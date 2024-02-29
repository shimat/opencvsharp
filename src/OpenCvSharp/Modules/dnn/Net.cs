using System.Diagnostics.CodeAnalysis;
using OpenCvSharp.Internal;
using OpenCvSharp.Internal.Vectors;

// ReSharper disable UnusedMember.Global
// ReSharper disable IdentifierTypo
// ReSharper disable InconsistentNaming
// ReSharper disable CommentTypo

namespace OpenCvSharp.Dnn;

/// <inheritdoc />
/// <summary>
/// This class allows to create and manipulate comprehensive artificial neural networks.
/// </summary>
/// <remarks>
/// Neural network is presented as directed acyclic graph(DAG), where vertices are Layer instances,
/// and edges specify relationships between layers inputs and outputs.
/// 
/// Each network layer has unique integer id and unique string name inside its network.
/// LayerId can store either layer name or layer id.
/// This class supports reference counting of its instances, i.e.copies point to the same instance.
/// </remarks>
[SuppressMessage("Microsoft.Design", "CA1724: Type names should not match namespaces")]
public class Net : DisposableCvObject
{
    #region Init & Disposal

    /// <inheritdoc />
    /// <summary>
    /// Default constructor.
    /// </summary>
    public Net()
    {
        NativeMethods.HandleException(
            NativeMethods.dnn_Net_new(out ptr));
    }

    /// <inheritdoc />
    /// <summary>
    /// </summary>
    protected Net(IntPtr ptr)
    {
        this.ptr = ptr;
    }
        
    /// <inheritdoc />
    /// <summary>
    /// </summary>
    protected override void DisposeUnmanaged()
    {
        NativeMethods.HandleException(
            NativeMethods.dnn_Net_delete(ptr));
        base.DisposeUnmanaged();
    }

    /// <summary>
    /// Create a network from Intel's Model Optimizer intermediate representation (IR).
    /// Networks imported from Intel's Model Optimizer are launched in Intel's Inference Engine backend.
    /// </summary>
    /// <param name="xml">XML configuration file with network's topology.</param>
    /// <param name="bin">Binary file with trained weights.</param>
    /// <returns></returns>
    public static Net? ReadFromModelOptimizer(string xml, string bin)
    {
        if (xml is null) 
            throw new ArgumentNullException(nameof(xml));
        if (bin is null) 
            throw new ArgumentNullException(nameof(bin));

        NativeMethods.HandleException(
            NativeMethods.dnn_Net_readFromModelOptimizer(xml, bin, out var p));
        return (p == IntPtr.Zero) ? null : new Net(p);
    }

    /// <summary>
    /// Reads a network model stored in Darknet (https://pjreddie.com/darknet/) model files.
    /// </summary>
    /// <param name="cfgFile">path to the .cfg file with text description of the network architecture.</param>
    /// <param name="darknetModel">path to the .weights file with learned network.</param>
    /// <returns>Network object that ready to do forward, throw an exception in failure cases.</returns>
    /// <remarks>This is shortcut consisting from DarknetImporter and Net::populateNet calls.</remarks>
    public static Net? ReadNetFromDarknet(string cfgFile, string? darknetModel = null)
    {
        if (cfgFile is null)
            throw new ArgumentNullException(nameof(cfgFile));

        NativeMethods.HandleException(
            NativeMethods.dnn_readNetFromDarknet(cfgFile, darknetModel, out var p));
        return (p == IntPtr.Zero) ? null : new Net(p);
    }
        
    /// <summary>
    /// Reads a network model stored in Caffe model files from memory.
    /// </summary>
    /// <param name="bufferCfg">A buffer contains a content of .cfg file with text description of the network architecture.</param>
    /// <param name="bufferModel">A buffer contains a content of .weights file with learned network.</param>
    /// <returns></returns>
    /// <remarks>This is shortcut consisting from createCaffeImporter and Net::populateNet calls.</remarks>
    public static Net? ReadNetFromDarknet(byte[] bufferCfg, byte[]? bufferModel = null)
    {
        if (bufferCfg is null)
            throw new ArgumentNullException(nameof(bufferCfg));

        var ret = ReadNetFromDarknet(
            new ReadOnlySpan<byte>(bufferCfg),
            bufferModel is null ? ReadOnlySpan<byte>.Empty : new ReadOnlySpan<byte>(bufferModel));
        GC.KeepAlive(bufferCfg);
        GC.KeepAlive(bufferModel);
        return ret;
    }
        
