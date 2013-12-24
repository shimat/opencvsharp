/*
 * (C) 2008-2013 Schima
 * This code is licenced under the LGPL.
 */

using System;
using System.Collections.Generic;
using System.Text;

using CvLabel = System.UInt32;

namespace OpenCvSharp.Blob.Old
{
	/// <summary>
    /// List of blobs.
    /// A map is used to access each blob from its label number.
    /// </summary>
    public class CvBlobs : DisposableCvObject, IDictionary<CvLabel, CvBlob>
    {
        /// <summary>
        /// sizeof(CvBlobs)
        /// </summary>
        public static readonly int SizeOf = CvBlobInvoke.CvBlobs_sizeof();
        /// <summary>
        /// Track whether Dispose has been called
        /// </summary>
        public bool Disposed { get; internal set; }

        #region Init and Disposal
        /// <summary>
        /// Constructor
        /// </summary>
        public CvBlobs()
        {
            ptr = CvBlobInvoke.CvBlobs_construct();
            Disposed = false;
            NotifyMemoryPressure(SizeOf);
        }
        /// <summary>
        /// Constructor (init and cvLabel)
        /// </summary>
        /// <param name="img">Input binary image (depth=IPL_DEPTH_8U and num. channels=1).</param>
        /// <param name="imgOut">Output image (depth=IPL_DEPTH_LABEL and num. channels=1).</param>
        public CvBlobs(IplImage img, IplImage imgOut) : this()
        {
            Label(img, imgOut);
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
            if (!Disposed)
            {
                // 継承したクラス独自の解放処理
                try
                {
                    if (disposing)
                    {
                    }
                    if (IsEnabledDispose)
                    {
                        //CvBlobInvoke.cvb_cvReleaseBlobs(ptr);
                        foreach (CvBlob blob in Values)
                        {
                            blob.Dispose();
                        }
                        CvBlobInvoke.CvBlobs_destruct(ptr);
                    }
                    Disposed = true;
                }
                finally
                {
                    // 親の解放処理
                    base.Dispose(disposing);
                }
            }
        }
        #endregion

