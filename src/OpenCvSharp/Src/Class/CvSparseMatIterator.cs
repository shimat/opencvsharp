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
    /// 疎な配列要素のイテレータ
    /// </summary>
#else
    /// <summary>
    /// sparse array iterator
    /// </summary>
#endif
    public class CvSparseMatIterator : DisposableCvObject, IEnumerable<CvSparseNode>
    {
        /// <summary>
        /// Target sparse mat
        /// </summary>
        private CvSparseMat mat;

        #region Initialization and Disposal
#if LANG_JP
        /// <summary>
        /// デフォルトコンストラクタ
        /// </summary>
#else
        /// <summary>
        /// Default constructor
        /// </summary>
#endif
        public CvSparseMatIterator()
            : this(null)
        {
        }
#if LANG_JP
        /// <summary>
        /// 対象のCvSparseMatを指定して初期化
        /// </summary>
        /// <param name="mat">入力配列</param>
#else
        /// <summary>
        /// Initializes with CvSparseMat
        /// </summary>
        /// <param name="mat">Input array</param>
#endif
        public CvSparseMatIterator(CvSparseMat mat)
        {
            ptr = AllocMemory(SizeOf);
            Init(mat);
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

        #region Properties
        /// <summary>
        /// sizeof(CvSparseMatIterator)
        /// </summary>
        public static readonly int SizeOf = Marshal.SizeOf(typeof(WCvSparseMatIterator));


#if LANG_JP
        /// <summary>
        /// 
        /// </summary>
#else
        /// <summary>
        /// 
        /// </summary>
#endif
        public CvSparseMat Mat
		{
            get
            {
                IntPtr p;
                unsafe
                {
                    p = new IntPtr(((WCvSparseMatIterator*)ptr)->mat);
                }
                if (p == IntPtr.Zero)
                    return null;
                return new CvSparseMat(p, false);
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
		public CvSparseNode Node
		{
            get
            {
                IntPtr p;
                unsafe
                {
                    p = new IntPtr(((WCvSparseMatIterator*)ptr)->node);
                }
                if (p == IntPtr.Zero)
                    return null;
                return new CvSparseNode(p);
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
		public int CurIdx
		{
            get
            {
                unsafe
                {
                    return ((WCvSparseMatIterator*)ptr)->curidx;
                }
            }
		}
        #endregion

        #region Methods
        #region GetNextSparseNode
#if LANG_JP
        /// <summary>
        /// 疎な配列において次の要素のポインタを返す
        /// </summary>
        /// <returns></returns>
#else
        /// <summary>
        /// Moves iterator to the next sparse matrix element and returns pointer to it.
        /// </summary>
        /// <returns></returns>
#endif
        public CvSparseNode GetNextSparseNode()
        {
            return Cv.GetNextSparseNode(this);
        }
        #endregion
        #region InitSparseMatIterator
#if LANG_JP
        /// <summary>
        /// 疎な配列要素のイテレータを初期化する (cvInitSparseMatIterator)
        /// </summary>
        /// <param name="m">入力配列</param>
        /// <returns>疎な配列の先頭要素</returns>
#else
        /// <summary>
        /// Initializes sparse array elements iterator
        /// </summary>
        /// <param name="m">Input array</param>
        /// <returns>the first sparse matrix element</returns>
#endif
        public CvSparseNode Init(CvSparseMat m)
        {
            if (m == null)
            {
                throw new ArgumentNullException("m");
            }
            mat = m;
            IntPtr result = CvInvoke.cvInitSparseMatIterator(mat.CvPtr, CvPtr);
            if (result == IntPtr.Zero)
                return null;
            return new CvSparseNode(result);
        }
        #endregion
        #endregion

        #region IEnumerable<CvSparseNode> Members
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IEnumerator<CvSparseNode> GetEnumerator()
        {
            if (mat == null)
            {
                throw new OpenCvSharpException("Not initialized CvSparseMatIterator");
            }

            CvSparseNode node = Init(mat);
            if (node == null)
            {
                yield break;
            }            

            do
            {
                yield return node;
                node = Cv.GetNextSparseNode(this);
            } while (node != null);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        #endregion
    }
}
