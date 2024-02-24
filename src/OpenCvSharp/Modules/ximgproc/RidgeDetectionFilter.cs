using OpenCvSharp.Internal;

namespace OpenCvSharp;

/// <summary>
/// Applies Ridge Detection Filter to an input image.
/// 
/// Implements Ridge detection similar to the one in [Mathematica](http://reference.wolfram.com/language/ref/RidgeFilter.html)
/// using the eigen values from the Hessian Matrix of the input image using Sobel Derivatives.
/// Additional refinement can be done using Skeletonization and Binarization. Adapted from @cite segleafvein and @cite M_RF
/// </summary>
public class RidgeDetectionFilter : Algorithm
{
    private Ptr? ptrObj;

    /// <summary>
    /// Constructor
    /// </summary>
    protected RidgeDetectionFilter(IntPtr p)
    {
        ptrObj = new Ptr(p);
        ptr = ptrObj.Get();
    }

    /// <summary>
    /// Create pointer to the Ridge detection filter.
    /// </summary>
    /// <param name="ddepth">Specifies output image depth. Defualt is CV_32FC1</param>
    /// <param name="dx">Order of derivative x, default is 1</param>
    /// <param name="dy">Order of derivative y, default is 1</param>
    /// <param name="ksize">Sobel kernel size , default is 3</param>
    /// <param name="outDtype">Converted format for output, default is CV_8UC1</param>
    /// <param name="scale">Optional scale value for derivative values, default is 1</param>
    /// <param name="delta">Optional bias added to output, default is 0</param>
    /// <param name="borderType">Pixel extrapolation method, default is BORDER_DEFAULT</param>
    /// <returns></returns>
    public static RidgeDetectionFilter Create(
        MatType? ddepth = null,
        int dx = 1,
        int dy = 1,
        int ksize = 3,
        MatType? outDtype = null,
        double scale = 1,
        double delta = 0,
        BorderTypes borderType = BorderTypes.Default)
    {
        var ddepthValue = ddepth.GetValueOrDefault(MatType.CV_32FC1);
        var outDtypeValue = outDtype.GetValueOrDefault(MatType.CV_8UC1);

        NativeMethods.HandleException(
            NativeMethods.ximgproc_RidgeDetectionFilter_create(
                ddepthValue, dx, dy, ksize,
                outDtypeValue, scale, delta, (int)borderType,
                out var ptr));

        return new RidgeDetectionFilter(ptr);
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
    /// Apply Ridge detection filter on input image.
    /// </summary>
    /// <param name="src">InputArray as supported by Sobel. img can be 1-Channel or 3-Channels.</param>
    /// <param name="dst">OutputAray of structure as RidgeDetectionFilter::ddepth. Output image with ridges.</param>
    public virtual void GetRidgeFilteredImage(InputArray src, OutputArray dst)
    {
        if (src is null)
            throw new ArgumentNullException(nameof(src));
        if (dst is null)
            throw new ArgumentNullException(nameof(dst));
        ThrowIfDisposed();
        NativeMethods.HandleException(
            NativeMethods.ximgproc_RidgeDetectionFilter_getRidgeFilteredImage(ptr, src.CvPtr, dst.CvPtr));
        GC.KeepAlive(this);
    }

    internal class Ptr : OpenCvSharp.Ptr
    {
        public Ptr(IntPtr ptr) : base(ptr)
        {
        }

        public override IntPtr Get()
        {
            NativeMethods.HandleException(
                NativeMethods.ximgproc_Ptr_RFFeatureGetter_get(ptr, out var ret));
            GC.KeepAlive(this);
            return ret;
        }

        protected override void DisposeUnmanaged()
        {
            NativeMethods.HandleException(
                NativeMethods.ximgproc_Ptr_RFFeatureGetter_delete(ptr));
            base.DisposeUnmanaged();
        }
    }
}
