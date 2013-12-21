using System;
using System.Collections.Generic;
using System.Text;

#pragma warning disable 1591
// ReSharper disable InconsistentNaming

namespace OpenCvSharp
{
#if LANG_JP
    /// <summary>
	/// OpenCVの定数
	/// </summary>
#else
    /// <summary>
    /// OpenCV Constants defined by macro
    /// </summary>
#endif
    static public class CvConst
    {
        public const int CV_AUTOSTEP = 2147483647;
        public const int CV_FILLED = -1;
        public const double CV_LOG2 = 0.69314718055994530941723212145818;
        public const double CV_PI = 3.1415926535897932384626433832795;
        public const int CV_MAX_DIM = 32;
        public const int CV_WHOLE_SEQ_END_INDEX = 1073741823;
        public const int CV_ORIENTED_GRAPH = 5632;
        public const int CV_GRAPH_FLAG_ORIENTED = 4096;
        public const int CV_GRAPH = 1536;
        public const uint IPL_DEPTH_SIGN = 0x80000000;
        public const uint MAGIC_MASK = 0xFFFF0000;
        public const int TYPE_MASK = 0x00000FFF;
        public const int DEPTH_MASK = 7;
        public const int CV_MAT_CONT_FLAG_SHIFT = 14;
        public const int CV_MAT_CONT_FLAG = (1 << CV_MAT_CONT_FLAG_SHIFT);
        public const uint CV_MAGIC_MASK = 0xFFFF0000;
        public const int CV_MAT_MAGIC_VAL = 0x42420000;

        // Matrix type
        public const int CV_CN_MAX = 64;
        public const int CV_CN_SHIFT = 3;
        public const int CV_DEPTH_MAX = (1 << CV_CN_SHIFT);
        public const int CV_MAT_DEPTH_MASK = (CV_DEPTH_MAX - 1);
        public const int CV_MAT_CN_MASK = ((CV_CN_MAX - 1) << CV_CN_SHIFT);
        public const int CV_MAT_TYPE_MASK = (CV_DEPTH_MAX * CV_CN_MAX - 1);

        // cvAdaptiveThreshold
        public const int CV_ADAPTIVE_THRESH_MEAN_C = 0;
        public const int CV_ADAPTIVE_THRESH_GAUSSIAN_C = 1;
        // cvApproxPoly
        public const int CV_POLY_APPROX_DP = 0;
        // cvLine, cvCircle, ...
        public const int CV_AA = 16;
        // cvCalibrateCamera2        
        public const int CV_CALIB_USE_INTRINSIC_GUESS = 1;
        public const int CV_CALIB_FIX_ASPECT_RATIO = 2;
        public const int CV_CALIB_FIX_PRINCIPAL_POINT = 4;
        public const int CV_CALIB_ZERO_TANGENT_DIST = 8;
        public const int CV_CALIB_FIX_FOCAL_LENGTH = 16;
        public const int CV_CALIB_FIX_K1 = 32;
        public const int CV_CALIB_FIX_K2 = 64;
        public const int CV_CALIB_FIX_K3 = 128;
        public const int CV_CALIB_FIX_INTRINSIC = 256;
        public const int CV_CALIB_SAME_FOCAL_LENGTH = 512;
        public const int CV_CALIB_FIX_K4 = 2048;
        public const int CV_CALIB_FIX_K5 = 4096;
        public const int CV_CALIB_FIX_K6 = 8192;
        public const int CV_CALIB_RATIONAL_MODEL = 16384;

        // cvCalcCoverMatrix
        public const int CV_COVAR_SCRAMBLED = 0;
        public const int CV_COVAR_NORMAL = 1;
        public const int CV_COVAR_USE_AVG = 2;
        public const int CV_COVAR_SCALE = 4;
        public const int CV_COVAR_ROWS = 8;
        public const int CV_COVAR_COLS = 16;
        // cvCalcCoverMatrixEx, cvCalcEigenObjects, ...
        public const int CV_EIGOBJ_NO_CALLBACK = 0;
        public const int CV_EIGOBJ_INPUT_CALLBACK = 1;
        public const int CV_EIGOBJ_OUTPUT_CALLBACK = 2;
        public const int CV_EIGOBJ_BOTH_CALLBACK = 3;
        // cvCalcOpticalFlowXXX
        public const int CV_LKFLOW_PYR_A_READY = 1;
        public const int CV_LKFLOW_PYR_B_READY = 2;
        public const int CV_LKFLOW_INITIAL_GUESSES = 4;
        public const int OPTFLOW_USE_INITIAL_FLOW = 4;
        public const int CV_LKFLOW_GET_MIN_EIGENVALS = 8;
        // cvCalcPCA
        public const int CV_PCA_DATA_AS_ROW = 0;
        public const int CV_PCA_DATA_AS_COL = 1;
        public const int CV_PCA_USE_AVG = 2;
        // cvCanny
        public const int CV_SCHARR = -1;

        // cvCheckHardwareSupport
        public const int CV_CPU_NONE   = 0;    
        public const int CV_CPU_MMX    = 1;
        public const int CV_CPU_SSE    = 2;
        public const int CV_CPU_SSE2   = 3;
        public const int CV_CPU_SSE3   = 4;
        public const int CV_CPU_SSSE3  = 5;
        public const int CV_CPU_SSE4_1 = 6;
        public const int CV_CPU_SSE4_2 = 7;
        public const int CV_CPU_POPCNT = 8;
        public const int CV_CPU_AVX    = 10;
        public const int CV_HARDWARE_MAX_FEATURE = 255;

        // cvCopyMakeBorder
        public const int IPL_BORDER_CONSTANT = 0;
        public const int IPL_BORDER_REPLICATE = 1;
        public const int IPL_BORDER_REFLECT = 2;
        public const int IPL_BORDER_REFLECT_101 = 4;
        public const int IPL_BORDER_WRAP = 3;
        public const int IPL_BORDER_DEFAULT = 4;
        // cvCreateCameraCapture
        public const int CV_CAP_ANY = 0;
        public const int CV_CAP_MIL = 100;
        public const int CV_CAP_VFW = 200;
        public const int CV_CAP_V4L = 200;
        public const int CV_CAP_V4L2 = 200;
        public const int CV_CAP_FIREWIRE = 300;
        public const int CV_CAP_IEEE1394 = 300;
        public const int CV_CAP_FIREWARE = 300;   // IEEE 1394 drivers
        public const int CV_CAP_DC1394 = 300;
        public const int CV_CAP_CMU1394 = 300;
        public const int CV_CAP_STEREO = 400;
        public const int CV_CAP_TYZX = 400;// TYZX proprietary drivers
        public const int CV_TYZX_LEFT = 400;
        public const int CV_TYZX_RIGHT = 401;
        public const int CV_TYZX_COLOR = 402;
        public const int CV_TYZX_Z = 403;
        public const int CV_CAP_QT = 500;
        public const int CV_CAP_UNICAP = 600;
        public const int CV_CAP_DSHOW = 700;
        public const int CV_CAP_PVAPI = 800;   // PvAPI, Prosilica GigE SDK
        public const int CV_CAP_OPENNI = 900;   // OpenNI (for Kinect)
        public const int CV_CAP_ANDROID = 1000;  // Android   
        public const int CV_CAP_XIAPI = 1100;   // XIMEA Camera API

