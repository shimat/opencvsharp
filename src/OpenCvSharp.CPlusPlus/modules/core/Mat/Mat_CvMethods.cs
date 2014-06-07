using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;

namespace OpenCvSharp.CPlusPlus
{
    partial class Mat
    {
        #region core
        
        /// <summary>
        /// Computes absolute value of each matrix element
        /// </summary>
        /// <returns></returns>
        public MatExpr Abs()
        {
            return Cv2.Abs(this);
        }

#if LANG_JP
    /// <summary>
    /// スケーリング後，絶対値を計算し，結果を結果を 8 ビットに変換します．
    /// </summary>
    /// <param name="alpha">オプションのスケールファクタ. [既定値は1]</param>
    /// <param name="beta">スケーリングされた値に加えられるオプション値. [既定値は0]</param>
    /// <returns></returns>
#else
        /// <summary>
        /// Scales, computes absolute values and converts the result to 8-bit.
        /// </summary>
        /// <param name="alpha">The optional scale factor. [By default this is 1]</param>
        /// <param name="beta">The optional delta added to the scaled values. [By default this is 0]</param>
        /// <returns></returns>
#endif
        public Mat ConvertScaleAbs(double alpha = 1, double beta = 0)
        {
            var dst = new Mat();
            Cv2.ConvertScaleAbs(this, dst, alpha, beta);
            return dst;
        }

        /// <summary>
        /// transforms array of numbers using a lookup table: dst(i)=lut(src(i))
        /// </summary>
        /// <param name="lut">Look-up table of 256 elements. 
        /// In the case of multi-channel source array, the table should either have 
        /// a single channel (in this case the same table is used for all channels)
        ///  or the same number of channels as in the source array</param>
        /// <param name="interpolation"></param>
        /// <returns></returns>
        public Mat LUT(InputArray lut, int interpolation = 0)
        {
            var dst = new Mat();
            Cv2.LUT(this, lut, dst, interpolation);
            return dst;
        }

        /// <summary>
        /// transforms array of numbers using a lookup table: dst(i)=lut(src(i))
        /// </summary>
        /// <param name="lut">Look-up table of 256 elements. 
        /// In the case of multi-channel source array, the table should either have 
        /// a single channel (in this case the same table is used for all channels)
        ///  or the same number of channels as in the source array</param>
        /// <param name="interpolation"></param>
        /// <returns></returns>
        public Mat LUT(byte[] lut, int interpolation = 0)
        {
            var dst = new Mat();
            Cv2.LUT(this, lut, dst, interpolation);
            return dst;
        }

        /// <summary>
        /// computes sum of array elements
        /// </summary>
        /// <returns></returns>
        public Scalar Sum()
        {
            return Cv2.Sum(this);
        }
        
        /// <summary>
        /// computes the number of nonzero array elements
        /// </summary>
        /// <returns>number of non-zero elements in mtx</returns>
        public int CountNonZero()
        {
            return Cv2.CountNonZero(this);
        }

        /// <summary>
        /// returns the list of locations of non-zero pixels
        /// </summary>
        /// <returns></returns>
        public Mat FindNonZero()
        {
            var idx = new Mat();
            Cv2.FindNonZero(this, idx);
            return idx;
        }

        /// <summary>
        /// computes mean value of selected array elements
        /// </summary>
        /// <param name="mask">The optional operation mask</param>
        /// <returns></returns>
        public Scalar Mean(InputArray mask = null)
        {
            return Cv2.Mean(this, mask);
        }

        /// <summary>
        /// computes mean value and standard deviation of all or selected array elements
        /// </summary>
        /// <param name="mean">The output parameter: computed mean value</param>
        /// <param name="stddev">The output parameter: computed standard deviation</param>
        /// <param name="mask">The optional operation mask</param>
        public void MeanStdDev(OutputArray mean, OutputArray stddev, InputArray mask = null)
        {
            Cv2.MeanStdDev(this, mean, stddev, mask);
        }

        /// <summary>
        /// computes norm of the selected array part
        /// </summary>
        /// <param name="normType">Type of the norm</param>
        /// <param name="mask">The optional operation mask</param>
        /// <returns></returns>
        public double Norm(NormType normType = NormType.L2, InputArray mask = null)
        {
            return Cv2.Norm(this, normType, mask);
        }

