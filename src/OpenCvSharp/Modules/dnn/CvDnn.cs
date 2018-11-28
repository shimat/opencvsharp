using System;
using System.Collections.Generic;
using OpenCvSharp.Util;

namespace OpenCvSharp.Dnn
{
    /// <summary>
    /// cv::dnn functions
    /// </summary>
    public static class CvDnn
    {
        /// <summary>
        /// Reads a network model stored in Darknet (https://pjreddie.com/darknet/) model files.
        /// </summary>
        /// <param name="cfgFile">path to the .cfg file with text description of the network architecture.</param>
        /// <param name="darknetModel">path to the .weights file with learned network.</param>
        /// <returns>Network object that ready to do forward, throw an exception in failure cases.</returns>
        /// <remarks>This is shortcut consisting from DarknetImporter and Net::populateNet calls.</remarks>
        public static Net ReadNetFromDarknet(string cfgFile, string darknetModel = null)
        {
            return Net.ReadNetFromDarknet(cfgFile, darknetModel);
        }

        /// <summary>
        /// Reads a network model stored in Caffe model files.
        /// </summary>
        /// <param name="prototxt"></param>
        /// <param name="caffeModel"></param>
        /// <returns></returns>
        /// <remarks>This is shortcut consisting from createCaffeImporter and Net::populateNet calls.</remarks>
        public static Net ReadNetFromCaffe(string prototxt, string caffeModel = null)
        {
            return Net.ReadNetFromCaffe(prototxt, caffeModel);
        }

        /// <summary>
        /// Reads a network model stored in Tensorflow model file.
        /// </summary>
        /// <param name="model"></param>
        /// <param name="config"></param>
        /// <returns></returns>
        /// <remarks>This is shortcut consisting from createTensorflowImporter and Net::populateNet calls.</remarks>
        public static Net ReadNetFromTensorflow(string model, string config = null)
        {
            return Net.ReadNetFromTensorflow(model, config);
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

            IntPtr ptr = NativeMethods.dnn_readTorchBlob(fileName, isBinary ? 1 : 0);
            return new Mat(ptr);
        }

        /// <summary>
        /// Creates blob from .pb file.
        /// </summary>
        /// <param name="path">path to the .pb file with input tensor.</param>
        /// <returns></returns>
        public static Mat ReadTensorFromONNX(string path)
        {
            if (path == null)
                throw new ArgumentNullException(nameof(path));

            IntPtr p = NativeMethods.dnn_readTensorFromONNX(path);
            return (p == IntPtr.Zero) ? null : new Mat(p);
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
            Mat image, double scaleFactor = 1.0, Size size = default(Size),
            Scalar mean = default(Scalar), bool swapRB = true, bool crop = true)
        {
            if (image == null)
                throw new ArgumentNullException(nameof(image));

            IntPtr ptr = NativeMethods.dnn_blobFromImage(image.CvPtr, scaleFactor, size, mean, swapRB ? 1 : 0, crop ? 1 : 0);
            return new Mat(ptr);
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
            Size size = default(Size), Scalar mean = default(Scalar), bool swapRB = true, bool crop = true)
        {
            if (images == null)
                throw new ArgumentNullException(nameof(images));

            IntPtr[] imagesPtrs = EnumerableEx.SelectPtrs(images);

            IntPtr ptr = NativeMethods.dnn_blobFromImages(imagesPtrs, imagesPtrs.Length, scaleFactor, size, mean, swapRB ? 1 : 0, crop ? 1 : 0);
            return new Mat(ptr);
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

            NativeMethods.dnn_shrinkCaffeModel(src, dst);
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

            NativeMethods.dnn_writeTextGraph(model, output);
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
        public static void NMSBoxes(IEnumerable<Rect> bboxes, IEnumerable<float> scores,
                                   float scoreThreshold, float nmsThreshold,
                                   out int[] indices,
                                   float eta = 1.0f, int topK = 0)
        {
            if (bboxes == null)
                throw new ArgumentNullException(nameof(bboxes));
            if (scores == null)
                throw new ArgumentNullException(nameof(scores));

            using (var bboxesVec = new VectorOfRect(bboxes))
            using (var scoresVec = new VectorOfFloat(scores))
            using (var indicesVec = new VectorOfInt32())
            {
                NativeMethods.dnn_NMSBoxes_Rect(
                    bboxesVec.CvPtr, scoresVec.CvPtr, scoreThreshold, nmsThreshold,
                    indicesVec.CvPtr, eta, topK);
                indices = indicesVec.ToArray();
            }
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
        public static void NMSBoxes(IEnumerable<Rect2d> bboxes, IEnumerable<float> scores,
                               float scoreThreshold, float nmsThreshold,
                               out int[] indices,
                               float eta = 1.0f, int topK = 0)
        {
            if (bboxes == null)
                throw new ArgumentNullException(nameof(bboxes));
            if (scores == null)
                throw new ArgumentNullException(nameof(scores));

            using (var bboxesVec = new VectorOfRect2d(bboxes))
            using (var scoresVec = new VectorOfFloat(scores))
            using (var indicesVec = new VectorOfInt32())
            {
                NativeMethods.dnn_NMSBoxes_Rect2d(
                    bboxesVec.CvPtr, scoresVec.CvPtr, scoreThreshold, nmsThreshold,
                    indicesVec.CvPtr, eta, topK);
                indices = indicesVec.ToArray();
            }
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
        public static void NMSBoxes(IEnumerable<RotatedRect> bboxes, IEnumerable<float> scores,
                             float scoreThreshold, float nmsThreshold,
                             out int[] indices,
                             float eta = 1.0f, int topK = 0)
        {
            if (bboxes == null)
                throw new ArgumentNullException(nameof(bboxes));
            if (scores == null)
                throw new ArgumentNullException(nameof(scores));

            using (var bboxesVec = new VectorOfRotatedRect(bboxes))
            using (var scoresVec = new VectorOfFloat(scores))
            using (var indicesVec = new VectorOfInt32())
            {
                NativeMethods.dnn_NMSBoxes_RotatedRect(
                    bboxesVec.CvPtr, scoresVec.CvPtr, scoreThreshold, nmsThreshold,
                    indicesVec.CvPtr, eta, topK);
                indices = indicesVec.ToArray();
            }
        }

        /// <summary>
        /// Release a Myriad device is binded by OpenCV.
        /// 
        /// Single Myriad device cannot be shared across multiple processes which uses Inference Engine's Myriad plugin.
        /// </summary>
        public static void ResetMyriadDevice()
        {
            NativeMethods.dnn_resetMyriadDevice();
        }
    }
}