        // cv(Get/Set)CaptureProperty
        public const int CV_CAP_PROP_POS_MSEC = 0;
        public const int CV_CAP_PROP_POS_FRAMES = 1;
        public const int CV_CAP_PROP_POS_AVI_RATIO = 2;
        public const int CV_CAP_PROP_FRAME_WIDTH = 3;
        public const int CV_CAP_PROP_FRAME_HEIGHT = 4;
        public const int CV_CAP_PROP_FPS = 5;
        public const int CV_CAP_PROP_FOURCC = 6;
        public const int CV_CAP_PROP_FRAME_COUNT = 7;
        public const int CV_CAP_PROP_FORMAT = 8;
        public const int CV_CAP_PROP_MODE = 9;
        public const int CV_CAP_PROP_BRIGHTNESS = 10;
        public const int CV_CAP_PROP_CONTRAST = 11;
        public const int CV_CAP_PROP_SATURATION = 12;
        public const int CV_CAP_PROP_HUE = 13;
        public const int CV_CAP_PROP_GAIN = 14;
        public const int CV_CAP_PROP_EXPOSURE = 15;
        public const int CV_CAP_PROP_CONVERT_RGB = 16;
        public const int CV_CAP_PROP_WHITE_BALANCE = 17;
        public const int CV_CAP_PROP_RECTIFICATION = 18;
        public const int CV_CAP_PROP_MONOCROME = 19;
        public const int CV_CAP_PROP_SHARPNESS = 20;
        public const int CV_CAP_PROP_AUTO_EXPOSURE = 21; // exposure control done by camera, user can adjust refernce level using this feature
        public const int CV_CAP_PROP_GAMMA = 22;
        public const int CV_CAP_PROP_TEMPERATURE = 23;
        public const int CV_CAP_PROP_TRIGGER = 24;
        public const int CV_CAP_PROP_TRIGGER_DELAY = 25;
        public const int CV_CAP_PROP_WHITE_BALANCE_RED_V = 26;
        public const int CV_CAP_PROP_MAX_DC1394 = 27;
        public const int CV_CAP_PROP_AUTOGRAB = 1024; // property for highgui class CvCapture_Android only
        public const int CV_CAP_PROP_SUPPORTED_PREVIEW_SIZES_STRING = 1025; // readonly, tricky property, returns cpnst char* indeed
        public const int CV_CAP_PROP_PREVIEW_FORMAT = 1026; // readonly, tricky property, returns cpnst char* indeed
        // OpenNI map generators
        public const int CV_CAP_OPENNI_DEPTH_GENERATOR = 0;
        public const int CV_CAP_OPENNI_IMAGE_GENERATOR = 1 << 31;
        public const int CV_CAP_OPENNI_GENERATORS_MASK = 1 << 31;
        // Properties of cameras available through OpenNI interfaces
        public const int CV_CAP_PROP_OPENNI_OUTPUT_MODE = 100;
        public const int CV_CAP_PROP_OPENNI_FRAME_MAX_DEPTH = 101; // in mm
        public const int CV_CAP_PROP_OPENNI_BASELINE = 102; // in mm
        public const int CV_CAP_PROP_OPENNI_FOCAL_LENGTH = 103; // in pixels
        public const int CV_CAP_PROP_OPENNI_REGISTRATION_ON = 104; // flag
        public const int CV_CAP_PROP_OPENNI_REGISTRATION = CV_CAP_PROP_OPENNI_REGISTRATION_ON; // flag that synchronizes the remapping depth map to image map
        // by changing depth generator's view point (if the flag is "on") or
        // sets this view point to its normal one (if the flag is "off").
        public const int CV_CAP_OPENNI_IMAGE_GENERATOR_OUTPUT_MODE = CV_CAP_OPENNI_IMAGE_GENERATOR + CV_CAP_PROP_OPENNI_OUTPUT_MODE;
        public const int CV_CAP_OPENNI_DEPTH_GENERATOR_BASELINE = CV_CAP_OPENNI_DEPTH_GENERATOR + CV_CAP_PROP_OPENNI_BASELINE;
        public const int CV_CAP_OPENNI_DEPTH_GENERATOR_FOCAL_LENGTH = CV_CAP_OPENNI_DEPTH_GENERATOR + CV_CAP_PROP_OPENNI_FOCAL_LENGTH;
        public const int CV_CAP_OPENNI_DEPTH_GENERATOR_REGISTRATION_ON = CV_CAP_OPENNI_DEPTH_GENERATOR + CV_CAP_PROP_OPENNI_REGISTRATION_ON;
        // Properties of cameras available through GStreamer interface
        public const int CV_CAP_GSTREAMER_QUEUE_LENGTH = 200; // default is 1
        public const int CV_CAP_PROP_PVAPI_MULTICASTIP = 300; // ip for anable multicast master mode. 0 for disable multicast
        // Properties of cameras available through XIMEA SDK interface
        public const int CV_CAP_PROP_XI_DOWNSAMPLING = 400;      // Change image resolution by binning or skipping.  
        public const int CV_CAP_PROP_XI_DATA_FORMAT = 401;       // Output data format.
        public const int CV_CAP_PROP_XI_OFFSET_X = 402;      // Horizontal offset from the origin to the area of interest (in pixels).
        public const int CV_CAP_PROP_XI_OFFSET_Y = 403;      // Vertical offset from the origin to the area of interest (in pixels).
        public const int CV_CAP_PROP_XI_TRG_SOURCE = 404;      // Defines source of trigger.
        public const int CV_CAP_PROP_XI_TRG_SOFTWARE = 405;      // Generates an internal trigger. PRM_TRG_SOURCE must be set to TRG_SOFTWARE.
        public const int CV_CAP_PROP_XI_GPI_SELECTOR = 406;      // Selects general purpose input 
        public const int CV_CAP_PROP_XI_GPI_MODE = 407;      // Set general purpose input mode
        public const int CV_CAP_PROP_XI_GPI_LEVEL = 408;      // Get general purpose level
        public const int CV_CAP_PROP_XI_GPO_SELECTOR = 409;      // Selects general purpose output 
        public const int CV_CAP_PROP_XI_GPO_MODE = 410;      // Set general purpose output mode
        public const int CV_CAP_PROP_XI_LED_SELECTOR = 411;      // Selects camera signalling LED 
        public const int CV_CAP_PROP_XI_LED_MODE = 412;      // Define camera signalling LED functionality
        public const int CV_CAP_PROP_XI_MANUAL_WB = 413;      // Calculates White Balance(must be called during acquisition)
        public const int CV_CAP_PROP_XI_AUTO_WB = 414;      // Automatic white balance
        public const int CV_CAP_PROP_XI_AEAG = 415;      // Automatic exposure/gain
        public const int CV_CAP_PROP_XI_EXP_PRIORITY = 416;      // Exposure priority (0.5 - exposure 50%, gain 50%).
        public const int CV_CAP_PROP_XI_AE_MAX_LIMIT = 417;      // Maximum limit of exposure in AEAG procedure
        public const int CV_CAP_PROP_XI_AG_MAX_LIMIT = 418;      // Maximum limit of gain in AEAG procedure
        public const int CV_CAP_PROP_XI_AEAG_LEVEL = 419;       // Average intensity of output signal AEAG should achieve(in %)
        public const int CV_CAP_PROP_XI_TIMEOUT = 420;       // Image capture timeout in milliseconds