        /// <summary>
        /// scales and shifts array elements so that either the specified norm (alpha) 
        /// or the minimum (alpha) and maximum (beta) array values get the specified values
        /// </summary>
        /// <param name="alpha">The norm value to normalize to or the lower range boundary 
        /// in the case of range normalization</param>
        /// <param name="beta">The upper range boundary in the case of range normalization; 
        /// not used for norm normalization</param>
        /// <param name="normType">The normalization type</param>
        /// <param name="dtype">When the parameter is negative, 
        /// the destination array will have the same type as src, 
        /// otherwise it will have the same number of channels as src and the depth =CV_MAT_DEPTH(rtype)</param>
        /// <param name="mask">The optional operation mask</param>
        /// <returns></returns>
        public Mat Normalize(double alpha = 1, double beta = 0,
            NormType normType = NormType.L2, int dtype = -1, InputArray mask = null)
        {
            var dst = new Mat();
            Cv2.Normalize(this, dst, alpha, beta, normType, dtype, mask);
            return dst;
        }

        /// <summary>
        /// finds global minimum and maximum array elements and returns their values and their locations
        /// </summary>
        /// <param name="minVal">Pointer to returned minimum value</param>
        /// <param name="maxVal">Pointer to returned maximum value</param>
        public void MinMaxLoc(out double minVal, out double maxVal)
        {
            Cv2.MinMaxLoc(this, out minVal, out maxVal);
        }

        /// <summary>
        /// finds global minimum and maximum array elements and returns their values and their locations
        /// </summary>
        /// <param name="minLoc">Pointer to returned minimum location</param>
        /// <param name="maxLoc">Pointer to returned maximum location</param>
        public void MinMaxLoc(out Point minLoc, out Point maxLoc)
        {
            Cv2.MinMaxLoc(this, out minLoc, out maxLoc);
        }

        /// <summary>
        /// finds global minimum and maximum array elements and returns their values and their locations
        /// </summary>
        /// <param name="minVal">Pointer to returned minimum value</param>
        /// <param name="maxVal">Pointer to returned maximum value</param>
        /// <param name="minLoc">Pointer to returned minimum location</param>
        /// <param name="maxLoc">Pointer to returned maximum location</param>
        /// <param name="mask">The optional mask used to select a sub-array</param>
        public void MinMaxLoc(out double minVal, out double maxVal,
            out Point minLoc, out Point maxLoc, InputArray mask = null)
        {
            Cv2.MinMaxLoc(this, out minVal, out maxVal, out minLoc, out maxLoc, mask);
        }

        /// <summary>
        /// finds global minimum and maximum array elements and returns their values and their locations
        /// </summary>
        /// <param name="minVal">Pointer to returned minimum value</param>
        /// <param name="maxVal">Pointer to returned maximum value</param>
        public void MinMaxIdx(out double minVal, out double maxVal)
        {
            Cv2.MinMaxIdx(this, out minVal, out maxVal);
        }

        /// <summary>
        /// finds global minimum and maximum array elements and returns their values and their locations
        /// </summary>
        /// <param name="minIdx"></param>
        /// <param name="maxIdx"></param>
        public void MinMaxIdx(out int minIdx, out int maxIdx)
        {
            Cv2.MinMaxIdx(this, out minIdx, out maxIdx);
        }

        /// <summary>
        /// finds global minimum and maximum array elements and returns their values and their locations
        /// </summary>
        /// <param name="minVal">Pointer to returned minimum value</param>
        /// <param name="maxVal">Pointer to returned maximum value</param>
        /// <param name="minIdx"></param>
        /// <param name="maxIdx"></param>
        /// <param name="mask"></param>
        public void MinMaxIdx(out double minVal, out double maxVal,
            out int minIdx, out int maxIdx, InputArray mask = null)
        {
            Cv2.MinMaxIdx(this, out minVal, out maxVal, out minIdx, out maxIdx, mask);
        }

        /// <summary>
        /// transforms 2D matrix to 1D row or column vector by taking sum, minimum, maximum or mean value over all the rows
        /// </summary>
        /// <param name="dim">The dimension index along which the matrix is reduced. 
        /// 0 means that the matrix is reduced to a single row and 1 means that the matrix is reduced to a single column</param>
        /// <param name="rtype"></param>
        /// <param name="dtype">When it is negative, the destination vector will have 
        /// the same type as the source matrix, otherwise, its type will be CV_MAKE_TYPE(CV_MAT_DEPTH(dtype), mtx.channels())</param>
        /// <returns></returns>
        public Mat Reduce(ReduceDimension dim, ReduceOperation rtype, int dtype)
        {
            var dst = new Mat();
            Cv2.Reduce(this, dst, dim, rtype, dtype);
            return dst;
        }

        /// <summary>
        /// Copies each plane of a multi-channel array to a dedicated array
        /// </summary>
        /// <returns>The number of arrays must match mtx.channels() . 
        /// The arrays themselves will be reallocated if needed</returns>
        public Mat[] Split()
        {
            return Cv2.Split(this);
        }

