using OpenCvSharp.Internal;

namespace OpenCvSharp.XFeatures2D;

/// <summary>
/// Class for extracting Speeded Up Robust Features from an image.
/// </summary>
public class SURF : Feature2D
{
    private Ptr? detectorPtr;

    #region Init & Disposal

    /// <summary>
    /// Creates instance by raw pointer cv::SURF*
    /// </summary>
    protected SURF(IntPtr p)
    {
        detectorPtr = new Ptr(p);
        ptr = detectorPtr.Get();
    }

    /// <summary>
    /// The SURF constructor.
    /// </summary>
    /// <param name="hessianThreshold">Only features with keypoint.hessian larger than that are extracted. </param>
    /// <param name="nOctaves">The number of a gaussian pyramid octaves that the detector uses. It is set to 4 by default. 
    /// If you want to get very large features, use the larger value. If you want just small features, decrease it.</param>
    /// <param name="nOctaveLayers">The number of images within each octave of a gaussian pyramid. It is set to 2 by default.</param>
    /// <param name="extended">false means basic descriptors (64 elements each), true means extended descriptors (128 elements each) </param>
    /// <param name="upright">false means that detector computes orientation of each feature.
    /// true means that the orientation is not computed (which is much, much faster).</param>
    public static SURF Create(double hessianThreshold,
        int nOctaves = 4, int nOctaveLayers = 2,
        bool extended = true, bool upright = false)
    {
        NativeMethods.HandleException(
            NativeMethods.xfeatures2d_SURF_create(
                hessianThreshold, nOctaves, nOctaveLayers,
                extended ? 1 : 0, upright ? 1 : 0, out var ptr));
        return new SURF(ptr);
    }

    /// <summary>
    /// Releases managed resources
    /// </summary>
    protected override void DisposeManaged()
    {
        detectorPtr?.Dispose();
        detectorPtr = null;
        base.DisposeManaged();
    }

    #endregion

    #region Properties

    /// <summary>
    /// Threshold for the keypoint detector. Only features, whose hessian is larger than hessianThreshold 
    /// are retained by the detector. Therefore, the larger the value, the less keypoints you will get. 
    /// A good default value could be from 300 to 500, depending from the image contrast.
    /// </summary>
    public double HessianThreshold
    {
        get
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.xfeatures2d_SURF_getHessianThreshold(ptr, out var ret));
            GC.KeepAlive(this);
            return ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.xfeatures2d_SURF_setHessianThreshold(ptr, value));
            GC.KeepAlive(this);
        }
    }

    /// <summary>
    /// The number of a gaussian pyramid octaves that the detector uses. It is set to 4 by default. 
    /// If you want to get very large features, use the larger value. If you want just small features, decrease it.
    /// </summary>
    public int NOctaves
    {
        get
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.xfeatures2d_SURF_getNOctaves(ptr, out var ret));
            GC.KeepAlive(this);
            return ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.xfeatures2d_SURF_setNOctaves(ptr, value));
            GC.KeepAlive(this);
        }
    }

    /// <summary>
    /// The number of images within each octave of a gaussian pyramid. It is set to 2 by default.
    /// </summary>
    public int NOctaveLayers
    {
        get
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.xfeatures2d_SURF_getNOctaveLayers(ptr, out var ret));
            GC.KeepAlive(this);
            return ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.xfeatures2d_SURF_setNOctaveLayers(ptr, value));
            GC.KeepAlive(this);
        }
    }

    /// <summary>
    /// false means that the basic descriptors (64 elements each) shall be computed. 
    /// true means that the extended descriptors (128 elements each) shall be computed
    /// </summary>
    public bool Extended
    {
        get
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.xfeatures2d_SURF_getExtended(ptr, out var ret));
            GC.KeepAlive(this);
            return ret != 0;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.xfeatures2d_SURF_setExtended(ptr, value ? 1 : 0));
            GC.KeepAlive(this);
        }
    }

    /// <summary>
    /// false means that detector computes orientation of each feature.
    /// true means that the orientation is not computed (which is much, much faster). 
    /// For example, if you match images from a stereo pair, or do image stitching, the matched features 
    /// likely have very similar angles, and you can speed up feature extraction by setting upright=true.
    /// </summary>
    public bool Upright
    {
        get
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.xfeatures2d_SURF_getUpright(ptr, out var ret));
            GC.KeepAlive(this);
            return ret != 0;

        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.xfeatures2d_SURF_setUpright(ptr, value ? 1 : 0));
            GC.KeepAlive(this);
        }
    }

    #endregion

    internal class Ptr : OpenCvSharp.Ptr
    {
        public Ptr(IntPtr ptr) : base(ptr)
        {
        }

        public override IntPtr Get()
        {
            NativeMethods.HandleException(
                NativeMethods.xfeatures2d_Ptr_SURF_get(ptr, out var ret));
            GC.KeepAlive(this);
            return ret;

        }

        protected override void DisposeUnmanaged()
        {
            NativeMethods.HandleException(
                NativeMethods.xfeatures2d_Ptr_SURF_delete(ptr));
            base.DisposeUnmanaged();
        }
    }
}
