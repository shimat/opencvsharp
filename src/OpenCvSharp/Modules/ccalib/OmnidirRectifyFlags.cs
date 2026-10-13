namespace OpenCvSharp;

/// <summary>Projection used to rectify an omnidirectional camera image.</summary>
public enum OmnidirRectifyFlags
{
    /// <summary>Perspective projection.</summary>
    Perspective = 1,
    /// <summary>Cylindrical projection.</summary>
    Cylindrical = 2,
    /// <summary>Longitude-latitude projection.</summary>
    LongitudeLatitude = 3,
    /// <summary>Stereographic projection.</summary>
    Stereographic = 4,
}
