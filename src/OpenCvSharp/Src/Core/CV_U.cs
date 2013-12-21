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
    public static partial class Cv
    {
        #region Undistort2
#if LANG_JP
        /// <summary>
        /// 半径方向や円周方向のレンズ歪みを補正するために画像を変換する．
        /// </summary>
        /// <param name="src">入力画像（歪みあり）</param>
        /// <param name="dst">出力画像（補正済み）</param>
        /// <param name="intrinsicMatrix">カメラ内部行列 (A) [fx 0 cx; 0 fy cy; 0 0 1]. </param>
        /// <param name="distortionCoeffs">歪み係数ベクトル． 4x1 または 1x4 [k1, k2, p1, p2]. </param>
#else
        /// <summary>
        /// Transforms image to compensate lens distortion.
        /// </summary>
        /// <param name="src">The input (distorted) image. </param>
        /// <param name="dst">The output (corrected) image. </param>
        /// <param name="intrinsicMatrix">The camera matrix (A) [fx 0 cx; 0 fy cy; 0 0 1]. </param>
        /// <param name="distortionCoeffs">The vector of distortion coefficients, 4x1 or 1x4 [k1, k2, p1, p2]. </param>
#endif
        public static void Undistort2(CvArr src, CvArr dst, CvMat intrinsicMatrix, CvMat distortionCoeffs)
        {
            Undistort2(src, dst, intrinsicMatrix, distortionCoeffs, null);
        }
#if LANG_JP
        /// <summary>
        /// 半径方向や円周方向のレンズ歪みを補正するために画像を変換する．
        /// </summary>
        /// <param name="src">入力画像（歪みあり）</param>
        /// <param name="dst">出力画像（補正済み）</param>
        /// <param name="intrinsicMatrix">カメラ内部行列 (A) [fx 0 cx; 0 fy cy; 0 0 1]. </param>
        /// <param name="distortionCoeffs">歪み係数ベクトル． 4x1 または 1x4 [k1, k2, p1, p2]. </param>
        /// <param name="newCameraMatrix"></param>
#else
        /// <summary>
        /// Transforms image to compensate lens distortion.
        /// </summary>
        /// <param name="src">The input (distorted) image. </param>
        /// <param name="dst">The output (corrected) image. </param>
        /// <param name="intrinsicMatrix">The camera matrix (A) [fx 0 cx; 0 fy cy; 0 0 1]. </param>
        /// <param name="distortionCoeffs">The vector of distortion coefficients, 4x1 or 1x4 [k1, k2, p1, p2]. </param>
        /// <param name="newCameraMatrix"></param>
#endif
        public static void Undistort2(CvArr src, CvArr dst, CvMat intrinsicMatrix, CvMat distortionCoeffs, CvMat newCameraMatrix)
        {
            if (src == null)
                throw new ArgumentNullException("src");
            if (dst == null)
                throw new ArgumentNullException("dst");
            if (intrinsicMatrix == null)
                throw new ArgumentNullException("intrinsicMatrix");
            if (distortionCoeffs == null)
                throw new ArgumentNullException("distortionCoeffs");

            IntPtr newCameraMatrixPtr = (newCameraMatrix == null) ? IntPtr.Zero : newCameraMatrix.CvPtr;
            CvInvoke.cvUndistort2(src.CvPtr, dst.CvPtr, intrinsicMatrix.CvPtr, distortionCoeffs.CvPtr, newCameraMatrixPtr);
        }
        #endregion
        #region UndistortPoints
#if LANG_JP
        /// <summary>
        /// 観測された点座標から理想的な点座標を計算する
        /// </summary>
        /// <param name="src">カメラで観測された点座標の集合．</param>
        /// <param name="dst">歪み補正後に逆透視投影を行った理想的な点座標.</param>
        /// <param name="cameraMatrix">カメラ行列 A=[fx 0 cx; 0 fy cy; 0 0 1] </param>
        /// <param name="distCoeffs">歪み係数のベクトル，4x1, 1x4, 5x1, 1x5．</param>
        /// <param name="R">オブジェクト空間での平行化変換（3x3 行列）． cvStereoRectify で計算された値， R1 あるいは R2 が渡される．このパラメータが null の場合，単位行列が用いられる．</param>
        /// <param name="P">新しいカメラ行列（3x3），あるいは，新しい投影行列（3x4）． cvStereoRectify  で計算された値， P1 あるいは P2  が渡される． このパラメータが null の場合，単位行列が用いられる． </param>
#else
        /// <summary>
        /// Computes the ideal point coordinates from the observed point coordinates
        /// </summary>
        /// <param name="src">The observed point coordinates. </param>
        /// <param name="dst">The ideal point coordinates, after undistortion and reverse perspective transformation. </param>
        /// <param name="cameraMatrix">The camera matrix A=[fx 0 cx; 0 fy cy; 0 0 1]. </param>
        /// <param name="distCoeffs">The vector of distortion coefficients, 4x1, 1x4, 5x1 or 1x5. </param>
        /// <param name="R">The rectification transformation in object space (3x3 matrix). R1 or R2, computed by cvStereoRectify can be passed here. If the parameter is null, the identity matrix is used. </param>
        /// <param name="P">The new camera matrix (3x3) or the new projection matrix (3x4). P1 or P2, computed by cvStereoRectify can be passed here. If the parameter is null, the identity matrix is used. </param>
#endif
        public static void UndistortPoints(CvMat src, CvMat dst, CvMat cameraMatrix, CvMat distCoeffs, CvMat R, CvMat P)
        {
            if (src == null)
                throw new ArgumentNullException("src");
            if (dst == null)
                throw new ArgumentNullException("dst");
            if (cameraMatrix == null)
                throw new ArgumentNullException("cameraMatrix");
            if (distCoeffs == null)
                throw new ArgumentNullException("distCoeffs");

            IntPtr Rptr = (R == null) ? IntPtr.Zero : R.CvPtr;
            IntPtr Pptr = (P == null) ? IntPtr.Zero : P.CvPtr;

            CvInvoke.cvUndistortPoints(src.CvPtr, dst.CvPtr, cameraMatrix.CvPtr, distCoeffs.CvPtr, Rptr, Pptr);
        }
        #endregion
        #region UnregisterType
#if LANG_JP
        /// <summary>
        /// 型の登録を取り消す
        /// </summary>
        /// <param name="typeName">登録を取り消す型の名前</param>
#else
        /// <summary>
        /// Unregisters the type
        /// </summary>
        /// <param name="typeName">Name of the unregistered type. </param>
#endif
        public static void UnregisterType(string typeName)
        {
            if (string.IsNullOrEmpty(typeName))
            {
                throw new ArgumentNullException("typeName");
            }
            CvInvoke.cvUnregisterType(typeName);
        }
        #endregion
        #region UpdateMotionHistory
#if LANG_JP
        /// <summary>
        /// 動くシルエットを用いてモーション履歴画像を更新する
        /// </summary>
        /// <param name="silhouette">モーションが発生した場所が 0 以外のピクセル値をもつシルエットマスク．</param>
        /// <param name="mhi">関数によって更新される，モーション履歴画像（シングルチャンネル，32 ビット浮動小数点型）．</param>
        /// <param name="timestamp">ミリ秒単位，あるはその他の単位で表される現在時間．</param>
        /// <param name="duration">timestamp と同じ時間単位で表される，モーション軌跡の最大保持時間． </param>
#else
        /// <summary>
        /// Updates motion history image by moving silhouette
        /// </summary>
        /// <param name="silhouette">Silhouette mask that has non-zero pixels where the motion occurs. </param>
        /// <param name="mhi">Motion history image, that is updated by the function (single-channel, 32-bit floating-point)  </param>
        /// <param name="timestamp">Current time in milliseconds or other units.  </param>
        /// <param name="duration">Maximal duration of motion track in the same units as timestamp.  </param>
#endif
        public static void UpdateMotionHistory(CvArr silhouette, CvArr mhi, double timestamp, double duration)
        {
            if (silhouette == null)
                throw new ArgumentNullException("silhouette");
            if (mhi == null)
                throw new ArgumentNullException("mhi");
            CvInvoke.cvUpdateMotionHistory(silhouette.CvPtr, mhi.CvPtr, timestamp, duration);
        }
        #endregion
        #region UseOptimized
#if LANG_JP
        /// <summary>
        /// 最適化モード／非最適化モードを切り替える
        /// </summary>
        /// <param name="onOff">trueのとき最適化，falseのとき非最適化．</param>
        /// <returns>ロードされた最適化関数の数</returns>
#else
        /// <summary>
        /// Switches between optimized/non-optimized modes
        /// </summary>
        /// <param name="onOff">Use optimized (true) or not (false). </param>
        /// <returns>the number of optimized functions loaded</returns>
#endif
        public static int UseOptimized(bool onOff)
        {
            return CvInvoke.cvUseOptimized(onOff);
        }
        #endregion
    }
}