/*
 * (C) 2008-2013 Schima
 * This code is licenced under the LGPL.
 */

using System;
using System.Runtime.InteropServices;

namespace OpenCvSharp
{
#if LANG_JP
    /// <summary>
	/// 色をあらわす構造体.
	/// OpenCVのCvScalarや、System.Drawing.Colorとの暗黙の変換が定義されている.
	/// </summary>
#else
    /// <summary>
    /// Structure that represents RGB color (alias of CvScalar).
    /// </summary>
#endif
    [Serializable]
    [StructLayout(LayoutKind.Sequential)]
    public struct CvColor : IEquatable<CvColor>
    {
        #region Fields
#if LANG_JP
        /// <summary>
        /// R成分
        /// </summary>
#else
        /// <summary>
        /// Red
        /// </summary>
#endif
        public byte R;

#if LANG_JP
        /// <summary>
        /// G成分
        /// </summary>
#else
        /// <summary>
        /// Green
        /// </summary>
#endif
        public byte G;
        
#if LANG_JP
        /// <summary>
        /// B成分
        /// </summary>
#else
        /// <summary>
        /// Blue
        /// </summary>
#endif
        public byte B;
        #endregion

        #region Initializers
#if LANG_JP
        /// <summary>
        /// 初期化 
        /// </summary>
        /// <param name="r">R成分</param>
        /// <param name="g">G成分</param>
        /// <param name="b">B成分</param>
#else
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="r">Red</param>
        /// <param name="g">Green</param>
        /// <param name="b">Blue</param>
#endif
        public CvColor(byte r, byte g, byte b)
        {
            R = r;
            G = g;
            B = b;
        }
#if LANG_JP
        /// <summary>
        /// 初期化 
        /// </summary>
        /// <param name="r">R成分</param>
        /// <param name="g">G成分</param>
        /// <param name="b">B成分</param>
#else
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="r">Red</param>
        /// <param name="g">Green</param>
        /// <param name="b">Blue</param>
#endif
        public CvColor(int r, int g, int b)
        {
            R = (byte)r;
            G = (byte)g;
            B = (byte)b;
        }

#if LANG_JP
        /// <summary>
        /// 初期化 
        /// </summary>
        /// <param name="argb">32 ビットの ARGB 値を指定する値 (Aは無視される)</param>
#else
        /// <summary>
        /// Construct from 
        /// </summary>
        /// <param name="argb">A value specifying the 32-bit ARGB value. </param>
#endif
        public CvColor(int argb)
        {
            //byte a = (byte)((argb >> 24) & 0xff);
            R = (byte)((argb >> 16) & 0xff);
            G = (byte)((argb >> 8) & 0xff);
            B = (byte)((argb >> 0) & 0xff);
        }

#if LANG_JP
        /// <summary>
        /// ランダムな色を生成して返す
        /// </summary>
        /// <returns></returns>
#else
        /// <summary>
        /// Creates a random color
        /// </summary>
        /// <returns></returns>
#endif
        public static CvColor Random()
        {
            return new CvColor((byte)rand.Next(256), (byte)rand.Next(256), (byte)rand.Next(256));
        }
        static readonly Random rand = new Random();
        #endregion

