
namespace OpenCvSharp
{
#if LANG_JP
    /// <summary>
    /// テンプレートマッチングの方法
    /// </summary>
#else
    /// <summary>
    /// Specifies the way the template must be compared with image regions
    /// </summary>
#endif
    public enum TemplateMatchModes : int
    {
        /// <summary>
        /// \f[R(x,y)= \sum _{x',y'} (T(x',y')-I(x+x',y+y'))^2\f]
        /// </summary>
        SqDiff = 0,

        /// <summary>
        /// \f[R(x,y)= \frac{\sum_{x',y'} (T(x',y')-I(x+x',y+y'))^2}{\sqrt{\sum_{x',y'}T(x',y')^2 \cdot \sum_{x',y'} I(x+x',y+y')^2}}\f]
        /// </summary>
        SqDiffNormed = 1,

        /// <summary>
        /// \f[R(x,y)= \sum _{x',y'} (T(x',y')  \cdot I(x+x',y+y'))\f]
        /// </summary>
        CCorr = 2,

        /// <summary>
        /// \f[R(x,y)= \frac{\sum_{x',y'} (T(x',y') \cdot I(x+x',y+y'))}{\sqrt{\sum_{x',y'}T(x',y')^2 \cdot \sum_{x',y'} I(x+x',y+y')^2}}\f]
        /// </summary>
        CCorrNormed = 3,

        /// <summary>
        /// \f[R(x,y)= \sum _{x',y'} (T'(x',y')  \cdot I'(x+x',y+y'))\f]
        /// where
        /// \f[\begin{array}{l} T'(x',y')=T(x',y') - 1/(w  \cdot h)  \cdot \sum _{x'',y''} T(x'',y'') \\ I'(x+x',y+y')=I(x+x',y+y') - 1/(w  \cdot h)  \cdot \sum _{x'',y''} I(x+x'',y+y'') \end{array}\f]
        /// </summary>
        CCoeff = 4,

        /// <summary>
        /// \f[R(x,y)= \frac{ \sum_{x',y'} (T'(x',y') \cdot I'(x+x',y+y')) }{ \sqrt{\sum_{x',y'}T'(x',y')^2 \cdot \sum_{x',y'} I'(x+x',y+y')^2} }\f]
        /// </summary>
        CCoeffNormed = 5,
    }
}
