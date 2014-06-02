
namespace OpenCvSharp.CPlusPlus
{
#if LANG_JP
    /// <summary>
	/// SVMパラメータの種類
	/// </summary>
#else
	/// <summary>
	/// SVM params type
	/// </summary>
#endif
	public enum SVMParamType : int
	{
		/// <summary>
		/// [CvSVM::C]
		/// </summary>
		C = 0,
		/// <summary>
		/// [CvSVM::GAMMA]
		/// </summary>
		Gamma = 1,
		/// <summary>
		/// [CvSVM::P]
		/// </summary>
		P = 2,
		/// <summary>
		/// [CvSVM::NU]
		/// </summary>
		Nu = 3,
		/// <summary>
		/// [CvSVM::COEF]
		/// </summary>
		Coef = 4,
		/// <summary>
		/// [CvSVM::DEGREE]
		/// </summary>
		Degree = 5,
	}
}