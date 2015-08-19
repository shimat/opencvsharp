using System;
using System.Diagnostics;
using OpenCvSharp;
using OpenCvSharp.XFeatures2D;
using SampleBase;

namespace SamplesCS
{
    /// <summary>
    /// Retrieves keypoints using the KAZE and AKAZE algorithm.
    /// </summary>
    internal class KAZESample : ISample
    {
        public void Run()
        {
            var gray = new Mat(FilePath.Image.Lenna, LoadMode.GrayScale);
            var kaze = KAZE.Create();
            var akaze = AKAZE.Create();

            var kazeDescriptors = new Mat();
            var akazeDescriptors = new Mat();
            KeyPoint[] kazeKeyPoints = null, akazeKeyPoints = null;
            var kazeTime = MeasureTime(() =>
                kaze.DetectAndCompute(gray, null, out kazeKeyPoints, kazeDescriptors));
            var akazeTime = MeasureTime(() =>
                akaze.DetectAndCompute(gray, null, out akazeKeyPoints, akazeDescriptors));

            var dstKaze = new Mat();
            var dstAkaze = new Mat();
            Cv2.DrawKeypoints(gray, kazeKeyPoints, dstKaze);
            Cv2.DrawKeypoints(gray, akazeKeyPoints, dstAkaze);

            using (new Window(String.Format("KAZE [{0:F2}ms]", kazeTime.TotalMilliseconds), dstKaze))
            using (new Window(String.Format("AKAZE [{0:F2}ms]", akazeTime.TotalMilliseconds), dstAkaze))
            {
                Cv2.WaitKey();
            }
        }

        private TimeSpan MeasureTime(Action action)
        {
            var watch = Stopwatch.StartNew();
            action();
            watch.Stop();
            return watch.Elapsed;
        }
    }
}