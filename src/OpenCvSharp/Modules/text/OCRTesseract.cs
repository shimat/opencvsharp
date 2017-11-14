using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace OpenCvSharp.Text
{
    // ReSharper disable InconsistentNaming

    /// <summary>
    /// Recognize text using the tesseract-ocr API.
    /// 
    /// Takes image on input and returns recognized text in the output_text parameter.
    /// Optionallyprovides also the Rects for individual text elements found(e.g.words), 
    /// and the list of those text elements with their confidence values.
    /// </summary>
    public sealed class OCRTesseract : BaseOcr
    {
        private Ptr ptrObj;

        #region Init & Disposal

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="p"></param>
        private OCRTesseract(IntPtr p)
        {
            ptrObj = new Ptr(p);
            ptr = ptrObj.Get();
        }

        /// <summary>
        /// Creates an instance of the OCRTesseract class. Initializes Tesseract.
        /// </summary>
        /// <param name="datapath">datapath the name of the parent directory of tessdata ended with "/", or null to use the system's default directory.</param>
        /// <param name="language">an ISO 639-3 code or NULL will default to "eng".</param>
        /// <param name="charWhitelist">specifies the list of characters used for recognition. 
        /// null defaults to "0123456789abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ".</param>
        /// <param name="oem">tesseract-ocr offers different OCR Engine Modes (OEM), 
        /// by deffault tesseract::OEM_DEFAULT is used.See the tesseract-ocr API documentation for other possible values.</param>
        /// <param name="psmode">tesseract-ocr offers different Page Segmentation Modes (PSM) tesseract::PSM_AUTO (fully automatic layout analysis) is used.
        /// See the tesseract-ocr API documentation for other possible values.</param>
        public static OCRTesseract Create(
            string datapath = null, 
            string language = null,
            string charWhitelist = null, 
            int oem = 3, 
            int psmode = 3)
        {
            IntPtr p = NativeMethods.text_OCRTesseract_create(datapath, language, charWhitelist, oem, psmode);
            return new OCRTesseract(p);
        }

        /// <summary>
        /// Releases managed resources
        /// </summary>
        protected override void DisposeManaged()
        {
            ptrObj?.Dispose();
            ptrObj = null;
            base.DisposeManaged();
        }

        #endregion

        #region Methods

        /// <summary>
        /// Recognize text using the tesseract-ocr API.
        /// Takes image on input and returns recognized text in the output_text parameter.
        /// Optionally provides also the Rects for individual text elements found(e.g.words), 
        /// and the list of those text elements with their confidence values.
        /// </summary>
        /// <param name="image">Input image CV_8UC1 or CV_8UC3</param>
        /// <param name="outputText">Output text of the tesseract-ocr.</param>
        /// <param name="componentRects">If provided the method will output a list of Rects for the individual 
        /// text elements found(e.g.words or text lines).</param>
        /// <param name="componentTexts">If provided the method will output a list of text strings for the 
        /// recognition of individual text elements found(e.g.words or text lines).</param>
        /// <param name="componentConfidences">If provided the method will output a list of confidence values 
        /// for the recognition of individual text elements found(e.g.words or text lines).</param>
        /// <param name="componentLevel">OCR_LEVEL_WORD (by default), or OCR_LEVEL_TEXT_LINE.</param>
        public override void Run(
            Mat image,
            out string outputText,
            out Rect[] componentRects,
            out string[] componentTexts,
            out float[] componentConfidences,
            ComponentLevels componentLevel = ComponentLevels.Word)
        {
            if (image == null)
                throw new ArgumentNullException(nameof(image));
            image.ThrowIfDisposed();

            using (var outputTextString = new StdString())
            using (var componentRectsVector = new VectorOfRect())
            using (var componentTextsVector = new VectorOfString())
            using (var componentConfidencesVector = new VectorOfFloat())
            {
                NativeMethods.text_OCRTesseract_run1(
                    ptr, 
                    image.CvPtr,
                    outputTextString.CvPtr,
                    componentRectsVector.CvPtr, 
                    componentTextsVector.CvPtr, 
                    componentConfidencesVector.CvPtr, 
                    (int)componentLevel);

                outputText = outputTextString.ToString();
                componentRects = componentRectsVector.ToArray();
                componentTexts = componentTextsVector.ToArray();
                componentConfidences = componentConfidencesVector.ToArray();
            }

            GC.KeepAlive(image);
        }

        /// <summary>
        /// Recognize text using the tesseract-ocr API.
        /// Takes image on input and returns recognized text in the output_text parameter.
        /// Optionally provides also the Rects for individual text elements found(e.g.words), 
        /// and the list of those text elements with their confidence values.
        /// </summary>
        /// <param name="image">Input image CV_8UC1 or CV_8UC3</param>
        /// <param name="mask"></param>
        /// <param name="outputText">Output text of the tesseract-ocr.</param>
        /// <param name="componentRects">If provided the method will output a list of Rects for the individual 
        /// text elements found(e.g.words or text lines).</param>
        /// <param name="componentTexts">If provided the method will output a list of text strings for the 
        /// recognition of individual text elements found(e.g.words or text lines).</param>
        /// <param name="componentConfidences">If provided the method will output a list of confidence values 
        /// for the recognition of individual text elements found(e.g.words or text lines).</param>
        /// <param name="componentLevel">OCR_LEVEL_WORD (by default), or OCR_LEVEL_TEXT_LINE.</param>
        public override void Run(
            Mat image,
            Mat mask,
            out string outputText,
            out Rect[] componentRects,
            out string[] componentTexts,
            out float[] componentConfidences,
            ComponentLevels componentLevel = ComponentLevels.Word)
        {
            if (image == null)
                throw new ArgumentNullException(nameof(image));
            if (mask == null)
                throw new ArgumentNullException(nameof(mask));
            image.ThrowIfDisposed();
            mask.ThrowIfDisposed();

            using (var outputTextString = new StdString())
            using (var componentRectsVector = new VectorOfRect())
            using (var componentTextsVector = new VectorOfString())
            using (var componentConfidencesVector = new VectorOfFloat())
            {
                NativeMethods.text_OCRTesseract_run2(
                    ptr,
                    image.CvPtr,
                    mask.CvPtr,
                    outputTextString.CvPtr,
                    componentRectsVector.CvPtr,
                    componentTextsVector.CvPtr,
                    componentConfidencesVector.CvPtr,
                    (int)componentLevel);

                outputText = outputTextString.ToString();
                componentRects = componentRectsVector.ToArray();
                componentTexts = componentTextsVector.ToArray();
                componentConfidences = componentConfidencesVector.ToArray();
            }

            GC.KeepAlive(image);
        }

        #endregion

        internal class Ptr : OpenCvSharp.Ptr
        {
            public Ptr(IntPtr ptr) : base(ptr)
            {
            }

            public override IntPtr Get()
            {
                return NativeMethods.text_OCRTesseract_get(ptr);
            }

            protected override void DisposeUnmanaged()
            {
                NativeMethods.text_Ptr_OCRTesseract_delete(ptr);
                base.DisposeUnmanaged();
            }
        }
    }
}
