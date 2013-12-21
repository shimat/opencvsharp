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
    public interface IPointerAccessor1D<T>
    {
        /// <summary>
        /// Data pointer
        /// </summary>
        IntPtr Ptr { get; }
        /// <summary>
        /// Indexer
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        T this[int index] { get; set; }
        /// <summary>
        /// ptr[index]
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        T Get(int index);
        /// <summary>
        /// ptr[index] = value;
        /// </summary>
        /// <param name="index"></param>
        /// <param name="value"></param>
        void Set(int index, T value);
    }
}

