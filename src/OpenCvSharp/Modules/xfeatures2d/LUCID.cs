using OpenCvSharp.Internal;

namespace OpenCvSharp.XFeatures2D;

/// <summary>
/// Class implementing the locally uniform comparison image descriptor, described in @cite LUCID.
/// 
/// An image descriptor that can be computed very fast, while being 
/// about as robust as, for example, SURF or BRIEF.
/// @note It requires a color image as input.
/// </summary>
// ReSharper disable once InconsistentNaming
public class LUCID : Feature2D
{
    private Ptr? ptrObj;

    /// <summary>
    /// 
    /// </summary>
    internal LUCID(IntPtr p)
    {
        ptrObj = new Ptr(p);
        ptr = ptrObj.Get();
    }

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="lucidKernel">kernel for descriptor construction, where 1=3x3, 2=5x5, 3=7x7 and so forth</param>
    /// <param name="blurKernel">kernel for blurring image prior to descriptor construction, where 1=3x3, 2=5x5, 3=7x7 and so forth</param>
    public static LUCID Create(int lucidKernel = 1, int blurKernel = 2)
    {
        NativeMethods.HandleException(
            NativeMethods.xfeatures2d_LUCID_create(
                lucidKernel, blurKernel, out var ptr));
        return new LUCID(ptr);
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

    internal class Ptr : OpenCvSharp.Ptr
    {
        public Ptr(IntPtr ptr) : base(ptr)
        {
        }

        public override IntPtr Get()
        {
            NativeMethods.HandleException(
                NativeMethods.xfeatures2d_Ptr_LUCID_get(ptr, out var ret));
            GC.KeepAlive(this);
            return ret;
        }

        protected override void DisposeUnmanaged()
        {
            NativeMethods.HandleException(
                NativeMethods.xfeatures2d_Ptr_LUCID_delete(ptr));
            base.DisposeUnmanaged();
        }
    }
}
