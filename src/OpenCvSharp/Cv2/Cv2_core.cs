using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
// ReSharper disable CommentTypo
// ReSharper disable IdentifierTypo
// ReSharper disable UnusedMember.Global

namespace OpenCvSharp
{
    static partial class Cv2
    {
        #region core.hpp

        /// <summary>
        /// Computes the source location of an extrapolated pixel.
        /// </summary>
        /// <param name="p">0-based coordinate of the extrapolated pixel along one of the axes, likely &lt;0 or &gt;= len</param>
        /// <param name="len">Length of the array along the corresponding axis.</param>
        /// <param name="borderType">Border type, one of the #BorderTypes, except for #BORDER_TRANSPARENT and BORDER_ISOLATED. 
        /// When borderType==BORDER_CONSTANT, the function always returns -1, regardless</param>
        /// <returns></returns>
        public static int BorderInterpolate(int p, int len, BorderTypes borderType)
        {
            NativeMethods.HandleException(
                NativeMethods.core_borderInterpolate(p, len, (int)borderType, out var ret));
            return ret;
        }

        /// <summary>
        /// Forms a border around the image
        /// </summary>
        /// <param name="src">The source image</param>
        /// <param name="dst">The destination image; will have the same type as src and 
        /// the size Size(src.cols+left+right, src.rows+top+bottom)</param>
        /// <param name="top">Specify how much pixels in each direction from the source image rectangle one needs to extrapolate</param>
        /// <param name="bottom">Specify how much pixels in each direction from the source image rectangle one needs to extrapolate</param>
        /// <param name="left">Specify how much pixels in each direction from the source image rectangle one needs to extrapolate</param>
        /// <param name="right">Specify how much pixels in each direction from the source image rectangle one needs to extrapolate</param>
        /// <param name="borderType">The border type</param>
        /// <param name="value">The border value if borderType == Constant</param>
        public static void CopyMakeBorder(InputArray src, OutputArray dst, int top, int bottom, int left, int right,
            BorderTypes borderType, Scalar? value = null)
        {
            if (src == null)
                throw new ArgumentNullException(nameof(src));
            if (dst == null)
                throw new ArgumentNullException(nameof(dst));
            src.ThrowIfDisposed();
            dst.ThrowIfNotReady();

            var value0 = value.GetValueOrDefault(new Scalar());
            NativeMethods.HandleException(
                NativeMethods.core_copyMakeBorder(
                    src.CvPtr, dst.CvPtr, top, bottom, left, right, (int)borderType, value0));

            GC.KeepAlive(src);
            dst.Fix();
        }

#if LANG_JP
        /// <summary>
        /// 2つの配列同士，あるいは配列とスカラの 要素毎の和を求めます．
        /// </summary>
        /// <param name="src1">1番目の入力配列</param>
        /// <param name="src2">src1 と同じサイズ，同じ型である2番目の入力配列</param>
        /// <param name="dst">src1 と同じサイズ，同じ型の出力配列．</param>
        /// <param name="mask">8ビット，シングルチャンネル配列のオプションの処理マスク．出力配列内の変更される要素を表します. [既定値はnull]</param>        
        /// <param name="dtype"></param>
#else
        /// <summary>
        /// Computes the per-element sum of two arrays or an array and a scalar.
        /// </summary>
        /// <param name="src1">The first source array</param>
        /// <param name="src2">The second source array. It must have the same size and same type as src1</param>
        /// <param name="dst">The destination array; it will have the same size and same type as src1</param>
        /// <param name="mask">The optional operation mask, 8-bit single channel array; specifies elements of the destination array to be changed. [By default this is null]</param>
        /// <param name="dtype"></param>
#endif
        public static void Add(InputArray src1, InputArray src2, OutputArray dst, InputArray? mask = null,
            int dtype = -1)
        {
            if (src1 == null)
                throw new ArgumentNullException(nameof(src1));
            if (src2 == null)
                throw new ArgumentNullException(nameof(src2));
            if (dst == null)
                throw new ArgumentNullException(nameof(dst));
            src1.ThrowIfDisposed();
            src2.ThrowIfDisposed();
            dst.ThrowIfNotReady();

            NativeMethods.HandleException(
                NativeMethods.core_add(
                    src1.CvPtr, src2.CvPtr, dst.CvPtr, ToPtr(mask), dtype));

            GC.KeepAlive(src1);
            GC.KeepAlive(src2);
            GC.KeepAlive(mask);
            dst.Fix();
        }
#if LANG_JP
        /// <summary>
        /// 2つの配列同士，あるいは配列とスカラの 要素毎の差を求めます．
        /// </summary>
        /// <param name="src1">1番目の入力配列</param>
        /// <param name="src2">src1 と同じサイズ，同じ型である2番目の入力配列</param>
        /// <param name="dst">src1 と同じサイズ，同じ型の出力配列．</param>
        /// <param name="mask">オプション．8ビット，シングルチャンネル配列の処理マスク．出力配列内の変更される要素を表します. [既定値はnull]</param>
        /// <param name="dtype"></param>
#else
        /// <summary>
        /// Calculates per-element difference between two arrays or array and a scalar
        /// </summary>
        /// <param name="src1">The first source array</param>
        /// <param name="src2">The second source array. It must have the same size and same type as src1</param>
        /// <param name="dst">The destination array; it will have the same size and same type as src1</param>
        /// <param name="mask">The optional operation mask, 8-bit single channel array; specifies elements of the destination array to be changed. [By default this is null]</param>
        /// <param name="dtype"></param>
#endif
        public static void Subtract(InputArray src1, InputArray src2, OutputArray dst, InputArray? mask = null,
            int dtype = -1)
        {
            if (src1 == null)
                throw new ArgumentNullException(nameof(src1));
            if (src2 == null)
                throw new ArgumentNullException(nameof(src2));
            if (dst == null)
                throw new ArgumentNullException(nameof(dst));
            src1.ThrowIfDisposed();
            src2.ThrowIfDisposed();
            dst.ThrowIfNotReady();

            NativeMethods.HandleException(
                NativeMethods.core_subtract_InputArray2(
                    src1.CvPtr, src2.CvPtr, dst.CvPtr, ToPtr(mask), dtype));

            GC.KeepAlive(src1);
            GC.KeepAlive(src2);
            dst.Fix();
            GC.KeepAlive(mask);
        }

#if LANG_JP
        /// <summary>
        /// 2つの配列同士，あるいは配列とスカラの 要素毎の差を求めます．
        /// </summary>
        /// <param name="src1">1番目の入力配列</param>
        /// <param name="src2">src1 と同じサイズ，同じ型である2番目の入力配列</param>
        /// <param name="dst">src1 と同じサイズ，同じ型の出力配列．</param>
        /// <param name="mask">オプション．8ビット，シングルチャンネル配列の処理マスク．出力配列内の変更される要素を表します. [既定値はnull]</param>
        /// <param name="dtype"></param>
#else
        /// <summary>
        /// Calculates per-element difference between two arrays or array and a scalar
        /// </summary>
        /// <param name="src1">The first source array</param>
        /// <param name="src2">The second source array. It must have the same size and same type as src1</param>
        /// <param name="dst">The destination array; it will have the same size and same type as src1</param>
        /// <param name="mask">The optional operation mask, 8-bit single channel array; specifies elements of the destination array to be changed. [By default this is null]</param>
        /// <param name="dtype"></param>
#endif
        public static void Subtract(InputArray src1, Scalar src2, OutputArray dst, InputArray? mask = null,
            int dtype = -1)
        {
            if (src1 == null)
                throw new ArgumentNullException(nameof(src1));
            if (src2 == null)
                throw new ArgumentNullException(nameof(src2));
            if (dst == null)
                throw new ArgumentNullException(nameof(dst));
            src1.ThrowIfDisposed();
            dst.ThrowIfNotReady();

            NativeMethods.HandleException(
                NativeMethods.core_subtract_InputArrayScalar(
                    src1.CvPtr, src2, dst.CvPtr, ToPtr(mask), dtype));

            GC.KeepAlive(src1);
            dst.Fix();
            GC.KeepAlive(mask);
        }

#if LANG_JP
        /// <summary>
        /// 2つの配列同士，あるいは配列とスカラの 要素毎の差を求めます．
        /// </summary>
        /// <param name="src1">1番目の入力配列</param>
        /// <param name="src2">src1 と同じサイズ，同じ型である2番目の入力配列</param>
        /// <param name="dst">src1 と同じサイズ，同じ型の出力配列．</param>
        /// <param name="mask">オプション．8ビット，シングルチャンネル配列の処理マスク．出力配列内の変更される要素を表します. [既定値はnull]</param>
        /// <param name="dtype"></param>
#else
        /// <summary>
        /// Calculates per-element difference between two arrays or array and a scalar
        /// </summary>
        /// <param name="src1">The first source array</param>
        /// <param name="src2">The second source array. It must have the same size and same type as src1</param>
        /// <param name="dst">The destination array; it will have the same size and same type as src1</param>
        /// <param name="mask">The optional operation mask, 8-bit single channel array; specifies elements of the destination array to be changed. [By default this is null]</param>
        /// <param name="dtype"></param>
#endif
        public static void Subtract(Scalar src1, InputArray src2, OutputArray dst, InputArray? mask = null,
            int dtype = -1)
        {
            if (src1 == null)
                throw new ArgumentNullException(nameof(src1));
            if (src2 == null)
                throw new ArgumentNullException(nameof(src2));
            if (dst == null)
                throw new ArgumentNullException(nameof(dst));
            src2.ThrowIfDisposed();
            dst.ThrowIfNotReady();

            NativeMethods.HandleException(
                NativeMethods.core_subtract_ScalarInputArray(
                    src1, src2.CvPtr, dst.CvPtr, ToPtr(mask), dtype));

            GC.KeepAlive(src2);
            dst.Fix();
            GC.KeepAlive(mask);
        }
        
#if LANG_JP
        /// <summary>
        /// 2つの配列同士の，要素毎のスケーリングされた積を求めます．
        /// </summary>
        /// <param name="src1">1番目の入力配列</param>
        /// <param name="src2">src1 と同じサイズ，同じ型である2番目の入力配列</param>
        /// <param name="dst">src1 と同じサイズ，同じ型の出力配列</param>
        /// <param name="scale">オプションであるスケールファクタ. [既定値は1]</param>
        /// <param name="dtype"></param>
#else
        /// <summary>
        /// Calculates the per-element scaled product of two arrays
        /// </summary>
        /// <param name="src1">The first source array</param>
        /// <param name="src2">The second source array of the same size and the same type as src1</param>
        /// <param name="dst">The destination array; will have the same size and the same type as src1</param>
        /// <param name="scale">The optional scale factor. [By default this is 1]</param>
        /// <param name="dtype"></param>
#endif
        public static void Multiply(InputArray src1, InputArray src2, OutputArray dst, double scale = 1, int dtype = -1)
        {
            if (src1 == null)
                throw new ArgumentNullException(nameof(src1));
            if (src2 == null)
                throw new ArgumentNullException(nameof(src2));
            if (dst == null)
                throw new ArgumentNullException(nameof(dst));
            src1.ThrowIfDisposed();
            src2.ThrowIfDisposed();
            dst.ThrowIfNotReady();

            NativeMethods.HandleException(
                NativeMethods.core_multiply(
                    src1.CvPtr, src2.CvPtr, dst.CvPtr, scale, dtype));

            GC.KeepAlive(src1);
            GC.KeepAlive(src2);
            dst.Fix();
        }

#if LANG_JP
        /// <summary>
        /// 2つの配列同士，あるいは配列とスカラの 要素毎の商を求めます．
        /// </summary>
        /// <param name="src1">1番目の入力配列</param>
        /// <param name="src2">src1 と同じサイズ，同じ型である2番目の入力配列</param>
        /// <param name="dst">src2 と同じサイズ，同じ型である出力配列</param>
        /// <param name="scale">スケールファクタ [既定値は1]</param>
        /// <param name="dtype"></param>
#else
        /// <summary>
        /// Performs per-element division of two arrays or a scalar by an array.
        /// </summary>
        /// <param name="src1">The first source array</param>
        /// <param name="src2">The second source array; should have the same size and same type as src1</param>
        /// <param name="dst">The destination array; will have the same size and same type as src2</param>
        /// <param name="scale">Scale factor [By default this is 1]</param>
        /// <param name="dtype"></param>
#endif
        public static void Divide(InputArray src1, InputArray src2, OutputArray dst, double scale = 1, int dtype = -1)
        {
            if (src1 == null)
                throw new ArgumentNullException(nameof(src1));
            if (src2 == null)
                throw new ArgumentNullException(nameof(src2));
            if (dst == null)
                throw new ArgumentNullException(nameof(dst));
            src1.ThrowIfDisposed();
            src2.ThrowIfDisposed();
            dst.ThrowIfNotReady();

            NativeMethods.HandleException(
                NativeMethods.core_divide2(
                    src1.CvPtr, src2.CvPtr, dst.CvPtr, scale, dtype));

            GC.KeepAlive(src1);
            GC.KeepAlive(src2);
            dst.Fix();
        }

#if LANG_JP
        /// <summary>
        /// 2つの配列同士，あるいは配列とスカラの 要素毎の商を求めます．
        /// </summary>
        /// <param name="scale">スケールファクタ</param>
        /// <param name="src2">1番目の入力配列</param>
        /// <param name="dst">src2 と同じサイズ，同じ型である出力配列</param>
        /// <param name="dtype"></param>
#else
        /// <summary>
        /// Performs per-element division of two arrays or a scalar by an array.
        /// </summary>
        /// <param name="scale">Scale factor</param>
        /// <param name="src2">The first source array</param>
        /// <param name="dst">The destination array; will have the same size and same type as src2</param>
        /// <param name="dtype"></param>
#endif
        public static void Divide(double scale, InputArray src2, OutputArray dst, int dtype = -1)
        {
            if (src2 == null)
                throw new ArgumentNullException(nameof(src2));
            if (dst == null)
                throw new ArgumentNullException(nameof(dst));
            src2.ThrowIfDisposed();
            dst.ThrowIfNotReady();

            NativeMethods.HandleException(
                NativeMethods.core_divide1(scale, src2.CvPtr, dst.CvPtr, dtype));

            GC.KeepAlive(src2);
            dst.Fix();
        }

        /// <summary>
        /// adds scaled array to another one (dst = alpha*src1 + src2)
        /// </summary>
        /// <param name="src1"></param>
        /// <param name="alpha"></param>
        /// <param name="src2"></param>
        /// <param name="dst"></param>
        public static void ScaleAdd(InputArray src1, double alpha, InputArray src2, OutputArray dst)
        {
            if (src1 == null)
                throw new ArgumentNullException(nameof(src1));
            if (src2 == null)
                throw new ArgumentNullException(nameof(src2));
            if (dst == null)
                throw new ArgumentNullException(nameof(dst));
            src1.ThrowIfDisposed();
            src2.ThrowIfDisposed();
            dst.ThrowIfNotReady();

            NativeMethods.HandleException(
                NativeMethods.core_scaleAdd(src1.CvPtr, alpha, src2.CvPtr, dst.CvPtr));

            GC.KeepAlive(src1);
            GC.KeepAlive(src2);
            dst.Fix();
        }

        /// <summary>
        /// computes weighted sum of two arrays (dst = alpha*src1 + beta*src2 + gamma)
        /// </summary>
        /// <param name="src1"></param>
        /// <param name="alpha"></param>
        /// <param name="src2"></param>
        /// <param name="beta"></param>
        /// <param name="gamma"></param>
        /// <param name="dst"></param>
        /// <param name="dtype"></param>
        public static void AddWeighted(InputArray src1, double alpha, InputArray src2,
            double beta, double gamma, OutputArray dst, int dtype = -1)
        {
            if (src1 == null)
                throw new ArgumentNullException(nameof(src1));
            if (src2 == null)
                throw new ArgumentNullException(nameof(src2));
            if (dst == null)
                throw new ArgumentNullException(nameof(dst));
            src1.ThrowIfDisposed();
            src2.ThrowIfDisposed();
            dst.ThrowIfNotReady();

            NativeMethods.HandleException(
                NativeMethods.core_addWeighted(
                    src1.CvPtr, alpha, src2.CvPtr, beta, gamma, dst.CvPtr, dtype));

            GC.KeepAlive(src1);
            GC.KeepAlive(src2);
            dst.Fix();
        }

#if LANG_JP
        /// <summary>
        /// スケーリング後，絶対値を計算し，結果を結果を 8 ビットに変換します．
        /// </summary>
        /// <param name="src">入力配列</param>
        /// <param name="dst">出力配列</param>
        /// <param name="alpha">オプションのスケールファクタ. [既定値は1]</param>
        /// <param name="beta">スケーリングされた値に加えられるオプション値. [既定値は0]</param>
#else
        /// <summary>
        /// Scales, computes absolute values and converts the result to 8-bit.
        /// </summary>
        /// <param name="src">The source array</param>
        /// <param name="dst">The destination array</param>
        /// <param name="alpha">The optional scale factor. [By default this is 1]</param>
        /// <param name="beta">The optional delta added to the scaled values. [By default this is 0]</param>
#endif
        public static void ConvertScaleAbs(InputArray src, OutputArray dst, double alpha = 1, double beta = 0)
        {
            if (src == null)
                throw new ArgumentNullException(nameof(src));
            if (dst == null)
                throw new ArgumentNullException(nameof(dst));
            src.ThrowIfDisposed();
            dst.ThrowIfNotReady();

            NativeMethods.HandleException(
                NativeMethods.core_convertScaleAbs(src.CvPtr, dst.CvPtr, alpha, beta));

            GC.KeepAlive(src);
            dst.Fix();
        }