        /// <summary>
        /// extracts a single channel from src (coi is 0-based index)
        /// </summary>
        /// <param name="coi"></param>
        /// <returns></returns>
        public Mat ExtractChannel(int coi)
        {
            var dst = new Mat();
            Cv2.ExtractChannel(this, dst, coi);
            return dst;
        }

        /// <summary>
        /// inserts a single channel to dst (coi is 0-based index)
        /// </summary>
        /// <param name="dst"></param>
        /// <param name="coi"></param>
        public void InsertChannel(InputOutputArray dst, int coi)
        {
            Cv2.InsertChannel(this, dst, coi);
        }

        /// <summary>
        /// reverses the order of the rows, columns or both in a matrix
        /// </summary>
        /// <param name="flipCode">Specifies how to flip the array: 
        /// 0 means flipping around the x-axis, positive (e.g., 1) means flipping around y-axis, 
        /// and negative (e.g., -1) means flipping around both axes. See also the discussion below for the formulas.</param>
        /// <returns>The destination array; will have the same size and same type as src</returns>
        public Mat Flip(FlipMode flipCode)
        {
            var dst = new Mat();
            Cv2.Flip(this, dst, flipCode);
            return dst;
        }

        /// <summary>
        /// replicates the input matrix the specified number of times in the horizontal and/or vertical direction
        /// </summary>
        /// <param name="ny">How many times the src is repeated along the vertical axis</param>
        /// <param name="nx">How many times the src is repeated along the horizontal axis</param>
        /// <returns></returns>
        public Mat Repeat(int ny, int nx)
        {
            var dst = new Mat();
            Cv2.Repeat(this, ny, nx, dst);
            return dst;
        }

        /// <summary>
        /// set mask elements for those array elements which are within the element-specific bounding box (dst = lowerb &lt;= src &amp;&amp; src &lt; upperb)
        /// </summary>
        /// <param name="lowerb">The inclusive lower boundary array of the same size and type as src</param>
        /// <param name="upperb">The exclusive upper boundary array of the same size and type as src</param>
        /// <returns>The destination array, will have the same size as src and CV_8U type</returns>
        public Mat InRange(InputArray lowerb, InputArray upperb)
        {
            var dst = new Mat();
            Cv2.InRange(this, lowerb, upperb, dst);
            return dst;
        }

        /// <summary>
        /// set mask elements for those array elements which are within the element-specific bounding box (dst = lowerb &lt;= src &amp;&amp; src &lt; upperb)
        /// </summary>
        /// <param name="lowerb">The inclusive lower boundary array of the same size and type as src</param>
        /// <param name="upperb">The exclusive upper boundary array of the same size and type as src</param>
        /// <returns>The destination array, will have the same size as src and CV_8U type</returns>
        public Mat InRange(Scalar lowerb, Scalar upperb)
        {
            var dst = new Mat();
            Cv2.InRange(this, lowerb, upperb, dst);
            return dst;
        }

        /// <summary>
        /// computes square root of each matrix element (dst = src**0.5)
        /// </summary>
        /// <returns>The destination array; will have the same size and the same type as src</returns>
        public Mat Sqrt()
        {
            var dst = new Mat();
            Cv2.Sqrt(this, dst);
            return dst;
        }

        /// <summary>
        /// raises the input matrix elements to the specified power (b = a**power)
        /// </summary>
        /// <param name="power">The exponent of power</param>
        /// <returns>The destination array; will have the same size and the same type as src</returns>
        public Mat Pow(double power)
        {
            var dst = new Mat();
            Cv2.Pow(this, power, dst);
            return dst;
        }

        /// <summary>
        /// computes exponent of each matrix element (dst = e**src)
        /// </summary>
        /// <returns>The destination array; will have the same size and same type as src</returns>
        public Mat Exp()
        {
            var dst = new Mat();
            Cv2.Exp(this, dst);
            return dst;
        }

        /// <summary>
        /// computes natural logarithm of absolute value of each matrix element: dst = log(abs(src))
        /// </summary>
        /// <returns>The destination array; will have the same size and same type as src</returns>
        public Mat Log()
        {
            var dst = new Mat();
            Cv2.Log(this, dst);
            return dst;
        }

        /// <summary>
        /// checks that each matrix element is within the specified range.
        /// </summary>
        /// <param name="quiet">The flag indicating whether the functions quietly 
        /// return false when the array elements are out of range, 
        /// or they throw an exception.</param>
        /// <returns></returns>
        public bool CheckRange(bool quiet = true)
        {
            return Cv2.CheckRange(this, quiet);
        }

