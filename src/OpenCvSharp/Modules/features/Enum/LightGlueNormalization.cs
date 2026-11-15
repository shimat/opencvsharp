namespace OpenCvSharp;

/// <summary>Normalization applied to pixel keypoints by <see cref="LightGlueMatcher"/>.</summary>
public enum LightGlueNormalization
{
    /// <summary>Scales each axis according to the model variant.</summary>
    Model = 0,

    /// <summary>Centers the coordinates and scales both axes by half the longer image side.</summary>
    MaxSide = 1
}
