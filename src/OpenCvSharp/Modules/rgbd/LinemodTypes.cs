namespace OpenCvSharp.Rgbd;

/// <summary>A discriminant LINEMOD feature.</summary>
public readonly record struct LinemodFeature(int X, int Y, int Label);

/// <summary>A template at one pyramid level.</summary>
public sealed record LinemodTemplate(int Width, int Height, int PyramidLevel, LinemodFeature[] Features)
{
    /// <inheritdoc />
    public bool Equals(LinemodTemplate? other) =>
        other is not null &&
        Width == other.Width &&
        Height == other.Height &&
        PyramidLevel == other.PyramidLevel &&
        Features.AsSpan().SequenceEqual(other.Features);

    /// <inheritdoc />
    public override int GetHashCode()
    {
        var hash = new HashCode();
        hash.Add(Width);
        hash.Add(Height);
        hash.Add(PyramidLevel);
        foreach (var feature in Features)
            hash.Add(feature);
        return hash.ToHashCode();
    }
}

/// <summary>A successful LINEMOD template match.</summary>
public readonly record struct LinemodMatch(
    int X, int Y, float Similarity, string ClassId, int TemplateId);
