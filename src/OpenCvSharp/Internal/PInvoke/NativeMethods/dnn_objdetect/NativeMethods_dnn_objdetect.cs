using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

#pragma warning disable 1591
#pragma warning disable CA1401
#pragma warning disable IDE1006

namespace OpenCvSharp.Internal;

static partial class NativeMethods
{
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus dnn_objdetect_inferBboxes(
        IntPtr deltaBboxes, IntPtr classScores, IntPtr confidenceScores,
        double threshold, out IntPtr returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus dnn_objdetect_detections_count(IntPtr detections, out int returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus dnn_objdetect_detections_get(
        IntPtr detections, int index,
        out int xmin, out int ymin, out int xmax, out int ymax, out int classIndex,
        out IntPtr label, out double probability);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus dnn_objdetect_detections_delete(IntPtr detections);
}
