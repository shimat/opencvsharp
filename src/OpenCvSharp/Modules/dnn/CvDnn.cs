using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

// ReSharper disable UnusedMember.Global
// ReSharper disable InconsistentNaming
// ReSharper disable CommentTypo

namespace OpenCvSharp.Dnn
{
    /// <summary>
    /// cv::dnn functions
    /// </summary>
    public static class CvDnn
    {

        private static byte[] StreamToArray(Stream stream)
        {
            if (stream == null || !stream.CanRead || stream.Length == 0)
                return null;
            using var memoryStream = new MemoryStream();
            stream.CopyTo(memoryStream);
            byte[] byteBlob = memoryStream.ToArray();
            return byteBlob;
        }

        /// <summary>
        /// Reads a network model stored in Darknet (https://pjreddie.com/darknet/) model files.
        /// </summary>
        /// <param name="cfgFile">path to the .cfg file with text description of the network architecture.</param>
        /// <param name="darknetModel">path to the .weights file with learned network.</param>
        /// <returns>Network object that ready to do forward, throw an exception in failure cases.</returns>
        /// <remarks>This is shortcut consisting from DarknetImporter and Net::populateNet calls.</remarks>
        public static Net ReadNetFromDarknet(string cfgFile, string? darknetModel = null)
        {
            return Net.ReadNetFromDarknet(cfgFile, darknetModel);
        }

        /// <summary>
        /// Reads a network model stored in Darknet (https://pjreddie.com/darknet/) model files from memory.
        /// </summary>
        /// <param name="cfgFileData"></param>
        /// <param name="darknetModelData">(optional)</param>
        /// <returns></returns>
        /// <remarks>This is shortcut consisting from DarknetImporter and Net::populateNet calls.</remarks>
        public static Net ReadNetFromDarknet(byte[] cfgFileData, byte[] darknetModelData = null)
        {
            if (cfgFileData == null)
                throw new ArgumentNullException(nameof(cfgFileData));
            if (cfgFileData.Length > int.MaxValue)
                throw new ArgumentException("Not supported array (too long)");

            return Net.ReadNetFromDarknet(cfgFileData, darknetModelData);
        }

        /// <summary>
        /// Reads a network model stored in Darknet (https://pjreddie.com/darknet/) model files from stream.
        /// </summary>
        /// <param name="cfgFileStream"></param>
        /// <param name="darknetModelStream">(optional)</param>
        /// <returns></returns>
        /// <remarks>This is shortcut consisting from DarknetImporter and Net::populateNet calls.</remarks>
        public static Net ReadNetFromDarknet(Stream cfgFileStream, Stream darknetModelStream = null)
        {
            return ReadNetFromDarknet(StreamToArray(cfgFileStream), 
                StreamToArray(darknetModelStream));
        }

        /// <summary>
        /// Reads a network model stored in Caffe model files.
        /// </summary>
        /// <param name="prototxt"></param>
        /// <param name="caffeModel"></param>
        /// <returns></returns>
        /// <remarks>This is shortcut consisting from createCaffeImporter and Net::populateNet calls.</remarks>
        // ReSharper disable once IdentifierTypo
        public static Net ReadNetFromCaffe(string prototxt, string? caffeModel = null)
        {
            return Net.ReadNetFromCaffe(prototxt, caffeModel);
        }

        /// <summary>
        /// Reads a network model stored in Caffe model files from memory.
        /// </summary>
        /// <param name="prototxtData"></param>
        /// <param name="caffeModelData"></param>
        /// <returns></returns>
        /// <remarks>This is shortcut consisting from createCaffeImporter and Net::populateNet calls.</remarks>
        // ReSharper disable once IdentifierTypo
        public static Net ReadNetFromCaffe(byte[] prototxtData, byte[] caffeModelData = null)
        {
            if (prototxtData == null)
                throw new ArgumentNullException(nameof(prototxtData));
            if (prototxtData.Length > int.MaxValue)
                throw new ArgumentException("Not supported array (too long)");

            return Net.ReadNetFromCaffe(prototxtData, caffeModelData);
        }

