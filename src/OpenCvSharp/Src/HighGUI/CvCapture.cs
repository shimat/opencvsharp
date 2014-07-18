using System;
using System.Runtime.InteropServices;

namespace OpenCvSharp
{
#if LANG_JP
    /// <summary>
    /// ビデオキャプチャ
    /// </summary>
#else
    /// <summary>
    /// Video capturing class 
    /// </summary>
#endif
    public class CvCapture : DisposableCvObject
    {
        #region Fields
#if LANG_JP
        /// <summary>
        /// キャプチャの種類 (File or Camera)
        /// </summary>
#else
        /// <summary>
        /// Capture type (File or Camera)
        /// </summary>
#endif
        protected CaptureType captureType;
        /// <summary>
        /// Track whether Dispose has been called
        /// </summary>
        protected bool disposed = false;
        #endregion

        #region Init and Disposal
#if LANG_JP
        /// <summary>
        /// カメラからのビデオキャプチャを初期化する.
        /// Windows では，次の二つのカメラインタフェースが利用できる：Video for Windows（VFW），Matrox Imaging Library（MIL）． 
        /// Linux では，次の二つカメラインタフェースが利用できる：Video for Linux（V4L），FireWire（IEEE1394）． 
        /// </summary>
        /// <param name="index">使われるカメラのインデックス．使用するカメラが1台のとき，あるいは，何台のカメラを使うかが重要でないときは，-1 でも問題ない場合もある.</param>
        /// <returns></returns>
#else
        /// <summary>
        /// Allocates and initialized the CvCapture structure for reading a video stream from the camera. 
        /// Currently two camera interfaces can be used on Windows: Video for Windows (VFW) and Matrox Imaging Library (MIL); and two on Linux: V4L and FireWire (IEEE1394).
        /// </summary>
        /// <param name="index">Index of the camera to be used. If there is only one camera or it does not matter what camera to use -1 may be passed. </param>
        /// <returns></returns>
#endif
        public CvCapture(int index)
        {
            try
            {
                ptr = NativeMethods.cvCreateCameraCapture(index);
            }
            catch (AccessViolationException e)
            {
                throw new OpenCvSharpException("Failed to create CvCapture", e);
            }

            if (ptr == IntPtr.Zero)
                throw new OpenCvSharpException("Failed to create CvCapture");
            
            captureType = CaptureType.Camera;
        }
#if LANG_JP
        /// <summary>
        /// カメラからのビデオキャプチャを初期化する.
        /// Windows では，次の二つのカメラインタフェースが利用できる：Video for Windows（VFW），Matrox Imaging Library（MIL）． 
        /// Linux では，次の二つカメラインタフェースが利用できる：Video for Linux（V4L），FireWire（IEEE1394）． 
        /// </summary>
        /// <param name="device">使われるカメラの種類</param>
        /// <returns></returns>
#else
        /// <summary>
        /// Allocates and initialized the CvCapture structure for reading a video stream from the camera. 
        /// Currently two camera interfaces can be used on Windows: Video for Windows (VFW) and Matrox Imaging Library (MIL); and two on Linux: V4L and FireWire (IEEE1394). 
        /// </summary>
        /// <param name="device">Device type</param>
        /// <returns></returns>
#endif
        public CvCapture(CaptureDevice device)
            : this((int)device)
        {
        }
#if LANG_JP
        /// <summary>
        /// カメラからのビデオキャプチャを初期化する.
        /// Windows では，次の二つのカメラインタフェースが利用できる：Video for Windows（VFW），Matrox Imaging Library（MIL）． 
        /// Linux では，次の二つカメラインタフェースが利用できる：Video for Linux（V4L），FireWire（IEEE1394）． 
        /// </summary>
        /// <param name="device">使われるカメラの種類</param>
        /// <param name="index">使われるカメラのインデックス．使用するカメラが1台のとき，あるいは，何台のカメラを使うかが重要でないときは，-1 でも問題ない場合もある.</param>
        /// <returns></returns>
#else
        /// <summary>
        /// Allocates and initialized the CvCapture structure for reading a video stream from the camera. 
        /// Currently two camera interfaces can be used on Windows: Video for Windows (VFW) and Matrox Imaging Library (MIL); and two on Linux: V4L and FireWire (IEEE1394). 
        /// </summary>
        /// <param name="device">Device type</param>
        /// <param name="index">Index of the camera to be used. If there is only one camera or it does not matter what camera to use -1 may be passed. </param>
        /// <returns></returns>
#endif
        public CvCapture(CaptureDevice device, int index)
            : this((int)device + index)
        {
        }
#if LANG_JP
        /// <summary>
        /// カメラからのビデオキャプチャを初期化する.
        /// Windows では，次の二つのカメラインタフェースが利用できる：Video for Windows（VFW），Matrox Imaging Library（MIL）． 
        /// Linux では，次の二つカメラインタフェースが利用できる：Video for Linux（V4L），FireWire（IEEE1394）． 
        /// </summary>
        /// <param name="index">使われるカメラのインデックス．使用するカメラが１台のとき，あるいは，何台のカメラを使うかが重要でないときは，-1 でも問題ない場合もある.</param>
        /// <returns></returns>
#else
        /// <summary>
        /// Allocates and initialized the CvCapture structure for reading a video stream from the camera. 
        /// Currently two camera interfaces can be used on Windows: Video for Windows (VFW) and Matrox Imaging Library (MIL); and two on Linux: V4L and FireWire (IEEE1394).
        /// </summary>
        /// <param name="index">Index of the camera to be used. If there is only one camera or it does not matter what camera to use -1 may be passed. </param>
        /// <returns></returns>
#endif
        public static CvCapture FromCamera(int index)
        {
            return new CvCapture(index);
        }
#if LANG_JP
        /// <summary>
        /// カメラからのビデオキャプチャを初期化する.
        /// Windows では，次の二つのカメラインタフェースが利用できる：Video for Windows（VFW），Matrox Imaging Library（MIL）． 
        /// Linux では，次の二つカメラインタフェースが利用できる：Video for Linux（V4L），FireWire（IEEE1394）． 
        /// </summary>
        /// <param name="device">使われるカメラの種類</param>
        /// <returns></returns>
#else
        /// <summary>
        /// Allocates and initialized the CvCapture structure for reading a video stream from the camera. 
        /// Currently two camera interfaces can be used on Windows: Video for Windows (VFW) and Matrox Imaging Library (MIL); and two on Linux: V4L and FireWire (IEEE1394). 
        /// </summary>
        /// <param name="device">Device type</param>
        /// <returns></returns>
#endif
        public static CvCapture FromCamera(CaptureDevice device)
        {
            return new CvCapture(device);
        }
#if LANG_JP
        /// <summary>
        /// カメラからのビデオキャプチャを初期化する.
        /// Windows では，次の二つのカメラインタフェースが利用できる：Video for Windows（VFW），Matrox Imaging Library（MIL）． 
        /// Linux では，次の二つカメラインタフェースが利用できる：Video for Linux（V4L），FireWire（IEEE1394）． 
        /// </summary>
        /// <param name="device">使われるカメラの種類</param>
        /// <param name="index">使われるカメラのインデックス．使用するカメラが1台のとき，あるいは，何台のカメラを使うかが重要でないときは，-1 でも問題ない場合もある.</param>
        /// <returns></returns>
#else
        /// <summary>
        /// Allocates and initialized the CvCapture structure for reading a video stream from the camera. 
        /// Currently two camera interfaces can be used on Windows: Video for Windows (VFW) and Matrox Imaging Library (MIL); and two on Linux: V4L and FireWire (IEEE1394). 
        /// </summary>
        /// <param name="device">Device type</param>
        /// <param name="index">Index of the camera to be used. If there is only one camera or it does not matter what camera to use -1 may be passed. </param>
        /// <returns></returns>
#endif
        public static CvCapture FromCamera(CaptureDevice device, int index)
        {
            return new CvCapture((int)device + index);
        }

#if LANG_JP
        /// <summary>
        /// ファイルからのビデオキャプチャを初期化する
        /// </summary>
        /// <param name="fileName">ビデオファイル名</param>
        /// <returns></returns>
#else
        /// <summary>
        /// Allocates and initialized the CvCapture structure for reading the video stream from the specified file.
        /// After the allocated structure is not used any more it should be released by cvReleaseCapture function. 
        /// </summary>
        /// <param name="fileName">Name of the video file. </param>
        /// <returns></returns>
#endif
        public CvCapture(string fileName)
        {
            if (string.IsNullOrEmpty(fileName))
                throw new ArgumentNullException("fileName");
            /*if (!File.Exists(filename))
                throw new FileNotFoundException("File not found", filename);*/

            ptr = NativeMethods.cvCreateFileCapture(fileName);
            if (ptr == IntPtr.Zero)
                throw new OpenCvSharpException("Failed to create CvCapture");
            
            captureType = CaptureType.File;
        }
#if LANG_JP
        /// <summary>
        /// ファイルからのビデオキャプチャを初期化する
        /// </summary>
        /// <param name="filename">ビデオファイル名</param>
        /// <returns></returns>
#else
        /// <summary>
        /// Allocates and initialized the CvCapture structure for reading the video stream from the specified file.
        /// After the allocated structure is not used any more it should be released by cvReleaseCapture function. 
        /// </summary>
        /// <param name="filename">Name of the video file. </param>
        /// <returns></returns>
#endif
        public static CvCapture FromFile(string filename)
        {
            return new CvCapture(filename);
        }

