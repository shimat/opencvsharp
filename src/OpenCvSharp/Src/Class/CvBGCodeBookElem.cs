using System;
using System.Runtime.InteropServices;

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
            this.ptr = ptr;
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
                    WCvBGCodeBookElem* p = ((WCvBGCodeBookElem*)ptr)->next;
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
                    ((WCvBGCodeBookElem*)ptr)->next = p;
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
                    return ((WCvBGCodeBookElem*)ptr)->tLastUpdate;
                }
            }
            set
            {
                unsafe
                {
                    ((WCvBGCodeBookElem*)ptr)->tLastUpdate = value;
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
                    return ((WCvBGCodeBookElem*)ptr)->stale;
                }
            }
            set
            {
                unsafe
                {
                    ((WCvBGCodeBookElem*)ptr)->stale = value;
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
                    byte* p = ((WCvBGCodeBookElem*)ptr)->boxMin;
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
                    byte* p = ((WCvBGCodeBookElem*)ptr)->boxMin;
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
                    byte* p = ((WCvBGCodeBookElem*)ptr)->boxMax;
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
                    byte* p = ((WCvBGCodeBookElem*)ptr)->boxMax;
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
                    byte* p = ((WCvBGCodeBookElem*)ptr)->learnMin;
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
                    byte* p = ((WCvBGCodeBookElem*)ptr)->learnMin;
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
                    byte* p = ((WCvBGCodeBookElem*)ptr)->learnMax;
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
                    byte* p = ((WCvBGCodeBookElem*)ptr)->learnMax;
                    p[0] = value[0];
                    p[1] = value[1];
                    p[2] = value[2];
                }
            }
        }
        #endregion
    }
}