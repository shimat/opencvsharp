using OpenCvSharp.Internal;
using OpenCvSharp.Internal.Vectors;

// ReSharper disable UnusedMember.Global
// ReSharper disable InconsistentNaming
// ReSharper disable CommentTypo

namespace OpenCvSharp.Dnn;

/// <summary>
/// cv::dnn functions
/// </summary>
public static class CvDnn
{
    /// <summary>
    /// Reads a network model stored in Tensorflow model file.
    /// </summary>
    /// <param name="model">path to the .pb file with binary protobuf description of the network architecture</param>
    /// <param name="config">path to the .pbtxt file that contains text graph definition in protobuf format.</param>
    /// <returns>Resulting Net object is built by text graph using weights from a binary one that
    /// let us make it more flexible.</returns>
    /// <remarks>This is shortcut consisting from createTensorflowImporter and Net::populateNet calls.</remarks>
    /// <param name="engine">DNN engine to use. <see cref="EngineType.Auto"/> tries the new engine first and falls back to the classic one.</param>
    public static Net? ReadNetFromTensorflow(string model, string? config = null, EngineType engine = EngineType.Auto)
    {
        return Net.ReadNetFromTensorflow(model, config, engine);
    }

    /// <summary>
    /// Reads a network model stored in Tensorflow model file from memory.
    /// </summary>
    /// <param name="bufferModel">buffer containing the content of the pb file</param>
    /// <param name="bufferConfig">buffer containing the content of the pbtxt file (optional)</param>
    /// <returns></returns>
    /// <remarks>This is shortcut consisting from createTensorflowImporter and Net::populateNet calls.</remarks>
    /// <param name="engine">DNN engine to use. <see cref="EngineType.Auto"/> tries the new engine first and falls back to the classic one.</param>
    public static Net? ReadNetFromTensorflow(byte[] bufferModel, byte[]? bufferConfig = null, EngineType engine = EngineType.Auto)
    {
        return Net.ReadNetFromTensorflow(bufferModel, bufferConfig, engine);
    }

