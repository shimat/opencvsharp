﻿using System;

namespace OpenCvSharp
{
#if LANG_JP
    /// <summary>
    /// OpenCvのcvXXX関数のラッパー。
    /// </summary>
#else
    /// <summary>
    /// Managed wrapper of all OpenCV functions
    /// </summary>
#endif
    // ReSharper disable once InconsistentNaming
    internal static class FourCCCalculator
    {
        // ReSharper disable InconsistentNaming

        /// <summary>
        /// 4つの文字からFOURCCの整数値を得る
        /// </summary>
        /// <param name="c1"></param>
        /// <param name="c2"></param>
        /// <param name="c3"></param>
        /// <param name="c4"></param>
        /// <returns></returns>
        public static int Run(byte c1, byte c2, byte c3, byte c4)
        {
            return (((c1) & 255) + (((c2) & 255) << 8) + (((c3) & 255) << 16) + (((c4) & 255) << 24));
        }

        /// <summary>
        /// 4つの文字からFOURCCの整数値を得る
        /// </summary>
        /// <param name="c1"></param>
        /// <param name="c2"></param>
        /// <param name="c3"></param>
        /// <param name="c4"></param>
        /// <returns></returns>
        public static int Run(char c1, char c2, char c3, char c4)
        {
            var b1 = Convert.ToByte(c1);
            var b2 = Convert.ToByte(c2);
            var b3 = Convert.ToByte(c3);
            var b4 = Convert.ToByte(c4);
            return Run(b1, b2, b3, b4);
        }

        /// <summary>
        /// 4つの文字からFOURCCの整数値を得る
        /// </summary>
        /// <param name="fourcc"></param>
        /// <returns></returns>
        public static int Run(string fourcc)
        {
            if (string.IsNullOrEmpty(fourcc))
                return -1;
            if (fourcc.Length != 4)
                throw new ArgumentOutOfRangeException(nameof(fourcc));
            var c1 = Convert.ToByte(fourcc[0]);
            var c2 = Convert.ToByte(fourcc[1]);
            var c3 = Convert.ToByte(fourcc[2]);
            var c4 = Convert.ToByte(fourcc[3]);
            return Run(c1, c2, c3, c4);
        }
    }
}