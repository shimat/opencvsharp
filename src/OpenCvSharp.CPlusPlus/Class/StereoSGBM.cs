/*
 * (C) 2008-2013 Schima
 * This code is licenced under the LGPL.
 */

using System;
using System.Collections.Generic;
using System.Text;
using OpenCvSharp;
using OpenCvSharp.Utilities;

namespace OpenCvSharp.CPlusPlus
{
#if LANG_JP
    /// <summary>
    /// セミグローバルブロックマッチングアルゴリズムを用てステレオ対応点探索を行うためのクラス
    /// </summary>
#else
    /// <summary>
    /// Semi-Global Stereo Matching
    /// </summary>
#endif
    public partial class StereoSGBM : DisposableCvObject
    {
        #region Fields
        /// <summary>
        /// sizeof(StereoSGBM)
        /// </summary>
        public static readonly int SizeOf;
        /// <summary>
        /// Track whether Dispose has been called
        /// </summary>
        private bool disposed = false;
        #endregion

        #region Init and Disposal
        /// <summary>
        /// static constructor
        /// </summary>
        static StereoSGBM()
        {
            try
            {
                SizeOf = CppInvoke.StereoSGBM_sizeof();
            }
            catch (DllNotFoundException e)
            {
                PInvokeHelper.DllImportError(e);
                throw;
            }
            catch (BadImageFormatException e)
            {
                PInvokeHelper.DllImportError(e);
                throw;
            }
            catch (Exception)
            {
                throw;
            }
        }
        #region Constructor
#if LANG_JP
        /// <summary>
        /// デフォルトのパラメータで初期化.
        /// 実際は numberOfDisparities だけは指定する必要がある.
        /// </summary>
#else
        /// <summary>
        /// Default constructor
        /// </summary>
#endif
        public StereoSGBM()
        {
            ptr = CppInvoke.StereoSGBM_new1();
            if (ptr == IntPtr.Zero)
                throw new OpenCvSharpException();
        }

#if LANG_JP
        /// <summary>
        /// StereoSGBM コンストラクタ
        /// </summary>
        /// <param name="minDisparity">取り得る最小の視差値．通常は0ですが，平行化のアルゴリズムによって画像が移動する場合があるので，それに応じてこのパラメータを調整する必要があります.</param>
        /// <param name="numDisparities">取り得る最大の視差値．常に0より大きい値となります．現在の実装では，この値は16の倍数でなければいけません.</param>
        /// <param name="SADWindowSize">マッチングされるブロックのサイズ．必ず奇数 >=1  となります．通常は， 3..11  の範囲内の値になります.</param>
        /// <param name="P1">視差のなめらかさを制御するパラメータ．この値が大きくなると，視差がなめらかになります．P1は隣り合うピクセル間で視差が +1 または -1 変化した場合のペナルティです．このアルゴリズムでは， P2 &gt; P2 でなければいけません．</param>
        /// <param name="P2">視差のなめらかさを制御するパラメータ．この値が大きくなると，視差がなめらかになります．P2 は，隣り合うピクセル間で視差が 1 よりも大きく 変化した場合のペナルティです．このアルゴリズムでは， P2 &gt; P2 でなければいけません．</param>
        /// <param name="disp12MaxDiff">left-right 視差チェックにおけて許容される最大の差（整数のピクセル単位）．チェックを行わない場合は，これを 0 または負の値にしてください.</param>
        /// <param name="preFilterCap">事前フィルタにおいて，画像ピクセルを切り捨てる閾値．このアルゴリズムは，まず，各ピクセルのx-微分を求め，その値を [-preFilterCap, preFilterCap] 区間で切り取ります．そして，その結果が Birchfield-Tomasi コスト関数に渡されます.</param>
        /// <param name="uniquenessRatio">パーセント単位で表現されるマージン．正しい値を求めるため，求められた最適な（最小の）コスト関数値は，このマージン以上の差で2番目に最適な値に「勝つ」必要があります.</param>
        /// <param name="speckleWindowSize">ノイズスペックルや無効なピクセルが考慮されたなめらかな視差領域の最大サイズ．スペックルフィルタを無効にする場合は，これを0にセットしてください．そうでない場合は，50-200 の範囲内の値にします.</param>
        /// <param name="speckleRange">それぞれの連結成分における最大視差値．スペックルフィルタリングを行う場合，これは正の値で16の倍数にしてください．通常は，16 または 32 が適切な値です.</param>
        /// <param name="fullDP">完全な 2 パス，動的計画法のアルゴリズムを動作させるには，これを true にします．このアルゴリズムは， O(W*H*numDisparities) バイトのメモリを消費します．これは，640x480 のステレオに対しても大きな値で，HD-サイズの画像の場合は莫大な値になります．デフォルトでは，これは false です.</param>
#else
        /// <summary>
        /// StereoSGBM Constructor
        /// </summary>
        /// <param name="minDisparity"></param>
        /// <param name="numDisparities"></param>
        /// <param name="SADWindowSize"></param>
        /// <param name="P1"></param>
        /// <param name="P2"></param>
        /// <param name="disp12MaxDiff"></param>
        /// <param name="preFilterCap"></param>
        /// <param name="uniquenessRatio"></param>
        /// <param name="speckleWindowSize"></param>
        /// <param name="speckleRange"></param>
        /// <param name="fullDP"></param>
#endif
        public StereoSGBM(int minDisparity, int numDisparities,
            int SADWindowSize, int P1, int P2, int disp12MaxDiff, int preFilterCap, int uniquenessRatio, int speckleWindowSize, int speckleRange, bool fullDP)
        {
            ptr = CppInvoke.StereoSGBM_new2(minDisparity, numDisparities, SADWindowSize, P1, P2, disp12MaxDiff, preFilterCap, uniquenessRatio, speckleWindowSize, speckleRange, fullDP);
            if (ptr == IntPtr.Zero)
                throw new OpenCvSharpException();
        }
        #endregion
        #region Dispose
#if LANG_JP
        /// <summary>
        /// リソースの解放
        /// </summary>
#else
        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
#endif
        public void Release()
        {
            Dispose(true);
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
            if (!this.disposed)
            {
                // 継承したクラス独自の解放処理
                try
                {
                    if (disposing)
                    {                        
                    }
                    if (IsEnabledDispose)
                    {
                        CppInvoke.StereoSGBM_delete(ptr);
                    }
                    this.disposed = true;
                }
                finally
                {
                    // 親の解放処理
                    base.Dispose(disposing);
                }
            }
        }
        #endregion
        #endregion

