using System;

namespace OpenCvSharp
{
    // ReSharper disable InconsistentNaming

    partial class CvArr
    {
        #region AbsDiff
#if LANG_JP
        /// <summary>
        /// 二つの配列の要素ごとの差の絶対値を計算する.
        /// dst(I) = abs(src1(I) - src2(I)).
        /// </summary>
        /// <param name="src2">2番目の入力画像</param>
        /// <param name="dst">出力画像</param>
#else
        /// <summary>
        /// Calculates absolute difference between two arrays
        /// </summary>
        /// <param name="src2">The second source array. </param>
        /// <param name="dst">The destination array. </param>
#endif
        public void AbsDiff(CvArr src2, CvArr dst)
        {
            Cv.AbsDiff(this, src2, dst);
        }
        #endregion
        #region AbsDiffS
#if LANG_JP
        /// <summary>
        /// 配列の要素の絶対値を計算する. 
        /// dst(I) = abs(src(I)).
        /// すべての配列は同じタイプ，同じサイズ（または同じROIサイズ）でなければならない．
        /// </summary>
        /// <param name="dst">出力画像</param>
#else
        /// <summary>
        /// Calculates absolute difference between array and scalar
        /// </summary>
        /// <param name="dst">The destination array. </param>
#endif
        public void Abs(CvArr dst)
        {
            Cv.Abs(this, dst);
        }
#if LANG_JP
        /// <summary>
        /// 配列の要素と定数との差の絶対値を計算する. 
        /// dst(I) = abs(src(I) - value).
        /// </summary>
        /// <param name="dst">出力画像</param>
        /// <param name="value">スカラー</param>
#else
        /// <summary>
        /// Calculates absolute difference between array and scalar
        /// </summary>
        /// <param name="dst">The destination array. </param>
        /// <param name="value">The scalar. </param>
#endif
        public void AbsDiffS(CvArr dst, CvScalar value)
        {
            Cv.AbsDiffS(this, dst, value);
        }
        #endregion
        #region Acc
#if LANG_JP
        /// <summary>
        /// アキュムレータにフレームを加算する
        /// </summary>
        /// <param name="sum">入力画像と同じチャンネル数のアキュムレータ，32 ビットあるいは 64 ビット浮動小数点型．</param>
#else
        /// <summary>
        /// Adds frame to accumulator
        /// </summary>
        /// <param name="sum">Accumulator of the same number of channels as input image, 32-bit or 64-bit floating-point. </param>
#endif
        public void Acc(CvArr sum)
        {
            Cv.Acc(this, sum);
        }
#if LANG_JP
        /// <summary>
        /// アキュムレータにフレームを加算する
        /// </summary>
        /// <param name="sum">入力画像と同じチャンネル数のアキュムレータ，32 ビットあるいは 64 ビット浮動小数点型．</param>
        /// <param name="mask">オプションの処理マスク．</param>
#else
        /// <summary>
        /// Adds frame to accumulator
        /// </summary>
        /// <param name="sum">Accumulator of the same number of channels as input image, 32-bit or 64-bit floating-point. </param>
        /// <param name="mask">Optional operation mask. </param>
#endif
        public void Acc(CvArr sum, CvArr mask)
        {
            Cv.Acc(this, sum, mask);
        }
        #endregion
        #region AdaptiveThreshold
#if LANG_JP
        /// <summary>
        /// 適応的な閾値処理を行い、グレースケール画像を2値画像に変換する
        /// </summary>
        /// <param name="dst">出力画像</param>
        /// <param name="maxValue">threshold_type がBinaryあるいはBinaryInvのときに用いる最大値</param>
#else
        /// <summary>
        /// Applies adaptive threshold to array.
        /// </summary>
        /// <param name="dst">Destination image. </param>
        /// <param name="maxValue">Maximum value that is used with CV_THRESH_BINARY and CV_THRESH_BINARY_INV. </param>
#endif
        public void AdaptiveThreshold(CvArr dst, double maxValue)
        {
            Cv.AdaptiveThreshold(this, dst, maxValue);
        }
#if LANG_JP
        /// <summary>
        /// 適応的な閾値処理を行い、グレースケール画像を2値画像に変換する
        /// </summary>
        /// <param name="dst">出力画像</param>
        /// <param name="maxValue">threshold_type がBinaryあるいはBinaryInvのときに用いる最大値</param>
        /// <param name="adaptiveMethod">適応的閾値処理で使用するアルゴリズム</param>
#else
        /// <summary>
        /// Applies adaptive threshold to array.
        /// </summary>
        /// <param name="dst">Destination image. </param>
        /// <param name="maxValue">Maximum value that is used with CV_THRESH_BINARY and CV_THRESH_BINARY_INV. </param>
        /// <param name="adaptiveMethod">Adaptive thresholding algorithm to use: CV_ADAPTIVE_THRESH_MEAN_C or CV_ADAPTIVE_THRESH_GAUSSIAN_C.</param>
#endif
        public void AdaptiveThreshold(CvArr dst, double maxValue, AdaptiveThresholdType adaptiveMethod)
        {
            Cv.AdaptiveThreshold(this, dst, maxValue, adaptiveMethod);
        }
#if LANG_JP
        /// <summary>
        /// 適応的な閾値処理を行い、グレースケール画像を2値画像に変換する
        /// </summary>
        /// <param name="dst">出力画像</param>
        /// <param name="maxValue">threshold_type がBinaryあるいはBinaryInvのときに用いる最大値</param>
        /// <param name="adaptiveMethod">適応的閾値処理で使用するアルゴリズム</param>
        /// <param name="thresholdType">閾値処理の種類. BinaryかBinaryInvのどちらか</param>
#else
        /// <summary>
        /// Applies adaptive threshold to array.
        /// </summary>
        /// <param name="dst">Destination image. </param>
        /// <param name="maxValue">Maximum value that is used with CV_THRESH_BINARY and CV_THRESH_BINARY_INV. </param>
        /// <param name="adaptiveMethod">Adaptive thresholding algorithm to use: CV_ADAPTIVE_THRESH_MEAN_C or CV_ADAPTIVE_THRESH_GAUSSIAN_C.</param>
        /// <param name="thresholdType">Thresholding type.</param>
#endif
        public void AdaptiveThreshold(CvArr dst, double maxValue, AdaptiveThresholdType adaptiveMethod, ThresholdType thresholdType)
        {
            Cv.AdaptiveThreshold(this, dst, maxValue, adaptiveMethod, thresholdType);
        }
#if LANG_JP
        /// <summary>
        /// 適応的な閾値処理を行い、グレースケール画像を2値画像に変換する
        /// </summary>
        /// <param name="dst">出力画像</param>
        /// <param name="maxValue">threshold_type がBinaryあるいはBinaryInvのときに用いる最大値</param>
        /// <param name="adaptiveMethod">適応的閾値処理で使用するアルゴリズム</param>
        /// <param name="thresholdType">閾値処理の種類. BinaryかBinaryInvのどちらか</param>
        /// <param name="blockSize">ピクセルの閾値を計算するために用いる隣接領域のサイズ： 3, 5, 7, ... </param>
#else
        /// <summary>
        /// Applies adaptive threshold to array.
        /// </summary>
        /// <param name="dst">Destination image. </param>
        /// <param name="maxValue">Maximum value that is used with CV_THRESH_BINARY and CV_THRESH_BINARY_INV. </param>
        /// <param name="adaptiveMethod">Adaptive thresholding algorithm to use: CV_ADAPTIVE_THRESH_MEAN_C or CV_ADAPTIVE_THRESH_GAUSSIAN_C.</param>
        /// <param name="thresholdType">Thresholding type.</param>
        /// <param name="blockSize">The size of a pixel neighborhood that is used to calculate a threshold value for the pixel: 3, 5, 7, ... </param>
#endif
        public void AdaptiveThreshold(CvArr dst, double maxValue, AdaptiveThresholdType adaptiveMethod, ThresholdType thresholdType, int blockSize)
        {
            Cv.AdaptiveThreshold(this, dst, maxValue, adaptiveMethod, thresholdType, blockSize);
        }
#if LANG_JP
        /// <summary>
        /// 適応的な閾値処理を行い、グレースケール画像を2値画像に変換する
        /// </summary>
        /// <param name="dst">出力画像</param>
        /// <param name="maxValue">threshold_type がBinaryあるいはBinaryInvのときに用いる最大値</param>
        /// <param name="adaptiveMethod">適応的閾値処理で使用するアルゴリズム</param>
        /// <param name="thresholdType">閾値処理の種類. BinaryかBinaryInvのどちらか</param>
        /// <param name="blockSize">ピクセルの閾値を計算するために用いる隣接領域のサイズ： 3, 5, 7, ... </param>
        /// <param name="param1">各適応手法に応じたパラメータ. 適応手法がMeanCおよびGaussianCの場合は，平均値または重み付き平均値から引く定数. 負の値の場合もある.</param>
#else
        /// <summary>
        /// Applies adaptive threshold to array.
        /// </summary>
        /// <param name="dst">Destination image. </param>
        /// <param name="maxValue">Maximum value that is used with CV_THRESH_BINARY and CV_THRESH_BINARY_INV. </param>
        /// <param name="adaptiveMethod">Adaptive thresholding algorithm to use: CV_ADAPTIVE_THRESH_MEAN_C or CV_ADAPTIVE_THRESH_GAUSSIAN_C.</param>
        /// <param name="thresholdType">Thresholding type.</param>
        /// <param name="blockSize">The size of a pixel neighborhood that is used to calculate a threshold value for the pixel: 3, 5, 7, ... </param>
        /// <param name="param1">The method-dependent parameter. For the methods CV_ADAPTIVE_THRESH_MEAN_C and CV_ADAPTIVE_THRESH_GAUSSIAN_C it is a constant subtracted from mean or weighted mean (see the discussion), though it may be negative. </param>
#endif
        public void AdaptiveThreshold(CvArr dst, double maxValue, AdaptiveThresholdType adaptiveMethod, ThresholdType thresholdType, int blockSize, double param1)
        {
            Cv.AdaptiveThreshold(this, dst, maxValue, adaptiveMethod, thresholdType, blockSize, param1);
        }
        #endregion
        #region Add
#if LANG_JP
        /// <summary>
        /// 二つの配列を要素ごとに加算する. 
        /// dst(I)=src1(I)+src2(I)
        /// </summary>
        /// <param name="src2">2番目の入力配列</param>
        /// <param name="dst">出力配列</param>
#else
        /// <summary>
        /// Computes per-element sum of two arrays
        /// </summary>
        /// <param name="src2">The second source array. </param>
        /// <param name="dst">The destination array. </param>
#endif
        public void Add(CvArr src2, CvArr dst)
        {
            Cv.Add(this, src2, dst);
        }
#if LANG_JP
        /// <summary>
        /// 二つの配列を要素ごとに加算する. 
        /// dst(I)=src1(I)+src2(I) [mask(I)!=0の場合]
        /// </summary>
        /// <param name="src2">2番目の入力配列</param>
        /// <param name="dst">出力配列</param>
        /// <param name="mask">処理マスク．8ビットシングルチャンネル配列（出力配列のどの要素が変更されるかを指定する）． </param>
#else
        /// <summary>
        /// Computes per-element sum of two arrays
        /// </summary>
        /// <param name="src2">The second source array. </param>
        /// <param name="dst">The destination array. </param>
        /// <param name="mask">Operation mask, 8-bit single channel array; specifies elements of destination array to be changed. </param>
#endif
        public void Add(CvArr src2, CvArr dst, CvArr mask)
        {
            Cv.Add(this, src2, dst, mask);
        }
        #endregion
        #region AddS
#if LANG_JP
        /// <summary>
        /// 入力配列 src1 のすべての要素にスカラー value を加え，結果を dst に保存する．
        /// dst(I)=src(I)+value
        /// </summary>
        /// <param name="value">加算するスカラー</param>
        /// <param name="dst">出力配列</param>
#else
        /// <summary>
        /// Computes sum of array and scalar
        /// </summary>
        /// <param name="value">Added scalar. </param>
        /// <param name="dst">The destination array. </param>
#endif
        public void AddS(CvScalar value, CvArr dst)
        {
            Cv.AddS(this, value, dst);
        }
#if LANG_JP
        /// <summary>
        /// 入力配列 src1 のすべての要素にスカラー value を加え，結果を dst に保存する．
        /// dst(I)=src(I)+value [mask(I)!=0 の場合]
        /// </summary>
        /// <param name="value">加算するスカラー</param>
        /// <param name="dst">出力配列</param>
        /// <param name="mask">処理マスク．8ビットシングルチャンネル配列（出力配列のどの要素が変更されるかを指定する）．</param>
#else
        /// <summary>
        /// Computes sum of array and scalar
        /// </summary>
        /// <param name="value">Added scalar. </param>
        /// <param name="dst">The destination array. </param>
        /// <param name="mask">Operation mask, 8-bit single channel array; specifies elements of destination array to be changed. </param>
#endif
        public void AddS(CvScalar value, CvArr dst, CvArr mask)
        {
            Cv.AddS(this, value, dst, mask);
        }
        #endregion
        #region AddText
#if LANG_JP
        /// <summary>
        /// 画像上にテキストを描画します．
        /// </summary>
        /// <param name="text">画像上に描画されるテキスト．</param>
        /// <param name="location">画像上のテキストの開始位置 Point(x,y)．</param>
        /// <param name="font">テキストを描画するのに利用されるフォント．</param>
#else
        /// <summary>
        /// Create the font to be used to draw text on an image
        /// </summary>
        /// <param name="text">Text to write on the image</param>
        /// <param name="location">Point(x,y) where the text should start on the image</param>
        /// <param name="font">Font to use to draw the text</param>
#endif
        public void AddText(string text, CvPoint location, CvFont font)
        {
            Cv.AddText(this, text, location, font);
        }
        #endregion
        #region AddWeighted
#if LANG_JP
        /// <summary>
        /// 入力配列 src1 のすべての要素にスカラー value を加え，結果を dst に保存する．
        /// dst(I) = src1(I)*alpha + src2(I)*beta + gamma
        /// </summary>
        /// <param name="alpha">1番目の配列要素への重み</param>
        /// <param name="src2">2番目の入力配列スカラー</param>
        /// <param name="beta">2番目の配列要素への重み</param>
        /// <param name="gamma">加算結果に，さらに加えられるスカラー値</param>
        /// <param name="dst">出力配列</param>
#else
        /// <summary>
        /// Computes weighted sum of two arrays
        /// </summary>
        /// <param name="alpha">Weight of the first array elements. </param>
        /// <param name="src2">The second source array. </param>
        /// <param name="beta">Weight of the second array elements. </param>
        /// <param name="gamma">Scalar, added to each sum. </param>
        /// <param name="dst">The destination array. </param>
#endif
        public void AddWeighted(double alpha, CvArr src2, double beta, double gamma, CvArr dst)
        {
            Cv.AddWeighted(this, alpha, src2, beta, gamma, dst);
        }
        #endregion
        #region And
#if LANG_JP
        /// <summary>
        /// 二つの配列の要素ごとの論理積（AND）を計算する. 
        /// dst(I)=src1(I)&amp;src2(I)
        /// </summary>
        /// <param name="src2">2番目の入力配列</param>
        /// <param name="dst">出力配列</param>
#else
        /// <summary>
        /// Calculates per-element bit-wise conjunction of two arrays
        /// </summary>
        /// <param name="src2">The second source array. </param>
        /// <param name="dst">The destination array. </param>
#endif
        public void And(CvArr src2, CvArr dst)
        {
            Cv.And(this, src2, dst);
        }
#if LANG_JP
        /// <summary>
        /// 二つの配列の要素ごとの論理積（AND）を計算する. 
        /// dst(I)=src1(I)&amp;src2(I) [mask(I)!=0の場合]
        /// </summary>
        /// <param name="src2">2番目の入力配列</param>
        /// <param name="dst">出力配列</param>
        /// <param name="mask">処理マスク．8ビットシングルチャンネル配列（出力配列のどの要素が変更されるかを指定する）． </param>
#else
        /// <summary>
        /// Calculates per-element bit-wise conjunction of two arrays
        /// </summary>
        /// <param name="src2">The second source array. </param>
        /// <param name="dst">The destination array. </param>
        /// <param name="mask">Operation mask, 8-bit single channel array; specifies elements of destination array to be changed. </param>
#endif
        public void And(CvArr src2, CvArr dst, CvArr mask)
        {
            Cv.And(this, src2, dst, mask);
        }
        #endregion
        #region AndS
#if LANG_JP
        /// <summary>
        /// 配列の各要素とスカラーとのビット単位の論理積(AND)を計算する. 
        /// 実際の計算の前に，スカラーは配列と同じタイプに変換される．浮動小数点型配列の場合，それらのビット表現が処理に使われる．
        /// dst(I)=src(I)&amp;value
        /// </summary>
        /// <param name="value">処理に用いるスカラー</param>
        /// <param name="dst">出力配列</param>
#else
        /// <summary>
        /// Calculates per-element bit-wise conjunction of array and scalar
        /// </summary>
        /// <param name="value">Scalar to use in the operation. </param>
        /// <param name="dst">The destination array. </param>
#endif
        public void AndS(CvScalar value, CvArr dst)
        {
            Cv.AndS(this, value, dst);
        }
#if LANG_JP
        /// <summary>
        /// 配列の各要素とスカラーとのビット単位の論理積(AND)を計算する. 
        /// 実際の計算の前に，スカラーは配列と同じタイプに変換される．浮動小数点型配列の場合，それらのビット表現が処理に使われる．
        /// dst(I)=src(I)&amp;value [mask(I)!=0の場合]
        /// </summary>
        /// <param name="value">処理に用いるスカラー</param>
        /// <param name="dst">出力配列</param>
        /// <param name="mask">処理マスク．8ビットシングルチャンネル配列（出力配列のどの要素が変更されるかを指定する）．</param>
#else
        /// <summary>
        /// Calculates per-element bit-wise conjunction of array and scalar
        /// </summary>
        /// <param name="value">Scalar to use in the operation. </param>
        /// <param name="dst">The destination array. </param>
        /// <param name="mask">Operation mask, 8-bit single channel array; specifies elements of destination array to be changed. </param>
#endif
        public void AndS(CvScalar value, CvArr dst, CvArr mask)
        {
            Cv.AndS(this, value, dst, mask);
        }
        #endregion
        #region ArcLength
#if LANG_JP
        /// <summary>
        /// 輪郭の周囲長または曲線の長さを計算する
        /// </summary>
        /// <returns>輪郭の周囲長または曲線の長さ</returns>
#else
        /// <summary>
        /// Calculates contour perimeter or curve length
        /// </summary>
        /// <returns></returns>
#endif
        public double ArcLength()
        {
            return Cv.ArcLength(this);
        }
#if LANG_JP
        /// <summary>
        /// 輪郭の周囲長または曲線の長さを計算する
        /// </summary>
        /// <param name="slice">曲線の始点と終点．デフォルトでは曲線の全ての長さが計算される．</param>
        /// <returns>輪郭の周囲長または曲線の長さ</returns>
#else
        /// <summary>
        /// Calculates contour perimeter or curve length
        /// </summary>
        /// <param name="slice">Starting and ending points of the curve, by default the whole curve length is calculated. </param>
        /// <returns></returns>
#endif
        public double ArcLength(CvSlice slice)
        {
            return Cv.ArcLength(this, slice);
        }
#if LANG_JP
        /// <summary>
        /// 輪郭の周囲長または曲線の長さを計算する
        /// </summary>
        /// <param name="slice">曲線の始点と終点．デフォルトでは曲線の全ての長さが計算される．</param>
        /// <param name="isClosed">閉曲線かどうかを示す．次の3つの状態がある： 
        /// is_closed=0 - 曲線は閉曲線として扱われない． 
        /// is_closed&gt;0 - 曲線は閉曲線として扱われる． 
        /// is_closed&lt;0 - 曲線がシーケンスの場合， ((CvSeq*)curve)-&gt;flagsのフラグCV_SEQ_FLAG_CLOSEDから閉曲線かどうかを判別する．そうでない（曲線が点の配列（CvMat*）で表現される）場合，閉曲線として扱われない． 
        /// </param>
        /// <returns>輪郭の周囲長または曲線の長さ</returns>
#else
        /// <summary>
        /// Calculates contour perimeter or curve length
        /// </summary>
        /// <param name="slice">Starting and ending points of the curve, by default the whole curve length is calculated. </param>
        /// <param name="isClosed">Indicates whether the curve is closed or not. There are 3 cases:
        /// * is_closed=0 - the curve is assumed to be unclosed.
        /// * is_closed&gt;0 - the curve is assumed to be closed.
        /// * is_closed&lt;0 - if curve is sequence, the flag CV_SEQ_FLAG_CLOSED of ((CvSeq*)curve)-&gt;flags is checked to determine if the curve is closed or not, otherwise (curve is represented by array (CvMat*) of points) it is assumed to be unclosed. </param>
        /// <returns></returns>
#endif
        public double ArcLength(CvSlice slice, int isClosed)
        {
            return Cv.ArcLength(this, slice, isClosed);
        }
        #endregion
        #region Avg
#if LANG_JP
        /// <summary>
        /// 配列要素の平均値を各チャンネルで独立に計算する．
        /// </summary>
        /// <returns>平均値</returns>
#else
        /// <summary>
        /// Calculates average (mean) of array elements
        /// </summary>
        /// <returns></returns>
#endif
        public CvScalar Avg()
        {
            return Cv.Avg(this, null);
        }
#if LANG_JP
        /// <summary>
        /// 配列要素の平均値を各チャンネルで独立に計算する．
        /// </summary>
        /// <param name="mask">オプションの処理マスク</param>
        /// <returns>平均値</returns>
#else
        /// <summary>
        /// Calculates average (mean) of array elements
        /// </summary>
        /// <param name="mask">The optional operation mask. </param>
        /// <returns></returns>
#endif
        public CvScalar Avg(CvArr mask)
        {
            return Cv.Avg(this, mask);
        }
        #endregion
        #region AvgSdv
#if LANG_JP
        /// <summary>
        /// 配列要素の平均と標準偏差を各チャンネルで独立に計算する．
        /// </summary>
        /// <param name="mean">計算結果の平均値の出力</param>
        /// <param name="stdDev">計算結果の標準偏差の出力</param>
#else
        /// <summary>
        /// Calculates average (mean) of array elements
        /// </summary>
        /// <param name="mean">Pointer to the mean value, may be null if it is not needed. </param>
        /// <param name="stdDev">Pointer to the standard deviation. </param>
#endif
        public void AvgSdv(out CvScalar mean, out CvScalar stdDev)
        {
            Cv.AvgSdv(this, out mean, out stdDev, null);
        }
#if LANG_JP
        /// <summary>
        /// 配列要素の平均と標準偏差を各チャンネルで独立に計算する．
        /// </summary>
        /// <param name="mean">計算結果の平均値の出力</param>
        /// <param name="stdDev">計算結果の標準偏差の出力</param>
        /// <param name="mask">オプションの処理マスク</param>
#else
        /// <summary>
        /// Calculates average (mean) of array elements
        /// </summary>
        /// <param name="mean">Pointer to the mean value, may be null if it is not needed. </param>
        /// <param name="stdDev">Pointer to the standard deviation. </param>
        /// <param name="mask">The optional operation mask. </param>
#endif
        public void AvgSdv(out CvScalar mean, out CvScalar stdDev, CvArr mask)
        {
            Cv.AvgSdv(this, out mean, out stdDev, mask);
        }
        #endregion
        #region BoundingRect
#if LANG_JP
        /// <summary>
        /// 2次元点列を包含するまっすぐな矩形を返す．
        /// </summary>
        /// <returns>矩形</returns>
#else
        /// <summary>
        /// Calculates up-right bounding rectangle of point set.
        /// </summary>
        /// <returns></returns>
#endif
        public CvRect BoundingRect()
        {
            return Cv.BoundingRect(this);
        }
#if LANG_JP
        /// <summary>
        /// 2次元点列を包含するまっすぐな矩形を返す．
        /// </summary>
        /// <param name="update">更新フラグ. 
        /// pointsがCvContour で，update=falseの場合： 包含矩形は計算されず，輪郭ヘッダのrectフィールドから読み込まれる． 
        /// pointsがCvContour で，update=trueの場合： 包含矩形は計算され，輪郭ヘッダのrectフィールドに書き込まれる． 
        /// pointsがCvSeqかCvMatの場合： updateは無視されて，包含矩形は計算されて返される． </param>
        /// <returns>矩形</returns>
#else
        /// <summary>
        /// Calculates up-right bounding rectangle of point set.
        /// </summary>
        /// <param name="update">The update flag. Here is list of possible combination of the flag values and type of contour:
        /// * points is CvContour*, update=0: the bounding rectangle is not calculated, but it is read from rect field of the contour header.
        /// * points is CvContour*, update=1: the bounding rectangle is calculated and written to rect field of the contour header. For example, this mode is used by cvFindContours.
        /// * points is CvSeq* or CvMat*: update is ignored, the bounding rectangle is calculated and returned. </param>
        /// <returns></returns>
#endif
        public CvRect BoundingRect(bool update)
        {
            return Cv.BoundingRect(this, update);
        }
        #endregion
        #region Canny
#if LANG_JP
        /// <summary>
        /// Cannyアルゴリズムを使用して，入力画像 imageに含まれているエッジを検出し，それを出力画像 edges に保存する [aperture_size=3]． 
        /// threshold1 と threshold2 のうち小さいほうがエッジ同士を接続するために用いられ，大きいほうが強いエッジの初期検出に用いられる． 
        /// </summary>
        /// <param name="edges">この関数によって得られたエッジ画像</param>
        /// <param name="threshold1">１番目の閾値</param>
        /// <param name="threshold2">２番目の閾値</param>
#else
        /// <summary>
        /// Finds the edges on the input image image and marks them in the output image edges using the Canny algorithm. 
        /// The smallest of threshold1 and threshold2 is used for edge linking, the largest - to find initial segments of strong edges.
        /// </summary>
        /// <param name="edges">Image to store the edges found by the function. </param>
        /// <param name="threshold1">The first threshold. </param>
        /// <param name="threshold2">The second threshold. </param>
#endif
        public void Canny(CvArr edges, double threshold1, double threshold2)
        {
            Cv.Canny(this, edges, threshold1, threshold2, ApertureSize.Size3);
        }
#if LANG_JP
        /// <summary>
        /// Cannyアルゴリズムを使用して，入力画像 imageに含まれているエッジを検出し，それを出力画像 edges に保存する． 
        /// threshold1 と threshold2 のうち小さいほうがエッジ同士を接続するために用いられ，大きいほうが強いエッジの初期検出に用いられる． 
        /// </summary>
        /// <param name="edges">この関数によって得られたエッジ画像</param>
        /// <param name="threshold1">１番目の閾値</param>
        /// <param name="threshold2">２番目の閾値</param>
        /// <param name="apertureSize">Sobel演算子のアパーチャサイズ</param>
#else
        /// <summary>
        /// Finds the edges on the input image image and marks them in the output image edges using the Canny algorithm. 
        /// The smallest of threshold1 and threshold2 is used for edge linking, the largest - to find initial segments of strong edges.
        /// </summary>
        /// <param name="edges">Image to store the edges found by the function. </param>
        /// <param name="threshold1">The first threshold. </param>
        /// <param name="threshold2">The second threshold. </param>
        /// <param name="apertureSize">Aperture parameter for Sobel operator. </param>
#endif
        public void Canny(CvArr edges, double threshold1, double threshold2, ApertureSize apertureSize)
        {
            Cv.Canny(this, edges, threshold1, threshold2, apertureSize);
        }
        #endregion
        #region CheckArr
#if LANG_JP
        /// <summary>
        /// 入力配列のすべての要素について，無効な値が存在しないかをチェックする 
        /// </summary>
        /// <returns>チェックが正しく終わればtrue</returns>
#else
        /// <summary>
        /// Checks every element of input array for invalid values
        /// </summary>
        /// <returns>returns nonzero if the check succeeded, i.e. all elements are valid and within the range, and zero otherwise.</returns>
#endif
        public bool CheckArr()
        {

            return Cv.CheckArr(this);
        }
#if LANG_JP
        /// <summary>
        /// 入力配列のすべての要素について，無効な値が存在しないかをチェックする 
        /// </summary>
        /// <param name="flags">処理フラグ</param>
        /// <returns>チェックが正しく終わればtrue</returns>
#else
        /// <summary>
        /// Checks every element of input array for invalid values
        /// </summary>
        /// <param name="flags">The operation flags</param>
        /// <returns>returns nonzero if the check succeeded, i.e. all elements are valid and within the range, and zero otherwise.</returns>
#endif
        public bool CheckArr(CheckArrFlag flags)
        {
            return Cv.CheckArr(this, flags);
        }
#if LANG_JP
        /// <summary>
        /// 入力配列のすべての要素について，無効な値が存在しないかをチェックする
        /// </summary>
        /// <param name="flags">処理フラグ</param>
        /// <param name="minVal">有効な値域の下限値(この値以上)．CheckArrFlag.Range がセットされているときのみ有効．</param>
        /// <param name="maxVal">有効な値域の上限値(この値未満)．CheckArrFlag.Range がセットされているときのみ有効．</param>
        /// <returns>チェックが正しく終わればtrue</returns>
#else
        /// <summary>
        /// Checks every element of input array for invalid values
        /// </summary>
        /// <param name="flags">The operation flags</param>
        /// <param name="minVal">The inclusive lower boundary of valid values range. It is used only if CV_CHECK_RANGE is set. </param>
        /// <param name="maxVal">The exclusive upper boundary of valid values range. It is used only if CV_CHECK_RANGE is set. </param>
        /// <returns>returns nonzero if the check succeeded, i.e. all elements are valid and within the range, and zero otherwise.</returns>
#endif
        public bool CheckArr(CheckArrFlag flags, double minVal, double maxVal)
        {
            return Cv.CheckArr(this, flags, minVal, maxVal);
        }
#if LANG_JP
        /// <summary>
        /// 入力配列のすべての要素について，無効な値が存在しないかをチェックする. CheckArrのエイリアス.
        /// </summary>
        /// <returns>チェックが正しく終わればtrue</returns>
#else
        /// <summary>
        /// Checks every element of input array for invalid values
        /// </summary>
        /// <returns>returns nonzero if the check succeeded, i.e. all elements are valid and within the range, and zero otherwise.</returns>
#endif
        public bool CheckArray()
        {
            return Cv.CheckArray(this);
        }
#if LANG_JP
        /// <summary>
        /// 入力配列のすべての要素について，無効な値が存在しないかをチェックする. CheckArrのエイリアス. 
        /// </summary>
        /// <param name="flags">処理フラグ</param>
        /// <returns>チェックが正しく終わればtrue</returns>
#else
        /// <summary>
        /// Checks every element of input array for invalid values
        /// </summary>
        /// <param name="flags">The operation flags</param>
        /// <returns>returns nonzero if the check succeeded, i.e. all elements are valid and within the range, and zero otherwise.</returns>
#endif
        public bool CheckArray(CheckArrFlag flags)
        {
            return Cv.CheckArray(this, flags);
        }
#if LANG_JP
        /// <summary>
        /// 入力配列のすべての要素について，無効な値が存在しないかをチェックする. CheckArrのエイリアス. 
        /// </summary>
        /// <param name="flags">処理フラグ</param>
        /// <param name="minVal">有効な値域の下限値(この値以上)．CheckArrFlag.Range がセットされているときのみ有効．</param>
        /// <param name="maxVal">有効な値域の上限値(この値未満)．CheckArrFlag.Range がセットされているときのみ有効．</param>
        /// <returns>チェックが正しく終わればtrue</returns>
#else
        /// <summary>
        /// Checks every element of input array for invalid values
        /// </summary>
        /// <param name="flags">The operation flags</param>
        /// <param name="minVal">The inclusive lower boundary of valid values range. It is used only if CV_CHECK_RANGE is set. </param>
        /// <param name="maxVal">The exclusive upper boundary of valid values range. It is used only if CV_CHECK_RANGE is set. </param>
        /// <returns>returns nonzero if the check succeeded, i.e. all elements are valid and within the range, and zero otherwise.</returns>
#endif
        public bool CheckArray(CheckArrFlag flags, double minVal, double maxVal)
        {
            return Cv.CheckArray(this, flags, minVal, maxVal);
        }
        #endregion
        #region CheckContourConvexity
#if LANG_JP
        /// <summary>
        /// 輪郭が凸であるかを調べる
        /// </summary>
        /// <returns></returns>
#else
        /// <summary>
        /// Tests contour convexity.
        /// </summary>
        /// <returns></returns>
#endif
        public bool CheckContourConvexity()
        {
            return Cv.CheckContourConvexity(this);
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
#else
        /// <summary>
        /// Draws a circle
        /// </summary>
        /// <param name="centerX">X-coordinate of the center of the circle. </param>
        /// <param name="centerY">Y-coordinate of the center of the circle. </param>
        /// <param name="radius">Radius of the circle. </param>
        /// <param name="color">Circle color. </param>
#endif
        public void Circle(int centerX, int centerY, int radius, CvScalar color)
        {
            Cv.Circle(this, centerX, centerY, radius, color);
        }
#if LANG_JP
        /// <summary>
        /// 円を描画する
        /// </summary>
        /// <param name="centerX">円の中心のx座標</param>
        /// <param name="centerY">円の中心のy座標</param>
        /// <param name="radius">円の半径</param>
        /// <param name="color">円の色</param>
        /// <param name="thickness">線の幅．負の値を指定した場合は塗りつぶされる．</param>
#else
        /// <summary>
        /// Draws a circle
        /// </summary>
        /// <param name="centerX">X-coordinate of the center of the circle. </param>
        /// <param name="centerY">Y-coordinate of the center of the circle. </param>
        /// <param name="radius">Radius of the circle. </param>
        /// <param name="color">Circle color. </param>
        /// <param name="thickness">Thickness of the circle outline if positive, otherwise indicates that a filled circle has to be drawn. </param>
#endif
        public void Circle(int centerX, int centerY, int radius, CvScalar color, int thickness)
        {
            Cv.Circle(this, centerX, centerY, radius, color, thickness);
        }
#if LANG_JP
        /// <summary>
        /// 円を描画する
        /// </summary>
        /// <param name="centerX">円の中心のx座標</param>
        /// <param name="centerY">円の中心のy座標</param>
        /// <param name="radius">円の半径</param>
        /// <param name="color">円の色</param>
        /// <param name="thickness">線の幅．負の値を指定した場合は塗りつぶされる．</param>
        /// <param name="lineType">線の種類</param>
#else
        /// <summary>
        /// Draws a circle
        /// </summary>
        /// <param name="centerX">X-coordinate of the center of the circle. </param>
        /// <param name="centerY">Y-coordinate of the center of the circle. </param>
        /// <param name="radius">Radius of the circle. </param>
        /// <param name="color">Circle color. </param>
        /// <param name="thickness">Thickness of the circle outline if positive, otherwise indicates that a filled circle has to be drawn. </param>
        /// <param name="lineType">Type of the circle boundary.</param>
#endif
        public void Circle(int centerX, int centerY, int radius, CvScalar color, int thickness, LineType lineType)
        {
            Cv.Circle(this, centerX, centerY, radius, color, thickness, lineType);
        }
#if LANG_JP
        /// <summary>
        /// 円を描画する
        /// </summary>
        /// <param name="centerX">円の中心のx座標</param>
        /// <param name="centerY">円の中心のy座標</param>
        /// <param name="radius">円の半径</param>
        /// <param name="color">円の色</param>
        /// <param name="thickness">線の幅．負の値を指定した場合は塗りつぶされる．</param>
        /// <param name="lineType">線の種類</param>
        /// <param name="shift">中心座標と半径の小数点以下の桁を表すビット数.</param>
#else
        /// <summary>
        /// Draws a circle
        /// </summary>
        /// <param name="centerX">X-coordinate of the center of the circle. </param>
        /// <param name="centerY">Y-coordinate of the center of the circle. </param>
        /// <param name="radius">Radius of the circle. </param>
        /// <param name="color">Circle color. </param>
        /// <param name="thickness">Thickness of the circle outline if positive, otherwise indicates that a filled circle has to be drawn. </param>
        /// <param name="lineType">Type of the circle boundary.</param>
        /// <param name="shift">Number of fractional bits in the center coordinates and radius value. </param>
#endif
        public void Circle(int centerX, int centerY, int radius, CvScalar color, int thickness, LineType lineType, int shift)
        {
            Cv.Circle(this, centerX, centerY, radius, color, thickness, lineType, shift);
        }

#if LANG_JP
        /// <summary>
        /// 円を描画する
        /// </summary>
        /// <param name="center">円の中心</param>
        /// <param name="radius">円の半径</param>
        /// <param name="color">円の色</param>
#else
        /// <summary>
        /// Draws a circle
        /// </summary>
        /// <param name="center">Center of the circle. </param>
        /// <param name="radius">Radius of the circle. </param>
        /// <param name="color">Circle color. </param>
#endif
        public void Circle(CvPoint center, int radius, CvScalar color)
        {
            Cv.Circle(this, center, radius, color);
        }
#if LANG_JP
        /// <summary>
        /// 円を描画する
        /// </summary>
        /// <param name="center">円の中心</param>
        /// <param name="radius">円の半径</param>
        /// <param name="color">円の色</param>
        /// <param name="thickness">線の幅．負の値を指定した場合は塗りつぶされる．</param>
#else
        /// <summary>
        /// Draws a circle
        /// </summary>
        /// <param name="center">Center of the circle. </param>
        /// <param name="radius">Radius of the circle. </param>
        /// <param name="color">Circle color. </param>
        /// <param name="thickness">Thickness of the circle outline if positive, otherwise indicates that a filled circle has to be drawn. </param>
#endif
        public void Circle(CvPoint center, int radius, CvScalar color, int thickness)
        {
            Cv.Circle(this, center, radius, color, thickness);
        }
#if LANG_JP
        /// <summary>
        /// 円を描画する
        /// </summary>
        /// <param name="center">円の中心</param>
        /// <param name="radius">円の半径</param>
        /// <param name="color">円の色</param>
        /// <param name="thickness">線の幅．負の値を指定した場合は塗りつぶされる．</param>
        /// <param name="lineType">線の種類</param>
#else
        /// <summary>
        /// Draws a circle
        /// </summary>
        /// <param name="center">Center of the circle. </param>
        /// <param name="radius">Radius of the circle. </param>
        /// <param name="color">Circle color. </param>
        /// <param name="thickness">Thickness of the circle outline if positive, otherwise indicates that a filled circle has to be drawn. </param>
        /// <param name="lineType">Type of the circle boundary.</param>
#endif
        public void Circle(CvPoint center, int radius, CvScalar color, int thickness, LineType lineType)
        {
            Cv.Circle(this, center, radius, color, thickness, lineType);
        }
#if LANG_JP
        /// <summary>
        /// 円を描画する
        /// </summary>
        /// <param name="center">円の中心</param>
        /// <param name="radius">円の半径</param>
        /// <param name="color">円の色</param>
        /// <param name="thickness">線の幅．負の値を指定した場合は塗りつぶされる．</param>
        /// <param name="lineType">線の種類</param>
        /// <param name="shift">中心座標と半径の小数点以下の桁を表すビット数.</param>
#else
        /// <summary>
        /// Draws a circle
        /// </summary>
        /// <param name="center">Center of the circle. </param>
        /// <param name="radius">Radius of the circle. </param>
        /// <param name="color">Circle color. </param>
        /// <param name="thickness">Thickness of the circle outline if positive, otherwise indicates that a filled circle has to be drawn. </param>
        /// <param name="lineType">Type of the circle boundary.</param>
        /// <param name="shift">Number of fractional bits in the center coordinates and radius value. </param>
#endif
        public void Circle(CvPoint center, int radius, CvScalar color, int thickness, LineType lineType, int shift)
        {
            Cv.Circle(this, center, radius, color, thickness, lineType, shift);
        }
#if LANG_JP
        /// <summary>
        /// 円を描画する
        /// </summary>
        /// <param name="centerX">円の中心のx座標</param>
        /// <param name="centerY">円の中心のy座標</param>
        /// <param name="radius">円の半径</param>
        /// <param name="color">円の色</param>
#else
        /// <summary>
        /// Draws a circle
        /// </summary>
        /// <param name="centerX">X-coordinate of the center of the circle. </param>
        /// <param name="centerY">Y-coordinate of the center of the circle. </param>
        /// <param name="radius">Radius of the circle. </param>
        /// <param name="color">Circle color. </param>
#endif
        public void DrawCircle(int centerX, int centerY, int radius, CvScalar color)
        {
            Cv.DrawCircle(this, centerX, centerY, radius, color);
        }
#if LANG_JP
        /// <summary>
        /// 円を描画する
        /// </summary>
        /// <param name="centerX">円の中心のx座標</param>
        /// <param name="centerY">円の中心のy座標</param>
        /// <param name="radius">円の半径</param>
        /// <param name="color">円の色</param>
        /// <param name="thickness">線の幅．負の値を指定した場合は塗りつぶされる．</param>
#else
        /// <summary>
        /// Draws a circle
        /// </summary>
        /// <param name="centerX">X-coordinate of the center of the circle. </param>
        /// <param name="centerY">Y-coordinate of the center of the circle. </param>
        /// <param name="radius">Radius of the circle. </param>
        /// <param name="color">Circle color. </param>
        /// <param name="thickness">Thickness of the circle outline if positive, otherwise indicates that a filled circle has to be drawn. </param>
#endif
        public void DrawCircle(int centerX, int centerY, int radius, CvScalar color, int thickness)
        {
            Cv.DrawCircle(this, centerX, centerY, radius, color, thickness);
        }
#if LANG_JP
        /// <summary>
        /// 円を描画する
        /// </summary>
        /// <param name="centerX">円の中心のx座標</param>
        /// <param name="centerY">円の中心のy座標</param>
        /// <param name="radius">円の半径</param>
        /// <param name="color">円の色</param>
        /// <param name="thickness">線の幅．負の値を指定した場合は塗りつぶされる．</param>
        /// <param name="lineType">線の種類</param>
#else
        /// <summary>
        /// Draws a circle
        /// </summary>
        /// <param name="centerX">X-coordinate of the center of the circle. </param>
        /// <param name="centerY">Y-coordinate of the center of the circle. </param>
        /// <param name="radius">Radius of the circle. </param>
        /// <param name="color">Circle color. </param>
        /// <param name="thickness">Thickness of the circle outline if positive, otherwise indicates that a filled circle has to be drawn. </param>
        /// <param name="lineType">Type of the circle boundary.</param>
#endif
        public void DrawCircle(int centerX, int centerY, int radius, CvScalar color, int thickness, LineType lineType)
        {
            Cv.DrawCircle(this, centerX, centerY, radius, color, thickness, lineType);
        }
#if LANG_JP
        /// <summary>
        /// 円を描画する
        /// </summary>
        /// <param name="centerX">円の中心のx座標</param>
        /// <param name="centerY">円の中心のy座標</param>
        /// <param name="radius">円の半径</param>
        /// <param name="color">円の色</param>
        /// <param name="thickness">線の幅．負の値を指定した場合は塗りつぶされる．</param>
        /// <param name="lineType">線の種類</param>
        /// <param name="shift">中心座標と半径の小数点以下の桁を表すビット数.</param>
#else
        /// <summary>
        /// Draws a circle
        /// </summary>
        /// <param name="centerX">X-coordinate of the center of the circle. </param>
        /// <param name="centerY">Y-coordinate of the center of the circle. </param>
        /// <param name="radius">Radius of the circle. </param>
        /// <param name="color">Circle color. </param>
        /// <param name="thickness">Thickness of the circle outline if positive, otherwise indicates that a filled circle has to be drawn. </param>
        /// <param name="lineType">Type of the circle boundary.</param>
        /// <param name="shift">Number of fractional bits in the center coordinates and radius value. </param>
#endif
        public void DrawCircle(int centerX, int centerY, int radius, CvScalar color, int thickness, LineType lineType, int shift)
        {
            Cv.DrawCircle(this, centerX, centerY, radius, color, thickness, lineType, shift);
        }

#if LANG_JP
        /// <summary>
        /// 円を描画する
        /// </summary>
        /// <param name="center">円の中心</param>
        /// <param name="radius">円の半径</param>
        /// <param name="color">円の色</param>
#else
        /// <summary>
        /// Draws a circle
        /// </summary>
        /// <param name="center">Center of the circle. </param>
        /// <param name="radius">Radius of the circle. </param>
        /// <param name="color">Circle color. </param>
#endif
        public void DrawCircle(CvPoint center, int radius, CvScalar color)
        {
            Cv.DrawCircle(this, center, radius, color);
        }
#if LANG_JP
        /// <summary>
        /// 円を描画する
        /// </summary>
        /// <param name="center">円の中心</param>
        /// <param name="radius">円の半径</param>
        /// <param name="color">円の色</param>
        /// <param name="thickness">線の幅．負の値を指定した場合は塗りつぶされる．</param>
#else
        /// <summary>
        /// Draws a circle
        /// </summary>
        /// <param name="center">Center of the circle. </param>
        /// <param name="radius">Radius of the circle. </param>
        /// <param name="color">Circle color. </param>
        /// <param name="thickness">Thickness of the circle outline if positive, otherwise indicates that a filled circle has to be drawn. </param>
#endif
        public void DrawCircle(CvPoint center, int radius, CvScalar color, int thickness)
        {
            Cv.DrawCircle(this, center, radius, color, thickness);
        }
#if LANG_JP
        /// <summary>
        /// 円を描画する
        /// </summary>
        /// <param name="center">円の中心</param>
        /// <param name="radius">円の半径</param>
        /// <param name="color">円の色</param>
        /// <param name="thickness">線の幅．負の値を指定した場合は塗りつぶされる．</param>
        /// <param name="lineType">線の種類</param>
#else
        /// <summary>
        /// Draws a circle
        /// </summary>
        /// <param name="center">Center of the circle. </param>
        /// <param name="radius">Radius of the circle. </param>
        /// <param name="color">Circle color. </param>
        /// <param name="thickness">Thickness of the circle outline if positive, otherwise indicates that a filled circle has to be drawn. </param>
        /// <param name="lineType">Type of the circle boundary.</param>
#endif
        public void DrawCircle(CvPoint center, int radius, CvScalar color, int thickness, LineType lineType)
        {
            Cv.DrawCircle(this, center, radius, color, thickness, lineType);
        }
#if LANG_JP
        /// <summary>
        /// 円を描画する
        /// </summary>
        /// <param name="center">円の中心</param>
        /// <param name="radius">円の半径</param>
        /// <param name="color">円の色</param>
        /// <param name="thickness">線の幅．負の値を指定した場合は塗りつぶされる．</param>
        /// <param name="lineType">線の種類</param>
        /// <param name="shift">中心座標と半径の小数点以下の桁を表すビット数.</param>
#else
        /// <summary>
        /// Draws a circle
        /// </summary>
        /// <param name="center">Center of the circle. </param>
        /// <param name="radius">Radius of the circle. </param>
        /// <param name="color">Circle color. </param>
        /// <param name="thickness">Thickness of the circle outline if positive, otherwise indicates that a filled circle has to be drawn. </param>
        /// <param name="lineType">Type of the circle boundary.</param>
        /// <param name="shift">Number of fractional bits in the center coordinates and radius value. </param>
#endif
        public void DrawCircle(CvPoint center, int radius, CvScalar color, int thickness, LineType lineType, int shift)
        {
            Cv.DrawCircle(this, center, radius, color, thickness, lineType, shift);
        }
        #endregion
        #region ClearND
#if LANG_JP
        /// <summary>
        /// 密な配列と疎な配列の指定した要素をクリア（0にセット）する．要素が存在しなければ，この関数は何もしない．
        /// </summary>
        /// <param name="idx">要素のインデックスの配列(可変長引数）</param>
#else
        /// <summary>
        /// Clears the particular array element
        /// </summary>
        /// <param name="idx">Array of the element indices </param>
#endif
        public void ClearND(params int[] idx)
        {
            Cv.ClearND(this, idx);
        }
        #endregion
        #region Cmp
#if LANG_JP
        /// <summary>
        /// 二つの配列の各要素ごとの比較を行う. 対応する要素を比較し，出力配列の値にセットする．
        /// dst(I) = src1(I) op src2(I) .
        /// 比較結果が真（true）であれば dst(I) には 0xff（要素すべてのビットが 1 ）をセットし，それ以外の場合（false）であれば 0 をセットする．
        /// </summary>
        /// <param name="src2">2番目の入力配列．どちらの入力配列もシングルチャンネルでなければならない．</param>
        /// <param name="dst">出力配列（タイプは 8u か 8s でないといけない）</param>
        /// <param name="cmpOp">比較方法を示すフラグ</param>
#else
        /// <summary>
        /// Performs per-element comparison of two arrays
        /// </summary>
        /// <param name="src2">The second source array. Both source array must have a single channel. </param>
        /// <param name="dst">The destination array, must have 8u or 8s type. </param>
        /// <param name="cmpOp">The flag specifying the relation between the elements to be checked</param>
#endif
        public void Cmp(CvArr src2, CvArr dst, ArrComparison cmpOp)
        {
            Cv.Cmp(this, src2, dst, cmpOp);
        }
        #endregion
        #region CmpS
#if LANG_JP
        /// <summary>
        /// 配列要素とスカラーを比較し，出力配列の値をセットする．
        /// dst(I) = src1(I) op scalar .
        /// 比較結果が真（true）であれば dst(I) には 0xff（要素すべてのビットが 1 ）をセットし，それ以外の場合（false）であれば 0 をセットする．
        /// </summary>
        /// <param name="value">それぞれの配列要素と比較されるスカラー</param>
        /// <param name="dst">出力配列（タイプは 8u か 8s でないといけない）</param>
        /// <param name="cmpOp">比較方法を示すフラグ</param>
#else
        /// <summary>
        /// Performs per-element comparison of array and scalar
        /// </summary>
        /// <param name="value">The scalar value to compare each array element with. </param>
        /// <param name="dst">The destination array, must have 8u or 8s type. </param>
        /// <param name="cmpOp">The flag specifying the relation between the elements to be checked</param>
#endif
        public void CmpS(double value, CvArr dst, ArrComparison cmpOp)
        {
            Cv.CmpS(this, value, dst, cmpOp);
        }
        #endregion
        #region ContourArea
#if LANG_JP
        /// <summary>
        /// 輪郭全体の領域，または輪郭の一部を計算する． 
        /// 後者の場合，輪郭の弧と選択された2点を繋ぐ弦で区切られたエリア全体が計算される．
        /// </summary>
        /// <returns></returns>
#else
        /// <summary>
        /// Calculates area of the whole contour or contour section.
        /// </summary>
        /// <returns></returns>
#endif
        public double ContourArea()
        {
            return Cv.ContourArea(this);
        }
#if LANG_JP
        /// <summary>
        /// 輪郭全体の領域，または輪郭の一部を計算する． 
        /// 後者の場合，輪郭の弧と選択された2点を繋ぐ弦で区切られたエリア全体が計算される．
        /// </summary>
        /// <param name="slice">注目領域の輪郭の始点と終点．デフォルトでは全領域が計算される．</param>
        /// <returns></returns>
#else
        /// <summary>
        /// Calculates area of the whole contour or contour section.
        /// </summary>
        /// <param name="slice">Starting and ending points of the contour section of interest, by default area of the whole contour is calculated. </param>
        /// <returns></returns>
#endif
        public double ContourArea(CvSlice slice)
        {
            return Cv.ContourArea(this, slice);
        }
        #endregion
        #region ContourPerimeter
#if LANG_JP
        /// <summary>
        /// cvArcLength(curve,Whole_Seq,1) のエイリアス
        /// </summary>
        /// <returns></returns>
#else
        /// <summary>
        /// Alias for cvArcLength(curve,Whole_Seq,1)
        /// </summary>
        /// <returns></returns>
#endif
        public double ContourPerimeter()
        {
            return Cv.ContourPerimeter(this);
        }
        #endregion
        #region ConvertScale
#if LANG_JP
        /// <summary>
        /// 任意の線形変換によって配列の値を変換する．[scale=1, shift=0]
        /// </summary>
        /// <param name="dst">出力配列（デプスは 8u）</param>
#else
        /// <summary>
        /// Converts one array to another with optional linear transformation
        /// </summary>
        /// <param name="dst">Destination array. </param>
#endif
        public void ConvertScale(CvArr dst)
        {
            Cv.ConvertScale(this, dst);
        }
#if LANG_JP
        /// <summary>
        /// 任意の線形変換によって配列の値を変換する．[shift=0]
        /// </summary>
        /// <param name="dst">出力配列（デプスは 8u）</param>
        /// <param name="scale">スケーリング係数</param>
#else
        /// <summary>
        /// Converts one array to another with optional linear transformation
        /// </summary>
        /// <param name="dst">Destination array. </param>
        /// <param name="scale">Scale factor. </param>
#endif
        public void ConvertScale(CvArr dst, double scale)
        {
            Cv.ConvertScale(this, dst, scale);
        }
#if LANG_JP
        /// <summary>
        /// 任意の線形変換によって配列の値を変換する．
        /// </summary>
        /// <param name="dst">出力配列（デプスは 8u）</param>
        /// <param name="scale">スケーリング係数</param>
        /// <param name="shift">スケーリングした入力配列の要素に加える値</param>
#else
        /// <summary>
        /// Converts one array to another with optional linear transformation
        /// </summary>
        /// <param name="dst">Destination array. </param>
        /// <param name="scale">Scale factor. </param>
        /// <param name="shift">Value added to the scaled source array elements. </param>
#endif
        public void ConvertScale(CvArr dst, double scale, double shift)
        {
            Cv.ConvertScale(this, dst, scale, shift);
        }
#if LANG_JP
        /// <summary>
        /// 任意の線形変換によって配列の値を変換する．[scale=1, shift=0]
        /// </summary>
        /// <param name="dst">出力配列（デプスは 8u）</param>
#else
        /// <summary>
        /// Converts one array to another with optional linear transformation
        /// </summary>
        /// <param name="dst">Destination array. </param>
#endif
        public void CvtScale(CvArr dst)
        {
            Cv.CvtScale(this, dst);
        }
#if LANG_JP
        /// <summary>
        /// 任意の線形変換によって配列の値を変換する．[shift=0]
        /// </summary>
        /// <param name="dst">出力配列（デプスは 8u）</param>
        /// <param name="scale">スケーリング係数</param>
#else
        /// <summary>
        /// Converts one array to another with optional linear transformation
        /// </summary>
        /// <param name="dst">Destination array. </param>
        /// <param name="scale">Scale factor. </param>
#endif
        public void CvtScale(CvArr dst, double scale)
        {
            Cv.CvtScale(this, dst, scale);
        }
#if LANG_JP
        /// <summary>
        /// 任意の線形変換によって配列の値を変換する．
        /// </summary>
        /// <param name="dst">出力配列（デプスは 8u）</param>
        /// <param name="scale">スケーリング係数</param>
        /// <param name="shift">スケーリングした入力配列の要素に加える値</param>
#else
        /// <summary>
        /// Converts one array to another with optional linear transformation
        /// </summary>
        /// <param name="dst">Destination array. </param>
        /// <param name="scale">Scale factor. </param>
        /// <param name="shift">Value added to the scaled source array elements. </param>
#endif
        public void CvtScale(CvArr dst, double scale, double shift)
        {
            Cv.CvtScale(this, dst, scale, shift);
        }
#if LANG_JP
        /// <summary>
        /// 任意の線形変換によって配列の値を変換する．[scale=1, shift=0]
        /// </summary>
        /// <param name="dst">出力配列（デプスは 8u）</param>
#else
        /// <summary>
        /// Converts one array to another with optional linear transformation
        /// </summary>
        /// <param name="dst">Destination array. </param>
#endif
        public void Scale(CvArr dst)
        {
            Cv.Scale(this, dst);
        }
#if LANG_JP
        /// <summary>
        /// 任意の線形変換によって配列の値を変換する．[shift=0]
        /// </summary>
        /// <param name="dst">出力配列（デプスは 8u）</param>
        /// <param name="scale">スケーリング係数</param>
#else
        /// <summary>
        /// Converts one array to another with optional linear transformation
        /// </summary>
        /// <param name="dst">Destination array. </param>
        /// <param name="scale">Scale factor. </param>
#endif
        public void Scale(CvArr dst, double scale)
        {
            Cv.Scale(this, dst, scale);
        }
#if LANG_JP
        /// <summary>
        /// 任意の線形変換によって配列の値を変換する．
        /// </summary>
        /// <param name="dst">出力配列（デプスは 8u）</param>
        /// <param name="scale">スケーリング係数</param>
        /// <param name="shift">スケーリングした入力配列の要素に加える値</param>
#else
        /// <summary>
        /// Converts one array to another with optional linear transformation
        /// </summary>
        /// <param name="dst">Destination array. </param>
        /// <param name="scale">Scale factor. </param>
        /// <param name="shift">Value added to the scaled source array elements. </param>
#endif
        public void Scale(CvArr dst, double scale, double shift)
        {
            Cv.Scale(this, dst, scale, shift);
        }
#if LANG_JP
        /// <summary>
        /// scale=1, shift=0 でのcvConvertScale呼び出し. 任意の線形変換によって配列の値を変換する．
        /// </summary>
        /// <param name="dst">出力配列（デプスは 8u）</param>
#else
        /// <summary>
        /// Converts one array to another with optional linear transformation
        /// </summary>
        /// <param name="dst">Destination array. </param>
#endif
        public void Convert(CvArr dst)
        {
            Cv.Convert(this, dst);
        }
        #endregion
        #region ConvertScaleAbs
#if LANG_JP
        /// <summary>
        /// 任意の線形変換によって，入力配列の要素を8ビット符号無し整数型の配列に変換する．[scale=1, shift=0]
        /// </summary>
        /// <param name="dst">出力配列（デプスは 8u）</param>
#else
        /// <summary>
        /// Converts input array elements to 8-bit unsigned integer another with optional linear transformation
        /// </summary>
        /// <param name="dst">Destination array (should have 8u depth). </param>
#endif
        public void ConvertScaleAbs(CvArr dst)
        {
            Cv.ConvertScaleAbs(this, dst);
        }
#if LANG_JP
        /// <summary>
        /// 任意の線形変換によって，入力配列の要素を8ビット符号無し整数型の配列に変換する．[shift=0]
        /// </summary>
        /// <param name="dst">出力配列（デプスは 8u）</param>
        /// <param name="scale">ScaleAbs 係数</param>
#else
        /// <summary>
        /// Converts input array elements to 8-bit unsigned integer another with optional linear transformation
        /// </summary>
        /// <param name="dst">Destination array (should have 8u depth). </param>
        /// <param name="scale">ScaleAbs factor. </param>
#endif
        public void ConvertScaleAbs(CvArr dst, double scale)
        {
            Cv.ConvertScaleAbs(this, dst, scale);
        }
#if LANG_JP
        /// <summary>
        /// 任意の線形変換によって，入力配列の要素を8ビット符号無し整数型の配列に変換する．
        /// </summary>
        /// <param name="dst">出力配列（デプスは 8u）</param>
        /// <param name="scale">ScaleAbs 係数</param>
        /// <param name="shift">スケーリングした入力配列の要素に加える値</param>
#else
        /// <summary>
        /// Converts input array elements to 8-bit unsigned integer another with optional linear transformation
        /// </summary>
        /// <param name="dst">Destination array (should have 8u depth). </param>
        /// <param name="scale">ScaleAbs factor. </param>
        /// <param name="shift">Value added to the scaled source array elements. </param>
#endif
        public void ConvertScaleAbs(CvArr dst, double scale, double shift)
        {
            Cv.ConvertScaleAbs(this, dst, scale, shift);
        }
#if LANG_JP
        /// <summary>
        /// 任意の線形変換によって，入力配列の要素を8ビット符号無し整数型の配列に変換する．[scale=1, shift=0]
        /// </summary>
        /// <param name="dst">出力配列（デプスは 8u）</param>
#else
        /// <summary>
        /// Converts input array elements to 8-bit unsigned integer another with optional linear transformation
        /// </summary>
        /// <param name="dst">Destination array (should have 8u depth). </param>
#endif
        public void CvtScaleAbs(CvArr dst)
        {
            Cv.CvtScaleAbs(this, dst);
        }
#if LANG_JP
        /// <summary>
        /// 任意の線形変換によって，入力配列の要素を8ビット符号無し整数型の配列に変換する．[shift=0]
        /// </summary>
        /// <param name="dst">出力配列（デプスは 8u）</param>
        /// <param name="scale">ScaleAbs 係数</param>
#else
        /// <summary>
        /// Converts input array elements to 8-bit unsigned integer another with optional linear transformation
        /// </summary>
        /// <param name="dst">Destination array (should have 8u depth). </param>
        /// <param name="scale">ScaleAbs factor. </param>
#endif
        public void CvtScaleAbs(CvArr dst, double scale)
        {
            Cv.CvtScaleAbs(this, dst, scale);
        }
#if LANG_JP
        /// <summary>
        /// 任意の線形変換によって，入力配列の要素を8ビット符号無し整数型の配列に変換する．
        /// </summary>
        /// <param name="dst">出力配列（デプスは 8u）</param>
        /// <param name="scale">ScaleAbs 係数</param>
        /// <param name="shift">スケーリングした入力配列の要素に加える値</param>
#else
        /// <summary>
        /// Converts input array elements to 8-bit unsigned integer another with optional linear transformation
        /// </summary>
        /// <param name="dst">Destination array (should have 8u depth). </param>
        /// <param name="scale">ScaleAbs factor. </param>
        /// <param name="shift">Value added to the scaled source array elements. </param>
#endif
        public void CvtScaleAbs(CvArr dst, double scale, double shift)
        {
            Cv.CvtScaleAbs(this, dst, scale, shift);
        }
        #endregion
        #region ConvexHull2
#if LANG_JP
        /// <summary>
        /// Sklanskyのアルゴリズムを使って2次元の点列の凸包を見つける
        /// </summary>
        /// <param name="hull">出力される凸包．凸包を構成する点の元の配列におけるインデックス（0基準）のベクトル</param>
        /// <param name="orientation">凸包を構成するデータの並び．</param>
#else
        /// <summary>
        /// Finds convex hull of point set
        /// </summary>
        /// <param name="hull">Vector of 0-based point indices of the hull points in the original array.</param>
        /// <param name="orientation">Desired orientation of convex hull: CV_CLOCKWISE or CV_COUNTER_CLOCKWISE. </param>
#endif
        public void ConvexHull2(out int[] hull, ConvexHullOrientation orientation)
        {
             Cv.ConvexHull2(this, out hull, orientation);
        }

#if LANG_JP
        /// <summary>
        /// Sklanskyのアルゴリズムを使って2次元の点列の凸包を見つける
        /// </summary>
        /// <param name="hull">出力される凸包．凸包を構成する点の元の配列におけるインデックス（0基準）のベクトル</param>
        /// <param name="orientation">凸包を構成するデータの並び．</param>
#else
        /// <summary>
        /// Finds convex hull of point set
        /// </summary>
        /// <param name="hull">The output convex hull. It is either a vector of points that form the hull.</param>
        /// <param name="orientation">Desired orientation of convex hull: CV_CLOCKWISE or CV_COUNTER_CLOCKWISE. </param>
#endif
        public void ConvexHull2(out CvPoint[] hull, ConvexHullOrientation orientation)
        {
            Cv.ConvexHull2(this, out hull, orientation);
        }
#if LANG_JP
        /// <summary>
        /// Sklanskyのアルゴリズムを使って2次元の点列の凸包を見つける
        /// </summary>
        /// <param name="hull">出力される凸包．凸包を構成する点の元の配列におけるインデックス（0基準）のベクトル</param>
        /// <param name="orientation">凸包を構成するデータの並び．</param>
#else
        /// <summary>
        /// Finds convex hull of point set
        /// </summary>
        /// <param name="hull">The output convex hull. It is either a vector of points that form the hull.</param>
        /// <param name="orientation">Desired orientation of convex hull: CV_CLOCKWISE or CV_COUNTER_CLOCKWISE. </param>
#endif
        public void ConvexHull2(out CvPoint2D32f[] hull, ConvexHullOrientation orientation)
        {
            Cv.ConvexHull2(this, out hull, orientation);
        }
        #endregion
        #region ConvexityDefects
#if LANG_JP
        /// <summary>
        /// 輪郭の凸包から凹状欠損を見つける
        /// </summary>
        /// <param name="convexhull">凸包の点そのものではなく，輪郭の点へのポインタまたはインデックスを持つ，つまりcvConvexHull2のreturn_pointsパラメータが0であるような cvConvexHull2 を使って得られた凸包．</param>
#else
        /// <summary>
        /// Finds convexity defects of contour
        /// </summary>
        /// <param name="convexhull">Convex hull obtained using cvConvexHull2 that should contain pointers or indices to the contour points, not the hull points themselves, i.e. return_points parameter in cvConvexHull2 should be 0. </param>
#endif
        public CvSeq<CvConvexityDefect> ConvexityDefects(CvArr convexhull)
        {
            return Cv.ConvexityDefects(this, convexhull, null);
        }
#if LANG_JP
        /// <summary>
        /// 輪郭の凸包から凹状欠損を見つける
        /// </summary>
        /// <param name="convexhull">凸包の点そのものではなく，輪郭の点へのポインタまたはインデックスを持つ，つまりcvConvexHull2のreturn_pointsパラメータが0であるような cvConvexHull2 を使って得られた凸包．</param>
        /// <param name="storage">凹状欠損の出力シーケンスを格納する変数．これがnullである場合，代わりに，輪郭あるいは凸包のストレージが（この順番で）利用される．</param>
#else
        /// <summary>
        /// Finds convexity defects of contour
        /// </summary>
        /// <param name="convexhull">Convex hull obtained using cvConvexHull2 that should contain pointers or indices to the contour points, not the hull points themselves, i.e. return_points parameter in cvConvexHull2 should be 0. </param>
        /// <param name="storage">Container for output sequence of convexity defects. If it is null, contour or hull (in that order) storage is used. </param>
#endif
        public CvSeq<CvConvexityDefect> ConvexityDefects(CvArr convexhull, CvMemStorage storage)
        {
            return Cv.ConvexityDefects(this, convexhull, storage);
        }

#if LANG_JP
        /// <summary>
        /// 輪郭の凸包から凹状欠損を見つける
        /// </summary>
        /// <param name="convexhull">凸包の点そのものではなく，輪郭の点へのインデックスを持つ cvConvexHull2 を使って得られた凸包．</param>
#else
        /// <summary>
        /// Finds convexity defects of contour
        /// </summary>
        /// <param name="convexhull">Convex hull obtained using cvConvexHull2 that should contain indices to the contour points </param>
#endif
        public CvSeq<CvConvexityDefect> ConvexityDefects(int[] convexhull)
        {
            return Cv.ConvexityDefects(this, convexhull);
        }
        #endregion
        #region Copy
#if LANG_JP
        /// <summary>
        /// 一つの配列を別の配列にコピーする.
        /// </summary>
        /// <param name="dst">コピー先の画像</param>
#else
        /// <summary>
        /// Copies one array to another
        /// </summary>
        /// <param name="dst">The destination array. </param>
#endif
        public void Copy(CvArr dst)
        {
            Cv.Copy(this, dst);
        }
#if LANG_JP
        /// <summary>
        /// 一つの配列を別の配列にコピーする.
        /// </summary>
        /// <param name="dst">コピー先の画像</param>
        /// <param name="mask">8 ビットシングルチャンネル配列の処理マスク．コピー先の配列の変更する要素を指定する．</param>
#else
        /// <summary>
        /// Copies one array to another
        /// </summary>
        /// <param name="dst">The destination array. </param>
        /// <param name="mask">Operation mask, 8-bit single channel array; specifies elements of destination array to be changed. </param>
#endif
        public void Copy(CvArr dst, CvArr mask)
        {
             Cv.Copy(this, dst, mask);
        }
        #endregion
        #region CopyMakeBorder
#if LANG_JP
        /// <summary>
        /// 画像をコピーし，その周りに境界線をつける
        /// </summary>
        /// <param name="dst">出力画像</param>
        /// <param name="offset">入力画像（あるいはROI）がコピーされる出力画像内矩形領域の左上角座標 （左下に原点を持つ画像の場合は，左下角座標）．</param>
        /// <param name="bordertype">コピーされた矩形領域の周りに生成する境界線のタイプ</param>
#else
        /// <summary>
        /// Copies image and makes border around it.
        /// </summary>
        /// <param name="dst">The destination image. </param>
        /// <param name="offset">Coordinates of the top-left corner (or bottom-left in case of images with bottom-left origin) of the destination image rectangle where the source image (or its ROI) is copied. Size of the rectanlge matches the source image size/ROI size. </param>
        /// <param name="bordertype">Type of the border to create around the copied source image rectangle.</param>
#endif
        public void CopyMakeBorder(CvArr dst, CvPoint offset, BorderType bordertype)
        {
            Cv.CopyMakeBorder(this, dst, offset, bordertype);
        }
#if LANG_JP
        /// <summary>
        /// 画像をコピーし，その周りに境界線をつける
        /// </summary>
        /// <param name="dst">出力画像</param>
        /// <param name="offset">入力画像（あるいはROI）がコピーされる出力画像内矩形領域の左上角座標 （左下に原点を持つ画像の場合は，左下角座標）．</param>
        /// <param name="bordertype">コピーされた矩形領域の周りに生成する境界線のタイプ</param>
        /// <param name="value">bordertype=Constant の場合は境界を埋める値</param>
#else
        /// <summary>
        /// Copies image and makes border around it.
        /// </summary>
        /// <param name="dst">The destination image. </param>
        /// <param name="offset">Coordinates of the top-left corner (or bottom-left in case of images with bottom-left origin) of the destination image rectangle where the source image (or its ROI) is copied. Size of the rectanlge matches the source image size/ROI size. </param>
        /// <param name="bordertype">Type of the border to create around the copied source image rectangle.</param>
        /// <param name="value">Value of the border pixels if bordertype=IPL_BORDER_CONSTANT. </param>
#endif
        public void CopyMakeBorder(CvArr dst, CvPoint offset, BorderType bordertype, CvScalar value)
        {
            Cv.CopyMakeBorder(this, dst, offset, bordertype, value);
        }
        #endregion
        #region CornerEigenValsAndVecs
#if LANG_JP
        /// <summary>
        /// コーナー検出のために画像ブロックの固有値と固有ベクトルを計算する.
        /// </summary>
        /// <param name="eigenvv">結果保存用の画像．入力画像の6倍のサイズが必要．</param>
        /// <param name="blockSize">隣接ブロックのサイズ</param>
#else
        /// <summary>
        /// Calculates eigenvalues and eigenvectors of image blocks for corner detection
        /// </summary>
        /// <param name="eigenvv">Image to store the results. It must be 6 times wider than the input image. </param>
        /// <param name="blockSize">Neighborhood size.</param>
#endif
        public void CornerEigenValsAndVecs(CvArr eigenvv, int blockSize)
        {
            Cv.CornerEigenValsAndVecs(this, eigenvv, blockSize);
        }
#if LANG_JP
        /// <summary>
        /// コーナー検出のために画像ブロックの固有値と固有ベクトルを計算する.
        /// </summary>
        /// <param name="eigenvv">結果保存用の画像．入力画像の6倍のサイズが必要．</param>
        /// <param name="blockSize">隣接ブロックのサイズ</param>
        /// <param name="apertureSize">Sobel演算子のアパーチャサイズ(cvSobel参照)．</param>
#else
        /// <summary>
        /// Calculates eigenvalues and eigenvectors of image blocks for corner detection
        /// </summary>
        /// <param name="eigenvv">Image to store the results. It must be 6 times wider than the input image. </param>
        /// <param name="blockSize">Neighborhood size.</param>
        /// <param name="apertureSize">Aperture parameter for Sobel operator</param>
#endif
        public void CornerEigenValsAndVecs(CvArr eigenvv, int blockSize, ApertureSize apertureSize)
        {
            Cv.CornerEigenValsAndVecs(this, eigenvv, blockSize, apertureSize);
        }
        #endregion
        #region CornerHarris
#if LANG_JP
        /// <summary>
        /// 入力画像について Harris エッジ検出を行う． 
        /// cvCornerMinEigenVal や cvCornerEigenValsAndVecsと同様の機能を持ち，それぞれのピクセルにおいて，
        /// block_size×block_size 隣接における 2×2 サイズの勾配から共変動行列M を計算する．その後， 
        /// det(M) - k * trace(M)^2
        /// を計算し，検出結果として出力画像に保存する．結果画像の極大値を求めることで，画像のコーナーを検出することができる． 
        /// </summary>
        /// <param name="harrisResponce">検出結果を保存する画像．入力画像 image と同じサイズでなくてはならない.</param>
        /// <param name="blockSize">隣接ブロックのサイズ</param>
#else
        /// <summary>
        /// Runs the Harris edge detector on image. 
        /// Similarly to cvCornerMinEigenVal and cvCornerEigenValsAndVecs, 
        /// for each pixel it calculates 2x2 gradient covariation matrix M over block_size×block_size neighborhood.
        /// </summary>
        /// <param name="harrisResponce">Image to store the Harris detector responces. Should have the same size as image.</param>
        /// <param name="blockSize">Neighborhood size.</param>
#endif
        public void CornerHarris(CvArr harrisResponce, int blockSize)
        {
            Cv.CornerHarris(this, harrisResponce, blockSize);
        }
#if LANG_JP
        /// <summary>
        /// 入力画像について Harris エッジ検出を行う． 
        /// cvCornerMinEigenVal や cvCornerEigenValsAndVecsと同様の機能を持ち，それぞれのピクセルにおいて，
        /// block_size×block_size 隣接における 2×2 サイズの勾配から共変動行列M を計算する．その後， 
        /// det(M) - k * trace(M)^2
        /// を計算し，検出結果として出力画像に保存する．結果画像の極大値を求めることで，画像のコーナーを検出することができる． 
        /// </summary>
        /// <param name="harrisResponce">検出結果を保存する画像．入力画像 image と同じサイズでなくてはならない.</param>
        /// <param name="blockSize">隣接ブロックのサイズ</param>
        /// <param name="apertureSize">Sobel演算子のアパーチャサイズ(cvSobel参照)．入力画像が浮動小数点型である場合，このパラメータは差分を計算するために用いられる固定小数点型フィルタの数を表す</param>
#else
        /// <summary>
        /// Runs the Harris edge detector on image. 
        /// Similarly to cvCornerMinEigenVal and cvCornerEigenValsAndVecs, 
        /// for each pixel it calculates 2x2 gradient covariation matrix M over block_size×block_size neighborhood.
        /// </summary>
        /// <param name="harrisResponce">Image to store the Harris detector responces. Should have the same size as image.</param>
        /// <param name="blockSize">Neighborhood size.</param>
        /// <param name="apertureSize">Aperture parameter for Sobel operator (see cvSobel). format. In the case of floating-point input format this parameter is the number of the fixed float filter used for differencing. </param>
#endif
        public void CornerHarris(CvArr harrisResponce, int blockSize, ApertureSize apertureSize)
        {
            Cv.CornerHarris(this, harrisResponce, blockSize, apertureSize);
        }
#if LANG_JP
        /// <summary>
        /// 入力画像について Harris エッジ検出を行う． 
        /// cvCornerMinEigenVal や cvCornerEigenValsAndVecsと同様の機能を持ち，それぞれのピクセルにおいて，
        /// block_size×block_size 隣接における 2×2 サイズの勾配から共変動行列M を計算する．その後， 
        /// det(M) - k * trace(M)^2
        /// を計算し，検出結果として出力画像に保存する．結果画像の極大値を求めることで，画像のコーナーを検出することができる． 
        /// </summary>
        /// <param name="harrisResponce">検出結果を保存する画像．入力画像 image と同じサイズでなくてはならない.</param>
        /// <param name="blockSize">隣接ブロックのサイズ</param>
        /// <param name="apertureSize">Sobel演算子のアパーチャサイズ(cvSobel参照)．入力画像が浮動小数点型である場合，このパラメータは差分を計算するために用いられる固定小数点型フィルタの数を表す</param>
        /// <param name="k">Harris検出器のパラメータ</param>
#else
        /// <summary>
        /// Runs the Harris edge detector on image. 
        /// Similarly to cvCornerMinEigenVal and cvCornerEigenValsAndVecs, 
        /// for each pixel it calculates 2x2 gradient covariation matrix M over block_size×block_size neighborhood.
        /// </summary>
        /// <param name="harrisResponce">Image to store the Harris detector responces. Should have the same size as image.</param>
        /// <param name="blockSize">Neighborhood size.</param>
        /// <param name="apertureSize">Aperture parameter for Sobel operator (see cvSobel). format. In the case of floating-point input format this parameter is the number of the fixed float filter used for differencing. </param>
        /// <param name="k">Harris detector free parameter.</param>
#endif
        public void CornerHarris(CvArr harrisResponce, int blockSize, ApertureSize apertureSize, double k)
        {
            Cv.CornerHarris(this, harrisResponce, blockSize, apertureSize, k);
        }
        #endregion
        #region CornerMinEigenVal
#if LANG_JP
        /// <summary>
        /// コーナー検出のために，画像ブロックの最小固有値を計算する. 
        /// すべてのピクセルについて，隣接ブロックにおける導関数の共変動行列の最小固有値だけを求める関数である．
        /// </summary>
        /// <param name="eigenval">最小固有値を保存する画像．image と同じサイズでなくてはならない．</param>
        /// <param name="blockSize">隣接ブロックのサイズ</param>
#else
        /// <summary>
        /// Calculates minimal eigenvalue of gradient matrices for corner detection
        /// </summary>
        /// <param name="eigenval">Image to store the minimal eigen values. Should have the same size as image</param>
        /// <param name="blockSize">Neighborhood size.</param>
#endif
        public void CornerMinEigenVal(CvArr eigenval, int blockSize)
        {
            Cv.CornerMinEigenVal(this, eigenval, blockSize);
        }
#if LANG_JP
        /// <summary>
        /// コーナー検出のために，画像ブロックの最小固有値を計算する. 
        /// すべてのピクセルについて，隣接ブロックにおける導関数の共変動行列の最小固有値だけを求める関数である．
        /// </summary>
        /// <param name="eigenval">最小固有値を保存する画像．image と同じサイズでなくてはならない．</param>
        /// <param name="blockSize">隣接ブロックのサイズ</param>
        /// <param name="apertureSize">Sobel演算子のアパーチャサイズ(cvSobel参照)．入力画像が浮動小数点型である場合，このパラメータは差分を計算するために用いられる固定小数点型フィルタの数を表す</param>
#else
        /// <summary>
        /// Calculates minimal eigenvalue of gradient matrices for corner detection
        /// </summary>
        /// <param name="eigenval">Image to store the minimal eigen values. Should have the same size as image</param>
        /// <param name="blockSize">Neighborhood size.</param>
        /// <param name="apertureSize">Aperture parameter for Sobel operator (see cvSobel). format. In the case of floating-point input format this parameter is the number of the fixed float filter used for differencing. </param>
#endif
        public void CornerMinEigenVal(CvArr eigenval, int blockSize, ApertureSize apertureSize)
        {
            Cv.CornerMinEigenVal(this, eigenval, blockSize, apertureSize);
        }
        #endregion
        #region CountNonZero
#if LANG_JP
        /// <summary>
        /// 配列要素において 0 ではない要素をカウントする.
        /// 配列が IplImage の場合， ROI，COI の両方に対応している．
        /// </summary>
        /// <returns>0 ではない要素数</returns>
#else
        /// <summary>
        /// Counts non-zero array elements
        /// </summary>
        /// <returns>the number of non-zero elements in arr</returns>
#endif
        public int CountNonZero()
        {
            return Cv.CountNonZero(this);
        }
        #endregion
        #region CreateData
#if LANG_JP
        /// <summary>
        /// 画像，行列あるいは多次元配列のデータを確保する．
        /// </summary>
#else
        /// <summary>
        /// Allocates array data.
        /// </summary>
#endif
        public void CreateData()
        {
            Cv.CreateData(this);
        }
        #endregion
        #region CreatePyramid
#if LANG_JP
        /// <summary>
        /// Builds pyramid for an image
        /// </summary>
        /// <param name="extraLayers"></param>
        /// <param name="rate"></param>
        /// <param name="layerSizes"></param>
        /// <param name="bufarr"></param>
        /// <param name="calc"></param>
        /// <param name="filter"></param>
        /// <returns></returns>
#else
        /// <summary>
        /// Builds pyramid for an image
        /// </summary>
        /// <param name="extraLayers"></param>
        /// <param name="rate"></param>
        /// <param name="layerSizes"></param>
        /// <param name="bufarr"></param>
        /// <param name="calc"></param>
        /// <param name="filter"></param>
        /// <returns></returns>
#endif
        public CvMat[] CreatePyramid(int extraLayers, double rate, CvSize[] layerSizes, CvArr bufarr, bool calc, CvFilter filter)
        {
            return Cv.CreatePyramid(this, extraLayers, rate, layerSizes, bufarr, calc, filter);
        }
        #endregion
        #region CrossProduct
#if LANG_JP
        /// <summary>
        /// 二つの3次元ベクトルの外積を計算する.
        /// dst = src1 × src2,  (dst1 = src12src23 - src13src22 , dst2 = src13src21 - src11src23 , dst3 = src11src22 - src12src21).
        /// </summary>
        /// <param name="src2">2番目の入力ベクトル</param>
        /// <param name="dst">出力ベクトル</param>
#else
        /// <summary>
        /// Calculates cross product of two 3D vectors
        /// </summary>
        /// <param name="src2">The second source vector. </param>
        /// <param name="dst">The destination vector. </param>
#endif
        public void CrossProduct(CvArr src2, CvArr dst)
        {
            Cv.CrossProduct(this, src2, dst);
        }
        #endregion
        #region CvtColor
#if LANG_JP
        /// <summary>
        /// 入力画像の色空間を変換する
        /// </summary>
        /// <param name="dst">出力画像. 入力画像と同じデータタイプ. チャンネル数は違うこともある．</param>
        /// <param name="code">色空間の変換の方法</param>
#else
        /// <summary>
        /// Converts image from one color space to another.
        /// </summary>
        /// <param name="dst">The destination image of the same data type as the source one. The number of channels may be different. </param>
        /// <param name="code">Color conversion operation that can be specifed using CV_&lt;src_color_space&gt;2&lt;dst_color_space&gt; constants (see below). </param>
#endif
        public void CvtColor(CvArr dst, ColorConversion code)
        {
            Cv.CvtColor(this, dst, code);
        }
        #endregion
        #region DCT
#if LANG_JP
        /// <summary>
        /// 次元あるいは2次元浮動小数点型配列の順方向・逆方向離散コサイン変換を行う
        /// </summary>
        /// <param name="dst">入力と同じサイズ・タイプの出力配列</param>
        /// <param name="flags">変換フラグ</param>
#else
        /// <summary>
        /// Performs forward or inverse Discrete Cosine transform of 1D or 2D floating-point array
        /// </summary>
        /// <param name="dst">Destination array of the same size and same type as the source. </param>
        /// <param name="flags">Transformation flags.</param>
#endif
        public void DCT(CvArr dst, DCTFlag flags)
        {
            Cv.DCT(this, dst, flags);
        }
        #endregion
        #region DecRefData
#if LANG_JP
        /// <summary>
        /// 参照カウンタのポインタが null ではない場合に CvMat あるいは CvMatND のデータの参照カウンタをデクリメントし，さらにカウンタが 0 になった場合にはデータを解放する．
        /// </summary>
#else
        /// <summary>
        /// Decrements array data reference counter．
        /// </summary>
#endif
        public void DecRefData()
        {
            Cv.DecRefData(this);
        }
        #endregion
        #region Det
#if LANG_JP
        /// <summary>
        /// 行列式を返す
        /// </summary>
        /// <returns>行列式</returns>
#else
        /// <summary>
        /// Returns determinant of matrix
        /// </summary>
        /// <returns>determinant of the square matrix mat</returns>
#endif
        public double Det()
        {
            return Cv.Det(this);
        }
        #endregion
        #region DFT
#if LANG_JP
        /// <summary>
        /// 1次元あるいは2次元浮動小数点型配列に対して離散フーリエ変換（DFT），逆離散フーリエ変換（IDFT）を行う.
        /// </summary>
        /// <param name="dst">入力配列と同じサイズ・タイプの出力配列</param>
        /// <param name="flags">変換フラグ</param>
#else
        /// <summary>
        /// Performs forward or inverse Discrete Fourier transform of 1D or 2D floating-point array
        /// </summary>
        /// <param name="dst">Destination array of the same size and same type as the source. </param>
        /// <param name="flags">Transformation flags</param>
#endif
        public void DFT(CvArr dst, DFTFlag flags)
        {
            Cv.DFT(this, dst, flags);
        }
#if LANG_JP
        /// <summary>
        /// 1次元あるいは2次元浮動小数点型配列に対して離散フーリエ変換（DFT），逆離散フーリエ変換（IDFT）を行う.
        /// </summary>
        /// <param name="dst">入力配列と同じサイズ・タイプの出力配列</param>
        /// <param name="flags">変換フラグ</param>
        /// <param name="nonzeroRows">入力配列の非0である行の数（2次元順変換の場合），あるいは出力配列で注目する行の数（2次元逆変換の場合）．</param>
#else
        /// <summary>
        /// Performs forward or inverse Discrete Fourier transform of 1D or 2D floating-point array
        /// </summary>
        /// <param name="dst">Destination array of the same size and same type as the source. </param>
        /// <param name="flags">Transformation flags</param>
        /// <param name="nonzeroRows">Number of nonzero rows to in the source array (in case of forward 2d transform), or a number of rows of interest in the destination array (in case of inverse 2d transform). If the value is negative, zero, or greater than the total number of rows, it is ignored. The parameter can be used to speed up 2d convolution/correlation when computing them via DFT.</param>
#endif
        public void DFT(CvArr dst, DFTFlag flags, int nonzeroRows)
        {
            Cv.DFT(this, dst, flags, nonzeroRows);
        }
#if LANG_JP
        /// <summary>
        /// 1次元あるいは2次元浮動小数点型配列に対して離散フーリエ変換（DFT），逆離散フーリエ変換（IDFT）を行う. cvDFTのエイリアス.
        /// </summary>
        /// <param name="dst">入力配列と同じサイズ・タイプの出力配列</param>
        /// <param name="flags">変換フラグ</param>
#else
        /// <summary>
        /// Performs forward or inverse Discrete Fourier transform of 1D or 2D floating-point array
        /// </summary>
        /// <param name="dst">Destination array of the same size and same type as the source. </param>
        /// <param name="flags">Transformation flags</param>
#endif
        public void FFT(CvArr dst, DFTFlag flags)
        {
            Cv.FFT(this, dst, flags);
        }
#if LANG_JP
        /// <summary>
        /// 1次元あるいは2次元浮動小数点型配列に対して離散フーリエ変換（DFT），逆離散フーリエ変換（IDFT）を行う.cvDFTのエイリアス.
        /// </summary>
        /// <param name="dst">入力配列と同じサイズ・タイプの出力配列</param>
        /// <param name="flags">変換フラグ</param>
        /// <param name="nonzeroRows">入力配列の非0である行の数（2次元順変換の場合），あるいは出力配列で注目する行の数（2次元逆変換の場合）．</param>
#else
        /// <summary>
        /// Performs forward or inverse Discrete Fourier transform of 1D or 2D floating-point array
        /// </summary>
        /// <param name="dst">Destination array of the same size and same type as the source. </param>
        /// <param name="flags">Transformation flags</param>
        /// <param name="nonzeroRows">Number of nonzero rows to in the source array (in case of forward 2d transform), or a number of rows of interest in the destination array (in case of inverse 2d transform). If the value is negative, zero, or greater than the total number of rows, it is ignored. The parameter can be used to speed up 2d convolution/correlation when computing them via DFT.</param>
#endif
        public void FFT(CvArr dst, DFTFlag flags, int nonzeroRows)
        {
            Cv.FFT(this, dst, flags, nonzeroRows);
        }
        #endregion
        #region Dilate
#if LANG_JP
        /// <summary>
        /// 隣接ピクセルの形状を決定する指定された構造要素を用いて，入力画像を膨張する. 
        /// この関数はインプレースモード（src=dstである入力）をサポートする．膨張は複数回 (iterations) 繰り返すことができる．
        /// カラー画像の場合は，それぞれのチャンネルが独立に処理される． 
        /// </summary>
        /// <param name="dst">出力画像</param>
#else
        /// <summary>
        /// Dilates image by using arbitrary structuring element.
        /// </summary>
        /// <param name="dst">Destination image. </param>
#endif
        public void Dilate(CvArr dst)
        {
            Cv.Dilate(this, dst);
        }
#if LANG_JP
        /// <summary>
        /// 隣接ピクセルの形状を決定する指定された構造要素を用いて，入力画像を膨張する. 
        /// この関数はインプレースモード（src=dstである入力）をサポートする．膨張は複数回 (iterations) 繰り返すことができる．
        /// カラー画像の場合は，それぞれのチャンネルが独立に処理される． 
        /// </summary>
        /// <param name="dst">出力画像</param>
        /// <param name="element">膨張に用いる構造要素．nullの場合は, 3×3 の矩形形状の構造要素を用いる．</param>
#else
        /// <summary>
        /// Dilates image by using arbitrary structuring element.
        /// </summary>
        /// <param name="dst">Destination image. </param>
        /// <param name="element">Structuring element used for erosion. If it is null, a 3x3 rectangular structuring element is used. </param>
#endif
        public void Dilate(CvArr dst, IplConvKernel element)
        {
            Cv.Dilate(this, dst, element);
        }
#if LANG_JP
        /// <summary>
        /// 隣接ピクセルの形状を決定する指定された構造要素を用いて，入力画像を膨張する. 
        /// この関数はインプレースモード（src=dstである入力）をサポートする．膨張は複数回 (iterations) 繰り返すことができる．
        /// カラー画像の場合は，それぞれのチャンネルが独立に処理される． 
        /// </summary>
        /// <param name="dst">出力画像</param>
        /// <param name="element">膨張に用いる構造要素．nullの場合は, 3×3 の矩形形状の構造要素を用いる．</param>
        /// <param name="iterations">膨張の回数</param>
#else
        /// <summary>
        /// Dilates image by using arbitrary structuring element.
        /// </summary>
        /// <param name="dst">Destination image. </param>
        /// <param name="element">Structuring element used for erosion. If it is null, a 3x3 rectangular structuring element is used. </param>
        /// <param name="iterations">Number of times erosion is applied. </param>
#endif
        public void Dilate(CvArr dst, IplConvKernel element, int iterations)
        {
            Cv.Dilate(this, dst, element, iterations);
        }
        #endregion
        #region DistTransform
#if LANG_JP
        /// <summary>
        /// 入力画像中の値が0でないピクセルから，最も近い値が0のピクセルまでの距離を計算する
        /// </summary>
        /// <param name="dst">距離計算結果をピクセル値として持つ出力画像 （32ビット浮動小数点型，シングルチャンネル）</param>
#else
        /// <summary>
        /// Calculates distance to closest zero pixel for all non-zero pixels of source image.
        /// </summary>
        /// <param name="dst">Output image with calculated distances (32-bit floating-point, single-channel). </param>
#endif
        public void DistTransform(CvArr dst)
        {
            Cv.DistTransform(this, dst);
        }
#if LANG_JP
        /// <summary>
        /// 入力画像中の値が0でないピクセルから，最も近い値が0のピクセルまでの距離を計算する
        /// </summary>
        /// <param name="dst">距離計算結果をピクセル値として持つ出力画像 （32ビット浮動小数点型，シングルチャンネル）</param>
        /// <param name="distanceType">距離の種類．L1, L2, C か User</param>
#else
        /// <summary>
        /// Calculates distance to closest zero pixel for all non-zero pixels of source image.
        /// </summary>
        /// <param name="dst">Output image with calculated distances (32-bit floating-point, single-channel). </param>
        /// <param name="distanceType">Type of distance. </param>
#endif
        public void DistTransform(CvArr dst, DistanceType distanceType)
        {
            Cv.DistTransform(this, dst, distanceType);
        }
#if LANG_JP
        /// <summary>
        /// 入力画像中の値が0でないピクセルから，最も近い値が0のピクセルまでの距離を計算する
        /// </summary>
        /// <param name="dst">距離計算結果をピクセル値として持つ出力画像 （32ビット浮動小数点型，シングルチャンネル）</param>
        /// <param name="distanceType">距離の種類．L1, L2, C か User</param>
        /// <param name="maskSize">距離変換マスクのサイズで，3，5，0 のいずれか． L1，C の場合，このパラメータ値は3に固定される．mask_size==0の場合，距離計算に別の近似無しアルゴリズムが用いられる．</param>
#else
        /// <summary>
        /// Calculates distance to closest zero pixel for all non-zero pixels of source image.
        /// </summary>
        /// <param name="dst">Output image with calculated distances (32-bit floating-point, single-channel). </param>
        /// <param name="distanceType">Type of distance. </param>
        /// <param name="maskSize">Size of distance transform mask; can be 3, 5 or 0. In case of CV_DIST_L1 or CV_DIST_C the parameter is forced to 3, because 3×3 mask gives the same result as 5x5 yet it is faster. When mask_size==0, a different non-approximate algorithm is used to calculate distances. </param>
#endif
        public void DistTransform(CvArr dst, DistanceType distanceType, int maskSize)
        {
            Cv.DistTransform(this, dst, distanceType, maskSize);
        }
#if LANG_JP
        /// <summary>
        /// 入力画像中の値が0でないピクセルから，最も近い値が0のピクセルまでの距離を計算する
        /// </summary>
        /// <param name="dst">距離計算結果をピクセル値として持つ出力画像 （32ビット浮動小数点型，シングルチャンネル）</param>
        /// <param name="distanceType">距離の種類．L1, L2, C か User</param>
        /// <param name="maskSize">距離変換マスクのサイズで，3，5，0 のいずれか． L1，C の場合，このパラメータ値は3に固定される．mask_size==0の場合，距離計算に別の近似無しアルゴリズムが用いられる．</param>
        /// <param name="mask">ユーザ定義の距離の場合はユーザ定義のマスク．3×3のマスクを用いる場合は2つの値（上下シフト値，斜めシフト値）を指定，5×5のマスクを用いる場合は3つの値（上下シフト値，斜めシフト値，ナイト移動シフト値（桂馬飛びのシフト値））を指定する．</param>
#else
        /// <summary>
        /// Calculates distance to closest zero pixel for all non-zero pixels of source image.
        /// </summary>
        /// <param name="dst">Output image with calculated distances (32-bit floating-point, single-channel). </param>
        /// <param name="distanceType">Type of distance. </param>
        /// <param name="maskSize">Size of distance transform mask; can be 3, 5 or 0. In case of CV_DIST_L1 or CV_DIST_C the parameter is forced to 3, because 3×3 mask gives the same result as 5x5 yet it is faster. When mask_size==0, a different non-approximate algorithm is used to calculate distances. </param>
        /// <param name="mask">User-defined mask in case of user-defined distance, it consists of 2 numbers (horizontal/vertical shift cost, diagonal shift cost) in case of 3x3 mask and 3 numbers (horizontal/vertical shift cost, diagonal shift cost, knight’s move cost) in case of 5x5 mask. </param>
#endif
        public void DistTransform(CvArr dst, DistanceType distanceType, int maskSize, float[] mask)
        {
            Cv.DistTransform(this, dst, distanceType, maskSize, mask);
        }
#if LANG_JP
        /// <summary>
        /// 入力画像中の値が0でないピクセルから，最も近い値が0のピクセルまでの距離を計算する
        /// </summary>
        /// <param name="dst">距離計算結果をピクセル値として持つ出力画像 （32ビット浮動小数点型，シングルチャンネル）</param>
        /// <param name="distanceType">距離の種類．L1, L2, C か User</param>
        /// <param name="maskSize">距離変換マスクのサイズで，3，5，0 のいずれか． L1，C の場合，このパラメータ値は3に固定される．mask_size==0の場合，距離計算に別の近似無しアルゴリズムが用いられる．</param>
        /// <param name="mask">ユーザ定義の距離の場合はユーザ定義のマスク．3×3のマスクを用いる場合は2つの値（上下シフト値，斜めシフト値）を指定，5×5のマスクを用いる場合は3つの値（上下シフト値，斜めシフト値，ナイト移動シフト値（桂馬飛びのシフト値））を指定する．</param>
        /// <param name="labels">オプション出力．整数ラベルに変換された2次元配列で，src ，dstと同じサイズ．現在は mask_size==3 あるいは 5 のときのみに使用される．</param>
#else
        /// <summary>
        /// Calculates distance to closest zero pixel for all non-zero pixels of source image.
        /// </summary>
        /// <param name="dst">Output image with calculated distances (32-bit floating-point, single-channel). </param>
        /// <param name="distanceType">Type of distance. </param>
        /// <param name="maskSize">Size of distance transform mask; can be 3, 5 or 0. In case of CV_DIST_L1 or CV_DIST_C the parameter is forced to 3, because 3×3 mask gives the same result as 5x5 yet it is faster. When mask_size==0, a different non-approximate algorithm is used to calculate distances. </param>
        /// <param name="mask">User-defined mask in case of user-defined distance, it consists of 2 numbers (horizontal/vertical shift cost, diagonal shift cost) in case of 3x3 mask and 3 numbers (horizontal/vertical shift cost, diagonal shift cost, knight’s move cost) in case of 5x5 mask. </param>
        /// <param name="labels">The optional output 2d array of labels of integer type and the same size as src and dst, can now be used only with mask_size==3 or 5. </param>
#endif
        public void DistTransform(CvArr dst, DistanceType distanceType, int maskSize, float[] mask, CvArr labels)
        {
            Cv.DistTransform(this, dst, distanceType, maskSize, mask, labels);
        }
        #endregion
        #region Div
#if LANG_JP
        /// <summary>
        /// 二つの配列の要素同士を除算する (scale=1).
        /// dst(I)=scale*src1(I)/src2(I) [src1!=nullの場合],  
        /// dst(I)=scale/src2(I) [src1=nullの場合]
        /// </summary>
        /// <param name="src2">2番目の入力配列</param>
        /// <param name="dst">出力配列</param>
#else
        /// <summary>
        /// Performs per-element division of two arrays
        /// </summary>
        /// <param name="src2">The second source array. </param>
        /// <param name="dst">The destination array. </param>
#endif
        public void Div(CvArr src2, CvArr dst)
        {
            Cv.Div(this, src2, dst);
        }
#if LANG_JP
        /// <summary>
        /// 二つの配列の要素同士を除算する.
        /// dst(I)=scale*src1(I)/src2(I) [src1!=nullの場合],  
        /// dst(I)=scale/src2(I) [src1=nullの場合]
        /// </summary>
        /// <param name="src2">2番目の入力配列</param>
        /// <param name="dst">出力配列</param>
        /// <param name="scale">任意のスケーリング係数</param>
#else
        /// <summary>
        /// Performs per-element division of two arrays
        /// </summary>
        /// <param name="src2">The second source array. </param>
        /// <param name="dst">The destination array. </param>
        /// <param name="scale">Optional scale factor </param>
#endif
        public void Div(CvArr src2, CvArr dst, double scale)
        {
            Cv.Div(this, src2, dst, scale);
        }
        #endregion
        #region DrawChessboardCorners
#if LANG_JP
        /// <summary>
        /// チェスボードからコーナーが完全に検出されていない場合（pattern_was_found=false）は，検出されたコーナーそれぞれに赤色の円を描く．
        /// また完全に検出されている場合（pattern_was_found=true）は，色付けされた各コーナを線分で接続して表示する． 
        /// </summary>
        /// <param name="patternSize">チェスボードの各行と各列の内部コーナーの数．</param>
        /// <param name="corners">検出されたコーナーの配列．</param>
        /// <param name="patternWasFound">チェスボードからコーナーが完全に発見された(true)か，そうでない(false)かを示す．</param>
#else
        /// <summary>
        /// Draws the individual chessboard corners detected (as red circles) in case if the board was not found (pattern_was_found=0) or the colored corners connected with lines when the board was found (pattern_was_found≠0). 
        /// </summary>
        /// <param name="patternSize">The number of inner corners per chessboard row and column. </param>
        /// <param name="corners">The array of corners detected. </param>
        /// <param name="patternWasFound">Indicates whether the complete board was found (≠0) or not (=0). One may just pass the return value cvFindChessboardCorners here. </param>
#endif
        public void DrawChessboardCorners(CvSize patternSize, CvPoint2D32f[] corners, bool patternWasFound)
        {
            Cv.DrawChessboardCorners(this, patternSize, corners, patternWasFound);
        }
        #endregion
        #region DrawContours
#if LANG_JP
        /// <summary>
        /// 画像の外側輪郭線，または内側輪郭線を描画する
        /// </summary>
        /// <param name="contour">最初の輪郭へのポインタ</param>
        /// <param name="externalColor">外側輪郭線の色</param>
        /// <param name="holeColor">内側輪郭線（穴）の色</param>
        /// <param name="maxLevel">描画される輪郭の最大レベル． 0にした場合，contourのみが描画される． 1にした場合，先頭の輪郭と，同レベルのすべての輪郭が描画される． 2にした場合，先頭の輪郭と同レベルのすべての輪郭と，先頭の輪郭の一つ下のレベルのすべての輪郭が描画される．以下同様．</param>
#else
        /// <summary>
        /// Draws contour outlines or interiors in the image
        /// </summary>
        /// <param name="contour">Reference to the first contour. </param>
        /// <param name="externalColor">Color of the external contours. </param>
        /// <param name="holeColor">Color of internal contours (holes). </param>
        /// <param name="maxLevel">Maximal level for drawn contours. If 0, only contour is drawn. If 1, the contour and all contours after it on the same level are drawn. If 2, all contours after and all contours one level below the contours are drawn, etc. If the value is negative, the function does not draw the contours following after contour but draws child contours of contour up to abs(max_level)-1 level. </param>
#endif
        public void DrawContours(CvSeq<CvPoint> contour, CvScalar externalColor, CvScalar holeColor, int maxLevel)
        {
            Cv.DrawContours(this, contour, externalColor, holeColor, maxLevel);
        }
#if LANG_JP
        /// <summary>
        /// 画像の外側輪郭線，または内側輪郭線を描画する
        /// </summary>
        /// <param name="contour">最初の輪郭へのポインタ</param>
        /// <param name="externalColor">外側輪郭線の色</param>
        /// <param name="holeColor">内側輪郭線（穴）の色</param>
        /// <param name="maxLevel">描画される輪郭の最大レベル． 0にした場合，contourのみが描画される． 1にした場合，先頭の輪郭と，同レベルのすべての輪郭が描画される． 2にした場合，先頭の輪郭と同レベルのすべての輪郭と，先頭の輪郭の一つ下のレベルのすべての輪郭が描画される．以下同様．</param>
        /// <param name="thickness">描画される輪郭線の太さ. 負(例えば=Cv.FILLED)にした場合には，内部を塗りつぶす．</param>
#else
        /// <summary>
        /// Draws contour outlines or interiors in the image
        /// </summary>
        /// <param name="contour">Reference to the first contour. </param>
        /// <param name="externalColor">Color of the external contours. </param>
        /// <param name="holeColor">Color of internal contours (holes). </param>
        /// <param name="maxLevel">Maximal level for drawn contours. If 0, only contour is drawn. If 1, the contour and all contours after it on the same level are drawn. If 2, all contours after and all contours one level below the contours are drawn, etc. If the value is negative, the function does not draw the contours following after contour but draws child contours of contour up to abs(max_level)-1 level. </param>
        /// <param name="thickness">Thickness of lines the contours are drawn with. If it is negative (e.g. =CV_FILLED), the contour interiors are drawn. </param>
#endif
        public void DrawContours(CvSeq<CvPoint> contour, CvScalar externalColor, CvScalar holeColor, int maxLevel, int thickness)
        {
            Cv.DrawContours(this, contour, externalColor, holeColor, maxLevel, thickness);
        }
#if LANG_JP
        /// <summary>
        /// 画像の外側輪郭線，または内側輪郭線を描画する
        /// </summary>
        /// <param name="contour">最初の輪郭へのポインタ</param>
        /// <param name="externalColor">外側輪郭線の色</param>
        /// <param name="holeColor">内側輪郭線（穴）の色</param>
        /// <param name="maxLevel">描画される輪郭の最大レベル． 0にした場合，contourのみが描画される． 1にした場合，先頭の輪郭と，同レベルのすべての輪郭が描画される． 2にした場合，先頭の輪郭と同レベルのすべての輪郭と，先頭の輪郭の一つ下のレベルのすべての輪郭が描画される．以下同様．</param>
        /// <param name="thickness">描画される輪郭線の太さ. 負(例えば=Cv.FILLED)にした場合には，内部を塗りつぶす．</param>
        /// <param name="lineType">線の種類</param>
#else
        /// <summary>
        /// Draws contour outlines or interiors in the image
        /// </summary>
        /// <param name="contour">Reference to the first contour. </param>
        /// <param name="externalColor">Color of the external contours. </param>
        /// <param name="holeColor">Color of internal contours (holes). </param>
        /// <param name="maxLevel">Maximal level for drawn contours. If 0, only contour is drawn. If 1, the contour and all contours after it on the same level are drawn. If 2, all contours after and all contours one level below the contours are drawn, etc. If the value is negative, the function does not draw the contours following after contour but draws child contours of contour up to abs(max_level)-1 level. </param>
        /// <param name="thickness">Thickness of lines the contours are drawn with. If it is negative (e.g. =CV_FILLED), the contour interiors are drawn. </param>
        /// <param name="lineType">Type of the contour segments.</param>
#endif
        public void DrawContours(CvSeq<CvPoint> contour, CvScalar externalColor, CvScalar holeColor, int maxLevel, int thickness, LineType lineType)
        {
            Cv.DrawContours(this, contour, externalColor, holeColor, maxLevel, thickness, lineType);
        }
#if LANG_JP
        /// <summary>
        /// 画像の外側輪郭線，または内側輪郭線を描画する
        /// </summary>
        /// <param name="contour">最初の輪郭へのポインタ</param>
        /// <param name="externalColor">外側輪郭線の色</param>
        /// <param name="holeColor">内側輪郭線（穴）の色</param>
        /// <param name="maxLevel">描画される輪郭の最大レベル． 0にした場合，contourのみが描画される． 1にした場合，先頭の輪郭と，同レベルのすべての輪郭が描画される． 2にした場合，先頭の輪郭と同レベルのすべての輪郭と，先頭の輪郭の一つ下のレベルのすべての輪郭が描画される．以下同様．</param>
        /// <param name="thickness">描画される輪郭線の太さ. 負(例えば=Cv.FILLED)にした場合には，内部を塗りつぶす．</param>
        /// <param name="lineType">線の種類</param>
        /// <param name="offset">全ての座標を指定した値だけシフトする</param>
#else
        /// <summary>
        /// Draws contour outlines or interiors in the image
        /// </summary>
        /// <param name="contour">Reference to the first contour. </param>
        /// <param name="externalColor">Color of the external contours. </param>
        /// <param name="holeColor">Color of internal contours (holes). </param>
        /// <param name="maxLevel">Maximal level for drawn contours. If 0, only contour is drawn. If 1, the contour and all contours after it on the same level are drawn. If 2, all contours after and all contours one level below the contours are drawn, etc. If the value is negative, the function does not draw the contours following after contour but draws child contours of contour up to abs(max_level)-1 level. </param>
        /// <param name="thickness">Thickness of lines the contours are drawn with. If it is negative (e.g. =CV_FILLED), the contour interiors are drawn. </param>
        /// <param name="lineType">Type of the contour segments.</param>
        /// <param name="offset">Shift all the point coordinates by the specified value. It is useful in case if the contours retrieved in some image ROI and then the ROI offset needs to be taken into account during the rendering. </param>
#endif
        public void DrawContours(CvSeq<CvPoint> contour, CvScalar externalColor, CvScalar holeColor, int maxLevel, int thickness, LineType lineType, CvPoint offset)
        {
            Cv.DrawContours(this, contour, externalColor, holeColor, maxLevel, thickness, lineType, offset);
        }
        #endregion
        #region EigenVV
#if LANG_JP
        /// <summary>
        /// 対称行列の固有値と固有ベクトルを計算する
        /// </summary>
        /// <param name="evects">固有ベクトルの出力行列．連続した行として保存される． </param>
        /// <param name="evals">固有値ベクトルの出力ベクトル．降順に保存される（もちろん固有値と固有ベクトルの順番は一致する）．</param>
#else
        /// <summary>
        /// Computes eigenvalues and eigenvectors of symmetric matrix
        /// </summary>
        /// <param name="evects">The output matrix of eigenvectors, stored as a subsequent rows. </param>
        /// <param name="evals">The output vector of eigenvalues, stored in the descending order (order of eigenvalues and eigenvectors is synchronized, of course). </param>
#endif
        public void EigenVV(CvArr evects, CvArr evals)
        {
            Cv.EigenVV(this, evects, evals);
        }
#if LANG_JP
        /// <summary>
        /// 対称行列の固有値と固有ベクトルを計算する
        /// </summary>
        /// <param name="evects">固有ベクトルの出力行列．連続した行として保存される． </param>
        /// <param name="evals">固有値ベクトルの出力ベクトル．降順に保存される（もちろん固有値と固有ベクトルの順番は一致する）．</param>
        /// <param name="eps">対角化の精度（一般的に，DBL_EPSILON=≈10^-15 で十分である）</param>
#else
        /// <summary>
        /// Computes eigenvalues and eigenvectors of symmetric matrix
        /// </summary>
        /// <param name="evects">The output matrix of eigenvectors, stored as a subsequent rows. </param>
        /// <param name="evals">The output vector of eigenvalues, stored in the descending order (order of eigenvalues and eigenvectors is synchronized, of course). </param>
        /// <param name="eps">Accuracy of diagonalization (typically, DBL_EPSILON=≈10-15 is enough). </param>
#endif
        public void EigenVV(CvArr evects, CvArr evals, double eps)
        {
            Cv.EigenVV(this, evects, evals, eps);
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
#endif
        public void Ellipse(CvPoint center, CvSize axes, double angle, double startAngle, double endAngle, CvScalar color)
        {
            Cv.Ellipse(this, center, axes, angle, startAngle, endAngle, color);
        }
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
        /// <param name="thickness">楕円弧の線の幅</param>
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
        /// <param name="thickness">Thickness of the ellipse arc. </param>
#endif
        public void Ellipse(CvPoint center, CvSize axes, double angle, double startAngle, double endAngle, CvScalar color, int thickness)
        {
            Cv.Ellipse(this, center, axes, angle, startAngle, endAngle, color, thickness);
        }
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
        /// <param name="thickness">楕円弧の線の幅</param>
        /// <param name="lineType">楕円弧の線の種類</param>
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
        /// <param name="thickness">Thickness of the ellipse arc. </param>
        /// <param name="lineType">Type of the ellipse boundary.</param>
#endif
        public void Ellipse(CvPoint center, CvSize axes, double angle, double startAngle, double endAngle, CvScalar color, int thickness, LineType lineType)
        {
            Cv.Ellipse(this, center, axes, angle, startAngle, endAngle, color, thickness, lineType);
        }
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
        /// <param name="thickness">楕円弧の線の幅</param>
        /// <param name="lineType">楕円弧の線の種類</param>
        /// <param name="shift">中心座標と軸の長さの小数点以下の桁を表すビット数</param>
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
        /// <param name="thickness">Thickness of the ellipse arc. </param>
        /// <param name="lineType">Type of the ellipse boundary.</param>
        /// <param name="shift">Number of fractional bits in the center coordinates and axes' values. </param>
#endif
        public void Ellipse(CvPoint center, CvSize axes, double angle, double startAngle, double endAngle, CvScalar color, int thickness, LineType lineType, int shift)
        {
            Cv.Ellipse(this, center, axes, angle, startAngle, endAngle, color, thickness, lineType, shift);
        }
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
#endif
        public void DrawEllipse(CvPoint center, CvSize axes, double angle, double startAngle, double endAngle, CvScalar color)
        {
            Cv.DrawEllipse(this, center, axes, angle, startAngle, endAngle, color);
        }
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
        /// <param name="thickness">楕円弧の線の幅</param>
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
        /// <param name="thickness">Thickness of the ellipse arc. </param>
#endif
        public void DrawEllipse(CvPoint center, CvSize axes, double angle, double startAngle, double endAngle, CvScalar color, int thickness)
        {
            Cv.DrawEllipse(this, center, axes, angle, startAngle, endAngle, color, thickness);
        }
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
        /// <param name="thickness">楕円弧の線の幅</param>
        /// <param name="lineType">楕円弧の線の種類</param>
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
        /// <param name="thickness">Thickness of the ellipse arc. </param>
        /// <param name="lineType">Type of the ellipse boundary.</param>
#endif
        public void DrawEllipse(CvPoint center, CvSize axes, double angle, double startAngle, double endAngle, CvScalar color, int thickness, LineType lineType)
        {
            Cv.DrawEllipse(this, center, axes, angle, startAngle, endAngle, color, thickness, lineType);
        }
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
        /// <param name="thickness">楕円弧の線の幅</param>
        /// <param name="lineType">楕円弧の線の種類</param>
        /// <param name="shift">中心座標と軸の長さの小数点以下の桁を表すビット数</param>
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
        /// <param name="thickness">Thickness of the ellipse arc. </param>
        /// <param name="lineType">Type of the ellipse boundary.</param>
        /// <param name="shift">Number of fractional bits in the center coordinates and axes' values. </param>
#endif
        public void DrawEllipse(CvPoint center, CvSize axes, double angle, double startAngle, double endAngle, CvScalar color, int thickness, LineType lineType, int shift)
        {
            Cv.DrawEllipse(this, center, axes, angle, startAngle, endAngle, color, thickness, lineType, shift);
        }
        #endregion
        #region EllipseBox
#if LANG_JP
        /// <summary>
        /// 枠だけの楕円，もしくは塗りつぶされた楕円を描画する
        /// </summary>
        /// <param name="box">描画したい楕円を囲む矩形領域．</param>
        /// <param name="color">楕円の色．</param>
#else
        /// <summary>
        /// Draws simple or thick elliptic arc or fills ellipse sector
        /// </summary>
        /// <param name="box">The enclosing box of the ellipse drawn </param>
        /// <param name="color">Ellipse color. </param>
#endif
        public void EllipseBox(CvBox2D box, CvScalar color)
        {
            Cv.EllipseBox(this, box, color);
        }
#if LANG_JP
        /// <summary>
        /// 枠だけの楕円，もしくは塗りつぶされた楕円を描画する
        /// </summary>
        /// <param name="box">描画したい楕円を囲む矩形領域．</param>
        /// <param name="color">楕円の色．</param>
        /// <param name="thickness">楕円境界線の幅．</param>
#else
        /// <summary>
        /// Draws simple or thick elliptic arc or fills ellipse sector
        /// </summary>
        /// <param name="box">The enclosing box of the ellipse drawn </param>
        /// <param name="color">Ellipse color. </param>
        /// <param name="thickness">Thickness of the ellipse boundary. </param>
#endif
        public void EllipseBox(CvBox2D box, CvScalar color, int thickness)
        {
            Cv.EllipseBox(this, box, color, thickness);
        }
#if LANG_JP
        /// <summary>
        /// 枠だけの楕円，もしくは塗りつぶされた楕円を描画する
        /// </summary>
        /// <param name="box">描画したい楕円を囲む矩形領域．</param>
        /// <param name="color">楕円の色．</param>
        /// <param name="thickness">楕円境界線の幅．</param>
        /// <param name="lineType">楕円境界線の種類．</param>
#else
        /// <summary>
        /// Draws simple or thick elliptic arc or fills ellipse sector
        /// </summary>
        /// <param name="box">The enclosing box of the ellipse drawn </param>
        /// <param name="color">Ellipse color. </param>
        /// <param name="thickness">Thickness of the ellipse boundary. </param>
        /// <param name="lineType">Type of the ellipse boundary</param>
#endif
        public void EllipseBox(CvBox2D box, CvScalar color, int thickness, LineType lineType)
        {
            Cv.EllipseBox(this, box, color, thickness, lineType);
        }
#if LANG_JP
        /// <summary>
        /// 枠だけの楕円，もしくは塗りつぶされた楕円を描画する
        /// </summary>
        /// <param name="box">描画したい楕円を囲む矩形領域．</param>
        /// <param name="color">楕円の色．</param>
        /// <param name="thickness">楕円境界線の幅．</param>
        /// <param name="lineType">楕円境界線の種類．</param>
        /// <param name="shift">矩形領域の頂点座標の小数点以下の桁を表すビット数．</param>
#else
        /// <summary>
        /// Draws simple or thick elliptic arc or fills ellipse sector
        /// </summary>
        /// <param name="box">The enclosing box of the ellipse drawn </param>
        /// <param name="color">Ellipse color. </param>
        /// <param name="thickness">Thickness of the ellipse boundary. </param>
        /// <param name="lineType">Type of the ellipse boundary</param>
        /// <param name="shift">Number of fractional bits in the box vertex coordinates. </param>
#endif
        public void EllipseBox(CvBox2D box, CvScalar color, int thickness, LineType lineType, int shift)
        {
            Cv.EllipseBox(this, box, color, thickness, lineType, shift);
        }
        #endregion
        #region EqualizeHist
#if LANG_JP
        /// <summary>
        /// グレースケール画像のヒストグラムを均一化する．輝度を均一化し，画像のコントラストを上げる．
        /// </summary>
        /// <param name="dst">出力画像．srcと同じサイズ, 同じデータタイプ．</param>
#else
        /// <summary>
        /// Equalizes histogram of grayscale image.
        /// </summary>
        /// <param name="dst">The output image of the same size and the same data type as src. </param>
#endif
        public void EqualizeHist(CvArr dst)
        {
            Cv.EqualizeHist(this, dst);
        }
        #endregion
        #region Erode
#if LANG_JP
        /// <summary>
        /// 隣接ピクセルの形状を決定する指定された構造要素を用いて，入力画像を収縮する. 
        /// この関数はインプレースモード（src=dstである入力）をサポートする．収縮は複数回 (iterations) 繰り返すことができる．
        /// カラー画像の場合は，それぞれのチャンネルが独立に処理される． 
        /// </summary>
        /// <param name="dst">出力画像</param>
#else
        /// <summary>
        /// Erodes image by using arbitrary structuring element.
        /// </summary>
        /// <param name="dst">Destination image. </param>
#endif
        public void Erode(CvArr dst)
        {
            Cv.Erode(this, dst);
        }
#if LANG_JP
        /// <summary>
        /// 隣接ピクセルの形状を決定する指定された構造要素を用いて，入力画像を収縮する. 
        /// この関数はインプレースモード（src=dstである入力）をサポートする．収縮は複数回 (iterations) 繰り返すことができる．
        /// カラー画像の場合は，それぞれのチャンネルが独立に処理される． 
        /// </summary>
        /// <param name="dst">出力画像</param>
        /// <param name="element">収縮に用いる構造要素．nullの場合は, 3×3 の矩形形状の構造要素を用いる．</param>
#else
        /// <summary>
        /// Erodes image by using arbitrary structuring element.
        /// </summary>
        /// <param name="dst">Destination image. </param>
        /// <param name="element">Structuring element used for erosion. If it is null, a 3x3 rectangular structuring element is used. </param>
#endif
        public void Erode(CvArr dst, IplConvKernel element)
        {
            Cv.Erode(this, dst, element);
        }
#if LANG_JP
        /// <summary>
        /// 隣接ピクセルの形状を決定する指定された構造要素を用いて，入力画像を収縮する. 
        /// この関数はインプレースモード（src=dstである入力）をサポートする．収縮は複数回 (iterations) 繰り返すことができる．
        /// カラー画像の場合は，それぞれのチャンネルが独立に処理される． 
        /// </summary>
        /// <param name="dst">出力画像</param>
        /// <param name="element">収縮に用いる構造要素．nullの場合は, 3×3 の矩形形状の構造要素を用いる．</param>
        /// <param name="iterations">収縮の回数</param>
#else
        /// <summary>
        /// Erodes image by using arbitrary structuring element.
        /// </summary>
        /// <param name="dst">Destination image. </param>
        /// <param name="element">Structuring element used for erosion. If it is null, a 3x3 rectangular structuring element is used. </param>
        /// <param name="iterations">Number of times erosion is applied. </param>
#endif
        public void Erode(CvArr dst, IplConvKernel element, int iterations)
        {
            Cv.Erode(this, dst, element, iterations);
        }
        #endregion
        #region Exp
#if LANG_JP
        /// <summary>
        /// すべての配列要素について自然対数の底（ネイピア数）eのべき乗を求める
        /// </summary>
        /// <param name="dst">出力配列．倍精度の浮動小数点型（double），または入力配列と同じタイプでなければならない．</param>
#else
        /// <summary>
        /// Calculates exponent of every array element
        /// </summary>
        /// <param name="dst">The destination array, it should have double type or the same type as the source. </param>
#endif
        public void Exp(CvArr dst)
        {
            Cv.Exp(this, dst);
        }
        #endregion
        #region ExtractMSER
#if LANG_JP
        /// <summary>
        /// Extracts the contours of Maximally Stable Extremal Regions
        /// </summary>
        /// <param name="mask"></param>
        /// <param name="storage"></param>
        /// <param name="params"></param>
#else
        /// <summary>
        /// Extracts the contours of Maximally Stable Extremal Regions
        /// </summary>
        /// <param name="mask"></param>
        /// <param name="storage"></param>
        /// <param name="params"></param>
#endif
        public CvContour[] ExtractMSER(CvArr mask, CvMemStorage storage, CvMSERParams @params)
        {
            CvContour[] contours;
            Cv.ExtractMSER(this, mask, out contours, storage, @params);
            return contours;
        }
        #endregion
        #region ExtractSURF
#if LANG_JP
        /// <summary>
        /// 画像中からSURF（Speeded Up Robust Features）を検出する
        /// </summary>
        /// <param name="mask">オプション：8ビットのマスク画像．非0 のマスクピクセルが50%以上を占める領域からのみ，特徴点検出を行う．</param>
        /// <param name="keypoints">出力パラメータ．キーポイントのシーケンスへのポインタのポインタ． これは，CvSURFPoint 構造体のシーケンスになる</param>
        /// <param name="descriptors">オプション：出力パラメータ．ディスクリプタのシーケンスへのポインタのポインタ． シーケンスの各要素は，params.extended の値に依存して， 64-要素，あるいは 128-要素の浮動小数点数（CV_32F）ベクトルとなる． パラメータが NULL の場合，ディスクリプタは計算されない．</param>
        /// <param name="storage">キーポイントとディスクリプタが格納されるメモリストレージ</param>
        /// <param name="param">CvSURFParams 構造体に入れられた，様々なアルゴリズムパラメータ</param>
#else
        /// <summary>
        /// Extracts Speeded Up Robust Features from image
        /// </summary>
        /// <param name="mask">The optional input 8-bit mask. The features are only found in the areas that contain more than 50% of non-zero mask pixels. </param>
        /// <param name="keypoints">The output parameter; double pointer to the sequence of keypoints. This will be the sequence of CvSURFPoint structures.</param>
        /// <param name="descriptors">The optional output parameter; double pointer to the sequence of descriptors; Depending on the params.extended value, each element of the sequence will be either 64-element or 128-element floating-point (CV_32F) vector. If the parameter is null, the descriptors are not computed. </param>
        /// <param name="storage">Memory storage where keypoints and descriptors will be stored. </param>
        /// <param name="param">Various algorithm parameters put to the structure CvSURFParams</param>
#endif
        public void ExtractSURF(CvArr mask, out CvSeq<CvSURFPoint> keypoints, out CvSeq<IntPtr> descriptors, CvMemStorage storage, CvSURFParams param)
        {
            Cv.ExtractSURF(this, mask, out keypoints, out descriptors, storage, param);
        }
#if LANG_JP
        /// <summary>
        /// 画像中からSURF（Speeded Up Robust Features）を検出する
        /// </summary>
        /// <param name="mask">オプション：8ビットのマスク画像．非0 のマスクピクセルが50%以上を占める領域からのみ，特徴点検出を行う．</param>
        /// <param name="keypoints">出力パラメータ．キーポイントのシーケンスへのポインタのポインタ． これは，CvSURFPoint 構造体のシーケンスになる</param>
        /// <param name="descriptors">オプション：出力パラメータ．ディスクリプタのシーケンスへのポインタのポインタ． シーケンスの各要素は，params.extended の値に依存して， 64-要素，あるいは 128-要素の浮動小数点数（CV_32F）ベクトルとなる． パラメータが NULL の場合，ディスクリプタは計算されない．</param>
        /// <param name="storage">キーポイントとディスクリプタが格納されるメモリストレージ</param>
        /// <param name="param">CvSURFParams 構造体に入れられた，様々なアルゴリズムパラメータ</param>
        /// <param name="useProvidedKeyPts">If useProvidedKeyPts!=0, keypoints are not detected, but descriptors are computed at the locations provided in keypoints (a CvSeq of CvSURFPoint).</param>
#else
        /// <summary>
        /// Extracts Speeded Up Robust Features from image
        /// </summary>
        /// <param name="mask">The optional input 8-bit mask. The features are only found in the areas that contain more than 50% of non-zero mask pixels. </param>
        /// <param name="keypoints">The output parameter; double pointer to the sequence of keypoints. This will be the sequence of CvSURFPoint structures.</param>
        /// <param name="descriptors">The optional output parameter; double pointer to the sequence of descriptors; Depending on the params.extended value, each element of the sequence will be either 64-element or 128-element floating-point (CV_32F) vector. If the parameter is null, the descriptors are not computed. </param>
        /// <param name="storage">Memory storage where keypoints and descriptors will be stored. </param>
        /// <param name="param">Various algorithm parameters put to the structure CvSURFParams</param>
        /// <param name="useProvidedKeyPts">If useProvidedKeyPts!=0, keypoints are not detected, but descriptors are computed at the locations provided in keypoints (a CvSeq of CvSURFPoint).</param>
#endif
        public void ExtractSURF(CvArr mask, ref CvSeq<CvSURFPoint> keypoints, out CvSeq<IntPtr> descriptors, CvMemStorage storage, CvSURFParams param, bool useProvidedKeyPts)
        {
            Cv.ExtractSURF(this, mask, ref keypoints, out descriptors, storage, param, useProvidedKeyPts);
        }

#if LANG_JP
        /// <summary>
        /// 画像中からSURF（Speeded Up Robust Features）を検出する
        /// </summary>
        /// <param name="mask">オプション：8ビットのマスク画像．非0 のマスクピクセルが50%以上を占める領域からのみ，特徴点検出を行う．</param>
        /// <param name="keypoints">出力パラメータ．キーポイントのシーケンスへのポインタのポインタ． これは，CvSURFPoint 構造体のシーケンスになる</param>
        /// <param name="descriptors">オプション：出力パラメータ．ディスクリプタのシーケンスへのポインタのポインタ． シーケンスの各要素は，params.extended の値に依存して， 64-要素，あるいは 128-要素の浮動小数点数（CV_32F）ベクトルとなる． パラメータが NULL の場合，ディスクリプタは計算されない．</param>
        /// <param name="param">CvSURFParams 構造体に入れられた，様々なアルゴリズムパラメータ</param>
#else
        /// <summary>
        /// Extracts Speeded Up Robust Features from image
        /// </summary>
        /// <param name="mask">The optional input 8-bit mask. The features are only found in the areas that contain more than 50% of non-zero mask pixels. </param>
        /// <param name="keypoints">The output parameter; double pointer to the sequence of keypoints. This will be the sequence of CvSURFPoint structures.</param>
        /// <param name="descriptors">The optional output parameter; double pointer to the sequence of descriptors; Depending on the params.extended value, each element of the sequence will be either 64-element or 128-element floating-point (CV_32F) vector. If the parameter is null, the descriptors are not computed. </param>
        /// <param name="param">Various algorithm parameters put to the structure CvSURFParams</param>
#endif
        public void ExtractSURF(CvArr mask, out CvSURFPoint[] keypoints, out float[][] descriptors, CvSURFParams param)
        {
            Cv.ExtractSURF(this, mask, out keypoints, out descriptors, param);
        }

#if LANG_JP
        /// <summary>
        /// 画像中からSURF（Speeded Up Robust Features）を検出する
        /// </summary>
        /// <param name="mask">オプション：8ビットのマスク画像．非0 のマスクピクセルが50%以上を占める領域からのみ，特徴点検出を行う．</param>
        /// <param name="keypoints">出力パラメータ．キーポイントのシーケンスへのポインタのポインタ． これは，CvSURFPoint 構造体のシーケンスになる</param>
        /// <param name="descriptors">オプション：出力パラメータ．ディスクリプタのシーケンスへのポインタのポインタ． シーケンスの各要素は，params.extended の値に依存して， 64-要素，あるいは 128-要素の浮動小数点数（CV_32F）ベクトルとなる． パラメータが NULL の場合，ディスクリプタは計算されない．</param>
        /// <param name="param">CvSURFParams 構造体に入れられた，様々なアルゴリズムパラメータ</param>
        /// <param name="useProvidedKeyPts">If useProvidedKeyPts!=0, keypoints are not detected, but descriptors are computed at the locations provided in keypoints (a CvSeq of CvSURFPoint).</param>
#else
        /// <summary>
        /// Extracts Speeded Up Robust Features from image
        /// </summary>
        /// <param name="mask">The optional input 8-bit mask. The features are only found in the areas that contain more than 50% of non-zero mask pixels. </param>
        /// <param name="keypoints">The output parameter; double pointer to the sequence of keypoints. This will be the sequence of CvSURFPoint structures.</param>
        /// <param name="descriptors">The optional output parameter; double pointer to the sequence of descriptors; Depending on the params.extended value, each element of the sequence will be either 64-element or 128-element floating-point (CV_32F) vector. If the parameter is null, the descriptors are not computed. </param>
        /// <param name="param">Various algorithm parameters put to the structure CvSURFParams</param>
        /// <param name="useProvidedKeyPts">If useProvidedKeyPts!=0, keypoints are not detected, but descriptors are computed at the locations provided in keypoints (a CvSeq of CvSURFPoint).</param>
#endif
        public void ExtractSURF(CvArr mask, ref CvSURFPoint[] keypoints, out float[][] descriptors, CvSURFParams param, bool useProvidedKeyPts)
        {
            Cv.ExtractSURF(this, mask, ref keypoints, out descriptors, param, useProvidedKeyPts);
        }
        #endregion
        #region FillConvexPoly
#if LANG_JP
        /// <summary>
        /// 凸ポリゴンの内部を塗りつぶす．
        /// </summary>
        /// <param name="pts">一つのポリゴンへのポインタの配列</param>
        /// <param name="color">ポリゴンの色</param>
#else
        /// <summary>
        /// Fills convex polygon
        /// </summary>
        /// <param name="pts">Array of pointers to a single polygon. </param>
        /// <param name="color">Polygon color. </param>
#endif
        public void FillConvexPoly(CvPoint[] pts, CvScalar color)
        {
            Cv.FillConvexPoly(this, pts, color);
        }
#if LANG_JP
        /// <summary>
        /// 凸ポリゴンの内部を塗りつぶす．
        /// </summary>
        /// <param name="pts">一つのポリゴンへのポインタの配列</param>
        /// <param name="color">ポリゴンの色</param>
        /// <param name="lineType">線の種類</param>
#else
        /// <summary>
        /// Fills convex polygon
        /// </summary>
        /// <param name="pts">Array of pointers to a single polygon. </param>
        /// <param name="color">Polygon color. </param>
        /// <param name="lineType">Type of the polygon boundaries.</param>
#endif
        public void FillConvexPoly(CvPoint[] pts, CvScalar color, LineType lineType)
        {
            Cv.FillConvexPoly(this, pts, color, lineType);
        }
#if LANG_JP
        /// <summary>
        /// 凸ポリゴンの内部を塗りつぶす．
        /// </summary>
        /// <param name="pts">一つのポリゴンへのポインタの配列</param>
        /// <param name="color">ポリゴンの色</param>
        /// <param name="lineType">線の種類</param>
        /// <param name="shift">頂点座標の小数点以下の桁を表すビット数</param>
#else
        /// <summary>
        /// Fills convex polygon
        /// </summary>
        /// <param name="pts">Array of pointers to a single polygon. </param>
        /// <param name="color">Polygon color. </param>
        /// <param name="lineType">Type of the polygon boundaries.</param>
        /// <param name="shift">Number of fractional bits in the vertex coordinates. </param>
#endif
        public void FillConvexPoly(CvPoint[] pts, CvScalar color, LineType lineType, int shift)
        {
            Cv.FillConvexPoly(this, pts, color, lineType, shift);
        }
        #endregion
        #region FillPoly
#if LANG_JP
        /// <summary>
        /// ポリゴン内部を塗りつぶす
        /// </summary>
        /// <param name="pts">ポリゴンへのポインタ配列．</param>
        /// <param name="color">ポリゴンの色．</param>
#else
        /// <summary>
        /// Fills polygons interior
        /// </summary>
        /// <param name="pts">Array of pointers to polygons. </param>
        /// <param name="color">Polygon color. </param>
#endif
        public void FillPoly(CvPoint[][] pts, CvScalar color)
        {
            Cv.FillPoly(this, pts, color);
        }
#if LANG_JP
        /// <summary>
        /// ポリゴン内部を塗りつぶす
        /// </summary>
        /// <param name="pts">ポリゴンへのポインタ配列．</param>
        /// <param name="color">ポリゴンの色．</param>
        /// <param name="lineType">線の種類．</param>
#else
        /// <summary>
        /// Fills polygons interior
        /// </summary>
        /// <param name="pts">Array of pointers to polygons. </param>
        /// <param name="color">Polygon color. </param>
        /// <param name="lineType">ype of the polygon boundaries.</param>
#endif
        public void FillPoly(CvPoint[][] pts, CvScalar color, LineType lineType)
        {
            Cv.FillPoly(this, pts, color, lineType);
        }
#if LANG_JP
        /// <summary>
        /// ポリゴン内部を塗りつぶす
        /// </summary>
        /// <param name="pts">ポリゴンへのポインタ配列．</param>
        /// <param name="color">ポリゴンの色．</param>
        /// <param name="lineType">線の種類．</param>
        /// <param name="shift">頂点座標の小数点以下の桁を表すビット数．</param>
#else
        /// <summary>
        /// Fills polygons interior
        /// </summary>
        /// <param name="pts">Array of pointers to polygons. </param>
        /// <param name="color">Polygon color. </param>
        /// <param name="lineType">ype of the polygon boundaries.</param>
        /// <param name="shift">Number of fractional bits in the vertex coordinates. </param>
#endif
        public void FillPoly(CvPoint[][] pts, CvScalar color, LineType lineType, int shift)
        {
            Cv.FillPoly(this, pts, color, lineType, shift);
        }
        #endregion
        #region Filter2D
#if LANG_JP
        /// <summary>
        /// 画像に線形フィルタを適用する
        /// </summary>
        /// <param name="dst">出力画像</param>
        /// <param name="kernel">フィルタマスク．係数のシングルチャンネルの2次元浮動小数点型行列．</param>
#else
        /// <summary>
        /// Applies arbitrary linear filter to the image. In-place operation is supported. 
        /// When the aperture is partially outside the image, the function interpolates outlier pixel values from the nearest pixels that is inside the image. 
        /// </summary>
        /// <param name="dst">The destination image. </param>
        /// <param name="kernel">Convolution kernel, single-channel floating point matrix. If you want to apply different kernels to different channels, split the image using cvSplit into separate color planes and process them individually. </param>
#endif
        public void Filter2D(CvArr dst, CvMat kernel)
        {
            Cv.Filter2D(this, dst, kernel);
        }
#if LANG_JP
        /// <summary>
        /// 画像に線形フィルタを適用する
        /// </summary>
        /// <param name="dst">出力画像</param>
        /// <param name="kernel">フィルタマスク．係数のシングルチャンネルの2次元浮動小数点型行列．</param>
        /// <param name="anchor">カーネルのアンカー．カーネルマスクでカバーされる隣接領域内における， フィルタ対象となるピクセルの相対位置を表す．</param>
#else
        /// <summary>
        /// Applies arbitrary linear filter to the image. In-place operation is supported. 
        /// When the aperture is partially outside the image, the function interpolates outlier pixel values from the nearest pixels that is inside the image. 
        /// </summary>
        /// <param name="dst">The destination image. </param>
        /// <param name="kernel">Convolution kernel, single-channel floating point matrix. If you want to apply different kernels to different channels, split the image using cvSplit into separate color planes and process them individually. </param>
        /// <param name="anchor">The anchor of the kernel that indicates the relative position of a filtered point within the kernel. The anchor shoud lie within the kernel. The special default value (-1,-1) means that it is at the kernel center. </param>
#endif
        public void Filter2D(CvArr dst, CvMat kernel, CvPoint anchor)
        {
            Cv.Filter2D(this, dst, kernel, anchor);
        }
        #endregion
        #region FindChessboardCorners
#if LANG_JP
        /// <summary>
        /// 入力画像がチェスボードパターンであるかどうかを確認し，チェスボードの各コーナーの位置検出を試みる．
        /// </summary>
        /// <param name="patternSize">チェスボードの行と列ごとのコーナーの数</param>
        /// <param name="corners">検出されたコーナーの配列. Length=pattern_size.Width*pattern_size.Height</param>
        /// <returns>すべてのコーナーが検出され，正しい順番（行順で，かつ各行は左から右に並ぶ）でそれらが配置されている場合には, true</returns>
#else
        /// <summary>
        /// Finds positions of internal corners of the chessboard
        /// </summary>
        /// <param name="patternSize">The number of inner corners per chessboard row and column. </param>
        /// <param name="corners">The output array of corners detected. </param>
        /// <returns>returns true if all the corners have been found and they have been placed in a certain order (row by row, left to right in every row), otherwise, if the function fails to find all the corners or reorder them, it returns false. </returns>
#endif
        public bool FindChessboardCorners(CvSize patternSize, out CvPoint2D32f[] corners)
        {
            return Cv.FindChessboardCorners(this, patternSize, out corners);
        }
#if LANG_JP
        /// <summary>
        /// 入力画像がチェスボードパターンであるかどうかを確認し，チェスボードの各コーナーの位置検出を試みる．
        /// </summary>
        /// <param name="patternSize">チェスボードの行と列ごとのコーナーの数</param>
        /// <param name="corners">検出されたコーナーの配列. Length=pattern_size.Width*pattern_size.Height</param>
        /// <param name="cornerCount">コーナーの数が出力される</param>
        /// <returns>すべてのコーナーが検出され，正しい順番（行順で，かつ各行は左から右に並ぶ）でそれらが配置されている場合には, true</returns>
#else
        /// <summary>
        /// Finds positions of internal corners of the chessboard
        /// </summary>
        /// <param name="patternSize">The number of inner corners per chessboard row and column. </param>
        /// <param name="corners">The output array of corners detected. </param>
        /// <param name="cornerCount">The output corner counter. If it is not null, the function stores there the number of corners found. </param>
        /// <returns>returns true if all the corners have been found and they have been placed in a certain order (row by row, left to right in every row), otherwise, if the function fails to find all the corners or reorder them, it returns false. </returns>
#endif
        public bool FindChessboardCorners(CvSize patternSize, out CvPoint2D32f[] corners, out int cornerCount)
        {
            return Cv.FindChessboardCorners(this, patternSize, out corners, out cornerCount);
        }
#if LANG_JP
        /// <summary>
        /// 入力画像がチェスボードパターンであるかどうかを確認し，チェスボードの各コーナーの位置検出を試みる．
        /// </summary>
        /// <param name="patternSize">チェスボードの行と列ごとのコーナーの数</param>
        /// <param name="corners">検出されたコーナーの配列. Length=pattern_size.Width*pattern_size.Height</param>
        /// <param name="cornerCount">コーナーの数が出力される</param>
        /// <param name="flags">処理フラグ</param>
        /// <returns>すべてのコーナーが検出され，正しい順番（行順で，かつ各行は左から右に並ぶ）でそれらが配置されている場合には, true</returns>
#else
        /// <summary>
        /// Finds positions of internal corners of the chessboard
        /// </summary>
        /// <param name="patternSize">The number of inner corners per chessboard row and column. </param>
        /// <param name="corners">The output array of corners detected. </param>
        /// <param name="cornerCount">The output corner counter. If it is not null, the function stores there the number of corners found. </param>
        /// <param name="flags">Various operation flags</param>
        /// <returns>returns true if all the corners have been found and they have been placed in a certain order (row by row, left to right in every row), otherwise, if the function fails to find all the corners or reorder them, it returns false. </returns>
#endif
        public bool FindChessboardCorners(CvSize patternSize, out CvPoint2D32f[] corners, out int cornerCount, ChessboardFlag flags)
        {
            return Cv.FindChessboardCorners(this, patternSize, out corners, out cornerCount, flags);
        }
        #endregion
        #region FindContours
#if LANG_JP
        /// <summary>
        /// 2値画像中の輪郭を見つける
        /// </summary>
        /// <param name="storage">抽出された輪郭を保存する領域</param>
        /// <param name="firstContour">出力パラメータ．一番外側の輪郭へのポインタが入っている．</param>
        /// <returns>抽出した輪郭の個数</returns>
#else
        /// <summary>
        /// Retrieves contours from the binary image and returns the number of retrieved contours.
        /// </summary>
        /// <param name="storage">Container of the retrieved contours. </param>
        /// <param name="firstContour">Output parameter, will contain the pointer to the first outer contour. </param>
        /// <returns>The number of retrieved contours.</returns>
#endif
        public int FindContours(CvMemStorage storage, out CvSeq<CvPoint> firstContour)
        {
            return Cv.FindContours(this, storage, out firstContour);
        }
#if LANG_JP
        /// <summary>
        /// 2値画像中の輪郭を見つける
        /// </summary>
        /// <param name="storage">抽出された輪郭を保存する領域</param>
        /// <param name="firstContour">出力パラメータ．一番外側の輪郭へのポインタが入っている．</param>
        /// <param name="headerSize">シーケンスヘッダのサイズ．method=CV_CHAIN_CODEの場合，>=sizeof(CvChain) ，それ以外の場合 >=sizeof(CvContour)．</param>
        /// <returns>抽出した輪郭の個数</returns>
#else
        /// <summary>
        /// Retrieves contours from the binary image and returns the number of retrieved contours.
        /// </summary>
        /// <param name="storage">Container of the retrieved contours. </param>
        /// <param name="firstContour">Output parameter, will contain the pointer to the first outer contour. </param>
        /// <param name="headerSize">Size of the sequence header, >=sizeof(CvChain) if method=CV_CHAIN_CODE, and >=sizeof(CvContour) otherwise. </param>
        /// <returns>The number of retrieved contours.</returns>
#endif
        public int FindContours(CvMemStorage storage, out CvSeq<CvPoint> firstContour, int headerSize)
        {
            return Cv.FindContours(this, storage, out firstContour, headerSize);
        }
#if LANG_JP
        /// <summary>
        /// 2値画像中の輪郭を見つける
        /// </summary>
        /// <param name="storage">抽出された輪郭を保存する領域</param>
        /// <param name="firstContour">出力パラメータ．一番外側の輪郭へのポインタが入っている．</param>
        /// <param name="headerSize">シーケンスヘッダのサイズ．method=CV_CHAIN_CODEの場合，>=sizeof(CvChain) ，それ以外の場合 >=sizeof(CvContour)．</param>
        /// <param name="mode">抽出モード </param>
        /// <returns>抽出した輪郭の個数</returns>
#else
        /// <summary>
        /// Retrieves contours from the binary image and returns the number of retrieved contours.
        /// </summary>
        /// <param name="storage">Container of the retrieved contours. </param>
        /// <param name="firstContour">Output parameter, will contain the pointer to the first outer contour. </param>
        /// <param name="headerSize">Size of the sequence header, >=sizeof(CvChain) if method=CV_CHAIN_CODE, and >=sizeof(CvContour) otherwise. </param>
        /// <param name="mode">Retrieval mode. </param>
        /// <returns>The number of retrieved contours.</returns>
#endif
        public int FindContours(CvMemStorage storage, out CvSeq<CvPoint> firstContour, int headerSize, ContourRetrieval mode)
        {
            return Cv.FindContours(this, storage, out firstContour, headerSize, mode);
        }
#if LANG_JP
        /// <summary>
        /// 2値画像中の輪郭を見つける
        /// </summary>
        /// <param name="storage">抽出された輪郭を保存する領域</param>
        /// <param name="firstContour">出力パラメータ．一番外側の輪郭へのポインタが入っている．</param>
        /// <param name="headerSize">シーケンスヘッダのサイズ．method=CV_CHAIN_CODEの場合，>=sizeof(CvChain) ，それ以外の場合 >=sizeof(CvContour)．</param>
        /// <param name="mode">抽出モード </param>
        /// <param name="method">近似手法</param>
        /// <returns>抽出した輪郭の個数</returns>
#else
        /// <summary>
        /// Retrieves contours from the binary image and returns the number of retrieved contours.
        /// </summary>
        /// <param name="storage">Container of the retrieved contours. </param>
        /// <param name="firstContour">Output parameter, will contain the pointer to the first outer contour. </param>
        /// <param name="headerSize">Size of the sequence header, >=sizeof(CvChain) if method=CV_CHAIN_CODE, and >=sizeof(CvContour) otherwise. </param>
        /// <param name="mode">Retrieval mode. </param>
        /// <param name="method">Approximation method. </param>
        /// <returns>The number of retrieved contours.</returns>
#endif
        public int FindContours(CvMemStorage storage, out CvSeq<CvPoint> firstContour, int headerSize, ContourRetrieval mode, ContourChain method)
        {
            return Cv.FindContours(this, storage, out firstContour, headerSize, mode, method);
        }
#if LANG_JP
        /// <summary>
        /// 2値画像中の輪郭を見つける
        /// </summary>
        /// <param name="storage">抽出された輪郭を保存する領域</param>
        /// <param name="firstContour">出力パラメータ．一番外側の輪郭へのポインタが入っている．</param>
        /// <param name="headerSize">シーケンスヘッダのサイズ．method=CV_CHAIN_CODEの場合，>=sizeof(CvChain) ，それ以外の場合 >=sizeof(CvContour)．</param>
        /// <param name="mode">抽出モード </param>
        /// <param name="method">近似手法</param>
        /// <param name="offset">オフセット．全ての輪郭点はこれによってシフトされる.</param>
        /// <returns>抽出した輪郭の個数</returns>
#else
        /// <summary>
        /// Retrieves contours from the binary image and returns the number of retrieved contours.
        /// </summary>
        /// <param name="storage">Container of the retrieved contours. </param>
        /// <param name="firstContour">Output parameter, will contain the pointer to the first outer contour. </param>
        /// <param name="headerSize">Size of the sequence header, >=sizeof(CvChain) if method=CV_CHAIN_CODE, and >=sizeof(CvContour) otherwise. </param>
        /// <param name="mode">Retrieval mode. </param>
        /// <param name="method">Approximation method. </param>
        /// <param name="offset">Offset, by which every contour point is shifted. This is useful if the contours are extracted from the image ROI and then they should be analyzed in the whole image context. </param>
        /// <returns>The number of retrieved contours.</returns>
#endif
        public int FindContours(CvMemStorage storage, out CvSeq<CvPoint> firstContour, int headerSize, ContourRetrieval mode, ContourChain method, CvPoint offset)
        {
            return Cv.FindContours(this, storage, out firstContour, headerSize, mode, method, offset);
        }
        #endregion
        #region FindCornerSubPix
#if LANG_JP
        /// <summary>
        /// コーナー位置を高精度化する.
        /// </summary>
        /// <param name="corners">コーナーの初期座標が入力され，高精度化された座標が出力される.</param>
        /// <param name="count">コーナーの数</param>
        /// <param name="win">検索ウィンドウの半分のサイズ．（例）win=(5,5) ならば 5*2+1 × 5*2+1 = 11 × 11 が探索ウィンドウして使われる.</param>
        /// <param name="zeroZone">総和を計算する際に含まれない，探索領域の中心に存在する総和対象外領域の半分のサイズ．この値は，自己相関行列において発生しうる特異点を避けるために用いられる． 値が (-1,-1) の場合は，そのようなサイズはないということを意味する</param>
        /// <param name="criteria">コーナー座標の高精度化のための繰り返し処理の終了条件．コーナー位置の高精度化の繰り返し処理は，規定回数に達するか，目標精度に達したときに終了する．</param>
#else
        /// <summary>
        /// Iterates to find the sub-pixel accurate location of corners, or radial saddle points.
        /// </summary>
        /// <param name="corners">Initial coordinates of the input corners and refined coordinates on output. </param>
        /// <param name="count">Number of corners. </param>
        /// <param name="win">Half sizes of the search window.</param>
        /// <param name="zeroZone">Half size of the dead region in the middle of the search zone over which the summation in formulae below is not done. It is used sometimes to avoid possible singularities of the autocorrelation matrix. The value of (-1,-1) indicates that there is no such size. </param>
        /// <param name="criteria">Criteria for termination of the iterative process of corner refinement. That is, the process of corner position refinement stops either after certain number of iteration or when a required accuracy is achieved. The criteria may specify either of or both the maximum number of iteration and the required accuracy. </param>
#endif
        public void FindCornerSubPix(CvPoint2D32f[] corners, int count, CvSize win, CvSize zeroZone, CvTermCriteria criteria)
        {
            Cv.FindCornerSubPix(this, corners, count, win, zeroZone, criteria);
        }
        #endregion
        #region FitEllipse2
#if LANG_JP
        /// <summary>
        /// 2次元の点列に楕円をフィッティングする
        /// </summary>
        /// <returns>2次元の点列にフィットする最良の楕円</returns>
#else
        /// <summary>
        /// Fits ellipse to set of 2D points
        /// </summary>
        /// <returns>ellipse that fits best (in least-squares sense) to a set of 2D points.</returns>
#endif
        public CvBox2D FitEllipse2()
        {
            return Cv.FitEllipse2(this);
        }
        #endregion
        #region FitLine
#if LANG_JP
        /// <summary>
        /// 2次元または3次元の点列に線をフィッティングする
        /// </summary>
        /// <param name="distType">フィッティングに使われる距離．</param>
        /// <param name="param">それぞれの距離関数における数値パラメータ（C）．0を指定した場合，最適な値が選択される．</param>
        /// <param name="reps">半径（座標原点と線の距離）と角度に対する精度．それぞれ0.01が初期値として適している．</param>
        /// <param name="aeps">半径（座標原点と線の距離）と角度に対する精度．それぞれ0.01が初期値として適している．</param>
        /// <param name="line">出力される線のパラメータ．2次元フィッティングの場合，四つの浮動小数点型数(vx, vy, x0, y0)の配列で，(vx, vy)は正規化された方向ベクトル，(x0, y0)は線上の点を意味する．3次元フィッティングの場合，(vx, vy, vz, x0, y0, z0)の六つの浮動小数点型数の配列で，(vx, vy, vz)は正規化された方向ベクトル，(x0, y0, z0)は線上の点を意味する．</param>
#else
        /// <summary>
        /// Fits line to 2D or 3D point set
        /// </summary>
        /// <param name="distType">The distance used for fitting (see the discussion). </param>
        /// <param name="param">Numerical parameter (C) for some types of distances, if 0 then some optimal value is chosen. </param>
        /// <param name="reps">Sufficient accuracy for radius (distance between the coordinate origin and the line) and angle, respectively, 0.01 would be a good defaults for both. </param>
        /// <param name="aeps">Sufficient accuracy for radius (distance between the coordinate origin and the line) and angle, respectively, 0.01 would be a good defaults for both. </param>
        /// <param name="line">The output line parameters. In case of 2d fitting it is array of 4 floats (vx, vy, x0, y0) where (vx, vy) is a normalized vector collinear to the line and (x0, y0) is some point on the line. In case of 3D fitting it is array of 6 floats (vx, vy, vz, x0, y0, z0) where (vx, vy, vz) is a normalized vector collinear to the line and (x0, y0, z0) is some point on the line. </param>
#endif
        public void FitLine(DistanceType distType, double param, double reps, double aeps, float[] line)
        {
            Cv.FitLine(this, distType, param, reps, aeps, line);
        }
        #endregion
        #region Flip
#if LANG_JP
        /// <summary>
        /// 2次元配列を垂直，水平，または両軸で反転する
        /// </summary>
#else
        /// <summary>
        /// Flip a 2D array around vertical, horizontal or both axises
        /// </summary>
#endif
        public void Flip()
        {
            Cv.Flip(this);
        }
#if LANG_JP
        /// <summary>
        /// 2次元配列を垂直，水平，または両軸で反転する
        /// </summary>
        /// <param name="dst">出力配列．もしnullであれば，反転はインプレースモードで行われる</param>
#else
        /// <summary>
        /// Flip a 2D array around vertical, horizontal or both axises
        /// </summary>
        /// <param name="dst">Destination array. If dst = null the flipping is done in-place. </param>
#endif
        public void Flip(CvArr dst)
        {
            Cv.Flip(this, dst);
        }
#if LANG_JP
        /// <summary>
        /// 2次元配列を垂直，水平，または両軸で反転する
        /// </summary>
        /// <param name="dst">出力配列．もしnullであれば，反転はインプレースモードで行われる</param>
        /// <param name="flipMode">配列の反転方法の指定</param>
#else
        /// <summary>
        /// Flip a 2D array around vertical, horizontal or both axises
        /// </summary>
        /// <param name="dst">Destination array. If dst = null the flipping is done in-place. </param>
        /// <param name="flipMode">Specifies how to flip the array.</param>
#endif
        public void Flip(CvArr dst, FlipMode flipMode)
        {
            Cv.Flip(this, dst, flipMode);
        }
#if LANG_JP
        /// <summary>
        /// 2次元配列を垂直，水平，または両軸で反転する. cvFlipのエイリアス.
        /// </summary>
#else
        /// <summary>
        /// Flip a 2D array around vertical, horizontal or both axises 
        /// </summary>
#endif
        public void Mirror()
        {
            Cv.Mirror(this);
        }
#if LANG_JP
        /// <summary>
        /// 2次元配列を垂直，水平，または両軸で反転する. cvFlipのエイリアス.
        /// </summary>
        /// <param name="dst">出力配列．もしnullであれば，反転はインプレースモードで行われる</param>
#else
        /// <summary>
        /// Flip a 2D array around vertical, horizontal or both axises 
        /// </summary>
        /// <param name="dst">Destination array. If dst = null the flipping is done in-place. </param>
#endif
        public void Mirror(CvArr dst)
        {
            Cv.Mirror(this, dst);
        }
#if LANG_JP
        /// <summary>
        /// 2次元配列を垂直，水平，または両軸で反転する. cvFlipのエイリアス.
        /// </summary>
        /// <param name="dst">出力配列．もしnullであれば，反転はインプレースモードで行われる</param>
        /// <param name="flipMode">配列の反転方法の指定</param>
#else
        /// <summary>
        /// Flip a 2D array around vertical, horizontal or both axises 
        /// </summary>
        /// <param name="dst">Destination array. If dst = null the flipping is done in-place. </param>
        /// <param name="flipMode">Specifies how to flip the array.</param>
#endif
        public void Mirror(CvArr dst, FlipMode flipMode)
        {
            Cv.Mirror(this, dst, flipMode);
        }
        #endregion
        #region FloodFill
#if LANG_JP
        /// <summary>
        /// 連結成分を指定した色で塗りつぶす
        /// </summary>
        /// <param name="seedPoint">連結成分の開始点．シードピクセル． </param>
        /// <param name="newVal">塗りつぶされる領域の新しいピクセル値（塗りつぶす値）．</param>
#else
        /// <summary>
        /// Fills a connected component with given color.
        /// </summary>
        /// <param name="seedPoint">The starting point. </param>
        /// <param name="newVal">New value of repainted domain pixels. </param>
#endif
        public void FloodFill(CvPoint seedPoint, CvScalar newVal)
        {
            Cv.FloodFill(this, seedPoint, newVal);
        }
#if LANG_JP
        /// <summary>
        /// 連結成分を指定した色で塗りつぶす
        /// </summary>
        /// <param name="seedPoint">連結成分の開始点．シードピクセル． </param>
        /// <param name="newVal">塗りつぶされる領域の新しいピクセル値（塗りつぶす値）．</param>
        /// <param name="loDiff">現在の観測対象ピクセルと，その連結成分に属する隣接ピクセル， またはそのピクセルを連結成分に追加するためのシードピクセルとの，輝度値/色の差（違い）の許容下限値． 8ビットカラー画像のときは，パックされた値． </param>
#else
        /// <summary>
        /// Fills a connected component with given color.
        /// </summary>
        /// <param name="seedPoint">The starting point. </param>
        /// <param name="newVal">New value of repainted domain pixels. </param>
        /// <param name="loDiff">Maximal lower brightness/color difference between the currently observed pixel and one of its neighbor belong to the component or seed pixel to add the pixel to component. In case of 8-bit color images it is packed value. </param>
#endif
        public void FloodFill(CvPoint seedPoint, CvScalar newVal, CvScalar loDiff)
        {
            Cv.FloodFill(this, seedPoint, newVal, loDiff);
        }
#if LANG_JP
        /// <summary>
        /// 連結成分を指定した色で塗りつぶす
        /// </summary>
        /// <param name="seedPoint">連結成分の開始点．シードピクセル． </param>
        /// <param name="newVal">塗りつぶされる領域の新しいピクセル値（塗りつぶす値）．</param>
        /// <param name="loDiff">現在の観測対象ピクセルと，その連結成分に属する隣接ピクセル， またはそのピクセルを連結成分に追加するためのシードピクセルとの，輝度値/色の差（違い）の許容下限値． 8ビットカラー画像のときは，パックされた値． </param>
        /// <param name="upDiff">現在の観測対象ピクセルと，その連結成分に属する隣接ピクセル， またはそのピクセルを連結成分に追加するためのシードピクセルとの，輝度値/色の差（違い）の許容上限値． 8ビットカラー画像のときは，パックされた値． </param>
#else
        /// <summary>
        /// Fills a connected component with given color.
        /// </summary>
        /// <param name="seedPoint">The starting point. </param>
        /// <param name="newVal">New value of repainted domain pixels. </param>
        /// <param name="loDiff">Maximal lower brightness/color difference between the currently observed pixel and one of its neighbor belong to the component or seed pixel to add the pixel to component. In case of 8-bit color images it is packed value. </param>
        /// <param name="upDiff">Maximal upper brightness/color difference between the currently observed pixel and one of its neighbor belong to the component or seed pixel to add the pixel to component. In case of 8-bit color images it is packed value. </param>
#endif
        public void FloodFill(CvPoint seedPoint, CvScalar newVal, CvScalar loDiff, CvScalar upDiff)
        {
            Cv.FloodFill(this, seedPoint, newVal, loDiff, upDiff);
        }
#if LANG_JP
        /// <summary>
        /// 連結成分を指定した色で塗りつぶす
        /// </summary>
        /// <param name="seedPoint">連結成分の開始点．シードピクセル． </param>
        /// <param name="newVal">塗りつぶされる領域の新しいピクセル値（塗りつぶす値）．</param>
        /// <param name="loDiff">現在の観測対象ピクセルと，その連結成分に属する隣接ピクセル， またはそのピクセルを連結成分に追加するためのシードピクセルとの，輝度値/色の差（違い）の許容下限値． 8ビットカラー画像のときは，パックされた値． </param>
        /// <param name="upDiff">現在の観測対象ピクセルと，その連結成分に属する隣接ピクセル， またはそのピクセルを連結成分に追加するためのシードピクセルとの，輝度値/色の差（違い）の許容上限値． 8ビットカラー画像のときは，パックされた値． </param>
        /// <param name="comp">構造体へのポインタ．この関数は，塗りつぶされた領域の情報を構造体に代入する． </param>
#else
        /// <summary>
        /// Fills a connected component with given color.
        /// </summary>
        /// <param name="seedPoint">The starting point. </param>
        /// <param name="newVal">New value of repainted domain pixels. </param>
        /// <param name="loDiff">Maximal lower brightness/color difference between the currently observed pixel and one of its neighbor belong to the component or seed pixel to add the pixel to component. In case of 8-bit color images it is packed value. </param>
        /// <param name="upDiff">Maximal upper brightness/color difference between the currently observed pixel and one of its neighbor belong to the component or seed pixel to add the pixel to component. In case of 8-bit color images it is packed value. </param>
        /// <param name="comp">Pointer to structure the function fills with the information about the repainted domain. </param>
#endif
        public void FloodFill(CvPoint seedPoint, CvScalar newVal, CvScalar loDiff, CvScalar upDiff, out CvConnectedComp comp)
        {
            Cv.FloodFill(this, seedPoint, newVal, loDiff, upDiff, out comp);
        }
#if LANG_JP
        /// <summary>
        /// 連結成分を指定した色で塗りつぶす
        /// </summary>
        /// <param name="seedPoint">連結成分の開始点．シードピクセル． </param>
        /// <param name="newVal">塗りつぶされる領域の新しいピクセル値（塗りつぶす値）．</param>
        /// <param name="loDiff">現在の観測対象ピクセルと，その連結成分に属する隣接ピクセル， またはそのピクセルを連結成分に追加するためのシードピクセルとの，輝度値/色の差（違い）の許容下限値． 8ビットカラー画像のときは，パックされた値． </param>
        /// <param name="upDiff">現在の観測対象ピクセルと，その連結成分に属する隣接ピクセル， またはそのピクセルを連結成分に追加するためのシードピクセルとの，輝度値/色の差（違い）の許容上限値． 8ビットカラー画像のときは，パックされた値． </param>
        /// <param name="comp">構造体へのポインタ．この関数は，塗りつぶされた領域の情報を構造体に代入する． </param>
        /// <param name="flags">操作フラグ．下位ビットは関数内で用いられる連結性に関する値4（デフォルト）または8が入っている． 
        /// 連結性は，どのピクセルを隣接ピクセルと見なすかを定義する．上位ビットは0，あるいはCv.FLOODFILL_FIXED_RANGE, Cv.FLOODFILL_MASK_ONLY との組み合わせである.</param>
#else
        /// <summary>
        /// Fills a connected component with given color.
        /// </summary>
        /// <param name="seedPoint">The starting point. </param>
        /// <param name="newVal">New value of repainted domain pixels. </param>
        /// <param name="loDiff">Maximal lower brightness/color difference between the currently observed pixel and one of its neighbor belong to the component or seed pixel to add the pixel to component. In case of 8-bit color images it is packed value. </param>
        /// <param name="upDiff">Maximal upper brightness/color difference between the currently observed pixel and one of its neighbor belong to the component or seed pixel to add the pixel to component. In case of 8-bit color images it is packed value. </param>
        /// <param name="comp">Pointer to structure the function fills with the information about the repainted domain. </param>
        /// <param name="flags">The operation flags. Lower bits contain connectivity value, 4 (by default) or 8, used within the function. Connectivity determines which neighbors of a pixel are considered. Upper bits can be 0 or combination of the flags</param>
#endif
        public void FloodFill(CvPoint seedPoint, CvScalar newVal, CvScalar loDiff, CvScalar upDiff, 
            out CvConnectedComp comp, FloodFillFlag flags)
        {
            Cv.FloodFill(this, seedPoint, newVal, loDiff, upDiff, out comp, flags);
        }
#if LANG_JP
        /// <summary>
        /// 連結成分を指定した色で塗りつぶす
        /// </summary>
        /// <param name="seedPoint">連結成分の開始点．シードピクセル． </param>
        /// <param name="newVal">塗りつぶされる領域の新しいピクセル値（塗りつぶす値）．</param>
        /// <param name="loDiff">現在の観測対象ピクセルと，その連結成分に属する隣接ピクセル， またはそのピクセルを連結成分に追加するためのシードピクセルとの，輝度値/色の差（違い）の許容下限値． 8ビットカラー画像のときは，パックされた値． </param>
        /// <param name="upDiff">現在の観測対象ピクセルと，その連結成分に属する隣接ピクセル， またはそのピクセルを連結成分に追加するためのシードピクセルとの，輝度値/色の差（違い）の許容上限値． 8ビットカラー画像のときは，パックされた値． </param>
        /// <param name="comp">構造体へのポインタ．この関数は，塗りつぶされた領域の情報を構造体に代入する． </param>
        /// <param name="flags">操作フラグ．下位ビットは関数内で用いられる連結性に関する値4（デフォルト）または8が入っている． 
        /// 連結性は，どのピクセルを隣接ピクセルと見なすかを定義する．上位ビットは0，あるいはCv.FLOODFILL_FIXED_RANGE, Cv.FLOODFILL_MASK_ONLY との組み合わせである.</param>
        /// <param name="mask">処理用マスク</param>
#else
        /// <summary>
        /// Fills a connected component with given color.
        /// </summary>
        /// <param name="seedPoint">The starting point. </param>
        /// <param name="newVal">New value of repainted domain pixels. </param>
        /// <param name="loDiff">Maximal lower brightness/color difference between the currently observed pixel and one of its neighbor belong to the component or seed pixel to add the pixel to component. In case of 8-bit color images it is packed value. </param>
        /// <param name="upDiff">Maximal upper brightness/color difference between the currently observed pixel and one of its neighbor belong to the component or seed pixel to add the pixel to component. In case of 8-bit color images it is packed value. </param>
        /// <param name="comp">Pointer to structure the function fills with the information about the repainted domain. </param>
        /// <param name="flags">The operation flags. Lower bits contain connectivity value, 4 (by default) or 8, used within the function. Connectivity determines which neighbors of a pixel are considered. Upper bits can be 0 or combination of the flags</param>
        /// <param name="mask">Operation mask</param>
#endif
        public void FloodFill(CvPoint seedPoint, CvScalar newVal, CvScalar loDiff, 
            CvScalar upDiff, out CvConnectedComp comp, FloodFillFlag flags, CvArr mask)
        {
            Cv.FloodFill(this, seedPoint, newVal, loDiff, upDiff, out comp, flags, mask);
        }
        #endregion
        #region Get*D
#if LANG_JP
        /// <summary>
        /// 特定の配列要素を返す．
        /// </summary>
        /// <param name="idx0">要素インデックスの，0を基準とした第1成分．</param>
        /// <returns>指定した要素の値. 疎な配列で，指定したノードが存在しない場合，0を返す（この関数によって新しいノードは生成されない）．</returns>
#else
        /// <summary>
        /// Return the particular array element
        /// </summary>
        /// <param name="idx0">The first zero-based component of the element index </param>
        /// <returns></returns>
#endif
        public CvScalar Get1D(int idx0)
        {
            return NativeMethods.cvGet1D(CvPtr, idx0);
        }
#if LANG_JP
        /// <summary>
        /// 特定の配列要素を返す．
        /// </summary>
        /// <param name="idx0">要素インデックスの，0を基準とした第1成分．</param>
        /// <param name="idx1">要素インデックスの，0を基準とした第2成分．</param>
        /// <returns>指定した要素の値. 疎な配列で，指定したノードが存在しない場合，0を返す（この関数によって新しいノードは生成されない）．</returns>
#else
        /// <summary>
        /// Return the particular array element
        /// </summary>
        /// <param name="idx0">The first zero-based component of the element index </param>
        /// <param name="idx1">The second zero-based component of the element index </param>
        /// <returns></returns>
#endif
        public CvScalar Get2D(int idx0, int idx1)
        {
            return NativeMethods.cvGet2D(CvPtr, idx0, idx1);
        }
#if LANG_JP
        /// <summary>
        /// 特定の配列要素を返す．
        /// </summary>
        /// <param name="idx0">要素インデックスの，0を基準とした第1成分．</param>
        /// <param name="idx1">要素インデックスの，0を基準とした第2成分．</param>
        /// <param name="idx2">要素インデックスの，0を基準とした第3成分．</param>
        /// <returns>指定した要素の値. 疎な配列で，指定したノードが存在しない場合，0を返す（この関数によって新しいノードは生成されない）．</returns>
#else
        /// <summary>
        /// Return the particular array element
        /// </summary>
        /// <param name="idx0">The first zero-based component of the element index </param>
        /// <param name="idx1">The second zero-based component of the element index </param>
        /// <param name="idx2">The third zero-based component of the element index </param>
        /// <returns></returns>
#endif
        public CvScalar Get3D(int idx0, int idx1, int idx2)
        {
            return NativeMethods.cvGet3D(CvPtr, idx0, idx1, idx2);
        }
#if LANG_JP
        /// <summary>
        /// 特定の配列要素を返す．
        /// </summary>
        /// <param name="idx">要素インデックスの配列(可変長引数)</param>
        /// <returns>指定した要素の値. </returns>
#else
        /// <summary>
        /// Return the particular array element
        /// </summary>
        /// <param name="idx">Array of the element indices </param>
        /// <returns>the particular array element</returns>
#endif
        public CvScalar GetND(params int[] idx)
        {
            return NativeMethods.cvGetND(CvPtr, idx);
        }
        #endregion
        #region GetCol
#if LANG_JP
        /// <summary>
        /// 指定された列を返す
        /// </summary>
        /// <param name="col">選択した列の，0を基準としたインデックス．</param>
        /// <returns>指定された範囲の列</returns>
#else
        /// <summary>
        /// Returns array column
        /// </summary>
        /// <param name="col">Zero-based index of the selected column. </param>
        /// <returns></returns>
#endif
        public CvMat GetCol(int col)
        {
            CvMat submat;
            return Cv.GetCol(this, out submat, col);
        }
#if LANG_JP
        /// <summary>
        /// 指定された範囲の列（複数列）を返す
        /// </summary>
        /// <param name="startCol">範囲の最初の（この値を含む）列の，0を基準としたインデックス．</param>
        /// <param name="endCol">範囲の最後の（この値を含まない）列の，0を基準としたインデックス．</param>
        /// <returns>指定された範囲の列</returns>
#else
        /// <summary>
        /// Returns array column span
        /// </summary>
        /// <param name="startCol">Zero-based index of the starting column (inclusive) of the span. </param>
        /// <param name="endCol">Zero-based index of the ending column (exclusive) of the span. </param>
        /// <returns></returns>
#endif
        public CvMat GetCols(int startCol, int endCol)
        {
            CvMat submat;
            return Cv.GetCols(this, out submat, startCol, endCol);
        }
        #endregion
        #region GetDiag
#if LANG_JP
        /// <summary>
        /// 入力配列中の指定された対角列に相当するヘッダを返す. 
        /// </summary>
        /// <param name="submat">結果として得られる部分配列のヘッダへの参照</param>
        /// <returns>結果として得られる部分配列のヘッダへの参照</returns>
#else
        /// <summary>
        /// Returns one of array diagonals
        /// </summary>
        /// <param name="submat">Reference to the resulting sub-array header. </param>
        /// <returns></returns>
#endif
        public CvMat GetDiag(out CvMat submat)
        {
            return Cv.GetDiag(this, out submat);
        }
#if LANG_JP
        /// <summary>
        /// 入力配列中の指定された対角列に相当するヘッダを返す. 
        /// </summary>
        /// <param name="submat">結果として得られる部分配列のヘッダへの参照</param>
        /// <param name="diag">対角配列の種類</param>
        /// <returns>結果として得られる部分配列のヘッダへの参照</returns>
#else
        /// <summary>
        /// Returns one of array diagonals
        /// </summary>
        /// <param name="submat">Reference to the resulting sub-array header. </param>
        /// <param name="diag">Array diagonal. Zero corresponds to the main diagonal, -1 corresponds to the diagonal above the main etc., 1 corresponds to the diagonal below the main etc. </param>
        /// <returns></returns>
#endif
        public CvMat GetDiag(out CvMat submat, DiagType diag)
        {
            return Cv.GetDiag(this, out submat, diag);
        }
        #endregion
        #region GetDims
#if LANG_JP
        /// <summary>
        /// 配列の次元とそれらのサイズを返す．
        /// IplImageまたは CvMatの場合には，画像や行列の行数に関係なく常に 2 を返す．
        /// </summary>
        /// <returns>配列の次元数</returns>
#else
        /// <summary>
        /// Return number of array dimensions and their sizes
        /// </summary>
        /// <returns>number of array dimensions.</returns>
#endif
        public int GetDims()
        {
            return Cv.GetDims(this);
        }
#if LANG_JP
        /// <summary>
        /// 配列の次元とそれらのサイズを返す．
        /// IplImageまたは CvMatの場合には，画像や行列の行数に関係なく常に 2 を返す．
        /// </summary>
        /// <param name="sizes">配列の次元の大きさを示すオプションの出力ベクトル．2次元配列の場合は1番目に行数（高さ），次は列数（幅）を示す．</param>
        /// <returns>配列の次元数</returns>
#else
        /// <summary>
        /// Return number of array dimensions and their sizes
        /// </summary>
        /// <param name="sizes">Optional output vector of the array dimension sizes. For 2d arrays the number of rows (height) goes first, number of columns (width) next. </param>
        /// <returns>number of array dimensions.</returns>
#endif
        public int GetDims(out int[] sizes)
        {
            return Cv.GetDims(this, out sizes);
        }
        #endregion
        #region GetDimSize
#if LANG_JP
        /// <summary>
        /// 配列の指定された次元の要素数を返す. 
        /// </summary>
        /// <param name="index">0を基準にした次元のインデックス（行列では0は行数，1は列数を示す．画像では0は高さ, 1は幅を示す）．</param>
        /// <returns>指定された次元の要素数</returns>
#else
        /// <summary>
        /// Return the size of particular dimension
        /// </summary>
        /// <param name="index">Zero-based dimension index (for matrices 0 means number of rows, 1 means number of columns; for images 0 means height, 1 means width). </param>
        /// <returns>the particular dimension size (number of elements per that dimension).</returns>
#endif
        public int GetDimSize(int index)
        {
            return Cv.GetDimSize(this, index);
        }
        #endregion
        #region GetElemType
#if LANG_JP
        /// <summary>
        /// 配列要素のタイプを返す. 
        /// </summary>
        /// <returns>配列要素のタイプ</returns>
#else
        /// <summary>
        /// Returns type of array elements
        /// </summary>
        /// <returns>type of the array elements</returns>
#endif
        public MatrixType GetElemType()
        {
            return Cv.GetElemType(this);
        }
        #endregion
        #region GetQuadrangleSubPix
#if LANG_JP
        /// <summary>
        /// 四角形領域のピクセル値を画像からサブピクセル精度で取得する（画像の回転＋並進移動を行なう）.
        /// </summary>
        /// <param name="dst">抽出された矩形</param>
        /// <param name="mapMatrix">2 × 3 の変換行列[A|b]</param>
#else
        /// <summary>
        /// Retrieves pixel quadrangle from image with sub-pixel accuracy.
        /// </summary>
        /// <param name="dst">Extracted quadrangle. </param>
        /// <param name="mapMatrix">The transformation 2 × 3 matrix [A|b]. </param>
#endif
        public void GetQuadrangleSubPix(CvArr dst, CvMat mapMatrix)
        {
            Cv.GetQuadrangleSubPix(this, dst, mapMatrix);
        }
        #endregion
        #region GetRawData
#if LANG_JP
        /// <summary>
        /// 配列の低レベル情報を取り出す
        /// </summary>
        /// <param name="data">出力である全画像の原点へのポインタ，あるいは ROI が設定されている場合は ROI の原点へのポインタ．</param>
#else
        /// <summary>
        /// Retrieves low-level information about the array
        /// </summary>
        /// <param name="data">Output pointer to the whole image origin or ROI origin if ROI is set. </param>
#endif
        public void GetRawData(out IntPtr data)
        {
            Cv.GetRawData(this, out data);
        }
#if LANG_JP
        /// <summary>
        /// 配列の低レベル情報を取り出す
        /// </summary>
        /// <param name="data">出力である全画像の原点へのポインタ，あるいは ROI が設定されている場合は ROI の原点へのポインタ．</param>
        /// <param name="step">出力であるバイト単位で表された行の長さ．</param>
#else
        /// <summary>
        /// Retrieves low-level information about the array
        /// </summary>
        /// <param name="data">Output pointer to the whole image origin or ROI origin if ROI is set. </param>
        /// <param name="step">Output full row length in bytes. </param>
#endif
        public void GetRawData(out IntPtr data, out int step)
        {
            Cv.GetRawData(this, out data, out step);
        }
#if LANG_JP
        /// <summary>
        /// 配列の低レベル情報を取り出す
        /// </summary>
        /// <param name="data">出力である全画像の原点へのポインタ，あるいは ROI が設定されている場合は ROI の原点へのポインタ．</param>
        /// <param name="step">出力であるバイト単位で表された行の長さ．</param>
        /// <param name="roiSize">出力であるROI サイズ．</param>
#else
        /// <summary>
        /// Retrieves low-level information about the array
        /// </summary>
        /// <param name="data">Output pointer to the whole image origin or ROI origin if ROI is set. </param>
        /// <param name="step">Output full row length in bytes. </param>
        /// <param name="roiSize">Output ROI size. </param>
#endif
        public void GetRawData(out IntPtr data, out int step, out CvSize roiSize)
        {
            Cv.GetRawData(this, out data, out step, out roiSize);
        }
        #endregion
        #region GetReal*D
#if LANG_JP
        /// <summary>
        /// シングルチャンネルの配列の特定の要素を返す．配列がマルチチャンネルの場合は，ランタイムエラーが発生する．
        /// </summary>
        /// <param name="idx0">要素インデックスの，0を基準とした第1成分．</param>
        /// <returns>指定した要素の値. 指定したノードが存在しなければ，この関数は0を返す（この関数によって新しいノードは生成されない）．</returns>
#else
        /// <summary>
        /// Return the particular element of single-channel array
        /// </summary>
        /// <param name="idx0">The first zero-based component of the element index </param>
        /// <returns>the particular element of single-channel array.</returns>
#endif
        public double GetReal1D(int idx0)
        {
            return NativeMethods.cvGetReal1D(CvPtr, idx0);
        }
#if LANG_JP
        /// <summary>
        /// シングルチャンネルの配列の特定の要素を返す．配列がマルチチャンネルの場合は，ランタイムエラーが発生する．
        /// </summary>
        /// <param name="idx0">要素インデックスの，0を基準とした第1成分．</param>
        /// <param name="idx1">要素インデックスの，0を基準とした第2成分．</param>
        /// <returns>指定した要素の値. 指定したノードが存在しなければ，この関数は0を返す（この関数によって新しいノードは生成されない）．</returns>
#else
        /// <summary>
        /// Return the particular element of single-channel array
        /// </summary>
        /// <param name="idx0">The first zero-based component of the element index </param>
        /// <param name="idx1">The second zero-based component of the element index </param>
        /// <returns>the particular element of single-channel array.</returns>
#endif
        public double GetReal2D(int idx0, int idx1)
        {
            return NativeMethods.cvGetReal2D(CvPtr, idx0, idx1);
        }
#if LANG_JP
        /// <summary>
        /// シングルチャンネルの配列の特定の要素を返す．配列がマルチチャンネルの場合は，ランタイムエラーが発生する．
        /// </summary>
        /// <param name="idx0">要素インデックスの，0を基準とした第1成分．</param>
        /// <param name="idx1">要素インデックスの，0を基準とした第2成分．</param>
        /// <param name="idx2">要素インデックスの，0を基準とした第3成分．</param>
        /// <returns>指定した要素の値. 指定したノードが存在しなければ，この関数は0を返す（この関数によって新しいノードは生成されない）．</returns>
#else
        /// <summary>
        /// Return the particular element of single-channel array
        /// </summary>
        /// <param name="idx0">The first zero-based component of the element index </param>
        /// <param name="idx1">The second zero-based component of the element index </param>
        /// <param name="idx2">The third zero-based component of the element index </param>
        /// <returns>the particular element of single-channel array.</returns>
#endif
        public double GetReal3D(int idx0, int idx1, int idx2)
        {
            return NativeMethods.cvGetReal3D(CvPtr, idx0, idx1, idx2);
        }
#if LANG_JP
        /// <summary>
        /// シングルチャンネルの配列の特定の要素を返す．配列がマルチチャンネルの場合は，ランタイムエラーが発生する．
        /// </summary>
        /// <param name="idx">要素インデックスの配列(可変長引数)</param>
        /// <returns>指定した要素の値. 指定したノードが存在しなければ，この関数は0を返す（この関数によって新しいノードは生成されない）．</returns>
#else
        /// <summary>
        /// Return the particular element of single-channel array
        /// </summary>
        /// <param name="idx">Array of the element indices </param>
        /// <returns>the particular element of single-channel array.</returns>
#endif
        public double GetRealND(params int[] idx)
        {
            return NativeMethods.cvGetRealND(CvPtr, idx);
        }
        #endregion
        #region GetRectSubPix
#if LANG_JP
        /// <summary>
        /// 矩形領域のピクセル値を画像からサブピクセル精度で取得する（画像の並進移動を行なう）.
        /// </summary>
        /// <param name="dst">抽出された矩形</param>
        /// <param name="center">入力画像中にある抽出された矩形中心の浮動小数点型座標．中心は画像中になければならない．</param>
#else
        /// <summary>
        /// Retrieves pixel rectangle from image with sub-pixel accuracy.
        /// </summary>
        /// <param name="dst">Extracted rectangle. </param>
        /// <param name="center">Floating point coordinates of the extracted rectangle center within the source image. The center must be inside the image. </param>
#endif
        public void GetRectSubPix(CvArr dst, CvPoint2D32f center)
        {
            Cv.GetRectSubPix(this, dst, center);
        }
        #endregion
        #region GetRow
#if LANG_JP
        /// <summary>
        /// 指定された行を返す
        /// </summary>
        /// <param name="row">選択した行の，0を基準としたインデックス．</param>
        /// <returns>指定された範囲の行</returns>
#else
        /// <summary>
        /// Returns array row
        /// </summary>
        /// <param name="row">Zero-based index of the selected row. </param>
        /// <returns></returns>
#endif
        public CvMat GetRow(int row)
        {
            CvMat submat;
            return Cv.GetRow(this, out submat, row);
        }
#if LANG_JP
        /// <summary>
        /// 指定された範囲の行（複数行）を返す
        /// </summary>
        /// <param name="startRow">範囲の最初の（この値を含む）行の，0を基準としたインデックス．</param>
        /// <param name="endRow">範囲の最後の（この値を含まない）行の，0を基準としたインデックス．</param>
        /// <returns>指定された範囲の行</returns>
#else
        /// <summary>
        /// Returns array row span
        /// </summary>
        /// <param name="startRow">Zero-based index of the starting row (inclusive) of the span. </param>
        /// <param name="endRow">Zero-based index of the ending row (exclusive) of the span. </param>
        /// <returns></returns>
#endif
        public CvMat GetRows(int startRow, int endRow)
        {
            CvMat submat;
            return Cv.GetRows(this, out submat, startRow, endRow);
        }
#if LANG_JP
        /// <summary>
        /// 指定された範囲の行（複数行）を返す
        /// </summary>
        /// <param name="startRow">範囲の最初の（この値を含む）行の，0を基準としたインデックス．</param>
        /// <param name="endRow">範囲の最後の（この値を含まない）行の，0を基準としたインデックス．</param>
        /// <param name="deltaRow">行の範囲のインデックス間隔． この関数は，start_rowからend_row（は含まない）まで，delta_row毎に行を抽出する. </param>
        /// <returns>指定された範囲の行</returns>
#else
        /// <summary>
        /// Returns array row span
        /// </summary>
        /// <param name="startRow">Zero-based index of the starting row (inclusive) of the span. </param>
        /// <param name="endRow">Zero-based index of the ending row (exclusive) of the span. </param>
        /// <param name="deltaRow">Index step in the row span. That is, the function extracts every delta_row-th row from start_row and up to (but not including) end_row. </param>
        /// <returns></returns>
#endif
        public CvMat GetRows(int startRow, int endRow, int deltaRow)
        {
            CvMat submat;
            return Cv.GetRows(this, out submat, startRow, endRow, deltaRow);
        }
        #endregion
        #region GetSize
#if LANG_JP
        /// <summary>
        /// 行列または画像の ROI のサイズを返す
        /// </summary>
        /// <returns>サイズ</returns>
#else
        /// <summary>
        /// Returns size of matrix or image ROI
        /// </summary>
        /// <returns></returns>
#endif
        public CvSize GetSize()
        {
            return Cv.GetSize(this);
        }
        #endregion
        #region GetStarKeypoints
#if LANG_JP
        /// <summary>
        /// StarDetectorアルゴリズムによりキーポイントを取得する
        /// </summary>
        /// <param name="storage">キーポイントが格納されるメモリストレージ</param>
        /// <returns></returns>
#else
        /// <summary>
        /// Retrieves keypoints using the StarDetector algorithm.
        /// </summary>
        /// <param name="storage">Memory storage where the keypoints will be stored</param>
        /// <returns></returns>
#endif
        public CvSeq GetStarKeypoints(CvMemStorage storage)
        {
            return Cv.GetStarKeypoints(this, storage, new CvStarDetectorParams());
        }
#if LANG_JP
        /// <summary>
        /// StarDetectorアルゴリズムによりキーポイントを取得する
        /// </summary>
        /// <param name="storage">キーポイントが格納されるメモリストレージ</param>
        /// <param name="params">CvStarDetectorParams構造体としてまとめて与えられる、アルゴリズムのための各種パラメータ</param>
        /// <returns></returns>
#else
        /// <summary>
        /// Retrieves keypoints using the StarDetector algorithm.
        /// </summary>
        /// <param name="storage">Memory storage where the keypoints will be stored</param>
        /// <param name="params">Various algorithm parameters given to the structure CvStarDetectorParams</param>
        /// <returns></returns>
#endif
        public CvSeq<CvStarKeypoint> GetStarKeypoints(CvMemStorage storage, CvStarDetectorParams @params)
        {
            return Cv.GetStarKeypoints(this, storage, @params);
        }
        #endregion
        #region GetSubRect
#if LANG_JP
        /// <summary>
        /// 入力配列中の指定した矩形領域に相当するヘッダを返す．
        /// つまり，入力配列の一部の矩形領域を，独立した配列として扱えるようにする．この関数では ROI を考慮し，実際には ROI の部分配列が取り出される.
        /// </summary>
        /// <param name="submat">結果として得られる部分配列のヘッダへの参照</param>
        /// <param name="rect">着目する矩形領域の，0 を基準とした座標</param>
        /// <returns>結果として得られる部分配列のヘッダへの参照</returns>
#else
        /// <summary>
        /// Returns matrix header corresponding to the rectangular sub-array of input image or matrix
        /// </summary>
        /// <param name="submat">Reference to the resultant sub-array header. </param>
        /// <param name="rect">Zero-based coordinates of the rectangle of interest. </param>
        /// <returns>Reference to the header, corresponding to a specified rectangle of the input array.</returns>
#endif
        public CvMat GetSubRect(out CvMat submat, CvRect rect)
        {
            return Cv.GetSubRect(this, out submat, rect);
        }
#if LANG_JP
        /// <summary>
        /// 入力配列中の指定した矩形領域に相当するヘッダを返す．
        /// つまり，入力配列の一部の矩形領域を，独立した配列として扱えるようにする．この関数では ROI を考慮し，実際には ROI の部分配列が取り出される.
        /// </summary>
        /// <param name="submat">結果として得られる部分配列のヘッダへの参照</param>
        /// <param name="rect">着目する矩形領域の，0 を基準とした座標</param>
        /// <returns>結果として得られる部分配列のヘッダへの参照</returns>
#else
        /// <summary>
        /// Returns matrix header corresponding to the rectangular sub-array of input image or matrix
        /// </summary>
        /// <param name="submat">Reference to the resultant sub-array header. </param>
        /// <param name="rect">Zero-based coordinates of the rectangle of interest. </param>
        /// <returns>Reference to the header, corresponding to a specified rectangle of the input array.</returns>
#endif
        public CvMat GetSubArr(out CvMat submat, CvRect rect)
        {
            return Cv.GetSubArr(this, out submat, rect);
        }
        #endregion
        #region HaarDetectObjects
#if LANG_JP
        /// <summary>
        /// 与えられた画像からオブジェクトを含む様な矩形領域を検出し，それらの領域を矩形の列として返す．
        /// </summary>
        /// <param name="cascade">Haar 分類器カスケード の内部表現</param>
        /// <param name="storage">オブジェクト候補の矩形が得られた場合に，その矩形列を保存するメモリストレージ</param>
        /// <returns>CvAvgCompを要素とするCvSeq</returns>
#else
        /// <summary>
        /// Finds rectangular regions in the given image that are likely to contain objects the cascade has been trained for and returns those regions as a sequence of rectangles.
        /// </summary>
        /// <param name="cascade">Haar classifier cascade in internal representation. </param>
        /// <param name="storage">Memory storage to store the resultant sequence of the object candidate rectangles. </param>
        /// <returns></returns>
#endif
        public CvSeq<CvAvgComp> HaarDetectObjects(CvHaarClassifierCascade cascade, CvMemStorage storage)
        {
            return Cv.HaarDetectObjects(this, cascade, storage);
        }
#if LANG_JP
        /// <summary>
        /// 与えられた画像からオブジェクトを含む様な矩形領域を検出し，それらの領域を矩形の列として返す．
        /// </summary>
        /// <param name="cascade">Haar 分類器カスケード の内部表現</param>
        /// <param name="storage">オブジェクト候補の矩形が得られた場合に，その矩形列を保存するメモリストレージ</param>
        /// <param name="scaleFactor">スキャン毎に探索ウィンドウがスケーリングされる際のスケールファクタ． 例えばこの値が 1.1 ならば，ウィンドウが 10% 大きくなる</param>
        /// <returns>CvAvgCompを要素とするCvSeq</returns>
#else
        /// <summary>
        /// Finds rectangular regions in the given image that are likely to contain objects the cascade has been trained for and returns those regions as a sequence of rectangles.
        /// </summary>
        /// <param name="cascade">Haar classifier cascade in internal representation. </param>
        /// <param name="storage">Memory storage to store the resultant sequence of the object candidate rectangles. </param>
        /// <param name="scaleFactor">The factor by which the search window is scaled between the subsequent scans, for example, 1.1 means increasing window by 10%. </param>
        /// <returns></returns>
#endif
        public CvSeq<CvAvgComp> HaarDetectObjects(CvHaarClassifierCascade cascade, CvMemStorage storage, double scaleFactor)
        {
            return Cv.HaarDetectObjects(this, cascade, storage, scaleFactor);
        }
#if LANG_JP
        /// <summary>
        /// 与えられた画像からオブジェクトを含む様な矩形領域を検出し，それらの領域を矩形の列として返す．
        /// </summary>
        /// <param name="cascade">Haar 分類器カスケード の内部表現</param>
        /// <param name="storage">オブジェクト候補の矩形が得られた場合に，その矩形列を保存するメモリストレージ</param>
        /// <param name="scaleFactor">スキャン毎に探索ウィンドウがスケーリングされる際のスケールファクタ． 例えばこの値が 1.1 ならば，ウィンドウが 10% 大きくなる</param>
        /// <param name="minNeighbors">（これから 1 を引いた値が）オブジェクトを構成する近傍矩形の最小数となる． min_neighbors-1 よりも少ない矩形しか含まないようなグループは全て棄却される． もし min_neighbors が 0 である場合，この関数はグループを一つも生成せず，候補となる矩形を全て返す．これはユーザがカスタマイズしたグループ化処理を適用したい場合に有用である． </param>
        /// <returns>CvAvgCompを要素とするCvSeq</returns>
#else
        /// <summary>
        /// Finds rectangular regions in the given image that are likely to contain objects the cascade has been trained for and returns those regions as a sequence of rectangles.
        /// </summary>
        /// <param name="cascade">Haar classifier cascade in internal representation. </param>
        /// <param name="storage">Memory storage to store the resultant sequence of the object candidate rectangles. </param>
        /// <param name="scaleFactor">The factor by which the search window is scaled between the subsequent scans, for example, 1.1 means increasing window by 10%. </param>
        /// <param name="minNeighbors">Minimum number (minus 1) of neighbor rectangles that makes up an object. All the groups of a smaller number of rectangles than min_neighbors-1 are rejected. If min_neighbors is 0, the function does not any grouping at all and returns all the detected candidate rectangles, which may be useful if the user wants to apply a customized grouping procedure. </param>
        /// <returns></returns>
#endif
        public CvSeq<CvAvgComp> HaarDetectObjects(CvHaarClassifierCascade cascade, CvMemStorage storage, double scaleFactor, int minNeighbors)
        {
            return Cv.HaarDetectObjects(this, cascade, storage, scaleFactor, minNeighbors);
        }
#if LANG_JP
        /// <summary>
        /// 与えられた画像からオブジェクトを含む様な矩形領域を検出し，それらの領域を矩形の列として返す．
        /// </summary>
        /// <param name="cascade">Haar 分類器カスケード の内部表現</param>
        /// <param name="storage">オブジェクト候補の矩形が得られた場合に，その矩形列を保存するメモリストレージ</param>
        /// <param name="scaleFactor">スキャン毎に探索ウィンドウがスケーリングされる際のスケールファクタ． 例えばこの値が 1.1 ならば，ウィンドウが 10% 大きくなる</param>
        /// <param name="minNeighbors">（これから 1 を引いた値が）オブジェクトを構成する近傍矩形の最小数となる． min_neighbors-1 よりも少ない矩形しか含まないようなグループは全て棄却される． もし min_neighbors が 0 である場合，この関数はグループを一つも生成せず，候補となる矩形を全て返す．これはユーザがカスタマイズしたグループ化処理を適用したい場合に有用である． </param>
        /// <param name="flags">処理モード</param>
        /// <returns>CvAvgCompを要素とするCvSeq</returns>
#else
        /// <summary>
        /// Finds rectangular regions in the given image that are likely to contain objects the cascade has been trained for and returns those regions as a sequence of rectangles.
        /// </summary>
        /// <param name="cascade">Haar classifier cascade in internal representation. </param>
        /// <param name="storage">Memory storage to store the resultant sequence of the object candidate rectangles. </param>
        /// <param name="scaleFactor">The factor by which the search window is scaled between the subsequent scans, for example, 1.1 means increasing window by 10%. </param>
        /// <param name="minNeighbors">Minimum number (minus 1) of neighbor rectangles that makes up an object. All the groups of a smaller number of rectangles than min_neighbors-1 are rejected. If min_neighbors is 0, the function does not any grouping at all and returns all the detected candidate rectangles, which may be useful if the user wants to apply a customized grouping procedure. </param>
        /// <param name="flags">Mode of operation. Currently the only flag that may be specified is CV_HAAR_DO_CANNY_PRUNING. If it is set, the function uses Canny edge detector to reject some image regions that contain too few or too much edges and thus can not contain the searched object. The particular threshold values are tuned for face detection and in this case the pruning speeds up the processing. </param>
        /// <returns></returns>
#endif
        public CvSeq<CvAvgComp> HaarDetectObjects(CvHaarClassifierCascade cascade, CvMemStorage storage, double scaleFactor, int minNeighbors, HaarDetectionType flags)
        {
            return Cv.HaarDetectObjects(this, cascade, storage, scaleFactor, minNeighbors, flags);
        }
#if LANG_JP
        /// <summary>
        /// 与えられた画像からオブジェクトを含む様な矩形領域を検出し，それらの領域を矩形の列として返す．
        /// </summary>
        /// <param name="cascade">Haar 分類器カスケード の内部表現</param>
        /// <param name="storage">オブジェクト候補の矩形が得られた場合に，その矩形列を保存するメモリストレージ</param>
        /// <param name="scaleFactor">スキャン毎に探索ウィンドウがスケーリングされる際のスケールファクタ． 例えばこの値が 1.1 ならば，ウィンドウが 10% 大きくなる</param>
        /// <param name="minNeighbors">（これから 1 を引いた値が）オブジェクトを構成する近傍矩形の最小数となる． min_neighbors-1 よりも少ない矩形しか含まないようなグループは全て棄却される． もし min_neighbors が 0 である場合，この関数はグループを一つも生成せず，候補となる矩形を全て返す．これはユーザがカスタマイズしたグループ化処理を適用したい場合に有用である． </param>
        /// <param name="flags">処理モード</param>
        /// <param name="minSize">最小ウィンドウサイズ．デフォルトでは分類器の学習に用いられたサンプルのサイズが設定される（顔検出の場合は，~20×20）.</param>
        /// <param name="maxSize">最大ウィンドウサイズ. </param>
        /// <returns>CvAvgCompを要素とするCvSeq</returns>
#else
        /// <summary>
        /// Finds rectangular regions in the given image that are likely to contain objects the cascade has been trained for and returns those regions as a sequence of rectangles.
        /// </summary>
        /// <param name="cascade">Haar classifier cascade in internal representation. </param>
        /// <param name="storage">Memory storage to store the resultant sequence of the object candidate rectangles. </param>
        /// <param name="scaleFactor">The factor by which the search window is scaled between the subsequent scans, for example, 1.1 means increasing window by 10%. </param>
        /// <param name="minNeighbors">Minimum number (minus 1) of neighbor rectangles that makes up an object. All the groups of a smaller number of rectangles than min_neighbors-1 are rejected. If min_neighbors is 0, the function does not any grouping at all and returns all the detected candidate rectangles, which may be useful if the user wants to apply a customized grouping procedure. </param>
        /// <param name="flags">Mode of operation. Currently the only flag that may be specified is CV_HAAR_DO_CANNY_PRUNING. If it is set, the function uses Canny edge detector to reject some image regions that contain too few or too much edges and thus can not contain the searched object. The particular threshold values are tuned for face detection and in this case the pruning speeds up the processing. </param>
        /// <param name="minSize">Minimum window size. By default, it is set to the size of samples the classifier has been trained on (~20×20 for face detection). </param>
        /// <param name="maxSize">Maximum window size.</param>
        /// <returns></returns>
#endif
        public CvSeq<CvAvgComp> HaarDetectObjects(CvHaarClassifierCascade cascade, CvMemStorage storage, double scaleFactor, int minNeighbors, HaarDetectionType flags, CvSize minSize, CvSize maxSize)
        {
            return Cv.HaarDetectObjects(this, cascade, storage, scaleFactor, minNeighbors, flags, minSize, maxSize);
        }
        #endregion
        #region HoughCircles
        #region circle_storage = CvMemStorage
#if LANG_JP
        /// <summary>
        /// ハフ変換を用いてグレースケール画像中の円を検出する
        /// </summary>
        /// <param name="circleStorage">検出された円を保存するメモリストレージ</param>
        /// <param name="method">現状では，CV_HOUGH_GRADIENT（基本的な2段階のハフ変換）のみ実装されている. </param>
        /// <param name="dp">円の中心を求める際に用いられる計算時の解像度．例えば，この値が 1 の場合は，計算は入力画像と同じ解像度で行われる．2 の場合は，計算は幅・高さともに1/2の解像度になる，等． </param>
        /// <param name="minDist">円検出における中心座標間の最小間隔．この値が非常に小さい場合は，正しく抽出されるべき円の近傍に複数の間違った円が検出されることになる．また，逆に非常に大きい場合は，円検出に失敗する． </param>
        /// <returns></returns>
#else
        /// <summary>
        /// Finds circles in grayscale image using Hough transform.
        /// </summary>
        /// <param name="circleStorage">The storage for the circles detected. It can be a memory storage or single row/single column matrix (CvMat*) of type CV_32FC3, to which the circles' parameters are written. </param>
        /// <param name="method">Currently, the only implemented method is CV_HOUGH_GRADIENT, which is basically 21HT</param>
        /// <param name="dp">Resolution of the accumulator used to detect centers of the circles. For example, if it is 1, the accumulator will have the same resolution as the input image, if it is 2 - accumulator will have twice smaller width and height, etc. </param>
        /// <param name="minDist">Minimum distance between centers of the detected circles. If the parameter is too small, multiple neighbor circles may be falsely detected in addition to a true one. If it is too large, some circles may be missed. </param>
        /// <returns></returns>
#endif
        public CvSeq<CvCircleSegment> HoughCircles(CvMemStorage circleStorage, HoughCirclesMethod method, double dp, double minDist)
        {
            return Cv.HoughCircles(this, circleStorage, method, dp, minDist);
        }
#if LANG_JP
        /// <summary>
        /// ハフ変換を用いてグレースケール画像中の円を検出する
        /// </summary>
        /// <param name="circleStorage">検出された円を保存するメモリストレージ</param>
        /// <param name="method">現状では，CV_HOUGH_GRADIENT（基本的な2段階のハフ変換）のみ実装されている. </param>
        /// <param name="dp">円の中心を求める際に用いられる計算時の解像度．例えば，この値が 1 の場合は，計算は入力画像と同じ解像度で行われる．2 の場合は，計算は幅・高さともに1/2の解像度になる，等． </param>
        /// <param name="minDist">円検出における中心座標間の最小間隔．この値が非常に小さい場合は，正しく抽出されるべき円の近傍に複数の間違った円が検出されることになる．また，逆に非常に大きい場合は，円検出に失敗する． </param>
        /// <param name="param1">手法に応じた1番目のパラメータ． CV_HOUGH_GRADIENT の場合は，Cannyのエッジ検出器で用いる二つの閾値の高い方の値 (低い方の値は，この値を1/2したものになる）．</param>
        /// <returns></returns>
#else
        /// <summary>
        /// Finds circles in grayscale image using Hough transform.
        /// </summary>
        /// <param name="circleStorage">The storage for the circles detected. It can be a memory storage or single row/single column matrix (CvMat*) of type CV_32FC3, to which the circles' parameters are written. </param>
        /// <param name="method">Currently, the only implemented method is CV_HOUGH_GRADIENT, which is basically 21HT</param>
        /// <param name="dp">Resolution of the accumulator used to detect centers of the circles. For example, if it is 1, the accumulator will have the same resolution as the input image, if it is 2 - accumulator will have twice smaller width and height, etc. </param>
        /// <param name="minDist">Minimum distance between centers of the detected circles. If the parameter is too small, multiple neighbor circles may be falsely detected in addition to a true one. If it is too large, some circles may be missed. </param>
        /// <param name="param1">The first method-specific parameter. In case of CV_HOUGH_GRADIENT it is the higher threshold of the two passed to Canny edge detector (the lower one will be twice smaller). </param>
        /// <returns></returns>
#endif
        public CvSeq<CvCircleSegment> HoughCircles(CvMemStorage circleStorage, HoughCirclesMethod method, double dp, double minDist, double param1)
        {
            return Cv.HoughCircles(this, circleStorage, method, dp, minDist, param1);
        }
#if LANG_JP
        /// <summary>
        /// ハフ変換を用いてグレースケール画像中の円を検出する
        /// </summary>
        /// <param name="circleStorage">検出された円を保存するメモリストレージ</param>
        /// <param name="method">現状では，CV_HOUGH_GRADIENT（基本的な2段階のハフ変換）のみ実装されている. </param>
        /// <param name="dp">円の中心を求める際に用いられる計算時の解像度．例えば，この値が 1 の場合は，計算は入力画像と同じ解像度で行われる．2 の場合は，計算は幅・高さともに1/2の解像度になる，等． </param>
        /// <param name="minDist">円検出における中心座標間の最小間隔．この値が非常に小さい場合は，正しく抽出されるべき円の近傍に複数の間違った円が検出されることになる．また，逆に非常に大きい場合は，円検出に失敗する． </param>
        /// <param name="param1">手法に応じた1番目のパラメータ． CV_HOUGH_GRADIENT の場合は，Cannyのエッジ検出器で用いる二つの閾値の高い方の値 (低い方の値は，この値を1/2したものになる）．</param>
        /// <param name="param2">手法に応じた2番目のパラメータ． CV_HOUGH_GRADIENT の場合は，中心検出計算時の閾値．小さすぎると誤検出が多くなる．これに対応する値が大きい円から順に検出される．</param>
        /// <returns></returns>
#else
        /// <summary>
        /// Finds circles in grayscale image using Hough transform.
        /// </summary>
        /// <param name="circleStorage">The storage for the circles detected. It can be a memory storage or single row/single column matrix (CvMat*) of type CV_32FC3, to which the circles' parameters are written. </param>
        /// <param name="method">Currently, the only implemented method is CV_HOUGH_GRADIENT, which is basically 21HT</param>
        /// <param name="dp">Resolution of the accumulator used to detect centers of the circles. For example, if it is 1, the accumulator will have the same resolution as the input image, if it is 2 - accumulator will have twice smaller width and height, etc. </param>
        /// <param name="minDist">Minimum distance between centers of the detected circles. If the parameter is too small, multiple neighbor circles may be falsely detected in addition to a true one. If it is too large, some circles may be missed. </param>
        /// <param name="param1">The first method-specific parameter. In case of CV_HOUGH_GRADIENT it is the higher threshold of the two passed to Canny edge detector (the lower one will be twice smaller). </param>
        /// <param name="param2">The second method-specific parameter. In case of CV_HOUGH_GRADIENT it is accumulator threshold at the center detection stage. The smaller it is, the more false circles may be detected. Circles, corresponding to the larger accumulator values, will be returned first. </param>
        /// <returns></returns>
#endif
        public CvSeq<CvCircleSegment> HoughCircles(CvMemStorage circleStorage, HoughCirclesMethod method, double dp, double minDist, double param1, double param2)
        {
            return Cv.HoughCircles(this, circleStorage, method, dp, minDist, param1, param2);
        }
#if LANG_JP
        /// <summary>
        /// ハフ変換を用いてグレースケール画像中の円を検出する
        /// </summary>
        /// <param name="circleStorage">検出された円を保存するメモリストレージ</param>
        /// <param name="method">現状では，CV_HOUGH_GRADIENT（基本的な2段階のハフ変換）のみ実装されている. </param>
        /// <param name="dp">円の中心を求める際に用いられる計算時の解像度．例えば，この値が 1 の場合は，計算は入力画像と同じ解像度で行われる．2 の場合は，計算は幅・高さともに1/2の解像度になる，等． </param>
        /// <param name="minDist">円検出における中心座標間の最小間隔．この値が非常に小さい場合は，正しく抽出されるべき円の近傍に複数の間違った円が検出されることになる．また，逆に非常に大きい場合は，円検出に失敗する． </param>
        /// <param name="param1">手法に応じた1番目のパラメータ． CV_HOUGH_GRADIENT の場合は，Cannyのエッジ検出器で用いる二つの閾値の高い方の値 (低い方の値は，この値を1/2したものになる）．</param>
        /// <param name="param2">手法に応じた2番目のパラメータ． CV_HOUGH_GRADIENT の場合は，中心検出計算時の閾値．小さすぎると誤検出が多くなる．これに対応する値が大きい円から順に検出される．</param>
        /// <param name="minRadius">検出すべき円の最小半径．</param>
        /// <returns></returns>
#else
        /// <summary>
        /// Finds circles in grayscale image using Hough transform.
        /// </summary>
        /// <param name="circleStorage">The storage for the circles detected. It can be a memory storage or single row/single column matrix (CvMat*) of type CV_32FC3, to which the circles' parameters are written. </param>
        /// <param name="method">Currently, the only implemented method is CV_HOUGH_GRADIENT, which is basically 21HT</param>
        /// <param name="dp">Resolution of the accumulator used to detect centers of the circles. For example, if it is 1, the accumulator will have the same resolution as the input image, if it is 2 - accumulator will have twice smaller width and height, etc. </param>
        /// <param name="minDist">Minimum distance between centers of the detected circles. If the parameter is too small, multiple neighbor circles may be falsely detected in addition to a true one. If it is too large, some circles may be missed. </param>
        /// <param name="param1">The first method-specific parameter. In case of CV_HOUGH_GRADIENT it is the higher threshold of the two passed to Canny edge detector (the lower one will be twice smaller). </param>
        /// <param name="param2">The second method-specific parameter. In case of CV_HOUGH_GRADIENT it is accumulator threshold at the center detection stage. The smaller it is, the more false circles may be detected. Circles, corresponding to the larger accumulator values, will be returned first. </param>
        /// <param name="minRadius">Minimal radius of the circles to search for. </param>
        /// <returns></returns>
#endif
        public CvSeq<CvCircleSegment> HoughCircles(CvMemStorage circleStorage, HoughCirclesMethod method, double dp, double minDist, double param1, double param2, int minRadius)
        {
            return Cv.HoughCircles(this, circleStorage, method, dp, minDist, param1, param2, minRadius);
        }
#if LANG_JP
        /// <summary>
        /// ハフ変換を用いてグレースケール画像中の円を検出する
        /// </summary>
        /// <param name="circleStorage">検出された円を保存するメモリストレージ</param>
        /// <param name="method">現状では，CV_HOUGH_GRADIENT（基本的な2段階のハフ変換）のみ実装されている. </param>
        /// <param name="dp">円の中心を求める際に用いられる計算時の解像度．例えば，この値が 1 の場合は，計算は入力画像と同じ解像度で行われる．2 の場合は，計算は幅・高さともに1/2の解像度になる，等． </param>
        /// <param name="minDist">円検出における中心座標間の最小間隔．この値が非常に小さい場合は，正しく抽出されるべき円の近傍に複数の間違った円が検出されることになる．また，逆に非常に大きい場合は，円検出に失敗する． </param>
        /// <param name="param1">手法に応じた1番目のパラメータ． CV_HOUGH_GRADIENT の場合は，Cannyのエッジ検出器で用いる二つの閾値の高い方の値 (低い方の値は，この値を1/2したものになる）．</param>
        /// <param name="param2">手法に応じた2番目のパラメータ． CV_HOUGH_GRADIENT の場合は，中心検出計算時の閾値．小さすぎると誤検出が多くなる．これに対応する値が大きい円から順に検出される．</param>
        /// <param name="minRadius">検出すべき円の最小半径．</param>
        /// <param name="maxRadius">検出すべき円の最大半径 デフォルトの最大半径は max(image_width, image_height) にセットされている．</param>
        /// <returns></returns>
#else
        /// <summary>
        /// Finds circles in grayscale image using Hough transform.
        /// </summary>
        /// <param name="circleStorage">The storage for the circles detected. It can be a memory storage or single row/single column matrix (CvMat*) of type CV_32FC3, to which the circles' parameters are written. </param>
        /// <param name="method">Currently, the only implemented method is CV_HOUGH_GRADIENT, which is basically 21HT</param>
        /// <param name="dp">Resolution of the accumulator used to detect centers of the circles. For example, if it is 1, the accumulator will have the same resolution as the input image, if it is 2 - accumulator will have twice smaller width and height, etc. </param>
        /// <param name="minDist">Minimum distance between centers of the detected circles. If the parameter is too small, multiple neighbor circles may be falsely detected in addition to a true one. If it is too large, some circles may be missed. </param>
        /// <param name="param1">The first method-specific parameter. In case of CV_HOUGH_GRADIENT it is the higher threshold of the two passed to Canny edge detector (the lower one will be twice smaller). </param>
        /// <param name="param2">The second method-specific parameter. In case of CV_HOUGH_GRADIENT it is accumulator threshold at the center detection stage. The smaller it is, the more false circles may be detected. Circles, corresponding to the larger accumulator values, will be returned first. </param>
        /// <param name="minRadius">Minimal radius of the circles to search for. </param>
        /// <param name="maxRadius">Maximal radius of the circles to search for. By default the maximal radius is set to max(image_width, image_height). </param>
        /// <returns></returns>
#endif
        public CvSeq<CvCircleSegment> HoughCircles(CvMemStorage circleStorage, HoughCirclesMethod method, double dp, double minDist, double param1, double param2, int minRadius, int maxRadius)
        {
            return Cv.HoughCircles(this, circleStorage, method, dp, minDist, param1, param2, minRadius, maxRadius);
        }
        #endregion
        #region circle_storage = CvMat
#if LANG_JP
        /// <summary>
        /// ハフ変換を用いてグレースケール画像中の円を検出する
        /// </summary>
        /// <param name="circleStorage">検出された円を保存するメモリストレージ</param>
        /// <param name="method">現状では，CV_HOUGH_GRADIENT（基本的な2段階のハフ変換）のみ実装されている. </param>
        /// <param name="dp">円の中心を求める際に用いられる計算時の解像度．例えば，この値が 1 の場合は，計算は入力画像と同じ解像度で行われる．2 の場合は，計算は幅・高さともに1/2の解像度になる，等． </param>
        /// <param name="minDist">円検出における中心座標間の最小間隔．この値が非常に小さい場合は，正しく抽出されるべき円の近傍に複数の間違った円が検出されることになる．また，逆に非常に大きい場合は，円検出に失敗する． </param>
        /// <returns></returns>
#else
        /// <summary>
        /// Finds circles in grayscale image using Hough transform.
        /// </summary>
        /// <param name="circleStorage">The storage for the circles detected. It can be a memory storage or single row/single column matrix (CvMat*) of type CV_32FC3, to which the circles' parameters are written. </param>
        /// <param name="method">Currently, the only implemented method is CV_HOUGH_GRADIENT, which is basically 21HT</param>
        /// <param name="dp">Resolution of the accumulator used to detect centers of the circles. For example, if it is 1, the accumulator will have the same resolution as the input image, if it is 2 - accumulator will have twice smaller width and height, etc. </param>
        /// <param name="minDist">Minimum distance between centers of the detected circles. If the parameter is too small, multiple neighbor circles may be falsely detected in addition to a true one. If it is too large, some circles may be missed. </param>
        /// <returns></returns>
#endif
        public CvSeq<CvCircleSegment> HoughCircles(CvMat circleStorage, HoughCirclesMethod method, double dp, double minDist)
        {
            return Cv.HoughCircles(this, circleStorage, method, dp, minDist);
        }
#if LANG_JP
        /// <summary>
        /// ハフ変換を用いてグレースケール画像中の円を検出する
        /// </summary>
        /// <param name="circleStorage">検出された円を保存するメモリストレージ</param>
        /// <param name="method">現状では，CV_HOUGH_GRADIENT（基本的な2段階のハフ変換）のみ実装されている. </param>
        /// <param name="dp">円の中心を求める際に用いられる計算時の解像度．例えば，この値が 1 の場合は，計算は入力画像と同じ解像度で行われる．2 の場合は，計算は幅・高さともに1/2の解像度になる，等． </param>
        /// <param name="minDist">円検出における中心座標間の最小間隔．この値が非常に小さい場合は，正しく抽出されるべき円の近傍に複数の間違った円が検出されることになる．また，逆に非常に大きい場合は，円検出に失敗する． </param>
        /// <param name="param1">手法に応じた1番目のパラメータ． CV_HOUGH_GRADIENT の場合は，Cannyのエッジ検出器で用いる二つの閾値の高い方の値 (低い方の値は，この値を1/2したものになる）．</param>
        /// <returns></returns>
#else
        /// <summary>
        /// Finds circles in grayscale image using Hough transform.
        /// </summary>
        /// <param name="circleStorage">The storage for the circles detected. It can be a memory storage or single row/single column matrix (CvMat*) of type CV_32FC3, to which the circles' parameters are written. </param>
        /// <param name="method">Currently, the only implemented method is CV_HOUGH_GRADIENT, which is basically 21HT</param>
        /// <param name="dp">Resolution of the accumulator used to detect centers of the circles. For example, if it is 1, the accumulator will have the same resolution as the input image, if it is 2 - accumulator will have twice smaller width and height, etc. </param>
        /// <param name="minDist">Minimum distance between centers of the detected circles. If the parameter is too small, multiple neighbor circles may be falsely detected in addition to a true one. If it is too large, some circles may be missed. </param>
        /// <param name="param1">The first method-specific parameter. In case of CV_HOUGH_GRADIENT it is the higher threshold of the two passed to Canny edge detector (the lower one will be twice smaller). </param>
        /// <returns></returns>
#endif
        public CvSeq<CvCircleSegment> HoughCircles(CvMat circleStorage, HoughCirclesMethod method, double dp, double minDist, double param1)
        {
            return Cv.HoughCircles(this, circleStorage, method, dp, minDist, param1);
        }
#if LANG_JP
        /// <summary>
        /// ハフ変換を用いてグレースケール画像中の円を検出する
        /// </summary>
        /// <param name="circleStorage">検出された円を保存するメモリストレージ</param>
        /// <param name="method">現状では，CV_HOUGH_GRADIENT（基本的な2段階のハフ変換）のみ実装されている. </param>
        /// <param name="dp">円の中心を求める際に用いられる計算時の解像度．例えば，この値が 1 の場合は，計算は入力画像と同じ解像度で行われる．2 の場合は，計算は幅・高さともに1/2の解像度になる，等． </param>
        /// <param name="minDist">円検出における中心座標間の最小間隔．この値が非常に小さい場合は，正しく抽出されるべき円の近傍に複数の間違った円が検出されることになる．また，逆に非常に大きい場合は，円検出に失敗する． </param>
        /// <param name="param1">手法に応じた1番目のパラメータ． CV_HOUGH_GRADIENT の場合は，Cannyのエッジ検出器で用いる二つの閾値の高い方の値 (低い方の値は，この値を1/2したものになる）．</param>
        /// <param name="param2">手法に応じた2番目のパラメータ． CV_HOUGH_GRADIENT の場合は，中心検出計算時の閾値．小さすぎると誤検出が多くなる．これに対応する値が大きい円から順に検出される．</param>
        /// <returns></returns>
#else
        /// <summary>
        /// Finds circles in grayscale image using Hough transform.
        /// </summary>
        /// <param name="circleStorage">The storage for the circles detected. It can be a memory storage or single row/single column matrix (CvMat*) of type CV_32FC3, to which the circles' parameters are written. </param>
        /// <param name="method">Currently, the only implemented method is CV_HOUGH_GRADIENT, which is basically 21HT</param>
        /// <param name="dp">Resolution of the accumulator used to detect centers of the circles. For example, if it is 1, the accumulator will have the same resolution as the input image, if it is 2 - accumulator will have twice smaller width and height, etc. </param>
        /// <param name="minDist">Minimum distance between centers of the detected circles. If the parameter is too small, multiple neighbor circles may be falsely detected in addition to a true one. If it is too large, some circles may be missed. </param>
        /// <param name="param1">The first method-specific parameter. In case of CV_HOUGH_GRADIENT it is the higher threshold of the two passed to Canny edge detector (the lower one will be twice smaller). </param>
        /// <param name="param2">The second method-specific parameter. In case of CV_HOUGH_GRADIENT it is accumulator threshold at the center detection stage. The smaller it is, the more false circles may be detected. Circles, corresponding to the larger accumulator values, will be returned first. </param>
        /// <returns></returns>
#endif
        public CvSeq<CvCircleSegment> HoughCircles(CvMat circleStorage, HoughCirclesMethod method, double dp, double minDist, double param1, double param2)
        {
            return Cv.HoughCircles(this, circleStorage, method, dp, minDist, param1, param2);
        }
#if LANG_JP
        /// <summary>
        /// ハフ変換を用いてグレースケール画像中の円を検出する
        /// </summary>
        /// <param name="circleStorage">検出された円を保存するメモリストレージ</param>
        /// <param name="method">現状では，CV_HOUGH_GRADIENT（基本的な2段階のハフ変換）のみ実装されている. </param>
        /// <param name="dp">円の中心を求める際に用いられる計算時の解像度．例えば，この値が 1 の場合は，計算は入力画像と同じ解像度で行われる．2 の場合は，計算は幅・高さともに1/2の解像度になる，等． </param>
        /// <param name="minDist">円検出における中心座標間の最小間隔．この値が非常に小さい場合は，正しく抽出されるべき円の近傍に複数の間違った円が検出されることになる．また，逆に非常に大きい場合は，円検出に失敗する． </param>
        /// <param name="param1">手法に応じた1番目のパラメータ． CV_HOUGH_GRADIENT の場合は，Cannyのエッジ検出器で用いる二つの閾値の高い方の値 (低い方の値は，この値を1/2したものになる）．</param>
        /// <param name="param2">手法に応じた2番目のパラメータ． CV_HOUGH_GRADIENT の場合は，中心検出計算時の閾値．小さすぎると誤検出が多くなる．これに対応する値が大きい円から順に検出される．</param>
        /// <param name="minRadius">検出すべき円の最小半径．</param>
        /// <returns></returns>
#else
        /// <summary>
        /// Finds circles in grayscale image using Hough transform.
        /// </summary>
        /// <param name="circleStorage">The storage for the circles detected. It can be a memory storage or single row/single column matrix (CvMat*) of type CV_32FC3, to which the circles' parameters are written. </param>
        /// <param name="method">Currently, the only implemented method is CV_HOUGH_GRADIENT, which is basically 21HT</param>
        /// <param name="dp">Resolution of the accumulator used to detect centers of the circles. For example, if it is 1, the accumulator will have the same resolution as the input image, if it is 2 - accumulator will have twice smaller width and height, etc. </param>
        /// <param name="minDist">Minimum distance between centers of the detected circles. If the parameter is too small, multiple neighbor circles may be falsely detected in addition to a true one. If it is too large, some circles may be missed. </param>
        /// <param name="param1">The first method-specific parameter. In case of CV_HOUGH_GRADIENT it is the higher threshold of the two passed to Canny edge detector (the lower one will be twice smaller). </param>
        /// <param name="param2">The second method-specific parameter. In case of CV_HOUGH_GRADIENT it is accumulator threshold at the center detection stage. The smaller it is, the more false circles may be detected. Circles, corresponding to the larger accumulator values, will be returned first. </param>
        /// <param name="minRadius">Minimal radius of the circles to search for. </param>
        /// <returns></returns>
#endif
        public CvSeq<CvCircleSegment> HoughCircles(CvMat circleStorage, HoughCirclesMethod method, double dp, double minDist, double param1, double param2, int minRadius)
        {
            return Cv.HoughCircles(this, circleStorage, method, dp, minDist, param1, param2, minRadius);
        }
#if LANG_JP
        /// <summary>
        /// ハフ変換を用いてグレースケール画像中の円を検出する
        /// </summary>
        /// <param name="circleStorage">検出された円を保存するメモリストレージ</param>
        /// <param name="method">現状では，CV_HOUGH_GRADIENT（基本的な2段階のハフ変換）のみ実装されている. </param>
        /// <param name="dp">円の中心を求める際に用いられる計算時の解像度．例えば，この値が 1 の場合は，計算は入力画像と同じ解像度で行われる．2 の場合は，計算は幅・高さともに1/2の解像度になる，等． </param>
        /// <param name="minDist">円検出における中心座標間の最小間隔．この値が非常に小さい場合は，正しく抽出されるべき円の近傍に複数の間違った円が検出されることになる．また，逆に非常に大きい場合は，円検出に失敗する． </param>
        /// <param name="param1">手法に応じた1番目のパラメータ． CV_HOUGH_GRADIENT の場合は，Cannyのエッジ検出器で用いる二つの閾値の高い方の値 (低い方の値は，この値を1/2したものになる）．</param>
        /// <param name="param2">手法に応じた2番目のパラメータ． CV_HOUGH_GRADIENT の場合は，中心検出計算時の閾値．小さすぎると誤検出が多くなる．これに対応する値が大きい円から順に検出される．</param>
        /// <param name="minRadius">検出すべき円の最小半径．</param>
        /// <param name="maxRadius">検出すべき円の最大半径 デフォルトの最大半径は max(image_width, image_height) にセットされている．</param>
        /// <returns></returns>
#else
        /// <summary>
        /// Finds circles in grayscale image using Hough transform.
        /// </summary>
        /// <param name="circleStorage">The storage for the circles detected. It can be a memory storage or single row/single column matrix (CvMat*) of type CV_32FC3, to which the circles' parameters are written. </param>
        /// <param name="method">Currently, the only implemented method is CV_HOUGH_GRADIENT, which is basically 21HT</param>
        /// <param name="dp">Resolution of the accumulator used to detect centers of the circles. For example, if it is 1, the accumulator will have the same resolution as the input image, if it is 2 - accumulator will have twice smaller width and height, etc. </param>
        /// <param name="minDist">Minimum distance between centers of the detected circles. If the parameter is too small, multiple neighbor circles may be falsely detected in addition to a true one. If it is too large, some circles may be missed. </param>
        /// <param name="param1">The first method-specific parameter. In case of CV_HOUGH_GRADIENT it is the higher threshold of the two passed to Canny edge detector (the lower one will be twice smaller). </param>
        /// <param name="param2">The second method-specific parameter. In case of CV_HOUGH_GRADIENT it is accumulator threshold at the center detection stage. The smaller it is, the more false circles may be detected. Circles, corresponding to the larger accumulator values, will be returned first. </param>
        /// <param name="minRadius">Minimal radius of the circles to search for. </param>
        /// <param name="maxRadius">Maximal radius of the circles to search for. By default the maximal radius is set to max(image_width, image_height). </param>
        /// <returns></returns>
#endif
        public CvSeq<CvCircleSegment> HoughCircles(CvMat circleStorage, HoughCirclesMethod method, double dp, double minDist, double param1, double param2, int minRadius, int maxRadius)
        {
            return Cv.HoughCircles(this, circleStorage, method, dp, minDist, param1, param2, minRadius);
        }
        #endregion
        #endregion
        #region HoughLines2
#if LANG_JP
        /// <summary>
        /// ハフ（Hough）変換を用いて2値画像から直線を検出する
        /// </summary>
        /// <param name="lineStorage">検出された線を保存するメモリストレージ. 関数によって線分のシーケンスがストレージ内につくられ，その参照が返される</param>
        /// <param name="method">ハフ変換の種類</param>
        /// <param name="rho">距離解像度（１ピクセル当たりの単位）</param>
        /// <param name="theta">角度解像度（ラジアン単位で計測）</param>
        /// <param name="threshold">閾値パラメータ．対応する投票数がthresholdより大きい場合のみ，抽出された線が返される．</param>
        /// <returns></returns>
#else
        /// <summary>
        /// Finds lines in binary image using Hough transform.
        /// </summary>
        /// <param name="lineStorage">The storage for the lines detected. It can be a memory storage or single row/single column matrix (CvMat*) of a particular type to which the lines' parameters are written. </param>
        /// <param name="method">The Hough transform variant.</param>
        /// <param name="rho">Distance resolution in pixel-related units. </param>
        /// <param name="theta">Angle resolution measured in radians. </param>
        /// <param name="threshold">Threshold parameter. A line is returned by the function if the corresponding accumulator value is greater than threshold. </param>
        /// <returns></returns>
#endif
        public CvSeq HoughLines2(CvMemStorage lineStorage, HoughLinesMethod method, double rho, double theta, int threshold)
        {
            return Cv.HoughLines2(this, lineStorage, method, rho, theta, threshold);
        }
#if LANG_JP
        /// <summary>
        /// ハフ（Hough）変換を用いて2値画像から直線を検出する
        /// </summary>
        /// <param name="lineStorage">検出された線を保存するメモリストレージ. 関数によって線分のシーケンスがストレージ内につくられ，その参照が返される</param>
        /// <param name="method">ハフ変換の種類</param>
        /// <param name="rho">距離解像度（１ピクセル当たりの単位）</param>
        /// <param name="theta">角度解像度（ラジアン単位で計測）</param>
        /// <param name="threshold">閾値パラメータ．対応する投票数がthresholdより大きい場合のみ，抽出された線が返される．</param>
        /// <param name="param1">各手法に応じた１番目のパラメータ．標準的ハフ変換では，使用しない（0）．確率的ハフ変換では，最小の線の長さ．マルチスケールハフ変換では， 距離解像度rhoの除数．（荒い距離解像度では rho であり，詳細な解像度では (rho / param1) となる）．</param>
        /// <param name="param2">各手法に応じた２番目のパラメータ．標準的ハフ変換では，使用しない（0）．確率的ハフ変換では，同一線上に存在する線分として扱う（つまり，それらを統合しても問題ない），二つの線分の最大の間隔． マルチスケールハフ変換では，角度解像度 thetaの除数． （荒い角度解像度では theta であり，詳細な解像度では (theta / param2) となる）． </param>
        /// <returns></returns>
#else
        /// <summary>
        /// Finds lines in binary image using Hough transform.
        /// </summary>
        /// <param name="lineStorage">The storage for the lines detected. It can be a memory storage or single row/single column matrix (CvMat*) of a particular type to which the lines' parameters are written. </param>
        /// <param name="method">The Hough transform variant.</param>
        /// <param name="rho">Distance resolution in pixel-related units. </param>
        /// <param name="theta">Angle resolution measured in radians. </param>
        /// <param name="threshold">Threshold parameter. A line is returned by the function if the corresponding accumulator value is greater than threshold. </param>
        /// <param name="param1">The first method-dependent parameter.</param>
        /// <param name="param2">The second method-dependent parameter.</param>
        /// <returns></returns>
#endif
        public CvSeq HoughLines2(CvMemStorage lineStorage, HoughLinesMethod method, double rho, double theta, int threshold, double param1, double param2)
        {
            return Cv.HoughLines2(this, lineStorage, method, rho, theta, threshold, param1, param2);
        }
#if LANG_JP
        /// <summary>
        /// ハフ（Hough）変換を用いて2値画像から直線を検出する
        /// </summary>
        /// <param name="lineStorage">検出された線を保存する1行の行列/1列の行列. 行列のヘッダは，そのcols か rowsが検出された線の数となるように，この関数によって変更される．もし実際の線の数が行列のサイズを超える場合は，線の最大可能数が返される（標準的ハフ変換の場合は 投票数でソートされる）．</param>
        /// <param name="method">ハフ変換の種類</param>
        /// <param name="rho">距離解像度（１ピクセル当たりの単位）</param>
        /// <param name="theta">角度解像度（ラジアン単位で計測）</param>
        /// <param name="threshold">閾値パラメータ．対応する投票数がthresholdより大きい場合のみ，抽出された線が返される．</param>
        /// <returns></returns>
#else
        /// <summary>
        /// Finds lines in binary image using Hough transform.
        /// </summary>
        /// <param name="lineStorage">The storage for the lines detected. It can be a memory storage or single row/single column matrix (CvMat*) of a particular type to which the lines' parameters are written. </param>
        /// <param name="method">The Hough transform variant.</param>
        /// <param name="rho">Distance resolution in pixel-related units. </param>
        /// <param name="theta">Angle resolution measured in radians. </param>
        /// <param name="threshold">Threshold parameter. A line is returned by the function if the corresponding accumulator value is greater than threshold. </param>
        /// <returns></returns>
#endif
        public CvSeq HoughLines2(CvMat lineStorage, HoughLinesMethod method, double rho, double theta, int threshold)
        {
            return Cv.HoughLines2(this, lineStorage, method, rho, theta, threshold, 0, 0);
        }
#if LANG_JP
        /// <summary>
        /// ハフ（Hough）変換を用いて2値画像から直線を検出する
        /// </summary>
        /// <param name="lineStorage">検出された線を保存する1行の行列/1列の行列. 行列のヘッダは，そのcols か rowsが検出された線の数となるように，この関数によって変更される．もし実際の線の数が行列のサイズを超える場合は，線の最大可能数が返される（標準的ハフ変換の場合は 投票数でソートされる）．</param>
        /// <param name="method">ハフ変換の種類</param>
        /// <param name="rho">距離解像度（１ピクセル当たりの単位）</param>
        /// <param name="theta">角度解像度（ラジアン単位で計測）</param>
        /// <param name="threshold">閾値パラメータ．対応する投票数がthresholdより大きい場合のみ，抽出された線が返される．</param>
        /// <param name="param1">各手法に応じた１番目のパラメータ．標準的ハフ変換では，使用しない（0）．確率的ハフ変換では，最小の線の長さ．マルチスケールハフ変換では， 距離解像度rhoの除数．（荒い距離解像度では rho であり，詳細な解像度では (rho / param1) となる）．</param>
        /// <param name="param2">各手法に応じた２番目のパラメータ．標準的ハフ変換では，使用しない（0）．確率的ハフ変換では，同一線上に存在する線分として扱う（つまり，それらを統合しても問題ない），二つの線分の最大の間隔． マルチスケールハフ変換では，角度解像度 thetaの除数． （荒い角度解像度では theta であり，詳細な解像度では (theta / param2) となる）． </param>
        /// <returns></returns>
#else
        /// <summary>
        /// Finds lines in binary image using Hough transform.
        /// </summary>
        /// <param name="lineStorage">The storage for the lines detected. It can be a memory storage or single row/single column matrix (CvMat*) of a particular type to which the lines' parameters are written. </param>
        /// <param name="method">The Hough transform variant.</param>
        /// <param name="rho">Distance resolution in pixel-related units. </param>
        /// <param name="theta">Angle resolution measured in radians. </param>
        /// <param name="threshold">Threshold parameter. A line is returned by the function if the corresponding accumulator value is greater than threshold. </param>
        /// <param name="param1">The first method-dependent parameter.</param>
        /// <param name="param2">The second method-dependent parameter.</param>
        /// <returns></returns>
#endif
        public CvSeq HoughLines2(CvMat lineStorage, HoughLinesMethod method, double rho, double theta, int threshold, double param1, double param2)
        {
            return Cv.HoughLines2(this, lineStorage, method, rho, theta, threshold, param1, param2);
        }
        #endregion
        #region IncRefData
#if LANG_JP
        /// <summary>
        /// 参照カウンタポインタが null ではない場合に， CvMat あるいは CvMatND のデータの参照カウンタをインクリメントし，新たなカウンタ値を返す．
        /// そうでない場合は 0 を返す． 
        /// </summary>
        /// <returns>新たなカウンタ値</returns>
#else
        /// <summary>
        /// Increments array data reference counter
        /// </summary>
        /// <returns>The function cvIncRefData increments CvMat or CvMatND data reference counter and returns the new counter value if the reference counter pointer is not NULL, otherwise it returns zero. </returns>
#endif
        public int IncRefData()
        {
            return Cv.IncRefData(this);
        }
        #endregion
        #region Inpaint
#if LANG_JP
        /// <summary>
        /// 配列の要素値が他の二つの配列要素で表される範囲内に位置するかをチェックする
        /// </summary>
        /// <param name="mask">修復マスク．8ビット，1チャンネル画像． 非0のピクセルが，修復の必要がある領域であることを示す．</param>
        /// <param name="dst">出力画像（入力画像と同じサイズ，同じタイプ）．</param>
        /// <param name="inpaintRange">修復されるピクセルの円状の隣接領域を示す半径</param>
        /// <param name="flags">修復方法</param>	
#else
        /// <summary>
        /// Inpaints the selected region in the image.
        /// </summary>
        /// <param name="mask">The inpainting mask, 8-bit 1-channel image. Non-zero pixels indicate the area that needs to be inpainted. </param>
        /// <param name="dst">The output image of the same format and the same size as input. </param>
        /// <param name="inpaintRange">The radius of circlular neighborhood of each point inpainted that is considered by the algorithm. </param>
        /// <param name="flags">The inpainting method.</param>
#endif
        public void Inpaint(CvArr mask, CvArr dst, double inpaintRange, InpaintMethod flags)
        {
            Cv.Inpaint(this, mask, dst, inpaintRange, flags);
        }
        #endregion
        #region InRange
#if LANG_JP
        /// <summary>
        /// 配列の要素値が他の二つの配列要素で表される範囲内に位置するかをチェックする
        /// </summary>
        /// <param name="lower">下限値（その値を含む）を表す配列</param>
        /// <param name="upper">上限値（その値は含まない）を表す配列</param>
        /// <param name="dst">出力配列（タイプは8u または 8s）</param>
#else
        /// <summary>
        /// Checks that array elements lie between elements of two other arrays
        /// </summary>
        /// <param name="lower">The inclusive lower boundary array. </param>
        /// <param name="upper">The exclusive upper boundary array. </param>
        /// <param name="dst">The destination array, must have 8u or 8s type. </param>
#endif
        public void InRange(CvArr lower, CvArr upper, CvArr dst)
        {
            Cv.InRange(this, lower, upper, dst);
        }
        #endregion
        #region InRangeS
#if LANG_JP
        /// <summary>
        /// 配列の要素値が二つのスカラーの間に位置するかをチェックする
        /// </summary>
        /// <param name="lower">下限値（その値を含む）</param>
        /// <param name="upper">上限値（その値は含まない）</param>
        /// <param name="dst">出力配列（タイプは8u または 8s）</param>
#else
        /// <summary>
        /// Checks that array elements lie between two scalars
        /// </summary>
        /// <param name="lower">The inclusive lower boundary. </param>
        /// <param name="upper">The exclusive upper boundary. </param>
        /// <param name="dst">The destination array, must have 8u or 8s type. </param>
#endif
        public void InRangeS(CvScalar lower, CvScalar upper, CvArr dst)
        {
            Cv.InRangeS(this, lower, upper, dst);
        }
        #endregion
        #region Integral
#if LANG_JP
        /// <summary>
        /// 任意の矩形領域の画素値の総和を計算する
        /// </summary>
        /// <param name="sum">インテグラルイメージ（integral image），W+1×H+1，32ビット整数型あるいは倍精度浮動小数点型（64f）． </param>
#else
        /// <summary>
        /// Calculates integral images.
        /// </summary>
        /// <param name="sum">The integral image, W+1xH+1, 32-bit integer or double precision floating-point (64f). </param>
#endif
        public void Integral(CvArr sum)
        {
            Cv.Integral(this, sum);
        }
#if LANG_JP
        /// <summary>
        /// 任意の矩形領域の画素値の総和を計算する
        /// </summary>
        /// <param name="sum">インテグラルイメージ（integral image），W+1×H+1，32ビット整数型あるいは倍精度浮動小数点型（64f）． </param>
        /// <param name="sqsum">オプション：各ピクセル値を2乗したインテグラルイメージ，W+1×H+1，倍精度浮動小数点型（64f）． </param>
#else
        /// <summary>
        /// Calculates integral images.
        /// </summary>
        /// <param name="sum">The integral image, W+1xH+1, 32-bit integer or double precision floating-point (64f). </param>
        /// <param name="sqsum">The integral image for squared pixel values, W+1xH+1, double precision floating-point (64f). </param>
#endif
        public void Integral(CvArr sum, CvArr sqsum)
        {
            Cv.Integral(this, sum, sqsum);
        }
#if LANG_JP
        /// <summary>
        /// 任意の矩形領域の画素値の総和を計算する
        /// </summary>
        /// <param name="sum">インテグラルイメージ（integral image），W+1×H+1，32ビット整数型あるいは倍精度浮動小数点型（64f）． </param>
        /// <param name="sqsum">オプション：各ピクセル値を2乗したインテグラルイメージ，W+1×H+1，倍精度浮動小数点型（64f）． </param>
        /// <param name="tiltedSum">オプション：45度回転させた入力画像のインテグラルイメージ，W+1×H+1，sumと同じデータフォーマット．</param>
#else
        /// <summary>
        /// Calculates integral images.
        /// </summary>
        /// <param name="sum">The integral image, W+1xH+1, 32-bit integer or double precision floating-point (64f). </param>
        /// <param name="sqsum">The integral image for squared pixel values, W+1xH+1, double precision floating-point (64f). </param>
        /// <param name="tiltedSum">The integral for the image rotated by 45 degrees, W+1xH+1, the same data type as sum. </param>
#endif
        public void Integral(CvArr sum, CvArr sqsum, CvArr tiltedSum)
        {
            Cv.Integral(this, sum, sqsum, tiltedSum);
        }
        #endregion
        #region Invert
#if LANG_JP
        /// <summary>
        /// 逆行列または擬似逆行列を求める.
        /// </summary>
        /// <param name="dst">出力行列</param>
        /// <returns></returns>
#else
        /// <summary>
        /// Finds inverse or pseudo-inverse of matrix
        /// </summary>
        /// <param name="dst">The destination matrix. </param>
        /// <returns>In case of LU method the function returns src1 determinant (src1 must be square). 
        /// If it is 0, the matrix is not inverted and src2 is filled with zeros.
        /// In case of SVD methods the function returns the inverted condition number of src1</returns>
#endif
        public double Invert(CvArr dst)
        {
            return Cv.Invert(this, dst);
        }
#if LANG_JP
        /// <summary>
        /// 逆行列または擬似逆行列を求める.
        /// </summary>
        /// <param name="dst">出力行列</param>
        /// <param name="method">逆行列を求める手法</param>
        /// <returns></returns>
#else
        /// <summary>
        /// Finds inverse or pseudo-inverse of matrix
        /// </summary>
        /// <param name="dst">The destination matrix. </param>
        /// <param name="method">Inversion method</param>
        /// <returns>In case of LU method the function returns src1 determinant (src1 must be square). 
        /// If it is 0, the matrix is not inverted and src2 is filled with zeros.
        /// In case of SVD methods the function returns the inverted condition number of src1</returns>
#endif
        public double Invert(CvArr dst, InvertMethod method)
        {
            return Cv.Invert(this, dst, method);
        }
#if LANG_JP
        /// <summary>
        /// 逆行列または擬似逆行列を求める. Invertのエイリアス.
        /// </summary>
        /// <param name="dst">出力行列</param>
        /// <returns></returns>
#else
        /// <summary>
        /// Finds inverse or pseudo-inverse of matrix
        /// </summary>
        /// <param name="dst">The destination matrix. </param>
        /// <returns>In case of LU method the function returns src1 determinant (src1 must be square). 
        /// If it is 0, the matrix is not inverted and src2 is filled with zeros.
        /// In case of SVD methods the function returns the inverted condition number of src1</returns>
#endif
        public double Inv(CvArr dst)
        {
            return Cv.Inv(this, dst);
        }
#if LANG_JP
        /// <summary>
        /// 逆行列または擬似逆行列を求める. Invertのエイリアス.
        /// </summary>
        /// <param name="dst">出力行列</param>
        /// <param name="method">逆行列を求める手法</param>
        /// <returns></returns>
#else
        /// <summary>
        /// Finds inverse or pseudo-inverse of matrix
        /// </summary>
        /// <param name="dst">The destination matrix. </param>
        /// <param name="method">Inversion method</param>
        /// <returns>In case of LU method the function returns src1 determinant (src1 must be square). 
        /// If it is 0, the matrix is not inverted and src2 is filled with zeros.
        /// In case of SVD methods the function returns the inverted condition number of src1</returns>
#endif
        public double Inv(CvArr dst, InvertMethod method)
        {
            return Cv.Inv(this, dst, method);
        }
        #endregion
        #region KMeans
#if LANG_JP
        /// <summary>
        /// ベクトル集合を，与えられたクラスタ数に分割する.
        /// 入力サンプルを各クラスタに分類するために cluster_count 個のクラスタの中心を求める k-means 法を実装する．
        /// 出力 labels(i) は，配列 samples のi番目の行のサンプルが属するクラスタのインデックスを表す． 
        /// </summary>
        /// <param name="clusterCount">集合を分割するクラスタ数</param>
        /// <param name="labels">出力の整数ベクトル．すべてのサンプルについて，それぞれがどのクラスタに属しているかが保存されている.</param>
        /// <param name="termcrit">最大繰り返し数と(または)，精度（1ループでの各クラスタ中心位置移動距離）の指定</param>
#else
        /// <summary>
        /// Splits set of vectors by given number of clusters
        /// </summary>
        /// <param name="clusterCount">Number of clusters to split the set by. </param>
        /// <param name="labels">Output integer vector storing cluster indices for every sample. </param>
        /// <param name="termcrit">Specifies maximum number of iterations and/or accuracy (distance the centers move by between the subsequent iterations). </param>
#endif
        public void KMeans2(int clusterCount, CvArr labels, CvTermCriteria termcrit)
        {
            Cv.KMeans2(this, clusterCount, labels, termcrit);
        }
        #endregion
        #region Laplace
#if LANG_JP
        /// <summary>
        /// Sobel演算子を用いて計算されたxとyの2次微分を加算することで，入力画像のラプラシアン（Laplacian）を計算する [aperture_size=3]
        /// </summary>
        /// <param name="dst">出力画像</param>
#else
        /// <summary>
        /// Calculates Laplacian of the source image by summing second x- and y- derivatives calculated using Sobel operator.
        /// </summary>
        /// <param name="dst">Destination image. </param>
#endif
        public void Laplace(CvArr dst)
        {
            Cv.Laplace(this, dst);
        }
#if LANG_JP
        /// <summary>
        /// Sobel演算子を用いて計算されたxとyの2次微分を加算することで，入力画像のラプラシアン（Laplacian）を計算する
        /// </summary>
        /// <param name="dst">出力画像</param>
        /// <param name="apertureSize">拡張Sobelカーネルのサイズ</param>
#else
        /// <summary>
        /// Calculates Laplacian of the source image by summing second x- and y- derivatives calculated using Sobel operator.
        /// </summary>
        /// <param name="dst">Destination image. </param>
        /// <param name="apertureSize">Aperture size (it has the same meaning as in cvSobel). </param>
#endif
        public void Laplace(CvArr dst, ApertureSize apertureSize)
        {
            Cv.Laplace(this, dst, apertureSize);
        }
        #endregion
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
#else
        /// <summary>
        /// Draws a line segment connecting two points
        /// </summary>
        /// <param name="pt1X">First point's x-coordinate of the line segment. </param>
        /// <param name="pt1Y">First point's y-coordinate of the line segment. </param>
        /// <param name="pt2X">Second point's x-coordinate of the line segment. </param>
        /// <param name="pt2Y">Second point's y-coordinate of the line segment. </param>
        /// <param name="color">Line color. </param>
#endif
        public void Line(int pt1X, int pt1Y, int pt2X, int pt2Y, CvScalar color)
        {
            Cv.Line(this, pt1X, pt1Y, pt2X, pt2Y, color);
        }
#if LANG_JP
        /// <summary>
        /// 2点を結ぶ線分を画像上に描画する．
        /// </summary>
        /// <param name="pt1X">線分の1番目の端点x</param>
        /// <param name="pt1Y">線分の1番目の端点y</param>
        /// <param name="pt2X">線分の2番目の端点x</param>
        /// <param name="pt2Y">線分の2番目の端点y</param>
        /// <param name="color">線分の色</param>
        /// <param name="thickness">線分の太さ</param>
#else
        /// <summary>
        /// Draws a line segment connecting two points
        /// </summary>
        /// <param name="pt1X">First point's x-coordinate of the line segment. </param>
        /// <param name="pt1Y">First point's y-coordinate of the line segment. </param>
        /// <param name="pt2X">Second point's x-coordinate of the line segment. </param>
        /// <param name="pt2Y">Second point's y-coordinate of the line segment. </param>
        /// <param name="color">Line color. </param>
        /// <param name="thickness">Line thickness. </param>
#endif
        public void Line(int pt1X, int pt1Y, int pt2X, int pt2Y, CvScalar color, int thickness)
        {
            Cv.Line(this, pt1X, pt1Y, pt2X, pt2Y, color, thickness);
        }
#if LANG_JP
        /// <summary>
        /// 2点を結ぶ線分を画像上に描画する．
        /// </summary>
        /// <param name="pt1X">線分の1番目の端点x</param>
        /// <param name="pt1Y">線分の1番目の端点y</param>
        /// <param name="pt2X">線分の2番目の端点x</param>
        /// <param name="pt2Y">線分の2番目の端点y</param>
        /// <param name="color">線分の色</param>
        /// <param name="thickness">線分の太さ</param>
        /// <param name="lineType">線分の種類</param>
#else
        /// <summary>
        /// Draws a line segment connecting two points
        /// </summary>
        /// <param name="pt1X">First point's x-coordinate of the line segment. </param>
        /// <param name="pt1Y">First point's y-coordinate of the line segment. </param>
        /// <param name="pt2X">Second point's x-coordinate of the line segment. </param>
        /// <param name="pt2Y">Second point's y-coordinate of the line segment. </param>
        /// <param name="color">Line color. </param>
        /// <param name="thickness">Line thickness. </param>
        /// <param name="lineType">Type of the line.</param>
#endif
        public void Line(int pt1X, int pt1Y, int pt2X, int pt2Y, CvScalar color, int thickness, LineType lineType)
        {
            Cv.Line(this, pt1X, pt1Y, pt2X, pt2Y, color, thickness, lineType);
        }
#if LANG_JP
        /// <summary>
        /// 2点を結ぶ線分を画像上に描画する．
        /// </summary>
        /// <param name="pt1X">線分の1番目の端点x</param>
        /// <param name="pt1Y">線分の1番目の端点y</param>
        /// <param name="pt2X">線分の2番目の端点x</param>
        /// <param name="pt2Y">線分の2番目の端点y</param>
        /// <param name="color">線分の色</param>
        /// <param name="thickness">線分の太さ</param>
        /// <param name="lineType">線分の種類</param>
        /// <param name="shift">座標の小数点以下の桁を表すビット数</param>
#else
        /// <summary>
        /// Draws a line segment connecting two points
        /// </summary>
        /// <param name="pt1X">First point's x-coordinate of the line segment. </param>
        /// <param name="pt1Y">First point's y-coordinate of the line segment. </param>
        /// <param name="pt2X">Second point's x-coordinate of the line segment. </param>
        /// <param name="pt2Y">Second point's y-coordinate of the line segment. </param>
        /// <param name="color">Line color. </param>
        /// <param name="thickness">Line thickness. </param>
        /// <param name="lineType">Type of the line.</param>
        /// <param name="shift">Number of fractional bits in the point coordinates. </param>
#endif
        public void Line(int pt1X, int pt1Y, int pt2X, int pt2Y, CvScalar color, int thickness, LineType lineType, int shift)
        {
            Cv.Line(this, pt1X, pt1Y, pt2X, pt2Y, color, thickness, lineType, shift);
        }

#if LANG_JP
        /// <summary>
        /// 2点を結ぶ線分を画像上に描画する．
        /// </summary>
        /// <param name="pt1">線分の1番目の端点</param>
        /// <param name="pt2">線分の2番目の端点</param>
        /// <param name="color">線分の色</param>
#else
        /// <summary>
        /// Draws a line segment connecting two points
        /// </summary>
        /// <param name="pt1">First point of the line segment. </param>
        /// <param name="pt2">Second point of the line segment. </param>
        /// <param name="color">Line color. </param>
#endif
        public void Line(CvPoint pt1, CvPoint pt2, CvScalar color)
        {
            Cv.Line(this, pt1, pt2, color);
        }
#if LANG_JP
        /// <summary>
        /// 2点を結ぶ線分を画像上に描画する．
        /// </summary>
        /// <param name="pt1">線分の1番目の端点</param>
        /// <param name="pt2">線分の2番目の端点</param>
        /// <param name="color">線分の色</param>
        /// <param name="thickness">線分の太さ</param>
#else
        /// <summary>
        /// Draws a line segment connecting two points
        /// </summary>
        /// <param name="pt1">First point of the line segment. </param>
        /// <param name="pt2">Second point of the line segment. </param>
        /// <param name="color">Line color. </param>
        /// <param name="thickness">Line thickness. </param>
#endif
        public void Line(CvPoint pt1, CvPoint pt2, CvScalar color, int thickness)
        {
            Cv.Line(this, pt1, pt2, color, thickness);
        }
#if LANG_JP
        /// <summary>
        /// 2点を結ぶ線分を画像上に描画する．
        /// </summary>
        /// <param name="pt1">線分の1番目の端点</param>
        /// <param name="pt2">線分の2番目の端点</param>
        /// <param name="color">線分の色</param>
        /// <param name="thickness">線分の太さ</param>
        /// <param name="lineType">線分の種類</param>
#else
        /// <summary>
        /// Draws a line segment connecting two points
        /// </summary>
        /// <param name="pt1">First point of the line segment. </param>
        /// <param name="pt2">Second point of the line segment. </param>
        /// <param name="color">Line color. </param>
        /// <param name="thickness">Line thickness. </param>
        /// <param name="lineType">Type of the line.</param>
#endif
        public void Line(CvPoint pt1, CvPoint pt2, CvScalar color, int thickness, LineType lineType)
        {
            Cv.Line(this, pt1, pt2, color, thickness, lineType);
        }
#if LANG_JP
        /// <summary>
        /// 2点を結ぶ線分を画像上に描画する．
        /// </summary>
        /// <param name="pt1">線分の1番目の端点</param>
        /// <param name="pt2">線分の2番目の端点</param>
        /// <param name="color">線分の色</param>
        /// <param name="thickness">線分の太さ</param>
        /// <param name="lineType">線分の種類</param>
        /// <param name="shift">座標の小数点以下の桁を表すビット数</param>
#else
        /// <summary>
        /// Draws a line segment connecting two points
        /// </summary>
        /// <param name="pt1">First point of the line segment. </param>
        /// <param name="pt2">Second point of the line segment. </param>
        /// <param name="color">Line color. </param>
        /// <param name="thickness">Line thickness. </param>
        /// <param name="lineType">Type of the line.</param>
        /// <param name="shift">Number of fractional bits in the point coordinates. </param>
#endif
        public void Line(CvPoint pt1, CvPoint pt2, CvScalar color, int thickness, LineType lineType, int shift)
        {
            Cv.Line(this, pt1, pt2, color, thickness, lineType, shift);
        }
#if LANG_JP
        /// <summary>
        /// 2点を結ぶ線分を画像上に描画する．
        /// </summary>
        /// <param name="pt1X">線分の1番目の端点x</param>
        /// <param name="pt1Y">線分の1番目の端点y</param>
        /// <param name="pt2X">線分の2番目の端点x</param>
        /// <param name="pt2Y">線分の2番目の端点y</param>
        /// <param name="color">線分の色</param>
#else
        /// <summary>
        /// Draws a line segment connecting two points
        /// </summary>
        /// <param name="pt1X">First point's x-coordinate of the line segment. </param>
        /// <param name="pt1Y">First point's y-coordinate of the line segment. </param>
        /// <param name="pt2X">Second point's x-coordinate of the line segment. </param>
        /// <param name="pt2Y">Second point's y-coordinate of the line segment. </param>
        /// <param name="color">Line color. </param>
#endif
        public void DrawLine(int pt1X, int pt1Y, int pt2X, int pt2Y, CvScalar color)
        {
            Cv.DrawLine(this, pt1X, pt1Y, pt2X, pt2Y, color);
        }
#if LANG_JP
        /// <summary>
        /// 2点を結ぶ線分を画像上に描画する．
        /// </summary>
        /// <param name="pt1X">線分の1番目の端点x</param>
        /// <param name="pt1Y">線分の1番目の端点y</param>
        /// <param name="pt2X">線分の2番目の端点x</param>
        /// <param name="pt2Y">線分の2番目の端点y</param>
        /// <param name="color">線分の色</param>
        /// <param name="thickness">線分の太さ</param>
#else
        /// <summary>
        /// Draws a line segment connecting two points
        /// </summary>
        /// <param name="pt1X">First point's x-coordinate of the line segment. </param>
        /// <param name="pt1Y">First point's y-coordinate of the line segment. </param>
        /// <param name="pt2X">Second point's x-coordinate of the line segment. </param>
        /// <param name="pt2Y">Second point's y-coordinate of the line segment. </param>
        /// <param name="color">Line color. </param>
        /// <param name="thickness">Line thickness. </param>
#endif
        public void DrawLine(int pt1X, int pt1Y, int pt2X, int pt2Y, CvScalar color, int thickness)
        {
            Cv.DrawLine(this, pt1X, pt1Y, pt2X, pt2Y, color, thickness);
        }
#if LANG_JP
        /// <summary>
        /// 2点を結ぶ線分を画像上に描画する．
        /// </summary>
        /// <param name="pt1X">線分の1番目の端点x</param>
        /// <param name="pt1Y">線分の1番目の端点y</param>
        /// <param name="pt2X">線分の2番目の端点x</param>
        /// <param name="pt2Y">線分の2番目の端点y</param>
        /// <param name="color">線分の色</param>
        /// <param name="thickness">線分の太さ</param>
        /// <param name="lineType">線分の種類</param>
#else
        /// <summary>
        /// Draws a line segment connecting two points
        /// </summary>
        /// <param name="pt1X">First point's x-coordinate of the line segment. </param>
        /// <param name="pt1Y">First point's y-coordinate of the line segment. </param>
        /// <param name="pt2X">Second point's x-coordinate of the line segment. </param>
        /// <param name="pt2Y">Second point's y-coordinate of the line segment. </param>
        /// <param name="color">Line color. </param>
        /// <param name="thickness">Line thickness. </param>
        /// <param name="lineType">Type of the line.</param>
#endif
        public void DrawLine(int pt1X, int pt1Y, int pt2X, int pt2Y, CvScalar color, int thickness, LineType lineType)
        {
            Cv.DrawLine(this, pt1X, pt1Y, pt2X, pt2Y, color, thickness, lineType);
        }
#if LANG_JP
        /// <summary>
        /// 2点を結ぶ線分を画像上に描画する．
        /// </summary>
        /// <param name="pt1X">線分の1番目の端点x</param>
        /// <param name="pt1Y">線分の1番目の端点y</param>
        /// <param name="pt2X">線分の2番目の端点x</param>
        /// <param name="pt2Y">線分の2番目の端点y</param>
        /// <param name="color">線分の色</param>
        /// <param name="thickness">線分の太さ</param>
        /// <param name="lineType">線分の種類</param>
        /// <param name="shift">座標の小数点以下の桁を表すビット数</param>
#else
        /// <summary>
        /// Draws a line segment connecting two points
        /// </summary>
        /// <param name="pt1X">First point's x-coordinate of the line segment. </param>
        /// <param name="pt1Y">First point's y-coordinate of the line segment. </param>
        /// <param name="pt2X">Second point's x-coordinate of the line segment. </param>
        /// <param name="pt2Y">Second point's y-coordinate of the line segment. </param>
        /// <param name="color">Line color. </param>
        /// <param name="thickness">Line thickness. </param>
        /// <param name="lineType">Type of the line.</param>
        /// <param name="shift">Number of fractional bits in the point coordinates. </param>
#endif
        public void DrawLine(int pt1X, int pt1Y, int pt2X, int pt2Y, CvScalar color, int thickness, LineType lineType, int shift)
        {
            Cv.DrawLine(this, pt1X, pt1Y, pt2X, pt2Y, color, thickness, lineType, shift);
        }

#if LANG_JP
        /// <summary>
        /// 2点を結ぶ線分を画像上に描画する．
        /// </summary>
        /// <param name="pt1">線分の1番目の端点</param>
        /// <param name="pt2">線分の2番目の端点</param>
        /// <param name="color">線分の色</param>
#else
        /// <summary>
        /// Draws a line segment connecting two points
        /// </summary>
        /// <param name="pt1">First point of the line segment. </param>
        /// <param name="pt2">Second point of the line segment. </param>
        /// <param name="color">Line color. </param>
#endif
        public void DrawLine(CvPoint pt1, CvPoint pt2, CvScalar color)
        {
            Cv.DrawLine(this, pt1, pt2, color);
        }
#if LANG_JP
        /// <summary>
        /// 2点を結ぶ線分を画像上に描画する．
        /// </summary>
        /// <param name="pt1">線分の1番目の端点</param>
        /// <param name="pt2">線分の2番目の端点</param>
        /// <param name="color">線分の色</param>
        /// <param name="thickness">線分の太さ</param>
#else
        /// <summary>
        /// Draws a line segment connecting two points
        /// </summary>
        /// <param name="pt1">First point of the line segment. </param>
        /// <param name="pt2">Second point of the line segment. </param>
        /// <param name="color">Line color. </param>
        /// <param name="thickness">Line thickness. </param>
#endif
        public void DrawLine(CvPoint pt1, CvPoint pt2, CvScalar color, int thickness)
        {
            Cv.DrawLine(this, pt1, pt2, color, thickness);
        }
#if LANG_JP
        /// <summary>
        /// 2点を結ぶ線分を画像上に描画する．
        /// </summary>
        /// <param name="pt1">線分の1番目の端点</param>
        /// <param name="pt2">線分の2番目の端点</param>
        /// <param name="color">線分の色</param>
        /// <param name="thickness">線分の太さ</param>
        /// <param name="lineType">線分の種類</param>
#else
        /// <summary>
        /// Draws a line segment connecting two points
        /// </summary>
        /// <param name="pt1">First point of the line segment. </param>
        /// <param name="pt2">Second point of the line segment. </param>
        /// <param name="color">Line color. </param>
        /// <param name="thickness">Line thickness. </param>
        /// <param name="lineType">Type of the line.</param>
#endif
        public void DrawLine(CvPoint pt1, CvPoint pt2, CvScalar color, int thickness, LineType lineType)
        {
            Cv.DrawLine(this, pt1, pt2, color, thickness, lineType);
        }
#if LANG_JP
        /// <summary>
        /// 2点を結ぶ線分を画像上に描画する．
        /// </summary>
        /// <param name="pt1">線分の1番目の端点</param>
        /// <param name="pt2">線分の2番目の端点</param>
        /// <param name="color">線分の色</param>
        /// <param name="thickness">線分の太さ</param>
        /// <param name="lineType">線分の種類</param>
        /// <param name="shift">座標の小数点以下の桁を表すビット数</param>
#else
        /// <summary>
        /// Draws a line segment connecting two points
        /// </summary>
        /// <param name="pt1">First point of the line segment. </param>
        /// <param name="pt2">Second point of the line segment. </param>
        /// <param name="color">Line color. </param>
        /// <param name="thickness">Line thickness. </param>
        /// <param name="lineType">Type of the line.</param>
        /// <param name="shift">Number of fractional bits in the point coordinates. </param>
#endif
        public void DrawLine(CvPoint pt1, CvPoint pt2, CvScalar color, int thickness, LineType lineType, int shift)
        {
            Cv.DrawLine(this, pt1, pt2, color, thickness, lineType, shift);
        }
        #endregion
        #region LinearPolar
#if LANG_JP
        /// <summary>
        /// Performs forward or inverse linear-polar image transform
        /// </summary>
        /// <param name="dst"></param>
        /// <param name="center"></param>
        /// <param name="maxRadius"></param>
#else
        /// <summary>
        /// Performs forward or inverse linear-polar image transform
        /// </summary>
        /// <param name="dst"></param>
        /// <param name="center"></param>
        /// <param name="maxRadius"></param>
#endif
        public void LinearPolar(CvArr dst, CvPoint2D32f center, double maxRadius)
        {
            Cv.LinearPolar(this, dst, center, maxRadius);
        }
#if LANG_JP
        /// <summary>
        /// Performs forward or inverse linear-polar image transform
        /// </summary>
        /// <param name="dst"></param>
        /// <param name="center"></param>
        /// <param name="maxRadius"></param>
        /// <param name="flags"></param>
#else
        /// <summary>
        /// Performs forward or inverse linear-polar image transform
        /// </summary>
        /// <param name="dst"></param>
        /// <param name="center"></param>
        /// <param name="maxRadius"></param>
        /// <param name="flags"></param>
#endif
        public void LinearPolar(CvArr dst, CvPoint2D32f center, double maxRadius, Interpolation flags)
        {
            Cv.LinearPolar(this, dst, center, maxRadius, flags);
        }
        #endregion
        #region Log
#if LANG_JP
        /// <summary>
        /// すべての配列要素の絶対値の自然対数を計算する
        /// </summary>
        /// <param name="dst">出力配列．倍精度の浮動小数点型（double），または入力配列と同じタイプでなければならない．</param>
#else
        /// <summary>
        /// Calculates natural logarithm of every array element absolute value
        /// </summary>
        /// <param name="dst">The destination array, it should have double type or the same type as the source. </param>
#endif
        public void Log(CvArr dst)
        {
            Cv.Log(this, dst);
        }
        #endregion
        #region LogPolar
#if LANG_JP
        /// <summary>
        /// 画像を対数極座標（Log-Polar）空間に再マッピングする.
        /// この関数は人間の網膜をモデル化したものであり，オブジェクトトラッキング等のための高速なスケーリングと，
        /// 回転に不変なテンプレートマッチングに用いることができる．
        /// </summary>
        /// <param name="dst">出力画像</param>
        /// <param name="center">出力精度が最大となるような変換の中心座標</param>
        /// <param name="m">スケーリング係数の大きさ</param>
#else
        /// <summary>
        /// Remaps image to log-polar space.
        /// The function emulates the human "foveal" vision and can be used for fast scale and rotation-invariant template matching, for object tracking etc.
        /// </summary>
        /// <param name="dst">Destination image. </param>
        /// <param name="center">The transformation center, where the output precision is maximal. </param>
        /// <param name="m">Magnitude scale parameter. See below. </param>
#endif
        public void LogPolar(CvArr dst, CvPoint2D32f center, double m)
        {
            Cv.LogPolar(this, dst, center, m);
        }
#if LANG_JP
        /// <summary>
        /// 画像を対数極座標（Log-Polar）空間に再マッピングする. 
        /// この関数は人間の網膜をモデル化したものであり，オブジェクトトラッキング等のための高速なスケーリングと，
        /// 回転に不変なテンプレートマッチングに用いることができる．
        /// </summary>
        /// <param name="dst">出力画像</param>
        /// <param name="center">出力精度が最大となるような変換の中心座標</param>
        /// <param name="m">スケーリング係数の大きさ</param>
        /// <param name="flags">補間方法</param>
#else
        /// <summary>
        /// Remaps image to log-polar space.
        /// The function emulates the human "foveal" vision and can be used for fast scale and rotation-invariant template matching, for object tracking etc.
        /// </summary>
        /// <param name="dst">Destination image. </param>
        /// <param name="center">The transformation center, where the output precision is maximal. </param>
        /// <param name="m">Magnitude scale parameter. See below. </param>
        /// <param name="flags">A combination of interpolation method and the optional flags.</param>
#endif
        public void LogPolar(CvArr dst, CvPoint2D32f center, double m, Interpolation flags)
        {
            Cv.LogPolar(this, dst, center, m, flags);
        }
        #endregion
        #region LUT
#if LANG_JP
        /// <summary>
        /// 出力配列の各要素値をルックアップテーブルを用いて決定する．
        /// </summary>
        /// <param name="dst">出力配列（任意のデプス，入力配列と同じチャンネル数）．</param>
        /// <param name="lut">要素数が256であるルックアップテーブル（出力配列と同じデプスでなければならない）．マルチチャンネルの入力/出力配列の場合，テーブルはシングルチャンネル（この場合すべてのチャンネル対して，同じテーブルを使う）か，入力/出力配列と同じチャンネル数でなければならない．</param>
#else
        /// <summary>
        /// Performs look-up table transform of array
        /// </summary>
        /// <param name="dst">Destination array of arbitrary depth and of the same number of channels as the source array. </param>
        /// <param name="lut">Look-up table of 256 elements; should have the same depth as the destination array. In case of multi-channel source and destination arrays, the table should either have a single-channel (in this case the same table is used for all channels), or the same number of channels as the source/destination array. </param>
#endif
        public void LUT(CvArr dst, CvArr lut)
        {
            Cv.LUT(this, dst, lut);
        }
#if LANG_JP
        /// <summary>
        /// 出力配列の各要素値をルックアップテーブルを用いて決定する．ルックアップテーブルが配列で指定できる簡易バージョン.
        /// </summary>
        /// <param name="dst">出力配列（任意のデプス，入力配列と同じチャンネル数）</param>
        /// <param name="lut">要素数が256であるルックアップテーブル</param>
#else
        /// <summary>
        /// Performs look-up table transform of array
        /// </summary>
        /// <param name="dst">Destination array of arbitrary depth and of the same number of channels as the source array. </param>
        /// <param name="lut">Look-up table of 256 elements; should have the same depth as the destination array. </param>
#endif
        public void LUT(CvArr dst, byte[] lut)
        {
            Cv.LUT(this, dst, lut);
        }
#if LANG_JP
        /// <summary>
        /// 出力配列の各要素値をルックアップテーブルを用いて決定する．ルックアップテーブルが配列で指定できる簡易バージョン.
        /// </summary>
        /// <param name="dst">出力配列（任意のデプス，入力配列と同じチャンネル数）</param>
        /// <param name="lut">要素数が256であるルックアップテーブル</param>
#else
        /// <summary>
        /// Performs look-up table transform of array
        /// </summary>
        /// <param name="dst">Destination array of arbitrary depth and of the same number of channels as the source array. </param>
        /// <param name="lut">Look-up table of 256 elements; should have the same depth as the destination array. </param>
#endif
        public void LUT(CvArr dst, short[] lut)
        {
            Cv.LUT(this, dst, lut);
        }
#if LANG_JP
        /// <summary>
        /// 出力配列の各要素値をルックアップテーブルを用いて決定する．ルックアップテーブルが配列で指定できる簡易バージョン.
        /// </summary>
        /// <param name="dst">出力配列（任意のデプス，入力配列と同じチャンネル数）</param>
        /// <param name="lut">要素数が256であるルックアップテーブル</param>
#else
        /// <summary>
        /// Performs look-up table transform of array
        /// </summary>
        /// <param name="dst">Destination array of arbitrary depth and of the same number of channels as the source array. </param>
        /// <param name="lut">Look-up table of 256 elements; should have the same depth as the destination array. </param>
#endif
        public void LUT(CvArr dst, int[] lut)
        {
            Cv.LUT(this, dst, lut);
        }
#if LANG_JP
        /// <summary>
        /// 出力配列の各要素値をルックアップテーブルを用いて決定する．ルックアップテーブルが配列で指定できる簡易バージョン.
        /// </summary>
        /// <param name="dst">出力配列（任意のデプス，入力配列と同じチャンネル数）</param>
        /// <param name="lut">要素数が256であるルックアップテーブル</param>
#else
        /// <summary>
        /// Performs look-up table transform of array
        /// </summary>
        /// <param name="dst">Destination array of arbitrary depth and of the same number of channels as the source array. </param>
        /// <param name="lut">Look-up table of 256 elements; should have the same depth as the destination array. </param>
#endif
        public void LUT(CvArr dst, float[] lut)
        {
            Cv.LUT(this, dst, lut);
        }
#if LANG_JP
        /// <summary>
        /// 出力配列の各要素値をルックアップテーブルを用いて決定する．ルックアップテーブルが配列で指定できる簡易バージョン.
        /// </summary>
        /// <param name="dst">出力配列（任意のデプス，入力配列と同じチャンネル数）</param>
        /// <param name="lut">要素数が256であるルックアップテーブル</param>
#else
        /// <summary>
        /// Performs look-up table transform of array
        /// </summary>
        /// <param name="dst">Destination array of arbitrary depth and of the same number of channels as the source array. </param>
        /// <param name="lut">Look-up table of 256 elements; should have the same depth as the destination array. </param>
#endif
        public void LUT(CvArr dst, double[] lut)
        {
            Cv.LUT(this, dst, lut);
        }
        #endregion
        #region MatchTemplate
#if LANG_JP
        /// <summary>
        /// テンプレートと重なった画像領域を比較する. 
        /// templを，image全体に対してスライドさせ，それとサイズ w×h で重なる領域とを指定された方法で比較し，その結果を result に保存する． 
        /// </summary>
        /// <param name="templ">探索用テンプレート．画像より大きくてはならない，かつ画像と同じタイプである必要がある． </param>
        /// <param name="result">比較結果のマップ．シングルチャンネルの32ビット浮動小数点型データ．image が W×H で templ が w×h ならば， result は W-w+1×H-h+1のサイズが必要． </param>
        /// <param name="method">テンプレートマッチングの方法（以下を参照）．</param>
#else
        /// <summary>
        /// Compares template against overlapped image regions.
        /// </summary>
        /// <param name="templ">Searched template; must be not greater than the source image and the same data type as the image. </param>
        /// <param name="result">A map of comparison results; single-channel 32-bit floating-point. If image is W×H and templ is w×h then result must be W-w+1×H-h+1. </param>
        /// <param name="method">Specifies the way the template must be compared with image regions. </param>
#endif
        public void MatchTemplate(CvArr templ, CvArr result, MatchTemplateMethod method)
        {
            Cv.MatchTemplate(this, templ, result, method);
        }
        #endregion
        #region Max
#if LANG_JP
        /// <summary>
        /// 二つの配列の各要素についての最大値を求める. 
        /// dst(I)=max(src1(I), src2(I)) 
        /// </summary>
        /// <param name="src2">2番目の入力配列</param>
        /// <param name="dst">出力配列</param>
#else
        /// <summary>
        /// Finds per-element maximum of two arrays
        /// </summary>
        /// <param name="src2">The second source array. </param>
        /// <param name="dst">The destination array. </param>
#endif
        public void Max(CvArr src2, CvArr dst)
        {
            Cv.Max(this, src2, dst);
        }
        #endregion
        #region MaxS
#if LANG_JP
        /// <summary>
        /// 配列の各要素とスカラーについての最大値を求める. 
        /// dst(I)=max(src(I), value) 
        /// </summary>
        /// <param name="value">スカラー</param>
        /// <param name="dst">出力配列</param>
#else
        /// <summary>
        /// Finds per-element maximum of array and scalar
        /// </summary>
        /// <param name="value">The scalar value. </param>
        /// <param name="dst">The destination array. </param>
#endif
        public void MaxS(double value, CvArr dst)
        {
            Cv.MaxS(this, value, dst);
        }
        #endregion
        #region Min
#if LANG_JP
        /// <summary>
        /// 二つの配列の各要素についての最小値を求める. 
        /// dst(I)=min(src1(I), src2(I)) 
        /// </summary>
        /// <param name="src2">2番目の入力配列</param>
        /// <param name="dst">出力配列</param>
#else
        /// <summary>
        /// Finds per-element minimum of two arrays
        /// </summary>
        /// <param name="src2">The second source array. </param>
        /// <param name="dst">The destination array. </param>
#endif
        public void Min(CvArr src2, CvArr dst)
        {
            Cv.Min(this, src2, dst);
        }
        #endregion
        #region MinAreaRect2
#if LANG_JP
        /// <summary>
        /// 与えられた2次元の点列を囲む最小矩形を求める
        /// </summary>
        /// <returns>2次元の点列に対する最小矩形</returns>
#else
        /// <summary>
        /// Finds circumscribed rectangle of minimal area for given 2D point set
        /// </summary>
        /// <returns>The function cvMinAreaRect2 finds a circumscribed rectangle of the minimal area for 2D point set by building convex hull for the set and applying rotating calipers technique to the hull.</returns> 
#endif
        public CvBox2D MinAreaRect2()
        {
            return Cv.MinAreaRect2(this);
        }
#if LANG_JP
        /// <summary>
        /// 与えられた2次元の点列を囲む最小矩形を求める
        /// </summary>
        /// <param name="storage">一時的なメモリストレージ</param>
        /// <returns>2次元の点列に対する最小矩形</returns>
#else
        /// <summary>
        /// Finds circumscribed rectangle of minimal area for given 2D point set
        /// </summary>
        /// <param name="storage">The point tested against the contour.</param>
        /// <returns>The function cvMinAreaRect2 finds a circumscribed rectangle of the minimal area for 2D point set by building convex hull for the set and applying rotating calipers technique to the hull.</returns> 
#endif
        public CvBox2D MinAreaRect2(CvMemStorage storage)
        {
            return Cv.MinAreaRect2(this, storage);
        }
        #endregion
        #region MinEnclosingCircle
#if LANG_JP
        /// <summary>
        /// 与えられた2次元の点列を囲む最小円を求める
        /// </summary>
        /// <param name="center">出力パラメータ．囲む円の中心．</param>
        /// <param name="radius">出力パラメータ．囲む円の半径．</param>
        /// <returns>結果の円が全ての入力点を含む場合はtrueを返し， それ以外（すなわちアルゴリズムの失敗）の場合はfalseを返す．</returns>
#else
        /// <summary>
        /// Finds circumscribed rectangle of minimal area for given 2D point set
        /// </summary>
        /// <param name="center">Output parameter. The center of the enclosing circle. </param>
        /// <param name="radius">Output parameter. The radius of the enclosing circle. </param>
        /// <returns>The function cvMinEnclosingCircle finds the minimal circumscribed circle for 2D point set using iterative algorithm. 
        /// It returns true if the resultant circle contains all the input points and false otherwise (i.e. algorithm failed). </returns> 
#endif
        public bool MinEnclosingCircle(out CvPoint2D32f center, out float radius)
        {
            return Cv.MinEnclosingCircle(this, out center, out radius);
        }
        #endregion
        #region MinMaxLoc
#if LANG_JP
        /// <summary>
        /// 配列あるいは部分配列内の最小値と最大値を求める
        /// </summary>
        /// <param name="minVal">戻り値の最小値</param>
        /// <param name="maxVal">戻り値の最大値</param>
#else
        /// <summary>
        /// Finds global minimum and maximum in array or subarray
        /// </summary>
        /// <param name="minVal">Pointer to returned minimum value. </param>
        /// <param name="maxVal">Pointer to returned maximum value. </param>
#endif
        public void MinMaxLoc(out double minVal, out double maxVal)
        {
            Cv.MinMaxLoc(this, out minVal, out maxVal);
        }
#if LANG_JP
        /// <summary>
        /// 配列あるいは部分配列内の最小値と最大値を求める
        /// </summary>
        /// <param name="minVal">戻り値の最小値</param>
        /// <param name="maxVal">戻り値の最大値</param>
        /// <param name="mask">部分配列を指定するためのオプションのマスク</param>
#else
        /// <summary>
        /// Finds global minimum and maximum in array or subarray
        /// </summary>
        /// <param name="minVal">Pointer to returned minimum value. </param>
        /// <param name="maxVal">Pointer to returned maximum value. </param>
        /// <param name="mask">The optional mask that is used to select a subarray. </param>
#endif
        public void MinMaxLoc(out double minVal, out double maxVal, CvArr mask)
        {
            Cv.MinMaxLoc(this, out minVal, out maxVal, mask);
        }
#if LANG_JP
        /// <summary>
        /// 配列あるいは部分配列内の最小値と最大値を求める
        /// </summary>
        /// <param name="minLoc">戻り値の最小値を持つ位置</param>
        /// <param name="maxLoc">戻り値の最大値を持つ位置</param>
#else
        /// <summary>
        /// Finds global minimum and maximum in array or subarray
        /// </summary>
        /// <param name="minLoc">Pointer to returned minimum location. </param>
        /// <param name="maxLoc">Pointer to returned maximum location. </param>
#endif
        public void MinMaxLoc(out CvPoint minLoc, out CvPoint maxLoc)
        {
            Cv.MinMaxLoc(this, out minLoc, out maxLoc);
        }
#if LANG_JP
        /// <summary>
        /// 配列あるいは部分配列内の最小値と最大値を求める
        /// </summary>
        /// <param name="minLoc">戻り値の最小値を持つ位置</param>
        /// <param name="maxLoc">戻り値の最大値を持つ位置</param>
        /// <param name="mask">部分配列を指定するためのオプションのマスク</param>
#else
        /// <summary>
        /// Finds global minimum and maximum in array or subarray
        /// </summary>
        /// <param name="minLoc">Pointer to returned minimum location. </param>
        /// <param name="maxLoc">Pointer to returned maximum location. </param>
        /// <param name="mask">The optional mask that is used to select a subarray. </param>
#endif
        public void MinMaxLoc(out CvPoint minLoc, out CvPoint maxLoc, CvArr mask)
        {
            Cv.MinMaxLoc(this, out minLoc, out maxLoc, mask);
        }
#if LANG_JP
        /// <summary>
        /// 配列あるいは部分配列内の最小値と最大値を求める
        /// </summary>
        /// <param name="minVal">戻り値の最小値</param>
        /// <param name="maxVal">戻り値の最大値</param>
        /// <param name="minLoc">戻り値の最小値を持つ位置</param>
        /// <param name="maxLoc">戻り値の最大値を持つ位置</param>
#else
        /// <summary>
        /// Finds global minimum and maximum in array or subarray
        /// </summary>
        /// <param name="minVal">Pointer to returned minimum value. </param>
        /// <param name="maxVal">Pointer to returned maximum value. </param>
        /// <param name="minLoc">Pointer to returned minimum location. </param>
        /// <param name="maxLoc">Pointer to returned maximum location. </param>
#endif
        public void MinMaxLoc(out double minVal, out double maxVal, out CvPoint minLoc, out CvPoint maxLoc)
        {
            Cv.MinMaxLoc(this, out minVal, out maxVal, out minLoc, out maxLoc);
        }
#if LANG_JP
        /// <summary>
        /// 配列あるいは部分配列内の最小値と最大値を求める
        /// </summary>
        /// <param name="minVal">戻り値の最小値</param>
        /// <param name="maxVal">戻り値の最大値</param>
        /// <param name="minLoc">戻り値の最小値を持つ位置</param>
        /// <param name="maxLoc">戻り値の最大値を持つ位置</param>
        /// <param name="mask">部分配列を指定するためのオプションのマスク</param>
#else
        /// <summary>
        /// Finds global minimum and maximum in array or subarray
        /// </summary>
        /// <param name="minVal">Pointer to returned minimum value. </param>
        /// <param name="maxVal">Pointer to returned maximum value. </param>
        /// <param name="minLoc">Pointer to returned minimum location. </param>
        /// <param name="maxLoc">Pointer to returned maximum location. </param>
        /// <param name="mask">The optional mask that is used to select a subarray. </param>
#endif
        public void MinMaxLoc(out double minVal, out double maxVal, out CvPoint minLoc, out CvPoint maxLoc, CvArr mask)
        {
            Cv.MinMaxLoc(this, out minVal, out maxVal, out minLoc, out maxLoc, mask);
        }
        #endregion
        #region MinS
#if LANG_JP
        /// <summary>
        /// 配列の各要素とスカラーについての最小値を求める. 
        /// dst(I)=min(src(I), value) 
        /// </summary>
        /// <param name="value">スカラー</param>
        /// <param name="dst">出力配列</param>
#else
        /// <summary>
        /// Finds per-element minimum of array and scalar
        /// </summary>
        /// <param name="value">The scalar value. </param>
        /// <param name="dst">The destination array. </param>
#endif
        public void MinS(double value, CvArr dst)
        {
            Cv.MinS(this, value, dst);
        }
        #endregion
        #region Moments
#if LANG_JP
        /// <summary>
        /// ポリゴンまたはラスタ形状の３次までのモーメントを計算する
        /// </summary>
        /// <param name="isBinary">（画像の場合のみ）このフラグがtrueの場合，値0のピクセルは0として，その他のピクセル値は1として扱われる． </param>
        /// <returns></returns>
#else
        /// <summary>
        /// Moments
        /// </summary>
        /// <param name="isBinary">(For images only) If the flag is non-zero, all the zero pixel values are treated as zeroes, all the others are treated as 1’s</param>
        /// <returns></returns>
#endif
        public CvMoments Moments(bool isBinary)
        {
            CvMoments moments;
            Cv.Moments(this, out moments, isBinary);
            return moments;
        }
        #endregion
        #region Mul
#if LANG_JP
        /// <summary>
        /// 二つの配列の要素同士を乗算する (scale=1).
        /// dst(I) = scale * src1(I) * src2(I)
        /// </summary>
        /// <param name="src2">2番目の入力配列</param>
        /// <param name="dst">出力配列</param>
#else
        /// <summary>
        /// Calculates per-element product of two arrays
        /// </summary>
        /// <param name="src2">The second source array. </param>
        /// <param name="dst">The destination array. </param>
#endif
        public void Mul(CvArr src2, CvArr dst)
        {
            Cv.Mul(this, src2, dst);
        }
#if LANG_JP
        /// <summary>
        /// 二つの配列の要素同士を乗算する.
        /// dst(I) = scale * src1(I) * src2(I)
        /// </summary>
        /// <param name="src2">2番目の入力配列</param>
        /// <param name="dst">出力配列</param>
        /// <param name="scale">任意のスケーリング係数</param>
#else
        /// <summary>
        /// Calculates per-element product of two arrays
        /// </summary>
        /// <param name="src2">The second source array. </param>
        /// <param name="dst">The destination array. </param>
        /// <param name="scale">Optional scale factor </param>
#endif
        public void Mul(CvArr src2, CvArr dst, double scale)
        {
            Cv.Mul(this, src2, dst, scale);
        }
        #endregion
        #region Norm
#if LANG_JP
        /// <summary>
        /// 配列の絶対値ノルム（absolute array norm）を計算する
        /// </summary>
        /// <returns></returns>
#else
        /// <summary>
        /// Calculates absolute array norm, absolute difference norm or relative difference norm
        /// </summary>
        /// <returns></returns>
#endif
        public double Norm()
        {
            return Cv.Norm(this);
        }
#if LANG_JP
        /// <summary>
        /// 配列の絶対値ノルム（absolute array norm），絶対値差分ノルム（absolute difference norm），相対値差分ノルム（relative difference norm）を計算する
        /// </summary>
        /// <param name="arr2">2番目の入力画像．null の場合，arr1の絶対値ノルムが計算され，そうでない場合は，arr1-arr2 の絶対値あるいは相対値ノルムが計算される． </param>
        /// <returns></returns>
#else
        /// <summary>
        /// Calculates absolute array norm, absolute difference norm or relative difference norm
        /// </summary>
        /// <param name="arr2">The second source image. If it is null, the absolute norm of arr1 is calculated, otherwise absolute or relative norm of arr1-arr2 is calculated. </param>
        /// <returns></returns>
#endif
        public double Norm(CvArr arr2)
        {
            return Cv.Norm(this, arr2);
        }
#if LANG_JP
        /// <summary>
        /// 配列の絶対値ノルム（absolute array norm），絶対値差分ノルム（absolute difference norm），相対値差分ノルム（relative difference norm）を計算する
        /// </summary>
        /// <param name="arr2">2番目の入力画像．null の場合，arr1の絶対値ノルムが計算され，そうでない場合は，arr1-arr2 の絶対値あるいは相対値ノルムが計算される． </param>
        /// <param name="normType">ノルムのタイプ</param>
        /// <returns></returns>
#else
        /// <summary>
        /// Calculates absolute array norm, absolute difference norm or relative difference norm
        /// </summary>
        /// <param name="arr2">The second source image. If it is null, the absolute norm of arr1 is calculated, otherwise absolute or relative norm of arr1-arr2 is calculated. </param>
        /// <param name="normType">Type of norm</param>
        /// <returns></returns>
#endif
        public double Norm(CvArr arr2, NormType normType)
        {
            return Cv.Norm(this, arr2, normType);
        }
#if LANG_JP
        /// <summary>
        /// 配列の絶対値ノルム（absolute array norm），絶対値差分ノルム（absolute difference norm），相対値差分ノルム（relative difference norm）を計算する
        /// </summary>
        /// <param name="arr2">2番目の入力画像．null の場合，arr1の絶対値ノルムが計算され，そうでない場合は，arr1-arr2 の絶対値あるいは相対値ノルムが計算される． </param>
        /// <param name="normType">ノルムのタイプ</param>
        /// <param name="mask">オプションの処理マスク</param>
        /// <returns></returns>
#else
        /// <summary>
        /// Calculates absolute array norm, absolute difference norm or relative difference norm
        /// </summary>
        /// <param name="arr2">The second source image. If it is null, the absolute norm of arr1 is calculated, otherwise absolute or relative norm of arr1-arr2 is calculated. </param>
        /// <param name="normType">Type of norm</param>
        /// <param name="mask">The optional operation mask. </param>
        /// <returns></returns>
#endif
        public double Norm(CvArr arr2, NormType normType, CvArr mask)
        {
            return Cv.Norm(this, arr2, normType, mask);
        }
        #endregion
        #region Normalize
#if LANG_JP
        /// <summary>
        /// 指定のノルムになるように，あるいは値が指定の範囲になるように，配列を正規化する
        /// </summary>
        /// <param name="dst">出力配列．インプレース処理が可能．</param>
#else
        /// <summary>
        /// Normalizes array to a certain norm or value range
        /// </summary>
        /// <param name="dst">The output array; in-place operation is supported. </param>
#endif
        public void Normalize(CvArr dst)
        {
            Cv.Normalize(this, dst);
        }
#if LANG_JP
        /// <summary>
        /// 指定のノルムになるように，あるいは値が指定の範囲になるように，配列を正規化する
        /// </summary>
        /// <param name="dst">出力配列．インプレース処理が可能．</param>
        /// <param name="a">出力配列の最小値または最大値，あるいは出力配列のノルム．</param>
        /// <param name="b">出力配列の最大値または最小値．</param>
#else
        /// <summary>
        /// Normalizes array to a certain norm or value range
        /// </summary>
        /// <param name="dst">The output array; in-place operation is supported. </param>
        /// <param name="a">The minimum/maximum value of the output array or the norm of output array. </param>
        /// <param name="b">The maximum/minimum value of the output array. </param>
#endif
        public void Normalize(CvArr dst, double a, double b)
        {
            Cv.Normalize(this, dst, a, b);
        }
#if LANG_JP
        /// <summary>
        /// 指定のノルムになるように，あるいは値が指定の範囲になるように，配列を正規化する
        /// </summary>
        /// <param name="dst">出力配列．インプレース処理が可能．</param>
        /// <param name="a">出力配列の最小値または最大値，あるいは出力配列のノルム．</param>
        /// <param name="b">出力配列の最大値または最小値．</param>
        /// <param name="normType">正規化のタイプ. C, L1, L2, MinMaxのうち1つ.</param>
#else
        /// <summary>
        /// Normalizes array to a certain norm or value range
        /// </summary>
        /// <param name="dst">The output array; in-place operation is supported. </param>
        /// <param name="a">The minimum/maximum value of the output array or the norm of output array. </param>
        /// <param name="b">The maximum/minimum value of the output array. </param>
        /// <param name="normType">The normalization type.</param>
#endif
        public void Normalize(CvArr dst, double a, double b, NormType normType)
        {
            Cv.Normalize(this, dst, a, b, normType);
        }
#if LANG_JP
        /// <summary>
        /// 指定のノルムになるように，あるいは値が指定の範囲になるように，配列を正規化する
        /// </summary>
        /// <param name="dst">出力配列．インプレース処理が可能．</param>
        /// <param name="a">出力配列の最小値または最大値，あるいは出力配列のノルム．</param>
        /// <param name="b">出力配列の最大値または最小値．</param>
        /// <param name="normType">正規化のタイプ. C, L1, L2, MinMaxのうち1つ.</param>
        /// <param name="mask">操作マスク．特定の配列要素のみを正規化するためのマスク．</param>
#else
        /// <summary>
        /// Normalizes array to a certain norm or value range
        /// </summary>
        /// <param name="dst">The output array; in-place operation is supported. </param>
        /// <param name="a">The minimum/maximum value of the output array or the norm of output array. </param>
        /// <param name="b">The maximum/minimum value of the output array. </param>
        /// <param name="normType">The normalization type.</param>
        /// <param name="mask">The operation mask. Makes the function consider and normalize only certain array elements. </param>
#endif
        public void Normalize(CvArr dst, double a, double b, NormType normType, CvArr mask)
        {
             Cv.Normalize(this, dst, a, b, normType, mask);
        }
        #endregion
        #region Not
#if LANG_JP
        /// <summary>
        /// 各配列要素のビット単位の反転を行う
        /// </summary>
        /// <param name="dst">出力配列</param>
#else
        /// <summary>
        /// Performs per-element bit-wise inversion of array elements
        /// </summary>
        /// <param name="dst">The destination array. </param>
#endif
        public void Not(CvArr dst)
        {
            Cv.Not(this, dst);
        }
        #endregion
        #region Or
#if LANG_JP
        /// <summary>
        /// 二つの配列の要素ごとの論理和（OR）を計算する. 
        /// dst(I)=src1(I)|src2(I)
        /// </summary>
        /// <param name="src2">2番目の入力配列</param>
        /// <param name="dst">出力配列</param>
#else
        /// <summary>
        /// Calculates per-element bit-wise disjunction of two arrays
        /// </summary>
        /// <param name="src2">The second source array. </param>
        /// <param name="dst">The destination array. </param>
#endif
        public void Or(CvArr src2, CvArr dst)
        {
            Cv.Or(this, src2, dst);
        }
#if LANG_JP
        /// <summary>
        /// 二つの配列の要素ごとの論理和（OR）を計算する. 
        /// dst(I)=src1(I)|src2(I) [mask(I)!=0の場合]
        /// </summary>
        /// <param name="src2">2番目の入力配列</param>
        /// <param name="dst">出力配列</param>
        /// <param name="mask">処理マスク．8ビットシングルチャンネル配列（出力配列のどの要素が変更されるかを指定する）． </param>
#else
        /// <summary>
        /// Calculates per-element bit-wise disjunction of two arrays
        /// </summary>
        /// <param name="src2">The second source array. </param>
        /// <param name="dst">The destination array. </param>
        /// <param name="mask">Operation mask, 8-bit single channel array; specifies elements of destination array to be changed. </param>
#endif
        public void Or(CvArr src2, CvArr dst, CvArr mask)
        {
            Cv.Or(this, src2, dst, mask);
        }
        #endregion
        #region OrS
#if LANG_JP
        /// <summary>
        /// 配列の各要素とスカラーとのビット単位の論理和(OR)を計算する.
        /// 実際の計算の前に，スカラーは配列と同じタイプに変換される．浮動小数点型配列の場合，それらのビット表現が処理に使われる．
        /// dst(I)=src(I)|value
        /// </summary>
        /// <param name="value">処理に用いるスカラー</param>
        /// <param name="dst">出力配列</param>
#else
        /// <summary>
        /// Calculates per-element bit-wise disjunction of array and scalar
        /// </summary>
        /// <param name="value">Scalar to use in the operation. </param>
        /// <param name="dst">The destination array. </param>
#endif
        public void OrS(CvScalar value, CvArr dst)
        {
            Cv.OrS(this, value, dst);
        }
#if LANG_JP
        /// <summary>
        /// 配列の各要素とスカラーとのビット単位の論理和(OR)を計算する. 
        /// 実際の計算の前に，スカラーは配列と同じタイプに変換される．浮動小数点型配列の場合，それらのビット表現が処理に使われる．
        /// dst(I)=src(I)|value [mask(I)!=0の場合]
        /// </summary>
        /// <param name="value">処理に用いるスカラー</param>
        /// <param name="dst">出力配列</param>
        /// <param name="mask">処理マスク．8ビットシングルチャンネル配列（出力配列のどの要素が変更されるかを指定する）．</param>
#else
        /// <summary>
        /// Calculates per-element bit-wise disjunction of array and scalar
        /// </summary>
        /// <param name="value">Scalar to use in the operation. </param>
        /// <param name="dst">The destination array. </param>
        /// <param name="mask">Operation mask, 8-bit single channel array; specifies elements of destination array to be changed. </param>
#endif
        public void OrS(CvScalar value, CvArr dst, CvArr mask)
        {
            Cv.OrS(this, value, dst, mask);
        }
        #endregion
        #region PerspectiveTransform
#if LANG_JP
        /// <summary>
        /// ベクトルの透視投影変換を行う
        /// </summary>
        /// <param name="dst">3チャンネルの浮動小数点型出力配列</param>
        /// <param name="mat">3×3 または 4×4 の変換行列</param>
#else
        /// <summary>
        /// Performs perspective matrix transform of vector array
        /// </summary>
        /// <param name="dst">The destination three-channel floating-point array. </param>
        /// <param name="mat">3×3 or 4×4 transformation matrix. </param>
#endif
        public void PerspectiveTransform(CvArr dst, CvMat mat)
        {
            Cv.PerspectiveTransform(this, dst, mat);
        }
        #endregion
        #region PointPolygonTest
#if LANG_JP
        /// <summary>
        /// 点と輪郭の関係を調べる
        /// </summary>
        /// <param name="pt">入力輪郭に対して調べる点</param>
        /// <param name="measureDist">非0の場合, この関数は与えた点に最も近い輪郭までの距離を求める.</param>
        /// <returns>点が輪郭の内側にあるか，外側にあるか，輪郭上に乗っている（あるいは，頂点と一致している）かを判別し，それぞれの場合に応じて正か負か0を返す．
        /// measure_dist=0の場合，戻り値はそれぞれ+1，-1，0である． measure_dist≠0の場合，点と最近傍輪郭までの符号付きの距離を返す．</returns>
#else
        /// <summary>
        /// Point in contour test
        /// </summary>
        /// <param name="pt">The point tested against the contour.</param>
        /// <param name="measureDist">If it is true, the function estimates distance from the point to the nearest contour edge.</param>
        /// <returns>The function cvPointPolygonTest determines whether the point is inside contour, outside, or lies on an edge (or coinsides with a vertex). It returns positive, negative or zero value, correspondingly. When measure_dist=0, the return value is +1, -1 and 0, respectively. When measure_dist≠0, it is a signed distance between the point and the nearest contour edge.</returns> 
#endif
        public double PointPolygonTest(CvPoint2D32f pt, bool measureDist)
        {
            return Cv.PointPolygonTest(this, pt, measureDist);
        }
        #endregion
        #region PolyLine
#if LANG_JP
        /// <summary>
        /// ポリライン（枠だけのポリゴン）を描画する
        /// </summary>
        /// <param name="pts">ポリラインの配列の配列</param>
        /// <param name="isClosed">ポリラインを閉じるかどうかを指定する．閉じる場合，それぞれの領域の最後の頂点と最初の頂点を結ぶ線分を描画する． </param>
        /// <param name="color">線の色</param>
#else
        /// <summary>
        /// Draws simple or thick polygons
        /// </summary>
        /// <param name="pts">Array of pointers to polylines. </param>
        /// <param name="isClosed">Indicates whether the polylines must be drawn closed. If closed, the function draws the line from the last vertex of every contour to the first vertex. </param>
        /// <param name="color">Polyline color. </param>
#endif
        public void PolyLine(CvPoint[][] pts, bool isClosed, CvScalar color)
        {
            Cv.PolyLine(this, pts, isClosed, color);
        }
#if LANG_JP
        /// <summary>
        /// ポリライン（枠だけのポリゴン）を描画する
        /// </summary>
        /// <param name="pts">ポリラインの配列の配列</param>
        /// <param name="isClosed">ポリラインを閉じるかどうかを指定する．閉じる場合，それぞれの領域の最後の頂点と最初の頂点を結ぶ線分を描画する． </param>
        /// <param name="color">線の色</param>
        /// <param name="thickness">線の太さ</param>
#else
        /// <summary>
        /// Draws simple or thick polygons
        /// </summary>
        /// <param name="pts">Array of pointers to polylines. </param>
        /// <param name="isClosed">Indicates whether the polylines must be drawn closed. If closed, the function draws the line from the last vertex of every contour to the first vertex. </param>
        /// <param name="color">Polyline color. </param>
        /// <param name="thickness">Thickness of the polyline edges. </param>
#endif
        public void PolyLine(CvPoint[][] pts, bool isClosed, CvScalar color, int thickness)
        {
            Cv.PolyLine(this, pts, isClosed, color, thickness);
        }
#if LANG_JP
        /// <summary>
        /// ポリライン（枠だけのポリゴン）を描画する
        /// </summary>
        /// <param name="pts">ポリラインの配列の配列</param>
        /// <param name="isClosed">ポリラインを閉じるかどうかを指定する．閉じる場合，それぞれの領域の最後の頂点と最初の頂点を結ぶ線分を描画する． </param>
        /// <param name="color">線の色</param>
        /// <param name="thickness">線の太さ</param>
        /// <param name="lineType">線の種類</param>
#else
        /// <summary>
        /// Draws simple or thick polygons
        /// </summary>
        /// <param name="pts">Array of pointers to polylines. </param>
        /// <param name="isClosed">Indicates whether the polylines must be drawn closed. If closed, the function draws the line from the last vertex of every contour to the first vertex. </param>
        /// <param name="color">Polyline color. </param>
        /// <param name="thickness">Thickness of the polyline edges. </param>
        /// <param name="lineType">Type of the line segments.</param>
#endif
        public void PolyLine(CvPoint[][] pts, bool isClosed, CvScalar color, int thickness, LineType lineType)
        {
            Cv.PolyLine(this, pts, isClosed, color, thickness, lineType);
        }
#if LANG_JP
        /// <summary>
        /// ポリライン（枠だけのポリゴン）を描画する
        /// </summary>
        /// <param name="pts">ポリラインの配列の配列</param>
        /// <param name="isClosed">ポリラインを閉じるかどうかを指定する．閉じる場合，それぞれの領域の最後の頂点と最初の頂点を結ぶ線分を描画する． </param>
        /// <param name="color">線の色</param>
        /// <param name="thickness">線の太さ</param>
        /// <param name="lineType">線の種類</param>
        /// <param name="shift">頂点座標の小数点以下の桁を表すビット数</param>
#else
        /// <summary>
        /// Draws simple or thick polygons
        /// </summary>
        /// <param name="pts">Array of pointers to polylines. </param>
        /// <param name="isClosed">Indicates whether the polylines must be drawn closed. If closed, the function draws the line from the last vertex of every contour to the first vertex. </param>
        /// <param name="color">Polyline color. </param>
        /// <param name="thickness">Thickness of the polyline edges. </param>
        /// <param name="lineType">Type of the line segments.</param>
        /// <param name="shift">Number of fractional bits in the vertex coordinates. </param>
#endif
        public void PolyLine(CvPoint[][] pts, bool isClosed, CvScalar color, int thickness, LineType lineType, int shift)
        {
            Cv.PolyLine(this, pts, isClosed, color, thickness, lineType, shift);
        }
#if LANG_JP
        /// <summary>
        /// ポリライン（枠だけのポリゴン）を描画する
        /// </summary>
        /// <param name="pts">ポリラインの配列の配列</param>
        /// <param name="isClosed">ポリラインを閉じるかどうかを指定する．閉じる場合，それぞれの領域の最後の頂点と最初の頂点を結ぶ線分を描画する． </param>
        /// <param name="color">線の色</param>
#else
        /// <summary>
        /// Draws simple or thick polygons
        /// </summary>
        /// <param name="pts">Array of pointers to polylines. </param>
        /// <param name="isClosed">Indicates whether the polylines must be drawn closed. If closed, the function draws the line from the last vertex of every contour to the first vertex. </param>
        /// <param name="color">Polyline color. </param>
#endif
        public void DrawPolyLine(CvPoint[][] pts, bool isClosed, CvScalar color)
        {
            Cv.DrawPolyLine(this, pts, isClosed, color);
        }
#if LANG_JP
        /// <summary>
        /// ポリライン（枠だけのポリゴン）を描画する
        /// </summary>
        /// <param name="pts">ポリラインの配列の配列</param>
        /// <param name="isClosed">ポリラインを閉じるかどうかを指定する．閉じる場合，それぞれの領域の最後の頂点と最初の頂点を結ぶ線分を描画する． </param>
        /// <param name="color">線の色</param>
        /// <param name="thickness">線の太さ</param>
#else
        /// <summary>
        /// Draws simple or thick polygons
        /// </summary>
        /// <param name="pts">Array of pointers to polylines. </param>
        /// <param name="isClosed">Indicates whether the polylines must be drawn closed. If closed, the function draws the line from the last vertex of every contour to the first vertex. </param>
        /// <param name="color">Polyline color. </param>
        /// <param name="thickness">Thickness of the polyline edges. </param>
#endif
        public void DrawPolyLine(CvPoint[][] pts, bool isClosed, CvScalar color, int thickness)
        {
            Cv.DrawPolyLine(this, pts, isClosed, color, thickness);
        }
#if LANG_JP
        /// <summary>
        /// ポリライン（枠だけのポリゴン）を描画する
        /// </summary>
        /// <param name="pts">ポリラインの配列の配列</param>
        /// <param name="isClosed">ポリラインを閉じるかどうかを指定する．閉じる場合，それぞれの領域の最後の頂点と最初の頂点を結ぶ線分を描画する． </param>
        /// <param name="color">線の色</param>
        /// <param name="thickness">線の太さ</param>
        /// <param name="lineType">線の種類</param>
#else
        /// <summary>
        /// Draws simple or thick polygons
        /// </summary>
        /// <param name="pts">Array of pointers to polylines. </param>
        /// <param name="isClosed">Indicates whether the polylines must be drawn closed. If closed, the function draws the line from the last vertex of every contour to the first vertex. </param>
        /// <param name="color">Polyline color. </param>
        /// <param name="thickness">Thickness of the polyline edges. </param>
        /// <param name="lineType">Type of the line segments.</param>
#endif
        public void DrawPolyLine(CvPoint[][] pts, bool isClosed, CvScalar color, int thickness, LineType lineType)
        {
            Cv.DrawPolyLine(this, pts, isClosed, color, thickness, lineType);
        }
#if LANG_JP
        /// <summary>
        /// ポリライン（枠だけのポリゴン）を描画する
        /// </summary>
        /// <param name="pts">ポリラインの配列の配列</param>
        /// <param name="isClosed">ポリラインを閉じるかどうかを指定する．閉じる場合，それぞれの領域の最後の頂点と最初の頂点を結ぶ線分を描画する． </param>
        /// <param name="color">線の色</param>
        /// <param name="thickness">線の太さ</param>
        /// <param name="lineType">線の種類</param>
        /// <param name="shift">頂点座標の小数点以下の桁を表すビット数</param>
#else
        /// <summary>
        /// Draws simple or thick polygons
        /// </summary>
        /// <param name="pts">Array of pointers to polylines. </param>
        /// <param name="isClosed">Indicates whether the polylines must be drawn closed. If closed, the function draws the line from the last vertex of every contour to the first vertex. </param>
        /// <param name="color">Polyline color. </param>
        /// <param name="thickness">Thickness of the polyline edges. </param>
        /// <param name="lineType">Type of the line segments.</param>
        /// <param name="shift">Number of fractional bits in the vertex coordinates. </param>
#endif
        public void DrawPolyLine(CvPoint[][] pts, bool isClosed, CvScalar color, int thickness, LineType lineType, int shift)
        {
            Cv.DrawPolyLine(this, pts, isClosed, color, thickness, lineType, shift);
        }
        #endregion
        #region Pow
#if LANG_JP
        /// <summary>
        /// すべての配列要素を累乗する.
        /// </summary>
        /// <param name="dst">出力配列．入力と同じタイプでなければならない.</param>
        /// <param name="power">累乗の指数</param>
#else
        /// <summary>
        /// Raises every array element to power
        /// </summary>
        /// <param name="dst">The destination array, should be the same type as the source. </param>
        /// <param name="power">The exponent of power. </param>
#endif
        public void Pow(CvArr dst, double power)
        {
            Cv.Pow(this, dst, power);
        }
        #endregion
        #region PreCornerDetect
#if LANG_JP
        /// <summary>
        /// コーナー検出のために，画像ブロックの最小固有値を計算する. 
        /// すべてのピクセルについて，隣接ブロックにおける導関数の共変動行列の最小固有値だけを求める関数である．
        /// </summary>
        /// <param name="corners">コーナーの候補を保存する画像</param>
#else
        /// <summary>
        /// Calculates feature map for corner detection
        /// </summary>
        /// <param name="corners">Image to store the corner candidates. </param>
#endif
        public void PreCornerDetect(CvArr corners)
        {
            Cv.PreCornerDetect(this, corners);
        }
#if LANG_JP
        /// <summary>
        /// コーナー検出のために，画像ブロックの最小固有値を計算する. 
        /// すべてのピクセルについて，隣接ブロックにおける導関数の共変動行列の最小固有値だけを求める関数である．
        /// </summary>
        /// <param name="corners">コーナーの候補を保存する画像</param>
        /// <param name="apertureSize">Sobel演算子のアパーチャサイズ(cvSobel参照)．</param>
#else
        /// <summary>
        /// Calculates feature map for corner detection
        /// </summary>
        /// <param name="corners">Image to store the corner candidates. </param>
        /// <param name="apertureSize">Aperture parameter for Sobel operator.</param>
#endif
        public void PreCornerDetect(CvArr corners, ApertureSize apertureSize)
        {
            Cv.PreCornerDetect(this, corners, apertureSize);
        }
        #endregion
        #region Ptr*D
#if LANG_JP
        /// <summary>
        /// 特定の配列要素へのポインタを返す．
        /// </summary>
        /// <param name="idx0">要素インデックスの，0を基準とした第1成分．</param>
        /// <returns>指定した要素のポインタ</returns>
#else
        /// <summary>
        /// Return pointer to the particular array element
        /// </summary>
        /// <param name="idx0">The first zero-based component of the element index </param>
        /// <returns>pointer to the particular array element</returns>
#endif
        public IntPtr Ptr1D(int idx0)
        {
            return Cv.Ptr1D(this, idx0);
        }
#if LANG_JP
        /// <summary>
        /// 特定の配列要素へのポインタを返す．
        /// </summary>
        /// <param name="idx0">要素インデックスの，0を基準とした第1成分．</param>
        /// <param name="type">行列要素のタイプ</param>
        /// <returns>指定した要素のポインタ</returns>
#else
        /// <summary>
        /// Return pointer to the particular array element
        /// </summary>
        /// <param name="idx0">The first zero-based component of the element index </param>
        /// <param name="type">Type of matrix elements </param>
        /// <returns>pointer to the particular array element</returns>
#endif
        public IntPtr Ptr1D(int idx0, out MatrixType type)
        {
            return Cv.Ptr1D(this, idx0, out type);
        }
#if LANG_JP
        /// <summary>
        /// 特定の配列要素へのポインタを返す．
        /// </summary>
        /// <param name="idx0">要素インデックスの，0を基準とした第1成分．</param>
        /// <param name="idx1">要素インデックスの，0を基準とした第2成分．</param>
        /// <returns>指定した要素のポインタ</returns>
#else
        /// <summary>
        /// Return pointer to the particular array element
        /// </summary>
        /// <param name="idx0">The first zero-based component of the element index </param>
        /// <param name="idx1">The second zero-based component of the element index </param>
        /// <returns>pointer to the particular array element</returns>
#endif
        public IntPtr Ptr2D(int idx0, int idx1)
        {
            return Cv.Ptr2D(this, idx0, idx1);
        }
#if LANG_JP
        /// <summary>
        /// 特定の配列要素へのポインタを返す．
        /// </summary>
        /// <param name="idx0">要素インデックスの，0を基準とした第1成分．</param>
        /// <param name="idx1">要素インデックスの，0を基準とした第2成分．</param>
        /// <param name="type">行列要素のタイプ</param>
        /// <returns>指定した要素のポインタ</returns>
#else
        /// <summary>
        /// Return pointer to the particular array element
        /// </summary>
        /// <param name="idx0">The first zero-based component of the element index </param>
        /// <param name="idx1">The second zero-based component of the element index </param>
        /// <param name="type">Type of matrix elements </param>
        /// <returns>pointer to the particular array element</returns>
#endif
        public IntPtr Ptr2D(int idx0, int idx1, out MatrixType type)
        {
            return Cv.Ptr2D(this, idx0, idx1, out type);
        }
#if LANG_JP
        /// <summary>
        /// 特定の配列要素へのポインタを返す．
        /// </summary>
        /// <param name="idx0">要素インデックスの，0を基準とした第1成分．</param>
        /// <param name="idx1">要素インデックスの，0を基準とした第2成分．</param>
        /// <param name="idx2">要素インデックスの，0を基準とした第3成分．</param>
        /// <returns>指定した要素のポインタ</returns>
#else
        /// <summary>
        /// Return pointer to the particular array element
        /// </summary>
        /// <param name="idx0">The first zero-based component of the element index </param>
        /// <param name="idx1">The second zero-based component of the element index </param>
        /// <param name="idx2">The third zero-based component of the element index </param>
        /// <returns>pointer to the particular array element</returns>
#endif
        public IntPtr Ptr3D(int idx0, int idx1, int idx2)
        {
            return Cv.Ptr3D(this, idx0, idx1, idx2);
        }
#if LANG_JP
        /// <summary>
        /// 特定の配列要素へのポインタを返す．
        /// </summary>
        /// <param name="idx0">要素インデックスの，0を基準とした第1成分．</param>
        /// <param name="idx1">要素インデックスの，0を基準とした第2成分．</param>
        /// <param name="idx2">要素インデックスの，0を基準とした第3成分．</param>
        /// <param name="type">行列要素のタイプ</param>
        /// <returns>指定した要素のポインタ</returns>
#else
        /// <summary>
        /// Return pointer to the particular array element
        /// </summary>
        /// <param name="idx0">The first zero-based component of the element index </param>
        /// <param name="idx1">The second zero-based component of the element index </param>
        /// <param name="idx2">The third zero-based component of the element index </param>
        /// <param name="type">Type of matrix elements </param>
        /// <returns>pointer to the particular array element</returns>
#endif
        public IntPtr Ptr3D(int idx0, int idx1, int idx2, out MatrixType type)
        {
            return Cv.Ptr3D(this, idx0, idx1, idx2, out type);
        }
#if LANG_JP
        /// <summary>
        /// 特定の配列要素へのポインタを返す．
        /// </summary>
        /// <param name="idx">要素インデックスの配列(可変長引数)</param>
        /// <returns>指定した要素のポインタ</returns>
#else
        /// <summary>
        /// Return pointer to the particular array element
        /// </summary>
        /// <param name="idx">Array of the element indices </param>
        /// <returns>pointer to the particular array element</returns>
#endif
        public IntPtr PtrND(params int[] idx)
        {
            return Cv.PtrND(this, idx);
        }
#if LANG_JP
        /// <summary>
        /// 特定の配列要素へのポインタを返す．
        /// </summary>
        /// <param name="idx">要素インデックスの配列</param>
        /// <param name="type">行列要素のタイプ</param>
        /// <returns>指定した要素のポインタ</returns>
#else
        /// <summary>
        /// Return pointer to the particular array element
        /// </summary>
        /// <param name="idx">Array of the element indices </param>
        /// <param name="type">Type of matrix elements </param>
        /// <returns>pointer to the particular array element</returns>
#endif
        public IntPtr PtrND(int[] idx, out MatrixType type)
        {
            return Cv.PtrND(this, idx, out type);
        }
#if LANG_JP
        /// <summary>
        /// 特定の配列要素へのポインタを返す．
        /// </summary>
        /// <param name="idx">要素インデックスの配列</param>
        /// <param name="type">行列要素のタイプ</param>
        /// <param name="createNode">疎な行列に対するオプションの入力パラメータ. trueの場合，指定された要素が存在しないときは要素を生成する.</param>
        /// <returns>指定した要素のポインタ</returns>
#else
        /// <summary>
        /// Return pointer to the particular array element
        /// </summary>
        /// <param name="idx">Array of the element indices </param>
        /// <param name="type">Type of matrix elements </param>
        /// <param name="createNode">Optional input parameter for sparse matrices. Non-zero value of the parameter means that the requested element is created if it does not exist already. </param>
        /// <returns>pointer to the particular array element</returns>
#endif
        public IntPtr PtrND(int[] idx, out MatrixType type, bool createNode)
        {
            return Cv.PtrND(this, idx, out type, createNode);
        }
#if LANG_JP
        /// <summary>
        /// 特定の配列要素へのポインタを返す．
        /// </summary>
        /// <param name="idx">要素インデックスの配列</param>
        /// <param name="type">行列要素のタイプ</param>
        /// <param name="createNode">疎な行列に対するオプションの入力パラメータ. trueの場合，指定された要素が存在しないときは要素を生成する.</param>
        /// <param name="precalcHashval">疎な行列に対するオプションの入力パラメータ．nullでないとき，関数はノードのハッシュ値を再計算せず，指定された場所から取ってくる． これにより，ペアワイズ操作の速度が向上する．</param>
        /// <returns>指定した要素のポインタ</returns>
#else
        /// <summary>
        /// Return pointer to the particular array element
        /// </summary>
        /// <param name="idx">Array of the element indices </param>
        /// <param name="type">Type of matrix elements </param>
        /// <param name="createNode">Optional input parameter for sparse matrices. Non-zero value of the parameter means that the requested element is created if it does not exist already. </param>
        /// <param name="precalcHashval">Optional input parameter for sparse matrices. If the pointer is not NULL, the function does not recalculate the node hash value, but takes it from the specified location. It is useful for speeding up pair-wise operations</param>
        /// <returns>pointer to the particular array element</returns>
#endif
        public IntPtr PtrND(int[] idx, out MatrixType type, bool createNode, uint? precalcHashval)
        {
            return Cv.PtrND(this, idx, out type, createNode, precalcHashval);
        }
        #endregion
        #region PutText
#if LANG_JP
        /// <summary>
        /// 文字列を描画する
        /// </summary>
        /// <param name="text">描画する文字列</param>
        /// <param name="org">最初の文字の左下の座標</param>
        /// <param name="font">フォント構造体</param>
        /// <param name="color">文字の色</param>
#else
        /// <summary>
        /// Draws text string
        /// </summary>
        /// <param name="text">String to print. </param>
        /// <param name="org">Coordinates of the bottom-left corner of the first letter. </param>
        /// <param name="font">Pointer to the font structure. </param>
        /// <param name="color">Text color. </param>
#endif
        public void PutText(string text, CvPoint org, CvFont font, CvScalar color)
        {
            Cv.PutText(this, text, org, font, color);
        }
        #endregion        
        #region PyrDown
#if LANG_JP
        /// <summary>
        /// 画像のダウンサンプリングを行う
        /// </summary>
        /// <param name="dst">出力画像．入力画像の1/2の幅と高さ．</param>
#else
        /// <summary>
        /// Downsamples image.
        /// </summary>
        /// <param name="dst">The destination image, should have 2x smaller width and height than the source. </param>
#endif
        public void PyrDown(CvArr dst)
        {
            Cv.PyrDown(this, dst);
        }
#if LANG_JP
        /// <summary>
        /// 画像のダウンサンプリングを行う
        /// </summary>
        /// <param name="dst">出力画像．入力画像の1/2の幅と高さ．</param>
        /// <param name="filter">畳み込みに使うフィルタ．現在は CV_GAUSSIAN_5x5 のみサポート．</param>
#else
        /// <summary>
        /// Downsamples image.
        /// </summary>
        /// <param name="dst">The destination image, should have 2x smaller width and height than the source. </param>
        /// <param name="filter">Type of the filter used for convolution; only CV_GAUSSIAN_5x5 is currently supported. </param>
#endif
        public void PyrDown(CvArr dst, CvFilter filter)
        {
             Cv.PyrDown(this, dst, filter);
        }
        #endregion
        #region PyrMeanShiftFiltering
#if LANG_JP
        /// <summary>
        /// 平均値シフト法による画像のセグメント化アルゴリズムのフィルタリング部分を実装する．
        /// </summary>
        /// <param name="dst">出力画像．入力画像と同じフォーマット，同じサイズ</param>
        /// <param name="sp">空間ウィンドウの半径</param>
        /// <param name="sr">色空間ウィンドウの半径</param>
#else
        /// <summary>
        /// Does meanshift image segmentation.
        /// </summary>
        /// <param name="dst">The destination image of the same format and the same size as the source. </param>
        /// <param name="sp">The spatial window radius. </param>
        /// <param name="sr">The color window radius. </param>
#endif
        public void PyrMeanShiftFiltering(CvArr dst, double sp, double sr)
        {
            Cv.PyrMeanShiftFiltering(this, dst, sp, sr);
        }
#if LANG_JP
        /// <summary>
        /// 平均値シフト法による画像のセグメント化アルゴリズムのフィルタリング部分を実装する．
        /// </summary>
        /// <param name="dst">出力画像．入力画像と同じフォーマット，同じサイズ</param>
        /// <param name="sp">空間ウィンドウの半径</param>
        /// <param name="sr">色空間ウィンドウの半径</param>
        /// <param name="maxLevel">セグメント化のためのピラミッドの最大レベル</param>
#else
        /// <summary>
        /// Does meanshift image segmentation.
        /// </summary>
        /// <param name="dst">The destination image of the same format and the same size as the source. </param>
        /// <param name="sp">The spatial window radius. </param>
        /// <param name="sr">The color window radius. </param>
        /// <param name="maxLevel">Maximum level of the pyramid for the segmentation. </param>
#endif
        public void PyrMeanShiftFiltering(CvArr dst, double sp, double sr, int maxLevel)
        {
            Cv.PyrMeanShiftFiltering(this, dst, sp, sr, maxLevel);
        }
#if LANG_JP
        /// <summary>
        /// 平均値シフト法による画像のセグメント化アルゴリズムのフィルタリング部分を実装する．
        /// </summary>
        /// <param name="dst">出力画像．入力画像と同じフォーマット，同じサイズ</param>
        /// <param name="sp">空間ウィンドウの半径</param>
        /// <param name="sr">色空間ウィンドウの半径</param>
        /// <param name="maxLevel">セグメント化のためのピラミッドの最大レベル</param>
        /// <param name="termcrit">終了条件．平均値シフトをいつまで繰り返すか</param>
#else
        /// <summary>
        /// Does meanshift image segmentation.
        /// </summary>
        /// <param name="dst">The destination image of the same format and the same size as the source. </param>
        /// <param name="sp">The spatial window radius. </param>
        /// <param name="sr">The color window radius. </param>
        /// <param name="maxLevel">Maximum level of the pyramid for the segmentation. </param>
        /// <param name="termcrit">Termination criteria: when to stop meanshift iterations. </param>
#endif
        public void PyrMeanShiftFiltering(CvArr dst, double sp, double sr, int maxLevel, CvTermCriteria termcrit)
        {
            Cv.PyrMeanShiftFiltering(this, dst, sp, sr, maxLevel, termcrit);
        }
        #endregion
        #region PyrUp
#if LANG_JP
        /// <summary>
        /// 画像のアップサンプリングを行う
        /// </summary>
        /// <param name="dst">出力画像．入力画像の1/2の幅と高さ．</param>
#else
        /// <summary>
        /// Upsamples image.
        /// </summary>
        /// <param name="dst">The destination image, should have 2x smaller width and height than the source. </param>
#endif
        public void PyrUp(CvArr dst)
        {
            Cv.PyrUp(this, dst);
        }
#if LANG_JP
        /// <summary>
        /// 画像のアップサンプリングを行う
        /// </summary>
        /// <param name="dst">出力画像．入力画像の1/2の幅と高さ．</param>
        /// <param name="filter">畳み込みに使うフィルタ．現在は CV_GAUSSIAN_5x5 のみサポート．</param>
#else
        /// <summary>
        /// Upsamples image.
        /// </summary>
        /// <param name="dst">The destination image, should have 2x smaller width and height than the source. </param>
        /// <param name="filter">Type of the filter used for convolution; only CV_GAUSSIAN_5x5 is currently supported. </param>
#endif
        public void PyrUp(CvArr dst, CvFilter filter)
        {
            Cv.PyrUp(this, dst, filter);
        }
        #endregion
        #region RandShuffle
#if LANG_JP
        /// <summary>
        /// ランダムに選ばれた配列要素ペアの入れ替えを反復することにより行列をシャッフルする（マルチチャンネル配列の場合，それぞれの要素は複数の成分を含む）．
        /// </summary>
#else
        /// <summary>
        /// Randomly shuffles the array elements
        /// </summary>
#endif
        public void RandShuffle()
        {
            Cv.RandShuffle(this);
        }
#if LANG_JP
        /// <summary>
        /// ランダムに選ばれた配列要素ペアの入れ替えを反復することにより行列をシャッフルする（マルチチャンネル配列の場合，それぞれの要素は複数の成分を含む）．
        /// </summary>
        /// <param name="rng">要素のシャッフルで用いられる Random Number Generator．ポインタがnullの場合，一時的なRNGが生成され，利用される．</param>
#else
        /// <summary>
        /// Randomly shuffles the array elements
        /// </summary>
        /// <param name="rng">The Random Number Generator  used to shuffle the elements. When the pointer is null, a temporary RNG will be created and used. </param>
#endif
        public void RandShuffle(CvRNG rng)
        {
            Cv.RandShuffle(this, rng);
        }
#if LANG_JP
        /// <summary>
        /// ランダムに選ばれた配列要素ペアの入れ替えを反復することにより行列をシャッフルする（マルチチャンネル配列の場合，それぞれの要素は複数の成分を含む）．
        /// </summary>
        /// <param name="rng">要素のシャッフルで用いられる Random Number Generator．ポインタがnullの場合，一時的なRNGが生成され，利用される．</param>
        /// <param name="iterFactor">シャッフルの強さを指定するパラメータ.</param>
#else
        /// <summary>
        /// Randomly shuffles the array elements
        /// </summary>
        /// <param name="rng">The Random Number Generator  used to shuffle the elements. When the pointer is null, a temporary RNG will be created and used. </param>
        /// <param name="iterFactor">The relative parameter that characterizes intensity of the shuffling performed. </param>
#endif
        public void RandShuffle(CvRNG rng, double iterFactor)
        {
            Cv.RandShuffle(this, rng, iterFactor);
        }
        #endregion
        #region Range
#if LANG_JP
        /// <summary>
        /// 与えられた範囲の数で行列を埋める．次のように行列を初期化する．
        /// arr(i,j) = (End-Start) * (i*cols(arr)+j) / (cols(arr)*rows(arr)) 
        /// </summary>
        /// <param name="start">範囲の下限（範囲に含まれる）</param>
        /// <param name="end">範囲の上限（範囲に含まれない）</param>
#else
        /// <summary>
        /// Fills matrix with given range of numbers as following:
        /// arr(i,j) = (end-start) * (i*cols(arr)+j) / (cols(arr)*rows(arr))
        /// </summary>
        /// <param name="start">The lower inclusive boundary of the range. </param>
        /// <param name="end">The upper exclusive boundary of the range. </param>
#endif
        public void Range(double start, double end)
        {
            Cv.Range(this, start, end);
        }
        #endregion
        #region Rectangle
#if LANG_JP
        /// <summary>
        /// 枠のみ，もしくは塗りつぶされた矩形を描画する
        /// </summary>
        /// <param name="pt1X">矩形の一つの頂点のx座標</param>
        /// <param name="pt1Y">矩形の一つの頂点のy座標</param>
        /// <param name="pt2X">矩形の反対側の頂点のx座標</param>
        /// <param name="pt2Y">矩形の反対側の頂点のy座標</param>
        /// <param name="color">線の色(RGB)，もしくは輝度(グレースケール画像).</param>
#else
        /// <summary>
        /// Draws simple, thick or filled rectangle
        /// </summary>
        /// <param name="pt1X">X-coordinate of the one of the rectangle vertices. </param>
        /// <param name="pt1Y">Y-coordinate of the one of the rectangle vertices. </param>
        /// <param name="pt2X">X-coordinate of the opposite rectangle vertex. </param>
        /// <param name="pt2Y">Y-coordinate of the opposite rectangle vertex. </param>
        /// <param name="color">Line color (RGB) or brightness (grayscale image). </param>
#endif
        public void Rectangle(int pt1X, int pt1Y, int pt2X, int pt2Y, CvScalar color)
        {
            Cv.Rectangle(this, pt1X, pt1Y, pt2X, pt2Y, color);
        }
#if LANG_JP
        /// <summary>
        /// 枠のみ，もしくは塗りつぶされた矩形を描画する
        /// </summary>
        /// <param name="pt1X">矩形の一つの頂点のx座標</param>
        /// <param name="pt1Y">矩形の一つの頂点のy座標</param>
        /// <param name="pt2X">矩形の反対側の頂点のx座標</param>
        /// <param name="pt2Y">矩形の反対側の頂点のy座標</param>
        /// <param name="color">線の色(RGB)，もしくは輝度(グレースケール画像).</param>
        /// <param name="thickness">矩形を描く線の太さ．負の値，例えばCV_FILLEDを指定した場合は塗りつぶされる．</param>
#else
        /// <summary>
        /// Draws simple, thick or filled rectangle
        /// </summary>
        /// <param name="pt1X">X-coordinate of the one of the rectangle vertices. </param>
        /// <param name="pt1Y">Y-coordinate of the one of the rectangle vertices. </param>
        /// <param name="pt2X">X-coordinate of the opposite rectangle vertex. </param>
        /// <param name="pt2Y">Y-coordinate of the opposite rectangle vertex. </param>
        /// <param name="color">Line color (RGB) or brightness (grayscale image). </param>
        /// <param name="thickness">Thickness of lines that make up the rectangle. Negative values, e.g. CV_FILLED, make the function to draw a filled rectangle. </param>
#endif
        public void Rectangle(int pt1X, int pt1Y, int pt2X, int pt2Y, CvScalar color, int thickness)
        {
            Cv.Rectangle(this, pt1X, pt1Y, pt2X, pt2Y, color, thickness);
        }
#if LANG_JP
        /// <summary>
        /// 枠のみ，もしくは塗りつぶされた矩形を描画する
        /// </summary>
        /// <param name="pt1X">矩形の一つの頂点のx座標</param>
        /// <param name="pt1Y">矩形の一つの頂点のy座標</param>
        /// <param name="pt2X">矩形の反対側の頂点のx座標</param>
        /// <param name="pt2Y">矩形の反対側の頂点のy座標</param>
        /// <param name="color">線の色(RGB)，もしくは輝度(グレースケール画像).</param>
        /// <param name="thickness">矩形を描く線の太さ．負の値，例えばCV_FILLEDを指定した場合は塗りつぶされる．</param>
        /// <param name="lineType">線の種類</param>
#else
        /// <summary>
        /// Draws simple, thick or filled rectangle
        /// </summary>
        /// <param name="pt1X">X-coordinate of the one of the rectangle vertices. </param>
        /// <param name="pt1Y">Y-coordinate of the one of the rectangle vertices. </param>
        /// <param name="pt2X">X-coordinate of the opposite rectangle vertex. </param>
        /// <param name="pt2Y">Y-coordinate of the opposite rectangle vertex. </param>
        /// <param name="color">Line color (RGB) or brightness (grayscale image). </param>
        /// <param name="thickness">Thickness of lines that make up the rectangle. Negative values, e.g. CV_FILLED, make the function to draw a filled rectangle. </param>
        /// <param name="lineType">Type of the line, see cvLine description. </param>
#endif
        public void Rectangle(int pt1X, int pt1Y, int pt2X, int pt2Y, CvScalar color, int thickness, LineType lineType)
        {
            Cv.Rectangle(this, pt1X, pt1Y, pt2X, pt2Y, color, thickness, lineType);
        }
#if LANG_JP
        /// <summary>
        /// 枠のみ，もしくは塗りつぶされた矩形を描画する
        /// </summary>
        /// <param name="pt1X">矩形の一つの頂点のx座標</param>
        /// <param name="pt1Y">矩形の一つの頂点のy座標</param>
        /// <param name="pt2X">矩形の反対側の頂点のx座標</param>
        /// <param name="pt2Y">矩形の反対側の頂点のy座標</param>
        /// <param name="color">線の色(RGB)，もしくは輝度(グレースケール画像).</param>
        /// <param name="thickness">矩形を描く線の太さ．負の値，例えばCV_FILLEDを指定した場合は塗りつぶされる．</param>
        /// <param name="lineType">線の種類</param>
        /// <param name="shift">座標の小数点以下の桁を表すビット数</param>
#else
        /// <summary>
        /// Draws simple, thick or filled rectangle
        /// </summary>
        /// <param name="pt1X">X-coordinate of the one of the rectangle vertices. </param>
        /// <param name="pt1Y">Y-coordinate of the one of the rectangle vertices. </param>
        /// <param name="pt2X">X-coordinate of the opposite rectangle vertex. </param>
        /// <param name="pt2Y">Y-coordinate of the opposite rectangle vertex. </param>
        /// <param name="color">Line color (RGB) or brightness (grayscale image). </param>
        /// <param name="thickness">Thickness of lines that make up the rectangle. Negative values, e.g. CV_FILLED, make the function to draw a filled rectangle. </param>
        /// <param name="lineType">Type of the line, see cvLine description. </param>
        /// <param name="shift">Number of fractional bits in the point coordinates. </param>
#endif
        public void Rectangle(int pt1X, int pt1Y, int pt2X, int pt2Y, CvScalar color, int thickness, LineType lineType, int shift)
        {
            Cv.Rectangle(this, pt1X, pt1Y, pt2X, pt2Y, color, thickness, lineType, shift);
        }

#if LANG_JP
        /// <summary>
        /// 枠のみ，もしくは塗りつぶされた矩形を描画する
        /// </summary>
        /// <param name="pt1">矩形の一つの頂点</param>
        /// <param name="pt2">矩形の反対側の頂点</param>
        /// <param name="color">線の色(RGB)，もしくは輝度(グレースケール画像).</param>
#else
        /// <summary>
        /// Draws simple, thick or filled rectangle
        /// </summary>
        /// <param name="pt1">One of the rectangle vertices. </param>
        /// <param name="pt2">Opposite rectangle vertex. </param>
        /// <param name="color">Line color (RGB) or brightness (grayscale image). </param>
#endif
        public void Rectangle(CvPoint pt1, CvPoint pt2, CvScalar color)
        {
            Cv.Rectangle(this, pt1, pt2, color);
        }
#if LANG_JP
        /// <summary>
        /// 枠のみ，もしくは塗りつぶされた矩形を描画する
        /// </summary>
        /// <param name="pt1">矩形の一つの頂点</param>
        /// <param name="pt2">矩形の反対側の頂点</param>
        /// <param name="color">線の色(RGB)，もしくは輝度(グレースケール画像).</param>
        /// <param name="thickness">矩形を描く線の太さ．負の値，例えばCV_FILLEDを指定した場合は塗りつぶされる.</param>
#else
        /// <summary>
        /// Draws simple, thick or filled rectangle
        /// </summary>
        /// <param name="pt1">One of the rectangle vertices. </param>
        /// <param name="pt2">Opposite rectangle vertex. </param>
        /// <param name="color">Line color (RGB) or brightness (grayscale image). </param>
        /// <param name="thickness">Thickness of lines that make up the rectangle. Negative values, e.g. CV_FILLED, make the function to draw a filled rectangle. </param>
#endif
        public void Rectangle(CvPoint pt1, CvPoint pt2, CvScalar color, int thickness)
        {
            Cv.Rectangle(this, pt1, pt2, color, thickness);
        }
#if LANG_JP
        /// <summary>
        /// 枠のみ，もしくは塗りつぶされた矩形を描画する
        /// </summary>
        /// <param name="pt1">矩形の一つの頂点</param>
        /// <param name="pt2">矩形の反対側の頂点</param>
        /// <param name="color">線の色(RGB)，もしくは輝度(グレースケール画像).</param>
        /// <param name="thickness">矩形を描く線の太さ．負の値，例えばCV_FILLEDを指定した場合は塗りつぶされる.</param>
        /// <param name="lineType">線の種類</param>
#else
        /// <summary>
        /// Draws simple, thick or filled rectangle
        /// </summary>
        /// <param name="pt1">One of the rectangle vertices. </param>
        /// <param name="pt2">Opposite rectangle vertex. </param>
        /// <param name="color">Line color (RGB) or brightness (grayscale image). </param>
        /// <param name="thickness">Thickness of lines that make up the rectangle. Negative values, e.g. CV_FILLED, make the function to draw a filled rectangle. </param>
        /// <param name="lineType">Type of the line, see cvLine description. </param>
#endif
        public void Rectangle(CvPoint pt1, CvPoint pt2, CvScalar color, int thickness, LineType lineType)
        {
            Cv.Rectangle(this, pt1, pt2, color, thickness, lineType);
        }
#if LANG_JP
        /// <summary>
        /// 枠のみ，もしくは塗りつぶされた矩形を描画する
        /// </summary>
        /// <param name="pt1">矩形の一つの頂点</param>
        /// <param name="pt2">矩形の反対側の頂点</param>
        /// <param name="color">線の色(RGB)，もしくは輝度(グレースケール画像).</param>
        /// <param name="thickness">矩形を描く線の太さ．負の値，例えばCV_FILLEDを指定した場合は塗りつぶされる．</param>
        /// <param name="lineType">線の種類</param>
        /// <param name="shift">座標の小数点以下の桁を表すビット数</param>
#else
        /// <summary>
        /// Draws simple, thick or filled rectangle
        /// </summary>
        /// <param name="pt1">One of the rectangle vertices. </param>
        /// <param name="pt2">Opposite rectangle vertex. </param>
        /// <param name="color">Line color (RGB) or brightness (grayscale image). </param>
        /// <param name="thickness">Thickness of lines that make up the rectangle. Negative values, e.g. CV_FILLED, make the function to draw a filled rectangle. </param>
        /// <param name="lineType">Type of the line, see cvLine description. </param>
        /// <param name="shift">Number of fractional bits in the point coordinates. </param>
#endif
        public void Rectangle(CvPoint pt1, CvPoint pt2, CvScalar color, int thickness, LineType lineType, int shift)
        {
            Cv.Rectangle(this, pt1, pt2, color, thickness, lineType, shift);
        }
#if LANG_JP
        /// <summary>
        /// 枠のみ，もしくは塗りつぶされた矩形を描画する
        /// </summary>
        /// <param name="rect">矩形</param>
        /// <param name="color">線の色(RGB)，もしくは輝度(グレースケール画像).</param>
#else
        /// <summary>
        /// Draws simple, thick or filled rectangle
        /// </summary>
        /// <param name="rect">Rectangle.</param>
        /// <param name="color">Line color (RGB) or brightness (grayscale image). </param>
#endif
        public void Rectangle(CvRect rect, CvScalar color)
        {
            Cv.Rectangle(this, rect, color);
        }
#if LANG_JP
        /// <summary>
        /// 枠のみ，もしくは塗りつぶされた矩形を描画する
        /// </summary>
        /// <param name="rect">矩形</param>
        /// <param name="color">線の色(RGB)，もしくは輝度(グレースケール画像).</param>
        /// <param name="thickness">矩形を描く線の太さ．負の値，例えばCV_FILLEDを指定した場合は塗りつぶされる．</param>
#else
        /// <summary>
        /// Draws simple, thick or filled rectangle
        /// </summary>
        /// <param name="rect">Rectangle.</param>
        /// <param name="color">Line color (RGB) or brightness (grayscale image). </param>
        /// <param name="thickness">Thickness of lines that make up the rectangle. Negative values, e.g. CV_FILLED, make the function to draw a filled rectangle. </param>
#endif
        public void Rectangle(CvRect rect, CvScalar color, int thickness)
        {
            Cv.Rectangle(this, rect, color, thickness);
        }
#if LANG_JP
        /// <summary>
        /// 枠のみ，もしくは塗りつぶされた矩形を描画する
        /// </summary>
        /// <param name="rect">矩形</param>
        /// <param name="color">線の色(RGB)，もしくは輝度(グレースケール画像).</param>
        /// <param name="thickness">矩形を描く線の太さ．負の値，例えばCV_FILLEDを指定した場合は塗りつぶされる．</param>
        /// <param name="lineType">線の種類</param>
#else
        /// <summary>
        /// Draws simple, thick or filled rectangle
        /// </summary>
        /// <param name="rect">Rectangle.</param>
        /// <param name="color">Line color (RGB) or brightness (grayscale image). </param>
        /// <param name="thickness">Thickness of lines that make up the rectangle. Negative values, e.g. CV_FILLED, make the function to draw a filled rectangle. </param>
        /// <param name="lineType">Type of the line, see cvLine description. </param>
#endif
        public void Rectangle(CvRect rect, CvScalar color, int thickness, LineType lineType)
        {
            Cv.Rectangle(this, rect, color, thickness, lineType);
        }
#if LANG_JP
        /// <summary>
        /// 枠のみ，もしくは塗りつぶされた矩形を描画する
        /// </summary>
        /// <param name="rect">矩形</param>
        /// <param name="color">線の色(RGB)，もしくは輝度(グレースケール画像).</param>
        /// <param name="thickness">矩形を描く線の太さ．負の値，例えばCV_FILLEDを指定した場合は塗りつぶされる．</param>
        /// <param name="lineType">線の種類</param>
        /// <param name="shift">座標の小数点以下の桁を表すビット数</param>
#else
        /// <summary>
        /// Draws simple, thick or filled rectangle
        /// </summary>
        /// <param name="rect">Rectangle.</param>
        /// <param name="color">Line color (RGB) or brightness (grayscale image). </param>
        /// <param name="thickness">Thickness of lines that make up the rectangle. Negative values, e.g. CV_FILLED, make the function to draw a filled rectangle. </param>
        /// <param name="lineType">Type of the line, see cvLine description. </param>
        /// <param name="shift">Number of fractional bits in the point coordinates. </param>
#endif
        public void Rectangle(CvRect rect, CvScalar color, int thickness, LineType lineType, int shift)
        {
            Cv.Rectangle(this, rect, color, thickness, lineType, shift);
        }
#if LANG_JP
        /// <summary>
        /// 枠のみ，もしくは塗りつぶされた矩形を描画する
        /// </summary>
        /// <param name="pt1X">矩形の一つの頂点のx座標</param>
        /// <param name="pt1Y">矩形の一つの頂点のy座標</param>
        /// <param name="pt2X">矩形の反対側の頂点のx座標</param>
        /// <param name="pt2Y">矩形の反対側の頂点のy座標</param>
        /// <param name="color">線の色(RGB)，もしくは輝度(グレースケール画像).</param>
#else
        /// <summary>
        /// Draws simple, thick or filled rectangle
        /// </summary>
        /// <param name="pt1X">X-coordinate of the one of the rectangle vertices. </param>
        /// <param name="pt1Y">Y-coordinate of the one of the rectangle vertices. </param>
        /// <param name="pt2X">X-coordinate of the opposite rectangle vertex. </param>
        /// <param name="pt2Y">Y-coordinate of the opposite rectangle vertex. </param>
        /// <param name="color">Line color (RGB) or brightness (grayscale image). </param>
#endif
        public void DrawRect(int pt1X, int pt1Y, int pt2X, int pt2Y, CvScalar color)
        {
            Cv.DrawRect(this, pt1X, pt1Y, pt2X, pt2Y, color);
        }
#if LANG_JP
        /// <summary>
        /// 枠のみ，もしくは塗りつぶされた矩形を描画する
        /// </summary>
        /// <param name="pt1X">矩形の一つの頂点のx座標</param>
        /// <param name="pt1Y">矩形の一つの頂点のy座標</param>
        /// <param name="pt2X">矩形の反対側の頂点のx座標</param>
        /// <param name="pt2Y">矩形の反対側の頂点のy座標</param>
        /// <param name="color">線の色(RGB)，もしくは輝度(グレースケール画像).</param>
        /// <param name="thickness">矩形を描く線の太さ．負の値，例えばCV_FILLEDを指定した場合は塗りつぶされる．</param>
#else
        /// <summary>
        /// Draws simple, thick or filled rectangle
        /// </summary>
        /// <param name="pt1X">X-coordinate of the one of the rectangle vertices. </param>
        /// <param name="pt1Y">Y-coordinate of the one of the rectangle vertices. </param>
        /// <param name="pt2X">X-coordinate of the opposite rectangle vertex. </param>
        /// <param name="pt2Y">Y-coordinate of the opposite rectangle vertex. </param>
        /// <param name="color">Line color (RGB) or brightness (grayscale image). </param>
        /// <param name="thickness">Thickness of lines that make up the rectangle. Negative values, e.g. CV_FILLED, make the function to draw a filled rectangle. </param>
#endif
        public void DrawRect(int pt1X, int pt1Y, int pt2X, int pt2Y, CvScalar color, int thickness)
        {
            Cv.DrawRect(this, pt1X, pt1Y, pt2X, pt2Y, color, thickness);
        }
#if LANG_JP
        /// <summary>
        /// 枠のみ，もしくは塗りつぶされた矩形を描画する
        /// </summary>
        /// <param name="pt1X">矩形の一つの頂点のx座標</param>
        /// <param name="pt1Y">矩形の一つの頂点のy座標</param>
        /// <param name="pt2X">矩形の反対側の頂点のx座標</param>
        /// <param name="pt2Y">矩形の反対側の頂点のy座標</param>
        /// <param name="color">線の色(RGB)，もしくは輝度(グレースケール画像).</param>
        /// <param name="thickness">矩形を描く線の太さ．負の値，例えばCV_FILLEDを指定した場合は塗りつぶされる．</param>
        /// <param name="lineType">線の種類</param>
#else
        /// <summary>
        /// Draws simple, thick or filled rectangle
        /// </summary>
        /// <param name="pt1X">X-coordinate of the one of the rectangle vertices. </param>
        /// <param name="pt1Y">Y-coordinate of the one of the rectangle vertices. </param>
        /// <param name="pt2X">X-coordinate of the opposite rectangle vertex. </param>
        /// <param name="pt2Y">Y-coordinate of the opposite rectangle vertex. </param>
        /// <param name="color">Line color (RGB) or brightness (grayscale image). </param>
        /// <param name="thickness">Thickness of lines that make up the rectangle. Negative values, e.g. CV_FILLED, make the function to draw a filled rectangle. </param>
        /// <param name="lineType">Type of the line, see cvLine description. </param>
#endif
        public void DrawRect(int pt1X, int pt1Y, int pt2X, int pt2Y, CvScalar color, int thickness, LineType lineType)
        {
            Cv.DrawRect(this, pt1X, pt1Y, pt2X, pt2Y, color, thickness, lineType);
        }
#if LANG_JP
        /// <summary>
        /// 枠のみ，もしくは塗りつぶされた矩形を描画する
        /// </summary>
        /// <param name="pt1X">矩形の一つの頂点のx座標</param>
        /// <param name="pt1Y">矩形の一つの頂点のy座標</param>
        /// <param name="pt2X">矩形の反対側の頂点のx座標</param>
        /// <param name="pt2Y">矩形の反対側の頂点のy座標</param>
        /// <param name="color">線の色(RGB)，もしくは輝度(グレースケール画像).</param>
        /// <param name="thickness">矩形を描く線の太さ．負の値，例えばCV_FILLEDを指定した場合は塗りつぶされる．</param>
        /// <param name="lineType">線の種類</param>
        /// <param name="shift">座標の小数点以下の桁を表すビット数</param>
#else
        /// <summary>
        /// Draws simple, thick or filled rectangle
        /// </summary>
        /// <param name="pt1X">X-coordinate of the one of the rectangle vertices. </param>
        /// <param name="pt1Y">Y-coordinate of the one of the rectangle vertices. </param>
        /// <param name="pt2X">X-coordinate of the opposite rectangle vertex. </param>
        /// <param name="pt2Y">Y-coordinate of the opposite rectangle vertex. </param>
        /// <param name="color">Line color (RGB) or brightness (grayscale image). </param>
        /// <param name="thickness">Thickness of lines that make up the rectangle. Negative values, e.g. CV_FILLED, make the function to draw a filled rectangle. </param>
        /// <param name="lineType">Type of the line, see cvLine description. </param>
        /// <param name="shift">Number of fractional bits in the point coordinates. </param>
#endif
        public void DrawRect(int pt1X, int pt1Y, int pt2X, int pt2Y, CvScalar color, int thickness, LineType lineType, int shift)
        {
            Cv.DrawRect(this, pt1X, pt1Y, pt2X, pt2Y, color, thickness, lineType, shift);
        }

#if LANG_JP
        /// <summary>
        /// 枠のみ，もしくは塗りつぶされた矩形を描画する
        /// </summary>
        /// <param name="pt1">矩形の一つの頂点</param>
        /// <param name="pt2">矩形の反対側の頂点</param>
        /// <param name="color">線の色(RGB)，もしくは輝度(グレースケール画像).</param>
#else
        /// <summary>
        /// Draws simple, thick or filled rectangle
        /// </summary>
        /// <param name="pt1">One of the rectangle vertices. </param>
        /// <param name="pt2">Opposite rectangle vertex. </param>
        /// <param name="color">Line color (RGB) or brightness (grayscale image). </param>
#endif
        public void DrawRect(CvPoint pt1, CvPoint pt2, CvScalar color)
        {
            Cv.DrawRect(this, pt1, pt2, color);
        }
#if LANG_JP
        /// <summary>
        /// 枠のみ，もしくは塗りつぶされた矩形を描画する
        /// </summary>
        /// <param name="pt1">矩形の一つの頂点</param>
        /// <param name="pt2">矩形の反対側の頂点</param>
        /// <param name="color">線の色(RGB)，もしくは輝度(グレースケール画像).</param>
        /// <param name="thickness">矩形を描く線の太さ．負の値，例えばCV_FILLEDを指定した場合は塗りつぶされる.</param>
#else
        /// <summary>
        /// Draws simple, thick or filled rectangle
        /// </summary>
        /// <param name="pt1">One of the rectangle vertices. </param>
        /// <param name="pt2">Opposite rectangle vertex. </param>
        /// <param name="color">Line color (RGB) or brightness (grayscale image). </param>
        /// <param name="thickness">Thickness of lines that make up the rectangle. Negative values, e.g. CV_FILLED, make the function to draw a filled rectangle. </param>
#endif
        public void DrawRect(CvPoint pt1, CvPoint pt2, CvScalar color, int thickness)
        {
            Cv.DrawRect(this, pt1, pt2, color, thickness);
        }
#if LANG_JP
        /// <summary>
        /// 枠のみ，もしくは塗りつぶされた矩形を描画する
        /// </summary>
        /// <param name="pt1">矩形の一つの頂点</param>
        /// <param name="pt2">矩形の反対側の頂点</param>
        /// <param name="color">線の色(RGB)，もしくは輝度(グレースケール画像).</param>
        /// <param name="thickness">矩形を描く線の太さ．負の値，例えばCV_FILLEDを指定した場合は塗りつぶされる.</param>
        /// <param name="lineType">線の種類</param>
#else
        /// <summary>
        /// Draws simple, thick or filled rectangle
        /// </summary>
        /// <param name="pt1">One of the rectangle vertices. </param>
        /// <param name="pt2">Opposite rectangle vertex. </param>
        /// <param name="color">Line color (RGB) or brightness (grayscale image). </param>
        /// <param name="thickness">Thickness of lines that make up the rectangle. Negative values, e.g. CV_FILLED, make the function to draw a filled rectangle. </param>
        /// <param name="lineType">Type of the line, see cvLine description. </param>
#endif
        public void DrawRect(CvPoint pt1, CvPoint pt2, CvScalar color, int thickness, LineType lineType)
        {
            Cv.DrawRect(this, pt1, pt2, color, thickness, lineType);
        }
#if LANG_JP
        /// <summary>
        /// 枠のみ，もしくは塗りつぶされた矩形を描画する
        /// </summary>
        /// <param name="pt1">矩形の一つの頂点</param>
        /// <param name="pt2">矩形の反対側の頂点</param>
        /// <param name="color">線の色(RGB)，もしくは輝度(グレースケール画像).</param>
        /// <param name="thickness">矩形を描く線の太さ．負の値，例えばCV_FILLEDを指定した場合は塗りつぶされる．</param>
        /// <param name="lineType">線の種類</param>
        /// <param name="shift">座標の小数点以下の桁を表すビット数</param>
#else
        /// <summary>
        /// Draws simple, thick or filled rectangle
        /// </summary>
        /// <param name="pt1">One of the rectangle vertices. </param>
        /// <param name="pt2">Opposite rectangle vertex. </param>
        /// <param name="color">Line color (RGB) or brightness (grayscale image). </param>
        /// <param name="thickness">Thickness of lines that make up the rectangle. Negative values, e.g. CV_FILLED, make the function to draw a filled rectangle. </param>
        /// <param name="lineType">Type of the line, see cvLine description. </param>
        /// <param name="shift">Number of fractional bits in the point coordinates. </param>
#endif
        public void DrawRect(CvPoint pt1, CvPoint pt2, CvScalar color, int thickness, LineType lineType, int shift)
        {
            Cv.DrawRect(this, pt1, pt2, color, thickness, lineType, shift);
        }
#if LANG_JP
        /// <summary>
        /// 枠のみ，もしくは塗りつぶされた矩形を描画する
        /// </summary>
        /// <param name="rect">矩形</param>
        /// <param name="color">線の色(RGB)，もしくは輝度(グレースケール画像).</param>
#else
        /// <summary>
        /// Draws simple, thick or filled rectangle
        /// </summary>
        /// <param name="rect">Rectangle.</param>
        /// <param name="color">Line color (RGB) or brightness (grayscale image). </param>
#endif
        public void DrawRect(CvRect rect, CvScalar color)
        {
            Cv.DrawRect(this, rect, color);
        }
#if LANG_JP
        /// <summary>
        /// 枠のみ，もしくは塗りつぶされた矩形を描画する
        /// </summary>
        /// <param name="rect">矩形</param>
        /// <param name="color">線の色(RGB)，もしくは輝度(グレースケール画像).</param>
        /// <param name="thickness">矩形を描く線の太さ．負の値，例えばCV_FILLEDを指定した場合は塗りつぶされる．</param>
#else
        /// <summary>
        /// Draws simple, thick or filled rectangle
        /// </summary>
        /// <param name="rect">Rectangle.</param>
        /// <param name="color">Line color (RGB) or brightness (grayscale image). </param>
        /// <param name="thickness">Thickness of lines that make up the rectangle. Negative values, e.g. CV_FILLED, make the function to draw a filled rectangle. </param>
#endif
        public void DrawRect(CvRect rect, CvScalar color, int thickness)
        {
            Cv.DrawRect(this, rect, color, thickness);
        }
#if LANG_JP
        /// <summary>
        /// 枠のみ，もしくは塗りつぶされた矩形を描画する
        /// </summary>
        /// <param name="rect">矩形</param>
        /// <param name="color">線の色(RGB)，もしくは輝度(グレースケール画像).</param>
        /// <param name="thickness">矩形を描く線の太さ．負の値，例えばCV_FILLEDを指定した場合は塗りつぶされる．</param>
        /// <param name="lineType">線の種類</param>
#else
        /// <summary>
        /// Draws simple, thick or filled rectangle
        /// </summary>
        /// <param name="rect">Rectangle.</param>
        /// <param name="color">Line color (RGB) or brightness (grayscale image). </param>
        /// <param name="thickness">Thickness of lines that make up the rectangle. Negative values, e.g. CV_FILLED, make the function to draw a filled rectangle. </param>
        /// <param name="lineType">Type of the line, see cvLine description. </param>
#endif
        public void DrawRect(CvRect rect, CvScalar color, int thickness, LineType lineType)
        {
            Cv.DrawRect(this, rect, color, thickness, lineType);
        }
#if LANG_JP
        /// <summary>
        /// 枠のみ，もしくは塗りつぶされた矩形を描画する
        /// </summary>
        /// <param name="rect">矩形</param>
        /// <param name="color">線の色(RGB)，もしくは輝度(グレースケール画像).</param>
        /// <param name="thickness">矩形を描く線の太さ．負の値，例えばCV_FILLEDを指定した場合は塗りつぶされる．</param>
        /// <param name="lineType">線の種類</param>
        /// <param name="shift">座標の小数点以下の桁を表すビット数</param>
#else
        /// <summary>
        /// Draws simple, thick or filled rectangle
        /// </summary>
        /// <param name="rect">Rectangle.</param>
        /// <param name="color">Line color (RGB) or brightness (grayscale image). </param>
        /// <param name="thickness">Thickness of lines that make up the rectangle. Negative values, e.g. CV_FILLED, make the function to draw a filled rectangle. </param>
        /// <param name="lineType">Type of the line, see cvLine description. </param>
        /// <param name="shift">Number of fractional bits in the point coordinates. </param>
#endif
        public void DrawRect(CvRect rect, CvScalar color, int thickness, LineType lineType, int shift)
        {
            Cv.DrawRect(this, rect, color, thickness, lineType, shift);
        }
        #endregion
        #region Reduce
#if LANG_JP
        /// <summary>
        /// 行列をベクトルへ縮小する
        /// </summary>
        /// <param name="dst">行（または1列）の出力ベクトル（すべての行/列から指定された方法で計算される）</param>
#else
        /// <summary>
        /// Reduces matrix to a vector
        /// </summary>
        /// <param name="dst">The output single-row/single-column vector that accumulates somehow all the matrix rows/columns. </param>
#endif
        public void Reduce(CvArr dst)
        {
            Cv.Reduce(this, dst);
        }
#if LANG_JP
        /// <summary>
        /// 行列をベクトルへ縮小する
        /// </summary>
        /// <param name="dst">行（または1列）の出力ベクトル（すべての行/列から指定された方法で計算される）</param>
        /// <param name="dim">配列をどのように縮小するかを示すインデックス</param>
#else
        /// <summary>
        /// Reduces matrix to a vector
        /// </summary>
        /// <param name="dst">The output single-row/single-column vector that accumulates somehow all the matrix rows/columns. </param>
        /// <param name="dim">The dimension index along which the matrix is reduce. 0 means that the matrix is reduced to a single row, 1 means that the matrix is reduced to a single column. -1 means that the dimension is chosen automatically by analysing the dst size. </param>
#endif
        public void Reduce(CvArr dst, ReduceDimension dim)
        {
            Cv.Reduce(this, dst, dim);
        }
#if LANG_JP
        /// <summary>
        /// 行列をベクトルへ縮小する
        /// </summary>
        /// <param name="dst">行（または1列）の出力ベクトル（すべての行/列から指定された方法で計算される）</param>
        /// <param name="dim">配列をどのように縮小するかを示すインデックス</param>
        /// <param name="type">縮小処理の種類</param>
#else
        /// <summary>
        /// Reduces matrix to a vector
        /// </summary>
        /// <param name="dst">The output single-row/single-column vector that accumulates somehow all the matrix rows/columns. </param>
        /// <param name="dim">The dimension index along which the matrix is reduce. 0 means that the matrix is reduced to a single row, 1 means that the matrix is reduced to a single column. -1 means that the dimension is chosen automatically by analysing the dst size. </param>
        /// <param name="type">The reduction operation.</param>
#endif
        public void Reduce(CvArr dst, ReduceDimension dim, ReduceOperation type)
        {
            Cv.Reduce(this, dst, dim, type);
        }
        #endregion
        #region ReleaseData
#if LANG_JP
        /// <summary>
        /// 配列データを解放する． 
        /// </summary>
#else
        /// <summary>
        /// Releases array data.
        /// </summary>
#endif
        public void ReleaseData()
        {
            Cv.ReleaseData(this);
        }
        #endregion
        #region Remap
#if LANG_JP
        /// <summary>
        /// 画像に対して幾何変換を行う. 指定されたマップを用いて入力画像を以下のように変換する．
        /// dst(x,y)&lt;-src(mapx(x,y),mapy(x,y)) .
        /// 他の幾何変換と同様，非整数座標値を持つピクセルを抽出するために，ユーザによって指定された補間方法が用いられる．
        /// </summary>
        /// <param name="dst">出力画像</param>
        /// <param name="mapx">x座標マップ (32FC1 フォーマットの画像)</param>
        /// <param name="mapy">y座標マップ (32FC1 フォーマットの画像)</param>
#else
        /// <summary>
        /// Applies generic geometrical transformation to the image.
        /// </summary>
        /// <param name="dst">Destination image. </param>
        /// <param name="mapx">The map of x-coordinates (32fC1 image). </param>
        /// <param name="mapy">The map of y-coordinates (32fC1 image). </param>
#endif
        public void Remap(CvArr dst, CvArr mapx, CvArr mapy)
        {
            Cv.Remap(this, dst, mapx, mapy);
        }
#if LANG_JP
        /// <summary>
        /// 画像に対して幾何変換を行う. 指定されたマップを用いて入力画像を以下のように変換する．
        /// dst(x,y)&lt;-src(mapx(x,y),mapy(x,y)) .
        /// 他の幾何変換と同様，非整数座標値を持つピクセルを抽出するために，ユーザによって指定された補間方法が用いられる．
        /// </summary>
        /// <param name="dst">出力画像</param>
        /// <param name="mapx">x座標マップ (32FC1 フォーマットの画像)</param>
        /// <param name="mapy">y座標マップ (32FC1 フォーマットの画像)</param>
        /// <param name="flags">補間方法</param>
#else
        /// <summary>
        /// Applies generic geometrical transformation to the image.
        /// </summary>
        /// <param name="dst">Destination image. </param>
        /// <param name="mapx">The map of x-coordinates (32fC1 image). </param>
        /// <param name="mapy">The map of y-coordinates (32fC1 image). </param>
        /// <param name="flags">A combination of interpolation method and the optional flag(s).</param>
#endif
        public void Remap(CvArr dst, CvArr mapx, CvArr mapy, Interpolation flags)
        {
            Cv.Remap(this, dst, mapx, mapy, flags);
        }
#if LANG_JP
        /// <summary>
        /// 画像に対して幾何変換を行う. 指定されたマップを用いて入力画像を以下のように変換する．
        /// dst(x,y)&lt;-src(mapx(x,y),mapy(x,y)) .
        /// 他の幾何変換と同様，非整数座標値を持つピクセルを抽出するために，ユーザによって指定された補間方法が用いられる．
        /// </summary>
        /// <param name="dst">出力画像</param>
        /// <param name="mapx">x座標マップ (32FC1 フォーマットの画像)</param>
        /// <param name="mapy">y座標マップ (32FC1 フォーマットの画像)</param>
        /// <param name="flags">補間方法</param>
        /// <param name="fillval">対応の取れない点に対して与える値</param>
#else
        /// <summary>
        /// Applies generic geometrical transformation to the image.
        /// </summary>
        /// <param name="dst">Destination image. </param>
        /// <param name="mapx">The map of x-coordinates (32fC1 image). </param>
        /// <param name="mapy">The map of y-coordinates (32fC1 image). </param>
        /// <param name="flags">A combination of interpolation method and the optional flag(s).</param>
        /// <param name="fillval">A value used to fill outliers. </param>
#endif
        public void Remap(CvArr dst, CvArr mapx, CvArr mapy, Interpolation flags, CvScalar fillval)
        {
            Cv.Remap(this, dst, mapx, mapy, flags, fillval);
        }
        #endregion
        #region Repeat
#if LANG_JP
        /// <summary>
        /// 出力配列を入力配列でタイル状に埋める
        /// </summary>
        /// <param name="dst">出力配列，画像または行列．</param>
#else
        /// <summary>
        /// Fill destination array with tiled source array
        /// </summary>
        /// <param name="dst">Destination array, image or matrix. </param>
#endif
        public void Repeat(CvArr dst)
        {
            Cv.Repeat(this, dst);
        }
        #endregion
        #region Reshape
#if LANG_JP
        /// <summary>
        /// オリジナルの配列と同じデータだが，異なる形状（異なるチャンネル数，異なる行数，またその両方）を持つCvMatのヘッダを初期化する．
        /// </summary>
        /// <param name="header">書き込まれる出力ヘッダ</param>
        /// <param name="newCn">新しいチャンネル数 ．new_cn = 0はチャンネル数が変更されていないことを意味する．</param>
        /// <returns>行列データ</returns>
#else
        /// <summary>
        /// Changes shape of matrix/image without copying data
        /// </summary>
        /// <param name="header">Output header to be filled. </param>
        /// <param name="newCn">New number of channels. new_cn = 0 means that number of channels remains unchanged. </param>
        /// <returns></returns>
#endif
        public CvMat Reshape(out CvMat header, int newCn)
        {
            return Cv.Reshape(this, out header, newCn);
        }
#if LANG_JP
        /// <summary>
        /// オリジナルの配列と同じデータだが，異なる形状（異なるチャンネル数，異なる行数，またその両方）を持つCvMatのヘッダを初期化する．
        /// </summary>
        /// <param name="header">書き込まれる出力ヘッダ</param>
        /// <param name="newCn">新しいチャンネル数 ．new_cn = 0はチャンネル数が変更されていないことを意味する．</param>
        /// <param name="newRows">新しい行数． new_rows = 0は，行数がnew_cnの値に応じて変更する必要があるのにも関わらず，変更されないままであることを意味する．</param>
        /// <returns>行列データ</returns>
#else
        /// <summary>
        /// Changes shape of matrix/image without copying data
        /// </summary>
        /// <param name="header">Output header to be filled. </param>
        /// <param name="newCn">New number of channels. new_cn = 0 means that number of channels remains unchanged. </param>
        /// <param name="newRows">New number of rows. new_rows = 0 means that number of rows remains unchanged unless it needs to be changed according to new_cn value. destination array to be changed. </param>
        /// <returns></returns>
#endif
        public CvMat Reshape(out CvMat header, int newCn, int newRows)
        {
            return Cv.Reshape(this, out header, newCn, newRows);
        }
#if LANG_JP
        /// <summary>
        /// オリジナルの配列と同じデータだが，異なる形状（異なるチャンネル数，異なる行数，またその両方）を持つCvMatのヘッダを初期化する．
        /// </summary>
        /// <param name="header">書き込まれる出力ヘッダ</param>
        /// <param name="newCn">新しいチャンネル数 ．new_cn = 0はチャンネル数が変更されていないことを意味する．</param>
        /// <returns>行列データ</returns>
#else
        /// <summary>
        /// Changes shape of matrix/image without copying data
        /// </summary>
        /// <param name="header">Output header to be filled. </param>
        /// <param name="newCn">New number of channels. new_cn = 0 means that number of channels remains unchanged. </param>
        /// <returns></returns>
#endif
        public CvMat Reshape(CvMat header, int newCn)
        {
            return Cv.Reshape(this, header, newCn);
        }
#if LANG_JP
        /// <summary>
        /// オリジナルの配列と同じデータだが，異なる形状（異なるチャンネル数，異なる行数，またその両方）を持つCvMatのヘッダを初期化する．
        /// </summary>
        /// <param name="header">書き込まれる出力ヘッダ</param>
        /// <param name="newCn">新しいチャンネル数 ．new_cn = 0はチャンネル数が変更されていないことを意味する．</param>
        /// <param name="newRows">新しい行数． new_rows = 0は，行数がnew_cnの値に応じて変更する必要があるのにも関わらず，変更されないままであることを意味する．</param>
        /// <returns>行列データ</returns>
#else
        /// <summary>
        /// Changes shape of matrix/image without copying data
        /// </summary>
        /// <param name="header">Output header to be filled. </param>
        /// <param name="newCn">New number of channels. new_cn = 0 means that number of channels remains unchanged. </param>
        /// <param name="newRows">New number of rows. new_rows = 0 means that number of rows remains unchanged unless it needs to be changed according to new_cn value. destination array to be changed. </param>
        /// <returns></returns>
#endif
        public CvMat Reshape(CvMat header, int newCn, int newRows)
        {
            return Cv.Reshape(this, header, newCn, newRows);
        }
        #endregion
        #region ReshapeMatND
#if LANG_JP
        /// <summary>
        /// cvReshape の拡張バージョン．
        /// これは多次元配列を扱うことが可能（普通の画像と行列に対しても使用することが可能）で，さらに次元の変更も可能である．
        /// </summary>
        /// <typeparam name="T">出力ヘッダの型</typeparam>
        /// <param name="sizeofHeader">IplImageとCvMat，CvMatNDそれぞれの出力ヘッダを区別するための出力ヘッダのサイズ．</param>
        /// <param name="header">書き込まれる出力ヘッダ</param>
        /// <param name="newCn">新しいチャンネル数 ．new_cn = 0はチャンネル数が変更されていないことを意味する．</param>
        /// <param name="newDims">新しい次元数． new_dims = 0は，次元数が同じままであることを意味する．</param>
        /// <param name="newSizes">新しい次元サイズの配列．要素の総数は変化してはいけないので，new_dims-1の値のみ使用される．従って，new_dims = 1であればnew_sizesは使用されない．</param>
        /// <returns></returns>
#else
        /// <summary>
        /// Changes shape of multi-dimensional array w/o copying data
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sizeofHeader">Size of output header to distinguish between IplImage, CvMat and CvMatND output headers. </param>
        /// <param name="header">Output header to be filled. </param>
        /// <param name="newCn">New number of channels. new_cn = 0 means that number of channels remains unchanged. </param>
        /// <param name="newDims">New number of dimensions. new_dims = 0 means that number of dimensions remains the same. </param>
        /// <param name="newSizes">Array of new dimension sizes. Only new_dims-1 values are used, because the total number of elements must remain the same. Thus, if new_dims = 1, new_sizes array is not used </param>
        /// <returns></returns>
#endif
        public T ReshapeMatND<T>(int sizeofHeader, T header, int newCn, int newDims, int[] newSizes) where T : CvArr
        {
            return Cv.ReshapeMatND(this, sizeofHeader, header, newCn, newDims, newSizes);
        }
#if LANG_JP
        /// <summary>
        /// cvReshape の拡張バージョン．
        /// これは多次元配列を扱うことが可能（普通の画像と行列に対しても使用することが可能）で，さらに次元の変更も可能である．
        /// </summary>
        /// <typeparam name="T">出力ヘッダの型</typeparam>
        /// <param name="header">書き込まれる出力ヘッダ</param>
        /// <param name="newCn">新しいチャンネル数 ．new_cn = 0はチャンネル数が変更されていないことを意味する．</param>
        /// <param name="newDims">新しい次元数． new_dims = 0は，次元数が同じままであることを意味する．</param>
        /// <param name="newSizes">新しい次元サイズの配列．要素の総数は変化してはいけないので，new_dims-1の値のみ使用される．従って，new_dims = 1であればnew_sizesは使用されない．</param>
        /// <returns></returns>
#else
        /// <summary>
        /// Changes shape of multi-dimensional array w/o copying data
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="header">Output header to be filled. </param>
        /// <param name="newCn">New number of channels. new_cn = 0 means that number of channels remains unchanged. </param>
        /// <param name="newDims">New number of dimensions. new_dims = 0 means that number of dimensions remains the same. </param>
        /// <param name="newSizes">Array of new dimension sizes. Only new_dims-1 values are used, because the total number of elements must remain the same. Thus, if new_dims = 1, new_sizes array is not used </param>
        /// <returns></returns>
#endif
        public T ReshapeND<T>(T header, int newCn, int newDims, int[] newSizes) where T : CvArr
        {
            return Cv.ReshapeND(this, header, newCn, newDims, newSizes);
        }
        #endregion
        #region Resize
#if LANG_JP
        /// <summary>
        /// 画像のサイズ変更を行う (バイリニア補間)
        /// </summary>
        /// <param name="dst">出力画像</param>
#else
        /// <summary>
        /// Resizes image src so that it fits exactly to dst. 
        /// If ROI is set, the function consideres the ROI as supported as usual.
        /// </summary>
        /// <param name="dst">Destination image. </param>
#endif
        public void Resize(CvArr dst)
        {
            Cv.Resize(this, dst);
        }
#if LANG_JP
        /// <summary>
        /// 画像のサイズ変更を行う
        /// </summary>
        /// <param name="dst">出力画像</param>
        /// <param name="interpolation">補間方法</param>
#else
        /// <summary>
        /// Resizes image src so that it fits exactly to dst. 
        /// If ROI is set, the function consideres the ROI as supported as usual.
        /// </summary>
        /// <param name="dst">Destination image. </param>
        /// <param name="interpolation">Interpolation method.</param>
#endif
        public void Resize(CvArr dst, Interpolation interpolation)
        {
            Cv.Resize(this, dst, interpolation);
        }
        #endregion
        #region SampleLine
#if LANG_JP
        /// <summary>
        /// ラスタ表現の線分を構成する点をサンプリングする
        /// </summary>
        /// <param name="pt1">線分の始点</param>
        /// <param name="pt2">線分の終点</param>
        /// <param name="buffer">線分上の点を保存するためのバッファ</param>
        /// <param name="connectivity">線分の接続性．4 または 8．</param>
        /// <returns></returns>
#else
        /// <summary>
        /// Implements a particular case of application of line iterators. 
        /// The function reads all the image points lying on the line between pt1 and pt2, including the ending points, and stores them into the buffer.
        /// </summary>
        /// <param name="pt1">Starting the line point. </param>
        /// <param name="pt2">Ending the line point. </param>
        /// <param name="buffer">Buffer to store the line points.</param>
        /// <param name="connectivity">The line connectivity, 4 or 8. </param>
        /// <returns></returns>
#endif
        public int SampleLine(CvPoint pt1, CvPoint pt2, out CvPoint[] buffer, int connectivity)
        {
            return Cv.SampleLine(this, pt1, pt2, out buffer, connectivity);
        }
        #endregion
        #region ScaleAdd
#if LANG_JP
        /// <summary>
        /// スケーリングされた配列ともう一つの配列の和を計算する.
        /// dst(I)=src1(I)*scale + src2(I)
        /// </summary>
        /// <param name="scale">1番目の配列のためのスケールファクタ</param>
        /// <param name="src2">2番目の入力配列</param>
        /// <param name="dst">出力配列</param>
#else
        /// <summary>
        /// Calculates sum of scaled array and another array
        /// </summary>
        /// <param name="scale">Scale factor for the first array. </param>
        /// <param name="src2">The second source array. </param>
        /// <param name="dst">The destination array </param>
#endif
        public void ScaleAdd(CvScalar scale, CvArr src2, CvArr dst)
        {
            Cv.ScaleAdd(this, scale, src2, dst);
        }
#if LANG_JP
        /// <summary>
        /// スケーリングされた配列ともう一つの配列の和を計算する (cvScaleAddのエイリアス).
        /// dst(I)=src1(I)*scale + src2(I)
        /// </summary>
        /// <param name="scale">1番目の配列のためのスケールファクタ</param>
        /// <param name="src2">2番目の入力配列</param>
        /// <param name="dst">出力配列</param>
#else
        /// <summary>
        /// Calculates sum of scaled array and another array
        /// </summary>
        /// <param name="scale">Scale factor for the first array. </param>
        /// <param name="src2">The second source array. </param>
        /// <param name="dst">The destination array </param>
#endif
        public void MulAddS(CvScalar scale, CvArr src2, CvArr dst)
        {
            Cv.MulAddS(this, scale, src2, dst);
        }
        #endregion
        #region Set
#if LANG_JP
        /// <summary>
        /// スカラー値 value を，配列の選択された各要素にコピーする．
        /// </summary>
        /// <param name="value">配列を埋める値</param>
#else
        /// <summary>
        /// Sets every element of array to given value
        /// </summary>
        /// <param name="value">Fill value. </param>
#endif
        public void Set(CvScalar value)
        {
            Cv.Set(this, value);
        }
#if LANG_JP
        /// <summary>
        /// スカラー値 value を，配列の選択された各要素にコピーする．
        /// mask(I) != null の場合，arr(I)=value. 
        /// </summary>
        /// <param name="value">配列を埋める値</param>
        /// <param name="mask">8 ビットシングルチャンネル配列の処理マスク．配列の変更する要素を指定する.</param>
#else
        /// <summary>
        /// Sets every element of array to given value
        /// </summary>
        /// <param name="value">Fill value. </param>
        /// <param name="mask">Operation mask, 8-bit single channel array; specifies elements of destination array to be changed. </param>
#endif
        public void Set(CvScalar value, CvArr mask)
        {
            Cv.Set(this, value, mask);
        }
        #endregion
        #region Set*D
#if LANG_JP
        /// <summary>
        /// 新しい値を指定した配列要素に割り当てる． 
        /// 疎な配列の場合，ノードが存在しなければ，この関数はノードを生成する．
        /// </summary>
        /// <param name="idx0">要素インデックスの，0を基準とした第1成分．</param>
        /// <param name="value">割り当てる値</param>
#else
        /// <summary>
        /// Change the particular array element
        /// </summary>
        /// <param name="idx0">The first zero-based component of the element index </param>
        /// <param name="value">The assigned value </param>
#endif
        public void Set1D(int idx0, CvScalar value)
        {
            NativeMethods.cvSet1D(CvPtr, idx0, value);
        }
#if LANG_JP
        /// <summary>
        /// 新しい値を指定した配列要素に割り当てる． 
        /// 疎な配列の場合，ノードが存在しなければ，この関数はノードを生成する．
        /// </summary>
        /// <param name="idx0">要素インデックスの，0を基準とした第1成分．</param>
        /// <param name="idx1">要素インデックスの，0を基準とした第2成分．</param>
        /// <param name="value">割り当てる値</param>
#else
        /// <summary>
        /// Change the particular array element
        /// </summary>
        /// <param name="idx0">The first zero-based component of the element index </param>
        /// <param name="idx1">The second zero-based component of the element index </param>
        /// <param name="value">The assigned value </param>
#endif
        public void Set2D(int idx0, int idx1, CvScalar value)
        {
            NativeMethods.cvSet2D(CvPtr, idx0, idx1, value);
        }
#if LANG_JP
        /// <summary>
        /// 新しい値を指定した配列要素に割り当てる． 
        /// 疎な配列の場合，ノードが存在しなければ，この関数はノードを生成する．
        /// </summary>
        /// <param name="idx0">要素インデックスの，0を基準とした第1成分．</param>
        /// <param name="idx1">要素インデックスの，0を基準とした第2成分．</param>
        /// <param name="idx2">要素インデックスの，0を基準とした第3成分．</param>
        /// <param name="value">割り当てる値</param>
#else
        /// <summary>
        /// Change the particular array element
        /// </summary>
        /// <param name="idx0">The first zero-based component of the element index </param>
        /// <param name="idx1">The second zero-based component of the element index </param>
        /// <param name="idx2">The third zero-based component of the element index </param>
        /// <param name="value">The assigned value </param>
#endif
        public void Set3D(int idx0, int idx1, int idx2, CvScalar value)
        {
            NativeMethods.cvSet3D(CvPtr, idx0, idx1, idx2, value);
        }
#if LANG_JP
        /// <summary>
        /// 新しい値を指定した配列要素に割り当てる． 
        /// 疎な配列の場合，ノードが存在しなければ，この関数はノードを生成する．
        /// </summary>
        /// <param name="value">割り当てる値</param>
        /// <param name="idx">要素インデックスの配列(可変長引数)</param>
#else
        /// <summary>
        /// Change the particular array element
        /// </summary>
        /// <param name="value">The assigned value </param>
        /// <param name="idx">Array of the element indices</param>
#endif
        public void SetND(CvScalar value, params int[] idx)
        {
            NativeMethods.cvSetND(CvPtr, idx, value);
        }
        #endregion
        #region SetData
#if LANG_JP
        /// <summary>
        /// ユーザデータを配列のヘッダに割り当てる． 
        /// ヘッダは，関数 cvCreate*Header，関数 cvInit*Header あるいは 関数 cvMat（行列の場合）を用いて，あらかじめ初期化されるべきである．
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="data">ユーザデータ</param>
        /// <param name="step">バイト単位で表された行の長さ</param>
#else
        /// <summary>
        /// Assigns user data to the array header.
        /// Header should be initialized before using cvCreate*Header, cvInit*Header or cvMat (in case of matrix) function. 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="data">User data. </param>
        /// <param name="step">Full row length in bytes. </param>
#endif
        public void SetData<T>(T[] data, int step) where T : struct
        {
            Cv.SetData(this, data, step);
        }
#if LANG_JP
        /// <summary>
        /// ユーザデータを配列のヘッダに割り当てる． 
        /// ヘッダは，関数 cvCreate*Header，関数 cvInit*Header あるいは 関数 cvMat（行列の場合）を用いて，あらかじめ初期化されるべきである．
        /// </summary>
        /// <param name="data">ユーザデータ</param>
        /// <param name="step">バイト単位で表された行の長さ</param>
#else
        /// <summary>
        /// Assigns user data to the array header.
        /// Header should be initialized before using cvCreate*Header, cvInit*Header or cvMat (in case of matrix) function. 
        /// </summary>
        /// <param name="data">User data. </param>
        /// <param name="step">Full row length in bytes. </param>
#endif
        public void SetData(IntPtr data, int step)
        {
            Cv.SetData(this, data, step);
        }
        #endregion
        #region SetIdentity
#if LANG_JP
        /// <summary>
        /// スカラー倍された単位行列を用いた初期化を行う
        /// </summary>
#else
        /// <summary>
        /// Initializes scaled identity matrix
        /// </summary>
#endif
        public void SetIdentity()
        {
            Cv.SetIdentity(this);
        }
#if LANG_JP
        /// <summary>
        /// スカラー倍された単位行列を用いた初期化を行う
        /// </summary>
        /// <param name="value">対角成分の値</param>
#else
        /// <summary>
        /// Initializes scaled identity matrix
        /// </summary>
        /// <param name="value">The value to assign to the diagonal elements. </param>
#endif
        public void SetIdentity(CvScalar value)
        {
            Cv.SetIdentity(this, value);
        }
        #endregion
        #region SetReal*D
#if LANG_JP
        /// <summary>
        /// シングルチャンネルの配列の指定した要素に新しい値を割り当てる．配列がマルチチャンネルのときは，ランタイムエラーが起こる．
        /// 疎な配列の場合に，ノードが存在しなれば，この関数はノードを生成する．
        /// </summary>
        /// <param name="idx0">要素インデックスの，0を基準とした第1成分．</param>
        /// <param name="value">割り当てる値</param>
#else
        /// <summary>
        /// Change the particular array element
        /// </summary>
        /// <param name="idx0">The first zero-based component of the element index </param>
        /// <param name="value">The assigned value </param>
#endif
        public void SetReal1D(int idx0, double value)
        {
            NativeMethods.cvSetReal1D(CvPtr, idx0, value);
        }
#if LANG_JP
        /// <summary>
        /// シングルチャンネルの配列の指定した要素に新しい値を割り当てる．配列がマルチチャンネルのときは，ランタイムエラーが起こる．
        /// 疎な配列の場合に，ノードが存在しなれば，この関数はノードを生成する．
        /// </summary>
        /// <param name="idx0">要素インデックスの，0を基準とした第1成分．</param>
        /// <param name="idx1">要素インデックスの，0を基準とした第2成分．</param>
        /// <param name="value">割り当てる値</param>
#else
        /// <summary>
        /// Change the particular array element
        /// </summary>
        /// <param name="idx0">The first zero-based component of the element index </param>
        /// <param name="idx1">The second zero-based component of the element index </param>
        /// <param name="value">The assigned value </param>
#endif
        public void SetReal2D(int idx0, int idx1, double value)
        {
            NativeMethods.cvSetReal2D(CvPtr, idx0, idx1, value);
        }
#if LANG_JP
        /// <summary>
        /// シングルチャンネルの配列の指定した要素に新しい値を割り当てる．配列がマルチチャンネルのときは，ランタイムエラーが起こる．
        /// 疎な配列の場合に，ノードが存在しなれば，この関数はノードを生成する．
        /// </summary>
        /// <param name="idx0">要素インデックスの，0を基準とした第1成分．</param>
        /// <param name="idx1">要素インデックスの，0を基準とした第2成分．</param>
        /// <param name="idx2">要素インデックスの，0を基準とした第3成分．</param>
        /// <param name="value">割り当てる値</param>
#else
        /// <summary>
        /// Change the particular array element
        /// </summary>
        /// <param name="idx0">The first zero-based component of the element index </param>
        /// <param name="idx1">The second zero-based component of the element index </param>
        /// <param name="idx2">The third zero-based component of the element index </param>
        /// <param name="value">The assigned value </param>
#endif
        public void SetReal3D(int idx0, int idx1, int idx2, double value)
        {
            NativeMethods.cvSetReal3D(CvPtr, idx0, idx1, idx2, value);
        }
#if LANG_JP
        /// <summary>
        /// シングルチャンネルの配列の指定した要素に新しい値を割り当てる．配列がマルチチャンネルのときは，ランタイムエラーが起こる．
        /// 疎な配列の場合に，ノードが存在しなれば，この関数はノードを生成する．
        /// </summary>
        /// <param name="value">割り当てる値</param>
        /// <param name="idx">要素インデックスの配列(可変長引数)</param>
#else
        /// <summary>
        /// Change the particular array element
        /// </summary>
        /// <param name="value">The assigned value </param>
        /// <param name="idx">Array of the element indices </param>
#endif
        public void SetRealND(double value, params int[] idx)
        {
            NativeMethods.cvSetRealND(CvPtr, idx, value);
        }
        #endregion
        #region SetZero
#if LANG_JP
        /// <summary>
        /// 配列をクリアする
        /// </summary>
#else
        /// <summary>
        /// Clears the array
        /// </summary>
#endif
        public void SetZero()
        {
            Cv.SetZero(this);
        }
#if LANG_JP
        /// <summary>
        /// 配列をクリアする
        /// </summary>
#else
        /// <summary>
        /// Clears the array
        /// </summary>
#endif
        public void Zero()
        {
            Cv.Zero(this);
        }
        #endregion
        #region Smooth
#if LANG_JP
        /// <summary>
        /// 画像の平滑化を行う
        /// </summary>
        /// <param name="dst">出力画像</param>
#else
        /// <summary>
        /// Smooths the image in one of several ways.
        /// </summary>
        /// <param name="dst">The destination image. </param>
#endif
        public void Smooth(CvArr dst)
        {
            Cv.Smooth(this, dst);
        }
#if LANG_JP
        /// <summary>
        /// 画像の平滑化を行う
        /// </summary>
        /// <param name="dst">出力画像</param>
        /// <param name="smoothtype">平滑化の方法</param>
#else
        /// <summary>
        /// Smooths the image in one of several ways.
        /// </summary>
        /// <param name="dst">The destination image. </param>
        /// <param name="smoothtype">Type of the smoothing.</param>
#endif
        public void Smooth(CvArr dst, SmoothType smoothtype)
        {
            Cv.Smooth(this, dst, smoothtype);
        }
#if LANG_JP
        /// <summary>
        /// 画像の平滑化を行う
        /// </summary>
        /// <param name="dst">出力画像</param>
        /// <param name="smoothtype">平滑化の方法</param>
        /// <param name="param1">平滑化処理のパラメータ1</param>
#else
        /// <summary>
        /// Smooths the image in one of several ways.
        /// </summary>
        /// <param name="dst">The destination image. </param>
        /// <param name="smoothtype">Type of the smoothing.</param>
        /// <param name="param1">The first parameter of smoothing operation. </param>
#endif
        public void Smooth(CvArr dst, SmoothType smoothtype, int param1)
        {
            Cv.Smooth(this, dst, smoothtype, param1);
        }
#if LANG_JP
        /// <summary>
        /// 画像の平滑化を行う
        /// </summary>
        /// <param name="dst">出力画像</param>
        /// <param name="smoothtype">平滑化の方法</param>
        /// <param name="param1">平滑化処理のパラメータ1</param>
        /// <param name="param2">平滑化処理のパラメータ2．スケーリング有り/無しの単純平滑またはガウシアン平滑化の場合，param2 が0のときは param1 にセットされる.</param>
#else
        /// <summary>
        /// Smooths the image in one of several ways.
        /// </summary>
        /// <param name="dst">The destination image. </param>
        /// <param name="smoothtype">Type of the smoothing.</param>
        /// <param name="param1">The first parameter of smoothing operation. </param>
        /// <param name="param2">The second parameter of smoothing operation. In case of simple scaled/non-scaled and Gaussian blur if param2 is zero, it is set to param1. </param>
#endif
        public void Smooth(CvArr dst, SmoothType smoothtype, int param1, int param2)
        {
            Cv.Smooth(this, dst, smoothtype, param1, param2);
        }
#if LANG_JP
        /// <summary>
        /// 画像の平滑化を行う
        /// </summary>
        /// <param name="dst">出力画像</param>
        /// <param name="smoothtype">平滑化の方法</param>
        /// <param name="param1">平滑化処理のパラメータ1</param>
        /// <param name="param2">平滑化処理のパラメータ2．スケーリング有り/無しの単純平滑またはガウシアン平滑化の場合，param2 が0のときは param1 にセットされる.</param>
        /// <param name="param3">ガウシアン平滑化 の場合，このパラメータがガウシアンsigma（標準偏差）を示す．</param>
#else
        /// <summary>
        /// Smooths the image in one of several ways.
        /// </summary>
        /// <param name="dst">The destination image. </param>
        /// <param name="smoothtype">Type of the smoothing.</param>
        /// <param name="param1">The first parameter of smoothing operation. </param>
        /// <param name="param2">The second parameter of smoothing operation. In case of simple scaled/non-scaled and Gaussian blur if param2 is zero, it is set to param1. </param>
        /// <param name="param3">In case of Gaussian kernel this parameter may specify Gaussian sigma (standard deviation). If it is zero, it is calculated from the kernel size.</param>
#endif
        public void Smooth(CvArr dst, SmoothType smoothtype, int param1, int param2, double param3)
        {
            Cv.Smooth(this, dst, smoothtype, param1, param2, param3);
        }
#if LANG_JP
        /// <summary>
        /// 画像の平滑化を行う
        /// </summary>
        /// <param name="dst">出力画像</param>
        /// <param name="smoothtype">平滑化の方法</param>
        /// <param name="param1">平滑化処理のパラメータ1</param>
        /// <param name="param2">平滑化処理のパラメータ2．スケーリング有り/無しの単純平滑またはガウシアン平滑化の場合，param2 が0のときは param1 にセットされる.</param>
        /// <param name="param3">ガウシアン平滑化 の場合，このパラメータがガウシアンsigma（標準偏差）を示す．</param>
        /// <param name="param4">非正方形のガウシアンカーネルを使用する場合，垂直方向に異なるsigma 値(param3と違う値)指定するために用いられる．</param>
#else
        /// <summary>
        /// Smooths the image in one of several ways.
        /// </summary>
        /// <param name="dst">The destination image. </param>
        /// <param name="smoothtype">Type of the smoothing.</param>
        /// <param name="param1">The first parameter of smoothing operation. </param>
        /// <param name="param2">The second parameter of smoothing operation. In case of simple scaled/non-scaled and Gaussian blur if param2 is zero, it is set to param1. </param>
        /// <param name="param3">In case of Gaussian kernel this parameter may specify Gaussian sigma (standard deviation). If it is zero, it is calculated from the kernel size.</param>
        /// <param name="param4">In case of non-square Gaussian kernel the parameter may be used to specify a different (from param3) sigma in the vertical direction. </param>
#endif
        public void Smooth(CvArr dst, SmoothType smoothtype, int param1, int param2, double param3, double param4)
        {
            Cv.Smooth(this, dst, smoothtype, param1, param2, param3, param4);
        }
        #endregion
        #region Sobel
#if LANG_JP
        /// <summary>
        /// 拡張Sobel演算子を用いて1次，2次，3次または混合次数の微分画像を計算する [aperture_size=3]
        /// </summary>
        /// <param name="dst">出力画像</param>
        /// <param name="xorder">x-導関数の次数</param>
        /// <param name="yorder">y-導関数の次数</param>
#else
        /// <summary>
        /// Calculates first, second, third or mixed image derivatives using extended Sobel operator
        /// </summary>
        /// <param name="dst">Destination image. </param>
        /// <param name="xorder">Order of the derivative x.</param>
        /// <param name="yorder">Order of the derivative y.</param>
#endif
        public void Sobel(CvArr dst, int xorder, int yorder)
        {
            Cv.Sobel(this, dst, xorder, yorder);
        }
#if LANG_JP
        /// <summary>
        /// 拡張Sobel演算子を用いて1次，2次，3次または混合次数の微分画像を計算する
        /// </summary>
        /// <param name="dst">出力画像</param>
        /// <param name="xorder">x-導関数の次数</param>
        /// <param name="yorder">y-導関数の次数</param>
        /// <param name="apertureSize">拡張Sobelカーネルのサイズ</param>
#else
        /// <summary>
        /// Calculates first, second, third or mixed image derivatives using extended Sobel operator
        /// </summary>
        /// <param name="dst">Destination image. </param>
        /// <param name="xorder">Order of the derivative x.</param>
        /// <param name="yorder">Order of the derivative y.</param>
        /// <param name="apertureSize">Size of the extended Sobel kernel.</param>
#endif
        public void Sobel(CvArr dst, int xorder, int yorder, ApertureSize apertureSize)
        {
            Cv.Sobel(this, dst, xorder, yorder, apertureSize);
        }
        #endregion
        #region Sort
#if LANG_JP
        /// <summary>
        /// Sorts the rows/cols of an array ascending/descending
        /// </summary>
#else
        /// <summary>
        /// Sorts the rows/cols of an array ascending/descending
        /// </summary>
#endif
        public void Sort()
        {
            Cv.Sort(this);
        }
#if LANG_JP
        /// <summary>
        /// Sorts the rows/cols of an array ascending/descending
        /// </summary>
        /// <param name="dst">Optional destination array</param>
#else
        /// <summary>
        /// Sorts the rows/cols of an array ascending/descending
        /// </summary>
        /// <param name="dst">Optional destination array</param>
#endif
        public void Sort(CvArr dst)
        {
            Cv.Sort(this, dst);
        }
#if LANG_JP
        /// <summary>
        /// Sorts the rows/cols of an array ascending/descending
        /// </summary>
        /// <param name="dst">Optional destination array</param>
        /// <param name="idxmat">Index matrix</param>
#else
        /// <summary>
        /// Sorts the rows/cols of an array ascending/descending
        /// </summary>
        /// <param name="dst">Optional destination array</param>
        /// <param name="idxmat">Index matrix</param>
#endif
        public void Sort(CvArr dst, CvArr idxmat)
        {
            Cv.Sort(this, dst, idxmat);
        }
#if LANG_JP
        /// <summary>
        /// Sorts the rows/cols of an array ascending/descending
        /// </summary>
        /// <param name="dst">Optional destination array</param>
        /// <param name="idxmat">Index matrix</param>
        /// <param name="flags">Sorting parameter</param>
#else
        /// <summary>
        /// Sorts the rows/cols of an array ascending/descending
        /// </summary>
        /// <param name="dst">Optional destination array</param>
        /// <param name="idxmat">Index matrix</param>
        /// <param name="flags">Sorting parameter</param>
#endif
        public void Sort(CvArr dst, CvArr idxmat, SortFlag flags)
        {
            Cv.Sort(this, dst, idxmat, flags);
        }
        #endregion
        #region Split
#if LANG_JP
        /// <summary>
        /// マルチチャンネルの配列を，複数のシングルチャンネルの配列に分割する．または，配列から一つのチャンネルを取り出す．
        /// </summary>
        /// <param name="dst0">出力チャンネル1</param>
        /// <param name="dst1">出力チャンネル2</param>
        /// <param name="dst2">出力チャンネル3</param>
        /// <param name="dst3">出力チャンネル4</param>
#else
        /// <summary>
        /// Divides multi-channel array into several single-channel arrays or extracts a single channel from the array
        /// </summary>
        /// <param name="dst0">Destination channel 0</param>
        /// <param name="dst1">Destination channel 1</param>
        /// <param name="dst2">Destination channel 2</param>
        /// <param name="dst3">Destination channel 3</param>
#endif
        public void Split(CvArr dst0, CvArr dst1, CvArr dst2, CvArr dst3)
        {
            Cv.Split(this, dst0, dst1, dst2, dst3);
        }
#if LANG_JP
        /// <summary>
        /// マルチチャンネルの配列を，複数のシングルチャンネルの配列に分割する．または，配列から一つのチャンネルを取り出す．
        /// </summary>
        /// <param name="dst0">出力チャンネル1</param>
        /// <param name="dst1">出力チャンネル2</param>
        /// <param name="dst2">出力チャンネル3</param>
        /// <param name="dst3">出力チャンネル4</param>
#else
        /// <summary>
        /// Divides multi-channel array into several single-channel arrays or extracts a single channel from the array
        /// </summary>
        /// <param name="dst0">Destination channel 0</param>
        /// <param name="dst1">Destination channel 1</param>
        /// <param name="dst2">Destination channel 2</param>
        /// <param name="dst3">Destination channel 3</param>
#endif
        public void CvtPixToPlane(CvArr dst0, CvArr dst1, CvArr dst2, CvArr dst3)
        {
            Cv.Split(this, dst0, dst1, dst2, dst3);
        }
        #endregion
        #region SquareAcc
#if LANG_JP
        /// <summary>
        /// アキュムレータに入力画像の二乗を加算する
        /// </summary>
        /// <param name="sqsum">入力画像と同じチャンネル数のアキュムレータ，32 ビットあるいは 64 ビット浮動小数点型． </param>
#else
        /// <summary>
        /// Adds the square of source image to accumulator
        /// </summary>
        /// <param name="sqsum">Accumulator of the same number of channels as input image, 32-bit or 64-bit floating-point. </param>
#endif
        public void SquareAcc(CvArr sqsum)
        {
            Cv.SquareAcc(this, sqsum);
        }
#if LANG_JP
        /// <summary>
        /// アキュムレータに入力画像の二乗を加算する
        /// </summary>
        /// <param name="sqsum">入力画像と同じチャンネル数のアキュムレータ，32 ビットあるいは 64 ビット浮動小数点型． </param>
        /// <param name="mask">オプションの処理マスク</param>        
#else
        /// <summary>
        /// Adds the square of source image to accumulator
        /// </summary>
        /// <param name="sqsum">Accumulator of the same number of channels as input image, 32-bit or 64-bit floating-point. </param>
        /// <param name="mask">Optional operation mask. </param>
#endif
        public void SquareAcc(CvArr sqsum, CvArr mask)
        {
            Cv.SquareAcc(this, sqsum, mask);
        }
        #endregion
        #region StartFindContours
#if LANG_JP
        /// <summary>
        /// 輪郭走査処理の初期化を行う
        /// </summary>
        /// <param name="storage">抽出された輪郭データの保存領域． </param>
        /// <returns>輪郭スキャナのポインタ</returns>
#else
        /// <summary>
        /// Initializes contour scanning process
        /// </summary>
        /// <param name="storage">Container of the retrieved contours.</param>
        /// <returns>CvContourScanner</returns>
#endif
        public CvContourScanner StartFindContours(CvMemStorage storage)
        {
            return Cv.StartFindContours(this, storage);
        }
#if LANG_JP
        /// <summary>
        /// 輪郭走査処理の初期化を行う
        /// </summary>
        /// <param name="storage">抽出された輪郭データの保存領域． </param>
        /// <param name="headerSize"></param>
        /// <returns>輪郭スキャナのポインタ</returns>
#else
        /// <summary>
        /// Initializes contour scanning process
        /// </summary>
        /// <param name="storage">Container of the retrieved contours.</param>
        /// <param name="headerSize">Size of the sequence header, >=sizeof(CvChain) if method=CV_CHAIN_CODE, and >=sizeof(CvContour) otherwise. </param>
        /// <returns>CvContourScanner</returns>
#endif
        public CvContourScanner StartFindContours(CvMemStorage storage, int headerSize)
        {
            return Cv.StartFindContours(this, storage, headerSize);
        }
#if LANG_JP
        /// <summary>
        /// 輪郭走査処理の初期化を行う
        /// </summary>
        /// <param name="storage">抽出された輪郭データの保存領域． </param>
        /// <param name="headerSize">シーケンスヘッダのサイズ． method=CV_CHAIN_CODEの時， >=sizeof(CvChain) ，それ以外の場合 >=sizeof(CvContour)． </param>
        /// <param name="mode">抽出モード．</param>
        /// <returns>輪郭スキャナのポインタ</returns>
#else
        /// <summary>
        /// Initializes contour scanning process
        /// </summary>
        /// <param name="storage">Container of the retrieved contours.</param>
        /// <param name="headerSize">Size of the sequence header, >=sizeof(CvChain) if method=CV_CHAIN_CODE, and >=sizeof(CvContour) otherwise. </param>
        /// <param name="mode">Retrieval mode; see cvFindContours. </param>
        /// <returns>CvContourScanner</returns>
#endif
        public CvContourScanner StartFindContours(CvMemStorage storage, int headerSize, ContourRetrieval mode)
        {
            return Cv.StartFindContours(this, storage, headerSize, mode);
        }
#if LANG_JP
        /// <summary>
        /// 輪郭走査処理の初期化を行う
        /// </summary>
        /// <param name="storage">抽出された輪郭データの保存領域． </param>
        /// <param name="headerSize">シーケンスヘッダのサイズ． method=CV_CHAIN_CODEの時， >=sizeof(CvChain) ，それ以外の場合 >=sizeof(CvContour)． </param>
        /// <param name="mode">抽出モード．</param>
        /// <param name="method">近似手法．cvFindContoursと同様，但し CV_LINK_RUNS は使用不可． </param>
        /// <returns>輪郭スキャナのポインタ</returns>
#else
        /// <summary>
        /// Initializes contour scanning process
        /// </summary>
        /// <param name="storage">Container of the retrieved contours.</param>
        /// <param name="headerSize">Size of the sequence header, >=sizeof(CvChain) if method=CV_CHAIN_CODE, and >=sizeof(CvContour) otherwise. </param>
        /// <param name="mode">Retrieval mode; see cvFindContours. </param>
        /// <param name="method">Approximation method. It has the same meaning as in cvFindContours, but CV_LINK_RUNS can not be used here. </param>
        /// <returns>CvContourScanner</returns>
#endif
        public CvContourScanner StartFindContours(CvMemStorage storage, int headerSize, ContourRetrieval mode, ContourChain method)
        {
            return Cv.StartFindContours(this, storage, headerSize, mode, method);
        }
#if LANG_JP
        /// <summary>
        /// 輪郭走査処理の初期化を行う
        /// </summary>
        /// <param name="storage">抽出された輪郭データの保存領域． </param>
        /// <param name="headerSize">シーケンスヘッダのサイズ． method=CV_CHAIN_CODEの時， >=sizeof(CvChain) ，それ以外の場合 >=sizeof(CvContour)． </param>
        /// <param name="mode">抽出モード．</param>
        /// <param name="method">近似手法．cvFindContoursと同様，但し CV_LINK_RUNS は使用不可． </param>
        /// <param name="offset">ROIのオフセット．cvFindContoursを参照． </param>
        /// <returns>輪郭スキャナのポインタ</returns>
#else
        /// <summary>
        /// Initializes contour scanning process
        /// </summary>
        /// <param name="storage">Container of the retrieved contours.</param>
        /// <param name="headerSize">Size of the sequence header, >=sizeof(CvChain) if method=CV_CHAIN_CODE, and >=sizeof(CvContour) otherwise. </param>
        /// <param name="mode">Retrieval mode; see cvFindContours. </param>
        /// <param name="method">Approximation method. It has the same meaning as in cvFindContours, but CV_LINK_RUNS can not be used here. </param>
        /// <param name="offset">ROI offset; see cvFindContours. </param>
        /// <returns>CvContourScanner</returns>
#endif
        public CvContourScanner StartFindContours(CvMemStorage storage, int headerSize, ContourRetrieval mode, ContourChain method, CvPoint offset)
        {
            return Cv.StartFindContours(this, storage, headerSize, mode, method, offset);
        }
        #endregion
        #region Sub
#if LANG_JP
        /// <summary>
        /// 二つの配列の要素ごとの減算を行う. 
        /// dst(I)=src1(I)-src2(I) 
        /// </summary>
        /// <param name="src2">2番目の入力配列</param>
        /// <param name="dst">出力配列</param>
#else
        /// <summary>
        /// Computes per-element difference between two arrays
        /// </summary>
        /// <param name="src2">The second source array. </param>
        /// <param name="dst">The destination array. </param>
#endif
        public void Sub(CvArr src2, CvArr dst)
        {
            Cv.Sub(this, src2, dst);
        }
#if LANG_JP
        /// <summary>
        /// 二つの配列の要素ごとの減算を行う.
        /// dst(I)=src1(I)-src2(I) [mask(I)!=0 の場合]
        /// </summary>
        /// <param name="src2">2番目の入力配列</param>
        /// <param name="dst">出力配列</param>
        /// <param name="mask">処理マスク．8ビットシングルチャンネル配列（出力配列のどの要素が変更されるかを指定する）． </param>
#else
        /// <summary>
        /// Computes per-element difference between two arrays
        /// </summary>
        /// <param name="src2">The second source array. </param>
        /// <param name="dst">The destination array. </param>
        /// <param name="mask">Operation mask, 8-bit single channel array; specifies elements of destination array to be changed. </param>
#endif
        public void Sub(CvArr src2, CvArr dst, CvArr mask)
        {
            Cv.Sub(this, src2, dst, mask);
        }
        #endregion
        #region SubS
#if LANG_JP
        /// <summary>
        /// 配列要素からスカラーを減算する.
        /// dst(I) = src(I)-value 
        /// </summary>
        /// <param name="value">加算するスカラー</param>
        /// <param name="dst">出力配列</param>
#else
        /// <summary>
        /// Computes difference between array and scalar
        /// </summary>
        /// <param name="value">Subtracted scalar. </param>
        /// <param name="dst">The destination array. </param>
#endif
        public void SubS(CvScalar value, CvArr dst)
        {
            Cv.SubS(this, value, dst);
        }
#if LANG_JP
        /// <summary>
        /// 配列要素からスカラーを減算する.
        /// dst(I) = src(I)-value [mask(I)!=0]
        /// </summary>
        /// <param name="value">加算するスカラー</param>
        /// <param name="dst">出力配列</param>
        /// <param name="mask">処理マスク．8ビットシングルチャンネル配列（出力配列のどの要素が変更されるかを指定する）．</param>
#else
        /// <summary>
        /// Computes difference between array and scalar
        /// </summary>
        /// <param name="value">Subtracted scalar. </param>
        /// <param name="dst">The destination array. </param>
        /// <param name="mask">Operation mask, 8-bit single channel array; specifies elements of destination array to be changed. </param>
#endif
        public void SubS(CvScalar value, CvArr dst, CvArr mask)
        {
            Cv.SubS(this, value, dst, mask);
        }
        #endregion
        #region SubRS
#if LANG_JP
        /// <summary>
        /// スカラーから配列要素を減算する.
        /// dst(I)=value-src(I)
        /// </summary>
        /// <param name="value">加算するスカラー</param>
        /// <param name="dst">出力配列</param>
#else
        /// <summary>
        /// Computes difference between scalar and array
        /// </summary>
        /// <param name="value">Scalar to subtract from. </param>
        /// <param name="dst">The destination array. </param>
#endif
        public void SubRS(CvScalar value, CvArr dst)
        {
            Cv.SubRS(this, value, dst);
        }
#if LANG_JP
        /// <summary>
        /// スカラーから配列要素を減算する.
        /// dst(I)=value-src(I) [mask(I)!=0 の場合]
        /// </summary>
        /// <param name="value">加算するスカラー</param>
        /// <param name="dst">出力配列</param>
        /// <param name="mask">処理マスク．8ビットシングルチャンネル配列（出力配列のどの要素が変更されるかを指定する）．</param>
#else
        /// <summary>
        /// Computes difference between scalar and array
        /// </summary>
        /// <param name="value">Scalar to subtract from. </param>
        /// <param name="dst">The destination array. </param>
        /// <param name="mask">Operation mask, 8-bit single channel array; specifies elements of destination array to be changed. </param>
#endif
        public void SubRS(CvScalar value, CvArr dst, CvArr mask)
        {
            Cv.SubRS(this, value, dst, mask);
        }
        #endregion
        #region Sum
#if LANG_JP
        /// <summary>
        /// 配列要素の総和を計算する.
        /// 配列のタイプが IplImage で COI がセットされている場合，指定されたチャンネルのみを処理し，総和を１番目のスカラー値（S0）として保存する．
        /// </summary>
        /// <returns></returns>
#else
        /// <summary>
        /// Summarizes array elements
        /// </summary>
        /// <returns>sum S of array elements, independently for each channel</returns>
#endif
        public CvScalar Sum()
        {
            return Cv.Sum(this);
        }
        #endregion
        #region SVD
#if LANG_JP
        /// <summary>
        /// 浮動小数点型の実数行列の特異値分解を行う.
        /// 行列Aを二つの直交行列と一つの対角行列の積に分解する．A=U*W*VT
        /// </summary>
        /// <param name="w">特異値行列の結果 (M×N または N×N)またはベクトル（N×1）．</param>
#else
        /// <summary>
        /// Performs singular value decomposition of real floating-point matrix
        /// </summary>
        /// <param name="w">Resulting singular value matrix (M×N or N×N) or vector (N×1). </param>
#endif
        public void SVD(CvArr w)
        {
            Cv.SVD(this, w);
        }
#if LANG_JP
        /// <summary>
        /// 浮動小数点型の実数行列の特異値分解を行う.
        /// 行列Aを二つの直交行列と一つの対角行列の積に分解する．A=U*W*VT
        /// </summary>
        /// <param name="w">特異値行列の結果 (M×N または N×N)またはベクトル（N×1）．</param>
        /// <param name="u">任意の左直交行列 (M×M または M×N)．もしCV_SVD_U_Tが指定された場合，上で述べた，行と列の数は入れ替わる．</param>
#else
        /// <summary>
        /// Performs singular value decomposition of real floating-point matrix
        /// </summary>
        /// <param name="w">Resulting singular value matrix (M×N or N×N) or vector (N×1). </param>
        /// <param name="u">Optional left orthogonal matrix (M×M or M×N). If CV_SVD_U_T is specified, the number of rows and columns in the sentence above should be swapped. </param>
#endif
        public void SVD(CvArr w, CvArr u)
        {
            Cv.SVD(this, w, u);
        }
#if LANG_JP
        /// <summary>
        /// 浮動小数点型の実数行列の特異値分解を行う.
        /// 行列Aを二つの直交行列と一つの対角行列の積に分解する．A=U*W*VT
        /// </summary>
        /// <param name="w">特異値行列の結果 (M×N または N×N)またはベクトル（N×1）．</param>
        /// <param name="u">任意の左直交行列 (M×M または M×N)．もしCV_SVD_U_Tが指定された場合，上で述べた，行と列の数は入れ替わる．</param>
        /// <param name="v">任意の右直交行列（N×N)．</param>
#else
        /// <summary>
        /// Performs singular value decomposition of real floating-point matrix
        /// </summary>
        /// <param name="w">Resulting singular value matrix (M×N or N×N) or vector (N×1). </param>
        /// <param name="u">Optional left orthogonal matrix (M×M or M×N). If CV_SVD_U_T is specified, the number of rows and columns in the sentence above should be swapped. </param>
        /// <param name="v">Optional right orthogonal matrix (N×N) </param>
#endif
        public void SVD(CvArr w, CvArr u, CvArr v)
        {
            Cv.SVD(this, w, u, v);
        }
#if LANG_JP
        /// <summary>
        /// 浮動小数点型の実数行列の特異値分解を行う.
        /// 行列Aを二つの直交行列と一つの対角行列の積に分解する．A=U*W*VT
        /// </summary>
        /// <param name="w">特異値行列の結果 (M×N または N×N)またはベクトル（N×1）．</param>
        /// <param name="u">任意の左直交行列 (M×M または M×N)．もしCV_SVD_U_Tが指定された場合，上で述べた，行と列の数は入れ替わる．</param>
        /// <param name="v">任意の右直交行列（N×N)．</param>
        /// <param name="flags">操作フラグ</param>
#else
        /// <summary>
        /// Performs singular value decomposition of real floating-point matrix
        /// </summary>
        /// <param name="w">Resulting singular value matrix (M×N or N×N) or vector (N×1). </param>
        /// <param name="u">Optional left orthogonal matrix (M×M or M×N). If CV_SVD_U_T is specified, the number of rows and columns in the sentence above should be swapped. </param>
        /// <param name="v">Optional right orthogonal matrix (N×N) </param>
        /// <param name="flags">Operation flags</param>
#endif
        public void SVD(CvArr w, CvArr u, CvArr v, SVDFlag flags)
        {
            Cv.SVD(this, w, u, v, flags);
        }
        #endregion
        #region Threshold
#if LANG_JP
        /// <summary>
        /// シングルチャンネルの配列に対して，固定閾値での閾値処理を行う
        /// </summary>
        /// <param name="dst">出力配列．src と同じデータタイプ，または8ビット． </param>
        /// <param name="threshold">閾値</param>
        /// <param name="maxValue">threshold_type が Binary と BinaryInv のときに使用する最大値</param>
        /// <param name="thresholdType">閾値処理の種類</param>
#else
        /// <summary>
        /// Applies fixed-level threshold to array elements.
        /// </summary>
        /// <param name="dst">Destination array; must be either the same type as src or 8-bit. </param>
        /// <param name="threshold">Threshold value. </param>
        /// <param name="maxValue">Maximum value to use with CV_THRESH_BINARY and CV_THRESH_BINARY_INV thresholding types. </param>
        /// <param name="thresholdType">Thresholding type.</param>
#endif
        public void Threshold(CvArr dst, double threshold, double maxValue, ThresholdType thresholdType)
        {
            Cv.Threshold(this, dst, threshold, maxValue, thresholdType);
        }
        #endregion
        #region Trace
#if LANG_JP
        /// <summary>
        /// 行列のトレース(対角成分の和)を返す
        /// </summary>
        /// <returns>対角成分の和</returns>
#else
        /// <summary>
        /// Returns trace of matrix
        /// </summary>
        /// <returns>sum of diagonal elements of the matrix src1</returns>
#endif
        public CvScalar Trace()
        {
            return Cv.Trace(this);
        }
        #endregion
        #region Transpose
#if LANG_JP
        /// <summary>
        /// 行列の転置を行う.
        /// </summary>
        /// <param name="dst">出力行列</param>
#else
        /// <summary>
        /// Transposes matrix
        /// </summary>
        /// <param name="dst">The destination matrix. </param>
#endif
        public void Transpose(CvArr dst)
        {
            Cv.Transpose(this, dst);
        }
#if LANG_JP
        /// <summary>
        /// 行列の転置を行う.
        /// </summary>
        /// <param name="dst">出力行列</param>
#else
        /// <summary>
        /// Transposes matrix
        /// </summary>
        /// <param name="dst">The destination matrix. </param>
#endif
        public void T(CvArr dst)
        {
            Cv.T(this, dst);
        }
        #endregion
        #region Undistort2
#if LANG_JP
        /// <summary>
        /// 半径方向や円周方向のレンズ歪みを補正するために画像を変換する．
        /// </summary>
        /// <param name="dst">出力画像（補正済み）</param>
        /// <param name="intrinsicMatrix">カメラ内部行列 (A) [fx 0 cx; 0 fy cy; 0 0 1]. </param>
        /// <param name="distortionCoeffs">歪み係数ベクトル． 4x1 または 1x4 [k1, k2, p1, p2]. </param>
#else
        /// <summary>
        /// Transforms image to compensate lens distortion.
        /// </summary>
        /// <param name="dst">The output (corrected) image. </param>
        /// <param name="intrinsicMatrix">The camera matrix (A) [fx 0 cx; 0 fy cy; 0 0 1]. </param>
        /// <param name="distortionCoeffs">The vector of distortion coefficients, 4x1 or 1x4 [k1, k2, p1, p2]. </param>
#endif
        public void Undistort2(CvArr dst, CvMat intrinsicMatrix, CvMat distortionCoeffs)
        {
            Cv.Undistort2(this, dst, intrinsicMatrix, distortionCoeffs);
        }
#if LANG_JP
        /// <summary>
        /// 半径方向や円周方向のレンズ歪みを補正するために画像を変換する．
        /// </summary>
        /// <param name="dst">出力画像（補正済み）</param>
        /// <param name="intrinsicMatrix">カメラ内部行列 (A) [fx 0 cx; 0 fy cy; 0 0 1]. </param>
        /// <param name="distortionCoeffs">歪み係数ベクトル． 4x1 または 1x4 [k1, k2, p1, p2]. </param>
        /// <param name="newCameraMatrix"></param>
#else
        /// <summary>
        /// Transforms image to compensate lens distortion.
        /// </summary>
        /// <param name="dst">The output (corrected) image. </param>
        /// <param name="intrinsicMatrix">The camera matrix (A) [fx 0 cx; 0 fy cy; 0 0 1]. </param>
        /// <param name="distortionCoeffs">The vector of distortion coefficients, 4x1 or 1x4 [k1, k2, p1, p2]. </param>
        /// <param name="newCameraMatrix"></param>
#endif
        public void Undistort2(CvArr dst, CvMat intrinsicMatrix, CvMat distortionCoeffs, CvMat newCameraMatrix)
        {
            Cv.Undistort2(this, dst, intrinsicMatrix, distortionCoeffs, newCameraMatrix);
        }
        #endregion
        #region ValidateDisparity
#if LANG_JP
        /// <summary>
        /// 
        /// </summary>
        /// <param name="cost"></param>
        /// <param name="minDisparity"></param>
        /// <param name="numberOfDisparities"></param>
#else
        /// <summary>
        /// 
        /// </summary>
        /// <param name="cost"></param>
        /// <param name="minDisparity"></param>
        /// <param name="numberOfDisparities"></param>
#endif
        public void ValidateDisparity(CvArr cost, int minDisparity, int numberOfDisparities)
        {
            Cv.ValidateDisparity(this, cost, minDisparity, numberOfDisparities);
        }
#if LANG_JP
        /// <summary>
        /// 
        /// </summary>
        /// <param name="cost"></param>
        /// <param name="minDisparity"></param>
        /// <param name="numberOfDisparities"></param>
        /// <param name="disp12MaxDiff"></param>
#else
        /// <summary>
        /// 
        /// </summary>
        /// <param name="cost"></param>
        /// <param name="minDisparity"></param>
        /// <param name="numberOfDisparities"></param>
        /// <param name="disp12MaxDiff"></param>
#endif
        public void ValidateDisparity(CvArr cost, int minDisparity, int numberOfDisparities, int disp12MaxDiff)
        {
            Cv.ValidateDisparity(this, cost, minDisparity, numberOfDisparities, disp12MaxDiff);
        }
        #endregion
        #region WarpPerspective
#if LANG_JP
        /// <summary>
        /// 画像の透視変換を行う.
        /// </summary>
        /// <param name="dst">出力画像</param>
        /// <param name="mapMatrix">3×3 の変換行列</param>
#else
        /// <summary>
        /// Applies perspective transformation to the image.
        /// </summary>
        /// <param name="dst">Destination image. </param>
        /// <param name="mapMatrix">3x3 transformation matrix. </param>
#endif
        public void WarpPerspective(CvArr dst, CvMat mapMatrix)
        {
            Cv.WarpPerspective(this, dst, mapMatrix);
        }
#if LANG_JP
        /// <summary>
        /// 画像の透視変換を行う.
        /// </summary>
        /// <param name="dst">出力画像</param>
        /// <param name="mapMatrix">3×3 の変換行列</param>
        /// <param name="flags">補間方法</param>
#else
        /// <summary>
        /// Applies perspective transformation to the image.
        /// </summary>
        /// <param name="dst">Destination image. </param>
        /// <param name="mapMatrix">3x3 transformation matrix. </param>
        /// <param name="flags">A combination of interpolation method and the optional flags.</param>
#endif
        public void WarpPerspective(CvArr dst, CvMat mapMatrix, Interpolation flags)
        {
            Cv.WarpPerspective(this, dst, mapMatrix, flags);
        }
#if LANG_JP
        /// <summary>
        /// 画像の透視変換を行う.
        /// </summary>
        /// <param name="dst">出力画像</param>
        /// <param name="mapMatrix">3×3 の変換行列</param>
        /// <param name="flags">補間方法</param>
        /// <param name="fillval">対応の取れない点に対して与える値</param>
#else
        /// <summary>
        /// Applies perspective transformation to the image.
        /// </summary>
        /// <param name="dst">Destination image. </param>
        /// <param name="mapMatrix">3x3 transformation matrix. </param>
        /// <param name="flags">A combination of interpolation method and the optional flags.</param>
        /// <param name="fillval">A value used to fill outliers. </param>
#endif
        public void WarpPerspective(CvArr dst, CvMat mapMatrix, Interpolation flags, CvScalar fillval)
        {
            Cv.WarpPerspective(this, dst, mapMatrix, flags, fillval);
        }
        #endregion
        #region Watershed
#if LANG_JP
        /// <summary>
        /// watershedアルゴリズムによる画像のセグメント化を行う.
        /// 画像をこの関数に渡す前に，ユーザーは大まかに画像markers中の処理対象領域を，正（>0）のインデックスを用いて区切っておかなければならない．
        /// </summary>
        /// <param name="markers">入出力画像．32ビットシングルチャンネルのマーカー画像（マップ）.</param>
#else
        /// <summary>
        /// Does watershed segmentation.
        /// </summary>
        /// <param name="markers">The input/output 32-bit single-channel image (map) of markers. </param>
#endif
        public void Watershed(CvArr markers)
        {
            Cv.Watershed(this, markers);
        }
        #endregion
        #region Xor
#if LANG_JP
        /// <summary>
        /// 二つの配列の要素ごとの排他的論理和（XOR）を計算する. 
        /// dst(I)=src1(I)^src2(I)
        /// </summary>
        /// <param name="src2">2番目の入力配列</param>
        /// <param name="dst">出力配列</param>
#else
        /// <summary>
        /// Performs per-element bit-wise "exclusive or" operation on two arrays
        /// </summary>
        /// <param name="src2">The second source array. </param>
        /// <param name="dst">The destination array. </param>am>
#endif
        public void Xor(CvArr src2, CvArr dst)
        {
            Cv.Xor(this, src2, dst);
        }
#if LANG_JP
        /// <summary>
        /// 二つの配列の要素ごとの排他的論理和（XOR）を計算する. 
        /// dst(I)=src1(I)^src2(I) [mask(I)!=0の場合]
        /// </summary>
        /// <param name="src2">2番目の入力配列</param>
        /// <param name="dst">出力配列</param>
        /// <param name="mask">処理マスク．8ビットシングルチャンネル配列（出力配列のどの要素が変更されるかを指定する）． </param>
#else
        /// <summary>
        /// Performs per-element bit-wise "exclusive or" operation on two arrays
        /// </summary>
        /// <param name="src2">The second source array. </param>
        /// <param name="dst">The destination array. </param>
        /// <param name="mask">Operation mask, 8-bit single channel array; specifies elements of destination array to be changed. </param>
#endif
        public void Xor(CvArr src2, CvArr dst, CvArr mask)
        {
            Cv.Xor(this, src2, dst, mask);
        }
        #endregion
        #region XorS
#if LANG_JP
        /// <summary>
        /// 配列の各要素とスカラーとのビット単位の排他的論理和(XOR)を計算する.
        /// 実際の計算の前に，スカラーは配列と同じタイプに変換される．浮動小数点型配列の場合，それらのビット表現が処理に使われる．
        /// dst(I)=src(I)^value
        /// </summary>
        /// <param name="value">処理に用いるスカラー</param>
        /// <param name="dst">出力配列</param>
#else
        /// <summary>
        /// Performs per-element bit-wise "exclusive or" operation on array and scalar
        /// </summary>
        /// <param name="value">Scalar to use in the operation. </param>
        /// <param name="dst">The destination array. </param>
#endif
        public void XorS(CvScalar value, CvArr dst)
        {
            Cv.XorS(this, value, dst);
        }
#if LANG_JP
        /// <summary>
        /// 配列の各要素とスカラーとのビット単位の排他的論理和(XOR)を計算する. 
        /// 実際の計算の前に，スカラーは配列と同じタイプに変換される．浮動小数点型配列の場合，それらのビット表現が処理に使われる．
        /// dst(I)=src(I)^value [mask(I)!=0の場合]
        /// </summary>
        /// <param name="value">処理に用いるスカラー</param>
        /// <param name="dst">出力配列</param>
        /// <param name="mask">処理マスク．8ビットシングルチャンネル配列（出力配列のどの要素が変更されるかを指定する）．</param>
#else
        /// <summary>
        /// Performs per-element bit-wise "exclusive or" operation on array and scalar
        /// </summary>
        /// <param name="value">Scalar to use in the operation. </param>
        /// <param name="dst">The destination array. </param>
        /// <param name="mask">Operation mask, 8-bit single channel array; specifies elements of destination array to be changed. </param>
#endif
        public void XorS(CvScalar value, CvArr dst, CvArr mask)
        {
            Cv.XorS(this, value, dst, mask);
        }
        #endregion
    }
}
