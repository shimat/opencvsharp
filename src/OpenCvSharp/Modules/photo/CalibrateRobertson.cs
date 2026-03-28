using OpenCvSharp.Internal;

namespace OpenCvSharp;

/// <summary>
/// CalibrateRobertson object
/// </summary>
public class CalibrateRobertson : CalibrateCRF
{
    /// <summary>
    /// Creates instance by raw pointer cv::CalibrateRobertson*
    /// </summary>
    private CalibrateRobertson(IntPtr smartPtr, IntPtr rawPtr)
        : base(smartPtr, rawPtr, p => NativeMethods.HandleException(NativeMethods.photo_Ptr_CalibrateRobertson_delete(p)))
    { }

    /// <summary>
    /// Creates CalibrateRobertson object
    /// </summary>
    /// <param name="maxIter">maximal number of Gauss-Seidel solver iterations.</param>
    /// <param name="threshold">target difference between results of two successive steps of the minimization.</param>
    /// <returns></returns>
    public static CalibrateRobertson Create(int maxIter = 30, float threshold = 0.01f)
    {
        NativeMethods.HandleException(
            NativeMethods.photo_createCalibrateRobertson(maxIter, threshold, out var smartPtr));
        NativeMethods.HandleException(NativeMethods.photo_Ptr_CalibrateRobertson_get(smartPtr, out var rawPtr));
        return new CalibrateRobertson(smartPtr, rawPtr);
    }

    /// <summary>
    /// 
    /// </summary>
    public int MaxIter
    {
        get
        {
            NativeMethods.HandleException(
                NativeMethods.photo_CalibrateRobertson_getMaxIter(CvPtr, out var ret));
            return ret;
        }
        set =>
            NativeMethods.HandleException(
                NativeMethods.photo_CalibrateRobertson_setMaxIter(CvPtr, value));
    }

    /// <summary>
    /// 
    /// </summary>
    public float Threshold
    {
        get
        {
            NativeMethods.HandleException(
                NativeMethods.photo_CalibrateRobertson_getThreshold(CvPtr, out var ret));
            return ret;
        }
        set =>
            NativeMethods.HandleException(
                NativeMethods.photo_CalibrateRobertson_setThreshold(CvPtr, value));
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
                NativeMethods.photo_CalibrateRobertson_getRadiance(CvPtr, ret.CvPtr));
            return ret;
        }
    }
}
