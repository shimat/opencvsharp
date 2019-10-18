﻿using System;

namespace OpenCvSharp.Blob
{
    /// <summary>
    /// Label values for each pixel
    /// </summary>
    public class LabelData 
    {
        private readonly Size size;
        private readonly int[,] values;

        /// <summary>
        /// Label value
        /// </summary>
        public int[,] Values => values;

        /// <summary>
        /// Image sizw
        /// </summary>
        public Size Size => size;

        /// <summary>
        /// Row length
        /// </summary>
        public int Rows => Values.GetLength(0);

        /// <summary>
        /// Column Length
        /// </summary>
        public int Cols => Values.GetLength(1);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="rows"></param>
        /// <param name="cols"></param>
        public LabelData(int rows, int cols)
        {
            values = new int[rows, cols];
            size = new Size(cols, rows);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="values"></param>
        public LabelData(int[,] values)
        {
            if (values == null) 
                throw new ArgumentNullException(nameof(values));
            this.values = (int[,]) values.Clone();
            size.Height = values.GetLength(0);
            size.Width = values.GetLength(1);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="values"></param>
        /// <param name="roi"></param>
        public LabelData(int[,] values, Rect roi)
        {
            if (values == null)
                throw new ArgumentNullException(nameof(values));
            this.values = (int[,]) values.Clone();
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
            get => Values[row, col];
            set => Values[row, col] = value;
        }

        /// <summary>
        /// 
        /// </summary>
        public void DebugShow()
        {
            using (Mat img = Mat.Zeros(Rows, Cols, MatType.CV_8UC1))
            {
                var indexer = img.GetGenericIndexer<byte>();
                for (int r = 0; r < Rows; r++)
                {
                    for (int c = 0; c < Cols; c++)
                    {
                        if (Values[r, c] != 0)
                            indexer[r, c] = 255;
                    }
                }
                Window.ShowImages(img);
            }
        }

        /// <summary>
        /// Returns deep copied instance of this
        /// </summary>
        /// <returns></returns>
        public LabelData Clone()
        {
            return new LabelData((int[,]) Values.Clone());
        }
    }
}