    /// <summary>
    /// Reads a network model stored in Caffe model files from memory.
    /// </summary>
    /// <param name="bufferCfg">A buffer contains a content of .cfg file with text description of the network architecture.</param>
    /// <param name="bufferModel">A buffer contains a content of .weights file with learned network.</param>
    /// <returns></returns>
    /// <remarks>This is shortcut consisting from createCaffeImporter and Net::populateNet calls.</remarks>
    public static Net? ReadNetFromDarknet(ReadOnlySpan<byte> bufferCfg, ReadOnlySpan<byte> bufferModel = default)
    {
        if (bufferCfg.IsEmpty)
            throw new ArgumentException("Empty span", nameof(bufferCfg));

        unsafe
        {
            fixed (byte* bufferCfgPtr = bufferCfg)
            fixed (byte* bufferModelPtr = bufferModel)
            {
                NativeMethods.HandleException(
                    NativeMethods.dnn_readNetFromDarknet(
                        bufferCfgPtr, new IntPtr(bufferCfg.Length),
                        bufferModelPtr, new IntPtr(bufferModel.Length),
                        out var p));
                return (p == IntPtr.Zero) ? null : new Net(p);
            }
        }
    }

    /// <summary>
    /// Reads a network model stored in Caffe model files.
    /// </summary>
    /// <param name="prototxt">path to the .prototxt file with text description of the network architecture.</param>
    /// <param name="caffeModel">path to the .caffemodel file with learned network.</param>
    /// <returns></returns>
    /// <remarks>This is shortcut consisting from createCaffeImporter and Net::populateNet calls.</remarks>
    public static Net? ReadNetFromCaffe(string prototxt, string? caffeModel = null)
    {
        if (prototxt is null)
            throw new ArgumentNullException(nameof(prototxt));

        NativeMethods.HandleException(
            NativeMethods.dnn_readNetFromCaffe(prototxt, caffeModel, out var p));
        return (p == IntPtr.Zero) ? null : new Net(p);
    }

    /// <summary>
    /// Reads a network model stored in Caffe model in memory.
    /// </summary>
    /// <param name="bufferProto">buffer containing the content of the .prototxt file</param>
    /// <param name="bufferModel">buffer containing the content of the .caffemodel file</param>
    /// <returns></returns>
    /// <remarks>This is shortcut consisting from createCaffeImporter and Net::populateNet calls.</remarks>
    public static Net? ReadNetFromCaffe(byte[] bufferProto, byte[]? bufferModel = null)
    {
        if (bufferProto is null)
            throw new ArgumentNullException(nameof(bufferProto));
            
        var ret = ReadNetFromCaffe(
            new ReadOnlySpan<byte>(bufferProto),
            bufferModel is null ? ReadOnlySpan<byte>.Empty : new ReadOnlySpan<byte>(bufferModel));
        GC.KeepAlive(bufferProto);
        GC.KeepAlive(bufferModel);
        return ret;
    }

    /// <summary>
    /// Reads a network model stored in Caffe model files from memory.
    /// </summary>
    /// <param name="bufferProto">buffer containing the content of the .prototxt file</param>
    /// <param name="bufferModel">buffer containing the content of the .caffemodel file</param>
    /// <returns></returns>
    /// <remarks>This is shortcut consisting from createCaffeImporter and Net::populateNet calls.</remarks>
    public static Net? ReadNetFromCaffe(ReadOnlySpan<byte> bufferProto, ReadOnlySpan<byte> bufferModel = default)
    {
        if (bufferProto.IsEmpty)
            throw new ArgumentException("Empty span", nameof(bufferProto));

        unsafe
        {
            fixed (byte* bufferProtoPtr = bufferProto)
            fixed (byte* bufferModelPtr = bufferModel)
            {
                NativeMethods.HandleException(
                    NativeMethods.dnn_readNetFromCaffe(
                        bufferProtoPtr, new IntPtr(bufferProto.Length),
                        bufferModelPtr, new IntPtr(bufferModel.Length),
                        out var p));
                return (p == IntPtr.Zero) ? null : new Net(p);
            }
        }
    }