        #region Operators
#if LANG_JP
        /// <summary>
        /// CvColorからCvScalarに変換する暗黙のキャスト 
        /// </summary>
        /// <param name="self">新しい CvScalar の値を指定する CvColor</param>
        /// <returns>CvScalar</returns>
#else
        /// <summary>
        /// Creates a CvScalar with the members of the specified CvColor.
        /// </summary>
        /// <param name="self">A CvColor that specifies the coordinates for the new CvScalar.</param>
        /// <returns>CvScalar</returns>
#endif
	    public static implicit operator CvScalar(CvColor self)
	    {
		    return new CvScalar(self.B, self.G, self.R, 0);
	    }
#if LANG_JP
        /// <summary>
        /// CvScalarからCvColorに変換する暗黙のキャスト 
        /// </summary>
        /// <param name="obj">新しい CvColor の値を指定する CvScalar</param>
        /// <returns>CvColor</returns>
#else
        /// <summary>
        /// Creates a CvColor with the members of the specified CvScalar.
        /// </summary>
        /// <param name="obj">A CvScalar that specifies the coordinates for the new CvPoint.</param>
        /// <returns>CvColor</returns>
#endif
        public static implicit operator CvColor(CvScalar obj)
	    {
            return new CvColor((byte)obj.Val2, (byte)obj.Val1, (byte)obj.Val0);
	    }


#if LANG_JP
        /// <summary>
        /// == 演算子のオーバーロード
        /// </summary>
        /// <param name="lhs">左辺値</param>
        /// <param name="rhs">右辺値</param>
        /// <returns>等しければtrue</returns>
#else
        /// <summary>
        /// Compares two CvPoint objects. The result specifies whether the members of each CvPoint object are equal.
        /// </summary>
        /// <param name="lhs">A Point to compare.</param>
        /// <param name="rhs">A Point to compare.</param>
        /// <returns>This operator returns true if the members of left and right are equal; otherwise, false.</returns>
#endif
	    public static bool operator==(CvColor lhs, CvColor rhs)
	    {
		    return lhs.Equals(rhs);
	    }
#if LANG_JP
        /// <summary>
        /// != 演算子のオーバーロード
        /// </summary>
        /// <param name="lhs">左辺値</param>
        /// <param name="rhs">右辺値</param>
        /// <returns>等しくなければtrue</returns>
#else
        /// <summary>
        /// Compares two CvPoint objects. The result specifies whether the members of each CvPoint object are unequal.
        /// </summary>
        /// <param name="lhs">A Point to compare.</param>
        /// <param name="rhs">A Point to compare.</param>
        /// <returns>This operator returns true if the members of left and right are unequal; otherwise, false.</returns>
#endif
        public static bool operator !=(CvColor lhs, CvColor rhs)
        {
            return !lhs.Equals(rhs);
        }
#if LANG_JP
        /// <summary>
        /// 指定したオブジェクトと等しければtrueを返す 
        /// </summary>
        /// <param name="obj">比較するオブジェクト</param>
        /// <returns>型が同じで、メンバの値が等しければtrue</returns>
#else
        /// <summary>
        /// Specifies whether this object contains the same members as the specified Object.
        /// </summary>
        /// <param name="obj">The Object to test.</param>
        /// <returns>This method returns true if obj is the same type as this object and has the same members as this object.</returns>
#endif
        public bool Equals(CvColor obj)
	    {
            return (R == obj.R && G == obj.G && B == obj.B);
        }
        #endregion

        #region Overridden Methods
#if LANG_JP
        /// <summary>
        /// Equalsのオーバーライド
        /// </summary>
        /// <param name="obj">比較するオブジェクト</param>
        /// <returns></returns>
#else
        /// <summary>
        /// Specifies whether this object contains the same members as the specified Object.
        /// </summary>
        /// <param name="obj">The Object to test.</param>
        /// <returns>This method returns true if obj is the same type as this object and has the same members as this object.</returns>
#endif   
        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }
#if LANG_JP
        /// <summary>
        /// GetHashCodeのオーバーライド
        /// </summary>
        /// <returns>このオブジェクトのハッシュ値を指定する整数値。</returns>
#else
        /// <summary>
        /// Returns a hash code for this object.
        /// </summary>
        /// <returns>An integer value that specifies a hash value for this object.</returns>
#endif
        public override int GetHashCode()
        {
            return R.GetHashCode() ^ G.GetHashCode() ^ B.GetHashCode();
        }
#if LANG_JP
        /// <summary>
        /// 文字列形式を返す 
        /// </summary>
        /// <returns>文字列形式</returns>
#else
        /// <summary>
        /// Converts this object to a human readable string.
        /// </summary>
        /// <returns>A string that represents this object.</returns>
#endif
	    public override string ToString()
	    {
		    return string.Format("CvColor (r:{0} g:{1} b:{2})", R, G, B);
        }
        #endregion

