using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

#pragma warning disable 1591
#pragma warning disable CA1401 // P/Invokes should not be visible
#pragma warning disable CA1720 // Identifiers should not contain type names
#pragma warning disable CA2101 // Specify marshaling for P/Invoke string arguments
#pragma warning disable IDE1006 // Naming style

namespace OpenCvSharp.Internal;

static partial class NativeMethods
{
    #region PCA
    [LibraryImport(DllExtern)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus core_PCA_new1(out IntPtr returnValue);
    [LibraryImport(DllExtern)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus core_PCA_new2(
        IntPtr data, IntPtr mean, int flags, int maxComponents, out IntPtr returnValue);
    [LibraryImport(DllExtern)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus core_PCA_new3(
        IntPtr data, IntPtr mean, int flags, double retainedVariance, out IntPtr returnValue);

    [LibraryImport(DllExtern)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus core_PCA_delete(IntPtr obj);

    [LibraryImport(DllExtern)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus core_PCA_operatorThis(
        IntPtr obj, IntPtr data, IntPtr mean, int flags, int maxComponents);

    [LibraryImport(DllExtern)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus core_PCA_computeVar(
        IntPtr obj, IntPtr data, IntPtr mean, int flags, double retainedVariance);

    [LibraryImport(DllExtern)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus core_PCA_project1(IntPtr obj, IntPtr vec, out IntPtr returnValue);
    [LibraryImport(DllExtern)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus core_PCA_project2(IntPtr obj, IntPtr vec, IntPtr result);

    [LibraryImport(DllExtern)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus core_PCA_backProject1(IntPtr obj, IntPtr vec, out IntPtr returnValue);
    [LibraryImport(DllExtern)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus core_PCA_backProject2(IntPtr obj, IntPtr vec, IntPtr result);

    [LibraryImport(DllExtern)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus core_PCA_eigenvectors(IntPtr obj, out IntPtr returnValue);
    [LibraryImport(DllExtern)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus core_PCA_eigenvalues(IntPtr obj, out IntPtr returnValue);
    [LibraryImport(DllExtern)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus core_PCA_mean(IntPtr obj, out IntPtr returnValue);

    [LibraryImport(DllExtern)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus core_PCA_write(IntPtr obj, IntPtr fs);

    [LibraryImport(DllExtern)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus core_PCA_read(IntPtr obj, IntPtr fn);

    #endregion

    #region RNG

    [LibraryImport(DllExtern)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus core_RNG_fill(ref ulong state, IntPtr mat, int distType, IntPtr a, IntPtr b, int saturateRange);

    [LibraryImport(DllExtern)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus core_RNG_gaussian(ref ulong state, double sigma, out double returnValue);

    #endregion

    #region SVD
    [LibraryImport(DllExtern)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus core_SVD_new1(out IntPtr returnValue);
    [LibraryImport(DllExtern)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus core_SVD_new2(IntPtr src, int flags, out IntPtr returnValue);

    [LibraryImport(DllExtern)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus core_SVD_delete(IntPtr obj);

    [LibraryImport(DllExtern)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus core_SVD_operatorThis(IntPtr obj, IntPtr src, int flags);
    [LibraryImport(DllExtern)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus core_SVD_backSubst(IntPtr obj, IntPtr rhs, IntPtr dst);

    [LibraryImport(DllExtern)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus core_SVD_static_compute1(IntPtr src, IntPtr w, IntPtr u, IntPtr vt, int flags);
    [LibraryImport(DllExtern)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus core_SVD_static_compute2(IntPtr src, IntPtr w, int flags);

    [LibraryImport(DllExtern)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus core_SVD_static_backSubst(IntPtr w, IntPtr u, IntPtr vt, IntPtr rhs, IntPtr dst);

    [LibraryImport(DllExtern)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus core_SVD_static_solveZ(IntPtr src, IntPtr dst);

    [LibraryImport(DllExtern)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus core_SVD_u(IntPtr obj, out IntPtr returnValue);
    [LibraryImport(DllExtern)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus core_SVD_w(IntPtr obj, out IntPtr returnValue);
    [LibraryImport(DllExtern)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus core_SVD_vt(IntPtr obj, out IntPtr returnValue);
    #endregion

    #region LDA

    [LibraryImport(DllExtern)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus core_LDA_new1(int numComponents, out IntPtr returnValue);

    [LibraryImport(DllExtern)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus core_LDA_new2(IntPtr src, IntPtr labels, int numComponents, out IntPtr returnValue);

    [LibraryImport(DllExtern)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus core_LDA_delete(IntPtr obj);

    [LibraryImport(DllExtern)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus core_LDA_save_String(IntPtr obj, [MarshalAs(UnmanagedType.LPStr)] string filename);

    [LibraryImport(DllExtern)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus core_LDA_load_String(IntPtr obj, [MarshalAs(UnmanagedType.LPStr)] string filename);

    [LibraryImport(DllExtern)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus core_LDA_save_FileStorage(IntPtr obj, IntPtr fs);

    [LibraryImport(DllExtern)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus core_LDA_load_FileStorage(IntPtr obj, IntPtr node);

    [LibraryImport(DllExtern)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus core_LDA_compute(IntPtr obj, IntPtr src, IntPtr labels);

    [LibraryImport(DllExtern)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus core_LDA_project(IntPtr obj, IntPtr src, out IntPtr returnValue);

    [LibraryImport(DllExtern)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus core_LDA_reconstruct(IntPtr obj, IntPtr src, out IntPtr returnValue);

    [LibraryImport(DllExtern)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus core_LDA_eigenvectors(IntPtr obj, out IntPtr returnValue);

    [LibraryImport(DllExtern)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus core_LDA_eigenvalues(IntPtr obj, out IntPtr returnValue);

    [LibraryImport(DllExtern)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus core_LDA_subspaceProject(IntPtr w, IntPtr mean, IntPtr src, out IntPtr returnValue);

    [LibraryImport(DllExtern)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus core_LDA_subspaceReconstruct(IntPtr w, IntPtr mean, IntPtr src, out IntPtr returnValue);

    #endregion
}