        #region Properties
#if LANG_JP
        /// <summary>
        /// 
        /// </summary>
#else
        /// <summary>
        /// 
        /// </summary>
#endif
        public int MinDisparity
        {
            get
            {
                if (disposed)
                    throw new ObjectDisposedException("StereoSGBM");
                return CppInvoke.StereoSGBM_minDisparity_get(ptr);
            }
            set
            {
                if (disposed)
                    throw new ObjectDisposedException("StereoSGBM");
                unsafe
                {
                    CppInvoke.StereoSGBM_minDisparity_set(ptr, value);
                }
            }
        }
#if LANG_JP
        /// <summary>
        /// 
        /// </summary>
#else
        /// <summary>
        /// 
        /// </summary>
#endif
        public int NumberOfDisparities
        {
            get
            {
                if (disposed)
                    throw new ObjectDisposedException("StereoSGBM");
                return CppInvoke.StereoSGBM_numberOfDisparities_get(ptr);
            }
            set
            {
                if (disposed)
                    throw new ObjectDisposedException("StereoSGBM");
                CppInvoke.StereoSGBM_numberOfDisparities_set(ptr, value);
            }
        }
#if LANG_JP
        /// <summary>
        /// 
        /// </summary>
#else
        /// <summary>
        /// 
        /// </summary>
#endif
        public int SADWindowSize
        {
            get
            {
                if (disposed)
                    throw new ObjectDisposedException("StereoSGBM");

                    return CppInvoke.StereoSGBM_SADWindowSize_get(ptr);
            }
            set
            {
                if (disposed)
                    throw new ObjectDisposedException("StereoSGBM");
                CppInvoke.StereoSGBM_SADWindowSize_set(ptr, value);
            }
        }
#if LANG_JP
        /// <summary>
        /// 
        /// </summary>
#else
        /// <summary>
        /// 
        /// </summary>
#endif
        public int PreFilterCap
        {
            get
            {
                if (disposed)
                    throw new ObjectDisposedException("StereoSGBM");
                return CppInvoke.StereoSGBM_preFilterCap_get(ptr);
            }
            set
            {
                if (disposed)
                    throw new ObjectDisposedException("StereoSGBM");
                CppInvoke.StereoSGBM_preFilterCap_set(ptr, value);
            }
        }
#if LANG_JP
        /// <summary>
        /// 
        /// </summary>
#else
        /// <summary>
        /// 
        /// </summary>
#endif
        public int UniquenessRatio
        {
            get
            {
                if (disposed)
                    throw new ObjectDisposedException("StereoSGBM");
                return CppInvoke.StereoSGBM_uniquenessRatio_get(ptr);
            }
            set
            {
                if (disposed)
                    throw new ObjectDisposedException("StereoSGBM");
                CppInvoke.StereoSGBM_uniquenessRatio_set(ptr, value);
            }
        }
#if LANG_JP
        /// <summary>
        /// 
        /// </summary>
#else
        /// <summary>
        /// 
        /// </summary>
#endif
        public int P1
        {
            get
            {
                if (disposed)
                    throw new ObjectDisposedException("StereoSGBM");
                return CppInvoke.StereoSGBM_P1_get(ptr);
            }
            set
            {
                if (disposed)
                    throw new ObjectDisposedException("StereoSGBM");
                CppInvoke.StereoSGBM_P1_set(ptr, value);
            }
        }
#if LANG_JP
        /// <summary>
        /// 
        /// </summary>
#else
        /// <summary>
        /// 
        /// </summary>
#endif
        public int P2
        {
            get
            {
                if (disposed)
                    throw new ObjectDisposedException("StereoSGBM");
                return CppInvoke.StereoSGBM_P2_get(ptr);
            }
            set
            {
                if (disposed)
                    throw new ObjectDisposedException("StereoSGBM");
                CppInvoke.StereoSGBM_P2_set(ptr, value);
            }
        }
#if LANG_JP
        /// <summary>
        /// 
        /// </summary>
#else
        /// <summary>
        /// 
        /// </summary>
#endif
        public int SpeckleWindowSize
        {
            get
            {
                if (disposed)
                    throw new ObjectDisposedException("StereoSGBM");
                return CppInvoke.StereoSGBM_speckleWindowSize_get(ptr);
            }
            set
            {
                if (disposed)
                    throw new ObjectDisposedException("StereoSGBM");
                CppInvoke.StereoSGBM_speckleWindowSize_set(ptr, value);
            }
        }
#if LANG_JP
        /// <summary>
        /// 
        /// </summary>
#else
        /// <summary>
        /// 
        /// </summary>
#endif
        public int SpeckleRange
        {
            get
            {
                if (disposed)
                    throw new ObjectDisposedException("StereoSGBM");
                return CppInvoke.StereoSGBM_speckleRange_get(ptr);
            }
            set
            {
                if (disposed)
                    throw new ObjectDisposedException("StereoSGBM");
                CppInvoke.StereoSGBM_speckleRange_set(ptr, value);
            }
        }
#if LANG_JP
        /// <summary>
        /// 
        /// </summary>
#else
        /// <summary>
        /// 
        /// </summary>
#endif
        public int Disp12MaxDiff
        {
            get
            {
                if (disposed)
                    throw new ObjectDisposedException("StereoSGBM");
                return CppInvoke.StereoSGBM_disp12MaxDiff_get(ptr);
            }
            set
            {
                if (disposed)
                    throw new ObjectDisposedException("StereoSGBM");
                CppInvoke.StereoSGBM_disp12MaxDiff_set(ptr, value);
            }
        }
#if LANG_JP
        /// <summary>
        /// 
        /// </summary>
#else
        /// <summary>
        /// 
        /// </summary>
#endif
        public bool FullDP
        {
            get
            {
                if (disposed)
                    throw new ObjectDisposedException("StereoSGBM");
                return CppInvoke.StereoSGBM_fullDP_get(ptr) != 0;
            }
            set
            {
                if (disposed)
                    throw new ObjectDisposedException("StereoSGBM");
                CppInvoke.StereoSGBM_fullDP_set(ptr, value ? 1 : 0);
            }
        }
        #endregion

        #region Methods
#if LANG_JP
        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <param name="disp"></param>
#else
        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <param name="disp"></param>
#endif
        public void FindCorrespondence(Mat left, Mat right, Mat disp)
        {
            if (disposed)
                throw new ObjectDisposedException("StereoSGBM");
            if(left == null)
                throw new ArgumentNullException("left");
            if(right == null)
                throw new ArgumentNullException("right");
            if(disp == null)
                throw new ArgumentNullException("disp");

            CppInvoke.StereoSGBM_exec(ptr, left.CvPtr, right.CvPtr, disp.CvPtr);
        }
        #endregion
    }
}