        /// <summary>
        /// checks that each matrix element is within the specified range.
        /// </summary>
        /// <param name="quiet">The flag indicating whether the functions quietly 
        /// return false when the array elements are out of range, 
        /// or they throw an exception.</param>
        /// <param name="pos">The optional output parameter, where the position of 
        /// the first outlier is stored.</param>
        /// <param name="minVal">The inclusive lower boundary of valid values range</param>
        /// <param name="maxVal">The exclusive upper boundary of valid values range</param>
        /// <returns></returns>
        public bool CheckRange(bool quiet, out Point pos,
            double minVal = double.MinValue, double maxVal = double.MaxValue)
        {
            return Cv2.CheckRange(this, quiet, out pos, minVal, maxVal);
        }

        /// <summary>
        /// converts NaN's to the given number
        /// </summary>
        /// <param name="val"></param>
        public void PatchNaNs(double val = 0)
        {
            Cv2.PatchNaNs(this, val);
        }

        /// <summary>
        /// multiplies matrix by its transposition from the left or from the right
        /// </summary>
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
        public Mat MulTransposed(bool aTa, InputArray delta = null, double scale = 1, int dtype = -1)
        {
            var dst = new Mat();
            Cv2.MulTransposed(this, dst, aTa, delta, scale, dtype);
            return dst;
        }

        /// <summary>
        /// transposes the matrix
        /// </summary>
        /// <returns>The destination array of the same type as src</returns>
        public Mat Transpose()
        {
            var dst = new Mat();
            Cv2.Transpose(this, dst);
            return dst;
        }

        /// <summary>
        /// performs affine transformation of each element of multi-channel input matrix
        /// </summary>
        /// <param name="m">The transformation matrix</param>
        /// <returns>The destination array; will have the same size and depth as src and as many channels as mtx.rows</returns>
        public Mat Transform(InputArray m)
        {
            var dst = new Mat();
            Cv2.Transform(this, dst, m);
            return dst;
        }

        /// <summary>
        /// performs perspective transformation of each element of multi-channel input matrix
        /// </summary>
        /// <param name="m">3x3 or 4x4 transformation matrix</param>
        /// <returns>The destination array; it will have the same size and same type as src</returns>
        public Mat PerspectiveTransform(InputArray m)
        {
            var dst = new Mat();
            Cv2.PerspectiveTransform(this, dst, m);
            return dst;
        }

        /// <summary>
        /// extends the symmetrical matrix from the lower half or from the upper half
        /// </summary>
        /// <param name="lowerToUpper">If true, the lower half is copied to the upper half, 
        /// otherwise the upper half is copied to the lower half</param>
        public void CompleteSymm(bool lowerToUpper = false)
        {
            Cv2.CompleteSymm(this, lowerToUpper);
        }

        /// <summary>
        /// initializes scaled identity matrix (not necessarily square). 
        /// </summary>
        /// <param name="s">The value to assign to the diagonal elements</param>
        public void SetIdentity(Scalar? s = null)
        {
            Cv2.SetIdentity(this, s);
        }

        /// <summary>
        /// computes determinant of a square matrix.
        /// The input matrix must have CV_32FC1 or CV_64FC1 type and square size.
        /// </summary>
        /// <returns>determinant of the specified matrix.</returns>
        public double Determinant()
        {
            return Cv2.Determinant(this);
        }

        /// <summary>
        /// computes trace of a matrix
        /// </summary>
        /// <returns></returns>
        public Scalar Trace()
        {
            return Cv2.Trace(this);
        }

        /// <summary>
        /// sorts independently each matrix row or each matrix column
        /// </summary>
        /// <param name="flags">The operation flags, a combination of the SortFlag values</param>
        /// <returns>The destination array of the same size and the same type as src</returns>
        public Mat Sort(SortFlag flags)
        {
            var dst = new Mat();
            Cv2.Sort(this, dst, flags);
            return dst;
        }

        /// <summary>
        /// sorts independently each matrix row or each matrix column
        /// </summary>
        /// <param name="flags">The operation flags, a combination of SortFlag values</param>
        /// <returns>The destination integer array of the same size as src</returns>
        public Mat SortIdx(SortFlag flags)
        {
            var dst = new Mat();
            Cv2.SortIdx(this, dst, flags);
            return dst;
        }

        /// <summary>
        /// Performs a forward Discrete Fourier transform of 1D or 2D floating-point array.
        /// </summary>
        /// <param name="flags">Transformation flags, a combination of the DftFlag2 values</param>
        /// <param name="nonzeroRows">When the parameter != 0, the function assumes that 
        /// only the first nonzeroRows rows of the input array ( DFT_INVERSE is not set) 
        /// or only the first nonzeroRows of the output array ( DFT_INVERSE is set) contain non-zeros, 
        /// thus the function can handle the rest of the rows more efficiently and 
        /// thus save some time. This technique is very useful for computing array cross-correlation 
        /// or convolution using DFT</param>
        /// <returns>The destination array, which size and type depends on the flags</returns>
        public Mat Dft(DftFlag2 flags = DftFlag2.None, int nonzeroRows = 0)
        {
            var dst = new Mat();
            Cv2.Dft(this, dst, flags, nonzeroRows);
            return dst;
        }

