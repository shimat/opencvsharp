using System;
using System.Runtime.InteropServices;
using OpenCvSharp;

namespace SamplesCore
{
    /// <summary>
    /// 
    /// </summary>
    class VideoCaptureSample : ISample
    {
        public void Run()
        {
            // Opens MP4 file (ffmpeg is probably needed)
            var capture = new VideoCapture(FilePath.Movie.Bach);

            int sleepTime = (int)Math.Round(1000 / capture.Fps);

            using (var window = new Window("capture"))
            {
                // Frame image buffer
                Mat image = new Mat();

                // When the movie playback reaches end, Mat.data becomes NULL.
                while (true)
                {
                    capture.Read(image); // same as cvQueryFrame
                    if(image.Empty())
                        break;

                    window.ShowImage(image);
                    Cv2.WaitKey(sleepTime);
                } 
            }
        }

    }
}