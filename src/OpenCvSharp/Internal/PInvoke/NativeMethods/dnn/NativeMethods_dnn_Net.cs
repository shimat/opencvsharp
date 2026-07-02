using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

#pragma warning disable 1591
#pragma warning disable CA1401 // P/Invokes should not be visible
#pragma warning disable CA2101 // Specify marshaling for P/Invoke string arguments
#pragma warning disable IDE1006 // Naming style

namespace OpenCvSharp.Internal;

// ReSharper disable InconsistentNaming
static partial class NativeMethods
{
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus dnn_Net_new(out IntPtr returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus dnn_Net_delete(IntPtr net);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus dnn_Net_readFromModelOptimizer(
        [MarshalAs(UnmanagedType.LPStr)] string xml, [MarshalAs(UnmanagedType.LPStr)] string bin, out IntPtr returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus dnn_Net_empty(OpenCvSafeHandle net, out int returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus dnn_Net_dump(OpenCvSafeHandle net, IntPtr outString);
        
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus dnn_Net_dumpToFile(OpenCvSafeHandle net, [MarshalAs(UnmanagedType.LPStr)] string path);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus dnn_Net_getLayerId(OpenCvSafeHandle net, [MarshalAs(UnmanagedType.LPStr)] string layer, out int returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus dnn_Net_getLayerNames(OpenCvSafeHandle net, IntPtr outVec);
        
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus dnn_Net_connect1(
        OpenCvSafeHandle net, [MarshalAs(UnmanagedType.LPStr)] string outPin, [MarshalAs(UnmanagedType.LPStr)] string inpPin);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus dnn_Net_connect2(OpenCvSafeHandle net, int outLayerId, int outNum, int inpLayerId, int inpNum);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus dnn_Net_setInputsNames(OpenCvSafeHandle net, [MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.LPStr)] string[] inputBlobNames, int inputBlobNamesLength);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus dnn_Net_forward1(OpenCvSafeHandle net, [MarshalAs(UnmanagedType.LPStr)] string? outputName, out IntPtr returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus dnn_Net_forward2(
        OpenCvSafeHandle net, IntPtr[] outputBlobs, int outputBlobsLength, [MarshalAs(UnmanagedType.LPStr)] string? outputName);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus dnn_Net_forward3(
        OpenCvSafeHandle net, IntPtr[] outputBlobs, int outputBlobsLength, [MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.LPStr)] string[] outBlobNames, int outBlobNamesLength);
        
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus dnn_Net_setPreferableBackend(OpenCvSafeHandle net, int backendId);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus dnn_Net_setPreferableTarget(OpenCvSafeHandle net, int targetId);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus dnn_Net_setInput(OpenCvSafeHandle net, IntPtr blob, [MarshalAs(UnmanagedType.LPStr)] string name);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus dnn_Net_getUnconnectedOutLayers(OpenCvSafeHandle net, IntPtr result);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus dnn_Net_getUnconnectedOutLayersNames(OpenCvSafeHandle net, IntPtr result);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus dnn_Net_enableFusion(OpenCvSafeHandle net, int fusion);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus dnn_Net_getPerfProfile(OpenCvSafeHandle net, IntPtr timings, out long returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus dnn_Net_setInputShape(
        OpenCvSafeHandle net, [MarshalAs(UnmanagedType.LPStr)] string inputName, int[] shape, int shapeLength);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus dnn_Net_getParam(OpenCvSafeHandle net, int layer, int numParam, out IntPtr returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus dnn_Net_setParam(OpenCvSafeHandle net, int layer, int numParam, IntPtr blob);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus dnn_Net_getLayerTypes(OpenCvSafeHandle net, IntPtr outVec);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus dnn_Net_getLayersCount(
        OpenCvSafeHandle net, [MarshalAs(UnmanagedType.LPStr)] string layerType, out int returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus dnn_Net_enableWinograd(OpenCvSafeHandle net, int useWinograd);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus dnn_Net_dumpToPbtxt(OpenCvSafeHandle net, [MarshalAs(UnmanagedType.LPStr)] string path);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus dnn_Net_getModelFormat(OpenCvSafeHandle net, out int returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus dnn_Net_enableKVCache(OpenCvSafeHandle net);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus dnn_Net_disableKVCache(OpenCvSafeHandle net);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus dnn_Net_resetKVCache(OpenCvSafeHandle net);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus dnn_Net_printPerfProfile(OpenCvSafeHandle net);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus dnn_Net_finalizeNet(OpenCvSafeHandle net);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus dnn_Net_setTracingMode(OpenCvSafeHandle net, int tracingMode);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus dnn_Net_getTracingMode(OpenCvSafeHandle net, out int returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus dnn_Net_setProfilingMode(OpenCvSafeHandle net, int profilingMode);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus dnn_Net_getProfilingMode(OpenCvSafeHandle net, out int returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus dnn_Net_registerOutput(
        OpenCvSafeHandle net, [MarshalAs(UnmanagedType.LPUTF8Str)] string outputName, int layerId, int outputPort, out int returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus dnn_Net_getPerfProfileDetailed(OpenCvSafeHandle net, IntPtr names, IntPtr timems, IntPtr counts);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus dnn_Net_getFLOPS_netInputs(
        OpenCvSafeHandle net, int[] shapesData, int shapesLength, int[] netInputTypes, int netInputTypesLength, out long returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus dnn_Net_getFLOPS_layer(
        OpenCvSafeHandle net, int layerId, int[] shapesData, int shapesLength, int[] netInputTypes, int netInputTypesLength, out long returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus dnn_Net_getLayerShapes(
        OpenCvSafeHandle net, int[] shapesData, int shapesLength, int[] netInputTypes, int netInputTypesLength,
        int layerId, IntPtr outInLayerShapes, IntPtr outOutLayerShapes);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus dnn_Net_getLayersShapes(
        OpenCvSafeHandle net, int[] shapesData, int shapesLength, int[] netInputTypes, int netInputTypesLength,
        IntPtr outLayerIds, IntPtr outInLayersShapes, IntPtr outOutLayersShapes);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus dnn_Net_getMemoryConsumption(
        OpenCvSafeHandle net, int[] shapesData, int shapesLength, int[] netInputTypes, int netInputTypesLength,
        out long outWeights, out long outBlobs);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus dnn_Net_getMemoryConsumption_perLayer(
        OpenCvSafeHandle net, int[] shapesData, int shapesLength, int[] netInputTypes, int netInputTypesLength,
        IntPtr outLayerIds, IntPtr outWeights, IntPtr outBlobs);
}
