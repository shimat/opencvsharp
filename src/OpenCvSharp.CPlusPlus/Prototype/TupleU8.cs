using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace OpenCvSharp.CPlusPlus.Prototype
{
    /// <summary>
    /// 2-Tuple of byte (System.Byte)
    /// </summary>
    [Serializable]
    [StructLayout(LayoutKind.Sequential)]
    public struct TupleU8C2
    {
        /// <summary>
        /// The value of the first component of this object.
        /// </summary>
        public byte Item1;
        /// <summary>
        /// The value of the second component of this object.
        /// </summary>
        public byte Item2;

        /// <summary>
        /// Initializer
        /// </summary>
        /// <param name="item1"></param>
        /// <param name="item2"></param>
        public TupleU8C2(byte item1, byte item2)
        {
            Item1 = item1;
            Item2 = item2;
        }
    }

    /// <summary>
    /// 3-Tuple of byte (System.Byte)
    /// </summary>
    [Serializable]
    [StructLayout(LayoutKind.Sequential)]
    public struct TupleU8C3
    {
        /// <summary>
        /// The value of the first component of this object.
        /// </summary>
        public byte Item1;
        /// <summary>
        /// The value of the second component of this object.
        /// </summary>
        public byte Item2;
        /// <summary>
        /// The value of the third component of this object.
        /// </summary>
        public byte Item3;

        /// <summary>
        /// Initializer
        /// </summary>
        /// <param name="item1"></param>
        /// <param name="item2"></param>
        /// <param name="item3"></param>
        public TupleU8C3(byte item1, byte item2, byte item3)
        {
            Item1 = item1;
            Item2 = item2;
            Item3 = item3;
        }
    }

    /// <summary>
    /// 4-Tuple of byte (System.Byte)
    /// </summary>
    [Serializable]
    [StructLayout(LayoutKind.Sequential)]
    public struct TupleU8C4
    {
        /// <summary>
        /// The value of the first component of this object.
        /// </summary>
        public byte Item1;

        /// <summary>
        /// The value of the second component of this object.
        /// </summary>
        public byte Item2;

        /// <summary>
        /// The value of the third component of this object.
        /// </summary>
        public byte Item3;

        /// <summary>
        /// The value of the fourth component of this object.
        /// </summary>
        public byte Item4;

        /// <summary>
        /// Initializer
        /// </summary>
        /// <param name="item1"></param>
        /// <param name="item2"></param>
        /// <param name="item3"></param>
        /// <param name="item4"></param>
        public TupleU8C4(byte item1, byte item2, byte item3, byte item4)
        {
            Item1 = item1;
            Item2 = item2;
            Item3 = item3;
            Item4 = item4;
        }
    }
}
