namespace OpenCvSharp;

/// <summary>Column offsets and row width for a decoded CV_32F Gaussian splat scene.</summary>
public enum GaussianSplatLayout
{
    /// <summary>Number of columns per splat.</summary>
    Stride = 13,

    /// <summary>Start of the three position coordinates.</summary>
    Position = 0,

    /// <summary>Start of the six upper-triangular covariance elements.</summary>
    Covariance = 3,

    /// <summary>Start of the three RGB channels.</summary>
    Color = 9,

    /// <summary>Opacity column.</summary>
    Alpha = 12,
}
