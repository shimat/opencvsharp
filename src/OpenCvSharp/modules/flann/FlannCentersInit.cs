using System;
using System.Collections.Generic;
using System.Text;

namespace OpenCvSharp.Flann
{

#if LANG_JP
    /// <summary>
	/// k-means クラスタリングの初期中心を選択するアルゴリズム．
	/// </summary>
#else
    /// <summary>
    /// The algorithm to use for selecting the initial centers when performing a k-means clustering step. 
    /// </summary>
#endif
    public enum FlannCentersInit : int
    {
#if LANG_JP
        /// <summary>
        /// ランダムに初期クラスタ中心を選択
        /// [flann_centers_init_t::CENTERS_RANDOM]
        /// </summary>
#else
        /// <summary>
        /// picks the initial cluster centers randomly
        /// [flann_centers_init_t::CENTERS_RANDOM]
        /// </summary>
#endif
        Random = 0,

#if LANG_JP
        /// <summary>
        /// Gonzalesのアルゴリズムを用いて初期クラスタ中心を選択
        /// [flann_centers_init_t::CENTERS_GONZALES]
        /// </summary>
#else
        /// <summary>
        /// picks the initial centers using Gonzales’ algorithm
        /// [flann_centers_init_t::CENTERS_GONZALES]
        /// </summary>
#endif
        Gonzales = 1,

#if LANG_JP
        /// <summary>
        /// arthur_kmeanspp_2007 で提案されたアルゴリズムを用いて初期クラスタ中心を選択
        /// [flann_centers_init_t::CENTERS_KMEANSPP]
        /// </summary>
#else
        /// <summary>
        /// picks the initial centers using the algorithm suggested in [arthur_kmeanspp_2007]
        /// [flann_centers_init_t::CENTERS_KMEANSPP]
        /// </summary>
#endif
        KMeansPP = 2

    }
}


