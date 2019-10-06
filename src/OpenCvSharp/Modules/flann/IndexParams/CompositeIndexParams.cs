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
        public CompositeIndexParams(int trees = 4, int branching = 32, int iterations = 11,
            FlannCentersInit centersInit = FlannCentersInit.Random, float cbIndex = 0.2f)
            : base(null)
        {
            IntPtr p = NativeMethods.flann_Ptr_CompositeIndexParams_new(trees, branching, iterations, centersInit, cbIndex);
            if (p == IntPtr.Zero)
                throw new OpenCvSharpException($"Failed to create {nameof(AutotunedIndexParams)}");

            PtrObj = new Ptr(p);
            ptr = PtrObj.Get();
        }
        
        /// <summary>
        /// 
        /// </summary>
        protected CompositeIndexParams(OpenCvSharp.Ptr ptrObj)
            : base(ptrObj)
        {
        }

        internal new class Ptr : OpenCvSharp.Ptr
        {
            public Ptr(IntPtr ptr) : base(ptr)
            {
            }

            public override IntPtr Get()
            {
                var res = NativeMethods.flann_Ptr_CompositeIndexParams_get(ptr);
                GC.KeepAlive(this);
                return res;
            }

            protected override void DisposeUnmanaged()
            {
                NativeMethods.flann_Ptr_CompositeIndexParams_delete(ptr);
                base.DisposeUnmanaged();
            }
        }
    }
}
