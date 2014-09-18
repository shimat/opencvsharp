using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace OpenCvSharp
{
#if LANG_JP
    /// <summary>
    /// 空きノードのリスト
    /// </summary>
#else
    /// <summary>
    /// List of free nodes
    /// </summary>
#endif
    public class CvSetElem : DisposableCvObject
    {
        #region Init and Disposal
#if LANG_JP
        /// <summary>
        /// 初期化
        /// </summary>
#else
        /// <summary>
        /// Default constructor
        /// </summary>
#endif
        public CvSetElem()
        {
            this.ptr = base.AllocMemory(SizeOf);
        }
#if LANG_JP
        /// <summary>
        /// ポインタから初期化
        /// </summary>
        /// <param name="ptr">struct CvSetElem*</param>
#else
        /// <summary>
        /// Initializes from native pointer
        /// </summary>
        /// <param name="ptr">struct CvSetElem*</param>
#endif
        public CvSetElem(IntPtr ptr)
        {
            this.ptr = ptr;
        }
        #endregion

        #region Properties
        /// <summary>
        /// sizeof(CvSetElem) 
        /// </summary>
        public static readonly int SizeOf = Marshal.SizeOf(typeof(WCvSetElem));


#if LANG_JP
        /// <summary>
        /// 空きノードのリスト 
        /// </summary>
#else
        /// <summary>
        /// if the node is free, the field is a pointer to next free node
        /// </summary>
#endif
        public CvSetElem NextFree
        {
            get 
            {
                IntPtr p;
                unsafe
                {
                    p = new IntPtr(((WCvSetElem*)ptr)->next_free);
                }
                if (p == IntPtr.Zero)
                    return null;
                else
                    return new CvSetElem(p); 
            }
        }
#if LANG_JP
        /// <summary>
        /// 空きノードならtrue, その他の場合はfalse
        /// </summary>
#else
        /// <summary>
        /// it is true if the node is free and false otherwise
        /// </summary>
#endif
        public bool Flags
        {
            get
            {
                unsafe
                {
                    return ((WCvSetElem*)ptr)->flags != 0;
                }
            }
        }
        #endregion
    }
}
