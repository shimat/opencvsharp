using System;

namespace OpenCvSharp.Blob
{
    /// <summary>
    /// Label values for each pixel
    /// </summary>
    public class LabelData : ICloneable
    {
        private CvRect roi;
        private int[,] values;

        /// <summary>
        /// Label value
        /// </summary>
        public int[,] Values
        {
            get { return values; }
            set { values = value; }
        }
        /// <summary>
        /// Region of interest
        /// </summary>
        public CvRect Roi
        {
            get { return roi; }
            set { roi = value; }
        }
        /// <summary>
        /// Row length
        /// </summary>
        public int Rows { get { return Values.GetLength(0); } }
        /// <summary>
        /// Column Length
        /// </summary>
        public int Cols { get { return Values.GetLength(1); } }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="rows"></param>
        /// <param name="cols"></param>
        public LabelData(int rows, int cols)
        {
            Values = new int[rows, cols];
            Roi = new CvRect();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="rows"></param>
        /// <param name="cols"></param>
        /// <param name="roi"></param>
        public LabelData(int rows, int cols, CvRect roi)
        {
            Values = new int[rows, cols];
            Roi = roi;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="values"></param>
        public LabelData(int[,] values)
        {
            Values = (int[,])values.Clone();
            Roi = new CvRect();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="values"></param>
        /// <param name="roi"></param>
        public LabelData(int[,] values, CvRect roi)
        {
            Values = (int[,])values.Clone();
            Roi = roi;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="row"></param>
        /// <param name="col"></param>
        /// <returns></returns>
        public int RawGetLabel(int row, int col)
        {
            return Values[row, col];
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="row"></param>
        /// <param name="col"></param>
        /// <param name="value"></param>
        public void RawSetLabel(int row, int col, int value)
        {
            Values[row, col] = value;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="row"></param>
        /// <param name="col"></param>
        /// <returns></returns>
        public int this[int row, int col]
        {
            get { return Values[row + roi.Y, col + roi.X]; }
            set { Values[row + roi.Y, col + roi.X] = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public void DebugShow()
        {
            using (IplImage img = new IplImage(Cols, Rows, BitDepth.U8, 1))
            {
                img.Zero();
                for (int r = 0; r < Rows; r++)
                {
                    for (int c = 0; c < Cols; c++)
                    {
                        if (Values[r, c] != 0)
                            img[r, c] = 255;
                    }
                }
                CvWindow.ShowImages(img);
            }
        }

        /// <summary>
        /// Returns deep copied instance of this
        /// </summary>
        /// <returns></returns>
        public LabelData Clone()
        {
            return new LabelData((int[,])Values.Clone(), roi);
        }

        object ICloneable.Clone()
        {
            return Clone();
        }
    }
}
