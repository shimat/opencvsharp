using System;
using System.Collections.Generic;
using System.Text;

namespace OpenCvSharp
{
    /// <summary>
    /// 
    /// </summary>
    public abstract class MatExprRangeIndexer
    {
        /// <summary>
        /// 
        /// </summary>
        protected readonly Mat parent;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="parent"></param>
        protected internal MatExprRangeIndexer(Mat parent)
        {
            this.parent = parent;
        }

        /// <summary>
        /// Creates a matrix header for the specified matrix row/column.
        /// </summary>
        /// <param name="rowStart"></param>
        /// <param name="rowEnd"></param>
        /// <param name="colStart"></param>
        /// <param name="colEnd"></param>
        /// <returns></returns>
        public abstract MatExpr this[int rowStart, int rowEnd, int colStart, int colEnd] { get; set; }

        /// <summary>
        /// Creates a matrix header for the specified row/column span.
        /// </summary>
        /// <param name="rowRange"></param>
        /// <param name="colRange"></param>
        /// <returns></returns>
        public abstract MatExpr this[Range rowRange, Range colRange] { get; set; }

        /// <summary>
        /// Creates a matrix header for the specified row/column span.
        /// </summary>
        /// <param name="roi"></param>
        /// <returns></returns>
        public virtual MatExpr this[Rect roi]
        {
            get { return this[roi.Top, roi.Bottom, roi.Left, roi.Right]; }
            set { this[roi.Top, roi.Bottom, roi.Left, roi.Right] = value; }
        }

        /// <summary>
        /// Extracts a rectangular submatrix.
        /// </summary>
        /// <param name="ranges">Array of selected ranges along each array dimension.</param>
        /// <returns></returns>
        public abstract MatExpr this[params Range[] ranges] { get; set; }

        /// <summary>
        /// Creates a matrix header for the specified matrix row/column.
        /// </summary>
        /// <param name="rowStart"></param>
        /// <param name="rowEnd"></param>
        /// <param name="colStart"></param>
        /// <param name="colEnd"></param>
        /// <returns></returns>
        public MatExpr Get(int rowStart, int rowEnd, int colStart, int colEnd)
        {
            return this[rowStart, rowEnd, colStart, colEnd];
        }
        /// <summary>
        /// Creates a matrix header for the specified row/column span.
        /// </summary>
        /// <param name="rowRange"></param>
        /// <param name="colRange"></param>
        /// <returns></returns>
        public MatExpr Get(Range rowRange, Range colRange)
        {
            return this[rowRange, colRange];
        }
        /// <summary>
        /// Creates a matrix header for the specified row/column span.
        /// </summary>
        /// <param name="roi"></param>
        /// <returns></returns>
        public MatExpr Get(Rect roi)
        {
            return this[roi];
        }

        /// <summary>
        /// Sets a matrix header for the specified matrix row/column.
        /// </summary>
        /// <param name="rowStart"></param>
        /// <param name="rowEnd"></param>
        /// <param name="colEnd"></param>
        /// <param name="colStart"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public void Set(int rowStart, int rowEnd, int colStart, int colEnd, MatExpr value)
        {
            this[rowStart, rowEnd, colStart, colEnd] = value;
        }

        /// <summary>
        /// Sets a matrix header for the specified matrix row/column span.
        /// </summary>
        /// <param name="rowRange"></param>
        /// <param name="colRange"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public void Set(Range rowRange, Range colRange, MatExpr value)
        {
            this[rowRange, colRange] = value;
        }
        /// <summary>
        /// Sets a matrix header for the specified matrix row/column span.
        /// </summary>
        /// <param name="roi"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public void Set(Rect roi, MatExpr value)
        {
            this[roi] = value;
        }
    }
}
