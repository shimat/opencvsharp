using System;
using OpenCvSharp;
using SampleBase;

namespace CStyleSamplesCS
{
    /// <summary>
    /// Perspective transformation
    /// </summary>
    /// <remarks>http://opencv.jp/sample/sampling_and_geometricaltransforms.html#perspective</remarks>
    class Perspective
    {        
        public Perspective()
        {
            using (var srcImg = new IplImage(FilePath.Image.Lenna, LoadMode.AnyDepth | LoadMode.AnyColor))
            using (var dstImg = srcImg.Clone())
            {
                CvPoint2D32f[] srcPnt = new CvPoint2D32f[4];
                CvPoint2D32f[] dstPnt = new CvPoint2D32f[4];
                srcPnt[0] = new CvPoint2D32f(150.0f, 150.0f);
                srcPnt[1] = new CvPoint2D32f(150.0f, 300.0f);
                srcPnt[2] = new CvPoint2D32f(350.0f, 300.0f);
                srcPnt[3] = new CvPoint2D32f(350.0f, 150.0f);
                dstPnt[0] = new CvPoint2D32f(200.0f, 200.0f);
                dstPnt[1] = new CvPoint2D32f(150.0f, 300.0f);
                dstPnt[2] = new CvPoint2D32f(350.0f, 300.0f);
                dstPnt[3] = new CvPoint2D32f(300.0f, 200.0f);
                using (CvMat mapMatrix = Cv.GetPerspectiveTransform(srcPnt, dstPnt))
                {
                    Cv.WarpPerspective(srcImg, dstImg, mapMatrix, Interpolation.Linear | Interpolation.FillOutliers, CvScalar.ScalarAll(100));

                    using (new CvWindow("src", srcImg))
                    using (new CvWindow("dst", dstImg))
                    {
                        Cv.WaitKey(0);
                    }
                }
            }
        }
    }
}