        /// <summary>
        /// Converts an array to half precision floating number.
        ///
        /// This function converts FP32(single precision floating point) from/to FP16(half precision floating point). CV_16S format is used to represent FP16 data.
        /// There are two use modes(src -&gt; dst) : CV_32F -&gt; CV_16S and CV_16S -&gt; CV_32F.The input array has to have type of CV_32F or
        /// CV_16S to represent the bit depth.If the input array is neither of them, the function will raise an error.
        /// The format of half precision floating point is defined in IEEE 754-2008.
        /// </summary>
        /// <param name="src">input array.</param>
        /// <param name="dst">output array.</param>
        public static void ConvertFp16(InputArray src, OutputArray dst)
        {
            if (src == null)
                throw new ArgumentNullException(nameof(src));
            if (dst == null)
                throw new ArgumentNullException(nameof(dst));
            src.ThrowIfDisposed();
            dst.ThrowIfNotReady();

            NativeMethods.HandleException(
                NativeMethods.core_convertFp16(src.CvPtr, dst.CvPtr));

            GC.KeepAlive(src);
            dst.Fix();
        }

        /// <summary>
        /// transforms array of numbers using a lookup table: dst(i)=lut(src(i))
        /// </summary>
        /// <param name="src">Source array of 8-bit elements</param>
        /// <param name="lut">Look-up table of 256 elements. 
        /// In the case of multi-channel source array, the table should either have 
        /// a single channel (in this case the same table is used for all channels)
        ///  or the same number of channels as in the source array</param>
        /// <param name="dst">Destination array; 
        /// will have the same size and the same number of channels as src, 
        /// and the same depth as lut</param>
        public static void LUT(InputArray src, InputArray lut, OutputArray dst)
        {
            if (src == null)
                throw new ArgumentNullException(nameof(src));
            if (lut == null)
                throw new ArgumentNullException(nameof(lut));
            if (dst == null)
                throw new ArgumentNullException(nameof(dst));
            src.ThrowIfDisposed();
            lut.ThrowIfDisposed();
            dst.ThrowIfNotReady();

            NativeMethods.HandleException(
                NativeMethods.core_LUT(src.CvPtr, lut.CvPtr, dst.CvPtr));

            GC.KeepAlive(src);
            GC.KeepAlive(lut);
            GC.KeepAlive(dst);
            dst.Fix();
        }

        /// <summary>
        /// transforms array of numbers using a lookup table: dst(i)=lut(src(i))
        /// </summary>
        /// <param name="src">Source array of 8-bit elements</param>
        /// <param name="lut">Look-up table of 256 elements. 
        /// In the case of multi-channel source array, the table should either have 
        /// a single channel (in this case the same table is used for all channels) 
        /// or the same number of channels as in the source array</param>
        /// <param name="dst">Destination array; 
        /// will have the same size and the same number of channels as src, 
        /// and the same depth as lut</param>
        public static void LUT(InputArray src, byte[] lut, OutputArray dst)
        {
            if (lut == null)
                throw new ArgumentNullException(nameof(lut));
            if (lut.Length != 256)
                throw new ArgumentException("lut.Length != 256");

            using var lutMat = new Mat(256, 1, MatType.CV_8UC1, lut);
            LUT(src, lutMat, dst);
        }

        /// <summary>
        /// computes sum of array elements
        /// </summary>
        /// <param name="src">The source array; must have 1 to 4 channels</param>
        /// <returns></returns>
        public static Scalar Sum(InputArray src)
        {
            if (src == null)
                throw new ArgumentNullException(nameof(src));
            src.ThrowIfDisposed();

            NativeMethods.HandleException(
                NativeMethods.core_sum(src.CvPtr, out var ret));

            GC.KeepAlive(src);
            return ret;
        }
        
        /// <summary>
        /// computes the number of nonzero array elements
        /// </summary>
        /// <param name="mtx">Single-channel array</param>
        /// <returns>number of non-zero elements in mtx</returns>
        public static int CountNonZero(InputArray mtx)
        {
            if (mtx == null)
                throw new ArgumentNullException(nameof(mtx));
            mtx.ThrowIfDisposed();

            NativeMethods.HandleException(
                NativeMethods.core_countNonZero(mtx.CvPtr, out var ret));

            GC.KeepAlive(mtx);
            return ret;
        }

        /// <summary>
        /// returns the list of locations of non-zero pixels
        /// </summary>
        /// <param name="src"></param>
        /// <param name="idx"></param>
        public static void FindNonZero(InputArray src, OutputArray idx)
        {
            if (src == null)
                throw new ArgumentNullException(nameof(src));
            if (idx == null)
                throw new ArgumentNullException(nameof(idx));
            src.ThrowIfDisposed();
            idx.ThrowIfNotReady();

            NativeMethods.HandleException(
                NativeMethods.core_findNonZero(src.CvPtr, idx.CvPtr));

            GC.KeepAlive(src);
            GC.KeepAlive(idx);
            idx.Fix();
        }

        /// <summary>
        /// computes mean value of selected array elements
        /// </summary>
        /// <param name="src">The source array; it should have 1 to 4 channels
        ///  (so that the result can be stored in Scalar)</param>
        /// <param name="mask">The optional operation mask</param>
        /// <returns></returns>
        public static Scalar Mean(InputArray src, InputArray? mask = null)
        {
            if (src == null)
                throw new ArgumentNullException(nameof(src));
            src.ThrowIfDisposed();

            NativeMethods.HandleException(
                NativeMethods.core_mean(src.CvPtr, ToPtr(mask), out var ret));

            GC.KeepAlive(src);
            GC.KeepAlive(mask);
            return ret;
        }

        /// <summary>
        /// computes mean value and standard deviation of all or selected array elements
        /// </summary>
        /// <param name="src">The source array; it should have 1 to 4 channels 
        /// (so that the results can be stored in Scalar's)</param>
        /// <param name="mean">The output parameter: computed mean value</param>
        /// <param name="stddev">The output parameter: computed standard deviation</param>
        /// <param name="mask">The optional operation mask</param>
        public static void MeanStdDev(
            InputArray src, OutputArray mean, OutputArray stddev, InputArray? mask = null)
        {
            if (src == null)
                throw new ArgumentNullException(nameof(src));
            if (mean == null)
                throw new ArgumentNullException(nameof(mean));
            if (stddev == null)
                throw new ArgumentNullException(nameof(stddev));
            src.ThrowIfDisposed();
            mean.ThrowIfNotReady();
            stddev.ThrowIfNotReady();

            NativeMethods.HandleException(
                NativeMethods.core_meanStdDev_OutputArray(
                    src.CvPtr, mean.CvPtr, stddev.CvPtr, ToPtr(mask)));

            mean.Fix();
            stddev.Fix();
            GC.KeepAlive(src);
            GC.KeepAlive(mean);
            GC.KeepAlive(stddev);
            GC.KeepAlive(mask);
        }

        /// <summary>
        /// computes mean value and standard deviation of all or selected array elements
        /// </summary>
        /// <param name="src">The source array; it should have 1 to 4 channels 
        /// (so that the results can be stored in Scalar's)</param>
        /// <param name="mean">The output parameter: computed mean value</param>
        /// <param name="stddev">The output parameter: computed standard deviation</param>
        /// <param name="mask">The optional operation mask</param>
        public static void MeanStdDev(
            InputArray src, out Scalar mean, out Scalar stddev, InputArray? mask = null)
        {
            if (src == null)
                throw new ArgumentNullException(nameof(src));

            src.ThrowIfDisposed();

            NativeMethods.HandleException(
                NativeMethods.core_meanStdDev_Scalar(
                    src.CvPtr, out mean, out stddev, ToPtr(mask)));

            GC.KeepAlive(src);
            GC.KeepAlive(mask);
        }

        /// <summary>
        /// Calculates absolute array norm, absolute difference norm, or relative difference norm.
        /// </summary>
        /// <param name="src1">The first source array</param>
        /// <param name="normType">Type of the norm</param>
        /// <param name="mask">The optional operation mask</param>
        /// <returns></returns>
        public static double Norm(InputArray src1,
            NormTypes normType = NormTypes.L2, InputArray? mask = null)
        {
            if (src1 == null)
                throw new ArgumentNullException(nameof(src1));
            src1.ThrowIfDisposed();

            NativeMethods.HandleException(
                NativeMethods.core_norm1(src1.CvPtr, (int)normType, ToPtr(mask), out var ret));

            GC.KeepAlive(src1);
            GC.KeepAlive(mask);
            return ret;
        }

        /// <summary>
        /// computes norm of selected part of the difference between two arrays
        /// </summary>
        /// <param name="src1">The first source array</param>
        /// <param name="src2">The second source array of the same size and the same type as src1</param>
        /// <param name="normType">Type of the norm</param>
        /// <param name="mask">The optional operation mask</param>
        /// <returns></returns>
        public static double Norm(InputArray src1, InputArray src2,
            NormTypes normType = NormTypes.L2, InputArray? mask = null)
        {
            if (src1 == null)
                throw new ArgumentNullException(nameof(src1));
            if (src2 == null)
                throw new ArgumentNullException(nameof(src2));
            src1.ThrowIfDisposed();
            src2.ThrowIfDisposed();

            NativeMethods.HandleException(
                NativeMethods.core_norm2(src1.CvPtr, src2.CvPtr, (int)normType, ToPtr(mask), out var ret));

            GC.KeepAlive(src1);
            GC.KeepAlive(src2);
            GC.KeepAlive(mask);
            return ret;
        }

        /// <summary>
        /// Computes the Peak Signal-to-Noise Ratio (PSNR) image quality metric.
        /// 
        /// This function calculates the Peak Signal-to-Noise Ratio(PSNR) image quality metric in decibels(dB), 
        /// between two input arrays src1 and src2.The arrays must have the same type.
        /// </summary>
        /// <param name="src1">first input array.</param>
        /// <param name="src2">second input array of the same size as src1.</param>
        /// <param name="r">the maximum pixel value (255 by default)</param>
        /// <returns></returns>
        // ReSharper disable once InconsistentNaming
        public static double PSNR(InputArray src1, InputArray src2, double r = 255.0)
        {
            if (src1 == null)
                throw new ArgumentNullException(nameof(src1));
            if (src2 == null)
                throw new ArgumentNullException(nameof(src2));
            src1.ThrowIfDisposed();
            src2.ThrowIfDisposed();

            NativeMethods.HandleException(
                NativeMethods.core_PSNR(src1.CvPtr, src2.CvPtr, r, out var ret));

            GC.KeepAlive(src1);
            GC.KeepAlive(src2);
            return ret;
        }

        /// <summary>
        /// naive nearest neighbor finder
        /// </summary>
        /// <param name="src1"></param>
        /// <param name="src2"></param>
        /// <param name="dist"></param>
        /// <param name="dtype"></param>
        /// <param name="nidx"></param>
        /// <param name="normType"></param>
        /// <param name="k"></param>
        /// <param name="mask"></param>
        /// <param name="update"></param>
        /// <param name="crosscheck"></param>
        public static void BatchDistance(InputArray src1, InputArray src2,
            // ReSharper disable once IdentifierTypo
            OutputArray dist, int dtype, OutputArray nidx,
            NormTypes normType = NormTypes.L2,
            int k = 0, InputArray? mask = null,
            int update = 0, bool crosscheck = false)
        {
            if (src1 == null)
                throw new ArgumentNullException(nameof(src1));
            if (src2 == null)
                throw new ArgumentNullException(nameof(src2));
            if (dist == null)
                throw new ArgumentNullException(nameof(dist));
            if (nidx == null)
                throw new ArgumentNullException(nameof(nidx));
            src1.ThrowIfDisposed();
            src2.ThrowIfDisposed();
            dist.ThrowIfNotReady();
            nidx.ThrowIfNotReady();

            NativeMethods.HandleException(
                NativeMethods.core_batchDistance(
                    src1.CvPtr, src2.CvPtr, dist.CvPtr, dtype, nidx.CvPtr,
                    (int) normType, k, ToPtr(mask), update, crosscheck ? 1 : 0));

            GC.KeepAlive(src1);
            GC.KeepAlive(src2);
            GC.KeepAlive(dist);
            GC.KeepAlive(nidx);
            dist.Fix();
            nidx.Fix();
            GC.KeepAlive(mask);
        }

        /// <summary>
        /// scales and shifts array elements so that either the specified norm (alpha) 
        /// or the minimum (alpha) and maximum (beta) array values get the specified values
        /// </summary>
        /// <param name="src">The source array</param>
        /// <param name="dst">The destination array; will have the same size as src</param>
        /// <param name="alpha">The norm value to normalize to or the lower range boundary 
        /// in the case of range normalization</param>
        /// <param name="beta">The upper range boundary in the case of range normalization; 
        /// not used for norm normalization</param>
        /// <param name="normType">The normalization type</param>
        /// <param name="dtype">When the parameter is negative, 
        /// the destination array will have the same type as src, 
        /// otherwise it will have the same number of channels as src and the depth =CV_MAT_DEPTH(rtype)</param>
        /// <param name="mask">The optional operation mask</param>
        public static void Normalize(InputArray src, InputOutputArray dst, double alpha = 1, double beta = 0,
            NormTypes normType = NormTypes.L2, int dtype = -1, InputArray? mask = null)
        {
            if (src == null)
                throw new ArgumentNullException(nameof(src));
            if (dst == null)
                throw new ArgumentNullException(nameof(dst));
            src.ThrowIfDisposed();
            dst.ThrowIfNotReady();

            NativeMethods.HandleException(
                NativeMethods.core_normalize(
                    src.CvPtr, dst.CvPtr, alpha, beta, (int)normType, dtype, ToPtr(mask)));

            GC.KeepAlive(src);
            GC.KeepAlive(dst);
            dst.Fix();
            GC.KeepAlive(mask);
        }

        /// <summary>
        /// finds global minimum and maximum array elements and returns their values and their locations
        /// </summary>
        /// <param name="src">The source single-channel array</param>
        /// <param name="minVal">Pointer to returned minimum value</param>
        /// <param name="maxVal">Pointer to returned maximum value</param>
        public static void MinMaxLoc(InputArray src, out double minVal, out double maxVal)
        {
            if (src == null)
                throw new ArgumentNullException(nameof(src));
            src.ThrowIfDisposed();

            NativeMethods.HandleException(
                NativeMethods.core_minMaxLoc1(src.CvPtr, out minVal, out maxVal));

            GC.KeepAlive(src);
        }

        /// <summary>
        /// finds global minimum and maximum array elements and returns their values and their locations
        /// </summary>
        /// <param name="src">The source single-channel array</param>
        /// <param name="minLoc">Pointer to returned minimum location</param>
        /// <param name="maxLoc">Pointer to returned maximum location</param>
        public static void MinMaxLoc(InputArray src, out Point minLoc, out Point maxLoc)
        {
            MinMaxLoc(src, out _, out _, out minLoc, out maxLoc);
        }

        /// <summary>
        /// finds global minimum and maximum array elements and returns their values and their locations
        /// </summary>
        /// <param name="src">The source single-channel array</param>
        /// <param name="minVal">Pointer to returned minimum value</param>
        /// <param name="maxVal">Pointer to returned maximum value</param>
        /// <param name="minLoc">Pointer to returned minimum location</param>
        /// <param name="maxLoc">Pointer to returned maximum location</param>
        /// <param name="mask">The optional mask used to select a sub-array</param>
        public static void MinMaxLoc(InputArray src, out double minVal, out double maxVal,
            out Point minLoc, out Point maxLoc, InputArray? mask = null)
        {
            if (src == null)
                throw new ArgumentNullException(nameof(src));
            src.ThrowIfDisposed();

            NativeMethods.HandleException(
                NativeMethods.core_minMaxLoc2(
                    src.CvPtr, out minVal, out maxVal, out minLoc, out maxLoc, ToPtr(mask)));

            GC.KeepAlive(src);
            GC.KeepAlive(mask);
        }

        /// <summary>
        /// finds global minimum and maximum array elements and returns their values and their locations
        /// </summary>
        /// <param name="src">The source single-channel array</param>
        /// <param name="minVal">Pointer to returned minimum value</param>
        /// <param name="maxVal">Pointer to returned maximum value</param>
        public static void MinMaxIdx(InputArray src, out double minVal, out double maxVal)
        {
            if (src == null)
                throw new ArgumentNullException(nameof(src));
            src.ThrowIfDisposed();

            NativeMethods.HandleException(
                NativeMethods.core_minMaxIdx1(src.CvPtr, out minVal, out maxVal));

            GC.KeepAlive(src);
        }

        /// <summary>
        /// finds global minimum and maximum array elements and returns their values and their locations
        /// </summary>
        /// <param name="src">The source single-channel array</param>
        /// <param name="minIdx"></param>
        /// <param name="maxIdx"></param>
        public static void MinMaxIdx(InputArray src, int[] minIdx, int[] maxIdx)
        {
            MinMaxIdx(src, out _, out _, minIdx, maxIdx);
        }

        /// <summary>
        /// finds global minimum and maximum array elements and returns their values and their locations
        /// </summary>
        /// <param name="src">The source single-channel array</param>
        /// <param name="minVal">Pointer to returned minimum value</param>
        /// <param name="maxVal">Pointer to returned maximum value</param>
        /// <param name="minIdx"></param>
        /// <param name="maxIdx"></param>
        /// <param name="mask"></param>
        public static void MinMaxIdx(InputArray src, out double minVal, out double maxVal,
            int[] minIdx, int[] maxIdx, InputArray? mask = null)
        {
            if (src == null)
                throw new ArgumentNullException(nameof(src));
            if (minIdx == null)
                throw new ArgumentNullException(nameof(minIdx));
            if (maxIdx == null)
                throw new ArgumentNullException(nameof(maxIdx));
            src.ThrowIfDisposed();

            NativeMethods.HandleException(
                NativeMethods.core_minMaxIdx2(
                    src.CvPtr, out minVal, out maxVal, minIdx, maxIdx, ToPtr(mask)));

            GC.KeepAlive(src);
        }

