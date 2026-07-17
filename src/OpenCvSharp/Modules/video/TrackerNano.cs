using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;
using OpenCvSharp.Internal;

namespace OpenCvSharp;

/// <inheritdoc />
/// <summary>
/// The Nano tracker is a super lightweight dnn-based general object tracking.
/// Nano tracker needs two models: one for feature extraction (backbone) and the another for
/// localization (neckhead).
/// </summary>
public class TrackerNano : Tracker
{
    private TrackerNano(IntPtr smartPtr, IntPtr rawPtr)
        : base(smartPtr, rawPtr, p => NativeMethods.HandleException(NativeMethods.video_Ptr_TrackerNano_delete(p)))
    { }

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="parameters">NanoTrack parameters</param>
    /// <returns></returns>
    public static TrackerNano Create(Params parameters)
    {
        // backbone/neckhead are char* in the native struct, so marshal them for the duration of the
        // call (native copies them into std::string immediately).
        var backbonePtr = Marshal.StringToCoTaskMemAnsi(parameters.Backbone);
        var neckheadPtr = Marshal.StringToCoTaskMemAnsi(parameters.Neckhead);
        try
        {
            var native = parameters.ToNativeStruct(backbonePtr, neckheadPtr);
            unsafe
            {
                NativeMethods.HandleException(
                    NativeMethods.video_TrackerNano_create(&native, out var smartPtr));
                NativeMethods.HandleException(NativeMethods.video_Ptr_TrackerNano_get(smartPtr, out var rawPtr));
                return new TrackerNano(smartPtr, rawPtr);
            }
        }
        finally
        {
            Marshal.FreeCoTaskMem(backbonePtr);
            Marshal.FreeCoTaskMem(neckheadPtr);
        }
    }

#pragma warning disable CA1034
    /// <summary>
    /// NanoTrack Params. A managed-friendly parameter bag; <see cref="ToNativeStruct"/> converts it
    /// into the blittable <see cref="WTrackerNanoParams"/> mirror passed to the native entry point.
    /// </summary>
    [SuppressMessage("Design", "CA1051: Do not declare visible instance fields")]
    [SuppressMessage("Microsoft.Design", "CA1815: Override equals and operator equals on value types")]
    public struct Params
    {
        /// <summary>
        /// Path to the pre-trained backbone model (.onnx)
        /// </summary>
        public string Backbone;

        /// <summary>
        /// Path to the pre-trained neckhead model (.onnx)
        /// </summary>
        public string Neckhead;

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
        internal readonly WTrackerNanoParams ToNativeStruct(IntPtr backbone, IntPtr neckhead) => new()
        {
            Backbone = backbone,
            Neckhead = neckhead,
            Backend = Backend,
            Target = Target,
        };
    }
#pragma warning restore CA1034
}

/// <summary>
/// Blittable mirror of native <c>video_TrackerNano_Params</c> (the string fields are <c>char*</c>).
/// Built from <see cref="TrackerNano.Params"/> for the P/Invoke.
/// </summary>
#pragma warning disable CA1815
[StructLayout(LayoutKind.Sequential)]
[SuppressMessage("Design", "CA1051: Do not declare visible instance fields")]
public struct WTrackerNanoParams
{
#pragma warning disable 1591
    public IntPtr Backbone;
    public IntPtr Neckhead;
    public int Backend;
    public int Target;
#pragma warning restore 1591
}
