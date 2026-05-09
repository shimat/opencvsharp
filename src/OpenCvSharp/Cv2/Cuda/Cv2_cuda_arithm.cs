using System.Runtime.InteropServices;
using OpenCvSharp.Cuda;
using OpenCvSharp.Internal;

namespace OpenCvSharp;

public static partial class Cv2
{
    public static partial class Cuda
    {
        #region Abs
        /// <summary>
        /// Computes an absolute value of each matrix element.
        /// </summary>
        public static void Abs(OpenCvSharp.Cuda.InputArray src, OpenCvSharp.Cuda.OutputArray dst, OpenCvSharp.Cuda.Stream? stream = null)
        {
            if (src is null)
                throw new ArgumentNullException(nameof(src));
            if (dst is null)
                throw new ArgumentNullException(nameof(dst));
            src.ThrowIfDisposed();
            dst.ThrowIfNotReady();

            NativeMethods.HandleException(NativeMethods.cuda_abs(src.CvPtr, dst.CvPtr, ToPtr(stream)));

            GC.KeepAlive(src);
            GC.KeepAlive(dst);
            dst.Fix();
        }

        /// <summary>
        /// Computes per-element absolute difference of two matrices (or of a
        /// matrix and a scalar).
        /// </summary>
        public static void Absdiff(OpenCvSharp.Cuda.InputArray src1, OpenCvSharp.Cuda.InputArray src2, OpenCvSharp.Cuda.OutputArray dst, OpenCvSharp.Cuda.Stream? stream = null)
        {
            if (src1 is null)
                throw new ArgumentNullException(nameof(src1));
            if (src2 is null)
                throw new ArgumentNullException(nameof(src2));
            if (dst is null)
                throw new ArgumentNullException(nameof(dst));
            src1.ThrowIfDisposed();
            src2.ThrowIfDisposed();
            dst.ThrowIfNotReady();

            NativeMethods.HandleException(
                NativeMethods.cuda_absdiff(src1.CvPtr, src2.CvPtr, dst.CvPtr, ToPtr(stream)));

            GC.KeepAlive(src1);
            GC.KeepAlive(src2);
            dst.Fix();
        }

        /// <summary>
        /// Computes per-element absolute difference of a matrix and scalar. 
        /// </summary>
        public static void AbsdiffWithScalar(OpenCvSharp.Cuda.InputArray src1, Scalar src2, OpenCvSharp.Cuda.OutputArray dst, OpenCvSharp.Cuda.Stream? stream = null)
        {
            if (src1 is null)
                throw new ArgumentNullException(nameof(src1));
            if (dst is null)
                throw new ArgumentNullException(nameof(dst));

            src1.ThrowIfDisposed();
            dst.ThrowIfNotReady();

            NativeMethods.HandleException(
                NativeMethods.cuda_absdiffWithScalar(src1.CvPtr, src2, dst.CvPtr, ToPtr(stream)));

            GC.KeepAlive(src1);
            dst.Fix();
        }

        /// <summary>
        /// Returns the sum of absolute values for matrix elements. 
        /// </summary>
        public static Scalar AbsSum(OpenCvSharp.Cuda.InputArray src, OpenCvSharp.Cuda.InputArray? mask = null)
        {
            if (src is null)
                throw new ArgumentNullException(nameof(src));
            src.ThrowIfDisposed();

            NativeMethods.HandleException(NativeMethods.cuda_absSum(src.CvPtr, ToPtr(mask), out Scalar ret));
            GC.KeepAlive(src);
            GC.KeepAlive(mask);
            return ret;
        }
        #endregion

        #region Add
        /// <summary>
        /// Computes a matrix-matrix or matrix-scalar sum.
        /// </summary>
        public static void Add(OpenCvSharp.Cuda.InputArray src1, OpenCvSharp.Cuda.InputArray src2, 
            OpenCvSharp.Cuda.OutputArray dst, OpenCvSharp.Cuda.InputArray? mask = null, int dtype = -1, 
            OpenCvSharp.Cuda.Stream? stream = null)
        {
            if (src1 is null)
                throw new ArgumentNullException(nameof(src1));
            if (src2 is null)
                throw new ArgumentNullException(nameof(src2));
            if (dst is null)
                throw new ArgumentNullException(nameof(dst));
            src1.ThrowIfDisposed();
            src2.ThrowIfDisposed();
            dst.ThrowIfNotReady();

            NativeMethods.HandleException(NativeMethods.cuda_add(src1.CvPtr, src2.CvPtr, dst.CvPtr, ToPtr(mask), dtype, ToPtr(stream)));
            GC.KeepAlive(src1);
            GC.KeepAlive(src2);
            GC.KeepAlive(mask);
            dst.Fix();
            
        }

        /// <summary>
        /// Computes the weighted sum of two arrays:
        /// dst = alpha * src1 + beta * src2 + gamma.
        /// </summary>
        public static void AddWeighted(OpenCvSharp.Cuda.InputArray src1, double alpha, OpenCvSharp.Cuda.InputArray src2, 
            double beta, double gamma, OpenCvSharp.Cuda.OutputArray dst, int dtype = -1, OpenCvSharp.Cuda.Stream? stream = null)
        {
            if (src1 is null)
                throw new ArgumentNullException(nameof(src1));
            if (src2 is null)
                throw new ArgumentNullException(nameof(src2));
            if (dst is null)
                throw new ArgumentNullException(nameof(dst));
            src1.ThrowIfDisposed();
            src2.ThrowIfDisposed();
            dst.ThrowIfNotReady();

            NativeMethods.HandleException(
                NativeMethods.cuda_addWeighted(
                    src1.CvPtr, alpha,
                    src2.CvPtr, beta,
                    gamma, dst.CvPtr,
                    dtype, ToPtr(stream)));

            GC.KeepAlive(src1);
            GC.KeepAlive(src2);
            dst.Fix();
        }

        /// <summary>
        /// Computes a matrix-scalar sum. 
        /// </summary>
        public static void Add(OpenCvSharp.Cuda.InputArray src1, Scalar src2, OpenCvSharp.Cuda.OutputArray dst, OpenCvSharp.Cuda.InputArray? mask = null, 
            int dtype = -1, OpenCvSharp.Cuda.Stream? stream = null)
        {
            if (src1 is null)
                throw new ArgumentNullException(nameof(src1));
            if (dst is null)
                throw new ArgumentNullException(nameof(dst));
            src1.ThrowIfDisposed();
            dst.ThrowIfNotReady();

            NativeMethods.HandleException(
                NativeMethods.cuda_addWithScalar(src1.CvPtr, src2, dst.CvPtr, ToPtr(mask), dtype, ToPtr(stream)));

            GC.KeepAlive(src1);
            dst.Fix();
            GC.KeepAlive(mask);


        }
        #endregion

        #region Bitwise And
        /// <summary>
        /// Performs a per-element bitwise conjunction of two matrices (or of a
        /// matrix and a scalar).
        /// </summary>
        public static void BitwiseAnd(OpenCvSharp.Cuda.InputArray src1, OpenCvSharp.Cuda.InputArray src2, OpenCvSharp.Cuda.OutputArray dst,
            OpenCvSharp.Cuda.InputArray? mask = null, OpenCvSharp.Cuda.Stream? stream = null)
        {
            if (src1 is null)
                throw new ArgumentNullException(nameof(src1));
            if (src2 is null)
                throw new ArgumentNullException(nameof(src2));
            if (dst is null)
                throw new ArgumentNullException(nameof(dst));
            src1.ThrowIfDisposed();
            src2.ThrowIfDisposed();
            dst.ThrowIfNotReady();

            NativeMethods.HandleException(
                NativeMethods.cuda_bitwise_and(
                    src1.CvPtr, src2.CvPtr, dst.CvPtr,
                    ToPtr(mask), ToPtr(stream)));

            GC.KeepAlive(src1);
            GC.KeepAlive(src2);
            GC.KeepAlive(mask);
            dst.Fix();
            
        }

        /// <summary>
        /// Performs a per-element bitwise conjunction of two matrices (or of a
        /// matrix and a scalar).
        /// </summary>
        public static void BitwiseAnd(OpenCvSharp.Cuda.InputArray src1, Scalar src2, OpenCvSharp.Cuda.OutputArray dst, 
            OpenCvSharp.Cuda.InputArray? mask = null, OpenCvSharp.Cuda.Stream? stream = null)
        {
            if (src1 is null)
                throw new ArgumentNullException(nameof(src1));
            if (dst is null)
                throw new ArgumentNullException(nameof(dst));
            src1.ThrowIfDisposed();
            dst.ThrowIfNotReady();

            NativeMethods.HandleException(
                NativeMethods.cuda_bitwise_and_with_scalar(src1.CvPtr, src2, dst.CvPtr, ToPtr(mask), ToPtr(stream)));

            GC.KeepAlive(src1);
            dst.Fix();
            GC.KeepAlive(mask);
        }

        #endregion

        #region Bitwise Not

        /// <summary>
        /// Performs a per-element bitwise inversion.
        /// </summary>
        public static void BitwiseNot(OpenCvSharp.Cuda.InputArray src, OpenCvSharp.Cuda.OutputArray dst, 
            OpenCvSharp.Cuda.InputArray? mask = null, OpenCvSharp.Cuda.Stream? stream = null)
        {
            if (src is null)
                throw new ArgumentNullException(nameof(src));
            if (dst is null)
                throw new ArgumentNullException(nameof(dst));
            src.ThrowIfDisposed();
            dst.ThrowIfNotReady();

            NativeMethods.HandleException(
                NativeMethods.cuda_bitwise_not(
                    src.CvPtr, dst.CvPtr,
                    ToPtr(mask), ToPtr(stream)));

            GC.KeepAlive(src);
            dst.Fix();
            GC.KeepAlive(mask);
        }

        #endregion

        #region Bitwise Or
        /// <summary>
        /// Performs a per-element bitwise disjunction of two matrices (or of a
        /// matrix and a scalar).
        /// </summary>
        public static void BitwiseOr(OpenCvSharp.Cuda.InputArray src1, OpenCvSharp.Cuda.InputArray src2, OpenCvSharp.Cuda.OutputArray dst,
            OpenCvSharp.Cuda.InputArray? mask = null, OpenCvSharp.Cuda.Stream? stream = null)
        {
            if (src1 is null)
                throw new ArgumentNullException(nameof(src1));
            if (src2 is null)
                throw new ArgumentNullException(nameof(src2));
            if (dst is null)
                throw new ArgumentNullException(nameof(dst));
            src1.ThrowIfDisposed();
            src2.ThrowIfDisposed();
            dst.ThrowIfNotReady();

            NativeMethods.HandleException(
                NativeMethods.cuda_bitwise_or(
                    src1.CvPtr, src2.CvPtr, dst.CvPtr,
                    ToPtr(mask), ToPtr(stream)));

            GC.KeepAlive(src1);
            GC.KeepAlive(src2);
            dst.Fix();
            GC.KeepAlive(mask);
        }

        /// <summary>
        /// Performs a per-element bitwise disjunction (OR) of a matrix and scalar.
        /// </summary>
        public static void BitwiseOr(OpenCvSharp.Cuda.InputArray src1, Scalar src2, OpenCvSharp.Cuda.OutputArray dst,
            OpenCvSharp.Cuda.InputArray? mask = null, OpenCvSharp.Cuda.Stream? stream = null)
        {
            if (src1 is null)
                throw new ArgumentNullException(nameof(src1));
            if (dst is null)
                throw new ArgumentNullException(nameof(dst));
            src1.ThrowIfDisposed();
            dst.ThrowIfNotReady();

            NativeMethods.HandleException(
                NativeMethods.cuda_bitwise_or_with_scalar(src1.CvPtr, src2, dst.CvPtr, ToPtr(mask), ToPtr(stream)));

            GC.KeepAlive(src1);
            dst.Fix();
            GC.KeepAlive(mask);

        }