        /// <summary>
        /// Performs an inverse Discrete Fourier transform of 1D or 2D floating-point array.
        /// </summary>
        /// <param name="flags">Transformation flags, a combination of the DftFlag2 values</param>
        /// <param name="nonzeroRows">When the parameter != 0, the function assumes that 
        /// only the first nonzeroRows rows of the input array ( DFT_INVERSE is not set) 
        /// or only the first nonzeroRows of the output array ( DFT_INVERSE is set) contain non-zeros, 
        /// thus the function can handle the rest of the rows more efficiently and 
        /// thus save some time. This technique is very useful for computing array cross-correlation 
        /// or convolution using DFT</param>
        /// <returns>The destination array, which size and type depends on the flags</returns>
        public Mat Idft(DftFlag2 flags = DftFlag2.None, int nonzeroRows = 0)
        {
            var dst = new Mat();
            Cv2.Idft(this, dst, flags, nonzeroRows);
            return dst;
        }

        /// <summary>
        /// performs forward or inverse 1D or 2D Discrete Cosine Transformation
        /// </summary>
        /// <param name="flags">Transformation flags, a combination of DctFlag2 values</param>
        /// <returns>The destination array; will have the same size and same type as src</returns>
        public Mat Dct(DctFlag2 flags = DctFlag2.None)
        {
            var dst = new Mat();
            Cv2.Dct(this, dst, flags);
            return dst;
        }

        /// <summary>
        /// performs inverse 1D or 2D Discrete Cosine Transformation
        /// </summary>
        /// <param name="flags">Transformation flags, a combination of DctFlag2 values</param>
        /// <returns>The destination array; will have the same size and same type as src</returns>
        public Mat Idct(DctFlag2 flags = DctFlag2.None)
        {
            var dst = new Mat();
            Cv2.Idct(this, dst, flags);
            return dst;
        }

        /// <summary>
        /// fills array with uniformly-distributed random numbers from the range [low, high)
        /// </summary>
        /// <param name="low">The inclusive lower boundary of the generated random numbers</param>
        /// <param name="high">The exclusive upper boundary of the generated random numbers</param>
        public void Randu(InputArray low, InputArray high)
        {
            Cv2.Randu(this, low, high);
        }

        /// <summary>
        /// fills array with uniformly-distributed random numbers from the range [low, high)
        /// </summary>
        /// <param name="low">The inclusive lower boundary of the generated random numbers</param>
        /// <param name="high">The exclusive upper boundary of the generated random numbers</param>
        public void Randu(Scalar low, Scalar high)
        {
            Cv2.Randu(this, low, high);
        }

        /// <summary>
        /// fills array with normally-distributed random numbers with the specified mean and the standard deviation
        /// </summary>
        /// <param name="mean">The mean value (expectation) of the generated random numbers</param>
        /// <param name="stddev">The standard deviation of the generated random numbers</param>
        public void Randn(InputArray mean, InputArray stddev)
        {
            Cv2.Randn(this, mean, stddev);
        }

        /// <summary>
        /// fills array with normally-distributed random numbers with the specified mean and the standard deviation
        /// </summary>
        /// <param name="mean">The mean value (expectation) of the generated random numbers</param>
        /// <param name="stddev">The standard deviation of the generated random numbers</param>
        public void Randn(Scalar mean, Scalar stddev)
        {
            Cv2.Randn(this, mean, stddev);
        }

        /// <summary>
        /// shuffles the input array elements
        /// </summary>
        /// <param name="iterFactor">The scale factor that determines the number of random swap operations.</param>
        /// <param name="rng">The optional random number generator used for shuffling. 
        /// If it is null, theRng() is used instead.</param>
        /// <returns>The input/output numerical 1D array</returns>
        public void RandShuffle(double iterFactor, RNG rng = null)
        {
            Cv2.RandShuffle(this, iterFactor, rng);
        }

        /// <summary>
        /// computes the contour perimeter (closed=true) or a curve length
        /// </summary>
        /// <param name="closed"></param>
        /// <returns></returns>
        public double ArcLength(bool closed)
        {
            return Cv2.ArcLength(this, closed);
        }

        /// <summary>
        /// computes the bounding rectangle for a contour
        /// </summary>
        /// <returns></returns>
        public Rect BoundingRect()
        {
            return Cv2.BoundingRect(this);
        }

