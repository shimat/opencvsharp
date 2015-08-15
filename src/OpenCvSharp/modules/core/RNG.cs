using System;
using System.Collections.Generic;
using System.Text;

namespace OpenCvSharp
{
    /// <summary>
    /// Random Number Generator.
    /// The class implements RNG using Multiply-with-Carry algorithm.
    /// </summary>
    public class RNG
    {
        /// <summary>
        /// 
        /// </summary>
        public ulong State { get; set; }

        #region Init & Disposal
        /// <summary>
        /// 
        /// </summary>
        public RNG()
        {
            State = NativeMethods.core_RNG_new();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="state"></param>
        public RNG(ulong state)
        {
            State = NativeMethods.core_RNG_new(state);
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
            if(self == null)
                throw new ArgumentNullException("self");
            return NativeMethods.core_RNG_operator_uchar(self.State);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="self"></param>
        /// <returns></returns>
        public static explicit operator sbyte(RNG self)
        {
            if (self == null)
                throw new ArgumentNullException("self");
            return NativeMethods.core_RNG_operator_schar(self.State);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="self"></param>
        /// <returns></returns>
        public static explicit operator ushort(RNG self)
        {
            if (self == null)
                throw new ArgumentNullException("self");
            return NativeMethods.core_RNG_operator_ushort(self.State);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="self"></param>
        /// <returns></returns>
        public static explicit operator short(RNG self)
        {
            if (self == null)
                throw new ArgumentNullException("self");
            return NativeMethods.core_RNG_operator_short(self.State);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="self"></param>
        /// <returns></returns>
        public static explicit operator uint(RNG self)
        {
            if (self == null)
                throw new ArgumentNullException("self");
            return NativeMethods.core_RNG_operator_uint(self.State);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="self"></param>
        /// <returns></returns>
        public static explicit operator int(RNG self)
        {
            if (self == null)
                throw new ArgumentNullException("self");
            return NativeMethods.core_RNG_operator_int(self.State);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="self"></param>
        /// <returns></returns>
        public static explicit operator float(RNG self)
        {
            if (self == null)
                throw new ArgumentNullException("self");
            return NativeMethods.core_RNG_operator_float(self.State);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="self"></param>
        /// <returns></returns>
        public static explicit operator double(RNG self)
        {
            if (self == null)
                throw new ArgumentNullException("self");
            return NativeMethods.core_RNG_operator_double(self.State);
        }
        #endregion

        #region Methods
        /// <summary>
        /// updates the state and returns the next 32-bit unsigned integer random number
        /// </summary>
        /// <returns></returns>
        public uint Next()
        {
            return NativeMethods.core_RNG_next(State);
        }

        /// <summary>
        /// returns a random integer sampled uniformly from [0, N).
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public uint Run(uint n)
        {
            return NativeMethods.core_RNG_operatorThis(State, n);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public uint Run()
        {
            return NativeMethods.core_RNG_operatorThis(State);
        }

        /// <summary>
        /// returns uniformly distributed integer random number from [a,b) range
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public int Uniform(int a, int b)
        {
            return NativeMethods.core_RNG_uniform(State, a, b);
        }
        /// <summary>
        /// returns uniformly distributed floating-point random number from [a,b) range
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public float Uniform(float a, float b)
        {
            return NativeMethods.core_RNG_uniform(State, a, b);
        }
        /// <summary>
        /// returns uniformly distributed double-precision floating-point random number from [a,b) range
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public double Uniform(double a, double b)
        {
            return NativeMethods.core_RNG_uniform(State, a, b);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="mat"></param>
        /// <param name="distType"></param>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="saturateRange"></param>
        public void Fill(InputOutputArray mat, DistributionType distType, InputArray a, InputArray b, bool saturateRange = false)
        {
            if (mat == null)
                throw new ArgumentNullException("mat");
            if (a == null)
                throw new ArgumentNullException("a");
            if (b == null)
                throw new ArgumentNullException("b");
            mat.ThrowIfNotReady();
            a.ThrowIfDisposed();
            b.ThrowIfDisposed();
            NativeMethods.core_RNG_fill(State, mat.CvPtr, (int)distType, a.CvPtr, b.CvPtr, saturateRange ? 1 : 0);
            mat.Fix();
        }

        /// <summary>
        /// returns Gaussian random variate with mean zero.
        /// </summary>
        /// <param name="sigma"></param>
        /// <returns></returns>
        public double Gaussian(double sigma)
        {
            return NativeMethods.core_RNG_gaussian(State, sigma);
        }
        #endregion
    }
}
