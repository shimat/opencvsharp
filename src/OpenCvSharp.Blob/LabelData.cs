using System;
using System.Collections.Generic;
using System.Text;

namespace OpenCvSharp.Blob
{
    public class LabelData
    {
        private CvRect roi;
        private int[,] values;

        public int[,] Values
        {
            get { return values; }
            set { values = value; }
        }
        public CvRect Roi
        {
            get { return roi; }
            set { roi = value; }
        }

        public int Rows { get { return Values.GetLength(0); } }
        public int Cols { get { return Values.GetLength(1); } }

        public LabelData(int rows, int cols)
        {
            Values = new int[rows, cols];
            Roi = new CvRect();
        }
        public LabelData(int rows, int cols, CvRect roi)
        {
            Values = new int[rows, cols];
            Roi = roi;
        }
        public LabelData(int[,] values)
        {
            Values = (int[,])values.Clone();
            Roi = new CvRect();
        }
        public LabelData(int[,] values, CvRect roi)
        {
            Values = (int[,])values.Clone();
            Roi = roi;
        }

        public int RawGetLabel(int row, int col)
        {
            return Values[row, col];
        }
        public void RawSetLabel(int row, int col, int value)
        {
            Values[row, col] = value;
        }
        public int this[int row, int col]
        {
            get { return Values[row + roi.Y, col + roi.X]; }
            set { Values[row + roi.Y, col + roi.X] = value; }
        }

        public void DebugShow()
        {
            using (IplImage img = new IplImage(Cols, Rows, BitDepth.U8, 1))
            {
                img.Zero();
                for (int r = 0; r < Rows; r++)
                {
                    for (int c = 0; c < Cols; c++)
                    {
                        try
                        {
                            if (Values[r, c] != 0)
                                img[r, c] = 255;
                        }
                        catch
                        {
                            throw;
                        }
                    }
                }
                CvWindow.ShowImages("new", img);
            }
        }
    }
}
