using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

#pragma warning disable 1591

namespace OpenCvSharp
{
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    internal unsafe struct WCvTreeNode
    {
        public int flags;
        public int header_size;
        public void* h_prev;
        public void* h_next;
        public void* v_prev;
        public void* v_next;
    }
}
