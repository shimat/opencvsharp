using OpenCvSharp.Internal;
using OpenCvSharp.Internal.Vectors;

namespace OpenCvSharp.Rgbd;

/// <summary>Object detector using LINE template matching with one or more modalities.</summary>
public sealed class LinemodDetector : CvObject
{
    private LinemodDetector(IntPtr ptr)
        => SetSafeHandle(new OpenCvPtrSafeHandle(ptr, true,
            static p => NativeMethods.HandleException(NativeMethods.rgbd_linemod_Detector_delete(p))));

    /// <summary>Creates an empty detector intended to be initialized with <see cref="Read"/>.</summary>
    public LinemodDetector()
    {
        NativeMethods.HandleException(NativeMethods.rgbd_linemod_Detector_newEmpty(out var ptr));
        SetSafeHandle(new OpenCvPtrSafeHandle(ptr, true,
            static p => NativeMethods.HandleException(NativeMethods.rgbd_linemod_Detector_delete(p))));
    }

    /// <summary>Creates a detector using the supplied modalities and sampling steps.</summary>
    public LinemodDetector(IEnumerable<LinemodModality> modalities, IEnumerable<int> tPyramid)
    {
        ArgumentNullException.ThrowIfNull(modalities);
        ArgumentNullException.ThrowIfNull(tPyramid);
        var mods = modalities.ToArray();
        var steps = tPyramid.ToArray();
        if (mods.Length == 0 || steps.Length == 0)
            throw new ArgumentException("At least one modality and pyramid sampling step are required.");
        var pointers = mods.Select(m => m.SmartPtr).ToArray();
        NativeMethods.HandleException(NativeMethods.rgbd_linemod_Detector_new(
            pointers, pointers.Length, steps, steps.Length, out var ptr));
        SetSafeHandle(new OpenCvPtrSafeHandle(ptr, true,
            static p => NativeMethods.HandleException(NativeMethods.rgbd_linemod_Detector_delete(p))));
        foreach (var mod in mods) GC.KeepAlive(mod);
    }

    /// <summary>Creates the default color-gradient LINE detector.</summary>
    public static LinemodDetector CreateDefaultLINE()
    {
        NativeMethods.HandleException(NativeMethods.rgbd_linemod_getDefaultLINE(out var ptr));
        return new LinemodDetector(ptr);
    }

    /// <summary>Creates the default color-and-depth LINEMOD detector.</summary>
    public static LinemodDetector CreateDefaultLINEMOD()
    {
        NativeMethods.HandleException(NativeMethods.rgbd_linemod_getDefaultLINEMOD(out var ptr));
        return new LinemodDetector(ptr);
    }

    /// <summary>Extracts and registers a new object template.</summary>
    public int AddTemplate(IEnumerable<Mat> sources, string classId, Mat objectMask, out Rect boundingBox)
    {
        ArgumentNullException.ThrowIfNull(sources); ArgumentException.ThrowIfNullOrEmpty(classId);
        ArgumentNullException.ThrowIfNull(objectMask);
        var sourceArray = sources.ToArray();
        using var sourceVec = new VectorOfMat(sourceArray);
        NativeMethods.HandleException(NativeMethods.rgbd_linemod_Detector_addTemplate(
            Handle, sourceVec.CvPtr, classId, objectMask.Handle, out boundingBox, out var result));
        foreach (var source in sourceArray) GC.KeepAlive(source);
        GC.KeepAlive(objectMask);
        return result;
    }

    /// <summary>Adds a template pyramid computed externally.</summary>
    public int AddSyntheticTemplate(IEnumerable<LinemodTemplate> templates, string classId)
    {
        ArgumentNullException.ThrowIfNull(templates); ArgumentException.ThrowIfNullOrEmpty(classId);
        var templateArray = templates.ToArray();
        using var headers = new StdVector<Vec4i>(templateArray.Select(t =>
            new Vec4i(t.Width, t.Height, t.PyramidLevel, t.Features.Length)));
        using var features = new StdVector<Vec4i>(templateArray.SelectMany(t => t.Features)
            .Select(f => new Vec4i(f.X, f.Y, f.Label, 0)));
        NativeMethods.HandleException(NativeMethods.rgbd_linemod_Detector_addSyntheticTemplate(
            Handle, headers.CvPtr, features.CvPtr, classId, out var result));
        return result;
    }

