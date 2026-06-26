using OpenCvSharp.Internal;

// ReSharper disable UnusedMember.Global

namespace OpenCvSharp.XFeatures2D;

// ReSharper disable once InconsistentNaming
/// <summary>
/// Class implementing the AKAZE keypoint detector and descriptor extractor, 
/// described in @cite ANB13
/// </summary>
/// <remarks>
/// AKAZE descriptors can only be used with KAZE or AKAZE keypoints. 
/// Try to avoid using *extract* and *detect* instead of *operator()* due to performance reasons. 
/// .. [ANB13] Fast Explicit Diffusion for Accelerated Features in Nonlinear Scale 
/// Spaces. Pablo F. Alcantarilla, Jesús Nuevo and Adrien Bartoli. 
/// In British Machine Vision Conference (BMVC), Bristol, UK, September 2013.
/// </remarks>
// ReSharper disable once InconsistentNaming
public class AKAZE : Feature2D
{
    /// <summary>
    /// Constructor
    /// </summary>
    private AKAZE(IntPtr smartPtr, IntPtr rawPtr)
        : base(smartPtr, rawPtr, p => NativeMethods.HandleException(NativeMethods.xfeatures2d_Ptr_AKAZE_delete(p)))
    {
    }

    /// <summary>
    /// The AKAZE constructor
    /// </summary>
    /// <param name="descriptorType">Type of the extracted descriptor: DESCRIPTOR_KAZE,
    /// DESCRIPTOR_KAZE_UPRIGHT, DESCRIPTOR_MLDB or DESCRIPTOR_MLDB_UPRIGHT.</param>
    /// <param name="descriptorSize">Size of the descriptor in bits. 0 -&gt; Full size</param>
    /// <param name="descriptorChannels">Number of channels in the descriptor (1, 2, 3)</param>
    /// <param name="threshold">Detector response threshold to accept point</param>
    /// <param name="nOctaves">Maximum octave evolution of the image</param>
    /// <param name="nOctaveLayers">Default number of sublevels per scale level</param>
    /// <param name="diffusivity">Diffusivity type. DIFF_PM_G1, DIFF_PM_G2, DIFF_WEICKERT or DIFF_CHARBONNIER</param>
    public static AKAZE Create(
        AKAZEDescriptorType descriptorType = AKAZEDescriptorType.MLDB,
        int descriptorSize = 0,
        int descriptorChannels = 3,
        float threshold = 0.001f,
        int nOctaves = 4,
        int nOctaveLayers = 4,
        KAZEDiffusivityType diffusivity = KAZEDiffusivityType.DiffPmG2)
    {
        NativeMethods.HandleException(
            NativeMethods.xfeatures2d_AKAZE_create(
                (int) descriptorType, descriptorSize, descriptorChannels,
                threshold, nOctaves, nOctaveLayers, (int) diffusivity, out var smartPtr));
        NativeMethods.HandleException(
            NativeMethods.features_Ptr_Feature2D_get(smartPtr, out var rawPtr));
        return new AKAZE(smartPtr, rawPtr);
    }

    /// <summary>
    /// 
    /// </summary>
    // ReSharper disable once InconsistentNaming
    public AKAZEDescriptorType AKAZEDescriptorType // avoid name conflict
    {
        get
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.xfeatures2d_AKAZE_getDescriptorType(Handle, out var ret));
            return (AKAZEDescriptorType)ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.xfeatures2d_AKAZE_setDescriptorType(Handle, (int)value));
        }
    }

    /// <summary>
    /// 
    /// </summary>
    // ReSharper disable once InconsistentNaming
    public int AKAZEDescriptorSize // avoid name conflict
    {
        get
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.xfeatures2d_AKAZE_getDescriptorSize(Handle, out var ret));
            return ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.xfeatures2d_AKAZE_setDescriptorSize(Handle, value));
        }
    }

    /// <summary>
    /// 
    /// </summary>
    // ReSharper disable once InconsistentNaming
    public int AKAZEDescriptorChannels // avoid name conflict
    {
        get
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.xfeatures2d_AKAZE_getDescriptorChannels(Handle, out var ret));
            return ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.xfeatures2d_AKAZE_setDescriptorChannels(Handle, value));
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public double Threshold
    {
        get
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.xfeatures2d_AKAZE_getThreshold(Handle, out var ret));
            return ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.xfeatures2d_AKAZE_setThreshold(Handle, value));
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public int NOctaves
    {
        get
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.xfeatures2d_AKAZE_getNOctaves(Handle, out var ret));
            return ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.xfeatures2d_AKAZE_setNOctaves(Handle, value));
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public int NOctaveLayers
    {
        get
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.xfeatures2d_AKAZE_getNOctaveLayers(Handle, out var ret));
            return ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.xfeatures2d_AKAZE_setNOctaveLayers(Handle, value));
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public KAZEDiffusivityType DiffusivityType
    {
        get
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.xfeatures2d_AKAZE_getDiffusivity(Handle, out var ret));
            return (KAZEDiffusivityType)ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.xfeatures2d_AKAZE_setDiffusivity(Handle, (int)value));
        }
    }
}
