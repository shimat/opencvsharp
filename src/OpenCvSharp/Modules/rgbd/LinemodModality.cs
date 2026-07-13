using OpenCvSharp.Internal;
using OpenCvSharp.Internal.Vectors;

namespace OpenCvSharp.Rgbd;

/// <summary>Feature-extraction strategy used by a LINEMOD detector.</summary>
public class LinemodModality : CvPtrObject
{
    internal LinemodModality(IntPtr smartPtr)
        : base(smartPtr, GetRawPtr(smartPtr),
            static p => NativeMethods.HandleException(NativeMethods.rgbd_linemod_Ptr_Modality_delete(p))) { }

    private static IntPtr GetRawPtr(IntPtr smartPtr)
    {
        if (smartPtr == IntPtr.Zero)
            throw new OpenCvSharpException("Failed to create LINEMOD modality");
        NativeMethods.HandleException(NativeMethods.rgbd_linemod_Ptr_Modality_get(smartPtr, out var rawPtr));
        if (rawPtr == IntPtr.Zero)
            throw new OpenCvSharpException("Failed to create LINEMOD modality");
        return rawPtr;
    }

    /// <summary>Creates a modality by its OpenCV type name.</summary>
    public static LinemodModality Create(string modalityType)
    {
        ArgumentException.ThrowIfNullOrEmpty(modalityType);
        NativeMethods.HandleException(NativeMethods.rgbd_linemod_Modality_create(modalityType, out var ptr));
        return new LinemodModality(ptr);
    }

    /// <summary>Creates a modality from a serialized file node.</summary>
    public static LinemodModality Create(FileNode node)
    {
        ArgumentNullException.ThrowIfNull(node);
        NativeMethods.HandleException(NativeMethods.rgbd_linemod_Modality_createFromFileNode(node.Handle, out var ptr));
        GC.KeepAlive(node);
        return new LinemodModality(ptr);
    }

    /// <summary>The OpenCV modality type name.</summary>
    public string Name
    {
        get
        {
            ThrowIfDisposed();
            using var value = new StdString();
            NativeMethods.HandleException(NativeMethods.rgbd_linemod_Modality_name(Handle, value.CvPtr));
            return value.ToString();
        }
    }

    /// <summary>Forms a quantized image pyramid from a source image.</summary>
    public QuantizedPyramid Process(Mat src, Mat? mask = null)
    {
        ThrowIfDisposed();
        ArgumentNullException.ThrowIfNull(src);
        src.ThrowIfDisposed();
        mask?.ThrowIfDisposed();
        NativeMethods.HandleException(NativeMethods.rgbd_linemod_Modality_process(
            Handle, src.Handle, mask?.Handle ?? OpenCvSafeHandle.Null, out var ptr));
        GC.KeepAlive(src); GC.KeepAlive(mask);
        return new QuantizedPyramid(ptr);
    }

    /// <summary>Loads modality parameters from a file node.</summary>
    public void Read(FileNode node)
    {
        ThrowIfDisposed();
        ArgumentNullException.ThrowIfNull(node);
        NativeMethods.HandleException(NativeMethods.rgbd_linemod_Modality_read(Handle, node.Handle));
        GC.KeepAlive(node);
    }

    /// <summary>Writes modality parameters to file storage.</summary>
    public void Write(FileStorage storage)
    {
        ThrowIfDisposed();
        ArgumentNullException.ThrowIfNull(storage);
        NativeMethods.HandleException(NativeMethods.rgbd_linemod_Modality_write(Handle, storage.Handle));
        GC.KeepAlive(storage);
    }
}

/// <summary>Color-gradient LINEMOD modality.</summary>
public sealed class ColorGradient : LinemodModality
{
    /// <summary>Creates a color-gradient modality.</summary>
    public ColorGradient(float weakThreshold = 10f, nuint numFeatures = 63, float strongThreshold = 55f)
        : base(CreateNative(weakThreshold, numFeatures, strongThreshold)) { }

    private static IntPtr CreateNative(float weakThreshold, nuint numFeatures, float strongThreshold)
    {
        NativeMethods.HandleException(NativeMethods.rgbd_linemod_ColorGradient_create(
            weakThreshold, numFeatures, strongThreshold, out var ptr));
        return ptr;
    }

