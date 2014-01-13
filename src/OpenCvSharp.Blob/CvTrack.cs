using System;
using System.Collections.Generic;
using System.Text;

namespace OpenCvSharp.Blob
{    
    /// <summary>
    /// Struct that contain information about one track.
    /// </summary>
    public class CvTrack
    {        
        /// <summary>
        /// Track identification number.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Label assigned to the blob related to this track.
        /// </summary>
        public int Label { get; set; }

        /// <summary>
        /// X min.
        /// </summary>
        public int MinX { get; set; }
        /// <summary>
        /// X max.
        /// </summary>
        public int MaxX { get; set; }
        /// <summary>
        /// Y min.
        /// </summary>
        public int MinY { get; set; }
        /// <summary>
        /// Y max.
        /// </summary>
        public int MaxY { get; set; }

        /// <summary>
        /// Centroid.
        /// </summary>
        public CvPoint2D64f Centroid { get; set; }

        /// <summary>
        /// Indicates how much frames the object has been in scene.
        /// </summary>
        public int LifeTime { get; set; }
        /// <summary>
        /// Indicates number of frames that has been active from last inactive period.
        /// </summary>
        public int Active { get; set; }
        /// <summary>
        /// Indicates number of frames that has been missing.
        /// </summary>
        public int Inactive { get; set; }
    }
}
