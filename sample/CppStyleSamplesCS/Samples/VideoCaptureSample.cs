using System;
using OpenCvSharp;
using OpenCvSharp.CPlusPlus;
using SampleBase;

namespace CppStyleSamplesCS
{
    /// <summary>
    /// 
    /// </summary>
    class VideoCaptureSample : ISample
    {
        public void Run()
        {
            // Opens MP4 file (ffmpeg is probably needed)
            VideoCapture capture = new VideoCapture(FilePath.Movie.Bach);

            int sleepTime = (int)Math.Round(1000 / capture.Fps);

            using (Window window = new Window("capture"))
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