    /// <summary>
    /// Reads a network model stored in Tensorflow model file from stream.
    /// </summary>
    /// <param name="bufferModel">buffer containing the content of the pb file</param>
    /// <param name="bufferConfig">buffer containing the content of the pbtxt file (optional)</param>
    /// <returns></returns>
    /// <remarks>This is shortcut consisting from createTensorflowImporter and Net::populateNet calls.</remarks>
    /// <param name="engine">DNN engine to use. <see cref="EngineType.Auto"/> tries the new engine first and falls back to the classic one.</param>
    public static Net? ReadNetFromTensorflow(Stream bufferModel, Stream? bufferConfig = null, EngineType engine = EngineType.Auto)
    {
        if (bufferModel is null)
            throw new ArgumentNullException(nameof(bufferModel));
        return Net.ReadNetFromTensorflow(
            bufferModel.StreamToArray(),
            bufferConfig?.StreamToArray(),
            engine);
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
    /// <param name="engine">DNN engine to use. <see cref="EngineType.Auto"/> tries the new engine first and falls back to the classic one.</param>
    public static Net ReadNet(string model, string config = "", string framework = "", EngineType engine = EngineType.Auto)
    {
        return Net.ReadNet(model, config, framework, engine);
    }
        
    /// <summary>
    /// Reads a network model ONNX https://onnx.ai/ from memory
    /// </summary>
    /// <param name="onnxFile"></param>
    /// <returns></returns>
    /// <param name="engine">DNN engine to use. <see cref="EngineType.Auto"/> tries the new engine first and falls back to the classic one.</param>
    public static Net? ReadNetFromOnnx(string onnxFile, EngineType engine = EngineType.Auto)
    {
        return Net.ReadNetFromONNX(onnxFile, engine);
    }

    /// <summary>
    /// Reads a network model ONNX https://onnx.ai/ from memory
    /// </summary>
    /// <param name="onnxFileData">memory of the first byte of the buffer.</param>
    /// <returns></returns>
    /// <param name="engine">DNN engine to use. <see cref="EngineType.Auto"/> tries the new engine first and falls back to the classic one.</param>
    public static Net? ReadNetFromOnnx(byte[] onnxFileData, EngineType engine = EngineType.Auto)
    {
        return Net.ReadNetFromONNX(onnxFileData, engine);
    }

    /// <summary>
    /// Reads a network model ONNX https://onnx.ai/ from memory
    /// </summary>
    /// <param name="onnxFileData">memory of the first byte of the buffer.</param>
    /// <returns></returns>
    /// <param name="engine">DNN engine to use. <see cref="EngineType.Auto"/> tries the new engine first and falls back to the classic one.</param>
    public static Net? ReadNetFromOnnx(ReadOnlySpan<byte> onnxFileData, EngineType engine = EngineType.Auto)
    {
        return Net.ReadNetFromONNX(onnxFileData, engine);
    }

    /// <summary>
    /// Reads a network model ONNX https://onnx.ai/  from stream.
    /// </summary>
    /// <param name="onnxFileStream">memory of the first byte of the buffer.</param>
    /// <returns></returns>
    /// <param name="engine">DNN engine to use. <see cref="EngineType.Auto"/> tries the new engine first and falls back to the classic one.</param>
    public static Net? ReadNetFromOnnx(Stream onnxFileStream, EngineType engine = EngineType.Auto)
    {
        if (onnxFileStream is null)
            throw new ArgumentNullException(nameof(onnxFileStream));
        return ReadNetFromOnnx(StreamToArray(onnxFileStream), engine);
    }

    /// <summary>
    /// Reads a network model stored in TFLite (https://www.tensorflow.org/lite) framework's format.
    /// </summary>
    /// <param name="model">path to the .tflite file with binary flatbuffers description of the network architecture.</param>
    /// <returns></returns>
    /// <param name="engine">DNN engine to use. <see cref="EngineType.Auto"/> tries the new engine first and falls back to the classic one.</param>
    // ReSharper disable once InconsistentNaming
    public static Net? ReadNetFromTFLite(string model, EngineType engine = EngineType.Auto)
    {
        return Net.ReadNetFromTFLite(model, engine);
    }

    /// <summary>
    /// Reads a network model stored in TFLite framework's format from memory.
    /// </summary>
    /// <param name="bufferModel">buffer containing the content of the tflite file.</param>
    /// <returns></returns>
    /// <param name="engine">DNN engine to use. <see cref="EngineType.Auto"/> tries the new engine first and falls back to the classic one.</param>
    // ReSharper disable once InconsistentNaming
    public static Net? ReadNetFromTFLite(byte[] bufferModel, EngineType engine = EngineType.Auto)
    {
        return Net.ReadNetFromTFLite(bufferModel, engine);
    }

    /// <summary>
    /// Reads a network model stored in TFLite framework's format from memory.
    /// </summary>
    /// <param name="bufferModel">buffer containing the content of the tflite file.</param>
    /// <returns></returns>
    /// <param name="engine">DNN engine to use. <see cref="EngineType.Auto"/> tries the new engine first and falls back to the classic one.</param>
    // ReSharper disable once InconsistentNaming
    public static Net? ReadNetFromTFLite(ReadOnlySpan<byte> bufferModel, EngineType engine = EngineType.Auto)
    {
        return Net.ReadNetFromTFLite(bufferModel, engine);
    }

    /// <summary>
    /// Reads a network model stored in TFLite framework's format from stream.
    /// </summary>
    /// <param name="bufferModelStream">stream containing the content of the tflite file.</param>
    /// <returns></returns>
    /// <param name="engine">DNN engine to use. <see cref="EngineType.Auto"/> tries the new engine first and falls back to the classic one.</param>
    // ReSharper disable once InconsistentNaming
    public static Net? ReadNetFromTFLite(Stream bufferModelStream, EngineType engine = EngineType.Auto)
    {
        if (bufferModelStream is null)
            throw new ArgumentNullException(nameof(bufferModelStream));
        return Net.ReadNetFromTFLite(StreamToArray(bufferModelStream), engine);
    }

    /// <summary>
    /// Creates blob from .pb file.
    /// </summary>
    /// <param name="path">path to the .pb file with input tensor.</param>
    /// <returns></returns>
    public static Mat? ReadTensorFromONNX(string path)
    {
        if (path is null)
            throw new ArgumentNullException(nameof(path));

        NativeMethods.HandleException(
            NativeMethods.dnn_readTensorFromONNX(path, out var ret));
        return (ret == IntPtr.Zero) ? null : new Mat(ret);
    }

    /// <summary>
    /// Creates 4-dimensional blob from image. Optionally resizes and crops @p image from center, 
    /// subtract @p mean values, scales values by @p scalefactor, swap Blue and Red channels.
    /// </summary>
    /// <param name="image">input image (with 1- or 3-channels).</param>
    /// <param name="scaleFactor">multiplier for @p image values.</param>
    /// <param name="size">spatial size for output image</param>
    /// <param name="mean">scalar with mean values which are subtracted from channels. Values are intended 
    /// to be in (mean-R, mean-G, mean-B) order if @p image has BGR ordering and @p swapRB is true.</param>
    /// <param name="swapRB">flag which indicates that swap first and last channels in 3-channel image is necessary.</param>
    /// <param name="crop">flag which indicates whether image will be cropped after resize or not</param>
    /// <returns>4-dimansional Mat with NCHW dimensions order.</returns>
    /// <remarks>if @p crop is true, input image is resized so one side after resize is equal to corresponing 
    /// dimension in @p size and another one is equal or larger.Then, crop from the center is performed. 
    /// If @p crop is false, direct resize without cropping and preserving aspect ratio is performed.</remarks>
    public static Mat BlobFromImage(
        Mat image, double scaleFactor = 1.0, Size size = default,
        Scalar mean = default, bool swapRB = true, bool crop = true)
    {
        if (image is null)
            throw new ArgumentNullException(nameof(image));

        NativeMethods.HandleException(
            NativeMethods.dnn_blobFromImage(
                image.CvPtr, scaleFactor, size, mean, swapRB ? 1 : 0, crop ? 1 : 0, out var ret));
        return new Mat(ret);
    }

    /// <summary>
    /// Creates 4-dimensional blob from series of images. Optionally resizes and 
    /// crops @p images from center, subtract @p mean values, scales values by @p scalefactor, swap Blue and Red channels.
    /// </summary>
    /// <param name="images">input images (all with 1- or 3-channels).</param>
    /// <param name="scaleFactor">multiplier for @p image values.</param>
    /// <param name="size">spatial size for output image</param>
    /// <param name="mean">scalar with mean values which are subtracted from channels. Values are intended 
    /// to be in (mean-R, mean-G, mean-B) order if @p image has BGR ordering and @p swapRB is true.</param>
    /// <param name="swapRB">flag which indicates that swap first and last channels in 3-channel image is necessary.</param>
    /// <param name="crop">flag which indicates whether image will be cropped after resize or not</param>
    /// <returns>4-dimansional Mat with NCHW dimensions order.</returns>
    /// <remarks>if @p crop is true, input image is resized so one side after resize is equal to corresponing 
    /// dimension in @p size and another one is equal or larger.Then, crop from the center is performed. 
    /// If @p crop is false, direct resize without cropping and preserving aspect ratio is performed.</remarks>
    public static Mat BlobFromImages(
        IEnumerable<Mat> images, double scaleFactor,
        Size size = default, Scalar mean = default, bool swapRB = true, bool crop = true)
    {
        if (images is null)
            throw new ArgumentNullException(nameof(images));

        var imagesPointers = images.Select(x => x.CvPtr).ToArray();

        NativeMethods.HandleException(
            NativeMethods.dnn_blobFromImages(
                imagesPointers, imagesPointers.Length, scaleFactor, size, mean, swapRB ? 1 : 0, crop ? 1 : 0,
                out var ret));
        return new Mat(ret);
    }

    /// <summary>
    /// Creates 4-dimensional blob from image with given params.
    /// This function is an extension of <see cref="BlobFromImage(Mat, double, Size, Scalar, bool, bool)"/> to meet more image preprocess needs.
    /// </summary>
    /// <param name="image">input image (all with 1-, 3- or 4-channels).</param>
    /// <param name="param">params with preprocessing parameters. If null, default params are used.</param>
    /// <returns>4-dimensional Mat.</returns>
    public static Mat BlobFromImageWithParams(InputArray image, Image2BlobParams? param = null)
    {
        if (image is null)
            throw new ArgumentNullException(nameof(image));
        image.ThrowIfDisposed();
        param ??= new Image2BlobParams();

        NativeMethods.HandleException(
            NativeMethods.dnn_blobFromImageWithParams(
                image.CvPtr, param.ScaleFactor, param.Size, param.Mean,
                param.SwapRB ? 1 : 0, (int)param.Depth, (int)param.DataLayout, (int)param.PaddingMode, param.BorderValue,
                out var ret));
        GC.KeepAlive(image);
        return new Mat(ret);
    }

    /// <summary>
    /// Creates 4-dimensional blob from series of images with given params.
    /// </summary>
    /// <param name="images">input images (all with 1-, 3- or 4-channels).</param>
    /// <param name="param">params with preprocessing parameters. If null, default params are used.</param>
    /// <returns>4-dimensional Mat.</returns>
    public static Mat BlobFromImagesWithParams(IEnumerable<Mat> images, Image2BlobParams? param = null)
    {
        if (images is null)
            throw new ArgumentNullException(nameof(images));
        param ??= new Image2BlobParams();

        var imagesPointers = images.Select(x => x.CvPtr).ToArray();
        NativeMethods.HandleException(
            NativeMethods.dnn_blobFromImagesWithParams(
                imagesPointers, imagesPointers.Length, param.ScaleFactor, param.Size, param.Mean,
                param.SwapRB ? 1 : 0, (int)param.Depth, (int)param.DataLayout, (int)param.PaddingMode, param.BorderValue,
                out var ret));
        GC.KeepAlive(images);
        return new Mat(ret);
    }

    /// <summary>
    /// Parse a 4D blob and output the images it contains as 2D arrays through a simpler data structure (std::vector&lt;cv::Mat&gt;).
    /// </summary>
    /// <param name="blob">4 dimensional array (images, channels, height, width) in floating point precision (CV_32F) from
    /// which you would like to extract the images.</param>
    /// <returns>array of 2D Mat containing the images extracted from the blob in floating point precision (CV_32F).</returns>
    public static Mat[] ImagesFromBlob(Mat blob)
    {
        if (blob is null)
            throw new ArgumentNullException(nameof(blob));
        blob.ThrowIfDisposed();

        using var imagesVec = new Internal.Vectors.VectorOfMat();
        NativeMethods.HandleException(
            NativeMethods.dnn_imagesFromBlob(blob.CvPtr, imagesVec.CvPtr));
        GC.KeepAlive(blob);
        return imagesVec.ToArray();
    }

    /// <summary>
    /// Create a text representation for a binary network stored in protocol buffer format.
    /// </summary>
    /// <param name="model">A path to binary network.</param>
    /// <param name="output">A path to output text file to be created.</param>
    public static void WriteTextGraph(string model, string output)
    {
        if (model is null)
            throw new ArgumentNullException(nameof(model));
        if (output is null)
            throw new ArgumentNullException(nameof(output));

        NativeMethods.HandleException(
            NativeMethods.dnn_writeTextGraph(model, output));
    }
        
    /// <summary>
    /// Performs non maximum suppression given boxes and corresponding scores.
    /// </summary>
    /// <param name="bboxes">a set of bounding boxes to apply NMS.</param>
    /// <param name="scores">a set of corresponding confidences.</param>
    /// <param name="scoreThreshold">a threshold used to filter boxes by score.</param>
    /// <param name="nmsThreshold">a threshold used in non maximum suppression.</param>
    /// <param name="indices">the kept indices of bboxes after NMS.</param>
    /// <param name="eta">a coefficient in adaptive threshold formula</param>
    /// <param name="topK">if `&gt;0`, keep at most @p top_k picked indices.</param>
    // ReSharper disable once IdentifierTypo
    public static void NMSBoxes(IEnumerable<Rect> bboxes, IEnumerable<float> scores,
        float scoreThreshold, float nmsThreshold,
        out int[] indices,
        float eta = 1.0f, int topK = 0)
    {
        if (bboxes is null)
            throw new ArgumentNullException(nameof(bboxes));
        if (scores is null)
            throw new ArgumentNullException(nameof(scores));

        // ReSharper disable once IdentifierTypo
        using var bboxesVec = new StdVector<Rect>(bboxes);
        using var scoresVec = new StdVector<float>(scores);
        using var indicesVec = new StdVector<int>();
        NativeMethods.HandleException(
            NativeMethods.dnn_NMSBoxes_Rect(
                bboxesVec.CvPtr, scoresVec.CvPtr, scoreThreshold, nmsThreshold,
                indicesVec.CvPtr, eta, topK));
        indices = indicesVec.ToArray();
    }

    /// <summary>
    /// Performs non maximum suppression given boxes and corresponding scores.
    /// </summary>
    /// <param name="bboxes">a set of bounding boxes to apply NMS.</param>
    /// <param name="scores">a set of corresponding confidences.</param>
    /// <param name="scoreThreshold">a threshold used to filter boxes by score.</param>
    /// <param name="nmsThreshold">a threshold used in non maximum suppression.</param>
    /// <param name="indices">the kept indices of bboxes after NMS.</param>
    /// <param name="eta">a coefficient in adaptive threshold formula</param>
    /// <param name="topK">if `&gt;0`, keep at most @p top_k picked indices.</param>
    // ReSharper disable once IdentifierTypo
    public static void NMSBoxes(IEnumerable<Rect2d> bboxes, IEnumerable<float> scores,
        float scoreThreshold, float nmsThreshold,
        out int[] indices,
        float eta = 1.0f, int topK = 0)
    {
        if (bboxes is null)
            throw new ArgumentNullException(nameof(bboxes));
        if (scores is null)
            throw new ArgumentNullException(nameof(scores));

        // ReSharper disable once IdentifierTypo
        using var bboxesVec = new StdVector<Rect2d>(bboxes);
        using var scoresVec = new StdVector<float>(scores);
        using var indicesVec = new StdVector<int>();
        NativeMethods.HandleException(
            NativeMethods.dnn_NMSBoxes_Rect2d(
                bboxesVec.CvPtr, scoresVec.CvPtr, scoreThreshold, nmsThreshold,
                indicesVec.CvPtr, eta, topK));
        indices = indicesVec.ToArray();
    }

    /// <summary>
    /// Performs non maximum suppression given boxes and corresponding scores.
    /// </summary>
    /// <param name="bboxes">a set of bounding boxes to apply NMS.</param>
    /// <param name="scores">a set of corresponding confidences.</param>
    /// <param name="scoreThreshold">a threshold used to filter boxes by score.</param>
    /// <param name="nmsThreshold">a threshold used in non maximum suppression.</param>
    /// <param name="indices">the kept indices of bboxes after NMS.</param>
    /// <param name="eta">a coefficient in adaptive threshold formula</param>
    /// <param name="topK">if `&gt;0`, keep at most @p top_k picked indices.</param>
    // ReSharper disable once IdentifierTypo
    public static void NMSBoxes(IEnumerable<RotatedRect> bboxes, IEnumerable<float> scores,
        float scoreThreshold, float nmsThreshold,
        out int[] indices,
        float eta = 1.0f, int topK = 0)
    {
        if (bboxes is null)
            throw new ArgumentNullException(nameof(bboxes));
        if (scores is null)
            throw new ArgumentNullException(nameof(scores));

        // ReSharper disable once IdentifierTypo
        using var bboxesVec = new StdVector<RotatedRect>(bboxes);
        using var scoresVec = new StdVector<float>(scores);
        using var indicesVec = new StdVector<int>();
        NativeMethods.HandleException(
            NativeMethods.dnn_NMSBoxes_RotatedRect(
                bboxesVec.CvPtr, scoresVec.CvPtr, scoreThreshold, nmsThreshold,
                indicesVec.CvPtr, eta, topK));
        indices = indicesVec.ToArray();
    }

    /// <summary>
    /// Performs batched non maximum suppression on given boxes and corresponding scores across different classes.
    /// </summary>
    /// <param name="bboxes">a set of bounding boxes to apply NMS.</param>
    /// <param name="scores">a set of corresponding confidences.</param>
    /// <param name="classIds">a set of corresponding class ids. Ids are integer and usually start from 0.</param>
    /// <param name="scoreThreshold">a threshold used to filter boxes by score.</param>
    /// <param name="nmsThreshold">a threshold used in non maximum suppression.</param>
    /// <param name="indices">the kept indices of bboxes after NMS.</param>
    /// <param name="eta">a coefficient in adaptive threshold formula</param>
    /// <param name="topK">if `&gt;0`, keep at most @p top_k picked indices.</param>
    // ReSharper disable once IdentifierTypo
    public static void NMSBoxesBatched(IEnumerable<Rect> bboxes, IEnumerable<float> scores, IEnumerable<int> classIds,
        float scoreThreshold, float nmsThreshold,
        out int[] indices,
        float eta = 1.0f, int topK = 0)
    {
        if (bboxes is null)
            throw new ArgumentNullException(nameof(bboxes));
        if (scores is null)
            throw new ArgumentNullException(nameof(scores));
        if (classIds is null)
            throw new ArgumentNullException(nameof(classIds));

        // ReSharper disable once IdentifierTypo
        using var bboxesVec = new StdVector<Rect>(bboxes);
        using var scoresVec = new StdVector<float>(scores);
        using var classIdsVec = new StdVector<int>(classIds);
        using var indicesVec = new StdVector<int>();
        NativeMethods.HandleException(
            NativeMethods.dnn_NMSBoxesBatched_Rect(
                bboxesVec.CvPtr, scoresVec.CvPtr, classIdsVec.CvPtr, scoreThreshold, nmsThreshold,
                indicesVec.CvPtr, eta, topK));
        indices = indicesVec.ToArray();
    }

    /// <summary>
    /// Performs batched non maximum suppression on given boxes and corresponding scores across different classes.
    /// </summary>
    /// <param name="bboxes">a set of bounding boxes to apply NMS.</param>
    /// <param name="scores">a set of corresponding confidences.</param>
    /// <param name="classIds">a set of corresponding class ids. Ids are integer and usually start from 0.</param>
    /// <param name="scoreThreshold">a threshold used to filter boxes by score.</param>
    /// <param name="nmsThreshold">a threshold used in non maximum suppression.</param>
    /// <param name="indices">the kept indices of bboxes after NMS.</param>
    /// <param name="eta">a coefficient in adaptive threshold formula</param>
    /// <param name="topK">if `&gt;0`, keep at most @p top_k picked indices.</param>
    // ReSharper disable once IdentifierTypo
    public static void NMSBoxesBatched(IEnumerable<Rect2d> bboxes, IEnumerable<float> scores, IEnumerable<int> classIds,
        float scoreThreshold, float nmsThreshold,
        out int[] indices,
        float eta = 1.0f, int topK = 0)
    {
        if (bboxes is null)
            throw new ArgumentNullException(nameof(bboxes));
        if (scores is null)
            throw new ArgumentNullException(nameof(scores));
        if (classIds is null)
            throw new ArgumentNullException(nameof(classIds));

        // ReSharper disable once IdentifierTypo
        using var bboxesVec = new StdVector<Rect2d>(bboxes);
        using var scoresVec = new StdVector<float>(scores);
        using var classIdsVec = new StdVector<int>(classIds);
        using var indicesVec = new StdVector<int>();
        NativeMethods.HandleException(
            NativeMethods.dnn_NMSBoxesBatched_Rect2d(
                bboxesVec.CvPtr, scoresVec.CvPtr, classIdsVec.CvPtr, scoreThreshold, nmsThreshold,
                indicesVec.CvPtr, eta, topK));
        indices = indicesVec.ToArray();
    }

    /// <summary>
    /// Performs soft non maximum suppression given boxes and corresponding scores.
    /// Reference: https://arxiv.org/abs/1704.04503
    /// </summary>
    /// <param name="bboxes">a set of bounding boxes to apply Soft NMS.</param>
    /// <param name="scores">a set of corresponding confidences.</param>
    /// <param name="updatedScores">a set of corresponding updated confidences.</param>
    /// <param name="scoreThreshold">a threshold used to filter boxes by score.</param>
    /// <param name="nmsThreshold">a threshold used in non maximum suppression.</param>
    /// <param name="indices">the kept indices of bboxes after NMS.</param>
    /// <param name="topK">keep at most @p top_k picked indices.</param>
    /// <param name="sigma">parameter of Gaussian weighting.</param>
    /// <param name="method">Gaussian or linear.</param>
    // ReSharper disable once IdentifierTypo
    public static void SoftNMSBoxes(IEnumerable<Rect> bboxes, IEnumerable<float> scores,
        out float[] updatedScores,
        float scoreThreshold, float nmsThreshold,
        out int[] indices,
        int topK = 0, float sigma = 0.5f, SoftNMSMethod method = SoftNMSMethod.SOFTNMS_GAUSSIAN)
    {
        if (bboxes is null)
            throw new ArgumentNullException(nameof(bboxes));
        if (scores is null)
            throw new ArgumentNullException(nameof(scores));

        // ReSharper disable once IdentifierTypo
        using var bboxesVec = new StdVector<Rect>(bboxes);
        using var scoresVec = new StdVector<float>(scores);
        using var updatedScoresVec = new StdVector<float>();
        using var indicesVec = new StdVector<int>();
        NativeMethods.HandleException(
            NativeMethods.dnn_softNMSBoxes_Rect(
                bboxesVec.CvPtr, scoresVec.CvPtr, updatedScoresVec.CvPtr, scoreThreshold, nmsThreshold,
                indicesVec.CvPtr, new UIntPtr((uint)topK), sigma, (int)method));
        indices = indicesVec.ToArray();
        updatedScores = updatedScoresVec.ToArray();
    }

    /// <summary>
    /// Release a Myriad device is binded by OpenCV.
    ///
    /// Single Myriad device cannot be shared across multiple processes which uses Inference Engine's Myriad plugin.
    /// </summary>
    public static void ResetMyriadDevice()
    {
        NativeMethods.HandleException(
            NativeMethods.dnn_resetMyriadDevice());
    }

    /// <summary>
    /// Returns the list of available computation targets for the given backend.
    /// </summary>
    /// <param name="backend">backend identifier.</param>
    /// <returns>available targets.</returns>
    public static Target[] GetAvailableTargets(Backend backend)
    {
        using var targetsVec = new StdVector<int>();
        NativeMethods.HandleException(
            NativeMethods.dnn_getAvailableTargets((int)backend, targetsVec.CvPtr));
        return targetsVec.ToArray().Select(x => (Target)x).ToArray();
    }

    /// <summary>
    /// Returns the list of available (backend, target) pairs supported by this build.
    /// </summary>
    /// <returns>available backend/target pairs.</returns>
    public static (Backend Backend, Target Target)[] GetAvailableBackends()
    {
        using var backendsVec = new StdVector<int>();
        using var targetsVec = new StdVector<int>();
        NativeMethods.HandleException(
            NativeMethods.dnn_getAvailableBackends(backendsVec.CvPtr, targetsVec.CvPtr));

        var backends = backendsVec.ToArray();
        var targets = targetsVec.ToArray();
        var result = new (Backend, Target)[backends.Length];
        for (var i = 0; i < backends.Length; i++)
            result[i] = ((Backend)backends[i], (Target)targets[i]);
        return result;
    }

    /// <summary>
    /// Enables detailed logging of the DNN model loading with CV DNN API.
    /// Diagnostic mode provides detailed logging of the model loading stage to explore
    /// potential problems (ex.: not implemented layer type).
    /// </summary>
    /// <param name="isDiagnosticsMode">indicates whether diagnostic mode should be set.</param>
    public static void EnableModelDiagnostics(bool isDiagnosticsMode)
    {
        NativeMethods.HandleException(
            NativeMethods.dnn_enableModelDiagnostics(isDiagnosticsMode ? 1 : 0));
    }

    private static byte[] StreamToArray(this Stream stream)
    {
        if (!stream.CanRead) 
            throw new ArgumentException("Unreadable stream", nameof(stream));
        using var memoryStream = new MemoryStream();
        stream.CopyTo(memoryStream);
        byte[] byteBlob = memoryStream.ToArray();
        return byteBlob;
    }
}
