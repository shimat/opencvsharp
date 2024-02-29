using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;

namespace OpenCvSharp;

/// <summary>
///
/// </summary>
[Serializable]
[StructLayout(LayoutKind.Sequential)]
[SuppressMessage("Design", "CA1051: Do not declare visible instance fields")]
public record struct Size(int Width, int Height)
{
    /// <summary>
    ///
    /// </summary>
    public int Width = Width;

    /// <summary>
    ///
    /// </summary>
    public int Height = Height;
    
    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="width"></param>
    /// <param name="height"></param>
    public Size(double width, double height)
        : this((int)width, (int)height)
    {
    }
    
#pragma warning disable CA2225
    /// <summary> 
    /// </summary>
    /// <param name="size"></param>
    public static explicit operator Size(Size2d size) 
        => new(size.Width, size.Height);

    /// <summary> 
    /// </summary>
    /// <param name="size"></param>
    public static explicit operator Size(Size2f size) 
        => new(size.Width, size.Height);
#pragma warning restore CA2225
}
