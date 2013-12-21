using System;
using System.Collections.Generic;
using System.Text;

#pragma warning disable 1591

namespace OpenCvSharp
{
#if LANG_JP
    /// <summary>
    /// フレームを圧縮するためのコーデックを表す4文字
    /// </summary>
#else
    /// <summary>
    /// 4-character code of codec used to compress the frames.
    /// </summary>
#endif
    public enum FourCC
    {
        Default = CvConst.CV_FOURCC_DEFAULT,
        Prompt = CvConst.CV_FOURCC_PROMPT,
        PIM1 = CvConst.CV_FOURCC_PIM1,
        MJPG = CvConst.CV_FOURCC_MJPG,
        DIB = CvConst.CV_FOURCC_DIB,
        DIVX = CvConst.CV_FOURCC_DIVX,
        XVID = CvConst.CV_FOURCC_XVID,
        MP42 = CvConst.CV_FOURCC_MP42,
        MP43 = CvConst.CV_FOURCC_MP43,
        MPG4 = CvConst.CV_FOURCC_MPG4,
        MSVC = CvConst.CV_FOURCC_MSVC,
        IV32 = CvConst.CV_FOURCC_IV32,
        IV41 = CvConst.CV_FOURCC_IV41,
        IV50 = CvConst.CV_FOURCC_IV50,
        CVID = CvConst.CV_FOURCC_CVID,
        IYUB = CvConst.CV_FOURCC_IYUB,
        H261 = CvConst.CV_FOURCC_H261,
        H263 = CvConst.CV_FOURCC_H263,
        H264 = CvConst.CV_FOURCC_H264,
    }
}