    private (float Weak, nuint Count, float Strong) Parameters
    {
        get
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(NativeMethods.rgbd_linemod_ColorGradient_get(
                Handle, out var weak, out var count, out var strong));
            return (weak, count, strong);
        }
    }

    /// <summary>Gets the minimum gradient magnitude used during quantization.</summary>
    public float WeakThreshold => Parameters.Weak;
    /// <summary>Gets the number of features extracted for each template.</summary>
    public nuint NumFeatures => Parameters.Count;
    /// <summary>Gets the minimum gradient magnitude used for candidate features.</summary>
    public float StrongThreshold => Parameters.Strong;
}

/// <summary>Depth-normal LINEMOD modality.</summary>
public sealed class DepthNormal : LinemodModality
{
    /// <summary>Creates a depth-normal modality.</summary>
    public DepthNormal(int distanceThreshold = 2000, int differenceThreshold = 50,
        nuint numFeatures = 63, int extractThreshold = 2)
        : base(CreateNative(distanceThreshold, differenceThreshold, numFeatures, extractThreshold)) { }

    private static IntPtr CreateNative(int distanceThreshold, int differenceThreshold,
        nuint numFeatures, int extractThreshold)
    {
        NativeMethods.HandleException(NativeMethods.rgbd_linemod_DepthNormal_create(
            distanceThreshold, differenceThreshold, numFeatures, extractThreshold, out var ptr));
        return ptr;
    }

    private (int Distance, int Difference, nuint Count, int Extract) Parameters
    {
        get
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(NativeMethods.rgbd_linemod_DepthNormal_get(
                Handle, out var distance, out var difference, out var count, out var extract));
            return (distance, difference, count, extract);
        }
    }

    /// <summary>Gets the distance beyond which depth pixels are ignored.</summary>
    public int DistanceThreshold => Parameters.Distance;
    /// <summary>Gets the maximum depth difference used when computing normals.</summary>
    public int DifferenceThreshold => Parameters.Difference;
    /// <summary>Gets the number of features extracted for each template.</summary>
    public nuint NumFeatures => Parameters.Count;
    /// <summary>Gets the orientation-consistency distance used for feature extraction.</summary>
    public int ExtractThreshold => Parameters.Extract;
}

/// <summary>A modality-specific quantized image pyramid.</summary>
public sealed class QuantizedPyramid : CvPtrObject
{
    internal QuantizedPyramid(IntPtr smartPtr)
        : base(smartPtr, GetRawPtr(smartPtr),
            static p => NativeMethods.HandleException(NativeMethods.rgbd_linemod_Ptr_QuantizedPyramid_delete(p))) { }

    private static IntPtr GetRawPtr(IntPtr smartPtr)
    {
        if (smartPtr == IntPtr.Zero)
            throw new OpenCvSharpException("Failed to create QuantizedPyramid");
        NativeMethods.HandleException(NativeMethods.rgbd_linemod_Ptr_QuantizedPyramid_get(smartPtr, out var rawPtr));
        return rawPtr != IntPtr.Zero ? rawPtr : throw new OpenCvSharpException("Failed to create QuantizedPyramid");
    }

    /// <summary>Computes the quantized image at the current pyramid level.</summary>
    public Mat Quantize()
    {
        ThrowIfDisposed();
        var dst = new Mat();
        NativeMethods.HandleException(NativeMethods.rgbd_linemod_QuantizedPyramid_quantize(Handle, dst.Handle));
        return dst;
    }

    /// <summary>Extracts the most discriminant features at the current pyramid level.</summary>
    public bool ExtractTemplate(out LinemodTemplate template)
    {
        ThrowIfDisposed();
        using var features = new StdVector<Vec4i>();
        NativeMethods.HandleException(NativeMethods.rgbd_linemod_QuantizedPyramid_extractTemplate(
            Handle, out var width, out var height, out var level, features.CvPtr, out var result));
        template = new LinemodTemplate(width, height, level,
            features.ToArray().Select(v => new LinemodFeature(v.Item0, v.Item1, v.Item2)).ToArray());
        return result != 0;
    }

    /// <summary>Advances to the next pyramid level.</summary>
    public void PyrDown()
    {
        ThrowIfDisposed();
        NativeMethods.HandleException(NativeMethods.rgbd_linemod_QuantizedPyramid_pyrDown(Handle));
    }
}
