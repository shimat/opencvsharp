using OpenCvSharp.Internal;

namespace OpenCvSharp;

// ReSharper disable once InconsistentNaming
/// <summary>
/// Implementation of the Shape Context descriptor and matching algorithm
/// </summary>
/// <remarks>
/// proposed by Belongie et al. in "Shape Matching and Object Recognition Using Shape Contexts" 
/// (PAMI2002). This implementation is packaged in a generic scheme, in order to allow 
/// you the implementation of the common variations of the original pipeline.
/// </remarks>
public class ShapeContextDistanceExtractor : ShapeDistanceExtractor
{
    #region Init & Disposal

    /// <summary>
    /// 
    /// </summary>
    private ShapeContextDistanceExtractor(IntPtr smartPtr, IntPtr rawPtr)
        : base(smartPtr, rawPtr, p => NativeMethods.HandleException(NativeMethods.shape_Ptr_ShapeContextDistanceExtractor_delete(p)))
    { }
    /// <summary>
    /// Complete constructor
    /// </summary>
    /// <param name="nAngularBins">The number of angular bins in the shape context descriptor.</param>
    /// <param name="nRadialBins">The number of radial bins in the shape context descriptor.</param>
    /// <param name="innerRadius">The value of the inner radius.</param>
    /// <param name="outerRadius">The value of the outer radius.</param>
    /// <param name="iterations"></param>
    /// <returns></returns>
    public static ShapeContextDistanceExtractor Create(
        int nAngularBins = 12, int nRadialBins = 4, float innerRadius = 0.2f,
        float outerRadius = 2, int iterations = 3)
    {
        NativeMethods.HandleException(
            NativeMethods.shape_createShapeContextDistanceExtractor(
                nAngularBins, nRadialBins, innerRadius, outerRadius, iterations, out var ret));
        NativeMethods.HandleException(NativeMethods.shape_Ptr_ShapeContextDistanceExtractor_get(ret, out var rawPtr));
        return new ShapeContextDistanceExtractor(ret, rawPtr);
    }

    #endregion

    #region Properties