        /// <summary>
        /// transforms 2D matrix to 1D row or column vector by taking sum, minimum, maximum or mean value over all the rows
        /// </summary>
        /// <param name="src">The source 2D matrix</param>
        /// <param name="dst">The destination vector. 
        /// Its size and type is defined by dim and dtype parameters</param>
        /// <param name="dim">The dimension index along which the matrix is reduced. 
        /// 0 means that the matrix is reduced to a single row and 1 means that the matrix is reduced to a single column</param>
        /// <param name="rtype"></param>
        /// <param name="dtype">When it is negative, the destination vector will have 
        /// the same type as the source matrix, otherwise, its type will be CV_MAKE_TYPE(CV_MAT_DEPTH(dtype), mtx.channels())</param>
        public static void Reduce(InputArray src, OutputArray dst, ReduceDimension dim, ReduceTypes rtype, int dtype)
        {
            if (src == null)
                throw new ArgumentNullException(nameof(src));
            if (dst == null)
                throw new ArgumentNullException(nameof(dst));
            src.ThrowIfDisposed();
            dst.ThrowIfNotReady();

            NativeMethods.HandleException(
                NativeMethods.core_reduce(src.CvPtr, dst.CvPtr, (int)dim, (int)rtype, dtype));

            dst.Fix();
            GC.KeepAlive(src);
            GC.KeepAlive(dst);
        }

        /// <summary>
        /// makes multi-channel array out of several single-channel arrays
        /// </summary>
        /// <param name="mv"></param>
        /// <param name="dst"></param>
        public static void Merge(Mat[] mv, Mat dst)
        {
            if (mv == null)
                throw new ArgumentNullException(nameof(mv));
            if (mv.Length == 0)
                throw new ArgumentException("mv.Length == 0");
            if (dst == null)
                throw new ArgumentNullException(nameof(dst));
            foreach (var m in mv)
            {
                if (m == null)
                    throw new ArgumentException("mv contains null element");
                m.ThrowIfDisposed();
            }

            dst.ThrowIfDisposed();

            var mvPtr = new IntPtr[mv.Length];
            for (var i = 0; i < mv.Length; i++)
            {
                mvPtr[i] = mv[i].CvPtr;
            }

            NativeMethods.HandleException(
                NativeMethods.core_merge(mvPtr, (uint)mvPtr.Length, dst.CvPtr));

            GC.KeepAlive(mv);
            GC.KeepAlive(dst);
        }

        /// <summary>
        /// Copies each plane of a multi-channel array to a dedicated array
        /// </summary>
        /// <param name="src">The source multi-channel array</param>
        /// <param name="mv">The destination array or vector of arrays; 
        /// The number of arrays must match mtx.channels() . 
        /// The arrays themselves will be reallocated if needed</param>
        public static void Split(Mat src, out Mat[] mv)
        {
            if (src == null)
                throw new ArgumentNullException(nameof(src));
            src.ThrowIfDisposed();

            using var vec = new VectorOfMat();
            NativeMethods.HandleException(
                NativeMethods.core_split(src.CvPtr, vec.CvPtr));
            mv = vec.ToArray();

            GC.KeepAlive(src);
        }

        /// <summary>
        /// Copies each plane of a multi-channel array to a dedicated array
        /// </summary>
        /// <param name="src">The source multi-channel array</param>
        /// <returns>The number of arrays must match mtx.channels() . 
        /// The arrays themselves will be reallocated if needed</returns>
        public static Mat[] Split(Mat src)
        {
            Split(src, out var mv);
            return mv;
        }

        /// <summary>
        /// copies selected channels from the input arrays to the selected channels of the output arrays
        /// </summary>
        /// <param name="src"></param>
        /// <param name="dst"></param>
        /// <param name="fromTo"></param>
        public static void MixChannels(Mat[] src, Mat[] dst, int[] fromTo)
        {
            if (src == null)
                throw new ArgumentNullException(nameof(src));
            if (dst == null)
                throw new ArgumentNullException(nameof(dst));
            if (fromTo == null)
                throw new ArgumentNullException(nameof(fromTo));
            if (src.Length == 0)
                throw new ArgumentException("src.Length == 0");
            if (dst.Length == 0)
                throw new ArgumentException("dst.Length == 0");
            if (fromTo.Length == 0 || fromTo.Length % 2 != 0)
                throw new ArgumentException("fromTo.Length == 0");
            var srcPtr = new IntPtr[src.Length];
            var dstPtr = new IntPtr[dst.Length];
            for (var i = 0; i < src.Length; i++)
            {
                src[i].ThrowIfDisposed();
                srcPtr[i] = src[i].CvPtr;
            }

            for (var i = 0; i < dst.Length; i++)
            {
                dst[i].ThrowIfDisposed();
                dstPtr[i] = dst[i].CvPtr;
            }
            NativeMethods.HandleException(
            NativeMethods.core_mixChannels(
                srcPtr, (uint)src.Length, dstPtr, (uint)dst.Length,
                fromTo, (uint)(fromTo.Length / 2)));

            GC.KeepAlive(src);
            GC.KeepAlive(dst);
        }

        /// <summary>
        /// extracts a single channel from src (coi is 0-based index)
        /// </summary>
        /// <param name="src"></param>
        /// <param name="dst"></param>
        /// <param name="coi"></param>
        public static void ExtractChannel(InputArray src, OutputArray dst, int coi)
        {
            if (src == null)
                throw new ArgumentNullException(nameof(src));
            if (dst == null)
                throw new ArgumentNullException(nameof(dst));
            src.ThrowIfDisposed();
            dst.ThrowIfNotReady();

            NativeMethods.HandleException(
                NativeMethods.core_extractChannel(src.CvPtr, dst.CvPtr, coi));

            GC.KeepAlive(src);
            GC.KeepAlive(dst);
            dst.Fix();
        }

        /// <summary>
        /// inserts a single channel to dst (coi is 0-based index)
        /// </summary>
        /// <param name="src"></param>
        /// <param name="dst"></param>
        /// <param name="coi"></param>
        public static void InsertChannel(InputArray src, InputOutputArray dst, int coi)
        {
            if (src == null)
                throw new ArgumentNullException(nameof(src));
            if (dst == null)
                throw new ArgumentNullException(nameof(dst));
            src.ThrowIfDisposed();
            dst.ThrowIfNotReady();

            NativeMethods.HandleException(
                NativeMethods.core_insertChannel(src.CvPtr, dst.CvPtr, coi));

            GC.KeepAlive(src);
            GC.KeepAlive(dst);
            dst.Fix();
        }

        /// <summary>
        /// reverses the order of the rows, columns or both in a matrix
        /// </summary>
        /// <param name="src">The source array</param>
        /// <param name="dst">The destination array; will have the same size and same type as src</param>
        /// <param name="flipCode">Specifies how to flip the array: 
        /// 0 means flipping around the x-axis, positive (e.g., 1) means flipping around y-axis, 
        /// and negative (e.g., -1) means flipping around both axes. See also the discussion below for the formulas.</param>
        public static void Flip(InputArray src, OutputArray dst, FlipMode flipCode)
        {
            if (src == null)
                throw new ArgumentNullException(nameof(src));
            if (dst == null)
                throw new ArgumentNullException(nameof(dst));
            src.ThrowIfDisposed();
            dst.ThrowIfNotReady();

            NativeMethods.HandleException(
                NativeMethods.core_flip(src.CvPtr, dst.CvPtr, (int) flipCode));

            GC.KeepAlive(src);
            dst.Fix();
        }

        /// <summary>
        /// Rotates a 2D array in multiples of 90 degrees.
        /// </summary>
        /// <param name="src">input array.</param>
        /// <param name="dst">output array of the same type as src.
        /// The size is the same with ROTATE_180, and the rows and cols are switched for
        /// ROTATE_90_CLOCKWISE and ROTATE_90_COUNTERCLOCKWISE.</param>
        /// <param name="rotateCode">an enum to specify how to rotate the array.</param>
        public static void Rotate(InputArray src, OutputArray dst, RotateFlags rotateCode)
        {
            if (src == null)
                throw new ArgumentNullException(nameof(src));
            if (dst == null)
                throw new ArgumentNullException(nameof(dst));
            src.ThrowIfDisposed();
            dst.ThrowIfNotReady();

            NativeMethods.HandleException(
                NativeMethods.core_rotate(src.CvPtr, dst.CvPtr, (int)rotateCode));

            GC.KeepAlive(src);
            dst.Fix();
        }

        /// <summary>
        /// replicates the input matrix the specified number of times in the horizontal and/or vertical direction
        /// </summary>
        /// <param name="src">The source array to replicate</param>
        /// <param name="ny">How many times the src is repeated along the vertical axis</param>
        /// <param name="nx">How many times the src is repeated along the horizontal axis</param>
        /// <param name="dst">The destination array; will have the same type as src</param>
        public static void Repeat(InputArray src, int ny, int nx, OutputArray dst)
        {
            if (src == null)
                throw new ArgumentNullException(nameof(src));
            if (dst == null)
                throw new ArgumentNullException(nameof(dst));
            src.ThrowIfDisposed();
            dst.ThrowIfNotReady();

            NativeMethods.HandleException(
                NativeMethods.core_repeat1(src.CvPtr, ny, nx, dst.CvPtr));

            GC.KeepAlive(src);
            GC.KeepAlive(dst);
            dst.Fix();
        }

        /// <summary>
        /// replicates the input matrix the specified number of times in the horizontal and/or vertical direction
        /// </summary>
        /// <param name="src">The source array to replicate</param>
        /// <param name="ny">How many times the src is repeated along the vertical axis</param>
        /// <param name="nx">How many times the src is repeated along the horizontal axis</param>
        /// <returns></returns>
        public static Mat Repeat(Mat src, int ny, int nx)
        {
            if (src == null)
                throw new ArgumentNullException(nameof(src));
            src.ThrowIfDisposed();

            NativeMethods.HandleException(
                NativeMethods.core_repeat2(src.CvPtr, ny, nx, out var matPtr));

            GC.KeepAlive(src);
            return new Mat(matPtr);
        }

        /// <summary>
        /// Applies horizontal concatenation to given matrices.
        /// </summary>
        /// <param name="src">input array or vector of matrices. all of the matrices must have the same number of rows and the same depth.</param>
        /// <param name="dst">output array. It has the same number of rows and depth as the src, and the sum of cols of the src.</param>
        public static void HConcat(IEnumerable<Mat> src, OutputArray dst)
        {
            if (src == null)
                throw new ArgumentNullException(nameof(src));
            if (dst == null)
                throw new ArgumentNullException(nameof(dst));

            var srcArray = src as Mat[] ?? src.ToArray();
            if (srcArray.Length == 0)
                throw new ArgumentException("src.Count == 0", nameof(src));
            var srcPtr = new IntPtr[srcArray.Length];
            for (var i = 0; i < srcArray.Length; i++)
            {
                srcArray[i].ThrowIfDisposed();
                srcPtr[i] = srcArray[i].CvPtr;
            }

            NativeMethods.HandleException(
                NativeMethods.core_hconcat1(srcPtr, (uint) srcArray.Length, dst.CvPtr));

            GC.KeepAlive(srcArray);
            GC.KeepAlive(dst);
            dst.Fix();
        }

        /// <summary>
        /// Applies horizontal concatenation to given matrices.
        /// </summary>
        /// <param name="src1">first input array to be considered for horizontal concatenation.</param>
        /// <param name="src2">second input array to be considered for horizontal concatenation.</param>
        /// <param name="dst">output array. It has the same number of rows and depth as the src1 and src2, and the sum of cols of the src1 and src2.</param>
        public static void HConcat(InputArray src1, InputArray src2, OutputArray dst)
        {
            if (src1 == null)
                throw new ArgumentNullException(nameof(src1));
            if (src2 == null)
                throw new ArgumentNullException(nameof(src2));
            if (dst == null)
                throw new ArgumentNullException(nameof(dst));
            src1.ThrowIfDisposed();
            src2.ThrowIfDisposed();
            dst.ThrowIfNotReady();

            NativeMethods.HandleException(
                NativeMethods.core_hconcat2(src1.CvPtr, src2.CvPtr, dst.CvPtr));

            GC.KeepAlive(src1);
            GC.KeepAlive(src2);
            GC.KeepAlive(dst);
            dst.Fix();
        }

        /// <summary>
        /// Applies vertical concatenation to given matrices.
        /// </summary>
        /// <param name="src">input array or vector of matrices. all of the matrices must have the same number of cols and the same depth.</param>
        /// <param name="dst">output array. It has the same number of cols and depth as the src, and the sum of rows of the src.</param>
        public static void VConcat(IEnumerable<Mat> src, OutputArray dst)
        {
            if (src == null)
                throw new ArgumentNullException(nameof(src));
            if (dst == null)
                throw new ArgumentNullException(nameof(dst));

            var srcArray = src as Mat[] ?? src.ToArray();
            if (srcArray.Length == 0)
                throw new ArgumentException("src.Count == 0", nameof(src));
            var srcPtr = new IntPtr[srcArray.Length];
            for (var i = 0; i < srcArray.Length; i++)
            {
                srcArray[i].ThrowIfDisposed();
                srcPtr[i] = srcArray[i].CvPtr;
            }

            NativeMethods.HandleException(
                NativeMethods.core_vconcat1(srcPtr, (uint)srcArray.Length, dst.CvPtr));

            GC.KeepAlive(src);
            GC.KeepAlive(dst);
            dst.Fix();
        }

        /// <summary>
        /// Applies vertical concatenation to given matrices.
        /// </summary>
        /// <param name="src1">first input array to be considered for vertical concatenation.</param>
        /// <param name="src2">second input array to be considered for vertical concatenation.</param>
        /// <param name="dst">output array. It has the same number of cols and depth as the src1 and src2, and the sum of rows of the src1 and src2.</param>
        public static void VConcat(InputArray src1, InputArray src2, OutputArray dst)
        {
            if (src1 == null)
                throw new ArgumentNullException(nameof(src1));
            if (src2 == null)
                throw new ArgumentNullException(nameof(src2));
            if (dst == null)
                throw new ArgumentNullException(nameof(dst));
            src1.ThrowIfDisposed();
            src2.ThrowIfDisposed();
            dst.ThrowIfNotReady();

            NativeMethods.HandleException(
                NativeMethods.core_vconcat2(src1.CvPtr, src2.CvPtr, dst.CvPtr));

            GC.KeepAlive(src1);
            GC.KeepAlive(src2);
            GC.KeepAlive(dst);
            dst.Fix();
        }

        /// <summary>
        /// computes bitwise conjunction of the two arrays (dst = src1 &amp; src2)
        /// </summary>
        /// <param name="src1">first input array or a scalar.</param>
        /// <param name="src2">second input array or a scalar.</param>
        /// <param name="dst">output array that has the same size and type as the input</param>
        /// <param name="mask">optional operation mask, 8-bit single channel array, that specifies elements of the output array to be changed.</param>
        public static void BitwiseAnd(InputArray src1, InputArray src2, OutputArray dst, InputArray? mask = null)
        {
            if (src1 == null)
                throw new ArgumentNullException(nameof(src1));
            if (src2 == null)
                throw new ArgumentNullException(nameof(src2));
            if (dst == null)
                throw new ArgumentNullException(nameof(dst));
            src1.ThrowIfDisposed();
            src2.ThrowIfDisposed();
            dst.ThrowIfNotReady();

            NativeMethods.HandleException(
            NativeMethods.core_bitwise_and(src1.CvPtr, src2.CvPtr, dst.CvPtr, ToPtr(mask)));

            GC.KeepAlive(src1);
            GC.KeepAlive(src2);
            GC.KeepAlive(dst);
            dst.Fix();
            GC.KeepAlive(mask);
        }

        /// <summary>
        /// computes bitwise disjunction of the two arrays (dst = src1 | src2)
        /// </summary>
        /// <param name="src1">first input array or a scalar.</param>
        /// <param name="src2">second input array or a scalar.</param>
        /// <param name="dst">output array that has the same size and type as the input</param>
        /// <param name="mask">optional operation mask, 8-bit single channel array, that specifies elements of the output array to be changed.</param>
        public static void BitwiseOr(InputArray src1, InputArray src2, OutputArray dst, InputArray? mask = null)
        {
            if (src1 == null)
                throw new ArgumentNullException(nameof(src1));
            if (src2 == null)
                throw new ArgumentNullException(nameof(src2));
            if (dst == null)
                throw new ArgumentNullException(nameof(dst));
            src1.ThrowIfDisposed();
            src2.ThrowIfDisposed();
            dst.ThrowIfNotReady();

            NativeMethods.HandleException(
                NativeMethods.core_bitwise_or(src1.CvPtr, src2.CvPtr, dst.CvPtr, ToPtr(mask)));

            GC.KeepAlive(src1);
            GC.KeepAlive(src2);
            GC.KeepAlive(dst);
            GC.KeepAlive(mask);
            dst.Fix();
        }

        /// <summary>
        /// computes bitwise exclusive-or of the two arrays (dst = src1 ^ src2)
        /// </summary>
        /// <param name="src1">first input array or a scalar.</param>
        /// <param name="src2">second input array or a scalar.</param>
        /// <param name="dst">output array that has the same size and type as the input</param>
        /// <param name="mask">optional operation mask, 8-bit single channel array, that specifies elements of the output array to be changed.</param>
        public static void BitwiseXor(InputArray src1, InputArray src2, OutputArray dst, InputArray? mask = null)
        {
            if (src1 == null)
                throw new ArgumentNullException(nameof(src1));
            if (src2 == null)
                throw new ArgumentNullException(nameof(src2));
            if (dst == null)
                throw new ArgumentNullException(nameof(dst));
            src1.ThrowIfDisposed();
            src2.ThrowIfDisposed();
            dst.ThrowIfNotReady();

            NativeMethods.HandleException(
                NativeMethods.core_bitwise_xor(src1.CvPtr, src2.CvPtr, dst.CvPtr, ToPtr(mask)));

            GC.KeepAlive(src1);
            GC.KeepAlive(src2);
            GC.KeepAlive(dst);
            GC.KeepAlive(mask);
            dst.Fix();
        }

