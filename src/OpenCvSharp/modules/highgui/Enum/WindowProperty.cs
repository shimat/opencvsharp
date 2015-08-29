
namespace OpenCvSharp
{
#if LANG_JP
	/// <summary>
	/// ウィンドウのプロパティを取得・設定する際のプロパティID(cvGetWindowProperty/cvSetWindowProperty)
	/// </summary>
#else
    /// <summary>
    /// Property identifiers for cvGetWindowProperty/cvSetWindowProperty
    /// </summary>
#endif
    public enum WindowProperty : int
    {
        /// <summary>
        /// fullscreen property (can be WINDOW_NORMAL or WINDOW_FULLSCREEN)
        /// </summary>
        Fullscreen = 0,

        /// <summary>
        /// autosize property (can be WINDOW_NORMAL or WINDOW_AUTOSIZE)
        /// </summary>
        AutoSize = 1,
        
        /// <summary>
        /// window's aspect ration (can be set to WINDOW_FREERATIO or WINDOW_KEEPRATIO)
        /// </summary>
        AspectRatio = 2,

        /// <summary>
        /// opengl support
        /// </summary>
        OpenGL = 3,
    }
}
