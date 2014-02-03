/*
 * (C) 2008-2014 shimat
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
    internal unsafe struct WCvLSVMFilterObject
    {
        public CvLSVMFilterPosition V;
        public fixed float fineFunction[4];
        public int sizeX;
        public int sizeY;
        public int numFeatures;
        public float *H;
    }
}