        /// <summary>
        /// Reads a network model stored in Caffe model files.
        /// </summary>
        /// <param name="prototxtStream"></param>
        /// <param name="caffeModelStream"></param>
        /// <returns></returns>
        /// <remarks>This is shortcut consisting from createCaffeImporter and Net::populateNet calls.</remarks>
        // ReSharper disable once IdentifierTypo
        public static Net ReadNetFromCaffe(Stream prototxtStream, Stream caffeModelStream = null)
        {
            return ReadNetFromCaffe(StreamToArray(prototxtStream), 
                StreamToArray(caffeModelStream));
        }

        /// <summary>
        /// Reads a network model stored in Tensorflow model file.
        /// </summary>
        /// <param name="model"></param>
        /// <param name="config"></param>
        /// <returns></returns>
        /// <remarks>This is shortcut consisting from createTensorflowImporter and Net::populateNet calls.</remarks>
        public static Net ReadNetFromTensorflow(string model, string? config = null)
        {
            return Net.ReadNetFromTensorflow(model, config);
        }

        /// <summary>
        /// Reads a network model stored in Tensorflow model file from memory.
        /// </summary>
        /// <param name="modelData">An array containing the data of a Tensorflow model</param>
        /// <param name="configData">An array contaiing the data of the pbtxt file (optional)</param>
        /// <returns></returns>
        /// <remarks>This is shortcut consisting from createTensorflowImporter and Net::populateNet calls.</remarks>
        public static Net ReadNetFromTensorflow(byte[] modelData, byte[] configData = null)
        {
            if (modelData == null)
                throw new ArgumentNullException(nameof(modelData));
            if (modelData.Length > int.MaxValue)
                throw new ArgumentException("Not supported array (too long)");

            return Net.ReadNetFromTensorflow(modelData, configData);
        }

        /// <summary>
        /// Reads a network model stored in Tensorflow model file from stream.
        /// </summary>
        /// <param name="modelStream">An array containing the data of a Tensorflow model</param>
        /// <param name="configStream">An array contaiing the data of the pbtxt file (optional)</param>
        /// <returns></returns>
        /// <remarks>This is shortcut consisting from createTensorflowImporter and Net::populateNet calls.</remarks>
        public static Net ReadNetFromTensorflow(Stream modelStream, Stream configStream = null)
        {
            return ReadNetFromTensorflow(StreamToArray(modelStream), 
                StreamToArray(configStream));
        }

        /// <summary>
        /// Reads a network model stored in Torch model file.
        /// </summary>
        /// <param name="model"></param>
        /// <param name="isBinary"></param>
        /// <returns></returns>
        /// <remarks>This is shortcut consisting from createTorchImporter and Net::populateNet calls.</remarks>
        public static Net ReadNetFromTorch(string model, bool isBinary = true)
        {
            return Net.ReadNetFromTorch(model, isBinary);
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
            return Net.ReadNet(model, config, framework);
        }

        /// <summary>
        /// Reads a network model ONNX https://onnx.ai/ from memory
        /// </summary>
        /// <param name="onnxFile"></param>
        /// <returns></returns>
        public static Net ReadNetFromOnnx(string onnxFile)
        {
            return Net.ReadNetFromONNX(onnxFile);
        }

        /// <summary>
        /// Reads a network model ONNX https://onnx.ai/ from memory
        /// </summary>
        /// <param name="onnxFileData"></param>
        /// <returns></returns>
        public static Net ReadNetFromOnnx(byte[] onnxFileData)
        {
            if (onnxFileData == null)
                throw new ArgumentNullException(nameof(onnxFileData));
            if (onnxFileData.Length > int.MaxValue)
                throw new ArgumentException("Not supported array (too long)");

            return Net.ReadNetFromONNX(onnxFileData);
        }

        /// <summary>
        /// Reads a network model ONNX https://onnx.ai/  from stream.
        /// </summary>
        /// <param name="onnxFileStream"></param>
        /// <returns></returns>
        public static Net ReadNetFromOnnx(Stream onnxFileStream)
        {
            return ReadNetFromOnnx(StreamToArray(onnxFileStream));
        }

