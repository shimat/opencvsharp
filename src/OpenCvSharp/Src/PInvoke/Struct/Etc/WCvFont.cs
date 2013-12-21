using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

#pragma warning disable 1591

namespace OpenCvSharp
{
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public unsafe struct WCvFont
    {
        public sbyte* nameFont;  // added for OpenCV 2.11 Qt support
        public CvScalar color;  // added for OpenCV 2.11 Qt support
        public int font_face; 
        public int* ascii; 
        public int* greek;
        public int* cyrillic;
        public float hscale, vscale;
        public float shear;
        public int thickness; 
        public float dx; 
        public int line_type;
    }
}