        /// <summary>
        /// computes the contour area
        /// </summary>
        /// <param name="oriented"></param>
        /// <returns></returns>
        public double ContourArea(bool oriented = false)
        {
            return Cv2.ContourArea(this, oriented);
        }

        /// <summary>
        /// computes the minimal rotated rectangle for a set of points
        /// </summary>
        /// <param name="points"></param>
        /// <returns></returns>
        public RotatedRect MinAreaRect(InputArray points)
        {
            return Cv2.MinAreaRect(this);
        }

        /// <summary>
        /// computes the minimal enclosing circle for a set of points
        /// </summary>
        /// <param name="center"></param>
        /// <param name="radius"></param>
        public void MinEnclosingCircle(out Point2f center, out float radius)
        {
            Cv2.MinEnclosingCircle(this, out center, out radius);
        }

        #region Drawing

        #region Line

#if LANG_JP
    /// <summary>
    /// 2点を結ぶ線分を画像上に描画する．
    /// </summary>
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
        /// <param name="pt1X">First point's x-coordinate of the line segment. </param>
        /// <param name="pt1Y">First point's y-coordinate of the line segment. </param>
        /// <param name="pt2X">Second point's x-coordinate of the line segment. </param>
        /// <param name="pt2Y">Second point's y-coordinate of the line segment. </param>
        /// <param name="color">Line color. </param>
        /// <param name="thickness">Line thickness. [By default this is 1]</param>
        /// <param name="lineType">Type of the line. [By default this is LineType.Link8]</param>
        /// <param name="shift">Number of fractional bits in the point coordinates. [By default this is 0]</param>
#endif
        public void Line(int pt1X, int pt1Y, int pt2X, int pt2Y, CvScalar color,
            int thickness = 1, LineType lineType = LineType.Link8, int shift = 0)
        {
            Cv2.Line(this, pt1X, pt1Y, pt2X, pt2Y, color, thickness, lineType, shift);
        }

#if LANG_JP
    /// <summary>
    /// 2点を結ぶ線分を画像上に描画する．
    /// </summary>
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
        /// <param name="pt1">First point of the line segment. </param>
        /// <param name="pt2">Second point of the line segment. </param>
        /// <param name="color">Line color. </param>
        /// <param name="thickness">Line thickness. [By default this is 1]</param>
        /// <param name="lineType">Type of the line. [By default this is LineType.Link8]</param>
        /// <param name="shift">Number of fractional bits in the point coordinates. [By default this is 0]</param>
#endif
        public void Line(Point pt1, Point pt2, Scalar color, int thickness = 1, LineType lineType = LineType.Link8,
            int shift = 0)
        {
            Cv2.Line(this, pt1, pt2, color, thickness, lineType, shift);
        }

        #endregion

        #region Rectangle

#if LANG_JP
    /// <summary>
    /// 枠のみ，もしくは塗りつぶされた矩形を描画する
    /// </summary>
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
        /// <param name="pt1">One of the rectangle vertices. </param>
        /// <param name="pt2">Opposite rectangle vertex. </param>
        /// <param name="color">Line color (RGB) or brightness (grayscale image). </param>
        /// <param name="thickness">Thickness of lines that make up the rectangle. Negative values make the function to draw a filled rectangle. [By default this is 1]</param>
        /// <param name="lineType">Type of the line, see cvLine description. [By default this is LineType.Link8]</param>
        /// <param name="shift">Number of fractional bits in the point coordinates. [By default this is 0]</param>
#endif
        public void Rectangle(Point pt1, Point pt2, Scalar color, int thickness = 1, LineType lineType = LineType.Link8,
            int shift = 0)
        {
            Cv2.Rectangle(this, pt1, pt2, color, thickness, lineType, shift);
        }

#if LANG_JP
    /// <summary>
    /// 枠のみ，もしくは塗りつぶされた矩形を描画する
    /// </summary>
    /// <param name="rect">矩形</param>
    /// <param name="color">線の色(RGB)，もしくは輝度(グレースケール画像).</param>
    /// <param name="thickness">矩形を描く線の太さ．負の値を指定した場合は塗りつぶされる. [既定値は1]</param>
    /// <param name="lineType">線の種類. [既定値はLineType.Link8]</param>
    /// <param name="shift">座標の小数点以下の桁を表すビット数. [既定値は0]</param>
#else
        /// <summary>
        /// Draws simple, thick or filled rectangle
        /// </summary>
        /// <param name="rect">Rectangle.</param>
        /// <param name="color">Line color (RGB) or brightness (grayscale image). </param>
        /// <param name="thickness">Thickness of lines that make up the rectangle. Negative values make the function to draw a filled rectangle. [By default this is 1]</param>
        /// <param name="lineType">Type of the line, see cvLine description. [By default this is LineType.Link8]</param>
        /// <param name="shift">Number of fractional bits in the point coordinates. [By default this is 0]</param>
#endif
        public void Rectangle(Rect rect, Scalar color, int thickness = 1, LineType lineType = LineType.Link8,
            int shift = 0)
        {
            Cv2.Rectangle(this, rect, color, thickness, lineType, shift);
        }

