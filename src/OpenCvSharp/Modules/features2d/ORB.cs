using OpenCvSharp.Internal;

namespace OpenCvSharp;

// ReSharper disable once InconsistentNaming
/// <summary>
/// Class implementing the ORB (*oriented BRIEF*) keypoint detector and descriptor extractor.
///
/// described in @cite RRKB11 . The algorithm uses FAST in pyramids to detect stable keypoints, selects 
/// the strongest features using FAST or Harris response, finds their orientation using first-order
/// moments and computes the descriptors using BRIEF (where the coordinates of random point pairs (or
/// k-tuples) are rotated according to the measured orientation).
/// </summary>
// ReSharper disable once InconsistentNaming
public class ORB : Feature2D
{
    private Ptr? ptrObj;

    /// <summary>
    /// 
    /// </summary>
    protected ORB(IntPtr p)
    {
        ptrObj = new Ptr(p);
        ptr = ptrObj.Get();
    }

    /// <summary>
    /// The ORB constructor
    /// </summary>
    /// <param name="nFeatures">The maximum number of features to retain.</param>
    /// <param name="scaleFactor">Pyramid decimation ratio, greater than 1. scaleFactor==2 means the classical
    /// pyramid, where each next level has 4x less pixels than the previous, but such a big scale factor
    /// will degrade feature matching scores dramatically. On the other hand, too close to 1 scale factor
    /// will mean that to cover certain scale range you will need more pyramid levels and so the speed will suffer.</param>
    /// <param name="nLevels">The number of pyramid levels. The smallest level will have linear size equal to
    /// input_image_linear_size/pow(scaleFactor, nlevels - firstLevel).</param>
    /// <param name="edgeThreshold">This is size of the border where the features are not detected. It should
    /// roughly match the patchSize parameter.</param>
    /// <param name="firstLevel">The level of pyramid to put source image to. Previous layers are filled
    /// with upscaled source image.</param>
    /// <param name="wtaK">The number of points that produce each element of the oriented BRIEF descriptor. The
    /// default value 2 means the BRIEF where we take a random point pair and compare their brightnesses,
    /// so we get 0/1 response. Other possible values are 3 and 4. For example, 3 means that we take 3
    /// random points (of course, those point coordinates are random, but they are generated from the
    /// pre-defined seed, so each element of BRIEF descriptor is computed deterministically from the pixel
    /// rectangle), find point of maximum brightness and output index of the winner (0, 1 or 2). Such
    /// output will occupy 2 bits, and therefore it will need a special variant of Hamming distance,
    /// denoted as NORM_HAMMING2 (2 bits per bin). When WTA_K=4, we take 4 random points to compute each
    /// bin (that will also occupy 2 bits with possible values 0, 1, 2 or 3).</param>
    /// <param name="scoreType">The default HARRIS_SCORE means that Harris algorithm is used to rank features
    /// (the score is written to KeyPoint::score and is used to retain best nfeatures features);
    /// FAST_SCORE is alternative value of the parameter that produces slightly less stable keypoints,
    /// but it is a little faster to compute.</param>
    /// <param name="patchSize">size of the patch used by the oriented BRIEF descriptor. Of course, on smaller
    /// pyramid layers the perceived image area covered by a feature will be larger.</param>
    /// <param name="fastThreshold">the fast threshold</param>
    public static ORB Create(
        int nFeatures = 500, float scaleFactor = 1.2f, int nLevels = 8, 
        int edgeThreshold = 31, int firstLevel = 0, int wtaK = 2, 
        ORBScoreType scoreType = ORBScoreType.Harris, int patchSize = 31, 
        int fastThreshold = 20)
    {
        NativeMethods.HandleException(
            NativeMethods.features2d_ORB_create(
                nFeatures, scaleFactor, nLevels, edgeThreshold,
                firstLevel, wtaK, (int) scoreType, patchSize, fastThreshold,
                out var ptr));
        return new ORB(ptr);
    }

    /// <summary>
    /// Releases managed resources
    /// </summary>
    protected override void DisposeManaged()
    {
        ptrObj?.Dispose();
        ptrObj = null;
        base.DisposeManaged();
    }
        
    /// <summary>
    /// 
    /// </summary>
    public int MaxFeatures
    {
        get
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.features2d_ORB_getMaxFeatures(ptr, out var ret));
            GC.KeepAlive(this);
            return ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.features2d_ORB_setMaxFeatures(ptr, value));
            GC.KeepAlive(this);
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public double ScaleFactor
    {
        get
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.features2d_ORB_getScaleFactor(ptr, out var ret));
            GC.KeepAlive(this);
            return ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.features2d_ORB_setScaleFactor(ptr, value));
            GC.KeepAlive(this);
        }
    }
        
    /// <summary>
    /// 
    /// </summary>
    public int NLevels
    {
        get
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.features2d_ORB_getNLevels(ptr, out var ret));
            GC.KeepAlive(this);
            return ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.features2d_ORB_setNLevels(ptr, value));
            GC.KeepAlive(this);
        }
    }
        
    /// <summary>
    /// 
    /// </summary>
    public int EdgeThreshold
    {
        get
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.features2d_ORB_getEdgeThreshold(ptr, out var ret));
            GC.KeepAlive(this);
            return ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.features2d_ORB_setEdgeThreshold(ptr, value));
            GC.KeepAlive(this);
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public int FirstLevel
    {
        get
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.features2d_ORB_getFirstLevel(ptr, out var ret));
            GC.KeepAlive(this);
            return ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.features2d_ORB_setFirstLevel(ptr, value));
            GC.KeepAlive(this);
        }
    }

    /// <summary>
    /// 
    /// </summary>
    // ReSharper disable once InconsistentNaming
    public int WTA_K
    {
        get
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.features2d_ORB_getWTA_K(ptr, out var ret));
            GC.KeepAlive(this);
            return ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.features2d_ORB_setWTA_K(ptr, value));
            GC.KeepAlive(this);
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public ORBScoreType ScoreType
    {
        get
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.features2d_ORB_getScoreType(ptr, out var ret));
            GC.KeepAlive(this);
            return (ORBScoreType)ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.features2d_ORB_setScoreType(ptr, (int)value));
            GC.KeepAlive(this);
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public int PatchSize
    {
        get
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.features2d_ORB_getPatchSize(ptr, out var ret));
            GC.KeepAlive(this);
            return ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.features2d_ORB_setPatchSize(ptr, value));
            GC.KeepAlive(this);
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public int FastThreshold
    {
        get
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.features2d_ORB_getFastThreshold(ptr, out var ret));
            GC.KeepAlive(this);
            return ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.features2d_ORB_setFastThreshold(ptr, value));
            GC.KeepAlive(this);
        }
    }

    internal class Ptr : OpenCvSharp.Ptr
    {
        public Ptr(IntPtr ptr) : base(ptr)
        {
        }

        public override IntPtr Get()
        {
            NativeMethods.HandleException(
                NativeMethods.features2d_Ptr_ORB_get(ptr, out var ret));
            GC.KeepAlive(this);
            return ret;
        }

        protected override void DisposeUnmanaged()
        {
            NativeMethods.HandleException(
                NativeMethods.features2d_Ptr_ORB_delete(ptr));
            base.DisposeUnmanaged();
        }
    }
}
