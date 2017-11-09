using System;

namespace OpenCvSharp
{
    /// <summary>
    /// The Base Class for Background/Foreground Segmentation.
    /// The class is only used to define the common interface for
    /// the whole family of background/foreground segmentation algorithms.
    /// </summary>
    public abstract class BackgroundSubtractor : Algorithm
    {
        /// <summary>
        /// the update operator that takes the next video frame and returns the current foreground mask as 8-bit binary image.
        /// </summary>
        /// <param name="image"></param>
        /// <param name="fgmask"></param>
        /// <param name="learningRate"></param>
        public virtual void Apply(InputArray image, OutputArray fgmask, double learningRate = -1)
        {
            if (image == null)
                throw new ArgumentNullException(nameof(image));
            if (fgmask == null)
                throw new ArgumentNullException(nameof(fgmask));
            image.ThrowIfDisposed();
            fgmask.ThrowIfNotReady();
            
            NativeMethods.video_BackgroundSubtractor_apply(ptr, image.CvPtr, fgmask.CvPtr, learningRate);
            
            fgmask.Fix();
            GC.KeepAlive(this);
            GC.KeepAlive(image);
            GC.KeepAlive(fgmask);
        }

        /// <summary>
        /// computes a background image
        /// </summary>
        /// <param name="backgroundImage"></param>
        public virtual void GetBackgroundImage(OutputArray backgroundImage)
        {
            if (backgroundImage == null)
                throw new ArgumentNullException(nameof(backgroundImage));
            backgroundImage.ThrowIfNotReady();

            NativeMethods.video_BackgroundSubtractor_getBackgroundImage(ptr, backgroundImage.CvPtr);
            GC.KeepAlive(this);
            GC.KeepAlive(backgroundImage);
            backgroundImage.Fix();
        }
    }
}
