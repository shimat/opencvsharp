using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenCvSharp;
using SampleBase;

namespace CStyleSamplesCS
{
    /// <summary>
    /// Image pyramid
    /// </summary>
    /// <remarks>http://opencv.jp/sample/pyramid.html#pyramid</remarks>
    class PyrDownUp
    {
        public PyrDownUp()
        {
            using (var srcImg = new IplImage(FilePath.Image.Lenna, LoadMode.AnyDepth | LoadMode.AnyColor))
            using (var dstImg1 = new IplImage (srcImg.Width / 2, srcImg.Height / 2, srcImg.Depth, srcImg.NChannels))
            using (var dstImg2 = new IplImage (srcImg.Width * 2, srcImg.Height * 2, srcImg.Depth, srcImg.NChannels))
            {
                Cv.PyrDown (srcImg, dstImg1, CvFilter.Gaussian5x5);
                Cv.PyrUp(srcImg, dstImg2, CvFilter.Gaussian5x5);

                using (new CvWindow("Original", srcImg)) 
                using (new CvWindow("PyrDown", dstImg1)) 
                using (new CvWindow("PyrUp", dstImg2))
                {
                    Cv.WaitKey(0);
                }
            }
        }
    }
}
