using System;
using System.Collections.Generic;
using System.Text;

namespace OpenCvSharp.CPlusPlus
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    interface ITypeSpecificMat<T> : IEnumerable<T> 
        where T : struct
    {
        /// <summary>
        /// Convert this mat to managed array
        /// </summary>
        /// <returns></returns>
        T[] ToArray();

        /// <summary>
        /// Convert this mat to managed rectangular array
        /// </summary>
        /// <returns></returns>
        T[,] ToRectangularArray();

        MatIndexer<T> GetIndexer();
    }
}
