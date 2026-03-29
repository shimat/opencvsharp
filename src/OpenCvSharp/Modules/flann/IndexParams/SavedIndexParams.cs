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
        : base(Create(fileName), static h => NativeMethods.flann_Ptr_SavedIndexParams_delete(h))
    {
    }

    private static IntPtr Create(string fileName)
    {
        if (string.IsNullOrEmpty(fileName))
            throw new ArgumentNullException(nameof(fileName));
        NativeMethods.HandleException(
            NativeMethods.flann_Ptr_SavedIndexParams_new(fileName, out var p));
        if (p == IntPtr.Zero)
            throw new OpenCvSharpException($"Failed to create {nameof(SavedIndexParams)}");
        return p;
    }
}
