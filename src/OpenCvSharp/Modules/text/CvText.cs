using System;

// ReSharper disable UnusedMember.Global
// ReSharper disable InconsistentNaming
// ReSharper disable CommentTypo

namespace OpenCvSharp.Text
{
    /// <summary>
    /// cv::text functions
    /// </summary>
    public static class CvText
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
            InputArray input, bool darkOnLight, OutputArray? draw = null, OutputArray? chainBBs = null)
        {
            if (input == null)
                throw new ArgumentNullException(nameof(input));
            input.ThrowIfDisposed();
            draw?.ThrowIfNotReady();
            chainBBs?.ThrowIfNotReady();
            
            using var result = new VectorOfRect();
            NativeMethods.HandleException(
                NativeMethods.text_detectTextSWT(
                    input.CvPtr, 
                    result.CvPtr, 
                    darkOnLight ? 1 : 0,
                    draw?.CvPtr ?? IntPtr.Zero,
                    chainBBs?.CvPtr ?? IntPtr.Zero));
            
            GC.KeepAlive(input);
            draw?.Fix();
            chainBBs?.Fix();

            return result.ToArray();
        }
    }
}