        // cvRetrieveFrame
        // Data given from depth generator.
        public const int CV_CAP_OPENNI_DEPTH_MAP = 0; // Depth values in mm (CV_16UC1)
        public const int CV_CAP_OPENNI_POINT_CLOUD_MAP = 1; // XYZ in meters (CV_32FC3)
        public const int CV_CAP_OPENNI_DISPARITY_MAP = 2; // Disparity in pixels (CV_8UC1)
        public const int CV_CAP_OPENNI_DISPARITY_MAP_32F = 3; // Disparity in pixels (CV_32FC1)
        public const int CV_CAP_OPENNI_VALID_DEPTH_MASK = 4; // CV_8UC1
        // Data given from RGB image generator.
        public const int CV_CAP_OPENNI_BGR_IMAGE = 5;
        public const int CV_CAP_OPENNI_GRAY_IMAGE = 6;
        // Supported output modes of OpenNI image generator
        public const int CV_CAP_OPENNI_VGA_30HZ = 0;
        public const int CV_CAP_OPENNI_SXGA_15HZ = 1;
        //supported by Android camera output formats
        public const int CV_CAP_ANDROID_COLOR_FRAME_BGR = 0; //BGR
        public const int CV_CAP_ANDROID_COLOR_FRAME = CV_CAP_ANDROID_COLOR_FRAME_BGR;
        public const int CV_CAP_ANDROID_GREY_FRAME = 1;  //Y
        public const int CV_CAP_ANDROID_COLOR_FRAME_RGB = 2;
        public const int CV_CAP_ANDROID_COLOR_FRAME_BGRA = 3;
        public const int CV_CAP_ANDROID_COLOR_FRAME_RGBA = 4;

        // cv(Get/Set)WindowProperty
        public const int CV_WND_PROP_FULLSCREEN = 0;
        public const int CV_WND_PROP_AUTOSIZE = 1;
        public const int CV_WINDOW_NORMAL = 0;
        public const int CV_WINDOW_FULLSCREEN = 1;
        public const int CV_WINDOW_FREERATIO = 4;
        public const int CV_WINDOW_KEEPRATIO = 0;

