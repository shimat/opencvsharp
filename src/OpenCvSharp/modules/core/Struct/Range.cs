using System;
using System.Runtime.InteropServices;

namespace OpenCvSharp
{
    /// <summary>
    /// 
    /// </summary>
    [Serializable]
    [StructLayout(LayoutKind.Sequential)]
    public struct Range
    {
        /// <summary>
        /// 
        /// </summary>
        public int Start;

        /// <summary>
        /// 
        /// </summary>
        public int End;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="start"></param>
        /// <param name="end"></param>
        public Range(int start, int end)
        {
            Start = start;
            End = end;
        }

        /// <summary>
        /// 
        /// </summary>
        public static Range All
        {
            get { return new Range(Int32.MinValue, Int32.MaxValue); }
        }
    }
}
