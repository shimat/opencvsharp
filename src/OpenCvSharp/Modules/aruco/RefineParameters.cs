using System.Runtime.InteropServices;

namespace OpenCvSharp.Aruco;

#pragma warning disable CA1815

/// <summary>
/// struct RefineParameters is used by ArucoDetector
/// </summary>
[StructLayout(LayoutKind.Sequential)]
public struct RefineParameters
{
    /// <summary>
    /// Minimum distance between the corners of the rejected candidate and the reprojected marker
    /// in order to consider it as a correspondence (default 10).
    /// </summary>
    public float MinRepDistance = 10f;

    /// <summary>
    /// Rate of allowed erroneous bits respect to the error correction capability of the used dictionary.
    /// -1 ignores the error correction step (default 3).
    /// </summary>
    public float ErrorCorrectionRate = 3f;

    /// <summary>
    /// Consider the four possible corner orders in the rejectedCorners array (default true).
    /// </summary>
    [MarshalAs(UnmanagedType.U1)]
    public bool CheckAllOrders = true;

    /// <summary>
    /// Constructor
    /// </summary>
    public RefineParameters()
    {
    }

    /// <summary>
    /// Constructor
    /// </summary>
    public RefineParameters(float minRepDistance, float errorCorrectionRate, bool checkAllOrders)
    {
        MinRepDistance = minRepDistance;
        ErrorCorrectionRate = errorCorrectionRate;
        CheckAllOrders = checkAllOrders;
    }
}
