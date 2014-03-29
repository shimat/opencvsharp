/*
 * (C) 2008-2014 shimat
 * This code is licenced under the LGPL.
 */

using System;
using System.Collections.Generic;
using System.Text;

namespace OpenCvSharp
{
#if LANG_JP
    /// <summary>
    /// オブジェクト構造体
    /// </summary>
#else
    /// <summary>
    /// Structure containing object information
    /// </summary>
#endif
    public class CvPOSITObject : DisposableCvObject
    {
        /// <summary>
        /// Track whether Dispose has been called
        /// </summary>
        private bool _disposed = false;

        #region Init and disposal
#if LANG_JP
        /// <summary>
        /// cvCreatePOSITObjectで初期化
        /// </summary>
        /// <param name="points">3次元オブジェクトモデル上の点データの配列</param>
#else
        /// <summary>
        /// Constructor (cvCreatePOSITObject)
        /// </summary>
        /// <param name="points">Points of the 3D object model. </param>
#endif
        public CvPOSITObject(CvPoint3D32f[] points)
        {
            if (points == null)
            {
                throw new ArgumentNullException("points");
            }
            this.ptr = NativeMethods.cvCreatePOSITObject(points, points.Length);
            if (this.ptr == IntPtr.Zero)
            {
                throw new OpenCvSharpException();
            }
        }
#if LANG_JP
        /// <summary>
        /// ポインタから初期化
        /// </summary>
#else
        /// <summary>
        /// Constructs from pointer
        /// </summary>
        /// <param name="ptr">struct CvPOSITObject*</param>
#endif
        public CvPOSITObject(IntPtr ptr)
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
            if (!this._disposed)
            {
                // 継承したクラス独自の解放処理
                try
                {
                    if (disposing)
                    {
                    }
                    if (IsEnabledDispose)
                    {
                        NativeMethods.cvReleasePOSITObject(ref ptr);
                    }
                    this._disposed = true;
                }
                finally
                {
                    // 親の解放処理
                    base.Dispose(disposing);
                }
            }
        }
        #endregion

        #region Methods
        #region POSIT
#if LANG_JP
        /// <summary>
        /// POSITアルゴリズムの実装
        /// </summary>
        /// <param name="image_points">オブジェクト上の点を二次元画像平面上へ投影して得られる点群</param>
        /// <param name="focal_length">使用するカメラの焦点距離</param>
        /// <param name="criteria">反復POSITアルゴリズムの終了条件</param>
        /// <param name="rotation_matrix">回転行列</param>
        /// <param name="translation_vector">並進ベクトル</param>
#else
        /// <summary>
        /// Implements POSIT algorithm
        /// </summary>
        /// <param name="image_points">Object points projections on the 2D image plane.</param>
        /// <param name="focal_length">Focal length of the camera used.</param>
        /// <param name="criteria">Termination criteria of the iterative POSIT algorithm.</param>
        /// <param name="rotation_matrix">Matrix of rotations.</param>
        /// <param name="translation_vector">Translation vector.</param>
#endif
        public void POSIT(CvPoint2D32f[] image_points, double focal_length,
              CvTermCriteria criteria, out float[,] rotation_matrix, out float[] translation_vector)
        {
            Cv.POSIT(this, image_points, focal_length, criteria, out rotation_matrix, out translation_vector);
        }
        #endregion
        #endregion
    }
}
