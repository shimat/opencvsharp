using System;

namespace OpenCvSharp
{
#if LANG_JP
    /// <summary>
    /// AVIビデオ出力機
    /// </summary>
#else
    /// <summary>
    /// AVI Video File Writer
    /// </summary>
#endif
    public class VideoWriter : DisposableCvObject
    {
        #region Init and Disposal

        /// <summary>
        /// 
        /// </summary>
        public VideoWriter()
        {
            FileName = null;
            Fps = -1;
            FrameSize = Size.Zero;
            IsColor = true;
            NativeMethods.HandleException(
                NativeMethods.videoio_VideoWriter_new1(out ptr));
            if (ptr == IntPtr.Zero)
                throw new OpenCvSharpException("Failed to create VideoWriter");
        }

#if LANG_JP
        /// <summary>
        /// ビデオライタを作成し、返す.
        /// </summary>
        /// <param name="fileName">出力するビデオファイルの名前</param>
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
        /// <param name="fileName">Name of the output video file. </param>
        /// <param name="fourcc">4-character code of codec used to compress the frames. For example, "PIM1" is MPEG-1 codec, "MJPG" is motion-jpeg codec etc. 
        /// Under Win32 it is possible to pass null in order to choose compression method and additional compression parameters from dialog. </param>
        /// <param name="fps">Frame rate of the created video stream. </param>
        /// <param name="frameSize">Size of video frames. </param>
        /// <param name="isColor">If it is true, the encoder will expect and encode color frames, otherwise it will work with grayscale frames (the flag is currently supported on Windows only). </param>
        /// <returns></returns>
#endif
        public VideoWriter(string fileName, FourCC fourcc, double fps, Size frameSize, bool isColor = true)
        {
            FileName = fileName ?? throw new ArgumentNullException(nameof(fileName));
            Fps = fps;
            FrameSize = frameSize;
            IsColor = isColor;
            NativeMethods.HandleException(
                NativeMethods.videoio_VideoWriter_new2(fileName, (int)fourcc, fps, frameSize, isColor ? 1 : 0, out ptr));
            if (ptr == IntPtr.Zero)
                throw new OpenCvSharpException("Failed to create VideoWriter");
        }

#if LANG_JP
        /// <summary>
        /// ビデオライタを作成し、返す.
        /// </summary>
        /// <param name="fileName">出力するビデオファイルの名前</param>
        /// <param name="apiPreference">allows to specify API backends to use. Can be used to enforce a specific reader implementation
        /// if multiple are available: e.g. cv::CAP_FFMPEG or cv::CAP_GSTREAMER.</param>
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
        /// <param name="fileName">Name of the output video file. </param>
        /// <param name="apiPreference">allows to specify API backends to use. Can be used to enforce a specific reader implementation
        /// if multiple are available: e.g. cv::CAP_FFMPEG or cv::CAP_GSTREAMER.</param>
        /// <param name="fourcc">4-character code of codec used to compress the frames. For example, "PIM1" is MPEG-1 codec, "MJPG" is motion-jpeg codec etc. 
        /// Under Win32 it is possible to pass null in order to choose compression method and additional compression parameters from dialog. </param>
        /// <param name="fps">Frame rate of the created video stream. </param>
        /// <param name="frameSize">Size of video frames. </param>
        /// <param name="isColor">If it is true, the encoder will expect and encode color frames, otherwise it will work with grayscale frames (the flag is currently supported on Windows only). </param>
        /// <returns></returns>
#endif
        public VideoWriter(string fileName, VideoCaptureAPIs apiPreference, FourCC fourcc, double fps, Size frameSize, bool isColor = true)
        {
            FileName = fileName ?? throw new ArgumentNullException(nameof(fileName));
            Fps = fps;
            FrameSize = frameSize;
            IsColor = isColor;
            NativeMethods.HandleException(
                NativeMethods.videoio_VideoWriter_new3(fileName, (int)apiPreference, (int)fourcc, fps, frameSize, isColor ? 1 : 0, out ptr));
            if (ptr == IntPtr.Zero)
                throw new OpenCvSharpException("Failed to create VideoWriter");
        }

