using System;

#pragma warning disable 1591

namespace OpenCvSharp.Util
{
    public static class MemoryHelper
    {
        public static unsafe void CopyMemory(void* outDest, void* inSrc, uint inNumOfBytes)
        {
            Buffer.MemoryCopy(inSrc, outDest, inNumOfBytes, inNumOfBytes);
        }

        public static unsafe void CopyMemory(void* outDest, void* inSrc, int inNumOfBytes)
        {
            Buffer.MemoryCopy(inSrc, outDest, inNumOfBytes, inNumOfBytes);
        }

        public static unsafe void CopyMemory(IntPtr outDest, IntPtr inSrc, uint inNumOfBytes)
        {
            Buffer.MemoryCopy(inSrc.ToPointer(), outDest.ToPointer(), inNumOfBytes, inNumOfBytes);
        }

        public static unsafe void CopyMemory(IntPtr outDest, IntPtr inSrc, int inNumOfBytes)
        {
            Buffer.MemoryCopy(inSrc.ToPointer(), outDest.ToPointer(), inNumOfBytes, inNumOfBytes);
        }
    }
}
