namespace OpenCvSharp;

/// <summary>State of the monocular visual odometry pipeline.</summary>
public enum VisualOdometryState
{
    /// <summary>Waiting for the first frame.</summary>
    NotInitialized = 0,

    /// <summary>Initializing a map from two frames.</summary>
    Initializing = 1,

    /// <summary>Tracking the current pose against the map.</summary>
    Tracking = 2,
}
