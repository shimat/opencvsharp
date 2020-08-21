using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace OpenCvSharp.Detail
{
    /// <summary>
    /// Structure containing image keypoints and descriptors.
    /// </summary>
    public class ImageFeatures : IDisposable
    {
#pragma warning disable 1591
        public int ImgIdx { get; }
        public Size ImgSize{ get; }
        public IReadOnlyList<KeyPoint> Keypoints{ get; }
        public Mat Descriptors{ get; }
#pragma warning restore 1591
        
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="imgIdx"></param>
        /// <param name="imgSize"></param>
        /// <param name="keypoints"></param>
        /// <param name="descriptors"></param>
        public ImageFeatures(int imgIdx, Size imgSize, IReadOnlyList<KeyPoint> keypoints, Mat descriptors)
        {
            ImgIdx = imgIdx;
            ImgSize = imgSize;
            Keypoints = keypoints;
            Descriptors = descriptors;
        }

        /// <summary>
        /// Destructor
        /// </summary>
        ~ImageFeatures()
        {
            Dispose(false);
        }

        /// <summary> 
        /// </summary>
        /// <param name="disposing"></param>
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                Descriptors.Dispose();
            }
        }

        /// <inheritdoc />
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }

#pragma warning disable 1591
    [StructLayout(LayoutKind.Sequential)]
    public struct WImageFeatures
    {
        public int ImgIdx;
        public Size ImgSize;
        public IntPtr Keypoints;
        public IntPtr Descriptors;
    }
#pragma warning restore 1591
}