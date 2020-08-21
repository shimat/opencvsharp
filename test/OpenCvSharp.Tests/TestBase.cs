using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

[assembly: CollectionBehavior(/*MaxParallelThreads = 2, */DisableTestParallelization = true)]

#pragma warning disable CA1810 // Initialize reference type static fields inline
#pragma warning disable CA5359 

namespace OpenCvSharp.Tests
{
    public abstract class TestBase
    {
        private static readonly HttpClient httpClient;
        
        static TestBase()
        {
            ServicePointManager.ServerCertificateValidationCallback = (sender, certificate, chain, sslPolicyErrors) => true;

#pragma warning disable CA5364
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;
#pragma warning restore CA5364

#pragma warning disable CA2000 
            var handler = new HttpClientHandler
            {
                ServerCertificateCustomValidationCallback = delegate { return true; }
            };
#pragma warning restore CA2000
            httpClient = new HttpClient(handler)
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
#pragma warning disable CS8602
#pragma warning disable CA1062
            Assert.Equal(img1.Type(), img2.Type());
#pragma warning restore CS8602 
#pragma warning restore CA1062 

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

        protected static void ShowImagesWhenDebugMode(IEnumerable<Mat> mats, IEnumerable<string> names)
        {
            if (Debugger.IsAttached)
            {
                Window.ShowImages(mats, names);
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

        protected static byte[] DownloadBytes(
            Uri uri, 
            Action<(long BytesReceived, long TotalBytesToReceive, int ProgressPercentage)>? downloadProgressChangedEvent = null)
        {
            using var client = new MyWebClient();
            if (downloadProgressChangedEvent == null)
            {
                return client.DownloadData(uri);
            }

            var task = client.DownloadDataTaskAsync(
                uri,
                new Progress<(long BytesReceived, long TotalBytesToReceive, int ProgressPercentage)>(downloadProgressChangedEvent));
            return task.Result;
            //var response = (httpClient.GetAsync(uri).Result).EnsureSuccessStatusCode();
            //return response.Content.ReadAsByteArrayAsync().Result;
        }

        private static byte[] DownloadAndCacheBytes(Uri uri, string fileName)
        {
            lock (lockObj)
            {
                if (File.Exists(fileName))
                {
                    return File.ReadAllBytes(fileName);
                }

                var contents = DownloadBytes(uri);
                File.WriteAllBytes(fileName, contents);
                return contents;
            }
        }
        private static readonly object lockObj = new object();

        protected static async Task<byte[]> DownloadBytesAsync(Uri uri, CancellationToken token = default)
        {
            var response = await httpClient.GetAsync(uri, token).ConfigureAwait(false);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsByteArrayAsync().ConfigureAwait(false);
        }

        protected static async Task<Stream> DownloadStreamAsync(Uri uri, CancellationToken token = default)
        {
            var response = await httpClient.GetAsync(uri, token).ConfigureAwait(false);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsStreamAsync().ConfigureAwait(false);
        }

        protected static string DownloadString(Uri uri)
        {
            using var client = new MyWebClient();
            return client.DownloadString(uri);
            //var response = (await httpClient.GetAsync(url)).EnsureSuccessStatusCode();
            //return await response.Content.ReadAsStringAsync();
        }
    }
}
