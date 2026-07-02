using System.Diagnostics;
using System.Runtime.InteropServices;
using OpenCvSharp.Internal.Util;

// TODO
#pragma warning disable CA5393
[assembly: DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]

// ReSharper disable InconsistentNaming
#pragma warning disable 1591
#pragma warning disable CA1805 // Do not initialize unnecessarily.

namespace OpenCvSharp.Internal;

/// <summary>
/// P/Invoke methods of OpenCV 2.x C++ interface
/// </summary>
public static partial class NativeMethods
{
    public const string DllExtern = "OpenCvSharpExtern";

    //private const UnmanagedType StringUnmanagedType = UnmanagedType.LPStr;

    private const UnmanagedType StringUnmanagedTypeWindows = UnmanagedType.LPStr;

    private const UnmanagedType StringUnmanagedTypeNotWindows =
        UnmanagedType.LPUTF8Str;

    /// <summary>
    /// Is tried P/Invoke once
    /// </summary>
    private static bool tried;

    /// <summary>
    /// Static constructor
    /// </summary>
    static NativeMethods()
    {
        LoadLibraries();
    }

    public static void HandleException(ExceptionStatus status)
    {
        // The native wrapper caught an exception and reported it through the status
        // return value (on every platform). Surface the recorded details as a managed exception.
        if (status == ExceptionStatus.Occurred)
        {
            ExceptionHandler.ThrowPossibleException();
        }
    }

    /// <summary>
    /// Triggers native library resolution and installs the default error handler.
    /// </summary>
    public static void LoadLibraries()
    {
        if (IsWasm())
        {
            return;
        }

        // On both Windows and *nix, the native library is resolved by the .NET runtime's
        // default probing (the runtimes/{rid}/native/ layout produced by the
        // OpenCvSharp5.runtime.* packages). The P/Invoke below triggers the load and installs
        // the default error handler.
        InstallDefaultErrorHandler();
    }

    /// <summary>
    /// Installs the default native (managed-free) OpenCV error handler. It only mutes
    /// OpenCV's stderr dump; error details are captured natively and surfaced as a managed
    /// exception via <see cref="HandleException"/> on each call's returned status.
    /// Use <see cref="OpenCvSharp.Cv2.SetErrorHandler"/> to override it.
    /// </summary>
    private static void InstallDefaultErrorHandler()
    {
        HandleException(core_setSilentErrorHandler());
    }

    /// <summary>
    /// Checks whether PInvoke functions can be called and throws a descriptive exception if not.
    /// This method is not called automatically. Call it explicitly for pre-flight validation
    /// after setting up any custom native library loading (e.g. NativeLibrary.SetDllImportResolver).
    /// </summary>
    public static void TryPInvoke()
    {
#pragma warning disable CA1031
        if (tried)
            return;
        tried = true;

        try
        {
            var ret = core_Mat_sizeof();
            GC.KeepAlive(ret);
        }
        catch (DllNotFoundException e)
        {
            var exception = new OpenCvSharpException(e.Message, e);
            try{Console.WriteLine(exception.Message); }
            // ReSharper disable once EmptyGeneralCatchClause
            catch { }
            try{Debug.WriteLine(exception.Message); }
            // ReSharper disable once EmptyGeneralCatchClause
            catch { }
            throw exception;
        }
        catch (BadImageFormatException e)
        {
            var exception = new OpenCvSharpException(e.Message, e);
            try { Console.WriteLine(exception.Message); }
            // ReSharper disable once EmptyGeneralCatchClause
            catch { }
            try { Debug.WriteLine(exception.Message); }
            // ReSharper disable once EmptyGeneralCatchClause
            catch { }
            throw exception;
        }
        catch (Exception e)
        {
            var ex = e.InnerException ?? e;
            try{ Console.WriteLine(ex.Message); }
            // ReSharper disable once EmptyGeneralCatchClause
            catch { }
            try { Debug.WriteLine(ex.Message); }
            // ReSharper disable once EmptyGeneralCatchClause
            catch { }
            throw;
        }
#pragma warning restore CA1031
    }

    /// <summary>
    /// Returns whether the OS is Windows or not
    /// </summary>
    /// <returns></returns>
    public static bool IsWindows()
    {
        return RuntimeInformation.IsOSPlatform(OSPlatform.Windows);
    }

    /// <summary>
    /// Returns whether the OS is *nix or not
    /// </summary>
    /// <returns></returns>
    public static bool IsUnix()
    {
        return RuntimeInformation.IsOSPlatform(OSPlatform.Linux) ||
               RuntimeInformation.IsOSPlatform(OSPlatform.OSX) ||
               RuntimeInformation.IsOSPlatform(OSPlatform.FreeBSD);
    }

    /// <summary>
    /// Returns whether the runtime is Mono or not
    /// </summary>
    /// <returns></returns>
    public static bool IsMono()
    {
        return (Type.GetType("Mono.Runtime") is not null);
    }

    /// <summary>
    /// Returns whether the architecture is Wasm or not
    /// </summary>
    /// <returns></returns>
    public static bool IsWasm()
    {
        return RuntimeInformation.OSArchitecture == Architecture.Wasm;
    }

    /// <summary>
    /// Custom error handler to ignore all OpenCV errors
    /// </summary>
    // ReSharper disable UnusedParameter.Local
    public static readonly CvErrorCallback ErrorHandlerIgnorance =
        (status, funcName, errMsg, fileName, line, userData) => 0;
    // ReSharper restore UnusedParameter.Local

#pragma warning disable CA2211
    /// <summary>
    /// Default error handler
    /// </summary>
    public static CvErrorCallback? ErrorHandlerDefault = null;
#pragma warning restore CA2211
}
