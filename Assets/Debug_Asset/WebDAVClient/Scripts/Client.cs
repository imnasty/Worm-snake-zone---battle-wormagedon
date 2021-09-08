using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using WebDAVClient.Helpers;
using WebDAVClient.HttpClient;
using WebDAVClient.Model;

namespace WebDAVClient
{
    public class Client : ScriptableObject
    {
        #region Private consts
        private static readonly HttpMethod s_propFindMethod = new HttpMethod("PROPFIND");
        private static readonly HttpMethod s_moveMethod = new HttpMethod("MOVE");
        private static readonly HttpMethod s_copyMethod = new HttpMethod("COPY");
        private static readonly HttpMethod s_mkColMethod = new HttpMethod(WebRequestMethods.Http.MkCol);
        private static readonly string s_assemblyVersion = typeof(Item).Assembly.GetName().Version.ToString();

        private const int c_httpStatusCode_MultiStatus = 207;

        // http://webdav.org/specs/rfc4918.html#METHOD_PROPFIND
        private const string c_propFindRequestContent =
            "<?xml version=\"1.0\" encoding=\"utf-8\" ?>" +
            "<propfind xmlns=\"DAV:\">" +
            "<allprop/>" +
            "</propfind>";
        #endregion

        #region Public properties
        [Header("Server details")]
        [Tooltip("Specify the WebDAV hostname (required).")]
        public string server;
        [Tooltip("Specify the WebDAV hostname (required).")]
        public string basePath = "/";

        [Space]
        [Header("User Agent")]
        [Tooltip("Specify the UserAgent string to use in requests")]
        public string userAgent;
        [Tooltip("Specify the UserAgent Version string to use in requests")]
        public string userAgentVersion;

        [Header("Credentials")]
        [Tooltip("Specify the WebDAV hostname (required).")]
        public string username;
        [PasswordField]
        [Tooltip("Specify the WebDAV hostname (required).")]
        public string password;

        [Header("Other")]
        [Tooltip("Timeout during upload operations (in milliseconds")]
        [Range(0, 60000)]
        public int uploadTimeout;
        #endregion

        #region Private fields
        private string m_encodedBasePath;
        private HttpClientHandler m_handler;
        private HttpClientWrapper m_httpClientWrapper;
        private bool m_initialized;
        #endregion

        #region Public methods

        public void GetUsername()
        {
            username=PlayerPrefs.GetString("Username");
        }
        public void GetPassword()
        {
            password=PlayerPrefs.GetString("Password");
        }
        public void Reset()
        {
            m_initialized = false;
        }

        /// <summary>
        /// List all files present on the server.
        /// </summary>
        /// <param name="path">List only files in this path</param>
        /// <param name="depth">Recursion depth</param>
        /// <returns>A list of files (entries without a trailing slash) and directories (entries with a trailing slash)</returns>
        public IEnumerable<Item> List(string path = "/", int? depth = 1)
        {
            return ListAsync(path, depth).GetAwaiter().GetResult();
        }

