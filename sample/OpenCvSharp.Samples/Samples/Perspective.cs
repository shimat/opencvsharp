using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OpenCvSharp.Test
{
    /// <summary>
    /// 画像の透視投影変換
    /// </summary>
    /// <remarks>http://opencv.jp/sample/sampling_and_geometricaltransforms.html#perspective</remarks>
    class Perspective
    {        
        public Perspective()
        {
            // cvGetPerspectiveTransform + cvWarpPerspective
            // 画像上の４点対応より透視投影変換行列を計算し，その行列を用いて画像全体の透視投影変換を行う．

            // (1)画像の読み込み，出力用画像領域の確保を行なう
            using (IplImage srcImg = new IplImage(Const.ImageLenna, LoadMode.AnyDepth | LoadMode.AnyColor))
            using (IplImage dstImg = srcImg.Clone())
            {
                // (2)四角形の変換前と変換後の対応する頂点をそれぞれセットし
                //    cvWarpPerspectiveを用いて透視投影変換行列を求める  
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
                    // (3)指定されたアフィン行列により，cvWarpAffineを用いて画像を回転させる
                    Cv.WarpPerspective(srcImg, dstImg, mapMatrix, Interpolation.Linear | Interpolation.FillOutliers, CvScalar.ScalarAll(100));
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
