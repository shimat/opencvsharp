using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace OpenCvSharp
{
#if LANG_JP
    /// <summary>
    /// メモリストレージの位置
    /// </summary>
#else
    /// <summary>
    /// Memory storage position
    /// </summary>
#endif
    public class CvMemStoragePos : DisposableCvObject
    {
        #region Init and Disposal
#if LANG_JP
        /// <summary>
        /// メモリを確保して初期化
        /// </summary>
#else
        /// <summary>
        /// Default constructor
        /// </summary>
#endif
        public CvMemStoragePos()
        {
            this.ptr = base.AllocMemory(SizeOf);
        }
#if LANG_JP
        /// <summary>
        /// ポインタから初期化
        /// </summary>
        /// <param name="ptr">struct CvMemStoragePos*</param>
#else
        /// <summary>
        /// Initializes from native pointer
        /// </summary>
        /// <param name="ptr">struct CvMemStoragePos*</param>
#endif
        public CvMemStoragePos(IntPtr ptr)
        {
            this.ptr = ptr;
        }
        #endregion

        #region Properties
        /// <summary>
        /// sizeof(CvMemStoragePos) 
        /// </summary>
        public static readonly int SizeOf = Marshal.SizeOf(typeof(WCvMemStoragePos));


#if LANG_JP
        /// <summary>
        /// 
        /// </summary>
#else
        /// <summary>
        /// 
        /// </summary>
#endif
        public CvMemBlock Top
        {
            get
            {
                IntPtr p;
                unsafe
                {
                    p = new IntPtr(((WCvMemStoragePos*)ptr)->top);
                }
                if (p == IntPtr.Zero)
                    return null;
                else
                    return new CvMemBlock(p);
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
        public int FreeSpace
        {
            get
            {
                unsafe
                {
                    return ((WCvMemStoragePos*)ptr)->free_space;
                }
            }
        }
        #endregion
    }
}
