using System;
using System.Net;
using System.Threading.Tasks;

namespace OpenCvSharp.Tests
{
    internal class MyWebClient : WebClient
    {
        protected override WebRequest GetWebRequest(Uri uri)
        {
            WebRequest w = base.GetWebRequest(uri);
            w.Timeout = 5 * 60 * 1000; // ms
            return w;
        }
    }

    /// <summary>
    /// https://stackoverflow.com/questions/35281024/webclient-progress-reporting-using-tap
    /// </summary>
    internal static class MyWebClientExtensions
    {
        public static async Task<byte[]> DownloadDataTaskAsync(
            this MyWebClient webClient, 
            Uri address, 
            IProgress<(long BytesReceived, long TotalBytesToReceive, int ProgressPercentage)> progress)
        {
            // Create the task to be returned
            var tcs = new TaskCompletionSource<byte[]>(address);

            // Setup the callback event handler handlers
            void CompletedHandler(object sender, DownloadDataCompletedEventArgs e)
            {
                if (e.UserState == tcs)
                {
                    if (e.Error != null)
                        tcs.TrySetException(e.Error);
                    else if (e.Cancelled)
                        tcs.TrySetCanceled();
                    else
                        tcs.TrySetResult(e.Result);
                }
            }

            void ProgressChangedHandler(object ps, DownloadProgressChangedEventArgs pe)
            {
                if (pe.UserState == tcs)
                {
                    progress.Report((pe.BytesReceived, pe.TotalBytesToReceive, pe.ProgressPercentage));
                }
            }

            try
            {
                webClient.DownloadDataCompleted += CompletedHandler;
                webClient.DownloadProgressChanged += ProgressChangedHandler;

                webClient.DownloadDataAsync(address, tcs);

                return await tcs.Task.ConfigureAwait(false);
            }
            finally
            {
                webClient.DownloadDataCompleted -= CompletedHandler;
                webClient.DownloadProgressChanged -= ProgressChangedHandler;
            }
        }
    }
}