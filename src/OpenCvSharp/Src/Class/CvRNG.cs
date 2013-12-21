/*
 * (C) 2008-2013 Schima
 * This code is licenced under the LGPL.
 */

using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace OpenCvSharp
{
#if LANG_JP
    /// <summary>
	/// 乱数生成機. 実体はUInt64.
	/// </summary>
	/// <remarks>typedef uint64 CvRNG</remarks>
#else
    /// <summary>
    /// Random number generator 
    /// </summary>
#endif
    [Serializable]
    public class CvRNG
    {
#if LANG_JP
        /// <summary>
        /// このインスタンスの示すUInt64値(乱数の種)
        /// </summary>
#else
        /// <summary>
        /// 64-bit seed value
        /// </summary>
#endif
        public ulong Seed;

        #region Init and Disposal
#if LANG_JP
        /// <summary>
        /// seed = -1 で初期化 
        /// </summary>
#else
        /// <summary>
        /// Initializes with seed=-1
        /// </summary>
#endif
        public CvRNG()
            : this(-1)
        {
        }
#if LANG_JP
        /// <summary>
        /// seedを指定して初期化 
        /// </summary>
        /// <param name="seed">ランダムシーケンスを開始するために使用される64ビットの数値</param>
#else
        /// <summary>
        /// Initializes with specified seed value
        /// </summary>
        /// <param name="seed"></param>
#endif
        public CvRNG(ulong seed)
        {
            this.Seed = seed;
        }
#if LANG_JP
        /// <summary>
        /// seedを指定して初期化 
        /// </summary>
        /// <param name="seed">ランダムシーケンスを開始するために使用される64ビットの数値</param>
#else
        /// <summary>
        /// Initializes with specified seed value
        /// </summary>
        /// <param name="seed"></param>
#endif
        public CvRNG(long seed)
            : this((ulong)seed)
        {
        }
#if LANG_JP
        /// <summary>
        /// 時刻の値から初期化
        /// </summary>
        /// <param name="time">時刻データ。Tickプロパティの値が使われる。</param>
#else
        /// <summary>
        /// Initializes with specified time data 
        /// </summary>
        /// <param name="time"></param>
#endif
        public CvRNG(DateTime time)
            : this((ulong)time.Ticks)
        {
        }
        #endregion

        #region Operators
#if LANG_JP
        /// <summary>
        /// CvRNGからUInt64への明示的な変換
        /// </summary>
        /// <param name="self">CvRNG</param>
        /// <returns>UInt64</returns>
#else
        /// <summary>
        /// explicit cast to ulong
        /// </summary>
        /// <param name="self"></param>
        /// <returns></returns>
#endif
        public static explicit operator ulong(CvRNG self)
        {
            return self.Seed;
        }
#if LANG_JP
        /// <summary>
        /// UInt64からCvRNGへの明示的な変換
        /// </summary>
        /// <param name="v">UInt64</param>
        /// <returns>CvRNG</returns>
#else
        /// <summary>
        /// explicit cast to CvRNG
        /// </summary>
        /// <param name="v"></param>
        /// <returns></returns>
#endif
        public static explicit operator CvRNG(ulong v)
        {
            return new CvRNG(v);
        }
        #endregion

        #region Methods
        #region RandArr
#if LANG_JP
        /// <summary>
        /// 一様または正規分布の乱数で出力配列を埋める 
        /// </summary>
        /// <param name="arr">出力配列</param>
        /// <param name="dist_type">分布のタイプ</param>
        /// <param name="param1">分布の第一パラメータ．一様分布では，発生する乱数の下限値（この値を含む）である． 正規分布では，乱数の平均値である．</param>
        /// <param name="param2">分布の第二パラメータ．一様分布では，発生する乱数の上限値（この値は含まない）である． 正規分布では，乱数の標準偏差である．</param>
#else
        /// <summary>
        /// Fills array with random numbers and updates the RNG state
        /// </summary>
        /// <param name="arr">The destination array. </param>
        /// <param name="dist_type">Distribution type.</param>
        /// <param name="param1">The first parameter of distribution. In case of uniform distribution it is the inclusive lower boundary of random numbers range. In case of normal distribution it is the mean value of random numbers. </param>
        /// <param name="param2">The second parameter of distribution. In case of uniform distribution it is the exclusive upper boundary of random numbers range. In case of normal distribution it is the standard deviation of random numbers. </param>
#endif
        public void RandArr(CvArr arr, DistributionType dist_type, CvScalar param1, CvScalar param2)
        {
            Cv.RandArr(this, arr, dist_type, param1, param2);
        }
        #endregion
        #region RandInt
#if RANG_JP
        /// <summary>
        /// 一様分布した32ビット符号なし整数型の乱数を返し，RNGの状態を更新する．
        /// </summary>
        /// <returns>32ビット符号なし整数</returns>
#else
        /// <summary>
        /// Returns 32-bit unsigned integer and updates RNG
        /// </summary>
        /// <returns>uniformly-distributed random 32-bit unsigned integer</returns>
#endif
        public uint RandInt()
        {
            return Cv.RandInt(this);
        }
#if LANG_JP
        /// <summary>
        /// 一様分布した32ビット符号なし整数型の乱数を返し，RNGの状態を更新する (cvRandInt相当)．
        /// </summary>
        /// <param name="max">生成される乱数の排他的上限値. すなわち0からこの値未満の乱数が返される.</param>
        /// <returns>32ビット符号なし整数</returns>
#else
        /// <summary>
        /// Returns 32-bit unsigned integer and updates RNG
        /// </summary>
        /// <param name="max">the exclusive upper boundary of random numbers range.</param>
        /// <returns>uniformly-distributed random 32-bit unsigned integer</returns>
#endif
        public uint RandInt(uint max)
        {
            if (max == 0)
            {
                return 0;
            }
            else
            {
                return Cv.RandInt(this) % max;
            }
        }        
#if LANG_JP
        /// <summary>
        /// 一様分布した32ビット符号なし整数型の乱数を返し，RNGの状態を更新する (cvRandInt相当)．
        /// </summary>
        /// <param name="min">生成される乱数の包括的下限値. すなわちこの値以上の乱数が返される.</param>
        /// <param name="max">生成される乱数の排他的上限値. すなわちこの値未満の乱数が返される.</param>
        /// <returns>32ビット符号なし整数</returns>
#else
        /// <summary>
        /// Returns 32-bit unsigned integer and updates RNG
        /// </summary>
        /// <param name="min">the inclusive lower boundary of random numbers range. </param>
        /// <param name="max">the exclusive upper boundary of random numbers range.</param>
        /// <returns></returns>
#endif
        public uint RandInt(uint min, uint max)
        {
            if (min > max)
            {
                throw new ArgumentOutOfRangeException();
            }
            return RandInt(max - min) + min;
        }
        #endregion
        #region RandReal
#if RANG_JP
        /// <summary>
        /// 0から1（1は含まれない）の範囲に一様分布する浮動小数点型の乱数を返す．
        /// </summary>
        /// <returns>0から1（1は含まれない）の範囲に一様分布する浮動小数点型</returns>
#else
        /// <summary>
        /// Returns floating-point random number and updates RNG
        /// </summary>
        /// <returns>uniformly-distributed random floating-point number from 0..1 range (1 is not included).</returns>
#endif
        public double RandReal()
        {
            return Cv.RandReal(this);
        }
        #endregion
        #endregion
    }
}
