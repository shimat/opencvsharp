using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

#pragma warning disable 1591

namespace OpenCvSharp
{
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    internal unsafe struct WIplConvKernel
    {
        public int nCols;
        public int nRows;
        public int anchorX;
        public int anchorY;
        public int* values;
        public int nShiftR;
    }
}
