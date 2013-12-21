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
    /// CvSparseMatの要素
    /// </summary>
#else
    /// <summary>
    /// An element of CvSparseMat
    /// </summary>
#endif
    public class CvSparseNode : CvObject
    {
        #region Initialization and Disposal
#if LANG_JP
        /// <summary>
        /// デフォルトコンストラクタ
        /// </summary>
        /// <param name="ptr">CvSparseNode*</param>
#else
        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="ptr">CvSparseNode*</param>
#endif
        public CvSparseNode(IntPtr ptr)
        {
            this._ptr = ptr;
        }
        #endregion

        #region Properties
        /// <summary>
        /// sizeof(CvSparseNode)
        /// </summary>
        public static readonly int SizeOf = Marshal.SizeOf(typeof(WCvSparseNode));


#if LANG_JP
        /// <summary>
        /// 
        /// </summary>
#else
        /// <summary>
        /// 
        /// </summary>
#endif
        public uint HashVal
		{
            get
            {
                unsafe
                {
                    return ((WCvSparseNode*)_ptr)->hashval;
                }
            }
		}
#if LANG_JP
        /// <summary>
        /// 
        /// </summary>
#else
        /// <summary>
        /// 
        /// </summary>
#endif
		public CvSparseNode Next
		{
            get
            {
                IntPtr p;
                unsafe
                {
                    p = new IntPtr(((WCvSparseNode*)_ptr)->next);
                }
                if (p == IntPtr.Zero)
                    return null;
                else
                    return new CvSparseNode(p);
            }
		}
        #endregion
    }
}
