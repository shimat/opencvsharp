namespace OpenCvSharp;

/// <summary>
/// Enum of the possible types of the initial method used to calculate the initial CCM value.
/// </summary>
public enum InitialMethodType
{
    /// <summary>
    /// The white balance method.
    /// </summary>
    WhiteBalance,

    /// <summary>
    /// The least square method, an optimal solution under the linear RGB distance function.
    /// </summary>
    LeastSquare,
}
