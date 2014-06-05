using System;
using System.Collections.Generic;
using System.Text;

namespace OpenCvSharp.CPlusPlus
{
#if LANG_JP
    /// <summary>
    /// GrabCutの処理フラグ
    /// </summary>
#else
    /// <summary>
    /// GrabCut algorithm flags
    /// </summary>
#endif
    [Flags]
    public enum GrabCutFlag : int
    {
#if LANG_JP
        /// <summary>
        /// 与えられた矩形を用いて，状態とマスクを初期化します．
        /// その後，アルゴリズムが iterCount 回繰り返されます．
        /// [GC_INIT_WITH_RECT]
        /// </summary>
#else
        /// <summary>
        ///  The function initializes the state and the mask using the provided rectangle. 
        /// After that it runs iterCount iterations of the algorithm.
        /// [GC_INIT_WITH_RECT]
        /// </summary>
#endif
        InitWithRect = CppConst.GC_INIT_WITH_RECT,


#if LANG_JP
        /// <summary>
        /// 与えられたマスクを用いて状態を初期化します． 
        /// GC_INIT_WITH_RECT と GC_INIT_WITH_MASK は，一緒に使うことができる
        /// ことに注意してください．そして，ROIの外側の全ピクセルは自動的に 
        /// GC_BGD として初期化されます．
        /// [GC_INIT_WITH_MASK]
        /// </summary>
#else
        /// <summary>
        ///  The function initializes the state using the provided mask. 
        /// Note that GC_INIT_WITH_RECT and GC_INIT_WITH_MASK can be combined. 
        /// Then, all the pixels outside of the ROI are automatically initialized with GC_BGD .
        /// [GC_INIT_WITH_MASK]
        /// </summary>
#endif
        InitWithMask = CppConst.GC_INIT_WITH_MASK,


#if LANG_JP
        /// <summary>
        /// アルゴリズムがすぐに再開することを意味する値．
        /// [GC_EVAL]
        /// </summary>
#else
        /// <summary>
        ///  The value means that the algorithm should just resume.
        /// [GC_EVAL]
        /// </summary>
#endif
        Rows = CppConst.GC_EVAL,
    }
}
