using OpenCvSharp.Internal;
using OpenCvSharp.Internal.Util;
using OpenCvSharp.Internal.Vectors;

namespace OpenCvSharp.LineDescriptor;

/// <summary>
/// Detects line segments and computes binary line descriptors.
/// </summary>
public sealed class BinaryDescriptor : Algorithm
{
    private BinaryDescriptor(IntPtr smartPtr, IntPtr rawPtr)
        : base(smartPtr, rawPtr, p =>
            NativeMethods.HandleException(NativeMethods.line_descriptor_Ptr_BinaryDescriptor_delete(p)))
    {
    }

    /// <summary>
    /// Creates a binary descriptor.
    /// </summary>
    public static BinaryDescriptor Create(Params? parameters = null)
    {
        var nativeParams = parameters?.ToNative() ?? IntPtr.Zero;
        try
        {
            NativeMethods.HandleException(
                NativeMethods.line_descriptor_BinaryDescriptor_create(nativeParams, out var smartPtr));
            NativeMethods.HandleException(
                NativeMethods.line_descriptor_Ptr_BinaryDescriptor_get(smartPtr, out var rawPtr));
            return new BinaryDescriptor(smartPtr, rawPtr);
        }
        finally
        {
            if (nativeParams != IntPtr.Zero)
                NativeMethods.HandleException(
                    NativeMethods.line_descriptor_BinaryDescriptor_Params_delete(nativeParams));
        }
    }

    /// <summary>Gets or sets the number of image octaves.</summary>
    public int NumOfOctaves
    {
        get
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.line_descriptor_BinaryDescriptor_getNumOfOctaves(Handle, out var value));
            return value;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.line_descriptor_BinaryDescriptor_setNumOfOctaves(Handle, value));
        }
    }

    /// <summary>Gets or sets the descriptor band width.</summary>
    public int WidthOfBand
    {
        get
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.line_descriptor_BinaryDescriptor_getWidthOfBand(Handle, out var value));
            return value;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.line_descriptor_BinaryDescriptor_setWidthOfBand(Handle, value));
        }
    }

    /// <summary>Gets or sets the Gaussian-pyramid reduction ratio.</summary>
    public int ReductionRatio
    {
        get
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.line_descriptor_BinaryDescriptor_getReductionRatio(Handle, out var value));
            return value;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.line_descriptor_BinaryDescriptor_setReductionRatio(Handle, value));
        }
    }

    /// <summary>Gets the descriptor size in bits.</summary>
    public int DescriptorSize
    {
        get
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.line_descriptor_BinaryDescriptor_descriptorSize(Handle, out var value));
            return value;
        }
    }

    /// <summary>Gets the OpenCV matrix type used by binary descriptors.</summary>
    public int DescriptorType
    {
        get
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.line_descriptor_BinaryDescriptor_descriptorType(Handle, out var value));
            return value;
        }
    }

    /// <summary>Gets the default norm used to compare descriptors.</summary>
    public int DefaultNorm
    {
        get
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.line_descriptor_BinaryDescriptor_defaultNorm(Handle, out var value));
            return value;
        }
    }

    /// <summary>
    /// Detects line segments in an image.
    /// </summary>
    public KeyLine[] Detect(Mat image, Mat? mask = null)
    {
        ThrowIfDisposed();
        ArgumentNullException.ThrowIfNull(image);
        image.ThrowIfDisposed();
        mask?.ThrowIfDisposed();
        using var keyLines = new VectorOfKeyLine();
        NativeMethods.HandleException(
            NativeMethods.line_descriptor_BinaryDescriptor_detect1(
                Handle, image.CvPtr, keyLines.CvPtr, mask?.Handle ?? OpenCvSafeHandle.Null));
        GC.KeepAlive(image);
        GC.KeepAlive(mask);
        return keyLines.ToArray();
    }

    /// <summary>
    /// Detects line segments in multiple images.
    /// </summary>
    public KeyLine[][] Detect(IEnumerable<Mat> images, IEnumerable<Mat>? masks = null)
    {
        ThrowIfDisposed();
        var imageArray = MaterializeMats(images, nameof(images));
        var maskArray = masks is null ? [] : MaterializeMats(masks, nameof(masks));
        if (maskArray.Length != 0 && maskArray.Length != imageArray.Length)
            throw new ArgumentException("Masks must be empty or have one entry per image.", nameof(masks));
        using var keyLines = new VectorOfVectorKeyLine();
        NativeMethods.HandleException(
            NativeMethods.line_descriptor_BinaryDescriptor_detect2(
                Handle, imageArray.Select(x => x.CvPtr).ToArray(), imageArray.Length, keyLines.CvPtr,
                maskArray.Select(x => x.CvPtr).ToArray(), maskArray.Length));
        GC.KeepAlive(imageArray);
        GC.KeepAlive(maskArray);
        return keyLines.ToArray();
    }

    /// <summary>
    /// Computes descriptors for the supplied lines. The native algorithm may update the lines.
    /// </summary>
    public void Compute(Mat image, ref KeyLine[] keyLines, Mat descriptors, bool returnFloatDescriptor = false)
    {
        ThrowIfDisposed();
        ArgumentNullException.ThrowIfNull(image);
        ArgumentNullException.ThrowIfNull(keyLines);
        ArgumentNullException.ThrowIfNull(descriptors);
        image.ThrowIfDisposed();
        descriptors.ThrowIfDisposed();
        using var keyLineVector = new VectorOfKeyLine(keyLines);
        NativeMethods.HandleException(
            NativeMethods.line_descriptor_BinaryDescriptor_compute1(
                Handle, image.CvPtr, keyLineVector.CvPtr, descriptors.CvPtr,
                returnFloatDescriptor ? 1 : 0));
        keyLines = keyLineVector.ToArray();
        GC.KeepAlive(image);
        GC.KeepAlive(descriptors);
    }

    /// <summary>
    /// Computes descriptors for lines from multiple images.
    /// </summary>
    public void Compute(
        IEnumerable<Mat> images,
        ref KeyLine[][] keyLines,
        out Mat[] descriptors,
        bool returnFloatDescriptor = false)
    {
        ThrowIfDisposed();
        ArgumentNullException.ThrowIfNull(keyLines);
        var imageArray = MaterializeMats(images, nameof(images));
        if (imageArray.Length != keyLines.Length)
            throw new ArgumentException("Images and key lines must have the same length.", nameof(keyLines));
        using var keyLinePointers = new ArrayAddress2<KeyLine>(keyLines);
        using var outputKeyLines = new VectorOfVectorKeyLine();
        using var descriptorVector = new VectorOfMat();
        NativeMethods.HandleException(
            NativeMethods.line_descriptor_BinaryDescriptor_compute2(
                Handle, imageArray.Select(x => x.CvPtr).ToArray(), imageArray.Length,
                keyLinePointers.GetPointer(), keyLinePointers.GetDim2Lengths(), keyLines.Length,
                outputKeyLines.CvPtr, descriptorVector.CvPtr, returnFloatDescriptor ? 1 : 0));
        keyLines = outputKeyLines.ToArray();
        descriptors = descriptorVector.ToArray();
        GC.KeepAlive(imageArray);
    }

    private static Mat[] MaterializeMats(IEnumerable<Mat> mats, string parameterName)
    {
        ArgumentNullException.ThrowIfNull(mats, parameterName);
        var result = mats.ToArray();
        foreach (var mat in result)
        {
            if (mat is null)
                throw new ArgumentException("The collection contains null.", parameterName);
            mat.ThrowIfDisposed();
        }
        return result;
    }

