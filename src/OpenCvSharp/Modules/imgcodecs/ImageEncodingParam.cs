namespace OpenCvSharp;

/// <summary>
/// The format-specific save parameters for cv::imwrite and cv::imencode
/// </summary>
// TODO record
[Serializable]
public record ImageEncodingParam
{
    /// <summary>
    /// format type ID
    /// </summary>
    public ImwriteFlags EncodingId { get; }

    /// <summary>
    /// value of parameter
    /// </summary>
    public int Value { get; }

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="id">format type ID</param>
    /// <param name="value">value of parameter</param>
    public ImageEncodingParam(ImwriteFlags id, int value)
    {
        EncodingId = id;
        Value = value;
    }
}