        #endregion

        #region Circle

#if LANG_JP
    /// <summary>
    /// 円を描画する
    /// </summary>
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
        /// <param name="centerX">X-coordinate of the center of the circle. </param>
        /// <param name="centerY">Y-coordinate of the center of the circle. </param>
        /// <param name="radius">Radius of the circle. </param>
        /// <param name="color">Circle color. </param>
        /// <param name="thickness">Thickness of the circle outline if positive, otherwise indicates that a filled circle has to be drawn. [By default this is 1]</param>
        /// <param name="lineType">Type of the circle boundary. [By default this is LineType.Link8]</param>
        /// <param name="shift">Number of fractional bits in the center coordinates and radius value. [By default this is 0]</param>
#endif
        public void Circle(int centerX, int centerY, int radius, Scalar color,
            int thickness = 1, LineType lineType = LineType.Link8, int shift = 0)
        {
            Cv2.Circle(this, centerX, centerY, radius, color, thickness, lineType, shift);
        }

#if LANG_JP
    /// <summary>
    /// 円を描画する
    /// </summary>
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
        /// <param name="center">Center of the circle. </param>
        /// <param name="radius">Radius of the circle. </param>
        /// <param name="color">Circle color. </param>
        /// <param name="thickness">Thickness of the circle outline if positive, otherwise indicates that a filled circle has to be drawn. [By default this is 1]</param>
        /// <param name="lineType">Type of the circle boundary. [By default this is LineType.Link8]</param>
        /// <param name="shift">Number of fractional bits in the center coordinates and radius value. [By default this is 0]</param>
#endif
        public void Circle(Point center, int radius, Scalar color,
            int thickness = 1, LineType lineType = LineType.Link8, int shift = 0)
        {
            Cv2.Circle(this, center, radius, color, thickness, lineType, shift);
        }

        #endregion

        #region Ellipse

#if LANG_JP
    /// <summary>
    /// 枠だけの楕円，楕円弧，もしくは塗りつぶされた扇形の楕円を描画する
    /// </summary>
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
        public void Ellipse(Point center, Size axes, double angle, double startAngle, double endAngle, Scalar color,
            int thickness = 1, LineType lineType = LineType.Link8, int shift = 0)
        {
            Cv2.Ellipse(this, center, axes, angle, startAngle, endAngle, color, thickness, lineType, shift);
        }

#if LANG_JP
    /// <summary>
    /// 枠だけの楕円，もしくは塗りつぶされた楕円を描画する
    /// </summary>
    /// <param name="box">描画したい楕円を囲む矩形領域．</param>
    /// <param name="color">楕円の色．</param>
    /// <param name="thickness">楕円境界線の幅．[既定値は1]</param>
    /// <param name="lineType">楕円境界線の種類．[既定値はLineType.Link8]</param>
#else
        /// <summary>
        /// Draws simple or thick elliptic arc or fills ellipse sector
        /// </summary>
        /// <param name="box">The enclosing box of the ellipse drawn </param>
        /// <param name="color">Ellipse color. </param>
        /// <param name="thickness">Thickness of the ellipse boundary. [By default this is 1]</param>
        /// <param name="lineType">Type of the ellipse boundary. [By default this is LineType.Link8]</param>
#endif
        public void Ellipse(RotatedRect box, Scalar color,
            int thickness = 1, LineType lineType = LineType.Link8)
        {
            Cv2.Ellipse(this, box, color, thickness, lineType);
        }

        #endregion

        #region FillConvexPoly

#if LANG_JP
    /// <summary>
    /// 塗りつぶされた凸ポリゴンを描きます．
    /// </summary>
    /// <param name="pts">ポリゴンの頂点．</param>
    /// <param name="color">ポリゴンの色．</param>
    /// <param name="lineType">ポリゴンの枠線の種類，</param>
    /// <param name="shift">ポリゴンの頂点座標において，小数点以下の桁を表すビット数．</param>
#else
        /// <summary>
        /// Fills a convex polygon.
        /// </summary>
        /// <param name="pts">The polygon vertices</param>
        /// <param name="color">Polygon color</param>
        /// <param name="lineType">Type of the polygon boundaries</param>
        /// <param name="shift">The number of fractional bits in the vertex coordinates</param>
#endif
        public void FillConvexPoly(IEnumerable<Point> pts, Scalar color,
            LineType lineType = LineType.Link8, int shift = 0)
        {
            Cv2.FillConvexPoly(this, pts, color, lineType, shift);
        }

