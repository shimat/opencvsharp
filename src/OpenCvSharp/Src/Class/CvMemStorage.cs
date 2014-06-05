using System;
using System.Runtime.InteropServices;

namespace OpenCvSharp
{
#if LANG_JP
    /// <summary>
	/// 動的に拡張可能なメモリストレージ
	/// </summary>
#else
    /// <summary>
    /// Growing memory storage
    /// </summary>
#endif
    public class CvMemStorage : DisposableCvObject
    {
        /// <summary>
        /// Track whether Dispose has been called
        /// </summary>
        private bool disposed;

        #region Init and Disposal
#if LANG_JP
        /// <summary>
        /// メモリストレージを生成し，その参照を返す [block_size=0 (≈64K)]．初期状態ではストレージは空である．
        /// block_sizeを除くヘッダのフィールドは全て0に設定されている.
        /// </summary>
#else
        /// <summary>
        /// Creates memory storage
        /// </summary>
#endif
        public CvMemStorage()
            : this(0)
        {
        }
#if LANG_JP
        /// <summary>
        /// メモリストレージを生成し，その参照を返す．初期状態ではストレージは空である．
        /// block_sizeを除くヘッダのフィールドは全て0に設定されている.
        /// </summary>
        /// <param name="blockSize">ストレージブロックのバイト単位のサイズ．0の場合，デフォルト値（現在は≈64K）が使われる．</param>
#else
        /// <summary>
        /// Creates memory storage
        /// </summary>
        /// <param name="blockSize">Size of the storage blocks in bytes. If it is 0, the block size is set to default value - currently it is ≈64K. </param>
#endif
        public CvMemStorage(int blockSize)
        {
            ptr = NativeMethods.cvCreateMemStorage(blockSize);
            if (ptr == IntPtr.Zero)
                throw new OpenCvSharpException("Failed to create CvMemStorage");
        }

#if LANG_JP
        /// <summary>
	    /// ポインタで初期化
	    /// </summary>
	    /// <param name="ptr">struct CvMemStorage*</param>
#else
        /// <summary>
        /// Initializes from native poitner
        /// </summary>
        /// <param name="ptr">struct CvMemStorage*</param>
#endif
        public CvMemStorage(IntPtr ptr)
            : this(ptr, false)
        {
        }
#if LANG_JP
        /// <summary>
        /// ポインタと自動解放の可否を指定して初期化
        /// </summary>
        /// <param name="ptr"></param>
        /// <param name="isEnabledDispose"></param>
#else
        /// <summary>
        /// Initializes by native pointer
        /// </summary>
        /// <param name="ptr"></param>
        /// <param name="isEnabledDispose">If true, this object will be disposed by GC automatically.</param>
#endif
        internal CvMemStorage(IntPtr ptr, bool isEnabledDispose)
            : base(isEnabledDispose)
	    {
            if (ptr == IntPtr.Zero)
                throw new OpenCvSharpException("Failed to create CvMemStorage");
            this.ptr = ptr;
	    }

#if LANG_JP
        /// <summary>
        /// リソースの解放
        /// </summary>
        /// <param name="disposing">
        /// trueの場合は、このメソッドがユーザコードから直接が呼ばれたことを示す。マネージ・アンマネージ双方のリソースが解放される。
        /// falseの場合は、このメソッドはランタイムからファイナライザによって呼ばれ、もうほかのオブジェクトから参照されていないことを示す。アンマネージリソースのみ解放される。
        ///</param>
#else
        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">
        /// If disposing equals true, the method has been called directly or indirectly by a user's code. Managed and unmanaged resources can be disposed.
        /// If false, the method has been called by the runtime from inside the finalizer and you should not reference other objects. Only unmanaged resources can be disposed.
        /// </param>
#endif
        protected override void Dispose(bool disposing)
        {
            if (!disposed)
            {
                try
                {
                    if (disposing)
                    {
                    }
                    if (IsEnabledDispose)
                    {
                        NativeMethods.cvReleaseMemStorage(ref ptr);  
                    }
                    disposed = true;
                }
                finally
                {
                    base.Dispose(disposing);
                }
            }
        }
        #endregion

