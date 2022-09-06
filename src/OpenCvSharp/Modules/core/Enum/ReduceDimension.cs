
namespace OpenCvSharp;

/// <summary>
/// The dimension index along which the matrix is reduce.
/// </summary>
public enum ReduceDimension
{
    /// <summary>
    /// The matrix is reduced to a single row.
    /// [= 0]
    /// </summary>
    Row = 0,

    /// <summary>
    /// The matrix is reduced to a single column.
    /// [= 1]
    /// </summary>
    Column = 1,

    /// <summary>
    /// The dimension is chosen automatically by analysing the dst size. 
    /// [= -1]
    /// </summary>
    Auto = -1
}
