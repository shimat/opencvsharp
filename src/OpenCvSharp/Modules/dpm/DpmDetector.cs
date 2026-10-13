using OpenCvSharp.Internal;
using OpenCvSharp.Internal.Vectors;

namespace OpenCvSharp.Dpm;

/// <summary>Object detector using OpenCV's deformable part models.</summary>
public sealed class DpmDetector : CvPtrObject
{
    private DpmDetector(IntPtr smartPtr, IntPtr rawPtr)
        : base(smartPtr, rawPtr, p => NativeMethods.HandleException(NativeMethods.dpm_Ptr_DPMDetector_delete(p)))
    { }

    /// <summary>Loads DPM model XML files with optional class names.</summary>
    /// <param name="modelPaths">Paths to one or more DPM model XML files.</param>
    /// <param name="classNames">Optional class name for each model, in the same order.</param>
    public static DpmDetector Create(IEnumerable<string> modelPaths, IEnumerable<string>? classNames = null)
    {
        ArgumentNullException.ThrowIfNull(modelPaths);
        var paths = modelPaths.ToArray();
        if (paths.Length == 0)
            throw new ArgumentException("At least one model path is required.", nameof(modelPaths));
        foreach (var path in paths)
        {
            ArgumentException.ThrowIfNullOrEmpty(path);
            if (!File.Exists(path))
                throw new FileNotFoundException("DPM model file was not found.", path);
            if (path.Length < 5 || !path.EndsWith(".xml", StringComparison.Ordinal))
                throw new ArgumentException("DPM model paths must end with .xml.", nameof(modelPaths));
        }

        var names = classNames?.ToArray() ?? [];
        if (names.Length != 0 && names.Length != paths.Length)
            throw new ArgumentException("Provide exactly one class name per model.", nameof(classNames));
        if (names.Any(string.IsNullOrEmpty))
            throw new ArgumentException("Class names must not be null or empty.", nameof(classNames));

        using var pathsVec = new VectorOfString(paths);
        using var namesVec = new VectorOfString(names);
        NativeMethods.HandleException(NativeMethods.dpm_DPMDetector_create(
            pathsVec.CvPtr, namesVec.CvPtr, out var smartPtr));
        NativeMethods.HandleException(NativeMethods.dpm_Ptr_DPMDetector_get(smartPtr, out var rawPtr));
        return new DpmDetector(smartPtr, rawPtr);
    }

    /// <summary>Whether no models were loaded.</summary>
    public bool IsEmpty
    {
        get
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(NativeMethods.dpm_DPMDetector_isEmpty(RawPtr, out var value));
            return value != 0;
        }
    }

    /// <summary>Number of loaded model classes.</summary>
    public int ClassCount
    {
        get
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(NativeMethods.dpm_DPMDetector_getClassCount(RawPtr, out var value));
            return value;
        }
    }

    /// <summary>Names of the loaded model classes.</summary>
    public string[] ClassNames
    {
        get
        {
            ThrowIfDisposed();
            using var names = new VectorOfString();
            NativeMethods.HandleException(NativeMethods.dpm_DPMDetector_getClassNames(RawPtr, names.CvPtr));
            return names.ToArray();
        }
    }

    /// <summary>Detects model classes in an 8-bit grayscale or BGR image without changing the source.</summary>
    public DpmObjectDetection[] Detect(Mat image)
    {
        ThrowIfDisposed();
        ArgumentNullException.ThrowIfNull(image);
        image.ThrowIfDisposed();
        if (image.Type() != MatType.CV_8UC1 && image.Type() != MatType.CV_8UC3)
            throw new ArgumentException("Expected an 8-bit grayscale or BGR image.", nameof(image));

        NativeMethods.HandleException(NativeMethods.dpm_DPMDetector_detect(RawPtr, image.CvPtr, out var detections));
        GC.KeepAlive(image);
        try
        {
            NativeMethods.HandleException(NativeMethods.dpm_detections_count(detections, out var count));
            var result = new DpmObjectDetection[count];
            for (var i = 0; i < count; i++)
            {
                NativeMethods.HandleException(NativeMethods.dpm_detections_get(
                    detections, i, out var rect, out var score, out var classId));
                result[i] = new DpmObjectDetection(rect, score, classId);
            }
            return result;
        }
        finally
        {
            NativeMethods.HandleException(NativeMethods.dpm_detections_delete(detections));
        }
    }
}
