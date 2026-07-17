using OpenCvSharp.Internal;

namespace OpenCvSharp.Detail;

/// <summary>
/// Blender which uses a multi-band blending algorithm.
/// </summary>
public class MultiBandBlender : Blender
{
    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="tryGpu">Should try to use GPU or not</param>
    /// <param name="numBands">Number of bands</param>
    /// <param name="weightType">Type of pyramid weights (CV_32F or CV_16S)</param>
    public MultiBandBlender(bool tryGpu = false, int numBands = 5, MatType? weightType = null)
        : base(Create(tryGpu, numBands, weightType?.Value ?? MatType.CV_32F), static h =>
            NativeMethods.HandleException(NativeMethods.stitching_MultiBandBlender_delete(h)))
    {
    }

    private static IntPtr Create(bool tryGpu, int numBands, int weightType)
    {
        NativeMethods.HandleException(
            NativeMethods.stitching_MultiBandBlender_new(tryGpu ? 1 : 0, numBands, weightType, out var ptr));
        return ptr;
    }

    /// <summary>
    /// Number of bands used in the multi-band blending algorithm.
    /// </summary>
    public int NumBands
    {
        get
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(NativeMethods.stitching_MultiBandBlender_getNumBands(Handle, out var ret));
            return ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(NativeMethods.stitching_MultiBandBlender_setNumBands(Handle, value));
        }
    }
}
