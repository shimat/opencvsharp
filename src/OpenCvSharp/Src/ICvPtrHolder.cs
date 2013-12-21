/*
 * (C) 2008-2013 Schima
 * This code is licenced under the LGPL.
 */

using System;
using System.Collections.Generic;
using System.Text;

namespace OpenCvSharp
{
#if LANG_JP
    /// <summary>
    /// OpenCVのネイティブデータポインタを持つことを示すインターフェイス
    /// </summary>
#else
    /// <summary>
    /// Represents a OpenCV-based class which have a native pointer. 
    /// </summary>
#endif
    public interface ICvPtrHolder
    {
        /// <summary>
        /// Unmanaged OpenCV data pointer
        /// </summary>
        IntPtr CvPtr { get; }

    }
}
