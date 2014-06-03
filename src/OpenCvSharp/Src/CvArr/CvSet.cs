using System;
using System.Runtime.InteropServices;

namespace OpenCvSharp
{
#if LANG_JP
    /// <summary>
    /// ノードの集合
    /// </summary>
#else
    /// <summary>
    /// Collection of nodes
    /// </summary>
#endif
    public class CvSet : CvSeq
    {
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
        protected CvSet()
        {
            ptr = IntPtr.Zero;
        }
#if LANG_JP
        /// <summary>
        /// 空のセットを生成する
        /// </summary>
        /// <param name="setFlags">生成するセットのタイプ． </param>
        /// <param name="headerSize">セットのヘッダのサイズ（sizeof(CvSet)以上）． </param>
        /// <param name="elemSize">セットの要素のサイズ（CvSetElem 以上）． </param>
        /// <param name="storage">セットのためのコンテナ． </param>
#else
        /// <summary>
        /// Creates empty set
        /// </summary>
        /// <param name="setFlags">Type of the created set. </param>
        /// <param name="headerSize">Set header size; may not be less than sizeof(CvSet). </param>
        /// <param name="elemSize">Set element size; may not be less than CvSetElem. </param>
        /// <param name="storage">Container for the set. </param>
#endif
        public CvSet(SeqType setFlags, int headerSize, int elemSize, CvMemStorage storage)
        {
            if (storage == null)
                throw new ArgumentNullException();
            
            IntPtr p = NativeMethods.cvCreateSet(setFlags, headerSize, elemSize, storage.CvPtr);
            Initialize(p);
            holdingStorage = storage;
        }

#if LANG_JP
        /// <summary>
        /// ポインタから初期化
        /// </summary>
        /// <param name="ptr">struct CvSet*</param>
#else
        /// <summary>
        /// Initializes from native pointer
        /// </summary>
        /// <param name="ptr">struct CvSet*</param>
#endif
        public CvSet(IntPtr ptr)
        {
            Initialize(ptr);
        }
        #endregion

        #region Properties
        /// <summary>
        /// sizeof(CvSet)
        /// </summary>
        new public static readonly int SizeOf = Marshal.SizeOf(typeof(WCvSet));

#if LANG_JP
        /// <summary>
		/// 空きノードのリスト 
        /// </summary>
#else
        /// <summary>
        /// list of free nodes
        /// </summary>
#endif
        public CvSetElem FreeElems
        {
            get 
            {
                unsafe
                {
                    IntPtr p = new IntPtr(((WCvSet*)ptr)->free_elems);

                    if (p != IntPtr.Zero)
                        return new CvSetElem(p);
                    else
                        return null;
                }
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
        public int ActiveCount
        {
            get
            {
                unsafe
                {
                    return ((WCvSet*)ptr)->active_count;
                }
            }
        }
        #endregion

        #region Methods
        #region ClearSet
#if LANG_JP
        /// <summary>
        /// セットをクリアする
        /// </summary>
        /// <returns></returns>
#else
        /// <summary>
        /// Clears set
        /// </summary>
        /// <returns>The function cvClearSet removes all elements from set. It has O(1) time complexity.</returns>
#endif
        public void ClearSet()
        {
            Cv.ClearSet(this);
        }
        #endregion
        #region GetSetElem
#if LANG_JP
        /// <summary>
        /// インデックスによってセットの要素を検索する
        /// </summary>
        /// <param name="index">シーケンスの中のセットの要素のインデックス．</param>
        /// <returns>見つけた要素への参照</returns>
#else
        /// <summary>
        /// Finds set element by its index
        /// </summary>
        /// <param name="index">Index of the set element within a sequence. </param>
        /// <returns>the pointer to it or null if the index is invalid or the corresponding node is free.</returns>
#endif
        public CvSetElem GetSetElem(int index)
        {
            return Cv.GetSetElem(this, index);
        }
        #endregion
        #region SetAdd
#if LANG_JP
        /// <summary>
        /// セットに新しいノード（要素）を追加する
        /// </summary>
        /// <returns>ノードへのインデックス</returns>
#else
        /// <summary>
        /// Occupies a node in the set
        /// </summary>
        /// <returns>the index to the node</returns>
#endif
        public int SetAdd()
        {
            return Cv.SetAdd(this);
        }
#if LANG_JP
        /// <summary>
        /// セットに新しいノード（要素）を追加する
        /// </summary>
        /// <param name="elem">挿入する要素． nullでない場合，新たに確保したノードにデータをコピーする （コピーした後，先頭の整数フィールドの最上位ビットはクリアされる）． </param>
        /// <returns>ノードへのインデックス</returns>
#else
        /// <summary>
        /// Occupies a node in the set
        /// </summary>
        /// <param name="elem">Optional input argument, inserted element. If not null, the function copies the data to the allocated node (The MSB of the first integer field is cleared after copying). </param>
        /// <returns>the index to the node</returns>
#endif
        public int SetAdd(CvSetElem elem)
        {
            return Cv.SetAdd(this, elem);
        }
#if LANG_JP
        /// <summary>
        /// セットに新しいノード（要素）を追加する
        /// </summary>
        /// <param name="elem">挿入する要素． nullでない場合，新たに確保したノードにデータをコピーする （コピーした後，先頭の整数フィールドの最上位ビットはクリアされる）． </param>
        /// <param name="insertedElem">割り当てられた要素への参照</param>
        /// <returns>ノードへのインデックス</returns>
#else
        /// <summary>
        /// Occupies a node in the set
        /// </summary>
        /// <param name="elem">Optional input argument, inserted element. If not null, the function copies the data to the allocated node (The MSB of the first integer field is cleared after copying). </param>
        /// <param name="insertedElem">Optional output argument; the pointer to the allocated cell. </param>
        /// <returns>the index to the node</returns>
#endif
        public int SetAdd(CvSetElem elem, out CvSetElem insertedElem)
        {
            return Cv.SetAdd(this, elem, out insertedElem);
        }
        #endregion
        #region SetNew
#if LANG_JP
        /// <summary>
        /// セットに要素を加える（高速版）
        /// </summary>
        /// <returns>ノードへのポインタ</returns>
#else
        /// <summary>
        /// Adds element to set (fast variant)
        /// </summary>
        /// <returns>pointer to a new node</returns>
#endif
        public CvSetElem SetNew()
        {
            return Cv.SetNew(this);
        }
        #endregion
        #region SetRemove
#if LANG_JP
        /// <summary>
        /// セットから要素を削除する
        /// </summary>
        /// <param name="index">削除する要素のインデックス．</param>
#else
        /// <summary>
        /// Removes element from set
        /// </summary>
        /// <param name="index">Index of the removed element. </param>
#endif
        public void SetRemove(int index)
        {
            Cv.SetRemove(this, index);
        }
        #endregion
        #region SetRemoveByPtr
#if LANG_JP
        /// <summary>
        /// ポインタで指定したセットの要素を削除する
        /// </summary>
        /// <param name="elem">削除される要素．</param>
#else
        /// <summary>
        /// Removes set element given its pointer
        /// </summary>
        /// <param name="elem">Removed element. </param>
#endif
        public void SetRemoveByPtr(IntPtr elem)
        {
            Cv.SetRemoveByPtr(this, elem);
        }
        #endregion
        #endregion
    }
}
