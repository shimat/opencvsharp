using System;
using System.Runtime.InteropServices;

#pragma warning disable CA1051

namespace OpenCvSharp
{
    /// <summary>
    /// Template class specifying a continuous subsequence (slice) of a sequence.
    /// </summary>
    [Serializable]
    [StructLayout(LayoutKind.Sequential)]
    public readonly struct Range : IEquatable<Range>
    {
        /// <summary>
        /// 
        /// </summary>
        public readonly int Start;

        /// <summary>
        /// 
        /// </summary>
        public readonly int End;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="start"></param>
        /// <param name="end"></param>
        public Range(int start, int end)
        {
            Start = start;
            End = end;
        }

        /// <summary>
        /// 
        /// </summary>
        public static Range All => new Range(int.MinValue, int.MaxValue);
        
        /// <inheritdoc />
        public readonly bool Equals(Range other)
        {
            return Start == other.Start && End == other.End;
        }

        /// <inheritdoc />
        public override readonly bool Equals(object? obj)
        {
            return obj is Range other && Equals(other);
        }

        /// <inheritdoc />
        public override readonly int GetHashCode()
        {
            unchecked
            {
                return (Start * 397) ^ End;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator ==(Range left, Range right)
        {
            return left.Equals(right);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator !=(Range left, Range right)
        {
            return !(left == right);
        }
    }
}
