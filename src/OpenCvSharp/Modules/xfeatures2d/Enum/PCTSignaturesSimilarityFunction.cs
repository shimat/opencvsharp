namespace OpenCvSharp;

/// <summary>
/// Similarity function selector for cv::xfeatures2d::PCTSignatures.
/// </summary>
public enum PCTSignaturesSimilarityFunction
{
    /// <summary>
    /// -d(c_i, c_j)
    /// </summary>
    Minus,

    /// <summary>
    /// e^(-alpha * d^2(c_i, c_j))
    /// </summary>
    Gaussian,

    /// <summary>
    /// 1 / (alpha + d(c_i, c_j))
    /// </summary>
    Heuristic
}