    /// <summary>
    /// The number of angular bins in the shape context descriptor.
    /// </summary>
    public int AngularBins 
    {
        get
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.shape_ShapeContextDistanceExtractor_getAngularBins(Handle, out var ret));
            return ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.shape_ShapeContextDistanceExtractor_setAngularBins(Handle, value));
        }
    }

    /// <summary>
    /// The number of radial bins in the shape context descriptor.
    /// </summary>
    public int RadialBins 
    {
        get
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.shape_ShapeContextDistanceExtractor_getRadialBins(Handle, out var ret));
            return ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.shape_ShapeContextDistanceExtractor_setRadialBins(Handle, value));
        }
    }

    /// <summary>
    /// The value of the inner radius.
    /// </summary>
    public float InnerRadius 
    {
        get
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.shape_ShapeContextDistanceExtractor_getInnerRadius(Handle, out var ret));
            return ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.shape_ShapeContextDistanceExtractor_setInnerRadius(Handle, value));
        }
    }

    /// <summary>
    /// The value of the outer radius.
    /// </summary>
    public float OuterRadius 
    {
        get
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.shape_ShapeContextDistanceExtractor_getOuterRadius(Handle, out var ret));
            return ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.shape_ShapeContextDistanceExtractor_setOuterRadius(Handle, value));
        }
    }
        
    /// <summary>
    /// 
    /// </summary>
    public bool RotationInvariant 
    {
        get
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.shape_ShapeContextDistanceExtractor_getRotationInvariant(Handle, out var ret));
            return ret != 0;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.shape_ShapeContextDistanceExtractor_setRotationInvariant(Handle, value ? 1 : 0));
        }
    }

    /// <summary>
    /// The weight of the shape context distance in the final distance value.
    /// </summary>
    public float ShapeContextWeight 
    {
        get
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.shape_ShapeContextDistanceExtractor_getShapeContextWeight(Handle, out var ret));
            return ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.shape_ShapeContextDistanceExtractor_setShapeContextWeight(Handle, value));
        }
    }

    /// <summary>
    /// The weight of the appearance cost in the final distance value.
    /// </summary>
    public float ImageAppearanceWeight 
    {
        get
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.shape_ShapeContextDistanceExtractor_getImageAppearanceWeight(Handle, out var ret));
            return ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.shape_ShapeContextDistanceExtractor_setImageAppearanceWeight(Handle, value));
        }
    }

    /// <summary>
    /// The weight of the Bending Energy in the final distance value.
    /// </summary>
    public float BendingEnergyWeight
    {
        get
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.shape_ShapeContextDistanceExtractor_getBendingEnergyWeight(Handle, out var ret));
            return ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.shape_ShapeContextDistanceExtractor_setBendingEnergyWeight(Handle, value));
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public int Iterations
    {
        get
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.shape_ShapeContextDistanceExtractor_getIterations(Handle, out var ret));
            return ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.shape_ShapeContextDistanceExtractor_setIterations(Handle, value));
        }
    }

    /// <summary>
    /// The value of the standard deviation for the Gaussian window for the image appearance cost.
    /// </summary>
    public float StdDev
    {
        get
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.shape_ShapeContextDistanceExtractor_getStdDev(Handle, out var ret));
            return ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.shape_ShapeContextDistanceExtractor_setStdDev(Handle, value));
        }
    }

    #endregion

    #region Methods

    /// <summary>
    /// Set the images that correspond to each shape. 
    /// This images are used in the calculation of the Image Appearance cost.
    /// </summary>
    /// <param name="image1">Image corresponding to the shape defined by contours1.</param>
    /// <param name="image2">Image corresponding to the shape defined by contours2.</param>
    public void SetImages(InputArray image1, InputArray image2)
    {
        ThrowIfDisposed();
        if (image1 is null)
            throw new ArgumentNullException(nameof(image1));
        if (image2 is null)
            throw new ArgumentNullException(nameof(image2));
        image1.ThrowIfDisposed();
        image2.ThrowIfDisposed();

        NativeMethods.HandleException(
            NativeMethods.shape_ShapeContextDistanceExtractor_setImages(Handle, image1.CvPtr, image2.CvPtr));

        GC.KeepAlive(image1);
        GC.KeepAlive(image2);
    }

    /// <summary>
    /// Get the images that correspond to each shape. 
    /// This images are used in the calculation of the Image Appearance cost.
    /// </summary>
    /// <param name="image1">Image corresponding to the shape defined by contours1.</param>
    /// <param name="image2">Image corresponding to the shape defined by contours2.</param>
    public void GetImages(OutputArray image1, OutputArray image2)
    {
        ThrowIfDisposed();
        if (image1 is null)
            throw new ArgumentNullException(nameof(image1));
        if (image2 is null)
            throw new ArgumentNullException(nameof(image2));
        image1.ThrowIfNotReady();
        image2.ThrowIfNotReady();

        NativeMethods.HandleException(
            NativeMethods.shape_ShapeContextDistanceExtractor_getImages(Handle, image1.CvPtr, image2.CvPtr));

        image1.Fix();
        image2.Fix();
        GC.KeepAlive(image1);
        GC.KeepAlive(image2);
    }

    #endregion

    #region Methods (cost extractor / transform algorithm)

    /// <summary>
    /// Sets the histogram cost extractor used internally during shape matching.
    /// </summary>
    /// <param name="comparer">The cost extractor to use.</param>
    public void SetCostExtractor(HistogramCostExtractor comparer)
    {
        ThrowIfDisposed();
        if (comparer is null)
            throw new ArgumentNullException(nameof(comparer));
        comparer.ThrowIfDisposed();

        NativeMethods.HandleException(
            NativeMethods.shape_ShapeContextDistanceExtractor_setCostExtractor(
                Handle, comparer.SmartPtr));

        GC.KeepAlive(comparer);
    }

    /// <summary>
    /// Sets the shape transformer used internally during shape matching.
    /// </summary>
    /// <param name="transformer">The shape transformer to use.</param>
    public void SetTransformAlgorithm(ShapeTransformer transformer)
    {
        ThrowIfDisposed();
        if (transformer is null)
            throw new ArgumentNullException(nameof(transformer));
        transformer.ThrowIfDisposed();

        var basePtr = transformer.CreateBaseSmartPtr();
        try
        {
            NativeMethods.HandleException(
                NativeMethods.shape_ShapeContextDistanceExtractor_setTransformAlgorithm(
                    Handle, basePtr));
        }
        finally
        {
            NativeMethods.HandleException(NativeMethods.shape_Ptr_ShapeTransformer_delete(basePtr));
        }

        GC.KeepAlive(transformer);
    }

    #endregion
}
