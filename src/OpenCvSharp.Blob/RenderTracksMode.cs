/*
 * (C) 2008-2013 Schima
 * This code is licenced under the LGPL.
 */

using System;
using System.Collections.Generic;
using System.Text;

namespace OpenCvSharp.Blob
{
	/// <summary>
    /// Render mode of cvRenderTracks
    /// </summary>
	[Flags]
	public enum RenderTracksMode : ushort
	{
        /// <summary>
        /// Print the ID of each track in the image.
        /// [CV_TRACK_RENDER_ID]
        /// </summary>
        ID = CvBlobConst.CV_TRACK_RENDER_ID,

        /// <summary>
        /// Print track info to log out.
        /// [CV_TRACK_RENDER_TO_LOG]
        /// </summary>
        ToLog = CvBlobConst.CV_TRACK_RENDER_TO_LOG,

        /// <summary>
        /// Print track info to log out.
        /// [CV_TRACK_RENDER_TO_STD]
        /// </summary>
        ToStd = CvBlobConst.CV_TRACK_RENDER_TO_STD,
	}
}
