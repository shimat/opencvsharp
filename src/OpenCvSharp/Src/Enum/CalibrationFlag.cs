/*
 * (C) 2008-2013 Schima
 * This code is licenced under the LGPL.
 */

using System;
using System.Collections.Generic;
using System.Text;

namespace OpenCvSharp
{
#if LANG_JP
    /// <summary>
	/// cvCalibrateCamera2やcvStereoCalibrateの処理フラグ
	/// </summary>
#else
    /// <summary>
    /// Different flags for cvCalibrateCamera2 and cvStereoCalibrate
    /// </summary>
#endif
    [Flags]
    public enum CalibrationFlag : int
    {
#if LANG_JP
		/// <summary>
		/// オプション無し (=0)
		/// </summary>
#else
        /// <summary>
        /// = 0
        /// </summary>
#endif
        Default = 0,


#if LANG_JP
		/// <summary>
		/// これがセットされた場合，外部パラメータのみが最適化されるように， camera_matrix1,2 と dist_coeffs1,2 が固定される．
        /// [CV_CALIB_FIX_INTRINSIC]
		/// </summary>
#else
        /// <summary>
        /// If it is set, camera_matrix1,2, as well as dist_coeffs1,2 are fixed, so that only extrinsic parameters are optimized.
        /// [CV_CALIB_FIX_INTRINSIC]
        /// </summary>
#endif
        FixIntrinsic = CvConst.CV_CALIB_FIX_INTRINSIC,


#if LANG_JP
		/// <summary>
		/// intrinsic_matrixは最適化が行われた正しい初 期値 fx, fy, cx, cyを含む．このパラメータがセッ トされていない場合，(cx, cy) は最初に画像中心にセットされ（image_size はこの計算に用いられ る），焦点距離は最小二乗法で計算される．
        /// [CV_CALIB_USE_INTRINSIC_GUESS]
		/// </summary>
#else
        /// <summary>
        /// The flag allows the function to optimize some or all of the intrinsic parameters, depending on the other flags, but the initial values are provided by the user
        /// [CV_CALIB_USE_INTRINSIC_GUESS]
        /// </summary>
#endif
        UseIntrinsicGuess = CvConst.CV_CALIB_USE_INTRINSIC_GUESS,


#if LANG_JP
		/// <summary>
		/// 主点（光学中心） は最適化中には変化せず，中心または別の指定された場所（このパラメータと同時 に UseIntrinsicGuess がセットされ ている場合）に固定される 
        /// [CV_CALIB_FIX_PRINCIPAL_POINT]
		/// </summary>
#else
        /// <summary>
        /// The principal points are fixed during the optimization.
        /// [CV_CALIB_FIX_PRINCIPAL_POINT]
        /// </summary>
#endif
        FixPrincipalPoint = CvConst.CV_CALIB_FIX_PRINCIPAL_POINT,


#if LANG_JP
		/// <summary>
        /// fxk および fyk が固定される．
		/// [CV_CALIB_FIX_FOCAL_LENGTH]
		/// </summary>
#else
        /// <summary>
        /// fxk and fyk are fixed.
        /// [CV_CALIB_FIX_FOCAL_LENGTH]
        /// </summary>
#endif
        FixFocalLength = CvConst.CV_CALIB_FIX_FOCAL_LENGTH,


#if LANG_JP
		/// <summary>
		/// fx  と fy のうちのどちらか一方だけが独立変数であるとし，アスペクト比 fx/fy が intrinsic_matrix の初期値として与えられた値か ら変わらないように最適化処理を行う．
        /// この場合，実際に用いられる(fx, fy)の初期値は，行列から与えられる （CV_CALIB_USE_INTRINSIC_GUESSがセットされている場合）か，何らかの方法で推定される（後者の場合は， fx, fy は任意の値にセットされ，それらの比率だけが用いられる）．
        /// [CV_CALIB_FIX_ASPECT_RATIO]
		/// </summary>
#else
        /// <summary>
        /// fyk is optimized, but the ratio fxk/fyk is fixed.
        /// [CV_CALIB_FIX_ASPECT_RATIO]
        /// </summary>
#endif
        FixAspectRatio = CvConst.CV_CALIB_FIX_ASPECT_RATIO,


#if LANG_JP
		/// <summary>
        /// 強制的に，fx0=fx1， fy0=fy1 とする．
		/// [CV_CALIB_SAME_FOCAL_LENGTH]
		/// </summary>
#else
        /// <summary>
        /// Enforces fx0=fx1 and fy0=fy1. CV_CALIB_ZERO_TANGENT_DIST - Tangential distortion coefficients for each camera are set to zeros and fixed there.
        /// [CV_CALIB_SAME_FOCAL_LENGTH]
        /// </summary>
#endif
        SameFocalLength = CvConst.CV_CALIB_SAME_FOCAL_LENGTH,

#if LANG_JP
		/// <summary>
		/// 円周方向の歪み係数は0にセットされ，最適化中は変化しない 
        /// [CV_CALIB_ZERO_TANGENT_DIST]
		/// </summary>
#else
        /// <summary>
        /// Tangential distortion coefficients are set to zeros and do not change during the optimization.
        /// [CV_CALIB_ZERO_TANGENT_DIST]
        /// </summary>
#endif
        ZeroTangentDist = CvConst.CV_CALIB_ZERO_TANGENT_DIST,


#if LANG_JP
		/// <summary>
		/// 0 番目の歪み係数（k1）が固定される．
        /// [CV_CALIB_FIX_K1]
		/// </summary>
#else
        /// <summary>
        /// The 0-th distortion coefficients (k1) are fixed 
        /// [CV_CALIB_FIX_K1]
        /// </summary>
#endif
        FixK1 = CvConst.CV_CALIB_FIX_K1,


#if LANG_JP
		/// <summary>
		/// 1 番目の歪み係数（k2）が固定される．
        /// [CV_CALIB_FIX_K2]
		/// </summary>
#else
        /// <summary>
        /// The 1-th distortion coefficients (k2) are fixed 
        /// [CV_CALIB_FIX_K2]
        /// </summary>
#endif
		FixK2 = CvConst.CV_CALIB_FIX_K2,


#if LANG_JP
		/// <summary>
		/// 4 番目の歪み係数（k3）が固定される．
        /// [CV_CALIB_FIX_K3]
		/// </summary>
#else
        /// <summary>
        /// The 4-th distortion coefficients (k3) are fixed 
        /// [CV_CALIB_FIX_K3]
        /// </summary>
#endif
		FixK3 = CvConst.CV_CALIB_FIX_K3,


#if LANG_JP
		/// <summary>
		/// 最適化中に，指定した半径方向の歪み係数を変更しません．
        /// CV_CALIB_USE_INTRINSIC_GUESS が指定されている場合は，与えられた distCoeffs 行列の係数が利用されます．そうでない場合は，0が利用されます．
        /// [CV_CALIB_FIX_K4]
		/// </summary>
#else
        /// <summary>
        /// Do not change the corresponding radial distortion coefficient during the optimization. 
        /// If CV_CALIB_USE_INTRINSIC_GUESS is set, the coefficient from the supplied distCoeffs matrix is used, otherwise it is set to 0.
        /// [CV_CALIB_FIX_K4]
        /// </summary>
#endif
        FixK4 = CvConst.CV_CALIB_FIX_K4,


#if LANG_JP
		/// <summary>
		/// 最適化中に，指定した半径方向の歪み係数を変更しません．
        /// CV_CALIB_USE_INTRINSIC_GUESS が指定されている場合は，与えられた distCoeffs 行列の係数が利用されます．そうでない場合は，0が利用されます．
        /// [CV_CALIB_FIX_K5]
		/// </summary>
#else
        /// <summary>
        /// Do not change the corresponding radial distortion coefficient during the optimization. 
        /// If CV_CALIB_USE_INTRINSIC_GUESS is set, the coefficient from the supplied distCoeffs matrix is used, otherwise it is set to 0.
        /// [CV_CALIB_FIX_K5]
        /// </summary>
#endif
        FixK5 = CvConst.CV_CALIB_FIX_K5,


#if LANG_JP
		/// <summary>
		/// 最適化中に，指定した半径方向の歪み係数を変更しません．
        /// CV_CALIB_USE_INTRINSIC_GUESS が指定されている場合は，与えられた distCoeffs 行列の係数が利用されます．そうでない場合は，0が利用されます．
        /// [CV_CALIB_FIX_K6]
		/// </summary>
#else
        /// <summary>
        /// Do not change the corresponding radial distortion coefficient during the optimization. 
        /// If CV_CALIB_USE_INTRINSIC_GUESS is set, the coefficient from the supplied distCoeffs matrix is used, otherwise it is set to 0.
        /// [CV_CALIB_FIX_K6]
        /// </summary>
#endif
        FixK6 = CvConst.CV_CALIB_FIX_K6,


#if LANG_JP
		/// <summary>
		/// 係数 k4, k5, k6 を有効にします．
        /// 後方互換性を保つためには，このフラグを明示的に指定して，キャリブレーション関数が rational モデルを利用して8個の係数を返すようにします．
        /// このフラグが指定されない場合，関数は5つの歪み係数のみを計算し ます．
        /// [CV_CALIB_RATIONAL_MODEL]
		/// </summary>
#else
        /// <summary>
        /// Enable coefficients k4, k5 and k6. 
        /// To provide the backward compatibility, this extra flag should be explicitly specified to make the calibration function 
        /// use the rational model and return 8 coefficients. If the flag is not set, the function will compute only 5 distortion coefficients.
        /// [CV_CALIB_RATIONAL_MODEL]
        /// </summary>
#endif
        RationalModel = CvConst.CV_CALIB_RATIONAL_MODEL,
    }
}

		