        /// <summary>
        /// List all files present on the server.
        /// </summary>
        /// <param name="path">List only files in this path</param>
        /// <param name="depth">Recursion depth</param>
        /// <returns>A list of files (entries without a trailing slash) and directories (entries with a trailing slash)</returns>
        public async Task<IEnumerable<Item>> ListAsync(string path = "/", int? depth = 1)
        {
            var listUri = await GetServerUrlAsync(path, true).ConfigureAwait(false);

            // Depth header: http://webdav.org/specs/rfc4918.html#rfc.section.9.1.4
            IDictionary<string, string> headers = new Dictionary<string, string>();
            if (depth != null)
            {
                headers.Add("Depth", depth.ToString());
            }

            HttpResponseMessage response = null;

            try
            {
                response = await HttpRequestAsync(listUri.Uri, s_propFindMethod, headers, Encoding.UTF8.GetBytes(c_propFindRequestContent)).ConfigureAwait(false);

                if (response.StatusCode != HttpStatusCode.OK &&
                    (int)response.StatusCode != c_httpStatusCode_MultiStatus)
                {
                    throw new WebDAVException((int)response.StatusCode, "Failed retrieving items in folder.");
                }

                using (var stream = await response.Content.ReadAsStreamAsync().ConfigureAwait(false))
                {
                    var items = ResponseParser.ParseItems(stream);

                    if (items == null)
                    {
                        throw new WebDAVException("Failed deserializing data returned from server.");
                    }

                    var listUrl = listUri.ToString();

                    var result = new List<Item>(items.Count());
                    foreach (var item in items)
                    {
                        // If it's not a collection, add it to the result
                        if (!item.IsCollection)
                        {
                            result.Add(item);
                        }
                        else
                        {
                            // If it's not the requested parent folder, add it to the result
                            var fullHref = await GetServerUrlAsync(item.Href, true).ConfigureAwait(false);
                            if (!string.Equals(fullHref.ToString(), listUrl, StringComparison.CurrentCultureIgnoreCase))
                            {
                                result.Add(item);
                            }
                        }
                    }
                    return result;
                }
            }
            finally
            {
                response?.Dispose();
            }
        }

        /// <summary>
        /// List all files present on the server.
        /// </summary>
        /// <returns>An item representing the retrieved folder</returns>
        public Item GetFolder(string path = "/")
        {
            return GetFolderAsync(path).GetAwaiter().GetResult();
        }

          /// <summary>
        /// List all files present on the server.
        /// </summary>
        /// <returns>An item representing the retrieved folder</returns>
        public async Task<Item> GetFolderAsync(string path = "/")
        {
            var listUri = await GetServerUrlAsync(path, true).ConfigureAwait(false);
            return await GetAsync(listUri.Uri).ConfigureAwait(false);
        }

        /// <summary>
        /// Get file present on the server.
        /// </summary>
        /// <returns>An item representing the retrieved file</returns>
        public Item GetFile(string path = "/")
        {
            return GetFileAsync(path).GetAwaiter().GetResult();
        }

        /// <summary>
        /// Get file present on the server.
        /// </summary>
        /// <returns>An item representing the retrieved file</returns>
        public async Task<Item> GetFileAsync(string path = "/")
        {
            var listUri = await GetServerUrlAsync(path, false).ConfigureAwait(false);
            return await GetAsync(listUri.Uri).ConfigureAwait(false);
        }

        /// <summary>
        /// Download a file from the server
        /// </summary>
        /// <param name="remoteFilePath">Source path and filename of the file on the server</param>
        /// <returns>A stream with the content of the downloaded file</returns>
        public Stream Download(string remoteFilePath)
        {
            return DownloadAsync(remoteFilePath).GetAwaiter().GetResult();
        }

        public async Task<Stream> DownloadAsync(string remoteFilePath)
        {
            var dictionary = new Dictionary<string, string> { { "translate", "f" } };
            return await DownloadFileAsync(remoteFilePath, dictionary).ConfigureAwait(false);
        }

        /// <summary>
        /// Download a part of file from the server
        /// </summary>
        /// <param name="remoteFilePath">Source path and filename of the file on the server</param>
        /// <param name="startBytes">Start bytes of content</param>
        /// <param name="endBytes">End bytes of content</param>
        /// <returns>A stream with the partial content of the downloaded file</returns>
        public Stream DownloadPartial(string remoteFilePath, long startBytes, long endBytes)
        {
            return DownloadPartialAsync(remoteFilePath, startBytes, endBytes).GetAwaiter().GetResult();
        }

