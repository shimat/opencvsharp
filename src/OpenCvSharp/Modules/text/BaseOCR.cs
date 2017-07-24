using System;

namespace OpenCvSharp.Text
{
    /// <summary>
    /// base class BaseOCR declares a common API that would be used in a typical text recognition scenario
    /// </summary>
    public abstract class BaseOcr : DisposableCvObject
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="image"></param>
        /// <param name="outputText"></param>
        /// <param name="componentRects"></param>
        /// <param name="componentTexts"></param>
        /// <param name="componentConfidences"></param>
        /// <param name="componentLevel"></param>
        public abstract void Run(
            Mat image,
            out string outputText,
            out Rect[] componentRects,
            out string[] componentTexts,
            out float[] componentConfidences,
            ComponentLevels componentLevel = ComponentLevels.Word);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="image"></param>
        /// <param name="mask"></param>
        /// <param name="outputText"></param>
        /// <param name="componentRects"></param>
        /// <param name="componentTexts"></param>
        /// <param name="componentConfidences"></param>
        /// <param name="componentLevel"></param>
        public abstract void Run(
            Mat image,
            Mat mask,
            out string outputText,
            out Rect[] componentRects,
            out string[] componentTexts,
            out float[] componentConfidences,
            ComponentLevels componentLevel = ComponentLevels.Word);
    }
}