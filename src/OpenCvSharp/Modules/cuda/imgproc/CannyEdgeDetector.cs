using OpenCvSharp.Internal;

namespace OpenCvSharp.Cuda;

public class CannyEdgeDetector: Algorithm
{
    protected CannyEdgeDetector(IntPtr smartPtr, IntPtr rawPtr)
          : base(smartPtr, rawPtr, p=> NativeMethods.HandleException( NativeMethods.cuda_CannyEdgeDetector_delete(p)))
    {
    }

    /// <summary>
    /// Creates implementation for cuda::CannyEdgeDetector.
    /// </summary>
    public static CannyEdgeDetector Create(
        double lowThresh, double highThresh, int appertureSize = 3, bool l2Gradient = false)
    {
        NativeMethods.HandleException(NativeMethods.cuda_createCannyEdgeDetector(
            lowThresh, highThresh, appertureSize, l2Gradient ? 1 : 0, out var smartPtr));

        NativeMethods.HandleException(NativeMethods.cuda_CannyEdgeDetector_get(smartPtr, out IntPtr rawPtr));

        return new CannyEdgeDetector(smartPtr, rawPtr);
    }

    public virtual void Detect( OpenCvSharp.Cuda.InputArray image, OpenCvSharp.Cuda.OutputArray edges, OpenCvSharp.Cuda.Stream? stream = null)
    {
        if (image is null) 
            throw new ArgumentNullException(nameof(image));
        if (edges is null) 
            throw new ArgumentNullException(nameof(edges));

        image.ThrowIfDisposed();
        edges.ThrowIfNotReady();
        ThrowIfDisposed();

        NativeMethods.HandleException(
            NativeMethods.cuda_CannyEdgeDetector_detect(RawPtr, image.CvPtr, edges.CvPtr, stream?.CvPtr ?? IntPtr.Zero));

        edges.Fix();
        GC.KeepAlive(this);
        GC.KeepAlive(image);
    }

    public virtual void Detect( OpenCvSharp.Cuda.InputArray dx, OpenCvSharp.Cuda.InputArray dy,
        OpenCvSharp.Cuda.OutputArray edges, OpenCvSharp.Cuda.Stream? stream = null)
    {
        if (dx is null) 
            throw new ArgumentNullException(nameof(dx));
        if (dy is null) 
            throw new ArgumentNullException(nameof(dy));
        if (edges is null) 
            throw new ArgumentNullException(nameof(edges));

        dx.ThrowIfDisposed();
        dy.ThrowIfDisposed();
        edges.ThrowIfNotReady();
        ThrowIfDisposed();

        NativeMethods.HandleException(
            NativeMethods.cuda_CannyEdgeDetector_detect_dxdy(RawPtr, dx.CvPtr, dy.CvPtr, edges.CvPtr, stream?.CvPtr ?? IntPtr.Zero));

        edges.Fix();
        GC.KeepAlive(this);
        GC.KeepAlive(dx);
        GC.KeepAlive(dy);
    }

    public int AppertureSize
    {
        get { 
            ThrowIfDisposed(); 
            NativeMethods.HandleException(NativeMethods.cuda_CannyEdgeDetector_getAppertureSize(RawPtr, out int val));
            GC.KeepAlive(this);
            return val; 
        }
        set { 
            ThrowIfDisposed();
            NativeMethods.HandleException(NativeMethods.cuda_CannyEdgeDetector_setAppertureSize(RawPtr, value)); 
            GC.KeepAlive(this);
        }
    }

    public double HighThreshold
    {
        get { ThrowIfDisposed(); 
            NativeMethods.HandleException(NativeMethods.cuda_CannyEdgeDetector_getHighThreshold(RawPtr, out double val));
            GC.KeepAlive(this); 
            return val; 
        }
        set { ThrowIfDisposed(); 
            NativeMethods.HandleException(NativeMethods.cuda_CannyEdgeDetector_setHighThreshold(RawPtr, value)); 
            GC.KeepAlive(this); 
        }
    }

    public double LowThreshold
    {
        get { ThrowIfDisposed(); 
            NativeMethods.HandleException(NativeMethods.cuda_CannyEdgeDetector_getLowThreshold(RawPtr, out double val)); 
            GC.KeepAlive(this); 
            return val; 
        }
        set { ThrowIfDisposed(); 
            NativeMethods.HandleException(NativeMethods.cuda_CannyEdgeDetector_setLowThreshold(RawPtr, value)); 
            GC.KeepAlive(this); 
        }
    }

    public bool L2Gradient
    {
        get { ThrowIfDisposed(); 
            NativeMethods.HandleException(NativeMethods.cuda_CannyEdgeDetector_getL2Gradient(RawPtr, out int val)); 
            GC.KeepAlive(this); 
            return val != 0; 
        }
        set { ThrowIfDisposed(); 
            NativeMethods.HandleException(NativeMethods.cuda_CannyEdgeDetector_setL2Gradient(RawPtr, value ? 1 : 0)); 
            GC.KeepAlive(this); 
        }
    }
}