        /// <summary>
        /// Download a part of file from the server
        /// </summary>
        /// <param name="remoteFilePath">Source path and filename of the file on the server</param>
        /// <param name="startBytes">Start bytes of content</param>
        /// <param name="endBytes">End bytes of content</param>
        /// <returns>A stream with the partial content of the downloaded file</returns>
        public async Task<Stream> DownloadPartialAsync(string remoteFilePath, long startBytes, long endBytes)
        {
            var dictionary = new Dictionary<string, string> { { "translate", "f" }, { "Range", "bytes=" + startBytes + "-" + endBytes } };
            return await DownloadFileAsync(remoteFilePath, dictionary).ConfigureAwait(false);
        }

        /// <summary>
        /// Upload a file to the server
        /// </summary>
        /// <param name="remoteFilePath">Source path and filename of the file on the server</param>
        /// <param name="content"></param>
        /// <param name="name"></param>
        /// <returns>True if the file was uploaded successfully. False otherwise</returns>
        public bool Upload(string remoteFilePath, Stream content, string name)
        {
            return UploadAsync(remoteFilePath, content, name).GetAwaiter().GetResult();
        }

        /// <summary>
        /// Upload a file to the server
        /// </summary>
        /// <param name="remoteFilePath">Source path and filename of the file on the server</param>
        /// <param name="content"></param>
        /// <param name="name"></param>
        /// <returns>True if the file was uploaded successfully. False otherwise</returns>
        public async Task<bool> UploadAsync(string remoteFilePath, Stream content, string name)
        {
            // Should not have a trailing slash.
            var uploadUri = await GetServerUrlAsync(remoteFilePath.TrimEnd('/') + "/" + name.TrimStart('/'), false).ConfigureAwait(false);

            HttpResponseMessage response = null;

            try
            {
                response = await HttpUploadRequestAsync(uploadUri.Uri, HttpMethod.Put, content).ConfigureAwait(false);

                if (response.StatusCode != HttpStatusCode.OK &&
                    response.StatusCode != HttpStatusCode.NoContent &&
                    response.StatusCode != HttpStatusCode.Created)
                {
                    Debug.LogError("ybabuf");
                    throw new WebDAVException((int) response.StatusCode, "Failed uploading file.");
                }

                return response.IsSuccessStatusCode;
            }
            finally
            {
                PlayerPrefs.SetInt("loadingscreen",PlayerPrefs.GetInt("loadingscreen")+1);
                Debug.LogWarning("Загрузка завершена");
                response?.Dispose();
            }
        }

        /// <summary>
        /// Partial upload a part of file to the server
        /// </summary>
        /// <param name="remoteFilePath">Source path and filename of the file on the server</param>
        /// <param name="content">Partial content to update</param>
        /// <param name="name">Name of the file to update</param>
        /// <param name="startBytes">Start byte position of the target content</param>
        /// <param name="endBytes">End bytes of the target content. Must match the length of <paramref name="content"/> plus <paramref name="startBytes"/></param>
        /// <returns>True if the file part was uploaded successfully. False otherwise</returns>
        public bool UploadPartial(string remoteFilePath, Stream content, string name, long startBytes, long endBytes)
        {
            return UploadPartialAsync(remoteFilePath, content, name, startBytes, endBytes).GetAwaiter().GetResult();
        }