        // cvCheckArr
        public const int CV_CHECK_RANGE = 1;
        public const int CV_CHECK_QUIET = 2;
        // cvConvertImage
        public const int CV_CVTIMG_FLIP = 1;
        public const int CV_CVTIMG_SWAP_RB = 2;
        // cvCmp
        public const int CV_CMP_EQ = 0;
        public const int CV_CMP_GT = 1;
        public const int CV_CMP_GE = 2;
        public const int CV_CMP_LT = 3;
        public const int CV_CMP_LE = 4;
        public const int CV_CMP_NE = 5;
        // cvConvexHull2
        public const int CV_CLOCKWISE = 1;
        public const int CV_COUNTER_CLOCKWISE = 2;
        // cvCreateButton
        public const int CV_PUSH_BUTTON = 0;
        public const int CV_CHECKBOX = 1;
        public const int CV_RADIOBOX = 2;
        // cvCreateGraphScanner		
        public const int CV_GRAPH_VERTEX = 1;
        public const int CV_GRAPH_TREE_EDGE = 2;
        public const int CV_GRAPH_BACK_EDGE = 4;
        public const int CV_GRAPH_FORWARD_EDGE = 8;
        public const int CV_GRAPH_CROSS_EDGE = 16;
        public const int CV_GRAPH_ANY_EDGE = 30;
        public const int CV_GRAPH_NEW_TREE = 32;
        public const int CV_GRAPH_BACKTRACKING = 64;
        public const int CV_GRAPH_OVER = -1;
        public const int CV_GRAPH_ALL_ITEMS = -1;
        // cvCreateImage		
        public const int IPL_DEPTH_1U = 1;
        public const int IPL_DEPTH_8U = 8;
        public const int IPL_DEPTH_8S = -2147483640;
        public const int IPL_DEPTH_16U = 16;
        public const int IPL_DEPTH_16S = -2147483632;
        public const int IPL_DEPTH_32S = -2147483616;
        public const int IPL_DEPTH_32F = 32;
        public const int IPL_DEPTH_64F = 64;
        // cvCreateMat
        public const int CV_8U = 0;
        public const int CV_8S = 1;
        public const int CV_16U = 2;
        public const int CV_16S = 3;
        public const int CV_32S = 4;
        public const int CV_32F = 5;
        public const int CV_64F = 6;
        public const int CV_8UC1 = 0;
        public const int CV_8UC2 = 8;
        public const int CV_8UC3 = 16;
        public const int CV_8UC4 = 24;
        public const int CV_8SC1 = 1;
        public const int CV_8SC2 = 9;
        public const int CV_8SC3 = 17;
        public const int CV_8SC4 = 25;
        public const int CV_16UC1 = 2;
        public const int CV_16UC2 = 10;
        public const int CV_16UC3 = 18;
        public const int CV_16UC4 = 26;
        public const int CV_16SC1 = 3;
        public const int CV_16SC2 = 11;
        public const int CV_16SC3 = 19;
        public const int CV_16SC4 = 27;
        public const int CV_32SC1 = 4;
        public const int CV_32SC2 = 12;
        public const int CV_32SC3 = 20;
        public const int CV_32SC4 = 28;
        public const int CV_32FC1 = 5;
        public const int CV_32FC2 = 13;
        public const int CV_32FC3 = 21;
        public const int CV_32FC4 = 29;
        public const int CV_64FC1 = 6;
        public const int CV_64FC2 = 14;
        public const int CV_64FC3 = 22;
        public const int CV_64FC4 = 30;
        public const int CV_USRTYPE1 = 7;
        // cvCreateSeq
        public const int CV_SEQ_ELTYPE_BITS = 12;
        public const int CV_SEQ_ELTYPE_MASK = ((1 << CV_SEQ_ELTYPE_BITS) - 1);
        public const int CV_SEQ_ELTYPE_POINT = CV_32SC2;
        public const int CV_SEQ_ELTYPE_CODE = CV_8UC1;
        public const int CV_SEQ_ELTYPE_GENERIC = 0;
        public const int CV_SEQ_ELTYPE_PTR = CV_USRTYPE1;
        public const int CV_SEQ_ELTYPE_PPOINT = CV_SEQ_ELTYPE_PTR;
        public const int CV_SEQ_ELTYPE_INDEX = CV_32SC1;
        public const int CV_SEQ_ELTYPE_GRAPH_EDGE = 0;
        public const int CV_SEQ_ELTYPE_GRAPH_VERTEX = 0;
        public const int CV_SEQ_ELTYPE_TRIAN_ATR = 0;
        public const int CV_SEQ_ELTYPE_CONNECTED_COMP = 0;
        public const int CV_SEQ_ELTYPE_POINT3D = CV_32FC3;
        public const int CV_SEQ_KIND_BITS = 2;
        public const int CV_SEQ_KIND_MASK = (((1 << CV_SEQ_KIND_BITS) - 1) << CV_SEQ_ELTYPE_BITS);
        public const int CV_SEQ_KIND_GENERIC = (0 << CV_SEQ_ELTYPE_BITS);
        public const int CV_SEQ_KIND_CURVE = (1 << CV_SEQ_ELTYPE_BITS);
        public const int CV_SEQ_KIND_BIN_TREE = (2 << CV_SEQ_ELTYPE_BITS);
        public const int CV_SEQ_KIND_GRAPH = (1 << CV_SEQ_ELTYPE_BITS);
        public const int CV_SEQ_KIND_SUBDIV2D = (2 << CV_SEQ_ELTYPE_BITS);
        public const int CV_SEQ_FLAG_SHIFT = (CV_SEQ_KIND_BITS + CV_SEQ_ELTYPE_BITS);
        public const int CV_SEQ_FLAG_CLOSED = (1 << CV_SEQ_FLAG_SHIFT);
        public const int CV_SEQ_FLAG_SIMPLE = (0 << CV_SEQ_FLAG_SHIFT);
        public const int CV_SEQ_FLAG_CONVEX = (0 << CV_SEQ_FLAG_SHIFT);
        public const int CV_SEQ_FLAG_HOLE = (2 << CV_SEQ_FLAG_SHIFT);
        public const int CV_SEQ_POINT_SET = (CV_SEQ_KIND_GENERIC | CV_SEQ_ELTYPE_POINT);
        public const int CV_SEQ_POINT3D_SET = (CV_SEQ_KIND_GENERIC | CV_SEQ_ELTYPE_POINT3D);
        public const int CV_SEQ_POLYLINE = (CV_SEQ_KIND_CURVE | CV_SEQ_ELTYPE_POINT);
        public const int CV_SEQ_POLYGON = (CV_SEQ_FLAG_CLOSED | CV_SEQ_POLYLINE);
        public const int CV_SEQ_CONTOUR = CV_SEQ_POLYGON;
        public const int CV_SEQ_SIMPLE_POLYGON = (CV_SEQ_FLAG_SIMPLE | CV_SEQ_POLYGON);
        public const int CV_SEQ_CHAIN = (CV_SEQ_KIND_CURVE | CV_SEQ_ELTYPE_CODE);
        public const int CV_SEQ_CHAIN_CONTOUR = (CV_SEQ_FLAG_CLOSED | CV_SEQ_CHAIN);
        public const int CV_SEQ_POLYGON_TREE = (CV_SEQ_KIND_BIN_TREE | CV_SEQ_ELTYPE_TRIAN_ATR);
        public const int CV_SEQ_CONNECTED_COMP = (CV_SEQ_KIND_GENERIC | CV_SEQ_ELTYPE_CONNECTED_COMP);
        public const int CV_SEQ_INDEX = (CV_SEQ_KIND_GENERIC | CV_SEQ_ELTYPE_INDEX);
        public const int CV_SET_ELEM_IDX_MASK = ((1 << 26) - 1);
        public const int CV_SET_ELEM_FREE_FLAG = (1 << (sizeof(int) * 8 - 1));

