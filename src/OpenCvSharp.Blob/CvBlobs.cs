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
    /// Blob set
    /// </summary>
    public class CvBlobs : Dictionary<int, CvBlob>
    {
        /// <summary>
        /// Label values
        /// </summary>
        public LabelData Labels { get; protected set; }

        /// <summary>
        /// Constructor (init only)
        /// </summary>
        public CvBlobs()
        {
        }

        /// <summary>
        /// Constructor (init and cvLabel)
        /// </summary>
        /// <param name="img">Input binary image (depth=IPL_DEPTH_8U and nchannels=1).</param>
        public CvBlobs(IplImage img)
        {
            if (img == null)
                throw new ArgumentNullException("img");
            if (img.IsDisposed)
                throw new ArgumentException("img is disposed");
            if (img.Depth != BitDepth.U8 || img.NChannels != 1)
                throw new ArgumentException("img.Depth == BitDepth.U8 && img.NChannels == 1");

            Label(img);
        }

        #region Methods

        #region BlobMeanColor

        /// <summary>
        /// Calculates mean color of a blob in an image. (cvBlobMeanColor)
        /// </summary>
        /// <param name="targetBlob">The target blob</param>
        /// <param name="originalImage">Original image.</param>
        public CvScalar BlobMeanColor(CvBlob targetBlob, IplImage originalImage)
        {
            if (targetBlob == null)
                throw new ArgumentNullException("targetBlob");
            if (originalImage == null)
                throw new ArgumentNullException("originalImage");
            if (originalImage.Depth != BitDepth.U8)
                throw new ArgumentException("imgOut.Depth != BitDepth.U8");
            if (originalImage.NChannels != 3)
                throw new ArgumentException("imgOut.NChannels != 3");
            if (Labels == null)
                throw new ArgumentException("blobs.Labels == null");

            int step = originalImage.WidthStep;
            CvRect roi = originalImage.ROI;
            int width = roi.Width;
            int height = roi.Height;
            int offset = roi.X + (roi.Y * step);

            int mb = 0;
            int mg = 0;
            int mr = 0;
            unsafe
            {
                byte* imgData = originalImage.ImageDataPtr + offset;
                for (int r = 0; r < height; r++)
                {
                    for (int c = 0; c < width; c++)
                    {
                        if (Labels[r, c] == targetBlob.Label)
                        {
                            mb += imgData[3 * c + 0];
                            mg += imgData[3 * c + 1];
                            mr += imgData[3 * c + 2];
                        }
                    }
                    imgData += step;
                }
            }
            int pixels = targetBlob.Area;
            return new CvColor((byte)(mr / pixels), (byte)(mg / pixels), (byte)(mb / pixels));
        }

        #endregion

        #region FilterByArea

        /// <summary>
        /// Filter blobs by area. 
        /// Those blobs whose areas are not in range will be erased from the input list of blobs. (cvFilterByArea)
        /// </summary>
        /// <param name="minArea">Minimun area.</param>
        /// <param name="maxArea">Maximun area.</param>
        public void FilterByArea(int minArea, int maxArea)
        {
            int[] keys = new int[Count];
            Keys.CopyTo(keys, 0);

            foreach (int key in keys)
            {
                int area = this[key].Area;
                if (area < minArea || area > maxArea)
                {
                    Remove(key);
                }
            }
        }

        #endregion

        #region FilterByLabel

        /// <summary>
        /// Filter blobs by label.
        /// Delete all blobs except those with label l.
        /// </summary>
        /// <param name="label">Label to leave.</param>
        public void FilterByLabel(int label)
        {
            int[] keys = new int[Count];
            Keys.CopyTo(keys, 0);

            foreach (int key in keys)
            {
                if (this[key].Label != label)
                {
                    Remove(key);
                }
            }
        }

        #endregion

        #region FilterLabels

        /// <summary>
        /// Draw a binary image with the blobs that have been given. (cvFilterLabels)
        /// </summary>
        /// <param name="imgOut">Output binary image (depth=IPL_DEPTH_8U and nchannels=1).</param>
        public void FilterLabels(IplImage imgOut)
        {
            if (imgOut == null)
                throw new ArgumentNullException("imgOut");
            if (imgOut.Depth != BitDepth.U8)
                throw new ArgumentException("imgOut.Depth != BitDepth.U8");
            if (imgOut.NChannels != 1)
                throw new ArgumentException("imgOut.NChannels != 1");
            if (Labels == null)
                throw new ArgumentException("blobs.Labels == null");

            CvRect roi = Labels.Roi;
            int w = roi.Width;
            int h = roi.Height;
            int step = imgOut.WidthStep;
            int offset = roi.X + (roi.Y * step);

            unsafe
            {
                byte* imgData = imgOut.ImageDataPtr + offset;

                for (int r = 0; r < h; r++, imgData += step)
                {
                    for (int c = 0; c < w; c++)
                    {
                        int label = Labels[r, c];
                        if (label != 0)
                        {
                            if (ContainsKey(label))
                                imgData[c] = 0xff;
                            else
                                imgData[c] = 0x00;
                        }
                        else
                        {
                            imgData[c] = 0x00;
                        }
                    }
                }
            }
        }

        #endregion

        #region GreaterBlob

        /// <summary>
        /// Find greater blob. (cvGreaterBlob)
        /// </summary>
        /// <returns>The greater blob.</returns>
        public CvBlob GreaterBlob()
        {
            return LargestBlob();
        }

        /// <summary>
        /// Find the largest blob. (cvGreaterBlob)
        /// </summary>
        /// <returns>The largest blob.</returns>
        public CvBlob LargestBlob()
        {
            if (Count == 0)
                return null;

            var list = new List<KeyValuePair<int, CvBlob>>(this);
            // 降順ソート
            list.Sort((kv1, kv2) =>
            {
                CvBlob b1 = kv1.Value;
                CvBlob b2 = kv2.Value;
                if (b1 == null)
                    return -1;
                if (b2 == null)
                    return 1;
                return b2.Area - b1.Area;
            });
            return list[0].Value;
        }

        #endregion

        #region GetLabel

        /// <summary>
        /// Label the connected parts of a binary image. (cvLabel)
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns>Number of pixels that has been labeled.</returns>
        public int GetLabel(int x, int y)
        {
            return Labels[y, x];
        }

        #endregion

        #region Label

        /// <summary>
        /// Label the connected parts of a binary image. (cvLabel)
        /// </summary>
        /// <param name="img">Input binary image (depth=IPL_DEPTH_8U and num. channels=1).</param>
        /// <returns>Number of pixels that has been labeled.</returns>
        public int Label(IplImage img)
        {
            if (img == null)
                throw new ArgumentNullException("img");

            Labels = new LabelData(img.Height, img.Width, img.ROI);
            return Labeller.Perform(img, this);
        }

        #endregion

        #region RenderBlobs

        /// <summary>
        /// Draws or prints information about blobs. (cvRenderBlobs)
        /// </summary>
        /// <param name="imgSource">Input image (depth=IPL_DEPTH_8U and num. channels=3).</param>
        /// <param name="imgDest">Output image (depth=IPL_DEPTH_8U and num. channels=3).</param>
        public void RenderBlobs(IplImage imgSource, IplImage imgDest)
        {
            CvBlobLib.RenderBlobs(this, imgSource, imgDest);
        }

        /// <summary>
        /// Draws or prints information about blobs. (cvRenderBlobs)
        /// </summary>
        /// <param name="imgSource">Input image (depth=IPL_DEPTH_8U and num. channels=3).</param>
        /// <param name="imgDest">Output image (depth=IPL_DEPTH_8U and num. channels=3).</param>
        /// <param name="mode">Render mode. By default is CV_BLOB_RENDER_COLOR|CV_BLOB_RENDER_CENTROID|CV_BLOB_RENDER_BOUNDING_BOX|CV_BLOB_RENDER_ANGLE.</param>
        public void RenderBlobs(IplImage imgSource, IplImage imgDest, RenderBlobsMode mode)
        {
            CvBlobLib.RenderBlobs(this, imgSource, imgDest, mode);
        }

        /// <summary>
        /// Draws or prints information about blobs. (cvRenderBlobs)
        /// </summary>
        /// <param name="imgSource">Input image (depth=IPL_DEPTH_8U and num. channels=3).</param>
        /// <param name="imgDest">Output image (depth=IPL_DEPTH_8U and num. channels=3).</param>
        /// <param name="mode">Render mode. By default is CV_BLOB_RENDER_COLOR|CV_BLOB_RENDER_CENTROID|CV_BLOB_RENDER_BOUNDING_BOX|CV_BLOB_RENDER_ANGLE.</param>
        /// <param name="alpha">If mode CV_BLOB_RENDER_COLOR is used. 1.0 indicates opaque and 0.0 translucent (1.0 by default).</param>
        public void RenderBlobs(IplImage imgSource, IplImage imgDest, RenderBlobsMode mode, Double alpha)
        {
            CvBlobLib.RenderBlobs(this, imgSource, imgDest, mode, alpha);
        }

        #endregion

        #region UpdateTracks

        /// <summary>
        /// Updates list of tracks based on current blobs. 
        /// </summary>
        /// <param name="tracks">List of tracks.</param>
        /// <param name="thDistance">Max distance to determine when a track and a blob match.</param>
        /// <param name="thInactive">Max number of frames a track can be inactive.</param>
        /// <remarks>
        /// Tracking based on:
        /// A. Senior, A. Hampapur, Y-L Tian, L. Brown, S. Pankanti, R. Bolle. Appearance Models for
        /// Occlusion Handling. Second International workshop on Performance Evaluation of Tracking and
        /// Surveillance Systems &amp; CVPR'01. December, 2001.
        /// (http://www.research.ibm.com/peoplevision/PETS2001.pdf)
        /// </remarks>
        public void UpdateTracks(CvTracks tracks, double thDistance, int thInactive)
        {
            UpdateTracks(tracks, thDistance, thInactive, 0);
        }

        /// <summary>
        /// Updates list of tracks based on current blobs. 
        /// </summary>
        /// <param name="tracks">List of tracks.</param>
        /// <param name="thDistance">Max distance to determine when a track and a blob match.</param>
        /// <param name="thInactive">Max number of frames a track can be inactive.</param>
        /// <param name="thActive">If a track becomes inactive but it has been active less than thActive frames, the track will be deleted.</param>
        /// <remarks>
        /// Tracking based on:
        /// A. Senior, A. Hampapur, Y-L Tian, L. Brown, S. Pankanti, R. Bolle. Appearance Models for
        /// Occlusion Handling. Second International workshop on Performance Evaluation of Tracking and
        /// Surveillance Systems &amp; CVPR'01. December, 2001.
        /// (http://www.research.ibm.com/peoplevision/PETS2001.pdf)
        /// </remarks>
        public void UpdateTracks(CvTracks tracks, double thDistance, int thInactive, int thActive)
        {
            if (tracks == null)
                throw new ArgumentNullException("tracks");

            int nBlobs = this.Count;
            int nTracks = tracks.Count;

            if (nBlobs == 0)
                return;

            // Proximity matrix:
            // Last row/column is for ID/label.
            // Last-1 "/" is for accumulation.
            ProximityMatrix close = new ProximityMatrix(nBlobs, nTracks);

            // Initialization:
            int i = 0;
            foreach (CvBlob blob in Values)
            {
                close.AB[i] = 0;
                close.IB[i] = blob.Label;
                i++;
            }

            int maxTrackID = 0;
            int j = 0;
            foreach (CvTrack track in tracks.Values)
            {
                close.AT[j] = 0;
                close.AT[j] = track.Id;
                if (track.Id > maxTrackID)
                    maxTrackID = track.Id;
                j++;
            }

            // Proximity matrix calculation and "used blob" list inicialization:
            for (i = 0; i < nBlobs; i++)
            {
                for (j = 0; j < nTracks; j++)
                {
                    CvBlob b = this[close.IB[i]];
                    CvTrack t = tracks[close.IT[j]];
                    close[i, j] = (DistantBlobTrack(b, t) < thDistance) ? 1 : 0;
                    if (close[i, j] < thDistance)
                    {
                        close.AB[i]++;
                        close.AT[j]++;
                    }
                }
            }

            /////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            // Detect inactive tracks
            for (j = 0; j < nTracks; j++)
            {
                int c = close[nBlobs, j];
                if (c == 0)
                {
                    //cout << "Inactive track: " << j << endl;

                    // Inactive track.
                    CvTrack track = tracks[j];
                    track.Inactive++;
                    track.Label = 0;
                }
            }

            // Detect new tracks
            for (i = 0; i < nBlobs; i++)
            {
                int c = close.AB[i];
                if (c == 0)
                {
                    //cout << "Blob (new track): " << maxTrackID+1 << endl;
                    //cout << *B(i) << endl;

                    // New track.
                    maxTrackID++;
                    CvBlob blob = this[i+1];
                    CvTrack track = new CvTrack
                    {
                        Id = maxTrackID,
                        Label = blob.Label,
                        MinX = blob.MinX,
                        MinY = blob.MinY,
                        MaxX = blob.MaxX,
                        MaxY = blob.MaxY,
                        Centroid = blob.Centroid,
                        LifeTime = 0,
                        Active = 0,
                        Inactive = 0,
                    };
                    tracks[maxTrackID] = track;
                }
            }

            // Clustering
            for (j = 0; j < nTracks; j++)
            {
                int c = close.AT[j];
                if (c != 0)
                {
                    List<CvTrack> tt = new List<CvTrack> {tracks[j]};
                    List<CvBlob> bb = new List<CvBlob>();

                    GetClusterForTrack(j, close, nBlobs, nTracks, this, tracks, bb, tt);

                    // Select track
                    CvTrack track = null;
                    int area = 0;
                    foreach (CvTrack t in tt)
                    {
                        int a = (t.MaxX - t.MinX) * (t.MaxY - t.MinY);
                        if (a > area)
                        {
                            area = a;
                            track = t;
                        }
                    }

                    // Select blob
                    CvBlob blob = null;
                    area = 0;
                    foreach (CvBlob b in Values)
                    {
                        if (b.Area > area)
                        {
                            area = b.Area;
                            blob = b;
                        }
                    }

                    if (blob == null || track == null)
                        throw new NotSupportedException();

                    // Update track
                    track.Label = blob.Label;
                    track.Centroid = blob.Centroid;
                    track.MinX = blob.MinX;
                    track.MinY = blob.MinY;
                    track.MaxX = blob.MaxX;
                    track.MaxY = blob.MaxY;
                    if (track.Inactive != 0)
                        track.Active = 0;
                    track.Inactive = 0;

                    // Others to inactive
                    foreach (CvTrack t in tt)
                    {
                        if (t != track)
                        {
                            //cout << "Inactive: track=" << t->id << endl;
                            t.Inactive++;
                            t.Label = 0;
                        }
                    }
                }
            }
            /////////////////////////////////////////////////////////////////////////////////////////////////////////////////

            int[] trackKeys = new int[tracks.Count];
            tracks.Keys.CopyTo(trackKeys, 0);
            foreach (int tkey in trackKeys)
            {
                CvTrack t = tracks[tkey];
                if ((t.Inactive >= thInactive) ||
                    ((t.Inactive != 0) && (thActive != 0) && (t.Active < thActive)))
                {
                    tracks.Remove(tkey);
                }
                else
                {
                    t.LifeTime++;
                    if (t.Inactive == 0)
                        t.Active++;
                }
            }
        }

        private double DistantBlobTrack(CvBlob b, CvTrack t)
        {
            double d1;
            if (b.Centroid.X < t.MinX)
            {
                if (b.Centroid.Y < t.MinY)
                    d1 = Math.Max(t.MinX - b.Centroid.X, t.MinY - b.Centroid.Y);
                else if (b.Centroid.Y > t.MaxY)
                    d1 = Math.Max(t.MinX - b.Centroid.X, b.Centroid.Y - t.MaxY);
                else // if (t.MinY < b.Centroid.Y)&&(b.Centroid.Y < t.MaxY)
                    d1 = t.MinX - b.Centroid.X;
            }
            else if (b.Centroid.X > t.MaxX)
            {
                if (b.Centroid.Y < t.MinY)
                    d1 = Math.Max(b.Centroid.X - t.MaxX, t.MinY - b.Centroid.Y);
                else if (b.Centroid.Y > t.MaxY)
                    d1 = Math.Max(b.Centroid.X - t.MaxX, b.Centroid.Y - t.MaxY);
                else
                    d1 = b.Centroid.X - t.MaxX;
            }
            else // if (t.MinX =< b.Centroid.X) && (b.Centroid.X =< t.MaxX)
            {
                if (b.Centroid.Y < t.MinY)
                    d1 = t.MinY - b.Centroid.Y;
                else if (b.Centroid.Y > t.MaxY)
                    d1 = b.Centroid.Y - t.MaxY;
                else
                    return 0.0;
            }

            double d2;
            if (t.Centroid.X < b.MinX)
            {
                if (t.Centroid.Y < b.MinY)
                    d2 = Math.Max(b.MinX - t.Centroid.X, b.MinY - t.Centroid.Y);
                else if (t.Centroid.Y > b.MaxY)
                    d2 = Math.Max(b.MinX - t.Centroid.X, t.Centroid.Y - b.MaxY);
                else // if (b.MinY < t.Centroid.Y)&&(t.Centroid.Y < b.MaxY)
                    d2 = b.MinX - t.Centroid.X;
            }
            else if (t.Centroid.X > b.MaxX)
            {
                if (t.Centroid.Y < b.MinY)
                    d2 = Math.Max(t.Centroid.X - b.MaxX, b.MinY - t.Centroid.Y);
                else if (t.Centroid.Y > b.MaxY)
                    d2 = Math.Max(t.Centroid.X - b.MaxX, t.Centroid.Y - b.MaxY);
                else
                    d2 = t.Centroid.X - b.MaxX;
            }
            else // if (b.MinX =< t.Centroid.X) && (t.Centroid.X =< b.MaxX)
            {
                if (t.Centroid.Y < b.MinY)
                    d2 = b.MinY - t.Centroid.Y;
                else if (t.Centroid.Y > b.MaxY)
                    d2 = t.Centroid.Y - b.MaxY;
                else
                    return 0.0;
            }

            return Math.Min(d1, d2);
        }

        private static void GetClusterForTrack(int trackPos, ProximityMatrix close,
            int nBlobs, int nTracks, CvBlobs blobs,
            CvTracks tracks, List<CvBlob> bb, List<CvTrack> tt)
        {
            for (int i = 0; i < nBlobs; i++)
            {
                if (close[i, trackPos] != 0)
                {
                    bb.Add(blobs[i]);

                    int c = close.AB[i];

                    close[i, trackPos] = 0;
                    close.AB[i]--;
                    close.AT[trackPos]--;

                    if (c > 1)
                    {
                        GetClusterForBlob(i, close, nBlobs, nTracks, blobs, tracks, bb, tt);
                    }
                }
            }
        }

        private static void GetClusterForBlob(int blobPos, ProximityMatrix close,
            int nBlobs, int nTracks, CvBlobs blobs, CvTracks tracks,
            List<CvBlob> bb, List<CvTrack> tt)
        {
            for (int j = 0; j < nTracks; j++)
            {
                if (close[blobPos, j] != 0)
                {
                    tt.Add(tracks[j]);

                    int c = close.AT[j];

                    close[blobPos, j] = 0;
                    close.AB[blobPos]--;
                    close.AT[j]--;

                    if (c > 1)
                    {
                        GetClusterForTrack(j, close, nBlobs, nTracks, blobs, tracks, bb, tt);
                    }
                }
            }
        }

        #endregion

        #endregion
    }
}