        #endregion

        #region Bitwise Xor

        /// <summary>
        /// Performs a per-element bitwise exclusive-or of two matrices (or of a
        /// matrix and a scalar).
        /// </summary>
        public static void BitwiseXor(OpenCvSharp.Cuda.InputArray src1, OpenCvSharp.Cuda.InputArray src2, OpenCvSharp.Cuda.OutputArray dst, 
            OpenCvSharp.Cuda.InputArray? mask = null, OpenCvSharp.Cuda.Stream? stream = null)
        {
            if (src1 is null)
                throw new ArgumentNullException(nameof(src1));
            if (src2 is null)
                throw new ArgumentNullException(nameof(src2));
            if (dst is null)
                throw new ArgumentNullException(nameof(dst));
            src1.ThrowIfDisposed();
            src2.ThrowIfDisposed();
            dst.ThrowIfNotReady();

            NativeMethods.HandleException(
                NativeMethods.cuda_bitwise_xor(
                    src1.CvPtr, src2.CvPtr, dst.CvPtr,
                    ToPtr(mask), ToPtr(stream)));

            GC.KeepAlive(src1);
            GC.KeepAlive(src2);
            dst.Fix();
            GC.KeepAlive(mask);
        }

        /// <summary>
        /// Performs a per-element bitwise exclusive or (XOR) operation of a matrix and a scalar.
        /// </summary>
        public static void BitwiseXor(OpenCvSharp.Cuda.InputArray src1, Scalar src2, OpenCvSharp.Cuda.OutputArray dst, 
            OpenCvSharp.Cuda.InputArray? mask = null, OpenCvSharp.Cuda.Stream? stream = null)
        {
            if (src1 is null)
                throw new ArgumentNullException(nameof(src1));
            if (dst is null)
                throw new ArgumentNullException(nameof(dst));
            src1.ThrowIfDisposed();
            dst.ThrowIfNotReady();

            NativeMethods.HandleException(
                NativeMethods.cuda_bitwise_xor_with_scalar(src1.CvPtr, src2, dst.CvPtr, ToPtr(mask), ToPtr(stream)));

            GC.KeepAlive(src1);
            dst.Fix();
            GC.KeepAlive(mask);
        }

        #endregion

        #region calcAbsSum
        /// <summary>
        /// This is an overloaded member function, provided for convenience. It differs from the absSum() function only in what argument(s) it accepts. 
        /// </summary>

        public static void CalcAbsSum(OpenCvSharp.Cuda.InputArray src, OpenCvSharp.Cuda.OutputArray dst, 
            OpenCvSharp.Cuda.InputArray? mask = null, OpenCvSharp.Cuda.Stream? stream = null)
        {
            if (src is null)
                throw new ArgumentNullException(nameof(src));
            if (dst is null)
                throw new ArgumentNullException(nameof(dst));
            src.ThrowIfDisposed();
            dst.ThrowIfNotReady();

            NativeMethods.HandleException(NativeMethods.cuda_calcAbsSum(src.CvPtr, dst.CvPtr, ToPtr(mask), ToPtr(stream)));
            GC.KeepAlive(src);
            dst.Fix();
            GC.KeepAlive(mask);
        }

        #endregion

        #region calcHist

        /// <summary>
        /// This is an overloaded member function, provided for convenience. It differs from the Hist() function only in what argument(s) it accepts. 
        /// </summary>
        public static void CalcHist(OpenCvSharp.Cuda.InputArray src, OpenCvSharp.Cuda.OutputArray hist, 
            OpenCvSharp.Cuda.InputArray? mask = null, OpenCvSharp.Cuda.Stream? stream = null)
        {
            if (src is null)
                throw new ArgumentNullException(nameof(src));
            if (hist is null)
                throw new ArgumentNullException(nameof(hist));
            src.ThrowIfDisposed();
            hist.ThrowIfNotReady();

            NativeMethods.HandleException(NativeMethods.cuda_calcHist(src.CvPtr, ToPtr(mask), hist.CvPtr, ToPtr(stream)));
            GC.KeepAlive(src);
            hist.Fix();
            GC.KeepAlive(mask);
        }

        #endregion

        #region calcNorm+calcNormDiff

        /// <summary>
        /// This is an overloaded member function, provided for convenience. It differs from the Norm() function only in what argument(s) it accepts. 
        /// </summary>
        public static void CalcNorm(OpenCvSharp.Cuda.InputArray src, OpenCvSharp.Cuda.OutputArray dst, NormTypes normType, 
            OpenCvSharp.Cuda.InputArray? mask = null, OpenCvSharp.Cuda.Stream? stream = null)
        {
            if (src is null)
                throw new ArgumentNullException(nameof(src));
            if (dst is null)
                throw new ArgumentNullException(nameof(dst));
            src.ThrowIfDisposed();
            dst.ThrowIfNotReady();

            NativeMethods.HandleException(NativeMethods.cuda_calcNorm(src.CvPtr, dst.CvPtr, (int)normType, ToPtr(mask), ToPtr(stream)));
            GC.KeepAlive(src);
            dst.Fix();
            GC.KeepAlive(mask);
        }

        /// <summary>
        /// This is an overloaded member function, provided for convenience. It differs from the NormDiff() function only in what argument(s) it accepts. 
        /// </summary>
        public static void CalcNormDiff(OpenCvSharp.Cuda.InputArray src1, OpenCvSharp.Cuda.InputArray src2, 
            OpenCvSharp.Cuda.OutputArray dst, NormTypes normType = NormTypes.L2, OpenCvSharp.Cuda.Stream? stream = null)
        {
            if (src1 is null)
                throw new ArgumentNullException(nameof(src1));
            if (src2 is null)
                throw new ArgumentNullException(nameof(src2));
            if (dst is null)
                throw new ArgumentNullException(nameof(dst));
            src1.ThrowIfDisposed();
            src2.ThrowIfDisposed();
            dst.ThrowIfNotReady();

            NativeMethods.HandleException(NativeMethods.cuda_calcNormDiff(src1.CvPtr, src2.CvPtr, dst.CvPtr, (int)normType, ToPtr(stream)));
            GC.KeepAlive(src1);
            GC.KeepAlive(src2);
            dst.Fix();
        }


        #endregion

        #region calcSqrSum

        /// <summary>
        /// This is an overloaded member function, provided for convenience. It differs from the SqrSum() function only in what argument(s) it accepts. 
        /// </summary>
        public static void CalcSqrSum(OpenCvSharp.Cuda.InputArray src, OpenCvSharp.Cuda.OutputArray dst, 
            OpenCvSharp.Cuda.InputArray? mask = null, OpenCvSharp.Cuda.Stream? stream = null)
        {
            if (src is null)
                throw new ArgumentNullException(nameof(src));
            if (dst is null)
                throw new ArgumentNullException(nameof(dst));
            src.ThrowIfDisposed();
            dst.ThrowIfNotReady();

            NativeMethods.HandleException(NativeMethods.cuda_calcSqrSum(src.CvPtr, dst.CvPtr, ToPtr(mask), ToPtr(stream)));
            GC.KeepAlive(src);
            dst.Fix();
            GC.KeepAlive(mask);
        }


        #endregion

        #region CalcSum
        /// <summary>
        /// This is an overloaded member function, provided for convenience. It differs from the Sum() function only in what argument(s) it accepts. 
        /// </summary>
        public static void CalcSum(OpenCvSharp.Cuda.InputArray src, OpenCvSharp.Cuda.OutputArray dst, OpenCvSharp.Cuda.InputArray? mask = null, OpenCvSharp.Cuda.Stream? stream = null)
        {
            if (src is null)
                throw new ArgumentNullException(nameof(src));
            if (dst is null)
                throw new ArgumentNullException(nameof(dst));
            src.ThrowIfDisposed();
            dst.ThrowIfNotReady();

            NativeMethods.HandleException(NativeMethods.cuda_calcSum(src.CvPtr, dst.CvPtr, ToPtr(mask), ToPtr(stream)));
            GC.KeepAlive(src);
            dst.Fix();
            GC.KeepAlive(mask);
        }

        #endregion

        #region CartToPolar

        /// <summary>
        /// Converts Cartesian coordinates into polar.
        /// </summary>
        public static void CartToPolar(OpenCvSharp.Cuda.InputArray x, OpenCvSharp.Cuda.InputArray y, OpenCvSharp.Cuda.OutputArray magnitude, 
            OpenCvSharp.Cuda.OutputArray angle, bool angleInDegrees = false, OpenCvSharp.Cuda.Stream? stream = null)
        {
            if (x is null)
                throw new ArgumentNullException(nameof(x));
            if (y is null)
                throw new ArgumentNullException(nameof(y));
            if (magnitude is null)
                throw new ArgumentNullException(nameof(magnitude));
            if (angle is null)
                throw new ArgumentNullException(nameof(angle));
            x.ThrowIfDisposed();
            y.ThrowIfDisposed();
            magnitude.ThrowIfNotReady();
            angle.ThrowIfNotReady();

            NativeMethods.HandleException(
                NativeMethods.cuda_cartToPolar(
                    x.CvPtr, y.CvPtr,
                    magnitude.CvPtr, angle.CvPtr,
                    angleInDegrees ? 1 : 0,
                   ToPtr(stream)));

            GC.KeepAlive(x);
            GC.KeepAlive(y);
            magnitude.Fix();
            angle.Fix();
        }

        /// <summary>
        /// Converts Cartesian coordinates into polar (Interleaved XY).
        /// </summary>
        public static void CartToPolar(OpenCvSharp.Cuda.InputArray xy, OpenCvSharp.Cuda.OutputArray magnitude, OpenCvSharp.Cuda.OutputArray angle,
            bool angleInDegrees = false, OpenCvSharp.Cuda.Stream? stream = null)
        {
            if (xy is null) 
                throw new ArgumentNullException(nameof(xy));
            if (magnitude is null) 
                throw new ArgumentNullException(nameof(magnitude));
            if (angle is null) 
                throw new ArgumentNullException(nameof(angle));

            xy.ThrowIfDisposed();
            magnitude.ThrowIfNotReady();
            angle.ThrowIfNotReady();

            NativeMethods.HandleException(
                NativeMethods.cuda_cartToPolar_interleaved(xy.CvPtr, magnitude.CvPtr, angle.CvPtr, angleInDegrees ? 1 : 0, ToPtr(stream)));

            magnitude.Fix();
            angle.Fix();
            GC.KeepAlive(xy);
        }

