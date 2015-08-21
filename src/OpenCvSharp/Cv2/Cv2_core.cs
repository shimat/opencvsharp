using System;
using System.Collections.Generic;
using System.Text;
using OpenCvSharp.Util;

namespace OpenCvSharp
{
    static partial class Cv2
    {
        #region Miscellaneous
        /// <summary>
        /// 
        /// </summary>
        /// <param name="nthreads"></param>
        public static void SetNumThreads(int nthreads)
        {
            NativeMethods.core_setNumThreads(nthreads);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static int GetNumThreads()
        {
            return NativeMethods.core_getNumThreads();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static int GetThreadNum()
        {
            return NativeMethods.core_getThreadNum();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static string GetBuildInformation()
        {
            StringBuilder buf = new StringBuilder(1 << 16);
            NativeMethods.core_getBuildInformation(buf, (uint)buf.Capacity);
            return buf.ToString();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static long GetTickCount()
        {
            return NativeMethods.core_getTickCount();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static double GetTickFrequency()
        {
            return NativeMethods.core_getTickFrequency();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static long GetCpuTickCount()
        {
            return NativeMethods.core_getCPUTickCount();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="feature"></param>
        /// <returns></returns>
        public static bool CheckHardwareSupport(HardwareSupport feature)
        {
            return NativeMethods.core_checkHardwareSupport(feature) != 0;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static int FetNumberOfCpus()
        {
            return NativeMethods.core_getNumberOfCPUs();
        }
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

        /// <summary>
        /// Turns on/off available optimization.
        /// The function turns on or off the optimized code in OpenCV. Some optimization can not be enabled
        /// or disabled, but, for example, most of SSE code in OpenCV can be temporarily turned on or off this way.
        /// </summary>
        /// <param name="onoff"></param>
        public static void SetUseOptimized(bool onoff)
        {
            NativeMethods.core_setUseOptimized(onoff ? 1 : 0);
        }

        /// <summary>
        /// Returns the current optimization status.
        /// The function returns the current optimization status, which is controlled by cv::setUseOptimized().
        /// </summary>
        /// <returns></returns>
        public static bool UseOptimized()
        {
            return NativeMethods.core_useOptimized() != 0;
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
            bool assert = ((n & (n - 1)) == 0); // n is a power of 2
            if(!assert)
                throw new ArgumentException();
            return (sz + n - 1) & -n;
        }

        #endregion

        #region Abs
        /// <summary>
        /// Computes absolute value of each matrix element
        /// </summary>
        /// <param name="src">matrix</param>
        /// <returns></returns>
        public static MatExpr Abs(Mat src)
        {
            if (src == null)
                throw new ArgumentNullException("src");
            src.ThrowIfDisposed();
            IntPtr retPtr = NativeMethods.core_abs_Mat(src.CvPtr);
            return new MatExpr(retPtr);
        }
        /// <summary>
        /// Computes absolute value of each matrix element
        /// </summary>
        /// <param name="src">matrix expression</param>
        /// <returns></returns>
        public static MatExpr Abs(MatExpr src)
        {
            if (src == null)
                throw new ArgumentNullException("src");
            src.ThrowIfDisposed();
            IntPtr retPtr = NativeMethods.core_abs_MatExpr(src.CvPtr);
            return new MatExpr(retPtr);
        }
        #endregion
        #region Add
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
        public static void Add(InputArray src1, InputArray src2, OutputArray dst, InputArray mask = null, int dtype = -1)
        {
            if (src1 == null)
                throw new ArgumentNullException("src1");
            if (src2 == null)
                throw new ArgumentNullException("src2");
            if (dst == null)
                throw new ArgumentNullException("dst");
            src1.ThrowIfDisposed();
            src2.ThrowIfDisposed();
            dst.ThrowIfNotReady();
            NativeMethods.core_add(src1.CvPtr, src2.CvPtr, dst.CvPtr, ToPtr(mask), dtype);
            dst.Fix();
        }
        #endregion
        #region Subtract
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
        public static void Subtract(InputArray src1, InputArray src2, OutputArray dst, InputArray mask = null, int dtype = -1)
        {
            if (src1 == null)
                throw new ArgumentNullException("src1");
            if (src2 == null)
                throw new ArgumentNullException("src2");
            if (dst == null)
                throw new ArgumentNullException("dst");
            src1.ThrowIfDisposed();
            src2.ThrowIfDisposed();
            dst.ThrowIfNotReady();
            NativeMethods.core_subtract(src1.CvPtr, src2.CvPtr, dst.CvPtr, ToPtr(mask), dtype);
            dst.Fix();
        }
        #endregion
        #region Multiply
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
                throw new ArgumentNullException("src1");
            if (src2 == null)
                throw new ArgumentNullException("src2");
            if (dst == null)
                throw new ArgumentNullException("dst");
            src1.ThrowIfDisposed();
            src2.ThrowIfDisposed();
            dst.ThrowIfNotReady();
            NativeMethods.core_multiply(src1.CvPtr, src2.CvPtr, dst.CvPtr, scale, dtype);
            dst.Fix();

        }
        #endregion
        #region Divide
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
                throw new ArgumentNullException("src1");
            if (src2 == null)
                throw new ArgumentNullException("src2");
            if (dst == null)
                throw new ArgumentNullException("dst");
            src1.ThrowIfDisposed();
            src2.ThrowIfDisposed();
            dst.ThrowIfNotReady();
            NativeMethods.core_divide(src1.CvPtr, src2.CvPtr, dst.CvPtr, scale, dtype);
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
                throw new ArgumentNullException("src2");
            if (dst == null)
                throw new ArgumentNullException("dst");
            src2.ThrowIfDisposed();
            dst.ThrowIfNotReady();
            NativeMethods.core_divide(scale, src2.CvPtr, dst.CvPtr, dtype);
            dst.Fix();
        }
        #endregion
        #region ScaleAdd
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
                throw new ArgumentNullException("src1");
            if (src2 == null)
                throw new ArgumentNullException("src2");
            if (dst == null)
                throw new ArgumentNullException("dst");
            src1.ThrowIfDisposed();
            src2.ThrowIfDisposed();
            dst.ThrowIfNotReady();
            NativeMethods.core_scaleAdd(src1.CvPtr, alpha, src2.CvPtr, dst.CvPtr);
            dst.Fix();
        }
        #endregion
        #region AddWeighted
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
                throw new ArgumentNullException("src1");
            if (src2 == null)
                throw new ArgumentNullException("src2");
            if (dst == null)
                throw new ArgumentNullException("dst");
            src1.ThrowIfDisposed();
            src2.ThrowIfDisposed();
            dst.ThrowIfNotReady();
            NativeMethods.core_addWeighted(src1.CvPtr, alpha, src2.CvPtr, beta, gamma, dst.CvPtr, dtype);
            dst.Fix();
        }
        #endregion

        #region ConvertScaleAbs
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
                throw new ArgumentNullException("src");
            if (dst == null)
                throw new ArgumentNullException("dst");
            src.ThrowIfDisposed();
            dst.ThrowIfNotReady();
            NativeMethods.core_convertScaleAbs(src.CvPtr, dst.CvPtr, alpha, beta);
            dst.Fix();
        }
        #endregion
        #region LUT
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
        /// <param name="interpolation"></param>
        public static void LUT(InputArray src, InputArray lut, OutputArray dst, int interpolation = 0)
        {
            if (src == null)
                throw new ArgumentNullException("src");
            if (lut == null)
                throw new ArgumentNullException("lut");
            if (dst == null)
                throw new ArgumentNullException("dst");
            src.ThrowIfDisposed();
            lut.ThrowIfDisposed();
            dst.ThrowIfNotReady();
            NativeMethods.core_LUT(src.CvPtr, lut.CvPtr, dst.CvPtr);
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
        /// <param name="interpolation"></param>
        public static void LUT(InputArray src, byte[] lut, OutputArray dst, int interpolation = 0)
        {
            if (lut == null)
                throw new ArgumentNullException("lut");
            if (lut.Length != 256)
                throw new ArgumentException("lut.Length != 256");
            using (Mat lutMat = new Mat(256, 1, MatType.CV_8UC1, lut))
            {
                LUT(src, lutMat, dst, interpolation);
            }
        }
        #endregion
        #region Sum
        /// <summary>
        /// computes sum of array elements
        /// </summary>
        /// <param name="src">The source array; must have 1 to 4 channels</param>
        /// <returns></returns>
        public static Scalar Sum(InputArray src)
        {
            if (src == null)
                throw new ArgumentNullException("src");
            src.ThrowIfDisposed();
            return NativeMethods.core_sum(src.CvPtr);
        }
        #endregion
        #region CountNonZero
        /// <summary>
        /// computes the number of nonzero array elements
        /// </summary>
        /// <param name="mtx">Single-channel array</param>
        /// <returns>number of non-zero elements in mtx</returns>
        public static int CountNonZero(InputArray mtx)
        {
            if (mtx == null)
                throw new ArgumentNullException("mtx");
            mtx.ThrowIfDisposed();
            return NativeMethods.core_countNonZero(mtx.CvPtr);
        }
        #endregion
        #region FindNonZero
        /// <summary>
        /// returns the list of locations of non-zero pixels
        /// </summary>
        /// <param name="src"></param>
        /// <param name="idx"></param>
        public static void FindNonZero(InputArray src, OutputArray idx)
        {
            if (src == null)
                throw new ArgumentNullException("src");
            if (idx == null)
                throw new ArgumentNullException("idx");
            src.ThrowIfDisposed();
            idx.ThrowIfNotReady();
            NativeMethods.core_findNonZero(src.CvPtr, idx.CvPtr);
            idx.Fix();
        }
        #endregion
        #region Mean
        /// <summary>
        /// computes mean value of selected array elements
        /// </summary>
        /// <param name="src">The source array; it should have 1 to 4 channels
        ///  (so that the result can be stored in Scalar)</param>
        /// <param name="mask">The optional operation mask</param>
        /// <returns></returns>
        public static Scalar Mean(InputArray src, InputArray mask = null)
        {
            if (src == null)
                throw new ArgumentNullException("src");
            src.ThrowIfDisposed();
            return NativeMethods.core_mean(src.CvPtr, ToPtr(mask));
        }
        #endregion
        #region MeanStdDev
        /// <summary>
        /// computes mean value and standard deviation of all or selected array elements
        /// </summary>
        /// <param name="src">The source array; it should have 1 to 4 channels 
        /// (so that the results can be stored in Scalar's)</param>
        /// <param name="mean">The output parameter: computed mean value</param>
        /// <param name="stddev">The output parameter: computed standard deviation</param>
        /// <param name="mask">The optional operation mask</param>
        public static void MeanStdDev(
            InputArray src, OutputArray mean, OutputArray stddev, InputArray mask = null)
        {
            if (src == null)
                throw new ArgumentNullException("src");
            if (mean == null)
                throw new ArgumentNullException("mean");
            if (stddev == null)
                throw new ArgumentNullException("stddev");
            src.ThrowIfDisposed();
            mean.ThrowIfNotReady();
            stddev.ThrowIfNotReady();

            NativeMethods.core_meanStdDev_OutputArray(src.CvPtr, mean.CvPtr, stddev.CvPtr, ToPtr(mask));

            mean.Fix();
            stddev.Fix();
            GC.KeepAlive(src);
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
            InputArray src, out Scalar mean, out Scalar stddev, InputArray mask = null)
        {
            if (src == null)
                throw new ArgumentNullException("src");

            src.ThrowIfDisposed();

            NativeMethods.core_meanStdDev_Scalar(src.CvPtr, out mean, out stddev, ToPtr(mask));

            GC.KeepAlive(src);
            GC.KeepAlive(mask);
        }
        #endregion
        #region Norm
        /// <summary>
        /// Calculates absolute array norm, absolute difference norm, or relative difference norm.
        /// </summary>
        /// <param name="src1">The first source array</param>
        /// <param name="normType">Type of the norm</param>
        /// <param name="mask">The optional operation mask</param>
        /// <returns></returns>
        public static double Norm(InputArray src1, 
            NormType normType = NormType.L2, InputArray mask = null)
        {
            if (src1 == null)
                throw new ArgumentNullException("src1");
            src1.ThrowIfDisposed();
            return NativeMethods.core_norm(src1.CvPtr, (int)normType, ToPtr(mask));
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
                                  NormType normType = NormType.L2, InputArray mask = null)
        {
            if (src1 == null)
                throw new ArgumentNullException("src1");
            if (src2 == null)
                throw new ArgumentNullException("src2");
            src1.ThrowIfDisposed();
            src2.ThrowIfDisposed();
            return NativeMethods.core_norm(src1.CvPtr, src2.CvPtr, (int)normType, ToPtr(mask));
        }
        #endregion
        #region BatchDistance
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
                                         OutputArray dist, int dtype, OutputArray nidx,
                                         NormType normType = NormType.L2,
                                         int k = 0, InputArray mask = null,
                                         int update = 0, bool crosscheck = false)
        {
            if (src1 == null)
                throw new ArgumentNullException("src1");
            if (src2 == null)
                throw new ArgumentNullException("src2");
            if (dist == null)
                throw new ArgumentNullException("dist");
            if (nidx == null)
                throw new ArgumentNullException("nidx");
            src1.ThrowIfDisposed();
            src2.ThrowIfDisposed();
            dist.ThrowIfNotReady();
            nidx.ThrowIfNotReady();
            NativeMethods.core_batchDistance(src1.CvPtr, src2.CvPtr, dist.CvPtr, dtype, nidx.CvPtr,
                (int)normType, k, ToPtr(mask), update, crosscheck ? 1 : 0);
            dist.Fix();
            nidx.Fix();
        }
        #endregion
        #region Normalize
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
        public static void Normalize( InputArray src, InputOutputArray dst, double alpha=1, double beta=0,
                             NormType normType=NormType.L2, int dtype=-1, InputArray mask=null)
        {
            if (src == null)
                throw new ArgumentNullException("src");
            if (dst == null)
                throw new ArgumentNullException("dst");
            src.ThrowIfDisposed();
            dst.ThrowIfNotReady();
            NativeMethods.core_normalize(src.CvPtr, dst.CvPtr, alpha, beta, (int)normType, dtype, ToPtr(mask));
            dst.Fix();
        }
        #endregion
        #region MinMaxLoc
        /// <summary>
        /// finds global minimum and maximum array elements and returns their values and their locations
        /// </summary>
        /// <param name="src">The source single-channel array</param>
        /// <param name="minVal">Pointer to returned minimum value</param>
        /// <param name="maxVal">Pointer to returned maximum value</param>
        public static void MinMaxLoc(InputArray src, out double minVal, out double maxVal)
        {
            if (src == null)
                throw new ArgumentNullException("src");
            src.ThrowIfDisposed();
            NativeMethods.core_minMaxLoc(src.CvPtr, out minVal, out maxVal);
        }

        /// <summary>
        /// finds global minimum and maximum array elements and returns their values and their locations
        /// </summary>
        /// <param name="src">The source single-channel array</param>
        /// <param name="minLoc">Pointer to returned minimum location</param>
        /// <param name="maxLoc">Pointer to returned maximum location</param>
        public static void MinMaxLoc(InputArray src, out Point minLoc, out Point maxLoc)
        {
            double minVal, maxVal;
            MinMaxLoc(src, out minVal, out maxVal, out minLoc, out maxLoc);
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
            out Point minLoc, out Point maxLoc, InputArray mask = null)
        {
            if (src == null)
                throw new ArgumentNullException("src");
            src.ThrowIfDisposed();

            NativeMethods.core_minMaxLoc(src.CvPtr, out minVal, out maxVal, out minLoc, out maxLoc, ToPtr(mask));
            GC.KeepAlive(src);
        }

        #endregion
        #region MinMaxIdx
        /// <summary>
        /// finds global minimum and maximum array elements and returns their values and their locations
        /// </summary>
        /// <param name="src">The source single-channel array</param>
        /// <param name="minVal">Pointer to returned minimum value</param>
        /// <param name="maxVal">Pointer to returned maximum value</param>
        public static void MinMaxIdx(InputArray src, out double minVal, out double maxVal)
        {
            if (src == null)
                throw new ArgumentNullException("src");
            src.ThrowIfDisposed();
            NativeMethods.core_minMaxIdx(src.CvPtr, out minVal, out maxVal);
        }

        /// <summary>
        /// finds global minimum and maximum array elements and returns their values and their locations
        /// </summary>
        /// <param name="src">The source single-channel array</param>
        /// <param name="minIdx"></param>
        /// <param name="maxIdx"></param>
        public static void MinMaxIdx(InputArray src, out int minIdx, out int maxIdx)
        {
            double minVal, maxVal;
            MinMaxIdx(src, out minVal, out maxVal, out minIdx, out maxIdx, null);
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
            out int minIdx, out int maxIdx, InputArray mask = null)
        {
            if (src == null)
                throw new ArgumentNullException("src");
            src.ThrowIfDisposed();
            NativeMethods.core_minMaxIdx(src.CvPtr, out minVal, out maxVal, out minIdx, out maxIdx, ToPtr(mask));
        }
        #endregion
        #region Reduce
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
        public static void Reduce(InputArray src, OutputArray dst, ReduceDimension dim, ReduceOperation rtype, int dtype)
        {
            if (src == null)
                throw new ArgumentNullException("src");
            if (dst == null)
                throw new ArgumentNullException("dst");
            src.ThrowIfDisposed();
            dst.ThrowIfNotReady();
            NativeMethods.core_reduce(src.CvPtr, dst.CvPtr, (int)dim, (int)rtype, dtype);
            dst.Fix();
        }
        #endregion
        #region Merge
        /// <summary>
        /// makes multi-channel array out of several single-channel arrays
        /// </summary>
        /// <param name="mv"></param>
        /// <param name="dst"></param>
        public static void Merge(Mat[] mv, Mat dst)
        {
            if (mv == null)
                throw new ArgumentNullException("mv");
            if (mv.Length == 0)
                throw new ArgumentException("mv.Length == 0");
            if (dst == null)
                throw new ArgumentNullException("dst");
            foreach (Mat m in mv)
            {
                if(m == null)
                    throw new ArgumentException("mv contains null element");
                m.ThrowIfDisposed();
            }
            dst.ThrowIfDisposed();

            var mvPtr = new IntPtr[mv.Length];
            for (int i = 0; i < mv.Length; i++)
            {
                mvPtr[i] = mv[i].CvPtr;
            }
            NativeMethods.core_merge(mvPtr, (uint)mvPtr.Length, dst.CvPtr);
        }
        #endregion
        #region Split
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
                throw new ArgumentNullException("src");
            src.ThrowIfDisposed();

            IntPtr mvPtr;
            NativeMethods.core_split(src.CvPtr, out mvPtr);

            using (var vec = new VectorOfMat(mvPtr))
            {
                mv = vec.ToArray();
            }
        }
        /// <summary>
        /// Copies each plane of a multi-channel array to a dedicated array
        /// </summary>
        /// <param name="src">The source multi-channel array</param>
        /// <returns>The number of arrays must match mtx.channels() . 
        /// The arrays themselves will be reallocated if needed</returns>
        public static Mat[] Split(Mat src)
        {
            Mat[] mv;
            Split(src, out mv);
            return mv;
        }
        #endregion
        #region MixChannels
        /// <summary>
        /// copies selected channels from the input arrays to the selected channels of the output arrays
        /// </summary>
        /// <param name="src"></param>
        /// <param name="dst"></param>
        /// <param name="fromTo"></param>
        public static void MixChannels(Mat[] src, Mat[] dst, int[] fromTo)
        {
            if (src == null)
                throw new ArgumentNullException("src");
            if (dst == null)
                throw new ArgumentNullException("dst");
            if (fromTo == null)
                throw new ArgumentNullException("fromTo");
            if (src.Length == 0)
                throw new ArgumentException("src.Length == 0");
            if (dst.Length == 0)
                throw new ArgumentException("dst.Length == 0");
            if (fromTo.Length == 0 || fromTo.Length % 2 != 0)
                throw new ArgumentException("fromTo.Length == 0");
            IntPtr[] srcPtr = new IntPtr[src.Length];
            IntPtr[] dstPtr = new IntPtr[dst.Length];
            for (int i = 0; i < src.Length; i++)
            {
                src[i].ThrowIfDisposed();
                srcPtr[i] = src[i].CvPtr;
            }
            for (int i = 0; i < dst.Length; i++)
            {
                dst[i].ThrowIfDisposed();
                dstPtr[i] = dst[i].CvPtr;
            }
            NativeMethods.core_mixChannels(srcPtr, (uint)src.Length, dstPtr, (uint)dst.Length, 
                fromTo, (uint)(fromTo.Length / 2));
        }
        #endregion
        #region ExtractChannel
        /// <summary>
        /// extracts a single channel from src (coi is 0-based index)
        /// </summary>
        /// <param name="src"></param>
        /// <param name="dst"></param>
        /// <param name="coi"></param>
        public static void ExtractChannel(InputArray src, OutputArray dst, int coi)
        {
            if (src == null)
                throw new ArgumentNullException("src");
            if (dst == null)
                throw new ArgumentNullException("dst");
            src.ThrowIfDisposed();
            dst.ThrowIfNotReady();
            NativeMethods.core_extractChannel(src.CvPtr, dst.CvPtr, coi);
            dst.Fix();
        }
        #endregion
        #region InsertChannel
        /// <summary>
        /// inserts a single channel to dst (coi is 0-based index)
        /// </summary>
        /// <param name="src"></param>
        /// <param name="dst"></param>
        /// <param name="coi"></param>
        public static void InsertChannel(InputArray src, InputOutputArray dst, int coi)
        {
            if (src == null)
                throw new ArgumentNullException("src");
            if (dst == null)
                throw new ArgumentNullException("dst");
            src.ThrowIfDisposed();
            dst.ThrowIfNotReady();
            NativeMethods.core_insertChannel(src.CvPtr, dst.CvPtr, coi);
            dst.Fix();
        }
        #endregion
        #region Flip
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
                throw new ArgumentNullException("src");
            if (dst == null)
                throw new ArgumentNullException("dst");
            src.ThrowIfDisposed();
            dst.ThrowIfNotReady();
            NativeMethods.core_flip(src.CvPtr, dst.CvPtr, (int)flipCode);
            dst.Fix();
        }
        #endregion
        #region Repeat
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
                throw new ArgumentNullException("src");
            if (dst == null)
                throw new ArgumentNullException("dst");
            src.ThrowIfDisposed();
            dst.ThrowIfNotReady();
            NativeMethods.core_repeat(src.CvPtr, ny, nx, dst.CvPtr);
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
                throw new ArgumentNullException("src");
            src.ThrowIfDisposed();
            IntPtr matPtr = NativeMethods.core_repeat(src.CvPtr, ny, nx);
            return new Mat(matPtr);
        }
        #endregion
        #region HConcat
        /// <summary>
        /// 
        /// </summary>
        /// <param name="src"></param>
        /// <param name="dst"></param>
        public static void HConcat(Mat[] src, OutputArray dst)
        {
            if (src == null)
                throw new ArgumentNullException("src");
            if (dst == null)
                throw new ArgumentNullException("dst");
            if (src.Length == 0)
                throw new ArgumentException("src.Length == 0");
            IntPtr[] srcPtr = new IntPtr[src.Length];
            for (int i = 0; i < src.Length; i++)
            {
                src[i].ThrowIfDisposed();
                srcPtr[i] = src[i].CvPtr;
            }
            NativeMethods.core_hconcat(srcPtr, (uint)src.Length, dst.CvPtr);
            dst.Fix();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="src1"></param>
        /// <param name="src2"></param>
        /// <param name="dst"></param>
        public static void HConcat(InputArray src1, InputArray src2, OutputArray dst)
        {
            if (src1 == null)
                throw new ArgumentNullException("src1");
            if (src2 == null)
                throw new ArgumentNullException("src2");
            if (dst == null)
                throw new ArgumentNullException("dst");
            src1.ThrowIfDisposed();
            src2.ThrowIfDisposed();
            dst.ThrowIfNotReady();
            NativeMethods.core_hconcat(src1.CvPtr, src2.CvPtr, dst.CvPtr);
            dst.Fix();
        }
        #endregion
        #region VConcat
        /// <summary>
        /// 
        /// </summary>
        /// <param name="src"></param>
        /// <param name="dst"></param>
        public static void VConcat(Mat[] src, OutputArray dst)
        {
            if (src == null)
                throw new ArgumentNullException("src");
            if (dst == null)
                throw new ArgumentNullException("dst");
            if (src.Length == 0)
                throw new ArgumentException("src.Length == 0");
            IntPtr[] srcPtr = new IntPtr[src.Length];
            for (int i = 0; i < src.Length; i++)
            {
                src[i].ThrowIfDisposed();
                srcPtr[i] = src[i].CvPtr;
            }
            NativeMethods.core_vconcat(srcPtr, (uint)src.Length, dst.CvPtr);
            dst.Fix();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="src1"></param>
        /// <param name="src2"></param>
        /// <param name="dst"></param>
        public static void VConcat(InputArray src1, InputArray src2, OutputArray dst)
        {
            if (src1 == null)
                throw new ArgumentNullException("src1");
            if (src2 == null)
                throw new ArgumentNullException("src2");
            if (dst == null)
                throw new ArgumentNullException("dst");
            src1.ThrowIfDisposed();
            src2.ThrowIfDisposed();
            dst.ThrowIfNotReady();
            NativeMethods.core_vconcat(src1.CvPtr, src2.CvPtr, dst.CvPtr);
            dst.Fix();
        }
        #endregion
        #region BitwiseAnd
        /// <summary>
        /// computes bitwise conjunction of the two arrays (dst = src1 &amp; src2)
        /// </summary>
        /// <param name="src1"></param>
        /// <param name="src2"></param>
        /// <param name="dst"></param>
        /// <param name="mask"></param>
        public static void BitwiseAnd(InputArray src1, InputArray src2, OutputArray dst, InputArray mask = null)
        {
            if (src1 == null)
                throw new ArgumentNullException("src1");
            if (src2 == null)
                throw new ArgumentNullException("src2");
            if (dst == null)
                throw new ArgumentNullException("dst");
            src1.ThrowIfDisposed();
            src2.ThrowIfDisposed();
            dst.ThrowIfNotReady();
            NativeMethods.core_bitwise_and(src1.CvPtr, src2.CvPtr, dst.CvPtr, ToPtr(mask));
            dst.Fix();
        }
        #endregion
        #region BitwiseOr
        /// <summary>
        /// computes bitwise disjunction of the two arrays (dst = src1 | src2)
        /// </summary>
        /// <param name="src1"></param>
        /// <param name="src2"></param>
        /// <param name="dst"></param>
        /// <param name="mask"></param>
        public static void BitwiseOr(InputArray src1, InputArray src2, OutputArray dst, InputArray mask = null)
        {
            if (src1 == null)
                throw new ArgumentNullException("src1");
            if (src2 == null)
                throw new ArgumentNullException("src2");
            if (dst == null)
                throw new ArgumentNullException("dst");
            src1.ThrowIfDisposed();
            src2.ThrowIfDisposed();
            dst.ThrowIfNotReady();
            NativeMethods.core_bitwise_or(src1.CvPtr, src2.CvPtr, dst.CvPtr, ToPtr(mask));
            dst.Fix();
        }
        #endregion
        #region BitwiseXor
        /// <summary>
        /// computes bitwise exclusive-or of the two arrays (dst = src1 ^ src2)
        /// </summary>
        /// <param name="src1"></param>
        /// <param name="src2"></param>
        /// <param name="dst"></param>
        /// <param name="mask"></param>
        public static void BitwiseXor(InputArray src1, InputArray src2, OutputArray dst, InputArray mask = null)
        {
            if (src1 == null)
                throw new ArgumentNullException("src1");
            if (src2 == null)
                throw new ArgumentNullException("src2");
            if (dst == null)
                throw new ArgumentNullException("dst");
            src1.ThrowIfDisposed();
            src2.ThrowIfDisposed();
            dst.ThrowIfNotReady();
            NativeMethods.core_bitwise_xor(src1.CvPtr, src2.CvPtr, dst.CvPtr, ToPtr(mask));
            dst.Fix();
        }
        #endregion
        #region BitwiseNot
        /// <summary>
        /// inverts each bit of array (dst = ~src)
        /// </summary>
        /// <param name="src"></param>
        /// <param name="dst"></param>
        /// <param name="mask"></param>
        public static void BitwiseNot(InputArray src, OutputArray dst, InputArray mask = null)
        {
            if (src == null)
                throw new ArgumentNullException("src");
            if (dst == null)
                throw new ArgumentNullException("dst");
            src.ThrowIfDisposed();
            dst.ThrowIfNotReady();
            NativeMethods.core_bitwise_not(src.CvPtr, dst.CvPtr, ToPtr(mask));
            dst.Fix();
        }
        #endregion
        #region Absdiff
        /// <summary>
        /// computes element-wise absolute difference of two arrays (dst = abs(src1 - src2))
        /// </summary>
        /// <param name="src1"></param>
        /// <param name="src2"></param>
        /// <param name="dst"></param>
        public static void Absdiff(InputArray src1, InputArray src2, OutputArray dst)
        {
            if (src1 == null)
                throw new ArgumentNullException("src1");
            if (src2 == null)
                throw new ArgumentNullException("src2");
            if (dst == null)
                throw new ArgumentNullException("dst");
            src1.ThrowIfDisposed();
            src2.ThrowIfDisposed();
            dst.ThrowIfNotReady();
            NativeMethods.core_absdiff(src1.CvPtr, src2.CvPtr, dst.CvPtr);
            dst.Fix();
        }
        #endregion
        #region InRange
        /// <summary>
        /// set mask elements for those array elements which are within the element-specific bounding box (dst = lowerb &lt;= src &amp;&amp; src &lt; upperb)
        /// </summary>
        /// <param name="src">The first source array</param>
        /// <param name="lowerb">The inclusive lower boundary array of the same size and type as src</param>
        /// <param name="upperb">The exclusive upper boundary array of the same size and type as src</param>
        /// <param name="dst">The destination array, will have the same size as src and CV_8U type</param>
        public static void InRange(InputArray src, InputArray lowerb, InputArray upperb, OutputArray dst)
        {
            if (src == null)
                throw new ArgumentNullException("src");
            if (lowerb == null)
                throw new ArgumentNullException("lowerb");
            if (upperb == null)
                throw new ArgumentNullException("upperb");
            if (dst == null)
                throw new ArgumentNullException("dst");
            src.ThrowIfDisposed();
            lowerb.ThrowIfDisposed();
            upperb.ThrowIfDisposed();
            dst.ThrowIfNotReady();
            NativeMethods.core_inRange(src.CvPtr, lowerb.CvPtr, upperb.CvPtr, dst.CvPtr);
            dst.Fix();
        }

        /// <summary>
        /// set mask elements for those array elements which are within the element-specific bounding box (dst = lowerb &lt;= src &amp;&amp; src &lt; upperb)
        /// </summary>
        /// <param name="src">The first source array</param>
        /// <param name="lowerb">The inclusive lower boundary array of the same size and type as src</param>
        /// <param name="upperb">The exclusive upper boundary array of the same size and type as src</param>
        /// <param name="dst">The destination array, will have the same size as src and CV_8U type</param>
        public static void InRange(InputArray src, Scalar lowerb, Scalar upperb, OutputArray dst)
        {
            if (src == null)
                throw new ArgumentNullException("src");
            if (dst == null)
                throw new ArgumentNullException("dst");
            src.ThrowIfDisposed();
            dst.ThrowIfNotReady();
            NativeMethods.core_inRange(src.CvPtr, lowerb, upperb, dst.CvPtr);
            dst.Fix();
        }
        #endregion
        #region Compare
        /// <summary>
        /// compares elements of two arrays (dst = src1 [cmpop] src2)
        /// </summary>
        /// <param name="src1"></param>
        /// <param name="src2"></param>
        /// <param name="dst"></param>
        /// <param name="cmpop"></param>
        public static void Compare(InputArray src1, InputArray src2, OutputArray dst, ArrComparison cmpop)
        {
            if (src1 == null)
                throw new ArgumentNullException("src1");
            if (src2 == null)
                throw new ArgumentNullException("src2");
            if (dst == null)
                throw new ArgumentNullException("dst");
            src1.ThrowIfDisposed();
            src2.ThrowIfDisposed();
            dst.ThrowIfNotReady();
            NativeMethods.core_compare(src1.CvPtr, src2.CvPtr, dst.CvPtr, (int)cmpop);
            dst.Fix();
        }
        #endregion
        #region Min
        /// <summary>
        /// computes per-element minimum of two arrays (dst = min(src1, src2))
        /// </summary>
        /// <param name="src1"></param>
        /// <param name="src2"></param>
        /// <param name="dst"></param>
        public static void Min(InputArray src1, InputArray src2, OutputArray dst)
        {
            if (src1 == null)
                throw new ArgumentNullException("src1");
            if (src2 == null)
                throw new ArgumentNullException("src2");
            if (dst == null)
                throw new ArgumentNullException("dst");
            src1.ThrowIfDisposed();
            src2.ThrowIfDisposed();
            dst.ThrowIfNotReady();
            NativeMethods.core_min1(src1.CvPtr, src2.CvPtr, dst.CvPtr);
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
                throw new ArgumentNullException("src1");
            if (src2 == null)
                throw new ArgumentNullException("src2");
            if (dst == null)
                throw new ArgumentNullException("dst");
            src1.ThrowIfDisposed();
            src2.ThrowIfDisposed();
            dst.ThrowIfDisposed();
            NativeMethods.core_min_MatMat(src1.CvPtr, src2.CvPtr, dst.CvPtr);
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
                throw new ArgumentNullException("src1");
            if (dst == null)
                throw new ArgumentNullException("dst");
            src1.ThrowIfDisposed();
            dst.ThrowIfDisposed();
            NativeMethods.core_min_MatDouble(src1.CvPtr, src2, dst.CvPtr);
        }
        #endregion
        #region Max
        /// <summary>
        /// computes per-element maximum of two arrays (dst = max(src1, src2))
        /// </summary>
        /// <param name="src1"></param>
        /// <param name="src2"></param>
        /// <param name="dst"></param>
        public static void Max(InputArray src1, InputArray src2, OutputArray dst)
        {
            if (src1 == null)
                throw new ArgumentNullException("src1");
            if (src2 == null)
                throw new ArgumentNullException("src2");
            if (dst == null)
                throw new ArgumentNullException("dst");
            src1.ThrowIfDisposed();
            src2.ThrowIfDisposed();
            dst.ThrowIfNotReady();
            NativeMethods.core_max1(src1.CvPtr, src2.CvPtr, dst.CvPtr);
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
                throw new ArgumentNullException("src1");
            if (src2 == null)
                throw new ArgumentNullException("src2");
            if (dst == null)
                throw new ArgumentNullException("dst");
            src1.ThrowIfDisposed();
            src2.ThrowIfDisposed();
            dst.ThrowIfDisposed();
            NativeMethods.core_max_MatMat(src1.CvPtr, src2.CvPtr, dst.CvPtr);
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
                throw new ArgumentNullException("src1");
            if (dst == null)
                throw new ArgumentNullException("dst");
            src1.ThrowIfDisposed();
            dst.ThrowIfDisposed();
            NativeMethods.core_max_MatDouble(src1.CvPtr, src2, dst.CvPtr);
        }
        #endregion
        #region Sqrt
        /// <summary>
        /// computes square root of each matrix element (dst = src**0.5)
        /// </summary>
        /// <param name="src">The source floating-point array</param>
        /// <param name="dst">The destination array; will have the same size and the same type as src</param>
        public static void Sqrt(InputArray src, OutputArray dst)
        {
            if (src == null)
                throw new ArgumentNullException("src");
            if (dst == null)
                throw new ArgumentNullException("dst");
            src.ThrowIfDisposed();
            dst.ThrowIfNotReady();
            NativeMethods.core_sqrt(src.CvPtr, dst.CvPtr);
            dst.Fix();
        }
        #endregion
        #region Pow
        /// <summary>
        /// raises the input matrix elements to the specified power (b = a**power)
        /// </summary>
        /// <param name="src">The source array</param>
        /// <param name="power">The exponent of power</param>
        /// <param name="dst">The destination array; will have the same size and the same type as src</param>
        public static void Pow(InputArray src, double power, OutputArray dst)
        {
            if (src == null)
                throw new ArgumentNullException("src");
            if (dst == null)
                throw new ArgumentNullException("dst");
            src.ThrowIfDisposed();
            dst.ThrowIfNotReady();
            NativeMethods.core_pow_Mat(src.CvPtr, power, dst.CvPtr);
            dst.Fix();
        }
        #endregion
        #region Exp
        /// <summary>
        /// computes exponent of each matrix element (dst = e**src)
        /// </summary>
        /// <param name="src">The source array</param>
        /// <param name="dst">The destination array; will have the same size and same type as src</param>
        public static void Exp(InputArray src, OutputArray dst)
        {
            if (src == null)
                throw new ArgumentNullException("src");
            if (dst == null)
                throw new ArgumentNullException("dst");
            src.ThrowIfDisposed();
            dst.ThrowIfNotReady();
            NativeMethods.core_exp_Mat(src.CvPtr, dst.CvPtr);
            dst.Fix();
        }
        #endregion
        #region Log
        /// <summary>
        /// computes natural logarithm of absolute value of each matrix element: dst = log(abs(src))
        /// </summary>
        /// <param name="src">The source array</param>
        /// <param name="dst">The destination array; will have the same size and same type as src</param>
        public static void Log(InputArray src, OutputArray dst)
        {
            if (src == null)
                throw new ArgumentNullException("src");
            if (dst == null)
                throw new ArgumentNullException("dst");
            src.ThrowIfDisposed();
            dst.ThrowIfNotReady();
            NativeMethods.core_log_Mat(src.CvPtr, dst.CvPtr);
            dst.Fix();
        }

        #endregion
        #region CubeRoot
        /// <summary>
        /// computes cube root of the argument
        /// </summary>
        /// <param name="val"></param>
        /// <returns></returns>
        public static float CubeRoot(float val)
        {
            return NativeMethods.core_cubeRoot(val);
        }
        #endregion
        #region FastAtan2
        /// <summary>
        /// computes the angle in degrees (0..360) of the vector (x,y)
        /// </summary>
        /// <param name="y"></param>
        /// <param name="x"></param>
        /// <returns></returns>
        public static float FastAtan2(float y, float x)
        {
            return NativeMethods.core_fastAtan2(y, x);
        }
        #endregion
        #region PolarToCart
        /// <summary>
        /// converts polar coordinates to Cartesian
        /// </summary>
        /// <param name="magnitude"></param>
        /// <param name="angle"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="angleInDegrees"></param>
        public static void PolarToCart(InputArray magnitude, InputArray angle,
            OutputArray x, OutputArray y, bool angleInDegrees = false)
        {
            if (magnitude == null)
                throw new ArgumentNullException("magnitude");
            if (angle == null)
                throw new ArgumentNullException("angle");
            if (x == null)
                throw new ArgumentNullException("x");
            if (y == null)
                throw new ArgumentNullException("y");
            magnitude.ThrowIfDisposed();
            angle.ThrowIfDisposed();
            x.ThrowIfNotReady();
            y.ThrowIfNotReady();
            NativeMethods.core_polarToCart(magnitude.CvPtr, angle.CvPtr, x.CvPtr, y.CvPtr, angleInDegrees ? 1 : 0);
            x.Fix();
            y.Fix();
        }
        #endregion
        #region CartToPolar
        /// <summary>
        /// converts Cartesian coordinates to polar
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="magnitude"></param>
        /// <param name="angle"></param>
        /// <param name="angleInDegrees"></param>
        public static void CartToPolar(InputArray x, InputArray y,
            OutputArray magnitude, OutputArray angle, bool angleInDegrees = false)
        {
            if (x == null)
                throw new ArgumentNullException("x");
            if (y == null)
                throw new ArgumentNullException("y");
            if (magnitude == null)
                throw new ArgumentNullException("magnitude");
            if (angle == null)
                throw new ArgumentNullException("angle");
            x.ThrowIfDisposed();
            y.ThrowIfDisposed();
            magnitude.ThrowIfNotReady();
            angle.ThrowIfNotReady();
            NativeMethods.core_cartToPolar(x.CvPtr, y.CvPtr, magnitude.CvPtr, angle.CvPtr, angleInDegrees ? 1 : 0);
            magnitude.Fix();
            angle.Fix();
        }
        #endregion
        #region Phase
        /// <summary>
        /// computes angle (angle(i)) of each (x(i), y(i)) vector
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="angle"></param>
        /// <param name="angleInDegrees"></param>
        public static void Phase(InputArray x, InputArray y, OutputArray angle, bool angleInDegrees = false)
        {
            if (x == null)
                throw new ArgumentNullException("x");
            if (y == null)
                throw new ArgumentNullException("y");
            if (angle == null)
                throw new ArgumentNullException("angle");
            x.ThrowIfDisposed();
            y.ThrowIfDisposed();
            angle.ThrowIfNotReady();
            NativeMethods.core_phase(x.CvPtr, y.CvPtr, angle.CvPtr, angleInDegrees ? 1 : 0);
            angle.Fix();
        }
        #endregion
        #region Magnitude
        /// <summary>
        /// computes magnitude (magnitude(i)) of each (x(i), y(i)) vector
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="magnitude"></param>
        public static void Magnitude(InputArray x, InputArray y, OutputArray magnitude)
        {
            if (x == null)
                throw new ArgumentNullException("x");
            if (y == null)
                throw new ArgumentNullException("y");
            if (magnitude == null)
                throw new ArgumentNullException("magnitude");
            x.ThrowIfDisposed();
            y.ThrowIfDisposed();
            magnitude.ThrowIfNotReady();
            NativeMethods.core_magnitude_Mat(x.CvPtr, y.CvPtr, magnitude.CvPtr);
            magnitude.Fix();
        }
        #endregion
        #region CheckRange
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
            Point pos;
            return CheckRange(src, quiet, out pos);
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
                throw new ArgumentNullException("a");
            src.ThrowIfDisposed();

            int ret = NativeMethods.core_checkRange(src.CvPtr, quiet ? 1 : 0, out pos, minVal, maxVal);
            GC.KeepAlive(src);
            return ret != 0;
        }
        #endregion
        #region PatchNaNs
        /// <summary>
        /// converts NaN's to the given number
        /// </summary>
        /// <param name="a"></param>
        /// <param name="val"></param>
        public static void PatchNaNs(InputOutputArray a, double val = 0)
        {
            if (a == null)
                throw new ArgumentNullException("a");
            a.ThrowIfNotReady();
            NativeMethods.core_patchNaNs(a.CvPtr, val);
        }
        #endregion
        #region Gemm
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
        public static void Gemm(InputArray src1, InputArray src2, double alpha,
            InputArray src3, double gamma, OutputArray dst, GemmOperation flags = GemmOperation.None)
        {
            if (src1 == null)
                throw new ArgumentNullException("src1");
            if (src2 == null)
                throw new ArgumentNullException("src2");
            if (src3 == null)
                throw new ArgumentNullException("src3");
            if (dst == null)
                throw new ArgumentNullException("dst");
            src1.ThrowIfDisposed();
            src2.ThrowIfDisposed();
            src3.ThrowIfDisposed();
            dst.ThrowIfNotReady();
            NativeMethods.core_gemm(src1.CvPtr, src2.CvPtr, alpha, src3.CvPtr, gamma, dst.CvPtr, (int)flags);
            dst.Fix();
        }
        #endregion
        #region MulTransposed
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
            InputArray delta = null, double scale = 1, int dtype = -1)
        {
            if (src == null)
                throw new ArgumentNullException("src");
            if (dst == null)
                throw new ArgumentNullException("dst");
            src.ThrowIfDisposed();
            dst.ThrowIfNotReady();
            NativeMethods.core_mulTransposed(src.CvPtr, dst.CvPtr, aTa ? 1 : 0 , ToPtr(delta), scale, dtype);
            dst.Fix();
        }
        #endregion
        #region Transpose
        /// <summary>
        /// transposes the matrix
        /// </summary>
        /// <param name="src">The source array</param>
        /// <param name="dst">The destination array of the same type as src</param>
        public static void Transpose(InputArray src, OutputArray dst)
        {
            if (src == null)
                throw new ArgumentNullException("src");
            if (dst == null)
                throw new ArgumentNullException("dst");
            src.ThrowIfDisposed();
            dst.ThrowIfNotReady();
            NativeMethods.core_transpose(src.CvPtr, dst.CvPtr);
            dst.Fix();
        }
        #endregion
        #region Transform
        /// <summary>
        /// performs affine transformation of each element of multi-channel input matrix
        /// </summary>
        /// <param name="src">The source array; must have as many channels (1 to 4) as mtx.cols or mtx.cols-1</param>
        /// <param name="dst">The destination array; will have the same size and depth as src and as many channels as mtx.rows</param>
        /// <param name="m">The transformation matrix</param>
        public static void Transform(InputArray src, OutputArray dst, InputArray m)
        {
            if (src == null)
                throw new ArgumentNullException("src");
            if (dst == null)
                throw new ArgumentNullException("dst");
            if (m == null)
                throw new ArgumentNullException("m");
            src.ThrowIfDisposed();
            dst.ThrowIfNotReady();
            m.ThrowIfDisposed();
            NativeMethods.core_transform(src.CvPtr, dst.CvPtr, m.CvPtr);
            dst.Fix();
        }
        #endregion
        #region PerspectiveTransform
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
                throw new ArgumentNullException("src");
            if (dst == null)
                throw new ArgumentNullException("dst");
            if (m == null)
                throw new ArgumentNullException("m");
            src.ThrowIfDisposed();
            dst.ThrowIfNotReady();
            m.ThrowIfDisposed();
            NativeMethods.core_perspectiveTransform(src.CvPtr, dst.CvPtr, m.CvPtr);
            dst.Fix();
        }
        #endregion
        #region CompleteSymm
        /// <summary>
        /// extends the symmetrical matrix from the lower half or from the upper half
        /// </summary>
        /// <param name="mtx"> Input-output floating-point square matrix</param>
        /// <param name="lowerToUpper">If true, the lower half is copied to the upper half, 
        /// otherwise the upper half is copied to the lower half</param>
        public static void CompleteSymm(InputOutputArray mtx, bool lowerToUpper = false)
        {
            if (mtx == null)
                throw new ArgumentNullException("mtx");
            mtx.ThrowIfNotReady();
            NativeMethods.core_completeSymm(mtx.CvPtr, lowerToUpper ? 1 : 0);
        }
        #endregion
        #region SetIdentity
        /// <summary>
        /// initializes scaled identity matrix
        /// </summary>
        /// <param name="mtx">The matrix to initialize (not necessarily square)</param>
        /// <param name="s">The value to assign to the diagonal elements</param>
        public static void SetIdentity(InputOutputArray mtx, Scalar? s = null)
        {
            if (mtx == null)
                throw new ArgumentNullException("mtx");
            mtx.ThrowIfNotReady();
            Scalar s0 = s.GetValueOrDefault(new Scalar(1));
            NativeMethods.core_setIdentity(mtx.CvPtr, s0);
        }
        #endregion
        #region Determinant
        /// <summary>
        /// computes determinant of a square matrix
        /// </summary>
        /// <param name="mtx">The input matrix; must have CV_32FC1 or CV_64FC1 type and square size</param>
        /// <returns>determinant of the specified matrix.</returns>
        public static double Determinant(InputArray mtx)
        {
            if (mtx == null)
                throw new ArgumentNullException("mtx");
            mtx.ThrowIfDisposed();
            return NativeMethods.core_determinant(mtx.CvPtr);
        }
        #endregion
        #region Trace
        /// <summary>
        /// computes trace of a matrix
        /// </summary>
        /// <param name="mtx">The source matrix</param>
        /// <returns></returns>
        public static Scalar Trace(InputArray mtx)
        {
            if (mtx == null)
                throw new ArgumentNullException("mtx");
            mtx.ThrowIfDisposed();
            return NativeMethods.core_trace(mtx.CvPtr);
        }
        #endregion
        #region Invert
        /// <summary>
        /// computes inverse or pseudo-inverse matrix
        /// </summary>
        /// <param name="src">The source floating-point MxN matrix</param>
        /// <param name="dst">The destination matrix; will have NxM size and the same type as src</param>
        /// <param name="flags">The inversion method</param>
        /// <returns></returns>
        public static double Invert(InputArray src, OutputArray dst, 
            MatrixDecomposition flags = MatrixDecomposition.LU)
        {
            if (src == null)
                throw new ArgumentNullException("src");
            if (dst == null)
                throw new ArgumentNullException("dst");
            src.ThrowIfDisposed();
            dst.ThrowIfNotReady();
            double ret = NativeMethods.core_invert(src.CvPtr, dst.CvPtr, (int)flags);
            dst.Fix();
            return ret;
        }
        #endregion
        #region Solve
        /// <summary>
        /// solves linear system or a least-square problem
        /// </summary>
        /// <param name="src1"></param>
        /// <param name="src2"></param>
        /// <param name="dst"></param>
        /// <param name="flags"></param>
        /// <returns></returns>
        public static bool Solve(InputArray src1, InputArray src2, OutputArray dst, 
            MatrixDecomposition flags = MatrixDecomposition.LU)
        {
            if (src1 == null)
                throw new ArgumentNullException("src1");
            if (src2 == null)
                throw new ArgumentNullException("src2");
            if (dst == null)
                throw new ArgumentNullException("dst");
            src1.ThrowIfDisposed();
            src2.ThrowIfDisposed();
            dst.ThrowIfNotReady();
            int ret = NativeMethods.core_solve(src1.CvPtr, src2.CvPtr, dst.CvPtr, (int)flags);
            dst.Fix();
            return ret != 0;
        }
        #endregion
        #region Sort
        /// <summary>
        /// sorts independently each matrix row or each matrix column
        /// </summary>
        /// <param name="src">The source single-channel array</param>
        /// <param name="dst">The destination array of the same size and the same type as src</param>
        /// <param name="flags">The operation flags, a combination of the SortFlag values</param>
        public static void Sort(InputArray src, OutputArray dst, SortFlag flags)
        {
            if (src == null)
                throw new ArgumentNullException("src");
            if (dst == null)
                throw new ArgumentNullException("dst");
            src.ThrowIfDisposed();
            dst.ThrowIfNotReady();
            NativeMethods.core_sort(src.CvPtr, dst.CvPtr, (int)flags);
            dst.Fix();
        }
        #endregion
        #region SortIdx
        /// <summary>
        /// sorts independently each matrix row or each matrix column
        /// </summary>
        /// <param name="src">The source single-channel array</param>
        /// <param name="dst">The destination integer array of the same size as src</param>
        /// <param name="flags">The operation flags, a combination of SortFlag values</param>
        public static void SortIdx(InputArray src, OutputArray dst, SortFlag flags)
        {
            if (src == null)
                throw new ArgumentNullException("src");
            if (dst == null)
                throw new ArgumentNullException("dst");
            src.ThrowIfDisposed();
            dst.ThrowIfNotReady();
            NativeMethods.core_sortIdx(src.CvPtr, dst.CvPtr, (int)flags);
            dst.Fix();
        }
        #endregion
        #region SolveCubic
        /// <summary>
        /// finds real roots of a cubic polynomial
        /// </summary>
        /// <param name="coeffs">The equation coefficients, an array of 3 or 4 elements</param>
        /// <param name="roots">The destination array of real roots which will have 1 or 3 elements</param>
        /// <returns></returns>
        public static int SolveCubic(InputArray coeffs, OutputArray roots)
        {
            if (coeffs == null)
                throw new ArgumentNullException("coeffs");
            if (roots == null)
                throw new ArgumentNullException("roots");
            coeffs.ThrowIfDisposed();
            roots.ThrowIfNotReady();
            int ret = NativeMethods.core_solveCubic(coeffs.CvPtr, roots.CvPtr);
            roots.Fix();
            return ret;
        }
        #endregion
        #region SolvePoly
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
                throw new ArgumentNullException("coeffs");
            if (roots == null)
                throw new ArgumentNullException("roots");
            coeffs.ThrowIfDisposed();
            roots.ThrowIfNotReady();
            double ret = NativeMethods.core_solvePoly(coeffs.CvPtr, roots.CvPtr, maxIters);
            roots.Fix();
            return ret;
        }
        #endregion
        #region Eigen

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
                throw new ArgumentNullException("src");
            if (eigenvalues == null)
                throw new ArgumentNullException("eigenvalues");
            if (eigenvectors == null)
                throw new ArgumentNullException("eigenvectors");
            src.ThrowIfDisposed();
            eigenvalues.ThrowIfNotReady();
            eigenvectors.ThrowIfNotReady();
            int ret = NativeMethods.core_eigen(src.CvPtr, eigenvalues.CvPtr, eigenvectors.CvPtr);
            eigenvalues.Fix();
            eigenvectors.Fix();
            GC.KeepAlive(src);
            return ret != 0;
        }
        #endregion
        #region CalcCovarMatrix
        /// <summary>
        /// computes covariation matrix of a set of samples
        /// </summary>
        /// <param name="samples"></param>
        /// <param name="covar"></param>
        /// <param name="mean"></param>
        /// <param name="flags"></param>
        public static void CalcCovarMatrix(Mat[] samples, Mat covar, Mat mean, CovarMatrixFlag flags)
        {
            CalcCovarMatrix(samples, covar, mean, flags, MatType.CV_64F);
        }
        /// <summary>
        /// computes covariation matrix of a set of samples
        /// </summary>
        /// <param name="samples"></param>
        /// <param name="covar"></param>
        /// <param name="mean"></param>
        /// <param name="flags"></param>
        /// <param name="ctype"></param>
        public static void CalcCovarMatrix(Mat[] samples, Mat covar, Mat mean,
            CovarMatrixFlag flags, MatType ctype)
        {
            if (samples == null)
                throw new ArgumentNullException("samples");
            if (covar == null)
                throw new ArgumentNullException("covar");
            if (mean == null)
                throw new ArgumentNullException("mean");
            covar.ThrowIfDisposed();
            mean.ThrowIfDisposed();
            IntPtr[] samplesPtr = EnumerableEx.SelectPtrs(samples);
            NativeMethods.core_calcCovarMatrix_Mat(samplesPtr, samples.Length, covar.CvPtr, mean.CvPtr, (int)flags, ctype);
        }
        /// <summary>
        /// computes covariation matrix of a set of samples
        /// </summary>
        /// <param name="samples"></param>
        /// <param name="covar"></param>
        /// <param name="mean"></param>
        /// <param name="flags"></param>
        public static void CalcCovarMatrix(InputArray samples, OutputArray covar,
            InputOutputArray mean, CovarMatrixFlag flags)
        {
            CalcCovarMatrix(samples, covar, mean, flags, MatType.CV_64F);
        }
        /// <summary>
        /// computes covariation matrix of a set of samples
        /// </summary>
        /// <param name="samples"></param>
        /// <param name="covar"></param>
        /// <param name="mean"></param>
        /// <param name="flags"></param>
        /// <param name="ctype"></param>
        public static void CalcCovarMatrix(InputArray samples, OutputArray covar,
            InputOutputArray mean, CovarMatrixFlag flags, MatType ctype)
        {
            if (samples == null)
                throw new ArgumentNullException("samples");
            if (covar == null)
                throw new ArgumentNullException("covar");
            if (mean == null)
                throw new ArgumentNullException("mean");
            samples.ThrowIfDisposed();
            covar.ThrowIfNotReady();
            mean.ThrowIfNotReady();
            NativeMethods.core_calcCovarMatrix_InputArray(samples.CvPtr, covar.CvPtr, mean.CvPtr, (int)flags, ctype);
            covar.Fix();
            mean.Fix();
        }
        #endregion

        #region PCA
        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        /// <param name="mean"></param>
        /// <param name="eigenvectors"></param>
        /// <param name="maxComponents"></param>
        public static void PCACompute(InputArray data, InputOutputArray mean,
            OutputArray eigenvectors, int maxComponents = 0)
        {
            if (data == null)
                throw new ArgumentNullException("data");
            if (mean == null)
                throw new ArgumentNullException("mean");
            if (eigenvectors == null)
                throw new ArgumentNullException("eigenvectors");
            data.ThrowIfDisposed();
            mean.ThrowIfNotReady();
            eigenvectors.ThrowIfNotReady();
            NativeMethods.core_PCACompute(data.CvPtr, mean.CvPtr, eigenvectors.CvPtr, maxComponents);
            mean.Fix();
            eigenvectors.Fix();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        /// <param name="mean"></param>
        /// <param name="eigenvectors"></param>
        /// <param name="retainedVariance"></param>
        public static void PCAComputeVar(InputArray data, InputOutputArray mean,
            OutputArray eigenvectors, double retainedVariance)
        {
            if (data == null)
                throw new ArgumentNullException("data");
            if (mean == null)
                throw new ArgumentNullException("mean");
            if (eigenvectors == null)
                throw new ArgumentNullException("eigenvectors");
            data.ThrowIfDisposed();
            mean.ThrowIfNotReady();
            eigenvectors.ThrowIfNotReady();
            NativeMethods.core_PCAComputeVar(data.CvPtr, mean.CvPtr, eigenvectors.CvPtr, retainedVariance);
            mean.Fix();
            eigenvectors.Fix();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        /// <param name="mean"></param>
        /// <param name="eigenvectors"></param>
        /// <param name="result"></param>
        public static void PCAProject(InputArray data, InputArray mean,
            InputArray eigenvectors, OutputArray result)
        {
            if (data == null)
                throw new ArgumentNullException("data");
            if (mean == null)
                throw new ArgumentNullException("mean");
            if (eigenvectors == null)
                throw new ArgumentNullException("eigenvectors");
            if (result == null)
                throw new ArgumentNullException("result");
            data.ThrowIfDisposed();
            mean.ThrowIfDisposed();
            eigenvectors.ThrowIfDisposed();
            result.ThrowIfNotReady();
            NativeMethods.core_PCAProject(data.CvPtr, mean.CvPtr, eigenvectors.CvPtr, result.CvPtr);
            result.Fix();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        /// <param name="mean"></param>
        /// <param name="eigenvectors"></param>
        /// <param name="result"></param>
        public static void PCABackProject(InputArray data, InputArray mean,
            InputArray eigenvectors, OutputArray result)
        {
            if (data == null)
                throw new ArgumentNullException("data");
            if (mean == null)
                throw new ArgumentNullException("mean");
            if (eigenvectors == null)
                throw new ArgumentNullException("eigenvectors");
            if (result == null)
                throw new ArgumentNullException("result");
            data.ThrowIfDisposed();
            mean.ThrowIfDisposed();
            eigenvectors.ThrowIfDisposed();
            result.ThrowIfNotReady();
            NativeMethods.core_PCABackProject(data.CvPtr, mean.CvPtr, eigenvectors.CvPtr, result.CvPtr);
            result.Fix();
        }
        #endregion
        #region SVD
        /// <summary>
        /// computes SVD of src
        /// </summary>
        /// <param name="src"></param>
        /// <param name="w"></param>
        /// <param name="u"></param>
        /// <param name="vt"></param>
        /// <param name="flags"></param>
        public static void SVDecomp(InputArray src, OutputArray w,
            OutputArray u, OutputArray vt, SVDFlag flags = SVDFlag.None)
        {
            if (src == null)
                throw new ArgumentNullException("src");
            if (w == null)
                throw new ArgumentNullException("w");
            if (u == null)
                throw new ArgumentNullException("u");
            if (vt == null)
                throw new ArgumentNullException("vt");
            src.ThrowIfDisposed();
            w.ThrowIfNotReady();
            u.ThrowIfNotReady();
            vt.ThrowIfNotReady();
            NativeMethods.core_SVDecomp(src.CvPtr, w.CvPtr, u.CvPtr, vt.CvPtr, (int)flags);
            w.Fix();
            u.Fix();
            vt.Fix();
        }

        /// <summary>
        /// performs back substitution for the previously computed SVD
        /// </summary>
        /// <param name="w"></param>
        /// <param name="u"></param>
        /// <param name="vt"></param>
        /// <param name="rhs"></param>
        /// <param name="dst"></param>
        public static void SVBackSubst(InputArray w, InputArray u, InputArray vt,
            InputArray rhs, OutputArray dst)
        {
            if (w == null)
                throw new ArgumentNullException("w");
            if (u == null)
                throw new ArgumentNullException("u");
            if (vt == null)
                throw new ArgumentNullException("vt");
            if (rhs == null)
                throw new ArgumentNullException("rhs");
            if (dst == null)
                throw new ArgumentNullException("dst");
            w.ThrowIfDisposed();
            u.ThrowIfDisposed();
            vt.ThrowIfDisposed();
            rhs.ThrowIfDisposed();
            dst.ThrowIfNotReady();
            NativeMethods.core_SVBackSubst(w.CvPtr, u.CvPtr, vt.CvPtr, rhs.CvPtr, dst.CvPtr);
            dst.Fix();
        }
        #endregion

        #region Mahalanobis/Mahalonobis
        /// <summary>
        /// 
        /// </summary>
        /// <param name="v1"></param>
        /// <param name="v2"></param>
        /// <param name="icovar"></param>
        /// <returns></returns>
        public static double Mahalanobis(InputArray v1, InputArray v2, InputArray icovar)
        {
            if (v1 == null)
                throw new ArgumentNullException("v1");
            if (v2 == null)
                throw new ArgumentNullException("v2");
            if (icovar == null)
                throw new ArgumentNullException("icovar");
            v1.ThrowIfDisposed();
            v2.ThrowIfDisposed();
            icovar.ThrowIfDisposed();
            return NativeMethods.core_Mahalanobis(v1.CvPtr, v2.CvPtr, icovar.CvPtr);
        }
        /// <summary>
        /// computes Mahalanobis distance between two vectors: sqrt((v1-v2)'*icovar*(v1-v2)), where icovar is the inverse covariation matrix
        /// </summary>
        /// <param name="v1"></param>
        /// <param name="v2"></param>
        /// <param name="icovar"></param>
        /// <returns></returns>
        public static double Mahalonobis(InputArray v1, InputArray v2, InputArray icovar)
        {
            return Mahalanobis(v1, v2, icovar);
        }
        #endregion
        #region Dft/Idft
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
        public static void Dft(InputArray src, OutputArray dst, DftFlag2 flags = DftFlag2.None, int nonzeroRows = 0)
        {
            if (src == null)
                throw new ArgumentNullException("src");
            if (dst == null)
                throw new ArgumentNullException("dst");
            src.ThrowIfDisposed();
            dst.ThrowIfNotReady();
            NativeMethods.core_dft(src.CvPtr, dst.CvPtr, (int)flags, nonzeroRows);
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
        public static void Idft(InputArray src, OutputArray dst, DftFlag2 flags = DftFlag2.None, int nonzeroRows = 0)
        {
            if (src == null)
                throw new ArgumentNullException("src");
            if (dst == null)
                throw new ArgumentNullException("dst");
            src.ThrowIfDisposed();
            dst.ThrowIfNotReady();
            NativeMethods.core_idft(src.CvPtr, dst.CvPtr, (int)flags, nonzeroRows);
            dst.Fix();
        }
        #endregion
        #region Dct/Idct
        /// <summary>
        /// Performs forward or inverse 1D or 2D Discrete Cosine Transformation
        /// </summary>
        /// <param name="src">The source floating-point array</param>
        /// <param name="dst">The destination array; will have the same size and same type as src</param>
        /// <param name="flags">Transformation flags, a combination of DctFlag2 values</param>
        public static void Dct(InputArray src, OutputArray dst, DctFlag2 flags = DctFlag2.None)
        {
            if (src == null)
                throw new ArgumentNullException("src");
            if (dst == null)
                throw new ArgumentNullException("dst");
            src.ThrowIfDisposed();
            dst.ThrowIfNotReady();
            NativeMethods.core_dct(src.CvPtr, dst.CvPtr, (int)flags);
            dst.Fix();
        }

        /// <summary>
        /// Performs inverse 1D or 2D Discrete Cosine Transformation
        /// </summary>
        /// <param name="src">The source floating-point array</param>
        /// <param name="dst">The destination array; will have the same size and same type as src</param>
        /// <param name="flags">Transformation flags, a combination of DctFlag2 values</param>
        public static void Idct(InputArray src, OutputArray dst, DctFlag2 flags = DctFlag2.None)
        {
            if (src == null)
                throw new ArgumentNullException("src");
            if (dst == null)
                throw new ArgumentNullException("dst");
            src.ThrowIfDisposed();
            dst.ThrowIfNotReady();
            NativeMethods.core_idct(src.CvPtr, dst.CvPtr, (int)flags);
            dst.Fix();
        }
        #endregion
        #region MulSpectrums
        /// <summary>
        /// computes element-wise product of the two Fourier spectrums. The second spectrum can optionally be conjugated before the multiplication
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="c"></param>
        /// <param name="flags"></param>
        /// <param name="conjB"></param>
        public static void MulSpectrums(InputArray a, InputArray b, OutputArray c,
            MulSpectrumsFlag flags, bool conjB = false)
        {
            if (a == null)
                throw new ArgumentNullException("a");
            if (b == null)
                throw new ArgumentNullException("b");
            if (c == null)
                throw new ArgumentNullException("c");
            a.ThrowIfDisposed();
            b.ThrowIfDisposed();
            c.ThrowIfNotReady();
            NativeMethods.core_mulSpectrums(a.CvPtr, b.CvPtr, c.CvPtr, (int)flags, conjB ? 1 : 0);
            c.Fix();
        }
        #endregion
        #region GetOptimalDFTSize
        /// <summary>
        /// computes the minimal vector size vecsize1 >= vecsize so that the dft() of the vector of length vecsize1 can be computed efficiently
        /// </summary>
        /// <param name="vecsize"></param>
        /// <returns></returns>
        public static int GetOptimalDFTSize(int vecsize)
        {
            return NativeMethods.core_getOptimalDFTSize(vecsize);
        }
        #endregion
        #region Kmeans
        /// <summary>
        /// clusters the input data using k-Means algorithm
        /// </summary>
        /// <param name="data"></param>
        /// <param name="k"></param>
        /// <param name="bestLabels"></param>
        /// <param name="criteria"></param>
        /// <param name="attempts"></param>
        /// <param name="flags"></param>
        /// <param name="centers"></param>
        /// <returns></returns>
        public static double Kmeans(InputArray data, int k, InputOutputArray bestLabels,
            TermCriteria criteria, int attempts, KMeansFlag flags, OutputArray centers = null)
        {
            if (data == null)
                throw new ArgumentNullException("data");
            if (bestLabels == null)
                throw new ArgumentNullException("bestLabels");
            data.ThrowIfDisposed();
            bestLabels.ThrowIfDisposed();
            double ret = NativeMethods.core_kmeans(data.CvPtr, k, bestLabels.CvPtr, criteria, attempts, (int)flags, ToPtr(centers));
            bestLabels.Fix();
            if(centers != null)
                centers.Fix();
            return ret;
        }
        #endregion
        #region TheRNG
        /// <summary>
        /// returns the thread-local Random number generator
        /// </summary>
        /// <returns></returns>
        public static RNG TheRNG()
        {
            ulong state = NativeMethods.core_theRNG();
            return new RNG(state);
        }
        #endregion
        #region Randu
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
                throw new ArgumentNullException("dst");
            if (low == null)
                throw new ArgumentNullException("low");
            if (high == null)
                throw new ArgumentNullException("high");
            dst.ThrowIfNotReady();
            low.ThrowIfDisposed();
            high.ThrowIfDisposed();
            NativeMethods.core_randu_InputArray(dst.CvPtr, low.CvPtr, high.CvPtr);
            dst.Fix();
        }

        /// <summary>
        /// fills array with uniformly-distributed random numbers from the range [low, high)
        /// </summary>
        /// <param name="dst">The output array of random numbers. 
        /// The array must be pre-allocated and have 1 to 4 channels</param>
        /// <param name="low">The inclusive lower boundary of the generated random numbers</param>
        /// <param name="high">The exclusive upper boundary of the generated random numbers</param>
        public static void Randu(InputOutputArray dst, Scalar low, Scalar high)
        {
            if (dst == null)
                throw new ArgumentNullException("dst");
            dst.ThrowIfNotReady();
            NativeMethods.core_randu_Scalar(dst.CvPtr, low, high);
            dst.Fix();
        }
        #endregion
        #region Randn
        /// <summary>
        /// fills array with normally-distributed random numbers with the specified mean and the standard deviation
        /// </summary>
        /// <param name="dst">The output array of random numbers. 
        /// The array must be pre-allocated and have 1 to 4 channels</param>
        /// <param name="mean">The mean value (expectation) of the generated random numbers</param>
        /// <param name="stddev">The standard deviation of the generated random numbers</param>
        public static void Randn(InputOutputArray dst, InputArray mean, InputArray stddev)
        {
            if (dst == null)
                throw new ArgumentNullException("dst");
            if (mean == null)
                throw new ArgumentNullException("mean");
            if (stddev == null)
                throw new ArgumentNullException("stddev");
            dst.ThrowIfNotReady();
            mean.ThrowIfDisposed();
            stddev.ThrowIfDisposed();
            NativeMethods.core_randn_InputArray(dst.CvPtr, mean.CvPtr, stddev.CvPtr);
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
                throw new ArgumentNullException("dst");
            dst.ThrowIfNotReady();
            NativeMethods.core_randn_Scalar(dst.CvPtr, mean, stddev);
            dst.Fix();
        }
        #endregion
        #region RandShuffle
        /// <summary>
        /// shuffles the input array elements
        /// </summary>
        /// <param name="dst">The input/output numerical 1D array</param>
        /// <param name="iterFactor">The scale factor that determines the number of random swap operations.</param>
        /// <param name="rng">The optional random number generator used for shuffling. 
        /// If it is null, theRng() is used instead.</param>
        public static void RandShuffle(InputOutputArray dst, double iterFactor, RNG rng = null)
        {
            if (dst == null)
                throw new ArgumentNullException("dst");
            dst.ThrowIfNotReady();

            if (rng == null)
            {
                NativeMethods.core_randShuffle(dst.CvPtr, iterFactor, IntPtr.Zero);
            }
            else
            {
                ulong state = rng.State;
                NativeMethods.core_randShuffle(dst.CvPtr, iterFactor, ref state);
                rng.State = state;
            }
            dst.Fix();
        }
        #endregion

        #region Drawing
        #region Line
#if LANG_JP
        /// <summary>
        /// 2点を結ぶ線分を画像上に描画する．
        /// </summary>
        /// <param name="img">画像</param>
        /// <param name="pt1X">線分の1番目の端点x</param>
        /// <param name="pt1Y">線分の1番目の端点y</param>
        /// <param name="pt2X">線分の2番目の端点x</param>
        /// <param name="pt2Y">線分の2番目の端点y</param>
        /// <param name="color">線分の色</param>
        /// <param name="thickness">線分の太さ. [既定値は1]</param>
        /// <param name="lineType">線分の種類. [既定値はLineType.Link8]</param>
        /// <param name="shift">座標の小数点以下の桁を表すビット数. [既定値は0]</param>
#else
        /// <summary>
        /// Draws a line segment connecting two points
        /// </summary>
        /// <param name="img">The image. </param>
        /// <param name="pt1X">First point's x-coordinate of the line segment. </param>
        /// <param name="pt1Y">First point's y-coordinate of the line segment. </param>
        /// <param name="pt2X">Second point's x-coordinate of the line segment. </param>
        /// <param name="pt2Y">Second point's y-coordinate of the line segment. </param>
        /// <param name="color">Line color. </param>
        /// <param name="thickness">Line thickness. [By default this is 1]</param>
        /// <param name="lineType">Type of the line. [By default this is LineType.Link8]</param>
        /// <param name="shift">Number of fractional bits in the point coordinates. [By default this is 0]</param>
#endif
        public static void Line(InputOutputArray img, int pt1X, int pt1Y, int pt2X, int pt2Y, Scalar color, 
            int thickness = 1, LineType lineType = LineType.Link8, int shift = 0)
        {
            Line(img, new Point(pt1X, pt1Y), new Point(pt2X, pt2Y), color, thickness, lineType, shift);
        }

#if LANG_JP
        /// <summary>
        /// 2点を結ぶ線分を画像上に描画する．
        /// </summary>
        /// <param name="img">画像</param>
        /// <param name="pt1">線分の1番目の端点</param>
        /// <param name="pt2">線分の2番目の端点</param>
        /// <param name="color">線分の色</param>
        /// <param name="thickness">線分の太さ. [既定値は1]</param>
        /// <param name="lineType">線分の種類. [既定値はLineType.Link8]</param>
        /// <param name="shift">座標の小数点以下の桁を表すビット数. [既定値は0]</param>
#else
        /// <summary>
        /// Draws a line segment connecting two points
        /// </summary>
        /// <param name="img">The image. </param>
        /// <param name="pt1">First point of the line segment. </param>
        /// <param name="pt2">Second point of the line segment. </param>
        /// <param name="color">Line color. </param>
        /// <param name="thickness">Line thickness. [By default this is 1]</param>
        /// <param name="lineType">Type of the line. [By default this is LineType.Link8]</param>
        /// <param name="shift">Number of fractional bits in the point coordinates. [By default this is 0]</param>
#endif
        public static void Line(InputOutputArray img, Point pt1, Point pt2, Scalar color, int thickness = 1, LineType lineType = LineType.Link8, int shift = 0)
        {
            if (img == null)
                throw new ArgumentNullException("img");
            img.ThrowIfNotReady();
            NativeMethods.core_line(img.CvPtr, pt1, pt2, color, thickness, (int)lineType, shift);
            img.Fix();
        }
        #endregion
        #region Rectangle
#if LANG_JP
        /// <summary>
        /// 枠のみ，もしくは塗りつぶされた矩形を描画する
        /// </summary>
        /// <param name="img">画像</param>
        /// <param name="pt1">矩形の一つの頂点</param>
        /// <param name="pt2">矩形の反対側の頂点</param>
        /// <param name="color">線の色(RGB)，もしくは輝度(グレースケール画像).</param>
        /// <param name="thickness">矩形を描く線の太さ．負の値を指定した場合は塗りつぶされる. [既定値は1]</param>
        /// <param name="lineType">線の種類. [既定値はLineType.Link8]</param>
        /// <param name="shift">座標の小数点以下の桁を表すビット数. [既定値は0]</param>
#else
        /// <summary>
        /// Draws simple, thick or filled rectangle
        /// </summary>
        /// <param name="img">Image. </param>
        /// <param name="pt1">One of the rectangle vertices. </param>
        /// <param name="pt2">Opposite rectangle vertex. </param>
        /// <param name="color">Line color (RGB) or brightness (grayscale image). </param>
        /// <param name="thickness">Thickness of lines that make up the rectangle. Negative values make the function to draw a filled rectangle. [By default this is 1]</param>
        /// <param name="lineType">Type of the line, see cvLine description. [By default this is LineType.Link8]</param>
        /// <param name="shift">Number of fractional bits in the point coordinates. [By default this is 0]</param>
#endif
        public static void Rectangle(InputOutputArray img, Point pt1, Point pt2, Scalar color, int thickness = 1, LineType lineType = LineType.Link8, int shift = 0)
        {
            if (img == null)
                throw new ArgumentNullException("img");
            NativeMethods.core_rectangle1(img.CvPtr, pt1, pt2, color, thickness, (int)lineType, shift);
            img.Fix();
        }

#if LANG_JP
        /// <summary>
        /// 枠のみ，もしくは塗りつぶされた矩形を描画する
        /// </summary>
        /// <param name="img">画像</param>
        /// <param name="rect">矩形</param>
        /// <param name="color">線の色(RGB)，もしくは輝度(グレースケール画像).</param>
        /// <param name="thickness">矩形を描く線の太さ．負の値を指定した場合は塗りつぶされる. [既定値は1]</param>
        /// <param name="lineType">線の種類. [既定値はLineType.Link8]</param>
        /// <param name="shift">座標の小数点以下の桁を表すビット数. [既定値は0]</param>
#else
        /// <summary>
        /// Draws simple, thick or filled rectangle
        /// </summary>
        /// <param name="img">Image. </param>
        /// <param name="rect">Rectangle.</param>
        /// <param name="color">Line color (RGB) or brightness (grayscale image). </param>
        /// <param name="thickness">Thickness of lines that make up the rectangle. Negative values make the function to draw a filled rectangle. [By default this is 1]</param>
        /// <param name="lineType">Type of the line, see cvLine description. [By default this is LineType.Link8]</param>
        /// <param name="shift">Number of fractional bits in the point coordinates. [By default this is 0]</param>
#endif
        public static void Rectangle(InputOutputArray img, Rect rect, Scalar color, int thickness = 1, LineType lineType = LineType.Link8, int shift = 0)
        {
            if (img == null)
                throw new ArgumentNullException("img");
            NativeMethods.core_rectangle1(img.CvPtr, rect.TopLeft, rect.BottomRight, color, thickness, (int)lineType, shift);
            img.Fix();
        }

#if LANG_JP
        /// <summary>
        /// 枠のみ，もしくは塗りつぶされた矩形を描画する
        /// </summary>
        /// <param name="img">画像</param>
        /// <param name="pt1">矩形の一つの頂点</param>
        /// <param name="pt2">矩形の反対側の頂点</param>
        /// <param name="color">線の色(RGB)，もしくは輝度(グレースケール画像).</param>
        /// <param name="thickness">矩形を描く線の太さ．負の値を指定した場合は塗りつぶされる. [既定値は1]</param>
        /// <param name="lineType">線の種類. [既定値はLineType.Link8]</param>
        /// <param name="shift">座標の小数点以下の桁を表すビット数. [既定値は0]</param>
#else
        /// <summary>
        /// Draws simple, thick or filled rectangle
        /// </summary>
        /// <param name="img">Image. </param>
        /// <param name="pt1">One of the rectangle vertices. </param>
        /// <param name="pt2">Opposite rectangle vertex. </param>
        /// <param name="color">Line color (RGB) or brightness (grayscale image). </param>
        /// <param name="thickness">Thickness of lines that make up the rectangle. Negative values make the function to draw a filled rectangle. [By default this is 1]</param>
        /// <param name="lineType">Type of the line, see cvLine description. [By default this is LineType.Link8]</param>
        /// <param name="shift">Number of fractional bits in the point coordinates. [By default this is 0]</param>
#endif
        public static void Rectangle(Mat img, Point pt1, Point pt2, Scalar color, int thickness = 1, LineType lineType = LineType.Link8, int shift = 0)
        {
            if (img == null)
                throw new ArgumentNullException("img");
            Rect rect = Rect.FromLTRB(pt1.X, pt1.Y, pt2.X, pt2.Y);
            NativeMethods.core_rectangle2(img.CvPtr, rect, color, thickness, (int)lineType, shift);
            GC.KeepAlive(img);
        }

#if LANG_JP
        /// <summary>
        /// 枠のみ，もしくは塗りつぶされた矩形を描画する
        /// </summary>
        /// <param name="img">画像</param>
        /// <param name="rect">矩形</param>
        /// <param name="color">線の色(RGB)，もしくは輝度(グレースケール画像).</param>
        /// <param name="thickness">矩形を描く線の太さ．負の値を指定した場合は塗りつぶされる. [既定値は1]</param>
        /// <param name="lineType">線の種類. [既定値はLineType.Link8]</param>
        /// <param name="shift">座標の小数点以下の桁を表すビット数. [既定値は0]</param>
#else
        /// <summary>
        /// Draws simple, thick or filled rectangle
        /// </summary>
        /// <param name="img">Image. </param>
        /// <param name="rect">Rectangle.</param>
        /// <param name="color">Line color (RGB) or brightness (grayscale image). </param>
        /// <param name="thickness">Thickness of lines that make up the rectangle. Negative values make the function to draw a filled rectangle. [By default this is 1]</param>
        /// <param name="lineType">Type of the line, see cvLine description. [By default this is LineType.Link8]</param>
        /// <param name="shift">Number of fractional bits in the point coordinates. [By default this is 0]</param>
#endif
        public static void Rectangle(Mat img, Rect rect, Scalar color, int thickness = 1, LineType lineType = LineType.Link8, int shift = 0)
        {
            if (img == null)
                throw new ArgumentNullException("img");
            NativeMethods.core_rectangle2(img.CvPtr, rect, color, thickness, (int)lineType, shift);
            GC.KeepAlive(img);
        }

        #endregion
        #region Circle
#if LANG_JP
        /// <summary>
        /// 円を描画する
        /// </summary>
        /// <param name="img">画像</param>
        /// <param name="centerX">円の中心のx座標</param>
        /// <param name="centerY">円の中心のy座標</param>
        /// <param name="radius">円の半径</param>
        /// <param name="color">円の色</param>
        /// <param name="thickness">線の幅．負の値を指定した場合は塗りつぶされる．[既定値は1]</param>
        /// <param name="lineType">線の種類. [既定値はLineType.Link8]</param>
        /// <param name="shift">中心座標と半径の小数点以下の桁を表すビット数. [既定値は0]</param>
#else
        /// <summary>
        /// Draws a circle
        /// </summary>
        /// <param name="img">Image where the circle is drawn. </param>
        /// <param name="centerX">X-coordinate of the center of the circle. </param>
        /// <param name="centerY">Y-coordinate of the center of the circle. </param>
        /// <param name="radius">Radius of the circle. </param>
        /// <param name="color">Circle color. </param>
        /// <param name="thickness">Thickness of the circle outline if positive, otherwise indicates that a filled circle has to be drawn. [By default this is 1]</param>
        /// <param name="lineType">Type of the circle boundary. [By default this is LineType.Link8]</param>
        /// <param name="shift">Number of fractional bits in the center coordinates and radius value. [By default this is 0]</param>
#endif
        public static void Circle(InputOutputArray img, int centerX, int centerY, int radius, Scalar color, 
            int thickness = 1, LineType lineType = LineType.Link8, int shift = 0)
        {
            Circle(img, new Point(centerX, centerY), radius, color, thickness, lineType, shift);
        }

#if LANG_JP
        /// <summary>
        /// 円を描画する
        /// </summary>
        /// <param name="img">画像</param>
        /// <param name="center">円の中心</param>
        /// <param name="radius">円の半径</param>
        /// <param name="color">円の色</param>
        /// <param name="thickness">線の幅．負の値を指定した場合は塗りつぶされる．[既定値は1]</param>
        /// <param name="lineType">線の種類. [既定値はLineType.Link8]</param>
        /// <param name="shift">中心座標と半径の小数点以下の桁を表すビット数. [既定値は0]</param>
#else
        /// <summary>
        /// Draws a circle
        /// </summary>
        /// <param name="img">Image where the circle is drawn. </param>
        /// <param name="center">Center of the circle. </param>
        /// <param name="radius">Radius of the circle. </param>
        /// <param name="color">Circle color. </param>
        /// <param name="thickness">Thickness of the circle outline if positive, otherwise indicates that a filled circle has to be drawn. [By default this is 1]</param>
        /// <param name="lineType">Type of the circle boundary. [By default this is LineType.Link8]</param>
        /// <param name="shift">Number of fractional bits in the center coordinates and radius value. [By default this is 0]</param>
#endif
        public static void Circle(InputOutputArray img, Point center, int radius, Scalar color, 
            int thickness = 1, LineType lineType = LineType.Link8, int shift = 0)
        {
            if (img == null)
                throw new ArgumentNullException("img");
            img.ThrowIfDisposed();
            NativeMethods.core_circle(img.CvPtr, center, radius, color, thickness, (int)lineType, shift);
            img.Fix();
        }
        #endregion
        #region Ellipse
#if LANG_JP
        /// <summary>
        /// 枠だけの楕円，楕円弧，もしくは塗りつぶされた扇形の楕円を描画する
        /// </summary>
        /// <param name="img">楕円が描画される画像</param>
        /// <param name="center">楕円の中心</param>
        /// <param name="axes">楕円の軸の長さ</param>
        /// <param name="angle">回転角度</param>
        /// <param name="startAngle">楕円弧の開始角度</param>
        /// <param name="endAngle">楕円弧の終了角度</param>
        /// <param name="color">楕円の色</param>
        /// <param name="thickness">楕円弧の線の幅 [既定値は1]</param>
        /// <param name="lineType">楕円弧の線の種類 [既定値はLineType.Link8]</param>
        /// <param name="shift">中心座標と軸の長さの小数点以下の桁を表すビット数 [既定値は0]</param>
#else
        /// <summary>
        /// Draws simple or thick elliptic arc or fills ellipse sector
        /// </summary>
        /// <param name="img">Image. </param>
        /// <param name="center">Center of the ellipse. </param>
        /// <param name="axes">Length of the ellipse axes. </param>
        /// <param name="angle">Rotation angle. </param>
        /// <param name="startAngle">Starting angle of the elliptic arc. </param>
        /// <param name="endAngle">Ending angle of the elliptic arc. </param>
        /// <param name="color">Ellipse color. </param>
        /// <param name="thickness">Thickness of the ellipse arc. [By default this is 1]</param>
        /// <param name="lineType">Type of the ellipse boundary. [By default this is LineType.Link8]</param>
        /// <param name="shift">Number of fractional bits in the center coordinates and axes' values. [By default this is 0]</param>
#endif
        public static void Ellipse(InputOutputArray img, Point center, Size axes, double angle, double startAngle, double endAngle, Scalar color,
            int thickness = 1, LineType lineType = LineType.Link8, int shift = 0)
        {
            if (img == null)
                throw new ArgumentNullException("img");
            img.ThrowIfNotReady();
            NativeMethods.core_ellipse(img.CvPtr, center, axes, angle, startAngle, endAngle, color, thickness, (int)lineType, shift);
            img.Fix();
        }

#if LANG_JP
        /// <summary>
        /// 枠だけの楕円，もしくは塗りつぶされた楕円を描画する
        /// </summary>
        /// <param name="img">楕円が描かれる画像．</param>
        /// <param name="box">描画したい楕円を囲む矩形領域．</param>
        /// <param name="color">楕円の色．</param>
        /// <param name="thickness">楕円境界線の幅．[既定値は1]</param>
        /// <param name="lineType">楕円境界線の種類．[既定値はLineType.Link8]</param>
#else
        /// <summary>
        /// Draws simple or thick elliptic arc or fills ellipse sector
        /// </summary>
        /// <param name="img">Image. </param>
        /// <param name="box">The enclosing box of the ellipse drawn </param>
        /// <param name="color">Ellipse color. </param>
        /// <param name="thickness">Thickness of the ellipse boundary. [By default this is 1]</param>
        /// <param name="lineType">Type of the ellipse boundary. [By default this is LineType.Link8]</param>
#endif
        public static void Ellipse(InputOutputArray img, RotatedRect box, Scalar color, 
            int thickness = 1, LineType lineType = LineType.Link8)
        {
            if (img == null)
                throw new ArgumentNullException("img");
            img.ThrowIfDisposed();
            NativeMethods.core_ellipse(img.CvPtr, box, color, thickness, (int)lineType);
            img.Fix();
        }
        #endregion
        #region FillConvexPoly
#if LANG_JP
        /// <summary>
        /// 塗りつぶされた凸ポリゴンを描きます．
        /// </summary>
        /// <param name="img">画像</param>
        /// <param name="pts">ポリゴンの頂点．</param>
        /// <param name="color">ポリゴンの色．</param>
        /// <param name="lineType">ポリゴンの枠線の種類，</param>
        /// <param name="shift">ポリゴンの頂点座標において，小数点以下の桁を表すビット数．</param>
#else
        /// <summary>
        /// Fills a convex polygon.
        /// </summary>
        /// <param name="img">Image</param>
        /// <param name="pts">The polygon vertices</param>
        /// <param name="color">Polygon color</param>
        /// <param name="lineType">Type of the polygon boundaries</param>
        /// <param name="shift">The number of fractional bits in the vertex coordinates</param>
#endif
        public static void FillConvexPoly(Mat img, IEnumerable<Point> pts, Scalar color, 
            LineType lineType = LineType.Link8, int shift = 0)
        {
            if (img == null)
                throw new ArgumentNullException("img");
            img.ThrowIfDisposed();

            Point[] ptsArray = Util.Utility.ToArray(pts);
            NativeMethods.core_fillConvexPoly(img.CvPtr, ptsArray, ptsArray.Length, color, (int)lineType, shift);
            GC.KeepAlive(img);
        }
        #endregion
        #region FillPoly
#if LANG_JP
        /// <summary>
        /// 1つ，または複数のポリゴンで区切られた領域を塗りつぶします．
        /// </summary>
        /// <param name="img">画像</param>
        /// <param name="pts">ポリゴンの配列．各要素は，点の配列で表現されます．</param>
        /// <param name="color">ポリゴンの色．</param>
        /// <param name="lineType">ポリゴンの枠線の種類，</param>
        /// <param name="shift">ポリゴンの頂点座標において，小数点以下の桁を表すビット数．</param>
        /// <param name="offset"></param>
#else
        /// <summary>
        /// Fills the area bounded by one or more polygons
        /// </summary>
        /// <param name="img">Image</param>
        /// <param name="pts">Array of polygons, each represented as an array of points</param>
        /// <param name="color">Polygon color</param>
        /// <param name="lineType">Type of the polygon boundaries</param>
        /// <param name="shift">The number of fractional bits in the vertex coordinates</param>
        /// <param name="offset"></param>
#endif
        public static void FillPoly(InputOutputArray img, IEnumerable<IEnumerable<Point>> pts, Scalar color, 
            LineType lineType = LineType.Link8, int shift = 0, Point? offset = null)
        {
            if (img == null)
                throw new ArgumentNullException("img");
            img.ThrowIfDisposed();
            Point offset0 = offset.GetValueOrDefault(new Point());

            List<Point[]> ptsList = new List<Point[]>();
            List<int> nptsList = new List<int>();
            foreach (IEnumerable<Point> pts1 in pts)
            {
                Point[] pts1Arr = Util.Utility.ToArray(pts1);
                ptsList.Add(pts1Arr);
                nptsList.Add(pts1Arr.Length);
            }
            Point[][] ptsArr = ptsList.ToArray();
            int[] npts = nptsList.ToArray();
            int ncontours = ptsArr.Length;
            using (var ptsPtr = new ArrayAddress2<Point>(ptsArr))
            {
                NativeMethods.core_fillPoly(img.CvPtr, ptsPtr.Pointer, npts, ncontours, color, (int)lineType, shift, offset0);
            }
            img.Fix();
        }
        #endregion
        #region Polylines
        /// <summary>
        /// draws one or more polygonal curves
        /// </summary>
        /// <param name="img"></param>
        /// <param name="pts"></param>
        /// <param name="isClosed"></param>
        /// <param name="color"></param>
        /// <param name="thickness"></param>
        /// <param name="lineType"></param>
        /// <param name="shift"></param>
        public static void Polylines(InputOutputArray img, IEnumerable<IEnumerable<Point>> pts, bool isClosed, Scalar color, 
            int thickness = 1, LineType lineType = LineType.Link8, int shift = 0)
        {
            if (img == null)
                throw new ArgumentNullException("img");
            img.ThrowIfDisposed();

            List<Point[]> ptsList = new List<Point[]>();
            List<int> nptsList = new List<int>();
            foreach (IEnumerable<Point> pts1 in pts)
            {
                Point[] pts1Arr = Util.Utility.ToArray(pts1);
                ptsList.Add(pts1Arr);
                nptsList.Add(pts1Arr.Length);
            }
            Point[][] ptsArr = ptsList.ToArray();
            int[] npts = nptsList.ToArray();
            int ncontours = ptsArr.Length;
            using (ArrayAddress2<Point> ptsPtr = new ArrayAddress2<Point>(ptsArr))
            {
                NativeMethods.core_polylines(img.CvPtr, ptsPtr.Pointer, npts, ncontours, isClosed ? 1 : 0, color, thickness, (int)lineType, shift);
            }
            img.Fix();
        }
        #endregion
        #region ClipLine
#if LANG_JP
        /// <summary>
        /// 線分が画像矩形内に収まるように切り詰めます．
        /// </summary>
        /// <param name="imgSize">画像サイズ．</param>
        /// <param name="pt1">線分の1番目の端点．</param>
        /// <param name="pt2">線分の2番目の端点．</param>
        /// <returns></returns>
#else
        /// <summary>
        /// Clips the line against the image rectangle
        /// </summary>
        /// <param name="imgSize">The image size</param>
        /// <param name="pt1">The first line point</param>
        /// <param name="pt2">The second line point</param>
        /// <returns></returns>
#endif
        public static bool ClipLine(Size imgSize, ref Point pt1, ref Point pt2)
        {
            return NativeMethods.core_clipLine(imgSize, ref pt1, ref pt2) != 0;
        }
#if LANG_JP
        /// <summary>
        /// 線分が画像矩形内に収まるように切り詰めます．
        /// </summary>
        /// <param name="imgRect">画像矩形．</param>
        /// <param name="pt1">線分の1番目の端点．</param>
        /// <param name="pt2">線分の2番目の端点．</param>
        /// <returns></returns>
#else
        /// <summary>
        /// Clips the line against the image rectangle
        /// </summary>
        /// <param name="imgRect">sThe image rectangle</param>
        /// <param name="pt1">The first line point</param>
        /// <param name="pt2">The second line point</param>
        /// <returns></returns>
#endif
        public static bool ClipLine(Rect imgRect, ref Point pt1, ref Point pt2)
        {
            return NativeMethods.core_clipLine(imgRect, ref pt1, ref pt2) != 0;
        }
        #endregion
        #region PutText
        /// <summary>
        /// renders text string in the image
        /// </summary>
        /// <param name="img"></param>
        /// <param name="text"></param>
        /// <param name="org"></param>
        /// <param name="fontFace"></param>
        /// <param name="fontScale"></param>
        /// <param name="color"></param>
        /// <param name="thickness"></param>
        /// <param name="lineType"></param>
        /// <param name="bottomLeftOrigin"></param>
        public static void PutText(InputOutputArray img, string text, Point org,
            HersheyFonts fontFace, double fontScale, Scalar color,
            int thickness = 1, LineType lineType = LineType.Link8, bool bottomLeftOrigin = false) 
        {
            if (img == null)
                throw new ArgumentNullException("img");
            if (String.IsNullOrEmpty(text))
                throw new ArgumentNullException(text); 
            img.ThrowIfDisposed();
            NativeMethods.core_putText(img.CvPtr, text, org, (int)fontFace, fontScale, color, 
                thickness, (int)lineType, bottomLeftOrigin ? 1 : 0);
            img.Fix();
        }
        #endregion
        #region GetTextSize
        /// <summary>
        /// returns bounding box of the text string
        /// </summary>
        /// <param name="text"></param>
        /// <param name="fontFace"></param>
        /// <param name="fontScale"></param>
        /// <param name="thickness"></param>
        /// <param name="baseLine"></param>
        /// <returns></returns>
        public static Size GetTextSize(string text, HersheyFonts fontFace,
            double fontScale, int thickness, out int baseLine)
        {
            if (String.IsNullOrEmpty(text))
                throw new ArgumentNullException(text);
            return NativeMethods.core_getTextSize(text, (int)fontFace, fontScale, thickness, out baseLine);
        }
        #endregion
        #endregion     
    }
}
