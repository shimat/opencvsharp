using OpenCvSharp.Internal;

namespace OpenCvSharp.Segmentation;

/// <summary>
/// Intelligent Scissors image segmentation
/// 
/// This class is used to find the path (contour) between two points
/// which can be used for image segmentation.
/// 
/// Usage example:
/// @snippet snippets/imgproc_segmentation.cpp usage_example_intelligent_scissors
/// 
/// Reference: Intelligent Scissors for Image Composition http://citeseerx.ist.psu.edu/viewdoc/download?doi=10.1.1.138.3811&amp;rep=rep1&amp;type=pdf
/// algorithm designed by Eric N. Mortensen and William A. Barrett, Brigham Young University
/// @cite Mortensen95intelligentscissors
/// </summary>
public class IntelligentScissorsMB : DisposableCvObject
{
    /// <summary>
    /// Constructor
    /// </summary>
    public IntelligentScissorsMB()
    {
        NativeMethods.HandleException(
            NativeMethods.imgproc_segmentation_IntelligentScissorsMB_new(out ptr));
    }

    /// <summary>
    /// Releases unmanaged resources
    /// </summary>
    protected override void DisposeUnmanaged()
    {
        NativeMethods.HandleException(
            NativeMethods.imgproc_segmentation_IntelligentScissorsMB_delete(ptr));
        base.DisposeUnmanaged();
    }

    /// <summary>
    /// Specify weights of feature functions
    /// 
    /// Consider keeping weights normalized (sum of weights equals to 1.0)
    /// Discrete dynamic programming (DP) goal is minimization of costs between pixels.
    /// </summary>
    /// <param name="weightNonEdge">Specify cost of non-edge pixels (default: 0.43f)</param>
    /// <param name="weightGradientDirection">Specify cost of gradient direction function (default: 0.43f)</param>
    /// <param name="weightGradientMagnitude">Specify cost of gradient magnitude function (default: 0.14f)</param>
    /// <returns></returns>
    public IntelligentScissorsMB SetWeights(
        float weightNonEdge, float weightGradientDirection, float weightGradientMagnitude)
    {
        ThrowIfDisposed();

        NativeMethods.HandleException(
            NativeMethods.imgproc_segmentation_IntelligentScissorsMB_setWeights(
                ptr, weightNonEdge, weightGradientDirection, weightGradientMagnitude));

        return this;
    }

    /// <summary>
    /// Specify gradient magnitude max value threshold
    /// 
    /// Zero limit value is used to disable gradient magnitude thresholding (default behavior, as described in original article).
    /// Otherwize pixels with `gradient magnitude >= threshold` have zero cost.
    /// 
    /// @note Thresholding should be used for images with irregular regions (to avoid stuck on parameters from high-contract areas, like embedded logos).
    /// </summary>
    /// <param name="gradientMagnitudeThresholdMax">Specify gradient magnitude max value threshold (default: 0, disabled)</param>
    /// <returns></returns>
    public IntelligentScissorsMB SetGradientMagnitudeMaxLimit(
        float gradientMagnitudeThresholdMax = 0.0f)
    {
        ThrowIfDisposed();

        NativeMethods.HandleException(
            NativeMethods.imgproc_segmentation_IntelligentScissorsMB_setGradientMagnitudeMaxLimit(
                ptr, gradientMagnitudeThresholdMax));

        return this;
    }

    /// <summary>
    /// Switch to "Laplacian Zero-Crossing" edge feature extractor and specify its parameters
    /// 
    /// This feature extractor is used by default according to article.
    /// 
    /// Implementation has additional filtering for regions with low-amplitude noise.
    /// This filtering is enabled through parameter of minimal gradient amplitude (use some small value 4, 8, 16).
    /// 
    /// @note Current implementation of this feature extractor is based on processing of grayscale images (color image is converted to grayscale image first).
    /// 
    /// @note Canny edge detector is a bit slower, but provides better results (especially on color images): use setEdgeFeatureCannyParameters().
    /// </summary>
    /// <param name="gradientMagnitudeMinValue">Minimal gradient magnitude value for edge pixels (default: 0, check is disabled)</param>
    /// <returns></returns>
    public IntelligentScissorsMB SetEdgeFeatureZeroCrossingParameters(
        float gradientMagnitudeMinValue = 0.0f)
    {
        ThrowIfDisposed();
            
        NativeMethods.HandleException(
            NativeMethods.imgproc_segmentation_IntelligentScissorsMB_setEdgeFeatureZeroCrossingParameters(
                ptr, gradientMagnitudeMinValue));

        return this;
    }

