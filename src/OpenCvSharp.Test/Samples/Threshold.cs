using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OpenCvSharp.Test
{
    /// <summary>
    /// 2値化
    /// </summary>
    class Threshold
    {        
        public Threshold()
        {
            using (IplImage src = new IplImage(Const.ImageLenna, LoadMode.Color))
            using (IplImage srcGray = new IplImage(src.Size, BitDepth.U8, 1))
            using (IplImage dst = new IplImage(src.Size, BitDepth.U8, 1))
            using (CvWindow window = new CvWindow("SampleThreshold"))
            {
                src.CvtColor(srcGray, ColorConversion.BgrToGray);
                srcGray.Smooth(srcGray, SmoothType.Gaussian, 5);
                int threshold = 90;
                window.CreateTrackbar("threshold", threshold, 255, delegate(int pos)
                {
                    srcGray.Threshold(dst, pos, 255, ThresholdType.Binary);
                    window.Image = dst;
                });
                srcGray.Threshold(dst, threshold, 255, ThresholdType.Binary);
                window.Image = dst;
                CvWindow.WaitKey();
            }
        }
    }
}
