using OpenCvSharp.Internal;

namespace OpenCvSharp;

/// <summary>
/// The base class for camera response calibration algorithms.
/// </summary>
// ReSharper disable once InconsistentNaming
public abstract class CalibrateCRF : Algorithm
{
    /// <summary>
    /// Recovers inverse camera response.
    /// </summary>
    /// <param name="src">vector of input images</param>
    /// <param name="dst">256x1 matrix with inverse camera response function</param>
    /// <param name="times">vector of exposure time values for each image</param>
    public virtual void Process(IEnumerable<Mat> src, OutputArray dst, IEnumerable<float> times)
    {
        if (src is null)
            throw new ArgumentNullException(nameof(src));
        if (dst is null)
            throw new ArgumentNullException(nameof(dst));
        if (times is null)
            throw new ArgumentNullException(nameof(times));
        dst.ThrowIfNotReady();

        var srcArray = src.Select(x => x.CvPtr).ToArray();
        var timesArray = times.ToArray();
        if (srcArray.Length != timesArray.Length)
            throw new OpenCvSharpException("src.Count() != times.Count");

        NativeMethods.HandleException(
            NativeMethods.photo_CalibrateCRF_process(ptr, srcArray, srcArray.Length, dst.CvPtr, timesArray));

        dst.Fix();
        GC.KeepAlive(this);
        GC.KeepAlive(src);
        GC.KeepAlive(dst);
    }
}
