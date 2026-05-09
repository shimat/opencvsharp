#if ENABLED_CUDA
using OpenCvSharp.Internal;

namespace OpenCvSharp.Cuda;

public class DisparityBilateralFilter : Algorithm
{
    protected DisparityBilateralFilter(IntPtr smartPtr, IntPtr rawPtr)
        : base(smartPtr, rawPtr, p => NativeMethods.HandleException(NativeMethods.cuda_DisparityBilateralFilter_delete(p))) 
    {
    }

    public static DisparityBilateralFilter Create(int ndisp = 64, int radius = 3, int iters = 1)
    {
        NativeMethods.HandleException(
            NativeMethods.cuda_createDisparityBilateralFilter(ndisp, radius, iters, out var smartPtr));

        NativeMethods.HandleException(
            NativeMethods.cuda_DisparityBilateralFilter_get(smartPtr, out var rawPtr));

        return new DisparityBilateralFilter(smartPtr, rawPtr);
    }

    /// <summary>
    /// Refines a disparity map using joint bilateral filtering.
    /// </summary>
    /// <param name="disparity">Input disparity map. CV_8UC1 and CV_16SC1 types are supported.</param>
    /// <param name="image">Input image. CV_8UC1 and CV_8UC3 types are supported.</param>
    /// <param name="dst">Output refined disparity map.</param>
    /// <param name="stream">Stream for the asynchronous version.</param>
    public virtual void Apply(
        OpenCvSharp.Cuda.InputArray disparity, OpenCvSharp.Cuda.InputArray image,
        OpenCvSharp.Cuda.OutputArray dst, OpenCvSharp.Cuda.Stream? stream = null)
    {
        if (disparity is null) throw new ArgumentNullException(nameof(disparity));
        if (image is null) throw new ArgumentNullException(nameof(image));
        if (dst is null) throw new ArgumentNullException(nameof(dst));

        disparity.ThrowIfDisposed();
        image.ThrowIfDisposed();
        dst.ThrowIfNotReady();
        ThrowIfDisposed();

        NativeMethods.HandleException(
            NativeMethods.cuda_DisparityBilateralFilter_apply(
                RawPtr, disparity.CvPtr, image.CvPtr, dst.CvPtr, stream?.CvPtr ?? IntPtr.Zero));

        dst.Fix();
        GC.KeepAlive(this);
        GC.KeepAlive(disparity);
        GC.KeepAlive(image);
    }

    /// <summary>
    /// Gets or sets the truncation of data continuity.
    /// </summary>
    public virtual float EdgeThreshold
    {
        get 
        { 
            ThrowIfDisposed(); 
            NativeMethods.HandleException(NativeMethods.cuda_DisparityBilateralFilter_getEdgeThreshold(RawPtr, out float val)); 
            GC.KeepAlive(this);
            return val; 
        }
        set 
        { 
            ThrowIfDisposed(); 
            NativeMethods.HandleException(NativeMethods.cuda_DisparityBilateralFilter_setEdgeThreshold(RawPtr, value)); 
            GC.KeepAlive(this); 
        }
    }

    /// <summary>
    /// Gets or sets the truncation of disparity continuity.
    /// </summary>
    public virtual float MaxDiscThreshold
    {
        get 
        { 
            ThrowIfDisposed(); 
            NativeMethods.HandleException(NativeMethods.cuda_DisparityBilateralFilter_getMaxDiscThreshold(RawPtr, out float val)); 
            GC.KeepAlive(this); 
            return val; 
        }
        set 
        { 
            ThrowIfDisposed(); 
            NativeMethods.HandleException(NativeMethods.cuda_DisparityBilateralFilter_setMaxDiscThreshold(RawPtr, value)); 
            GC.KeepAlive(this); 
        }
    }

    /// <summary>
    /// Gets or sets the number of disparities.
    /// </summary>
    public int NumDisparities
    {
        get 
        { 
            ThrowIfDisposed(); 
            NativeMethods.HandleException(NativeMethods.cuda_DisparityBilateralFilter_getNumDisparities(RawPtr, out int val));
            GC.KeepAlive(this); 
            return val; 
        }
        set 
        { 
            ThrowIfDisposed();
            NativeMethods.HandleException(NativeMethods.cuda_DisparityBilateralFilter_setNumDisparities(RawPtr, value)); 
            GC.KeepAlive(this); 
        }
    }

    /// <summary>
    /// Gets or sets the number of iterations.
    /// </summary>
    public int NumIters
    {
        get { 
            ThrowIfDisposed(); 
            NativeMethods.HandleException(NativeMethods.cuda_DisparityBilateralFilter_getNumIters(RawPtr, out int val)); 
            GC.KeepAlive(this); 
            return val; 
        }
        set { 
            ThrowIfDisposed(); 
            NativeMethods.HandleException(NativeMethods.cuda_DisparityBilateralFilter_setNumIters(RawPtr, value)); 
            GC.KeepAlive(this); 
        }
    }

    /// <summary>
    /// Gets or sets the filter radius.
    /// </summary>
    public int Radius
    {
        get 
        { 
            ThrowIfDisposed(); NativeMethods.HandleException(NativeMethods.cuda_DisparityBilateralFilter_getRadius(RawPtr, out int val)); 
            GC.KeepAlive(this); 
            return val; 
        }
        set 
        { 
            ThrowIfDisposed(); NativeMethods.HandleException(NativeMethods.cuda_DisparityBilateralFilter_setRadius(RawPtr, value));
            GC.KeepAlive(this); 
        }
    }

    /// <summary>
    /// Gets or sets the filter range sigma.
    /// </summary>
    public float SigmaRange
    {
        get 
        { 
            ThrowIfDisposed(); NativeMethods.HandleException(NativeMethods.cuda_DisparityBilateralFilter_getSigmaRange(RawPtr, out float val)); 
            GC.KeepAlive(this); 
            return val;
        }
        set 
        { 
            ThrowIfDisposed(); NativeMethods.HandleException(NativeMethods.cuda_DisparityBilateralFilter_setSigmaRange(RawPtr, value)); 
            GC.KeepAlive(this);
        }
    }
}
#endif