        //public const int CV_SEQ_CHAIN = 512;
        //public const int CV_SEQ_CHAIN_CONTOUR = 4608;
        //public const int CV_SEQ_CONNECTED_COMP = 0;
        //public const int CV_SEQ_CONTOUR = 4620;
        //public const int CV_SEQ_ELTYPE_CODE = 0;
        //public const int CV_SEQ_ELTYPE_CONNECTED_COMP = 0;
        //public const int CV_SEQ_ELTYPE_GENERIC = 0;
        //public const int CV_SEQ_ELTYPE_GRAPH_EDGE = 0;
        //public const int CV_SEQ_ELTYPE_GRAPH_VERTEX = 0;
        //public const int CV_SEQ_ELTYPE_INDEX = 4;
        //public const int CV_SEQ_ELTYPE_POINT = 12;
        //public const int CV_SEQ_ELTYPE_POINT3D = 21;
        //public const int CV_SEQ_ELTYPE_PPOINT = 7;
        //public const int CV_SEQ_ELTYPE_PTR = 7;
        //public const int CV_SEQ_ELTYPE_TRIAN_ATR = 0;
        //public const int CV_SEQ_FLAG_CLOSED = 4096;
        //public const int CV_SEQ_FLAG_CONVEX = 16384;
        //public const int CV_SEQ_FLAG_HOLE = 32768;
        //public const int CV_SEQ_FLAG_SIMPLE = 8192;
        //public const int CV_SEQ_INDEX = 4;
        //public const int CV_SEQ_KIND_BIN_TREE = 1024;
        //public const int CV_SEQ_KIND_CURVE = 512;
        //public const int CV_SEQ_KIND_GENERIC = 0;
        //public const int CV_SEQ_KIND_GRAPH = 1536;
        //public const int CV_SEQ_KIND_SUBDIV2D = 2048;
        //public const int CV_SEQ_POINT_SET = 12;
        //public const int CV_SEQ_POINT3D_SET = 21;
        //public const int CV_SEQ_POLYGON = 4620;
        //public const int CV_SEQ_POLYGON_TREE = 1024;
        //public const int CV_SEQ_POLYLINE = 524;
        //public const int CV_SEQ_SIMPLE_POLYGON = 12812;
        //public const int CV_SET_ELEM_FREE_FLAG = -2147483648;
        //public const int CV_SET_ELEM_IDX_MASK = 67108863;
        // cvCreateStereoBMState
        public const int CV_STEREO_BM_BASIC = 0;
        public const int CV_STEREO_BM_FISH_EYE = 1;
        public const int CV_STEREO_BM_NARROW = 2;
        // cvCreateStructuringElementEx
        public const int CV_SHAPE_CROSS = 1;
        public const int CV_SHAPE_CUSTOM = 100;
        public const int CV_SHAPE_ELLIPSE = 2;
        public const int CV_SHAPE_RECT = 0;
        // cvCvtColor
        public const int CV_BGR2BGRA = 0;
        public const int CV_RGB2RGBA = 0;
        public const int CV_BGRA2BGR = 1;
        public const int CV_RGBA2RGB = 1;
        public const int CV_RGB2BGRA = 2;
        public const int CV_BGR2RGBA = 2;
        public const int CV_RGBA2BGR = 3;
        public const int CV_BGRA2RGB = 3;
        public const int CV_BGR2RGB = 4;
        public const int CV_RGB2BGR = 4;
        public const int CV_BGRA2RGBA = 5;
        public const int CV_RGBA2BGRA = 5;
        public const int CV_BGR2GRAY = 6;
        public const int CV_RGB2GRAY = 7;
        public const int CV_GRAY2RGB = 8;
        public const int CV_GRAY2BGR = 8;
        public const int CV_GRAY2BGRA = 9;
        public const int CV_GRAY2RGBA = 9;
        public const int CV_BGRA2GRAY = 10;
        public const int CV_RGBA2GRAY = 11;
        public const int CV_BGR2BGR565 = 12;
        public const int CV_RGB2BGR565 = 13;
        public const int CV_BGR5652BGR = 14;
        public const int CV_BGR5652RGB = 15;
        public const int CV_BGRA2BGR565 = 16;
        public const int CV_RGBA2BGR565 = 17;
        public const int CV_BGR5652BGRA = 18;
        public const int CV_BGR5652RGBA = 19;
        public const int CV_GRAY2BGR565 = 20;
        public const int CV_BGR5652GRAY = 21;
        public const int CV_BGR2BGR555 = 22;
        public const int CV_RGB2BGR555 = 23;
        public const int CV_BGR5552BGR = 24;
        public const int CV_BGR5552RGB = 25;
        public const int CV_BGRA2BGR555 = 26;
        public const int CV_RGBA2BGR555 = 27;
        public const int CV_BGR5552BGRA = 28;
        public const int CV_BGR5552RGBA = 29;
        public const int CV_GRAY2BGR555 = 30;
        public const int CV_BGR5552GRAY = 31;
        public const int CV_BGR2XYZ = 32;
        public const int CV_RGB2XYZ = 33;
        public const int CV_XYZ2BGR = 34;
        public const int CV_XYZ2RGB = 35;
        public const int CV_BGR2YCrCb = 36;
        public const int CV_RGB2YCrCb = 37;
        public const int CV_YCrCb2BGR = 38;
        public const int CV_YCrCb2RGB = 39;
        public const int CV_BGR2HSV = 40;
        public const int CV_RGB2HSV = 41;

        public const int CV_BGR2Lab = 44;
        public const int CV_RGB2Lab = 45;
        public const int CV_BayerRG2RGB = 46;
        public const int CV_BayerBG2BGR = 46;
        public const int CV_BayerGB2BGR = 47;
        public const int CV_BayerGR2RGB = 47;
        public const int CV_BayerBG2RGB = 48;
        public const int CV_BayerRG2BGR = 48;
        public const int CV_BayerGB2RGB = 49;
        public const int CV_BayerGR2BGR = 49;
        public const int CV_BGR2Luv = 50;
        public const int CV_RGB2Luv = 51;
        public const int CV_BGR2HLS = 52;
        public const int CV_RGB2HLS = 53;
        public const int CV_HSV2BGR = 54;
        public const int CV_HSV2RGB = 55;
        public const int CV_Lab2BGR = 56;
        public const int CV_Lab2RGB = 57;
        public const int CV_Luv2BGR = 58;
        public const int CV_Luv2RGB = 59;
        public const int CV_HLS2BGR = 60;
        public const int CV_HLS2RGB = 61;
        // (2.2)
        public const int CV_BayerBG2BGR_VNG = 62;
        public const int CV_BayerGB2BGR_VNG = 63;
        public const int CV_BayerRG2BGR_VNG = 64;
        public const int CV_BayerGR2BGR_VNG = 65;
        public const int CV_BayerBG2RGB_VNG = CV_BayerRG2BGR_VNG;
        public const int CV_BayerGB2RGB_VNG = CV_BayerGR2BGR_VNG;
        public const int CV_BayerRG2RGB_VNG = CV_BayerBG2BGR_VNG;
        public const int CV_BayerGR2RGB_VNG = CV_BayerGB2BGR_VNG;
        public const int CV_BGR2HSV_FULL = 66;
        public const int CV_RGB2HSV_FULL = 67;
        public const int CV_BGR2HLS_FULL = 68;
        public const int CV_RGB2HLS_FULL = 69;
        public const int CV_HSV2BGR_FULL = 70;
        public const int CV_HSV2RGB_FULL = 71;
        public const int CV_HLS2BGR_FULL = 72;
        public const int CV_HLS2RGB_FULL = 73;
        public const int CV_LBGR2Lab = 74;
        public const int CV_LRGB2Lab = 75;
        public const int CV_LBGR2Luv = 76;
        public const int CV_LRGB2Luv = 77;
        public const int CV_Lab2LBGR = 78;
        public const int CV_Lab2LRGB = 79;
        public const int CV_Luv2LBGR = 80;
        public const int CV_Luv2LRGB = 81;
        public const int CV_BGR2YUV = 82;
        public const int CV_RGB2YUV = 83;
        public const int CV_YUV2BGR = 84;
        public const int CV_YUV2RGB = 85;

        public const int CV_COLORCVT_MAX = 100;