        /// <summary>
        /// Converts Cartesian coordinates into polar (Interleaved input and Interleaved output).
        /// </summary>
        /// <param name="xy">Source interleaved Cartesian coordinates (CV_32FC2 or CV_64FC2).</param>
        /// <param name="magnitudeAngle">Destination interleaved Polar coordinates (Magnitude, Angle).</param>
        /// <param name="angleInDegrees">If true, output angles are in degrees, otherwise in radians.</param>
        /// <param name="stream">Stream for the asynchronous version.</param>
        public static void CartToPolar(OpenCvSharp.Cuda.InputArray xy, OpenCvSharp.Cuda.OutputArray magnitudeAngle,
            bool angleInDegrees = false, OpenCvSharp.Cuda.Stream? stream = null)
        {
            if (xy is null) 
                throw new ArgumentNullException(nameof(xy));
            if (magnitudeAngle is null) 
                throw new ArgumentNullException(nameof(magnitudeAngle));

            xy.ThrowIfDisposed();
            magnitudeAngle.ThrowIfNotReady();

            NativeMethods.HandleException(
                NativeMethods.cuda_cartToPolar_interleaved_combined(
                    xy.CvPtr, magnitudeAngle.CvPtr, angleInDegrees ? 1 : 0, ToPtr(stream)));

            magnitudeAngle.Fix();
            GC.KeepAlive(xy);
        }
        #endregion

        #region Compare
        /// <summary>
        /// Compares elements of two matrices (or of a matrix and a scalar).
        /// </summary>
        public static void Compare(OpenCvSharp.Cuda.InputArray src1, OpenCvSharp.Cuda.InputArray src2,
            OpenCvSharp.Cuda.OutputArray dst, CmpTypes cmpop,
            OpenCvSharp.Cuda.Stream? stream = null)
        {
            if (src1 is null)
                throw new ArgumentNullException(nameof(src1));
            if (src2 is null)
                throw new ArgumentNullException(nameof(src2));
            if (dst is null)
                throw new ArgumentNullException(nameof(dst));
            src1.ThrowIfDisposed();
            src2.ThrowIfDisposed();
            dst.ThrowIfNotReady();

            NativeMethods.HandleException(
                NativeMethods.cuda_compare(
                    src1.CvPtr, src2.CvPtr, dst.CvPtr,
                    (int)cmpop, ToPtr(stream)));

            GC.KeepAlive(src1);
            GC.KeepAlive(src2);
            dst.Fix();
        }

        /// <summary>
        /// Compares elements of a matrix and a scalar.
        /// </summary>
        public static void Compare(OpenCvSharp.Cuda.InputArray src1, Scalar src2,
            OpenCvSharp.Cuda.OutputArray dst, CmpTypes cmpop, OpenCvSharp.Cuda.Stream? stream = null)
        {
            if (src1 is null) 
                throw new ArgumentNullException(nameof(src1));
            if (dst is null) 
                throw new ArgumentNullException(nameof(dst));

            src1.ThrowIfDisposed();
            dst.ThrowIfNotReady();

            NativeMethods.HandleException(
                NativeMethods.cuda_compareWithScalar(src1.CvPtr, src2, dst.CvPtr, (int)cmpop, ToPtr(stream)));

            dst.Fix();
            GC.KeepAlive(src1);
        }

        #endregion

        #region CopyMakeBorder
        /// <summary>
        /// Forms a border around an image.
        /// </summary>
        public static void CopyMakeBorder(OpenCvSharp.Cuda.InputArray src, OpenCvSharp.Cuda.OutputArray dst, 
            int top, int bottom, int left, int right, BorderTypes borderType, Scalar? value = null, OpenCvSharp.Cuda.Stream? stream = null)
        {
            if (src is null)
                throw new ArgumentNullException(nameof(src));
            if (dst is null)
                throw new ArgumentNullException(nameof(dst));

            src.ThrowIfDisposed();
            dst.ThrowIfNotReady();

            Scalar val = value ?? new Scalar();

            NativeMethods.HandleException(
                NativeMethods.cuda_copyMakeBorder(
                    src.CvPtr, dst.CvPtr, top, bottom, left, right, (int)borderType, val, ToPtr(stream)));

            GC.KeepAlive(src);
            dst.Fix();
        }

        #endregion

        #region CountNonZero

        /// <summary>
        /// Counts non-zero matrix elements. (Synchronous, returns count directly).
        /// </summary>
        public static int CountNonZero(OpenCvSharp.Cuda.InputArray src)
        {
            if (src is null)
                throw new ArgumentNullException(nameof(src));
            src.ThrowIfDisposed();

            NativeMethods.HandleException(
                NativeMethods.cuda_countNonZero_int(src.CvPtr, out int ret));

            GC.KeepAlive(src);
            return ret;
        }

        /// <summary>
        /// Counts non-zero matrix elements. (Convenience overload for Asynchronous version).
        /// </summary>
        public static void CountNonZero(OpenCvSharp.Cuda.InputArray src, OpenCvSharp.Cuda.OutputArray dst, OpenCvSharp.Cuda.Stream? stream = null)
        {
            if (src is null)
                throw new ArgumentNullException(nameof(src));
            if (dst is null)
                throw new ArgumentNullException(nameof(dst));

            src.ThrowIfDisposed();
            dst.ThrowIfNotReady();

            NativeMethods.HandleException(
                NativeMethods.cuda_countNonZero_dst(src.CvPtr, dst.CvPtr, ToPtr(stream)));
            GC.KeepAlive(src);
            dst.Fix();

        }

        #endregion

        #region DFT
        /// <summary>
        /// Performs a forward or inverse discrete Fourier transform (1D or 2D) of the floating point matrix.
        /// </summary>
        /// <param name="src">Source array. CV_32FC1 or CV_32FC2 are supported.</param>
        /// <param name="dst">Destination array.</param>
        /// <param name="dftSize">Size of the transform.</param>
        /// <param name="flags">Transformation flags.</param>
        /// <param name="stream">Stream for the asynchronous version.</param>
        public static void Dft(OpenCvSharp.Cuda.InputArray src, OpenCvSharp.Cuda.OutputArray dst, 
            Size dftSize, DftFlags flags = 0, OpenCvSharp.Cuda.Stream? stream = null)
        {
            if (src is null)
                throw new ArgumentNullException(nameof(src));
            if (dst is null)
                throw new ArgumentNullException(nameof(dst));

            src.ThrowIfDisposed();
            dst.ThrowIfNotReady();

            NativeMethods.HandleException(
                NativeMethods.cuda_dft(src.CvPtr, dst.CvPtr, dftSize, (int)flags, ToPtr(stream)));

            GC.KeepAlive(src);
            dst.Fix();

        }

        #endregion

        #region Divide

        /// <summary>
        /// Computes a matrix-matrix or matrix-scalar division.
        /// </summary>
        public static void Divide(OpenCvSharp.Cuda.InputArray src1, OpenCvSharp.Cuda.InputArray src2,
            OpenCvSharp.Cuda.OutputArray dst, double scale = 1.0, int dtype = -1, OpenCvSharp.Cuda.Stream? stream = null)
        {
            if (src1 is null) 
                throw new ArgumentNullException(nameof(src1));
            if (src2 is null) 
                throw new ArgumentNullException(nameof(src2));
            if (dst is null) 
                throw new ArgumentNullException(nameof(dst));

            src1.ThrowIfDisposed();
            src2.ThrowIfDisposed();
            dst.ThrowIfNotReady();

            NativeMethods.HandleException(
                NativeMethods.cuda_divide(
                    src1.CvPtr, src2.CvPtr, dst.CvPtr,
                    scale, dtype, ToPtr(stream)));

            GC.KeepAlive(src1);
            GC.KeepAlive(src2);
            dst.Fix();
        }

        /// <summary>
        /// Computes a matrix-scalar division.
        /// </summary>
        /// <param name="src1">Source matrix.</param>
        /// <param name="src2">Scalar divisor.</param>
        /// <param name="dst">Destination matrix.</param>
        /// <param name="scale">Scale factor.</param>
        /// <param name="dtype">Optional output depth. If -1, dst will have the same depth as src1.</param>
        /// <param name="stream">Stream for the asynchronous version.</param>
        public static void Divide(OpenCvSharp.Cuda.InputArray src1, Scalar src2, OpenCvSharp.Cuda.OutputArray dst,
            double scale = 1, int dtype = -1, OpenCvSharp.Cuda.Stream? stream = null)
        {
            if (src1 is null) 
                throw new ArgumentNullException(nameof(src1));
            if (dst is null) 
                throw new ArgumentNullException(nameof(dst));

            src1.ThrowIfDisposed();
            dst.ThrowIfNotReady();

            NativeMethods.HandleException(
                NativeMethods.cuda_divideWithScalar(src1.CvPtr, src2, dst.CvPtr, scale, dtype, ToPtr(stream)));

            dst.Fix();
            GC.KeepAlive(src1);
        }

        #endregion

        #region Exp

        /// <summary>
        /// Computes an exponent of each matrix element.
        /// </summary>
        public static void Exp(OpenCvSharp.Cuda.InputArray src, OpenCvSharp.Cuda.OutputArray dst, OpenCvSharp.Cuda.Stream? stream = null)
        {
            if (src is null) 
                throw new ArgumentNullException(nameof(src));
            if (dst is null) 
                throw new ArgumentNullException(nameof(dst));
            src.ThrowIfDisposed();
            dst.ThrowIfNotReady();

            NativeMethods.HandleException(
                NativeMethods.cuda_exp(
                    src.CvPtr, dst.CvPtr, ToPtr(stream)));
            GC.KeepAlive(src);
            dst.Fix();
        }

        #endregion

        #region FindMinMax


        /// <summary>
        /// Finds the minimum and maximum element values and returns them on the GPU.
        /// </summary>
        /// <param name="src">Single-channel source image.</param>
        /// <param name="dst">Output 1x2 CV_64F matrix on GPU containing [min, max].</param>
        /// <param name="mask">Optional mask.</param>
        /// <param name="stream">Stream for the asynchronous version.</param>
        public static void FindMinMax(OpenCvSharp.Cuda.InputArray src, OpenCvSharp.Cuda.OutputArray dst, 
            OpenCvSharp.Cuda.InputArray? mask = null, OpenCvSharp.Cuda.Stream? stream = null)
        {
            if (src is null) 
                throw new ArgumentNullException(nameof(src));
            if (dst is null) 
                throw new ArgumentNullException(nameof(dst));

            src.ThrowIfDisposed();
            dst.ThrowIfNotReady();

            NativeMethods.HandleException(
                NativeMethods.cuda_findMinMax(src.CvPtr, dst.CvPtr, ToPtr(mask), ToPtr(stream)));

            GC.KeepAlive(src);
            GC.KeepAlive(mask);
            dst.Fix();
        }

        /// <summary>
        /// Finds the minimum and maximum element values and their localities on the GPU.
        /// </summary>
        /// <param name="src">Single-channel source image.</param>
        /// <param name="minMaxVals">Output 1x2 CV_64F matrix on GPU containing [min, max].</param>
        /// <param name="loc">Output 1x4 CV_32S matrix on GPU containing [minX, minY, maxX, maxY].</param>
        /// <param name="mask">Optional mask.</param>
        /// <param name="stream">Stream for the asynchronous version.</param>
        public static void FindMinMaxLoc(OpenCvSharp.Cuda.InputArray src, OpenCvSharp.Cuda.OutputArray minMaxVals, 
            OpenCvSharp.Cuda.OutputArray loc,  OpenCvSharp.Cuda.InputArray? mask = null, OpenCvSharp.Cuda.Stream? stream = null)
        {
            if (src is null) 
                throw new ArgumentNullException(nameof(src));
            if (minMaxVals is null) 
                throw new ArgumentNullException(nameof(minMaxVals));
            if (loc is null) 
                throw new ArgumentNullException(nameof(loc));

            src.ThrowIfDisposed();
            minMaxVals.ThrowIfNotReady();
            loc.ThrowIfNotReady();

            NativeMethods.HandleException(
                NativeMethods.cuda_findMinMaxLoc(src.CvPtr, minMaxVals.CvPtr, loc.CvPtr, ToPtr( mask), ToPtr(stream)));
            GC.KeepAlive(src);
            GC.KeepAlive(mask);
            minMaxVals.Fix();
            loc.Fix();
        }

