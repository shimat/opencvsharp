using System.Runtime.InteropServices;

namespace OpenCvSharp;

#pragma warning disable CA1815

/// <summary>
/// Parameters for the QRCodeDetectorAruco (cv::QRCodeDetectorAruco::Params).
/// </summary>
[StructLayout(LayoutKind.Sequential)]
public struct QRCodeDetectorArucoParams
{
    /// <summary>
    /// The minimum allowed pixel size of a QR module in the smallest image in the image pyramid, default 4.f
    /// </summary>
    public float MinModuleSizeInPyramid = 4.0f;

    /// <summary>
    /// max rotation of a finder pattern marker, default pi/12
    /// </summary>
    public float MaxRotation = (float)(Math.PI / 12);

    /// <summary>
    /// The maximum allowed relative mismatch in module sizes, default 1.75f
    /// </summary>
    public float MaxModuleSizeMismatch = 1.75f;

    /// <summary>
    /// The maximum allowed mismatch between the timing pattern and the black-white module pattern, default 2.f
    /// </summary>
    public float MaxTimingPatternMismatch = 2.0f;

    /// <summary>
    /// The maximum allowed percentage of penalty points out of total pins in timing pattern, default 0.4f
    /// </summary>
    public float MaxPenalties = 0.4f;

    /// <summary>
    /// The maximum allowed relative color mismatch in the timing pattern, default 0.2f
    /// </summary>
    public float MaxColorsMismatch = 0.2f;

    /// <summary>
    /// Scale of timing pattern score, default 0.9f
    /// </summary>
    public float ScaleTimingPatternScore = 0.9f;

    /// <summary>
    /// Constructor
    /// </summary>
    public QRCodeDetectorArucoParams()
    {
    }
}
