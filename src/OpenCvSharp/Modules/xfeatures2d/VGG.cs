using OpenCvSharp.Internal;

namespace OpenCvSharp.XFeatures2D;

// ReSharper disable once InconsistentNaming
/// <summary>
/// Class implementing the VGG (Oxford Visual Geometry Group) descriptor, trained end-to-end
/// using "Descriptor Learning Using Convex Optimisation" (DLCO).
/// </summary>
public class VGG : Feature2D
{
    /// <summary>
    ///
    /// </summary>
    private VGG(IntPtr smartPtr, IntPtr rawPtr)
        : base(smartPtr, rawPtr, p => NativeMethods.HandleException(NativeMethods.xfeatures2d_Ptr_VGG_delete(p)))
    { }

    /// <summary>
    /// Creates the VGG descriptor.
    /// </summary>
    /// <param name="desc">Type of descriptor to use.</param>
    /// <param name="isigma">Gaussian kernel value for image blur.</param>
    /// <param name="imgNormalize">Use image sample intensity normalization.</param>
    /// <param name="useScaleOrientation">Sample patterns using keypoints orientation.</param>
    /// <param name="scaleFactor">Adjust the sampling window of detected keypoints.</param>
    /// <param name="dscNormalize">Clamp descriptors to 255 and convert to uchar CV_8UC1.</param>
    public static VGG Create(
        VGGDescriptorType desc = VGGDescriptorType.Vgg120, float isigma = 1.4f,
        bool imgNormalize = true, bool useScaleOrientation = true,
        float scaleFactor = 6.25f, bool dscNormalize = false)
    {
        NativeMethods.HandleException(
            NativeMethods.xfeatures2d_VGG_create(
                (int)desc, isigma, imgNormalize ? 1 : 0, useScaleOrientation ? 1 : 0, scaleFactor, dscNormalize ? 1 : 0,
                out var ptr));
        NativeMethods.HandleException(NativeMethods.xfeatures2d_Ptr_VGG_get(ptr, out var rawPtr));
        return new VGG(ptr, rawPtr);
    }

    /// <summary>
    /// Gaussian kernel value for image blur.
    /// </summary>
    public float Sigma
    {
        get
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(NativeMethods.xfeatures2d_VGG_getSigma(Handle, out var ret));
            return ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(NativeMethods.xfeatures2d_VGG_setSigma(Handle, value));
        }
    }

    /// <summary>
    /// Use image sample intensity normalization.
    /// </summary>
    public bool UseNormalizeImage
    {
        get
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(NativeMethods.xfeatures2d_VGG_getUseNormalizeImage(Handle, out var ret));
            return ret != 0;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(NativeMethods.xfeatures2d_VGG_setUseNormalizeImage(Handle, value ? 1 : 0));
        }
    }

    /// <summary>
    /// Sample patterns using keypoints orientation.
    /// </summary>
    public bool UseScaleOrientation
    {
        get
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(NativeMethods.xfeatures2d_VGG_getUseScaleOrientation(Handle, out var ret));
            return ret != 0;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(NativeMethods.xfeatures2d_VGG_setUseScaleOrientation(Handle, value ? 1 : 0));
        }
    }

    /// <summary>
    /// Adjust the sampling window of detected keypoints.
    /// </summary>
    public float ScaleFactor
    {
        get
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(NativeMethods.xfeatures2d_VGG_getScaleFactor(Handle, out var ret));
            return ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(NativeMethods.xfeatures2d_VGG_setScaleFactor(Handle, value));
        }
    }

    /// <summary>
    /// Clamp descriptors to 255 and convert to uchar CV_8UC1.
    /// </summary>
    public bool UseNormalizeDescriptor
    {
        get
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(NativeMethods.xfeatures2d_VGG_getUseNormalizeDescriptor(Handle, out var ret));
            return ret != 0;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(NativeMethods.xfeatures2d_VGG_setUseNormalizeDescriptor(Handle, value ? 1 : 0));
        }
    }
}
