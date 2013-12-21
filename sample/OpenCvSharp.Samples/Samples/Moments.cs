using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OpenCvSharp.Test
{
    /// <summary>
    /// 画像のモーメント
    /// </summary>
    /// <remarks>http://opencv.jp/sample/moment.html</remarks>
    class Moments
    {
        public Moments()
        {
            // (1)画像を読み込む．3チャンネル画像の場合はCOIがセットされていなければならない
            using (IplImage srcImg = new IplImage(Const.ImageLenna, LoadMode.AnyColor | LoadMode.AnyDepth))
            {
                if (srcImg.NChannels == 3 && srcImg.COI == 0)
                {
                    srcImg.COI = 1;
                }
                // (2)入力画像の３次までの画像モーメントを計算する
                CvMoments moments = new CvMoments(srcImg, false);
                srcImg.COI = 0;

                // (3)モーメントやHuモーメント不変量を，得られたCvMoments構造体の値を使って計算する．
                double spatialMoment = moments.GetSpatialMoment(0, 0);
                double centralMoment = moments.GetCentralMoment(0, 0);
                double normCMoment = moments.GetNormalizedCentralMoment(0, 0);
                CvHuMoments huMoments = new CvHuMoments(moments);

                // (4)得られたモーメントやHuモーメント不変量を文字として画像に描画
                using (CvFont font = new CvFont(FontFace.HersheySimplex, 1.0, 1.0, 0, 2, LineType.Link8))
                {
                    string[] text = new string[10];
                    text[0] = string.Format("spatial={0:F3}", spatialMoment);
                    text[1] = string.Format("central={0:F3}", centralMoment);
                    text[2] = string.Format("norm={0:F3}", spatialMoment);
                    text[3] = string.Format("hu1={0:F10}", huMoments.Hu1);
                    text[4] = string.Format("hu2={0:F10}", huMoments.Hu2);
                    text[5] = string.Format("hu3={0:F10}", huMoments.Hu3);
                    text[6] = string.Format("hu4={0:F10}", huMoments.Hu4);
                    text[7] = string.Format("hu5={0:F10}", huMoments.Hu5);
                    text[8] = string.Format("hu6={0:F10}", huMoments.Hu6);
                    text[9] = string.Format("hu7={0:F10}", huMoments.Hu7);

                    CvSize textSize = font.GetTextSize(text[0]);
                    for (int i = 0; i < 10; i++)
                    {
                        srcImg.PutText(text[i], new CvPoint(10, (textSize.Height + 3) * (i + 1)), font, CvColor.Black);
                    }
                }

                // (5)入力画像とモーメント計算結果を表示，キーが押されたときに終了
                using (CvWindow window = new CvWindow("Image", WindowMode.AutoSize))
                {
                    window.ShowImage(srcImg);
                    Cv.WaitKey(0);
                }
            }

        }
    }
}
