namespace OpenCvSharp;

/// <summary>
/// Transformation flags for cv::dct
/// </summary>
[Flags]
public enum DctFlags
{
    /// <summary>
    /// 
    /// </summary>
    None = 0,

    /// <summary>
    /// Do inverse 1D or 2D transform.
    /// (Forward and Inverse are mutually exclusive, of course.)
    /// </summary>
    Inverse = 1,

    /// <summary>
    /// Do forward or inverse transform of every individual row of the input matrix. 
    /// This flag allows user to transform multiple vectors simultaneously and can be used to decrease the overhead 
    /// (which is sometimes several times larger than the processing itself), to do 3D and higher-dimensional transforms etc. 
    /// [CV_DXT_ROWS]
    /// </summary>
    Rows = 4,
}