        #endregion

        #region Flip
        /// <summary>
        /// Flips a 2D matrix around vertical, horizontal, or both axes.
        /// </summary>
        /// <param name="src">Source image.</param>
        /// <param name="dst">Destination image.</param>
        /// <param name="flipCode">A flag to specify how to flip the array; 0 means flipping around the x-axis and positive value (for example, 1) means flipping around y-axis. Negative value (for example, -1) means flipping around both axes.</param>
        /// <param name="stream">Stream for the asynchronous version.</param>
        public static void Flip(OpenCvSharp.Cuda.InputArray src, OpenCvSharp.Cuda.OutputArray dst, FlipMode flipCode, OpenCvSharp.Cuda.Stream? stream = null)
        {
            if (src is null) 
                throw new ArgumentNullException(nameof(src));
            if (dst is null) 
                throw new ArgumentNullException(nameof(dst));

            src.ThrowIfDisposed();
            dst.ThrowIfNotReady();

            NativeMethods.HandleException(
                NativeMethods.cuda_flip(src.CvPtr, dst.CvPtr, (int)flipCode, ToPtr(stream)));

            GC.KeepAlive(src);
            dst.Fix();
        }
        #endregion

        #region Gemm

        /// <summary>
        /// Performs generalized matrix multiplication.
        /// </summary>
        /// <param name="src1">First multiplied matrix. CV_32FC1, CV_32FC2, CV_64FC1, CV_64FC2 are supported.</param>
        /// <param name="src2">Second multiplied matrix. Same type as src1.</param>
        /// <param name="alpha">Weight of the matrix product.</param>
        /// <param name="src3">Optional third matrix to add. Same type as src1.</param>
        /// <param name="beta">Weight of src3.</param>
        /// <param name="dst">Destination matrix.</param>
        /// <param name="flags">Operation flags (GemmFlags).</param>
        /// <param name="stream">Stream for the asynchronous version.</param>
        public static void Gemm(OpenCvSharp.Cuda.InputArray src1, OpenCvSharp.Cuda.InputArray src2, double alpha, 
            OpenCvSharp.Cuda.InputArray? src3, double beta, OpenCvSharp.Cuda.OutputArray dst, GemmFlags flags = GemmFlags.None, OpenCvSharp.Cuda.Stream? stream = null)
        {
            if (src1 is null) 
                throw new ArgumentNullException(nameof(src1));
            if (src2 is null) 
                throw new ArgumentNullException(nameof(src2));
            if (dst is null)
                throw new ArgumentNullException(nameof(dst));

            src1.ThrowIfDisposed();
            src2.ThrowIfDisposed();
            if (src3 != null)
                src3.ThrowIfDisposed();
            dst.ThrowIfNotReady();

            NativeMethods.HandleException(
                NativeMethods.cuda_gemm(
                    src1.CvPtr, src2.CvPtr, alpha,
                    src3 ?.CvPtr ?? IntPtr.Zero, beta, dst.CvPtr,
                    (int)flags, ToPtr(stream)));

            dst.Fix();
            GC.KeepAlive(src1);
            GC.KeepAlive(src2);
            if (src3 != null) GC.KeepAlive(src3);
        }

        #endregion

        #region InRange

        /// <summary>
        /// Checks if array elements lie between two scalars.
        /// </summary>
        /// <param name="src">Source image.</param>
        /// <param name="lowerb">Inclusive lower boundary scalar.</param>
        /// <param name="upperb">Inclusive upper boundary scalar.</param>
        /// <param name="dst">Destination binary mask (CV_8UC1).</param>
        /// <param name="stream">Stream for the asynchronous version.</param>
        public static void InRange(OpenCvSharp.Cuda.InputArray src, Scalar lowerb, Scalar upperb,
            OpenCvSharp.Cuda.OutputArray dst, OpenCvSharp.Cuda.Stream? stream = null)
        {
            if (src is null)
                throw new ArgumentNullException(nameof(src));
            if (dst is null)
                throw new ArgumentNullException(nameof(dst));

            src.ThrowIfDisposed();
            dst.ThrowIfNotReady();

            NativeMethods.HandleException(
                NativeMethods.cuda_inRange(src.CvPtr, lowerb, upperb, dst.CvPtr, ToPtr(stream)));

            dst.Fix();
            GC.KeepAlive(src);
        }


        #endregion

        #region Integral
        /// <summary>
        /// Computes an integral image.
        /// </summary>
        /// <param name="src">Source image.</param>
        /// <param name="sum">Integral image, (W+1)x(H+1), CV_32S or CV_32F.</param>
        /// <param name="stream">Stream for the asynchronous version.</param>
        public static void Integral(OpenCvSharp.Cuda.InputArray src, OpenCvSharp.Cuda.OutputArray sum, OpenCvSharp.Cuda.Stream? stream = null)
        {
            if (src is null) 
                throw new ArgumentNullException(nameof(src));
            if (sum is null) 
                throw new ArgumentNullException(nameof(sum));

            src.ThrowIfDisposed();
            sum.ThrowIfNotReady();

            NativeMethods.HandleException(
                NativeMethods.cuda_integral(src.CvPtr, sum.CvPtr, ToPtr(stream)));
            
            GC.KeepAlive(src);
            sum.Fix();
        }

        #endregion

        #region Log

        /// <summary>
        /// Computes a natural logarithm of the absolute value of each matrix
        /// element.
        /// </summary>
        public static void Log(OpenCvSharp.Cuda.InputArray src, OpenCvSharp.Cuda.OutputArray dst, OpenCvSharp.Cuda.Stream? stream = null)
        {
            if (src is null) 
                throw new ArgumentNullException(nameof(src));
            if (dst is null) 
                throw new ArgumentNullException(nameof(dst));
            src.ThrowIfDisposed();
            dst.ThrowIfNotReady();

            NativeMethods.HandleException(
                NativeMethods.cuda_log(
                    src.CvPtr, dst.CvPtr, ToPtr(stream)));
            GC.KeepAlive(src);
            dst.Fix();
        }

        #endregion

        #region Lshift
        /// <summary>
        /// Performs pixel-by-pixel left shift of an image by a constant value.
        /// </summary>
        public static void Lshift(OpenCvSharp.Cuda.InputArray src, Scalar val, OpenCvSharp.Cuda.OutputArray dst,   OpenCvSharp.Cuda.Stream? stream = null)
        {
            if (src is null) 
                throw new ArgumentNullException(nameof(src));
            if (dst is null) 
                throw new ArgumentNullException(nameof(dst));
            src.ThrowIfDisposed();
            dst.ThrowIfNotReady();

            NativeMethods.HandleException(
                NativeMethods.cuda_lshift(
                    src.CvPtr, val, dst.CvPtr, ToPtr(stream)));
            GC.KeepAlive(src);
            dst.Fix();
        }

        #endregion

        #region Magnitude

        /// <summary>
        /// Computes magnitudes of complex matrix elements (2-channel input).
        /// </summary>
        public static void Magnitude(OpenCvSharp.Cuda.InputArray xy, OpenCvSharp.Cuda.OutputArray magnitude,  OpenCvSharp.Cuda.Stream? stream = null)
        {
            if (xy is null) 
                throw new ArgumentNullException(nameof(xy));
            if (magnitude is null) 
                throw new ArgumentNullException(nameof(magnitude));
            xy.ThrowIfDisposed();
            magnitude.ThrowIfNotReady();

            NativeMethods.HandleException(
                NativeMethods.cuda_magnitude_1(
                    xy.CvPtr, magnitude.CvPtr, ToPtr(stream)));

            GC.KeepAlive(xy);
            magnitude.Fix();
        }

        /// <summary>
        /// Computes magnitudes of complex matrix elements from separate X and Y
        /// planes.
        /// </summary>
        public static void Magnitude(OpenCvSharp.Cuda.InputArray x, OpenCvSharp.Cuda.InputArray y, OpenCvSharp.Cuda.OutputArray magnitude, OpenCvSharp.Cuda.Stream? stream = null)
        {
            if (x is null) 
                throw new ArgumentNullException(nameof(x));
            if (y is null) 
                throw new ArgumentNullException(nameof(y));
            if (magnitude is null) 
                throw new ArgumentNullException(nameof(magnitude));
            x.ThrowIfDisposed();
            y.ThrowIfDisposed();
            magnitude.ThrowIfNotReady();

            NativeMethods.HandleException(
                NativeMethods.cuda_magnitude_2(
                    x.CvPtr, y.CvPtr, magnitude.CvPtr, ToPtr(stream)));

            GC.KeepAlive(x);
            GC.KeepAlive(y);
            magnitude.Fix();
        }

        #endregion

        #region MagnitudeSqr

        /// <summary>
        /// Computes squared magnitudes of complex matrix elements (2-channel
        /// input).
        /// </summary>
        public static void MagnitudeSqr(OpenCvSharp.Cuda.InputArray xy, OpenCvSharp.Cuda.OutputArray magnitude, OpenCvSharp.Cuda.Stream? stream = null)
        {
            if (xy is null) 
                throw new ArgumentNullException(nameof(xy));
            if (magnitude is null) 
                throw new ArgumentNullException(nameof(magnitude));
            xy.ThrowIfDisposed();
            magnitude.ThrowIfNotReady();

            NativeMethods.HandleException(
                NativeMethods.cuda_magnitudeSqr_1(
                    xy.CvPtr, magnitude.CvPtr, ToPtr(stream)));

            GC.KeepAlive(xy);
            magnitude.Fix();
        }

        /// <summary>
        /// Computes squared magnitudes from separate X and Y planes.
        /// </summary>
        public static void MagnitudeSqr(OpenCvSharp.Cuda.InputArray x, OpenCvSharp.Cuda.InputArray y,  OpenCvSharp.Cuda.OutputArray magnitude, OpenCvSharp.Cuda.Stream? stream = null)
        {
            if (x is null) 
                throw new ArgumentNullException(nameof(x));
            if (y is null) 
                throw new ArgumentNullException(nameof(y));
            if (magnitude is null) 
                throw new ArgumentNullException(nameof(magnitude));
            x.ThrowIfDisposed();
            y.ThrowIfDisposed();
            magnitude.ThrowIfNotReady();

            NativeMethods.HandleException(
                NativeMethods.cuda_magnitudeSqr_2(
                    x.CvPtr, y.CvPtr, magnitude.CvPtr, ToPtr(stream)));

            GC.KeepAlive(x);
            GC.KeepAlive(y);
            magnitude.Fix();
        }

        #endregion

        #region Max

        /// <summary>
        /// Computes the per-element maximum of two matrices (or a matrix and a
        /// scalar).
        /// </summary>
        public static void Max(OpenCvSharp.Cuda.InputArray src1, OpenCvSharp.Cuda.InputArray src2, OpenCvSharp.Cuda.OutputArray dst, OpenCvSharp.Cuda.Stream? stream = null)
        {
            if (src1 is null) 
                throw new ArgumentNullException(nameof(src1));
            if (src2 is null) 
                throw new ArgumentNullException(nameof(src2));
            if (dst is null) 
                throw new ArgumentNullException(nameof(dst));
            src1.ThrowIfDisposed();
            src2.ThrowIfDisposed();
            dst.ThrowIfNotReady();

            NativeMethods.HandleException(
                NativeMethods.cuda_max(
                    src1.CvPtr, src2.CvPtr, dst.CvPtr, ToPtr(stream)));

            GC.KeepAlive(src1);
            GC.KeepAlive(src2);
            dst.Fix();
        }

