using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using OpenCvSharp.Utilities;

namespace OpenCvSharp
{
#if LANG_JP
    /// <summary>
    /// 多次元ヒストグラムの構造体
    /// </summary>
#else
    /// <summary>
    /// Muti-dimensional histogram
    /// </summary>
#endif
    public class CvHistogram : DisposableCvObject
    {
        /// <summary>
        /// Track whether Dispose has been called
        /// </summary>
        private bool disposed = false;

        #region Initialization and Disposal
#if LANG_JP
        /// <summary>
        /// CvHistogram構造体の分のメモリ領域を確保して初期化
        /// </summary>
#else
        /// <summary>
        /// Creates an empty histogram 
        /// </summary>
#endif
        public CvHistogram()
        {
            ptr = AllocMemory(SizeOf);
        }
#if LANG_JP
        /// <summary>
        /// 
        /// </summary>
#else
        /// <summary>
        /// Creates a histogram from pointer
        /// </summary>
#endif
        public CvHistogram(IntPtr ptr)
        {
            this.ptr = ptr;
        }
#if LANG_JP
        /// <summary>
        /// 指定サイズのヒストグラムを生成し，そのヒストグラムの参照を返す． 
        /// </summary>
        /// <param name="sizes">ヒストグラム各次元のサイズを示す配列</param>
        /// <param name="type">ヒストグラム表現フォーマット</param>
#else
        /// <summary>
        /// Creates a histogram of the specified size and returns the pointer to the created histogram.
        /// </summary>
        /// <param name="sizes">Number of histogram dimensions. </param>
        /// <param name="type">Histogram representation format.</param>
        /// <returns></returns>
#endif
        public CvHistogram(int[] sizes, HistogramFormat type)
            : this(sizes, type, null, true)
        {
        }
#if LANG_JP
        /// <summary>
        /// 指定サイズのヒストグラムを生成し，そのヒストグラムの参照を返す． 
        /// </summary>
        /// <param name="sizes">ヒストグラム各次元のサイズを示す配列</param>
        /// <param name="type">ヒストグラム表現フォーマット</param>
        /// <param name="ranges">ヒストグラムのビン（bin）（値域）を示す配列．このパラメータの意味はパラメータuniformに依存している．
        /// このレンジは，ヒストグラムを計算したり，またどのヒストグラムのビンが入力画像のどの値やどのデータ要素に対応するかを決めるためのバックプロジェクションで用いられる．
        /// null の場合は，後から関数 cvSetHistBinRanges を用いて決定される.</param>
#else
        /// <summary>
        /// Creates a histogram of the specified size and returns the pointer to the created histogram.
        /// </summary>
        /// <param name="sizes">Number of histogram dimensions. </param>
        /// <param name="type">Histogram representation format.</param>
        /// <param name="ranges">Array of ranges for histogram bins. Its meaning depends on the uniform parameter value. The ranges are used for when histogram is calculated or backprojected to determine, which histogram bin corresponds to which value/tuple of values from the input image[s]. </param>
        /// <returns></returns>
#endif
        public CvHistogram(int[] sizes, HistogramFormat type, float[][] ranges)
            : this(sizes, type, ranges, true)
        {
        }
#if LANG_JP
        /// <summary>
        /// 指定サイズのヒストグラムを生成し，そのヒストグラムの参照を返す． 
        /// </summary>
        /// <param name="sizes">ヒストグラム各次元のサイズを示す配列</param>
        /// <param name="type">ヒストグラム表現フォーマット</param>
        /// <param name="ranges">ヒストグラムのビン（bin）（値域）を示す配列．このパラメータの意味はパラメータuniformに依存している．
        /// このレンジは，ヒストグラムを計算したり，またどのヒストグラムのビンが入力画像のどの値やどのデータ要素に対応するかを決めるためのバックプロジェクションで用いられる．
        /// null の場合は，後から関数 cvSetHistBinRanges を用いて決定される.</param>
        /// <param name="uniform">一様性に関するフラグ</param>
#else
        /// <summary>
        /// Creates a histogram of the specified size and returns the pointer to the created histogram.
        /// </summary>
        /// <param name="sizes">Number of histogram dimensions. </param>
        /// <param name="type">Histogram representation format.</param>
        /// <param name="ranges">Array of ranges for histogram bins. Its meaning depends on the uniform parameter value. The ranges are used for when histogram is calculated or backprojected to determine, which histogram bin corresponds to which value/tuple of values from the input image[s]. </param>
        /// <param name="uniform">Uniformity flag.</param>
#endif
        public CvHistogram(int[] sizes, HistogramFormat type, float[][] ranges, bool uniform)
        {
            if (sizes == null)
                throw new ArgumentNullException("sizes");

            if (ranges == null)
            {
                ptr = NativeMethods.cvCreateHist(sizes.Length, sizes, type, IntPtr.Zero, uniform);
            }
            else
            {
                // float[][]をIntPtr[]に変換する
                using (var rangesPtr = new ArrayAddress2<float>(ranges))
                {
                    ptr = NativeMethods.cvCreateHist(sizes.Length, sizes, type, rangesPtr.Pointer, uniform);
                }
            }
            if (ptr == IntPtr.Zero)
            {
                throw new OpenCvSharpException("Failed to create CvHistogram");
            }

            if (ranges != null)
            {
                SetBinRanges(ranges, uniform);
            }
            Type = type;
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
            if (!disposed)
            {
                try
                {
                    if (disposing)
                    {
                    }
                    if (IsEnabledDispose)
                    {
                        NativeMethods.cvReleaseHist(ref ptr);
                    }
                    disposed = true;
                }
                finally
                {
                    base.Dispose(disposing);
                }
            }
        }
        #endregion

