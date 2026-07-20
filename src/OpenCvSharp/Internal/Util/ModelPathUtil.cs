namespace OpenCvSharp.Internal.Util;

/// <summary>
/// Helper for model-loading APIs that expose both a file-path overload (marshaled as the ANSI
/// code page on Windows via <c>StringUnmanagedTypeWindows</c>) and an in-memory buffer overload.
/// </summary>
internal static class ModelPathUtil
{
    /// <summary>
    /// True if the given path cannot be trusted to round-trip through the Windows ANSI code page
    /// and should instead be read into memory and passed through the buffer overload.
    /// Only returns true when the file actually exists, so a missing-file path still reaches the
    /// native call and surfaces the usual <see cref="OpenCVException"/> instead of a .NET IO exception.
    /// </summary>
    /// <param name="path"></param>
    /// <returns></returns>
    public static bool RequiresBufferFallback(string path) =>
        OperatingSystem.IsWindows() && !System.Text.Ascii.IsValid(path) && File.Exists(path);
}
