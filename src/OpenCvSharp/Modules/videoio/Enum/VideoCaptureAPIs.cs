using System.Diagnostics.CodeAnalysis;

#pragma warning disable CA1707 // Underscore

namespace OpenCvSharp;

// ReSharper disable InconsistentNaming
// ReSharper disable IdentifierTypo
// ReSharper disable CommentTypo
/// <summary>
/// Camera device types
/// </summary>
/// <remarks>
/// https://github.com/opencv/opencv/blob/d3bc563c6e01c2bc153f23e7393322a95c7d3974/modules/videoio/include/opencv2/videoio.hpp#L89
/// </remarks>
[SuppressMessage("Microsoft.Design", "CA1717: Only FlagsAttribute enums should have plural names")]
public enum VideoCaptureAPIs
{
    /// <summary>
    /// Auto detect == 0
    /// </summary>
    ANY = 0, 
        
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
#pragma warning disable CA1069
    REALSENSE = 1500,
#pragma warning restore CA1069

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

    /// <summary>
    /// uEye Camera API
    /// </summary>
    CAP_UEYE = 2500,
}
