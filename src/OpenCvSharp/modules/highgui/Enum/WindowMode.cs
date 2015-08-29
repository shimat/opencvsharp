using System;

namespace OpenCvSharp
{
#if LANG_JP
    /// <summary>
	/// cvNamedWindowで使用するウィンドウのフラグ
	/// </summary>
#else
    /// <summary>
    /// Flags for the window
    /// </summary>
#endif
    [Flags]
    public enum WindowMode : int
    {
        /// <summary>
        /// the user can resize the window (no constraint) / 
        /// also use to switch a fullscreen window to a normal size
        /// </summary>
        Normal = 0x00000000,

#if LANG_JP
		/// <summary>
		/// 表示される画像サイズに合わせてウィンドウサイズが自動的に調整される 
		/// </summary>
#else
        /// <summary>
        /// the user cannot resize the window, the size is constrainted by the image displayed
        /// </summary>
#endif
        AutoSize = 0x00000001,

        /// <summary>
        /// window with opengl support
        /// </summary>
        OpenGL = 0x00001000,

        /// <summary>
        /// change the window to fullscreen
        /// </summary>
        FullScreen = 1,

        /// <summary>
        /// the image expends as much as it can (no ratio constraint)
        /// </summary>
        FreeRatio = 0x00000100,

        /// <summary>
        /// the ratio of the image is respected
        /// </summary>
        KeepRatio = 0x00000000
    }
}
