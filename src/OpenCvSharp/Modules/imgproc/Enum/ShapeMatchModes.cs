
namespace OpenCvSharp
{
#if LANG_JP
    /// <summary>
    /// cv::matchShapesで用いる比較手法
    /// </summary>
#else
    /// <summary>
    /// Comparison methods for cv::matchShapes
    /// </summary>
#endif
    public enum ShapeMatchModes : int
    {
        /// <summary>
        /// \f[I_1(A,B) =  \sum _{i=1...7}  \left |  \frac{1}{m^A_i} -  \frac{1}{m^B_i} \right |\f]
        /// </summary>
        I1 = 1,

        /// <summary>
        /// \f[I_2(A,B) =  \sum _{i=1...7}  \left | m^A_i - m^B_i  \right |\f]
        /// </summary>
        I2 = 2,

        /// <summary>
        /// \f[I_3(A,B) =  \max _{i=1...7}  \frac{ \left| m^A_i - m^B_i \right| }{ \left| m^A_i \right| }\f]
        /// </summary>
        I3 = 3,
    }
}
