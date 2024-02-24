using OpenCvSharp.Internal;

namespace OpenCvSharp;

/// <summary>
/// CalibrateRobertson object
/// </summary>
public class CalibrateRobertson : CalibrateCRF
{
    private Ptr? ptrObj;

    /// <summary>
    /// Creates instance by raw pointer cv::CalibrateRobertson*
    /// </summary>
    protected CalibrateRobertson(IntPtr p)
    {
        ptrObj = new Ptr(p);
        ptr = ptrObj.Get();
    }

    /// <summary>
    /// Creates CalibrateRobertson object
    /// </summary>
    /// <param name="maxIter">maximal number of Gauss-Seidel solver iterations.</param>
    /// <param name="threshold">target difference between results of two successive steps of the minimization.</param>
    /// <returns></returns>
    public static CalibrateRobertson Create(int maxIter = 30, float threshold = 0.01f)
    {
        NativeMethods.HandleException(
            NativeMethods.photo_createCalibrateRobertson(maxIter, threshold, out var ptr));
        return new CalibrateRobertson(ptr);
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

    /// <summary>
    /// 
    /// </summary>
    public int MaxIter
    {
        get
        {
            NativeMethods.HandleException(
                NativeMethods.photo_CalibrateRobertson_getMaxIter(ptr, out var ret));
            return ret;
        }
        set
        {
            NativeMethods.HandleException(
                NativeMethods.photo_CalibrateRobertson_setMaxIter(ptr, value));
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public float Threshold
    {
        get
        {
            NativeMethods.HandleException(
                NativeMethods.photo_CalibrateRobertson_getThreshold(ptr, out var ret));
            return ret;
        }
        set
        {
            NativeMethods.HandleException(
                NativeMethods.photo_CalibrateRobertson_setThreshold(ptr, value));
        }
    }
        
    /// <summary>
    /// 
    /// </summary>
    public Mat Radiance
    {
        get
        {
            var ret = new Mat();
            NativeMethods.HandleException(
                NativeMethods.photo_CalibrateRobertson_getRadiance(ptr, ret.CvPtr));
            return ret;
        }
    }

    internal class Ptr : OpenCvSharp.Ptr
    {
        public Ptr(IntPtr ptr) : base(ptr)
        {
        }

        public override IntPtr Get()
        {
            NativeMethods.HandleException(
                NativeMethods.photo_Ptr_CalibrateRobertson_get(ptr, out var ret));
            GC.KeepAlive(this);
            return ret;
        }

        protected override void DisposeUnmanaged()
        {
            NativeMethods.HandleException(
                NativeMethods.photo_Ptr_CalibrateRobertson_delete(ptr));
            base.DisposeUnmanaged();
        }
    }
}
