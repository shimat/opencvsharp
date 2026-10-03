using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace OpenCvSharp.Internal;

static partial class NativeMethods
{
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus ptcloud_triangleRasterize(
        in InputArrayProxy vertices, in InputArrayProxy indices, in InputArrayProxy colors,
        in InputOutputArrayProxy colorBuf, in InputOutputArrayProxy depthBuf,
        in InputArrayProxy world2cam, double fovY, double zNear, double zFar,
        int shading, int culling, int glCompatible);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus ptcloud_triangleRasterizeDepth(
        in InputArrayProxy vertices, in InputArrayProxy indices,
        in InputOutputArrayProxy depthBuf, in InputArrayProxy world2cam,
        double fovY, double zNear, double zFar, int shading, int culling, int glCompatible);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus ptcloud_triangleRasterizeColor(
        in InputArrayProxy vertices, in InputArrayProxy indices, in InputArrayProxy colors,
        in InputOutputArrayProxy colorBuf, in InputArrayProxy world2cam,
        double fovY, double zNear, double zFar, int shading, int culling, int glCompatible);
}
