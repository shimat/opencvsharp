using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace OpenCvSharp
{
#if LANG_JP
    /// <summary>
    /// CvSeqからデータを読み取るためのクラス
    /// </summary>
#else
    /// <summary>
    /// Sequence reader
    /// </summary>
#endif
    public class CvSeqReader : DisposableCvObject 
    {
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
        public CvSeqReader()
        {
            this.ptr = base.AllocMemory(SizeOf);
        }
        #endregion

        #region Properties
        /// <summary>
        /// sizeof(CvSeqReader) 
        /// </summary>
        public static readonly int SizeOf = Marshal.SizeOf(typeof(WCvSeqReader));


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
                    return ((WCvSeqReader*)ptr)->header_size;
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
                    p = new IntPtr(((WCvSeqReader*)ptr)->seq);
                }
                if (p == IntPtr.Zero)
                    return null;
                else
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
                    p = new IntPtr(((WCvSeqReader*)ptr)->block);
                }
                if (p == IntPtr.Zero)
                    return null;
                else
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
                    return new IntPtr(((WCvSeqReader*)ptr)->ptr);
                }
            }
            internal set
            {
                unsafe
                {
                    ((WCvSeqReader*)ptr)->ptr = (sbyte*)value;
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
                    return new IntPtr(((WCvSeqReader*)ptr)->block_min);
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
                    return new IntPtr(((WCvSeqReader*)ptr)->block_max);
                }
            }
        }
        /// <summary>
        /// seq->first->start_index
        /// </summary>
        public int DeltaIndex
        {
            get
            {
                unsafe
                {
                    return ((WCvSeqReader*)ptr)->delta_index;
                }
            }
        }
        /// <summary>
        /// pointer to the End of block
        /// </summary>
        public IntPtr PrevElem
        {
            get
            {
                unsafe
                {
                    return new IntPtr(((WCvSeqReader*)ptr)->prev_elem);
                }
            }
        }
#if LANG_JP
        /// <summary>
        /// 現在のリーダの位置を取得・設定する
        /// </summary>
#else
        /// <summary>
        /// Gets/Sets the current reader position
        /// </summary>
#endif
        public int ReaderPos
        {
            get { return GetPos(); }
            set { SetPos(value); }
        }
        #endregion

        #region Methods
        #region GetPos
#if LANG_JP
        /// <summary>
        /// 現在のリーダの位置（0 ... reader->seq->total - 1 の範囲）を返す (cvGetSeqReaderPos).
        /// </summary>
        /// <returns>リーダの位置</returns>
#else
        /// <summary>
        /// Returns the current reader position (cvGetSeqReaderPos).
        /// </summary>
        /// <returns>the current reader position</returns>
#endif
        public int GetPos()
        {
            return Cv.GetSeqReaderPos(this);
        }
        #endregion
        #region NextSeqElem
        /// <summary>
        /// 次のシーケンスへ (CV_NEXT_SEQ_ELEM相当)
        /// </summary>
        /// <param name="elem_size"></param>
        public void NextSeqElem(int elem_size)
        {
            Cv.NEXT_SEQ_ELEM(elem_size, this);
        }
        #endregion
        #region PrevSeqElem
        /// <summary>
        /// 前のシーケンスへ (CV_PREV_SEQ_ELEM相当)
        /// </summary>
        /// <param name="elem_size"></param>
        public void PrevSeqElem(int elem_size)
        {
            Cv.PREV_SEQ_ELEM(elem_size, this);
        }
        #endregion
        #region ReadSeqElem
        /// <summary>
        /// シーケンスの要素を一つ読みだして、読み出しポインタを次へ1つ移動させる (CV_READ_SEQ_ELEM相当)
        /// </summary>
        public T ReadSeqElem<T>() where T : struct 
        {
            T result;
            Cv.READ_SEQ_ELEM<T>(out result, this);
            return result;
        }
        #endregion
        #region RevReadSeqElem
        /// <summary>
        /// シーケンスの前の要素を一つ読みだして、読み出しポインタを前へ1つ移動させる (CV_REV_READ_SEQ_ELEM相当)
        /// </summary>
        public T RevReadSeqElem<T>() where T : struct 
        {
            T result;
            Cv.REV_READ_SEQ_ELEM(out result, this);
            return result;
        }
        #endregion
        #region SetPos
#if LANG_JP
        /// <summary>
        /// 読み込み位置を絶対位置か相対位置で表された位置に移動する (cvSetSeqReaderPos).
        /// </summary>
        /// <param name="index">移動先の位置．位置決めモード（次のパラメータis_relativeを参照）が使用されている場合， 実際の位置は index を reader->seq->totalで割った剰余になる．</param>
#else
        /// <summary>
        /// Moves the reader to specified position (cvSetSeqReaderPos).
        /// </summary>
        /// <param name="index">The destination position. If the positioning mode is used (see the next parameter) the actual position will be index mod reader->seq->total. </param>
#endif
        public void SetPos(int index)
        {
            Cv.SetSeqReaderPos(this, index);
        }
#if LANG_JP
        /// <summary>
        /// 読み込み位置を絶対位置か相対位置で表された位置に移動する (cvSetSeqReaderPos).
        /// </summary>
        /// <param name="index">移動先の位置．位置決めモード（次のパラメータis_relativeを参照）が使用されている場合， 実際の位置は index を reader->seq->totalで割った剰余になる．</param>
        /// <param name="is_relative">true，index は現在位置からの相対値</param>
#else
        /// <summary>
        /// Moves the reader to specified position (cvSetSeqReaderPos).
        /// </summary>
        /// <param name="index">The destination position. If the positioning mode is used (see the next parameter) the actual position will be index mod reader->seq->total. </param>
        /// <param name="is_relative">If it is true, then index is a relative to the current position. </param>
#endif
        public void SetPos(int index, bool is_relative)
        {
            Cv.SetSeqReaderPos(this, index, is_relative);
        }
        #endregion
        #endregion
    }
}
