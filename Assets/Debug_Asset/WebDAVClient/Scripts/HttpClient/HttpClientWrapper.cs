using System.Net.Http;
using System.Threading.Tasks;

namespace WebDAVClient.HttpClient
{
    public class HttpClientWrapper : IHttpClientWrapper
    {
        public System.Net.Http.HttpClient httpClient;
        public System.Net.Http.HttpClient uploadHttpClient;

        public HttpClientWrapper(System.Net.Http.HttpClient httpClient, System.Net.Http.HttpClient uploadHttpClient)
        {
            this.httpClient = httpClient;
            this.uploadHttpClient = uploadHttpClient;
        }

        public HttpResponseMessage Send(HttpRequestMessage request, HttpCompletionOption responseHeadersRead)
        {
            return SendAsync(request, responseHeadersRead).GetAwaiter().GetResult();
        }

        public async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, HttpCompletionOption responseHeadersRead)
        {
            return await httpClient.SendAsync(request, responseHeadersRead).ConfigureAwait(false);
        }

        public HttpResponseMessage SendUpload(HttpRequestMessage request)
        {
            return SendUploadAsync(request).GetAwaiter().GetResult();
        }

        public async Task<HttpResponseMessage> SendUploadAsync(HttpRequestMessage request)
        {
            return await uploadHttpClient.SendAsync(request).ConfigureAwait(false);
        }
    }
}