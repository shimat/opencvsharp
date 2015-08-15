using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace OpenCvSharp
{
    /// <summary>
    /// 2-Tuple of ushort (System.UInt16)
    /// </summary>
    [Serializable]
    [StructLayout(LayoutKind.Sequential)]
    public struct Vec2w : IVec<ushort>
    {
        /// <summary>
        /// The value of the first component of this object.
        /// </summary>
        public ushort Item0;

        /// <summary>
        /// The value of the second component of this object.
        /// </summary>
        public ushort Item1;

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
                        throw new ArgumentOutOfRangeException("i");
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
                        throw new ArgumentOutOfRangeException("i");
                }
            }
        }
    }

    /// <summary>
    /// 3-Tuple of ushort (System.UInt16)
    /// </summary>
    [Serializable]
    [StructLayout(LayoutKind.Sequential)]
    public struct Vec3w : IVec<ushort>
    {
        /// <summary>
        /// The value of the first component of this object.
        /// </summary>
        public ushort Item0;

        /// <summary>
        /// The value of the second component of this object.
        /// </summary>
        public ushort Item1;

        /// <summary>
        /// The value of the third component of this object.
        /// </summary>
        public ushort Item2;

        /// <summary>
        /// Initializer
        /// </summary>
        /// <param name="item0"></param>
        /// <param name="item1"></param>
        /// <param name="item2"></param>
        public Vec3w(ushort item0, ushort item1, ushort item2)
        {
            Item0 = item0;
            Item1 = item1;
            Item2 = item2;
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
                    case 2:
                        return Item2;
                    default:
                        throw new ArgumentOutOfRangeException("i");
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
                    case 2:
                        Item2 = value;
                        break;
                    default:
                        throw new ArgumentOutOfRangeException("i");
                }
            }
        }
    }

    /// <summary>
    /// 4-Tuple of ushort (System.UInt16)
    /// </summary>
    [Serializable]
    [StructLayout(LayoutKind.Sequential)]
    public struct Vec4w : IVec<ushort>
    {
        /// <summary>
        /// The value of the first component of this object.
        /// </summary>
        public ushort Item0;

        /// <summary>
        /// The value of the second component of this object.
        /// </summary>
        public ushort Item1;

        /// <summary>
        /// The value of the third component of this object.
        /// </summary>
        public ushort Item2;

        /// <summary>
        /// The value of the fourth component of this object.
        /// </summary>
        public ushort Item3;

        /// <summary>
        /// Initializer
        /// </summary>
        /// <param name="item0"></param>
        /// <param name="item1"></param>
        /// <param name="item2"></param>
        /// <param name="item3"></param>
        public Vec4w(ushort item0, ushort item1, ushort item2, ushort item3)
        {
            Item0 = item0;
            Item1 = item1;
            Item2 = item2;
            Item3 = item3;
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
                    case 2:
                        return Item2;
                    case 3:
                        return Item3;
                    default:
                        throw new ArgumentOutOfRangeException("i");
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
                    case 2:
                        Item2 = value;
                        break;
                    case 3:
                        Item3 = value;
                        break;
                    default:
                        throw new ArgumentOutOfRangeException("i");
                }
            }
        }
    }

    /// <summary>
    /// 4-Tuple of ushort (System.UInt16)
    /// </summary>
    [Serializable]
    [StructLayout(LayoutKind.Sequential)]
    public struct Vec6w : IVec<ushort>
    {
        /// <summary>
        /// The value of the first component of this object.
        /// </summary>
        public ushort Item0;

        /// <summary>
        /// The value of the second component of this object.
        /// </summary>
        public ushort Item1;

        /// <summary>
        /// The value of the third component of this object.
        /// </summary>
        public ushort Item2;

        /// <summary>
        /// The value of the fourth component of this object.
        /// </summary>
        public ushort Item3;

        /// <summary>
        /// The value of the fifth component of this object.
        /// </summary>
        public ushort Item4;

        /// <summary>
        /// The value of the sixth component of this object.
        /// </summary>
        public ushort Item5;

        /// <summary>
        /// Initializer
        /// </summary>
        /// <param name="item0"></param>
        /// <param name="item1"></param>
        /// <param name="item2"></param>
        /// <param name="item3"></param>
        /// <param name="item4"></param>
        /// <param name="item5"></param>
        public Vec6w(ushort item0, ushort item1, ushort item2, ushort item3, ushort item4, ushort item5)
        {
            Item0 = item0;
            Item1 = item1;
            Item2 = item2;
            Item3 = item3;
            Item4 = item4;
            Item5 = item5;
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
                    case 2:
                        return Item2;
                    case 3:
                        return Item3;
                    case 4:
                        return Item4;
                    case 5:
                        return Item5;
                    default:
                        throw new ArgumentOutOfRangeException("i");
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
                    case 2:
                        Item2 = value;
                        break;
                    case 3:
                        Item3 = value;
                        break;
                    case 4:
                        Item4 = value;
                        break;
                    case 5:
                        Item5 = value;
                        break;
                    default:
                        throw new ArgumentOutOfRangeException("i");
                }
            }
        }
    }
}
