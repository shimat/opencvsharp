using OpenCvSharp.Internal;

namespace OpenCvSharp;

/// <summary>
/// Class computing a dense optical flow using the Gunnar Farneback's algorithm.
/// </summary>
public class FarnebackOpticalFlow : DenseOpticalFlow
{
    private FarnebackOpticalFlow(IntPtr smartPtr, IntPtr rawPtr)
        : base(smartPtr, rawPtr, p => NativeMethods.HandleException(NativeMethods.video_Ptr_FarnebackOpticalFlow_delete(p)))
    { }

    /// <summary>
    /// Creates instance of cv::FarnebackOpticalFlow.
    /// </summary>
    /// <param name="numLevels">number of pyramid layers including the initial image; levels=1 means that
    /// no extra layers are created and only the original images are used.</param>
    /// <param name="pyrScale">parameter, specifying the image scale (&lt;1) to build pyramids for each image;
    /// pyrScale=0.5 means a classical pyramid, where each next layer is twice smaller than the previous one.</param>
    /// <param name="fastPyramids"></param>
    /// <param name="winSize">averaging window size; larger values increase the algorithm robustness to
    /// image noise and give more chances for fast motion detection, but yield more blurred motion field.</param>
    /// <param name="numIters">number of iterations the algorithm does at each pyramid level.</param>
    /// <param name="polyN">size of the pixel neighborhood used to find polynomial expansion in each pixel;
    /// larger values mean that the image will be approximated with smoother surfaces, yielding more
    /// robust algorithm and more blurred motion field, typically polyN =5 or 7.</param>
    /// <param name="polySigma">standard deviation of the Gaussian that is used to smooth derivatives used as a
    /// basis for the polynomial expansion; for polyN=5, you can set polySigma=1.1, for polyN=7,
    /// a good value would be polySigma=1.5.</param>
    /// <param name="flags">operation flags that can be a combination of OPTFLOW_USE_INITIAL_FLOW and/or OPTFLOW_FARNEBACK_GAUSSIAN</param>
    /// <returns></returns>
    public static FarnebackOpticalFlow Create(
        int numLevels = 5,
        double pyrScale = 0.5,
        bool fastPyramids = false,
        int winSize = 13,
        int numIters = 10,
        int polyN = 5,
        double polySigma = 1.1,
        int flags = 0)
    {
        NativeMethods.HandleException(
            NativeMethods.video_FarnebackOpticalFlow_create(
                numLevels, pyrScale, fastPyramids ? 1 : 0, winSize, numIters, polyN, polySigma, flags, out var smartPtr));
        NativeMethods.HandleException(NativeMethods.video_Ptr_FarnebackOpticalFlow_get(smartPtr, out var rawPtr));
        return new FarnebackOpticalFlow(smartPtr, rawPtr);
    }

    /// <summary>
    /// number of pyramid layers including the initial image
    /// </summary>
    public int NumLevels
    {
        get
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.video_FarnebackOpticalFlow_getNumLevels(Handle, out var ret));
            return ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.video_FarnebackOpticalFlow_setNumLevels(Handle, value));
        }
    }

    /// <summary>
    /// image scale (&lt;1) to build pyramids for each image
    /// </summary>
    public double PyrScale
    {
        get
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.video_FarnebackOpticalFlow_getPyrScale(Handle, out var ret));
            return ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.video_FarnebackOpticalFlow_setPyrScale(Handle, value));
        }
    }

    /// <summary>
    /// Whether to use fast pyramids
    /// </summary>
    public bool FastPyramids
    {
        get
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.video_FarnebackOpticalFlow_getFastPyramids(Handle, out var ret));
            return ret != 0;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.video_FarnebackOpticalFlow_setFastPyramids(Handle, value ? 1 : 0));
        }
    }

    /// <summary>
    /// averaging window size
    /// </summary>
    public int WinSize
    {
        get
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.video_FarnebackOpticalFlow_getWinSize(Handle, out var ret));
            return ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.video_FarnebackOpticalFlow_setWinSize(Handle, value));
        }
    }

    /// <summary>
    /// number of iterations the algorithm does at each pyramid level
    /// </summary>
    public int NumIters
    {
        get
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.video_FarnebackOpticalFlow_getNumIters(Handle, out var ret));
            return ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.video_FarnebackOpticalFlow_setNumIters(Handle, value));
        }
    }

    /// <summary>
    /// size of the pixel neighborhood used to find polynomial expansion in each pixel
    /// </summary>
    public int PolyN
    {
        get
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.video_FarnebackOpticalFlow_getPolyN(Handle, out var ret));
            return ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.video_FarnebackOpticalFlow_setPolyN(Handle, value));
        }
    }

    /// <summary>
    /// standard deviation of the Gaussian that is used to smooth derivatives used as a basis for the polynomial expansion
    /// </summary>
    public double PolySigma
    {
        get
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.video_FarnebackOpticalFlow_getPolySigma(Handle, out var ret));
            return ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.video_FarnebackOpticalFlow_setPolySigma(Handle, value));
        }
    }

    /// <summary>
    /// operation flags
    /// </summary>
    public int Flags
    {
        get
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.video_FarnebackOpticalFlow_getFlags(Handle, out var ret));
            return ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.video_FarnebackOpticalFlow_setFlags(Handle, value));
        }
    }
}
