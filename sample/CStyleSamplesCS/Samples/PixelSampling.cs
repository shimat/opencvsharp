using System;
using OpenCvSharp;
using SampleBase;

namespace CStyleSamplesCS
{
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>http://opencv.jp/sample/sampling_and_geometricaltransforms.html#getrectsubpix</remarks>
    class PixelSampling
    {        
        public PixelSampling()
        {
            // cvGetRectSubPix

            using (IplImage srcImg = new IplImage(FilePath.Image.Lenna, LoadMode.AnyDepth | LoadMode.AnyColor))
            using (IplImage dstImg = srcImg.Clone())
            {
                CvPoint2D32f center = new CvPoint2D32f
                {
                    X = srcImg.Width - 1,
                    Y = srcImg.Height - 1
                };

                Cv.GetRectSubPix(srcImg, dstImg, center);

                using (CvWindow wSrc = new CvWindow("src"))
                using (CvWindow wDst = new CvWindow("dst"))
                {
                    wSrc.Image = srcImg;
                    wDst.Image = dstImg;
                    Cv.WaitKey(0);
                }
            }


            // cvGetQuadrangleSubPix

            const int angle = 45;

            using (IplImage srcImg = new IplImage(FilePath.Image.Lenna, LoadMode.AnyDepth | LoadMode.AnyColor))
            using (IplImage dstImg = srcImg.Clone())
            {
                float[] m = new float[6];
                m[0] = (float)(Math.Cos(angle * Cv.PI / 180.0));
                m[1] = (float)(-Math.Sin(angle * Cv.PI / 180.0));
                m[2] = srcImg.Width * 0.5f;
                m[3] = -m[1];
                m[4] = m[0];
                m[5] = srcImg.Height * 0.5f;
                using (CvMat mat = new CvMat(2, 3, MatrixType.F32C1, m))
                {
                    Cv.GetQuadrangleSubPix(srcImg, dstImg, mat);

                    using (CvWindow wSrc = new CvWindow("src"))
                    using (CvWindow wDst = new CvWindow("dst"))
                    {
                        wSrc.Image = srcImg;
                        wDst.Image = dstImg;
                        Cv.WaitKey(0);
                    }
                }
            }
        }
    }
}
