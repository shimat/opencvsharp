using System;
using System.Runtime.InteropServices;

#pragma warning disable CA1051

namespace OpenCvSharp
{
    /// <summary>
    /// 2-Tuple of ushort (System.UInt16)
    /// </summary>
    [Serializable]
    [StructLayout(LayoutKind.Sequential)]
    // ReSharper disable once InconsistentNaming
    public struct Vec2w : IVec<ushort>, IEquatable<Vec2w>
    {
        /// <summary>
        /// The value of the first component of this object.
        /// </summary>
        public ushort Item0;

        /// <summary>
        /// The value of the second component of this object.
        /// </summary>
        public ushort Item1;

#if !DOTNET_FRAMEWORK
        /// <summary>
        /// Deconstructing a Vector
        /// </summary>
        /// <param name="item0"></param>
        /// <param name="item1"></param>
        public void Deconstruct(out ushort item0, out ushort item1) => (item0, item1) = (Item0, Item1);
#endif

        /// <summary>
        /// Initializer
        /// </summary>
        /// <param name="item0"></param>
        /// <param name="item1"></param>
        public Vec2w(ushort item0, ushort item1)
        {
            Item0 = item0;
            Item1 = item1;
        }

        /// <summary>
        /// Indexer
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        public ushort this[int i]
        {
            get
            {
                switch (i)
                {
                    case 0:
                        return Item0;
                    case 1:
                        return Item1;
                    default:
                        throw new ArgumentOutOfRangeException(nameof(i));
                }
            }
            set
            {
                switch (i)
                {
                    case 0:
                        Item0 = value;
                        break;
                    case 1:
                        Item1 = value;
                        break;
                    default:
                        throw new ArgumentOutOfRangeException(nameof(i));
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public bool Equals(Vec2w other)
        {
            return Item0 == other.Item0 && Item1 == other.Item1;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object? obj)
        {
            if (obj is null) return false;
            return obj is Vec2w w && Equals(w);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static bool operator ==(Vec2w a, Vec2w b)
        {
            return a.Equals(b);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static bool operator !=(Vec2w a, Vec2w b)
        {
            return !a.Equals(b);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            unchecked
            {
                return (Item0.GetHashCode() * 397) ^ Item1.GetHashCode();
            }
        }

        /// <inheritdoc />
        public override string ToString()
        {
            return $"{GetType().Name} ({Item0}, {Item1})";
        }
    }
}