        // cvDFT
        public const int CV_DXT_FORWARD = 0;
        public const int CV_DXT_INVERSE = 1;
        public const int CV_DXT_INVERSE_SCALE = 3;
        public const int CV_DXT_MUL_CONJ = 8;
        public const int CV_DXT_ROWS = 4;
        public const int CV_DXT_SCALE = 2;
        // cvDistTransform
        public const int CV_DIST_C = 3;
        public const int CV_DIST_FAIR = 5;
        public const int CV_DIST_HUBER = 7;
        public const int CV_DIST_L1 = 1;
        public const int CV_DIST_L12 = 4;
        public const int CV_DIST_L2 = 2;
        public const int CV_DIST_USER = -1;
        public const int CV_DIST_WELSCH = 6;
        public const int CV_DIST_LABEL_CCOMP = 0;
        public const int CV_DIST_LABEL_PIXEL = 1;
        // cvError
        public const int CV_StsOk = 0;	/* everithing is ok                */
        public const int CV_StsBackTrace = -1;	/* pseudo error for back trace     */
        public const int CV_StsError = -2;		/* unknown /unspecified error      */
        public const int CV_StsInternal = -3;	/* internal error (bad state)      */
        public const int CV_StsNoMem = -4;		/* insufficient memory             */
        public const int CV_StsBadArg = -5;		/* function arg_param is bad       */
        public const int CV_StsBadFunc = -6;		/* unsupported function            */
        public const int CV_StsNoConv = -7;		/* iter. didn't converge           */
        public const int CV_StsAutoTrace = -8;	/* tracing                         */

        public const int CV_HeaderIsNull = -9;	/* image header is NULL            */
        public const int CV_BadImageSize = -10;	/* image size is invalid           */
        public const int CV_BadOffset = -11;		/* offset is invalid               */
        public const int CV_BadDataPtr = -12;		/**/
        public const int CV_BadStep = -13;	/**/
        public const int CV_BadModelOrChSeq = -14; /**/
        public const int CV_BadNumChannels = -15;	/**/
        public const int CV_BadNumChannel1U = -16; /**/
        public const int CV_BadDepth = -17;		/**/
        public const int CV_BadAlphaChannel = -18; /**/
        public const int CV_BadOrder = -19;		/**/
        public const int CV_BadOrigin = -20;		/**/
        public const int CV_BadAlign = -21;		/**/
        public const int CV_BadCallBack = -22;		/**/
        public const int CV_BadTileSize = -23;		/**/
        public const int CV_BadCOI = -24;	/**/
        public const int CV_BadROISize = -25;		/**/

        public const int CV_MaskIsTiled = -26;		/**/

        public const int CV_StsNullPtr = -27;		/* null pointer */
        public const int CV_StsVecLengthErr = -28;	/* incorrect vector length */
        public const int CV_StsFilterStructContentErr = -29; /* incorr. filter structure content */
        public const int CV_StsKernelStructContentErr = -30; /* incorr. transform kernel content */
        public const int CV_StsFilterOffsetErr = -31;		/* incorrect filter ofset value */

        /*extra for CV */
        public const int CV_StsBadSize = -201;		/* the input/output structure size is incorrect  */
        public const int CV_StsDivByZero = -202;	/* division by zero */
        public const int CV_StsInplaceNotSupported = -203; /* inplace operation is not supported */
        public const int CV_StsObjectNotFound = -204;		/* request can't be completed */
        public const int CV_StsUnmatchedFormats = -205;	/* formats of input/output arrays differ */
        public const int CV_StsBadFlag = -206;		/* flag is wrong or not supported */
        public const int CV_StsBadPoint = -207;	/* bad CvPoint */
        public const int CV_StsBadMask = -208;		/* bad format of mask (neither 8uC1 nor 8sC1)*/
        public const int CV_StsUnmatchedSizes = -209;		/* sizes of input/output structures do not match */
        public const int CV_StsUnsupportedFormat = -210;	/* the data format/type is not supported by the function*/
        public const int CV_StsOutOfRange = -211;	/* some of parameters are out of range */
        public const int CV_StsParseError = -212;	/* invalid syntax/structure of the parsed file */
        public const int CV_StsNotImplemented = -213;		/* the requested function/feature is not implemented */
        public const int CV_StsBadMemBlock = -214;	/* an allocated block has been corrupted */

        // cvGet/SetErrMode
        public const int CV_ErrModeLeaf = 0;
        public const int CV_ErrModeParent = 1;
        public const int CV_ErrModeSilent = 2;

