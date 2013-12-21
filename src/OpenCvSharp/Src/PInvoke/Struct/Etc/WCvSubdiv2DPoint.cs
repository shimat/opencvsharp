using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

#pragma warning disable 1591

namespace OpenCvSharp
{
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    internal unsafe struct WCvSubdiv2DPoint
    {
        public int flags;
        public CvSubdiv2DEdge first;
        public CvPoint2D32f pt;

        public int id;  // opencv 2.1
    }
}