        #region Methods
        #region Label
        /// <summary>
        /// Label the connected parts of a binary image. (cvLabel)
        /// </summary>
        /// <param name="img">Input binary image (depth=IPL_DEPTH_8U and num. channels=1).</param>
        /// <param name="imgOut">Output image (depth=IPL_DEPTH_LABEL and num. channels=1).</param>
        /// <returns>Number of pixels that has been labeled.</returns>
        public uint Label(IplImage img, IplImage imgOut)
        {
            if(Disposed)
                throw new ObjectDisposedException("CvBlobs");
            return CvBlobLib.Label(img, imgOut, this);
        }
        #endregion
        #region FilterLabels
        /// <summary>
        /// Draw a binary image with the blobs that have been given. (cvFilterLabels)
        /// </summary>
        /// <param name="imgIn">Input image (depth=IPL_DEPTH_LABEL and num. channels=1).</param>
        /// <param name="imgOut">Output binary image (depth=IPL_DEPTH_8U and num. channels=1).</param>
        public void FilterLabels(IplImage imgIn, IplImage imgOut)
        {
            if (Disposed)
                throw new ObjectDisposedException("CvBlobs");
            CvBlobLib.FilterLabels(imgIn, imgOut, this);
        }
        #endregion
        #region GreaterBlob
        /// <summary>
        /// Find greater blob. (cvGreaterBlob)
        /// </summary>
        /// <returns>Label of greater blob.</returns>
        public CvLabel GreaterBlob()
        {
            if (Disposed)
                throw new ObjectDisposedException("CvBlobs");
            return CvBlobLib.GreaterBlob(this);
        }
        #endregion
        #region ReleaseBlobs
        /// <summary>
        /// Clear blobs structure. (cvReleaseBlobs)
        /// </summary>
        public void Release()
        {
            if (Disposed)
                throw new ObjectDisposedException("CvBlobs");
		    CvBlobLib.ReleaseBlobs(this);
	    }
        #endregion
        #region RenderBlobs
        /// <summary>
        /// Draws or prints information about blobs. (cvRenderBlobs)
        /// </summary>
        /// <param name="imgLabel">Label image (depth=IPL_DEPTH_LABEL and num. channels=1).</param>
        /// <param name="imgSource">Input image (depth=IPL_DEPTH_8U and num. channels=3).</param>
        /// <param name="imgDest">Output image (depth=IPL_DEPTH_8U and num. channels=3).</param>
        public void RenderBlobs(IplImage imgLabel, IplImage imgSource, IplImage imgDest)
        {
            if (Disposed)
                throw new ObjectDisposedException("CvBlobs");
            CvBlobLib.RenderBlobs(imgLabel, this, imgSource, imgDest);
        }
        /// <summary>
        /// Draws or prints information about blobs. (cvRenderBlobs)
        /// </summary>
        /// <param name="imgLabel">Label image (depth=IPL_DEPTH_LABEL and num. channels=1).</param>
        /// <param name="imgSource">Input image (depth=IPL_DEPTH_8U and num. channels=3).</param>
        /// <param name="imgDest">Output image (depth=IPL_DEPTH_8U and num. channels=3).</param>
        /// <param name="mode">Render mode. By default is CV_BLOB_RENDER_COLOR|CV_BLOB_RENDER_CENTROID|CV_BLOB_RENDER_BOUNDING_BOX|CV_BLOB_RENDER_ANGLE.</param>
        public void RenderBlobs(IplImage imgLabel, IplImage imgSource, IplImage imgDest, RenderBlobsMode mode)
        {
            if (Disposed)
                throw new ObjectDisposedException("CvBlobs");
            CvBlobLib.RenderBlobs(imgLabel, this, imgSource, imgDest, mode);
        }
        /// <summary>
        /// Draws or prints information about blobs. (cvRenderBlobs)
        /// </summary>
        /// <param name="imgLabel">Label image (depth=IPL_DEPTH_LABEL and num. channels=1).</param>
        /// <param name="imgSource">Input image (depth=IPL_DEPTH_8U and num. channels=3).</param>
        /// <param name="imgDest">Output image (depth=IPL_DEPTH_8U and num. channels=3).</param>
        /// <param name="mode">Render mode. By default is CV_BLOB_RENDER_COLOR|CV_BLOB_RENDER_CENTROID|CV_BLOB_RENDER_BOUNDING_BOX|CV_BLOB_RENDER_ANGLE.</param>
        /// <param name="alpha">If mode CV_BLOB_RENDER_COLOR is used. 1.0 indicates opaque and 0.0 translucent (1.0 by default).</param>
        public void RenderBlobs(IplImage imgLabel, IplImage imgSource, IplImage imgDest, RenderBlobsMode mode, Double alpha)
        {
            if (Disposed)
                throw new ObjectDisposedException("CvBlobs");
            CvBlobLib.RenderBlobs(imgLabel, this, imgSource, imgDest, mode, alpha);
        }
        #endregion
        #region FilterByArea
        /// <summary>
        /// Filter blobs by area. 
        /// Those blobs whose areas are not in range will be erased from the input list of blobs. (cvFilterByArea)
        /// </summary>
        /// <param name="minArea">Minimun area.</param>
        /// <param name="maxArea">Maximun area.</param>
        public void FilterByArea(UInt32 minArea, UInt32 maxArea)
        {
            if (Disposed)
                throw new ObjectDisposedException("CvBlobs");
            CvBlobLib.FilterByArea(this, minArea, maxArea);
        }
        #endregion
        #endregion

