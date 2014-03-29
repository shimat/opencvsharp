/*
 * (C) 2008-2014 shimat
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
    /// CvSeqにデータを書き込むためのクラス
    /// </summary>
#else
    /// <summary>
    /// Sequence writer
    /// </summary>
#endif
    public class CvSeqWriter : DisposableCvObject
    {
        /// <summary>
        /// Track whether Dispose has been called
        /// </summary>
        private bool disposed = false;

        #region Initialization and Disposal
#if LANG_JP
        /// <summary>
        /// 初期化
        /// </summary>
#else
        /// <summary>
        /// Default constructor
        /// </summary>
#endif
        public CvSeqWriter()
        {
            ptr = AllocMemory(SizeOf);
            NotifyMemoryPressure(SizeOf);
        }
#if LANG_JP
        /// <summary>
        /// シーケンスへのデータ書き込み処理を初期化する (cvStartAppendToSeq).
        /// </summary>
        /// <param name="seq">シーケンスのポインタ</param>
        /// <returns>ライタ（Writer）の状態．この関数で初期化される．</returns>
#else
        /// <summary>
        /// Initializes process of writing data to sequence (cvStartAppendToSeq).
        /// </summary>
        /// <param name="seq">Pointer to the sequence. </param>
        /// <returns>Writer state; initialized by the function. </returns>
#endif
        public CvSeqWriter(CvSeq seq)
            : this()
        {
            if (seq == null)
            {
                throw new ArgumentNullException("seq");
            }
            NativeMethods.cvStartAppendToSeq(seq.CvPtr, ptr);
        }
#if LANG_JP
        /// <summary>
        /// 新しいシーケンスを作成し，ライタ（writer）を初期化する (cvStartWriteSeq).
        /// </summary>
        /// <param name="seqFlags">作成されたシーケンスのフラグ． 生成されたシーケンスが，特定のシーケンスタイプを引数にとるような関数に一切渡されない場合は，この値に0を指定してもかまわない． そうでない場合は，定義済みのシーケンスタイプのリストから適切なタイプが選択されなければならない． </param>
        /// <param name="headerSize">シーケンスヘッダのサイズ．sizeof(CvSeq)以上でなければならない． また，特別なタイプか拡張が指示されている場合，そのタイプは基本タイプのヘッダサイズと合致しなければならない． </param>
        /// <param name="elemSize">シーケンスの要素サイズ（バイト単位）．サイズはシーケンスタイプと合致しなければならない． 例えば，点群のシーケンス（要素タイプは CV_SEQ_ELTYPE_POINT）を作成する場合， パラメータ elem_size は sizeof(CvPoint) と等しくなければならない． </param>
        /// <param name="storage">シーケンスの位置． </param>
#else
        /// <summary>
        /// Creates new sequence and initializes writer for it (cvStartWriteSeq).
        /// </summary>
        /// <param name="seqFlags">Flags of the created sequence. If the sequence is not passed to any function working with a specific type of sequences, the sequence value may be equal to 0, otherwise the appropriate type must be selected from the list of predefined sequence types. </param>
        /// <param name="headerSize">Size of the sequence header. The parameter value may not be less than sizeof(CvSeq). If a certain type or extension is specified, it must fit the base type header. </param>
        /// <param name="elemSize">Size of the sequence elements in bytes; must be consistent with the sequence type. For example, if the sequence of points is created (element type CV_SEQ_ELTYPE_POINT ), then the parameter elem_size must be equal to sizeof(CvPoint). </param>
        /// <param name="storage">Sequence location. </param>
#endif
        public CvSeqWriter(SeqType seqFlags, int headerSize, int elemSize, CvMemStorage storage)
            : this()
        {
            if (storage == null)
                throw new ArgumentNullException("storage");
           
            NativeMethods.cvStartWriteSeq(seqFlags, headerSize, elemSize, storage.CvPtr, ptr);
        }
#if LANG_JP
        /// <summary>
        /// ポインタから初期化
        /// </summary>
        /// <param name="ptr">CvSeqWriter*</param>
#else
        /// <summary>
        /// Initializes from pointer
        /// </summary>
        /// <param name="ptr">CvSeqWriter*</param>
#endif
        public CvSeqWriter(IntPtr ptr)
        {
            base.ptr = ptr;
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
                // 継承したクラス独自の解放処理
                try
                {
                    if (disposing)
                    {
                    }
                    if (IsEnabledDispose)
                    {
                        try
                        {
                            NativeMethods.cvEndWriteSeq(ptr);
                        }
                        catch { }
                    }
                    disposed = true;
                }
                finally
                {
                    // 親の解放処理
                    base.Dispose(disposing);
                }
            }
        }
        #endregion

        #region Properties
        /// <summary>
        /// sizeof(CvSeqWriter) 
        /// </summary>
        public static readonly int SizeOf = Marshal.SizeOf(typeof(WCvSeqWriter));


#if LANG_JP
		/// <summary>
		/// シーケンスのヘッダサイズ
		/// </summary>
#else
        /// <summary>
        /// size of sequence header
        /// </summary>
#endif
        public int HeaderSize
        {
            get
            {
                unsafe
                {
                    return ((WCvSeqWriter*)ptr)->header_size;
                }
            }
        }
        /// <summary>
        /// Sequence, beign read
        /// </summary>
        public CvSeq Seq
        {
            get
            {
                IntPtr p;
                unsafe
                {
                    p = new IntPtr(((WCvSeqWriter*)ptr)->seq);
                }
                if (p == IntPtr.Zero)
                    return null;
                return new CvSeq(p);
            }
        }
        /// <summary>
        /// current block
        /// </summary>
        public CvSeqBlock Block
        {
            get
            {
                IntPtr p;
                unsafe
                {
                    p = new IntPtr(((WCvSeqWriter*)ptr)->block);
                }
                if (p == IntPtr.Zero)
                    return null;
                return new CvSeqBlock(p);
            }
        }
        /// <summary>
        /// pointer to element be read next
        /// </summary>
        public IntPtr Ptr
        {
            get
            {
                unsafe
                {
                    return new IntPtr(((WCvSeqWriter*)ptr)->ptr);
                }
            }
            internal set
            {
                unsafe
                {
                    ((WCvSeqWriter*)ptr)->ptr = (sbyte*)value;
                }
            }
        }
        /// <summary>
        /// pointer to the beginning of block
        /// </summary>
        public IntPtr BlockMin
        {
            get
            {
                unsafe
                {
                    return new IntPtr(((WCvSeqWriter*)ptr)->block_min);
                }
            }
        }
        /// <summary>
        /// pointer to the End of block
        /// </summary>
        public IntPtr BlockMax
        {
            get
            {
                unsafe
                {
                    return new IntPtr(((WCvSeqWriter*)ptr)->block_max);
                }
            }
        }
        #endregion

        #region Methods
        #region EndWriteSeq
#if LANG_JP
        /// <summary>
        /// シーケンス書き込み処理を終了する
        /// </summary>
        /// <returns>書き込まれたシーケンスへのポインタ</returns>
#else
        /// <summary>
        /// Finishes process of writing sequence
        /// </summary>
        /// <returns>the pointer to the written sequence.</returns>
#endif
        public CvSeq EndWriteSeq()
        {
            if (IsDisposed)
            {
                return null;
            }
            IntPtr result = NativeMethods.cvEndWriteSeq(CvPtr);
            IsDisposed = true;
            if (result == IntPtr.Zero)
                return null;
            return new CvSeq(result);
        }
        #endregion
        #region Flush
#if LANG_JP
        /// <summary>
        /// ライタの状態からシーケンスヘッダを更新する (cvFlushSeqWriter).
        /// </summary>
#else
        /// <summary>
        /// Updates sequence headers from the writer state (cvFlushSeqWriter).
        /// </summary>
#endif
        public void Flush()
        {
            NativeMethods.cvFlushSeqWriter(ptr);
        }
        #endregion
        #region WriteSeqElemVar
#if LANG_JP
        /// <summary>
        /// (CV_WRITE_SEQ_ELEM_VAR)
        /// </summary>
        /// <param name="elemPtr"></param>
#else
        /// <summary>
        /// (CV_WRITE_SEQ_ELEM_VAR)
        /// </summary>
        /// <param name="elemPtr"></param>
#endif
        public void WRITE_SEQ_ELEM_VAR(IntPtr elemPtr)
        {
            Cv.WRITE_SEQ_ELEM_VAR(elemPtr, this);
        }
        #endregion
        #region WriteSeqElem
#if LANG_JP
        /// <summary>
        /// (CV_WRITE_SEQ_ELEM)
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="elem"></param>
#else
        /// <summary>
        /// (CV_WRITE_SEQ_ELEM)
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="elem"></param>
#endif
        public void WriteSeqElem<T>(T elem) where T : struct
        {
            Cv.WRITE_SEQ_ELEM(elem, this);
        }
        #endregion
        #endregion
    }
}
