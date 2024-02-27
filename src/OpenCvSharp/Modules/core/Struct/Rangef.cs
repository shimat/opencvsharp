using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;

namespace OpenCvSharp;

/// <summary>
/// float Range class
/// </summary>
[Serializable]
[StructLayout(LayoutKind.Sequential)]
[SuppressMessage("Design", "CA1051: Do not declare visible instance fields")]
// ReSharper disable once IdentifierTypo
public readonly record struct Rangef(float Start, float End)
{
    /// <summary>
    /// 
    /// </summary>
    public readonly float Start = Start;

    /// <summary>
    /// 
    /// </summary>
    public readonly float End = End;

    /// <summary>
    /// Convert to Range
    /// </summary>
    /// <returns></returns>
    public Range ToRange() => new ((int)Start, (int)End);

    /// <summary>
    /// Implicit operator (Range)this
    /// </summary>
    /// <param name="range"></param>
    /// <returns></returns>
    public static implicit operator Range(Rangef range) => new ((int)range.Start, (int)range.End);

    /// <summary>
    /// Range(int.MinValue, int.MaxValue)
    /// </summary>
    public static Range All => new (int.MinValue, int.MaxValue);
}
