using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

#pragma warning disable 1591
#pragma warning disable CA1401 // P/Invokes should not be visible
#pragma warning disable CA1720 // Identifiers should not contain type names
#pragma warning disable CA2101 // Specify marshaling for P/Invoke string arguments
#pragma warning disable IDE1006 // Naming style

namespace OpenCvSharp.Internal;

// ReSharper disable InconsistentNaming
static partial class NativeMethods
{
    #region Facemark

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus face_Facemark_loadModel(
        OpenCvSafeHandle obj, [MarshalAs(UnmanagedType.LPStr)] string model);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus face_Facemark_fit(
        OpenCvSafeHandle obj, IntPtr image, IntPtr faces, IntPtr landmarks, out int returnValue);

    #endregion

    #region FacemarkLBF

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus face_FacemarkLBF_create(IntPtr @params, out IntPtr returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus face_Ptr_FacemarkLBF_get(IntPtr obj, out IntPtr returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus face_Ptr_FacemarkLBF_delete(IntPtr obj);

    #region Params

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus face_FacemarkLBF_Params_new(out IntPtr returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus face_FacemarkLBF_Params_delete(IntPtr obj);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus face_FacemarkLBF_Params_getAll(
        IntPtr obj, out FacemarkLBFParamsData data, IntPtr cascadeFace, IntPtr modelFilename,
        IntPtr featsM, IntPtr radiusM, IntPtr pupils0, IntPtr pupils1);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus face_FacemarkLBF_Params_setAll(
        IntPtr obj, FacemarkLBFParamsData data, [MarshalAs(UnmanagedType.LPStr)] string cascadeFace,
        [MarshalAs(UnmanagedType.LPStr)] string modelFilename, IntPtr featsM, IntPtr radiusM, IntPtr pupils0, IntPtr pupils1);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus face_FacemarkLBF_Params_read(IntPtr obj, IntPtr fn);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus face_FacemarkLBF_Params_write(IntPtr obj, IntPtr fs);

    #endregion

    #endregion

    #region FacemarkAAM

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus face_FacemarkAAM_create(IntPtr @params, out IntPtr returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus face_Ptr_FacemarkAAM_get(IntPtr obj, out IntPtr returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus face_Ptr_FacemarkAAM_delete(IntPtr obj);

    #region Params

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus face_FacemarkAAM_Params_new(out IntPtr returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus face_FacemarkAAM_Params_delete(IntPtr obj);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus face_FacemarkAAM_Params_getAll(
        IntPtr obj, out FacemarkAAMParamsData data, IntPtr modelFilename, IntPtr scales);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus face_FacemarkAAM_Params_setAll(
        IntPtr obj, FacemarkAAMParamsData data, [MarshalAs(UnmanagedType.LPStr)] string modelFilename, IntPtr scales);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus face_FacemarkAAM_Params_read(IntPtr obj, IntPtr fn);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus face_FacemarkAAM_Params_write(IntPtr obj, IntPtr fs);

    #endregion

    #endregion
}
