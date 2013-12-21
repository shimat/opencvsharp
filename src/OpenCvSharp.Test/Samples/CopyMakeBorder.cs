using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OpenCvSharp.Test
{
    /// <summary>
    /// 境界線の作成
    /// </summary>
    /// <remarks>
    /// http://opencv.jp/sample/filter_and_color_conversion.html#makeborder
    /// </remarks>
    class CopyMakeBorder
    {        
        public CopyMakeBorder()
        {
            // cvCopyMakeBorder
            // 画像のコピーと境界の作成

            const int offset = 30;

            // (1)入力画像の読み込み
            using (IplImage src = Cv.LoadImage(Const.ImageLenna, LoadMode.AnyDepth | LoadMode.AnyColor))
            {
                // (2)出力画像の領域の確保
                int dstWidth = src.Width + offset * 2;
                int dstHeight = src.Height + offset * 2;
                using (IplImage dstReplicate = Cv.CreateImage(new CvSize(dstWidth, dstHeight), src.Depth, src.NChannels))
                using (IplImage dstConstant = Cv.CreateImage(new CvSize(dstWidth, dstHeight), src.Depth, src.NChannels))
                {
                    // (3)境界線の作成
                    Cv.CopyMakeBorder(src, dstReplicate, new CvPoint(offset, offset), BorderType.Replicate);
                    Cv.CopyMakeBorder(src, dstConstant, new CvPoint(offset, offset), BorderType.Constant, CvColor.Red);

                    // (4)結果を表示する
                    Cv.NamedWindow("Border Replicate", WindowMode.AutoSize);
                    Cv.NamedWindow("Border Constant", WindowMode.AutoSize);
                    Cv.ShowImage("Border Replicate", dstReplicate);
                    Cv.ShowImage("Border Constant", dstConstant);
                    Cv.WaitKey(0);
                    Cv.DestroyAllWindows();
                }
            }
        }
    }
}