        /// <summary>
        /// Computes the per-element maximum of a matrix and a scalar.
        /// </summary>
        /// <param name="src1">Source matrix.</param>
        /// <param name="src2">Scalar value.</param>
        /// <param name="dst">Destination matrix.</param>
        /// <param name="stream">Stream for the asynchronous version.</param>
        public static void Max(OpenCvSharp.Cuda.InputArray src1, Scalar src2, OpenCvSharp.Cuda.OutputArray dst,
            OpenCvSharp.Cuda.Stream? stream = null)
        {
            if (src1 is null) 
                throw new ArgumentNullException(nameof(src1));
            if (dst is null) 
                throw new ArgumentNullException(nameof(dst));

            src1.ThrowIfDisposed();
            dst.ThrowIfNotReady();

            NativeMethods.HandleException(
                NativeMethods.cuda_maxWithScalar(src1.CvPtr, src2, dst.CvPtr, ToPtr(stream)));

            dst.Fix();
            GC.KeepAlive(src1);
        }
        #endregion

        #region MeanShiftFiltering
        /// <summary>
        /// Performs mean-shift filtering for each point of the source image.
        /// </summary>
        /// <param name="src">Source 8-bit, 3-channel image.</param>
        /// <param name="dst">Destination image of the same format as src.</param>
        /// <param name="sp">Spatial window radius.</param>
        /// <param name="sr">Color window radius.</param>
        /// <param name="criteria">Termination criteria.</param>
        /// <param name="stream">Stream for the asynchronous version.</param>
        public static void MeanShiftFiltering(OpenCvSharp.Cuda.InputArray src, OpenCvSharp.Cuda.OutputArray dst, 
            int sp, int sr, TermCriteria? criteria = null, OpenCvSharp.Cuda.Stream? stream = null)
        {
            if (src is null) 
                throw new ArgumentNullException(nameof(src));
            if (dst is null) 
                throw new ArgumentNullException(nameof(dst));

            src.ThrowIfDisposed();
            dst.ThrowIfNotReady();

            // Default criteria: TermCriteria(TermCriteria::MAX_ITER + TermCriteria::EPS, 5, 1)
            TermCriteria crit = criteria ?? new TermCriteria(CriteriaTypes.MaxIter | CriteriaTypes.Eps, 5, 1);

            NativeMethods.HandleException(
                NativeMethods.cuda_meanShiftFiltering(src.CvPtr, dst.CvPtr, sp, sr, crit, ToPtr(stream)));
            
            GC.KeepAlive(src);
            dst.Fix();
        }

        #endregion

        #region MeanShiftProc

        /// <summary>
        /// Performs a mean-shift procedure and stores information about processed points (their colors and positions) in two images.
        /// </summary>
        /// <param name="src">Source 8-bit, 3-channel image.</param>
        /// <param name="dstr">Destination color image.</param>
        /// <param name="dstsp">Destination spatial image.</param>
        /// <param name="sp">Spatial window radius.</param>
        /// <param name="sr">Color window radius.</param>
        /// <param name="criteria">Termination criteria.</param>
        /// <param name="stream">Stream for the asynchronous version.</param>
        public static void MeanShiftProc(OpenCvSharp.Cuda.InputArray src, OpenCvSharp.Cuda.OutputArray dstr,
            OpenCvSharp.Cuda.OutputArray dstsp, int sp, int sr, TermCriteria? criteria = null, OpenCvSharp.Cuda.Stream? stream = null)
        {
            if (src is null) 
                throw new ArgumentNullException(nameof(src));
            if (dstr is null) 
                throw new ArgumentNullException(nameof(dstr));
            if (dstsp is null) 
                throw new ArgumentNullException(nameof(dstsp));

            src.ThrowIfDisposed();
            dstr.ThrowIfNotReady();
            dstsp.ThrowIfNotReady();

            // Default criteria: TermCriteria(TermCriteria::MAX_ITER + TermCriteria::EPS, 5, 1)
            TermCriteria crit = criteria ?? new TermCriteria(CriteriaTypes.MaxIter | CriteriaTypes.Eps, 5, 1);

            NativeMethods.HandleException(
                NativeMethods.cuda_meanShiftProc(src.CvPtr, dstr.CvPtr, dstsp.CvPtr, sp, sr, crit, ToPtr(stream)));
            
            GC.KeepAlive(src);
            dstr.Fix();
            dstsp.Fix();
        }

        #endregion

        #region MeanShiftSegmentation

        /// <summary>
        /// Performs a mean-shift segmentation of the source image and eliminates small segments.
        /// </summary>
        /// <param name="src">Source 8-bit, 3-channel image.</param>
        /// <param name="dst">Destination image of the same format as src.</param>
        /// <param name="sp">Spatial window radius.</param>
        /// <param name="sr">Color window radius.</param>
        /// <param name="minsize">Minimum segment size. Smaller segments will be merged.</param>
        /// <param name="criteria">Termination criteria.</param>
        /// <param name="stream">Stream for the asynchronous version.</param>
        public static void MeanShiftSegmentation(OpenCvSharp.Cuda.InputArray src, OpenCvSharp.Cuda.OutputArray dst, 
            int sp, int sr, int minsize, TermCriteria? criteria = null, OpenCvSharp.Cuda.Stream? stream = null)
        {
            if (src is null) 
                throw new ArgumentNullException(nameof(src));
            if (dst is null) 
                throw new ArgumentNullException(nameof(dst));

            src.ThrowIfDisposed();
            dst.ThrowIfNotReady();

            // Default criteria: TermCriteria(TermCriteria::MAX_ITER + TermCriteria::EPS, 5, 1)
            TermCriteria crit = criteria ?? new TermCriteria(CriteriaTypes.MaxIter | CriteriaTypes.Eps, 5, 1);

            NativeMethods.HandleException(
                NativeMethods.cuda_meanShiftSegmentation(src.CvPtr, dst.CvPtr, sp, sr, minsize, crit, ToPtr(stream)));

            GC.KeepAlive(src);
            dst.Fix();
        }

        #endregion

        #region MeanStdDev
        /// <summary>
        /// Computes a mean value and a standard deviation of matrix elements (Asynchronous).
        /// </summary>
        public static void MeanStdDev(
            OpenCvSharp.Cuda.InputArray src,
            OpenCvSharp.Cuda.OutputArray dst,
            OpenCvSharp.Cuda.InputArray? mask = null,
            OpenCvSharp.Cuda.Stream? stream = null)
        {
            if (src is null) throw new ArgumentNullException(nameof(src));
            if (dst is null) throw new ArgumentNullException(nameof(dst));
            src.ThrowIfDisposed();
            dst.ThrowIfNotReady();

            if (mask == null)
            {
                NativeMethods.HandleException(
                    NativeMethods.cuda_meanStdDev_dst(src.CvPtr, dst.CvPtr, ToPtr(stream)));
            }
            else
            {
                mask.ThrowIfDisposed();
                NativeMethods.HandleException(
                    NativeMethods.cuda_meanStdDev_dst_mask(src.CvPtr, dst.CvPtr, mask.CvPtr, ToPtr(stream)));
                GC.KeepAlive(mask);
            }

            dst.Fix();
            GC.KeepAlive(src);
        }

        /// <summary>
        /// Computes a mean value and a standard deviation of matrix elements (Synchronous).
        /// </summary>
        public static void MeanStdDev(
            OpenCvSharp.Cuda.InputArray src,
            out Scalar mean,
            out Scalar stddev,
            OpenCvSharp.Cuda.InputArray? mask = null)
        {
            if (src is null) throw new ArgumentNullException(nameof(src));
            src.ThrowIfDisposed();

            if (mask == null)
            {
                NativeMethods.HandleException(
                    NativeMethods.cuda_meanStdDev_scalar(src.CvPtr, out mean, out stddev));
            }
            else
            {
                mask.ThrowIfDisposed();
                NativeMethods.HandleException(
                    NativeMethods.cuda_meanStdDev_scalar_mask(src.CvPtr, out mean, out stddev, mask.CvPtr));
                GC.KeepAlive(mask);
            }

            GC.KeepAlive(src);
        }


        #endregion

        #region Merge
        /// <summary>
        /// Makes a multi-channel matrix out of several single-channel matrices.
        /// </summary>
        /// <param name="src">Array of single-channel matrices to be merged.</param>
        /// <param name="dst">Destination multi-channel matrix.</param>
        /// <param name="stream">Stream for the asynchronous version.</param>
        public static void Merge(GpuMat[] src, OpenCvSharp.Cuda.OutputArray dst, OpenCvSharp.Cuda.Stream? stream = null)
        {
            if (src is null) 
                throw new ArgumentNullException(nameof(src));
            if (dst is null) 
                throw new ArgumentNullException(nameof(dst));
            if (src.Length == 0) 
                throw new ArgumentException("Source array cannot be empty.", nameof(src));

            IntPtr[] ptrs = new IntPtr[src.Length];
            for (int i = 0; i < src.Length; i++)
            {
                if (src[i] is null) throw new ArgumentException($"Element at index {i} is null.");
                src[i].ThrowIfDisposed();
                ptrs[i] = src[i].CvPtr;
            }

            dst.ThrowIfNotReady();

            NativeMethods.HandleException(
                NativeMethods.cuda_merge(ptrs, (UIntPtr)src.Length, dst.CvPtr, ToPtr(stream)));
            
            foreach (var m in src) GC.KeepAlive(m);
            dst.Fix();
        }

        /// <summary>
        /// Makes a multi-channel matrix out of several single-channel matrices (Convenience overload).
        /// </summary>
        public static GpuMat Merge(GpuMat[] src, OpenCvSharp.Cuda.Stream? stream = null)
        {
            var dst = new GpuMat();
            Merge(src, dst, stream);
            return dst;
        }

        #endregion

        #region Min

        /// <summary>
        /// Computes the per-element minimum of two matrices (or a matrix and a
        /// scalar).
        /// </summary>
        public static void Min(OpenCvSharp.Cuda.InputArray src1, OpenCvSharp.Cuda.InputArray src2, 
            OpenCvSharp.Cuda.OutputArray dst, OpenCvSharp.Cuda.Stream? stream = null)
        {
            if (src1 is null) 
                throw new ArgumentNullException(nameof(src1));
            if (src2 is null) 
                throw new ArgumentNullException(nameof(src2));
            if (dst is null) 
                throw new ArgumentNullException(nameof(dst));
            src1.ThrowIfDisposed();
            src2.ThrowIfDisposed();
            dst.ThrowIfNotReady();

            NativeMethods.HandleException(
                NativeMethods.cuda_min(
                    src1.CvPtr, src2.CvPtr, dst.CvPtr, ToPtr(stream)));

            GC.KeepAlive(src1);
            GC.KeepAlive(src2);
            dst.Fix();
        }

        /// <summary>
        /// Computes the per-element minimum of a matrix and a scalar.
        /// </summary>
        /// <param name="src1">Source matrix.</param>
        /// <param name="src2">Scalar value acting as the upper limit.</param>
        /// <param name="dst">Destination matrix.</param>
        /// <param name="stream">Stream for the asynchronous version.</param>
        public static void Min(OpenCvSharp.Cuda.InputArray src1, Scalar src2, OpenCvSharp.Cuda.OutputArray dst,
            OpenCvSharp.Cuda.Stream? stream = null)
        {
            if (src1 is null) 
                throw new ArgumentNullException(nameof(src1));
            if (dst is null) 
                throw new ArgumentNullException(nameof(dst));

            src1.ThrowIfDisposed();
            dst.ThrowIfNotReady();

            NativeMethods.HandleException(
                NativeMethods.cuda_minWithScalar(src1.CvPtr, src2, dst.CvPtr, ToPtr(stream)));

            dst.Fix();
            GC.KeepAlive(src1);
        }


