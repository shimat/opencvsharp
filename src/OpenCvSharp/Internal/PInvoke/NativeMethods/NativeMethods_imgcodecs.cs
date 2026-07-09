using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

#pragma warning disable 1591
#pragma warning disable CA2101 // Specify marshaling for P/Invoke string arguments

namespace OpenCvSharp.Internal;

static partial class NativeMethods
{
    // imread (UTF-8 everywhere; the native side converts to a wide path on Windows so non-ANSI names work)

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus imgcodecs_imread(
        [MarshalAs(UnmanagedType.LPUTF8Str)] string fileName, int flags, out IntPtr returnValue);

    // imreadmulti (UTF-8 everywhere; native reads via a wide path on Windows)

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus imgcodecs_imreadmulti(
        [MarshalAs(UnmanagedType.LPUTF8Str)] string fileName, IntPtr mats, int flags, out int returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus imgcodecs_imreadmulti_range(
        [MarshalAs(UnmanagedType.LPUTF8Str)] string fileName, IntPtr mats, int start, int count, int flags, out int returnValue);

    // imcount (UTF-8 everywhere; native reads via a wide path on Windows)

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus imgcodecs_imcount(
        [MarshalAs(UnmanagedType.LPUTF8Str)] string fileName, int flags, out IntPtr returnValue);

    // imreadWithMetadata / imwriteWithMetadata / imdecodeWithMetadata / imencodeWithMetadata

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus imgcodecs_imreadWithMetadata(
        [MarshalAs(UnmanagedType.LPUTF8Str)] string fileName, IntPtr metadataTypes, IntPtr metadata, int flags, out IntPtr returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus imgcodecs_imwriteWithMetadata(
        [MarshalAs(UnmanagedType.LPUTF8Str)] string fileName, IntPtr img,
        [In] int[] metadataTypes, int metadataTypesLength, IntPtr metadata,
        [In] int[] @params, int paramsLength, out int returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus imgcodecs_imdecodeWithMetadata(
        in InputArrayProxy buf, IntPtr metadataTypes, IntPtr metadata, int flags, out IntPtr returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus imgcodecs_imencodeWithMetadata(
        [MarshalAs(UnmanagedType.LPStr)] string ext, in InputArrayProxy img,
        [In] int[] metadataTypes, int metadataTypesLength, IntPtr metadata, IntPtr buf,
        [In] int[] @params, int paramsLength, out int returnValue);

    // imdecodemulti / imencodemulti

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus imgcodecs_imdecodemulti(
        in InputArrayProxy buf, int flags, IntPtr mats, Range range, out int returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus imgcodecs_imencodemulti(
        [MarshalAs(UnmanagedType.LPStr)] string ext, IntPtr imgs, IntPtr buf, [In] int[] @params, int paramsLength, out int returnValue);

    // imwrite (UTF-8 everywhere; the native side converts to a wide path on Windows so non-ANSI names work)

    [LibraryImport(DllExtern, EntryPoint = "imgcodecs_imwrite"), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    private static partial ExceptionStatus imgcodecs_imwrite_utf8(
        [MarshalAs(UnmanagedType.LPUTF8Str)] string fileName, IntPtr img, [In] int[] @params, int paramsLength, out int returnValue);

    public static ExceptionStatus imgcodecs_imwrite(string fileName, IntPtr img, int[] @params, int paramsLength, out int returnValue)
    {
        if (IsWasm()) {
            returnValue = default(int);
            return ExceptionStatus.Occurred;
        }

        return imgcodecs_imwrite_utf8(fileName, img, @params, paramsLength, out returnValue);
    }

    // imwrite_multi (UTF-8 everywhere; native writes via a wide path on Windows)

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus imgcodecs_imwrite_multi(
        [MarshalAs(UnmanagedType.LPUTF8Str)] string fileName, IntPtr img, [In] int[] @params, int paramsLength, out int returnValue);

    // 

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus imgcodecs_imdecode_Mat(
        IntPtr buf, int flags, out IntPtr returnValue);
        
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static unsafe partial ExceptionStatus imgcodecs_imdecode_vector(
        byte* buf, int bufLength, int flags, out IntPtr returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus imgcodecs_imdecode_InputArray(
        in InputArrayProxy buf, int flags, out IntPtr returnValue);

    // Do not consider that "ext" may not be ASCII characters
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus imgcodecs_imencode_vector(
        [MarshalAs(UnmanagedType.LPStr)] string ext, in InputArrayProxy img, IntPtr buf, [In] int[] @params, int paramsLength, out int returnValue);

    // Animation

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus imgcodecs_Animation_new(int loopCount, Scalar bgColor, out IntPtr returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus imgcodecs_Animation_delete(IntPtr obj);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus imgcodecs_Animation_get_loop_count(IntPtr obj, out int returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus imgcodecs_Animation_set_loop_count(IntPtr obj, int value);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus imgcodecs_Animation_get_bgcolor(IntPtr obj, out Scalar returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus imgcodecs_Animation_set_bgcolor(IntPtr obj, Scalar value);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus imgcodecs_Animation_get_durations(IntPtr obj, IntPtr outVec);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus imgcodecs_Animation_set_durations(IntPtr obj, [In] int[] data, int length);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus imgcodecs_Animation_get_frames(IntPtr obj, IntPtr outVec);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus imgcodecs_Animation_set_frames(IntPtr obj, IntPtr frames);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus imgcodecs_Animation_get_still_image(IntPtr obj, out IntPtr returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus imgcodecs_Animation_set_still_image(IntPtr obj, IntPtr image);

    // imreadanimation / imdecodeanimation / imwriteanimation / imencodeanimation

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus imgcodecs_imreadanimation(
        [MarshalAs(UnmanagedType.LPUTF8Str)] string fileName, IntPtr animation, int start, int count, out int returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus imgcodecs_imdecodeanimation(
        in InputArrayProxy buf, IntPtr animation, int start, int count, out int returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus imgcodecs_imwriteanimation(
        [MarshalAs(UnmanagedType.LPUTF8Str)] string fileName, IntPtr animation, [In] int[] @params, int paramsLength, out int returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus imgcodecs_imencodeanimation(
        [MarshalAs(UnmanagedType.LPStr)] string ext, IntPtr animation, IntPtr buf, [In] int[] @params, int paramsLength, out int returnValue);

    // ImageCollection

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus imgcodecs_ImageCollection_new1(out IntPtr returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus imgcodecs_ImageCollection_new2(
        [MarshalAs(UnmanagedType.LPUTF8Str)] string fileName, int flags, out IntPtr returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus imgcodecs_ImageCollection_delete(IntPtr obj);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus imgcodecs_ImageCollection_init(
        IntPtr obj, [MarshalAs(UnmanagedType.LPUTF8Str)] string fileName, int flags);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus imgcodecs_ImageCollection_size(IntPtr obj, out IntPtr returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus imgcodecs_ImageCollection_at(IntPtr obj, int index, out IntPtr returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus imgcodecs_ImageCollection_releaseCache(IntPtr obj, int index);

    // haveImageReader (UTF-8 everywhere; native probes via a wide path on Windows)

    [LibraryImport(DllExtern, EntryPoint = "imgcodecs_haveImageReader"), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    private static partial ExceptionStatus imgcodecs_haveImageReader_utf8(
        [MarshalAs(UnmanagedType.LPUTF8Str)] string fileName, out int returnValue);

    public static ExceptionStatus imgcodecs_haveImageReader(string fileName, out int returnValue)
    {
        if (IsWasm()) {
            returnValue = default(int);
            return ExceptionStatus.Occurred;
        }

        return imgcodecs_haveImageReader_utf8(fileName, out returnValue);
    }
        
    // haveImageWriter

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus imgcodecs_haveImageWriter(
        [MarshalAs(UnmanagedType.LPStr)] string fileName, out int returnValue);
}
