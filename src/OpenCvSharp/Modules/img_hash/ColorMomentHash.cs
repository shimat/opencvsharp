using OpenCvSharp.Internal;

namespace OpenCvSharp.ImgHash;

/// <inheritdoc />
/// <summary>
/// Image hash based on color moments.
/// </summary>
public class ColorMomentHash : ImgHashBase
{
    /// <summary>
    /// cv::Ptr&lt;T&gt;
    /// </summary>
    private Ptr? ptrObj;

    /// <summary>
    /// 
    /// </summary>
    protected ColorMomentHash(IntPtr p)
    {
        ptrObj = new Ptr(p);
        SetSafeHandle(new OpenCvPtrSafeHandle(ptrObj.Get(), ownsHandle: false, releaseAction: null));
    }

    /// <summary>
    /// Constructor
    /// </summary>
    /// <returns></returns>
    public static ColorMomentHash Create()
    {
        NativeMethods.HandleException(
            NativeMethods.img_hash_ColorMomentHash_create(out var p));
        return new ColorMomentHash(p);
    }
        
    /// <inheritdoc />
    /// <summary>
    /// Releases managed resources
    /// </summary>
    protected override void DisposeManaged()
    {
        ptrObj?.Dispose();
        ptrObj = null;
        base.DisposeManaged();
    }

    // ReSharper disable once RedundantOverriddenMember
    /// <inheritdoc />
    public override void Compute(InputArray inputArr, OutputArray outputArr)
    {
        base.Compute(inputArr, outputArr);
    }

    internal sealed class Ptr(IntPtr ptr) : OpenCvSharp.Ptr(ptr, static h => NativeMethods.HandleException(NativeMethods.img_hash_Ptr_ColorMomentHash_delete(h)))
    {
        public override IntPtr Get()
        {
            NativeMethods.HandleException(
                NativeMethods.img_hash_Ptr_ColorMomentHash_get(ptr, out var ret));
            GC.KeepAlive(this);
            return ret;
        }
    }
}