        #region Properties
        /// <summary>
        /// sizeof(CvHistogram)
        /// </summary>
        public static readonly int SizeOf = Marshal.SizeOf(typeof(WCvHistogram));

#if LANG_JP
        /// <summary>
        /// ヒストグラム表現フォーマットを取得する.
        /// </summary>
#else
        /// <summary>
        /// Histogram representation format
        /// </summary>
#endif
        public HistogramFormat Type
        {
            get;
            private set;
        }
#if LANG_JP
        /// <summary>
		/// ヒストグラムのビン(値域)を取得する.
		/// TypeがArrayならCvMatND, SparseならCvSparseMatが返される.
		/// </summary>
#else
        /// <summary>
        /// Histogram bins.
        /// if Type == Array then returns CvMatND, else if Type == Sparse then CvSparseMat
        /// </summary>
#endif
        public CvArr Bins
        {
            get
            {
                IntPtr bins;
                unsafe
                {
                    bins = new IntPtr(((WCvHistogram*)ptr)->bins);
                }
                switch (Type)
                {
                    case HistogramFormat.Array:
                        return new CvMatND(bins, false);
                    case HistogramFormat.Sparse:
                        return new CvSparseMat(bins, false);
                    default:
                        return null;
                }
            }
        }
#if LANG_JP
        /// <summary>
		/// ヒストグラムのビン(値域)を取得する.
		/// TypeがArrayならCvMatND, SparseならCvSparseMatが返される.
		/// </summary>
#else
        /// <summary>
        /// Histogram bins.
        /// if Type == Array then returns CvMatND, else if Type == Sparse then CvSparseMat
        /// </summary>
#endif
        public IntPtr BinsPtr
        {
            get
            {
                unsafe
                {
                    return new IntPtr(((WCvHistogram*)ptr)->bins);
                }
            }
        }
#if LANG_JP
        /// <summary>
        /// ヒストグラムの次元
        /// </summary>
#else
        /// <summary>
        /// Number of histogram dimensions.
        /// </summary>
#endif
        public int Dim
        {
            get
            {
                unsafe
                {
                    return ((WCvHistogram*)ptr)->mat.dims;
                }
            }
        }
#if LANG_JP
        /// <summary>
        /// For uniform histograms (thresh). 
        /// </summary>
#else
        /// <summary>
        /// For uniform histograms (thresh). 
        /// </summary>
#endif
        public PointerAccessor1D_Single Thresh1
        {
            get
            {
                unsafe
                {
                    float* p = ((WCvHistogram*)ptr)->thresh;
                    return new PointerAccessor1D_Single(p);
                }
            }
        }
#if LANG_JP
        /// <summary>
        /// For non-uniform histograms.. 
        /// </summary>
#else
        /// <summary>
        /// For non-uniform histograms.
        /// </summary>
#endif
        public PointerAccessor2D_Single Thresh2
        {
            get
            {
                unsafe
                {
                    float** p = ((WCvHistogram*)ptr)->thresh2;
                    return new PointerAccessor2D_Single(p);
                }
            }
        }
        #endregion

