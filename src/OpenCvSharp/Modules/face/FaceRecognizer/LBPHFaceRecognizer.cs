using OpenCvSharp.Internal;
using OpenCvSharp.Internal.Vectors;

namespace OpenCvSharp.Face;

/// <inheritdoc />
/// <summary>
/// The Circular Local Binary Patterns (used in training and prediction) expect the data given as
/// grayscale images, use cvtColor to convert between the color spaces.
/// This model supports updating.
/// </summary>
// ReSharper disable once InconsistentNaming
public class LBPHFaceRecognizer : FaceRecognizer
{
    /// <summary>
    ///
    /// </summary>
    private Ptr? recognizerPtr;

    #region Init & Disposal

    /// <summary>
    ///
    /// </summary>
    protected LBPHFaceRecognizer()
    {
        recognizerPtr = null;
        ptr = IntPtr.Zero;
    }
        
    /// <summary>
    /// Releases managed resources
    /// </summary>
    protected override void DisposeManaged()
    {
        recognizerPtr?.Dispose();
        recognizerPtr = null;
        base.DisposeManaged();
    }

    /// <summary>
    /// The Circular Local Binary Patterns (used in training and prediction) expect the data given as
    /// grayscale images, use cvtColor to convert between the color spaces.
    /// This model supports updating.
    /// </summary>
    /// <param name="radius">The radius used for building the Circular Local Binary Pattern. The greater the radius, the</param>
    /// <param name="neighbors">The number of sample points to build a Circular Local Binary Pattern from. 
    /// An appropriate value is to use `8` sample points.Keep in mind: the more sample points you include, the higher the computational cost.</param>
    /// <param name="gridX">The number of cells in the horizontal direction, 8 is a common value used in publications. 
    /// The more cells, the finer the grid, the higher the dimensionality of the resulting feature vector.</param>
    /// <param name="gridY">The number of cells in the vertical direction, 8 is a common value used in publications. 
    /// The more cells, the finer the grid, the higher the dimensionality of the resulting feature vector.</param>
    /// <param name="threshold">The threshold applied in the prediction. If the distance to the nearest neighbor 
    /// is larger than the threshold, this method returns -1.</param>
    /// <returns></returns>
    // ReSharper disable once InconsistentNaming
    public static LBPHFaceRecognizer Create(int radius = 1, int neighbors = 8,
        int gridX = 8, int gridY = 8, double threshold = double.MaxValue)
    {
        NativeMethods.HandleException(
            NativeMethods.face_LBPHFaceRecognizer_create(radius, neighbors, gridX, gridY, threshold, out var p));
        if (p == IntPtr.Zero)
            throw new OpenCvSharpException($"Invalid cv::Ptr<{nameof(LBPHFaceRecognizer)}> pointer");
        var ptrObj = new Ptr(p);
        var detector = new LBPHFaceRecognizer
        {
            recognizerPtr = ptrObj,
            ptr = ptrObj.Get()
        };
        return detector;
    }

    #endregion

    #region Methods

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public virtual int GetGridX()
    {
        ThrowIfDisposed();
        NativeMethods.HandleException(
            NativeMethods.face_LBPHFaceRecognizer_getGridX(ptr, out var ret));
        GC.KeepAlive(this);
        return ret;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="val"></param>
    public virtual void SetGridX(int val)
    {
        ThrowIfDisposed();
        NativeMethods.HandleException(
            NativeMethods.face_LBPHFaceRecognizer_setGridX(ptr, val));
        GC.KeepAlive(this);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public virtual int GetGridY()
    {
        ThrowIfDisposed();
        NativeMethods.HandleException(
            NativeMethods.face_LBPHFaceRecognizer_getGridY(ptr, out var ret));
        GC.KeepAlive(this);
        return ret;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="val"></param>
    public virtual void SetGridY(int val)
    {
        ThrowIfDisposed();
        NativeMethods.HandleException(
            NativeMethods.face_LBPHFaceRecognizer_setGridY(ptr, val));
        GC.KeepAlive(this);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public virtual int GetRadius()
    {
        ThrowIfDisposed();
        NativeMethods.HandleException(
            NativeMethods.face_LBPHFaceRecognizer_getRadius(ptr, out var ret));
        GC.KeepAlive(this);
        return ret;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="val"></param>
    public virtual void SetRadius(int val)
    {
        ThrowIfDisposed();
        NativeMethods.HandleException(
            NativeMethods.face_LBPHFaceRecognizer_setRadius(ptr, val));
        GC.KeepAlive(this);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public virtual int GetNeighbors()
    {
        ThrowIfDisposed();
        NativeMethods.HandleException(
            NativeMethods.face_LBPHFaceRecognizer_getNeighbors(ptr, out var ret));
        GC.KeepAlive(this);
        return ret;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="val"></param>
    public virtual void SetNeighbors(int val)
    {
        ThrowIfDisposed();
        NativeMethods.HandleException(
            NativeMethods.face_LBPHFaceRecognizer_setNeighbors(ptr, val));
        GC.KeepAlive(this);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public new virtual double GetThreshold()
    {
        ThrowIfDisposed();
        NativeMethods.HandleException(
            NativeMethods.face_LBPHFaceRecognizer_getThreshold(ptr, out var ret));
        GC.KeepAlive(this);
        return ret;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="val"></param>
    public new virtual void SetThreshold(double val)
    {
        ThrowIfDisposed();
        NativeMethods.HandleException(
            NativeMethods.face_LBPHFaceRecognizer_setThreshold(ptr, val));
        GC.KeepAlive(this);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public virtual Mat[] GetHistograms()
    {
        ThrowIfDisposed();
        using var resultVector = new VectorOfMat();
        NativeMethods.HandleException(
            NativeMethods.face_LBPHFaceRecognizer_getHistograms(ptr, resultVector.CvPtr));
        GC.KeepAlive(this);
        return resultVector.ToArray();
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public virtual Mat GetLabels()
    {
        ThrowIfDisposed();
        var result = new Mat();
        NativeMethods.HandleException(
            NativeMethods.face_LBPHFaceRecognizer_getLabels(ptr, result.CvPtr));
        GC.KeepAlive(this);
        return result;
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
                NativeMethods.face_Ptr_LBPHFaceRecognizer_get(ptr, out var ret));
            GC.KeepAlive(this);
            return ret;
        }

        protected override void DisposeUnmanaged()
        {
            NativeMethods.HandleException(
                NativeMethods.face_Ptr_LBPHFaceRecognizer_delete(ptr));
            base.DisposeUnmanaged();
        }
    }
}
