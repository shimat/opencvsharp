using System.Net.Http;

namespace OpenCvSharp.Tests
{
    public static class FileDownloader
    {
        private const int TimeoutMilliseconds = 5 * 60 * 1000;

        private static readonly HttpClient httpClient = new()
        {
            Timeout = TimeSpan.FromMilliseconds(TimeoutMilliseconds)
        };

        public static byte[] DownloadData(Uri address)
        {
            using var httpRequest = new HttpRequestMessage(HttpMethod.Get, address);
            using var httpResponse = httpClient.Send(httpRequest);
            using var memoryStream = new MemoryStream();
            httpResponse.Content.ReadAsStream().CopyTo(memoryStream);
            return memoryStream.ToArray();
        }
    }
}