        /// <summary>
        /// Partial upload a part of file to the server
        /// </summary>
        /// <param name="remoteFilePath">Source path and filename of the file on the server</param>
        /// <param name="content">Partial content to update</param>
        /// <param name="name">Name of the file to update</param>
        /// <param name="startBytes">Start byte position of the target content</param>
        /// <param name="endBytes">End bytes of the target content. Must match the length of <paramref name="content"/> plus <paramref name="startBytes"/></param>
        /// <returns>True if the file part was uploaded successfully. False otherwise</returns>
        public async Task<bool> UploadPartialAsync(string remoteFilePath, Stream content, string name, long startBytes, long endBytes)
        {
            if (startBytes + content.Length != endBytes)
            {
                throw new InvalidOperationException("The length of the given content plus the startBytes must match the endBytes.");
            }

            // Should not have a trailing slash. 
            var uploadUri = await GetServerUrlAsync(remoteFilePath.TrimEnd('/') + "/" + name.TrimStart('/'), false).ConfigureAwait(false);

            HttpResponseMessage response = null;

            try
            {
                response = await HttpUploadRequestAsync(uploadUri.Uri, HttpMethod.Put, content, null, startBytes, endBytes).ConfigureAwait(false);

                if (response.StatusCode != HttpStatusCode.OK &&
                    response.StatusCode != HttpStatusCode.NoContent &&
                    response.StatusCode != HttpStatusCode.Created)
                {
                    throw new WebDAVException((int) response.StatusCode, "Failed uploading file.");
                }

                return response.IsSuccessStatusCode;
            }
            finally
            {
                response?.Dispose();
            }
        }

        /// <summary>
        /// Create a directory on the server
        /// </summary>
        /// <param name="remotePath">Destination path of the directory on the server</param>
        /// <param name="name">The name of the folder to create</param>
        /// <returns>True if the folder was created successfully. False otherwise</returns>
        public bool CreateDir(string remotePath, string name)
        {
            return CreateDirAsync(remotePath, name).GetAwaiter().GetResult();
        }

        /// <summary>
        /// Create a directory on the server
        /// </summary>
        /// <param name="remotePath">Destination path of the directory on the server</param>
        /// <param name="name">The name of the folder to create</param>
        /// <returns>True if the folder was created successfully. False otherwise</returns>
        public async Task<bool> CreateDirAsync(string remotePath, string name)
        {
            // Should not have a trailing slash.
            var dirUri = await GetServerUrlAsync(remotePath.TrimEnd('/') + "/" + name.TrimStart('/'), false).ConfigureAwait(false);

            HttpResponseMessage response = null;

            try
            {
                response = await HttpRequestAsync(dirUri.Uri, s_mkColMethod).ConfigureAwait(false);

                if (response.StatusCode == HttpStatusCode.Conflict)
                    throw new WebDAVConflictException((int) response.StatusCode, "Failed creating folder.");

                if (response.StatusCode != HttpStatusCode.OK &&
                    response.StatusCode != HttpStatusCode.NoContent &&
                    response.StatusCode != HttpStatusCode.Created)
                {
                    throw new WebDAVException((int)response.StatusCode, "Failed creating folder.");
                }

                return response.IsSuccessStatusCode;
            }
            finally
            {
                response?.Dispose();
            }
        }

        /// <summary>
        /// Deletes a folder from the server.
        /// </summary>
        public void DeleteFolder(string href)
        {
            DeleteFolderAsync(href).GetAwaiter().GetResult();
        }

        /// <summary>
        /// Deletes a folder from the server.
        /// </summary>
        public async Task DeleteFolderAsync(string href)
        {
            var listUri = await GetServerUrlAsync(href, true).ConfigureAwait(false);
            await DeleteAsync(listUri.Uri).ConfigureAwait(false);
        }

        /// <summary>
        /// Deletes a file from the server.
        /// </summary>
        public void DeleteFile(string href)
        {
            DeleteFileAsync(href).GetAwaiter().GetResult();
        }

        /// <summary>
        /// Deletes a file from the server.
        /// </summary>
        public async Task DeleteFileAsync(string href)
        {
            var listUri = await GetServerUrlAsync(href, false).ConfigureAwait(false);
            await DeleteAsync(listUri.Uri).ConfigureAwait(false);
        }

        /// <summary>
        /// Move a folder on the server
        /// </summary>
        /// <param name="srcFolderPath">Source path of the folder on the server</param>
        /// <param name="dstFolderPath">Destination path of the folder on the server</param>
        /// <returns>True if the folder was moved successfully. False otherwise</returns>
        public bool MoveFolder(string srcFolderPath, string dstFolderPath)
        {
            return MoveFolderAsync(srcFolderPath, dstFolderPath).GetAwaiter().GetResult();
        }