    /// <summary>
    /// Reads a network model stored in Tensorflow model file.
    /// </summary>
    /// <param name="model">path to the .pb file with binary protobuf description of the network architecture</param>
    /// <param name="config">path to the .pbtxt file that contains text graph definition in protobuf format.</param>
    /// <returns>Resulting Net object is built by text graph using weights from a binary one that
    /// let us make it more flexible.</returns>
    /// <remarks>This is shortcut consisting from createTensorflowImporter and Net::populateNet calls.</remarks>
    public static Net? ReadNetFromTensorflow(string model, string? config = null)
    {
        if (model is null)
            throw new ArgumentNullException(nameof(model));

        NativeMethods.HandleException(
            NativeMethods.dnn_readNetFromTensorflow(model, config, out var p));
        return (p == IntPtr.Zero) ? null : new Net(p);
    }

    /// <summary>
    /// Reads a network model stored in Tensorflow model from memory.
    /// </summary>
    /// <param name="bufferModel">buffer containing the content of the pb file</param>
    /// <param name="bufferConfig">buffer containing the content of the pbtxt file (optional)</param>
    /// <returns></returns>
    /// <remarks>This is shortcut consisting from createTensorflowImporter and Net::populateNet calls.</remarks>
    public static Net? ReadNetFromTensorflow(byte[] bufferModel, byte[]? bufferConfig = null)
    {
        if (bufferModel is null)
            throw new ArgumentNullException(nameof(bufferModel));
            
        var ret = ReadNetFromTensorflow(
            new ReadOnlySpan<byte>(bufferModel),
            bufferConfig is null ? ReadOnlySpan<byte>.Empty : new ReadOnlySpan<byte>(bufferConfig));
        GC.KeepAlive(bufferModel);
        GC.KeepAlive(bufferConfig);
        return ret;
    }

    /// <summary>
    /// Reads a network model stored in Tensorflow model from memory.
    /// </summary>
    /// <param name="bufferModel">buffer containing the content of the pb file</param>
    /// <param name="bufferConfig">buffer containing the content of the pbtxt file (optional)</param>
    /// <returns></returns>
    /// <remarks>This is shortcut consisting from createTensorflowImporter and Net::populateNet calls.</remarks>
    public static Net? ReadNetFromTensorflow(ReadOnlySpan<byte> bufferModel, ReadOnlySpan<byte> bufferConfig = default)
    {
        if (bufferModel.IsEmpty)
            throw new ArgumentException("Empty span", nameof(bufferModel));
            
        unsafe
        {
            fixed (byte* bufferModelPtr = bufferModel)
            fixed (byte* bufferConfigPtr = bufferConfig)
            {
                NativeMethods.HandleException(
                    NativeMethods.dnn_readNetFromTensorflow(
                        bufferModelPtr, new IntPtr(bufferModel.Length),
                        bufferConfigPtr, new IntPtr(bufferConfig.Length),
                        out var p));
                return (p == IntPtr.Zero) ? null : new Net(p);
            }
        }
    }

    /// <summary>
    /// Reads a network model stored in Torch model file.
    /// </summary>
    /// <param name="model"></param>
    /// <param name="isBinary"></param>
    /// <returns></returns>
    /// <remarks>This is shortcut consisting from createTorchImporter and Net::populateNet calls.</remarks>
    public static Net? ReadNetFromTorch(string model, bool isBinary = true)
    {
        if (model is null)
            throw new ArgumentNullException(nameof(model));

        NativeMethods.HandleException(
            NativeMethods.dnn_readNetFromTorch(model, isBinary ? 1 : 0, out var p));
        return (p == IntPtr.Zero) ? null : new Net(p);
    }

