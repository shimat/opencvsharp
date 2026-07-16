using OpenCvSharp.Internal;
using OpenCvSharp.Internal.Vectors;
using OpenCvSharp.Text;

// ReSharper disable UnusedMember.Global
// ReSharper disable InconsistentNaming
// ReSharper disable CommentTypo

namespace OpenCvSharp;

public static partial class Cv2
{
    /// <summary>
    /// cv::text functions
    /// </summary>
    public static partial class Text
    {
        /// <summary>
        /// Applies the Stroke Width Transform operator followed by filtering of connected components of similar Stroke Widths to
        /// return letter candidates. It also chain them by proximity and size, saving the result in chainBBs.
        /// </summary>
        /// <param name="input">input the input image with 3 channels.</param>
        /// <param name="darkOnLight">a boolean value signifying whether the text is darker or lighter than the background,
        /// it is observed to reverse the gradient obtained from Scharr operator, and significantly affect the result.</param>
        /// <param name="draw">an optional Mat of type CV_8UC3 which visualises the detected letters using bounding boxes.</param>
        /// <param name="chainBBs">an optional parameter which chains the letter candidates according to heuristics in the
        /// paper and returns all possible regions where text is likely to occur.</param>
        /// <returns>a vector of resulting bounding boxes where probability of finding text is high</returns>
        public static Rect[] DetectTextSWT(
            InputArray input, bool darkOnLight, OutputArray draw = default, OutputArray chainBBs = default)
        {
            using var result = new StdVector<Rect>();
            NativeMethods.HandleException(
                NativeMethods.text_detectTextSWT(
                    input.Proxy, 
                    result.CvPtr, 
                    darkOnLight ? 1 : 0,
                    draw.Proxy,
                    chainBBs.Proxy));
            
            GC.KeepAlive(input.Source);

            return result.ToArray();
        }

        /// <summary>
        /// Computes the different channels to be processed independently in the N&amp;M algorithm.
        /// </summary>
        /// <param name="src">Source image. Must be RGB CV_8UC3.</param>
        /// <param name="mode">Mode of operation.</param>
        /// <returns>The computed channels.</returns>
        public static Mat[] ComputeNMChannels(InputArray src, ERFilterNMMode mode = ERFilterNMMode.RGBLGrad)
        {
            using var channels = new VectorOfMat();
            NativeMethods.HandleException(
                NativeMethods.text_computeNMChannels(src.Proxy, channels.CvPtr, (int)mode));

            GC.KeepAlive(src.Source);
            return channels.ToArray();
        }

        /// <summary>
        /// Extracts text regions from an image, as contours.
        /// </summary>
        /// <param name="image">Source image where text blocks need to be extracted from. Should be CV_8UC3 (color).</param>
        /// <param name="erFilter1">Extremal Region Filter for the 1st stage classifier of the N&amp;M algorithm.</param>
        /// <param name="erFilter2">Extremal Region Filter for the 2nd stage classifier of the N&amp;M algorithm.</param>
        /// <returns>The detected text region contours.</returns>
        public static Point[][] DetectRegions(InputArray image, ERFilter erFilter1, ERFilter erFilter2)
        {
            ArgumentNullException.ThrowIfNull(erFilter1);
            ArgumentNullException.ThrowIfNull(erFilter2);
            erFilter1.ThrowIfDisposed();
            erFilter2.ThrowIfDisposed();

            using var regions = new VectorOfVectorPoint();
            NativeMethods.HandleException(
                NativeMethods.text_detectRegions_contours(image.Proxy, erFilter1.SmartPtr, erFilter2.SmartPtr, regions.CvPtr));

            GC.KeepAlive(image.Source);
            GC.KeepAlive(erFilter1);
            GC.KeepAlive(erFilter2);
            return regions.ToArray();
        }

        /// <summary>
        /// Extracts text regions from an image, grouped as rectangular text blocks.
        /// </summary>
        /// <param name="image">Source image where text blocks need to be extracted from. Should be CV_8UC3 (color).</param>
        /// <param name="erFilter1">Extremal Region Filter for the 1st stage classifier of the N&amp;M algorithm.</param>
        /// <param name="erFilter2">Extremal Region Filter for the 2nd stage classifier of the N&amp;M algorithm.</param>
        /// <param name="method">Grouping method.</param>
        /// <param name="filename">The XML or YAML file with the classifier model (e.g. trained_classifier_erGrouping.xml).
        /// Only used when the grouping method is ErGroupingModes.OrientationAny.</param>
        /// <param name="minProbability">The minimum probability for accepting a group. Only used when the grouping method
        /// is ErGroupingModes.OrientationAny.</param>
        /// <returns>Output list of rectangle blocks with text.</returns>
        public static Rect[] DetectRegions(
            InputArray image, ERFilter erFilter1, ERFilter erFilter2,
            ErGroupingModes method = ErGroupingModes.OrientationHoriz, string filename = "", float minProbability = 0.5f)
        {
            ArgumentNullException.ThrowIfNull(erFilter1);
            ArgumentNullException.ThrowIfNull(erFilter2);
            ArgumentNullException.ThrowIfNull(filename);
            erFilter1.ThrowIfDisposed();
            erFilter2.ThrowIfDisposed();

            using var groupsRects = new StdVector<Rect>();
            NativeMethods.HandleException(
                NativeMethods.text_detectRegions_rects(
                    image.Proxy, erFilter1.SmartPtr, erFilter2.SmartPtr, groupsRects.CvPtr, (int)method, filename, minProbability));

            GC.KeepAlive(image.Source);
            GC.KeepAlive(erFilter1);
            GC.KeepAlive(erFilter2);
            return groupsRects.ToArray();
        }

        /// <summary>
        /// Creates a tailored language model transitions table from a given list of words (lexicon).
        /// The result can be used as input for OCRHMMDecoder.Create and OCRBeamSearchDecoder.Create.
        /// </summary>
        /// <param name="vocabulary">The language vocabulary (chars when ASCII English text).</param>
        /// <param name="lexicon">The list of words that are expected to be found in a particular image.</param>
        /// <returns>Table with transition probabilities between character pairs. cols == rows == vocabulary.Length.</returns>
        public static Mat CreateOCRHMMTransitionsTable(string vocabulary, IEnumerable<string> lexicon)
        {
            ArgumentNullException.ThrowIfNull(vocabulary);
            ArgumentNullException.ThrowIfNull(lexicon);

            using var lexiconVec = new VectorOfString(lexicon);
            NativeMethods.HandleException(
                NativeMethods.text_createOCRHMMTransitionsTable(vocabulary, lexiconVec.CvPtr, out var ret));

            return new Mat(ret);
        }
    }
}
