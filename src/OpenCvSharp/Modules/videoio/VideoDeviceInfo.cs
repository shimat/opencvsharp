namespace OpenCvSharp;

/// <summary>
/// A camera device reported by a Video I/O backend.
/// </summary>
/// <param name="Index">The index to use with the reporting backend when opening the device.</param>
/// <param name="Name">The device name reported by the backend, or an index-based name if unavailable.</param>
/// <param name="Backend">The backend that reported the device.</param>
public sealed record VideoDeviceInfo(int Index, string Name, VideoCaptureAPIs Backend);
