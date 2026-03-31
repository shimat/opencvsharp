namespace OpenCvSharp.XImgProc;

/// <summary>
/// Gradient operators for EdgeDrawing.
/// </summary>
public enum GradientOperator
{
    /// <summary>
    /// Prewitt operator.
    /// </summary>
    Prewitt = 0,

    /// <summary>
    /// Sobel operator.
    /// </summary>
    Sobel = 1,

    /// <summary>
    /// Scharr operator.
    /// </summary>
    Scharr = 2,

    /// <summary>
    /// Line Segment Detector operator.
    /// </summary>
    LSD = 3,
}
