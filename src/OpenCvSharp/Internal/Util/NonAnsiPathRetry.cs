namespace OpenCvSharp.Internal.Util;

/// <summary>
/// Helpers for retrying a native narrow-string file API call whose path could not be represented in the
/// process ANSI code page on Windows (see e.g. imgcodecs_imcount's / videoio's acpOk contract).
/// </summary>
internal static class NonAnsiPathRetry
{
    /// <summary>
    /// Copies 'filename' to an ASCII-safe temp path (managed file I/O handles arbitrary Unicode
    /// source paths natively, unlike OpenCV's narrow-string file APIs on Windows) and invokes
    /// 'action' with that path; the temp file is deleted afterward. Used to retry a read-side native
    /// call that reported it could not open the original path directly (Windows non-ANSI paths only).
    /// </summary>
    public static T ViaTempCopy<T>(string filename, T notFoundResult, Func<string, T> action)
    {
        if (!File.Exists(filename))
            return notFoundResult;

        var tempPath = Path.GetTempFileName();
        try
        {
            File.Copy(filename, tempPath, overwrite: true);
            return action(tempPath);
        }
        finally
        {
            File.Delete(tempPath);
        }
    }

    /// <summary>
    /// Invokes 'action' with an ASCII-safe temp path for it to write to, then moves that temp file to
    /// 'filename' (managed file I/O handles arbitrary Unicode destination paths natively, unlike
    /// OpenCV's narrow-string file APIs on Windows) if 'action' reports success. The temp file is
    /// deleted if 'action' reports failure or throws. Used to retry a write-side native call that
    /// reported it could not open the original path directly (Windows non-ANSI paths only).
    /// </summary>
    /// <remarks>
    /// Unlike the read side, the temp path here keeps 'filename'-s extension: encoder-selection-by-path
    /// APIs such as cv::imwrite and cv::VideoWriter pick the output codec from the destination path's
    /// extension (not the content), so a generic .tmp path (as Path.GetTempFileName returns) would fail
    /// to resolve an encoder.
    /// </remarks>
    public static bool ViaTempMove(string filename, Func<string, bool> action)
    {
        var tempPath = Path.Combine(Path.GetTempPath(), Path.GetRandomFileName() + Path.GetExtension(filename));
        try
        {
            if (!action(tempPath))
                return false;
            File.Move(tempPath, filename, overwrite: true);
            return true;
        }
        finally
        {
            if (File.Exists(tempPath))
                File.Delete(tempPath);
        }
    }
}