        /// <summary>
        /// Move a folder on the server
        /// </summary>
        /// <param name="srcFolderPath">Source path of the folder on the server</param>
        /// <param name="dstFolderPath">Destination path of the folder on the server</param>
        /// <returns>True if the folder was moved successfully. False otherwise</returns>
        public async Task<bool> MoveFolderAsync(string srcFolderPath, string dstFolderPath)
        {
            // Should have a trailing slash.
            var srcUri = await GetServerUrlAsync(srcFolderPath, true).ConfigureAwait(false);
            var dstUri = await GetServerUrlAsync(dstFolderPath, true).ConfigureAwait(false);

            return await MoveAsync(srcUri.Uri, dstUri.Uri).ConfigureAwait(false);
        }

        /// <summary>
        /// Move a file on the server
        /// </summary>
        /// <param name="srcFilePath">Source path and filename of the file on the server</param>
        /// <param name="dstFilePath">Destination path and filename of the file on the server</param>
        /// <returns>True if the file was moved successfully. False otherwise</returns>
        public bool MoveFile(string srcFilePath, string dstFilePath)
        {
            return MoveFileAsync(srcFilePath, dstFilePath).GetAwaiter().GetResult();
        }

        /// <summary>
        /// Move a file on the server
        /// </summary>
        /// <param name="srcFilePath">Source path and filename of the file on the server</param>
        /// <param name="dstFilePath">Destination path and filename of the file on the server</param>
        /// <returns>True if the file was moved successfully. False otherwise</returns>
        public async Task<bool> MoveFileAsync(string srcFilePath, string dstFilePath)
        {
            // Should not have a trailing slash.
            var srcUri = await GetServerUrlAsync(srcFilePath, false).ConfigureAwait(false);
            var dstUri = await GetServerUrlAsync(dstFilePath, false).ConfigureAwait(false);

            return await MoveAsync(srcUri.Uri, dstUri.Uri).ConfigureAwait(false);
        }

        /// <summary>
        /// Copies a folder on the server
        /// </summary>
        /// <param name="srcFolderPath">Source path of the folder on the server</param>
        /// <param name="dstFolderPath">Destination path of the folder on the server</param>
        /// <returns>True if the folder was copied successfully. False otherwise</returns>
        public bool CopyFolder(string srcFolderPath, string dstFolderPath)
        {
            return CopyFolderAsync(srcFolderPath, dstFolderPath).GetAwaiter().GetResult();
        }

        /// <summary>
        /// Copies a folder on the server
        /// </summary>
        /// <param name="srcFolderPath">Source path of the folder on the server</param>
        /// <param name="dstFolderPath">Destination path of the folder on the server</param>
        /// <returns>True if the folder was copied successfully. False otherwise</returns>
        public async Task<bool> CopyFolderAsync(string srcFolderPath, string dstFolderPath)
        {
            // Should have a trailing slash.
            var srcUri = await GetServerUrlAsync(srcFolderPath, true).ConfigureAwait(false);
            var dstUri = await GetServerUrlAsync(dstFolderPath, true).ConfigureAwait(false);

            return await CopyAsync(srcUri.Uri, dstUri.Uri).ConfigureAwait(false);
        }

        /// <summary>
        /// Copies a file on the server
        /// </summary>
        /// <param name="srcFilePath">Source path and filename of the file on the server</param>
        /// <param name="dstFilePath">Destination path and filename of the file on the server</param>
        /// <returns>True if the file was copied successfully. False otherwise</returns>
        public bool CopyFile(string srcFilePath, string dstFilePath)
        {
            return CopyFileAsync(srcFilePath, dstFilePath).GetAwaiter().GetResult();
        }

