using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

#pragma warning disable 1591

namespace OpenCvSharp
{
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    internal unsafe struct WCvSeqWriter
    {
        public int header_size;
        public void* seq;
        public void* block;
        public sbyte* ptr;
        public sbyte* block_min;
        public sbyte* block_max;
    }
}
