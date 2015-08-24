using System;

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
    public enum CalibrationFlags : int
    {
        /// <summary>
        /// 
        /// </summary>
        None = 0,

#if LANG_JP
		/// <summary>
		/// intrinsic_matrixは最適化が行われた正しい初 期値 fx, fy, cx, cyを含む．このパラメータがセッ トされていない場合，(cx, cy) は最初に画像中心にセットされ（image_size はこの計算に用いられ る），焦点距離は最小二乗法で計算される．
		/// </summary>
#else
        /// <summary>
        /// The flag allows the function to optimize some or all of the intrinsic parameters, depending on the other flags, but the initial values are provided by the user
        /// </summary>
#endif
        UseIntrinsicGuess = 0x00001,

#if LANG_JP
		/// <summary>
		/// fx  と fy のうちのどちらか一方だけが独立変数であるとし，アスペクト比 fx/fy が intrinsic_matrix の初期値として与えられた値か ら変わらないように最適化処理を行う．
        /// この場合，実際に用いられる(fx, fy)の初期値は，行列から与えられる （CV_CALIB_USE_INTRINSIC_GUESSがセットされている場合）か，何らかの方法で推定される（後者の場合は， fx, fy は任意の値にセットされ，それらの比率だけが用いられる）．
		/// </summary>
#else
        /// <summary>
        /// fyk is optimized, but the ratio fxk/fyk is fixed.
        /// </summary>
#endif
        FixAspectRatio = 0x00002,

#if LANG_JP
		/// <summary>
		/// 主点（光学中心） は最適化中には変化せず，中心または別の指定された場所（このパラメータと同時 に UseIntrinsicGuess がセットされ ている場合）に固定される 
		/// </summary>
#else
        /// <summary>
        /// The principal points are fixed during the optimization.
        /// </summary>
#endif
        FixPrincipalPoint = 0x00004,

#if LANG_JP
		/// <summary>
		/// 円周方向の歪み係数は0にセットされ，最適化中は変化しない 
		/// </summary>
#else
        /// <summary>
        /// Tangential distortion coefficients are set to zeros and do not change during the optimization.
        /// </summary>
#endif
        ZeroTangentDist = 0x00008,

#if LANG_JP
		/// <summary>
        /// fxk および fyk が固定される．
		/// </summary>
#else
        /// <summary>
        /// fxk and fyk are fixed.
        /// </summary>
#endif
        FixFocalLength = 0x00010,
       
#if LANG_JP
		/// <summary>
		/// 0 番目の歪み係数（k1）が固定される．
		/// </summary>
#else
        /// <summary>
        /// The 0-th distortion coefficients (k1) are fixed 
        /// </summary>
#endif
        FixK1 = 0x00020,


#if LANG_JP
		/// <summary>
		/// 1 番目の歪み係数（k2）が固定される．
		/// </summary>
#else
        /// <summary>
        /// The 1-th distortion coefficients (k2) are fixed 
        /// </summary>
#endif
        FixK2 = 0x00040,


#if LANG_JP
		/// <summary>
		/// 4 番目の歪み係数（k3）が固定される．
		/// </summary>
#else
        /// <summary>
        /// The 4-th distortion coefficients (k3) are fixed 
        /// </summary>
#endif
        FixK3 = 0x00080,


#if LANG_JP
		/// <summary>
		/// 最適化中に，指定した半径方向の歪み係数を変更しません．
        /// CV_CALIB_USE_INTRINSIC_GUESS が指定されている場合は，与えられた distCoeffs 行列の係数が利用されます．そうでない場合は，0が利用されます．
		/// </summary>
#else
        /// <summary>
        /// Do not change the corresponding radial distortion coefficient during the optimization. 
        /// If CV_CALIB_USE_INTRINSIC_GUESS is set, the coefficient from the supplied distCoeffs matrix is used, otherwise it is set to 0.
        /// </summary>
#endif
        FixK4 = 0x00800,


#if LANG_JP
		/// <summary>
		/// 最適化中に，指定した半径方向の歪み係数を変更しません．
        /// CV_CALIB_USE_INTRINSIC_GUESS が指定されている場合は，与えられた distCoeffs 行列の係数が利用されます．そうでない場合は，0が利用されます．
		/// </summary>
#else
        /// <summary>
        /// Do not change the corresponding radial distortion coefficient during the optimization. 
        /// If CV_CALIB_USE_INTRINSIC_GUESS is set, the coefficient from the supplied distCoeffs matrix is used, otherwise it is set to 0.
        /// </summary>
#endif
        FixK5 = 0x01000,


#if LANG_JP
		/// <summary>
		/// 最適化中に，指定した半径方向の歪み係数を変更しません．
        /// CV_CALIB_USE_INTRINSIC_GUESS が指定されている場合は，与えられた distCoeffs 行列の係数が利用されます．そうでない場合は，0が利用されます．
		/// </summary>
#else
        /// <summary>
        /// Do not change the corresponding radial distortion coefficient during the optimization. 
        /// If CV_CALIB_USE_INTRINSIC_GUESS is set, the coefficient from the supplied distCoeffs matrix is used, otherwise it is set to 0.
        /// </summary>
#endif
        FixK6 = 0x02000,
        
#if LANG_JP
		/// <summary>
		/// 係数 k4, k5, k6 を有効にします．
        /// 後方互換性を保つためには，このフラグを明示的に指定して，キャリブレーション関数が rational モデルを利用して8個の係数を返すようにします．
        /// このフラグが指定されない場合，関数は5つの歪み係数のみを計算し ます．
		/// </summary>
#else
        /// <summary>
        /// Enable coefficients k4, k5 and k6. 
        /// To provide the backward compatibility, this extra flag should be explicitly specified to make the calibration function 
        /// use the rational model and return 8 coefficients. If the flag is not set, the function will compute only 5 distortion coefficients.
        /// </summary>
#endif
        RationalModel = 0x04000,

        /// <summary>
        /// 
        /// </summary>
        ThinPrismModel = 0x08000,

        /// <summary>
        /// 
        /// </summary>
        FixS1S2S3S4 = 0x08000,

#if LANG_JP
		/// <summary>
		/// これがセットされた場合，外部パラメータのみが最適化されるように， camera_matrix1,2 と dist_coeffs1,2 が固定される．
		/// </summary>
#else
        /// <summary>
        /// If it is set, camera_matrix1,2, as well as dist_coeffs1,2 are fixed, so that only extrinsic parameters are optimized.
        /// </summary>
#endif
        FixIntrinsic = 0x00100,

#if LANG_JP
		/// <summary>
        /// 強制的に，fx0=fx1， fy0=fy1 とする．
		/// </summary>
#else
        /// <summary>
        /// Enforces fx0=fx1 and fy0=fy1. CV_CALIB_ZERO_TANGENT_DIST - Tangential distortion coefficients for each camera are set to zeros and fixed there.
        /// </summary>
#endif
        SameFocalLength = 0x00200,

        /// <summary>
        /// for stereo rectification
        /// </summary>
        ZeroDisparity = 0x00400,
    }
}

		

