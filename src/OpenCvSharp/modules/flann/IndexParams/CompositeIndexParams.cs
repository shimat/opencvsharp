using System;
using System.Collections.Generic;
using System.Text;

namespace OpenCvSharp.Flann
{
#if LANG_JP
    /// <summary>
    /// ランダム kd-tree と 階層的 k-means tree の組み合わせでインデックスが表現されます．
    /// </summary>
#else
    /// <summary>
    /// When using a parameters object of this type the index created combines the randomized kd-trees and the hierarchical k-means tree.
    /// </summary>
#endif
    public class CompositeIndexParams : IndexParams
    {
        private bool disposed = false;

        #region Properties
        /*
#if LANG_JP
        /// <summary>
        /// 並列な kd-tree の個数．[1..16] の範囲が適切な値です
        /// </summary>
#else
        /// <summary>
        /// The number of parallel kd-trees to use. Good values are in the range [1..16]
        /// </summary>
#endif
        public int Trees
        {
            get
            {
                unsafe
                {
                    return *FlannInvoke.flann_CompositeIndexParams_trees(ptr);
                }
            }
            set
            {
                unsafe
                {
                    *FlannInvoke.flann_CompositeIndexParams_trees(ptr) = value;
                }
            }
        }
#if LANG_JP
        /// <summary>
        /// 階層型 k-means tree で利用される branching ファクタ
        /// </summary>
#else
        /// <summary>
        /// The branching factor to use for the hierarchical k-means tree
        /// </summary>
#endif
        public int Branching
        {
            get
            {
                unsafe
                {
                    return *FlannInvoke.flann_CompositeIndexParams_branching(ptr);
                }
            }
            set
            {
                unsafe
                {
                    *FlannInvoke.flann_CompositeIndexParams_branching(ptr) = value;
                }
            }
        }
#if LANG_JP
        /// <summary>
        /// k-means tree を作成する際の，k-means クラスタリングステージでの反復数の上限．ここで -1 は，k-means クラスタリングが収束するまで続けられることを意味します
        /// </summary>
#else
        /// <summary>
        /// The maximum number of iterations to use in the k-means clustering
        /// stage when building the k-means tree. A value of -1 used here means that the k-means clustering should be iterated until convergence
        /// </summary>
#endif
        public int Iterations
        {
            get
            {
                unsafe
                {
                    return *FlannInvoke.flann_CompositeIndexParams_iterations(ptr);
                }
            }
            set
            {
                unsafe
                {
                    *FlannInvoke.flann_CompositeIndexParams_iterations(ptr) = value;
                }
            }
        }
#if LANG_JP
        /// <summary>
        /// k-means クラスタリングの初期中心を選択するアルゴリズム．
        /// </summary>
#else
        /// <summary>
        /// The algorithm to use for selecting the initial centers when performing a k-means clustering step. 
        /// </summary>
#endif
        public FlannCentersInit CentersInit
        {
            get
            {
                unsafe
                {
                    return *FlannInvoke.flann_CompositeIndexParams_centers_init(ptr);
                }
            }
            set
            {
                unsafe
                {
                    *FlannInvoke.flann_CompositeIndexParams_centers_init(ptr) = value;
                }
            }
        }
#if LANG_JP
        /// <summary>
        /// このパラメータ（クラスタ境界インデックス）は，階層的 k-means tree の探索方法に影響を与えます． 
        /// cb_index が0の場合，最も近い中心のクラスタが，次に探索される k-means 領域になります．0より大きい値の場合も，領域サイズが考慮されます
        /// </summary>
#else
        /// <summary>
        /// This parameter (cluster boundary index) influences the
        /// way exploration is performed in the hierarchical kmeans tree. When cb_index is zero the next kmeans domain to be explored 
        /// is choosen to be the one with the closest center. A value greater then zero also takes into account the size of the domain.
        /// </summary>
#endif
        public float CbIndex
        {
            get
            {
                unsafe
                {
                    return *FlannInvoke.flann_CompositeIndexParams_cb_index(ptr);
                }
            }
            set
            {
                unsafe
                {
                    *FlannInvoke.flann_CompositeIndexParams_cb_index(ptr) = value;
                }
            }
        }
        //*/
        #endregion

        #region Init & Disposal
#if LANG_JP
        /// <summary>
        /// 
        /// </summary>
        /// <param name="trees">並列な kd-tree の個数．[1..16] の範囲が適切な値です</param>
        /// <param name="branching">階層型 k-means tree で利用される branching ファクタ</param>
        /// <param name="iterations">k-means tree を作成する際の，k-means クラスタリングステージでの反復数の上限．ここで -1 は，k-means クラスタリングが収束するまで続けられることを意味します</param>
        /// <param name="centersInit">k-means クラスタリングの初期中心を選択するアルゴリズム．</param>
        /// <param name="cbIndex">このパラメータ（クラスタ境界インデックス）は，階層的 k-means tree の探索方法に影響を与えます． cb_index が0の場合，最も近い中心のクラスタが，次に探索される k-means 領域になります．0より大きい値の場合も，領域サイズが考慮されます</param>
#else
        /// <summary>
        /// 
        /// </summary>
        /// <param name="trees">The number of parallel kd-trees to use. Good values are in the range [1..16]</param>
        /// <param name="branching">The branching factor to use for the hierarchical k-means tree</param>
        /// <param name="iterations">The maximum number of iterations to use in the k-means clustering stage when building the k-means tree. A value of -1 used here means that the k-means clustering should be iterated until convergence</param>
        /// <param name="centersInit">The algorithm to use for selecting the initial centers when performing a k-means clustering step. </param>
        /// <param name="cbIndex">This parameter (cluster boundary index) influences the way exploration is performed in the hierarchical kmeans tree. When cb_index is zero the next kmeans domain to be explored is choosen to be the one with the closest center. A value greater then zero also takes into account the size of the domain.</param>
#endif
        public CompositeIndexParams(int trees = 4, int branching = 32, int iterations = 11, FlannCentersInit centersInit = FlannCentersInit.Random, float cbIndex = 0.2f)
        {
            ptr = NativeMethods.flann_CompositeIndexParams_new(trees, branching, iterations, centersInit, cbIndex);
            if (ptr == IntPtr.Zero)
                throw new OpenCvSharpException("Failed to create CompositeIndexParams");
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
            if (!disposed)
            {
                try
                {
                    if (disposing)
                    {
                    }
                    if (IsEnabledDispose)
                    {
                        if (ptr != IntPtr.Zero)
                        {
                            NativeMethods.flann_CompositeIndexParams_delete(ptr);
                        }
                        ptr = IntPtr.Zero;
                    }
                    disposed = true;
                }
                finally
                {
                    base.Dispose(disposing);
                }
            }
        }
        #endregion
    }
}