        /// <summary>
        /// inverts each bit of array (dst = ~src)
        /// </summary>
        /// <param name="src">input array.</param>
        /// <param name="dst">output array that has the same size and type as the input</param>
        /// <param name="mask">optional operation mask, 8-bit single channel array, that specifies elements of the output array to be changed.</param>
        public static void BitwiseNot(InputArray src, OutputArray dst, InputArray? mask = null)
        {
            if (src == null)
                throw new ArgumentNullException(nameof(src));
            if (dst == null)
                throw new ArgumentNullException(nameof(dst));
            src.ThrowIfDisposed();
            dst.ThrowIfNotReady();

            NativeMethods.HandleException(
                NativeMethods.core_bitwise_not(src.CvPtr, dst.CvPtr, ToPtr(mask)));

            GC.KeepAlive(src);
            GC.KeepAlive(dst);
            GC.KeepAlive(mask);
            dst.Fix();
        }

        /// <summary>
        /// Calculates the per-element absolute difference between two arrays or between an array and a scalar.
        /// </summary>
        /// <param name="src1">first input array or a scalar.</param>
        /// <param name="src2">second input array or a scalar.</param>
        /// <param name="dst">output array that has the same size and type as input arrays.</param>
        public static void Absdiff(InputArray src1, InputArray src2, OutputArray dst)
        {
            if (src1 == null)
                throw new ArgumentNullException(nameof(src1));
            if (src2 == null)
                throw new ArgumentNullException(nameof(src2));
            if (dst == null)
                throw new ArgumentNullException(nameof(dst));
            src1.ThrowIfDisposed();
            src2.ThrowIfDisposed();
            dst.ThrowIfNotReady();
            
            NativeMethods.HandleException(
                NativeMethods.core_absdiff(src1.CvPtr, src2.CvPtr, dst.CvPtr));

            GC.KeepAlive(src1);
            GC.KeepAlive(src2);
            GC.KeepAlive(dst);
            dst.Fix();
        }

        /// <summary>
        /// Copies the matrix to another one.
        /// When the operation mask is specified, if the Mat::create call shown above reallocates the matrix, the newly allocated matrix is initialized with all zeros before copying the data.
        /// </summary>
        /// <param name="src">Source matrix.</param>
        /// <param name="dst">Destination matrix. If it does not have a proper size or type before the operation, it is reallocated.</param>
        /// <param name="mask">Operation mask of the same size as \*this. Its non-zero elements indicate which matrix
        /// elements need to be copied.The mask has to be of type CV_8U and can have 1 or multiple channels.</param>
        public static void CopyTo(InputArray src, OutputArray dst, InputArray? mask = null)
        {
            if (src == null)
                throw new ArgumentNullException(nameof(src));
            if (dst == null)
                throw new ArgumentNullException(nameof(dst));
            src.ThrowIfDisposed();
            dst.ThrowIfNotReady();

            NativeMethods.HandleException(
                NativeMethods.core_copyTo(src.CvPtr, dst.CvPtr, ToPtr(mask)));

            GC.KeepAlive(src);
            GC.KeepAlive(dst);
            GC.KeepAlive(mask);
            dst.Fix();
        }

        /// <summary>
        /// Checks if array elements lie between the elements of two other arrays.
        /// </summary>
        /// <param name="src">first input array.</param>
        /// <param name="lowerb">inclusive lower boundary array or a scalar.</param>
        /// <param name="upperb">inclusive upper boundary array or a scalar.</param>
        /// <param name="dst">output array of the same size as src and CV_8U type.</param>
        public static void InRange(InputArray src, InputArray lowerb, InputArray upperb, OutputArray dst)
        {
            if (src == null)
                throw new ArgumentNullException(nameof(src));
            if (lowerb == null)
                throw new ArgumentNullException(nameof(lowerb));
            if (upperb == null)
                throw new ArgumentNullException(nameof(upperb));
            if (dst == null)
                throw new ArgumentNullException(nameof(dst));
            src.ThrowIfDisposed();
            lowerb.ThrowIfDisposed();
            upperb.ThrowIfDisposed();
            dst.ThrowIfNotReady();

            NativeMethods.HandleException(
                NativeMethods.core_inRange_InputArray(src.CvPtr, lowerb.CvPtr, upperb.CvPtr, dst.CvPtr));

            GC.KeepAlive(src);
            GC.KeepAlive(lowerb);
            GC.KeepAlive(upperb);
            GC.KeepAlive(dst);
            dst.Fix();
        }

        /// <summary>
        /// Checks if array elements lie between the elements of two other arrays.
        /// </summary>
        /// <param name="src">first input array.</param>
        /// <param name="lowerb">inclusive lower boundary array or a scalar.</param>
        /// <param name="upperb">inclusive upper boundary array or a scalar.</param>
        /// <param name="dst">output array of the same size as src and CV_8U type.</param>
        public static void InRange(InputArray src, Scalar lowerb, Scalar upperb, OutputArray dst)
        {
            if (src == null)
                throw new ArgumentNullException(nameof(src));
            if (dst == null)
                throw new ArgumentNullException(nameof(dst));
            src.ThrowIfDisposed();
            dst.ThrowIfNotReady();

            NativeMethods.HandleException(
                NativeMethods.core_inRange_Scalar(src.CvPtr, lowerb, upperb, dst.CvPtr));

            GC.KeepAlive(src);
            GC.KeepAlive(dst);
            dst.Fix();
        }

        /// <summary>
        /// Performs the per-element comparison of two arrays or an array and scalar value.
        /// </summary>
        /// <param name="src1">first input array or a scalar; when it is an array, it must have a single channel.</param>
        /// <param name="src2">second input array or a scalar; when it is an array, it must have a single channel.</param>
        /// <param name="dst">output array of type ref CV_8U that has the same size and the same number of channels as the input arrays.</param>
        /// <param name="cmpop">a flag, that specifies correspondence between the arrays (cv::CmpTypes)</param>
        // ReSharper disable once IdentifierTypo
        public static void Compare(InputArray src1, InputArray src2, OutputArray dst, CmpTypes cmpop)
        {
            if (src1 == null)
                throw new ArgumentNullException(nameof(src1));
            if (src2 == null)
                throw new ArgumentNullException(nameof(src2));
            if (dst == null)
                throw new ArgumentNullException(nameof(dst));
            src1.ThrowIfDisposed();
            src2.ThrowIfDisposed();
            dst.ThrowIfNotReady();

            NativeMethods.HandleException(
                NativeMethods.core_compare(src1.CvPtr, src2.CvPtr, dst.CvPtr, (int) cmpop));

            GC.KeepAlive(src1);
            GC.KeepAlive(src2);
            GC.KeepAlive(dst);
            dst.Fix();
        }

        /// <summary>
        /// computes per-element minimum of two arrays (dst = min(src1, src2))
        /// </summary>
        /// <param name="src1"></param>
        /// <param name="src2"></param>
        /// <param name="dst"></param>
        public static void Min(InputArray src1, InputArray src2, OutputArray dst)
        {
            if (src1 == null)
                throw new ArgumentNullException(nameof(src1));
            if (src2 == null)
                throw new ArgumentNullException(nameof(src2));
            if (dst == null)
                throw new ArgumentNullException(nameof(dst));
            src1.ThrowIfDisposed();
            src2.ThrowIfDisposed();
            dst.ThrowIfNotReady();

            NativeMethods.HandleException(
                NativeMethods.core_min1(src1.CvPtr, src2.CvPtr, dst.CvPtr));

            GC.KeepAlive(src1);
            GC.KeepAlive(src2);
            GC.KeepAlive(dst);
            dst.Fix();
        }

        /// <summary>
        /// computes per-element minimum of two arrays (dst = min(src1, src2))
        /// </summary>
        /// <param name="src1"></param>
        /// <param name="src2"></param>
        /// <param name="dst"></param>
        public static void Min(Mat src1, Mat src2, Mat dst)
        {
            if (src1 == null)
                throw new ArgumentNullException(nameof(src1));
            if (src2 == null)
                throw new ArgumentNullException(nameof(src2));
            if (dst == null)
                throw new ArgumentNullException(nameof(dst));
            src1.ThrowIfDisposed();
            src2.ThrowIfDisposed();
            dst.ThrowIfDisposed();

            NativeMethods.HandleException(
                NativeMethods.core_min_MatMat(src1.CvPtr, src2.CvPtr, dst.CvPtr));

            GC.KeepAlive(src1);
            GC.KeepAlive(src2);
            GC.KeepAlive(dst);
        }

        /// <summary>
        /// computes per-element minimum of array and scalar (dst = min(src1, src2))
        /// </summary>
        /// <param name="src1"></param>
        /// <param name="src2"></param>
        /// <param name="dst"></param>
        public static void Min(Mat src1, double src2, Mat dst)
        {
            if (src1 == null)
                throw new ArgumentNullException(nameof(src1));
            if (dst == null)
                throw new ArgumentNullException(nameof(dst));
            src1.ThrowIfDisposed();
            dst.ThrowIfDisposed();

            NativeMethods.HandleException(
                NativeMethods.core_min_MatDouble(src1.CvPtr, src2, dst.CvPtr));

            GC.KeepAlive(src1);
            GC.KeepAlive(dst);
        }

        /// <summary>
        /// computes per-element maximum of two arrays (dst = max(src1, src2))
        /// </summary>
        /// <param name="src1"></param>
        /// <param name="src2"></param>
        /// <param name="dst"></param>
        public static void Max(InputArray src1, InputArray src2, OutputArray dst)
        {
            if (src1 == null)
                throw new ArgumentNullException(nameof(src1));
            if (src2 == null)
                throw new ArgumentNullException(nameof(src2));
            if (dst == null)
                throw new ArgumentNullException(nameof(dst));
            src1.ThrowIfDisposed();
            src2.ThrowIfDisposed();
            dst.ThrowIfNotReady();

            NativeMethods.HandleException(
                NativeMethods.core_max1(src1.CvPtr, src2.CvPtr, dst.CvPtr));

            GC.KeepAlive(src1);
            GC.KeepAlive(src2);
            GC.KeepAlive(dst);
            dst.Fix();
        }

        /// <summary>
        /// computes per-element maximum of two arrays (dst = max(src1, src2))
        /// </summary>
        /// <param name="src1"></param>
        /// <param name="src2"></param>
        /// <param name="dst"></param>
        public static void Max(Mat src1, Mat src2, Mat dst)
        {
            if (src1 == null)
                throw new ArgumentNullException(nameof(src1));
            if (src2 == null)
                throw new ArgumentNullException(nameof(src2));
            if (dst == null)
                throw new ArgumentNullException(nameof(dst));
            src1.ThrowIfDisposed();
            src2.ThrowIfDisposed();
            dst.ThrowIfDisposed();

            NativeMethods.HandleException(
                NativeMethods.core_max_MatMat(src1.CvPtr, src2.CvPtr, dst.CvPtr));

            GC.KeepAlive(src1);
            GC.KeepAlive(src2);
            GC.KeepAlive(dst);
        }

        /// <summary>
        /// computes per-element maximum of array and scalar (dst = max(src1, src2))
        /// </summary>
        /// <param name="src1"></param>
        /// <param name="src2"></param>
        /// <param name="dst"></param>
        public static void Max(Mat src1, double src2, Mat dst)
        {
            if (src1 == null)
                throw new ArgumentNullException(nameof(src1));
            if (dst == null)
                throw new ArgumentNullException(nameof(dst));
            src1.ThrowIfDisposed();
            dst.ThrowIfDisposed();

            NativeMethods.HandleException(
                NativeMethods.core_max_MatDouble(src1.CvPtr, src2, dst.CvPtr));

            GC.KeepAlive(src1);
            GC.KeepAlive(dst);
        }

        /// <summary>
        /// computes square root of each matrix element (dst = src**0.5)
        /// </summary>
        /// <param name="src">The source floating-point array</param>
        /// <param name="dst">The destination array; will have the same size and the same type as src</param>
        public static void Sqrt(InputArray src, OutputArray dst)
        {
            if (src == null)
                throw new ArgumentNullException(nameof(src));
            if (dst == null)
                throw new ArgumentNullException(nameof(dst));
            src.ThrowIfDisposed();
            dst.ThrowIfNotReady();

            NativeMethods.HandleException(
                NativeMethods.core_sqrt(src.CvPtr, dst.CvPtr));

            GC.KeepAlive(src);
            GC.KeepAlive(dst);
            dst.Fix();
        }

        /// <summary>
        /// raises the input matrix elements to the specified power (b = a**power)
        /// </summary>
        /// <param name="src">The source array</param>
        /// <param name="power">The exponent of power</param>
        /// <param name="dst">The destination array; will have the same size and the same type as src</param>
        public static void Pow(InputArray src, double power, OutputArray dst)
        {
            if (src == null)
                throw new ArgumentNullException(nameof(src));
            if (dst == null)
                throw new ArgumentNullException(nameof(dst));
            src.ThrowIfDisposed();
            dst.ThrowIfNotReady();

            NativeMethods.HandleException(
                NativeMethods.core_pow_Mat(src.CvPtr, power, dst.CvPtr));

            GC.KeepAlive(src);
            GC.KeepAlive(dst);
            dst.Fix();
        }

        /// <summary>
        /// computes exponent of each matrix element (dst = e**src)
        /// </summary>
        /// <param name="src">The source array</param>
        /// <param name="dst">The destination array; will have the same size and same type as src</param>
        public static void Exp(InputArray src, OutputArray dst)
        {
            if (src == null)
                throw new ArgumentNullException(nameof(src));
            if (dst == null)
                throw new ArgumentNullException(nameof(dst));
            src.ThrowIfDisposed();
            dst.ThrowIfNotReady();

            NativeMethods.HandleException(
                NativeMethods.core_exp_Mat(src.CvPtr, dst.CvPtr));

            GC.KeepAlive(src);
            GC.KeepAlive(dst);
            dst.Fix();
        }

        /// <summary>
        /// computes natural logarithm of absolute value of each matrix element: dst = log(abs(src))
        /// </summary>
        /// <param name="src">The source array</param>
        /// <param name="dst">The destination array; will have the same size and same type as src</param>
        public static void Log(InputArray src, OutputArray dst)
        {
            if (src == null)
                throw new ArgumentNullException(nameof(src));
            if (dst == null)
                throw new ArgumentNullException(nameof(dst));
            src.ThrowIfDisposed();
            dst.ThrowIfNotReady();

            NativeMethods.HandleException(
                NativeMethods.core_log_Mat(src.CvPtr, dst.CvPtr));

            GC.KeepAlive(src);
            GC.KeepAlive(dst);
            dst.Fix();
        }


        /// <summary>
        /// Calculates x and y coordinates of 2D vectors from their magnitude and angle.
        /// </summary>
        /// <param name="magnitude">input floating-point array of magnitudes of 2D vectors;
        /// it can be an empty matrix(=Mat()), in this case, the function assumes that all the magnitudes are = 1; if it is not empty,
        /// it must have the same size and type as angle.</param>
        /// <param name="angle">input floating-point array of angles of 2D vectors.</param>
        /// <param name="x">output array of x-coordinates of 2D vectors; it has the same size and type as angle.</param>
        /// <param name="y">output array of y-coordinates of 2D vectors; it has the same size and type as angle.</param>
        /// <param name="angleInDegrees">when true, the input angles are measured in degrees, otherwise, they are measured in radians.</param>
        public static void PolarToCart(InputArray magnitude, InputArray angle,
            OutputArray x, OutputArray y, bool angleInDegrees = false)
        {
            if (magnitude == null)
                throw new ArgumentNullException(nameof(magnitude));
            if (angle == null)
                throw new ArgumentNullException(nameof(angle));
            if (x == null)
                throw new ArgumentNullException(nameof(x));
            if (y == null)
                throw new ArgumentNullException(nameof(y));
            magnitude.ThrowIfDisposed();
            angle.ThrowIfDisposed();
            x.ThrowIfNotReady();
            y.ThrowIfNotReady();
            
            NativeMethods.HandleException(
                NativeMethods.core_polarToCart(magnitude.CvPtr, angle.CvPtr, x.CvPtr, y.CvPtr, angleInDegrees ? 1 : 0));

            GC.KeepAlive(magnitude);
            GC.KeepAlive(angle);
            GC.KeepAlive(x);
            GC.KeepAlive(y);
            x.Fix();
            y.Fix();
        }

        /// <summary>
        /// Calculates the magnitude and angle of 2D vectors.
        /// </summary>
        /// <param name="x">array of x-coordinates; this must be a single-precision or double-precision floating-point array.</param>
        /// <param name="y">array of y-coordinates, that must have the same size and same type as x.</param>
        /// <param name="magnitude">output array of magnitudes of the same size and type as x.</param>
        /// <param name="angle">output array of angles that has the same size and type as x;
        /// the angles are measured in radians(from 0 to 2\*Pi) or in degrees(0 to 360 degrees).</param>
        /// <param name="angleInDegrees">a flag, indicating whether the angles are measured in radians(which is by default), or in degrees.</param>
        public static void CartToPolar(InputArray x, InputArray y,
            OutputArray magnitude, OutputArray angle, bool angleInDegrees = false)
        {
            if (x == null)
                throw new ArgumentNullException(nameof(x));
            if (y == null)
                throw new ArgumentNullException(nameof(y));
            if (magnitude == null)
                throw new ArgumentNullException(nameof(magnitude));
            if (angle == null)
                throw new ArgumentNullException(nameof(angle));
            x.ThrowIfDisposed();
            y.ThrowIfDisposed();
            magnitude.ThrowIfNotReady();
            angle.ThrowIfNotReady();

            NativeMethods.HandleException(
                NativeMethods.core_cartToPolar(x.CvPtr, y.CvPtr, magnitude.CvPtr, angle.CvPtr, angleInDegrees ? 1 : 0));

            GC.KeepAlive(x);
            GC.KeepAlive(y);
            GC.KeepAlive(magnitude);
            GC.KeepAlive(angle);
            magnitude.Fix();
            angle.Fix();
        }

