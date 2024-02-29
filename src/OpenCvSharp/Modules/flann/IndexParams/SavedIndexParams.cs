using OpenCvSharp.Internal;

namespace OpenCvSharp.Flann;

/// <summary>
/// This object type is used for loading a previously saved index from the disk.
/// </summary>
public class SavedIndexParams : IndexParams
{
    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="fileName"></param>
    public SavedIndexParams(string fileName)
        : base(null)
    {
        if (string.IsNullOrEmpty(fileName))
            throw new ArgumentNullException(nameof(fileName));

        NativeMethods.HandleException(
            NativeMethods.flann_Ptr_SavedIndexParams_new(fileName, out var p));
        if (p == IntPtr.Zero)
            throw new OpenCvSharpException($"Failed to create {nameof(SavedIndexParams)}");

        PtrObj = new Ptr(p);
        ptr = PtrObj.Get();
    }

    /// <summary>
    /// 
    /// </summary>
    protected SavedIndexParams(OpenCvSharp.Ptr ptrObj)
        : base(ptrObj)
    {
    }

    internal new class Ptr : OpenCvSharp.Ptr
    {
        public Ptr(IntPtr ptr) : base(ptr)
        {
        }

        public override IntPtr Get()
        {
            NativeMethods.HandleException( 
                NativeMethods.flann_Ptr_SavedIndexParams_get(ptr, out var ret));
            GC.KeepAlive(this);
            return ret;
        }

        protected override void DisposeUnmanaged()
        {
            NativeMethods.HandleException(
                NativeMethods.flann_Ptr_SavedIndexParams_delete(ptr));
            base.DisposeUnmanaged();
        }
    }
}
