using OpenCvSharp.Internal;

namespace OpenCvSharp;

/// <summary>
/// The base class algorithms that can merge exposure sequence to a single image.
/// </summary>
public abstract class MergeExposures : Algorithm
{
    /// <summary>
    /// Merges images.
    /// </summary>
    /// <param name="src">vector of input images</param>
    /// <param name="dst">result image</param>
    /// <param name="times">vector of exposure time values for each image</param>
    /// <param name="response"> 256x1 matrix with inverse camera response function for each pixel value, it should have the same number of channels as images.</param>
    public virtual void Process(IEnumerable<Mat> src, OutputArray dst, IEnumerable<float> times, InputArray response)
    {
        if (src is null)
            throw new ArgumentNullException(nameof(src));
        if (dst is null)
            throw new ArgumentNullException(nameof(dst));
        if (times is null)
            throw new ArgumentNullException(nameof(times));
        if (response is null)
            throw new ArgumentNullException(nameof(response));
        dst.ThrowIfNotReady();

        var srcArray = src.Select(s => s.CvPtr).ToArray();
        var timesArray = times as float[] ?? times.ToArray();
        if (srcArray.Length != timesArray.Length)
            throw new OpenCvSharpException("src.Count() != times.Count");
            
        NativeMethods.photo_MergeExposures_process(ptr, srcArray, srcArray.Length, dst.CvPtr, timesArray, response.CvPtr);

        dst.Fix();
        GC.KeepAlive(this);
        GC.KeepAlive(src);
        GC.KeepAlive(dst);
        GC.KeepAlive(response);
        GC.KeepAlive(srcArray);
        GC.KeepAlive(timesArray);
    }
}
