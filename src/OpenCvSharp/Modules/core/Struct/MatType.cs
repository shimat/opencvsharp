namespace OpenCvSharp;
// ReSharper disable InconsistentNaming
#pragma warning disable 1591

/// <summary>
/// Matrix data type (depth and number of channels)
/// </summary>
public readonly record struct MatType(int value) : IEquatable<int>
{
    /// <summary>
    /// Entity value
    /// </summary>
    private readonly int value = value;

    /// <summary>
    /// Entity value
    /// </summary>
    public int Value => value;

    /// <summary> 
    /// </summary>
    /// <param name="self"></param>
    /// <returns></returns>
    public static explicit operator int(MatType self)
    {
        return self.value;
    }

    /// <summary> 
    /// </summary>
    /// <returns></returns>
    public int ToInt32() => value;

    /// <summary> 
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public static implicit operator MatType(int value)
    {
        return new MatType(value);
    }

    /// <summary> 
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public static MatType FromInt32(int value)
    {
        return new MatType(value);
    }

    /// <summary>
    /// 
    /// </summary>
    public int Depth => value & (CV_DEPTH_MAX - 1);

    /// <summary>
    /// 
    /// </summary>
    public bool IsInteger => Depth < CV_32F;

    /// <summary>
    /// 
    /// </summary>
    public int Channels => (Value >> CV_CN_SHIFT) + 1;

    public bool Equals(int other)
    {
        return value == other;
    }

    public static bool operator ==(MatType self, int other)
    {
        return self.Equals(other);
    }

    public static bool operator !=(MatType self, int other)
    {
        return !self.Equals(other);
    }

    /// <inheritdoc />
    public override string ToString()
    {
        string s;
        switch (Depth)
        {
            case CV_8U:
                s = "CV_8U";
                break;
            case CV_8S:
                s = "CV_8S";
                break;
            case CV_16U:
                s = "CV_16U";
                break;
            case CV_16S:
                s = "CV_16S";
                break;
            case CV_32S:
                s = "CV_32S";
                break;
            case CV_32F:
                s = "CV_32F";
                break;
            case CV_64F:
                s = "CV_64F";
                break;
            case CV_USRTYPE1:
                s = "CV_USRTYPE1";
                break;
            default:
                return $"Unsupported type value ({Value})";
        }

        var ch = Channels;
        if (ch <= 4)
            return s + "C" + ch;
        else
            return s + "C(" + ch + ")";
    }

    private const int CV_CN_MAX = 512,
        CV_CN_SHIFT = 3,
        CV_DEPTH_MAX = (1 << CV_CN_SHIFT);

    /// <summary>
    /// type depth constants
    /// </summary>
    public const int
        CV_8U = 0,
        CV_8S = 1,
        CV_16U = 2,
        CV_16S = 3,
        CV_32S = 4,
        CV_32F = 5,
        CV_64F = 6,
        CV_USRTYPE1 = 7;

    /// <summary>
    /// predefined type constants
    /// </summary>
    public static readonly MatType
        CV_8UC1 = CV_8UC(1),
        CV_8UC2 = CV_8UC(2),
        CV_8UC3 = CV_8UC(3),
        CV_8UC4 = CV_8UC(4),
        CV_8SC1 = CV_8SC(1),
        CV_8SC2 = CV_8SC(2),
        CV_8SC3 = CV_8SC(3),
        CV_8SC4 = CV_8SC(4),
        CV_16UC1 = CV_16UC(1),
        CV_16UC2 = CV_16UC(2),
        CV_16UC3 = CV_16UC(3),
        CV_16UC4 = CV_16UC(4),
        CV_16SC1 = CV_16SC(1),
        CV_16SC2 = CV_16SC(2),
        CV_16SC3 = CV_16SC(3),
        CV_16SC4 = CV_16SC(4),
        CV_32SC1 = CV_32SC(1),
        CV_32SC2 = CV_32SC(2),
        CV_32SC3 = CV_32SC(3),
        CV_32SC4 = CV_32SC(4),
        CV_32FC1 = CV_32FC(1),
        CV_32FC2 = CV_32FC(2),
        CV_32FC3 = CV_32FC(3),
        CV_32FC4 = CV_32FC(4),
        CV_64FC1 = CV_64FC(1),
        CV_64FC2 = CV_64FC(2),
        CV_64FC3 = CV_64FC(3),
        CV_64FC4 = CV_64FC(4);
    /*
    public const int 
        CV_8UC1 = 0,
        CV_8SC1 = 1,
        CV_16UC1 = 2,
        CV_16SC1 = 3,
        CV_32SC1 = 4,
        CV_32FC1 = 5,
        CV_64FC1 = 6,
        CV_8UC2 = 8,
        CV_8SC2 = 9,
        CV_16UC2 = 10,
        CV_16SC2 = 11,
        CV_32SC2 = 12,
        CV_32FC2 = 13,
        CV_64FC2 = 14,
        CV_8UC3 = 16,
        CV_8SC3 = 17,
        CV_16UC3 = 18,
        CV_16SC3 = 19,
        CV_32SC3 = 20,
        CV_32FC3 = 21,
        CV_64FC3 = 22,
        CV_8UC4 = 24,
        CV_8SC4 = 25,
        CV_16UC4 = 26,
        CV_16SC4 = 27,
        CV_32SC4 = 28,
        CV_32FC4 = 29,
        CV_64FC4 = 30,
        CV_8UC5 = 32,
        CV_8SC5 = 33,
        CV_16UC5 = 34,
        CV_16SC5 = 35,
        CV_32SC5 = 36,
        CV_32FC5 = 37,
        CV_64FC5 = 38,
        CV_8UC6 = 40,
        CV_8SC6 = 41,
        CV_16UC6 = 42,
        CV_16SC6 = 43,
        CV_32SC6 = 44,
        CV_32FC6 = 45,
        CV_64FC6 = 46;
     */ 

    public static MatType CV_8UC(int ch)
    {
        return MakeType(CV_8U, ch);
    }

    public static MatType CV_8SC(int ch)
    {
        return MakeType(CV_8S, ch);
    }

    public static MatType CV_16UC(int ch)
    {
        return MakeType(CV_16U, ch);
    }

    public static MatType CV_16SC(int ch)
    {
        return MakeType(CV_16S, ch);
    }

    public static MatType CV_32SC(int ch)
    {
        return MakeType(CV_32S, ch);
    }

    public static MatType CV_32FC(int ch)
    {
        return MakeType(CV_32F, ch);
    }

    public static MatType CV_64FC(int ch)
    {
        return MakeType(CV_64F, ch);
    }

    public static MatType MakeType(int depth, int channels)
    {
        if (channels <= 0 || channels >= CV_CN_MAX)
            throw new OpenCvSharpException("Channels count should be 1.." + (CV_CN_MAX - 1));
        if (depth < 0 || depth >= CV_DEPTH_MAX)
            throw new OpenCvSharpException("Data type depth should be 0.." + (CV_DEPTH_MAX - 1));
        return (depth & (CV_DEPTH_MAX - 1)) + ((channels - 1) << CV_CN_SHIFT);
    }
}
