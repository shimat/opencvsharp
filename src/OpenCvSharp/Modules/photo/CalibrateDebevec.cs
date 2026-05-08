using OpenCvSharp.Internal;

namespace OpenCvSharp;

/// <summary>
/// CalibrateDebevec object
/// </summary>
public class CalibrateDebevec : CalibrateCRF
{
    /// <summary>
    /// Creates instance by raw pointer cv::CalibrateDebevec*
    /// </summary>
    private CalibrateDebevec(IntPtr smartPtr, IntPtr rawPtr)
        : base(smartPtr, rawPtr, p => NativeMethods.HandleException(NativeMethods.photo_Ptr_CalibrateDebevec_delete(p)))
    { }

    /// <summary>
    /// Creates the empty model.
    /// </summary>
    /// <param name="samples">number of pixel locations to use</param>
    /// <param name="lambda">smoothness term weight. Greater values produce smoother results, 
    /// but can alter the response.</param>
    /// <param name="random">if true sample pixel locations are chosen at random, 
    /// otherwise the form a rectangular grid.</param>
    /// <returns></returns>
    public static CalibrateDebevec Create(int samples = 70, float lambda = 10.0f, bool random = false)
    {
        NativeMethods.HandleException(
            NativeMethods.photo_createCalibrateDebevec(samples, lambda, random ? 1 : 0, out var smartPtr));
        NativeMethods.HandleException(NativeMethods.photo_Ptr_CalibrateDebevec_get(smartPtr, out var rawPtr));
        return new CalibrateDebevec(smartPtr, rawPtr);
    }
  
    /// <summary>
    /// 
    /// </summary>
    public float Lambda
    {
        get
        {
            NativeMethods.HandleException(
                NativeMethods.photo_CalibrateDebevec_getLambda(RawPtr, out var ret));
            return ret;
        }
        set =>
            NativeMethods.HandleException(
                NativeMethods.photo_CalibrateDebevec_setLambda(RawPtr, value));
    }

    /// <summary>
    /// 
    /// </summary>
    public float Samples
    {
        get
        {
            NativeMethods.HandleException(
                NativeMethods.photo_CalibrateDebevec_getSamples(RawPtr, out var ret));
            return ret;
        }
        set =>
            NativeMethods.HandleException(
                NativeMethods.photo_CalibrateDebevec_setSamples(RawPtr, value));
    }
        
    /// <summary>
    /// 
    /// </summary>
    public bool Random
    {
        get
        {
            NativeMethods.HandleException(
                NativeMethods.photo_CalibrateDebevec_getRandom(RawPtr, out var ret));
            return ret != 0;
        }
        set =>
            NativeMethods.HandleException(
                NativeMethods.photo_CalibrateDebevec_setRandom(RawPtr, value ? 1 : 0));
    }
}
