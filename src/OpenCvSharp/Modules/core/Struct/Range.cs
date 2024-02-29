using System.Runtime.InteropServices;

#pragma warning disable CA1051

namespace OpenCvSharp;

/// <summary>
/// Template class specifying a continuous subsequence (slice) of a sequence.
/// </summary>
[Serializable]
[StructLayout(LayoutKind.Sequential)]
public readonly record struct Range(int Start, int End)
{
    /// <summary>
    /// 
    /// </summary>
    public readonly int Start = Start;

    /// <summary>
    /// 
    /// </summary>
    public readonly int End = End;

    /// <summary>
    /// 
    /// </summary>
    public static Range All => new Range(int.MinValue, int.MaxValue);
}
