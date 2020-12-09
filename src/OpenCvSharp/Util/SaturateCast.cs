using System;

namespace OpenCvSharp.Util
{
#pragma warning disable 1591

    public static class SaturateCast
    {
        // ReSharper disable UnusedMember.Global

        public static byte ToByte(sbyte v) => (byte)Math.Max((int)v, 0);
        public static byte ToByte(ushort v) => (byte)Math.Min(v, (uint)byte.MaxValue);
        public static byte ToByte(int v) => (byte)((uint)v <= byte.MaxValue ? v : v > 0 ? byte.MaxValue : 0);
        public static byte ToByte(short v) => ToByte((int)v);
        public static byte ToByte(uint v) => (byte)Math.Min(v, byte.MaxValue);
        public static byte ToByte(float v) { var iv = (int)Math.Round(v); return ToByte(iv); }
        public static byte ToByte(double v) { var iv = (long)Math.Round(v); return ToByte(iv); }
        public static byte ToByte(long v) => (byte)((ulong)v <= byte.MaxValue ? v : v > 0 ? byte.MaxValue : 0);
        public static byte ToByte(ulong v) => (byte)Math.Min(v, byte.MaxValue);

        public static sbyte ToSByte(byte v) => (sbyte)Math.Min((int)v, sbyte.MaxValue);
        public static sbyte ToSByte(ushort v) => (sbyte)Math.Min(v, (uint)sbyte.MaxValue);
        public static sbyte ToSByte(int v) => (sbyte)((uint)(v - sbyte.MinValue) <= byte.MaxValue ? v : v > 0 ? sbyte.MaxValue : sbyte.MinValue);
        public static sbyte ToSByte(short v) => ToSByte((int)v);
        public static sbyte ToSByte(uint v) => (sbyte)Math.Min(v, sbyte.MaxValue);
        public static sbyte ToSByte(float v) { var iv = (int)Math.Round(v); return ToSByte(iv); }
        public static sbyte ToSByte(double v) { var iv = (int)Math.Round(v); return ToSByte(iv); }
        public static sbyte ToSByte(long v) => (sbyte)((ulong)(v - sbyte.MinValue) <= byte.MaxValue ? v : v > 0 ? sbyte.MaxValue : sbyte.MinValue);
        public static sbyte ToSByte(ulong v) => (sbyte)Math.Min(v, (int)sbyte.MaxValue);

        public static ushort ToUInt16(sbyte v) => (ushort)Math.Max((int)v, 0);
        public static ushort ToUInt16(short v) => (ushort)Math.Max((int)v, 0);
        public static ushort ToUInt16(int v) => (ushort)((uint)v <= ushort.MaxValue ? v : v > 0 ? ushort.MaxValue : 0);
        public static ushort ToUInt16(uint v) => (ushort)Math.Min(v, ushort.MaxValue);
        public static ushort ToUInt16(float v)  { var iv = (int)Math.Round(v); return ToUInt16(iv); }
        public static ushort ToUInt16(double v) { var iv = (int)Math.Round(v); return ToUInt16(iv); }
        public static ushort ToUInt16(long v) => (ushort)((ulong)v <= ushort.MaxValue ? v : v > 0 ? ushort.MaxValue : 0);
        public static ushort ToUInt16(ulong v) => (ushort)Math.Min(v, ushort.MaxValue);

        public static short ToInt16(ushort v) => (short)Math.Min(v, short.MaxValue);
        public static short ToInt16(int v) => (short)((uint)(v - short.MinValue) <= ushort.MaxValue ? v : v > 0 ? short.MaxValue : short.MinValue);
        public static short ToInt16(uint v) => (short)Math.Min(v, short.MaxValue);
        public static short ToInt16(float v)  { var iv = (int)Math.Round(v); return ToInt16(iv); }
        public static short ToInt16(double v) { var iv = (int)Math.Round(v); return ToInt16(iv); }
        public static short ToInt16(long v) => (short)((ulong)(v - short.MinValue) <= ushort.MaxValue ? v : v > 0 ? short.MaxValue : short.MinValue);
        public static short ToInt16(ulong v) => (short)Math.Min(v, (int)short.MaxValue);

        public static int ToInt32(uint v) => (int)Math.Min(v, int.MaxValue);
        public static int ToInt32(long v) => (int)((ulong)(v - int.MinValue) <= uint.MaxValue ? v : v > 0 ? int.MaxValue : int.MinValue);
        public static int ToInt32(ulong v) => (int)Math.Min(v, int.MaxValue);
        public static int ToInt32(float v) => (int)Math.Round(v);
        public static int ToInt32(double v) => (int)Math.Round(v);

        public static uint ToUInt32(sbyte v) => (uint)Math.Max(v, (sbyte)0);
        public static uint ToUInt32(short v) => (uint)Math.Max(v, (short)0);
        public static uint ToUInt32(int v) => (uint)Math.Max(v, 0);
        public static uint ToUInt32(long v) => (uint)((ulong)v <= uint.MaxValue ? v : v > 0 ? uint.MaxValue : 0);
        public static uint ToUInt32(ulong v) => (uint)Math.Min(v, uint.MaxValue);

        // we intentionally do not clip negative numbers, to make -1 become 0xffffffff etc.
        public static uint ToUInt32(float v) => (uint)Math.Round(v);
        public static uint ToUInt32(double v) => (uint)Math.Round(v);

        public static ulong ToUInt64(sbyte v) => (ulong)Math.Max(v, (sbyte)0);
        public static ulong ToUInt64(short v) => (ulong)Math.Max(v, (short)0);
        public static ulong ToUInt64(int v) => (ulong)Math.Max(v, 0);
        public static ulong ToUInt64(long v) => (ulong)Math.Max(v, 0);

        public static long ToInt64(ulong v) => (long)Math.Min(v, long.MaxValue);
    }
}
