using System;
using System.Collections.Generic;
using OpenCvSharp.Util;

namespace OpenCvSharp
{
    // ReSharper disable InconsistentNaming

    /// <summary>
    /// TextDetectorCNN class provides the functionality of text bounding box detection.
    /// </summary>
    /// <remarks>
    /// This class is representing to find bounding boxes of text words given an input image.
    /// This class uses OpenCV dnn module to load pre-trained model described in @cite LiaoSBWL17.
    /// The original repository with the modified SSD Caffe version: https://github.com/MhLiao/TextBoxes.
    /// Model can be downloaded from[DropBox](https://www.dropbox.com/s/g8pjzv2de9gty8g/TextBoxes_icdar13.caffemodel?dl=0).
    /// Modified.prototxt file with the model description can be found in `opencv_contrib/modules/text/samples/textbox.prototxt`.
    /// </remarks>
    public class TextDetectorCNN : TextDetector
    {
        /// <summary>
        /// cv::Ptr&lt;T&gt;
        /// </summary>
        private Ptr objectPtr;

        /// <summary>
        /// Creates an instance of the TextDetectorCNN class using the provided parameters.
        /// </summary>
        /// <param name="modelArchFilename">the relative or absolute path to the prototxt file describing the classifiers architecture.</param>
        /// <param name="modelWeightsFilename">the relative or absolute path to the file containing the pretrained weights of the model in caffe-binary form.</param>
        /// <param name="detectionSizes">a list of sizes for multiscale detection. The values`[(300,300),(700,500),(700,300),(700,700),(1600,1600)]` are recommended in @cite LiaoSBWL17 to achieve the best quality.</param>
        /// <returns></returns>
        public static TextDetectorCNN Create(
            string modelArchFilename, string modelWeightsFilename, IEnumerable<Size> detectionSizes)
        {
            if (string.IsNullOrEmpty(modelArchFilename))
                throw new ArgumentException("empty string", nameof(detectionSizes));
            if (string.IsNullOrEmpty(modelWeightsFilename))
                throw new ArgumentException("empty string", nameof(modelWeightsFilename));
            if (detectionSizes == null)
                throw new ArgumentNullException(nameof(detectionSizes));

            var detectionSizesArray = EnumerableEx.ToArray(detectionSizes);
            var ptr = NativeMethods.text_TextDetectorCNN_create1(
                modelArchFilename, modelWeightsFilename, detectionSizesArray, detectionSizesArray.Length);
            GC.KeepAlive(detectionSizes);
            return new TextDetectorCNN(ptr);
        }

        /// <summary>
        /// Creates an instance of the TextDetectorCNN class using the provided parameters.
        /// </summary>
        /// <param name="modelArchFilename">the relative or absolute path to the prototxt file describing the classifiers architecture.</param>
        /// <param name="modelWeightsFilename">the relative or absolute path to the file containing the pretrained weights of the model in caffe-binary form.</param>
        /// <returns></returns>
        public static TextDetectorCNN Create(
            string modelArchFilename, string modelWeightsFilename)
        {
            var ptr = NativeMethods.text_TextDetectorCNN_create2(modelArchFilename, modelWeightsFilename);
            return new TextDetectorCNN(ptr);
        }

        internal TextDetectorCNN(IntPtr ptr)
        {
            this.objectPtr = new Ptr(ptr);
            this.ptr = objectPtr.Get(); 
        }

        /// <summary>
        /// Releases managed resources
        /// </summary>
        protected override void DisposeManaged()
        {
            objectPtr?.Dispose();
            objectPtr = null;
            base.DisposeManaged();
        }

        /// <summary>
        /// Method that provides a quick and simple interface to detect text inside an image
        /// </summary>
        /// <param name="inputImage">an image to process</param>
        /// <param name="bbox"> a vector of Rect that will store the detected word bounding box</param>
        /// <param name="confidence">a vector of float that will be updated with the confidence the classifier has for the selected bounding box</param>
        public override void Detect(InputArray inputImage, out Rect[] bbox, out float[] confidence)
        {
            if (inputImage == null)
                throw new ArgumentNullException(nameof(inputImage));
            inputImage.ThrowIfDisposed();

            using (var bboxVec = new VectorOfRect())
            using (var confidenceVec = new VectorOfFloat())
            {
                NativeMethods.text_TextDetectorCNN_detect(ptr, inputImage.CvPtr, bboxVec.CvPtr, confidenceVec.CvPtr);
                bbox = bboxVec.ToArray();
                confidence = confidenceVec.ToArray();
            }

            GC.KeepAlive(this);
            GC.KeepAlive(inputImage);
        }

        internal class Ptr : OpenCvSharp.Ptr
        {
            public Ptr(IntPtr ptr) : base(ptr)
            {
            }

            public override IntPtr Get()
            {
                var res = NativeMethods.text_Ptr_TextDetectorCNN_get(ptr);
                GC.KeepAlive(this);
                return res;
            }

            protected override void DisposeUnmanaged()
            {
                NativeMethods.text_Ptr_TextDetectorCNN_delete(ptr);
                base.DisposeUnmanaged();
            }
        }
    }
}