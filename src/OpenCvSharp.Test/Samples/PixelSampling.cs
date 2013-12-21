using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OpenCvSharp.Test
{
    /// <summary>
    /// ピクセルサンプリング
    /// </summary>
    /// <remarks>http://opencv.jp/sample/sampling_and_geometricaltransforms.html#getrectsubpix</remarks>
    class PixelSampling
    {        
        public PixelSampling()
        {
            // 並進移動のためのピクセルサンプリング cvGetRectSubPix

            // (1) 画像の読み込み，出力用画像領域の確保を行なう 
            using (IplImage srcImg = new IplImage(Const.ImageLenna, LoadMode.AnyDepth | LoadMode.AnyColor))
            using (IplImage dstImg = srcImg.Clone())
            {
                // (2)dst_imgの画像中心になるsrc_img中の位置centerを指定する
                CvPoint2D32f center = new CvPoint2D32f
                {
                    X = srcImg.Width - 1,
                    Y = srcImg.Height - 1
                };
                // (3)centerが画像中心になるように，GetRectSubPixを用いて画像全体をシフトさせる
                Cv.GetRectSubPix(srcImg, dstImg, center);
                // (4)結果を表示する
                using (CvWindow wSrc = new CvWindow("src"))
                using (CvWindow wDst = new CvWindow("dst"))
                {
                    wSrc.Image = srcImg;
                    wDst.Image = dstImg;
                    Cv.WaitKey(0);
                }
            }


            // 回転移動のためのピクセルサンプリング cvGetQuadrangleSubPix

            const int angle = 45;
            // (1)画像の読み込み，出力用画像領域の確保を行なう
            using (IplImage srcImg = new IplImage(Const.ImageLenna, LoadMode.AnyDepth | LoadMode.AnyColor))
            using (IplImage dstImg = srcImg.Clone())
            {
                // (2)回転のための行列（アフィン行列）要素を設定し，CvMat行列Mを初期化する
                float[] m = new float[6];
                m[0] = (float)(Math.Cos(angle * Cv.PI / 180.0));
                m[1] = (float)(-Math.Sin(angle * Cv.PI / 180.0));
                m[2] = srcImg.Width * 0.5f;
                m[3] = -m[1];
                m[4] = m[0];
                m[5] = srcImg.Height * 0.5f;
                using (CvMat mat = new CvMat(2, 3, MatrixType.F32C1, m))
                {
                    // (3)指定された回転行列により，GetQuadrangleSubPixを用いて画像全体を回転させる
                    Cv.GetQuadrangleSubPix(srcImg, dstImg, mat);
                    // (4)結果を表示する
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
