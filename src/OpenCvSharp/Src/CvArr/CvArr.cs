using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;

namespace OpenCvSharp
{
#if LANG_JP
    /// <summary>
    /// IplImage, CvMatなどの各種配列データの基本クラス. 実体は void* 
    /// </summary>
#else
    /// <summary>
    /// Arbitrary array
    /// </summary>
#endif
    abstract public partial class CvArr : DisposableCvObject
    {
        #region Initialization and Disposal
#if LANG_JP
        /// <summary>
        /// デフォルトコンストラクタ
        /// </summary>
#else
        /// <summary>
        /// Default constructor
        /// </summary>
#endif
        internal CvArr()
        {
        }
#if LANG_JP
        /// <summary>
        /// 解放の可否を指定して初期化
        /// </summary>
        /// <param name="isEnabledDispose">GCで解放するならtrue</param>
#else
        /// <summary>
        /// Constructor 
        /// </summary>
        /// <param name="isEnabledDispose">If true, this matrix will be disposed by GC automatically.</param>
#endif
        internal CvArr(bool isEnabledDispose)
            : base(isEnabledDispose)
        {
        }
#if LANG_JP
        /// <summary>
        /// リソースの解放
        /// </summary>
        /// <param name="disposing">
        /// trueの場合は、このメソッドがユーザコードから直接が呼ばれたことを示す。マネージ・アンマネージ双方のリソースが解放される。
        /// falseの場合は、このメソッドはランタイムからファイナライザによって呼ばれ、もうほかのオブジェクトから参照されていないことを示す。アンマネージリソースのみ解放される。
        ///</param>
#else
        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">
        /// If disposing equals true, the method has been called directly or indirectly by a user's code. Managed and unmanaged resources can be disposed.
        /// If false, the method has been called by the runtime from inside the finalizer and you should not reference other objects. Only unmanaged resources can be disposed.
        /// </param>
#endif
        protected override void Dispose(bool disposing)
        {
            // 親の解放処理
            base.Dispose(disposing);
        }
        #endregion

