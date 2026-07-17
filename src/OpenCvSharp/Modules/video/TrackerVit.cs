using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;
using OpenCvSharp.Internal;

namespace OpenCvSharp;

// ReSharper disable once InconsistentNaming
/// <inheritdoc />
/// <summary>
/// The VIT tracker is a super lightweight dnn-based general object tracking.
/// </summary>
public class TrackerVit : Tracker
{
    private TrackerVit(IntPtr smartPtr, IntPtr rawPtr)
        : base(smartPtr, rawPtr, p => NativeMethods.HandleException(NativeMethods.video_Ptr_TrackerVit_delete(p)))
    { }

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="parameters">vit tracker parameters</param>
    /// <returns></returns>
    public static TrackerVit Create(Params parameters)
    {
        ArgumentNullException.ThrowIfNull(parameters.Net, nameof(parameters.Net));

        // net is a char* in the native struct, so marshal it for the duration of the call
        // (native copies it into a std::string immediately).
        var netPtr = Marshal.StringToCoTaskMemAnsi(parameters.Net);
        try
        {
            var native = parameters.ToNativeStruct(netPtr);
            unsafe
            {
                NativeMethods.HandleException(
                    NativeMethods.video_TrackerVit_create(&native, out var smartPtr));
                NativeMethods.HandleException(NativeMethods.video_Ptr_TrackerVit_get(smartPtr, out var rawPtr));
                return new TrackerVit(smartPtr, rawPtr);
            }
        }
        finally
        {
            Marshal.FreeCoTaskMem(netPtr);
        }
    }

#pragma warning disable CA1034
    /// <summary>
    /// VIT tracker Params. A managed-friendly parameter bag; <see cref="ToNativeStruct"/> converts it
    /// into the blittable <see cref="WTrackerVitParams"/> mirror passed to the native entry point.
    /// </summary>
    [SuppressMessage("Design", "CA1051: Do not declare visible instance fields")]
    [SuppressMessage("Microsoft.Design", "CA1815: Override equals and operator equals on value types")]
    public struct Params
    {
        /// <summary>
        /// Path to the pre-trained DNN model (.onnx)
        /// </summary>
        public string Net;

        /// <summary>
        /// dnn::Backend
        /// </summary>
        public int Backend;

        /// <summary>
        /// dnn::Target
        /// </summary>
        public int Target;

        /// <summary>
        /// mean value for image preprocessing
        /// </summary>
        public Scalar MeanValue;

        /// <summary>
        /// std value for image preprocessing
        /// </summary>
        public Scalar StdValue;

        /// <summary>
        /// threshold for tracking score
        /// </summary>
        public float TrackingScoreThreshold;

        /// <summary>
        /// Builds the blittable native mirror. <paramref name="net"/> must point to a char* that
        /// stays alive for the duration of the native call.
        /// </summary>
        internal readonly WTrackerVitParams ToNativeStruct(IntPtr net) => new()
        {
            Net = net,
            Backend = Backend,
            Target = Target,
            MeanValue = MeanValue,
            StdValue = StdValue,
            TrackingScoreThreshold = TrackingScoreThreshold,
        };
    }
#pragma warning restore CA1034
}

/// <summary>
/// Blittable mirror of native <c>video_TrackerVit_Params</c> (<c>net</c> is a <c>char*</c>).
/// Built from <see cref="TrackerVit.Params"/> for the P/Invoke.
/// </summary>
#pragma warning disable CA1815
[StructLayout(LayoutKind.Sequential)]
[SuppressMessage("Design", "CA1051: Do not declare visible instance fields")]
public struct WTrackerVitParams
{
#pragma warning disable 1591
    public IntPtr Net;
    public int Backend;
    public int Target;
    public Scalar MeanValue;
    public Scalar StdValue;
    public float TrackingScoreThreshold;
#pragma warning restore 1591
}
