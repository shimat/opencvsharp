using System.Runtime.InteropServices;

#pragma warning disable CA1051

namespace OpenCvSharp;

/// <summary>
///
/// </summary>
[Serializable]
[StructLayout(LayoutKind.Sequential)]
public record struct Size2d(double Width, double Height)
{
    /// <summary>
    ///
    /// </summary>
    public double Width = Width;

    /// <summary>
    ///
    /// </summary>
    public double Height = Height;
    
#pragma warning disable CA2225
    /// <summary> 
    /// </summary>
    /// <param name="size"></param>
    public static implicit operator Size2d(Size size) 
        => new(size.Width, size.Height);

    /// <summary> 
    /// </summary>
    /// <param name="size"></param>
    public static implicit operator Size2d(Size2f size) 
        => new(size.Width, size.Height);
#pragma warning restore CA2225

    /// <summary> 
    /// </summary>
    /// <returns></returns>
    public readonly Size ToSize() => new (Width, Height);

    /// <summary> 
    /// </summary>
    /// <returns></returns>
    // ReSharper disable once InconsistentNaming
    public readonly Size2f ToSize2f() => new (Width, Height);
}
