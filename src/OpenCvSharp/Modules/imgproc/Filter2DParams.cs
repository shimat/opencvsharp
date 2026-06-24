namespace OpenCvSharp;

/// <summary>
/// Parameters for the OpenCV 5 <see cref="Cv2.Filter2D(InputArray, OutputArray, InputArray, Filter2DParams)"/> overload.
/// Mirrors cv::Filter2DParams; all fields are optional and default to the OpenCV defaults.
/// </summary>
public class Filter2DParams
{
    /// <summary>
    /// Anchor X. -1 means the anchor is at the kernel center.
    /// </summary>
    public int AnchorX { get; set; } = -1;

    /// <summary>
    /// Anchor Y. -1 means the anchor is at the kernel center.
    /// </summary>
    public int AnchorY { get; set; } = -1;

    /// <summary>
    /// Pixel extrapolation method.
    /// </summary>
    public BorderTypes BorderType { get; set; } = BorderTypes.Default;

    /// <summary>
    /// Border value used in case of a constant border.
    /// </summary>
    public Scalar BorderValue { get; set; } = new Scalar();

    /// <summary>
    /// Desired depth of the destination image. -1 means the same depth as the source.
    /// </summary>
    public int Ddepth { get; set; } = -1;

    /// <summary>
    /// Optional scale factor applied to the filtered pixels.
    /// </summary>
    public double Scale { get; set; } = 1.0;

    /// <summary>
    /// Optional value added to the filtered pixels.
    /// </summary>
    public double Shift { get; set; }
}
