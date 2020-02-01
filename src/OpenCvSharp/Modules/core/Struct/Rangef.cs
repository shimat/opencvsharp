using System;
using System.Runtime.InteropServices;

#pragma warning disable CA1051

namespace OpenCvSharp
{
    /// <summary>
    /// float Range class
    /// </summary>
    [Serializable]
    [StructLayout(LayoutKind.Sequential)]
    public readonly struct Rangef
    {
        /// <summary>
        /// 
        /// </summary>
        public readonly float Start;

        /// <summary>
        /// 
        /// </summary>
        public readonly float End;

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
