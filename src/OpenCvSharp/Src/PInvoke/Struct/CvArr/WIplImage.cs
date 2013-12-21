using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

#pragma warning disable 1591

namespace OpenCvSharp
{    
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    internal unsafe struct WIplImage
    {
        public int nSize;
        public int ID;
        public int nChannels;
        public int alphaChannel;
        public int depth;
        public fixed byte colorModel[4];
        public fixed byte channelSeq[4];
        public int dataOrder;
        public int origin;
        public int align;
        public int width;
        public int height;
        public void* roi;
        public void* maskROI;
        public void* imageId;
        public void* tileInfo;
        public int imageSize;
        public byte* imageData;
        public int widthStep;
        public fixed int BorderMode[4];
        public fixed int BorderConst[4];
        public byte* imageDataOrigin;
    }
}
