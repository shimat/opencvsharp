using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace OpenCvSharp.CPlusPlus
{
    /// <summary>
    /// 2-Tuple of ushort (System.UInt16)
    /// </summary>
    [Serializable]
    [StructLayout(LayoutKind.Sequential)]
    public struct Vec2w : IVec
    {
        /// <summary>
        /// The value of the first component of this object.
        /// </summary>
        public ushort Item1;
        /// <summary>
        /// The value of the second component of this object.
        /// </summary>
        public ushort Item2;

        /// <summary>
        /// Initializer
        /// </summary>
        /// <param name="item1"></param>
        /// <param name="item2"></param>
        public Vec2w(ushort item1, ushort item2)
        {
            Item1 = item1;
            Item2 = item2;
        }
    }

    /// <summary>
    /// 3-Tuple of ushort (System.UInt16)
    /// </summary>
    [Serializable]
    [StructLayout(LayoutKind.Sequential)]
    public struct Vec3w : IVec
    {
        /// <summary>
        /// The value of the first component of this object.
        /// </summary>
        public ushort Item1;
        /// <summary>
        /// The value of the second component of this object.
        /// </summary>
        public ushort Item2;
        /// <summary>
        /// The value of the third component of this object.
        /// </summary>
        public ushort Item3;

        /// <summary>
        /// Initializer
        /// </summary>
        /// <param name="item1"></param>
        /// <param name="item2"></param>
        /// <param name="item3"></param>
        public Vec3w(ushort item1, ushort item2, ushort item3)
        {
            Item1 = item1;
            Item2 = item2;
            Item3 = item3;
        }
    }

    /// <summary>
    /// 4-Tuple of ushort (System.UInt16)
    /// </summary>
    [Serializable]
    [StructLayout(LayoutKind.Sequential)]
    public struct Vec4w : IVec
    {
        /// <summary>
        /// The value of the first component of this object.
        /// </summary>
        public ushort Item1;

        /// <summary>
        /// The value of the second component of this object.
        /// </summary>
        public ushort Item2;

        /// <summary>
        /// The value of the third component of this object.
        /// </summary>
        public ushort Item3;

        /// <summary>
        /// The value of the fourth component of this object.
        /// </summary>
        public ushort Item4;

        /// <summary>
        /// Initializer
        /// </summary>
        /// <param name="item1"></param>
        /// <param name="item2"></param>
        /// <param name="item3"></param>
        /// <param name="item4"></param>
        public Vec4w(ushort item1, ushort item2, ushort item3, ushort item4)
        {
            Item1 = item1;
            Item2 = item2;
            Item3 = item3;
            Item4 = item4;
        }
    }
    
    /// <summary>
    /// 4-Tuple of ushort (System.UInt16)
    /// </summary>
    [Serializable]
    [StructLayout(LayoutKind.Sequential)]
    public struct Vec6w : IVec
    {
        /// <summary>
        /// The value of the first component of this object.
        /// </summary>
        public ushort Item1;

        /// <summary>
        /// The value of the second component of this object.
        /// </summary>
        public ushort Item2;

        /// <summary>
        /// The value of the third component of this object.
        /// </summary>
        public ushort Item3;

        /// <summary>
        /// The value of the fourth component of this object.
        /// </summary>
        public ushort Item4;

        /// <summary>
        /// The value of the fifth component of this object.
        /// </summary>
        public ushort Item5;

        /// <summary>
        /// The value of the sixth component of this object.
        /// </summary>
        public ushort Item6;

        /// <summary>
        /// Initializer
        /// </summary>
        /// <param name="item1"></param>
        /// <param name="item2"></param>
        /// <param name="item3"></param>
        /// <param name="item4"></param>
        /// <param name="item5"></param>
        /// <param name="item6"></param>
        public Vec6w(ushort item1, ushort item2, ushort item3, ushort item4, ushort item5, ushort item6)
        {
            Item1 = item1;
            Item2 = item2;
            Item3 = item3;
            Item4 = item4;
            Item5 = item5;
            Item6 = item6;
        }
    }
}