        /// <summary>
        /// ポインタから初期化
        /// </summary>
        /// <param name="ptr">CvCapture*</param>
        protected internal CvCapture(IntPtr ptr)
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
                        NativeMethods.cvReleaseCapture(ref ptr);
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
        #region Basic
#if LANG_JP
        /// <summary>
        /// キャプチャの種類 (File or Camera)
        /// </summary>
#else
        /// <summary>
        /// Gets the capture type (File or Camera) 
        /// </summary>
#endif
        public CaptureType CaptureType
        {
            get { return captureType; }
        }

#if LANG_JP
        /// <summary>
        /// ファイル中の現在の位置（ミリ秒単位），あるいはビデオキャプチャのタイムスタンプ値を取得・設定する
        /// </summary>
#else
        /// <summary>
        /// Gets or sets film current position in milliseconds or video capture timestamp 
        /// </summary>
#endif
        public int PosMsec
        {
            get
            {
                return (int)NativeMethods.cvGetCaptureProperty(ptr, CaptureProperty.PosMsec);
            }
            set
            {
                NativeMethods.cvSetCaptureProperty(ptr, CaptureProperty.PosMsec, value);
            }
        }

#if LANG_JP
        /// <summary>
        /// 次にデコード/キャプチャされるフレームのインデックス(0からはじまる)を取得・設定する（設定はビデオファイルのみ）
        /// </summary>
#else
        /// <summary>
        /// Gets or sets 0-based index of the frame to be decoded/captured next
        /// </summary>
#endif
        public int PosFrames
        {
            get
            {
                return (int)NativeMethods.cvGetCaptureProperty(ptr, CaptureProperty.PosFrames);
            }
            set
            {
                if (captureType == CaptureType.Camera)
                    throw new NotSupportedException("Only for video files");
                NativeMethods.cvSetCaptureProperty(
                    ptr, CaptureProperty.PosFrames, value);
            }
        }

#if LANG_JP
        /// <summary>
        /// ビデオファイル内の相対的な位置を取得・設定する（設定はビデオファイルのみ）
        /// </summary>
#else
        /// <summary>
        /// Gets or sets relative position of video file
        /// </summary>
#endif
        public CapturePosAviRatio PosAviRatio
        {
            get
            {
                return (CapturePosAviRatio)(int)NativeMethods.cvGetCaptureProperty(ptr, CaptureProperty.PosAviRatio);
            }
            set
            {
                if (captureType == CaptureType.Camera)
                    throw new NotSupportedException("Only for video files");
                NativeMethods.cvSetCaptureProperty(
                    ptr, CaptureProperty.PosAviRatio, (int)value);
            }
        }

#if LANG_JP
        /// <summary>
        /// ビデオストリーム中のフレームの幅を取得・設定する（設定はカメラのみ）
        /// </summary>
#else
        /// <summary>
        /// Gets or sets width of frames in the video stream
        /// </summary>
#endif
        public int FrameWidth
        {
            get
            {
                return (int)NativeMethods.cvGetCaptureProperty(ptr, CaptureProperty.FrameWidth);
            }
            set
            {
                if (captureType == CaptureType.File)
                    throw new NotSupportedException("Only for cameras");
                NativeMethods.cvSetCaptureProperty(
                    ptr, CaptureProperty.FrameWidth, value);
            }
        }

#if LANG_JP
        /// <summary>
        /// ビデオストリーム中のフレームの高さを取得・設定する（設定はカメラのみ）
        /// </summary>
#else
        /// <summary>
        /// Gets or sets height of frames in the video stream 
        /// </summary>
#endif
        public int FrameHeight
        {
            get
            {
                return (int)NativeMethods.cvGetCaptureProperty(ptr, CaptureProperty.FrameHeight);
            }
            set
            {
                if (captureType == CaptureType.File)
                    throw new NotSupportedException("Only for cameras");
                NativeMethods.cvSetCaptureProperty(
                    ptr, CaptureProperty.FrameHeight, value);
            }
        }

#if LANG_JP
        /// <summary>
        /// フレームレートを取得・設定する（設定はカメラのみ）
        /// </summary>
#else
        /// <summary>
        /// Gets or sets frame rate
        /// </summary>
#endif
        public double Fps
        {
            get
            {
                return NativeMethods.cvGetCaptureProperty(ptr, CaptureProperty.Fps);
            }
            set
            {
                if (captureType == CaptureType.File)
                    throw new NotSupportedException("Only for cameras");
                NativeMethods.cvSetCaptureProperty(ptr, CaptureProperty.Fps, value);
            }
        }

#if LANG_JP
        /// <summary>
        /// コーデックを表す4文字を取得・設定する（設定はカメラのみ）.
        /// 例えば，"PIM1" は，MPEG-1 コーデック， "MJPG" は，motion-jpeg コーデックである． 
        /// Win32 環境下では，null を渡すとダイアログから圧縮方法と圧縮のパラメータを選択できるようになる. 
        /// </summary>
#else
        /// <summary>
        /// Gets or sets 4-character code of codec 
        /// </summary>
#endif
// ReSharper disable InconsistentNaming
        public string FourCC
// ReSharper restore InconsistentNaming
        {
            get
            {
                int src = (int)NativeMethods.cvGetCaptureProperty(ptr, CaptureProperty.FourCC);
                var bytes = new IntBytes { Value = src };
                char[] fourcc = {
                    Convert.ToChar(bytes.B1),
                    Convert.ToChar(bytes.B2),
                    Convert.ToChar(bytes.B3),
                    Convert.ToChar(bytes.B4)
                };
                return new string(fourcc);
            }
            set
            {
                if (captureType == CaptureType.File)
                    throw new NotSupportedException("Only for cameras");
                if (value.Length != 4)
                    throw new ArgumentException("Length of the argument string must be 4");
                
                byte c1 = Convert.ToByte(value[0]);
                byte c2 = Convert.ToByte(value[1]);
                byte c3 = Convert.ToByte(value[2]);
                byte c4 = Convert.ToByte(value[3]);
                int v = Cv.FOURCC(c1, c2, c3, c4);
                NativeMethods.cvSetCaptureProperty(ptr, CaptureProperty.FourCC, v);
            }
        }

#if LANG_JP
        /// <summary>
        /// ビデオファイル中のフレーム数を取得する
        /// </summary>
#else
        /// <summary>
        /// Gets number of frames in video file 
        /// </summary>
#endif
        public int FrameCount
        {
            get
            {
                return (int)NativeMethods.cvGetCaptureProperty(
                    ptr, CaptureProperty.FrameCount);
            }
        }

#if LANG_JP
        /// <summary>
        /// 明度を取得・設定する
        /// </summary>
#else
        /// <summary>
        /// Gets or sets brightness of image (only for cameras) 
        /// </summary>
#endif
        public double Brightness
        {
            get
            {
                if (captureType == CaptureType.File)
                    throw new NotSupportedException("Only for cameras");
                return (int)NativeMethods.cvGetCaptureProperty(
                    ptr, CaptureProperty.Brightness);
            }
            set
            {
                if (captureType == CaptureType.File)
                    throw new NotSupportedException("Only for cameras");
                NativeMethods.cvSetCaptureProperty(
                    ptr, CaptureProperty.Brightness, value);
            }
        }

#if LANG_JP
        /// <summary>
        /// コンストラストを取得・設定する
        /// </summary>
#else
        /// <summary>
        /// Gets or sets contrast of image (only for cameras) 
        /// </summary>
#endif
        public double Contrast
        {
            get
            {
                if (captureType == CaptureType.File)
                    throw new NotSupportedException("Only for cameras");
                return (int)NativeMethods.cvGetCaptureProperty(
                    ptr, CaptureProperty.Contrast);
            }
            set
            {
                if (captureType == CaptureType.File)
                    throw new NotSupportedException("Only for cameras");
                NativeMethods.cvSetCaptureProperty(
                    ptr, CaptureProperty.Contrast, value);
            }
        }

#if LANG_JP
        /// <summary>
        /// 彩度を取得・設定する
        /// </summary>
#else
        /// <summary>
        /// Gets or sets saturation of image (only for cameras) 
        /// </summary>
#endif
        public double Saturation
        {
            get
            {
                if (captureType == CaptureType.File)
                {
                    throw new NotSupportedException("Only for cameras");
                }
                return (int)NativeMethods.cvGetCaptureProperty(ptr, CaptureProperty.Saturation);
            }
            set
            {
                if (captureType == CaptureType.File)
                {
                    throw new NotSupportedException("Only for cameras");
                }
                NativeMethods.cvSetCaptureProperty(ptr, CaptureProperty.Saturation, value);
            }
        }

#if LANG_JP
        /// <summary>
        /// 色相を取得・設定する
        /// </summary>
#else
        /// <summary>
        /// Gets or sets hue of image (only for cameras) 
        /// </summary>
#endif
        public double Hue
        {
            get
            {
                if (captureType == CaptureType.File)
                {
                    throw new NotSupportedException("Only for cameras");
                }
                return (int)NativeMethods.cvGetCaptureProperty(ptr, CaptureProperty.Hue);
            }
            set
            {
                if (captureType == CaptureType.File)
                {
                    throw new NotSupportedException("Only for cameras");
                }
                NativeMethods.cvSetCaptureProperty(ptr, CaptureProperty.Hue, value);
            }
        }

#if LANG_JP
		/// <summary>
		/// retrieve() によって返されるMat オブジェクトのフォーマット．
		/// </summary>
#else
        /// <summary>
        /// The format of the Mat objects returned by retrieve()
        /// </summary>
#endif
        public int Format
        {
            get
            {
                return (int)NativeMethods.cvGetCaptureProperty(ptr, CaptureProperty.Format);
            }
            set
            {
                NativeMethods.cvSetCaptureProperty(ptr, CaptureProperty.Format, value);
            }
        }


#if LANG_JP
		/// <summary>
		/// 現在のキャプチャモードを表す，バックエンド固有の値．
		/// </summary>
#else
        /// <summary>
        /// A backend-specific value indicating the current capture mode
        /// </summary>
#endif
        public int Mode
        {
            get
            {
                return (int)NativeMethods.cvGetCaptureProperty(ptr, CaptureProperty.Mode);
            }
            set
            {
                NativeMethods.cvSetCaptureProperty(ptr, CaptureProperty.Mode, value);
            }
        }


#if LANG_JP
		/// <summary>
		/// 画像のゲイン（カメラの場合のみ）．
		/// </summary>
#else
        /// <summary>
        /// Gain of the image (only for cameras)
        /// </summary>
#endif
        public double Gain
        {
            get
            {
                if (captureType == CaptureType.File)
                {
                    throw new NotSupportedException("Only for cameras");
                }
                return NativeMethods.cvGetCaptureProperty(ptr, CaptureProperty.Gain);
            }
            set
            {
                if (captureType == CaptureType.File)
                {
                    throw new NotSupportedException("Only for cameras");
                }
                NativeMethods.cvSetCaptureProperty(ptr, CaptureProperty.Gain, value);
            }
        }


#if LANG_JP
		/// <summary>
		/// 露出（カメラの場合のみ）．
		/// </summary>
#else
        /// <summary>
        /// Exposure (only for cameras)
        /// </summary>
#endif
        public double Exposure
        {
            get
            {
                if (captureType == CaptureType.File)
                {
                    throw new NotSupportedException("Only for cameras");
                }
                return NativeMethods.cvGetCaptureProperty(ptr, CaptureProperty.Exposure);
            }
            set
            {
                if (captureType == CaptureType.File)
                {
                    throw new NotSupportedException("Only for cameras");
                }
                NativeMethods.cvSetCaptureProperty(ptr, CaptureProperty.Exposure, value);
            }
        }


#if LANG_JP
		/// <summary>
		/// 画像がRGBに変換されるか否かを表す，ブール値のフラグ．
		/// </summary>
#else
        /// <summary>
        /// Boolean flags indicating whether images should be converted to RGB
        /// </summary>
#endif
        public bool ConvertRgb
        {
            get
            {
                return (int)NativeMethods.cvGetCaptureProperty(ptr, CaptureProperty.ConvertRgb) != 0;
            }
            set
            {
                NativeMethods.cvSetCaptureProperty(ptr, CaptureProperty.ConvertRgb, value ? 0 : 1);
            }
        }


#if LANG_JP
		/// <summary>
		/// 
		/// </summary>
#else
        /// <summary>
        /// 
        /// </summary>
#endif
        public double WhiteBalance
        {
            get
            {
                return NativeMethods.cvGetCaptureProperty(ptr, CaptureProperty.WhiteBalance);
            }
            set
            {
                NativeMethods.cvSetCaptureProperty(ptr, CaptureProperty.WhiteBalance, value);
            }
        }


#if LANG_JP
		/// <summary>
		/// TOWRITE（注意：現在のところ，DC1394 v 2.x バックエンドでのみサポートされます）．
		/// </summary>
#else
        /// <summary>
        /// TOWRITE (note: only supported by DC1394 v 2.x backend currently)
        /// </summary>
#endif
        public double Rectification
        {
            get
            {
                return NativeMethods.cvGetCaptureProperty(ptr, CaptureProperty.Rectification);
            }
            set
            {
                NativeMethods.cvSetCaptureProperty(ptr, CaptureProperty.Rectification, value);
            }
        }

        
#if LANG_JP
		/// <summary>
		/// 
		/// </summary>
#else
        /// <summary>
        /// 
        /// </summary>
#endif
        public double Monocrome
        {
            get
            {
                return NativeMethods.cvGetCaptureProperty(ptr, CaptureProperty.Monocrome);
            }
            set
            {
                NativeMethods.cvSetCaptureProperty(ptr, CaptureProperty.Monocrome, value);
            }
        }
        #endregion
        #region Added for 2.3
#if LANG_JP
		/// <summary>
        /// 
		/// [CV_CAP_PROP_SHARPNESS]
		/// </summary>
#else
        /// <summary>
        /// 
        /// [CV_CAP_PROP_SHARPNESS]
        /// </summary>
#endif
        public double Sharpness
        {
            get
            {
                return NativeMethods.cvGetCaptureProperty(ptr, CaptureProperty.Sharpness);
            }
            set
            {
                NativeMethods.cvSetCaptureProperty(ptr, CaptureProperty.Sharpness, value);
            }
        }

#if LANG_JP
		/// <summary>
        /// exposure control done by camera,
        /// user can adjust refernce level using this feature
		/// [CV_CAP_PROP_AUTO_EXPOSURE]
		/// </summary>
#else
        /// <summary>
        /// exposure control done by camera,
        /// user can adjust refernce level using this feature
        /// [CV_CAP_PROP_AUTO_EXPOSURE]
        /// </summary>
#endif
        public double AutoExposure
        {
            get
            {
                return NativeMethods.cvGetCaptureProperty(ptr, CaptureProperty.AutoExposure);
            }
            set
            {
                NativeMethods.cvSetCaptureProperty(ptr, CaptureProperty.AutoExposure, value);
            }
        }

#if LANG_JP
		/// <summary>
        /// 
		/// [CV_CAP_PROP_GAMMA]
		/// </summary>
#else
        /// <summary>
        /// 
        /// [CV_CAP_PROP_GAMMA]
        /// </summary>
#endif
        public double Gamma
        {
            get
            {
                return NativeMethods.cvGetCaptureProperty(ptr, CaptureProperty.Gamma);
            }
            set
            {
                NativeMethods.cvSetCaptureProperty(ptr, CaptureProperty.Gamma, value);
            }
        }

#if LANG_JP
		/// <summary>
        /// 
		/// [CV_CAP_PROP_TEMPERATURE]
		/// </summary>
#else
        /// <summary>
        /// 
        /// [CV_CAP_PROP_TEMPERATURE]
        /// </summary>
#endif
        public double Temperature
        {
            get
            {
                return NativeMethods.cvGetCaptureProperty(ptr, CaptureProperty.Temperature);
            }
            set
            {
                NativeMethods.cvSetCaptureProperty(ptr, CaptureProperty.Temperature, value);
            }
        }

#if LANG_JP
		/// <summary>
        /// 
		/// [CV_CAP_PROP_TRIGGER]
		/// </summary>
#else
        /// <summary>
        /// 
        /// [CV_CAP_PROP_TRIGGER]
        /// </summary>
#endif
        public double Trigger
        {
            get
            {
                return NativeMethods.cvGetCaptureProperty(ptr, CaptureProperty.Trigger);
            }
            set
            {
                NativeMethods.cvSetCaptureProperty(ptr, CaptureProperty.Trigger, value);
            }
        }

#if LANG_JP
		/// <summary>
        /// 
		/// [CV_CAP_PROP_TRIGGER_DELAY]
		/// </summary>
#else
        /// <summary>
        /// 
        /// [CV_CAP_PROP_TRIGGER_DELAY]
        /// </summary>
#endif
        public double TriggerDelay
        {
            get
            {
                return NativeMethods.cvGetCaptureProperty(ptr, CaptureProperty.TriggerDelay);
            }
            set
            {
                NativeMethods.cvSetCaptureProperty(ptr, CaptureProperty.TriggerDelay, value);
            }
        }

#if LANG_JP
		/// <summary>
        /// 
		/// [CV_CAP_PROP_WHITE_BALANCE_RED_V]
		/// </summary>
#else
        /// <summary>
        /// 
        /// [CV_CAP_PROP_WHITE_BALANCE_RED_V]
        /// </summary>
#endif
        public double WhiteBalanceRedV
        {
            get
            {
                return NativeMethods.cvGetCaptureProperty(ptr, CaptureProperty.WhiteBalanceRedV);
            }
            set
            {
                NativeMethods.cvSetCaptureProperty(ptr, CaptureProperty.WhiteBalanceRedV, value);
            }
        }

#if LANG_JP
		/// <summary>
        /// 
		/// [CV_CAP_PROP_MAX_DC1394]
		/// </summary>
#else
        /// <summary>
        /// 
        /// [CV_CAP_PROP_MAX_DC1394]
        /// </summary>
#endif
// ReSharper disable InconsistentNaming
        public double MaxDC1394
// ReSharper restore InconsistentNaming
        {
            get
            {
                return NativeMethods.cvGetCaptureProperty(ptr, CaptureProperty.MaxDC1394);
            }
            set
            {
                NativeMethods.cvSetCaptureProperty(ptr, CaptureProperty.MaxDC1394, value);
            }
        }

#if LANG_JP
		/// <summary>
        /// property for highgui class CvCapture_Android only
		/// [CV_CAP_PROP_AUTOGRAB]
		/// </summary>
#else
        /// <summary>
        /// property for highgui class CvCapture_Android only
        /// [CV_CAP_PROP_AUTOGRAB]
        /// </summary>
#endif
        public double AutoGrab
        {
            get
            {
                return NativeMethods.cvGetCaptureProperty(ptr, CaptureProperty.AutoGrab);
            }
            set
            {
                NativeMethods.cvSetCaptureProperty(ptr, CaptureProperty.AutoGrab, value);
            }
        }

#if LANG_JP
		/// <summary>
        /// readonly, tricky property, returns cpnst char* indeed
		/// [CV_CAP_PROP_SUPPORTED_PREVIEW_SIZES_STRING]
		/// </summary>
#else
        /// <summary>
        /// readonly, tricky property, returns cpnst char* indeed
        /// [CV_CAP_PROP_SUPPORTED_PREVIEW_SIZES_STRING]
        /// </summary>
#endif
        public string SupportedPreviewSizesString
        {
            get
            {
                // double to const char*
                double d = NativeMethods.cvGetCaptureProperty(ptr, CaptureProperty.SupportedPreviewSizesString);
                unsafe
                {
                    char* p = (char*)(long)d;  // problematic cast
                    return new string(p);
                }
            }
        }

#if LANG_JP
		/// <summary>
        /// readonly, tricky property, returns cpnst char* indeed
		/// [CV_CAP_PROP_PREVIEW_FORMAT]
		/// </summary>
#else
        /// <summary>
        /// readonly, tricky property, returns cpnst char* indeed
        /// [CV_CAP_PROP_PREVIEW_FORMAT]
        /// </summary>
#endif
        public string PreviewFormat
        {
            get
            {
                // double to const char*
                double d = NativeMethods.cvGetCaptureProperty(ptr, CaptureProperty.PreviewFormat);
                unsafe
                {
                    char* p = (char*)(long)d;  // problematic cast
                    return new string(p);
                }
            }
        }
        #endregion
        #region OpenNI
        // Properties of cameras available through OpenNI interfaces
// ReSharper disable InconsistentNaming
#if LANG_JP
		/// <summary>
        /// 
		/// [CV_CAP_PROP_OPENNI_OUTPUT_MODE]
		/// </summary>
#else
        /// <summary>
        /// 
        /// [CV_CAP_PROP_OPENNI_OUTPUT_MODE]
        /// </summary>
#endif
        public double OpenNI_OutputMode
        {
            get
            {
                return NativeMethods.cvGetCaptureProperty(ptr, CaptureProperty.OpenNI_OutputMode);
            }
            set
            {
                NativeMethods.cvSetCaptureProperty(ptr, CaptureProperty.OpenNI_OutputMode, value);
            }
        }

#if LANG_JP
		/// <summary>
        /// in mm
		/// [CV_CAP_PROP_OPENNI_FRAME_MAX_DEPTH]
		/// </summary>
#else
        /// <summary>
        /// in mm
        /// [CV_CAP_PROP_OPENNI_FRAME_MAX_DEPTH]
        /// </summary>
#endif
        public double OpenNI_FrameMaxDepth
        {
            get
            {
                return NativeMethods.cvGetCaptureProperty(ptr, CaptureProperty.OpenNI_FrameMaxDepth);
            }
            set
            {
                NativeMethods.cvSetCaptureProperty(ptr, CaptureProperty.OpenNI_FrameMaxDepth, value);
            }
        }

#if LANG_JP
		/// <summary>
        /// in mm
		/// [CV_CAP_PROP_OPENNI_BASELINE]
		/// </summary>
#else
        /// <summary>
        /// in mm
        /// [CV_CAP_PROP_OPENNI_BASELINE]
        /// </summary>
#endif
        public double OpenNI_Baseline
        {
            get
            {
                return NativeMethods.cvGetCaptureProperty(ptr, CaptureProperty.OpenNI_Baseline);
            }
            set
            {
                NativeMethods.cvSetCaptureProperty(ptr, CaptureProperty.OpenNI_Baseline, value);
            }
        }

#if LANG_JP
		/// <summary>
        /// in pixels
		/// [CV_CAP_PROP_OPENNI_FOCAL_LENGTH]
		/// </summary>
#else
        /// <summary>
        /// in pixels
        /// [CV_CAP_PROP_OPENNI_FOCAL_LENGTH]
        /// </summary>
#endif
        public double OpenNI_FocalLength
        {
            get
            {
                return NativeMethods.cvGetCaptureProperty(ptr, CaptureProperty.OpenNI_FocalLength);
            }
            set
            {
                NativeMethods.cvSetCaptureProperty(ptr, CaptureProperty.OpenNI_FocalLength, value);
            }
        }

#if LANG_JP
		/// <summary>
        /// flag
		/// [CV_CAP_PROP_OPENNI_REGISTRATION_ON]
		/// </summary>
#else
        /// <summary>
        /// flag
        /// [CV_CAP_PROP_OPENNI_REGISTRATION_ON]
        /// </summary>
#endif
        public double OpenNI_RegistrationON
        {
            get
            {
                return NativeMethods.cvGetCaptureProperty(ptr, CaptureProperty.OpenNI_RegistrationON);
            }
            set
            {
                NativeMethods.cvSetCaptureProperty(ptr, CaptureProperty.OpenNI_RegistrationON, value);
            }
        }

#if LANG_JP
		/// <summary>
        /// flag that synchronizes the remapping depth map to image map
        /// by changing depth generator's view point (if the flag is "on") or
        /// sets this view point to its normal one (if the flag is "off").
		/// [CV_CAP_PROP_OPENNI_REGISTRATION]
		/// </summary>
#else
        /// <summary>
        /// flag that synchronizes the remapping depth map to image map
        /// by changing depth generator's view point (if the flag is "on") or
        /// sets this view point to its normal one (if the flag is "off").
        /// [CV_CAP_PROP_OPENNI_REGISTRATION]
        /// </summary>
#endif
        public double OpenNI_Registratiob
        {
            get
            {
                return NativeMethods.cvGetCaptureProperty(ptr, CaptureProperty.OpenNI_Registratiob);
            }
            set
            {
                NativeMethods.cvSetCaptureProperty(ptr, CaptureProperty.OpenNI_Registratiob, value);
            }
        }

#if LANG_JP
		/// <summary>
        /// 
		/// [CV_CAP_OPENNI_IMAGE_GENERATOR_OUTPUT_MODE]
		/// </summary>
#else
        /// <summary>
        /// 
        /// [CV_CAP_OPENNI_IMAGE_GENERATOR_OUTPUT_MODE]
        /// </summary>
#endif
        public double OpenNI_ImageGeneratorOutputMode
        {
            get
            {
                return NativeMethods.cvGetCaptureProperty(ptr, CaptureProperty.OpenNI_ImageGeneratorOutputMode);
            }
            set
            {
                NativeMethods.cvSetCaptureProperty(ptr, CaptureProperty.OpenNI_ImageGeneratorOutputMode, value);
            }
        }

#if LANG_JP
		/// <summary>
        /// 
		/// [CV_CAP_OPENNI_DEPTH_GENERATOR_BASELINE]
		/// </summary>
#else
        /// <summary>
        /// 
        /// [CV_CAP_OPENNI_DEPTH_GENERATOR_BASELINE]
        /// </summary>
#endif
        public double OpenNI_DepthGeneratorBaseline
        {
            get
            {
                return NativeMethods.cvGetCaptureProperty(ptr, CaptureProperty.OpenNI_DepthGeneratorBaseline);
            }
            set
            {
                NativeMethods.cvSetCaptureProperty(ptr, CaptureProperty.OpenNI_DepthGeneratorBaseline, value);
            }
        }

#if LANG_JP
		/// <summary>
        /// 
		/// [CV_CAP_OPENNI_DEPTH_GENERATOR_FOCAL_LENGTH]
		/// </summary>
#else
        /// <summary>
        /// 
        /// [CV_CAP_OPENNI_DEPTH_GENERATOR_FOCAL_LENGTH]
        /// </summary>
#endif
        public double OpenNI_DepthGeneratorFocalLength
        {
            get
            {
                return NativeMethods.cvGetCaptureProperty(ptr, CaptureProperty.OpenNI_DepthGeneratorFocalLength);
            }
            set
            {
                NativeMethods.cvSetCaptureProperty(ptr, CaptureProperty.OpenNI_DepthGeneratorFocalLength, value);
            }
        }

#if LANG_JP
		/// <summary>
        /// 
		/// [CV_CAP_OPENNI_DEPTH_GENERATOR_REGISTRATION_ON]
		/// </summary>
#else
        /// <summary>
        /// 
        /// [CV_CAP_OPENNI_DEPTH_GENERATOR_REGISTRATION_ON]
        /// </summary>
#endif
        public double OpenNI_DepthGeneratorRegistrationON
        {
            get
            {
                return NativeMethods.cvGetCaptureProperty(ptr, CaptureProperty.OpenNI_DepthGeneratorRegistrationON);
            }
            set
            {
                NativeMethods.cvSetCaptureProperty(ptr, CaptureProperty.OpenNI_DepthGeneratorRegistrationON, value);
            }
        }
// ReSharper restore InconsistentNaming
        #endregion
        #region GStreamer
        // Properties of cameras available through GStreamer interface

#if LANG_JP
		/// <summary>
        /// default is 1
		/// [CV_CAP_GSTREAMER_QUEUE_LENGTH]
		/// </summary>
#else
        /// <summary>
        /// default is 1
        /// [CV_CAP_GSTREAMER_QUEUE_LENGTH]
        /// </summary>
#endif
        public double GStreamerQueueLength
        {
            get
            {
                return NativeMethods.cvGetCaptureProperty(ptr, CaptureProperty.GStreamerQueueLength);
            }
            set
            {
                NativeMethods.cvSetCaptureProperty(ptr, CaptureProperty.GStreamerQueueLength, value);
            }
        }

#if LANG_JP
		/// <summary>
        /// ip for anable multicast master mode. 0 for disable multicast
		/// [CV_CAP_PROP_PVAPI_MULTICASTIP]
		/// </summary>
#else
        /// <summary>
        /// ip for anable multicast master mode. 0 for disable multicast
        /// [CV_CAP_PROP_PVAPI_MULTICASTIP]
        /// </summary>
#endif
// ReSharper disable InconsistentNaming
        public double PvAPIMulticastIP
// ReSharper restore InconsistentNaming
        {
            get
            {
                return NativeMethods.cvGetCaptureProperty(ptr, CaptureProperty.PvAPIMulticastIP);
            }
            set
            {
                NativeMethods.cvSetCaptureProperty(ptr, CaptureProperty.PvAPIMulticastIP, value);
            }
        }
        #endregion
        #region XI
        // Properties of cameras available through XIMEA SDK interface
// ReSharper disable InconsistentNaming
#if LANG_JP
		/// <summary>
        /// Change image resolution by binning or skipping.  
		/// [CV_CAP_PROP_XI_DOWNSAMPLING]
		/// </summary>
#else
        /// <summary>
        /// Change image resolution by binning or skipping.  
        /// [CV_CAP_PROP_XI_DOWNSAMPLING]
        /// </summary>
#endif
        public double XI_Downsampling
        {
            get
            {
                return NativeMethods.cvGetCaptureProperty(ptr, CaptureProperty.XI_Downsampling);
            }
            set
            {
                NativeMethods.cvSetCaptureProperty(ptr, CaptureProperty.XI_Downsampling, value);
            }
        }

#if LANG_JP
		/// <summary>
        /// Output data format.
		/// [CV_CAP_PROP_XI_DATA_FORMAT]
		/// </summary>
#else
        /// <summary>
        /// Output data format.
        /// [CV_CAP_PROP_XI_DATA_FORMAT]
        /// </summary>
#endif
        public double XI_DataFormat
        {
            get
            {
                return NativeMethods.cvGetCaptureProperty(ptr, CaptureProperty.XI_DataFormat);
            }
        }

#if LANG_JP
		/// <summary>
        /// Horizontal offset from the origin to the area of interest (in pixels).
		/// [CV_CAP_PROP_XI_OFFSET_X]
		/// </summary>
#else
        /// <summary>
        /// Horizontal offset from the origin to the area of interest (in pixels).
        /// [CV_CAP_PROP_XI_OFFSET_X]
        /// </summary>
#endif
        public double XI_OffsetX
        {
            get
            {
                return NativeMethods.cvGetCaptureProperty(ptr, CaptureProperty.XI_OffsetX);
            }
            set
            {
                NativeMethods.cvSetCaptureProperty(ptr, CaptureProperty.XI_OffsetX, value);
            }
        }

#if LANG_JP
		/// <summary>
        /// Vertical offset from the origin to the area of interest (in pixels).
		/// [CV_CAP_PROP_XI_OFFSET_Y]
		/// </summary>
#else
        /// <summary>
        /// Vertical offset from the origin to the area of interest (in pixels).
        /// [CV_CAP_PROP_XI_OFFSET_Y]
        /// </summary>
#endif
        public double XI_OffsetY
        {
            get
            {
                return NativeMethods.cvGetCaptureProperty(ptr, CaptureProperty.XI_OffsetY);
            }
            set
            {
                NativeMethods.cvSetCaptureProperty(ptr, CaptureProperty.XI_OffsetY, value);
            }
        }

#if LANG_JP
		/// <summary>
        /// Defines source of trigger.
		/// [CV_CAP_PROP_XI_TRG_SOURCE]
		/// </summary>
#else
        /// <summary>
        /// Defines source of trigger.
        /// [CV_CAP_PROP_XI_TRG_SOURCE]
        /// </summary>
#endif
        public double XI_TrgSource
        {
            get
            {
                return NativeMethods.cvGetCaptureProperty(ptr, CaptureProperty.XI_TrgSource);
            }
            set
            {
                NativeMethods.cvSetCaptureProperty(ptr, CaptureProperty.XI_TrgSource, value);
            }
        }

#if LANG_JP
		/// <summary>
        /// Generates an internal trigger. PRM_TRG_SOURCE must be set to TRG_SOFTWARE.
		/// [CV_CAP_PROP_XI_TRG_SOFTWARE]
		/// </summary>
#else
        /// <summary>
        /// Generates an internal trigger. PRM_TRG_SOURCE must be set to TRG_SOFTWARE.
        /// [CV_CAP_PROP_XI_TRG_SOFTWARE]
        /// </summary>
#endif
        public double XI_TrgSoftware
        {
            get
            {
                return NativeMethods.cvGetCaptureProperty(ptr, CaptureProperty.XI_TrgSoftware);
            }
            set
            {
                NativeMethods.cvSetCaptureProperty(ptr, CaptureProperty.XI_TrgSoftware, value);
            }
        }

#if LANG_JP
		/// <summary>
        /// Selects general purpose input
		/// [CV_CAP_PROP_XI_GPI_SELECTOR]
		/// </summary>
#else
        /// <summary>
        /// Selects general purpose input
        /// [CV_CAP_PROP_XI_GPI_SELECTOR]
        /// </summary>
#endif
        public double XI_GpiSelector
        {
            get
            {
                return NativeMethods.cvGetCaptureProperty(ptr, CaptureProperty.XI_GpiSelector);
            }
            set
            {
                NativeMethods.cvSetCaptureProperty(ptr, CaptureProperty.XI_GpiSelector, value);
            }
        }

#if LANG_JP
		/// <summary>
        /// Set general purpose input mode
		/// [CV_CAP_PROP_XI_GPI_MODE]
		/// </summary>
#else
        /// <summary>
        /// Set general purpose input mode
        /// [CV_CAP_PROP_XI_GPI_MODE]
        /// </summary>
#endif
        public double XI_GpiMode
        {
            get
            {
                return NativeMethods.cvGetCaptureProperty(ptr, CaptureProperty.XI_GpiMode);
            }
            set
            {
                NativeMethods.cvSetCaptureProperty(ptr, CaptureProperty.XI_GpiMode, value);
            }
        }

#if LANG_JP
		/// <summary>
        /// Get general purpose level
		/// [CV_CAP_PROP_XI_GPI_LEVEL]
		/// </summary>
#else
        /// <summary>
        /// Get general purpose level
        /// [CV_CAP_PROP_XI_GPI_LEVEL]
        /// </summary>
#endif
        public double XI_GpiLevel
        {
            get
            {
                return NativeMethods.cvGetCaptureProperty(ptr, CaptureProperty.XI_GpiLevel);
            }
            set
            {
                NativeMethods.cvSetCaptureProperty(ptr, CaptureProperty.XI_GpiLevel, value);
            }
        }

#if LANG_JP
		/// <summary>
        /// Selects general purpose output 
		/// [CV_CAP_PROP_XI_GPO_SELECTOR]
		/// </summary>
#else
        /// <summary>
        /// Selects general purpose output 
        /// [CV_CAP_PROP_XI_GPO_SELECTOR]
        /// </summary>
#endif
        public double XI_GpoSelector
        {
            get
            {
                return NativeMethods.cvGetCaptureProperty(ptr, CaptureProperty.XI_GpoSelector);
            }
            set
            {
                NativeMethods.cvSetCaptureProperty(ptr, CaptureProperty.XI_GpoSelector, value);
            }
        }

#if LANG_JP
		/// <summary>
        /// Set general purpose output mode
		/// [CV_CAP_PROP_XI_GPO_MODE]
		/// </summary>
#else
        /// <summary>
        /// Set general purpose output mode
        /// [CV_CAP_PROP_XI_GPO_MODE]
        /// </summary>
#endif
        public double XI_GpoMode
        {
            get
            {
                return NativeMethods.cvGetCaptureProperty(ptr, CaptureProperty.XI_GpoMode);
            }
            set
            {
                NativeMethods.cvSetCaptureProperty(ptr, CaptureProperty.XI_GpoMode, value);
            }
        }

#if LANG_JP
		/// <summary>
        /// Selects camera signalling LED 
		/// [CV_CAP_PROP_XI_LED_SELECTOR]
		/// </summary>
#else
        /// <summary>
        /// Selects camera signalling LED 
        /// [CV_CAP_PROP_XI_LED_SELECTOR]
        /// </summary>
#endif
        public double XI_LedSelector
        {
            get
            {
                return NativeMethods.cvGetCaptureProperty(ptr, CaptureProperty.XI_LedSelector);
            }
            set
            {
                NativeMethods.cvSetCaptureProperty(ptr, CaptureProperty.XI_LedSelector, value);
            }
        }

#if LANG_JP
		/// <summary>
        /// Define camera signalling LED functionality
		/// [CV_CAP_PROP_XI_LED_MODE]
		/// </summary>
#else
        /// <summary>
        /// Define camera signalling LED functionality
        /// [CV_CAP_PROP_XI_LED_MODE]
        /// </summary>
#endif
        public double XI_LedMode
        {
            get
            {
                return NativeMethods.cvGetCaptureProperty(ptr, CaptureProperty.XI_LedMode);
            }
            set
            {
                NativeMethods.cvSetCaptureProperty(ptr, CaptureProperty.XI_LedMode, value);
            }
        }

#if LANG_JP
		/// <summary>
        /// Calculates White Balance(must be called during acquisition)
		/// [CV_CAP_PROP_XI_MANUAL_WB]
		/// </summary>
#else
        /// <summary>
        /// Calculates White Balance(must be called during acquisition)
        /// [CV_CAP_PROP_XI_MANUAL_WB]
        /// </summary>
#endif
        public double XI_ManualWB
        {
            get
            {
                return NativeMethods.cvGetCaptureProperty(ptr, CaptureProperty.XI_ManualWB);
            }
            set
            {
                NativeMethods.cvSetCaptureProperty(ptr, CaptureProperty.XI_ManualWB, value);
            }
        }

#if LANG_JP
		/// <summary>
        /// Automatic white balance
		/// [CV_CAP_PROP_XI_AUTO_WB]
		/// </summary>
#else
        /// <summary>
        /// Automatic white balance
        /// [CV_CAP_PROP_XI_AUTO_WB]
        /// </summary>
#endif
        public double XI_AutoWB
        {
            get
            {
                return NativeMethods.cvGetCaptureProperty(ptr, CaptureProperty.XI_AutoWB);
            }
            set
            {
                NativeMethods.cvSetCaptureProperty(ptr, CaptureProperty.XI_AutoWB, value);
            }
        }

#if LANG_JP
		/// <summary>
        /// Automatic exposure/gain
		/// [CV_CAP_PROP_XI_AEAG]
		/// </summary>
#else
        /// <summary>
        /// Automatic exposure/gain
        /// [CV_CAP_PROP_XI_AEAG]
        /// </summary>
#endif
        public double XI_AEAG
        {
            get
            {
                return NativeMethods.cvGetCaptureProperty(ptr, CaptureProperty.XI_AEAG);
            }
            set
            {
                NativeMethods.cvSetCaptureProperty(ptr, CaptureProperty.XI_AEAG, value);
            }
        }

#if LANG_JP
		/// <summary>
        /// Exposure priority (0.5 - exposure 50%, gain 50%).
		/// [CV_CAP_PROP_XI_EXP_PRIORITY]
		/// </summary>
#else
        /// <summary>
        /// Exposure priority (0.5 - exposure 50%, gain 50%).
        /// [CV_CAP_PROP_XI_EXP_PRIORITY]
        /// </summary>
#endif
        public double XI_ExpPriority
        {
            get
            {
                return NativeMethods.cvGetCaptureProperty(ptr, CaptureProperty.XI_ExpPriority);
            }
            set
            {
                NativeMethods.cvSetCaptureProperty(ptr, CaptureProperty.XI_ExpPriority, value);
            }
        }

#if LANG_JP
		/// <summary>
        /// Maximum limit of exposure in AEAG procedure
		/// [CV_CAP_PROP_XI_AE_MAX_LIMIT]
		/// </summary>
#else
        /// <summary>
        /// Maximum limit of exposure in AEAG procedure
        /// [CV_CAP_PROP_XI_AE_MAX_LIMIT]
        /// </summary>
#endif
        public double XI_AEMaxLimit
        {
            get
            {
                return NativeMethods.cvGetCaptureProperty(ptr, CaptureProperty.XI_AEMaxLimit);
            }
            set
            {
                NativeMethods.cvSetCaptureProperty(ptr, CaptureProperty.XI_AEMaxLimit, value);
            }
        }

#if LANG_JP
		/// <summary>
        /// Maximum limit of gain in AEAG procedure
		/// [CV_CAP_PROP_XI_AG_MAX_LIMIT]
		/// </summary>
#else
        /// <summary>
        /// Maximum limit of gain in AEAG procedure
        /// [CV_CAP_PROP_XI_AG_MAX_LIMIT]
        /// </summary>
#endif
        public double XI_AGMaxLimit
        {
            get
            {
                return NativeMethods.cvGetCaptureProperty(ptr, CaptureProperty.XI_AGMaxLimit);
            }
            set
            {
                NativeMethods.cvSetCaptureProperty(ptr, CaptureProperty.XI_AGMaxLimit, value);
            }
        }

#if LANG_JP
		/// <summary>
        /// default is 1
		/// [CV_CAP_PROP_XI_AEAG_LEVEL]
		/// </summary>
#else
        /// <summary>
        /// default is 1
        /// [CV_CAP_PROP_XI_AEAG_LEVEL]
        /// </summary>
#endif
        public double XI_AEAGLevel
        {
            get
            {
                return NativeMethods.cvGetCaptureProperty(ptr, CaptureProperty.XI_AEAGLevel);
            }
            set
            {
                NativeMethods.cvSetCaptureProperty(ptr, CaptureProperty.XI_AEAGLevel, value);
            }
        }

#if LANG_JP
		/// <summary>
        /// default is 1
		/// [CV_CAP_PROP_XI_TIMEOUT]
		/// </summary>
#else
        /// <summary>
        /// default is 1
        /// [CV_CAP_PROP_XI_TIMEOUT]
        /// </summary>
#endif
        public double XI_Timeout
        {
            get
            {
                return NativeMethods.cvGetCaptureProperty(ptr, CaptureProperty.XI_Timeout);
            }
            set
            {
                NativeMethods.cvSetCaptureProperty(ptr, CaptureProperty.XI_Timeout, value);
            }
        }
// ReSharper restore InconsistentNaming
        #endregion
        #endregion

