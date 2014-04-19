using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace OpenCvSharp.CPlusPlus
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
        /// <param name="self"></param>
        /// <returns></returns>
        public static implicit operator CvSlice(Range self)
        {
            return new CvSlice(self.Start, self.End);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="slice"></param>
        /// <returns></returns>
        public static implicit operator Range(CvSlice slice)
        {
            return new Range(slice.StartIndex, slice.EndIndex);
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
