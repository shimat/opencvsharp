/*
 * (C) 2008-2013 Schima
 * This code is licenced under the LGPL.
 */

using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace OpenCvSharp
{
#if LANG_JP
    /// <summary>
    /// 段階分類器のカスケードまたは木
    /// </summary>
#else
    /// <summary>
    /// Cascade or tree of stage classifiers
    /// </summary>
#endif
    public class CvHaarClassifierCascade : DisposableCvObject
    {
        /// <summary>
        /// Track whether Dispose has been called
        /// </summary>
        private bool disposed = false;

        #region Init and Disposal
#if LANG_JP
        /// <summary>
        /// ポインタで初期化
        /// </summary>
        /// <param name="ptr">struct CvHaarClassifierCascade*</param>
#else
        /// <summary>
        /// Initializes from native pointer
        /// </summary>
        /// <param name="ptr"></param>
#endif
        public CvHaarClassifierCascade(IntPtr ptr)
            : this(ptr, false)
        {
        }
#if LANG_JP
        /// <summary>
        /// ポインタと自動解放の可否を指定して初期化
        /// </summary>
        /// <param name="ptr"></param>
        /// <param name="isEnabledDispose"></param>
#else
        /// <summary>
        /// Initializes by native pointer
        /// </summary>
        /// <param name="ptr"></param>
        /// <param name="isEnabledDispose">If true, this object will be disposed by GC automatically.</param>
#endif
        internal CvHaarClassifierCascade(IntPtr ptr, bool isEnabledDispose)
            : base(isEnabledDispose)
        {
            if (ptr == IntPtr.Zero)
            {
                throw new OpenCvSharpException("Failed to create CvHaarClassifierCascade.");
            }
            this.ptr = ptr;
        }
#if LANG_JP
	    /// <summary>
	    /// ファイルからHaar分類機のカスケードを読み込んで返す (cvLoad相当).
	    /// </summary>
	    /// <param name="filename">読み込むファイル(xml/yaml)</param>
	    /// <returns>CvHaarClassifierCascade</returns>
#else
        /// <summary>
        /// Loads object from file (cvLoad)
        /// </summary>
        /// <param name="filename">File name (xml/yaml)</param>
        /// <returns></returns>
#endif
        public static CvHaarClassifierCascade FromFile(string filename)
        {
            if (string.IsNullOrEmpty(filename))
                throw new OpenCvSharpException("Failed to create CvHaarClassifierCascade.");
            
            //return Cv.LoadHaarClassifierCascade(filename, new CvSize(1, 1));
            return Cv.Load<CvHaarClassifierCascade>(filename);
        }
#if LANG_JP
        /// <summary>
        /// ファイルまたはOpenCV 内に組み込まれた分類器データベースから，学習されたカスケード分類器を読み込む (cvLoadHaarClassifierCascade) 
        /// </summary>
        /// <param name="directory">学習されたカスケード分類器の記述を含むディレクトリ名． </param>
        /// <param name="orig_window_size">オブジェクトのオリジナルサイズ（カスケード分類器はこのサイズに合わせて学習される）． これはカスケード分類器内に保存されないので，別に指定する必要がある事に注意． </param>
        /// <remarks>この関数は，もはやサポートされない．現在では，オブジェクト検出分類器はディレクトリではなく XML/YAML ファイルに保存される． カスケードをファイルから読み込むためには，関数 cvLoad を用いる．</remarks>
#else
        /// <summary>
        /// Loads a trained cascade classifier from file or the classifier database embedded in OpenCV (cvLoadHaarClassifierCascade)
        /// </summary>
        /// <param name="directory">Name of directory containing the description of a trained cascade classifier. </param>
        /// <param name="origWindowSize">Original size of objects the cascade has been trained on. Note that it is not stored in the cascade and therefore must be specified separately. </param>
        /// <remarks>The function is obsolete. Nowadays object detection classifiers are stored in XML or YAML files, rather than in directories. To load cascade from a file, use cvLoad function. </remarks>
#endif
        [Obsolete]
        public static CvHaarClassifierCascade FromDirectory(string directory, CvSize origWindowSize)
        {
            if (string.IsNullOrEmpty(directory))
                throw new ArgumentNullException("directory");
            IntPtr result = CvInvoke.cvLoadHaarClassifierCascade(directory, origWindowSize);
            if (result == IntPtr.Zero)
                return null;
            return new CvHaarClassifierCascade(result);
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
                // 継承したクラス独自の解放処理
                try
                {
                    if (disposing)
                    {
                    }
                    if (IsEnabledDispose)
                    {
                        CvInvoke.cvReleaseHaarClassifierCascade(ref ptr);
                    }
                    disposed = true;
                }
                finally
                {
                    // 親の解放処理
                    base.Dispose(disposing);
                }
            }
        }
        #endregion

        #region Properties
        /// <summary>
        /// sizeof(CvHaarClassifierCascade) 
        /// </summary>
        public static readonly int SizeOf = Marshal.SizeOf(typeof(WCvHaarClassifierCascade));


#if LANG_JP
        /// <summary>
        /// シグネチャ
        /// </summary>
#else
        /// <summary>
        /// Signature 
        /// </summary>
#endif
        public int Flags
        {
            get
            {
                unsafe
                {
                    return ((WCvHaarClassifierCascade*)ptr)->flags;
                }
            }
        }
#if LANG_JP
        /// <summary>
        /// 段階数
        /// </summary>
#else
        /// <summary>
        /// Number of stages
        /// </summary>
#endif
        public int Count
        {
            get
            {
                unsafe
                {
                    return ((WCvHaarClassifierCascade*)ptr)->count;
                }
            }
        }
#if LANG_JP
        /// <summary>
        /// オリジナルのオブジェクトサイズ（カスケードの学習対象）
        /// </summary>
#else
        /// <summary>
        /// Original object size (the cascade is trained for)
        /// </summary>
#endif
        public CvSize OrigWindowSize
        {
            get
            {
                unsafe
                {
                    return ((WCvHaarClassifierCascade*)ptr)->orig_window_size;
                }
            }
        }
#if LANG_JP
        /// <summary>
        /// 現在のオブジェクトサイズ
        /// </summary>
#else
        /// <summary>
        /// Current object size
        /// </summary>
#endif
        public CvSize RealWindowSize
        {
            get
            {
                unsafe
                {
                    return ((WCvHaarClassifierCascade*)ptr)->real_window_size;
                }
            }
        }
#if LANG_JP
        /// <summary>
        /// 現在のスケール
        /// </summary>
#else
        /// <summary>
        /// Current scale
        /// </summary>
#endif
        public double Scale
        {
            get
            {
                unsafe
                {
                    return ((WCvHaarClassifierCascade*)ptr)->scale;
                }
            }
        }
#if LANG_JP
        /// <summary>
        /// 段階分類器の配列
        /// </summary>
#else
        /// <summary>
        /// Array of stage classifiers
        /// </summary>
#endif
        public CvHaarStageClassifier[] StageClassifier
        {
            get
            {
                unsafe
                {
                    WCvHaarClassifierCascade* p = (WCvHaarClassifierCascade*)ptr;
                    WCvHaarStageClassifier* classifier = (WCvHaarStageClassifier*)p->stage_classifier;

                    int length = p->count;
                    CvHaarStageClassifier[] result = new CvHaarStageClassifier[length];
                    for (int i = 0; i < length; i++)
                    {
                        result[i] = new CvHaarStageClassifier(new IntPtr(&classifier[i]));
                    }
                    return result;
                }
            }
        }
#if LANG_JP
        /// <summary>
        /// cvSetImagesForHaarClassifierCascade によって生成されるカスケードの，隠れ最適表現
        /// </summary>
#else
        /// <summary>
        /// Hidden optimized representation of the cascade, created by cvSetImagesForHaarClassifierCascade
        /// </summary>
#endif
        public IntPtr HidCascade
        {
            get
            {
                unsafe
                {
                    return new IntPtr(((WCvHaarClassifierCascade*)ptr)->hid_cascade);
                }
            }
        }

        #endregion

        #region Methods
        #region HaarDetectObjects
#if LANG_JP
        /// <summary>
        /// 与えられた画像からオブジェクトを含む様な矩形領域を検出し，それらの領域を矩形の列として返す．
        /// </summary>
        /// <param name="image">この画像の中からオブジェクトを検出する</param>
        /// <param name="storage">オブジェクト候補の矩形が得られた場合に，その矩形列を保存するメモリストレージ</param>
        /// <returns>CvAvgCompを要素とするCvSeq</returns>
#else
        /// <summary>
        /// Finds rectangular regions in the given image that are likely to contain objects the cascade has been trained for and returns those regions as a sequence of rectangles.
        /// </summary>
        /// <param name="image">Image to detect objects in. </param>
        /// <param name="storage">Memory storage to store the resultant sequence of the object candidate rectangles. </param>
        /// <returns></returns>
#endif
        public CvSeq HaarDetectObjects(CvArr image, CvMemStorage storage)
        {
            return Cv.HaarDetectObjects(image, this, storage);
        }
#if LANG_JP
        /// <summary>
        /// 与えられた画像からオブジェクトを含む様な矩形領域を検出し，それらの領域を矩形の列として返す．
        /// </summary>
        /// <param name="image">この画像の中からオブジェクトを検出する</param>
        /// <param name="storage">オブジェクト候補の矩形が得られた場合に，その矩形列を保存するメモリストレージ</param>
        /// <param name="scale_factor">スキャン毎に探索ウィンドウがスケーリングされる際のスケールファクタ． 例えばこの値が 1.1 ならば，ウィンドウが 10% 大きくなる</param>
        /// <returns>CvAvgCompを要素とするCvSeq</returns>
#else
        /// <summary>
        /// Finds rectangular regions in the given image that are likely to contain objects the cascade has been trained for and returns those regions as a sequence of rectangles.
        /// </summary>
        /// <param name="image">Image to detect objects in. </param>
        /// <param name="storage">Memory storage to store the resultant sequence of the object candidate rectangles. </param>
        /// <param name="scaleFactor">The factor by which the search window is scaled between the subsequent scans, for example, 1.1 means increasing window by 10%. </param>
        /// <returns></returns>
#endif
        public CvSeq HaarDetectObjects(CvArr image, CvMemStorage storage, double scaleFactor)
        {
            return Cv.HaarDetectObjects(image, this, storage, scaleFactor);
        }
#if LANG_JP
        /// <summary>
        /// 与えられた画像からオブジェクトを含む様な矩形領域を検出し，それらの領域を矩形の列として返す．
        /// </summary>
        /// <param name="image">この画像の中からオブジェクトを検出する</param>
        /// <param name="storage">オブジェクト候補の矩形が得られた場合に，その矩形列を保存するメモリストレージ</param>
        /// <param name="scale_factor">スキャン毎に探索ウィンドウがスケーリングされる際のスケールファクタ． 例えばこの値が 1.1 ならば，ウィンドウが 10% 大きくなる</param>
        /// <param name="min_neighbors">（これから 1 を引いた値が）オブジェクトを構成する近傍矩形の最小数となる． min_neighbors-1 よりも少ない矩形しか含まないようなグループは全て棄却される． もし min_neighbors が 0 である場合，この関数はグループを一つも生成せず，候補となる矩形を全て返す．これはユーザがカスタマイズしたグループ化処理を適用したい場合に有用である． </param>
        /// <returns>CvAvgCompを要素とするCvSeq</returns>
#else
        /// <summary>
        /// Finds rectangular regions in the given image that are likely to contain objects the cascade has been trained for and returns those regions as a sequence of rectangles.
        /// </summary>
        /// <param name="image">Image to detect objects in. </param>
        /// <param name="storage">Memory storage to store the resultant sequence of the object candidate rectangles. </param>
        /// <param name="scaleFactor">The factor by which the search window is scaled between the subsequent scans, for example, 1.1 means increasing window by 10%. </param>
        /// <param name="minNeighbors">Minimum number (minus 1) of neighbor rectangles that makes up an object. All the groups of a smaller number of rectangles than min_neighbors-1 are rejected. If min_neighbors is 0, the function does not any grouping at all and returns all the detected candidate rectangles, which may be useful if the user wants to apply a customized grouping procedure. </param>
        /// <returns></returns>
#endif
        public CvSeq HaarDetectObjects(CvArr image, CvMemStorage storage, double scaleFactor, int minNeighbors)
        {
            return Cv.HaarDetectObjects(image, this, storage, scaleFactor, minNeighbors);
        }
#if LANG_JP
        /// <summary>
        /// 与えられた画像からオブジェクトを含む様な矩形領域を検出し，それらの領域を矩形の列として返す．
        /// </summary>
        /// <param name="image">この画像の中からオブジェクトを検出する</param>
        /// <param name="storage">オブジェクト候補の矩形が得られた場合に，その矩形列を保存するメモリストレージ</param>
        /// <param name="scale_factor">スキャン毎に探索ウィンドウがスケーリングされる際のスケールファクタ． 例えばこの値が 1.1 ならば，ウィンドウが 10% 大きくなる</param>
        /// <param name="min_neighbors">（これから 1 を引いた値が）オブジェクトを構成する近傍矩形の最小数となる． min_neighbors-1 よりも少ない矩形しか含まないようなグループは全て棄却される． もし min_neighbors が 0 である場合，この関数はグループを一つも生成せず，候補となる矩形を全て返す．これはユーザがカスタマイズしたグループ化処理を適用したい場合に有用である． </param>
        /// <param name="flags">処理モード</param>
        /// <returns>CvAvgCompを要素とするCvSeq</returns>
#else
        /// <summary>
        /// Finds rectangular regions in the given image that are likely to contain objects the cascade has been trained for and returns those regions as a sequence of rectangles.
        /// </summary>
        /// <param name="image">Image to detect objects in. </param>
        /// <param name="storage">Memory storage to store the resultant sequence of the object candidate rectangles. </param>
        /// <param name="scaleFactor">The factor by which the search window is scaled between the subsequent scans, for example, 1.1 means increasing window by 10%. </param>
        /// <param name="minNeighbors">Minimum number (minus 1) of neighbor rectangles that makes up an object. All the groups of a smaller number of rectangles than min_neighbors-1 are rejected. If min_neighbors is 0, the function does not any grouping at all and returns all the detected candidate rectangles, which may be useful if the user wants to apply a customized grouping procedure. </param>
        /// <param name="flags">Mode of operation. Currently the only flag that may be specified is CV_HAAR_DO_CANNY_PRUNING. If it is set, the function uses Canny edge detector to reject some image regions that contain too few or too much edges and thus can not contain the searched object. The particular threshold values are tuned for face detection and in this case the pruning speeds up the processing. </param>
        /// <returns></returns>
#endif
        public CvSeq HaarDetectObjects(CvArr image, CvMemStorage storage, double scaleFactor, int minNeighbors, HaarDetectionType flags)
        {
            return Cv.HaarDetectObjects(image, this, storage, scaleFactor, minNeighbors, flags);
        }
#if LANG_JP
        /// <summary>
        /// 与えられた画像からオブジェクトを含む様な矩形領域を検出し，それらの領域を矩形の列として返す．
        /// </summary>
        /// <param name="image">この画像の中からオブジェクトを検出する</param>
        /// <param name="storage">オブジェクト候補の矩形が得られた場合に，その矩形列を保存するメモリストレージ</param>
        /// <param name="scale_factor">スキャン毎に探索ウィンドウがスケーリングされる際のスケールファクタ． 例えばこの値が 1.1 ならば，ウィンドウが 10% 大きくなる</param>
        /// <param name="min_neighbors">（これから 1 を引いた値が）オブジェクトを構成する近傍矩形の最小数となる． min_neighbors-1 よりも少ない矩形しか含まないようなグループは全て棄却される． もし min_neighbors が 0 である場合，この関数はグループを一つも生成せず，候補となる矩形を全て返す．これはユーザがカスタマイズしたグループ化処理を適用したい場合に有用である． </param>
        /// <param name="flags">処理モード</param>
        /// <param name="min_size">最小ウィンドウサイズ．デフォルトでは分類器の学習に用いられたサンプルのサイズが設定される（顔検出の場合は，~20×20）.</param>
        /// <returns>CvAvgCompを要素とするCvSeq</returns>
#else
        /// <summary>
        /// Finds rectangular regions in the given image that are likely to contain objects the cascade has been trained for and returns those regions as a sequence of rectangles.
        /// </summary>
        /// <param name="image">Image to detect objects in. </param>
        /// <param name="storage">Memory storage to store the resultant sequence of the object candidate rectangles. </param>
        /// <param name="scaleFactor">The factor by which the search window is scaled between the subsequent scans, for example, 1.1 means increasing window by 10%. </param>
        /// <param name="minNeighbors">Minimum number (minus 1) of neighbor rectangles that makes up an object. All the groups of a smaller number of rectangles than min_neighbors-1 are rejected. If min_neighbors is 0, the function does not any grouping at all and returns all the detected candidate rectangles, which may be useful if the user wants to apply a customized grouping procedure. </param>
        /// <param name="flags">Mode of operation. Currently the only flag that may be specified is CV_HAAR_DO_CANNY_PRUNING. If it is set, the function uses Canny edge detector to reject some image regions that contain too few or too much edges and thus can not contain the searched object. The particular threshold values are tuned for face detection and in this case the pruning speeds up the processing. </param>
        /// <param name="minSize">Minimum window size. By default, it is set to the size of samples the classifier has been trained on (~20×20 for face detection). </param>
        /// <returns></returns>
#endif
        public CvSeq HaarDetectObjects(CvArr image, CvMemStorage storage, double scaleFactor, int minNeighbors, HaarDetectionType flags, CvSize minSize)
        {
            return Cv.HaarDetectObjects(image, this, storage, scaleFactor, minNeighbors, flags, minSize);
        }
        #endregion
        #region Run
#if LANG_JP
        /// <summary>
        /// ブーストされた分類器のカスケードを，与えられた画像位置で実行する
        /// </summary>
        /// <param name="pt">解析する領域の左上の角</param>
        /// <returns>分析対象の領域が全ての分類器ステージを通過した場合（これは候補の一つになる）はtrue，そうでなければfalse．</returns>
#else
        /// <summary>
        /// Runs cascade of boosted classifier at given image location
        /// </summary>
        /// <param name="pt">Top-left corner of the analyzed region. Size of the region is a original window size scaled by the currenly set scale. The current window size may be retrieved using  cvGetHaarClassifierCascadeWindowSize function. </param>
        /// <returns>positive value if the analyzed rectangle passed all the classifier stages (it is a candidate) and zero or negative value otherwise. </returns>
#endif
	    public bool Run( CvPoint pt )
	    {
		    return Cv.RunHaarClassifierCascade(this, pt);
	    }
#if LANG_JP
        /// <summary>
        /// ブーストされた分類器のカスケードを，与えられた画像位置で実行する
        /// </summary>
        /// <param name="pt">解析する領域の左上の角</param>
        /// <param name="start_stage">0から始まるインデックスで，カスケードステージをどこ から開始するかを決定する</param>
        /// <returns>分析対象の領域が全ての分類器ステージを通過した場合（これは候補の一つになる）はtrue，そうでなければfalse．</returns>
#else
        /// <summary>
        /// Runs cascade of boosted classifier at given image location
        /// </summary>
        /// <param name="pt">Top-left corner of the analyzed region. Size of the region is a original window size scaled by the currenly set scale. The current window size may be retrieved using  cvGetHaarClassifierCascadeWindowSize function. </param>
        /// <param name="startStage">Initial zero-based index of the cascade stage to start from. The function assumes that all the previous stages are passed. This feature is used internally by  cvHaarDetectObjects for better processor cache utilization. </param>
        /// <returns>positive value if the analyzed rectangle passed all the classifier stages (it is a candidate) and zero or negative value otherwise. </returns>
#endif
        public bool Run(CvPoint pt, bool startStage)
        {
            return Cv.RunHaarClassifierCascade(this, pt, startStage);
        }
        #endregion 
	    #region SetImages
#if LANG_JP
        /// <summary>
        /// 画像を隠れ分類器カスケードに割り当てる．
        /// </summary>
        /// <param name="sum">32 ビット整数シングルチャンネルのインテグラルイメージ</param>
        /// <param name="sqsum">64ビット浮動小数点型のシングルチャンネル画像の各ピクセルを二乗した値に対するインテグラルイメージ</param>
        /// <param name="tilted_sum">32 ビット整数型のシングルチャンネル画像を 45°傾けたものに対するインテグラルイメージ</param>
        /// <param name="scale">カスケードのウィンドウスケール</param>
#else
        /// <summary>
        /// Assigns images to the hidden cascade
        /// </summary>
        /// <param name="sum">Integral (sum) single-channel image of 32-bit integer format. This image as well as the two subsequent images are used for fast feature evaluation and brightness/contrast normalization. They all can be retrieved from input 8-bit or floating point single-channel image using The function cvIntegral. </param>
        /// <param name="sqsum">Square sum single-channel image of 64-bit floating-point format. </param>
        /// <param name="tiltedSum">Tilted sum single-channel image of 32-bit integer format. </param>
        /// <param name="scale">Window scale for the cascade. If scale=1, original window size is used (objects of that size are searched) - the same size as specified in cvLoadHaarClassifierCascade  (24x24 in case of "&lt;default_face_cascade&gt;"), if scale=2, a two times larger window is used (48x48 in case of default face cascade). While this will speed-up search about four times, faces smaller than 48x48 cannot be detected. </param>
#endif
	    public void SetImages( CvArr sum, CvArr sqsum, CvArr tiltedSum, double scale )
	    {
		    Cv.SetImagesForHaarClassifierCascade(this, sum, sqsum, tiltedSum, scale);
	    }
	    #endregion 
        #endregion
    }
}