        #region Properties

#if LANG_JP
        /// <summary>
		/// 配列の次元数を取得する 
        /// </summary>
#else
        /// <summary>
        /// Get number of dimensions
        /// </summary>
#endif
        public virtual Int32 Dims
        {
            get { return Cv.GetDims(this); }
        }
#if LANG_JP
		/// <summary>
		/// 配列要素のタイプを取得する 
        /// </summary>
#else
        /// <summary>
        /// Get type of the array
        /// </summary>
#endif
        public virtual MatrixType ElemType
        {
            get { return (MatrixType)NativeMethods.cvGetElemType(CvPtr); }
        }
#if LANG_JP
        /// <summary>
		/// 配列要素のチャンネル数を取得する. 
        /// </summary>
#else
        /// <summary>
        /// Get number of channels
        /// </summary>
#endif
        public virtual int ElemChannels
        {
            get
            {
                switch (ElemType)
                {
                    case MatrixType.F32C1:
                    case MatrixType.F64C1:
                    case MatrixType.S16C1:
                    case MatrixType.S32C1:
                    case MatrixType.S8C1:
                    case MatrixType.U16C1:
                    case MatrixType.U8C1:
                        return 1;
                    case MatrixType.F32C2:
                    case MatrixType.F64C2:
                    case MatrixType.S16C2:
                    case MatrixType.S32C2:
                    case MatrixType.S8C2:
                    case MatrixType.U16C2:
                    case MatrixType.U8C2:
                        return 2;
                    case MatrixType.F32C3:
                    case MatrixType.F64C3:
                    case MatrixType.S16C3:
                    case MatrixType.S32C3:
                    case MatrixType.S8C3:
                    case MatrixType.U16C3:
                    case MatrixType.U8C3:
                        return 3;
                    case MatrixType.F32C4:
                    case MatrixType.F64C4:
                    case MatrixType.S16C4:
                    case MatrixType.S32C4:
                    case MatrixType.S8C4:
                    case MatrixType.U16C4:
                    case MatrixType.U8C4:
                        return 4;
                    default:
                        return -1;
                }
            }
        }
#if LANG_JP
        /// <summary>
        /// 配列要素のビット深度を取得する. 
        /// </summary>
#else
        /// <summary>
        /// Get bit Depth
        /// </summary>
#endif
        public virtual int ElemDepth
        {
            get
            {
                switch (ElemType)
                {
                    case MatrixType.U8C1:
                    case MatrixType.U8C2:
                    case MatrixType.U8C3:
                    case MatrixType.U8C4:
                    case MatrixType.S8C1:
                    case MatrixType.S8C2:
                    case MatrixType.S8C3:
                    case MatrixType.S8C4:
                        return 8;
                    case MatrixType.U16C1:
                    case MatrixType.U16C2:
                    case MatrixType.U16C3:
                    case MatrixType.U16C4:
                    case MatrixType.S16C1:
                    case MatrixType.S16C2:
                    case MatrixType.S16C3:
                    case MatrixType.S16C4:
                        return 16;
                    case MatrixType.F32C1:
                    case MatrixType.F32C2:
                    case MatrixType.F32C3:
                    case MatrixType.F32C4:
                    case MatrixType.S32C1:
                    case MatrixType.S32C2:
                    case MatrixType.S32C3:
                    case MatrixType.S32C4:
                        return 32;
                    case MatrixType.F64C1:
                    case MatrixType.F64C2:
                    case MatrixType.F64C3:
                    case MatrixType.F64C4:
                        return 64;
                    default:
                        // んなバカな
                        throw new NotSupportedException();
                }
            }
        }

#if LANG_JP
        /// <summary>
		/// 特定の配列要素を返す (cvGet/Set1D相当). 
		/// 比較的低速なため、高速にアクセスしたい場合はこのメソッドではなくポインタを利用すること。
		/// </summary>
		/// <param name="idx0">要素インデックスの，0を基準とした第1成分．</param>
#else
        /// <summary>
        /// Return the particular array element (cvGet1D/Set1D)
        /// </summary>
        /// <param name="idx0">The first zero-based component of the element index </param>
        /// <returns></returns>
#endif
        public virtual CvScalar this[int idx0]
        {
            get
            {
                return Cv.Get1D(this, idx0);
            }
            set
            {
                Cv.Set1D(this, idx0, value);
            }
        }
#if LANG_JP
		/// <summary>
		/// 特定の配列要素を返す (cvGet/Set2D相当). 
		/// 比較的低速なため、高速にアクセスしたい場合はこのメソッドではなくポインタを利用すること。
		/// </summary>
		/// <param name="idx0">要素インデックスの，0を基準とした第1成分．</param>
        /// <param name="idx1">要素インデックスの，0を基準とした第2成分．</param>
#else
        /// <summary>
        /// Return the particular array element (cvGet2D/Set2D)
        /// </summary>
        /// <param name="idx0">The first zero-based component of the element index </param>
        /// <param name="idx1">The second zero-based component of the element index </param>
        /// <returns></returns>
#endif
        public virtual CvScalar this[int idx0, int idx1]
        {
            get
            {
                return Cv.Get2D(this, idx0, idx1);
            }
            set
            {
                Cv.Set2D(this, idx0, idx1, value);
            }
        }
#if LANG_JP
		/// <summary>
		/// 特定の配列要素を返す (cvGet/Set3D相当). 
		/// 比較的低速なため、高速にアクセスしたい場合はこのメソッドではなくポインタを利用すること。
		/// </summary>
		/// <param name="idx0">要素インデックスの，0を基準とした第1成分．</param>
		/// <param name="idx1">要素インデックスの，0を基準とした第2成分．</param>
        /// <param name="idx2">要素インデックスの，0を基準とした第3成分．</param>
#else
        /// <summary>
        /// Return the particular array element (cvGet3D/Set3D)
        /// </summary>
        /// <param name="idx0">The first zero-based component of the element index </param>
        /// <param name="idx1">The second zero-based component of the element index </param>
        /// <param name="idx2">The third zero-based component of the element index </param>
        /// <returns></returns>
#endif
        public virtual CvScalar this[int idx0, int idx1, int idx2]
        {
            get
            {
                return Cv.Get3D(this, idx0, idx1, idx2);
            }
            set
            {
                Cv.Set3D(this, idx0, idx1, idx2, value);
            }
        }
        #endregion

