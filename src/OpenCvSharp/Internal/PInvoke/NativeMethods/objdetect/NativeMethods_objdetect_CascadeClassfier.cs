using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

#pragma warning disable 1591
#pragma warning disable CA1401 // P/Invokes should not be visible
#pragma warning disable CA2101 // Specify marshaling for P/Invoke string arguments
#pragma warning disable IDE1006 // Naming style
// ReSharper disable InconsistentNaming

namespace OpenCvSharp.Internal;

static partial class NativeMethods
{
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus objdetect_CascadeClassifier_read(IntPtr obj, IntPtr fn, out int returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus objdetect_CascadeClassifier_new(out IntPtr returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus objdetect_CascadeClassifier_newFromFile(
        [MarshalAs(UnmanagedType.LPStr)] string fileName, out IntPtr returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus objdetect_CascadeClassifier_delete(IntPtr obj);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus objdetect_CascadeClassifier_empty(IntPtr obj, out int returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus objdetect_CascadeClassifier_load(
        IntPtr obj, [MarshalAs(UnmanagedType.LPStr)] string fileName, out int returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus objdetect_CascadeClassifier_detectMultiScale1(
        IntPtr obj, IntPtr image, IntPtr objects,
        double scaleFactor, int minNeighbors, int flags, Size minSize, Size maxSize);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus objdetect_CascadeClassifier_detectMultiScale2(
        IntPtr obj, IntPtr image, IntPtr objects,
        IntPtr rejectLevels, IntPtr levelWeights,
        double scaleFactor, int minNeighbors, int flags,
        Size minSize, Size maxSize, int outputRejectLevels);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus objdetect_CascadeClassifier_isOldFormatCascade(IntPtr obj, out int returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus objdetect_CascadeClassifier_getOriginalWindowSize(IntPtr obj, out Size returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus objdetect_CascadeClassifier_getFeatureType(IntPtr obj, out int returnValue);
}
