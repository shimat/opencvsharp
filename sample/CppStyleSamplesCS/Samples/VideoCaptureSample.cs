using System;
using System.Diagnostics;
using System.Drawing;
using OpenCvSharp;
using OpenCvSharp.CPlusPlus;
using System.Windows.Forms;

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
            VideoCapture capture = new VideoCapture(FilePath.Bach);

            int sleepTime = (int)Math.Round(1000 / capture.Fps);

            using (Window window = new Window("capture"))
            {
                // Frame image buffer
                Mat image = new Mat();

                // When the movie playback reaches end, Mat.data becomes NULL.
                do
                {
                    capture.Read(image); // same as cvQueryImage
                    window.ShowImage(image);
                    Cv2.WaitKey(sleepTime);
                } while (!image.Empty());
            }
        }

    }
}