        /// <summary>
        /// Calculates the rotation angle of 2D vectors.
        /// </summary>
        /// <param name="x">input floating-point array of x-coordinates of 2D vectors.</param>
        /// <param name="y">input array of y-coordinates of 2D vectors; it must have the same size and the same type as x.</param>
        /// <param name="angle">output array of vector angles; it has the same size and same type as x.</param>
        /// <param name="angleInDegrees">when true, the function calculates the angle in degrees, otherwise, they are measured in radians.</param>
        public static void Phase(InputArray x, InputArray y, OutputArray angle, bool angleInDegrees = false)
        {
            if (x == null)
                throw new ArgumentNullException(nameof(x));
            if (y == null)
                throw new ArgumentNullException(nameof(y));
            if (angle == null)
                throw new ArgumentNullException(nameof(angle));
            x.ThrowIfDisposed();
            y.ThrowIfDisposed();
            angle.ThrowIfNotReady();

            NativeMethods.HandleException(
                NativeMethods.core_phase(x.CvPtr, y.CvPtr, angle.CvPtr, angleInDegrees ? 1 : 0));

            GC.KeepAlive(x);
            GC.KeepAlive(y);
            GC.KeepAlive(angle);
            angle.Fix();
        }

        /// <summary>
        /// Calculates the magnitude of 2D vectors.
        /// </summary>
        /// <param name="x">floating-point array of x-coordinates of the vectors.</param>
        /// <param name="y">floating-point array of y-coordinates of the vectors; it must have the same size as x.</param>
        /// <param name="magnitude">output array of the same size and type as x.</param>
        public static void Magnitude(InputArray x, InputArray y, OutputArray magnitude)
        {
            if (x == null)
                throw new ArgumentNullException(nameof(x));
            if (y == null)
                throw new ArgumentNullException(nameof(y));
            if (magnitude == null)
                throw new ArgumentNullException(nameof(magnitude));
            x.ThrowIfDisposed();
            y.ThrowIfDisposed();
            magnitude.ThrowIfNotReady();

            NativeMethods.HandleException(
                NativeMethods.core_magnitude_Mat(x.CvPtr, y.CvPtr, magnitude.CvPtr));

            GC.KeepAlive(x);
            GC.KeepAlive(y);
            GC.KeepAlive(magnitude);
            magnitude.Fix();
        }
        
        /// <summary>
        /// checks that each matrix element is within the specified range.
        /// </summary>
        /// <param name="src">The array to check</param>
        /// <param name="quiet">The flag indicating whether the functions quietly 
        /// return false when the array elements are out of range, 
        /// or they throw an exception.</param>
        /// <returns></returns>
        public static bool CheckRange(InputArray src, bool quiet = true)
        {
            return CheckRange(src, quiet, out _);
        }

        /// <summary>
        /// checks that each matrix element is within the specified range.
        /// </summary>
        /// <param name="src">The array to check</param>
        /// <param name="quiet">The flag indicating whether the functions quietly 
        /// return false when the array elements are out of range, 
        /// or they throw an exception.</param>
        /// <param name="pos">The optional output parameter, where the position of 
        /// the first outlier is stored.</param>
        /// <param name="minVal">The inclusive lower boundary of valid values range</param>
        /// <param name="maxVal">The exclusive upper boundary of valid values range</param>
        /// <returns></returns>
        public static bool CheckRange(InputArray src, bool quiet, out Point pos,
            double minVal = double.MinValue, double maxVal = double.MaxValue)
        {
            if (src == null)
                throw new ArgumentNullException(nameof(src));
            src.ThrowIfDisposed();

            NativeMethods.HandleException(
                NativeMethods.core_checkRange(src.CvPtr, quiet ? 1 : 0, out pos, minVal, maxVal, out var ret));
            GC.KeepAlive(src);
            return ret != 0;
        }
        
        /// <summary>
        /// converts NaN's to the given number
        /// </summary>
        /// <param name="a"></param>
        /// <param name="val"></param>
        public static void PatchNaNs(InputOutputArray a, double val = 0)
        {
            if (a == null)
                throw new ArgumentNullException(nameof(a));
            a.ThrowIfNotReady();
            
            NativeMethods.HandleException(
                NativeMethods.core_patchNaNs(a.CvPtr, val));

            GC.KeepAlive(a);
        }
        
        /// <summary>
        /// implements generalized matrix product algorithm GEMM from BLAS
        /// </summary>
        /// <param name="src1"></param>
        /// <param name="src2"></param>
        /// <param name="alpha"></param>
        /// <param name="src3"></param>
        /// <param name="gamma"></param>
        /// <param name="dst"></param>
        /// <param name="flags"></param>
        // ReSharper disable once IdentifierTypo
        public static void Gemm(InputArray src1, InputArray src2, double alpha,
            InputArray src3, double gamma, OutputArray dst, GemmFlags flags = GemmFlags.None)
        {
            if (src1 == null)
                throw new ArgumentNullException(nameof(src1));
            if (src2 == null)
                throw new ArgumentNullException(nameof(src2));
            if (src3 == null)
                throw new ArgumentNullException(nameof(src3));
            if (dst == null)
                throw new ArgumentNullException(nameof(dst));
            src1.ThrowIfDisposed();
            src2.ThrowIfDisposed();
            src3.ThrowIfDisposed();
            dst.ThrowIfNotReady();

            NativeMethods.HandleException(
                NativeMethods.core_gemm(src1.CvPtr, src2.CvPtr, alpha, src3.CvPtr, gamma, dst.CvPtr, (int) flags));

            GC.KeepAlive(src1);
            GC.KeepAlive(src2);
            GC.KeepAlive(src3);
            GC.KeepAlive(dst);
            dst.Fix();
        }
        
        /// <summary>
        /// multiplies matrix by its transposition from the left or from the right
        /// </summary>
        /// <param name="src">The source matrix</param>
        /// <param name="dst">The destination square matrix</param>
        /// <param name="aTa">Specifies the multiplication ordering; see the description below</param>
        /// <param name="delta">The optional delta matrix, subtracted from src before the 
        /// multiplication. When the matrix is empty ( delta=Mat() ), it’s assumed to be 
        /// zero, i.e. nothing is subtracted, otherwise if it has the same size as src, 
        /// then it’s simply subtracted, otherwise it is "repeated" to cover the full src 
        /// and then subtracted. Type of the delta matrix, when it's not empty, must be the 
        /// same as the type of created destination matrix, see the rtype description</param>
        /// <param name="scale">The optional scale factor for the matrix product</param>
        /// <param name="dtype">When it’s negative, the destination matrix will have the 
        /// same type as src . Otherwise, it will have type=CV_MAT_DEPTH(rtype), 
        /// which should be either CV_32F or CV_64F</param>
        public static void MulTransposed(InputArray src, OutputArray dst, bool aTa,
            InputArray? delta = null, double scale = 1, int dtype = -1)
        {
            if (src == null)
                throw new ArgumentNullException(nameof(src));
            if (dst == null)
                throw new ArgumentNullException(nameof(dst));
            src.ThrowIfDisposed();
            dst.ThrowIfNotReady();
            
            NativeMethods.HandleException(
                NativeMethods.core_mulTransposed(src.CvPtr, dst.CvPtr, aTa ? 1 : 0, ToPtr(delta), scale, dtype));

            GC.KeepAlive(src);
            GC.KeepAlive(dst);
            GC.KeepAlive(delta);
            dst.Fix();
        }
        
        /// <summary>
        /// transposes the matrix
        /// </summary>
        /// <param name="src">The source array</param>
        /// <param name="dst">The destination array of the same type as src</param>
        public static void Transpose(InputArray src, OutputArray dst)
        {
            if (src == null)
                throw new ArgumentNullException(nameof(src));
            if (dst == null)
                throw new ArgumentNullException(nameof(dst));
            src.ThrowIfDisposed();
            dst.ThrowIfNotReady();
            

            NativeMethods.HandleException(
                NativeMethods.core_transpose(src.CvPtr, dst.CvPtr));

            GC.KeepAlive(src);
            GC.KeepAlive(dst);
            dst.Fix();
        }
        
        /// <summary>
        /// performs affine transformation of each element of multi-channel input matrix
        /// </summary>
        /// <param name="src">The source array; must have as many channels (1 to 4) as mtx.cols or mtx.cols-1</param>
        /// <param name="dst">The destination array; will have the same size and depth as src and as many channels as mtx.rows</param>
        /// <param name="m">The transformation matrix</param>
        public static void Transform(InputArray src, OutputArray dst, InputArray m)
        {
            if (src == null)
                throw new ArgumentNullException(nameof(src));
            if (dst == null)
                throw new ArgumentNullException(nameof(dst));
            if (m == null)
                throw new ArgumentNullException(nameof(m));
            src.ThrowIfDisposed();
            dst.ThrowIfNotReady();
            m.ThrowIfDisposed();
            
            NativeMethods.HandleException(
                NativeMethods.core_transform(src.CvPtr, dst.CvPtr, m.CvPtr));

            GC.KeepAlive(src);
            GC.KeepAlive(dst);
            GC.KeepAlive(m);
            dst.Fix();
        }

                /// <summary>
        /// performs perspective transformation of each element of multi-channel input matrix
        /// </summary>
        /// <param name="src">The source two-channel or three-channel floating-point array; 
        /// each element is 2D/3D vector to be transformed</param>
        /// <param name="dst">The destination array; it will have the same size and same type as src</param>
        /// <param name="m">3x3 or 4x4 transformation matrix</param>
        public static void PerspectiveTransform(InputArray src, OutputArray dst, InputArray m)
        {
            if (src == null)
                throw new ArgumentNullException(nameof(src));
            if (dst == null)
                throw new ArgumentNullException(nameof(dst));
            if (m == null)
                throw new ArgumentNullException(nameof(m));
            src.ThrowIfDisposed();
            dst.ThrowIfNotReady();
            m.ThrowIfDisposed();
            
            NativeMethods.HandleException(
                NativeMethods.core_perspectiveTransform(src.CvPtr, dst.CvPtr, m.CvPtr));

            GC.KeepAlive(src);
            GC.KeepAlive(dst);
            GC.KeepAlive(m);
            dst.Fix();
        }

        /// <summary>
        /// performs perspective transformation of each element of multi-channel input matrix
        /// </summary>
        /// <param name="src">The source two-channel or three-channel floating-point array; 
        /// each element is 2D/3D vector to be transformed</param>
        /// <param name="m">3x3 or 4x4 transformation matrix</param>
        /// <returns>The destination array; it will have the same size and same type as src</returns>
        public static Point2f[] PerspectiveTransform(IEnumerable<Point2f> src, Mat m)
        {
            if (src == null)
                throw new ArgumentNullException(nameof(src));
            if (m == null)
                throw new ArgumentNullException(nameof(m));

            using var srcMat = Mat<Point2f>.FromArray(src);
            using var dstMat = new Mat<Point2f>();

            NativeMethods.HandleException(
                NativeMethods.core_perspectiveTransform_Mat(srcMat.CvPtr, dstMat.CvPtr, m.CvPtr));

            GC.KeepAlive(m);
            return dstMat.ToArray();
        }

        /// <summary>
        /// performs perspective transformation of each element of multi-channel input matrix
        /// </summary>
        /// <param name="src">The source two-channel or three-channel floating-point array; 
        /// each element is 2D/3D vector to be transformed</param>
        /// <param name="m">3x3 or 4x4 transformation matrix</param>
        /// <returns>The destination array; it will have the same size and same type as src</returns>
        public static Point2d[] PerspectiveTransform(IEnumerable<Point2d> src, Mat m)
        {
            if (src == null)
                throw new ArgumentNullException(nameof(src));
            if (m == null)
                throw new ArgumentNullException(nameof(m));

            using var srcMat = Mat<Point2d>.FromArray(src);
            using var dstMat = new Mat<Point2d>();

            NativeMethods.HandleException(
                NativeMethods.core_perspectiveTransform_Mat(srcMat.CvPtr, dstMat.CvPtr, m.CvPtr));

            GC.KeepAlive(m);
            return dstMat.ToArray();
        }

        /// <summary>
        /// performs perspective transformation of each element of multi-channel input matrix
        /// </summary>
        /// <param name="src">The source two-channel or three-channel floating-point array; 
        /// each element is 2D/3D vector to be transformed</param>
        /// <param name="m">3x3 or 4x4 transformation matrix</param>
        /// <returns>The destination array; it will have the same size and same type as src</returns>
        public static Point3f[] PerspectiveTransform(IEnumerable<Point3f> src, Mat m)
        {
            if (src == null)
                throw new ArgumentNullException(nameof(src));
            if (m == null)
                throw new ArgumentNullException(nameof(m));

            using var srcMat = Mat<Point3f>.FromArray(src);
            using var dstMat = new Mat<Point3f>();

            NativeMethods.HandleException(
                NativeMethods.core_perspectiveTransform_Mat(srcMat.CvPtr, dstMat.CvPtr, m.CvPtr));

            GC.KeepAlive(m);
            return dstMat.ToArray();
        }

        /// <summary>
        /// performs perspective transformation of each element of multi-channel input matrix
        /// </summary>
        /// <param name="src">The source two-channel or three-channel floating-point array; 
        /// each element is 2D/3D vector to be transformed</param>
        /// <param name="m">3x3 or 4x4 transformation matrix</param>
        /// <returns>The destination array; it will have the same size and same type as src</returns>
        public static Point3d[] PerspectiveTransform(IEnumerable<Point3d> src, Mat m)
        {
            if (src == null)
                throw new ArgumentNullException(nameof(src));
            if (m == null)
                throw new ArgumentNullException(nameof(m));

            using var srcMat = Mat<Point3d>.FromArray(src);
            using var dstMat = new Mat<Point3d>();

            NativeMethods.HandleException(
                NativeMethods.core_perspectiveTransform_Mat(srcMat.CvPtr, dstMat.CvPtr, m.CvPtr));

            GC.KeepAlive(m);
            return dstMat.ToArray();
        }
        
        /// <summary>
        /// extends the symmetrical matrix from the lower half or from the upper half
        /// </summary>
        /// <param name="mtx"> Input-output floating-point square matrix</param>
        /// <param name="lowerToUpper">If true, the lower half is copied to the upper half, 
        /// otherwise the upper half is copied to the lower half</param>
        // ReSharper disable once IdentifierTypo
        public static void CompleteSymm(InputOutputArray mtx, bool lowerToUpper = false)
        {
            if (mtx == null)
                throw new ArgumentNullException(nameof(mtx));
            mtx.ThrowIfNotReady();

            NativeMethods.HandleException(
                NativeMethods.core_completeSymm(mtx.CvPtr, lowerToUpper ? 1 : 0));

            GC.KeepAlive(mtx);
            mtx.Fix();
        }
        
        /// <summary>
        /// initializes scaled identity matrix
        /// </summary>
        /// <param name="mtx">The matrix to initialize (not necessarily square)</param>
        /// <param name="s">The value to assign to the diagonal elements</param>
        public static void SetIdentity(InputOutputArray mtx, Scalar? s = null)
        {
            if (mtx == null)
                throw new ArgumentNullException(nameof(mtx));
            mtx.ThrowIfNotReady();

            var s0 = s.GetValueOrDefault(new Scalar(1));
            NativeMethods.HandleException(
                NativeMethods.core_setIdentity(mtx.CvPtr, s0));

            GC.KeepAlive(mtx);
            mtx.Fix();
        }
        
        /// <summary>
        /// computes determinant of a square matrix
        /// </summary>
        /// <param name="mtx">The input matrix; must have CV_32FC1 or CV_64FC1 type and square size</param>
        /// <returns>determinant of the specified matrix.</returns>
        public static double Determinant(InputArray mtx)
        {
            if (mtx == null)
                throw new ArgumentNullException(nameof(mtx));
            mtx.ThrowIfDisposed();

            NativeMethods.HandleException(
                NativeMethods.core_determinant(mtx.CvPtr, out var ret));

            GC.KeepAlive(mtx);
            return ret;
        }
        
        /// <summary>
        /// computes trace of a matrix
        /// </summary>
        /// <param name="mtx">The source matrix</param>
        /// <returns></returns>
        public static Scalar Trace(InputArray mtx)
        {
            if (mtx == null)
                throw new ArgumentNullException(nameof(mtx));
            mtx.ThrowIfDisposed();

            NativeMethods.HandleException(
                NativeMethods.core_trace(mtx.CvPtr, out var ret));

            GC.KeepAlive(mtx);
            return ret;
        }

        /// <summary>
        /// computes inverse or pseudo-inverse matrix
        /// </summary>
        /// <param name="src">The source floating-point MxN matrix</param>
        /// <param name="dst">The destination matrix; will have NxM size and the same type as src</param>
        /// <param name="flags">The inversion method</param>
        /// <returns></returns>
        public static double Invert(InputArray src, OutputArray dst,
            DecompTypes flags = DecompTypes.LU)
        {
            if (src == null)
                throw new ArgumentNullException(nameof(src));
            if (dst == null)
                throw new ArgumentNullException(nameof(dst));
            src.ThrowIfDisposed();
            dst.ThrowIfNotReady();

            NativeMethods.HandleException(
                NativeMethods.core_invert(src.CvPtr, dst.CvPtr, (int) flags, out var ret));

            GC.KeepAlive(src);
            GC.KeepAlive(dst);
            dst.Fix();
            return ret;
        }
        
