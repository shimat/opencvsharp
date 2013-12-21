/*
 * (C) 2008-2013 Schima
 * This code is licenced under the LGPL.
 */

using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

#pragma warning disable 1591

namespace OpenCvSharp
{
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    internal unsafe struct WCvFileNode
    {
        public int tag;
        public IntPtr info;

        // 一番sizeofがでかいので代表
        public CvString data;
    }
    /*
#if X86
    [StructLayout(LayoutKind.Explicit, CharSet = CharSet.Ansi, Pack=4)]
    internal unsafe struct WCvFileNode
    {
        [FieldOffset(0)]
        public int tag;
        [FieldOffset(4)]
        public void* info;

        [FieldOffset(8)]
        public double data_f;
        [FieldOffset(8)]
        public int data_i;
        [FieldOffset(8)]
        public CvString data_str;
        [FieldOffset(8)]
        public void* data_seq;
        [FieldOffset(8)]
        public void* data_map;
    }
#else
    [StructLayout(LayoutKind.Explicit, CharSet = CharSet.Ansi, Pack=4)]
    internal unsafe struct WCvFileNode
    {
        [FieldOffset(0)]
        public int tag;
        [FieldOffset(4)]
        public void* info;

        [FieldOffset(16)]
        public double data_f;
        [FieldOffset(16)]
        public int data_i;
        [FieldOffset(16)]
        public CvString data_str;
        [FieldOffset(16)]
        public void* data_seq;
        [FieldOffset(16)]
        public void* data_map;
    }
#endif
     */
}
