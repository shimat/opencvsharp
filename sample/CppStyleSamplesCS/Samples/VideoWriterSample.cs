using System;
using OpenCvSharp;
using OpenCvSharp.CPlusPlus;
using SampleBase;

namespace CppStyleSamplesCS
{
    /// <summary>
    /// 
    /// </summary>
    class VideoWriterSample : ISample
    {
        public void Run()
        {
            const string OutVideoFile = "out.avi";

            // Opens MP4 file (ffmpeg is probably needed)
            VideoCapture capture = new VideoCapture(FilePath.Movie.Bach);

            // Read movie frames and write them to VideoWriter 
            Size dsize = new Size(640, 480);
            using (VideoWriter writer = new VideoWriter(OutVideoFile, -1, capture.Fps, dsize))
            {
                Console.WriteLine("Converting each movie frames...");
                Mat frame = new Mat();
                while(true)
                {
                    // Read image
                    capture.Read(frame);
                    if(frame.Empty())
                        break;

                    Console.CursorLeft = 0;
                    Console.Write("{0} / {1}", capture.PosFrames, capture.FrameCount);

                    // grayscale -> canny -> resize
                    Mat gray = new Mat();
                    Mat canny = new Mat();
                    Mat dst = new Mat();
                    Cv2.CvtColor(frame, gray, ColorConversion.BgrToGray);
                    Cv2.Canny(gray, canny, 100, 180);
                    Cv2.Resize(canny, dst, dsize, 0, 0, Interpolation.Linear);
                    // Write mat to VideoWriter
                    writer.Write(dst);
                } 
                Console.WriteLine();
            }

            // Watch result movie
            using (VideoCapture capture2 = new VideoCapture(OutVideoFile))
            using (Window window = new Window("result"))
            {
                int sleepTime = (int)(1000 / capture.Fps);

                Mat frame = new Mat();
                while (true)
                {
                    capture2.Read(frame);
                    if(frame.Empty())
                        break;

                    window.ShowImage(frame);
                    Cv2.WaitKey(sleepTime);
                }
            }
        }

    }
}