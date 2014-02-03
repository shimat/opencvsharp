using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace OpenCvSharp.CPlusPlus.Prototype
{
    /// <summary>
    /// 2-Tuple of double (System.Double)
    /// </summary>
    [Serializable]
    [StructLayout(LayoutKind.Sequential)]
    public struct DoubleTuple2
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
        public DoubleTuple2(double item1, double item2)
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
    public struct DoubleTuple3
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
        public DoubleTuple3(double item1, double item2, double item3)
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
    public struct DoubleTuple4
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
        public DoubleTuple4(double item1, double item2, double item3, double item4)
        {
            Item1 = item1;
            Item2 = item2;
            Item3 = item3;
            Item4 = item4;
        }
    }
}
