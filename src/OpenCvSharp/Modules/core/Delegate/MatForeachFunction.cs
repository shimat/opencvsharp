using System.Runtime.InteropServices;

namespace OpenCvSharp;
// ReSharper disable InconsistentNaming

/// <summary>
/// Callback invoked once per element when <see cref="Mat.ForEachAsByte"/> runs the given
/// functor over all matrix elements in parallel.
/// </summary>
/// <param name="value">Pointer to the element value.</param>
/// <param name="position">Pointer to the element's position (one int per matrix dimension).</param>
[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
public unsafe delegate void MatForeachFunctionByte(byte* value, int* position);

/// <summary>
/// Callback invoked once per element when <see cref="Mat.ForEachAsVec2b"/> runs the given
/// functor over all matrix elements in parallel.
/// </summary>
/// <param name="value">Pointer to the element value.</param>
/// <param name="position">Pointer to the element's position (one int per matrix dimension).</param>
[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
public unsafe delegate void MatForeachFunctionVec2b(Vec2b* value, int* position);

/// <summary>
/// Callback invoked once per element when <see cref="Mat.ForEachAsVec3b"/> runs the given
/// functor over all matrix elements in parallel.
/// </summary>
/// <param name="value">Pointer to the element value.</param>
/// <param name="position">Pointer to the element's position (one int per matrix dimension).</param>
[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
public unsafe delegate void MatForeachFunctionVec3b(Vec3b* value, int* position);

/// <summary>
/// Callback invoked once per element when <see cref="Mat.ForEachAsVec4b"/> runs the given
/// functor over all matrix elements in parallel.
/// </summary>
/// <param name="value">Pointer to the element value.</param>
/// <param name="position">Pointer to the element's position (one int per matrix dimension).</param>
[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
public unsafe delegate void MatForeachFunctionVec4b(Vec4b* value, int* position);

/// <summary>
/// Callback invoked once per element when <see cref="Mat.ForEachAsVec6b"/> runs the given
/// functor over all matrix elements in parallel.
/// </summary>
/// <param name="value">Pointer to the element value.</param>
/// <param name="position">Pointer to the element's position (one int per matrix dimension).</param>
[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
public unsafe delegate void MatForeachFunctionVec6b(Vec6b* value, int* position);

/// <summary>
/// Callback invoked once per element when <see cref="Mat.ForEachAsInt16"/> runs the given
/// functor over all matrix elements in parallel.
/// </summary>
/// <param name="value">Pointer to the element value.</param>
/// <param name="position">Pointer to the element's position (one int per matrix dimension).</param>
[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
public unsafe delegate void MatForeachFunctionInt16(short* value, int* position);

/// <summary>
/// Callback invoked once per element when <see cref="Mat.ForEachAsVec2s"/> runs the given
/// functor over all matrix elements in parallel.
/// </summary>
/// <param name="value">Pointer to the element value.</param>
/// <param name="position">Pointer to the element's position (one int per matrix dimension).</param>
[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
public unsafe delegate void MatForeachFunctionVec2s(Vec2s* value, int* position);

/// <summary>
/// Callback invoked once per element when <see cref="Mat.ForEachAsVec3s"/> runs the given
/// functor over all matrix elements in parallel.
/// </summary>
/// <param name="value">Pointer to the element value.</param>
/// <param name="position">Pointer to the element's position (one int per matrix dimension).</param>
[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
public unsafe delegate void MatForeachFunctionVec3s(Vec3s* value, int* position);

/// <summary>
/// Callback invoked once per element when <see cref="Mat.ForEachAsVec4s"/> runs the given
/// functor over all matrix elements in parallel.
/// </summary>
/// <param name="value">Pointer to the element value.</param>
/// <param name="position">Pointer to the element's position (one int per matrix dimension).</param>
[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
public unsafe delegate void MatForeachFunctionVec4s(Vec4s* value, int* position);

/// <summary>
/// Callback invoked once per element when <see cref="Mat.ForEachAsVec6s"/> runs the given
/// functor over all matrix elements in parallel.
/// </summary>
/// <param name="value">Pointer to the element value.</param>
/// <param name="position">Pointer to the element's position (one int per matrix dimension).</param>
[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
public unsafe delegate void MatForeachFunctionVec6s(Vec6s* value, int* position);

/// <summary>
/// Callback invoked once per element when <see cref="Mat.ForEachAsInt32"/> runs the given
/// functor over all matrix elements in parallel.
/// </summary>
/// <param name="value">Pointer to the element value.</param>
/// <param name="position">Pointer to the element's position (one int per matrix dimension).</param>
[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
public unsafe delegate void MatForeachFunctionInt32(int* value, int* position);

/// <summary>
/// Callback invoked once per element when <see cref="Mat.ForEachAsVec2i"/> runs the given
/// functor over all matrix elements in parallel.
/// </summary>
/// <param name="value">Pointer to the element value.</param>
/// <param name="position">Pointer to the element's position (one int per matrix dimension).</param>
[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
public unsafe delegate void MatForeachFunctionVec2i(Vec2i* value, int* position);

/// <summary>
/// Callback invoked once per element when <see cref="Mat.ForEachAsVec3i"/> runs the given
/// functor over all matrix elements in parallel.
/// </summary>
/// <param name="value">Pointer to the element value.</param>
/// <param name="position">Pointer to the element's position (one int per matrix dimension).</param>
[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
public unsafe delegate void MatForeachFunctionVec3i(Vec3i* value, int* position);

/// <summary>
/// Callback invoked once per element when <see cref="Mat.ForEachAsVec4i"/> runs the given
/// functor over all matrix elements in parallel.
/// </summary>
/// <param name="value">Pointer to the element value.</param>
/// <param name="position">Pointer to the element's position (one int per matrix dimension).</param>
[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
public unsafe delegate void MatForeachFunctionVec4i(Vec4i* value, int* position);

/// <summary>
/// Callback invoked once per element when <see cref="Mat.ForEachAsVec6i"/> runs the given
/// functor over all matrix elements in parallel.
/// </summary>
/// <param name="value">Pointer to the element value.</param>
/// <param name="position">Pointer to the element's position (one int per matrix dimension).</param>
[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
public unsafe delegate void MatForeachFunctionVec6i(Vec6i* value, int* position);

/// <summary>
/// Callback invoked once per element when <see cref="Mat.ForEachAsFloat"/> runs the given
/// functor over all matrix elements in parallel.
/// </summary>
/// <param name="value">Pointer to the element value.</param>
/// <param name="position">Pointer to the element's position (one int per matrix dimension).</param>
[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
public unsafe delegate void MatForeachFunctionFloat(float* value, int* position);

/// <summary>
/// Callback invoked once per element when <see cref="Mat.ForEachAsVec2f"/> runs the given
/// functor over all matrix elements in parallel.
/// </summary>
/// <param name="value">Pointer to the element value.</param>
/// <param name="position">Pointer to the element's position (one int per matrix dimension).</param>
[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
public unsafe delegate void MatForeachFunctionVec2f(Vec2f* value, int* position);

/// <summary>
/// Callback invoked once per element when <see cref="Mat.ForEachAsVec3f"/> runs the given
/// functor over all matrix elements in parallel.
/// </summary>
/// <param name="value">Pointer to the element value.</param>
/// <param name="position">Pointer to the element's position (one int per matrix dimension).</param>
[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
public unsafe delegate void MatForeachFunctionVec3f(Vec3f* value, int* position);

/// <summary>
/// Callback invoked once per element when <see cref="Mat.ForEachAsVec4f"/> runs the given
/// functor over all matrix elements in parallel.
/// </summary>
/// <param name="value">Pointer to the element value.</param>
/// <param name="position">Pointer to the element's position (one int per matrix dimension).</param>
[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
public unsafe delegate void MatForeachFunctionVec4f(Vec4f* value, int* position);

/// <summary>
/// Callback invoked once per element when <see cref="Mat.ForEachAsVec6f"/> runs the given
/// functor over all matrix elements in parallel.
/// </summary>
/// <param name="value">Pointer to the element value.</param>
/// <param name="position">Pointer to the element's position (one int per matrix dimension).</param>
[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
public unsafe delegate void MatForeachFunctionVec6f(Vec6f* value, int* position);

/// <summary>
/// Callback invoked once per element when <see cref="Mat.ForEachAsDouble"/> runs the given
/// functor over all matrix elements in parallel.
/// </summary>
/// <param name="value">Pointer to the element value.</param>
/// <param name="position">Pointer to the element's position (one int per matrix dimension).</param>
[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
public unsafe delegate void MatForeachFunctionDouble(double* value, int* position);

/// <summary>
/// Callback invoked once per element when <see cref="Mat.ForEachAsVec2d"/> runs the given
/// functor over all matrix elements in parallel.
/// </summary>
/// <param name="value">Pointer to the element value.</param>
/// <param name="position">Pointer to the element's position (one int per matrix dimension).</param>
[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
public unsafe delegate void MatForeachFunctionVec2d(Vec2d* value, int* position);

/// <summary>
/// Callback invoked once per element when <see cref="Mat.ForEachAsVec3d"/> runs the given
/// functor over all matrix elements in parallel.
/// </summary>
/// <param name="value">Pointer to the element value.</param>
/// <param name="position">Pointer to the element's position (one int per matrix dimension).</param>
[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
public unsafe delegate void MatForeachFunctionVec3d(Vec3d* value, int* position);

/// <summary>
/// Callback invoked once per element when <see cref="Mat.ForEachAsVec4d"/> runs the given
/// functor over all matrix elements in parallel.
/// </summary>
/// <param name="value">Pointer to the element value.</param>
/// <param name="position">Pointer to the element's position (one int per matrix dimension).</param>
[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
public unsafe delegate void MatForeachFunctionVec4d(Vec4d* value, int* position);

/// <summary>
/// Callback invoked once per element when <see cref="Mat.ForEachAsVec6d"/> runs the given
/// functor over all matrix elements in parallel.
/// </summary>
/// <param name="value">Pointer to the element value.</param>
/// <param name="position">Pointer to the element's position (one int per matrix dimension).</param>
[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
public unsafe delegate void MatForeachFunctionVec6d(Vec6d* value, int* position);
