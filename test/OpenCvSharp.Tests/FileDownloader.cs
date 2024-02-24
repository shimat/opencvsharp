#if NET48
using System.Net;
#else
using System.Net.Http;
#endif

namespace OpenCvSharp.Tests
{
    public static class FileDownloader
    {
        private const int TimeoutMilliseconds = 5 * 60 * 1000;

#if !NET48
        private static readonly HttpClient httpClient = new()
        {
            Timeout = TimeSpan.FromMilliseconds(TimeoutMilliseconds)
        };
#endif

        public static byte[] DownloadData(Uri address)
        {
#if NET48
            var webRequest = WebRequest.CreateHttp(address);
            webRequest.Method = "GET";
            webRequest.Timeout = TimeoutMilliseconds;
            using var response = webRequest.GetResponse();
            using var responseStream = response.GetResponseStream();
            using var memoryStream = new MemoryStream();
            responseStream.CopyTo(memoryStream);
            return memoryStream.ToArray();
#else
            using var httpRequest = new HttpRequestMessage(HttpMethod.Get, address);
            using var httpResponse = httpClient.Send(httpRequest);
            using var memoryStream = new MemoryStream();
            httpResponse.Content.ReadAsStream().CopyTo(memoryStream);
            return memoryStream.ToArray();
#endif
        }
    }
}