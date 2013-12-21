using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

#pragma warning disable 1591

namespace OpenCvSharp
{
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    internal unsafe struct WCvConnectedComp
    {
        public double area;
        public CvScalar value; 
        public CvRect rect;  
        public void* contour; 
    }
}