    /// <summary>
    /// Read deep learning network represented in one of the supported formats.
    /// 
    /// This function automatically detects an origin framework of trained model 
    /// and calls an appropriate function such @ref readNetFromCaffe, @ref readNetFromTensorflow,
    /// </summary>
    /// <param name="model">Binary file contains trained weights. The following file
    /// *                  extensions are expected for models from different frameworks:
    /// *                  * `*.caffemodel` (Caffe, http://caffe.berkeleyvision.org/)
    /// *                  * `*.pb` (TensorFlow, https://www.tensorflow.org/)
    /// *                  * `*.t7` | `*.net` (Torch, http://torch.ch/)
    /// *                  * `*.weights` (Darknet, https://pjreddie.com/darknet/)
    /// *                  * `*.bin` (DLDT, https://software.intel.com/openvino-toolkit)</param>
    /// <param name="config">Text file contains network configuration. It could be a
    /// *                   file with the following extensions:
    /// *                  * `*.prototxt` (Caffe, http://caffe.berkeleyvision.org/)
    /// *                  * `*.pbtxt` (TensorFlow, https://www.tensorflow.org/)
    /// *                  * `*.cfg` (Darknet, https://pjreddie.com/darknet/)
    /// *                  * `*.xml` (DLDT, https://software.intel.com/openvino-toolkit)</param>
    /// <param name="framework">Explicit framework name tag to determine a format.</param>
    /// <returns></returns>
    public static Net ReadNet(string model, string config = "", string framework = "")
    {
        if (string.IsNullOrEmpty(model))
            throw new ArgumentException("message is null or empty", nameof(model));
        config ??= "";
        framework ??= "";

        NativeMethods.HandleException(
            NativeMethods.dnn_readNet(model, config, framework, out var p));
        return new Net(p);
    }

    /// <summary>
    /// Load a network from Intel's Model Optimizer intermediate representation.
    /// Networks imported from Intel's Model Optimizer are launched in Intel's Inference Engine  backend.
    /// </summary>
    /// <param name="xml">XML configuration file with network's topology.</param>
    /// <param name="bin">Binary file with trained weights.</param>
    /// <returns></returns>
    public static Net? ReadNetFromModelOptimizer(string xml, string bin)
    {
        if (xml is null)
            throw new ArgumentNullException(nameof(xml));
        if (bin is null)
            throw new ArgumentNullException(nameof(bin));

        NativeMethods.HandleException(
            NativeMethods.dnn_readNetFromModelOptimizer(xml, bin, out var p));
        return (p == IntPtr.Zero) ? null : new Net(p);
    }

    /// <summary>
    /// Reads a network model ONNX https://onnx.ai/
    /// </summary>
    /// <param name="onnxFile">path to the .onnx file with text description of the network architecture.</param>
    /// <returns>Network object that ready to do forward, throw an exception in failure cases.</returns>
    // ReSharper disable once InconsistentNaming
    public static Net? ReadNetFromONNX(string onnxFile)
    {
        if (onnxFile is null)
            throw new ArgumentNullException(nameof(onnxFile));

        NativeMethods.HandleException(
            NativeMethods.dnn_readNetFromONNX(onnxFile, out var p));
        return (p == IntPtr.Zero) ? null : new Net(p);
    }

    /// <summary>
    /// Reads a network model ONNX https://onnx.ai/ from memory
    /// </summary>
    /// <param name="onnxFileData">memory of the first byte of the buffer.</param>
    /// <returns>Network object that ready to do forward, throw an exception in failure cases.</returns>
    // ReSharper disable once InconsistentNaming
    public static Net? ReadNetFromONNX(byte[] onnxFileData)
    {
        if (onnxFileData is null)
            throw new ArgumentNullException(nameof(onnxFileData));
            
        var ret = ReadNetFromONNX(
            new ReadOnlySpan<byte>(onnxFileData));
        GC.KeepAlive(onnxFileData);
        return ret;
    }