        /// <summary>
        /// solves linear system or a least-square problem
        /// </summary>
        /// <param name="src1"></param>
        /// <param name="src2"></param>
        /// <param name="dst"></param>
        /// <param name="flags"></param>
        /// <returns></returns>
        public static bool Solve(InputArray src1, InputArray src2, OutputArray dst,
            DecompTypes flags = DecompTypes.LU)
        {
            if (src1 == null)
                throw new ArgumentNullException(nameof(src1));
            if (src2 == null)
                throw new ArgumentNullException(nameof(src2));
            if (dst == null)
                throw new ArgumentNullException(nameof(dst));
            src1.ThrowIfDisposed();
            src2.ThrowIfDisposed();
            dst.ThrowIfNotReady();

            NativeMethods.HandleException(
                NativeMethods.core_solve(src1.CvPtr, src2.CvPtr, dst.CvPtr, (int) flags, out var ret));

            GC.KeepAlive(src1);
            GC.KeepAlive(src2);
            GC.KeepAlive(dst);
            dst.Fix();
            return ret != 0;
        }
        
        /// <summary>
        /// Solve given (non-integer) linear programming problem using the Simplex Algorithm (Simplex Method).
        /// </summary>
        /// <param name="func">This row-vector corresponds to \f$c\f$ in the LP problem formulation (see above). 
        /// It should contain 32- or 64-bit floating point numbers.As a convenience, column-vector may be also submitted,
        /// in the latter case it is understood to correspond to \f$c^T\f$.</param>
        /// <param name="constr">`m`-by-`n+1` matrix, whose rightmost column corresponds to \f$b\f$ in formulation above 
        /// and the remaining to \f$A\f$. It should containt 32- or 64-bit floating point numbers.</param>
        /// <param name="z">The solution will be returned here as a column-vector - it corresponds to \f$c\f$ in the 
        /// formulation above.It will contain 64-bit floating point numbers.</param>
        /// <returns></returns>
        // ReSharper disable once InconsistentNaming
        // ReSharper disable once IdentifierTypo
        public static SolveLPResult SolveLP(InputArray func, InputArray constr, OutputArray z)
        {
            if (func == null)
                throw new ArgumentNullException(nameof(func));
            if (constr == null)
                throw new ArgumentNullException(nameof(constr));
            if (z == null)
                throw new ArgumentNullException(nameof(z));
            func.ThrowIfDisposed();
            constr.ThrowIfDisposed();
            z.ThrowIfNotReady();

            NativeMethods.HandleException(
                NativeMethods.core_solveLP(func.CvPtr, constr.CvPtr, z.CvPtr, out var ret));

            GC.KeepAlive(func);
            GC.KeepAlive(constr);
            z.Fix();
            return (SolveLPResult) ret;
        }
        
        /// <summary>
        /// sorts independently each matrix row or each matrix column
        /// </summary>
        /// <param name="src">The source single-channel array</param>
        /// <param name="dst">The destination array of the same size and the same type as src</param>
        /// <param name="flags">The operation flags, a combination of the SortFlag values</param>
        public static void Sort(InputArray src, OutputArray dst, SortFlags flags)
        {
            if (src == null)
                throw new ArgumentNullException(nameof(src));
            if (dst == null)
                throw new ArgumentNullException(nameof(dst));
            src.ThrowIfDisposed();
            dst.ThrowIfNotReady();

            NativeMethods.HandleException(
                NativeMethods.core_sort(src.CvPtr, dst.CvPtr, (int) flags));

            GC.KeepAlive(src);
            GC.KeepAlive(dst);
            dst.Fix();
        }

        /// <summary>
        /// sorts independently each matrix row or each matrix column
        /// </summary>
        /// <param name="src">The source single-channel array</param>
        /// <param name="dst">The destination integer array of the same size as src</param>
        /// <param name="flags">The operation flags, a combination of SortFlag values</param>
        public static void SortIdx(InputArray src, OutputArray dst, SortFlags flags)
        {
            if (src == null)
                throw new ArgumentNullException(nameof(src));
            if (dst == null)
                throw new ArgumentNullException(nameof(dst));
            src.ThrowIfDisposed();
            dst.ThrowIfNotReady();

            NativeMethods.HandleException(
                NativeMethods.core_sortIdx(src.CvPtr, dst.CvPtr, (int) flags));

            GC.KeepAlive(src);
            GC.KeepAlive(dst);
            dst.Fix();
        }
        
        /// <summary>
        /// finds real roots of a cubic polynomial
        /// </summary>
        /// <param name="coeffs">The equation coefficients, an array of 3 or 4 elements</param>
        /// <param name="roots">The destination array of real roots which will have 1 or 3 elements</param>
        /// <returns></returns>
        public static int SolveCubic(InputArray coeffs, OutputArray roots)
        {
            if (coeffs == null)
                throw new ArgumentNullException(nameof(coeffs));
            if (roots == null)
                throw new ArgumentNullException(nameof(roots));
            coeffs.ThrowIfDisposed();
            roots.ThrowIfNotReady();

            NativeMethods.HandleException(
                NativeMethods.core_solveCubic(coeffs.CvPtr, roots.CvPtr, out var ret));

            GC.KeepAlive(coeffs);
            GC.KeepAlive(roots);
            roots.Fix();
            return ret;
        }

        /// <summary>
        /// finds real and complex roots of a polynomial
        /// </summary>
        /// <param name="coeffs">The array of polynomial coefficients</param>
        /// <param name="roots">The destination (complex) array of roots</param>
        /// <param name="maxIters">The maximum number of iterations the algorithm does</param>
        /// <returns></returns>
        public static double SolvePoly(InputArray coeffs, OutputArray roots, int maxIters = 300)
        {
            if (coeffs == null)
                throw new ArgumentNullException(nameof(coeffs));
            if (roots == null)
                throw new ArgumentNullException(nameof(roots));
            coeffs.ThrowIfDisposed();
            roots.ThrowIfNotReady();

            NativeMethods.HandleException(
                NativeMethods.core_solvePoly(coeffs.CvPtr, roots.CvPtr, maxIters, out var ret));

            GC.KeepAlive(coeffs);
            GC.KeepAlive(roots);
            roots.Fix();
            return ret;
        }
        
        /// <summary>
        /// Computes eigenvalues and eigenvectors of a symmetric matrix.
        /// </summary>
        /// <param name="src">The input matrix; must have CV_32FC1 or CV_64FC1 type, 
        /// square size and be symmetric: src^T == src</param>
        /// <param name="eigenvalues">The output vector of eigenvalues of the same type as src; 
        /// The eigenvalues are stored in the descending order.</param>
        /// <param name="eigenvectors">The output matrix of eigenvectors; 
        /// It will have the same size and the same type as src; The eigenvectors are stored 
        /// as subsequent matrix rows, in the same order as the corresponding eigenvalues</param>
        /// <returns></returns>
        public static bool Eigen(InputArray src, OutputArray eigenvalues, OutputArray eigenvectors)
        {
            if (src == null)
                throw new ArgumentNullException(nameof(src));
            if (eigenvalues == null)
                throw new ArgumentNullException(nameof(eigenvalues));
            if (eigenvectors == null)
                throw new ArgumentNullException(nameof(eigenvectors));
            src.ThrowIfDisposed();
            eigenvalues.ThrowIfNotReady();
            eigenvectors.ThrowIfNotReady();

            NativeMethods.HandleException(
                NativeMethods.core_eigen(src.CvPtr, eigenvalues.CvPtr, eigenvectors.CvPtr, out var ret));

            eigenvalues.Fix();
            eigenvectors.Fix();
            GC.KeepAlive(src);
            GC.KeepAlive(eigenvalues);
            GC.KeepAlive(eigenvectors);
            return ret != 0;
        }

        /// <summary>
        /// Calculates eigenvalues and eigenvectors of a non-symmetric matrix (real eigenvalues only).
        /// </summary>
        /// <param name="src">input matrix (CV_32FC1 or CV_64FC1 type).</param>
        /// <param name="eigenvalues">output vector of eigenvalues (type is the same type as src).</param>
        /// <param name="eigenvectors">output matrix of eigenvectors (type is the same type as src). The eigenvectors are stored as subsequent matrix rows, in the same order as the corresponding eigenvalues.</param>
        public static void EigenNonSymmetric(InputArray src, OutputArray eigenvalues, OutputArray eigenvectors)
        {
            if (src == null)
                throw new ArgumentNullException(nameof(src));
            if (eigenvalues == null)
                throw new ArgumentNullException(nameof(eigenvalues));
            if (eigenvectors == null)
                throw new ArgumentNullException(nameof(eigenvectors));
            src.ThrowIfDisposed();
            eigenvalues.ThrowIfNotReady();
            eigenvectors.ThrowIfNotReady();

            NativeMethods.HandleException(
                NativeMethods.core_eigenNonSymmetric(src.CvPtr, eigenvalues.CvPtr, eigenvectors.CvPtr));

            eigenvalues.Fix();
            eigenvectors.Fix();
            GC.KeepAlive(src);
            GC.KeepAlive(eigenvalues);
            GC.KeepAlive(eigenvectors);
        }

       
        /// <summary>
        /// computes covariation matrix of a set of samples
        /// </summary>
        /// <param name="samples">samples stored as separate matrices</param>
        /// <param name="covar">output covariance matrix of the type ctype and square size.</param>
        /// <param name="mean">input or output (depending on the flags) array as the average value of the input vectors.</param>
        /// <param name="flags">operation flags as a combination of CovarFlags</param>
        /// <param name="ctype">type of the matrixl; it equals 'CV_64F' by default.</param>
        public static void CalcCovarMatrix(
            Mat[] samples, Mat covar, Mat mean,
            CovarFlags flags, MatType? ctype = null)
        {
            if (samples == null)
                throw new ArgumentNullException(nameof(samples));
            if (covar == null)
                throw new ArgumentNullException(nameof(covar));
            if (mean == null)
                throw new ArgumentNullException(nameof(mean));
            covar.ThrowIfDisposed();
            mean.ThrowIfDisposed();
            var samplesPtr = samples.Select(x => x.CvPtr).ToArray();

            var ctypeValue = ctype.GetValueOrDefault(MatType.CV_64F);
            NativeMethods.HandleException(
                NativeMethods.core_calcCovarMatrix_Mat(samplesPtr, samples.Length, covar.CvPtr, mean.CvPtr, (int) flags, ctypeValue));

            GC.KeepAlive(samples);
            GC.KeepAlive(covar);
            GC.KeepAlive(mean);
        }

        /// <summary>
        /// computes covariation matrix of a set of samples
        /// </summary>
        /// <param name="samples">samples stored as rows/columns of a single matrix.</param>
        /// <param name="covar">output covariance matrix of the type ctype and square size.</param>
        /// <param name="mean">input or output (depending on the flags) array as the average value of the input vectors.</param>
        /// <param name="flags">operation flags as a combination of CovarFlags</param>
        /// <param name="ctype">type of the matrixl; it equals 'CV_64F' by default.</param>
        public static void CalcCovarMatrix(
            InputArray samples, OutputArray covar,
            InputOutputArray mean, CovarFlags flags, MatType? ctype = null)
        {
            if (samples == null)
                throw new ArgumentNullException(nameof(samples));
            if (covar == null)
                throw new ArgumentNullException(nameof(covar));
            if (mean == null)
                throw new ArgumentNullException(nameof(mean));
            samples.ThrowIfDisposed();
            covar.ThrowIfNotReady();
            mean.ThrowIfNotReady();

            var ctypeValue = ctype.GetValueOrDefault(MatType.CV_64F);
            NativeMethods.HandleException(
                NativeMethods.core_calcCovarMatrix_InputArray(samples.CvPtr, covar.CvPtr, mean.CvPtr, (int) flags, ctypeValue));

            GC.KeepAlive(samples);
            GC.KeepAlive(covar);
            GC.KeepAlive(mean);
            covar.Fix();
            mean.Fix();
        }
        
        /// <summary>
        /// PCA of the supplied dataset. 
        /// </summary>
        /// <param name="data">input samples stored as the matrix rows or as the matrix columns.</param>
        /// <param name="mean">optional mean value; if the matrix is empty (noArray()), the mean is computed from the data.</param>
        /// <param name="eigenvectors">eigenvectors of the covariation matrix</param>
        /// <param name="maxComponents">maximum number of components that PCA should
        /// retain; by default, all the components are retained.</param>
        public static void PCACompute(
            InputArray data, InputOutputArray mean,
            OutputArray eigenvectors, int maxComponents = 0)
        {
            if (data == null)
                throw new ArgumentNullException(nameof(data));
            if (mean == null)
                throw new ArgumentNullException(nameof(mean));
            if (eigenvectors == null)
                throw new ArgumentNullException(nameof(eigenvectors));
            data.ThrowIfDisposed();
            mean.ThrowIfNotReady();
            eigenvectors.ThrowIfNotReady();

            NativeMethods.HandleException(
                NativeMethods.core_PCACompute(data.CvPtr, mean.CvPtr, eigenvectors.CvPtr, maxComponents));

            GC.KeepAlive(data);
            mean.Fix();
            eigenvectors.Fix();
        }

        /// <summary>
        /// PCA of the supplied dataset. 
        /// </summary>
        /// <param name="data">input samples stored as the matrix rows or as the matrix columns.</param>
        /// <param name="mean">optional mean value; if the matrix is empty (noArray()), the mean is computed from the data.</param>
        /// <param name="eigenvectors">eigenvectors of the covariation matrix</param>
        /// <param name="eigenvalues">eigenvalues of the covariation matrix</param>
        /// <param name="maxComponents">maximum number of components that PCA should
        /// retain; by default, all the components are retained.</param>
        public static void PCACompute(
            InputArray data, InputOutputArray mean,
            OutputArray eigenvectors, OutputArray eigenvalues, int maxComponents = 0)
        {
            if (data == null)
                throw new ArgumentNullException(nameof(data));
            if (mean == null)
                throw new ArgumentNullException(nameof(mean));
            if (eigenvectors == null)
                throw new ArgumentNullException(nameof(eigenvectors));
            if (eigenvalues == null)
                throw new ArgumentNullException(nameof(eigenvalues));
            data.ThrowIfDisposed();
            mean.ThrowIfNotReady();
            eigenvectors.ThrowIfNotReady();
            eigenvalues.ThrowIfNotReady();

            NativeMethods.HandleException(
                NativeMethods.core_PCACompute2(data.CvPtr, mean.CvPtr, eigenvectors.CvPtr, eigenvalues.CvPtr, maxComponents));

            GC.KeepAlive(data);
            mean.Fix();
            eigenvectors.Fix();
            eigenvalues.Fix();
        }

        /// <summary>
        /// PCA of the supplied dataset. 
        /// </summary>
        /// <param name="data">input samples stored as the matrix rows or as the matrix columns.</param>
        /// <param name="mean">optional mean value; if the matrix is empty (noArray()), the mean is computed from the data.</param>
        /// <param name="eigenvectors">eigenvectors of the covariation matrix</param>
        /// <param name="retainedVariance">Percentage of variance that PCA should retain.
        /// Using this parameter will let the PCA decided how many components to retain but it will always keep at least 2.</param>
        public static void PCAComputeVar(
            InputArray data, InputOutputArray mean,
            OutputArray eigenvectors, double retainedVariance)
        {
            if (data == null)
                throw new ArgumentNullException(nameof(data));
            if (mean == null)
                throw new ArgumentNullException(nameof(mean));
            if (eigenvectors == null)
                throw new ArgumentNullException(nameof(eigenvectors));
            data.ThrowIfDisposed();
            mean.ThrowIfNotReady();
            eigenvectors.ThrowIfNotReady();

            NativeMethods.HandleException(
                NativeMethods.core_PCAComputeVar(data.CvPtr, mean.CvPtr, eigenvectors.CvPtr, retainedVariance));

            GC.KeepAlive(data);
            GC.KeepAlive(mean);
            GC.KeepAlive(eigenvectors);
            mean.Fix();
            eigenvectors.Fix();
        }

        /// <summary>
        /// PCA of the supplied dataset. 
        /// </summary>
        /// <param name="data">input samples stored as the matrix rows or as the matrix columns.</param>
        /// <param name="mean">optional mean value; if the matrix is empty (noArray()), the mean is computed from the data.</param>
        /// <param name="eigenvectors">eigenvectors of the covariation matrix</param>
        /// <param name="eigenvalues">eigenvalues of the covariation matrix</param>
        /// <param name="retainedVariance">Percentage of variance that PCA should retain.
        /// Using this parameter will let the PCA decided how many components to retain but it will always keep at least 2.</param>
        public static void PCAComputeVar(
            InputArray data, InputOutputArray mean,
            OutputArray eigenvectors, OutputArray eigenvalues, double retainedVariance)
        {
            if (data == null)
                throw new ArgumentNullException(nameof(data));
            if (mean == null)
                throw new ArgumentNullException(nameof(mean));
            if (eigenvectors == null)
                throw new ArgumentNullException(nameof(eigenvectors));
            if (eigenvalues == null)
                throw new ArgumentNullException(nameof(eigenvalues));
            data.ThrowIfDisposed();
            mean.ThrowIfNotReady();
            eigenvectors.ThrowIfNotReady();
            eigenvalues.ThrowIfNotReady();

            NativeMethods.HandleException(
                NativeMethods.core_PCAComputeVar2(data.CvPtr, mean.CvPtr, eigenvectors.CvPtr, eigenvalues.CvPtr, retainedVariance));

            GC.KeepAlive(data);
            mean.Fix();
            eigenvectors.Fix();
            eigenvalues.Fix();
        }

