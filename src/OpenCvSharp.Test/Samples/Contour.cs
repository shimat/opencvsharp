using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenCvSharp;

namespace OpenCvSharp.Test
{
    /// <summary>
    /// 輪郭領域の面積と輪郭の長さ
    /// </summary>
    /// <remarks>
    /// http://opencv.jp/sample/contour_processing.html#contour_area
    /// </remarks>
    class Contour
    {        
        public Contour()
        {
            // cvContourArea, cvArcLength
            // 輪郭によって区切られた領域の面積と，輪郭の長さを求める
            
            const int SIZE = 500;

            // (1)画像を確保し初期化する
            using (CvMemStorage storage = new CvMemStorage())
            using (IplImage img = new IplImage(SIZE, SIZE, BitDepth.U8, 3))
            {
                img.Zero();
                // (2)点列を生成する 
                CvSeq<CvPoint> points = new CvSeq<CvPoint>(SeqType.PolyLine, storage);
                CvRNG rng = new CvRNG((ulong)DateTime.Now.Ticks);
                double scale = rng.RandReal() + 0.5;
                CvPoint pt0 = new CvPoint
                {
                    X = (int)(Math.Cos(0) * SIZE / 4 * scale + SIZE / 2),
                    Y = (int)(Math.Sin(0) * SIZE / 4 * scale + SIZE / 2)
                };
                img.Circle(pt0, 2, CvColor.Green);
                points.Push(pt0);
                for (int i = 1; i < 20; i++)
                {
                    scale = rng.RandReal() + 0.5;
                    CvPoint pt1 = new CvPoint
                    {
                        X = (int)(Math.Cos(i * 2 * Math.PI / 20) * SIZE / 4 * scale + SIZE / 2),
                        Y = (int)(Math.Sin(i * 2 * Math.PI / 20) * SIZE / 4 * scale + SIZE / 2)
                    };
                    img.Line(pt0, pt1, CvColor.Green, 2);
                    pt0.X = pt1.X;
                    pt0.Y = pt1.Y;
                    img.Circle(pt0, 3, CvColor.Green, Cv.FILLED);
                    points.Push(pt0);
                }
                img.Line(pt0, points.GetSeqElem(0).Value, CvColor.Green, 2);
                // (3)包含矩形，面積，長さを求める
                CvRect rect = points.BoundingRect(false);
                double area = points.ContourArea();
                double length = points.ArcLength(CvSlice.WholeSeq, 1);
                // (4)結果を画像に書き込む
                img.Rectangle(new CvPoint(rect.X, rect.Y), new CvPoint(rect.X + rect.Width, rect.Y + rect.Height), CvColor.Red, 2);
                string text_area = string.Format("Area:   wrect={0}, contour={1}", rect.Width * rect.Height, area);
                string text_length = string.Format("Length: rect={0}, contour={1}", 2 * (rect.Width + rect.Height), length);
                using (CvFont font = new CvFont(FontFace.HersheySimplex, 0.7, 0.7, 0, 1, LineType.AntiAlias))
                {
                    img.PutText(text_area, new CvPoint(10, img.Height - 30), font, CvColor.White);
                    img.PutText(text_length, new CvPoint(10, img.Height - 10), font, CvColor.White);
                }
                // (5)画像を表示，キーが押されたときに終了 
                using (CvWindow window = new CvWindow("BoundingRect", WindowMode.AutoSize))
                {
                    window.Image = img;
                    CvWindow.WaitKey(0);
                }
            }
        }
    }
}