    /// <summary>Matches registered templates against source images.</summary>
    public LinemodMatch[] Match(IEnumerable<Mat> sources, float threshold,
        IEnumerable<string>? classIds = null, IEnumerable<Mat>? masks = null)
        => Match(sources, threshold, out _, classIds, masks);

    /// <summary>Matches templates and returns the generated quantized images.</summary>
    public LinemodMatch[] Match(IEnumerable<Mat> sources, float threshold, out Mat[] quantizedImages,
        IEnumerable<string>? classIds = null, IEnumerable<Mat>? masks = null)
    {
        ArgumentNullException.ThrowIfNull(sources);
        var sourceArray = sources.ToArray();
        var maskArray = masks?.ToArray();
        using var sourceVec = new VectorOfMat(sourceArray);
        using var values = new StdVector<Vec4f>();
        using var resultClassIds = new VectorOfString();
        using var filter = classIds is null ? null : new VectorOfString(classIds);
        using var quantized = new VectorOfMat();
        using var maskVec = maskArray is null ? null : new VectorOfMat(maskArray);
        NativeMethods.HandleException(NativeMethods.rgbd_linemod_Detector_match(
            Handle, sourceVec.CvPtr, threshold, values.CvPtr, resultClassIds.CvPtr,
            filter?.CvPtr ?? IntPtr.Zero, quantized.CvPtr, maskVec?.CvPtr ?? IntPtr.Zero));
        var nativeValues = values.ToArray();
        var ids = resultClassIds.ToArray();
        quantizedImages = quantized.ToArray();
        var result = new LinemodMatch[nativeValues.Length];
        for (var i = 0; i < result.Length; i++)
        {
            var v = nativeValues[i];
            result[i] = new LinemodMatch((int)v.Item0, (int)v.Item1, v.Item2, ids[i], (int)v.Item3);
        }
        foreach (var source in sourceArray) GC.KeepAlive(source);
        if (maskArray is not null) foreach (var mask in maskArray) GC.KeepAlive(mask);
        return result;
    }

    /// <summary>Gets the number of pyramid levels.</summary>
    public int PyramidLevels => GetValue(NativeMethods.rgbd_linemod_Detector_pyramidLevels);
    /// <summary>Gets the total number of registered templates.</summary>
    public int NumTemplates => GetValue(NativeMethods.rgbd_linemod_Detector_numTemplates);
    /// <summary>Gets the number of registered classes.</summary>
    public int NumClasses => GetValue(NativeMethods.rgbd_linemod_Detector_numClasses);

    /// <summary>Gets the sampling step at a pyramid level.</summary>
    public int GetT(int pyramidLevel)
    {
        NativeMethods.HandleException(NativeMethods.rgbd_linemod_Detector_getT(Handle, pyramidLevel, out var value));
        return value;
    }

    /// <summary>Gets the number of templates registered for a class.</summary>
    public int GetNumTemplates(string classId)
    {
        ArgumentException.ThrowIfNullOrEmpty(classId);
        NativeMethods.HandleException(NativeMethods.rgbd_linemod_Detector_numTemplatesByClass(Handle, classId, out var value));
        return value;
    }

    /// <summary>Gets all registered class identifiers.</summary>
    public string[] GetClassIds()
    {
        using var values = new VectorOfString();
        NativeMethods.HandleException(NativeMethods.rgbd_linemod_Detector_classIds(Handle, values.CvPtr));
        return values.ToArray();
    }

