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
    [Serializable]
    [StructLayout(LayoutKind.Sequential)]
    public struct WCvSURFParams
    {
        public int extended;
        public double hessianThreshold;
        public int nOctaves;
        public int nOctaveLayers;
    }
}
