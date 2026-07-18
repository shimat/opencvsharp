using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;
using OpenCvSharp.Internal;

namespace OpenCvSharp;

// ReSharper disable once InconsistentNaming
/// <inheritdoc />
/// <summary>
/// DaSiamRPN tracker: a super lightweight dnn-based general object tracking.
/// </summary>
public class TrackerDaSiamRPN : Tracker
{
    private TrackerDaSiamRPN(IntPtr smartPtr, IntPtr rawPtr)
        : base(smartPtr, rawPtr, p => NativeMethods.HandleException(NativeMethods.video_Ptr_TrackerDaSiamRPN_delete(p)))
    { }

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="parameters">DaSiamRPN parameters</param>
    /// <returns></returns>
    public static TrackerDaSiamRPN Create(Params parameters)
    {
        ArgumentNullException.ThrowIfNull(parameters.Model, nameof(parameters.Model));
        ArgumentNullException.ThrowIfNull(parameters.KernelCls1, nameof(parameters.KernelCls1));
        ArgumentNullException.ThrowIfNull(parameters.KernelR1, nameof(parameters.KernelR1));

        // model/kernel_cls1/kernel_r1 are char* in the native struct, so marshal them for the
        // duration of the call (native copies them into std::string immediately).
        var modelPtr = Marshal.StringToCoTaskMemAnsi(parameters.Model);
        var kernelCls1Ptr = Marshal.StringToCoTaskMemAnsi(parameters.KernelCls1);
        var kernelR1Ptr = Marshal.StringToCoTaskMemAnsi(parameters.KernelR1);
        try
        {
            var native = parameters.ToNativeStruct(modelPtr, kernelCls1Ptr, kernelR1Ptr);
            unsafe
            {
                NativeMethods.HandleException(
                    NativeMethods.video_TrackerDaSiamRPN_create(&native, out var smartPtr));
                NativeMethods.HandleException(NativeMethods.video_Ptr_TrackerDaSiamRPN_get(smartPtr, out var rawPtr));
                return new TrackerDaSiamRPN(smartPtr, rawPtr);
            }
        }
        finally
        {
            Marshal.FreeCoTaskMem(modelPtr);
            Marshal.FreeCoTaskMem(kernelCls1Ptr);
            Marshal.FreeCoTaskMem(kernelR1Ptr);
        }
    }

#pragma warning disable CA1034
    /// <summary>
    /// DaSiamRPN Params. A managed-friendly parameter bag; <see cref="ToNativeStruct"/> converts it
    /// into the blittable <see cref="WTrackerDaSiamRPNParams"/> mirror passed to the native entry point.
    /// </summary>
    [SuppressMessage("Design", "CA1051: Do not declare visible instance fields")]
    [SuppressMessage("Microsoft.Design", "CA1815: Override equals and operator equals on value types")]
    public struct Params
    {
        /// <summary>
        /// Path to the pre-trained SiamRPN model (.onnx)
        /// </summary>
        public string Model;

        /// <summary>
        /// Path to the pre-trained CLS model (.onnx)
        /// </summary>
        public string KernelCls1;

        /// <summary>
        /// Path to the pre-trained R1 model (.onnx)
        /// </summary>
        public string KernelR1;

        /// <summary>
        /// dnn::Backend
        /// </summary>
        public int Backend;

        /// <summary>
        /// dnn::Target
        /// </summary>
        public int Target;

        /// <summary>
        /// Builds the blittable native mirror. Each string pointer must point to a char* that stays
        /// alive for the duration of the native call.
        /// </summary>
        internal readonly WTrackerDaSiamRPNParams ToNativeStruct(IntPtr model, IntPtr kernelCls1, IntPtr kernelR1) => new()
        {
            Model = model,
            KernelCls1 = kernelCls1,
            KernelR1 = kernelR1,
            Backend = Backend,
            Target = Target,
        };
    }
#pragma warning restore CA1034
}

/// <summary>
/// Blittable mirror of native <c>video_TrackerDaSiamRPN_Params</c> (the string fields are
/// <c>char*</c>). Built from <see cref="TrackerDaSiamRPN.Params"/> for the P/Invoke.
/// </summary>
#pragma warning disable CA1815
[StructLayout(LayoutKind.Sequential)]
[SuppressMessage("Design", "CA1051: Do not declare visible instance fields")]
public struct WTrackerDaSiamRPNParams
{
#pragma warning disable 1591
    public IntPtr Model;
    public IntPtr KernelCls1;
    public IntPtr KernelR1;
    public int Backend;
    public int Target;
#pragma warning restore 1591
}