        #region Methods
        #region HoughLinesStandard
#if LANG_JP
        /// <summary>
        /// ハフ（Hough）変換で、method=CV_HOUGH_STANDARDを用いて2値画像から直線を検出する
        /// </summary>
        /// <param name="rho">距離解像度（１ピクセル当たりの単位）</param>
        /// <param name="theta">角度解像度（ラジアン単位で計測）</param>
        /// <param name="threshold">閾値パラメータ．対応する投票数がthresholdより大きい場合のみ，抽出された線が返される．</param>
        /// <returns>検出した直線の極座標形式、の配列</returns>
#else
        /// <summary>
        /// Finds lines in binary image using Hough transform.
        /// </summary>
        /// <param name="rho">Distance resolution in pixel-related units. </param>
        /// <param name="theta">Angle resolution measured in radians. </param>
        /// <param name="threshold">Threshold parameter. A line is returned by the function if the corresponding accumulator value is greater than threshold. </param>
        /// <returns></returns>
#endif
        public CvLineSegmentPolar[] HoughLinesStandard(double rho, double theta, int threshold)
        {
            return HoughLinesStandard(rho, theta, threshold, 0, 0);
        }
#if LANG_JP
        /// <summary>
        /// ハフ（Hough）変換で、method=CV_HOUGH_STANDARDを用いて2値画像から直線を検出する
        /// </summary>
        /// <param name="rho">距離解像度（１ピクセル当たりの単位）</param>
        /// <param name="theta">角度解像度（ラジアン単位で計測）</param>
        /// <param name="threshold">閾値パラメータ．対応する投票数がthresholdより大きい場合のみ，抽出された線が返される．</param>
        /// <param name="param1">各手法に応じた１番目のパラメータ．標準的ハフ変換では，使用しない（0）．確率的ハフ変換では，最小の線の長さ．マルチスケールハフ変換では， 距離解像度rhoの除数．（荒い距離解像度では rho であり，詳細な解像度では (rho / param1) となる）．</param>
        /// <param name="param2">各手法に応じた２番目のパラメータ．標準的ハフ変換では，使用しない（0）．確率的ハフ変換では，同一線上に存在する線分として扱う（つまり，それらを統合しても問題ない），二つの線分の最大の間隔． マルチスケールハフ変換では，角度解像度 thetaの除数． （荒い角度解像度では theta であり，詳細な解像度では (theta / param2) となる）． </param>
        /// <returns>検出した直線の極座標形式、の配列</returns>
#else
        /// <summary>
        /// Finds lines in binary image using Hough transform.
        /// </summary>
        /// <param name="rho">Distance resolution in pixel-related units. </param>
        /// <param name="theta">Angle resolution measured in radians. </param>
        /// <param name="threshold">Threshold parameter. A line is returned by the function if the corresponding accumulator value is greater than threshold. </param>
        /// <param name="param1">The first method-dependent parameter.</param>
        /// <param name="param2">The second method-dependent parameter.</param>
        /// <returns></returns>
#endif
        public CvLineSegmentPolar[] HoughLinesStandard(double rho, double theta, int threshold, double param1, double param2)
        {
            using (CvMemStorage lineStorage = new CvMemStorage())
            {
                IntPtr result = NativeMethods.cvHoughLines2(CvPtr, lineStorage.CvPtr, HoughLinesMethod.Standard, rho, theta, threshold, param1, param2);
                if (result == IntPtr.Zero)
                    throw new OpenCvSharpException();
                
                CvSeq<CvLineSegmentPolar> seq = new CvSeq<CvLineSegmentPolar>(result);
                return seq.ToArray();
            }
        }
        #endregion
        #region HoughLinesProbabilistic
#if LANG_JP
        /// <summary>
        /// ハフ（Hough）変換で、method=CV_HOUGH_PROBABILISTICを用いて2値画像から直線を検出する
        /// </summary>
        /// <param name="rho">距離解像度（１ピクセル当たりの単位）</param>
        /// <param name="theta">角度解像度（ラジアン単位で計測）</param>
        /// <param name="threshold">閾値パラメータ．対応する投票数がthresholdより大きい場合のみ，抽出された線が返される．</param>
        /// <returns>検出した直線を両端の点で表した形式、の配列</returns>
#else
        /// <summary>
        /// Finds lines in binary image using Hough transform.
        /// </summary>
        /// <param name="rho">Distance resolution in pixel-related units. </param>
        /// <param name="theta">Angle resolution measured in radians. </param>
        /// <param name="threshold">Threshold parameter. A line is returned by the function if the corresponding accumulator value is greater than threshold. </param>
        /// <returns></returns>
#endif
        public CvLineSegmentPoint[] HoughLinesProbabilistic(double rho, double theta, int threshold)
        {
            return HoughLinesProbabilistic(rho, theta, threshold, 0, 0);
        }
#if LANG_JP
        /// <summary>
        /// ハフ（Hough）変換で、method=CV_HOUGH_PROBABILISTICを用いて2値画像から直線を検出する
        /// </summary>
        /// <param name="rho">距離解像度（１ピクセル当たりの単位）</param>
        /// <param name="theta">角度解像度（ラジアン単位で計測）</param>
        /// <param name="threshold">閾値パラメータ．対応する投票数がthresholdより大きい場合のみ，抽出された線が返される．</param>
        /// <param name="param1">各手法に応じた１番目のパラメータ．標準的ハフ変換では，使用しない（0）．確率的ハフ変換では，最小の線の長さ．マルチスケールハフ変換では， 距離解像度rhoの除数．（荒い距離解像度では rho であり，詳細な解像度では (rho / param1) となる）．</param>
        /// <param name="param2">各手法に応じた２番目のパラメータ．標準的ハフ変換では，使用しない（0）．確率的ハフ変換では，同一線上に存在する線分として扱う（つまり，それらを統合しても問題ない），二つの線分の最大の間隔． マルチスケールハフ変換では，角度解像度 thetaの除数． （荒い角度解像度では theta であり，詳細な解像度では (theta / param2) となる）． </param>
        /// <returns>検出した直線を両端の点で表した形式、の配列</returns>
#else
        /// <summary>
        /// Finds lines in binary image using Hough transform.
        /// </summary>
        /// <param name="rho">Distance resolution in pixel-related units. </param>
        /// <param name="theta">Angle resolution measured in radians. </param>
        /// <param name="threshold">Threshold parameter. A line is returned by the function if the corresponding accumulator value is greater than threshold. </param>
        /// <param name="param1">The first method-dependent parameter.</param>
        /// <param name="param2">The second method-dependent parameter.</param>
        /// <returns></returns>
#endif
        public CvLineSegmentPoint[] HoughLinesProbabilistic(double rho, double theta, int threshold, double param1, double param2)
        {
            using (CvMemStorage lineStorage = new CvMemStorage())
            {
                IntPtr result = NativeMethods.cvHoughLines2(CvPtr, lineStorage.CvPtr, HoughLinesMethod.Probabilistic, rho, theta, threshold, param1, param2);
                if (result == IntPtr.Zero)
                    throw new OpenCvSharpException();
                
                CvSeq<CvLineSegmentPoint> seq = new CvSeq<CvLineSegmentPoint>(result);
                return seq.ToArray();
            }
        }
        #endregion
        #region Merge
#if LANG_JP
        /// <summary>
        /// 複数のシングルチャンネルの配列からマルチチャンネル配列を構成する．または，配列に一つのシングルチャンネルを挿入する. (cvMerge)
        /// </summary>
        /// <param name="src0">入力配列1</param>
        /// <param name="src1">入力配列2</param>
        /// <param name="src2">入力配列3</param>
        /// <param name="src3">入力配列4</param>
#else
        /// <summary>
        /// Composes multi-channel array from several single-channel arrays or inserts a single channel into the array. (cvMerge)
        /// </summary>
        /// <param name="src0">Input channel 0</param>
        /// <param name="src1">Input channel 1</param>
        /// <param name="src2">Input channel 2</param>
        /// <param name="src3">Input channel 3</param>
#endif
        public void Merge(CvArr src0, CvArr src1, CvArr src2, CvArr src3)
        {
            Cv.Merge(src0, src1, src2, src3, this);
        }
#if LANG_JP
        /// <summary>
        /// 複数のシングルチャンネルの配列からマルチチャンネル配列を構成する．または，配列に一つのシングルチャンネルを挿入する. (cvCvtPlaneToPix)
        /// </summary>
        /// <param name="src0">入力配列1</param>
        /// <param name="src1">入力配列2</param>
        /// <param name="src2">入力配列3</param>
        /// <param name="src3">入力配列4</param>
#else
        /// <summary>
        /// Composes multi-channel array from several single-channel arrays or inserts a single channel into the array. (cvCvtPlaneToPix)
        /// </summary>
        /// <param name="src0">Input channel 0</param>
        /// <param name="src1">Input channel 1</param>
        /// <param name="src2">Input channel 2</param>
        /// <param name="src3">Input channel 3</param>
#endif
        public void CvtPlaneToPix(CvArr src0, CvArr src1, CvArr src2, CvArr src3)
        {
            Cv.CvtPlaneToPix(src0, src1, src2, src3, this);
        }
        #endregion
        #region RandArr
#if LANG_JP
        /// <summary>
        /// 一様または正規分布の乱数で出力配列を埋める 
        /// </summary>
        /// <param name="rng">cvRNGによって初期化されたRNGの状態</param>
        /// <param name="distType">分布のタイプ</param>
        /// <param name="param1">分布の第一パラメータ．一様分布では，発生する乱数の下限値（この値を含む）である． 正規分布では，乱数の平均値である．</param>
        /// <param name="param2">分布の第二パラメータ．一様分布では，発生する乱数の上限値（この値は含まない）である． 正規分布では，乱数の標準偏差である．</param>
#else
        /// <summary>
        /// Fills array with random numbers and updates the RNG state
        /// </summary>
        /// <param name="rng">RNG state initialized by cvRNG. </param>
        /// <param name="distType">Distribution type.</param>
        /// <param name="param1">The first parameter of distribution. In case of uniform distribution it is the inclusive lower boundary of random numbers range. In case of normal distribution it is the mean value of random numbers. </param>
        /// <param name="param2">The second parameter of distribution. In case of uniform distribution it is the exclusive upper boundary of random numbers range. In case of normal distribution it is the standard deviation of random numbers. </param>
#endif
        public void RandArr(CvRNG rng, DistributionType distType, CvScalar param1, CvScalar param2)
        {
            Cv.RandArr(rng, this, distType, param1, param2);
        }
        #endregion
        #region SaveImage
#if LANG_JP
        /// <summary>
        /// 画像を指定したファイルに保存する．画像フォーマットは，filename の拡張子により決定される．
        /// この関数で保存できるのは，8 ビット 1チャンネル，あるいは 8 ビット3 チャンネル（'BGR' の順）画像だけである．
        /// </summary>
        /// <param name="filename">ファイル名</param>
        /// <returns></returns>
#else
        /// <summary>
        /// Saves the image to the specified file. The image format is chosen depending on the filename extension, see cvLoadImage. 
        /// Only 8-bit single-channel or 3-channel (with 'BGR' channel order) images can be saved using this function. 
        /// </summary>
        /// <param name="filename">Name of the file. </param>
        /// <returns></returns>
#endif
        public int SaveImage(string filename)
        {
            return Cv.SaveImage(filename, this);
        }
#if LANG_JP
        /// <summary>
        /// 画像を指定したファイルに保存する．画像フォーマットは，filename の拡張子により決定される．
        /// この関数で保存できるのは，8 ビット 1チャンネル，あるいは 8 ビット3 チャンネル（'BGR' の順）画像だけである．
        /// </summary>
        /// <param name="fileName">ファイル名</param>
        /// <param name="prms"></param>
        /// <returns></returns>
#else
        /// <summary>
        /// Saves the image to the specified file. The image format is chosen depending on the filename extension, see cvLoadImage. 
        /// Only 8-bit single-channel or 3-channel (with 'BGR' channel order) images can be saved using this function. 
        /// </summary>
        /// <param name="fileName">Name of the file. </param>
        /// <param name="prms"></param>
        /// <returns></returns>
#endif
        public int SaveImage(string fileName, int[] prms)
        {
            return Cv.SaveImage(fileName, this, prms);
        }
#if LANG_JP
        /// <summary>
        /// 画像を指定したファイルに保存する．画像フォーマットは，filename の拡張子により決定される．
        /// この関数で保存できるのは，8 ビット 1チャンネル，あるいは 8 ビット3 チャンネル（'BGR' の順）画像だけである．
        /// </summary>
        /// <param name="fileName">ファイル名</param>
        /// <param name="prms"></param>
        /// <returns></returns>
#else
        /// <summary>
        /// Saves the image to the specified file. The image format is chosen depending on the filename extension, see cvLoadImage. 
        /// Only 8-bit single-channel or 3-channel (with 'BGR' channel order) images can be saved using this function. 
        /// </summary>
        /// <param name="fileName">Name of the file. </param>
        /// <param name="prms"></param>
        /// <returns></returns>
#endif
        public int SaveImage(string fileName, params ImageEncodingParam[] prms)
        {
            return Cv.SaveImage(fileName, this, prms);
        }
        #endregion
        #region ToBytes
#if LANG_JP
        /// <summary>
        /// cvEncodeImageにより、この画像をメモリ上に展開する
        /// </summary>
        /// <param name="ext">拡張子。.jpgや.pngなど。これによりエンコード形式が決定される。</param>
        /// <param name="encodingParams">JPEGの圧縮率などのエンコード設定</param>
        /// <returns></returns>
#else
        /// <summary>
        /// Extract this image to the memory using cvEncodeImage
        /// </summary>
        /// <param name="ext">Image extension to decide encoding format.</param>
        /// <param name="encodingParams">Encoding options.</param>
        /// <returns></returns>
#endif
        public byte[] ToBytes(string ext, params ImageEncodingParam[] encodingParams)
        {
            using (CvMat mat = Cv.EncodeImage(ext, this, encodingParams))
            {
                byte[] bytes = new byte[mat.Rows * mat.Cols];
                Marshal.Copy(mat.Data, bytes, 0, bytes.Length);
                return bytes;
            }
        }
        #endregion
        #region ToStream
#if LANG_JP
        /// <summary>
        /// cvEncodeImageにより、この画像をメモリ上に展開する
        /// </summary>
        /// <param name="outStream">出力先ストリーム</param>
        /// <param name="ext">拡張子。.jpgや.pngなど。これによりエンコード形式が決定される。</param>
        /// <param name="encodingParams">JPEGの圧縮率などのエンコード設定</param>
        /// <returns></returns>
#else
        /// <summary>
        /// Extract this image to the memory using cvEncodeImage
        /// </summary>
        /// <param name="outStream">Destination stream.</param>
        /// <param name="ext">Image extension to decide encoding format.</param>
        /// <param name="encodingParams">Encoding options.</param>
        /// <returns></returns>
#endif
        public void ToStream(Stream outStream, string ext, params ImageEncodingParam[] encodingParams)
        {
            if (outStream == null)
                throw new ArgumentNullException("outStream");

            byte[] bytes = ToBytes(ext, encodingParams);
            outStream.Write(bytes, 0, bytes.Length);
        }
        #endregion

#pragma warning disable 1591
        #region DrawMarker
        public void DrawMarker(int x, int y, CvScalar color)
        {
            DrawMarker(x, y, color, MarkerStyle.Cross, 10, LineType.Link8, 1);
        }
        public void DrawMarker(int x, int y, CvScalar color, MarkerStyle style)
        {
            DrawMarker(x, y, color, style, 10, LineType.Link8, 1);
        }
        public void DrawMarker(int x, int y, CvScalar color, MarkerStyle style, int size)
        {
            DrawMarker(x, y, color, style, size, LineType.Link8, 1);
        }
        public void DrawMarker(int x, int y, CvScalar color, MarkerStyle style, int size, LineType lineType)
        {
            DrawMarker(x, y, color, style, size, LineType.Link8, 1);
        }
        public void DrawMarker(int x, int y, CvScalar color, MarkerStyle style, int size, LineType lineType, int thickness)
        {
            int r = size / 2;            

            switch (style)
            {
                case MarkerStyle.CircleLine:
                    Circle(x, y, r, color, thickness, lineType);
                    break;
                case MarkerStyle.CircleFilled:
                    Circle(x, y, r, color, -1, lineType);
                    break;
                case MarkerStyle.Cross:
                    Line(x, y - r, x, y + r, color, thickness, lineType);
                    Line(x - r, y, x + r, y, color, thickness, lineType);
                    break;
                case MarkerStyle.TiltedCross:
                    Line(x - r, y - r, x + r, y + r, color, thickness, lineType);
                    Line(x + r, y - r, x - r, y + r, color, thickness, lineType);
                    break;
                case MarkerStyle.CircleAndCross:
                    Circle(x, y, r, color, thickness, lineType);
                    Line(x, y - r, x, y + r, color, thickness, lineType);
                    Line(x - r, y, x + r, y, color, thickness, lineType);
                    break;
                case MarkerStyle.CircleAndTiltedCross:
                    Circle(x, y, r, color, thickness, lineType);
                    Line(x - r, y - r, x + r, y + r, color, thickness, lineType);
                    Line(x + r, y - r, x - r, y + r, color, thickness, lineType);
                    break;
                case MarkerStyle.DiamondLine:
                case MarkerStyle.DiamondFilled:
                    {
                        int r2 = (int)(size * Math.Sqrt(2) / 2.0);
                        CvPoint[] pts = new CvPoint[]
                        { 
                            new CvPoint(x, y-r2),
                            new CvPoint(x+r2, y),
                            new CvPoint(x, y+r2),
                            new CvPoint(x-r2, y),
                        };
                        switch (style)
                        {
                            case MarkerStyle.DiamondLine:
                                PolyLine(new CvPoint[][] { pts }, true, color, thickness, lineType); break;
                            case MarkerStyle.DiamondFilled:
                                FillConvexPoly(pts, color, lineType); break;
                        }
                    }
                    break;
                case MarkerStyle.SquareLine:
                case MarkerStyle.SquareFilled:
                    {
                        CvPoint[] pts = new CvPoint[]
                        { 
                            new CvPoint(x-r, y-r),
                            new CvPoint(x+r, y-r),
                            new CvPoint(x+r, y+r),
                            new CvPoint(x-r, y+r),
                        };
                        switch (style)
                        {
                            case MarkerStyle.SquareLine:
                                PolyLine(new CvPoint[][] { pts }, true, color, thickness, lineType); break;
                            case MarkerStyle.SquareFilled:
                                FillConvexPoly(pts, color, lineType); break;
                        }
                    }
                    break;
                default:
                    throw new NotImplementedException();
            }
        }
        #endregion
#pragma warning restore 1591
        #endregion
    }
}
