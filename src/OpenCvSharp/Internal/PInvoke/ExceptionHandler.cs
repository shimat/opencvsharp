namespace OpenCvSharp.Internal;

/// <summary>
/// Surfaces the last native OpenCV exception as a managed exception.
/// </summary>
/// <remarks>
/// Details are captured natively, on the calling thread, directly from the thrown C++
/// exception (see the native cvTry / LastNativeException). No managed error callback is
/// installed in the default path, so this is NativeAOT / trimming friendly.
/// </remarks>
public static class ExceptionHandler
{
    /// <summary>
    /// Throws an <see cref="OpenCVException"/> built from the per-thread native exception
    /// record. Call only when an export reported <see cref="ExceptionStatus.Occurred"/>.
    /// </summary>
    public static void ThrowPossibleException()
    {
        using var func = new StdString();
        using var file = new StdString();
        using var message = new StdString();

        NativeMethods.core_getLastException(out var code, out var line, func.CvPtr, file.CvPtr, message.CvPtr);

        throw new OpenCVException((ErrorCode)code, func.ToString(), message.ToString(), file.ToString(), line);
    }
}
