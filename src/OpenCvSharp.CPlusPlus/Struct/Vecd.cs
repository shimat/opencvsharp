using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace OpenCvSharp.CPlusPlus
{
    /// <summary>
    /// 2-Tuple of double (System.Double)
    /// </summary>
    [Serializable]
    [StructLayout(LayoutKind.Sequential)]
    public struct Vec2d : IVec
    {
        /// <summary>
        /// The value of the first component of this object.
        /// </summary>
        public double Item1;
        /// <summary>
        /// The value of the second component of this object.
        /// </summary>
        public double Item2;

        /// <summary>
        /// Initializer
        /// </summary>
        /// <param name="item1"></param>
        /// <param name="item2"></param>
        public Vec2d(double item1, double item2)
        {
            Item1 = item1;
            Item2 = item2;
        }
    }

    /// <summary>
    /// 3-Tuple of double (System.Double)
    /// </summary>
    [Serializable]
    [StructLayout(LayoutKind.Sequential)]
    public struct Vec3d : IVec
    {
        /// <summary>
        /// The value of the first component of this object.
        /// </summary>
        public double Item1;
        /// <summary>
        /// The value of the second component of this object.
        /// </summary>
        public double Item2;
        /// <summary>
        /// The value of the third component of this object.
        /// </summary>
        public double Item3;

        /// <summary>
        /// Initializer
        /// </summary>
        /// <param name="item1"></param>
        /// <param name="item2"></param>
        /// <param name="item3"></param>
        public Vec3d(double item1, double item2, double item3)
        {
            Item1 = item1;
            Item2 = item2;
            Item3 = item3;
        }
    }

    /// <summary>
    /// 4-Tuple of double (System.Double)
    /// </summary>
    [Serializable]
    [StructLayout(LayoutKind.Sequential)]
    public struct Vec4d : IVec
    {
        /// <summary>
        /// The value of the first component of this object.
        /// </summary>
        public double Item1;

        /// <summary>
        /// The value of the second component of this object.
        /// </summary>
        public double Item2;

        /// <summary>
        /// The value of the third component of this object.
        /// </summary>
        public double Item3;

        /// <summary>
        /// The value of the fourth component of this object.
        /// </summary>
        public double Item4;

        /// <summary>
        /// Initializer
        /// </summary>
        /// <param name="item1"></param>
        /// <param name="item2"></param>
        /// <param name="item3"></param>
        /// <param name="item4"></param>
        public Vec4d(double item1, double item2, double item3, double item4)
        {
            Item1 = item1;
            Item2 = item2;
            Item3 = item3;
            Item4 = item4;
        }
    }

    /// <summary>
    /// 6-Tuple of double (System.Double)
    /// </summary>
    [Serializable]
    [StructLayout(LayoutKind.Sequential)]
    public struct Vec6d : IVec
    {
        /// <summary>
        /// The value of the first component of this object.
        /// </summary>
        public double Item1;

        /// <summary>
        /// The value of the second component of this object.
        /// </summary>
        public double Item2;

        /// <summary>
        /// The value of the third component of this object.
        /// </summary>
        public double Item3;

        /// <summary>
        /// The value of the fourth component of this object.
        /// </summary>
        public double Item4;

        /// <summary>
        /// The value of the fifth component of this object.
        /// </summary>
        public double Item5;

        /// <summary>
        /// The value of the sixth component of this object.
        /// </summary>
        public double Item6;

        /// <summary>
        /// Initializer
        /// </summary>
        /// <param name="item1"></param>
        /// <param name="item2"></param>
        /// <param name="item3"></param>
        /// <param name="item4"></param>
        public Vec6d(double item1, double item2, double item3, double item4, double item5, double item6)
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
