using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenCvSharp;

namespace OpenCvSharp.Test
{
    /// <summary>
    /// 画像のアフィン変換
    /// </summary>
    /// <remarks>
    /// http://opencv.jp/sample/sampling_and_geometricaltransforms.html#affine_1
    /// </remarks>
    class Affine
    {
        public Affine()
        {
            // cvGetAffineTransform + cvWarpAffine
            // 画像上の３点対応よりアフィン変換行列を計算し，その行列を用いて画像全体のアフィン変換を行う．

            // (1)画像の読み込み，出力用画像領域の確保を行なう
            using (IplImage srcImg = new IplImage(Const.ImageGoryokaku, LoadMode.AnyDepth | LoadMode.AnyColor))
            using (IplImage dstImg = srcImg.Clone())
            {

                // (2)三角形の回転前と回転後の対応する頂点をそれぞれセットし  
                //    cvGetAffineTransformを用いてアフィン行列を求める  
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
                    // (3)指定されたアフィン行列により，cvWarpAffineを用いて画像を回転させる
                    Cv.WarpAffine(srcImg, dstImg, mapMatrix, Interpolation.Linear | Interpolation.FillOutliers, CvScalar.ScalarAll(0));
                    // (4)結果を表示する
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