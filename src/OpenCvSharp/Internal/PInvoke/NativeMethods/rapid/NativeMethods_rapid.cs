using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

#pragma warning disable 1591
#pragma warning disable CA1401
#pragma warning disable IDE1006

namespace OpenCvSharp.Internal;

static partial class NativeMethods
{
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus rapid_track(
        IntPtr image, int num, int len, IntPtr vertices, IntPtr triangles,
        IntPtr cameraMatrix, IntPtr rotation, IntPtr translation,
        out float matchRatio, out double rmsd);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus rapid_drawWireframe(
        IntPtr image, IntPtr imagePoints, IntPtr triangles,
        Scalar color, int lineType, int cullBackface);
}
