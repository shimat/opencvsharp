using OpenCvSharp.Internal;

// ReSharper disable once CheckNamespace
namespace OpenCvSharp.XImgProc;

/// <summary>
/// Class implementing the F-DBSCAN (Accelerated superpixel image segmentation with a parallelized
/// DBSCAN algorithm) superpixels algorithm.
///
/// The algorithm uses a parallelised DBSCAN cluster search that is resistant to noise, competitive
/// in segmentation quality, and faster than existing superpixel segmentation methods. The output is
/// deterministic when the number of processing threads is fixed, and requires the source image to
/// be in Lab colour format.
/// </summary>
public class ScanSegment : Algorithm
{
    /// <summary>
    /// Creates instance by raw pointer
    /// </summary>
    private ScanSegment(IntPtr smartPtr, IntPtr rawPtr)
        : base(smartPtr, rawPtr, p => NativeMethods.HandleException(NativeMethods.ximgproc_Ptr_ScanSegment_delete(p)))
    { }

    /// <summary>
    /// Initializes a ScanSegment object.
    ///
    /// The function initializes a ScanSegment object for the input image. It stores the parameters of
    /// the image: image_width and image_height. It also sets the parameters of the F-DBSCAN superpixel
    /// algorithm, which are: num_superpixels, threads, and merge_small.
    /// </summary>
    /// <param name="imageWidth">Image width.</param>
    /// <param name="imageHeight">Image height.</param>
    /// <param name="numSuperpixels">Desired number of superpixels. Note that the actual number may be
    /// smaller due to restrictions (depending on the image size). Use GetNumberOfSuperpixels() to get
    /// the actual number.</param>
    /// <param name="slices">Number of processing threads for parallelisation. Setting -1 uses the
    /// maximum number of threads. In practice, four threads is enough for smaller images and eight
    /// threads for larger ones.</param>
    /// <param name="mergeSmall">Merge small segments to give the desired number of superpixels.
    /// Processing is much faster without merging, but many small segments will be left in the image.</param>
    /// <returns></returns>
    public static ScanSegment Create(
        int imageWidth, int imageHeight, int numSuperpixels, int slices = 8, bool mergeSmall = true)
    {
        NativeMethods.HandleException(
            NativeMethods.ximgproc_createScanSegment(
                imageWidth, imageHeight, numSuperpixels, slices, mergeSmall ? 1 : 0, out var smartPtr));

        NativeMethods.HandleException(NativeMethods.ximgproc_Ptr_ScanSegment_get(smartPtr, out var rawPtr));
        return new ScanSegment(smartPtr, rawPtr);
    }

    /// <summary>
    /// Returns the actual superpixel segmentation from the last image processed using Iterate.
    /// Returns zero if no image has been processed.
    /// </summary>
    /// <returns></returns>
    public virtual int GetNumberOfSuperpixels()
    {
        ThrowIfDisposed();
        NativeMethods.HandleException(
            NativeMethods.ximgproc_ScanSegment_getNumberOfSuperpixels(Handle, out var ret));
        return ret;
    }

    /// <summary>
    /// Calculates the superpixel segmentation on a given image with the initialized parameters in the
    /// ScanSegment object.
    ///
    /// This function can be called again for other images without the need of initializing the
    /// algorithm with Create(). This saves the computational cost of allocating memory for all the
    /// structures of the algorithm.
    /// </summary>
    /// <param name="img">Input image. Supported format: CV_8UC3. Image size must match with the
    /// initialized image size with the function Create(). It MUST be in Lab color space.</param>
    public virtual void Iterate(InputArray img)
    {
        ThrowIfDisposed();

        NativeMethods.HandleException(
            NativeMethods.ximgproc_ScanSegment_iterate(Handle, img.Proxy));

        GC.KeepAlive(img.Source);
    }

    /// <summary>
    /// Returns the segmentation labeling of the image.
    /// Each label represents a superpixel, and each pixel is assigned to one superpixel label.
    /// </summary>
    /// <param name="labelsOut">Return: A CV_32UC1 integer array containing the labels of the
    /// superpixel segmentation. The labels are in the range [0, GetNumberOfSuperpixels()].</param>
    public virtual void GetLabels(OutputArray labelsOut)
    {
        ThrowIfDisposed();

        NativeMethods.HandleException(
            NativeMethods.ximgproc_ScanSegment_getLabels(Handle, labelsOut.Proxy));

        GC.KeepAlive(labelsOut.Source);
    }

    /// <summary>
    /// Returns the mask of the superpixel segmentation stored in the ScanSegment object.
    /// The function returns the boundaries of the superpixel segmentation.
    /// </summary>
    /// <param name="image">Return: CV_8UC1 image mask where -1 indicates that the pixel is a
    /// superpixel border, and 0 otherwise.</param>
    /// <param name="thickLine">If false, the border is only one pixel wide, otherwise all pixels at
    /// the border are masked.</param>
    public virtual void GetLabelContourMask(OutputArray image, bool thickLine = false)
    {
        ThrowIfDisposed();

        NativeMethods.HandleException(
            NativeMethods.ximgproc_ScanSegment_getLabelContourMask(Handle, image.Proxy, thickLine ? 1 : 0));

        GC.KeepAlive(image.Source);
    }
}
