using System.Diagnostics.CodeAnalysis;

namespace OpenCvSharp;

/// <summary>
/// Mersenne Twister random number generator
/// </summary>
/// <remarks>operations.hpp</remarks>
// ReSharper disable once InconsistentNaming
[SuppressMessage("Microsoft.Design", "CA1815: Override equals and operator equals on value types")]
public struct RNG_MT19937
{
    private const int N = 624, M = 397;
        
    private readonly uint[] state;
    private int mti;

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="s"></param>
    public RNG_MT19937(uint s = 5489U)
    {
        state = new uint[N];
        mti = 0;
        Seed(s);
    }
        
    #region Cast

    /// <summary> 
    /// </summary>
    /// <param name="self"></param>
    /// <returns></returns>
    public static explicit operator uint(RNG_MT19937 self)
    {
        return self.Next();
    }

    /// <summary> 
    /// </summary>
    /// <returns></returns>
    public uint ToUInt32()
    {
        return Next();
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="self"></param>
    /// <returns></returns>
    public static explicit operator int(RNG_MT19937 self)
    {
        return self.ToInt32();
    }

    /// <summary> 
    /// </summary>
    /// <returns></returns>
    public int ToInt32()
    {
        return (int)Next();
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="self"></param>
    /// <returns></returns>
    public static explicit operator float(RNG_MT19937 self)
    {
        return self.ToSingle();
    }
        
    /// <summary> 
    /// </summary>
    /// <returns></returns>
    public float ToSingle()
    {
        return Next() * (1.0f / 4294967296.0f);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="self"></param>
    /// <returns></returns>
    public static explicit operator double(RNG_MT19937 self)
    {
        return self.ToDouble();
    }
        
    /// <summary> 
    /// </summary>
    /// <returns></returns>
    public double ToDouble()
    {
        var a = Next() >> 5;
        var b = Next() >> 6;
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
        for (mti = 1; mti < N; mti++)
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

        const uint upperMask = 0x80000000U;
        const uint lowerMask = 0x7fffffffU;
        const int n = N;
        const int m = M;

        /* generate N words at one time */
        uint y;
        if (mti >= n)
        {
            var kk = 0;

            for (; kk < n - m; ++kk)
            {
                y = (state[kk] & upperMask) | (state[kk + 1] & lowerMask);
                state[kk] = state[kk + m] ^ (y >> 1) ^ mag01[y & 0x1U];
            }

            for (; kk < n - 1; ++kk)
            {
                y = (state[kk] & upperMask) | (state[kk + 1] & lowerMask);
                state[kk] = state[kk + (m - n)] ^ (y >> 1) ^ mag01[y & 0x1U];
            }

            y = (state[n - 1] & upperMask) | (state[0] & lowerMask);
            state[n - 1] = state[m - 1] ^ (y >> 1) ^ mag01[y & 0x1U];

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
