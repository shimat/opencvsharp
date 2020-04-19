using System;

namespace OpenCvSharp.Blob
{
    /// <summary>
    /// Render mode of cvRenderTracks
    /// </summary>
    [Flags]
    public enum RenderTracksModes
    {
        /// <summary>
        /// No flags
        /// [0]
        /// </summary>
        None = 0,

        /// <summary>
        /// Print the ID of each track in the image.
        /// [CV_TRACK_RENDER_ID]
        /// </summary>
        Id = CvBlobConst.CV_TRACK_RENDER_ID,

        /// <summary>
        /// Draw bounding box of each track in the image. \see cvRenderTracks
        /// [CV_TRACK_RENDER_BOUNDING_BOX]
        /// </summary>
        BoundingBox = CvBlobConst.CV_TRACK_RENDER_BOUNDING_BOX,
    }
}
