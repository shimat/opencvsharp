using System;
using System.Collections.Generic;
using System.Linq;
using OpenCvSharp;
using OpenCvSharp.CPlusPlus;

namespace CppStyleSamplesCS
{
    /// <summary>
    /// 
    /// </summary>
    class SuperResolutionSample : ISample
    {
        public void Run()
        {
            var capture = new VideoCapture();
            capture.Set(CaptureProperty.FrameWidth, 640);
            capture.Set(CaptureProperty.FrameHeight, 480);
            capture.Open(-1);
            if (!capture.IsOpened())
                throw new Exception("capture initialization failed");

            var fs = FrameSource.CreateCameraSource(-1);
            var sr = SuperResolution.CreateBTVL1();
            sr.SetInput(fs);

            using (var normalWindow = new Window("normal"))
            using (var srWindow = new Window("super resolution"))
            {
                var normalFrame = new Mat();
                var srFrame = new Mat();
                while (true)
                {
                    capture.Read(normalFrame);
                    sr.NextFrame(srFrame);
                    if (normalFrame.Empty() || srFrame.Empty())
                        break;
                    normalWindow.ShowImage(normalFrame);
                    srWindow.ShowImage(srFrame);
                    Cv2.WaitKey(100);
                }
            }
        }
    }
}