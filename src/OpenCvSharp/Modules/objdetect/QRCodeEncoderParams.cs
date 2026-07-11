using System.Runtime.InteropServices;

namespace OpenCvSharp;

#pragma warning disable CA1815

/// <summary>
/// Parameters for the QRCodeEncoder (cv::QRCodeEncoder::Params).
/// </summary>
[StructLayout(LayoutKind.Sequential)]
public struct QRCodeEncoderParams
{
    /// <summary>
    /// The version of QR Code ranges from Version 1 to Version 40, augmented with a value of 0 for the encoder to select the minimum required version.
    /// </summary>
    public int Version = 0;

    /// <summary>
    /// The error correction level of the QR Code.
    /// </summary>
    public QRCodeEncoderCorrectionLevel CorrectionLevel = QRCodeEncoderCorrectionLevel.L;

    /// <summary>
    /// The encoding mode of the QR Code.
    /// </summary>
    public QRCodeEncoderMode Mode = QRCodeEncoderMode.Auto;

    /// <summary>
    /// The number of QR Codes to generate in structured append mode.
    /// </summary>
    public int StructureNumber = 1;

    /// <summary>
    /// Constructor
    /// </summary>
    public QRCodeEncoderParams()
    {
    }
}
