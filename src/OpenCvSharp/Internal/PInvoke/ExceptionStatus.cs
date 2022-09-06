namespace OpenCvSharp.Internal;

/// <summary>
/// Whether native methods for P/Invoke raises an exception
/// </summary>
public enum ExceptionStatus
{
#pragma warning disable 1591
    NotOccurred = 0, 
    Occurred = 1
}
