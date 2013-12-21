using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

#pragma warning disable 1591

namespace OpenCvSharp
{
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    internal unsafe struct WCvLineIterator
    {
        public byte* ptr;

        /* Bresenham algorithm state: */
        public int err;
        public int plus_delta;
        public int minus_delta;
        public int plus_step;
        public int minus_step;
    }
}