    /// <summary>
    /// Reads a network model ONNX https://onnx.ai/ from memory
    /// </summary>
    /// <param name="onnxFileData">memory of the first byte of the buffer.</param>
    /// <returns>Network object that ready to do forward, throw an exception in failure cases.</returns>
    // ReSharper disable once InconsistentNaming
    public static Net? ReadNetFromONNX(ReadOnlySpan<byte> onnxFileData)
    {
        if (onnxFileData.IsEmpty)
            throw new ArgumentException("Empty span", nameof(onnxFileData));
        unsafe
        {
            fixed (byte* onnxFileDataPtr = onnxFileData)
            {
                NativeMethods.HandleException(
                    NativeMethods.dnn_readNetFromONNX(
                        onnxFileDataPtr, new IntPtr(onnxFileData.Length), out var p));
                return (p == IntPtr.Zero) ? null : new Net(p);
            }
        }
    }

    #endregion

    #region Methods

    /// <summary>
    /// Returns true if there are no layers in the network. 
    /// </summary>
    /// <returns></returns>
    public bool Empty()
    {
        ThrowIfDisposed();

        NativeMethods.HandleException(
            NativeMethods.dnn_Net_empty(ptr, out var ret));
        GC.KeepAlive(this);
        return ret != 0;
    }

    /// <summary>
    /// Dump net to String.
    /// Call method after setInput(). To see correct backend, target and fusion run after forward().
    /// </summary>
    /// <returns>String with structure, hyperparameters, backend, target and fusion</returns>
    public string Dump()
    {
        ThrowIfDisposed();

        using var stdString = new StdString();
        NativeMethods.HandleException(
            NativeMethods.dnn_Net_dump(ptr, stdString.CvPtr));
        GC.KeepAlive(this);
        return stdString.ToString();
    }
        
    /// <summary>
    /// Dump net structure, hyperparameters, backend, target and fusion to dot file
    /// </summary>
    /// <param name="path">path to output file with .dot extension</param>
    public void DumpToFile(string path)
    {
        if (path is null) 
            throw new ArgumentNullException(nameof(path));
        NativeMethods.HandleException(
            NativeMethods.dnn_Net_dumpToFile(ptr, path));
        GC.KeepAlive(this);
    }

