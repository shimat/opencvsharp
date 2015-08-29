using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using OpenCvSharp;

namespace OpenCvSharp
{
    /// <summary>
    /// Proxy datatype for passing Mat's and vector&lt;&gt;'s as input parameters.
    /// Synonym for OutputArray.
    /// </summary>
    public class InputOutputArray : OutputArray
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="mat"></param>
        internal InputOutputArray(Mat mat)
            : base(mat)
        {
        }

        #region Cast
        /// <summary>
        /// 
        /// </summary>
        /// <param name="mat"></param>
        /// <returns></returns>
        public static implicit operator InputOutputArray(Mat mat)
        {
            return new InputOutputArray(mat);
        }
        #endregion
    }
}
