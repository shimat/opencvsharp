/*
 * (C) 2008-2013 Schima
 * This code is licenced under the LGPL.
 */

using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using OpenCvSharp.Utilities;

namespace OpenCvSharp
{
#if LANG_JP
    /// <summary>
    /// CvBGCodeBookElem
    /// </summary>
#else
    /// <summary>
    /// CvBGCodeBookElem
    /// </summary>
#endif
    public class CvBGCodeBookElem : CvObject
    {
        #region Init and Disposal
#if LANG_JP
        /// <summary>
        /// ポインタから初期化
        /// </summary>
        /// <param name="ptr">WCvBGCodeBookElem*</param>
#else
        /// <summary>
        /// Initialize from pointer
        /// </summary>
        /// <param name="ptr">CvBGCodeBookElem*</param>
#endif
        public CvBGCodeBookElem(IntPtr ptr)
        {
            if (ptr == IntPtr.Zero)
            {
                throw new ArgumentNullException("ptr");
            }
            this._ptr = ptr;
        }
        #endregion

        #region Properties
        /// <summary>
        /// sizeof(CvBGCodeBookElem) 
        /// </summary>
        public static readonly int SizeOf = Marshal.SizeOf(typeof(WCvBGCodeBookElem));

#if LANG_JP
        /// <summary>
        /// 
        /// </summary>
#else
        /// <summary>
        /// 
        /// </summary>
#endif
        public CvBGCodeBookElem Next
        {
            get
            {
                unsafe
                {
                    WCvBGCodeBookElem* p = ((WCvBGCodeBookElem*)_ptr)->next;
                    if (p == null)
                        return null;
                    else
                        return new CvBGCodeBookElem(new IntPtr(p));
                }
            }
            set
            {
                unsafe
                {
                    WCvBGCodeBookElem* p = (value == null) ? null : (WCvBGCodeBookElem*)value.CvPtr;
                    ((WCvBGCodeBookElem*)_ptr)->next = p;
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
        public int TLastUpdate
        {
            get
            {
                unsafe
                {
                    return ((WCvBGCodeBookElem*)_ptr)->tLastUpdate;
                }
            }
            set
            {
                unsafe
                {
                    ((WCvBGCodeBookElem*)_ptr)->tLastUpdate = value;
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
        public int Stale
        {
            get
            {
                unsafe
                {
                    return ((WCvBGCodeBookElem*)_ptr)->stale;
                }
            }
            set
            {
                unsafe
                {
                    ((WCvBGCodeBookElem*)_ptr)->stale = value;
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
        public byte[] BoxMin
        {
            get
            {
                unsafe
                {
                    byte* p = ((WCvBGCodeBookElem*)_ptr)->boxMin;
                    return new byte[] { p[0], p[1], p[2] };
                }
            }
            set
            {
                if (value == null)
                    throw new ArgumentNullException();
                if (value.Length != 3)
                    throw new ArgumentException();

                unsafe
                {
                    byte* p = ((WCvBGCodeBookElem*)_ptr)->boxMin;
                    p[0] = value[0];
                    p[1] = value[1];
                    p[2] = value[2];
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
        public byte[] BoxMax
        {
            get
            {
                unsafe
                {
                    byte* p = ((WCvBGCodeBookElem*)_ptr)->boxMax;
                    return new byte[] { p[0], p[1], p[2] };
                }
            }
            set
            {
                if (value == null)
                    throw new ArgumentNullException();
                if (value.Length != 3)
                    throw new ArgumentException();

                unsafe
                {
                    byte* p = ((WCvBGCodeBookElem*)_ptr)->boxMax;
                    p[0] = value[0];
                    p[1] = value[1];
                    p[2] = value[2];
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
        public byte[] LearnMin
        {
            get
            {
                unsafe
                {
                    byte* p = ((WCvBGCodeBookElem*)_ptr)->learnMin;
                    return new byte[] { p[0], p[1], p[2] };
                }
            }
            set
            {
                if (value == null)
                    throw new ArgumentNullException();
                if (value.Length != 3)
                    throw new ArgumentException();

                unsafe
                {
                    byte* p = ((WCvBGCodeBookElem*)_ptr)->learnMin;
                    p[0] = value[0];
                    p[1] = value[1];
                    p[2] = value[2];
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
        public byte[] LearnMax
        {
            get
            {
                unsafe
                {
                    byte* p = ((WCvBGCodeBookElem*)_ptr)->learnMax;
                    return new byte[] { p[0], p[1], p[2] };
                }
            }
            set
            {
                if (value == null)
                    throw new ArgumentNullException();
                if (value.Length != 3)
                    throw new ArgumentException();

                unsafe
                {
                    byte* p = ((WCvBGCodeBookElem*)_ptr)->learnMax;
                    p[0] = value[0];
                    p[1] = value[1];
                    p[2] = value[2];
                }
            }
        }
        #endregion
    }
}