        #region Methods
        #region Calc
#if LANG_JP
        /// <summary>
        /// 1つの画像のヒストグラムを計算する (cvCalcHist相当).
        /// ヒストグラムのビンを増加（インクリメント）するために用いられるタプルの各要素は， 対応する入力画像群の同じ場所から取り出される.
        /// </summary>
        /// <param name="image">入力画像</param>
#else
        /// <summary>
        /// Calculates the histogram of one single-channel image. 
        /// The elements of a tuple that is used to increment a histogram bin are taken at the same location from the corresponding input images.
        /// </summary>
        /// <param name="image">Source image.</param>
#endif
        public void Calc(IplImage image)
        {
            Cv.CalcHist(image, this);
        }
#if LANG_JP
        /// <summary>
        /// 1つの画像のヒストグラムを計算する (cvCalcHist相当).
        /// ヒストグラムのビンを増加（インクリメント）するために用いられるタプルの各要素は， 対応する入力画像群の同じ場所から取り出される.
        /// </summary>
        /// <param name="image">入力画像</param>
        /// <param name="accumulate">計算フラグ．セットされている場合は，ヒストグラムは処理前には最初にクリアされない． </param>
#else
        /// <summary>
        /// Calculates the histogram of one single-channel image. 
        /// The elements of a tuple that is used to increment a histogram bin are taken at the same location from the corresponding input images.
        /// </summary>
        /// <param name="image">Source image.</param>
        /// <param name="accumulate">Accumulation flag. If it is set, the histogram is not cleared in the beginning. This feature allows user to compute a single histogram from several images, or to update the histogram online. </param>
#endif
        public void Calc(IplImage image, bool accumulate)
        {
            Cv.CalcHist(image, this, accumulate, null);
        }
#if LANG_JP
        /// <summary>
        /// 1つの画像のヒストグラムを計算する (cvCalcHist相当).
        /// ヒストグラムのビンを増加（インクリメント）するために用いられるタプルの各要素は， 対応する入力画像群の同じ場所から取り出される.
        /// </summary>
        /// <param name="image">入力画像</param>
        /// <param name="accumulate">計算フラグ．セットされている場合は，ヒストグラムは処理前には最初にクリアされない．</param>
        /// <param name="mask">処理マスク．入力画像中のどのピクセルをカウントするかを決定する.</param>
#else
        /// <summary>
        /// Calculates the histogram of one single-channel image. 
        /// The elements of a tuple that is used to increment a histogram bin are taken at the same location from the corresponding input images.
        /// </summary>
        /// <param name="image">Source image.</param>
        /// <param name="accumulate">Accumulation flag. If it is set, the histogram is not cleared in the beginning. This feature allows user to compute a single histogram from several images, or to update the histogram online. </param>
        /// <param name="mask">The operation mask, determines what pixels of the source images are counted. </param>
#endif
        public void Calc(IplImage image, bool accumulate, CvArr mask)
        {
            Cv.CalcHist(image, this, accumulate, mask);
        }
#if LANG_JP
        /// <summary>
        /// 画像群のヒストグラムを計算する (cvCalcHist相当).
        /// ヒストグラムのビンを増加（インクリメント）するために用いられるタプルの各要素は， 対応する入力画像群の同じ場所から取り出される.
        /// </summary>
        /// <param name="image">入力画像群．全て同じサイズ・タイプ．</param>
#else
        /// <summary>
        /// Calculates the histogram of single-channel images. 
        /// The elements of a tuple that is used to increment a histogram bin are taken at the same location from the corresponding input images.
        /// </summary>
        /// <param name="image">Source images, all are of the same size and type.</param>
#endif
        public void Calc(IplImage[] image)
        {
            Cv.CalcHist(image, this);
        }
#if LANG_JP
        /// <summary>
        /// 画像群のヒストグラムを計算する (cvCalcHist相当).
        /// ヒストグラムのビンを増加（インクリメント）するために用いられるタプルの各要素は， 対応する入力画像群の同じ場所から取り出される.
        /// </summary>
        /// <param name="image">入力画像群．全て同じサイズ・タイプ．</param>
        /// <param name="accumulate">計算フラグ．セットされている場合は，ヒストグラムは処理前には最初にクリアされない． </param>
#else
        /// <summary>
        /// Calculates the histogram of single-channel images. 
        /// The elements of a tuple that is used to increment a histogram bin are taken at the same location from the corresponding input images.
        /// </summary>
        /// <param name="image">Source images, all are of the same size and type.</param>
        /// <param name="accumulate">Accumulation flag. If it is set, the histogram is not cleared in the beginning. This feature allows user to compute a single histogram from several images, or to update the histogram online. </param>
#endif
        public void Calc(IplImage[] image, bool accumulate)
        {
            Cv.CalcHist(image, this, accumulate, null);
        }
#if LANG_JP
        /// <summary>
        /// 画像群のヒストグラムを計算する (cvCalcHist相当).
        /// ヒストグラムのビンを増加（インクリメント）するために用いられるタプルの各要素は， 対応する入力画像群の同じ場所から取り出される.
        /// </summary>
        /// <param name="image">入力画像群．全て同じサイズ・タイプ．</param>
        /// <param name="accumulate">計算フラグ．セットされている場合は，ヒストグラムは処理前には最初にクリアされない． </param>
        /// <param name="mask">処理マスク．入力画像中のどのピクセルをカウントするかを決定する.</param>
#else
        /// <summary>
        /// Calculates the histogram of single-channel images. 
        /// The elements of a tuple that is used to increment a histogram bin are taken at the same location from the corresponding input images.
        /// </summary>
        /// <param name="image">Source images, all are of the same size and type.</param>
        /// <param name="accumulate">Accumulation flag. If it is set, the histogram is not cleared in the beginning. This feature allows user to compute a single histogram from several images, or to update the histogram online. </param>
        /// <param name="mask">The operation mask, determines what pixels of the source images are counted. </param>
#endif
        public void Calc(IplImage[] image, bool accumulate, CvArr mask)
        {
            Cv.CalcHist(image, this, accumulate, mask);
        }
        #endregion
        #region CalcArr
#if LANG_JP
        /// <summary>
        /// 1つの配列のヒストグラムを計算する (cvCalcArrHist相当).
        /// ヒストグラムのビンを増加（インクリメント）するために用いられるタプルの各要素は， 対応する入力画像群の同じ場所から取り出される.
        /// </summary>
        /// <param name="arr">入力配列</param>
#else
        /// <summary>
        /// Calculates the histogram of one single-channel image. 
        /// The elements of a tuple that is used to increment a histogram bin are taken at the same location from the corresponding input images.
        /// </summary>
        /// <param name="arr">A Source image (though, you may pass CvMat** as well).</param>
#endif
        public void CalcArr(CvArr arr)
        {
            Cv.CalcArrHist(arr, this);
        }
#if LANG_JP
        /// <summary>
        /// 1つの配列のヒストグラムを計算する (cvCalcArrHist相当).
        /// ヒストグラムのビンを増加（インクリメント）するために用いられるタプルの各要素は， 対応する入力画像群の同じ場所から取り出される.
        /// </summary>
        /// <param name="arr">入力配列</param>
        /// <param name="accumulate">計算フラグ．セットされている場合は，ヒストグラムは処理前には最初にクリアされない．</param>
#else
        /// <summary>
        /// Calculates the histogram of one single-channel image. 
        /// The elements of a tuple that is used to increment a histogram bin are taken at the same location from the corresponding input images.
        /// </summary>
        /// <param name="arr">A Source image (though, you may pass CvMat** as well).</param>
        /// <param name="accumulate">Accumulation flag. If it is set, the histogram is not cleared in the beginning. This feature allows user to compute a single histogram from several images, or to update the histogram online. </param>
#endif
        public void CalcArr(CvArr arr, bool accumulate)
        {
            Cv.CalcArrHist(arr, this, accumulate, null);
        }
#if LANG_JP
        /// <summary>
        /// 1つの配列のヒストグラムを計算する (cvCalcArrHist相当).
        /// ヒストグラムのビンを増加（インクリメント）するために用いられるタプルの各要素は， 対応する入力画像群の同じ場所から取り出される.
        /// </summary>
        /// <param name="arr">入力配列</param>
        /// <param name="accumulate">計算フラグ．セットされている場合は，ヒストグラムは処理前には最初にクリアされない．</param>
        /// <param name="mask">処理マスク．入力画像中のどのピクセルをカウントするかを決定する.</param>
#else
        /// <summary>
        /// Calculates the histogram of one single-channel image. 
        /// The elements of a tuple that is used to increment a histogram bin are taken at the same location from the corresponding input images.
        /// </summary>
        /// <param name="arr">A Source image (though, you may pass CvMat** as well).</param>
        /// <param name="accumulate">Accumulation flag. If it is set, the histogram is not cleared in the beginning. This feature allows user to compute a single histogram from several images, or to update the histogram online. </param>
        /// <param name="mask">The operation mask, determines what pixels of the source images are counted. </param>
#endif
        public void CalcArr(CvArr arr, bool accumulate, CvArr mask)
        {
            Cv.CalcArrHist(arr, this, accumulate, mask);
        }
#if LANG_JP
        /// <summary>
        /// 配列群のヒストグラムを計算する (cvCalcArrHist相当).
        /// ヒストグラムのビンを増加（インクリメント）するために用いられるタプルの各要素は， 対応する入力画像群の同じ場所から取り出される.
        /// </summary>
        /// <param name="arr">入力配列群．全て同じサイズ・タイプ．</param>
#else
        /// <summary>
        /// Calculates the histogram of single-channel images. 
        /// The elements of a tuple that is used to increment a histogram bin are taken at the same location from the corresponding input images.
        /// </summary>
        /// <param name="arr">Source images (though, you may pass CvMat** as well), all are of the same size and type.</param>
#endif
        public void CalcArr(CvArr[] arr)
        {
            Cv.CalcArrHist(arr, this);
        }
#if LANG_JP
        /// <summary>
        /// 配列群のヒストグラムを計算する (cvCalcArrHist相当).
        /// ヒストグラムのビンを増加（インクリメント）するために用いられるタプルの各要素は， 対応する入力画像群の同じ場所から取り出される.
        /// </summary>
        /// <param name="arr">入力配列群．全て同じサイズ・タイプ．</param>
        /// <param name="accumulate">計算フラグ．セットされている場合は，ヒストグラムは処理前には最初にクリアされない． </param>
#else
        /// <summary>
        /// Calculates the histogram of single-channel images. 
        /// The elements of a tuple that is used to increment a histogram bin are taken at the same location from the corresponding input images.
        /// </summary>
        /// <param name="arr">Source images (though, you may pass CvMat** as well), all are of the same size and type.</param>
        /// <param name="accumulate">Accumulation flag. If it is set, the histogram is not cleared in the beginning. This feature allows user to compute a single histogram from several images, or to update the histogram online. </param>
#endif
        public void CalcArr(CvArr[] arr, bool accumulate)
        {
            Cv.CalcArrHist(arr, this, accumulate, null);
        }
#if LANG_JP
        /// <summary>
        /// 配列群のヒストグラムを計算する (cvCalcArrHist相当).
        /// ヒストグラムのビンを増加（インクリメント）するために用いられるタプルの各要素は， 対応する入力画像群の同じ場所から取り出される.
        /// </summary>
        /// <param name="arr">入力配列群．全て同じサイズ・タイプ．</param>
        /// <param name="accumulate">計算フラグ．セットされている場合は，ヒストグラムは処理前には最初にクリアされない． </param>
        /// <param name="mask">処理マスク．入力画像中のどのピクセルをカウントするかを決定する.</param>
#else
        /// <summary>
        /// Calculates the histogram of single-channel images. 
        /// The elements of a tuple that is used to increment a histogram bin are taken at the same location from the corresponding input images.
        /// </summary>
        /// <param name="arr">Source images (though, you may pass CvMat** as well), all are of the same size and type.</param>
        /// <param name="accumulate">Accumulation flag. If it is set, the histogram is not cleared in the beginning. This feature allows user to compute a single histogram from several images, or to update the histogram online. </param>
        /// <param name="mask">The operation mask, determines what pixels of the source images are counted. </param>
#endif
        public void CalcArr(CvArr[] arr, bool accumulate, CvArr mask)
        {
            Cv.CalcArrHist(arr, this, accumulate, mask);
        }
        #endregion
        #region CalcArrBackProject
#if LANG_JP
        /// <summary>
        /// バックプロジェクションの計算を行う
        /// </summary>
        /// <param name="image">入力画像群</param>
        /// <param name="backProject">出力のバックプロジェクション画像．入力画像群と同じタイプ．</param>
        /// <returns></returns>
#else
        /// <summary>
        /// Calculates back projection
        /// </summary>
        /// <param name="image">Source images (though you may pass CvMat** as well), all are of the same size and type </param>
        /// <param name="backProject">Destination back projection image of the same type as the source images. </param>
        /// <returns></returns>
#endif
        public void CalcArrBackProject(CvArr[] image, CvArr backProject)
        {
            Cv.CalcArrBackProject(image, backProject, this);
        }
#if LANG_JP
        /// <summary>
        /// バックプロジェクションの計算を行う
        /// </summary>
        /// <param name="image">入力画像群</param>
        /// <param name="backProject">出力のバックプロジェクション画像．入力画像群と同じタイプ．</param>
        /// <returns></returns>
#else
        /// <summary>
        /// Calculates back projection
        /// </summary>
        /// <param name="image">Source images (though you may pass CvMat** as well), all are of the same size and type </param>
        /// <param name="backProject">Destination back projection image of the same type as the source images. </param>
        /// <returns></returns>
#endif
        public void CalcBackProject(IplImage[] image, CvArr backProject)
        {
            Cv.CalcBackProject(image, backProject, this);
        }
        #endregion
        #region CalcArrBackProjectPatch
#if LANG_JP
        /// <summary>
        /// ヒストグラムの比較に基づき画像内部でのテンプレート位置を求める
        /// </summary>
        /// <param name="image">入力画像群（ CvMat** 形式でも構わない）．すべて同じサイズ．</param>
        /// <param name="dst">出力画像</param>
        /// <param name="patchSize">入力画像群上をスライドさせるテンプレートのサイズ</param>
        /// <param name="method">比較方法．値は関数 cvCompareHist に渡される（この関数に関する記述を参照）</param>
        /// <returns></returns>
#else
        /// <summary>
        /// Locates a template within image by histogram comparison
        /// </summary>
        /// <param name="image">Source images (though you may pass CvMat** as well), all are of the same size and type </param>
        /// <param name="dst">Destination image. </param>
        /// <param name="patchSize">Size of patch slid though the source images. </param>
        /// <param name="method">Compasion method, passed to cvCompareHist (see description of that function). </param>
        /// <returns></returns>
#endif
        public void CalcArrBackProjectPatch(CvArr[] image, CvArr dst, CvSize patchSize, HistogramComparison method)
        {
            Cv.CalcArrBackProjectPatch(image, dst, patchSize, this, method);
        }
#if LANG_JP
        /// <summary>
        /// ヒストグラムの比較に基づき画像内部でのテンプレート位置を求める
        /// </summary>
        /// <param name="image">入力画像群（ CvMat** 形式でも構わない）．すべて同じサイズ．</param>
        /// <param name="dst">出力画像</param>
        /// <param name="patchSize">入力画像群上をスライドさせるテンプレートのサイズ</param>
        /// <param name="method">比較方法．値は関数 cvCompareHist に渡される（この関数に関する記述を参照）</param>
        /// <param name="factor">ヒストグラムの正規化係数．出力画像の正規化スケールに影響する．値に確信がない場合は，１にする．</param>
        /// <returns></returns>
#else
        /// <summary>
        /// Locates a template within image by histogram comparison
        /// </summary>
        /// <param name="image">Source images (though you may pass CvMat** as well), all are of the same size and type </param>
        /// <param name="dst">Destination image. </param>
        /// <param name="patchSize">Size of patch slid though the source images. </param>
        /// <param name="method">Compasion method, passed to cvCompareHist (see description of that function). </param>
        /// <param name="factor">Normalization factor for histograms, will affect normalization scale of destination image, pass 1. if unsure. </param>
        /// <returns></returns>
#endif
        public void CalcArrBackProjectPatch(CvArr[] image, CvArr dst, CvSize patchSize, HistogramComparison method, float factor)
        {
            Cv.CalcArrBackProjectPatch(image, dst, patchSize, this, method, factor);
        }
#if LANG_JP
        /// <summary>
        /// ヒストグラムの比較に基づき画像内部でのテンプレート位置を求める
        /// </summary>
        /// <param name="image">入力画像群（ CvMat** 形式でも構わない）．すべて同じサイズ．</param>
        /// <param name="dst">出力画像</param>
        /// <param name="patchSize">入力画像群上をスライドさせるテンプレートのサイズ</param>
        /// <param name="method">比較方法．値は関数 cvCompareHist に渡される（この関数に関する記述を参照）</param>
        /// <returns></returns>
#else
        /// <summary>
        /// Locates a template within image by histogram comparison
        /// </summary>
        /// <param name="image">Source images (though you may pass CvMat** as well), all are of the same size and type </param>
        /// <param name="dst">Destination image. </param>
        /// <param name="patchSize">Size of patch slid though the source images. </param>
        /// <param name="method">Compasion method, passed to cvCompareHist (see description of that function). </param>
        /// <returns></returns>
#endif
        public void CalcBackProjectPatch(CvArr[] image, CvArr dst, CvSize patchSize, HistogramComparison method)
        {
            Cv.CalcArrBackProjectPatch(image, dst, patchSize, this, method);
        }
#if LANG_JP
        /// <summary>
        /// ヒストグラムの比較に基づき画像内部でのテンプレート位置を求める
        /// </summary>
        /// <param name="image">入力画像群（ CvMat** 形式でも構わない）．すべて同じサイズ．</param>
        /// <param name="dst">出力画像</param>
        /// <param name="patchSize">入力画像群上をスライドさせるテンプレートのサイズ</param>
        /// <param name="method">比較方法．値は関数 cvCompareHist に渡される（この関数に関する記述を参照）</param>
        /// <param name="factor">ヒストグラムの正規化係数．出力画像の正規化スケールに影響する．値に確信がない場合は，１にする．</param>
        /// <returns></returns>
#else
        /// <summary>
        /// Locates a template within image by histogram comparison
        /// </summary>
        /// <param name="image">Source images (though you may pass CvMat** as well), all are of the same size and type </param>
        /// <param name="dst">Destination image. </param>
        /// <param name="patchSize">Size of patch slid though the source images. </param>
        /// <param name="method">Compasion method, passed to cvCompareHist (see description of that function). </param>
        /// <param name="factor">Normalization factor for histograms, will affect normalization scale of destination image, pass 1. if unsure. </param>
        /// <returns></returns>
#endif
        public void CalcBackProjectPatch(CvArr[] image, CvArr dst, CvSize patchSize, HistogramComparison method, float factor)
        {
            Cv.CalcArrBackProjectPatch(image, dst, patchSize, this, method, factor);
        }
        #endregion        
        #region CalcBayesianProb
#if LANG_JP
        /// <summary>
        /// Calculates bayesian probabilistic histograms
        /// </summary>
        /// <param name="src"></param>
        /// <param name="dst"></param>
#else
        /// <summary>
        /// Calculates bayesian probabilistic histograms
        /// </summary>
        /// <param name="src"></param>
        /// <param name="dst"></param>
#endif
        public static void CalcBayesianProb(CvHistogram[] src, CvHistogram[] dst)
        {
            Cv.CalcBayesianProb(src, dst);
        }
        #endregion
        #region CalcProbDensity
#if LANG_JP
        /// <summary>
        /// 一つのヒストグラムをもう一方のヒストグラムで割る (cvCalcProbDensity相当).
        /// </summary>
        /// <param name="hist1">一番目のヒストグラム（除数）</param>
        /// <param name="hist2">二番目のヒストグラム</param>
        /// <param name="dstHist">出力ヒストグラム</param>
#else
        /// <summary>
        /// Divides one histogram by another.
        /// </summary>
        /// <param name="hist1">first histogram (the divisor). </param>
        /// <param name="hist2">second histogram. </param>
        /// <param name="dstHist">destination histogram. </param>
#endif
        public static void CalcProbDensity(CvHistogram hist1, CvHistogram hist2, CvHistogram dstHist)
        {
            Cv.CalcProbDensity(hist1, hist2, dstHist);
        }
#if LANG_JP
        /// <summary>
        /// 一つのヒストグラムをもう一方のヒストグラムで割る (cvCalcProbDensity相当).
        /// </summary>
        /// <param name="hist1">一番目のヒストグラム（除数）</param>
        /// <param name="hist2">二番目のヒストグラム</param>
        /// <param name="dstHist">出力ヒストグラム</param>
        /// <param name="scale">出力ヒストグラムのスケール係数</param>
#else
        /// <summary>
        /// Divides one histogram by another.
        /// </summary>
        /// <param name="hist1">first histogram (the divisor). </param>
        /// <param name="hist2">second histogram. </param>
        /// <param name="dstHist">destination histogram. </param>
        /// <param name="scale">scale factor for the destination histogram. </param>
#endif
        public static void CalcProbDensity(CvHistogram hist1, CvHistogram hist2, CvHistogram dstHist, double scale)
        {
            Cv.CalcProbDensity(hist1, hist2, dstHist, scale);
        }
        #endregion
        #region Clear
#if LANG_JP
        /// <summary>
        /// ヒストグラムをクリアする (cvClearHist).
        /// 密なヒストグラムの場合，全てのヒストグラムのビンを0にセットする， また疎なヒストグラムの場合は，すべてのヒストグラムのビンを削除する．
        /// </summary>
#else
        /// <summary>
        /// Sets all histogram bins to 0 in case of dense histogram and removes all histogram bins in case of sparse array.
        /// </summary>
#endif
        public void Clear()
        {
            Cv.ClearHist(this);
        }
        #endregion
        #region Compare
#if LANG_JP
        /// <summary>
        /// 2つの密なヒストグラムを比較する (cvCompareHist相当).
        /// 疎なヒストグラム，あるいは重み付けされた点が集まったような，より一般的な構造を比較するためには，関数cvCalcEMD2 を用いる方が良い場合もある.
        /// </summary>
        /// <param name="hist">比較対象の密なヒストグラム</param>
        /// <param name="method">比較手法</param>
#else
        /// <summary>
        /// Compares two dense histograms.
        /// </summary>
        /// <param name="hist">target histogram</param>
        /// <param name="method">Comparison method.</param>
        /// <returns></returns>
#endif
        public double Compare(CvHistogram hist, HistogramComparison method)
        {
            if (hist == null)
            {
                throw new ArgumentNullException("hist");
            }
            return NativeMethods.cvCompareHist(ptr, hist.CvPtr, method);
        }
        #endregion
        #region Copy
#if LANG_JP
        /// <summary>
        /// ヒストグラムのコピーを作成する (cvCopyHist相当)．
        /// コピー先のヒストグラムへのポインタdstがnullの場合は，srcと同じサイズの新しいヒストグラムが作成される．
        /// それ以外の場合は，二つのヒストグラムは同一タイプ，サイズでないといけない．
        /// この関数はコピー元のヒストグラムのビンの値を，コピー先にコピーし， src内に定義されているのと同じビンの値域をセットする．
        /// </summary>
        /// <param name="dst">コピー先のヒストグラムへのポインタ． </param>        
#else
        /// <summary>
        /// Makes a copy of the histogram. 
        /// If the second histogram dst is null, a new histogram of the same size as src is created. 
        /// Otherwise, both histograms must have equal types and sizes. 
        /// Then the function copies the source histogram bins values to destination histogram and sets the same bin values ranges as in src.
        /// </summary>
        /// <param name="dst">Reference to destination histogram. </param>
#endif
        public void Copy(CvHistogram dst)
        {
            Cv.CopyHist(this, ref dst);
        }
        #endregion
        #region GetValue*D
#if LANG_JP
        /// <summary>
        /// 1次元ヒストグラムの指定されたビンへのポインタを返す． 
        /// 疎なヒストグラムの場合で，既にビンが存在している場合以外は，この関数が新しいビンを作成し，0にセットする．
        /// </summary>
        /// <param name="idx0">要素インデックスの，0を基準とした第1成分．</param>
        /// <returns>指定した要素のポインタ</returns>
#else
        /// <summary>
        /// Returns pointer to histogram bin.
        /// </summary>
        /// <param name="idx0">1st index of the bin.</param>
        /// <returns></returns>
#endif
        public IntPtr GetValue1D(int idx0)
        {
            return Cv.GetHistValue_1D(this, idx0);
        }
#if LANG_JP
        /// <summary>
        /// 2次元ヒストグラムの指定されたビンへのポインタを返す． 
        /// 疎なヒストグラムの場合で，既にビンが存在している場合以外は，この関数が新しいビンを作成し，0にセットする．
        /// </summary>
        /// <param name="idx0">要素インデックスの，0を基準とした第1成分．</param>
        /// <param name="idx1">要素インデックスの，0を基準とした第2成分．</param>
        /// <returns>指定した要素のポインタ</returns>
#else
        /// <summary>
        /// Returns pointer to histogram bin.
        /// </summary>
        /// <param name="idx0">1st index of the bin.</param>
        /// <param name="idx1">2rd index of the bin.</param>
        /// <returns></returns>
#endif
        public IntPtr GetValue2D(int idx0, int idx1)
        {
            return Cv.GetHistValue_2D(this, idx0, idx1);
        }
#if LANG_JP
        /// <summary>
        /// 3次元ヒストグラムの指定されたビンへのポインタを返す． 
        /// 疎なヒストグラムの場合で，既にビンが存在している場合以外は，この関数が新しいビンを作成し，0にセットする．
        /// </summary>
        /// <param name="idx0">要素インデックスの，0を基準とした第1成分．</param>
        /// <param name="idx1">要素インデックスの，0を基準とした第2成分．</param>
        /// <param name="idx2">要素インデックスの，0を基準とした第3成分．</param>
        /// <returns>指定した要素のポインタ</returns>
#else
        /// <summary>
        /// Returns pointer to histogram bin.
        /// </summary>
        /// <param name="idx0">1st index of the bin.</param>
        /// <param name="idx1">2nd index of the bin.</param>
        /// <param name="idx2">3rd index of the bin.</param>
        /// <returns></returns>
#endif
        public IntPtr GetValue3D(int idx0, int idx1, int idx2)
        {
            return Cv.GetHistValue_3D(this, idx0, idx1, idx2);
        }
#if LANG_JP
        /// <summary>
        /// n次元ヒストグラムの指定されたビンへのポインタを返す． 
        /// 疎なヒストグラムの場合で，既にビンが存在している場合以外は，この関数が新しいビンを作成し，0にセットする．
        /// </summary>
        /// <param name="idx">要素インデックスの配列(可変長引数)</param>
        /// <returns>指定した要素のポインタ</returns>
#else
        /// <summary>
        /// Returns pointer to histogram bin.
        /// </summary>
        /// <param name="idx">Indices of the bin. </param>
        /// <returns></returns>
#endif
        public IntPtr GetValueND(params int[] idx)
        {
            return Cv.GetHistValue_nD(this, idx);
        }
        #endregion
        #region GetMinMaxValue
#if LANG_JP
        /// <summary>
        /// ヒストグラムのビンの最小値/最大値を求める (cvGetMinMaxHistValue相当)． 
        /// 同じ値の最大値や最小値が複数存在する場合，辞書順に並べたときに最も先頭になるインデックスが返される． 
        /// </summary>
        /// <param name="minValue">ヒストグラムの最小値の出力</param>
        /// <param name="maxValue">ヒストグラムの最大値の出力</param>
#else
        /// <summary>
        /// Finds minimum and maximum histogram bins.
        /// </summary>
        /// <param name="minValue">The minimum value of the histogram.</param>
        /// <param name="maxValue">The maximum value of the histogram.</param>
#endif
        public void GetMinMaxValue(out float minValue, out float maxValue)
        {
            Cv.GetMinMaxHistValue(this, out minValue, out maxValue);
        }
#if LANG_JP
        /// <summary>
        /// ヒストグラムのビンの最小値/最大値とそれらの場所を求める (cvGetMinMaxHistValue相当)． 
        /// 同じ値の最大値や最小値が複数存在する場合，辞書順に並べたときに最も先頭になるインデックスが返される． 
        /// </summary>
        /// <param name="minValue">ヒストグラムの最小値の出力</param>
        /// <param name="maxValue">ヒストグラムの最大値の出力</param>
        /// <param name="minIdx">最小値の配列中のインデックスの出力</param>
        /// <param name="maxIdx">最大値の配列中のインデックスの出力</param>
#else
        /// <summary>
        /// Finds minimum and maximum histogram bins.
        /// </summary>
        /// <param name="minValue">The minimum value of the histogram.</param>
        /// <param name="maxValue">The maximum value of the histogram.</param>
        /// <param name="minIdx">The array of coordinates for minimum.</param>
        /// <param name="maxIdx">The array of coordinates for maximum.</param>
#endif
        public void GetMinMaxValue(out float minValue, out float maxValue, out int[] minIdx, out int[] maxIdx)
        {
            Cv.GetMinMaxHistValue(this, out minValue, out maxValue, out minIdx, out maxIdx);
        }
        #endregion
        #region Normalize
#if LANG_JP
        /// <summary>
        /// ヒストグラムの正規化を行う (cvNormalizeHist相当).
        /// ビンの値の合計が factor に等しくなるようにスケーリングする事で，ヒストグラムのビンを正規化する．
        /// </summary>
        /// <param name="factor">正規化係数</param>
#else
        /// <summary>
        /// Normalizes the histogram bins by scaling them, such that the sum of the bins becomes equal to factor.
        /// </summary>
        /// <param name="factor">Threshold level. </param>
#endif
        public void Normalize(double factor)
        {
            Cv.NormalizeHist(this, factor);
        }
        #endregion
        #region QueryValue*D
#if LANG_JP
        /// <summary>
        /// 1次元ヒストグラムの指定されたビンの値を返す (cvQueryHistValue_1D相当)． 
        /// 疎なヒストグラムの場合で，既にビンが存在している場合以外は，この関数が新しいビンを作成し，0にセットする．
        /// </summary>
        /// <param name="idx0">要素インデックスの，0を基準とした第1成分．</param>
        /// <returns>指定した要素の値</returns>
#else
        /// <summary>
        /// Queries value of histogram bin.
        /// </summary>
        /// <param name="idx0">1st index of the bin.</param>
        /// <returns></returns>
#endif
        public double QueryValue1D(Int32 idx0)
        {
            return Cv.QueryHistValue_1D(this, idx0);
        }
#if LANG_JP
        /// <summary>
        /// 2次元ヒストグラムの指定されたビンの値を返す (cvQueryHistValue_2D相当)． 
        /// 疎なヒストグラムの場合で，既にビンが存在している場合以外は，この関数が新しいビンを作成し，0にセットする．
        /// </summary>
        /// <param name="idx0">要素インデックスの，0を基準とした第1成分．</param>
        /// <param name="idx1">要素インデックスの，0を基準とした第2成分．</param>
        /// <returns>指定した要素の値</returns>
#else
        /// <summary>
        /// Queries value of histogram bin.
        /// </summary>
        /// <param name="idx0">1st index of the bin.</param>
        /// <param name="idx1">2nd index of the bin.</param>
        /// <returns></returns>
#endif
        public double QueryValue2D(Int32 idx0, Int32 idx1)
        {
            return Cv.QueryHistValue_2D(this, idx0, idx1);
        }
#if LANG_JP
        /// <summary>
        /// 3次元ヒストグラムの指定されたビンの値を返す (cvQueryHistValue_3D相当)． 
        /// 疎なヒストグラムの場合で，既にビンが存在している場合以外は，この関数が新しいビンを作成し，0にセットする．
        /// </summary>
        /// <param name="idx0">要素インデックスの，0を基準とした第1成分．</param>
        /// <param name="idx1">要素インデックスの，0を基準とした第2成分．</param>
        /// <param name="idx2">要素インデックスの，0を基準とした第3成分．</param>
        /// <returns>指定した要素の値</returns>
#else
        /// <summary>
        /// Queries value of histogram bin.
        /// </summary>
        /// <param name="idx0">1st index of the bin.</param>
        /// <param name="idx1">2nd index of the bin.</param>
        /// <param name="idx2">3rd index of the bin.</param>
        /// <returns></returns>
#endif
        public double QueryValue3D(Int32 idx0, Int32 idx1, Int32 idx2)
        {
            return Cv.QueryHistValue_3D(this, idx0, idx1, idx2);
        }
#if LANG_JP
        /// <summary>
        /// n次元ヒストグラムの指定されたビンの値を返す (cvQueryHistValue_ND相当)． 
        /// 疎なヒストグラムの場合で，既にビンが存在している場合以外は，この関数が新しいビンを作成し，0にセットする．
        /// </summary>
        /// <param name="idx">要素インデックスの配列(可変長引数)</param>
        /// <returns>指定した要素の値</returns>
#else
        /// <summary>
        /// Queries value of histogram bin.
        /// </summary>
        /// <param name="idx">Array of indices.</param>
        /// <returns></returns>
#endif
        public double QueryValueND(params int[] idx)
        {
            return Cv.QueryHistValue_nD(this, idx);
        }
        #endregion
        #region SetBinRanges
#if LANG_JP
        /// <summary>
        /// ヒストグラムのビンのレンジをセットする (cvSetHistBinRanges相当).
        /// </summary>
        /// <param name="ranges">ビンのレンジの配列</param>
#else
        /// <summary>
        /// Sets bounds of histogram bins
        /// </summary>
        /// <param name="ranges">Array of bin ranges arrays.</param>
#endif
        public void SetBinRanges(float[][] ranges)
        {
            Cv.SetHistBinRanges(this, ranges);
        }
#if LANG_JP
        /// <summary>
        /// ヒストグラムのビンのレンジをセットする (cvSetHistBinRanges相当).
        /// </summary>
        /// <param name="ranges">ビンのレンジの配列</param>
        /// <param name="uniform">一様性フラグ</param>
#else
        /// <summary>
        /// Sets bounds of histogram bins
        /// </summary>
        /// <param name="ranges">Array of bin ranges arrays.</param>
        /// <param name="uniform">Uniformity flag.</param>
#endif
        public void SetBinRanges(float[][] ranges, bool uniform)
        {
            Cv.SetHistBinRanges(this, ranges, uniform);
        }
        #endregion
        #region Thresh
#if LANG_JP
        /// <summary>
        /// ヒストグラムの閾値処理を行う (cvThreshHist相当).
        /// 指定した閾値以下のヒストグラムのビンをクリアする.
        /// </summary>
        /// <param name="threshold">閾値レベル</param>
#else
        /// <summary>
        /// Clears histogram bins that are below the specified threshold.
        /// </summary>
        /// <param name="threshold">Threshold level. </param>
#endif
        public void Thresh(double threshold)
        {
            Cv.ThreshHist(this, threshold);
        }
        #endregion
        #endregion
    }
}
