using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

#pragma warning disable 1591

namespace OpenCvSharp
{
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    internal unsafe struct WCvHaarClassifierCascade
    {
        public int flags;
        public int count;
        public CvSize orig_window_size;
        public CvSize real_window_size;
        public double scale;
        public void* stage_classifier;
        public void* hid_cascade;
    }
}