        /// <summary>
        /// Copies a file on the server
        /// </summary>
        /// <param name="srcFilePath">Source path and filename of the file on the server</param>
        /// <param name="dstFilePath">Destination path and filename of the file on the server</param>
        /// <returns>True if the file was copied successfully. False otherwise</returns>
        public async Task<bool> CopyFileAsync(string srcFilePath, string dstFilePath)
        {
            // Should not have a trailing slash.
            var srcUri = await GetServerUrlAsync(srcFilePath, false).ConfigureAwait(false);
            var dstUri = await GetServerUrlAsync(dstFilePath, false).ConfigureAwait(false);

            return await CopyAsync(srcUri.Uri, dstUri.Uri).ConfigureAwait(false);
        }
        #endregion

        #region Private methods

        private void Initialize()
        {
            if (m_initialized && m_httpClientWrapper != null)
                return;

            server = server.TrimEnd('/');
            basePath = basePath.Trim('/');
            if (string.IsNullOrEmpty(basePath))
                basePath = "/";
            else
                basePath = "/" + basePath + "/";

            m_handler = new HttpClientHandler();
            if (m_handler.SupportsAutomaticDecompression)
                m_handler.AutomaticDecompression = DecompressionMethods.Deflate | DecompressionMethods.GZip;

            if (!string.IsNullOrEmpty(username) && !string.IsNullOrEmpty(password))
            {
                m_handler.Credentials = new NetworkCredential(username, password);
                m_handler.PreAuthenticate = true;
            }
            else
            {
                m_handler.UseDefaultCredentials = true;
            }

            var client = new System.Net.Http.HttpClient(m_handler);
            client.DefaultRequestHeaders.ExpectContinue = false;

            m_httpClientWrapper = new HttpClientWrapper(client, client);
            if (uploadTimeout != 0)
            {
                if (m_httpClientWrapper.httpClient != m_httpClientWrapper.uploadHttpClient)
                {
                    m_httpClientWrapper.uploadHttpClient.Timeout = TimeSpan.FromMilliseconds(uploadTimeout);
                }
                else
                {
                    m_httpClientWrapper.uploadHttpClient = new System.Net.Http.HttpClient(m_handler);
                    m_httpClientWrapper.uploadHttpClient.DefaultRequestHeaders.ExpectContinue = false;
                    m_httpClientWrapper.uploadHttpClient.Timeout = TimeSpan.FromMilliseconds(uploadTimeout);
                }
            }
            m_initialized = true;
        }

        /// <summary>
        /// Perform the WebDAV call and fire the callback when finished.
        /// </summary>
        /// <param name="uri"></param>
        /// <param name="method"></param>
        /// <param name="headers"></param>
        /// <param name="content"></param>
        private async Task<HttpResponseMessage> HttpRequestAsync(Uri uri, HttpMethod method, IDictionary<string, string> headers = null, byte[] content = null)
        {
            using (var request = new HttpRequestMessage(method, uri))
            {
                request.Headers.Connection.Add("Keep-Alive");
                if (!string.IsNullOrWhiteSpace(userAgent))
                    request.Headers.UserAgent.Add(new ProductInfoHeaderValue(userAgent, userAgentVersion));
                else
                    request.Headers.UserAgent.Add(new ProductInfoHeaderValue("WebDAVClient", s_assemblyVersion));

                if (headers != null)
                {
                    foreach (string key in headers.Keys)
                    {
                        request.Headers.Add(key, headers[key]);
                    }
                }

                // Need to send along content?
                if (content != null)
                {
                    request.Content = new ByteArrayContent(content);
                    request.Content.Headers.ContentType = new MediaTypeHeaderValue("text/xml");
                }

                return await m_httpClientWrapper.SendAsync(request, HttpCompletionOption.ResponseHeadersRead).ConfigureAwait(false);
            }
        }

