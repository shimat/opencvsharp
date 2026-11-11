namespace OpenCvSharp;

/// <summary>
/// Encoder presets for <see cref="VideoWriterProperties.Preset"/>, ordered from fastest
/// encoding to highest compression efficiency.
/// </summary>
public enum VideoWriterPresets
{
    /// <summary>Fastest encoding and lowest compression efficiency.</summary>
    UltraFast = 0,

    /// <summary>Superfast encoding preset.</summary>
    SuperFast = 1,

    /// <summary>Very fast encoding preset.</summary>
    VeryFast = 2,

    /// <summary>Faster encoding preset.</summary>
    Faster = 3,

    /// <summary>Fast encoding preset.</summary>
    Fast = 4,

    /// <summary>Default encoder preset.</summary>
    Medium = 5,

    /// <summary>Slow encoding preset.</summary>
    Slow = 6,

    /// <summary>Slower encoding preset.</summary>
    Slower = 7,

    /// <summary>Very slow encoding preset.</summary>
    VerySlow = 8,

    /// <summary>Slowest encoding and highest compression efficiency.</summary>
    Placebo = 9
}