        /// <summary>
        /// Initializes from native pointer
        /// </summary>
        /// <param name="ptr">CvVideoWriter*</param>
        internal VideoWriter(IntPtr ptr)
        {
            this.ptr = ptr;
        }

        /// <summary>
        /// Releases unmanaged resources
        /// </summary>
        protected override void DisposeUnmanaged()
        {
            NativeMethods.HandleException(
                NativeMethods.videoio_VideoWriter_delete(ptr));
            base.DisposeUnmanaged();
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
        public string? FileName { get; private set; }

#if LANG_JP
        /// <summary>
        /// 作成されたビデオストリームのフレームレートを取得する
        /// </summary>
#else
        /// <summary>
        /// Frames per second of the output video
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
        public Size FrameSize { get; private set; }

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

#if LANG_JP
        /// <summary>
        /// ビデオライタを開く
        /// </summary>
        /// <param name="fileName">出力するビデオファイルの名前</param>
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
        /// <param name="fileName">Name of the output video file. </param>
        /// <param name="fourcc">4-character code of codec used to compress the frames. For example, "PIM1" is MPEG-1 codec, "MJPG" is motion-jpeg codec etc. 
        /// Under Win32 it is possible to pass null in order to choose compression method and additional compression parameters from dialog. </param>
        /// <param name="fps">Frame rate of the created video stream. </param>
        /// <param name="frameSize">Size of video frames. </param>
        /// <param name="isColor">If it is true, the encoder will expect and encode color frames, otherwise it will work with grayscale frames (the flag is currently supported on Windows only). </param>
        /// <returns></returns>
#endif
        public bool Open(string fileName, FourCC fourcc, double fps, Size frameSize, bool isColor = true)
        {
            ThrowIfDisposed();
            if (string.IsNullOrEmpty(fileName))
                throw new ArgumentNullException(nameof(fileName));

            FileName = fileName;
            Fps = fps;
            FrameSize = frameSize;
            IsColor = isColor;

            NativeMethods.HandleException(
                NativeMethods.videoio_VideoWriter_open1(ptr, fileName, fourcc, fps, frameSize, isColor ? 1 : 0, out var ret));

            GC.KeepAlive(this);
            return ret != 0;
        }

#if LANG_JP
        /// <summary>
        /// ビデオライタを開く
        /// </summary>
        /// <param name="fileName">出力するビデオファイルの名前</param>
        /// <param name="apiPreference">allows to specify API backends to use. Can be used to enforce a specific reader implementation
        /// if multiple are available: e.g. cv::CAP_FFMPEG or cv::CAP_GSTREAMER.</param>
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
        /// <param name="fileName">Name of the output video file. </param>
        /// <param name="apiPreference">allows to specify API backends to use. Can be used to enforce a specific reader implementation
        /// if multiple are available: e.g. cv::CAP_FFMPEG or cv::CAP_GSTREAMER.</param>
        /// <param name="fourcc">4-character code of codec used to compress the frames. For example, "PIM1" is MPEG-1 codec, "MJPG" is motion-jpeg codec etc. 
        /// Under Win32 it is possible to pass null in order to choose compression method and additional compression parameters from dialog. </param>
        /// <param name="fps">Frame rate of the created video stream. </param>
        /// <param name="frameSize">Size of video frames. </param>
        /// <param name="isColor">If it is true, the encoder will expect and encode color frames, otherwise it will work with grayscale frames (the flag is currently supported on Windows only). </param>
        /// <returns></returns>
#endif
        public bool Open(string fileName, VideoCaptureAPIs apiPreference, FourCC fourcc, double fps, Size frameSize, bool isColor = true)
        {
            ThrowIfDisposed();
            if (string.IsNullOrEmpty(fileName))
                throw new ArgumentNullException(nameof(fileName));

            FileName = fileName;
            Fps = fps;
            FrameSize = frameSize;
            IsColor = isColor;

            NativeMethods.HandleException(
                NativeMethods.videoio_VideoWriter_open2(ptr, fileName, (int)apiPreference, (int)fourcc, fps, frameSize, isColor ? 1 : 0, out var ret));

            GC.KeepAlive(this);
            return ret != 0;
        }

        /// <summary>
        /// Returns true if video writer has been successfully initialized.
        /// </summary>
        /// <returns></returns>
        public bool IsOpened()
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.videoio_VideoWriter_isOpened(ptr, out var ret));
            GC.KeepAlive(this);
            return ret != 0;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public void Release()
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.videoio_VideoWriter_release(ptr));
            GC.KeepAlive(this);
        }

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
        public void Write(InputArray image)
        {
            ThrowIfDisposed();
            if(image == null)
                throw new ArgumentNullException(nameof(image));
            image.ThrowIfDisposed();

            NativeMethods.HandleException(
                NativeMethods.videoio_VideoWriter_write(ptr, image.CvPtr));

            GC.KeepAlive(this);
            GC.KeepAlive(image);
        }

        /// <summary>
        ///  Sets a property in the VideoWriter.
        /// </summary>
        /// <param name="propId">Property identifier from cv::VideoWriterProperties (eg. cv::VIDEOWRITER_PROP_QUALITY) or one of @ref videoio_flags_others</param>
        /// <param name="value">Value of the property.</param>
        /// <returns>`true` if the property is supported by the backend used by the VideoWriter instance.</returns>
        public bool Set(VideoWriterProperties propId, double value)
        {
            ThrowIfDisposed();

            NativeMethods.HandleException(
                NativeMethods.videoio_VideoWriter_set(ptr, (int)propId, value, out var ret));

            GC.KeepAlive(this);
            return ret != 0;
        }

        /// <summary>
        /// Returns the specified VideoWriter property
        /// </summary>
        /// <param name="propId"> Property identifier from cv::VideoWriterProperties (eg. cv::VIDEOWRITER_PROP_QUALITY) or one of @ref videoio_flags_others</param>
        /// <returns>Value for the specified property. Value 0 is returned when querying a property that is not supported by the backend used by the VideoWriter instance.</returns>
        public double Get(VideoWriterProperties propId)
        {
            ThrowIfDisposed();

            NativeMethods.HandleException(
                NativeMethods.videoio_VideoWriter_get(ptr, (int)propId, out var ret));

            GC.KeepAlive(this);
            return ret;
        }

        /// <summary>
        /// Concatenates 4 chars to a fourcc code.
        /// This static method constructs the fourcc code of the codec to be used in 
        /// the constructor VideoWriter::VideoWriter or VideoWriter::open.
        /// </summary>
        // ReSharper disable once InconsistentNaming
        public static int FourCC(char c1, char c2, char c3, char c4)
        {
            NativeMethods.HandleException(
                NativeMethods.videoio_VideoWriter_fourcc((sbyte) c1, (sbyte) c2, (sbyte) c3, (sbyte) c4, out var ret));
            return ret;
        }

        /// <summary>
        /// Concatenates 4 chars to a fourcc code.
        /// This static method constructs the fourcc code of the codec to be used in 
        /// the constructor VideoWriter::VideoWriter or VideoWriter::open.
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        // ReSharper disable once InconsistentNaming
        public static int FourCC(string code)
        {
            if (code == null)
                throw new ArgumentNullException(nameof(code));
            if (code.Length != 4)
                throw new ArgumentException("code.Length != 4", nameof(code));

            return FourCC(code[0], code[1], code[2], code[3]);
        }

        /// <summary>
        /// Returns used backend API name.
        /// Note that stream should be opened.
        /// </summary>
        /// <returns></returns>
        public string GetBackendName()
        {
            ThrowIfDisposed();

            using var returnString = new StdString();
            NativeMethods.HandleException(
                NativeMethods.videoio_VideoWriter_getBackendName(ptr, returnString.CvPtr));

            GC.KeepAlive(this);
            return returnString.ToString();
        }

        #endregion
    }
}