        #endregion

        #region FillPoly

#if LANG_JP
    /// <summary>
    /// 1つ，または複数のポリゴンで区切られた領域を塗りつぶします．
    /// </summary>
    /// <param name="pts">ポリゴンの配列．各要素は，点の配列で表現されます．</param>
    /// <param name="color">ポリゴンの色．</param>
    /// <param name="lineType">ポリゴンの枠線の種類，</param>
    /// <param name="shift">ポリゴンの頂点座標において，小数点以下の桁を表すビット数．</param>
    /// <param name="offset"></param>
#else
        /// <summary>
        /// Fills the area bounded by one or more polygons
        /// </summary>
        /// <param name="pts">Array of polygons, each represented as an array of points</param>
        /// <param name="color">Polygon color</param>
        /// <param name="lineType">Type of the polygon boundaries</param>
        /// <param name="shift">The number of fractional bits in the vertex coordinates</param>
        /// <param name="offset"></param>
#endif
        public void FillPoly(IEnumerable<IEnumerable<Point>> pts, Scalar color,
            LineType lineType = LineType.Link8, int shift = 0, Point? offset = null)
        {
            Cv2.FillPoly(this, pts, color, lineType, shift, offset);
        }

        #endregion

        #region Polylines

        /// <summary>
        /// draws one or more polygonal curves
        /// </summary>
        /// <param name="pts"></param>
        /// <param name="isClosed"></param>
        /// <param name="color"></param>
        /// <param name="thickness"></param>
        /// <param name="lineType"></param>
        /// <param name="shift"></param>
        public void Polylines(IEnumerable<IEnumerable<Point>> pts, bool isClosed, Scalar color,
            int thickness = 1, LineType lineType = LineType.Link8, int shift = 0)
        {
            Cv2.Polylines(this, pts, isClosed, color, thickness, lineType, shift);
        }

        #endregion

        #region PutText

        /// <summary>
        /// renders text string in the image
        /// </summary>
        /// <param name="text"></param>
        /// <param name="org"></param>
        /// <param name="fontFace"></param>
        /// <param name="fontScale"></param>
        /// <param name="color"></param>
        /// <param name="thickness"></param>
        /// <param name="lineType"></param>
        /// <param name="bottomLeftOrigin"></param>
        public void PutText(string text, Point org,
            FontFace fontFace, double fontScale, Scalar color,
            int thickness = 1,
            LineType lineType = LineType.Link8,
            bool bottomLeftOrigin = false)
        {
            Cv2.PutText(this, text, org, fontFace, fontScale, color, thickness, lineType, bottomLeftOrigin);
        }

        #endregion

        #region ImEncode / ToBytes

        /// <summary>
        /// Encodes an image into a memory buffer.
        /// </summary>
        /// <param name="ext">Encodes an image into a memory buffer.</param>
        /// <param name="prms">Format-specific parameters.</param>
        /// <returns></returns>
        public byte[] ImEncode(string ext = ".png", int[] prms = null)
        {
            byte[] buf;
            Cv2.ImEncode(ext, this, out buf, prms);
            return buf;
        }

        /// <summary>
        /// Encodes an image into a memory buffer.
        /// </summary>
        /// <param name="ext">Encodes an image into a memory buffer.</param>
        /// <param name="prms">Format-specific parameters.</param>
        /// <returns></returns>
        public byte[] ImEncode(string ext = ".png", params ImageEncodingParam[] prms)
        {
            byte[] buf;
            Cv2.ImEncode(ext, this, out buf, prms);
            return buf;
        }

        #endregion

        #region ImWrite / SaveImage

        /// <summary>
        /// Saves an image to a specified file.
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="prms"></param>
        /// <returns></returns>
        public bool ImWrite(string fileName, int[] prms = null)
        {
            return Cv2.ImWrite(fileName, this, prms);
        }

        /// <summary>
        /// Saves an image to a specified file.
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="prms"></param>
        /// <returns></returns>
        public bool ImWrite(string fileName, params ImageEncodingParam[] prms)
        {
            return Cv2.ImWrite(fileName, this, prms);
        }

        /// <summary>
        /// Saves an image to a specified file.
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="prms"></param>
        /// <returns></returns>
        public bool SaveImage(string fileName, int[] prms = null)
        {
            return Cv2.ImWrite(fileName, this, prms);
        }

        /// <summary>
        /// Saves an image to a specified file.
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="prms"></param>
        /// <returns></returns>
        public bool SaveImage(string fileName, params ImageEncodingParam[] prms)
        {
            return Cv2.ImWrite(fileName, this, prms);
        }

        #endregion

        #endregion

        #endregion
    }
}
