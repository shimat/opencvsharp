using OpenCvSharp.Internal;

namespace OpenCvSharp;

/// <summary>
/// The base class algorithms that can merge exposure sequence to a single image.
/// </summary>
public abstract class MergeExposures : Algorithm
{
    /// <inheritdoc />
    protected MergeExposures(IntPtr smartPtr, IntPtr rawPtr, Action<IntPtr> release)
        : base(smartPtr, rawPtr, release) { }

    /// <summary>
    /// Merges images.
    /// </summary>
    /// <param name="src">vector of input images</param>
    /// <param name="dst">result image</param>
    /// <param name="times">vector of exposure time values for each image</param>
    /// <param name="response"> 256x1 matrix with inverse camera response function for each pixel value, it should have the same number of channels as images.</param>
    public virtual void Process(IEnumerable<Mat> src, OutputArray dst, IEnumerable<float> times, InputArray response)
    {
        ArgumentNullException.ThrowIfNull(src);
        ArgumentNullException.ThrowIfNull(times);

        var srcArray = src.Select(s => s.CvPtr).ToArray();
        var timesArray = times as float[] ?? times.ToArray();
        if (srcArray.Length != timesArray.Length)
            throw new OpenCvSharpException("src.Count() != times.Count");
            
        NativeMethods.HandleException(
            NativeMethods.photo_MergeExposures_process(Handle, srcArray, srcArray.Length, dst.Proxy, timesArray, response.Proxy));

        GC.KeepAlive(src);
        GC.KeepAlive(dst.Source);
        GC.KeepAlive(response.Source);
        GC.KeepAlive(srcArray);
        GC.KeepAlive(timesArray);
    }
}