#pragma warning disable CA1034
    /// <summary>
    /// Binary descriptor configuration.
    /// </summary>
    public sealed class Params
    {
        /// <summary>Creates a parameter set initialized with OpenCV defaults.</summary>
        public Params()
        {
            NativeMethods.HandleException(
                NativeMethods.line_descriptor_BinaryDescriptor_Params_new(out var native));
            try
            {
                LoadFrom(native);
            }
            finally
            {
                NativeMethods.HandleException(
                    NativeMethods.line_descriptor_BinaryDescriptor_Params_delete(native));
            }
        }

        /// <summary>Gets or sets the number of octaves.</summary>
        public int NumOfOctaves { get; set; }
        /// <summary>Gets or sets the descriptor band width.</summary>
        public int WidthOfBand { get; set; }
        /// <summary>Gets or sets the pyramid reduction ratio.</summary>
        public int ReductionRatio { get; set; }
        /// <summary>Gets or sets the smoothing kernel size.</summary>
        public int KSize { get; set; }

        /// <summary>Reads parameter values from a file node.</summary>
        public void Read(FileNode node)
        {
            ArgumentNullException.ThrowIfNull(node);
            var native = ToNative();
            try
            {
                NativeMethods.HandleException(
                    NativeMethods.line_descriptor_BinaryDescriptor_Params_read(native, node.CvPtr));
                LoadFrom(native);
                GC.KeepAlive(node);
            }
            finally
            {
                NativeMethods.HandleException(
                    NativeMethods.line_descriptor_BinaryDescriptor_Params_delete(native));
            }
        }

        /// <summary>Writes parameter values to a file storage.</summary>
        public void Write(FileStorage storage)
        {
            ArgumentNullException.ThrowIfNull(storage);
            var native = ToNative();
            try
            {
                NativeMethods.HandleException(
                    NativeMethods.line_descriptor_BinaryDescriptor_Params_write(native, storage.CvPtr));
                GC.KeepAlive(storage);
            }
            finally
            {
                NativeMethods.HandleException(
                    NativeMethods.line_descriptor_BinaryDescriptor_Params_delete(native));
            }
        }

        private void LoadFrom(IntPtr native)
        {
            NativeMethods.HandleException(
                NativeMethods.line_descriptor_BinaryDescriptor_Params_getAll(native, out var data));
            NumOfOctaves = data.NumOfOctaves;
            WidthOfBand = data.WidthOfBand;
            ReductionRatio = data.ReductionRatio;
            KSize = data.KSize;
        }

        internal IntPtr ToNative()
        {
            NativeMethods.HandleException(
                NativeMethods.line_descriptor_BinaryDescriptor_Params_new(out var native));
            try
            {
                NativeMethods.HandleException(
                    NativeMethods.line_descriptor_BinaryDescriptor_Params_setAll(native, new BinaryDescriptorParamsData
                    {
                        NumOfOctaves = NumOfOctaves,
                        WidthOfBand = WidthOfBand,
                        ReductionRatio = ReductionRatio,
                        KSize = KSize,
                    }));
                return native;
            }
            catch
            {
                NativeMethods.HandleException(
                    NativeMethods.line_descriptor_BinaryDescriptor_Params_delete(native));
                throw;
            }
        }
    }
}
