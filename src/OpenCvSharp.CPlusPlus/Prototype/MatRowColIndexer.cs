using System;
using System.Collections.Generic;
using System.Text;

namespace OpenCvSharp.CPlusPlus.Prototype
{
    /// <summary>
    /// 
    /// </summary>
    public abstract class MatRowColIndexer
    {
        /// <summary>
        /// 
        /// </summary>
        protected readonly Mat parent;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="parent"></param>
        protected internal MatRowColIndexer(Mat parent)
        {
            this.parent = parent;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pos"></param>
        /// <returns></returns>
        public abstract MatExpr this[int pos] { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <returns></returns>
        public abstract MatExpr this[int start, int end] { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="range"></param>
        /// <returns></returns>
        public virtual MatExpr this[Range range]
        {
            get { return this[range.Start, range.End]; }

            set { this[range.Start, range.End] = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pos"></param>
        /// <returns></returns>
        public MatExpr Get(int pos)
        {
            return this[pos];
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <returns></returns>
        public MatExpr Get(int start, int end)
        {
            return this[start, end];
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="range"></param>
        /// <returns></returns>
        public MatExpr Get(Range range)
        {
            return this[range];
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pos"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public void Set(int pos, MatExpr value)
        {
            this[pos] = value;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public void Set(int start, int end, MatExpr value)
        {
            this[start, end] = value;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="range"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public void Set(Range range, MatExpr value)
        {
            this[range] = value;
        }
    }
}
