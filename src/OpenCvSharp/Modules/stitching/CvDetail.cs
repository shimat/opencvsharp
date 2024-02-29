using OpenCvSharp.Internal;
using OpenCvSharp.Internal.Vectors;

// ReSharper disable UnusedMember.Global

namespace OpenCvSharp.Detail;

/// <summary>
/// cv::detail functions
/// </summary>
public static class CvDetail
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="featuresFinder"></param>
    /// <param name="images"></param>
    /// <param name="masks"></param>
    public static ImageFeatures[] ComputeImageFeatures(
        Feature2D featuresFinder,
        IEnumerable<Mat> images,
        IEnumerable<Mat>? masks = null)
    {
        if (featuresFinder is null)
            throw new ArgumentNullException(nameof(featuresFinder));
        if (images is null)
            throw new ArgumentNullException(nameof(images));
        featuresFinder.ThrowIfDisposed();

        var imagesArray = images as Mat[] ?? images.ToArray();
        if (imagesArray.Length == 0)
            throw new ArgumentException("Empty array", nameof(images));
            
        var imagesPointers = imagesArray.Select(i => i.CvPtr).ToArray();
        var masksPointers = masks?.Select(i => i.CvPtr).ToArray();
        if (masksPointers is not null && imagesPointers.Length != masksPointers.Length)
            throw new ArgumentException("size of images != size of masks");

        using var wImageFeaturesVec = new VectorOfImageFeatures();
        NativeMethods.HandleException(
            NativeMethods.stitching_computeImageFeatures1(
                featuresFinder.CvPtr,
                imagesPointers,
                imagesPointers.Length,
                wImageFeaturesVec.CvPtr,
                masksPointers));
            
        GC.KeepAlive(featuresFinder);
        GC.KeepAlive(images);
        GC.KeepAlive(masks);
        GC.KeepAlive(imagesPointers);

        return wImageFeaturesVec.ToArray();
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="featuresFinder"></param>
    /// <param name="image"></param>
    /// <param name="mask"></param>
    public static ImageFeatures ComputeImageFeatures(
        Feature2D featuresFinder,
        InputArray image,
        InputArray? mask = null)
    {
        if (featuresFinder is null)
            throw new ArgumentNullException(nameof(featuresFinder));
        if (image is null)
            throw new ArgumentNullException(nameof(image));
        featuresFinder.ThrowIfDisposed();
        image.ThrowIfDisposed();

        var descriptorsMat = new Mat();
        using var keypointsVec = new VectorOfKeyPoint();
        var wImageFeatures = new WImageFeatures
        {
            Keypoints = keypointsVec.CvPtr,
            Descriptors = descriptorsMat.CvPtr
        };

        unsafe
        {
            NativeMethods.HandleException(
                NativeMethods.stitching_computeImageFeatures2(
                    featuresFinder.CvPtr, image.CvPtr, &wImageFeatures, mask?.CvPtr ?? IntPtr.Zero));
        }
            
        GC.KeepAlive(featuresFinder);
        GC.KeepAlive(image);
        GC.KeepAlive(mask);
        GC.KeepAlive(descriptorsMat);

        return new ImageFeatures(
            wImageFeatures.ImgIdx,
            wImageFeatures.ImgSize,
            keypointsVec.ToArray(),
            descriptorsMat);
    }
}