    /// <summary>
    /// Converts string name of the layer to the integer identifier.
    /// </summary>
    /// <param name="layer"></param>
    /// <returns>id of the layer, or -1 if the layer wasn't found.</returns>
    public int GetLayerId(string layer)
    {
        if (layer is null)
            throw new ArgumentNullException(nameof(layer));
        ThrowIfDisposed();

        NativeMethods.HandleException(
            NativeMethods.dnn_Net_getLayerId(ptr, layer, out var ret));
        GC.KeepAlive(this);
        return ret;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public string?[] GetLayerNames()
    {
        using var namesVec = new VectorOfString();
        NativeMethods.HandleException(
            NativeMethods.dnn_Net_getLayerNames(ptr, namesVec.CvPtr));
        GC.KeepAlive(this);
        return namesVec.ToArray();
    }

    /// <summary>
    /// Connects output of the first layer to input of the second layer.
    /// </summary>
    /// <param name="outPin">descriptor of the first layer output.</param>
    /// <param name="inpPin">descriptor of the second layer input.</param>
    public void Connect(string outPin, string inpPin)
    {
        if (outPin is null)
            throw new ArgumentNullException(nameof(outPin));
        if (inpPin is null)
            throw new ArgumentNullException(nameof(inpPin));

        NativeMethods.HandleException(
            NativeMethods.dnn_Net_connect1(ptr, outPin, inpPin));
        GC.KeepAlive(this);
    }

    /// <summary>
    /// Connects #@p outNum output of the first layer to #@p inNum input of the second layer.
    /// </summary>
    /// <param name="outLayerId">identifier of the first layer</param>
    /// <param name="outNum">identifier of the second layer</param>
    /// <param name="inpLayerId">number of the first layer output</param>
    /// <param name="inpNum">number of the second layer input</param>
    public void Connect(int outLayerId, int outNum, int inpLayerId, int inpNum)
    {
        NativeMethods.HandleException(
            NativeMethods.dnn_Net_connect2(ptr, outLayerId, outNum, inpLayerId, inpNum));
        GC.KeepAlive(this);
    }

    /// <summary>
    /// Sets outputs names of the network input pseudo layer.
    /// </summary>
    /// <param name="inputBlobNames"></param>
    /// <remarks>
    /// * Each net always has special own the network input pseudo layer with id=0.
    /// * This layer stores the user blobs only and don't make any computations.
    /// * In fact, this layer provides the only way to pass user data into the network.
    /// * As any other layer, this layer can label its outputs and this function provides an easy way to do this.
    /// </remarks>
    public void SetInputsNames(IEnumerable<string> inputBlobNames)
    {
        if (inputBlobNames is null)
            throw new ArgumentNullException(nameof(inputBlobNames));

        var inputBlobNamesArray = inputBlobNames.ToArray();
        NativeMethods.HandleException(
            NativeMethods.dnn_Net_setInputsNames(ptr, inputBlobNamesArray, inputBlobNamesArray.Length));
        GC.KeepAlive(this);
    }

    /// <summary>
    /// Runs forward pass to compute output of layer with name @p outputName.
    /// By default runs forward pass for the whole network.
    /// </summary>
    /// <param name="outputName">name for layer which output is needed to get</param>
    /// <returns>blob for first output of specified layer.</returns>
    public Mat Forward(string? outputName = null)
    {
        NativeMethods.HandleException(
            NativeMethods.dnn_Net_forward1(ptr, outputName, out var ret));
        GC.KeepAlive(this);
        return new Mat(ret);
    }

    /// <summary>
    /// Runs forward pass to compute output of layer with name @p outputName.
    /// </summary>
    /// <param name="outputBlobs">contains all output blobs for specified layer.</param>
    /// <param name="outputName">name for layer which output is needed to get. 
    /// If outputName is empty, runs forward pass for the whole network.</param>
    public void Forward(IEnumerable<Mat> outputBlobs, string? outputName = null)
    {
        if (outputBlobs is null)
            throw new ArgumentNullException(nameof(outputBlobs));

        var outputBlobsPtrs = outputBlobs.Select(x => x.CvPtr).ToArray();
        NativeMethods.HandleException(
            NativeMethods.dnn_Net_forward2(ptr, outputBlobsPtrs, outputBlobsPtrs.Length, outputName));

        GC.KeepAlive(outputBlobs);
        GC.KeepAlive(this);
    }

    /// <summary>
    /// Runs forward pass to compute outputs of layers listed in @p outBlobNames.
    /// </summary>
    /// <param name="outputBlobs">contains blobs for first outputs of specified layers.</param>
    /// <param name="outBlobNames">names for layers which outputs are needed to get</param>
    public void Forward(IEnumerable<Mat> outputBlobs, IEnumerable<string> outBlobNames)
    {
        if (outputBlobs is null)
            throw new ArgumentNullException(nameof(outputBlobs));
        if (outBlobNames is null)
            throw new ArgumentNullException(nameof(outBlobNames));

        var outputBlobsPtrs = outputBlobs.Select(x => x.CvPtr).ToArray();
        var outBlobNamesArray = outBlobNames.ToArray();
        NativeMethods.HandleException(
            NativeMethods.dnn_Net_forward3(
                ptr, outputBlobsPtrs, outputBlobsPtrs.Length, outBlobNamesArray, outBlobNamesArray.Length));

        GC.KeepAlive(outputBlobs);
        GC.KeepAlive(this);
    }

    /// <summary>
    /// Compile Halide layers.
    /// Schedule layers that support Halide backend. Then compile them for 
    /// specific target.For layers that not represented in scheduling file 
    /// or if no manual scheduling used at all, automatic scheduling will be applied.
    /// </summary>
    /// <param name="scheduler">Path to YAML file with scheduling directives.</param>
    public void SetHalideScheduler(string scheduler)
    {
        ThrowIfDisposed();
        NativeMethods.HandleException(
            NativeMethods.dnn_Net_setHalideScheduler(ptr, scheduler));
        GC.KeepAlive(this);
    }

    /// <summary>
    /// Ask network to use specific computation backend where it supported.
    /// </summary>
    /// <param name="backendId">backend identifier.</param>
    public void SetPreferableBackend(Backend backendId)
    {
        ThrowIfDisposed();
        NativeMethods.HandleException(
            NativeMethods.dnn_Net_setPreferableBackend(ptr, (int)backendId));
        GC.KeepAlive(this);
    }

    /// <summary>
    /// Ask network to make computations on specific target device.
    /// </summary>
    /// <param name="targetId">target identifier.</param>
    public void SetPreferableTarget(Target targetId)
    {
        ThrowIfDisposed();
        NativeMethods.HandleException(
            NativeMethods.dnn_Net_setPreferableTarget(ptr, (int)targetId));
        GC.KeepAlive(this);
    }

    /// <summary>
    /// Sets the new value for the layer output blob
    /// </summary>
    /// <param name="blob">new blob.</param>
    /// <param name="name">descriptor of the updating layer output blob.</param>
    /// <remarks>
    /// connect(String, String) to know format of the descriptor.
    /// If updating blob is not empty then @p blob must have the same shape, 
    /// because network reshaping is not implemented yet.
    /// </remarks>
    public void SetInput(Mat blob, string name = "")
    {
        if (blob is null)
            throw new ArgumentNullException(nameof(blob));

        NativeMethods.HandleException(
            NativeMethods.dnn_Net_setInput(ptr, blob.CvPtr, name));
        GC.KeepAlive(this);
    }

    /// <summary>
    /// Returns indexes of layers with unconnected outputs.
    /// </summary>
    /// <returns></returns>
    public int[] GetUnconnectedOutLayers()
    {
        ThrowIfDisposed();

        using var resultVec = new VectorOfInt32();
        NativeMethods.HandleException(
            NativeMethods.dnn_Net_getUnconnectedOutLayers(ptr, resultVec.CvPtr));
        GC.KeepAlive(this);
        return resultVec.ToArray();
    }

    /// <summary>
    /// Returns names of layers with unconnected outputs.
    /// </summary>
    /// <returns></returns>
    public string?[] GetUnconnectedOutLayersNames()
    {
        ThrowIfDisposed();
            
        using var resultVec = new VectorOfString();
        NativeMethods.HandleException(
            NativeMethods.dnn_Net_getUnconnectedOutLayersNames(ptr, resultVec.CvPtr));
        GC.KeepAlive(this);
        return resultVec.ToArray();
    }

    /// <summary>
    /// Enables or disables layer fusion in the network.
    /// </summary>
    /// <param name="fusion">true to enable the fusion, false to disable. The fusion is enabled by default.</param>
    public void EnableFusion(bool fusion)
    {
        ThrowIfDisposed();
        NativeMethods.HandleException(
            NativeMethods.dnn_Net_enableFusion(ptr, fusion ? 1 : 0));
        GC.KeepAlive(this);
    }

    /// <summary>
    /// Returns overall time for inference and timings (in ticks) for layers.
    /// Indexes in returned vector correspond to layers ids.Some layers can be fused with others,
    /// in this case zero ticks count will be return for that skipped layers.
    /// </summary>
    /// <param name="timings">vector for tick timings for all layers.</param>
    /// <returns>overall ticks for model inference.</returns>
    public long GetPerfProfile(out double[] timings)
    {
        ThrowIfDisposed();

        using var timingsVec = new VectorOfDouble();
        NativeMethods.HandleException(
            NativeMethods.dnn_Net_getPerfProfile(ptr, timingsVec.CvPtr, out var ret));
        GC.KeepAlive(this);

        timings = timingsVec.ToArray();
        return ret;
    }

    #endregion
}
