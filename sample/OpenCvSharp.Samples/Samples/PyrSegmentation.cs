using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OpenCvSharp.Test
{
    /// <summary>
    /// 画像ピラミッドを用いた画像の領域分割
    /// </summary>
    /// <remarks>http://opencv.jp/sample/segmentation_and_connection.html#pyrsegm</remarks>
    class PyrSegmentation
    {
        public PyrSegmentation()
        {
            // cvPyrSegmentation
            // レベルを指定して画像ピラミッドを作成し，その情報を用いて画像のセグメント化を行なう．

            const double threshold1 = 255.0;
            const double threshold2 = 50.0; 

            // (1)画像の読み込み
            using (IplImage srcImg = new IplImage(Const.ImageGoryokaku, LoadMode.AnyDepth | LoadMode.AnyColor))
            {
                // level1から4それぞれでやってみる
                IplImage[] dstImg = new IplImage[4];
                for (int level = 0; level < dstImg.Length; level++)
                {
                    // (2)領域分割のためにROIをセットする
                    CvRect roi = new CvRect()
                    {
                        X = 0,
                        Y = 0,
                        Width = srcImg.Width & -(1 << (level + 1)),
                        Height = srcImg.Height & -(1 << (level + 1))
                    };
                    srcImg.ROI = roi;
                    // (3)分割結果画像出力用の画像領域を確保し，領域分割を実行
                    dstImg[level] = srcImg.Clone();
                    Cv.PyrSegmentation(srcImg, dstImg[level], level + 1, threshold1, threshold2);
                }

                // (4)入力画像と分割結果画像の表示
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
