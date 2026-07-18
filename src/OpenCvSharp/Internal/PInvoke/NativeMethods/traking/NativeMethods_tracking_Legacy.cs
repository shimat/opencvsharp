using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using OpenCvSharp.Tracking.Legacy;

#pragma warning disable 1591
#pragma warning disable CA1401 // P/Invokes should not be visible

// ReSharper disable UnusedMember.Global
// ReSharper disable IdentifierTypo
// ReSharper disable CommentTypo

namespace OpenCvSharp.Internal;

static partial class NativeMethods
{
    // legacy::Tracker (base init/update)

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus tracking_legacy_Tracker_init(IntPtr tracker, IntPtr image, Rect2d boundingBox, out int returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus tracking_legacy_Tracker_update(IntPtr tracker, IntPtr image, ref Rect2d boundingBox, out int returnValue);


    // legacy::TrackerMIL

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus tracking_legacy_TrackerMIL_create1(out IntPtr returnValue);

    // Fully-qualified: OpenCvSharp.TrackerMIL (the modern, video-module tracker) is visible here
    // without a `using` via the OpenCvSharp.Internal -> OpenCvSharp outer-scope rule, and that
    // outer-scope visibility wins over the `using OpenCvSharp.Tracking.Legacy;` import above for the
    // unqualified name "TrackerMIL" - so the Legacy one needs an explicit qualifier here.
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus tracking_legacy_TrackerMIL_create2(ref OpenCvSharp.Tracking.Legacy.TrackerMIL.Params parameters, out IntPtr returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus tracking_legacy_Ptr_TrackerMIL_delete(IntPtr ptr);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus tracking_legacy_Ptr_TrackerMIL_get(IntPtr ptr, out IntPtr returnValue);


    // legacy::TrackerBoosting

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus tracking_legacy_TrackerBoosting_create1(out IntPtr returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus tracking_legacy_TrackerBoosting_create2(ref TrackerBoosting.Params parameters, out IntPtr returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus tracking_legacy_Ptr_TrackerBoosting_delete(IntPtr ptr);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus tracking_legacy_Ptr_TrackerBoosting_get(IntPtr ptr, out IntPtr returnValue);


    // legacy::TrackerMedianFlow

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus tracking_legacy_TrackerMedianFlow_create1(out IntPtr returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus tracking_legacy_TrackerMedianFlow_create2(ref TrackerMedianFlow.Params parameters, out IntPtr returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus tracking_legacy_Ptr_TrackerMedianFlow_delete(IntPtr ptr);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus tracking_legacy_Ptr_TrackerMedianFlow_get(IntPtr ptr, out IntPtr returnValue);


    // legacy::TrackerTLD (no Params overload - see TrackerTLD.cs)

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus tracking_legacy_TrackerTLD_create1(out IntPtr returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus tracking_legacy_Ptr_TrackerTLD_delete(IntPtr ptr);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus tracking_legacy_Ptr_TrackerTLD_get(IntPtr ptr, out IntPtr returnValue);


    // legacy::TrackerKCF

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus tracking_legacy_TrackerKCF_create1(out IntPtr returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus tracking_legacy_TrackerKCF_create2(ref TrackerKCF.Params parameters, out IntPtr returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus tracking_legacy_Ptr_TrackerKCF_delete(IntPtr ptr);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus tracking_legacy_Ptr_TrackerKCF_get(IntPtr ptr, out IntPtr returnValue);


    // legacy::TrackerMOSSE (no Params struct exists for this tracker)

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus tracking_legacy_TrackerMOSSE_create1(out IntPtr returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus tracking_legacy_Ptr_TrackerMOSSE_delete(IntPtr ptr);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus tracking_legacy_Ptr_TrackerMOSSE_get(IntPtr ptr, out IntPtr returnValue);


    // legacy::TrackerCSRT

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus tracking_legacy_TrackerCSRT_create1(out IntPtr returnValue);

    // WLegacyTrackerCSRTParams is the blittable mirror of native tracker_legacy_TrackerCSRT_Params
    // (window_function as a char*). The managed-friendly TrackerCSRT.Params is converted into it
    // (with the string marshalled) in TrackerCSRT.Create.
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus tracking_legacy_TrackerCSRT_create2(ref WLegacyTrackerCSRTParams parameters, out IntPtr returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus tracking_legacy_Ptr_TrackerCSRT_delete(IntPtr ptr);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus tracking_legacy_Ptr_TrackerCSRT_get(IntPtr ptr, out IntPtr returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus tracking_legacy_TrackerCSRT_setInitialMask(IntPtr tracker, in InputArrayProxy mask);


    // legacy::upgradeTrackingAPI

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus tracking_legacy_upgradeTrackingAPI(IntPtr legacyTracker, out IntPtr returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus tracking_legacy_Ptr_UpgradedTracker_delete(IntPtr ptr);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus tracking_legacy_Ptr_UpgradedTracker_get(IntPtr ptr, out IntPtr returnValue);


    // legacy::MultiTracker

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus tracking_legacy_MultiTracker_create(out IntPtr returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus tracking_legacy_Ptr_MultiTracker_delete(IntPtr ptr);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus tracking_legacy_Ptr_MultiTracker_get(IntPtr ptr, out IntPtr returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus tracking_legacy_MultiTracker_add(
        IntPtr obj, IntPtr newTracker, IntPtr image, Rect2d boundingBox, out int returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus tracking_legacy_MultiTracker_update(IntPtr obj, IntPtr image, out int returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus tracking_legacy_MultiTracker_getObjects(IntPtr obj, IntPtr returnValue);


    // legacy::MultiTracker_Alt

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus tracking_legacy_MultiTracker_Alt_new(out IntPtr returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus tracking_legacy_MultiTracker_Alt_delete(IntPtr obj);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus tracking_legacy_MultiTracker_Alt_addTarget(
        OpenCvSafeHandle obj, IntPtr image, Rect2d boundingBox, IntPtr trackerAlgorithm, out int returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus tracking_legacy_MultiTracker_Alt_update(OpenCvSafeHandle obj, IntPtr image, out int returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus tracking_legacy_MultiTracker_Alt_targetNum(OpenCvSafeHandle obj, out int returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus tracking_legacy_MultiTracker_Alt_boundingBoxes(OpenCvSafeHandle obj, IntPtr returnValue);


    // legacy::MultiTrackerTLD

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus tracking_legacy_MultiTrackerTLD_new(out IntPtr returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus tracking_legacy_MultiTrackerTLD_delete(IntPtr obj);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus tracking_legacy_MultiTrackerTLD_updateOpt(OpenCvSafeHandle obj, IntPtr image, out int returnValue);
}
