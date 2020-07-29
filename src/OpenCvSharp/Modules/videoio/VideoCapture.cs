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
            NativeMethods.HandleException(
                NativeMethods.videoio_VideoCapture_new1(out ptr));
            
            if (ptr == IntPtr.Zero)
                throw new OpenCvSharpException("Failed to create VideoCapture");
            
            captureType = CaptureType.NotSpecified;
        }

        /// <summary>
        /// Opens a camera for video capturing
        /// </summary>
        /// <param name="index">id of the video capturing device to open. To open default camera using default backend just pass 0.
        /// (to backward compatibility usage of camera_id + domain_offset (CAP_*) is valid when apiPreference is CAP_ANY)</param>
        /// <param name="apiPreference">preferred Capture API backends to use. Can be used to enforce a specific reader implementation
        /// if multiple are available: e.g. cv::CAP_DSHOW or cv::CAP_MSMF or cv::CAP_V4L.</param>
        /// <returns></returns>
        public VideoCapture(int index, VideoCaptureAPIs apiPreference = VideoCaptureAPIs.ANY)
        {
            NativeMethods.HandleException(
                NativeMethods.videoio_VideoCapture_new3(index, (int) apiPreference, out ptr));
 
            if (ptr == IntPtr.Zero)
                throw new OpenCvSharpException("Failed to create VideoCapture");
            
            captureType = CaptureType.Camera;
        }

        /// <summary>
        /// Opens a camera for video capturing
        /// </summary>
        /// <param name="index">id of the video capturing device to open. To open default camera using default backend just pass 0.
        /// (to backward compatibility usage of camera_id + domain_offset (CAP_*) is valid when apiPreference is CAP_ANY)</param>
        /// <param name="apiPreference">preferred Capture API backends to use. Can be used to enforce a specific reader implementation
        /// if multiple are available: e.g. cv::CAP_DSHOW or cv::CAP_MSMF or cv::CAP_V4L.</param>
        /// <returns></returns>
        public static VideoCapture FromCamera(int index, VideoCaptureAPIs apiPreference = VideoCaptureAPIs.ANY)
        {
            return new VideoCapture(index, apiPreference);
        }

        /// <summary>
        /// Opens a video file or a capturing device or an IP video stream for video capturing with API Preference
        /// </summary>
        /// <param name="fileName">it can be:
        /// - name of video file (eg. `video.avi`)
        /// - or image sequence (eg. `img_%02d.jpg`, which will read samples like `img_00.jpg, img_01.jpg, img_02.jpg, ...`)
        /// - or URL of video stream (eg. `protocol://host:port/script_name?script_params|auth`).
        /// Note that each video stream or IP camera feed has its own URL scheme. Please refer to the
        /// documentation of source stream to know the right URL.</param>
        /// <param name="apiPreference">apiPreference preferred Capture API backends to use. Can be used to enforce a specific reader
        /// implementation if multiple are available: e.g. cv::CAP_FFMPEG or cv::CAP_IMAGES or cv::CAP_DSHOW.</param>
        /// <returns></returns>
        public VideoCapture(string fileName, VideoCaptureAPIs apiPreference = VideoCaptureAPIs.ANY)
        {
            if (string.IsNullOrEmpty(fileName))
                throw new ArgumentNullException(nameof(fileName));

            NativeMethods.HandleException(
                NativeMethods.videoio_VideoCapture_new2(fileName, (int)apiPreference, out ptr));

            if (ptr == IntPtr.Zero)
                throw new OpenCvSharpException("Failed to create VideoCapture");
            
            captureType = CaptureType.File;
        }

        /// <summary>
        /// Opens a video file or a capturing device or an IP video stream for video capturing with API Preference
        /// </summary>
        /// <param name="fileName">it can be:
        /// - name of video file (eg. `video.avi`)
        /// - or image sequence (eg. `img_%02d.jpg`, which will read samples like `img_00.jpg, img_01.jpg, img_02.jpg, ...`)
        /// - or URL of video stream (eg. `protocol://host:port/script_name?script_params|auth`).
        /// Note that each video stream or IP camera feed has its own URL scheme. Please refer to the
        /// documentation of source stream to know the right URL.</param>
        /// <param name="apiPreference">apiPreference preferred Capture API backends to use. Can be used to enforce a specific reader
        /// implementation if multiple are available: e.g. cv::CAP_FFMPEG or cv::CAP_IMAGES or cv::CAP_DSHOW.</param>
        /// <returns></returns>
        public static VideoCapture FromFile(string fileName, VideoCaptureAPIs apiPreference = VideoCaptureAPIs.ANY)
        {
            return new VideoCapture(fileName, apiPreference);
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
            NativeMethods.HandleException(
                NativeMethods.videoio_VideoCapture_delete(ptr));
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
            get => (int)Get(VideoCaptureProperties.PosMsec);
            set => Set(VideoCaptureProperties.PosMsec, value);
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
            get => (int)Get(VideoCaptureProperties.PosFrames);
            set
            {
                if (captureType == CaptureType.Camera)
                    throw new NotSupportedException("Only for video files");
                Set(VideoCaptureProperties.PosFrames, value);
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
            get => (CapturePosAviRatio)(int)Get(VideoCaptureProperties.PosAviRatio);
            set
            {
                if (captureType == CaptureType.Camera)
                    throw new NotSupportedException("Only for video files");
                Set(VideoCaptureProperties.PosAviRatio, (int)value);
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
            get => (int)Get(VideoCaptureProperties.FrameWidth);
            set
            {
                if (captureType == CaptureType.File)
                    throw new NotSupportedException("Only for cameras");
                Set(VideoCaptureProperties.FrameWidth, value);
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
            get => (int)Get(VideoCaptureProperties.FrameHeight);
            set
            {
                if (captureType == CaptureType.File)
                    throw new NotSupportedException("Only for cameras");
                Set(VideoCaptureProperties.FrameHeight, value);
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
            get => Get(VideoCaptureProperties.Fps);
            set
            {
                if (captureType == CaptureType.File)
                    throw new NotSupportedException("Only for cameras");
                Set(VideoCaptureProperties.Fps, value);
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
                var src = (int)Get(VideoCaptureProperties.FourCC);
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
                var v = OpenCvSharp.FourCC.FromString(value);
                Set(VideoCaptureProperties.FourCC, v.Value);
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
                return (int)Get(VideoCaptureProperties.FrameCount);
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
                return (int)Get(VideoCaptureProperties.Brightness);
            }
            set
            {
                if (captureType == CaptureType.File)
                    throw new NotSupportedException("Only for cameras");
                Set(VideoCaptureProperties.Brightness, value);
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
                return (int)Get(VideoCaptureProperties.Contrast);
            }
            set
            {
                if (captureType == CaptureType.File)
                    throw new NotSupportedException("Only for cameras");
                Set(VideoCaptureProperties.Contrast, value);
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
                return (int)Get(VideoCaptureProperties.Saturation);
            }
            set
            {
                if (captureType == CaptureType.File)
                    throw new NotSupportedException("Only for cameras");
                Set(VideoCaptureProperties.Saturation, value);
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
                return (int)Get(VideoCaptureProperties.Hue);
            }
            set
            {
                if (captureType == CaptureType.File)
                    throw new NotSupportedException("Only for cameras");
                Set(VideoCaptureProperties.Hue, value);
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
            get => (int)Get(VideoCaptureProperties.Format);
            set => Set(VideoCaptureProperties.Format, value);
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
            get => (int)Get(VideoCaptureProperties.Mode);
            set => Set(VideoCaptureProperties.Mode, value);
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
                return Get(VideoCaptureProperties.Gain);
            }
            set
            {
                if (captureType == CaptureType.File)
                    throw new NotSupportedException("Only for cameras");
                Set(VideoCaptureProperties.Gain, value);
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
                return Get(VideoCaptureProperties.Exposure);
            }
            set
            {
                if (captureType == CaptureType.File)
                    throw new NotSupportedException("Only for cameras");
                Set(VideoCaptureProperties.Exposure, value);
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
            get => (int)Get(VideoCaptureProperties.ConvertRgb) != 0;
            set => Set(VideoCaptureProperties.ConvertRgb, value ? 1 : 0);
        }
        
        /// <summary>
        /// 
        /// </summary>
        public double WhiteBalanceBlueU
        {
            get => Get(VideoCaptureProperties.WhiteBalanceBlueU);
            set => Set(VideoCaptureProperties.WhiteBalanceBlueU, value);
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
            get => Get(VideoCaptureProperties.Rectification);
            set => Set(VideoCaptureProperties.Rectification, value);
        }
        
        /// <summary>
        /// 
        /// </summary>
        public double Monocrome
        {
            get => Get(VideoCaptureProperties.Monocrome);
            set => Set(VideoCaptureProperties.Monocrome, value);
        }

        /// <summary>
        /// 
        /// </summary>
        public double Sharpness
        {
            get => Get(VideoCaptureProperties.Sharpness);
            set => Set(VideoCaptureProperties.Sharpness, value);
        }

        /// <summary>
        /// exposure control done by camera,
        /// user can adjust refernce level using this feature
        /// [CV_CAP_PROP_AUTO_EXPOSURE]
        /// </summary>
        public double AutoExposure
        {
            get => Get(VideoCaptureProperties.AutoExposure);
            set => Set(VideoCaptureProperties.AutoExposure, value);
        }

        /// <summary>
        /// 
        /// </summary>
        public double Gamma
        {
            get => Get(VideoCaptureProperties.Gamma);
            set => Set(VideoCaptureProperties.Gamma, value);
        }

        /// <summary>
        /// 
        /// [CV_CAP_PROP_TEMPERATURE]
        /// </summary>
        public double Temperature
        {
            get => Get(VideoCaptureProperties.Temperature);
            set => Set(VideoCaptureProperties.Temperature, value);
        }

        /// <summary>
        /// 
        /// </summary>
        public double Trigger
        {
            get => Get(VideoCaptureProperties.Trigger);
            set => Set(VideoCaptureProperties.Trigger, value);
        }

        /// <summary>
        /// 
        /// </summary>
        public double TriggerDelay
        {
            get => Get(VideoCaptureProperties.TriggerDelay);
            set => Set(VideoCaptureProperties.TriggerDelay, value);
        }

        /// <summary>
        /// 
        /// </summary>
        public double WhiteBalanceRedV
        {
            get => Get(VideoCaptureProperties.WhiteBalanceRedV);
            set => Set(VideoCaptureProperties.WhiteBalanceRedV, value);
        }

        /// <summary>
        /// 
        /// </summary>
        public double Zoom
        {
            get => Get(VideoCaptureProperties.Zoom);
            set => Set(VideoCaptureProperties.Zoom, value);
        }

        /// <summary>
        /// 
        /// </summary>
        public double Focus
        {
            get => Get(VideoCaptureProperties.Focus);
            set => Set(VideoCaptureProperties.Focus, value);
        }

        /// <summary>
        /// 
        /// </summary>
        public double Guid
        {
            get => Get(VideoCaptureProperties.Guid);
            set => Set(VideoCaptureProperties.Guid, value);
        }

        /// <summary>
        /// 
        /// </summary>
        public double IsoSpeed
        {
            get => Get(VideoCaptureProperties.IsoSpeed);
            set => Set(VideoCaptureProperties.IsoSpeed, value);
        }

        /// <summary>
        /// 
        /// </summary>
        public double BackLight
        {
            get => Get(VideoCaptureProperties.BackLight);
            set => Set(VideoCaptureProperties.BackLight, value);
        }

        /// <summary>
        /// 
        /// </summary>
        public double Pan
        {
            get => Get(VideoCaptureProperties.Pan);
            set => Set(VideoCaptureProperties.Pan, value);
        }

        /// <summary>
        /// 
        /// </summary>
        public double Tilt
        {
            get => Get(VideoCaptureProperties.Tilt);
            set => Set(VideoCaptureProperties.Tilt, value);
        }

        /// <summary>
        /// 
        /// </summary>
        public double Roll
        {
            get => Get(VideoCaptureProperties.Roll);
            set => Set(VideoCaptureProperties.Roll, value);
        }

        /// <summary>
        /// 
        /// </summary>
        public double Iris
        {
            get => Get(VideoCaptureProperties.Iris);
            set => Set(VideoCaptureProperties.Iris, value);
        }

        /// <summary>
        /// 
        /// </summary>
        public double Settings
        {
            get => Get(VideoCaptureProperties.Settings);
            set => Set(VideoCaptureProperties.Settings, value);
        }

        /// <summary>
        /// 
        /// </summary>
        public double BufferSize
        {
            get => Get(VideoCaptureProperties.BufferSize);
            set => Set(VideoCaptureProperties.BufferSize, value);
        }

        /// <summary>
        /// 
        /// </summary>
        public bool AutoFocus
        {
            get => (int)Get(VideoCaptureProperties.AutoFocus) != 0;
            set => Set(VideoCaptureProperties.AutoFocus, value ? 1 : 0);
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
            get => Get(VideoCaptureProperties.OpenNI_OutputMode);
            set => Set(VideoCaptureProperties.OpenNI_OutputMode, value);
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
            get => Get(VideoCaptureProperties.OpenNI_FrameMaxDepth);
            set => Set(VideoCaptureProperties.OpenNI_FrameMaxDepth, value);
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
            get => Get(VideoCaptureProperties.OpenNI_Baseline);
            set => Set(VideoCaptureProperties.OpenNI_Baseline, value);
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
            get => Get(VideoCaptureProperties.OpenNI_FocalLength);
            set => Set(VideoCaptureProperties.OpenNI_FocalLength, value);
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
            get => Get(VideoCaptureProperties.OpenNI_Registration);
            set => Set(VideoCaptureProperties.OpenNI_Registration, value);
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
            get => Get(VideoCaptureProperties.OpenNI_ImageGeneratorOutputMode);
            set => Set(VideoCaptureProperties.OpenNI_ImageGeneratorOutputMode, value);
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
            get => Get(VideoCaptureProperties.OpenNI_DepthGeneratorBaseline);
            set => Set(VideoCaptureProperties.OpenNI_DepthGeneratorBaseline, value);
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
            get => Get(VideoCaptureProperties.OpenNI_DepthGeneratorFocalLength);
            set => Set(VideoCaptureProperties.OpenNI_DepthGeneratorFocalLength, value);
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
            get => Get(VideoCaptureProperties.OpenNI_DepthGeneratorRegistrationON);
            set => Set(VideoCaptureProperties.OpenNI_DepthGeneratorRegistrationON, value);
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
            get => Get(VideoCaptureProperties.GStreamerQueueLength);
            set => Set(VideoCaptureProperties.GStreamerQueueLength, value);
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
            get => Get(VideoCaptureProperties.PvAPIMulticastIP);
            set => Set(VideoCaptureProperties.PvAPIMulticastIP, value);
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
            get => Get(VideoCaptureProperties.XI_Downsampling);
            set => Set(VideoCaptureProperties.XI_Downsampling, value);
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
                return Get(VideoCaptureProperties.XI_DataFormat);
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
            get => Get(VideoCaptureProperties.XI_OffsetX);
            set => Set(VideoCaptureProperties.XI_OffsetX, value);
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
            get => Get(VideoCaptureProperties.XI_OffsetY);
            set => Set(VideoCaptureProperties.XI_OffsetY, value);
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
            get => Get(VideoCaptureProperties.XI_TrgSource);
            set => Set(VideoCaptureProperties.XI_TrgSource, value);
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
            get => Get(VideoCaptureProperties.XI_TrgSoftware);
            set => Set(VideoCaptureProperties.XI_TrgSoftware, value);
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
            get => Get(VideoCaptureProperties.XI_GpiSelector);
            set => Set(VideoCaptureProperties.XI_GpiSelector, value);
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
            get => Get(VideoCaptureProperties.XI_GpiMode);
            set => Set(VideoCaptureProperties.XI_GpiMode, value);
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
            get => Get(VideoCaptureProperties.XI_GpiLevel);
            set => Set(VideoCaptureProperties.XI_GpiLevel, value);
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
            get => Get(VideoCaptureProperties.XI_GpoSelector);
            set => Set(VideoCaptureProperties.XI_GpoSelector, value);
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
            get => Get(VideoCaptureProperties.XI_GpoMode);
            set => Set(VideoCaptureProperties.XI_GpoMode, value);
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
            get => Get(VideoCaptureProperties.XI_LedSelector);
            set => Set(VideoCaptureProperties.XI_LedSelector, value);
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
            get => Get(VideoCaptureProperties.XI_LedMode);
            set => Set(VideoCaptureProperties.XI_LedMode, value);
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
            get => Get(VideoCaptureProperties.XI_ManualWB);
            set => Set(VideoCaptureProperties.XI_ManualWB, value);
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
            get => Get(VideoCaptureProperties.XI_AutoWB);
            set => Set(VideoCaptureProperties.XI_AutoWB, value);
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
            get => Get(VideoCaptureProperties.XI_AEAG);
            set => Set(VideoCaptureProperties.XI_AEAG, value);
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
            get => Get(VideoCaptureProperties.XI_ExpPriority);
            set => Set(VideoCaptureProperties.XI_ExpPriority, value);
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
            get => Get(VideoCaptureProperties.XI_AEMaxLimit);
            set => Set(VideoCaptureProperties.XI_AEMaxLimit, value);
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
            get => Get(VideoCaptureProperties.XI_AGMaxLimit);
            set => Set(VideoCaptureProperties.XI_AGMaxLimit, value);
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
            get => Get(VideoCaptureProperties.XI_AEAGLevel);
            set => Set(VideoCaptureProperties.XI_AEAGLevel, value);
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
            get => Get(VideoCaptureProperties.XI_Timeout);
            set => Set(VideoCaptureProperties.XI_Timeout, value);
        }
// ReSharper restore InconsistentNaming
        #endregion
        #endregion

        #region Methods

        /// <summary>
        /// Opens a video file or a capturing device or an IP video stream for video capturing.
        /// </summary>
        /// <param name="fileName">it can be:
        /// - name of video file (eg. `video.avi`)
        /// - or image sequence (eg. `img_%02d.jpg`, which will read samples like `img_00.jpg, img_01.jpg, img_02.jpg, ...`)
        /// - or URL of video stream (eg. `protocol://host:port/script_name?script_params|auth`).
        /// Note that each video stream or IP camera feed has its own URL scheme. Please refer to the
        /// documentation of source stream to know the right URL.</param>
        /// <param name="apiPreference">apiPreference preferred Capture API backends to use. Can be used to enforce a specific reader
        /// implementation if multiple are available: e.g. cv::CAP_FFMPEG or cv::CAP_IMAGES or cv::CAP_DSHOW.</param>
        /// <returns>`true` if the file has been successfully opened</returns>
        public bool Open(string fileName, VideoCaptureAPIs apiPreference = VideoCaptureAPIs.ANY)
        {
            ThrowIfDisposed();

            NativeMethods.HandleException(
                NativeMethods.videoio_VideoCapture_open1(ptr, fileName, (int)apiPreference, out var ret));

            GC.KeepAlive(this);
            if (ret == 0) 
                return false;

            captureType = CaptureType.File;
            return true;
        }

        /// <summary>
        /// Opens a camera for video capturing
        /// </summary>
        /// <param name="index">id of the video capturing device to open. To open default camera using default backend just pass 0.
        /// (to backward compatibility usage of camera_id + domain_offset (CAP_*) is valid when apiPreference is CAP_ANY)</param>
        /// <param name="apiPreference">preferred Capture API backends to use. Can be used to enforce a specific reader implementation
        /// if multiple are available: e.g. cv::CAP_DSHOW or cv::CAP_MSMF or cv::CAP_V4L.</param>
        /// <returns>`true` if the file has been successfully opened</returns>
        public bool Open(int index, VideoCaptureAPIs apiPreference = VideoCaptureAPIs.ANY)
        {
            ThrowIfDisposed();

            NativeMethods.HandleException(
                NativeMethods.videoio_VideoCapture_open2(ptr, index, (int)apiPreference, out var ret));

            GC.KeepAlive(this);
            if (ret == 0) 
                return false;

            captureType = CaptureType.Camera;
            return true;
        }

        /// <summary>
        /// Returns true if video capturing has been initialized already.
        /// </summary>
        /// <returns></returns>
        public bool IsOpened()
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.videoio_VideoCapture_isOpened(ptr, out var ret));
            GC.KeepAlive(this);
            return ret != 0;
        }

        /// <summary>
        /// Closes video file or capturing device.
        /// </summary>
        /// <returns></returns>
        public void Release()
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.videoio_VideoCapture_release(ptr));
        }

        /// <summary>
        /// Grabs the next frame from video file or capturing device.
        ///
        /// The method/function grabs the next frame from video file or camera and returns true (non-zero) in the case of success.
        ///
        /// The primary use of the function is in multi-camera environments, especially when the cameras do not
        /// have hardware synchronization. That is, you call VideoCapture::grab() for each camera and after that
        /// call the slower method VideoCapture::retrieve() to decode and get frame from each camera. This way
        /// the overhead on demosaicing or motion jpeg decompression etc. is eliminated and the retrieved frames
        /// from different cameras will be closer in time.
        ///
        /// Also, when a connected camera is multi-head (for example, a stereo camera or a Kinect device), the
        /// correct way of retrieving data from it is to call VideoCapture::grab() first and then call
        /// VideoCapture::retrieve() one or more times with different values of the channel parameter.
        /// </summary>
        /// <returns>`true` (non-zero) in the case of success.</returns>
        public bool Grab()
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.videoio_VideoCapture_grab(ptr, out var ret));
            GC.KeepAlive(this);
            return ret != 0;
        }
        
        /// <summary>
        /// Decodes and returns the grabbed video frame.
        ///
        /// The method decodes and returns the just grabbed frame. If no frames has been grabbed
        /// (camera has been disconnected, or there are no more frames in video file), the method returns false
        /// and the function returns an empty image (with %cv::Mat, test it with Mat::empty()).
        /// </summary>
        /// <param name="image">the video frame is returned here. If no frames has been grabbed the image will be empty.</param>
        /// <param name="flag">it could be a frame index or a driver specific flag</param>
        /// <returns></returns>
        public bool Retrieve(OutputArray image, int flag = 0)
        {
            ThrowIfDisposed();
            if (image == null)
                throw new ArgumentNullException(nameof(image));
            image.ThrowIfNotReady();

            NativeMethods.HandleException(
                NativeMethods.videoio_VideoCapture_retrieve_OutputArray(ptr, image.CvPtr, flag, out var ret));

            GC.KeepAlive(this);
            image.Fix();
            return ret != 0;
        }

        /// <summary>
        /// Decodes and returns the grabbed video frame.
        /// 
        /// The method decodes and returns the just grabbed frame. If no frames has been grabbed
        /// (camera has been disconnected, or there are no more frames in video file), the method returns false
        /// and the function returns an empty image (with %cv::Mat, test it with Mat::empty()).
        /// </summary>
        /// <param name="image">the video frame is returned here. If no frames has been grabbed the image will be empty.</param>
        /// <param name="streamIdx">non-zero streamIdx is only valid for multi-head camera live streams</param>
        /// <returns></returns>
        public bool Retrieve(OutputArray image, CameraChannels streamIdx)
        {
            ThrowIfDisposed();
            if (image == null)
                throw new ArgumentNullException(nameof(image));
            image.ThrowIfNotReady();

            NativeMethods.HandleException(
                NativeMethods.videoio_VideoCapture_retrieve_OutputArray(ptr, image.CvPtr, (int)streamIdx, out var ret));

            GC.KeepAlive(this);
            image.Fix();
            return ret != 0;
        }
        
        /// <summary>
        /// Decodes and returns the grabbed video frame.
        ///
        /// The method decodes and returns the just grabbed frame. If no frames has been grabbed
        /// (camera has been disconnected, or there are no more frames in video file), the method returns false
        /// and the function returns an empty image (with %cv::Mat, test it with Mat::empty()).
        /// </summary>
        /// <param name="image">the video frame is returned here. If no frames has been grabbed the image will be empty.</param>
        /// <param name="flag">it could be a frame index or a driver specific flag</param>
        /// <returns></returns>
        public bool Retrieve(Mat image, int flag = 0)
        {
            ThrowIfDisposed();
            if (image == null)
                throw new ArgumentNullException(nameof(image));
            image.ThrowIfDisposed();

            NativeMethods.HandleException(
                NativeMethods.videoio_VideoCapture_retrieve_Mat(ptr, image.CvPtr, flag, out var ret));

            GC.KeepAlive(this);
            GC.KeepAlive(image);
            return ret != 0;
        }

        /// <summary>
        /// Decodes and returns the grabbed video frame.
        /// 
        /// The method decodes and returns the just grabbed frame. If no frames has been grabbed
        /// (camera has been disconnected, or there are no more frames in video file), the method returns false
        /// and the function returns an empty image (with %cv::Mat, test it with Mat::empty()).
        /// </summary>
        /// <param name="image">the video frame is returned here. If no frames has been grabbed the image will be empty.</param>
        /// <param name="streamIdx">non-zero streamIdx is only valid for multi-head camera live streams</param>
        /// <returns></returns>
        public bool Retrieve(Mat image, CameraChannels streamIdx)
        {
            ThrowIfDisposed();
            if (image == null)
                throw new ArgumentNullException(nameof(image));
            image.ThrowIfDisposed();

            NativeMethods.HandleException(
                NativeMethods.videoio_VideoCapture_retrieve_Mat(ptr, image.CvPtr, (int)streamIdx, out var ret));

            GC.KeepAlive(this);
            GC.KeepAlive(image);
            return ret != 0;
        }

        /// <summary>
        /// Decodes and returns the grabbed video frame.
        ///
        /// The method decodes and returns the just grabbed frame. If no frames has been grabbed
        /// (camera has been disconnected, or there are no more frames in video file), the method returns false
        /// and the function returns an empty image (with %cv::Mat, test it with Mat::empty()).
        /// </summary>
        /// <returns>the video frame is returned here. If no frames has been grabbed the image will be empty.</returns>
        public Mat RetrieveMat()
        {
            ThrowIfDisposed();

            var mat = new Mat();
            NativeMethods.HandleException(
                NativeMethods.videoio_VideoCapture_operatorRightShift_Mat(ptr, mat.CvPtr));
            GC.KeepAlive(this);
            return mat;
        }

        /// <summary>
        /// Grabs, decodes and returns the next video frame.
        ///
        /// The method/function combines VideoCapture::grab() and VideoCapture::retrieve() in one call. This is the
        /// most convenient method for reading video files or capturing data from decode and returns the just
        /// grabbed frame. If no frames has been grabbed (camera has been disconnected, or there are no more
        /// frames in video file), the method returns false and the function returns empty image (with %cv::Mat, test it with Mat::empty()).
        /// </summary>
        /// <returns>`false` if no frames has been grabbed</returns>
        public bool Read(OutputArray image)
        {
            ThrowIfDisposed();
            if(image == null)
                throw new ArgumentNullException(nameof(image));
            image.ThrowIfNotReady();

            NativeMethods.HandleException(
                NativeMethods.videoio_VideoCapture_read_OutputArray(ptr, image.CvPtr, out var ret));

            GC.KeepAlive(this);
            image.Fix();
            return ret != 0;
        }
        
        /// <summary>
        /// Grabs, decodes and returns the next video frame.
        ///
        /// The method/function combines VideoCapture::grab() and VideoCapture::retrieve() in one call. This is the
        /// most convenient method for reading video files or capturing data from decode and returns the just
        /// grabbed frame. If no frames has been grabbed (camera has been disconnected, or there are no more
        /// frames in video file), the method returns false and the function returns empty image (with %cv::Mat, test it with Mat::empty()).
        /// </summary>
        /// <returns>`false` if no frames has been grabbed</returns>
        public bool Read(Mat image)
        {
            ThrowIfDisposed();
            if(image == null)
                throw new ArgumentNullException(nameof(image));
            image.ThrowIfDisposed();

            NativeMethods.HandleException(
                NativeMethods.videoio_VideoCapture_read_Mat(ptr, image.CvPtr, out var ret));

            GC.KeepAlive(this);
            GC.KeepAlive(image);
            return ret != 0;
        }

        /// <summary>
        /// Sets a property in the VideoCapture.
        /// </summary>
        /// <param name="propertyId">Property identifier from cv::VideoCaptureProperties (eg. cv::CAP_PROP_POS_MSEC, cv::CAP_PROP_POS_FRAMES, ...)
        /// or one from @ref videoio_flags_others</param>
        /// <param name="value">Value of the property.</param>
        /// <returns>`true` if the property is supported by backend used by the VideoCapture instance.</returns>
        public bool Set(VideoCaptureProperties propertyId, double value)
        {
            return Set((int)propertyId, value);
        }

        /// <summary>
        /// Sets a property in the VideoCapture.
        /// </summary>
        /// <param name="propertyId">Property identifier from cv::VideoCaptureProperties (eg. cv::CAP_PROP_POS_MSEC, cv::CAP_PROP_POS_FRAMES, ...)
        /// or one from @ref videoio_flags_others</param>
        /// <param name="value">Value of the property.</param>
        /// <returns>`true` if the property is supported by backend used by the VideoCapture instance.</returns>
        public bool Set(int propertyId, double value)
        { 
            ThrowIfDisposed();

            NativeMethods.HandleException(
                NativeMethods.videoio_VideoCapture_set(ptr, propertyId, value, out var ret));

            GC.KeepAlive(this);
            return ret != 0;
        }

        /// <summary>
        /// Returns the specified VideoCapture property
        /// </summary>
        /// <param name="propertyId">Property identifier from cv::VideoCaptureProperties (eg. cv::CAP_PROP_POS_MSEC, cv::CAP_PROP_POS_FRAMES, ...)
        /// or one from @ref videoio_flags_others</param>
        /// <returns>Value for the specified property. Value 0 is returned when querying a property that is not supported by the backend used by the VideoCapture instance.</returns>
        public double Get(VideoCaptureProperties propertyId)
        {
            return Get((int)propertyId);
        }

        /// <summary>
        /// Returns the specified VideoCapture property
        /// </summary>
        /// <param name="propertyId">Property identifier from cv::VideoCaptureProperties (eg. cv::CAP_PROP_POS_MSEC, cv::CAP_PROP_POS_FRAMES, ...)
        /// or one from @ref videoio_flags_others</param>
        /// <returns>Value for the specified property. Value 0 is returned when querying a property that is not supported by the backend used by the VideoCapture instance.</returns>
        public double Get(int propertyId)
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.videoio_VideoCapture_get(ptr, propertyId, out var ret));
            GC.KeepAlive(this);
            return ret;
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
                NativeMethods.videoio_VideoCapture_getBackendName(ptr, returnString.CvPtr));
            GC.KeepAlive(this);
            return returnString.ToString();
        }

        /// <summary>
        /// Switches exceptions mode.
        /// methods raise exceptions if not successful instead of returning an error code
        /// </summary>
        /// <param name="enable"></param>
        public void SetExceptionMode(bool enable)
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.videoio_VideoCapture_setExceptionMode(ptr, enable ? 1 : 0));
            GC.KeepAlive(this);
        }

        /// <summary>
        /// query if exception mode is active
        /// </summary>
        /// <returns></returns>
        public bool GetExceptionMode()
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.videoio_VideoCapture_getExceptionMode(ptr, out var ret));
            GC.KeepAlive(this);
            return ret != 0;
        }

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
