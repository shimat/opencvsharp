using System;
using System.Runtime.InteropServices;
using System.Security;
using System.Security.Permissions;
using OpenCvSharp.Utilities;

#pragma warning disable 1591

namespace OpenCvSharp.Blob.Old
{
    /// <summary>
    /// cvblob's P/Invoke methods
    /// </summary>
    [SuppressUnmanagedCodeSecurity]
    internal static class CvBlobInvoke
    {
        /// <summary>
        /// DLL file name
        /// </summary>
        public const string DllExtern = "OpenCvSharpExtern";

        #region Static constructor
        /// <summary>
        /// Static constructor
        /// </summary>
        [SecurityPermission(SecurityAction.Demand, Flags = SecurityPermissionFlag.UnmanagedCode)]
        static CvBlobInvoke()
        {
            // call cv to enable redirecting
            TryPInvoke();
        }

#if LANG_JP
        /// <summary>
        /// PInvokeが正常に行えるかチェックする
        /// </summary>
#else
        /// <summary>
        /// Checks whether PInvoke functions can be called
        /// </summary>
#endif
        private static void TryPInvoke()
        {
            // call cv to enable redirecting 
            if (!_tried)
            {
                Cv.GetTickCount();
                try
                {
                    CvBlobs_sizeof();
                }
                catch (DllNotFoundException e)
                {
                    PInvokeHelper.DllImportError(e);
                }
                catch (BadImageFormatException e)
                {
                    PInvokeHelper.DllImportError(e);
                }
                finally
                {
                    _tried = true;
                }
            }
        }
        private static bool _tried = false;
        #endregion

