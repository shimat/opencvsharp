namespace OpenCvSharp;

/// <summary>
/// Represents a OpenCV-based class which has a native pointer. 
/// </summary>
public interface ICvPtrHolder
{
    /// <summary>
    /// Unmanaged OpenCV data pointer
    /// </summary>
    IntPtr CvPtr { get; }
}
