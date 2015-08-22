using System;

namespace OpenCvSharp
{
#if LANG_JP
    /// <summary>
    /// cv::sortで用いる、配列の並び順指定
    /// </summary>
#else
    /// <summary>
    /// Signals an error and raises the exception.
    /// </summary>
#endif
    [Flags]
    public enum SortFlags : int
    {
        /// <summary>
        /// each matrix row is sorted independently
        /// </summary>
        EveryRow = 0,

        /// <summary>
        /// each matrix column is sorted independently; 
        /// this flag and the previous one are mutually exclusive.
        /// </summary>
        EveryColumn = 1,

        /// <summary>
        /// each matrix row is sorted in the ascending order.
        /// </summary>
        Ascending = 0,

        /// <summary>
        /// each matrix row is sorted in the descending order; 
        /// this flag and the previous one are also mutually exclusive.
        /// </summary>
        Descending = 16,
    }
}