        /// <summary>
        /// Perform the WebDAV call and fire the callback when finished.
        /// </summary>
        /// <param name="uri"></param>
        /// <param name="method"></param>
        /// <param name="content"></param>
        /// <param name="headers"></param>
        private async Task<HttpResponseMessage> HttpUploadRequestAsync(Uri uri, HttpMethod method, Stream content, IDictionary<string, string> headers = null, long? startbytes = null, long? endbytes = null)
        {
            Initialize();

            using (var request = new HttpRequestMessage(method, uri))
            {
                request.Headers.Connection.Add("Keep-Alive");
                if (!string.IsNullOrWhiteSpace(userAgent))
                    request.Headers.UserAgent.Add(new ProductInfoHeaderValue(userAgent, userAgentVersion));
                else
                    request.Headers.UserAgent.Add(new ProductInfoHeaderValue("WebDAVClient", s_assemblyVersion));

                if (headers != null)
                {
                    foreach (string key in headers.Keys)
                    {
                        request.Headers.Add(key, headers[key]);
                    }
                }

                // Need to send along content?
                if (content != null)
                {
                    request.Content = new StreamContent(content);
                    if (startbytes.HasValue && endbytes.HasValue)
                    {
                        request.Content.Headers.ContentRange = ContentRangeHeaderValue.Parse($"bytes {startbytes}-{endbytes}/*");
                        request.Content.Headers.ContentLength = endbytes - startbytes;
                    }
                }

                return await m_httpClientWrapper.SendUploadAsync(request).ConfigureAwait(false);
            }
        }

        private async Task<bool> MoveAsync(Uri srcUri, Uri dstUri)
        {
            const string requestContent = "MOVE";

            var headers = new Dictionary<string, string>(1)
            {
                { "Destination", dstUri.ToString() }
            };

            var response = await HttpRequestAsync(srcUri, s_moveMethod, headers, Encoding.UTF8.GetBytes(requestContent)).ConfigureAwait(false);

            if (response.StatusCode != HttpStatusCode.OK &&
                response.StatusCode != HttpStatusCode.Created)
            {
                throw new WebDAVException((int)response.StatusCode, "Failed moving file.");
            }

            return response.IsSuccessStatusCode;
        }

        private async Task<bool> CopyAsync(Uri srcUri, Uri dstUri)
        {
            const string requestContent = "COPY";

            var headers = new Dictionary<string, string>(1)
            {
                { "Destination", dstUri.ToString() }
            };

            var response = await HttpRequestAsync(srcUri, s_copyMethod, headers, Encoding.UTF8.GetBytes(requestContent)).ConfigureAwait(false);

            if (response.StatusCode != HttpStatusCode.OK &&
                response.StatusCode != HttpStatusCode.Created)
            {
                throw new WebDAVException((int) response.StatusCode, "Failed copying file.");
            }

            return response.IsSuccessStatusCode;
        }

        private async Task<Stream> DownloadFileAsync(string remoteFilePath, Dictionary<string, string> header)
        {
            // Should not have a trailing slash.
            var downloadUri = await GetServerUrlAsync(remoteFilePath, false).ConfigureAwait(false);
            var response = await HttpRequestAsync(downloadUri.Uri, HttpMethod.Get, header).ConfigureAwait(false);
            if (response.StatusCode == HttpStatusCode.OK || response.StatusCode == HttpStatusCode.PartialContent)
            {
                return await response.Content.ReadAsStreamAsync().ConfigureAwait(false);
            }
            throw new WebDAVException((int)response.StatusCode, "Failed retrieving file.");
        }

        /// <summary>
        /// Try to create an Uri with kind UriKind.Absolute
        /// This particular implementation also works on Mono/Linux
        /// It seems that on Mono it is expected behaviour that uris
        /// of kind /a/b are indeed absolute uris since it referes to a file in /a/b.
        /// https://bugzilla.xamarin.com/show_bug.cgi?id=30854
        /// </summary>
        /// <param name="uriString"></param>
        /// <param name="uriResult"></param>
        private static bool TryCreateAbsolute(string uriString, out Uri uriResult)
        {
            return Uri.TryCreate(uriString, UriKind.Absolute, out uriResult) && uriResult.Scheme != Uri.UriSchemeFile;
        }

