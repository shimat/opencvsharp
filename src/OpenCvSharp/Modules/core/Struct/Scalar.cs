using System.Runtime.InteropServices;
using System.Security.Cryptography;

#pragma warning disable CA1051

namespace OpenCvSharp;

/// <summary>
/// Template class for a 4-element vector derived from Vec.
/// </summary>
[Serializable]
[StructLayout(LayoutKind.Sequential)]
public record struct Scalar(double Val0, double Val1, double Val2, double Val3)
{
    #region Field

    /// <summary>
    /// 
    /// </summary>
    public double Val0 = Val0;

    /// <summary>
    /// 
    /// </summary>
    public double Val1 = Val1;

    /// <summary>
    /// 
    /// </summary>
    public double Val2 = Val2;

    /// <summary>
    /// 
    /// </summary>
    public double Val3 = Val3;

    /// <summary>
    /// 
    /// </summary>
    public double this[int i]
    {
        get
        {
            return i switch
            {
                0 => Val0,
                1 => Val1,
                2 => Val2,
                3 => Val3,
                _ => throw new ArgumentOutOfRangeException(nameof(i)),
            };
        }
        set
        {
            switch (i)
            {
                case 0:
                    Val0 = value;
                    break;
                case 1:
                    Val1 = value;
                    break;
                case 2:
                    Val2 = value;
                    break;
                case 3:
                    Val3 = value;
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(i));
            }
        }
    }

    #endregion

    #region Init

    /// <summary>
    /// 
    /// </summary>
    /// <param name="val0"></param>
    public Scalar(double val0)
        : this(val0, 0, 0, 0)
    {
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="val0"></param>
    /// <param name="val1"></param>
    public Scalar(double val0, double val1)
        : this(val0, val1, 0, 0)
    {
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="val0"></param>
    /// <param name="val1"></param>
    /// <param name="val2"></param>
    public Scalar(double val0, double val1, double val2)
        : this(val0, val1, val2, 0)
    {
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="r"></param>
    /// <param name="g"></param>
    /// <param name="b"></param>
    public static Scalar FromRgb(int r, int g, int b)
    {
        return new(b, g, r);
    }

    /// <summary>
    /// Gets random color
    /// </summary>
    public static Scalar RandomColor() => RandomColor(defaultRng);

    /// <summary>
    /// Gets random color
    /// </summary>
    /// <param name="rng">.NET random number generator. This method uses Random.NextBytes()</param>
    public static Scalar RandomColor(RandomNumberGenerator rng)
    {
        if (rng is null) 
            throw new ArgumentNullException(nameof(rng));

        var buf = new byte[3];
        rng.GetBytes(buf);
        return new Scalar(buf[0], buf[1], buf[2]);
    }

    private static readonly RandomNumberGenerator defaultRng = RandomNumberGenerator.Create();

    #endregion

    #region Cast

#pragma warning disable 1591

    public readonly double ToDouble() => Val0;
    public readonly DMatch ToDMatch() => new((int)Val0, (int)Val1, (int)Val2, (float)Val3);

    public static explicit operator double(Scalar self) => self.ToDouble();
    public static explicit operator DMatch(Scalar self) => new((int)self.Val0, (int)self.Val1, (int)self.Val2, (float)self.Val3);

    // ReSharper disable InconsistentNaming
    public static Scalar FromDouble(double val) => new(val);
    public static Scalar FromDMatch(DMatch d) => new(d.QueryIdx, d.TrainIdx, d.ImgIdx, d.Distance);
    public static Scalar FromVec3b(Vec3b v) => new(v.Item0, v.Item1, v.Item2);
    public static Scalar FromVec3f(Vec3f v) => new(v.Item0, v.Item1, v.Item2);
    public static Scalar FromVec4f(Vec4f v) => new(v.Item0, v.Item1, v.Item2, v.Item3);
    public static Scalar FromVec6f(Vec6f v) => new(v.Item0, v.Item1, v.Item2, v.Item3);
    public static Scalar FromVec3d(Vec3d v) => new(v.Item0, v.Item1, v.Item2);
    public static Scalar FromVec4d(Vec4d v) => new(v.Item0, v.Item1, v.Item2, v.Item3);
    public static Scalar FromVec6d(Vec6d v) => new(v.Item0, v.Item1, v.Item2, v.Item3);
    public static Scalar FromPoint(Point p) => new(p.X, p.Y);
    public static Scalar FromPoint2f(Point2f p) => new(p.X, p.Y);
    public static Scalar FromPoint2d(Point2d p) => new(p.X, p.Y);
    public static Scalar FromPoint3i(Point3i p) => new(p.X, p.Y, p.Z);
    public static Scalar FromPoint3f(Point3f p) => new(p.X, p.Y, p.Z);
    public static Scalar FromPoint3d(Point3d p) => new(p.X, p.Y, p.Z);
    public static Scalar FromRect(Rect p) => new(p.X, p.Y, p.Width, p.Height);
    // ReSharper restore InconsistentNaming

    public static explicit operator Scalar(double val) => FromDouble(val);
    public static explicit operator Scalar(DMatch d) => FromDMatch(d);
    public static explicit operator Scalar(Vec3b v) => FromVec3b(v);
    public static explicit operator Scalar(Vec3f v) => FromVec3f(v);
    public static explicit operator Scalar(Vec4f v) => FromVec4f(v);
    public static explicit operator Scalar(Vec6f v) => FromVec6f(v);
    public static explicit operator Scalar(Vec3d v) => FromVec3d(v);
    public static explicit operator Scalar(Vec4d v) => FromVec4d(v);
    public static explicit operator Scalar(Vec6d v) => FromVec6d(v);
    public static explicit operator Scalar(Point p) => FromPoint(p);
    public static explicit operator Scalar(Point2f p) => FromPoint2f(p);
    public static explicit operator Scalar(Point2d p) => FromPoint2d(p);
    public static explicit operator Scalar(Point3i p) => FromPoint3i(p);
    public static explicit operator Scalar(Point3f p) => FromPoint3f(p);
    public static explicit operator Scalar(Point3d p) => FromPoint3d(p);
    public static explicit operator Scalar(Rect p) => FromRect(p);

#pragma warning restore 1591

    #endregion

    #region Methods

    /// <summary>
    /// 
    /// </summary>
    /// <param name="v"></param>
    /// <returns></returns>
    public static Scalar All(double v)
    {
        return new(v, v, v, v);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="it"></param>
    /// <param name="scale"></param>
    /// <returns></returns>
    public readonly Scalar Mul(Scalar it, double scale)
    {
        return new(Val0*it.Val0*scale, Val1*it.Val1*scale,
            Val2*it.Val2*scale, Val3*it.Val3*scale);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="it"></param>
    /// <returns></returns>
    public readonly Scalar Mul(Scalar it)
    {
        return Mul(it, 1);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public readonly Scalar Conj()
    {
        return new(Val0, -Val1, -Val2, -Val3);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public readonly bool IsReal()
    {
        // ReSharper disable CompareOfFloatsByEqualityOperator
        return Val1 == 0 && Val2 == 0 && Val3 == 0;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    // ReSharper disable once InconsistentNaming
    public readonly Vec3b ToVec3b()
    {
        return new((byte)Val0, (byte)Val1, (byte)Val2);
    }

    #endregion

    #region Existing Color Constants

    /// <summary>
    /// #F0F8FF
    /// </summary>
    public static readonly Scalar AliceBlue = FromRgb(240, 248, 255);

    /// <summary>
    /// #FAEBD7 
    /// </summary>
    public static readonly Scalar AntiqueWhite = FromRgb(250, 235, 215);

    /// <summary>
    /// #00FFFF 
    /// </summary>
    public static readonly Scalar Aqua = FromRgb(0, 255, 255);

    /// <summary>
    /// #7FFFD4
    /// </summary>
    public static readonly Scalar Aquamarine = FromRgb(127, 255, 212);

    /// <summary>
    /// #F0FFFF
    /// </summary>
    public static readonly Scalar Azure = FromRgb(240, 255, 255);

    /// <summary>
    /// #F5F5DC
    /// </summary>
    public static readonly Scalar Beige = FromRgb(245, 245, 220);

    /// <summary>
    /// #FFE4C4
    /// </summary>
    public static readonly Scalar Bisque = FromRgb(255, 228, 196);

    /// <summary>
    /// #000000
    /// </summary>
    public static readonly Scalar Black = FromRgb(0, 0, 0);

    /// <summary>
    /// #FFEBCD
    /// </summary>
    public static readonly Scalar BlanchedAlmond = FromRgb(255, 235, 205);

    /// <summary>
    /// #0000FF
    /// </summary>
    public static readonly Scalar Blue = FromRgb(0, 0, 255);

    /// <summary>
    /// #8A2BE2
    /// </summary>
    public static readonly Scalar BlueViolet = FromRgb(138, 43, 226);

    /// <summary>
    /// #A52A2A 
    /// </summary>
    public static readonly Scalar Brown = FromRgb(165, 42, 42);

    /// <summary>
    /// #DEB887
    /// </summary>
    public static readonly Scalar BurlyWood = FromRgb(222, 184, 135);

    /// <summary>
    /// #5F9EA0 
    /// </summary>
    public static readonly Scalar CadetBlue = FromRgb(95, 158, 160);

    /// <summary>
    /// #7FFF00 
    /// </summary>
    public static readonly Scalar Chartreuse = FromRgb(127, 255, 0);

    /// <summary>
    /// #D2691E
    /// </summary>
    public static readonly Scalar Chocolate = FromRgb(210, 105, 30);

    /// <summary>
    /// #FF7F50
    /// </summary>
    public static readonly Scalar Coral = FromRgb(255, 127, 80);

    /// <summary>
    /// #6495ED
    /// </summary>
    public static readonly Scalar CornflowerBlue = FromRgb(100, 149, 237);

    /// <summary>
    /// #FFF8DC
    /// </summary>
    public static readonly Scalar Cornsilk = FromRgb(255, 248, 220);

    /// <summary>
    /// #DC143C
    /// </summary>
    public static readonly Scalar Crimson = FromRgb(220, 20, 60);

    /// <summary>
    /// #00FFFF
    /// </summary>
    public static readonly Scalar Cyan = FromRgb(0, 255, 255);

    /// <summary>
    /// #00008B
    /// </summary>
    public static readonly Scalar DarkBlue = FromRgb(0, 0, 139);

    /// <summary>
    /// #008B8B
    /// </summary>
    public static readonly Scalar DarkCyan = FromRgb(0, 139, 139);

    /// <summary>
    /// #B8860B
    /// </summary>
    public static readonly Scalar DarkGoldenrod = FromRgb(184, 134, 11);

    /// <summary>
    /// #A9A9A9
    /// </summary>
    public static readonly Scalar DarkGray = FromRgb(169, 169, 169);

    /// <summary>
    /// #006400
    /// </summary>
    public static readonly Scalar DarkGreen = FromRgb(0, 100, 0);

    /// <summary>
    /// #BDB76B
    /// </summary>
    public static readonly Scalar DarkKhaki = FromRgb(189, 183, 107);

    /// <summary>
    /// #8B008B
    /// </summary>
    public static readonly Scalar DarkMagenta = FromRgb(139, 0, 139);

    /// <summary>
    /// #556B2F
    /// </summary>
    public static readonly Scalar DarkOliveGreen = FromRgb(85, 107, 47);

    /// <summary>
    /// #FF8C00 
    /// </summary>
    public static readonly Scalar DarkOrange = FromRgb(255, 140, 0);

    /// <summary>
    /// #9932CC
    /// </summary>
    public static readonly Scalar DarkOrchid = FromRgb(153, 50, 204);

    /// <summary>
    /// #8B0000
    /// </summary>
    public static readonly Scalar DarkRed = FromRgb(139, 0, 0);

    /// <summary>
    /// #E9967A
    /// </summary>
    public static readonly Scalar DarkSalmon = FromRgb(233, 150, 122);

    /// <summary>
    /// #8FBC8F
    /// </summary>
    public static readonly Scalar DarkSeaGreen = FromRgb(143, 188, 139);

    /// <summary>
    /// #483D8B
    /// </summary>
    public static readonly Scalar DarkSlateBlue = FromRgb(72, 61, 139);

    /// <summary>
    /// #2F4F4F
    /// </summary>
    public static readonly Scalar DarkSlateGray = FromRgb(47, 79, 79);

    /// <summary>
    /// #00CED1 
    /// </summary>
    public static readonly Scalar DarkTurquoise = FromRgb(0, 206, 209);

    /// <summary>
    /// #9400D3
    /// </summary>
    public static readonly Scalar DarkViolet = FromRgb(148, 0, 211);

    /// <summary>
    /// #FF1493
    /// </summary>
    public static readonly Scalar DeepPink = FromRgb(255, 20, 147);

    /// <summary>
    /// #00BFFF
    /// </summary>
    public static readonly Scalar DeepSkyBlue = FromRgb(0, 191, 255);

    /// <summary>
    /// #696969
    /// </summary>
    public static readonly Scalar DimGray = FromRgb(105, 105, 105);

    /// <summary>
    /// #1E90FF
    /// </summary>
    public static readonly Scalar DodgerBlue = FromRgb(30, 144, 255);

    /// <summary>
    /// #B22222
    /// </summary>
    public static readonly Scalar Firebrick = FromRgb(178, 34, 34);

    /// <summary>
    /// #FFFAF0 
    /// </summary>
    public static readonly Scalar FloralWhite = FromRgb(255, 250, 240);

    /// <summary>
    /// #228B22
    /// </summary>
    public static readonly Scalar ForestGreen = FromRgb(34, 139, 34);

    /// <summary>
    /// #FF00FF 
    /// </summary>
    public static readonly Scalar Fuchsia = FromRgb(255, 0, 255);

    /// <summary>
    /// #DCDCDC
    /// </summary>
    public static readonly Scalar Gainsboro = FromRgb(220, 220, 220);

    /// <summary>
    /// #F8F8FF
    /// </summary>
    public static readonly Scalar GhostWhite = FromRgb(248, 248, 255);

    /// <summary>
    /// #FFD700
    /// </summary>
    public static readonly Scalar Gold = FromRgb(255, 215, 0);

    /// <summary>
    /// #DAA520
    /// </summary>
    public static readonly Scalar Goldenrod = FromRgb(218, 165, 32);

    /// <summary>
    /// #808080
    /// </summary>
    public static readonly Scalar Gray = FromRgb(128, 128, 128);

    /// <summary>
    /// #008000
    /// </summary>
    public static readonly Scalar Green = FromRgb(0, 128, 0);

    /// <summary>
    /// #ADFF2F
    /// </summary>
    public static readonly Scalar GreenYellow = FromRgb(173, 255, 47);

    /// <summary>
    /// #F0FFF0
    /// </summary>
    public static readonly Scalar Honeydew = FromRgb(240, 255, 240);

    /// <summary>
    /// #FF69B4
    /// </summary>
    public static readonly Scalar HotPink = FromRgb(255, 105, 180);

    /// <summary>
    /// #CD5C5C
    /// </summary>
    public static readonly Scalar IndianRed = FromRgb(205, 92, 92);

    /// <summary>
    /// #4B0082
    /// </summary>
    public static readonly Scalar Indigo = FromRgb(75, 0, 130);

    /// <summary>
    /// #FFFFF0
    /// </summary>
    public static readonly Scalar Ivory = FromRgb(255, 255, 240);

    /// <summary>
    /// #F0E68C
    /// </summary>
    public static readonly Scalar Khaki = FromRgb(240, 230, 140);

    /// <summary>
    /// #E6E6FA
    /// </summary>
    public static readonly Scalar Lavender = FromRgb(230, 230, 250);

    /// <summary>
    /// #FFF0F5 
    /// </summary>
    public static readonly Scalar LavenderBlush = FromRgb(255, 240, 245);

    /// <summary>
    /// #7CFC00
    /// </summary>
    public static readonly Scalar LawnGreen = FromRgb(124, 252, 0);

    /// <summary>
    /// #FFFACD
    /// </summary>
    public static readonly Scalar LemonChiffon = FromRgb(255, 250, 205);

    /// <summary>
    /// #ADD8E6
    /// </summary>
    public static readonly Scalar LightBlue = FromRgb(173, 216, 230);

    /// <summary>
    /// #F08080
    /// </summary>
    public static readonly Scalar LightCoral = FromRgb(240, 128, 128);

    /// <summary>
    /// #E0FFFF
    /// </summary>
    public static readonly Scalar LightCyan = FromRgb(224, 255, 255);

    /// <summary>
    /// #FAFAD2
    /// </summary>
    public static readonly Scalar LightGoldenrodYellow = FromRgb(250, 250, 210);

    /// <summary>
    /// #D3D3D3
    /// </summary>
    public static readonly Scalar LightGray = FromRgb(211, 211, 211);

    /// <summary>
    /// #90EE90 
    /// </summary>
    public static readonly Scalar LightGreen = FromRgb(144, 238, 144);

    /// <summary>
    /// #FFB6C1
    /// </summary>
    public static readonly Scalar LightPink = FromRgb(255, 182, 193);

    /// <summary>
    /// #FFA07A
    /// </summary>
    public static readonly Scalar LightSalmon = FromRgb(255, 160, 122);

    /// <summary>
    /// #20B2AA
    /// </summary>
    public static readonly Scalar LightSeaGreen = FromRgb(32, 178, 170);

    /// <summary>
    /// #87CEFA 
    /// </summary>
    public static readonly Scalar LightSkyBlue = FromRgb(135, 206, 250);

    /// <summary>
    /// #778899
    /// </summary>
    public static readonly Scalar LightSlateGray = FromRgb(119, 136, 153);

    /// <summary>
    /// #B0C4DE 
    /// </summary>
    public static readonly Scalar LightSteelBlue = FromRgb(176, 196, 222);

    /// <summary>
    /// #FFFFE0
    /// </summary>
    public static readonly Scalar LightYellow = FromRgb(255, 255, 224);

    /// <summary>
    /// #00FF00
    /// </summary>
    public static readonly Scalar Lime = FromRgb(0, 255, 0);

    /// <summary>
    /// #32CD32
    /// </summary>
    public static readonly Scalar LimeGreen = FromRgb(50, 205, 50);

    /// <summary>
    /// #FAF0E6
    /// </summary>
    public static readonly Scalar Linen = FromRgb(250, 240, 230);

    /// <summary>
    /// #FF00FF
    /// </summary>
    public static readonly Scalar Magenta = FromRgb(255, 0, 255);

    /// <summary>
    /// #800000
    /// </summary>
    public static readonly Scalar Maroon = FromRgb(128, 0, 0);

    /// <summary>
    /// #66CDAA
    /// </summary>
    public static readonly Scalar MediumAquamarine = FromRgb(102, 205, 170);

    /// <summary>
    /// #0000CD
    /// </summary>
    public static readonly Scalar MediumBlue = FromRgb(0, 0, 205);

    /// <summary>
    /// #BA55D3
    /// </summary>
    public static readonly Scalar MediumOrchid = FromRgb(186, 85, 211);

    /// <summary>
    /// #9370DB
    /// </summary>
    public static readonly Scalar MediumPurple = FromRgb(147, 112, 219);

    /// <summary>
    /// #3CB371
    /// </summary>
    public static readonly Scalar MediumSeaGreen = FromRgb(60, 179, 113);

    /// <summary>
    /// #7B68EE
    /// </summary>
    public static readonly Scalar MediumSlateBlue = FromRgb(123, 104, 238);

    /// <summary>
    /// #00FA9A 
    /// </summary>
    public static readonly Scalar MediumSpringGreen = FromRgb(0, 250, 154);

    /// <summary>
    /// #48D1CC
    /// </summary>
    public static readonly Scalar MediumTurquoise = FromRgb(72, 209, 204);

    /// <summary>
    /// #C71585
    /// </summary>
    public static readonly Scalar MediumVioletRed = FromRgb(199, 21, 133);

    /// <summary>
    /// #191970
    /// </summary>
    public static readonly Scalar MidnightBlue = FromRgb(25, 25, 112);

    /// <summary>
    /// #F5FFFA
    /// </summary>
    public static readonly Scalar MintCream = FromRgb(245, 255, 250);

    /// <summary>
    /// #FFE4E1
    /// </summary>
    public static readonly Scalar MistyRose = FromRgb(255, 228, 225);

    /// <summary>
    /// #FFE4B5
    /// </summary>
    public static readonly Scalar Moccasin = FromRgb(255, 228, 181);

    /// <summary>
    /// #FFDEAD
    /// </summary>
    public static readonly Scalar NavajoWhite = FromRgb(255, 222, 173);

    /// <summary>
    /// #000080
    /// </summary>
    public static readonly Scalar Navy = FromRgb(0, 0, 128);

    /// <summary>
    /// #FDF5E6
    /// </summary>
    public static readonly Scalar OldLace = FromRgb(253, 245, 230);

    /// <summary>
    /// #808000 
    /// </summary>
    public static readonly Scalar Olive = FromRgb(128, 128, 0);

    /// <summary>
    /// #6B8E23
    /// </summary>
    public static readonly Scalar OliveDrab = FromRgb(107, 142, 35);

    /// <summary>
    /// #FFA500
    /// </summary>
    public static readonly Scalar Orange = FromRgb(255, 165, 0);

    /// <summary>
    /// #FF4500
    /// </summary>
    public static readonly Scalar OrangeRed = FromRgb(255, 69, 0);

    /// <summary>
    /// #DA70D6
    /// </summary>
    public static readonly Scalar Orchid = FromRgb(218, 112, 214);

    /// <summary>
    /// #EEE8AA 
    /// </summary>
    public static readonly Scalar PaleGoldenrod = FromRgb(238, 232, 170);

    /// <summary>
    /// #98FB98
    /// </summary>
    public static readonly Scalar PaleGreen = FromRgb(152, 251, 152);

    /// <summary>
    /// #AFEEEE
    /// </summary>
    public static readonly Scalar PaleTurquoise = FromRgb(175, 238, 238);

    /// <summary>
    /// #DB7093
    /// </summary>
    public static readonly Scalar PaleVioletRed = FromRgb(219, 112, 147);

    /// <summary>
    /// #FFEFD5 
    /// </summary>
    public static readonly Scalar PapayaWhip = FromRgb(255, 239, 213);

    /// <summary>
    /// #FFDAB9
    /// </summary>
    public static readonly Scalar PeachPuff = FromRgb(255, 218, 185);

    /// <summary>
    /// #CD853F
    /// </summary>
    public static readonly Scalar Peru = FromRgb(205, 133, 63);

    /// <summary>
    /// #FFC0CB
    /// </summary>
    public static readonly Scalar Pink = FromRgb(255, 192, 203);

    /// <summary>
    /// #DDA0DD
    /// </summary>
    public static readonly Scalar Plum = FromRgb(221, 160, 221);

    /// <summary>
    /// #B0E0E6
    /// </summary>
    public static readonly Scalar PowderBlue = FromRgb(176, 224, 230);

    /// <summary>
    /// #800080
    /// </summary>
    public static readonly Scalar Purple = FromRgb(128, 0, 128);

    /// <summary>
    /// #FF0000
    /// </summary>
    public static readonly Scalar Red = FromRgb(255, 0, 0);

    /// <summary>
    /// #BC8F8F
    /// </summary>
    public static readonly Scalar RosyBrown = FromRgb(188, 143, 143);

    /// <summary>
    /// #4169E1
    /// </summary>
    public static readonly Scalar RoyalBlue = FromRgb(65, 105, 225);

    /// <summary>
    /// #8B4513
    /// </summary>
    public static readonly Scalar SaddleBrown = FromRgb(139, 69, 19);

    /// <summary>
    /// #FA8072
    /// </summary>
    public static readonly Scalar Salmon = FromRgb(250, 128, 114);

    /// <summary>
    /// #F4A460
    /// </summary>
    public static readonly Scalar SandyBrown = FromRgb(244, 164, 96);

    /// <summary>
    /// #2E8B57
    /// </summary>
    public static readonly Scalar SeaGreen = FromRgb(46, 139, 87);

    /// <summary>
    /// #FFF5EE
    /// </summary>
    public static readonly Scalar SeaShell = FromRgb(255, 245, 238);

    /// <summary>
    /// #A0522D
    /// </summary>
    public static readonly Scalar Sienna = FromRgb(160, 82, 45);

    /// <summary>
    /// #C0C0C0 
    /// </summary>
    public static readonly Scalar Silver = FromRgb(192, 192, 192);

    /// <summary>
    /// #87CEEB
    /// </summary>
    public static readonly Scalar SkyBlue = FromRgb(135, 206, 235);

    /// <summary>
    /// #6A5ACD
    /// </summary>
    public static readonly Scalar SlateBlue = FromRgb(106, 90, 205);

    /// <summary>
    /// #708090
    /// </summary>
    public static readonly Scalar SlateGray = FromRgb(112, 128, 144);

    /// <summary>
    /// #FFFAFA
    /// </summary>
    public static readonly Scalar Snow = FromRgb(255, 250, 250);

    /// <summary>
    /// #00FF7F
    /// </summary>
    public static readonly Scalar SpringGreen = FromRgb(0, 255, 127);

    /// <summary>
    /// #4682B4
    /// </summary>
    public static readonly Scalar SteelBlue = FromRgb(70, 130, 180);

    /// <summary>
    /// #D2B48C
    /// </summary>
    public static readonly Scalar Tan = FromRgb(210, 180, 140);

    /// <summary>
    /// #008080
    /// </summary>
    public static readonly Scalar Teal = FromRgb(0, 128, 128);

    /// <summary>
    /// #D8BFD8
    /// </summary>
    public static readonly Scalar Thistle = FromRgb(216, 191, 216);

    /// <summary>
    /// #FF6347
    /// </summary>
    public static readonly Scalar Tomato = FromRgb(255, 99, 71);

    /// <summary>
    /// #40E0D0
    /// </summary>
    public static readonly Scalar Turquoise = FromRgb(64, 224, 208);

    /// <summary>
    /// #EE82EE
    /// </summary>
    public static readonly Scalar Violet = FromRgb(238, 130, 238);

    /// <summary>
    /// #F5DEB3
    /// </summary>
    public static readonly Scalar Wheat = FromRgb(245, 222, 179);

    /// <summary>
    /// #FFFFFF
    /// </summary>
    public static readonly Scalar White = FromRgb(255, 255, 255);

    /// <summary>
    /// #F5F5F5
    /// </summary>
    public static readonly Scalar WhiteSmoke = FromRgb(245, 245, 245);

    /// <summary>
    /// #FFFF00
    /// </summary>
    public static readonly Scalar Yellow = FromRgb(255, 255, 0);

    /// <summary>
    /// #9ACD32
    /// </summary>
    public static readonly Scalar YellowGreen = FromRgb(154, 205, 50);
        
    #endregion
}
