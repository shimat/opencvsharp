/*
 * (C) 2008-2013 Schima
 * This code is licenced under the LGPL.
 */

using System;
using System.Collections.Generic;
using System.Text;

namespace OpenCvSharp
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IPointerAccessor2D<T>
    {
        /// <summary>
        /// Data pointer
        /// </summary>
        IntPtr Ptr { get; }
        /// <summary>
        /// Indexer
        /// </summary>
        /// <param name="index1"></param>
        /// <param name="index2"></param>
        /// <returns></returns>
        T this[int index1, int index2] { get; set; }
        /// <summary>
        /// ptr[index]
        /// </summary>
        /// <param name="index1"></param>
        /// <param name="index2"></param>
        /// <returns></returns>
        T Get(int index1, int index2);
        /// <summary>
        /// ptr[index] = value;
        /// </summary>
        /// <param name="index1"></param>
        /// <param name="index2"></param>
        /// <param name="value"></param>
        void Set(int index1, int index2, T value);
    }

}
