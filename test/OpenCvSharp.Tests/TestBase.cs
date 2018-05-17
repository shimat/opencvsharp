using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

[assembly: CollectionBehavior(/*MaxParallelThreads = 2, */DisableTestParallelization = true)]

namespace OpenCvSharp.Tests
{
    public abstract class TestBase
    {
        private static readonly HttpClient httpClient;

        static TestBase()
        {
            ServicePointManager.ServerCertificateValidationCallback = (sender, certificate, chain, sslPolicyErrors) => true;
#if net46
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;
#endif

            httpClient = new HttpClient
            {
                Timeout = TimeSpan.FromMinutes(5)
            };
        }

        protected static Mat Image(string fileName, ImreadModes modes = ImreadModes.Color)
        {
            return new Mat(Path.Combine("_data", "image", fileName), modes);
        }

        protected static void ImageEquals(Mat img1, Mat img2)
        {
            if (img1 == null && img2 == null)
                return;
            Assert.NotNull(img1);
            Assert.NotNull(img2);
            Assert.Equal(img1.Type(), img2.Type());

            using (var comparison = new Mat())
            {
                Cv2.Compare(img1, img2, comparison, CmpTypes.NE);
                if (img1.Channels() == 1)
                {
                    Assert.Equal(0, Cv2.CountNonZero(comparison));
                }
                else
                {
                    var channels = Cv2.Split(comparison);
                    try
                    {
                        foreach (var channel in channels)
                        {
                            Assert.Equal(0, Cv2.CountNonZero(channel));
                        }
                    }
                    finally
                    {
                        foreach (var channel in channels)
                        {
                            channel.Dispose();
                        }
                    }
                }
            }
        }

        protected static void ShowImagesWhenDebugMode(params Mat[] mats)
        {
            if (Debugger.IsAttached)
            {
                Window.ShowImages(mats);
            }
        }

        protected static void Pause(string message = "Press any key to exit")
        {
            if (Debugger.IsAttached)
            {
                Console.WriteLine();
                Console.WriteLine(message);
                Console.Read();
            }
        }

        protected static async Task<byte[]> DownloadBytes(string url)
        {
            var response = (await httpClient.GetAsync(url)).EnsureSuccessStatusCode();
            return await response.Content.ReadAsByteArrayAsync();
        }

        protected static async Task<string> DownloadString(string url)
        {
            var response = (await httpClient.GetAsync(url)).EnsureSuccessStatusCode();
            return await response.Content.ReadAsStringAsync();
        }
    }
}
