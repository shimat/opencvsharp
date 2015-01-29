
#pragma warning disable 1591
// ReSharper disable InconsistentNaming

namespace OpenCvSharp
{
#if LANG_JP
	/// <summary>
	/// 色空間の変換の方法
	/// </summary>
#else
    /// <summary>
    /// Color conversion operation for cvCvtColor
    /// </summary>
#endif
	public enum ColorConversion : int
	{
        BgrToBgra = CvConst.COLOR_BGR2BGRA, // 1
        RgbToRgba = CvConst.COLOR_RGB2RGBA,
        BgraToBgr = CvConst.COLOR_BGRA2BGR,
        RgbaToRgb = CvConst.COLOR_RGBA2RGB,
        BgrToRgba = CvConst.COLOR_BGR2RGBA, 
        RgbToBgra = CvConst.COLOR_RGB2BGRA,
        RgbaToBgr = CvConst.COLOR_RGBA2BGR,
        BgraToRgb = CvConst.COLOR_BGRA2RGB,
        BgrToRgb = CvConst.COLOR_BGR2RGB,
        RgbToBgr = CvConst.COLOR_RGB2BGR,  
        BgraToRgba = CvConst.COLOR_BGRA2RGBA, // 5
        RgbaToBgra = CvConst.COLOR_RGBA2BGRA,
        BgrToGray = CvConst.COLOR_BGR2GRAY,
        RgbToGray = CvConst.COLOR_RGB2GRAY,
        GrayToBgr = CvConst.COLOR_GRAY2BGR,
        GrayToRgb = CvConst.COLOR_GRAY2RGB,
        GrayToBgra = CvConst.COLOR_GRAY2BGRA,
        GrayToRgba = CvConst.COLOR_GRAY2RGBA,
        BgraToGray = CvConst.COLOR_BGRA2GRAY, // 10
        RgbaToGray = CvConst.COLOR_RGBA2GRAY,
        BgrToBgr565 = CvConst.COLOR_BGR2BGR565,
        RgbToBgr565 = CvConst.COLOR_RGB2BGR565,
        Bgr565ToBgr = CvConst.COLOR_BGR5652BGR,
        Bgr565ToRgb = CvConst.COLOR_BGR5652RGB, // 15
        BgraToBgr565 = CvConst.COLOR_BGRA2BGR565,
        RgbaToBgr565 = CvConst.COLOR_RGBA2BGR565,
        Bgr565ToBgra = CvConst.COLOR_BGR5652BGRA,
        Bgr565ToRgba = CvConst.COLOR_BGR5652RGBA,
        GrayToBgr565 = CvConst.COLOR_GRAY2BGR565, // 20
        Bgr565ToGray = CvConst.COLOR_BGR5652GRAY,
        BgrToBgr555 = CvConst.COLOR_BGR2BGR555,
        RgbToBgra555 = CvConst.COLOR_RGB2BGR555,
        Bgr555ToBgr = CvConst.COLOR_BGR5552BGR,
        Bgr555ToRgb = CvConst.COLOR_BGR5552RGB, // 25
        BgraToBgr555 = CvConst.COLOR_BGRA2BGR555,
        RgbaToBgr555 = CvConst.COLOR_RGBA2BGR555,
        Bgr555ToBgra = CvConst.COLOR_BGR5552BGRA,
        Bgr555ToRgba = CvConst.COLOR_BGR5552RGBA,
        GrayToBgr555 = CvConst.COLOR_GRAY2BGR555, // 30
        Bgr555ToGray = CvConst.COLOR_BGR5552GRAY,
        BgrToXyz = CvConst.COLOR_BGR2XYZ,
        RgbToXyz = CvConst.COLOR_RGB2XYZ,
        XyzToBgr = CvConst.COLOR_XYZ2BGR,
        XyzToRgb = CvConst.COLOR_XYZ2RGB, // 35
        BgrToCrCb = CvConst.COLOR_BGR2YCrCb,
        RgbToCrCb = CvConst.COLOR_RGB2YCrCb,
        CrCbToBgr = CvConst.COLOR_YCrCb2BGR,
        CrCbToRgb = CvConst.COLOR_YCrCb2RGB,
        BgrToHsv = CvConst.COLOR_BGR2HSV, // 40
        RgbToHsv = CvConst.COLOR_RGB2HSV, // 41
        BgrToLab = CvConst.COLOR_BGR2Lab, // 44
        RgbToLab = CvConst.COLOR_RGB2Lab, // 45
        BayerBgToBgr = CvConst.COLOR_BayerBG2BGR,
        BayerGbToBgr = CvConst.COLOR_BayerGB2BGR,
        BayerRgToBgr = CvConst.COLOR_BayerRG2BGR,
        BayerGrToBgr = CvConst.COLOR_BayerGR2BGR,
        BayerBgToRgb = CvConst.COLOR_BayerBG2RGB,
        BayerGbToRgb = CvConst.COLOR_BayerGB2RGB,
        BayerRgToRgb = CvConst.COLOR_BayerRG2RGB,
        BayerGrToRgb = CvConst.COLOR_BayerGR2RGB,
        BgrToLuv = CvConst.COLOR_BGR2Luv, // 50
        RgbToLuv = CvConst.COLOR_RGB2Luv,
        BgrToHls = CvConst.COLOR_BGR2HLS,
        RgbToHls = CvConst.COLOR_RGB2HLS,
        HsvToBgr = CvConst.COLOR_HSV2BGR,
        HsvToRgb = CvConst.COLOR_HSV2RGB, // 55
        LabToBgr = CvConst.COLOR_Lab2BGR,
        LabToRgb = CvConst.COLOR_Lab2RGB,
        LuvToBgr = CvConst.COLOR_Luv2BGR,
        LuvToRgb = CvConst.COLOR_Luv2RGB,
        HlsToBgr = CvConst.COLOR_HLS2BGR, // 60
        HlsToRgb = CvConst.COLOR_HLS2RGB,
        // (2.2)
        BayerBgToBgr_Vng = CvConst.COLOR_BayerBG2BGR_VNG,
        BayerGbToBgr_Vng = CvConst.COLOR_BayerGB2BGR_VNG,
        BayerRgToBgr_Vng = CvConst.COLOR_BayerRG2BGR_VNG,
        BayerGrToBgr_Vng = CvConst.COLOR_BayerGR2BGR_VNG, // 65
        BayerBgToRgb_Vng = CvConst.COLOR_BayerBG2RGB_VNG,
        BayerGbToRgb_Vng = CvConst.COLOR_BayerGB2RGB_VNG,
        BayerRgToRgb_Vng = CvConst.COLOR_BayerRG2RGB_VNG,
        BayerGrToRgb_Vng = CvConst.COLOR_BayerGR2RGB_VNG,
        BgrToHsv_Full = CvConst.COLOR_BGR2HSV_FULL,
        RgbToHsv_Full = CvConst.COLOR_RGB2HSV_FULL,
        BgrToHls_Full = CvConst.COLOR_BGR2HLS_FULL,
        RgbToHls_Full = CvConst.COLOR_RGB2HLS_FULL,
        HsvToBgr_Full = CvConst.COLOR_HSV2BGR_FULL, // 70
        HsvToRgb_Full = CvConst.COLOR_HSV2RGB_FULL,
        HlsToBgr_Full = CvConst.COLOR_HLS2BGR_FULL,
        HlsToRgb_Full = CvConst.COLOR_HLS2RGB_FULL,
        LbgrToLab = CvConst.COLOR_LBGR2Lab,
        LrgbToLab = CvConst.COLOR_LRGB2Lab, // 75
        LbgrToLuv = CvConst.COLOR_LBGR2Luv,
        LrgbToLuv = CvConst.COLOR_LRGB2Luv,
        LabToLbgr = CvConst.COLOR_Lab2LBGR,
        LabToLrgb = CvConst.COLOR_Lab2LRGB,
        LuvToLbgr = CvConst.COLOR_Luv2LBGR, // 80
        LubToLrgb = CvConst.COLOR_Luv2LRGB,
        BgrToYuv = CvConst.COLOR_BGR2YUV,
        RgbToYuv = CvConst.COLOR_RGB2YUV,
        YuvToBgr = CvConst.COLOR_YUV2BGR,
        YuvToRgb = CvConst.COLOR_YUV2RGB, // 85
        
