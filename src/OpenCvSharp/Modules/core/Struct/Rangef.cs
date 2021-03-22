using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;

namespace OpenCvSharp
{
    /// <summary>
    /// float Range class
    /// </summary>
    [Serializable]
    [StructLayout(LayoutKind.Sequential)]
    [SuppressMessage("Design", "CA1051: Do not declare visible instance fields")]
    // ReSharper disable once IdentifierTypo
    public readonly struct Rangef : IEquatable<Rangef>
    {
        /// <summary>
        /// 
        /// </summary>
        public readonly float Start;

        /// <summary>
        /// 
        /// </summary>
        public readonly float End;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="start"></param>
        /// <param name="end"></param>
        // ReSharper disable once IdentifierTypo
        public Rangef(float start, float end)
        {
            Start = start;
            End = end;
        }

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

#pragma warning disable CS1591
        public bool Equals(Rangef other)
        {
            return Start.Equals(other.Start) && End.Equals(other.End);
        }

        public override bool Equals(object? obj)
        {
            return obj is Rangef other && Equals(other);
        }

        public override int GetHashCode()
        {
#if DOTNET_FRAMEWORK || NETSTANDARD2_0
            unchecked
            {
                var hashCode = Start.GetHashCode();
                hashCode = (hashCode * 397) ^ End.GetHashCode();
                return hashCode;
            }
#else
            return HashCode.Combine(Start, End);
#endif
        }

        public static bool operator ==(Rangef left, Rangef right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(Rangef left, Rangef right)
        {
            return !left.Equals(right);
        }
#pragma warning restore CS1591
    }
}
