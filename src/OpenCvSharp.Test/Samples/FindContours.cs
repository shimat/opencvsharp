using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OpenCvSharp.Test
{
    /// <summary>
    /// 輪郭の検出と描画
    /// </summary>
    class FindContours
    {        
        public FindContours()
        {
            // cvFindContoursm cvDrawContours
            // 画像中から輪郭を検出し，-1~+1までのレベルにある輪郭を描画する

            const int SIZE = 500;

            using (IplImage img = new IplImage(SIZE, SIZE, BitDepth.U8, 1))
            {
                // 画像の初期化
                img.Zero();
                for (int i = 0; i < 6; i++)
                {
                    int dx = (i % 2) * 250 - 30;
                    int dy = (i / 2) * 150;
                    if (i == 0)
                    {
                        for (int j = 0; j <= 10; j++)
                        {
                            double angle = (j + 5) * Cv.PI / 21;
                            CvPoint p1 = new CvPoint(Cv.Round(dx + 100 + j * 10 - 80 * Math.Cos(angle)), Cv.Round(dy + 100 - 90 * Math.Sin(angle)));
                            CvPoint p2 = new CvPoint(Cv.Round(dx + 100 + j * 10 - 30 * Math.Cos(angle)), Cv.Round(dy + 100 - 30 * Math.Sin(angle)));
                            Cv.Line(img, p1, p2, CvColor.White, 1, LineType.AntiAlias, 0);
                        }
                    }
                    Cv.Ellipse(img, new CvPoint(dx + 150, dy + 100), new CvSize(100, 70), 0, 0, 360, CvColor.White, -1, LineType.AntiAlias, 0);
                    Cv.Ellipse(img, new CvPoint(dx + 115, dy + 70), new CvSize(30, 20), 0, 0, 360, CvColor.Black, -1, LineType.AntiAlias, 0);
                    Cv.Ellipse(img, new CvPoint(dx + 185, dy + 70), new CvSize(30, 20), 0, 0, 360, CvColor.Black, -1, LineType.AntiAlias, 0);
                    Cv.Ellipse(img, new CvPoint(dx + 115, dy + 70), new CvSize(15, 15), 0, 0, 360, CvColor.White, -1, LineType.AntiAlias, 0);
                    Cv.Ellipse(img, new CvPoint(dx + 185, dy + 70), new CvSize(15, 15), 0, 0, 360, CvColor.White, -1, LineType.AntiAlias, 0);
                    Cv.Ellipse(img, new CvPoint(dx + 115, dy + 70), new CvSize(5, 5), 0, 0, 360, CvColor.Black, -1, LineType.AntiAlias, 0);
                    Cv.Ellipse(img, new CvPoint(dx + 185, dy + 70), new CvSize(5, 5), 0, 0, 360, CvColor.Black, -1, LineType.AntiAlias, 0);
                    Cv.Ellipse(img, new CvPoint(dx + 150, dy + 100), new CvSize(10, 5), 0, 0, 360, CvColor.Black, -1, LineType.AntiAlias, 0);
                    Cv.Ellipse(img, new CvPoint(dx + 150, dy + 150), new CvSize(40, 10), 0, 0, 360, CvColor.Black, -1, LineType.AntiAlias, 0);
                    Cv.Ellipse(img, new CvPoint(dx + 27, dy + 100), new CvSize(20, 35), 0, 0, 360, CvColor.White, -1, LineType.AntiAlias, 0);
                    Cv.Ellipse(img, new CvPoint(dx + 273, dy + 100), new CvSize(20, 35), 0, 0, 360, CvColor.White, -1, LineType.AntiAlias, 0);
                }

                // 輪郭の検出
                CvSeq<CvPoint> contours;
                CvMemStorage storage = new CvMemStorage();
                // native style
                Cv.FindContours(img, storage, out contours, CvContour.SizeOf, ContourRetrieval.Tree, ContourChain.ApproxSimple);
                contours = Cv.ApproxPoly(contours, CvContour.SizeOf, storage, ApproxPolyMethod.DP, 3, true);
                
                // wrapper style
                //img.FindContours(storage, out contours, ContourRetrieval.Tree, ContourChain.ApproxSimple);
                //contours = contours.ApproxPoly(storage, ApproxPolyMethod.DP, 3, true);

                // ウィンドウに表示
                using (CvWindow window_image = new CvWindow("image", img))
                using (CvWindow window_contours = new CvWindow("contours"))
                {
                    CvTrackbarCallback onTrackbar = delegate(int pos)
                    {
                        IplImage cnt_img = new IplImage(SIZE, SIZE, BitDepth.U8, 3);
                        CvSeq<CvPoint> _contours = contours;
                        int levels = pos - 3;
                        if (levels <= 0) // get to the nearest face to make it look more funny
                        {
                            //_contours = _contours.HNext.HNext.HNext;
                        }
                        cnt_img.Zero();
                        Cv.DrawContours(cnt_img, _contours, CvColor.Red, CvColor.Green, levels, 3, LineType.AntiAlias);
                        window_contours.ShowImage(cnt_img);
                        cnt_img.Dispose();
                    };
                    window_contours.CreateTrackbar("levels+3", 3, 7, onTrackbar);
                    onTrackbar(3);

                    Cv.WaitKey();
                }
            }

        }
    }
}
