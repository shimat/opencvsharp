/*
 * (C) 2008-2014 shimat
 * This code is licenced under the LGPL.
 */

using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using OpenCvSharp;
using OpenCvSharp.Utilities;

namespace OpenCvSharp.CPlusPlus
{
    /// <summary>
    /// The Base Class for Background/Foreground Segmentation.
    /// The class is only used to define the common interface for
    /// the whole family of background/foreground segmentation algorithms.
    /// </summary>
    public abstract class BackgroundSubtractor : DisposableCvObject
    {
        /// <summary>
        /// sizeof(BackgroundSubtractor)
        /// </summary>
        public static readonly int SizeOf = NativeMethods.video_BackgroundSubtractor_sizeof().ToInt32();
        /// <summary>
        /// 
        /// </summary>
        protected bool disposed = false;

        /// <summary>
        /// the update operator that takes the next video frame and returns the current foreground mask as 8-bit binary image.
        /// </summary>
        /// <param name="image"></param>
        /// <param name="fgmask"></param>
        /// <param name="learningRate"></param>
        public abstract void Run(InputArray image, OutputArray fgmask, double learningRate=0);

        /// <summary>
        /// computes a background image
        /// </summary>
        /// <param name="backgroundImage"></param>
        public virtual void GetBackgroundImage(OutputArray backgroundImage)
        {
            if (backgroundImage == null)
                throw new ArgumentNullException("backgroundImage");
            backgroundImage.ThrowIfNotReady();
            NativeMethods.video_BackgroundSubtractor_getBackgroundImage(ptr, backgroundImage.CvPtr);
            backgroundImage.Fix();
        }
    }
}
