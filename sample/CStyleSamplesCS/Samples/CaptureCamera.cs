using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenCvSharp;

namespace CStyleSamplesCS
{
    /// <summary>
    /// カメラのキャプチャ
    /// </summary>
    class CaptureCamera
    {
        public CaptureCamera()
        {
            using (CvCapture cap = CvCapture.FromCamera(0)) // device type + camera index
            using (CvWindow w = new CvWindow("SampleCapture"))
            {
                while (CvWindow.WaitKey(10) < 0)
                {
                    w.Image = cap.QueryFrame();
                }
            }
        }
    }
}