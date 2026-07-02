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
        : this(Create(fileName))
    {
    }

    private SavedIndexParams((IntPtr smartPtr, IntPtr rawPtr) ptrs)
        : base(ptrs.smartPtr, ptrs.rawPtr,
            static h => NativeMethods.HandleException(NativeMethods.flann_Ptr_SavedIndexParams_delete(h)))
    {
    }

    private static (IntPtr smartPtr, IntPtr rawPtr) Create(string fileName)
    {
        if (string.IsNullOrEmpty(fileName))
            throw new ArgumentNullException(nameof(fileName));
        NativeMethods.HandleException(
            NativeMethods.flann_Ptr_SavedIndexParams_new(fileName, out var smartPtr));
        if (smartPtr == IntPtr.Zero)
            throw new OpenCvSharpException($"Failed to create {nameof(SavedIndexParams)}");
        NativeMethods.HandleException(
            NativeMethods.flann_Ptr_SavedIndexParams_get(smartPtr, out var rawPtr));
        return (smartPtr, rawPtr);
    }
}
