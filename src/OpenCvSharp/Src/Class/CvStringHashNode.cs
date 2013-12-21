/*
 * (C) 2008-2013 Schima
 * This code is licenced under the LGPL.
 */

using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace OpenCvSharp
{
#if LANG_JP
    /// <summary>
    /// ファイルストレージに含まれる要素の全てのキー（names）を記憶するハッシュ
    /// </summary>
#else
    /// <summary>
    /// All the keys (names) of elements in the read file storage are stored in the hash to speed up the lookup operations
    /// </summary>
#endif
    public class CvStringHashNode : CvObject
    {
#if LANG_JP
        /// <summary>
        /// ポインタから初期化
        /// </summary>
        /// <param name="ptr">struct CvStringHashNode*</param>
#else
        /// <summary>
        /// Initializes from pointer
        /// </summary>
        /// <param name="ptr">struct CvStringHashNode*</param>
#endif
        public CvStringHashNode(IntPtr ptr)
        {
            this._ptr = ptr;
        }


        #region Properties
        /// <summary>
        /// sizeof(CvStringHashNode) 
        /// </summary>
        public static readonly int SizeOf = Marshal.SizeOf(typeof(WCvStringHashNode));


        /// <summary>
        /// 
        /// </summary>
        public uint HashVal
        {
            get
            {
                unsafe
                {
                    return ((WCvStringHashNode*)_ptr)->hashval;
                }
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public CvString Str
        {
            get
            {
                unsafe
                {
                    return ((WCvStringHashNode*)_ptr)->str;
                }
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public IntPtr Next
        {
            get
            {
                unsafe
                {
                    return new IntPtr(((WCvStringHashNode*)_ptr)->next);
                }
            }
        }
        #endregion
    }
}
