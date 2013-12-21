using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OpenCvSharp.Test
{
    /// <summary>
    /// 画像ピラミッドの作成
    /// </summary>
    /// <remarks>http://opencv.jp/sample/pyramid.html#pyramid</remarks>
    class PyrDownUp
    {
        public PyrDownUp()
        {
            using(IplImage srcImg = new IplImage (Const.ImageLenna, LoadMode.AnyDepth | LoadMode.AnyColor))
            using(IplImage dstImg1 = new IplImage (srcImg.Width / 2, srcImg.Height / 2, srcImg.Depth, srcImg.NChannels))
            using(IplImage dstImg2 = new IplImage (srcImg.Width * 2, srcImg.Height * 2, srcImg.Depth, srcImg.NChannels))
            {
                // (1)入力画像に対する画像ピラミッドを構成
                Cv.PyrDown (srcImg, dstImg1, CvFilter.Gaussian5x5);
                Cv.PyrUp(srcImg, dstImg2, CvFilter.Gaussian5x5);

                // (2)表示
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