        /// <summary>
        /// Projects vector(s) to the principal component subspace.
        /// </summary>
        /// <param name="data">input samples stored as the matrix rows or as the matrix columns.</param>
        /// <param name="mean">optional mean value; if the matrix is empty (noArray()), the mean is computed from the data.</param>
        /// <param name="eigenvectors">eigenvectors of the covariation matrix</param>
        /// <param name="result">output vectors</param>
        public static void PCAProject(InputArray data, InputArray mean,
            InputArray eigenvectors, OutputArray result)
        {
            if (data == null)
                throw new ArgumentNullException(nameof(data));
            if (mean == null)
                throw new ArgumentNullException(nameof(mean));
            if (eigenvectors == null)
                throw new ArgumentNullException(nameof(eigenvectors));
            if (result == null)
                throw new ArgumentNullException(nameof(result));
            data.ThrowIfDisposed();
            mean.ThrowIfDisposed();
            eigenvectors.ThrowIfDisposed();
            result.ThrowIfNotReady();

            NativeMethods.HandleException(
                NativeMethods.core_PCAProject(data.CvPtr, mean.CvPtr, eigenvectors.CvPtr, result.CvPtr));

            GC.KeepAlive(data);
            GC.KeepAlive(mean);
            GC.KeepAlive(eigenvectors);
            GC.KeepAlive(result);
            result.Fix();
        }

        /// <summary>
        /// Reconstructs vectors from their PC projections.
        /// </summary>
        /// <param name="data">input samples stored as the matrix rows or as the matrix columns.</param>
        /// <param name="mean">optional mean value; if the matrix is empty (noArray()), the mean is computed from the data.</param>
        /// <param name="eigenvectors">eigenvectors of the covariation matrix</param>
        /// <param name="result">output vectors</param>
        public static void PCABackProject(InputArray data, InputArray mean,
            InputArray eigenvectors, OutputArray result)
        {
            if (data == null)
                throw new ArgumentNullException(nameof(data));
            if (mean == null)
                throw new ArgumentNullException(nameof(mean));
            if (eigenvectors == null)
                throw new ArgumentNullException(nameof(eigenvectors));
            if (result == null)
                throw new ArgumentNullException(nameof(result));
            data.ThrowIfDisposed();
            mean.ThrowIfDisposed();
            eigenvectors.ThrowIfDisposed();
            result.ThrowIfNotReady();

            NativeMethods.HandleException(
                NativeMethods.core_PCABackProject(data.CvPtr, mean.CvPtr, eigenvectors.CvPtr, result.CvPtr));

            GC.KeepAlive(data);
            GC.KeepAlive(mean);
            GC.KeepAlive(eigenvectors);
            GC.KeepAlive(result);
            result.Fix();
        }

        /// <summary>
        /// decomposes matrix and stores the results to user-provided matrices
        /// </summary>
        /// <param name="src">decomposed matrix. The depth has to be CV_32F or CV_64F.</param>
        /// <param name="w">calculated singular values</param>
        /// <param name="u">calculated left singular vectors</param>
        /// <param name="vt">transposed matrix of right singular vectors</param>
        /// <param name="flags">peration flags - see SVD::Flags.</param>
        // ReSharper disable once InconsistentNaming
        // ReSharper disable once IdentifierTypo
        public static void SVDecomp(
            InputArray src, OutputArray w,
            OutputArray u, OutputArray vt, SVD.Flags flags = SVD.Flags.None)
        {
            if (src == null)
                throw new ArgumentNullException(nameof(src));
            if (w == null)
                throw new ArgumentNullException(nameof(w));
            if (u == null)
                throw new ArgumentNullException(nameof(u));
            if (vt == null)
                throw new ArgumentNullException(nameof(vt));
            src.ThrowIfDisposed();
            w.ThrowIfNotReady();
            u.ThrowIfNotReady();
            vt.ThrowIfNotReady();

            NativeMethods.HandleException(
                NativeMethods.core_SVDecomp(src.CvPtr, w.CvPtr, u.CvPtr, vt.CvPtr, (int) flags));

            GC.KeepAlive(src);
            GC.KeepAlive(w);
            GC.KeepAlive(u);
            GC.KeepAlive(vt);
            w.Fix();
            u.Fix();
            vt.Fix();
        }

        /// <summary>
        /// performs back substitution for the previously computed SVD
        /// </summary>
        /// <param name="w">calculated singular values</param>
        /// <param name="u">calculated left singular vectors</param>
        /// <param name="vt">transposed matrix of right singular vectors</param>
        /// <param name="rhs">right-hand side of a linear system (u*w*v')*dst = rhs to be solved, where A has been previously decomposed.</param>
        /// <param name="dst">output</param>
        // ReSharper disable once InconsistentNaming
        public static void SVBackSubst(
            InputArray w, InputArray u, InputArray vt,
            InputArray rhs, OutputArray dst)
        {
            if (w == null)
                throw new ArgumentNullException(nameof(w));
            if (u == null)
                throw new ArgumentNullException(nameof(u));
            if (vt == null)
                throw new ArgumentNullException(nameof(vt));
            if (rhs == null)
                throw new ArgumentNullException(nameof(rhs));
            if (dst == null)
                throw new ArgumentNullException(nameof(dst));
            w.ThrowIfDisposed();
            u.ThrowIfDisposed();
            vt.ThrowIfDisposed();
            rhs.ThrowIfDisposed();
            dst.ThrowIfNotReady();

            NativeMethods.HandleException(
                NativeMethods.core_SVBackSubst(w.CvPtr, u.CvPtr, vt.CvPtr, rhs.CvPtr, dst.CvPtr));

            GC.KeepAlive(w);
            GC.KeepAlive(u);
            GC.KeepAlive(vt);
            GC.KeepAlive(rhs);
            GC.KeepAlive(dst);
            dst.Fix();
        }
        
        /// <summary>
        /// Calculates the Mahalanobis distance between two vectors.
        /// </summary>
        /// <param name="v1">first 1D input vector.</param>
        /// <param name="v2">second 1D input vector.</param>
        /// <param name="icovar">inverse covariance matrix.</param>
        /// <returns></returns>
        public static double Mahalanobis(InputArray v1, InputArray v2, InputArray icovar)
        {
            if (v1 == null)
                throw new ArgumentNullException(nameof(v1));
            if (v2 == null)
                throw new ArgumentNullException(nameof(v2));
            if (icovar == null)
                throw new ArgumentNullException(nameof(icovar));
            v1.ThrowIfDisposed();
            v2.ThrowIfDisposed();
            icovar.ThrowIfDisposed();
            
            NativeMethods.HandleException(
                NativeMethods.core_Mahalanobis(v1.CvPtr, v2.CvPtr, icovar.CvPtr, out var ret));

            GC.KeepAlive(v1);
            GC.KeepAlive(v2);
            GC.KeepAlive(icovar);
            return ret;
        }
        
        /// <summary>
        /// Performs a forward Discrete Fourier transform of 1D or 2D floating-point array.
        /// </summary>
        /// <param name="src">The source array, real or complex</param>
        /// <param name="dst">The destination array, which size and type depends on the flags</param>
        /// <param name="flags">Transformation flags, a combination of the DftFlag2 values</param>
        /// <param name="nonzeroRows">When the parameter != 0, the function assumes that 
        /// only the first nonzeroRows rows of the input array ( DFT_INVERSE is not set) 
        /// or only the first nonzeroRows of the output array ( DFT_INVERSE is set) contain non-zeros, 
        /// thus the function can handle the rest of the rows more efficiently and 
        /// thus save some time. This technique is very useful for computing array cross-correlation 
        /// or convolution using DFT</param>
        public static void Dft(InputArray src, OutputArray dst, DftFlags flags = DftFlags.None, int nonzeroRows = 0)
        {
            if (src == null)
                throw new ArgumentNullException(nameof(src));
            if (dst == null)
                throw new ArgumentNullException(nameof(dst));
            src.ThrowIfDisposed();
            dst.ThrowIfNotReady();

            NativeMethods.HandleException(
                NativeMethods.core_dft(src.CvPtr, dst.CvPtr, (int) flags, nonzeroRows));

            GC.KeepAlive(src);
            GC.KeepAlive(dst);
            dst.Fix();
        }

        /// <summary>
        /// Performs an inverse Discrete Fourier transform of 1D or 2D floating-point array.
        /// </summary>
        /// <param name="src">The source array, real or complex</param>
        /// <param name="dst">The destination array, which size and type depends on the flags</param>
        /// <param name="flags">Transformation flags, a combination of the DftFlag2 values</param>
        /// <param name="nonzeroRows">When the parameter != 0, the function assumes that 
        /// only the first nonzeroRows rows of the input array ( DFT_INVERSE is not set) 
        /// or only the first nonzeroRows of the output array ( DFT_INVERSE is set) contain non-zeros, 
        /// thus the function can handle the rest of the rows more efficiently and 
        /// thus save some time. This technique is very useful for computing array cross-correlation 
        /// or convolution using DFT</param>
        public static void Idft(InputArray src, OutputArray dst, DftFlags flags = DftFlags.None, int nonzeroRows = 0)
        {
            if (src == null)
                throw new ArgumentNullException(nameof(src));
            if (dst == null)
                throw new ArgumentNullException(nameof(dst));
            src.ThrowIfDisposed();
            dst.ThrowIfNotReady();

            NativeMethods.HandleException(
                NativeMethods.core_idft(src.CvPtr, dst.CvPtr, (int) flags, nonzeroRows));

            GC.KeepAlive(src);
            GC.KeepAlive(dst);
            dst.Fix();
        }

        /// <summary>
        /// Performs forward or inverse 1D or 2D Discrete Cosine Transformation
        /// </summary>
        /// <param name="src">The source floating-point array</param>
        /// <param name="dst">The destination array; will have the same size and same type as src</param>
        /// <param name="flags">Transformation flags, a combination of DctFlag2 values</param>
        public static void Dct(InputArray src, OutputArray dst, DctFlags flags = DctFlags.None)
        {
            if (src == null)
                throw new ArgumentNullException(nameof(src));
            if (dst == null)
                throw new ArgumentNullException(nameof(dst));
            src.ThrowIfDisposed();
            dst.ThrowIfNotReady();

            NativeMethods.HandleException(
                NativeMethods.core_dct(src.CvPtr, dst.CvPtr, (int) flags));

            GC.KeepAlive(src);
            GC.KeepAlive(dst);
            dst.Fix();
        }

        /// <summary>
        /// Performs inverse 1D or 2D Discrete Cosine Transformation
        /// </summary>
        /// <param name="src">The source floating-point array</param>
        /// <param name="dst">The destination array; will have the same size and same type as src</param>
        /// <param name="flags">Transformation flags, a combination of DctFlag2 values</param>
        public static void Idct(InputArray src, OutputArray dst, DctFlags flags = DctFlags.None)
        {
            if (src == null)
                throw new ArgumentNullException(nameof(src));
            if (dst == null)
                throw new ArgumentNullException(nameof(dst));
            src.ThrowIfDisposed();
            dst.ThrowIfNotReady();

            NativeMethods.HandleException(
                NativeMethods.core_idct(src.CvPtr, dst.CvPtr, (int) flags));

            GC.KeepAlive(src);
            GC.KeepAlive(dst);
            dst.Fix();
        }

        /// <summary>
        /// Performs the per-element multiplication of two Fourier spectrums.
        /// </summary>
        /// <param name="a">first input array.</param>
        /// <param name="b">second input array of the same size and type as src1.</param>
        /// <param name="c"> output array of the same size and type as src1.</param>
        /// <param name="flags">operation flags; currently, the only supported flag is cv::DFT_ROWS, which indicates that
        /// each row of src1 and src2 is an independent 1D Fourier spectrum. If you do not want to use this flag, then simply add a `0` as value.</param>
        /// <param name="conjB">optional flag that conjugates the second input array before the multiplication (true) or not (false).</param>
        public static void MulSpectrums(
            InputArray a, InputArray b, OutputArray c,
            DftFlags flags, bool conjB = false)
        {
            if (a == null)
                throw new ArgumentNullException(nameof(a));
            if (b == null)
                throw new ArgumentNullException(nameof(b));
            if (c == null)
                throw new ArgumentNullException(nameof(c));
            a.ThrowIfDisposed();
            b.ThrowIfDisposed();
            c.ThrowIfNotReady();

            NativeMethods.HandleException( 
                NativeMethods.core_mulSpectrums(a.CvPtr, b.CvPtr, c.CvPtr, (int) flags, conjB ? 1 : 0));

            GC.KeepAlive(a);
            GC.KeepAlive(b);
            GC.KeepAlive(c);
            c.Fix();
        }

        /// <summary>
        /// Returns the optimal DFT size for a given vector size.
        /// </summary>
        /// <param name="vecSize">vector size.</param>
        /// <returns></returns>
        // ReSharper disable once InconsistentNaming
        public static int GetOptimalDFTSize(int vecSize)
        {
            NativeMethods.HandleException( 
                NativeMethods.core_getOptimalDFTSize(vecSize, out var ret));
            return ret;
        }
        
        /// <summary>
        /// Returns the thread-local Random number generator
        /// </summary>
        /// <returns></returns>
        public static RNG GetTheRNG()
        {
            NativeMethods.HandleException(
                NativeMethods.core_theRNG_get(out var state));
            return new RNG(state);
        }
        
        /// <summary>
        /// Sets the thread-local Random number generator
        /// </summary>
        /// <returns></returns>
        public static RNG SetTheRNG(ulong state)
        {
            NativeMethods.HandleException(
                NativeMethods.core_theRNG_set(state));
            return new RNG(state);
        }

        /// <summary>
        /// fills array with uniformly-distributed random numbers from the range [low, high)
        /// </summary>
        /// <param name="dst">The output array of random numbers. 
        /// The array must be pre-allocated and have 1 to 4 channels</param>
        /// <param name="low">The inclusive lower boundary of the generated random numbers</param>
        /// <param name="high">The exclusive upper boundary of the generated random numbers</param>
        public static void Randu(InputOutputArray dst, InputArray low, InputArray high)
        {
            if (dst == null)
                throw new ArgumentNullException(nameof(dst));
            if (low == null)
                throw new ArgumentNullException(nameof(low));
            if (high == null)
                throw new ArgumentNullException(nameof(high));
            dst.ThrowIfNotReady();
            low.ThrowIfDisposed();
            high.ThrowIfDisposed();

            NativeMethods.HandleException(
                NativeMethods.core_randu_InputArray(dst.CvPtr, low.CvPtr, high.CvPtr));

            GC.KeepAlive(dst);
            GC.KeepAlive(low);
            GC.KeepAlive(high);
            dst.Fix();
        }

        /// <summary>
        /// fills array with uniformly-distributed random numbers from the range [low, high)
        /// </summary>
        /// <param name="dst">The output array of random numbers. 
        /// The array must be pre-allocated and have 1 to 4 channels</param>
        /// <param name="low">The inclusive lower boundary of the generated random numbers</param>
        /// <param name="high">The exclusive upper boundary of the generated random numbers</param>
        // ReSharper disable once IdentifierTypo
        public static void Randu(InputOutputArray dst, Scalar low, Scalar high)
        {
            if (dst == null)
                throw new ArgumentNullException(nameof(dst));
            dst.ThrowIfNotReady();

            NativeMethods.HandleException(
                NativeMethods.core_randu_Scalar(dst.CvPtr, low, high));

            GC.KeepAlive(dst);
            dst.Fix();
        }

        /// <summary>
        /// fills array with normally-distributed random numbers with the specified mean and the standard deviation
        /// </summary>
        /// <param name="dst">The output array of random numbers. 
        /// The array must be pre-allocated and have 1 to 4 channels</param>
        /// <param name="mean">The mean value (expectation) of the generated random numbers</param>
        /// <param name="stddev">The standard deviation of the generated random numbers</param>
        // ReSharper disable once IdentifierTypo
        public static void Randn(InputOutputArray dst, InputArray mean, InputArray stddev)
        {
            if (dst == null)
                throw new ArgumentNullException(nameof(dst));
            if (mean == null)
                throw new ArgumentNullException(nameof(mean));
            if (stddev == null)
                throw new ArgumentNullException(nameof(stddev));
            dst.ThrowIfNotReady();
            mean.ThrowIfDisposed();
            stddev.ThrowIfDisposed();

            NativeMethods.HandleException(
                NativeMethods.core_randn_InputArray(dst.CvPtr, mean.CvPtr, stddev.CvPtr));

            GC.KeepAlive(dst);
            GC.KeepAlive(mean);
            GC.KeepAlive(stddev);
            dst.Fix();
        }

        /// <summary>
        /// fills array with normally-distributed random numbers with the specified mean and the standard deviation
        /// </summary>
        /// <param name="dst">The output array of random numbers. 
        /// The array must be pre-allocated and have 1 to 4 channels</param>
        /// <param name="mean">The mean value (expectation) of the generated random numbers</param>
        /// <param name="stddev">The standard deviation of the generated random numbers</param>
        public static void Randn(InputOutputArray dst, Scalar mean, Scalar stddev)
        {
            if (dst == null)
                throw new ArgumentNullException(nameof(dst));
            dst.ThrowIfNotReady();

            NativeMethods.HandleException(
                NativeMethods.core_randn_Scalar(dst.CvPtr, mean, stddev));

            GC.KeepAlive(dst);
            dst.Fix();
        }
        
        /// <summary>
        /// shuffles the input array elements
        /// </summary>
        /// <param name="dst">The input/output numerical 1D array</param>
        /// <param name="iterFactor">The scale factor that determines the number of random swap operations.</param>
        // ReSharper disable once IdentifierTypo
        public static void RandShuffle(InputOutputArray dst, double iterFactor)
        {
            if (dst == null)
                throw new ArgumentNullException(nameof(dst));
            dst.ThrowIfNotReady();

            NativeMethods.HandleException(
                    NativeMethods.core_randShuffle(dst.CvPtr, iterFactor, IntPtr.Zero));

            GC.KeepAlive(dst);
            dst.Fix();
        }

