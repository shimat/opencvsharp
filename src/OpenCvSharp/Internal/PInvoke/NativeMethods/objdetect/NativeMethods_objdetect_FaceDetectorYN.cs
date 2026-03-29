using System.Runtime.InteropServices;

#pragma warning disable 1591
#pragma warning disable CA1401 // P/Invokes should not be visible
#pragma warning disable IDE1006 // Naming style
// ReSharper disable InconsistentNaming

namespace OpenCvSharp.Internal;

static partial class NativeMethods
{
    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, BestFitMapping = false, ThrowOnUnmappableChar = true, ExactSpelling = true)]
    public static extern ExceptionStatus objdetect_FaceDetectorYN_create(
        IntPtr model,
        IntPtr config,
        ref Size inputSize,
        float scoreThreshold,
        float nmsThreshold,
        int topK,
        int backendId,
        int targetId,
        out IntPtr returnValue);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, BestFitMapping = false, ThrowOnUnmappableChar = true, ExactSpelling = true)]
    public static extern ExceptionStatus objdetect_Ptr_FaceDetectorYN_delete(IntPtr ptr);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, BestFitMapping = false, ThrowOnUnmappableChar = true, ExactSpelling = true)]
    public static extern ExceptionStatus objdetect_Ptr_FaceDetectorYN_get(IntPtr ptr, out IntPtr returnValue);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, BestFitMapping = false, ThrowOnUnmappableChar = true, ExactSpelling = true)]
    public static extern ExceptionStatus objdetect_FaceDetectorYN_detect(
        IntPtr obj, IntPtr image, IntPtr faces, out int returnValue);
}
