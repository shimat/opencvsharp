using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenCvSharp;
using SampleBase;

namespace CStyleSamplesCS
{
    /// <summary>
    /// Affine transform
    /// </summary>
    /// <remarks>
    /// http://opencv.jp/sample/sampling_and_geometricaltransforms.html#affine_1
    /// </remarks>
    class Affine
    {
        public Affine()
        {
            // cvGetAffineTransform + cvWarpAffine

            using (IplImage srcImg = new IplImage(FilePath.Image.Goryokaku, LoadMode.AnyDepth | LoadMode.AnyColor))
            using (IplImage dstImg = srcImg.Clone())
            {
                CvPoint2D32f[] srcPnt = new CvPoint2D32f[3];
                CvPoint2D32f[] dstPnt = new CvPoint2D32f[3];
                srcPnt[0] = new CvPoint2D32f(200.0f, 200.0f);
                srcPnt[1] = new CvPoint2D32f(250.0f, 200.0f);
                srcPnt[2] = new CvPoint2D32f(200.0f, 100.0f);
                dstPnt[0] = new CvPoint2D32f(300.0f, 100.0f);
                dstPnt[1] = new CvPoint2D32f(300.0f, 50.0f);
                dstPnt[2] = new CvPoint2D32f(200.0f, 100.0f);
                using (CvMat mapMatrix = Cv.GetAffineTransform(srcPnt, dstPnt))
                {
                    Cv.WarpAffine(srcImg, dstImg, mapMatrix, Interpolation.Linear | Interpolation.FillOutliers, CvScalar.ScalarAll(0));

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