using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace OpenCvSharp.CPlusPlus.Prototype
{
    /// <summary>
    /// 2-Tuple of short (System.Int16)
    /// </summary>
    [Serializable]
    [StructLayout(LayoutKind.Sequential)]
    public struct TupleS16C2
    {
        /// <summary>
        /// The value of the first component of this object.
        /// </summary>
        public short Item1;
        /// <summary>
        /// The value of the second component of this object.
        /// </summary>
        public short Item2;

        /// <summary>
        /// Initializer
        /// </summary>
        /// <param name="item1"></param>
        /// <param name="item2"></param>
        public TupleS16C2(short item1, short item2)
        {
            Item1 = item1;
            Item2 = item2;
        }
    }

    /// <summary>
    /// 3-Tuple of short (System.Int16)
    /// </summary>
    [Serializable]
    [StructLayout(LayoutKind.Sequential)]
    public struct TupleS16C3
    {
        /// <summary>
        /// The value of the first component of this object.
        /// </summary>
        public short Item1;
        /// <summary>
        /// The value of the second component of this object.
        /// </summary>
        public short Item2;
        /// <summary>
        /// The value of the third component of this object.
        /// </summary>
        public short Item3;

        /// <summary>
        /// Initializer
        /// </summary>
        /// <param name="item1"></param>
        /// <param name="item2"></param>
        /// <param name="item3"></param>
        public TupleS16C3(short item1, short item2, short item3)
        {
            Item1 = item1;
            Item2 = item2;
            Item3 = item3;
        }
    }

    /// <summary>
    /// 4-Tuple of short (System.Int16)
    /// </summary>
    [Serializable]
    [StructLayout(LayoutKind.Sequential)]
    public struct TupleS16C4
    {
        /// <summary>
        /// The value of the first component of this object.
        /// </summary>
        public short Item1;

        /// <summary>
        /// The value of the second component of this object.
        /// </summary>
        public short Item2;

        /// <summary>
        /// The value of the third component of this object.
        /// </summary>
        public short Item3;

        /// <summary>
        /// The value of the fourth component of this object.
        /// </summary>
        public short Item4;

        /// <summary>
        /// Initializer
        /// </summary>
        /// <param name="item1"></param>
        /// <param name="item2"></param>
        /// <param name="item3"></param>
        /// <param name="item4"></param>
        public TupleS16C4(short item1, short item2, short item3, short item4)
        {
            Item1 = item1;
            Item2 = item2;
            Item3 = item3;
            Item4 = item4;
        }
    }
}
