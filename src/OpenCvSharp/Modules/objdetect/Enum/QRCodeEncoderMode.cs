namespace OpenCvSharp;

/// <summary>
/// cv::QRCodeEncoder::EncodeMode
/// </summary>
public enum QRCodeEncoderMode
{
    /// <summary>
    /// MODE_AUTO
    /// </summary>
    Auto = -1,

    /// <summary>
    /// MODE_NUMERIC
    /// </summary>
    Numeric = 1,

    /// <summary>
    /// MODE_ALPHANUMERIC
    /// </summary>
    Alphanumeric = 2,

    /// <summary>
    /// MODE_STRUCTURED_APPEND
    /// </summary>
    StructuredAppend = 3,

    /// <summary>
    /// MODE_BYTE
    /// </summary>
    Byte = 4,

    /// <summary>
    /// MODE_ECI
    /// </summary>
    ECI = 7,

    /// <summary>
    /// MODE_KANJI
    /// </summary>
    Kanji = 8,
}
