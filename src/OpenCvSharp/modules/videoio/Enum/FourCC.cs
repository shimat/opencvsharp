using System;

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
        Default = -1,
        Prompt = -1,
        CVID = 1145656899,
        DIB = 541215044,
        DIVX = 1482049860,
        H261 = 825635400,
        H263 = 859189832,
        H264 = 875967048,
        IV32 = 842225225,
        IV41 = 825513545,
        IV50 = 808801865,
        IYUB = 1448433993,
        MJPG = 1196444237,
        MP42 = 842289229,
        MP43 = 859066445,
        MPG4 = 877088845,
        MSVC = 1129730893,
        PIM1 = 827148624,
        XVID = 1145656920,
    }
}
