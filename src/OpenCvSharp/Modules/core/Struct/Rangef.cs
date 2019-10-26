using System;
using System.Runtime.InteropServices;

namespace OpenCvSharp
{
    /// <summary>
    /// float Range class
    /// </summary>
    [Serializable]
    [StructLayout(LayoutKind.Sequential)]
    public struct Rangef
    {
        /// <summary>
        /// 
        /// </summary>
        public float Start;

        /// <summary>
        /// 
        /// </summary>
        public float End;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="start"></param>
        /// <param name="end"></param>
        public Rangef(float start, float end)
        {
            Start = start;
            End = end;
        }

        /// <summary>
        /// Implicit operator (Range)this
        /// </summary>
        /// <param name="range"></param>
        /// <returns></returns>
        public static implicit operator Range(Rangef range)
        {
            return new Range((int)range.Start, (int)range.End);
        }

        /// <summary>
        /// Range(int.MinValue, int.MaxValue)
        /// </summary>
        public static Range All => new Range(int.MinValue, int.MaxValue);
    }
}
