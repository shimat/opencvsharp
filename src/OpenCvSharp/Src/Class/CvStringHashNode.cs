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
            this.ptr = ptr;
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
                    return ((WCvStringHashNode*)ptr)->hashval;
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
                    return ((WCvStringHashNode*)ptr)->str;
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
                    return new IntPtr(((WCvStringHashNode*)ptr)->next);
                }
            }
        }
        #endregion
    }
}