        #region Implementation of IDictionary
        #region IDictionary<CvLabel,CvBlob> Members
#if LANG_JP
        /// <summary>
        /// 指定したキーおよび値を持つ要素を IDictionary&lt;TKey,TValue&gt; に追加します。
        /// </summary>
        /// <param name="key">追加する要素のキーとして使用するオブジェクト。</param>
        /// <param name="value">追加する要素の値として使用するオブジェクト。</param>
#else
        /// <summary>
        /// Adds the specified key and value to the dictionary.
        /// </summary>
        /// <param name="key">The object to use as the key.</param>
        /// <param name="value">The object to use as the value.</param>
#endif
        public virtual void Add(CvLabel key, CvBlob value)
        {
            if (value == null)
                throw new ArgumentNullException("value");
            if (Disposed)
                throw new ObjectDisposedException("CvBlobs");
            CvBlobInvoke.CvBlobs_Add(ptr, key, value.CvPtr);
        }
#if LANG_JP
        /// <summary>
        /// 指定したキーの要素が IDictionary&lt;TKey,TValue&gt; に格納されているかどうかを確認します。
        /// </summary>
        /// <param name="key">IDictionary&lt;TKey,TValue&gt; 内で検索されるキー。</param>
        /// <returns>指定したキーを持つ要素を IDictionary&lt;TKey,TValue&gt; が保持している場合は true。それ以外の場合は false。</returns>
#else
        /// <summary>
        /// Determines whether the IDictionary contains an element with the specified key. 
        /// </summary>
        /// <param name="key">The key to locate in the IDictionary&lt;TKey,TValue&gt;.</param>
        /// <returns>true if the IDictionary&lt;TKey,TValue&gt; contains an element with the key; otherwise, false. </returns>
#endif
        public virtual bool ContainsKey(CvLabel key)
        {
            if (Disposed)
                throw new ObjectDisposedException("CvBlobs");
            return CvBlobInvoke.CvBlobs_ContainsKey(ptr, key);
        }
#if LANG_JP
		/// <summary>
        /// IDictionary&lt;TKey,TValue&gt; のキーを保持している ICollection&lt;T&gt;を取得します。
        /// </summary>
		/// <returns>IDictionary&lt;TKey,TValue&gt; を実装するオブジェクトのキーを保持している ICollection&lt;T&gt;。</returns>
#else
        /// <summary>
        /// Gets an ICollection&lt;T&gt; containing the keys of the IDictionary&lt;TKey,TValue&gt;.
        /// </summary>
        /// <returns>An ICollection&lt;T&gt; containing the keys of the IDictionary&lt;TKey,TValue&gt;.</returns>
#endif
        public virtual ICollection<CvLabel> Keys
        {
            get
            {
                if (Disposed)
                    throw new ObjectDisposedException("CvBlobs");
                CvLabel[] keys = new CvLabel[Count];
                CvBlobInvoke.CvBlobs_Keys(ptr, keys);
                return keys;
            }
        }
#if LANG_JP
		/// <summary>
        /// 指定したキーを持つ要素を IDictionary&lt;TKey,TValue&gt; から削除します。
        /// </summary>
        /// <param name="key">削除する要素のキー。</param>
        /// <returns>要素が正常に削除された場合は true。それ以外の場合は false。このメソッドは、key が元の IDictionary&lt;TKey,TValue&gt; に見つからなかった場合にも false を返します。</returns>
#else
        /// <summary>
        /// Removes the element with the specified key from the IDictionary&lt;TKey,TValue&gt;.
        /// </summary>
        /// <param name="key">The key of the element to remove.</param>
        /// <returns> true if the element is successfully found and removed; otherwise, false. This method returns false if key is not found in the IDictionary&lt;TKey, TValue&gt;.</returns>
#endif
        public virtual bool Remove(CvLabel key)
        {
            if (Disposed)
                throw new ObjectDisposedException("CvBlobs");
            if (ContainsKey(key))
            {                
                CvBlob blob = this[key];                
                // mapからの削除
                bool result = CvBlobInvoke.CvBlobs_RemoveAt(ptr, key);
                // 要素のCvBlobを解放 (参照が切れるので)
                if (result) blob.Release();
                return result;
            }
            return false;
        }
#if LANG_JP
        /// <summary>
        /// 指定したキーに関連付けられている値を取得します。
        /// </summary>
        /// <param name="key">値を取得する対象のキー。</param>
        /// <param name="value">このメソッドが返されるときに、キーが見つかった場合は、指定したキーに関連付けられている値。それ以外の場合は value パラメータの型に対する既定の値。このパラメータは初期化せずに渡されます。</param>
        /// <returns>指定したキーを持つ要素が IDictionary&lt;TKey,TValue&gt; を実装するオブジェクトに格納されている場合は true。それ以外の場合は false。</returns>
#else
        /// <summary>
        /// Gets the value associated with the specified key. 
        /// </summary>
        /// <param name="key">The key whose value to get.</param>
        /// <param name="value">When this method returns, the value associated with the specified key, if the key is found; otherwise, the default value for the type of the value parameter. This parameter is passed uninitialized.</param>
        /// <returns>true if the object that implements IDictionary contains an element with the specified key; otherwise, false. </returns>
#endif
        public virtual bool TryGetValue(CvLabel key, out CvBlob value)
        {
            if (Disposed)
                throw new ObjectDisposedException("CvBlobs");
            IntPtr valuePtr;
            if (CvBlobInvoke.CvBlobs_TryGetValue(ptr, key, out valuePtr))
            {
                if (valuePtr == IntPtr.Zero)
                    value = null;
                else
                    value = new CvBlob(valuePtr);
                return true;
            }
            else
            {
                value = null;
                return false;
            }
        }
#if LANG_JP
		/// <summary>
        /// IDictionary&lt;TKey,TValue&gt; 内の値を格納している ICollection&lt;T&gt; を取得します。
        /// </summary>
		/// <returns>IDictionary&lt;TKey,TValue&gt; を実装するオブジェクトの値を保持している ICollection&lt;T&gt;。</returns>
#else
        /// <summary>
        /// Gets an ICollection&lt;T&gt; containing the values in the IDictionary&lt;TKey,TValue&gt;.
        /// </summary>
        /// <returns>An ICollection&lt;T&gt; containing the values in the IDictionary&lt;TKey,TValue&gt;.</returns>
#endif
        public virtual ICollection<CvBlob> Values
        {
            get
            {
                if (Disposed)
                    throw new ObjectDisposedException("CvBlobs");

                IntPtr[] values = new IntPtr[Count];
                CvBlobInvoke.CvBlobs_Values(ptr, values);

                CvBlob[] result = new CvBlob[values.Length];
                for (int i = 0; i < values.Length; i++)
                {
                    if (values[i] == IntPtr.Zero)
                        result[i] = null;
                    else
                        result[i] = new CvBlob(values[i]);
                }
                return result;
            }
        }
#if LANG_JP
		/// <summary>
        /// 指定したキーを持つ要素を取得または設定します。
        /// </summary>
		/// <param name="key">取得または設定する要素のキー。</param>
        /// <returns>指定したキーを持つ要素。</returns>
#else
        /// <summary>
        /// Gets or sets the value associated with the specified key.
        /// </summary>
        /// <param name="key">The key of the value to get or set.</param>
        /// <returns>The value associated with the specified key. If the specified key is not found, a get operation throws a KeyNotFoundException, and a set operation creates a new element with the specified key.</returns>
#endif
        public virtual CvBlob this[CvLabel key]
        {
            get
            {
                if (Disposed)
                    throw new ObjectDisposedException("CvBlobs");
                IntPtr p = CvBlobInvoke.CvBlobs_get(ptr, key);
                if (p == IntPtr.Zero)
                    return null;
                else
                    return new CvBlob(p);
            }
            set
            {
                if (Disposed)
                    throw new ObjectDisposedException("CvBlobs");
                IntPtr v = (value == null) ? IntPtr.Zero : value.CvPtr;
                CvBlobInvoke.CvBlobs_set(ptr, key, v);
            }
        }
        #endregion
        #region ICollection<KeyValuePair<CvLabel,CvBlob>> Members
#if LANG_JP
        /// <summary>
        /// ICollection&lt;T&gt; に項目を追加します。
        /// </summary>
        /// <param name="item">ICollection&lt;T&gt; に追加するオブジェクト。</param>
#else
        /// <summary>
        /// Adds an item to the ICollection&lt;T&gt;.
        /// </summary>
        /// <param name="item">The object to add to the ICollection&lt;T&gt;.</param>
#endif
        public virtual void Add(KeyValuePair<CvLabel, CvBlob> item)
        {
            if (Disposed)
                throw new ObjectDisposedException("CvBlobs");
            IntPtr value = (item.Value == null) ? IntPtr.Zero : item.Value.CvPtr;
            CvBlobInvoke.CvBlobs_Add(ptr, item.Key, value);
        }
#if LANG_JP
		/// <summary>
        /// ICollection&lt;T&gt; からすべての項目を削除します。
        /// </summary>
#else
        /// <summary>
        /// Removes all items from the ICollection&lt;T&gt;. 
        /// </summary>
#endif
        public virtual void Clear()
        {
            if (Disposed)
                throw new ObjectDisposedException("CvBlobs");
            CvBlobInvoke.cvb_cvReleaseBlobs(ptr);
            //CvBlobInvoke.CvBlobs_Clear(_ptr);
        }
#if LANG_JP
        /// <summary>
        /// ICollection&lt;T&gt; に特定の値が格納されているかどうかを判断します。
        /// </summary>
        /// <param name="item">ICollection&lt;T&gt; 内で検索するオブジェクト。</param>
        /// <returns>item が ICollection&lt;T&gt; に存在する場合は true。それ以外の場合は false。</returns>
#else
        /// <summary>
        /// Determines whether the ICollection&lt;T&gt; contains a specific value. 
        /// </summary>
        /// <param name="item">The object to locate in the ICollection&lt;T&gt;.</param>
        /// <returns>true if item is found in the ICollection&lt;T&gt;; otherwise, false. </returns>
#endif
        public virtual bool Contains(KeyValuePair<CvLabel, CvBlob> item)
        {
            if (Disposed)
                throw new ObjectDisposedException("CvBlobs");
            IntPtr value = (item.Value == null) ? IntPtr.Zero : item.Value.CvPtr;
            return CvBlobInvoke.CvBlobs_Contains(ptr, item.Key, value);
        }
#if LANG_JP
        /// <summary>
        /// ICollection&lt;T&gt; の要素を Array にコピーします。Array の特定のインデックスからコピーが開始されます。
        /// </summary>
        /// <param name="ary">ICollection&lt;T&gt; から要素がコピーされる 1 次元の Array。Array には、0 から始まるインデックス番号が必要です。</param>
        /// <param name="aryIndex">コピーの開始位置となる、array の 0 から始まるインデックス番号。</param>
#else
        /// <summary>
        /// Copies the elements of the ICollection&lt;T&gt; to an Array, starting at a particular Array index.
        /// </summary>
        /// <param name="ary">The one-dimensional Array that is the destination of the elements copied from ICollection. The Array must have zero-based indexing.</param>
        /// <param name="aryIndex">The zero-based index in array at which copying begins.</param>
#endif
        public virtual void CopyTo(KeyValuePair<CvLabel, CvBlob>[] ary, int aryIndex)
        {
            if (Disposed)
                throw new ObjectDisposedException("CvBlobs");
            if (ary == null)
                throw new ArgumentNullException("ary");
            if (ary.Length < Count + aryIndex)
                throw new ArgumentException();

            int i = 0;
            foreach (KeyValuePair<CvLabel, CvBlob> item in this)
            {
                ary[i + aryIndex] = item;
                i++;
            }
        }
#if LANG_JP
		/// <summary>
        /// ICollection&lt;T&gt; に格納されている要素の数を取得します。
        /// </summary>
		/// <returns>ICollection&lt;T&gt; に格納されている要素の数。</returns>
#else
        /// <summary>
        /// Gets the number of elements contained in the ICollection&lt;T&gt;.
        /// </summary>
        /// <returns>The number of elements contained in the ICollection&lt;T&gt;.</returns>
#endif
        public virtual int Count
        {
            get
            {
                if (Disposed)
                    throw new ObjectDisposedException("CvBlobs");
                return CvBlobInvoke.CvBlobs_Count(ptr);
            }
        }
#if LANG_JP
		/// <summary>
        /// ICollection&lt;T&gt; が読み取り専用かどうかを示す値を取得します。
        /// </summary>
		/// <returns>ICollection&lt;T&gt; が読み取り専用の場合は true。それ以外の場合は false。</returns>
#else
        /// <summary>
        /// Gets a value indicating whether the ICollection&lt;T&gt; is read-only.
        /// </summary>
        /// <returns>true if the ICollection&lt;T&gt; is read-only; otherwise, false. 
        /// In the default implementation of Collection&lt;T&gt;, this property always returns false.</returns>
#endif
        public virtual bool IsReadOnly
        {
            get
            {
                if (Disposed)
                    throw new ObjectDisposedException("CvBlobs");
                return false;
            }
        }
#if LANG_JP
		/// <summary>
        /// ICollection&lt;T&gt; 内で最初に見つかった特定のオブジェクトを削除します。
        /// </summary>
		/// <param name="item">ICollection&lt;T&gt; から削除するオブジェクト。</param>
		/// <returns>item が ICollection&lt;T&gt; から正常に削除された場合は true。それ以外の場合は
        /// false。このメソッドは、item が元の ICollection&lt;T&gt; に見つからない場合にも false を返します。</returns>
#else
        /// <summary>
        /// Removes the first occurrence of a specific object from the ICollection&lt;T&gt;. 
        /// </summary>
        /// <param name="item">The object to remove from the ICollection&lt;T&gt;.</param>
        /// <returns>true if item was successfully removed from the ICollection&lt;T&gt;; otherwise, false. 
        /// This method also returns false if item is not found in the original ICollection&lt;T&gt;. </returns>
#endif
        public virtual bool Remove(KeyValuePair<CvLabel, CvBlob> item)
        {
            if (Disposed)
                throw new ObjectDisposedException("CvBlobs");
            if (item.Value == null)
                throw new ArgumentException("");

            bool result = CvBlobInvoke.CvBlobs_Remove(ptr, item.Key, item.Value.CvPtr);
            // 削除成功時は要素のCvBlobを解放 (参照が切れるので)
            if (result)
            {
                item.Value.Release();
            }
            return result;
        }
        #endregion
        #region IEnumerator<KeyValuePair<CvLabel,CvBlob>> Members
#if LANG_JP
		/// <summary>
        /// コレクションを反復処理する列挙子を返します。
        /// </summary>
#else
        /// <summary>
        /// Returns an enumerator that iterates through a collection. 
        /// </summary>
#endif
        public IEnumerator<KeyValuePair<CvLabel, CvBlob>> GetEnumerator()
        {
            if (Disposed)
                throw new ObjectDisposedException("CvBlobs");
            int count = Count;
            CvLabel[] keys = new CvLabel[count];
            IntPtr[] values = new IntPtr[count];
            CvBlobInvoke.CvBlobs_GetKeysAndValues(ptr, keys, values);

            for (int i = 0; i < count; i++)
            {
                CvBlob v = (values[i] == IntPtr.Zero) ? null : new CvBlob(values[i]);
                yield return new KeyValuePair<CvLabel, CvBlob>(keys[i], v);
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
            if (Disposed)
                throw new ObjectDisposedException("CvBlobs");
            return GetEnumerator();
        }
        #endregion
        #endregion

    }
}
