/*
 * (C) 2008-2013 Schima
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
    /// ツリーノード
    /// </summary>
#else
    /// <summary>
    /// tree node
    /// </summary>
#endif
    abstract public class CvTreeNode<T> : CvArr
        where T : CvTreeNode<T>
    {
        #region Initialization
#if LANG_JP
        /// <summary>
        /// 既定の初期化
        /// </summary>
#else
        /// <summary>
        /// Default constructor
        /// </summary>
#endif
        protected CvTreeNode()
        {
            ptr = IntPtr.Zero;
        }
#if LANG_JP
        /// <summary>
        /// ポインタから初期化
        /// </summary>
        /// <param name="ptr">struct CvTreeNode*</param>
#else
        /// <summary>
        /// Initializes from native pointer
        /// </summary>
        /// <param name="ptr">struct CvTreeNode*</param>
#endif
        protected CvTreeNode(IntPtr ptr)
        {
            Initialize(ptr);
        }

#if LANG_JP
        /// <summary>
        /// ポインタから初期化
        /// </summary>
        /// <param name="p">struct CvTreeNode*</param>
#else
        /// <summary>
        /// Initializes from native pointer
        /// </summary>
        /// <param name="p">struct CvTreeNode*</param>
#endif
        protected void Initialize(IntPtr p)
        {
            if (p == IntPtr.Zero)
                throw new ArgumentNullException("p");
            ptr = p;
        }
        #endregion

        #region Properties
        /// <summary>
        /// sizeof(CvTreeNode)
        /// </summary>
        public static readonly int SizeOf = Marshal.SizeOf(typeof(WCvTreeNode));


#if LANG_JP
        /// <summary>
		/// 様々なフラグ
		/// </summary>
#else
        /// <summary>
        /// miscellaneous flags
        /// </summary>
#endif
        public int Flags
        {
            get
            {
                unsafe
                {
                    return ((WCvTreeNode*)ptr)->flags;
                }
            }
        }
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
                    return ((WCvTreeNode*)ptr)->header_size;
                }
            }
        }
#if LANG_JP
		/// <summary>
		/// 一つ前のシーケンスへのポインタ
		/// </summary>
#else
        /// <summary>
        /// previous sequence
        /// </summary>
#endif
        abstract public T HPrev
        {
            get;
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
        abstract public T HNext
        {
            get;
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
        abstract public T VPrev
        {
            get;
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
        abstract public T VNext
        {
            get;
        }
        #endregion

        #region Methods
        #region InsertNodeIntoTree
#if LANG_JP
        /// <summary>
        /// ツリーに新しいノードを追加する
        /// </summary>
        /// <param name="parent">ツリー内に既に存在している親ノード．</param>
        /// <param name="frame">トップレベルノード．parent と frame が同じである場合， nodeのv_prevフィールドには，parent ではなく，nullがセットされる．</param>
#else
        /// <summary>
        /// Adds new node to the tree
        /// </summary>
        /// <param name="parent">The parent node that is already in the tree. </param>
        /// <param name="frame">The top level node. If parent and frame are the same, v_prev  field of node is set to null rather than parent. </param>
#endif
        public void InsertNodeIntoTree(CvTreeNode<T> parent, CvTreeNode<T> frame)
        {
            Cv.InsertNodeIntoTree(this, parent, frame);
        }
        #endregion
        #region RemoveNodeFromTree
#if LANG_JP
        /// <summary>
        /// ツリーからノードを削除する
        /// </summary>
        /// <param name="frame">トップレベルノード．node->v_prev = null かつ node->h_prev = null （つまり，node が frameの最初の子ノードである）である場合， 
        /// frame->v_next は node->h_next にセットされる (つまり，最初の子ノードかframeが変更される）．</param>
#else
        /// <summary>
        /// Removes node from tree
        /// </summary>
        /// <param name="frame">The top level node. If node->v_prev = null and node->h_prev is null (i.e. if node is the first child of frame), 
        /// frame->v_next is set to node->h_next (i.e. the first child or frame is changed). </param>
#endif
        public void RemoveNodeFromTree(CvTreeNode<T> frame)
        {
            Cv.RemoveNodeFromTree(this, frame);
        }
        #endregion
        #region TreeToNodeSeq
#if LANG_JP
        /// <summary>
        /// すべてのノードへのポインタを一つのシーケンスに集める
        /// </summary>
        /// <param name="headerSize">作成したシーケンスのヘッダサイズ（sizeof(CvSeq) が用いられることが多い）．</param>
        /// <param name="storage">シーケンスのためのコンテナ．</param>
        /// <returns></returns>
#else
        /// <summary>
        /// Gathers all node pointers to the single sequence
        /// </summary>
        /// <param name="headerSize">Header size of the created sequence (sizeof(CvSeq) is the most used value). </param>
        /// <param name="storage">Container for the sequence. </param>
        /// <returns></returns>
#endif
        public CvSeq TreeToNodeSeq(int headerSize, CvMemStorage storage)
        {
            return Cv.TreeToNodeSeq(this, headerSize, storage);
        }
        #endregion
        #endregion
    }
}
