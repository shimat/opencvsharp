using System.Diagnostics.Contracts;
using System.Runtime.InteropServices;
using OpenCvSharp.Dnn;

#pragma warning disable 1591
#pragma warning disable CA1401 // P/Invokes should not be visible
#pragma warning disable CA2101 // Specify marshalling for P-Invoke string arguments (code analysis)
#pragma warning disable IDE1006 // Naming style

namespace OpenCvSharp.Internal;

public static partial class NativeMethods
{
    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    internal static extern IntPtr cveFaceDetectorYNCreate(
        IntPtr model,
        IntPtr config,
        ref Size inputSize,
        float scoreThreshold,
        float nmsThreshold,
        int topK,
        Backend backendId,
        Target targetId,
        ref IntPtr sharedPtr
    );

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    internal static extern int cveFaceDetectorYNDetect(IntPtr faceDetector, IntPtr image, IntPtr faces);

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    internal static extern void cveFaceDetectorYNRelease(ref IntPtr faceDetector);
}
