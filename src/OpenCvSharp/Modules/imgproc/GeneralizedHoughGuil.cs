using OpenCvSharp.Internal;

namespace OpenCvSharp;

/// <summary>
/// Guil, N., González-Linares, J.M. and Zapata, E.L. (1999). 
/// Bidimensional shape detection using an invariant approach. 
/// Pattern Recognition 32 (6): 1025-1038.
/// Detects position, translation and rotation
/// </summary>
public class GeneralizedHoughGuil : GeneralizedHough
{
    /// <summary>
    /// cv::Ptr&lt;T&gt; object
    /// </summary>
    /// <summary>
    /// 
    /// </summary>
    private GeneralizedHoughGuil(IntPtr smartPtr, IntPtr rawPtr)
        : base(smartPtr, rawPtr, p => NativeMethods.HandleException(NativeMethods.imgproc_Ptr_GeneralizedHoughGuil_delete(p)))
    { }

    /// <summary>
    /// Creates a predefined GeneralizedHoughBallard object
    /// </summary>
    /// <returns></returns>
    public static GeneralizedHoughGuil Create()
    {
        NativeMethods.HandleException(
            NativeMethods.imgproc_createGeneralizedHoughGuil(out var smartPtr));
        NativeMethods.HandleException(NativeMethods.imgproc_Ptr_GeneralizedHoughGuil_get(smartPtr, out var rawPtr));
        return new GeneralizedHoughGuil(smartPtr, rawPtr);
    }

    /// <summary>
    /// Angle difference in degrees between two points in feature.
    /// </summary>
    /// <returns></returns>
    public double Xi
    {
        get
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.imgproc_GeneralizedHoughGuil_getXi(CvPtr, out var ret));
            GC.KeepAlive(this);
            return ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.imgproc_GeneralizedHoughGuil_setXi(CvPtr, value));
            GC.KeepAlive(this);
        }
    }

    /// <summary>
    /// Feature table levels.
    /// </summary>
    /// <returns></returns>
    public int Levels
    {
        get
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.imgproc_GeneralizedHoughGuil_getLevels(CvPtr, out var ret));
            GC.KeepAlive(this);
            return ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.imgproc_GeneralizedHoughGuil_setLevels(CvPtr, value));
            GC.KeepAlive(this);
        }
    }

    /// <summary>
    /// Maximal difference between angles that treated as equal.
    /// </summary>
    /// <returns></returns>
    public double AngleEpsilon
    {
        get
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.imgproc_GeneralizedHoughGuil_getAngleEpsilon(CvPtr, out var ret));
            GC.KeepAlive(this);
            return ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.imgproc_GeneralizedHoughGuil_setAngleEpsilon(CvPtr, value));
            GC.KeepAlive(this);
        }
    }

    /// <summary>
    /// Minimal rotation angle to detect in degrees.
    /// </summary>
    /// <returns></returns>
    public double MinAngle
    {
        get
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.imgproc_GeneralizedHoughGuil_getMinAngle(CvPtr, out var ret));
            GC.KeepAlive(this);
            return ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.imgproc_GeneralizedHoughGuil_setMinAngle(CvPtr, value));
            GC.KeepAlive(this);
        }
    }

    /// <summary>
    /// Maximal rotation angle to detect in degrees.
    /// </summary>
    /// <returns></returns>
    public double MaxAngle
    {
        get
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.imgproc_GeneralizedHoughGuil_getMaxAngle(CvPtr, out var ret));
            GC.KeepAlive(this);
            return ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.imgproc_GeneralizedHoughGuil_setMaxAngle(CvPtr, value));
            GC.KeepAlive(this);
        }
    }

    /// <summary>
    /// Angle step in degrees.
    /// </summary>
    /// <returns></returns>
    public double AngleStep
    {
        get
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.imgproc_GeneralizedHoughGuil_getAngleStep(CvPtr, out var ret));
            GC.KeepAlive(this);
            return ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.imgproc_GeneralizedHoughGuil_setAngleStep(CvPtr, value));
            GC.KeepAlive(this);
        }
    }

    /// <summary>
    /// Angle votes threshold.
    /// </summary>
    /// <returns></returns>
    public int AngleThresh
    {
        get
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.imgproc_GeneralizedHoughGuil_getAngleThresh(CvPtr, out var ret));
            GC.KeepAlive(this);
            return ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.imgproc_GeneralizedHoughGuil_setAngleThresh(CvPtr, value));
            GC.KeepAlive(this);
        }
    }

    /// <summary>
    /// Minimal scale to detect.
    /// </summary>
    /// <returns></returns>
    public double MinScale
    {
        get
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.imgproc_GeneralizedHoughGuil_getMinScale(CvPtr, out var ret));
            GC.KeepAlive(this);
            return ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.imgproc_GeneralizedHoughGuil_setMinScale(CvPtr, value));
            GC.KeepAlive(this);
        }
    }

    /// <summary>
    /// Maximal scale to detect.
    /// </summary>
    /// <returns></returns>
    public double MaxScale
    {
        get
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.imgproc_GeneralizedHoughGuil_getMaxScale(CvPtr, out var ret));
            GC.KeepAlive(this);
            return ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.imgproc_GeneralizedHoughGuil_setMaxScale(CvPtr, value));
            GC.KeepAlive(this);
        }
    }

    /// <summary>
    /// Scale step.
    /// </summary>
    /// <returns></returns>
    public double ScaleStep
    {
        get
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.imgproc_GeneralizedHoughGuil_getScaleStep(CvPtr, out var ret));
            GC.KeepAlive(this);
            return ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.imgproc_GeneralizedHoughGuil_setScaleStep(CvPtr, value));
            GC.KeepAlive(this);
        }
    }

    /// <summary>
    /// Scale votes threshold.
    /// </summary>
    /// <returns></returns>
    public int ScaleThresh
    {
        get
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.imgproc_GeneralizedHoughGuil_getScaleThresh(CvPtr, out var ret));
            GC.KeepAlive(this);
            return ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.imgproc_GeneralizedHoughGuil_setScaleThresh(CvPtr, value));
            GC.KeepAlive(this);
        }
    }

    /// <summary>
    /// Position votes threshold.
    /// </summary>
    /// <returns></returns>
    public int PosThresh
    {
        get
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.imgproc_GeneralizedHoughGuil_getPosThresh(CvPtr, out var ret));
            GC.KeepAlive(this);
            return ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.imgproc_GeneralizedHoughGuil_setPosThresh(CvPtr, value));
            GC.KeepAlive(this);
        }
    }
}
