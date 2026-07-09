namespace OpenCvSharp;

/// <summary>
/// Imwrite JPEG specific values for IMWRITE_JPEG_SAMPLING_FACTOR parameter key.
/// </summary>
public enum ImwriteJPEGSamplingFactorParams
{
    /// <summary>
    /// 4x1,1x1,1x1
    /// </summary>
    Factor411 = 0x411111,

    /// <summary>
    /// 2x2,1x1,1x1 (Default)
    /// </summary>
    Factor420 = 0x221111,

    /// <summary>
    /// 2x1,1x1,1x1
    /// </summary>
    Factor422 = 0x211111,

    /// <summary>
    /// 1x2,1x1,1x1
    /// </summary>
    Factor440 = 0x121111,

    /// <summary>
    /// 1x1,1x1,1x1 (No subsampling)
    /// </summary>
    Factor444 = 0x111111
}
