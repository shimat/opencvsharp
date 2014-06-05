using System;

namespace OpenCvSharp
{
    // ReSharper disable InconsistentNaming

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
        private bool disposed;

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
                throw new ArgumentNullException("points");
            
            ptr = NativeMethods.cvCreatePOSITObject(points, points.Length);
            if (ptr == IntPtr.Zero)
                throw new OpenCvSharpException();
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
            if (!disposed)
            {
                try
                {
                    if (disposing)
                    {
                    }
                    if (IsEnabledDispose)
                    {
                        NativeMethods.cvReleasePOSITObject(ref ptr);
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

        #region Methods
        #region POSIT
#if LANG_JP
        /// <summary>
        /// POSITアルゴリズムの実装
        /// </summary>
        /// <param name="imagePoints">オブジェクト上の点を二次元画像平面上へ投影して得られる点群</param>
        /// <param name="focalLength">使用するカメラの焦点距離</param>
        /// <param name="criteria">反復POSITアルゴリズムの終了条件</param>
        /// <param name="rotationMatrix">回転行列</param>
        /// <param name="translationVector">並進ベクトル</param>
#else
        /// <summary>
        /// Implements POSIT algorithm
        /// </summary>
        /// <param name="imagePoints">Object points projections on the 2D image plane.</param>
        /// <param name="focalLength">Focal length of the camera used.</param>
        /// <param name="criteria">Termination criteria of the iterative POSIT algorithm.</param>
        /// <param name="rotationMatrix">Matrix of rotations.</param>
        /// <param name="translationVector">Translation vector.</param>
#endif
        public void POSIT(CvPoint2D32f[] imagePoints, double focalLength,
              CvTermCriteria criteria, out float[,] rotationMatrix, out float[] translationVector)
        {
            Cv.POSIT(this, imagePoints, focalLength, criteria, out rotationMatrix, out translationVector);
        }
        #endregion
        #endregion
    }
}
