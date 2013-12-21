using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OpenCvSharp.Test
{
    /// <summary>
    /// 画像のサイズ変更
    /// </summary>
    class Resize
    {
        public Resize()
        {
            // cvResize
            // 指定した出力画像サイズに合うように、入力画像のサイズを変更し出力する．

            // (1)画像を読み込む
            using (IplImage src = new IplImage(Const.ImageSquare5, LoadMode.AnyColor | LoadMode.AnyDepth))
            {
                // (2)出力用画像領域の確保を行なう
                CvSize size = new CvSize(src.Width * 2, src.Height * 2);
                using (IplImage dstNN = new IplImage(size, src.Depth, src.NChannels))
                using (IplImage dstCubic = new IplImage(size, src.Depth, src.NChannels))
                using (IplImage dstLinear = new IplImage(size, src.Depth, src.NChannels))
                using (IplImage dstLanczos = new IplImage(size, src.Depth, src.NChannels))                
                {
                    // (3)画像のサイズ変更を行う
                    Cv.Resize(src, dstNN, Interpolation.NearestNeighbor);
                    Cv.Resize(src, dstCubic, Interpolation.Cubic);                    
                    Cv.Resize(src, dstLinear, Interpolation.Linear);
                    Cv.Resize(src, dstLanczos, Interpolation.Lanczos4);

                    // (4)結果を表示する
                    using (new CvWindow("src", src))
                    using (new CvWindow("dst NearestNeighbor", dstNN))
                    using (new CvWindow("dst Cubic", dstCubic))
                    using (new CvWindow("dst Linear", dstLinear))
                    using (new CvWindow("dst Lanczos4", dstLanczos))                    
                    {
                        Cv.WaitKey();
                    }
                }
            }
        }
    }
}
