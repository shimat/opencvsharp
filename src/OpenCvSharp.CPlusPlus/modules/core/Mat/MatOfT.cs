using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace OpenCvSharp.CPlusPlus
{
    /// <summary>
    /// A matrix whose element is 8UC1 (cv::Mat_&lt;uchar&gt;)
    /// </summary>
    public abstract class Mat<TElem, TInherit> : Mat, IEnumerable<TElem> 
        where TElem : struct
        where TInherit : Mat, new()
    {
        #region Init

        /// <summary>
        /// 
        /// </summary>
        protected Mat()
            : base()
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="rows"></param>
        /// <param name="cols"></param>
        /// <param name="type"></param>
        protected Mat(int rows, int cols, MatType type)
            : base(rows, cols, type)
        {
        }

        /// <summary>
        /// Initializes by cv::Mat* pointer
        /// </summary>
        /// <param name="ptr"></param>
        protected Mat(IntPtr ptr)
            : base(ptr)
        {
        }

        /// <summary>
        /// Initializes by Mat object
        /// </summary>
        /// <param name="mat"></param>
        protected Mat(Mat mat)
            : base(mat.CvPtr)
        {
        }
        #endregion

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public abstract MatIndexer<TElem> GetIndexer();

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public abstract IEnumerator<TElem> GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        /// <summary>
        /// Convert this mat to managed array
        /// </summary>
        /// <returns></returns>
        public abstract TElem[] ToArray();

        /// <summary>
        /// Convert this mat to managed rectangular array
        /// </summary>
        /// <returns></returns>
        public abstract TElem[,] ToRectangularArray();

        /// <summary>
        /// Adds elements to the bottom of the matrix. (Mat::push_back)
        /// </summary>
        /// <param name="value">Added element(s)</param>
        public abstract void Add(TElem value);


        #region Mat Methods
        #region Reshape

        /// <summary>
        /// 
        /// </summary>
        /// <param name="mat"></param>
        /// <returns></returns>
        protected TInherit Wrap(Mat mat)
        {
            TInherit ret = new TInherit();
            mat.AssignTo(ret);
            return ret;
        }

        /// <summary>
        /// Changes the shape and/or the number of channels of a 2D matrix without copying the data.
        /// </summary>
        /// <param name="cn">New number of channels. If the parameter is 0, the number of channels remains the same.</param>
        /// <param name="rows">New number of rows. If the parameter is 0, the number of rows remains the same.</param>
        /// <returns></returns>
        public new TInherit Reshape(int cn, int rows = 0)
        {
            Mat result = base.Reshape(cn, rows);
            return Wrap(result);
        }

        /// <summary>
        /// Changes the shape and/or the number of channels of a 2D matrix without copying the data.
        /// </summary>
        /// <param name="cn">New number of channels. If the parameter is 0, the number of channels remains the same.</param>
        /// <param name="newDims">New number of rows. If the parameter is 0, the number of rows remains the same.</param>
        /// <returns></returns>
        public new TInherit Reshape(int cn, params int[] newDims)
        {
            Mat result = base.Reshape(cn, newDims);
            return Wrap(result);
        }

        #endregion
        #endregion
    }
}
