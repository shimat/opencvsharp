using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace OpenCvSharp
{
#if LANG_JP
    /// <summary>
    /// 連続したシーケンスブロック
    /// </summary>
#else
    /// <summary>
    /// Continuous sequence block
    /// </summary>
#endif
    public class CvSeqBlock : DisposableCvObject
    {
        #region Constructors
#if LANG_JP
        /// <summary>
        /// メモリを確保して初期化
        /// </summary>
#else
        /// <summary>
        /// Default constructor
        /// </summary>
#endif
        public CvSeqBlock()
        {
            this.ptr = base.AllocMemory(SizeOf);
        }
#if LANG_JP
        /// <summary>
        /// ポインタから初期化
        /// </summary>
        /// <param name="ptr">CvSeqBlock*</param>
#else
        /// <summary>
        /// Initializes from native pointer
        /// </summary>
        /// <param name="ptr">CvSeqBlock*</param>
#endif
        public CvSeqBlock(IntPtr ptr)
        {
            this.ptr = ptr;
        }
        #endregion

        #region Propertirs
        /// <summary>
        /// sizeof(CvSeqBlock)
        /// </summary>
        public static readonly int SizeOf = Marshal.SizeOf(typeof(WCvSeqBlock));


#if LANG_JP
        /// <summary>
		/// 前のシーケンスブロック
		/// </summary>
#else
        /// <summary>
        /// previous sequence block
        /// </summary>
#endif
        public CvSeqBlock Prev
        {
            get
            {
                IntPtr p;
                unsafe
                {
                    p = new IntPtr(((WCvSeqBlock*)ptr)->prev);
                }
                if (p == IntPtr.Zero)
                    return null;
                return new CvSeqBlock(p);
            }
        }
#if LANG_JP
		/// <summary>
		/// 次のシーケンスブロック
		/// </summary>
#else
        /// <summary>
        /// next sequence block
        /// </summary>
#endif
        public CvSeqBlock Next
        {
            get
            {
                IntPtr p;
                unsafe
                {
                    p = new IntPtr(((WCvSeqBlock*)ptr)->next);
                }
                if (p == IntPtr.Zero)
                    return null;
                return new CvSeqBlock(p);
            }
        }
#if LANG_JP
		/// <summary>
		/// ブロックの先頭要素のインデックス. 
		/// sequence->first->start_index 
		/// </summary>
#else
        /// <summary>
        /// index of the first element in the block + sequence->first->start_index
        /// </summary>
#endif
        public int StartIndex
        {
            get
            {
                unsafe
                {
                    return ((WCvSeqBlock*)ptr)->start_index;
                }
            }
        }
#if LANG_JP
		/// <summary>
		/// ブロック内の要素数
		/// </summary>
#else
        /// <summary>
        /// number of elements in the block
        /// </summary>
#endif
        public int Count
        {
            get
            {
                unsafe
                {
                    return ((WCvSeqBlock*)ptr)->count;
                }
            }
        }
#if LANG_JP
		/// <summary>
		/// ブロックの先頭要素へのポインタ
		/// </summary>
#else
        /// <summary>
        /// pointer to the first element of the block
        /// </summary>
#endif
        public IntPtr Data
        {
            get
            {
                unsafe
                {
                    return new IntPtr(((WCvSeqBlock*)ptr)->data);
                }
            }
        }
        #endregion
    }
}
