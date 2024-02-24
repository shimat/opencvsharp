using OpenCvSharp.Internal;

namespace OpenCvSharp;

/// <summary>
/// CalibrateDebevec object
/// </summary>
public class CalibrateDebevec : CalibrateCRF
{
    private Ptr? ptrObj;

    /// <summary>
    /// Creates instance by raw pointer cv::CalibrateDebevec*
    /// </summary>
    protected CalibrateDebevec(IntPtr p)
    {
        ptrObj = new Ptr(p);
        ptr = ptrObj.Get();
    }

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
            NativeMethods.photo_createCalibrateDebevec(samples, lambda, random ? 1 : 0, out var ptr));
        return new CalibrateDebevec(ptr);
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
    public float Lambda
    {
        get
        {
            NativeMethods.HandleException(
                NativeMethods.photo_CalibrateDebevec_getLambda(ptr, out var ret));
            return ret;
        }
        set
        {
            NativeMethods.HandleException(
                NativeMethods.photo_CalibrateDebevec_setLambda(ptr, value));
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public float Samples
    {
        get
        {
            NativeMethods.HandleException(
                NativeMethods.photo_CalibrateDebevec_getSamples(ptr, out var ret));
            return ret;
        }
        set
        {
            NativeMethods.HandleException(
                NativeMethods.photo_CalibrateDebevec_setSamples(ptr, value));
        }
    }
        
    /// <summary>
    /// 
    /// </summary>
    public bool Random
    {
        get
        {
            NativeMethods.HandleException(
                NativeMethods.photo_CalibrateDebevec_getRandom(ptr, out var ret));
            return ret != 0;
        }
        set
        {
            NativeMethods.HandleException(
                NativeMethods.photo_CalibrateDebevec_setRandom(ptr, value ? 1 : 0));
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
                NativeMethods.photo_Ptr_CalibrateDebevec_get(ptr, out var ret));
            GC.KeepAlive(this);
            return ret;
        }

        protected override void DisposeUnmanaged()
        {
            NativeMethods.HandleException(
                NativeMethods.photo_Ptr_CalibrateDebevec_delete(ptr));
            base.DisposeUnmanaged();
        }
    }
}
