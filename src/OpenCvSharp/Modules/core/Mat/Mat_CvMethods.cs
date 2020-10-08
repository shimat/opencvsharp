using System.Collections.Generic;

namespace OpenCvSharp
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
        /// <returns></returns>
        public Mat LUT(InputArray lut)
        {
            var dst = new Mat();
            Cv2.LUT(this, lut, dst);
            return dst;
        }

        /// <summary>
        /// transforms array of numbers using a lookup table: dst(i)=lut(src(i))
        /// </summary>
        /// <param name="lut">Look-up table of 256 elements. 
        /// In the case of multi-channel source array, the table should either have 
        /// a single channel (in this case the same table is used for all channels)
        ///  or the same number of channels as in the source array</param>
        /// <returns></returns>
        public Mat LUT(byte[] lut)
        {
            var dst = new Mat();
            Cv2.LUT(this, lut, dst);
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
        public Scalar Mean(InputArray? mask = null)
        {
            return Cv2.Mean(this, mask);
        }

        /// <summary>
        /// computes mean value and standard deviation of all or selected array elements
        /// </summary>
        /// <param name="mean">The output parameter: computed mean value</param>
        /// <param name="stddev">The output parameter: computed standard deviation</param>
        /// <param name="mask">The optional operation mask</param>
        public void MeanStdDev(OutputArray mean, OutputArray stddev, InputArray? mask = null)
        {
            Cv2.MeanStdDev(this, mean, stddev, mask);
        }

        /// <summary>
        /// computes norm of the selected array part
        /// </summary>
        /// <param name="normType">Type of the norm</param>
        /// <param name="mask">The optional operation mask</param>
        /// <returns></returns>
        public double Norm(NormTypes normType = NormTypes.L2, InputArray? mask = null)
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
            NormTypes normType = NormTypes.L2, int dtype = -1, InputArray? mask = null)
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
            out Point minLoc, out Point maxLoc, InputArray? mask = null)
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
        public void MinMaxIdx(int[] minIdx, int[] maxIdx)
        {
            Cv2.MinMaxIdx(this, minIdx, maxIdx);
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
            int[] minIdx, int[] maxIdx, InputArray? mask = null)
        {
            Cv2.MinMaxIdx(this, out minVal, out maxVal, minIdx, maxIdx, mask);
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
        public Mat Reduce(ReduceDimension dim, ReduceTypes rtype, int dtype)
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
        /// Checks if array elements lie between the elements of two other arrays.
        /// </summary>
        /// <param name="lowerb">inclusive lower boundary array or a scalar.</param>
        /// <param name="upperb">inclusive upper boundary array or a scalar.</param>
        /// <returns>The destination array, will have the same size as src and CV_8U type</returns>
        public Mat InRange(InputArray lowerb, InputArray upperb)
        {
            var dst = new Mat();
            Cv2.InRange(this, lowerb, upperb, dst);
            return dst;
        }


        /// <summary>
        /// Checks if array elements lie between the elements of two other arrays.
        /// </summary>
        /// <param name="lowerb">inclusive lower boundary array or a scalar.</param>
        /// <param name="upperb">inclusive upper boundary array or a scalar.</param>
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
        public Mat MulTransposed(bool aTa, InputArray? delta = null, double scale = 1, int dtype = -1)
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
        public Mat Sort(SortFlags flags)
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
        public Mat SortIdx(SortFlags flags)
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
        public Mat Dft(DftFlags flags = 0, int nonzeroRows = 0)
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
        public Mat Idft(DftFlags flags = 0, int nonzeroRows = 0)
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
        public Mat Dct(DctFlags flags = 0)
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
        public Mat Idct(DctFlags flags = 0)
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
        /// <returns>The input/output numerical 1D array</returns>
        public void RandShuffle(double iterFactor)
        {
            Cv2.RandShuffle(this, iterFactor);
        }

        /// <summary>
        /// shuffles the input array elements
        /// </summary>
        /// <param name="iterFactor">The scale factor that determines the number of random swap operations.</param>
        /// <param name="rng">The optional random number generator used for shuffling. 
        /// If it is null, theRng() is used instead.</param>
        /// <returns>The input/output numerical 1D array</returns>
        public void RandShuffle(double iterFactor, ref RNG rng)
        {
            Cv2.RandShuffle(this, iterFactor, ref rng);
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
        public void Line(int pt1X, int pt1Y, int pt2X, int pt2Y, Scalar color,
            int thickness = 1, LineTypes lineType = LineTypes.Link8, int shift = 0)
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
        public void Line(
            Point pt1, Point pt2, Scalar color, int thickness = 1, 
            LineTypes lineType = LineTypes.Link8, int shift = 0)
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
        public void Rectangle(
            Point pt1, Point pt2, Scalar color, int thickness = 1, 
            LineTypes lineType = LineTypes.Link8, int shift = 0)
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
        public void Rectangle(
            Rect rect, Scalar color, int thickness = 1,
            LineTypes lineType = LineTypes.Link8, int shift = 0)
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
            int thickness = 1, LineTypes lineType = LineTypes.Link8, int shift = 0)
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
            int thickness = 1, LineTypes lineType = LineTypes.Link8, int shift = 0)
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
        public void Ellipse(
            Point center, Size axes, double angle, double startAngle, double endAngle, Scalar color,
            int thickness = 1, LineTypes lineType = LineTypes.Link8, int shift = 0)
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
            int thickness = 1, LineTypes lineType = LineTypes.Link8)
        {
            Cv2.Ellipse(this, box, color, thickness, lineType);
        }

        #endregion

        /// <summary>
        /// Draws a marker on a predefined position in an image.
        ///
        /// The function cv::drawMarker draws a marker on a given position in the image.For the moment several
        /// marker types are supported, see #MarkerTypes for more information.
        /// </summary>
        /// <param name="position">The point where the crosshair is positioned.</param>
        /// <param name="color">Line color.</param>
        /// <param name="markerType">The specific type of marker you want to use.</param>
        /// <param name="markerSize">The length of the marker axis [default = 20 pixels]</param>
        /// <param name="thickness">Line thickness.</param>
        /// <param name="lineType">Type of the line.</param>
        public void DrawMarker(
            Point position, Scalar color,
            MarkerTypes markerType = MarkerTypes.Cross, int markerSize = 20, int thickness = 1, LineTypes lineType = LineTypes.Link8)
        {
            Cv2.DrawMarker(this, position, color, markerType, markerSize, thickness, lineType);
        }

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
            LineTypes lineType = LineTypes.Link8, int shift = 0)
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
            LineTypes lineType = LineTypes.Link8, int shift = 0, Point? offset = null)
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
            int thickness = 1, LineTypes lineType = LineTypes.Link8, int shift = 0)
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
            HersheyFonts fontFace, double fontScale, Scalar color,
            int thickness = 1,
            LineTypes lineType = LineTypes.Link8,
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
        public byte[] ImEncode(string ext = ".png", int[]? prms = null)
        {
            Cv2.ImEncode(ext, this, out var buf, prms);
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
            Cv2.ImEncode(ext, this, out var buf, prms);
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
        public bool ImWrite(string fileName, int[]? prms = null)
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
        public bool SaveImage(string fileName, int[]? prms = null)
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

        #region imgproc

        /// <summary>
        /// Forms a border around the image
        /// </summary>
        /// <param name="top">Specify how much pixels in each direction from the source image rectangle one needs to extrapolate</param>
        /// <param name="bottom">Specify how much pixels in each direction from the source image rectangle one needs to extrapolate</param>
        /// <param name="left">Specify how much pixels in each direction from the source image rectangle one needs to extrapolate</param>
        /// <param name="right">Specify how much pixels in each direction from the source image rectangle one needs to extrapolate</param>
        /// <param name="borderType">The border type</param>
        /// <param name="value">The border value if borderType == Constant</param>
        public Mat CopyMakeBorder(int top, int bottom, int left, int right, BorderTypes borderType, Scalar? value = null)
        {
            var dst = new Mat();
            Cv2.CopyMakeBorder(this, dst, top, bottom, left, right, borderType, value);
            return dst;
        }

        /// <summary>
        /// Smoothes image using median filter.
        /// The source image must have 1-, 3- or 4-channel and 
        /// its depth should be CV_8U , CV_16U or CV_32F. 
        /// </summary>
        /// <param name="ksize">The aperture linear size. It must be odd and more than 1, i.e. 3, 5, 7 ...</param>
        /// <returns>The destination array; will have the same size and the same type as src.</returns>
        public Mat MedianBlur(int ksize)
        {
            var dst = new Mat();
            Cv2.MedianBlur(this, dst, ksize);
            return dst;
        }

        /// <summary>
        /// Blurs an image using a Gaussian filter.
        /// The input image can have any number of channels, which are processed independently, 
        /// but the depth should be CV_8U, CV_16U, CV_16S, CV_32F or CV_64F.
        /// </summary>
        /// <param name="ksize">Gaussian kernel size. ksize.width and ksize.height can differ but they both must be positive and odd. 
        /// Or, they can be zero’s and then they are computed from sigma* .</param>
        /// <param name="sigmaX">Gaussian kernel standard deviation in X direction.</param>
        /// <param name="sigmaY">Gaussian kernel standard deviation in Y direction; if sigmaY is zero, it is set to be equal to sigmaX, 
        /// if both sigmas are zeros, they are computed from ksize.width and ksize.height, 
        /// respectively (see getGaussianKernel() for details); to fully control the result 
        /// regardless of possible future modifications of all this semantics, it is recommended to specify all of ksize, sigmaX, and sigmaY.</param>
        /// <param name="borderType">pixel extrapolation method</param>
        public Mat GaussianBlur(Size ksize, double sigmaX,
            double sigmaY = 0, BorderTypes borderType = BorderTypes.Default)
        {
            var dst = new Mat();
            Cv2.GaussianBlur(this, dst, ksize, sigmaX, sigmaY, borderType);
            return dst;
        }

        /// <summary>
        /// Applies bilateral filter to the image
        /// The source image must be a 8-bit or floating-point, 1-channel or 3-channel image.
        /// </summary>
        /// <param name="d">The diameter of each pixel neighborhood, that is used during filtering. 
        /// If it is non-positive, it's computed from sigmaSpace</param>
        /// <param name="sigmaColor">Filter sigma in the color space. 
        /// Larger value of the parameter means that farther colors within the pixel neighborhood 
        /// will be mixed together, resulting in larger areas of semi-equal color</param>
        /// <param name="sigmaSpace">Filter sigma in the coordinate space. 
        /// Larger value of the parameter means that farther pixels will influence each other 
        /// (as long as their colors are close enough; see sigmaColor). Then d>0 , it specifies 
        /// the neighborhood size regardless of sigmaSpace, otherwise d is proportional to sigmaSpace</param>
        /// <param name="borderType"></param>
        /// <returns>The destination image; will have the same size and the same type as src</returns>
        public Mat BilateralFilter(int d, double sigmaColor, double sigmaSpace,
            BorderTypes borderType = BorderTypes.Default)
        {
            var dst = new Mat();
            Cv2.BilateralFilter(this, dst, d, sigmaColor, sigmaSpace, borderType);
            return dst;
        }

        /// <summary>
        /// Smoothes image using box filter
        /// </summary>
        /// <param name="ddepth"></param>
        /// <param name="ksize">The smoothing kernel size</param>
        /// <param name="anchor">The anchor point. The default value Point(-1,-1) means that the anchor is at the kernel center</param>
        /// <param name="normalize">Indicates, whether the kernel is normalized by its area or not</param>
        /// <param name="borderType">The border mode used to extrapolate pixels outside of the image</param>
        /// <returns>The destination image; will have the same size and the same type as src</returns>
        public Mat BoxFilter(MatType ddepth, Size ksize, Point? anchor = null, 
            bool normalize = true, BorderTypes borderType = BorderTypes.Default)
        {
            var dst = new Mat();
            Cv2.BoxFilter(this, dst, ddepth, ksize, anchor, normalize, borderType);
            return dst;
        }

        /// <summary>
        /// Smoothes image using normalized box filter
        /// </summary>
        /// <param name="ksize">The smoothing kernel size</param>
        /// <param name="anchor">The anchor point. The default value Point(-1,-1) means that the anchor is at the kernel center</param>
        /// <param name="borderType">The border mode used to extrapolate pixels outside of the image</param>
        /// <returns>The destination image; will have the same size and the same type as src</returns>
        public Mat Blur(Size ksize, Point? anchor = null, 
            BorderTypes borderType = BorderTypes.Default)
        {
            var dst = new Mat();
            Cv2.Blur(this, dst, ksize, anchor, borderType);
            return dst;
        }

        /// <summary>
        /// Convolves an image with the kernel
        /// </summary>
        /// <param name="ddepth">The desired depth of the destination image. If it is negative, it will be the same as src.depth()</param>
        /// <param name="kernel">Convolution kernel (or rather a correlation kernel), 
        /// a single-channel floating point matrix. If you want to apply different kernels to 
        /// different channels, split the image into separate color planes using split() and process them individually</param>
        /// <param name="anchor">The anchor of the kernel that indicates the relative position of 
        /// a filtered point within the kernel. The anchor should lie within the kernel. 
        /// The special default value (-1,-1) means that the anchor is at the kernel center</param>
        /// <param name="delta">The optional value added to the filtered pixels before storing them in dst</param>
        /// <param name="borderType">The pixel extrapolation method</param>
        /// <returns>The destination image. It will have the same size and the same number of channels as src</returns>
        public Mat Filter2D(MatType ddepth, InputArray kernel, Point? anchor = null, 
            double delta = 0, BorderTypes borderType = BorderTypes.Default)
        {
            var dst = new Mat();
            Cv2.Filter2D(this, dst, ddepth, kernel, anchor, delta, borderType);
            return dst;
        }

        /// <summary>
        /// Applies separable linear filter to an image
        /// </summary>
        /// <param name="ddepth">The destination image depth</param>
        /// <param name="kernelX">The coefficients for filtering each row</param>
        /// <param name="kernelY">The coefficients for filtering each column</param>
        /// <param name="anchor">The anchor position within the kernel; The default value (-1, 1) means that the anchor is at the kernel center</param>
        /// <param name="delta">The value added to the filtered results before storing them</param>
        /// <param name="borderType">The pixel extrapolation method</param>
        /// <returns>The destination image; will have the same size and the same number of channels as src</returns>
        public Mat SepFilter2D(MatType ddepth, InputArray kernelX, InputArray kernelY,
            Point? anchor = null, double delta = 0, BorderTypes borderType = BorderTypes.Default)
        {
            var dst = new Mat();
            Cv2.SepFilter2D(this, dst, ddepth, kernelX, kernelY, anchor, delta, borderType);
            return dst;
        }

        /// <summary>
        /// Calculates the first, second, third or mixed image derivatives using an extended Sobel operator
        /// </summary>
        /// <param name="ddepth">The destination image depth</param>
        /// <param name="xorder">Order of the derivative x</param>
        /// <param name="yorder">Order of the derivative y</param>
        /// <param name="ksize">Size of the extended Sobel kernel, must be 1, 3, 5 or 7</param>
        /// <param name="scale">The optional scale factor for the computed derivative values (by default, no scaling is applied</param>
        /// <param name="delta">The optional delta value, added to the results prior to storing them in dst</param>
        /// <param name="borderType">The pixel extrapolation method</param>
        /// <returns>The destination image; will have the same size and the same number of channels as src</returns>
        public Mat Sobel(MatType ddepth, int xorder, int yorder,
            int ksize = 3, double scale = 1, double delta = 0, BorderTypes borderType = BorderTypes.Default)
        {
            var dst = new Mat();
            Cv2.Sobel(this, dst, ddepth, xorder, yorder, ksize, scale, delta, borderType);
            return dst;
        }

        /// <summary>
        /// Calculates the first x- or y- image derivative using Scharr operator
        /// </summary>
        /// <param name="ddepth">The destination image depth</param>
        /// <param name="xorder">Order of the derivative x</param>
        /// <param name="yorder">Order of the derivative y</param>
        /// <param name="scale">The optional scale factor for the computed derivative values (by default, no scaling is applie</param>
        /// <param name="delta">The optional delta value, added to the results prior to storing them in dst</param>
        /// <param name="borderType">The pixel extrapolation method</param>
        /// <returns>The destination image; will have the same size and the same number of channels as src</returns>
        public Mat Scharr(MatType ddepth, int xorder, int yorder,
            double scale = 1, double delta = 0, BorderTypes borderType = BorderTypes.Default)
        {
            var dst = new Mat();
            Cv2.Scharr(this, dst, ddepth, xorder, yorder, scale, delta, borderType);
            return dst;
        }

        /// <summary>
        /// Calculates the Laplacian of an image
        /// </summary>
        /// <param name="ddepth">The desired depth of the destination image</param>
        /// <param name="ksize">The aperture size used to compute the second-derivative filters</param>
        /// <param name="scale">The optional scale factor for the computed Laplacian values (by default, no scaling is applied</param>
        /// <param name="delta">The optional delta value, added to the results prior to storing them in dst</param>
        /// <param name="borderType">The pixel extrapolation method</param>
        /// <returns>Destination image; will have the same size and the same number of channels as src</returns>
        public Mat Laplacian(MatType ddepth,
            int ksize = 1, double scale = 1, double delta = 0, BorderTypes borderType = BorderTypes.Default)
        {
            var dst = new Mat();
            Cv2.Laplacian(this, dst, ddepth, ksize, scale, delta, borderType);
            return dst;
        }

#if LANG_JP
    /// <summary>
    /// Cannyアルゴリズムを用いて，画像のエッジを検出します．
    /// </summary>
    /// <param name="threshold1">ヒステリシスが存在する処理の，1番目の閾値</param>
    /// <param name="threshold2">ヒステリシスが存在する処理の，2番目の閾値</param>
    /// <param name="apertureSize">Sobelオペレータのアパーチャサイズ [既定値はApertureSize.Size3]</param>
    /// <param name="L2gradient">画像勾配の強度を求めるために，より精度の高い L2ノルムを利用するか，L1ノルムで十分（false）かを指定します. [既定値はfalse]</param>
    /// <returns>出力されるエッジのマップ． image  と同じサイズ，同じ型</returns>
#else
        /// <summary>
        /// Finds edges in an image using Canny algorithm.
        /// </summary>
        /// <param name="threshold1">The first threshold for the hysteresis procedure</param>
        /// <param name="threshold2">The second threshold for the hysteresis procedure</param>
        /// <param name="apertureSize">Aperture size for the Sobel operator [By default this is ApertureSize.Size3]</param>
        /// <param name="L2gradient">Indicates, whether the more accurate L2 norm should be used to compute the image gradient magnitude (true), or a faster default L1 norm is enough (false). [By default this is false]</param>
        /// <returns>The output edge map. It will have the same size and the same type as image</returns>
#endif
        // ReSharper disable once InconsistentNaming
        public Mat Canny(double threshold1, double threshold2, int apertureSize = 3, bool L2gradient = false)
        {
            var dst = new Mat();
            Cv2.Canny(this, dst, threshold1, threshold2, apertureSize, L2gradient);
            return dst;
        }

        /// <summary>
        /// computes both eigenvalues and the eigenvectors of 2x2 derivative covariation matrix  at each pixel. The output is stored as 6-channel matrix.
        /// </summary>
        /// <param name="blockSize"></param>
        /// <param name="ksize"></param>
        /// <param name="borderType"></param>
        public Mat CornerEigenValsAndVecs(int blockSize, int ksize, BorderTypes borderType = BorderTypes.Default)
        {
            var dst = new Mat();
            Cv2.CornerEigenValsAndVecs(this, dst, blockSize, ksize, borderType);
            return dst;
        }

        /// <summary>
        /// computes another complex cornerness criteria at each pixel
        /// </summary>
        /// <param name="ksize"></param>
        /// <param name="borderType"></param>
        public Mat PreCornerDetect(int ksize, BorderTypes borderType = BorderTypes.Default)
        {
            var dst = new Mat();
            Cv2.PreCornerDetect(this, dst, ksize, borderType);
            return dst;
        }

        /// <summary>
        /// adjusts the corner locations with sub-pixel accuracy to maximize the certain cornerness criteria
        /// </summary>
        /// <param name="inputCorners">Initial coordinates of the input corners and refined coordinates provided for output.</param>
        /// <param name="winSize">Half of the side length of the search window.</param>
        /// <param name="zeroZone">Half of the size of the dead region in the middle of the search zone 
        /// over which the summation in the formula below is not done. It is used sometimes to avoid possible singularities 
        /// of the autocorrelation matrix. The value of (-1,-1) indicates that there is no such a size.</param>
        /// <param name="criteria">Criteria for termination of the iterative process of corner refinement. 
        /// That is, the process of corner position refinement stops either after criteria.maxCount iterations 
        /// or when the corner position moves by less than criteria.epsilon on some iteration.</param>
        /// <returns></returns>
        public Point2f[] CornerSubPix(IEnumerable<Point2f> inputCorners,
            Size winSize, Size zeroZone, TermCriteria criteria)
        {
            return Cv2.CornerSubPix(this, inputCorners, winSize, zeroZone, criteria);
        }

        /// <summary>
        /// Finds the strong enough corners where the cornerMinEigenVal() or cornerHarris() report the local maxima.
        /// Input matrix must be 8-bit or floating-point 32-bit, single-channel image.
        /// </summary>
        /// <param name="maxCorners">Maximum number of corners to return. If there are more corners than are found, 
        /// the strongest of them is returned.</param>
        /// <param name="qualityLevel">Parameter characterizing the minimal accepted quality of image corners. 
        /// The parameter value is multiplied by the best corner quality measure, which is the minimal eigenvalue 
        /// or the Harris function response (see cornerHarris() ). The corners with the quality measure less than 
        /// the product are rejected. For example, if the best corner has the quality measure = 1500, and the qualityLevel=0.01, 
        /// then all the corners with the quality measure less than 15 are rejected.</param>
        /// <param name="minDistance">Minimum possible Euclidean distance between the returned corners.</param>
        /// <param name="mask">Optional region of interest. If the image is not empty
        ///  (it needs to have the type CV_8UC1 and the same size as image ), it specifies the region 
        /// in which the corners are detected.</param>
        /// <param name="blockSize">Size of an average block for computing a derivative covariation matrix over each pixel neighborhood.</param>
        /// <param name="useHarrisDetector">Parameter indicating whether to use a Harris detector</param>
        /// <param name="k">Free parameter of the Harris detector.</param>
        /// <returns>Output vector of detected corners.</returns>
        public Point2f[] GoodFeaturesToTrack(
            int maxCorners, double qualityLevel, double minDistance,
            InputArray mask, int blockSize, bool useHarrisDetector, double k)
        {
            return Cv2.GoodFeaturesToTrack(this, maxCorners, qualityLevel,
                    minDistance, mask, blockSize, useHarrisDetector, k);
        }

#if LANG_JP
    /// <summary>
    /// 標準ハフ変換を用いて，2値画像から直線を検出します．
    /// </summary>
    /// <param name="rho">ピクセル単位で表される投票空間の距離分解能</param>
    /// <param name="theta">ラジアン単位で表される投票空間の角度分解能</param>
    /// <param name="threshold">投票の閾値パラメータ．十分な票（ &gt; threshold ）を得た直線のみが出力されます</param>
    /// <param name="srn">マルチスケールハフ変換において，距離分解能 rho  の除数となる値．[既定値は0]</param>
    /// <param name="stn">マルチスケールハフ変換において，角度分解能 theta  の除数となる値. [既定値は0]</param>
    /// <returns>検出された直線．各直線は，2要素のベクトル (rho, theta) で表現されます．
    /// rho は原点（画像の左上コーナー）からの距離， theta はラジアン単位で表される直線の回転角度です</returns>
#else
        /// <summary>
        /// Finds lines in a binary image using standard Hough transform.
        /// The input matrix must be 8-bit, single-channel, binary source image. 
        /// This image may be modified by the function.
        /// </summary>
        /// <param name="rho">Distance resolution of the accumulator in pixels</param>
        /// <param name="theta">Angle resolution of the accumulator in radians</param>
        /// <param name="threshold">The accumulator threshold parameter. Only those lines are returned that get enough votes ( &gt; threshold )</param>
        /// <param name="srn">For the multi-scale Hough transform it is the divisor for the distance resolution rho. [By default this is 0]</param>
        /// <param name="stn">For the multi-scale Hough transform it is the divisor for the distance resolution theta. [By default this is 0]</param>
        /// <returns>The output vector of lines. Each line is represented by a two-element vector (rho, theta) . 
        /// rho is the distance from the coordinate origin (0,0) (top-left corner of the image) and theta is the line rotation angle in radians</returns>
#endif
        public LineSegmentPolar[] HoughLines(double rho, double theta, int threshold,
            double srn = 0, double stn = 0)
        {
            return Cv2.HoughLines(this, rho, theta, threshold, srn, stn);
        }

#if LANG_JP
    /// <summary>
    /// 確率的ハフ変換を利用して，2値画像から線分を検出します．
    /// </summary>
    /// <param name="rho">ピクセル単位で表される投票空間の距離分解能</param>
    /// <param name="theta">ラジアン単位で表される投票空間の角度分解能</param>
    /// <param name="threshold">投票の閾値パラメータ．十分な票（ &gt; threshold ）を得た直線のみが出力されます</param>
    /// <param name="minLineLength">最小の線分長．これより短い線分は棄却されます. [既定値は0]</param>
    /// <param name="maxLineGap">2点が同一線分上にあると見なす場合に許容される最大距離. [既定値は0]</param>
    /// <returns>検出された線分．各線分は，4要素のベクトル (x1, y1, x2, y2) で表現されます．</returns>
#else
        /// <summary>
        /// Finds lines segments in a binary image using probabilistic Hough transform.
        /// </summary>
        /// <param name="rho">Distance resolution of the accumulator in pixels</param>
        /// <param name="theta">Angle resolution of the accumulator in radians</param>
        /// <param name="threshold">The accumulator threshold parameter. Only those lines are returned that get enough votes ( &gt; threshold )</param>
        /// <param name="minLineLength">The minimum line length. Line segments shorter than that will be rejected. [By default this is 0]</param>
        /// <param name="maxLineGap">The maximum allowed gap between points on the same line to link them. [By default this is 0]</param>
        /// <returns>The output lines. Each line is represented by a 4-element vector (x1, y1, x2, y2)</returns>
#endif
        public LineSegmentPoint[] HoughLinesP(double rho, double theta, int threshold,
            double minLineLength = 0, double maxLineGap = 0)
        {
            return Cv2.HoughLinesP(this, rho, theta, threshold, minLineLength, maxLineGap);
        }

#if LANG_JP
    /// <summary>
    /// ハフ変換を用いて，グレースケール画像から円を検出します．
    /// </summary>
    /// <param name="method">現在のところ，HoughCirclesMethod.Gradient メソッドのみが実装されている．</param>
    /// <param name="dp">画像分解能に対する投票分解能の比率の逆数．</param>
    /// <param name="minDist">検出される円の中心同士の最小距離．</param>
    /// <param name="param1">手法依存の1番目のパラメータ．[既定値は100]</param>
    /// <param name="param2">手法依存の2番目のパラメータ．[既定値は100]</param>
    /// <param name="minRadius">円の半径の最小値 [既定値は0]</param>
    /// <param name="maxRadius">円の半径の最大値 [既定値は0]</param>
    /// <returns>検出された円．各ベクトルは，3要素の浮動小数点型ベクトル (x, y, radius) としてエンコードされます</returns>
#else
        /// <summary>
        /// Finds circles in a grayscale image using a Hough transform.
        /// The input matrix must be 8-bit, single-channel and grayscale.
        /// </summary>
        /// <param name="method">The available methods are HoughMethods.Gradient and HoughMethods.GradientAlt</param>
        /// <param name="dp">The inverse ratio of the accumulator resolution to the image resolution. </param>
        /// <param name="minDist">Minimum distance between the centers of the detected circles. </param>
        /// <param name="param1">The first method-specific parameter. [By default this is 100]</param>
        /// <param name="param2">The second method-specific parameter. [By default this is 100]</param>
        /// <param name="minRadius">Minimum circle radius. [By default this is 0]</param>
        /// <param name="maxRadius">Maximum circle radius. [By default this is 0] </param>
        /// <returns>The output vector found circles. Each vector is encoded as 3-element floating-point vector (x, y, radius)</returns>
#endif
        public CircleSegment[] HoughCircles(HoughMethods method, double dp, double minDist,
            double param1 = 100, double param2 = 100, int minRadius = 0, int maxRadius = 0)
        {
            return Cv2.HoughCircles(this, method, dp, minDist, param1, param2, minRadius, maxRadius);
        }

#if LANG_JP
    /// <summary>
    /// 指定の構造要素を用いて画像の膨張を行います．
    /// </summary>
    /// <param name="element">膨張に用いられる構造要素． element=new Mat()  の場合， 3x3 の矩形構造要素が用いられます</param>
    /// <param name="anchor">構造要素内のアンカー位置．デフォルト値の (-1, -1) は，アンカーが構造要素の中心にあることを意味します</param>
    /// <param name="iterations">膨張が行われる回数. [既定値は1]</param>
    /// <param name="borderType">ピクセル外挿手法．[既定値はBorderTypes.Constant]</param>
    /// <param name="borderValue">定数境界モードで利用されるピクセル値．デフォルト値は特別な意味を持ちます．[既定値はCvCpp.MorphologyDefaultBorderValue()]</param>
    /// <returns>src と同じサイズ，同じ型の出力画像</returns>
#else
        /// <summary>
        /// Dilates an image by using a specific structuring element.
        /// </summary>
        /// <param name="element">The structuring element used for dilation. If element=new Mat() , a 3x3 rectangular structuring element is used</param>
        /// <param name="anchor">Position of the anchor within the element. The default value (-1, -1) means that the anchor is at the element center</param>
        /// <param name="iterations">The number of times dilation is applied. [By default this is 1]</param>
        /// <param name="borderType">The pixel extrapolation method. [By default this is BorderTypes.Constant]</param>
        /// <param name="borderValue">The border value in case of a constant border. The default value has a special meaning. [By default this is CvCpp.MorphologyDefaultBorderValue()]</param>
        /// <returns>The destination image. It will have the same size and the same type as src</returns>
#endif
        public Mat Dilate(InputArray? element, Point? anchor = null, int iterations = 1, 
            BorderTypes borderType = BorderTypes.Constant, Scalar? borderValue = null)
        {
            var dst = new Mat();
            Cv2.Dilate(this, dst, element, anchor, iterations, borderType, borderValue);
            return dst;
        }

#if LANG_JP
    /// <summary>
    /// 指定の構造要素を用いて画像の収縮を行います．
    /// </summary>
    /// <param name="element">収縮に用いられる構造要素． element=new Mat() の場合， 3x3 の矩形の構造要素が用いられます</param>
    /// <param name="anchor">構造要素内のアンカー位置．デフォルト値の (-1, -1) は，アンカーが構造要素の中心にあることを意味します</param>
    /// <param name="iterations">収縮が行われる回数. [既定値は1]</param>
    /// <param name="borderType">ピクセル外挿手法．[既定値はBorderTypes.Constant]</param>
    /// <param name="borderValue">定数境界モードで利用されるピクセル値．デフォルト値は特別な意味を持ちます．[既定値はCvCpp.MorphologyDefaultBorderValue()]</param>
    /// <returns>src と同じサイズ，同じ型の出力画像</returns>
#else
        /// <summary>
        /// Erodes an image by using a specific structuring element.
        /// </summary>
        /// <param name="element">The structuring element used for dilation. If element=new Mat(), a 3x3 rectangular structuring element is used</param>
        /// <param name="anchor">Position of the anchor within the element. The default value (-1, -1) means that the anchor is at the element center</param>
        /// <param name="iterations">The number of times erosion is applied</param>
        /// <param name="borderType">The pixel extrapolation method</param>
        /// <param name="borderValue">The border value in case of a constant border. The default value has a special meaning. [By default this is CvCpp.MorphologyDefaultBorderValue()]</param>
        /// <returns>The destination image. It will have the same size and the same type as src</returns>
#endif
        public Mat Erode(InputArray? element, Point? anchor = null, int iterations = 1, 
            BorderTypes borderType = BorderTypes.Constant, Scalar? borderValue = null)
        {
            var dst = new Mat();
            Cv2.Erode(this, dst, element, anchor, iterations, borderType, borderValue);
            return dst;
        }

#if LANG_JP
    /// <summary>
    /// 高度なモルフォロジー変換を行います．
    /// </summary>
    /// <param name="op">モルフォロジー演算の種類</param>
    /// <param name="element">構造要素</param>
    /// <param name="anchor">構造要素内のアンカー位置．デフォルト値の (-1, -1) は，アンカーが構造要素の中心にあることを意味します.</param>
    /// <param name="iterations">収縮と膨張が適用される回数. [既定値は1]</param>
    /// <param name="borderType">ピクセル外挿手法. [既定値はBorderTypes.Constant]</param>
    /// <param name="borderValue">定数境界モードで利用されるピクセル値．デフォルト値は特別な意味を持ちます． [既定値は CvCpp.MorphologyDefaultBorderValue()]</param>
    /// <returns>src と同じサイズ，同じ型の出力画像</returns>
#else
        /// <summary>
        /// Performs advanced morphological transformations
        /// </summary>
        /// <param name="op">Type of morphological operation</param>
        /// <param name="element">Structuring element</param>
        /// <param name="anchor">Position of the anchor within the element. The default value (-1, -1) means that the anchor is at the element center</param>
        /// <param name="iterations">Number of times erosion and dilation are applied. [By default this is 1]</param>
        /// <param name="borderType">The pixel extrapolation method. [By default this is BorderTypes.Constant]</param>
        /// <param name="borderValue">The border value in case of a constant border. The default value has a special meaning. [By default this is CvCpp.MorphologyDefaultBorderValue()]</param>
        /// <returns>Destination image. It will have the same size and the same type as src</returns>
#endif
        public Mat MorphologyEx(MorphTypes op, InputArray? element,
            Point? anchor = null, int iterations = 1, BorderTypes borderType = BorderTypes.Constant,
            Scalar? borderValue = null)
        {
            var dst = new Mat();
            Cv2.MorphologyEx(this, dst, op, element, anchor, iterations, borderType, borderValue);
            return dst;
        }

        /// <summary>
        /// Resizes an image.
        /// </summary>
        /// <param name="dsize">output image size; if it equals zero, it is computed as: 
        /// dsize = Size(round(fx*src.cols), round(fy*src.rows))
        /// Either dsize or both fx and fy must be non-zero.</param>
        /// <param name="fx">scale factor along the horizontal axis; when it equals 0, 
        /// it is computed as: (double)dsize.width/src.cols</param>
        /// <param name="fy">scale factor along the vertical axis; when it equals 0, 
        /// it is computed as: (double)dsize.height/src.rows</param>
        /// <param name="interpolation">interpolation method</param>
        /// <returns>output image; it has the size dsize (when it is non-zero) or the size computed 
        /// from src.size(), fx, and fy; the type of dst is the same as of src.</returns>
        public Mat Resize(Size dsize, double fx = 0, double fy = 0,
            InterpolationFlags interpolation = InterpolationFlags.Linear)
        {
            var dst = new Mat();
            Cv2.Resize(this, dst, dsize, fx, fy, interpolation);
            return dst;
        }

        /// <summary>
        /// Applies an affine transformation to an image.
        /// </summary>
        /// <returns>output image that has the size dsize and the same type as src.</returns>
        /// <param name="m">2x3 transformation matrix.</param>
        /// <param name="dsize">size of the output image.</param>
        /// <param name="flags">combination of interpolation methods and the optional flag 
        /// WARP_INVERSE_MAP that means that M is the inverse transformation (dst -> src) .</param>
        /// <param name="borderMode">pixel extrapolation method; when borderMode=BORDER_TRANSPARENT, 
        /// it means that the pixels in the destination image corresponding to the "outliers" 
        /// in the source image are not modified by the function.</param>
        /// <param name="borderValue">value used in case of a constant border; by default, it is 0.</param>
        public Mat WarpAffine(InputArray m, Size dsize, InterpolationFlags flags = InterpolationFlags.Linear, 
            BorderTypes borderMode = BorderTypes.Constant, Scalar? borderValue = null)
        {
            var dst = new Mat();
            Cv2.WarpAffine(this, dst, m, dsize, flags, borderMode, borderValue);
            return dst;
        }

        /// <summary>
        /// Applies a perspective transformation to an image.
        /// </summary>
        /// <param name="m">3x3 transformation matrix.</param>
        /// <param name="dsize">size of the output image.</param>
        /// <param name="flags">combination of interpolation methods (INTER_LINEAR or INTER_NEAREST) 
        /// and the optional flag WARP_INVERSE_MAP, that sets M as the inverse transformation (dst -> src).</param>
        /// <param name="borderMode">pixel extrapolation method (BORDER_CONSTANT or BORDER_REPLICATE).</param>
        /// <param name="borderValue">value used in case of a constant border; by default, it equals 0.</param>
        /// <returns>output image that has the size dsize and the same type as src.</returns>
        public Mat WarpPerspective(Mat m, Size dsize, InterpolationFlags flags = InterpolationFlags.Linear, 
            BorderTypes borderMode = BorderTypes.Constant, Scalar? borderValue = null)
        {
            var dst = new Mat();
            Cv2.WarpPerspective(this, dst, m, dsize, flags, borderMode, borderValue);
            return dst;
        }

        /// <summary>
        /// Applies a generic geometrical transformation to an image.
        /// </summary>
        /// <param name="map1">The first map of either (x,y) points or just x values having the type CV_16SC2, CV_32FC1, or CV_32FC2.</param>
        /// <param name="map2">The second map of y values having the type CV_16UC1, CV_32FC1, or none (empty map if map1 is (x,y) points), respectively.</param>
        /// <param name="interpolation">Interpolation method. The method INTER_AREA is not supported by this function.</param>
        /// <param name="borderMode">Pixel extrapolation method. When borderMode=BORDER_TRANSPARENT, 
        /// it means that the pixels in the destination image that corresponds to the "outliers" in 
        /// the source image are not modified by the function.</param>
        /// <param name="borderValue">Value used in case of a constant border. By default, it is 0.</param>
        /// <returns>Destination image. It has the same size as map1 and the same type as src</returns>
        public Mat Remap(InputArray map1, InputArray map2, InterpolationFlags interpolation = InterpolationFlags.Linear, 
            BorderTypes borderMode = BorderTypes.Constant, Scalar? borderValue = null)
        {
            var dst = new Mat();
            Cv2.Remap(this, dst, map1, map2, interpolation, borderMode, borderValue);
            return dst;
        }

        /// <summary>
        /// Inverts an affine transformation.
        /// </summary>
        /// <returns>Output reverse affine transformation.</returns>
        public Mat InvertAffineTransform()
        {
            var dst = new Mat();
            Cv2.InvertAffineTransform(this, dst);
            return dst;
        }

        /// <summary>
        /// Retrieves a pixel rectangle from an image with sub-pixel accuracy.
        /// </summary>
        /// <param name="patchSize">Size of the extracted patch.</param>
        /// <param name="center">Floating point coordinates of the center of the extracted rectangle 
        /// within the source image. The center must be inside the image.</param>
        /// <param name="patchType">Depth of the extracted pixels. By default, they have the same depth as src.</param>
        /// <returns>Extracted patch that has the size patchSize and the same number of channels as src .</returns>
        public Mat GetRectSubPix(Size patchSize, Point2f center, int patchType = -1)
        {
            var dst = new Mat();
            Cv2.GetRectSubPix(this, patchSize, center, dst, patchType);
            return dst;
        }

        /// <summary>
        /// Adds an image to the accumulator.
        /// </summary>
        /// <param name="mask">Optional operation mask.</param>
        /// <returns>Accumulator image with the same number of channels as input image, 32-bit or 64-bit floating-point.</returns>
        public Mat Accumulate(InputArray mask)
        {
            var dst = new Mat();
            Cv2.Accumulate(this, dst, mask);
            return dst;
        }

        /// <summary>
        /// Adds the square of a source image to the accumulator.
        /// </summary>
        /// <param name="mask">Optional operation mask.</param>
        /// <returns>Accumulator image with the same number of channels as input image, 32-bit or 64-bit floating-point.</returns>
        public Mat AccumulateSquare(InputArray mask)
        {
            var dst = new Mat();
            Cv2.AccumulateSquare(this, dst, mask);
            return dst;
        }

        /// <summary>
        /// Computes a Hanning window coefficients in two dimensions.
        /// </summary>
        /// <param name="winSize">The window size specifications</param>
        /// <param name="type">Created array type</param>
        public void CreateHanningWindow(Size winSize, MatType type)
        {
            Cv2.CreateHanningWindow(this, winSize, type);
        }

        /// <summary>
        /// Applies a fixed-level threshold to each array element.
        /// The input matrix must be single-channel, 8-bit or 32-bit floating point.
        /// </summary>
        /// <param name="thresh">threshold value.</param>
        /// <param name="maxval">maximum value to use with the THRESH_BINARY and THRESH_BINARY_INV thresholding types.</param>
        /// <param name="type">thresholding type (see the details below).</param>
        /// <returns>output array of the same size and type as src.</returns>
        public Mat Threshold(double thresh, double maxval, ThresholdTypes type)
        {
            var dst = new Mat();
            Cv2.Threshold(this, dst, thresh, maxval, type);
            return dst;
        }

        /// <summary>
        /// Applies an adaptive threshold to an array.
        /// Source matrix must be 8-bit single-channel image.
        /// </summary>
        /// <param name="maxValue">Non-zero value assigned to the pixels for which the condition is satisfied. See the details below.</param>
        /// <param name="adaptiveMethod">Adaptive thresholding algorithm to use, ADAPTIVE_THRESH_MEAN_C or ADAPTIVE_THRESH_GAUSSIAN_C .</param>
        /// <param name="thresholdType">Thresholding type that must be either THRESH_BINARY or THRESH_BINARY_INV .</param>
        /// <param name="blockSize">Size of a pixel neighborhood that is used to calculate a threshold value for the pixel: 3, 5, 7, and so on.</param>
        /// <param name="c">Constant subtracted from the mean or weighted mean (see the details below). 
        /// Normally, it is positive but may be zero or negative as well.</param>
        /// <returns>Destination image of the same size and the same type as src.</returns>
        public Mat AdaptiveThreshold(double maxValue, AdaptiveThresholdTypes adaptiveMethod, 
            ThresholdTypes thresholdType, int blockSize, double c)
        {
            var dst = new Mat();
            Cv2.AdaptiveThreshold(this, dst, maxValue, adaptiveMethod, 
                thresholdType, blockSize, c);
            return dst;
        }

        /// <summary>
        /// Blurs an image and downsamples it.
        /// </summary>
        /// <param name="dstSize">size of the output image; by default, it is computed as Size((src.cols+1)/2</param>
        /// <param name="borderType"></param>
        /// <returns></returns>
        public Mat PyrDown(Size? dstSize = null, BorderTypes borderType = BorderTypes.Default)
        {
            var dst = new Mat();
            Cv2.PyrDown(this, dst, dstSize, borderType);
            return dst;
        }

        /// <summary>
        /// Upsamples an image and then blurs it.
        /// </summary>
        /// <param name="dstSize">size of the output image; by default, it is computed as Size(src.cols*2, (src.rows*2)</param>
        /// <param name="borderType"></param>
        /// <returns></returns>
        public Mat PyrUp(Size? dstSize = null, BorderTypes borderType = BorderTypes.Default)
        {
            var dst = new Mat();
            Cv2.PyrUp(this, dst, dstSize, borderType);
            return dst;
        }

        /// <summary>
        /// corrects lens distortion for the given camera matrix and distortion coefficients
        /// </summary>
        /// <param name="cameraMatrix"> Input camera matrix</param>
        /// <param name="distCoeffs">Input vector of distortion coefficients (k_1, k_2, p_1, p_2[, k_3[, k_4, k_5, k_6]]) of 4, 5, 
        /// or 8 elements. If the vector is null, the zero distortion coefficients are assumed.</param>
        /// <param name="newCameraMatrix">Camera matrix of the distorted image. 
        /// By default, it is the same as cameraMatrix but you may additionally scale 
        /// and shift the result by using a different matrix.</param>
        /// <returns>Output (corrected) image that has the same size and type as src .</returns>
        public Mat Undistort(InputArray cameraMatrix, InputArray distCoeffs, InputArray? newCameraMatrix = null)
        {
            var dst = new Mat();
            Cv2.Undistort(this, dst, cameraMatrix, distCoeffs, newCameraMatrix);
            return dst;
        }

        /// <summary>
        /// returns the default new camera matrix (by default it is the same as cameraMatrix unless centerPricipalPoint=true)
        /// </summary>
        /// <param name="imgSize">Camera view image size in pixels.</param>
        /// <param name="centerPrincipalPoint">Location of the principal point in the new camera matrix. 
        /// The parameter indicates whether this location should be at the image center or not.</param>
        /// <returns>the camera matrix that is either an exact copy of the input cameraMatrix 
        /// (when centerPrinicipalPoint=false), or the modified one (when centerPrincipalPoint=true).</returns>
        public Mat GetDefaultNewCameraMatrix(Size? imgSize = null, bool centerPrincipalPoint = false)
        {
            return Cv2.GetDefaultNewCameraMatrix(this, imgSize, centerPrincipalPoint);
        }

        /// <summary>
        /// Computes the ideal point coordinates from the observed point coordinates.
        /// Input matrix is an observed point coordinates, 1xN or Nx1 2-channel (CV_32FC2 or CV_64FC2).
        /// </summary>
        /// <param name="cameraMatrix">Camera matrix</param>
        /// <param name="distCoeffs">Input vector of distortion coefficients (k_1, k_2, p_1, p_2[, k_3[, k_4, k_5, k_6]]) of 4, 5, or 8 elements. 
        /// If the vector is null, the zero distortion coefficients are assumed.</param>
        /// <param name="r">Rectification transformation in the object space (3x3 matrix). 
        /// R1 or R2 computed by stereoRectify() can be passed here. 
        /// If the matrix is empty, the identity transformation is used.</param>
        /// <param name="p">New camera matrix (3x3) or new projection matrix (3x4). 
        /// P1 or P2 computed by stereoRectify() can be passed here. If the matrix is empty, 
        /// the identity new camera matrix is used.</param>
        /// <returns>Output ideal point coordinates after undistortion and reverse perspective transformation. 
        /// If matrix P is identity or omitted, dst will contain normalized point coordinates.</returns>
        public Mat UndistortPoints(
            InputArray cameraMatrix, InputArray distCoeffs,
            InputArray? r = null, InputArray? p = null)
        {
            var dst = new Mat();
            Cv2.UndistortPoints(this, dst, cameraMatrix, distCoeffs, r, p);
            return dst;
        }

        /// <summary>
        /// Normalizes the grayscale image brightness and contrast by normalizing its histogram.
        /// The source matrix is 8-bit single channel image.
        /// </summary>
        /// <returns>The destination image; will have the same size and the same type as src</returns>
        public Mat EqualizeHist()
        {
            var dst = new Mat();
            Cv2.EqualizeHist(this, dst);
            return dst;
        }

        /// <summary>
        /// Performs a marker-based image segmentation using the watershed algorithm.
        /// Input matrix is 8-bit 3-channel image.
        /// </summary>
        /// <param name="markers">Input/output 32-bit single-channel image (map) of markers. 
        /// It should have the same size as image.</param>
        public void Watershed(InputOutputArray markers)
        {
            Cv2.Watershed(this, markers);
        }

        /// <summary>
        /// Performs initial step of meanshift segmentation of an image.
        /// The source matrix is 8-bit, 3-channel image.
        /// </summary>
        /// <param name="sp">The spatial window radius.</param>
        /// <param name="sr">The color window radius.</param>
        /// <param name="maxLevel">Maximum level of the pyramid for the segmentation.</param>
        /// <param name="termcrit">Termination criteria: when to stop meanshift iterations.</param>
        /// <returns>The destination image of the same format and the same size as the source.</returns>
        public Mat PyrMeanShiftFiltering(double sp, double sr, int maxLevel = 1, TermCriteria? termcrit = null)
        {
            var dst = new Mat();
            Cv2.PyrMeanShiftFiltering(this, dst, sp, sr, maxLevel, termcrit);
            return dst;
        }

        /// <summary>
        /// Segments the image using GrabCut algorithm.
        /// The input is 8-bit 3-channel image.
        /// </summary>
        /// <param name="mask">Input/output 8-bit single-channel mask. 
        /// The mask is initialized by the function when mode is set to GC_INIT_WITH_RECT. 
        /// Its elements may have Cv2.GC_BGD / Cv2.GC_FGD / Cv2.GC_PR_BGD / Cv2.GC_PR_FGD</param>
        /// <param name="rect">ROI containing a segmented object. The pixels outside of the ROI are 
        /// marked as "obvious background". The parameter is only used when mode==GC_INIT_WITH_RECT.</param>
        /// <param name="bgdModel">Temporary array for the background model. Do not modify it while you are processing the same image.</param>
        /// <param name="fgdModel">Temporary arrays for the foreground model. Do not modify it while you are processing the same image.</param>
        /// <param name="iterCount">Number of iterations the algorithm should make before returning the result. 
        /// Note that the result can be refined with further calls with mode==GC_INIT_WITH_MASK or mode==GC_EVAL .</param>
        /// <param name="mode">Operation mode that could be one of GrabCutFlag value.</param>
        public void GrabCut(InputOutputArray mask, Rect rect,
            InputOutputArray bgdModel, InputOutputArray fgdModel,
            int iterCount, GrabCutModes mode)
        {
            Cv2.GrabCut(this, mask, rect, bgdModel, fgdModel, iterCount, mode);
        }

        /// <summary>
        /// Fills a connected component with the given color.
        /// Input/output 1- or 3-channel, 8-bit, or floating-point image. 
        /// It is modified by the function unless the FLOODFILL_MASK_ONLY flag is set in the 
        /// second variant of the function. See the details below.
        /// </summary>
        /// <param name="seedPoint">Starting point.</param>
        /// <param name="newVal">New value of the repainted domain pixels.</param>
        /// <returns></returns>
        public int FloodFill(Point seedPoint, Scalar newVal)
        {
            return Cv2.FloodFill(this, seedPoint, newVal);
        }

        /// <summary>
        /// Fills a connected component with the given color.
        /// Input/output 1- or 3-channel, 8-bit, or floating-point image. 
        /// It is modified by the function unless the FLOODFILL_MASK_ONLY flag is set in the 
        /// second variant of the function. See the details below.
        /// </summary>
        /// <param name="seedPoint">Starting point.</param>
        /// <param name="newVal">New value of the repainted domain pixels.</param>
        /// <param name="rect">Optional output parameter set by the function to the 
        /// minimum bounding rectangle of the repainted domain.</param>
        /// <param name="loDiff">Maximal lower brightness/color difference between the currently 
        /// observed pixel and one of its neighbors belonging to the component, or a seed pixel 
        /// being added to the component.</param>
        /// <param name="upDiff">Maximal upper brightness/color difference between the currently 
        /// observed pixel and one of its neighbors belonging to the component, or a seed pixel 
        /// being added to the component.</param>
        /// <param name="flags">Operation flags. Lower bits contain a connectivity value, 
        /// 4 (default) or 8, used within the function. Connectivity determines which 
        /// neighbors of a pixel are considered. </param>
        /// <returns></returns>
        public int FloodFill(
            Point seedPoint, Scalar newVal, out Rect rect, Scalar? loDiff = null, Scalar? upDiff = null,
            FloodFillFlags flags = FloodFillFlags.Link4)
        {
            return Cv2.FloodFill(this, seedPoint, newVal, out rect,
                loDiff, upDiff, flags);
        }

        /// <summary>
        /// Fills a connected component with the given color.
        /// Input/output 1- or 3-channel, 8-bit, or floating-point image. 
        /// It is modified by the function unless the FLOODFILL_MASK_ONLY flag is set in the 
        /// second variant of the function. See the details below.
        /// </summary>
        /// <param name="mask">(For the second function only) Operation mask that should be a single-channel 8-bit image, 
        /// 2 pixels wider and 2 pixels taller. The function uses and updates the mask, so you take responsibility of 
        /// initializing the mask content. Flood-filling cannot go across non-zero pixels in the mask. For example, 
        /// an edge detector output can be used as a mask to stop filling at edges. It is possible to use the same mask 
        /// in multiple calls to the function to make sure the filled area does not overlap.</param>
        /// <param name="seedPoint">Starting point.</param>
        /// <param name="newVal">New value of the repainted domain pixels.</param>
        /// <returns></returns>
        public int FloodFill(InputOutputArray mask, Point seedPoint, Scalar newVal)
        {
            return Cv2.FloodFill(this, mask, seedPoint, newVal);
        }

        /// <summary>
        /// Fills a connected component with the given color.
        /// Input/output 1- or 3-channel, 8-bit, or floating-point image. 
        /// It is modified by the function unless the FLOODFILL_MASK_ONLY flag is set in the 
        /// second variant of the function. See the details below.
        /// </summary>
        /// <param name="mask">(For the second function only) Operation mask that should be a single-channel 8-bit image, 
        /// 2 pixels wider and 2 pixels taller. The function uses and updates the mask, so you take responsibility of 
        /// initializing the mask content. Flood-filling cannot go across non-zero pixels in the mask. For example, 
        /// an edge detector output can be used as a mask to stop filling at edges. It is possible to use the same mask 
        /// in multiple calls to the function to make sure the filled area does not overlap.</param>
        /// <param name="seedPoint">Starting point.</param>
        /// <param name="newVal">New value of the repainted domain pixels.</param>
        /// <param name="rect">Optional output parameter set by the function to the 
        /// minimum bounding rectangle of the repainted domain.</param>
        /// <param name="loDiff">Maximal lower brightness/color difference between the currently 
        /// observed pixel and one of its neighbors belonging to the component, or a seed pixel 
        /// being added to the component.</param>
        /// <param name="upDiff">Maximal upper brightness/color difference between the currently 
        /// observed pixel and one of its neighbors belonging to the component, or a seed pixel 
        /// being added to the component.</param>
        /// <param name="flags">Operation flags. Lower bits contain a connectivity value, 
        /// 4 (default) or 8, used within the function. Connectivity determines which 
        /// neighbors of a pixel are considered. </param>
        /// <returns></returns>
        public int FloodFill(InputOutputArray mask, Point seedPoint, Scalar newVal, 
            out Rect rect, Scalar? loDiff = null, Scalar? upDiff = null,
            FloodFillFlags flags = FloodFillFlags.Link4)
        {
            return Cv2.FloodFill(this, mask, seedPoint,
                newVal, out rect, loDiff, upDiff, flags);
        }

#if LANG_JP
    /// <summary>
    /// 画像の色空間を変換します．
    /// </summary>
    /// <param name="code">色空間の変換コード．</param>
    /// <param name="dstCn">出力画像のチャンネル数．この値が 0 の場合，チャンネル数は src と code から自動的に求められます</param>
    /// <returns>src と同じサイズ，同じタイプの出力画像</returns>
#else
        /// <summary>
        /// Converts image from one color space to another
        /// </summary>
        /// <param name="code">The color space conversion code</param>
        /// <param name="dstCn">The number of channels in the destination image; if the parameter is 0, the number of the channels will be derived automatically from src and the code</param>
        /// <returns>The destination image; will have the same size and the same depth as src</returns>
#endif
        public Mat CvtColor(ColorConversionCodes code, int dstCn = 0)
        {
            var dst = new Mat();
            Cv2.CvtColor(this, dst, code, dstCn);
            return dst;
        }

        /// <summary>
        /// Calculates all of the moments 
        /// up to the third order of a polygon or rasterized shape.
        /// The input is a raster image (single-channel, 8-bit or floating-point 2D array).
        /// </summary>
        /// <param name="binaryImage">If it is true, then all the non-zero image pixels are treated as 1’s</param>
        /// <returns></returns>
        public Moments Moments(bool binaryImage = false)
        {
            return new Moments(this, binaryImage);
        }

        /// <summary>
        /// Computes the proximity map for the raster template and the image where the template is searched for
        /// The input is Image where the search is running; should be 8-bit or 32-bit floating-point.
        /// </summary>
        /// <param name="templ">Searched template; must be not greater than the source image and have the same data type</param>
        /// <param name="method">Specifies the comparison method</param>
        /// <param name="mask">Mask of searched template. It must have the same datatype and size with templ. It is not set by default.</param>
        /// <returns>A map of comparison results; will be single-channel 32-bit floating-point. 
        /// If image is WxH and templ is wxh then result will be (W-w+1) x (H-h+1).</returns>
        public Mat MatchTemplate(InputArray templ, TemplateMatchModes method, InputArray? mask = null)
        {
            var dst = new Mat();
            Cv2.MatchTemplate(this, templ, dst, method, mask);
            return dst;
        }

        /// <summary>
        /// computes the connected components labeled image of boolean image. 
        /// image with 4 or 8 way connectivity - returns N, the total number of labels [0, N-1] where 0 
        /// represents the background label. ltype specifies the output label image type, an important 
        /// consideration based on the total number of labels or alternatively the total number of 
        /// pixels in the source image.
        /// </summary>
        /// <param name="labels">destination labeled image</param>
        /// <param name="connectivity">8 or 4 for 8-way or 4-way connectivity respectively</param>
        /// <returns>The number of labels</returns>
        public int ConnectedComponents(OutputArray labels,
            PixelConnectivity connectivity = PixelConnectivity.Connectivity8)
        {
            return ConnectedComponents(labels, connectivity, MatType.CV_32S);
        }

        /// <summary>
        /// computes the connected components labeled image of boolean image. 
        /// image with 4 or 8 way connectivity - returns N, the total number of labels [0, N-1] where 0 
        /// represents the background label. ltype specifies the output label image type, an important 
        /// consideration based on the total number of labels or alternatively the total number of 
        /// pixels in the source image.
        /// </summary>
        /// <param name="labels">destination labeled image</param>
        /// <param name="connectivity">8 or 4 for 8-way or 4-way connectivity respectively</param>
        /// <param name="ltype">output image label type. Currently CV_32S and CV_16U are supported.</param>
        /// <returns>The number of labels</returns>
        public int ConnectedComponents(OutputArray labels,
            PixelConnectivity connectivity, MatType ltype)
        {
            return Cv2.ConnectedComponents(this, labels, connectivity, ltype);
        }

        /// <summary>
        /// computes the connected components labeled image of boolean image. 
        /// image with 4 or 8 way connectivity - returns N, the total number of labels [0, N-1] where 0 
        /// represents the background label. ltype specifies the output label image type, an important 
        /// consideration based on the total number of labels or alternatively the total number of 
        /// pixels in the source image.
        /// </summary>
        /// <param name="labels">destination labeled rectangular array</param>
        /// <param name="connectivity">8 or 4 for 8-way or 4-way connectivity respectively</param>
        /// <returns>The number of labels</returns>
        public int ConnectedComponents(out int[,] labels, PixelConnectivity connectivity)
        {
            return Cv2.ConnectedComponents(this, out labels, connectivity);
        }

        /// <summary>
        /// computes the connected components labeled image of boolean image. 
        /// image with 4 or 8 way connectivity - returns N, the total number of labels [0, N-1] where 0 
        /// represents the background label. ltype specifies the output label image type, an important 
        /// consideration based on the total number of labels or alternatively the total number of 
        /// pixels in the source image.
        /// </summary>
        /// <param name="labels">destination labeled image</param>
        /// <param name="stats">statistics output for each label, including the background label, 
        /// see below for available statistics. Statistics are accessed via stats(label, COLUMN) 
        /// where COLUMN is one of cv::ConnectedComponentsTypes</param>
        /// <param name="centroids">floating point centroid (x,y) output for each label, 
        /// including the background label</param>
        /// <param name="connectivity">8 or 4 for 8-way or 4-way connectivity respectively</param>
        /// <returns></returns>
        public int ConnectedComponentsWithStats(
            OutputArray labels, OutputArray stats, OutputArray centroids,
            PixelConnectivity connectivity = PixelConnectivity.Connectivity8)
        {
            return ConnectedComponentsWithStats(labels, stats, centroids, connectivity, MatType.CV_32S);
        }

        /// <summary>
        /// computes the connected components labeled image of boolean image. 
        /// image with 4 or 8 way connectivity - returns N, the total number of labels [0, N-1] where 0 
        /// represents the background label. ltype specifies the output label image type, an important 
        /// consideration based on the total number of labels or alternatively the total number of 
        /// pixels in the source image.
        /// </summary>
        /// <param name="labels">destination labeled image</param>
        /// <param name="stats">statistics output for each label, including the background label, 
        /// see below for available statistics. Statistics are accessed via stats(label, COLUMN) 
        /// where COLUMN is one of cv::ConnectedComponentsTypes</param>
        /// <param name="centroids">floating point centroid (x,y) output for each label, 
        /// including the background label</param>
        /// <param name="connectivity">8 or 4 for 8-way or 4-way connectivity respectively</param>
        /// <param name="ltype">output image label type. Currently CV_32S and CV_16U are supported.</param>
        /// <returns></returns>
        public int ConnectedComponentsWithStats(
            OutputArray labels, OutputArray stats, OutputArray centroids,
            PixelConnectivity connectivity, MatType ltype)
        {
            return Cv2.ConnectedComponentsWithStats(this, labels, stats, centroids, connectivity, ltype);
        }

        /// <summary>
        /// computes the connected components labeled image of boolean image. 
        /// image with 4 or 8 way connectivity - returns N, the total number of labels [0, N-1] where 0 
        /// represents the background label. ltype specifies the output label image type, an important 
        /// consideration based on the total number of labels or alternatively the total number of 
        /// pixels in the source image.
        /// </summary>
        /// <param name="connectivity">8 or 4 for 8-way or 4-way connectivity respectively</param>
        /// <returns></returns>
        public ConnectedComponents ConnectedComponentsEx(PixelConnectivity connectivity = PixelConnectivity.Connectivity8)
        {
            return Cv2.ConnectedComponentsEx(this, connectivity);
        }

#if LANG_JP
    /// <summary>
    /// 2値画像中の輪郭を検出します．
    /// 入力画像は，8ビット，シングルチャンネル．0以外のピクセルは 1として，0のピクセルは0のまま扱われます．
    /// また，この関数は，輪郭抽出処理中に入力画像の中身を書き換えます．
    /// </summary>
    /// <param name="contours">検出された輪郭．各輪郭は，点のベクトルとして格納されます．</param>
    /// <param name="hierarchy">画像のトポロジーに関する情報を含む出力ベクトル．これは，輪郭数と同じ数の要素を持ちます．各輪郭 contours[i] に対して，
    /// 要素 hierarchy[i]のメンバにはそれぞれ，同じ階層レベルに存在する前後の輪郭，最初の子輪郭，および親輪郭の 
    /// contours インデックス（0 基準）がセットされます．また，輪郭 i において，前後，親，子の輪郭が存在しない場合，
    /// それに対応する hierarchy[i] の要素は，負の値になります．</param>
    /// <param name="mode">輪郭抽出モード</param>
    /// <param name="method">輪郭の近似手法</param>
    /// <param name="offset">オプションのオフセット．各輪郭点はこの値の分だけシフトします．これは，ROIの中で抽出された輪郭を，画像全体に対して位置づけて解析する場合に役立ちます．</param>
#else
        /// <summary>
        /// Finds contours in a binary image.
        /// The source is an 8-bit single-channel image. Non-zero pixels are treated as 1’s. 
        /// Zero pixels remain 0’s, so the image is treated as binary. The function modifies this image while extracting the contours.
        /// </summary>
        /// <param name="contours">Detected contours. Each contour is stored as a vector of points.</param>
        /// <param name="hierarchy">Optional output vector, containing information about the image topology. 
        /// It has as many elements as the number of contours. For each i-th contour contours[i], 
        /// the members of the elements hierarchy[i] are set to 0-based indices in contours of the next 
        /// and previous contours at the same hierarchical level, the first child contour and the parent contour, respectively. 
        /// If for the contour i there are no next, previous, parent, or nested contours, the corresponding elements of hierarchy[i] will be negative.</param>
        /// <param name="mode">Contour retrieval mode</param>
        /// <param name="method">Contour approximation method</param>
        /// <param name="offset"> Optional offset by which every contour point is shifted. 
        /// This is useful if the contours are extracted from the image ROI and then they should be analyzed in the whole image context.</param>
#endif
        public void FindContours(out Point[][] contours, out HierarchyIndex[] hierarchy,
            RetrievalModes mode, ContourApproximationModes method, Point? offset = null)
        {
            Cv2.FindContours(this, out contours, out hierarchy, mode, method, offset);
        }

#if LANG_JP
    /// <summary>
    /// 2値画像中の輪郭を検出します．
    /// 入力画像は，8ビット，シングルチャンネル．0以外のピクセルは 1として，0のピクセルは0のまま扱われます．
    /// また，この関数は，輪郭抽出処理中に入力画像の中身を書き換えます．
    /// </summary>
    /// <param name="contours">検出された輪郭．各輪郭は，点のベクトルとして格納されます．</param>
    /// <param name="hierarchy">画像のトポロジーに関する情報を含む出力ベクトル．これは，輪郭数と同じ数の要素を持ちます．各輪郭 contours[i] に対して，
    /// 要素 hierarchy[i]のメンバにはそれぞれ，同じ階層レベルに存在する前後の輪郭，最初の子輪郭，および親輪郭の 
    /// contours インデックス（0 基準）がセットされます．また，輪郭 i において，前後，親，子の輪郭が存在しない場合，
    /// それに対応する hierarchy[i] の要素は，負の値になります．</param>
    /// <param name="mode">輪郭抽出モード</param>
    /// <param name="method">輪郭の近似手法</param>
    /// <param name="offset">オプションのオフセット．各輪郭点はこの値の分だけシフトします．これは，ROIの中で抽出された輪郭を，画像全体に対して位置づけて解析する場合に役立ちます．</param>
#else
        /// <summary>
        /// Finds contours in a binary image.
        /// The source is an 8-bit single-channel image. Non-zero pixels are treated as 1’s. 
        /// Zero pixels remain 0’s, so the image is treated as binary. The function modifies this image while extracting the contours.
        /// </summary>
        /// <param name="contours">Detected contours. Each contour is stored as a vector of points.</param>
        /// <param name="hierarchy">Optional output vector, containing information about the image topology. 
        /// It has as many elements as the number of contours. For each i-th contour contours[i], 
        /// the members of the elements hierarchy[i] are set to 0-based indices in contours of the next 
        /// and previous contours at the same hierarchical level, the first child contour and the parent contour, respectively. 
        /// If for the contour i there are no next, previous, parent, or nested contours, the corresponding elements of hierarchy[i] will be negative.</param>
        /// <param name="mode">Contour retrieval mode</param>
        /// <param name="method">Contour approximation method</param>
        /// <param name="offset"> Optional offset by which every contour point is shifted. 
        /// This is useful if the contours are extracted from the image ROI and then they should be analyzed in the whole image context.</param>
#endif
        public void FindContours(out Mat[] contours, OutputArray hierarchy,
            RetrievalModes mode, ContourApproximationModes method, Point? offset = null)
        {
            Cv2.FindContours(this, out contours, hierarchy, mode, method, offset);
        }

#if LANG_JP
        /// <summary>
        /// 2値画像中の輪郭を検出します．
        /// 入力画像は，8ビット，シングルチャンネル．0以外のピクセルは 1として，0のピクセルは0のまま扱われます．
        /// また，この関数は，輪郭抽出処理中に入力画像の中身を書き換えます．
        /// </summary>
        /// <param name="mode">輪郭抽出モード</param>
        /// <param name="method">輪郭の近似手法</param>
        /// <param name="offset">オプションのオフセット．各輪郭点はこの値の分だけシフトします．これは，ROIの中で抽出された輪郭を，画像全体に対して位置づけて解析する場合に役立ちます．</param>
        /// <return>検出された輪郭．各輪郭は，点のベクトルとして格納されます．</return>
#else
        /// <summary>
        /// Finds contours in a binary image.
        /// The source is an 8-bit single-channel image. Non-zero pixels are treated as 1’s. 
        /// Zero pixels remain 0’s, so the image is treated as binary. The function modifies this image while extracting the contours.
        /// </summary>
        /// <param name="mode">Contour retrieval mode</param>
        /// <param name="method">Contour approximation method</param>
        /// <param name="offset"> Optional offset by which every contour point is shifted. 
        /// This is useful if the contours are extracted from the image ROI and then they should be analyzed in the whole image context.</param>
        /// <returns>Detected contours. Each contour is stored as a vector of points.</returns>
#endif
        public Point[][] FindContoursAsArray(RetrievalModes mode, ContourApproximationModes method, Point? offset = null)
        {
            return Cv2.FindContoursAsArray(this, mode, method, offset);
        }

#if LANG_JP
        /// <summary>
        /// 2値画像中の輪郭を検出します．
        /// 入力画像は，8ビット，シングルチャンネル．0以外のピクセルは 1として，0のピクセルは0のまま扱われます．
        /// また，この関数は，輪郭抽出処理中に入力画像の中身を書き換えます．
        /// </summary>
        /// <param name="mode">輪郭抽出モード</param>
        /// <param name="method">輪郭の近似手法</param>
        /// <param name="offset">オプションのオフセット．各輪郭点はこの値の分だけシフトします．これは，ROIの中で抽出された輪郭を，画像全体に対して位置づけて解析する場合に役立ちます．</param>
        /// <return>検出された輪郭．各輪郭は，点のベクトルとして格納されます．</return>
#else
        /// <summary>
        /// Finds contours in a binary image.
        /// The source is an 8-bit single-channel image. Non-zero pixels are treated as 1’s. 
        /// Zero pixels remain 0’s, so the image is treated as binary. The function modifies this image while extracting the contours.
        /// </summary>
        /// <param name="mode">Contour retrieval mode</param>
        /// <param name="method">Contour approximation method</param>
        /// <param name="offset"> Optional offset by which every contour point is shifted. 
        /// This is useful if the contours are extracted from the image ROI and then they should be analyzed in the whole image context.</param>
        /// <returns>Detected contours. Each contour is stored as a vector of points.</returns>
#endif
        public Mat<Point>[] FindContoursAsMat(RetrievalModes mode, ContourApproximationModes method, Point? offset = null)
        {
            return Cv2.FindContoursAsMat(this, mode, method, offset);
        }

#if LANG_JP
    /// <summary>
    /// 輪郭線，または内側が塗りつぶされた輪郭を描きます．
    /// </summary>
    /// <param name="contours"> 入力される全輪郭．各輪郭は，点のベクトルとして格納されています．</param>
    /// <param name="contourIdx">描かれる輪郭を示します．これが負値の場合，すべての輪郭が描画されます．</param>
    /// <param name="color">輪郭の色．</param>
    /// <param name="thickness">輪郭線の太さ．これが負値の場合（例えば thickness=CV_FILLED ），輪郭の内側が塗りつぶされます．</param>
    /// <param name="lineType">線の連結性</param>
    /// <param name="hierarchy">階層に関するオプションの情報．これは，特定の輪郭だけを描画したい場合にのみ必要になります．</param>
    /// <param name="maxLevel">描画される輪郭の最大レベル．0ならば，指定された輪郭のみが描画されます．
    /// 1ならば，指定された輪郭と，それに入れ子になったすべての輪郭が描画されます．2ならば，指定された輪郭と，
    /// それに入れ子になったすべての輪郭，さらにそれに入れ子になったすべての輪郭が描画されます．このパラメータは， 
    /// hierarchy が有効な場合のみ考慮されます．</param>
    /// <param name="offset">輪郭をシフトするオプションパラメータ．指定された offset = (dx,dy) だけ，すべての描画輪郭がシフトされます．</param>
#else
        /// <summary>
        /// Draws contours in the image
        /// </summary>
        /// <param name="contours">All the input contours. Each contour is stored as a point vector.</param>
        /// <param name="contourIdx">Parameter indicating a contour to draw. If it is negative, all the contours are drawn.</param>
        /// <param name="color">Color of the contours.</param>
        /// <param name="thickness">Thickness of lines the contours are drawn with. If it is negative (for example, thickness=CV_FILLED ), 
        /// the contour interiors are drawn.</param>
        /// <param name="lineType">Line connectivity. </param>
        /// <param name="hierarchy">Optional information about hierarchy. It is only needed if you want to draw only some of the contours</param>
        /// <param name="maxLevel">Maximal level for drawn contours. If it is 0, only the specified contour is drawn. 
        /// If it is 1, the function draws the contour(s) and all the nested contours. If it is 2, the function draws the contours, 
        /// all the nested contours, all the nested-to-nested contours, and so on. This parameter is only taken into account 
        /// when there is hierarchy available.</param>
        /// <param name="offset">Optional contour shift parameter. Shift all the drawn contours by the specified offset = (dx, dy)</param>
#endif
        public void DrawContours(
            IEnumerable<IEnumerable<Point>> contours,
            int contourIdx,
            Scalar color,
            int thickness = 1,
            LineTypes lineType = LineTypes.Link8,
            IEnumerable<HierarchyIndex>? hierarchy = null,
            int maxLevel = int.MaxValue,
            Point? offset = null)
        {
            Cv2.DrawContours(this, contours, contourIdx, color, 
                thickness, lineType, hierarchy, maxLevel, offset);
        }

#if LANG_JP
    /// <summary>
    /// 輪郭線，または内側が塗りつぶされた輪郭を描きます．
    /// </summary>
    /// <param name="contours"> 入力される全輪郭．各輪郭は，点のベクトルとして格納されています．</param>
    /// <param name="contourIdx">描かれる輪郭を示します．これが負値の場合，すべての輪郭が描画されます．</param>
    /// <param name="color">輪郭の色．</param>
    /// <param name="thickness">輪郭線の太さ．これが負値の場合（例えば thickness=CV_FILLED ），輪郭の内側が塗りつぶされます．</param>
    /// <param name="lineType">線の連結性</param>
    /// <param name="hierarchy">階層に関するオプションの情報．これは，特定の輪郭だけを描画したい場合にのみ必要になります．</param>
    /// <param name="maxLevel">描画される輪郭の最大レベル．0ならば，指定された輪郭のみが描画されます．
    /// 1ならば，指定された輪郭と，それに入れ子になったすべての輪郭が描画されます．2ならば，指定された輪郭と，
    /// それに入れ子になったすべての輪郭，さらにそれに入れ子になったすべての輪郭が描画されます．このパラメータは， 
    /// hierarchy が有効な場合のみ考慮されます．</param>
    /// <param name="offset">輪郭をシフトするオプションパラメータ．指定された offset = (dx,dy) だけ，すべての描画輪郭がシフトされます．</param>
#else
        /// <summary>
        /// Draws contours in the image
        /// </summary>
        /// <param name="contours">All the input contours. Each contour is stored as a point vector.</param>
        /// <param name="contourIdx">Parameter indicating a contour to draw. If it is negative, all the contours are drawn.</param>
        /// <param name="color">Color of the contours.</param>
        /// <param name="thickness">Thickness of lines the contours are drawn with. If it is negative (for example, thickness=CV_FILLED ), 
        /// the contour interiors are drawn.</param>
        /// <param name="lineType">Line connectivity. </param>
        /// <param name="hierarchy">Optional information about hierarchy. It is only needed if you want to draw only some of the contours</param>
        /// <param name="maxLevel">Maximal level for drawn contours. If it is 0, only the specified contour is drawn. 
        /// If it is 1, the function draws the contour(s) and all the nested contours. If it is 2, the function draws the contours, 
        /// all the nested contours, all the nested-to-nested contours, and so on. This parameter is only taken into account 
        /// when there is hierarchy available.</param>
        /// <param name="offset">Optional contour shift parameter. Shift all the drawn contours by the specified offset = (dx, dy)</param>
#endif
        public void DrawContours(
            IEnumerable<Mat> contours,
            int contourIdx,
            Scalar color,
            int thickness = 1,
            LineTypes lineType = LineTypes.Link8,
            Mat? hierarchy = null,
            int maxLevel = int.MaxValue,
            Point? offset = null)
        {
            Cv2.DrawContours(this, contours, contourIdx, color, 
                thickness, lineType, hierarchy, maxLevel, offset);
        }

        /// <summary>
        /// Approximates contour or a curve using Douglas-Peucker algorithm.
        /// The input is the polygon or curve to approximate and 
        /// it must be 1 x N or N x 1 matrix of type CV_32SC2 or CV_32FC2.
        /// </summary>
        /// <param name="epsilon">Specifies the approximation accuracy. 
        /// This is the maximum distance between the original curve and its approximation.</param>
        /// <param name="closed">The result of the approximation; 
        /// The type should match the type of the input curve</param>
        /// <returns>The result of the approximation; 
        /// The type should match the type of the input curve</returns>
// ReSharper disable once InconsistentNaming
        public Mat ApproxPolyDP(double epsilon, bool closed)
        {
            var dst = new Mat();
            Cv2.ApproxPolyDP(this, dst, epsilon, closed);
            return dst;
        }

        /// <summary>
        /// Calculates a contour perimeter or a curve length.
        /// The input is 2D point set, represented by CV_32SC2 or CV_32FC2 matrix.
        /// </summary>
        /// <param name="closed">Indicates, whether the curve is closed or not</param>
        /// <returns></returns>
        public double ArcLength(bool closed)
        {
            return Cv2.ArcLength(this, closed);
        }

        /// <summary>
        /// Calculates the up-right bounding rectangle of a point set.
        /// The input is 2D point set, represented by CV_32SC2 or CV_32FC2 matrix.
        /// </summary>
        /// <returns>Minimal up-right bounding rectangle for the specified point set.</returns>
        public Rect BoundingRect()
        {
            return Cv2.BoundingRect(this);
        }

        /// <summary>
        /// Calculates the contour area.
        /// The input is 2D point set, represented by CV_32SC2 or CV_32FC2 matrix.
        /// </summary>
        /// <param name="oriented"></param>
        /// <returns></returns>
        public double ContourArea(bool oriented = false)
        {
            return Cv2.ContourArea(this, oriented);
        }

        /// <summary>
        /// Finds the minimum area rotated rectangle enclosing a 2D point set.
        /// The input is 2D point set, represented by CV_32SC2 or CV_32FC2 matrix.
        /// </summary>
        /// <returns></returns>
        public RotatedRect MinAreaRect()
        {
            return Cv2.MinAreaRect(this);
        }

        /// <summary>
        /// Finds the minimum area circle enclosing a 2D point set.
        /// The input is 2D point set, represented by CV_32SC2 or CV_32FC2 matrix.
        /// </summary>
        /// <param name="center">The output center of the circle</param>
        /// <param name="radius">The output radius of the circle</param>
        public void MinEnclosingCircle(out Point2f center, out float radius)
        {
            Cv2.MinEnclosingCircle(this, out center, out radius);
        }

        /// <summary>
        /// Computes convex hull for a set of 2D points.
        /// </summary>
        /// <param name="clockwise">If true, the output convex hull will be oriented clockwise, 
        /// otherwise it will be oriented counter-clockwise. Here, the usual screen coordinate 
        /// system is assumed - the origin is at the top-left corner, x axis is oriented to the right, 
        /// and y axis is oriented downwards.</param>
        /// <param name="returnPoints"></param>
        /// <returns>The output convex hull. It is either a vector of points that form the 
        /// hull (must have the same type as the input points), or a vector of 0-based point 
        /// indices of the hull points in the original array (since the set of convex hull 
        /// points is a subset of the original point set).</returns>
        public Mat ConvexHull(bool clockwise = false, bool returnPoints = true)
        {
            var dst = new Mat();
            Cv2.ConvexHull(this, dst, clockwise, returnPoints);
            return dst;
        }

        /// <summary>
        /// Computes convex hull for a set of 2D points.
        /// </summary>
        /// <param name="clockwise">If true, the output convex hull will be oriented clockwise, 
        /// otherwise it will be oriented counter-clockwise. Here, the usual screen coordinate 
        /// system is assumed - the origin is at the top-left corner, x axis is oriented to the right, 
        /// and y axis is oriented downwards.</param>
        /// <returns>The output convex hull. It is a vector of points that form the 
        /// hull (must have the same type as the input points).</returns>
        public Point[] ConvexHullPoints(bool clockwise = false)
        {
            var dst = new Mat<Point>();
            Cv2.ConvexHull(this, dst, clockwise);
            return dst.ToArray();
        }

        /// <summary>
        /// Computes convex hull for a set of 2D points.
        /// </summary>
        /// <param name="clockwise">If true, the output convex hull will be oriented clockwise, 
        /// otherwise it will be oriented counter-clockwise. Here, the usual screen coordinate 
        /// system is assumed - the origin is at the top-left corner, x axis is oriented to the right, 
        /// and y axis is oriented downwards.</param>
        /// <returns>The output convex hull. It is a vector of points that form the 
        /// hull (must have the same type as the input points).</returns>
        public Point2f[] ConvexHullFloatPoints(bool clockwise = false)
        {
            var dst = new Mat<Point2f>();
            Cv2.ConvexHull(this, dst, clockwise);
            return dst.ToArray();
        }

        /// <summary>
        /// Computes convex hull for a set of 2D points.
        /// </summary>
        /// <param name="clockwise">If true, the output convex hull will be oriented clockwise, 
        /// otherwise it will be oriented counter-clockwise. Here, the usual screen coordinate 
        /// system is assumed - the origin is at the top-left corner, x axis is oriented to the right, 
        /// and y axis is oriented downwards.</param>
        /// <returns>The output convex hull. It is a vector of 0-based point 
        /// indices of the hull points in the original array (since the set of convex hull 
        /// points is a subset of the original point set).</returns>
        public int[] ConvexHullIndices(bool clockwise = false)
        {
            var dst = new Mat<int>();
            Cv2.ConvexHull(this, dst, clockwise, false);
            return dst.ToArray();
        }

        /// <summary>
        /// Computes the contour convexity defects
        /// </summary>
        /// <param name="convexHull">Convex hull obtained using convexHull() that 
        /// should contain indices of the contour points that make the hull.</param>
        /// <returns>The output vector of convexity defects. 
        /// Each convexity defect is represented as 4-element integer vector 
        /// (a.k.a. cv::Vec4i): (start_index, end_index, farthest_pt_index, fixpt_depth), 
        /// where indices are 0-based indices in the original contour of the convexity defect beginning, 
        /// end and the farthest point, and fixpt_depth is fixed-point approximation 
        /// (with 8 fractional bits) of the distance between the farthest contour point and the hull. 
        /// That is, to get the floating-point value of the depth will be fixpt_depth/256.0. </returns>
        public Mat ConvexityDefects(InputArray convexHull)
        {
            var dst = new Mat();
            Cv2.ConvexityDefects(this, convexHull, dst);
            return dst;
        }

        /// <summary>
        /// Computes the contour convexity defects
        /// </summary>
        /// <param name="convexHull">Convex hull obtained using convexHull() that 
        /// should contain indices of the contour points that make the hull.</param>
        /// <returns>The output vector of convexity defects. 
        /// Each convexity defect is represented as 4-element integer vector 
        /// (a.k.a. cv::Vec4i): (start_index, end_index, farthest_pt_index, fixpt_depth), 
        /// where indices are 0-based indices in the original contour of the convexity defect beginning, 
        /// end and the farthest point, and fixpt_depth is fixed-point approximation 
        /// (with 8 fractional bits) of the distance between the farthest contour point and the hull. 
        /// That is, to get the floating-point value of the depth will be fixpt_depth/256.0. </returns>
        public Vec4i[] ConvexityDefectsAsVec(InputArray convexHull)
        {
            var dst = new Mat<Vec4i>();
            Cv2.ConvexityDefects(this, convexHull, dst);
            return dst.ToArray();
        }

        /// <summary>
        /// Returns true if the contour is convex. 
        /// Does not support contours with self-intersection
        /// </summary>
        /// <returns></returns>
        public bool IsContourConvex()
        {
            return Cv2.IsContourConvex(this);
        }

        /// <summary>
        /// Fits ellipse to the set of 2D points.
        /// </summary>
        /// <returns></returns>
        public RotatedRect FitEllipse()
        {
            return Cv2.FitEllipse(this);
        }

        /// <summary>
        /// Fits line to the set of 2D points using M-estimator algorithm.
        /// The input is vector of 2D points.
        /// </summary>
        /// <param name="distType">Distance used by the M-estimator</param>
        /// <param name="param">Numerical parameter ( C ) for some types of distances. 
        /// If it is 0, an optimal value is chosen.</param>
        /// <param name="reps">Sufficient accuracy for the radius 
        /// (distance between the coordinate origin and the line).</param>
        /// <param name="aeps">Sufficient accuracy for the angle. 
        /// 0.01 would be a good default value for reps and aeps.</param>
        /// <returns>Output line parameters.</returns>
        public Line2D FitLine2D(DistanceTypes distType, double param, double reps, double aeps)
        {
            var line = new Mat<float>();
            Cv2.FitLine(this, line, distType, param, reps, aeps);
            return new Line2D(line.ToArray());
        }

        /// <summary>
        /// Fits line to the set of 3D points using M-estimator algorithm.
        /// The input is vector of 3D points.
        /// </summary>
        /// <param name="distType">Distance used by the M-estimator</param>
        /// <param name="param">Numerical parameter ( C ) for some types of distances. 
        /// If it is 0, an optimal value is chosen.</param>
        /// <param name="reps">Sufficient accuracy for the radius 
        /// (distance between the coordinate origin and the line).</param>
        /// <param name="aeps">Sufficient accuracy for the angle. 
        /// 0.01 would be a good default value for reps and aeps.</param>
        /// <returns>Output line parameters.</returns>
        public Line3D FitLine3D(DistanceTypes distType, double param, double reps, double aeps)
        {
            var line = new Mat<float>();
            Cv2.FitLine(this, line, distType, param, reps, aeps);
            return new Line3D(line.ToArray());
        }

        /// <summary>
        /// Checks if the point is inside the contour. 
        /// Optionally computes the signed distance from the point to the contour boundary.
        /// </summary>
        /// <param name="pt">Point tested against the contour.</param>
        /// <param name="measureDist">If true, the function estimates the signed distance 
        /// from the point to the nearest contour edge. Otherwise, the function only checks 
        /// if the point is inside a contour or not.</param>
        /// <returns>Positive (inside), negative (outside), or zero (on an edge) value.</returns>
        public double PointPolygonTest(Point2f pt, bool measureDist)
        {
            return Cv2.PointPolygonTest(this, pt, measureDist);
        }

        /// <summary>
        /// Computes the distance transform map
        /// </summary>
        /// <param name="distanceType"></param>
        /// <param name="maskSize"></param>
        public Mat<float> DistanceTransform(DistanceTypes distanceType, DistanceMaskSize maskSize)
        {
            var dst = new Mat<float>();
            Cv2.DistanceTransform(this, dst, distanceType, maskSize);
            return dst;
        }

        #endregion
    }
}
