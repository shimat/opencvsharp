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
    /// 拡張可能な要素のシーケンス
    /// </summary>
#else
    /// <summary>
    /// Generic growable sequence of elements
    /// </summary>
    /// <typeparam name="T"></typeparam>
#endif
    public class CvSeq<T> : CvSeq, ICloneable, IEnumerable<T?> where T : struct
    {
        #region Init and Disposal
#if LANG_JP
        /// <summary>
        /// シーケンスを生成する. header_size=sizeof(CvSeq)
        /// </summary>
        /// <param name="seq_flags">生成されたシーケンスのフラグ．生成されたシーケンスが，特定のシーケンスタイプを引数にとるような関数に一切渡されない場合は，この値に0を指定してもかまわない．そうでない場合は，定義済みのシーケンスタイプのリストから適切なタイプが選択されなければならない．</param>
        /// <param name="storage">シーケンスが保存される場所</param>
        /// <returns></returns>
#else
        /// <summary>
        /// Creates sequence. header_size=sizeof(CvSeq)
        /// </summary>
        /// <param name="seq_flags">Flags of the created sequence. If the sequence is not passed to any function working with a specific type of sequences, the sequence value may be set to 0, otherwise the appropriate type must be selected from the list of predefined sequence types. </param>
        /// <param name="storage">Sequence location. </param>
        /// <returns></returns>
#endif
        public CvSeq(SeqType seq_flags, CvMemStorage storage)
            : base(seq_flags, Util.SizeOf(typeof(T)), storage)
        {
        }
#if LANG_JP
        /// <summary>
        /// シーケンスを生成する
        /// </summary>
        /// <param name="seq_flags">生成されたシーケンスのフラグ．生成されたシーケンスが，特定のシーケンスタイプを引数にとるような関数に一切渡されない場合は，この値に0を指定してもかまわない．そうでない場合は，定義済みのシーケンスタイプのリストから適切なタイプが選択されなければならない．</param>
        /// <param name="header_size">シーケンスのヘッダサイズ．sizeof(CvSeq)以上でなければならない． また，特別なタイプかその拡張が指示されている場合，そのタイプは基本タイプのヘッダと合致していなければならない．</param>
        /// <param name="storage">シーケンスが保存される場所</param>
#else
        /// <summary>
        /// Creates sequence
        /// </summary>
        /// <param name="seq_flags">Flags of the created sequence. If the sequence is not passed to any function working with a specific type of sequences, the sequence value may be set to 0, otherwise the appropriate type must be selected from the list of predefined sequence types. </param>
        /// <param name="header_size">Size of the sequence header; must be greater or equal to sizeof(CvSeq). If a specific type or its extension is indicated, this type must fit the base type header. </param>
        /// <param name="storage">Sequence location. </param>
#endif
        public CvSeq(SeqType seq_flags, int header_size, CvMemStorage storage)
            : base(seq_flags, header_size, Util.SizeOf(typeof(T)), storage)
        {
        }
        /// <summary>
        /// CvSeq -> CvSeq&lt;t&gt;
        /// </summary>
        /// <param name="seq"></param>
        public CvSeq(CvSeq seq)
            : base(seq.CvPtr)
        {
        }
#if LANG_JP
        /// <summary>
        /// ポインタから初期化
        /// </summary>
        /// <param name="ptr">struct CvSeq*</param>
#else
        /// <summary>
        /// Initializes from native pointer
        /// </summary>
        /// <param name="ptr">struct CvSeq*</param>
#endif
        public CvSeq(IntPtr ptr)
            : base(ptr)
        {
        }

#if LANG_JP
        /// <summary>
        /// 配列からインスタンスを生成する
        /// </summary>
        /// <param name="array">IEnumerableインタフェースを実装するオブジェクト。ArrayやList&lt;t&gt;など。</param>
        /// <param name="seq_flags">生成されたシーケンスのフラグ</param>
        /// <param name="storage">シーケンスが保存される場所</param>
        /// <returns>CvSeq&lt;t&gt;</returns>
#else
        /// <summary>
        /// Creates CvSeq&lt;t&gt; from an IEnumerable&lt;t&gt; instance (ex. Array, List&lt;t&gt;)
        /// </summary>
        /// <param name="array">IEnumerable&lt;t&gt; instance</param>
        /// <param name="seq_flags">Flags of the created sequence</param>
        /// <param name="storage">Sequence location</param>
        /// <returns>CvSeq&lt;t&gt;</returns>
#endif
        public static CvSeq<T> FromArray(IEnumerable<T> array, SeqType seq_flags, CvMemStorage storage)
        {
            CvSeq<T> seq = new CvSeq<T>(seq_flags, storage);
            foreach (var item in array)
            {
                Cv.SeqPush<T>(seq, item);
            }
            return seq;
        }
        #endregion

        #region Properties
#if LANG_JP
        /// <summary>
        /// 一つ前のシーケンスへのポインタ
        /// </summary>
#else
        /// <summary>
        /// previous sequence
        /// </summary>
#endif
        new public CvSeq<T> HPrev
        {
            get
            {
                CvSeq seq = base.HPrev;
                if (seq == null)
                    return null;
                else
                    return new CvSeq<T>(seq);
            }
        }
#if LANG_JP
        /// <summary>
        /// 一つ後のシーケンスへのポインタ
        /// </summary>
#else
        /// <summary>
        /// next sequence
        /// </summary>
#endif
        new public CvSeq<T> HNext
        {
            get
            {
                CvSeq seq = base.HNext;
                if (seq == null)
                    return null;
                else
                    return new CvSeq<T>(seq);
            }
        }
#if LANG_JP
        /// <summary>
        /// 一つ前のシーケンスへのポインタ（セカンダリ，構造によって意味が異なる）
        /// </summary>
#else
        /// <summary>
        /// 2nd previous sequence
        /// </summary>
#endif
        new public CvSeq<T> VPrev
        {
            get
            {
                CvSeq seq = base.VPrev;
                if (seq == null)
                    return null;
                else
                    return new CvSeq<T>(seq);
            }
        }
#if LANG_JP
        /// <summary>
        /// 一つ後のシーケンスへのポインタ（セカンダリ，構造によって意味が異なる）
        /// </summary>
#else
        /// <summary>
        /// 2nd next sequence
        /// </summary>
#endif
        new public CvSeq<T> VNext
        {
            get
            {
                CvSeq seq = base.VNext;
                if (seq == null)
                    return null;
                else
                    return new CvSeq<T>(seq);
            }
        }
#if LANG_JP
        /// <summary>
        /// 要素にアクセスするインデクサ
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
#else
        /// <summary>
        /// Indexer (cvGetSeqElem)
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
#endif
        new public T? this[int index]
        {
            get { return Cv.GetSeqElem<T>(this, index); }
        }
        #endregion

        #region Methods
        #region Clone
#if LANG_JP
        /// <summary>
        /// 入力行列のコピーを作成し返す (cvCloneSeq).
        /// </summary>
        /// <returns>コピーされたCvSeq</returns>
#else
        /// <summary>
        /// Creates a copy of sequence (cvCloneSeq).
        /// </summary>
        /// <returns></returns>
#endif
        new public CvSeq<T> Clone()
        {
            return Cv.CloneSeq(this);
        }
#if LANG_JP
        /// <summary>
        /// 入力行列のコピーを作成し返す (cvCloneSeq).
        /// </summary>
        /// <param name="storage">新しいシーケンスヘッダとコピーされたデータ（もしデータがあれば）を保存する出力ストレージ． nullの場合，入力シーケンスに含まれるストレージを使用する．</param>
        /// <returns>コピーされたCvSeq</returns>
#else
        /// <summary>
        /// Creates a copy of sequence (cvCloneSeq).
        /// </summary>
        /// <param name="storage">The destination storage to keep the new sequence header and the copied data if any. If it is null, the function uses the storage containing the input sequence. </param>
        /// <returns></returns>
#endif
        new public CvSeq<T> Clone(CvMemStorage storage)
        {
            return Cv.CloneSeq<T>(this, storage);
        }
        #endregion
        #region ElemIdx
#if LANG_JP
        /// <summary>
        /// 指定されたシーケンスの要素のインデックスを返す (cvSeqElemIdx).
        /// </summary>
        /// <param name="element">シーケンス要素</param>
        /// <returns>指定されたシーケンス要素のインデックス</returns>
#else
        /// <summary>
        /// Returns index of concrete sequence element (cvSeqElemIdx).
        /// </summary>
        /// <param name="element">the element within the sequence. </param>
        /// <returns>the index of a sequence element or a negative number if the element is not found.</returns>
#endif
        public int ElemIdx(T element) 
        {
            return Cv.SeqElemIdx<T>(this, element);
        }
#if LANG_JP
        /// <summary>
        /// 指定されたシーケンスの要素のインデックスを返す (cvSeqElemIdx).
        /// </summary>
        /// <param name="element">シーケンス要素</param>
        /// <param name="block">要素を含むシーケンスブロックのアドレスがこの場所に保存される．</param>
        /// <returns>指定されたシーケンス要素のインデックス</returns>
#else
        /// <summary>
        /// Returns index of concrete sequence element (cvSeqElemIdx).
        /// </summary>
        /// <param name="element">the element within the sequence. </param>
        /// <param name="block">the address of the sequence block that contains the element is stored in this location. </param>
        /// <returns>the index of a sequence element or a negative number if the element is not found.</returns>
#endif
        public int ElemIdx(T element, out CvSeqBlock block)
        {
            return Cv.SeqElemIdx<T>(this, element, out block);
        }
        #endregion
        #region GetSeqElem
#if LANG_JP
        /// <summary>
        /// 与えられたインデックスを持つ要素をシーケンスの中から求め，その要素を返す．
        /// </summary>
        /// <param name="index">要素のインデックス. 負のインデックスの指定も可能で, 例えば，-1はシーケンスの最後の要素，-2は最後の一つ前を指す.</param>
        /// <returns>与えられたインデックスを持つ要素．要素が見つからない場合はnull．</returns>
#else
        /// <summary>
        /// Returns pointer to sequence element by its index
        /// </summary>
        /// <param name="index">Index of element. </param>
        /// <returns></returns>
#endif
        public T? GetSeqElem(int index)
        {
            return Cv.GetSeqElem<T>(this, index);
        }
        #endregion
        #region Insert
#if LANG_JP
        /// <summary>
        /// シーケンスの中に要素を挿入する (cvSeqInsert).
        /// </summary>
        /// <param name="before_index">要素が挿入されるインデックス（このインデックスの前に挿入される）</param>
        /// <param name="element">追加される要素. プリミティブ型か、OpenCVの構造体(CvPointなど).</param>
        /// <returns>追加された要素</returns>
#else
        /// <summary>
        /// Inserts element in sequence middle (cvSeqInsert).
        /// </summary>
        /// <param name="before_index">Index before which the element is inserted. Inserting before 0 (the minimal allowed value of the parameter) is equal to cvSeqPushFront and inserting before seq->total (the maximal allowed value of the parameter) is equal to cvSeqPush. </param>
        /// <param name="element">Inserted element. </param>
        /// <returns>Inserted element. </returns>
#endif
        public virtual T Insert(int before_index, T element)
        {
            return Cv.SeqInsert<T>(this, before_index, element);
        }
        #endregion
        #region Partition
#if LANG_JP
        /// <summary>
        /// データシーケンスを同値類（同じクラスに属すると定義されたデータ群）に分割する
        /// </summary>
        /// <param name="storage">同値類として分割されたシーケンスの保存領域．nullの場合は，seq->storage を使用する．</param>
        /// <param name="labels">出力パラメータ．入力シーケンスの各要素に割り振られた（分割結果を表す）0から始まるラベルシーケンスへのポインタのポインタ．</param>
        /// <param name="is_equal">2つのシーケンス要素が同じクラスである場合，関係関数は 0以外を返す． そうでなければ0を返す．分割アルゴリズムは，同値基準として関係関数の推移閉包を用いる．</param>
        /// <returns></returns>
#else
        /// <summary>
        /// Splits sequence into equivalence classes
        /// </summary>
        /// <param name="storage">The storage to store the sequence of equivalence classes. If it is null, the function uses seq->storage for output labels. </param>
        /// <param name="labels">Output parameter. Double pointer to the sequence of 0-based labels of input sequence elements. </param>
        /// <param name="is_equal">The relation function that should return non-zero if the two particular sequence elements are from the same class, and zero otherwise. The partitioning algorithm uses transitive closure of the relation function as equivalence criteria. </param>
        /// <returns></returns>
#endif
        public int Partition(CvMemStorage storage, out CvSeq labels, CvCmpFunc<T> is_equal)
        {
            return Cv.SeqPartition(this, storage, out labels, is_equal);
        }
        #endregion
        #region Pop
#if LANG_JP
        /// <summary>
        /// シーケンスの末尾から一つの要素を削除する (cvSeqPop).
        /// </summary>
        /// <returns>削除した要素</returns>
#else
        /// <summary>
        /// Removes element from sequence end (cvSeqPop).
        /// </summary>
        /// <returns>removed element</returns>
#endif
        public virtual T Pop()
        {
            T result;
            Cv.SeqPop<T>(this, out result);
            return result;
        }
        #endregion
        #region PopFront
#if LANG_JP
        /// <summary>
        /// シーケンスの先頭から一つの要素を削除する (cvSeqPopFront).
        /// </summary>
        /// <returns>削除した要素をコピーする出力先</returns>
#else
        /// <summary>
        /// Removes element from sequence beginning (cvSeqPopFront).
        /// </summary>
        /// <returns>removed element</returns>
#endif
        public virtual T PopFront()
        {
            return base.PopFront<T>();
        }
        #endregion
        #region PopMulti
#if LANG_JP
        /// <summary>
        /// 複数の要素をシーケンスのどちらかの端（先頭か末尾）から削除する (cvSeqPopMulti).
        /// </summary>
        /// <param name="count">削除される要素数．</param>
        /// <param name="in_front">変更するシーケンスの端を指定するフラグ．</param>
#else
        /// <summary>
        /// Removes several elements from the either end of sequence (cvSeqPopMulti).
        /// </summary>
        /// <param name="count">Number of elements to pop. </param>
        /// <param name="in_front">The flags specifying the modified sequence end</param>
#endif
        public T[] PopMulti(int count, InsertPosition in_front) 
        {
            return base.PopMulti<T>(count, in_front);
        }
        #endregion
        #region Push
#if LANG_JP
        /// <summary>
        /// シーケンスの末尾に要素を追加し，割り付けられた要素を返す (cvSeqPush)．
        /// 入力の element が null の場合，この関数は単に要素一つ分の領域を確保する．
        /// </summary>
        /// <param name="element">追加される要素. プリミティブ型か、OpenCVの構造体(CvPointなど).</param>
        /// <returns>追加された要素</returns>
#else
        /// <summary>
        /// Adds element to sequence end (cvSeqPush)．
        /// </summary>
        /// <param name="element">Added element. </param>
        /// <returns>pointer to the allocated element. </returns>
#endif
        public virtual T Push(T element)
        {
            return Cv.SeqPush<T>(this, element);
        }
        #endregion
        #region PushFront
#if LANG_JP
        /// <summary>
        /// シーケンスの先頭に要素を追加し，割り付けられた要素へのポインタを返す (cvSeqPushFront).
        /// 入力の element が null の場合，この関数は単に要素一つ分の領域を確保する．
        /// </summary>
        /// <param name="element">追加される要素. プリミティブ型か、OpenCVの構造体(CvPointなど).</param>
        /// <returns>追加された要素</returns>
#else
        /// <summary>
        /// Adds element to sequence beginning (cvSeqPushFront).
        /// </summary>
        /// <param name="element">Added element. </param>
        /// <returns>pointer to the added element</returns>
#endif
        public virtual T PushFront(T element)
        {
            return Cv.SeqPushFront<T>(this, element);
        }
        #endregion
        #region PushMulti
#if LANG_JP
        /// <summary>
        /// 複数の要素をシーケンスのどちらかの端（先頭か末尾）に追加する (cvSeqPushMulti).
        /// </summary>
        /// <param name="elements">追加される要素群．</param>
        /// <param name="in_front">変更するシーケンスの端を指定するフラグ．</param>
#else
        /// <summary>
        /// Pushes several elements to the either end of sequence (cvSeqPushMulti).
        /// </summary>
        /// <param name="elements">Added elements. </param>
        /// <param name="in_front">The flags specifying the modified sequence end</param>
#endif
        public void PushMulti(T[] elements, InsertPosition in_front) 
        {
            Cv.SeqPushMulti<T>(this, elements, in_front);
        }
        #endregion
        #region Search
#if LANG_JP
        /// <summary>
        /// シーケンスの中から要素を検索する (cvSeqSearch).
        /// </summary>
        /// <param name="elem">検索する要素</param>
        /// <param name="func">要素の関係に応じて，負・0・正の値を返す比較関数</param>
        /// <param name="is_sorted">シーケンスがソート済みか否かを示すフラグ</param>
        /// <param name="elem_idx">出力パラメータ．見つかった要素のインデックス．</param>
#else
        /// <summary>
        /// Searches element in sequence (cvSeqSearch).
        /// </summary>
        /// <param name="elem">The element to look for </param>
        /// <param name="func">The comparison function that returns negative, zero or positive value depending on the elements relation</param>
        /// <param name="is_sorted">Whether the sequence is sorted or not. </param>
        /// <param name="elem_idx">Output parameter; index of the found element. </param>
        /// <returns></returns>
#endif
        public virtual T Search(T elem, CvCmpFunc<T> func, bool is_sorted, out int elem_idx)
        {
            return Cv.SeqSearch<T>(this, elem, func, is_sorted, out elem_idx);
        }
        #endregion
        #region Slice
#if LANG_JP
        /// <summary>
        /// シーケンススライスのための別のヘッダを作成する (cvSeqSlice).
        /// </summary>
        /// <param name="slice">抽出するシーケンスの一部分</param>
        /// <returns></returns>
#else
        /// <summary>
        /// Makes separate header for the sequence slice (cvSeqSlice).
        /// </summary>
        /// <param name="slice">The part of the sequence to extract. </param>
        /// <returns></returns>
#endif
        new public CvSeq<T> Slice(CvSlice slice)
        {
            return Cv.SeqSlice(this, slice);
        }
#if LANG_JP
        /// <summary>
        /// シーケンススライスのための別のヘッダを作成する (cvSeqSlice).
        /// </summary>
        /// <param name="slice">抽出するシーケンスの一部分</param>
        /// <param name="storage">新しいシーケンスヘッダとコピーされたデータ（もしデータがあれば）を保存する出力ストレージ． nullの場合，この関数は入力シーケンスに含まれるストレージを使用する</param>
        /// <returns></returns>
#else
        /// <summary>
        /// Makes separate header for the sequence slice (cvSeqSlice).
        /// </summary>
        /// <param name="slice">The part of the sequence to extract. </param>
        /// <param name="storage">The destination storage to keep the new sequence header and the copied data if any. If it is null, the function uses the storage containing the input sequence. </param>
        /// <returns></returns>
#endif
        new public CvSeq<T> Slice(CvSlice slice, CvMemStorage storage)
        {
            return Cv.SeqSlice(this, slice, storage);
        }
#if LANG_JP
        /// <summary>
        /// シーケンススライスのための別のヘッダを作成する (cvSeqSlice).
        /// </summary>
        /// <param name="slice">抽出するシーケンスの一部分</param>
        /// <param name="storage">新しいシーケンスヘッダとコピーされたデータ（もしデータがあれば）を保存する出力ストレージ． nullの場合，この関数は入力シーケンスに含まれるストレージを使用する</param>
        /// <param name="copy_data">抽出されたスライスの要素をコピーするかしないかを示すフラグ</param>
        /// <returns></returns>
#else
        /// <summary>
        /// Makes separate header for the sequence slice (cvSeqSlice).
        /// </summary>
        /// <param name="slice">The part of the sequence to extract. </param>
        /// <param name="storage">The destination storage to keep the new sequence header and the copied data if any. If it is null, the function uses the storage containing the input sequence. </param>
        /// <param name="copy_data">The flag that indicates whether to copy the elements of the extracted slice (copy_data=true) or not (copy_data=false) </param>
        /// <returns></returns>
#endif
        new public CvSeq<T> Slice(CvSlice slice, CvMemStorage storage, bool copy_data)
        {
            return Cv.SeqSlice(this, slice, storage, copy_data);
        }
        #endregion
        #region Sort
#if LANG_JP
        /// <summary>
        /// シーケンスの要素を，指定した比較関数を用いてソートする (cvSeqSort).
        /// </summary>
        /// <param name="func">要素の関係に応じて，負・0・正の値を返す比較関数</param>
#else
        /// <summary>
        /// Sorts sequence element using the specified comparison function (cvSeqSort).
        /// </summary>
        /// <param name="func">The comparison function that returns negative, zero or positive value depending on the elements relation (see the above declaration and the example below) - similar function is used by qsort from C runtime except that in the latter userdata is not used </param>
#endif
        public virtual void Sort(CvCmpFunc<T> func)
        {
            Cv.SeqSort<T>(this, func);
        }
        #endregion
        #region StartRead
#if LANG_JP
        /// <summary>
        /// シーケンスからの連続読み出し処理を初期化する (cvStartReadSeq).
        /// </summary>
        /// <param name="reader">リーダ（reader）の状態．この関数で初期化される．</param>
#else
        /// <summary>
        /// Initializes process of sequential reading from sequence (cvStartReadSeq).
        /// </summary>
        /// <param name="reader">Reader state; initialized by the function. </param>
#endif
        public virtual void StartRead(CvSeqReader<T> reader)
        {
            Cv.StartReadSeq(this, reader);
        }
#if LANG_JP
        /// <summary>
        /// シーケンスからの連続読み出し処理を初期化する (cvStartReadSeq).
        /// </summary>
        /// <param name="reader">リーダ（reader）の状態．この関数で初期化される．</param>
        /// <param name="reverse">シーケンス走査方向の指定．reverse が false の場合，リーダは先頭のシーケンス要素に位置する．それ以外は最後の要素に位置する．</param>
#else
        /// <summary>
        /// Initializes process of sequential reading from sequence (cvStartReadSeq).
        /// </summary>
        /// <param name="reader">Reader state; initialized by the function. </param>
        /// <param name="reverse">Determines the direction of the sequence traversal. If reverse is false, the reader is positioned at the first sequence element, otherwise it is positioned at the last element. </param>
#endif
        public virtual void StartRead(CvSeqReader<T> reader, Boolean reverse)
        {
            Cv.StartReadSeq(this, reader, reverse);
        }
        #endregion
        #region ToArray
#if LANG_JP
        /// <summary>
        /// シーケンスをメモリ内の連続した一つのブロックにコピーする (cvCvtSeqToArray).
        /// </summary>
        /// <returns>出力される配列. outされる引数 element と同じ値.</returns>
#else
        /// <summary>
        /// Copies sequence to one continuous block of memory (cvCvtSeqToArray).
        /// </summary>
        /// <returns></returns>
#endif
        public T[] ToArray()
        {
            T[] elements;
            return Cv.CvtSeqToArray<T>(this, out elements);
        }
#if LANG_JP
        /// <summary>
        /// シーケンスをメモリ内の連続した一つのブロックにコピーする (cvCvtSeqToArray).
        /// </summary>
        /// <param name="slice">配列へコピーするシーケンス内の部分</param>
        /// <returns>出力される配列. outされる引数 element と同じ値.</returns>
#else
        /// <summary>
        /// Copies sequence to one continuous block of memory (cvCvtSeqToArray).
        /// </summary>
        /// <param name="slice">The sequence part to copy to the array. </param>
        /// <returns></returns>
#endif
        public T[] ToArray(CvSlice slice)
        {
            T[] elements;
            return Cv.CvtSeqToArray<T>(this, out elements, slice);
        }
        #endregion

        #region ApproxPoly
#if LANG_JP
        /// <summary>
        /// 指定した精度でポリラインを近似する
        /// </summary>
        /// <param name="header_size">近似されたポリラインのヘッダサイズ．</param>
        /// <param name="storage">近似された輪郭の保存場所．nullの場合，入力シーケンスのストレージが使われる． </param>
        /// <param name="method">近似方法</param>
        /// <param name="parameter">近似方法に依存するパラメータ．CV_POLY_APPROX_DPの場合には，要求する近似精度である．</param>
        /// <returns>単一もしくは複数の近似曲線を計算した結果</returns>
#else
        /// <summary>
        /// Approximates polygonal curve(s) with desired precision.
        /// </summary>
        /// <param name="header_size">Header size of approximated curve[s]. </param>
        /// <param name="storage">Container for approximated contours. If it is null, the input sequences' storage is used. </param>
        /// <param name="method">Approximation method; only ApproxPolyMethod.DP is supported, that corresponds to Douglas-Peucker algorithm. </param>
        /// <param name="parameter">Method-specific parameter; in case of CV_POLY_APPROX_DP it is a desired approximation accuracy. </param>
        /// <returns></returns>
#endif
        public CvSeq<CvPoint> ApproxPoly(int header_size, CvMemStorage storage, ApproxPolyMethod method, double parameter)
        {
            if (typeof(T) == typeof(CvPoint))
            {
                return Cv.ApproxPoly((CvSeq<CvPoint>)(object)this, header_size, storage, method, parameter);
            }
            else
            {
                throw new InvalidOperationException("This instance must be CvSeq<CvPoint>");
            }
        }
#if LANG_JP
        /// <summary>
        /// 指定した精度でポリラインを近似する
        /// </summary>
        /// <param name="header_size">近似されたポリラインのヘッダサイズ．</param>
        /// <param name="storage">近似された輪郭の保存場所．nullの場合，入力シーケンスのストレージが使われる． </param>
        /// <param name="method">近似方法</param>
        /// <param name="parameter">近似方法に依存するパラメータ．CV_POLY_APPROX_DPの場合には，要求する近似精度である．</param>
        /// <param name="parameter2">src_seqが点の配列（CvMat）の場合， このパラメータは輪郭が閉じている（parameter2=true）か，開いているか(parameter2=false)を指定する．</param>
        /// <returns>単一もしくは複数の近似曲線を計算した結果</returns>
#else
        /// <summary>
        /// Approximates polygonal curve(s) with desired precision.
        /// </summary>
        /// <param name="header_size">Header size of approximated curve[s]. </param>
        /// <param name="storage">Container for approximated contours. If it is null, the input sequences' storage is used. </param>
        /// <param name="method">Approximation method; only ApproxPolyMethod.DP is supported, that corresponds to Douglas-Peucker algorithm. </param>
        /// <param name="parameter">Method-specific parameter; in case of CV_POLY_APPROX_DP it is a desired approximation accuracy. </param>
        /// <param name="parameter2">If case if src_seq is sequence it means whether the single sequence should be approximated 
        /// or all sequences on the same level or below src_seq (see cvFindContours for description of hierarchical contour structures). 
        /// And if src_seq is array (CvMat*) of points, the parameter specifies whether the curve is closed (parameter2==true) or not (parameter2==false). </param>
        /// <returns></returns>
#endif
        public CvSeq<CvPoint> ApproxPoly(int header_size, CvMemStorage storage, ApproxPolyMethod method, double parameter, bool parameter2)
        {
            if (typeof(T) == typeof(CvPoint))
            {
                return Cv.ApproxPoly((CvSeq<CvPoint>)(object)this, header_size, storage, method, parameter, parameter2);
            }
            else
            {
                throw new InvalidOperationException("This instance must be CvSeq<CvPoint>");
            }
        }
        #endregion
        #endregion

        #region IEnumerable
        /// <summary>
        /// Returns an enumerator that iterates through the collection.
        /// </summary>
        /// <returns>A IEnumerator&lt;CvSeq&gt; that can be used to iterate through the collection.</returns>
        public IEnumerator<T?> GetEnumerator()
        {
            for (int i = 0; i < Total; i++)
            {
                yield return Cv.GetSeqElem<T>(this, i);
            }
        }
        /// <summary>
        /// Returns an enumerator that iterates through a collection.
        /// </summary>
        /// <returns>An System.Collections.IEnumerator object that can be used to iterate through the collection.</returns>
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        #endregion
    }
}