        #region Methods
        #region GetCaptureProperty
#if LANG_JP
        /// <summary>
        /// ビデオキャプチャのプロパティを取得する
        /// </summary>
        /// <param name="propertyId">プロパティID</param>
        /// <returns>プロパティの値</returns>
#else
        /// <summary>
        /// Retrieves the specified property of camera or video file. 
        /// </summary>
        /// <param name="propertyId">property identifier.</param>
        /// <returns>property value</returns>
#endif
        public double GetCaptureProperty(CaptureProperty propertyId)
        {
            return Cv.GetCaptureProperty(this, propertyId);
        }
#if LANG_JP
        /// <summary>
        /// ビデオキャプチャのプロパティを取得する
        /// </summary>
        /// <param name="propertyId">プロパティID</param>
        /// <returns>プロパティの値</returns>
#else
        /// <summary>
        /// Retrieves the specified property of camera or video file. 
        /// </summary>
        /// <param name="propertyId">property identifier.</param>
        /// <returns>property value</returns>
#endif
        public double GetCaptureProperty(int propertyId)
        {
            return Cv.GetCaptureProperty(this, propertyId);
        }
        #endregion
        #region GrabFrame
#if LANG_JP
        /// <summary>
        /// カメラやファイルからフレームを取り出す．取り出されたフレームは内部的に保存される．
        /// 取り出されたフレームをユーザ側で利用するためには，cvRetrieveFrame を用いるべきである．
        /// </summary>
        /// <returns></returns>
#else
        /// <summary>
        /// Grabs the frame from camera or file. The grabbed frame is stored internally. 
        /// The purpose of this function is to grab frame fast that is important for syncronization in case of reading from several cameras simultaneously. 
        /// The grabbed frames are not exposed because they may be stored in compressed format (as defined by camera/driver). 
        /// To retrieve the grabbed frame, cvRetrieveFrame should be used. 
        /// </summary>
        /// <returns></returns>
#endif
        public int GrabFrame()
        {
            return Cv.GrabFrame(this);
        }
        #endregion
        #region QueryFrame
#if LANG_JP
        /// <summary>
        /// カメラやビデオファイルから一つのフレームを取り出し，それを展開して返す．
        /// この関数は，単純にcvGrabFrame とcvRetrieveFrame をまとめて呼び出しているだけである．
        /// 返された画像は，ユーザが解放したり，変更したりするべきではない．
        /// </summary>
        /// <returns>1フレームの画像 (GC禁止フラグが立っている). キャプチャできなかった場合はnull.</returns>
#else
        /// <summary>
        /// Grabs a frame from camera or video file, decompresses and returns it. 
        /// This function is just a combination of cvGrabFrame and cvRetrieveFrame in one call. 
        /// The returned image should not be released or modified by user. 
        /// </summary>
        /// <returns></returns>
#endif
        public IplImage QueryFrame()
        {
            return Cv.QueryFrame(this);
        }
        #endregion
        #region RetrieveFrame
#if LANG_JP
        /// <summary>
        /// GrabFrame 関数によって取り出された画像への参照を返す．
        /// 返された画像は，ユーザが解放したり，変更したりするべきではない．
        /// </summary>
        /// <returns>1フレームの画像 (GC禁止フラグが立っている). キャプチャできなかった場合はnull.</returns>
#else
        /// <summary>
        /// Returns the pointer to the image grabbed with cvGrabFrame function. 
        /// The returned image should not be released or modified by user. 
        /// </summary>
        /// <returns></returns>
#endif
        public IplImage RetrieveFrame()
        {
            return Cv.RetrieveFrame(this);
        }
#if LANG_JP
        /// <summary>
        /// GrabFrame 関数によって取り出された画像への参照を返す．
        /// 返された画像は，ユーザが解放したり，変更したりするべきではない．
        /// </summary>
        /// <param name="streamIdx">non-zero streamIdx is only valid for multi-head camera live streams</param>
        /// <returns>1フレームの画像 (GC禁止フラグが立っている). キャプチャできなかった場合はnull.</returns>
#else
        /// <summary>
        /// Returns the pointer to the image grabbed with cvGrabFrame function. 
        /// The returned image should not be released or modified by user. 
        /// </summary>
        /// <param name="streamIdx">non-zero streamIdx is only valid for multi-head camera live streams</param>
        /// <returns></returns>
#endif
        public IplImage RetrieveFrame(int streamIdx)
        {
            return Cv.RetrieveFrame(this, streamIdx);
        }
#if LANG_JP
        /// <summary>
        /// GrabFrame 関数によって取り出された画像への参照を返す．
        /// 返された画像は，ユーザが解放したり，変更したりするべきではない．
        /// </summary>
        /// <param name="streamIdx">non-zero streamIdx is only valid for multi-head camera live streams</param>
        /// <returns>1フレームの画像 (GC禁止フラグが立っている). キャプチャできなかった場合はnull.</returns>
#else
        /// <summary>
        /// Returns the pointer to the image grabbed with cvGrabFrame function. 
        /// The returned image should not be released or modified by user. 
        /// </summary>
        /// <param name="streamIdx">non-zero streamIdx is only valid for multi-head camera live streams</param>
        /// <returns></returns>
#endif
        public IplImage RetrieveFrame(CameraChannels streamIdx)
        {
            return Cv.RetrieveFrame(this, streamIdx);
        }
        #endregion
        #region SetCaptureProperty
#if LANG_JP
        /// <summary>
        /// ビデオキャプチャのプロパティをセットする
        /// </summary>
        /// <param name="propertyId">プロパティID</param>
        /// <param name="value">プロパティの値</param>
        /// <returns></returns>
#else
        /// <summary>
        /// Sets the specified property of video capturing.
        /// </summary>
        /// <param name="propertyId">property identifier. </param>
        /// <param name="value">value of the property. </param>
        /// <returns></returns>
#endif
        public int SetCaptureProperty(CaptureProperty propertyId, double value)
        {
            return Cv.SetCaptureProperty(this, propertyId, value);
        }
#if LANG_JP
        /// <summary>
        /// ビデオキャプチャのプロパティをセットする
        /// </summary>
        /// <param name="propertyId">プロパティID</param>
        /// <param name="value">プロパティの値</param>
        /// <returns></returns>
#else
        /// <summary>
        /// Sets the specified property of video capturing.
        /// </summary>
        /// <param name="propertyId">property identifier. </param>
        /// <param name="value">value of the property. </param>
        /// <returns></returns>
#endif
        public int SetCaptureProperty(int propertyId, double value)
        {
            return Cv.SetCaptureProperty(this, propertyId, value);
        }
        #endregion
        #endregion

        /// <summary>
        /// Int32の各バイトにアクセスしやすくするための共用体
        /// </summary>
        [StructLayout(LayoutKind.Explicit)]
        private struct IntBytes
        {
            [FieldOffset(0)]
            public Int32 Value;
            [FieldOffset(0)]
            public readonly Byte B1;
            [FieldOffset(1)]
            public readonly Byte B2;
            [FieldOffset(2)]
            public readonly Byte B3;
            [FieldOffset(3)]
            public readonly Byte B4;
        }
    }
}
