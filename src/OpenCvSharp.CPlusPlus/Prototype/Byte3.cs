using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace OpenCvSharp.CPlusPlus.Prototype
{
    /// <summary>
    /// 3-Tuple of byte
    /// </summary>
    [Serializable]
    [StructLayout(LayoutKind.Sequential)]
    public struct Byte3
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
        /// 
        /// </summary>
        /// <param name="item1"></param>
        /// <param name="item2"></param>
        /// <param name="item3"></param>
        public Byte3(byte item1, byte item2, byte item3)
        {
            Item1 = item1;
            Item2 = item2;
            Item3 = item3;
        }
    }
}
