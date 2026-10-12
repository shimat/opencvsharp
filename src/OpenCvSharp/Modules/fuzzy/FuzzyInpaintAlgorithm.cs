namespace OpenCvSharp;

/// <summary>Fuzzy transform inpainting strategy.</summary>
public enum FuzzyInpaintAlgorithm
{
    /// <summary>Fill the masked area in one pass.</summary>
    OneStep = 1,
    /// <summary>Increase the kernel radius until all masked pixels are filled.</summary>
    MultiStep = 2,
    /// <summary>Refine the result over multiple iterations.</summary>
    Iterative = 3,
}
