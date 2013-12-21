/*
 * (C) 2008-2013 Schima
 * This code is licenced under the LGPL.
 */

using System;
using System.Collections.Generic;
using System.Text;

namespace OpenCvSharp.Blob
{
	/// <summary>
    /// List of contours (chain codes type)
    /// </summary>
    public class CvContoursChainCode : CvObject, ICollection<CvContourChainCode>
    {
        #region Init and Disposal
#if LANG_JP
        /// <summary>
        /// ポインタから初期化
        /// </summary>
        /// <param name="ptr">CvContoursChainCode*</param>
#else
        /// <summary>
        /// Initializes from pointer
        /// </summary>
        /// <param name="ptr">CvContoursChainCode*</param>
#endif
        public CvContoursChainCode(IntPtr ptr)
            : base(ptr)
        {
        }
#if LANG_JP
        /// <summary>
        /// ポインタから初期化
        /// </summary>
        /// <param name="ptr">CvContoursChainCode*</param>
#else
        /// <summary>
        /// Initializes from pointer
        /// </summary>
        /// <param name="ptr">CvContoursChainCode*</param>
#endif
        public static CvContoursChainCode FromPtr(IntPtr ptr)
        {
            return new CvContoursChainCode(ptr);
        }
        #endregion

        #region ICollection<CvContourChainCode> Members
#if LANG_JP
        /// <summary>
        /// このコレクション に項目を追加します。
        /// </summary>
        /// <param name="item">このコレクション に追加するオブジェクト。</param>
#else
        /// <summary>
        /// Adds an item to the collection.
        /// </summary>
        /// <param name="item">The object to add to the collection.</param>
#endif
        public void Add(CvContourChainCode item)
        {
            if (item == null)
                throw new ArgumentNullException("item");

            CvBlobInvoke.CvContoursChainCode_PushBack(_ptr, item.CvPtr);
        }
#if LANG_JP
        /// <summary>
        /// コレクション からすべての項目を削除します。
        /// </summary>
#else
        /// <summary>
        /// Removes all items from the collection.
        /// </summary>
#endif
        public void Clear()
        {
            CvBlobInvoke.CvContoursChainCode_Clear(_ptr);
        }
#if LANG_JP
        /// <summary>
        /// このコレクション に特定の値が格納されているかどうかを判断します。
        /// </summary>
        /// <param name="item">このコレクション 内で検索するオブジェクト。</param>
        /// <returns>item が このコレクション に存在する場合は true。それ以外の場合は false。</returns>
#else
        /// <summary>
        /// Determines whether the collection contains a specific value.
        /// </summary>
        /// <param name="item">The object to locate in the collection.</param>
        /// <returns> true if item is found in the collection; otherwise, false.</returns>
#endif
        public bool Contains(CvContourChainCode item)
        {
            if (item == null)
                throw new ArgumentNullException("item");

            return CvBlobInvoke.CvContoursChainCode_Contains(_ptr, item.CvPtr);
        }
#if LANG_JP
        /// <summary>
        /// このコレクション の要素を Array にコピーします。Array の特定のインデックスからコピーが開始されます。
        /// </summary>
        /// <param name="array">このコレクション から要素がコピーされる 1 次元の Array。Array には、0 から始まるインデックス番号が必要です。</param>
        /// <param name="arrayIndex">コピーの開始位置となる、array の 0 から始まるインデックス番号。</param>
#else
        /// <summary>
        /// Copies the elements of the collection to an Array, starting at a particular Array index.
        /// </summary>
        /// <param name="array">The one-dimensional Array that is the destination of the elements copied from collection. The Array must have zero-based indexing.</param>
        /// <param name="arrayIndex">The zero-based index in array at which copying begins.</param>
#endif
        public void CopyTo(CvContourChainCode[] array, int arrayIndex)
        {
            if (array == null)
                throw new ArgumentNullException("array");

            IntPtr[] ptrArray = new IntPtr[array.Length];
            CvBlobInvoke.CvContoursChainCode_CopyTo(_ptr, ptrArray, arrayIndex);
            for (int i = arrayIndex; i < ptrArray.Length; i++)
            {
                array[i] = new CvContourChainCode(ptrArray[i]);
            }
        }
#if LANG_JP
        /// <summary>
        /// このコレクション に格納されている要素の数を取得します。
        /// </summary>
#else
        /// <summary>
        /// Gets the number of elements contained in the collection.
        /// </summary>
#endif
        public int Count
        {
            get
            {
                return CvBlobInvoke.CvContoursChainCode_Count(_ptr);
            }
        }
#if LANG_JP
        /// <summary>
        /// このコレクション が読み取り専用かどうかを示す値を取得します。
        /// </summary>
#else
        /// <summary>
        /// Gets a value indicating whether the collectio is read-only.
        /// </summary>
#endif
        public bool IsReadOnly
        {
            get { return false; }
        }
#if LANG_JP
        /// <summary>
        /// コレクション 内で最初に見つかった特定のオブジェクトを削除します。
        /// </summary>
        /// <param name="item">コレクションから削除するオブジェクト。</param>
        /// <returns>item がコレクション から正常に削除された場合は true。それ以外の場合は false。</returns>
#else
        /// <summary>
        /// Removes the first occurrence of a specific object from the collection.
        /// </summary>
        /// <param name="item">The object to remove from the collection.</param>
        /// <returns>true if item was successfully removed from the collection; otherwise, false.</returns>
#endif
        public bool Remove(CvContourChainCode item)
        {
            if (item == null)
                throw new ArgumentNullException("item");

            return CvBlobInvoke.CvContoursChainCode_Remove(_ptr, item.CvPtr);
        }
        #endregion
        #region IEnumerable<CvContourChainCode> Members
#if LANG_JP
        /// <summary>
        /// コレクションを反復処理する列挙子を返します。
        /// </summary>
#else
        /// <summary>
        /// Returns an enumerator that iterates through a collection. 
        /// </summary>
#endif
        public IEnumerator<CvContourChainCode> GetEnumerator()
        {
            CvContourChainCode[] array = new CvContourChainCode[Count];
            CopyTo(array, 0);

            foreach (CvContourChainCode item in array)
            {
                yield return item;
            }
        }
#if LANG_JP
		/// <summary>
        /// コレクションを反復処理する列挙子を返します。
        /// </summary>
#else
        /// <summary>
        /// Returns an enumerator that iterates through a collection. 
        /// </summary>
#endif
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        #endregion
    }
}
