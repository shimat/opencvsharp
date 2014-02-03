using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace OpenCvSharp.CPlusPlus.Prototype
{
    /// <summary>
    /// 2-Tuple of float (System.Single)
    /// </summary>
    [Serializable]
    [StructLayout(LayoutKind.Sequential)]
    public struct SingleTuple2
    {
        /// <summary>
        /// The value of the first component of this object.
        /// </summary>
        public float Item1;
        /// <summary>
        /// The value of the second component of this object.
        /// </summary>
        public float Item2;

        /// <summary>
        /// Initializer
        /// </summary>
        /// <param name="item1"></param>
        /// <param name="item2"></param>
        public SingleTuple2(float item1, float item2)
        {
            Item1 = item1;
            Item2 = item2;
        }
    }

    /// <summary>
    /// 3-Tuple of float (System.Single)
    /// </summary>
    [Serializable]
    [StructLayout(LayoutKind.Sequential)]
    public struct SingleTuple3
    {
        /// <summary>
        /// The value of the first component of this object.
        /// </summary>
        public float Item1;
        /// <summary>
        /// The value of the second component of this object.
        /// </summary>
        public float Item2;
        /// <summary>
        /// The value of the third component of this object.
        /// </summary>
        public float Item3;

        /// <summary>
        /// Initializer
        /// </summary>
        /// <param name="item1"></param>
        /// <param name="item2"></param>
        /// <param name="item3"></param>
        public SingleTuple3(float item1, float item2, float item3)
        {
            Item1 = item1;
            Item2 = item2;
            Item3 = item3;
        }
    }

    /// <summary>
    /// 4-Tuple of float (System.Single)
    /// </summary>
    [Serializable]
    [StructLayout(LayoutKind.Sequential)]
    public struct SingleTuple4
    {
        /// <summary>
        /// The value of the first component of this object.
        /// </summary>
        public float Item1;

        /// <summary>
        /// The value of the second component of this object.
        /// </summary>
        public float Item2;

        /// <summary>
        /// The value of the third component of this object.
        /// </summary>
        public float Item3;

        /// <summary>
        /// The value of the fourth component of this object.
        /// </summary>
        public float Item4;

        /// <summary>
        /// Initializer
        /// </summary>
        /// <param name="item1"></param>
        /// <param name="item2"></param>
        /// <param name="item3"></param>
        /// <param name="item4"></param>
        public SingleTuple4(float item1, float item2, float item3, float item4)
        {
            Item1 = item1;
            Item2 = item2;
            Item3 = item3;
            Item4 = item4;
        }
    }
}
