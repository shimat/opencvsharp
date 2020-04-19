using System;

namespace OpenCvSharp.Blob
{
    /// <summary>
    /// Render mode of cvRenderBlobs
    /// </summary>
    [Flags]
    public enum RenderBlobsModes
    {
        /// <summary>
        /// No flags (=0)
        /// </summary>
        None = 0,

        /// <summary>
        /// Render each blog with a different color.
        /// [CV_BLOB_RENDER_COLOR]
        /// </summary>
        Color = CvBlobConst.CV_BLOB_RENDER_COLOR,

        /// <summary>
        /// Render centroid.
        /// CV_BLOB_RENDER_CENTROID]
        /// </summary>
        Centroid = CvBlobConst.CV_BLOB_RENDER_CENTROID,

        /// <summary>
        /// Render bounding box.
        /// [CV_BLOB_RENDER_BOUNDING_BOX]
        /// </summary>
        BoundingBox = CvBlobConst.CV_BLOB_RENDER_BOUNDING_BOX,

        /// <summary>
        /// Render angle.
        /// [CV_BLOB_RENDER_ANGLE]
        /// </summary>
        Angle = CvBlobConst.CV_BLOB_RENDER_ANGLE,

        /// <summary>
        /// Print blob data to log out.
        /// [CV_BLOB_RENDER_TO_LOG]
        /// </summary>
        ToLog = CvBlobConst.CV_BLOB_RENDER_TO_LOG,

        /// <summary>
        /// Print blob data to std out.
        /// [CV_BLOB_RENDER_TO_STD]
        /// </summary>
        ToStd = CvBlobConst.CV_BLOB_RENDER_TO_STD,
    }
}
