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
    public class VideoCapture : DisposableCvObject
    {
#if LANG_JP
        /// <summary>
        /// キャプチャの種類 (File or Camera)
        /// </summary>
#else
        /// <summary>
        /// Capture type (File or Camera)
        /// </summary>
#endif
        private CaptureType captureType;

        #region Init and Disposal

#if LANG_JP
        /// <summary>
        /// 空の状態で初期化. 後でOpenが必要.
        /// </summary>
        /// <returns></returns>
#else
        /// <summary>
        /// Initializes empty capture.
        /// To use this, you should call Open. 
        /// </summary>
        /// <returns></returns>
#endif
        public VideoCapture()
        {
            try
            {
                ptr = NativeMethods.videoio_VideoCapture_new1();
            }
            catch (Exception e)
            {
                throw new OpenCvSharpException("Failed to create VideoCapture", e);
            }
            if (ptr == IntPtr.Zero)
                throw new OpenCvSharpException("Failed to create VideoCapture");
            
            captureType = CaptureType.NotSpecified;
        }

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
        public VideoCapture(int index)
        {
            try
            {
                ptr = NativeMethods.videoio_VideoCapture_new3(index);
            }
            catch (Exception e)
            {
                throw new OpenCvSharpException("Failed to create VideoCapture", e);
            }
            if (ptr == IntPtr.Zero)
            {
                throw new OpenCvSharpException("Failed to create VideoCapture");
            }
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
        public VideoCapture(CaptureDevice device)
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
        public VideoCapture(CaptureDevice device, int index)
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
        public static VideoCapture FromCamera(int index)
        {
            return new VideoCapture(index);
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
        public static VideoCapture FromCamera(CaptureDevice device)
        {
            return new VideoCapture(device);
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
        public static VideoCapture FromCamera(CaptureDevice device, int index)
        {
            return new VideoCapture((int)device + index);
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
        public VideoCapture(string fileName)
        {
            if (string.IsNullOrEmpty(fileName))
                throw new ArgumentNullException(nameof(fileName));
            /*if (!File.Exists(fileName))
                throw new FileNotFoundException("File not found", fileName);*/

            ptr = NativeMethods.videoio_VideoCapture_new2(fileName);

            if (ptr == IntPtr.Zero)
                throw new OpenCvSharpException("Failed to create VideoCapture");
            
            captureType = CaptureType.File;
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
        public static VideoCapture FromFile(string fileName)
        {
            return new VideoCapture(fileName);
        }

        /// <summary>
        /// Initializes from native pointer
        /// </summary>
        /// <param name="ptr">CvCapture*</param>
        protected internal VideoCapture(IntPtr ptr)
        {
            this.ptr = ptr;
        }

        /// <summary>
        /// Releases unmanaged resources
        /// </summary>
        protected override void DisposeUnmanaged()
        {
            NativeMethods.videoio_VideoCapture_delete(ptr);
            base.DisposeUnmanaged();
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
            get => (int)Get(CaptureProperty.PosMsec);
            set => Set(CaptureProperty.PosMsec, value);
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
            get => (int)Get(CaptureProperty.PosFrames);
            set
            {
                if (captureType == CaptureType.Camera)
                    throw new NotSupportedException("Only for video files");
                Set(CaptureProperty.PosFrames, value);
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
            get => (CapturePosAviRatio)(int)Get(CaptureProperty.PosAviRatio);
            set
            {
                if (captureType == CaptureType.Camera)
                    throw new NotSupportedException("Only for video files");
                Set(CaptureProperty.PosAviRatio, (int)value);
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
            get => (int)Get(CaptureProperty.FrameWidth);
            set
            {
                if (captureType == CaptureType.File)
                    throw new NotSupportedException("Only for cameras");
                Set(CaptureProperty.FrameWidth, value);
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
            get => (int)Get(CaptureProperty.FrameHeight);
            set
            {
                if (captureType == CaptureType.File)
                    throw new NotSupportedException("Only for cameras");
                Set(CaptureProperty.FrameHeight, value);
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
            get => Get(CaptureProperty.Fps);
            set
            {
                if (captureType == CaptureType.File)
                    throw new NotSupportedException("Only for cameras");
                Set(CaptureProperty.Fps, value);
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
                int src = (int)Get(CaptureProperty.FourCC);
                IntBytes bytes = new IntBytes { Value = src };
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
                int v = FourCCCalcurator.Run(c1, c2, c3, c4);
                Set(CaptureProperty.FourCC, v);
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
                return (int)Get(CaptureProperty.FrameCount);
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
                return (int)Get(CaptureProperty.Brightness);
            }
            set
            {
                if (captureType == CaptureType.File)
                    throw new NotSupportedException("Only for cameras");
                Set(CaptureProperty.Brightness, value);
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
                return (int)Get(CaptureProperty.Contrast);
            }
            set
            {
                if (captureType == CaptureType.File)
                    throw new NotSupportedException("Only for cameras");
                Set(CaptureProperty.Contrast, value);
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
                    throw new NotSupportedException("Only for cameras");
                return (int)Get(CaptureProperty.Saturation);
            }
            set
            {
                if (captureType == CaptureType.File)
                    throw new NotSupportedException("Only for cameras");
                Set(CaptureProperty.Saturation, value);
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
                    throw new NotSupportedException("Only for cameras");
                return (int)Get(CaptureProperty.Hue);
            }
            set
            {
                if (captureType == CaptureType.File)
                    throw new NotSupportedException("Only for cameras");
                Set(CaptureProperty.Hue, value);
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
            get => (int)Get(CaptureProperty.Format);
            set => Set(CaptureProperty.Format, value);
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
            get => (int)Get(CaptureProperty.Mode);
            set => Set(CaptureProperty.Mode, value);
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
                    throw new NotSupportedException("Only for cameras");
                return Get(CaptureProperty.Gain);
            }
            set
            {
                if (captureType == CaptureType.File)
                    throw new NotSupportedException("Only for cameras");
                Set(CaptureProperty.Gain, value);
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
                    throw new NotSupportedException("Only for cameras");
                return Get(CaptureProperty.Exposure);
            }
            set
            {
                if (captureType == CaptureType.File)
                    throw new NotSupportedException("Only for cameras");
                Set(CaptureProperty.Exposure, value);
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
            get => (int)Get(CaptureProperty.ConvertRgb) != 0;
            set => Set(CaptureProperty.ConvertRgb, value ? 0 : 1);
        }
        
        /// <summary>
        /// 
        /// </summary>
        public double WhiteBalanceBlueU
        {
            get => Get(CaptureProperty.WhiteBalanceBlueU);
            set => Set(CaptureProperty.WhiteBalanceBlueU, value);
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
            get => Get(CaptureProperty.Rectification);
            set => Set(CaptureProperty.Rectification, value);
        }
        
        /// <summary>
        /// 
        /// </summary>
        public double Monocrome
        {
            get => Get(CaptureProperty.Monocrome);
            set => Set(CaptureProperty.Monocrome, value);
        }

        /// <summary>
        /// 
        /// </summary>
        public double Sharpness
        {
            get => Get(CaptureProperty.Sharpness);
            set => Set(CaptureProperty.Sharpness, value);
        }

        /// <summary>
        /// exposure control done by camera,
        /// user can adjust refernce level using this feature
        /// [CV_CAP_PROP_AUTO_EXPOSURE]
        /// </summary>
        public double AutoExposure
        {
            get => Get(CaptureProperty.AutoExposure);
            set => Set(CaptureProperty.AutoExposure, value);
        }

        /// <summary>
        /// 
        /// </summary>
        public double Gamma
        {
            get => Get(CaptureProperty.Gamma);
            set => Set(CaptureProperty.Gamma, value);
        }

        /// <summary>
        /// 
        /// [CV_CAP_PROP_TEMPERATURE]
        /// </summary>
        public double Temperature
        {
            get => Get(CaptureProperty.Temperature);
            set => Set(CaptureProperty.Temperature, value);
        }

        /// <summary>
        /// 
        /// </summary>
        public double Trigger
        {
            get => Get(CaptureProperty.Trigger);
            set => Set(CaptureProperty.Trigger, value);
        }

        /// <summary>
        /// 
        /// </summary>
        public double TriggerDelay
        {
            get => Get(CaptureProperty.TriggerDelay);
            set => Set(CaptureProperty.TriggerDelay, value);
        }

        /// <summary>
        /// 
        /// </summary>
        public double WhiteBalanceRedV
        {
            get => Get(CaptureProperty.WhiteBalanceRedV);
            set => Set(CaptureProperty.WhiteBalanceRedV, value);
        }

        /// <summary>
        /// 
        /// </summary>
        public double Zoom
        {
            get => Get(CaptureProperty.Zoom);
            set => Set(CaptureProperty.Zoom, value);
        }

        /// <summary>
        /// 
        /// </summary>
        public double Focus
        {
            get => Get(CaptureProperty.Focus);
            set => Set(CaptureProperty.Focus, value);
        }

        /// <summary>
        /// 
        /// </summary>
        public double Guid
        {
            get => Get(CaptureProperty.Guid);
            set => Set(CaptureProperty.Guid, value);
        }

        /// <summary>
        /// 
        /// </summary>
        public double IsoSpeed
        {
            get => Get(CaptureProperty.IsoSpeed);
            set => Set(CaptureProperty.IsoSpeed, value);
        }

        /// <summary>
        /// 
        /// </summary>
        public double BackLight
        {
            get => Get(CaptureProperty.BackLight);
            set => Set(CaptureProperty.BackLight, value);
        }

        /// <summary>
        /// 
        /// </summary>
        public double Pan
        {
            get => Get(CaptureProperty.Pan);
            set => Set(CaptureProperty.Pan, value);
        }

        /// <summary>
        /// 
        /// </summary>
        public double Tilt
        {
            get => Get(CaptureProperty.Tilt);
            set => Set(CaptureProperty.Tilt, value);
        }

        /// <summary>
        /// 
        /// </summary>
        public double Roll
        {
            get => Get(CaptureProperty.Roll);
            set => Set(CaptureProperty.Roll, value);
        }

        /// <summary>
        /// 
        /// </summary>
        public double Iris
        {
            get => Get(CaptureProperty.Iris);
            set => Set(CaptureProperty.Iris, value);
        }

        /// <summary>
        /// 
        /// </summary>
        public double Settings
        {
            get => Get(CaptureProperty.Settings);
            set => Set(CaptureProperty.Settings, value);
        }

        /// <summary>
        /// 
        /// </summary>
        public double BufferSize
        {
            get => Get(CaptureProperty.BufferSize);
            set => Set(CaptureProperty.BufferSize, value);
        }

        /// <summary>
        /// 
        /// </summary>
        public bool AutoFocus
        {
            get => (int)Get(CaptureProperty.AutoFocus) != 0;
            set => Set(CaptureProperty.AutoFocus, value ? 1 : 0);
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
            get => Get(CaptureProperty.OpenNI_OutputMode);
            set => Set(CaptureProperty.OpenNI_OutputMode, value);
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
            get => Get(CaptureProperty.OpenNI_FrameMaxDepth);
            set => Set(CaptureProperty.OpenNI_FrameMaxDepth, value);
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
            get => Get(CaptureProperty.OpenNI_Baseline);
            set => Set(CaptureProperty.OpenNI_Baseline, value);
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
            get => Get(CaptureProperty.OpenNI_FocalLength);
            set => Set(CaptureProperty.OpenNI_FocalLength, value);
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
        public double OpenNI_Registration
        {
            get => Get(CaptureProperty.OpenNI_Registration);
            set => Set(CaptureProperty.OpenNI_Registration, value);
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
            get => Get(CaptureProperty.OpenNI_ImageGeneratorOutputMode);
            set => Set(CaptureProperty.OpenNI_ImageGeneratorOutputMode, value);
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
            get => Get(CaptureProperty.OpenNI_DepthGeneratorBaseline);
            set => Set(CaptureProperty.OpenNI_DepthGeneratorBaseline, value);
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
            get => Get(CaptureProperty.OpenNI_DepthGeneratorFocalLength);
            set => Set(CaptureProperty.OpenNI_DepthGeneratorFocalLength, value);
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
            get => Get(CaptureProperty.OpenNI_DepthGeneratorRegistrationON);
            set => Set(CaptureProperty.OpenNI_DepthGeneratorRegistrationON, value);
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
            get => Get(CaptureProperty.GStreamerQueueLength);
            set => Set(CaptureProperty.GStreamerQueueLength, value);
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
            get => Get(CaptureProperty.PvAPIMulticastIP);
            set => Set(CaptureProperty.PvAPIMulticastIP, value);
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
            get => Get(CaptureProperty.XI_Downsampling);
            set => Set(CaptureProperty.XI_Downsampling, value);
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
                return Get(CaptureProperty.XI_DataFormat);
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
            get => Get(CaptureProperty.XI_OffsetX);
            set => Set(CaptureProperty.XI_OffsetX, value);
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
            get => Get(CaptureProperty.XI_OffsetY);
            set => Set(CaptureProperty.XI_OffsetY, value);
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
            get => Get(CaptureProperty.XI_TrgSource);
            set => Set(CaptureProperty.XI_TrgSource, value);
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
            get => Get(CaptureProperty.XI_TrgSoftware);
            set => Set(CaptureProperty.XI_TrgSoftware, value);
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
            get => Get(CaptureProperty.XI_GpiSelector);
            set => Set(CaptureProperty.XI_GpiSelector, value);
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
            get => Get(CaptureProperty.XI_GpiMode);
            set => Set(CaptureProperty.XI_GpiMode, value);
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
            get => Get(CaptureProperty.XI_GpiLevel);
            set => Set(CaptureProperty.XI_GpiLevel, value);
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
            get => Get(CaptureProperty.XI_GpoSelector);
            set => Set(CaptureProperty.XI_GpoSelector, value);
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
            get => Get(CaptureProperty.XI_GpoMode);
            set => Set(CaptureProperty.XI_GpoMode, value);
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
            get => Get(CaptureProperty.XI_LedSelector);
            set => Set(CaptureProperty.XI_LedSelector, value);
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
            get => Get(CaptureProperty.XI_LedMode);
            set => Set(CaptureProperty.XI_LedMode, value);
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
            get => Get(CaptureProperty.XI_ManualWB);
            set => Set(CaptureProperty.XI_ManualWB, value);
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
            get => Get(CaptureProperty.XI_AutoWB);
            set => Set(CaptureProperty.XI_AutoWB, value);
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
            get => Get(CaptureProperty.XI_AEAG);
            set => Set(CaptureProperty.XI_AEAG, value);
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
            get => Get(CaptureProperty.XI_ExpPriority);
            set => Set(CaptureProperty.XI_ExpPriority, value);
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
            get => Get(CaptureProperty.XI_AEMaxLimit);
            set => Set(CaptureProperty.XI_AEMaxLimit, value);
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
            get => Get(CaptureProperty.XI_AGMaxLimit);
            set => Set(CaptureProperty.XI_AGMaxLimit, value);
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
            get => Get(CaptureProperty.XI_AEAGLevel);
            set => Set(CaptureProperty.XI_AEAGLevel, value);
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
            get => Get(CaptureProperty.XI_Timeout);
            set => Set(CaptureProperty.XI_Timeout, value);
        }
// ReSharper restore InconsistentNaming
        #endregion
        #endregion

        #region Methods
        #region Get
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
        public double Get(CaptureProperty propertyId)
        {
            var res = NativeMethods.videoio_VideoCapture_get(ptr, (int)propertyId);
            GC.KeepAlive(this);
            return res;
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
        public double Get(int propertyId)
        {
            var res = NativeMethods.videoio_VideoCapture_get(ptr, propertyId);
            GC.KeepAlive(this);
            return res;
        }
        #endregion
        #region Grab
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
        public bool Grab()
        {
            ThrowIfDisposed();
            var res = NativeMethods.videoio_VideoCapture_grab(ptr) != 0;
            GC.KeepAlive(this);
            return res;
        }
        #endregion
        #region Retrieve
#if LANG_JP
        /// <summary>
        /// GrabFrame 関数によって取り出された画像への参照を返す．
        /// </summary>
        /// <param name="image"></param>
        /// <param name="channel">non-zero streamIdx is only valid for multi-head camera live streams</param>
        /// <returns>1フレームの画像 (GC禁止フラグが立っている). キャプチャできなかった場合はnull.</returns>
#else
        /// <summary>
        /// Decodes and returns the grabbed video frame.
        /// </summary>
        /// <param name="image"></param>
        /// <param name="channel">non-zero streamIdx is only valid for multi-head camera live streams</param>
        /// <returns></returns>
#endif
        public bool Retrieve(Mat image, int channel = 0)
        {
            ThrowIfDisposed();
            if (image == null)
                throw new ArgumentNullException(nameof(image));
            image.ThrowIfDisposed();
            var res = NativeMethods.videoio_VideoCapture_retrieve(ptr, image.CvPtr, channel) != 0;
            GC.KeepAlive(this);
            GC.KeepAlive(image);
            return res;
        }

#if LANG_JP
        /// <summary>
        /// GrabFrame 関数によって取り出された画像への参照を返す．
        /// 返された画像は，ユーザが解放したり，変更したりするべきではない．
        /// </summary>
        /// <param name="image"></param>
        /// <param name="streamIdx">non-zero streamIdx is only valid for multi-head camera live streams</param>
        /// <returns>1フレームの画像 (GC禁止フラグが立っている). キャプチャできなかった場合はnull.</returns>
#else
        /// <summary>
        /// Returns the pointer to the image grabbed with cvGrabFrame function. 
        /// The returned image should not be released or modified by user. 
        /// </summary>
        /// <param name="image"></param>
        /// <param name="streamIdx">non-zero streamIdx is only valid for multi-head camera live streams</param>
        /// <returns></returns>
#endif
        public bool Retrieve(Mat image, CameraChannels streamIdx = CameraChannels.OpenNI_DepthMap)
        {
            ThrowIfDisposed();
            if (image == null)
                throw new ArgumentNullException(nameof(image));
            image.ThrowIfDisposed();
            var res = NativeMethods.videoio_VideoCapture_retrieve(ptr, image.CvPtr, (int)streamIdx) != 0;
            GC.KeepAlive(this);
            GC.KeepAlive(image);
            return res;
        }

#if LANG_JP
        /// <summary>
        /// GrabFrame 関数によって取り出された画像への参照を返す．
        /// </summary>
#else
        /// <summary>
        /// Decodes and returns the grabbed video frame.
        /// </summary>
        /// <returns></returns>
#endif
        public Mat RetrieveMat()
        {
            ThrowIfDisposed();

            var mat = new Mat();
            NativeMethods.videoio_VideoCapture_operatorRightShift_Mat(ptr, mat.CvPtr);
            GC.KeepAlive(this);
            return mat;
        }

        #endregion
        #region Read
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
        public bool Read(Mat image)
        {
            ThrowIfDisposed();
            if(image == null)
                throw new ArgumentNullException(nameof(image));
            image.ThrowIfDisposed();
            
            //NativeMethods.videoio_VideoCapture_read(ptr, image.CvPtr);
            /*
            bool grabbed = NativeMethods.videoio_VideoCapture_grab(ptr) != 0;
            if (!grabbed)
                return false;
            */
            NativeMethods.videoio_VideoCapture_operatorRightShift_Mat(ptr, image.CvPtr);
            GC.KeepAlive(this);
            GC.KeepAlive(image);
            return true;
        }
        #endregion
        #region Set
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
        public int Set(CaptureProperty propertyId, double value)
        {
            var res = NativeMethods.videoio_VideoCapture_set(ptr, (int)propertyId, value);
            GC.KeepAlive(this);
            return res;
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
        public int Set(int propertyId, double value)
        {
            var res = NativeMethods.videoio_VideoCapture_set(ptr, propertyId, value);
            GC.KeepAlive(this);
            return res;
        }
        #endregion
        #region Open
#if LANG_JP
        /// <summary>
        /// 指定されたビデオファイルをオープンします．
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
#else
        /// <summary>
        /// Opens the specified video file
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
#endif
        public void Open(string fileName)
        {
            ThrowIfDisposed();
            NativeMethods.videoio_VideoCapture_open1(ptr, fileName);
            captureType = CaptureType.File;
        }

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
        public void Open(int index)
        {
            ThrowIfDisposed();
            try
            {
                NativeMethods.videoio_VideoCapture_open2(ptr, index);
            }
            catch (Exception e)
            {
                throw new OpenCvSharpException("Failed to create CvCapture", e);
            }
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
        public void Open(CaptureDevice device)
        {
            Open((int)device);
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
        public void Open(CaptureDevice device, int index)
        {
            Open((int)device + index);
        }
        #endregion
        #region Release
#if LANG_JP
        /// <summary>
        /// Closes video file or capturing device.
        /// </summary>
        /// <returns></returns>
#else
        /// <summary>
        /// Closes video file or capturing device.
        /// </summary>
        /// <returns></returns>
#endif
        public void Release()
        {
            ThrowIfDisposed();
            NativeMethods.videoio_VideoCapture_release(ptr);
        }
        #endregion
        #region IsOpened
        /// <summary>
        /// Returns true if video capturing has been initialized already.
        /// </summary>
        /// <returns></returns>
        public bool IsOpened()
        {
            ThrowIfDisposed();
            var res = NativeMethods.videoio_VideoCapture_isOpened(ptr) != 0;
            GC.KeepAlive(this);
            return res;
        }
        #endregion
        #endregion

        /// <summary>
        /// For accessing each byte of Int32 value
        /// </summary>
        [StructLayout(LayoutKind.Explicit)]
        private struct IntBytes
        {
            [FieldOffset(0)]
            public int Value;
            [FieldOffset(0)]
            public readonly byte B1;
            [FieldOffset(1)]
            public readonly byte B2;
            [FieldOffset(2)]
            public readonly byte B3;
            [FieldOffset(3)]
            public readonly byte B4;
        }
    }
}
