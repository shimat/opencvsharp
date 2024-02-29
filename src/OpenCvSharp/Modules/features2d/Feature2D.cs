using OpenCvSharp.Internal;
using OpenCvSharp.Internal.Vectors;

namespace OpenCvSharp;

/// <summary>
/// Abstract base class for 2D image feature detectors and descriptor extractors
/// </summary>
public class Feature2D : Algorithm
{
    /// <inheritdoc />
    protected Feature2D()
    {
    }

    #region Properties

    /// <summary> 
    /// </summary>
    /// <returns></returns>
    public virtual int DescriptorSize
    {
        get
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.features2d_Feature2D_descriptorSize(ptr, out var ret));
            GC.KeepAlive(this);
            return ret;
        }
    }

    /// <summary> 
    /// </summary>
    /// <returns></returns>
    public virtual int DescriptorType
    {
        get
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.features2d_Feature2D_descriptorType(ptr, out var ret));
            GC.KeepAlive(this);
            return ret;
        }
    }

    /// <summary> 
    /// </summary>
    /// <returns></returns>
    public virtual int DefaultNorm
    {
        get
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.features2d_Feature2D_defaultNorm(ptr, out var ret));
            GC.KeepAlive(this);
            return ret;
        }
    }

    #endregion

    #region Methods

    /// <summary>
    /// Return true if detector object is empty
    /// </summary>
    /// <returns></returns>
    public new virtual bool Empty()
    {
        ThrowIfDisposed();
        NativeMethods.HandleException(
            NativeMethods.features2d_Feature2D_empty(ptr, out var ret));
        GC.KeepAlive(this);
        return ret != 0;
    }

    /// <summary>
    /// Detect keypoints in an image.
    /// </summary>
    /// <param name="image">The image.</param>
    /// <param name="mask">Mask specifying where to look for keypoints (optional). 
    /// Must be a char matrix with non-zero values in the region of interest.</param>
    /// <returns>The detected keypoints.</returns>
    public KeyPoint[] Detect(Mat image, Mat? mask = null)
    {
        if (image is null)
            throw new ArgumentNullException(nameof(image));
        ThrowIfDisposed();

        image.ThrowIfDisposed();
        try
        {
            using var keyPoints = new VectorOfKeyPoint();
            NativeMethods.HandleException(
                NativeMethods.features2d_Feature2D_detect_Mat1(ptr, image.CvPtr, keyPoints.CvPtr, Cv2.ToPtr(mask)));
            return keyPoints.ToArray();
        }
        finally
        {
            GC.KeepAlive(this);
            GC.KeepAlive(image);
            GC.KeepAlive(mask);
        }
    }

    /// <summary>
    /// Detect keypoints in an image.
    /// </summary>
    /// <param name="image">The image.</param>
    /// <param name="mask">Mask specifying where to look for keypoints (optional). 
    /// Must be a char matrix with non-zero values in the region of interest.</param>
    /// <returns>The detected keypoints.</returns>
    public KeyPoint[] Detect(InputArray image, Mat? mask = null)
    {
        if (image is null)
            throw new ArgumentNullException(nameof(image));
        ThrowIfDisposed();

        image.ThrowIfDisposed();
        try
        {
            using var keypoints = new VectorOfKeyPoint();
            NativeMethods.HandleException(
                NativeMethods.features2d_Feature2D_detect_InputArray(ptr, image.CvPtr, keypoints.CvPtr, Cv2.ToPtr(mask)));
            return keypoints.ToArray();
        }
        finally
        {
            GC.KeepAlive(this);
            GC.KeepAlive(image);
            GC.KeepAlive(mask);
        }
    }

    /// <summary>
    /// Detect keypoints in an image set.
    /// </summary>
    /// <param name="images">Image collection.</param>
    /// <param name="masks">Masks for image set. masks[i] is a mask for images[i].</param>
    /// <returns>Collection of keypoints detected in an input images. keypoints[i] is a set of keypoints detected in an images[i].</returns>
    public KeyPoint[][] Detect(IEnumerable<Mat> images, IEnumerable<Mat>? masks = null)
    {
        if (images is null)
            throw new ArgumentNullException(nameof(images));
        ThrowIfDisposed();

        var imagesArray = images.ToArray();
        var imagesPtr = new IntPtr[imagesArray.Length];
        for (var i = 0; i < imagesArray.Length; i++)
            imagesPtr[i] = imagesArray[i].CvPtr;

        using var keypoints = new VectorOfVectorKeyPoint();
        IntPtr[]? masksPtr = null;
        if (masks is not null)
        {
            masksPtr = masks.Select(x => x.CvPtr).ToArray();
            if (masksPtr.Length != imagesArray.Length)
                throw new ArgumentException("masks.Length != images.Length");
        }

        NativeMethods.HandleException(
            NativeMethods.features2d_Feature2D_detect_Mat2(
                ptr, imagesPtr, imagesArray.Length, keypoints.CvPtr, masksPtr));
        GC.KeepAlive(masks);

        GC.KeepAlive(this);
        GC.KeepAlive(imagesArray);
        return keypoints.ToArray();
    }

    /// <summary>
    /// Compute the descriptors for a set of keypoints in an image.
    /// </summary>
    /// <param name="image">The image.</param>
    /// <param name="keypoints">The input keypoints. Keypoints for which a descriptor cannot be computed are removed.</param>
    /// <param name="descriptors">Computed descriptors. Row i is the descriptor for KeyPoint i.</param>param>
    public virtual void Compute(InputArray image, ref KeyPoint[] keypoints, OutputArray descriptors)
    {
        if (image is null)
            throw new ArgumentNullException(nameof(image));
        if (descriptors is null) 
            throw new ArgumentNullException(nameof(descriptors));
        ThrowIfDisposed();

        using var keypointsVec = new VectorOfKeyPoint(keypoints);
        NativeMethods.HandleException(
            NativeMethods.features2d_Feature2D_compute1(ptr, image.CvPtr, keypointsVec.CvPtr, descriptors.CvPtr));
        keypoints = keypointsVec.ToArray();

        GC.KeepAlive(this);
        GC.KeepAlive(image);
        GC.KeepAlive(descriptors);
    }

    /// <summary>
    /// Compute the descriptors for a keypoints collection detected in image collection.
    /// </summary>
    /// <param name="images">Image collection.</param>
    /// <param name="keypoints">Input keypoints collection. keypoints[i] is keypoints detected in images[i].
    /// Keypoints for which a descriptor cannot be computed are removed.</param>
    /// <param name="descriptors">Descriptor collection. descriptors[i] are descriptors computed for set keypoints[i].</param>
    public virtual void Compute(IEnumerable<Mat> images, ref KeyPoint[][] keypoints, IEnumerable<Mat> descriptors)
    {
        ThrowIfDisposed();
        if (images is null)
            throw new ArgumentNullException(nameof(images));
        if (descriptors is null)
            throw new ArgumentNullException(nameof(descriptors));

        var imagesPtrs = images.Select(x => x.CvPtr).ToArray();
        var descriptorsPtrs = descriptors.Select(x => x.CvPtr).ToArray();

        using var keypointsVec = new VectorOfVectorKeyPoint(keypoints);

        NativeMethods.HandleException(
            NativeMethods.features2d_Feature2D_compute2(
                ptr, imagesPtrs, imagesPtrs.Length, keypointsVec.CvPtr,
                descriptorsPtrs, descriptorsPtrs.Length));
        keypoints = keypointsVec.ToArray();

        GC.KeepAlive(this);
        GC.KeepAlive(images);
        GC.KeepAlive(descriptors);
    }

    /// <summary>
    /// Detects keypoints and computes the descriptors
    /// </summary>
    /// <param name="image"></param>
    /// <param name="mask"></param>
    /// <param name="keypoints"></param>
    /// <param name="descriptors"></param>
    /// <param name="useProvidedKeypoints"></param>
    public virtual void DetectAndCompute(
        InputArray image,
        InputArray? mask,
        out KeyPoint[] keypoints,
        OutputArray descriptors,
        bool useProvidedKeypoints = false)
    {
        ThrowIfDisposed();
        if (image is null)
            throw new ArgumentNullException(nameof(image));
        if (descriptors is null)
            throw new ArgumentNullException(nameof(descriptors));
        image.ThrowIfDisposed();
        mask?.ThrowIfDisposed();

        using var keypointsVec = new VectorOfKeyPoint();

        NativeMethods.HandleException(
            NativeMethods.features2d_Feature2D_detectAndCompute(
                ptr, image.CvPtr, Cv2.ToPtr(mask), keypointsVec.CvPtr, descriptors.CvPtr,
                useProvidedKeypoints ? 1 : 0));
        keypoints = keypointsVec.ToArray();

        GC.KeepAlive(this);
        GC.KeepAlive(image);
        GC.KeepAlive(mask);
        descriptors.Fix();
        GC.KeepAlive(descriptors);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="fileName"></param>
    public void Write(string fileName)
    {
        ThrowIfDisposed();
        if (string.IsNullOrEmpty(fileName)) 
            throw new ArgumentNullException(nameof(fileName));

        NativeMethods.HandleException(
            NativeMethods.features2d_Feature2D_write(ptr, fileName));
        GC.KeepAlive(this);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="fileName"></param>
    public void Read(string fileName)
    {
        ThrowIfDisposed();
        if (string.IsNullOrEmpty(fileName)) 
            throw new ArgumentNullException(nameof(fileName));

        NativeMethods.HandleException(
            NativeMethods.features2d_Feature2D_read(ptr, fileName));
        GC.KeepAlive(this);
    }
        
    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public override string GetDefaultName()
    {
        ThrowIfDisposed();

        using var returnValue = new StdString();
        NativeMethods.HandleException(
            NativeMethods.features2d_Feature2D_getDefaultName(ptr, returnValue.CvPtr));
        GC.KeepAlive(this);
        return returnValue.ToString();
    }

    #endregion
}
