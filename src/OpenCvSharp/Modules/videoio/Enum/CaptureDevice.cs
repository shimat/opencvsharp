
namespace OpenCvSharp
{
    // ReSharper disable InconsistentNaming

#if LANG_JP
    /// <summary>
    /// カメラキャプチャの初期化に用いるカメラのデバイス
    /// </summary>
#else
    /// <summary>
    /// Camera device types
    /// </summary>
#endif
    public enum CaptureDevice : int
    {
        /// <summary>
        /// autodetect
        /// </summary>
        Any = 0,

        /// <summary>
        /// platform native
        /// </summary>
        VFW = 200,

        /// <summary>
        /// platform native
        /// </summary>
        V4L = 200,

        /// <summary>
        /// platform native
        /// </summary>
        V4L2 = V4L,

        /// <summary>
        /// IEEE 1394 drivers
        /// </summary>
        Firewire = 300,

        /// <summary>
        /// IEEE 1394 drivers
        /// </summary>
        Fireware = Firewire,

        /// <summary>
        /// IEEE 1394 drivers
        /// </summary>
        IEEE1394 = Firewire,

        /// <summary>
        /// IEEE 1394 drivers
        /// </summary>
        DC1394 = Firewire,

        /// <summary>
        /// IEEE 1394 drivers
        /// </summary>
        CMU1394 = Firewire,

        /// <summary>
        /// QuickTime
        /// </summary>
        Qt = 500,

        /// <summary>
        /// Unicap drivers
        /// </summary>
        Unicap = 600,

        /// <summary>
        /// DirectShow (via videoInput)
        /// </summary>
        DShow = 700,

        /// <summary>
        /// PvAPI, Prosilica GigE SDK
        /// </summary>
        PVAPI = 800,

        /// <summary>
        /// OpenNI (for Kinect)
        /// </summary>
        OpenNI = 900,

        /// <summary>
        /// OpenNI (for Asus Xtion)
        /// </summary>
        OpenNI_ASUS = 910,

        /// <summary>
        /// Android
        /// </summary>
        Android = 1000,

        /// <summary>
        /// XIMEA Camera API
        /// </summary>
        XIAPI = 1100,

        /// <summary>
        /// AVFoundation framework for iOS (OS X Lion will have the same API)
        /// </summary>
        AVFoundation = 1200, 
 
        /// <summary>
        /// Smartek Giganetix GigEVisionSDK
        /// </summary>
        Giganetix = 1300,  

        /// <summary>
        /// Microsoft Media Foundation (via videoInput)
        /// </summary>
        MSMF = 1400,  

        /// <summary>
        /// Microsoft Windows Runtime using Media Foundation
        /// </summary>
        WinRT = 1410, 

        /// <summary>
        /// Intel Perceptual Computing SDK
        /// </summary>
        IntelPERC = 1500,  
 
        /// <summary>
        /// OpenNI2 (for Kinect)
        /// </summary>
        OpenNI2 = 1600,  

        /// <summary>
        /// OpenNI2 (for Asus Xtion and Occipital Structure sensors)
        /// </summary>
        OpenNI2_ASUS = 1610, 

        /// <summary>
        /// gPhoto2 connection
        /// </summary>
        GPhoto2 = 1700,

        /// <summary>
        /// GStreamer
        /// </summary>
        GStreamer = 1800,

        /// <summary>
        /// Open and record video file or stream using the FFMPEG library
        /// </summary>
        FFMPEG = 1900, 

        /// <summary>
        ///  OpenCV Image Sequence (e.g. img_%02d.jpg)
        /// </summary>
        Images = 2000,

        /// <summary>
        /// Aravis SDK
        /// </summary>
        Aravis = 2100,
    }
}
