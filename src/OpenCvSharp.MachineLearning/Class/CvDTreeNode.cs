/*
 * (C) 2008-2013 Schima
 * This code is licenced under the LGPL.
 */

using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

#pragma warning disable 1591

namespace OpenCvSharp.MachineLearning
{
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    internal unsafe struct WCvDTreeNode
    {
        public int class_idx;
        public int Tn;
        public double value;

        public void* parent;
        public void* left;
        public void* right;

        public void* split;

        public int sample_count;
        public int depth;
        public int* num_valid;
        public int offset;
        public int buf_idx;
        public double maxlr;

        public int complexity;
        public double alpha;
        public double node_risk, tree_risk, tree_error;

        public int* cv_Tn;
        public double* cv_node_risk;
        public double* cv_node_error;
    }

#if LANG_JP
    /// <summary>
    /// 決定木ノード
    /// </summary>
#else
	/// <summary>
    /// Decision tree node
    /// </summary>
#endif
    public class CvDTreeNode : ICvPtrHolder
    {
        private IntPtr _ptr;

		

#if LANG_JP
        /// <summary>
        /// 初期化
        /// </summary>
        /// <param name="ptr"></param>
#else
		/// <summary>
		/// Default constructor
		/// </summary>
        /// <param name="ptr"></param>
#endif
        public CvDTreeNode(IntPtr ptr)
		{
			this._ptr = ptr;
		}



        #region Properties
		/// <summary>
		/// sizeof(CvDTreeNode) 
		/// </summary>
		public static readonly int SizeOf = Marshal.SizeOf(typeof(WCvDTreeNode)); 

#if LANG_JP
		/// <summary>
		/// データポインタ (CvDTreeNode*)
		/// </summary>
#else
		/// <summary>
		/// Data pointer (CvDTreeNode*)
		/// </summary>
#endif
		public IntPtr CvPtr
		{
			get{ return _ptr; }
		}

#if LANG_JP
		/// <summary>
		/// ノードに割り当てられた正規化されたクラスインデックス（0 から class_count-1 までの範囲）．分類木と木集合の内部で用いられる． 
		/// </summary>
#else
		/// <summary>
		/// The assigned to the node normalized class index (to 0..class_count-1 range), it is used internally in classification trees and tree ensembles. 
		/// </summary>
#endif
		public int ClassIdx
		{
            get
            {
                unsafe
                {
                    return ((WCvDTreeNode*)_ptr)->class_idx;
                }
            }
		}

#if LANG_JP
		/// <summary>
		/// 複数の木を順番に並べた場合の木のインデックス．
		/// これらのインデックスは，刈り込み手続き中およびその後に利用される．
		/// ルートノードは，木全体における最大値 Tn を持ち，子ノードは親ノードのTn 以下の Tn を持つ．
		/// Tn≤CvDTree::pruned_tree_idx となるノードは， 刈り込みを行う際にそれらが木から物理的に削除されなくても，
		/// 予測ステージにおいて考慮されない（対応する枝が刈り込まれたものと見なされる）．
		/// </summary>
#else
		/// <summary>
		/// The tree index in a ordered sequence of trees. The indices are used during and after the pruning procedure. 
		/// The root node has the maximum value Tn  of the whole tree, child nodes have Tn less than or equal to the parent's Tn, 
		/// and the nodes with Tn≤CvDTree::pruned_tree_idx are not taken into consideration at the prediction stage (the corresponding branches are considered as cut-off), 
		/// even if they have not been physically deleted from the tree at the pruning stage. 
		/// </summary>
#endif
		public int Tn
		{
            get
            {
                unsafe
                {
                    return ((WCvDTreeNode*)_ptr)->Tn;
                }
            }
		}

#if LANG_JP
		/// <summary>
		/// 木のノードに割り当てられた値．これはクラスラベルか，推定された関数値のいずれかとなる．
		/// </summary>
#else
		/// <summary>
		/// When true, the inverse split rule is used (i.e. left and right branches are exchanged in the expressions below) 
		/// </summary>
#endif
		public double Value
		{
            get 
            {
                unsafe
                {
                    return ((WCvDTreeNode*)_ptr)->value;
                }
            }
		}

		
#if LANG_JP
		/// <summary>
		/// 親ノードへのポインタ
		/// </summary>
#else
		/// <summary>
		/// Pointers to the parent node
		/// </summary>
#endif
		public CvDTreeNode Parent
		{
			get
			{
                unsafe
                {
                    IntPtr p = new IntPtr(((WCvDTreeNode*)_ptr)->parent);
                    if (p == IntPtr.Zero)
                        return null;
                    else
                        return new CvDTreeNode(p);
                }
			}
		}

#if LANG_JP
		/// <summary>
		/// 子ノード（左）へのポインタ 
		/// </summary>
#else
		/// <summary>
		/// Pointers to the left node
		/// </summary>
#endif
		public CvDTreeNode Left
		{
			get
			{
                unsafe
                {
                    IntPtr p = new IntPtr(((WCvDTreeNode*)_ptr)->left);
                    if (p == IntPtr.Zero)
                        return null;
                    else
                        return new CvDTreeNode(p);
                }
			}
		}

#if LANG_JP
		/// <summary>
		/// 子ノード（右）へのポインタ 
		/// </summary>
#else
		/// <summary>
		/// Pointers to the right node
		/// </summary>
#endif
		public CvDTreeNode Right
		{
			get
			{
                unsafe
                {
                    IntPtr p = new IntPtr(((WCvDTreeNode*)_ptr)->right);
                    if (p == IntPtr.Zero)
                        return null;
                    else
                        return new CvDTreeNode(p);
                }
			}
		}

#if LANG_JP
		/// <summary>
		/// 最初の（第一）分岐へのポインタ．
		/// </summary>
#else
		/// <summary>
		/// Pointer to the first (primary) split. 
		/// </summary>
#endif
		public CvDTreeSplit Split
		{
			get
			{
                unsafe
                {
                    IntPtr p = new IntPtr(((WCvDTreeNode*)_ptr)->split);
                    if (p == IntPtr.Zero)
                        return null;
                    else
                        return new CvDTreeSplit(p);
                }
			}
		}

		 
#if LANG_JP
		/// <summary>
		/// 学習ステージでノードに分類されるサンプル数．
		/// これは困難なケースを解決するために用いられる．つまり第一分岐の変数が見つからず，他の全ての代理分岐に対する変数も見つからない場合は，
		/// left-&lt;sample_count&lt;right-&lt;sample_count のとき，サンプルは左に向かい，そうでなければ右に向かう． 
		/// </summary>
#else
		/// <summary>
		/// The number of samples that fall into the node at the training stage. 
		/// It is used to resolve the difficult cases - when the variable for the primary split is missing, 
		/// and all the variables for other surrogate splits are missing too,
		/// the sample is directed to the left if left-&lt;sample_count&lt;right-&lt;sample_count and to the right otherwise. 
		/// </summary>
#endif
		public int SampleCount
		{
            get
            {
                unsafe
                {
                    return ((WCvDTreeNode*)_ptr)->sample_count;
                }
            }
		}

#if LANG_JP
		/// <summary>
		/// ノードの深さ．ルートノードの深さは 0 であり，子ノードの深さは親ノードの深さ +1 となる．
		/// </summary>
#else
		/// <summary>
		/// The node depth, the root node depth is 0, the child nodes depth is the parent's depth + 1. 
		/// </summary>
#endif
		public int Depth
		{
            get
            {
                unsafe
                {
                    return ((WCvDTreeNode*)_ptr)->depth;
                }
            }
		}
		#endregion
    }
}
