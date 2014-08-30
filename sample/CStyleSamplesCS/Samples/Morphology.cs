using System;
using OpenCvSharp;
using SampleBase;

namespace CStyleSamplesCS
{
    /// <summary>
    /// Morphology operations
    /// </summary>
    /// <remarks>http://opencv.jp/sample/morphology.html#morphology</remarks>
    class Morphology
    {
        public Morphology()
        {
            using (IplImage srcImg = new IplImage(FilePath.Image.Lenna, LoadMode.AnyDepth | LoadMode.AnyColor))
            using (IplImage dstImgDilate = srcImg.Clone())
            using (IplImage dstImgErode = srcImg.Clone())
            using (IplImage dstImgOpening = srcImg.Clone())
            using (IplImage dstImgClosing = srcImg.Clone())
            using (IplImage dstImgGradient = srcImg.Clone())
            using (IplImage dstImgTophat = srcImg.Clone())
            using (IplImage dstImgBlackhat = srcImg.Clone())
            using (IplImage tmpImg = srcImg.Clone())
            {
                IplConvKernel element = Cv.CreateStructuringElementEx(9, 9, 4, 4, ElementShape.Rect, null);

                Cv.Dilate(srcImg, dstImgDilate, element, 1);
                Cv.Erode(srcImg, dstImgErode, element, 1);
                Cv.MorphologyEx(srcImg, dstImgOpening, tmpImg, element, MorphologyOperation.Open, 1);
                Cv.MorphologyEx(srcImg, dstImgClosing, tmpImg, element, MorphologyOperation.Close, 1);
                Cv.MorphologyEx(srcImg, dstImgGradient, tmpImg, element, MorphologyOperation.Gradient, 1);
                Cv.MorphologyEx(srcImg, dstImgTophat, tmpImg, element, MorphologyOperation.TopHat, 1);
                Cv.MorphologyEx(srcImg, dstImgBlackhat, tmpImg, element, MorphologyOperation.BlackHat, 1);

                using (new CvWindow("src", srcImg))
                using (new CvWindow("dilate", dstImgDilate))
                using (new CvWindow("erode", dstImgErode)) 
                using (new CvWindow("opening", dstImgOpening)) 
                using (new CvWindow("closing", dstImgClosing)) 
                using (new CvWindow("gradient", dstImgGradient)) 
                using (new CvWindow("tophat", dstImgTophat)) 
                using (new CvWindow("blackhat", dstImgBlackhat))
                {
                    Cv.WaitKey(0);
                }
            }
        }
    }
}
