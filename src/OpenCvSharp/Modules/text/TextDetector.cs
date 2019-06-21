using System;

namespace OpenCvSharp
{
    /// <summary>
    /// An abstract class providing interface for text detection algorithms
    /// </summary>
    public abstract class TextDetector : DisposableCvObject
    {
        /// <summary>
        /// Method that provides a quick and simple interface to detect text inside an image
        /// </summary>
        /// <param name="inputImage">an image to process</param>
        /// <param name="bbox"> a vector of Rect that will store the detected word bounding box</param>
        /// <param name="confidence">a vector of float that will be updated with the confidence the classifier has for the selected bounding box</param>
        public virtual void Detect(InputArray inputImage, out Rect[] bbox, out float[] confidence)
        {
            if (inputImage == null)
                throw new ArgumentNullException(nameof(inputImage));
            inputImage.ThrowIfDisposed();

            using (var bboxVec = new VectorOfRect())
            using (var confidenceVec = new VectorOfFloat())
            {
                NativeMethods.text_TextDetector_detect(ptr, inputImage.CvPtr, bboxVec.CvPtr, confidenceVec.CvPtr);
                bbox = bboxVec.ToArray();
                confidence = confidenceVec.ToArray();
            }

            GC.KeepAlive(this);
            GC.KeepAlive(inputImage);
        }
    }
}
