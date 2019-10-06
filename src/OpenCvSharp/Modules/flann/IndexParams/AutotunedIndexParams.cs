using System;
using System.Collections.Generic;
using System.Text;

namespace OpenCvSharp.Flann
{
#if LANG_JP
    /// <summary>
    /// 階層型 k-means tree で表現されるインデックス．
    /// </summary>
#else
    /// <summary>
    /// hierarchical k-means tree.
    /// </summary>
#endif
    public class AutotunedIndexParams : IndexParams
    {
#if LANG_JP
        /// <summary>
        /// 
        /// </summary>
        /// <param name="targetPrecision">どれだけ厳密な最近傍を返すかという，最近傍探索の近似の割合を指定する 0から1の間の値．このパラメータが大きくなると，より正確な結果が得られますが，探索時間が長くなります．最適な値は，アプリケーションに依存します</param>
        /// <param name="buildWeight">最近傍探索時間に対するインデックスの構築時間の重要度を指定します．
        /// その後のインデックス探索時間が高速になるならば，インデックスの構築時間が長くても良いというアプリケーションが存在する一方で，インデックスの探索時間が多少長くなっても，できるだけ高速にインデックスを構築する必要があるアプリケーションもあります</param>
        /// <param name="memoryWeight">これは，（インデックスの構築時間と探索時間）とインデックスの占有メモリとの，トレードオフを指定するのに利用されます．
        /// 1より小さい値は消費時間を重要視し，1より大きい値はメモリ使用量を重要視します</param>
        /// <param name="sampleFraction">パラメータの自動設定アルゴリズムにおけるデータ集合の比率を示す，0から1の間の値．
        /// 全データ集合を用いてアルゴリズムを実行すると，最も正確な結果が得られますが，巨大なデータ集合に対しては長い計算時間がかかります．
        /// このような場合，データをある比率分だけ使うことでアルゴリズムを高速化し，なおかつ，最適なパラメータの良い近似となる結果を得ることができます</param>
#else
        /// <summary>
        /// 
        /// </summary>
        /// <param name="targetPrecision">Is a number between 0 and 1 specifying the percentage of the approximate nearest-neighbor searches that return the exact nearest-neighbor. 
        /// Using a higher value for this parameter gives more accurate results, but the search takes longer. The optimum value usually depends on the application.</param>
        /// <param name="buildWeight">Specifies the importance of the index build time raported to the nearest-neighbor search time. 
        /// In some applications it’s acceptable for the index build step to take a long time if the subsequent searches in the index can be performed very fast. 
        /// In other applications it’s required that the index be build as fast as possible even if that leads to slightly longer search times.</param>
        /// <param name="memoryWeight">Is used to specify the tradeoff between time (index build time and search time) and memory used by the index. 
        /// A value less than 1 gives more importance to the time spent and a value greater than 1 gives more importance to the memory usage.</param>
        /// <param name="sampleFraction">Is a number between 0 and 1 indicating what fraction of the dataset to use in the automatic parameter configuration algorithm. 
        /// Running the algorithm on the full dataset gives the most accurate results, but for very large datasets can take longer than desired. 
        /// In such case using just a fraction of the data helps speeding up this algorithm while still giving good approximations of the optimum parameters.</param>
#endif
        public AutotunedIndexParams(float targetPrecision = 0.9f, float buildWeight = 0.01f, float memoryWeight = 0, float sampleFraction = 0.1f)
            : base(null)
        {
            IntPtr p = NativeMethods.flann_Ptr_AutotunedIndexParams_new(targetPrecision, buildWeight, memoryWeight, sampleFraction);
            if (p == IntPtr.Zero)
                throw new OpenCvSharpException($"Failed to create {nameof(AutotunedIndexParams)}");

            PtrObj = new Ptr(p);
            ptr = PtrObj.Get();
        }

        /// <summary>
        /// 
        /// </summary>
        protected AutotunedIndexParams(OpenCvSharp.Ptr ptrObj)
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
                var res = NativeMethods.flann_Ptr_AutotunedIndexParams_get(ptr);
                GC.KeepAlive(this);
                return res;
            }

            protected override void DisposeUnmanaged()
            {
                NativeMethods.flann_Ptr_AutotunedIndexParams_delete(ptr);
                base.DisposeUnmanaged();
            }
        }
    }
}
