
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
    public enum ReduceTypes : int
    {
#if LANG_JP
        /// <summary>
        /// 出力は各行（または各列）の総和
        /// </summary>
#else
        /// <summary>
        /// The output is the sum of all the matrix rows/columns.
        /// </summary>
#endif
        Sum = 0,


#if LANG_JP
        /// <summary>
        /// 出力は各行（または各列）の平均ベクトル
        /// </summary>
#else
        /// <summary>
        /// The output is the mean vector of all the matrix rows/columns.
        /// </summary>
#endif
        Avg = 1,


#if LANG_JP
        /// <summary>
        /// 出力は各行（または各列）における最大値
        /// </summary>
#else
        /// <summary>
        /// The output is the maximum (column/row-wise) of all the matrix rows/columns.
        /// </summary>
#endif
        Max = 2,


#if LANG_JP
        /// <summary>
        /// 出力は各行（または各列）における最小値
        /// </summary>
#else
        /// <summary>
        /// The output is the minimum (column/row-wise) of all the matrix rows/columns.
        /// </summary>
#endif
        Min = 3,
    }
}
