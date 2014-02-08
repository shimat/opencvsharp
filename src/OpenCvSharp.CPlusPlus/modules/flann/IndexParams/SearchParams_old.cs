using System;
using System.Collections.Generic;
using System.Text;

namespace OpenCvSharp.CPlusPlus.Flann
{

#if LANG_JP
    /// <summary>
    /// 探索パラメータ
    /// </summary>
#else
    /// <summary>
    /// Search parameters
    /// </summary>
#endif
    internal class SearchParams_old
    {
#if LANG_JP
        /// <summary>
        /// checks インデックスの tree が再帰的に横断されるべき回数．
        /// </summary>
#else
        /// <summary>
        /// The number of times the tree(s) in the index should be recursively traversed.
        /// </summary>
#endif
        public int Checks { get; set; }


#if LANG_JP
        /// <summary>
        /// 
        /// </summary>
        /// <param name="checks">checks インデックスの tree が再帰的に横断されるべき回数．</param>
#else
        /// <summary>
        /// 
        /// </summary>
        /// <param name="checks">The number of times the tree(s) in the index should be recursively traversed.</param>
#endif
        public SearchParams_old(int checks = 32)
        {
            Checks = checks;
        }
    }
}
