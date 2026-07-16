using OpenCvSharp.Internal;
using OpenCvSharp.LineDescriptor;

namespace OpenCvSharp;

public static partial class Cv2
{
    /// <summary>
    /// cv::line_descriptor functions.
    /// </summary>
    public static partial class LineDescriptor
    {
        /// <summary>
        /// Draws matched key lines from two images.
        /// </summary>
        public static unsafe void DrawLineMatches(
            Mat image1,
            KeyLine[] keyLines1,
            Mat image2,
            KeyLine[] keyLines2,
            DMatch[] matches,
            Mat output,
            Scalar? matchColor = null,
            Scalar? singleLineColor = null,
            byte[]? matchesMask = null,
            DrawLinesMatchesFlags flags = DrawLinesMatchesFlags.Default)
        {
            ArgumentNullException.ThrowIfNull(image1);
            ArgumentNullException.ThrowIfNull(keyLines1);
            ArgumentNullException.ThrowIfNull(image2);
            ArgumentNullException.ThrowIfNull(keyLines2);
            ArgumentNullException.ThrowIfNull(matches);
            ArgumentNullException.ThrowIfNull(output);
            matchesMask ??= [];
            if (matchesMask.Length != 0 && matchesMask.Length != matches.Length)
                throw new ArgumentException("The match mask must be empty or have one entry per match.", nameof(matchesMask));
            fixed (KeyLine* keyLines1Pointer = keyLines1)
            fixed (KeyLine* keyLines2Pointer = keyLines2)
            fixed (DMatch* matchesPointer = matches)
            fixed (byte* maskPointer = matchesMask)
            {
                NativeMethods.HandleException(
                    NativeMethods.line_descriptor_drawLineMatches(
                        image1.CvPtr, keyLines1Pointer, keyLines1.Length,
                        image2.CvPtr, keyLines2Pointer, keyLines2.Length,
                        matchesPointer, matches.Length, output.CvPtr,
                        matchColor ?? Scalar.All(-1), singleLineColor ?? Scalar.All(-1),
                        maskPointer, matchesMask.Length, (int)flags));
            }
            GC.KeepAlive(image1);
            GC.KeepAlive(image2);
            GC.KeepAlive(output);
        }

        /// <summary>
        /// Draws key lines on an image.
        /// </summary>
        public static unsafe void DrawKeylines(
            Mat image,
            KeyLine[] keyLines,
            Mat output,
            Scalar? color = null,
            DrawLinesMatchesFlags flags = DrawLinesMatchesFlags.Default)
        {
            ArgumentNullException.ThrowIfNull(image);
            ArgumentNullException.ThrowIfNull(keyLines);
            ArgumentNullException.ThrowIfNull(output);
            fixed (KeyLine* keyLinePointer = keyLines)
            {
                NativeMethods.HandleException(
                    NativeMethods.line_descriptor_drawKeylines(
                        image.CvPtr, keyLinePointer, keyLines.Length, output.CvPtr,
                        color ?? Scalar.All(-1), (int)flags));
            }
            GC.KeepAlive(image);
            GC.KeepAlive(output);
        }
    }
}
