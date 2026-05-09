using OpenCvSharp.Internal;
using OpenCvSharp.Internal.Vectors;

namespace OpenCvSharp.Cuda;


public class HOG : Algorithm
{
    protected HOG(IntPtr smartPtr, IntPtr rawPtr)
        : base(smartPtr, rawPtr, p => NativeMethods.HandleException(NativeMethods.cuda_HOG_delete(p)))
    {
    }

    public static HOG Create(Size? winSize = null, Size? blockSize = null, Size? blockStride = null, Size? cellSize = null, int nbins = 9)
    {
        Size wSize = winSize ?? new Size(64, 128);
        Size bSize = blockSize ?? new Size(16, 16);
        Size bStride = blockStride ?? new Size(8, 8);
        Size cSize = cellSize ?? new Size(8, 8);

        NativeMethods.HandleException(NativeMethods.cuda_createHOG(
            wSize, bSize, bStride, cSize, nbins, out var smartPtr));

        NativeMethods.HandleException(NativeMethods.cuda_HOG_get(smartPtr, out var rawPtr));

        return new HOG(smartPtr, rawPtr);
    }

    public virtual void Compute(OpenCvSharp.Cuda.InputArray img, OpenCvSharp.Cuda.OutputArray descriptors, OpenCvSharp.Cuda.Stream? stream = null)
    {
        if (img is null) throw new ArgumentNullException(nameof(img));
        if (descriptors is null) throw new ArgumentNullException(nameof(descriptors));

        img.ThrowIfDisposed();
        descriptors.ThrowIfNotReady();
        ThrowIfDisposed();

        NativeMethods.HandleException(
            NativeMethods.cuda_HOG_compute(RawPtr, img.CvPtr, descriptors.CvPtr, stream?.CvPtr?? IntPtr.Zero));

        descriptors.Fix();
        GC.KeepAlive(this);
        GC.KeepAlive(img);
    }

    /// <summary>
    /// Performs object detection without a multi-scale window.
    /// </summary>
    public virtual Point[] Detect(OpenCvSharp.Cuda.InputArray img)
    {
        return Detect(img, out _);
    }

    /// <summary>
    /// Performs object detection without a multi-scale window.
    /// </summary>
    public virtual Point[] Detect(OpenCvSharp.Cuda.InputArray img, out double[] confidences)
    {
        if (img is null) throw new ArgumentNullException(nameof(img));
        img.ThrowIfDisposed();
        ThrowIfDisposed();

        using var ptsVec = new VectorOfPoint();
        using var confVec = new VectorOfDouble();

        NativeMethods.HandleException(
            NativeMethods.cuda_HOG_detect(RawPtr, img.CvPtr, ptsVec.CvPtr, confVec.CvPtr));

        confidences = confVec.ToArray();
        GC.KeepAlive(this);
        GC.KeepAlive(img);

        return ptsVec.ToArray();
    }

    /// <summary>
    /// Performs object detection with a multi-scale window.
    /// </summary>
    public virtual Rect[] DetectMultiScale(OpenCvSharp.Cuda.InputArray img)
    {
        return DetectMultiScale(img, out _);
    }

    /// <summary>
    /// Performs object detection with a multi-scale window, returning confidences.
    /// </summary>
    public virtual Rect[] DetectMultiScale(OpenCvSharp.Cuda.InputArray img, out double[] confidences)
    {
        if (img is null) throw new ArgumentNullException(nameof(img));
        img.ThrowIfDisposed();
        ThrowIfDisposed();

        using var rectsVec = new VectorOfRect();
        using var confVec = new VectorOfDouble();

        NativeMethods.HandleException(
            NativeMethods.cuda_HOG_detectMultiScale(RawPtr, img.CvPtr, rectsVec.CvPtr, confVec.CvPtr));

        confidences = confVec.ToArray();
        GC.KeepAlive(this);
        GC.KeepAlive(img);

        return rectsVec.ToArray();
    }

    /// <summary>
    /// Returns the block histogram size.
    /// </summary>
    public ulong BlockHistogramSize
    {
        get 
        { 
            ThrowIfDisposed();
            NativeMethods.HandleException(NativeMethods.cuda_HOG_getBlockHistogramSize(RawPtr, out var val)); 
            GC.KeepAlive(this); 
            return (ulong)val;
        }
    }

    /// <summary>
    /// Returns the number of coefficients required for the classification.
    /// </summary>
    public ulong DescriptorSize
    {
        get 
        { 
            ThrowIfDisposed(); 
            NativeMethods.HandleException(NativeMethods.cuda_HOG_getDescriptorSize(RawPtr, out var val)); 
            GC.KeepAlive(this); 
            return (ulong)val; 
        }
    }

