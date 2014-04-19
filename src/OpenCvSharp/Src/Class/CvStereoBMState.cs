using System;
using System.Runtime.InteropServices;

namespace OpenCvSharp
{
#if LANG_JP
    /// <summary>
    /// ブロックマッチングによるステレオマッチングアルゴリズムのための構造体
    /// </summary>
#else
    /// <summary>
    /// The structure for block matching stereo correspondence algorithm
    /// </summary>
#endif
    public class CvStereoBMState : DisposableCvObject
    {
        /// <summary>
        /// Track whether Dispose has been called
        /// </summary>
        private bool disposed;

        #region Init and Disposal
#if LANG_JP
        /// <summary>
        /// ステレオブロックマッチング構造体を作成する (CreateStereoBMState)
        /// </summary>
        /// <returns>ステレオブロックマッチング構造体</returns>
#else
        /// <summary>
        /// Creates block matching stereo correspondence structure (CreateStereoBMState)
        /// </summary>
#endif
        public CvStereoBMState()
            : this(StereoBMPreset.Basic, 0)
        {
        }
#if LANG_JP
        /// <summary>
        /// ステレオブロックマッチング構造体を作成する (CreateStereoBMState)
        /// </summary>
        /// <param name="preset">あらかじめ定義されたパラメータのID．構造体を作成した後で，任意のパラメータをオーバーライドできる． </param>
#else
        /// <summary>
        /// Creates block matching stereo correspondence structure (CreateStereoBMState)
        /// </summary>
        /// <param name="preset">ID of one of the pre-defined parameter sets. Any of the parameters can be overridden after creating the structure. </param>
#endif
        public CvStereoBMState(StereoBMPreset preset)
            : this(preset, 0)
        {
        }
#if LANG_JP
        /// <summary>
        /// ステレオブロックマッチング構造体を作成する (CreateStereoBMState)
        /// </summary>
        /// <param name="preset">あらかじめ定義されたパラメータのID．構造体を作成した後で，任意のパラメータをオーバーライドできる． </param>
        /// <param name="numberOfDisparities">視差数（最大視差-最小視差）． このパラメータが 0 の場合，preset から選択される． そうでない場合は，与えられた値が preset の値をオーバーライドする．</param>
#else
        /// <summary>
        /// Creates block matching stereo correspondence structure (CreateStereoBMState)
        /// </summary>
        /// <param name="preset">ID of one of the pre-defined parameter sets. Any of the parameters can be overridden after creating the structure. </param>
        /// <param name="numberOfDisparities">The number of disparities. If the parameter is 0, it is taken from the preset, otherwise the supplied value overrides the one from preset. </param>
#endif
        public CvStereoBMState(StereoBMPreset preset, int numberOfDisparities)
        {
            ptr = NativeMethods.cvCreateStereoBMState(preset, numberOfDisparities);
            if (ptr == IntPtr.Zero)
                throw new OpenCvSharpException("Failed to create CvStereoBMState");
        }

#if LANG_JP
        /// <summary>
        /// ポインタから初期化
        /// </summary>
        /// <param name="ptr">CvStereoBMState*</param>
#else
        /// <summary>
        /// Initializes from native pointer
        /// </summary>
        /// <param name="ptr"></param>
#endif
        public CvStereoBMState(IntPtr ptr)
        {
            this.ptr = ptr;
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
                        NativeMethods.cvReleaseStereoBMState(ref ptr);
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
        /// sizeof(CvStereoBMState)
        /// </summary>
        public static readonly int SizeOf = Marshal.SizeOf(typeof(WCvStereoBMState));


#if LANG_JP
        /// <summary>
        /// 事前フィルタのタイプ (現在のところ0)
        /// </summary>
#else
        /// <summary>
        /// pre filters' type (0 for now)
        /// </summary>
#endif
        public int PreFilterType
        {
            get
            {
                unsafe
                {
                    return ((WCvStereoBMState*)ptr)->preFilterType;
                }
            }
            set
            {
                unsafe
                {
                    ((WCvStereoBMState*)ptr)->preFilterType = value;
                }
            }
        }
#if LANG_JP
        /// <summary>
        /// 事前フィルタのサイズ (おおよそ5x5から21x21)
        /// </summary>
#else
        /// <summary>
        /// pre filters' size (~5x5..21x21)
        /// </summary>
#endif
        public int PreFilterSize
        {
            get
            {
                unsafe
                {
                    return ((WCvStereoBMState*)ptr)->preFilterSize;
                }
            }
            set
            {
                unsafe
                {
                    ((WCvStereoBMState*)ptr)->preFilterSize = value;
                }
            }
        }
#if LANG_JP
        /// <summary>
        /// 事前フィルタのキャップ (おおよそ31以下)
        /// </summary>
#else
        /// <summary>
        /// pre filters' cap (up to ~31)
        /// </summary>
#endif
        public int PreFilterCap
        {
            get
            {
                unsafe
                {
                    return ((WCvStereoBMState*)ptr)->preFilterCap;
                }
            }
            set
            {
                unsafe
                {
                    ((WCvStereoBMState*)ptr)->preFilterCap = value;
                }
            }
        }

#if LANG_JP
        /// <summary>
        /// SAD(Sum of Absolute Difference)の窓の大きさ (5x5から21x21)
        /// </summary>
#else
        /// <summary>
        /// window size of correspondence using Sum of Absolute Difference(SAD) (Could be 5x5..21x21)
        /// </summary>
#endif
        public int SADWindowSize
        {
            get
            {
                unsafe
                {
                    return ((WCvStereoBMState*)ptr)->SADWindowSize;
                }
            }
            set
            {
                unsafe
                {
                    ((WCvStereoBMState*)ptr)->SADWindowSize = value;
                }
            }
        }
#if LANG_JP
        /// <summary>
        /// SAD(Sum of Absolute Difference)の最小視差 (=0)
        /// </summary>
#else
        /// <summary>
        /// minimum disparity of correspondence using Sum of Absolute Difference(SAD) (=0)
        /// </summary>
#endif
        public int MinDisparity
        {
            get
            {
                unsafe
                {
                    return ((WCvStereoBMState*)ptr)->minDisparity;
                }
            }
            set
            {
                unsafe
                {
                    ((WCvStereoBMState*)ptr)->minDisparity = value;
                }
            }
        }
#if LANG_JP
        /// <summary>
        /// SAD(Sum of Absolute Difference)の 最大視差-最小視差
        /// </summary>
#else
        /// <summary>
        /// maximum disparity - minimum disparity of correspondence using Sum of Absolute Difference(SAD)
        /// </summary>
#endif
        public int NumberOfDisparities
        {
            get
            {
                unsafe
                {
                    return ((WCvStereoBMState*)ptr)->numberOfDisparities;
                }
            }
            set
            {
                unsafe
                {
                    ((WCvStereoBMState*)ptr)->numberOfDisparities = value;
                }
            }
        }

#if LANG_JP
        /// <summary>
        /// 事後フィルタの、テクスチャの無い領域を無視する際の閾値
        /// </summary>
#else
        /// <summary>
        /// post filters' areas with no texture are ignored
        /// </summary>
#endif
        public int TextureThreshold
        {
            get
            {
                unsafe
                {
                    return ((WCvStereoBMState*)ptr)->textureThreshold;
                }
            }
            set
            {
                unsafe
                {
                    ((WCvStereoBMState*)ptr)->textureThreshold = value;
                }
            }
        }
#if LANG_JP
        /// <summary>
        /// 事後フィルタの、異なる視差でのマッチが近辺にある場合にそのピクセルを除外する際の比率?
        /// </summary>
#else
        /// <summary>
        /// filter out pixels if there are other close matches with different disparity
        /// </summary>
#endif
        public int UniquenessRatio
        {
            get
            {
                unsafe
                {
                    return ((WCvStereoBMState*)ptr)->uniquenessRatio;
                }
            }
            set
            {
                unsafe
                {
                    ((WCvStereoBMState*)ptr)->uniquenessRatio = value;
                }
            }
        }
#if LANG_JP
        /// <summary>
        /// 事後フィルタの視差変化ウィンドウ（利用されない）
        /// </summary>
#else
        /// <summary>
        /// Disparity variation window (not used)
        /// </summary>
#endif
        [Obsolete("", true)]
        public int SpeckleWindowSize
        {
            get
            {
                unsafe
                {
                    return ((WCvStereoBMState*)ptr)->speckleWindowSize;
                }
            }
            set
            {
                unsafe
                {
                    ((WCvStereoBMState*)ptr)->speckleWindowSize = value;
                }
            }
        }
#if LANG_JP
        /// <summary>
        /// 事後フィルタのウィンドウの変化範囲（利用されない）
        /// </summary>
#else
        /// <summary>
        /// Acceptable range of variation in window (not used)
        /// </summary>
#endif
        [Obsolete("", true)]
        public int SpeckleRange
        {
            get
            {
                unsafe
                {
                    return ((WCvStereoBMState*)ptr)->speckleRange;
                }
            }
            set
            {
                unsafe
                {
                    ((WCvStereoBMState*)ptr)->speckleRange = value;
                }
            }
        }
        #endregion

        #region Methods
#if LANG_JP
        /// <summary>
        /// ブロックマッチングアルゴリズムを用いて視差画像を計算する (cvFindStereoCorrespondenceBM)
        /// </summary>
        /// <param name="left">左画像．シングルチャンネル，8ビット．</param>
        /// <param name="right">右画像．左画像と同じサイズ，同じ種類．</param>
        /// <param name="disparity">出力の視差配列．シングルチャンネル，16ビット，符号有り整数，入力画像と同サイズ．各要素は，計算された視差であり，16倍されて整数値にまるめられる．</param>
#else
        /// <summary>
        /// Computes the disparity map using block matching algorithm (cvFindStereoCorrespondenceBM)
        /// </summary>
        /// <param name="left">The left single-channel, 8-bit image. </param>
        /// <param name="right">The right image of the same size and the same type. </param>
        /// <param name="disparity">The output single-channel 16-bit signed disparity map of the same size as input images. Its elements will be the computed disparities, multiplied by 16 and rounded to integer's. </param>
#endif
        public void FindStereoCorrespondence(CvArr left, CvArr right, CvArr disparity)
        {
            Cv.FindStereoCorrespondenceBM(left, right, disparity, this);
        }
        #endregion
    }
}