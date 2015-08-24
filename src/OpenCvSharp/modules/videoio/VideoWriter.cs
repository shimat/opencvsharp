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
        /// <summary>
        /// Track whether Dispose has been called
        /// </summary>
        private bool disposed = false;

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
            ptr = NativeMethods.videoio_VideoWriter_new1();
            if (ptr == IntPtr.Zero)
                throw new OpenCvSharpException("Failed to create VideoWriter");
        }

#if LANG_JP
        /// <summary>
        /// ビデオライタを作成する.
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
        /// <param name="fps">Framerate of the created video stream. </param>
        /// <param name="frameSize">Size of video frames. </param>
        /// <param name="isColor">If it is true, the encoder will expect and encode color frames, otherwise it will work with grayscale frames (the flag is currently supported on Windows only). </param>
#endif
        public VideoWriter(string fileName, string fourcc, double fps, Size frameSize, bool isColor = true)
            : this(fileName, FourCCCalcurator.Run(fourcc), fps, frameSize, isColor)
        {
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
        /// <param name="fps">Framerate of the created video stream. </param>
        /// <param name="frameSize">Size of video frames. </param>
        /// <param name="isColor">If it is true, the encoder will expect and encode color frames, otherwise it will work with grayscale frames (the flag is currently supported on Windows only). </param>
        /// <returns></returns>
#endif
        public VideoWriter(string fileName, FourCC fourcc, double fps, Size frameSize, bool isColor = true)
            : this(fileName, (int)fourcc, fps, frameSize, isColor)
        {
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
        /// <param name="fps">Framerate of the created video stream. </param>
        /// <param name="frameSize">Size of video frames. </param>
        /// <param name="isColor">If it is true, the encoder will expect and encode color frames, otherwise it will work with grayscale frames (the flag is currently supported on Windows only). </param>
        /// <returns></returns>
#endif
        public VideoWriter(string fileName, int fourcc, double fps, Size frameSize, bool isColor = true)
        {
            if (fileName == null)
                throw new ArgumentNullException();

            FileName = fileName;
            Fps = fps;
            FrameSize = frameSize;
            IsColor = isColor;
            ptr = NativeMethods.videoio_VideoWriter_new2(fileName, fourcc, fps, frameSize, isColor ? 1 : 0);
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
                        NativeMethods.videoio_VideoWriter_delete(ptr);
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
        /// <param name="fps">Framerate of the created video stream. </param>
        /// <param name="frameSize">Size of video frames. </param>
        /// <param name="isColor">If it is true, the encoder will expect and encode color frames, otherwise it will work with grayscale frames (the flag is currently supported on Windows only). </param>
        /// <returns></returns>
#endif
        public void Open(string fileName, string fourcc, double fps, Size frameSize, bool isColor = true)
        {
            Open(fileName, FourCCCalcurator.Run(fourcc), fps, frameSize, isColor);
        }

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
        /// <param name="fps">Framerate of the created video stream. </param>
        /// <param name="frameSize">Size of video frames. </param>
        /// <param name="isColor">If it is true, the encoder will expect and encode color frames, otherwise it will work with grayscale frames (the flag is currently supported on Windows only). </param>
        /// <returns></returns>
#endif
        public void Open(string fileName, FourCC fourcc, double fps, Size frameSize, bool isColor = true)
        {
            Open(fileName, (int)fourcc, fps, frameSize, isColor);
        }

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
        /// <param name="fps">Framerate of the created video stream. </param>
        /// <param name="frameSize">Size of video frames. </param>
        /// <param name="isColor">If it is true, the encoder will expect and encode color frames, otherwise it will work with grayscale frames (the flag is currently supported on Windows only). </param>
        /// <returns></returns>
#endif
        public void Open(string fileName, int fourcc, double fps, Size frameSize, bool isColor = true)
        {
            ThrowIfDisposed();
            if (String.IsNullOrEmpty(fileName))
                throw new ArgumentNullException("fileName");

            FileName = fileName;
            Fps = fps;
            FrameSize = frameSize;
            IsColor = isColor;
            NativeMethods.videoio_VideoWriter_open(ptr, fileName, fourcc, fps, frameSize, isColor ? 1 : 0);
        }

        /// <summary>
        /// Returns true if video writer has been successfully initialized.
        /// </summary>
        /// <returns></returns>
        public bool IsOpened()
        {
            ThrowIfDisposed();
            return NativeMethods.videoio_VideoWriter_isOpened(ptr) != 0;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public void Release()
        {
            ThrowIfDisposed();
            NativeMethods.videoio_VideoWriter_release(ptr);
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
        public void Write(Mat image)
        {
            ThrowIfDisposed();
            if(image == null)
                throw new ArgumentNullException("image");
            image.ThrowIfDisposed();
            NativeMethods.videoio_VideoWriter_write(ptr, image.CvPtr);
        }

        /// <summary>
        /// Concatenates 4 chars to a fourcc code.
        /// This static method constructs the fourcc code of the codec to be used in 
        /// the constructor VideoWriter::VideoWriter or VideoWriter::open.
        /// </summary>
        /// <param name="c1"></param>
        /// <param name="c2"></param>
        /// <param name="c3"></param>
        /// <param name="c4"></param>
        /// <returns></returns>
// ReSharper disable once InconsistentNaming
        public static int FourCC(char c1, char c2, char c3, char c4)
        {
            return NativeMethods.videoio_VideoWriter_fourcc((byte) c1, (byte) c2, (byte) c3, (byte) c4);
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
                throw new ArgumentNullException("code");
            if (code.Length != 4)
                throw new ArgumentException("code.Length != 4", "code");

            return FourCC(code[0], code[1], code[2], code[3]);
        }

        #endregion
    }
}
