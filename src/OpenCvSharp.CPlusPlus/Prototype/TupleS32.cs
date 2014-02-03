using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace OpenCvSharp.CPlusPlus.Prototype
{
    /// <summary>
    /// 2-Tuple of int (System.Int32)
    /// </summary>
    [Serializable]
    [StructLayout(LayoutKind.Sequential)]
    public struct TupleS32C2
    {
        /// <summary>
        /// The value of the first component of this object.
        /// </summary>
        public int Item1;
        /// <summary>
        /// The value of the second component of this object.
        /// </summary>
        public int Item2;

        /// <summary>
        /// Initializer
        /// </summary>
        /// <param name="item1"></param>
        /// <param name="item2"></param>
        public TupleS32C2(int item1, int item2)
        {
            Item1 = item1;
            Item2 = item2;
        }
    }

    /// <summary>
    /// 3-Tuple of int (System.Int32)
    /// </summary>
    [Serializable]
    [StructLayout(LayoutKind.Sequential)]
    public struct TupleS32C3
    {
        /// <summary>
        /// The value of the first component of this object.
        /// </summary>
        public int Item1;
        /// <summary>
        /// The value of the second component of this object.
        /// </summary>
        public int Item2;
        /// <summary>
        /// The value of the third component of this object.
        /// </summary>
        public int Item3;

        /// <summary>
        /// Initializer
        /// </summary>
        /// <param name="item1"></param>
        /// <param name="item2"></param>
        /// <param name="item3"></param>
        public TupleS32C3(int item1, int item2, int item3)
        {
            Item1 = item1;
            Item2 = item2;
            Item3 = item3;
        }
    }

    /// <summary>
    /// 4-Tuple of int (System.Int32)
    /// </summary>
    [Serializable]
    [StructLayout(LayoutKind.Sequential)]
    public struct TupleS32C4
    {
        /// <summary>
        /// The value of the first component of this object.
        /// </summary>
        public int Item1;

        /// <summary>
        /// The value of the second component of this object.
        /// </summary>
        public int Item2;

        /// <summary>
        /// The value of the third component of this object.
        /// </summary>
        public int Item3;

        /// <summary>
        /// The value of the fourth component of this object.
        /// </summary>
        public int Item4;

        /// <summary>
        /// Initializer
        /// </summary>
        /// <param name="item1"></param>
        /// <param name="item2"></param>
        /// <param name="item3"></param>
        /// <param name="item4"></param>
        public TupleS32C4(int item1, int item2, int item3, int item4)
        {
            Item1 = item1;
            Item2 = item2;
            Item3 = item3;
            Item4 = item4;
        }
    }
}
