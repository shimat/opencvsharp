using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OpenCvSharp.Test
{
    /// <summary>
    /// ユーザ定義フィルタ
    /// </summary>
    /// <remarks>
    /// http://opencv.jp/sample/filter_and_color_conversion.html#filter2d
    /// </remarks>
    class Filter2D
    {
        public Filter2D()
        {
            // cvFilter2D
            // ユーザが定義したカーネルによるフィルタリング

            // (1)画像の読み込み
            using (IplImage srcImg = new IplImage(Const.ImageFruits, LoadMode.AnyDepth | LoadMode.AnyColor))
            using (IplImage dstImg = new IplImage(srcImg.Size, srcImg.Depth, srcImg.NChannels))
            {
                // (2)カーネルの正規化と，フィルタ処理
                float[] data = {    2, 2, 2, 2, 2, 2, 2, 2, 2, 2,
                                    1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1
                };
                CvMat kernel = new CvMat(1, 21, MatrixType.F32C1, data);

                Cv.Normalize(kernel, kernel, 1.0, 0, NormType.L1);
                Cv.Filter2D(srcImg, dstImg, kernel, new CvPoint(0, 0));

                // (3)結果を表示する
                using (CvWindow window = new CvWindow("Filter2D", dstImg))
                {
                    Cv.WaitKey(0);
                }
            }

        }
    }
}
