using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenCvSharp;

namespace OpenCvSharp.Test
{
    /// <summary>
    /// 点列を包含する矩形 
    /// </summary>
    /// <remarks>
    /// http://opencv.jp/sample/contour_processing.html#bounding
    /// </remarks>
    class BoundingRect
    {        
        public BoundingRect()
        {
            // cvBoundingRect 
            // 点列を包含する矩形を求める

            // (1)画像とメモリストレージを確保し初期化する
            // (メモリストレージは、CvSeqを使わないのであれば不要)
            using (IplImage img = new IplImage(640, 480, BitDepth.U8, 3))
            using (CvMemStorage storage = new CvMemStorage(0))
            {
                img.Zero();
                CvRNG rng = new CvRNG(DateTime.Now);
                // (2)点列を生成する
                ///*
                // お手軽な方法 (普通の配列を使う)
                CvPoint[] points = new CvPoint[50];
                for (int i = 0; i < 50; i++)
                {
                    points[i] = new CvPoint()
                    {
                        X = (int)(rng.RandInt() % (img.Width / 2) + img.Width / 4),
                        Y = (int)(rng.RandInt() % (img.Height / 2) + img.Height / 4)
                    };
                    img.Circle(points[i], 3, new CvColor(0, 255, 0), Cv.FILLED);
                }
                //*/
                /*
                // サンプルに準拠した方法 (CvSeqを使う)
                CvSeq points = new CvSeq(SeqType.EltypePoint, CvSeq.SizeOf, CvPoint.SizeOf, storage);
                for (int i = 0; i < 50; i++) {
                    CvPoint pt = new CvPoint();
                    pt.X = (int)(rng.RandInt() % (img.Width / 2) + img.Width / 4);
                    pt.Y = (int)(rng.RandInt() % (img.Height / 2) + img.Height / 4);
                    points.Push(pt);
                    img.Circle(pt, 3, new CvColor(0, 255, 0), Cv.FILLED);
                }
                //*/
                // (3)点列を包含する矩形を求めて描画する
                CvRect rect = Cv.BoundingRect(points);
                img.Rectangle(new CvPoint(rect.X, rect.Y), new CvPoint(rect.X + rect.Width, rect.Y + rect.Height), new CvColor(255, 0, 0), 2);
                // (4)画像の表示，キーが押されたときに終了 
                using (CvWindow w = new CvWindow("BoundingRect", WindowMode.AutoSize, img))
                {
                    CvWindow.WaitKey(0);
                }
            }
        }
    }
}