using System;
using System.Runtime.InteropServices;

// ReSharper disable InconsistentNaming

namespace OpenCvSharp
{
#if LANG_JP
    /// <summary>
    /// 拡張可能な要素のシーケンス
    /// </summary>
#else
    /// <summary>
    /// Growable sequence of elements
    /// </summary>
#endif
    public class CvSeq : CvTreeNode<CvSeq>, ICloneable
    {
        /// <summary>
        /// to keep alive storage
        /// </summary>
        protected CvMemStorage holdingStorage;

        #region Init and Disposal
#if LANG_JP
        /// <summary>
        /// 既定の初期化
        /// </summary>
#else
        /// <summary>
        /// Default constructor
        /// </summary>
#endif
        protected CvSeq()
        {
            ptr = IntPtr.Zero;
        }
#if LANG_JP
        /// <summary>
        /// シーケンスを生成する. header_size=sizeof(CvSeq)
        /// </summary>
        /// <param name="seqFlags">生成されたシーケンスのフラグ．生成されたシーケンスが，特定のシーケンスタイプを引数にとるような関数に一切渡されない場合は，この値に0を指定してもかまわない．そうでない場合は，定義済みのシーケンスタイプのリストから適切なタイプが選択されなければならない．</param>
        /// <param name="elemSize">シーケンスの要素サイズ（バイト単位）．サイズはシーケンスタイプと合致しなければならない．例えば，点群のシーケンスを作成する場合，要素タイプにCV_SEQ_ELTYPE_POINTを指定し，パラメータ elem_size は sizeof(CvPoint) と等しくなければならない．</param>
        /// <param name="storage">シーケンスが保存される場所</param>
        /// <returns></returns>
#else
        /// <summary>
        /// Creates sequence. header_size=sizeof(CvSeq)
        /// </summary>
        /// <param name="seqFlags">Flags of the created sequence. If the sequence is not passed to any function working with a specific type of sequences, the sequence value may be set to 0, otherwise the appropriate type must be selected from the list of predefined sequence types. </param>
        /// <param name="elemSize">Size of the sequence elements in bytes. The size must be consistent with the sequence type. For example, for a sequence of points to be created, the element type CV_SEQ_ELTYPE_POINT should be specified and the parameter elem_size must be equal to sizeof(CvPoint). </param>
        /// <param name="storage">Sequence location. </param>
        /// <returns></returns>
#endif
        public CvSeq(SeqType seqFlags, int elemSize, CvMemStorage storage)
            : this(seqFlags, SizeOf, elemSize, storage)
        {
        }
#if LANG_JP
        /// <summary>
        /// シーケンスを生成する
        /// </summary>
        /// <param name="seqFlags">生成されたシーケンスのフラグ．生成されたシーケンスが，特定のシーケンスタイプを引数にとるような関数に一切渡されない場合は，この値に0を指定してもかまわない．そうでない場合は，定義済みのシーケンスタイプのリストから適切なタイプが選択されなければならない．</param>
        /// <param name="headerSize">シーケンスのヘッダサイズ．sizeof(CvSeq)以上でなければならない． また，特別なタイプかその拡張が指示されている場合，そのタイプは基本タイプのヘッダと合致していなければならない．</param>
        /// <param name="elemSize">シーケンスの要素サイズ（バイト単位）．サイズはシーケンスタイプと合致しなければならない．例えば，点群のシーケンスを作成する場合，要素タイプにCV_SEQ_ELTYPE_POINTを指定し，パラメータ elem_size は sizeof(CvPoint) と等しくなければならない．</param>
        /// <param name="storage">シーケンスが保存される場所</param>
#else
        /// <summary>
        /// Creates sequence
        /// </summary>
        /// <param name="seqFlags">Flags of the created sequence. If the sequence is not passed to any function working with a specific type of sequences, the sequence value may be set to 0, otherwise the appropriate type must be selected from the list of predefined sequence types. </param>
        /// <param name="headerSize">Size of the sequence header; must be greater or equal to sizeof(CvSeq). If a specific type or its extension is indicated, this type must fit the base type header. </param>
        /// <param name="elemSize">Size of the sequence elements in bytes. The size must be consistent with the sequence type. For example, for a sequence of points to be created, the element type CV_SEQ_ELTYPE_POINT should be specified and the parameter elem_size must be equal to sizeof(CvPoint). </param>
        /// <param name="storage">Sequence location. </param>
#endif
        public CvSeq(SeqType seqFlags, int headerSize, int elemSize, CvMemStorage storage)
        {
            if (storage == null)
                throw new ArgumentNullException();
            
            IntPtr p = NativeMethods.cvCreateSeq(seqFlags, headerSize, elemSize, storage.CvPtr);
            Initialize(p);
            holdingStorage = storage;
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
        {
            Initialize(ptr);
        }
        #endregion

        #region Properties
        /// <summary>
        /// sizeof(CvSeq)
        /// </summary>
        new public static readonly int SizeOf = Marshal.SizeOf(typeof(WCvSeq));


#if LANG_JP
		/// <summary>
		/// 一つ前のシーケンスへのポインタ
		/// </summary>
#else
        /// <summary>
        /// previous sequence
        /// </summary>
#endif
        public override CvSeq HPrev
        {
            get
            {
                unsafe
                {
                    IntPtr p = new IntPtr(((WCvSeq*)ptr)->h_prev);

                    if (p != IntPtr.Zero)
                        return new CvSeq(p);
                    return null;
                }
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
        public override CvSeq HNext
        {
            get
            {
                unsafe
                {
                    IntPtr p = new IntPtr(((WCvSeq*)ptr)->h_next);

                    if (p != IntPtr.Zero)
                        return new CvSeq(p);
                    return null;
                }
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
        public override CvSeq VPrev
        {
            get
            {
                unsafe
                {
                    IntPtr p = new IntPtr(((WCvSeq*)ptr)->v_prev);

                    if (p != IntPtr.Zero)
                        return new CvSeq(p);
                    else
                        return null;
                }
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
        public override CvSeq VNext
        {
            get
            {
                unsafe
                {
                    IntPtr p = new IntPtr(((WCvSeq*)ptr)->v_next);

                    if (p != IntPtr.Zero)
                        return new CvSeq(p);
                    else
                        return null;
                }
            }
        }
#if LANG_JP
		/// <summary>
		/// 要素の総数
		/// </summary>
#else
        /// <summary>
        /// total number of elements
        /// </summary>
#endif
        public int Total
        {
            get
            {
                unsafe
                {
                    return ((WCvSeq*)ptr)->total;
                }
            }
        }
#if LANG_JP
		/// <summary>
		/// シーケンス要素のサイズ（バイト単位）
		/// </summary>
#else
        /// <summary>
        /// size of sequence element in bytes
        /// </summary>
#endif
        public int ElemSize
        {
            get
            {
                unsafe
                {
                    return ((WCvSeq*)ptr)->elem_size;
                }
            }
        }
#if LANG_JP
		/// <summary>
		/// 最新のブロックの最大値
		/// </summary>
#else
        /// <summary>
        /// maximal bound of the last block
        /// </summary>
#endif
        public IntPtr BlockMax
        {
            get
            {
                unsafe
                {
                    return new IntPtr(((WCvSeq*)ptr)->block_max);
                }
            }
        }
#if LANG_JP
		/// <summary>
		/// 現在の書き込みポインタ
		/// </summary>
#else
        /// <summary>
        /// current write pointer
        /// </summary>
#endif
        public IntPtr Ptr
        {
            get
            {
                unsafe
                {
                    return new IntPtr(((WCvSeq*)ptr)->ptr);
                }
            }
        }
#if LANG_JP
		/// <summary>
		/// シーケンスを拡張させる際に，領域確保する要素数（シーケンスの粒度）
		/// </summary>
#else
        /// <summary>
        /// how many elements allocated when the sequence grows (sequence granularity)
        /// </summary>
#endif
        public int DeltaElems
        {
            get
            {
                unsafe
                {
                    return ((WCvSeq*)ptr)->delta_elems;
                }
            }
        }
#if LANG_JP
		/// <summary>
		/// seqが保存される領域
		/// </summary>
#else
        /// <summary>
        /// where the seq is stored
        /// </summary>
#endif
        public CvMemStorage Storage
        {
            get
            {
                unsafe
                {
                    IntPtr p = new IntPtr(((WCvSeq*)ptr)->storage);

                    if (p != IntPtr.Zero)
                        return new CvMemStorage(p, false);
                    else
                        return null;
                }
            }
        }
#if LANG_JP
		/// <summary>
		/// 空きブロックリスト
		/// </summary>
#else
        /// <summary>
        /// free blocks list
        /// </summary>
#endif
        public CvSeqBlock FreeBlocks
        {
            get
            {
                unsafe
                {
                    IntPtr p = new IntPtr(((WCvSeq*)ptr)->storage);

                    if (p != IntPtr.Zero)
                        return new CvSeqBlock(p);
                    else
                        return null;
                }
            }
        }
#if LANG_JP
		/// <summary>
		/// 先頭シーケンスブロックへのポインタ
		/// </summary>
#else
        /// <summary>
        /// pointer to the first sequence block
        /// </summary>
#endif
        public CvSeqBlock First
        {
            get
            {
                unsafe
                {
                    IntPtr p = new IntPtr(((WCvSeq*)ptr)->first);

                    if (p != IntPtr.Zero)
                        return new CvSeqBlock(p);
                    else
                        return null;
                }
            }
        }
        #endregion

        #region Methods
        #region CalcPGH
#if LANG_JP
        /// <summary>
        /// 輪郭の pair-wise geometrical histogram を求める
        /// </summary>
        /// <param name="hist">求められたヒストグラム．必ず2次元になる．</param>
#else
        /// <summary>
        /// Calculates pair-wise geometrical histogram for contour
        /// </summary>
        /// <param name="hist">Calculated histogram; must be two-dimensional. </param>
#endif
        public void CalcPGH(CvHistogram hist)
        {
            Cv.CalcPGH(this, hist);
        }
        #endregion
        #region ClearSeq
#if LANG_JP
        /// <summary>
        /// シーケンスをクリアする
        /// </summary>
#else
        /// <summary>
        /// Clears sequence
        /// </summary>
#endif
        public void ClearSeq()
        {
            Cv.ClearSeq(this);
        }
        #endregion
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
        public virtual CvSeq Clone()
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
        public virtual CvSeq Clone(CvMemStorage storage)
        {
            return Cv.CloneSeq(this, storage);
        }
        /// <summary>
        /// ICloneable.Clone
        /// </summary>
        /// <returns></returns>
        object ICloneable.Clone()
        {
            return Clone();
        }
        #endregion
        #region ContoursMoments
#if LANG_JP
        /// <summary>
        /// Alias for Moments with CvSeq contours
        /// </summary>
        /// <returns></returns>
#else
        /// <summary>
        /// Alias for Moments with CvSeq contours
        /// </summary>
        /// <returns></returns>
#endif
        public CvMoments ContoursMoments()
        {
            CvMoments moments;
            Cv.ContoursMoments(this, out moments);
            return moments;
        }
        #endregion
        #region CreateContourTree
#if LANG_JP
        /// <summary>
        /// 輪郭の階層的表現を生成する
        /// </summary>
        /// <param name="storage">結果のツリーの出力先</param>
        /// <param name="threshold">近似精度</param>
        /// <returns></returns>
#else
        /// <summary>
        /// Creates hierarchical representation of contour
        /// </summary>
        /// <param name="storage">Container for output tree. </param>
        /// <param name="threshold">Approximation accuracy. </param>
        /// <returns></returns>
#endif
        public CvContourTree CreateContourTree(CvMemStorage storage, double threshold)
        {
            return Cv.CreateContourTree(this, storage, threshold);
        }
        #endregion
        #region ElemIdx
#if LANG_JP
        /// <summary>
        /// 指定されたシーケンスの要素のインデックスを返す (cvSeqElemIdx).
        /// </summary>
        /// <typeparam name="T">要素の型</typeparam>
        /// <param name="element">シーケンス要素</param>
        /// <returns>指定されたシーケンス要素のインデックス</returns>
#else
        /// <summary>
        /// Returns index of concrete sequence element (cvSeqElemIdx).
        /// </summary>
        /// <typeparam name="T">Element type</typeparam>
        /// <param name="element">the element within the sequence. </param>
        /// <returns>the index of a sequence element or a negative number if the element is not found.</returns>
#endif
        public int ElemIdx<T>(T element) where T : struct
        {
            return Cv.SeqElemIdx(this, element);
        }
#if LANG_JP
        /// <summary>
        /// 指定されたシーケンスの要素のインデックスを返す (cvSeqElemIdx).
        /// </summary>
        /// <typeparam name="T">要素の型</typeparam>
        /// <param name="element">シーケンス要素</param>
        /// <param name="block">要素を含むシーケンスブロックのアドレスがこの場所に保存される．</param>
        /// <returns>指定されたシーケンス要素のインデックス</returns>
#else
        /// <summary>
        /// Returns index of concrete sequence element (cvSeqElemIdx).
        /// </summary>
        /// <typeparam name="T">Element type</typeparam>
        /// <param name="element">the element within the sequence. </param>
        /// <param name="block">the address of the sequence block that contains the element is stored in this location. </param>
        /// <returns>the index of a sequence element or a negative number if the element is not found.</returns>
#endif
        public int ElemIdx<T>(T element, out CvSeqBlock block) where T : struct
        {
            return Cv.SeqElemIdx(this, element, out block);
        }
        #endregion
        #region GetSeqElem
#if LANG_JP
        /// <summary>
        /// 与えられたインデックスを持つ要素をシーケンスの中から求め，その要素を返す．
        /// </summary>
        /// <typeparam name="T">出力オブジェクトの型</typeparam>
        /// <param name="index">要素のインデックス. 負のインデックスの指定も可能で, 例えば，-1はシーケンスの最後の要素，-2は最後の一つ前を指す.</param>
        /// <returns>与えられたインデックスを持つ要素．要素が見つからない場合はnull．</returns>
#else
        /// <summary>
        /// Returns pointer to sequence element by its index
        /// </summary>
        /// <typeparam name="T">Element type</typeparam>
        /// <param name="index">Index of element. </param>
        /// <returns></returns>
#endif
        public T? GetSeqElem<T>(int index) where T : struct
        {
            return Cv.GetSeqElem<T>(this, index);
        }
        #endregion
        #region Insert
#if LANG_JP
        /// <summary>
        /// シーケンスの中に要素を挿入する (cvSeqInsert).
        /// </summary>
        /// <typeparam name="T">追加する要素の型.プリミティブ型か、OpenCVの構造体(CvPointなど).</typeparam>
        /// <param name="beforeIndex">要素が挿入されるインデックス（このインデックスの前に挿入される）</param>
        /// <param name="element">追加される要素. プリミティブ型か、OpenCVの構造体(CvPointなど).</param>
        /// <returns>追加された要素</returns>
#else
        /// <summary>
        /// Inserts element in sequence middle (cvSeqInsert).
        /// </summary>
        /// <typeparam name="T">Element type</typeparam>
        /// <param name="beforeIndex">Index before which the element is inserted. Inserting before 0 (the minimal allowed value of the parameter) is equal to cvSeqPushFront and inserting before seq->total (the maximal allowed value of the parameter) is equal to cvSeqPush. </param>
        /// <param name="element">Inserted element. </param>
        /// <returns>Inserted element. </returns>
#endif
        public virtual T Insert<T>(int beforeIndex, T element) where T : struct
        {
            return Cv.SeqInsert(this, beforeIndex, element);
        }
        #endregion
        #region InsertSlice
#if LANG_JP
        /// <summary>
        /// シーケンス内に配列を挿入する (cvSeqInsertSlice).
        /// </summary>
        /// <param name="beforeIndex">配列が挿入される場所へのインデックス（インデックスの前に挿入される）．</param>
        /// <param name="fromArr">追加される要素の配列．</param>
#else
        /// <summary>
        /// Inserts array in the middle of sequence (cvSeqInsertSlice).
        /// </summary>
        /// <param name="beforeIndex">The part of the sequence to remove. </param>
        /// <param name="fromArr">The array to take elements from. </param>
#endif
        public virtual void InsertSlice(int beforeIndex, CvArr fromArr)
        {
            Cv.SeqInsertSlice(this, beforeIndex, fromArr);
        }
        #endregion
        #region Invert
#if LANG_JP
        /// <summary>
        /// シーケンス要素の順序を反転させる (cvSeqInvert).
        /// </summary>
#else
        /// <summary>
        /// Reverses the order of sequence elements (cvSeqInvert).
        /// </summary>
#endif
        public void Invert()
        {
            Cv.SeqInvert(this);
        }
        #endregion
        #region Remove
#if LANG_JP
        /// <summary>
        /// 与えられたインデックスをもつ要素を削除する (cvSeqRemove).
        /// </summary>
        /// <param name="index">削除される要素のインデックス</param>
#else
        /// <summary>
        /// Removes element from sequence middle (cvSeqRemove).
        /// </summary>
        /// <param name="index">Index of removed element. </param>
#endif
        public virtual void Remove(int index)
        {
            Cv.SeqRemove(this, index);
        }
        #endregion
        #region RemoveSlice
#if LANG_JP
        /// <summary>
        /// シーケンススライスを削除する (cvSeqRemoveSlice).
        /// </summary>
        /// <param name="slice">削除するシーケンスの一部分． </param>
#else
        /// <summary>
        /// Removes sequence slice (cvSeqRemoveSlice).
        /// </summary>
        /// <param name="slice">The part of the sequence to remove. </param>
#endif
        public void RemoveSlice(CvSlice slice)
        {
            Cv.SeqRemoveSlice(this, slice);
        }
        #endregion
        #region Partition
#if LANG_JP
        /// <summary>
        /// データシーケンスを同値類（同じクラスに属すると定義されたデータ群）に分割する
        /// </summary>
        /// <param name="storage">同値類として分割されたシーケンスの保存領域．nullの場合は，seq->storage を使用する．</param>
        /// <param name="labels">出力パラメータ．入力シーケンスの各要素に割り振られた（分割結果を表す）0から始まるラベルシーケンスへのポインタのポインタ．</param>
        /// <param name="isEqual">2つのシーケンス要素が同じクラスである場合，関係関数は 0以外を返す． そうでなければ0を返す．分割アルゴリズムは，同値基準として関係関数の推移閉包を用いる．</param>
        /// <returns></returns>
#else
        /// <summary>
        /// Splits sequence into equivalence classes
        /// </summary>
        /// <param name="storage">The storage to store the sequence of equivalence classes. If it is null, the function uses seq->storage for output labels. </param>
        /// <param name="labels">Output parameter. Double pointer to the sequence of 0-based labels of input sequence elements. </param>
        /// <param name="isEqual">The relation function that should return non-zero if the two particular sequence elements are from the same class, and zero otherwise. The partitioning algorithm uses transitive closure of the relation function as equivalence criteria. </param>
        /// <returns></returns>
#endif
        public int Partition(CvMemStorage storage, out CvSeq labels, CvCmpFunc isEqual)
        {
            return Cv.SeqPartition(this, storage, out labels, isEqual);
        }
        #endregion
        #region Pop
#if LANG_JP
        /// <summary>
        /// シーケンスの末尾から一つの要素を削除する (cvSeqPop).
        /// </summary>
        /// <typeparam name="T">要素の型</typeparam>
        /// <returns>削除した要素</returns>
#else
        /// <summary>
        /// Removes element from sequence end (cvSeqPop).
        /// </summary>
        /// <typeparam name="T">Element type</typeparam>
        /// <returns>removed element</returns>
#endif
        public virtual T Pop<T>() where T : struct
        {
            T result;
            Cv.SeqPop(this, out result);
            return result;
        }
        #endregion
        #region PopFront
#if LANG_JP
        /// <summary>
        /// シーケンスの先頭から一つの要素を削除する (cvSeqPopFront).
        /// </summary>
        /// <typeparam name="T">出力先オブジェクトの型</typeparam>
        /// <returns>削除した要素をコピーする出力先</returns>
#else
        /// <summary>
        /// Removes element from sequence beginning (cvSeqPopFront).
        /// </summary>
        /// <typeparam name="T">Element type</typeparam>
        /// <returns>removed element</returns>
#endif
        public virtual T PopFront<T>() where T : struct
        {
            T result;
            Cv.SeqPopFront(this, out result);
            return result;
        }
        #endregion
        #region PopMulti
#if LANG_JP
        /// <summary>
        /// 複数の要素をシーケンスのどちらかの端（先頭か末尾）から削除する (cvSeqPopMulti).
        /// </summary>
        /// <typeparam name="T">削除する要素の型</typeparam>
        /// <param name="count">削除される要素数．</param>
        /// <param name="inFront">変更するシーケンスの端を指定するフラグ．</param>
#else
        /// <summary>
        /// Removes several elements from the either end of sequence (cvSeqPopMulti).
        /// </summary>
        /// <typeparam name="T">Element type</typeparam>
        /// <param name="count">Number of elements to pop. </param>
        /// <param name="inFront">The flags specifying the modified sequence end</param>
#endif
        public T[] PopMulti<T>(int count, InsertPosition inFront) where T : struct
        {
            T[] elements;
            Cv.SeqPopMulti(this, out elements, count, inFront);
            return elements;
        }
        #endregion
        #region Push
#if LANG_JP
        /// <summary>
        /// シーケンスの末尾に要素一つ分の領域を確保する (cvSeqPush)．
        /// </summary>
        /// <returns></returns>
#else
        /// <summary>
        /// allocates a space for one more element (cvSeqPush)．
        /// </summary>
        /// <returns>pointer to the allocated element. </returns>
#endif
        public virtual IntPtr Push()
        {
            return Cv.SeqPush(this);
        }
#if LANG_JP
        /// <summary>
        /// シーケンスの末尾に要素を追加し，割り付けられた要素を返す (cvSeqPush)．
        /// 入力の element が null の場合，この関数は単に要素一つ分の領域を確保する．
        /// </summary>
        /// <typeparam name="T">要素の型</typeparam>
        /// <param name="element">追加される要素. プリミティブ型か、OpenCVの構造体(CvPointなど).</param>
        /// <returns>追加された要素</returns>
#else
        /// <summary>
        /// Adds element to sequence end (cvSeqPush)．
        /// </summary>
        /// <typeparam name="T">Element type</typeparam>
        /// <param name="element">Added element. </param>
        /// <returns>pointer to the allocated element. </returns>
#endif
        public virtual T Push<T>(T element) where T : struct
        {
            return Cv.SeqPush(this, element);
        }
        #endregion
        #region PushFront
#if LANG_JP
        /// <summary>
        /// シーケンスの先頭に要素を追加し，割り付けられた要素へのポインタを返す (cvSeqPushFront).
        /// 入力の element が null の場合，この関数は単に要素一つ分の領域を確保する．
        /// </summary>
        /// <typeparam name="T">追加する要素の型. プリミティブ型か、OpenCVの構造体(CvPointなど).</typeparam>
        /// <param name="element">追加される要素. プリミティブ型か、OpenCVの構造体(CvPointなど).</param>
        /// <returns>追加された要素</returns>
#else
        /// <summary>
        /// Adds element to sequence beginning (cvSeqPushFront).
        /// </summary>
        /// <typeparam name="T">Element type</typeparam>
        /// <param name="element">Added element. </param>
        /// <returns>pointer to the added element</returns>
#endif
        public virtual T PushFront<T>(T element) where T : struct
        {
            return Cv.SeqPushFront(this, element);
        }
        #endregion
        #region PushMulti
#if LANG_JP
        /// <summary>
        /// 複数の要素をシーケンスのどちらかの端（先頭か末尾）に追加する (cvSeqPushMulti).
        /// </summary>
        /// <typeparam name="T">追加する要素の型</typeparam>
        /// <param name="elements">追加される要素群．</param>
        /// <param name="inFront">変更するシーケンスの端を指定するフラグ．</param>
#else
        /// <summary>
        /// Pushes several elements to the either end of sequence (cvSeqPushMulti).
        /// </summary>
        /// <typeparam name="T">Element type</typeparam>
        /// <param name="elements">Added elements. </param>
        /// <param name="inFront">The flags specifying the modified sequence end</param>
#endif
        public void PushMulti<T>(T[] elements, InsertPosition inFront) where T : struct
        {
            Cv.SeqPushMulti(this, elements, inFront);
        }
        #endregion
        #region Search
#if LANG_JP
        /// <summary>
        /// シーケンスの中から要素を検索する (cvSeqSearch).
        /// </summary>
        /// <param name="elem">検索する要素</param>
        /// <param name="func">要素の関係に応じて，負・0・正の値を返す比較関数</param>
        /// <param name="isSorted">シーケンスがソート済みか否かを示すフラグ</param>
        /// <param name="elemIdx">出力パラメータ．見つかった要素のインデックス．</param>
#else
        /// <summary>
        /// Searches element in sequence (cvSeqSearch).
        /// </summary>
        /// <param name="elem">The element to look for </param>
        /// <param name="func">The comparison function that returns negative, zero or positive value depending on the elements relation</param>
        /// <param name="isSorted">Whether the sequence is sorted or not. </param>
        /// <param name="elemIdx">Output parameter; index of the found element. </param>
        /// <returns></returns>
#endif
        public virtual IntPtr Search(IntPtr elem, CvCmpFunc func, bool isSorted, out int elemIdx)
        {
            return Cv.SeqSearch(this, elem, func, isSorted, out elemIdx);
        }
        #endregion
        #region SetBlockSize
#if LANG_JP
        /// <summary>
        /// シーケンスのブロックサイズを設定する
        /// </summary>
        /// <param name="deltaElems">シーケンス要素のブロックサイズ</param>
#else
        /// <summary>
        /// Sets up sequence block size
        /// </summary>
        /// <param name="deltaElems">Desirable sequence block size in elements. </param>
#endif
        public virtual void SetBlockSize(int deltaElems)
        {
            Cv.SetSeqBlockSize(this, deltaElems);
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
        public virtual CvSeq Slice(CvSlice slice)
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
        public virtual CvSeq Slice(CvSlice slice, CvMemStorage storage)
        {
            return Cv.SeqSlice(this, slice, storage);
        }
#if LANG_JP
        /// <summary>
        /// シーケンススライスのための別のヘッダを作成する (cvSeqSlice).
        /// </summary>
        /// <param name="slice">抽出するシーケンスの一部分</param>
        /// <param name="storage">新しいシーケンスヘッダとコピーされたデータ（もしデータがあれば）を保存する出力ストレージ． nullの場合，この関数は入力シーケンスに含まれるストレージを使用する</param>
        /// <param name="copyData">抽出されたスライスの要素をコピーするかしないかを示すフラグ</param>
        /// <returns></returns>
#else
        /// <summary>
        /// Makes separate header for the sequence slice (cvSeqSlice).
        /// </summary>
        /// <param name="slice">The part of the sequence to extract. </param>
        /// <param name="storage">The destination storage to keep the new sequence header and the copied data if any. If it is null, the function uses the storage containing the input sequence. </param>
        /// <param name="copyData">The flag that indicates whether to copy the elements of the extracted slice (copy_data=true) or not (copy_data=false) </param>
        /// <returns></returns>
#endif
        public virtual CvSeq Slice(CvSlice slice, CvMemStorage storage, bool copyData)
        {
            return Cv.SeqSlice(this, slice, storage, copyData);
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
        public virtual void Sort(CvCmpFunc func)
        {
            Cv.SeqSort(this, func);
        }
        #endregion
        #region StartAppend
#if LANG_JP
        /// <summary>
        /// シーケンスへのデータ書き込み処理を初期化する (cvStartAppendToSeq).
        /// </summary>
        /// <returns>ライタ（Writer）の状態．この関数で初期化される．</returns>
#else
        /// <summary>
        /// Initializes process of writing data to sequence (cvStartAppendToSeq).
        /// </summary>
        /// <returns>Writer state; initialized by the function. </returns>
#endif
        public CvSeqWriter StartAppend()
        {
            CvSeqWriter writer;
            Cv.StartAppendToSeq(this, out writer);
            return writer;
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
        public virtual void StartRead(CvSeqReader reader)
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
        public virtual void StartRead(CvSeqReader reader, bool reverse)
        {
            Cv.StartReadSeq(this, reader, reverse);
        }
        #endregion
        #region ToArray
#if LANG_JP
        /// <summary>
        /// シーケンスをメモリ内の連続した一つのブロックにコピーする (cvCvtSeqToArray).
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns>出力される配列. outされる引数 element と同じ値.</returns>
#else
        /// <summary>
        /// Copies sequence to one continuous block of memory (cvCvtSeqToArray).
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
#endif
        public T[] ToArray<T>() where T : struct
        {
            T[] elements;
            return Cv.CvtSeqToArray(this, out elements);
        }
#if LANG_JP
        /// <summary>
        /// シーケンスをメモリ内の連続した一つのブロックにコピーする (cvCvtSeqToArray).
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="slice">配列へコピーするシーケンス内の部分</param>
        /// <returns>出力される配列. outされる引数 element と同じ値.</returns>
#else
        /// <summary>
        /// Copies sequence to one continuous block of memory (cvCvtSeqToArray).
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="slice">The sequence part to copy to the array. </param>
        /// <returns></returns>
#endif
        public T[] ToArray<T>(CvSlice slice) where T : struct
        {
            T[] elements;
            return Cv.CvtSeqToArray(this, out elements, slice);
        }
        #endregion
        #endregion
    }
}
