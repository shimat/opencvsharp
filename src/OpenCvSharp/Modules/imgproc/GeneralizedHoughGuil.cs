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
                NativeMethods.imgproc_GeneralizedHoughGuil_getXi(Handle, out var ret));
            return ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.imgproc_GeneralizedHoughGuil_setXi(Handle, value));
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
                NativeMethods.imgproc_GeneralizedHoughGuil_getLevels(Handle, out var ret));
            return ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.imgproc_GeneralizedHoughGuil_setLevels(Handle, value));
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
                NativeMethods.imgproc_GeneralizedHoughGuil_getAngleEpsilon(Handle, out var ret));
            return ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.imgproc_GeneralizedHoughGuil_setAngleEpsilon(Handle, value));
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
                NativeMethods.imgproc_GeneralizedHoughGuil_getMinAngle(Handle, out var ret));
            return ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.imgproc_GeneralizedHoughGuil_setMinAngle(Handle, value));
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
                NativeMethods.imgproc_GeneralizedHoughGuil_getMaxAngle(Handle, out var ret));
            return ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.imgproc_GeneralizedHoughGuil_setMaxAngle(Handle, value));
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
                NativeMethods.imgproc_GeneralizedHoughGuil_getAngleStep(Handle, out var ret));
            return ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.imgproc_GeneralizedHoughGuil_setAngleStep(Handle, value));
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
                NativeMethods.imgproc_GeneralizedHoughGuil_getAngleThresh(Handle, out var ret));
            return ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.imgproc_GeneralizedHoughGuil_setAngleThresh(Handle, value));
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
                NativeMethods.imgproc_GeneralizedHoughGuil_getMinScale(Handle, out var ret));
            return ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.imgproc_GeneralizedHoughGuil_setMinScale(Handle, value));
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
                NativeMethods.imgproc_GeneralizedHoughGuil_getMaxScale(Handle, out var ret));
            return ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.imgproc_GeneralizedHoughGuil_setMaxScale(Handle, value));
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
                NativeMethods.imgproc_GeneralizedHoughGuil_getScaleStep(Handle, out var ret));
            return ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.imgproc_GeneralizedHoughGuil_setScaleStep(Handle, value));
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
                NativeMethods.imgproc_GeneralizedHoughGuil_getScaleThresh(Handle, out var ret));
            return ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.imgproc_GeneralizedHoughGuil_setScaleThresh(Handle, value));
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
                NativeMethods.imgproc_GeneralizedHoughGuil_getPosThresh(Handle, out var ret));
            return ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.imgproc_GeneralizedHoughGuil_setPosThresh(Handle, value));
        }
    }
}
