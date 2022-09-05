using System.Diagnostics.CodeAnalysis;

namespace OpenCvSharp;

/// <summary>
/// The reduction operations for cvReduce
/// </summary>
/// <remarks>
///https://github.com/opencv/opencv/blob/37c12db3668a1fbbfdb286be59f662c67cfbfea1/modules/core/include/opencv2/core.hpp#L231
/// </remarks>
[SuppressMessage("Microsoft.Design", "CA1717: Only FlagsAttribute enums should have plural names")]
public enum ReduceTypes
{
    /// <summary>
    /// The output is the sum of all the matrix rows/columns.
    /// </summary>
    Sum = 0,

    /// <summary>
    /// The output is the mean vector of all the matrix rows/columns.
    /// </summary>
    Avg = 1,

    /// <summary>
    /// The output is the maximum (column/row-wise) of all the matrix rows/columns.
    /// </summary>
    Max = 2,

    /// <summary>
    /// The output is the minimum (column/row-wise) of all the matrix rows/columns.
    /// </summary>
    Min = 3,
}
