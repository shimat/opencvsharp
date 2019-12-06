
using System;

namespace OpenCvSharp
{
    // ReSharper disable InconsistentNaming
    // ReSharper disable IdentifierTypo
    // ReSharper disable CommentTypo

#if LANG_JP
    /// <summary>
    /// カメラキャプチャの初期化に用いるカメラのデバイス
    /// </summary>
#else
    /// <summary>
    /// Camera device types
    /// </summary>
#endif
    public enum VideoCaptureAPIs
    {
        /// <summary>
        /// Auto detect == 0
        /// </summary>
        ANY = 0, 

        /// <summary>
        /// Video For Windows (obsolete, removed)
        /// </summary>
        [Obsolete] VFW = 200,

        /// <summary>
        /// V4L/V4L2 capturing support
        /// </summary>
        V4L = 200,

        /// <summary>
        /// Same as CAP_V4L
        /// </summary>
        V4L2 = V4L, 

        /// <summary>
        /// IEEE 1394 drivers
        /// </summary>
        FIREWIRE = 300, 

        /// <summary>
        /// Same value as CAP_FIREWIRE
        /// </summary>
        FIREWARE = FIREWIRE, 

        /// <summary>
        /// Same value as CAP_FIREWIRE
        /// </summary>
        IEEE1394 = FIREWIRE, 

        /// <summary>
        /// Same value as CAP_FIREWIRE
        /// </summary>
        DC1394 = FIREWIRE, 

        /// <summary>
        /// Same value as CAP_FIREWIRE
        /// </summary>
        CMU1394 = FIREWIRE, 

        /// <summary>
        /// QuickTime (obsolete, removed)
        /// </summary>
        [Obsolete] QT = 500,

        /// <summary>
        /// Unicap drivers (obsolete, removed)
        /// </summary>
        [Obsolete] UNICAP = 600,

        /// <summary>
        /// DirectShow (via videoInput)
        /// </summary>
        DSHOW = 700,

        /// <summary>
        /// PvAPI, Prosilica GigE SDK
        /// </summary>
        PVAPI = 800, 

        /// <summary>
        /// OpenNI (for Kinect)
        /// </summary>
        OPENNI = 900, 

        /// <summary>
        /// OpenNI (for Asus Xtion)
        /// </summary>
        OPENNI_ASUS = 910, 

        /// <summary>
        /// Android - not used
        /// </summary>
        ANDROID = 1000, 

        /// <summary>
        /// XIMEA Camera API
        /// </summary>
        XIAPI = 1100, 

        /// <summary>
        /// AVFoundation framework for iOS (OS X Lion will have the same API)
        /// </summary>
        AVFOUNDATION = 1200, 

        /// <summary>
        /// Smartek Giganetix GigEVisionSDK
        /// </summary>
        GIGANETIX = 1300, 

        /// <summary>
        /// Microsoft Media Foundation (via videoInput)
        /// </summary>
        MSMF = 1400, 

        /// <summary>
        /// Microsoft Windows Runtime using Media Foundation
        /// </summary>
        WINRT = 1410, 

        /// <summary>
        /// RealSense (former Intel Perceptual Computing SDK)
        /// </summary>
        INTELPERC = 1500, 

        /// <summary>
        /// Synonym for CAP_INTELPERC
        /// </summary>
        REALSENSE = 1500, 

        /// <summary>
        /// OpenNI2 (for Kinect)
        /// </summary>
        OPENNI2 = 1600, 

        /// <summary>
        /// OpenNI2 (for Asus Xtion and Occipital Structure sensors)
        /// </summary>
        OPENNI2_ASUS = 1610, 

        /// <summary>
        /// gPhoto2 connection
        /// </summary>
        GPHOTO2 = 1700, 

        /// <summary>
        /// GStreamer
        /// </summary>
        GSTREAMER = 1800, 

        /// <summary>
        /// Open and record video file or stream using the FFMPEG library
        /// </summary>
        FFMPEG = 1900, 

        /// <summary>
        /// OpenCV Image Sequence (e.g. img_%02d.jpg)
        /// </summary>
        IMAGES = 2000, 

        /// <summary>
        /// Aravis SDK
        /// </summary>
        ARAVIS = 2100, 

        /// <summary>
        /// Built-in OpenCV MotionJPEG codec
        /// </summary>
        OPENCV_MJPEG = 2200,

        /// <summary>
        /// Intel MediaSDK
        /// </summary>
        INTEL_MFX = 2300,

        /// <summary>
        /// XINE engine (Linux)
        /// </summary>
        XINE = 2400,
    }
}