        #endregion

        #region MinMax

        /// <summary>
        /// Finds global minimum and maximum matrix elements and returns their values.
        /// </summary>
        /// <param name="src">Single-channel source image.</param>
        /// <param name="minVal">Pointer to the returned minimum value.</param>
        /// <param name="maxVal">Pointer to the returned maximum value.</param>
        /// <param name="mask">Optional mask.</param>
        public static void MinMax(OpenCvSharp.Cuda.InputArray src, out double minVal, out double maxVal, OpenCvSharp.Cuda.InputArray? mask = null)
        {
            if (src is null) 
                throw new ArgumentNullException(nameof(src));
            src.ThrowIfDisposed();

            NativeMethods.HandleException(
                NativeMethods.cuda_minMax(src.CvPtr, out minVal, out maxVal, ToPtr(mask)));
            GC.KeepAlive(mask);
            GC.KeepAlive(src);
        }

        /// <summary>
        /// Finds global minimum and maximum matrix elements and returns their values with locations.
        /// </summary>
        /// <param name="src">Single-channel source image.</param>
        /// <param name="minVal">Pointer to the returned minimum value.</param>
        /// <param name="maxVal">Pointer to the returned maximum value.</param>
        /// <param name="minLoc">Pointer to the returned minimum location.</param>
        /// <param name="maxLoc">Pointer to the returned maximum location.</param>
        /// <param name="mask">Optional mask.</param>
        public static void MinMaxLoc(OpenCvSharp.Cuda.InputArray src, out double minVal, out double maxVal, out Point minLoc, out Point maxLoc, OpenCvSharp.Cuda.InputArray? mask = null)
        {
            if (src is null) 
                throw new ArgumentNullException(nameof(src));

            src.ThrowIfDisposed();

            NativeMethods.HandleException(
                NativeMethods.cuda_minMaxLoc(src.CvPtr, out minVal, out maxVal, out minLoc, out maxLoc, ToPtr(mask)));

            GC.KeepAlive(src);
            GC.KeepAlive(mask);
        }

        #endregion

        #region Moments
        /// <summary>
        /// Calculates all of the moments up to the 3rd order of a rasterized shape.
        /// </summary>
        /// <param name="src">Raster image (8-bit 1-channel or floating-point 2D array).</param>
        /// <param name="binaryImage">If it is true, all non-zero image pixels are treated as 1's.</param>
        /// <param name="order">Order of moments to compute.</param>
        /// <param name="momentsType">Type of moments (CV_32F or CV_64F).</param>
        /// <returns>Moments structure.</returns>
        public static Moments Moments(
       OpenCvSharp.Cuda.InputArray src,
       bool binaryImage = false,
       MomentsOrder order = MomentsOrder.ThirdOrder,
       MatType? momentsType = null)
        {
            if (src is null) throw new ArgumentNullException(nameof(src));
            src.ThrowIfDisposed();

            int type = momentsType?.Value ?? (int)MatType.CV_64F;

            // Allocate array for the 24 doubles contained in cv::Moments
            double[] buffer = new double[24];

            NativeMethods.HandleException(
                NativeMethods.cuda_moments(
                    src.CvPtr,
                    binaryImage ? 1 : 0,
                    (int)order,
                    type,
                    buffer));

            GC.KeepAlive(src);

            // Map the flat array back into the OpenCvSharp Moments class.
            // The C++ memory layout is strictly ordered: 
            // Spatial (10), Central (7), Normalized (7)
            return new Moments
            {
                // Spatial moments
                M00 = buffer[0],
                M10 = buffer[1],
                M01 = buffer[2],
                M20 = buffer[3],
                M11 = buffer[4],
                M02 = buffer[5],
                M30 = buffer[6],
                M21 = buffer[7],
                M12 = buffer[8],
                M03 = buffer[9],

                // Central moments
                Mu20 = buffer[10],
                Mu11 = buffer[11],
                Mu02 = buffer[12],
                Mu30 = buffer[13],
                Mu21 = buffer[14],
                Mu12 = buffer[15],
                Mu03 = buffer[16],

                // Central normalized moments
                Nu20 = buffer[17],
                Nu11 = buffer[18],
                Nu02 = buffer[19],
                Nu30 = buffer[20],
                Nu21 = buffer[21],
                Nu12 = buffer[22],
                Nu03 = buffer[23]
            };
        }


        #endregion

        #region MulAndScaleSpectrums
        /// <summary>
        /// Performs a per-element multiplication of two Fourier spectrums and scales the result.
        /// </summary>
        public static void MulAndScaleSpectrums(OpenCvSharp.Cuda.InputArray src1, OpenCvSharp.Cuda.InputArray src2, 
            OpenCvSharp.Cuda.OutputArray dst, DftFlags flags, float scale, bool conjB = false, OpenCvSharp.Cuda.Stream? stream = null)
        {
            if (src1 is null) 
                throw new ArgumentNullException(nameof(src1));
            if (src2 is null) 
                throw new ArgumentNullException(nameof(src2));
            if (dst is null) 
                throw new ArgumentNullException(nameof(dst));

            src1.ThrowIfDisposed();
            src2.ThrowIfDisposed();
            dst.ThrowIfNotReady();

            NativeMethods.HandleException(
                NativeMethods.cuda_mulAndScaleSpectrums(src1.CvPtr, src2.CvPtr, dst.CvPtr, (int)flags, scale, conjB ? 1 : 0, ToPtr(stream)));
            
            GC.KeepAlive(src1);
            GC.KeepAlive(src2);
            dst.Fix();
        }

        #endregion

        #region MulSpectrums
        /// <summary>
        /// Performs a per-element multiplication of two Fourier spectrums.
        /// </summary>
        public static void MulSpectrums(OpenCvSharp.Cuda.InputArray src1, OpenCvSharp.Cuda.InputArray src2, 
            OpenCvSharp.Cuda.OutputArray dst, DftFlags flags, bool conjB = false, OpenCvSharp.Cuda.Stream? stream = null)
        {
            if (src1 is null) 
                throw new ArgumentNullException(nameof(src1));
            if (src2 is null) 
                throw new ArgumentNullException(nameof(src2));
            if (dst is null) 
                throw new ArgumentNullException(nameof(dst));

            src1.ThrowIfDisposed();
            src2.ThrowIfDisposed();
            dst.ThrowIfNotReady();

            NativeMethods.HandleException(
                NativeMethods.cuda_mulSpectrums(src1.CvPtr, src2.CvPtr, dst.CvPtr, (int)flags, conjB ? 1 : 0, ToPtr(stream)));
  
            GC.KeepAlive(src1);
            GC.KeepAlive(src2);
            dst.Fix();
        }

        #endregion

        #region Multiply

        /// <summary>
        /// Computes a matrix-matrix or matrix-scalar per-element product.
        /// </summary>
        public static void Multiply(OpenCvSharp.Cuda.InputArray src1, OpenCvSharp.Cuda.InputArray src2,  OpenCvSharp.Cuda.OutputArray dst,  double scale = 1.0, int dtype = -1, OpenCvSharp.Cuda.Stream? stream = null)
        {
            if (src1 is null) 
                throw new ArgumentNullException(nameof(src1));
            if (src2 is null) 
                throw new ArgumentNullException(nameof(src2));
            if (dst is null) 
                throw new ArgumentNullException(nameof(dst));

            src1.ThrowIfDisposed();
            src2.ThrowIfDisposed();
            dst.ThrowIfNotReady();

            NativeMethods.HandleException(
                NativeMethods.cuda_multiply(
                    src1.CvPtr, src2.CvPtr, dst.CvPtr,
                    scale, dtype, ToPtr(stream)));
           
            GC.KeepAlive(src1);
            GC.KeepAlive(src2);
            dst.Fix();
        }

        /// <summary>
        /// Computes a matrix-scalar per-element product.
        /// </summary>
        /// <param name="src1">Source matrix.</param>
        /// <param name="src2">Scalar multiplier.</param>
        /// <param name="dst">Destination matrix.</param>
        /// <param name="scale">Optional scale factor.</param>
        /// <param name="dtype">Optional output depth. If -1, dst will have the same depth as src1.</param>
        /// <param name="stream">Stream for the asynchronous version.</param>
        public static void Multiply(
            OpenCvSharp.Cuda.InputArray src1, Scalar src2, OpenCvSharp.Cuda.OutputArray dst,
            double scale = 1, int dtype = -1, OpenCvSharp.Cuda.Stream? stream = null)
        {
            if (src1 is null) 
                throw new ArgumentNullException(nameof(src1));
            if (dst is null) 
                throw new ArgumentNullException(nameof(dst));

            src1.ThrowIfDisposed();
            dst.ThrowIfNotReady();

            NativeMethods.HandleException(
                NativeMethods.cuda_multiplyWithScalar(src1.CvPtr, src2, dst.CvPtr, scale, dtype, ToPtr(stream)));

            dst.Fix();
            GC.KeepAlive(src1);
        }

        #endregion

        #region NonLocalMeans
        /// <summary>
        /// Performs pure non local means denoising without any simplification.
        /// </summary>
        /// <param name="src">Source image. Supports CV_8UC1, CV_8UC3.</param>
        /// <param name="dst">Destination image.</param>
        /// <param name="h">Filter sigma.</param>
        /// <param name="searchWindow">Size of search window.</param>
        /// <param name="blockSize">Size of patch.</param>
        /// <param name="borderMode">Border type.</param>
        /// <param name="stream">Stream for the asynchronous version.</param>
        public static void NonLocalMeans(OpenCvSharp.Cuda.InputArray src, OpenCvSharp.Cuda.OutputArray dst,
            float h, int searchWindow = 21, int blockSize = 7, BorderTypes borderMode = BorderTypes.Default, OpenCvSharp.Cuda.Stream? stream = null)
        {
            if (src is null) 
                throw new ArgumentNullException(nameof(src));
            if (dst is null) 
                throw new ArgumentNullException(nameof(dst));

            src.ThrowIfDisposed();
            dst.ThrowIfNotReady();

            NativeMethods.HandleException(
                NativeMethods.cuda_nonLocalMeans(
                    src.CvPtr, dst.CvPtr, h, searchWindow, blockSize, (int)borderMode, ToPtr(stream)));

            GC.KeepAlive(src); 
            dst.Fix();
        }

        #endregion

        #region Norm
        /// <summary>
        /// Returns the norm of a matrix.
        /// </summary>
        /// <param name="src1">Source matrix.</param>
        /// <param name="normType">Type of the norm (L1, L2, or Inf).</param>
        /// <param name="mask">Optional operation mask.</param>
        /// <returns>Calculated norm.</returns>
        public static double Norm(OpenCvSharp.Cuda.InputArray src1, NormTypes normType, OpenCvSharp.Cuda.InputArray? mask = null)
        {
            if (src1 is null) 
                throw new ArgumentNullException(nameof(src1));
            src1.ThrowIfDisposed();

            NativeMethods.HandleException(
                NativeMethods.cuda_norm1(src1.CvPtr, (int)normType, ToPtr(mask), out double ret));

            GC.KeepAlive(src1);
            GC.KeepAlive(mask);
            return ret;
        }

