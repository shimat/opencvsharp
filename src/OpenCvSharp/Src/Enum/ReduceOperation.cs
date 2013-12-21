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
    /// cvReduceで用いる縮小処理の種類
    /// </summary>
#else
    /// <summary>
    /// The reduction operations for cvReduce
    /// </summary>
#endif
    public enum ReduceOperation : int
    {
#if LANG_JP
        /// <summary>
        /// 出力は各行（または各列）の総和
        /// [CV_REDUCE_SUM]
        /// </summary>
#else
        /// <summary>
        /// The output is the sum of all the matrix rows/columns.
        /// [CV_REDUCE_SUM]
        /// </summary>
#endif
        Sum = CvConst.CV_REDUCE_SUM,


#if LANG_JP
        /// <summary>
        /// 出力は各行（または各列）の平均ベクトル
        /// [CV_REDUCE_AVG]
        /// </summary>
#else
        /// <summary>
        /// The output is the mean vector of all the matrix rows/columns.
        /// [CV_REDUCE_AVG]
        /// </summary>
#endif
        Avg = CvConst.CV_REDUCE_AVG,


#if LANG_JP
        /// <summary>
        /// 出力は各行（または各列）における最大値
        /// [CV_REDUCE_MAX]
        /// </summary>
#else
        /// <summary>
        /// The output is the maximum (column/row-wise) of all the matrix rows/columns.
        /// [CV_REDUCE_MAX]
        /// </summary>
#endif
        Max = CvConst.CV_REDUCE_MAX,


#if LANG_JP
        /// <summary>
        /// 出力は各行（または各列）における最小値
        /// [CV_REDUCE_MIN]
        /// </summary>
#else
        /// <summary>
        /// The output is the minimum (column/row-wise) of all the matrix rows/columns.
        /// [CV_REDUCE_MIN]
        /// </summary>
#endif
        Min = CvConst.CV_REDUCE_MIN,
    }
}
