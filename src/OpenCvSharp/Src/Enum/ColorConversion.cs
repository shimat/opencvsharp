/*
 * (C) 2008-2013 Schima
 * This code is licenced under the LGPL.
 */

using System;
using System.Collections.Generic;
using System.Text;

#pragma warning disable 1591

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
		BgrToBgra = CvConst.CV_BGR2BGRA,
		RgbToRgba =  CvConst.CV_RGB2RGBA,

		BgraToBgr =  CvConst.CV_BGRA2BGR,
		RgbaToRgb =  CvConst.CV_RGBA2RGB,

		BgrToRgba =  CvConst.CV_BGR2RGBA,
		RgbToBgra =  CvConst.CV_RGB2BGRA,

		RgbaToBgr =  CvConst.CV_RGBA2BGR,
		BgraToRgb =  CvConst.CV_BGRA2RGB,

		BgrToRgb =  CvConst.CV_BGR2RGB,
		RgbToBgr =  CvConst.CV_RGB2BGR,

		BgraToRgba =  CvConst.CV_BGRA2RGBA,
		RgbaToBgra =  CvConst.CV_RGBA2BGRA,

		BgrToGray =  CvConst.CV_BGR2GRAY,
		RgbToGray =  CvConst.CV_RGB2GRAY,
		GrayToBgr =  CvConst.CV_GRAY2BGR,
		GrayToRgb =  CvConst.CV_GRAY2RGB,
		GrayToBgra =  CvConst.CV_GRAY2BGRA,
		GrayToRgba =  CvConst.CV_GRAY2RGBA,
		BgraToGray =  CvConst.CV_BGRA2GRAY,
		RgbaToGray =  CvConst.CV_RGBA2GRAY,

		BgrToBgr565 =  CvConst.CV_BGR2BGR565,
		RgbToBgr565 =  CvConst.CV_RGB2BGR565,
		Bgr565ToBgr =  CvConst.CV_BGR5652BGR,
		Bgr565ToRgb =  CvConst.CV_BGR5652RGB,
		BgraToBgr565 =  CvConst.CV_BGRA2BGR565,
		RgbaToBgr565 =  CvConst.CV_RGBA2BGR565,
		Bgr565ToBgra =  CvConst.CV_BGR5652BGRA,
		Bgr565ToRgba =  CvConst.CV_BGR5652RGBA,

		GrayToBgr565 =  CvConst.CV_GRAY2BGR565,
		Bgr565ToGray =  CvConst.CV_BGR5652GRAY,

		BgrToBgr555 =  CvConst.CV_BGR2BGR555,
		RgbToBgra555 =  CvConst.CV_RGB2BGR555,
		Bgr555ToBgr =  CvConst.CV_BGR5552BGR,
		Bgr555ToRgb =  CvConst.CV_BGR5552RGB,
		BgraToBgr555 =  CvConst.CV_BGRA2BGR555,
		RgbaToBgr555 =  CvConst.CV_RGBA2BGR555,
		Bgr555ToBgra =  CvConst.CV_BGR5552BGRA,
		Bgr555ToRgba =  CvConst.CV_BGR5552RGBA,

		GrayToBgr555 =  CvConst.CV_GRAY2BGR555,
		Bgr555ToGray =  CvConst.CV_BGR5552GRAY,

		BgrToXyz =  CvConst.CV_BGR2XYZ,
		RgbToXyz =  CvConst.CV_RGB2XYZ,
		XyzToBgr =  CvConst.CV_XYZ2BGR,
		XyzToRgb =  CvConst.CV_XYZ2RGB,

		BgrToCrCb =  CvConst.CV_BGR2YCrCb,
		RgbToCrCb =  CvConst.CV_RGB2YCrCb,
		CrCbToBgr =  CvConst.CV_YCrCb2BGR,
		CrCbToRgb =  CvConst.CV_YCrCb2RGB,

		BgrToHsv =  CvConst.CV_BGR2HSV,
		RgbToHsv =  CvConst.CV_RGB2HSV,

		BgrToLab =  CvConst.CV_BGR2Lab,
		RgbToLab =  CvConst.CV_RGB2Lab,

		BayerBgToBgr =  CvConst.CV_BayerBG2BGR,
		BayerGbToBgr =  CvConst.CV_BayerGB2BGR,
		BayerRgToBgr =  CvConst.CV_BayerRG2BGR,
		BayerGrToBgr =  CvConst.CV_BayerGR2BGR,

		BayerBgToRgb =  CvConst.CV_BayerBG2RGB,
		BayerGbToRgb =  CvConst.CV_BayerGB2RGB,
		BayerRgToRgb =  CvConst.CV_BayerRG2RGB,
		BayerGrToRgb =  CvConst.CV_BayerGR2RGB,

		BgrToLuv =  CvConst.CV_BGR2Luv,
		RgbToLuv =  CvConst.CV_RGB2Luv,
		BgrToHls =  CvConst.CV_BGR2HLS,
		RgbToHls =  CvConst.CV_RGB2HLS,

		HsvToBgr =  CvConst.CV_HSV2BGR,
		HsvToRgb =  CvConst.CV_HSV2RGB,

		LabToBgr =  CvConst.CV_Lab2BGR,
		LabToRgb =  CvConst.CV_Lab2RGB,
		LuvToBgr =  CvConst.CV_Luv2BGR,
		LuvToRgb =  CvConst.CV_Luv2RGB,
		HlsToBgr =  CvConst.CV_HLS2BGR,
		HlsToRgb =  CvConst.CV_HLS2RGB,

        // (2.2)
        BayerBgToBgr_Vng = CvConst.CV_BayerBG2BGR_VNG,
        BayerGbToBgr_Vng = CvConst.CV_BayerGB2BGR_VNG,
        BayerRgToBgr_Vng = CvConst.CV_BayerRG2BGR_VNG,
        BayerGrToBgr_Vng = CvConst.CV_BayerGR2BGR_VNG,
        BayerBgToRgb_Vng = CvConst.CV_BayerBG2RGB_VNG,
        BayerGbToRgb_Vng = CvConst.CV_BayerGB2RGB_VNG,
        BayerRgToRgb_Vng = CvConst.CV_BayerRG2RGB_VNG,
        BayerGrToRgb_Vng = CvConst.CV_BayerGR2RGB_VNG,
        BgrToHsv_Full = CvConst.CV_BGR2HSV_FULL,
        RgbToHsv_Full = CvConst.CV_RGB2HSV_FULL,
        BgrToHls_Full = CvConst.CV_BGR2HLS_FULL,
        RgbToHls_Full = CvConst.CV_RGB2HLS_FULL,
        HsvToBgr_Full = CvConst.CV_HSV2BGR_FULL,
        HsvToRgb_Full = CvConst.CV_HSV2RGB_FULL,
        HlsToBgr_Full = CvConst.CV_HLS2BGR_FULL,
        HlsToRgb_Full = CvConst.CV_HLS2RGB_FULL,
        LbgrToLab = CvConst.CV_LBGR2Lab,
        LrgbToLab = CvConst.CV_LRGB2Lab,
        LbgrToLuv = CvConst.CV_LBGR2Luv,
        LrgbToLuv = CvConst.CV_LRGB2Luv,
        LabToLbgr = CvConst.CV_Lab2LBGR,
        LabToLrgb = CvConst.CV_Lab2LRGB,
        LuvToLbgr = CvConst.CV_Luv2LBGR,
        LubToLrgb = CvConst.CV_Luv2LRGB,
        BgrToYuv = CvConst.CV_BGR2YUV,
        RgbToYuv = CvConst.CV_RGB2YUV,
        YuvToBgr = CvConst.CV_YUV2BGR,
        YuvToRgb = CvConst.CV_YUV2RGB,
	}
}
