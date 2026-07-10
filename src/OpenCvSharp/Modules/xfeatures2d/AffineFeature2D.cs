using OpenCvSharp.Internal;
using OpenCvSharp.Internal.Vectors;

namespace OpenCvSharp.XFeatures2D;

/// <summary>
/// Class implementing affine adaptation for keypoints. A Feature2D detector and a Feature2D
/// descriptor extractor are wrapped to augment the detected points with their affine invariant
/// elliptic region, and to compute the feature descriptors on the regions after warping them into
/// circles.
/// </summary>
public class AffineFeature2D : Feature2D
{
    /// <summary>
    ///
    /// </summary>
    private AffineFeature2D(IntPtr smartPtr, IntPtr rawPtr)
        : base(smartPtr, rawPtr, p => NativeMethods.HandleException(NativeMethods.xfeatures2d_Ptr_AffineFeature2D_delete(p)))
    { }

    /// <summary>
    /// Creates an instance wrapping the given keypoint detector and descriptor extractor.
    /// </summary>
    /// <param name="keypointDetector">The keypoint detector to wrap.</param>
    /// <param name="descriptorExtractor">The descriptor extractor to wrap.</param>
    public static AffineFeature2D Create(Feature2D keypointDetector, Feature2D descriptorExtractor)
    {
        ArgumentNullException.ThrowIfNull(keypointDetector);
        ArgumentNullException.ThrowIfNull(descriptorExtractor);
        keypointDetector.ThrowIfDisposed();
        descriptorExtractor.ThrowIfDisposed();

        NativeMethods.HandleException(
            NativeMethods.xfeatures2d_AffineFeature2D_create1(keypointDetector.SmartPtr, descriptorExtractor.SmartPtr, out var ptr));
        NativeMethods.HandleException(NativeMethods.xfeatures2d_Ptr_AffineFeature2D_get(ptr, out var rawPtr));
        GC.KeepAlive(keypointDetector);
        GC.KeepAlive(descriptorExtractor);
        return new AffineFeature2D(ptr, rawPtr);
    }

    /// <summary>
    /// Creates an instance where the keypoint detector and descriptor extractor are identical.
    /// </summary>
    /// <param name="keypointDetector">The keypoint detector/descriptor extractor to wrap.</param>
    public static AffineFeature2D Create(Feature2D keypointDetector)
    {
        ArgumentNullException.ThrowIfNull(keypointDetector);
        keypointDetector.ThrowIfDisposed();

        NativeMethods.HandleException(
            NativeMethods.xfeatures2d_AffineFeature2D_create2(keypointDetector.SmartPtr, out var ptr));
        NativeMethods.HandleException(NativeMethods.xfeatures2d_Ptr_AffineFeature2D_get(ptr, out var rawPtr));
        GC.KeepAlive(keypointDetector);
        return new AffineFeature2D(ptr, rawPtr);
    }

    /// <summary>
    /// Detects keypoints in the image using the wrapped detector and performs affine adaptation
    /// to augment them with their elliptic regions.
    /// </summary>
    /// <param name="image">Image.</param>
    /// <param name="mask">Mask specifying where to look for keypoints (optional).</param>
    /// <returns>The detected elliptic keypoints.</returns>
    public EllipticKeyPoint[] DetectElliptic(InputArray image, InputArray mask = default)
    {
        ThrowIfDisposed();

        using var keypoints = new StdVector<EllipticKeyPoint>();
        NativeMethods.HandleException(
            NativeMethods.xfeatures2d_AffineFeature2D_detect(Handle, image.Proxy, keypoints.CvPtr, mask.Proxy));
        GC.KeepAlive(image.Source);
        GC.KeepAlive(mask.Source);
        return keypoints.ToArray();
    }

    /// <summary>
    /// Detects keypoints and computes descriptors for their surrounding regions, after warping
    /// them into circles.
    /// </summary>
    /// <remarks>
    /// OpenCV's native calcAffineCovariantDescriptors (opencv_contrib
    /// xfeatures2d/src/affine_feature2d.cpp) has been observed to throw an assertion failure
    /// when the wrapped descriptor extractor is ORB (a binary/CV_8U descriptor); SIFT-family
    /// extractors work correctly.
    /// </remarks>
    /// <param name="image">Image.</param>
    /// <param name="mask">Mask specifying where to look for keypoints (optional).</param>
    /// <param name="descriptors">Computed descriptors.</param>
    /// <param name="useProvidedKeypoints">If true, <paramref name="providedKeypoints"/> is used
    /// as input instead of running detection.</param>
    /// <param name="providedKeypoints">Keypoints to use when <paramref name="useProvidedKeypoints"/>
    /// is true.</param>
    /// <returns>The elliptic keypoints (either newly detected, or the augmented input keypoints
    /// when <paramref name="useProvidedKeypoints"/> is true).</returns>
    public EllipticKeyPoint[] DetectAndComputeElliptic(
        InputArray image, InputArray mask, OutputArray descriptors,
        bool useProvidedKeypoints = false, IEnumerable<EllipticKeyPoint>? providedKeypoints = null)
    {
        ThrowIfDisposed();

        using var keypoints = useProvidedKeypoints
            ? new StdVector<EllipticKeyPoint>(providedKeypoints ?? throw new ArgumentNullException(nameof(providedKeypoints)))
            : new StdVector<EllipticKeyPoint>();
        NativeMethods.HandleException(
            NativeMethods.xfeatures2d_AffineFeature2D_detectAndCompute(
                Handle, image.Proxy, mask.Proxy, keypoints.CvPtr, descriptors.Proxy, useProvidedKeypoints ? 1 : 0));
        GC.KeepAlive(image.Source);
        GC.KeepAlive(mask.Source);
        GC.KeepAlive(descriptors.Source);
        return keypoints.ToArray();
    }
}
