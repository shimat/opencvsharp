using OpenCvSharp.Internal;

namespace OpenCvSharp.OptFlow;

/// <summary>
/// "Dual TV L1" Optical Flow Algorithm.
/// </summary>
public class DualTVL1OpticalFlow : DenseOpticalFlow
{
    private DualTVL1OpticalFlow(IntPtr smartPtr, IntPtr rawPtr)
        : base(smartPtr, rawPtr, p => NativeMethods.HandleException(NativeMethods.optflow_Ptr_DualTVL1OpticalFlow_delete(p)))
    {
    }

    /// <summary>
    /// Creates instance of cv::optflow::DualTVL1OpticalFlow.
    /// </summary>
    /// <param name="tau">Time step of the numerical scheme.</param>
    /// <param name="lambda">Weight parameter for the data term, attachment parameter.</param>
    /// <param name="theta">Weight parameter for (u - v)^2, tightness parameter.</param>
    /// <param name="nscales">Number of scales used to create the pyramid of images.</param>
    /// <param name="warps">Number of warpings per scale.</param>
    /// <param name="epsilon">Stopping criterion threshold used in the numerical scheme.</param>
    /// <param name="innerIterations">Inner iterations (between outlier filtering) used in the numerical scheme.</param>
    /// <param name="outerIterations">Outer iterations (number of inner loops) used in the numerical scheme.</param>
    /// <param name="scaleStep">Step between scales (&lt;1).</param>
    /// <param name="gamma">Coefficient for additional illumination variation term.</param>
    /// <param name="medianFiltering">Median filter kernel size (1 = no filter) (3 or 5).</param>
    /// <param name="useInitialFlow">Use initial flow.</param>
    /// <returns></returns>
    public static DualTVL1OpticalFlow Create(
        double tau = 0.25,
        double lambda = 0.15,
        double theta = 0.3,
        int nscales = 5,
        int warps = 5,
        double epsilon = 0.01,
        int innerIterations = 30,
        int outerIterations = 10,
        double scaleStep = 0.8,
        double gamma = 0.0,
        int medianFiltering = 5,
        bool useInitialFlow = false)
    {
        NativeMethods.HandleException(
            NativeMethods.optflow_DualTVL1OpticalFlow_create(
                tau, lambda, theta, nscales, warps, epsilon,
                innerIterations, outerIterations, scaleStep, gamma,
                medianFiltering, useInitialFlow ? 1 : 0, out var smartPtr));
        NativeMethods.HandleException(NativeMethods.optflow_Ptr_DualTVL1OpticalFlow_get(smartPtr, out var rawPtr));
        return new DualTVL1OpticalFlow(smartPtr, rawPtr);
    }

    /// <summary>
    /// Wraps an already-created native <c>cv::Ptr&lt;cv::optflow::DualTVL1OpticalFlow&gt;</c>
    /// (e.g. one obtained from <c>cv::optflow::createOptFlow_DualTVL1</c>) as a managed instance.
    /// </summary>
    internal static new DualTVL1OpticalFlow FromPtr(IntPtr smartPtr, IntPtr rawPtr) => new(smartPtr, rawPtr);

    /// <summary>
    /// Time step of the numerical scheme.
    /// </summary>
    public double Tau
    {
        get
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(NativeMethods.optflow_DualTVL1OpticalFlow_getTau(Handle, out var ret));
            return ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(NativeMethods.optflow_DualTVL1OpticalFlow_setTau(Handle, value));
        }
    }

    /// <summary>
    /// Weight parameter for the data term, attachment parameter.
    /// </summary>
    public double Lambda
    {
        get
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(NativeMethods.optflow_DualTVL1OpticalFlow_getLambda(Handle, out var ret));
            return ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(NativeMethods.optflow_DualTVL1OpticalFlow_setLambda(Handle, value));
        }
    }

    /// <summary>
    /// Weight parameter for (u - v)^2, tightness parameter.
    /// </summary>
    public double Theta
    {
        get
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(NativeMethods.optflow_DualTVL1OpticalFlow_getTheta(Handle, out var ret));
            return ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(NativeMethods.optflow_DualTVL1OpticalFlow_setTheta(Handle, value));
        }
    }

    /// <summary>
    /// Coefficient for additional illumination variation term.
    /// </summary>
    public double Gamma
    {
        get
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(NativeMethods.optflow_DualTVL1OpticalFlow_getGamma(Handle, out var ret));
            return ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(NativeMethods.optflow_DualTVL1OpticalFlow_setGamma(Handle, value));
        }
    }

    /// <summary>
    /// Number of scales used to create the pyramid of images.
    /// </summary>
    public int ScalesNumber
    {
        get
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(NativeMethods.optflow_DualTVL1OpticalFlow_getScalesNumber(Handle, out var ret));
            return ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(NativeMethods.optflow_DualTVL1OpticalFlow_setScalesNumber(Handle, value));
        }
    }

    /// <summary>
    /// Number of warpings per scale.
    /// </summary>
    public int WarpingsNumber
    {
        get
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(NativeMethods.optflow_DualTVL1OpticalFlow_getWarpingsNumber(Handle, out var ret));
            return ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(NativeMethods.optflow_DualTVL1OpticalFlow_setWarpingsNumber(Handle, value));
        }
    }

    /// <summary>
    /// Stopping criterion threshold used in the numerical scheme, a trade-off between precision and running time.
    /// </summary>
    public double Epsilon
    {
        get
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(NativeMethods.optflow_DualTVL1OpticalFlow_getEpsilon(Handle, out var ret));
            return ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(NativeMethods.optflow_DualTVL1OpticalFlow_setEpsilon(Handle, value));
        }
    }

    /// <summary>
    /// Inner iterations (between outlier filtering) used in the numerical scheme.
    /// </summary>
    public int InnerIterations
    {
        get
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(NativeMethods.optflow_DualTVL1OpticalFlow_getInnerIterations(Handle, out var ret));
            return ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(NativeMethods.optflow_DualTVL1OpticalFlow_setInnerIterations(Handle, value));
        }
    }

    /// <summary>
    /// Outer iterations (number of inner loops) used in the numerical scheme.
    /// </summary>
    public int OuterIterations
    {
        get
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(NativeMethods.optflow_DualTVL1OpticalFlow_getOuterIterations(Handle, out var ret));
            return ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(NativeMethods.optflow_DualTVL1OpticalFlow_setOuterIterations(Handle, value));
        }
    }

    /// <summary>
    /// Use initial flow.
    /// </summary>
    public bool UseInitialFlow
    {
        get
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(NativeMethods.optflow_DualTVL1OpticalFlow_getUseInitialFlow(Handle, out var ret));
            return ret != 0;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(NativeMethods.optflow_DualTVL1OpticalFlow_setUseInitialFlow(Handle, value ? 1 : 0));
        }
    }

    /// <summary>
    /// Step between scales (&lt;1).
    /// </summary>
    public double ScaleStep
    {
        get
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(NativeMethods.optflow_DualTVL1OpticalFlow_getScaleStep(Handle, out var ret));
            return ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(NativeMethods.optflow_DualTVL1OpticalFlow_setScaleStep(Handle, value));
        }
    }

    /// <summary>
    /// Median filter kernel size (1 = no filter) (3 or 5).
    /// </summary>
    public int MedianFiltering
    {
        get
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(NativeMethods.optflow_DualTVL1OpticalFlow_getMedianFiltering(Handle, out var ret));
            return ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(NativeMethods.optflow_DualTVL1OpticalFlow_setMedianFiltering(Handle, value));
        }
    }
}