        // 
        BayerBgToGray = CvConst.COLOR_BayerBG2GRAY,
        BayerGbToGray = CvConst.COLOR_BayerGB2GRAY,
        BayerRGToGray = CvConst.COLOR_BayerRG2GRAY,
        BayerGRToGray = CvConst.COLOR_BayerGR2GRAY,
            //YUV 4:2:0 formats family
        YuvToRGB_NV12 = CvConst.COLOR_YUV2RGB_NV12,
        YuvToBGR_NV12 = CvConst.COLOR_YUV2BGR_NV12,
        YuvToRGB_NV21 = CvConst.COLOR_YUV2RGB_NV21,
        YuvToBGR_NV21 = CvConst.COLOR_YUV2BGR_NV21,
        YUV420spToRgb = CvConst.COLOR_YUV420sp2RGB,
        YUV420spToBgr = CvConst.COLOR_YUV420sp2BGR,
        YuvToRgba_NV12 = CvConst.COLOR_YUV2RGBA_NV12,
        YuvToBgra_NV12 = CvConst.COLOR_YUV2BGRA_NV12,
        YuvToRgba_NV21 = CvConst.COLOR_YUV2RGBA_NV21,
        YuvToBgra_NV21 = CvConst.COLOR_YUV2BGRA_NV21,
        YUV420spToRgba = CvConst.COLOR_YUV420sp2RGBA,
        YUV420spToBgra = CvConst.COLOR_YUV420sp2BGRA,
        YuvToRgb_YV12 = CvConst.COLOR_YUV2RGB_YV12,
        YuvToBgr_YV12 = CvConst.COLOR_YUV2BGR_YV12,
        YuvToRgb_IYUV = CvConst.COLOR_YUV2RGB_IYUV,
        YuvToBgr_IYUV = CvConst.COLOR_YUV2BGR_IYUV,
        YuvToRgb_I420 = CvConst.COLOR_YUV2RGB_I420,
        YuvToBgr_I420 = CvConst.COLOR_YUV2BGR_I420,
        YUV420pToRgb = CvConst.COLOR_YUV420p2RGB,
        YUV420pToBgr = CvConst.COLOR_YUV420p2BGR,
        YuvToRgba_YV12 = CvConst.COLOR_YUV2RGBA_YV12,
        YuvToBgra_YV12 = CvConst.COLOR_YUV2BGRA_YV12,
        YuvToRgba_IYUV = CvConst.COLOR_YUV2RGBA_IYUV,
        YuvToBgra_IYUV = CvConst.COLOR_YUV2BGRA_IYUV,
        YuvToRgba_I420 = CvConst.COLOR_YUV2RGBA_I420,
        YuvToBgra_I420 = CvConst.COLOR_YUV2BGRA_I420,
        YUV420pToRgba = CvConst.COLOR_YUV420p2RGBA,
        YUV420pToBgra = CvConst.COLOR_YUV420p2BGRA,
        YuvToGray_420 = CvConst.COLOR_YUV2GRAY_420,
        YuvToGray_NV21 = CvConst.COLOR_YUV2GRAY_NV21,
        YuvToGray_NV12 = CvConst.COLOR_YUV2GRAY_NV12,
        YuvToGray_YV12 = CvConst.COLOR_YUV2GRAY_YV12,
        YuvToGray_IYUV = CvConst.COLOR_YUV2GRAY_IYUV,
        YuvToGray_I420 = CvConst.COLOR_YUV2GRAY_I420,
        YUV420spToGray = CvConst.COLOR_YUV420sp2GRAY,
        YUV420pToGray = CvConst.COLOR_YUV420p2GRAY,
            //YUV 4:2:2 formats family
        YuvToRgb_UYVY = CvConst.COLOR_YUV2RGB_UYVY,
        YuvToBgr_UYVY = CvConst.COLOR_YUV2BGR_UYVY,
            //COLOR_YUV2RGB_VYUY = 109,
            //COLOR_YUV2BGR_VYUY = 110,
        YuvToRgb_Y422 = CvConst.COLOR_YUV2RGB_Y422,
        YuvToBgr_Y422 = CvConst.COLOR_YUV2BGR_Y422,
        YuvToRgb_UYNV = CvConst.COLOR_YUV2RGB_UYNV,
        YuvToBgr_UYNV = CvConst.COLOR_YUV2BGR_UYNV,
        YuvToRgba_UYVY = CvConst.COLOR_YUV2RGBA_UYVY,
        YuvToBgra_UYVY = CvConst.COLOR_YUV2BGRA_UYVY,
            //COLOR_YUV2RGBA_VYUY = 113,
            //COLOR_YUV2BGRA_VYUY = 114,
        YuvToRgba_Y422 = CvConst.COLOR_YUV2RGBA_Y422,
        YuvToBgra_Y422 = CvConst.COLOR_YUV2BGRA_Y422,
        YuvToRgba_UYNV = CvConst.COLOR_YUV2RGBA_UYNV,
        YuvToBgra_UYNV = CvConst.COLOR_YUV2BGRA_UYNV,
        YuvToRgb_YUY2 = CvConst.COLOR_YUV2RGB_YUY2,
        YuvToBgr_YUY2 = CvConst.COLOR_YUV2BGR_YUY2,
        YuvToRgb_YVYU = CvConst.COLOR_YUV2RGB_YVYU,
        YuvToBgr_YVYU = CvConst.COLOR_YUV2BGR_YVYU,
        YuvToRgb_YUYV = CvConst.COLOR_YUV2RGB_YUYV,
        YuvToBgr_YUYV = CvConst.COLOR_YUV2BGR_YUYV,
        YuvToRgb_YUNV = CvConst.COLOR_YUV2RGB_YUNV,
        YuvToBgr_YUNV = CvConst.COLOR_YUV2BGR_YUNV,
        YuvToRgba_YUY2 = CvConst.COLOR_YUV2RGBA_YUY2,
        YuvToBgra_YUY2 = CvConst.COLOR_YUV2BGRA_YUY2,
        YuvToRgba_YVYU = CvConst.COLOR_YUV2RGBA_YVYU,
        YuvToBgra_YVYU = CvConst.COLOR_YUV2BGRA_YVYU,
        YuvToRgba_YUYV = CvConst.COLOR_YUV2RGBA_YUYV,
        YuvToBgra_YUYV = CvConst.COLOR_YUV2BGRA_YUYV,
        YuvToRgba_YUNV = CvConst.COLOR_YUV2RGBA_YUNV,
        YuvToBgra_YUNV = CvConst.COLOR_YUV2BGRA_YUNV,
        YuvToGray_UYVY = CvConst.COLOR_YUV2GRAY_UYVY,
        YuvToGray_YUY2 = CvConst.COLOR_YUV2GRAY_YUY2,
            //COLOR_YUV2GRAY_VYUY = COLOR_YUV2GRAY_UYVY,
        YuvToGray_Y422 = CvConst.COLOR_YUV2GRAY_Y422,
        YuvToGray_UYNV = CvConst.COLOR_YUV2GRAY_UYNV,
        YuvToGray_YVYU = CvConst.COLOR_YUV2GRAY_YVYU,
        YuvToGray_YUYV = CvConst.COLOR_YUV2GRAY_YUYV,
        YuvToGray_YUNV = CvConst.COLOR_YUV2GRAY_YUNV,
            // alpha premultiplication
        RgbaTomRgba = CvConst.COLOR_RGBA2mRGBA,
        mRgbaToRgba = CvConst.COLOR_mRGBA2RGBA,
        RgbToYuv_I420 = CvConst.COLOR_RGB2YUV_I420,
        BgrToYuv_I420 = CvConst.COLOR_BGR2YUV_I420,
        RgbToYuv_IYUV = CvConst.COLOR_RGB2YUV_IYUV,
        BgrToYuv_IYUV = CvConst.COLOR_BGR2YUV_IYUV,
        RgbaToYuv_I420 = CvConst.COLOR_RGBA2YUV_I420,
        BgraToYuv_I420 = CvConst.COLOR_BGRA2YUV_I420,
        RgbaToYuv_IYUV = CvConst.COLOR_RGBA2YUV_IYUV,
        BgraToYuv_IYUV = CvConst.COLOR_BGRA2YUV_IYUV,
        RgbToYuv_YV12 = CvConst.COLOR_RGB2YUV_YV12,
        BgrToYuv_YV12 = CvConst.COLOR_BGR2YUV_YV12,
        RgbaToYuv_YV12 = CvConst.COLOR_RGBA2YUV_YV12,
        BgraToYuv_YV12 = CvConst.COLOR_BGRA2YUV_YV12,
            
	}
}
