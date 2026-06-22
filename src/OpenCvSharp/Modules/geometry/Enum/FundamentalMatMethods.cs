namespace OpenCvSharp;

/// <summary>
/// Method for computing the fundamental matrix 
/// </summary>
[Flags]
public enum FundamentalMatMethods
{
    /// <summary>
    /// for 7-point algorithm. N == 7 
    /// </summary>
    Point7 = 1,

    /// <summary>
    /// for 8-point algorithm. N >= 8 
    /// [CV_FM_8POINT]
    /// </summary>
    Point8 = 2,

    /// <summary>
    /// for LMedS algorithm. N > 8 
    /// </summary>
    LMedS = 4,

    /// <summary>
    /// for RANSAC algorithm. N > 8 
    /// </summary>
    Ransac = 8,
}