        /// <summary>
        /// shuffles the input array elements
        /// </summary>
        /// <param name="dst">The input/output numerical 1D array</param>
        /// <param name="iterFactor">The scale factor that determines the number of random swap operations.</param>
        /// <param name="rng">The optional random number generator used for shuffling. 
        /// If it is null, theRng() is used instead.</param>
        // ReSharper disable once IdentifierTypo
        public static void RandShuffle(InputOutputArray dst, double iterFactor, ref RNG rng)
        {
            if (dst == null)
                throw new ArgumentNullException(nameof(dst));
            dst.ThrowIfNotReady();

            var state = rng.State;
            NativeMethods.HandleException(
                NativeMethods.core_randShuffle(dst.CvPtr, iterFactor, ref state));
            rng = new RNG(state);

            GC.KeepAlive(dst);
            dst.Fix();
        }

        /// <summary>
        /// Finds centers of clusters and groups input samples around the clusters.
        /// </summary>
        /// <param name="data">Data for clustering. An array of N-Dimensional points with float coordinates is needed.</param>
        /// <param name="k">Number of clusters to split the set by.</param>
        /// <param name="bestLabels">Input/output integer array that stores the cluster indices for every sample.</param>
        /// <param name="criteria">The algorithm termination criteria, that is, the maximum number of iterations and/or
        /// the desired accuracy. The accuracy is specified as criteria.epsilon. As soon as each of the cluster centers
        /// moves by less than criteria.epsilon on some iteration, the algorithm stops.</param>
        /// <param name="attempts">Flag to specify the number of times the algorithm is executed using different
        /// initial labellings. The algorithm returns the labels that yield the best compactness (see the last function parameter).</param>
        /// <param name="flags">Flag that can take values of cv::KmeansFlags</param>
        /// <param name="centers">Output matrix of the cluster centers, one row per each cluster center.</param>
        /// <returns>The function returns the compactness measure that is computed as
        /// \f[\sum _i  \| \texttt{samples} _i -  \texttt{centers} _{ \texttt{labels} _i} \| ^2\f]
        /// after every attempt. The best (minimum) value is chosen and the corresponding labels and the compactness
        /// value are returned by the function. Basically, you can use only the core of the function,
        /// set the number of attempts to 1, initialize labels each time using a custom algorithm,
        /// pass them with the ( flags = #KMEANS_USE_INITIAL_LABELS ) flag, and then choose the best (most-compact) clustering.</returns>
        public static double Kmeans(InputArray data, int k, InputOutputArray bestLabels,
            TermCriteria criteria, int attempts, KMeansFlags flags, OutputArray? centers = null)
        {
            if (data == null)
                throw new ArgumentNullException(nameof(data));
            if (bestLabels == null)
                throw new ArgumentNullException(nameof(bestLabels));
            data.ThrowIfDisposed();
            bestLabels.ThrowIfDisposed();

            NativeMethods.HandleException(
                NativeMethods.core_kmeans(
                    data.CvPtr, k, bestLabels.CvPtr, criteria, attempts, (int) flags, ToPtr(centers), out var ret));

            bestLabels.Fix();
            centers?.Fix();
            GC.KeepAlive(data);
            GC.KeepAlive(bestLabels);
            GC.KeepAlive(centers);
            return ret;
        }

        #endregion

        #region base.hpp

        /// <summary>
        /// computes the angle in degrees (0..360) of the vector (x,y)
        /// </summary>
        /// <param name="y"></param>
        /// <param name="x"></param>
        /// <returns></returns>
        public static float FastAtan2(float y, float x)
        {
            NativeMethods.HandleException( 
                NativeMethods.core_fastAtan2(y, x, out var ret));
            return ret;
        }

        /// <summary>
        /// computes cube root of the argument
        /// </summary>
        /// <param name="val"></param>
        /// <returns></returns>
        public static float CubeRoot(float val)
        {
            NativeMethods.HandleException(
                NativeMethods.core_cubeRoot(val, out var ret));
            return ret;
        }
        

        #endregion

        #region utility.hpp
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="pattern"></param>
        /// <param name="recursive"></param>
        /// <returns></returns>
        public static string?[] Glob(string pattern, bool recursive = false)
        {
            if (pattern == null)
                throw new ArgumentNullException(nameof(pattern));

            using var resultVec = new VectorOfString();
            NativeMethods.HandleException(
                NativeMethods.core_glob(pattern, resultVec.CvPtr, recursive ? 1 : 0));
            return resultVec.ToArray();
        }

        /// <summary>
        /// OpenCV will try to set the number of threads for the next parallel region.
        /// If threads == 0, OpenCV will disable threading optimizations and run all it's functions
        /// sequentially.Passing threads &lt; 0 will reset threads number to system default. This function must
        /// be called outside of parallel region.
        /// OpenCV will try to run its functions with specified threads number, but some behaviour differs from framework:
        /// -   `TBB` - User-defined parallel constructions will run with the same threads number, if another is not specified.If later on user creates his own scheduler, OpenCV will use it.
        /// -   `OpenMP` - No special defined behaviour.
        /// -   `Concurrency` - If threads == 1, OpenCV will disable threading optimizations and run its functions sequentially.
        /// -   `GCD` - Supports only values &lt;= 0.
        /// -   `C=` - No special defined behaviour.
        /// </summary>
        /// <param name="nThreads">Number of threads used by OpenCV.</param>
        public static void SetNumThreads(int nThreads)
        {
            NativeMethods.HandleException(
                NativeMethods.core_setNumThreads(nThreads));
        }

        /// <summary>
        /// Returns the number of threads used by OpenCV for parallel regions.
        /// 
        /// Always returns 1 if OpenCV is built without threading support.
        /// The exact meaning of return value depends on the threading framework used by OpenCV library:
        /// - `TBB` - The number of threads, that OpenCV will try to use for parallel regions. If there is
        /// any tbb::thread_scheduler_init in user code conflicting with OpenCV, then function returns default
        /// number of threads used by TBB library.
        /// - `OpenMP` - An upper bound on the number of threads that could be used to form a new team.
        /// - `Concurrency` - The number of threads, that OpenCV will try to use for parallel regions.
        /// - `GCD` - Unsupported; returns the GCD thread pool limit(512) for compatibility.
        /// - `C=` - The number of threads, that OpenCV will try to use for parallel regions, if before
        /// called setNumThreads with threads &gt; 0, otherwise returns the number of logical CPUs,
        /// available for the process.
        /// </summary>
        /// <returns></returns>
        public static int GetNumThreads()
        {
            NativeMethods.HandleException(
                NativeMethods.core_getNumThreads(out var ret));
            return ret;
        }
        
        /// <summary>
        /// Returns the index of the currently executed thread within the current parallel region.
        /// Always returns 0 if called outside of parallel region.
        /// @deprecated Current implementation doesn't corresponding to this documentation.
        /// The exact meaning of the return value depends on the threading framework used by OpenCV library:
        /// - `TBB` - Unsupported with current 4.1 TBB release.Maybe will be supported in future.
        /// - `OpenMP` - The thread number, within the current team, of the calling thread.
        /// - `Concurrency` - An ID for the virtual processor that the current context is executing
        /// on(0 for master thread and unique number for others, but not necessary 1,2,3,...).
        /// - `GCD` - System calling thread's ID. Never returns 0 inside parallel region.
        /// - `C=` - The index of the current parallel task.
        /// </summary>
        /// <returns></returns>
        public static int GetThreadNum()
        {
            NativeMethods.HandleException(
                NativeMethods.core_getThreadNum(out var ret));
            return ret;
        }

        /// <summary>
        /// Returns full configuration time cmake output.
        ///
        /// Returned value is raw cmake output including version control system revision, compiler version,
        /// compiler flags, enabled modules and third party libraries, etc.Output format depends on target architecture.
        /// </summary>
        /// <returns></returns>
        public static string GetBuildInformation()
        {
            using var stdString = new StdString();
            NativeMethods.HandleException(
                NativeMethods.core_getBuildInformation(stdString.CvPtr));
            return stdString.ToString();
        }

        /// <summary>
        /// Returns library version string.
        /// For example "3.4.1-dev".
        /// </summary>
        /// <returns></returns>
        public static string GetVersionString()
        {
            const int length = 128;
            var buf = new StringBuilder(length + 1);

            NativeMethods.HandleException(
                NativeMethods.core_getVersionString(buf, buf.Capacity));

            return buf.ToString();
        }

        /// <summary>
        /// Returns major library version
        /// </summary>
        /// <returns></returns>
        public static int GetVersionMajor()
        {
            NativeMethods.HandleException(
                NativeMethods.core_getVersionMajor(out var ret));
            return ret;
        }

        /// <summary>
        /// Returns minor library version
        /// </summary>
        /// <returns></returns>
        public static int GetVersionMinor()
        {
            NativeMethods.HandleException(
                NativeMethods.core_getVersionMinor(out var ret));
            return ret;
        }

        /// <summary>
        /// Returns revision field of the library version
        /// </summary>
        /// <returns></returns>
        public static int GetVersionRevision()
        {
            NativeMethods.HandleException(
                NativeMethods.core_getVersionRevision(out var ret));
            return ret;
        }

        /// <summary>
        /// Returns the number of ticks.
        /// The function returns the number of ticks after the certain event (for example, when the machine was
        /// turned on). It can be used to initialize RNG or to measure a function execution time by reading the
        /// tick count before and after the function call.
        /// </summary>
        /// <returns></returns>
        public static long GetTickCount()
        {
            NativeMethods.HandleException(
                NativeMethods.core_getTickCount(out var ret));
            return ret;
        }

        /// <summary>
        /// Returns the number of ticks per second.
        /// The function returns the number of ticks per second.That is, the following code computes the execution time in seconds:
        /// </summary>
        /// <returns></returns>
        public static double GetTickFrequency()
        {
            NativeMethods.HandleException(
                NativeMethods.core_getTickFrequency(out var ret));
            return ret;
        }

        /// <summary>
        /// Returns the number of CPU ticks.
        ///
        /// The function returns the current number of CPU ticks on some architectures(such as x86, x64, PowerPC).
        /// On other platforms the function is equivalent to getTickCount.It can also be used for very accurate time
        /// measurements, as well as for RNG initialization.Note that in case of multi-CPU systems a thread, from which
        /// getCPUTickCount is called, can be suspended and resumed at another CPU with its own counter. So,
        /// theoretically (and practically) the subsequent calls to the function do not necessary return the monotonously
        /// increasing values. Also, since a modern CPU varies the CPU frequency depending on the load, the number of CPU
        /// clocks spent in some code cannot be directly converted to time units.Therefore, getTickCount is generally
        /// a preferable solution for measuringexecution time.
        /// </summary>
        /// <returns></returns>
        public static long GetCpuTickCount()
        {
            NativeMethods.HandleException(
                NativeMethods.core_getCPUTickCount(out var ret));
            return ret;
        }

        /// <summary>
        /// Returns true if the specified feature is supported by the host hardware.
        /// The function returns true if the host hardware supports the specified feature.When user calls
        /// setUseOptimized(false), the subsequent calls to checkHardwareSupport() will return false until
        /// setUseOptimized(true) is called.This way user can dynamically switch on and off the optimized code in OpenCV.
        /// </summary>
        /// <param name="feature">The feature of interest, one of cv::CpuFeatures</param>
        /// <returns></returns>
        public static bool CheckHardwareSupport(CpuFeatures feature)
        {
            NativeMethods.HandleException(
                NativeMethods.core_checkHardwareSupport((int) feature, out var ret));
            return ret != 0;
        }

        /// <summary>
        /// Returns feature name by ID.
        /// Returns empty string if feature is not defined
        /// </summary>
        /// <param name="feature"></param>
        /// <returns></returns>
        public static string GetHardwareFeatureName(CpuFeatures feature)
        {
            using var buf = new StdString();
            NativeMethods.HandleException(
                NativeMethods.core_getHardwareFeatureName((int) feature, buf.CvPtr));
            return buf.ToString();
        }

        /// <summary>
        /// Returns list of CPU features enabled during compilation.
        /// Returned value is a string containing space separated list of CPU features with following markers:
        /// - no markers - baseline features
        /// - prefix `*` - features enabled in dispatcher
        /// - suffix `?` - features enabled but not available in HW
        /// </summary>
        /// <example>
        /// `SSE SSE2 SSE3* SSE4.1 *SSE4.2 *FP16* AVX *AVX2* AVX512-SKX?`
        /// </example>
        /// <returns></returns>
        public static string GetCpuFeaturesLine()
        {
            using var buf = new StdString();
            NativeMethods.HandleException(
                NativeMethods.core_getCPUFeaturesLine(buf.CvPtr));
            return buf.ToString();
        }

        /// <summary>
        /// Returns the number of logical CPUs available for the process.
        /// </summary>
        /// <returns></returns>
        public static int GetNumberOfCpus()
        {
            NativeMethods.HandleException(
                NativeMethods.core_getNumberOfCPUs(out int ret));
            return ret;
        }

        /*
        /// <summary>
        /// 
        /// </summary>
        /// <param name="bufSize"></param>
        /// <returns></returns>
        public static IntPtr FastMalloc(long bufSize)
        {
            return NativeMethods.core_fastMalloc(new IntPtr(bufSize));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ptr"></param>
        public static void FastFree(IntPtr ptr)
        {
            NativeMethods.core_fastFree(ptr);
        }
        */

        /// <summary>
        /// Turns on/off available optimization.
        /// The function turns on or off the optimized code in OpenCV. Some optimization can not be enabled
        /// or disabled, but, for example, most of SSE code in OpenCV can be temporarily turned on or off this way.
        /// </summary>
        /// <param name="onoff"></param>
        public static void SetUseOptimized(bool onoff)
        {
            NativeMethods.HandleException(
                NativeMethods.core_setUseOptimized(onoff ? 1 : 0));
        }

        /// <summary>
        /// Returns the current optimization status.
        /// The function returns the current optimization status, which is controlled by cv::setUseOptimized().
        /// </summary>
        /// <returns></returns>
        public static bool UseOptimized()
        {
            NativeMethods.HandleException(
                NativeMethods.core_useOptimized(out var ret));
            return ret != 0;
        }

        /// <summary>
        /// Aligns buffer size by the certain number of bytes
        /// This small inline function aligns a buffer size by 
        /// the certian number of bytes by enlarging it.
        /// </summary>
        /// <param name="sz"></param>
        /// <param name="n"></param>
        /// <returns></returns>
        public static int AlignSize(int sz, int n)
        {
            var assert = ((n & (n - 1)) == 0); // n is a power of 2
            if (!assert)
                throw new ArgumentException("n must be a power of 2.", nameof(n));
            return (sz + n - 1) & -n;
        }
        
        /// <summary>
        /// Sets/resets the break-on-error mode.
        /// When the break-on-error mode is set, the default error handler issues a hardware exception,
        /// which can make debugging more convenient.
        /// </summary>
        /// <param name="flag"></param>
        /// <returns>the previous state</returns>
        public static bool SetBreakOnError(bool flag)
        {
            return NativeMethods.core_setBreakOnError(flag ? 1 : 0) != 0;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="mtx"></param>
        /// <param name="format"></param>
        /// <returns></returns>
        public static string? Format(InputArray mtx, FormatType format = FormatType.Default)
        {
            if (mtx == null)
                throw new ArgumentNullException(nameof(mtx));

            using var buf = new StdString();
            NativeMethods.HandleException(
                NativeMethods.core_format(mtx.CvPtr, (int) format, buf.CvPtr));
            GC.KeepAlive(mtx);
            return buf.ToString();
        }

        #endregion

        /// <summary>
        /// Computes absolute value of each matrix element
        /// </summary>
        /// <param name="src">matrix</param>
        /// <returns></returns>
        public static MatExpr Abs(Mat src)
        {
            if (src == null)
                throw new ArgumentNullException(nameof(src));
            src.ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.core_abs_Mat(src.CvPtr, out var ret));
            GC.KeepAlive(src);
            return new MatExpr(ret);
        }

        /// <summary>
        /// Computes absolute value of each matrix element
        /// </summary>
        /// <param name="src">matrix expression</param>
        /// <returns></returns>
        public static MatExpr Abs(MatExpr src)
        {
            if (src == null)
                throw new ArgumentNullException(nameof(src));
            src.ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.core_abs_MatExpr(src.CvPtr, out var ret));
            GC.KeepAlive(src);
            return new MatExpr(ret);
        }
        
        /// <summary>
        /// Equivalence predicate (a boolean function of two arguments).
        /// The predicate returns true when the elements are certainly in the same class, and returns false if they may or may not be in the same class.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="t1"></param>
        /// <param name="t2"></param>
        /// <returns></returns>
        public delegate bool PartitionPredicate<in T>(T t1, T t2);

        /// <summary>
        /// Splits an element set into equivalency classes.
        /// Consider using GroupBy of Linq instead.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="vec">Set of elements stored as a vector.</param>
        /// <param name="labels">Output vector of labels. It contains as many elements as vec. Each label labels[i] is a 0-based cluster index of vec[i] .</param>
        /// <param name="predicate">Equivalence predicate (a boolean function of two arguments).
        /// The predicate returns true when the elements are certainly in the same class, and returns false if they may or may not be in the same class.</param>
        /// <returns></returns>
        public static int Partition<T>(IEnumerable<T> vec, out int[] labels, PartitionPredicate<T> predicate)
        {
            var vecArray = vec as T[] ?? vec.ToArray();
            labels = new int[vecArray.Length];
            var groupHeads = new List<T>();

            var index = 0;
            foreach (var t in vecArray)
            {
                var foundGroup = false;

                var label = 0;
                foreach (var groupHeadElem in groupHeads)
                {
                    if (predicate(groupHeadElem, t))
                    {
                        labels[index] = label;
                        foundGroup = true;
                        break;
                    }

                    label++;
                }

                if (!foundGroup)
                {
                    labels[index] = groupHeads.Count;
                    groupHeads.Add(t);
                }

                index++;
            }

            return groupHeads.Count;
        }
    }
}
