using System.Runtime.InteropServices;

#pragma warning disable 1591
#pragma warning disable CA1401 // P/Invokes should not be visible
#pragma warning disable CA2101 // Specify marshaling for P/Invoke string arguments
#pragma warning disable IDE1006 // Naming style

namespace OpenCvSharp.Internal;

// ReSharper disable InconsistentNaming
static partial class NativeMethods
{
    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus dnn_Net_new(out IntPtr returnValue);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus dnn_Net_delete(IntPtr net);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus dnn_Net_readFromModelOptimizer(
        [MarshalAs(UnmanagedType.LPStr)] string xml, [MarshalAs(UnmanagedType.LPStr)] string bin, out IntPtr returnValue);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus dnn_Net_empty(IntPtr net, out int returnValue);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus dnn_Net_dump(IntPtr net, IntPtr outString);
        
    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus dnn_Net_dumpToFile(IntPtr net, [MarshalAs(UnmanagedType.LPStr)] string path);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus dnn_Net_getLayerId(IntPtr net, [MarshalAs(UnmanagedType.LPStr)] string layer, out int returnValue);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus dnn_Net_getLayerNames(IntPtr net, IntPtr outVec);
        
    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, BestFitMapping = false, ThrowOnUnmappableChar = true)]
    public static extern ExceptionStatus dnn_Net_connect1(
        IntPtr net, [MarshalAs(UnmanagedType.LPStr)] string outPin, [MarshalAs(UnmanagedType.LPStr)] string inpPin);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus dnn_Net_connect2(IntPtr net, int outLayerId, int outNum, int inpLayerId, int inpNum);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, BestFitMapping = false, ThrowOnUnmappableChar = true)]
    public static extern ExceptionStatus dnn_Net_setInputsNames(IntPtr net, string[] inputBlobNames, int inputBlobNamesLength);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, BestFitMapping = false, ThrowOnUnmappableChar = true)]
    public static extern ExceptionStatus dnn_Net_forward1(IntPtr net, [MarshalAs(UnmanagedType.LPStr)] string? outputName, out IntPtr returnValue);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, BestFitMapping = false, ThrowOnUnmappableChar = true)]
    public static extern ExceptionStatus dnn_Net_forward2(
        IntPtr net, IntPtr[] outputBlobs, int outputBlobsLength, [MarshalAs(UnmanagedType.LPStr)] string? outputName);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, BestFitMapping = false, ThrowOnUnmappableChar = true)]
    public static extern ExceptionStatus dnn_Net_forward3(
        IntPtr net, IntPtr[] outputBlobs, int outputBlobsLength, string[] outBlobNames, int outBlobNamesLength);
        
    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, BestFitMapping = false, ThrowOnUnmappableChar = true)]
    public static extern ExceptionStatus dnn_Net_setPreferableBackend(IntPtr net, int backendId);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, BestFitMapping = false, ThrowOnUnmappableChar = true)]
    public static extern ExceptionStatus dnn_Net_setPreferableTarget(IntPtr net, int targetId);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, BestFitMapping = false, ThrowOnUnmappableChar = true)]
    public static extern ExceptionStatus dnn_Net_setInput(IntPtr net, IntPtr blob, [MarshalAs(UnmanagedType.LPStr)] string name);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, BestFitMapping = false, ThrowOnUnmappableChar = true)]
    public static extern ExceptionStatus dnn_Net_getUnconnectedOutLayers(IntPtr net, IntPtr result);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, BestFitMapping = false, ThrowOnUnmappableChar = true)]
    public static extern ExceptionStatus dnn_Net_getUnconnectedOutLayersNames(IntPtr net, IntPtr result);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, BestFitMapping = false, ThrowOnUnmappableChar = true)]
    public static extern ExceptionStatus dnn_Net_enableFusion(IntPtr net, int fusion);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, BestFitMapping = false, ThrowOnUnmappableChar = true)]
    public static extern ExceptionStatus dnn_Net_getPerfProfile(IntPtr net, IntPtr timings, out long returnValue);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, BestFitMapping = false, ThrowOnUnmappableChar = true)]
    public static extern ExceptionStatus dnn_Net_setInputShape(
        IntPtr net, [MarshalAs(UnmanagedType.LPStr)] string inputName, int[] shape, int shapeLength);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus dnn_Net_getParam(IntPtr net, int layer, int numParam, out IntPtr returnValue);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus dnn_Net_setParam(IntPtr net, int layer, int numParam, IntPtr blob);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus dnn_Net_getLayerTypes(IntPtr net, IntPtr outVec);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, BestFitMapping = false, ThrowOnUnmappableChar = true)]
    public static extern ExceptionStatus dnn_Net_getLayersCount(
        IntPtr net, [MarshalAs(UnmanagedType.LPStr)] string layerType, out int returnValue);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus dnn_Net_enableWinograd(IntPtr net, int useWinograd);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, BestFitMapping = false, ThrowOnUnmappableChar = true)]
    public static extern ExceptionStatus dnn_Net_dumpToPbtxt(IntPtr net, [MarshalAs(UnmanagedType.LPStr)] string path);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus dnn_Net_getModelFormat(IntPtr net, out int returnValue);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus dnn_Net_enableKVCache(IntPtr net);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus dnn_Net_disableKVCache(IntPtr net);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus dnn_Net_resetKVCache(IntPtr net);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus dnn_Net_printPerfProfile(IntPtr net);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus dnn_Net_finalizeNet(IntPtr net);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus dnn_Net_setTracingMode(IntPtr net, int tracingMode);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus dnn_Net_getTracingMode(IntPtr net, out int returnValue);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus dnn_Net_setProfilingMode(IntPtr net, int profilingMode);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus dnn_Net_getProfilingMode(IntPtr net, out int returnValue);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, BestFitMapping = false, ThrowOnUnmappableChar = true)]
    public static extern ExceptionStatus dnn_Net_registerOutput(
        IntPtr net, [MarshalAs(UnmanagedType.LPUTF8Str)] string outputName, int layerId, int outputPort, out int returnValue);
}
