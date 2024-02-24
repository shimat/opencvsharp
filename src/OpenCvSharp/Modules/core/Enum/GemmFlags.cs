namespace OpenCvSharp;

// ReSharper disable InconsistentNaming
/// <summary>
/// The operation flags for cv::GEMM
/// </summary>
[Flags]
public enum GemmFlags
{
    /// <summary>
    /// 
    /// </summary>
    None = 0,

    /// <summary>
    /// Transpose src1
    /// </summary>
    A_T = 1,

    /// <summary>
    /// Transpose src2
    /// </summary>
    B_T = 2,

    /// <summary>
    /// Transpose src3
    /// </summary>
    C_T = 4,
}
