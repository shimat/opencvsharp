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
    public class CvSeqWriter<T> : CvSeqWriter where T: struct
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
        public CvSeqWriter()
            : base()
        {
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
            : base(seq)
        {
        }
#if LANG_JP
        /// <summary>
        /// 新しいシーケンスを作成し，ライタ（writer）を初期化する (cvStartWriteSeq).
        /// </summary>
        /// <param name="seq_flags">作成されたシーケンスのフラグ． 生成されたシーケンスが，特定のシーケンスタイプを引数にとるような関数に一切渡されない場合は，この値に0を指定してもかまわない． そうでない場合は，定義済みのシーケンスタイプのリストから適切なタイプが選択されなければならない． </param>
        /// <param name="header_size">シーケンスヘッダのサイズ．sizeof(CvSeq)以上でなければならない． また，特別なタイプか拡張が指示されている場合，そのタイプは基本タイプのヘッダサイズと合致しなければならない． </param>
        /// <param name="elem_size">シーケンスの要素サイズ（バイト単位）．サイズはシーケンスタイプと合致しなければならない． 例えば，点群のシーケンス（要素タイプは CV_SEQ_ELTYPE_POINT）を作成する場合， パラメータ elem_size は sizeof(CvPoint) と等しくなければならない． </param>
        /// <param name="storage">シーケンスの位置． </param>
#else
        /// <summary>
        /// Creates new sequence and initializes writer for it (cvStartWriteSeq).
        /// </summary>
        /// <param name="seq_flags">Flags of the created sequence. If the sequence is not passed to any function working with a specific type of sequences, the sequence value may be equal to 0, otherwise the appropriate type must be selected from the list of predefined sequence types. </param>
        /// <param name="header_size">Size of the sequence header. The parameter value may not be less than sizeof(CvSeq). If a certain type or extension is specified, it must fit the base type header. </param>
        /// <param name="elem_size">Size of the sequence elements in bytes; must be consistent with the sequence type. For example, if the sequence of points is created (element type CV_SEQ_ELTYPE_POINT ), then the parameter elem_size must be equal to sizeof(CvPoint). </param>
        /// <param name="storage">Sequence location. </param>
#endif
        public CvSeqWriter(SeqType seq_flags, int header_size, int elem_size, CvMemStorage storage)
            : base(seq_flags, header_size, elem_size, storage)
        {
        }
#if LANG_JP
        /// <summary>
        /// ジェネリックなし版のWriterから初期化
        /// </summary>
        /// <param name="writer"></param>
#else
        /// <summary>
        /// Initializes from non generic writer
        /// </summary>
        /// <param name="writer"></param>
#endif
        public CvSeqWriter(CvSeqWriter writer)
            : base(writer.CvPtr)
        {
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
            : base(ptr)
        {
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
            // 親の解放処理
            base.Dispose(disposing);
        }
        #endregion


        #region Methods
        #region WriteSeqElem
#if LANG_JP
        /// <summary>
        /// (CV_WRITE_SEQ_ELEM)
        /// </summary>
        /// <param name="elem"></param>
#else
        /// <summary>
        /// (CV_WRITE_SEQ_ELEM)
        /// </summary>
        /// <param name="elem"></param>
#endif
        public void WriteSeqElem(T elem) 
        {
            Cv.WRITE_SEQ_ELEM<T>(elem, this);
        }
        #endregion
        #endregion
    }
}
