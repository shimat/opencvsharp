namespace OpenCvSharp.Internal.Util;

/// <summary>
/// Provides utility methods for native library (P/Invoke) calls.
/// </summary>
public static class PInvokeHelper
{
    /// <summary>
    /// Wraps an exception that occurred during a DLL import or native call in an <see cref="OpenCvSharpException"/> and throws it.
    /// </summary>
    /// <param name="ex">The original exception raised by the native call.</param>
    /// <exception cref="ArgumentNullException"><paramref name="ex"/> is <see langword="null"/>.</exception>
    /// <exception cref="OpenCvSharpException">Always thrown.</exception>
    public static void DllImportError(Exception ex) => throw CreateException(ex);

    /// <summary>
    /// Wraps the specified exception in an <see cref="OpenCvSharpException"/> and returns it.
    /// </summary>
    /// <param name="ex">The original exception raised by the native call.</param>
    /// <returns>An <see cref="OpenCvSharpException"/> that wraps the original exception.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="ex"/> is <see langword="null"/>.</exception>
    public static OpenCvSharpException CreateException(Exception ex)
    {
        if (ex is null) 
            throw new ArgumentNullException(nameof(ex));

        return new OpenCvSharpException(ex.Message, ex);
    }
}