        // CV_FACE_ELEMENTS
        public const int CV_FACE_MOUTH = 0;
        public const int CV_FACE_LEFT_EYE = 1;
        public const int CV_FACE_RIGHT_EYE = 2;
        // CvFileNode
        public const int CV_NODE_NONE = 0;
        public const int CV_NODE_INT = 1;
        public const int CV_NODE_INTEGER = CV_NODE_INT;
        public const int CV_NODE_REAL = 2;
        public const int CV_NODE_FLOAT = CV_NODE_REAL;
        public const int CV_NODE_STR = 3;
        public const int CV_NODE_STRING = CV_NODE_STR;
        public const int CV_NODE_REF = 4;/* not used */
        public const int CV_NODE_SEQ = 5;
        public const int CV_NODE_MAP = 6;
        public const int CV_NODE_TYPE_MASK = 7;
        public const int CV_NODE_FLOW = 8; /* Used only for writing structures in YAML format. */
        public const int CV_NODE_USER = 16;
        public const int CV_NODE_EMPTY = 32;
        public const int CV_NODE_NAMED = 64;
        // cvFindChessboardCorners
        public const int CV_CALIB_CB_ADAPTIVE_THRESH = 1;
        public const int CV_CALIB_CB_NORMALIZE_IMAGE = 2;
        public const int CV_CALIB_CB_FILTER_QUADS = 4;
        // cvFindContours
        public const int CV_CHAIN_CODE = 0;
        public const int CV_CHAIN_APPROX_NONE = 1;
        public const int CV_CHAIN_APPROX_SIMPLE = 2;
        public const int CV_CHAIN_APPROX_TC89_L1 = 3;
        public const int CV_CHAIN_APPROX_TC89_KCOS = 4;
        public const int CV_LINK_RUNS = 5;
        public const int CV_RETR_EXTERNAL = 0;
        public const int CV_RETR_LIST = 1;
        public const int CV_RETR_CCOMP = 2;
        public const int CV_RETR_TREE = 3;
        // cvFindDominantPoints
        public const int CV_DOMINANT_IPAN = 1;
        // cvFindFundamentalMat
        public const int CV_FM_7POINT = 1;
        public const int CV_FM_8POINT = 2;
        public const int CV_FM_LMEDS = 4;
        public const int CV_FM_LMEDS_ONLY = 4;
        public const int CV_FM_RANSAC = 8;
        public const int CV_FM_RANSAC_ONLY = 8;
        // cvFindHomography
        public const int CV_LMEDS = 4;
        public const int CV_RANSAC = 8;
        // cvFindStereoCorrespondence
        public const int CV_UNDEF_SC_PARAM = 12345;
        public const int CV_DISPARITY_BIRCHFIELD = 0;
        public const int CV_IDP_BIRCHFIELD_PARAM1 = 25;
        public const int CV_IDP_BIRCHFIELD_PARAM2 = 5;
        public const int CV_IDP_BIRCHFIELD_PARAM3 = 12;
        public const int CV_IDP_BIRCHFIELD_PARAM4 = 15;
        public const int CV_IDP_BIRCHFIELD_PARAM5 = 25;
        // cvFloodFill
        public const int CV_FLOODFILL_FIXED_RANGE = 65536;
        public const int CV_FLOODFILL_MASK_ONLY = 131072;
        // cvFontQt
        public const int CV_FONT_LIGHT = 25;//QFont::Light,
        public const int CV_FONT_NORMAL = 50;//QFont::Normal,
        public const int CV_FONT_DEMIBOLD = 63;//QFont::DemiBold,
        public const int CV_FONT_BOLD = 75;//QFont::Bold,
        public const int CV_FONT_BLACK = 87;//QFont::Black
        public const int CV_STYLE_NORMAL = 0;//QFont::StyleNormal,
        public const int CV_STYLE_ITALIC = 1;//QFont::StyleItalic,
        public const int CV_STYLE_OBLIQUE = 2;//QFont::StyleOblique
        // cvGEMM
        public const int CV_GEMM_A_T = 1;
        public const int CV_GEMM_B_T = 2;
        public const int CV_GEMM_C_T = 4;
        // CvGraphEdge/Vtx
        public const int CV_GRAPH_ITEM_VISITED_FLAG = 1073741824;
        public const int CV_GRAPH_SEARCH_TREE_NODE_FLAG = 536870912;
        public const int CV_GRAPH_FORWARD_EDGE_FLAG = 268435456;
        // cvHaarDetectObjects
        public const int CV_HAAR_DO_CANNY_PRUNING = 1;
        public const int CV_HAAR_SCALE_IMAGE = 2;
        public const int CV_HAAR_FIND_BIGGEST_OBJECT = 4;
        public const int CV_HAAR_DO_ROUGH_SEARCH = 8;
        // CvHaarFeature
        public const int CV_HAAR_FEATURE_MAX = 3;
        // CvHistogram
        public const int CV_HIST_ARRAY = 0;
        public const int CV_HIST_SPARSE = 1;
        public const int CV_COMP_CHISQR = 1;
        public const int CV_COMP_CORREL = 0;
        public const int CV_COMP_INTERSECT = 2;
        public const int CV_COMP_BHATTACHARYYA = 3;
        // cvHoughCircles
        public const int CV_HOUGH_GRADIENT = 3;
        // cvHoughLines
        public const int CV_HOUGH_STANDARD = 0;
        public const int CV_HOUGH_PROBABILISTIC = 1;
        public const int CV_HOUGH_MULTI_SCALE = 2;
        // cvInitFont
        public const int CV_FONT_HERSHEY_SIMPLEX = 0;
        public const int CV_FONT_HERSHEY_PLAIN = 1;
        public const int CV_FONT_HERSHEY_DUPLEX = 2;
        public const int CV_FONT_HERSHEY_COMPLEX = 3;
        public const int CV_FONT_HERSHEY_TRIPLEX = 4;
        public const int CV_FONT_HERSHEY_COMPLEX_SMALL = 5;
        public const int CV_FONT_HERSHEY_SCRIPT_SIMPLEX = 6;
        public const int CV_FONT_HERSHEY_SCRIPT_COMPLEX = 7;
        public const int CV_FONT_ITALIC = 16;
        public const int CV_FONT_VECTOR0 = CV_FONT_HERSHEY_SIMPLEX;
        // cvInpaint
        public const int CV_INPAINT_NS = 0;
        public const int CV_INPAINT_TELEA = 1;
        // cvInvert
        public const int CV_LU = 0;
        public const int CV_SVD = 1;
        public const int DECOMP_EIG = 2;
        public const int CV_SVD_SYM = 2;
        public const int CV_CHOLESKY = 3;
        public const int CV_QR = 4;
        public const int CV_NORMAL = 16;
        // cvKMeans2
        public const int CV_KMEANS_USE_INITIAL_LABELS = 1;
        // cvLoadImage
        public const int CV_LOAD_IMAGE_UNCHANGED = -1;
        public const int CV_LOAD_IMAGE_GRAYSCALE = 0;
        public const int CV_LOAD_IMAGE_COLOR = 1;
        public const int CV_LOAD_IMAGE_ANYDEPTH = 2;
        public const int CV_LOAD_IMAGE_ANYCOLOR = 3;
        // cvMatchContourTrees
        public const int CV_CONTOUR_TREES_MATCH_I1 = 1;
        // cvMatchShapes
        public const int CV_CONTOURS_MATCH_I1 = 1;
        public const int CV_CONTOURS_MATCH_I2 = 2;
        public const int CV_CONTOURS_MATCH_I3 = 3;
        // cvMatchTemplate
        public const int CV_TM_SQDIFF = 0;
        public const int CV_TM_SQDIFF_NORMED = 1;
        public const int CV_TM_CCORR = 2;
        public const int CV_TM_CCORR_NORMED = 3;
        public const int CV_TM_CCOEFF = 4;
        public const int CV_TM_CCOEFF_NORMED = 5;
        // cvMorphologyEx
        public const int CV_MOP_OPEN = 2;
        public const int CV_MOP_CLOSE = 3;
        public const int CV_MOP_GRADIENT = 4;
        public const int CV_MOP_TOPHAT = 5;
        public const int CV_MOP_BLACKHAT = 6;
        // cvMouseCallback
        public const int CV_EVENT_MOUSEMOVE = 0;
        public const int CV_EVENT_LBUTTONDOWN = 1;
        public const int CV_EVENT_RBUTTONDOWN = 2;
        public const int CV_EVENT_MBUTTONDOWN = 3;
        public const int CV_EVENT_LBUTTONUP = 4;
        public const int CV_EVENT_RBUTTONUP = 5;
        public const int CV_EVENT_MBUTTONUP = 6;
        public const int CV_EVENT_LBUTTONDBLCLK = 7;
        public const int CV_EVENT_RBUTTONDBLCLK = 8;
        public const int CV_EVENT_MBUTTONDBLCLK = 9;
        public const int CV_EVENT_FLAG_LBUTTON = 1;
        public const int CV_EVENT_FLAG_RBUTTON = 2;
        public const int CV_EVENT_FLAG_MBUTTON = 4;
        public const int CV_EVENT_FLAG_CTRLKEY = 8;
        public const int CV_EVENT_FLAG_SHIFTKEY = 16;
        public const int CV_EVENT_FLAG_ALTKEY = 32;
        // cvNamedWindow
        public const int CV_WINDOW_AUTOSIZE = 1;

