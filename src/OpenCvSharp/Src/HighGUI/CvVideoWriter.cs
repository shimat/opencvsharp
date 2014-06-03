using System;

namespace OpenCvSharp
{
#if LANG_JP
    /// <summary>
    /// AVIビデオを出力するためのライタ
    /// </summary>
#else
    /// <summary>
    /// AVI Video File Writer
    /// </summary>
#endif
    public class CvVideoWriter : DisposableCvObject
    {
        /// <summary>
        /// Track whether Dispose has been called
        /// </summary>
        private bool disposed = false;

        #region Init and Disposal
#if LANG_JP
        /// <summary>
        /// ビデオライタを作成し、返す.
        /// </summary>
        /// <param name="filename">出力するビデオファイルの名前</param>
        /// <param name="fourcc">
        /// フレームを圧縮するためのコーデックを表す 4 文字．例えば，"PIM1" は，MPEG-1 コーデック， "MJPG" は，motion-jpeg コーデックである． 
        /// Win32 環境下では，null を渡すとダイアログから圧縮方法と圧縮のパラメータを選択できるようになる. 
        /// </param>
        /// <param name="fps">作成されたビデオストリームのフレームレート</param>
        /// <param name="frameSize">ビデオフレームのサイズ</param>
#else
        /// <summary>
        /// Creates video writer structure. 
        /// </summary>
        /// <param name="filename">Name of the output video file. </param>
        /// <param name="fourcc">4-character code of codec used to compress the frames. For example, "PIM1" is MPEG-1 codec, "MJPG" is motion-jpeg codec etc. 
        /// Under Win32 it is possible to pass null in order to choose compression method and additional compression parameters from dialog. </param>
        /// <param name="fps">Framerate of the created video stream. </param>
        /// <param name="frameSize">Size of video frames. </param>
#endif
	    public CvVideoWriter(string filename, string fourcc, double fps, CvSize frameSize )
            : this(filename, Cv.FOURCC(fourcc), fps, frameSize, true)
	    {
	    }
#if LANG_JP
        /// <summary>
        /// ビデオライタを作成し、返す.
        /// </summary>
        /// <param name="filename">出力するビデオファイルの名前</param>
        /// <param name="fourcc">
        /// フレームを圧縮するためのコーデックを表す 4 文字．例えば，"PIM1" は，MPEG-1 コーデック， "MJPG" は，motion-jpeg コーデックである． 
        /// Win32 環境下では，null を渡すとダイアログから圧縮方法と圧縮のパラメータを選択できるようになる. 
        /// </param>
        /// <param name="fps">作成されたビデオストリームのフレームレート</param>
        /// <param name="frameSize">ビデオフレームのサイズ</param>
        /// <param name="isColor">trueの場合，エンコーダはカラーフレームとしてエンコードする． falseの場合，グレースケールフレームとして動作する（現在のところ，このフラグは Windows でのみ利用できる）．</param>
        /// <returns>CvVideoWriter</returns>
#else
        /// <summary>
        /// Creates video writer structure. 
        /// </summary>
        /// <param name="filename">Name of the output video file. </param>
        /// <param name="fourcc">4-character code of codec used to compress the frames. For example, "PIM1" is MPEG-1 codec, "MJPG" is motion-jpeg codec etc. 
        /// Under Win32 it is possible to pass null in order to choose compression method and additional compression parameters from dialog. </param>
        /// <param name="fps">Framerate of the created video stream. </param>
        /// <param name="frameSize">Size of video frames. </param>
        /// <param name="isColor">If it is true, the encoder will expect and encode color frames, otherwise it will work with grayscale frames (the flag is currently supported on Windows only). </param>
#endif
	    public CvVideoWriter( string filename, string fourcc, double fps, CvSize frameSize, bool isColor)
            : this(filename, Cv.FOURCC(fourcc), fps, frameSize, isColor)
	    {
	    }
#if LANG_JP
        /// <summary>
        /// ビデオライタを作成し、返す.
        /// </summary>
        /// <param name="filename">出力するビデオファイルの名前</param>
        /// <param name="fourcc">
        /// フレームを圧縮するためのコーデックを表す 4 文字．例えば，"PIM1" は，MPEG-1 コーデック， "MJPG" は，motion-jpeg コーデックである． 
        /// Win32 環境下では，null を渡すとダイアログから圧縮方法と圧縮のパラメータを選択できるようになる. 
        /// </param>
        /// <param name="fps">作成されたビデオストリームのフレームレート</param>
        /// <param name="frameSize">ビデオフレームのサイズ</param>
        /// <returns>CvVideoWriter</returns>
#else
        /// <summary>
        /// Creates video writer structure. 
        /// </summary>
        /// <param name="filename">Name of the output video file. </param>
        /// <param name="fourcc">4-character code of codec used to compress the frames. For example, "PIM1" is MPEG-1 codec, "MJPG" is motion-jpeg codec etc. 
        /// Under Win32 it is possible to pass null in order to choose compression method and additional compression parameters from dialog. </param>
        /// <param name="fps">Framerate of the created video stream. </param>
        /// <param name="frameSize">Size of video frames. </param>
        /// <returns></returns>
#endif
        public CvVideoWriter(string filename, FourCC fourcc, double fps, CvSize frameSize)
            : this(filename, (int)fourcc, fps, frameSize, true)
        {
        }
#if LANG_JP
        /// <summary>
        /// ビデオライタを作成し、返す.
        /// </summary>
        /// <param name="filename">出力するビデオファイルの名前</param>
        /// <param name="fourcc">
        /// フレームを圧縮するためのコーデックを表す 4 文字．例えば，"PIM1" は，MPEG-1 コーデック， "MJPG" は，motion-jpeg コーデックである． 
        /// Win32 環境下では，null を渡すとダイアログから圧縮方法と圧縮のパラメータを選択できるようになる. 
        /// </param>
        /// <param name="fps">作成されたビデオストリームのフレームレート</param>
        /// <param name="frameSize">ビデオフレームのサイズ</param>
        /// <param name="isColor">trueの場合，エンコーダはカラーフレームとしてエンコードする． falseの場合，グレースケールフレームとして動作する（現在のところ，このフラグは Windows でのみ利用できる）．</param>
        /// <returns>CvVideoWriter</returns>
#else
        /// <summary>
        /// Creates video writer structure. 
        /// </summary>
        /// <param name="filename">Name of the output video file. </param>
        /// <param name="fourcc">4-character code of codec used to compress the frames. For example, "PIM1" is MPEG-1 codec, "MJPG" is motion-jpeg codec etc. 
        /// Under Win32 it is possible to pass null in order to choose compression method and additional compression parameters from dialog. </param>
        /// <param name="fps">Framerate of the created video stream. </param>
        /// <param name="frameSize">Size of video frames. </param>
        /// <param name="isColor">If it is true, the encoder will expect and encode color frames, otherwise it will work with grayscale frames (the flag is currently supported on Windows only). </param>
        /// <returns></returns>
#endif
        public CvVideoWriter(string filename, FourCC fourcc, double fps, CvSize frameSize, bool isColor)
            : this(filename, (int)fourcc, fps, frameSize, isColor)
        {
        }
#if LANG_JP
        /// <summary>
        /// ビデオライタを作成し、返す.
        /// </summary>
        /// <param name="filename">出力するビデオファイルの名前</param>
        /// <param name="fourcc">
        /// フレームを圧縮するためのコーデックを表す 4 文字．例えば，"PIM1" は，MPEG-1 コーデック， "MJPG" は，motion-jpeg コーデックである． 
        /// Win32 環境下では，null を渡すとダイアログから圧縮方法と圧縮のパラメータを選択できるようになる. 
        /// </param>
        /// <param name="fps">作成されたビデオストリームのフレームレート</param>
        /// <param name="frameSize">ビデオフレームのサイズ</param>
        /// <returns>CvVideoWriter</returns>
#else
        /// <summary>
        /// Creates video writer structure. 
        /// </summary>
        /// <param name="filename">Name of the output video file. </param>
        /// <param name="fourcc">4-character code of codec used to compress the frames. For example, "PIM1" is MPEG-1 codec, "MJPG" is motion-jpeg codec etc. 
        /// Under Win32 it is possible to pass null in order to choose compression method and additional compression parameters from dialog. </param>
        /// <param name="fps">Framerate of the created video stream. </param>
        /// <param name="frameSize">Size of video frames. </param>
        /// <returns></returns>
#endif
        public CvVideoWriter(string filename, int fourcc, double fps, CvSize frameSize)
            : this(filename, fourcc, fps, frameSize, true)
        {
        }
#if LANG_JP
        /// <summary>
        /// ビデオライタを作成し、返す.
        /// </summary>
        /// <param name="filename">出力するビデオファイルの名前</param>
        /// <param name="fourcc">
        /// フレームを圧縮するためのコーデックを表す 4 文字．例えば，"PIM1" は，MPEG-1 コーデック， "MJPG" は，motion-jpeg コーデックである． 
        /// Win32 環境下では，null を渡すとダイアログから圧縮方法と圧縮のパラメータを選択できるようになる. 
        /// </param>
        /// <param name="fps">作成されたビデオストリームのフレームレート</param>
        /// <param name="frameSize">ビデオフレームのサイズ</param>
        /// <param name="isColor">trueの場合，エンコーダはカラーフレームとしてエンコードする． falseの場合，グレースケールフレームとして動作する（現在のところ，このフラグは Windows でのみ利用できる）．</param>
        /// <returns>CvVideoWriter</returns>
#else
        /// <summary>
        /// Creates video writer structure. 
        /// </summary>
        /// <param name="filename">Name of the output video file. </param>
        /// <param name="fourcc">4-character code of codec used to compress the frames. For example, "PIM1" is MPEG-1 codec, "MJPG" is motion-jpeg codec etc. 
        /// Under Win32 it is possible to pass null in order to choose compression method and additional compression parameters from dialog. </param>
        /// <param name="fps">Framerate of the created video stream. </param>
        /// <param name="frameSize">Size of video frames. </param>
        /// <param name="isColor">If it is true, the encoder will expect and encode color frames, otherwise it will work with grayscale frames (the flag is currently supported on Windows only). </param>
        /// <returns></returns>
#endif
        public CvVideoWriter(string filename, int fourcc, double fps, CvSize frameSize, bool isColor)
        {
            if (filename == null)
            {
                throw new ArgumentNullException();
            }
            FileName = filename;
            Fps = fps;
            FrameSize = frameSize;
            IsColor = isColor;
            ptr = NativeMethods.cvCreateVideoWriter(filename, fourcc, fps, frameSize, isColor);
            if (ptr == IntPtr.Zero)
            {
                throw new OpenCvSharpException("Failed to create CvVideoWriter");
            }
        } 
        /// <summary>
        /// ポインタから初期化
        /// </summary>
        /// <param name="ptr">CvVideoWriter*</param>
        internal CvVideoWriter(IntPtr ptr)
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
                        NativeMethods.cvReleaseVideoWriter(ref ptr);
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

