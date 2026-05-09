#if ENABLED_CUDA
using System.Runtime.InteropServices;
using OpenCvSharp.Internal;

namespace OpenCvSharp.Cuda;

public class BackgroundSubtractorFGD : BackgroundSubtractor
{
    protected BackgroundSubtractorFGD(IntPtr smartPtr, IntPtr rawPtr)
         : base(smartPtr, rawPtr, p=> NativeMethods.HandleException(NativeMethods.cuda_BackgroundSubtractorFGD_delete(p)))
    {
    }

    /// <summary>
    /// Creates an FGD Background Subtractor using default parameters.
    /// </summary>
    /// <returns></returns>
    public static BackgroundSubtractorFGD Create()
    {
        NativeMethods.HandleException(
            NativeMethods.cuda_createBackgroundSubtractorFGD(out var smartPtr));

        NativeMethods.HandleException(NativeMethods.cuda_BackgroundSubtractorFGD_get(smartPtr, out IntPtr rawPtr));

        return new BackgroundSubtractorFGD(smartPtr, rawPtr);
    }

    /// <summary>
    /// Creates an FGD Background Subtractor using custom parameters.
    /// </summary>
    /// <param name="params"></param>
    /// <returns></returns>
    public static BackgroundSubtractorFGD Create(FGDParams? @params = null)
    {
        IntPtr smartPtr;
        if (@params.HasValue)
        {
            NativeMethods.HandleException(
                NativeMethods.cuda_createBackgroundSubtractorFGD_withParams(@params.Value, out smartPtr));
        }
        else
        {
            // Use your existing cuda_createBackgroundSubtractorFGD (no params)
            NativeMethods.HandleException(
                NativeMethods.cuda_createBackgroundSubtractorFGD(out smartPtr));
        }

        NativeMethods.HandleException(NativeMethods.cuda_BackgroundSubtractorFGD_get(smartPtr, out IntPtr rawPtr));
        return new BackgroundSubtractorFGD(smartPtr, rawPtr);
    }

    /// <summary>
    /// Updates the background model and computes the foreground mask, with CUDA Stream support.
    /// </summary>
    public virtual void Apply(OpenCvSharp.Cuda.InputArray image, OpenCvSharp.Cuda.OutputArray fgmask, double learningRate = -1)
    {
        if (image is null) 
            throw new ArgumentNullException(nameof(image));
        if (fgmask is null) 
            throw new ArgumentNullException(nameof(fgmask));

        image.ThrowIfDisposed();
        fgmask.ThrowIfNotReady();
        ThrowIfDisposed();

        NativeMethods.HandleException(
            NativeMethods.cuda_BackgroundSubtractorFGD_apply(
                RawPtr, image.CvPtr, fgmask.CvPtr, learningRate));

        fgmask.Fix();
        GC.KeepAlive(this);
        GC.KeepAlive(image);
    }

    /// <summary>
    /// Returns the foreground regions found by the algorithm.
    /// </summary>
    /// <returns>An array of CPU Mat objects containing the foreground regions.</returns>
    public Mat[] GetForegroundRegions()
    {
        ThrowIfDisposed();

        NativeMethods.HandleException(
            NativeMethods.cuda_BackgroundSubtractorFGD_getForegroundRegions(
                RawPtr, out IntPtr outMatsPtr, out int outCount));

        GC.KeepAlive(this);

        if (outCount == 0 || outMatsPtr == IntPtr.Zero)
        {
            return Array.Empty<Mat>();
        }

        // 1. Read the array of IntPtrs (which point to cv::Mat)
        IntPtr[] matPtrs = new IntPtr[outCount];
        Marshal.Copy(outMatsPtr, matPtrs, 0, outCount);

        // 2. Wrap each IntPtr into an OpenCvSharp Mat object
        Mat[] result = new Mat[outCount];
        for (int i = 0; i < outCount; i++)
        {
            // OpenCvSharp will take ownership and automatically call cv::Mat destructor when disposed
            result[i] = new Mat(matPtrs[i]);
        }

        // 3. Free the temporary pointer array in C++
        NativeMethods.HandleException(
            NativeMethods.cuda_FreeMatPointerArray(outMatsPtr));

        return result;
    }
}
#endif