    /// <summary>Gets the template pyramid identified by class and template ID.</summary>
    public LinemodTemplate[] GetTemplates(string classId, int templateId)
    {
        ArgumentException.ThrowIfNullOrEmpty(classId);
        using var headers = new StdVector<Vec4i>();
        using var features = new StdVector<Vec4i>();
        NativeMethods.HandleException(NativeMethods.rgbd_linemod_Detector_getTemplates(
            Handle, classId, templateId, headers.CvPtr, features.CvPtr));
        var nativeHeaders = headers.ToArray();
        var nativeFeatures = features.ToArray();
        var result = new LinemodTemplate[nativeHeaders.Length];
        var offset = 0;
        for (var i = 0; i < result.Length; i++)
        {
            var h = nativeHeaders[i];
            var featureArray = new LinemodFeature[h.Item3];
            for (var j = 0; j < featureArray.Length; j++)
            {
                var f = nativeFeatures[offset++];
                featureArray[j] = new LinemodFeature(f.Item0, f.Item1, f.Item2);
            }
            result[i] = new LinemodTemplate(h.Item0, h.Item1, h.Item2, featureArray);
        }
        return result;
    }

    /// <summary>Gets copies of the modalities used by this detector.</summary>
    public LinemodModality[] GetModalities()
    {
        NativeMethods.HandleException(NativeMethods.rgbd_linemod_Detector_getModalitiesSize(Handle, out var count));
        var result = new LinemodModality[count];
        try
        {
            for (var i = 0; i < count; i++)
            {
                NativeMethods.HandleException(NativeMethods.rgbd_linemod_Detector_getModality(Handle, i, out var ptr));
                result[i] = new LinemodModality(ptr);
            }
            return result;
        }
        catch
        {
            foreach (var modality in result)
                modality?.Dispose();
            throw;
        }
    }

    /// <summary>Loads detector configuration from a file node.</summary>
    public void Read(FileNode node)
    {
        ArgumentNullException.ThrowIfNull(node);
        NativeMethods.HandleException(NativeMethods.rgbd_linemod_Detector_read(Handle, node.Handle));
        GC.KeepAlive(node);
    }

    /// <summary>Writes detector configuration to file storage.</summary>
    public void Write(FileStorage storage)
    {
        ArgumentNullException.ThrowIfNull(storage);
        NativeMethods.HandleException(NativeMethods.rgbd_linemod_Detector_write(Handle, storage.Handle));
        GC.KeepAlive(storage);
    }

    /// <summary>Loads one serialized template class and returns its class identifier.</summary>
    public string ReadClass(FileNode node, string classIdOverride = "")
    {
        ArgumentNullException.ThrowIfNull(node);
        using var value = new StdString();
        NativeMethods.HandleException(NativeMethods.rgbd_linemod_Detector_readClass(
            Handle, node.Handle, classIdOverride, value.CvPtr));
        GC.KeepAlive(node);
        return value.ToString();
    }

    /// <summary>Writes one template class to file storage.</summary>
    public void WriteClass(string classId, FileStorage storage)
    {
        ArgumentException.ThrowIfNullOrEmpty(classId); ArgumentNullException.ThrowIfNull(storage);
        NativeMethods.HandleException(NativeMethods.rgbd_linemod_Detector_writeClass(Handle, classId, storage.Handle));
        GC.KeepAlive(storage);
    }

    /// <summary>Loads template classes from files matching a format string.</summary>
    public void ReadClasses(IEnumerable<string> classIds, string format = "templates_%s.yml.gz")
    {
        using var values = new VectorOfString(classIds);
        NativeMethods.HandleException(NativeMethods.rgbd_linemod_Detector_readClasses(Handle, values.CvPtr, format));
    }

    /// <summary>Writes every template class to a separate file.</summary>
    public void WriteClasses(string format = "templates_%s.yml.gz")
        => NativeMethods.HandleException(NativeMethods.rgbd_linemod_Detector_writeClasses(Handle, format));

    private delegate ExceptionStatus Getter(OpenCvSafeHandle obj, out int value);
    private int GetValue(Getter getter)
    {
        NativeMethods.HandleException(getter(Handle, out var value));
        return value;
    }
}
