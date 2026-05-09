using System;
using System.Collections.Generic;
using System.Text;
using OpenCvSharp.Internal;

namespace OpenCvSharp.Cuda;

/// <summary>
/// Base class for Hough circles detector.
/// </summary>
public class HoughCirclesDetector : Algorithm
{
    protected HoughCirclesDetector(IntPtr smartPtr, IntPtr rawPtr)
        : base(smartPtr, rawPtr, p => NativeMethods.HandleException(NativeMethods.cuda_HoughCirclesDetector_delete(p)))
    {
    }

    /// <summary>
    /// Creates implementation for cuda::HoughCirclesDetector.
    /// </summary>
    public static HoughCirclesDetector Create(
        float dp, float minDist, int cannyThreshold, int votesThreshold,
        int minRadius, int maxRadius, int maxCircles = 4096)
    {
        NativeMethods.HandleException(
            NativeMethods.cuda_createHoughCirclesDetector(
                dp, minDist, cannyThreshold, votesThreshold, minRadius, maxRadius, maxCircles, out var smartPtr));

        NativeMethods.HandleException(
            NativeMethods.cuda_HoughCirclesDetector_get(smartPtr, out var rawPtr));

        return new HoughCirclesDetector(smartPtr, rawPtr);
    }

    /// <summary>
    /// Finds circles in a grayscale image using the Hough transform.
    /// </summary>
    /// <param name="src">8-bit, single-channel, grayscale input image.</param>
    /// <param name="circles">Output matrix of detected circles (CV_32FC3).</param>
    /// <param name="stream">Stream for the asynchronous version.</param>
    public virtual void Detect(
        OpenCvSharp.Cuda.InputArray src, OpenCvSharp.Cuda.OutputArray circles, OpenCvSharp.Cuda.Stream? stream = null)
    {
        if (src is null) throw new ArgumentNullException(nameof(src));
        if (circles is null) throw new ArgumentNullException(nameof(circles));

        src.ThrowIfDisposed();
        circles.ThrowIfNotReady();
        ThrowIfDisposed();

        NativeMethods.HandleException(
            NativeMethods.cuda_HoughCirclesDetector_detect(RawPtr, src.CvPtr, circles.CvPtr, stream?.CvPtr ?? IntPtr.Zero));

        circles.Fix();
        GC.KeepAlive(this);
        GC.KeepAlive(src);
    }

    public int CannyThreshold
    {
        get 
        { 
            ThrowIfDisposed();
            NativeMethods.HandleException(NativeMethods.cuda_HoughCirclesDetector_getCannyThreshold(RawPtr, out int val)); 
            GC.KeepAlive(this); 
            return val; 
        }
        set 
        { 
            ThrowIfDisposed();
            NativeMethods.HandleException(NativeMethods.cuda_HoughCirclesDetector_setCannyThreshold(RawPtr, value)); 
            GC.KeepAlive(this);
        }
    }

    public float Dp
    {
        get 
        { 
            ThrowIfDisposed(); 
            NativeMethods.HandleException(NativeMethods.cuda_HoughCirclesDetector_getDp(RawPtr, out float val)); 
            GC.KeepAlive(this);
            return val;
        }
        set 
        { 
            ThrowIfDisposed(); 
            NativeMethods.HandleException(NativeMethods.cuda_HoughCirclesDetector_setDp(RawPtr, value)); 
            GC.KeepAlive(this);
        }
    }

    public int MaxCircles
    {
        get 
        { 
            ThrowIfDisposed();
            NativeMethods.HandleException(NativeMethods.cuda_HoughCirclesDetector_getMaxCircles(RawPtr, out int val)); 
            GC.KeepAlive(this); 
            return val; 
        }
        set 
        { 
            ThrowIfDisposed();
            NativeMethods.HandleException(NativeMethods.cuda_HoughCirclesDetector_setMaxCircles(RawPtr, value));
            GC.KeepAlive(this); 
        }
    }

    public int MaxRadius
    {
        get 
        { 
            ThrowIfDisposed(); 
            NativeMethods.HandleException(NativeMethods.cuda_HoughCirclesDetector_getMaxRadius(RawPtr, out int val)); 
            GC.KeepAlive(this);
            return val; 
        }
        set 
        { 
            ThrowIfDisposed(); 
            NativeMethods.HandleException(NativeMethods.cuda_HoughCirclesDetector_setMaxRadius(RawPtr, value)); 
            GC.KeepAlive(this);
        }
    }

    public float MinDist
    {
        get 
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(NativeMethods.cuda_HoughCirclesDetector_getMinDist(RawPtr, out float val));
            GC.KeepAlive(this); 
            return val; 
        }
        set 
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(NativeMethods.cuda_HoughCirclesDetector_setMinDist(RawPtr, value)); 
            GC.KeepAlive(this); 
        }
    }

    public int MinRadius
    {
        get
        { 
            ThrowIfDisposed();
            NativeMethods.HandleException(NativeMethods.cuda_HoughCirclesDetector_getMinRadius(RawPtr, out int val));
            GC.KeepAlive(this); 
            return val; 
        }
        set 
        {
            ThrowIfDisposed(); 
            NativeMethods.HandleException(NativeMethods.cuda_HoughCirclesDetector_setMinRadius(RawPtr, value)); 
            GC.KeepAlive(this); 
        }
    }

    public int VotesThreshold
    {
        get {
            ThrowIfDisposed();
            NativeMethods.HandleException(NativeMethods.cuda_HoughCirclesDetector_getVotesThreshold(RawPtr, out int val));
            GC.KeepAlive(this);
            return val;
        }
        set {
            ThrowIfDisposed();
            NativeMethods.HandleException(NativeMethods.cuda_HoughCirclesDetector_setVotesThreshold(RawPtr, value));
            GC.KeepAlive(this);
        }
    }
}
