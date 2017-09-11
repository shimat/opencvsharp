using System;

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
    public static class FourCCCalcurator
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
            byte b1 = System.Convert.ToByte(c1);
            byte b2 = System.Convert.ToByte(c2);
            byte b3 = System.Convert.ToByte(c3);
            byte b4 = System.Convert.ToByte(c4);
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
            byte c1 = System.Convert.ToByte(fourcc[0]);
            byte c2 = System.Convert.ToByte(fourcc[1]);
            byte c3 = System.Convert.ToByte(fourcc[2]);
            byte c4 = System.Convert.ToByte(fourcc[3]);
            return Run(c1, c2, c3, c4);
        }
    }
}