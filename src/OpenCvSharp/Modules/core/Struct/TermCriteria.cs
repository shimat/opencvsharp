using System;

#pragma warning disable CA1051

namespace OpenCvSharp
{
    /// <summary>
    /// The class defining termination criteria for iterative algorithms.
    /// </summary>
    public readonly struct TermCriteria : IEquatable<TermCriteria>
    {
        /// <summary>
        /// the type of termination criteria: COUNT, EPS or COUNT + EPS
        /// </summary>
        public readonly CriteriaTypes Type;

        /// <summary>
        /// the maximum number of iterations/elements
        /// </summary>
        public readonly int MaxCount;

        /// <summary>
        /// the desired accuracy
        /// </summary>
        public readonly double Epsilon;

        /// <summary>
        /// full constructor
        /// </summary>
        /// <param name="type"></param>
        /// <param name="maxCount"></param>
        /// <param name="epsilon"></param>
        public TermCriteria(CriteriaTypes type, int maxCount, double epsilon)
        {
            Type = type;
            MaxCount = maxCount;
            Epsilon = epsilon;
        }

        /// <summary>
        /// full constructor with both type (count | epsilon)
        /// </summary>
        /// <param name="maxCount"></param>
        /// <param name="epsilon"></param>
        public static TermCriteria Both(int maxCount, double epsilon)
        {
            return new (
                type: CriteriaTypes.Count | CriteriaTypes.Eps,
                maxCount: maxCount,
                epsilon: epsilon);
        }

#pragma warning disable CS1591

        public bool Equals(TermCriteria other)
        {
            return Type == other.Type && MaxCount == other.MaxCount && Epsilon.Equals(other.Epsilon);
        }

        public override bool Equals(object? obj)
        {
            return obj is TermCriteria other && Equals(other);
        }

        public override int GetHashCode()
        {
#if DOTNET_FRAMEWORK || NETSTANDARD2_0
            unchecked
            {
                var hashCode = Type.GetHashCode();
                hashCode = (hashCode * 397) ^ MaxCount.GetHashCode();
                hashCode = (hashCode * 397) ^ Epsilon.GetHashCode();
                return hashCode;
            }
#else
            return HashCode.Combine((int) Type, MaxCount, Epsilon);
#endif
        }

        public static bool operator ==(TermCriteria left, TermCriteria right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(TermCriteria left, TermCriteria right)
        {
            return !left.Equals(right);
        }

#pragma warning restore CS1591
    }
}
