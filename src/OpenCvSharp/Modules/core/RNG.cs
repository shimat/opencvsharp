using System;
using System.Collections.Generic;
using System.Text;

namespace OpenCvSharp
{
    /// <summary>
    /// Random Number Generator.
    /// The class implements RNG using Multiply-with-Carry algorithm.
    /// </summary>
    /// <remarks>operations.hpp</remarks>
    public class RNG
    {
        private ulong state;

        /// <summary>
        /// 
        /// </summary>
        public ulong State
        {
            get { return state; }
            set { state = value; }
        }

        #region Init & Disposal

        /// <summary>
        /// 
        /// </summary>
        public RNG()
        {
            this.state = 0xffffffff;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="state"></param>
        public RNG(ulong state)
        {
            this.state = (state != 0) ? state : 0xffffffff;
        }

        #endregion

        #region Cast

        /// <summary>
        /// 
        /// </summary>
        /// <param name="self"></param>
        /// <returns></returns>
        public static explicit operator byte(RNG self)
        {
            if (self == null)
                throw new ArgumentNullException(nameof(self));
            return (byte) self.Next();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="self"></param>
        /// <returns></returns>
        public static explicit operator sbyte(RNG self)
        {
            if (self == null)
                throw new ArgumentNullException(nameof(self));
            return (sbyte)self.Next();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="self"></param>
        /// <returns></returns>
        public static explicit operator ushort(RNG self)
        {
            if (self == null)
                throw new ArgumentNullException(nameof(self));
            return (ushort)self.Next();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="self"></param>
        /// <returns></returns>
        public static explicit operator short(RNG self)
        {
            if (self == null)
                throw new ArgumentNullException(nameof(self));
            return (short)self.Next();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="self"></param>
        /// <returns></returns>
        public static explicit operator uint(RNG self)
        {
            if (self == null)
                throw new ArgumentNullException(nameof(self));
            return self.Next();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="self"></param>
        /// <returns></returns>
        public static explicit operator int(RNG self)
        {
            if (self == null)
                throw new ArgumentNullException(nameof(self));
            return (int)self.Next();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="self"></param>
        /// <returns></returns>
        public static explicit operator float(RNG self)
        {
            if (self == null)
                throw new ArgumentNullException(nameof(self));
            return self.Next() * 2.3283064365386962890625e-10f; 
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="self"></param>
        /// <returns></returns>
        public static explicit operator double(RNG self)
        {
            if (self == null)
                throw new ArgumentNullException(nameof(self));
            uint t = self.Next();
            return (((ulong)t << 32) | self.Next()) * 5.4210108624275221700372640043497e-20;
        }

        #endregion

        #region Methods

        /// <summary>
        /// updates the state and returns the next 32-bit unsigned integer random number
        /// </summary>
        /// <returns></returns>
        public uint Next()
        {
            state = (ulong)(uint)State * /*CV_RNG_COEFF*/ 4164903690U + (uint)(State >> 32);
            return (uint)State;
        }

        /// <summary>
        /// returns a random integer sampled uniformly from [0, N).
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public uint Run(uint n)
        {
            return (uint)Uniform(0, n);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public uint Run()
        {
            return Next();
        }

        /// <summary>
        /// returns uniformly distributed integer random number from [a,b) range
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public int Uniform(int a, int b)
        {
            return a == b ? a : (int)(Next() % (b - a) + a);
        }

        /// <summary>
        /// returns uniformly distributed floating-point random number from [a,b) range
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public float Uniform(float a, float b)
        {
            return ((float)this) * (b - a) + a;
        }

        /// <summary>
        /// returns uniformly distributed double-precision floating-point random number from [a,b) range
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public double Uniform(double a, double b)
        {
            return ((double)this) * (b - a) + a;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="mat"></param>
        /// <param name="distType"></param>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="saturateRange"></param>
        public void Fill(InputOutputArray mat, DistributionType distType, InputArray a, InputArray b,
            bool saturateRange = false)
        {
            if (mat == null)
                throw new ArgumentNullException(nameof(mat));
            if (a == null)
                throw new ArgumentNullException(nameof(a));
            if (b == null)
                throw new ArgumentNullException(nameof(b));
            mat.ThrowIfNotReady();
            a.ThrowIfDisposed();
            b.ThrowIfDisposed();
            NativeMethods.core_RNG_fill(ref state, mat.CvPtr, (int) distType, a.CvPtr, b.CvPtr, saturateRange ? 1 : 0);
            mat.Fix();
            GC.KeepAlive(mat);
            GC.KeepAlive(a);
            GC.KeepAlive(b);
        }

        /// <summary>
        /// returns Gaussian random variate with mean zero.
        /// </summary>
        /// <param name="sigma"></param>
        /// <returns></returns>
        public double Gaussian(double sigma)
        {
            return NativeMethods.core_RNG_gaussian(ref state, sigma);
        }

        #endregion
    }
}
