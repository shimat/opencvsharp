using OpenCvSharp.Internal;

namespace OpenCvSharp.VideoStab;

/// <summary>CPU-based stabilization of a sequence of video frames.</summary>
public static class CvVideoStab
{
    /// <summary>Stabilizes a sequence of frames using OpenCV's one-pass Gaussian motion filter.</summary>
    /// <param name="frames">At least two consecutive 8-bit grayscale or BGR frames with the same dimensions.</param>
    /// <param name="radius">Motion smoothing radius in frames.</param>
    /// <param name="trimRatio">Fraction trimmed from each edge of each output frame, from zero to less than one half.</param>
    /// <param name="motionModel">Motion model estimated between adjacent frames.</param>
    /// <returns>One new frame per input frame, in the same order. The caller owns the returned images.</returns>
    public static Mat[] Stabilize(
        IEnumerable<Mat> frames, int radius = 15, float trimRatio = 0f,
        VideoStabMotionModel motionModel = VideoStabMotionModel.Affine)
    {
        ArgumentNullException.ThrowIfNull(frames);
        var input = frames as Mat[] ?? frames.ToArray();
        if (input.Length < 2)
            throw new ArgumentException("At least two frames are required.", nameof(frames));
        if (radius < 1)
            throw new ArgumentOutOfRangeException(nameof(radius));
        if (!float.IsFinite(trimRatio) || trimRatio < 0f || trimRatio >= 0.5f)
            throw new ArgumentOutOfRangeException(nameof(trimRatio));
        if (!Enum.IsDefined(motionModel))
            throw new ArgumentOutOfRangeException(nameof(motionModel));

        Size frameSize = default;
        MatType frameType = default;
        for (var i = 0; i < input.Length; i++)
        {
            var frame = input[i];
            ArgumentNullException.ThrowIfNull(frame);
            frame.ThrowIfDisposed();
            if (i == 0)
            {
                frameSize = frame.Size();
                frameType = frame.Type();
            }
            if (frame.Empty() || frame.Size() != frameSize || frame.Type() != frameType ||
                (frameType != MatType.CV_8UC1 && frameType != MatType.CV_8UC3))
                throw new ArgumentException("Frames must be nonempty, equally sized, and 8-bit grayscale or BGR.", nameof(frames));
        }

        var results = new Mat[input.Length];
        try
        {
            for (var i = 0; i < results.Length; i++)
                results[i] = new Mat();
            NativeMethods.HandleException(NativeMethods.videostab_stabilize(
                input.Select(static frame => frame.CvPtr).ToArray(), input.Length,
                radius, trimRatio, (int)motionModel,
                results.Select(static frame => frame.CvPtr).ToArray()));
            GC.KeepAlive(input);
            return results;
        }
        catch
        {
            foreach (var result in results)
                result?.Dispose();
            throw;
        }
    }
}
