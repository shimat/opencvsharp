using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using OpenCvSharp.Util;

namespace OpenCvSharp
{
    /// <summary>
    /// Raster image moments
    /// </summary>
    public class Moments
    {
        /// <summary>
        /// spatial moments
        /// </summary>
        public double M00, M10, M01, M20, M11, M02, M30, M21, M12, M03;

        /// <summary>
        /// central moments
        /// </summary>
        public double Mu20, Mu11, Mu02, Mu30, Mu21, Mu12, Mu03;

        /// <summary>
        /// central normalized moments
        /// </summary>
        public double Nu20, Nu11, Nu02, Nu30, Nu21, Nu12, Nu03;

        #region Init & Disposal
        /// <summary>
        /// Default constructor.
        /// All moment values are set to 0.
        /// </summary>
        public Moments()
        {
            M00 = M10 = M01 = M20 = M11 = M02 = M30 = M21 = M12 = M03 =
            Mu20 = Mu11 = Mu02 = Mu30 = Mu21 = Mu12 = Mu03 =
            Nu20 = Nu11 = Nu02 = Nu30 = Nu21 = Nu12 = Nu03 = 0.0;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="m00"></param>
        /// <param name="m10"></param>
        /// <param name="m01"></param>
        /// <param name="m20"></param>
        /// <param name="m11"></param>
        /// <param name="m02"></param>
        /// <param name="m30"></param>
        /// <param name="m21"></param>
        /// <param name="m12"></param>
        /// <param name="m03"></param>
        public Moments(double m00, double m10, double m01, double m20, double m11,
                       double m02, double m30, double m21, double m12, double m03)
        {
            Initialize(m00, m10, m01, m20, m11, m02, m30, m21, m12, m03);
        }

        /// <summary>
        /// Calculates all of the moments 
        /// up to the third order of a polygon or rasterized shape.
        /// </summary>
        /// <param name="array">A raster image (single-channel, 8-bit or floating-point 
        /// 2D array) or an array ( 1xN or Nx1 ) of 2D points ( Point or Point2f )</param>
        /// <param name="binaryImage">If it is true, then all the non-zero image pixels are treated as 1’s</param>
        /// <returns></returns>
        public Moments(InputArray array, bool binaryImage = false)
        {
            if (array == null)
                throw new ArgumentNullException(nameof(array));
            array.ThrowIfDisposed();
            InitializeFromInputArray(array, binaryImage);
        }

        /// <summary>
        /// Calculates all of the moments 
        /// up to the third order of a polygon or rasterized shape.
        /// </summary>
        /// <param name="array">A raster image (8-bit) 2D array</param>
        /// <param name="binaryImage">If it is true, then all the non-zero image pixels are treated as 1’s</param>
        /// <returns></returns>
        public Moments(byte[,] array, bool binaryImage = false)
        {
            if (array == null)
                throw new ArgumentNullException(nameof(array));
            int rows = array.GetLength(0);
            int cols = array.GetLength(1);
            using (var arrayMat = new Mat(rows, cols, MatType.CV_8UC1, array))
            {
                InitializeFromInputArray(arrayMat, binaryImage);
            }
        }

        /// <summary>
        /// Calculates all of the moments 
        /// up to the third order of a polygon or rasterized shape.
        /// </summary>
        /// <param name="array">A raster image (floating-point) 2D array</param>
        /// <param name="binaryImage">If it is true, then all the non-zero image pixels are treated as 1’s</param>
        /// <returns></returns>
        public Moments(float[,] array, bool binaryImage = false)
        {
            if (array == null)
                throw new ArgumentNullException(nameof(array));
            int rows = array.GetLength(0);
            int cols = array.GetLength(1);
            using (var arrayMat = new Mat(rows, cols, MatType.CV_32FC1, array))
            {
                InitializeFromInputArray(arrayMat, binaryImage);
            }
        }

        /// <summary>
        /// Calculates all of the moments 
        /// up to the third order of a polygon or rasterized shape.
        /// </summary>
        /// <param name="array">Array of 2D points</param>
        /// <param name="binaryImage">If it is true, then all the non-zero image pixels are treated as 1’s</param>
        /// <returns></returns>
        public Moments(IEnumerable<Point> array, bool binaryImage = false)
        {
            if (array == null)
                throw new ArgumentNullException(nameof(array));
            Point[] points = EnumerableEx.ToArray(array);
            using (var pointsMat = new Mat(points.Length, 1, MatType.CV_32SC2, points))
            {
                InitializeFromInputArray(pointsMat, binaryImage);
            }
        }

        /// <summary>
        /// Calculates all of the moments 
        /// up to the third order of a polygon or rasterized shape.
        /// </summary>
        /// <param name="array">Array of 2D points</param>
        /// <param name="binaryImage">If it is true, then all the non-zero image pixels are treated as 1’s</param>
        /// <returns></returns>
        public Moments(IEnumerable<Point2f> array, bool binaryImage = false)
        {
            if (array == null)
                throw new ArgumentNullException(nameof(array));
            Point2f[] points = EnumerableEx.ToArray(array);
            using (var pointsMat = new Mat(points.Length, 1, MatType.CV_32FC2, points))
            {
                InitializeFromInputArray(pointsMat, binaryImage);
            }
        }

        /// <summary>
        /// Calculates all of the moments 
        /// up to the third order of a polygon or rasterized shape.
        /// </summary>
        /// <param name="array">A raster image (single-channel, 8-bit or floating-point 
        /// 2D array) or an array ( 1xN or Nx1 ) of 2D points ( Point or Point2f )</param>
        /// <param name="binaryImage">If it is true, then all the non-zero image pixels are treated as 1’s</param>
        /// <returns></returns>
        private void InitializeFromInputArray(InputArray array, bool binaryImage)
        {
            var m = NativeMethods.imgproc_moments(array.CvPtr, binaryImage ? 1 : 0);
            GC.KeepAlive(array);
            Initialize(m.m00, m.m10, m.m01, m.m20, m.m11, m.m02, m.m30, m.m21, m.m12, m.m03);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="m00"></param>
        /// <param name="m10"></param>
        /// <param name="m01"></param>
        /// <param name="m20"></param>
        /// <param name="m11"></param>
        /// <param name="m02"></param>
        /// <param name="m30"></param>
        /// <param name="m21"></param>
        /// <param name="m12"></param>
        /// <param name="m03"></param>
        private void Initialize(double m00, double m10, double m01, double m20, double m11,
                       double m02, double m30, double m21, double m12, double m03)
        {
            M00 = m00;
            M10 = m10;
            M01 = m01;
            M20 = m20;
            M11 = m11;
            M02 = m02;
            M30 = m30;
            M21 = m21;
            M12 = m12;
            M03 = m03;

            double cx = 0, cy = 0, invM00 = 0;
            if (Math.Abs(M00) > double.Epsilon)
            {
                invM00 = 1.0 / M00;
                cx = M10 * invM00;
                cy = M01 * invM00;
            }

            Mu20 = M20 - M10 * cx;
            Mu11 = M11 - M10 * cy;
            Mu02 = M02 - M01 * cy;

            Mu30 = M30 - cx * (3 * Mu20 + cx * M10);
            Mu21 = M21 - cx * (2 * Mu11 + cx * M01) - cy * Mu20;
            Mu12 = M12 - cy * (2 * Mu11 + cy * M10) - cx * Mu02;
            Mu03 = M03 - cy * (3 * Mu02 + cy * M01);

            double invSqrtM00 = Math.Sqrt(Math.Abs(invM00));
            double s2 = invM00 * invM00;
            double s3 = s2 * invSqrtM00;

            Nu20 = Mu20 * s2;
            Nu11 = Mu11 * s2;
            Nu02 = Mu02 * s2;
            Nu30 = Mu30 * s3;
            Nu21 = Mu21 * s3;
            Nu12 = Mu12 * s3;
            Nu03 = Mu03 * s3;
        }

        #endregion

        #region Methods
        /// <summary>
        /// computes 7 Hu invariants from the moments
        /// </summary>
        /// <returns></returns>
        public double[] HuMoments()
        {
            double[] hu = new double[7];
            double t0 = Nu30 + Nu12;
            double t1 = Nu21 + Nu03;

            double q0 = t0 * t0, q1 = t1 * t1;

            double n4 = 4 * Nu11;
            double s = Nu20 + Nu02;
            double d = Nu20 - Nu02;

            hu[0] = s;
            hu[1] = d * d + n4 * Nu11;
            hu[3] = q0 + q1;
            hu[5] = d * (q0 - q1) + n4 * t0 * t1;

            t0 *= q0 - 3 * q1;
            t1 *= 3 * q0 - q1;

            q0 = Nu30 - 3 * Nu12;
            q1 = 3 * Nu21 - Nu03;

            hu[2] = q0 * q0 + q1 * q1;
            hu[4] = q0 * t0 + q1 * t1;
            hu[6] = q1 * t0 - q0 * t1;
            return hu;
        }

        #endregion

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
#pragma warning disable 1591
        public struct NativeStruct
        {
            public double m00, m10, m01, m20, m11, m02, m30, m21, m12, m03; /* spatial moments */
            public double mu20, mu11, mu02, mu30, mu21, mu12, mu03; /* central moments */
            public double inv_sqrt_m00; /* m00 != 0 ? 1/sqrt(m00) : 0 */
        }
    }
}
