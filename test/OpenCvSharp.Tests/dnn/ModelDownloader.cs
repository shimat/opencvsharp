using System;
using System.IO;

namespace OpenCvSharp.Tests.Dnn;

internal static class ModelDownloader
{
    /// <summary>
    /// Download model file
    /// </summary>
    /// <param name="uri"></param>
    /// <param name="fileName"></param>
    public static void DownloadAndSave(Uri uri, string fileName)
    {
        if (File.Exists(fileName))
            return;

        var bytes = FileDownloader.DownloadData(uri);
        File.WriteAllBytes(fileName, bytes);
    }
}