        #region Properties
        /// <summary>
        /// sizeof(CvMemStorage) 
        /// </summary>
        public static readonly int SizeOf = Marshal.SizeOf(typeof(WCvMemStorage));


#if LANG_JP
        /// <summary>
        /// 
        /// </summary>
#else
        /// <summary>
        /// 
        /// </summary>
#endif
        public int Signature 
		{
            get
            {
                unsafe
                {
                    return ((WCvMemStorage*)ptr)->signature;
                }
            }
		}
#if LANG_JP
        /// <summary>
        /// 最初に確保されたブロック
        /// </summary>
#else
        /// <summary>
        /// first allocated block
        /// </summary>
#endif
		public CvMemBlock Bottom 
		{
            get
            {
                unsafe
                {
                    IntPtr p = new IntPtr(((WCvMemStorage*)ptr)->bottom);

                    if (p != IntPtr.Zero)
                        return new CvMemBlock(p);
                    return null;
                }
            }
		}
#if LANG_JP
        /// <summary>
        /// 新たなブロックを確保する場所
        /// </summary>
#else
        /// <summary>
        /// the current memory block - top of the stack
        /// </summary>
#endif
        public CvMemBlock Top 
		{
            get
            {
                unsafe
                {
                    IntPtr p = new IntPtr(((WCvMemStorage*)ptr)->top);

                    if (p != IntPtr.Zero)
                        return new CvMemBlock(p);
                    else
                        return null;
                }
            }
		}
#if LANG_JP
        /// <summary>
        /// 現在のメモリブロック − スタックの先頭
        /// </summary>
#else
        /// <summary>
        /// borrows new blocks from
        /// </summary>
#endif
		public CvMemStorage Parent 
		{
            get
            {
                unsafe
                {
                    IntPtr p = new IntPtr(((WCvMemStorage*)ptr)->parent);

                    if (p != IntPtr.Zero)
                        return new CvMemStorage(p, false);
                    else
                        return null;
                }
            }
		}
#if LANG_JP
        /// <summary>
        /// ブロックの大きさ
        /// </summary>
#else
        /// <summary>
        /// block size
        /// </summary>
#endif
		public int BlockSize 
		{
            get
            {
                unsafe
                {
                    return ((WCvMemStorage*)ptr)->block_size;
                }
            }
		}
#if LANG_JP
        /// <summary>
        /// topブロック内の自由領域（バイト単位）
        /// </summary>
#else
        /// <summary>
        /// free space in the top block (in bytes)
        /// </summary>
#endif
		public int FreeSpace 
		{
            get
            {
                unsafe
                {
                    return ((WCvMemStorage*)ptr)->free_space;
                }
            }
		}
        #endregion

        #region Methods
        #region Alloc
#if LANG_JP
        /// <summary>
        /// ストレージ内にメモリバッファを確保する (cvMemStorageAlloc).
        /// </summary>
        /// <param name="size">バッファサイズ</param>
        /// <returns></returns>
#else
        /// <summary>
        /// Allocates memory buffer in the storage (cvMemStorageAlloc).
        /// </summary>
        /// <param name="size">Buffer size. </param>
        /// <returns></returns>
#endif
        public IntPtr Alloc(uint size)
        {
            return Cv.MemStorageAlloc(this, size);
        }
        #endregion
        #region AllocString
#if LANG_JP
        /// <summary>
        /// ストレージ内にテキスト文字列を確保する (cvMemStorageAllocString).
        /// </summary>
        /// <param name="str">文字列</param>
        /// <returns></returns>
#else
        /// <summary>
        /// Allocates text string in the storage (cvMemStorageAllocString).
        /// </summary>
        /// <param name="str">The string</param>
        /// <returns></returns>
#endif
        public CvString AllocString(string str)
        {
            return Cv.MemStorageAllocString(this, str);
        }
        #endregion
        #region Clear
#if LANG_JP
        /// <summary>
        /// メモリストレージをクリアする (cvClearMemStorage)．
        /// </summary>
#else
        /// <summary>
        /// Clears memory storage (cvClearMemStorage)．
        /// </summary>
#endif
	    public void Clear()
	    {
		    Cv.ClearMemStorage(this);
        }
        #endregion
        #region CreateChild
#if LANG_JP
        /// <summary>
        /// 子メモリストレージを生成する (cvCreateChildMemStorage).
        /// </summary>
        /// <returns></returns>
#else
        /// <summary>
        /// Creates child memory storage (cvCreateChildMemStorage).
        /// </summary>
        /// <returns></returns>
#endif
	    public CvMemStorage CreateChild()
	    {
		    return Cv.CreateChildMemStorage(this);
        }
        #endregion
        #region RestorePos
#if LANG_JP
        /// <summary>
        /// メモリストレージの位置を復元する (cvRestoreMemStoragePos).
        /// </summary>
        /// <param name="pos">新しいストレージの先頭位置</param>
#else
        /// <summary>
        /// Restores memory storage position (cvRestoreMemStoragePos).
        /// </summary>
        /// <param name="pos">New storage top position</param>
#endif
        public void RestorePos(CvMemStoragePos pos)
        {
            Cv.RestoreMemStoragePos(this, pos);
        }
        #endregion
        #region SavePos
#if LANG_JP
        /// <summary>
        /// メモリストレージの位置を保存する (cvSaveMemStoragePos).
        /// </summary>
        /// <returns>ストレージ先頭の位置．</returns>
#else
        /// <summary>
        /// Saves memory storage position (cvSaveMemStoragePos).
        /// </summary>
        /// <returns>position of the storage top. </returns>
#endif
        public CvMemStoragePos SavePos()
        {
            CvMemStoragePos pos;
            Cv.SaveMemStoragePos(this, out pos);
            return pos;
        }
        #endregion
        #endregion
    }
}