        /// <summary>
        /// Returns the norm of the difference of two matrices.
        /// </summary>
        /// <param name="src1">First source matrix.</param>
        /// <param name="src2">Second source matrix.</param>
        /// <param name="normType">Type of the norm (L1, L2, or Inf).</param>
        /// <returns>Calculated norm.</returns>
        public static double Norm(OpenCvSharp.Cuda.InputArray src1, OpenCvSharp.Cuda.InputArray src2, NormTypes normType = NormTypes.L2)
        {
            if (src1 is null) 
                throw new ArgumentNullException(nameof(src1));
            if (src2 is null) 
                throw new ArgumentNullException(nameof(src2));

            src1.ThrowIfDisposed();
            src2.ThrowIfDisposed();

            NativeMethods.HandleException(
                NativeMethods.cuda_norm2(src1.CvPtr, src2.CvPtr, (int)normType, out double ret));

            GC.KeepAlive(src1);
            GC.KeepAlive(src2);
            return ret;
        }

        #endregion

        #region Normalize
        /// <summary>
        /// Normalizes the norm or value range of an array.
        /// </summary>
        /// <param name="src">Source image.</param>
        /// <param name="dst">Destination image.</param>
        /// <param name="alpha">Norm value to normalize to or the lower range boundary in case of the range normalization.</param>
        /// <param name="beta">Upper range boundary in case of the range normalization; it is not used for the norm normalization.</param>
        /// <param name="normType">Normalization type (NormTypes.MinMax, NormTypes.L2, etc).</param>
        /// <param name="dtype">When negative, the output array has the same type as src; otherwise, it has the same number of channels as src and the depth =CV_MAT_DEPTH(dtype).</param>
        /// <param name="mask">Optional operation mask.</param>
        /// <param name="stream">Stream for the asynchronous version.</param>
        public static void Normalize( OpenCvSharp.Cuda.InputArray src, OpenCvSharp.Cuda.OutputArray dst, 
            double alpha, double beta, NormTypes normType, int dtype = -1, OpenCvSharp.Cuda.InputArray? mask = null, OpenCvSharp.Cuda.Stream? stream = null)
        {
            if (src is null) 
                throw new ArgumentNullException(nameof(src));
            if (dst is null) 
                throw new ArgumentNullException(nameof(dst));

            src.ThrowIfDisposed();
            dst.ThrowIfNotReady();

            NativeMethods.HandleException(
                NativeMethods.cuda_normalize(
                    src.CvPtr, dst.CvPtr, alpha, beta, (int)normType, dtype, ToPtr(mask), ToPtr(stream)));
            GC.KeepAlive(src); 
            GC.KeepAlive(mask);
            dst.Fix();
        }

        #endregion

        #region Phase

        /// <summary>
        /// Computes polar angles of complex matrix elements.
        /// </summary>
        public static void Phase(OpenCvSharp.Cuda.InputArray x, OpenCvSharp.Cuda.InputArray y, OpenCvSharp.Cuda.OutputArray angle,
            bool angleInDegrees = false,
            OpenCvSharp.Cuda.Stream? stream = null)
        {
            if (x is null) 
                throw new ArgumentNullException(nameof(x));
            if (y is null) 
                throw new ArgumentNullException(nameof(y));
            if (angle is null) 
                throw new ArgumentNullException(nameof(angle));

            x.ThrowIfDisposed();
            y.ThrowIfDisposed();
            angle.ThrowIfNotReady();

            NativeMethods.HandleException(
                NativeMethods.cuda_phase(
                    x.CvPtr, y.CvPtr, angle.CvPtr,
                    angleInDegrees ? 1 : 0,
                   ToPtr(stream)));

            GC.KeepAlive(x);
            GC.KeepAlive(y);
            angle.Fix();
        }

        /// <summary>
        /// Computes polar angles of complex matrix elements.
        /// </summary>
        /// <param name="xy">Source interleaved Cartesian coordinates (CV_32FC2 or CV_64FC2).</param>
        /// <param name="angle">Destination single-channel angles matrix.</param>
        /// <param name="angleInDegrees">If true, output angles are in degrees, otherwise in radians.</param>
        /// <param name="stream">Stream for the asynchronous version.</param>
        public static void Phase( OpenCvSharp.Cuda.InputArray xy, OpenCvSharp.Cuda.OutputArray angle,
            bool angleInDegrees = false,
            OpenCvSharp.Cuda.Stream? stream = null)
        {
            if (xy is null) throw new ArgumentNullException(nameof(xy));
            if (angle is null) throw new ArgumentNullException(nameof(angle));

            xy.ThrowIfDisposed();
            angle.ThrowIfNotReady();

            NativeMethods.HandleException(
                NativeMethods.cuda_phase_xy(xy.CvPtr, angle.CvPtr, angleInDegrees ? 1 : 0, ToPtr(stream)));

            angle.Fix();
            GC.KeepAlive(xy);
        }


        #endregion

        #region PolarToCart

        /// <summary>
        /// Converts polar coordinates into Cartesian (Separate In, Separate Out).
        /// </summary>
        public static void PolarToCart(
            OpenCvSharp.Cuda.InputArray magnitude, OpenCvSharp.Cuda.InputArray angle,
            OpenCvSharp.Cuda.OutputArray x, OpenCvSharp.Cuda.OutputArray y,
            bool angleInDegrees = false, OpenCvSharp.Cuda.Stream? stream = null)
        {
            if (magnitude is null) 
                throw new ArgumentNullException(nameof(magnitude));
            if (angle is null) 
                throw new ArgumentNullException(nameof(angle));
            if (x is null) 
                throw new ArgumentNullException(nameof(x));
            if (y is null) 
                throw new ArgumentNullException(nameof(y));

            magnitude.ThrowIfDisposed();
            angle.ThrowIfDisposed();
            x.ThrowIfNotReady();
            y.ThrowIfNotReady();

            NativeMethods.HandleException(
                NativeMethods.cuda_polarToCart(magnitude.CvPtr, angle.CvPtr, x.CvPtr, y.CvPtr, angleInDegrees ? 1 : 0, ToPtr(stream)));

            x.Fix(); 
            y.Fix();
            GC.KeepAlive(magnitude); 
            GC.KeepAlive(angle);
        }

        /// <summary>
        /// Converts polar coordinates into Cartesian (Separate In, Interleaved Out).
        /// </summary>
        public static void PolarToCart(
            OpenCvSharp.Cuda.InputArray magnitude, OpenCvSharp.Cuda.InputArray angle,
            OpenCvSharp.Cuda.OutputArray xy, bool angleInDegrees = false, OpenCvSharp.Cuda.Stream? stream = null)
        {
            if (magnitude is null) 
                throw new ArgumentNullException(nameof(magnitude));
            if (angle is null) 
                throw new ArgumentNullException(nameof(angle));
            if (xy is null) 
                throw new ArgumentNullException(nameof(xy));

            magnitude.ThrowIfDisposed();
            angle.ThrowIfDisposed();
            xy.ThrowIfNotReady();

            NativeMethods.HandleException(
                NativeMethods.cuda_polarToCart_interleaved_out(magnitude.CvPtr, angle.CvPtr, xy.CvPtr, angleInDegrees ? 1 : 0, ToPtr(stream)));

            xy.Fix();
            GC.KeepAlive(magnitude); 
            GC.KeepAlive(angle);
        }

        /// <summary>
        /// Converts polar coordinates into Cartesian (Interleaved In, Interleaved Out).
        /// </summary>
        public static void PolarToCart(
            OpenCvSharp.Cuda.InputArray magnitudeAngle, OpenCvSharp.Cuda.OutputArray xy,
            bool angleInDegrees = false, OpenCvSharp.Cuda.Stream? stream = null)
        {
            if (magnitudeAngle is null) throw new ArgumentNullException(nameof(magnitudeAngle));
            if (xy is null) throw new ArgumentNullException(nameof(xy));

            magnitudeAngle.ThrowIfDisposed();
            xy.ThrowIfNotReady();

            NativeMethods.HandleException(
                NativeMethods.cuda_polarToCart_interleaved_inout(magnitudeAngle.CvPtr, xy.CvPtr, angleInDegrees ? 1 : 0, ToPtr(stream)));

            xy.Fix();
            GC.KeepAlive(magnitudeAngle);
        }


        #endregion

        #region Pow
        /// <summary>
        /// Raises every matrix element to a power.
        /// </summary>
        public static void Pow(OpenCvSharp.Cuda.InputArray src, double power, OpenCvSharp.Cuda.OutputArray dst, OpenCvSharp.Cuda.Stream? stream = null)
        {
            if (src is null) 
                throw new ArgumentNullException(nameof(src));
            if (dst is null) 
                throw new ArgumentNullException(nameof(dst));
            src.ThrowIfDisposed();
            dst.ThrowIfNotReady();

            NativeMethods.HandleException(
                NativeMethods.cuda_pow(
                    src.CvPtr, power, dst.CvPtr, ToPtr(stream)));

            GC.KeepAlive(src);
            dst.Fix();
        }

        #endregion

        #region RectStdDev
        /// <summary>
        /// Computes a standard deviation of integral images.
        /// </summary>
        /// <param name="src">Integral image (sum). CV_32S or CV_32F.</param>
        /// <param name="sqr">Squared integral image (sqsum). CV_64F.</param>
        /// <param name="dst">Destination image. CV_32F.</param>
        /// <param name="rect">Rectangle window size.</param>
        /// <param name="stream">Stream for the asynchronous version.</param>
        public static void RectStdDev(OpenCvSharp.Cuda.InputArray src, OpenCvSharp.Cuda.InputArray sqr, OpenCvSharp.Cuda.OutputArray dst, Rect rect, OpenCvSharp.Cuda.Stream? stream = null)
        {
            if (src is null) 
                throw new ArgumentNullException(nameof(src));
            if (sqr is null) 
                throw new ArgumentNullException(nameof(sqr));
            if (dst is null) 
                throw new ArgumentNullException(nameof(dst));

            src.ThrowIfDisposed();
            sqr.ThrowIfDisposed();
            dst.ThrowIfNotReady();

            NativeMethods.HandleException(
                NativeMethods.cuda_rectStdDev(src.CvPtr, sqr.CvPtr, dst.CvPtr, rect, ToPtr(stream)));
           
            GC.KeepAlive(src);
            GC.KeepAlive(sqr);
            dst.Fix();
        }

        #endregion

        #region Reduce

        /// <summary>
        /// Reduces a matrix to a vector.
        /// </summary>
        /// <param name="mtx">Source 2D matrix.</param>
        /// <param name="vec">Destination vector. Its size and type is defined by dim and dtype parameters.</param>
        /// <param name="dim">Dimension index along which the matrix is reduced. 0 means that the matrix is reduced to a single row. 1 means that the matrix is reduced to a single column.</param>
        /// <param name="reduceOp">Reduction operation (ReduceTypes.Sum, ReduceTypes.Avg, etc.).</param>
        /// <param name="dtype">When it is negative, the destination vector will have the same type as the source matrix.</param>
        /// <param name="stream">Stream for the asynchronous version.</param>
        public static void Reduce(OpenCvSharp.Cuda.InputArray mtx, OpenCvSharp.Cuda.OutputArray vec,
            int dim, ReduceTypes reduceOp, int dtype = -1, OpenCvSharp.Cuda.Stream? stream = null)
        {
            if (mtx is null) 
                throw new ArgumentNullException(nameof(mtx));
            if (vec is null) 
                throw new ArgumentNullException(nameof(vec));

            mtx.ThrowIfDisposed();
            vec.ThrowIfNotReady();

            NativeMethods.HandleException(
                NativeMethods.cuda_reduce(mtx.CvPtr, vec.CvPtr, dim, (int)reduceOp, dtype, ToPtr(stream)));

            GC.KeepAlive(mtx);
            vec.Fix();
            
        }
        #endregion

