using System.Net.Http;
using System.Threading.Tasks;

namespace WebDAVClient.HttpClient
{
    public interface IHttpClientWrapper
    {
        HttpResponseMessage Send(HttpRequestMessage request, HttpCompletionOption responseHeadersRead);
        HttpResponseMessage SendUpload(HttpRequestMessage request);
    }
}