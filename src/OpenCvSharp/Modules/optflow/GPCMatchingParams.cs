using OpenCvSharp.Internal;

namespace OpenCvSharp.OptFlow;

/// <summary>
/// Parameters used for matching with a <see cref="GPCForest5"/>.
/// </summary>
public sealed class GPCMatchingParams
{
    /// <summary>
    /// Creates a new instance with the given OpenCL setting.
    /// </summary>
    /// <param name="useOpenCL">Whether to use OpenCL to speed up the matching.</param>
    public GPCMatchingParams(bool useOpenCL = false)
    {
        UseOpenCL = useOpenCL;
    }

    /// <summary>
    /// Whether to use OpenCL to speed up the matching. Default: false.
    /// </summary>
    public bool UseOpenCL { get; set; }

    /// <summary>
    /// Converts this instance to the blittable P/Invoke representation.
    /// </summary>
    internal CvGPCMatchingParams ToNative() => new()
    {
        UseOpenCL = UseOpenCL ? 1 : 0,
    };
}
