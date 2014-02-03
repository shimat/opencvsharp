using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace OpenCvSharp.CPlusPlus.Prototype
{
    /// <summary>
    /// 2-Tuple of long (System.Int64)
    /// </summary>
    [Serializable]
    [StructLayout(LayoutKind.Sequential)]
    public struct TupleS64C2
    {
        /// <summary>
        /// The value of the first component of this object.
        /// </summary>
        public long Item1;
        /// <summary>
        /// The value of the second component of this object.
        /// </summary>
        public long Item2;

        /// <summary>
        /// Initializer
        /// </summary>
        /// <param name="item1"></param>
        /// <param name="item2"></param>
        public TupleS64C2(long item1, long item2)
        {
            Item1 = item1;
            Item2 = item2;
        }
    }

    /// <summary>
    /// 3-Tuple of long (System.Int64)
    /// </summary>
    [Serializable]
    [StructLayout(LayoutKind.Sequential)]
    public struct TupleS64C3
    {
        /// <summary>
        /// The value of the first component of this object.
        /// </summary>
        public long Item1;
        /// <summary>
        /// The value of the second component of this object.
        /// </summary>
        public long Item2;
        /// <summary>
        /// The value of the third component of this object.
        /// </summary>
        public long Item3;

        /// <summary>
        /// Initializer
        /// </summary>
        /// <param name="item1"></param>
        /// <param name="item2"></param>
        /// <param name="item3"></param>
        public TupleS64C3(long item1, long item2, long item3)
        {
            Item1 = item1;
            Item2 = item2;
            Item3 = item3;
        }
    }

    /// <summary>
    /// 4-Tuple of long (System.Int64)
    /// </summary>
    [Serializable]
    [StructLayout(LayoutKind.Sequential)]
    public struct TupleS64C4
    {
        /// <summary>
        /// The value of the first component of this object.
        /// </summary>
        public long Item1;

        /// <summary>
        /// The value of the second component of this object.
        /// </summary>
        public long Item2;

        /// <summary>
        /// The value of the third component of this object.
        /// </summary>
        public long Item3;

        /// <summary>
        /// The value of the fourth component of this object.
        /// </summary>
        public long Item4;

        /// <summary>
        /// Initializer
        /// </summary>
        /// <param name="item1"></param>
        /// <param name="item2"></param>
        /// <param name="item3"></param>
        /// <param name="item4"></param>
        public TupleS64C4(long item1, long item2, long item3, long item4)
        {
            Item1 = item1;
            Item2 = item2;
            Item3 = item3;
            Item4 = item4;
        }
    }
}