        private async Task<UriBuilder> GetServerUrlAsync(string path, bool appendTrailingSlash)
        {
            Initialize();

            // Resolve the base path on the server
            if (m_encodedBasePath == null)
            {
                var baseUri = new UriBuilder(server) {Path = basePath};
                var root = await GetAsync(baseUri.Uri).ConfigureAwait(false);

                m_encodedBasePath = root.Href;
            }

            // If we've been asked for the "root" folder
            if (string.IsNullOrEmpty(path))
            {
                // If the resolved base path is an absolute URI, use it
                Uri absoluteBaseUri;
                if (TryCreateAbsolute(m_encodedBasePath, out absoluteBaseUri))
                {
                    return new UriBuilder(absoluteBaseUri);
                }

                // Otherwise, use the resolved base path relatively to the server
                return new UriBuilder(server) { Path = m_encodedBasePath };
            }

            // If the requested path is absolute, use it
            Uri absoluteUri;
            if (TryCreateAbsolute(path, out absoluteUri))
            {
                return new UriBuilder(absoluteUri);
            }
            else
            {
                // Otherwise, create a URI relative to the server
                UriBuilder baseUri;
                if (TryCreateAbsolute(m_encodedBasePath, out absoluteUri))
                {
                    baseUri = new UriBuilder(absoluteUri);

                    baseUri.Path = baseUri.Path.TrimEnd('/') + "/" + path.TrimStart('/');

                    if (appendTrailingSlash && !baseUri.Path.EndsWith("/"))
                        baseUri.Path += "/";
                }
                else
                {
                    baseUri = new UriBuilder(server);

                    // Ensure we don't add the base path twice
                    var finalPath = path;
                    if (!finalPath.StartsWith(m_encodedBasePath, StringComparison.InvariantCultureIgnoreCase))
                    {
                        finalPath = m_encodedBasePath.TrimEnd('/') + "/" + path;
                    }
                    if (appendTrailingSlash)
                        finalPath = finalPath.TrimEnd('/') + "/";

                    baseUri.Path = finalPath;
                }

                return baseUri;
            }
        }

        private async Task<Item> GetAsync(Uri listUri)
        {
            // Depth header: http://webdav.org/specs/rfc4918.html#rfc.section.9.1.4
            IDictionary<string, string> headers = new Dictionary<string, string>(1)
            {
                { "Depth", "0" }
            };

            HttpResponseMessage response = null;

            try
            {
                response = await HttpRequestAsync(listUri, s_propFindMethod, headers, Encoding.UTF8.GetBytes(c_propFindRequestContent)).ConfigureAwait(false);

                if (response.StatusCode != HttpStatusCode.OK &&
                    (int) response.StatusCode != c_httpStatusCode_MultiStatus)
                {
                    throw new WebDAVException((int)response.StatusCode, string.Format("Failed retrieving item/folder (Status Code: {0})", response.StatusCode));
                }

                using (var stream = await response.Content.ReadAsStreamAsync().ConfigureAwait(false))
                {
                    var result = ResponseParser.ParseItem(stream);

                    if (result == null)
                    {
                        throw new WebDAVException("Failed deserializing data returned from server.");
                    }

                    return result;
                }
            }
            finally
            {
                response?.Dispose();
            }
        }

        private async Task DeleteAsync(Uri listUri)
        {
            var response = await HttpRequestAsync(listUri, HttpMethod.Delete).ConfigureAwait(false);

            if (response.StatusCode != HttpStatusCode.OK &&
                response.StatusCode != HttpStatusCode.NoContent)
            {
                throw new WebDAVException((int)response.StatusCode, "Failed deleting item.");
            }
        }
        #endregion
    }
}
