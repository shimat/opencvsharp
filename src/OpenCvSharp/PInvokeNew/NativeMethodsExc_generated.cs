using System;
using System.Runtime.InteropServices;

#pragma warning disable 1591

namespace OpenCvSharp
{
    static partial class NativeMethodsExc
    {
[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean ximgproc_StructuredEdgeDetection_computeOrientation_excsafe( System.IntPtr obj ,  System.IntPtr src ,  System.IntPtr dst );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean ximgproc_StructuredEdgeDetection_edgesNms_excsafe( System.IntPtr obj ,  System.IntPtr edge_image ,  System.IntPtr orientation_image ,  System.IntPtr dst ,  System.Int32 r ,  System.Int32 s ,  System.Single m ,  System.Int32 isParallel );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean ximgproc_segmentation_createSelectiveSearchSegmentationStrategyMultiple1_excsafe(ref System.IntPtr ret,  System.IntPtr s1 );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean ximgproc_segmentation_createSelectiveSearchSegmentationStrategyMultiple2_excsafe(ref System.IntPtr ret,  System.IntPtr s1 ,  System.IntPtr s2 );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean ximgproc_segmentation_createSelectiveSearchSegmentationStrategyMultiple3_excsafe(ref System.IntPtr ret,  System.IntPtr s1 ,  System.IntPtr s2 ,  System.IntPtr s3 );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean ximgproc_segmentation_createSelectiveSearchSegmentationStrategyMultiple4_excsafe(ref System.IntPtr ret,  System.IntPtr s1 ,  System.IntPtr s2 ,  System.IntPtr s3 ,  System.IntPtr s4 );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean ximgproc_segmentation_Ptr_SelectiveSearchSegmentationStrategyMultiple_delete_excsafe( System.IntPtr obj );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean ximgproc_segmentation_Ptr_SelectiveSearchSegmentationStrategyMultiple_get_excsafe(ref System.IntPtr ret,  System.IntPtr ptr );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean ximgproc_segmentation_SelectiveSearchSegmentation_setBaseImage_excsafe( System.IntPtr obj ,  System.IntPtr img );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean ximgproc_segmentation_SelectiveSearchSegmentation_switchToSingleStrategy_excsafe( System.IntPtr obj ,  System.Int32 k ,  System.Single sigma );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean ximgproc_segmentation_SelectiveSearchSegmentation_switchToSelectiveSearchFast_excsafe( System.IntPtr obj ,  System.Int32 base_k ,  System.Int32 inc_k ,  System.Single sigma );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean ximgproc_segmentation_SelectiveSearchSegmentation_switchToSelectiveSearchQuality_excsafe( System.IntPtr obj ,  System.Int32 base_k ,  System.Int32 inc_k ,  System.Single sigma );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean ximgproc_segmentation_SelectiveSearchSegmentation_addImage_excsafe( System.IntPtr obj ,  System.IntPtr img );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean ximgproc_segmentation_SelectiveSearchSegmentation_clearImages_excsafe( System.IntPtr obj );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean ximgproc_segmentation_SelectiveSearchSegmentation_addGraphSegmentation_excsafe( System.IntPtr obj ,  System.IntPtr g );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean ximgproc_segmentation_SelectiveSearchSegmentation_clearGraphSegmentations_excsafe( System.IntPtr obj );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean ximgproc_segmentation_SelectiveSearchSegmentation_addStrategy_excsafe( System.IntPtr obj ,  System.IntPtr s );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean ximgproc_segmentation_SelectiveSearchSegmentation_clearStrategies_excsafe( System.IntPtr obj );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean ximgproc_segmentation_SelectiveSearchSegmentation_process_excsafe( System.IntPtr obj ,  System.IntPtr rects );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean ximgproc_segmentation_createSelectiveSearchSegmentation_excsafe(ref System.IntPtr ret);

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean ximgproc_segmentation_Ptr_SelectiveSearchSegmentation_delete_excsafe( System.IntPtr obj );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean ximgproc_segmentation_Ptr_SelectiveSearchSegmentation_get_excsafe(ref System.IntPtr ret,  System.IntPtr ptr );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean ximgproc_createRFFeatureGetter_excsafe(ref System.IntPtr ret);

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean ximgproc_Ptr_RFFeatureGetter_delete_excsafe( System.IntPtr obj );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean ximgproc_Ptr_RFFeatureGetter_get_excsafe(ref System.IntPtr ret,  System.IntPtr ptr );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean ximgproc_RFFeatureGetter_getFeatures_excsafe( System.IntPtr obj ,  System.IntPtr src ,  System.IntPtr features ,  System.Int32 gnrmRad ,  System.Int32 gsmthRad ,  System.Int32 shrink ,  System.Int32 outNum ,  System.Int32 gradNum );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean ximgproc_createStructuredEdgeDetection_excsafe(ref System.IntPtr ret, [MarshalAs(UnmanagedType.LPStr)] System.String model ,  System.IntPtr howToGetFeatures );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean ximgproc_Ptr_StructuredEdgeDetection_delete_excsafe( System.IntPtr obj );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean ximgproc_Ptr_StructuredEdgeDetection_get_excsafe(ref System.IntPtr ret,  System.IntPtr ptr );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean ximgproc_StructuredEdgeDetection_detectEdges_excsafe( System.IntPtr obj ,  System.IntPtr src ,  System.IntPtr dst );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean ximgproc_segmentation_createGraphSegmentation_excsafe(ref System.IntPtr ret,  System.Double sigma ,  System.Single k ,  System.Int32 min_size );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean ximgproc_segmentation_Ptr_GraphSegmentation_delete_excsafe( System.IntPtr obj );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean ximgproc_segmentation_Ptr_GraphSegmentation_get_excsafe(ref System.IntPtr ret,  System.IntPtr ptr );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean ximgproc_segmentation_GraphSegmentation_processImage_excsafe( System.IntPtr obj ,  System.IntPtr src ,  System.IntPtr dst );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean ximgproc_segmentation_GraphSegmentation_setSigma_excsafe( System.IntPtr obj ,  System.Double value );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean ximgproc_segmentation_GraphSegmentation_getSigma_excsafe(ref System.Double ret,  System.IntPtr obj );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean ximgproc_segmentation_GraphSegmentation_setK_excsafe( System.IntPtr obj ,  System.Single value );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean ximgproc_segmentation_GraphSegmentation_getK_excsafe(ref System.Single ret,  System.IntPtr obj );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean ximgproc_segmentation_GraphSegmentation_setMinSize_excsafe( System.IntPtr obj ,  System.Int32 value );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean ximgproc_segmentation_GraphSegmentation_getMinSize_excsafe(ref System.Int32 ret,  System.IntPtr obj );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean ximgproc_segmentation_SelectiveSearchSegmentationStrategy_setImage_excsafe( System.IntPtr obj ,  System.IntPtr img ,  System.IntPtr regions ,  System.IntPtr sizes ,  System.Int32 image_id );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean ximgproc_segmentation_SelectiveSearchSegmentationStrategy_get_excsafe(ref System.Single ret,  System.IntPtr obj ,  System.Int32 r1 ,  System.Int32 r2 );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean ximgproc_segmentation_SelectiveSearchSegmentationStrategy_merge_excsafe( System.IntPtr obj ,  System.Int32 r1 ,  System.Int32 r2 );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean ximgproc_segmentation_createSelectiveSearchSegmentationStrategyColor_excsafe(ref System.IntPtr ret);

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean ximgproc_segmentation_createSelectiveSearchSegmentationStrategySize_excsafe(ref System.IntPtr ret);

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean ximgproc_segmentation_createSelectiveSearchSegmentationStrategyTexture_excsafe(ref System.IntPtr ret);

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean ximgproc_segmentation_createSelectiveSearchSegmentationStrategyFill_excsafe(ref System.IntPtr ret);

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean ximgproc_segmentation_Ptr_SelectiveSearchSegmentationStrategyColor_delete_excsafe( System.IntPtr obj );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean ximgproc_segmentation_Ptr_SelectiveSearchSegmentationStrategySize_delete_excsafe( System.IntPtr obj );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean ximgproc_segmentation_Ptr_SelectiveSearchSegmentationStrategyTexture_delete_excsafe( System.IntPtr obj );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean ximgproc_segmentation_Ptr_SelectiveSearchSegmentationStrategyFill_delete_excsafe( System.IntPtr obj );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean ximgproc_segmentation_Ptr_SelectiveSearchSegmentationStrategyColor_get_excsafe(ref System.IntPtr ret,  System.IntPtr ptr );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean ximgproc_segmentation_Ptr_SelectiveSearchSegmentationStrategySize_get_excsafe(ref System.IntPtr ret,  System.IntPtr ptr );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean ximgproc_segmentation_Ptr_SelectiveSearchSegmentationStrategyTexture_get_excsafe(ref System.IntPtr ret,  System.IntPtr ptr );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean ximgproc_segmentation_Ptr_SelectiveSearchSegmentationStrategyFill_get_excsafe(ref System.IntPtr ret,  System.IntPtr ptr );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean ximgproc_segmentation_SelectiveSearchSegmentationStrategyMultiple_addStrategy_excsafe( System.IntPtr obj ,  System.IntPtr g ,  System.Single weight );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean ximgproc_segmentation_SelectiveSearchSegmentationStrategyMultiple_clearStrategies_excsafe( System.IntPtr obj );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean ximgproc_segmentation_createSelectiveSearchSegmentationStrategyMultiple0_excsafe(ref System.IntPtr ret);

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean ximgproc_EdgeBoxes_getMaxBoxes_excsafe(ref System.Int32 ret,  System.IntPtr obj );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean ximgproc_EdgeBoxes_setMaxBoxes_excsafe( System.IntPtr obj ,  System.Int32 value );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean ximgproc_EdgeBoxes_getEdgeMinMag_excsafe(ref System.Single ret,  System.IntPtr obj );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean ximgproc_EdgeBoxes_setEdgeMinMag_excsafe( System.IntPtr obj ,  System.Single value );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean ximgproc_EdgeBoxes_getEdgeMergeThr_excsafe(ref System.Single ret,  System.IntPtr obj );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean ximgproc_EdgeBoxes_setEdgeMergeThr_excsafe( System.IntPtr obj ,  System.Single value );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean ximgproc_EdgeBoxes_getClusterMinMag_excsafe(ref System.Single ret,  System.IntPtr obj );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean ximgproc_EdgeBoxes_setClusterMinMag_excsafe( System.IntPtr obj ,  System.Single value );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean ximgproc_EdgeBoxes_getMaxAspectRatio_excsafe(ref System.Single ret,  System.IntPtr obj );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean ximgproc_EdgeBoxes_setMaxAspectRatio_excsafe( System.IntPtr obj ,  System.Single value );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean ximgproc_EdgeBoxes_getMinBoxArea_excsafe(ref System.Single ret,  System.IntPtr obj );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean ximgproc_EdgeBoxes_setMinBoxArea_excsafe( System.IntPtr obj ,  System.Single value );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean ximgproc_EdgeBoxes_getGamma_excsafe(ref System.Single ret,  System.IntPtr obj );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean ximgproc_EdgeBoxes_setGamma_excsafe( System.IntPtr obj ,  System.Single value );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean ximgproc_EdgeBoxes_getKappa_excsafe(ref System.Single ret,  System.IntPtr obj );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean ximgproc_EdgeBoxes_setKappa_excsafe( System.IntPtr obj ,  System.Single value );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean ximgproc_createEdgeBoxes_excsafe(ref System.IntPtr ret,  System.Single alpha ,  System.Single beta ,  System.Single eta ,  System.Single minScore ,  System.Int32 maxBoxes ,  System.Single edgeMinMag ,  System.Single edgeMergeThr ,  System.Single clusterMinMag ,  System.Single maxAspectRatio ,  System.Single minBoxArea ,  System.Single gamma ,  System.Single kappa );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean ximgproc_Ptr_EdgeBoxes_delete_excsafe( System.IntPtr obj );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean ximgproc_Ptr_EdgeBoxes_get_excsafe(ref System.IntPtr ret,  System.IntPtr ptr );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean ximgproc_FastHoughTransform_excsafe( System.IntPtr src ,  System.IntPtr dst ,  System.Int32 dstMatDepth ,  System.Int32 angleRange ,  System.Int32 op ,  System.Int32 makeSkew );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean ximgproc_HoughPoint2Line_excsafe(ref OpenCvSharp.Vec4i ret,  OpenCvSharp.Point houghPoint ,  System.IntPtr srcImgInfo ,  System.Int32 angleRange ,  System.Int32 makeSkew ,  System.Int32 rules );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean ximgproc_FastLineDetector_delete_excsafe( System.IntPtr obj );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean ximgproc_Ptr_FastLineDetector_get_excsafe(ref System.IntPtr ret,  System.IntPtr ptr );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean ximgproc_FastLineDetector_detect_OutputArray_excsafe( System.IntPtr obj ,  System.IntPtr image ,  System.IntPtr lines );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean ximgproc_FastLineDetector_detect_vector_excsafe( System.IntPtr obj ,  System.IntPtr image ,  System.IntPtr lines );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean ximgproc_FastLineDetector_drawSegments_InputArray_excsafe( System.IntPtr obj ,  System.IntPtr image ,  System.IntPtr lines ,  System.Int32 draw_arrow );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean ximgproc_FastLineDetector_drawSegments_vector_excsafe( System.IntPtr obj ,  System.IntPtr image ,  System.IntPtr lines ,  System.Int32 draw_arrow );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean ximgproc_createFastLineDetector_excsafe(ref System.IntPtr ret,  System.Int32 length_threshold ,  System.Single distance_threshold ,  System.Double canny_th1 ,  System.Double canny_th2 ,  System.Int32 canny_aperture_size ,  System.Int32 do_merge );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean video_BackgroundSubtractorKNN_getHistory_excsafe(ref System.Int32 ret,  System.IntPtr ptr );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean video_BackgroundSubtractorKNN_setHistory_excsafe( System.IntPtr ptr ,  System.Int32 value );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean video_BackgroundSubtractorKNN_getNSamples_excsafe(ref System.Int32 ret,  System.IntPtr ptr );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean video_BackgroundSubtractorKNN_setNSamples_excsafe( System.IntPtr ptr ,  System.Int32 value );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean video_BackgroundSubtractorKNN_getDist2Threshold_excsafe(ref System.Int32 ret,  System.IntPtr ptr );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean video_BackgroundSubtractorKNN_setDist2Threshold_excsafe( System.IntPtr ptr ,  System.Double value );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean video_BackgroundSubtractorKNN_getkNNSamples_excsafe(ref System.Int32 ret,  System.IntPtr ptr );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean video_BackgroundSubtractorKNN_setkNNSamples_excsafe( System.IntPtr ptr ,  System.Int32 value );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean video_BackgroundSubtractorKNN_getDetectShadows_excsafe(ref System.Int32 ret,  System.IntPtr ptr );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean video_BackgroundSubtractorKNN_setDetectShadows_excsafe( System.IntPtr ptr ,  System.Int32 value );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean video_BackgroundSubtractorKNN_getShadowValue_excsafe(ref System.Int32 ret,  System.IntPtr ptr );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean video_BackgroundSubtractorKNN_setShadowValue_excsafe( System.IntPtr ptr ,  System.Int32 value );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean video_BackgroundSubtractorKNN_getShadowThreshold_excsafe(ref System.Double ret,  System.IntPtr ptr );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean video_BackgroundSubtractorKNN_setShadowThreshold_excsafe( System.IntPtr ptr ,  System.Double value );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean ximgproc_niBlackThreshold_excsafe( System.IntPtr src ,  System.IntPtr dst ,  System.Double maxValue ,  System.Int32 type ,  System.Int32 blockSize ,  System.Double delta );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean ximgproc_thinning_excsafe( System.IntPtr src ,  System.IntPtr dst ,  System.Int32 thinningType );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean ximgproc_anisotropicDiffusion_excsafe( System.IntPtr src ,  System.IntPtr dst ,  System.Single alpha ,  System.Single K ,  System.Int32 niters );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean ximgproc_weightedMedianFilter_excsafe( System.IntPtr joint ,  System.IntPtr src ,  System.IntPtr dst ,  System.Int32 r ,  System.Double sigma ,  System.Int32 weightType ,  System.IntPtr mask );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean ximgproc_covarianceEstimation_excsafe( System.IntPtr src ,  System.IntPtr dst ,  System.Int32 windowRows ,  System.Int32 windowCols );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean ximgproc_EdgeBoxes_getBoundingBoxes_excsafe( System.IntPtr obj ,  System.IntPtr edge_map ,  System.IntPtr orientation_map ,  System.IntPtr boxes );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean ximgproc_EdgeBoxes_getAlpha_excsafe(ref System.Single ret,  System.IntPtr obj );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean ximgproc_EdgeBoxes_setAlpha_excsafe( System.IntPtr obj ,  System.Single value );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean ximgproc_EdgeBoxes_getBeta_excsafe(ref System.Single ret,  System.IntPtr obj );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean ximgproc_EdgeBoxes_setBeta_excsafe( System.IntPtr obj ,  System.Single value );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean ximgproc_EdgeBoxes_getEta_excsafe(ref System.Single ret,  System.IntPtr obj );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean ximgproc_EdgeBoxes_setEta_excsafe( System.IntPtr obj ,  System.Single value );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean ximgproc_EdgeBoxes_getMinScore_excsafe(ref System.Single ret,  System.IntPtr obj );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean ximgproc_EdgeBoxes_setMinScore_excsafe( System.IntPtr obj ,  System.Single value );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean video_Ptr_BackgroundSubtractorMOG2_get_excsafe(ref System.IntPtr ret,  System.IntPtr ptr );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean video_BackgroundSubtractorMOG2_getHistory_excsafe(ref System.Int32 ret,  System.IntPtr ptr );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean video_BackgroundSubtractorMOG2_setHistory_excsafe( System.IntPtr ptr ,  System.Int32 value );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean video_BackgroundSubtractorMOG2_getNMixtures_excsafe(ref System.Int32 ret,  System.IntPtr ptr );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean video_BackgroundSubtractorMOG2_setNMixtures_excsafe( System.IntPtr ptr ,  System.Int32 value );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean video_BackgroundSubtractorMOG2_getBackgroundRatio_excsafe(ref System.Double ret,  System.IntPtr ptr );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean video_BackgroundSubtractorMOG2_setBackgroundRatio_excsafe( System.IntPtr ptr ,  System.Double value );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean video_BackgroundSubtractorMOG2_getVarThreshold_excsafe(ref System.Double ret,  System.IntPtr ptr );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean video_BackgroundSubtractorMOG2_setVarThreshold_excsafe( System.IntPtr ptr ,  System.Double value );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean video_BackgroundSubtractorMOG2_getVarThresholdGen_excsafe(ref System.Double ret,  System.IntPtr ptr );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean video_BackgroundSubtractorMOG2_setVarThresholdGen_excsafe( System.IntPtr ptr ,  System.Double value );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean video_BackgroundSubtractorMOG2_getVarInit_excsafe(ref System.Double ret,  System.IntPtr ptr );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean video_BackgroundSubtractorMOG2_setVarInit_excsafe( System.IntPtr ptr ,  System.Double value );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean video_BackgroundSubtractorMOG2_getVarMin_excsafe(ref System.Double ret,  System.IntPtr ptr );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean video_BackgroundSubtractorMOG2_setVarMin_excsafe( System.IntPtr ptr ,  System.Double value );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean video_BackgroundSubtractorMOG2_getVarMax_excsafe(ref System.Double ret,  System.IntPtr ptr );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean video_BackgroundSubtractorMOG2_setVarMax_excsafe( System.IntPtr ptr ,  System.Double value );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean video_BackgroundSubtractorMOG2_getComplexityReductionThreshold_excsafe(ref System.Double ret,  System.IntPtr ptr );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean video_BackgroundSubtractorMOG2_setComplexityReductionThreshold_excsafe( System.IntPtr ptr ,  System.Double value );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean video_BackgroundSubtractorMOG2_getDetectShadows_excsafe(ref System.Int32 ret,  System.IntPtr ptr );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean video_BackgroundSubtractorMOG2_setDetectShadows_excsafe( System.IntPtr ptr ,  System.Int32 value );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean video_BackgroundSubtractorMOG2_getShadowValue_excsafe(ref System.Int32 ret,  System.IntPtr ptr );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean video_BackgroundSubtractorMOG2_setShadowValue_excsafe( System.IntPtr ptr ,  System.Int32 value );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean video_BackgroundSubtractorMOG2_getShadowThreshold_excsafe(ref System.Double ret,  System.IntPtr ptr );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean video_BackgroundSubtractorMOG2_setShadowThreshold_excsafe( System.IntPtr ptr ,  System.Double value );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean video_createBackgroundSubtractorKNN_excsafe(ref System.IntPtr ret,  System.Int32 history ,  System.Double dist2Threshold ,  System.Int32 detectShadows );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean video_Ptr_BackgroundSubtractorKNN_delete_excsafe( System.IntPtr obj );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean video_Ptr_BackgroundSubtractorKNN_get_excsafe(ref System.IntPtr ret,  System.IntPtr ptr );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean video_KalmanFilter_correct_excsafe(ref System.IntPtr ret,  System.IntPtr obj ,  System.IntPtr measurement );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean video_KalmanFilter_statePre_excsafe(ref System.IntPtr ret,  System.IntPtr obj );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean video_KalmanFilter_statePost_excsafe(ref System.IntPtr ret,  System.IntPtr obj );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean video_KalmanFilter_transitionMatrix_excsafe(ref System.IntPtr ret,  System.IntPtr obj );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean video_KalmanFilter_controlMatrix_excsafe(ref System.IntPtr ret,  System.IntPtr obj );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean video_KalmanFilter_measurementMatrix_excsafe(ref System.IntPtr ret,  System.IntPtr obj );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean video_KalmanFilter_processNoiseCov_excsafe(ref System.IntPtr ret,  System.IntPtr obj );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean video_KalmanFilter_measurementNoiseCov_excsafe(ref System.IntPtr ret,  System.IntPtr obj );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean video_KalmanFilter_errorCovPre_excsafe(ref System.IntPtr ret,  System.IntPtr obj );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean video_KalmanFilter_gain_excsafe(ref System.IntPtr ret,  System.IntPtr obj );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean video_KalmanFilter_errorCovPost_excsafe(ref System.IntPtr ret,  System.IntPtr obj );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean video_buildOpticalFlowPyramid1_excsafe(ref System.Int32 ret,  System.IntPtr img ,  System.IntPtr pyramid ,  OpenCvSharp.Size winSize ,  System.Int32 maxLevel ,  System.Int32 withDerivatives ,  System.Int32 pyrBorder ,  System.Int32 derivBorder ,  System.Int32 tryReuseInputImage );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean video_buildOpticalFlowPyramid2_excsafe(ref System.Int32 ret,  System.IntPtr img ,  System.IntPtr pyramidVec ,  OpenCvSharp.Size winSize ,  System.Int32 maxLevel ,  System.Int32 withDerivatives ,  System.Int32 pyrBorder ,  System.Int32 derivBorder ,  System.Int32 tryReuseInputImage );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean video_calcOpticalFlowPyrLK_InputArray_excsafe( System.IntPtr prevImg ,  System.IntPtr nextImg ,  System.IntPtr prevPts ,  System.IntPtr nextPts ,  System.IntPtr status ,  System.IntPtr err ,  OpenCvSharp.Size winSize ,  System.Int32 maxLevel ,  OpenCvSharp.TermCriteria criteria ,  System.Int32 flags ,  System.Double minEigThreshold );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean video_calcOpticalFlowPyrLK_vector_excsafe( System.IntPtr prevImg ,  System.IntPtr nextImg ,  OpenCvSharp.Point2f[] prevPts ,  System.Int32 prevPtsSize ,  System.IntPtr nextPts ,  System.IntPtr status ,  System.IntPtr err ,  OpenCvSharp.Size winSize ,  System.Int32 maxLevel ,  OpenCvSharp.TermCriteria criteria ,  System.Int32 flags ,  System.Double minEigThreshold );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean video_calcOpticalFlowFarneback_excsafe( System.IntPtr prev ,  System.IntPtr next ,  System.IntPtr flow ,  System.Double pyrScale ,  System.Int32 levels ,  System.Int32 winSize ,  System.Int32 iterations ,  System.Int32 polyN ,  System.Double polySigma ,  System.Int32 flags );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean video_estimateRigidTransform_excsafe(ref System.IntPtr ret,  System.IntPtr src ,  System.IntPtr dst ,  System.Int32 fullAffine );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean video_DenseOpticalFlow_calc_excsafe( System.IntPtr obj ,  System.IntPtr i0 ,  System.IntPtr i1 ,  System.IntPtr flow );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean video_DenseOpticalFlow_collectGarbage_excsafe( System.IntPtr obj );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean video_createOptFlow_DualTVL1_excsafe(ref System.IntPtr ret);

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean video_Ptr_DenseOpticalFlow_get_excsafe(ref System.IntPtr ret,  System.IntPtr ptr );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean video_Ptr_DenseOpticalFlow_delete_excsafe( System.IntPtr ptr );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean video_BackgroundSubtractor_getBackgroundImage_excsafe( System.IntPtr self ,  System.IntPtr backgroundImage );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean video_BackgroundSubtractor_apply_excsafe( System.IntPtr self ,  System.IntPtr image ,  System.IntPtr fgmask ,  System.Double learningRate );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean video_Ptr_BackgroundSubtractor_delete_excsafe( System.IntPtr ptr );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean video_Ptr_BackgroundSubtractor_get_excsafe(ref System.IntPtr ret,  System.IntPtr ptr );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean video_createBackgroundSubtractorMOG2_excsafe(ref System.IntPtr ret,  System.Int32 history ,  System.Double varThreshold ,  System.Int32 detectShadows );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean video_Ptr_BackgroundSubtractorMOG2_delete_excsafe( System.IntPtr ptr );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean tracking_Ptr_TrackerMedianFlow_delete_excsafe( System.IntPtr ptr );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean tracking_Ptr_TrackerMedianFlow_get_excsafe(ref System.IntPtr ret,  System.IntPtr ptr );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean tracking_TrackerTLD_create1_excsafe(ref System.IntPtr ret);

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern unsafe System.Boolean tracking_TrackerTLD_create2_excsafe(ref System.IntPtr ret,  OpenCvSharp.Tracking.TrackerTLD.Params* parameters );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean tracking_Ptr_TrackerTLD_delete_excsafe( System.IntPtr ptr );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean tracking_Ptr_TrackerTLD_get_excsafe(ref System.IntPtr ret,  System.IntPtr ptr );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean tracking_TrackerGOTURN_create1_excsafe(ref System.IntPtr ret);

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern unsafe System.Boolean tracking_TrackerGOTURN_create2_excsafe(ref System.IntPtr ret,  OpenCvSharp.Tracking.TrackerGOTURN.Params* parameters );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean tracking_Ptr_TrackerGOTURN_delete_excsafe( System.IntPtr ptr );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean tracking_Ptr_TrackerGOTURN_get_excsafe(ref System.IntPtr ret,  System.IntPtr ptr );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean tracking_TrackerMOSSE_create_excsafe(ref System.IntPtr ret);

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean tracking_Ptr_TrackerMOSSE_delete_excsafe( System.IntPtr ptr );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean tracking_Ptr_TrackerMOSSE_get_excsafe(ref System.IntPtr ret,  System.IntPtr ptr );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean tracking_MultiTracker_create_excsafe(ref System.IntPtr ret);

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean tracking_Ptr_MultiTracker_delete_excsafe( System.IntPtr ptr );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean tracking_Ptr_MultiTracker_get_excsafe(ref System.IntPtr ret,  System.IntPtr ptr );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean tracking_MultiTracker_add1_excsafe(ref System.Int32 ret,  System.IntPtr obj ,  System.IntPtr newTracker ,  System.IntPtr image ,  OpenCvSharp.Rect2d boundingBox );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean tracking_MultiTracker_add2_excsafe(ref System.Int32 ret,  System.IntPtr obj ,  System.IntPtr[] newTrackers ,  System.Int32 newTrackersLength ,  System.IntPtr image ,  OpenCvSharp.Rect2d[] boundingBox ,  System.Int32 boundingBoxLength );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean tracking_MultiTracker_update1_excsafe(ref System.Int32 ret,  System.IntPtr obj ,  System.IntPtr image );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean tracking_MultiTracker_update2_excsafe(ref System.Int32 ret,  System.IntPtr obj ,  System.IntPtr image ,  System.IntPtr boundingBox );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean tracking_MultiTracker_getObjects_excsafe( System.IntPtr obj ,  System.IntPtr boundingBox );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean video_CamShift_excsafe(ref OpenCvSharp.RotatedRect ret,  System.IntPtr probImage ,  ref OpenCvSharp.Rect window ,  OpenCvSharp.TermCriteria criteria );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean video_meanShift_excsafe(ref System.Int32 ret,  System.IntPtr probImage ,  ref OpenCvSharp.Rect window ,  OpenCvSharp.TermCriteria criteria );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean video_KalmanFilter_new1_excsafe(ref System.IntPtr ret);

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean video_KalmanFilter_new2_excsafe(ref System.IntPtr ret,  System.Int32 dynamParams ,  System.Int32 measureParams ,  System.Int32 controlParams ,  System.Int32 type );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean video_KalmanFilter_init_excsafe( System.IntPtr obj ,  System.Int32 dynamParams ,  System.Int32 measureParams ,  System.Int32 controlParams ,  System.Int32 type );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean video_KalmanFilter_delete_excsafe( System.IntPtr obj );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean video_KalmanFilter_predict_excsafe(ref System.IntPtr ret,  System.IntPtr obj ,  System.IntPtr control );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean shape_ShapeContextDistanceExtractor_setStdDev_excsafe( System.IntPtr obj ,  System.Single val );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean shape_ShapeContextDistanceExtractor_getStdDev_excsafe(ref System.Single ret,  System.IntPtr obj );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean shape_createShapeContextDistanceExtractor_excsafe(ref System.IntPtr ret,  System.Int32 nAngularBins ,  System.Int32 nRadialBins ,  System.Single innerRadius ,  System.Single outerRadius ,  System.Int32 iterations );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean shape_Ptr_HausdorffDistanceExtractor_delete_excsafe( System.IntPtr obj );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean shape_Ptr_HausdorffDistanceExtractor_get_excsafe(ref System.IntPtr ret,  System.IntPtr obj );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean shape_HausdorffDistanceExtractor_setDistanceFlag_excsafe( System.IntPtr obj ,  System.Int32 val );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean shape_HausdorffDistanceExtractor_getDistanceFlag_excsafe(ref System.Int32 ret,  System.IntPtr obj );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean shape_HausdorffDistanceExtractor_setRankProportion_excsafe( System.IntPtr obj ,  System.Single val );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean shape_HausdorffDistanceExtractor_getRankProportion_excsafe(ref System.Single ret,  System.IntPtr obj );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean shape_createHausdorffDistanceExtractor_excsafe(ref System.IntPtr ret,  System.Int32 distanceFlag ,  System.Single rankProp );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean tracking_Tracker_init_excsafe(ref System.Boolean ret,  System.IntPtr obj ,  System.IntPtr image ,  OpenCvSharp.Rect2d boundingBox );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean tracking_Tracker_update_excsafe(ref System.Boolean ret,  System.IntPtr obj ,  System.IntPtr image ,  ref OpenCvSharp.Rect2d boundingBox );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean tracking_Ptr_Tracker_delete_excsafe( System.IntPtr ptr );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean tracking_Ptr_Tracker_get_excsafe(ref System.IntPtr ret,  System.IntPtr ptr );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean tracking_TrackerKCF_create1_excsafe(ref System.IntPtr ret);

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean tracking_TrackerKCF_create2_excsafe(ref System.IntPtr ret,  OpenCvSharp.Tracking.TrackerKCF.Params parameters );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean tracking_Ptr_TrackerKCF_delete_excsafe( System.IntPtr ptr );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean tracking_Ptr_TrackerKCF_get_excsafe(ref System.IntPtr ret,  System.IntPtr ptr );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean tracking_TrackerMIL_create1_excsafe(ref System.IntPtr ret);

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern unsafe System.Boolean tracking_TrackerMIL_create2_excsafe(ref System.IntPtr ret,  OpenCvSharp.Tracking.TrackerMIL.Params* parameters );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean tracking_Ptr_TrackerMIL_delete_excsafe( System.IntPtr ptr );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean tracking_Ptr_TrackerMIL_get_excsafe(ref System.IntPtr ret,  System.IntPtr ptr );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean tracking_TrackerBoosting_create1_excsafe(ref System.IntPtr ret);

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern unsafe System.Boolean tracking_TrackerBoosting_create2_excsafe(ref System.IntPtr ret,  OpenCvSharp.Tracking.TrackerBoosting.Params* parameters );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean tracking_Ptr_TrackerBoosting_delete_excsafe( System.IntPtr ptr );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean tracking_Ptr_TrackerBoosting_get_excsafe(ref System.IntPtr ret,  System.IntPtr ptr );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean tracking_TrackerMedianFlow_create1_excsafe(ref System.IntPtr ret);

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern unsafe System.Boolean tracking_TrackerMedianFlow_create2_excsafe(ref System.IntPtr ret,  OpenCvSharp.Tracking.TrackerMedianFlow.Params* parameters );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean photo_Ptr_CalibrateDebevec_delete_excsafe( System.IntPtr obj );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean photo_Ptr_CalibrateRobertson_delete_excsafe( System.IntPtr obj );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean photo_Ptr_CalibrateDebevec_get_excsafe(ref System.IntPtr ret,  System.IntPtr obj );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean photo_Ptr_CalibrateRobertson_get_excsafe(ref System.IntPtr ret,  System.IntPtr obj );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean photo_CalibrateCRF_process_excsafe( System.IntPtr obj ,  System.IntPtr[] srcImgs ,  System.Int32 srcImgsLength ,  System.IntPtr dst , [In, MarshalAs(UnmanagedType.LPArray)] System.Single[] times );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean shape_ShapeDistanceExtractor_computeDistance_excsafe(ref System.Single ret,  System.IntPtr obj ,  System.IntPtr contour1 ,  System.IntPtr contour2 );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean shape_Ptr_ShapeContextDistanceExtractor_delete_excsafe( System.IntPtr obj );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean shape_Ptr_ShapeContextDistanceExtractor_get_excsafe(ref System.IntPtr ret,  System.IntPtr obj );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean shape_ShapeContextDistanceExtractor_setAngularBins_excsafe( System.IntPtr obj ,  System.Int32 val );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean shape_ShapeContextDistanceExtractor_getAngularBins_excsafe(ref System.Int32 ret,  System.IntPtr obj );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean shape_ShapeContextDistanceExtractor_setRadialBins_excsafe( System.IntPtr obj ,  System.Int32 val );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean shape_ShapeContextDistanceExtractor_getRadialBins_excsafe(ref System.Int32 ret,  System.IntPtr obj );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean shape_ShapeContextDistanceExtractor_setInnerRadius_excsafe( System.IntPtr obj ,  System.Single val );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean shape_ShapeContextDistanceExtractor_getInnerRadius_excsafe(ref System.Single ret,  System.IntPtr obj );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean shape_ShapeContextDistanceExtractor_setOuterRadius_excsafe( System.IntPtr obj ,  System.Single val );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean shape_ShapeContextDistanceExtractor_getOuterRadius_excsafe(ref System.Single ret,  System.IntPtr obj );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean shape_ShapeContextDistanceExtractor_setRotationInvariant_excsafe( System.IntPtr obj ,  System.Int32 val );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean shape_ShapeContextDistanceExtractor_getRotationInvariant_excsafe(ref System.Int32 ret,  System.IntPtr obj );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean shape_ShapeContextDistanceExtractor_setShapeContextWeight_excsafe( System.IntPtr obj ,  System.Single val );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean shape_ShapeContextDistanceExtractor_getShapeContextWeight_excsafe(ref System.Single ret,  System.IntPtr obj );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean shape_ShapeContextDistanceExtractor_setImageAppearanceWeight_excsafe( System.IntPtr obj ,  System.Single val );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean shape_ShapeContextDistanceExtractor_getImageAppearanceWeight_excsafe(ref System.Single ret,  System.IntPtr obj );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean shape_ShapeContextDistanceExtractor_setBendingEnergyWeight_excsafe( System.IntPtr obj ,  System.Single val );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean shape_ShapeContextDistanceExtractor_getBendingEnergyWeight_excsafe(ref System.Single ret,  System.IntPtr obj );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean shape_ShapeContextDistanceExtractor_setImages_excsafe( System.IntPtr obj ,  System.IntPtr image1 ,  System.IntPtr image2 );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean shape_ShapeContextDistanceExtractor_getImages_excsafe( System.IntPtr obj ,  System.IntPtr image1 ,  System.IntPtr image2 );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean shape_ShapeContextDistanceExtractor_setIterations_excsafe( System.IntPtr obj ,  System.Int32 val );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean shape_ShapeContextDistanceExtractor_getIterations_excsafe(ref System.Int32 ret,  System.IntPtr obj );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean xphoto_SimpleWB_InputMin_get_excsafe(ref System.Single ret,  System.IntPtr prt );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean xphoto_SimpleWB_InputMin_set_excsafe(ref System.Single ret,  System.IntPtr prt ,  System.Single value );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean xphoto_SimpleWB_OutputMax_get_excsafe(ref System.Single ret,  System.IntPtr prt );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean xphoto_SimpleWB_OutputMax_set_excsafe(ref System.Single ret,  System.IntPtr prt ,  System.Single value );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean xphoto_SimpleWB_OutputMin_get_excsafe(ref System.Single ret,  System.IntPtr prt );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean xphoto_SimpleWB_OutputMin_set_excsafe(ref System.Single ret,  System.IntPtr prt ,  System.Single value );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean xphoto_SimpleWB_P_get_excsafe(ref System.Single ret,  System.IntPtr prt );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean xphoto_SimpleWB_P_set_excsafe(ref System.Single ret,  System.IntPtr prt ,  System.Single value );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean xphoto_dctDenoising_excsafe( System.IntPtr src ,  System.IntPtr dst ,  System.Double sigma ,  System.Int32 psize );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean xphoto_bm3dDenoising1_excsafe( System.IntPtr src ,  System.IntPtr dstStep1 ,  System.IntPtr dstStep2 ,  System.Single h ,  System.Int32 templateWindowSize ,  System.Int32 searchWindowSize ,  System.Int32 blockMatchingStep1 ,  System.Int32 blockMatchingStep2 ,  System.Int32 groupSize ,  System.Int32 slidingStep ,  System.Single beta ,  System.Int32 normType ,  System.Int32 step ,  System.Int32 transformType );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean xphoto_bm3dDenoising2_excsafe( System.IntPtr src ,  System.IntPtr dst ,  System.Single h ,  System.Int32 templateWindowSize ,  System.Int32 searchWindowSize ,  System.Int32 blockMatchingStep1 ,  System.Int32 blockMatchingStep2 ,  System.Int32 groupSize ,  System.Int32 slidingStep ,  System.Single beta ,  System.Int32 normType ,  System.Int32 step ,  System.Int32 transformType );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean photo_inpaint_excsafe( System.IntPtr src ,  System.IntPtr inpaintMask ,  System.IntPtr dst ,  System.Double inpaintRadius ,  System.Int32 flags );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean photo_fastNlMeansDenoising_excsafe( System.IntPtr src ,  System.IntPtr dst ,  System.Single h ,  System.Int32 templateWindowSize ,  System.Int32 searchWindowSize );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean photo_fastNlMeansDenoisingColored_excsafe( System.IntPtr src ,  System.IntPtr dst ,  System.Single h ,  System.Single hColor ,  System.Int32 templateWindowSize ,  System.Int32 searchWindowSize );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean photo_fastNlMeansDenoisingMulti_excsafe( System.IntPtr[] srcImgs ,  System.Int32 srcImgsLength ,  System.IntPtr dst ,  System.Int32 imgToDenoiseIndex ,  System.Int32 temporalWindowSize ,  System.Single h ,  System.Int32 templateWindowSize ,  System.Int32 searchWindowSize );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean photo_fastNlMeansDenoisingColoredMulti_excsafe( System.IntPtr[] srcImgs ,  System.Int32 srcImgsLength ,  System.IntPtr dst ,  System.Int32 imgToDenoiseIndex ,  System.Int32 temporalWindowSize ,  System.Single h ,  System.Single hColor ,  System.Int32 templateWindowSize ,  System.Int32 searchWindowSize );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean photo_denoise_TVL1_excsafe( System.IntPtr[] observations ,  System.Int32 observationsSize ,  System.IntPtr result ,  System.Double lambda ,  System.Int32 niters );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean photo_decolor_excsafe( System.IntPtr src ,  System.IntPtr grayscale ,  System.IntPtr color_boost );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean photo_seamlessClone_excsafe( System.IntPtr src ,  System.IntPtr dst ,  System.IntPtr mask ,  OpenCvSharp.Point p ,  System.IntPtr blend ,  System.Int32 flags );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean photo_colorChange_excsafe( System.IntPtr src ,  System.IntPtr mask ,  System.IntPtr dst ,  System.Single red_mul ,  System.Single green_mul ,  System.Single blue_mul );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean photo_illuminationChange_excsafe( System.IntPtr src ,  System.IntPtr mask ,  System.IntPtr dst ,  System.Single alpha ,  System.Single beta );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean photo_textureFlattening_excsafe( System.IntPtr src ,  System.IntPtr mask ,  System.IntPtr dst ,  System.Single low_threshold ,  System.Single high_threshold ,  System.Int32 kernel_size );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean photo_edgePreservingFilter_excsafe( System.IntPtr src ,  System.IntPtr dst ,  System.Int32 flags ,  System.Single sigma_s ,  System.Single sigma_r );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean photo_detailEnhance_excsafe( System.IntPtr src ,  System.IntPtr dst ,  System.Single sigma_s ,  System.Single sigma_r );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean photo_pencilSketch_excsafe( System.IntPtr src ,  System.IntPtr dst1 ,  System.IntPtr dst2 ,  System.Single sigma_s ,  System.Single sigma_r ,  System.Single shade_factor );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean photo_stylization_excsafe( System.IntPtr src ,  System.IntPtr dst ,  System.Single sigma_s ,  System.Single sigma_r );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean photo_createCalibrateDebevec_excsafe(ref System.IntPtr ret,  System.Int32 samples ,  System.Single lambda ,  System.Int32 random );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean photo_createCalibrateRobertson_excsafe(ref System.IntPtr ret,  System.Int32 maxIter ,  System.Single threshold );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean xfeatures2d_SIFT_create_excsafe(ref System.IntPtr ret,  System.Int32 nfeatures ,  System.Int32 nOctaveLayers ,  System.Double contrastThreshold ,  System.Double edgeThreshold ,  System.Double sigma );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean xfeatures2d_Ptr_SIFT_delete_excsafe( System.IntPtr ptr );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean xfeatures2d_Ptr_SIFT_get_excsafe(ref System.IntPtr ret,  System.IntPtr ptr );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean xphoto_inpaint_excsafe( System.IntPtr prt ,  System.IntPtr src ,  System.IntPtr dst ,  System.Int32 algorithm );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean xphoto_applyChannelGains_excsafe(ref System.IntPtr ret,  System.IntPtr src ,  System.IntPtr dst ,  System.Single gainB ,  System.Single gainG ,  System.Single gainR );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean xphoto_createGrayworldWB_excsafe(ref System.IntPtr ret);

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean xphoto_Ptr_GrayworldWB_delete_excsafe( System.IntPtr prt );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean xphoto_Ptr_GrayworldWB_get_excsafe(ref System.IntPtr ret,  System.IntPtr prt );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean xphoto_GrayworldWB_balanceWhite_excsafe( System.IntPtr prt ,  System.IntPtr src ,  System.IntPtr dst );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean xphoto_GrayworldWB_SaturationThreshold_get_excsafe(ref System.Single ret,  System.IntPtr ptr );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean xphoto_GrayworldWB_SaturationThreshold_set_excsafe( System.IntPtr ptr ,  System.Single val );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean xphoto_createLearningBasedWB_excsafe(ref System.IntPtr ret,  System.String trackerType );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean xphoto_Ptr_LearningBasedWB_delete_excsafe( System.IntPtr prt );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean xphoto_Ptr_LearningBasedWB_get_excsafe(ref System.IntPtr ret,  System.IntPtr prt );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean xphoto_LearningBasedWB_balanceWhite_excsafe( System.IntPtr prt ,  System.IntPtr src ,  System.IntPtr dst );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean xphoto_LearningBasedWB_extractSimpleFeatures_excsafe( System.IntPtr prt ,  System.IntPtr src ,  System.IntPtr dst );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean xphoto_LearningBasedWB_HistBinNum_set_excsafe( System.IntPtr prt ,  System.Int32 value );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean xphoto_LearningBasedWB_RangeMaxVal_set_excsafe( System.IntPtr prt ,  System.Int32 value );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean xphoto_LearningBasedWB_SaturationThreshold_set_excsafe(ref System.Single ret,  System.IntPtr prt ,  System.Single value );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean xphoto_LearningBasedWB_HistBinNum_get_excsafe(ref System.Int32 ret,  System.IntPtr prt );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean xphoto_LearningBasedWB_RangeMaxVal_get_excsafe(ref System.Int32 ret,  System.IntPtr prt );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean xphoto_LearningBasedWB_SaturationThreshold_get_excsafe(ref System.Single ret,  System.IntPtr prt );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean xphoto_createSimpleWB_excsafe(ref System.IntPtr ret);

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean xphoto_Ptr_SimpleWB_delete_excsafe( System.IntPtr prt );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean xphoto_Ptr_SimpleWB_get_excsafe(ref System.IntPtr ret,  System.IntPtr prt );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean xphoto_SimpleWB_balanceWhite_excsafe( System.IntPtr prt ,  System.IntPtr src ,  System.IntPtr dst );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean xphoto_SimpleWB_InputMax_get_excsafe(ref System.Single ret,  System.IntPtr prt );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean xphoto_SimpleWB_InputMax_set_excsafe(ref System.Single ret,  System.IntPtr prt ,  System.Single value );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean xfeatures2d_BriefDescriptorExtractor_descriptorSize_excsafe(ref System.Int32 ret,  System.IntPtr obj );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean xfeatures2d_BriefDescriptorExtractor_descriptorType_excsafe(ref System.Int32 ret,  System.IntPtr obj );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean xfeatures2d_Ptr_BriefDescriptorExtractor_get_excsafe(ref System.IntPtr ret,  System.IntPtr ptr );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean xfeatures2d_FREAK_create_excsafe(ref System.IntPtr ret,  System.Int32 orientationNormalized ,  System.Int32 scaleNormalized ,  System.Single patternScale ,  System.Int32 nOctaves ,  System.Int32[] selectedPairs ,  System.Int32 selectedPairsLength );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean xfeatures2d_Ptr_FREAK_delete_excsafe( System.IntPtr ptr );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean xfeatures2d_Ptr_FREAK_get_excsafe(ref System.IntPtr ret,  System.IntPtr ptr );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean xfeatures2d_StarDetector_create_excsafe(ref System.IntPtr ret,  System.Int32 maxSize ,  System.Int32 responseThreshold ,  System.Int32 lineThresholdProjected ,  System.Int32 lineThresholdBinarized ,  System.Int32 suppressNonmaxSize );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean xfeatures2d_Ptr_StarDetector_delete_excsafe( System.IntPtr ptr );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean xfeatures2d_Ptr_StarDetector_get_excsafe(ref System.IntPtr ret,  System.IntPtr ptr );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean xfeatures2d_LUCID_create_excsafe(ref System.IntPtr ret,  System.Int32 lucid_kernel  = 1,  System.Int32 blur_kernel  = 2);

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean xfeatures2d_Ptr_LUCID_delete_excsafe( System.IntPtr ptr );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean xfeatures2d_Ptr_LUCID_get_excsafe(ref System.IntPtr ret,  System.IntPtr ptr );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean xfeatures2d_LATCH_create_excsafe(ref System.IntPtr ret,  System.Int32 bytes ,  System.Int32 rotationInvariance ,  System.Int32 half_ssd_size ,  System.Double sigma );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean xfeatures2d_Ptr_LATCH_delete_excsafe( System.IntPtr ptr );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean xfeatures2d_Ptr_LATCH_get_excsafe(ref System.IntPtr ret,  System.IntPtr ptr );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean xfeatures2d_SURF_create_excsafe(ref System.IntPtr ret,  System.Double hessianThreshold ,  System.Int32 nOctaves ,  System.Int32 nOctaveLayers ,  System.Int32 extended ,  System.Int32 upright );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean xfeatures2d_Ptr_SURF_delete_excsafe( System.IntPtr ptr );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean xfeatures2d_Ptr_SURF_get_excsafe(ref System.IntPtr ret,  System.IntPtr ptr );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean xfeatures2d_SURF_getHessianThreshold_excsafe(ref System.Double ret,  System.IntPtr obj );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean xfeatures2d_SURF_getNOctaves_excsafe(ref System.Int32 ret,  System.IntPtr obj );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean xfeatures2d_SURF_getNOctaveLayers_excsafe(ref System.Int32 ret,  System.IntPtr obj );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean xfeatures2d_SURF_getExtended_excsafe(ref System.Int32 ret,  System.IntPtr obj );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean xfeatures2d_SURF_getUpright_excsafe(ref System.Int32 ret,  System.IntPtr obj );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean xfeatures2d_SURF_setHessianThreshold_excsafe( System.IntPtr obj ,  System.Double value );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean xfeatures2d_SURF_setNOctaves_excsafe( System.IntPtr obj ,  System.Int32 value );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean xfeatures2d_SURF_setNOctaveLayers_excsafe( System.IntPtr obj ,  System.Int32 value );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean xfeatures2d_SURF_setExtended_excsafe( System.IntPtr obj ,  System.Int32 value );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean xfeatures2d_SURF_setUpright_excsafe( System.IntPtr obj ,  System.Int32 value );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean videoio_VideoCapture_new3_excsafe(ref System.IntPtr ret,  System.Int32 device );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean videoio_VideoCapture_delete_excsafe( System.IntPtr obj );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean videoio_VideoCapture_open1_excsafe(ref System.Int32 ret,  System.IntPtr obj , [MarshalAs(UnmanagedType.LPStr)] System.String filename );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean videoio_VideoCapture_open2_excsafe(ref System.Int32 ret,  System.IntPtr obj ,  System.Int32 device );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean videoio_VideoCapture_isOpened_excsafe(ref System.Int32 ret,  System.IntPtr obj );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean videoio_VideoCapture_release_excsafe( System.IntPtr obj );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean videoio_VideoCapture_grab_excsafe(ref System.Int32 ret,  System.IntPtr obj );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean videoio_VideoCapture_retrieve_excsafe(ref System.Int32 ret,  System.IntPtr obj ,  System.IntPtr image ,  System.Int32 flag );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean videoio_VideoCapture_operatorRightShift_Mat_excsafe( System.IntPtr obj ,  System.IntPtr image );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean videoio_VideoCapture_operatorRightShift_UMat_excsafe( System.IntPtr obj ,  System.IntPtr image );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean videoio_VideoCapture_read_excsafe(ref System.Int32 ret,  System.IntPtr obj ,  System.IntPtr image );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean videoio_VideoCapture_set_excsafe(ref System.Int32 ret,  System.IntPtr obj ,  System.Int32 propId ,  System.Double value );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean videoio_VideoCapture_get_excsafe(ref System.Double ret,  System.IntPtr obj ,  System.Int32 propId );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean videoio_VideoWriter_new1_excsafe(ref System.IntPtr ret);

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean videoio_VideoWriter_new2_excsafe(ref System.IntPtr ret, [MarshalAs(UnmanagedType.LPStr)] System.String filename ,  System.Int32 fourcc ,  System.Double fps ,  OpenCvSharp.Size frameSize ,  System.Int32 isColor );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean videoio_VideoWriter_delete_excsafe( System.IntPtr obj );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean videoio_VideoWriter_open_excsafe(ref System.Int32 ret,  System.IntPtr obj , [MarshalAs(UnmanagedType.LPStr)] System.String filename ,  System.Int32 fourcc ,  System.Double fps ,  OpenCvSharp.Size frameSize ,  System.Int32 isColor );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean videoio_VideoWriter_isOpened_excsafe(ref System.Int32 ret,  System.IntPtr obj );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean videoio_VideoWriter_release_excsafe( System.IntPtr obj );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean videoio_VideoWriter_OperatorLeftShift_excsafe( System.IntPtr obj ,  System.IntPtr image );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean videoio_VideoWriter_write_excsafe( System.IntPtr obj ,  System.IntPtr image );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean videoio_VideoWriter_set_excsafe(ref System.Int32 ret,  System.IntPtr obj ,  System.Int32 propId ,  System.Double value );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean videoio_VideoWriter_get_excsafe(ref System.Double ret,  System.IntPtr obj ,  System.Int32 propId );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean videoio_VideoWriter_fourcc_excsafe(ref System.Int32 ret,  System.Byte c1 ,  System.Byte c2 ,  System.Byte c3 ,  System.Byte c4 );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean xfeatures2d_BriefDescriptorExtractor_create_excsafe(ref System.IntPtr ret,  System.Int32 bytes );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean xfeatures2d_Ptr_BriefDescriptorExtractor_delete_excsafe( System.IntPtr obj );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean xfeatures2d_BriefDescriptorExtractor_read_excsafe( System.IntPtr obj ,  System.IntPtr fn );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean xfeatures2d_BriefDescriptorExtractor_write_excsafe( System.IntPtr obj ,  System.IntPtr fs );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean superres_SuperResolution_reset_excsafe( System.IntPtr obj );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean superres_SuperResolution_collectGarbage_excsafe( System.IntPtr obj );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean superres_createSuperResolution_BTVL1_excsafe(ref System.IntPtr ret);

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean superres_createSuperResolution_BTVL1_CUDA_excsafe(ref System.IntPtr ret);

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean superres_Ptr_SuperResolution_get_excsafe(ref System.IntPtr ret,  System.IntPtr ptr );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean superres_Ptr_SuperResolution_delete_excsafe( System.IntPtr ptr );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean superres_DenseOpticalFlowExt_calc_excsafe( System.IntPtr obj ,  System.IntPtr frame0 ,  System.IntPtr frame1 ,  System.IntPtr flow1 ,  System.IntPtr flow2 );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean superres_DenseOpticalFlowExt_collectGarbage_excsafe( System.IntPtr obj );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean superres_Ptr_DenseOpticalFlowExt_get_excsafe(ref System.IntPtr ret,  System.IntPtr ptr );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean superres_Ptr_DenseOpticalFlowExt_delete_excsafe( System.IntPtr ptr );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean superres_createOptFlow_Farneback_excsafe(ref System.IntPtr ret);

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean superres_createOptFlow_Farneback_CUDA_excsafe(ref System.IntPtr ret);

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean superres_createOptFlow_DualTVL1_excsafe(ref System.IntPtr ret);

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean superres_createOptFlow_DualTVL1_CUDA_excsafe(ref System.IntPtr ret);

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean superres_createOptFlow_Brox_CUDA_excsafe(ref System.IntPtr ret);

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean superres_createOptFlow_PyrLK_CUDA_excsafe(ref System.IntPtr ret);

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean text_BaseOCR_run1_excsafe( System.IntPtr obj ,  System.IntPtr image ,  System.IntPtr outputText ,  System.IntPtr componentRects ,  System.IntPtr componentTexts ,  System.IntPtr componentConfidences ,  System.Int32 componentLevel );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean text_BaseOCR_run2_excsafe( System.IntPtr obj ,  System.IntPtr image ,  System.IntPtr mask ,  System.IntPtr outputText ,  System.IntPtr componentRects ,  System.IntPtr componentTexts ,  System.IntPtr componentConfidences ,  System.Int32 componentLevel );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean text_OCRTesseract_run1_excsafe( System.IntPtr obj ,  System.IntPtr image ,  System.IntPtr outputText ,  System.IntPtr componentRects ,  System.IntPtr componentTexts ,  System.IntPtr componentConfidences ,  System.Int32 componentLevel );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean text_OCRTesseract_run2_excsafe( System.IntPtr obj ,  System.IntPtr image ,  System.IntPtr mask ,  System.IntPtr outputText ,  System.IntPtr componentRects ,  System.IntPtr componentTexts ,  System.IntPtr componentConfidences ,  System.Int32 componentLevel );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean text_OCRTesseract_run3_excsafe( System.IntPtr obj ,  System.IntPtr image ,  System.Int32 minConfidence ,  System.Int32 componentLevel ,  System.IntPtr dst );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean text_OCRTesseract_run4_excsafe( System.IntPtr obj ,  System.IntPtr image ,  System.IntPtr mask ,  System.Int32 minConfidence ,  System.Int32 componentLevel ,  System.IntPtr dst );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean text_OCRTesseract_setWhiteList_excsafe( System.IntPtr obj , [MarshalAs(UnmanagedType.LPStr)] System.String charWhitelist );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean text_OCRTesseract_create_excsafe(ref System.IntPtr ret, [MarshalAs(UnmanagedType.LPStr)] System.String datapath , [MarshalAs(UnmanagedType.LPStr)] System.String language , [MarshalAs(UnmanagedType.LPStr)] System.String charWhitelist ,  System.Int32 oem ,  System.Int32 psmode );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean text_Ptr_OCRTesseract_delete_excsafe( System.IntPtr obj );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean text_OCRTesseract_get_excsafe(ref System.IntPtr ret,  System.IntPtr obj );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean videoio_VideoCapture_new1_excsafe(ref System.IntPtr ret);

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean videoio_VideoCapture_new2_excsafe(ref System.IntPtr ret, [MarshalAs(UnmanagedType.LPStr)] System.String filename );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean stitching_Stitcher_setPanoConfidenceThresh_excsafe( System.IntPtr obj ,  System.Double confThresh );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean stitching_Stitcher_waveCorrection_excsafe(ref System.Int32 ret,  System.IntPtr obj );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean stitching_Stitcher_setWaveCorrection_excsafe( System.IntPtr obj ,  System.Int32 flag );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean stitching_Stitcher_waveCorrectKind_excsafe(ref System.Int32 ret,  System.IntPtr obj );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean stitching_Stitcher_setWaveCorrectKind_excsafe( System.IntPtr obj ,  System.Int32 kind );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean stitching_Stitcher_estimateTransform_InputArray1_excsafe(ref System.Int32 ret,  System.IntPtr obj ,  System.IntPtr images );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean stitching_Stitcher_estimateTransform_InputArray2_excsafe(ref System.Int32 ret,  System.IntPtr obj ,  System.IntPtr images ,  System.IntPtr[] rois ,  System.Int32 roisSize1 ,  System.Int32[] roisSize2 );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean stitching_Stitcher_estimateTransform_MatArray1_excsafe(ref System.Int32 ret,  System.IntPtr obj ,  System.IntPtr[] images ,  System.Int32 imagesSize );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean stitching_Stitcher_estimateTransform_MatArray2_excsafe(ref System.Int32 ret,  System.IntPtr obj ,  System.IntPtr[] images ,  System.Int32 imagesSize ,  System.IntPtr[] rois ,  System.Int32 roisSize1 ,  System.Int32[] roisSize2 );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean stitching_Stitcher_composePanorama1_excsafe(ref System.Int32 ret,  System.IntPtr obj ,  System.IntPtr pano );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean stitching_Stitcher_composePanorama2_InputArray_excsafe(ref System.Int32 ret,  System.IntPtr obj ,  System.IntPtr images ,  System.IntPtr pano );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean stitching_Stitcher_composePanorama2_MatArray_excsafe(ref System.Int32 ret,  System.IntPtr obj ,  System.IntPtr[] images ,  System.Int32 imagesSize ,  System.IntPtr pano );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean stitching_Stitcher_stitch1_InputArray_excsafe(ref System.Int32 ret,  System.IntPtr obj ,  System.IntPtr images ,  System.IntPtr pano );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean stitching_Stitcher_stitch1_MatArray_excsafe(ref System.Int32 ret,  System.IntPtr obj , [MarshalAs(UnmanagedType.LPArray)] System.IntPtr[] images ,  System.Int32 imagesSize ,  System.IntPtr pano );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean stitching_Stitcher_stitch2_InputArray_excsafe(ref System.Int32 ret,  System.IntPtr obj ,  System.IntPtr images ,  System.IntPtr[] rois ,  System.Int32 roisSize1 ,  System.Int32[] roisSize2 ,  System.IntPtr pano );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean stitching_Stitcher_stitch2_MatArray_excsafe(ref System.Int32 ret,  System.IntPtr obj ,  System.IntPtr[] images ,  System.Int32 imagesSize ,  System.IntPtr[] rois ,  System.Int32 roisSize1 ,  System.Int32[] roisSize2 ,  System.IntPtr pano );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean stitching_Stitcher_component_excsafe( System.IntPtr obj ,  out System.IntPtr pointer ,  out System.Int32 length );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean stitching_Stitcher_workScale_excsafe(ref System.Double ret,  System.IntPtr obj );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean superres_FrameSource_nextFrame_excsafe( System.IntPtr obj ,  System.IntPtr frame );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean superres_FrameSource_reset_excsafe( System.IntPtr obj );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean superres_createFrameSource_Empty_excsafe(ref System.IntPtr ret);

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean superres_createFrameSource_Video_excsafe(ref System.IntPtr ret, [MarshalAs(UnmanagedType.LPStr)] System.String fileName );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean superres_createFrameSource_Video_CUDA_excsafe(ref System.IntPtr ret, [MarshalAs(UnmanagedType.LPStr)] System.String fileName );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean superres_createFrameSource_Camera_excsafe(ref System.IntPtr ret,  System.Int32 deviceId );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean superres_Ptr_FrameSource_get_excsafe(ref System.IntPtr ret,  System.IntPtr ptr );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean superres_Ptr_FrameSource_delete_excsafe( System.IntPtr ptr );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean superres_SuperResolution_setInput_excsafe( System.IntPtr obj ,  System.IntPtr frameSource );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean superres_SuperResolution_nextFrame_excsafe( System.IntPtr obj ,  System.IntPtr frame );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean vector_Mat_getSize_excsafe(ref System.IntPtr ret,  System.IntPtr vector );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean vector_Mat_getPointer_excsafe(ref System.IntPtr ret,  System.IntPtr vector );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean vector_Mat_delete_excsafe( System.IntPtr vector );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean vector_Mat_assignToArray_excsafe( System.IntPtr vector , [MarshalAs(UnmanagedType.LPArray)] System.IntPtr[] arr );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean vector_Mat_addref_excsafe( System.IntPtr vector );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean vector_DTrees_Node_new1_excsafe(ref System.IntPtr ret);

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean vector_DTrees_Node_new2_excsafe(ref System.IntPtr ret,  System.IntPtr size );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean vector_DTrees_Node_new3_excsafe(ref System.IntPtr ret, [In] OpenCvSharp.ML.DTrees.Node[] data ,  System.IntPtr dataLength );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean vector_DTrees_Node_getSize_excsafe(ref System.IntPtr ret,  System.IntPtr vector );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean vector_DTrees_Node_getPointer_excsafe(ref System.IntPtr ret,  System.IntPtr vector );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean vector_DTrees_Node_delete_excsafe( System.IntPtr vector );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean vector_DTrees_Split_new1_excsafe(ref System.IntPtr ret);

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean vector_DTrees_Split_new2_excsafe(ref System.IntPtr ret,  System.IntPtr size );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean vector_DTrees_Split_new3_excsafe(ref System.IntPtr ret, [In] OpenCvSharp.ML.DTrees.Split[] data ,  System.IntPtr dataLength );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean vector_DTrees_Split_getSize_excsafe(ref System.IntPtr ret,  System.IntPtr vector );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean vector_DTrees_Split_getPointer_excsafe(ref System.IntPtr ret,  System.IntPtr vector );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean vector_DTrees_Split_delete_excsafe( System.IntPtr vector );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean stitching_createStitcher_excsafe(ref System.IntPtr ret,  System.Int32 try_use_cpu );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean stitching_createStitcherScans_excsafe(ref System.IntPtr ret,  System.Int32 try_use_cpu );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean stitching_Ptr_Stitcher_delete_excsafe( System.IntPtr obj );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean stitching_Ptr_Stitcher_get_excsafe(ref System.IntPtr ret,  System.IntPtr obj );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean stitching_Stitcher_registrationResol_excsafe(ref System.Double ret,  System.IntPtr obj );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean stitching_Stitcher_setRegistrationResol_excsafe( System.IntPtr obj ,  System.Double resolMpx );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean stitching_Stitcher_seamEstimationResol_excsafe(ref System.Double ret,  System.IntPtr obj );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean stitching_Stitcher_setSeamEstimationResol_excsafe( System.IntPtr obj ,  System.Double resolMpx );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean stitching_Stitcher_compositingResol_excsafe(ref System.Double ret,  System.IntPtr obj );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean stitching_Stitcher_setCompositingResol_excsafe( System.IntPtr obj ,  System.Double resolMpx );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean stitching_Stitcher_panoConfidenceThresh_excsafe(ref System.Double ret,  System.IntPtr obj );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean vector_vector_Point_new2_excsafe(ref System.IntPtr ret,  System.IntPtr size );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean vector_vector_Point_getSize1_excsafe(ref System.IntPtr ret,  System.IntPtr vector );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean vector_vector_Point_getSize2_excsafe( System.IntPtr vector , [In, Out] System.IntPtr[] size );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean vector_vector_Point_getPointer_excsafe(ref System.IntPtr ret,  System.IntPtr vector );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean vector_vector_Point_copy_excsafe( System.IntPtr vec ,  System.IntPtr[] dst );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean vector_vector_Point_delete_excsafe( System.IntPtr vector );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean vector_vector_Point2f_new1_excsafe(ref System.IntPtr ret);

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean vector_vector_Point2f_new2_excsafe(ref System.IntPtr ret,  System.IntPtr size );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean vector_vector_Point2f_getSize1_excsafe(ref System.IntPtr ret,  System.IntPtr vector );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean vector_vector_Point2f_getSize2_excsafe( System.IntPtr vector , [In, Out] System.IntPtr[] size );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean vector_vector_Point2f_getPointer_excsafe(ref System.IntPtr ret,  System.IntPtr vector );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean vector_vector_Point2f_copy_excsafe( System.IntPtr vec ,  System.IntPtr[] dst );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean vector_vector_Point2f_delete_excsafe( System.IntPtr vector );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean vector_string_new1_excsafe(ref System.IntPtr ret);

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean vector_string_new2_excsafe(ref System.IntPtr ret,  System.IntPtr size );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean vector_string_getSize_excsafe(ref System.IntPtr ret,  System.IntPtr vec );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean vector_string_getPointer_excsafe(ref System.IntPtr ret,  System.IntPtr vector );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean vector_string_elemAt_excsafe(ref IntPtr ret,  System.IntPtr vector ,  System.Int32 i );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean vector_string_delete_excsafe( System.IntPtr vector );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean vector_cvString_new1_excsafe(ref System.IntPtr ret);

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean vector_cvString_new2_excsafe(ref System.IntPtr ret,  System.IntPtr size );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean vector_cvString_getSize_excsafe(ref System.IntPtr ret,  System.IntPtr vec );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean vector_cvString_getPointer_excsafe(ref System.IntPtr ret,  System.IntPtr vector );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean vector_cvString_elemAt_excsafe(ref IntPtr ret,  System.IntPtr vector ,  System.Int32 i );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean vector_cvString_delete_excsafe( System.IntPtr vector );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean vector_Mat_new1_excsafe(ref System.IntPtr ret);

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean vector_Mat_new2_excsafe(ref System.IntPtr ret,  System.IntPtr size );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean vector_Mat_new3_excsafe(ref System.IntPtr ret,  System.IntPtr data ,  System.IntPtr dataLength );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean vector_vector_float_getSize1_excsafe(ref System.IntPtr ret,  System.IntPtr vector );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean vector_vector_float_getSize2_excsafe( System.IntPtr vector , [In, Out] System.IntPtr[] size );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean vector_vector_float_getPointer_excsafe(ref System.IntPtr ret,  System.IntPtr vector );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean vector_vector_float_copy_excsafe( System.IntPtr vec ,  System.IntPtr[] dst );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean vector_vector_float_delete_excsafe( System.IntPtr vector );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean vector_vector_double_new1_excsafe(ref System.IntPtr ret);

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean vector_vector_double_new2_excsafe(ref System.IntPtr ret,  System.IntPtr size );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean vector_vector_double_getSize1_excsafe(ref System.IntPtr ret,  System.IntPtr vector );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean vector_vector_double_getSize2_excsafe( System.IntPtr vector , [In, Out] System.IntPtr[] size );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean vector_vector_double_getPointer_excsafe(ref System.IntPtr ret,  System.IntPtr vector );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean vector_vector_double_copy_excsafe( System.IntPtr vec ,  System.IntPtr[] dst );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean vector_vector_double_delete_excsafe( System.IntPtr vector );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean vector_vector_KeyPoint_new1_excsafe(ref System.IntPtr ret);

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean vector_vector_KeyPoint_new2_excsafe(ref System.IntPtr ret,  System.IntPtr size );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean vector_vector_KeyPoint_new3_excsafe(ref System.IntPtr ret,  System.IntPtr[] values ,  System.Int32 size1 ,  System.Int32[] size2 );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean vector_vector_KeyPoint_getSize1_excsafe(ref System.IntPtr ret,  System.IntPtr vector );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean vector_vector_KeyPoint_getSize2_excsafe( System.IntPtr vector , [In, Out] System.IntPtr[] size );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean vector_vector_KeyPoint_getPointer_excsafe(ref System.IntPtr ret,  System.IntPtr vector );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean vector_vector_KeyPoint_copy_excsafe( System.IntPtr vec ,  System.IntPtr[] dst );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean vector_vector_KeyPoint_delete_excsafe( System.IntPtr vector );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean vector_vector_DMatch_new1_excsafe(ref System.IntPtr ret);

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean vector_vector_DMatch_new2_excsafe(ref System.IntPtr ret,  System.IntPtr size );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean vector_vector_DMatch_getSize1_excsafe(ref System.IntPtr ret,  System.IntPtr vector );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean vector_vector_DMatch_getSize2_excsafe( System.IntPtr vector , [In, Out] System.IntPtr[] size );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean vector_vector_DMatch_getPointer_excsafe(ref System.IntPtr ret,  System.IntPtr vector );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean vector_vector_DMatch_copy_excsafe( System.IntPtr vec ,  System.IntPtr[] dst );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean vector_vector_DMatch_delete_excsafe( System.IntPtr vector );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean vector_vector_Point_new1_excsafe(ref System.IntPtr ret);

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean vector_Rect_delete_excsafe( System.IntPtr vector );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean vector_Rect2d_new1_excsafe(ref System.IntPtr ret);

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean vector_Rect2d_new2_excsafe(ref System.IntPtr ret,  System.IntPtr size );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean vector_Rect2d_new3_excsafe(ref System.IntPtr ret, [In] OpenCvSharp.Rect2d[] data ,  System.IntPtr dataLength );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean vector_Rect2d_getSize_excsafe(ref System.IntPtr ret,  System.IntPtr vector );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean vector_Rect2d_getPointer_excsafe(ref System.IntPtr ret,  System.IntPtr vector );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean vector_Rect2d_delete_excsafe( System.IntPtr vector );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean vector_KeyPoint_new1_excsafe(ref System.IntPtr ret);

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean vector_KeyPoint_new2_excsafe(ref System.IntPtr ret,  System.IntPtr size );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean vector_KeyPoint_new3_excsafe(ref System.IntPtr ret, [In] OpenCvSharp.KeyPoint[] data ,  System.IntPtr dataLength );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean vector_KeyPoint_getSize_excsafe(ref System.IntPtr ret,  System.IntPtr vector );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean vector_KeyPoint_getPointer_excsafe(ref System.IntPtr ret,  System.IntPtr vector );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean vector_KeyPoint_delete_excsafe( System.IntPtr vector );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean vector_DMatch_new1_excsafe(ref System.IntPtr ret);

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean vector_DMatch_new2_excsafe(ref System.IntPtr ret,  System.IntPtr size );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean vector_DMatch_new3_excsafe(ref System.IntPtr ret, [In] OpenCvSharp.DMatch[] data ,  System.IntPtr dataLength );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean vector_DMatch_getSize_excsafe(ref System.IntPtr ret,  System.IntPtr vector );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean vector_DMatch_getPointer_excsafe(ref System.IntPtr ret,  System.IntPtr vector );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean vector_DMatch_delete_excsafe( System.IntPtr vector );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean vector_vector_int_new1_excsafe(ref System.IntPtr ret);

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean vector_vector_int_new2_excsafe(ref System.IntPtr ret,  System.IntPtr size );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean vector_vector_int_getSize1_excsafe(ref System.IntPtr ret,  System.IntPtr vector );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean vector_vector_int_getSize2_excsafe( System.IntPtr vector , [In, Out] System.IntPtr[] size );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean vector_vector_int_getPointer_excsafe(ref System.IntPtr ret,  System.IntPtr vector );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean vector_vector_int_copy_excsafe( System.IntPtr vec ,  System.IntPtr[] dst );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean vector_vector_int_delete_excsafe( System.IntPtr vector );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean vector_vector_float_new1_excsafe(ref System.IntPtr ret);

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean vector_vector_float_new2_excsafe(ref System.IntPtr ret,  System.IntPtr size );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean vector_Vec6d_new2_excsafe(ref System.IntPtr ret,  System.IntPtr size );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean vector_Vec6d_new3_excsafe(ref System.IntPtr ret, [In] OpenCvSharp.Vec6d[] data ,  System.IntPtr dataLength );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean vector_Vec6d_getSize_excsafe(ref System.IntPtr ret,  System.IntPtr vector );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean vector_Vec6d_getPointer_excsafe(ref System.IntPtr ret,  System.IntPtr vector );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean vector_Vec6d_delete_excsafe( System.IntPtr vector );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean vector_Point2i_new1_excsafe(ref System.IntPtr ret);

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean vector_Point2i_new2_excsafe(ref System.IntPtr ret,  System.IntPtr size );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean vector_Point2i_new3_excsafe(ref System.IntPtr ret, [In] OpenCvSharp.Point[] data ,  System.IntPtr dataLength );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean vector_Point2i_getSize_excsafe(ref System.IntPtr ret,  System.IntPtr vector );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean vector_Point2i_getPointer_excsafe(ref System.IntPtr ret,  System.IntPtr vector );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean vector_Point2i_delete_excsafe( System.IntPtr vector );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean vector_Point2f_new1_excsafe(ref System.IntPtr ret);

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean vector_Point2f_new2_excsafe(ref System.IntPtr ret,  System.IntPtr size );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean vector_Point2f_new3_excsafe(ref System.IntPtr ret, [In] OpenCvSharp.Point2f[] data ,  System.IntPtr dataLength );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean vector_Point2f_getSize_excsafe(ref System.IntPtr ret,  System.IntPtr vector );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean vector_Point2f_getPointer_excsafe(ref System.IntPtr ret,  System.IntPtr vector );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean vector_Point2f_delete_excsafe( System.IntPtr vector );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean vector_Point3f_new1_excsafe(ref System.IntPtr ret);

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean vector_Point3f_new2_excsafe(ref System.IntPtr ret,  System.IntPtr size );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean vector_Point3f_new3_excsafe(ref System.IntPtr ret, [In] OpenCvSharp.Point3f[] data ,  System.IntPtr dataLength );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean vector_Point3f_getSize_excsafe(ref System.IntPtr ret,  System.IntPtr vector );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean vector_Point3f_getPointer_excsafe(ref System.IntPtr ret,  System.IntPtr vector );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean vector_Point3f_delete_excsafe( System.IntPtr vector );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean vector_Rect_new1_excsafe(ref System.IntPtr ret);

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean vector_Rect_new2_excsafe(ref System.IntPtr ret,  System.IntPtr size );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean vector_Rect_new3_excsafe(ref System.IntPtr ret, [In] OpenCvSharp.Rect[] data ,  System.IntPtr dataLength );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean vector_Rect_getSize_excsafe(ref System.IntPtr ret,  System.IntPtr vector );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean vector_Rect_getPointer_excsafe(ref System.IntPtr ret,  System.IntPtr vector );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean vector_Vec2f_getSize_excsafe(ref System.IntPtr ret,  System.IntPtr vector );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean vector_Vec2f_getPointer_excsafe(ref System.IntPtr ret,  System.IntPtr vector );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean vector_Vec2f_delete_excsafe( System.IntPtr vector );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean vector_Vec3f_new1_excsafe(ref System.IntPtr ret);

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean vector_Vec3f_new2_excsafe(ref System.IntPtr ret,  System.IntPtr size );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean vector_Vec3f_new3_excsafe(ref System.IntPtr ret, [In] OpenCvSharp.Vec3f[] data ,  System.IntPtr dataLength );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean vector_Vec3f_getSize_excsafe(ref System.IntPtr ret,  System.IntPtr vector );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean vector_Vec3f_getPointer_excsafe(ref System.IntPtr ret,  System.IntPtr vector );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean vector_Vec3f_delete_excsafe( System.IntPtr vector );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean vector_Vec4f_new1_excsafe(ref System.IntPtr ret);

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean vector_Vec4f_new2_excsafe(ref System.IntPtr ret,  System.IntPtr size );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean vector_Vec4f_new3_excsafe(ref System.IntPtr ret, [In] OpenCvSharp.Vec4f[] data ,  System.IntPtr dataLength );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean vector_Vec4f_getSize_excsafe(ref System.IntPtr ret,  System.IntPtr vector );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean vector_Vec4f_getPointer_excsafe(ref System.IntPtr ret,  System.IntPtr vector );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean vector_Vec4f_delete_excsafe( System.IntPtr vector );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean vector_Vec4i_new1_excsafe(ref System.IntPtr ret);

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean vector_Vec4i_new2_excsafe(ref System.IntPtr ret,  System.IntPtr size );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean vector_Vec4i_new3_excsafe(ref System.IntPtr ret, [In] OpenCvSharp.Vec4i[] data ,  System.IntPtr dataLength );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean vector_Vec4i_getSize_excsafe(ref System.IntPtr ret,  System.IntPtr vector );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean vector_Vec4i_getPointer_excsafe(ref System.IntPtr ret,  System.IntPtr vector );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean vector_Vec4i_delete_excsafe( System.IntPtr vector );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean vector_Vec6f_new1_excsafe(ref System.IntPtr ret);

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean vector_Vec6f_new2_excsafe(ref System.IntPtr ret,  System.IntPtr size );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean vector_Vec6f_new3_excsafe(ref System.IntPtr ret, [In] OpenCvSharp.Vec6f[] data ,  System.IntPtr dataLength );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean vector_Vec6f_getSize_excsafe(ref System.IntPtr ret,  System.IntPtr vector );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean vector_Vec6f_getPointer_excsafe(ref System.IntPtr ret,  System.IntPtr vector );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean vector_Vec6f_delete_excsafe( System.IntPtr vector );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean vector_Vec6d_new1_excsafe(ref System.IntPtr ret);

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean vector_char_new1_excsafe(ref System.IntPtr ret);

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean vector_char_new2_excsafe(ref System.IntPtr ret,  System.IntPtr size );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean vector_char_new3_excsafe(ref System.IntPtr ret, [In] System.SByte[] data ,  System.IntPtr dataLength );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean vector_char_getSize_excsafe(ref System.IntPtr ret,  System.IntPtr vector );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean vector_char_getPointer_excsafe(ref System.IntPtr ret,  System.IntPtr vector );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean vector_vector_char_copy_excsafe( System.IntPtr vector ,  System.IntPtr dst );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean vector_char_delete_excsafe( System.IntPtr vector );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean vector_int32_new1_excsafe(ref System.IntPtr ret);

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean vector_int32_new2_excsafe(ref System.IntPtr ret,  System.IntPtr size );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean vector_int32_new3_excsafe(ref System.IntPtr ret, [In] System.Int32[] data ,  System.IntPtr dataLength );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean vector_int32_getSize_excsafe(ref System.IntPtr ret,  System.IntPtr vector );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean vector_int32_getPointer_excsafe(ref System.IntPtr ret,  System.IntPtr vector );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean vector_int32_delete_excsafe( System.IntPtr vector );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean vector_float_new1_excsafe(ref System.IntPtr ret);

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean vector_float_new2_excsafe(ref System.IntPtr ret,  System.IntPtr size );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean vector_float_new3_excsafe(ref System.IntPtr ret, [In] System.Single[] data ,  System.IntPtr dataLength );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean vector_float_getSize_excsafe(ref System.IntPtr ret,  System.IntPtr vector );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean vector_float_getPointer_excsafe(ref System.IntPtr ret,  System.IntPtr vector );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean vector_float_delete_excsafe( System.IntPtr vector );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean vector_double_new1_excsafe(ref System.IntPtr ret);

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean vector_double_new2_excsafe(ref System.IntPtr ret,  System.IntPtr size );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean vector_double_new3_excsafe(ref System.IntPtr ret, [In] System.Double[] data ,  System.IntPtr dataLength );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean vector_double_getSize_excsafe(ref System.IntPtr ret,  System.IntPtr vector );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean vector_double_getPointer_excsafe(ref System.IntPtr ret,  System.IntPtr vector );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean vector_double_delete_excsafe( System.IntPtr vector );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean vector_Vec2f_new1_excsafe(ref System.IntPtr ret);

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean vector_Vec2f_new2_excsafe(ref System.IntPtr ret,  System.IntPtr size );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean vector_Vec2f_new3_excsafe(ref System.IntPtr ret, [In] OpenCvSharp.Vec2f[] data ,  System.IntPtr dataLength );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean objdetect_HOGDescriptor_winSigma_set_excsafe( System.IntPtr self ,  System.Double value );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean objdetect_HOGDescriptor_histogramNormType_set_excsafe( System.IntPtr self ,  System.Int32 value );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean objdetect_HOGDescriptor_L2HysThreshold_set_excsafe( System.IntPtr self ,  System.Double value );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean objdetect_HOGDescriptor_gammaCorrection_set_excsafe( System.IntPtr self ,  System.Int32 value );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean objdetect_HOGDescriptor_nlevels_set_excsafe( System.IntPtr self ,  System.Int32 value );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean objdetect_groupRectangles1_excsafe( System.IntPtr rectList ,  System.Int32 groupThreshold ,  System.Double eps );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean objdetect_groupRectangles2_excsafe( System.IntPtr rectList ,  System.IntPtr weights ,  System.Int32 groupThreshold ,  System.Double eps );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean objdetect_groupRectangles3_excsafe( System.IntPtr rectList ,  System.Int32 groupThreshold ,  System.Double eps ,  System.IntPtr weights ,  System.IntPtr levelWeights );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean objdetect_groupRectangles4_excsafe( System.IntPtr rectList ,  System.IntPtr rejectLevels ,  System.IntPtr levelWeights ,  System.Int32 groupThreshold ,  System.Double eps );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean objdetect_groupRectangles_meanshift_excsafe( System.IntPtr rectList ,  System.IntPtr foundWeights ,  System.IntPtr foundScales ,  System.Double detectThreshold ,  OpenCvSharp.Size winDetSize );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean optflow_motempl_updateMotionHistory_excsafe( System.IntPtr silhouette ,  System.IntPtr mhi ,  System.Double timestamp ,  System.Double duration );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean optflow_motempl_calcMotionGradient_excsafe( System.IntPtr mhi ,  System.IntPtr mask ,  System.IntPtr orientation ,  System.Double delta1 ,  System.Double delta2 ,  System.Int32 apertureSize );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean optflow_motempl_calcGlobalOrientation_excsafe(ref System.Double ret,  System.IntPtr orientation ,  System.IntPtr mask ,  System.IntPtr mhi ,  System.Double timestamp ,  System.Double duration );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean optflow_motempl_segmentMotion_excsafe( System.IntPtr mhi ,  System.IntPtr segmask ,  System.IntPtr boundingRects ,  System.Double timestamp ,  System.Double segThresh );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean optflow_calcOpticalFlowSF1_excsafe( System.IntPtr from ,  System.IntPtr to ,  System.IntPtr flow ,  System.Int32 layers ,  System.Int32 averagingBlockSize ,  System.Int32 maxFlow );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean optflow_calcOpticalFlowSF2_excsafe( System.IntPtr from ,  System.IntPtr to ,  System.IntPtr flow ,  System.Int32 layers ,  System.Int32 averagingBlockSize ,  System.Int32 maxFlow ,  System.Double sigmaDist ,  System.Double sigmaColor ,  System.Int32 postprocessWindow ,  System.Double sigmaDistFix ,  System.Double sigmaColorFix ,  System.Double occThr ,  System.Int32 upscaleAveragingRadius ,  System.Double upscaleSigmaDist ,  System.Double upscaleSigmaColor ,  System.Double speedUpThr );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean string_new1_excsafe(ref System.IntPtr ret);

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean string_new2_excsafe(ref System.IntPtr ret, [MarshalAs(UnmanagedType.LPStr)] System.String str );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean string_delete_excsafe( System.IntPtr s );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean string_c_str_excsafe(ref IntPtr ret,  System.IntPtr s );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean string_size_excsafe(ref System.IntPtr ret,  System.IntPtr s );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean vector_uchar_new1_excsafe(ref System.IntPtr ret);

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean vector_uchar_new2_excsafe(ref System.IntPtr ret,  System.IntPtr size );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean vector_uchar_new3_excsafe(ref System.IntPtr ret, [In] System.Byte[] data ,  System.IntPtr dataLength );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean vector_uchar_getSize_excsafe(ref System.IntPtr ret,  System.IntPtr vector );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean vector_uchar_getPointer_excsafe(ref System.IntPtr ret,  System.IntPtr vector );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean vector_vector_uchar_copy_excsafe( System.IntPtr vector ,  System.IntPtr dst );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean vector_uchar_delete_excsafe( System.IntPtr vector );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean objdetect_HOGDescriptor_save_excsafe( System.IntPtr self , [MarshalAs(UnmanagedType.LPStr)] System.String filename , [MarshalAs(UnmanagedType.LPStr)] System.String objname );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean objdetect_HOGDescriptor_compute_excsafe( System.IntPtr self ,  System.IntPtr img ,  System.IntPtr descriptors ,  OpenCvSharp.Size winStride ,  OpenCvSharp.Size padding , [In] OpenCvSharp.Point[] locations ,  System.Int32 locationsLength );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean objdetect_HOGDescriptor_detect1_excsafe( System.IntPtr self ,  System.IntPtr img ,  System.IntPtr foundLocations ,  System.Double hitThreshold ,  OpenCvSharp.Size winStride ,  OpenCvSharp.Size padding , [In] OpenCvSharp.Point[] searchLocations ,  System.Int32 searchLocationsLength );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean objdetect_HOGDescriptor_detect2_excsafe( System.IntPtr self ,  System.IntPtr img ,  System.IntPtr foundLocations ,  System.IntPtr weights ,  System.Double hitThreshold ,  OpenCvSharp.Size winStride ,  OpenCvSharp.Size padding , [In] OpenCvSharp.Point[] searchLocations ,  System.Int32 searchLocationsLength );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean objdetect_HOGDescriptor_detectMultiScale1_excsafe( System.IntPtr self ,  System.IntPtr img ,  System.IntPtr foundLocations ,  System.Double hitThreshold ,  OpenCvSharp.Size winStride ,  OpenCvSharp.Size padding ,  System.Double scale ,  System.Int32 groupThreshold );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean objdetect_HOGDescriptor_detectMultiScale2_excsafe( System.IntPtr self ,  System.IntPtr img ,  System.IntPtr foundLocations ,  System.IntPtr foundWeights ,  System.Double hitThreshold ,  OpenCvSharp.Size winStride ,  OpenCvSharp.Size padding ,  System.Double scale ,  System.Int32 groupThreshold );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean objdetect_HOGDescriptor_computeGradient_excsafe( System.IntPtr self ,  System.IntPtr img ,  System.IntPtr grad ,  System.IntPtr angleOfs ,  OpenCvSharp.Size paddingTL ,  OpenCvSharp.Size paddingBR );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean objdetect_HOGDescriptor_detectROI_excsafe( System.IntPtr obj ,  System.IntPtr img ,  OpenCvSharp.Point[] locations ,  System.Int32 locationsLength ,  System.IntPtr foundLocations ,  System.IntPtr confidences ,  System.Double hitThreshold ,  OpenCvSharp.Size winStride ,  OpenCvSharp.Size padding );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean objdetect_HOGDescriptor_detectMultiScaleROI_excsafe( System.IntPtr obj ,  System.IntPtr img ,  System.IntPtr foundLocations ,  System.IntPtr roiScales ,  System.IntPtr roiLocations ,  System.IntPtr roiConfidences ,  System.Double hitThreshold ,  System.Int32 groupThreshold );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean objdetect_HOGDescriptor_readALTModel_excsafe( System.IntPtr obj , [MarshalAs(UnmanagedType.LPStr)] System.String modelfile );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean objdetect_HOGDescriptor_groupRectangles_excsafe( System.IntPtr obj ,  System.IntPtr rectList ,  System.IntPtr weights ,  System.Int32 groupThreshold ,  System.Double eps );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean objdetect_HOGDescriptor_winSize_get_excsafe(ref OpenCvSharp.Size ret,  System.IntPtr self );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean objdetect_HOGDescriptor_blockSize_get_excsafe(ref OpenCvSharp.Size ret,  System.IntPtr self );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean objdetect_HOGDescriptor_blockStride_get_excsafe(ref OpenCvSharp.Size ret,  System.IntPtr self );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean objdetect_HOGDescriptor_cellSize_get_excsafe(ref OpenCvSharp.Size ret,  System.IntPtr self );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean objdetect_HOGDescriptor_nbins_get_excsafe(ref System.Int32 ret,  System.IntPtr self );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean objdetect_HOGDescriptor_derivAperture_get_excsafe(ref System.Int32 ret,  System.IntPtr self );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean objdetect_HOGDescriptor_winSigma_get_excsafe(ref System.Double ret,  System.IntPtr self );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean objdetect_HOGDescriptor_histogramNormType_get_excsafe(ref System.Int32 ret,  System.IntPtr self );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean objdetect_HOGDescriptor_L2HysThreshold_get_excsafe(ref System.Double ret,  System.IntPtr self );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean objdetect_HOGDescriptor_gammaCorrection_get_excsafe(ref System.Int32 ret,  System.IntPtr self );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean objdetect_HOGDescriptor_nlevels_get_excsafe(ref System.Int32 ret,  System.IntPtr self );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean objdetect_HOGDescriptor_winSize_set_excsafe( System.IntPtr self ,  OpenCvSharp.Size value );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean objdetect_HOGDescriptor_blockSize_set_excsafe( System.IntPtr self ,  OpenCvSharp.Size value );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean objdetect_HOGDescriptor_blockStride_set_excsafe( System.IntPtr self ,  OpenCvSharp.Size value );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean objdetect_HOGDescriptor_cellSize_set_excsafe( System.IntPtr self ,  OpenCvSharp.Size value );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean objdetect_HOGDescriptor_nbins_set_excsafe( System.IntPtr self ,  System.Int32 value );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean objdetect_HOGDescriptor_derivAperture_set_excsafe( System.IntPtr self ,  System.Int32 value );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean objdetect_LatentSvmDetector_new_excsafe(ref System.IntPtr ret);

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean objdetect_LatentSvmDetector_delete_excsafe( System.IntPtr obj );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean objdetect_LatentSvmDetector_clear_excsafe( System.IntPtr obj );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean objdetect_LatentSvmDetector_empty_excsafe(ref System.Int32 ret,  System.IntPtr obj );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean objdetect_LatentSvmDetector_load_excsafe(ref System.Int32 ret,  System.IntPtr obj ,  System.IntPtr[] fileNames ,  System.Int32 fileNamesLength ,  System.IntPtr[] classNames ,  System.Int32 classNamesLength );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean objdetect_LatentSvmDetector_detect_excsafe( System.IntPtr obj ,  System.IntPtr image ,  System.IntPtr objectDetections ,  System.Single overlapThreshold ,  System.Int32 numThreads );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean objdetect_LatentSvmDetector_getClassNames_excsafe( System.IntPtr obj ,  System.IntPtr outValues );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean objdetect_LatentSvmDetector_getClassCount_excsafe(ref System.IntPtr ret,  System.IntPtr obj );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean objdetect_CascadeClassifier_new_excsafe(ref System.IntPtr ret);

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean objdetect_CascadeClassifier_newFromFile_excsafe(ref System.IntPtr ret, [MarshalAs(UnmanagedType.LPStr)] System.String fileName );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean objdetect_CascadeClassifier_delete_excsafe( System.IntPtr obj );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean objdetect_CascadeClassifier_empty_excsafe(ref System.Int32 ret,  System.IntPtr obj );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean objdetect_CascadeClassifier_load_excsafe(ref System.Int32 ret,  System.IntPtr obj , [MarshalAs(UnmanagedType.LPStr)] System.String fileName );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean objdetect_CascadeClassifier_detectMultiScale1_excsafe( System.IntPtr obj ,  System.IntPtr image ,  System.IntPtr objects ,  System.Double scaleFactor ,  System.Int32 minNeighbors ,  System.Int32 flags ,  OpenCvSharp.Size minSize ,  OpenCvSharp.Size maxSize );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean objdetect_CascadeClassifier_detectMultiScale2_excsafe( System.IntPtr obj ,  System.IntPtr image ,  System.IntPtr objects ,  System.IntPtr rejectLevels ,  System.IntPtr levelWeights ,  System.Double scaleFactor ,  System.Int32 minNeighbors ,  System.Int32 flags ,  OpenCvSharp.Size minSize ,  OpenCvSharp.Size maxSize ,  System.Int32 outputRejectLevels );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean objdetect_CascadeClassifier_isOldFormatCascade_excsafe(ref System.Int32 ret,  System.IntPtr obj );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean objdetect_CascadeClassifier_getOriginalWindowSize_excsafe(ref OpenCvSharp.Size ret,  System.IntPtr obj );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean objdetect_CascadeClassifier_getFeatureType_excsafe(ref System.Int32 ret,  System.IntPtr obj );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean objdetect_HOGDescriptor_sizeof_excsafe(ref System.Int32 ret);

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean objdetect_HOGDescriptor_new1_excsafe(ref System.IntPtr ret);

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean objdetect_HOGDescriptor_new2_excsafe(ref System.IntPtr ret,  OpenCvSharp.Size winSize ,  OpenCvSharp.Size blockSize ,  OpenCvSharp.Size blockStride ,  OpenCvSharp.Size cellSize ,  System.Int32 nbins ,  System.Int32 derivAperture ,  System.Double winSigma , [MarshalAs(UnmanagedType.I4)] OpenCvSharp.HistogramNormType histogramNormType ,  System.Double l2HysThreshold ,  System.Int32 gammaCorrection ,  System.Int32 nlevels );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean objdetect_HOGDescriptor_new3_excsafe(ref System.IntPtr ret, [MarshalAs(UnmanagedType.LPStr)] System.String fileName );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean objdetect_HOGDescriptor_delete_excsafe( System.IntPtr self );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean objdetect_HOGDescriptor_getDescriptorSize_excsafe(ref System.IntPtr ret,  System.IntPtr self );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean objdetect_HOGDescriptor_checkDetectorSize_excsafe(ref System.Int32 ret,  System.IntPtr self );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean objdetect_HOGDescriptor_getWinSigma_excsafe(ref System.Double ret,  System.IntPtr self );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean objdetect_HOGDescriptor_setSVMDetector_excsafe( System.IntPtr self ,  System.IntPtr svmdetector );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean objdetect_HOGDescriptor_load_excsafe(ref System.Boolean ret,  System.IntPtr self , [MarshalAs(UnmanagedType.LPStr)] System.String filename , [MarshalAs(UnmanagedType.LPStr)] System.String objname );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean img_hash_ImgHashBase_compare_excsafe(ref System.Double ret,  System.IntPtr obj ,  System.IntPtr hashOne ,  System.IntPtr hashTwo );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean img_hash_AverageHash_create_excsafe(ref System.IntPtr ret);

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean img_hash_Ptr_AverageHash_delete_excsafe( System.IntPtr ptr );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean img_hash_Ptr_AverageHash_get_excsafe(ref System.IntPtr ret,  System.IntPtr ptr );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean img_hash_BlockMeanHash_create_excsafe(ref System.IntPtr ret,  System.Int32 mode );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean img_hash_Ptr_BlockMeanHash_delete_excsafe( System.IntPtr ptr );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean img_hash_Ptr_BlockMeanHash_get_excsafe(ref System.IntPtr ret,  System.IntPtr ptr );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean img_hash_BlockMeanHash_setMode_excsafe( System.IntPtr obj ,  System.Int32 mode );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean img_hash_BlockMeanHash_getMean_excsafe( System.IntPtr obj ,  System.IntPtr outVec );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean img_hash_ColorMomentHash_create_excsafe(ref System.IntPtr ret);

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean img_hash_Ptr_ColorMomentHash_delete_excsafe( System.IntPtr ptr );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean img_hash_Ptr_ColorMomentHash_get_excsafe(ref System.IntPtr ret,  System.IntPtr ptr );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean img_hash_MarrHildrethHash_create_excsafe(ref System.IntPtr ret,  System.Single alpha ,  System.Single scale );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean img_hash_Ptr_MarrHildrethHash_delete_excsafe( System.IntPtr ptr );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean img_hash_Ptr_MarrHildrethHash_get_excsafe(ref System.IntPtr ret,  System.IntPtr ptr );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean img_hash_MarrHildrethHash_setKernelParam_excsafe( System.IntPtr obj ,  System.Single alpha ,  System.Single scale );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean img_hash_MarrHildrethHash_getAlpha_excsafe(ref System.Single ret,  System.IntPtr obj );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean img_hash_MarrHildrethHash_getScale_excsafe(ref System.Single ret,  System.IntPtr obj );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean img_hash_PHash_create_excsafe(ref System.IntPtr ret);

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean img_hash_Ptr_PHash_delete_excsafe( System.IntPtr ptr );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean img_hash_Ptr_PHash_get_excsafe(ref System.IntPtr ret,  System.IntPtr ptr );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean img_hash_RadialVarianceHash_create_excsafe(ref System.IntPtr ret,  System.Double sigma ,  System.Int32 numOfAngleLine );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean img_hash_Ptr_RadialVarianceHash_delete_excsafe( System.IntPtr ptr );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean img_hash_Ptr_RadialVarianceHash_get_excsafe(ref System.IntPtr ret,  System.IntPtr ptr );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean img_hash_RadialVarianceHash_setNumOfAngleLine_excsafe( System.IntPtr obj ,  System.Int32 value );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean img_hash_RadialVarianceHash_setSigma_excsafe( System.IntPtr obj ,  System.Double value );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean img_hash_RadialVarianceHash_getNumOfAngleLine_excsafe(ref System.Int32 ret,  System.IntPtr obj );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean img_hash_RadialVarianceHash_getSigma_excsafe(ref System.Double ret,  System.IntPtr obj );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean highgui_waitKey_excsafe(ref System.Int32 ret,  System.Int32 delay );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean highgui_waitKeyEx_excsafe(ref System.Int32 ret,  System.Int32 delay );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean highgui_resizeWindow_excsafe([MarshalAs(UnmanagedType.LPStr)] System.String winName ,  System.Int32 width ,  System.Int32 height );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean highgui_moveWindow_excsafe([MarshalAs(UnmanagedType.LPStr)] System.String winName ,  System.Int32 x ,  System.Int32 y );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean highgui_setWindowProperty_excsafe([MarshalAs(UnmanagedType.LPStr)] System.String winName ,  System.Int32 propId ,  System.Double propValue );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean highgui_setWindowTitle_excsafe([MarshalAs(UnmanagedType.LPStr)] System.String winname , [MarshalAs(UnmanagedType.LPStr)] System.String title );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean highgui_getWindowProperty_excsafe(ref System.Double ret, [MarshalAs(UnmanagedType.LPStr)] System.String winName ,  System.Int32 propId );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean highgui_setMouseCallback_excsafe( System.String winName , [MarshalAs(UnmanagedType.FunctionPtr)] OpenCvSharp.CvMouseCallback onMouse ,  System.IntPtr userData );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean highgui_getMouseWheelDelta_excsafe(ref System.Int32 ret,  System.Int32 flags );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean highgui_createTrackbar_excsafe(ref System.Int32 ret, [MarshalAs(UnmanagedType.LPStr)] System.String trackbarName , [MarshalAs(UnmanagedType.LPStr)] System.String winName ,  ref System.Int32 value ,  System.Int32 count ,  System.IntPtr onChange ,  System.IntPtr userData );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean highgui_createTrackbar_excsafe(ref System.Int32 ret, [MarshalAs(UnmanagedType.LPStr)] System.String trackbarName , [MarshalAs(UnmanagedType.LPStr)] System.String winName ,  ref System.Int32 value ,  System.Int32 count , [MarshalAs(UnmanagedType.FunctionPtr)] OpenCvSharp.CvTrackbarCallback2 onChange ,  System.IntPtr userData );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean highgui_getTrackbarPos_excsafe(ref System.Int32 ret, [MarshalAs(UnmanagedType.LPStr)] System.String trackbarName , [MarshalAs(UnmanagedType.LPStr)] System.String winName );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean highgui_setTrackbarPos_excsafe( System.String trackbarName ,  System.String winName ,  System.Int32 pos );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean highgui_setTrackbarMax_excsafe([MarshalAs(UnmanagedType.LPStr)] System.String trackbarname , [MarshalAs(UnmanagedType.LPStr)] System.String winname ,  System.Int32 maxval );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean highgui_setTrackbarMin_excsafe([MarshalAs(UnmanagedType.LPStr)] System.String trackbarname , [MarshalAs(UnmanagedType.LPStr)] System.String winname ,  System.Int32 minval );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean highgui_createButton_excsafe(ref System.Int32 ret, [MarshalAs(UnmanagedType.LPStr)] System.String barName ,  System.IntPtr onChange ,  System.IntPtr userdata ,  System.Int32 type ,  System.Int32 initialButtonState );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean imgcodecs_imread_excsafe(ref System.IntPtr ret,  System.String filename ,  System.Int32 flags );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean imgcodecs_imreadmulti_excsafe(ref System.Int32 ret, [MarshalAs(UnmanagedType.LPStr)] System.String filename ,  System.IntPtr mats ,  System.Int32 flags );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean imgcodecs_imwrite_excsafe(ref System.Int32 ret, [MarshalAs(UnmanagedType.LPStr)] System.String filename ,  System.IntPtr img , [In] System.Int32[] @params ,  System.Int32 paramsLength );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean imgcodecs_imdecode_Mat_excsafe(ref System.IntPtr ret,  System.IntPtr buf ,  System.Int32 flags );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean imgcodecs_imdecode_vector_excsafe(ref System.IntPtr ret,  System.Byte[] buf ,  System.IntPtr bufLength ,  System.Int32 flags );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean imgcodecs_imdecode_InputArray_excsafe(ref System.IntPtr ret,  System.IntPtr buf ,  System.Int32 flags );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean imgcodecs_imencode_vector_excsafe(ref System.Int32 ret, [MarshalAs(UnmanagedType.LPStr)] System.String ext ,  System.IntPtr img ,  System.IntPtr buf , [In] System.Int32[] @params ,  System.Int32 paramsLength );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean imgcodecs_cvConvertImage_CvArr_excsafe( System.IntPtr src ,  System.IntPtr dst ,  System.Int32 flags );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean imgcodecs_cvConvertImage_Mat_excsafe( System.IntPtr src ,  System.IntPtr dst ,  System.Int32 flags );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean imgcodecs_cvHaveImageReader_excsafe(ref System.Int32 ret, [MarshalAs(UnmanagedType.LPStr)] System.String fileName );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean imgcodecs_cvHaveImageWriter_excsafe(ref System.Int32 ret, [MarshalAs(UnmanagedType.LPStr)] System.String fileName );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean img_hash_ImgHashBase_compute_excsafe( System.IntPtr obj ,  System.IntPtr inputArr ,  System.IntPtr outputArr );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean flann_Ptr_LshIndexParams_new_excsafe(ref System.IntPtr ret,  System.Int32 tableNumber ,  System.Int32 keySize ,  System.Int32 multiProbeLevel );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean flann_Ptr_LshIndexParams_get_excsafe(ref System.IntPtr ret,  System.IntPtr ptr );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean flann_Ptr_LshIndexParams_delete_excsafe( System.IntPtr obj );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean flann_CompositeIndexParams_new_excsafe(ref System.IntPtr ret,  System.Int32 trees ,  System.Int32 branching ,  System.Int32 iterations ,  OpenCvSharp.Flann.FlannCentersInit centersInit ,  System.Single cbIndex );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean flann_CompositeIndexParams_delete_excsafe( System.IntPtr obj );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean flann_Ptr_CompositeIndexParams_new_excsafe(ref System.IntPtr ret,  System.Int32 trees ,  System.Int32 branching ,  System.Int32 iterations ,  OpenCvSharp.Flann.FlannCentersInit centersInit ,  System.Single cbIndex );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean flann_Ptr_CompositeIndexParams_get_excsafe(ref System.IntPtr ret,  System.IntPtr ptr );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean flann_Ptr_CompositeIndexParams_delete_excsafe( System.IntPtr obj );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean flann_AutotunedIndexParams_new_excsafe(ref System.IntPtr ret,  System.Single targetPrecision ,  System.Single buildWeight ,  System.Single memoryWeight ,  System.Single sampleFraction );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean flann_AutotunedIndexParams_delete_excsafe( System.IntPtr obj );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean flann_Ptr_AutotunedIndexParams_new_excsafe(ref System.IntPtr ret,  System.Single targetPrecision ,  System.Single buildWeight ,  System.Single memoryWeight ,  System.Single sampleFraction );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean flann_Ptr_AutotunedIndexParams_get_excsafe(ref System.IntPtr ret,  System.IntPtr ptr );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean flann_Ptr_AutotunedIndexParams_delete_excsafe( System.IntPtr obj );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean flann_SavedIndexParams_new_excsafe(ref System.IntPtr ret, [MarshalAs(UnmanagedType.LPStr)] System.String filename );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean flann_SavedIndexParams_delete_excsafe( System.IntPtr obj );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean flann_Ptr_SavedIndexParams_new_excsafe(ref System.IntPtr ret, [MarshalAs(UnmanagedType.LPStr)] System.String filename );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean flann_Ptr_SavedIndexParams_get_excsafe(ref System.IntPtr ret,  System.IntPtr ptr );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean flann_Ptr_SavedIndexParams_delete_excsafe( System.IntPtr obj );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean flann_SearchParams_new_excsafe(ref System.IntPtr ret,  System.Int32 checks ,  System.Single eps ,  System.Int32 sorted );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean flann_SearchParams_delete_excsafe( System.IntPtr obj );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean flann_Ptr_SearchParams_new_excsafe(ref System.IntPtr ret,  System.Int32 checks ,  System.Single eps ,  System.Int32 sorted );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean flann_Ptr_SearchParams_get_excsafe(ref System.IntPtr ret,  System.IntPtr ptr );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean flann_Ptr_SearchParams_delete_excsafe( System.IntPtr obj );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean highgui_namedWindow_excsafe([MarshalAs(UnmanagedType.LPStr)] System.String winname ,  System.Int32 flags );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean highgui_destroyWindow_excsafe([MarshalAs(UnmanagedType.LPStr)] System.String winName );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean highgui_destroyAllWindows_excsafe();

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean highgui_imshow_excsafe([MarshalAs(UnmanagedType.LPStr)] System.String winname ,  System.IntPtr mat );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean highgui_startWindowThread_excsafe(ref System.Int32 ret);

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean flann_Ptr_IndexParams_get_excsafe(ref System.IntPtr ret,  System.IntPtr ptr );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean flann_Ptr_IndexParams_delete_excsafe( System.IntPtr obj );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean flann_IndexParams_getString_excsafe( System.IntPtr obj , [MarshalAs(UnmanagedType.LPStr)] System.String key , [MarshalAs(UnmanagedType.LPStr)] System.String defaultVal , [MarshalAs(UnmanagedType.LPStr)] System.Text.StringBuilder result );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean flann_IndexParams_getInt_excsafe(ref System.Int32 ret,  System.IntPtr obj , [MarshalAs(UnmanagedType.LPStr)] System.String key ,  System.Int32 defaultVal );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean flann_IndexParams_getDouble_excsafe(ref System.Double ret,  System.IntPtr obj , [MarshalAs(UnmanagedType.LPStr)] System.String key ,  System.Double defaultVal );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean flann_IndexParams_setString_excsafe( System.IntPtr obj , [MarshalAs(UnmanagedType.LPStr)] System.String key , [MarshalAs(UnmanagedType.LPStr)] System.String value );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean flann_IndexParams_setInt_excsafe( System.IntPtr obj , [MarshalAs(UnmanagedType.LPStr)] System.String key ,  System.Int32 value );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean flann_IndexParams_setDouble_excsafe( System.IntPtr obj , [MarshalAs(UnmanagedType.LPStr)] System.String key ,  System.Double value );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean flann_IndexParams_setFloat_excsafe( System.IntPtr obj , [MarshalAs(UnmanagedType.LPStr)] System.String key ,  System.Single value );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean flann_IndexParams_setBool_excsafe( System.IntPtr obj , [MarshalAs(UnmanagedType.LPStr)] System.String key ,  System.Int32 value );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean flann_IndexParams_setAlgorithm_excsafe( System.IntPtr obj ,  System.Int32 value );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean flann_LinearIndexParams_new_excsafe(ref System.IntPtr ret);

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean flann_LinearIndexParams_delete_excsafe( System.IntPtr obj );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean flann_Ptr_LinearIndexParams_new_excsafe(ref System.IntPtr ret);

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean flann_Ptr_LinearIndexParams_get_excsafe(ref System.IntPtr ret,  System.IntPtr ptr );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean flann_Ptr_LinearIndexParams_delete_excsafe( System.IntPtr obj );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean flann_KDTreeIndexParams_new_excsafe(ref System.IntPtr ret,  System.Int32 trees );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean flann_KDTreeIndexParams_delete_excsafe( System.IntPtr obj );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean flann_Ptr_KDTreeIndexParams_new_excsafe(ref System.IntPtr ret,  System.Int32 trees );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean flann_Ptr_KDTreeIndexParams_get_excsafe(ref System.IntPtr ret,  System.IntPtr ptr );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean flann_Ptr_KDTreeIndexParams_delete_excsafe( System.IntPtr obj );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean flann_KMeansIndexParams_new_excsafe(ref System.IntPtr ret,  System.Int32 branching ,  System.Int32 iterations , [MarshalAs(UnmanagedType.I4)] OpenCvSharp.Flann.FlannCentersInit centersInit ,  System.Single cbIndex );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean flann_KMeansIndexParams_delete_excsafe( System.IntPtr obj );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean flann_Ptr_KMeansIndexParams_new_excsafe(ref System.IntPtr ret,  System.Int32 branching ,  System.Int32 iterations , [MarshalAs(UnmanagedType.I4)] OpenCvSharp.Flann.FlannCentersInit centersInit ,  System.Single cbIndex );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean flann_Ptr_KMeansIndexParams_get_excsafe(ref System.IntPtr ret,  System.IntPtr ptr );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean flann_Ptr_KMeansIndexParams_delete_excsafe( System.IntPtr obj );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean flann_LshIndexParams_new_excsafe(ref System.IntPtr ret,  System.Int32 tableNumber ,  System.Int32 keySize ,  System.Int32 multiProbeLevel );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean flann_LshIndexParams_delete_excsafe( System.IntPtr obj );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean bgsegm_BackgroundSubtractorGMG_getNumFrames_excsafe(ref System.Int32 ret,  System.IntPtr ptr );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean bgsegm_BackgroundSubtractorGMG_setNumFrames_excsafe( System.IntPtr ptr ,  System.Int32 value );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean bgsegm_BackgroundSubtractorGMG_getQuantizationLevels_excsafe(ref System.Int32 ret,  System.IntPtr ptr );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean bgsegm_BackgroundSubtractorGMG_setQuantizationLevels_excsafe( System.IntPtr ptr ,  System.Int32 value );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean bgsegm_BackgroundSubtractorGMG_getBackgroundPrior_excsafe(ref System.Double ret,  System.IntPtr ptr );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean bgsegm_BackgroundSubtractorGMG_setBackgroundPrior_excsafe( System.IntPtr ptr ,  System.Double value );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean bgsegm_BackgroundSubtractorGMG_getSmoothingRadius_excsafe(ref System.Int32 ret,  System.IntPtr ptr );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean bgsegm_BackgroundSubtractorGMG_setSmoothingRadius_excsafe( System.IntPtr ptr ,  System.Int32 value );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean bgsegm_BackgroundSubtractorGMG_getDecisionThreshold_excsafe(ref System.Double ret,  System.IntPtr ptr );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean bgsegm_BackgroundSubtractorGMG_setDecisionThreshold_excsafe( System.IntPtr ptr ,  System.Double value );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean bgsegm_BackgroundSubtractorGMG_getUpdateBackgroundModel_excsafe(ref System.Int32 ret,  System.IntPtr ptr );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean bgsegm_BackgroundSubtractorGMG_setUpdateBackgroundModel_excsafe( System.IntPtr ptr ,  System.Int32 value );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean bgsegm_BackgroundSubtractorGMG_getMinVal_excsafe(ref System.Double ret,  System.IntPtr ptr );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean bgsegm_BackgroundSubtractorGMG_setMinVal_excsafe( System.IntPtr ptr ,  System.Double value );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean bgsegm_BackgroundSubtractorGMG_getMaxVal_excsafe(ref System.Double ret,  System.IntPtr ptr );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean bgsegm_BackgroundSubtractorGMG_setMaxVal_excsafe( System.IntPtr ptr ,  System.Double value );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean flann_Index_new_excsafe(ref System.IntPtr ret,  System.IntPtr features ,  System.IntPtr @params ,  System.Int32 distType );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean flann_Index_delete_excsafe( System.IntPtr obj );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean flann_Index_knnSearch1_excsafe( System.IntPtr obj , [In] System.Single[] queries ,  System.Int32 queriesLength , [Out] System.Int32[] indices , [Out] System.Single[] dists ,  System.Int32 knn ,  System.IntPtr @params );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean flann_Index_knnSearch2_excsafe( System.IntPtr obj ,  System.IntPtr queries ,  System.IntPtr indices ,  System.IntPtr dists ,  System.Int32 knn ,  System.IntPtr @params );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean flann_Index_knnSearch3_excsafe( System.IntPtr obj ,  System.IntPtr queries , [Out] System.Int32[] indices , [Out] System.Single[] dists ,  System.Int32 knn ,  System.IntPtr @params );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean flann_Index_radiusSearch1_excsafe( System.IntPtr obj , [In] System.Single[] queries ,  System.Int32 queriesLength , [Out] System.Int32[] indices ,  System.Int32 indicesLength , [Out] System.Single[] dists ,  System.Int32 dists_length ,  System.Single radius ,  System.Int32 maxResults ,  System.IntPtr @params );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean flann_Index_radiusSearch2_excsafe( System.IntPtr obj ,  System.IntPtr queries ,  System.IntPtr indices ,  System.IntPtr dists ,  System.Single radius ,  System.Int32 maxResults ,  System.IntPtr @params );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean flann_Index_radiusSearch3_excsafe( System.IntPtr obj ,  System.IntPtr queries , [Out] System.Int32[] indices ,  System.Int32 indicesLength , [Out] System.Single[] dists ,  System.Int32 distsLength ,  System.Single radius ,  System.Int32 maxResults ,  System.IntPtr @params );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean flann_Index_save_excsafe( System.IntPtr obj , [MarshalAs(UnmanagedType.LPStr)] System.String filename );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean flann_IndexParams_new_excsafe(ref System.IntPtr ret);

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean flann_IndexParams_delete_excsafe( System.IntPtr obj );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean flann_Ptr_IndexParams_new_excsafe(ref System.IntPtr ret);

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean aruco_DetectorParameters_getMarkerBorderBits_excsafe(ref System.Int32 ret,  System.IntPtr obj );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean aruco_DetectorParameters_getMinDistanceToBorder_excsafe(ref System.Int32 ret,  System.IntPtr obj );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean aruco_DetectorParameters_getPerspectiveRemovePixelPerCell_excsafe(ref System.Int32 ret,  System.IntPtr obj );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean aruco_Ptr_Dictionary_delete_excsafe( System.IntPtr ptr );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean aruco_Ptr_Dictionary_get_excsafe(ref System.IntPtr ret,  System.IntPtr ptr );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean aruco_Dictionary_setMarkerSize_excsafe( System.IntPtr obj ,  System.Int32 value );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean aruco_Dictionary_setMaxCorrectionBits_excsafe( System.IntPtr obj ,  System.Int32 value );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean aruco_Dictionary_getBytesList_excsafe(ref System.IntPtr ret,  System.IntPtr obj );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean aruco_Dictionary_getMarkerSize_excsafe(ref System.Int32 ret,  System.IntPtr obj );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean aruco_Dictionary_getMaxCorrectionBits_excsafe(ref System.Int32 ret,  System.IntPtr obj );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean bgsegm_createBackgroundSubtractorMOG_excsafe(ref System.IntPtr ret,  System.Int32 history ,  System.Int32 nmixtures ,  System.Double backgroundRatio ,  System.Double noiseSigma );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean bgsegm_Ptr_BackgroundSubtractorMOG_delete_excsafe( System.IntPtr obj );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean bgsegm_Ptr_BackgroundSubtractorMOG_get_excsafe(ref System.IntPtr ret,  System.IntPtr ptr );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean bgsegm_BackgroundSubtractorMOG_getHistory_excsafe(ref System.Int32 ret,  System.IntPtr ptr );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean bgsegm_BackgroundSubtractorMOG_setHistory_excsafe( System.IntPtr ptr ,  System.Int32 value );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean bgsegm_BackgroundSubtractorMOG_getNMixtures_excsafe(ref System.Int32 ret,  System.IntPtr ptr );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean bgsegm_BackgroundSubtractorMOG_setNMixtures_excsafe( System.IntPtr ptr ,  System.Int32 value );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean bgsegm_BackgroundSubtractorMOG_getBackgroundRatio_excsafe(ref System.Double ret,  System.IntPtr ptr );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean bgsegm_BackgroundSubtractorMOG_setBackgroundRatio_excsafe( System.IntPtr ptr ,  System.Double value );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean bgsegm_BackgroundSubtractorMOG_getNoiseSigma_excsafe(ref System.Double ret,  System.IntPtr ptr );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean bgsegm_BackgroundSubtractorMOG_setNoiseSigma_excsafe( System.IntPtr ptr ,  System.Double value );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean bgsegm_createBackgroundSubtractorGMG_excsafe(ref System.IntPtr ret,  System.Int32 initializationFrames ,  System.Double decisionThreshold );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean bgsegm_Ptr_BackgroundSubtractorGMG_delete_excsafe( System.IntPtr obj );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean bgsegm_Ptr_BackgroundSubtractorGMG_get_excsafe(ref System.IntPtr ret,  System.IntPtr ptr );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean bgsegm_BackgroundSubtractorGMG_getMaxFeatures_excsafe(ref System.Int32 ret,  System.IntPtr ptr );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean bgsegm_BackgroundSubtractorGMG_setMaxFeatures_excsafe( System.IntPtr ptr ,  System.Int32 value );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean bgsegm_BackgroundSubtractorGMG_getDefaultLearningRate_excsafe(ref System.Double ret,  System.IntPtr ptr );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean bgsegm_BackgroundSubtractorGMG_setDefaultLearningRate_excsafe( System.IntPtr ptr ,  System.Double value );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean aruco_DetectorParameters_setMinOtsuStdDev_excsafe( System.IntPtr obj ,  System.Double value );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean aruco_DetectorParameters_setPerspectiveRemoveIgnoredMarginPerCell_excsafe( System.IntPtr obj ,  System.Double value );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean aruco_DetectorParameters_setPolygonalApproxAccuracyRate_excsafe( System.IntPtr obj ,  System.Double value );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean aruco_DetectorParameters_setAdaptiveThreshWinSizeMax_excsafe( System.IntPtr obj ,  System.Int32 value );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean aruco_DetectorParameters_setAdaptiveThreshWinSizeMin_excsafe( System.IntPtr obj ,  System.Int32 value );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean aruco_DetectorParameters_setAdaptiveThreshWinSizeStep_excsafe( System.IntPtr obj ,  System.Int32 value );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean aruco_DetectorParameters_setCornerRefinementMaxIterations_excsafe( System.IntPtr obj ,  System.Int32 value );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean aruco_DetectorParameters_setCornerRefinementWinSize_excsafe( System.IntPtr obj ,  System.Int32 value );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean aruco_DetectorParameters_setMarkerBorderBits_excsafe( System.IntPtr obj ,  System.Int32 value );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean aruco_DetectorParameters_setMinDistanceToBorder_excsafe( System.IntPtr obj ,  System.Int32 value );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean aruco_DetectorParameters_setPerspectiveRemovePixelPerCell_excsafe( System.IntPtr obj ,  System.Int32 value );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean aruco_DetectorParameters_getDoCornerRefinement_excsafe(ref System.Boolean ret,  System.IntPtr obj );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean aruco_DetectorParameters_getAdaptiveThreshConstant_excsafe(ref System.Double ret,  System.IntPtr obj );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean aruco_DetectorParameters_getCornerRefinementMinAccuracy_excsafe(ref System.Double ret,  System.IntPtr obj );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean aruco_DetectorParameters_getErrorCorrectionRate_excsafe(ref System.Double ret,  System.IntPtr obj );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean aruco_DetectorParameters_getMaxErroneousBitsInBorderRate_excsafe(ref System.Double ret,  System.IntPtr obj );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean aruco_DetectorParameters_getMaxMarkerPerimeterRate_excsafe(ref System.Double ret,  System.IntPtr obj );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean aruco_DetectorParameters_getMinCornerDistanceRate_excsafe(ref System.Double ret,  System.IntPtr obj );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean aruco_DetectorParameters_getMinMarkerDistanceRate_excsafe(ref System.Double ret,  System.IntPtr obj );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean aruco_DetectorParameters_getMinMarkerPerimeterRate_excsafe(ref System.Double ret,  System.IntPtr obj );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean aruco_DetectorParameters_getMinOtsuStdDev_excsafe(ref System.Double ret,  System.IntPtr obj );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean aruco_DetectorParameters_getPerspectiveRemoveIgnoredMarginPerCell_excsafe(ref System.Double ret,  System.IntPtr obj );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean aruco_DetectorParameters_getPolygonalApproxAccuracyRate_excsafe(ref System.Double ret,  System.IntPtr obj );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean aruco_DetectorParameters_getAdaptiveThreshWinSizeMax_excsafe(ref System.Int32 ret,  System.IntPtr obj );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean aruco_DetectorParameters_getAdaptiveThreshWinSizeMin_excsafe(ref System.Int32 ret,  System.IntPtr obj );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean aruco_DetectorParameters_getAdaptiveThreshWinSizeStep_excsafe(ref System.Int32 ret,  System.IntPtr obj );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean aruco_DetectorParameters_getCornerRefinementMaxIterations_excsafe(ref System.Int32 ret,  System.IntPtr obj );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean aruco_DetectorParameters_getCornerRefinementWinSize_excsafe(ref System.Int32 ret,  System.IntPtr obj );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean ml_SVM_setKernel_excsafe( System.IntPtr obj ,  System.Int32 kernelType );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean ml_SVM_getSupportVectors_excsafe(ref System.IntPtr ret,  System.IntPtr obj );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean ml_SVM_getDecisionFunction_excsafe(ref System.Double ret,  System.IntPtr obj ,  System.Int32 i ,  System.IntPtr alpha ,  System.IntPtr svidx );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean ml_SVM_getDefaultGrid_excsafe(ref OpenCvSharp.ML.ParamGrid ret,  System.Int32 paramId );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean ml_SVM_create_excsafe(ref System.IntPtr ret);

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean ml_Ptr_SVM_delete_excsafe( System.IntPtr obj );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean ml_Ptr_SVM_get_excsafe(ref System.IntPtr ret,  System.IntPtr obj );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean ml_SVM_load_excsafe(ref System.IntPtr ret,  System.String filePath );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean ml_SVM_loadFromString_excsafe(ref System.IntPtr ret,  System.String strModel );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean aruco_getPredefinedDictionary_excsafe(ref System.IntPtr ret,  System.Int32 name );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean aruco_detectMarkers_excsafe( System.IntPtr image ,  System.IntPtr dictionary ,  System.IntPtr corners ,  System.IntPtr ids ,  System.IntPtr detectParameters ,  System.IntPtr outrejectedImgPoints );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean aruco_drawDetectedMarkers_excsafe( System.IntPtr image , [MarshalAs(UnmanagedType.LPArray)] System.IntPtr[] corners ,  System.Int32 cornerSize1 ,  System.Int32[] contoursSize2 , [MarshalAs(UnmanagedType.LPArray)] System.Int32[] ids ,  System.Int32 idxLength ,  OpenCvSharp.Scalar borderColor );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean aruco_drawDetectedMarkers_excsafe( System.IntPtr image , [MarshalAs(UnmanagedType.LPArray)] System.IntPtr[] corners ,  System.Int32 cornerSize1 ,  System.Int32[] contoursSize2 ,  System.IntPtr ids ,  System.Int32 idxLength ,  OpenCvSharp.Scalar borderColor );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean aruco_drawMarker_excsafe( System.IntPtr dictionary ,  System.Int32 id ,  System.Int32 sidePixels ,  System.IntPtr mat ,  System.Int32 borderBits );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean aruco_estimatePoseSingleMarkers_excsafe([MarshalAs(UnmanagedType.LPArray)] System.IntPtr[] corners ,  System.Int32 cornersLength1 ,  System.Int32[] cornersLengths2 ,  System.Single markerLength ,  System.IntPtr cameraMatrix ,  System.IntPtr distCoeffs ,  System.IntPtr rvecs ,  System.IntPtr tvecs ,  System.IntPtr objPoints );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean aruco_DetectorParameters_create_excsafe(ref System.IntPtr ret);

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean aruco_Ptr_DetectorParameters_delete_excsafe( System.IntPtr obj );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean aruco_Ptr_DetectorParameters_get_excsafe(ref System.IntPtr ret,  System.IntPtr obj );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean aruco_DetectorParameters_setDoCornerRefinement_excsafe( System.IntPtr obj ,  System.Boolean value );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean aruco_DetectorParameters_setAdaptiveThreshConstant_excsafe( System.IntPtr obj ,  System.Double value );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean aruco_DetectorParameters_setCornerRefinementMinAccuracy_excsafe( System.IntPtr obj ,  System.Double value );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean aruco_DetectorParameters_setErrorCorrectionRate_excsafe( System.IntPtr obj ,  System.Double value );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean aruco_DetectorParameters_setMaxErroneousBitsInBorderRate_excsafe( System.IntPtr obj ,  System.Double value );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean aruco_DetectorParameters_setMaxMarkerPerimeterRate_excsafe( System.IntPtr obj ,  System.Double value );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean aruco_DetectorParameters_setMinCornerDistanceRate_excsafe( System.IntPtr obj ,  System.Double value );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean aruco_DetectorParameters_setMinMarkerDistanceRate_excsafe( System.IntPtr obj ,  System.Double value );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean aruco_DetectorParameters_setMinMarkerPerimeterRate_excsafe( System.IntPtr obj ,  System.Double value );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean ml_StatModel_getVarCount_excsafe(ref System.Int32 ret,  System.IntPtr obj );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean ml_StatModel_empty_excsafe(ref System.Int32 ret,  System.IntPtr obj );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean ml_StatModel_isTrained_excsafe(ref System.Int32 ret,  System.IntPtr obj );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean ml_StatModel_isClassifier_excsafe(ref System.Int32 ret,  System.IntPtr obj );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean ml_StatModel_train1_excsafe(ref System.Int32 ret,  System.IntPtr obj ,  System.IntPtr trainData ,  System.Int32 flags );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean ml_StatModel_train2_excsafe(ref System.Int32 ret,  System.IntPtr obj ,  System.IntPtr samples ,  System.Int32 layout ,  System.IntPtr responses );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean ml_StatModel_calcError_excsafe(ref System.Single ret,  System.IntPtr obj ,  System.IntPtr data ,  System.Int32 test ,  System.IntPtr resp );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean ml_StatModel_predict_excsafe(ref System.Single ret,  System.IntPtr obj ,  System.IntPtr samples ,  System.IntPtr results ,  System.Int32 flags );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean ml_StatModel_save_excsafe( System.IntPtr obj ,  System.String filename );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean ml_SVM_getType_excsafe(ref System.Int32 ret,  System.IntPtr obj );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean ml_SVM_setType_excsafe( System.IntPtr obj ,  System.Int32 val );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean ml_SVM_getGamma_excsafe(ref System.Double ret,  System.IntPtr obj );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean ml_SVM_setGamma_excsafe( System.IntPtr obj ,  System.Double val );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean ml_SVM_getCoef0_excsafe(ref System.Double ret,  System.IntPtr obj );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean ml_SVM_setCoef0_excsafe( System.IntPtr obj ,  System.Double val );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean ml_SVM_getDegree_excsafe(ref System.Double ret,  System.IntPtr obj );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean ml_SVM_setDegree_excsafe( System.IntPtr obj ,  System.Double val );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean ml_SVM_getC_excsafe(ref System.Double ret,  System.IntPtr obj );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean ml_SVM_setC_excsafe( System.IntPtr obj ,  System.Double val );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean ml_SVM_getP_excsafe(ref System.Double ret,  System.IntPtr obj );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean ml_SVM_setP_excsafe( System.IntPtr obj ,  System.Double val );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean ml_SVM_getNu_excsafe(ref System.Double ret,  System.IntPtr obj );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean ml_SVM_setNu_excsafe( System.IntPtr obj ,  System.Double val );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean ml_SVM_getClassWeights_excsafe(ref System.IntPtr ret,  System.IntPtr obj );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean ml_SVM_setClassWeights_excsafe( System.IntPtr obj ,  System.IntPtr val );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean ml_SVM_getTermCriteria_excsafe(ref OpenCvSharp.TermCriteria ret,  System.IntPtr obj );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean ml_SVM_setTermCriteria_excsafe( System.IntPtr obj ,  OpenCvSharp.TermCriteria val );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean ml_SVM_getKernelType_excsafe(ref System.Int32 ret,  System.IntPtr obj );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean ml_LogisticRegression_getTermCriteria_excsafe(ref OpenCvSharp.TermCriteria ret,  System.IntPtr obj );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean ml_LogisticRegression_setTermCriteria_excsafe( System.IntPtr obj ,  OpenCvSharp.TermCriteria val );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean ml_LogisticRegression_predict_excsafe(ref System.Single ret,  System.IntPtr obj ,  System.IntPtr samples ,  System.IntPtr results ,  System.Int32 flags );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean ml_LogisticRegression_get_learnt_thetas_excsafe(ref System.IntPtr ret,  System.IntPtr obj );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean ml_LogisticRegression_create_excsafe(ref System.IntPtr ret);

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean ml_Ptr_LogisticRegression_delete_excsafe( System.IntPtr obj );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean ml_Ptr_LogisticRegression_get_excsafe(ref System.IntPtr ret,  System.IntPtr obj );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean ml_LogisticRegression_load_excsafe(ref System.IntPtr ret,  System.String filePath );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean ml_LogisticRegression_loadFromString_excsafe(ref System.IntPtr ret,  System.String strModel );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean ml_NormalBayesClassifier_predictProb_excsafe(ref System.Single ret,  System.IntPtr obj ,  System.IntPtr inputs ,  System.IntPtr samples ,  System.IntPtr outputProbs ,  System.Int32 flags );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean ml_NormalBayesClassifier_create_excsafe(ref System.IntPtr ret);

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean ml_Ptr_NormalBayesClassifier_delete_excsafe( System.IntPtr obj );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean ml_Ptr_NormalBayesClassifier_get_excsafe(ref System.IntPtr ret,  System.IntPtr obj );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean ml_NormalBayesClassifier_load_excsafe(ref System.IntPtr ret,  System.String filePath );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean ml_NormalBayesClassifier_loadFromString_excsafe(ref System.IntPtr ret,  System.String strModel );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean ml_RTrees_getCalculateVarImportance_excsafe(ref System.Int32 ret,  System.IntPtr obj );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean ml_RTrees_setCalculateVarImportance_excsafe( System.IntPtr obj ,  System.Int32 val );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean ml_RTrees_getActiveVarCount_excsafe(ref System.Int32 ret,  System.IntPtr obj );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean ml_RTrees_setActiveVarCount_excsafe( System.IntPtr obj ,  System.Int32 val );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean ml_RTrees_getTermCriteria_excsafe(ref OpenCvSharp.TermCriteria ret,  System.IntPtr obj );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean ml_RTrees_setTermCriteria_excsafe( System.IntPtr obj ,  OpenCvSharp.TermCriteria val );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean ml_RTrees_getVarImportance_excsafe(ref System.IntPtr ret,  System.IntPtr obj );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean ml_RTrees_create_excsafe(ref System.IntPtr ret);

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean ml_Ptr_RTrees_delete_excsafe( System.IntPtr obj );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean ml_Ptr_RTrees_get_excsafe(ref System.IntPtr ret,  System.IntPtr obj );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean ml_RTrees_load_excsafe(ref System.IntPtr ret,  System.String filePath );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean ml_RTrees_loadFromString_excsafe(ref System.IntPtr ret,  System.String strModel );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean ml_StatModel_clear_excsafe( System.IntPtr obj );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean ml_Ptr_EM_get_excsafe(ref System.IntPtr ret,  System.IntPtr ptr );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean ml_Ptr_EM_delete_excsafe( System.IntPtr ptr );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean ml_EM_load_excsafe(ref System.IntPtr ret,  System.String filePath );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean ml_EM_loadFromString_excsafe(ref System.IntPtr ret,  System.String strModel );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean ml_KNearest_getDefaultK_excsafe(ref System.Int32 ret,  System.IntPtr obj );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean ml_KNearest_setDefaultK_excsafe( System.IntPtr obj ,  System.Int32 val );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean ml_KNearest_getIsClassifier_excsafe(ref System.Int32 ret,  System.IntPtr obj );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean ml_KNearest_setIsClassifier_excsafe( System.IntPtr obj ,  System.Int32 val );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean ml_KNearest_getEmax_excsafe(ref System.Int32 ret,  System.IntPtr obj );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean ml_KNearest_setEmax_excsafe( System.IntPtr obj ,  System.Int32 val );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean ml_KNearest_getAlgorithmType_excsafe(ref System.Int32 ret,  System.IntPtr obj );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean ml_KNearest_setAlgorithmType_excsafe( System.IntPtr obj ,  System.Int32 val );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean ml_KNearest_findNearest_excsafe(ref System.Single ret,  System.IntPtr obj ,  System.IntPtr samples ,  System.Int32 k ,  System.IntPtr results ,  System.IntPtr neighborResponses ,  System.IntPtr dist );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean ml_KNearest_create_excsafe(ref System.IntPtr ret);

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean ml_Ptr_KNearest_delete_excsafe( System.IntPtr obj );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean ml_Ptr_KNearest_get_excsafe(ref System.IntPtr ret,  System.IntPtr obj );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean ml_KNearest_load_excsafe(ref System.IntPtr ret,  System.String filePath );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean ml_KNearest_loadFromString_excsafe(ref System.IntPtr ret,  System.String strModel );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean ml_LogisticRegression_getLearningRate_excsafe(ref System.Double ret,  System.IntPtr obj );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean ml_LogisticRegression_setLearningRate_excsafe( System.IntPtr obj ,  System.Double val );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean ml_LogisticRegression_getIterations_excsafe(ref System.Int32 ret,  System.IntPtr obj );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean ml_LogisticRegression_setIterations_excsafe( System.IntPtr obj ,  System.Int32 val );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean ml_LogisticRegression_getRegularization_excsafe(ref System.Int32 ret,  System.IntPtr obj );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean ml_LogisticRegression_setRegularization_excsafe( System.IntPtr obj ,  System.Int32 val );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean ml_LogisticRegression_getTrainMethod_excsafe(ref System.Int32 ret,  System.IntPtr obj );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean ml_LogisticRegression_setTrainMethod_excsafe( System.IntPtr obj ,  System.Int32 val );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean ml_LogisticRegression_getMiniBatchSize_excsafe(ref System.Int32 ret,  System.IntPtr obj );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean ml_LogisticRegression_setMiniBatchSize_excsafe( System.IntPtr obj ,  System.Int32 val );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean ml_DTrees_setTruncatePrunedTree_excsafe( System.IntPtr obj ,  System.Int32 val );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean ml_DTrees_getRegressionAccuracy_excsafe(ref System.Single ret,  System.IntPtr obj );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean ml_DTrees_setRegressionAccuracy_excsafe( System.IntPtr obj ,  System.Single val );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean ml_DTrees_getPriors_excsafe(ref System.IntPtr ret,  System.IntPtr obj );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean ml_DTrees_setPriors_excsafe( System.IntPtr obj ,  System.IntPtr val );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean ml_DTrees_getRoots_excsafe( System.IntPtr obj ,  System.IntPtr result );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean ml_DTrees_getNodes_excsafe( System.IntPtr obj ,  System.IntPtr result );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean ml_DTrees_getSplits_excsafe( System.IntPtr obj ,  System.IntPtr result );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean ml_DTrees_getSubsets_excsafe( System.IntPtr obj ,  System.IntPtr result );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean ml_DTrees_create_excsafe(ref System.IntPtr ret);

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean ml_Ptr_DTrees_delete_excsafe( System.IntPtr obj );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean ml_Ptr_DTrees_get_excsafe(ref System.IntPtr ret,  System.IntPtr obj );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean ml_DTrees_load_excsafe(ref System.IntPtr ret,  System.String filePath );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean ml_DTrees_loadFromString_excsafe(ref System.IntPtr ret,  System.String strModel );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean ml_EM_getClustersNumber_excsafe(ref System.Int32 ret,  System.IntPtr obj );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean ml_EM_setClustersNumber_excsafe( System.IntPtr obj ,  System.Int32 val );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean ml_EM_getCovarianceMatrixType_excsafe(ref System.Int32 ret,  System.IntPtr obj );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean ml_EM_setCovarianceMatrixType_excsafe( System.IntPtr obj ,  System.Int32 val );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean ml_EM_getTermCriteria_excsafe(ref OpenCvSharp.TermCriteria ret,  System.IntPtr obj );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean ml_EM_setTermCriteria_excsafe( System.IntPtr obj ,  OpenCvSharp.TermCriteria val );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean ml_EM_getWeights_excsafe(ref System.IntPtr ret,  System.IntPtr obj );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean ml_EM_getMeans_excsafe(ref System.IntPtr ret,  System.IntPtr obj );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean ml_EM_getCovs_excsafe( System.IntPtr obj ,  System.IntPtr covs );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean ml_EM_predict2_excsafe(ref OpenCvSharp.Vec2d ret,  System.IntPtr model ,  System.IntPtr sample ,  System.IntPtr probs );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean ml_EM_trainEM_excsafe(ref System.Int32 ret,  System.IntPtr obj ,  System.IntPtr samples ,  System.IntPtr logLikelihoods ,  System.IntPtr labels ,  System.IntPtr probs );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean ml_EM_trainE_excsafe(ref System.Int32 ret,  System.IntPtr model ,  System.IntPtr samples ,  System.IntPtr means0 ,  System.IntPtr covs0 ,  System.IntPtr weights0 ,  System.IntPtr logLikelihoods ,  System.IntPtr labels ,  System.IntPtr probs );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean ml_EM_trainM_excsafe(ref System.Int32 ret,  System.IntPtr model ,  System.IntPtr samples ,  System.IntPtr probs0 ,  System.IntPtr logLikelihoods ,  System.IntPtr labels ,  System.IntPtr probs );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean ml_EM_create_excsafe(ref System.IntPtr ret);

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean ml_Ptr_ANN_MLP_delete_excsafe( System.IntPtr obj );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean ml_Ptr_ANN_MLP_get_excsafe(ref System.IntPtr ret,  System.IntPtr obj );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean ml_ANN_MLP_load_excsafe(ref System.IntPtr ret,  System.String filePath );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean ml_ANN_MLP_loadFromString_excsafe(ref System.IntPtr ret,  System.String strModel );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean ml_Boost_getBoostType_excsafe(ref System.Int32 ret,  System.IntPtr obj );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean ml_Boost_setBoostType_excsafe( System.IntPtr obj ,  System.Int32 val );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean ml_Boost_getWeakCount_excsafe(ref System.Int32 ret,  System.IntPtr obj );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean ml_Boost_setWeakCount_excsafe( System.IntPtr obj ,  System.Int32 val );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean ml_Boost_getWeightTrimRate_excsafe(ref System.Double ret,  System.IntPtr obj );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean ml_Boost_setWeightTrimRate_excsafe( System.IntPtr obj ,  System.Double val );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean ml_Boost_create_excsafe(ref System.IntPtr ret);

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean ml_Ptr_Boost_delete_excsafe( System.IntPtr obj );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean ml_Ptr_Boost_get_excsafe(ref System.IntPtr ret,  System.IntPtr obj );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean ml_Boost_load_excsafe(ref System.IntPtr ret,  System.String filePath );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean ml_Boost_loadFromString_excsafe(ref System.IntPtr ret,  System.String strModel );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean ml_DTrees_getMaxCategories_excsafe(ref System.Int32 ret,  System.IntPtr obj );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean ml_DTrees_setMaxCategories_excsafe( System.IntPtr obj ,  System.Int32 val );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean ml_DTrees_getMaxDepth_excsafe(ref System.Int32 ret,  System.IntPtr obj );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean ml_DTrees_setMaxDepth_excsafe( System.IntPtr obj ,  System.Int32 val );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean ml_DTrees_getMinSampleCount_excsafe(ref System.Int32 ret,  System.IntPtr obj );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean ml_DTrees_setMinSampleCount_excsafe( System.IntPtr obj ,  System.Int32 val );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean ml_DTrees_getCVFolds_excsafe(ref System.Int32 ret,  System.IntPtr obj );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean ml_DTrees_setCVFolds_excsafe( System.IntPtr obj ,  System.Int32 val );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean ml_DTrees_getUseSurrogates_excsafe(ref System.Int32 ret,  System.IntPtr obj );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean ml_DTrees_setUseSurrogates_excsafe( System.IntPtr obj ,  System.Int32 val );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean ml_DTrees_getUse1SERule_excsafe(ref System.Int32 ret,  System.IntPtr obj );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean ml_DTrees_setUse1SERule_excsafe( System.IntPtr obj ,  System.Int32 val );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean ml_DTrees_getTruncatePrunedTree_excsafe(ref System.Int32 ret,  System.IntPtr obj );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean imgproc_Subdiv2D_nextEdge_excsafe(ref System.Int32 ret,  System.IntPtr obj ,  System.Int32 edge );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean imgproc_Subdiv2D_rotateEdge_excsafe(ref System.Int32 ret,  System.IntPtr obj ,  System.Int32 edge ,  System.Int32 rotate );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean imgproc_Subdiv2D_symEdge_excsafe(ref System.Int32 ret,  System.IntPtr obj ,  System.Int32 edge );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean imgproc_Subdiv2D_edgeOrg_excsafe(ref System.Int32 ret,  System.IntPtr obj ,  System.Int32 edge ,  out OpenCvSharp.Point2f orgpt );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean imgproc_Subdiv2D_edgeDst_excsafe(ref System.Int32 ret,  System.IntPtr obj ,  System.Int32 edge ,  out OpenCvSharp.Point2f dstpt );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean ml_ANN_MLP_setTrainMethod_excsafe( System.IntPtr obj ,  System.Int32 method ,  System.Double param1 ,  System.Double param2 );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean ml_ANN_MLP_getTrainMethod_excsafe(ref System.Int32 ret,  System.IntPtr obj );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean ml_ANN_MLP_setActivationFunction_excsafe( System.IntPtr obj ,  System.Int32 type ,  System.Double param1 ,  System.Double param2 );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean ml_ANN_MLP_setLayerSizes_excsafe( System.IntPtr obj ,  System.IntPtr layerSizes );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean ml_ANN_MLP_getLayerSizes_excsafe(ref System.IntPtr ret,  System.IntPtr obj );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean ml_ANN_MLP_getTermCriteria_excsafe(ref OpenCvSharp.TermCriteria ret,  System.IntPtr obj );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean ml_ANN_MLP_setTermCriteria_excsafe( System.IntPtr obj ,  OpenCvSharp.TermCriteria val );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean ml_ANN_MLP_getBackpropWeightScale_excsafe(ref System.Double ret,  System.IntPtr obj );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean ml_ANN_MLP_setBackpropWeightScale_excsafe( System.IntPtr obj ,  System.Double val );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean ml_ANN_MLP_getBackpropMomentumScale_excsafe(ref System.Double ret,  System.IntPtr obj );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean ml_ANN_MLP_setBackpropMomentumScale_excsafe( System.IntPtr obj ,  System.Double val );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean ml_ANN_MLP_getRpropDW0_excsafe(ref System.Double ret,  System.IntPtr obj );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean ml_ANN_MLP_setRpropDW0_excsafe( System.IntPtr obj ,  System.Double val );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean ml_ANN_MLP_getRpropDWPlus_excsafe(ref System.Double ret,  System.IntPtr obj );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean ml_ANN_MLP_setRpropDWPlus_excsafe( System.IntPtr obj ,  System.Double val );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean ml_ANN_MLP_getRpropDWMinus_excsafe(ref System.Double ret,  System.IntPtr obj );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean ml_ANN_MLP_setRpropDWMinus_excsafe( System.IntPtr obj ,  System.Double val );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean ml_ANN_MLP_getRpropDWMin_excsafe(ref System.Double ret,  System.IntPtr obj );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean ml_ANN_MLP_setRpropDWMin_excsafe( System.IntPtr obj ,  System.Double val );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean ml_ANN_MLP_getRpropDWMax_excsafe(ref System.Double ret,  System.IntPtr obj );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean ml_ANN_MLP_setRpropDWMax_excsafe( System.IntPtr obj ,  System.Double val );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean ml_ANN_MLP_getWeights_excsafe(ref System.IntPtr ret,  System.IntPtr obj ,  System.Int32 layerIdx );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean ml_ANN_MLP_create_excsafe(ref System.IntPtr ret);

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean imgproc_LineIterator_minusDelta_set_excsafe( System.IntPtr obj ,  System.Int32 val );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean imgproc_LineIterator_plusDelta_get_excsafe(ref System.Int32 ret,  System.IntPtr obj );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean imgproc_LineIterator_plusDelta_set_excsafe( System.IntPtr obj ,  System.Int32 val );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean imgproc_LineIterator_minusStep_get_excsafe(ref System.Int32 ret,  System.IntPtr obj );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean imgproc_LineIterator_minusStep_set_excsafe( System.IntPtr obj ,  System.Int32 val );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean imgproc_LineIterator_plusStep_get_excsafe(ref System.Int32 ret,  System.IntPtr obj );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean imgproc_LineIterator_plusStep_set_excsafe( System.IntPtr obj ,  System.Int32 val );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean imgproc_LineSegmentDetector_detect_OutputArray_excsafe( System.IntPtr obj ,  System.IntPtr image ,  System.IntPtr lines ,  System.IntPtr width ,  System.IntPtr prec ,  System.IntPtr nfa );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean imgproc_LineSegmentDetector_detect_vector_excsafe( System.IntPtr obj ,  System.IntPtr image ,  System.IntPtr lines ,  System.IntPtr width ,  System.IntPtr prec ,  System.IntPtr nfa );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean imgproc_LineSegmentDetector_drawSegments_excsafe( System.IntPtr obj ,  System.IntPtr image ,  System.IntPtr lines );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean imgproc_LineSegmentDetector_compareSegments_excsafe(ref System.Int32 ret,  System.IntPtr obj ,  OpenCvSharp.Size size ,  System.IntPtr lines1 ,  System.IntPtr lines2 ,  System.IntPtr image );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean imgproc_createLineSegmentDetector_excsafe(ref System.IntPtr ret,  System.Int32 refine ,  System.Double scale ,  System.Double sigma_scale ,  System.Double quant ,  System.Double ang_th ,  System.Double log_eps ,  System.Double density_th ,  System.Int32 n_bins );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean imgproc_Ptr_LineSegmentDetector_delete_excsafe( System.IntPtr obj );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean imgproc_Ptr_LineSegmentDetector_get_excsafe(ref System.IntPtr ret,  System.IntPtr obj );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean imgproc_Subdiv2D_new1_excsafe(ref System.IntPtr ret);

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean imgproc_Subdiv2D_new2_excsafe(ref System.IntPtr ret,  OpenCvSharp.Rect rect );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean imgproc_Subdiv2D_delete_excsafe( System.IntPtr obj );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean imgproc_Subdiv2D_initDelaunay_excsafe( System.IntPtr obj ,  OpenCvSharp.Rect rect );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean imgproc_Subdiv2D_insert1_excsafe(ref System.Int32 ret,  System.IntPtr obj ,  OpenCvSharp.Point2f pt );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean imgproc_Subdiv2D_insert2_excsafe( System.IntPtr obj , [MarshalAs(UnmanagedType.LPArray)] OpenCvSharp.Point2f[] ptArray ,  System.Int32 length );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean imgproc_Subdiv2D_locate_excsafe(ref System.Int32 ret,  System.IntPtr obj ,  OpenCvSharp.Point2f pt ,  out System.Int32 edge ,  out System.Int32 vertex );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean imgproc_Subdiv2D_findNearest_excsafe(ref System.Int32 ret,  System.IntPtr obj ,  OpenCvSharp.Point2f pt ,  out OpenCvSharp.Point2f nearestPt );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean imgproc_Subdiv2D_getEdgeList_excsafe( System.IntPtr obj ,  out System.IntPtr edgeList );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean imgproc_Subdiv2D_getTriangleList_excsafe( System.IntPtr obj ,  out System.IntPtr triangleList );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean imgproc_Subdiv2D_getVoronoiFacetList_excsafe( System.IntPtr obj , [MarshalAs(UnmanagedType.LPArray)] System.Int32[] idx ,  System.Int32 idxCount ,  out System.IntPtr facetList ,  out System.IntPtr facetCenters );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean imgproc_Subdiv2D_getVoronoiFacetList_excsafe( System.IntPtr obj ,  System.IntPtr idx ,  System.Int32 idxCount ,  out System.IntPtr facetList ,  out System.IntPtr facetCenters );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean imgproc_Subdiv2D_getVertex_excsafe(ref OpenCvSharp.Point2f ret,  System.IntPtr obj ,  System.Int32 vertex ,  out System.Int32 firstEdge );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean imgproc_Subdiv2D_getEdge_excsafe(ref System.Int32 ret,  System.IntPtr obj ,  System.Int32 edge ,  System.Int32 nextEdgeType );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean imgproc_GeneralizedHoughGuil_getAngleThresh_excsafe(ref System.Int32 ret,  System.IntPtr obj );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean imgproc_GeneralizedHoughGuil_setMinScale_excsafe( System.IntPtr obj ,  System.Double val );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean imgproc_GeneralizedHoughGuil_getMinScale_excsafe(ref System.Double ret,  System.IntPtr obj );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean imgproc_GeneralizedHoughGuil_setMaxScale_excsafe( System.IntPtr obj ,  System.Double val );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean imgproc_GeneralizedHoughGuil_getMaxScale_excsafe(ref System.Double ret,  System.IntPtr obj );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean imgproc_GeneralizedHoughGuil_setScaleStep_excsafe( System.IntPtr obj ,  System.Double val );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean imgproc_GeneralizedHoughGuil_getScaleStep_excsafe(ref System.Double ret,  System.IntPtr obj );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean imgproc_GeneralizedHoughGuil_setScaleThresh_excsafe( System.IntPtr obj ,  System.Int32 val );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean imgproc_GeneralizedHoughGuil_getScaleThresh_excsafe(ref System.Int32 ret,  System.IntPtr obj );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean imgproc_GeneralizedHoughGuil_setPosThresh_excsafe( System.IntPtr obj ,  System.Int32 val );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean imgproc_GeneralizedHoughGuil_getPosThresh_excsafe(ref System.Int32 ret,  System.IntPtr obj );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean imgproc_LineIterator_new_excsafe(ref System.IntPtr ret,  System.IntPtr img ,  OpenCvSharp.Point pt1 ,  OpenCvSharp.Point pt2 ,  System.Int32 connectivity ,  System.Int32 leftToRight );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean imgproc_LineIterator_delete_excsafe( System.IntPtr obj );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean imgproc_LineIterator_operatorEntity_excsafe(ref System.IntPtr ret,  System.IntPtr obj );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean imgproc_LineIterator_operatorPP_excsafe( System.IntPtr obj );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean imgproc_LineIterator_pos_excsafe(ref OpenCvSharp.Point ret,  System.IntPtr obj );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean imgproc_LineIterator_ptr_get_excsafe(ref System.IntPtr ret,  System.IntPtr obj );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean imgproc_LineIterator_ptr_set_excsafe( System.IntPtr obj ,  System.IntPtr val );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean imgproc_LineIterator_ptr0_get_excsafe(ref System.IntPtr ret,  System.IntPtr obj );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean imgproc_LineIterator_step_get_excsafe(ref System.Int32 ret,  System.IntPtr obj );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean imgproc_LineIterator_step_set_excsafe( System.IntPtr obj ,  System.Int32 val );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean imgproc_LineIterator_elemSize_get_excsafe(ref System.Int32 ret,  System.IntPtr obj );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean imgproc_LineIterator_elemSize_set_excsafe( System.IntPtr obj ,  System.Int32 val );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean imgproc_LineIterator_err_get_excsafe(ref System.Int32 ret,  System.IntPtr obj );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean imgproc_LineIterator_err_set_excsafe( System.IntPtr obj ,  System.Int32 val );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean imgproc_LineIterator_count_get_excsafe(ref System.Int32 ret,  System.IntPtr obj );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean imgproc_LineIterator_count_set_excsafe( System.IntPtr obj ,  System.Int32 val );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean imgproc_LineIterator_minusDelta_get_excsafe(ref System.Int32 ret,  System.IntPtr obj );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean imgproc_GeneralizedHough_getMinDist_excsafe(ref System.Double ret,  System.IntPtr obj );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean imgproc_GeneralizedHough_setDp_excsafe( System.IntPtr obj ,  System.Double val );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean imgproc_GeneralizedHough_getDp_excsafe(ref System.Double ret,  System.IntPtr obj );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean imgproc_GeneralizedHough_setMaxBufferSize_excsafe( System.IntPtr obj ,  System.Int32 val );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean imgproc_GeneralizedHough_getMaxBufferSize_excsafe(ref System.Int32 ret,  System.IntPtr obj );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean imgproc_createGeneralizedHoughBallard_excsafe(ref System.IntPtr ret);

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean imgproc_Ptr_GeneralizedHoughBallard_get_excsafe(ref System.IntPtr ret,  System.IntPtr obj );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean imgproc_Ptr_GeneralizedHoughBallard_delete_excsafe( System.IntPtr obj );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean imgproc_GeneralizedHoughBallard_setLevels_excsafe( System.IntPtr obj ,  System.Int32 val );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean imgproc_GeneralizedHoughBallard_getLevels_excsafe(ref System.Int32 ret,  System.IntPtr obj );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean imgproc_GeneralizedHoughBallard_setVotesThreshold_excsafe( System.IntPtr obj ,  System.Int32 val );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean imgproc_GeneralizedHoughBallard_getVotesThreshold_excsafe(ref System.Int32 ret,  System.IntPtr obj );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean imgproc_createGeneralizedHoughGuil_excsafe(ref System.IntPtr ret);

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean imgproc_Ptr_GeneralizedHoughGuil_get_excsafe(ref System.IntPtr ret,  System.IntPtr obj );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean imgproc_Ptr_GeneralizedHoughGuil_delete_excsafe( System.IntPtr obj );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean imgproc_GeneralizedHoughGuil_setXi_excsafe( System.IntPtr obj ,  System.Double val );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean imgproc_GeneralizedHoughGuil_getXi_excsafe(ref System.Double ret,  System.IntPtr obj );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean imgproc_GeneralizedHoughGuil_setLevels_excsafe( System.IntPtr obj ,  System.Int32 val );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean imgproc_GeneralizedHoughGuil_getLevels_excsafe(ref System.Int32 ret,  System.IntPtr obj );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean imgproc_GeneralizedHoughGuil_setAngleEpsilon_excsafe( System.IntPtr obj ,  System.Double val );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean imgproc_GeneralizedHoughGuil_getAngleEpsilon_excsafe(ref System.Double ret,  System.IntPtr obj );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean imgproc_GeneralizedHoughGuil_setMinAngle_excsafe( System.IntPtr obj ,  System.Double val );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean imgproc_GeneralizedHoughGuil_getMinAngle_excsafe(ref System.Double ret,  System.IntPtr obj );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean imgproc_GeneralizedHoughGuil_setMaxAngle_excsafe( System.IntPtr obj ,  System.Double val );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean imgproc_GeneralizedHoughGuil_getMaxAngle_excsafe(ref System.Double ret,  System.IntPtr obj );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean imgproc_GeneralizedHoughGuil_setAngleStep_excsafe( System.IntPtr obj ,  System.Double val );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean imgproc_GeneralizedHoughGuil_getAngleStep_excsafe(ref System.Double ret,  System.IntPtr obj );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean imgproc_GeneralizedHoughGuil_setAngleThresh_excsafe( System.IntPtr obj ,  System.Int32 val );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean imgproc_fillConvexPoly_InputOutputArray_excsafe( System.IntPtr img ,  System.IntPtr points ,  OpenCvSharp.Scalar color ,  System.Int32 lineType ,  System.Int32 shift );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean imgproc_fillPoly_Mat_excsafe( System.IntPtr img ,  System.IntPtr[] pts ,  System.Int32[] npts ,  System.Int32 ncontours ,  OpenCvSharp.Scalar color ,  System.Int32 lineType ,  System.Int32 shift ,  OpenCvSharp.Point offset );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean imgproc_fillPoly_InputOutputArray_excsafe( System.IntPtr img ,  System.IntPtr pts ,  OpenCvSharp.Scalar color ,  System.Int32 lineType ,  System.Int32 shift ,  OpenCvSharp.Point offset );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean imgproc_polylines_Mat_excsafe( System.IntPtr img ,  System.IntPtr[] pts ,  System.Int32[] npts ,  System.Int32 ncontours ,  System.Int32 isClosed ,  OpenCvSharp.Scalar color ,  System.Int32 thickness ,  System.Int32 lineType ,  System.Int32 shift );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean imgproc_polylines_InputOutputArray_excsafe( System.IntPtr img ,  System.IntPtr pts ,  System.Int32 isClosed ,  OpenCvSharp.Scalar color ,  System.Int32 thickness ,  System.Int32 lineType ,  System.Int32 shift );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean imgproc_clipLine1_excsafe(ref System.Int32 ret,  OpenCvSharp.Size imgSize ,  ref OpenCvSharp.Point pt1 ,  ref OpenCvSharp.Point pt2 );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean imgproc_clipLine2_excsafe(ref System.Int32 ret,  OpenCvSharp.Rect imgRect ,  ref OpenCvSharp.Point pt1 ,  ref OpenCvSharp.Point pt2 );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean imgproc_ellipse2Poly_excsafe( OpenCvSharp.Point center ,  OpenCvSharp.Size axes ,  System.Int32 angle ,  System.Int32 arcStart ,  System.Int32 arcEnd ,  System.Int32 delta ,  System.IntPtr pts );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_putText_excsafe( System.IntPtr img , [MarshalAs(UnmanagedType.LPStr)] System.String text ,  OpenCvSharp.Point org ,  System.Int32 fontFace ,  System.Double fontScale ,  OpenCvSharp.Scalar color ,  System.Int32 thickness ,  System.Int32 lineType ,  System.Int32 bottomLeftOrigin );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_getTextSize_excsafe(ref OpenCvSharp.Size ret, [MarshalAs(UnmanagedType.LPStr)] System.String text ,  System.Int32 fontFace ,  System.Double fontScale ,  System.Int32 thickness ,  out System.Int32 baseLine );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean imgproc_createCLAHE_excsafe(ref System.IntPtr ret,  System.Double clipLimit ,  OpenCvSharp.Size tileGridSize );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean imgproc_Ptr_CLAHE_delete_excsafe( System.IntPtr obj );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean imgproc_Ptr_CLAHE_get_excsafe(ref System.IntPtr ret,  System.IntPtr obj );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean imgproc_CLAHE_apply_excsafe( System.IntPtr obj ,  System.IntPtr src ,  System.IntPtr dst );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean imgproc_CLAHE_setClipLimit_excsafe( System.IntPtr obj ,  System.Double clipLimit );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean imgproc_CLAHE_getClipLimit_excsafe(ref System.Double ret,  System.IntPtr obj );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean imgproc_CLAHE_setTilesGridSize_excsafe( System.IntPtr obj ,  OpenCvSharp.Size tileGridSize );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean imgproc_CLAHE_getTilesGridSize_excsafe(ref OpenCvSharp.Size ret,  System.IntPtr obj );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean imgproc_CLAHE_collectGarbage_excsafe( System.IntPtr obj );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean imgproc_GeneralizedHough_setTemplate1_excsafe( System.IntPtr obj ,  System.IntPtr templ ,  OpenCvSharp.Point templCenter );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean imgproc_GeneralizedHough_setTemplate2_excsafe( System.IntPtr obj ,  System.IntPtr edges ,  System.IntPtr dx ,  System.IntPtr dy ,  OpenCvSharp.Point templCenter );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean imgproc_GeneralizedHough_detect1_excsafe( System.IntPtr obj ,  System.IntPtr image ,  System.IntPtr positions ,  System.IntPtr votes );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean imgproc_GeneralizedHough_detect2_excsafe( System.IntPtr obj ,  System.IntPtr edges ,  System.IntPtr dx ,  System.IntPtr dy ,  System.IntPtr positions ,  System.IntPtr votes );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean imgproc_GeneralizedHough_setCannyLowThresh_excsafe( System.IntPtr obj ,  System.Int32 val );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean imgproc_GeneralizedHough_getCannyLowThresh_excsafe(ref System.Int32 ret,  System.IntPtr obj );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean imgproc_GeneralizedHough_setCannyHighThresh_excsafe( System.IntPtr obj ,  System.Int32 val );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean imgproc_GeneralizedHough_getCannyHighThresh_excsafe(ref System.Int32 ret,  System.IntPtr obj );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean imgproc_GeneralizedHough_setMinDist_excsafe( System.IntPtr obj ,  System.Double val );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean imgproc_isContourConvex_InputArray_excsafe(ref System.Int32 ret,  System.IntPtr contour );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean imgproc_isContourConvex_Point_excsafe(ref System.Int32 ret,  OpenCvSharp.Point[] contour ,  System.Int32 contourLength );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean imgproc_isContourConvex_Point2f_excsafe(ref System.Int32 ret,  OpenCvSharp.Point2f[] contour ,  System.Int32 contourLength );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean imgproc_intersectConvexConvex_InputArray_excsafe(ref System.Single ret,  System.IntPtr p1 ,  System.IntPtr p2 ,  System.IntPtr p12 ,  System.Int32 handleNested );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean imgproc_intersectConvexConvex_Point_excsafe(ref System.Single ret,  OpenCvSharp.Point[] p1 ,  System.Int32 p1Length ,  OpenCvSharp.Point[] p2 ,  System.Int32 p2Length ,  out System.IntPtr p12 ,  System.Int32 handleNested );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean imgproc_intersectConvexConvex_Point2f_excsafe(ref System.Single ret,  OpenCvSharp.Point2f[] p1 ,  System.Int32 p1Length ,  OpenCvSharp.Point2f[] p2 ,  System.Int32 p2Length ,  out System.IntPtr p12 ,  System.Int32 handleNested );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean imgproc_fitEllipse_InputArray_excsafe(ref OpenCvSharp.RotatedRect ret,  System.IntPtr points );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean imgproc_fitEllipse_Point_excsafe(ref OpenCvSharp.RotatedRect ret,  OpenCvSharp.Point[] points ,  System.Int32 pointsLength );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean imgproc_fitEllipse_Point2f_excsafe(ref OpenCvSharp.RotatedRect ret,  OpenCvSharp.Point2f[] points ,  System.Int32 pointsLength );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean imgproc_fitLine_InputArray_excsafe( System.IntPtr points ,  System.IntPtr line ,  System.Int32 distType ,  System.Double param ,  System.Double reps ,  System.Double aeps );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean imgproc_fitLine_Point_excsafe( OpenCvSharp.Point[] points ,  System.Int32 pointsLength , [In, Out] System.Single[] line ,  System.Int32 distType ,  System.Double param ,  System.Double reps ,  System.Double aeps );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean imgproc_fitLine_Point2f_excsafe( OpenCvSharp.Point2f[] points ,  System.Int32 pointsLength , [In, Out] System.Single[] line ,  System.Int32 distType ,  System.Double param ,  System.Double reps ,  System.Double aeps );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean imgproc_fitLine_Point3i_excsafe( OpenCvSharp.Point3i[] points ,  System.Int32 pointsLength , [In, Out] System.Single[] line ,  System.Int32 distType ,  System.Double param ,  System.Double reps ,  System.Double aeps );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean imgproc_fitLine_Point3f_excsafe( OpenCvSharp.Point3f[] points ,  System.Int32 pointsLength , [In, Out] System.Single[] line ,  System.Int32 distType ,  System.Double param ,  System.Double reps ,  System.Double aeps );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean imgproc_pointPolygonTest_InputArray_excsafe(ref System.Double ret,  System.IntPtr contour ,  OpenCvSharp.Point2f pt ,  System.Int32 measureDist );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean imgproc_pointPolygonTest_Point_excsafe(ref System.Double ret,  OpenCvSharp.Point[] contour ,  System.Int32 contourLength ,  OpenCvSharp.Point2f pt ,  System.Int32 measureDist );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean imgproc_pointPolygonTest_Point2f_excsafe(ref System.Double ret,  OpenCvSharp.Point2f[] contour ,  System.Int32 contourLength ,  OpenCvSharp.Point2f pt ,  System.Int32 measureDist );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean imgproc_rotatedRectangleIntersection_OutputArray_excsafe(ref System.Int32 ret,  OpenCvSharp.RotatedRect rect1 ,  OpenCvSharp.RotatedRect rect2 ,  System.IntPtr intersectingRegion );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean imgproc_rotatedRectangleIntersection_vector_excsafe(ref System.Int32 ret,  OpenCvSharp.RotatedRect rect1 ,  OpenCvSharp.RotatedRect rect2 ,  System.IntPtr intersectingRegion );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean imgproc_applyColorMap_excsafe( System.IntPtr src ,  System.IntPtr dst ,  System.Int32 colormap );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean imgproc_line_excsafe( System.IntPtr img ,  OpenCvSharp.Point pt1 ,  OpenCvSharp.Point pt2 ,  OpenCvSharp.Scalar color ,  System.Int32 thickness ,  System.Int32 lineType ,  System.Int32 shift );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean imgproc_arrowedLine_excsafe( System.IntPtr img ,  OpenCvSharp.Point pt1 ,  OpenCvSharp.Point pt2 ,  OpenCvSharp.Scalar color ,  System.Int32 thickness ,  System.Int32 lineType ,  System.Int32 shift ,  System.Double tipLength );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean imgproc_rectangle_InputOutputArray_excsafe( System.IntPtr img ,  OpenCvSharp.Point pt1 ,  OpenCvSharp.Point pt2 ,  OpenCvSharp.Scalar color ,  System.Int32 thickness ,  System.Int32 lineType ,  System.Int32 shift );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean imgproc_rectangle_Mat_excsafe( System.IntPtr img ,  OpenCvSharp.Rect rect ,  OpenCvSharp.Scalar color ,  System.Int32 thickness ,  System.Int32 lineType ,  System.Int32 shift );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean imgproc_circle_excsafe( System.IntPtr img ,  OpenCvSharp.Point center ,  System.Int32 radius ,  OpenCvSharp.Scalar color ,  System.Int32 thickness ,  System.Int32 lineType ,  System.Int32 shift );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean imgproc_ellipse1_excsafe( System.IntPtr img ,  OpenCvSharp.Point center ,  OpenCvSharp.Size axes ,  System.Double angle ,  System.Double startAngle ,  System.Double endAngle ,  OpenCvSharp.Scalar color ,  System.Int32 thickness ,  System.Int32 lineType ,  System.Int32 shift );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean imgproc_ellipse2_excsafe( System.IntPtr img ,  OpenCvSharp.RotatedRect box ,  OpenCvSharp.Scalar color ,  System.Int32 thickness ,  System.Int32 lineType );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean imgproc_fillConvexPoly_Mat_excsafe( System.IntPtr img ,  OpenCvSharp.Point[] pts ,  System.Int32 npts ,  OpenCvSharp.Scalar color ,  System.Int32 lineType ,  System.Int32 shift );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean imgproc_approxPolyDP_InputArray_excsafe( System.IntPtr curve ,  System.IntPtr approxCurve ,  System.Double epsilon ,  System.Int32 closed );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean imgproc_approxPolyDP_Point_excsafe( OpenCvSharp.Point[] curve ,  System.Int32 curveLength ,  out System.IntPtr approxCurve ,  System.Double epsilon ,  System.Int32 closed );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean imgproc_approxPolyDP_Point2f_excsafe( OpenCvSharp.Point2f[] curve ,  System.Int32 curveLength ,  out System.IntPtr approxCurve ,  System.Double epsilon ,  System.Int32 closed );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean imgproc_arcLength_InputArray_excsafe(ref System.Double ret,  System.IntPtr curve ,  System.Int32 closed );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean imgproc_arcLength_Point_excsafe(ref System.Double ret,  OpenCvSharp.Point[] curve ,  System.Int32 curveLength ,  System.Int32 closed );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean imgproc_arcLength_Point2f_excsafe(ref System.Double ret,  OpenCvSharp.Point2f[] curve ,  System.Int32 curveLength ,  System.Int32 closed );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean imgproc_boundingRect_InputArray_excsafe(ref OpenCvSharp.Rect ret,  System.IntPtr curve );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean imgproc_boundingRect_Point_excsafe(ref OpenCvSharp.Rect ret,  OpenCvSharp.Point[] curve ,  System.Int32 curveLength );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean imgproc_boundingRect_Point2f_excsafe(ref OpenCvSharp.Rect ret,  OpenCvSharp.Point2f[] curve ,  System.Int32 curveLength );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean imgproc_contourArea_InputArray_excsafe(ref System.Double ret,  System.IntPtr contour ,  System.Int32 oriented );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean imgproc_contourArea_Point_excsafe(ref System.Double ret,  OpenCvSharp.Point[] contour ,  System.Int32 contourLength ,  System.Int32 oriented );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean imgproc_contourArea_Point2f_excsafe(ref System.Double ret,  OpenCvSharp.Point2f[] contour ,  System.Int32 contourLength ,  System.Int32 oriented );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean imgproc_minAreaRect_InputArray_excsafe(ref OpenCvSharp.RotatedRect ret,  System.IntPtr points );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean imgproc_minAreaRect_Point_excsafe(ref OpenCvSharp.RotatedRect ret,  OpenCvSharp.Point[] points ,  System.Int32 pointsLength );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean imgproc_minAreaRect_Point2f_excsafe(ref OpenCvSharp.RotatedRect ret,  OpenCvSharp.Point2f[] points ,  System.Int32 pointsLength );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean imgproc_minEnclosingCircle_InputArray_excsafe( System.IntPtr points ,  out OpenCvSharp.Point2f center ,  out System.Single radius );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean imgproc_minEnclosingCircle_Point_excsafe( OpenCvSharp.Point[] points ,  System.Int32 pointsLength ,  out OpenCvSharp.Point2f center ,  out System.Single radius );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean imgproc_minEnclosingCircle_Point2f_excsafe( OpenCvSharp.Point2f[] points ,  System.Int32 pointsLength ,  out OpenCvSharp.Point2f center ,  out System.Single radius );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean imgproc_matchShapes_InputArray_excsafe(ref System.Double ret,  System.IntPtr contour1 ,  System.IntPtr contour2 ,  System.Int32 method ,  System.Double parameter );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean imgproc_matchShapes_Point_excsafe(ref System.Double ret,  OpenCvSharp.Point[] contour1 ,  System.Int32 contour1Length ,  OpenCvSharp.Point[] contour2 ,  System.Int32 contour2Length ,  System.Int32 method ,  System.Double parameter );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean imgproc_convexHull_InputArray_excsafe( System.IntPtr points ,  System.IntPtr hull ,  System.Int32 clockwise ,  System.Int32 returnPoints );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean imgproc_convexHull_Point_ReturnsPoints_excsafe( OpenCvSharp.Point[] points ,  System.Int32 pointsLength ,  out System.IntPtr hull ,  System.Int32 clockwise );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean imgproc_convexHull_Point2f_ReturnsPoints_excsafe( OpenCvSharp.Point2f[] points ,  System.Int32 pointsLength ,  out System.IntPtr hull ,  System.Int32 clockwise );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean imgproc_convexHull_Point_ReturnsIndices_excsafe( OpenCvSharp.Point[] points ,  System.Int32 pointsLength ,  out System.IntPtr hull ,  System.Int32 clockwise );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean imgproc_convexHull_Point2f_ReturnsIndices_excsafe( OpenCvSharp.Point2f[] points ,  System.Int32 pointsLength ,  out System.IntPtr hull ,  System.Int32 clockwise );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean imgproc_convexityDefects_InputArray_excsafe( System.IntPtr contour ,  System.IntPtr convexHull ,  System.IntPtr convexityDefects );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean imgproc_convexityDefects_Point_excsafe( OpenCvSharp.Point[] contour ,  System.Int32 contourLength ,  System.Int32[] convexHull ,  System.Int32 convexHullLength ,  out System.IntPtr convexityDefects );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean imgproc_convexityDefects_Point2f_excsafe( OpenCvSharp.Point2f[] contour ,  System.Int32 contourLength ,  System.Int32[] convexHull ,  System.Int32 convexHullLength ,  out System.IntPtr convexityDefects );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean imgproc_initUndistortRectifyMap_excsafe( System.IntPtr cameraMatrix ,  System.IntPtr distCoeffs ,  System.IntPtr r ,  System.IntPtr newCameraMatrix ,  OpenCvSharp.Size size ,  System.Int32 m1Type ,  System.IntPtr map1 ,  System.IntPtr map2 );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean imgproc_initWideAngleProjMap_excsafe(ref System.Single ret,  System.IntPtr cameraMatrix ,  System.IntPtr distCoeffs ,  OpenCvSharp.Size imageSize ,  System.Int32 destImageWidth ,  System.Int32 m1Type ,  System.IntPtr map1 ,  System.IntPtr map2 ,  System.Int32 projType ,  System.Double alpha );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean imgproc_getDefaultNewCameraMatrix_excsafe(ref System.IntPtr ret,  System.IntPtr cameraMatrix ,  OpenCvSharp.Size imgSize ,  System.Int32 centerPrincipalPoint );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean imgproc_undistortPoints_excsafe( System.IntPtr src ,  System.IntPtr dst ,  System.IntPtr cameraMatrix ,  System.IntPtr distCoeffs ,  System.IntPtr r ,  System.IntPtr p );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean imgproc_calcHist1_excsafe( System.IntPtr[] images ,  System.Int32 nimages ,  System.Int32[] channels ,  System.IntPtr mask ,  System.IntPtr hist ,  System.Int32 dims ,  System.Int32[] histSize ,  System.IntPtr[] ranges ,  System.Int32 uniform ,  System.Int32 accumulate );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean imgproc_calcBackProject_excsafe( System.IntPtr[] images ,  System.Int32 nimages ,  System.Int32[] channels ,  System.IntPtr hist ,  System.IntPtr backProject ,  System.IntPtr[] ranges ,  System.Int32 uniform );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean imgproc_compareHist1_excsafe(ref System.Double ret,  System.IntPtr h1 ,  System.IntPtr h2 ,  System.Int32 method );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean imgproc_equalizeHist_excsafe( System.IntPtr src ,  System.IntPtr dst );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean imgproc_EMD_excsafe(ref System.Single ret,  System.IntPtr signature1 ,  System.IntPtr signature2 ,  System.Int32 distType ,  System.IntPtr cost ,  out System.Single lowerBound ,  System.IntPtr flow );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean imgproc_watershed_excsafe( System.IntPtr image ,  System.IntPtr markers );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean imgproc_pyrMeanShiftFiltering_excsafe( System.IntPtr src ,  System.IntPtr dst ,  System.Double sp ,  System.Double sr ,  System.Int32 maxLevel ,  OpenCvSharp.TermCriteria termcrit );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean imgproc_grabCut_excsafe( System.IntPtr img ,  System.IntPtr mask ,  OpenCvSharp.Rect rect ,  System.IntPtr bgdModel ,  System.IntPtr fgdModel ,  System.Int32 iterCount ,  System.Int32 mode );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean imgproc_distanceTransformWithLabels_excsafe( System.IntPtr src ,  System.IntPtr dst ,  System.IntPtr labels ,  System.Int32 distanceType ,  System.Int32 maskSize ,  System.Int32 labelType );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean imgproc_distanceTransform_excsafe( System.IntPtr src ,  System.IntPtr dst ,  System.Int32 distanceType ,  System.Int32 maskSize );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean imgproc_floodFill1_excsafe(ref System.Int32 ret,  System.IntPtr image ,  OpenCvSharp.Point seedPoint ,  OpenCvSharp.Scalar newVal ,  out OpenCvSharp.Rect rect ,  OpenCvSharp.Scalar loDiff ,  OpenCvSharp.Scalar upDiff ,  System.Int32 flags );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean imgproc_floodFill2_excsafe(ref System.Int32 ret,  System.IntPtr image ,  System.IntPtr mask ,  OpenCvSharp.Point seedPoint ,  OpenCvSharp.Scalar newVal ,  out OpenCvSharp.Rect rect ,  OpenCvSharp.Scalar loDiff ,  OpenCvSharp.Scalar upDiff ,  System.Int32 flags );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean imgproc_cvtColor_excsafe( System.IntPtr src ,  System.IntPtr dst ,  System.Int32 code ,  System.Int32 dstCn );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean imgproc_moments_excsafe(ref OpenCvSharp.Moments.NativeStruct ret,  System.IntPtr arr ,  System.Int32 binaryImage );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean imgproc_matchTemplate_excsafe( System.IntPtr image ,  System.IntPtr templ ,  System.IntPtr result ,  System.Int32 method ,  System.IntPtr mask );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean imgproc_connectedComponents_excsafe(ref System.Int32 ret,  System.IntPtr image ,  System.IntPtr labels ,  System.Int32 connectivity ,  System.Int32 ltype );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean imgproc_connectedComponentsWithStats_excsafe(ref System.Int32 ret,  System.IntPtr image ,  System.IntPtr labels ,  System.IntPtr stats ,  System.IntPtr centroids ,  System.Int32 connectivity ,  System.Int32 ltype );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean imgproc_findContours1_vector_excsafe( System.IntPtr image ,  out System.IntPtr contours ,  out System.IntPtr hierarchy ,  System.Int32 mode ,  System.Int32 method ,  OpenCvSharp.Point offset );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean imgproc_findContours1_OutputArray_excsafe( System.IntPtr image ,  out System.IntPtr contours ,  System.IntPtr hierarchy ,  System.Int32 mode ,  System.Int32 method ,  OpenCvSharp.Point offset );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean imgproc_findContours2_vector_excsafe( System.IntPtr image ,  out System.IntPtr contours ,  System.Int32 mode ,  System.Int32 method ,  OpenCvSharp.Point offset );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean imgproc_findContours2_OutputArray_excsafe( System.IntPtr image ,  out System.IntPtr contours ,  System.Int32 mode ,  System.Int32 method ,  OpenCvSharp.Point offset );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean imgproc_drawContours_vector_excsafe( System.IntPtr image ,  System.IntPtr[] contours ,  System.Int32 contoursSize1 ,  System.Int32[] contoursSize2 ,  System.Int32 contourIdx ,  OpenCvSharp.Scalar color ,  System.Int32 thickness ,  System.Int32 lineType ,  OpenCvSharp.Vec4i[] hierarchy ,  System.Int32 hiearchyLength ,  System.Int32 maxLevel ,  OpenCvSharp.Point offset );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean imgproc_drawContours_vector_excsafe( System.IntPtr image ,  System.IntPtr[] contours ,  System.Int32 contoursSize1 ,  System.Int32[] contoursSize2 ,  System.Int32 contourIdx ,  OpenCvSharp.Scalar color ,  System.Int32 thickness ,  System.Int32 lineType ,  System.IntPtr hierarchy ,  System.Int32 hiearchyLength ,  System.Int32 maxLevel ,  OpenCvSharp.Point offset );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean imgproc_drawContours_InputArray_excsafe( System.IntPtr image ,  System.IntPtr[] contours ,  System.Int32 contoursLength ,  System.Int32 contourIdx ,  OpenCvSharp.Scalar color ,  System.Int32 thickness ,  System.Int32 lineType ,  System.IntPtr hierarchy ,  System.Int32 maxLevel ,  OpenCvSharp.Point offset );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean imgproc_warpPerspective_MisArray_excsafe( System.IntPtr src ,  System.IntPtr dst , [MarshalAs(UnmanagedType.LPArray)] System.Single[,] m ,  System.Int32 mRow ,  System.Int32 mCol ,  OpenCvSharp.Size dsize ,  System.Int32 flags ,  System.Int32 borderMode ,  OpenCvSharp.Scalar borderValue );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean imgproc_remap_excsafe( System.IntPtr src ,  System.IntPtr dst ,  System.IntPtr map1 ,  System.IntPtr map2 ,  System.Int32 interpolation ,  System.Int32 borderMode ,  OpenCvSharp.Scalar borderValue );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean imgproc_convertMaps_excsafe( System.IntPtr map1 ,  System.IntPtr map2 ,  System.IntPtr dstmap1 ,  System.IntPtr dstmap2 ,  System.Int32 dstmap1Type ,  System.Int32 nninterpolation );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean imgproc_getRotationMatrix2D_excsafe(ref System.IntPtr ret,  OpenCvSharp.Point2f center ,  System.Double angle ,  System.Double scale );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean imgproc_invertAffineTransform_excsafe( System.IntPtr m ,  System.IntPtr im );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean imgproc_getPerspectiveTransform1_excsafe(ref System.IntPtr ret,  OpenCvSharp.Point2f[] src ,  OpenCvSharp.Point2f[] dst );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean imgproc_getPerspectiveTransform2_excsafe(ref System.IntPtr ret,  System.IntPtr src ,  System.IntPtr dst );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean imgproc_getAffineTransform1_excsafe(ref System.IntPtr ret,  OpenCvSharp.Point2f[] src ,  OpenCvSharp.Point2f[] dst );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean imgproc_getAffineTransform2_excsafe(ref System.IntPtr ret,  System.IntPtr src ,  System.IntPtr dst );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean imgproc_getRectSubPix_excsafe( System.IntPtr image ,  OpenCvSharp.Size patchSize ,  OpenCvSharp.Point2f center ,  System.IntPtr patch ,  System.Int32 patchType );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean imgproc_logPolar_excsafe( System.IntPtr src ,  System.IntPtr dst ,  OpenCvSharp.Point2f center ,  System.Double m ,  System.Int32 flags );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean imgproc_linearPolar_excsafe( System.IntPtr src ,  System.IntPtr dst ,  OpenCvSharp.Point2f center ,  System.Double maxRadius ,  System.Int32 flags );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean imgproc_integral1_excsafe( System.IntPtr src ,  System.IntPtr sum ,  System.Int32 sdepth );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean imgproc_integral2_excsafe( System.IntPtr src ,  System.IntPtr sum ,  System.IntPtr sqsum ,  System.Int32 sdepth );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean imgproc_integral3_excsafe( System.IntPtr src ,  System.IntPtr sum ,  System.IntPtr sqsum ,  System.IntPtr tilted ,  System.Int32 sdepth );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean imgproc_accumulate_excsafe( System.IntPtr src ,  System.IntPtr dst ,  System.IntPtr mask );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean imgproc_accumulateSquare_excsafe( System.IntPtr src ,  System.IntPtr dst ,  System.IntPtr mask );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean imgproc_accumulateProduct_excsafe( System.IntPtr src1 ,  System.IntPtr src2 ,  System.IntPtr dst ,  System.IntPtr mask );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean imgproc_accumulateWeighted_excsafe( System.IntPtr src ,  System.IntPtr dst ,  System.Double alpha ,  System.IntPtr mask );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean imgproc_PSNR_excsafe(ref System.Double ret,  System.IntPtr src1 ,  System.IntPtr src2 );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean imgproc_phaseCorrelate_excsafe(ref OpenCvSharp.Point2d ret,  System.IntPtr src1 ,  System.IntPtr src2 ,  System.IntPtr window );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean imgproc_phaseCorrelateRes_excsafe(ref OpenCvSharp.Point2d ret,  System.IntPtr src1 ,  System.IntPtr src2 ,  System.IntPtr window ,  out System.Double response );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean imgproc_createHanningWindow_excsafe( System.IntPtr dst ,  OpenCvSharp.Size winSize ,  System.Int32 type );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean imgproc_threshold_excsafe(ref System.Double ret,  System.IntPtr src ,  System.IntPtr dst ,  System.Double thresh ,  System.Double maxval ,  System.Int32 type );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean imgproc_adaptiveThreshold_excsafe( System.IntPtr src ,  System.IntPtr dst ,  System.Double maxValue ,  System.Int32 adaptiveMethod ,  System.Int32 thresholdType ,  System.Int32 blockSize ,  System.Double c );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean imgproc_pyrDown_excsafe( System.IntPtr src ,  System.IntPtr dst ,  OpenCvSharp.Size dstsize ,  System.Int32 borderType );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean imgproc_pyrUp_excsafe( System.IntPtr src ,  System.IntPtr dst ,  OpenCvSharp.Size dstsize ,  System.Int32 borderType );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean imgproc_undistort_excsafe( System.IntPtr src ,  System.IntPtr dst ,  System.IntPtr cameraMatrix ,  System.IntPtr distCoeffs ,  System.IntPtr newCameraMatrix );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean imgproc_getGaussianKernel_excsafe(ref System.IntPtr ret,  System.Int32 ksize ,  System.Double sigma ,  System.Int32 ktype );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean imgproc_getDerivKernels_excsafe( System.IntPtr kx ,  System.IntPtr ky ,  System.Int32 dx ,  System.Int32 dy ,  System.Int32 ksize ,  System.Int32 normalize ,  System.Int32 ktype );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean imgproc_getGaborKernel_excsafe(ref System.IntPtr ret,  OpenCvSharp.Size ksize ,  System.Double sigma ,  System.Double theta ,  System.Double lambd ,  System.Double gamma ,  System.Double psi ,  System.Int32 ktype );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean imgproc_getStructuringElement_excsafe(ref System.IntPtr ret,  System.Int32 shape ,  OpenCvSharp.Size ksize ,  OpenCvSharp.Point anchor );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean imgproc_medianBlur_excsafe( System.IntPtr src ,  System.IntPtr dst ,  System.Int32 ksize );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean imgproc_GaussianBlur_excsafe( System.IntPtr src ,  System.IntPtr dst ,  OpenCvSharp.Size ksize ,  System.Double sigmaX ,  System.Double sigmaY ,  System.Int32 borderType );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean imgproc_bilateralFilter_excsafe( System.IntPtr src ,  System.IntPtr dst ,  System.Int32 d ,  System.Double sigmaColor ,  System.Double sigmaSpace ,  System.Int32 borderType );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean imgproc_boxFilter_excsafe( System.IntPtr src ,  System.IntPtr dst ,  System.Int32 ddepth ,  OpenCvSharp.Size ksize ,  OpenCvSharp.Point anchor ,  System.Int32 normalize ,  System.Int32 borderType );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean imgproc_blur_excsafe( System.IntPtr src ,  System.IntPtr dst ,  OpenCvSharp.Size ksize ,  OpenCvSharp.Point anchor ,  System.Int32 borderType );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean imgproc_filter2D_excsafe( System.IntPtr src ,  System.IntPtr dst ,  System.Int32 ddepth ,  System.IntPtr kernel ,  OpenCvSharp.Point anchor ,  System.Double delta ,  System.Int32 borderType );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean imgproc_sepFilter2D_excsafe( System.IntPtr src ,  System.IntPtr dst ,  System.Int32 ddepth ,  System.IntPtr kernelX ,  System.IntPtr kernelY ,  OpenCvSharp.Point anchor ,  System.Double delta ,  System.Int32 borderType );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean imgproc_Sobel_excsafe( System.IntPtr src ,  System.IntPtr dst ,  System.Int32 ddepth ,  System.Int32 dx ,  System.Int32 dy ,  System.Int32 ksize ,  System.Double scale ,  System.Double delta ,  System.Int32 borderType );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean imgproc_Scharr_excsafe( System.IntPtr src ,  System.IntPtr dst ,  System.Int32 ddepth ,  System.Int32 dx ,  System.Int32 dy ,  System.Double scale ,  System.Double delta ,  System.Int32 borderType );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean imgproc_Laplacian_excsafe( System.IntPtr src ,  System.IntPtr dst ,  System.Int32 ddepth ,  System.Int32 ksize ,  System.Double scale ,  System.Double delta ,  System.Int32 borderType );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean imgproc_Canny_excsafe( System.IntPtr src ,  System.IntPtr edges ,  System.Double threshold1 ,  System.Double threshold2 ,  System.Int32 apertureSize ,  System.Int32 L2gradient );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean imgproc_cornerEigenValsAndVecs_excsafe( System.IntPtr src ,  System.IntPtr dst ,  System.Int32 blockSize ,  System.Int32 ksize ,  System.Int32 borderType );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean imgproc_preCornerDetect_excsafe( System.IntPtr src ,  System.IntPtr dst ,  System.Int32 ksize ,  System.Int32 borderType );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean imgproc_cornerSubPix_excsafe( System.IntPtr image ,  System.IntPtr corners ,  OpenCvSharp.Size winSize ,  OpenCvSharp.Size zeroZone ,  OpenCvSharp.TermCriteria criteria );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean imgproc_goodFeaturesToTrack_excsafe( System.IntPtr src ,  System.IntPtr corners ,  System.Int32 maxCorners ,  System.Double qualityLevel ,  System.Double minDistance ,  System.IntPtr mask ,  System.Int32 blockSize ,  System.Int32 useHarrisDetector ,  System.Double k );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean imgproc_HoughLines_excsafe( System.IntPtr src ,  System.IntPtr lines ,  System.Double rho ,  System.Double theta ,  System.Int32 threshold ,  System.Double srn ,  System.Double stn );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean imgproc_HoughLinesP_excsafe( System.IntPtr src ,  System.IntPtr lines ,  System.Double rho ,  System.Double theta ,  System.Int32 threshold ,  System.Double minLineLength ,  System.Double maxLineG );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean imgproc_HoughCircles_excsafe( System.IntPtr src ,  System.IntPtr circles ,  System.Int32 method ,  System.Double dp ,  System.Double minDist ,  System.Double param1 ,  System.Double param2 ,  System.Int32 minRadius ,  System.Int32 maxRadius );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean imgproc_erode_excsafe( System.IntPtr src ,  System.IntPtr dst ,  System.IntPtr kernel ,  OpenCvSharp.Point anchor ,  System.Int32 iterations ,  System.Int32 borderType ,  OpenCvSharp.Scalar borderValue );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean imgproc_dilate_excsafe( System.IntPtr src ,  System.IntPtr dst ,  System.IntPtr kernel ,  OpenCvSharp.Point anchor ,  System.Int32 iterations ,  System.Int32 borderType ,  OpenCvSharp.Scalar borderValue );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean imgproc_morphologyEx_excsafe( System.IntPtr src ,  System.IntPtr dst ,  System.Int32 op ,  System.IntPtr kernel ,  OpenCvSharp.Point anchor ,  System.Int32 iterations ,  System.Int32 borderType ,  OpenCvSharp.Scalar borderValue );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean imgproc_resize_excsafe( System.IntPtr src ,  System.IntPtr dst ,  OpenCvSharp.Size dsize ,  System.Double fx ,  System.Double fy ,  System.Int32 interpolation );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean imgproc_warpAffine_excsafe( System.IntPtr src ,  System.IntPtr dst ,  System.IntPtr m ,  OpenCvSharp.Size dsize ,  System.Int32 flags ,  System.Int32 borderMode ,  OpenCvSharp.Scalar borderValue );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean imgproc_warpPerspective_MisInputArray_excsafe( System.IntPtr src ,  System.IntPtr dst ,  System.IntPtr m ,  OpenCvSharp.Size dsize ,  System.Int32 flags ,  System.Int32 borderMode ,  OpenCvSharp.Scalar borderValue );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean features2d_MSER_setMaxArea_excsafe( System.IntPtr obj ,  System.Int32 maxArea );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean features2d_MSER_getMaxArea_excsafe(ref System.Int32 ret,  System.IntPtr obj );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean features2d_MSER_setPass2Only_excsafe( System.IntPtr obj ,  System.Int32 f );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean features2d_MSER_getPass2Only_excsafe(ref System.Int32 ret,  System.IntPtr obj );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean features2d_ORB_create_excsafe(ref System.IntPtr ret,  System.Int32 nFeatures ,  System.Single scaleFactor ,  System.Int32 nlevels ,  System.Int32 edgeThreshold ,  System.Int32 firstLevel ,  System.Int32 wtaK ,  System.Int32 scoreType ,  System.Int32 patchSize );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean features2d_Ptr_ORB_delete_excsafe( System.IntPtr ptr );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean features2d_Ptr_ORB_get_excsafe(ref System.IntPtr ret,  System.IntPtr ptr );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean features2d_ORB_setMaxFeatures_excsafe( System.IntPtr obj ,  System.Int32 val );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean features2d_ORB_getMaxFeatures_excsafe(ref System.Int32 ret,  System.IntPtr obj );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean features2d_ORB_setScaleFactor_excsafe( System.IntPtr obj ,  System.Double val );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean features2d_ORB_getScaleFactor_excsafe(ref System.Double ret,  System.IntPtr obj );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean features2d_ORB_setNLevels_excsafe( System.IntPtr obj ,  System.Int32 val );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean features2d_ORB_getNLevels_excsafe(ref System.Int32 ret,  System.IntPtr obj );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean features2d_ORB_setEdgeThreshold_excsafe( System.IntPtr obj ,  System.Int32 val );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean features2d_ORB_getEdgeThreshold_excsafe(ref System.Int32 ret,  System.IntPtr obj );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean features2d_ORB_setFirstLevel_excsafe( System.IntPtr obj ,  System.Int32 val );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean features2d_ORB_getFirstLevel_excsafe(ref System.Int32 ret,  System.IntPtr obj );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean features2d_ORB_setWTA_K_excsafe( System.IntPtr obj ,  System.Int32 val );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean features2d_ORB_getWTA_K_excsafe(ref System.Int32 ret,  System.IntPtr obj );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean features2d_ORB_setScoreType_excsafe( System.IntPtr obj ,  System.Int32 val );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean features2d_ORB_getScoreType_excsafe(ref System.Int32 ret,  System.IntPtr obj );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean features2d_ORB_setPatchSize_excsafe( System.IntPtr obj ,  System.Int32 val );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean features2d_ORB_getPatchSize_excsafe(ref System.Int32 ret,  System.IntPtr obj );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean features2d_ORB_setFastThreshold_excsafe( System.IntPtr obj ,  System.Int32 val );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean features2d_ORB_getFastThreshold_excsafe(ref System.Int32 ret,  System.IntPtr obj );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean features2d_SimpleBlobDetector_create_excsafe(ref System.IntPtr ret,  ref OpenCvSharp.SimpleBlobDetector.WParams parameters );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean features2d_Ptr_SimpleBlobDetector_get_excsafe(ref System.IntPtr ret,  System.IntPtr ptr );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean features2d_Ptr_SimpleBlobDetector_delete_excsafe( System.IntPtr ptr );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean features2d_Ptr_KAZE_delete_excsafe( System.IntPtr ptr );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean features2d_Ptr_KAZE_get_excsafe(ref System.IntPtr ret,  System.IntPtr ptr );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean features2d_KAZE_setDiffusivity_excsafe( System.IntPtr obj ,  System.Int32 val );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean features2d_KAZE_getDiffusivity_excsafe(ref System.Int32 ret,  System.IntPtr obj );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean features2d_KAZE_setExtended_excsafe( System.IntPtr obj ,  System.Boolean val );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean features2d_KAZE_getExtended_excsafe(ref System.Boolean ret,  System.IntPtr obj );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean features2d_KAZE_setNOctaveLayers_excsafe( System.IntPtr obj ,  System.Int32 val );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean features2d_KAZE_getNOctaveLayers_excsafe(ref System.Int32 ret,  System.IntPtr obj );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean features2d_KAZE_setNOctaves_excsafe( System.IntPtr obj ,  System.Int32 val );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean features2d_KAZE_getNOctaves_excsafe(ref System.Int32 ret,  System.IntPtr obj );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean features2d_KAZE_setThreshold_excsafe( System.IntPtr obj ,  System.Double val );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean features2d_KAZE_getThreshold_excsafe(ref System.Double ret,  System.IntPtr obj );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean features2d_KAZE_setUpright_excsafe( System.IntPtr obj ,  System.Boolean val );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean features2d_KAZE_getUpright_excsafe(ref System.Boolean ret,  System.IntPtr obj );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean features2d_KeyPointsFilter_runByImageBorder_excsafe( System.IntPtr keypoints ,  OpenCvSharp.Size imageSize ,  System.Int32 borderSize );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean features2d_KeyPointsFilter_runByKeypointSize_excsafe( System.IntPtr keypoints ,  System.Single minSize ,  System.Single maxSize );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean features2d_KeyPointsFilter_runByPixelsMask_excsafe( System.IntPtr keypoints ,  System.IntPtr mask );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean features2d_KeyPointsFilter_removeDuplicated_excsafe( System.IntPtr keypoints );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean features2d_KeyPointsFilter_retainBest_excsafe( System.IntPtr keypoints ,  System.Int32 npoints );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean features2d_MSER_create_excsafe(ref System.IntPtr ret,  System.Int32 delta ,  System.Int32 minArea ,  System.Int32 maxArea ,  System.Double maxVariation ,  System.Double minDiversity ,  System.Int32 maxEvolution ,  System.Double areaThreshold ,  System.Double minMargin ,  System.Int32 edgeBlurSize );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean features2d_Ptr_MSER_delete_excsafe( System.IntPtr ptr );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean features2d_MSER_detect_excsafe( System.IntPtr obj ,  System.IntPtr image ,  out System.IntPtr msers ,  System.IntPtr mask );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean features2d_Ptr_MSER_get_excsafe(ref System.IntPtr ret,  System.IntPtr ptr );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean features2d_MSER_detectRegions_excsafe( System.IntPtr obj ,  System.IntPtr image ,  System.IntPtr msers ,  System.IntPtr bboxes );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean features2d_MSER_setDelta_excsafe( System.IntPtr obj ,  System.Int32 delta );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean features2d_MSER_getDelta_excsafe(ref System.Int32 ret,  System.IntPtr obj );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean features2d_MSER_setMinArea_excsafe( System.IntPtr obj ,  System.Int32 minArea );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean features2d_MSER_getMinArea_excsafe(ref System.Int32 ret,  System.IntPtr obj );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean features2d_Ptr_Feature2D_delete_excsafe( System.IntPtr ptr );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean features2d_Feature2D_detect_Mat1_excsafe( System.IntPtr detector ,  System.IntPtr image ,  System.IntPtr keypoints ,  System.IntPtr mask );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean features2d_Feature2D_detect_Mat2_excsafe( System.IntPtr detector ,  System.IntPtr[] images ,  System.Int32 imageLength ,  System.IntPtr keypoints ,  System.IntPtr[] mask );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean features2d_Feature2D_detect_InputArray_excsafe( System.IntPtr detector ,  System.IntPtr image ,  System.IntPtr keypoints ,  System.IntPtr mask );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean features2d_Feature2D_compute1_excsafe( System.IntPtr obj ,  System.IntPtr image ,  System.IntPtr keypoints ,  System.IntPtr descriptors );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean features2d_Feature2D_compute2_excsafe( System.IntPtr detector ,  System.IntPtr[] images ,  System.Int32 imageLength ,  System.IntPtr keypoints ,  System.IntPtr[] descriptors ,  System.Int32 descriptorsLength );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean features2d_Feature2D_detectAndCompute_excsafe( System.IntPtr detector ,  System.IntPtr image ,  System.IntPtr mask ,  System.IntPtr keypoints ,  System.IntPtr descriptors ,  System.Int32 useProvidedKeypoints );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean features2d_Feature2D_descriptorSize_excsafe(ref System.Int32 ret,  System.IntPtr obj );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean features2d_Feature2D_descriptorType_excsafe(ref System.Int32 ret,  System.IntPtr obj );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean features2d_Feature2D_defaultNorm_excsafe(ref System.Int32 ret,  System.IntPtr obj );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean features2d_Feature2D_empty_excsafe(ref System.Int32 ret,  System.IntPtr obj );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean features2d_GFTTDetector_create_excsafe(ref System.IntPtr ret,  System.Int32 maxCorners ,  System.Double qualityLevel ,  System.Double minDistance ,  System.Int32 blockSize ,  System.Int32 useHarrisDetector ,  System.Double k );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean features2d_GFTTDetector_delete_excsafe( System.IntPtr obj );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean features2d_Ptr_GFTTDetector_get_excsafe(ref System.IntPtr ret,  System.IntPtr ptr );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean features2d_Ptr_GFTTDetector_delete_excsafe( System.IntPtr ptr );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean features2d_GFTTDetector_setMaxFeatures_excsafe( System.IntPtr obj ,  System.Int32 maxFeatures );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean features2d_GFTTDetector_getMaxFeatures_excsafe(ref System.Int32 ret,  System.IntPtr obj );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean features2d_GFTTDetector_setQualityLevel_excsafe( System.IntPtr obj ,  System.Double qlevel );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean features2d_GFTTDetector_getQualityLevel_excsafe(ref System.Double ret,  System.IntPtr obj );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean features2d_GFTTDetector_setMinDistance_excsafe( System.IntPtr obj ,  System.Double minDistance );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean features2d_GFTTDetector_getMinDistance_excsafe(ref System.Double ret,  System.IntPtr obj );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean features2d_GFTTDetector_setBlockSize_excsafe( System.IntPtr obj ,  System.Int32 blockSize );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean features2d_GFTTDetector_getBlockSize_excsafe(ref System.Int32 ret,  System.IntPtr obj );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean features2d_GFTTDetector_setHarrisDetector_excsafe( System.IntPtr obj ,  System.Int32 val );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean features2d_GFTTDetector_getHarrisDetector_excsafe(ref System.Int32 ret,  System.IntPtr obj );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean features2d_GFTTDetector_setK_excsafe( System.IntPtr obj ,  System.Double k );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean features2d_GFTTDetector_getK_excsafe(ref System.Double ret,  System.IntPtr obj );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean features2d_KAZE_create_excsafe(ref System.IntPtr ret,  System.Boolean extended ,  System.Boolean upright ,  System.Single threshold ,  System.Int32 nOctaves ,  System.Int32 nOctaveLayers ,  System.Int32 diffusivity );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean features2d_DescriptorMatcher_create_excsafe(ref System.IntPtr ret, [MarshalAs(UnmanagedType.LPStr)] System.String descriptorMatcherType );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean features2d_Ptr_DescriptorMatcher_get_excsafe(ref System.IntPtr ret,  System.IntPtr ptr );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean features2d_Ptr_DescriptorMatcher_delete_excsafe( System.IntPtr ptr );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean features2d_BFMatcher_new_excsafe(ref System.IntPtr ret,  System.Int32 normType ,  System.Int32 crossCheck );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean features2d_BFMatcher_delete_excsafe( System.IntPtr obj );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean features2d_BFMatcher_isMaskSupported_excsafe(ref System.Int32 ret,  System.IntPtr obj );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean features2d_Ptr_BFMatcher_get_excsafe(ref System.IntPtr ret,  System.IntPtr ptr );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean features2d_Ptr_BFMatcher_delete_excsafe( System.IntPtr ptr );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean features2d_FlannBasedMatcher_new_excsafe(ref System.IntPtr ret,  System.IntPtr indexParams ,  System.IntPtr searchParams );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean features2d_FlannBasedMatcher_delete_excsafe( System.IntPtr obj );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean features2d_FlannBasedMatcher_add_excsafe( System.IntPtr obj ,  System.IntPtr[] descriptors ,  System.Int32 descriptorsSize );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean features2d_FlannBasedMatcher_clear_excsafe( System.IntPtr obj );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean features2d_FlannBasedMatcher_train_excsafe( System.IntPtr obj );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean features2d_FlannBasedMatcher_isMaskSupported_excsafe(ref System.Int32 ret,  System.IntPtr obj );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean features2d_Ptr_FlannBasedMatcher_get_excsafe(ref System.IntPtr ret,  System.IntPtr ptr );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean features2d_Ptr_FlannBasedMatcher_delete_excsafe( System.IntPtr ptr );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean features2d_FAST1_excsafe( System.IntPtr image ,  System.IntPtr keypoints ,  System.Int32 threshold ,  System.Int32 nonmaxSupression );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean features2d_FAST2_excsafe( System.IntPtr image ,  System.IntPtr keypoints ,  System.Int32 threshold ,  System.Int32 nonmaxSupression ,  System.Int32 type );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean features2d_FastFeatureDetector_create_excsafe(ref System.IntPtr ret,  System.Int32 threshold ,  System.Int32 nonmaxSuppression );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean features2d_Ptr_FastFeatureDetector_delete_excsafe( System.IntPtr ptr );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean features2d_Ptr_FastFeatureDetector_get_excsafe(ref System.IntPtr ret,  System.IntPtr ptr );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean features2d_FastFeatureDetector_setThreshold_excsafe( System.IntPtr obj ,  System.Int32 threshold );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean features2d_FastFeatureDetector_getThreshold_excsafe(ref System.Int32 ret,  System.IntPtr obj );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean features2d_FastFeatureDetector_setNonmaxSuppression_excsafe( System.IntPtr obj ,  System.Int32 f );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean features2d_FastFeatureDetector_getNonmaxSuppression_excsafe(ref System.Int32 ret,  System.IntPtr obj );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean features2d_FastFeatureDetector_setType_excsafe( System.IntPtr obj ,  System.Int32 type );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean features2d_FastFeatureDetector_getType_excsafe(ref System.Int32 ret,  System.IntPtr obj );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean features2d_Ptr_Feature2D_get_excsafe(ref System.IntPtr ret,  System.IntPtr ptr );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean features2d_BOWImgDescriptorExtractor_compute2_excsafe( System.IntPtr obj ,  System.IntPtr image ,  System.IntPtr keypoints ,  System.IntPtr imgDescriptor );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean features2d_BOWImgDescriptorExtractor_descriptorSize_excsafe(ref System.Int32 ret,  System.IntPtr obj );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean features2d_BOWImgDescriptorExtractor_descriptorType_excsafe(ref System.Int32 ret,  System.IntPtr obj );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean features2d_BRISK_create1_excsafe(ref System.IntPtr ret,  System.Int32 thresh ,  System.Int32 octaves ,  System.Single patternScale );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean features2d_BRISK_create2_excsafe(ref System.IntPtr ret,  System.Single[] radiusList ,  System.Int32 radiusListLength ,  System.Int32[] numberList ,  System.Int32 numberListLength ,  System.Single dMax ,  System.Single dMin ,  System.Int32[] indexChange ,  System.Int32 indexChangeLength );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean features2d_Ptr_BRISK_delete_excsafe( System.IntPtr ptr );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean features2d_Ptr_BRISK_get_excsafe(ref System.IntPtr ret,  System.IntPtr ptr );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean features2d_DescriptorExtractor_delete_excsafe( System.IntPtr obj );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean features2d_DescriptorExtractor_compute1_excsafe( System.IntPtr obj ,  System.IntPtr image ,  System.IntPtr keypoint ,  System.IntPtr descriptors );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean features2d_DescriptorExtractor_compute2_excsafe( System.IntPtr obj ,  System.IntPtr[] images ,  System.Int32 imagesSize ,  System.IntPtr keypoints ,  System.IntPtr[] descriptors ,  System.Int32 descriptorsSize );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean features2d_DescriptorExtractor_descriptorSize_excsafe(ref System.Int32 ret,  System.IntPtr obj );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean features2d_DescriptorExtractor_descriptorType_excsafe(ref System.Int32 ret,  System.IntPtr obj );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean features2d_DescriptorExtractor_empty_excsafe(ref System.Int32 ret,  System.IntPtr obj );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean features2d_DescriptorExtractor_create_excsafe(ref System.IntPtr ret, [MarshalAs(UnmanagedType.LPStr)] System.String descriptorExtractorType );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean features2d_Ptr_DescriptorExtractor_get_excsafe(ref System.IntPtr ret,  System.IntPtr ptr );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean features2d_Ptr_DescriptorExtractor_delete_excsafe( System.IntPtr ptr );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean features2d_DescriptorMatcher_add_excsafe( System.IntPtr obj ,  System.IntPtr[] descriptors ,  System.Int32 descriptorLength );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean features2d_DescriptorMatcher_getTrainDescriptors_excsafe( System.IntPtr obj ,  System.IntPtr dst );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean features2d_DescriptorMatcher_clear_excsafe( System.IntPtr obj );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean features2d_DescriptorMatcher_empty_excsafe(ref System.Int32 ret,  System.IntPtr obj );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean features2d_DescriptorMatcher_isMaskSupported_excsafe(ref System.Int32 ret,  System.IntPtr obj );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean features2d_DescriptorMatcher_train_excsafe( System.IntPtr obj );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean features2d_DescriptorMatcher_match1_excsafe( System.IntPtr obj ,  System.IntPtr queryDescriptors ,  System.IntPtr trainDescriptors ,  System.IntPtr matches ,  System.IntPtr mask );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean features2d_DescriptorMatcher_knnMatch1_excsafe( System.IntPtr obj ,  System.IntPtr queryDescriptors ,  System.IntPtr trainDescriptors ,  System.IntPtr matches ,  System.Int32 k ,  System.IntPtr mask ,  System.Int32 compactResult );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean features2d_DescriptorMatcher_radiusMatch1_excsafe( System.IntPtr obj ,  System.IntPtr queryDescriptors ,  System.IntPtr trainDescriptors ,  System.IntPtr matches ,  System.Single maxDistance ,  System.IntPtr mask ,  System.Int32 compactResult );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean features2d_DescriptorMatcher_match2_excsafe( System.IntPtr obj ,  System.IntPtr queryDescriptors ,  System.IntPtr matches ,  System.IntPtr[] masks ,  System.Int32 masksSize );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean features2d_DescriptorMatcher_knnMatch2_excsafe( System.IntPtr obj ,  System.IntPtr queryDescriptors ,  System.IntPtr matches ,  System.Int32 k ,  System.IntPtr[] masks ,  System.Int32 masksSize ,  System.Int32 compactResult );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean features2d_DescriptorMatcher_radiusMatch2_excsafe( System.IntPtr obj ,  System.IntPtr queryDescriptors ,  System.IntPtr matches ,  System.Single maxDistance ,  System.IntPtr[] masks ,  System.Int32 masksSize ,  System.Int32 compactResult );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean features2d_AKAZE_getDescriptorSize_excsafe(ref System.Int32 ret,  System.IntPtr obj );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean features2d_AKAZE_setDescriptorChannels_excsafe( System.IntPtr obj ,  System.Int32 val );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean features2d_AKAZE_getDescriptorChannels_excsafe(ref System.Int32 ret,  System.IntPtr obj );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean features2d_AKAZE_setThreshold_excsafe( System.IntPtr obj ,  System.Double val );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean features2d_AKAZE_getThreshold_excsafe(ref System.Double ret,  System.IntPtr obj );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean features2d_AKAZE_setNOctaves_excsafe( System.IntPtr obj ,  System.Int32 val );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean features2d_AKAZE_getNOctaves_excsafe(ref System.Int32 ret,  System.IntPtr obj );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean features2d_AKAZE_setNOctaveLayers_excsafe( System.IntPtr obj ,  System.Int32 val );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean features2d_AKAZE_getNOctaveLayers_excsafe(ref System.Int32 ret,  System.IntPtr obj );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean features2d_AKAZE_setDiffusivity_excsafe( System.IntPtr obj ,  System.Int32 val );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean features2d_AKAZE_getDiffusivity_excsafe(ref System.Int32 ret,  System.IntPtr obj );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean features2d_BOWTrainer_add_excsafe( System.IntPtr obj ,  System.IntPtr descriptors );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean features2d_BOWTrainer_getDescriptors_excsafe( System.IntPtr obj ,  System.IntPtr descriptors );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean features2d_BOWTrainer_descriptorsCount_excsafe(ref System.Int32 ret,  System.IntPtr obj );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean features2d_BOWTrainer_clear_excsafe( System.IntPtr obj );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean features2d_BOWKMeansTrainer_new_excsafe(ref System.IntPtr ret,  System.Int32 clusterCount ,  OpenCvSharp.TermCriteria termcrit ,  System.Int32 attempts ,  System.Int32 flags );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean features2d_BOWKMeansTrainer_delete_excsafe( System.IntPtr obj );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean features2d_BOWKMeansTrainer_cluster1_excsafe(ref System.IntPtr ret,  System.IntPtr obj );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean features2d_BOWKMeansTrainer_cluster2_excsafe(ref System.IntPtr ret,  System.IntPtr obj ,  System.IntPtr descriptors );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean features2d_BOWImgDescriptorExtractor_new1_Ptr_excsafe(ref System.IntPtr ret,  System.IntPtr dextractor ,  System.IntPtr dmatcher );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean features2d_BOWImgDescriptorExtractor_new2_Ptr_excsafe(ref System.IntPtr ret,  System.IntPtr dmatcher );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean features2d_BOWImgDescriptorExtractor_new1_RawPtr_excsafe(ref System.IntPtr ret,  System.IntPtr dextractor ,  System.IntPtr dmatcher );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean features2d_BOWImgDescriptorExtractor_new2_RawPtr_excsafe(ref System.IntPtr ret,  System.IntPtr dmatcher );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean features2d_BOWImgDescriptorExtractor_delete_excsafe( System.IntPtr obj );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean features2d_BOWImgDescriptorExtractor_setVocabulary_excsafe( System.IntPtr obj ,  System.IntPtr vocabulary );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean features2d_BOWImgDescriptorExtractor_getVocabulary_excsafe(ref System.IntPtr ret,  System.IntPtr obj );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean features2d_BOWImgDescriptorExtractor_compute11_excsafe( System.IntPtr obj ,  System.IntPtr image ,  System.IntPtr keypoints ,  System.IntPtr imgDescriptor ,  System.IntPtr pointIdxsOfClusters ,  System.IntPtr descriptors );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean features2d_BOWImgDescriptorExtractor_compute12_excsafe( System.IntPtr obj ,  System.IntPtr keypointDescriptors ,  System.IntPtr imgDescriptor ,  System.IntPtr pointIdxsOfClusters );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean face_LBPHFaceRecognizer_setThreshold_excsafe( System.IntPtr obj ,  System.Double val );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean face_LBPHFaceRecognizer_getHistograms_excsafe( System.IntPtr obj ,  System.IntPtr dst );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean face_LBPHFaceRecognizer_getLabels_excsafe( System.IntPtr obj ,  System.IntPtr dst );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean face_Ptr_LBPHFaceRecognizer_get_excsafe(ref System.IntPtr ret,  System.IntPtr obj );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean face_Ptr_LBPHFaceRecognizer_delete_excsafe( System.IntPtr obj );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean features2d_drawKeypoints_excsafe( System.IntPtr image ,  OpenCvSharp.KeyPoint[] keypoints ,  System.Int32 keypointsLength ,  System.IntPtr outImage ,  OpenCvSharp.Scalar color ,  System.Int32 flags );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean features2d_drawMatches1_excsafe( System.IntPtr img1 ,  OpenCvSharp.KeyPoint[] keypoints1 ,  System.Int32 keypoints1Length ,  System.IntPtr img2 ,  OpenCvSharp.KeyPoint[] keypoints2 ,  System.Int32 keypoints2Length ,  OpenCvSharp.DMatch[] matches1to2 ,  System.Int32 matches1to2Length ,  System.IntPtr outImg ,  OpenCvSharp.Scalar matchColor ,  OpenCvSharp.Scalar singlePointColor ,  System.Byte[] matchesMask ,  System.Int32 matchesMaskLength ,  System.Int32 flags );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean features2d_drawMatches2_excsafe( System.IntPtr img1 ,  OpenCvSharp.KeyPoint[] keypoints1 ,  System.Int32 keypoints1Length ,  System.IntPtr img2 ,  OpenCvSharp.KeyPoint[] keypoints2 ,  System.Int32 keypoints2Length ,  System.IntPtr[] matches1to2 ,  System.Int32 matches1to2Size1 ,  System.Int32[] matches1to2Size2 ,  System.IntPtr outImg ,  OpenCvSharp.Scalar matchColor ,  OpenCvSharp.Scalar singlePointColor ,  System.IntPtr[] matchesMask ,  System.Int32 matchesMaskSize1 ,  System.Int32[] matchesMaskSize2 ,  System.Int32 flags );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean features2d_evaluateFeatureDetector_excsafe( System.IntPtr img1 ,  System.IntPtr img2 ,  System.IntPtr H1to2 ,  System.IntPtr keypoints1 ,  System.IntPtr keypoints2 ,  out System.Single repeatability ,  out System.Int32 correspCount );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean features2d_computeRecallPrecisionCurve_excsafe( System.IntPtr[] matches1to2 ,  System.Int32 matches1to2Size1 ,  System.Int32[] matches1to2Size2 ,  System.IntPtr[] correctMatches1to2Mask ,  System.Int32 correctMatches1to2MaskSize1 ,  System.Int32[] correctMatches1to2MaskSize2 ,  System.IntPtr recallPrecisionCurve );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean features2d_getRecall_excsafe(ref System.Single ret,  OpenCvSharp.Point2f[] recallPrecisionCurve ,  System.Int32 recallPrecisionCurveSize ,  System.Single l_precision );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean features2d_getNearestPoint_excsafe(ref System.Int32 ret,  OpenCvSharp.Point2f[] recallPrecisionCurve ,  System.Int32 recallPrecisionCurveSize ,  System.Single l_precision );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean features2d_AGAST_excsafe( System.IntPtr image ,  System.IntPtr keypoints ,  System.Int32 threshold ,  System.Int32 nonmaxSuppression ,  System.Int32 type );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean features2d_AgastFeatureDetector_create_excsafe(ref System.IntPtr ret,  System.Int32 threshold ,  System.Int32 nonmaxSuppression ,  System.Int32 type );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean features2d_Ptr_AgastFeatureDetector_delete_excsafe( System.IntPtr ptr );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean features2d_Ptr_AgastFeatureDetector_get_excsafe(ref System.IntPtr ret,  System.IntPtr ptr );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean features2d_AgastFeatureDetector_setThreshold_excsafe( System.IntPtr obj ,  System.Int32 val );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean features2d_AgastFeatureDetector_getThreshold_excsafe(ref System.Int32 ret,  System.IntPtr obj );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean features2d_AgastFeatureDetector_setNonmaxSuppression_excsafe( System.IntPtr obj ,  System.Int32 val );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean features2d_AgastFeatureDetector_getNonmaxSuppression_excsafe(ref System.Int32 ret,  System.IntPtr obj );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean features2d_AgastFeatureDetector_setType_excsafe( System.IntPtr obj ,  System.Int32 val );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean features2d_AgastFeatureDetector_getType_excsafe(ref System.Int32 ret,  System.IntPtr obj );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean features2d_AKAZE_create_excsafe(ref System.IntPtr ret,  System.Int32 descriptor_type ,  System.Int32 descriptor_size ,  System.Int32 descriptor_channels ,  System.Single threshold ,  System.Int32 nOctaves ,  System.Int32 nOctaveLayers ,  System.Int32 diffusivity );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean features2d_Ptr_AKAZE_delete_excsafe( System.IntPtr ptr );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean features2d_Ptr_AKAZE_get_excsafe(ref System.IntPtr ret,  System.IntPtr ptr );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean features2d_AKAZE_setDescriptorType_excsafe( System.IntPtr obj ,  System.Int32 val );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean features2d_AKAZE_getDescriptorType_excsafe(ref System.Int32 ret,  System.IntPtr obj );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean features2d_AKAZE_setDescriptorSize_excsafe( System.IntPtr obj ,  System.Int32 val );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean face_FaceRecognizer_train_excsafe( System.IntPtr obj ,  System.IntPtr[] src ,  System.Int32 srcLength ,  System.Int32[] labels ,  System.Int32 labelsLength );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean face_FaceRecognizer_update_excsafe( System.IntPtr obj ,  System.IntPtr[] src ,  System.Int32 srcLength ,  System.Int32[] labels ,  System.Int32 labelsLength );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean face_FaceRecognizer_predict1_excsafe(ref System.Int32 ret,  System.IntPtr obj ,  System.IntPtr src );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean face_FaceRecognizer_predict2_excsafe( System.IntPtr obj ,  System.IntPtr src ,  out System.Int32 label ,  out System.Double confidence );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean face_FaceRecognizer_write1_excsafe( System.IntPtr obj ,  System.String filename );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean face_FaceRecognizer_read1_excsafe( System.IntPtr obj ,  System.String filename );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean face_FaceRecognizer_write2_excsafe( System.IntPtr obj ,  System.IntPtr fs );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean face_FaceRecognizer_read2_excsafe( System.IntPtr obj ,  System.IntPtr fs );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean face_FaceRecognizer_setLabelInfo_excsafe( System.IntPtr obj ,  System.Int32 label , [MarshalAs(UnmanagedType.LPStr)] System.String strInfo );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean face_FaceRecognizer_getLabelInfo_excsafe( System.IntPtr obj ,  System.Int32 label ,  System.IntPtr dst );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean face_FaceRecognizer_getLabelsByString_excsafe( System.IntPtr obj , [MarshalAs(UnmanagedType.LPStr)] System.String str ,  System.IntPtr dst );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean face_FaceRecognizer_getThreshold_excsafe(ref System.Double ret,  System.IntPtr obj );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean face_FaceRecognizer_setThreshold_excsafe( System.IntPtr obj ,  System.Double val );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean face_Ptr_FaceRecognizer_get_excsafe(ref System.IntPtr ret,  System.IntPtr obj );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean face_Ptr_FaceRecognizer_delete_excsafe( System.IntPtr obj );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean face_FisherFaceRecognizer_create_excsafe(ref System.IntPtr ret,  System.Int32 numComponents ,  System.Double threshold );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean face_Ptr_FisherFaceRecognizer_get_excsafe(ref System.IntPtr ret,  System.IntPtr obj );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean face_Ptr_FisherFaceRecognizer_delete_excsafe( System.IntPtr obj );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean face_LBPHFaceRecognizer_create_excsafe(ref System.IntPtr ret,  System.Int32 radius ,  System.Int32 neighbors ,  System.Int32 gridX ,  System.Int32 gridY ,  System.Double threshold );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean face_LBPHFaceRecognizer_getGridX_excsafe(ref System.Int32 ret,  System.IntPtr obj );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean face_LBPHFaceRecognizer_setGridX_excsafe( System.IntPtr obj ,  System.Int32 val );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean face_LBPHFaceRecognizer_getGridY_excsafe(ref System.Int32 ret,  System.IntPtr obj );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean face_LBPHFaceRecognizer_setGridY_excsafe( System.IntPtr obj ,  System.Int32 val );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean face_LBPHFaceRecognizer_getRadius_excsafe(ref System.Int32 ret,  System.IntPtr obj );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean face_LBPHFaceRecognizer_setRadius_excsafe( System.IntPtr obj ,  System.Int32 val );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean face_LBPHFaceRecognizer_getNeighbors_excsafe(ref System.Int32 ret,  System.IntPtr obj );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean face_LBPHFaceRecognizer_setNeighbors_excsafe( System.IntPtr obj ,  System.Int32 val );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean face_LBPHFaceRecognizer_getThreshold_excsafe(ref System.Double ret,  System.IntPtr obj );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean face_FacemarkAAM_create_excsafe(ref System.IntPtr ret,  System.IntPtr @params );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean face_Ptr_FacemarkAAM_get_excsafe(ref System.IntPtr ret,  System.IntPtr obj );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean face_Ptr_FacemarkAAM_delete_excsafe( System.IntPtr obj );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean face_FacemarkAAM_Params_new_excsafe(ref System.IntPtr ret);

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean face_FacemarkAAM_Params_delete_excsafe( System.IntPtr obj );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean face_FacemarkAAM_Params_model_filename_get_excsafe( System.IntPtr obj ,  System.IntPtr s );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean face_FacemarkAAM_Params_model_filename_set_excsafe( System.IntPtr obj , [MarshalAs(UnmanagedType.LPStr)] System.String s );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean face_FacemarkAAM_Params_m_get_excsafe(ref System.Int32 ret,  System.IntPtr obj );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean face_FacemarkAAM_Params_m_set_excsafe( System.IntPtr obj ,  System.Int32 val );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean face_FacemarkAAM_Params_n_get_excsafe(ref System.Int32 ret,  System.IntPtr obj );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean face_FacemarkAAM_Params_n_set_excsafe( System.IntPtr obj ,  System.Int32 val );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean face_FacemarkAAM_Params_n_iter_get_excsafe(ref System.Int32 ret,  System.IntPtr obj );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean face_FacemarkAAM_Params_n_iter_set_excsafe( System.IntPtr obj ,  System.Int32 val );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean face_FacemarkAAM_Params_verbose_get_excsafe(ref System.Int32 ret,  System.IntPtr obj );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean face_FacemarkAAM_Params_verbose_set_excsafe( System.IntPtr obj ,  System.Int32 val );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean face_FacemarkAAM_Params_save_model_get_excsafe(ref System.Int32 ret,  System.IntPtr obj );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean face_FacemarkAAM_Params_save_model_set_excsafe( System.IntPtr obj ,  System.Int32 val );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean face_FacemarkAAM_Params_max_m_get_excsafe(ref System.Int32 ret,  System.IntPtr obj );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean face_FacemarkAAM_Params_max_m_set_excsafe( System.IntPtr obj ,  System.Int32 val );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean face_FacemarkAAM_Params_max_n_get_excsafe(ref System.Int32 ret,  System.IntPtr obj );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean face_FacemarkAAM_Params_max_n_set_excsafe( System.IntPtr obj ,  System.Int32 val );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean face_FacemarkAAM_Params_texture_max_m_get_excsafe(ref System.Int32 ret,  System.IntPtr obj );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean face_FacemarkAAM_Params_texture_max_m_set_excsafe( System.IntPtr obj ,  System.Int32 val );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean face_FacemarkAAM_Params_scales_get_excsafe( System.IntPtr obj ,  System.IntPtr v );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean face_FacemarkAAM_Params_scales_set_excsafe( System.IntPtr obj ,  System.IntPtr v );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean face_FacemarkAAM_Params_read_excsafe( System.IntPtr obj ,  System.IntPtr fn );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean face_FacemarkAAM_Params_write_excsafe( System.IntPtr obj ,  System.IntPtr fs );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean face_FaceRecognizer_delete_excsafe( System.IntPtr obj );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean face_FacemarkLBF_Params_initShape_n_get_excsafe(ref System.Int32 ret,  System.IntPtr obj );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean face_FacemarkLBF_Params_initShape_n_set_excsafe( System.IntPtr obj ,  System.Int32 val );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean face_FacemarkLBF_Params_stages_n_get_excsafe(ref System.Int32 ret,  System.IntPtr obj );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean face_FacemarkLBF_Params_stages_n_set_excsafe( System.IntPtr obj ,  System.Int32 val );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean face_FacemarkLBF_Params_tree_n_get_excsafe(ref System.Int32 ret,  System.IntPtr obj );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean face_FacemarkLBF_Params_tree_n_set_excsafe( System.IntPtr obj ,  System.Int32 val );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean face_FacemarkLBF_Params_tree_depth_get_excsafe(ref System.Int32 ret,  System.IntPtr obj );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean face_FacemarkLBF_Params_tree_depth_set_excsafe( System.IntPtr obj ,  System.Int32 val );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean face_FacemarkLBF_Params_bagging_overlap_get_excsafe(ref System.Double ret,  System.IntPtr obj );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean face_FacemarkLBF_Params_bagging_overlap_set_excsafe( System.IntPtr obj ,  System.Double val );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean face_FacemarkLBF_Params_model_filename_get_excsafe( System.IntPtr obj ,  System.IntPtr s );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean face_FacemarkLBF_Params_model_filename_set_excsafe( System.IntPtr obj , [MarshalAs(UnmanagedType.LPStr)] System.String s );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean face_FacemarkLBF_Params_save_model_get_excsafe(ref System.Int32 ret,  System.IntPtr obj );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean face_FacemarkLBF_Params_save_model_set_excsafe( System.IntPtr obj ,  System.Int32 val );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean face_FacemarkLBF_Params_seed_get_excsafe(ref System.UInt32 ret,  System.IntPtr obj );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean face_FacemarkLBF_Params_seed_set_excsafe( System.IntPtr obj ,  System.UInt32 val );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean face_FacemarkLBF_Params_feats_m_get_excsafe( System.IntPtr obj ,  System.IntPtr v );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean face_FacemarkLBF_Params_feats_m_set_excsafe( System.IntPtr obj ,  System.IntPtr v );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean face_FacemarkLBF_Params_radius_m_get_excsafe( System.IntPtr obj ,  System.IntPtr v );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean face_FacemarkLBF_Params_radius_m_set_excsafe( System.IntPtr obj ,  System.IntPtr v );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean face_FacemarkLBF_Params_pupils0_get_excsafe( System.IntPtr obj ,  System.IntPtr v );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean face_FacemarkLBF_Params_pupils0_set_excsafe( System.IntPtr obj ,  System.IntPtr v );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean face_FacemarkLBF_Params_pupils1_get_excsafe( System.IntPtr obj ,  System.IntPtr v );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean face_FacemarkLBF_Params_pupils1_set_excsafe( System.IntPtr obj ,  System.IntPtr v );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean face_FacemarkLBF_Params_detectROI_get_excsafe(ref OpenCvSharp.Rect ret,  System.IntPtr obj );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean face_FacemarkLBF_Params_detectROI_set_excsafe( System.IntPtr obj ,  OpenCvSharp.Rect val );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean face_FacemarkLBF_Params_read_excsafe( System.IntPtr obj ,  System.IntPtr fn );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean face_FacemarkLBF_Params_write_excsafe( System.IntPtr obj ,  System.IntPtr fs );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean face_BasicFaceRecognizer_getMean_excsafe( System.IntPtr obj ,  System.IntPtr dst );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean face_Ptr_BasicFaceRecognizer_get_excsafe(ref System.IntPtr ret,  System.IntPtr obj );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean face_Ptr_BasicFaceRecognizer_delete_excsafe( System.IntPtr obj );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean face_EigenFaceRecognizer_create_excsafe(ref System.IntPtr ret,  System.Int32 numComponents ,  System.Double threshold );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean face_Ptr_EigenFaceRecognizer_get_excsafe(ref System.IntPtr ret,  System.IntPtr obj );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean face_Ptr_EigenFaceRecognizer_delete_excsafe( System.IntPtr obj );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean face_Facemark_read_excsafe( System.IntPtr obj ,  System.IntPtr fn );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean face_Facemark_write_excsafe( System.IntPtr obj ,  System.IntPtr fs );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean face_Facemark_addTrainingSample_excsafe(ref System.Int32 ret,  System.IntPtr obj ,  System.IntPtr image ,  System.IntPtr landmarks );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean face_Facemark_training_excsafe( System.IntPtr obj ,  System.IntPtr parameters );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean face_Facemark_loadModel_excsafe( System.IntPtr obj , [MarshalAs(UnmanagedType.LPStr)] System.String model );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean face_Facemark_fit_excsafe(ref System.Int32 ret,  System.IntPtr obj ,  System.IntPtr image ,  System.IntPtr faces ,  System.IntPtr landmarks ,  System.IntPtr config );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean face_Facemark_setFaceDetector_excsafe(ref System.Int32 ret,  System.IntPtr obj ,  System.IntPtr detector ,  System.IntPtr userData );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean face_Facemark_getFaces_OutputArray_excsafe(ref System.Int32 ret,  System.IntPtr obj ,  System.IntPtr image ,  System.IntPtr faces );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean face_Facemark_getFaces_vectorOfRect_excsafe(ref System.Int32 ret,  System.IntPtr obj ,  System.IntPtr image ,  System.IntPtr faces );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean face_FacemarkLBF_create_excsafe(ref System.IntPtr ret,  System.IntPtr @params );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean face_Ptr_FacemarkLBF_get_excsafe(ref System.IntPtr ret,  System.IntPtr obj );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean face_Ptr_FacemarkLBF_delete_excsafe( System.IntPtr obj );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean face_FacemarkLBF_Params_new_excsafe(ref System.IntPtr ret);

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean face_FacemarkLBF_Params_delete_excsafe( System.IntPtr obj );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean face_FacemarkLBF_Params_shape_offset_get_excsafe(ref System.Double ret,  System.IntPtr obj );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean face_FacemarkLBF_Params_shape_offset_set_excsafe( System.IntPtr obj ,  System.Double val );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean face_FacemarkLBF_Params_cascade_face_get_excsafe( System.IntPtr obj ,  System.IntPtr s );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean face_FacemarkLBF_Params_cascade_face_set_excsafe( System.IntPtr obj , [MarshalAs(UnmanagedType.LPStr)] System.String s );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean face_FacemarkLBF_Params_verbose_get_excsafe(ref System.Int32 ret,  System.IntPtr obj );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean face_FacemarkLBF_Params_verbose_set_excsafe( System.IntPtr obj ,  System.Int32 val );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean face_FacemarkLBF_Params_n_landmarks_get_excsafe(ref System.Int32 ret,  System.IntPtr obj );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean face_FacemarkLBF_Params_n_landmarks_set_excsafe( System.IntPtr obj ,  System.Int32 val );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean dnn_blobFromImage_excsafe(ref System.IntPtr ret,  System.IntPtr image ,  System.Double scalefactor ,  OpenCvSharp.Size size ,  OpenCvSharp.Scalar mean ,  System.Int32 swapRB ,  System.Int32 crop );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean dnn_blobFromImages_excsafe(ref System.IntPtr ret,  System.IntPtr[] images ,  System.Int32 imagesLength ,  System.Double scalefactor ,  OpenCvSharp.Size size ,  OpenCvSharp.Scalar mean ,  System.Int32 swapRB ,  System.Int32 crop );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean dnn_shrinkCaffeModel_excsafe([MarshalAs(UnmanagedType.LPStr)] System.String src , [MarshalAs(UnmanagedType.LPStr)] System.String dst );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean dnn_Net_new_excsafe(ref System.IntPtr ret);

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean dnn_Net_delete_excsafe( System.IntPtr net );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean dnn_Net_empty_excsafe(ref System.Int32 ret,  System.IntPtr net );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean dnn_Net_getLayerId_excsafe(ref System.Int32 ret,  System.IntPtr net , [MarshalAs(UnmanagedType.LPStr)] System.String layer );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean dnn_Net_getLayerNames_excsafe( System.IntPtr net ,  System.IntPtr outVec );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean dnn_Net_connect1_excsafe( System.IntPtr net , [MarshalAs(UnmanagedType.LPStr)] System.String outPin , [MarshalAs(UnmanagedType.LPStr)] System.String inpPin );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean dnn_Net_connect2_excsafe( System.IntPtr net ,  System.Int32 outLayerId ,  System.Int32 outNum ,  System.Int32 inpLayerId ,  System.Int32 inpNum );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean dnn_Net_setInputsNames_excsafe( System.IntPtr net ,  System.String[] inputBlobNames ,  System.Int32 inputBlobNamesLength );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean dnn_Net_forward1_excsafe(ref System.IntPtr ret,  System.IntPtr net , [MarshalAs(UnmanagedType.LPStr)] System.String outputName );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean dnn_Net_forward2_excsafe( System.IntPtr net ,  System.IntPtr[] outputBlobs ,  System.Int32 outputBlobsLength , [MarshalAs(UnmanagedType.LPStr)] System.String outputName );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean dnn_Net_forward3_excsafe( System.IntPtr net ,  System.IntPtr[] outputBlobs ,  System.Int32 outputBlobsLength ,  System.String[] outBlobNames ,  System.Int32 outBlobNamesLength );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean dnn_Net_setHalideScheduler_excsafe( System.IntPtr net , [MarshalAs(UnmanagedType.LPStr)] System.String scheduler );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean dnn_Net_setPreferableBackend_excsafe( System.IntPtr net ,  System.Int32 backendId );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean dnn_Net_setPreferableTarget_excsafe( System.IntPtr net ,  System.Int32 targetId );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean dnn_Net_setInput_excsafe( System.IntPtr net ,  System.IntPtr blob , [MarshalAs(UnmanagedType.LPStr)] System.String name );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean dnn_Net_enableFusion_excsafe( System.IntPtr net ,  System.Int32 fusion );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean dnn_Net_getPerfProfile_excsafe(ref System.Int64 ret,  System.IntPtr net ,  System.IntPtr timings );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean face_BasicFaceRecognizer_getNumComponents_excsafe(ref System.Int32 ret,  System.IntPtr obj );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean face_BasicFaceRecognizer_setNumComponents_excsafe( System.IntPtr obj ,  System.Int32 val );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean face_BasicFaceRecognizer_getThreshold_excsafe(ref System.Double ret,  System.IntPtr obj );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean face_BasicFaceRecognizer_setThreshold_excsafe( System.IntPtr obj ,  System.Double val );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean face_BasicFaceRecognizer_getProjections_excsafe( System.IntPtr obj ,  System.IntPtr dst );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean face_BasicFaceRecognizer_getLabels_excsafe( System.IntPtr obj ,  System.IntPtr dst );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean face_BasicFaceRecognizer_getEigenValues_excsafe( System.IntPtr obj ,  System.IntPtr dst );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean face_BasicFaceRecognizer_getEigenVectors_excsafe( System.IntPtr obj ,  System.IntPtr dst );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean cuda_GpuMat_convertTo_excsafe( System.IntPtr obj ,  System.IntPtr m ,  System.Int32 rtype ,  System.Double alpha ,  System.Double beta );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean cuda_GpuMat_assignTo_excsafe( System.IntPtr obj ,  System.IntPtr m ,  System.Int32 type );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean cuda_GpuMat_setTo_excsafe(ref System.IntPtr ret,  System.IntPtr obj ,  OpenCvSharp.Scalar s ,  System.IntPtr mask );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean cuda_GpuMat_reshape_excsafe(ref System.IntPtr ret,  System.IntPtr obj ,  System.Int32 cn ,  System.Int32 rows );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean cuda_GpuMat_create1_excsafe( System.IntPtr obj ,  System.Int32 rows ,  System.Int32 cols ,  System.Int32 type );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean cuda_GpuMat_create2_excsafe( System.IntPtr obj ,  OpenCvSharp.Size size ,  System.Int32 type );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean cuda_GpuMat_release_excsafe( System.IntPtr obj );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean cuda_GpuMat_swap_excsafe( System.IntPtr obj ,  System.IntPtr mat );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean cuda_GpuMat_locateROI_excsafe( System.IntPtr obj ,  out OpenCvSharp.Size wholeSize ,  out OpenCvSharp.Point ofs );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean cuda_GpuMat_adjustROI_excsafe(ref System.IntPtr ret,  System.IntPtr obj ,  System.Int32 dtop ,  System.Int32 dbottom ,  System.Int32 dleft ,  System.Int32 drightt );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean cuda_GpuMat_isContinuous_excsafe(ref System.Int32 ret,  System.IntPtr obj );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean cuda_GpuMat_elemSize_excsafe(ref System.UInt64 ret,  System.IntPtr obj );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean cuda_GpuMat_elemSize1_excsafe(ref System.UInt64 ret,  System.IntPtr obj );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean cuda_GpuMat_type_excsafe(ref System.Int32 ret,  System.IntPtr obj );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean cuda_GpuMat_depth_excsafe(ref System.Int32 ret,  System.IntPtr obj );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean cuda_GpuMat_channels_excsafe(ref System.Int32 ret,  System.IntPtr obj );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean cuda_GpuMat_step1_excsafe(ref System.UInt64 ret,  System.IntPtr obj );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean cuda_GpuMat_size_excsafe(ref OpenCvSharp.Size ret,  System.IntPtr obj );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean cuda_GpuMat_empty_excsafe(ref System.Int32 ret,  System.IntPtr obj );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean cuda_GpuMat_ptr_excsafe(ref IntPtr ret,  System.IntPtr obj ,  System.Int32 y );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean cuda_createContinuous1_excsafe( System.Int32 rows ,  System.Int32 cols ,  System.Int32 type ,  System.IntPtr gm );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean cuda_createContinuous2_excsafe(ref System.IntPtr ret,  System.Int32 rows ,  System.Int32 cols ,  System.Int32 type );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean cuda_ensureSizeIsEnough_excsafe( System.Int32 rows ,  System.Int32 cols ,  System.Int32 type ,  System.IntPtr m );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean dnn_readNetFromDarknet_excsafe(ref System.IntPtr ret, [MarshalAs(UnmanagedType.LPStr)] System.String cfgFile , [MarshalAs(UnmanagedType.LPStr)] System.String darknetModel );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean dnn_readNetFromCaffe_excsafe(ref System.IntPtr ret, [MarshalAs(UnmanagedType.LPStr)] System.String prototxt , [MarshalAs(UnmanagedType.LPStr)] System.String caffeModel );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean dnn_readNetFromTensorflow_excsafe(ref System.IntPtr ret, [MarshalAs(UnmanagedType.LPStr)] System.String model , [MarshalAs(UnmanagedType.LPStr)] System.String config );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean dnn_readNetFromTorch_excsafe(ref System.IntPtr ret, [MarshalAs(UnmanagedType.LPStr)] System.String model ,  System.Int32 isBinary );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean dnn_readTorchBlob_excsafe(ref System.IntPtr ret, [MarshalAs(UnmanagedType.LPStr)] System.String filename ,  System.Int32 isBinary );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean cuda_GpuMat_new6_excsafe(ref System.IntPtr ret,  OpenCvSharp.Size size ,  System.Int32 type );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean cuda_GpuMat_new7_excsafe(ref System.IntPtr ret,  OpenCvSharp.Size size ,  System.Int32 type ,  System.IntPtr data ,  System.UInt64 step );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean cuda_GpuMat_new8_excsafe(ref System.IntPtr ret,  System.Int32 rows ,  System.Int32 cols ,  System.Int32 type ,  OpenCvSharp.Scalar s );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean cuda_GpuMat_new9_excsafe(ref System.IntPtr ret,  System.IntPtr m ,  OpenCvSharp.Range rowRange ,  OpenCvSharp.Range colRange );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean cuda_GpuMat_new10_excsafe(ref System.IntPtr ret,  System.IntPtr m ,  OpenCvSharp.Rect roi );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean cuda_GpuMat_new11_excsafe(ref System.IntPtr ret,  OpenCvSharp.Size size ,  System.Int32 type ,  OpenCvSharp.Scalar s );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean cuda_GpuMat_opToMat_excsafe(ref System.IntPtr ret,  System.IntPtr src );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean cuda_GpuMat_opToGpuMat_excsafe(ref System.IntPtr ret,  System.IntPtr src );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean cuda_GpuMat_opAssign_excsafe( System.IntPtr left ,  System.IntPtr right );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean cuda_GpuMat_opRange1_excsafe(ref System.IntPtr ret,  System.IntPtr src ,  OpenCvSharp.Rect roi );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean cuda_GpuMat_opRange2_excsafe(ref System.IntPtr ret,  System.IntPtr src ,  OpenCvSharp.Range rowRange ,  OpenCvSharp.Range colRange );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean cuda_GpuMat_flags_excsafe(ref System.Int32 ret,  System.IntPtr obj );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean cuda_GpuMat_rows_excsafe(ref System.Int32 ret,  System.IntPtr obj );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean cuda_GpuMat_cols_excsafe(ref System.Int32 ret,  System.IntPtr obj );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean cuda_GpuMat_step_excsafe(ref System.UInt64 ret,  System.IntPtr obj );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean cuda_GpuMat_data_excsafe(ref IntPtr ret,  System.IntPtr obj );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean cuda_GpuMat_refcount_excsafe(ref System.IntPtr ret,  System.IntPtr obj );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean cuda_GpuMat_datastart_excsafe(ref System.IntPtr ret,  System.IntPtr obj );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean cuda_GpuMat_dataend_excsafe(ref System.IntPtr ret,  System.IntPtr obj );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean cuda_GpuMat_upload_excsafe( System.IntPtr obj ,  System.IntPtr mat );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean cuda_GpuMat_download_excsafe( System.IntPtr obj ,  System.IntPtr mat );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean cuda_GpuMat_row_excsafe(ref System.IntPtr ret,  System.IntPtr obj ,  System.Int32 y );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean cuda_GpuMat_col_excsafe(ref System.IntPtr ret,  System.IntPtr obj ,  System.Int32 x );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean cuda_GpuMat_rowRange_excsafe(ref System.IntPtr ret,  System.IntPtr obj ,  System.Int32 startrow ,  System.Int32 endrow );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean cuda_GpuMat_colRange_excsafe(ref System.IntPtr ret,  System.IntPtr obj ,  System.Int32 startcol ,  System.Int32 endcol );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean cuda_GpuMat_clone_excsafe(ref System.IntPtr ret,  System.IntPtr obj );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean cuda_GpuMat_copyTo1_excsafe( System.IntPtr obj ,  System.IntPtr m );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean cuda_GpuMat_copyTo2_excsafe( System.IntPtr obj ,  System.IntPtr m ,  System.IntPtr mask );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean cuda_MOG2_GPU_history_excsafe(ref IntPtr ret,  System.IntPtr obj );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean cuda_MOG2_GPU_varThreshold_excsafe(ref IntPtr ret,  System.IntPtr obj );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean cuda_MOG2_GPU_backgroundRatio_excsafe(ref IntPtr ret,  System.IntPtr obj );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean cuda_MOG2_GPU_varThresholdGen_excsafe(ref IntPtr ret,  System.IntPtr obj );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean cuda_MOG2_GPU_fVarInit_excsafe(ref IntPtr ret,  System.IntPtr obj );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean cuda_MOG2_GPU_fVarMin_excsafe(ref IntPtr ret,  System.IntPtr obj );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean cuda_MOG2_GPU_fVarMax_excsafe(ref IntPtr ret,  System.IntPtr obj );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean cuda_MOG2_GPU_fCT_excsafe(ref IntPtr ret,  System.IntPtr obj );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean cuda_MOG2_GPU_bShadowDetection_get_excsafe(ref System.Int32 ret,  System.IntPtr obj );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean cuda_MOG2_GPU_bShadowDetection_set_excsafe( System.IntPtr obj ,  System.Int32 value );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean cuda_MOG2_GPU_nShadowDetection_excsafe(ref IntPtr ret,  System.IntPtr obj );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean cuda_MOG2_GPU_fTau_excsafe(ref IntPtr ret,  System.IntPtr obj );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean cuda_StereoBM_GPU_new1_excsafe(ref System.IntPtr ret);

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean cuda_StereoBM_GPU_new2_excsafe(ref System.IntPtr ret,  System.Int32 preset ,  System.Int32 ndisparities ,  System.Int32 winSize );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean cuda_StereoBM_GPU_delete_excsafe( System.IntPtr obj );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean cuda_StereoBM_GPU_run1_excsafe( System.IntPtr obj ,  System.IntPtr left ,  System.IntPtr right ,  System.IntPtr disparity );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean cuda_StereoBM_GPU_run2_excsafe( System.IntPtr obj ,  System.IntPtr left ,  System.IntPtr right ,  System.IntPtr disparity ,  System.IntPtr stream );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean cuda_StereoBM_GPU_checkIfGpuCallReasonable_excsafe(ref System.Int32 ret);

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean cuda_StereoBM_GPU_preset_excsafe(ref IntPtr ret,  System.IntPtr obj );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean cuda_StereoBM_GPU_ndisp_excsafe(ref IntPtr ret,  System.IntPtr obj );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean cuda_StereoBM_GPU_winSize_excsafe(ref IntPtr ret,  System.IntPtr obj );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean cuda_StereoBM_GPU_avergeTexThreshold_excsafe(ref IntPtr ret,  System.IntPtr obj );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean cuda_GpuMat_delete_excsafe( System.IntPtr obj );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean cuda_GpuMat_new1_excsafe(ref System.IntPtr ret);

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean cuda_GpuMat_new2_excsafe(ref System.IntPtr ret,  System.Int32 rows ,  System.Int32 cols ,  System.Int32 type );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean cuda_GpuMat_new3_excsafe(ref System.IntPtr ret,  System.Int32 rows ,  System.Int32 cols ,  System.Int32 type ,  System.IntPtr data ,  System.UInt64 step );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean cuda_GpuMat_new4_excsafe(ref System.IntPtr ret,  System.IntPtr mat );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean cuda_GpuMat_new5_excsafe(ref System.IntPtr ret,  System.IntPtr gpumat );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean HOGDescriptor_threshold_L2hys_get_excsafe(ref System.Double ret,  System.IntPtr obj );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean HOGDescriptor_nlevels_get_excsafe(ref System.Int32 ret,  System.IntPtr obj );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean HOGDescriptor_gamma_correction_get_excsafe(ref System.Int32 ret,  System.IntPtr obj );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean HOGDescriptor_win_size_set_excsafe( System.IntPtr obj ,  OpenCvSharp.Size value );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean HOGDescriptor_block_size_set_excsafe( System.IntPtr obj ,  OpenCvSharp.Size value );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean HOGDescriptor_block_stride_set_excsafe( System.IntPtr obj ,  OpenCvSharp.Size value );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean HOGDescriptor_cell_size_set_excsafe( System.IntPtr obj ,  OpenCvSharp.Size value );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean HOGDescriptor_nbins_set_excsafe( System.IntPtr obj ,  System.Int32 value );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean HOGDescriptor_win_sigma_set_excsafe( System.IntPtr obj ,  System.Double value );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean HOGDescriptor_threshold_L2hys_set_excsafe( System.IntPtr obj ,  System.Double value );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean HOGDescriptor_nlevels_set_excsafe( System.IntPtr obj ,  System.Int32 value );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean HOGDescriptor_gamma_correction_set_excsafe( System.IntPtr obj ,  System.Int32 value );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean cuda_MOG_GPU_delete_excsafe( System.IntPtr obj );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean cuda_MOG_GPU_new_excsafe(ref System.IntPtr ret,  System.Int32 nmixtures );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean cuda_MOG_GPU_initialize_excsafe( System.IntPtr obj ,  OpenCvSharp.Size frameSize ,  System.Int32 frameType );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean cuda_MOG_GPU_operator_excsafe( System.IntPtr obj ,  System.IntPtr frame ,  System.IntPtr fgmask ,  System.Single learningRate ,  System.IntPtr stream );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean cuda_MOG_GPU_getBackgroundImage_excsafe( System.IntPtr obj ,  System.IntPtr backgroundImage ,  System.IntPtr stream );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean cuda_MOG_GPU_release_excsafe( System.IntPtr obj );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean cuda_MOG_GPU_history_excsafe(ref IntPtr ret,  System.IntPtr obj );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean cuda_MOG_GPU_varThreshold_excsafe(ref IntPtr ret,  System.IntPtr obj );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean cuda_MOG_GPU_backgroundRatio_excsafe(ref IntPtr ret,  System.IntPtr obj );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean cuda_MOG_GPU_noiseSigma_excsafe(ref IntPtr ret,  System.IntPtr obj );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean cuda_MOG2_GPU_delete_excsafe( System.IntPtr obj );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean cuda_MOG2_GPU_new_excsafe(ref System.IntPtr ret,  System.Int32 nmixtures );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean cuda_MOG2_GPU_initialize_excsafe( System.IntPtr obj ,  OpenCvSharp.Size frameSize ,  System.Int32 frameType );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean cuda_MOG2_GPU_operator_excsafe( System.IntPtr obj ,  System.IntPtr frame ,  System.IntPtr fgmask ,  System.Single learningRate ,  System.IntPtr stream );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean cuda_MOG2_GPU_getBackgroundImage_excsafe( System.IntPtr obj ,  System.IntPtr backgroundImage ,  System.IntPtr stream );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean cuda_MOG2_GPU_release_excsafe( System.IntPtr obj );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean cuda_CascadeClassifier_GPU_new2_excsafe(ref System.IntPtr ret,  System.String filename );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean cuda_CascadeClassifier_GPU_empty_excsafe(ref System.Int32 ret,  System.IntPtr obj );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean cuda_CascadeClassifier_GPU_load_excsafe(ref System.Int32 ret,  System.IntPtr obj ,  System.String filename );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean cuda_CascadeClassifier_GPU_release_excsafe( System.IntPtr obj );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean cuda_CascadeClassifier_GPU_detectMultiScale1_excsafe(ref System.Int32 ret,  System.IntPtr obj ,  System.IntPtr image ,  System.IntPtr objectsBuf ,  System.Double scaleFactor ,  System.Int32 minNeighbors ,  OpenCvSharp.Size minSize );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean cuda_CascadeClassifier_GPU_detectMultiScale2_excsafe(ref System.Int32 ret,  System.IntPtr obj ,  System.IntPtr image ,  System.IntPtr objectsBuf ,  OpenCvSharp.Size maxObjectSize ,  OpenCvSharp.Size minSize ,  System.Double scaleFactor ,  System.Int32 minNeighbors );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean cuda_CascadeClassifier_GPU_findLargestObject_get_excsafe(ref System.Int32 ret,  System.IntPtr obj );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean cuda_CascadeClassifier_GPU_findLargestObject_set_excsafe( System.IntPtr obj ,  System.Int32 value );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean cuda_CascadeClassifier_GPU_visualizeInPlace_get_excsafe(ref System.Int32 ret,  System.IntPtr obj );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean cuda_CascadeClassifier_GPU_visualizeInPlace_set_excsafe( System.IntPtr obj ,  System.Int32 value );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean cuda_CascadeClassifier_GPU_getClassifierSize_excsafe(ref OpenCvSharp.Size ret,  System.IntPtr obj );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean HOGDescriptor_sizeof_excsafe(ref System.Int32 ret);

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean HOGDescriptor_new_excsafe(ref System.IntPtr ret,  OpenCvSharp.Size win_size ,  OpenCvSharp.Size block_size ,  OpenCvSharp.Size block_stride ,  OpenCvSharp.Size cell_size ,  System.Int32 nbins ,  System.Double winSigma ,  System.Double threshold_L2Hys ,  System.Boolean gamma_correction ,  System.Int32 nlevels );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean HOGDescriptor_delete_excsafe( System.IntPtr obj );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean HOGDescriptor_getDescriptorSize_excsafe(ref System.UInt64 ret,  System.IntPtr obj );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean HOGDescriptor_getBlockHistogramSize_excsafe(ref System.UInt64 ret,  System.IntPtr obj );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean HOGDescriptor_checkDetectorSize_excsafe(ref System.Int32 ret,  System.IntPtr obj );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean HOGDescriptor_getWinSigma_excsafe(ref System.Double ret,  System.IntPtr obj );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean HOGDescriptor_setSVMDetector_excsafe( System.IntPtr obj ,  System.IntPtr svmdetector );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean HOGDescriptor_detect_excsafe( System.IntPtr obj ,  System.IntPtr img ,  System.IntPtr found_locations ,  System.Double hit_threshold ,  OpenCvSharp.Size win_stride ,  OpenCvSharp.Size padding );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean HOGDescriptor_detectMultiScale_excsafe( System.IntPtr obj ,  System.IntPtr img ,  System.IntPtr found_locations ,  System.Double hit_threshold ,  OpenCvSharp.Size win_stride ,  OpenCvSharp.Size padding ,  System.Double scale ,  System.Int32 group_threshold );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean HOGDescriptor_getDescriptors_excsafe( System.IntPtr obj ,  System.IntPtr img ,  OpenCvSharp.Size win_stride ,  System.IntPtr descriptors , [MarshalAs(UnmanagedType.I4)] OpenCvSharp.Cuda.DescriptorFormat descr_format );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean HOGDescriptor_win_size_get_excsafe(ref OpenCvSharp.Size ret,  System.IntPtr obj );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean HOGDescriptor_block_size_get_excsafe(ref OpenCvSharp.Size ret,  System.IntPtr obj );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean HOGDescriptor_block_stride_get_excsafe(ref OpenCvSharp.Size ret,  System.IntPtr obj );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean HOGDescriptor_cell_size_get_excsafe(ref OpenCvSharp.Size ret,  System.IntPtr obj );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean HOGDescriptor_nbins_get_excsafe(ref System.Int32 ret,  System.IntPtr obj );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean HOGDescriptor_win_sigma_get_excsafe(ref System.Double ret,  System.IntPtr obj );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean cuda_DeviceInfo_totalMemory_excsafe(ref System.UInt64 ret,  System.IntPtr obj );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean cuda_DeviceInfo_supports_excsafe(ref System.Int32 ret,  System.IntPtr obj ,  System.Int32 featureSet );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean cuda_DeviceInfo_isCompatible_excsafe(ref System.Int32 ret,  System.IntPtr obj );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean cuda_DeviceInfo_deviceID_excsafe(ref System.Int32 ret,  System.IntPtr obj );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean cuda_DeviceInfo_canMapHostMemory_excsafe(ref System.Int32 ret,  System.IntPtr obj );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean cuda_printCudaDeviceInfo_excsafe( System.Int32 device );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean cuda_printShortCudaDeviceInfo_excsafe( System.Int32 device );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean cuda_registerPageLocked_excsafe( System.IntPtr m );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean cuda_unregisterPageLocked_excsafe( System.IntPtr m );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean cuda_Stream_new1_excsafe(ref System.IntPtr ret);

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean cuda_Stream_new2_excsafe(ref System.IntPtr ret,  System.IntPtr s );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean cuda_Stream_delete_excsafe( System.IntPtr obj );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean cuda_Stream_opAssign_excsafe( System.IntPtr left ,  System.IntPtr right );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean cuda_Stream_queryIfComplete_excsafe(ref System.Int32 ret,  System.IntPtr obj );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean cuda_Stream_waitForCompletion_excsafe( System.IntPtr obj );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean cuda_Stream_enqueueDownload_CudaMem_excsafe( System.IntPtr obj ,  System.IntPtr src ,  System.IntPtr dst );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean cuda_Stream_enqueueDownload_Mat_excsafe( System.IntPtr obj ,  System.IntPtr src ,  System.IntPtr dst );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean cuda_Stream_enqueueUpload_CudaMem_excsafe( System.IntPtr obj ,  System.IntPtr src ,  System.IntPtr dst );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean cuda_Stream_enqueueUpload_Mat_excsafe( System.IntPtr obj ,  System.IntPtr src ,  System.IntPtr dst );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean cuda_Stream_enqueueCopy_excsafe( System.IntPtr obj ,  System.IntPtr src ,  System.IntPtr dst );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean cuda_Stream_enqueueMemSet_excsafe( System.IntPtr obj ,  System.IntPtr src ,  OpenCvSharp.Scalar val );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean cuda_Stream_enqueueMemSet_WithMask_excsafe( System.IntPtr obj ,  System.IntPtr src ,  OpenCvSharp.Scalar val ,  System.IntPtr mask );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean cuda_Stream_enqueueConvert_excsafe( System.IntPtr obj ,  System.IntPtr src ,  System.IntPtr dst ,  System.Int32 dtype ,  System.Double a ,  System.Double b );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean cuda_Stream_enqueueHostCallback_excsafe( System.IntPtr obj ,  System.IntPtr callback ,  System.IntPtr userData );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean cuda_Stream_Null_excsafe(ref System.IntPtr ret);

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean cuda_Stream_bool_excsafe(ref System.Int32 ret,  System.IntPtr obj );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean cuda_CascadeClassifier_GPU_delete_excsafe( System.IntPtr obj );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean cuda_CascadeClassifier_GPU_new1_excsafe(ref System.IntPtr ret);

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_SparseMat_ptr_2d_excsafe(ref System.IntPtr ret,  System.IntPtr obj ,  System.Int32 i0 ,  System.Int32 i1 ,  System.Int32 createMissing ,  System.IntPtr hashval );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_SparseMat_ptr_3d_excsafe(ref System.IntPtr ret,  System.IntPtr obj ,  System.Int32 i0 ,  System.Int32 i1 ,  System.Int32 i2 ,  System.Int32 createMissing ,  ref System.UInt64 hashval );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_SparseMat_ptr_3d_excsafe(ref System.IntPtr ret,  System.IntPtr obj ,  System.Int32 i0 ,  System.Int32 i1 ,  System.Int32 i2 ,  System.Int32 createMissing ,  System.IntPtr hashval );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_SparseMat_ptr_nd_excsafe(ref System.IntPtr ret,  System.IntPtr obj ,  System.Int32[] idx ,  System.Int32 createMissing ,  ref System.UInt64 hashval );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_SparseMat_ptr_nd_excsafe(ref System.IntPtr ret,  System.IntPtr obj ,  System.Int32[] idx ,  System.Int32 createMissing ,  System.IntPtr hashval );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean cuda_getCudaEnabledDeviceCount_excsafe(ref System.Int32 ret);

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean cuda_setDevice_excsafe( System.Int32 device );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean cuda_getDevice_excsafe(ref System.Int32 ret);

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean cuda_resetDevice_excsafe();

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean cuda_deviceSupports_excsafe(ref System.Int32 ret,  System.Int32 feature_set );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean cuda_TargetArchs_builtWith_excsafe(ref System.Int32 ret,  System.Int32 feature_set );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean cuda_TargetArchs_has_excsafe(ref System.Int32 ret,  System.Int32 major ,  System.Int32 minor );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean cuda_TargetArchs_hasPtx_excsafe(ref System.Int32 ret,  System.Int32 major ,  System.Int32 minor );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean cuda_TargetArchs_hasBin_excsafe(ref System.Int32 ret,  System.Int32 major ,  System.Int32 minor );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean cuda_TargetArchs_hasEqualOrLessPtx_excsafe(ref System.Int32 ret,  System.Int32 major ,  System.Int32 minor );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean cuda_TargetArchs_hasEqualOrGreater_excsafe(ref System.Int32 ret,  System.Int32 major ,  System.Int32 minor );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean cuda_TargetArchs_hasEqualOrGreaterPtx_excsafe(ref System.Int32 ret,  System.Int32 major ,  System.Int32 minor );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean cuda_TargetArchs_hasEqualOrGreaterBin_excsafe(ref System.Int32 ret,  System.Int32 major ,  System.Int32 minor );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean cuda_DeviceInfo_new1_excsafe(ref System.IntPtr ret);

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean cuda_DeviceInfo_new2_excsafe(ref System.IntPtr ret,  System.Int32 deviceId );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean cuda_DeviceInfo_delete_excsafe( System.IntPtr obj );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean cuda_DeviceInfo_name_excsafe( System.IntPtr obj , [MarshalAs(UnmanagedType.LPStr)] System.Text.StringBuilder buf ,  System.Int32 bufLength );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean cuda_DeviceInfo_majorVersion_excsafe(ref System.Int32 ret,  System.IntPtr obj );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean cuda_DeviceInfo_minorVersion_excsafe(ref System.Int32 ret,  System.IntPtr obj );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean cuda_DeviceInfo_multiProcessorCount_excsafe(ref System.Int32 ret,  System.IntPtr obj );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean cuda_DeviceInfo_sharedMemPerBlock_excsafe(ref System.UInt64 ret,  System.IntPtr obj );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean cuda_DeviceInfo_queryMemory_excsafe( System.IntPtr obj ,  out System.UInt64 totalMemory ,  out System.UInt64 freeMemory );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean cuda_DeviceInfo_freeMemory_excsafe(ref System.UInt64 ret,  System.IntPtr obj );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_SparseMat_operatorAssign_SparseMat_excsafe( System.IntPtr obj ,  System.IntPtr m );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_SparseMat_operatorAssign_Mat_excsafe( System.IntPtr obj ,  System.IntPtr m );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_SparseMat_clone_excsafe(ref System.IntPtr ret,  System.IntPtr obj );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_SparseMat_copyTo_SparseMat_excsafe( System.IntPtr obj ,  System.IntPtr m );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_SparseMat_copyTo_Mat_excsafe( System.IntPtr obj ,  System.IntPtr m );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_SparseMat_convertTo_SparseMat_excsafe( System.IntPtr obj ,  System.IntPtr m ,  System.Int32 rtype ,  System.Double alpha );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_SparseMat_convertTo_Mat_excsafe( System.IntPtr obj ,  System.IntPtr m ,  System.Int32 rtype ,  System.Double alpha ,  System.Double beta );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_SparseMat_assignTo_excsafe( System.IntPtr obj ,  System.IntPtr m ,  System.Int32 type );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_SparseMat_create_excsafe( System.IntPtr obj ,  System.Int32 dims ,  System.Int32[] sizes ,  System.Int32 type );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_SparseMat_clear_excsafe( System.IntPtr obj );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_SparseMat_addref_excsafe( System.IntPtr obj );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_SparseMat_release_excsafe( System.IntPtr obj );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_SparseMat_elemSize_excsafe(ref System.Int32 ret,  System.IntPtr obj );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_SparseMat_elemSize1_excsafe(ref System.Int32 ret,  System.IntPtr obj );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_SparseMat_type_excsafe(ref System.Int32 ret,  System.IntPtr obj );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_SparseMat_depth_excsafe(ref System.Int32 ret,  System.IntPtr obj );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_SparseMat_channels_excsafe(ref System.Int32 ret,  System.IntPtr obj );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_SparseMat_size1_excsafe(ref System.IntPtr ret,  System.IntPtr obj );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_SparseMat_size2_excsafe(ref System.Int32 ret,  System.IntPtr obj ,  System.Int32 i );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_SparseMat_dims_excsafe(ref System.Int32 ret,  System.IntPtr obj );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_SparseMat_nzcount_excsafe(ref System.IntPtr ret,  System.IntPtr obj );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_SparseMat_hash_1d_excsafe(ref System.IntPtr ret,  System.IntPtr obj ,  System.Int32 i0 );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_SparseMat_hash_2d_excsafe(ref System.IntPtr ret,  System.IntPtr obj ,  System.Int32 i0 ,  System.Int32 i1 );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_SparseMat_hash_3d_excsafe(ref System.IntPtr ret,  System.IntPtr obj ,  System.Int32 i0 ,  System.Int32 i1 ,  System.Int32 i2 );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_SparseMat_hash_nd_excsafe(ref System.IntPtr ret,  System.IntPtr obj ,  System.Int32[] idx );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_SparseMat_ptr_1d_excsafe(ref System.IntPtr ret,  System.IntPtr obj ,  System.Int32 i0 ,  System.Int32 createMissing ,  ref System.UInt64 hashval );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_SparseMat_ptr_1d_excsafe(ref System.IntPtr ret,  System.IntPtr obj ,  System.Int32 i0 ,  System.Int32 createMissing ,  System.IntPtr hashval );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_SparseMat_ptr_2d_excsafe(ref System.IntPtr ret,  System.IntPtr obj ,  System.Int32 i0 ,  System.Int32 i1 ,  System.Int32 createMissing ,  ref System.UInt64 hashval );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_MatExpr_row_excsafe(ref System.IntPtr ret,  System.IntPtr self ,  System.Int32 y );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_MatExpr_col_excsafe(ref System.IntPtr ret,  System.IntPtr self ,  System.Int32 x );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_MatExpr_diag1_excsafe(ref System.IntPtr ret,  System.IntPtr self );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_MatExpr_diag2_excsafe(ref System.IntPtr ret,  System.IntPtr self ,  System.Int32 d );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_MatExpr_submat_excsafe(ref System.IntPtr ret,  System.IntPtr self ,  System.Int32 rowStart ,  System.Int32 rowEnd ,  System.Int32 colStart ,  System.Int32 colEnd );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_MatExpr_cross_excsafe(ref System.IntPtr ret,  System.IntPtr self ,  System.IntPtr m );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_MatExpr_dot_excsafe(ref System.Double ret,  System.IntPtr self ,  System.IntPtr m );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_MatExpr_t_excsafe(ref System.IntPtr ret,  System.IntPtr self );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_MatExpr_inv1_excsafe(ref System.IntPtr ret,  System.IntPtr self );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_MatExpr_inv2_excsafe(ref System.IntPtr ret,  System.IntPtr self ,  System.Int32 method );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_MatExpr_mul_toMatExpr_excsafe(ref System.IntPtr ret,  System.IntPtr self ,  System.IntPtr e ,  System.Double scale );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_MatExpr_mul_toMat_excsafe(ref System.IntPtr ret,  System.IntPtr self ,  System.IntPtr m ,  System.Double scale );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_MatExpr_size_excsafe(ref OpenCvSharp.Size ret,  System.IntPtr self );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_MatExpr_type_excsafe(ref System.Int32 ret,  System.IntPtr self );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_abs_MatExpr_excsafe(ref System.IntPtr ret,  System.IntPtr e );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_OutputArray_new_byMat_excsafe(ref System.IntPtr ret,  System.IntPtr mat );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_OutputArray_new_byGpuMat_excsafe(ref System.IntPtr ret,  System.IntPtr mat );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_OutputArray_new_byScalar_excsafe(ref System.IntPtr ret,  OpenCvSharp.Scalar val );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_OutputArray_new_byVectorOfMat_excsafe(ref System.IntPtr ret,  System.IntPtr vector );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_OutputArray_delete_excsafe( System.IntPtr oa );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_OutputArray_getMat_excsafe(ref System.IntPtr ret,  System.IntPtr oa );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_OutputArray_getScalar_excsafe(ref OpenCvSharp.Scalar ret,  System.IntPtr oa );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_OutputArray_getVectorOfMat_excsafe( System.IntPtr oa ,  System.IntPtr vector );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_SparseMat_sizeof_excsafe(ref System.UInt64 ret);

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_SparseMat_new1_excsafe(ref System.IntPtr ret);

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_SparseMat_new2_excsafe(ref System.IntPtr ret,  System.Int32 dims ,  System.Int32[] sizes ,  System.Int32 type );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_SparseMat_new3_excsafe(ref System.IntPtr ret,  System.IntPtr m );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_SparseMat_delete_excsafe( System.IntPtr obj );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_Mat_forEach_Vec4d_excsafe( System.IntPtr m ,  OpenCvSharp.MatForeachFunctionVec4d proc );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_Mat_forEach_Vec6d_excsafe( System.IntPtr m ,  OpenCvSharp.MatForeachFunctionVec6d proc );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_MatExpr_new1_excsafe(ref System.IntPtr ret);

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_MatExpr_new2_excsafe(ref System.IntPtr ret,  System.IntPtr mat );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_MatExpr_delete_excsafe( System.IntPtr expr );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_MatExpr_toMat_excsafe(ref System.IntPtr ret,  System.IntPtr expr );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_operatorUnaryMinus_MatExpr_excsafe(ref System.IntPtr ret,  System.IntPtr e );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_operatorUnaryNot_MatExpr_excsafe(ref System.IntPtr ret,  System.IntPtr e );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_operatorAdd_MatExprMat_excsafe(ref System.IntPtr ret,  System.IntPtr e ,  System.IntPtr m );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_operatorAdd_MatMatExpr_excsafe(ref System.IntPtr ret,  System.IntPtr m ,  System.IntPtr e );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_operatorAdd_MatExprScalar_excsafe(ref System.IntPtr ret,  System.IntPtr e ,  OpenCvSharp.Scalar s );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_operatorAdd_ScalarMatExpr_excsafe(ref System.IntPtr ret,  OpenCvSharp.Scalar s ,  System.IntPtr e );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_operatorAdd_MatExprMatExpr_excsafe(ref System.IntPtr ret,  System.IntPtr e1 ,  System.IntPtr e2 );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_operatorSubtract_MatExprMat_excsafe(ref System.IntPtr ret,  System.IntPtr e ,  System.IntPtr m );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_operatorSubtract_MatMatExpr_excsafe(ref System.IntPtr ret,  System.IntPtr m ,  System.IntPtr e );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_operatorSubtract_MatExprScalar_excsafe(ref System.IntPtr ret,  System.IntPtr e ,  OpenCvSharp.Scalar s );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_operatorSubtract_ScalarMatExpr_excsafe(ref System.IntPtr ret,  OpenCvSharp.Scalar s ,  System.IntPtr e );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_operatorSubtract_MatExprMatExpr_excsafe(ref System.IntPtr ret,  System.IntPtr e1 ,  System.IntPtr e2 );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_operatorMultiply_MatExprMat_excsafe(ref System.IntPtr ret,  System.IntPtr e ,  System.IntPtr m );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_operatorMultiply_MatMatExpr_excsafe(ref System.IntPtr ret,  System.IntPtr m ,  System.IntPtr e );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_operatorMultiply_MatExprDouble_excsafe(ref System.IntPtr ret,  System.IntPtr e ,  System.Double s );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_operatorMultiply_DoubleMatExpr_excsafe(ref System.IntPtr ret,  System.Double s ,  System.IntPtr e );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_operatorMultiply_MatExprMatExpr_excsafe(ref System.IntPtr ret,  System.IntPtr e1 ,  System.IntPtr e2 );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_operatorDivide_MatExprMat_excsafe(ref System.IntPtr ret,  System.IntPtr e ,  System.IntPtr m );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_operatorDivide_MatMatExpr_excsafe(ref System.IntPtr ret,  System.IntPtr m ,  System.IntPtr e );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_operatorDivide_MatExprDouble_excsafe(ref System.IntPtr ret,  System.IntPtr e ,  System.Double s );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_operatorDivide_DoubleMatExpr_excsafe(ref System.IntPtr ret,  System.Double s ,  System.IntPtr e );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_operatorDivide_MatExprMatExpr_excsafe(ref System.IntPtr ret,  System.IntPtr e1 ,  System.IntPtr e2 );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_Mat_push_back_Rect_excsafe( System.IntPtr self ,  OpenCvSharp.Rect v );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_Mat_reserve_excsafe( System.IntPtr obj ,  System.IntPtr sz );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_Mat_resize1_excsafe( System.IntPtr obj ,  System.IntPtr sz );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_Mat_resize2_excsafe( System.IntPtr obj ,  System.IntPtr sz ,  OpenCvSharp.Scalar s );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_Mat_pop_back_excsafe( System.IntPtr obj ,  System.IntPtr nelems );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_Mat_forEach_uchar_excsafe( System.IntPtr m ,  OpenCvSharp.MatForeachFunctionByte proc );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_Mat_forEach_Vec2b_excsafe( System.IntPtr m ,  OpenCvSharp.MatForeachFunctionVec2b proc );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_Mat_forEach_Vec3b_excsafe( System.IntPtr m ,  OpenCvSharp.MatForeachFunctionVec3b proc );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_Mat_forEach_Vec4b_excsafe( System.IntPtr m ,  OpenCvSharp.MatForeachFunctionVec4b proc );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_Mat_forEach_Vec6b_excsafe( System.IntPtr m ,  OpenCvSharp.MatForeachFunctionVec6b proc );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_Mat_forEach_short_excsafe( System.IntPtr m ,  OpenCvSharp.MatForeachFunctionInt16 proc );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_Mat_forEach_Vec2s_excsafe( System.IntPtr m ,  OpenCvSharp.MatForeachFunctionVec2s proc );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_Mat_forEach_Vec3s_excsafe( System.IntPtr m ,  OpenCvSharp.MatForeachFunctionVec3s proc );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_Mat_forEach_Vec4s_excsafe( System.IntPtr m ,  OpenCvSharp.MatForeachFunctionVec4s proc );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_Mat_forEach_Vec6s_excsafe( System.IntPtr m ,  OpenCvSharp.MatForeachFunctionVec6s proc );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_Mat_forEach_int_excsafe( System.IntPtr m ,  OpenCvSharp.MatForeachFunctionInt32 proc );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_Mat_forEach_Vec2i_excsafe( System.IntPtr m ,  OpenCvSharp.MatForeachFunctionVec2i proc );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_Mat_forEach_Vec3i_excsafe( System.IntPtr m ,  OpenCvSharp.MatForeachFunctionVec3i proc );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_Mat_forEach_Vec4i_excsafe( System.IntPtr m ,  OpenCvSharp.MatForeachFunctionVec4i proc );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_Mat_forEach_Vec6i_excsafe( System.IntPtr m ,  OpenCvSharp.MatForeachFunctionVec6i proc );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_Mat_forEach_float_excsafe( System.IntPtr m ,  OpenCvSharp.MatForeachFunctionFloat proc );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_Mat_forEach_Vec2f_excsafe( System.IntPtr m ,  OpenCvSharp.MatForeachFunctionVec2f proc );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_Mat_forEach_Vec3f_excsafe( System.IntPtr m ,  OpenCvSharp.MatForeachFunctionVec3f proc );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_Mat_forEach_Vec4f_excsafe( System.IntPtr m ,  OpenCvSharp.MatForeachFunctionVec4f proc );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_Mat_forEach_Vec6f_excsafe( System.IntPtr m ,  OpenCvSharp.MatForeachFunctionVec6f proc );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_Mat_forEach_double_excsafe( System.IntPtr m ,  OpenCvSharp.MatForeachFunctionDouble proc );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_Mat_forEach_Vec2d_excsafe( System.IntPtr m ,  OpenCvSharp.MatForeachFunctionVec2d proc );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_Mat_forEach_Vec3d_excsafe( System.IntPtr m ,  OpenCvSharp.MatForeachFunctionVec3d proc );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_Mat_push_back_Vec6b_excsafe( System.IntPtr self ,  OpenCvSharp.Vec6b v );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_Mat_push_back_Vec2s_excsafe( System.IntPtr self ,  OpenCvSharp.Vec2s v );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_Mat_push_back_Vec3s_excsafe( System.IntPtr self ,  OpenCvSharp.Vec3s v );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_Mat_push_back_Vec4s_excsafe( System.IntPtr self ,  OpenCvSharp.Vec4s v );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_Mat_push_back_Vec6s_excsafe( System.IntPtr self ,  OpenCvSharp.Vec6s v );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_Mat_push_back_Vec2w_excsafe( System.IntPtr self ,  OpenCvSharp.Vec2w v );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_Mat_push_back_Vec3w_excsafe( System.IntPtr self ,  OpenCvSharp.Vec3w v );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_Mat_push_back_Vec4w_excsafe( System.IntPtr self ,  OpenCvSharp.Vec4w v );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_Mat_push_back_Vec6w_excsafe( System.IntPtr self ,  OpenCvSharp.Vec6w v );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_Mat_push_back_Vec2i_excsafe( System.IntPtr self ,  OpenCvSharp.Vec2i v );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_Mat_push_back_Vec3i_excsafe( System.IntPtr self ,  OpenCvSharp.Vec3i v );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_Mat_push_back_Vec4i_excsafe( System.IntPtr self ,  OpenCvSharp.Vec4i v );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_Mat_push_back_Vec6i_excsafe( System.IntPtr self ,  OpenCvSharp.Vec6i v );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_Mat_push_back_Vec2f_excsafe( System.IntPtr self ,  OpenCvSharp.Vec2f v );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_Mat_push_back_Vec3f_excsafe( System.IntPtr self ,  OpenCvSharp.Vec3f v );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_Mat_push_back_Vec4f_excsafe( System.IntPtr self ,  OpenCvSharp.Vec4f v );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_Mat_push_back_Vec6f_excsafe( System.IntPtr self ,  OpenCvSharp.Vec6f v );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_Mat_push_back_Vec2d_excsafe( System.IntPtr self ,  OpenCvSharp.Vec2d v );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_Mat_push_back_Vec3d_excsafe( System.IntPtr self ,  OpenCvSharp.Vec3d v );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_Mat_push_back_Vec6d_excsafe( System.IntPtr self ,  OpenCvSharp.Vec6d v );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_Mat_push_back_Point_excsafe( System.IntPtr self ,  OpenCvSharp.Point v );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_Mat_push_back_Point2f_excsafe( System.IntPtr self ,  OpenCvSharp.Point2f v );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_Mat_push_back_Point2d_excsafe( System.IntPtr self ,  OpenCvSharp.Point2d v );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_Mat_push_back_Point3i_excsafe( System.IntPtr self ,  OpenCvSharp.Point3i v );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_Mat_push_back_Point3f_excsafe( System.IntPtr self ,  OpenCvSharp.Point3f v );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_Mat_push_back_Point3d_excsafe( System.IntPtr self ,  OpenCvSharp.Point3d v );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_Mat_push_back_Size_excsafe( System.IntPtr self ,  OpenCvSharp.Size v );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_Mat_push_back_Size2f_excsafe( System.IntPtr self ,  OpenCvSharp.Size2f v );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern unsafe System.Boolean core_Mat_nGetS_excsafe(ref System.Int32 ret,  System.IntPtr obj ,  System.Int32 row ,  System.Int32 col ,  System.Int16* vals ,  System.Int32 valsLength );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern unsafe System.Boolean core_Mat_nGetS_excsafe(ref System.Int32 ret,  System.IntPtr obj ,  System.Int32 row ,  System.Int32 col ,  System.UInt16* vals ,  System.Int32 valsLength );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern unsafe System.Boolean core_Mat_nGetI_excsafe(ref System.Int32 ret,  System.IntPtr obj ,  System.Int32 row ,  System.Int32 col ,  System.Int32* vals ,  System.Int32 valsLength );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern unsafe System.Boolean core_Mat_nGetF_excsafe(ref System.Int32 ret,  System.IntPtr obj ,  System.Int32 row ,  System.Int32 col ,  System.Single* vals ,  System.Int32 valsLength );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern unsafe System.Boolean core_Mat_nGetD_excsafe(ref System.Int32 ret,  System.IntPtr obj ,  System.Int32 row ,  System.Int32 col ,  System.Double* vals ,  System.Int32 valsLength );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern unsafe System.Boolean core_Mat_nGetVec3b_excsafe(ref System.Int32 ret,  System.IntPtr obj ,  System.Int32 row ,  System.Int32 col ,  OpenCvSharp.Vec3b* vals ,  System.Int32 valsLength );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern unsafe System.Boolean core_Mat_nGetVec3d_excsafe(ref System.Int32 ret,  System.IntPtr obj ,  System.Int32 row ,  System.Int32 col ,  OpenCvSharp.Vec3d* vals ,  System.Int32 valsLength );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern unsafe System.Boolean core_Mat_nGetVec4f_excsafe(ref System.Int32 ret,  System.IntPtr obj ,  System.Int32 row ,  System.Int32 col ,  OpenCvSharp.Vec4f* vals ,  System.Int32 valsLength );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern unsafe System.Boolean core_Mat_nGetVec6f_excsafe(ref System.Int32 ret,  System.IntPtr obj ,  System.Int32 row ,  System.Int32 col ,  OpenCvSharp.Vec6f* vals ,  System.Int32 valsLength );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern unsafe System.Boolean core_Mat_nGetVec4i_excsafe(ref System.Int32 ret,  System.IntPtr obj ,  System.Int32 row ,  System.Int32 col ,  OpenCvSharp.Vec4i* vals ,  System.Int32 valsLength );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern unsafe System.Boolean core_Mat_nGetPoint_excsafe(ref System.Int32 ret,  System.IntPtr obj ,  System.Int32 row ,  System.Int32 col ,  OpenCvSharp.Point* vals ,  System.Int32 valsLength );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern unsafe System.Boolean core_Mat_nGetPoint2f_excsafe(ref System.Int32 ret,  System.IntPtr obj ,  System.Int32 row ,  System.Int32 col ,  OpenCvSharp.Point2f* vals ,  System.Int32 valsLength );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern unsafe System.Boolean core_Mat_nGetPoint2d_excsafe(ref System.Int32 ret,  System.IntPtr obj ,  System.Int32 row ,  System.Int32 col ,  OpenCvSharp.Point2d* vals ,  System.Int32 valsLength );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern unsafe System.Boolean core_Mat_nGetPoint3i_excsafe(ref System.Int32 ret,  System.IntPtr obj ,  System.Int32 row ,  System.Int32 col ,  OpenCvSharp.Point3i* vals ,  System.Int32 valsLength );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern unsafe System.Boolean core_Mat_nGetPoint3f_excsafe(ref System.Int32 ret,  System.IntPtr obj ,  System.Int32 row ,  System.Int32 col ,  OpenCvSharp.Point3f* vals ,  System.Int32 valsLength );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern unsafe System.Boolean core_Mat_nGetPoint3d_excsafe(ref System.Int32 ret,  System.IntPtr obj ,  System.Int32 row ,  System.Int32 col ,  OpenCvSharp.Point3d* vals ,  System.Int32 valsLength );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern unsafe System.Boolean core_Mat_nGetRect_excsafe(ref System.Int32 ret,  System.IntPtr obj ,  System.Int32 row ,  System.Int32 col ,  OpenCvSharp.Rect* vals ,  System.Int32 valsLength );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_Mat_push_back_Mat_excsafe( System.IntPtr self ,  System.IntPtr m );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_Mat_push_back_char_excsafe( System.IntPtr self ,  System.SByte v );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_Mat_push_back_uchar_excsafe( System.IntPtr self ,  System.Byte v );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_Mat_push_back_short_excsafe( System.IntPtr self ,  System.Int16 v );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_Mat_push_back_ushort_excsafe( System.IntPtr self ,  System.UInt16 v );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_Mat_push_back_int_excsafe( System.IntPtr self ,  System.Int32 v );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_Mat_push_back_float_excsafe( System.IntPtr self ,  System.Single v );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_Mat_push_back_double_excsafe( System.IntPtr self ,  System.Double v );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_Mat_push_back_Vec2b_excsafe( System.IntPtr self ,  OpenCvSharp.Vec2b v );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_Mat_push_back_Vec3b_excsafe( System.IntPtr self ,  OpenCvSharp.Vec3b v );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_Mat_push_back_Vec4b_excsafe( System.IntPtr self ,  OpenCvSharp.Vec4b v );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_Mat_operatorGE_DoubleMat_excsafe(ref System.IntPtr ret,  System.Double a ,  System.IntPtr b );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_Mat_operatorGE_MatDouble_excsafe(ref System.IntPtr ret,  System.IntPtr a ,  System.Double b );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_Mat_operatorEQ_MatMat_excsafe(ref System.IntPtr ret,  System.IntPtr a ,  System.IntPtr b );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_Mat_operatorEQ_DoubleMat_excsafe(ref System.IntPtr ret,  System.Double a ,  System.IntPtr b );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_Mat_operatorEQ_MatDouble_excsafe(ref System.IntPtr ret,  System.IntPtr a ,  System.Double b );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_Mat_operatorNE_MatMat_excsafe(ref System.IntPtr ret,  System.IntPtr a ,  System.IntPtr b );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_Mat_operatorNE_DoubleMat_excsafe(ref System.IntPtr ret,  System.Double a ,  System.IntPtr b );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_Mat_operatorNE_MatDouble_excsafe(ref System.IntPtr ret,  System.IntPtr a ,  System.Double b );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_abs_Mat_excsafe(ref System.IntPtr ret,  System.IntPtr e );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern unsafe System.Boolean core_Mat_nSetB_excsafe(ref System.Int32 ret,  System.IntPtr obj ,  System.Int32 row ,  System.Int32 col ,  System.Byte* vals ,  System.Int32 valsLength );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern unsafe System.Boolean core_Mat_nSetS_excsafe(ref System.Int32 ret,  System.IntPtr obj ,  System.Int32 row ,  System.Int32 col ,  System.Int16* vals ,  System.Int32 valsLength );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern unsafe System.Boolean core_Mat_nSetS_excsafe(ref System.Int32 ret,  System.IntPtr obj ,  System.Int32 row ,  System.Int32 col ,  System.UInt16* vals ,  System.Int32 valsLength );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern unsafe System.Boolean core_Mat_nSetI_excsafe(ref System.Int32 ret,  System.IntPtr obj ,  System.Int32 row ,  System.Int32 col ,  System.Int32* vals ,  System.Int32 valsLength );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern unsafe System.Boolean core_Mat_nSetF_excsafe(ref System.Int32 ret,  System.IntPtr obj ,  System.Int32 row ,  System.Int32 col ,  System.Single* vals ,  System.Int32 valsLength );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern unsafe System.Boolean core_Mat_nSetD_excsafe(ref System.Int32 ret,  System.IntPtr obj ,  System.Int32 row ,  System.Int32 col ,  System.Double* vals ,  System.Int32 valsLength );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern unsafe System.Boolean core_Mat_nSetVec3b_excsafe(ref System.Int32 ret,  System.IntPtr obj ,  System.Int32 row ,  System.Int32 col ,  OpenCvSharp.Vec3b* vals ,  System.Int32 valsLength );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern unsafe System.Boolean core_Mat_nSetVec3d_excsafe(ref System.Int32 ret,  System.IntPtr obj ,  System.Int32 row ,  System.Int32 col ,  OpenCvSharp.Vec3d* vals ,  System.Int32 valsLength );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern unsafe System.Boolean core_Mat_nSetVec4f_excsafe(ref System.Int32 ret,  System.IntPtr obj ,  System.Int32 row ,  System.Int32 col ,  OpenCvSharp.Vec4f* vals ,  System.Int32 valsLength );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern unsafe System.Boolean core_Mat_nSetVec6f_excsafe(ref System.Int32 ret,  System.IntPtr obj ,  System.Int32 row ,  System.Int32 col ,  OpenCvSharp.Vec6f* vals ,  System.Int32 valsLength );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern unsafe System.Boolean core_Mat_nSetVec4i_excsafe(ref System.Int32 ret,  System.IntPtr obj ,  System.Int32 row ,  System.Int32 col ,  OpenCvSharp.Vec4i* vals ,  System.Int32 valsLength );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern unsafe System.Boolean core_Mat_nSetPoint_excsafe(ref System.Int32 ret,  System.IntPtr obj ,  System.Int32 row ,  System.Int32 col ,  OpenCvSharp.Point* vals ,  System.Int32 valsLength );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern unsafe System.Boolean core_Mat_nSetPoint2f_excsafe(ref System.Int32 ret,  System.IntPtr obj ,  System.Int32 row ,  System.Int32 col ,  OpenCvSharp.Point2f* vals ,  System.Int32 valsLength );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern unsafe System.Boolean core_Mat_nSetPoint2d_excsafe(ref System.Int32 ret,  System.IntPtr obj ,  System.Int32 row ,  System.Int32 col ,  OpenCvSharp.Point2d* vals ,  System.Int32 valsLength );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern unsafe System.Boolean core_Mat_nSetPoint3i_excsafe(ref System.Int32 ret,  System.IntPtr obj ,  System.Int32 row ,  System.Int32 col ,  OpenCvSharp.Point3i* vals ,  System.Int32 valsLength );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern unsafe System.Boolean core_Mat_nSetPoint3f_excsafe(ref System.Int32 ret,  System.IntPtr obj ,  System.Int32 row ,  System.Int32 col ,  OpenCvSharp.Point3f* vals ,  System.Int32 valsLength );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern unsafe System.Boolean core_Mat_nSetPoint3d_excsafe(ref System.Int32 ret,  System.IntPtr obj ,  System.Int32 row ,  System.Int32 col ,  OpenCvSharp.Point3d* vals ,  System.Int32 valsLength );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern unsafe System.Boolean core_Mat_nSetRect_excsafe(ref System.Int32 ret,  System.IntPtr obj ,  System.Int32 row ,  System.Int32 col ,  OpenCvSharp.Rect* vals ,  System.Int32 valsLength );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern unsafe System.Boolean core_Mat_nGetB_excsafe(ref System.Int32 ret,  System.IntPtr obj ,  System.Int32 row ,  System.Int32 col ,  System.Byte* vals ,  System.Int32 valsLength );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_Mat_operatorSubtract_MatScalar_excsafe(ref System.IntPtr ret,  System.IntPtr a ,  OpenCvSharp.Scalar s );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_Mat_operatorSubtract_ScalarMat_excsafe(ref System.IntPtr ret,  OpenCvSharp.Scalar s ,  System.IntPtr a );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_Mat_operatorMultiply_MatMat_excsafe(ref System.IntPtr ret,  System.IntPtr a ,  System.IntPtr b );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_Mat_operatorMultiply_MatDouble_excsafe(ref System.IntPtr ret,  System.IntPtr a ,  System.Double s );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_Mat_operatorMultiply_DoubleMat_excsafe(ref System.IntPtr ret,  System.Double s ,  System.IntPtr a );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_Mat_operatorDivide_MatMat_excsafe(ref System.IntPtr ret,  System.IntPtr a ,  System.IntPtr b );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_Mat_operatorDivide_MatDouble_excsafe(ref System.IntPtr ret,  System.IntPtr a ,  System.Double s );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_Mat_operatorDivide_DoubleMat_excsafe(ref System.IntPtr ret,  System.Double s ,  System.IntPtr a );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_Mat_operatorAnd_MatMat_excsafe(ref System.IntPtr ret,  System.IntPtr a ,  System.IntPtr b );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_Mat_operatorAnd_MatDouble_excsafe(ref System.IntPtr ret,  System.IntPtr a ,  System.Double s );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_Mat_operatorAnd_DoubleMat_excsafe(ref System.IntPtr ret,  System.Double s ,  System.IntPtr a );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_Mat_operatorOr_MatMat_excsafe(ref System.IntPtr ret,  System.IntPtr a ,  System.IntPtr b );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_Mat_operatorOr_MatDouble_excsafe(ref System.IntPtr ret,  System.IntPtr a ,  System.Double s );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_Mat_operatorOr_DoubleMat_excsafe(ref System.IntPtr ret,  System.Double s ,  System.IntPtr a );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_Mat_operatorXor_MatMat_excsafe(ref System.IntPtr ret,  System.IntPtr a ,  System.IntPtr b );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_Mat_operatorXor_MatDouble_excsafe(ref System.IntPtr ret,  System.IntPtr a ,  System.Double s );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_Mat_operatorXor_DoubleMat_excsafe(ref System.IntPtr ret,  System.Double s ,  System.IntPtr a );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_Mat_operatorNot_excsafe(ref System.IntPtr ret,  System.IntPtr a );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_Mat_operatorLT_MatMat_excsafe(ref System.IntPtr ret,  System.IntPtr a ,  System.IntPtr b );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_Mat_operatorLT_DoubleMat_excsafe(ref System.IntPtr ret,  System.Double a ,  System.IntPtr b );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_Mat_operatorLT_MatDouble_excsafe(ref System.IntPtr ret,  System.IntPtr a ,  System.Double b );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_Mat_operatorLE_MatMat_excsafe(ref System.IntPtr ret,  System.IntPtr a ,  System.IntPtr b );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_Mat_operatorLE_DoubleMat_excsafe(ref System.IntPtr ret,  System.Double a ,  System.IntPtr b );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_Mat_operatorLE_MatDouble_excsafe(ref System.IntPtr ret,  System.IntPtr a ,  System.Double b );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_Mat_operatorGT_MatMat_excsafe(ref System.IntPtr ret,  System.IntPtr a ,  System.IntPtr b );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_Mat_operatorGT_DoubleMat_excsafe(ref System.IntPtr ret,  System.Double a ,  System.IntPtr b );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_Mat_operatorGT_MatDouble_excsafe(ref System.IntPtr ret,  System.IntPtr a ,  System.Double b );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_Mat_operatorGE_MatMat_excsafe(ref System.IntPtr ret,  System.IntPtr a ,  System.IntPtr b );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_Mat_step12_excsafe(ref System.UInt64 ret,  System.IntPtr self ,  System.Int32 i );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_Mat_step_excsafe(ref System.Int64 ret,  System.IntPtr self );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_Mat_stepAt_excsafe(ref System.UInt64 ret,  System.IntPtr self ,  System.Int32 i );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_Mat_subMat1_excsafe(ref System.IntPtr ret,  System.IntPtr self ,  System.Int32 rowStart ,  System.Int32 rowEnd ,  System.Int32 colStart ,  System.Int32 colEnd );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_Mat_subMat2_excsafe(ref System.IntPtr ret,  System.IntPtr self ,  System.Int32 nRanges ,  OpenCvSharp.Range[] ranges );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_Mat_t_excsafe(ref System.IntPtr ret,  System.IntPtr self );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_Mat_total_excsafe(ref System.UInt64 ret,  System.IntPtr self );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_Mat_type_excsafe(ref System.Int32 ret,  System.IntPtr self );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_Mat_zeros1_excsafe(ref System.IntPtr ret,  System.Int32 rows ,  System.Int32 cols ,  System.Int32 type );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_Mat_zeros2_excsafe(ref System.IntPtr ret,  System.Int32 ndims , [MarshalAs(UnmanagedType.LPArray)] System.Int32[] sz ,  System.Int32 type );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_Mat_dump_excsafe(ref IntPtr ret,  System.IntPtr self , [MarshalAs(UnmanagedType.LPStr)] System.String format );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern unsafe System.Boolean core_Mat_dump_delete_excsafe( System.SByte* buf );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_Mat_ptr1d_excsafe(ref System.IntPtr ret,  System.IntPtr self ,  System.Int32 i0 );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_Mat_ptr2d_excsafe(ref System.IntPtr ret,  System.IntPtr self ,  System.Int32 i0 ,  System.Int32 i1 );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_Mat_ptr3d_excsafe(ref System.IntPtr ret,  System.IntPtr self ,  System.Int32 i0 ,  System.Int32 i1 ,  System.Int32 i2 );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_Mat_ptrnd_excsafe(ref System.IntPtr ret,  System.IntPtr self , [MarshalAs(UnmanagedType.LPArray)] System.Int32[] idx );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_Mat_assignment_FromMat_excsafe( System.IntPtr self ,  System.IntPtr newMat );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_Mat_assignment_FromMatExpr_excsafe( System.IntPtr self ,  System.IntPtr newMatExpr );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_Mat_assignment_FromScalar_excsafe( System.IntPtr self ,  OpenCvSharp.Scalar scalar );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_Mat_IplImage_excsafe( System.IntPtr self ,  System.IntPtr outImage );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_Mat_IplImage_alignment_excsafe( System.IntPtr self ,  out System.IntPtr outImage );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_Mat_CvMat_excsafe( System.IntPtr self ,  System.IntPtr outMat );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_Mat_operatorUnaryMinus_excsafe(ref System.IntPtr ret,  System.IntPtr mat );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_Mat_operatorAdd_MatMat_excsafe(ref System.IntPtr ret,  System.IntPtr a ,  System.IntPtr b );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_Mat_operatorAdd_MatScalar_excsafe(ref System.IntPtr ret,  System.IntPtr a ,  OpenCvSharp.Scalar s );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_Mat_operatorAdd_ScalarMat_excsafe(ref System.IntPtr ret,  OpenCvSharp.Scalar s ,  System.IntPtr a );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_Mat_operatorMinus_Mat_excsafe(ref System.IntPtr ret,  System.IntPtr a );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_Mat_operatorSubtract_MatMat_excsafe(ref System.IntPtr ret,  System.IntPtr a ,  System.IntPtr b );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_Mat_diag3_excsafe(ref System.IntPtr ret,  System.IntPtr self );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_Mat_dot_excsafe(ref System.Double ret,  System.IntPtr self ,  System.IntPtr m );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_Mat_elemSize_excsafe(ref System.UInt64 ret,  System.IntPtr self );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_Mat_elemSize1_excsafe(ref System.UInt64 ret,  System.IntPtr self );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_Mat_empty_excsafe(ref System.Int32 ret,  System.IntPtr self );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_Mat_eye_excsafe(ref System.IntPtr ret,  System.Int32 rows ,  System.Int32 cols ,  System.Int32 type );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_Mat_inv1_excsafe(ref System.IntPtr ret,  System.IntPtr self );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_Mat_inv2_excsafe(ref System.IntPtr ret,  System.IntPtr self ,  System.Int32 method );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_Mat_isContinuous_excsafe(ref System.Int32 ret,  System.IntPtr self );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_Mat_isSubmatrix_excsafe(ref System.Int32 ret,  System.IntPtr self );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_Mat_locateROI_excsafe( System.IntPtr self ,  out OpenCvSharp.Size wholeSize ,  out OpenCvSharp.Point ofs );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_Mat_mul1_excsafe(ref System.IntPtr ret,  System.IntPtr self ,  System.IntPtr m );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_Mat_mul2_excsafe(ref System.IntPtr ret,  System.IntPtr self ,  System.IntPtr m ,  System.Double scale );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_Mat_ones1_excsafe(ref System.IntPtr ret,  System.Int32 rows ,  System.Int32 cols ,  System.Int32 type );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_Mat_ones2_excsafe(ref System.IntPtr ret,  System.Int32 ndims , [MarshalAs(UnmanagedType.LPArray)] System.Int32[] sz ,  System.Int32 type );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_Mat_reshape1_excsafe(ref System.IntPtr ret,  System.IntPtr self ,  System.Int32 cn );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_Mat_reshape2_excsafe(ref System.IntPtr ret,  System.IntPtr self ,  System.Int32 cn ,  System.Int32 rows );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_Mat_reshape3_excsafe(ref System.IntPtr ret,  System.IntPtr self ,  System.Int32 cn ,  System.Int32 newndims , [MarshalAs(UnmanagedType.LPArray)] System.Int32[] newsz );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_Mat_rows_excsafe(ref System.Int32 ret,  System.IntPtr self );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_Mat_row_toMat_excsafe(ref System.IntPtr ret,  System.IntPtr self ,  System.Int32 y );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_Mat_row_toMatExpr_excsafe(ref System.IntPtr ret,  System.IntPtr self ,  System.Int32 y );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_Mat_rowRange_toMat_excsafe(ref System.IntPtr ret,  System.IntPtr self ,  System.Int32 startRow ,  System.Int32 endRow );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_Mat_rowRange_toMatExpr_excsafe(ref System.IntPtr ret,  System.IntPtr self ,  System.Int32 startRow ,  System.Int32 endRow );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_Mat_setTo_Scalar_excsafe(ref System.IntPtr ret,  System.IntPtr self ,  OpenCvSharp.Scalar value ,  System.IntPtr mask );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_Mat_setTo_InputArray_excsafe(ref System.IntPtr ret,  System.IntPtr self ,  System.IntPtr value ,  System.IntPtr mask );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_Mat_size_excsafe(ref OpenCvSharp.Size ret,  System.IntPtr self );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_Mat_sizeAt_excsafe(ref System.Int32 ret,  System.IntPtr self ,  System.Int32 i );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_Mat_step11_excsafe(ref System.UInt64 ret,  System.IntPtr self );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_Mat_release_excsafe( System.IntPtr mat );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_Mat_delete_excsafe( System.IntPtr mat );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_Mat_adjustROI_excsafe(ref System.IntPtr ret,  System.IntPtr nativeObj ,  System.Int32 dtop ,  System.Int32 dbottom ,  System.Int32 dleft ,  System.Int32 dright );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_Mat_assignTo1_excsafe( System.IntPtr self ,  System.IntPtr m );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_Mat_assignTo2_excsafe( System.IntPtr self ,  System.IntPtr m ,  System.Int32 type );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_Mat_channels_excsafe(ref System.Int32 ret,  System.IntPtr self );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_Mat_checkVector1_excsafe(ref System.Int32 ret,  System.IntPtr self ,  System.Int32 elemChannels );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_Mat_checkVector2_excsafe(ref System.Int32 ret,  System.IntPtr self ,  System.Int32 elemChannels ,  System.Int32 depth );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_Mat_checkVector3_excsafe(ref System.Int32 ret,  System.IntPtr self ,  System.Int32 elemChannels ,  System.Int32 depth ,  System.Int32 requireContinuous );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_Mat_clone_excsafe(ref System.IntPtr ret,  System.IntPtr self );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_Mat_col_toMat_excsafe(ref System.IntPtr ret,  System.IntPtr self ,  System.Int32 x );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_Mat_col_toMatExpr_excsafe(ref System.IntPtr ret,  System.IntPtr self ,  System.Int32 x );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_Mat_cols_excsafe(ref System.Int32 ret,  System.IntPtr self );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_Mat_colRange_toMat_excsafe(ref System.IntPtr ret,  System.IntPtr self ,  System.Int32 startCol ,  System.Int32 endCol );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_Mat_colRange_toMatExpr_excsafe(ref System.IntPtr ret,  System.IntPtr self ,  System.Int32 startCol ,  System.Int32 endCol );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_Mat_dims_excsafe(ref System.Int32 ret,  System.IntPtr self );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_Mat_convertTo_excsafe( System.IntPtr self ,  System.IntPtr m ,  System.Int32 rtype ,  System.Double alpha ,  System.Double beta );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_Mat_copyTo_excsafe( System.IntPtr self ,  System.IntPtr m ,  System.IntPtr mask );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_Mat_create1_excsafe( System.IntPtr self ,  System.Int32 rows ,  System.Int32 cols ,  System.Int32 type );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_Mat_create2_excsafe( System.IntPtr self ,  System.Int32 ndims , [MarshalAs(UnmanagedType.LPArray)] System.Int32[] sizes ,  System.Int32 type );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_Mat_cross_excsafe(ref System.IntPtr ret,  System.IntPtr self ,  System.IntPtr m );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_Mat_data_excsafe(ref IntPtr ret,  System.IntPtr self );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_Mat_datastart_excsafe(ref System.IntPtr ret,  System.IntPtr self );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_Mat_dataend_excsafe(ref System.IntPtr ret,  System.IntPtr self );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_Mat_datalimit_excsafe(ref System.IntPtr ret,  System.IntPtr self );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_Mat_depth_excsafe(ref System.Int32 ret,  System.IntPtr self );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_Mat_diag1_excsafe(ref System.IntPtr ret,  System.IntPtr self );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_Mat_diag2_excsafe(ref System.IntPtr ret,  System.IntPtr self ,  System.Int32 d );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_InputArray_isSubmatrix_excsafe(ref System.Int32 ret,  System.IntPtr ia ,  System.Int32 i );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_InputArray_empty_excsafe(ref System.Int32 ret,  System.IntPtr ia );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_InputArray_copyTo1_excsafe( System.IntPtr ia ,  System.IntPtr arr );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_InputArray_copyTo2_excsafe( System.IntPtr ia ,  System.IntPtr arr ,  System.IntPtr mask );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_InputArray_offset_excsafe(ref System.IntPtr ret,  System.IntPtr ia ,  System.Int32 i );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_InputArray_step_excsafe(ref System.IntPtr ret,  System.IntPtr ia ,  System.Int32 i );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_InputArray_isMat_excsafe(ref System.Int32 ret,  System.IntPtr ia );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_InputArray_isUMat_excsafe(ref System.Int32 ret,  System.IntPtr ia );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_InputArray_isMatVector_excsafe(ref System.Int32 ret,  System.IntPtr ia );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_InputArray_isUMatVector_excsafe(ref System.Int32 ret,  System.IntPtr ia );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_InputArray_isMatx_excsafe(ref System.Int32 ret,  System.IntPtr ia );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_InputArray_isVector_excsafe(ref System.Int32 ret,  System.IntPtr ia );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_InputArray_isGpuMatVector_excsafe(ref System.Int32 ret,  System.IntPtr ia );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_Mat_sizeof_excsafe(ref System.UInt64 ret);

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_Mat_new1_excsafe(ref System.IntPtr ret);

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_Mat_new2_excsafe(ref System.IntPtr ret,  System.Int32 rows ,  System.Int32 cols ,  System.Int32 type );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_Mat_new3_excsafe(ref System.IntPtr ret,  System.Int32 rows ,  System.Int32 cols ,  System.Int32 type ,  OpenCvSharp.Scalar scalar );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_Mat_new4_excsafe(ref System.IntPtr ret,  System.IntPtr mat ,  OpenCvSharp.Range rowRange ,  OpenCvSharp.Range colRange );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_Mat_new5_excsafe(ref System.IntPtr ret,  System.IntPtr mat ,  OpenCvSharp.Range rowRange );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_Mat_new6_excsafe(ref System.IntPtr ret,  System.IntPtr mat , [MarshalAs(UnmanagedType.LPArray)] OpenCvSharp.Range[] rowRange );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_Mat_new7_excsafe(ref System.IntPtr ret,  System.IntPtr mat ,  OpenCvSharp.Rect roi );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_Mat_new8_excsafe(ref System.IntPtr ret,  System.Int32 rows ,  System.Int32 cols ,  System.Int32 type ,  System.IntPtr data ,  System.IntPtr step );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_Mat_new9_excsafe(ref System.IntPtr ret,  System.Int32 ndims , [MarshalAs(UnmanagedType.LPArray)] System.Int32[] sizes ,  System.Int32 type ,  System.IntPtr data , [MarshalAs(UnmanagedType.LPArray)] System.IntPtr[] steps );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_Mat_new9_excsafe(ref System.IntPtr ret,  System.Int32 ndims , [MarshalAs(UnmanagedType.LPArray)] System.Int32[] sizes ,  System.Int32 type ,  System.IntPtr data ,  System.IntPtr steps );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_Mat_new10_excsafe(ref System.IntPtr ret,  System.Int32 ndims , [MarshalAs(UnmanagedType.LPArray)] System.Int32[] sizes ,  System.Int32 type );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_Mat_new11_excsafe(ref System.IntPtr ret,  System.Int32 ndims , [MarshalAs(UnmanagedType.LPArray)] System.Int32[] sizes ,  System.Int32 type ,  OpenCvSharp.Scalar s );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_Mat_new_FromIplImage_excsafe(ref System.IntPtr ret,  System.IntPtr img ,  System.Int32 copyData );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_Mat_new_FromCvMat_excsafe(ref System.IntPtr ret,  System.IntPtr mat ,  System.Int32 copyData );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_InputArray_new_byMatExpr_excsafe(ref System.IntPtr ret,  System.IntPtr mat );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_InputArray_new_byScalar_excsafe(ref System.IntPtr ret,  OpenCvSharp.Scalar val );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_InputArray_new_byDouble_excsafe(ref System.IntPtr ret,  System.Double val );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_InputArray_new_byGpuMat_excsafe(ref System.IntPtr ret,  System.IntPtr mat );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_InputArray_new_byVectorOfMat_excsafe(ref System.IntPtr ret,  System.IntPtr vector );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_InputArray_delete_excsafe( System.IntPtr ia );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_InputArray_getMat_excsafe(ref System.IntPtr ret,  System.IntPtr ia ,  System.Int32 idx );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_InputArray_getMat__excsafe(ref System.IntPtr ret,  System.IntPtr ia ,  System.Int32 idx );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_InputArray_getUMat_excsafe(ref System.IntPtr ret,  System.IntPtr ia ,  System.Int32 idx );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_InputArray_getMatVector_excsafe( System.IntPtr ia ,  System.IntPtr mv );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_InputArray_getUMatVector_excsafe( System.IntPtr ia ,  System.IntPtr umv );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_InputArray_getGpuMatVector_excsafe( System.IntPtr ia ,  System.IntPtr gpumv );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_InputArray_getGpuMat_excsafe(ref System.IntPtr ret,  System.IntPtr ia );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_InputArray_getFlags_excsafe(ref System.Int32 ret,  System.IntPtr ia );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_InputArray_getObj_excsafe(ref System.IntPtr ret,  System.IntPtr ia );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_InputArray_getSz_excsafe(ref OpenCvSharp.Size ret,  System.IntPtr ia );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_InputArray_kind_excsafe(ref System.Int32 ret,  System.IntPtr ia );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_InputArray_dims_excsafe(ref System.Int32 ret,  System.IntPtr ia ,  System.Int32 i );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_InputArray_cols_excsafe(ref System.Int32 ret,  System.IntPtr ia ,  System.Int32 i );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_InputArray_rows_excsafe(ref System.Int32 ret,  System.IntPtr ia ,  System.Int32 i );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_InputArray_size_excsafe(ref OpenCvSharp.Size ret,  System.IntPtr ia ,  System.Int32 i );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_InputArray_sizend_excsafe(ref System.Int32 ret,  System.IntPtr ia ,  System.Int32[] sz ,  System.Int32 i );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_InputArray_sameSize_excsafe(ref System.Int32 ret,  System.IntPtr self ,  System.IntPtr target );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_InputArray_total_excsafe(ref System.IntPtr ret,  System.IntPtr ia ,  System.Int32 i );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_InputArray_type_excsafe(ref System.Int32 ret,  System.IntPtr ia ,  System.Int32 i );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_InputArray_depth_excsafe(ref System.Int32 ret,  System.IntPtr ia ,  System.Int32 i );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_InputArray_channels_excsafe(ref System.Int32 ret,  System.IntPtr ia ,  System.Int32 i );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_InputArray_isContinuous_excsafe(ref System.Int32 ret,  System.IntPtr ia ,  System.Int32 i );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_FileStorage_shift_Rect2f_excsafe( System.IntPtr fs ,  OpenCvSharp.Rect2f val );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_FileStorage_shift_Rect2d_excsafe( System.IntPtr fs ,  OpenCvSharp.Rect2d val );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_FileStorage_shift_Scalar_excsafe( System.IntPtr fs ,  OpenCvSharp.Scalar val );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_FileStorage_shift_Vec2i_excsafe( System.IntPtr fs ,  OpenCvSharp.Vec2i val );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_FileStorage_shift_Vec3i_excsafe( System.IntPtr fs ,  OpenCvSharp.Vec3i val );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_FileStorage_shift_Vec4i_excsafe( System.IntPtr fs ,  OpenCvSharp.Vec4i val );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_FileStorage_shift_Vec6i_excsafe( System.IntPtr fs ,  OpenCvSharp.Vec6i val );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_FileStorage_shift_Vec2d_excsafe( System.IntPtr fs ,  OpenCvSharp.Vec2d val );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_FileStorage_shift_Vec3d_excsafe( System.IntPtr fs ,  OpenCvSharp.Vec3d val );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_FileStorage_shift_Vec4d_excsafe( System.IntPtr fs ,  OpenCvSharp.Vec4d val );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_FileStorage_shift_Vec6d_excsafe( System.IntPtr fs ,  OpenCvSharp.Vec6d val );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_FileStorage_shift_Vec2f_excsafe( System.IntPtr fs ,  OpenCvSharp.Vec2f val );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_FileStorage_shift_Vec3f_excsafe( System.IntPtr fs ,  OpenCvSharp.Vec3f val );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_FileStorage_shift_Vec4f_excsafe( System.IntPtr fs ,  OpenCvSharp.Vec4f val );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_FileStorage_shift_Vec6f_excsafe( System.IntPtr fs ,  OpenCvSharp.Vec6f val );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_FileStorage_shift_Vec2b_excsafe( System.IntPtr fs ,  OpenCvSharp.Vec2b val );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_FileStorage_shift_Vec3b_excsafe( System.IntPtr fs ,  OpenCvSharp.Vec3b val );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_FileStorage_shift_Vec4b_excsafe( System.IntPtr fs ,  OpenCvSharp.Vec4b val );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_FileStorage_shift_Vec6b_excsafe( System.IntPtr fs ,  OpenCvSharp.Vec6b val );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_FileStorage_shift_Vec2s_excsafe( System.IntPtr fs ,  OpenCvSharp.Vec2s val );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_FileStorage_shift_Vec3s_excsafe( System.IntPtr fs ,  OpenCvSharp.Vec3s val );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_FileStorage_shift_Vec4s_excsafe( System.IntPtr fs ,  OpenCvSharp.Vec4s val );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_FileStorage_shift_Vec6s_excsafe( System.IntPtr fs ,  OpenCvSharp.Vec6s val );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_FileStorage_shift_Vec2w_excsafe( System.IntPtr fs ,  OpenCvSharp.Vec2w val );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_FileStorage_shift_Vec3w_excsafe( System.IntPtr fs ,  OpenCvSharp.Vec3w val );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_FileStorage_shift_Vec4w_excsafe( System.IntPtr fs ,  OpenCvSharp.Vec4w val );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_FileStorage_shift_Vec6w_excsafe( System.IntPtr fs ,  OpenCvSharp.Vec6w val );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_InputArray_new_byMat_excsafe(ref System.IntPtr ret,  System.IntPtr mat );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_FileStorage_write_SparseMat_excsafe( System.IntPtr fs , [MarshalAs(UnmanagedType.LPStr)] System.String name ,  System.IntPtr value );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_FileStorage_write_vectorOfKeyPoint_excsafe( System.IntPtr fs , [MarshalAs(UnmanagedType.LPStr)] System.String name ,  System.IntPtr value );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_FileStorage_write_vectorOfDMatch_excsafe( System.IntPtr fs , [MarshalAs(UnmanagedType.LPStr)] System.String name ,  System.IntPtr value );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_FileStorage_writeScalar_int_excsafe( System.IntPtr fs ,  System.Int32 value );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_FileStorage_writeScalar_float_excsafe( System.IntPtr fs ,  System.Single value );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_FileStorage_writeScalar_double_excsafe( System.IntPtr fs ,  System.Double value );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_FileStorage_writeScalar_String_excsafe( System.IntPtr fs , [MarshalAs(UnmanagedType.LPStr)] System.String value );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_FileStorage_shift_String_excsafe( System.IntPtr fs , [MarshalAs(UnmanagedType.LPStr)] System.String val );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_FileStorage_shift_int_excsafe( System.IntPtr fs ,  System.Int32 val );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_FileStorage_shift_float_excsafe( System.IntPtr fs ,  System.Single val );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_FileStorage_shift_double_excsafe( System.IntPtr fs ,  System.Double val );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_FileStorage_shift_Mat_excsafe( System.IntPtr fs ,  System.IntPtr val );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_FileStorage_shift_SparseMat_excsafe( System.IntPtr fs ,  System.IntPtr val );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_FileStorage_shift_Range_excsafe( System.IntPtr fs ,  OpenCvSharp.Range val );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_FileStorage_shift_KeyPoint_excsafe( System.IntPtr fs ,  OpenCvSharp.KeyPoint val );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_FileStorage_shift_DMatch_excsafe( System.IntPtr fs ,  OpenCvSharp.DMatch val );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_FileStorage_shift_vectorOfKeyPoint_excsafe( System.IntPtr fs ,  System.IntPtr val );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_FileStorage_shift_vectorOfDMatch_excsafe( System.IntPtr fs ,  System.IntPtr val );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_FileStorage_shift_Point2i_excsafe( System.IntPtr fs ,  OpenCvSharp.Point val );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_FileStorage_shift_Point2f_excsafe( System.IntPtr fs ,  OpenCvSharp.Point2f val );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_FileStorage_shift_Point2d_excsafe( System.IntPtr fs ,  OpenCvSharp.Point2d val );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_FileStorage_shift_Point3i_excsafe( System.IntPtr fs ,  OpenCvSharp.Point3i val );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_FileStorage_shift_Point3f_excsafe( System.IntPtr fs ,  OpenCvSharp.Point3f val );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_FileStorage_shift_Point3d_excsafe( System.IntPtr fs ,  OpenCvSharp.Point3d val );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_FileStorage_shift_Size2i_excsafe( System.IntPtr fs ,  OpenCvSharp.Size val );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_FileStorage_shift_Size2f_excsafe( System.IntPtr fs ,  OpenCvSharp.Size2f val );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_FileStorage_shift_Size2d_excsafe( System.IntPtr fs ,  OpenCvSharp.Size2d val );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_FileStorage_shift_Rect2i_excsafe( System.IntPtr fs ,  OpenCvSharp.Rect val );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_FileNodeIterator_readRaw_excsafe(ref System.IntPtr ret,  System.IntPtr obj , [MarshalAs(UnmanagedType.LPStr)] System.String fmt ,  System.IntPtr vec ,  System.IntPtr maxCount );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_FileNodeIterator_readRaw_excsafe(ref System.IntPtr ret,  System.IntPtr obj , [MarshalAs(UnmanagedType.LPStr)] System.String fmt ,  System.Byte[] vec ,  System.IntPtr maxCount );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_FileNodeIterator_operatorEqual_excsafe(ref System.Int32 ret,  System.IntPtr it1 ,  System.IntPtr it2 );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_FileNodeIterator_operatorMinus_excsafe(ref System.IntPtr ret,  System.IntPtr it1 ,  System.IntPtr it2 );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_FileNodeIterator_operatorLessThan_excsafe(ref System.Int32 ret,  System.IntPtr it1 ,  System.IntPtr it2 );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_FileStorage_new1_excsafe(ref System.IntPtr ret);

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_FileStorage_new2_excsafe(ref System.IntPtr ret, [MarshalAs(UnmanagedType.LPStr)] System.String source ,  System.Int32 flags , [MarshalAs(UnmanagedType.LPStr)] System.String encoding );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_FileStorage_newFromLegacy_excsafe(ref System.IntPtr ret,  System.IntPtr fs );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_FileStorage_delete_excsafe( System.IntPtr obj );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_FileStorage_open_excsafe(ref System.Int32 ret,  System.IntPtr obj , [MarshalAs(UnmanagedType.LPStr)] System.String filename ,  System.Int32 flags , [MarshalAs(UnmanagedType.LPStr)] System.String encoding );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_FileStorage_isOpened_excsafe(ref System.Int32 ret,  System.IntPtr obj );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_FileStorage_release_excsafe( System.IntPtr obj );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_FileStorage_releaseAndGetString_excsafe( System.IntPtr obj , [MarshalAs(UnmanagedType.LPStr)] System.Text.StringBuilder buf ,  System.Int32 bufLength );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_FileStorage_getFirstTopLevelNode_excsafe(ref System.IntPtr ret,  System.IntPtr obj );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_FileStorage_root_excsafe(ref System.IntPtr ret,  System.IntPtr obj ,  System.Int32 streamIdx );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_FileStorage_indexer_excsafe(ref System.IntPtr ret,  System.IntPtr obj , [MarshalAs(UnmanagedType.LPStr)] System.String nodeName );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_FileStorage_toLegacy_excsafe(ref System.IntPtr ret,  System.IntPtr obj );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_FileStorage_writeRaw_excsafe( System.IntPtr obj , [MarshalAs(UnmanagedType.LPStr)] System.String fmt ,  System.IntPtr vec ,  System.IntPtr len );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_FileStorage_writeObj_excsafe( System.IntPtr obj , [MarshalAs(UnmanagedType.LPStr)] System.String name ,  System.IntPtr value );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_FileStorage_getDefaultObjectName_excsafe([MarshalAs(UnmanagedType.LPStr)] System.String filename , [MarshalAs(UnmanagedType.LPStr)] System.Text.StringBuilder buf ,  System.Int32 bufLength );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_FileStorage_elname_excsafe(ref IntPtr ret,  System.IntPtr obj );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_FileStorage_structs_excsafe(ref System.IntPtr ret,  System.IntPtr obj ,  out System.IntPtr resultLength );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_FileStorage_state_excsafe(ref System.Int32 ret,  System.IntPtr obj );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_FileStorage_write_int_excsafe( System.IntPtr fs , [MarshalAs(UnmanagedType.LPStr)] System.String name ,  System.Int32 value );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_FileStorage_write_float_excsafe( System.IntPtr fs , [MarshalAs(UnmanagedType.LPStr)] System.String name ,  System.Single value );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_FileStorage_write_double_excsafe( System.IntPtr fs , [MarshalAs(UnmanagedType.LPStr)] System.String name ,  System.Double value );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_FileStorage_write_String_excsafe( System.IntPtr fs , [MarshalAs(UnmanagedType.LPStr)] System.String name , [MarshalAs(UnmanagedType.LPStr)] System.String value );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_FileStorage_write_Mat_excsafe( System.IntPtr fs , [MarshalAs(UnmanagedType.LPStr)] System.String name ,  System.IntPtr value );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_FileNode_read_Vec2d_excsafe(ref OpenCvSharp.Vec2d ret,  System.IntPtr node );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_FileNode_read_Vec3d_excsafe(ref OpenCvSharp.Vec3d ret,  System.IntPtr node );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_FileNode_read_Vec4d_excsafe(ref OpenCvSharp.Vec4d ret,  System.IntPtr node );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_FileNode_read_Vec6d_excsafe(ref OpenCvSharp.Vec6d ret,  System.IntPtr node );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_FileNode_read_Vec2f_excsafe(ref OpenCvSharp.Vec2f ret,  System.IntPtr node );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_FileNode_read_Vec3f_excsafe(ref OpenCvSharp.Vec3f ret,  System.IntPtr node );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_FileNode_read_Vec4f_excsafe(ref OpenCvSharp.Vec4f ret,  System.IntPtr node );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_FileNode_read_Vec6f_excsafe(ref OpenCvSharp.Vec6f ret,  System.IntPtr node );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_FileNode_read_Vec2b_excsafe(ref OpenCvSharp.Vec2b ret,  System.IntPtr node );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_FileNode_read_Vec3b_excsafe(ref OpenCvSharp.Vec3b ret,  System.IntPtr node );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_FileNode_read_Vec4b_excsafe(ref OpenCvSharp.Vec4b ret,  System.IntPtr node );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_FileNode_read_Vec6b_excsafe(ref OpenCvSharp.Vec6b ret,  System.IntPtr node );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_FileNode_read_Vec2s_excsafe(ref OpenCvSharp.Vec2s ret,  System.IntPtr node );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_FileNode_read_Vec3s_excsafe(ref OpenCvSharp.Vec3s ret,  System.IntPtr node );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_FileNode_read_Vec4s_excsafe(ref OpenCvSharp.Vec4s ret,  System.IntPtr node );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_FileNode_read_Vec6s_excsafe(ref OpenCvSharp.Vec6s ret,  System.IntPtr node );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_FileNode_read_Vec2w_excsafe(ref OpenCvSharp.Vec2w ret,  System.IntPtr node );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_FileNode_read_Vec3w_excsafe(ref OpenCvSharp.Vec3w ret,  System.IntPtr node );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_FileNode_read_Vec4w_excsafe(ref OpenCvSharp.Vec4w ret,  System.IntPtr node );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_FileNode_read_Vec6w_excsafe(ref OpenCvSharp.Vec6w ret,  System.IntPtr node );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_FileNodeIterator_new1_excsafe(ref System.IntPtr ret);

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_FileNodeIterator_new2_excsafe(ref System.IntPtr ret,  System.IntPtr obj );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_FileNodeIterator_delete_excsafe( System.IntPtr obj );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_FileNodeIterator_operatorAsterisk_excsafe(ref System.IntPtr ret,  System.IntPtr obj );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_FileNodeIterator_operatorIncrement_excsafe(ref System.Int32 ret,  System.IntPtr obj );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_FileNodeIterator_operatorDecrement_excsafe(ref System.Int32 ret,  System.IntPtr obj );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_FileNodeIterator_operatorPlusEqual_excsafe(ref System.Int32 ret,  System.IntPtr obj ,  System.Int32 ofs );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_FileNodeIterator_operatorMinusEqual_excsafe(ref System.Int32 ret,  System.IntPtr obj ,  System.Int32 ofs );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_FileNode_read_int_excsafe( System.IntPtr node ,  out System.Int32 value ,  System.Int32 defaultValue );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_FileNode_read_float_excsafe( System.IntPtr node ,  out System.Single value ,  System.Single defaultValue );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_FileNode_read_double_excsafe( System.IntPtr node ,  out System.Double value ,  System.Double defaultValue );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_FileNode_read_String_excsafe( System.IntPtr node , [MarshalAs(UnmanagedType.LPStr)] System.Text.StringBuilder value ,  System.Int32 valueCapacity , [MarshalAs(UnmanagedType.LPStr)] System.String defaultValue );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_FileNode_read_Mat_excsafe( System.IntPtr node ,  System.IntPtr mat ,  System.IntPtr defaultMat );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_FileNode_read_SparseMat_excsafe( System.IntPtr node ,  System.IntPtr mat ,  System.IntPtr defaultMat );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_FileNode_read_vectorOfKeyPoint_excsafe( System.IntPtr node ,  System.IntPtr keypoints );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_FileNode_read_vectorOfDMatch_excsafe( System.IntPtr node ,  System.IntPtr matches );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_FileNode_read_Range_excsafe(ref OpenCvSharp.Range ret,  System.IntPtr node );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_FileNode_read_KeyPoint_excsafe(ref OpenCvSharp.KeyPoint ret,  System.IntPtr node );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_FileNode_read_DMatch_excsafe(ref OpenCvSharp.DMatch ret,  System.IntPtr node );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_FileNode_read_Point2i_excsafe(ref OpenCvSharp.Point ret,  System.IntPtr node );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_FileNode_read_Point2f_excsafe(ref OpenCvSharp.Point2f ret,  System.IntPtr node );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_FileNode_read_Point2d_excsafe(ref OpenCvSharp.Point2d ret,  System.IntPtr node );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_FileNode_read_Point3i_excsafe(ref OpenCvSharp.Point3i ret,  System.IntPtr node );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_FileNode_read_Point3f_excsafe(ref OpenCvSharp.Point3f ret,  System.IntPtr node );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_FileNode_read_Point3d_excsafe(ref OpenCvSharp.Point3d ret,  System.IntPtr node );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_FileNode_read_Size2i_excsafe(ref OpenCvSharp.Size ret,  System.IntPtr node );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_FileNode_read_Size2f_excsafe(ref OpenCvSharp.Size2f ret,  System.IntPtr node );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_FileNode_read_Size2d_excsafe(ref OpenCvSharp.Size2d ret,  System.IntPtr node );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_FileNode_read_Rect2i_excsafe(ref OpenCvSharp.Rect ret,  System.IntPtr node );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_FileNode_read_Rect2f_excsafe(ref OpenCvSharp.Rect2f ret,  System.IntPtr node );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_FileNode_read_Rect2d_excsafe(ref OpenCvSharp.Rect2d ret,  System.IntPtr node );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_FileNode_read_Scalar_excsafe(ref OpenCvSharp.Scalar ret,  System.IntPtr node );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_FileNode_read_Vec2i_excsafe(ref OpenCvSharp.Vec2i ret,  System.IntPtr node );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_FileNode_read_Vec3i_excsafe(ref OpenCvSharp.Vec3i ret,  System.IntPtr node );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_FileNode_read_Vec4i_excsafe(ref OpenCvSharp.Vec4i ret,  System.IntPtr node );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_FileNode_read_Vec6i_excsafe(ref OpenCvSharp.Vec6i ret,  System.IntPtr node );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_LDA_subspaceProject_excsafe(ref System.IntPtr ret,  System.IntPtr w ,  System.IntPtr mean ,  System.IntPtr src );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_LDA_subspaceReconstruct_excsafe(ref System.IntPtr ret,  System.IntPtr w ,  System.IntPtr mean ,  System.IntPtr src );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_FileNode_new1_excsafe(ref System.IntPtr ret);

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_FileNode_new2_excsafe(ref System.IntPtr ret,  System.IntPtr fs ,  System.IntPtr node );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_FileNode_new3_excsafe(ref System.IntPtr ret,  System.IntPtr node );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_FileNode_delete_excsafe( System.IntPtr node );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_FileNode_operatorThis_byString_excsafe(ref System.IntPtr ret,  System.IntPtr obj , [MarshalAs(UnmanagedType.LPStr)] System.String nodeName );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_FileNode_operatorThis_byInt_excsafe(ref System.IntPtr ret,  System.IntPtr obj ,  System.Int32 i );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_FileNode_type_excsafe(ref System.Int32 ret,  System.IntPtr obj );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_FileNode_empty_excsafe(ref System.Int32 ret,  System.IntPtr obj );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_FileNode_isNone_excsafe(ref System.Int32 ret,  System.IntPtr obj );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_FileNode_isSeq_excsafe(ref System.Int32 ret,  System.IntPtr obj );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_FileNode_isMap_excsafe(ref System.Int32 ret,  System.IntPtr obj );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_FileNode_isInt_excsafe(ref System.Int32 ret,  System.IntPtr obj );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_FileNode_isReal_excsafe(ref System.Int32 ret,  System.IntPtr obj );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_FileNode_isString_excsafe(ref System.Int32 ret,  System.IntPtr obj );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_FileNode_isNamed_excsafe(ref System.Int32 ret,  System.IntPtr obj );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_FileNode_name_excsafe( System.IntPtr obj , [MarshalAs(UnmanagedType.LPStr)] System.Text.StringBuilder buf ,  System.Int32 bufLength );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_FileNode_size_excsafe(ref System.IntPtr ret,  System.IntPtr obj );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_FileNode_toInt_excsafe(ref System.Int32 ret,  System.IntPtr obj );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_FileNode_toFloat_excsafe(ref System.Single ret,  System.IntPtr obj );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_FileNode_toDouble_excsafe(ref System.Double ret,  System.IntPtr obj );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_FileNode_toString_excsafe( System.IntPtr obj ,  System.Text.StringBuilder buf ,  System.Int32 bufLength );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_FileNode_toMat_excsafe( System.IntPtr obj ,  System.IntPtr m );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_FileNode_begin_excsafe(ref System.IntPtr ret,  System.IntPtr obj );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_FileNode_end_excsafe(ref System.IntPtr ret,  System.IntPtr obj );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_FileNode_readRaw_excsafe( System.IntPtr obj , [MarshalAs(UnmanagedType.LPStr)] System.String fmt ,  System.IntPtr vec ,  System.IntPtr len );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_FileNode_readObj_excsafe(ref System.IntPtr ret,  System.IntPtr obj );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_PCA_eigenvalues_excsafe(ref System.IntPtr ret,  System.IntPtr obj );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_PCA_mean_excsafe(ref System.IntPtr ret,  System.IntPtr obj );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_RNG_fill_excsafe( ref System.UInt64 state ,  System.IntPtr mat ,  System.Int32 distType ,  System.IntPtr a ,  System.IntPtr b ,  System.Int32 saturateRange );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_RNG_gaussian_excsafe(ref System.Double ret,  ref System.UInt64 state ,  System.Double sigma );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_SVD_new1_excsafe(ref System.IntPtr ret);

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_SVD_new2_excsafe(ref System.IntPtr ret,  System.IntPtr src ,  System.Int32 flags );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_SVD_delete_excsafe( System.IntPtr obj );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_SVD_operatorThis_excsafe( System.IntPtr obj ,  System.IntPtr src ,  System.Int32 flags );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_SVD_backSubst_excsafe( System.IntPtr obj ,  System.IntPtr rhs ,  System.IntPtr dst );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_SVD_static_compute1_excsafe( System.IntPtr src ,  System.IntPtr w ,  System.IntPtr u ,  System.IntPtr vt ,  System.Int32 flags );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_SVD_static_compute2_excsafe( System.IntPtr src ,  System.IntPtr w ,  System.Int32 flags );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_SVD_static_backSubst_excsafe( System.IntPtr w ,  System.IntPtr u ,  System.IntPtr vt ,  System.IntPtr rhs ,  System.IntPtr dst );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_SVD_static_solveZ_excsafe( System.IntPtr src ,  System.IntPtr dst );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_SVD_u_excsafe(ref System.IntPtr ret,  System.IntPtr obj );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_SVD_w_excsafe(ref System.IntPtr ret,  System.IntPtr obj );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_SVD_vt_excsafe(ref System.IntPtr ret,  System.IntPtr obj );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_LDA_new1_excsafe(ref System.IntPtr ret,  System.Int32 numComponents );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_LDA_new2_excsafe(ref System.IntPtr ret,  System.IntPtr src ,  System.IntPtr labels ,  System.Int32 numComponents );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_LDA_delete_excsafe( System.IntPtr obj );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_LDA_save_String_excsafe( System.IntPtr obj , [MarshalAs(UnmanagedType.LPStr)] System.String filename );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_LDA_load_String_excsafe( System.IntPtr obj , [MarshalAs(UnmanagedType.LPStr)] System.String filename );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_LDA_save_FileStorage_excsafe( System.IntPtr obj ,  System.IntPtr fs );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_LDA_load_FileStorage_excsafe( System.IntPtr obj ,  System.IntPtr node );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_LDA_compute_excsafe( System.IntPtr obj ,  System.IntPtr src ,  System.IntPtr labels );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_LDA_project_excsafe(ref System.IntPtr ret,  System.IntPtr obj ,  System.IntPtr src );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_LDA_reconstruct_excsafe(ref System.IntPtr ret,  System.IntPtr obj ,  System.IntPtr src );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_LDA_eigenvectors_excsafe(ref System.IntPtr ret,  System.IntPtr obj );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_LDA_eigenvalues_excsafe(ref System.IntPtr ret,  System.IntPtr obj );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_dct_excsafe( System.IntPtr src ,  System.IntPtr dst ,  System.Int32 flags );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_idct_excsafe( System.IntPtr src ,  System.IntPtr dst ,  System.Int32 flags );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_mulSpectrums_excsafe( System.IntPtr a ,  System.IntPtr b ,  System.IntPtr c ,  System.Int32 flags ,  System.Int32 conjB );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_getOptimalDFTSize_excsafe(ref System.Int32 ret,  System.Int32 vecsize );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_kmeans_excsafe(ref System.Double ret,  System.IntPtr data ,  System.Int32 k ,  System.IntPtr bestLabels ,  OpenCvSharp.TermCriteria criteria ,  System.Int32 attempts ,  System.Int32 flags ,  System.IntPtr centers );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_theRNG_excsafe(ref System.UInt64 ret);

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_randu_InputArray_excsafe( System.IntPtr dst ,  System.IntPtr low ,  System.IntPtr high );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_randu_Scalar_excsafe( System.IntPtr dst ,  OpenCvSharp.Scalar low ,  OpenCvSharp.Scalar high );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_randn_InputArray_excsafe( System.IntPtr dst ,  System.IntPtr mean ,  System.IntPtr stddev );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_randn_Scalar_excsafe( System.IntPtr dst ,  OpenCvSharp.Scalar mean ,  OpenCvSharp.Scalar stddev );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_randShuffle_excsafe( System.IntPtr dst ,  System.Double iterFactor ,  ref System.UInt64 rng );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_randShuffle_excsafe( System.IntPtr dst ,  System.Double iterFactor ,  System.IntPtr rng );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_Algorithm_write_excsafe( System.IntPtr obj ,  System.IntPtr fs );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_Algorithm_read_excsafe( System.IntPtr obj ,  System.IntPtr fn );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_Algorithm_empty_excsafe(ref System.Int32 ret,  System.IntPtr obj );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_Algorithm_save_excsafe( System.IntPtr obj ,  System.String filename );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_Algorithm_getDefaultName_excsafe( System.IntPtr obj , [MarshalAs(UnmanagedType.LPStr)] System.Text.StringBuilder buf ,  System.Int32 bufLength );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_PCA_new1_excsafe(ref System.IntPtr ret);

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_PCA_new2_excsafe(ref System.IntPtr ret,  System.IntPtr data ,  System.IntPtr mean ,  System.Int32 flags ,  System.Int32 maxComponents );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_PCA_new3_excsafe(ref System.IntPtr ret,  System.IntPtr data ,  System.IntPtr mean ,  System.Int32 flags ,  System.Double retainedVariance );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_PCA_delete_excsafe( System.IntPtr obj );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_PCA_operatorThis_excsafe( System.IntPtr obj ,  System.IntPtr data ,  System.IntPtr mean ,  System.Int32 flags ,  System.Int32 maxComponents );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_PCA_computeVar_excsafe( System.IntPtr obj ,  System.IntPtr data ,  System.IntPtr mean ,  System.Int32 flags ,  System.Double retainedVariance );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_PCA_project1_excsafe(ref System.IntPtr ret,  System.IntPtr obj ,  System.IntPtr vec );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_PCA_project2_excsafe( System.IntPtr obj ,  System.IntPtr vec ,  System.IntPtr result );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_PCA_backProject1_excsafe(ref System.IntPtr ret,  System.IntPtr obj ,  System.IntPtr vec );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_PCA_backProject2_excsafe( System.IntPtr obj ,  System.IntPtr vec ,  System.IntPtr result );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_PCA_eigenvectors_excsafe(ref System.IntPtr ret,  System.IntPtr obj );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_perspectiveTransform_Mat_excsafe( System.IntPtr src ,  System.IntPtr dst ,  System.IntPtr m );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_perspectiveTransform_Point2f_excsafe( System.IntPtr src ,  System.Int32 srcLength ,  System.IntPtr dst ,  System.Int32 dstLength ,  System.IntPtr m );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_perspectiveTransform_Point2d_excsafe( System.IntPtr src ,  System.Int32 srcLength ,  System.IntPtr dst ,  System.Int32 dstLength ,  System.IntPtr m );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_perspectiveTransform_Point3f_excsafe( System.IntPtr src ,  System.Int32 srcLength ,  System.IntPtr dst ,  System.Int32 dstLength ,  System.IntPtr m );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_perspectiveTransform_Point3d_excsafe( System.IntPtr src ,  System.Int32 srcLength ,  System.IntPtr dst ,  System.Int32 dstLength ,  System.IntPtr m );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_completeSymm_excsafe( System.IntPtr mtx ,  System.Int32 lowerToUpper );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_setIdentity_excsafe( System.IntPtr mtx ,  OpenCvSharp.Scalar s );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_determinant_excsafe(ref System.Double ret,  System.IntPtr mtx );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_trace_excsafe(ref OpenCvSharp.Scalar ret,  System.IntPtr mtx );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_invert_excsafe(ref System.Double ret,  System.IntPtr src ,  System.IntPtr dst ,  System.Int32 flags );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_solve_excsafe(ref System.Int32 ret,  System.IntPtr src1 ,  System.IntPtr src2 ,  System.IntPtr dst ,  System.Int32 flags );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_solveLP_excsafe(ref System.Int32 ret,  System.IntPtr func ,  System.IntPtr constr ,  System.IntPtr z );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_sort_excsafe( System.IntPtr src ,  System.IntPtr dst ,  System.Int32 flags );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_sortIdx_excsafe( System.IntPtr src ,  System.IntPtr dst ,  System.Int32 flags );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_solveCubic_excsafe(ref System.Int32 ret,  System.IntPtr coeffs ,  System.IntPtr roots );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_solvePoly_excsafe(ref System.Double ret,  System.IntPtr coeffs ,  System.IntPtr roots ,  System.Int32 maxIters );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_eigen_excsafe(ref System.Int32 ret,  System.IntPtr src ,  System.IntPtr eigenvalues ,  System.IntPtr eigenvectors );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_calcCovarMatrix_Mat_excsafe([MarshalAs(UnmanagedType.LPArray)] System.IntPtr[] samples ,  System.Int32 nsamples ,  System.IntPtr covar ,  System.IntPtr mean ,  System.Int32 flags ,  System.Int32 ctype );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_calcCovarMatrix_InputArray_excsafe( System.IntPtr samples ,  System.IntPtr covar ,  System.IntPtr mean ,  System.Int32 flags ,  System.Int32 ctype );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_PCACompute_excsafe( System.IntPtr data ,  System.IntPtr mean ,  System.IntPtr eigenvectors ,  System.Int32 maxComponents );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_PCAComputeVar_excsafe( System.IntPtr data ,  System.IntPtr mean ,  System.IntPtr eigenvectors ,  System.Double retainedVariance );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_PCAProject_excsafe( System.IntPtr data ,  System.IntPtr mean ,  System.IntPtr eigenvectors ,  System.IntPtr result );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_PCABackProject_excsafe( System.IntPtr data ,  System.IntPtr mean ,  System.IntPtr eigenvectors ,  System.IntPtr result );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_SVDecomp_excsafe( System.IntPtr src ,  System.IntPtr w ,  System.IntPtr u ,  System.IntPtr vt ,  System.Int32 flags );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_SVBackSubst_excsafe( System.IntPtr w ,  System.IntPtr u ,  System.IntPtr vt ,  System.IntPtr rhs ,  System.IntPtr dst );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_Mahalanobis_excsafe(ref System.Double ret,  System.IntPtr v1 ,  System.IntPtr v2 ,  System.IntPtr icovar );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_dft_excsafe( System.IntPtr src ,  System.IntPtr dst ,  System.Int32 flags ,  System.Int32 nonzeroRows );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_idft_excsafe( System.IntPtr src ,  System.IntPtr dst ,  System.Int32 flags ,  System.Int32 nonzeroRows );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_bitwise_not_excsafe( System.IntPtr src ,  System.IntPtr dst ,  System.IntPtr mask );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_absdiff_excsafe( System.IntPtr src1 ,  System.IntPtr src2 ,  System.IntPtr dst );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_inRange_InputArray_excsafe( System.IntPtr src ,  System.IntPtr lowerb ,  System.IntPtr upperb ,  System.IntPtr dst );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_inRange_Scalar_excsafe( System.IntPtr src ,  OpenCvSharp.Scalar lowerb ,  OpenCvSharp.Scalar upperb ,  System.IntPtr dst );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_compare_excsafe( System.IntPtr src1 ,  System.IntPtr src2 ,  System.IntPtr dst ,  System.Int32 cmpop );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_min1_excsafe( System.IntPtr src1 ,  System.IntPtr src2 ,  System.IntPtr dst );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_max1_excsafe( System.IntPtr src1 ,  System.IntPtr src2 ,  System.IntPtr dst );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_min_MatMat_excsafe( System.IntPtr src1 ,  System.IntPtr src2 ,  System.IntPtr dst );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_min_MatDouble_excsafe( System.IntPtr src1 ,  System.Double src2 ,  System.IntPtr dst );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_max_MatMat_excsafe( System.IntPtr src1 ,  System.IntPtr src2 ,  System.IntPtr dst );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_max_MatDouble_excsafe( System.IntPtr src1 ,  System.Double src2 ,  System.IntPtr dst );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_sqrt_excsafe( System.IntPtr src ,  System.IntPtr dst );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_pow_Mat_excsafe( System.IntPtr src ,  System.Double power ,  System.IntPtr dst );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_exp_Mat_excsafe( System.IntPtr src ,  System.IntPtr dst );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_log_Mat_excsafe( System.IntPtr src ,  System.IntPtr dst );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_cubeRoot_excsafe(ref System.Single ret,  System.Single val );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_fastAtan2_excsafe(ref System.Single ret,  System.Single y ,  System.Single x );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_polarToCart_excsafe( System.IntPtr magnitude ,  System.IntPtr angle ,  System.IntPtr x ,  System.IntPtr y ,  System.Int32 angleInDegrees );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_cartToPolar_excsafe( System.IntPtr x ,  System.IntPtr y ,  System.IntPtr magnitude ,  System.IntPtr angle ,  System.Int32 angleInDegrees );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_phase_excsafe( System.IntPtr x ,  System.IntPtr y ,  System.IntPtr angle ,  System.Int32 angleInDegrees );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_magnitude_Mat_excsafe( System.IntPtr x ,  System.IntPtr y ,  System.IntPtr magnitude );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_checkRange_excsafe(ref System.Int32 ret,  System.IntPtr a ,  System.Int32 quiet ,  out OpenCvSharp.Point pos ,  System.Double minVal ,  System.Double maxVal );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_patchNaNs_excsafe( System.IntPtr a ,  System.Double val );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_gemm_excsafe( System.IntPtr src1 ,  System.IntPtr src2 ,  System.Double alpha ,  System.IntPtr src3 ,  System.Double gamma ,  System.IntPtr dst ,  System.Int32 flags );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_mulTransposed_excsafe( System.IntPtr src ,  System.IntPtr dst ,  System.Int32 aTa ,  System.IntPtr delta ,  System.Double scale ,  System.Int32 dtype );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_transpose_excsafe( System.IntPtr src ,  System.IntPtr dst );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_transform_excsafe( System.IntPtr src ,  System.IntPtr dst ,  System.IntPtr m );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_perspectiveTransform_excsafe( System.IntPtr src ,  System.IntPtr dst ,  System.IntPtr m );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_findNonZero_excsafe( System.IntPtr src ,  System.IntPtr idx );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_mean_excsafe(ref OpenCvSharp.Scalar ret,  System.IntPtr src ,  System.IntPtr mask );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_meanStdDev_OutputArray_excsafe( System.IntPtr src ,  System.IntPtr mean ,  System.IntPtr stddev ,  System.IntPtr mask );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_meanStdDev_Scalar_excsafe( System.IntPtr src ,  out OpenCvSharp.Scalar mean ,  out OpenCvSharp.Scalar stddev ,  System.IntPtr mask );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_norm1_excsafe(ref System.Double ret,  System.IntPtr src1 ,  System.Int32 normType ,  System.IntPtr mask );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_norm2_excsafe(ref System.Double ret,  System.IntPtr src1 ,  System.IntPtr src2 ,  System.Int32 normType ,  System.IntPtr mask );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_batchDistance_excsafe( System.IntPtr src1 ,  System.IntPtr src2 ,  System.IntPtr dist ,  System.Int32 dtype ,  System.IntPtr nidx ,  System.Int32 normType ,  System.Int32 k ,  System.IntPtr mask ,  System.Int32 update ,  System.Int32 crosscheck );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_normalize_excsafe( System.IntPtr src ,  System.IntPtr dst ,  System.Double alpha ,  System.Double beta ,  System.Int32 normType ,  System.Int32 dtype ,  System.IntPtr mask );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_minMaxLoc1_excsafe( System.IntPtr src ,  out System.Double minVal ,  out System.Double maxVal );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_minMaxLoc2_excsafe( System.IntPtr src ,  out System.Double minVal ,  out System.Double maxVal ,  out OpenCvSharp.Point minLoc ,  out OpenCvSharp.Point maxLoc ,  System.IntPtr mask );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_minMaxIdx1_excsafe( System.IntPtr src ,  out System.Double minVal ,  out System.Double maxVal );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_minMaxIdx2_excsafe( System.IntPtr src ,  out System.Double minVal ,  out System.Double maxVal , [MarshalAs(UnmanagedType.LPArray)] System.Int32[] minIdx , [MarshalAs(UnmanagedType.LPArray)] System.Int32[] maxIdx ,  System.IntPtr mask );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_reduce_excsafe( System.IntPtr src ,  System.IntPtr dst ,  System.Int32 dim ,  System.Int32 rtype ,  System.Int32 dtype );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_merge_excsafe([MarshalAs(UnmanagedType.LPArray)] System.IntPtr[] mv ,  System.UInt32 count ,  System.IntPtr dst );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_split_excsafe( System.IntPtr src ,  out System.IntPtr mv );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_mixChannels_excsafe( System.IntPtr[] src ,  System.UInt32 nsrcs ,  System.IntPtr[] dst ,  System.UInt32 ndsts ,  System.Int32[] fromTo ,  System.UInt32 npairs );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_extractChannel_excsafe( System.IntPtr src ,  System.IntPtr dst ,  System.Int32 coi );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_insertChannel_excsafe( System.IntPtr src ,  System.IntPtr dst ,  System.Int32 coi );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_flip_excsafe( System.IntPtr src ,  System.IntPtr dst ,  System.Int32 flipCode );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_repeat1_excsafe( System.IntPtr src ,  System.Int32 ny ,  System.Int32 nx ,  System.IntPtr dst );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_repeat2_excsafe(ref System.IntPtr ret,  System.IntPtr src ,  System.Int32 ny ,  System.Int32 nx );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_hconcat1_excsafe([MarshalAs(UnmanagedType.LPArray)] System.IntPtr[] src ,  System.UInt32 nsrc ,  System.IntPtr dst );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_hconcat2_excsafe( System.IntPtr src1 ,  System.IntPtr src2 ,  System.IntPtr dst );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_vconcat1_excsafe([MarshalAs(UnmanagedType.LPArray)] System.IntPtr[] src ,  System.UInt32 nsrc ,  System.IntPtr dst );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_vconcat2_excsafe( System.IntPtr src1 ,  System.IntPtr src2 ,  System.IntPtr dst );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_bitwise_and_excsafe( System.IntPtr src1 ,  System.IntPtr src2 ,  System.IntPtr dst ,  System.IntPtr mask );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_bitwise_or_excsafe( System.IntPtr src1 ,  System.IntPtr src2 ,  System.IntPtr dst ,  System.IntPtr mask );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_bitwise_xor_excsafe( System.IntPtr src1 ,  System.IntPtr src2 ,  System.IntPtr dst ,  System.IntPtr mask );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_getTickCount_excsafe(ref System.Int64 ret);

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_getTickFrequency_excsafe(ref System.Double ret);

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_getCPUTickCount_excsafe(ref System.Int64 ret);

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_checkHardwareSupport_excsafe(ref System.Int32 ret,  System.Int32 feature );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_getNumberOfCPUs_excsafe(ref System.Int32 ret);

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_fastMalloc_excsafe(ref System.IntPtr ret,  System.IntPtr bufSize );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_fastFree_excsafe( System.IntPtr ptr );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_setUseOptimized_excsafe( System.Int32 onoff );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_useOptimized_excsafe(ref System.Int32 ret);

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean redirectError_excsafe(ref System.IntPtr ret,  OpenCvSharp.CvErrorCallback errCallback ,  System.IntPtr userdata ,  ref System.IntPtr prevUserdata );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_cvarrToMat_excsafe(ref System.IntPtr ret,  System.IntPtr arr ,  System.Int32 copyData ,  System.Int32 allowND ,  System.Int32 coiMode );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_extractImageCOI_excsafe( System.IntPtr arr ,  System.IntPtr coiimg ,  System.Int32 coi );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_insertImageCOI_excsafe( System.IntPtr coiimg ,  System.IntPtr arr ,  System.Int32 coi );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_add_excsafe( System.IntPtr src1 ,  System.IntPtr src2 ,  System.IntPtr dst ,  System.IntPtr mask ,  System.Int32 dtype );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_subtract_InputArray2_excsafe( System.IntPtr src1 ,  System.IntPtr src2 ,  System.IntPtr dst ,  System.IntPtr mask ,  System.Int32 dtype );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_subtract_InputArrayScalar_excsafe( System.IntPtr src1 ,  OpenCvSharp.Scalar src2 ,  System.IntPtr dst ,  System.IntPtr mask ,  System.Int32 dtype );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_subtract_ScalarInputArray_excsafe( OpenCvSharp.Scalar src1 ,  System.IntPtr src2 ,  System.IntPtr dst ,  System.IntPtr mask ,  System.Int32 dtype );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_multiply_excsafe( System.IntPtr src1 ,  System.IntPtr src2 ,  System.IntPtr dst ,  System.Double scale ,  System.Int32 dtype );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_divide1_excsafe( System.Double scale ,  System.IntPtr src2 ,  System.IntPtr dst ,  System.Int32 dtype );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_divide2_excsafe( System.IntPtr src1 ,  System.IntPtr src2 ,  System.IntPtr dst ,  System.Double scale ,  System.Int32 dtype );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_scaleAdd_excsafe( System.IntPtr src1 ,  System.Double alpha ,  System.IntPtr src2 ,  System.IntPtr dst );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_addWeighted_excsafe( System.IntPtr src1 ,  System.Double alpha ,  System.IntPtr src2 ,  System.Double beta ,  System.Double gamma ,  System.IntPtr dst ,  System.Int32 dtype );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_borderInterpolate_excsafe(ref System.Int32 ret,  System.Int32 p ,  System.Int32 len ,  System.Int32 borderType );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_copyMakeBorder_excsafe( System.IntPtr src ,  System.IntPtr dst ,  System.Int32 top ,  System.Int32 bottom ,  System.Int32 left ,  System.Int32 right ,  System.Int32 borderType ,  OpenCvSharp.Scalar value );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_convertScaleAbs_excsafe( System.IntPtr src ,  System.IntPtr dst ,  System.Double alpha ,  System.Double beta );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_LUT_excsafe( System.IntPtr src ,  System.IntPtr lut ,  System.IntPtr dst );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_sum_excsafe(ref OpenCvSharp.Scalar ret,  System.IntPtr src );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_countNonZero_excsafe(ref System.Int32 ret,  System.IntPtr src );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean calib3d_StereoMatcher_getNumDisparities_excsafe(ref System.Int32 ret,  System.IntPtr obj );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean calib3d_StereoMatcher_setNumDisparities_excsafe( System.IntPtr obj ,  System.Int32 value );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean calib3d_StereoMatcher_getBlockSize_excsafe(ref System.Int32 ret,  System.IntPtr obj );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean calib3d_StereoMatcher_setBlockSize_excsafe( System.IntPtr obj ,  System.Int32 value );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean calib3d_StereoMatcher_getSpeckleWindowSize_excsafe(ref System.Int32 ret,  System.IntPtr obj );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean calib3d_StereoMatcher_setSpeckleWindowSize_excsafe( System.IntPtr obj ,  System.Int32 value );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean calib3d_StereoMatcher_getSpeckleRange_excsafe(ref System.Int32 ret,  System.IntPtr obj );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean calib3d_StereoMatcher_setSpeckleRange_excsafe( System.IntPtr obj ,  System.Int32 value );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean calib3d_StereoMatcher_getDisp12MaxDiff_excsafe(ref System.Int32 ret,  System.IntPtr obj );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean calib3d_StereoMatcher_setDisp12MaxDiff_excsafe( System.IntPtr obj ,  System.Int32 value );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean calib3d_Ptr_StereoSGBM_get_excsafe(ref System.IntPtr ret,  System.IntPtr obj );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean calib3d_Ptr_StereoSGBM_delete_excsafe( System.IntPtr obj );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean calib3d_StereoSGBM_create_excsafe(ref System.IntPtr ret,  System.Int32 minDisparity ,  System.Int32 numDisparities ,  System.Int32 blockSize ,  System.Int32 P1 ,  System.Int32 P2 ,  System.Int32 disp12MaxDiff ,  System.Int32 preFilterCap ,  System.Int32 uniquenessRatio ,  System.Int32 speckleWindowSize ,  System.Int32 speckleRange ,  System.Int32 mode );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean calib3d_StereoSGBM_getPreFilterCap_excsafe(ref System.Int32 ret,  System.IntPtr obj );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean calib3d_StereoSGBM_setPreFilterCap_excsafe( System.IntPtr obj ,  System.Int32 value );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean calib3d_StereoSGBM_getUniquenessRatio_excsafe(ref System.Int32 ret,  System.IntPtr obj );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean calib3d_StereoSGBM_setUniquenessRatio_excsafe( System.IntPtr obj ,  System.Int32 value );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean calib3d_StereoSGBM_getP1_excsafe(ref System.Int32 ret,  System.IntPtr obj );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean calib3d_StereoSGBM_setP1_excsafe( System.IntPtr obj ,  System.Int32 value );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean calib3d_StereoSGBM_getP2_excsafe(ref System.Int32 ret,  System.IntPtr obj );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean calib3d_StereoSGBM_setP2_excsafe( System.IntPtr obj ,  System.Int32 value );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean calib3d_StereoSGBM_getMode_excsafe(ref System.Int32 ret,  System.IntPtr obj );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean calib3d_StereoSGBM_setMode_excsafe( System.IntPtr obj ,  System.Int32 value );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_setNumThreads_excsafe( System.Int32 nthreads );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_getNumThreads_excsafe(ref System.Int32 ret);

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_getThreadNum_excsafe(ref System.Int32 ret);

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_getBuildInformation_excsafe([MarshalAs(UnmanagedType.LPStr)] System.Text.StringBuilder buf ,  System.Int32 maxLength );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean core_getBuildInformation_length_excsafe(ref System.Int32 ret);

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean calib3d_correctMatches_array_excsafe( System.Double[,] F ,  OpenCvSharp.Point2d[] points1 ,  System.Int32 points1Size ,  OpenCvSharp.Point2d[] points2 ,  System.Int32 points2Size ,  OpenCvSharp.Point2d[] newPoints1 ,  OpenCvSharp.Point2d[] newPoints2 );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean calib3d_filterSpeckles_excsafe( System.IntPtr img ,  System.Double newVal ,  System.Int32 maxSpeckleSize ,  System.Double maxDiff ,  System.IntPtr buf );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean calib3d_getValidDisparityROI_excsafe(ref OpenCvSharp.Rect ret,  OpenCvSharp.Rect roi1 ,  OpenCvSharp.Rect roi2 ,  System.Int32 minDisparity ,  System.Int32 numberOfDisparities ,  System.Int32 SADWindowSize );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean calib3d_validateDisparity_excsafe( System.IntPtr disparity ,  System.IntPtr cost ,  System.Int32 minDisparity ,  System.Int32 numberOfDisparities ,  System.Int32 disp12MaxDisp );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean calib3d_reprojectImageTo3D_excsafe( System.IntPtr disparity ,  System.IntPtr _3dImage ,  System.IntPtr Q ,  System.Int32 handleMissingValues ,  System.Int32 ddepth );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean calib3d_estimateAffine3D_excsafe(ref System.Int32 ret,  System.IntPtr src ,  System.IntPtr dst ,  System.IntPtr outVal ,  System.IntPtr inliers ,  System.Double ransacThreshold ,  System.Double confidence );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean calib3d_Ptr_StereoBM_delete_excsafe( System.IntPtr obj );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean calib3d_Ptr_StereoBM_get_excsafe(ref System.IntPtr ret,  System.IntPtr obj );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean calib3d_StereoBM_create_excsafe(ref System.IntPtr ret,  System.Int32 numDisparities ,  System.Int32 blockSize );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean calib3d_StereoBM_getPreFilterType_excsafe(ref System.Int32 ret,  System.IntPtr obj );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean calib3d_StereoBM_setPreFilterType_excsafe( System.IntPtr obj ,  System.Int32 value );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean calib3d_StereoBM_getPreFilterSize_excsafe(ref System.Int32 ret,  System.IntPtr obj );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean calib3d_StereoBM_setPreFilterSize_excsafe( System.IntPtr obj ,  System.Int32 value );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean calib3d_StereoBM_getPreFilterCap_excsafe(ref System.Int32 ret,  System.IntPtr obj );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean calib3d_StereoBM_setPreFilterCap_excsafe( System.IntPtr obj ,  System.Int32 value );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean calib3d_StereoBM_getTextureThreshold_excsafe(ref System.Int32 ret,  System.IntPtr obj );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean calib3d_StereoBM_setTextureThreshold_excsafe( System.IntPtr obj ,  System.Int32 value );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean calib3d_StereoBM_getUniquenessRatio_excsafe(ref System.Int32 ret,  System.IntPtr obj );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean calib3d_StereoBM_setUniquenessRatio_excsafe( System.IntPtr obj ,  System.Int32 value );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean calib3d_StereoBM_getSmallerBlockSize_excsafe(ref System.Int32 ret,  System.IntPtr obj );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean calib3d_StereoBM_setSmallerBlockSize_excsafe( System.IntPtr obj ,  System.Int32 value );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean calib3d_StereoBM_getROI1_excsafe(ref OpenCvSharp.Rect ret,  System.IntPtr obj );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean calib3d_StereoBM_setROI1_excsafe( System.IntPtr obj ,  OpenCvSharp.Rect value );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean calib3d_StereoBM_getROI2_excsafe(ref OpenCvSharp.Rect ret,  System.IntPtr obj );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean calib3d_StereoBM_setROI2_excsafe( System.IntPtr obj ,  OpenCvSharp.Rect value );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean calib3d_StereoMatcher_compute_excsafe( System.IntPtr obj ,  System.IntPtr left ,  System.IntPtr right ,  System.IntPtr disparity );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean calib3d_StereoMatcher_getMinDisparity_excsafe(ref System.Int32 ret,  System.IntPtr obj );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean calib3d_StereoMatcher_setMinDisparity_excsafe( System.IntPtr obj ,  System.Int32 value );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean calib3d_calibrateCamera_InputArray_excsafe(ref System.Double ret,  System.IntPtr[] objectPoints ,  System.Int32 objectPointsSize ,  System.IntPtr[] imagePoints ,  System.Int32 imagePointsSize ,  OpenCvSharp.Size imageSize ,  System.IntPtr cameraMatrix ,  System.IntPtr distCoeffs ,  System.IntPtr rvecs ,  System.IntPtr tvecs ,  System.Int32 flags ,  OpenCvSharp.TermCriteria criteria );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean calib3d_calibrateCamera_vector_excsafe(ref System.Double ret,  System.IntPtr[] objectPoints ,  System.Int32 opSize1 ,  System.Int32[] opSize2 ,  System.IntPtr[] imagePoints ,  System.Int32 ipSize1 ,  System.Int32[] ipSize2 ,  OpenCvSharp.Size imageSize , [In, Out] System.Double[,] cameraMatrix , [In, Out] System.Double[] distCoeffs ,  System.Int32 distCoeffsSize ,  System.IntPtr rvecs ,  System.IntPtr tvecs ,  System.Int32 flags ,  OpenCvSharp.TermCriteria criteria );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean calib3d_calibrationMatrixValues_InputArray_excsafe( System.IntPtr cameraMatrix ,  OpenCvSharp.Size imageSize ,  System.Double apertureWidth ,  System.Double apertureHeight ,  out System.Double fovx ,  out System.Double fovy ,  out System.Double focalLength ,  out OpenCvSharp.Point2d principalPoint ,  out System.Double aspectRatio );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean calib3d_calibrationMatrixValues_array_excsafe( System.Double[,] cameraMatrix ,  OpenCvSharp.Size imageSize ,  System.Double apertureWidth ,  System.Double apertureHeight ,  out System.Double fovx ,  out System.Double fovy ,  out System.Double focalLength ,  out OpenCvSharp.Point2d principalPoint ,  out System.Double aspectRatio );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean calib3d_stereoCalibrate_InputArray_excsafe(ref System.Double ret,  System.IntPtr[] objectPoints ,  System.Int32 opSize ,  System.IntPtr[] imagePoints1 ,  System.Int32 ip1Size ,  System.IntPtr[] imagePoints2 ,  System.Int32 ip2Size ,  System.IntPtr cameraMatrix1 ,  System.IntPtr distCoeffs1 ,  System.IntPtr cameraMatrix2 ,  System.IntPtr distCoeffs2 ,  OpenCvSharp.Size imageSize ,  System.IntPtr R ,  System.IntPtr T ,  System.IntPtr E ,  System.IntPtr F ,  System.Int32 flags ,  OpenCvSharp.TermCriteria criteria );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean calib3d_stereoCalibrate_array_excsafe(ref System.Double ret,  System.IntPtr[] objectPoints ,  System.Int32 opSize1 ,  System.Int32[] opSizes2 ,  System.IntPtr[] imagePoints1 ,  System.Int32 ip1Size1 ,  System.Int32[] ip1Sizes2 ,  System.IntPtr[] imagePoints2 ,  System.Int32 ip2Size1 ,  System.Int32[] ip2Sizes2 , [In, Out] System.Double[,] cameraMatrix1 , [In, Out] System.Double[] distCoeffs1 ,  System.Int32 dc1Size , [In, Out] System.Double[,] cameraMatrix2 , [In, Out] System.Double[] distCoeffs2 ,  System.Int32 dc2Size ,  OpenCvSharp.Size imageSize ,  System.IntPtr R ,  System.IntPtr T ,  System.IntPtr E ,  System.IntPtr F ,  System.Int32 flags ,  OpenCvSharp.TermCriteria criteria );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean calib3d_stereoRectify_InputArray_excsafe( System.IntPtr cameraMatrix1 ,  System.IntPtr distCoeffs1 ,  System.IntPtr cameraMatrix2 ,  System.IntPtr distCoeffs2 ,  OpenCvSharp.Size imageSize ,  System.IntPtr R ,  System.IntPtr T ,  System.IntPtr R1 ,  System.IntPtr R2 ,  System.IntPtr P1 ,  System.IntPtr P2 ,  System.IntPtr Q ,  System.Int32 flags ,  System.Double alpha ,  OpenCvSharp.Size newImageSize ,  out OpenCvSharp.Rect validPixROI1 ,  out OpenCvSharp.Rect validPixROI2 );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean calib3d_stereoRectify_array_excsafe( System.Double[,] cameraMatrix1 ,  System.Double[] distCoeffs1 ,  System.Int32 dc1Size ,  System.Double[,] cameraMatrix2 ,  System.Double[] distCoeffs2 ,  System.Int32 dc2Size ,  OpenCvSharp.Size imageSize ,  System.Double[,] R ,  System.Double[] T ,  System.Double[,] R1 ,  System.Double[,] R2 ,  System.Double[,] P1 ,  System.Double[,] P2 ,  System.Double[,] Q ,  System.Int32 flags ,  System.Double alpha ,  OpenCvSharp.Size newImageSize ,  out OpenCvSharp.Rect validPixROI1 ,  out OpenCvSharp.Rect validPixROI2 );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean calib3d_stereoRectifyUncalibrated_InputArray_excsafe(ref System.Int32 ret,  System.IntPtr points1 ,  System.IntPtr points2 ,  System.IntPtr F ,  OpenCvSharp.Size imgSize ,  System.IntPtr H1 ,  System.IntPtr H2 ,  System.Double threshold );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean calib3d_stereoRectifyUncalibrated_array_excsafe(ref System.Int32 ret,  OpenCvSharp.Point2d[] points1 ,  System.Int32 points1Size ,  OpenCvSharp.Point2d[] points2 ,  System.Int32 points2Size , [In] System.Double[,] F ,  OpenCvSharp.Size imgSize , [In, Out] System.Double[,] H1 , [In, Out] System.Double[,] H2 ,  System.Double threshold );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean calib3d_rectify3Collinear_InputArray_excsafe(ref System.Single ret,  System.IntPtr cameraMatrix1 ,  System.IntPtr distCoeffs1 ,  System.IntPtr cameraMatrix2 ,  System.IntPtr distCoeffs2 ,  System.IntPtr cameraMatrix3 ,  System.IntPtr distCoeffs3 ,  System.IntPtr[] imgpt1 ,  System.Int32 imgpt1Size ,  System.IntPtr[] imgpt3 ,  System.Int32 imgpt3Size ,  OpenCvSharp.Size imageSize ,  System.IntPtr R12 ,  System.IntPtr T12 ,  System.IntPtr R13 ,  System.IntPtr T13 ,  System.IntPtr R1 ,  System.IntPtr R2 ,  System.IntPtr R3 ,  System.IntPtr P1 ,  System.IntPtr P2 ,  System.IntPtr P3 ,  System.IntPtr Q ,  System.Double alpha ,  OpenCvSharp.Size newImgSize ,  out OpenCvSharp.Rect roi1 ,  out OpenCvSharp.Rect roi2 ,  System.Int32 flags );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean calib3d_getOptimalNewCameraMatrix_InputArray_excsafe(ref System.IntPtr ret,  System.IntPtr cameraMatrix ,  System.IntPtr distCoeffs ,  OpenCvSharp.Size imageSize ,  System.Double alpha ,  OpenCvSharp.Size newImgSize ,  out OpenCvSharp.Rect validPixROI ,  System.Int32 centerPrincipalPoint );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean calib3d_getOptimalNewCameraMatrix_array_excsafe([In] System.Double[,] cameraMatrix , [In] System.Double[] distCoeffs ,  System.Int32 distCoeffsSize ,  OpenCvSharp.Size imageSize ,  System.Double alpha ,  OpenCvSharp.Size newImgSize ,  out OpenCvSharp.Rect validPixROI ,  System.Int32 centerPrincipalPoint , [In, Out] System.Double[,] outValues );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean calib3d_convertPointsToHomogeneous_InputArray_excsafe( System.IntPtr src ,  System.IntPtr dst );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean calib3d_convertPointsToHomogeneous_array1_excsafe([In] OpenCvSharp.Vec2f[] src , [In, Out] OpenCvSharp.Vec3f[] dst ,  System.Int32 length );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean calib3d_convertPointsToHomogeneous_array2_excsafe([In] OpenCvSharp.Vec3f[] src , [In, Out] OpenCvSharp.Vec4f[] dst ,  System.Int32 length );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean calib3d_convertPointsFromHomogeneous_InputArray_excsafe( System.IntPtr src ,  System.IntPtr dst );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean calib3d_convertPointsFromHomogeneous_array1_excsafe([In] OpenCvSharp.Vec3f[] src , [In, Out] OpenCvSharp.Vec2f[] dst ,  System.Int32 length );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean calib3d_convertPointsFromHomogeneous_array2_excsafe([In] OpenCvSharp.Vec4f[] src , [In, Out] OpenCvSharp.Vec3f[] dst ,  System.Int32 length );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean calib3d_convertPointsHomogeneous_excsafe( System.IntPtr src ,  System.IntPtr dst );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean calib3d_findFundamentalMat_InputArray_excsafe(ref System.IntPtr ret,  System.IntPtr points1 ,  System.IntPtr points2 ,  System.Int32 method ,  System.Double param1 ,  System.Double param2 ,  System.IntPtr mask );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean calib3d_findFundamentalMat_array_excsafe(ref System.IntPtr ret,  OpenCvSharp.Point2d[] points1 ,  System.Int32 points1Size ,  OpenCvSharp.Point2d[] points2 ,  System.Int32 points2Size ,  System.Int32 method ,  System.Double param1 ,  System.Double param2 ,  System.IntPtr mask );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean calib3d_computeCorrespondEpilines_InputArray_excsafe( System.IntPtr points ,  System.Int32 whichImage ,  System.IntPtr F ,  System.IntPtr lines );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean calib3d_computeCorrespondEpilines_array2d_excsafe([In] OpenCvSharp.Point2d[] points ,  System.Int32 pointsSize ,  System.Int32 whichImage ,  System.Double[,] F , [In, Out] OpenCvSharp.Point3f[] lines );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean calib3d_computeCorrespondEpilines_array3d_excsafe([In] OpenCvSharp.Point3d[] points ,  System.Int32 pointsSize ,  System.Int32 whichImage ,  System.Double[,] F , [In, Out] OpenCvSharp.Point3f[] lines );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean calib3d_triangulatePoints_InputArray_excsafe( System.IntPtr projMatr1 ,  System.IntPtr projMatr2 ,  System.IntPtr projPoints1 ,  System.IntPtr projPoints2 ,  System.IntPtr points4D );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean calib3d_triangulatePoints_array_excsafe([In] System.Double[,] projMatr1 , [In] System.Double[,] projMatr2 , [In] OpenCvSharp.Point2d[] projPoints1 ,  System.Int32 projPoints1Size , [In] OpenCvSharp.Point2d[] projPoints2 ,  System.Int32 projPoints2Size , [In, Out] OpenCvSharp.Vec4d[] points4D );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean calib3d_correctMatches_InputArray_excsafe( System.IntPtr F ,  System.IntPtr points1 ,  System.IntPtr points2 ,  System.IntPtr newPoints1 ,  System.IntPtr newPoints2 );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean calib3d_Rodrigues_excsafe( System.IntPtr src ,  System.IntPtr dst ,  System.IntPtr jacobian );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean calib3d_Rodrigues_VecToMat_excsafe( System.IntPtr vector ,  System.IntPtr matrix ,  System.IntPtr jacobian );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean calib3d_Rodrigues_MatToVec_excsafe( System.IntPtr vector ,  System.IntPtr matrix ,  System.IntPtr jacobian );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean calib3d_findHomography_InputArray_excsafe(ref System.IntPtr ret,  System.IntPtr srcPoints ,  System.IntPtr dstPoints ,  System.Int32 method ,  System.Double ransacReprojThreshold ,  System.IntPtr mask );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean calib3d_findHomography_vector_excsafe(ref System.IntPtr ret,  OpenCvSharp.Point2d[] srcPoints ,  System.Int32 srcPointsLength ,  OpenCvSharp.Point2d[] dstPoints ,  System.Int32 dstPointsLength ,  System.Int32 method ,  System.Double ransacReprojThreshold ,  System.IntPtr mask );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean calib3d_RQDecomp3x3_InputArray_excsafe( System.IntPtr src ,  System.IntPtr mtxR ,  System.IntPtr mtxQ ,  System.IntPtr qx ,  System.IntPtr qy ,  System.IntPtr qz ,  out OpenCvSharp.Vec3d outVal );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean calib3d_RQDecomp3x3_Mat_excsafe( System.IntPtr src ,  System.IntPtr mtxR ,  System.IntPtr mtxQ ,  System.IntPtr qx ,  System.IntPtr qy ,  System.IntPtr qz ,  out OpenCvSharp.Vec3d outVal );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean calib3d_decomposeProjectionMatrix_InputArray_excsafe( System.IntPtr projMatrix ,  System.IntPtr cameraMatrix ,  System.IntPtr rotMatrix ,  System.IntPtr transVect ,  System.IntPtr rotMatrixX ,  System.IntPtr rotMatrixY ,  System.IntPtr rotMatrixZ ,  System.IntPtr eulerAngles );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean calib3d_decomposeProjectionMatrix_Mat_excsafe( System.IntPtr projMatrix ,  System.IntPtr cameraMatrix ,  System.IntPtr rotMatrix ,  System.IntPtr transVect ,  System.IntPtr rotMatrixX ,  System.IntPtr rotMatrixY ,  System.IntPtr rotMatrixZ ,  System.IntPtr eulerAngles );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean calib3d_matMulDeriv_excsafe( System.IntPtr a ,  System.IntPtr b ,  System.IntPtr dABdA ,  System.IntPtr dABdB );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean calib3d_composeRT_InputArray_excsafe( System.IntPtr rvec1 ,  System.IntPtr tvec1 ,  System.IntPtr rvec2 ,  System.IntPtr tvec2 ,  System.IntPtr rvec3 ,  System.IntPtr tvec3 ,  System.IntPtr dr3dr1 ,  System.IntPtr dr3dt1 ,  System.IntPtr dr3dr2 ,  System.IntPtr dr3dt2 ,  System.IntPtr dt3dr1 ,  System.IntPtr dt3dt1 ,  System.IntPtr dt3dr2 ,  System.IntPtr dt3dt2 );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean calib3d_composeRT_Mat_excsafe( System.IntPtr rvec1 ,  System.IntPtr tvec1 ,  System.IntPtr rvec2 ,  System.IntPtr tvec2 ,  System.IntPtr rvec3 ,  System.IntPtr tvec3 ,  System.IntPtr dr3dr1 ,  System.IntPtr dr3dt1 ,  System.IntPtr dr3dr2 ,  System.IntPtr dr3dt2 ,  System.IntPtr dt3dr1 ,  System.IntPtr dt3dt1 ,  System.IntPtr dt3dr2 ,  System.IntPtr dt3dt2 );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean calib3d_projectPoints_InputArray_excsafe( System.IntPtr objectPoints ,  System.IntPtr rvec ,  System.IntPtr tvec ,  System.IntPtr cameraMatrix ,  System.IntPtr distCoeffs ,  System.IntPtr imagePoints ,  System.IntPtr jacobian ,  System.Double aspectRatio );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean calib3d_projectPoints_Mat_excsafe( System.IntPtr objectPoints ,  System.IntPtr rvec ,  System.IntPtr tvec ,  System.IntPtr cameraMatrix ,  System.IntPtr distCoeffs ,  System.IntPtr imagePoints ,  System.IntPtr jacobian ,  System.Double aspectRatio );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean calib3d_solvePnP_InputArray_excsafe( System.IntPtr selfectPoints ,  System.IntPtr imagePoints ,  System.IntPtr cameraMatrix ,  System.IntPtr distCoeffs ,  System.IntPtr rvec ,  System.IntPtr tvec ,  System.Int32 useExtrinsicGuess ,  System.Int32 flags );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean calib3d_solvePnP_vector_excsafe( OpenCvSharp.Point3f[] objectPoints ,  System.Int32 objectPointsLength ,  OpenCvSharp.Point2f[] imagePoints ,  System.Int32 imagePointsLength ,  System.Double[,] cameraMatrix ,  System.Double[] distCoeffs ,  System.Int32 distCoeffsLength , [Out] System.Double[] rvec , [Out] System.Double[] tvec ,  System.Int32 useExtrinsicGuess ,  System.Int32 flags );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean calib3d_solvePnPRansac_InputArray_excsafe( System.IntPtr objectPoints ,  System.IntPtr imagePoints ,  System.IntPtr cameraMatrix ,  System.IntPtr distCoeffs ,  System.IntPtr rvec ,  System.IntPtr tvec ,  System.Int32 useExtrinsicGuess ,  System.Int32 iterationsCount ,  System.Single reprojectionError ,  System.Double confidence ,  System.IntPtr inliers ,  System.Int32 flags );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean calib3d_solvePnPRansac_vector_excsafe( OpenCvSharp.Point3f[] objectPoints ,  System.Int32 objectPointsLength ,  OpenCvSharp.Point2f[] imagePoints ,  System.Int32 imagePointsLength ,  System.Double[,] cameraMatrix ,  System.Double[] distCoeffs ,  System.Int32 distCoeffsLength , [Out] System.Double[] rvec , [Out] System.Double[] tvec ,  System.Int32 useExtrinsicGuess ,  System.Int32 iterationsCount ,  System.Single reprojectionError ,  System.Double confidence ,  System.IntPtr inliers ,  System.Int32 flags );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean calib3d_initCameraMatrix2D_Mat_excsafe(ref System.IntPtr ret,  System.IntPtr[] objectPoints ,  System.Int32 objectPointsLength ,  System.IntPtr[] imagePoints ,  System.Int32 imagePointsLength ,  OpenCvSharp.Size imageSize ,  System.Double aspectRatio );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean calib3d_initCameraMatrix2D_array_excsafe(ref System.IntPtr ret,  System.IntPtr[] objectPoints ,  System.Int32 opSize1 ,  System.Int32[] opSize2 ,  System.IntPtr[] imagePoints ,  System.Int32 ipSize1 ,  System.Int32[] ipSize2 ,  OpenCvSharp.Size imageSize ,  System.Double aspectRatio );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean calib3d_findChessboardCorners_InputArray_excsafe(ref System.Int32 ret,  System.IntPtr image ,  OpenCvSharp.Size patternSize ,  System.IntPtr corners ,  System.Int32 flags );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean calib3d_findChessboardCorners_vector_excsafe(ref System.Int32 ret,  System.IntPtr image ,  OpenCvSharp.Size patternSize ,  System.IntPtr corners ,  System.Int32 flags );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean calib3d_find4QuadCornerSubpix_InputArray_excsafe(ref System.Int32 ret,  System.IntPtr img ,  System.IntPtr corners ,  OpenCvSharp.Size regionSize );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean calib3d_find4QuadCornerSubpix_vector_excsafe(ref System.Int32 ret,  System.IntPtr img ,  System.IntPtr corners ,  OpenCvSharp.Size regionSize );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean calib3d_drawChessboardCorners_InputArray_excsafe( System.IntPtr image ,  OpenCvSharp.Size patternSize ,  System.IntPtr corners ,  System.Int32 patternWasFound );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean calib3d_drawChessboardCorners_array_excsafe( System.IntPtr image ,  OpenCvSharp.Size patternSize ,  OpenCvSharp.Point2f[] corners ,  System.Int32 cornersLength ,  System.Int32 patternWasFound );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean calib3d_findCirclesGrid_InputArray_excsafe(ref System.Int32 ret,  System.IntPtr image ,  OpenCvSharp.Size patternSize ,  System.IntPtr centers ,  System.Int32 flags ,  System.IntPtr blobDetector );

[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
public static extern System.Boolean calib3d_findCirclesGrid_vector_excsafe(ref System.Int32 ret,  System.IntPtr image ,  OpenCvSharp.Size patternSize ,  System.IntPtr centers ,  System.Int32 flags ,  System.IntPtr blobDetector );


}
}