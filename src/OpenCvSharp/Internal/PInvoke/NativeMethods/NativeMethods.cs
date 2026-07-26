using System.Runtime.InteropServices;

[assembly: DefaultDllImportSearchPaths(DllImportSearchPath.SafeDirectories)]

// ReSharper disable InconsistentNaming
#pragma warning disable 1591

namespace OpenCvSharp.Internal;

/// <summary>
/// P/Invoke methods for the OpenCV C++ interface.
/// </summary>
public static partial class NativeMethods
{
    public const string DllExtern = "OpenCvSharpExtern";

    private const UnmanagedType StringUnmanagedTypeWindows = UnmanagedType.LPStr;

    private const UnmanagedType StringUnmanagedTypeNotWindows =
        UnmanagedType.LPUTF8Str;

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
    /// Returns whether the OS is Windows or not
    /// </summary>
    /// <returns></returns>
    public static bool IsWindows()
    {
        return OperatingSystem.IsWindows();
    }

    /// <summary>
    /// Returns whether the OS is *nix or not
    /// </summary>
    /// <returns></returns>
    public static bool IsUnix()
    {
        return OperatingSystem.IsLinux() ||
               OperatingSystem.IsMacOS() ||
               OperatingSystem.IsFreeBSD();
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

}
