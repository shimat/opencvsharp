using System;
using System.Collections.Generic;
using System.Text;

// Copyright (C) 2007 by Cristóbal Carnero Liñán
// grendel.ccl@gmail.com
//
// This file is part of cvBlob.
//
// cvBlob is free software: you can redistribute it and/or modify
// it under the terms of the Lesser GNU General Public License as published by
// the Free Software Foundation, either version 3 of the License, or
// (at your option) any later version.
//
// cvBlob is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// Lesser GNU General Public License for more details.
//
// You should have received a copy of the Lesser GNU General Public License
// along with cvBlob.  If not, see <http://www.gnu.org/licenses/>.

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
