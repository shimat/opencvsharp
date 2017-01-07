using System;
using System.Collections.Generic;
using System.Text;

namespace OpenCvSharp
{
    /// <summary>
    /// Mersenne Twister random number generator
    /// </summary>
    /// <remarks>operations.hpp</remarks>
    // ReSharper disable once InconsistentNaming
    public class RNG_MT19937
    {
        private static class PeriodParameters
        {
            public const int N = 624, M = 397;
        }
        private readonly uint[] state;
        private int mti;

        #region Init & Disposal

        /// <summary>
        /// 
        /// </summary>
        public RNG_MT19937()
            : this(5489U)
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="s"></param>
        public RNG_MT19937(uint s)
        {
            state = new uint[PeriodParameters.N];
            Seed(s);
        }

        #endregion

        #region Cast

        /// <summary>
        /// 
        /// </summary>
        /// <param name="self"></param>
        /// <returns></returns>
        public static explicit operator uint(RNG_MT19937 self)
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
        public static explicit operator int(RNG_MT19937 self)
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
        public static explicit operator float(RNG_MT19937 self)
        {
            if (self == null)
                throw new ArgumentNullException(nameof(self));
            return self.Next() * (1.0f / 4294967296.0f);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="self"></param>
        /// <returns></returns>
        public static explicit operator double(RNG_MT19937 self)
        {
            if (self == null)
                throw new ArgumentNullException(nameof(self));
            uint a = self.Next() >> 5;
            uint b = self.Next() >> 6;
            return (a * 67108864.0 + b) * (1.0 / 9007199254740992.0);
        }

        #endregion

        #region Methods

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public void Seed(uint s)
        {
            state[0] = s;
            for (mti = 1; mti < PeriodParameters.N; mti++)
            {
                /* See Knuth TAOCP Vol2. 3rd Ed. P.106 for multiplier. */
                state[mti] = (uint) (1812433253U * (state[mti - 1] ^ (state[mti - 1] >> 30)) + mti);
            }
        }

        /// <summary>
        /// updates the state and returns the next 32-bit unsigned integer random number
        /// </summary>
        /// <returns></returns>
        public uint Next()
        {
            /* mag01[x] = x * MATRIX_A  for x=0,1 */
            uint[] mag01 = { 0x0U, /*MATRIX_A*/ 0x9908b0dfU };

            const uint UPPER_MASK = 0x80000000U;
            const uint LOWER_MASK = 0x7fffffffU;
            const int N = PeriodParameters.N;
            const int M = PeriodParameters.M;

            /* generate N words at one time */
            uint y;
            if (mti >= N)
            {
                int kk = 0;

                for (; kk < N - M; ++kk)
                {
                    y = (state[kk] & UPPER_MASK) | (state[kk + 1] & LOWER_MASK);
                    state[kk] = state[kk + M] ^ (y >> 1) ^ mag01[y & 0x1U];
                }

                for (; kk < N - 1; ++kk)
                {
                    y = (state[kk] & UPPER_MASK) | (state[kk + 1] & LOWER_MASK);
                    state[kk] = state[kk + (M - N)] ^ (y >> 1) ^ mag01[y & 0x1U];
                }

                y = (state[N - 1] & UPPER_MASK) | (state[0] & LOWER_MASK);
                state[N - 1] = state[M - 1] ^ (y >> 1) ^ mag01[y & 0x1U];

                mti = 0;
            }

            y = state[mti++];

            /* Tempering */
            y ^= (y >> 11);
            y ^= (y << 7) & 0x9d2c5680U;
            y ^= (y << 15) & 0xefc60000U;
            y ^= (y >> 18);

            return y;
        }

        /// <summary>
        /// returns a random integer sampled uniformly from [0, N).
        /// </summary>
        /// <param name="b"></param>
        /// <returns></returns>
        public uint Run(uint b)
        {
            return Next() % b;
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
            return (int)(Next() % (b - a) + a);
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

        #endregion
    }
}