    /// <summary>
    /// Gets or sets the descriptor storage format.
    /// </summary>
    public HOGDescriptorFormat DescriptorFormat
    {
        get
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(NativeMethods.cuda_HOG_getDescriptorFormat(RawPtr, out int val));
            GC.KeepAlive(this);
            return (HOGDescriptorFormat)val;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(NativeMethods.cuda_HOG_setDescriptorFormat(RawPtr, (int)value));
            GC.KeepAlive(this);
        }
    }

    public bool GammaCorrection
    {
        get 
        { 
            ThrowIfDisposed(); 
            NativeMethods.HandleException(NativeMethods.cuda_HOG_getGammaCorrection(RawPtr, out int val)); 
            GC.KeepAlive(this); 
            return val != 0; 
        }
        set 
        { 
            ThrowIfDisposed(); 
            NativeMethods.HandleException(NativeMethods.cuda_HOG_setGammaCorrection(RawPtr, value ? 1 : 0)); 
            GC.KeepAlive(this);
        }
    }

    public int GroupThreshold
    {
        get 
        { 
            ThrowIfDisposed(); NativeMethods.HandleException(NativeMethods.cuda_HOG_getGroupThreshold(RawPtr, out int val)); 
            GC.KeepAlive(this); 
            return val; 
        }
        set 
        { 
            ThrowIfDisposed(); NativeMethods.HandleException(NativeMethods.cuda_HOG_setGroupThreshold(RawPtr, value)); 
            GC.KeepAlive(this); 
        }
    }

    public double HitThreshold
    {
        get 
        { 
            ThrowIfDisposed(); 
            NativeMethods.HandleException(NativeMethods.cuda_HOG_getHitThreshold(RawPtr, out double val)); 
            GC.KeepAlive(this); 
            return val; 
        }
        set 
        { 
            ThrowIfDisposed(); 
            NativeMethods.HandleException(NativeMethods.cuda_HOG_setHitThreshold(RawPtr, value)); 
            GC.KeepAlive(this); 
        }
    }

    public double L2HysThreshold
    {
        get 
        { 
            ThrowIfDisposed(); NativeMethods.HandleException(NativeMethods.cuda_HOG_getL2HysThreshold(RawPtr, out double val)); 
            GC.KeepAlive(this);
            return val; 
        }
        set 
        { 
            ThrowIfDisposed(); NativeMethods.HandleException(NativeMethods.cuda_HOG_setL2HysThreshold(RawPtr, value));
            GC.KeepAlive(this);
        }
    }

    public int NumLevels
    {
        get 
        { 
            ThrowIfDisposed(); 
            NativeMethods.HandleException(NativeMethods.cuda_HOG_getNumLevels(RawPtr, out int val)); 
            GC.KeepAlive(this); 
            return val; 
        }
        set { 
            ThrowIfDisposed(); 
            NativeMethods.HandleException(NativeMethods.cuda_HOG_setNumLevels(RawPtr, value)); 
            GC.KeepAlive(this);
        }
    }

    public double ScaleFactor
    {
        get 
        { 
            ThrowIfDisposed(); NativeMethods.HandleException(NativeMethods.cuda_HOG_getScaleFactor(RawPtr, out double val)); 
            GC.KeepAlive(this);
            return val;
        }
        set 
        { 
            ThrowIfDisposed();
            NativeMethods.HandleException(NativeMethods.cuda_HOG_setScaleFactor(RawPtr, value)); 
            GC.KeepAlive(this);
        }
    }

    public double WinSigma
    {
        get 
        { 
            ThrowIfDisposed(); 
            NativeMethods.HandleException(NativeMethods.cuda_HOG_getWinSigma(RawPtr, out double val)); 
            GC.KeepAlive(this); 
            return val; 
        }
        set 
        { 
            ThrowIfDisposed(); 
            NativeMethods.HandleException(NativeMethods.cuda_HOG_setWinSigma(RawPtr, value)); 
            GC.KeepAlive(this); 
        }
    }

    public Size WinStride
    {
        get 
        { 
            ThrowIfDisposed(); 
            NativeMethods.HandleException(NativeMethods.cuda_HOG_getWinStride(RawPtr, out Size val)); 
            GC.KeepAlive(this); 
            return val; 
        }
        set 
        { 
            ThrowIfDisposed(); 
            NativeMethods.HandleException(NativeMethods.cuda_HOG_setWinStride(RawPtr, value)); 
            GC.KeepAlive(this);
        }
    }

    /// <summary>
    /// Returns coefficients of the classifier trained for people detection.
    /// </summary>
    public Mat GetDefaultPeopleDetector()
    {
        ThrowIfDisposed();
        NativeMethods.HandleException(
            NativeMethods.cuda_HOG_getDefaultPeopleDetector(RawPtr, out var ret));
        GC.KeepAlive(this);
        return new Mat(ret);
    }

    /// <summary>
    /// Sets coefficients for the linear SVM classifier.
    /// </summary>
    public void SetSVMDetector(OpenCvSharp.InputArray detector)
    {
        if (detector is null) throw new ArgumentNullException(nameof(detector));
        detector.ThrowIfDisposed();
        ThrowIfDisposed();

        NativeMethods.HandleException(
            NativeMethods.cuda_HOG_setSVMDetector(RawPtr, detector.CvPtr));
        GC.KeepAlive(this);
        GC.KeepAlive(detector);
    }

}