        /// <summary>
        /// Loads blob which was serialized as torch.Tensor object of Torch7 framework. 
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="isBinary"></param>
        /// <returns></returns>
        /// <remarks>
        /// This function has the same limitations as createTorchImporter().
        /// </remarks>
        public static Mat ReadTorchBlob(string fileName, bool isBinary = true)
        {
            if (fileName == null)
                throw new ArgumentNullException(nameof(fileName));

            NativeMethods.HandleException(
                NativeMethods.dnn_readTorchBlob(fileName, isBinary ? 1 : 0, out var ret));
            return new Mat(ret);
        }

        /// <summary>
        /// Creates blob from .pb file.
        /// </summary>
        /// <param name="path">path to the .pb file with input tensor.</param>
        /// <returns></returns>
        public static Mat? ReadTensorFromONNX(string path)
        {
            if (path == null)
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
            if (image == null)
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
            if (images == null)
                throw new ArgumentNullException(nameof(images));

            var imagesPointers = images.Select(x => x.CvPtr).ToArray();

            NativeMethods.HandleException(
                NativeMethods.dnn_blobFromImages(
                    imagesPointers, imagesPointers.Length, scaleFactor, size, mean, swapRB ? 1 : 0, crop ? 1 : 0,
                    out var ret));
            return new Mat(ret);
        }
        
        /// <summary>
        /// Convert all weights of Caffe network to half precision floating point.
        /// </summary>
        /// <param name="src">Path to origin model from Caffe framework contains single 
        /// precision floating point weights(usually has `.caffemodel` extension).</param>
        /// <param name="dst">Path to destination model with updated weights.</param>
        /// <remarks>
        /// Shrinked model has no origin float32 weights so it can't be used 
        /// in origin Caffe framework anymore.However the structure of data 
        /// is taken from NVidia's Caffe fork: https://github.com/NVIDIA/caffe.
        /// So the resulting model may be used there.
        /// </remarks>
        public static void ShrinkCaffeModel(string src, string dst)
        {
            if (src == null)
                throw new ArgumentNullException(nameof(src));
            if (dst == null)
                throw new ArgumentNullException(nameof(dst));

            NativeMethods.HandleException(
                NativeMethods.dnn_shrinkCaffeModel(src, dst));
        }

        /// <summary>
        /// Create a text representation for a binary network stored in protocol buffer format.
        /// </summary>
        /// <param name="model">A path to binary network.</param>
        /// <param name="output">A path to output text file to be created.</param>
        public static void WriteTextGraph(string model, string output)
        {
            if (model == null)
                throw new ArgumentNullException(nameof(model));
            if (output == null)
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
            if (bboxes == null)
                throw new ArgumentNullException(nameof(bboxes));
            if (scores == null)
                throw new ArgumentNullException(nameof(scores));

            // ReSharper disable once IdentifierTypo
            using var bboxesVec = new VectorOfRect(bboxes);
            using var scoresVec = new VectorOfFloat(scores);
            using var indicesVec = new VectorOfInt32();
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
            if (bboxes == null)
                throw new ArgumentNullException(nameof(bboxes));
            if (scores == null)
                throw new ArgumentNullException(nameof(scores));

            // ReSharper disable once IdentifierTypo
            using var bboxesVec = new VectorOfRect2d(bboxes);
            using var scoresVec = new VectorOfFloat(scores);
            using var indicesVec = new VectorOfInt32();
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
            if (bboxes == null)
                throw new ArgumentNullException(nameof(bboxes));
            if (scores == null)
                throw new ArgumentNullException(nameof(scores));

            // ReSharper disable once IdentifierTypo
            using var bboxesVec = new VectorOfRotatedRect(bboxes);
            using var scoresVec = new VectorOfFloat(scores);
            using var indicesVec = new VectorOfInt32();
            NativeMethods.HandleException(
                NativeMethods.dnn_NMSBoxes_RotatedRect(
                    bboxesVec.CvPtr, scoresVec.CvPtr, scoreThreshold, nmsThreshold,
                    indicesVec.CvPtr, eta, topK));
            indices = indicesVec.ToArray();
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
    }
}
