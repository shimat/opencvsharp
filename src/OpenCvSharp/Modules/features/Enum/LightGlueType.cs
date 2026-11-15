namespace OpenCvSharp;

/// <summary>The ONNX model variant used by <see cref="LightGlueMatcher"/>.</summary>
public enum LightGlueType
{
    /// <summary>ALIKED model with keypoints normalized to [-1, 1].</summary>
    Aliked = 0,

    /// <summary>DISK model with keypoints normalized to [0, 1].</summary>
    Disk = 1
}
