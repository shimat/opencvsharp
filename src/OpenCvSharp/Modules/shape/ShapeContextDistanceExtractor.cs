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
    private Ptr? ptrObj;

    #region Init & Disposal

    /// <summary>
    /// 
    /// </summary>
    protected ShapeContextDistanceExtractor(IntPtr p)
    {
        ptrObj = new Ptr(p);
        ptr = ptrObj.Get();
    }

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
        return new ShapeContextDistanceExtractor(ret);
    }

    /// <summary>
    /// Releases managed resources
    /// </summary>
    protected override void DisposeManaged()
    {
        ptrObj?.Dispose();
        ptrObj = null;
        base.DisposeManaged();
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
                NativeMethods.shape_ShapeContextDistanceExtractor_getAngularBins(ptr, out var ret));
            GC.KeepAlive(this);
            return ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.shape_ShapeContextDistanceExtractor_setAngularBins(ptr, value));
            GC.KeepAlive(this);
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
                NativeMethods.shape_ShapeContextDistanceExtractor_getRadialBins(ptr, out var ret));
            GC.KeepAlive(this);
            return ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.shape_ShapeContextDistanceExtractor_setRadialBins(ptr, value));
            GC.KeepAlive(this);
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
                NativeMethods.shape_ShapeContextDistanceExtractor_getInnerRadius(ptr, out var ret));
            GC.KeepAlive(this);
            return ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.shape_ShapeContextDistanceExtractor_setInnerRadius(ptr, value));
            GC.KeepAlive(this);
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
                NativeMethods.shape_ShapeContextDistanceExtractor_getOuterRadius(ptr, out var ret));
            GC.KeepAlive(this);
            return ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.shape_ShapeContextDistanceExtractor_setOuterRadius(ptr, value));
            GC.KeepAlive(this);
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
                NativeMethods.shape_ShapeContextDistanceExtractor_getRotationInvariant(ptr, out var ret));
            GC.KeepAlive(this);
            return ret != 0;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.shape_ShapeContextDistanceExtractor_setRotationInvariant(ptr, value ? 1 : 0));
            GC.KeepAlive(this);
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
                NativeMethods.shape_ShapeContextDistanceExtractor_getShapeContextWeight(ptr, out var ret));
            GC.KeepAlive(this);
            return ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.shape_ShapeContextDistanceExtractor_setShapeContextWeight(ptr, value));
            GC.KeepAlive(this);
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
                NativeMethods.shape_ShapeContextDistanceExtractor_getImageAppearanceWeight(ptr, out var ret));
            GC.KeepAlive(this);
            return ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.shape_ShapeContextDistanceExtractor_setImageAppearanceWeight(ptr, value));
            GC.KeepAlive(this);
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
                NativeMethods.shape_ShapeContextDistanceExtractor_getBendingEnergyWeight(ptr, out var ret));
            GC.KeepAlive(this);
            return ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.shape_ShapeContextDistanceExtractor_setBendingEnergyWeight(ptr, value));
            GC.KeepAlive(this);
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
                NativeMethods.shape_ShapeContextDistanceExtractor_getIterations(ptr, out var ret));
            GC.KeepAlive(this);
            return ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.shape_ShapeContextDistanceExtractor_setIterations(ptr, value));
            GC.KeepAlive(this);
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
                NativeMethods.shape_ShapeContextDistanceExtractor_getStdDev(ptr, out var ret));
            GC.KeepAlive(this);
            return ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.shape_ShapeContextDistanceExtractor_setStdDev(ptr, value));
            GC.KeepAlive(this);
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
            NativeMethods.shape_ShapeContextDistanceExtractor_setImages(ptr, image1.CvPtr, image2.CvPtr));

        GC.KeepAlive(this);
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
            NativeMethods.shape_ShapeContextDistanceExtractor_getImages(ptr, image1.CvPtr, image2.CvPtr));

        image1.Fix();
        image2.Fix();
        GC.KeepAlive(this);
        GC.KeepAlive(image1);
        GC.KeepAlive(image2);
    }

    #endregion

    internal class Ptr : OpenCvSharp.Ptr
    {
        public Ptr(IntPtr ptr) : base(ptr)
        {
        }

        public override IntPtr Get()
        {
            NativeMethods.HandleException(
                NativeMethods.shape_Ptr_ShapeContextDistanceExtractor_get(ptr, out var ret));
            GC.KeepAlive(this);
            return ret;
        }

        protected override void DisposeUnmanaged()
        {
            NativeMethods.HandleException(
                NativeMethods.shape_Ptr_ShapeContextDistanceExtractor_delete(ptr));
            base.DisposeUnmanaged();
        }
    }
}
