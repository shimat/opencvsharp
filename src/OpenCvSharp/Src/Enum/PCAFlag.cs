/*
 * (C) 2008-2013 Schima
 * This code is licenced under the LGPL.
 */

using System;
using System.Collections.Generic;
using System.Text;

namespace OpenCvSharp
{
#if LANG_JP
    /// <summary>
    /// cvCalcPCAの操作フラグ
    /// </summary>
#else
    /// <summary>
    /// Flags for PCA operations
    /// </summary>
#endif
    [Flags]
    public enum PCAFlag : int
    {
#if LANG_JP
        /// <summary>
        /// 行としてベクトルが保存される（つまり，あるベクトルの全ての要素は連続的に保存される）
        /// [CV_PCA_DATA_AS_ROW]
        /// </summary>
#else
        /// <summary>
        /// The vectors are stored as rows (i.e. all the components of a certain vector are stored continously)
        /// [CV_PCA_DATA_AS_ROW]
        /// </summary>
#endif
        DataAsRow = CvConst.CV_PCA_DATA_AS_ROW,


#if LANG_JP
        /// <summary>
        /// 列としてベクトルが保存される（つまり，あるベクトル成分に属する値は連続的に保存される）
        /// [CV_PCA_DATA_AS_COL]
        /// </summary>
#else
        /// <summary>
        /// The vectors are stored as columns (i.e. values of a certain vector component are stored continuously)
        /// [CV_PCA_DATA_AS_COL]
        /// </summary>
#endif
        DataAsCol = CvConst.CV_PCA_DATA_AS_COL,


#if LANG_JP
        /// <summary>
        /// 事前に計算された平均ベクトルを用いる
        /// [CV_PCA_USE_AVG]
        /// </summary>
#else
        /// <summary>
        /// Use pre-computed average vector
        /// [CV_PCA_USE_AVG]
        /// </summary>
#endif
        UseAvg = CvConst.CV_PCA_USE_AVG,
    }
}
