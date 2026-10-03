namespace OpenCvSharp;

/// <summary>Triangle shading mode.</summary>
public enum TriangleShadingType
{
    /// <summary>White triangle.</summary>
    White = 0,
    /// <summary>First vertex color.</summary>
    Flat = 1,
    /// <summary>Interpolated vertex colors.</summary>
    Shaded = 2,
}

/// <summary>Triangle face culling mode.</summary>
public enum TriangleCullingMode
{
    /// <summary>Draw all faces.</summary>
    None = 0,
    /// <summary>Draw clockwise faces.</summary>
    Clockwise = 1,
    /// <summary>Draw counterclockwise faces.</summary>
    Counterclockwise = 2,
}

/// <summary>OpenGL depth compatibility mode.</summary>
public enum TriangleGlCompatibleMode
{
    /// <summary>Use natural color and depth values.</summary>
    Disabled = 0,
    /// <summary>Store inverse depth in the OpenGL range.</summary>
    InverseDepth = 1,
}

/// <summary>Settings for point-cloud triangle rasterization.</summary>
public readonly record struct TriangleRasterizeSettings(
    TriangleShadingType ShadingType = TriangleShadingType.Shaded,
    TriangleCullingMode CullingMode = TriangleCullingMode.Clockwise,
    TriangleGlCompatibleMode GlCompatibleMode = TriangleGlCompatibleMode.Disabled)
{
    /// <summary>Initializes OpenCV's rasterization defaults. The default expression zero-initializes the fields instead.</summary>
    public TriangleRasterizeSettings()
        : this(TriangleShadingType.Shaded, TriangleCullingMode.Clockwise, TriangleGlCompatibleMode.Disabled)
    {
    }

    /// <summary>OpenCV's default rasterization settings.</summary>
    public static TriangleRasterizeSettings Default => new(
        TriangleShadingType.Shaded, TriangleCullingMode.Clockwise, TriangleGlCompatibleMode.Disabled);
}