        #region Existing Color Constants
        /// <summary>
        /// #F0F8FF
        /// </summary>
        public static readonly CvColor AliceBlue = new CvColor(240, 248, 255);
        /// <summary>
        /// #FAEBD7 
        /// </summary>
        public static readonly CvColor AntiqueWhite = new CvColor(250, 235, 215);
        /// <summary>
        /// #00FFFF 
        /// </summary>
        public static readonly CvColor Aqua = new CvColor(0, 255, 255);
        /// <summary>
        /// #7FFFD4
        /// </summary>
        public static readonly CvColor Aquamarine = new CvColor(127, 255, 212);
        /// <summary>
        /// #F0FFFF
        /// </summary>
        public static readonly CvColor Azure = new CvColor(240, 255, 255);
        /// <summary>
        /// #F5F5DC
        /// </summary>
        public static readonly CvColor Beige = new CvColor(245, 245, 220);
        /// <summary>
        /// #FFE4C4
        /// </summary>
        public static readonly CvColor Bisque = new CvColor(255, 228, 196);
        /// <summary>
        /// #000000
        /// </summary>
        public static readonly CvColor Black = new CvColor(0, 0, 0);
        /// <summary>
        /// #FFEBCD
        /// </summary>
        public static readonly CvColor BlanchedAlmond = new CvColor(255, 235, 205);
        /// <summary>
        /// #0000FF
        /// </summary>
        public static readonly CvColor Blue = new CvColor(0, 0, 255);
        /// <summary>
        /// #8A2BE2
        /// </summary>
        public static readonly CvColor BlueViolet = new CvColor(138, 43, 226);
        /// <summary>
        /// #A52A2A 
        /// </summary>
        public static readonly CvColor Brown = new CvColor(165, 42, 42);
        /// <summary>
        /// #DEB887
        /// </summary>
        public static readonly CvColor BurlyWood = new CvColor(222, 184, 135);
        /// <summary>
        /// #5F9EA0 
        /// </summary>
        public static readonly CvColor CadetBlue = new CvColor(95, 158, 160);
        /// <summary>
        /// #7FFF00 
        /// </summary>
        public static readonly CvColor Chartreuse = new CvColor(127, 255, 0);
        /// <summary>
        /// #D2691E
        /// </summary>
        public static readonly CvColor Chocolate = new CvColor(210, 105, 30);
        /// <summary>
        /// #FF7F50
        /// </summary>
        public static readonly CvColor Coral = new CvColor(255, 127, 80);
        /// <summary>
        /// #6495ED
        /// </summary>
        public static readonly CvColor CornflowerBlue = new CvColor(100, 149, 237);
        /// <summary>
        /// #FFF8DC
        /// </summary>
        public static readonly CvColor Cornsilk = new CvColor(255, 248, 220);
        /// <summary>
        /// #DC143C
        /// </summary>
        public static readonly CvColor Crimson = new CvColor(220, 20, 60);
        /// <summary>
        /// #00FFFF
        /// </summary>
        public static readonly CvColor Cyan = new CvColor(0, 255, 255);
        /// <summary>
        /// #00008B
        /// </summary>
        public static readonly CvColor DarkBlue = new CvColor(0, 0, 139);
        /// <summary>
        /// #008B8B
        /// </summary>
        public static readonly CvColor DarkCyan = new CvColor(0, 139, 139);
        /// <summary>
        /// #B8860B
        /// </summary>
        public static readonly CvColor DarkGoldenrod = new CvColor(184, 134, 11);
        /// <summary>
        /// #A9A9A9
        /// </summary>
        public static readonly CvColor DarkGray = new CvColor(169, 169, 169);
        /// <summary>
        /// #006400
        /// </summary>
        public static readonly CvColor DarkGreen = new CvColor(0, 100, 0);
        /// <summary>
        /// #BDB76B
        /// </summary>
        public static readonly CvColor DarkKhaki = new CvColor(189, 183, 107);
        /// <summary>
        /// #8B008B
        /// </summary>
        public static readonly CvColor DarkMagenta = new CvColor(139, 0, 139);
        /// <summary>
        /// #556B2F
        /// </summary>
        public static readonly CvColor DarkOliveGreen = new CvColor(85, 107, 47);
        /// <summary>
        /// #FF8C00 
        /// </summary>
        public static readonly CvColor DarkOrange = new CvColor(255, 140, 0);
        /// <summary>
        /// #9932CC
        /// </summary>
        public static readonly CvColor DarkOrchid = new CvColor(153, 50, 204);
        /// <summary>
        /// #8B0000
        /// </summary>
        public static readonly CvColor DarkRed = new CvColor(139, 0, 0);
        /// <summary>
        /// #E9967A
        /// </summary>
        public static readonly CvColor DarkSalmon = new CvColor(233, 150, 122);
        /// <summary>
        /// #8FBC8F
        /// </summary>
        public static readonly CvColor DarkSeaGreen = new CvColor(143, 188, 139);
        /// <summary>
        /// #483D8B
        /// </summary>
        public static readonly CvColor DarkSlateBlue = new CvColor(72, 61, 139);
        /// <summary>
        /// #2F4F4F
        /// </summary>
        public static readonly CvColor DarkSlateGray = new CvColor(47, 79, 79);
        /// <summary>
        /// #00CED1 
        /// </summary>
        public static readonly CvColor DarkTurquoise = new CvColor(0, 206, 209);
        /// <summary>
        /// #9400D3
        /// </summary>
        public static readonly CvColor DarkViolet = new CvColor(148, 0, 211);
        /// <summary>
        /// #FF1493
        /// </summary>
        public static readonly CvColor DeepPink = new CvColor(255, 20, 147);
        /// <summary>
        /// #00BFFF
        /// </summary>
        public static readonly CvColor DeepSkyBlue = new CvColor(0, 191, 255);
        /// <summary>
        /// #696969
        /// </summary>
        public static readonly CvColor DimGray = new CvColor(105, 105, 105);
        /// <summary>
        /// #1E90FF
        /// </summary>
        public static readonly CvColor DodgerBlue = new CvColor(30, 144, 255);
        /// <summary>
        /// #B22222
        /// </summary>
        public static readonly CvColor Firebrick = new CvColor(178, 34, 34);
        /// <summary>
        /// #FFFAF0 
        /// </summary>
        public static readonly CvColor FloralWhite = new CvColor(255, 250, 240);
        /// <summary>
        /// #228B22
        /// </summary>
        public static readonly CvColor ForestGreen = new CvColor(34, 139, 34);
        /// <summary>
        /// #FF00FF 
        /// </summary>
        public static readonly CvColor Fuchsia = new CvColor(255, 0, 255);
        /// <summary>
        /// #DCDCDC
        /// </summary>
        public static readonly CvColor Gainsboro = new CvColor(220, 220, 220);
        /// <summary>
        /// #F8F8FF
        /// </summary>
        public static readonly CvColor GhostWhite = new CvColor(248, 248, 255);
        /// <summary>
        /// #FFD700
        /// </summary>
        public static readonly CvColor Gold = new CvColor(255, 215, 0);
        /// <summary>
        /// #DAA520
        /// </summary>
        public static readonly CvColor Goldenrod = new CvColor(218, 165, 32);
        /// <summary>
        /// #808080
        /// </summary>
        public static readonly CvColor Gray = new CvColor(128, 128, 128);
        /// <summary>
        /// #008000
        /// </summary>
        public static readonly CvColor Green = new CvColor(0, 128, 0);
        /// <summary>
        /// #ADFF2F
        /// </summary>
        public static readonly CvColor GreenYellow = new CvColor(173, 255, 47);
        /// <summary>
        /// #F0FFF0
        /// </summary>
        public static readonly CvColor Honeydew = new CvColor(240, 255, 240);
        /// <summary>
        /// #FF69B4
        /// </summary>
        public static readonly CvColor HotPink = new CvColor(255, 105, 180);
        /// <summary>
        /// #CD5C5C
        /// </summary>
        public static readonly CvColor IndianRed = new CvColor(205, 92, 92);
        /// <summary>
        /// #4B0082
        /// </summary>
        public static readonly CvColor Indigo = new CvColor(75, 0, 130);
        /// <summary>
        /// #FFFFF0
        /// </summary>
        public static readonly CvColor Ivory = new CvColor(255, 255, 240);
        /// <summary>
        /// #F0E68C
        /// </summary>
        public static readonly CvColor Khaki = new CvColor(240, 230, 140);
        /// <summary>
        /// #E6E6FA
        /// </summary>
        public static readonly CvColor Lavender = new CvColor(230, 230, 250);
        /// <summary>
        /// #FFF0F5 
        /// </summary>
        public static readonly CvColor LavenderBlush = new CvColor(255, 240, 245);
        /// <summary>
        /// #7CFC00
        /// </summary>
        public static readonly CvColor LawnGreen = new CvColor(124, 252, 0);
        /// <summary>
        /// #FFFACD
        /// </summary>
        public static readonly CvColor LemonChiffon = new CvColor(255, 250, 205);
        /// <summary>
        /// #ADD8E6
        /// </summary>
        public static readonly CvColor LightBlue = new CvColor(173, 216, 230);
        /// <summary>
        /// #F08080
        /// </summary>
        public static readonly CvColor LightCoral = new CvColor(240, 128, 128);
        /// <summary>
        /// #E0FFFF
        /// </summary>
        public static readonly CvColor LightCyan = new CvColor(224, 255, 255);
        /// <summary>
        /// #FAFAD2
        /// </summary>
        public static readonly CvColor LightGoldenrodYellow = new CvColor(250, 250, 210);
        /// <summary>
        /// #D3D3D3
        /// </summary>
        public static readonly CvColor LightGray = new CvColor(211, 211, 211);
        /// <summary>
        /// #90EE90 
        /// </summary>
        public static readonly CvColor LightGreen = new CvColor(144, 238, 144);
        /// <summary>
        /// #FFB6C1
        /// </summary>
        public static readonly CvColor LightPink = new CvColor(255, 182, 193);
        /// <summary>
        /// #FFA07A
        /// </summary>
        public static readonly CvColor LightSalmon = new CvColor(255, 160, 122);
        /// <summary>
        /// #20B2AA
        /// </summary>
        public static readonly CvColor LightSeaGreen = new CvColor(32, 178, 170);
        /// <summary>
        /// #87CEFA 
        /// </summary>
        public static readonly CvColor LightSkyBlue = new CvColor(135, 206, 250);
        /// <summary>
        /// #778899
        /// </summary>
        public static readonly CvColor LightSlateGray = new CvColor(119, 136, 153);
        /// <summary>
        /// #B0C4DE 
        /// </summary>
        public static readonly CvColor LightSteelBlue = new CvColor(176, 196, 222);
        /// <summary>
        /// #FFFFE0
        /// </summary>
        public static readonly CvColor LightYellow = new CvColor(255, 255, 224);
        /// <summary>
        /// #00FF00
        /// </summary>
        public static readonly CvColor Lime = new CvColor(0, 255, 0);
        /// <summary>
        /// #32CD32
        /// </summary>
        public static readonly CvColor LimeGreen = new CvColor(50, 205, 50);
        /// <summary>
        /// #FAF0E6
        /// </summary>
        public static readonly CvColor Linen = new CvColor(250, 240, 230);
        /// <summary>
        /// #FF00FF
        /// </summary>
        public static readonly CvColor Magenta = new CvColor(255, 0, 255);
        /// <summary>
        /// #800000
        /// </summary>
        public static readonly CvColor Maroon = new CvColor(128, 0, 0);
        /// <summary>
        /// #66CDAA
        /// </summary>
        public static readonly CvColor MediumAquamarine = new CvColor(102, 205, 170);
        /// <summary>
        /// #0000CD
        /// </summary>
        public static readonly CvColor MediumBlue = new CvColor(0, 0, 205);
        /// <summary>
        /// #BA55D3
        /// </summary>
        public static readonly CvColor MediumOrchid = new CvColor(186, 85, 211);
        /// <summary>
        /// #9370DB
        /// </summary>
        public static readonly CvColor MediumPurple = new CvColor(147, 112, 219);
        /// <summary>
        /// #3CB371
        /// </summary>
        public static readonly CvColor MediumSeaGreen = new CvColor(60, 179, 113);
        /// <summary>
        /// #7B68EE
        /// </summary>
        public static readonly CvColor MediumSlateBlue = new CvColor(123, 104, 238);
        /// <summary>
        /// #00FA9A 
        /// </summary>
        public static readonly CvColor MediumSpringGreen = new CvColor(0, 250, 154);
        /// <summary>
        /// #48D1CC
        /// </summary>
        public static readonly CvColor MediumTurquoise = new CvColor(72, 209, 204);
        /// <summary>
        /// #C71585
        /// </summary>
        public static readonly CvColor MediumVioletRed = new CvColor(199, 21, 133);
        /// <summary>
        /// #191970
        /// </summary>
        public static readonly CvColor MidnightBlue = new CvColor(25, 25, 112);
        /// <summary>
        /// #F5FFFA
        /// </summary>
        public static readonly CvColor MintCream = new CvColor(245, 255, 250);
        /// <summary>
        /// #FFE4E1
        /// </summary>
        public static readonly CvColor MistyRose = new CvColor(255, 228, 225);
        /// <summary>
        /// #FFE4B5
        /// </summary>
        public static readonly CvColor Moccasin = new CvColor(255, 228, 181);
        /// <summary>
        /// #FFDEAD
        /// </summary>
        public static readonly CvColor NavajoWhite = new CvColor(255, 222, 173);
        /// <summary>
        /// #000080
        /// </summary>
        public static readonly CvColor Navy = new CvColor(0, 0, 128);
        /// <summary>
        /// #FDF5E6
        /// </summary>
        public static readonly CvColor OldLace = new CvColor(253, 245, 230);
        /// <summary>
        /// #808000 
        /// </summary>
        public static readonly CvColor Olive = new CvColor(128, 128, 0);
        /// <summary>
        /// #6B8E23
        /// </summary>
        public static readonly CvColor OliveDrab = new CvColor(107, 142, 35);
        /// <summary>
        /// #FFA500
        /// </summary>
        public static readonly CvColor Orange = new CvColor(255, 165, 0);
        /// <summary>
        /// #FF4500
        /// </summary>
        public static readonly CvColor OrangeRed = new CvColor(255, 69, 0);
        /// <summary>
        /// #DA70D6
        /// </summary>
        public static readonly CvColor Orchid = new CvColor(218, 112, 214);
        /// <summary>
        /// #EEE8AA 
        /// </summary>
        public static readonly CvColor PaleGoldenrod = new CvColor(238, 232, 170);
        /// <summary>
        /// #98FB98
        /// </summary>
        public static readonly CvColor PaleGreen = new CvColor(152, 251, 152);
        /// <summary>
        /// #AFEEEE
        /// </summary>
        public static readonly CvColor PaleTurquoise = new CvColor(175, 238, 238);
        /// <summary>
        /// #DB7093
        /// </summary>
        public static readonly CvColor PaleVioletRed = new CvColor(219, 112, 147);
        /// <summary>
        /// #FFEFD5 
        /// </summary>
        public static readonly CvColor PapayaWhip = new CvColor(255, 239, 213);
        /// <summary>
        /// #FFDAB9
        /// </summary>
        public static readonly CvColor PeachPuff = new CvColor(255, 218, 185);
        /// <summary>
        /// #CD853F
        /// </summary>
        public static readonly CvColor Peru = new CvColor(205, 133, 63);
        /// <summary>
        /// #FFC0CB
        /// </summary>
        public static readonly CvColor Pink = new CvColor(255, 192, 203);
        /// <summary>
        /// #DDA0DD
        /// </summary>
        public static readonly CvColor Plum = new CvColor(221, 160, 221);
        /// <summary>
        /// #B0E0E6
        /// </summary>
        public static readonly CvColor PowderBlue = new CvColor(176, 224, 230);
        /// <summary>
        /// #800080
        /// </summary>
        public static readonly CvColor Purple = new CvColor(128, 0, 128);
        /// <summary>
        /// #FF0000
        /// </summary>
        public static readonly CvColor Red = new CvColor(255, 0, 0);
        /// <summary>
        /// #BC8F8F
        /// </summary>
        public static readonly CvColor RosyBrown = new CvColor(188, 143, 143);
        /// <summary>
        /// #4169E1
        /// </summary>
        public static readonly CvColor RoyalBlue = new CvColor(65, 105, 225);
        /// <summary>
        /// #8B4513
        /// </summary>
        public static readonly CvColor SaddleBrown = new CvColor(139, 69, 19);
        /// <summary>
        /// #FA8072
        /// </summary>
        public static readonly CvColor Salmon = new CvColor(250, 128, 114);
        /// <summary>
        /// #F4A460
        /// </summary>
        public static readonly CvColor SandyBrown = new CvColor(244, 164, 96);
        /// <summary>
        /// #2E8B57
        /// </summary>
        public static readonly CvColor SeaGreen = new CvColor(46, 139, 87);
        /// <summary>
        /// #FFF5EE
        /// </summary>
        public static readonly CvColor SeaShell = new CvColor(255, 245, 238);
        /// <summary>
        /// #A0522D
        /// </summary>
        public static readonly CvColor Sienna = new CvColor(160, 82, 45);
        /// <summary>
        /// #C0C0C0 
        /// </summary>
        public static readonly CvColor Silver = new CvColor(192, 192, 192);
        /// <summary>
        /// #87CEEB
        /// </summary>
        public static readonly CvColor SkyBlue = new CvColor(135, 206, 235);
        /// <summary>
        /// #6A5ACD
        /// </summary>
        public static readonly CvColor SlateBlue = new CvColor(106, 90, 205);
        /// <summary>
        /// #708090
        /// </summary>
        public static readonly CvColor SlateGray = new CvColor(112, 128, 144);
        /// <summary>
        /// #FFFAFA
        /// </summary>
        public static readonly CvColor Snow = new CvColor(255, 250, 250);
        /// <summary>
        /// #00FF7F
        /// </summary>
        public static readonly CvColor SpringGreen = new CvColor(0, 255, 127);
        /// <summary>
        /// #4682B4
        /// </summary>
        public static readonly CvColor SteelBlue = new CvColor(70, 130, 180);
        /// <summary>
        /// #D2B48C
        /// </summary>
        public static readonly CvColor Tan = new CvColor(210, 180, 140);
        /// <summary>
        /// #008080
        /// </summary>
        public static readonly CvColor Teal = new CvColor(0, 128, 128);
        /// <summary>
        /// #D8BFD8
        /// </summary>
        public static readonly CvColor Thistle = new CvColor(216, 191, 216);
        /// <summary>
        /// #FF6347
        /// </summary>
        public static readonly CvColor Tomato = new CvColor(255, 99, 71);
        /// <summary>
        /// #40E0D0
        /// </summary>
        public static readonly CvColor Turquoise = new CvColor(64, 224, 208);
        /// <summary>
        /// #EE82EE
        /// </summary>
        public static readonly CvColor Violet = new CvColor(238, 130, 238);
        /// <summary>
        /// #F5DEB3
        /// </summary>
        public static readonly CvColor Wheat = new CvColor(245, 222, 179);
        /// <summary>
        /// #FFFFFF
        /// </summary>
        public static readonly CvColor White = new CvColor(255, 255, 255);
        /// <summary>
        /// #F5F5F5
        /// </summary>
        public static readonly CvColor WhiteSmoke = new CvColor(245, 245, 245);
        /// <summary>
        /// #FFFF00
        /// </summary>
        public static readonly CvColor Yellow = new CvColor(255, 255, 0);
        /// <summary>
        /// #9ACD32
        /// </summary>
        public static readonly CvColor YellowGreen = new CvColor(154, 205, 50);
        #endregion
    }
}
