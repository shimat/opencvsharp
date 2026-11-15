namespace OpenCvSharp;

/// <summary>Render modes for the primitives drawn by <see cref="Viz3d"/>.</summary>
public enum Viz3dRenderMode
{
    /// <summary>Draws solid faces without lighting.</summary>
    Simple = 0,

    /// <summary>Draws solid faces with lighting.</summary>
    Shading = 1,

    /// <summary>Draws only the edges of each primitive.</summary>
    Wireframe = 2,
}
