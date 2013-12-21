using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenCvSharp;
using OpenCvSharp.CPlusPlus;

namespace OpenCvSharp.Test
{
    /// <summary>
    /// 
    /// </summary>
    class BgSubtractorMOG
    {
        public BgSubtractorMOG()
        {
            using (CvCapture capture = new CvCapture(Const.MovieHara)) // specify your movie file
            using (BackgroundSubtractorMOG mog = new BackgroundSubtractorMOG())            
            using (CvWindow windowSrc = new CvWindow("src"))
            using (CvWindow windowDst = new CvWindow("dst")) 
            {
                IplImage imgFrame;
                using (Mat imgFg = new Mat(capture.FrameWidth, capture.FrameHeight, MatrixType.U8C1))
                while ((imgFrame = capture.QueryFrame()) != null)
                {
                    mog.Run(new Mat(imgFrame, false), imgFg, 0.01);
                    
                    windowSrc.Image = imgFrame;
                    windowDst.Image = imgFg.ToIplImage();
                    Cv.WaitKey(50);
                }               

            }
        }
    }
}