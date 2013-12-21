using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OpenCvSharp.Test
{
    /// <summary>
    /// モルフォロジー変換
    /// </summary>
    /// <remarks>http://opencv.jp/sample/morphology.html#morphology</remarks>
    class Morphology
    {
        public Morphology()
        {
            // cvMorphologyEx
            // 構造要素を指定して，様々なモルフォロジー演算を行なう

            //(1)画像の読み込み，演算結果画像領域の確保を行なう
            using (IplImage srcImg = new IplImage(Const.ImageLenna, LoadMode.AnyDepth | LoadMode.AnyColor))
            using (IplImage dstImgDilate = srcImg.Clone())
            using (IplImage dstImgErode = srcImg.Clone())
            using (IplImage dstImgOpening = srcImg.Clone())
            using (IplImage dstImgClosing = srcImg.Clone())
            using (IplImage dstImgGradient = srcImg.Clone())
            using (IplImage dstImgTophat = srcImg.Clone())
            using (IplImage dstImgBlackhat = srcImg.Clone())
            using (IplImage tmpImg = srcImg.Clone())
            {
                //(2)構造要素を生成する 
                IplConvKernel element = Cv.CreateStructuringElementEx(9, 9, 4, 4, ElementShape.Rect, null);
                //(3)各種のモルフォロジー演算を実行する 
                Cv.Dilate(srcImg, dstImgDilate, element, 1);
                Cv.Erode(srcImg, dstImgErode, element, 1);
                Cv.MorphologyEx(srcImg, dstImgOpening, tmpImg, element, MorphologyOperation.Open, 1);
                Cv.MorphologyEx(srcImg, dstImgClosing, tmpImg, element, MorphologyOperation.Close, 1);
                Cv.MorphologyEx(srcImg, dstImgGradient, tmpImg, element, MorphologyOperation.Gradient, 1);
                Cv.MorphologyEx(srcImg, dstImgTophat, tmpImg, element, MorphologyOperation.TopHat, 1);
                Cv.MorphologyEx(srcImg, dstImgBlackhat, tmpImg, element, MorphologyOperation.BlackHat, 1);

                //(4)モルフォロジー演算結果を表示する 
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
