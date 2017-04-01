using System;
using System.Collections.Generic;
using System.Text;

namespace OpenCvSharp.Flann
{
#if LANG_JP
    /// <summary>
    /// ランダム kd-tree の集合でインデックスが表現され，これは並列に探索されます．
    /// </summary>
#else
    /// <summary>
    /// When passing an object of this type the index constructed will consist of a set
    /// of randomized kd-trees which will be searched in parallel.
    /// </summary>
#endif
    public class KDTreeIndexParams : IndexParams
    {
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
                    return *FlannInvoke.flann_KDTreeIndexParams_trees(ptr);
                }
            }
            set
            {
                unsafe
                {
                    *FlannInvoke.flann_KDTreeIndexParams_trees(ptr) = value;
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
#else
        /// <summary>
        /// 
        /// </summary>
        /// <param name="trees">The number of parallel kd-trees to use. Good values are in the range [1..16]</param>
#endif
        public KDTreeIndexParams(int trees = 4)
        {
            ptr = NativeMethods.flann_KDTreeIndexParams_new(trees);
            if (ptr == IntPtr.Zero)
                throw new OpenCvSharpException("Failed to create KDTreeIndexParams");
        }

        /// <summary>
        /// Releases unmanaged resources
        /// </summary>
        protected override void DisposeUnmanaged()
        {
            NativeMethods.flann_KDTreeIndexParams_delete(ptr);
            base.DisposeUnmanaged();
        }

        #endregion
    }
}
