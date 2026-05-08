namespace OpenCvSharp.XImgProc;

/// <summary>
/// Gradient operators for EdgeDrawing.
/// </summary>
public enum GradientOperator
{
    /// <summary>
    /// Prewitt operator.
    /// </summary>
    PREWITT = 0,

    /// <summary>
    /// Sobel operator.
    /// </summary>
    SOBEL = 1,

    /// <summary>
    /// Scharr operator.
    /// </summary>
    SCHARR = 2,

    /// <summary>
    /// Line Segment Detector operator.
    /// </summary>
    LSD = 3,
}