        // cvNamedWindow(only for Qt)
        public const int CV_GUI_EXPANDED = 0;
        public const int CV_GUI_NORMAL = 2;

        // cvNorm
        public const int CV_C = 1;
        public const int CV_L1 = 2;
        public const int CV_L2 = 4;
        public const int CV_NORM_MASK = 7;
        public const int CV_RELATIVE = 8;
        public const int CV_DIFF = 16;
        public const int CV_MINMAX = 32;
        public const int CV_DIFF_C = (CV_DIFF | CV_C);
        public const int CV_DIFF_L1 = (CV_DIFF | CV_L1);
        public const int CV_DIFF_L2 = (CV_DIFF | CV_L2);
        public const int CV_RELATIVE_C = (CV_RELATIVE | CV_C);
        public const int CV_RELATIVE_L1 = (CV_RELATIVE | CV_L1);
        public const int CV_RELATIVE_L2 = (CV_RELATIVE | CV_L2);
        // cvOpenFileStorage
        public const int CV_STORAGE_READ = 0;
        public const int CV_STORAGE_WRITE = 1;
        public const int CV_STORAGE_WRITE_TEXT = 1;
        public const int CV_STORAGE_WRITE_BINARY = 1;
        public const int CV_STORAGE_APPEND = 2;
        public const int CV_STORAGE_MEMORY = 4;
        public const int CV_STORAGE_FORMAT_MASK = (7 << 3);
        public const int CV_STORAGE_FORMAT_AUTO = 0;
        public const int CV_STORAGE_FORMAT_XML = 8;
        public const int CV_STORAGE_FORMAT_YAML = 16;
        // cvPyrDown, PyrUp, ...
        public const int CV_GAUSSIAN_5x5 = 7;
        // cvRandArr
        public const int CV_RAND_UNI = 0;
        public const int CV_RAND_NORMAL = 1;
        // cvReduce
        public const int CV_REDUCE_SUM = 0;
        public const int CV_REDUCE_AVG = 1;
        public const int CV_REDUCE_MAX = 2;
        public const int CV_REDUCE_MIN = 3;
        // cvSaveImage
        public const int CV_IMWRITE_JPEG_QUALITY = 1;
        public const int CV_IMWRITE_PNG_COMPRESSION = 16;
        public const int CV_IMWRITE_PXM_BINARY = 32;
        // cvSet
        public const int CV_SET_ELEM_IDX_MASK_ = 67108863;
        public const int CV_SET_ELEM_FREE_FLAG_ = -2147483648;
        // cvSmooth
        public const int CV_BLUR_NO_SCALE = 0;
        public const int CV_BLUR = 1;
        public const int CV_GAUSSIAN = 2;
        public const int CV_MEDIAN = 3;
        public const int CV_BILATERAL = 4;
        // cvSnakeImage
        public const int CV_VALUE = 1;
        public const int CV_ARRAY = 2;
        // cvSort
        public const int CV_SORT_EVERY_ROW = 0;
        public const int CV_SORT_EVERY_COLUMN = 1;
        public const int CV_SORT_ASCENDING = 0;
        public const int CV_SORT_DESCENDING = 16;
        // cvStereoRectify
        public const int CV_CALIB_ZERO_DISPARITY = 1024;
        // cvSubdiv2DGetEdge
        public const int CV_NEXT_AROUND_ORG = 0;
        public const int CV_NEXT_AROUND_DST = 34;
        public const int CV_PREV_AROUND_ORG = 17;
        public const int CV_PREV_AROUND_DST = 51;
        public const int CV_NEXT_AROUND_LEFT = 19;
        public const int CV_NEXT_AROUND_RIGHT = 49;
        public const int CV_PREV_AROUND_LEFT = 32;
        public const int CV_PREV_AROUND_RIGHT = 2;
        // cvSubdiv2DLocate
        public const int CV_PTLOC_ERROR = -2;
        public const int CV_PTLOC_OUTSIDE_RECT = -1;
        public const int CV_PTLOC_INSIDE = 0;
        public const int CV_PTLOC_VERTEX = 1;
        public const int CV_PTLOC_ON_EDGE = 2;
        // cvSVD
        public const int CV_SVD_MODIFY_A = 1;
        public const int CV_SVD_U_T = 2;
        public const int CV_SVD_V_T = 4;
        // CvTermCriteria
        public const int CV_TERMCRIT_ITER = 1;
        public const int CV_TERMCRIT_NUMBER = 1;
        public const int CV_TERMCRIT_EPS = 2;
        // cvThreshold
        public const int CV_THRESH_BINARY = 0;
        public const int CV_THRESH_BINARY_INV = 1;
        public const int CV_THRESH_MASK = 7;
        public const int CV_THRESH_OTSU = 8;
        public const int CV_THRESH_TOZERO = 3;
        public const int CV_THRESH_TOZERO_INV = 4;
        public const int CV_THRESH_TRUNC = 2;
        // cvWarpAffine
        public const int CV_INTER_NN = 0;
        public const int CV_INTER_LINEAR = 1;
        public const int CV_INTER_CUBIC = 2;
        public const int CV_INTER_AREA = 3;
        public const int CV_INTER_LANCZOS4 = 4;
        public const int CV_WARP_FILL_OUTLIERS = 8;
        public const int CV_WARP_INVERSE_MAP = 16;
        // IplImage
        public const int IPL_ORIGIN_TL = 0;
        public const int IPL_ORIGIN_BL = 1;

        // cvVideoWriter
        public const int CV_FOURCC_DEFAULT = -1;
        public const int CV_FOURCC_PROMPT = -1;
        public const int CV_FOURCC_CVID = 1145656899;
        public const int CV_FOURCC_DIB = 541215044;
        public const int CV_FOURCC_DIVX = 1482049860;
        public const int CV_FOURCC_H261 = 825635400;
        public const int CV_FOURCC_H263 = 859189832;
        public const int CV_FOURCC_H264 = 875967048;
        public const int CV_FOURCC_IV32 = 842225225;
        public const int CV_FOURCC_IV41 = 825513545;
        public const int CV_FOURCC_IV50 = 808801865;
        public const int CV_FOURCC_IYUB = 1448433993;
        public const int CV_FOURCC_MJPG = 1196444237;
        public const int CV_FOURCC_MP42 = 842289229;
        public const int CV_FOURCC_MP43 = 859066445;
        public const int CV_FOURCC_MPG4 = 877088845;
        public const int CV_FOURCC_MSVC = 1129730893;
        public const int CV_FOURCC_PIM1 = 827148624;
        public const int CV_FOURCC_XVID = 1145656920;
    }
}