    /// <summary>
    /// Switch edge feature extractor to use Canny edge detector
    /// Note: "Laplacian Zero-Crossing" feature extractor is used by default (following to original article)
    /// </summary>
    /// <param name="threshold1"></param>
    /// <param name="threshold2"></param>
    /// <param name="apertureSize"></param>
    /// <param name="l2gradient"></param>
    /// <returns></returns>
    public IntelligentScissorsMB SetEdgeFeatureCannyParameters(
        double threshold1, double threshold2,
        int apertureSize = 3, bool l2gradient = false)
    {
        ThrowIfDisposed();
            
        NativeMethods.HandleException(
            NativeMethods.imgproc_segmentation_IntelligentScissorsMB_setEdgeFeatureCannyParameters(
                ptr, threshold1, threshold2, apertureSize, l2gradient ? 1 : 0));

        return this;
    }

    /// <summary>
    /// Specify input image and extract image features
    /// </summary>
    /// <param name="image">input image. Type is #CV_8UC1 / #CV_8UC3</param>
    /// <returns></returns>
    public IntelligentScissorsMB ApplyImage(InputArray image)
    {
        ThrowIfDisposed();
        if (image is null)
            throw new ArgumentNullException(nameof(image));
            
        NativeMethods.HandleException(
            NativeMethods.imgproc_segmentation_IntelligentScissorsMB_applyImage(
                ptr, image.CvPtr));

        return this;
    }

    /// <summary>
    /// Specify custom features of imput image
    /// Customized advanced variant of applyImage() call.
    /// </summary>
    /// <param name="nonEdge">Specify cost of non-edge pixels. Type is CV_8UC1. Expected values are `{0, 1}`.</param>
    /// <param name="gradientDirection">Specify gradient direction feature. Type is CV_32FC2. Values are expected to be normalized: `x^2 + y^2 == 1`</param>
    /// <param name="gradientMagnitude">Specify cost of gradient magnitude function: Type is CV_32FC1. Values should be in range `[0, 1]`.</param>
    /// <param name="image">Optional parameter. Must be specified if subset of features is specified (non-specified features are calculated internally)</param>
    /// <returns></returns>
    public IntelligentScissorsMB ApplyImageFeatures(
        InputArray nonEdge, InputArray gradientDirection, InputArray gradientMagnitude,
        InputArray? image = null)
    {
        ThrowIfDisposed();
        if (nonEdge is null)
            throw new ArgumentNullException(nameof(nonEdge));
        if (gradientDirection is null)
            throw new ArgumentNullException(nameof(gradientDirection));
        if (gradientMagnitude is null)
            throw new ArgumentNullException(nameof(gradientMagnitude));
            
        NativeMethods.HandleException(
            NativeMethods.imgproc_segmentation_IntelligentScissorsMB_applyImageFeatures(
                ptr, nonEdge.CvPtr, gradientDirection.CvPtr, gradientMagnitude.CvPtr, image?.CvPtr ?? IntPtr.Zero));

        return this;
    }

    /// <summary>
    /// Prepares a map of optimal paths for the given source point on the image
    /// Note: applyImage() / applyImageFeatures() must be called before this call
    /// </summary>
    /// <param name="sourcePt">The source point used to find the paths</param>
    public void BuildMap(Point sourcePt)
    {
        ThrowIfDisposed();
            
        NativeMethods.HandleException(
            NativeMethods.imgproc_segmentation_IntelligentScissorsMB_buildMap(
                ptr, sourcePt));
    }

    /// <summary>
    /// Extracts optimal contour for the given target point on the image
    /// Note: buildMap() must be called before this call
    /// </summary>
    /// <param name="targetPt">The target point</param>
    /// <param name="contour">contour The list of pixels which contains optimal path between the source and the target points of the image. 
    /// Type is CV_32SC2 (compatible with `std::vector&lt;Point&gt;`)</param>
    /// <param name="backward">Flag to indicate reverse order of retrived pixels (use "true" value to fetch points from the target to the source point)</param>
    public void GetContour(Point targetPt, OutputArray contour, bool backward = false)
    {
        ThrowIfDisposed();
        if (contour is null)
            throw new ArgumentNullException(nameof(contour));
            
        NativeMethods.HandleException(
            NativeMethods.imgproc_segmentation_IntelligentScissorsMB_getContour(
                ptr, targetPt, contour.CvPtr, backward ? 1 : 0));
    }
}
