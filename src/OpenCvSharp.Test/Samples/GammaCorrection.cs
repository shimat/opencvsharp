using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenCvSharp;

namespace OpenCvSharp.Test
{
    /// <summary>
    /// Gamma correction
    /// </summary>
    class GammaCorrection
    {
        /// <summary>
        /// constructor
        /// </summary>
        public GammaCorrection()
        {
            using (IplImage imgSrc = new IplImage(Const.ImageLenna, LoadMode.AnyDepth | LoadMode.AnyColor))
            using (IplImage imgDst0_25 = imgSrc.Clone())
            using (IplImage imgDst0_5 = imgSrc.Clone())
            using (IplImage imgDst2 = imgSrc.Clone())            
            {
                CorrectGamma(imgSrc, imgDst0_25, 0.25);
                CorrectGamma(imgSrc, imgDst0_5, 0.5);
                CorrectGamma(imgSrc, imgDst2, 2.0);

                using (new CvWindow("src", imgSrc))
                using (new CvWindow("gamma = 0.25", imgDst0_25))
                using (new CvWindow("gamma = 0.5", imgDst0_5))
                using (new CvWindow("gamma = 2.0", imgDst2))                
                {
                    Cv.WaitKey(0);
                }
            }
        }

        /// <summary>
        /// Corrects gamma
        /// </summary>
        /// <param name="src"></param>
        /// <param name="dst"></param>
        /// <param name="gamma"></param>
        public void CorrectGamma(CvArr src, CvArr dst, double gamma)
        {
            byte[] lut = new byte[256];
            for (int i = 0; i < lut.Length; i++)
            {
                lut[i] = (byte)(Math.Pow(i / 255.0, 1.0 / gamma) * 255.0);
            }

            Cv.LUT(src, dst, lut);
        }
    }
}