namespace OpenCvSharp.Rgbd;

/// <summary>A discriminant LINEMOD feature.</summary>
public readonly record struct LinemodFeature(int X, int Y, int Label);

/// <summary>A template at one pyramid level.</summary>
public sealed record LinemodTemplate(int Width, int Height, int PyramidLevel, LinemodFeature[] Features);

/// <summary>A successful LINEMOD template match.</summary>
public readonly record struct LinemodMatch(
    int X, int Y, float Similarity, string ClassId, int TemplateId);
