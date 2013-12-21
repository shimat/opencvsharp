using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

#pragma warning disable 1591

namespace OpenCvSharp
{
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    internal unsafe struct WCvSeqBlock
    {
        public void* prev;
        public void* next;
        public int start_index;

        public int count;
        public sbyte* data; 
    }
}