        #region RShift

        /// <summary>
        /// Performs pixel-by-pixel right shift of an image by a constant value.
        /// </summary>
        public static void Rshift(OpenCvSharp.Cuda.InputArray src, Scalar val, OpenCvSharp.Cuda.OutputArray dst,  OpenCvSharp.Cuda.Stream? stream = null)
        {
            if (src is null) 
                throw new ArgumentNullException(nameof(src));
            if (dst is null) 
                throw new ArgumentNullException(nameof(dst));

            src.ThrowIfDisposed();
            dst.ThrowIfNotReady();

            NativeMethods.HandleException(
                NativeMethods.cuda_rshift(
                    src.CvPtr, val, dst.CvPtr, ToPtr(stream)));
            GC.KeepAlive(src);
            dst.Fix();
        }

        #endregion

        #region ScaleAdd
        /// <summary>
        /// Adds a scaled array to another one: dst = alpha * src1 + src2.
        /// </summary>
        public static void ScaleAdd(OpenCvSharp.Cuda.InputArray src1, double alpha, OpenCvSharp.Cuda.InputArray src2, OpenCvSharp.Cuda.OutputArray dst, 
            OpenCvSharp.Cuda.Stream? stream = null)
        {
            if (src1 is null) 
                throw new ArgumentNullException(nameof(src1));
            if (src2 is null) 
                throw new ArgumentNullException(nameof(src2));
            if (dst is null) 
                throw new ArgumentNullException(nameof(dst));

            src1.ThrowIfDisposed();
            src2.ThrowIfDisposed();
            dst.ThrowIfNotReady();

            NativeMethods.HandleException(
                NativeMethods.cuda_scaleAdd(
                    src1.CvPtr, alpha, src2.CvPtr, dst.CvPtr,
                   ToPtr(stream)));

            GC.KeepAlive(src1);
            GC.KeepAlive(src2);
            dst.Fix();
        }
        #endregion

        #region Split


        /// <summary>
        /// Copies each plane of a multi-channel matrix into an array.
        /// </summary>
        /// <param name="src">Source multi-channel image.</param>
        /// <param name="dst">Destination array of single-channel matrices. Array length must match src.Channels().</param>
        /// <param name="stream">Stream for the asynchronous version.</param>
        public static void Split(
            OpenCvSharp.Cuda.InputArray src, GpuMat[] dst, OpenCvSharp.Cuda.Stream? stream = null)
        {
            if (src is null) 
                throw new ArgumentNullException(nameof(src));
            if (dst is null) 
                throw new ArgumentNullException(nameof(dst));

            src.ThrowIfDisposed();
            int channels = src.Channels();

            if (dst.Length != channels)
                throw new ArgumentException("The number of destination matrices must match the number of source channels.");

            IntPtr[] ptrs = new IntPtr[channels];
            for (int i = 0; i < channels; i++)
            {
                if (dst[i] == null) dst[i] = new GpuMat();
                dst[i].ThrowIfDisposed();
                ptrs[i] = dst[i].CvPtr;
            }

            NativeMethods.HandleException(
                NativeMethods.cuda_split(src.CvPtr, ptrs, ToPtr(stream)));

            GC.KeepAlive(src);
            foreach (var m in dst) GC.KeepAlive(m);
        }

        #endregion

        #region Sqr

        /// <summary>
        /// Computes a square value of each matrix element.
        /// </summary>
        public static void Sqr(OpenCvSharp.Cuda.InputArray src, OpenCvSharp.Cuda.OutputArray dst, OpenCvSharp.Cuda.Stream? stream = null)
        {
            if (src is null) 
                throw new ArgumentNullException(nameof(src));
            if (dst is null) 
                throw new ArgumentNullException(nameof(dst));
            src.ThrowIfDisposed();
            dst.ThrowIfNotReady();

            NativeMethods.HandleException(
                NativeMethods.cuda_sqr(
                    src.CvPtr, dst.CvPtr, ToPtr(stream)));

            GC.KeepAlive(src);
            dst.Fix();
        }

        #endregion

        #region SqrIntegral

        /// <summary>
        /// Computes a squared integral image.
        /// </summary>
        /// <param name="src">Source image.</param>
        /// <param name="sqsum">Squared integral image, (W+1)x(H+1), CV_64F.</param>
        /// <param name="stream">Stream for the asynchronous version.</param>
        public static void SqrIntegral(OpenCvSharp.Cuda.InputArray src, OpenCvSharp.Cuda.OutputArray sqsum, OpenCvSharp.Cuda.Stream? stream = null)
        {
            if (src is null) 
                throw new ArgumentNullException(nameof(src));
            if (sqsum is null) 
                throw new ArgumentNullException(nameof(sqsum));

            src.ThrowIfDisposed();
            sqsum.ThrowIfNotReady();

            NativeMethods.HandleException(
                NativeMethods.cuda_sqrIntegral(src.CvPtr, sqsum.CvPtr, ToPtr(stream)));
            
            GC.KeepAlive(src);
            sqsum.Fix();
           
        }

        #endregion

        #region SqrSum

        /// <summary>
        /// Returns the squared sum of matrix elements.
        /// </summary>
        /// <param name="src">Source image.</param>
        /// <param name="mask">Optional mask.</param>
        /// <returns>Scalar containing the squared sum of each channel.</returns>
        public static Scalar SqrSum(OpenCvSharp.Cuda.InputArray src, OpenCvSharp.Cuda.InputArray? mask = null)
        {
            if (src is null) 
                throw new ArgumentNullException(nameof(src));
            src.ThrowIfDisposed();

         

            NativeMethods.HandleException(
                NativeMethods.cuda_sqrSum(src.CvPtr, ToPtr(mask), out Scalar ret));

            GC.KeepAlive(src);
            GC.KeepAlive(mask);
            return ret;
        }

        #endregion

        #region Sqrt

        /// <summary>
        /// Computes a square root of each matrix element.
        /// </summary>
        public static void Sqrt(OpenCvSharp.Cuda.InputArray src, OpenCvSharp.Cuda.OutputArray dst,  OpenCvSharp.Cuda.Stream? stream = null)
        {
            if (src is null)
                throw new ArgumentNullException(nameof(src));
            if (dst is null) 
                throw new ArgumentNullException(nameof(dst));
            src.ThrowIfDisposed();
            dst.ThrowIfNotReady();

            NativeMethods.HandleException(
                NativeMethods.cuda_sqrt(
                    src.CvPtr, dst.CvPtr, ToPtr(stream)));
            GC.KeepAlive(src);
            dst.Fix();
        }

        #endregion

        #region Substract

        /// <summary>
        /// Computes a matrix-matrix or matrix-scalar difference.
        /// </summary>
        public static void Subtract(OpenCvSharp.Cuda.InputArray src1, OpenCvSharp.Cuda.InputArray src2,
            OpenCvSharp.Cuda.OutputArray dst,
            OpenCvSharp.Cuda.InputArray? mask = null,
            int dtype = -1,
            OpenCvSharp.Cuda.Stream? stream = null)
        {
            if (src1 is null) throw new ArgumentNullException(nameof(src1));
            if (src2 is null) throw new ArgumentNullException(nameof(src2));
            if (dst is null) throw new ArgumentNullException(nameof(dst));
            src1.ThrowIfDisposed();
            src2.ThrowIfDisposed();
            dst.ThrowIfNotReady();

            NativeMethods.HandleException(
                NativeMethods.cuda_subtract(
                    src1.CvPtr, src2.CvPtr, dst.CvPtr,
                    mask?.CvPtr ?? IntPtr.Zero, dtype,
                   ToPtr(stream)));

            dst.Fix();
        }

        public static void Subtract(OpenCvSharp.Cuda.InputArray src1, Scalar src2, OpenCvSharp.Cuda.OutputArray dst, OpenCvSharp.Cuda.InputArray? mask = null, int dtype = -1, OpenCvSharp.Cuda.Stream? stream = null)
        {
            if (src1 is null) 
                throw new ArgumentNullException(nameof(src1));
            if (dst is null) 
                throw new ArgumentNullException(nameof(dst));

            src1.ThrowIfDisposed();
            dst.ThrowIfNotReady();

            NativeMethods.HandleException(
                NativeMethods.cuda_subtract_scalar(src1.CvPtr, src2, dst.CvPtr, ToPtr(mask), dtype, ToPtr(stream)));

            
            GC.KeepAlive(src1);
            GC.KeepAlive(mask);
            dst.Fix();
        }

        #endregion

        #region Sum
        /// <summary>
        /// Returns the sum of matrix elements.
        /// </summary>
        /// <param name="src">Source image.</param>
        /// <param name="mask">Optional operation mask.</param>
        /// <returns>The sum of elements per channel.</returns>
        public static Scalar Sum(OpenCvSharp.Cuda.InputArray src, OpenCvSharp.Cuda.InputArray? mask = null)
        {
            if (src is null) 
                throw new ArgumentNullException(nameof(src));
            src.ThrowIfDisposed();

            NativeMethods.HandleException(
                NativeMethods.cuda_sum(src.CvPtr, ToPtr(mask), out var ret));

            GC.KeepAlive(src);
            GC.KeepAlive(mask);
            return ret;
        }

        #endregion

        #region Threshold

        /// <summary>
        /// Applies a fixed-level threshold to each array element.
        /// Returns the computed threshold value (relevant for Otsu / Triangle).
        /// </summary>
        public static double Threshold(OpenCvSharp.Cuda.InputArray src, OpenCvSharp.Cuda.OutputArray dst, double thresh, double maxval, ThresholdTypes type, OpenCvSharp.Cuda.Stream? stream = null)
        {
            if (src is null) 
                throw new ArgumentNullException(nameof(src));
            if (dst is null) 
                throw new ArgumentNullException(nameof(dst));

            src.ThrowIfDisposed();
            dst.ThrowIfNotReady();

            NativeMethods.HandleException(
                NativeMethods.cuda_threshold(
                    src.CvPtr, dst.CvPtr,
                    thresh, maxval, (int)type,
                   ToPtr(stream),
                    out double retVal));

            GC.KeepAlive(src);
            dst.Fix();
            return retVal;
        }

        #endregion

        #region Transpose

        /// <summary>
        /// Transposes a matrix.
        /// </summary>
        /// <param name="src">Source matrix.</param>
        /// <param name="dst">Destination matrix. Will have Size(src.rows, src.cols) and the same type as src.</param>
        /// <param name="stream">Stream for the asynchronous version.</param>
        public static void Transpose(OpenCvSharp.Cuda.InputArray src, OpenCvSharp.Cuda.OutputArray dst, OpenCvSharp.Cuda.Stream? stream = null)
        {
            if (src is null)
                throw new ArgumentNullException(nameof(src));
            if (dst is null)
                throw new ArgumentNullException(nameof(dst));

            src.ThrowIfDisposed();
            dst.ThrowIfNotReady();

            NativeMethods.HandleException(
                NativeMethods.cuda_transpose(src.CvPtr, dst.CvPtr, ToPtr(stream)));

            GC.KeepAlive(src);
            dst.Fix();
        }

        #endregion

    }
}
