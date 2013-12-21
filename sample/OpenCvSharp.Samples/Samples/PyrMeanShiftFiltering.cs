using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OpenCvSharp.Test
{
    /// <summary>
    /// 平均値シフト法による画像のセグメント化
    /// </summary>
    /// <remarks>http://opencv.jp/sample/segmentation_and_connection.html#meanshiftsegm</remarks>
    class PyrMeanShiftFiltering
    {
        public PyrMeanShiftFiltering()
        {
            // cvPyrMeanShiftFiltering
            // 平均値シフト法による画像のセグメント化を行う

            const int level = 2;

            // (1)画像の読み込み
            using (IplImage srcImg = new IplImage(Const.ImageGoryokaku, LoadMode.AnyDepth | LoadMode.AnyColor))
            {
                if (srcImg.NChannels != 3)
                {
                    throw new Exception();
                }
                if (srcImg.Depth != BitDepth.U8)
                {
                    throw new Exception();
                }

                // (2)領域分割のためにROIをセットする
                CvRect roi = new CvRect
                {
                    X = 0,
                    Y = 0,
                    Width = srcImg.Width & -(1 << level),
                    Height = srcImg.Height & -(1 << level)
                };
                srcImg.ROI = roi;

                // (3)分割結果画像出力用の画像領域を確保し，領域分割を実行
                using (IplImage dstImg = srcImg.Clone())
                {
                    Cv.PyrMeanShiftFiltering(srcImg, dstImg, 30.0, 30.0, level, new CvTermCriteria(5, 1));
                    // (4)入力画像と分割結果画像の表示
                    using (CvWindow wSrc = new CvWindow("Source", srcImg))
                    using (CvWindow wDst = new CvWindow("MeanShift", dstImg))
                    {
                        CvWindow.WaitKey();
                    }
                }
            }

        }
    }
}
