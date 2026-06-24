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
public class Net : CvObject
{
    #region Init & Disposal

    /// <inheritdoc />
    /// <summary>
    /// Default constructor.
    /// </summary>
    public Net()
    {
        NativeMethods.HandleException(
            NativeMethods.dnn_Net_new(out var p));
        InitSafeHandle(p);
    }

    /// <inheritdoc />
    /// <summary>
    /// </summary>
    protected Net(IntPtr ptr)
    {
        InitSafeHandle(ptr);
    }
        
    /// <inheritdoc />
    /// <summary>
    /// </summary>

    private void InitSafeHandle(IntPtr p, bool ownsHandle = true)
    {
        SetSafeHandle(new OpenCvPtrSafeHandle(p, ownsHandle,
            static h => NativeMethods.HandleException(NativeMethods.dnn_Net_delete(h))));
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

    /// <summary>
    /// Reads a network model stored in TFLite (https://www.tensorflow.org/lite) framework's format.
    /// </summary>
    /// <param name="model">path to the .tflite file with binary flatbuffers description of the network architecture.</param>
    /// <returns>Network object that ready to do forward, throw an exception in failure cases.</returns>
    // ReSharper disable once InconsistentNaming
    public static Net? ReadNetFromTFLite(string model)
    {
        if (model is null)
            throw new ArgumentNullException(nameof(model));

        NativeMethods.HandleException(
            NativeMethods.dnn_readNetFromTFLite(model, out var p));
        return (p == IntPtr.Zero) ? null : new Net(p);
    }

    /// <summary>
    /// Reads a network model stored in TFLite framework's format from memory.
    /// </summary>
    /// <param name="bufferModel">buffer containing the content of the tflite file.</param>
    /// <returns>Network object that ready to do forward, throw an exception in failure cases.</returns>
    // ReSharper disable once InconsistentNaming
    public static Net? ReadNetFromTFLite(byte[] bufferModel)
    {
        if (bufferModel is null)
            throw new ArgumentNullException(nameof(bufferModel));

        var ret = ReadNetFromTFLite(new ReadOnlySpan<byte>(bufferModel));
        GC.KeepAlive(bufferModel);
        return ret;
    }

    /// <summary>
    /// Reads a network model stored in TFLite framework's format from memory.
    /// </summary>
    /// <param name="bufferModel">buffer containing the content of the tflite file.</param>
    /// <returns>Network object that ready to do forward, throw an exception in failure cases.</returns>
    // ReSharper disable once InconsistentNaming
    public static Net? ReadNetFromTFLite(ReadOnlySpan<byte> bufferModel)
    {
        if (bufferModel.IsEmpty)
            throw new ArgumentException("Empty span", nameof(bufferModel));
        unsafe
        {
            fixed (byte* bufferModelPtr = bufferModel)
            {
                NativeMethods.HandleException(
                    NativeMethods.dnn_readNetFromTFLite(
                        bufferModelPtr, new IntPtr(bufferModel.Length), out var p));
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
            NativeMethods.dnn_Net_empty(CvPtr, out var ret));
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
            NativeMethods.dnn_Net_dump(CvPtr, stdString.CvPtr));
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
            NativeMethods.dnn_Net_dumpToFile(CvPtr, path));
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
            NativeMethods.dnn_Net_getLayerId(CvPtr, layer, out var ret));
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
            NativeMethods.dnn_Net_getLayerNames(CvPtr, namesVec.CvPtr));
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
            NativeMethods.dnn_Net_connect1(CvPtr, outPin, inpPin));
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
            NativeMethods.dnn_Net_connect2(CvPtr, outLayerId, outNum, inpLayerId, inpNum));
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
            NativeMethods.dnn_Net_setInputsNames(CvPtr, inputBlobNamesArray, inputBlobNamesArray.Length));
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
            NativeMethods.dnn_Net_forward1(CvPtr, outputName, out var ret));
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
            NativeMethods.dnn_Net_forward2(CvPtr, outputBlobsPtrs, outputBlobsPtrs.Length, outputName));

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
                CvPtr, outputBlobsPtrs, outputBlobsPtrs.Length, outBlobNamesArray, outBlobNamesArray.Length));

        GC.KeepAlive(outputBlobs);
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
            NativeMethods.dnn_Net_setPreferableBackend(CvPtr, (int)backendId));
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
            NativeMethods.dnn_Net_setPreferableTarget(CvPtr, (int)targetId));
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
            NativeMethods.dnn_Net_setInput(CvPtr, blob.CvPtr, name));
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
            NativeMethods.dnn_Net_getUnconnectedOutLayers(CvPtr, resultVec.CvPtr));
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
            NativeMethods.dnn_Net_getUnconnectedOutLayersNames(CvPtr, resultVec.CvPtr));
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
            NativeMethods.dnn_Net_enableFusion(CvPtr, fusion ? 1 : 0));
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
            NativeMethods.dnn_Net_getPerfProfile(CvPtr, timingsVec.CvPtr, out var ret));
        GC.KeepAlive(this);

        timings = timingsVec.ToArray();
        return ret;
    }

    /// <summary>
    /// Specify shape of network input.
    /// </summary>
    /// <param name="inputName">name of the input layer.</param>
    /// <param name="shape">the shape of the input blob.</param>
    public void SetInputShape(string inputName, IEnumerable<int> shape)
    {
        if (inputName is null)
            throw new ArgumentNullException(nameof(inputName));
        if (shape is null)
            throw new ArgumentNullException(nameof(shape));
        ThrowIfDisposed();

        var shapeArray = shape as int[] ?? shape.ToArray();
        NativeMethods.HandleException(
            NativeMethods.dnn_Net_setInputShape(CvPtr, inputName, shapeArray, shapeArray.Length));
        GC.KeepAlive(this);
    }

    /// <summary>
    /// Returns parameter blob of the layer.
    /// </summary>
    /// <param name="layer">id of the layer.</param>
    /// <param name="numParam">index of the layer parameter in the Layer::blobs array.</param>
    /// <returns></returns>
    public Mat GetParam(int layer, int numParam = 0)
    {
        ThrowIfDisposed();
        NativeMethods.HandleException(
            NativeMethods.dnn_Net_getParam(CvPtr, layer, numParam, out var ret));
        GC.KeepAlive(this);
        return new Mat(ret);
    }

    /// <summary>
    /// Returns parameter blob of the layer.
    /// </summary>
    /// <param name="layerName">name of the layer.</param>
    /// <param name="numParam">index of the layer parameter in the Layer::blobs array.</param>
    /// <returns></returns>
    public Mat GetParam(string layerName, int numParam = 0)
    {
        if (layerName is null)
            throw new ArgumentNullException(nameof(layerName));
        return GetParam(GetLayerId(layerName), numParam);
    }

    /// <summary>
    /// Sets the new value for the learned param of the layer.
    /// </summary>
    /// <param name="layer">id of the layer.</param>
    /// <param name="numParam">index of the layer parameter in the Layer::blobs array.</param>
    /// <param name="blob">the new value.</param>
    public void SetParam(int layer, int numParam, Mat blob)
    {
        if (blob is null)
            throw new ArgumentNullException(nameof(blob));
        ThrowIfDisposed();
        blob.ThrowIfDisposed();
        NativeMethods.HandleException(
            NativeMethods.dnn_Net_setParam(CvPtr, layer, numParam, blob.CvPtr));
        GC.KeepAlive(this);
        GC.KeepAlive(blob);
    }

    /// <summary>
    /// Sets the new value for the learned param of the layer.
    /// </summary>
    /// <param name="layerName">name of the layer.</param>
    /// <param name="numParam">index of the layer parameter in the Layer::blobs array.</param>
    /// <param name="blob">the new value.</param>
    public void SetParam(string layerName, int numParam, Mat blob)
    {
        if (layerName is null)
            throw new ArgumentNullException(nameof(layerName));
        SetParam(GetLayerId(layerName), numParam, blob);
    }

    /// <summary>
    /// Returns list of types for layer used in model.
    /// </summary>
    /// <returns></returns>
    public string?[] GetLayerTypes()
    {
        ThrowIfDisposed();
        using var resultVec = new VectorOfString();
        NativeMethods.HandleException(
            NativeMethods.dnn_Net_getLayerTypes(CvPtr, resultVec.CvPtr));
        GC.KeepAlive(this);
        return resultVec.ToArray();
    }

    /// <summary>
    /// Returns count of layers of specified type.
    /// </summary>
    /// <param name="layerType">type.</param>
    /// <returns>count of layers</returns>
    public int GetLayersCount(string layerType)
    {
        if (layerType is null)
            throw new ArgumentNullException(nameof(layerType));
        ThrowIfDisposed();
        NativeMethods.HandleException(
            NativeMethods.dnn_Net_getLayersCount(CvPtr, layerType, out var ret));
        GC.KeepAlive(this);
        return ret;
    }

    /// <summary>
    /// Enables or disables the Winograd convolution optimization.
    /// </summary>
    /// <param name="useWinograd">true to enable, false to disable.</param>
    public void EnableWinograd(bool useWinograd)
    {
        ThrowIfDisposed();
        NativeMethods.HandleException(
            NativeMethods.dnn_Net_enableWinograd(CvPtr, useWinograd ? 1 : 0));
        GC.KeepAlive(this);
    }

    /// <summary>
    /// Dump net structure, hyperparameters, backend, target and fusion to a pbtxt file.
    /// </summary>
    /// <remarks>Requires the network's output blobs to be allocated (e.g. after the input
    /// shape is known and the net has been set up); otherwise OpenCV raises an exception.</remarks>
    /// <param name="path">path to output file with .pbtxt extension.</param>
    public void DumpToPbtxt(string path)
    {
        if (path is null)
            throw new ArgumentNullException(nameof(path));
        ThrowIfDisposed();
        NativeMethods.HandleException(
            NativeMethods.dnn_Net_dumpToPbtxt(CvPtr, path));
        GC.KeepAlive(this);
    }

    /// <summary>
    /// Returns the original framework format the network was loaded from.
    /// </summary>
    /// <returns></returns>
    public ModelFormat GetModelFormat()
    {
        ThrowIfDisposed();
        NativeMethods.HandleException(
            NativeMethods.dnn_Net_getModelFormat(CvPtr, out var ret));
        GC.KeepAlive(this);
        return (ModelFormat)ret;
    }

    /// <summary>
    /// Enables the Key-Value (KV) cache, used to accelerate inference of transformer / LLM models.
    /// </summary>
    public void EnableKVCache()
    {
        ThrowIfDisposed();
        NativeMethods.HandleException(
            NativeMethods.dnn_Net_enableKVCache(CvPtr));
        GC.KeepAlive(this);
    }

    /// <summary>
    /// Disables the Key-Value (KV) cache.
    /// </summary>
    public void DisableKVCache()
    {
        ThrowIfDisposed();
        NativeMethods.HandleException(
            NativeMethods.dnn_Net_disableKVCache(CvPtr));
        GC.KeepAlive(this);
    }

    /// <summary>
    /// Resets the Key-Value (KV) cache contents.
    /// </summary>
    public void ResetKVCache()
    {
        ThrowIfDisposed();
        NativeMethods.HandleException(
            NativeMethods.dnn_Net_resetKVCache(CvPtr));
        GC.KeepAlive(this);
    }

    /// <summary>
    /// Prints per-layer performance profile to the standard output.
    /// </summary>
    public void PrintPerfProfile()
    {
        ThrowIfDisposed();
        NativeMethods.HandleException(
            NativeMethods.dnn_Net_printPerfProfile(CvPtr));
        GC.KeepAlive(this);
    }

    #endregion
}
