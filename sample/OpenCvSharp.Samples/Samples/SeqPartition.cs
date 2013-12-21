using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using OpenCvSharp;
using OpenCvSharp.UserInterface;

namespace OpenCvSharp.Test
{
    /// <summary>
    /// Partitioning 2d point set.
    /// </summary>
    /// <remarks>http://opencv.jp/opencv-1.1.0/document/opencvref_cxcore_misc.html#decl_cvSeqPartition</remarks>
    class SeqPartition
    {
        const int Width = 500;
        const int Height = 500;
        const int Count = 1000;

        CvSeq<CvPoint> pointSeq;
        IplImage canvas;
        CvScalar[] colors;
        CvWindowEx window;
        int threshold;

        /// <summary>
        /// 
        /// </summary>
        public SeqPartition()
        {
            CvMemStorage storage = new CvMemStorage(0);
            pointSeq = new CvSeq<CvPoint>(SeqType.EltypeS32C2, CvSeq.SizeOf, storage);
            Random rand = new Random();
            canvas = new IplImage(Width, Height, BitDepth.U8, 3);

            colors = new CvScalar[Count];
            for (int i = 0; i < Count; i++)
            {
                CvPoint pt = new CvPoint
                {
                    X = rand.Next(Width),
                    Y = rand.Next(Height)
                };
                pointSeq.Push(pt);
                int icolor = rand.Next() | 0x00404040;
                colors[i] = Cv.RGB(icolor & 255, (icolor >> 8) & 255, (icolor >> 16) & 255);
            }

            using (window = new CvWindowEx() { Text = "points" })
            {
                window.CreateTrackbar("threshold", 10, 50, OnTrack);
                OnTrack(10);
                CvWindowEx.WaitKey();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pos"></param>
        private void OnTrack(int pos)
        {
            CvSeq labels;
            Stopwatch watch = Stopwatch.StartNew();
            threshold = pos * pos;
            int classCount = Cv.SeqPartition(pointSeq, null, out labels, CmpFuncPtr);
            watch.Stop();
            Console.WriteLine("{0:D4} classes", classCount);
            Console.WriteLine("Partition time : {0} msec", watch.ElapsedMilliseconds);
            Cv.Zero(canvas);

            for (int i = 0; i < labels.Total; i++)
            {
                CvPoint pt = pointSeq.GetSeqElem(i).Value;
                CvScalar color = colors[labels.GetSeqElem<int>(i).Value];
                Cv.Circle(canvas, pt, 1, color, -1);
            }

            window.ShowImage(canvas);
        }

        private unsafe int CmpFuncPtr(IntPtr _a, IntPtr _b)
        {
            CvPoint a = *(CvPoint*)_a;
            CvPoint b = *(CvPoint*)_b;
            return ((a.X - b.X) * (a.X - b.X) + (a.Y - b.Y) * (a.Y - b.Y)) <= threshold ? 1 : 0;
        }

        private int CmpFuncManaged(CvPoint a, CvPoint b)
        {
            return ((a.X - b.X) * (a.X - b.X) + (a.Y - b.Y) * (a.Y - b.Y)) <= threshold ? 1 : 0;
        }
    }

}
