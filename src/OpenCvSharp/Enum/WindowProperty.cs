
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
#if LANG_JP
        /// <summary>
        /// 通常モード
        /// [CV_WND_PROP_AUTOSIZE]
        /// </summary>
#else
        /// <summary>
        /// Normal mode
        /// [CV_WND_PROP_AUTOSIZE]
        /// </summary>
#endif
        AutoSize = CvConst.CV_WND_PROP_AUTOSIZE,

#if LANG_JP
        /// <summary>
        /// フルスクリーン
        /// [CV_WND_PROP_FULLSCREEN]
        /// </summary>
#else
        /// <summary>
        /// Fullscreen
        /// [CV_WND_PROP_FULLSCREEN]
        /// </summary>
#endif
        Fullscreen = CvConst.CV_WND_PROP_FULLSCREEN,

#if LANG_JP
        /// <summary>
        /// 
        /// [CV_WND_PROP_ASPECTRATIO]
        /// </summary>
#else
        /// <summary>
        /// 
        /// [CV_WND_PROP_ASPECTRATIO]
        /// </summary>
#endif
        AspectRatio = CvConst.CV_WND_PROP_ASPECTRATIO,

        /// <summary>
        /// opengl support
        /// [CV_WND_PROP_OPENGL]
        /// </summary>
        OpenGL = CvConst.CV_WND_PROP_OPENGL,
    }


    /// <summary>
    /// New value of the window property.
    /// </summary>
    public enum WindowPropertyValue : int
    {
        /// <summary>
        /// Change the window to normal size or make the window resizable.
        /// [CV_WINDOW_NORMAL]
        /// </summary>
        Normal = CvConst.CV_WINDOW_NORMAL,

        /// <summary>
        /// Constrain the size by the displayed image. The window is not resizable.
        /// [CV_WINDOW_AUTOSIZE]
        /// </summary>
        AutoSize = CvConst.CV_WINDOW_AUTOSIZE,

        /// <summary>
        /// Change the window to fullscreen.
        /// [CV_WINDOW_FULLSCREEN]
        /// </summary>
        FullScreen = CvConst.CV_WINDOW_FULLSCREEN,

        /// <summary>
        /// Make the window resizable without any ratio constraints.
        /// [CV_WINDOW_FREERATIO]
        /// </summary>
        FreeRatio = CvConst.CV_WINDOW_FREERATIO,

        /// <summary>
        ///  Make the window resizable, but preserve the proportions of the displayed image.
        /// [CV_WINDOW_KEEPRATIO]
        /// </summary>
        KeepRatio = CvConst.CV_WINDOW_KEEPRATIO,
    }
}
