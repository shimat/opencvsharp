using OpenCvSharp;
using OpenCvSharp.CPlusPlus;
using SampleBase;

namespace CppStyleSamplesCS
{
    /// <summary>
    /// 
    /// </summary>
// ReSharper disable once InconsistentNaming
    class BgSubtractorMOG : ISample
    {
        public void Run()
        {
            using (var capture = new VideoCapture(FilePath.Movie.Bach))
            using (var mog = new BackgroundSubtractorMOG())
            using (var windowSrc = new Window("src"))
            using (var windowDst = new Window("dst"))
            {
                var frame = new Mat();
                var fg = new Mat();
                while (true)
                {
                    capture.Read(frame);
                    if(frame.Empty())
                        break;
                    mog.Run(frame, fg, 0.01);
                    
                    windowSrc.Image = frame;
                    windowDst.Image = fg;
                    Cv2.WaitKey(50);
                }
            }
        }
    }
}