using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

#pragma warning disable 1591

namespace OpenCvSharp
{
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    internal unsafe struct WCvQuadEdge2D
    {
        public int flags;

        //public fixed CvSubdiv2DPoint pt[4];

        public IntPtr pt0;
        public IntPtr pt1;
        public IntPtr pt2;
        public IntPtr pt3;

        /// <summary>
        /// pt[i]
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        public IntPtr pt(long i)
        {
            switch (i)
            {
                case 0: return pt0;
                case 1: return pt1;
                case 2: return pt2;
                case 3: return pt3;
                default: throw new OpenCvSharpException("Invalid pointer operation");
            }
        }

        //public fixed ulong next[4];

        public IntPtr next0;
        public IntPtr next1;
        public IntPtr next2;
        public IntPtr next3;

        /// <summary>
        /// next[i]
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        public IntPtr next(long i)
        {
            switch (i)
            {
                case 0: return next0;
                case 1: return next1;
                case 2: return next2;
                case 3: return next3;
                default: throw new OpenCvSharpException("Invalid pointer operation");
            }
        }
    }
}
