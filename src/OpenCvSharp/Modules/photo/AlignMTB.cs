using OpenCvSharp.Internal;
using OpenCvSharp.Internal.Vectors;

namespace OpenCvSharp;

/// <summary>
/// Aligns an exposure sequence using median threshold bitmaps.
/// </summary>
public sealed class AlignMTB : Algorithm
{
    private AlignMTB(IntPtr smartPtr, IntPtr rawPtr)
        : base(smartPtr, rawPtr, static p => NativeMethods.HandleException(NativeMethods.photo_Ptr_AlignMTB_delete(p)))
    {
    }

    /// <summary>Creates an exposure aligner.</summary>
    public static AlignMTB Create(int maxBits = 6, int excludeRange = 4, bool cut = true)
    {
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(maxBits);
        ArgumentOutOfRangeException.ThrowIfNegative(excludeRange);
        NativeMethods.HandleException(NativeMethods.photo_AlignMTB_create(maxBits, excludeRange, cut ? 1 : 0, out var smartPtr));
        NativeMethods.HandleException(NativeMethods.photo_Ptr_AlignMTB_get(smartPtr, out var rawPtr));
        return new AlignMTB(smartPtr, rawPtr);
    }

    /// <summary>Aligns images without exposure times or a camera response curve.</summary>
    public Mat[] Process(IEnumerable<Mat> src)
    {
        ThrowIfDisposed();
        ArgumentNullException.ThrowIfNull(src);
        var images = src.ToArray();
        using var input = new VectorOfMat(images);
        using var output = new VectorOfMat();
        NativeMethods.HandleException(NativeMethods.photo_AlignMTB_processShort(Handle, input.CvPtr, output.CvPtr));
        GC.KeepAlive(this);
        GC.KeepAlive(images);
        return output.ToArray();
    }

    /// <summary>Aligns images. OpenCV 5.0.0 ignores times and response for this aligner.</summary>
    public Mat[] Process(IEnumerable<Mat> src, InputArray times, InputArray response)
    {
        ThrowIfDisposed();
        ArgumentNullException.ThrowIfNull(src);
        var images = src.ToArray();
        using var input = new VectorOfMat(images);
        using var output = new VectorOfMat();
        NativeMethods.HandleException(NativeMethods.photo_AlignMTB_process(Handle, input.CvPtr, output.CvPtr, times.Proxy, response.Proxy));
        GC.KeepAlive(this);
        GC.KeepAlive(images);
        GC.KeepAlive(times.Source);
        GC.KeepAlive(response.Source);
        return output.ToArray();
    }

    /// <summary>Calculates the shift needed to align the second image to the first.</summary>
    public Point CalculateShift(InputArray img0, InputArray img1)
    {
        ThrowIfDisposed();
        NativeMethods.HandleException(NativeMethods.photo_AlignMTB_calculateShift(Handle, img0.Proxy, img1.Proxy, out var shift));
        GC.KeepAlive(this);
        GC.KeepAlive(img0.Source);
        GC.KeepAlive(img1.Source);
        return shift;
    }

    /// <summary>Shifts an image, filling new regions with zeros.</summary>
    public void ShiftMat(InputArray src, OutputArray dst, Point shift)
    {
        ThrowIfDisposed();
        NativeMethods.HandleException(NativeMethods.photo_AlignMTB_shiftMat(Handle, src.Proxy, dst.Proxy, shift));
        GC.KeepAlive(this);
        GC.KeepAlive(src.Source);
        GC.KeepAlive(dst.Source);
    }

    /// <summary>Computes the median threshold and exclusion bitmaps.</summary>
    public void ComputeBitmaps(InputArray img, OutputArray thresholdBitmap, OutputArray exclusionBitmap)
    {
        ThrowIfDisposed();
        NativeMethods.HandleException(NativeMethods.photo_AlignMTB_computeBitmaps(
            Handle, img.Proxy, thresholdBitmap.Proxy, exclusionBitmap.Proxy));
        GC.KeepAlive(this);
        GC.KeepAlive(img.Source);
        GC.KeepAlive(thresholdBitmap.Source);
        GC.KeepAlive(exclusionBitmap.Source);
    }

    /// <summary>Maximum alignment shift as a power of two.</summary>
    public int MaxBits
    {
        get
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(NativeMethods.photo_AlignMTB_getMaxBits(Handle, out var value));
            return value;
        }
        set
        {
            ThrowIfDisposed();
            ArgumentOutOfRangeException.ThrowIfNegativeOrZero(value);
            NativeMethods.HandleException(NativeMethods.photo_AlignMTB_setMaxBits(Handle, value));
        }
    }

    /// <summary>Noise exclusion range around the median.</summary>
    public int ExcludeRange
    {
        get
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(NativeMethods.photo_AlignMTB_getExcludeRange(Handle, out var value));
            return value;
        }
        set
        {
            ThrowIfDisposed();
            ArgumentOutOfRangeException.ThrowIfNegative(value);
            NativeMethods.HandleException(NativeMethods.photo_AlignMTB_setExcludeRange(Handle, value));
        }
    }

    /// <summary>Whether alignment crops images instead of filling new regions with zeros.</summary>
    public bool Cut
    {
        get
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(NativeMethods.photo_AlignMTB_getCut(Handle, out var value));
            return value != 0;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(NativeMethods.photo_AlignMTB_setCut(Handle, value ? 1 : 0));
        }
    }
}
