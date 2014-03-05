using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

#pragma warning disable 1591

namespace OpenCvSharp
{
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public struct WCvMoments
    {
        public double m00, m10, m01, m20, m11, m02, m30, m21, m12, m03; /* spatial moments */
        public double mu20, mu11, mu02, mu30, mu21, mu12, mu03; /* central moments */
        public double inv_sqrt_m00; /* m00 != 0 ? 1/sqrt(m00) : 0 */
    }
}
