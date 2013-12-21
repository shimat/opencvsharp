using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OpenCvSharp.Test
{
    /// <summary>
    /// 距離変換とその可視化
    /// </summary>
    /// <remarks>
    /// http://opencv.jp/sample/special_transforms.html#disttrans
    /// </remarks>
    class DistTransform
    {        
        public DistTransform()
        {
            // cvDistTransform
            // 入力画像に対して距離変換を行ない，結果を0-255に正規化し可視化する

            // (1)画像を読み込み
            using (IplImage src = new IplImage(Const.ImageLenna, LoadMode.GrayScale))
            {
                if (src.Depth != BitDepth.U8)
                {
                    throw new Exception("Invalid Depth");
                }
                // (2)処理結果の距離画像出力用の画像領域と表示ウィンドウを確保
                using (IplImage dst = new IplImage(src.Size, BitDepth.F32, 1))
                using (IplImage dstNorm = new IplImage(src.Size, BitDepth.U8, 1))
                {
                    // (3)距離画像を計算し，表示用に結果を0-255に正規化する
                    Cv.DistTransform(src, dst, DistanceType.L2, 3, null, null);
                    Cv.Normalize(dst, dstNorm, 0.0, 255.0, NormType.MinMax, null);

                    // (4)距離画像を表示，キーが押されたときに終了
                    using (new CvWindow("Source", WindowMode.AutoSize, src)) 
                    using (new CvWindow("Distance Image", WindowMode.AutoSize, dstNorm))
                    {
                        CvWindow.WaitKey(0);
                    }
                }
            }

        }
    }
}
