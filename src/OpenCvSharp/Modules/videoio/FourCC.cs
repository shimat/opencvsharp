using System;
using System.Runtime.InteropServices;

namespace OpenCvSharp
{
    /// <summary>
    /// 4-character code of codec used to compress the frames.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    // ReSharper disable once InconsistentNaming
    public readonly struct FourCC : IEquatable<FourCC>
    {
        /// <summary>
        /// int value
        /// </summary>
        public readonly int Value;

        #region Predefined values

        #pragma warning disable 1591
        // ReSharper disable IdentifierTypo

        public const int Default = -1;
        public const int Prompt = -1;

        public static readonly int AVC = FromString(nameof(AVC));
        public static readonly int CVID = FromString(nameof(CVID));
        public static readonly int DIB = FromString(nameof(DIB));
        public static readonly int DIV3 = FromString(nameof(DIV3));
        public static readonly int DIVX = FromString(nameof(DIVX));
        public static readonly int DV25 = FromString(nameof(DV25));
        public static readonly int DV50 = FromString(nameof(DV50));
        public static readonly int DVC = FromString(nameof(DVC));
        public static readonly int DVH1 = FromString(nameof(DVH1));
        public static readonly int DVHD = FromString(nameof(DVHD));
        public static readonly int DVSD = FromString(nameof(DVSD));
        public static readonly int DVSL = FromString(nameof(DVSL));
        public static readonly int H261 = FromString(nameof(H261));
        public static readonly int H263 = FromString(nameof(H263));
        public static readonly int H264 = FromString(nameof(X264));
        public static readonly int H265 = FromString(nameof(H265));
        public static readonly int HEVC = FromString(nameof(HEVC));
        public static readonly int I420 = FromString(nameof(I420));
        public static readonly int IV32 = FromString(nameof(IV32));
        public static readonly int IV41 = FromString(nameof(IV41));
        public static readonly int IV50 = FromString(nameof(IV50));
        public static readonly int IYUB = FromString(nameof(IYUB));
        public static readonly int IYUV = FromString(nameof(IYUV));
        public static readonly int MJPG = FromString(nameof(MJPG));
        public static readonly int M4S2 = FromString(nameof(M4S2));
        public static readonly int MP42 = FromString(nameof(MP42));
        public static readonly int MP43 = FromString(nameof(MP43));
        public static readonly int MP4S = FromString(nameof(MP4S));
        public static readonly int MP4V = FromString(nameof(MP4V));
        public static readonly int MPG1 = FromString(nameof(MPG1));
        public static readonly int MPG2 = FromString(nameof(MPG2));
        public static readonly int MPG4 = FromString(nameof(MPG4));
        public static readonly int MSS1 = FromString(nameof(MSS1));
        public static readonly int MSS2 = FromString(nameof(MSS2));
        public static readonly int MSVC = FromString(nameof(MSVC));
        public static readonly int JPEG = FromString(nameof(JPEG));
        public static readonly int PIM1 = FromString(nameof(PIM1));
        public static readonly int WMV1 = FromString(nameof(WMV1));
        public static readonly int WMV2 = FromString(nameof(WMV2));
        public static readonly int WMV3 = FromString(nameof(WMV3));
        public static readonly int WVC1 = FromString(nameof(WVC1));
        public static readonly int XVID = FromString(nameof(XVID));
        public static readonly int X264 = FromString(nameof(X264));

        // ReSharper restore IdentifierTypo
        #pragma warning restore 1591

        #endregion
        
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="value"></param>
        public FourCC(int value)
        {
            Value = value;
        }

        /// <summary>
        /// Create from four characters
        /// </summary>
        /// <param name="c1"></param>
        /// <param name="c2"></param>
        /// <param name="c3"></param>
        /// <param name="c4"></param>
        /// <returns></returns>
        public static FourCC FromFourChars(char c1, char c2, char c3, char c4)
        {
            var value = VideoWriter.FourCC(c1, c2, c3, c4);
            return new FourCC(value);
        }

        /// <summary>
        /// Create from string (length == 4)
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public static FourCC FromString(string code)
        {
            if (code == null)
                throw new ArgumentNullException(nameof(code));
            if (code.Length == 0)
                throw new ArgumentException("code.Length == 0", nameof(code));
            if (code.Length > 4)
                throw new ArgumentException("code.Length > 4", nameof(code));

            // padding
            while (code.Length < 4)
            {
                code += " ";
            }

            var value = VideoWriter.FourCC(code[0], code[1], code[2], code[3]);
            return new FourCC(value);
        }

        /// <summary>
        /// implicit cast to int
        /// </summary>
        /// <param name="fourcc"></param>
        public static implicit operator int(FourCC fourcc)
        {
            return fourcc.Value;
        }

        /// <summary>
        /// cast to int
        /// </summary>
        /// <returns></returns>
        public int ToInt32()
        {
            return Value;
        }

        /// <summary>
        /// implicit cast from int
        /// </summary>
        /// <param name="code"></param>
        public static implicit operator FourCC(int code)
        {
            return new FourCC(code);
        }

        /// <summary>
        /// cast from int
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public static FourCC FromInt32(int code)
        {
            return new FourCC(code);
        }

        /// <inheritdoc />
        public override bool Equals(object? obj)
        {
            if (obj is FourCC enumValue)
                return Equals(enumValue);
            return false;
        }

        /// <inheritdoc />
        public bool Equals(FourCC other)
        {
            return Value == other.Value;
        }

        /// <inheritdoc />
        public override int GetHashCode()
        {
            return Value.GetHashCode();
        }        

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator ==(FourCC left, FourCC right)
        {
            return left.Equals(right);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator !=(FourCC left, FourCC right)
        {
            return !(left == right);
        }
    }
}