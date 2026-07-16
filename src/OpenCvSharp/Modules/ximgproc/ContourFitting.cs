using OpenCvSharp.Internal;

// ReSharper disable once CheckNamespace
namespace OpenCvSharp.XImgProc;

/// <summary>
/// Class for ContourFitting algorithms.
/// ContourFitting matches two contours minimizing distance
/// using their Fourier descriptors, a scaling factor, an angle rotation and a starting point factor
/// adjustment.
/// </summary>
public class ContourFitting : Algorithm
{
    /// <summary>
    /// Creates instance by raw pointer
    /// </summary>
    private ContourFitting(IntPtr smartPtr, IntPtr rawPtr)
        : base(smartPtr, rawPtr, p => NativeMethods.HandleException(NativeMethods.ximgproc_Ptr_ContourFitting_delete(p)))
    { }

    /// <summary>
    /// Creates a ContourFitting algorithm object.
    /// </summary>
    /// <param name="ctr">number of Fourier descriptors equal to number of contour points after resampling.</param>
    /// <param name="fd">number of Fourier descriptors used for optimal curve matching.</param>
    /// <returns></returns>
    public static ContourFitting Create(int ctr = 1024, int fd = 16)
    {
        NativeMethods.HandleException(
            NativeMethods.ximgproc_createContourFitting(ctr, fd, out var smartPtr));

        NativeMethods.HandleException(NativeMethods.ximgproc_Ptr_ContourFitting_get(smartPtr, out var rawPtr));
        return new ContourFitting(smartPtr, rawPtr);
    }

    /// <summary>
    /// Fit two closed curves using Fourier descriptors.
    /// </summary>
    /// <param name="src">Contour defining first shape.</param>
    /// <param name="dst">Contour defining second shape (Target).</param>
    /// <param name="alphaPhiST">alpha=alphaPhiST(0,0), phi=alphaPhiST(0,1) (in radian), s=alphaPhiST(0,2),
    /// Tx=alphaPhiST(0,3), Ty=alphaPhiST(0,4) rotation center.</param>
    /// <param name="dist">distance between src and dst after matching.</param>
    /// <param name="fdContour">false then src and dst are contours and true src and dst are Fourier descriptors.</param>
    public virtual void EstimateTransformation(
        InputArray src, InputArray dst, OutputArray alphaPhiST, out double dist, bool fdContour = false)
    {
        ThrowIfDisposed();

        NativeMethods.HandleException(
            NativeMethods.ximgproc_ContourFitting_estimateTransformation(
                Handle, src.Proxy, dst.Proxy, alphaPhiST.Proxy, out dist, fdContour ? 1 : 0));

        GC.KeepAlive(src.Source);
        GC.KeepAlive(dst.Source);
        GC.KeepAlive(alphaPhiST.Source);
    }

    /// <summary>
    /// Number of Fourier descriptors equal to number of contour points after resampling, used in
    /// EstimateTransformation.
    /// </summary>
    public int CtrSize
    {
        get
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.ximgproc_ContourFitting_getCtrSize(Handle, out var ret));
            return ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.ximgproc_ContourFitting_setCtrSize(Handle, value));
        }
    }

    /// <summary>
    /// Number of Fourier descriptors used for optimal curve matching when EstimateTransformation is
    /// used with a vector of points.
    /// </summary>
    public int FDSize
    {
        get
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.ximgproc_ContourFitting_getFDSize(Handle, out var ret));
            return ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.ximgproc_ContourFitting_setFDSize(Handle, value));
        }
    }
}
