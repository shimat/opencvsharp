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
    internal unsafe struct WCvDTreeSplit
    {
        public int var_idx;
        public int inversed;
        public float quality;
        public void* next;
        public fixed int subset[2];
    }

#if LANG_JP
    /// <summary>
    /// 決定木ノードの分岐
    /// </summary>
#else
	/// <summary>
    /// Decision tree node split
    /// </summary>
#endif
	public class CvDTreeSplit : ICvPtrHolder
	{
	    private IntPtr _ptr;

		public CvDTreeSplit(IntPtr ptr)
		{
			this._ptr = ptr;
		}

		#region Properties
		/// <summary>
		/// sizeof(CvDTreeSplit) 
		/// </summary>
		public static readonly int SizeOf = Marshal.SizeOf(typeof(WCvDTreeSplit));

#if LANG_JP
		/// <summary>
		/// データポインタ (CvDTreeSplit*)
		/// </summary>
#else
		/// <summary>
		/// Data pointer (CvDTreeSplit*)
		/// </summary>
#endif
		public IntPtr CvPtr
		{
			get { return _ptr; }
		}

#if LANG_JP
		/// <summary>
		/// 分岐で用いられる変数のインデックス．
		/// </summary>
#else
		/// <summary>
		/// Index of the variable used in the split 
		/// </summary>
#endif
		public int VarIdx
		{
			get
            { 
                unsafe
                {
                    return ((WCvDTreeSplit*)_ptr)->var_idx;
                }
            }
		}

#if LANG_JP
		/// <summary>
		/// trueの場合，逆分岐規則が用いられる（つまり左右の枝が交換される）． 
		/// </summary>
#else
		/// <summary>
		/// When true, the inverse split rule is used (i.e. left and right branches are exchanged in the expressions below) 
		/// </summary>
#endif
		public bool Inversed
		{
			get
            {
                unsafe
                {
                    return ((WCvDTreeSplit*)_ptr)->inversed != 0;
                }
            }
		}

#if LANG_JP
		/// <summary>
		/// 正の数で表現される分岐のクオリティ．
		/// これは最も重要な分岐の選択，代理分岐の選択・ソートに用いられる．
		/// 木が構成された後は，変数の重要度を計算するために用いられる．  
		/// </summary>
#else
		/// <summary>
		/// The split quality, a positive number. 
		/// It is used to choose the best primary split, then to choose and sort the surrogate splits. 
		/// After the tree is constructed, it is also used to compute variable importance.  
		/// </summary>
#endif
		public float Quality
		{
			get
            { 
                unsafe
                {
                    return ((WCvDTreeSplit*)_ptr)->quality;
                }
            }
		}

		
#if LANG_JP
		/// <summary>
		/// ノード分岐リスト内の次の分岐へのポインタ.  
		/// </summary>
#else
		/// <summary>
		/// Pointer to the next split in the node split list. 
		/// </summary>
#endif
		public CvDTreeSplit Next
		{
			get
			{ 
                unsafe
                {
				    IntPtr p = new IntPtr(((WCvDTreeSplit*)_ptr)->next);
				    if(p == IntPtr.Zero)
					    return null;
				    else
					    return new CvDTreeSplit(p);
                }
			}
		}

#if LANG_JP
		/// <summary>
		/// カテゴリ変数に対する分岐の場合，部分集合を表すビット配列．
		/// var_value が subset に属する場合 next_node&lt;-left ，そうでない場合 next_node&lt;-right．  
		/// </summary>
#else
		/// <summary>
		/// Bit array indicating the value subset in case of split on a categorical variable.
		/// The rule is: if var_value in subset then next_node&lt;-left else next_node&lt;-right
		/// </summary>
#endif
		public PointerAccessor1D_Int32 Subset
		{
			get
			{
                unsafe
                {
                    int* subset = ((WCvDTreeSplit*)_ptr)->subset;
                    return new PointerAccessor1D_Int32(subset);
                }				
			}
		}
 
#if LANG_JP
		/// <summary>
		/// 連続変数に対する分岐の場合，閾値．
		/// var_value &lt; c の場合 next_node&lt;-left ，そうでない場合 next_node&lt;-right．  
		/// </summary>
#else
		/// <summary>
		/// The threshold value in case of split on an ordered variable.
		/// The rule is: if var_value &lt; c then next_node&lt;-left else next_node&lt;-right
		/// </summary>
#endif
		public float OrdC
		{
			get
            {
                unsafe
                {
                    int value = ((WCvDTreeSplit*)_ptr)->subset[0];
                    return BitConverter.ToSingle(BitConverter.GetBytes(value), 0);
                }
            }
		}

		 
#if LANG_JP
		/// <summary>
		/// 学習アルゴリズムで内部的に利用される． 
		/// </summary>
#else
		/// <summary>
		/// Used internally by the training algorithm. 
		/// </summary>
#endif
		public int OrdSplitPoint
		{
			get
            {
                unsafe
                {
                    return ((WCvDTreeSplit*)_ptr)->subset[1];
                }
            }
		}
		#endregion
	}
}
