namespace OpenCvSharp;

// ReSharper disable InconsistentNaming
/// <summary>
/// Type of norm
/// </summary>
[Flags]
public enum NormTypes
{
    /// <summary>
    /// 
    /// </summary>
    INF = 1,

    /// <summary>
    /// The L1-norm (sum of absolute values) of the array is normalized.
    /// </summary>
    L1 = 2,

    /// <summary>
    /// The (Euclidean) L2-norm of the array is normalized.
    /// </summary>
    L2 = 4,

    /// <summary>
    /// 
    /// </summary>
    L2SQR = 5,

    /// <summary>
    ///
    /// </summary>
    Hamming = 6,

    /// <summary>
    /// 
    /// </summary>
    Hamming2 = 7,

    /// <summary>
    /// 
    /// </summary>
    Relative = 8,

    /// <summary>
    /// The array values are scaled and shifted to the specified range.
    /// </summary>
    MinMax = 32,
}
