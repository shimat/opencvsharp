using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace OpenCvSharp
{
    /// <summary>
    /// 
    /// </summary>
    [StructLayout(LayoutKind.Explicit)]
    internal struct Cv64suf
    {
        [FieldOffset(0)]
        public Int64 i;
        [FieldOffset(0)]
        public UInt64 u;
        [FieldOffset(0)]
        public Double f;
    }
}
