using System;
using OpenCvSharp;
using SampleBase;

namespace CStyleSamplesCS
{
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>http://opencv.jp/sample/segmentation_and_connection.html#pyrsegm</remarks>
    class PyrSegmentation
    {
        public PyrSegmentation()
        {
            const double threshold1 = 255.0;
            const double threshold2 = 50.0; 

            using (IplImage srcImg = new IplImage(FilePath.Image.Goryokaku, LoadMode.AnyDepth | LoadMode.AnyColor))
            {
                IplImage[] dstImg = new IplImage[4];
                for (int level = 0; level < dstImg.Length; level++)
                {
                    CvRect roi = new CvRect()
                    {
                        X = 0,
                        Y = 0,
                        Width = srcImg.Width & -(1 << (level + 1)),
                        Height = srcImg.Height & -(1 << (level + 1))
                    };
                    srcImg.ROI = roi;

                    dstImg[level] = srcImg.Clone();
                    Cv.PyrSegmentation(srcImg, dstImg[level], level + 1, threshold1, threshold2);
                }

                CvWindow wSrc = new CvWindow("src", srcImg);
                CvWindow[] wDst = new CvWindow[dstImg.Length];
                for (int i = 0; i < dstImg.Length; i++)
                {
                    wDst[i] = new CvWindow("dst" + i, dstImg[i]);
                }
                CvWindow.WaitKey();
                CvWindow.DestroyAllWindows();

                foreach (IplImage item in dstImg)
                {
                    item.Dispose();
                }
            }
        }
    }
}
