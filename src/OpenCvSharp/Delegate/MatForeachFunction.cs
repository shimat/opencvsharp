using System;
using System.Runtime.InteropServices;

namespace OpenCvSharp
{
#pragma warning disable 1591
// ReSharper disable InconsistentNaming

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public unsafe delegate void MatForeachFunctionByte(byte* value, int* position);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public unsafe delegate void MatForeachFunctionVec2b(Vec2b* value, int* position);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public unsafe delegate void MatForeachFunctionVec3b(Vec3b* value, int* position);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public unsafe delegate void MatForeachFunctionVec4b(Vec4b* value, int* position);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public unsafe delegate void MatForeachFunctionVec6b(Vec6b* value, int* position);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public unsafe delegate void MatForeachFunctionInt16(short* value, int* position);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public unsafe delegate void MatForeachFunctionVec2s(Vec2s* value, int* position);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public unsafe delegate void MatForeachFunctionVec3s(Vec3s* value, int* position);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public unsafe delegate void MatForeachFunctionVec4s(Vec4s* value, int* position);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public unsafe delegate void MatForeachFunctionVec6s(Vec6s* value, int* position);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public unsafe delegate void MatForeachFunctionInt32(int* value, int* position);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public unsafe delegate void MatForeachFunctionVec2i(Vec2i* value, int* position);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public unsafe delegate void MatForeachFunctionVec3i(Vec3i* value, int* position);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public unsafe delegate void MatForeachFunctionVec4i(Vec4i* value, int* position);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public unsafe delegate void MatForeachFunctionVec6i(Vec6i* value, int* position);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public unsafe delegate void MatForeachFunctionFloat(float* value, int* position);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public unsafe delegate void MatForeachFunctionVec2f(Vec2f* value, int* position);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public unsafe delegate void MatForeachFunctionVec3f(Vec3f* value, int* position);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public unsafe delegate void MatForeachFunctionVec4f(Vec4f* value, int* position);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public unsafe delegate void MatForeachFunctionVec6f(Vec6f* value, int* position);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public unsafe delegate void MatForeachFunctionDouble(double* value, int* position);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public unsafe delegate void MatForeachFunctionVec2d(Vec2d* value, int* position);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public unsafe delegate void MatForeachFunctionVec3d(Vec3d* value, int* position);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public unsafe delegate void MatForeachFunctionVec4d(Vec4d* value, int* position);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public unsafe delegate void MatForeachFunctionVec6d(Vec6d* value, int* position);
}