        #region Properties
#if LANG_JP
        /// <summary>
        /// 出力するビデオファイルの名前を取得する
        /// </summary>
#else
        /// <summary>
        /// Get output video file name
        /// </summary>
#endif
        public string FileName { get; private set; }
#if LANG_JP
        /// <summary>
        /// 作成されたビデオストリームのフレームレートを取得する
        /// </summary>
#else
        /// <summary>
        /// Frames per second of the output vide
        /// </summary>
#endif
        public double Fps { get; private set; }
#if LANG_JP
        /// <summary>
        /// ビデオフレームのサイズを取得する
        /// </summary>
#else
        /// <summary>
        /// Get size of frame image
        /// </summary>
#endif
        public CvSize FrameSize { get; private set; }
#if LANG_JP
        /// <summary>
        /// カラーフレームかどうかの値を取得する
        /// </summary>
#else
        /// <summary>
        /// Get whether output frames is color or not
        /// </summary>
#endif
        public bool IsColor { get; private set; }
        #endregion

        #region Methods
        #region WriteFrame
#if LANG_JP
        /// <summary>
        /// 一つのフレームをビデオファイルに書き込む/追加する
        /// </summary>
        /// <param name="image">書き込まれるフレーム</param>
        /// <returns></returns>
#else
        /// <summary>
        /// Writes/appends one frame to video file. 
        /// </summary>
        /// <param name="image">the written frame.</param>
        /// <returns></returns>
#endif
        public int WriteFrame(IplImage image)
        {
            return Cv.WriteFrame(this, image);
        }
        #endregion
        #endregion
    }
}
