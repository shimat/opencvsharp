using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OpenCvSharp.Test
{
    /// <summary>
    /// Watershedアルゴリズムによる画像の領域分割
    /// </summary>
    /// <remarks>http://opencv.jp/sample/segmentation_and_connection.html#watershed</remarks>
    class Watershed
    {
        public Watershed()
        {
            // cvWatershed
            // マウスで円形のマーカー（シード領域）の中心を指定し，複数のマーカーを設定する．
            // このマーカを画像のgradientに沿って広げて行き，gradientの高い部分に出来る境界を元に領域を分割する．
            // 領域は，最初に指定したマーカーの数に分割される． 

            // (2)画像の読み込み，マーカー画像の初期化，結果表示用画像領域の確保を行なう
            using (IplImage srcImg = new IplImage(Const.ImageGoryokaku, LoadMode.AnyDepth | LoadMode.AnyColor))
            using (IplImage dstImg = srcImg.Clone())
            using (IplImage dspImg = srcImg.Clone())
            using (IplImage markers = new IplImage(srcImg.Size, BitDepth.S32, 1))
            {
                markers.Zero();

                // (3)入力画像を表示しシードコンポーネント指定のためのマウスイベントを登録する
                using (CvWindow wImage = new CvWindow("image", WindowMode.AutoSize))
                {
                    wImage.Image = srcImg;
                    // クリックにより中心を指定し，円形のシード領域を設定する   
                    int seedNum = 0;
                    wImage.OnMouseCallback += delegate(MouseEvent ev, int x, int y, MouseEvent flags)
                    {
                        if (ev == MouseEvent.LButtonDown)
                        {
                            seedNum++;
                            CvPoint pt = new CvPoint(x, y);
                            markers.Circle(pt, 20, CvScalar.ScalarAll(seedNum), Cv.FILLED, LineType.Link8, 0);
                            dspImg.Circle(pt, 20, CvColor.White, 3, LineType.Link8, 0);
                            wImage.Image = dspImg;
                        }
                    };
                    CvWindow.WaitKey();
                }

                // (4)watershed分割を実行する  
                Cv.Watershed(srcImg, markers);

                // (5)実行結果の画像中のwatershed境界（ピクセル値=-1）を結果表示用画像上に表示する
                for (int i = 0; i < markers.Height; i++)
                {
                    for (int j = 0; j < markers.Width; j++)
                    {
                        int idx = (int)(markers.Get2D(i, j).Val0);
                        if (idx == -1)
                        {
                            dstImg.Set2D(i, j, CvColor.Red);
                        }
                    }
                }
                using (CvWindow wDst = new CvWindow("watershed transform", WindowMode.AutoSize))
                {
                    wDst.Image = dstImg;
                    CvWindow.WaitKey();
                }
            }

        }
    }
}
