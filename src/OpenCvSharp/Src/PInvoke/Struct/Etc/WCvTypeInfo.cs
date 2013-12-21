using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

#pragma warning disable 1591

namespace OpenCvSharp
{
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    internal unsafe struct WCvTypeInfo
    {
        public int flags;
        public int header_size;
        public void* prev;
        public void* next;
        public sbyte* type_name;
        public void* is_instance;
        public void* release;
        public void* read;
        public void* write;
        public void* clone;
    }
}