        #region DllImport
        #region Methods
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern CvScalar cvb_cvBlobMeanColor(IntPtr blob, IntPtr imgLabel, IntPtr img);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern double cvb_cvAngle(IntPtr blob);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void cvb_cvCentralMoments(IntPtr blob, IntPtr img);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern CvPoint2D64f cvb_cvCentroid(IntPtr blob);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern double cvb_cvContourPolygonArea(IntPtr p);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern double cvb_cvContourPolygonPerimeter(IntPtr p);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr cvb_cvConvertChainCodesToPolygon(IntPtr cc);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void cvb_cvFilterByArea(IntPtr blobs, uint minArea, uint maxArea);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void cvb_cvFilterLabels(IntPtr imgIn, IntPtr imgOut, IntPtr blobs);
        //[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        //public static extern IntPtr cvb_cvGetContour(IntPtr blob, IntPtr img);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern UInt32 cvb_cvGetLabel(IntPtr img, uint x, uint y);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern UInt32 cvb_cvGreaterBlob(IntPtr blobs);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern UInt32 cvb_cvLabel(IntPtr img, IntPtr imgOut, IntPtr blobs);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr cvb_cvPolygonContourConvexHull(IntPtr p);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void cvb_cvReleaseBlob(IntPtr blob);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void cvb_cvReleaseBlobs(IntPtr blobs);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void cvb_cvRenderBlob(IntPtr imgLabel, IntPtr blob, IntPtr imgSource, IntPtr imgDest, [MarshalAs(UnmanagedType.U2)] RenderBlobsMode mode, CvScalar color, double alpha);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void cvb_cvRenderBlobs(IntPtr imgLabel, IntPtr blobs, IntPtr imgSource, IntPtr imgDest, [MarshalAs(UnmanagedType.U2)] RenderBlobsMode mode, double alpha);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void cvb_cvRenderContourChainCode(IntPtr contour, IntPtr img, CvScalar color);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void cvb_cvRenderContourPolygon(IntPtr contour, IntPtr img, CvScalar color);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void cvb_cvRenderTracks(IntPtr tracks, IntPtr imgSource, IntPtr imgDest, [MarshalAs(UnmanagedType.U2)] RenderTracksMode mode, IntPtr font);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void cvb_cvSetImageROItoBlob(IntPtr img, IntPtr blob);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr cvb_cvSimplifyPolygon(IntPtr p, double delta);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void cvb_cvUpdateTracks(IntPtr b, IntPtr t, double thDistance, uint thInactive);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void cvb_cvWriteContourPolygonCSV(IntPtr p, [MarshalAs(UnmanagedType.LPStr)] string filename);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void cvb_cvWriteContourPolygonSVG(IntPtr p, [MarshalAs(UnmanagedType.LPStr)] string filename, CvScalar stroke, CvScalar fill);
        #endregion
        #region CvBlob
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern int CvBlob_sizeof();
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr CvBlob_construct();
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void CvBlob_destruct(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern unsafe uint* CvBlob_label(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern unsafe uint* CvBlob_area(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern unsafe uint* CvBlob_m00(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern unsafe uint* CvBlob_minx(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern unsafe uint* CvBlob_maxx(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern unsafe uint* CvBlob_miny(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern unsafe uint* CvBlob_maxy(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern unsafe CvPoint2D64f* CvBlob_centroid(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern unsafe double* CvBlob_m10(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern unsafe double* CvBlob_m01(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern unsafe double* CvBlob_m11(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern unsafe double* CvBlob_m20(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern unsafe double* CvBlob_m02(IntPtr obj);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern unsafe bool* CvBlob_centralMoments(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern unsafe double* CvBlob_u11(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern unsafe double* CvBlob_u20(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern unsafe double* CvBlob_u02(IntPtr obj);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr CvBlob_contour(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr CvBlob_internalContours(IntPtr obj);
        #endregion
        #region CvContourChainCode
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern int CvContourChainCode_sizeof();
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern CvPoint CvContourChainCode_startingPoint_get(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void CvContourChainCode_startingPoint_set(IntPtr obj, CvPoint value);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr CvContourChainCode_chainCode_get(IntPtr obj);
        #endregion
        #region CvContoursChainCode
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void CvContoursChainCode_PushBack(IntPtr obj, IntPtr item);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void CvContoursChainCode_Clear(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool CvContoursChainCode_Contains(IntPtr obj, IntPtr item);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void CvContoursChainCode_CopyTo(IntPtr obj, [In, Out] IntPtr[] array, int arrayIndex);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern int CvContoursChainCode_Count(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool CvContoursChainCode_Remove(IntPtr obj, IntPtr value);
        #endregion
        #region CvChainCodes
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void CvChainCodes_PushBack(IntPtr obj, CvChainCode item);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void CvChainCodes_Clear(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool CvChainCodes_Contains(IntPtr obj, [MarshalAs(UnmanagedType.I4)] CvChainCode item);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void CvChainCodes_CopyTo(IntPtr obj, [In, Out] CvChainCode[] array, int arrayIndex);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern int CvChainCodes_Count(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool CvChainCodes_Remove(IntPtr obj, [MarshalAs(UnmanagedType.I4)] CvChainCode value);
        #endregion
        #region CvContourPolygon
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void CvContourPolygon_destruct(IntPtr obj);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern int CvContourPolygon_IndexOf(IntPtr obj, CvPoint item);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void CvContourPolygon_Insert(IntPtr obj, int index, CvPoint item);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void CvContourPolygon_RemoveAt(IntPtr obj, int index);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern CvPoint CvContourPolygon_This_get(IntPtr obj, int index);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void CvContourPolygon_This_set(IntPtr obj, int index, CvPoint value);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void CvContourPolygon_Add(IntPtr obj, CvPoint item);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void CvContourPolygon_Clear(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern bool CvContourPolygon_Contains(IntPtr obj, CvPoint item);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void CvContourPolygon_CopyTo(IntPtr obj, [In, Out] CvPoint[] array, int arrayIndex);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern int CvContourPolygon_Count(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern bool CvContourPolygon_Remove(IntPtr obj, CvPoint value);
        #endregion
        #region CvBlobs
        [DllImport(DllExtern, EntryPoint = "CvBlobs_sizeof", CallingConvention = CallingConvention.Cdecl)]
        private static extern int CvBlobs_sizeof_();
        public static int CvBlobs_sizeof()
        {
            return CvBlobs_sizeof_();
        }
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr CvBlobs_construct();
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void CvBlobs_destruct(IntPtr obj);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void CvBlobs_Add(IntPtr blobs, UInt32 key, IntPtr value);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern bool CvBlobs_ContainsKey(IntPtr blobs, UInt32 key);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void CvBlobs_Keys(IntPtr blobs, [In, Out] UInt32[] keys);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern bool CvBlobs_RemoveAt(IntPtr blobs, UInt32 key);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern bool CvBlobs_TryGetValue(IntPtr blobs, UInt32 key, out IntPtr value);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void CvBlobs_Values(IntPtr blobs, [In, Out] IntPtr[] values);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        [Obsolete("", true)]
        public static extern void CvBlobs_Clear(IntPtr blobs);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool CvBlobs_Contains(IntPtr blobs, UInt32 key, IntPtr value);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern int CvBlobs_Count(IntPtr blobs);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool CvBlobs_Remove(IntPtr blobs, UInt32 key, IntPtr value);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr CvBlobs_get(IntPtr blobs, UInt32 key);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void CvBlobs_set(IntPtr blobs, UInt32 key, IntPtr value);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void CvBlobs_GetKeysAndValues(IntPtr blobs, [In, Out] UInt32[] keys, [In, Out] IntPtr[] values);
        #endregion
        #region CvTracks
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern int CvTracks_sizeof();
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr CvTracks_construct();
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void CvTracks_destruct(IntPtr obj);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern int CvTrack_sizeof();
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr CvTrack_construct();
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void CvTrack_destruct(IntPtr track);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void CvTracks_cvReleaseTracks(IntPtr tracks);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void CvTracks_Add(IntPtr obj, UInt32 key, IntPtr value);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool CvTracks_ContainsKey(IntPtr obj, UInt32 key);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void CvTracks_Keys(IntPtr obj, [In, Out]UInt32[] keys);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool CvTracks_RemoveAt(IntPtr obj, UInt32 key);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool CvTracks_TryGetValue(IntPtr obj, UInt32 key, out IntPtr value);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void CvTracks_Values(IntPtr obj, [In, Out] IntPtr[] values);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        [Obsolete("", true)]
        public static extern void CvTracks_Clear(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool CvTracks_Contains(IntPtr obj, UInt32 key, IntPtr value);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern int CvTracks_Count(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool CvTracks_Remove(IntPtr obj, UInt32 key, IntPtr value);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr CvTracks_get(IntPtr obj, UInt32 key);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void CvTracks_set(IntPtr obj, UInt32 key, IntPtr value);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void CvTracks_GetKeysAndValues(IntPtr obj, [In, Out]UInt32[] keys, [In, Out]IntPtr[] values);
        #endregion
        #endregion
    }
}