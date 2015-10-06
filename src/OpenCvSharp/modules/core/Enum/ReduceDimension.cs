
namespace OpenCvSharp
{
#if LANG_JP
    /// <summary>
    /// cvReduceで、配列をどのように縮小するかを示すインデックス
    /// </summary>
#else
    /// <summary>
    /// The dimension index along which the matrix is reduce.
    /// </summary>
#endif
    public enum ReduceDimension
    {
#if LANG_JP
        /// <summary>
        /// 行列を1行ベクトルに縮小する
        /// [= 0]
        /// </summary>
#else
        /// <summary>
        /// The matrix is reduced to a single row.
        /// [= 0]
        /// </summary>
#endif
        Row = 0,

#if LANG_JP
        /// <summary>
        /// 行列を1列ベクトルに縮小する
        /// [= 1]
        /// </summary>
#else
        /// <summary>
        /// The matrix is reduced to a single column.
        /// [= 1]
        /// </summary>
#endif
        Column = 1,

#if LANG_JP
        /// <summary>
        /// 出力行列のサイズから次元を解析し，自動的に選択する
        /// [= -1]
        /// </summary>
#else
        /// <summary>
        /// The dimension is chosen automatically by analysing the dst size. 
        /// [= -1]
        /// </summary>
#endif
        Auto = -1
    }
}
