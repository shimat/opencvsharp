using System;

namespace OpenCvSharp
{
    /// <summary>
    /// Signals an error and raises the exception.
    /// </summary>
    [Flags]
    public enum SortFlags
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
