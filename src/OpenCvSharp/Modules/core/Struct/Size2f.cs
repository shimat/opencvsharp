using System.Runtime.InteropServices;

#pragma warning disable CA1051

namespace OpenCvSharp;

/// <summary>
///
/// </summary>
[Serializable]
[StructLayout(LayoutKind.Sequential)]
// ReSharper disable once InconsistentNaming
public record struct Size2f(float Width, float Height)
{
    /// <summary>
    ///
    /// </summary>
    public float Width = Width;

    /// <summary>
    ///
    /// </summary>
    public float Height = Height;
    
    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="width"></param>
    /// <param name="height"></param>
    public Size2f(double width, double height)
        : this((float)width, (float)height)
    {
    }
    
#pragma warning disable CA2225
    /// <summary> 
    /// </summary>
    /// <param name="size"></param>
    public static implicit operator Size2f(Size size) 
        => new(size.Width, size.Height);

    /// <summary> 
    /// </summary>
    /// <param name="size"></param>
    public static explicit operator Size2f(Size2d size) 
        => new(size.Width, size.Height);
#pragma warning restore CA2225
    
    /// <summary> 
    /// </summary>
    /// <returns></returns>
    public readonly Size ToSize() => new (Width, Height);

    /// <summary> 
    /// </summary>
    /// <returns></returns>
    public readonly Size2d ToSize2d() => new (Width, Height);
}
