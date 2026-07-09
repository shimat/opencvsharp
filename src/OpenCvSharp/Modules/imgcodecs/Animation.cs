using OpenCvSharp.Internal;
using OpenCvSharp.Internal.Util;
using OpenCvSharp.Internal.Vectors;

namespace OpenCvSharp;

/// <summary>
/// Represents an animation with multiple frames.
/// Stores and manages data for animated sequences such as those from animated formats (e.g., GIF, AVIF, APNG, WebP).
/// It provides support for looping, background color settings, frame timing, and frame storage.
/// </summary>
public class Animation : CvObject
{
    /// <summary>
    /// Constructs an Animation object with optional loop count and background color.
    /// </summary>
    /// <param name="loopCount">
    /// The number of times the animation should loop. 0 (default) indicates infinite looping.
    /// Negative values or values beyond 0xffff (65535) are reset to 0.
    /// </param>
    /// <param name="bgColor">Background color of the animation in BGR(A) format. Defaults to an empty color.</param>
    public Animation(int loopCount = 0, Scalar? bgColor = null)
    {
        NativeMethods.HandleException(
            NativeMethods.imgcodecs_Animation_new(loopCount, bgColor ?? Scalar.All(0), out var p));
        SetSafeHandle(new OpenCvPtrSafeHandle(p, ownsHandle: true,
            static h => NativeMethods.HandleException(NativeMethods.imgcodecs_Animation_delete(h))));
    }

    /// <summary>
    /// Number of times the animation should loop. 0 means infinite looping.
    /// </summary>
    public int LoopCount
    {
        get
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.imgcodecs_Animation_get_loop_count(CvPtr, out var ret));
            GC.KeepAlive(this);
            return ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.imgcodecs_Animation_set_loop_count(CvPtr, value));
            GC.KeepAlive(this);
        }
    }

    /// <summary>
    /// Background color of the animation in BGRA format.
    /// </summary>
    public Scalar BgColor
    {
        get
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.imgcodecs_Animation_get_bgcolor(CvPtr, out var ret));
            GC.KeepAlive(this);
            return ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.imgcodecs_Animation_set_bgcolor(CvPtr, value));
            GC.KeepAlive(this);
        }
    }

    /// <summary>
    /// Duration for each frame in milliseconds.
    /// </summary>
    public int[] Durations
    {
        get
        {
            ThrowIfDisposed();
            using var vec = new StdVector<int>();
            NativeMethods.HandleException(
                NativeMethods.imgcodecs_Animation_get_durations(CvPtr, vec.CvPtr));
            GC.KeepAlive(this);
            return vec.ToArray();
        }
        set
        {
            ThrowIfDisposed();
            ArgumentNullException.ThrowIfNull(value);
            NativeMethods.HandleException(
                NativeMethods.imgcodecs_Animation_set_durations(CvPtr, value, value.Length));
            GC.KeepAlive(this);
        }
    }

    /// <summary>
    /// Frames of the animation. The getter returns freshly-copied <see cref="Mat"/> headers that the
    /// caller owns and is responsible for disposing.
    /// </summary>
    public Mat[] Frames
    {
        get
        {
            ThrowIfDisposed();
            using var vec = new VectorOfMat();
            NativeMethods.HandleException(
                NativeMethods.imgcodecs_Animation_get_frames(CvPtr, vec.CvPtr));
            GC.KeepAlive(this);
            return vec.ToArray();
        }
        set
        {
            ThrowIfDisposed();
            ArgumentNullException.ThrowIfNull(value);
            using var vec = new VectorOfMat(value);
            NativeMethods.HandleException(
                NativeMethods.imgcodecs_Animation_set_frames(CvPtr, vec.CvPtr));
            GC.KeepAlive(this);
            GC.KeepAlive(value);
        }
    }

    /// <summary>
    /// Image that can be used for the format in addition to the animation, or if animation is not supported
    /// in the reader (like in PNG). The getter returns a freshly-copied <see cref="Mat"/> header that the
    /// caller owns and is responsible for disposing.
    /// </summary>
    public Mat StillImage
    {
        get
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.imgcodecs_Animation_get_still_image(CvPtr, out var ret));
            GC.KeepAlive(this);
            return new Mat(ret);
        }
        set
        {
            ThrowIfDisposed();
            ArgumentNullException.ThrowIfNull(value);
            NativeMethods.HandleException(
                NativeMethods.imgcodecs_Animation_set_still_image(CvPtr, value.CvPtr));
            GC.KeepAlive(this);
            GC.KeepAlive(value);
        }
    }
}
