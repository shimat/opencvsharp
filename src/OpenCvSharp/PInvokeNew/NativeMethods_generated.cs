using System;
using System.Runtime.InteropServices;

#pragma warning disable 1591

namespace OpenCvSharp
{
    static partial class NativeMethods
    {
public static  void ximgproc_StructuredEdgeDetection_computeOrientation( System.IntPtr obj ,  System.IntPtr src ,  System.IntPtr dst )
{
	bool isExc = NativeMethodsExc.ximgproc_StructuredEdgeDetection_computeOrientation_excsafe(obj, src, dst);

	if(isExc)
		handleException();
}


public static  void ximgproc_StructuredEdgeDetection_edgesNms( System.IntPtr obj ,  System.IntPtr edge_image ,  System.IntPtr orientation_image ,  System.IntPtr dst ,  System.Int32 r ,  System.Int32 s ,  System.Single m ,  System.Int32 isParallel )
{
	bool isExc = NativeMethodsExc.ximgproc_StructuredEdgeDetection_edgesNms_excsafe(obj, edge_image, orientation_image, dst, r, s, m, isParallel);

	if(isExc)
		handleException();
}


public static  System.IntPtr ximgproc_segmentation_createSelectiveSearchSegmentationStrategyMultiple1( System.IntPtr s1 )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.ximgproc_segmentation_createSelectiveSearchSegmentationStrategyMultiple1_excsafe(ref ret, s1);

	if(isExc)
		handleException();
	return ret;
}


public static  System.IntPtr ximgproc_segmentation_createSelectiveSearchSegmentationStrategyMultiple2( System.IntPtr s1 ,  System.IntPtr s2 )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.ximgproc_segmentation_createSelectiveSearchSegmentationStrategyMultiple2_excsafe(ref ret, s1, s2);

	if(isExc)
		handleException();
	return ret;
}


public static  System.IntPtr ximgproc_segmentation_createSelectiveSearchSegmentationStrategyMultiple3( System.IntPtr s1 ,  System.IntPtr s2 ,  System.IntPtr s3 )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.ximgproc_segmentation_createSelectiveSearchSegmentationStrategyMultiple3_excsafe(ref ret, s1, s2, s3);

	if(isExc)
		handleException();
	return ret;
}


public static  System.IntPtr ximgproc_segmentation_createSelectiveSearchSegmentationStrategyMultiple4( System.IntPtr s1 ,  System.IntPtr s2 ,  System.IntPtr s3 ,  System.IntPtr s4 )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.ximgproc_segmentation_createSelectiveSearchSegmentationStrategyMultiple4_excsafe(ref ret, s1, s2, s3, s4);

	if(isExc)
		handleException();
	return ret;
}


public static  void ximgproc_segmentation_Ptr_SelectiveSearchSegmentationStrategyMultiple_delete( System.IntPtr obj )
{
	bool isExc = NativeMethodsExc.ximgproc_segmentation_Ptr_SelectiveSearchSegmentationStrategyMultiple_delete_excsafe(obj);

	if(isExc)
		handleException();
}


public static  System.IntPtr ximgproc_segmentation_Ptr_SelectiveSearchSegmentationStrategyMultiple_get( System.IntPtr ptr )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.ximgproc_segmentation_Ptr_SelectiveSearchSegmentationStrategyMultiple_get_excsafe(ref ret, ptr);

	if(isExc)
		handleException();
	return ret;
}


public static  void ximgproc_segmentation_SelectiveSearchSegmentation_setBaseImage( System.IntPtr obj ,  System.IntPtr img )
{
	bool isExc = NativeMethodsExc.ximgproc_segmentation_SelectiveSearchSegmentation_setBaseImage_excsafe(obj, img);

	if(isExc)
		handleException();
}


public static  void ximgproc_segmentation_SelectiveSearchSegmentation_switchToSingleStrategy( System.IntPtr obj ,  System.Int32 k ,  System.Single sigma )
{
	bool isExc = NativeMethodsExc.ximgproc_segmentation_SelectiveSearchSegmentation_switchToSingleStrategy_excsafe(obj, k, sigma);

	if(isExc)
		handleException();
}


public static  void ximgproc_segmentation_SelectiveSearchSegmentation_switchToSelectiveSearchFast( System.IntPtr obj ,  System.Int32 base_k ,  System.Int32 inc_k ,  System.Single sigma )
{
	bool isExc = NativeMethodsExc.ximgproc_segmentation_SelectiveSearchSegmentation_switchToSelectiveSearchFast_excsafe(obj, base_k, inc_k, sigma);

	if(isExc)
		handleException();
}


public static  void ximgproc_segmentation_SelectiveSearchSegmentation_switchToSelectiveSearchQuality( System.IntPtr obj ,  System.Int32 base_k ,  System.Int32 inc_k ,  System.Single sigma )
{
	bool isExc = NativeMethodsExc.ximgproc_segmentation_SelectiveSearchSegmentation_switchToSelectiveSearchQuality_excsafe(obj, base_k, inc_k, sigma);

	if(isExc)
		handleException();
}


public static  void ximgproc_segmentation_SelectiveSearchSegmentation_addImage( System.IntPtr obj ,  System.IntPtr img )
{
	bool isExc = NativeMethodsExc.ximgproc_segmentation_SelectiveSearchSegmentation_addImage_excsafe(obj, img);

	if(isExc)
		handleException();
}


public static  void ximgproc_segmentation_SelectiveSearchSegmentation_clearImages( System.IntPtr obj )
{
	bool isExc = NativeMethodsExc.ximgproc_segmentation_SelectiveSearchSegmentation_clearImages_excsafe(obj);

	if(isExc)
		handleException();
}


public static  void ximgproc_segmentation_SelectiveSearchSegmentation_addGraphSegmentation( System.IntPtr obj ,  System.IntPtr g )
{
	bool isExc = NativeMethodsExc.ximgproc_segmentation_SelectiveSearchSegmentation_addGraphSegmentation_excsafe(obj, g);

	if(isExc)
		handleException();
}


public static  void ximgproc_segmentation_SelectiveSearchSegmentation_clearGraphSegmentations( System.IntPtr obj )
{
	bool isExc = NativeMethodsExc.ximgproc_segmentation_SelectiveSearchSegmentation_clearGraphSegmentations_excsafe(obj);

	if(isExc)
		handleException();
}


public static  void ximgproc_segmentation_SelectiveSearchSegmentation_addStrategy( System.IntPtr obj ,  System.IntPtr s )
{
	bool isExc = NativeMethodsExc.ximgproc_segmentation_SelectiveSearchSegmentation_addStrategy_excsafe(obj, s);

	if(isExc)
		handleException();
}


public static  void ximgproc_segmentation_SelectiveSearchSegmentation_clearStrategies( System.IntPtr obj )
{
	bool isExc = NativeMethodsExc.ximgproc_segmentation_SelectiveSearchSegmentation_clearStrategies_excsafe(obj);

	if(isExc)
		handleException();
}


public static  void ximgproc_segmentation_SelectiveSearchSegmentation_process( System.IntPtr obj ,  System.IntPtr rects )
{
	bool isExc = NativeMethodsExc.ximgproc_segmentation_SelectiveSearchSegmentation_process_excsafe(obj, rects);

	if(isExc)
		handleException();
}


public static  System.IntPtr ximgproc_segmentation_createSelectiveSearchSegmentation()
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.ximgproc_segmentation_createSelectiveSearchSegmentation_excsafe(ref ret);

	if(isExc)
		handleException();
	return ret;
}


public static  void ximgproc_segmentation_Ptr_SelectiveSearchSegmentation_delete( System.IntPtr obj )
{
	bool isExc = NativeMethodsExc.ximgproc_segmentation_Ptr_SelectiveSearchSegmentation_delete_excsafe(obj);

	if(isExc)
		handleException();
}


public static  System.IntPtr ximgproc_segmentation_Ptr_SelectiveSearchSegmentation_get( System.IntPtr ptr )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.ximgproc_segmentation_Ptr_SelectiveSearchSegmentation_get_excsafe(ref ret, ptr);

	if(isExc)
		handleException();
	return ret;
}


public static  System.IntPtr ximgproc_createRFFeatureGetter()
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.ximgproc_createRFFeatureGetter_excsafe(ref ret);

	if(isExc)
		handleException();
	return ret;
}


public static  void ximgproc_Ptr_RFFeatureGetter_delete( System.IntPtr obj )
{
	bool isExc = NativeMethodsExc.ximgproc_Ptr_RFFeatureGetter_delete_excsafe(obj);

	if(isExc)
		handleException();
}


public static  System.IntPtr ximgproc_Ptr_RFFeatureGetter_get( System.IntPtr ptr )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.ximgproc_Ptr_RFFeatureGetter_get_excsafe(ref ret, ptr);

	if(isExc)
		handleException();
	return ret;
}


public static  void ximgproc_RFFeatureGetter_getFeatures( System.IntPtr obj ,  System.IntPtr src ,  System.IntPtr features ,  System.Int32 gnrmRad ,  System.Int32 gsmthRad ,  System.Int32 shrink ,  System.Int32 outNum ,  System.Int32 gradNum )
{
	bool isExc = NativeMethodsExc.ximgproc_RFFeatureGetter_getFeatures_excsafe(obj, src, features, gnrmRad, gsmthRad, shrink, outNum, gradNum);

	if(isExc)
		handleException();
}


public static  System.IntPtr ximgproc_createStructuredEdgeDetection([MarshalAs(UnmanagedType.LPStr)] System.String model ,  System.IntPtr howToGetFeatures )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.ximgproc_createStructuredEdgeDetection_excsafe(ref ret, model, howToGetFeatures);

	if(isExc)
		handleException();
	return ret;
}


public static  void ximgproc_Ptr_StructuredEdgeDetection_delete( System.IntPtr obj )
{
	bool isExc = NativeMethodsExc.ximgproc_Ptr_StructuredEdgeDetection_delete_excsafe(obj);

	if(isExc)
		handleException();
}


public static  System.IntPtr ximgproc_Ptr_StructuredEdgeDetection_get( System.IntPtr ptr )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.ximgproc_Ptr_StructuredEdgeDetection_get_excsafe(ref ret, ptr);

	if(isExc)
		handleException();
	return ret;
}


public static  void ximgproc_StructuredEdgeDetection_detectEdges( System.IntPtr obj ,  System.IntPtr src ,  System.IntPtr dst )
{
	bool isExc = NativeMethodsExc.ximgproc_StructuredEdgeDetection_detectEdges_excsafe(obj, src, dst);

	if(isExc)
		handleException();
}


public static  System.IntPtr ximgproc_segmentation_createGraphSegmentation( System.Double sigma ,  System.Single k ,  System.Int32 min_size )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.ximgproc_segmentation_createGraphSegmentation_excsafe(ref ret, sigma, k, min_size);

	if(isExc)
		handleException();
	return ret;
}


public static  void ximgproc_segmentation_Ptr_GraphSegmentation_delete( System.IntPtr obj )
{
	bool isExc = NativeMethodsExc.ximgproc_segmentation_Ptr_GraphSegmentation_delete_excsafe(obj);

	if(isExc)
		handleException();
}


public static  System.IntPtr ximgproc_segmentation_Ptr_GraphSegmentation_get( System.IntPtr ptr )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.ximgproc_segmentation_Ptr_GraphSegmentation_get_excsafe(ref ret, ptr);

	if(isExc)
		handleException();
	return ret;
}


public static  void ximgproc_segmentation_GraphSegmentation_processImage( System.IntPtr obj ,  System.IntPtr src ,  System.IntPtr dst )
{
	bool isExc = NativeMethodsExc.ximgproc_segmentation_GraphSegmentation_processImage_excsafe(obj, src, dst);

	if(isExc)
		handleException();
}


public static  void ximgproc_segmentation_GraphSegmentation_setSigma( System.IntPtr obj ,  System.Double value )
{
	bool isExc = NativeMethodsExc.ximgproc_segmentation_GraphSegmentation_setSigma_excsafe(obj, value);

	if(isExc)
		handleException();
}


public static  System.Double ximgproc_segmentation_GraphSegmentation_getSigma( System.IntPtr obj )
{
	System.Double ret = new System.Double();
	bool isExc = NativeMethodsExc.ximgproc_segmentation_GraphSegmentation_getSigma_excsafe(ref ret, obj);

	if(isExc)
		handleException();
	return ret;
}


public static  void ximgproc_segmentation_GraphSegmentation_setK( System.IntPtr obj ,  System.Single value )
{
	bool isExc = NativeMethodsExc.ximgproc_segmentation_GraphSegmentation_setK_excsafe(obj, value);

	if(isExc)
		handleException();
}


public static  System.Single ximgproc_segmentation_GraphSegmentation_getK( System.IntPtr obj )
{
	System.Single ret = new System.Single();
	bool isExc = NativeMethodsExc.ximgproc_segmentation_GraphSegmentation_getK_excsafe(ref ret, obj);

	if(isExc)
		handleException();
	return ret;
}


public static  void ximgproc_segmentation_GraphSegmentation_setMinSize( System.IntPtr obj ,  System.Int32 value )
{
	bool isExc = NativeMethodsExc.ximgproc_segmentation_GraphSegmentation_setMinSize_excsafe(obj, value);

	if(isExc)
		handleException();
}


public static  System.Int32 ximgproc_segmentation_GraphSegmentation_getMinSize( System.IntPtr obj )
{
	System.Int32 ret = new System.Int32();
	bool isExc = NativeMethodsExc.ximgproc_segmentation_GraphSegmentation_getMinSize_excsafe(ref ret, obj);

	if(isExc)
		handleException();
	return ret;
}


public static  void ximgproc_segmentation_SelectiveSearchSegmentationStrategy_setImage( System.IntPtr obj ,  System.IntPtr img ,  System.IntPtr regions ,  System.IntPtr sizes ,  System.Int32 image_id )
{
	bool isExc = NativeMethodsExc.ximgproc_segmentation_SelectiveSearchSegmentationStrategy_setImage_excsafe(obj, img, regions, sizes, image_id);

	if(isExc)
		handleException();
}


public static  System.Single ximgproc_segmentation_SelectiveSearchSegmentationStrategy_get( System.IntPtr obj ,  System.Int32 r1 ,  System.Int32 r2 )
{
	System.Single ret = new System.Single();
	bool isExc = NativeMethodsExc.ximgproc_segmentation_SelectiveSearchSegmentationStrategy_get_excsafe(ref ret, obj, r1, r2);

	if(isExc)
		handleException();
	return ret;
}


public static  void ximgproc_segmentation_SelectiveSearchSegmentationStrategy_merge( System.IntPtr obj ,  System.Int32 r1 ,  System.Int32 r2 )
{
	bool isExc = NativeMethodsExc.ximgproc_segmentation_SelectiveSearchSegmentationStrategy_merge_excsafe(obj, r1, r2);

	if(isExc)
		handleException();
}


public static  System.IntPtr ximgproc_segmentation_createSelectiveSearchSegmentationStrategyColor()
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.ximgproc_segmentation_createSelectiveSearchSegmentationStrategyColor_excsafe(ref ret);

	if(isExc)
		handleException();
	return ret;
}


public static  System.IntPtr ximgproc_segmentation_createSelectiveSearchSegmentationStrategySize()
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.ximgproc_segmentation_createSelectiveSearchSegmentationStrategySize_excsafe(ref ret);

	if(isExc)
		handleException();
	return ret;
}


public static  System.IntPtr ximgproc_segmentation_createSelectiveSearchSegmentationStrategyTexture()
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.ximgproc_segmentation_createSelectiveSearchSegmentationStrategyTexture_excsafe(ref ret);

	if(isExc)
		handleException();
	return ret;
}


public static  System.IntPtr ximgproc_segmentation_createSelectiveSearchSegmentationStrategyFill()
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.ximgproc_segmentation_createSelectiveSearchSegmentationStrategyFill_excsafe(ref ret);

	if(isExc)
		handleException();
	return ret;
}


public static  void ximgproc_segmentation_Ptr_SelectiveSearchSegmentationStrategyColor_delete( System.IntPtr obj )
{
	bool isExc = NativeMethodsExc.ximgproc_segmentation_Ptr_SelectiveSearchSegmentationStrategyColor_delete_excsafe(obj);

	if(isExc)
		handleException();
}


public static  void ximgproc_segmentation_Ptr_SelectiveSearchSegmentationStrategySize_delete( System.IntPtr obj )
{
	bool isExc = NativeMethodsExc.ximgproc_segmentation_Ptr_SelectiveSearchSegmentationStrategySize_delete_excsafe(obj);

	if(isExc)
		handleException();
}


public static  void ximgproc_segmentation_Ptr_SelectiveSearchSegmentationStrategyTexture_delete( System.IntPtr obj )
{
	bool isExc = NativeMethodsExc.ximgproc_segmentation_Ptr_SelectiveSearchSegmentationStrategyTexture_delete_excsafe(obj);

	if(isExc)
		handleException();
}


public static  void ximgproc_segmentation_Ptr_SelectiveSearchSegmentationStrategyFill_delete( System.IntPtr obj )
{
	bool isExc = NativeMethodsExc.ximgproc_segmentation_Ptr_SelectiveSearchSegmentationStrategyFill_delete_excsafe(obj);

	if(isExc)
		handleException();
}


public static  System.IntPtr ximgproc_segmentation_Ptr_SelectiveSearchSegmentationStrategyColor_get( System.IntPtr ptr )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.ximgproc_segmentation_Ptr_SelectiveSearchSegmentationStrategyColor_get_excsafe(ref ret, ptr);

	if(isExc)
		handleException();
	return ret;
}


public static  System.IntPtr ximgproc_segmentation_Ptr_SelectiveSearchSegmentationStrategySize_get( System.IntPtr ptr )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.ximgproc_segmentation_Ptr_SelectiveSearchSegmentationStrategySize_get_excsafe(ref ret, ptr);

	if(isExc)
		handleException();
	return ret;
}


public static  System.IntPtr ximgproc_segmentation_Ptr_SelectiveSearchSegmentationStrategyTexture_get( System.IntPtr ptr )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.ximgproc_segmentation_Ptr_SelectiveSearchSegmentationStrategyTexture_get_excsafe(ref ret, ptr);

	if(isExc)
		handleException();
	return ret;
}


public static  System.IntPtr ximgproc_segmentation_Ptr_SelectiveSearchSegmentationStrategyFill_get( System.IntPtr ptr )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.ximgproc_segmentation_Ptr_SelectiveSearchSegmentationStrategyFill_get_excsafe(ref ret, ptr);

	if(isExc)
		handleException();
	return ret;
}


public static  void ximgproc_segmentation_SelectiveSearchSegmentationStrategyMultiple_addStrategy( System.IntPtr obj ,  System.IntPtr g ,  System.Single weight )
{
	bool isExc = NativeMethodsExc.ximgproc_segmentation_SelectiveSearchSegmentationStrategyMultiple_addStrategy_excsafe(obj, g, weight);

	if(isExc)
		handleException();
}


public static  void ximgproc_segmentation_SelectiveSearchSegmentationStrategyMultiple_clearStrategies( System.IntPtr obj )
{
	bool isExc = NativeMethodsExc.ximgproc_segmentation_SelectiveSearchSegmentationStrategyMultiple_clearStrategies_excsafe(obj);

	if(isExc)
		handleException();
}


public static  System.IntPtr ximgproc_segmentation_createSelectiveSearchSegmentationStrategyMultiple0()
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.ximgproc_segmentation_createSelectiveSearchSegmentationStrategyMultiple0_excsafe(ref ret);

	if(isExc)
		handleException();
	return ret;
}


public static  System.Int32 ximgproc_EdgeBoxes_getMaxBoxes( System.IntPtr obj )
{
	System.Int32 ret = new System.Int32();
	bool isExc = NativeMethodsExc.ximgproc_EdgeBoxes_getMaxBoxes_excsafe(ref ret, obj);

	if(isExc)
		handleException();
	return ret;
}


public static  void ximgproc_EdgeBoxes_setMaxBoxes( System.IntPtr obj ,  System.Int32 value )
{
	bool isExc = NativeMethodsExc.ximgproc_EdgeBoxes_setMaxBoxes_excsafe(obj, value);

	if(isExc)
		handleException();
}


public static  System.Single ximgproc_EdgeBoxes_getEdgeMinMag( System.IntPtr obj )
{
	System.Single ret = new System.Single();
	bool isExc = NativeMethodsExc.ximgproc_EdgeBoxes_getEdgeMinMag_excsafe(ref ret, obj);

	if(isExc)
		handleException();
	return ret;
}


public static  void ximgproc_EdgeBoxes_setEdgeMinMag( System.IntPtr obj ,  System.Single value )
{
	bool isExc = NativeMethodsExc.ximgproc_EdgeBoxes_setEdgeMinMag_excsafe(obj, value);

	if(isExc)
		handleException();
}


public static  System.Single ximgproc_EdgeBoxes_getEdgeMergeThr( System.IntPtr obj )
{
	System.Single ret = new System.Single();
	bool isExc = NativeMethodsExc.ximgproc_EdgeBoxes_getEdgeMergeThr_excsafe(ref ret, obj);

	if(isExc)
		handleException();
	return ret;
}


public static  void ximgproc_EdgeBoxes_setEdgeMergeThr( System.IntPtr obj ,  System.Single value )
{
	bool isExc = NativeMethodsExc.ximgproc_EdgeBoxes_setEdgeMergeThr_excsafe(obj, value);

	if(isExc)
		handleException();
}


public static  System.Single ximgproc_EdgeBoxes_getClusterMinMag( System.IntPtr obj )
{
	System.Single ret = new System.Single();
	bool isExc = NativeMethodsExc.ximgproc_EdgeBoxes_getClusterMinMag_excsafe(ref ret, obj);

	if(isExc)
		handleException();
	return ret;
}


public static  void ximgproc_EdgeBoxes_setClusterMinMag( System.IntPtr obj ,  System.Single value )
{
	bool isExc = NativeMethodsExc.ximgproc_EdgeBoxes_setClusterMinMag_excsafe(obj, value);

	if(isExc)
		handleException();
}


public static  System.Single ximgproc_EdgeBoxes_getMaxAspectRatio( System.IntPtr obj )
{
	System.Single ret = new System.Single();
	bool isExc = NativeMethodsExc.ximgproc_EdgeBoxes_getMaxAspectRatio_excsafe(ref ret, obj);

	if(isExc)
		handleException();
	return ret;
}


public static  void ximgproc_EdgeBoxes_setMaxAspectRatio( System.IntPtr obj ,  System.Single value )
{
	bool isExc = NativeMethodsExc.ximgproc_EdgeBoxes_setMaxAspectRatio_excsafe(obj, value);

	if(isExc)
		handleException();
}


public static  System.Single ximgproc_EdgeBoxes_getMinBoxArea( System.IntPtr obj )
{
	System.Single ret = new System.Single();
	bool isExc = NativeMethodsExc.ximgproc_EdgeBoxes_getMinBoxArea_excsafe(ref ret, obj);

	if(isExc)
		handleException();
	return ret;
}


public static  void ximgproc_EdgeBoxes_setMinBoxArea( System.IntPtr obj ,  System.Single value )
{
	bool isExc = NativeMethodsExc.ximgproc_EdgeBoxes_setMinBoxArea_excsafe(obj, value);

	if(isExc)
		handleException();
}


public static  System.Single ximgproc_EdgeBoxes_getGamma( System.IntPtr obj )
{
	System.Single ret = new System.Single();
	bool isExc = NativeMethodsExc.ximgproc_EdgeBoxes_getGamma_excsafe(ref ret, obj);

	if(isExc)
		handleException();
	return ret;
}


public static  void ximgproc_EdgeBoxes_setGamma( System.IntPtr obj ,  System.Single value )
{
	bool isExc = NativeMethodsExc.ximgproc_EdgeBoxes_setGamma_excsafe(obj, value);

	if(isExc)
		handleException();
}


public static  System.Single ximgproc_EdgeBoxes_getKappa( System.IntPtr obj )
{
	System.Single ret = new System.Single();
	bool isExc = NativeMethodsExc.ximgproc_EdgeBoxes_getKappa_excsafe(ref ret, obj);

	if(isExc)
		handleException();
	return ret;
}


public static  void ximgproc_EdgeBoxes_setKappa( System.IntPtr obj ,  System.Single value )
{
	bool isExc = NativeMethodsExc.ximgproc_EdgeBoxes_setKappa_excsafe(obj, value);

	if(isExc)
		handleException();
}


public static  System.IntPtr ximgproc_createEdgeBoxes( System.Single alpha ,  System.Single beta ,  System.Single eta ,  System.Single minScore ,  System.Int32 maxBoxes ,  System.Single edgeMinMag ,  System.Single edgeMergeThr ,  System.Single clusterMinMag ,  System.Single maxAspectRatio ,  System.Single minBoxArea ,  System.Single gamma ,  System.Single kappa )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.ximgproc_createEdgeBoxes_excsafe(ref ret, alpha, beta, eta, minScore, maxBoxes, edgeMinMag, edgeMergeThr, clusterMinMag, maxAspectRatio, minBoxArea, gamma, kappa);

	if(isExc)
		handleException();
	return ret;
}


public static  void ximgproc_Ptr_EdgeBoxes_delete( System.IntPtr obj )
{
	bool isExc = NativeMethodsExc.ximgproc_Ptr_EdgeBoxes_delete_excsafe(obj);

	if(isExc)
		handleException();
}


public static  System.IntPtr ximgproc_Ptr_EdgeBoxes_get( System.IntPtr ptr )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.ximgproc_Ptr_EdgeBoxes_get_excsafe(ref ret, ptr);

	if(isExc)
		handleException();
	return ret;
}


public static  void ximgproc_FastHoughTransform( System.IntPtr src ,  System.IntPtr dst ,  System.Int32 dstMatDepth ,  System.Int32 angleRange ,  System.Int32 op ,  System.Int32 makeSkew )
{
	bool isExc = NativeMethodsExc.ximgproc_FastHoughTransform_excsafe(src, dst, dstMatDepth, angleRange, op, makeSkew);

	if(isExc)
		handleException();
}


public static  OpenCvSharp.Vec4i ximgproc_HoughPoint2Line( OpenCvSharp.Point houghPoint ,  System.IntPtr srcImgInfo ,  System.Int32 angleRange ,  System.Int32 makeSkew ,  System.Int32 rules )
{
	OpenCvSharp.Vec4i ret = new OpenCvSharp.Vec4i();
	bool isExc = NativeMethodsExc.ximgproc_HoughPoint2Line_excsafe(ref ret, houghPoint, srcImgInfo, angleRange, makeSkew, rules);

	if(isExc)
		handleException();
	return ret;
}


public static  void ximgproc_FastLineDetector_delete( System.IntPtr obj )
{
	bool isExc = NativeMethodsExc.ximgproc_FastLineDetector_delete_excsafe(obj);

	if(isExc)
		handleException();
}


public static  System.IntPtr ximgproc_Ptr_FastLineDetector_get( System.IntPtr ptr )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.ximgproc_Ptr_FastLineDetector_get_excsafe(ref ret, ptr);

	if(isExc)
		handleException();
	return ret;
}


public static  void ximgproc_FastLineDetector_detect_OutputArray( System.IntPtr obj ,  System.IntPtr image ,  System.IntPtr lines )
{
	bool isExc = NativeMethodsExc.ximgproc_FastLineDetector_detect_OutputArray_excsafe(obj, image, lines);

	if(isExc)
		handleException();
}


public static  void ximgproc_FastLineDetector_detect_vector( System.IntPtr obj ,  System.IntPtr image ,  System.IntPtr lines )
{
	bool isExc = NativeMethodsExc.ximgproc_FastLineDetector_detect_vector_excsafe(obj, image, lines);

	if(isExc)
		handleException();
}


public static  void ximgproc_FastLineDetector_drawSegments_InputArray( System.IntPtr obj ,  System.IntPtr image ,  System.IntPtr lines ,  System.Int32 draw_arrow )
{
	bool isExc = NativeMethodsExc.ximgproc_FastLineDetector_drawSegments_InputArray_excsafe(obj, image, lines, draw_arrow);

	if(isExc)
		handleException();
}


public static  void ximgproc_FastLineDetector_drawSegments_vector( System.IntPtr obj ,  System.IntPtr image ,  System.IntPtr lines ,  System.Int32 draw_arrow )
{
	bool isExc = NativeMethodsExc.ximgproc_FastLineDetector_drawSegments_vector_excsafe(obj, image, lines, draw_arrow);

	if(isExc)
		handleException();
}


public static  System.IntPtr ximgproc_createFastLineDetector( System.Int32 length_threshold ,  System.Single distance_threshold ,  System.Double canny_th1 ,  System.Double canny_th2 ,  System.Int32 canny_aperture_size ,  System.Int32 do_merge )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.ximgproc_createFastLineDetector_excsafe(ref ret, length_threshold, distance_threshold, canny_th1, canny_th2, canny_aperture_size, do_merge);

	if(isExc)
		handleException();
	return ret;
}


public static  System.Int32 video_BackgroundSubtractorKNN_getHistory( System.IntPtr ptr )
{
	System.Int32 ret = new System.Int32();
	bool isExc = NativeMethodsExc.video_BackgroundSubtractorKNN_getHistory_excsafe(ref ret, ptr);

	if(isExc)
		handleException();
	return ret;
}


public static  void video_BackgroundSubtractorKNN_setHistory( System.IntPtr ptr ,  System.Int32 value )
{
	bool isExc = NativeMethodsExc.video_BackgroundSubtractorKNN_setHistory_excsafe(ptr, value);

	if(isExc)
		handleException();
}


public static  System.Int32 video_BackgroundSubtractorKNN_getNSamples( System.IntPtr ptr )
{
	System.Int32 ret = new System.Int32();
	bool isExc = NativeMethodsExc.video_BackgroundSubtractorKNN_getNSamples_excsafe(ref ret, ptr);

	if(isExc)
		handleException();
	return ret;
}


public static  void video_BackgroundSubtractorKNN_setNSamples( System.IntPtr ptr ,  System.Int32 value )
{
	bool isExc = NativeMethodsExc.video_BackgroundSubtractorKNN_setNSamples_excsafe(ptr, value);

	if(isExc)
		handleException();
}


public static  System.Int32 video_BackgroundSubtractorKNN_getDist2Threshold( System.IntPtr ptr )
{
	System.Int32 ret = new System.Int32();
	bool isExc = NativeMethodsExc.video_BackgroundSubtractorKNN_getDist2Threshold_excsafe(ref ret, ptr);

	if(isExc)
		handleException();
	return ret;
}


public static  void video_BackgroundSubtractorKNN_setDist2Threshold( System.IntPtr ptr ,  System.Double value )
{
	bool isExc = NativeMethodsExc.video_BackgroundSubtractorKNN_setDist2Threshold_excsafe(ptr, value);

	if(isExc)
		handleException();
}


public static  System.Int32 video_BackgroundSubtractorKNN_getkNNSamples( System.IntPtr ptr )
{
	System.Int32 ret = new System.Int32();
	bool isExc = NativeMethodsExc.video_BackgroundSubtractorKNN_getkNNSamples_excsafe(ref ret, ptr);

	if(isExc)
		handleException();
	return ret;
}


public static  void video_BackgroundSubtractorKNN_setkNNSamples( System.IntPtr ptr ,  System.Int32 value )
{
	bool isExc = NativeMethodsExc.video_BackgroundSubtractorKNN_setkNNSamples_excsafe(ptr, value);

	if(isExc)
		handleException();
}


public static  System.Int32 video_BackgroundSubtractorKNN_getDetectShadows( System.IntPtr ptr )
{
	System.Int32 ret = new System.Int32();
	bool isExc = NativeMethodsExc.video_BackgroundSubtractorKNN_getDetectShadows_excsafe(ref ret, ptr);

	if(isExc)
		handleException();
	return ret;
}


public static  void video_BackgroundSubtractorKNN_setDetectShadows( System.IntPtr ptr ,  System.Int32 value )
{
	bool isExc = NativeMethodsExc.video_BackgroundSubtractorKNN_setDetectShadows_excsafe(ptr, value);

	if(isExc)
		handleException();
}


public static  System.Int32 video_BackgroundSubtractorKNN_getShadowValue( System.IntPtr ptr )
{
	System.Int32 ret = new System.Int32();
	bool isExc = NativeMethodsExc.video_BackgroundSubtractorKNN_getShadowValue_excsafe(ref ret, ptr);

	if(isExc)
		handleException();
	return ret;
}


public static  void video_BackgroundSubtractorKNN_setShadowValue( System.IntPtr ptr ,  System.Int32 value )
{
	bool isExc = NativeMethodsExc.video_BackgroundSubtractorKNN_setShadowValue_excsafe(ptr, value);

	if(isExc)
		handleException();
}


public static  System.Double video_BackgroundSubtractorKNN_getShadowThreshold( System.IntPtr ptr )
{
	System.Double ret = new System.Double();
	bool isExc = NativeMethodsExc.video_BackgroundSubtractorKNN_getShadowThreshold_excsafe(ref ret, ptr);

	if(isExc)
		handleException();
	return ret;
}


public static  void video_BackgroundSubtractorKNN_setShadowThreshold( System.IntPtr ptr ,  System.Double value )
{
	bool isExc = NativeMethodsExc.video_BackgroundSubtractorKNN_setShadowThreshold_excsafe(ptr, value);

	if(isExc)
		handleException();
}


public static  void ximgproc_niBlackThreshold( System.IntPtr src ,  System.IntPtr dst ,  System.Double maxValue ,  System.Int32 type ,  System.Int32 blockSize ,  System.Double delta )
{
	bool isExc = NativeMethodsExc.ximgproc_niBlackThreshold_excsafe(src, dst, maxValue, type, blockSize, delta);

	if(isExc)
		handleException();
}


public static  void ximgproc_thinning( System.IntPtr src ,  System.IntPtr dst ,  System.Int32 thinningType )
{
	bool isExc = NativeMethodsExc.ximgproc_thinning_excsafe(src, dst, thinningType);

	if(isExc)
		handleException();
}


public static  void ximgproc_anisotropicDiffusion( System.IntPtr src ,  System.IntPtr dst ,  System.Single alpha ,  System.Single K ,  System.Int32 niters )
{
	bool isExc = NativeMethodsExc.ximgproc_anisotropicDiffusion_excsafe(src, dst, alpha, K, niters);

	if(isExc)
		handleException();
}


public static  void ximgproc_weightedMedianFilter( System.IntPtr joint ,  System.IntPtr src ,  System.IntPtr dst ,  System.Int32 r ,  System.Double sigma ,  System.Int32 weightType ,  System.IntPtr mask )
{
	bool isExc = NativeMethodsExc.ximgproc_weightedMedianFilter_excsafe(joint, src, dst, r, sigma, weightType, mask);

	if(isExc)
		handleException();
}


public static  void ximgproc_covarianceEstimation( System.IntPtr src ,  System.IntPtr dst ,  System.Int32 windowRows ,  System.Int32 windowCols )
{
	bool isExc = NativeMethodsExc.ximgproc_covarianceEstimation_excsafe(src, dst, windowRows, windowCols);

	if(isExc)
		handleException();
}


public static  void ximgproc_EdgeBoxes_getBoundingBoxes( System.IntPtr obj ,  System.IntPtr edge_map ,  System.IntPtr orientation_map ,  System.IntPtr boxes )
{
	bool isExc = NativeMethodsExc.ximgproc_EdgeBoxes_getBoundingBoxes_excsafe(obj, edge_map, orientation_map, boxes);

	if(isExc)
		handleException();
}


public static  System.Single ximgproc_EdgeBoxes_getAlpha( System.IntPtr obj )
{
	System.Single ret = new System.Single();
	bool isExc = NativeMethodsExc.ximgproc_EdgeBoxes_getAlpha_excsafe(ref ret, obj);

	if(isExc)
		handleException();
	return ret;
}


public static  void ximgproc_EdgeBoxes_setAlpha( System.IntPtr obj ,  System.Single value )
{
	bool isExc = NativeMethodsExc.ximgproc_EdgeBoxes_setAlpha_excsafe(obj, value);

	if(isExc)
		handleException();
}


public static  System.Single ximgproc_EdgeBoxes_getBeta( System.IntPtr obj )
{
	System.Single ret = new System.Single();
	bool isExc = NativeMethodsExc.ximgproc_EdgeBoxes_getBeta_excsafe(ref ret, obj);

	if(isExc)
		handleException();
	return ret;
}


public static  void ximgproc_EdgeBoxes_setBeta( System.IntPtr obj ,  System.Single value )
{
	bool isExc = NativeMethodsExc.ximgproc_EdgeBoxes_setBeta_excsafe(obj, value);

	if(isExc)
		handleException();
}


public static  System.Single ximgproc_EdgeBoxes_getEta( System.IntPtr obj )
{
	System.Single ret = new System.Single();
	bool isExc = NativeMethodsExc.ximgproc_EdgeBoxes_getEta_excsafe(ref ret, obj);

	if(isExc)
		handleException();
	return ret;
}


public static  void ximgproc_EdgeBoxes_setEta( System.IntPtr obj ,  System.Single value )
{
	bool isExc = NativeMethodsExc.ximgproc_EdgeBoxes_setEta_excsafe(obj, value);

	if(isExc)
		handleException();
}


public static  System.Single ximgproc_EdgeBoxes_getMinScore( System.IntPtr obj )
{
	System.Single ret = new System.Single();
	bool isExc = NativeMethodsExc.ximgproc_EdgeBoxes_getMinScore_excsafe(ref ret, obj);

	if(isExc)
		handleException();
	return ret;
}


public static  void ximgproc_EdgeBoxes_setMinScore( System.IntPtr obj ,  System.Single value )
{
	bool isExc = NativeMethodsExc.ximgproc_EdgeBoxes_setMinScore_excsafe(obj, value);

	if(isExc)
		handleException();
}


public static  System.IntPtr video_Ptr_BackgroundSubtractorMOG2_get( System.IntPtr ptr )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.video_Ptr_BackgroundSubtractorMOG2_get_excsafe(ref ret, ptr);

	if(isExc)
		handleException();
	return ret;
}


public static  System.Int32 video_BackgroundSubtractorMOG2_getHistory( System.IntPtr ptr )
{
	System.Int32 ret = new System.Int32();
	bool isExc = NativeMethodsExc.video_BackgroundSubtractorMOG2_getHistory_excsafe(ref ret, ptr);

	if(isExc)
		handleException();
	return ret;
}


public static  void video_BackgroundSubtractorMOG2_setHistory( System.IntPtr ptr ,  System.Int32 value )
{
	bool isExc = NativeMethodsExc.video_BackgroundSubtractorMOG2_setHistory_excsafe(ptr, value);

	if(isExc)
		handleException();
}


public static  System.Int32 video_BackgroundSubtractorMOG2_getNMixtures( System.IntPtr ptr )
{
	System.Int32 ret = new System.Int32();
	bool isExc = NativeMethodsExc.video_BackgroundSubtractorMOG2_getNMixtures_excsafe(ref ret, ptr);

	if(isExc)
		handleException();
	return ret;
}


public static  void video_BackgroundSubtractorMOG2_setNMixtures( System.IntPtr ptr ,  System.Int32 value )
{
	bool isExc = NativeMethodsExc.video_BackgroundSubtractorMOG2_setNMixtures_excsafe(ptr, value);

	if(isExc)
		handleException();
}


public static  System.Double video_BackgroundSubtractorMOG2_getBackgroundRatio( System.IntPtr ptr )
{
	System.Double ret = new System.Double();
	bool isExc = NativeMethodsExc.video_BackgroundSubtractorMOG2_getBackgroundRatio_excsafe(ref ret, ptr);

	if(isExc)
		handleException();
	return ret;
}


public static  void video_BackgroundSubtractorMOG2_setBackgroundRatio( System.IntPtr ptr ,  System.Double value )
{
	bool isExc = NativeMethodsExc.video_BackgroundSubtractorMOG2_setBackgroundRatio_excsafe(ptr, value);

	if(isExc)
		handleException();
}


public static  System.Double video_BackgroundSubtractorMOG2_getVarThreshold( System.IntPtr ptr )
{
	System.Double ret = new System.Double();
	bool isExc = NativeMethodsExc.video_BackgroundSubtractorMOG2_getVarThreshold_excsafe(ref ret, ptr);

	if(isExc)
		handleException();
	return ret;
}


public static  void video_BackgroundSubtractorMOG2_setVarThreshold( System.IntPtr ptr ,  System.Double value )
{
	bool isExc = NativeMethodsExc.video_BackgroundSubtractorMOG2_setVarThreshold_excsafe(ptr, value);

	if(isExc)
		handleException();
}


public static  System.Double video_BackgroundSubtractorMOG2_getVarThresholdGen( System.IntPtr ptr )
{
	System.Double ret = new System.Double();
	bool isExc = NativeMethodsExc.video_BackgroundSubtractorMOG2_getVarThresholdGen_excsafe(ref ret, ptr);

	if(isExc)
		handleException();
	return ret;
}


public static  void video_BackgroundSubtractorMOG2_setVarThresholdGen( System.IntPtr ptr ,  System.Double value )
{
	bool isExc = NativeMethodsExc.video_BackgroundSubtractorMOG2_setVarThresholdGen_excsafe(ptr, value);

	if(isExc)
		handleException();
}


public static  System.Double video_BackgroundSubtractorMOG2_getVarInit( System.IntPtr ptr )
{
	System.Double ret = new System.Double();
	bool isExc = NativeMethodsExc.video_BackgroundSubtractorMOG2_getVarInit_excsafe(ref ret, ptr);

	if(isExc)
		handleException();
	return ret;
}


public static  void video_BackgroundSubtractorMOG2_setVarInit( System.IntPtr ptr ,  System.Double value )
{
	bool isExc = NativeMethodsExc.video_BackgroundSubtractorMOG2_setVarInit_excsafe(ptr, value);

	if(isExc)
		handleException();
}


public static  System.Double video_BackgroundSubtractorMOG2_getVarMin( System.IntPtr ptr )
{
	System.Double ret = new System.Double();
	bool isExc = NativeMethodsExc.video_BackgroundSubtractorMOG2_getVarMin_excsafe(ref ret, ptr);

	if(isExc)
		handleException();
	return ret;
}


public static  void video_BackgroundSubtractorMOG2_setVarMin( System.IntPtr ptr ,  System.Double value )
{
	bool isExc = NativeMethodsExc.video_BackgroundSubtractorMOG2_setVarMin_excsafe(ptr, value);

	if(isExc)
		handleException();
}


public static  System.Double video_BackgroundSubtractorMOG2_getVarMax( System.IntPtr ptr )
{
	System.Double ret = new System.Double();
	bool isExc = NativeMethodsExc.video_BackgroundSubtractorMOG2_getVarMax_excsafe(ref ret, ptr);

	if(isExc)
		handleException();
	return ret;
}


public static  void video_BackgroundSubtractorMOG2_setVarMax( System.IntPtr ptr ,  System.Double value )
{
	bool isExc = NativeMethodsExc.video_BackgroundSubtractorMOG2_setVarMax_excsafe(ptr, value);

	if(isExc)
		handleException();
}


public static  System.Double video_BackgroundSubtractorMOG2_getComplexityReductionThreshold( System.IntPtr ptr )
{
	System.Double ret = new System.Double();
	bool isExc = NativeMethodsExc.video_BackgroundSubtractorMOG2_getComplexityReductionThreshold_excsafe(ref ret, ptr);

	if(isExc)
		handleException();
	return ret;
}


public static  void video_BackgroundSubtractorMOG2_setComplexityReductionThreshold( System.IntPtr ptr ,  System.Double value )
{
	bool isExc = NativeMethodsExc.video_BackgroundSubtractorMOG2_setComplexityReductionThreshold_excsafe(ptr, value);

	if(isExc)
		handleException();
}


public static  System.Int32 video_BackgroundSubtractorMOG2_getDetectShadows( System.IntPtr ptr )
{
	System.Int32 ret = new System.Int32();
	bool isExc = NativeMethodsExc.video_BackgroundSubtractorMOG2_getDetectShadows_excsafe(ref ret, ptr);

	if(isExc)
		handleException();
	return ret;
}


public static  void video_BackgroundSubtractorMOG2_setDetectShadows( System.IntPtr ptr ,  System.Int32 value )
{
	bool isExc = NativeMethodsExc.video_BackgroundSubtractorMOG2_setDetectShadows_excsafe(ptr, value);

	if(isExc)
		handleException();
}


public static  System.Int32 video_BackgroundSubtractorMOG2_getShadowValue( System.IntPtr ptr )
{
	System.Int32 ret = new System.Int32();
	bool isExc = NativeMethodsExc.video_BackgroundSubtractorMOG2_getShadowValue_excsafe(ref ret, ptr);

	if(isExc)
		handleException();
	return ret;
}


public static  void video_BackgroundSubtractorMOG2_setShadowValue( System.IntPtr ptr ,  System.Int32 value )
{
	bool isExc = NativeMethodsExc.video_BackgroundSubtractorMOG2_setShadowValue_excsafe(ptr, value);

	if(isExc)
		handleException();
}


public static  System.Double video_BackgroundSubtractorMOG2_getShadowThreshold( System.IntPtr ptr )
{
	System.Double ret = new System.Double();
	bool isExc = NativeMethodsExc.video_BackgroundSubtractorMOG2_getShadowThreshold_excsafe(ref ret, ptr);

	if(isExc)
		handleException();
	return ret;
}


public static  void video_BackgroundSubtractorMOG2_setShadowThreshold( System.IntPtr ptr ,  System.Double value )
{
	bool isExc = NativeMethodsExc.video_BackgroundSubtractorMOG2_setShadowThreshold_excsafe(ptr, value);

	if(isExc)
		handleException();
}


public static  System.IntPtr video_createBackgroundSubtractorKNN( System.Int32 history ,  System.Double dist2Threshold ,  System.Int32 detectShadows )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.video_createBackgroundSubtractorKNN_excsafe(ref ret, history, dist2Threshold, detectShadows);

	if(isExc)
		handleException();
	return ret;
}


public static  void video_Ptr_BackgroundSubtractorKNN_delete( System.IntPtr obj )
{
	bool isExc = NativeMethodsExc.video_Ptr_BackgroundSubtractorKNN_delete_excsafe(obj);

	if(isExc)
		handleException();
}


public static  System.IntPtr video_Ptr_BackgroundSubtractorKNN_get( System.IntPtr ptr )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.video_Ptr_BackgroundSubtractorKNN_get_excsafe(ref ret, ptr);

	if(isExc)
		handleException();
	return ret;
}


public static  System.IntPtr video_KalmanFilter_correct( System.IntPtr obj ,  System.IntPtr measurement )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.video_KalmanFilter_correct_excsafe(ref ret, obj, measurement);

	if(isExc)
		handleException();
	return ret;
}


public static  System.IntPtr video_KalmanFilter_statePre( System.IntPtr obj )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.video_KalmanFilter_statePre_excsafe(ref ret, obj);

	if(isExc)
		handleException();
	return ret;
}


public static  System.IntPtr video_KalmanFilter_statePost( System.IntPtr obj )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.video_KalmanFilter_statePost_excsafe(ref ret, obj);

	if(isExc)
		handleException();
	return ret;
}


public static  System.IntPtr video_KalmanFilter_transitionMatrix( System.IntPtr obj )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.video_KalmanFilter_transitionMatrix_excsafe(ref ret, obj);

	if(isExc)
		handleException();
	return ret;
}


public static  System.IntPtr video_KalmanFilter_controlMatrix( System.IntPtr obj )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.video_KalmanFilter_controlMatrix_excsafe(ref ret, obj);

	if(isExc)
		handleException();
	return ret;
}


public static  System.IntPtr video_KalmanFilter_measurementMatrix( System.IntPtr obj )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.video_KalmanFilter_measurementMatrix_excsafe(ref ret, obj);

	if(isExc)
		handleException();
	return ret;
}


public static  System.IntPtr video_KalmanFilter_processNoiseCov( System.IntPtr obj )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.video_KalmanFilter_processNoiseCov_excsafe(ref ret, obj);

	if(isExc)
		handleException();
	return ret;
}


public static  System.IntPtr video_KalmanFilter_measurementNoiseCov( System.IntPtr obj )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.video_KalmanFilter_measurementNoiseCov_excsafe(ref ret, obj);

	if(isExc)
		handleException();
	return ret;
}


public static  System.IntPtr video_KalmanFilter_errorCovPre( System.IntPtr obj )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.video_KalmanFilter_errorCovPre_excsafe(ref ret, obj);

	if(isExc)
		handleException();
	return ret;
}


public static  System.IntPtr video_KalmanFilter_gain( System.IntPtr obj )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.video_KalmanFilter_gain_excsafe(ref ret, obj);

	if(isExc)
		handleException();
	return ret;
}


public static  System.IntPtr video_KalmanFilter_errorCovPost( System.IntPtr obj )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.video_KalmanFilter_errorCovPost_excsafe(ref ret, obj);

	if(isExc)
		handleException();
	return ret;
}


public static  System.Int32 video_buildOpticalFlowPyramid1( System.IntPtr img ,  System.IntPtr pyramid ,  OpenCvSharp.Size winSize ,  System.Int32 maxLevel ,  System.Int32 withDerivatives ,  System.Int32 pyrBorder ,  System.Int32 derivBorder ,  System.Int32 tryReuseInputImage )
{
	System.Int32 ret = new System.Int32();
	bool isExc = NativeMethodsExc.video_buildOpticalFlowPyramid1_excsafe(ref ret, img, pyramid, winSize, maxLevel, withDerivatives, pyrBorder, derivBorder, tryReuseInputImage);

	if(isExc)
		handleException();
	return ret;
}


public static  System.Int32 video_buildOpticalFlowPyramid2( System.IntPtr img ,  System.IntPtr pyramidVec ,  OpenCvSharp.Size winSize ,  System.Int32 maxLevel ,  System.Int32 withDerivatives ,  System.Int32 pyrBorder ,  System.Int32 derivBorder ,  System.Int32 tryReuseInputImage )
{
	System.Int32 ret = new System.Int32();
	bool isExc = NativeMethodsExc.video_buildOpticalFlowPyramid2_excsafe(ref ret, img, pyramidVec, winSize, maxLevel, withDerivatives, pyrBorder, derivBorder, tryReuseInputImage);

	if(isExc)
		handleException();
	return ret;
}


public static  void video_calcOpticalFlowPyrLK_InputArray( System.IntPtr prevImg ,  System.IntPtr nextImg ,  System.IntPtr prevPts ,  System.IntPtr nextPts ,  System.IntPtr status ,  System.IntPtr err ,  OpenCvSharp.Size winSize ,  System.Int32 maxLevel ,  OpenCvSharp.TermCriteria criteria ,  System.Int32 flags ,  System.Double minEigThreshold )
{
	bool isExc = NativeMethodsExc.video_calcOpticalFlowPyrLK_InputArray_excsafe(prevImg, nextImg, prevPts, nextPts, status, err, winSize, maxLevel, criteria, flags, minEigThreshold);

	if(isExc)
		handleException();
}


public static  void video_calcOpticalFlowPyrLK_vector( System.IntPtr prevImg ,  System.IntPtr nextImg ,  OpenCvSharp.Point2f[] prevPts ,  System.Int32 prevPtsSize ,  System.IntPtr nextPts ,  System.IntPtr status ,  System.IntPtr err ,  OpenCvSharp.Size winSize ,  System.Int32 maxLevel ,  OpenCvSharp.TermCriteria criteria ,  System.Int32 flags ,  System.Double minEigThreshold )
{
	bool isExc = NativeMethodsExc.video_calcOpticalFlowPyrLK_vector_excsafe(prevImg, nextImg, prevPts, prevPtsSize, nextPts, status, err, winSize, maxLevel, criteria, flags, minEigThreshold);

	if(isExc)
		handleException();
}


public static  void video_calcOpticalFlowFarneback( System.IntPtr prev ,  System.IntPtr next ,  System.IntPtr flow ,  System.Double pyrScale ,  System.Int32 levels ,  System.Int32 winSize ,  System.Int32 iterations ,  System.Int32 polyN ,  System.Double polySigma ,  System.Int32 flags )
{
	bool isExc = NativeMethodsExc.video_calcOpticalFlowFarneback_excsafe(prev, next, flow, pyrScale, levels, winSize, iterations, polyN, polySigma, flags);

	if(isExc)
		handleException();
}


public static  System.IntPtr video_estimateRigidTransform( System.IntPtr src ,  System.IntPtr dst ,  System.Int32 fullAffine )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.video_estimateRigidTransform_excsafe(ref ret, src, dst, fullAffine);

	if(isExc)
		handleException();
	return ret;
}


public static  void video_DenseOpticalFlow_calc( System.IntPtr obj ,  System.IntPtr i0 ,  System.IntPtr i1 ,  System.IntPtr flow )
{
	bool isExc = NativeMethodsExc.video_DenseOpticalFlow_calc_excsafe(obj, i0, i1, flow);

	if(isExc)
		handleException();
}


public static  void video_DenseOpticalFlow_collectGarbage( System.IntPtr obj )
{
	bool isExc = NativeMethodsExc.video_DenseOpticalFlow_collectGarbage_excsafe(obj);

	if(isExc)
		handleException();
}


public static  System.IntPtr video_createOptFlow_DualTVL1()
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.video_createOptFlow_DualTVL1_excsafe(ref ret);

	if(isExc)
		handleException();
	return ret;
}


public static  System.IntPtr video_Ptr_DenseOpticalFlow_get( System.IntPtr ptr )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.video_Ptr_DenseOpticalFlow_get_excsafe(ref ret, ptr);

	if(isExc)
		handleException();
	return ret;
}


public static  void video_Ptr_DenseOpticalFlow_delete( System.IntPtr ptr )
{
	bool isExc = NativeMethodsExc.video_Ptr_DenseOpticalFlow_delete_excsafe(ptr);

	if(isExc)
		handleException();
}


public static  void video_BackgroundSubtractor_getBackgroundImage( System.IntPtr self ,  System.IntPtr backgroundImage )
{
	bool isExc = NativeMethodsExc.video_BackgroundSubtractor_getBackgroundImage_excsafe(self, backgroundImage);

	if(isExc)
		handleException();
}


public static  void video_BackgroundSubtractor_apply( System.IntPtr self ,  System.IntPtr image ,  System.IntPtr fgmask ,  System.Double learningRate )
{
	bool isExc = NativeMethodsExc.video_BackgroundSubtractor_apply_excsafe(self, image, fgmask, learningRate);

	if(isExc)
		handleException();
}


public static  void video_Ptr_BackgroundSubtractor_delete( System.IntPtr ptr )
{
	bool isExc = NativeMethodsExc.video_Ptr_BackgroundSubtractor_delete_excsafe(ptr);

	if(isExc)
		handleException();
}


public static  System.IntPtr video_Ptr_BackgroundSubtractor_get( System.IntPtr ptr )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.video_Ptr_BackgroundSubtractor_get_excsafe(ref ret, ptr);

	if(isExc)
		handleException();
	return ret;
}


public static  System.IntPtr video_createBackgroundSubtractorMOG2( System.Int32 history ,  System.Double varThreshold ,  System.Int32 detectShadows )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.video_createBackgroundSubtractorMOG2_excsafe(ref ret, history, varThreshold, detectShadows);

	if(isExc)
		handleException();
	return ret;
}


public static  void video_Ptr_BackgroundSubtractorMOG2_delete( System.IntPtr ptr )
{
	bool isExc = NativeMethodsExc.video_Ptr_BackgroundSubtractorMOG2_delete_excsafe(ptr);

	if(isExc)
		handleException();
}


public static  void tracking_Ptr_TrackerMedianFlow_delete( System.IntPtr ptr )
{
	bool isExc = NativeMethodsExc.tracking_Ptr_TrackerMedianFlow_delete_excsafe(ptr);

	if(isExc)
		handleException();
}


public static  System.IntPtr tracking_Ptr_TrackerMedianFlow_get( System.IntPtr ptr )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.tracking_Ptr_TrackerMedianFlow_get_excsafe(ref ret, ptr);

	if(isExc)
		handleException();
	return ret;
}


public static  System.IntPtr tracking_TrackerTLD_create1()
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.tracking_TrackerTLD_create1_excsafe(ref ret);

	if(isExc)
		handleException();
	return ret;
}


public static  unsafe System.IntPtr tracking_TrackerTLD_create2( OpenCvSharp.Tracking.TrackerTLD.Params* parameters )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.tracking_TrackerTLD_create2_excsafe(ref ret, parameters);

	if(isExc)
		handleException();
	return ret;
}


public static  void tracking_Ptr_TrackerTLD_delete( System.IntPtr ptr )
{
	bool isExc = NativeMethodsExc.tracking_Ptr_TrackerTLD_delete_excsafe(ptr);

	if(isExc)
		handleException();
}


public static  System.IntPtr tracking_Ptr_TrackerTLD_get( System.IntPtr ptr )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.tracking_Ptr_TrackerTLD_get_excsafe(ref ret, ptr);

	if(isExc)
		handleException();
	return ret;
}


public static  System.IntPtr tracking_TrackerGOTURN_create1()
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.tracking_TrackerGOTURN_create1_excsafe(ref ret);

	if(isExc)
		handleException();
	return ret;
}


public static  unsafe System.IntPtr tracking_TrackerGOTURN_create2( OpenCvSharp.Tracking.TrackerGOTURN.Params* parameters )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.tracking_TrackerGOTURN_create2_excsafe(ref ret, parameters);

	if(isExc)
		handleException();
	return ret;
}


public static  void tracking_Ptr_TrackerGOTURN_delete( System.IntPtr ptr )
{
	bool isExc = NativeMethodsExc.tracking_Ptr_TrackerGOTURN_delete_excsafe(ptr);

	if(isExc)
		handleException();
}


public static  System.IntPtr tracking_Ptr_TrackerGOTURN_get( System.IntPtr ptr )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.tracking_Ptr_TrackerGOTURN_get_excsafe(ref ret, ptr);

	if(isExc)
		handleException();
	return ret;
}


public static  System.IntPtr tracking_TrackerMOSSE_create()
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.tracking_TrackerMOSSE_create_excsafe(ref ret);

	if(isExc)
		handleException();
	return ret;
}


public static  void tracking_Ptr_TrackerMOSSE_delete( System.IntPtr ptr )
{
	bool isExc = NativeMethodsExc.tracking_Ptr_TrackerMOSSE_delete_excsafe(ptr);

	if(isExc)
		handleException();
}


public static  System.IntPtr tracking_Ptr_TrackerMOSSE_get( System.IntPtr ptr )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.tracking_Ptr_TrackerMOSSE_get_excsafe(ref ret, ptr);

	if(isExc)
		handleException();
	return ret;
}


public static  System.IntPtr tracking_MultiTracker_create()
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.tracking_MultiTracker_create_excsafe(ref ret);

	if(isExc)
		handleException();
	return ret;
}


public static  void tracking_Ptr_MultiTracker_delete( System.IntPtr ptr )
{
	bool isExc = NativeMethodsExc.tracking_Ptr_MultiTracker_delete_excsafe(ptr);

	if(isExc)
		handleException();
}


public static  System.IntPtr tracking_Ptr_MultiTracker_get( System.IntPtr ptr )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.tracking_Ptr_MultiTracker_get_excsafe(ref ret, ptr);

	if(isExc)
		handleException();
	return ret;
}


public static  System.Int32 tracking_MultiTracker_add1( System.IntPtr obj ,  System.IntPtr newTracker ,  System.IntPtr image ,  OpenCvSharp.Rect2d boundingBox )
{
	System.Int32 ret = new System.Int32();
	bool isExc = NativeMethodsExc.tracking_MultiTracker_add1_excsafe(ref ret, obj, newTracker, image, boundingBox);

	if(isExc)
		handleException();
	return ret;
}


public static  System.Int32 tracking_MultiTracker_add2( System.IntPtr obj ,  System.IntPtr[] newTrackers ,  System.Int32 newTrackersLength ,  System.IntPtr image ,  OpenCvSharp.Rect2d[] boundingBox ,  System.Int32 boundingBoxLength )
{
	System.Int32 ret = new System.Int32();
	bool isExc = NativeMethodsExc.tracking_MultiTracker_add2_excsafe(ref ret, obj, newTrackers, newTrackersLength, image, boundingBox, boundingBoxLength);

	if(isExc)
		handleException();
	return ret;
}


public static  System.Int32 tracking_MultiTracker_update1( System.IntPtr obj ,  System.IntPtr image )
{
	System.Int32 ret = new System.Int32();
	bool isExc = NativeMethodsExc.tracking_MultiTracker_update1_excsafe(ref ret, obj, image);

	if(isExc)
		handleException();
	return ret;
}


public static  System.Int32 tracking_MultiTracker_update2( System.IntPtr obj ,  System.IntPtr image ,  System.IntPtr boundingBox )
{
	System.Int32 ret = new System.Int32();
	bool isExc = NativeMethodsExc.tracking_MultiTracker_update2_excsafe(ref ret, obj, image, boundingBox);

	if(isExc)
		handleException();
	return ret;
}


public static  void tracking_MultiTracker_getObjects( System.IntPtr obj ,  System.IntPtr boundingBox )
{
	bool isExc = NativeMethodsExc.tracking_MultiTracker_getObjects_excsafe(obj, boundingBox);

	if(isExc)
		handleException();
}


public static  OpenCvSharp.RotatedRect video_CamShift( System.IntPtr probImage ,  ref OpenCvSharp.Rect window ,  OpenCvSharp.TermCriteria criteria )
{
	OpenCvSharp.RotatedRect ret = new OpenCvSharp.RotatedRect();
	bool isExc = NativeMethodsExc.video_CamShift_excsafe(ref ret, probImage,  ref window, criteria);

	if(isExc)
		handleException();
	return ret;
}


public static  System.Int32 video_meanShift( System.IntPtr probImage ,  ref OpenCvSharp.Rect window ,  OpenCvSharp.TermCriteria criteria )
{
	System.Int32 ret = new System.Int32();
	bool isExc = NativeMethodsExc.video_meanShift_excsafe(ref ret, probImage,  ref window, criteria);

	if(isExc)
		handleException();
	return ret;
}


public static  System.IntPtr video_KalmanFilter_new1()
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.video_KalmanFilter_new1_excsafe(ref ret);

	if(isExc)
		handleException();
	return ret;
}


public static  System.IntPtr video_KalmanFilter_new2( System.Int32 dynamParams ,  System.Int32 measureParams ,  System.Int32 controlParams ,  System.Int32 type )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.video_KalmanFilter_new2_excsafe(ref ret, dynamParams, measureParams, controlParams, type);

	if(isExc)
		handleException();
	return ret;
}


public static  void video_KalmanFilter_init( System.IntPtr obj ,  System.Int32 dynamParams ,  System.Int32 measureParams ,  System.Int32 controlParams ,  System.Int32 type )
{
	bool isExc = NativeMethodsExc.video_KalmanFilter_init_excsafe(obj, dynamParams, measureParams, controlParams, type);

	if(isExc)
		handleException();
}


public static  void video_KalmanFilter_delete( System.IntPtr obj )
{
	bool isExc = NativeMethodsExc.video_KalmanFilter_delete_excsafe(obj);

	if(isExc)
		handleException();
}


public static  System.IntPtr video_KalmanFilter_predict( System.IntPtr obj ,  System.IntPtr control )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.video_KalmanFilter_predict_excsafe(ref ret, obj, control);

	if(isExc)
		handleException();
	return ret;
}


public static  void shape_ShapeContextDistanceExtractor_setStdDev( System.IntPtr obj ,  System.Single val )
{
	bool isExc = NativeMethodsExc.shape_ShapeContextDistanceExtractor_setStdDev_excsafe(obj, val);

	if(isExc)
		handleException();
}


public static  System.Single shape_ShapeContextDistanceExtractor_getStdDev( System.IntPtr obj )
{
	System.Single ret = new System.Single();
	bool isExc = NativeMethodsExc.shape_ShapeContextDistanceExtractor_getStdDev_excsafe(ref ret, obj);

	if(isExc)
		handleException();
	return ret;
}


public static  System.IntPtr shape_createShapeContextDistanceExtractor( System.Int32 nAngularBins ,  System.Int32 nRadialBins ,  System.Single innerRadius ,  System.Single outerRadius ,  System.Int32 iterations )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.shape_createShapeContextDistanceExtractor_excsafe(ref ret, nAngularBins, nRadialBins, innerRadius, outerRadius, iterations);

	if(isExc)
		handleException();
	return ret;
}


public static  void shape_Ptr_HausdorffDistanceExtractor_delete( System.IntPtr obj )
{
	bool isExc = NativeMethodsExc.shape_Ptr_HausdorffDistanceExtractor_delete_excsafe(obj);

	if(isExc)
		handleException();
}


public static  System.IntPtr shape_Ptr_HausdorffDistanceExtractor_get( System.IntPtr obj )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.shape_Ptr_HausdorffDistanceExtractor_get_excsafe(ref ret, obj);

	if(isExc)
		handleException();
	return ret;
}


public static  void shape_HausdorffDistanceExtractor_setDistanceFlag( System.IntPtr obj ,  System.Int32 val )
{
	bool isExc = NativeMethodsExc.shape_HausdorffDistanceExtractor_setDistanceFlag_excsafe(obj, val);

	if(isExc)
		handleException();
}


public static  System.Int32 shape_HausdorffDistanceExtractor_getDistanceFlag( System.IntPtr obj )
{
	System.Int32 ret = new System.Int32();
	bool isExc = NativeMethodsExc.shape_HausdorffDistanceExtractor_getDistanceFlag_excsafe(ref ret, obj);

	if(isExc)
		handleException();
	return ret;
}


public static  void shape_HausdorffDistanceExtractor_setRankProportion( System.IntPtr obj ,  System.Single val )
{
	bool isExc = NativeMethodsExc.shape_HausdorffDistanceExtractor_setRankProportion_excsafe(obj, val);

	if(isExc)
		handleException();
}


public static  System.Single shape_HausdorffDistanceExtractor_getRankProportion( System.IntPtr obj )
{
	System.Single ret = new System.Single();
	bool isExc = NativeMethodsExc.shape_HausdorffDistanceExtractor_getRankProportion_excsafe(ref ret, obj);

	if(isExc)
		handleException();
	return ret;
}


public static  System.IntPtr shape_createHausdorffDistanceExtractor( System.Int32 distanceFlag ,  System.Single rankProp )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.shape_createHausdorffDistanceExtractor_excsafe(ref ret, distanceFlag, rankProp);

	if(isExc)
		handleException();
	return ret;
}


public static  System.Boolean tracking_Tracker_init( System.IntPtr obj ,  System.IntPtr image ,  OpenCvSharp.Rect2d boundingBox )
{
	System.Boolean ret = new System.Boolean();
	bool isExc = NativeMethodsExc.tracking_Tracker_init_excsafe(ref ret, obj, image, boundingBox);

	if(isExc)
		handleException();
	return ret;
}


public static  System.Boolean tracking_Tracker_update( System.IntPtr obj ,  System.IntPtr image ,  ref OpenCvSharp.Rect2d boundingBox )
{
	System.Boolean ret = new System.Boolean();
	bool isExc = NativeMethodsExc.tracking_Tracker_update_excsafe(ref ret, obj, image,  ref boundingBox);

	if(isExc)
		handleException();
	return ret;
}


public static  void tracking_Ptr_Tracker_delete( System.IntPtr ptr )
{
	bool isExc = NativeMethodsExc.tracking_Ptr_Tracker_delete_excsafe(ptr);

	if(isExc)
		handleException();
}


public static  System.IntPtr tracking_Ptr_Tracker_get( System.IntPtr ptr )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.tracking_Ptr_Tracker_get_excsafe(ref ret, ptr);

	if(isExc)
		handleException();
	return ret;
}


public static  System.IntPtr tracking_TrackerKCF_create1()
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.tracking_TrackerKCF_create1_excsafe(ref ret);

	if(isExc)
		handleException();
	return ret;
}


public static  System.IntPtr tracking_TrackerKCF_create2( OpenCvSharp.Tracking.TrackerKCF.Params parameters )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.tracking_TrackerKCF_create2_excsafe(ref ret, parameters);

	if(isExc)
		handleException();
	return ret;
}


public static  void tracking_Ptr_TrackerKCF_delete( System.IntPtr ptr )
{
	bool isExc = NativeMethodsExc.tracking_Ptr_TrackerKCF_delete_excsafe(ptr);

	if(isExc)
		handleException();
}


public static  System.IntPtr tracking_Ptr_TrackerKCF_get( System.IntPtr ptr )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.tracking_Ptr_TrackerKCF_get_excsafe(ref ret, ptr);

	if(isExc)
		handleException();
	return ret;
}


public static  System.IntPtr tracking_TrackerMIL_create1()
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.tracking_TrackerMIL_create1_excsafe(ref ret);

	if(isExc)
		handleException();
	return ret;
}


public static  unsafe System.IntPtr tracking_TrackerMIL_create2( OpenCvSharp.Tracking.TrackerMIL.Params* parameters )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.tracking_TrackerMIL_create2_excsafe(ref ret, parameters);

	if(isExc)
		handleException();
	return ret;
}


public static  void tracking_Ptr_TrackerMIL_delete( System.IntPtr ptr )
{
	bool isExc = NativeMethodsExc.tracking_Ptr_TrackerMIL_delete_excsafe(ptr);

	if(isExc)
		handleException();
}


public static  System.IntPtr tracking_Ptr_TrackerMIL_get( System.IntPtr ptr )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.tracking_Ptr_TrackerMIL_get_excsafe(ref ret, ptr);

	if(isExc)
		handleException();
	return ret;
}


public static  System.IntPtr tracking_TrackerBoosting_create1()
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.tracking_TrackerBoosting_create1_excsafe(ref ret);

	if(isExc)
		handleException();
	return ret;
}


public static  unsafe System.IntPtr tracking_TrackerBoosting_create2( OpenCvSharp.Tracking.TrackerBoosting.Params* parameters )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.tracking_TrackerBoosting_create2_excsafe(ref ret, parameters);

	if(isExc)
		handleException();
	return ret;
}


public static  void tracking_Ptr_TrackerBoosting_delete( System.IntPtr ptr )
{
	bool isExc = NativeMethodsExc.tracking_Ptr_TrackerBoosting_delete_excsafe(ptr);

	if(isExc)
		handleException();
}


public static  System.IntPtr tracking_Ptr_TrackerBoosting_get( System.IntPtr ptr )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.tracking_Ptr_TrackerBoosting_get_excsafe(ref ret, ptr);

	if(isExc)
		handleException();
	return ret;
}


public static  System.IntPtr tracking_TrackerMedianFlow_create1()
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.tracking_TrackerMedianFlow_create1_excsafe(ref ret);

	if(isExc)
		handleException();
	return ret;
}


public static  unsafe System.IntPtr tracking_TrackerMedianFlow_create2( OpenCvSharp.Tracking.TrackerMedianFlow.Params* parameters )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.tracking_TrackerMedianFlow_create2_excsafe(ref ret, parameters);

	if(isExc)
		handleException();
	return ret;
}


public static  void photo_Ptr_CalibrateDebevec_delete( System.IntPtr obj )
{
	bool isExc = NativeMethodsExc.photo_Ptr_CalibrateDebevec_delete_excsafe(obj);

	if(isExc)
		handleException();
}


public static  void photo_Ptr_CalibrateRobertson_delete( System.IntPtr obj )
{
	bool isExc = NativeMethodsExc.photo_Ptr_CalibrateRobertson_delete_excsafe(obj);

	if(isExc)
		handleException();
}


public static  System.IntPtr photo_Ptr_CalibrateDebevec_get( System.IntPtr obj )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.photo_Ptr_CalibrateDebevec_get_excsafe(ref ret, obj);

	if(isExc)
		handleException();
	return ret;
}


public static  System.IntPtr photo_Ptr_CalibrateRobertson_get( System.IntPtr obj )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.photo_Ptr_CalibrateRobertson_get_excsafe(ref ret, obj);

	if(isExc)
		handleException();
	return ret;
}


public static  void photo_CalibrateCRF_process( System.IntPtr obj ,  System.IntPtr[] srcImgs ,  System.Int32 srcImgsLength ,  System.IntPtr dst , [In, MarshalAs(UnmanagedType.LPArray)] System.Single[] times )
{
	bool isExc = NativeMethodsExc.photo_CalibrateCRF_process_excsafe(obj, srcImgs, srcImgsLength, dst, times);

	if(isExc)
		handleException();
}


public static  System.Single shape_ShapeDistanceExtractor_computeDistance( System.IntPtr obj ,  System.IntPtr contour1 ,  System.IntPtr contour2 )
{
	System.Single ret = new System.Single();
	bool isExc = NativeMethodsExc.shape_ShapeDistanceExtractor_computeDistance_excsafe(ref ret, obj, contour1, contour2);

	if(isExc)
		handleException();
	return ret;
}


public static  void shape_Ptr_ShapeContextDistanceExtractor_delete( System.IntPtr obj )
{
	bool isExc = NativeMethodsExc.shape_Ptr_ShapeContextDistanceExtractor_delete_excsafe(obj);

	if(isExc)
		handleException();
}


public static  System.IntPtr shape_Ptr_ShapeContextDistanceExtractor_get( System.IntPtr obj )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.shape_Ptr_ShapeContextDistanceExtractor_get_excsafe(ref ret, obj);

	if(isExc)
		handleException();
	return ret;
}


public static  void shape_ShapeContextDistanceExtractor_setAngularBins( System.IntPtr obj ,  System.Int32 val )
{
	bool isExc = NativeMethodsExc.shape_ShapeContextDistanceExtractor_setAngularBins_excsafe(obj, val);

	if(isExc)
		handleException();
}


public static  System.Int32 shape_ShapeContextDistanceExtractor_getAngularBins( System.IntPtr obj )
{
	System.Int32 ret = new System.Int32();
	bool isExc = NativeMethodsExc.shape_ShapeContextDistanceExtractor_getAngularBins_excsafe(ref ret, obj);

	if(isExc)
		handleException();
	return ret;
}


public static  void shape_ShapeContextDistanceExtractor_setRadialBins( System.IntPtr obj ,  System.Int32 val )
{
	bool isExc = NativeMethodsExc.shape_ShapeContextDistanceExtractor_setRadialBins_excsafe(obj, val);

	if(isExc)
		handleException();
}


public static  System.Int32 shape_ShapeContextDistanceExtractor_getRadialBins( System.IntPtr obj )
{
	System.Int32 ret = new System.Int32();
	bool isExc = NativeMethodsExc.shape_ShapeContextDistanceExtractor_getRadialBins_excsafe(ref ret, obj);

	if(isExc)
		handleException();
	return ret;
}


public static  void shape_ShapeContextDistanceExtractor_setInnerRadius( System.IntPtr obj ,  System.Single val )
{
	bool isExc = NativeMethodsExc.shape_ShapeContextDistanceExtractor_setInnerRadius_excsafe(obj, val);

	if(isExc)
		handleException();
}


public static  System.Single shape_ShapeContextDistanceExtractor_getInnerRadius( System.IntPtr obj )
{
	System.Single ret = new System.Single();
	bool isExc = NativeMethodsExc.shape_ShapeContextDistanceExtractor_getInnerRadius_excsafe(ref ret, obj);

	if(isExc)
		handleException();
	return ret;
}


public static  void shape_ShapeContextDistanceExtractor_setOuterRadius( System.IntPtr obj ,  System.Single val )
{
	bool isExc = NativeMethodsExc.shape_ShapeContextDistanceExtractor_setOuterRadius_excsafe(obj, val);

	if(isExc)
		handleException();
}


public static  System.Single shape_ShapeContextDistanceExtractor_getOuterRadius( System.IntPtr obj )
{
	System.Single ret = new System.Single();
	bool isExc = NativeMethodsExc.shape_ShapeContextDistanceExtractor_getOuterRadius_excsafe(ref ret, obj);

	if(isExc)
		handleException();
	return ret;
}


public static  void shape_ShapeContextDistanceExtractor_setRotationInvariant( System.IntPtr obj ,  System.Int32 val )
{
	bool isExc = NativeMethodsExc.shape_ShapeContextDistanceExtractor_setRotationInvariant_excsafe(obj, val);

	if(isExc)
		handleException();
}


public static  System.Int32 shape_ShapeContextDistanceExtractor_getRotationInvariant( System.IntPtr obj )
{
	System.Int32 ret = new System.Int32();
	bool isExc = NativeMethodsExc.shape_ShapeContextDistanceExtractor_getRotationInvariant_excsafe(ref ret, obj);

	if(isExc)
		handleException();
	return ret;
}


public static  void shape_ShapeContextDistanceExtractor_setShapeContextWeight( System.IntPtr obj ,  System.Single val )
{
	bool isExc = NativeMethodsExc.shape_ShapeContextDistanceExtractor_setShapeContextWeight_excsafe(obj, val);

	if(isExc)
		handleException();
}


public static  System.Single shape_ShapeContextDistanceExtractor_getShapeContextWeight( System.IntPtr obj )
{
	System.Single ret = new System.Single();
	bool isExc = NativeMethodsExc.shape_ShapeContextDistanceExtractor_getShapeContextWeight_excsafe(ref ret, obj);

	if(isExc)
		handleException();
	return ret;
}


public static  void shape_ShapeContextDistanceExtractor_setImageAppearanceWeight( System.IntPtr obj ,  System.Single val )
{
	bool isExc = NativeMethodsExc.shape_ShapeContextDistanceExtractor_setImageAppearanceWeight_excsafe(obj, val);

	if(isExc)
		handleException();
}


public static  System.Single shape_ShapeContextDistanceExtractor_getImageAppearanceWeight( System.IntPtr obj )
{
	System.Single ret = new System.Single();
	bool isExc = NativeMethodsExc.shape_ShapeContextDistanceExtractor_getImageAppearanceWeight_excsafe(ref ret, obj);

	if(isExc)
		handleException();
	return ret;
}


public static  void shape_ShapeContextDistanceExtractor_setBendingEnergyWeight( System.IntPtr obj ,  System.Single val )
{
	bool isExc = NativeMethodsExc.shape_ShapeContextDistanceExtractor_setBendingEnergyWeight_excsafe(obj, val);

	if(isExc)
		handleException();
}


public static  System.Single shape_ShapeContextDistanceExtractor_getBendingEnergyWeight( System.IntPtr obj )
{
	System.Single ret = new System.Single();
	bool isExc = NativeMethodsExc.shape_ShapeContextDistanceExtractor_getBendingEnergyWeight_excsafe(ref ret, obj);

	if(isExc)
		handleException();
	return ret;
}


public static  void shape_ShapeContextDistanceExtractor_setImages( System.IntPtr obj ,  System.IntPtr image1 ,  System.IntPtr image2 )
{
	bool isExc = NativeMethodsExc.shape_ShapeContextDistanceExtractor_setImages_excsafe(obj, image1, image2);

	if(isExc)
		handleException();
}


public static  void shape_ShapeContextDistanceExtractor_getImages( System.IntPtr obj ,  System.IntPtr image1 ,  System.IntPtr image2 )
{
	bool isExc = NativeMethodsExc.shape_ShapeContextDistanceExtractor_getImages_excsafe(obj, image1, image2);

	if(isExc)
		handleException();
}


public static  void shape_ShapeContextDistanceExtractor_setIterations( System.IntPtr obj ,  System.Int32 val )
{
	bool isExc = NativeMethodsExc.shape_ShapeContextDistanceExtractor_setIterations_excsafe(obj, val);

	if(isExc)
		handleException();
}


public static  System.Int32 shape_ShapeContextDistanceExtractor_getIterations( System.IntPtr obj )
{
	System.Int32 ret = new System.Int32();
	bool isExc = NativeMethodsExc.shape_ShapeContextDistanceExtractor_getIterations_excsafe(ref ret, obj);

	if(isExc)
		handleException();
	return ret;
}


public static  System.Single xphoto_SimpleWB_InputMin_get( System.IntPtr prt )
{
	System.Single ret = new System.Single();
	bool isExc = NativeMethodsExc.xphoto_SimpleWB_InputMin_get_excsafe(ref ret, prt);

	if(isExc)
		handleException();
	return ret;
}


public static  System.Single xphoto_SimpleWB_InputMin_set( System.IntPtr prt ,  System.Single value )
{
	System.Single ret = new System.Single();
	bool isExc = NativeMethodsExc.xphoto_SimpleWB_InputMin_set_excsafe(ref ret, prt, value);

	if(isExc)
		handleException();
	return ret;
}


public static  System.Single xphoto_SimpleWB_OutputMax_get( System.IntPtr prt )
{
	System.Single ret = new System.Single();
	bool isExc = NativeMethodsExc.xphoto_SimpleWB_OutputMax_get_excsafe(ref ret, prt);

	if(isExc)
		handleException();
	return ret;
}


public static  System.Single xphoto_SimpleWB_OutputMax_set( System.IntPtr prt ,  System.Single value )
{
	System.Single ret = new System.Single();
	bool isExc = NativeMethodsExc.xphoto_SimpleWB_OutputMax_set_excsafe(ref ret, prt, value);

	if(isExc)
		handleException();
	return ret;
}


public static  System.Single xphoto_SimpleWB_OutputMin_get( System.IntPtr prt )
{
	System.Single ret = new System.Single();
	bool isExc = NativeMethodsExc.xphoto_SimpleWB_OutputMin_get_excsafe(ref ret, prt);

	if(isExc)
		handleException();
	return ret;
}


public static  System.Single xphoto_SimpleWB_OutputMin_set( System.IntPtr prt ,  System.Single value )
{
	System.Single ret = new System.Single();
	bool isExc = NativeMethodsExc.xphoto_SimpleWB_OutputMin_set_excsafe(ref ret, prt, value);

	if(isExc)
		handleException();
	return ret;
}


public static  System.Single xphoto_SimpleWB_P_get( System.IntPtr prt )
{
	System.Single ret = new System.Single();
	bool isExc = NativeMethodsExc.xphoto_SimpleWB_P_get_excsafe(ref ret, prt);

	if(isExc)
		handleException();
	return ret;
}


public static  System.Single xphoto_SimpleWB_P_set( System.IntPtr prt ,  System.Single value )
{
	System.Single ret = new System.Single();
	bool isExc = NativeMethodsExc.xphoto_SimpleWB_P_set_excsafe(ref ret, prt, value);

	if(isExc)
		handleException();
	return ret;
}


public static  void xphoto_dctDenoising( System.IntPtr src ,  System.IntPtr dst ,  System.Double sigma ,  System.Int32 psize )
{
	bool isExc = NativeMethodsExc.xphoto_dctDenoising_excsafe(src, dst, sigma, psize);

	if(isExc)
		handleException();
}


public static  void xphoto_bm3dDenoising1( System.IntPtr src ,  System.IntPtr dstStep1 ,  System.IntPtr dstStep2 ,  System.Single h ,  System.Int32 templateWindowSize ,  System.Int32 searchWindowSize ,  System.Int32 blockMatchingStep1 ,  System.Int32 blockMatchingStep2 ,  System.Int32 groupSize ,  System.Int32 slidingStep ,  System.Single beta ,  System.Int32 normType ,  System.Int32 step ,  System.Int32 transformType )
{
	bool isExc = NativeMethodsExc.xphoto_bm3dDenoising1_excsafe(src, dstStep1, dstStep2, h, templateWindowSize, searchWindowSize, blockMatchingStep1, blockMatchingStep2, groupSize, slidingStep, beta, normType, step, transformType);

	if(isExc)
		handleException();
}


public static  void xphoto_bm3dDenoising2( System.IntPtr src ,  System.IntPtr dst ,  System.Single h ,  System.Int32 templateWindowSize ,  System.Int32 searchWindowSize ,  System.Int32 blockMatchingStep1 ,  System.Int32 blockMatchingStep2 ,  System.Int32 groupSize ,  System.Int32 slidingStep ,  System.Single beta ,  System.Int32 normType ,  System.Int32 step ,  System.Int32 transformType )
{
	bool isExc = NativeMethodsExc.xphoto_bm3dDenoising2_excsafe(src, dst, h, templateWindowSize, searchWindowSize, blockMatchingStep1, blockMatchingStep2, groupSize, slidingStep, beta, normType, step, transformType);

	if(isExc)
		handleException();
}


public static  void photo_inpaint( System.IntPtr src ,  System.IntPtr inpaintMask ,  System.IntPtr dst ,  System.Double inpaintRadius ,  System.Int32 flags )
{
	bool isExc = NativeMethodsExc.photo_inpaint_excsafe(src, inpaintMask, dst, inpaintRadius, flags);

	if(isExc)
		handleException();
}


public static  void photo_fastNlMeansDenoising( System.IntPtr src ,  System.IntPtr dst ,  System.Single h ,  System.Int32 templateWindowSize ,  System.Int32 searchWindowSize )
{
	bool isExc = NativeMethodsExc.photo_fastNlMeansDenoising_excsafe(src, dst, h, templateWindowSize, searchWindowSize);

	if(isExc)
		handleException();
}


public static  void photo_fastNlMeansDenoisingColored( System.IntPtr src ,  System.IntPtr dst ,  System.Single h ,  System.Single hColor ,  System.Int32 templateWindowSize ,  System.Int32 searchWindowSize )
{
	bool isExc = NativeMethodsExc.photo_fastNlMeansDenoisingColored_excsafe(src, dst, h, hColor, templateWindowSize, searchWindowSize);

	if(isExc)
		handleException();
}


public static  void photo_fastNlMeansDenoisingMulti( System.IntPtr[] srcImgs ,  System.Int32 srcImgsLength ,  System.IntPtr dst ,  System.Int32 imgToDenoiseIndex ,  System.Int32 temporalWindowSize ,  System.Single h ,  System.Int32 templateWindowSize ,  System.Int32 searchWindowSize )
{
	bool isExc = NativeMethodsExc.photo_fastNlMeansDenoisingMulti_excsafe(srcImgs, srcImgsLength, dst, imgToDenoiseIndex, temporalWindowSize, h, templateWindowSize, searchWindowSize);

	if(isExc)
		handleException();
}


public static  void photo_fastNlMeansDenoisingColoredMulti( System.IntPtr[] srcImgs ,  System.Int32 srcImgsLength ,  System.IntPtr dst ,  System.Int32 imgToDenoiseIndex ,  System.Int32 temporalWindowSize ,  System.Single h ,  System.Single hColor ,  System.Int32 templateWindowSize ,  System.Int32 searchWindowSize )
{
	bool isExc = NativeMethodsExc.photo_fastNlMeansDenoisingColoredMulti_excsafe(srcImgs, srcImgsLength, dst, imgToDenoiseIndex, temporalWindowSize, h, hColor, templateWindowSize, searchWindowSize);

	if(isExc)
		handleException();
}


public static  void photo_denoise_TVL1( System.IntPtr[] observations ,  System.Int32 observationsSize ,  System.IntPtr result ,  System.Double lambda ,  System.Int32 niters )
{
	bool isExc = NativeMethodsExc.photo_denoise_TVL1_excsafe(observations, observationsSize, result, lambda, niters);

	if(isExc)
		handleException();
}


public static  void photo_decolor( System.IntPtr src ,  System.IntPtr grayscale ,  System.IntPtr color_boost )
{
	bool isExc = NativeMethodsExc.photo_decolor_excsafe(src, grayscale, color_boost);

	if(isExc)
		handleException();
}


public static  void photo_seamlessClone( System.IntPtr src ,  System.IntPtr dst ,  System.IntPtr mask ,  OpenCvSharp.Point p ,  System.IntPtr blend ,  System.Int32 flags )
{
	bool isExc = NativeMethodsExc.photo_seamlessClone_excsafe(src, dst, mask, p, blend, flags);

	if(isExc)
		handleException();
}


public static  void photo_colorChange( System.IntPtr src ,  System.IntPtr mask ,  System.IntPtr dst ,  System.Single red_mul ,  System.Single green_mul ,  System.Single blue_mul )
{
	bool isExc = NativeMethodsExc.photo_colorChange_excsafe(src, mask, dst, red_mul, green_mul, blue_mul);

	if(isExc)
		handleException();
}


public static  void photo_illuminationChange( System.IntPtr src ,  System.IntPtr mask ,  System.IntPtr dst ,  System.Single alpha ,  System.Single beta )
{
	bool isExc = NativeMethodsExc.photo_illuminationChange_excsafe(src, mask, dst, alpha, beta);

	if(isExc)
		handleException();
}


public static  void photo_textureFlattening( System.IntPtr src ,  System.IntPtr mask ,  System.IntPtr dst ,  System.Single low_threshold ,  System.Single high_threshold ,  System.Int32 kernel_size )
{
	bool isExc = NativeMethodsExc.photo_textureFlattening_excsafe(src, mask, dst, low_threshold, high_threshold, kernel_size);

	if(isExc)
		handleException();
}


public static  void photo_edgePreservingFilter( System.IntPtr src ,  System.IntPtr dst ,  System.Int32 flags ,  System.Single sigma_s ,  System.Single sigma_r )
{
	bool isExc = NativeMethodsExc.photo_edgePreservingFilter_excsafe(src, dst, flags, sigma_s, sigma_r);

	if(isExc)
		handleException();
}


public static  void photo_detailEnhance( System.IntPtr src ,  System.IntPtr dst ,  System.Single sigma_s ,  System.Single sigma_r )
{
	bool isExc = NativeMethodsExc.photo_detailEnhance_excsafe(src, dst, sigma_s, sigma_r);

	if(isExc)
		handleException();
}


public static  void photo_pencilSketch( System.IntPtr src ,  System.IntPtr dst1 ,  System.IntPtr dst2 ,  System.Single sigma_s ,  System.Single sigma_r ,  System.Single shade_factor )
{
	bool isExc = NativeMethodsExc.photo_pencilSketch_excsafe(src, dst1, dst2, sigma_s, sigma_r, shade_factor);

	if(isExc)
		handleException();
}


public static  void photo_stylization( System.IntPtr src ,  System.IntPtr dst ,  System.Single sigma_s ,  System.Single sigma_r )
{
	bool isExc = NativeMethodsExc.photo_stylization_excsafe(src, dst, sigma_s, sigma_r);

	if(isExc)
		handleException();
}


public static  System.IntPtr photo_createCalibrateDebevec( System.Int32 samples ,  System.Single lambda ,  System.Int32 random )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.photo_createCalibrateDebevec_excsafe(ref ret, samples, lambda, random);

	if(isExc)
		handleException();
	return ret;
}


public static  System.IntPtr photo_createCalibrateRobertson( System.Int32 maxIter ,  System.Single threshold )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.photo_createCalibrateRobertson_excsafe(ref ret, maxIter, threshold);

	if(isExc)
		handleException();
	return ret;
}


public static  System.IntPtr xfeatures2d_SIFT_create( System.Int32 nfeatures ,  System.Int32 nOctaveLayers ,  System.Double contrastThreshold ,  System.Double edgeThreshold ,  System.Double sigma )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.xfeatures2d_SIFT_create_excsafe(ref ret, nfeatures, nOctaveLayers, contrastThreshold, edgeThreshold, sigma);

	if(isExc)
		handleException();
	return ret;
}


public static  void xfeatures2d_Ptr_SIFT_delete( System.IntPtr ptr )
{
	bool isExc = NativeMethodsExc.xfeatures2d_Ptr_SIFT_delete_excsafe(ptr);

	if(isExc)
		handleException();
}


public static  System.IntPtr xfeatures2d_Ptr_SIFT_get( System.IntPtr ptr )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.xfeatures2d_Ptr_SIFT_get_excsafe(ref ret, ptr);

	if(isExc)
		handleException();
	return ret;
}


public static  void xphoto_inpaint( System.IntPtr prt ,  System.IntPtr src ,  System.IntPtr dst ,  System.Int32 algorithm )
{
	bool isExc = NativeMethodsExc.xphoto_inpaint_excsafe(prt, src, dst, algorithm);

	if(isExc)
		handleException();
}


public static  System.IntPtr xphoto_applyChannelGains( System.IntPtr src ,  System.IntPtr dst ,  System.Single gainB ,  System.Single gainG ,  System.Single gainR )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.xphoto_applyChannelGains_excsafe(ref ret, src, dst, gainB, gainG, gainR);

	if(isExc)
		handleException();
	return ret;
}


public static  System.IntPtr xphoto_createGrayworldWB()
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.xphoto_createGrayworldWB_excsafe(ref ret);

	if(isExc)
		handleException();
	return ret;
}


public static  void xphoto_Ptr_GrayworldWB_delete( System.IntPtr prt )
{
	bool isExc = NativeMethodsExc.xphoto_Ptr_GrayworldWB_delete_excsafe(prt);

	if(isExc)
		handleException();
}


public static  System.IntPtr xphoto_Ptr_GrayworldWB_get( System.IntPtr prt )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.xphoto_Ptr_GrayworldWB_get_excsafe(ref ret, prt);

	if(isExc)
		handleException();
	return ret;
}


public static  void xphoto_GrayworldWB_balanceWhite( System.IntPtr prt ,  System.IntPtr src ,  System.IntPtr dst )
{
	bool isExc = NativeMethodsExc.xphoto_GrayworldWB_balanceWhite_excsafe(prt, src, dst);

	if(isExc)
		handleException();
}


public static  System.Single xphoto_GrayworldWB_SaturationThreshold_get( System.IntPtr ptr )
{
	System.Single ret = new System.Single();
	bool isExc = NativeMethodsExc.xphoto_GrayworldWB_SaturationThreshold_get_excsafe(ref ret, ptr);

	if(isExc)
		handleException();
	return ret;
}


public static  void xphoto_GrayworldWB_SaturationThreshold_set( System.IntPtr ptr ,  System.Single val )
{
	bool isExc = NativeMethodsExc.xphoto_GrayworldWB_SaturationThreshold_set_excsafe(ptr, val);

	if(isExc)
		handleException();
}


public static  System.IntPtr xphoto_createLearningBasedWB( System.String trackerType )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.xphoto_createLearningBasedWB_excsafe(ref ret, trackerType);

	if(isExc)
		handleException();
	return ret;
}


public static  void xphoto_Ptr_LearningBasedWB_delete( System.IntPtr prt )
{
	bool isExc = NativeMethodsExc.xphoto_Ptr_LearningBasedWB_delete_excsafe(prt);

	if(isExc)
		handleException();
}


public static  System.IntPtr xphoto_Ptr_LearningBasedWB_get( System.IntPtr prt )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.xphoto_Ptr_LearningBasedWB_get_excsafe(ref ret, prt);

	if(isExc)
		handleException();
	return ret;
}


public static  void xphoto_LearningBasedWB_balanceWhite( System.IntPtr prt ,  System.IntPtr src ,  System.IntPtr dst )
{
	bool isExc = NativeMethodsExc.xphoto_LearningBasedWB_balanceWhite_excsafe(prt, src, dst);

	if(isExc)
		handleException();
}


public static  void xphoto_LearningBasedWB_extractSimpleFeatures( System.IntPtr prt ,  System.IntPtr src ,  System.IntPtr dst )
{
	bool isExc = NativeMethodsExc.xphoto_LearningBasedWB_extractSimpleFeatures_excsafe(prt, src, dst);

	if(isExc)
		handleException();
}


public static  void xphoto_LearningBasedWB_HistBinNum_set( System.IntPtr prt ,  System.Int32 value )
{
	bool isExc = NativeMethodsExc.xphoto_LearningBasedWB_HistBinNum_set_excsafe(prt, value);

	if(isExc)
		handleException();
}


public static  void xphoto_LearningBasedWB_RangeMaxVal_set( System.IntPtr prt ,  System.Int32 value )
{
	bool isExc = NativeMethodsExc.xphoto_LearningBasedWB_RangeMaxVal_set_excsafe(prt, value);

	if(isExc)
		handleException();
}


public static  System.Single xphoto_LearningBasedWB_SaturationThreshold_set( System.IntPtr prt ,  System.Single value )
{
	System.Single ret = new System.Single();
	bool isExc = NativeMethodsExc.xphoto_LearningBasedWB_SaturationThreshold_set_excsafe(ref ret, prt, value);

	if(isExc)
		handleException();
	return ret;
}


public static  System.Int32 xphoto_LearningBasedWB_HistBinNum_get( System.IntPtr prt )
{
	System.Int32 ret = new System.Int32();
	bool isExc = NativeMethodsExc.xphoto_LearningBasedWB_HistBinNum_get_excsafe(ref ret, prt);

	if(isExc)
		handleException();
	return ret;
}


public static  System.Int32 xphoto_LearningBasedWB_RangeMaxVal_get( System.IntPtr prt )
{
	System.Int32 ret = new System.Int32();
	bool isExc = NativeMethodsExc.xphoto_LearningBasedWB_RangeMaxVal_get_excsafe(ref ret, prt);

	if(isExc)
		handleException();
	return ret;
}


public static  System.Single xphoto_LearningBasedWB_SaturationThreshold_get( System.IntPtr prt )
{
	System.Single ret = new System.Single();
	bool isExc = NativeMethodsExc.xphoto_LearningBasedWB_SaturationThreshold_get_excsafe(ref ret, prt);

	if(isExc)
		handleException();
	return ret;
}


public static  System.IntPtr xphoto_createSimpleWB()
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.xphoto_createSimpleWB_excsafe(ref ret);

	if(isExc)
		handleException();
	return ret;
}


public static  void xphoto_Ptr_SimpleWB_delete( System.IntPtr prt )
{
	bool isExc = NativeMethodsExc.xphoto_Ptr_SimpleWB_delete_excsafe(prt);

	if(isExc)
		handleException();
}


public static  System.IntPtr xphoto_Ptr_SimpleWB_get( System.IntPtr prt )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.xphoto_Ptr_SimpleWB_get_excsafe(ref ret, prt);

	if(isExc)
		handleException();
	return ret;
}


public static  void xphoto_SimpleWB_balanceWhite( System.IntPtr prt ,  System.IntPtr src ,  System.IntPtr dst )
{
	bool isExc = NativeMethodsExc.xphoto_SimpleWB_balanceWhite_excsafe(prt, src, dst);

	if(isExc)
		handleException();
}


public static  System.Single xphoto_SimpleWB_InputMax_get( System.IntPtr prt )
{
	System.Single ret = new System.Single();
	bool isExc = NativeMethodsExc.xphoto_SimpleWB_InputMax_get_excsafe(ref ret, prt);

	if(isExc)
		handleException();
	return ret;
}


public static  System.Single xphoto_SimpleWB_InputMax_set( System.IntPtr prt ,  System.Single value )
{
	System.Single ret = new System.Single();
	bool isExc = NativeMethodsExc.xphoto_SimpleWB_InputMax_set_excsafe(ref ret, prt, value);

	if(isExc)
		handleException();
	return ret;
}


public static  System.Int32 xfeatures2d_BriefDescriptorExtractor_descriptorSize( System.IntPtr obj )
{
	System.Int32 ret = new System.Int32();
	bool isExc = NativeMethodsExc.xfeatures2d_BriefDescriptorExtractor_descriptorSize_excsafe(ref ret, obj);

	if(isExc)
		handleException();
	return ret;
}


public static  System.Int32 xfeatures2d_BriefDescriptorExtractor_descriptorType( System.IntPtr obj )
{
	System.Int32 ret = new System.Int32();
	bool isExc = NativeMethodsExc.xfeatures2d_BriefDescriptorExtractor_descriptorType_excsafe(ref ret, obj);

	if(isExc)
		handleException();
	return ret;
}


public static  System.IntPtr xfeatures2d_Ptr_BriefDescriptorExtractor_get( System.IntPtr ptr )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.xfeatures2d_Ptr_BriefDescriptorExtractor_get_excsafe(ref ret, ptr);

	if(isExc)
		handleException();
	return ret;
}


public static  System.IntPtr xfeatures2d_FREAK_create( System.Int32 orientationNormalized ,  System.Int32 scaleNormalized ,  System.Single patternScale ,  System.Int32 nOctaves ,  System.Int32[] selectedPairs ,  System.Int32 selectedPairsLength )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.xfeatures2d_FREAK_create_excsafe(ref ret, orientationNormalized, scaleNormalized, patternScale, nOctaves, selectedPairs, selectedPairsLength);

	if(isExc)
		handleException();
	return ret;
}


public static  void xfeatures2d_Ptr_FREAK_delete( System.IntPtr ptr )
{
	bool isExc = NativeMethodsExc.xfeatures2d_Ptr_FREAK_delete_excsafe(ptr);

	if(isExc)
		handleException();
}


public static  System.IntPtr xfeatures2d_Ptr_FREAK_get( System.IntPtr ptr )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.xfeatures2d_Ptr_FREAK_get_excsafe(ref ret, ptr);

	if(isExc)
		handleException();
	return ret;
}


public static  System.IntPtr xfeatures2d_StarDetector_create( System.Int32 maxSize ,  System.Int32 responseThreshold ,  System.Int32 lineThresholdProjected ,  System.Int32 lineThresholdBinarized ,  System.Int32 suppressNonmaxSize )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.xfeatures2d_StarDetector_create_excsafe(ref ret, maxSize, responseThreshold, lineThresholdProjected, lineThresholdBinarized, suppressNonmaxSize);

	if(isExc)
		handleException();
	return ret;
}


public static  void xfeatures2d_Ptr_StarDetector_delete( System.IntPtr ptr )
{
	bool isExc = NativeMethodsExc.xfeatures2d_Ptr_StarDetector_delete_excsafe(ptr);

	if(isExc)
		handleException();
}


public static  System.IntPtr xfeatures2d_Ptr_StarDetector_get( System.IntPtr ptr )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.xfeatures2d_Ptr_StarDetector_get_excsafe(ref ret, ptr);

	if(isExc)
		handleException();
	return ret;
}


public static  System.IntPtr xfeatures2d_LUCID_create( System.Int32 lucid_kernel  = 1,  System.Int32 blur_kernel  = 2)
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.xfeatures2d_LUCID_create_excsafe(ref ret, lucid_kernel, blur_kernel);

	if(isExc)
		handleException();
	return ret;
}


public static  void xfeatures2d_Ptr_LUCID_delete( System.IntPtr ptr )
{
	bool isExc = NativeMethodsExc.xfeatures2d_Ptr_LUCID_delete_excsafe(ptr);

	if(isExc)
		handleException();
}


public static  System.IntPtr xfeatures2d_Ptr_LUCID_get( System.IntPtr ptr )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.xfeatures2d_Ptr_LUCID_get_excsafe(ref ret, ptr);

	if(isExc)
		handleException();
	return ret;
}


public static  System.IntPtr xfeatures2d_LATCH_create( System.Int32 bytes ,  System.Int32 rotationInvariance ,  System.Int32 half_ssd_size ,  System.Double sigma )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.xfeatures2d_LATCH_create_excsafe(ref ret, bytes, rotationInvariance, half_ssd_size, sigma);

	if(isExc)
		handleException();
	return ret;
}


public static  void xfeatures2d_Ptr_LATCH_delete( System.IntPtr ptr )
{
	bool isExc = NativeMethodsExc.xfeatures2d_Ptr_LATCH_delete_excsafe(ptr);

	if(isExc)
		handleException();
}


public static  System.IntPtr xfeatures2d_Ptr_LATCH_get( System.IntPtr ptr )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.xfeatures2d_Ptr_LATCH_get_excsafe(ref ret, ptr);

	if(isExc)
		handleException();
	return ret;
}


public static  System.IntPtr xfeatures2d_SURF_create( System.Double hessianThreshold ,  System.Int32 nOctaves ,  System.Int32 nOctaveLayers ,  System.Int32 extended ,  System.Int32 upright )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.xfeatures2d_SURF_create_excsafe(ref ret, hessianThreshold, nOctaves, nOctaveLayers, extended, upright);

	if(isExc)
		handleException();
	return ret;
}


public static  void xfeatures2d_Ptr_SURF_delete( System.IntPtr ptr )
{
	bool isExc = NativeMethodsExc.xfeatures2d_Ptr_SURF_delete_excsafe(ptr);

	if(isExc)
		handleException();
}


public static  System.IntPtr xfeatures2d_Ptr_SURF_get( System.IntPtr ptr )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.xfeatures2d_Ptr_SURF_get_excsafe(ref ret, ptr);

	if(isExc)
		handleException();
	return ret;
}


public static  System.Double xfeatures2d_SURF_getHessianThreshold( System.IntPtr obj )
{
	System.Double ret = new System.Double();
	bool isExc = NativeMethodsExc.xfeatures2d_SURF_getHessianThreshold_excsafe(ref ret, obj);

	if(isExc)
		handleException();
	return ret;
}


public static  System.Int32 xfeatures2d_SURF_getNOctaves( System.IntPtr obj )
{
	System.Int32 ret = new System.Int32();
	bool isExc = NativeMethodsExc.xfeatures2d_SURF_getNOctaves_excsafe(ref ret, obj);

	if(isExc)
		handleException();
	return ret;
}


public static  System.Int32 xfeatures2d_SURF_getNOctaveLayers( System.IntPtr obj )
{
	System.Int32 ret = new System.Int32();
	bool isExc = NativeMethodsExc.xfeatures2d_SURF_getNOctaveLayers_excsafe(ref ret, obj);

	if(isExc)
		handleException();
	return ret;
}


public static  System.Int32 xfeatures2d_SURF_getExtended( System.IntPtr obj )
{
	System.Int32 ret = new System.Int32();
	bool isExc = NativeMethodsExc.xfeatures2d_SURF_getExtended_excsafe(ref ret, obj);

	if(isExc)
		handleException();
	return ret;
}


public static  System.Int32 xfeatures2d_SURF_getUpright( System.IntPtr obj )
{
	System.Int32 ret = new System.Int32();
	bool isExc = NativeMethodsExc.xfeatures2d_SURF_getUpright_excsafe(ref ret, obj);

	if(isExc)
		handleException();
	return ret;
}


public static  void xfeatures2d_SURF_setHessianThreshold( System.IntPtr obj ,  System.Double value )
{
	bool isExc = NativeMethodsExc.xfeatures2d_SURF_setHessianThreshold_excsafe(obj, value);

	if(isExc)
		handleException();
}


public static  void xfeatures2d_SURF_setNOctaves( System.IntPtr obj ,  System.Int32 value )
{
	bool isExc = NativeMethodsExc.xfeatures2d_SURF_setNOctaves_excsafe(obj, value);

	if(isExc)
		handleException();
}


public static  void xfeatures2d_SURF_setNOctaveLayers( System.IntPtr obj ,  System.Int32 value )
{
	bool isExc = NativeMethodsExc.xfeatures2d_SURF_setNOctaveLayers_excsafe(obj, value);

	if(isExc)
		handleException();
}


public static  void xfeatures2d_SURF_setExtended( System.IntPtr obj ,  System.Int32 value )
{
	bool isExc = NativeMethodsExc.xfeatures2d_SURF_setExtended_excsafe(obj, value);

	if(isExc)
		handleException();
}


public static  void xfeatures2d_SURF_setUpright( System.IntPtr obj ,  System.Int32 value )
{
	bool isExc = NativeMethodsExc.xfeatures2d_SURF_setUpright_excsafe(obj, value);

	if(isExc)
		handleException();
}


public static  System.IntPtr videoio_VideoCapture_new3( System.Int32 device )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.videoio_VideoCapture_new3_excsafe(ref ret, device);

	if(isExc)
		handleException();
	return ret;
}


public static  void videoio_VideoCapture_delete( System.IntPtr obj )
{
	bool isExc = NativeMethodsExc.videoio_VideoCapture_delete_excsafe(obj);

	if(isExc)
		handleException();
}


public static  System.Int32 videoio_VideoCapture_open1( System.IntPtr obj , [MarshalAs(UnmanagedType.LPStr)] System.String filename )
{
	System.Int32 ret = new System.Int32();
	bool isExc = NativeMethodsExc.videoio_VideoCapture_open1_excsafe(ref ret, obj, filename);

	if(isExc)
		handleException();
	return ret;
}


public static  System.Int32 videoio_VideoCapture_open2( System.IntPtr obj ,  System.Int32 device )
{
	System.Int32 ret = new System.Int32();
	bool isExc = NativeMethodsExc.videoio_VideoCapture_open2_excsafe(ref ret, obj, device);

	if(isExc)
		handleException();
	return ret;
}


public static  System.Int32 videoio_VideoCapture_isOpened( System.IntPtr obj )
{
	System.Int32 ret = new System.Int32();
	bool isExc = NativeMethodsExc.videoio_VideoCapture_isOpened_excsafe(ref ret, obj);

	if(isExc)
		handleException();
	return ret;
}


public static  void videoio_VideoCapture_release( System.IntPtr obj )
{
	bool isExc = NativeMethodsExc.videoio_VideoCapture_release_excsafe(obj);

	if(isExc)
		handleException();
}


public static  System.Int32 videoio_VideoCapture_grab( System.IntPtr obj )
{
	System.Int32 ret = new System.Int32();
	bool isExc = NativeMethodsExc.videoio_VideoCapture_grab_excsafe(ref ret, obj);

	if(isExc)
		handleException();
	return ret;
}


public static  System.Int32 videoio_VideoCapture_retrieve( System.IntPtr obj ,  System.IntPtr image ,  System.Int32 flag )
{
	System.Int32 ret = new System.Int32();
	bool isExc = NativeMethodsExc.videoio_VideoCapture_retrieve_excsafe(ref ret, obj, image, flag);

	if(isExc)
		handleException();
	return ret;
}


public static  void videoio_VideoCapture_operatorRightShift_Mat( System.IntPtr obj ,  System.IntPtr image )
{
	bool isExc = NativeMethodsExc.videoio_VideoCapture_operatorRightShift_Mat_excsafe(obj, image);

	if(isExc)
		handleException();
}


public static  void videoio_VideoCapture_operatorRightShift_UMat( System.IntPtr obj ,  System.IntPtr image )
{
	bool isExc = NativeMethodsExc.videoio_VideoCapture_operatorRightShift_UMat_excsafe(obj, image);

	if(isExc)
		handleException();
}


public static  System.Int32 videoio_VideoCapture_read( System.IntPtr obj ,  System.IntPtr image )
{
	System.Int32 ret = new System.Int32();
	bool isExc = NativeMethodsExc.videoio_VideoCapture_read_excsafe(ref ret, obj, image);

	if(isExc)
		handleException();
	return ret;
}


public static  System.Int32 videoio_VideoCapture_set( System.IntPtr obj ,  System.Int32 propId ,  System.Double value )
{
	System.Int32 ret = new System.Int32();
	bool isExc = NativeMethodsExc.videoio_VideoCapture_set_excsafe(ref ret, obj, propId, value);

	if(isExc)
		handleException();
	return ret;
}


public static  System.Double videoio_VideoCapture_get( System.IntPtr obj ,  System.Int32 propId )
{
	System.Double ret = new System.Double();
	bool isExc = NativeMethodsExc.videoio_VideoCapture_get_excsafe(ref ret, obj, propId);

	if(isExc)
		handleException();
	return ret;
}


public static  System.IntPtr videoio_VideoWriter_new1()
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.videoio_VideoWriter_new1_excsafe(ref ret);

	if(isExc)
		handleException();
	return ret;
}


public static  System.IntPtr videoio_VideoWriter_new2([MarshalAs(UnmanagedType.LPStr)] System.String filename ,  System.Int32 fourcc ,  System.Double fps ,  OpenCvSharp.Size frameSize ,  System.Int32 isColor )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.videoio_VideoWriter_new2_excsafe(ref ret, filename, fourcc, fps, frameSize, isColor);

	if(isExc)
		handleException();
	return ret;
}


public static  void videoio_VideoWriter_delete( System.IntPtr obj )
{
	bool isExc = NativeMethodsExc.videoio_VideoWriter_delete_excsafe(obj);

	if(isExc)
		handleException();
}


public static  System.Int32 videoio_VideoWriter_open( System.IntPtr obj , [MarshalAs(UnmanagedType.LPStr)] System.String filename ,  System.Int32 fourcc ,  System.Double fps ,  OpenCvSharp.Size frameSize ,  System.Int32 isColor )
{
	System.Int32 ret = new System.Int32();
	bool isExc = NativeMethodsExc.videoio_VideoWriter_open_excsafe(ref ret, obj, filename, fourcc, fps, frameSize, isColor);

	if(isExc)
		handleException();
	return ret;
}


public static  System.Int32 videoio_VideoWriter_isOpened( System.IntPtr obj )
{
	System.Int32 ret = new System.Int32();
	bool isExc = NativeMethodsExc.videoio_VideoWriter_isOpened_excsafe(ref ret, obj);

	if(isExc)
		handleException();
	return ret;
}


public static  void videoio_VideoWriter_release( System.IntPtr obj )
{
	bool isExc = NativeMethodsExc.videoio_VideoWriter_release_excsafe(obj);

	if(isExc)
		handleException();
}


public static  void videoio_VideoWriter_OperatorLeftShift( System.IntPtr obj ,  System.IntPtr image )
{
	bool isExc = NativeMethodsExc.videoio_VideoWriter_OperatorLeftShift_excsafe(obj, image);

	if(isExc)
		handleException();
}


public static  void videoio_VideoWriter_write( System.IntPtr obj ,  System.IntPtr image )
{
	bool isExc = NativeMethodsExc.videoio_VideoWriter_write_excsafe(obj, image);

	if(isExc)
		handleException();
}


public static  System.Int32 videoio_VideoWriter_set( System.IntPtr obj ,  System.Int32 propId ,  System.Double value )
{
	System.Int32 ret = new System.Int32();
	bool isExc = NativeMethodsExc.videoio_VideoWriter_set_excsafe(ref ret, obj, propId, value);

	if(isExc)
		handleException();
	return ret;
}


public static  System.Double videoio_VideoWriter_get( System.IntPtr obj ,  System.Int32 propId )
{
	System.Double ret = new System.Double();
	bool isExc = NativeMethodsExc.videoio_VideoWriter_get_excsafe(ref ret, obj, propId);

	if(isExc)
		handleException();
	return ret;
}


public static  System.Int32 videoio_VideoWriter_fourcc( System.Byte c1 ,  System.Byte c2 ,  System.Byte c3 ,  System.Byte c4 )
{
	System.Int32 ret = new System.Int32();
	bool isExc = NativeMethodsExc.videoio_VideoWriter_fourcc_excsafe(ref ret, c1, c2, c3, c4);

	if(isExc)
		handleException();
	return ret;
}


public static  System.IntPtr xfeatures2d_BriefDescriptorExtractor_create( System.Int32 bytes )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.xfeatures2d_BriefDescriptorExtractor_create_excsafe(ref ret, bytes);

	if(isExc)
		handleException();
	return ret;
}


public static  void xfeatures2d_Ptr_BriefDescriptorExtractor_delete( System.IntPtr obj )
{
	bool isExc = NativeMethodsExc.xfeatures2d_Ptr_BriefDescriptorExtractor_delete_excsafe(obj);

	if(isExc)
		handleException();
}


public static  void xfeatures2d_BriefDescriptorExtractor_read( System.IntPtr obj ,  System.IntPtr fn )
{
	bool isExc = NativeMethodsExc.xfeatures2d_BriefDescriptorExtractor_read_excsafe(obj, fn);

	if(isExc)
		handleException();
}


public static  void xfeatures2d_BriefDescriptorExtractor_write( System.IntPtr obj ,  System.IntPtr fs )
{
	bool isExc = NativeMethodsExc.xfeatures2d_BriefDescriptorExtractor_write_excsafe(obj, fs);

	if(isExc)
		handleException();
}


public static  void superres_SuperResolution_reset( System.IntPtr obj )
{
	bool isExc = NativeMethodsExc.superres_SuperResolution_reset_excsafe(obj);

	if(isExc)
		handleException();
}


public static  void superres_SuperResolution_collectGarbage( System.IntPtr obj )
{
	bool isExc = NativeMethodsExc.superres_SuperResolution_collectGarbage_excsafe(obj);

	if(isExc)
		handleException();
}


public static  System.IntPtr superres_createSuperResolution_BTVL1()
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.superres_createSuperResolution_BTVL1_excsafe(ref ret);

	if(isExc)
		handleException();
	return ret;
}


public static  System.IntPtr superres_createSuperResolution_BTVL1_CUDA()
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.superres_createSuperResolution_BTVL1_CUDA_excsafe(ref ret);

	if(isExc)
		handleException();
	return ret;
}


public static  System.IntPtr superres_Ptr_SuperResolution_get( System.IntPtr ptr )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.superres_Ptr_SuperResolution_get_excsafe(ref ret, ptr);

	if(isExc)
		handleException();
	return ret;
}


public static  void superres_Ptr_SuperResolution_delete( System.IntPtr ptr )
{
	bool isExc = NativeMethodsExc.superres_Ptr_SuperResolution_delete_excsafe(ptr);

	if(isExc)
		handleException();
}


public static  void superres_DenseOpticalFlowExt_calc( System.IntPtr obj ,  System.IntPtr frame0 ,  System.IntPtr frame1 ,  System.IntPtr flow1 ,  System.IntPtr flow2 )
{
	bool isExc = NativeMethodsExc.superres_DenseOpticalFlowExt_calc_excsafe(obj, frame0, frame1, flow1, flow2);

	if(isExc)
		handleException();
}


public static  void superres_DenseOpticalFlowExt_collectGarbage( System.IntPtr obj )
{
	bool isExc = NativeMethodsExc.superres_DenseOpticalFlowExt_collectGarbage_excsafe(obj);

	if(isExc)
		handleException();
}


public static  System.IntPtr superres_Ptr_DenseOpticalFlowExt_get( System.IntPtr ptr )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.superres_Ptr_DenseOpticalFlowExt_get_excsafe(ref ret, ptr);

	if(isExc)
		handleException();
	return ret;
}


public static  void superres_Ptr_DenseOpticalFlowExt_delete( System.IntPtr ptr )
{
	bool isExc = NativeMethodsExc.superres_Ptr_DenseOpticalFlowExt_delete_excsafe(ptr);

	if(isExc)
		handleException();
}


public static  System.IntPtr superres_createOptFlow_Farneback()
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.superres_createOptFlow_Farneback_excsafe(ref ret);

	if(isExc)
		handleException();
	return ret;
}


public static  System.IntPtr superres_createOptFlow_Farneback_CUDA()
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.superres_createOptFlow_Farneback_CUDA_excsafe(ref ret);

	if(isExc)
		handleException();
	return ret;
}


public static  System.IntPtr superres_createOptFlow_DualTVL1()
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.superres_createOptFlow_DualTVL1_excsafe(ref ret);

	if(isExc)
		handleException();
	return ret;
}


public static  System.IntPtr superres_createOptFlow_DualTVL1_CUDA()
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.superres_createOptFlow_DualTVL1_CUDA_excsafe(ref ret);

	if(isExc)
		handleException();
	return ret;
}


public static  System.IntPtr superres_createOptFlow_Brox_CUDA()
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.superres_createOptFlow_Brox_CUDA_excsafe(ref ret);

	if(isExc)
		handleException();
	return ret;
}


public static  System.IntPtr superres_createOptFlow_PyrLK_CUDA()
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.superres_createOptFlow_PyrLK_CUDA_excsafe(ref ret);

	if(isExc)
		handleException();
	return ret;
}


public static  void text_BaseOCR_run1( System.IntPtr obj ,  System.IntPtr image ,  System.IntPtr outputText ,  System.IntPtr componentRects ,  System.IntPtr componentTexts ,  System.IntPtr componentConfidences ,  System.Int32 componentLevel )
{
	bool isExc = NativeMethodsExc.text_BaseOCR_run1_excsafe(obj, image, outputText, componentRects, componentTexts, componentConfidences, componentLevel);

	if(isExc)
		handleException();
}


public static  void text_BaseOCR_run2( System.IntPtr obj ,  System.IntPtr image ,  System.IntPtr mask ,  System.IntPtr outputText ,  System.IntPtr componentRects ,  System.IntPtr componentTexts ,  System.IntPtr componentConfidences ,  System.Int32 componentLevel )
{
	bool isExc = NativeMethodsExc.text_BaseOCR_run2_excsafe(obj, image, mask, outputText, componentRects, componentTexts, componentConfidences, componentLevel);

	if(isExc)
		handleException();
}


public static  void text_OCRTesseract_run1( System.IntPtr obj ,  System.IntPtr image ,  System.IntPtr outputText ,  System.IntPtr componentRects ,  System.IntPtr componentTexts ,  System.IntPtr componentConfidences ,  System.Int32 componentLevel )
{
	bool isExc = NativeMethodsExc.text_OCRTesseract_run1_excsafe(obj, image, outputText, componentRects, componentTexts, componentConfidences, componentLevel);

	if(isExc)
		handleException();
}


public static  void text_OCRTesseract_run2( System.IntPtr obj ,  System.IntPtr image ,  System.IntPtr mask ,  System.IntPtr outputText ,  System.IntPtr componentRects ,  System.IntPtr componentTexts ,  System.IntPtr componentConfidences ,  System.Int32 componentLevel )
{
	bool isExc = NativeMethodsExc.text_OCRTesseract_run2_excsafe(obj, image, mask, outputText, componentRects, componentTexts, componentConfidences, componentLevel);

	if(isExc)
		handleException();
}


public static  void text_OCRTesseract_run3( System.IntPtr obj ,  System.IntPtr image ,  System.Int32 minConfidence ,  System.Int32 componentLevel ,  System.IntPtr dst )
{
	bool isExc = NativeMethodsExc.text_OCRTesseract_run3_excsafe(obj, image, minConfidence, componentLevel, dst);

	if(isExc)
		handleException();
}


public static  void text_OCRTesseract_run4( System.IntPtr obj ,  System.IntPtr image ,  System.IntPtr mask ,  System.Int32 minConfidence ,  System.Int32 componentLevel ,  System.IntPtr dst )
{
	bool isExc = NativeMethodsExc.text_OCRTesseract_run4_excsafe(obj, image, mask, minConfidence, componentLevel, dst);

	if(isExc)
		handleException();
}


public static  void text_OCRTesseract_setWhiteList( System.IntPtr obj , [MarshalAs(UnmanagedType.LPStr)] System.String charWhitelist )
{
	bool isExc = NativeMethodsExc.text_OCRTesseract_setWhiteList_excsafe(obj, charWhitelist);

	if(isExc)
		handleException();
}


public static  System.IntPtr text_OCRTesseract_create([MarshalAs(UnmanagedType.LPStr)] System.String datapath , [MarshalAs(UnmanagedType.LPStr)] System.String language , [MarshalAs(UnmanagedType.LPStr)] System.String charWhitelist ,  System.Int32 oem ,  System.Int32 psmode )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.text_OCRTesseract_create_excsafe(ref ret, datapath, language, charWhitelist, oem, psmode);

	if(isExc)
		handleException();
	return ret;
}


public static  void text_Ptr_OCRTesseract_delete( System.IntPtr obj )
{
	bool isExc = NativeMethodsExc.text_Ptr_OCRTesseract_delete_excsafe(obj);

	if(isExc)
		handleException();
}


public static  System.IntPtr text_OCRTesseract_get( System.IntPtr obj )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.text_OCRTesseract_get_excsafe(ref ret, obj);

	if(isExc)
		handleException();
	return ret;
}


public static  System.IntPtr videoio_VideoCapture_new1()
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.videoio_VideoCapture_new1_excsafe(ref ret);

	if(isExc)
		handleException();
	return ret;
}


public static  System.IntPtr videoio_VideoCapture_new2([MarshalAs(UnmanagedType.LPStr)] System.String filename )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.videoio_VideoCapture_new2_excsafe(ref ret, filename);

	if(isExc)
		handleException();
	return ret;
}


public static  void stitching_Stitcher_setPanoConfidenceThresh( System.IntPtr obj ,  System.Double confThresh )
{
	bool isExc = NativeMethodsExc.stitching_Stitcher_setPanoConfidenceThresh_excsafe(obj, confThresh);

	if(isExc)
		handleException();
}


public static  System.Int32 stitching_Stitcher_waveCorrection( System.IntPtr obj )
{
	System.Int32 ret = new System.Int32();
	bool isExc = NativeMethodsExc.stitching_Stitcher_waveCorrection_excsafe(ref ret, obj);

	if(isExc)
		handleException();
	return ret;
}


public static  void stitching_Stitcher_setWaveCorrection( System.IntPtr obj ,  System.Int32 flag )
{
	bool isExc = NativeMethodsExc.stitching_Stitcher_setWaveCorrection_excsafe(obj, flag);

	if(isExc)
		handleException();
}


public static  System.Int32 stitching_Stitcher_waveCorrectKind( System.IntPtr obj )
{
	System.Int32 ret = new System.Int32();
	bool isExc = NativeMethodsExc.stitching_Stitcher_waveCorrectKind_excsafe(ref ret, obj);

	if(isExc)
		handleException();
	return ret;
}


public static  void stitching_Stitcher_setWaveCorrectKind( System.IntPtr obj ,  System.Int32 kind )
{
	bool isExc = NativeMethodsExc.stitching_Stitcher_setWaveCorrectKind_excsafe(obj, kind);

	if(isExc)
		handleException();
}


public static  System.Int32 stitching_Stitcher_estimateTransform_InputArray1( System.IntPtr obj ,  System.IntPtr images )
{
	System.Int32 ret = new System.Int32();
	bool isExc = NativeMethodsExc.stitching_Stitcher_estimateTransform_InputArray1_excsafe(ref ret, obj, images);

	if(isExc)
		handleException();
	return ret;
}


public static  System.Int32 stitching_Stitcher_estimateTransform_InputArray2( System.IntPtr obj ,  System.IntPtr images ,  System.IntPtr[] rois ,  System.Int32 roisSize1 ,  System.Int32[] roisSize2 )
{
	System.Int32 ret = new System.Int32();
	bool isExc = NativeMethodsExc.stitching_Stitcher_estimateTransform_InputArray2_excsafe(ref ret, obj, images, rois, roisSize1, roisSize2);

	if(isExc)
		handleException();
	return ret;
}


public static  System.Int32 stitching_Stitcher_estimateTransform_MatArray1( System.IntPtr obj ,  System.IntPtr[] images ,  System.Int32 imagesSize )
{
	System.Int32 ret = new System.Int32();
	bool isExc = NativeMethodsExc.stitching_Stitcher_estimateTransform_MatArray1_excsafe(ref ret, obj, images, imagesSize);

	if(isExc)
		handleException();
	return ret;
}


public static  System.Int32 stitching_Stitcher_estimateTransform_MatArray2( System.IntPtr obj ,  System.IntPtr[] images ,  System.Int32 imagesSize ,  System.IntPtr[] rois ,  System.Int32 roisSize1 ,  System.Int32[] roisSize2 )
{
	System.Int32 ret = new System.Int32();
	bool isExc = NativeMethodsExc.stitching_Stitcher_estimateTransform_MatArray2_excsafe(ref ret, obj, images, imagesSize, rois, roisSize1, roisSize2);

	if(isExc)
		handleException();
	return ret;
}


public static  System.Int32 stitching_Stitcher_composePanorama1( System.IntPtr obj ,  System.IntPtr pano )
{
	System.Int32 ret = new System.Int32();
	bool isExc = NativeMethodsExc.stitching_Stitcher_composePanorama1_excsafe(ref ret, obj, pano);

	if(isExc)
		handleException();
	return ret;
}


public static  System.Int32 stitching_Stitcher_composePanorama2_InputArray( System.IntPtr obj ,  System.IntPtr images ,  System.IntPtr pano )
{
	System.Int32 ret = new System.Int32();
	bool isExc = NativeMethodsExc.stitching_Stitcher_composePanorama2_InputArray_excsafe(ref ret, obj, images, pano);

	if(isExc)
		handleException();
	return ret;
}


public static  System.Int32 stitching_Stitcher_composePanorama2_MatArray( System.IntPtr obj ,  System.IntPtr[] images ,  System.Int32 imagesSize ,  System.IntPtr pano )
{
	System.Int32 ret = new System.Int32();
	bool isExc = NativeMethodsExc.stitching_Stitcher_composePanorama2_MatArray_excsafe(ref ret, obj, images, imagesSize, pano);

	if(isExc)
		handleException();
	return ret;
}


public static  System.Int32 stitching_Stitcher_stitch1_InputArray( System.IntPtr obj ,  System.IntPtr images ,  System.IntPtr pano )
{
	System.Int32 ret = new System.Int32();
	bool isExc = NativeMethodsExc.stitching_Stitcher_stitch1_InputArray_excsafe(ref ret, obj, images, pano);

	if(isExc)
		handleException();
	return ret;
}


public static  System.Int32 stitching_Stitcher_stitch1_MatArray( System.IntPtr obj , [MarshalAs(UnmanagedType.LPArray)] System.IntPtr[] images ,  System.Int32 imagesSize ,  System.IntPtr pano )
{
	System.Int32 ret = new System.Int32();
	bool isExc = NativeMethodsExc.stitching_Stitcher_stitch1_MatArray_excsafe(ref ret, obj, images, imagesSize, pano);

	if(isExc)
		handleException();
	return ret;
}


public static  System.Int32 stitching_Stitcher_stitch2_InputArray( System.IntPtr obj ,  System.IntPtr images ,  System.IntPtr[] rois ,  System.Int32 roisSize1 ,  System.Int32[] roisSize2 ,  System.IntPtr pano )
{
	System.Int32 ret = new System.Int32();
	bool isExc = NativeMethodsExc.stitching_Stitcher_stitch2_InputArray_excsafe(ref ret, obj, images, rois, roisSize1, roisSize2, pano);

	if(isExc)
		handleException();
	return ret;
}


public static  System.Int32 stitching_Stitcher_stitch2_MatArray( System.IntPtr obj ,  System.IntPtr[] images ,  System.Int32 imagesSize ,  System.IntPtr[] rois ,  System.Int32 roisSize1 ,  System.Int32[] roisSize2 ,  System.IntPtr pano )
{
	System.Int32 ret = new System.Int32();
	bool isExc = NativeMethodsExc.stitching_Stitcher_stitch2_MatArray_excsafe(ref ret, obj, images, imagesSize, rois, roisSize1, roisSize2, pano);

	if(isExc)
		handleException();
	return ret;
}


public static  void stitching_Stitcher_component( System.IntPtr obj ,  out System.IntPtr pointer ,  out System.Int32 length )
{
	bool isExc = NativeMethodsExc.stitching_Stitcher_component_excsafe(obj,  out pointer,  out length);

	if(isExc)
		handleException();
}


public static  System.Double stitching_Stitcher_workScale( System.IntPtr obj )
{
	System.Double ret = new System.Double();
	bool isExc = NativeMethodsExc.stitching_Stitcher_workScale_excsafe(ref ret, obj);

	if(isExc)
		handleException();
	return ret;
}


public static  void superres_FrameSource_nextFrame( System.IntPtr obj ,  System.IntPtr frame )
{
	bool isExc = NativeMethodsExc.superres_FrameSource_nextFrame_excsafe(obj, frame);

	if(isExc)
		handleException();
}


public static  void superres_FrameSource_reset( System.IntPtr obj )
{
	bool isExc = NativeMethodsExc.superres_FrameSource_reset_excsafe(obj);

	if(isExc)
		handleException();
}


public static  System.IntPtr superres_createFrameSource_Empty()
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.superres_createFrameSource_Empty_excsafe(ref ret);

	if(isExc)
		handleException();
	return ret;
}


public static  System.IntPtr superres_createFrameSource_Video([MarshalAs(UnmanagedType.LPStr)] System.String fileName )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.superres_createFrameSource_Video_excsafe(ref ret, fileName);

	if(isExc)
		handleException();
	return ret;
}


public static  System.IntPtr superres_createFrameSource_Video_CUDA([MarshalAs(UnmanagedType.LPStr)] System.String fileName )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.superres_createFrameSource_Video_CUDA_excsafe(ref ret, fileName);

	if(isExc)
		handleException();
	return ret;
}


public static  System.IntPtr superres_createFrameSource_Camera( System.Int32 deviceId )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.superres_createFrameSource_Camera_excsafe(ref ret, deviceId);

	if(isExc)
		handleException();
	return ret;
}


public static  System.IntPtr superres_Ptr_FrameSource_get( System.IntPtr ptr )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.superres_Ptr_FrameSource_get_excsafe(ref ret, ptr);

	if(isExc)
		handleException();
	return ret;
}


public static  void superres_Ptr_FrameSource_delete( System.IntPtr ptr )
{
	bool isExc = NativeMethodsExc.superres_Ptr_FrameSource_delete_excsafe(ptr);

	if(isExc)
		handleException();
}


public static  void superres_SuperResolution_setInput( System.IntPtr obj ,  System.IntPtr frameSource )
{
	bool isExc = NativeMethodsExc.superres_SuperResolution_setInput_excsafe(obj, frameSource);

	if(isExc)
		handleException();
}


public static  void superres_SuperResolution_nextFrame( System.IntPtr obj ,  System.IntPtr frame )
{
	bool isExc = NativeMethodsExc.superres_SuperResolution_nextFrame_excsafe(obj, frame);

	if(isExc)
		handleException();
}


public static  System.IntPtr vector_Mat_getSize( System.IntPtr vector )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.vector_Mat_getSize_excsafe(ref ret, vector);

	if(isExc)
		handleException();
	return ret;
}


public static  System.IntPtr vector_Mat_getPointer( System.IntPtr vector )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.vector_Mat_getPointer_excsafe(ref ret, vector);

	if(isExc)
		handleException();
	return ret;
}


public static  void vector_Mat_delete( System.IntPtr vector )
{
	bool isExc = NativeMethodsExc.vector_Mat_delete_excsafe(vector);

	if(isExc)
		handleException();
}


public static  void vector_Mat_assignToArray( System.IntPtr vector , [MarshalAs(UnmanagedType.LPArray)] System.IntPtr[] arr )
{
	bool isExc = NativeMethodsExc.vector_Mat_assignToArray_excsafe(vector, arr);

	if(isExc)
		handleException();
}


public static  void vector_Mat_addref( System.IntPtr vector )
{
	bool isExc = NativeMethodsExc.vector_Mat_addref_excsafe(vector);

	if(isExc)
		handleException();
}


public static  System.IntPtr vector_DTrees_Node_new1()
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.vector_DTrees_Node_new1_excsafe(ref ret);

	if(isExc)
		handleException();
	return ret;
}


public static  System.IntPtr vector_DTrees_Node_new2( System.IntPtr size )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.vector_DTrees_Node_new2_excsafe(ref ret, size);

	if(isExc)
		handleException();
	return ret;
}


public static  System.IntPtr vector_DTrees_Node_new3([In] OpenCvSharp.ML.DTrees.Node[] data ,  System.IntPtr dataLength )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.vector_DTrees_Node_new3_excsafe(ref ret, data, dataLength);

	if(isExc)
		handleException();
	return ret;
}


public static  System.IntPtr vector_DTrees_Node_getSize( System.IntPtr vector )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.vector_DTrees_Node_getSize_excsafe(ref ret, vector);

	if(isExc)
		handleException();
	return ret;
}


public static  System.IntPtr vector_DTrees_Node_getPointer( System.IntPtr vector )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.vector_DTrees_Node_getPointer_excsafe(ref ret, vector);

	if(isExc)
		handleException();
	return ret;
}


public static  void vector_DTrees_Node_delete( System.IntPtr vector )
{
	bool isExc = NativeMethodsExc.vector_DTrees_Node_delete_excsafe(vector);

	if(isExc)
		handleException();
}


public static  System.IntPtr vector_DTrees_Split_new1()
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.vector_DTrees_Split_new1_excsafe(ref ret);

	if(isExc)
		handleException();
	return ret;
}


public static  System.IntPtr vector_DTrees_Split_new2( System.IntPtr size )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.vector_DTrees_Split_new2_excsafe(ref ret, size);

	if(isExc)
		handleException();
	return ret;
}


public static  System.IntPtr vector_DTrees_Split_new3([In] OpenCvSharp.ML.DTrees.Split[] data ,  System.IntPtr dataLength )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.vector_DTrees_Split_new3_excsafe(ref ret, data, dataLength);

	if(isExc)
		handleException();
	return ret;
}


public static  System.IntPtr vector_DTrees_Split_getSize( System.IntPtr vector )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.vector_DTrees_Split_getSize_excsafe(ref ret, vector);

	if(isExc)
		handleException();
	return ret;
}


public static  System.IntPtr vector_DTrees_Split_getPointer( System.IntPtr vector )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.vector_DTrees_Split_getPointer_excsafe(ref ret, vector);

	if(isExc)
		handleException();
	return ret;
}


public static  void vector_DTrees_Split_delete( System.IntPtr vector )
{
	bool isExc = NativeMethodsExc.vector_DTrees_Split_delete_excsafe(vector);

	if(isExc)
		handleException();
}


public static  System.IntPtr stitching_createStitcher( System.Int32 try_use_cpu )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.stitching_createStitcher_excsafe(ref ret, try_use_cpu);

	if(isExc)
		handleException();
	return ret;
}


public static  System.IntPtr stitching_createStitcherScans( System.Int32 try_use_cpu )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.stitching_createStitcherScans_excsafe(ref ret, try_use_cpu);

	if(isExc)
		handleException();
	return ret;
}


public static  void stitching_Ptr_Stitcher_delete( System.IntPtr obj )
{
	bool isExc = NativeMethodsExc.stitching_Ptr_Stitcher_delete_excsafe(obj);

	if(isExc)
		handleException();
}


public static  System.IntPtr stitching_Ptr_Stitcher_get( System.IntPtr obj )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.stitching_Ptr_Stitcher_get_excsafe(ref ret, obj);

	if(isExc)
		handleException();
	return ret;
}


public static  System.Double stitching_Stitcher_registrationResol( System.IntPtr obj )
{
	System.Double ret = new System.Double();
	bool isExc = NativeMethodsExc.stitching_Stitcher_registrationResol_excsafe(ref ret, obj);

	if(isExc)
		handleException();
	return ret;
}


public static  void stitching_Stitcher_setRegistrationResol( System.IntPtr obj ,  System.Double resolMpx )
{
	bool isExc = NativeMethodsExc.stitching_Stitcher_setRegistrationResol_excsafe(obj, resolMpx);

	if(isExc)
		handleException();
}


public static  System.Double stitching_Stitcher_seamEstimationResol( System.IntPtr obj )
{
	System.Double ret = new System.Double();
	bool isExc = NativeMethodsExc.stitching_Stitcher_seamEstimationResol_excsafe(ref ret, obj);

	if(isExc)
		handleException();
	return ret;
}


public static  void stitching_Stitcher_setSeamEstimationResol( System.IntPtr obj ,  System.Double resolMpx )
{
	bool isExc = NativeMethodsExc.stitching_Stitcher_setSeamEstimationResol_excsafe(obj, resolMpx);

	if(isExc)
		handleException();
}


public static  System.Double stitching_Stitcher_compositingResol( System.IntPtr obj )
{
	System.Double ret = new System.Double();
	bool isExc = NativeMethodsExc.stitching_Stitcher_compositingResol_excsafe(ref ret, obj);

	if(isExc)
		handleException();
	return ret;
}


public static  void stitching_Stitcher_setCompositingResol( System.IntPtr obj ,  System.Double resolMpx )
{
	bool isExc = NativeMethodsExc.stitching_Stitcher_setCompositingResol_excsafe(obj, resolMpx);

	if(isExc)
		handleException();
}


public static  System.Double stitching_Stitcher_panoConfidenceThresh( System.IntPtr obj )
{
	System.Double ret = new System.Double();
	bool isExc = NativeMethodsExc.stitching_Stitcher_panoConfidenceThresh_excsafe(ref ret, obj);

	if(isExc)
		handleException();
	return ret;
}


public static  System.IntPtr vector_vector_Point_new2( System.IntPtr size )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.vector_vector_Point_new2_excsafe(ref ret, size);

	if(isExc)
		handleException();
	return ret;
}


public static  System.IntPtr vector_vector_Point_getSize1( System.IntPtr vector )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.vector_vector_Point_getSize1_excsafe(ref ret, vector);

	if(isExc)
		handleException();
	return ret;
}


public static  void vector_vector_Point_getSize2( System.IntPtr vector , [In, Out] System.IntPtr[] size )
{
	bool isExc = NativeMethodsExc.vector_vector_Point_getSize2_excsafe(vector, size);

	if(isExc)
		handleException();
}


public static  System.IntPtr vector_vector_Point_getPointer( System.IntPtr vector )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.vector_vector_Point_getPointer_excsafe(ref ret, vector);

	if(isExc)
		handleException();
	return ret;
}


public static  void vector_vector_Point_copy( System.IntPtr vec ,  System.IntPtr[] dst )
{
	bool isExc = NativeMethodsExc.vector_vector_Point_copy_excsafe(vec, dst);

	if(isExc)
		handleException();
}


public static  void vector_vector_Point_delete( System.IntPtr vector )
{
	bool isExc = NativeMethodsExc.vector_vector_Point_delete_excsafe(vector);

	if(isExc)
		handleException();
}


public static  System.IntPtr vector_vector_Point2f_new1()
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.vector_vector_Point2f_new1_excsafe(ref ret);

	if(isExc)
		handleException();
	return ret;
}


public static  System.IntPtr vector_vector_Point2f_new2( System.IntPtr size )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.vector_vector_Point2f_new2_excsafe(ref ret, size);

	if(isExc)
		handleException();
	return ret;
}


public static  System.IntPtr vector_vector_Point2f_getSize1( System.IntPtr vector )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.vector_vector_Point2f_getSize1_excsafe(ref ret, vector);

	if(isExc)
		handleException();
	return ret;
}


public static  void vector_vector_Point2f_getSize2( System.IntPtr vector , [In, Out] System.IntPtr[] size )
{
	bool isExc = NativeMethodsExc.vector_vector_Point2f_getSize2_excsafe(vector, size);

	if(isExc)
		handleException();
}


public static  System.IntPtr vector_vector_Point2f_getPointer( System.IntPtr vector )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.vector_vector_Point2f_getPointer_excsafe(ref ret, vector);

	if(isExc)
		handleException();
	return ret;
}


public static  void vector_vector_Point2f_copy( System.IntPtr vec ,  System.IntPtr[] dst )
{
	bool isExc = NativeMethodsExc.vector_vector_Point2f_copy_excsafe(vec, dst);

	if(isExc)
		handleException();
}


public static  void vector_vector_Point2f_delete( System.IntPtr vector )
{
	bool isExc = NativeMethodsExc.vector_vector_Point2f_delete_excsafe(vector);

	if(isExc)
		handleException();
}


public static  System.IntPtr vector_string_new1()
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.vector_string_new1_excsafe(ref ret);

	if(isExc)
		handleException();
	return ret;
}


public static  System.IntPtr vector_string_new2( System.IntPtr size )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.vector_string_new2_excsafe(ref ret, size);

	if(isExc)
		handleException();
	return ret;
}


public static  System.IntPtr vector_string_getSize( System.IntPtr vec )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.vector_string_getSize_excsafe(ref ret, vec);

	if(isExc)
		handleException();
	return ret;
}


public static  System.IntPtr vector_string_getPointer( System.IntPtr vector )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.vector_string_getPointer_excsafe(ref ret, vector);

	if(isExc)
		handleException();
	return ret;
}


public static  unsafe System.SByte* vector_string_elemAt( System.IntPtr vector ,  System.Int32 i )
{
	IntPtr ret = new IntPtr();
	bool isExc = NativeMethodsExc.vector_string_elemAt_excsafe(ref ret, vector, i);

	if(isExc)
		handleException();
	return (System.SByte*)ret;
}


public static  void vector_string_delete( System.IntPtr vector )
{
	bool isExc = NativeMethodsExc.vector_string_delete_excsafe(vector);

	if(isExc)
		handleException();
}


public static  System.IntPtr vector_cvString_new1()
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.vector_cvString_new1_excsafe(ref ret);

	if(isExc)
		handleException();
	return ret;
}


public static  System.IntPtr vector_cvString_new2( System.IntPtr size )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.vector_cvString_new2_excsafe(ref ret, size);

	if(isExc)
		handleException();
	return ret;
}


public static  System.IntPtr vector_cvString_getSize( System.IntPtr vec )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.vector_cvString_getSize_excsafe(ref ret, vec);

	if(isExc)
		handleException();
	return ret;
}


public static  System.IntPtr vector_cvString_getPointer( System.IntPtr vector )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.vector_cvString_getPointer_excsafe(ref ret, vector);

	if(isExc)
		handleException();
	return ret;
}


public static  unsafe System.SByte* vector_cvString_elemAt( System.IntPtr vector ,  System.Int32 i )
{
	IntPtr ret = new IntPtr();
	bool isExc = NativeMethodsExc.vector_cvString_elemAt_excsafe(ref ret, vector, i);

	if(isExc)
		handleException();
	return (System.SByte*)ret;
}


public static  void vector_cvString_delete( System.IntPtr vector )
{
	bool isExc = NativeMethodsExc.vector_cvString_delete_excsafe(vector);

	if(isExc)
		handleException();
}


public static  System.IntPtr vector_Mat_new1()
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.vector_Mat_new1_excsafe(ref ret);

	if(isExc)
		handleException();
	return ret;
}


public static  System.IntPtr vector_Mat_new2( System.IntPtr size )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.vector_Mat_new2_excsafe(ref ret, size);

	if(isExc)
		handleException();
	return ret;
}


public static  System.IntPtr vector_Mat_new3( System.IntPtr data ,  System.IntPtr dataLength )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.vector_Mat_new3_excsafe(ref ret, data, dataLength);

	if(isExc)
		handleException();
	return ret;
}


public static  System.IntPtr vector_vector_float_getSize1( System.IntPtr vector )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.vector_vector_float_getSize1_excsafe(ref ret, vector);

	if(isExc)
		handleException();
	return ret;
}


public static  void vector_vector_float_getSize2( System.IntPtr vector , [In, Out] System.IntPtr[] size )
{
	bool isExc = NativeMethodsExc.vector_vector_float_getSize2_excsafe(vector, size);

	if(isExc)
		handleException();
}


public static  System.IntPtr vector_vector_float_getPointer( System.IntPtr vector )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.vector_vector_float_getPointer_excsafe(ref ret, vector);

	if(isExc)
		handleException();
	return ret;
}


public static  void vector_vector_float_copy( System.IntPtr vec ,  System.IntPtr[] dst )
{
	bool isExc = NativeMethodsExc.vector_vector_float_copy_excsafe(vec, dst);

	if(isExc)
		handleException();
}


public static  void vector_vector_float_delete( System.IntPtr vector )
{
	bool isExc = NativeMethodsExc.vector_vector_float_delete_excsafe(vector);

	if(isExc)
		handleException();
}


public static  System.IntPtr vector_vector_double_new1()
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.vector_vector_double_new1_excsafe(ref ret);

	if(isExc)
		handleException();
	return ret;
}


public static  System.IntPtr vector_vector_double_new2( System.IntPtr size )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.vector_vector_double_new2_excsafe(ref ret, size);

	if(isExc)
		handleException();
	return ret;
}


public static  System.IntPtr vector_vector_double_getSize1( System.IntPtr vector )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.vector_vector_double_getSize1_excsafe(ref ret, vector);

	if(isExc)
		handleException();
	return ret;
}


public static  void vector_vector_double_getSize2( System.IntPtr vector , [In, Out] System.IntPtr[] size )
{
	bool isExc = NativeMethodsExc.vector_vector_double_getSize2_excsafe(vector, size);

	if(isExc)
		handleException();
}


public static  System.IntPtr vector_vector_double_getPointer( System.IntPtr vector )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.vector_vector_double_getPointer_excsafe(ref ret, vector);

	if(isExc)
		handleException();
	return ret;
}


public static  void vector_vector_double_copy( System.IntPtr vec ,  System.IntPtr[] dst )
{
	bool isExc = NativeMethodsExc.vector_vector_double_copy_excsafe(vec, dst);

	if(isExc)
		handleException();
}


public static  void vector_vector_double_delete( System.IntPtr vector )
{
	bool isExc = NativeMethodsExc.vector_vector_double_delete_excsafe(vector);

	if(isExc)
		handleException();
}


public static  System.IntPtr vector_vector_KeyPoint_new1()
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.vector_vector_KeyPoint_new1_excsafe(ref ret);

	if(isExc)
		handleException();
	return ret;
}


public static  System.IntPtr vector_vector_KeyPoint_new2( System.IntPtr size )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.vector_vector_KeyPoint_new2_excsafe(ref ret, size);

	if(isExc)
		handleException();
	return ret;
}


public static  System.IntPtr vector_vector_KeyPoint_new3( System.IntPtr[] values ,  System.Int32 size1 ,  System.Int32[] size2 )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.vector_vector_KeyPoint_new3_excsafe(ref ret, values, size1, size2);

	if(isExc)
		handleException();
	return ret;
}


public static  System.IntPtr vector_vector_KeyPoint_getSize1( System.IntPtr vector )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.vector_vector_KeyPoint_getSize1_excsafe(ref ret, vector);

	if(isExc)
		handleException();
	return ret;
}


public static  void vector_vector_KeyPoint_getSize2( System.IntPtr vector , [In, Out] System.IntPtr[] size )
{
	bool isExc = NativeMethodsExc.vector_vector_KeyPoint_getSize2_excsafe(vector, size);

	if(isExc)
		handleException();
}


public static  System.IntPtr vector_vector_KeyPoint_getPointer( System.IntPtr vector )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.vector_vector_KeyPoint_getPointer_excsafe(ref ret, vector);

	if(isExc)
		handleException();
	return ret;
}


public static  void vector_vector_KeyPoint_copy( System.IntPtr vec ,  System.IntPtr[] dst )
{
	bool isExc = NativeMethodsExc.vector_vector_KeyPoint_copy_excsafe(vec, dst);

	if(isExc)
		handleException();
}


public static  void vector_vector_KeyPoint_delete( System.IntPtr vector )
{
	bool isExc = NativeMethodsExc.vector_vector_KeyPoint_delete_excsafe(vector);

	if(isExc)
		handleException();
}


public static  System.IntPtr vector_vector_DMatch_new1()
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.vector_vector_DMatch_new1_excsafe(ref ret);

	if(isExc)
		handleException();
	return ret;
}


public static  System.IntPtr vector_vector_DMatch_new2( System.IntPtr size )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.vector_vector_DMatch_new2_excsafe(ref ret, size);

	if(isExc)
		handleException();
	return ret;
}


public static  System.IntPtr vector_vector_DMatch_getSize1( System.IntPtr vector )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.vector_vector_DMatch_getSize1_excsafe(ref ret, vector);

	if(isExc)
		handleException();
	return ret;
}


public static  void vector_vector_DMatch_getSize2( System.IntPtr vector , [In, Out] System.IntPtr[] size )
{
	bool isExc = NativeMethodsExc.vector_vector_DMatch_getSize2_excsafe(vector, size);

	if(isExc)
		handleException();
}


public static  System.IntPtr vector_vector_DMatch_getPointer( System.IntPtr vector )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.vector_vector_DMatch_getPointer_excsafe(ref ret, vector);

	if(isExc)
		handleException();
	return ret;
}


public static  void vector_vector_DMatch_copy( System.IntPtr vec ,  System.IntPtr[] dst )
{
	bool isExc = NativeMethodsExc.vector_vector_DMatch_copy_excsafe(vec, dst);

	if(isExc)
		handleException();
}


public static  void vector_vector_DMatch_delete( System.IntPtr vector )
{
	bool isExc = NativeMethodsExc.vector_vector_DMatch_delete_excsafe(vector);

	if(isExc)
		handleException();
}


public static  System.IntPtr vector_vector_Point_new1()
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.vector_vector_Point_new1_excsafe(ref ret);

	if(isExc)
		handleException();
	return ret;
}


public static  void vector_Rect_delete( System.IntPtr vector )
{
	bool isExc = NativeMethodsExc.vector_Rect_delete_excsafe(vector);

	if(isExc)
		handleException();
}


public static  System.IntPtr vector_Rect2d_new1()
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.vector_Rect2d_new1_excsafe(ref ret);

	if(isExc)
		handleException();
	return ret;
}


public static  System.IntPtr vector_Rect2d_new2( System.IntPtr size )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.vector_Rect2d_new2_excsafe(ref ret, size);

	if(isExc)
		handleException();
	return ret;
}


public static  System.IntPtr vector_Rect2d_new3([In] OpenCvSharp.Rect2d[] data ,  System.IntPtr dataLength )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.vector_Rect2d_new3_excsafe(ref ret, data, dataLength);

	if(isExc)
		handleException();
	return ret;
}


public static  System.IntPtr vector_Rect2d_getSize( System.IntPtr vector )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.vector_Rect2d_getSize_excsafe(ref ret, vector);

	if(isExc)
		handleException();
	return ret;
}


public static  System.IntPtr vector_Rect2d_getPointer( System.IntPtr vector )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.vector_Rect2d_getPointer_excsafe(ref ret, vector);

	if(isExc)
		handleException();
	return ret;
}


public static  void vector_Rect2d_delete( System.IntPtr vector )
{
	bool isExc = NativeMethodsExc.vector_Rect2d_delete_excsafe(vector);

	if(isExc)
		handleException();
}


public static  System.IntPtr vector_KeyPoint_new1()
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.vector_KeyPoint_new1_excsafe(ref ret);

	if(isExc)
		handleException();
	return ret;
}


public static  System.IntPtr vector_KeyPoint_new2( System.IntPtr size )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.vector_KeyPoint_new2_excsafe(ref ret, size);

	if(isExc)
		handleException();
	return ret;
}


public static  System.IntPtr vector_KeyPoint_new3([In] OpenCvSharp.KeyPoint[] data ,  System.IntPtr dataLength )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.vector_KeyPoint_new3_excsafe(ref ret, data, dataLength);

	if(isExc)
		handleException();
	return ret;
}


public static  System.IntPtr vector_KeyPoint_getSize( System.IntPtr vector )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.vector_KeyPoint_getSize_excsafe(ref ret, vector);

	if(isExc)
		handleException();
	return ret;
}


public static  System.IntPtr vector_KeyPoint_getPointer( System.IntPtr vector )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.vector_KeyPoint_getPointer_excsafe(ref ret, vector);

	if(isExc)
		handleException();
	return ret;
}


public static  void vector_KeyPoint_delete( System.IntPtr vector )
{
	bool isExc = NativeMethodsExc.vector_KeyPoint_delete_excsafe(vector);

	if(isExc)
		handleException();
}


public static  System.IntPtr vector_DMatch_new1()
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.vector_DMatch_new1_excsafe(ref ret);

	if(isExc)
		handleException();
	return ret;
}


public static  System.IntPtr vector_DMatch_new2( System.IntPtr size )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.vector_DMatch_new2_excsafe(ref ret, size);

	if(isExc)
		handleException();
	return ret;
}


public static  System.IntPtr vector_DMatch_new3([In] OpenCvSharp.DMatch[] data ,  System.IntPtr dataLength )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.vector_DMatch_new3_excsafe(ref ret, data, dataLength);

	if(isExc)
		handleException();
	return ret;
}


public static  System.IntPtr vector_DMatch_getSize( System.IntPtr vector )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.vector_DMatch_getSize_excsafe(ref ret, vector);

	if(isExc)
		handleException();
	return ret;
}


public static  System.IntPtr vector_DMatch_getPointer( System.IntPtr vector )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.vector_DMatch_getPointer_excsafe(ref ret, vector);

	if(isExc)
		handleException();
	return ret;
}


public static  void vector_DMatch_delete( System.IntPtr vector )
{
	bool isExc = NativeMethodsExc.vector_DMatch_delete_excsafe(vector);

	if(isExc)
		handleException();
}


public static  System.IntPtr vector_vector_int_new1()
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.vector_vector_int_new1_excsafe(ref ret);

	if(isExc)
		handleException();
	return ret;
}


public static  System.IntPtr vector_vector_int_new2( System.IntPtr size )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.vector_vector_int_new2_excsafe(ref ret, size);

	if(isExc)
		handleException();
	return ret;
}


public static  System.IntPtr vector_vector_int_getSize1( System.IntPtr vector )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.vector_vector_int_getSize1_excsafe(ref ret, vector);

	if(isExc)
		handleException();
	return ret;
}


public static  void vector_vector_int_getSize2( System.IntPtr vector , [In, Out] System.IntPtr[] size )
{
	bool isExc = NativeMethodsExc.vector_vector_int_getSize2_excsafe(vector, size);

	if(isExc)
		handleException();
}


public static  System.IntPtr vector_vector_int_getPointer( System.IntPtr vector )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.vector_vector_int_getPointer_excsafe(ref ret, vector);

	if(isExc)
		handleException();
	return ret;
}


public static  void vector_vector_int_copy( System.IntPtr vec ,  System.IntPtr[] dst )
{
	bool isExc = NativeMethodsExc.vector_vector_int_copy_excsafe(vec, dst);

	if(isExc)
		handleException();
}


public static  void vector_vector_int_delete( System.IntPtr vector )
{
	bool isExc = NativeMethodsExc.vector_vector_int_delete_excsafe(vector);

	if(isExc)
		handleException();
}


public static  System.IntPtr vector_vector_float_new1()
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.vector_vector_float_new1_excsafe(ref ret);

	if(isExc)
		handleException();
	return ret;
}


public static  System.IntPtr vector_vector_float_new2( System.IntPtr size )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.vector_vector_float_new2_excsafe(ref ret, size);

	if(isExc)
		handleException();
	return ret;
}


public static  System.IntPtr vector_Vec6d_new2( System.IntPtr size )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.vector_Vec6d_new2_excsafe(ref ret, size);

	if(isExc)
		handleException();
	return ret;
}


public static  System.IntPtr vector_Vec6d_new3([In] OpenCvSharp.Vec6d[] data ,  System.IntPtr dataLength )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.vector_Vec6d_new3_excsafe(ref ret, data, dataLength);

	if(isExc)
		handleException();
	return ret;
}


public static  System.IntPtr vector_Vec6d_getSize( System.IntPtr vector )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.vector_Vec6d_getSize_excsafe(ref ret, vector);

	if(isExc)
		handleException();
	return ret;
}


public static  System.IntPtr vector_Vec6d_getPointer( System.IntPtr vector )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.vector_Vec6d_getPointer_excsafe(ref ret, vector);

	if(isExc)
		handleException();
	return ret;
}


public static  void vector_Vec6d_delete( System.IntPtr vector )
{
	bool isExc = NativeMethodsExc.vector_Vec6d_delete_excsafe(vector);

	if(isExc)
		handleException();
}


public static  System.IntPtr vector_Point2i_new1()
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.vector_Point2i_new1_excsafe(ref ret);

	if(isExc)
		handleException();
	return ret;
}


public static  System.IntPtr vector_Point2i_new2( System.IntPtr size )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.vector_Point2i_new2_excsafe(ref ret, size);

	if(isExc)
		handleException();
	return ret;
}


public static  System.IntPtr vector_Point2i_new3([In] OpenCvSharp.Point[] data ,  System.IntPtr dataLength )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.vector_Point2i_new3_excsafe(ref ret, data, dataLength);

	if(isExc)
		handleException();
	return ret;
}


public static  System.IntPtr vector_Point2i_getSize( System.IntPtr vector )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.vector_Point2i_getSize_excsafe(ref ret, vector);

	if(isExc)
		handleException();
	return ret;
}


public static  System.IntPtr vector_Point2i_getPointer( System.IntPtr vector )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.vector_Point2i_getPointer_excsafe(ref ret, vector);

	if(isExc)
		handleException();
	return ret;
}


public static  void vector_Point2i_delete( System.IntPtr vector )
{
	bool isExc = NativeMethodsExc.vector_Point2i_delete_excsafe(vector);

	if(isExc)
		handleException();
}


public static  System.IntPtr vector_Point2f_new1()
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.vector_Point2f_new1_excsafe(ref ret);

	if(isExc)
		handleException();
	return ret;
}


public static  System.IntPtr vector_Point2f_new2( System.IntPtr size )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.vector_Point2f_new2_excsafe(ref ret, size);

	if(isExc)
		handleException();
	return ret;
}


public static  System.IntPtr vector_Point2f_new3([In] OpenCvSharp.Point2f[] data ,  System.IntPtr dataLength )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.vector_Point2f_new3_excsafe(ref ret, data, dataLength);

	if(isExc)
		handleException();
	return ret;
}


public static  System.IntPtr vector_Point2f_getSize( System.IntPtr vector )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.vector_Point2f_getSize_excsafe(ref ret, vector);

	if(isExc)
		handleException();
	return ret;
}


public static  System.IntPtr vector_Point2f_getPointer( System.IntPtr vector )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.vector_Point2f_getPointer_excsafe(ref ret, vector);

	if(isExc)
		handleException();
	return ret;
}


public static  void vector_Point2f_delete( System.IntPtr vector )
{
	bool isExc = NativeMethodsExc.vector_Point2f_delete_excsafe(vector);

	if(isExc)
		handleException();
}


public static  System.IntPtr vector_Point3f_new1()
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.vector_Point3f_new1_excsafe(ref ret);

	if(isExc)
		handleException();
	return ret;
}


public static  System.IntPtr vector_Point3f_new2( System.IntPtr size )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.vector_Point3f_new2_excsafe(ref ret, size);

	if(isExc)
		handleException();
	return ret;
}


public static  System.IntPtr vector_Point3f_new3([In] OpenCvSharp.Point3f[] data ,  System.IntPtr dataLength )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.vector_Point3f_new3_excsafe(ref ret, data, dataLength);

	if(isExc)
		handleException();
	return ret;
}


public static  System.IntPtr vector_Point3f_getSize( System.IntPtr vector )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.vector_Point3f_getSize_excsafe(ref ret, vector);

	if(isExc)
		handleException();
	return ret;
}


public static  System.IntPtr vector_Point3f_getPointer( System.IntPtr vector )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.vector_Point3f_getPointer_excsafe(ref ret, vector);

	if(isExc)
		handleException();
	return ret;
}


public static  void vector_Point3f_delete( System.IntPtr vector )
{
	bool isExc = NativeMethodsExc.vector_Point3f_delete_excsafe(vector);

	if(isExc)
		handleException();
}


public static  System.IntPtr vector_Rect_new1()
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.vector_Rect_new1_excsafe(ref ret);

	if(isExc)
		handleException();
	return ret;
}


public static  System.IntPtr vector_Rect_new2( System.IntPtr size )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.vector_Rect_new2_excsafe(ref ret, size);

	if(isExc)
		handleException();
	return ret;
}


public static  System.IntPtr vector_Rect_new3([In] OpenCvSharp.Rect[] data ,  System.IntPtr dataLength )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.vector_Rect_new3_excsafe(ref ret, data, dataLength);

	if(isExc)
		handleException();
	return ret;
}


public static  System.IntPtr vector_Rect_getSize( System.IntPtr vector )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.vector_Rect_getSize_excsafe(ref ret, vector);

	if(isExc)
		handleException();
	return ret;
}


public static  System.IntPtr vector_Rect_getPointer( System.IntPtr vector )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.vector_Rect_getPointer_excsafe(ref ret, vector);

	if(isExc)
		handleException();
	return ret;
}


public static  System.IntPtr vector_Vec2f_getSize( System.IntPtr vector )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.vector_Vec2f_getSize_excsafe(ref ret, vector);

	if(isExc)
		handleException();
	return ret;
}


public static  System.IntPtr vector_Vec2f_getPointer( System.IntPtr vector )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.vector_Vec2f_getPointer_excsafe(ref ret, vector);

	if(isExc)
		handleException();
	return ret;
}


public static  void vector_Vec2f_delete( System.IntPtr vector )
{
	bool isExc = NativeMethodsExc.vector_Vec2f_delete_excsafe(vector);

	if(isExc)
		handleException();
}


public static  System.IntPtr vector_Vec3f_new1()
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.vector_Vec3f_new1_excsafe(ref ret);

	if(isExc)
		handleException();
	return ret;
}


public static  System.IntPtr vector_Vec3f_new2( System.IntPtr size )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.vector_Vec3f_new2_excsafe(ref ret, size);

	if(isExc)
		handleException();
	return ret;
}


public static  System.IntPtr vector_Vec3f_new3([In] OpenCvSharp.Vec3f[] data ,  System.IntPtr dataLength )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.vector_Vec3f_new3_excsafe(ref ret, data, dataLength);

	if(isExc)
		handleException();
	return ret;
}


public static  System.IntPtr vector_Vec3f_getSize( System.IntPtr vector )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.vector_Vec3f_getSize_excsafe(ref ret, vector);

	if(isExc)
		handleException();
	return ret;
}


public static  System.IntPtr vector_Vec3f_getPointer( System.IntPtr vector )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.vector_Vec3f_getPointer_excsafe(ref ret, vector);

	if(isExc)
		handleException();
	return ret;
}


public static  void vector_Vec3f_delete( System.IntPtr vector )
{
	bool isExc = NativeMethodsExc.vector_Vec3f_delete_excsafe(vector);

	if(isExc)
		handleException();
}


public static  System.IntPtr vector_Vec4f_new1()
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.vector_Vec4f_new1_excsafe(ref ret);

	if(isExc)
		handleException();
	return ret;
}


public static  System.IntPtr vector_Vec4f_new2( System.IntPtr size )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.vector_Vec4f_new2_excsafe(ref ret, size);

	if(isExc)
		handleException();
	return ret;
}


public static  System.IntPtr vector_Vec4f_new3([In] OpenCvSharp.Vec4f[] data ,  System.IntPtr dataLength )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.vector_Vec4f_new3_excsafe(ref ret, data, dataLength);

	if(isExc)
		handleException();
	return ret;
}


public static  System.IntPtr vector_Vec4f_getSize( System.IntPtr vector )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.vector_Vec4f_getSize_excsafe(ref ret, vector);

	if(isExc)
		handleException();
	return ret;
}


public static  System.IntPtr vector_Vec4f_getPointer( System.IntPtr vector )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.vector_Vec4f_getPointer_excsafe(ref ret, vector);

	if(isExc)
		handleException();
	return ret;
}


public static  void vector_Vec4f_delete( System.IntPtr vector )
{
	bool isExc = NativeMethodsExc.vector_Vec4f_delete_excsafe(vector);

	if(isExc)
		handleException();
}


public static  System.IntPtr vector_Vec4i_new1()
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.vector_Vec4i_new1_excsafe(ref ret);

	if(isExc)
		handleException();
	return ret;
}


public static  System.IntPtr vector_Vec4i_new2( System.IntPtr size )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.vector_Vec4i_new2_excsafe(ref ret, size);

	if(isExc)
		handleException();
	return ret;
}


public static  System.IntPtr vector_Vec4i_new3([In] OpenCvSharp.Vec4i[] data ,  System.IntPtr dataLength )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.vector_Vec4i_new3_excsafe(ref ret, data, dataLength);

	if(isExc)
		handleException();
	return ret;
}


public static  System.IntPtr vector_Vec4i_getSize( System.IntPtr vector )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.vector_Vec4i_getSize_excsafe(ref ret, vector);

	if(isExc)
		handleException();
	return ret;
}


public static  System.IntPtr vector_Vec4i_getPointer( System.IntPtr vector )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.vector_Vec4i_getPointer_excsafe(ref ret, vector);

	if(isExc)
		handleException();
	return ret;
}


public static  void vector_Vec4i_delete( System.IntPtr vector )
{
	bool isExc = NativeMethodsExc.vector_Vec4i_delete_excsafe(vector);

	if(isExc)
		handleException();
}


public static  System.IntPtr vector_Vec6f_new1()
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.vector_Vec6f_new1_excsafe(ref ret);

	if(isExc)
		handleException();
	return ret;
}


public static  System.IntPtr vector_Vec6f_new2( System.IntPtr size )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.vector_Vec6f_new2_excsafe(ref ret, size);

	if(isExc)
		handleException();
	return ret;
}


public static  System.IntPtr vector_Vec6f_new3([In] OpenCvSharp.Vec6f[] data ,  System.IntPtr dataLength )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.vector_Vec6f_new3_excsafe(ref ret, data, dataLength);

	if(isExc)
		handleException();
	return ret;
}


public static  System.IntPtr vector_Vec6f_getSize( System.IntPtr vector )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.vector_Vec6f_getSize_excsafe(ref ret, vector);

	if(isExc)
		handleException();
	return ret;
}


public static  System.IntPtr vector_Vec6f_getPointer( System.IntPtr vector )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.vector_Vec6f_getPointer_excsafe(ref ret, vector);

	if(isExc)
		handleException();
	return ret;
}


public static  void vector_Vec6f_delete( System.IntPtr vector )
{
	bool isExc = NativeMethodsExc.vector_Vec6f_delete_excsafe(vector);

	if(isExc)
		handleException();
}


public static  System.IntPtr vector_Vec6d_new1()
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.vector_Vec6d_new1_excsafe(ref ret);

	if(isExc)
		handleException();
	return ret;
}


public static  System.IntPtr vector_char_new1()
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.vector_char_new1_excsafe(ref ret);

	if(isExc)
		handleException();
	return ret;
}


public static  System.IntPtr vector_char_new2( System.IntPtr size )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.vector_char_new2_excsafe(ref ret, size);

	if(isExc)
		handleException();
	return ret;
}


public static  System.IntPtr vector_char_new3([In] System.SByte[] data ,  System.IntPtr dataLength )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.vector_char_new3_excsafe(ref ret, data, dataLength);

	if(isExc)
		handleException();
	return ret;
}


public static  System.IntPtr vector_char_getSize( System.IntPtr vector )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.vector_char_getSize_excsafe(ref ret, vector);

	if(isExc)
		handleException();
	return ret;
}


public static  System.IntPtr vector_char_getPointer( System.IntPtr vector )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.vector_char_getPointer_excsafe(ref ret, vector);

	if(isExc)
		handleException();
	return ret;
}


public static  void vector_vector_char_copy( System.IntPtr vector ,  System.IntPtr dst )
{
	bool isExc = NativeMethodsExc.vector_vector_char_copy_excsafe(vector, dst);

	if(isExc)
		handleException();
}


public static  void vector_char_delete( System.IntPtr vector )
{
	bool isExc = NativeMethodsExc.vector_char_delete_excsafe(vector);

	if(isExc)
		handleException();
}


public static  System.IntPtr vector_int32_new1()
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.vector_int32_new1_excsafe(ref ret);

	if(isExc)
		handleException();
	return ret;
}


public static  System.IntPtr vector_int32_new2( System.IntPtr size )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.vector_int32_new2_excsafe(ref ret, size);

	if(isExc)
		handleException();
	return ret;
}


public static  System.IntPtr vector_int32_new3([In] System.Int32[] data ,  System.IntPtr dataLength )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.vector_int32_new3_excsafe(ref ret, data, dataLength);

	if(isExc)
		handleException();
	return ret;
}


public static  System.IntPtr vector_int32_getSize( System.IntPtr vector )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.vector_int32_getSize_excsafe(ref ret, vector);

	if(isExc)
		handleException();
	return ret;
}


public static  System.IntPtr vector_int32_getPointer( System.IntPtr vector )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.vector_int32_getPointer_excsafe(ref ret, vector);

	if(isExc)
		handleException();
	return ret;
}


public static  void vector_int32_delete( System.IntPtr vector )
{
	bool isExc = NativeMethodsExc.vector_int32_delete_excsafe(vector);

	if(isExc)
		handleException();
}


public static  System.IntPtr vector_float_new1()
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.vector_float_new1_excsafe(ref ret);

	if(isExc)
		handleException();
	return ret;
}


public static  System.IntPtr vector_float_new2( System.IntPtr size )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.vector_float_new2_excsafe(ref ret, size);

	if(isExc)
		handleException();
	return ret;
}


public static  System.IntPtr vector_float_new3([In] System.Single[] data ,  System.IntPtr dataLength )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.vector_float_new3_excsafe(ref ret, data, dataLength);

	if(isExc)
		handleException();
	return ret;
}


public static  System.IntPtr vector_float_getSize( System.IntPtr vector )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.vector_float_getSize_excsafe(ref ret, vector);

	if(isExc)
		handleException();
	return ret;
}


public static  System.IntPtr vector_float_getPointer( System.IntPtr vector )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.vector_float_getPointer_excsafe(ref ret, vector);

	if(isExc)
		handleException();
	return ret;
}


public static  void vector_float_delete( System.IntPtr vector )
{
	bool isExc = NativeMethodsExc.vector_float_delete_excsafe(vector);

	if(isExc)
		handleException();
}


public static  System.IntPtr vector_double_new1()
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.vector_double_new1_excsafe(ref ret);

	if(isExc)
		handleException();
	return ret;
}


public static  System.IntPtr vector_double_new2( System.IntPtr size )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.vector_double_new2_excsafe(ref ret, size);

	if(isExc)
		handleException();
	return ret;
}


public static  System.IntPtr vector_double_new3([In] System.Double[] data ,  System.IntPtr dataLength )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.vector_double_new3_excsafe(ref ret, data, dataLength);

	if(isExc)
		handleException();
	return ret;
}


public static  System.IntPtr vector_double_getSize( System.IntPtr vector )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.vector_double_getSize_excsafe(ref ret, vector);

	if(isExc)
		handleException();
	return ret;
}


public static  System.IntPtr vector_double_getPointer( System.IntPtr vector )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.vector_double_getPointer_excsafe(ref ret, vector);

	if(isExc)
		handleException();
	return ret;
}


public static  void vector_double_delete( System.IntPtr vector )
{
	bool isExc = NativeMethodsExc.vector_double_delete_excsafe(vector);

	if(isExc)
		handleException();
}


public static  System.IntPtr vector_Vec2f_new1()
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.vector_Vec2f_new1_excsafe(ref ret);

	if(isExc)
		handleException();
	return ret;
}


public static  System.IntPtr vector_Vec2f_new2( System.IntPtr size )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.vector_Vec2f_new2_excsafe(ref ret, size);

	if(isExc)
		handleException();
	return ret;
}


public static  System.IntPtr vector_Vec2f_new3([In] OpenCvSharp.Vec2f[] data ,  System.IntPtr dataLength )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.vector_Vec2f_new3_excsafe(ref ret, data, dataLength);

	if(isExc)
		handleException();
	return ret;
}


public static  void objdetect_HOGDescriptor_winSigma_set( System.IntPtr self ,  System.Double value )
{
	bool isExc = NativeMethodsExc.objdetect_HOGDescriptor_winSigma_set_excsafe(self, value);

	if(isExc)
		handleException();
}


public static  void objdetect_HOGDescriptor_histogramNormType_set( System.IntPtr self ,  System.Int32 value )
{
	bool isExc = NativeMethodsExc.objdetect_HOGDescriptor_histogramNormType_set_excsafe(self, value);

	if(isExc)
		handleException();
}


public static  void objdetect_HOGDescriptor_L2HysThreshold_set( System.IntPtr self ,  System.Double value )
{
	bool isExc = NativeMethodsExc.objdetect_HOGDescriptor_L2HysThreshold_set_excsafe(self, value);

	if(isExc)
		handleException();
}


public static  void objdetect_HOGDescriptor_gammaCorrection_set( System.IntPtr self ,  System.Int32 value )
{
	bool isExc = NativeMethodsExc.objdetect_HOGDescriptor_gammaCorrection_set_excsafe(self, value);

	if(isExc)
		handleException();
}


public static  void objdetect_HOGDescriptor_nlevels_set( System.IntPtr self ,  System.Int32 value )
{
	bool isExc = NativeMethodsExc.objdetect_HOGDescriptor_nlevels_set_excsafe(self, value);

	if(isExc)
		handleException();
}


public static  void objdetect_groupRectangles1( System.IntPtr rectList ,  System.Int32 groupThreshold ,  System.Double eps )
{
	bool isExc = NativeMethodsExc.objdetect_groupRectangles1_excsafe(rectList, groupThreshold, eps);

	if(isExc)
		handleException();
}


public static  void objdetect_groupRectangles2( System.IntPtr rectList ,  System.IntPtr weights ,  System.Int32 groupThreshold ,  System.Double eps )
{
	bool isExc = NativeMethodsExc.objdetect_groupRectangles2_excsafe(rectList, weights, groupThreshold, eps);

	if(isExc)
		handleException();
}


public static  void objdetect_groupRectangles3( System.IntPtr rectList ,  System.Int32 groupThreshold ,  System.Double eps ,  System.IntPtr weights ,  System.IntPtr levelWeights )
{
	bool isExc = NativeMethodsExc.objdetect_groupRectangles3_excsafe(rectList, groupThreshold, eps, weights, levelWeights);

	if(isExc)
		handleException();
}


public static  void objdetect_groupRectangles4( System.IntPtr rectList ,  System.IntPtr rejectLevels ,  System.IntPtr levelWeights ,  System.Int32 groupThreshold ,  System.Double eps )
{
	bool isExc = NativeMethodsExc.objdetect_groupRectangles4_excsafe(rectList, rejectLevels, levelWeights, groupThreshold, eps);

	if(isExc)
		handleException();
}


public static  void objdetect_groupRectangles_meanshift( System.IntPtr rectList ,  System.IntPtr foundWeights ,  System.IntPtr foundScales ,  System.Double detectThreshold ,  OpenCvSharp.Size winDetSize )
{
	bool isExc = NativeMethodsExc.objdetect_groupRectangles_meanshift_excsafe(rectList, foundWeights, foundScales, detectThreshold, winDetSize);

	if(isExc)
		handleException();
}


public static  void optflow_motempl_updateMotionHistory( System.IntPtr silhouette ,  System.IntPtr mhi ,  System.Double timestamp ,  System.Double duration )
{
	bool isExc = NativeMethodsExc.optflow_motempl_updateMotionHistory_excsafe(silhouette, mhi, timestamp, duration);

	if(isExc)
		handleException();
}


public static  void optflow_motempl_calcMotionGradient( System.IntPtr mhi ,  System.IntPtr mask ,  System.IntPtr orientation ,  System.Double delta1 ,  System.Double delta2 ,  System.Int32 apertureSize )
{
	bool isExc = NativeMethodsExc.optflow_motempl_calcMotionGradient_excsafe(mhi, mask, orientation, delta1, delta2, apertureSize);

	if(isExc)
		handleException();
}


public static  System.Double optflow_motempl_calcGlobalOrientation( System.IntPtr orientation ,  System.IntPtr mask ,  System.IntPtr mhi ,  System.Double timestamp ,  System.Double duration )
{
	System.Double ret = new System.Double();
	bool isExc = NativeMethodsExc.optflow_motempl_calcGlobalOrientation_excsafe(ref ret, orientation, mask, mhi, timestamp, duration);

	if(isExc)
		handleException();
	return ret;
}


public static  void optflow_motempl_segmentMotion( System.IntPtr mhi ,  System.IntPtr segmask ,  System.IntPtr boundingRects ,  System.Double timestamp ,  System.Double segThresh )
{
	bool isExc = NativeMethodsExc.optflow_motempl_segmentMotion_excsafe(mhi, segmask, boundingRects, timestamp, segThresh);

	if(isExc)
		handleException();
}


public static  void optflow_calcOpticalFlowSF1( System.IntPtr from ,  System.IntPtr to ,  System.IntPtr flow ,  System.Int32 layers ,  System.Int32 averagingBlockSize ,  System.Int32 maxFlow )
{
	bool isExc = NativeMethodsExc.optflow_calcOpticalFlowSF1_excsafe(from, to, flow, layers, averagingBlockSize, maxFlow);

	if(isExc)
		handleException();
}


public static  void optflow_calcOpticalFlowSF2( System.IntPtr from ,  System.IntPtr to ,  System.IntPtr flow ,  System.Int32 layers ,  System.Int32 averagingBlockSize ,  System.Int32 maxFlow ,  System.Double sigmaDist ,  System.Double sigmaColor ,  System.Int32 postprocessWindow ,  System.Double sigmaDistFix ,  System.Double sigmaColorFix ,  System.Double occThr ,  System.Int32 upscaleAveragingRadius ,  System.Double upscaleSigmaDist ,  System.Double upscaleSigmaColor ,  System.Double speedUpThr )
{
	bool isExc = NativeMethodsExc.optflow_calcOpticalFlowSF2_excsafe(from, to, flow, layers, averagingBlockSize, maxFlow, sigmaDist, sigmaColor, postprocessWindow, sigmaDistFix, sigmaColorFix, occThr, upscaleAveragingRadius, upscaleSigmaDist, upscaleSigmaColor, speedUpThr);

	if(isExc)
		handleException();
}


public static  System.IntPtr string_new1()
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.string_new1_excsafe(ref ret);

	if(isExc)
		handleException();
	return ret;
}


public static  System.IntPtr string_new2([MarshalAs(UnmanagedType.LPStr)] System.String str )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.string_new2_excsafe(ref ret, str);

	if(isExc)
		handleException();
	return ret;
}


public static  void string_delete( System.IntPtr s )
{
	bool isExc = NativeMethodsExc.string_delete_excsafe(s);

	if(isExc)
		handleException();
}


public static  unsafe System.SByte* string_c_str( System.IntPtr s )
{
	IntPtr ret = new IntPtr();
	bool isExc = NativeMethodsExc.string_c_str_excsafe(ref ret, s);

	if(isExc)
		handleException();
	return (System.SByte*)ret;
}


public static  System.IntPtr string_size( System.IntPtr s )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.string_size_excsafe(ref ret, s);

	if(isExc)
		handleException();
	return ret;
}


public static  System.IntPtr vector_uchar_new1()
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.vector_uchar_new1_excsafe(ref ret);

	if(isExc)
		handleException();
	return ret;
}


public static  System.IntPtr vector_uchar_new2( System.IntPtr size )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.vector_uchar_new2_excsafe(ref ret, size);

	if(isExc)
		handleException();
	return ret;
}


public static  System.IntPtr vector_uchar_new3([In] System.Byte[] data ,  System.IntPtr dataLength )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.vector_uchar_new3_excsafe(ref ret, data, dataLength);

	if(isExc)
		handleException();
	return ret;
}


public static  System.IntPtr vector_uchar_getSize( System.IntPtr vector )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.vector_uchar_getSize_excsafe(ref ret, vector);

	if(isExc)
		handleException();
	return ret;
}


public static  System.IntPtr vector_uchar_getPointer( System.IntPtr vector )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.vector_uchar_getPointer_excsafe(ref ret, vector);

	if(isExc)
		handleException();
	return ret;
}


public static  void vector_vector_uchar_copy( System.IntPtr vector ,  System.IntPtr dst )
{
	bool isExc = NativeMethodsExc.vector_vector_uchar_copy_excsafe(vector, dst);

	if(isExc)
		handleException();
}


public static  void vector_uchar_delete( System.IntPtr vector )
{
	bool isExc = NativeMethodsExc.vector_uchar_delete_excsafe(vector);

	if(isExc)
		handleException();
}


public static  void objdetect_HOGDescriptor_save( System.IntPtr self , [MarshalAs(UnmanagedType.LPStr)] System.String filename , [MarshalAs(UnmanagedType.LPStr)] System.String objname )
{
	bool isExc = NativeMethodsExc.objdetect_HOGDescriptor_save_excsafe(self, filename, objname);

	if(isExc)
		handleException();
}


public static  void objdetect_HOGDescriptor_compute( System.IntPtr self ,  System.IntPtr img ,  System.IntPtr descriptors ,  OpenCvSharp.Size winStride ,  OpenCvSharp.Size padding , [In] OpenCvSharp.Point[] locations ,  System.Int32 locationsLength )
{
	bool isExc = NativeMethodsExc.objdetect_HOGDescriptor_compute_excsafe(self, img, descriptors, winStride, padding, locations, locationsLength);

	if(isExc)
		handleException();
}


public static  void objdetect_HOGDescriptor_detect1( System.IntPtr self ,  System.IntPtr img ,  System.IntPtr foundLocations ,  System.Double hitThreshold ,  OpenCvSharp.Size winStride ,  OpenCvSharp.Size padding , [In] OpenCvSharp.Point[] searchLocations ,  System.Int32 searchLocationsLength )
{
	bool isExc = NativeMethodsExc.objdetect_HOGDescriptor_detect1_excsafe(self, img, foundLocations, hitThreshold, winStride, padding, searchLocations, searchLocationsLength);

	if(isExc)
		handleException();
}


public static  void objdetect_HOGDescriptor_detect2( System.IntPtr self ,  System.IntPtr img ,  System.IntPtr foundLocations ,  System.IntPtr weights ,  System.Double hitThreshold ,  OpenCvSharp.Size winStride ,  OpenCvSharp.Size padding , [In] OpenCvSharp.Point[] searchLocations ,  System.Int32 searchLocationsLength )
{
	bool isExc = NativeMethodsExc.objdetect_HOGDescriptor_detect2_excsafe(self, img, foundLocations, weights, hitThreshold, winStride, padding, searchLocations, searchLocationsLength);

	if(isExc)
		handleException();
}


public static  void objdetect_HOGDescriptor_detectMultiScale1( System.IntPtr self ,  System.IntPtr img ,  System.IntPtr foundLocations ,  System.Double hitThreshold ,  OpenCvSharp.Size winStride ,  OpenCvSharp.Size padding ,  System.Double scale ,  System.Int32 groupThreshold )
{
	bool isExc = NativeMethodsExc.objdetect_HOGDescriptor_detectMultiScale1_excsafe(self, img, foundLocations, hitThreshold, winStride, padding, scale, groupThreshold);

	if(isExc)
		handleException();
}


public static  void objdetect_HOGDescriptor_detectMultiScale2( System.IntPtr self ,  System.IntPtr img ,  System.IntPtr foundLocations ,  System.IntPtr foundWeights ,  System.Double hitThreshold ,  OpenCvSharp.Size winStride ,  OpenCvSharp.Size padding ,  System.Double scale ,  System.Int32 groupThreshold )
{
	bool isExc = NativeMethodsExc.objdetect_HOGDescriptor_detectMultiScale2_excsafe(self, img, foundLocations, foundWeights, hitThreshold, winStride, padding, scale, groupThreshold);

	if(isExc)
		handleException();
}


public static  void objdetect_HOGDescriptor_computeGradient( System.IntPtr self ,  System.IntPtr img ,  System.IntPtr grad ,  System.IntPtr angleOfs ,  OpenCvSharp.Size paddingTL ,  OpenCvSharp.Size paddingBR )
{
	bool isExc = NativeMethodsExc.objdetect_HOGDescriptor_computeGradient_excsafe(self, img, grad, angleOfs, paddingTL, paddingBR);

	if(isExc)
		handleException();
}


public static  void objdetect_HOGDescriptor_detectROI( System.IntPtr obj ,  System.IntPtr img ,  OpenCvSharp.Point[] locations ,  System.Int32 locationsLength ,  System.IntPtr foundLocations ,  System.IntPtr confidences ,  System.Double hitThreshold ,  OpenCvSharp.Size winStride ,  OpenCvSharp.Size padding )
{
	bool isExc = NativeMethodsExc.objdetect_HOGDescriptor_detectROI_excsafe(obj, img, locations, locationsLength, foundLocations, confidences, hitThreshold, winStride, padding);

	if(isExc)
		handleException();
}


public static  void objdetect_HOGDescriptor_detectMultiScaleROI( System.IntPtr obj ,  System.IntPtr img ,  System.IntPtr foundLocations ,  System.IntPtr roiScales ,  System.IntPtr roiLocations ,  System.IntPtr roiConfidences ,  System.Double hitThreshold ,  System.Int32 groupThreshold )
{
	bool isExc = NativeMethodsExc.objdetect_HOGDescriptor_detectMultiScaleROI_excsafe(obj, img, foundLocations, roiScales, roiLocations, roiConfidences, hitThreshold, groupThreshold);

	if(isExc)
		handleException();
}


public static  void objdetect_HOGDescriptor_readALTModel( System.IntPtr obj , [MarshalAs(UnmanagedType.LPStr)] System.String modelfile )
{
	bool isExc = NativeMethodsExc.objdetect_HOGDescriptor_readALTModel_excsafe(obj, modelfile);

	if(isExc)
		handleException();
}


public static  void objdetect_HOGDescriptor_groupRectangles( System.IntPtr obj ,  System.IntPtr rectList ,  System.IntPtr weights ,  System.Int32 groupThreshold ,  System.Double eps )
{
	bool isExc = NativeMethodsExc.objdetect_HOGDescriptor_groupRectangles_excsafe(obj, rectList, weights, groupThreshold, eps);

	if(isExc)
		handleException();
}


public static  OpenCvSharp.Size objdetect_HOGDescriptor_winSize_get( System.IntPtr self )
{
	OpenCvSharp.Size ret = new OpenCvSharp.Size();
	bool isExc = NativeMethodsExc.objdetect_HOGDescriptor_winSize_get_excsafe(ref ret, self);

	if(isExc)
		handleException();
	return ret;
}


public static  OpenCvSharp.Size objdetect_HOGDescriptor_blockSize_get( System.IntPtr self )
{
	OpenCvSharp.Size ret = new OpenCvSharp.Size();
	bool isExc = NativeMethodsExc.objdetect_HOGDescriptor_blockSize_get_excsafe(ref ret, self);

	if(isExc)
		handleException();
	return ret;
}


public static  OpenCvSharp.Size objdetect_HOGDescriptor_blockStride_get( System.IntPtr self )
{
	OpenCvSharp.Size ret = new OpenCvSharp.Size();
	bool isExc = NativeMethodsExc.objdetect_HOGDescriptor_blockStride_get_excsafe(ref ret, self);

	if(isExc)
		handleException();
	return ret;
}


public static  OpenCvSharp.Size objdetect_HOGDescriptor_cellSize_get( System.IntPtr self )
{
	OpenCvSharp.Size ret = new OpenCvSharp.Size();
	bool isExc = NativeMethodsExc.objdetect_HOGDescriptor_cellSize_get_excsafe(ref ret, self);

	if(isExc)
		handleException();
	return ret;
}


public static  System.Int32 objdetect_HOGDescriptor_nbins_get( System.IntPtr self )
{
	System.Int32 ret = new System.Int32();
	bool isExc = NativeMethodsExc.objdetect_HOGDescriptor_nbins_get_excsafe(ref ret, self);

	if(isExc)
		handleException();
	return ret;
}


public static  System.Int32 objdetect_HOGDescriptor_derivAperture_get( System.IntPtr self )
{
	System.Int32 ret = new System.Int32();
	bool isExc = NativeMethodsExc.objdetect_HOGDescriptor_derivAperture_get_excsafe(ref ret, self);

	if(isExc)
		handleException();
	return ret;
}


public static  System.Double objdetect_HOGDescriptor_winSigma_get( System.IntPtr self )
{
	System.Double ret = new System.Double();
	bool isExc = NativeMethodsExc.objdetect_HOGDescriptor_winSigma_get_excsafe(ref ret, self);

	if(isExc)
		handleException();
	return ret;
}


public static  System.Int32 objdetect_HOGDescriptor_histogramNormType_get( System.IntPtr self )
{
	System.Int32 ret = new System.Int32();
	bool isExc = NativeMethodsExc.objdetect_HOGDescriptor_histogramNormType_get_excsafe(ref ret, self);

	if(isExc)
		handleException();
	return ret;
}


public static  System.Double objdetect_HOGDescriptor_L2HysThreshold_get( System.IntPtr self )
{
	System.Double ret = new System.Double();
	bool isExc = NativeMethodsExc.objdetect_HOGDescriptor_L2HysThreshold_get_excsafe(ref ret, self);

	if(isExc)
		handleException();
	return ret;
}


public static  System.Int32 objdetect_HOGDescriptor_gammaCorrection_get( System.IntPtr self )
{
	System.Int32 ret = new System.Int32();
	bool isExc = NativeMethodsExc.objdetect_HOGDescriptor_gammaCorrection_get_excsafe(ref ret, self);

	if(isExc)
		handleException();
	return ret;
}


public static  System.Int32 objdetect_HOGDescriptor_nlevels_get( System.IntPtr self )
{
	System.Int32 ret = new System.Int32();
	bool isExc = NativeMethodsExc.objdetect_HOGDescriptor_nlevels_get_excsafe(ref ret, self);

	if(isExc)
		handleException();
	return ret;
}


public static  void objdetect_HOGDescriptor_winSize_set( System.IntPtr self ,  OpenCvSharp.Size value )
{
	bool isExc = NativeMethodsExc.objdetect_HOGDescriptor_winSize_set_excsafe(self, value);

	if(isExc)
		handleException();
}


public static  void objdetect_HOGDescriptor_blockSize_set( System.IntPtr self ,  OpenCvSharp.Size value )
{
	bool isExc = NativeMethodsExc.objdetect_HOGDescriptor_blockSize_set_excsafe(self, value);

	if(isExc)
		handleException();
}


public static  void objdetect_HOGDescriptor_blockStride_set( System.IntPtr self ,  OpenCvSharp.Size value )
{
	bool isExc = NativeMethodsExc.objdetect_HOGDescriptor_blockStride_set_excsafe(self, value);

	if(isExc)
		handleException();
}


public static  void objdetect_HOGDescriptor_cellSize_set( System.IntPtr self ,  OpenCvSharp.Size value )
{
	bool isExc = NativeMethodsExc.objdetect_HOGDescriptor_cellSize_set_excsafe(self, value);

	if(isExc)
		handleException();
}


public static  void objdetect_HOGDescriptor_nbins_set( System.IntPtr self ,  System.Int32 value )
{
	bool isExc = NativeMethodsExc.objdetect_HOGDescriptor_nbins_set_excsafe(self, value);

	if(isExc)
		handleException();
}


public static  void objdetect_HOGDescriptor_derivAperture_set( System.IntPtr self ,  System.Int32 value )
{
	bool isExc = NativeMethodsExc.objdetect_HOGDescriptor_derivAperture_set_excsafe(self, value);

	if(isExc)
		handleException();
}


public static  System.IntPtr objdetect_LatentSvmDetector_new()
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.objdetect_LatentSvmDetector_new_excsafe(ref ret);

	if(isExc)
		handleException();
	return ret;
}


public static  void objdetect_LatentSvmDetector_delete( System.IntPtr obj )
{
	bool isExc = NativeMethodsExc.objdetect_LatentSvmDetector_delete_excsafe(obj);

	if(isExc)
		handleException();
}


public static  void objdetect_LatentSvmDetector_clear( System.IntPtr obj )
{
	bool isExc = NativeMethodsExc.objdetect_LatentSvmDetector_clear_excsafe(obj);

	if(isExc)
		handleException();
}


public static  System.Int32 objdetect_LatentSvmDetector_empty( System.IntPtr obj )
{
	System.Int32 ret = new System.Int32();
	bool isExc = NativeMethodsExc.objdetect_LatentSvmDetector_empty_excsafe(ref ret, obj);

	if(isExc)
		handleException();
	return ret;
}


public static  System.Int32 objdetect_LatentSvmDetector_load( System.IntPtr obj ,  System.IntPtr[] fileNames ,  System.Int32 fileNamesLength ,  System.IntPtr[] classNames ,  System.Int32 classNamesLength )
{
	System.Int32 ret = new System.Int32();
	bool isExc = NativeMethodsExc.objdetect_LatentSvmDetector_load_excsafe(ref ret, obj, fileNames, fileNamesLength, classNames, classNamesLength);

	if(isExc)
		handleException();
	return ret;
}


public static  void objdetect_LatentSvmDetector_detect( System.IntPtr obj ,  System.IntPtr image ,  System.IntPtr objectDetections ,  System.Single overlapThreshold ,  System.Int32 numThreads )
{
	bool isExc = NativeMethodsExc.objdetect_LatentSvmDetector_detect_excsafe(obj, image, objectDetections, overlapThreshold, numThreads);

	if(isExc)
		handleException();
}


public static  void objdetect_LatentSvmDetector_getClassNames( System.IntPtr obj ,  System.IntPtr outValues )
{
	bool isExc = NativeMethodsExc.objdetect_LatentSvmDetector_getClassNames_excsafe(obj, outValues);

	if(isExc)
		handleException();
}


public static  System.IntPtr objdetect_LatentSvmDetector_getClassCount( System.IntPtr obj )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.objdetect_LatentSvmDetector_getClassCount_excsafe(ref ret, obj);

	if(isExc)
		handleException();
	return ret;
}


public static  System.IntPtr objdetect_CascadeClassifier_new()
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.objdetect_CascadeClassifier_new_excsafe(ref ret);

	if(isExc)
		handleException();
	return ret;
}


public static  System.IntPtr objdetect_CascadeClassifier_newFromFile([MarshalAs(UnmanagedType.LPStr)] System.String fileName )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.objdetect_CascadeClassifier_newFromFile_excsafe(ref ret, fileName);

	if(isExc)
		handleException();
	return ret;
}


public static  void objdetect_CascadeClassifier_delete( System.IntPtr obj )
{
	bool isExc = NativeMethodsExc.objdetect_CascadeClassifier_delete_excsafe(obj);

	if(isExc)
		handleException();
}


public static  System.Int32 objdetect_CascadeClassifier_empty( System.IntPtr obj )
{
	System.Int32 ret = new System.Int32();
	bool isExc = NativeMethodsExc.objdetect_CascadeClassifier_empty_excsafe(ref ret, obj);

	if(isExc)
		handleException();
	return ret;
}


public static  System.Int32 objdetect_CascadeClassifier_load( System.IntPtr obj , [MarshalAs(UnmanagedType.LPStr)] System.String fileName )
{
	System.Int32 ret = new System.Int32();
	bool isExc = NativeMethodsExc.objdetect_CascadeClassifier_load_excsafe(ref ret, obj, fileName);

	if(isExc)
		handleException();
	return ret;
}


public static  void objdetect_CascadeClassifier_detectMultiScale1( System.IntPtr obj ,  System.IntPtr image ,  System.IntPtr objects ,  System.Double scaleFactor ,  System.Int32 minNeighbors ,  System.Int32 flags ,  OpenCvSharp.Size minSize ,  OpenCvSharp.Size maxSize )
{
	bool isExc = NativeMethodsExc.objdetect_CascadeClassifier_detectMultiScale1_excsafe(obj, image, objects, scaleFactor, minNeighbors, flags, minSize, maxSize);

	if(isExc)
		handleException();
}


public static  void objdetect_CascadeClassifier_detectMultiScale2( System.IntPtr obj ,  System.IntPtr image ,  System.IntPtr objects ,  System.IntPtr rejectLevels ,  System.IntPtr levelWeights ,  System.Double scaleFactor ,  System.Int32 minNeighbors ,  System.Int32 flags ,  OpenCvSharp.Size minSize ,  OpenCvSharp.Size maxSize ,  System.Int32 outputRejectLevels )
{
	bool isExc = NativeMethodsExc.objdetect_CascadeClassifier_detectMultiScale2_excsafe(obj, image, objects, rejectLevels, levelWeights, scaleFactor, minNeighbors, flags, minSize, maxSize, outputRejectLevels);

	if(isExc)
		handleException();
}


public static  System.Int32 objdetect_CascadeClassifier_isOldFormatCascade( System.IntPtr obj )
{
	System.Int32 ret = new System.Int32();
	bool isExc = NativeMethodsExc.objdetect_CascadeClassifier_isOldFormatCascade_excsafe(ref ret, obj);

	if(isExc)
		handleException();
	return ret;
}


public static  OpenCvSharp.Size objdetect_CascadeClassifier_getOriginalWindowSize( System.IntPtr obj )
{
	OpenCvSharp.Size ret = new OpenCvSharp.Size();
	bool isExc = NativeMethodsExc.objdetect_CascadeClassifier_getOriginalWindowSize_excsafe(ref ret, obj);

	if(isExc)
		handleException();
	return ret;
}


public static  System.Int32 objdetect_CascadeClassifier_getFeatureType( System.IntPtr obj )
{
	System.Int32 ret = new System.Int32();
	bool isExc = NativeMethodsExc.objdetect_CascadeClassifier_getFeatureType_excsafe(ref ret, obj);

	if(isExc)
		handleException();
	return ret;
}


public static  System.Int32 objdetect_HOGDescriptor_sizeof()
{
	System.Int32 ret = new System.Int32();
	bool isExc = NativeMethodsExc.objdetect_HOGDescriptor_sizeof_excsafe(ref ret);

	if(isExc)
		handleException();
	return ret;
}


public static  System.IntPtr objdetect_HOGDescriptor_new1()
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.objdetect_HOGDescriptor_new1_excsafe(ref ret);

	if(isExc)
		handleException();
	return ret;
}


public static  System.IntPtr objdetect_HOGDescriptor_new2( OpenCvSharp.Size winSize ,  OpenCvSharp.Size blockSize ,  OpenCvSharp.Size blockStride ,  OpenCvSharp.Size cellSize ,  System.Int32 nbins ,  System.Int32 derivAperture ,  System.Double winSigma , [MarshalAs(UnmanagedType.I4)] OpenCvSharp.HistogramNormType histogramNormType ,  System.Double l2HysThreshold ,  System.Int32 gammaCorrection ,  System.Int32 nlevels )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.objdetect_HOGDescriptor_new2_excsafe(ref ret, winSize, blockSize, blockStride, cellSize, nbins, derivAperture, winSigma, histogramNormType, l2HysThreshold, gammaCorrection, nlevels);

	if(isExc)
		handleException();
	return ret;
}


public static  System.IntPtr objdetect_HOGDescriptor_new3([MarshalAs(UnmanagedType.LPStr)] System.String fileName )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.objdetect_HOGDescriptor_new3_excsafe(ref ret, fileName);

	if(isExc)
		handleException();
	return ret;
}


public static  void objdetect_HOGDescriptor_delete( System.IntPtr self )
{
	bool isExc = NativeMethodsExc.objdetect_HOGDescriptor_delete_excsafe(self);

	if(isExc)
		handleException();
}


public static  System.IntPtr objdetect_HOGDescriptor_getDescriptorSize( System.IntPtr self )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.objdetect_HOGDescriptor_getDescriptorSize_excsafe(ref ret, self);

	if(isExc)
		handleException();
	return ret;
}


public static  System.Int32 objdetect_HOGDescriptor_checkDetectorSize( System.IntPtr self )
{
	System.Int32 ret = new System.Int32();
	bool isExc = NativeMethodsExc.objdetect_HOGDescriptor_checkDetectorSize_excsafe(ref ret, self);

	if(isExc)
		handleException();
	return ret;
}


public static  System.Double objdetect_HOGDescriptor_getWinSigma( System.IntPtr self )
{
	System.Double ret = new System.Double();
	bool isExc = NativeMethodsExc.objdetect_HOGDescriptor_getWinSigma_excsafe(ref ret, self);

	if(isExc)
		handleException();
	return ret;
}


public static  void objdetect_HOGDescriptor_setSVMDetector( System.IntPtr self ,  System.IntPtr svmdetector )
{
	bool isExc = NativeMethodsExc.objdetect_HOGDescriptor_setSVMDetector_excsafe(self, svmdetector);

	if(isExc)
		handleException();
}


public static  System.Boolean objdetect_HOGDescriptor_load( System.IntPtr self , [MarshalAs(UnmanagedType.LPStr)] System.String filename , [MarshalAs(UnmanagedType.LPStr)] System.String objname )
{
	System.Boolean ret = new System.Boolean();
	bool isExc = NativeMethodsExc.objdetect_HOGDescriptor_load_excsafe(ref ret, self, filename, objname);

	if(isExc)
		handleException();
	return ret;
}


public static  System.Double img_hash_ImgHashBase_compare( System.IntPtr obj ,  System.IntPtr hashOne ,  System.IntPtr hashTwo )
{
	System.Double ret = new System.Double();
	bool isExc = NativeMethodsExc.img_hash_ImgHashBase_compare_excsafe(ref ret, obj, hashOne, hashTwo);

	if(isExc)
		handleException();
	return ret;
}


public static  System.IntPtr img_hash_AverageHash_create()
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.img_hash_AverageHash_create_excsafe(ref ret);

	if(isExc)
		handleException();
	return ret;
}


public static  void img_hash_Ptr_AverageHash_delete( System.IntPtr ptr )
{
	bool isExc = NativeMethodsExc.img_hash_Ptr_AverageHash_delete_excsafe(ptr);

	if(isExc)
		handleException();
}


public static  System.IntPtr img_hash_Ptr_AverageHash_get( System.IntPtr ptr )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.img_hash_Ptr_AverageHash_get_excsafe(ref ret, ptr);

	if(isExc)
		handleException();
	return ret;
}


public static  System.IntPtr img_hash_BlockMeanHash_create( System.Int32 mode )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.img_hash_BlockMeanHash_create_excsafe(ref ret, mode);

	if(isExc)
		handleException();
	return ret;
}


public static  void img_hash_Ptr_BlockMeanHash_delete( System.IntPtr ptr )
{
	bool isExc = NativeMethodsExc.img_hash_Ptr_BlockMeanHash_delete_excsafe(ptr);

	if(isExc)
		handleException();
}


public static  System.IntPtr img_hash_Ptr_BlockMeanHash_get( System.IntPtr ptr )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.img_hash_Ptr_BlockMeanHash_get_excsafe(ref ret, ptr);

	if(isExc)
		handleException();
	return ret;
}


public static  void img_hash_BlockMeanHash_setMode( System.IntPtr obj ,  System.Int32 mode )
{
	bool isExc = NativeMethodsExc.img_hash_BlockMeanHash_setMode_excsafe(obj, mode);

	if(isExc)
		handleException();
}


public static  void img_hash_BlockMeanHash_getMean( System.IntPtr obj ,  System.IntPtr outVec )
{
	bool isExc = NativeMethodsExc.img_hash_BlockMeanHash_getMean_excsafe(obj, outVec);

	if(isExc)
		handleException();
}


public static  System.IntPtr img_hash_ColorMomentHash_create()
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.img_hash_ColorMomentHash_create_excsafe(ref ret);

	if(isExc)
		handleException();
	return ret;
}


public static  void img_hash_Ptr_ColorMomentHash_delete( System.IntPtr ptr )
{
	bool isExc = NativeMethodsExc.img_hash_Ptr_ColorMomentHash_delete_excsafe(ptr);

	if(isExc)
		handleException();
}


public static  System.IntPtr img_hash_Ptr_ColorMomentHash_get( System.IntPtr ptr )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.img_hash_Ptr_ColorMomentHash_get_excsafe(ref ret, ptr);

	if(isExc)
		handleException();
	return ret;
}


public static  System.IntPtr img_hash_MarrHildrethHash_create( System.Single alpha ,  System.Single scale )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.img_hash_MarrHildrethHash_create_excsafe(ref ret, alpha, scale);

	if(isExc)
		handleException();
	return ret;
}


public static  void img_hash_Ptr_MarrHildrethHash_delete( System.IntPtr ptr )
{
	bool isExc = NativeMethodsExc.img_hash_Ptr_MarrHildrethHash_delete_excsafe(ptr);

	if(isExc)
		handleException();
}


public static  System.IntPtr img_hash_Ptr_MarrHildrethHash_get( System.IntPtr ptr )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.img_hash_Ptr_MarrHildrethHash_get_excsafe(ref ret, ptr);

	if(isExc)
		handleException();
	return ret;
}


public static  void img_hash_MarrHildrethHash_setKernelParam( System.IntPtr obj ,  System.Single alpha ,  System.Single scale )
{
	bool isExc = NativeMethodsExc.img_hash_MarrHildrethHash_setKernelParam_excsafe(obj, alpha, scale);

	if(isExc)
		handleException();
}


public static  System.Single img_hash_MarrHildrethHash_getAlpha( System.IntPtr obj )
{
	System.Single ret = new System.Single();
	bool isExc = NativeMethodsExc.img_hash_MarrHildrethHash_getAlpha_excsafe(ref ret, obj);

	if(isExc)
		handleException();
	return ret;
}


public static  System.Single img_hash_MarrHildrethHash_getScale( System.IntPtr obj )
{
	System.Single ret = new System.Single();
	bool isExc = NativeMethodsExc.img_hash_MarrHildrethHash_getScale_excsafe(ref ret, obj);

	if(isExc)
		handleException();
	return ret;
}


public static  System.IntPtr img_hash_PHash_create()
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.img_hash_PHash_create_excsafe(ref ret);

	if(isExc)
		handleException();
	return ret;
}


public static  void img_hash_Ptr_PHash_delete( System.IntPtr ptr )
{
	bool isExc = NativeMethodsExc.img_hash_Ptr_PHash_delete_excsafe(ptr);

	if(isExc)
		handleException();
}


public static  System.IntPtr img_hash_Ptr_PHash_get( System.IntPtr ptr )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.img_hash_Ptr_PHash_get_excsafe(ref ret, ptr);

	if(isExc)
		handleException();
	return ret;
}


public static  System.IntPtr img_hash_RadialVarianceHash_create( System.Double sigma ,  System.Int32 numOfAngleLine )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.img_hash_RadialVarianceHash_create_excsafe(ref ret, sigma, numOfAngleLine);

	if(isExc)
		handleException();
	return ret;
}


public static  void img_hash_Ptr_RadialVarianceHash_delete( System.IntPtr ptr )
{
	bool isExc = NativeMethodsExc.img_hash_Ptr_RadialVarianceHash_delete_excsafe(ptr);

	if(isExc)
		handleException();
}


public static  System.IntPtr img_hash_Ptr_RadialVarianceHash_get( System.IntPtr ptr )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.img_hash_Ptr_RadialVarianceHash_get_excsafe(ref ret, ptr);

	if(isExc)
		handleException();
	return ret;
}


public static  void img_hash_RadialVarianceHash_setNumOfAngleLine( System.IntPtr obj ,  System.Int32 value )
{
	bool isExc = NativeMethodsExc.img_hash_RadialVarianceHash_setNumOfAngleLine_excsafe(obj, value);

	if(isExc)
		handleException();
}


public static  void img_hash_RadialVarianceHash_setSigma( System.IntPtr obj ,  System.Double value )
{
	bool isExc = NativeMethodsExc.img_hash_RadialVarianceHash_setSigma_excsafe(obj, value);

	if(isExc)
		handleException();
}


public static  System.Int32 img_hash_RadialVarianceHash_getNumOfAngleLine( System.IntPtr obj )
{
	System.Int32 ret = new System.Int32();
	bool isExc = NativeMethodsExc.img_hash_RadialVarianceHash_getNumOfAngleLine_excsafe(ref ret, obj);

	if(isExc)
		handleException();
	return ret;
}


public static  System.Double img_hash_RadialVarianceHash_getSigma( System.IntPtr obj )
{
	System.Double ret = new System.Double();
	bool isExc = NativeMethodsExc.img_hash_RadialVarianceHash_getSigma_excsafe(ref ret, obj);

	if(isExc)
		handleException();
	return ret;
}


public static  System.Int32 highgui_waitKey( System.Int32 delay )
{
	System.Int32 ret = new System.Int32();
	bool isExc = NativeMethodsExc.highgui_waitKey_excsafe(ref ret, delay);

	if(isExc)
		handleException();
	return ret;
}


public static  System.Int32 highgui_waitKeyEx( System.Int32 delay )
{
	System.Int32 ret = new System.Int32();
	bool isExc = NativeMethodsExc.highgui_waitKeyEx_excsafe(ref ret, delay);

	if(isExc)
		handleException();
	return ret;
}


public static  void highgui_resizeWindow([MarshalAs(UnmanagedType.LPStr)] System.String winName ,  System.Int32 width ,  System.Int32 height )
{
	bool isExc = NativeMethodsExc.highgui_resizeWindow_excsafe(winName, width, height);

	if(isExc)
		handleException();
}


public static  void highgui_moveWindow([MarshalAs(UnmanagedType.LPStr)] System.String winName ,  System.Int32 x ,  System.Int32 y )
{
	bool isExc = NativeMethodsExc.highgui_moveWindow_excsafe(winName, x, y);

	if(isExc)
		handleException();
}


public static  void highgui_setWindowProperty([MarshalAs(UnmanagedType.LPStr)] System.String winName ,  System.Int32 propId ,  System.Double propValue )
{
	bool isExc = NativeMethodsExc.highgui_setWindowProperty_excsafe(winName, propId, propValue);

	if(isExc)
		handleException();
}


public static  void highgui_setWindowTitle([MarshalAs(UnmanagedType.LPStr)] System.String winname , [MarshalAs(UnmanagedType.LPStr)] System.String title )
{
	bool isExc = NativeMethodsExc.highgui_setWindowTitle_excsafe(winname, title);

	if(isExc)
		handleException();
}


public static  System.Double highgui_getWindowProperty([MarshalAs(UnmanagedType.LPStr)] System.String winName ,  System.Int32 propId )
{
	System.Double ret = new System.Double();
	bool isExc = NativeMethodsExc.highgui_getWindowProperty_excsafe(ref ret, winName, propId);

	if(isExc)
		handleException();
	return ret;
}


public static  void highgui_setMouseCallback( System.String winName , [MarshalAs(UnmanagedType.FunctionPtr)] OpenCvSharp.CvMouseCallback onMouse ,  System.IntPtr userData )
{
	bool isExc = NativeMethodsExc.highgui_setMouseCallback_excsafe(winName, onMouse, userData);

	if(isExc)
		handleException();
}


public static  System.Int32 highgui_getMouseWheelDelta( System.Int32 flags )
{
	System.Int32 ret = new System.Int32();
	bool isExc = NativeMethodsExc.highgui_getMouseWheelDelta_excsafe(ref ret, flags);

	if(isExc)
		handleException();
	return ret;
}


public static  System.Int32 highgui_createTrackbar([MarshalAs(UnmanagedType.LPStr)] System.String trackbarName , [MarshalAs(UnmanagedType.LPStr)] System.String winName ,  ref System.Int32 value ,  System.Int32 count ,  System.IntPtr onChange ,  System.IntPtr userData )
{
	System.Int32 ret = new System.Int32();
	bool isExc = NativeMethodsExc.highgui_createTrackbar_excsafe(ref ret, trackbarName, winName,  ref value, count, onChange, userData);

	if(isExc)
		handleException();
	return ret;
}


public static  System.Int32 highgui_createTrackbar([MarshalAs(UnmanagedType.LPStr)] System.String trackbarName , [MarshalAs(UnmanagedType.LPStr)] System.String winName ,  ref System.Int32 value ,  System.Int32 count , [MarshalAs(UnmanagedType.FunctionPtr)] OpenCvSharp.CvTrackbarCallback2 onChange ,  System.IntPtr userData )
{
	System.Int32 ret = new System.Int32();
	bool isExc = NativeMethodsExc.highgui_createTrackbar_excsafe(ref ret, trackbarName, winName,  ref value, count, onChange, userData);

	if(isExc)
		handleException();
	return ret;
}


public static  System.Int32 highgui_getTrackbarPos([MarshalAs(UnmanagedType.LPStr)] System.String trackbarName , [MarshalAs(UnmanagedType.LPStr)] System.String winName )
{
	System.Int32 ret = new System.Int32();
	bool isExc = NativeMethodsExc.highgui_getTrackbarPos_excsafe(ref ret, trackbarName, winName);

	if(isExc)
		handleException();
	return ret;
}


public static  void highgui_setTrackbarPos( System.String trackbarName ,  System.String winName ,  System.Int32 pos )
{
	bool isExc = NativeMethodsExc.highgui_setTrackbarPos_excsafe(trackbarName, winName, pos);

	if(isExc)
		handleException();
}


public static  void highgui_setTrackbarMax([MarshalAs(UnmanagedType.LPStr)] System.String trackbarname , [MarshalAs(UnmanagedType.LPStr)] System.String winname ,  System.Int32 maxval )
{
	bool isExc = NativeMethodsExc.highgui_setTrackbarMax_excsafe(trackbarname, winname, maxval);

	if(isExc)
		handleException();
}


public static  void highgui_setTrackbarMin([MarshalAs(UnmanagedType.LPStr)] System.String trackbarname , [MarshalAs(UnmanagedType.LPStr)] System.String winname ,  System.Int32 minval )
{
	bool isExc = NativeMethodsExc.highgui_setTrackbarMin_excsafe(trackbarname, winname, minval);

	if(isExc)
		handleException();
}


public static  System.Int32 highgui_createButton([MarshalAs(UnmanagedType.LPStr)] System.String barName ,  System.IntPtr onChange ,  System.IntPtr userdata ,  System.Int32 type ,  System.Int32 initialButtonState )
{
	System.Int32 ret = new System.Int32();
	bool isExc = NativeMethodsExc.highgui_createButton_excsafe(ref ret, barName, onChange, userdata, type, initialButtonState);

	if(isExc)
		handleException();
	return ret;
}


public static  System.IntPtr imgcodecs_imread( System.String filename ,  System.Int32 flags )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.imgcodecs_imread_excsafe(ref ret, filename, flags);

	if(isExc)
		handleException();
	return ret;
}


public static  System.Int32 imgcodecs_imreadmulti([MarshalAs(UnmanagedType.LPStr)] System.String filename ,  System.IntPtr mats ,  System.Int32 flags )
{
	System.Int32 ret = new System.Int32();
	bool isExc = NativeMethodsExc.imgcodecs_imreadmulti_excsafe(ref ret, filename, mats, flags);

	if(isExc)
		handleException();
	return ret;
}


public static  System.Int32 imgcodecs_imwrite([MarshalAs(UnmanagedType.LPStr)] System.String filename ,  System.IntPtr img , [In] System.Int32[] @params ,  System.Int32 paramsLength )
{
	System.Int32 ret = new System.Int32();
	bool isExc = NativeMethodsExc.imgcodecs_imwrite_excsafe(ref ret, filename, img, @params, paramsLength);

	if(isExc)
		handleException();
	return ret;
}


public static  System.IntPtr imgcodecs_imdecode_Mat( System.IntPtr buf ,  System.Int32 flags )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.imgcodecs_imdecode_Mat_excsafe(ref ret, buf, flags);

	if(isExc)
		handleException();
	return ret;
}


public static  System.IntPtr imgcodecs_imdecode_vector( System.Byte[] buf ,  System.IntPtr bufLength ,  System.Int32 flags )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.imgcodecs_imdecode_vector_excsafe(ref ret, buf, bufLength, flags);

	if(isExc)
		handleException();
	return ret;
}


public static  System.IntPtr imgcodecs_imdecode_InputArray( System.IntPtr buf ,  System.Int32 flags )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.imgcodecs_imdecode_InputArray_excsafe(ref ret, buf, flags);

	if(isExc)
		handleException();
	return ret;
}


public static  System.Int32 imgcodecs_imencode_vector([MarshalAs(UnmanagedType.LPStr)] System.String ext ,  System.IntPtr img ,  System.IntPtr buf , [In] System.Int32[] @params ,  System.Int32 paramsLength )
{
	System.Int32 ret = new System.Int32();
	bool isExc = NativeMethodsExc.imgcodecs_imencode_vector_excsafe(ref ret, ext, img, buf, @params, paramsLength);

	if(isExc)
		handleException();
	return ret;
}


public static  void imgcodecs_cvConvertImage_CvArr( System.IntPtr src ,  System.IntPtr dst ,  System.Int32 flags )
{
	bool isExc = NativeMethodsExc.imgcodecs_cvConvertImage_CvArr_excsafe(src, dst, flags);

	if(isExc)
		handleException();
}


public static  void imgcodecs_cvConvertImage_Mat( System.IntPtr src ,  System.IntPtr dst ,  System.Int32 flags )
{
	bool isExc = NativeMethodsExc.imgcodecs_cvConvertImage_Mat_excsafe(src, dst, flags);

	if(isExc)
		handleException();
}


public static  System.Int32 imgcodecs_cvHaveImageReader([MarshalAs(UnmanagedType.LPStr)] System.String fileName )
{
	System.Int32 ret = new System.Int32();
	bool isExc = NativeMethodsExc.imgcodecs_cvHaveImageReader_excsafe(ref ret, fileName);

	if(isExc)
		handleException();
	return ret;
}


public static  System.Int32 imgcodecs_cvHaveImageWriter([MarshalAs(UnmanagedType.LPStr)] System.String fileName )
{
	System.Int32 ret = new System.Int32();
	bool isExc = NativeMethodsExc.imgcodecs_cvHaveImageWriter_excsafe(ref ret, fileName);

	if(isExc)
		handleException();
	return ret;
}


public static  void img_hash_ImgHashBase_compute( System.IntPtr obj ,  System.IntPtr inputArr ,  System.IntPtr outputArr )
{
	bool isExc = NativeMethodsExc.img_hash_ImgHashBase_compute_excsafe(obj, inputArr, outputArr);

	if(isExc)
		handleException();
}


public static  System.IntPtr flann_Ptr_LshIndexParams_new( System.Int32 tableNumber ,  System.Int32 keySize ,  System.Int32 multiProbeLevel )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.flann_Ptr_LshIndexParams_new_excsafe(ref ret, tableNumber, keySize, multiProbeLevel);

	if(isExc)
		handleException();
	return ret;
}


public static  System.IntPtr flann_Ptr_LshIndexParams_get( System.IntPtr ptr )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.flann_Ptr_LshIndexParams_get_excsafe(ref ret, ptr);

	if(isExc)
		handleException();
	return ret;
}


public static  void flann_Ptr_LshIndexParams_delete( System.IntPtr obj )
{
	bool isExc = NativeMethodsExc.flann_Ptr_LshIndexParams_delete_excsafe(obj);

	if(isExc)
		handleException();
}


public static  System.IntPtr flann_CompositeIndexParams_new( System.Int32 trees ,  System.Int32 branching ,  System.Int32 iterations ,  OpenCvSharp.Flann.FlannCentersInit centersInit ,  System.Single cbIndex )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.flann_CompositeIndexParams_new_excsafe(ref ret, trees, branching, iterations, centersInit, cbIndex);

	if(isExc)
		handleException();
	return ret;
}


public static  void flann_CompositeIndexParams_delete( System.IntPtr obj )
{
	bool isExc = NativeMethodsExc.flann_CompositeIndexParams_delete_excsafe(obj);

	if(isExc)
		handleException();
}


public static  System.IntPtr flann_Ptr_CompositeIndexParams_new( System.Int32 trees ,  System.Int32 branching ,  System.Int32 iterations ,  OpenCvSharp.Flann.FlannCentersInit centersInit ,  System.Single cbIndex )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.flann_Ptr_CompositeIndexParams_new_excsafe(ref ret, trees, branching, iterations, centersInit, cbIndex);

	if(isExc)
		handleException();
	return ret;
}


public static  System.IntPtr flann_Ptr_CompositeIndexParams_get( System.IntPtr ptr )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.flann_Ptr_CompositeIndexParams_get_excsafe(ref ret, ptr);

	if(isExc)
		handleException();
	return ret;
}


public static  void flann_Ptr_CompositeIndexParams_delete( System.IntPtr obj )
{
	bool isExc = NativeMethodsExc.flann_Ptr_CompositeIndexParams_delete_excsafe(obj);

	if(isExc)
		handleException();
}


public static  System.IntPtr flann_AutotunedIndexParams_new( System.Single targetPrecision ,  System.Single buildWeight ,  System.Single memoryWeight ,  System.Single sampleFraction )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.flann_AutotunedIndexParams_new_excsafe(ref ret, targetPrecision, buildWeight, memoryWeight, sampleFraction);

	if(isExc)
		handleException();
	return ret;
}


public static  void flann_AutotunedIndexParams_delete( System.IntPtr obj )
{
	bool isExc = NativeMethodsExc.flann_AutotunedIndexParams_delete_excsafe(obj);

	if(isExc)
		handleException();
}


public static  System.IntPtr flann_Ptr_AutotunedIndexParams_new( System.Single targetPrecision ,  System.Single buildWeight ,  System.Single memoryWeight ,  System.Single sampleFraction )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.flann_Ptr_AutotunedIndexParams_new_excsafe(ref ret, targetPrecision, buildWeight, memoryWeight, sampleFraction);

	if(isExc)
		handleException();
	return ret;
}


public static  System.IntPtr flann_Ptr_AutotunedIndexParams_get( System.IntPtr ptr )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.flann_Ptr_AutotunedIndexParams_get_excsafe(ref ret, ptr);

	if(isExc)
		handleException();
	return ret;
}


public static  void flann_Ptr_AutotunedIndexParams_delete( System.IntPtr obj )
{
	bool isExc = NativeMethodsExc.flann_Ptr_AutotunedIndexParams_delete_excsafe(obj);

	if(isExc)
		handleException();
}


public static  System.IntPtr flann_SavedIndexParams_new([MarshalAs(UnmanagedType.LPStr)] System.String filename )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.flann_SavedIndexParams_new_excsafe(ref ret, filename);

	if(isExc)
		handleException();
	return ret;
}


public static  void flann_SavedIndexParams_delete( System.IntPtr obj )
{
	bool isExc = NativeMethodsExc.flann_SavedIndexParams_delete_excsafe(obj);

	if(isExc)
		handleException();
}


public static  System.IntPtr flann_Ptr_SavedIndexParams_new([MarshalAs(UnmanagedType.LPStr)] System.String filename )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.flann_Ptr_SavedIndexParams_new_excsafe(ref ret, filename);

	if(isExc)
		handleException();
	return ret;
}


public static  System.IntPtr flann_Ptr_SavedIndexParams_get( System.IntPtr ptr )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.flann_Ptr_SavedIndexParams_get_excsafe(ref ret, ptr);

	if(isExc)
		handleException();
	return ret;
}


public static  void flann_Ptr_SavedIndexParams_delete( System.IntPtr obj )
{
	bool isExc = NativeMethodsExc.flann_Ptr_SavedIndexParams_delete_excsafe(obj);

	if(isExc)
		handleException();
}


public static  System.IntPtr flann_SearchParams_new( System.Int32 checks ,  System.Single eps ,  System.Int32 sorted )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.flann_SearchParams_new_excsafe(ref ret, checks, eps, sorted);

	if(isExc)
		handleException();
	return ret;
}


public static  void flann_SearchParams_delete( System.IntPtr obj )
{
	bool isExc = NativeMethodsExc.flann_SearchParams_delete_excsafe(obj);

	if(isExc)
		handleException();
}


public static  System.IntPtr flann_Ptr_SearchParams_new( System.Int32 checks ,  System.Single eps ,  System.Int32 sorted )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.flann_Ptr_SearchParams_new_excsafe(ref ret, checks, eps, sorted);

	if(isExc)
		handleException();
	return ret;
}


public static  System.IntPtr flann_Ptr_SearchParams_get( System.IntPtr ptr )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.flann_Ptr_SearchParams_get_excsafe(ref ret, ptr);

	if(isExc)
		handleException();
	return ret;
}


public static  void flann_Ptr_SearchParams_delete( System.IntPtr obj )
{
	bool isExc = NativeMethodsExc.flann_Ptr_SearchParams_delete_excsafe(obj);

	if(isExc)
		handleException();
}


public static  void highgui_namedWindow([MarshalAs(UnmanagedType.LPStr)] System.String winname ,  System.Int32 flags )
{
	bool isExc = NativeMethodsExc.highgui_namedWindow_excsafe(winname, flags);

	if(isExc)
		handleException();
}


public static  void highgui_destroyWindow([MarshalAs(UnmanagedType.LPStr)] System.String winName )
{
	bool isExc = NativeMethodsExc.highgui_destroyWindow_excsafe(winName);

	if(isExc)
		handleException();
}


public static  void highgui_destroyAllWindows()
{
	bool isExc = NativeMethodsExc.highgui_destroyAllWindows_excsafe();

	if(isExc)
		handleException();
}


public static  void highgui_imshow([MarshalAs(UnmanagedType.LPStr)] System.String winname ,  System.IntPtr mat )
{
	bool isExc = NativeMethodsExc.highgui_imshow_excsafe(winname, mat);

	if(isExc)
		handleException();
}


public static  System.Int32 highgui_startWindowThread()
{
	System.Int32 ret = new System.Int32();
	bool isExc = NativeMethodsExc.highgui_startWindowThread_excsafe(ref ret);

	if(isExc)
		handleException();
	return ret;
}


public static  System.IntPtr flann_Ptr_IndexParams_get( System.IntPtr ptr )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.flann_Ptr_IndexParams_get_excsafe(ref ret, ptr);

	if(isExc)
		handleException();
	return ret;
}


public static  void flann_Ptr_IndexParams_delete( System.IntPtr obj )
{
	bool isExc = NativeMethodsExc.flann_Ptr_IndexParams_delete_excsafe(obj);

	if(isExc)
		handleException();
}


public static  void flann_IndexParams_getString( System.IntPtr obj , [MarshalAs(UnmanagedType.LPStr)] System.String key , [MarshalAs(UnmanagedType.LPStr)] System.String defaultVal , [MarshalAs(UnmanagedType.LPStr)] System.Text.StringBuilder result )
{
	bool isExc = NativeMethodsExc.flann_IndexParams_getString_excsafe(obj, key, defaultVal, result);

	if(isExc)
		handleException();
}


public static  System.Int32 flann_IndexParams_getInt( System.IntPtr obj , [MarshalAs(UnmanagedType.LPStr)] System.String key ,  System.Int32 defaultVal )
{
	System.Int32 ret = new System.Int32();
	bool isExc = NativeMethodsExc.flann_IndexParams_getInt_excsafe(ref ret, obj, key, defaultVal);

	if(isExc)
		handleException();
	return ret;
}


public static  System.Double flann_IndexParams_getDouble( System.IntPtr obj , [MarshalAs(UnmanagedType.LPStr)] System.String key ,  System.Double defaultVal )
{
	System.Double ret = new System.Double();
	bool isExc = NativeMethodsExc.flann_IndexParams_getDouble_excsafe(ref ret, obj, key, defaultVal);

	if(isExc)
		handleException();
	return ret;
}


public static  void flann_IndexParams_setString( System.IntPtr obj , [MarshalAs(UnmanagedType.LPStr)] System.String key , [MarshalAs(UnmanagedType.LPStr)] System.String value )
{
	bool isExc = NativeMethodsExc.flann_IndexParams_setString_excsafe(obj, key, value);

	if(isExc)
		handleException();
}


public static  void flann_IndexParams_setInt( System.IntPtr obj , [MarshalAs(UnmanagedType.LPStr)] System.String key ,  System.Int32 value )
{
	bool isExc = NativeMethodsExc.flann_IndexParams_setInt_excsafe(obj, key, value);

	if(isExc)
		handleException();
}


public static  void flann_IndexParams_setDouble( System.IntPtr obj , [MarshalAs(UnmanagedType.LPStr)] System.String key ,  System.Double value )
{
	bool isExc = NativeMethodsExc.flann_IndexParams_setDouble_excsafe(obj, key, value);

	if(isExc)
		handleException();
}


public static  void flann_IndexParams_setFloat( System.IntPtr obj , [MarshalAs(UnmanagedType.LPStr)] System.String key ,  System.Single value )
{
	bool isExc = NativeMethodsExc.flann_IndexParams_setFloat_excsafe(obj, key, value);

	if(isExc)
		handleException();
}


public static  void flann_IndexParams_setBool( System.IntPtr obj , [MarshalAs(UnmanagedType.LPStr)] System.String key ,  System.Int32 value )
{
	bool isExc = NativeMethodsExc.flann_IndexParams_setBool_excsafe(obj, key, value);

	if(isExc)
		handleException();
}


public static  void flann_IndexParams_setAlgorithm( System.IntPtr obj ,  System.Int32 value )
{
	bool isExc = NativeMethodsExc.flann_IndexParams_setAlgorithm_excsafe(obj, value);

	if(isExc)
		handleException();
}


public static  System.IntPtr flann_LinearIndexParams_new()
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.flann_LinearIndexParams_new_excsafe(ref ret);

	if(isExc)
		handleException();
	return ret;
}


public static  void flann_LinearIndexParams_delete( System.IntPtr obj )
{
	bool isExc = NativeMethodsExc.flann_LinearIndexParams_delete_excsafe(obj);

	if(isExc)
		handleException();
}


public static  System.IntPtr flann_Ptr_LinearIndexParams_new()
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.flann_Ptr_LinearIndexParams_new_excsafe(ref ret);

	if(isExc)
		handleException();
	return ret;
}


public static  System.IntPtr flann_Ptr_LinearIndexParams_get( System.IntPtr ptr )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.flann_Ptr_LinearIndexParams_get_excsafe(ref ret, ptr);

	if(isExc)
		handleException();
	return ret;
}


public static  void flann_Ptr_LinearIndexParams_delete( System.IntPtr obj )
{
	bool isExc = NativeMethodsExc.flann_Ptr_LinearIndexParams_delete_excsafe(obj);

	if(isExc)
		handleException();
}


public static  System.IntPtr flann_KDTreeIndexParams_new( System.Int32 trees )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.flann_KDTreeIndexParams_new_excsafe(ref ret, trees);

	if(isExc)
		handleException();
	return ret;
}


public static  void flann_KDTreeIndexParams_delete( System.IntPtr obj )
{
	bool isExc = NativeMethodsExc.flann_KDTreeIndexParams_delete_excsafe(obj);

	if(isExc)
		handleException();
}


public static  System.IntPtr flann_Ptr_KDTreeIndexParams_new( System.Int32 trees )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.flann_Ptr_KDTreeIndexParams_new_excsafe(ref ret, trees);

	if(isExc)
		handleException();
	return ret;
}


public static  System.IntPtr flann_Ptr_KDTreeIndexParams_get( System.IntPtr ptr )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.flann_Ptr_KDTreeIndexParams_get_excsafe(ref ret, ptr);

	if(isExc)
		handleException();
	return ret;
}


public static  void flann_Ptr_KDTreeIndexParams_delete( System.IntPtr obj )
{
	bool isExc = NativeMethodsExc.flann_Ptr_KDTreeIndexParams_delete_excsafe(obj);

	if(isExc)
		handleException();
}


public static  System.IntPtr flann_KMeansIndexParams_new( System.Int32 branching ,  System.Int32 iterations , [MarshalAs(UnmanagedType.I4)] OpenCvSharp.Flann.FlannCentersInit centersInit ,  System.Single cbIndex )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.flann_KMeansIndexParams_new_excsafe(ref ret, branching, iterations, centersInit, cbIndex);

	if(isExc)
		handleException();
	return ret;
}


public static  void flann_KMeansIndexParams_delete( System.IntPtr obj )
{
	bool isExc = NativeMethodsExc.flann_KMeansIndexParams_delete_excsafe(obj);

	if(isExc)
		handleException();
}


public static  System.IntPtr flann_Ptr_KMeansIndexParams_new( System.Int32 branching ,  System.Int32 iterations , [MarshalAs(UnmanagedType.I4)] OpenCvSharp.Flann.FlannCentersInit centersInit ,  System.Single cbIndex )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.flann_Ptr_KMeansIndexParams_new_excsafe(ref ret, branching, iterations, centersInit, cbIndex);

	if(isExc)
		handleException();
	return ret;
}


public static  System.IntPtr flann_Ptr_KMeansIndexParams_get( System.IntPtr ptr )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.flann_Ptr_KMeansIndexParams_get_excsafe(ref ret, ptr);

	if(isExc)
		handleException();
	return ret;
}


public static  void flann_Ptr_KMeansIndexParams_delete( System.IntPtr obj )
{
	bool isExc = NativeMethodsExc.flann_Ptr_KMeansIndexParams_delete_excsafe(obj);

	if(isExc)
		handleException();
}


public static  System.IntPtr flann_LshIndexParams_new( System.Int32 tableNumber ,  System.Int32 keySize ,  System.Int32 multiProbeLevel )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.flann_LshIndexParams_new_excsafe(ref ret, tableNumber, keySize, multiProbeLevel);

	if(isExc)
		handleException();
	return ret;
}


public static  void flann_LshIndexParams_delete( System.IntPtr obj )
{
	bool isExc = NativeMethodsExc.flann_LshIndexParams_delete_excsafe(obj);

	if(isExc)
		handleException();
}


public static  System.Int32 bgsegm_BackgroundSubtractorGMG_getNumFrames( System.IntPtr ptr )
{
	System.Int32 ret = new System.Int32();
	bool isExc = NativeMethodsExc.bgsegm_BackgroundSubtractorGMG_getNumFrames_excsafe(ref ret, ptr);

	if(isExc)
		handleException();
	return ret;
}


public static  void bgsegm_BackgroundSubtractorGMG_setNumFrames( System.IntPtr ptr ,  System.Int32 value )
{
	bool isExc = NativeMethodsExc.bgsegm_BackgroundSubtractorGMG_setNumFrames_excsafe(ptr, value);

	if(isExc)
		handleException();
}


public static  System.Int32 bgsegm_BackgroundSubtractorGMG_getQuantizationLevels( System.IntPtr ptr )
{
	System.Int32 ret = new System.Int32();
	bool isExc = NativeMethodsExc.bgsegm_BackgroundSubtractorGMG_getQuantizationLevels_excsafe(ref ret, ptr);

	if(isExc)
		handleException();
	return ret;
}


public static  void bgsegm_BackgroundSubtractorGMG_setQuantizationLevels( System.IntPtr ptr ,  System.Int32 value )
{
	bool isExc = NativeMethodsExc.bgsegm_BackgroundSubtractorGMG_setQuantizationLevels_excsafe(ptr, value);

	if(isExc)
		handleException();
}


public static  System.Double bgsegm_BackgroundSubtractorGMG_getBackgroundPrior( System.IntPtr ptr )
{
	System.Double ret = new System.Double();
	bool isExc = NativeMethodsExc.bgsegm_BackgroundSubtractorGMG_getBackgroundPrior_excsafe(ref ret, ptr);

	if(isExc)
		handleException();
	return ret;
}


public static  void bgsegm_BackgroundSubtractorGMG_setBackgroundPrior( System.IntPtr ptr ,  System.Double value )
{
	bool isExc = NativeMethodsExc.bgsegm_BackgroundSubtractorGMG_setBackgroundPrior_excsafe(ptr, value);

	if(isExc)
		handleException();
}


public static  System.Int32 bgsegm_BackgroundSubtractorGMG_getSmoothingRadius( System.IntPtr ptr )
{
	System.Int32 ret = new System.Int32();
	bool isExc = NativeMethodsExc.bgsegm_BackgroundSubtractorGMG_getSmoothingRadius_excsafe(ref ret, ptr);

	if(isExc)
		handleException();
	return ret;
}


public static  void bgsegm_BackgroundSubtractorGMG_setSmoothingRadius( System.IntPtr ptr ,  System.Int32 value )
{
	bool isExc = NativeMethodsExc.bgsegm_BackgroundSubtractorGMG_setSmoothingRadius_excsafe(ptr, value);

	if(isExc)
		handleException();
}


public static  System.Double bgsegm_BackgroundSubtractorGMG_getDecisionThreshold( System.IntPtr ptr )
{
	System.Double ret = new System.Double();
	bool isExc = NativeMethodsExc.bgsegm_BackgroundSubtractorGMG_getDecisionThreshold_excsafe(ref ret, ptr);

	if(isExc)
		handleException();
	return ret;
}


public static  void bgsegm_BackgroundSubtractorGMG_setDecisionThreshold( System.IntPtr ptr ,  System.Double value )
{
	bool isExc = NativeMethodsExc.bgsegm_BackgroundSubtractorGMG_setDecisionThreshold_excsafe(ptr, value);

	if(isExc)
		handleException();
}


public static  System.Int32 bgsegm_BackgroundSubtractorGMG_getUpdateBackgroundModel( System.IntPtr ptr )
{
	System.Int32 ret = new System.Int32();
	bool isExc = NativeMethodsExc.bgsegm_BackgroundSubtractorGMG_getUpdateBackgroundModel_excsafe(ref ret, ptr);

	if(isExc)
		handleException();
	return ret;
}


public static  void bgsegm_BackgroundSubtractorGMG_setUpdateBackgroundModel( System.IntPtr ptr ,  System.Int32 value )
{
	bool isExc = NativeMethodsExc.bgsegm_BackgroundSubtractorGMG_setUpdateBackgroundModel_excsafe(ptr, value);

	if(isExc)
		handleException();
}


public static  System.Double bgsegm_BackgroundSubtractorGMG_getMinVal( System.IntPtr ptr )
{
	System.Double ret = new System.Double();
	bool isExc = NativeMethodsExc.bgsegm_BackgroundSubtractorGMG_getMinVal_excsafe(ref ret, ptr);

	if(isExc)
		handleException();
	return ret;
}


public static  void bgsegm_BackgroundSubtractorGMG_setMinVal( System.IntPtr ptr ,  System.Double value )
{
	bool isExc = NativeMethodsExc.bgsegm_BackgroundSubtractorGMG_setMinVal_excsafe(ptr, value);

	if(isExc)
		handleException();
}


public static  System.Double bgsegm_BackgroundSubtractorGMG_getMaxVal( System.IntPtr ptr )
{
	System.Double ret = new System.Double();
	bool isExc = NativeMethodsExc.bgsegm_BackgroundSubtractorGMG_getMaxVal_excsafe(ref ret, ptr);

	if(isExc)
		handleException();
	return ret;
}


public static  void bgsegm_BackgroundSubtractorGMG_setMaxVal( System.IntPtr ptr ,  System.Double value )
{
	bool isExc = NativeMethodsExc.bgsegm_BackgroundSubtractorGMG_setMaxVal_excsafe(ptr, value);

	if(isExc)
		handleException();
}


public static  System.IntPtr flann_Index_new( System.IntPtr features ,  System.IntPtr @params ,  System.Int32 distType )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.flann_Index_new_excsafe(ref ret, features, @params, distType);

	if(isExc)
		handleException();
	return ret;
}


public static  void flann_Index_delete( System.IntPtr obj )
{
	bool isExc = NativeMethodsExc.flann_Index_delete_excsafe(obj);

	if(isExc)
		handleException();
}


public static  void flann_Index_knnSearch1( System.IntPtr obj , [In] System.Single[] queries ,  System.Int32 queriesLength , [Out] System.Int32[] indices , [Out] System.Single[] dists ,  System.Int32 knn ,  System.IntPtr @params )
{
	bool isExc = NativeMethodsExc.flann_Index_knnSearch1_excsafe(obj, queries, queriesLength, indices, dists, knn, @params);

	if(isExc)
		handleException();
}


public static  void flann_Index_knnSearch2( System.IntPtr obj ,  System.IntPtr queries ,  System.IntPtr indices ,  System.IntPtr dists ,  System.Int32 knn ,  System.IntPtr @params )
{
	bool isExc = NativeMethodsExc.flann_Index_knnSearch2_excsafe(obj, queries, indices, dists, knn, @params);

	if(isExc)
		handleException();
}


public static  void flann_Index_knnSearch3( System.IntPtr obj ,  System.IntPtr queries , [Out] System.Int32[] indices , [Out] System.Single[] dists ,  System.Int32 knn ,  System.IntPtr @params )
{
	bool isExc = NativeMethodsExc.flann_Index_knnSearch3_excsafe(obj, queries, indices, dists, knn, @params);

	if(isExc)
		handleException();
}


public static  void flann_Index_radiusSearch1( System.IntPtr obj , [In] System.Single[] queries ,  System.Int32 queriesLength , [Out] System.Int32[] indices ,  System.Int32 indicesLength , [Out] System.Single[] dists ,  System.Int32 dists_length ,  System.Single radius ,  System.Int32 maxResults ,  System.IntPtr @params )
{
	bool isExc = NativeMethodsExc.flann_Index_radiusSearch1_excsafe(obj, queries, queriesLength, indices, indicesLength, dists, dists_length, radius, maxResults, @params);

	if(isExc)
		handleException();
}


public static  void flann_Index_radiusSearch2( System.IntPtr obj ,  System.IntPtr queries ,  System.IntPtr indices ,  System.IntPtr dists ,  System.Single radius ,  System.Int32 maxResults ,  System.IntPtr @params )
{
	bool isExc = NativeMethodsExc.flann_Index_radiusSearch2_excsafe(obj, queries, indices, dists, radius, maxResults, @params);

	if(isExc)
		handleException();
}


public static  void flann_Index_radiusSearch3( System.IntPtr obj ,  System.IntPtr queries , [Out] System.Int32[] indices ,  System.Int32 indicesLength , [Out] System.Single[] dists ,  System.Int32 distsLength ,  System.Single radius ,  System.Int32 maxResults ,  System.IntPtr @params )
{
	bool isExc = NativeMethodsExc.flann_Index_radiusSearch3_excsafe(obj, queries, indices, indicesLength, dists, distsLength, radius, maxResults, @params);

	if(isExc)
		handleException();
}


public static  void flann_Index_save( System.IntPtr obj , [MarshalAs(UnmanagedType.LPStr)] System.String filename )
{
	bool isExc = NativeMethodsExc.flann_Index_save_excsafe(obj, filename);

	if(isExc)
		handleException();
}


public static  System.IntPtr flann_IndexParams_new()
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.flann_IndexParams_new_excsafe(ref ret);

	if(isExc)
		handleException();
	return ret;
}


public static  void flann_IndexParams_delete( System.IntPtr obj )
{
	bool isExc = NativeMethodsExc.flann_IndexParams_delete_excsafe(obj);

	if(isExc)
		handleException();
}


public static  System.IntPtr flann_Ptr_IndexParams_new()
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.flann_Ptr_IndexParams_new_excsafe(ref ret);

	if(isExc)
		handleException();
	return ret;
}


public static  System.Int32 aruco_DetectorParameters_getMarkerBorderBits( System.IntPtr obj )
{
	System.Int32 ret = new System.Int32();
	bool isExc = NativeMethodsExc.aruco_DetectorParameters_getMarkerBorderBits_excsafe(ref ret, obj);

	if(isExc)
		handleException();
	return ret;
}


public static  System.Int32 aruco_DetectorParameters_getMinDistanceToBorder( System.IntPtr obj )
{
	System.Int32 ret = new System.Int32();
	bool isExc = NativeMethodsExc.aruco_DetectorParameters_getMinDistanceToBorder_excsafe(ref ret, obj);

	if(isExc)
		handleException();
	return ret;
}


public static  System.Int32 aruco_DetectorParameters_getPerspectiveRemovePixelPerCell( System.IntPtr obj )
{
	System.Int32 ret = new System.Int32();
	bool isExc = NativeMethodsExc.aruco_DetectorParameters_getPerspectiveRemovePixelPerCell_excsafe(ref ret, obj);

	if(isExc)
		handleException();
	return ret;
}


public static  void aruco_Ptr_Dictionary_delete( System.IntPtr ptr )
{
	bool isExc = NativeMethodsExc.aruco_Ptr_Dictionary_delete_excsafe(ptr);

	if(isExc)
		handleException();
}


public static  System.IntPtr aruco_Ptr_Dictionary_get( System.IntPtr ptr )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.aruco_Ptr_Dictionary_get_excsafe(ref ret, ptr);

	if(isExc)
		handleException();
	return ret;
}


public static  void aruco_Dictionary_setMarkerSize( System.IntPtr obj ,  System.Int32 value )
{
	bool isExc = NativeMethodsExc.aruco_Dictionary_setMarkerSize_excsafe(obj, value);

	if(isExc)
		handleException();
}


public static  void aruco_Dictionary_setMaxCorrectionBits( System.IntPtr obj ,  System.Int32 value )
{
	bool isExc = NativeMethodsExc.aruco_Dictionary_setMaxCorrectionBits_excsafe(obj, value);

	if(isExc)
		handleException();
}


public static  System.IntPtr aruco_Dictionary_getBytesList( System.IntPtr obj )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.aruco_Dictionary_getBytesList_excsafe(ref ret, obj);

	if(isExc)
		handleException();
	return ret;
}


public static  System.Int32 aruco_Dictionary_getMarkerSize( System.IntPtr obj )
{
	System.Int32 ret = new System.Int32();
	bool isExc = NativeMethodsExc.aruco_Dictionary_getMarkerSize_excsafe(ref ret, obj);

	if(isExc)
		handleException();
	return ret;
}


public static  System.Int32 aruco_Dictionary_getMaxCorrectionBits( System.IntPtr obj )
{
	System.Int32 ret = new System.Int32();
	bool isExc = NativeMethodsExc.aruco_Dictionary_getMaxCorrectionBits_excsafe(ref ret, obj);

	if(isExc)
		handleException();
	return ret;
}


public static  System.IntPtr bgsegm_createBackgroundSubtractorMOG( System.Int32 history ,  System.Int32 nmixtures ,  System.Double backgroundRatio ,  System.Double noiseSigma )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.bgsegm_createBackgroundSubtractorMOG_excsafe(ref ret, history, nmixtures, backgroundRatio, noiseSigma);

	if(isExc)
		handleException();
	return ret;
}


public static  void bgsegm_Ptr_BackgroundSubtractorMOG_delete( System.IntPtr obj )
{
	bool isExc = NativeMethodsExc.bgsegm_Ptr_BackgroundSubtractorMOG_delete_excsafe(obj);

	if(isExc)
		handleException();
}


public static  System.IntPtr bgsegm_Ptr_BackgroundSubtractorMOG_get( System.IntPtr ptr )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.bgsegm_Ptr_BackgroundSubtractorMOG_get_excsafe(ref ret, ptr);

	if(isExc)
		handleException();
	return ret;
}


public static  System.Int32 bgsegm_BackgroundSubtractorMOG_getHistory( System.IntPtr ptr )
{
	System.Int32 ret = new System.Int32();
	bool isExc = NativeMethodsExc.bgsegm_BackgroundSubtractorMOG_getHistory_excsafe(ref ret, ptr);

	if(isExc)
		handleException();
	return ret;
}


public static  void bgsegm_BackgroundSubtractorMOG_setHistory( System.IntPtr ptr ,  System.Int32 value )
{
	bool isExc = NativeMethodsExc.bgsegm_BackgroundSubtractorMOG_setHistory_excsafe(ptr, value);

	if(isExc)
		handleException();
}


public static  System.Int32 bgsegm_BackgroundSubtractorMOG_getNMixtures( System.IntPtr ptr )
{
	System.Int32 ret = new System.Int32();
	bool isExc = NativeMethodsExc.bgsegm_BackgroundSubtractorMOG_getNMixtures_excsafe(ref ret, ptr);

	if(isExc)
		handleException();
	return ret;
}


public static  void bgsegm_BackgroundSubtractorMOG_setNMixtures( System.IntPtr ptr ,  System.Int32 value )
{
	bool isExc = NativeMethodsExc.bgsegm_BackgroundSubtractorMOG_setNMixtures_excsafe(ptr, value);

	if(isExc)
		handleException();
}


public static  System.Double bgsegm_BackgroundSubtractorMOG_getBackgroundRatio( System.IntPtr ptr )
{
	System.Double ret = new System.Double();
	bool isExc = NativeMethodsExc.bgsegm_BackgroundSubtractorMOG_getBackgroundRatio_excsafe(ref ret, ptr);

	if(isExc)
		handleException();
	return ret;
}


public static  void bgsegm_BackgroundSubtractorMOG_setBackgroundRatio( System.IntPtr ptr ,  System.Double value )
{
	bool isExc = NativeMethodsExc.bgsegm_BackgroundSubtractorMOG_setBackgroundRatio_excsafe(ptr, value);

	if(isExc)
		handleException();
}


public static  System.Double bgsegm_BackgroundSubtractorMOG_getNoiseSigma( System.IntPtr ptr )
{
	System.Double ret = new System.Double();
	bool isExc = NativeMethodsExc.bgsegm_BackgroundSubtractorMOG_getNoiseSigma_excsafe(ref ret, ptr);

	if(isExc)
		handleException();
	return ret;
}


public static  void bgsegm_BackgroundSubtractorMOG_setNoiseSigma( System.IntPtr ptr ,  System.Double value )
{
	bool isExc = NativeMethodsExc.bgsegm_BackgroundSubtractorMOG_setNoiseSigma_excsafe(ptr, value);

	if(isExc)
		handleException();
}


public static  System.IntPtr bgsegm_createBackgroundSubtractorGMG( System.Int32 initializationFrames ,  System.Double decisionThreshold )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.bgsegm_createBackgroundSubtractorGMG_excsafe(ref ret, initializationFrames, decisionThreshold);

	if(isExc)
		handleException();
	return ret;
}


public static  void bgsegm_Ptr_BackgroundSubtractorGMG_delete( System.IntPtr obj )
{
	bool isExc = NativeMethodsExc.bgsegm_Ptr_BackgroundSubtractorGMG_delete_excsafe(obj);

	if(isExc)
		handleException();
}


public static  System.IntPtr bgsegm_Ptr_BackgroundSubtractorGMG_get( System.IntPtr ptr )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.bgsegm_Ptr_BackgroundSubtractorGMG_get_excsafe(ref ret, ptr);

	if(isExc)
		handleException();
	return ret;
}


public static  System.Int32 bgsegm_BackgroundSubtractorGMG_getMaxFeatures( System.IntPtr ptr )
{
	System.Int32 ret = new System.Int32();
	bool isExc = NativeMethodsExc.bgsegm_BackgroundSubtractorGMG_getMaxFeatures_excsafe(ref ret, ptr);

	if(isExc)
		handleException();
	return ret;
}


public static  void bgsegm_BackgroundSubtractorGMG_setMaxFeatures( System.IntPtr ptr ,  System.Int32 value )
{
	bool isExc = NativeMethodsExc.bgsegm_BackgroundSubtractorGMG_setMaxFeatures_excsafe(ptr, value);

	if(isExc)
		handleException();
}


public static  System.Double bgsegm_BackgroundSubtractorGMG_getDefaultLearningRate( System.IntPtr ptr )
{
	System.Double ret = new System.Double();
	bool isExc = NativeMethodsExc.bgsegm_BackgroundSubtractorGMG_getDefaultLearningRate_excsafe(ref ret, ptr);

	if(isExc)
		handleException();
	return ret;
}


public static  void bgsegm_BackgroundSubtractorGMG_setDefaultLearningRate( System.IntPtr ptr ,  System.Double value )
{
	bool isExc = NativeMethodsExc.bgsegm_BackgroundSubtractorGMG_setDefaultLearningRate_excsafe(ptr, value);

	if(isExc)
		handleException();
}


public static  void aruco_DetectorParameters_setMinOtsuStdDev( System.IntPtr obj ,  System.Double value )
{
	bool isExc = NativeMethodsExc.aruco_DetectorParameters_setMinOtsuStdDev_excsafe(obj, value);

	if(isExc)
		handleException();
}


public static  void aruco_DetectorParameters_setPerspectiveRemoveIgnoredMarginPerCell( System.IntPtr obj ,  System.Double value )
{
	bool isExc = NativeMethodsExc.aruco_DetectorParameters_setPerspectiveRemoveIgnoredMarginPerCell_excsafe(obj, value);

	if(isExc)
		handleException();
}


public static  void aruco_DetectorParameters_setPolygonalApproxAccuracyRate( System.IntPtr obj ,  System.Double value )
{
	bool isExc = NativeMethodsExc.aruco_DetectorParameters_setPolygonalApproxAccuracyRate_excsafe(obj, value);

	if(isExc)
		handleException();
}


public static  void aruco_DetectorParameters_setAdaptiveThreshWinSizeMax( System.IntPtr obj ,  System.Int32 value )
{
	bool isExc = NativeMethodsExc.aruco_DetectorParameters_setAdaptiveThreshWinSizeMax_excsafe(obj, value);

	if(isExc)
		handleException();
}


public static  void aruco_DetectorParameters_setAdaptiveThreshWinSizeMin( System.IntPtr obj ,  System.Int32 value )
{
	bool isExc = NativeMethodsExc.aruco_DetectorParameters_setAdaptiveThreshWinSizeMin_excsafe(obj, value);

	if(isExc)
		handleException();
}


public static  void aruco_DetectorParameters_setAdaptiveThreshWinSizeStep( System.IntPtr obj ,  System.Int32 value )
{
	bool isExc = NativeMethodsExc.aruco_DetectorParameters_setAdaptiveThreshWinSizeStep_excsafe(obj, value);

	if(isExc)
		handleException();
}


public static  void aruco_DetectorParameters_setCornerRefinementMaxIterations( System.IntPtr obj ,  System.Int32 value )
{
	bool isExc = NativeMethodsExc.aruco_DetectorParameters_setCornerRefinementMaxIterations_excsafe(obj, value);

	if(isExc)
		handleException();
}


public static  void aruco_DetectorParameters_setCornerRefinementWinSize( System.IntPtr obj ,  System.Int32 value )
{
	bool isExc = NativeMethodsExc.aruco_DetectorParameters_setCornerRefinementWinSize_excsafe(obj, value);

	if(isExc)
		handleException();
}


public static  void aruco_DetectorParameters_setMarkerBorderBits( System.IntPtr obj ,  System.Int32 value )
{
	bool isExc = NativeMethodsExc.aruco_DetectorParameters_setMarkerBorderBits_excsafe(obj, value);

	if(isExc)
		handleException();
}


public static  void aruco_DetectorParameters_setMinDistanceToBorder( System.IntPtr obj ,  System.Int32 value )
{
	bool isExc = NativeMethodsExc.aruco_DetectorParameters_setMinDistanceToBorder_excsafe(obj, value);

	if(isExc)
		handleException();
}


public static  void aruco_DetectorParameters_setPerspectiveRemovePixelPerCell( System.IntPtr obj ,  System.Int32 value )
{
	bool isExc = NativeMethodsExc.aruco_DetectorParameters_setPerspectiveRemovePixelPerCell_excsafe(obj, value);

	if(isExc)
		handleException();
}


public static  System.Boolean aruco_DetectorParameters_getDoCornerRefinement( System.IntPtr obj )
{
	System.Boolean ret = new System.Boolean();
	bool isExc = NativeMethodsExc.aruco_DetectorParameters_getDoCornerRefinement_excsafe(ref ret, obj);

	if(isExc)
		handleException();
	return ret;
}


public static  System.Double aruco_DetectorParameters_getAdaptiveThreshConstant( System.IntPtr obj )
{
	System.Double ret = new System.Double();
	bool isExc = NativeMethodsExc.aruco_DetectorParameters_getAdaptiveThreshConstant_excsafe(ref ret, obj);

	if(isExc)
		handleException();
	return ret;
}


public static  System.Double aruco_DetectorParameters_getCornerRefinementMinAccuracy( System.IntPtr obj )
{
	System.Double ret = new System.Double();
	bool isExc = NativeMethodsExc.aruco_DetectorParameters_getCornerRefinementMinAccuracy_excsafe(ref ret, obj);

	if(isExc)
		handleException();
	return ret;
}


public static  System.Double aruco_DetectorParameters_getErrorCorrectionRate( System.IntPtr obj )
{
	System.Double ret = new System.Double();
	bool isExc = NativeMethodsExc.aruco_DetectorParameters_getErrorCorrectionRate_excsafe(ref ret, obj);

	if(isExc)
		handleException();
	return ret;
}


public static  System.Double aruco_DetectorParameters_getMaxErroneousBitsInBorderRate( System.IntPtr obj )
{
	System.Double ret = new System.Double();
	bool isExc = NativeMethodsExc.aruco_DetectorParameters_getMaxErroneousBitsInBorderRate_excsafe(ref ret, obj);

	if(isExc)
		handleException();
	return ret;
}


public static  System.Double aruco_DetectorParameters_getMaxMarkerPerimeterRate( System.IntPtr obj )
{
	System.Double ret = new System.Double();
	bool isExc = NativeMethodsExc.aruco_DetectorParameters_getMaxMarkerPerimeterRate_excsafe(ref ret, obj);

	if(isExc)
		handleException();
	return ret;
}


public static  System.Double aruco_DetectorParameters_getMinCornerDistanceRate( System.IntPtr obj )
{
	System.Double ret = new System.Double();
	bool isExc = NativeMethodsExc.aruco_DetectorParameters_getMinCornerDistanceRate_excsafe(ref ret, obj);

	if(isExc)
		handleException();
	return ret;
}


public static  System.Double aruco_DetectorParameters_getMinMarkerDistanceRate( System.IntPtr obj )
{
	System.Double ret = new System.Double();
	bool isExc = NativeMethodsExc.aruco_DetectorParameters_getMinMarkerDistanceRate_excsafe(ref ret, obj);

	if(isExc)
		handleException();
	return ret;
}


public static  System.Double aruco_DetectorParameters_getMinMarkerPerimeterRate( System.IntPtr obj )
{
	System.Double ret = new System.Double();
	bool isExc = NativeMethodsExc.aruco_DetectorParameters_getMinMarkerPerimeterRate_excsafe(ref ret, obj);

	if(isExc)
		handleException();
	return ret;
}


public static  System.Double aruco_DetectorParameters_getMinOtsuStdDev( System.IntPtr obj )
{
	System.Double ret = new System.Double();
	bool isExc = NativeMethodsExc.aruco_DetectorParameters_getMinOtsuStdDev_excsafe(ref ret, obj);

	if(isExc)
		handleException();
	return ret;
}


public static  System.Double aruco_DetectorParameters_getPerspectiveRemoveIgnoredMarginPerCell( System.IntPtr obj )
{
	System.Double ret = new System.Double();
	bool isExc = NativeMethodsExc.aruco_DetectorParameters_getPerspectiveRemoveIgnoredMarginPerCell_excsafe(ref ret, obj);

	if(isExc)
		handleException();
	return ret;
}


public static  System.Double aruco_DetectorParameters_getPolygonalApproxAccuracyRate( System.IntPtr obj )
{
	System.Double ret = new System.Double();
	bool isExc = NativeMethodsExc.aruco_DetectorParameters_getPolygonalApproxAccuracyRate_excsafe(ref ret, obj);

	if(isExc)
		handleException();
	return ret;
}


public static  System.Int32 aruco_DetectorParameters_getAdaptiveThreshWinSizeMax( System.IntPtr obj )
{
	System.Int32 ret = new System.Int32();
	bool isExc = NativeMethodsExc.aruco_DetectorParameters_getAdaptiveThreshWinSizeMax_excsafe(ref ret, obj);

	if(isExc)
		handleException();
	return ret;
}


public static  System.Int32 aruco_DetectorParameters_getAdaptiveThreshWinSizeMin( System.IntPtr obj )
{
	System.Int32 ret = new System.Int32();
	bool isExc = NativeMethodsExc.aruco_DetectorParameters_getAdaptiveThreshWinSizeMin_excsafe(ref ret, obj);

	if(isExc)
		handleException();
	return ret;
}


public static  System.Int32 aruco_DetectorParameters_getAdaptiveThreshWinSizeStep( System.IntPtr obj )
{
	System.Int32 ret = new System.Int32();
	bool isExc = NativeMethodsExc.aruco_DetectorParameters_getAdaptiveThreshWinSizeStep_excsafe(ref ret, obj);

	if(isExc)
		handleException();
	return ret;
}


public static  System.Int32 aruco_DetectorParameters_getCornerRefinementMaxIterations( System.IntPtr obj )
{
	System.Int32 ret = new System.Int32();
	bool isExc = NativeMethodsExc.aruco_DetectorParameters_getCornerRefinementMaxIterations_excsafe(ref ret, obj);

	if(isExc)
		handleException();
	return ret;
}


public static  System.Int32 aruco_DetectorParameters_getCornerRefinementWinSize( System.IntPtr obj )
{
	System.Int32 ret = new System.Int32();
	bool isExc = NativeMethodsExc.aruco_DetectorParameters_getCornerRefinementWinSize_excsafe(ref ret, obj);

	if(isExc)
		handleException();
	return ret;
}


public static  void ml_SVM_setKernel( System.IntPtr obj ,  System.Int32 kernelType )
{
	bool isExc = NativeMethodsExc.ml_SVM_setKernel_excsafe(obj, kernelType);

	if(isExc)
		handleException();
}


public static  System.IntPtr ml_SVM_getSupportVectors( System.IntPtr obj )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.ml_SVM_getSupportVectors_excsafe(ref ret, obj);

	if(isExc)
		handleException();
	return ret;
}


public static  System.Double ml_SVM_getDecisionFunction( System.IntPtr obj ,  System.Int32 i ,  System.IntPtr alpha ,  System.IntPtr svidx )
{
	System.Double ret = new System.Double();
	bool isExc = NativeMethodsExc.ml_SVM_getDecisionFunction_excsafe(ref ret, obj, i, alpha, svidx);

	if(isExc)
		handleException();
	return ret;
}


public static  OpenCvSharp.ML.ParamGrid ml_SVM_getDefaultGrid( System.Int32 paramId )
{
	OpenCvSharp.ML.ParamGrid ret = new OpenCvSharp.ML.ParamGrid();
	bool isExc = NativeMethodsExc.ml_SVM_getDefaultGrid_excsafe(ref ret, paramId);

	if(isExc)
		handleException();
	return ret;
}


public static  System.IntPtr ml_SVM_create()
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.ml_SVM_create_excsafe(ref ret);

	if(isExc)
		handleException();
	return ret;
}


public static  void ml_Ptr_SVM_delete( System.IntPtr obj )
{
	bool isExc = NativeMethodsExc.ml_Ptr_SVM_delete_excsafe(obj);

	if(isExc)
		handleException();
}


public static  System.IntPtr ml_Ptr_SVM_get( System.IntPtr obj )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.ml_Ptr_SVM_get_excsafe(ref ret, obj);

	if(isExc)
		handleException();
	return ret;
}


public static  System.IntPtr ml_SVM_load( System.String filePath )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.ml_SVM_load_excsafe(ref ret, filePath);

	if(isExc)
		handleException();
	return ret;
}


public static  System.IntPtr ml_SVM_loadFromString( System.String strModel )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.ml_SVM_loadFromString_excsafe(ref ret, strModel);

	if(isExc)
		handleException();
	return ret;
}


public static  System.IntPtr aruco_getPredefinedDictionary( System.Int32 name )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.aruco_getPredefinedDictionary_excsafe(ref ret, name);

	if(isExc)
		handleException();
	return ret;
}


public static  void aruco_detectMarkers( System.IntPtr image ,  System.IntPtr dictionary ,  System.IntPtr corners ,  System.IntPtr ids ,  System.IntPtr detectParameters ,  System.IntPtr outrejectedImgPoints )
{
	bool isExc = NativeMethodsExc.aruco_detectMarkers_excsafe(image, dictionary, corners, ids, detectParameters, outrejectedImgPoints);

	if(isExc)
		handleException();
}


public static  void aruco_drawDetectedMarkers( System.IntPtr image , [MarshalAs(UnmanagedType.LPArray)] System.IntPtr[] corners ,  System.Int32 cornerSize1 ,  System.Int32[] contoursSize2 , [MarshalAs(UnmanagedType.LPArray)] System.Int32[] ids ,  System.Int32 idxLength ,  OpenCvSharp.Scalar borderColor )
{
	bool isExc = NativeMethodsExc.aruco_drawDetectedMarkers_excsafe(image, corners, cornerSize1, contoursSize2, ids, idxLength, borderColor);

	if(isExc)
		handleException();
}


public static  void aruco_drawDetectedMarkers( System.IntPtr image , [MarshalAs(UnmanagedType.LPArray)] System.IntPtr[] corners ,  System.Int32 cornerSize1 ,  System.Int32[] contoursSize2 ,  System.IntPtr ids ,  System.Int32 idxLength ,  OpenCvSharp.Scalar borderColor )
{
	bool isExc = NativeMethodsExc.aruco_drawDetectedMarkers_excsafe(image, corners, cornerSize1, contoursSize2, ids, idxLength, borderColor);

	if(isExc)
		handleException();
}


public static  void aruco_drawMarker( System.IntPtr dictionary ,  System.Int32 id ,  System.Int32 sidePixels ,  System.IntPtr mat ,  System.Int32 borderBits )
{
	bool isExc = NativeMethodsExc.aruco_drawMarker_excsafe(dictionary, id, sidePixels, mat, borderBits);

	if(isExc)
		handleException();
}


public static  void aruco_estimatePoseSingleMarkers([MarshalAs(UnmanagedType.LPArray)] System.IntPtr[] corners ,  System.Int32 cornersLength1 ,  System.Int32[] cornersLengths2 ,  System.Single markerLength ,  System.IntPtr cameraMatrix ,  System.IntPtr distCoeffs ,  System.IntPtr rvecs ,  System.IntPtr tvecs ,  System.IntPtr objPoints )
{
	bool isExc = NativeMethodsExc.aruco_estimatePoseSingleMarkers_excsafe(corners, cornersLength1, cornersLengths2, markerLength, cameraMatrix, distCoeffs, rvecs, tvecs, objPoints);

	if(isExc)
		handleException();
}


public static  System.IntPtr aruco_DetectorParameters_create()
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.aruco_DetectorParameters_create_excsafe(ref ret);

	if(isExc)
		handleException();
	return ret;
}


public static  void aruco_Ptr_DetectorParameters_delete( System.IntPtr obj )
{
	bool isExc = NativeMethodsExc.aruco_Ptr_DetectorParameters_delete_excsafe(obj);

	if(isExc)
		handleException();
}


public static  System.IntPtr aruco_Ptr_DetectorParameters_get( System.IntPtr obj )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.aruco_Ptr_DetectorParameters_get_excsafe(ref ret, obj);

	if(isExc)
		handleException();
	return ret;
}


public static  void aruco_DetectorParameters_setDoCornerRefinement( System.IntPtr obj ,  System.Boolean value )
{
	bool isExc = NativeMethodsExc.aruco_DetectorParameters_setDoCornerRefinement_excsafe(obj, value);

	if(isExc)
		handleException();
}


public static  void aruco_DetectorParameters_setAdaptiveThreshConstant( System.IntPtr obj ,  System.Double value )
{
	bool isExc = NativeMethodsExc.aruco_DetectorParameters_setAdaptiveThreshConstant_excsafe(obj, value);

	if(isExc)
		handleException();
}


public static  void aruco_DetectorParameters_setCornerRefinementMinAccuracy( System.IntPtr obj ,  System.Double value )
{
	bool isExc = NativeMethodsExc.aruco_DetectorParameters_setCornerRefinementMinAccuracy_excsafe(obj, value);

	if(isExc)
		handleException();
}


public static  void aruco_DetectorParameters_setErrorCorrectionRate( System.IntPtr obj ,  System.Double value )
{
	bool isExc = NativeMethodsExc.aruco_DetectorParameters_setErrorCorrectionRate_excsafe(obj, value);

	if(isExc)
		handleException();
}


public static  void aruco_DetectorParameters_setMaxErroneousBitsInBorderRate( System.IntPtr obj ,  System.Double value )
{
	bool isExc = NativeMethodsExc.aruco_DetectorParameters_setMaxErroneousBitsInBorderRate_excsafe(obj, value);

	if(isExc)
		handleException();
}


public static  void aruco_DetectorParameters_setMaxMarkerPerimeterRate( System.IntPtr obj ,  System.Double value )
{
	bool isExc = NativeMethodsExc.aruco_DetectorParameters_setMaxMarkerPerimeterRate_excsafe(obj, value);

	if(isExc)
		handleException();
}


public static  void aruco_DetectorParameters_setMinCornerDistanceRate( System.IntPtr obj ,  System.Double value )
{
	bool isExc = NativeMethodsExc.aruco_DetectorParameters_setMinCornerDistanceRate_excsafe(obj, value);

	if(isExc)
		handleException();
}


public static  void aruco_DetectorParameters_setMinMarkerDistanceRate( System.IntPtr obj ,  System.Double value )
{
	bool isExc = NativeMethodsExc.aruco_DetectorParameters_setMinMarkerDistanceRate_excsafe(obj, value);

	if(isExc)
		handleException();
}


public static  void aruco_DetectorParameters_setMinMarkerPerimeterRate( System.IntPtr obj ,  System.Double value )
{
	bool isExc = NativeMethodsExc.aruco_DetectorParameters_setMinMarkerPerimeterRate_excsafe(obj, value);

	if(isExc)
		handleException();
}


public static  System.Int32 ml_StatModel_getVarCount( System.IntPtr obj )
{
	System.Int32 ret = new System.Int32();
	bool isExc = NativeMethodsExc.ml_StatModel_getVarCount_excsafe(ref ret, obj);

	if(isExc)
		handleException();
	return ret;
}


public static  System.Int32 ml_StatModel_empty( System.IntPtr obj )
{
	System.Int32 ret = new System.Int32();
	bool isExc = NativeMethodsExc.ml_StatModel_empty_excsafe(ref ret, obj);

	if(isExc)
		handleException();
	return ret;
}


public static  System.Int32 ml_StatModel_isTrained( System.IntPtr obj )
{
	System.Int32 ret = new System.Int32();
	bool isExc = NativeMethodsExc.ml_StatModel_isTrained_excsafe(ref ret, obj);

	if(isExc)
		handleException();
	return ret;
}


public static  System.Int32 ml_StatModel_isClassifier( System.IntPtr obj )
{
	System.Int32 ret = new System.Int32();
	bool isExc = NativeMethodsExc.ml_StatModel_isClassifier_excsafe(ref ret, obj);

	if(isExc)
		handleException();
	return ret;
}


public static  System.Int32 ml_StatModel_train1( System.IntPtr obj ,  System.IntPtr trainData ,  System.Int32 flags )
{
	System.Int32 ret = new System.Int32();
	bool isExc = NativeMethodsExc.ml_StatModel_train1_excsafe(ref ret, obj, trainData, flags);

	if(isExc)
		handleException();
	return ret;
}


public static  System.Int32 ml_StatModel_train2( System.IntPtr obj ,  System.IntPtr samples ,  System.Int32 layout ,  System.IntPtr responses )
{
	System.Int32 ret = new System.Int32();
	bool isExc = NativeMethodsExc.ml_StatModel_train2_excsafe(ref ret, obj, samples, layout, responses);

	if(isExc)
		handleException();
	return ret;
}


public static  System.Single ml_StatModel_calcError( System.IntPtr obj ,  System.IntPtr data ,  System.Int32 test ,  System.IntPtr resp )
{
	System.Single ret = new System.Single();
	bool isExc = NativeMethodsExc.ml_StatModel_calcError_excsafe(ref ret, obj, data, test, resp);

	if(isExc)
		handleException();
	return ret;
}


public static  System.Single ml_StatModel_predict( System.IntPtr obj ,  System.IntPtr samples ,  System.IntPtr results ,  System.Int32 flags )
{
	System.Single ret = new System.Single();
	bool isExc = NativeMethodsExc.ml_StatModel_predict_excsafe(ref ret, obj, samples, results, flags);

	if(isExc)
		handleException();
	return ret;
}


public static  void ml_StatModel_save( System.IntPtr obj ,  System.String filename )
{
	bool isExc = NativeMethodsExc.ml_StatModel_save_excsafe(obj, filename);

	if(isExc)
		handleException();
}


public static  System.Int32 ml_SVM_getType( System.IntPtr obj )
{
	System.Int32 ret = new System.Int32();
	bool isExc = NativeMethodsExc.ml_SVM_getType_excsafe(ref ret, obj);

	if(isExc)
		handleException();
	return ret;
}


public static  void ml_SVM_setType( System.IntPtr obj ,  System.Int32 val )
{
	bool isExc = NativeMethodsExc.ml_SVM_setType_excsafe(obj, val);

	if(isExc)
		handleException();
}


public static  System.Double ml_SVM_getGamma( System.IntPtr obj )
{
	System.Double ret = new System.Double();
	bool isExc = NativeMethodsExc.ml_SVM_getGamma_excsafe(ref ret, obj);

	if(isExc)
		handleException();
	return ret;
}


public static  void ml_SVM_setGamma( System.IntPtr obj ,  System.Double val )
{
	bool isExc = NativeMethodsExc.ml_SVM_setGamma_excsafe(obj, val);

	if(isExc)
		handleException();
}


public static  System.Double ml_SVM_getCoef0( System.IntPtr obj )
{
	System.Double ret = new System.Double();
	bool isExc = NativeMethodsExc.ml_SVM_getCoef0_excsafe(ref ret, obj);

	if(isExc)
		handleException();
	return ret;
}


public static  void ml_SVM_setCoef0( System.IntPtr obj ,  System.Double val )
{
	bool isExc = NativeMethodsExc.ml_SVM_setCoef0_excsafe(obj, val);

	if(isExc)
		handleException();
}


public static  System.Double ml_SVM_getDegree( System.IntPtr obj )
{
	System.Double ret = new System.Double();
	bool isExc = NativeMethodsExc.ml_SVM_getDegree_excsafe(ref ret, obj);

	if(isExc)
		handleException();
	return ret;
}


public static  void ml_SVM_setDegree( System.IntPtr obj ,  System.Double val )
{
	bool isExc = NativeMethodsExc.ml_SVM_setDegree_excsafe(obj, val);

	if(isExc)
		handleException();
}


public static  System.Double ml_SVM_getC( System.IntPtr obj )
{
	System.Double ret = new System.Double();
	bool isExc = NativeMethodsExc.ml_SVM_getC_excsafe(ref ret, obj);

	if(isExc)
		handleException();
	return ret;
}


public static  void ml_SVM_setC( System.IntPtr obj ,  System.Double val )
{
	bool isExc = NativeMethodsExc.ml_SVM_setC_excsafe(obj, val);

	if(isExc)
		handleException();
}


public static  System.Double ml_SVM_getP( System.IntPtr obj )
{
	System.Double ret = new System.Double();
	bool isExc = NativeMethodsExc.ml_SVM_getP_excsafe(ref ret, obj);

	if(isExc)
		handleException();
	return ret;
}


public static  void ml_SVM_setP( System.IntPtr obj ,  System.Double val )
{
	bool isExc = NativeMethodsExc.ml_SVM_setP_excsafe(obj, val);

	if(isExc)
		handleException();
}


public static  System.Double ml_SVM_getNu( System.IntPtr obj )
{
	System.Double ret = new System.Double();
	bool isExc = NativeMethodsExc.ml_SVM_getNu_excsafe(ref ret, obj);

	if(isExc)
		handleException();
	return ret;
}


public static  void ml_SVM_setNu( System.IntPtr obj ,  System.Double val )
{
	bool isExc = NativeMethodsExc.ml_SVM_setNu_excsafe(obj, val);

	if(isExc)
		handleException();
}


public static  System.IntPtr ml_SVM_getClassWeights( System.IntPtr obj )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.ml_SVM_getClassWeights_excsafe(ref ret, obj);

	if(isExc)
		handleException();
	return ret;
}


public static  void ml_SVM_setClassWeights( System.IntPtr obj ,  System.IntPtr val )
{
	bool isExc = NativeMethodsExc.ml_SVM_setClassWeights_excsafe(obj, val);

	if(isExc)
		handleException();
}


public static  OpenCvSharp.TermCriteria ml_SVM_getTermCriteria( System.IntPtr obj )
{
	OpenCvSharp.TermCriteria ret = new OpenCvSharp.TermCriteria();
	bool isExc = NativeMethodsExc.ml_SVM_getTermCriteria_excsafe(ref ret, obj);

	if(isExc)
		handleException();
	return ret;
}


public static  void ml_SVM_setTermCriteria( System.IntPtr obj ,  OpenCvSharp.TermCriteria val )
{
	bool isExc = NativeMethodsExc.ml_SVM_setTermCriteria_excsafe(obj, val);

	if(isExc)
		handleException();
}


public static  System.Int32 ml_SVM_getKernelType( System.IntPtr obj )
{
	System.Int32 ret = new System.Int32();
	bool isExc = NativeMethodsExc.ml_SVM_getKernelType_excsafe(ref ret, obj);

	if(isExc)
		handleException();
	return ret;
}


public static  OpenCvSharp.TermCriteria ml_LogisticRegression_getTermCriteria( System.IntPtr obj )
{
	OpenCvSharp.TermCriteria ret = new OpenCvSharp.TermCriteria();
	bool isExc = NativeMethodsExc.ml_LogisticRegression_getTermCriteria_excsafe(ref ret, obj);

	if(isExc)
		handleException();
	return ret;
}


public static  void ml_LogisticRegression_setTermCriteria( System.IntPtr obj ,  OpenCvSharp.TermCriteria val )
{
	bool isExc = NativeMethodsExc.ml_LogisticRegression_setTermCriteria_excsafe(obj, val);

	if(isExc)
		handleException();
}


public static  System.Single ml_LogisticRegression_predict( System.IntPtr obj ,  System.IntPtr samples ,  System.IntPtr results ,  System.Int32 flags )
{
	System.Single ret = new System.Single();
	bool isExc = NativeMethodsExc.ml_LogisticRegression_predict_excsafe(ref ret, obj, samples, results, flags);

	if(isExc)
		handleException();
	return ret;
}


public static  System.IntPtr ml_LogisticRegression_get_learnt_thetas( System.IntPtr obj )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.ml_LogisticRegression_get_learnt_thetas_excsafe(ref ret, obj);

	if(isExc)
		handleException();
	return ret;
}


public static  System.IntPtr ml_LogisticRegression_create()
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.ml_LogisticRegression_create_excsafe(ref ret);

	if(isExc)
		handleException();
	return ret;
}


public static  void ml_Ptr_LogisticRegression_delete( System.IntPtr obj )
{
	bool isExc = NativeMethodsExc.ml_Ptr_LogisticRegression_delete_excsafe(obj);

	if(isExc)
		handleException();
}


public static  System.IntPtr ml_Ptr_LogisticRegression_get( System.IntPtr obj )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.ml_Ptr_LogisticRegression_get_excsafe(ref ret, obj);

	if(isExc)
		handleException();
	return ret;
}


public static  System.IntPtr ml_LogisticRegression_load( System.String filePath )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.ml_LogisticRegression_load_excsafe(ref ret, filePath);

	if(isExc)
		handleException();
	return ret;
}


public static  System.IntPtr ml_LogisticRegression_loadFromString( System.String strModel )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.ml_LogisticRegression_loadFromString_excsafe(ref ret, strModel);

	if(isExc)
		handleException();
	return ret;
}


public static  System.Single ml_NormalBayesClassifier_predictProb( System.IntPtr obj ,  System.IntPtr inputs ,  System.IntPtr samples ,  System.IntPtr outputProbs ,  System.Int32 flags )
{
	System.Single ret = new System.Single();
	bool isExc = NativeMethodsExc.ml_NormalBayesClassifier_predictProb_excsafe(ref ret, obj, inputs, samples, outputProbs, flags);

	if(isExc)
		handleException();
	return ret;
}


public static  System.IntPtr ml_NormalBayesClassifier_create()
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.ml_NormalBayesClassifier_create_excsafe(ref ret);

	if(isExc)
		handleException();
	return ret;
}


public static  void ml_Ptr_NormalBayesClassifier_delete( System.IntPtr obj )
{
	bool isExc = NativeMethodsExc.ml_Ptr_NormalBayesClassifier_delete_excsafe(obj);

	if(isExc)
		handleException();
}


public static  System.IntPtr ml_Ptr_NormalBayesClassifier_get( System.IntPtr obj )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.ml_Ptr_NormalBayesClassifier_get_excsafe(ref ret, obj);

	if(isExc)
		handleException();
	return ret;
}


public static  System.IntPtr ml_NormalBayesClassifier_load( System.String filePath )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.ml_NormalBayesClassifier_load_excsafe(ref ret, filePath);

	if(isExc)
		handleException();
	return ret;
}


public static  System.IntPtr ml_NormalBayesClassifier_loadFromString( System.String strModel )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.ml_NormalBayesClassifier_loadFromString_excsafe(ref ret, strModel);

	if(isExc)
		handleException();
	return ret;
}


public static  System.Int32 ml_RTrees_getCalculateVarImportance( System.IntPtr obj )
{
	System.Int32 ret = new System.Int32();
	bool isExc = NativeMethodsExc.ml_RTrees_getCalculateVarImportance_excsafe(ref ret, obj);

	if(isExc)
		handleException();
	return ret;
}


public static  void ml_RTrees_setCalculateVarImportance( System.IntPtr obj ,  System.Int32 val )
{
	bool isExc = NativeMethodsExc.ml_RTrees_setCalculateVarImportance_excsafe(obj, val);

	if(isExc)
		handleException();
}


public static  System.Int32 ml_RTrees_getActiveVarCount( System.IntPtr obj )
{
	System.Int32 ret = new System.Int32();
	bool isExc = NativeMethodsExc.ml_RTrees_getActiveVarCount_excsafe(ref ret, obj);

	if(isExc)
		handleException();
	return ret;
}


public static  void ml_RTrees_setActiveVarCount( System.IntPtr obj ,  System.Int32 val )
{
	bool isExc = NativeMethodsExc.ml_RTrees_setActiveVarCount_excsafe(obj, val);

	if(isExc)
		handleException();
}


public static  OpenCvSharp.TermCriteria ml_RTrees_getTermCriteria( System.IntPtr obj )
{
	OpenCvSharp.TermCriteria ret = new OpenCvSharp.TermCriteria();
	bool isExc = NativeMethodsExc.ml_RTrees_getTermCriteria_excsafe(ref ret, obj);

	if(isExc)
		handleException();
	return ret;
}


public static  void ml_RTrees_setTermCriteria( System.IntPtr obj ,  OpenCvSharp.TermCriteria val )
{
	bool isExc = NativeMethodsExc.ml_RTrees_setTermCriteria_excsafe(obj, val);

	if(isExc)
		handleException();
}


public static  System.IntPtr ml_RTrees_getVarImportance( System.IntPtr obj )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.ml_RTrees_getVarImportance_excsafe(ref ret, obj);

	if(isExc)
		handleException();
	return ret;
}


public static  System.IntPtr ml_RTrees_create()
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.ml_RTrees_create_excsafe(ref ret);

	if(isExc)
		handleException();
	return ret;
}


public static  void ml_Ptr_RTrees_delete( System.IntPtr obj )
{
	bool isExc = NativeMethodsExc.ml_Ptr_RTrees_delete_excsafe(obj);

	if(isExc)
		handleException();
}


public static  System.IntPtr ml_Ptr_RTrees_get( System.IntPtr obj )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.ml_Ptr_RTrees_get_excsafe(ref ret, obj);

	if(isExc)
		handleException();
	return ret;
}


public static  System.IntPtr ml_RTrees_load( System.String filePath )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.ml_RTrees_load_excsafe(ref ret, filePath);

	if(isExc)
		handleException();
	return ret;
}


public static  System.IntPtr ml_RTrees_loadFromString( System.String strModel )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.ml_RTrees_loadFromString_excsafe(ref ret, strModel);

	if(isExc)
		handleException();
	return ret;
}


public static  void ml_StatModel_clear( System.IntPtr obj )
{
	bool isExc = NativeMethodsExc.ml_StatModel_clear_excsafe(obj);

	if(isExc)
		handleException();
}


public static  System.IntPtr ml_Ptr_EM_get( System.IntPtr ptr )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.ml_Ptr_EM_get_excsafe(ref ret, ptr);

	if(isExc)
		handleException();
	return ret;
}


public static  void ml_Ptr_EM_delete( System.IntPtr ptr )
{
	bool isExc = NativeMethodsExc.ml_Ptr_EM_delete_excsafe(ptr);

	if(isExc)
		handleException();
}


public static  System.IntPtr ml_EM_load( System.String filePath )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.ml_EM_load_excsafe(ref ret, filePath);

	if(isExc)
		handleException();
	return ret;
}


public static  System.IntPtr ml_EM_loadFromString( System.String strModel )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.ml_EM_loadFromString_excsafe(ref ret, strModel);

	if(isExc)
		handleException();
	return ret;
}


public static  System.Int32 ml_KNearest_getDefaultK( System.IntPtr obj )
{
	System.Int32 ret = new System.Int32();
	bool isExc = NativeMethodsExc.ml_KNearest_getDefaultK_excsafe(ref ret, obj);

	if(isExc)
		handleException();
	return ret;
}


public static  void ml_KNearest_setDefaultK( System.IntPtr obj ,  System.Int32 val )
{
	bool isExc = NativeMethodsExc.ml_KNearest_setDefaultK_excsafe(obj, val);

	if(isExc)
		handleException();
}


public static  System.Int32 ml_KNearest_getIsClassifier( System.IntPtr obj )
{
	System.Int32 ret = new System.Int32();
	bool isExc = NativeMethodsExc.ml_KNearest_getIsClassifier_excsafe(ref ret, obj);

	if(isExc)
		handleException();
	return ret;
}


public static  void ml_KNearest_setIsClassifier( System.IntPtr obj ,  System.Int32 val )
{
	bool isExc = NativeMethodsExc.ml_KNearest_setIsClassifier_excsafe(obj, val);

	if(isExc)
		handleException();
}


public static  System.Int32 ml_KNearest_getEmax( System.IntPtr obj )
{
	System.Int32 ret = new System.Int32();
	bool isExc = NativeMethodsExc.ml_KNearest_getEmax_excsafe(ref ret, obj);

	if(isExc)
		handleException();
	return ret;
}


public static  void ml_KNearest_setEmax( System.IntPtr obj ,  System.Int32 val )
{
	bool isExc = NativeMethodsExc.ml_KNearest_setEmax_excsafe(obj, val);

	if(isExc)
		handleException();
}


public static  System.Int32 ml_KNearest_getAlgorithmType( System.IntPtr obj )
{
	System.Int32 ret = new System.Int32();
	bool isExc = NativeMethodsExc.ml_KNearest_getAlgorithmType_excsafe(ref ret, obj);

	if(isExc)
		handleException();
	return ret;
}


public static  void ml_KNearest_setAlgorithmType( System.IntPtr obj ,  System.Int32 val )
{
	bool isExc = NativeMethodsExc.ml_KNearest_setAlgorithmType_excsafe(obj, val);

	if(isExc)
		handleException();
}


public static  System.Single ml_KNearest_findNearest( System.IntPtr obj ,  System.IntPtr samples ,  System.Int32 k ,  System.IntPtr results ,  System.IntPtr neighborResponses ,  System.IntPtr dist )
{
	System.Single ret = new System.Single();
	bool isExc = NativeMethodsExc.ml_KNearest_findNearest_excsafe(ref ret, obj, samples, k, results, neighborResponses, dist);

	if(isExc)
		handleException();
	return ret;
}


public static  System.IntPtr ml_KNearest_create()
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.ml_KNearest_create_excsafe(ref ret);

	if(isExc)
		handleException();
	return ret;
}


public static  void ml_Ptr_KNearest_delete( System.IntPtr obj )
{
	bool isExc = NativeMethodsExc.ml_Ptr_KNearest_delete_excsafe(obj);

	if(isExc)
		handleException();
}


public static  System.IntPtr ml_Ptr_KNearest_get( System.IntPtr obj )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.ml_Ptr_KNearest_get_excsafe(ref ret, obj);

	if(isExc)
		handleException();
	return ret;
}


public static  System.IntPtr ml_KNearest_load( System.String filePath )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.ml_KNearest_load_excsafe(ref ret, filePath);

	if(isExc)
		handleException();
	return ret;
}


public static  System.IntPtr ml_KNearest_loadFromString( System.String strModel )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.ml_KNearest_loadFromString_excsafe(ref ret, strModel);

	if(isExc)
		handleException();
	return ret;
}


public static  System.Double ml_LogisticRegression_getLearningRate( System.IntPtr obj )
{
	System.Double ret = new System.Double();
	bool isExc = NativeMethodsExc.ml_LogisticRegression_getLearningRate_excsafe(ref ret, obj);

	if(isExc)
		handleException();
	return ret;
}


public static  void ml_LogisticRegression_setLearningRate( System.IntPtr obj ,  System.Double val )
{
	bool isExc = NativeMethodsExc.ml_LogisticRegression_setLearningRate_excsafe(obj, val);

	if(isExc)
		handleException();
}


public static  System.Int32 ml_LogisticRegression_getIterations( System.IntPtr obj )
{
	System.Int32 ret = new System.Int32();
	bool isExc = NativeMethodsExc.ml_LogisticRegression_getIterations_excsafe(ref ret, obj);

	if(isExc)
		handleException();
	return ret;
}


public static  void ml_LogisticRegression_setIterations( System.IntPtr obj ,  System.Int32 val )
{
	bool isExc = NativeMethodsExc.ml_LogisticRegression_setIterations_excsafe(obj, val);

	if(isExc)
		handleException();
}


public static  System.Int32 ml_LogisticRegression_getRegularization( System.IntPtr obj )
{
	System.Int32 ret = new System.Int32();
	bool isExc = NativeMethodsExc.ml_LogisticRegression_getRegularization_excsafe(ref ret, obj);

	if(isExc)
		handleException();
	return ret;
}


public static  void ml_LogisticRegression_setRegularization( System.IntPtr obj ,  System.Int32 val )
{
	bool isExc = NativeMethodsExc.ml_LogisticRegression_setRegularization_excsafe(obj, val);

	if(isExc)
		handleException();
}


public static  System.Int32 ml_LogisticRegression_getTrainMethod( System.IntPtr obj )
{
	System.Int32 ret = new System.Int32();
	bool isExc = NativeMethodsExc.ml_LogisticRegression_getTrainMethod_excsafe(ref ret, obj);

	if(isExc)
		handleException();
	return ret;
}


public static  void ml_LogisticRegression_setTrainMethod( System.IntPtr obj ,  System.Int32 val )
{
	bool isExc = NativeMethodsExc.ml_LogisticRegression_setTrainMethod_excsafe(obj, val);

	if(isExc)
		handleException();
}


public static  System.Int32 ml_LogisticRegression_getMiniBatchSize( System.IntPtr obj )
{
	System.Int32 ret = new System.Int32();
	bool isExc = NativeMethodsExc.ml_LogisticRegression_getMiniBatchSize_excsafe(ref ret, obj);

	if(isExc)
		handleException();
	return ret;
}


public static  void ml_LogisticRegression_setMiniBatchSize( System.IntPtr obj ,  System.Int32 val )
{
	bool isExc = NativeMethodsExc.ml_LogisticRegression_setMiniBatchSize_excsafe(obj, val);

	if(isExc)
		handleException();
}


public static  void ml_DTrees_setTruncatePrunedTree( System.IntPtr obj ,  System.Int32 val )
{
	bool isExc = NativeMethodsExc.ml_DTrees_setTruncatePrunedTree_excsafe(obj, val);

	if(isExc)
		handleException();
}


public static  System.Single ml_DTrees_getRegressionAccuracy( System.IntPtr obj )
{
	System.Single ret = new System.Single();
	bool isExc = NativeMethodsExc.ml_DTrees_getRegressionAccuracy_excsafe(ref ret, obj);

	if(isExc)
		handleException();
	return ret;
}


public static  void ml_DTrees_setRegressionAccuracy( System.IntPtr obj ,  System.Single val )
{
	bool isExc = NativeMethodsExc.ml_DTrees_setRegressionAccuracy_excsafe(obj, val);

	if(isExc)
		handleException();
}


public static  System.IntPtr ml_DTrees_getPriors( System.IntPtr obj )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.ml_DTrees_getPriors_excsafe(ref ret, obj);

	if(isExc)
		handleException();
	return ret;
}


public static  void ml_DTrees_setPriors( System.IntPtr obj ,  System.IntPtr val )
{
	bool isExc = NativeMethodsExc.ml_DTrees_setPriors_excsafe(obj, val);

	if(isExc)
		handleException();
}


public static  void ml_DTrees_getRoots( System.IntPtr obj ,  System.IntPtr result )
{
	bool isExc = NativeMethodsExc.ml_DTrees_getRoots_excsafe(obj, result);

	if(isExc)
		handleException();
}


public static  void ml_DTrees_getNodes( System.IntPtr obj ,  System.IntPtr result )
{
	bool isExc = NativeMethodsExc.ml_DTrees_getNodes_excsafe(obj, result);

	if(isExc)
		handleException();
}


public static  void ml_DTrees_getSplits( System.IntPtr obj ,  System.IntPtr result )
{
	bool isExc = NativeMethodsExc.ml_DTrees_getSplits_excsafe(obj, result);

	if(isExc)
		handleException();
}


public static  void ml_DTrees_getSubsets( System.IntPtr obj ,  System.IntPtr result )
{
	bool isExc = NativeMethodsExc.ml_DTrees_getSubsets_excsafe(obj, result);

	if(isExc)
		handleException();
}


public static  System.IntPtr ml_DTrees_create()
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.ml_DTrees_create_excsafe(ref ret);

	if(isExc)
		handleException();
	return ret;
}


public static  void ml_Ptr_DTrees_delete( System.IntPtr obj )
{
	bool isExc = NativeMethodsExc.ml_Ptr_DTrees_delete_excsafe(obj);

	if(isExc)
		handleException();
}


public static  System.IntPtr ml_Ptr_DTrees_get( System.IntPtr obj )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.ml_Ptr_DTrees_get_excsafe(ref ret, obj);

	if(isExc)
		handleException();
	return ret;
}


public static  System.IntPtr ml_DTrees_load( System.String filePath )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.ml_DTrees_load_excsafe(ref ret, filePath);

	if(isExc)
		handleException();
	return ret;
}


public static  System.IntPtr ml_DTrees_loadFromString( System.String strModel )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.ml_DTrees_loadFromString_excsafe(ref ret, strModel);

	if(isExc)
		handleException();
	return ret;
}


public static  System.Int32 ml_EM_getClustersNumber( System.IntPtr obj )
{
	System.Int32 ret = new System.Int32();
	bool isExc = NativeMethodsExc.ml_EM_getClustersNumber_excsafe(ref ret, obj);

	if(isExc)
		handleException();
	return ret;
}


public static  void ml_EM_setClustersNumber( System.IntPtr obj ,  System.Int32 val )
{
	bool isExc = NativeMethodsExc.ml_EM_setClustersNumber_excsafe(obj, val);

	if(isExc)
		handleException();
}


public static  System.Int32 ml_EM_getCovarianceMatrixType( System.IntPtr obj )
{
	System.Int32 ret = new System.Int32();
	bool isExc = NativeMethodsExc.ml_EM_getCovarianceMatrixType_excsafe(ref ret, obj);

	if(isExc)
		handleException();
	return ret;
}


public static  void ml_EM_setCovarianceMatrixType( System.IntPtr obj ,  System.Int32 val )
{
	bool isExc = NativeMethodsExc.ml_EM_setCovarianceMatrixType_excsafe(obj, val);

	if(isExc)
		handleException();
}


public static  OpenCvSharp.TermCriteria ml_EM_getTermCriteria( System.IntPtr obj )
{
	OpenCvSharp.TermCriteria ret = new OpenCvSharp.TermCriteria();
	bool isExc = NativeMethodsExc.ml_EM_getTermCriteria_excsafe(ref ret, obj);

	if(isExc)
		handleException();
	return ret;
}


public static  void ml_EM_setTermCriteria( System.IntPtr obj ,  OpenCvSharp.TermCriteria val )
{
	bool isExc = NativeMethodsExc.ml_EM_setTermCriteria_excsafe(obj, val);

	if(isExc)
		handleException();
}


public static  System.IntPtr ml_EM_getWeights( System.IntPtr obj )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.ml_EM_getWeights_excsafe(ref ret, obj);

	if(isExc)
		handleException();
	return ret;
}


public static  System.IntPtr ml_EM_getMeans( System.IntPtr obj )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.ml_EM_getMeans_excsafe(ref ret, obj);

	if(isExc)
		handleException();
	return ret;
}


public static  void ml_EM_getCovs( System.IntPtr obj ,  System.IntPtr covs )
{
	bool isExc = NativeMethodsExc.ml_EM_getCovs_excsafe(obj, covs);

	if(isExc)
		handleException();
}


public static  OpenCvSharp.Vec2d ml_EM_predict2( System.IntPtr model ,  System.IntPtr sample ,  System.IntPtr probs )
{
	OpenCvSharp.Vec2d ret = new OpenCvSharp.Vec2d();
	bool isExc = NativeMethodsExc.ml_EM_predict2_excsafe(ref ret, model, sample, probs);

	if(isExc)
		handleException();
	return ret;
}


public static  System.Int32 ml_EM_trainEM( System.IntPtr obj ,  System.IntPtr samples ,  System.IntPtr logLikelihoods ,  System.IntPtr labels ,  System.IntPtr probs )
{
	System.Int32 ret = new System.Int32();
	bool isExc = NativeMethodsExc.ml_EM_trainEM_excsafe(ref ret, obj, samples, logLikelihoods, labels, probs);

	if(isExc)
		handleException();
	return ret;
}


public static  System.Int32 ml_EM_trainE( System.IntPtr model ,  System.IntPtr samples ,  System.IntPtr means0 ,  System.IntPtr covs0 ,  System.IntPtr weights0 ,  System.IntPtr logLikelihoods ,  System.IntPtr labels ,  System.IntPtr probs )
{
	System.Int32 ret = new System.Int32();
	bool isExc = NativeMethodsExc.ml_EM_trainE_excsafe(ref ret, model, samples, means0, covs0, weights0, logLikelihoods, labels, probs);

	if(isExc)
		handleException();
	return ret;
}


public static  System.Int32 ml_EM_trainM( System.IntPtr model ,  System.IntPtr samples ,  System.IntPtr probs0 ,  System.IntPtr logLikelihoods ,  System.IntPtr labels ,  System.IntPtr probs )
{
	System.Int32 ret = new System.Int32();
	bool isExc = NativeMethodsExc.ml_EM_trainM_excsafe(ref ret, model, samples, probs0, logLikelihoods, labels, probs);

	if(isExc)
		handleException();
	return ret;
}


public static  System.IntPtr ml_EM_create()
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.ml_EM_create_excsafe(ref ret);

	if(isExc)
		handleException();
	return ret;
}


public static  void ml_Ptr_ANN_MLP_delete( System.IntPtr obj )
{
	bool isExc = NativeMethodsExc.ml_Ptr_ANN_MLP_delete_excsafe(obj);

	if(isExc)
		handleException();
}


public static  System.IntPtr ml_Ptr_ANN_MLP_get( System.IntPtr obj )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.ml_Ptr_ANN_MLP_get_excsafe(ref ret, obj);

	if(isExc)
		handleException();
	return ret;
}


public static  System.IntPtr ml_ANN_MLP_load( System.String filePath )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.ml_ANN_MLP_load_excsafe(ref ret, filePath);

	if(isExc)
		handleException();
	return ret;
}


public static  System.IntPtr ml_ANN_MLP_loadFromString( System.String strModel )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.ml_ANN_MLP_loadFromString_excsafe(ref ret, strModel);

	if(isExc)
		handleException();
	return ret;
}


public static  System.Int32 ml_Boost_getBoostType( System.IntPtr obj )
{
	System.Int32 ret = new System.Int32();
	bool isExc = NativeMethodsExc.ml_Boost_getBoostType_excsafe(ref ret, obj);

	if(isExc)
		handleException();
	return ret;
}


public static  void ml_Boost_setBoostType( System.IntPtr obj ,  System.Int32 val )
{
	bool isExc = NativeMethodsExc.ml_Boost_setBoostType_excsafe(obj, val);

	if(isExc)
		handleException();
}


public static  System.Int32 ml_Boost_getWeakCount( System.IntPtr obj )
{
	System.Int32 ret = new System.Int32();
	bool isExc = NativeMethodsExc.ml_Boost_getWeakCount_excsafe(ref ret, obj);

	if(isExc)
		handleException();
	return ret;
}


public static  void ml_Boost_setWeakCount( System.IntPtr obj ,  System.Int32 val )
{
	bool isExc = NativeMethodsExc.ml_Boost_setWeakCount_excsafe(obj, val);

	if(isExc)
		handleException();
}


public static  System.Double ml_Boost_getWeightTrimRate( System.IntPtr obj )
{
	System.Double ret = new System.Double();
	bool isExc = NativeMethodsExc.ml_Boost_getWeightTrimRate_excsafe(ref ret, obj);

	if(isExc)
		handleException();
	return ret;
}


public static  void ml_Boost_setWeightTrimRate( System.IntPtr obj ,  System.Double val )
{
	bool isExc = NativeMethodsExc.ml_Boost_setWeightTrimRate_excsafe(obj, val);

	if(isExc)
		handleException();
}


public static  System.IntPtr ml_Boost_create()
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.ml_Boost_create_excsafe(ref ret);

	if(isExc)
		handleException();
	return ret;
}


public static  void ml_Ptr_Boost_delete( System.IntPtr obj )
{
	bool isExc = NativeMethodsExc.ml_Ptr_Boost_delete_excsafe(obj);

	if(isExc)
		handleException();
}


public static  System.IntPtr ml_Ptr_Boost_get( System.IntPtr obj )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.ml_Ptr_Boost_get_excsafe(ref ret, obj);

	if(isExc)
		handleException();
	return ret;
}


public static  System.IntPtr ml_Boost_load( System.String filePath )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.ml_Boost_load_excsafe(ref ret, filePath);

	if(isExc)
		handleException();
	return ret;
}


public static  System.IntPtr ml_Boost_loadFromString( System.String strModel )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.ml_Boost_loadFromString_excsafe(ref ret, strModel);

	if(isExc)
		handleException();
	return ret;
}


public static  System.Int32 ml_DTrees_getMaxCategories( System.IntPtr obj )
{
	System.Int32 ret = new System.Int32();
	bool isExc = NativeMethodsExc.ml_DTrees_getMaxCategories_excsafe(ref ret, obj);

	if(isExc)
		handleException();
	return ret;
}


public static  void ml_DTrees_setMaxCategories( System.IntPtr obj ,  System.Int32 val )
{
	bool isExc = NativeMethodsExc.ml_DTrees_setMaxCategories_excsafe(obj, val);

	if(isExc)
		handleException();
}


public static  System.Int32 ml_DTrees_getMaxDepth( System.IntPtr obj )
{
	System.Int32 ret = new System.Int32();
	bool isExc = NativeMethodsExc.ml_DTrees_getMaxDepth_excsafe(ref ret, obj);

	if(isExc)
		handleException();
	return ret;
}


public static  void ml_DTrees_setMaxDepth( System.IntPtr obj ,  System.Int32 val )
{
	bool isExc = NativeMethodsExc.ml_DTrees_setMaxDepth_excsafe(obj, val);

	if(isExc)
		handleException();
}


public static  System.Int32 ml_DTrees_getMinSampleCount( System.IntPtr obj )
{
	System.Int32 ret = new System.Int32();
	bool isExc = NativeMethodsExc.ml_DTrees_getMinSampleCount_excsafe(ref ret, obj);

	if(isExc)
		handleException();
	return ret;
}


public static  void ml_DTrees_setMinSampleCount( System.IntPtr obj ,  System.Int32 val )
{
	bool isExc = NativeMethodsExc.ml_DTrees_setMinSampleCount_excsafe(obj, val);

	if(isExc)
		handleException();
}


public static  System.Int32 ml_DTrees_getCVFolds( System.IntPtr obj )
{
	System.Int32 ret = new System.Int32();
	bool isExc = NativeMethodsExc.ml_DTrees_getCVFolds_excsafe(ref ret, obj);

	if(isExc)
		handleException();
	return ret;
}


public static  void ml_DTrees_setCVFolds( System.IntPtr obj ,  System.Int32 val )
{
	bool isExc = NativeMethodsExc.ml_DTrees_setCVFolds_excsafe(obj, val);

	if(isExc)
		handleException();
}


public static  System.Int32 ml_DTrees_getUseSurrogates( System.IntPtr obj )
{
	System.Int32 ret = new System.Int32();
	bool isExc = NativeMethodsExc.ml_DTrees_getUseSurrogates_excsafe(ref ret, obj);

	if(isExc)
		handleException();
	return ret;
}


public static  void ml_DTrees_setUseSurrogates( System.IntPtr obj ,  System.Int32 val )
{
	bool isExc = NativeMethodsExc.ml_DTrees_setUseSurrogates_excsafe(obj, val);

	if(isExc)
		handleException();
}


public static  System.Int32 ml_DTrees_getUse1SERule( System.IntPtr obj )
{
	System.Int32 ret = new System.Int32();
	bool isExc = NativeMethodsExc.ml_DTrees_getUse1SERule_excsafe(ref ret, obj);

	if(isExc)
		handleException();
	return ret;
}


public static  void ml_DTrees_setUse1SERule( System.IntPtr obj ,  System.Int32 val )
{
	bool isExc = NativeMethodsExc.ml_DTrees_setUse1SERule_excsafe(obj, val);

	if(isExc)
		handleException();
}


public static  System.Int32 ml_DTrees_getTruncatePrunedTree( System.IntPtr obj )
{
	System.Int32 ret = new System.Int32();
	bool isExc = NativeMethodsExc.ml_DTrees_getTruncatePrunedTree_excsafe(ref ret, obj);

	if(isExc)
		handleException();
	return ret;
}


public static  System.Int32 imgproc_Subdiv2D_nextEdge( System.IntPtr obj ,  System.Int32 edge )
{
	System.Int32 ret = new System.Int32();
	bool isExc = NativeMethodsExc.imgproc_Subdiv2D_nextEdge_excsafe(ref ret, obj, edge);

	if(isExc)
		handleException();
	return ret;
}


public static  System.Int32 imgproc_Subdiv2D_rotateEdge( System.IntPtr obj ,  System.Int32 edge ,  System.Int32 rotate )
{
	System.Int32 ret = new System.Int32();
	bool isExc = NativeMethodsExc.imgproc_Subdiv2D_rotateEdge_excsafe(ref ret, obj, edge, rotate);

	if(isExc)
		handleException();
	return ret;
}


public static  System.Int32 imgproc_Subdiv2D_symEdge( System.IntPtr obj ,  System.Int32 edge )
{
	System.Int32 ret = new System.Int32();
	bool isExc = NativeMethodsExc.imgproc_Subdiv2D_symEdge_excsafe(ref ret, obj, edge);

	if(isExc)
		handleException();
	return ret;
}


public static  System.Int32 imgproc_Subdiv2D_edgeOrg( System.IntPtr obj ,  System.Int32 edge ,  out OpenCvSharp.Point2f orgpt )
{
	System.Int32 ret = new System.Int32();
	bool isExc = NativeMethodsExc.imgproc_Subdiv2D_edgeOrg_excsafe(ref ret, obj, edge,  out orgpt);

	if(isExc)
		handleException();
	return ret;
}


public static  System.Int32 imgproc_Subdiv2D_edgeDst( System.IntPtr obj ,  System.Int32 edge ,  out OpenCvSharp.Point2f dstpt )
{
	System.Int32 ret = new System.Int32();
	bool isExc = NativeMethodsExc.imgproc_Subdiv2D_edgeDst_excsafe(ref ret, obj, edge,  out dstpt);

	if(isExc)
		handleException();
	return ret;
}


public static  void ml_ANN_MLP_setTrainMethod( System.IntPtr obj ,  System.Int32 method ,  System.Double param1 ,  System.Double param2 )
{
	bool isExc = NativeMethodsExc.ml_ANN_MLP_setTrainMethod_excsafe(obj, method, param1, param2);

	if(isExc)
		handleException();
}


public static  System.Int32 ml_ANN_MLP_getTrainMethod( System.IntPtr obj )
{
	System.Int32 ret = new System.Int32();
	bool isExc = NativeMethodsExc.ml_ANN_MLP_getTrainMethod_excsafe(ref ret, obj);

	if(isExc)
		handleException();
	return ret;
}


public static  void ml_ANN_MLP_setActivationFunction( System.IntPtr obj ,  System.Int32 type ,  System.Double param1 ,  System.Double param2 )
{
	bool isExc = NativeMethodsExc.ml_ANN_MLP_setActivationFunction_excsafe(obj, type, param1, param2);

	if(isExc)
		handleException();
}


public static  void ml_ANN_MLP_setLayerSizes( System.IntPtr obj ,  System.IntPtr layerSizes )
{
	bool isExc = NativeMethodsExc.ml_ANN_MLP_setLayerSizes_excsafe(obj, layerSizes);

	if(isExc)
		handleException();
}


public static  System.IntPtr ml_ANN_MLP_getLayerSizes( System.IntPtr obj )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.ml_ANN_MLP_getLayerSizes_excsafe(ref ret, obj);

	if(isExc)
		handleException();
	return ret;
}


public static  OpenCvSharp.TermCriteria ml_ANN_MLP_getTermCriteria( System.IntPtr obj )
{
	OpenCvSharp.TermCriteria ret = new OpenCvSharp.TermCriteria();
	bool isExc = NativeMethodsExc.ml_ANN_MLP_getTermCriteria_excsafe(ref ret, obj);

	if(isExc)
		handleException();
	return ret;
}


public static  void ml_ANN_MLP_setTermCriteria( System.IntPtr obj ,  OpenCvSharp.TermCriteria val )
{
	bool isExc = NativeMethodsExc.ml_ANN_MLP_setTermCriteria_excsafe(obj, val);

	if(isExc)
		handleException();
}


public static  System.Double ml_ANN_MLP_getBackpropWeightScale( System.IntPtr obj )
{
	System.Double ret = new System.Double();
	bool isExc = NativeMethodsExc.ml_ANN_MLP_getBackpropWeightScale_excsafe(ref ret, obj);

	if(isExc)
		handleException();
	return ret;
}


public static  void ml_ANN_MLP_setBackpropWeightScale( System.IntPtr obj ,  System.Double val )
{
	bool isExc = NativeMethodsExc.ml_ANN_MLP_setBackpropWeightScale_excsafe(obj, val);

	if(isExc)
		handleException();
}


public static  System.Double ml_ANN_MLP_getBackpropMomentumScale( System.IntPtr obj )
{
	System.Double ret = new System.Double();
	bool isExc = NativeMethodsExc.ml_ANN_MLP_getBackpropMomentumScale_excsafe(ref ret, obj);

	if(isExc)
		handleException();
	return ret;
}


public static  void ml_ANN_MLP_setBackpropMomentumScale( System.IntPtr obj ,  System.Double val )
{
	bool isExc = NativeMethodsExc.ml_ANN_MLP_setBackpropMomentumScale_excsafe(obj, val);

	if(isExc)
		handleException();
}


public static  System.Double ml_ANN_MLP_getRpropDW0( System.IntPtr obj )
{
	System.Double ret = new System.Double();
	bool isExc = NativeMethodsExc.ml_ANN_MLP_getRpropDW0_excsafe(ref ret, obj);

	if(isExc)
		handleException();
	return ret;
}


public static  void ml_ANN_MLP_setRpropDW0( System.IntPtr obj ,  System.Double val )
{
	bool isExc = NativeMethodsExc.ml_ANN_MLP_setRpropDW0_excsafe(obj, val);

	if(isExc)
		handleException();
}


public static  System.Double ml_ANN_MLP_getRpropDWPlus( System.IntPtr obj )
{
	System.Double ret = new System.Double();
	bool isExc = NativeMethodsExc.ml_ANN_MLP_getRpropDWPlus_excsafe(ref ret, obj);

	if(isExc)
		handleException();
	return ret;
}


public static  void ml_ANN_MLP_setRpropDWPlus( System.IntPtr obj ,  System.Double val )
{
	bool isExc = NativeMethodsExc.ml_ANN_MLP_setRpropDWPlus_excsafe(obj, val);

	if(isExc)
		handleException();
}


public static  System.Double ml_ANN_MLP_getRpropDWMinus( System.IntPtr obj )
{
	System.Double ret = new System.Double();
	bool isExc = NativeMethodsExc.ml_ANN_MLP_getRpropDWMinus_excsafe(ref ret, obj);

	if(isExc)
		handleException();
	return ret;
}


public static  void ml_ANN_MLP_setRpropDWMinus( System.IntPtr obj ,  System.Double val )
{
	bool isExc = NativeMethodsExc.ml_ANN_MLP_setRpropDWMinus_excsafe(obj, val);

	if(isExc)
		handleException();
}


public static  System.Double ml_ANN_MLP_getRpropDWMin( System.IntPtr obj )
{
	System.Double ret = new System.Double();
	bool isExc = NativeMethodsExc.ml_ANN_MLP_getRpropDWMin_excsafe(ref ret, obj);

	if(isExc)
		handleException();
	return ret;
}


public static  void ml_ANN_MLP_setRpropDWMin( System.IntPtr obj ,  System.Double val )
{
	bool isExc = NativeMethodsExc.ml_ANN_MLP_setRpropDWMin_excsafe(obj, val);

	if(isExc)
		handleException();
}


public static  System.Double ml_ANN_MLP_getRpropDWMax( System.IntPtr obj )
{
	System.Double ret = new System.Double();
	bool isExc = NativeMethodsExc.ml_ANN_MLP_getRpropDWMax_excsafe(ref ret, obj);

	if(isExc)
		handleException();
	return ret;
}


public static  void ml_ANN_MLP_setRpropDWMax( System.IntPtr obj ,  System.Double val )
{
	bool isExc = NativeMethodsExc.ml_ANN_MLP_setRpropDWMax_excsafe(obj, val);

	if(isExc)
		handleException();
}


public static  System.IntPtr ml_ANN_MLP_getWeights( System.IntPtr obj ,  System.Int32 layerIdx )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.ml_ANN_MLP_getWeights_excsafe(ref ret, obj, layerIdx);

	if(isExc)
		handleException();
	return ret;
}


public static  System.IntPtr ml_ANN_MLP_create()
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.ml_ANN_MLP_create_excsafe(ref ret);

	if(isExc)
		handleException();
	return ret;
}


public static  void imgproc_LineIterator_minusDelta_set( System.IntPtr obj ,  System.Int32 val )
{
	bool isExc = NativeMethodsExc.imgproc_LineIterator_minusDelta_set_excsafe(obj, val);

	if(isExc)
		handleException();
}


public static  System.Int32 imgproc_LineIterator_plusDelta_get( System.IntPtr obj )
{
	System.Int32 ret = new System.Int32();
	bool isExc = NativeMethodsExc.imgproc_LineIterator_plusDelta_get_excsafe(ref ret, obj);

	if(isExc)
		handleException();
	return ret;
}


public static  void imgproc_LineIterator_plusDelta_set( System.IntPtr obj ,  System.Int32 val )
{
	bool isExc = NativeMethodsExc.imgproc_LineIterator_plusDelta_set_excsafe(obj, val);

	if(isExc)
		handleException();
}


public static  System.Int32 imgproc_LineIterator_minusStep_get( System.IntPtr obj )
{
	System.Int32 ret = new System.Int32();
	bool isExc = NativeMethodsExc.imgproc_LineIterator_minusStep_get_excsafe(ref ret, obj);

	if(isExc)
		handleException();
	return ret;
}


public static  void imgproc_LineIterator_minusStep_set( System.IntPtr obj ,  System.Int32 val )
{
	bool isExc = NativeMethodsExc.imgproc_LineIterator_minusStep_set_excsafe(obj, val);

	if(isExc)
		handleException();
}


public static  System.Int32 imgproc_LineIterator_plusStep_get( System.IntPtr obj )
{
	System.Int32 ret = new System.Int32();
	bool isExc = NativeMethodsExc.imgproc_LineIterator_plusStep_get_excsafe(ref ret, obj);

	if(isExc)
		handleException();
	return ret;
}


public static  void imgproc_LineIterator_plusStep_set( System.IntPtr obj ,  System.Int32 val )
{
	bool isExc = NativeMethodsExc.imgproc_LineIterator_plusStep_set_excsafe(obj, val);

	if(isExc)
		handleException();
}


public static  void imgproc_LineSegmentDetector_detect_OutputArray( System.IntPtr obj ,  System.IntPtr image ,  System.IntPtr lines ,  System.IntPtr width ,  System.IntPtr prec ,  System.IntPtr nfa )
{
	bool isExc = NativeMethodsExc.imgproc_LineSegmentDetector_detect_OutputArray_excsafe(obj, image, lines, width, prec, nfa);

	if(isExc)
		handleException();
}


public static  void imgproc_LineSegmentDetector_detect_vector( System.IntPtr obj ,  System.IntPtr image ,  System.IntPtr lines ,  System.IntPtr width ,  System.IntPtr prec ,  System.IntPtr nfa )
{
	bool isExc = NativeMethodsExc.imgproc_LineSegmentDetector_detect_vector_excsafe(obj, image, lines, width, prec, nfa);

	if(isExc)
		handleException();
}


public static  void imgproc_LineSegmentDetector_drawSegments( System.IntPtr obj ,  System.IntPtr image ,  System.IntPtr lines )
{
	bool isExc = NativeMethodsExc.imgproc_LineSegmentDetector_drawSegments_excsafe(obj, image, lines);

	if(isExc)
		handleException();
}


public static  System.Int32 imgproc_LineSegmentDetector_compareSegments( System.IntPtr obj ,  OpenCvSharp.Size size ,  System.IntPtr lines1 ,  System.IntPtr lines2 ,  System.IntPtr image )
{
	System.Int32 ret = new System.Int32();
	bool isExc = NativeMethodsExc.imgproc_LineSegmentDetector_compareSegments_excsafe(ref ret, obj, size, lines1, lines2, image);

	if(isExc)
		handleException();
	return ret;
}


public static  System.IntPtr imgproc_createLineSegmentDetector( System.Int32 refine ,  System.Double scale ,  System.Double sigma_scale ,  System.Double quant ,  System.Double ang_th ,  System.Double log_eps ,  System.Double density_th ,  System.Int32 n_bins )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.imgproc_createLineSegmentDetector_excsafe(ref ret, refine, scale, sigma_scale, quant, ang_th, log_eps, density_th, n_bins);

	if(isExc)
		handleException();
	return ret;
}


public static  void imgproc_Ptr_LineSegmentDetector_delete( System.IntPtr obj )
{
	bool isExc = NativeMethodsExc.imgproc_Ptr_LineSegmentDetector_delete_excsafe(obj);

	if(isExc)
		handleException();
}


public static  System.IntPtr imgproc_Ptr_LineSegmentDetector_get( System.IntPtr obj )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.imgproc_Ptr_LineSegmentDetector_get_excsafe(ref ret, obj);

	if(isExc)
		handleException();
	return ret;
}


public static  System.IntPtr imgproc_Subdiv2D_new1()
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.imgproc_Subdiv2D_new1_excsafe(ref ret);

	if(isExc)
		handleException();
	return ret;
}


public static  System.IntPtr imgproc_Subdiv2D_new2( OpenCvSharp.Rect rect )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.imgproc_Subdiv2D_new2_excsafe(ref ret, rect);

	if(isExc)
		handleException();
	return ret;
}


public static  void imgproc_Subdiv2D_delete( System.IntPtr obj )
{
	bool isExc = NativeMethodsExc.imgproc_Subdiv2D_delete_excsafe(obj);

	if(isExc)
		handleException();
}


public static  void imgproc_Subdiv2D_initDelaunay( System.IntPtr obj ,  OpenCvSharp.Rect rect )
{
	bool isExc = NativeMethodsExc.imgproc_Subdiv2D_initDelaunay_excsafe(obj, rect);

	if(isExc)
		handleException();
}


public static  System.Int32 imgproc_Subdiv2D_insert1( System.IntPtr obj ,  OpenCvSharp.Point2f pt )
{
	System.Int32 ret = new System.Int32();
	bool isExc = NativeMethodsExc.imgproc_Subdiv2D_insert1_excsafe(ref ret, obj, pt);

	if(isExc)
		handleException();
	return ret;
}


public static  void imgproc_Subdiv2D_insert2( System.IntPtr obj , [MarshalAs(UnmanagedType.LPArray)] OpenCvSharp.Point2f[] ptArray ,  System.Int32 length )
{
	bool isExc = NativeMethodsExc.imgproc_Subdiv2D_insert2_excsafe(obj, ptArray, length);

	if(isExc)
		handleException();
}


public static  System.Int32 imgproc_Subdiv2D_locate( System.IntPtr obj ,  OpenCvSharp.Point2f pt ,  out System.Int32 edge ,  out System.Int32 vertex )
{
	System.Int32 ret = new System.Int32();
	bool isExc = NativeMethodsExc.imgproc_Subdiv2D_locate_excsafe(ref ret, obj, pt,  out edge,  out vertex);

	if(isExc)
		handleException();
	return ret;
}


public static  System.Int32 imgproc_Subdiv2D_findNearest( System.IntPtr obj ,  OpenCvSharp.Point2f pt ,  out OpenCvSharp.Point2f nearestPt )
{
	System.Int32 ret = new System.Int32();
	bool isExc = NativeMethodsExc.imgproc_Subdiv2D_findNearest_excsafe(ref ret, obj, pt,  out nearestPt);

	if(isExc)
		handleException();
	return ret;
}


public static  void imgproc_Subdiv2D_getEdgeList( System.IntPtr obj ,  out System.IntPtr edgeList )
{
	bool isExc = NativeMethodsExc.imgproc_Subdiv2D_getEdgeList_excsafe(obj,  out edgeList);

	if(isExc)
		handleException();
}


public static  void imgproc_Subdiv2D_getTriangleList( System.IntPtr obj ,  out System.IntPtr triangleList )
{
	bool isExc = NativeMethodsExc.imgproc_Subdiv2D_getTriangleList_excsafe(obj,  out triangleList);

	if(isExc)
		handleException();
}


public static  void imgproc_Subdiv2D_getVoronoiFacetList( System.IntPtr obj , [MarshalAs(UnmanagedType.LPArray)] System.Int32[] idx ,  System.Int32 idxCount ,  out System.IntPtr facetList ,  out System.IntPtr facetCenters )
{
	bool isExc = NativeMethodsExc.imgproc_Subdiv2D_getVoronoiFacetList_excsafe(obj, idx, idxCount,  out facetList,  out facetCenters);

	if(isExc)
		handleException();
}


public static  void imgproc_Subdiv2D_getVoronoiFacetList( System.IntPtr obj ,  System.IntPtr idx ,  System.Int32 idxCount ,  out System.IntPtr facetList ,  out System.IntPtr facetCenters )
{
	bool isExc = NativeMethodsExc.imgproc_Subdiv2D_getVoronoiFacetList_excsafe(obj, idx, idxCount,  out facetList,  out facetCenters);

	if(isExc)
		handleException();
}


public static  OpenCvSharp.Point2f imgproc_Subdiv2D_getVertex( System.IntPtr obj ,  System.Int32 vertex ,  out System.Int32 firstEdge )
{
	OpenCvSharp.Point2f ret = new OpenCvSharp.Point2f();
	bool isExc = NativeMethodsExc.imgproc_Subdiv2D_getVertex_excsafe(ref ret, obj, vertex,  out firstEdge);

	if(isExc)
		handleException();
	return ret;
}


public static  System.Int32 imgproc_Subdiv2D_getEdge( System.IntPtr obj ,  System.Int32 edge ,  System.Int32 nextEdgeType )
{
	System.Int32 ret = new System.Int32();
	bool isExc = NativeMethodsExc.imgproc_Subdiv2D_getEdge_excsafe(ref ret, obj, edge, nextEdgeType);

	if(isExc)
		handleException();
	return ret;
}


public static  System.Int32 imgproc_GeneralizedHoughGuil_getAngleThresh( System.IntPtr obj )
{
	System.Int32 ret = new System.Int32();
	bool isExc = NativeMethodsExc.imgproc_GeneralizedHoughGuil_getAngleThresh_excsafe(ref ret, obj);

	if(isExc)
		handleException();
	return ret;
}


public static  void imgproc_GeneralizedHoughGuil_setMinScale( System.IntPtr obj ,  System.Double val )
{
	bool isExc = NativeMethodsExc.imgproc_GeneralizedHoughGuil_setMinScale_excsafe(obj, val);

	if(isExc)
		handleException();
}


public static  System.Double imgproc_GeneralizedHoughGuil_getMinScale( System.IntPtr obj )
{
	System.Double ret = new System.Double();
	bool isExc = NativeMethodsExc.imgproc_GeneralizedHoughGuil_getMinScale_excsafe(ref ret, obj);

	if(isExc)
		handleException();
	return ret;
}


public static  void imgproc_GeneralizedHoughGuil_setMaxScale( System.IntPtr obj ,  System.Double val )
{
	bool isExc = NativeMethodsExc.imgproc_GeneralizedHoughGuil_setMaxScale_excsafe(obj, val);

	if(isExc)
		handleException();
}


public static  System.Double imgproc_GeneralizedHoughGuil_getMaxScale( System.IntPtr obj )
{
	System.Double ret = new System.Double();
	bool isExc = NativeMethodsExc.imgproc_GeneralizedHoughGuil_getMaxScale_excsafe(ref ret, obj);

	if(isExc)
		handleException();
	return ret;
}


public static  void imgproc_GeneralizedHoughGuil_setScaleStep( System.IntPtr obj ,  System.Double val )
{
	bool isExc = NativeMethodsExc.imgproc_GeneralizedHoughGuil_setScaleStep_excsafe(obj, val);

	if(isExc)
		handleException();
}


public static  System.Double imgproc_GeneralizedHoughGuil_getScaleStep( System.IntPtr obj )
{
	System.Double ret = new System.Double();
	bool isExc = NativeMethodsExc.imgproc_GeneralizedHoughGuil_getScaleStep_excsafe(ref ret, obj);

	if(isExc)
		handleException();
	return ret;
}


public static  void imgproc_GeneralizedHoughGuil_setScaleThresh( System.IntPtr obj ,  System.Int32 val )
{
	bool isExc = NativeMethodsExc.imgproc_GeneralizedHoughGuil_setScaleThresh_excsafe(obj, val);

	if(isExc)
		handleException();
}


public static  System.Int32 imgproc_GeneralizedHoughGuil_getScaleThresh( System.IntPtr obj )
{
	System.Int32 ret = new System.Int32();
	bool isExc = NativeMethodsExc.imgproc_GeneralizedHoughGuil_getScaleThresh_excsafe(ref ret, obj);

	if(isExc)
		handleException();
	return ret;
}


public static  void imgproc_GeneralizedHoughGuil_setPosThresh( System.IntPtr obj ,  System.Int32 val )
{
	bool isExc = NativeMethodsExc.imgproc_GeneralizedHoughGuil_setPosThresh_excsafe(obj, val);

	if(isExc)
		handleException();
}


public static  System.Int32 imgproc_GeneralizedHoughGuil_getPosThresh( System.IntPtr obj )
{
	System.Int32 ret = new System.Int32();
	bool isExc = NativeMethodsExc.imgproc_GeneralizedHoughGuil_getPosThresh_excsafe(ref ret, obj);

	if(isExc)
		handleException();
	return ret;
}


public static  System.IntPtr imgproc_LineIterator_new( System.IntPtr img ,  OpenCvSharp.Point pt1 ,  OpenCvSharp.Point pt2 ,  System.Int32 connectivity ,  System.Int32 leftToRight )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.imgproc_LineIterator_new_excsafe(ref ret, img, pt1, pt2, connectivity, leftToRight);

	if(isExc)
		handleException();
	return ret;
}


public static  void imgproc_LineIterator_delete( System.IntPtr obj )
{
	bool isExc = NativeMethodsExc.imgproc_LineIterator_delete_excsafe(obj);

	if(isExc)
		handleException();
}


public static  System.IntPtr imgproc_LineIterator_operatorEntity( System.IntPtr obj )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.imgproc_LineIterator_operatorEntity_excsafe(ref ret, obj);

	if(isExc)
		handleException();
	return ret;
}


public static  void imgproc_LineIterator_operatorPP( System.IntPtr obj )
{
	bool isExc = NativeMethodsExc.imgproc_LineIterator_operatorPP_excsafe(obj);

	if(isExc)
		handleException();
}


public static  OpenCvSharp.Point imgproc_LineIterator_pos( System.IntPtr obj )
{
	OpenCvSharp.Point ret = new OpenCvSharp.Point();
	bool isExc = NativeMethodsExc.imgproc_LineIterator_pos_excsafe(ref ret, obj);

	if(isExc)
		handleException();
	return ret;
}


public static  System.IntPtr imgproc_LineIterator_ptr_get( System.IntPtr obj )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.imgproc_LineIterator_ptr_get_excsafe(ref ret, obj);

	if(isExc)
		handleException();
	return ret;
}


public static  void imgproc_LineIterator_ptr_set( System.IntPtr obj ,  System.IntPtr val )
{
	bool isExc = NativeMethodsExc.imgproc_LineIterator_ptr_set_excsafe(obj, val);

	if(isExc)
		handleException();
}


public static  System.IntPtr imgproc_LineIterator_ptr0_get( System.IntPtr obj )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.imgproc_LineIterator_ptr0_get_excsafe(ref ret, obj);

	if(isExc)
		handleException();
	return ret;
}


public static  System.Int32 imgproc_LineIterator_step_get( System.IntPtr obj )
{
	System.Int32 ret = new System.Int32();
	bool isExc = NativeMethodsExc.imgproc_LineIterator_step_get_excsafe(ref ret, obj);

	if(isExc)
		handleException();
	return ret;
}


public static  void imgproc_LineIterator_step_set( System.IntPtr obj ,  System.Int32 val )
{
	bool isExc = NativeMethodsExc.imgproc_LineIterator_step_set_excsafe(obj, val);

	if(isExc)
		handleException();
}


public static  System.Int32 imgproc_LineIterator_elemSize_get( System.IntPtr obj )
{
	System.Int32 ret = new System.Int32();
	bool isExc = NativeMethodsExc.imgproc_LineIterator_elemSize_get_excsafe(ref ret, obj);

	if(isExc)
		handleException();
	return ret;
}


public static  void imgproc_LineIterator_elemSize_set( System.IntPtr obj ,  System.Int32 val )
{
	bool isExc = NativeMethodsExc.imgproc_LineIterator_elemSize_set_excsafe(obj, val);

	if(isExc)
		handleException();
}


public static  System.Int32 imgproc_LineIterator_err_get( System.IntPtr obj )
{
	System.Int32 ret = new System.Int32();
	bool isExc = NativeMethodsExc.imgproc_LineIterator_err_get_excsafe(ref ret, obj);

	if(isExc)
		handleException();
	return ret;
}


public static  void imgproc_LineIterator_err_set( System.IntPtr obj ,  System.Int32 val )
{
	bool isExc = NativeMethodsExc.imgproc_LineIterator_err_set_excsafe(obj, val);

	if(isExc)
		handleException();
}


public static  System.Int32 imgproc_LineIterator_count_get( System.IntPtr obj )
{
	System.Int32 ret = new System.Int32();
	bool isExc = NativeMethodsExc.imgproc_LineIterator_count_get_excsafe(ref ret, obj);

	if(isExc)
		handleException();
	return ret;
}


public static  void imgproc_LineIterator_count_set( System.IntPtr obj ,  System.Int32 val )
{
	bool isExc = NativeMethodsExc.imgproc_LineIterator_count_set_excsafe(obj, val);

	if(isExc)
		handleException();
}


public static  System.Int32 imgproc_LineIterator_minusDelta_get( System.IntPtr obj )
{
	System.Int32 ret = new System.Int32();
	bool isExc = NativeMethodsExc.imgproc_LineIterator_minusDelta_get_excsafe(ref ret, obj);

	if(isExc)
		handleException();
	return ret;
}


public static  System.Double imgproc_GeneralizedHough_getMinDist( System.IntPtr obj )
{
	System.Double ret = new System.Double();
	bool isExc = NativeMethodsExc.imgproc_GeneralizedHough_getMinDist_excsafe(ref ret, obj);

	if(isExc)
		handleException();
	return ret;
}


public static  void imgproc_GeneralizedHough_setDp( System.IntPtr obj ,  System.Double val )
{
	bool isExc = NativeMethodsExc.imgproc_GeneralizedHough_setDp_excsafe(obj, val);

	if(isExc)
		handleException();
}


public static  System.Double imgproc_GeneralizedHough_getDp( System.IntPtr obj )
{
	System.Double ret = new System.Double();
	bool isExc = NativeMethodsExc.imgproc_GeneralizedHough_getDp_excsafe(ref ret, obj);

	if(isExc)
		handleException();
	return ret;
}


public static  void imgproc_GeneralizedHough_setMaxBufferSize( System.IntPtr obj ,  System.Int32 val )
{
	bool isExc = NativeMethodsExc.imgproc_GeneralizedHough_setMaxBufferSize_excsafe(obj, val);

	if(isExc)
		handleException();
}


public static  System.Int32 imgproc_GeneralizedHough_getMaxBufferSize( System.IntPtr obj )
{
	System.Int32 ret = new System.Int32();
	bool isExc = NativeMethodsExc.imgproc_GeneralizedHough_getMaxBufferSize_excsafe(ref ret, obj);

	if(isExc)
		handleException();
	return ret;
}


public static  System.IntPtr imgproc_createGeneralizedHoughBallard()
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.imgproc_createGeneralizedHoughBallard_excsafe(ref ret);

	if(isExc)
		handleException();
	return ret;
}


public static  System.IntPtr imgproc_Ptr_GeneralizedHoughBallard_get( System.IntPtr obj )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.imgproc_Ptr_GeneralizedHoughBallard_get_excsafe(ref ret, obj);

	if(isExc)
		handleException();
	return ret;
}


public static  void imgproc_Ptr_GeneralizedHoughBallard_delete( System.IntPtr obj )
{
	bool isExc = NativeMethodsExc.imgproc_Ptr_GeneralizedHoughBallard_delete_excsafe(obj);

	if(isExc)
		handleException();
}


public static  void imgproc_GeneralizedHoughBallard_setLevels( System.IntPtr obj ,  System.Int32 val )
{
	bool isExc = NativeMethodsExc.imgproc_GeneralizedHoughBallard_setLevels_excsafe(obj, val);

	if(isExc)
		handleException();
}


public static  System.Int32 imgproc_GeneralizedHoughBallard_getLevels( System.IntPtr obj )
{
	System.Int32 ret = new System.Int32();
	bool isExc = NativeMethodsExc.imgproc_GeneralizedHoughBallard_getLevels_excsafe(ref ret, obj);

	if(isExc)
		handleException();
	return ret;
}


public static  void imgproc_GeneralizedHoughBallard_setVotesThreshold( System.IntPtr obj ,  System.Int32 val )
{
	bool isExc = NativeMethodsExc.imgproc_GeneralizedHoughBallard_setVotesThreshold_excsafe(obj, val);

	if(isExc)
		handleException();
}


public static  System.Int32 imgproc_GeneralizedHoughBallard_getVotesThreshold( System.IntPtr obj )
{
	System.Int32 ret = new System.Int32();
	bool isExc = NativeMethodsExc.imgproc_GeneralizedHoughBallard_getVotesThreshold_excsafe(ref ret, obj);

	if(isExc)
		handleException();
	return ret;
}


public static  System.IntPtr imgproc_createGeneralizedHoughGuil()
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.imgproc_createGeneralizedHoughGuil_excsafe(ref ret);

	if(isExc)
		handleException();
	return ret;
}


public static  System.IntPtr imgproc_Ptr_GeneralizedHoughGuil_get( System.IntPtr obj )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.imgproc_Ptr_GeneralizedHoughGuil_get_excsafe(ref ret, obj);

	if(isExc)
		handleException();
	return ret;
}


public static  void imgproc_Ptr_GeneralizedHoughGuil_delete( System.IntPtr obj )
{
	bool isExc = NativeMethodsExc.imgproc_Ptr_GeneralizedHoughGuil_delete_excsafe(obj);

	if(isExc)
		handleException();
}


public static  void imgproc_GeneralizedHoughGuil_setXi( System.IntPtr obj ,  System.Double val )
{
	bool isExc = NativeMethodsExc.imgproc_GeneralizedHoughGuil_setXi_excsafe(obj, val);

	if(isExc)
		handleException();
}


public static  System.Double imgproc_GeneralizedHoughGuil_getXi( System.IntPtr obj )
{
	System.Double ret = new System.Double();
	bool isExc = NativeMethodsExc.imgproc_GeneralizedHoughGuil_getXi_excsafe(ref ret, obj);

	if(isExc)
		handleException();
	return ret;
}


public static  void imgproc_GeneralizedHoughGuil_setLevels( System.IntPtr obj ,  System.Int32 val )
{
	bool isExc = NativeMethodsExc.imgproc_GeneralizedHoughGuil_setLevels_excsafe(obj, val);

	if(isExc)
		handleException();
}


public static  System.Int32 imgproc_GeneralizedHoughGuil_getLevels( System.IntPtr obj )
{
	System.Int32 ret = new System.Int32();
	bool isExc = NativeMethodsExc.imgproc_GeneralizedHoughGuil_getLevels_excsafe(ref ret, obj);

	if(isExc)
		handleException();
	return ret;
}


public static  void imgproc_GeneralizedHoughGuil_setAngleEpsilon( System.IntPtr obj ,  System.Double val )
{
	bool isExc = NativeMethodsExc.imgproc_GeneralizedHoughGuil_setAngleEpsilon_excsafe(obj, val);

	if(isExc)
		handleException();
}


public static  System.Double imgproc_GeneralizedHoughGuil_getAngleEpsilon( System.IntPtr obj )
{
	System.Double ret = new System.Double();
	bool isExc = NativeMethodsExc.imgproc_GeneralizedHoughGuil_getAngleEpsilon_excsafe(ref ret, obj);

	if(isExc)
		handleException();
	return ret;
}


public static  void imgproc_GeneralizedHoughGuil_setMinAngle( System.IntPtr obj ,  System.Double val )
{
	bool isExc = NativeMethodsExc.imgproc_GeneralizedHoughGuil_setMinAngle_excsafe(obj, val);

	if(isExc)
		handleException();
}


public static  System.Double imgproc_GeneralizedHoughGuil_getMinAngle( System.IntPtr obj )
{
	System.Double ret = new System.Double();
	bool isExc = NativeMethodsExc.imgproc_GeneralizedHoughGuil_getMinAngle_excsafe(ref ret, obj);

	if(isExc)
		handleException();
	return ret;
}


public static  void imgproc_GeneralizedHoughGuil_setMaxAngle( System.IntPtr obj ,  System.Double val )
{
	bool isExc = NativeMethodsExc.imgproc_GeneralizedHoughGuil_setMaxAngle_excsafe(obj, val);

	if(isExc)
		handleException();
}


public static  System.Double imgproc_GeneralizedHoughGuil_getMaxAngle( System.IntPtr obj )
{
	System.Double ret = new System.Double();
	bool isExc = NativeMethodsExc.imgproc_GeneralizedHoughGuil_getMaxAngle_excsafe(ref ret, obj);

	if(isExc)
		handleException();
	return ret;
}


public static  void imgproc_GeneralizedHoughGuil_setAngleStep( System.IntPtr obj ,  System.Double val )
{
	bool isExc = NativeMethodsExc.imgproc_GeneralizedHoughGuil_setAngleStep_excsafe(obj, val);

	if(isExc)
		handleException();
}


public static  System.Double imgproc_GeneralizedHoughGuil_getAngleStep( System.IntPtr obj )
{
	System.Double ret = new System.Double();
	bool isExc = NativeMethodsExc.imgproc_GeneralizedHoughGuil_getAngleStep_excsafe(ref ret, obj);

	if(isExc)
		handleException();
	return ret;
}


public static  void imgproc_GeneralizedHoughGuil_setAngleThresh( System.IntPtr obj ,  System.Int32 val )
{
	bool isExc = NativeMethodsExc.imgproc_GeneralizedHoughGuil_setAngleThresh_excsafe(obj, val);

	if(isExc)
		handleException();
}


public static  void imgproc_fillConvexPoly_InputOutputArray( System.IntPtr img ,  System.IntPtr points ,  OpenCvSharp.Scalar color ,  System.Int32 lineType ,  System.Int32 shift )
{
	bool isExc = NativeMethodsExc.imgproc_fillConvexPoly_InputOutputArray_excsafe(img, points, color, lineType, shift);

	if(isExc)
		handleException();
}


public static  void imgproc_fillPoly_Mat( System.IntPtr img ,  System.IntPtr[] pts ,  System.Int32[] npts ,  System.Int32 ncontours ,  OpenCvSharp.Scalar color ,  System.Int32 lineType ,  System.Int32 shift ,  OpenCvSharp.Point offset )
{
	bool isExc = NativeMethodsExc.imgproc_fillPoly_Mat_excsafe(img, pts, npts, ncontours, color, lineType, shift, offset);

	if(isExc)
		handleException();
}


public static  void imgproc_fillPoly_InputOutputArray( System.IntPtr img ,  System.IntPtr pts ,  OpenCvSharp.Scalar color ,  System.Int32 lineType ,  System.Int32 shift ,  OpenCvSharp.Point offset )
{
	bool isExc = NativeMethodsExc.imgproc_fillPoly_InputOutputArray_excsafe(img, pts, color, lineType, shift, offset);

	if(isExc)
		handleException();
}


public static  void imgproc_polylines_Mat( System.IntPtr img ,  System.IntPtr[] pts ,  System.Int32[] npts ,  System.Int32 ncontours ,  System.Int32 isClosed ,  OpenCvSharp.Scalar color ,  System.Int32 thickness ,  System.Int32 lineType ,  System.Int32 shift )
{
	bool isExc = NativeMethodsExc.imgproc_polylines_Mat_excsafe(img, pts, npts, ncontours, isClosed, color, thickness, lineType, shift);

	if(isExc)
		handleException();
}


public static  void imgproc_polylines_InputOutputArray( System.IntPtr img ,  System.IntPtr pts ,  System.Int32 isClosed ,  OpenCvSharp.Scalar color ,  System.Int32 thickness ,  System.Int32 lineType ,  System.Int32 shift )
{
	bool isExc = NativeMethodsExc.imgproc_polylines_InputOutputArray_excsafe(img, pts, isClosed, color, thickness, lineType, shift);

	if(isExc)
		handleException();
}


public static  System.Int32 imgproc_clipLine1( OpenCvSharp.Size imgSize ,  ref OpenCvSharp.Point pt1 ,  ref OpenCvSharp.Point pt2 )
{
	System.Int32 ret = new System.Int32();
	bool isExc = NativeMethodsExc.imgproc_clipLine1_excsafe(ref ret, imgSize,  ref pt1,  ref pt2);

	if(isExc)
		handleException();
	return ret;
}


public static  System.Int32 imgproc_clipLine2( OpenCvSharp.Rect imgRect ,  ref OpenCvSharp.Point pt1 ,  ref OpenCvSharp.Point pt2 )
{
	System.Int32 ret = new System.Int32();
	bool isExc = NativeMethodsExc.imgproc_clipLine2_excsafe(ref ret, imgRect,  ref pt1,  ref pt2);

	if(isExc)
		handleException();
	return ret;
}


public static  void imgproc_ellipse2Poly( OpenCvSharp.Point center ,  OpenCvSharp.Size axes ,  System.Int32 angle ,  System.Int32 arcStart ,  System.Int32 arcEnd ,  System.Int32 delta ,  System.IntPtr pts )
{
	bool isExc = NativeMethodsExc.imgproc_ellipse2Poly_excsafe(center, axes, angle, arcStart, arcEnd, delta, pts);

	if(isExc)
		handleException();
}


public static  void core_putText( System.IntPtr img , [MarshalAs(UnmanagedType.LPStr)] System.String text ,  OpenCvSharp.Point org ,  System.Int32 fontFace ,  System.Double fontScale ,  OpenCvSharp.Scalar color ,  System.Int32 thickness ,  System.Int32 lineType ,  System.Int32 bottomLeftOrigin )
{
	bool isExc = NativeMethodsExc.core_putText_excsafe(img, text, org, fontFace, fontScale, color, thickness, lineType, bottomLeftOrigin);

	if(isExc)
		handleException();
}


public static  OpenCvSharp.Size core_getTextSize([MarshalAs(UnmanagedType.LPStr)] System.String text ,  System.Int32 fontFace ,  System.Double fontScale ,  System.Int32 thickness ,  out System.Int32 baseLine )
{
	OpenCvSharp.Size ret = new OpenCvSharp.Size();
	bool isExc = NativeMethodsExc.core_getTextSize_excsafe(ref ret, text, fontFace, fontScale, thickness,  out baseLine);

	if(isExc)
		handleException();
	return ret;
}


public static  System.IntPtr imgproc_createCLAHE( System.Double clipLimit ,  OpenCvSharp.Size tileGridSize )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.imgproc_createCLAHE_excsafe(ref ret, clipLimit, tileGridSize);

	if(isExc)
		handleException();
	return ret;
}


public static  void imgproc_Ptr_CLAHE_delete( System.IntPtr obj )
{
	bool isExc = NativeMethodsExc.imgproc_Ptr_CLAHE_delete_excsafe(obj);

	if(isExc)
		handleException();
}


public static  System.IntPtr imgproc_Ptr_CLAHE_get( System.IntPtr obj )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.imgproc_Ptr_CLAHE_get_excsafe(ref ret, obj);

	if(isExc)
		handleException();
	return ret;
}


public static  void imgproc_CLAHE_apply( System.IntPtr obj ,  System.IntPtr src ,  System.IntPtr dst )
{
	bool isExc = NativeMethodsExc.imgproc_CLAHE_apply_excsafe(obj, src, dst);

	if(isExc)
		handleException();
}


public static  void imgproc_CLAHE_setClipLimit( System.IntPtr obj ,  System.Double clipLimit )
{
	bool isExc = NativeMethodsExc.imgproc_CLAHE_setClipLimit_excsafe(obj, clipLimit);

	if(isExc)
		handleException();
}


public static  System.Double imgproc_CLAHE_getClipLimit( System.IntPtr obj )
{
	System.Double ret = new System.Double();
	bool isExc = NativeMethodsExc.imgproc_CLAHE_getClipLimit_excsafe(ref ret, obj);

	if(isExc)
		handleException();
	return ret;
}


public static  void imgproc_CLAHE_setTilesGridSize( System.IntPtr obj ,  OpenCvSharp.Size tileGridSize )
{
	bool isExc = NativeMethodsExc.imgproc_CLAHE_setTilesGridSize_excsafe(obj, tileGridSize);

	if(isExc)
		handleException();
}


public static  OpenCvSharp.Size imgproc_CLAHE_getTilesGridSize( System.IntPtr obj )
{
	OpenCvSharp.Size ret = new OpenCvSharp.Size();
	bool isExc = NativeMethodsExc.imgproc_CLAHE_getTilesGridSize_excsafe(ref ret, obj);

	if(isExc)
		handleException();
	return ret;
}


public static  void imgproc_CLAHE_collectGarbage( System.IntPtr obj )
{
	bool isExc = NativeMethodsExc.imgproc_CLAHE_collectGarbage_excsafe(obj);

	if(isExc)
		handleException();
}


public static  void imgproc_GeneralizedHough_setTemplate1( System.IntPtr obj ,  System.IntPtr templ ,  OpenCvSharp.Point templCenter )
{
	bool isExc = NativeMethodsExc.imgproc_GeneralizedHough_setTemplate1_excsafe(obj, templ, templCenter);

	if(isExc)
		handleException();
}


public static  void imgproc_GeneralizedHough_setTemplate2( System.IntPtr obj ,  System.IntPtr edges ,  System.IntPtr dx ,  System.IntPtr dy ,  OpenCvSharp.Point templCenter )
{
	bool isExc = NativeMethodsExc.imgproc_GeneralizedHough_setTemplate2_excsafe(obj, edges, dx, dy, templCenter);

	if(isExc)
		handleException();
}


public static  void imgproc_GeneralizedHough_detect1( System.IntPtr obj ,  System.IntPtr image ,  System.IntPtr positions ,  System.IntPtr votes )
{
	bool isExc = NativeMethodsExc.imgproc_GeneralizedHough_detect1_excsafe(obj, image, positions, votes);

	if(isExc)
		handleException();
}


public static  void imgproc_GeneralizedHough_detect2( System.IntPtr obj ,  System.IntPtr edges ,  System.IntPtr dx ,  System.IntPtr dy ,  System.IntPtr positions ,  System.IntPtr votes )
{
	bool isExc = NativeMethodsExc.imgproc_GeneralizedHough_detect2_excsafe(obj, edges, dx, dy, positions, votes);

	if(isExc)
		handleException();
}


public static  void imgproc_GeneralizedHough_setCannyLowThresh( System.IntPtr obj ,  System.Int32 val )
{
	bool isExc = NativeMethodsExc.imgproc_GeneralizedHough_setCannyLowThresh_excsafe(obj, val);

	if(isExc)
		handleException();
}


public static  System.Int32 imgproc_GeneralizedHough_getCannyLowThresh( System.IntPtr obj )
{
	System.Int32 ret = new System.Int32();
	bool isExc = NativeMethodsExc.imgproc_GeneralizedHough_getCannyLowThresh_excsafe(ref ret, obj);

	if(isExc)
		handleException();
	return ret;
}


public static  void imgproc_GeneralizedHough_setCannyHighThresh( System.IntPtr obj ,  System.Int32 val )
{
	bool isExc = NativeMethodsExc.imgproc_GeneralizedHough_setCannyHighThresh_excsafe(obj, val);

	if(isExc)
		handleException();
}


public static  System.Int32 imgproc_GeneralizedHough_getCannyHighThresh( System.IntPtr obj )
{
	System.Int32 ret = new System.Int32();
	bool isExc = NativeMethodsExc.imgproc_GeneralizedHough_getCannyHighThresh_excsafe(ref ret, obj);

	if(isExc)
		handleException();
	return ret;
}


public static  void imgproc_GeneralizedHough_setMinDist( System.IntPtr obj ,  System.Double val )
{
	bool isExc = NativeMethodsExc.imgproc_GeneralizedHough_setMinDist_excsafe(obj, val);

	if(isExc)
		handleException();
}


public static  System.Int32 imgproc_isContourConvex_InputArray( System.IntPtr contour )
{
	System.Int32 ret = new System.Int32();
	bool isExc = NativeMethodsExc.imgproc_isContourConvex_InputArray_excsafe(ref ret, contour);

	if(isExc)
		handleException();
	return ret;
}


public static  System.Int32 imgproc_isContourConvex_Point( OpenCvSharp.Point[] contour ,  System.Int32 contourLength )
{
	System.Int32 ret = new System.Int32();
	bool isExc = NativeMethodsExc.imgproc_isContourConvex_Point_excsafe(ref ret, contour, contourLength);

	if(isExc)
		handleException();
	return ret;
}


public static  System.Int32 imgproc_isContourConvex_Point2f( OpenCvSharp.Point2f[] contour ,  System.Int32 contourLength )
{
	System.Int32 ret = new System.Int32();
	bool isExc = NativeMethodsExc.imgproc_isContourConvex_Point2f_excsafe(ref ret, contour, contourLength);

	if(isExc)
		handleException();
	return ret;
}


public static  System.Single imgproc_intersectConvexConvex_InputArray( System.IntPtr p1 ,  System.IntPtr p2 ,  System.IntPtr p12 ,  System.Int32 handleNested )
{
	System.Single ret = new System.Single();
	bool isExc = NativeMethodsExc.imgproc_intersectConvexConvex_InputArray_excsafe(ref ret, p1, p2, p12, handleNested);

	if(isExc)
		handleException();
	return ret;
}


public static  System.Single imgproc_intersectConvexConvex_Point( OpenCvSharp.Point[] p1 ,  System.Int32 p1Length ,  OpenCvSharp.Point[] p2 ,  System.Int32 p2Length ,  out System.IntPtr p12 ,  System.Int32 handleNested )
{
	System.Single ret = new System.Single();
	bool isExc = NativeMethodsExc.imgproc_intersectConvexConvex_Point_excsafe(ref ret, p1, p1Length, p2, p2Length,  out p12, handleNested);

	if(isExc)
		handleException();
	return ret;
}


public static  System.Single imgproc_intersectConvexConvex_Point2f( OpenCvSharp.Point2f[] p1 ,  System.Int32 p1Length ,  OpenCvSharp.Point2f[] p2 ,  System.Int32 p2Length ,  out System.IntPtr p12 ,  System.Int32 handleNested )
{
	System.Single ret = new System.Single();
	bool isExc = NativeMethodsExc.imgproc_intersectConvexConvex_Point2f_excsafe(ref ret, p1, p1Length, p2, p2Length,  out p12, handleNested);

	if(isExc)
		handleException();
	return ret;
}


public static  OpenCvSharp.RotatedRect imgproc_fitEllipse_InputArray( System.IntPtr points )
{
	OpenCvSharp.RotatedRect ret = new OpenCvSharp.RotatedRect();
	bool isExc = NativeMethodsExc.imgproc_fitEllipse_InputArray_excsafe(ref ret, points);

	if(isExc)
		handleException();
	return ret;
}


public static  OpenCvSharp.RotatedRect imgproc_fitEllipse_Point( OpenCvSharp.Point[] points ,  System.Int32 pointsLength )
{
	OpenCvSharp.RotatedRect ret = new OpenCvSharp.RotatedRect();
	bool isExc = NativeMethodsExc.imgproc_fitEllipse_Point_excsafe(ref ret, points, pointsLength);

	if(isExc)
		handleException();
	return ret;
}


public static  OpenCvSharp.RotatedRect imgproc_fitEllipse_Point2f( OpenCvSharp.Point2f[] points ,  System.Int32 pointsLength )
{
	OpenCvSharp.RotatedRect ret = new OpenCvSharp.RotatedRect();
	bool isExc = NativeMethodsExc.imgproc_fitEllipse_Point2f_excsafe(ref ret, points, pointsLength);

	if(isExc)
		handleException();
	return ret;
}


public static  void imgproc_fitLine_InputArray( System.IntPtr points ,  System.IntPtr line ,  System.Int32 distType ,  System.Double param ,  System.Double reps ,  System.Double aeps )
{
	bool isExc = NativeMethodsExc.imgproc_fitLine_InputArray_excsafe(points, line, distType, param, reps, aeps);

	if(isExc)
		handleException();
}


public static  void imgproc_fitLine_Point( OpenCvSharp.Point[] points ,  System.Int32 pointsLength , [In, Out] System.Single[] line ,  System.Int32 distType ,  System.Double param ,  System.Double reps ,  System.Double aeps )
{
	bool isExc = NativeMethodsExc.imgproc_fitLine_Point_excsafe(points, pointsLength, line, distType, param, reps, aeps);

	if(isExc)
		handleException();
}


public static  void imgproc_fitLine_Point2f( OpenCvSharp.Point2f[] points ,  System.Int32 pointsLength , [In, Out] System.Single[] line ,  System.Int32 distType ,  System.Double param ,  System.Double reps ,  System.Double aeps )
{
	bool isExc = NativeMethodsExc.imgproc_fitLine_Point2f_excsafe(points, pointsLength, line, distType, param, reps, aeps);

	if(isExc)
		handleException();
}


public static  void imgproc_fitLine_Point3i( OpenCvSharp.Point3i[] points ,  System.Int32 pointsLength , [In, Out] System.Single[] line ,  System.Int32 distType ,  System.Double param ,  System.Double reps ,  System.Double aeps )
{
	bool isExc = NativeMethodsExc.imgproc_fitLine_Point3i_excsafe(points, pointsLength, line, distType, param, reps, aeps);

	if(isExc)
		handleException();
}


public static  void imgproc_fitLine_Point3f( OpenCvSharp.Point3f[] points ,  System.Int32 pointsLength , [In, Out] System.Single[] line ,  System.Int32 distType ,  System.Double param ,  System.Double reps ,  System.Double aeps )
{
	bool isExc = NativeMethodsExc.imgproc_fitLine_Point3f_excsafe(points, pointsLength, line, distType, param, reps, aeps);

	if(isExc)
		handleException();
}


public static  System.Double imgproc_pointPolygonTest_InputArray( System.IntPtr contour ,  OpenCvSharp.Point2f pt ,  System.Int32 measureDist )
{
	System.Double ret = new System.Double();
	bool isExc = NativeMethodsExc.imgproc_pointPolygonTest_InputArray_excsafe(ref ret, contour, pt, measureDist);

	if(isExc)
		handleException();
	return ret;
}


public static  System.Double imgproc_pointPolygonTest_Point( OpenCvSharp.Point[] contour ,  System.Int32 contourLength ,  OpenCvSharp.Point2f pt ,  System.Int32 measureDist )
{
	System.Double ret = new System.Double();
	bool isExc = NativeMethodsExc.imgproc_pointPolygonTest_Point_excsafe(ref ret, contour, contourLength, pt, measureDist);

	if(isExc)
		handleException();
	return ret;
}


public static  System.Double imgproc_pointPolygonTest_Point2f( OpenCvSharp.Point2f[] contour ,  System.Int32 contourLength ,  OpenCvSharp.Point2f pt ,  System.Int32 measureDist )
{
	System.Double ret = new System.Double();
	bool isExc = NativeMethodsExc.imgproc_pointPolygonTest_Point2f_excsafe(ref ret, contour, contourLength, pt, measureDist);

	if(isExc)
		handleException();
	return ret;
}


public static  System.Int32 imgproc_rotatedRectangleIntersection_OutputArray( OpenCvSharp.RotatedRect rect1 ,  OpenCvSharp.RotatedRect rect2 ,  System.IntPtr intersectingRegion )
{
	System.Int32 ret = new System.Int32();
	bool isExc = NativeMethodsExc.imgproc_rotatedRectangleIntersection_OutputArray_excsafe(ref ret, rect1, rect2, intersectingRegion);

	if(isExc)
		handleException();
	return ret;
}


public static  System.Int32 imgproc_rotatedRectangleIntersection_vector( OpenCvSharp.RotatedRect rect1 ,  OpenCvSharp.RotatedRect rect2 ,  System.IntPtr intersectingRegion )
{
	System.Int32 ret = new System.Int32();
	bool isExc = NativeMethodsExc.imgproc_rotatedRectangleIntersection_vector_excsafe(ref ret, rect1, rect2, intersectingRegion);

	if(isExc)
		handleException();
	return ret;
}


public static  void imgproc_applyColorMap( System.IntPtr src ,  System.IntPtr dst ,  System.Int32 colormap )
{
	bool isExc = NativeMethodsExc.imgproc_applyColorMap_excsafe(src, dst, colormap);

	if(isExc)
		handleException();
}


public static  void imgproc_line( System.IntPtr img ,  OpenCvSharp.Point pt1 ,  OpenCvSharp.Point pt2 ,  OpenCvSharp.Scalar color ,  System.Int32 thickness ,  System.Int32 lineType ,  System.Int32 shift )
{
	bool isExc = NativeMethodsExc.imgproc_line_excsafe(img, pt1, pt2, color, thickness, lineType, shift);

	if(isExc)
		handleException();
}


public static  void imgproc_arrowedLine( System.IntPtr img ,  OpenCvSharp.Point pt1 ,  OpenCvSharp.Point pt2 ,  OpenCvSharp.Scalar color ,  System.Int32 thickness ,  System.Int32 lineType ,  System.Int32 shift ,  System.Double tipLength )
{
	bool isExc = NativeMethodsExc.imgproc_arrowedLine_excsafe(img, pt1, pt2, color, thickness, lineType, shift, tipLength);

	if(isExc)
		handleException();
}


public static  void imgproc_rectangle_InputOutputArray( System.IntPtr img ,  OpenCvSharp.Point pt1 ,  OpenCvSharp.Point pt2 ,  OpenCvSharp.Scalar color ,  System.Int32 thickness ,  System.Int32 lineType ,  System.Int32 shift )
{
	bool isExc = NativeMethodsExc.imgproc_rectangle_InputOutputArray_excsafe(img, pt1, pt2, color, thickness, lineType, shift);

	if(isExc)
		handleException();
}


public static  void imgproc_rectangle_Mat( System.IntPtr img ,  OpenCvSharp.Rect rect ,  OpenCvSharp.Scalar color ,  System.Int32 thickness ,  System.Int32 lineType ,  System.Int32 shift )
{
	bool isExc = NativeMethodsExc.imgproc_rectangle_Mat_excsafe(img, rect, color, thickness, lineType, shift);

	if(isExc)
		handleException();
}


public static  void imgproc_circle( System.IntPtr img ,  OpenCvSharp.Point center ,  System.Int32 radius ,  OpenCvSharp.Scalar color ,  System.Int32 thickness ,  System.Int32 lineType ,  System.Int32 shift )
{
	bool isExc = NativeMethodsExc.imgproc_circle_excsafe(img, center, radius, color, thickness, lineType, shift);

	if(isExc)
		handleException();
}


public static  void imgproc_ellipse1( System.IntPtr img ,  OpenCvSharp.Point center ,  OpenCvSharp.Size axes ,  System.Double angle ,  System.Double startAngle ,  System.Double endAngle ,  OpenCvSharp.Scalar color ,  System.Int32 thickness ,  System.Int32 lineType ,  System.Int32 shift )
{
	bool isExc = NativeMethodsExc.imgproc_ellipse1_excsafe(img, center, axes, angle, startAngle, endAngle, color, thickness, lineType, shift);

	if(isExc)
		handleException();
}


public static  void imgproc_ellipse2( System.IntPtr img ,  OpenCvSharp.RotatedRect box ,  OpenCvSharp.Scalar color ,  System.Int32 thickness ,  System.Int32 lineType )
{
	bool isExc = NativeMethodsExc.imgproc_ellipse2_excsafe(img, box, color, thickness, lineType);

	if(isExc)
		handleException();
}


public static  void imgproc_fillConvexPoly_Mat( System.IntPtr img ,  OpenCvSharp.Point[] pts ,  System.Int32 npts ,  OpenCvSharp.Scalar color ,  System.Int32 lineType ,  System.Int32 shift )
{
	bool isExc = NativeMethodsExc.imgproc_fillConvexPoly_Mat_excsafe(img, pts, npts, color, lineType, shift);

	if(isExc)
		handleException();
}


public static  void imgproc_approxPolyDP_InputArray( System.IntPtr curve ,  System.IntPtr approxCurve ,  System.Double epsilon ,  System.Int32 closed )
{
	bool isExc = NativeMethodsExc.imgproc_approxPolyDP_InputArray_excsafe(curve, approxCurve, epsilon, closed);

	if(isExc)
		handleException();
}


public static  void imgproc_approxPolyDP_Point( OpenCvSharp.Point[] curve ,  System.Int32 curveLength ,  out System.IntPtr approxCurve ,  System.Double epsilon ,  System.Int32 closed )
{
	bool isExc = NativeMethodsExc.imgproc_approxPolyDP_Point_excsafe(curve, curveLength,  out approxCurve, epsilon, closed);

	if(isExc)
		handleException();
}


public static  void imgproc_approxPolyDP_Point2f( OpenCvSharp.Point2f[] curve ,  System.Int32 curveLength ,  out System.IntPtr approxCurve ,  System.Double epsilon ,  System.Int32 closed )
{
	bool isExc = NativeMethodsExc.imgproc_approxPolyDP_Point2f_excsafe(curve, curveLength,  out approxCurve, epsilon, closed);

	if(isExc)
		handleException();
}


public static  System.Double imgproc_arcLength_InputArray( System.IntPtr curve ,  System.Int32 closed )
{
	System.Double ret = new System.Double();
	bool isExc = NativeMethodsExc.imgproc_arcLength_InputArray_excsafe(ref ret, curve, closed);

	if(isExc)
		handleException();
	return ret;
}


public static  System.Double imgproc_arcLength_Point( OpenCvSharp.Point[] curve ,  System.Int32 curveLength ,  System.Int32 closed )
{
	System.Double ret = new System.Double();
	bool isExc = NativeMethodsExc.imgproc_arcLength_Point_excsafe(ref ret, curve, curveLength, closed);

	if(isExc)
		handleException();
	return ret;
}


public static  System.Double imgproc_arcLength_Point2f( OpenCvSharp.Point2f[] curve ,  System.Int32 curveLength ,  System.Int32 closed )
{
	System.Double ret = new System.Double();
	bool isExc = NativeMethodsExc.imgproc_arcLength_Point2f_excsafe(ref ret, curve, curveLength, closed);

	if(isExc)
		handleException();
	return ret;
}


public static  OpenCvSharp.Rect imgproc_boundingRect_InputArray( System.IntPtr curve )
{
	OpenCvSharp.Rect ret = new OpenCvSharp.Rect();
	bool isExc = NativeMethodsExc.imgproc_boundingRect_InputArray_excsafe(ref ret, curve);

	if(isExc)
		handleException();
	return ret;
}


public static  OpenCvSharp.Rect imgproc_boundingRect_Point( OpenCvSharp.Point[] curve ,  System.Int32 curveLength )
{
	OpenCvSharp.Rect ret = new OpenCvSharp.Rect();
	bool isExc = NativeMethodsExc.imgproc_boundingRect_Point_excsafe(ref ret, curve, curveLength);

	if(isExc)
		handleException();
	return ret;
}


public static  OpenCvSharp.Rect imgproc_boundingRect_Point2f( OpenCvSharp.Point2f[] curve ,  System.Int32 curveLength )
{
	OpenCvSharp.Rect ret = new OpenCvSharp.Rect();
	bool isExc = NativeMethodsExc.imgproc_boundingRect_Point2f_excsafe(ref ret, curve, curveLength);

	if(isExc)
		handleException();
	return ret;
}


public static  System.Double imgproc_contourArea_InputArray( System.IntPtr contour ,  System.Int32 oriented )
{
	System.Double ret = new System.Double();
	bool isExc = NativeMethodsExc.imgproc_contourArea_InputArray_excsafe(ref ret, contour, oriented);

	if(isExc)
		handleException();
	return ret;
}


public static  System.Double imgproc_contourArea_Point( OpenCvSharp.Point[] contour ,  System.Int32 contourLength ,  System.Int32 oriented )
{
	System.Double ret = new System.Double();
	bool isExc = NativeMethodsExc.imgproc_contourArea_Point_excsafe(ref ret, contour, contourLength, oriented);

	if(isExc)
		handleException();
	return ret;
}


public static  System.Double imgproc_contourArea_Point2f( OpenCvSharp.Point2f[] contour ,  System.Int32 contourLength ,  System.Int32 oriented )
{
	System.Double ret = new System.Double();
	bool isExc = NativeMethodsExc.imgproc_contourArea_Point2f_excsafe(ref ret, contour, contourLength, oriented);

	if(isExc)
		handleException();
	return ret;
}


public static  OpenCvSharp.RotatedRect imgproc_minAreaRect_InputArray( System.IntPtr points )
{
	OpenCvSharp.RotatedRect ret = new OpenCvSharp.RotatedRect();
	bool isExc = NativeMethodsExc.imgproc_minAreaRect_InputArray_excsafe(ref ret, points);

	if(isExc)
		handleException();
	return ret;
}


public static  OpenCvSharp.RotatedRect imgproc_minAreaRect_Point( OpenCvSharp.Point[] points ,  System.Int32 pointsLength )
{
	OpenCvSharp.RotatedRect ret = new OpenCvSharp.RotatedRect();
	bool isExc = NativeMethodsExc.imgproc_minAreaRect_Point_excsafe(ref ret, points, pointsLength);

	if(isExc)
		handleException();
	return ret;
}


public static  OpenCvSharp.RotatedRect imgproc_minAreaRect_Point2f( OpenCvSharp.Point2f[] points ,  System.Int32 pointsLength )
{
	OpenCvSharp.RotatedRect ret = new OpenCvSharp.RotatedRect();
	bool isExc = NativeMethodsExc.imgproc_minAreaRect_Point2f_excsafe(ref ret, points, pointsLength);

	if(isExc)
		handleException();
	return ret;
}


public static  void imgproc_minEnclosingCircle_InputArray( System.IntPtr points ,  out OpenCvSharp.Point2f center ,  out System.Single radius )
{
	bool isExc = NativeMethodsExc.imgproc_minEnclosingCircle_InputArray_excsafe(points,  out center,  out radius);

	if(isExc)
		handleException();
}


public static  void imgproc_minEnclosingCircle_Point( OpenCvSharp.Point[] points ,  System.Int32 pointsLength ,  out OpenCvSharp.Point2f center ,  out System.Single radius )
{
	bool isExc = NativeMethodsExc.imgproc_minEnclosingCircle_Point_excsafe(points, pointsLength,  out center,  out radius);

	if(isExc)
		handleException();
}


public static  void imgproc_minEnclosingCircle_Point2f( OpenCvSharp.Point2f[] points ,  System.Int32 pointsLength ,  out OpenCvSharp.Point2f center ,  out System.Single radius )
{
	bool isExc = NativeMethodsExc.imgproc_minEnclosingCircle_Point2f_excsafe(points, pointsLength,  out center,  out radius);

	if(isExc)
		handleException();
}


public static  System.Double imgproc_matchShapes_InputArray( System.IntPtr contour1 ,  System.IntPtr contour2 ,  System.Int32 method ,  System.Double parameter )
{
	System.Double ret = new System.Double();
	bool isExc = NativeMethodsExc.imgproc_matchShapes_InputArray_excsafe(ref ret, contour1, contour2, method, parameter);

	if(isExc)
		handleException();
	return ret;
}


public static  System.Double imgproc_matchShapes_Point( OpenCvSharp.Point[] contour1 ,  System.Int32 contour1Length ,  OpenCvSharp.Point[] contour2 ,  System.Int32 contour2Length ,  System.Int32 method ,  System.Double parameter )
{
	System.Double ret = new System.Double();
	bool isExc = NativeMethodsExc.imgproc_matchShapes_Point_excsafe(ref ret, contour1, contour1Length, contour2, contour2Length, method, parameter);

	if(isExc)
		handleException();
	return ret;
}


public static  void imgproc_convexHull_InputArray( System.IntPtr points ,  System.IntPtr hull ,  System.Int32 clockwise ,  System.Int32 returnPoints )
{
	bool isExc = NativeMethodsExc.imgproc_convexHull_InputArray_excsafe(points, hull, clockwise, returnPoints);

	if(isExc)
		handleException();
}


public static  void imgproc_convexHull_Point_ReturnsPoints( OpenCvSharp.Point[] points ,  System.Int32 pointsLength ,  out System.IntPtr hull ,  System.Int32 clockwise )
{
	bool isExc = NativeMethodsExc.imgproc_convexHull_Point_ReturnsPoints_excsafe(points, pointsLength,  out hull, clockwise);

	if(isExc)
		handleException();
}


public static  void imgproc_convexHull_Point2f_ReturnsPoints( OpenCvSharp.Point2f[] points ,  System.Int32 pointsLength ,  out System.IntPtr hull ,  System.Int32 clockwise )
{
	bool isExc = NativeMethodsExc.imgproc_convexHull_Point2f_ReturnsPoints_excsafe(points, pointsLength,  out hull, clockwise);

	if(isExc)
		handleException();
}


public static  void imgproc_convexHull_Point_ReturnsIndices( OpenCvSharp.Point[] points ,  System.Int32 pointsLength ,  out System.IntPtr hull ,  System.Int32 clockwise )
{
	bool isExc = NativeMethodsExc.imgproc_convexHull_Point_ReturnsIndices_excsafe(points, pointsLength,  out hull, clockwise);

	if(isExc)
		handleException();
}


public static  void imgproc_convexHull_Point2f_ReturnsIndices( OpenCvSharp.Point2f[] points ,  System.Int32 pointsLength ,  out System.IntPtr hull ,  System.Int32 clockwise )
{
	bool isExc = NativeMethodsExc.imgproc_convexHull_Point2f_ReturnsIndices_excsafe(points, pointsLength,  out hull, clockwise);

	if(isExc)
		handleException();
}


public static  void imgproc_convexityDefects_InputArray( System.IntPtr contour ,  System.IntPtr convexHull ,  System.IntPtr convexityDefects )
{
	bool isExc = NativeMethodsExc.imgproc_convexityDefects_InputArray_excsafe(contour, convexHull, convexityDefects);

	if(isExc)
		handleException();
}


public static  void imgproc_convexityDefects_Point( OpenCvSharp.Point[] contour ,  System.Int32 contourLength ,  System.Int32[] convexHull ,  System.Int32 convexHullLength ,  out System.IntPtr convexityDefects )
{
	bool isExc = NativeMethodsExc.imgproc_convexityDefects_Point_excsafe(contour, contourLength, convexHull, convexHullLength,  out convexityDefects);

	if(isExc)
		handleException();
}


public static  void imgproc_convexityDefects_Point2f( OpenCvSharp.Point2f[] contour ,  System.Int32 contourLength ,  System.Int32[] convexHull ,  System.Int32 convexHullLength ,  out System.IntPtr convexityDefects )
{
	bool isExc = NativeMethodsExc.imgproc_convexityDefects_Point2f_excsafe(contour, contourLength, convexHull, convexHullLength,  out convexityDefects);

	if(isExc)
		handleException();
}


public static  void imgproc_initUndistortRectifyMap( System.IntPtr cameraMatrix ,  System.IntPtr distCoeffs ,  System.IntPtr r ,  System.IntPtr newCameraMatrix ,  OpenCvSharp.Size size ,  System.Int32 m1Type ,  System.IntPtr map1 ,  System.IntPtr map2 )
{
	bool isExc = NativeMethodsExc.imgproc_initUndistortRectifyMap_excsafe(cameraMatrix, distCoeffs, r, newCameraMatrix, size, m1Type, map1, map2);

	if(isExc)
		handleException();
}


public static  System.Single imgproc_initWideAngleProjMap( System.IntPtr cameraMatrix ,  System.IntPtr distCoeffs ,  OpenCvSharp.Size imageSize ,  System.Int32 destImageWidth ,  System.Int32 m1Type ,  System.IntPtr map1 ,  System.IntPtr map2 ,  System.Int32 projType ,  System.Double alpha )
{
	System.Single ret = new System.Single();
	bool isExc = NativeMethodsExc.imgproc_initWideAngleProjMap_excsafe(ref ret, cameraMatrix, distCoeffs, imageSize, destImageWidth, m1Type, map1, map2, projType, alpha);

	if(isExc)
		handleException();
	return ret;
}


public static  System.IntPtr imgproc_getDefaultNewCameraMatrix( System.IntPtr cameraMatrix ,  OpenCvSharp.Size imgSize ,  System.Int32 centerPrincipalPoint )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.imgproc_getDefaultNewCameraMatrix_excsafe(ref ret, cameraMatrix, imgSize, centerPrincipalPoint);

	if(isExc)
		handleException();
	return ret;
}


public static  void imgproc_undistortPoints( System.IntPtr src ,  System.IntPtr dst ,  System.IntPtr cameraMatrix ,  System.IntPtr distCoeffs ,  System.IntPtr r ,  System.IntPtr p )
{
	bool isExc = NativeMethodsExc.imgproc_undistortPoints_excsafe(src, dst, cameraMatrix, distCoeffs, r, p);

	if(isExc)
		handleException();
}


public static  void imgproc_calcHist1( System.IntPtr[] images ,  System.Int32 nimages ,  System.Int32[] channels ,  System.IntPtr mask ,  System.IntPtr hist ,  System.Int32 dims ,  System.Int32[] histSize ,  System.IntPtr[] ranges ,  System.Int32 uniform ,  System.Int32 accumulate )
{
	bool isExc = NativeMethodsExc.imgproc_calcHist1_excsafe(images, nimages, channels, mask, hist, dims, histSize, ranges, uniform, accumulate);

	if(isExc)
		handleException();
}


public static  void imgproc_calcBackProject( System.IntPtr[] images ,  System.Int32 nimages ,  System.Int32[] channels ,  System.IntPtr hist ,  System.IntPtr backProject ,  System.IntPtr[] ranges ,  System.Int32 uniform )
{
	bool isExc = NativeMethodsExc.imgproc_calcBackProject_excsafe(images, nimages, channels, hist, backProject, ranges, uniform);

	if(isExc)
		handleException();
}


public static  System.Double imgproc_compareHist1( System.IntPtr h1 ,  System.IntPtr h2 ,  System.Int32 method )
{
	System.Double ret = new System.Double();
	bool isExc = NativeMethodsExc.imgproc_compareHist1_excsafe(ref ret, h1, h2, method);

	if(isExc)
		handleException();
	return ret;
}


public static  void imgproc_equalizeHist( System.IntPtr src ,  System.IntPtr dst )
{
	bool isExc = NativeMethodsExc.imgproc_equalizeHist_excsafe(src, dst);

	if(isExc)
		handleException();
}


public static  System.Single imgproc_EMD( System.IntPtr signature1 ,  System.IntPtr signature2 ,  System.Int32 distType ,  System.IntPtr cost ,  out System.Single lowerBound ,  System.IntPtr flow )
{
	System.Single ret = new System.Single();
	bool isExc = NativeMethodsExc.imgproc_EMD_excsafe(ref ret, signature1, signature2, distType, cost,  out lowerBound, flow);

	if(isExc)
		handleException();
	return ret;
}


public static  void imgproc_watershed( System.IntPtr image ,  System.IntPtr markers )
{
	bool isExc = NativeMethodsExc.imgproc_watershed_excsafe(image, markers);

	if(isExc)
		handleException();
}


public static  void imgproc_pyrMeanShiftFiltering( System.IntPtr src ,  System.IntPtr dst ,  System.Double sp ,  System.Double sr ,  System.Int32 maxLevel ,  OpenCvSharp.TermCriteria termcrit )
{
	bool isExc = NativeMethodsExc.imgproc_pyrMeanShiftFiltering_excsafe(src, dst, sp, sr, maxLevel, termcrit);

	if(isExc)
		handleException();
}


public static  void imgproc_grabCut( System.IntPtr img ,  System.IntPtr mask ,  OpenCvSharp.Rect rect ,  System.IntPtr bgdModel ,  System.IntPtr fgdModel ,  System.Int32 iterCount ,  System.Int32 mode )
{
	bool isExc = NativeMethodsExc.imgproc_grabCut_excsafe(img, mask, rect, bgdModel, fgdModel, iterCount, mode);

	if(isExc)
		handleException();
}


public static  void imgproc_distanceTransformWithLabels( System.IntPtr src ,  System.IntPtr dst ,  System.IntPtr labels ,  System.Int32 distanceType ,  System.Int32 maskSize ,  System.Int32 labelType )
{
	bool isExc = NativeMethodsExc.imgproc_distanceTransformWithLabels_excsafe(src, dst, labels, distanceType, maskSize, labelType);

	if(isExc)
		handleException();
}


public static  void imgproc_distanceTransform( System.IntPtr src ,  System.IntPtr dst ,  System.Int32 distanceType ,  System.Int32 maskSize )
{
	bool isExc = NativeMethodsExc.imgproc_distanceTransform_excsafe(src, dst, distanceType, maskSize);

	if(isExc)
		handleException();
}


public static  System.Int32 imgproc_floodFill1( System.IntPtr image ,  OpenCvSharp.Point seedPoint ,  OpenCvSharp.Scalar newVal ,  out OpenCvSharp.Rect rect ,  OpenCvSharp.Scalar loDiff ,  OpenCvSharp.Scalar upDiff ,  System.Int32 flags )
{
	System.Int32 ret = new System.Int32();
	bool isExc = NativeMethodsExc.imgproc_floodFill1_excsafe(ref ret, image, seedPoint, newVal,  out rect, loDiff, upDiff, flags);

	if(isExc)
		handleException();
	return ret;
}


public static  System.Int32 imgproc_floodFill2( System.IntPtr image ,  System.IntPtr mask ,  OpenCvSharp.Point seedPoint ,  OpenCvSharp.Scalar newVal ,  out OpenCvSharp.Rect rect ,  OpenCvSharp.Scalar loDiff ,  OpenCvSharp.Scalar upDiff ,  System.Int32 flags )
{
	System.Int32 ret = new System.Int32();
	bool isExc = NativeMethodsExc.imgproc_floodFill2_excsafe(ref ret, image, mask, seedPoint, newVal,  out rect, loDiff, upDiff, flags);

	if(isExc)
		handleException();
	return ret;
}


public static  void imgproc_cvtColor( System.IntPtr src ,  System.IntPtr dst ,  System.Int32 code ,  System.Int32 dstCn )
{
	bool isExc = NativeMethodsExc.imgproc_cvtColor_excsafe(src, dst, code, dstCn);

	if(isExc)
		handleException();
}


public static  OpenCvSharp.Moments.NativeStruct imgproc_moments( System.IntPtr arr ,  System.Int32 binaryImage )
{
	OpenCvSharp.Moments.NativeStruct ret = new OpenCvSharp.Moments.NativeStruct();
	bool isExc = NativeMethodsExc.imgproc_moments_excsafe(ref ret, arr, binaryImage);

	if(isExc)
		handleException();
	return ret;
}


public static  void imgproc_matchTemplate( System.IntPtr image ,  System.IntPtr templ ,  System.IntPtr result ,  System.Int32 method ,  System.IntPtr mask )
{
	bool isExc = NativeMethodsExc.imgproc_matchTemplate_excsafe(image, templ, result, method, mask);

	if(isExc)
		handleException();
}


public static  System.Int32 imgproc_connectedComponents( System.IntPtr image ,  System.IntPtr labels ,  System.Int32 connectivity ,  System.Int32 ltype )
{
	System.Int32 ret = new System.Int32();
	bool isExc = NativeMethodsExc.imgproc_connectedComponents_excsafe(ref ret, image, labels, connectivity, ltype);

	if(isExc)
		handleException();
	return ret;
}


public static  System.Int32 imgproc_connectedComponentsWithStats( System.IntPtr image ,  System.IntPtr labels ,  System.IntPtr stats ,  System.IntPtr centroids ,  System.Int32 connectivity ,  System.Int32 ltype )
{
	System.Int32 ret = new System.Int32();
	bool isExc = NativeMethodsExc.imgproc_connectedComponentsWithStats_excsafe(ref ret, image, labels, stats, centroids, connectivity, ltype);

	if(isExc)
		handleException();
	return ret;
}


public static  void imgproc_findContours1_vector( System.IntPtr image ,  out System.IntPtr contours ,  out System.IntPtr hierarchy ,  System.Int32 mode ,  System.Int32 method ,  OpenCvSharp.Point offset )
{
	bool isExc = NativeMethodsExc.imgproc_findContours1_vector_excsafe(image,  out contours,  out hierarchy, mode, method, offset);

	if(isExc)
		handleException();
}


public static  void imgproc_findContours1_OutputArray( System.IntPtr image ,  out System.IntPtr contours ,  System.IntPtr hierarchy ,  System.Int32 mode ,  System.Int32 method ,  OpenCvSharp.Point offset )
{
	bool isExc = NativeMethodsExc.imgproc_findContours1_OutputArray_excsafe(image,  out contours, hierarchy, mode, method, offset);

	if(isExc)
		handleException();
}


public static  void imgproc_findContours2_vector( System.IntPtr image ,  out System.IntPtr contours ,  System.Int32 mode ,  System.Int32 method ,  OpenCvSharp.Point offset )
{
	bool isExc = NativeMethodsExc.imgproc_findContours2_vector_excsafe(image,  out contours, mode, method, offset);

	if(isExc)
		handleException();
}


public static  void imgproc_findContours2_OutputArray( System.IntPtr image ,  out System.IntPtr contours ,  System.Int32 mode ,  System.Int32 method ,  OpenCvSharp.Point offset )
{
	bool isExc = NativeMethodsExc.imgproc_findContours2_OutputArray_excsafe(image,  out contours, mode, method, offset);

	if(isExc)
		handleException();
}


public static  void imgproc_drawContours_vector( System.IntPtr image ,  System.IntPtr[] contours ,  System.Int32 contoursSize1 ,  System.Int32[] contoursSize2 ,  System.Int32 contourIdx ,  OpenCvSharp.Scalar color ,  System.Int32 thickness ,  System.Int32 lineType ,  OpenCvSharp.Vec4i[] hierarchy ,  System.Int32 hiearchyLength ,  System.Int32 maxLevel ,  OpenCvSharp.Point offset )
{
	bool isExc = NativeMethodsExc.imgproc_drawContours_vector_excsafe(image, contours, contoursSize1, contoursSize2, contourIdx, color, thickness, lineType, hierarchy, hiearchyLength, maxLevel, offset);

	if(isExc)
		handleException();
}


public static  void imgproc_drawContours_vector( System.IntPtr image ,  System.IntPtr[] contours ,  System.Int32 contoursSize1 ,  System.Int32[] contoursSize2 ,  System.Int32 contourIdx ,  OpenCvSharp.Scalar color ,  System.Int32 thickness ,  System.Int32 lineType ,  System.IntPtr hierarchy ,  System.Int32 hiearchyLength ,  System.Int32 maxLevel ,  OpenCvSharp.Point offset )
{
	bool isExc = NativeMethodsExc.imgproc_drawContours_vector_excsafe(image, contours, contoursSize1, contoursSize2, contourIdx, color, thickness, lineType, hierarchy, hiearchyLength, maxLevel, offset);

	if(isExc)
		handleException();
}


public static  void imgproc_drawContours_InputArray( System.IntPtr image ,  System.IntPtr[] contours ,  System.Int32 contoursLength ,  System.Int32 contourIdx ,  OpenCvSharp.Scalar color ,  System.Int32 thickness ,  System.Int32 lineType ,  System.IntPtr hierarchy ,  System.Int32 maxLevel ,  OpenCvSharp.Point offset )
{
	bool isExc = NativeMethodsExc.imgproc_drawContours_InputArray_excsafe(image, contours, contoursLength, contourIdx, color, thickness, lineType, hierarchy, maxLevel, offset);

	if(isExc)
		handleException();
}


public static  void imgproc_warpPerspective_MisArray( System.IntPtr src ,  System.IntPtr dst , [MarshalAs(UnmanagedType.LPArray)] System.Single[,] m ,  System.Int32 mRow ,  System.Int32 mCol ,  OpenCvSharp.Size dsize ,  System.Int32 flags ,  System.Int32 borderMode ,  OpenCvSharp.Scalar borderValue )
{
	bool isExc = NativeMethodsExc.imgproc_warpPerspective_MisArray_excsafe(src, dst, m, mRow, mCol, dsize, flags, borderMode, borderValue);

	if(isExc)
		handleException();
}


public static  void imgproc_remap( System.IntPtr src ,  System.IntPtr dst ,  System.IntPtr map1 ,  System.IntPtr map2 ,  System.Int32 interpolation ,  System.Int32 borderMode ,  OpenCvSharp.Scalar borderValue )
{
	bool isExc = NativeMethodsExc.imgproc_remap_excsafe(src, dst, map1, map2, interpolation, borderMode, borderValue);

	if(isExc)
		handleException();
}


public static  void imgproc_convertMaps( System.IntPtr map1 ,  System.IntPtr map2 ,  System.IntPtr dstmap1 ,  System.IntPtr dstmap2 ,  System.Int32 dstmap1Type ,  System.Int32 nninterpolation )
{
	bool isExc = NativeMethodsExc.imgproc_convertMaps_excsafe(map1, map2, dstmap1, dstmap2, dstmap1Type, nninterpolation);

	if(isExc)
		handleException();
}


public static  System.IntPtr imgproc_getRotationMatrix2D( OpenCvSharp.Point2f center ,  System.Double angle ,  System.Double scale )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.imgproc_getRotationMatrix2D_excsafe(ref ret, center, angle, scale);

	if(isExc)
		handleException();
	return ret;
}


public static  void imgproc_invertAffineTransform( System.IntPtr m ,  System.IntPtr im )
{
	bool isExc = NativeMethodsExc.imgproc_invertAffineTransform_excsafe(m, im);

	if(isExc)
		handleException();
}


public static  System.IntPtr imgproc_getPerspectiveTransform1( OpenCvSharp.Point2f[] src ,  OpenCvSharp.Point2f[] dst )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.imgproc_getPerspectiveTransform1_excsafe(ref ret, src, dst);

	if(isExc)
		handleException();
	return ret;
}


public static  System.IntPtr imgproc_getPerspectiveTransform2( System.IntPtr src ,  System.IntPtr dst )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.imgproc_getPerspectiveTransform2_excsafe(ref ret, src, dst);

	if(isExc)
		handleException();
	return ret;
}


public static  System.IntPtr imgproc_getAffineTransform1( OpenCvSharp.Point2f[] src ,  OpenCvSharp.Point2f[] dst )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.imgproc_getAffineTransform1_excsafe(ref ret, src, dst);

	if(isExc)
		handleException();
	return ret;
}


public static  System.IntPtr imgproc_getAffineTransform2( System.IntPtr src ,  System.IntPtr dst )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.imgproc_getAffineTransform2_excsafe(ref ret, src, dst);

	if(isExc)
		handleException();
	return ret;
}


public static  void imgproc_getRectSubPix( System.IntPtr image ,  OpenCvSharp.Size patchSize ,  OpenCvSharp.Point2f center ,  System.IntPtr patch ,  System.Int32 patchType )
{
	bool isExc = NativeMethodsExc.imgproc_getRectSubPix_excsafe(image, patchSize, center, patch, patchType);

	if(isExc)
		handleException();
}


public static  void imgproc_logPolar( System.IntPtr src ,  System.IntPtr dst ,  OpenCvSharp.Point2f center ,  System.Double m ,  System.Int32 flags )
{
	bool isExc = NativeMethodsExc.imgproc_logPolar_excsafe(src, dst, center, m, flags);

	if(isExc)
		handleException();
}


public static  void imgproc_linearPolar( System.IntPtr src ,  System.IntPtr dst ,  OpenCvSharp.Point2f center ,  System.Double maxRadius ,  System.Int32 flags )
{
	bool isExc = NativeMethodsExc.imgproc_linearPolar_excsafe(src, dst, center, maxRadius, flags);

	if(isExc)
		handleException();
}


public static  void imgproc_integral1( System.IntPtr src ,  System.IntPtr sum ,  System.Int32 sdepth )
{
	bool isExc = NativeMethodsExc.imgproc_integral1_excsafe(src, sum, sdepth);

	if(isExc)
		handleException();
}


public static  void imgproc_integral2( System.IntPtr src ,  System.IntPtr sum ,  System.IntPtr sqsum ,  System.Int32 sdepth )
{
	bool isExc = NativeMethodsExc.imgproc_integral2_excsafe(src, sum, sqsum, sdepth);

	if(isExc)
		handleException();
}


public static  void imgproc_integral3( System.IntPtr src ,  System.IntPtr sum ,  System.IntPtr sqsum ,  System.IntPtr tilted ,  System.Int32 sdepth )
{
	bool isExc = NativeMethodsExc.imgproc_integral3_excsafe(src, sum, sqsum, tilted, sdepth);

	if(isExc)
		handleException();
}


public static  void imgproc_accumulate( System.IntPtr src ,  System.IntPtr dst ,  System.IntPtr mask )
{
	bool isExc = NativeMethodsExc.imgproc_accumulate_excsafe(src, dst, mask);

	if(isExc)
		handleException();
}


public static  void imgproc_accumulateSquare( System.IntPtr src ,  System.IntPtr dst ,  System.IntPtr mask )
{
	bool isExc = NativeMethodsExc.imgproc_accumulateSquare_excsafe(src, dst, mask);

	if(isExc)
		handleException();
}


public static  void imgproc_accumulateProduct( System.IntPtr src1 ,  System.IntPtr src2 ,  System.IntPtr dst ,  System.IntPtr mask )
{
	bool isExc = NativeMethodsExc.imgproc_accumulateProduct_excsafe(src1, src2, dst, mask);

	if(isExc)
		handleException();
}


public static  void imgproc_accumulateWeighted( System.IntPtr src ,  System.IntPtr dst ,  System.Double alpha ,  System.IntPtr mask )
{
	bool isExc = NativeMethodsExc.imgproc_accumulateWeighted_excsafe(src, dst, alpha, mask);

	if(isExc)
		handleException();
}


public static  System.Double imgproc_PSNR( System.IntPtr src1 ,  System.IntPtr src2 )
{
	System.Double ret = new System.Double();
	bool isExc = NativeMethodsExc.imgproc_PSNR_excsafe(ref ret, src1, src2);

	if(isExc)
		handleException();
	return ret;
}


public static  OpenCvSharp.Point2d imgproc_phaseCorrelate( System.IntPtr src1 ,  System.IntPtr src2 ,  System.IntPtr window )
{
	OpenCvSharp.Point2d ret = new OpenCvSharp.Point2d();
	bool isExc = NativeMethodsExc.imgproc_phaseCorrelate_excsafe(ref ret, src1, src2, window);

	if(isExc)
		handleException();
	return ret;
}


public static  OpenCvSharp.Point2d imgproc_phaseCorrelateRes( System.IntPtr src1 ,  System.IntPtr src2 ,  System.IntPtr window ,  out System.Double response )
{
	OpenCvSharp.Point2d ret = new OpenCvSharp.Point2d();
	bool isExc = NativeMethodsExc.imgproc_phaseCorrelateRes_excsafe(ref ret, src1, src2, window,  out response);

	if(isExc)
		handleException();
	return ret;
}


public static  void imgproc_createHanningWindow( System.IntPtr dst ,  OpenCvSharp.Size winSize ,  System.Int32 type )
{
	bool isExc = NativeMethodsExc.imgproc_createHanningWindow_excsafe(dst, winSize, type);

	if(isExc)
		handleException();
}


public static  System.Double imgproc_threshold( System.IntPtr src ,  System.IntPtr dst ,  System.Double thresh ,  System.Double maxval ,  System.Int32 type )
{
	System.Double ret = new System.Double();
	bool isExc = NativeMethodsExc.imgproc_threshold_excsafe(ref ret, src, dst, thresh, maxval, type);

	if(isExc)
		handleException();
	return ret;
}


public static  void imgproc_adaptiveThreshold( System.IntPtr src ,  System.IntPtr dst ,  System.Double maxValue ,  System.Int32 adaptiveMethod ,  System.Int32 thresholdType ,  System.Int32 blockSize ,  System.Double c )
{
	bool isExc = NativeMethodsExc.imgproc_adaptiveThreshold_excsafe(src, dst, maxValue, adaptiveMethod, thresholdType, blockSize, c);

	if(isExc)
		handleException();
}


public static  void imgproc_pyrDown( System.IntPtr src ,  System.IntPtr dst ,  OpenCvSharp.Size dstsize ,  System.Int32 borderType )
{
	bool isExc = NativeMethodsExc.imgproc_pyrDown_excsafe(src, dst, dstsize, borderType);

	if(isExc)
		handleException();
}


public static  void imgproc_pyrUp( System.IntPtr src ,  System.IntPtr dst ,  OpenCvSharp.Size dstsize ,  System.Int32 borderType )
{
	bool isExc = NativeMethodsExc.imgproc_pyrUp_excsafe(src, dst, dstsize, borderType);

	if(isExc)
		handleException();
}


public static  void imgproc_undistort( System.IntPtr src ,  System.IntPtr dst ,  System.IntPtr cameraMatrix ,  System.IntPtr distCoeffs ,  System.IntPtr newCameraMatrix )
{
	bool isExc = NativeMethodsExc.imgproc_undistort_excsafe(src, dst, cameraMatrix, distCoeffs, newCameraMatrix);

	if(isExc)
		handleException();
}


public static  System.IntPtr imgproc_getGaussianKernel( System.Int32 ksize ,  System.Double sigma ,  System.Int32 ktype )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.imgproc_getGaussianKernel_excsafe(ref ret, ksize, sigma, ktype);

	if(isExc)
		handleException();
	return ret;
}


public static  void imgproc_getDerivKernels( System.IntPtr kx ,  System.IntPtr ky ,  System.Int32 dx ,  System.Int32 dy ,  System.Int32 ksize ,  System.Int32 normalize ,  System.Int32 ktype )
{
	bool isExc = NativeMethodsExc.imgproc_getDerivKernels_excsafe(kx, ky, dx, dy, ksize, normalize, ktype);

	if(isExc)
		handleException();
}


public static  System.IntPtr imgproc_getGaborKernel( OpenCvSharp.Size ksize ,  System.Double sigma ,  System.Double theta ,  System.Double lambd ,  System.Double gamma ,  System.Double psi ,  System.Int32 ktype )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.imgproc_getGaborKernel_excsafe(ref ret, ksize, sigma, theta, lambd, gamma, psi, ktype);

	if(isExc)
		handleException();
	return ret;
}


public static  System.IntPtr imgproc_getStructuringElement( System.Int32 shape ,  OpenCvSharp.Size ksize ,  OpenCvSharp.Point anchor )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.imgproc_getStructuringElement_excsafe(ref ret, shape, ksize, anchor);

	if(isExc)
		handleException();
	return ret;
}


public static  void imgproc_medianBlur( System.IntPtr src ,  System.IntPtr dst ,  System.Int32 ksize )
{
	bool isExc = NativeMethodsExc.imgproc_medianBlur_excsafe(src, dst, ksize);

	if(isExc)
		handleException();
}


public static  void imgproc_GaussianBlur( System.IntPtr src ,  System.IntPtr dst ,  OpenCvSharp.Size ksize ,  System.Double sigmaX ,  System.Double sigmaY ,  System.Int32 borderType )
{
	bool isExc = NativeMethodsExc.imgproc_GaussianBlur_excsafe(src, dst, ksize, sigmaX, sigmaY, borderType);

	if(isExc)
		handleException();
}


public static  void imgproc_bilateralFilter( System.IntPtr src ,  System.IntPtr dst ,  System.Int32 d ,  System.Double sigmaColor ,  System.Double sigmaSpace ,  System.Int32 borderType )
{
	bool isExc = NativeMethodsExc.imgproc_bilateralFilter_excsafe(src, dst, d, sigmaColor, sigmaSpace, borderType);

	if(isExc)
		handleException();
}


public static  void imgproc_boxFilter( System.IntPtr src ,  System.IntPtr dst ,  System.Int32 ddepth ,  OpenCvSharp.Size ksize ,  OpenCvSharp.Point anchor ,  System.Int32 normalize ,  System.Int32 borderType )
{
	bool isExc = NativeMethodsExc.imgproc_boxFilter_excsafe(src, dst, ddepth, ksize, anchor, normalize, borderType);

	if(isExc)
		handleException();
}


public static  void imgproc_blur( System.IntPtr src ,  System.IntPtr dst ,  OpenCvSharp.Size ksize ,  OpenCvSharp.Point anchor ,  System.Int32 borderType )
{
	bool isExc = NativeMethodsExc.imgproc_blur_excsafe(src, dst, ksize, anchor, borderType);

	if(isExc)
		handleException();
}


public static  void imgproc_filter2D( System.IntPtr src ,  System.IntPtr dst ,  System.Int32 ddepth ,  System.IntPtr kernel ,  OpenCvSharp.Point anchor ,  System.Double delta ,  System.Int32 borderType )
{
	bool isExc = NativeMethodsExc.imgproc_filter2D_excsafe(src, dst, ddepth, kernel, anchor, delta, borderType);

	if(isExc)
		handleException();
}


public static  void imgproc_sepFilter2D( System.IntPtr src ,  System.IntPtr dst ,  System.Int32 ddepth ,  System.IntPtr kernelX ,  System.IntPtr kernelY ,  OpenCvSharp.Point anchor ,  System.Double delta ,  System.Int32 borderType )
{
	bool isExc = NativeMethodsExc.imgproc_sepFilter2D_excsafe(src, dst, ddepth, kernelX, kernelY, anchor, delta, borderType);

	if(isExc)
		handleException();
}


public static  void imgproc_Sobel( System.IntPtr src ,  System.IntPtr dst ,  System.Int32 ddepth ,  System.Int32 dx ,  System.Int32 dy ,  System.Int32 ksize ,  System.Double scale ,  System.Double delta ,  System.Int32 borderType )
{
	bool isExc = NativeMethodsExc.imgproc_Sobel_excsafe(src, dst, ddepth, dx, dy, ksize, scale, delta, borderType);

	if(isExc)
		handleException();
}


public static  void imgproc_Scharr( System.IntPtr src ,  System.IntPtr dst ,  System.Int32 ddepth ,  System.Int32 dx ,  System.Int32 dy ,  System.Double scale ,  System.Double delta ,  System.Int32 borderType )
{
	bool isExc = NativeMethodsExc.imgproc_Scharr_excsafe(src, dst, ddepth, dx, dy, scale, delta, borderType);

	if(isExc)
		handleException();
}


public static  void imgproc_Laplacian( System.IntPtr src ,  System.IntPtr dst ,  System.Int32 ddepth ,  System.Int32 ksize ,  System.Double scale ,  System.Double delta ,  System.Int32 borderType )
{
	bool isExc = NativeMethodsExc.imgproc_Laplacian_excsafe(src, dst, ddepth, ksize, scale, delta, borderType);

	if(isExc)
		handleException();
}


public static  void imgproc_Canny( System.IntPtr src ,  System.IntPtr edges ,  System.Double threshold1 ,  System.Double threshold2 ,  System.Int32 apertureSize ,  System.Int32 L2gradient )
{
	bool isExc = NativeMethodsExc.imgproc_Canny_excsafe(src, edges, threshold1, threshold2, apertureSize, L2gradient);

	if(isExc)
		handleException();
}


public static  void imgproc_cornerEigenValsAndVecs( System.IntPtr src ,  System.IntPtr dst ,  System.Int32 blockSize ,  System.Int32 ksize ,  System.Int32 borderType )
{
	bool isExc = NativeMethodsExc.imgproc_cornerEigenValsAndVecs_excsafe(src, dst, blockSize, ksize, borderType);

	if(isExc)
		handleException();
}


public static  void imgproc_preCornerDetect( System.IntPtr src ,  System.IntPtr dst ,  System.Int32 ksize ,  System.Int32 borderType )
{
	bool isExc = NativeMethodsExc.imgproc_preCornerDetect_excsafe(src, dst, ksize, borderType);

	if(isExc)
		handleException();
}


public static  void imgproc_cornerSubPix( System.IntPtr image ,  System.IntPtr corners ,  OpenCvSharp.Size winSize ,  OpenCvSharp.Size zeroZone ,  OpenCvSharp.TermCriteria criteria )
{
	bool isExc = NativeMethodsExc.imgproc_cornerSubPix_excsafe(image, corners, winSize, zeroZone, criteria);

	if(isExc)
		handleException();
}


public static  void imgproc_goodFeaturesToTrack( System.IntPtr src ,  System.IntPtr corners ,  System.Int32 maxCorners ,  System.Double qualityLevel ,  System.Double minDistance ,  System.IntPtr mask ,  System.Int32 blockSize ,  System.Int32 useHarrisDetector ,  System.Double k )
{
	bool isExc = NativeMethodsExc.imgproc_goodFeaturesToTrack_excsafe(src, corners, maxCorners, qualityLevel, minDistance, mask, blockSize, useHarrisDetector, k);

	if(isExc)
		handleException();
}


public static  void imgproc_HoughLines( System.IntPtr src ,  System.IntPtr lines ,  System.Double rho ,  System.Double theta ,  System.Int32 threshold ,  System.Double srn ,  System.Double stn )
{
	bool isExc = NativeMethodsExc.imgproc_HoughLines_excsafe(src, lines, rho, theta, threshold, srn, stn);

	if(isExc)
		handleException();
}


public static  void imgproc_HoughLinesP( System.IntPtr src ,  System.IntPtr lines ,  System.Double rho ,  System.Double theta ,  System.Int32 threshold ,  System.Double minLineLength ,  System.Double maxLineG )
{
	bool isExc = NativeMethodsExc.imgproc_HoughLinesP_excsafe(src, lines, rho, theta, threshold, minLineLength, maxLineG);

	if(isExc)
		handleException();
}


public static  void imgproc_HoughCircles( System.IntPtr src ,  System.IntPtr circles ,  System.Int32 method ,  System.Double dp ,  System.Double minDist ,  System.Double param1 ,  System.Double param2 ,  System.Int32 minRadius ,  System.Int32 maxRadius )
{
	bool isExc = NativeMethodsExc.imgproc_HoughCircles_excsafe(src, circles, method, dp, minDist, param1, param2, minRadius, maxRadius);

	if(isExc)
		handleException();
}


public static  void imgproc_erode( System.IntPtr src ,  System.IntPtr dst ,  System.IntPtr kernel ,  OpenCvSharp.Point anchor ,  System.Int32 iterations ,  System.Int32 borderType ,  OpenCvSharp.Scalar borderValue )
{
	bool isExc = NativeMethodsExc.imgproc_erode_excsafe(src, dst, kernel, anchor, iterations, borderType, borderValue);

	if(isExc)
		handleException();
}


public static  void imgproc_dilate( System.IntPtr src ,  System.IntPtr dst ,  System.IntPtr kernel ,  OpenCvSharp.Point anchor ,  System.Int32 iterations ,  System.Int32 borderType ,  OpenCvSharp.Scalar borderValue )
{
	bool isExc = NativeMethodsExc.imgproc_dilate_excsafe(src, dst, kernel, anchor, iterations, borderType, borderValue);

	if(isExc)
		handleException();
}


public static  void imgproc_morphologyEx( System.IntPtr src ,  System.IntPtr dst ,  System.Int32 op ,  System.IntPtr kernel ,  OpenCvSharp.Point anchor ,  System.Int32 iterations ,  System.Int32 borderType ,  OpenCvSharp.Scalar borderValue )
{
	bool isExc = NativeMethodsExc.imgproc_morphologyEx_excsafe(src, dst, op, kernel, anchor, iterations, borderType, borderValue);

	if(isExc)
		handleException();
}


public static  void imgproc_resize( System.IntPtr src ,  System.IntPtr dst ,  OpenCvSharp.Size dsize ,  System.Double fx ,  System.Double fy ,  System.Int32 interpolation )
{
	bool isExc = NativeMethodsExc.imgproc_resize_excsafe(src, dst, dsize, fx, fy, interpolation);

	if(isExc)
		handleException();
}


public static  void imgproc_warpAffine( System.IntPtr src ,  System.IntPtr dst ,  System.IntPtr m ,  OpenCvSharp.Size dsize ,  System.Int32 flags ,  System.Int32 borderMode ,  OpenCvSharp.Scalar borderValue )
{
	bool isExc = NativeMethodsExc.imgproc_warpAffine_excsafe(src, dst, m, dsize, flags, borderMode, borderValue);

	if(isExc)
		handleException();
}


public static  void imgproc_warpPerspective_MisInputArray( System.IntPtr src ,  System.IntPtr dst ,  System.IntPtr m ,  OpenCvSharp.Size dsize ,  System.Int32 flags ,  System.Int32 borderMode ,  OpenCvSharp.Scalar borderValue )
{
	bool isExc = NativeMethodsExc.imgproc_warpPerspective_MisInputArray_excsafe(src, dst, m, dsize, flags, borderMode, borderValue);

	if(isExc)
		handleException();
}


public static  void features2d_MSER_setMaxArea( System.IntPtr obj ,  System.Int32 maxArea )
{
	bool isExc = NativeMethodsExc.features2d_MSER_setMaxArea_excsafe(obj, maxArea);

	if(isExc)
		handleException();
}


public static  System.Int32 features2d_MSER_getMaxArea( System.IntPtr obj )
{
	System.Int32 ret = new System.Int32();
	bool isExc = NativeMethodsExc.features2d_MSER_getMaxArea_excsafe(ref ret, obj);

	if(isExc)
		handleException();
	return ret;
}


public static  void features2d_MSER_setPass2Only( System.IntPtr obj ,  System.Int32 f )
{
	bool isExc = NativeMethodsExc.features2d_MSER_setPass2Only_excsafe(obj, f);

	if(isExc)
		handleException();
}


public static  System.Int32 features2d_MSER_getPass2Only( System.IntPtr obj )
{
	System.Int32 ret = new System.Int32();
	bool isExc = NativeMethodsExc.features2d_MSER_getPass2Only_excsafe(ref ret, obj);

	if(isExc)
		handleException();
	return ret;
}


public static  System.IntPtr features2d_ORB_create( System.Int32 nFeatures ,  System.Single scaleFactor ,  System.Int32 nlevels ,  System.Int32 edgeThreshold ,  System.Int32 firstLevel ,  System.Int32 wtaK ,  System.Int32 scoreType ,  System.Int32 patchSize )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.features2d_ORB_create_excsafe(ref ret, nFeatures, scaleFactor, nlevels, edgeThreshold, firstLevel, wtaK, scoreType, patchSize);

	if(isExc)
		handleException();
	return ret;
}


public static  void features2d_Ptr_ORB_delete( System.IntPtr ptr )
{
	bool isExc = NativeMethodsExc.features2d_Ptr_ORB_delete_excsafe(ptr);

	if(isExc)
		handleException();
}


public static  System.IntPtr features2d_Ptr_ORB_get( System.IntPtr ptr )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.features2d_Ptr_ORB_get_excsafe(ref ret, ptr);

	if(isExc)
		handleException();
	return ret;
}


public static  void features2d_ORB_setMaxFeatures( System.IntPtr obj ,  System.Int32 val )
{
	bool isExc = NativeMethodsExc.features2d_ORB_setMaxFeatures_excsafe(obj, val);

	if(isExc)
		handleException();
}


public static  System.Int32 features2d_ORB_getMaxFeatures( System.IntPtr obj )
{
	System.Int32 ret = new System.Int32();
	bool isExc = NativeMethodsExc.features2d_ORB_getMaxFeatures_excsafe(ref ret, obj);

	if(isExc)
		handleException();
	return ret;
}


public static  void features2d_ORB_setScaleFactor( System.IntPtr obj ,  System.Double val )
{
	bool isExc = NativeMethodsExc.features2d_ORB_setScaleFactor_excsafe(obj, val);

	if(isExc)
		handleException();
}


public static  System.Double features2d_ORB_getScaleFactor( System.IntPtr obj )
{
	System.Double ret = new System.Double();
	bool isExc = NativeMethodsExc.features2d_ORB_getScaleFactor_excsafe(ref ret, obj);

	if(isExc)
		handleException();
	return ret;
}


public static  void features2d_ORB_setNLevels( System.IntPtr obj ,  System.Int32 val )
{
	bool isExc = NativeMethodsExc.features2d_ORB_setNLevels_excsafe(obj, val);

	if(isExc)
		handleException();
}


public static  System.Int32 features2d_ORB_getNLevels( System.IntPtr obj )
{
	System.Int32 ret = new System.Int32();
	bool isExc = NativeMethodsExc.features2d_ORB_getNLevels_excsafe(ref ret, obj);

	if(isExc)
		handleException();
	return ret;
}


public static  void features2d_ORB_setEdgeThreshold( System.IntPtr obj ,  System.Int32 val )
{
	bool isExc = NativeMethodsExc.features2d_ORB_setEdgeThreshold_excsafe(obj, val);

	if(isExc)
		handleException();
}


public static  System.Int32 features2d_ORB_getEdgeThreshold( System.IntPtr obj )
{
	System.Int32 ret = new System.Int32();
	bool isExc = NativeMethodsExc.features2d_ORB_getEdgeThreshold_excsafe(ref ret, obj);

	if(isExc)
		handleException();
	return ret;
}


public static  void features2d_ORB_setFirstLevel( System.IntPtr obj ,  System.Int32 val )
{
	bool isExc = NativeMethodsExc.features2d_ORB_setFirstLevel_excsafe(obj, val);

	if(isExc)
		handleException();
}


public static  System.Int32 features2d_ORB_getFirstLevel( System.IntPtr obj )
{
	System.Int32 ret = new System.Int32();
	bool isExc = NativeMethodsExc.features2d_ORB_getFirstLevel_excsafe(ref ret, obj);

	if(isExc)
		handleException();
	return ret;
}


public static  void features2d_ORB_setWTA_K( System.IntPtr obj ,  System.Int32 val )
{
	bool isExc = NativeMethodsExc.features2d_ORB_setWTA_K_excsafe(obj, val);

	if(isExc)
		handleException();
}


public static  System.Int32 features2d_ORB_getWTA_K( System.IntPtr obj )
{
	System.Int32 ret = new System.Int32();
	bool isExc = NativeMethodsExc.features2d_ORB_getWTA_K_excsafe(ref ret, obj);

	if(isExc)
		handleException();
	return ret;
}


public static  void features2d_ORB_setScoreType( System.IntPtr obj ,  System.Int32 val )
{
	bool isExc = NativeMethodsExc.features2d_ORB_setScoreType_excsafe(obj, val);

	if(isExc)
		handleException();
}


public static  System.Int32 features2d_ORB_getScoreType( System.IntPtr obj )
{
	System.Int32 ret = new System.Int32();
	bool isExc = NativeMethodsExc.features2d_ORB_getScoreType_excsafe(ref ret, obj);

	if(isExc)
		handleException();
	return ret;
}


public static  void features2d_ORB_setPatchSize( System.IntPtr obj ,  System.Int32 val )
{
	bool isExc = NativeMethodsExc.features2d_ORB_setPatchSize_excsafe(obj, val);

	if(isExc)
		handleException();
}


public static  System.Int32 features2d_ORB_getPatchSize( System.IntPtr obj )
{
	System.Int32 ret = new System.Int32();
	bool isExc = NativeMethodsExc.features2d_ORB_getPatchSize_excsafe(ref ret, obj);

	if(isExc)
		handleException();
	return ret;
}


public static  void features2d_ORB_setFastThreshold( System.IntPtr obj ,  System.Int32 val )
{
	bool isExc = NativeMethodsExc.features2d_ORB_setFastThreshold_excsafe(obj, val);

	if(isExc)
		handleException();
}


public static  System.Int32 features2d_ORB_getFastThreshold( System.IntPtr obj )
{
	System.Int32 ret = new System.Int32();
	bool isExc = NativeMethodsExc.features2d_ORB_getFastThreshold_excsafe(ref ret, obj);

	if(isExc)
		handleException();
	return ret;
}


public static  System.IntPtr features2d_SimpleBlobDetector_create( ref OpenCvSharp.SimpleBlobDetector.WParams parameters )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.features2d_SimpleBlobDetector_create_excsafe(ref ret,  ref parameters);

	if(isExc)
		handleException();
	return ret;
}


public static  System.IntPtr features2d_Ptr_SimpleBlobDetector_get( System.IntPtr ptr )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.features2d_Ptr_SimpleBlobDetector_get_excsafe(ref ret, ptr);

	if(isExc)
		handleException();
	return ret;
}


public static  void features2d_Ptr_SimpleBlobDetector_delete( System.IntPtr ptr )
{
	bool isExc = NativeMethodsExc.features2d_Ptr_SimpleBlobDetector_delete_excsafe(ptr);

	if(isExc)
		handleException();
}


public static  void features2d_Ptr_KAZE_delete( System.IntPtr ptr )
{
	bool isExc = NativeMethodsExc.features2d_Ptr_KAZE_delete_excsafe(ptr);

	if(isExc)
		handleException();
}


public static  System.IntPtr features2d_Ptr_KAZE_get( System.IntPtr ptr )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.features2d_Ptr_KAZE_get_excsafe(ref ret, ptr);

	if(isExc)
		handleException();
	return ret;
}


public static  void features2d_KAZE_setDiffusivity( System.IntPtr obj ,  System.Int32 val )
{
	bool isExc = NativeMethodsExc.features2d_KAZE_setDiffusivity_excsafe(obj, val);

	if(isExc)
		handleException();
}


public static  System.Int32 features2d_KAZE_getDiffusivity( System.IntPtr obj )
{
	System.Int32 ret = new System.Int32();
	bool isExc = NativeMethodsExc.features2d_KAZE_getDiffusivity_excsafe(ref ret, obj);

	if(isExc)
		handleException();
	return ret;
}


public static  void features2d_KAZE_setExtended( System.IntPtr obj ,  System.Boolean val )
{
	bool isExc = NativeMethodsExc.features2d_KAZE_setExtended_excsafe(obj, val);

	if(isExc)
		handleException();
}


public static  System.Boolean features2d_KAZE_getExtended( System.IntPtr obj )
{
	System.Boolean ret = new System.Boolean();
	bool isExc = NativeMethodsExc.features2d_KAZE_getExtended_excsafe(ref ret, obj);

	if(isExc)
		handleException();
	return ret;
}


public static  void features2d_KAZE_setNOctaveLayers( System.IntPtr obj ,  System.Int32 val )
{
	bool isExc = NativeMethodsExc.features2d_KAZE_setNOctaveLayers_excsafe(obj, val);

	if(isExc)
		handleException();
}


public static  System.Int32 features2d_KAZE_getNOctaveLayers( System.IntPtr obj )
{
	System.Int32 ret = new System.Int32();
	bool isExc = NativeMethodsExc.features2d_KAZE_getNOctaveLayers_excsafe(ref ret, obj);

	if(isExc)
		handleException();
	return ret;
}


public static  void features2d_KAZE_setNOctaves( System.IntPtr obj ,  System.Int32 val )
{
	bool isExc = NativeMethodsExc.features2d_KAZE_setNOctaves_excsafe(obj, val);

	if(isExc)
		handleException();
}


public static  System.Int32 features2d_KAZE_getNOctaves( System.IntPtr obj )
{
	System.Int32 ret = new System.Int32();
	bool isExc = NativeMethodsExc.features2d_KAZE_getNOctaves_excsafe(ref ret, obj);

	if(isExc)
		handleException();
	return ret;
}


public static  void features2d_KAZE_setThreshold( System.IntPtr obj ,  System.Double val )
{
	bool isExc = NativeMethodsExc.features2d_KAZE_setThreshold_excsafe(obj, val);

	if(isExc)
		handleException();
}


public static  System.Double features2d_KAZE_getThreshold( System.IntPtr obj )
{
	System.Double ret = new System.Double();
	bool isExc = NativeMethodsExc.features2d_KAZE_getThreshold_excsafe(ref ret, obj);

	if(isExc)
		handleException();
	return ret;
}


public static  void features2d_KAZE_setUpright( System.IntPtr obj ,  System.Boolean val )
{
	bool isExc = NativeMethodsExc.features2d_KAZE_setUpright_excsafe(obj, val);

	if(isExc)
		handleException();
}


public static  System.Boolean features2d_KAZE_getUpright( System.IntPtr obj )
{
	System.Boolean ret = new System.Boolean();
	bool isExc = NativeMethodsExc.features2d_KAZE_getUpright_excsafe(ref ret, obj);

	if(isExc)
		handleException();
	return ret;
}


public static  void features2d_KeyPointsFilter_runByImageBorder( System.IntPtr keypoints ,  OpenCvSharp.Size imageSize ,  System.Int32 borderSize )
{
	bool isExc = NativeMethodsExc.features2d_KeyPointsFilter_runByImageBorder_excsafe(keypoints, imageSize, borderSize);

	if(isExc)
		handleException();
}


public static  void features2d_KeyPointsFilter_runByKeypointSize( System.IntPtr keypoints ,  System.Single minSize ,  System.Single maxSize )
{
	bool isExc = NativeMethodsExc.features2d_KeyPointsFilter_runByKeypointSize_excsafe(keypoints, minSize, maxSize);

	if(isExc)
		handleException();
}


public static  void features2d_KeyPointsFilter_runByPixelsMask( System.IntPtr keypoints ,  System.IntPtr mask )
{
	bool isExc = NativeMethodsExc.features2d_KeyPointsFilter_runByPixelsMask_excsafe(keypoints, mask);

	if(isExc)
		handleException();
}


public static  void features2d_KeyPointsFilter_removeDuplicated( System.IntPtr keypoints )
{
	bool isExc = NativeMethodsExc.features2d_KeyPointsFilter_removeDuplicated_excsafe(keypoints);

	if(isExc)
		handleException();
}


public static  void features2d_KeyPointsFilter_retainBest( System.IntPtr keypoints ,  System.Int32 npoints )
{
	bool isExc = NativeMethodsExc.features2d_KeyPointsFilter_retainBest_excsafe(keypoints, npoints);

	if(isExc)
		handleException();
}


public static  System.IntPtr features2d_MSER_create( System.Int32 delta ,  System.Int32 minArea ,  System.Int32 maxArea ,  System.Double maxVariation ,  System.Double minDiversity ,  System.Int32 maxEvolution ,  System.Double areaThreshold ,  System.Double minMargin ,  System.Int32 edgeBlurSize )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.features2d_MSER_create_excsafe(ref ret, delta, minArea, maxArea, maxVariation, minDiversity, maxEvolution, areaThreshold, minMargin, edgeBlurSize);

	if(isExc)
		handleException();
	return ret;
}


public static  void features2d_Ptr_MSER_delete( System.IntPtr ptr )
{
	bool isExc = NativeMethodsExc.features2d_Ptr_MSER_delete_excsafe(ptr);

	if(isExc)
		handleException();
}


public static  void features2d_MSER_detect( System.IntPtr obj ,  System.IntPtr image ,  out System.IntPtr msers ,  System.IntPtr mask )
{
	bool isExc = NativeMethodsExc.features2d_MSER_detect_excsafe(obj, image,  out msers, mask);

	if(isExc)
		handleException();
}


public static  System.IntPtr features2d_Ptr_MSER_get( System.IntPtr ptr )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.features2d_Ptr_MSER_get_excsafe(ref ret, ptr);

	if(isExc)
		handleException();
	return ret;
}


public static  void features2d_MSER_detectRegions( System.IntPtr obj ,  System.IntPtr image ,  System.IntPtr msers ,  System.IntPtr bboxes )
{
	bool isExc = NativeMethodsExc.features2d_MSER_detectRegions_excsafe(obj, image, msers, bboxes);

	if(isExc)
		handleException();
}


public static  void features2d_MSER_setDelta( System.IntPtr obj ,  System.Int32 delta )
{
	bool isExc = NativeMethodsExc.features2d_MSER_setDelta_excsafe(obj, delta);

	if(isExc)
		handleException();
}


public static  System.Int32 features2d_MSER_getDelta( System.IntPtr obj )
{
	System.Int32 ret = new System.Int32();
	bool isExc = NativeMethodsExc.features2d_MSER_getDelta_excsafe(ref ret, obj);

	if(isExc)
		handleException();
	return ret;
}


public static  void features2d_MSER_setMinArea( System.IntPtr obj ,  System.Int32 minArea )
{
	bool isExc = NativeMethodsExc.features2d_MSER_setMinArea_excsafe(obj, minArea);

	if(isExc)
		handleException();
}


public static  System.Int32 features2d_MSER_getMinArea( System.IntPtr obj )
{
	System.Int32 ret = new System.Int32();
	bool isExc = NativeMethodsExc.features2d_MSER_getMinArea_excsafe(ref ret, obj);

	if(isExc)
		handleException();
	return ret;
}


public static  void features2d_Ptr_Feature2D_delete( System.IntPtr ptr )
{
	bool isExc = NativeMethodsExc.features2d_Ptr_Feature2D_delete_excsafe(ptr);

	if(isExc)
		handleException();
}


public static  void features2d_Feature2D_detect_Mat1( System.IntPtr detector ,  System.IntPtr image ,  System.IntPtr keypoints ,  System.IntPtr mask )
{
	bool isExc = NativeMethodsExc.features2d_Feature2D_detect_Mat1_excsafe(detector, image, keypoints, mask);

	if(isExc)
		handleException();
}


public static  void features2d_Feature2D_detect_Mat2( System.IntPtr detector ,  System.IntPtr[] images ,  System.Int32 imageLength ,  System.IntPtr keypoints ,  System.IntPtr[] mask )
{
	bool isExc = NativeMethodsExc.features2d_Feature2D_detect_Mat2_excsafe(detector, images, imageLength, keypoints, mask);

	if(isExc)
		handleException();
}


public static  void features2d_Feature2D_detect_InputArray( System.IntPtr detector ,  System.IntPtr image ,  System.IntPtr keypoints ,  System.IntPtr mask )
{
	bool isExc = NativeMethodsExc.features2d_Feature2D_detect_InputArray_excsafe(detector, image, keypoints, mask);

	if(isExc)
		handleException();
}


public static  void features2d_Feature2D_compute1( System.IntPtr obj ,  System.IntPtr image ,  System.IntPtr keypoints ,  System.IntPtr descriptors )
{
	bool isExc = NativeMethodsExc.features2d_Feature2D_compute1_excsafe(obj, image, keypoints, descriptors);

	if(isExc)
		handleException();
}


public static  void features2d_Feature2D_compute2( System.IntPtr detector ,  System.IntPtr[] images ,  System.Int32 imageLength ,  System.IntPtr keypoints ,  System.IntPtr[] descriptors ,  System.Int32 descriptorsLength )
{
	bool isExc = NativeMethodsExc.features2d_Feature2D_compute2_excsafe(detector, images, imageLength, keypoints, descriptors, descriptorsLength);

	if(isExc)
		handleException();
}


public static  void features2d_Feature2D_detectAndCompute( System.IntPtr detector ,  System.IntPtr image ,  System.IntPtr mask ,  System.IntPtr keypoints ,  System.IntPtr descriptors ,  System.Int32 useProvidedKeypoints )
{
	bool isExc = NativeMethodsExc.features2d_Feature2D_detectAndCompute_excsafe(detector, image, mask, keypoints, descriptors, useProvidedKeypoints);

	if(isExc)
		handleException();
}


public static  System.Int32 features2d_Feature2D_descriptorSize( System.IntPtr obj )
{
	System.Int32 ret = new System.Int32();
	bool isExc = NativeMethodsExc.features2d_Feature2D_descriptorSize_excsafe(ref ret, obj);

	if(isExc)
		handleException();
	return ret;
}


public static  System.Int32 features2d_Feature2D_descriptorType( System.IntPtr obj )
{
	System.Int32 ret = new System.Int32();
	bool isExc = NativeMethodsExc.features2d_Feature2D_descriptorType_excsafe(ref ret, obj);

	if(isExc)
		handleException();
	return ret;
}


public static  System.Int32 features2d_Feature2D_defaultNorm( System.IntPtr obj )
{
	System.Int32 ret = new System.Int32();
	bool isExc = NativeMethodsExc.features2d_Feature2D_defaultNorm_excsafe(ref ret, obj);

	if(isExc)
		handleException();
	return ret;
}


public static  System.Int32 features2d_Feature2D_empty( System.IntPtr obj )
{
	System.Int32 ret = new System.Int32();
	bool isExc = NativeMethodsExc.features2d_Feature2D_empty_excsafe(ref ret, obj);

	if(isExc)
		handleException();
	return ret;
}


public static  System.IntPtr features2d_GFTTDetector_create( System.Int32 maxCorners ,  System.Double qualityLevel ,  System.Double minDistance ,  System.Int32 blockSize ,  System.Int32 useHarrisDetector ,  System.Double k )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.features2d_GFTTDetector_create_excsafe(ref ret, maxCorners, qualityLevel, minDistance, blockSize, useHarrisDetector, k);

	if(isExc)
		handleException();
	return ret;
}


public static  void features2d_GFTTDetector_delete( System.IntPtr obj )
{
	bool isExc = NativeMethodsExc.features2d_GFTTDetector_delete_excsafe(obj);

	if(isExc)
		handleException();
}


public static  System.IntPtr features2d_Ptr_GFTTDetector_get( System.IntPtr ptr )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.features2d_Ptr_GFTTDetector_get_excsafe(ref ret, ptr);

	if(isExc)
		handleException();
	return ret;
}


public static  void features2d_Ptr_GFTTDetector_delete( System.IntPtr ptr )
{
	bool isExc = NativeMethodsExc.features2d_Ptr_GFTTDetector_delete_excsafe(ptr);

	if(isExc)
		handleException();
}


public static  void features2d_GFTTDetector_setMaxFeatures( System.IntPtr obj ,  System.Int32 maxFeatures )
{
	bool isExc = NativeMethodsExc.features2d_GFTTDetector_setMaxFeatures_excsafe(obj, maxFeatures);

	if(isExc)
		handleException();
}


public static  System.Int32 features2d_GFTTDetector_getMaxFeatures( System.IntPtr obj )
{
	System.Int32 ret = new System.Int32();
	bool isExc = NativeMethodsExc.features2d_GFTTDetector_getMaxFeatures_excsafe(ref ret, obj);

	if(isExc)
		handleException();
	return ret;
}


public static  void features2d_GFTTDetector_setQualityLevel( System.IntPtr obj ,  System.Double qlevel )
{
	bool isExc = NativeMethodsExc.features2d_GFTTDetector_setQualityLevel_excsafe(obj, qlevel);

	if(isExc)
		handleException();
}


public static  System.Double features2d_GFTTDetector_getQualityLevel( System.IntPtr obj )
{
	System.Double ret = new System.Double();
	bool isExc = NativeMethodsExc.features2d_GFTTDetector_getQualityLevel_excsafe(ref ret, obj);

	if(isExc)
		handleException();
	return ret;
}


public static  void features2d_GFTTDetector_setMinDistance( System.IntPtr obj ,  System.Double minDistance )
{
	bool isExc = NativeMethodsExc.features2d_GFTTDetector_setMinDistance_excsafe(obj, minDistance);

	if(isExc)
		handleException();
}


public static  System.Double features2d_GFTTDetector_getMinDistance( System.IntPtr obj )
{
	System.Double ret = new System.Double();
	bool isExc = NativeMethodsExc.features2d_GFTTDetector_getMinDistance_excsafe(ref ret, obj);

	if(isExc)
		handleException();
	return ret;
}


public static  void features2d_GFTTDetector_setBlockSize( System.IntPtr obj ,  System.Int32 blockSize )
{
	bool isExc = NativeMethodsExc.features2d_GFTTDetector_setBlockSize_excsafe(obj, blockSize);

	if(isExc)
		handleException();
}


public static  System.Int32 features2d_GFTTDetector_getBlockSize( System.IntPtr obj )
{
	System.Int32 ret = new System.Int32();
	bool isExc = NativeMethodsExc.features2d_GFTTDetector_getBlockSize_excsafe(ref ret, obj);

	if(isExc)
		handleException();
	return ret;
}


public static  void features2d_GFTTDetector_setHarrisDetector( System.IntPtr obj ,  System.Int32 val )
{
	bool isExc = NativeMethodsExc.features2d_GFTTDetector_setHarrisDetector_excsafe(obj, val);

	if(isExc)
		handleException();
}


public static  System.Int32 features2d_GFTTDetector_getHarrisDetector( System.IntPtr obj )
{
	System.Int32 ret = new System.Int32();
	bool isExc = NativeMethodsExc.features2d_GFTTDetector_getHarrisDetector_excsafe(ref ret, obj);

	if(isExc)
		handleException();
	return ret;
}


public static  void features2d_GFTTDetector_setK( System.IntPtr obj ,  System.Double k )
{
	bool isExc = NativeMethodsExc.features2d_GFTTDetector_setK_excsafe(obj, k);

	if(isExc)
		handleException();
}


public static  System.Double features2d_GFTTDetector_getK( System.IntPtr obj )
{
	System.Double ret = new System.Double();
	bool isExc = NativeMethodsExc.features2d_GFTTDetector_getK_excsafe(ref ret, obj);

	if(isExc)
		handleException();
	return ret;
}


public static  System.IntPtr features2d_KAZE_create( System.Boolean extended ,  System.Boolean upright ,  System.Single threshold ,  System.Int32 nOctaves ,  System.Int32 nOctaveLayers ,  System.Int32 diffusivity )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.features2d_KAZE_create_excsafe(ref ret, extended, upright, threshold, nOctaves, nOctaveLayers, diffusivity);

	if(isExc)
		handleException();
	return ret;
}


public static  System.IntPtr features2d_DescriptorMatcher_create([MarshalAs(UnmanagedType.LPStr)] System.String descriptorMatcherType )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.features2d_DescriptorMatcher_create_excsafe(ref ret, descriptorMatcherType);

	if(isExc)
		handleException();
	return ret;
}


public static  System.IntPtr features2d_Ptr_DescriptorMatcher_get( System.IntPtr ptr )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.features2d_Ptr_DescriptorMatcher_get_excsafe(ref ret, ptr);

	if(isExc)
		handleException();
	return ret;
}


public static  void features2d_Ptr_DescriptorMatcher_delete( System.IntPtr ptr )
{
	bool isExc = NativeMethodsExc.features2d_Ptr_DescriptorMatcher_delete_excsafe(ptr);

	if(isExc)
		handleException();
}


public static  System.IntPtr features2d_BFMatcher_new( System.Int32 normType ,  System.Int32 crossCheck )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.features2d_BFMatcher_new_excsafe(ref ret, normType, crossCheck);

	if(isExc)
		handleException();
	return ret;
}


public static  void features2d_BFMatcher_delete( System.IntPtr obj )
{
	bool isExc = NativeMethodsExc.features2d_BFMatcher_delete_excsafe(obj);

	if(isExc)
		handleException();
}


public static  System.Int32 features2d_BFMatcher_isMaskSupported( System.IntPtr obj )
{
	System.Int32 ret = new System.Int32();
	bool isExc = NativeMethodsExc.features2d_BFMatcher_isMaskSupported_excsafe(ref ret, obj);

	if(isExc)
		handleException();
	return ret;
}


public static  System.IntPtr features2d_Ptr_BFMatcher_get( System.IntPtr ptr )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.features2d_Ptr_BFMatcher_get_excsafe(ref ret, ptr);

	if(isExc)
		handleException();
	return ret;
}


public static  void features2d_Ptr_BFMatcher_delete( System.IntPtr ptr )
{
	bool isExc = NativeMethodsExc.features2d_Ptr_BFMatcher_delete_excsafe(ptr);

	if(isExc)
		handleException();
}


public static  System.IntPtr features2d_FlannBasedMatcher_new( System.IntPtr indexParams ,  System.IntPtr searchParams )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.features2d_FlannBasedMatcher_new_excsafe(ref ret, indexParams, searchParams);

	if(isExc)
		handleException();
	return ret;
}


public static  void features2d_FlannBasedMatcher_delete( System.IntPtr obj )
{
	bool isExc = NativeMethodsExc.features2d_FlannBasedMatcher_delete_excsafe(obj);

	if(isExc)
		handleException();
}


public static  void features2d_FlannBasedMatcher_add( System.IntPtr obj ,  System.IntPtr[] descriptors ,  System.Int32 descriptorsSize )
{
	bool isExc = NativeMethodsExc.features2d_FlannBasedMatcher_add_excsafe(obj, descriptors, descriptorsSize);

	if(isExc)
		handleException();
}


public static  void features2d_FlannBasedMatcher_clear( System.IntPtr obj )
{
	bool isExc = NativeMethodsExc.features2d_FlannBasedMatcher_clear_excsafe(obj);

	if(isExc)
		handleException();
}


public static  void features2d_FlannBasedMatcher_train( System.IntPtr obj )
{
	bool isExc = NativeMethodsExc.features2d_FlannBasedMatcher_train_excsafe(obj);

	if(isExc)
		handleException();
}


public static  System.Int32 features2d_FlannBasedMatcher_isMaskSupported( System.IntPtr obj )
{
	System.Int32 ret = new System.Int32();
	bool isExc = NativeMethodsExc.features2d_FlannBasedMatcher_isMaskSupported_excsafe(ref ret, obj);

	if(isExc)
		handleException();
	return ret;
}


public static  System.IntPtr features2d_Ptr_FlannBasedMatcher_get( System.IntPtr ptr )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.features2d_Ptr_FlannBasedMatcher_get_excsafe(ref ret, ptr);

	if(isExc)
		handleException();
	return ret;
}


public static  void features2d_Ptr_FlannBasedMatcher_delete( System.IntPtr ptr )
{
	bool isExc = NativeMethodsExc.features2d_Ptr_FlannBasedMatcher_delete_excsafe(ptr);

	if(isExc)
		handleException();
}


public static  void features2d_FAST1( System.IntPtr image ,  System.IntPtr keypoints ,  System.Int32 threshold ,  System.Int32 nonmaxSupression )
{
	bool isExc = NativeMethodsExc.features2d_FAST1_excsafe(image, keypoints, threshold, nonmaxSupression);

	if(isExc)
		handleException();
}


public static  void features2d_FAST2( System.IntPtr image ,  System.IntPtr keypoints ,  System.Int32 threshold ,  System.Int32 nonmaxSupression ,  System.Int32 type )
{
	bool isExc = NativeMethodsExc.features2d_FAST2_excsafe(image, keypoints, threshold, nonmaxSupression, type);

	if(isExc)
		handleException();
}


public static  System.IntPtr features2d_FastFeatureDetector_create( System.Int32 threshold ,  System.Int32 nonmaxSuppression )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.features2d_FastFeatureDetector_create_excsafe(ref ret, threshold, nonmaxSuppression);

	if(isExc)
		handleException();
	return ret;
}


public static  void features2d_Ptr_FastFeatureDetector_delete( System.IntPtr ptr )
{
	bool isExc = NativeMethodsExc.features2d_Ptr_FastFeatureDetector_delete_excsafe(ptr);

	if(isExc)
		handleException();
}


public static  System.IntPtr features2d_Ptr_FastFeatureDetector_get( System.IntPtr ptr )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.features2d_Ptr_FastFeatureDetector_get_excsafe(ref ret, ptr);

	if(isExc)
		handleException();
	return ret;
}


public static  void features2d_FastFeatureDetector_setThreshold( System.IntPtr obj ,  System.Int32 threshold )
{
	bool isExc = NativeMethodsExc.features2d_FastFeatureDetector_setThreshold_excsafe(obj, threshold);

	if(isExc)
		handleException();
}


public static  System.Int32 features2d_FastFeatureDetector_getThreshold( System.IntPtr obj )
{
	System.Int32 ret = new System.Int32();
	bool isExc = NativeMethodsExc.features2d_FastFeatureDetector_getThreshold_excsafe(ref ret, obj);

	if(isExc)
		handleException();
	return ret;
}


public static  void features2d_FastFeatureDetector_setNonmaxSuppression( System.IntPtr obj ,  System.Int32 f )
{
	bool isExc = NativeMethodsExc.features2d_FastFeatureDetector_setNonmaxSuppression_excsafe(obj, f);

	if(isExc)
		handleException();
}


public static  System.Int32 features2d_FastFeatureDetector_getNonmaxSuppression( System.IntPtr obj )
{
	System.Int32 ret = new System.Int32();
	bool isExc = NativeMethodsExc.features2d_FastFeatureDetector_getNonmaxSuppression_excsafe(ref ret, obj);

	if(isExc)
		handleException();
	return ret;
}


public static  void features2d_FastFeatureDetector_setType( System.IntPtr obj ,  System.Int32 type )
{
	bool isExc = NativeMethodsExc.features2d_FastFeatureDetector_setType_excsafe(obj, type);

	if(isExc)
		handleException();
}


public static  System.Int32 features2d_FastFeatureDetector_getType( System.IntPtr obj )
{
	System.Int32 ret = new System.Int32();
	bool isExc = NativeMethodsExc.features2d_FastFeatureDetector_getType_excsafe(ref ret, obj);

	if(isExc)
		handleException();
	return ret;
}


public static  System.IntPtr features2d_Ptr_Feature2D_get( System.IntPtr ptr )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.features2d_Ptr_Feature2D_get_excsafe(ref ret, ptr);

	if(isExc)
		handleException();
	return ret;
}


public static  void features2d_BOWImgDescriptorExtractor_compute2( System.IntPtr obj ,  System.IntPtr image ,  System.IntPtr keypoints ,  System.IntPtr imgDescriptor )
{
	bool isExc = NativeMethodsExc.features2d_BOWImgDescriptorExtractor_compute2_excsafe(obj, image, keypoints, imgDescriptor);

	if(isExc)
		handleException();
}


public static  System.Int32 features2d_BOWImgDescriptorExtractor_descriptorSize( System.IntPtr obj )
{
	System.Int32 ret = new System.Int32();
	bool isExc = NativeMethodsExc.features2d_BOWImgDescriptorExtractor_descriptorSize_excsafe(ref ret, obj);

	if(isExc)
		handleException();
	return ret;
}


public static  System.Int32 features2d_BOWImgDescriptorExtractor_descriptorType( System.IntPtr obj )
{
	System.Int32 ret = new System.Int32();
	bool isExc = NativeMethodsExc.features2d_BOWImgDescriptorExtractor_descriptorType_excsafe(ref ret, obj);

	if(isExc)
		handleException();
	return ret;
}


public static  System.IntPtr features2d_BRISK_create1( System.Int32 thresh ,  System.Int32 octaves ,  System.Single patternScale )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.features2d_BRISK_create1_excsafe(ref ret, thresh, octaves, patternScale);

	if(isExc)
		handleException();
	return ret;
}


public static  System.IntPtr features2d_BRISK_create2( System.Single[] radiusList ,  System.Int32 radiusListLength ,  System.Int32[] numberList ,  System.Int32 numberListLength ,  System.Single dMax ,  System.Single dMin ,  System.Int32[] indexChange ,  System.Int32 indexChangeLength )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.features2d_BRISK_create2_excsafe(ref ret, radiusList, radiusListLength, numberList, numberListLength, dMax, dMin, indexChange, indexChangeLength);

	if(isExc)
		handleException();
	return ret;
}


public static  void features2d_Ptr_BRISK_delete( System.IntPtr ptr )
{
	bool isExc = NativeMethodsExc.features2d_Ptr_BRISK_delete_excsafe(ptr);

	if(isExc)
		handleException();
}


public static  System.IntPtr features2d_Ptr_BRISK_get( System.IntPtr ptr )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.features2d_Ptr_BRISK_get_excsafe(ref ret, ptr);

	if(isExc)
		handleException();
	return ret;
}


public static  void features2d_DescriptorExtractor_delete( System.IntPtr obj )
{
	bool isExc = NativeMethodsExc.features2d_DescriptorExtractor_delete_excsafe(obj);

	if(isExc)
		handleException();
}


public static  void features2d_DescriptorExtractor_compute1( System.IntPtr obj ,  System.IntPtr image ,  System.IntPtr keypoint ,  System.IntPtr descriptors )
{
	bool isExc = NativeMethodsExc.features2d_DescriptorExtractor_compute1_excsafe(obj, image, keypoint, descriptors);

	if(isExc)
		handleException();
}


public static  void features2d_DescriptorExtractor_compute2( System.IntPtr obj ,  System.IntPtr[] images ,  System.Int32 imagesSize ,  System.IntPtr keypoints ,  System.IntPtr[] descriptors ,  System.Int32 descriptorsSize )
{
	bool isExc = NativeMethodsExc.features2d_DescriptorExtractor_compute2_excsafe(obj, images, imagesSize, keypoints, descriptors, descriptorsSize);

	if(isExc)
		handleException();
}


public static  System.Int32 features2d_DescriptorExtractor_descriptorSize( System.IntPtr obj )
{
	System.Int32 ret = new System.Int32();
	bool isExc = NativeMethodsExc.features2d_DescriptorExtractor_descriptorSize_excsafe(ref ret, obj);

	if(isExc)
		handleException();
	return ret;
}


public static  System.Int32 features2d_DescriptorExtractor_descriptorType( System.IntPtr obj )
{
	System.Int32 ret = new System.Int32();
	bool isExc = NativeMethodsExc.features2d_DescriptorExtractor_descriptorType_excsafe(ref ret, obj);

	if(isExc)
		handleException();
	return ret;
}


public static  System.Int32 features2d_DescriptorExtractor_empty( System.IntPtr obj )
{
	System.Int32 ret = new System.Int32();
	bool isExc = NativeMethodsExc.features2d_DescriptorExtractor_empty_excsafe(ref ret, obj);

	if(isExc)
		handleException();
	return ret;
}


public static  System.IntPtr features2d_DescriptorExtractor_create([MarshalAs(UnmanagedType.LPStr)] System.String descriptorExtractorType )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.features2d_DescriptorExtractor_create_excsafe(ref ret, descriptorExtractorType);

	if(isExc)
		handleException();
	return ret;
}


public static  System.IntPtr features2d_Ptr_DescriptorExtractor_get( System.IntPtr ptr )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.features2d_Ptr_DescriptorExtractor_get_excsafe(ref ret, ptr);

	if(isExc)
		handleException();
	return ret;
}


public static  void features2d_Ptr_DescriptorExtractor_delete( System.IntPtr ptr )
{
	bool isExc = NativeMethodsExc.features2d_Ptr_DescriptorExtractor_delete_excsafe(ptr);

	if(isExc)
		handleException();
}


public static  void features2d_DescriptorMatcher_add( System.IntPtr obj ,  System.IntPtr[] descriptors ,  System.Int32 descriptorLength )
{
	bool isExc = NativeMethodsExc.features2d_DescriptorMatcher_add_excsafe(obj, descriptors, descriptorLength);

	if(isExc)
		handleException();
}


public static  void features2d_DescriptorMatcher_getTrainDescriptors( System.IntPtr obj ,  System.IntPtr dst )
{
	bool isExc = NativeMethodsExc.features2d_DescriptorMatcher_getTrainDescriptors_excsafe(obj, dst);

	if(isExc)
		handleException();
}


public static  void features2d_DescriptorMatcher_clear( System.IntPtr obj )
{
	bool isExc = NativeMethodsExc.features2d_DescriptorMatcher_clear_excsafe(obj);

	if(isExc)
		handleException();
}


public static  System.Int32 features2d_DescriptorMatcher_empty( System.IntPtr obj )
{
	System.Int32 ret = new System.Int32();
	bool isExc = NativeMethodsExc.features2d_DescriptorMatcher_empty_excsafe(ref ret, obj);

	if(isExc)
		handleException();
	return ret;
}


public static  System.Int32 features2d_DescriptorMatcher_isMaskSupported( System.IntPtr obj )
{
	System.Int32 ret = new System.Int32();
	bool isExc = NativeMethodsExc.features2d_DescriptorMatcher_isMaskSupported_excsafe(ref ret, obj);

	if(isExc)
		handleException();
	return ret;
}


public static  void features2d_DescriptorMatcher_train( System.IntPtr obj )
{
	bool isExc = NativeMethodsExc.features2d_DescriptorMatcher_train_excsafe(obj);

	if(isExc)
		handleException();
}


public static  void features2d_DescriptorMatcher_match1( System.IntPtr obj ,  System.IntPtr queryDescriptors ,  System.IntPtr trainDescriptors ,  System.IntPtr matches ,  System.IntPtr mask )
{
	bool isExc = NativeMethodsExc.features2d_DescriptorMatcher_match1_excsafe(obj, queryDescriptors, trainDescriptors, matches, mask);

	if(isExc)
		handleException();
}


public static  void features2d_DescriptorMatcher_knnMatch1( System.IntPtr obj ,  System.IntPtr queryDescriptors ,  System.IntPtr trainDescriptors ,  System.IntPtr matches ,  System.Int32 k ,  System.IntPtr mask ,  System.Int32 compactResult )
{
	bool isExc = NativeMethodsExc.features2d_DescriptorMatcher_knnMatch1_excsafe(obj, queryDescriptors, trainDescriptors, matches, k, mask, compactResult);

	if(isExc)
		handleException();
}


public static  void features2d_DescriptorMatcher_radiusMatch1( System.IntPtr obj ,  System.IntPtr queryDescriptors ,  System.IntPtr trainDescriptors ,  System.IntPtr matches ,  System.Single maxDistance ,  System.IntPtr mask ,  System.Int32 compactResult )
{
	bool isExc = NativeMethodsExc.features2d_DescriptorMatcher_radiusMatch1_excsafe(obj, queryDescriptors, trainDescriptors, matches, maxDistance, mask, compactResult);

	if(isExc)
		handleException();
}


public static  void features2d_DescriptorMatcher_match2( System.IntPtr obj ,  System.IntPtr queryDescriptors ,  System.IntPtr matches ,  System.IntPtr[] masks ,  System.Int32 masksSize )
{
	bool isExc = NativeMethodsExc.features2d_DescriptorMatcher_match2_excsafe(obj, queryDescriptors, matches, masks, masksSize);

	if(isExc)
		handleException();
}


public static  void features2d_DescriptorMatcher_knnMatch2( System.IntPtr obj ,  System.IntPtr queryDescriptors ,  System.IntPtr matches ,  System.Int32 k ,  System.IntPtr[] masks ,  System.Int32 masksSize ,  System.Int32 compactResult )
{
	bool isExc = NativeMethodsExc.features2d_DescriptorMatcher_knnMatch2_excsafe(obj, queryDescriptors, matches, k, masks, masksSize, compactResult);

	if(isExc)
		handleException();
}


public static  void features2d_DescriptorMatcher_radiusMatch2( System.IntPtr obj ,  System.IntPtr queryDescriptors ,  System.IntPtr matches ,  System.Single maxDistance ,  System.IntPtr[] masks ,  System.Int32 masksSize ,  System.Int32 compactResult )
{
	bool isExc = NativeMethodsExc.features2d_DescriptorMatcher_radiusMatch2_excsafe(obj, queryDescriptors, matches, maxDistance, masks, masksSize, compactResult);

	if(isExc)
		handleException();
}


public static  System.Int32 features2d_AKAZE_getDescriptorSize( System.IntPtr obj )
{
	System.Int32 ret = new System.Int32();
	bool isExc = NativeMethodsExc.features2d_AKAZE_getDescriptorSize_excsafe(ref ret, obj);

	if(isExc)
		handleException();
	return ret;
}


public static  void features2d_AKAZE_setDescriptorChannels( System.IntPtr obj ,  System.Int32 val )
{
	bool isExc = NativeMethodsExc.features2d_AKAZE_setDescriptorChannels_excsafe(obj, val);

	if(isExc)
		handleException();
}


public static  System.Int32 features2d_AKAZE_getDescriptorChannels( System.IntPtr obj )
{
	System.Int32 ret = new System.Int32();
	bool isExc = NativeMethodsExc.features2d_AKAZE_getDescriptorChannels_excsafe(ref ret, obj);

	if(isExc)
		handleException();
	return ret;
}


public static  void features2d_AKAZE_setThreshold( System.IntPtr obj ,  System.Double val )
{
	bool isExc = NativeMethodsExc.features2d_AKAZE_setThreshold_excsafe(obj, val);

	if(isExc)
		handleException();
}


public static  System.Double features2d_AKAZE_getThreshold( System.IntPtr obj )
{
	System.Double ret = new System.Double();
	bool isExc = NativeMethodsExc.features2d_AKAZE_getThreshold_excsafe(ref ret, obj);

	if(isExc)
		handleException();
	return ret;
}


public static  void features2d_AKAZE_setNOctaves( System.IntPtr obj ,  System.Int32 val )
{
	bool isExc = NativeMethodsExc.features2d_AKAZE_setNOctaves_excsafe(obj, val);

	if(isExc)
		handleException();
}


public static  System.Int32 features2d_AKAZE_getNOctaves( System.IntPtr obj )
{
	System.Int32 ret = new System.Int32();
	bool isExc = NativeMethodsExc.features2d_AKAZE_getNOctaves_excsafe(ref ret, obj);

	if(isExc)
		handleException();
	return ret;
}


public static  void features2d_AKAZE_setNOctaveLayers( System.IntPtr obj ,  System.Int32 val )
{
	bool isExc = NativeMethodsExc.features2d_AKAZE_setNOctaveLayers_excsafe(obj, val);

	if(isExc)
		handleException();
}


public static  System.Int32 features2d_AKAZE_getNOctaveLayers( System.IntPtr obj )
{
	System.Int32 ret = new System.Int32();
	bool isExc = NativeMethodsExc.features2d_AKAZE_getNOctaveLayers_excsafe(ref ret, obj);

	if(isExc)
		handleException();
	return ret;
}


public static  void features2d_AKAZE_setDiffusivity( System.IntPtr obj ,  System.Int32 val )
{
	bool isExc = NativeMethodsExc.features2d_AKAZE_setDiffusivity_excsafe(obj, val);

	if(isExc)
		handleException();
}


public static  System.Int32 features2d_AKAZE_getDiffusivity( System.IntPtr obj )
{
	System.Int32 ret = new System.Int32();
	bool isExc = NativeMethodsExc.features2d_AKAZE_getDiffusivity_excsafe(ref ret, obj);

	if(isExc)
		handleException();
	return ret;
}


public static  void features2d_BOWTrainer_add( System.IntPtr obj ,  System.IntPtr descriptors )
{
	bool isExc = NativeMethodsExc.features2d_BOWTrainer_add_excsafe(obj, descriptors);

	if(isExc)
		handleException();
}


public static  void features2d_BOWTrainer_getDescriptors( System.IntPtr obj ,  System.IntPtr descriptors )
{
	bool isExc = NativeMethodsExc.features2d_BOWTrainer_getDescriptors_excsafe(obj, descriptors);

	if(isExc)
		handleException();
}


public static  System.Int32 features2d_BOWTrainer_descriptorsCount( System.IntPtr obj )
{
	System.Int32 ret = new System.Int32();
	bool isExc = NativeMethodsExc.features2d_BOWTrainer_descriptorsCount_excsafe(ref ret, obj);

	if(isExc)
		handleException();
	return ret;
}


public static  void features2d_BOWTrainer_clear( System.IntPtr obj )
{
	bool isExc = NativeMethodsExc.features2d_BOWTrainer_clear_excsafe(obj);

	if(isExc)
		handleException();
}


public static  System.IntPtr features2d_BOWKMeansTrainer_new( System.Int32 clusterCount ,  OpenCvSharp.TermCriteria termcrit ,  System.Int32 attempts ,  System.Int32 flags )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.features2d_BOWKMeansTrainer_new_excsafe(ref ret, clusterCount, termcrit, attempts, flags);

	if(isExc)
		handleException();
	return ret;
}


public static  void features2d_BOWKMeansTrainer_delete( System.IntPtr obj )
{
	bool isExc = NativeMethodsExc.features2d_BOWKMeansTrainer_delete_excsafe(obj);

	if(isExc)
		handleException();
}


public static  System.IntPtr features2d_BOWKMeansTrainer_cluster1( System.IntPtr obj )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.features2d_BOWKMeansTrainer_cluster1_excsafe(ref ret, obj);

	if(isExc)
		handleException();
	return ret;
}


public static  System.IntPtr features2d_BOWKMeansTrainer_cluster2( System.IntPtr obj ,  System.IntPtr descriptors )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.features2d_BOWKMeansTrainer_cluster2_excsafe(ref ret, obj, descriptors);

	if(isExc)
		handleException();
	return ret;
}


public static  System.IntPtr features2d_BOWImgDescriptorExtractor_new1_Ptr( System.IntPtr dextractor ,  System.IntPtr dmatcher )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.features2d_BOWImgDescriptorExtractor_new1_Ptr_excsafe(ref ret, dextractor, dmatcher);

	if(isExc)
		handleException();
	return ret;
}


public static  System.IntPtr features2d_BOWImgDescriptorExtractor_new2_Ptr( System.IntPtr dmatcher )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.features2d_BOWImgDescriptorExtractor_new2_Ptr_excsafe(ref ret, dmatcher);

	if(isExc)
		handleException();
	return ret;
}


public static  System.IntPtr features2d_BOWImgDescriptorExtractor_new1_RawPtr( System.IntPtr dextractor ,  System.IntPtr dmatcher )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.features2d_BOWImgDescriptorExtractor_new1_RawPtr_excsafe(ref ret, dextractor, dmatcher);

	if(isExc)
		handleException();
	return ret;
}


public static  System.IntPtr features2d_BOWImgDescriptorExtractor_new2_RawPtr( System.IntPtr dmatcher )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.features2d_BOWImgDescriptorExtractor_new2_RawPtr_excsafe(ref ret, dmatcher);

	if(isExc)
		handleException();
	return ret;
}


public static  void features2d_BOWImgDescriptorExtractor_delete( System.IntPtr obj )
{
	bool isExc = NativeMethodsExc.features2d_BOWImgDescriptorExtractor_delete_excsafe(obj);

	if(isExc)
		handleException();
}


public static  void features2d_BOWImgDescriptorExtractor_setVocabulary( System.IntPtr obj ,  System.IntPtr vocabulary )
{
	bool isExc = NativeMethodsExc.features2d_BOWImgDescriptorExtractor_setVocabulary_excsafe(obj, vocabulary);

	if(isExc)
		handleException();
}


public static  System.IntPtr features2d_BOWImgDescriptorExtractor_getVocabulary( System.IntPtr obj )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.features2d_BOWImgDescriptorExtractor_getVocabulary_excsafe(ref ret, obj);

	if(isExc)
		handleException();
	return ret;
}


public static  void features2d_BOWImgDescriptorExtractor_compute11( System.IntPtr obj ,  System.IntPtr image ,  System.IntPtr keypoints ,  System.IntPtr imgDescriptor ,  System.IntPtr pointIdxsOfClusters ,  System.IntPtr descriptors )
{
	bool isExc = NativeMethodsExc.features2d_BOWImgDescriptorExtractor_compute11_excsafe(obj, image, keypoints, imgDescriptor, pointIdxsOfClusters, descriptors);

	if(isExc)
		handleException();
}


public static  void features2d_BOWImgDescriptorExtractor_compute12( System.IntPtr obj ,  System.IntPtr keypointDescriptors ,  System.IntPtr imgDescriptor ,  System.IntPtr pointIdxsOfClusters )
{
	bool isExc = NativeMethodsExc.features2d_BOWImgDescriptorExtractor_compute12_excsafe(obj, keypointDescriptors, imgDescriptor, pointIdxsOfClusters);

	if(isExc)
		handleException();
}


public static  void face_LBPHFaceRecognizer_setThreshold( System.IntPtr obj ,  System.Double val )
{
	bool isExc = NativeMethodsExc.face_LBPHFaceRecognizer_setThreshold_excsafe(obj, val);

	if(isExc)
		handleException();
}


public static  void face_LBPHFaceRecognizer_getHistograms( System.IntPtr obj ,  System.IntPtr dst )
{
	bool isExc = NativeMethodsExc.face_LBPHFaceRecognizer_getHistograms_excsafe(obj, dst);

	if(isExc)
		handleException();
}


public static  void face_LBPHFaceRecognizer_getLabels( System.IntPtr obj ,  System.IntPtr dst )
{
	bool isExc = NativeMethodsExc.face_LBPHFaceRecognizer_getLabels_excsafe(obj, dst);

	if(isExc)
		handleException();
}


public static  System.IntPtr face_Ptr_LBPHFaceRecognizer_get( System.IntPtr obj )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.face_Ptr_LBPHFaceRecognizer_get_excsafe(ref ret, obj);

	if(isExc)
		handleException();
	return ret;
}


public static  void face_Ptr_LBPHFaceRecognizer_delete( System.IntPtr obj )
{
	bool isExc = NativeMethodsExc.face_Ptr_LBPHFaceRecognizer_delete_excsafe(obj);

	if(isExc)
		handleException();
}


public static  void features2d_drawKeypoints( System.IntPtr image ,  OpenCvSharp.KeyPoint[] keypoints ,  System.Int32 keypointsLength ,  System.IntPtr outImage ,  OpenCvSharp.Scalar color ,  System.Int32 flags )
{
	bool isExc = NativeMethodsExc.features2d_drawKeypoints_excsafe(image, keypoints, keypointsLength, outImage, color, flags);

	if(isExc)
		handleException();
}


public static  void features2d_drawMatches1( System.IntPtr img1 ,  OpenCvSharp.KeyPoint[] keypoints1 ,  System.Int32 keypoints1Length ,  System.IntPtr img2 ,  OpenCvSharp.KeyPoint[] keypoints2 ,  System.Int32 keypoints2Length ,  OpenCvSharp.DMatch[] matches1to2 ,  System.Int32 matches1to2Length ,  System.IntPtr outImg ,  OpenCvSharp.Scalar matchColor ,  OpenCvSharp.Scalar singlePointColor ,  System.Byte[] matchesMask ,  System.Int32 matchesMaskLength ,  System.Int32 flags )
{
	bool isExc = NativeMethodsExc.features2d_drawMatches1_excsafe(img1, keypoints1, keypoints1Length, img2, keypoints2, keypoints2Length, matches1to2, matches1to2Length, outImg, matchColor, singlePointColor, matchesMask, matchesMaskLength, flags);

	if(isExc)
		handleException();
}


public static  void features2d_drawMatches2( System.IntPtr img1 ,  OpenCvSharp.KeyPoint[] keypoints1 ,  System.Int32 keypoints1Length ,  System.IntPtr img2 ,  OpenCvSharp.KeyPoint[] keypoints2 ,  System.Int32 keypoints2Length ,  System.IntPtr[] matches1to2 ,  System.Int32 matches1to2Size1 ,  System.Int32[] matches1to2Size2 ,  System.IntPtr outImg ,  OpenCvSharp.Scalar matchColor ,  OpenCvSharp.Scalar singlePointColor ,  System.IntPtr[] matchesMask ,  System.Int32 matchesMaskSize1 ,  System.Int32[] matchesMaskSize2 ,  System.Int32 flags )
{
	bool isExc = NativeMethodsExc.features2d_drawMatches2_excsafe(img1, keypoints1, keypoints1Length, img2, keypoints2, keypoints2Length, matches1to2, matches1to2Size1, matches1to2Size2, outImg, matchColor, singlePointColor, matchesMask, matchesMaskSize1, matchesMaskSize2, flags);

	if(isExc)
		handleException();
}


public static  void features2d_evaluateFeatureDetector( System.IntPtr img1 ,  System.IntPtr img2 ,  System.IntPtr H1to2 ,  System.IntPtr keypoints1 ,  System.IntPtr keypoints2 ,  out System.Single repeatability ,  out System.Int32 correspCount )
{
	bool isExc = NativeMethodsExc.features2d_evaluateFeatureDetector_excsafe(img1, img2, H1to2, keypoints1, keypoints2,  out repeatability,  out correspCount);

	if(isExc)
		handleException();
}


public static  void features2d_computeRecallPrecisionCurve( System.IntPtr[] matches1to2 ,  System.Int32 matches1to2Size1 ,  System.Int32[] matches1to2Size2 ,  System.IntPtr[] correctMatches1to2Mask ,  System.Int32 correctMatches1to2MaskSize1 ,  System.Int32[] correctMatches1to2MaskSize2 ,  System.IntPtr recallPrecisionCurve )
{
	bool isExc = NativeMethodsExc.features2d_computeRecallPrecisionCurve_excsafe(matches1to2, matches1to2Size1, matches1to2Size2, correctMatches1to2Mask, correctMatches1to2MaskSize1, correctMatches1to2MaskSize2, recallPrecisionCurve);

	if(isExc)
		handleException();
}


public static  System.Single features2d_getRecall( OpenCvSharp.Point2f[] recallPrecisionCurve ,  System.Int32 recallPrecisionCurveSize ,  System.Single l_precision )
{
	System.Single ret = new System.Single();
	bool isExc = NativeMethodsExc.features2d_getRecall_excsafe(ref ret, recallPrecisionCurve, recallPrecisionCurveSize, l_precision);

	if(isExc)
		handleException();
	return ret;
}


public static  System.Int32 features2d_getNearestPoint( OpenCvSharp.Point2f[] recallPrecisionCurve ,  System.Int32 recallPrecisionCurveSize ,  System.Single l_precision )
{
	System.Int32 ret = new System.Int32();
	bool isExc = NativeMethodsExc.features2d_getNearestPoint_excsafe(ref ret, recallPrecisionCurve, recallPrecisionCurveSize, l_precision);

	if(isExc)
		handleException();
	return ret;
}


public static  void features2d_AGAST( System.IntPtr image ,  System.IntPtr keypoints ,  System.Int32 threshold ,  System.Int32 nonmaxSuppression ,  System.Int32 type )
{
	bool isExc = NativeMethodsExc.features2d_AGAST_excsafe(image, keypoints, threshold, nonmaxSuppression, type);

	if(isExc)
		handleException();
}


public static  System.IntPtr features2d_AgastFeatureDetector_create( System.Int32 threshold ,  System.Int32 nonmaxSuppression ,  System.Int32 type )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.features2d_AgastFeatureDetector_create_excsafe(ref ret, threshold, nonmaxSuppression, type);

	if(isExc)
		handleException();
	return ret;
}


public static  void features2d_Ptr_AgastFeatureDetector_delete( System.IntPtr ptr )
{
	bool isExc = NativeMethodsExc.features2d_Ptr_AgastFeatureDetector_delete_excsafe(ptr);

	if(isExc)
		handleException();
}


public static  System.IntPtr features2d_Ptr_AgastFeatureDetector_get( System.IntPtr ptr )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.features2d_Ptr_AgastFeatureDetector_get_excsafe(ref ret, ptr);

	if(isExc)
		handleException();
	return ret;
}


public static  void features2d_AgastFeatureDetector_setThreshold( System.IntPtr obj ,  System.Int32 val )
{
	bool isExc = NativeMethodsExc.features2d_AgastFeatureDetector_setThreshold_excsafe(obj, val);

	if(isExc)
		handleException();
}


public static  System.Int32 features2d_AgastFeatureDetector_getThreshold( System.IntPtr obj )
{
	System.Int32 ret = new System.Int32();
	bool isExc = NativeMethodsExc.features2d_AgastFeatureDetector_getThreshold_excsafe(ref ret, obj);

	if(isExc)
		handleException();
	return ret;
}


public static  void features2d_AgastFeatureDetector_setNonmaxSuppression( System.IntPtr obj ,  System.Int32 val )
{
	bool isExc = NativeMethodsExc.features2d_AgastFeatureDetector_setNonmaxSuppression_excsafe(obj, val);

	if(isExc)
		handleException();
}


public static  System.Int32 features2d_AgastFeatureDetector_getNonmaxSuppression( System.IntPtr obj )
{
	System.Int32 ret = new System.Int32();
	bool isExc = NativeMethodsExc.features2d_AgastFeatureDetector_getNonmaxSuppression_excsafe(ref ret, obj);

	if(isExc)
		handleException();
	return ret;
}


public static  void features2d_AgastFeatureDetector_setType( System.IntPtr obj ,  System.Int32 val )
{
	bool isExc = NativeMethodsExc.features2d_AgastFeatureDetector_setType_excsafe(obj, val);

	if(isExc)
		handleException();
}


public static  System.Int32 features2d_AgastFeatureDetector_getType( System.IntPtr obj )
{
	System.Int32 ret = new System.Int32();
	bool isExc = NativeMethodsExc.features2d_AgastFeatureDetector_getType_excsafe(ref ret, obj);

	if(isExc)
		handleException();
	return ret;
}


public static  System.IntPtr features2d_AKAZE_create( System.Int32 descriptor_type ,  System.Int32 descriptor_size ,  System.Int32 descriptor_channels ,  System.Single threshold ,  System.Int32 nOctaves ,  System.Int32 nOctaveLayers ,  System.Int32 diffusivity )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.features2d_AKAZE_create_excsafe(ref ret, descriptor_type, descriptor_size, descriptor_channels, threshold, nOctaves, nOctaveLayers, diffusivity);

	if(isExc)
		handleException();
	return ret;
}


public static  void features2d_Ptr_AKAZE_delete( System.IntPtr ptr )
{
	bool isExc = NativeMethodsExc.features2d_Ptr_AKAZE_delete_excsafe(ptr);

	if(isExc)
		handleException();
}


public static  System.IntPtr features2d_Ptr_AKAZE_get( System.IntPtr ptr )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.features2d_Ptr_AKAZE_get_excsafe(ref ret, ptr);

	if(isExc)
		handleException();
	return ret;
}


public static  void features2d_AKAZE_setDescriptorType( System.IntPtr obj ,  System.Int32 val )
{
	bool isExc = NativeMethodsExc.features2d_AKAZE_setDescriptorType_excsafe(obj, val);

	if(isExc)
		handleException();
}


public static  System.Int32 features2d_AKAZE_getDescriptorType( System.IntPtr obj )
{
	System.Int32 ret = new System.Int32();
	bool isExc = NativeMethodsExc.features2d_AKAZE_getDescriptorType_excsafe(ref ret, obj);

	if(isExc)
		handleException();
	return ret;
}


public static  void features2d_AKAZE_setDescriptorSize( System.IntPtr obj ,  System.Int32 val )
{
	bool isExc = NativeMethodsExc.features2d_AKAZE_setDescriptorSize_excsafe(obj, val);

	if(isExc)
		handleException();
}


public static  void face_FaceRecognizer_train( System.IntPtr obj ,  System.IntPtr[] src ,  System.Int32 srcLength ,  System.Int32[] labels ,  System.Int32 labelsLength )
{
	bool isExc = NativeMethodsExc.face_FaceRecognizer_train_excsafe(obj, src, srcLength, labels, labelsLength);

	if(isExc)
		handleException();
}


public static  void face_FaceRecognizer_update( System.IntPtr obj ,  System.IntPtr[] src ,  System.Int32 srcLength ,  System.Int32[] labels ,  System.Int32 labelsLength )
{
	bool isExc = NativeMethodsExc.face_FaceRecognizer_update_excsafe(obj, src, srcLength, labels, labelsLength);

	if(isExc)
		handleException();
}


public static  System.Int32 face_FaceRecognizer_predict1( System.IntPtr obj ,  System.IntPtr src )
{
	System.Int32 ret = new System.Int32();
	bool isExc = NativeMethodsExc.face_FaceRecognizer_predict1_excsafe(ref ret, obj, src);

	if(isExc)
		handleException();
	return ret;
}


public static  void face_FaceRecognizer_predict2( System.IntPtr obj ,  System.IntPtr src ,  out System.Int32 label ,  out System.Double confidence )
{
	bool isExc = NativeMethodsExc.face_FaceRecognizer_predict2_excsafe(obj, src,  out label,  out confidence);

	if(isExc)
		handleException();
}


public static  void face_FaceRecognizer_write1( System.IntPtr obj ,  System.String filename )
{
	bool isExc = NativeMethodsExc.face_FaceRecognizer_write1_excsafe(obj, filename);

	if(isExc)
		handleException();
}


public static  void face_FaceRecognizer_read1( System.IntPtr obj ,  System.String filename )
{
	bool isExc = NativeMethodsExc.face_FaceRecognizer_read1_excsafe(obj, filename);

	if(isExc)
		handleException();
}


public static  void face_FaceRecognizer_write2( System.IntPtr obj ,  System.IntPtr fs )
{
	bool isExc = NativeMethodsExc.face_FaceRecognizer_write2_excsafe(obj, fs);

	if(isExc)
		handleException();
}


public static  void face_FaceRecognizer_read2( System.IntPtr obj ,  System.IntPtr fs )
{
	bool isExc = NativeMethodsExc.face_FaceRecognizer_read2_excsafe(obj, fs);

	if(isExc)
		handleException();
}


public static  void face_FaceRecognizer_setLabelInfo( System.IntPtr obj ,  System.Int32 label , [MarshalAs(UnmanagedType.LPStr)] System.String strInfo )
{
	bool isExc = NativeMethodsExc.face_FaceRecognizer_setLabelInfo_excsafe(obj, label, strInfo);

	if(isExc)
		handleException();
}


public static  void face_FaceRecognizer_getLabelInfo( System.IntPtr obj ,  System.Int32 label ,  System.IntPtr dst )
{
	bool isExc = NativeMethodsExc.face_FaceRecognizer_getLabelInfo_excsafe(obj, label, dst);

	if(isExc)
		handleException();
}


public static  void face_FaceRecognizer_getLabelsByString( System.IntPtr obj , [MarshalAs(UnmanagedType.LPStr)] System.String str ,  System.IntPtr dst )
{
	bool isExc = NativeMethodsExc.face_FaceRecognizer_getLabelsByString_excsafe(obj, str, dst);

	if(isExc)
		handleException();
}


public static  System.Double face_FaceRecognizer_getThreshold( System.IntPtr obj )
{
	System.Double ret = new System.Double();
	bool isExc = NativeMethodsExc.face_FaceRecognizer_getThreshold_excsafe(ref ret, obj);

	if(isExc)
		handleException();
	return ret;
}


public static  void face_FaceRecognizer_setThreshold( System.IntPtr obj ,  System.Double val )
{
	bool isExc = NativeMethodsExc.face_FaceRecognizer_setThreshold_excsafe(obj, val);

	if(isExc)
		handleException();
}


public static  System.IntPtr face_Ptr_FaceRecognizer_get( System.IntPtr obj )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.face_Ptr_FaceRecognizer_get_excsafe(ref ret, obj);

	if(isExc)
		handleException();
	return ret;
}


public static  void face_Ptr_FaceRecognizer_delete( System.IntPtr obj )
{
	bool isExc = NativeMethodsExc.face_Ptr_FaceRecognizer_delete_excsafe(obj);

	if(isExc)
		handleException();
}


public static  System.IntPtr face_FisherFaceRecognizer_create( System.Int32 numComponents ,  System.Double threshold )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.face_FisherFaceRecognizer_create_excsafe(ref ret, numComponents, threshold);

	if(isExc)
		handleException();
	return ret;
}


public static  System.IntPtr face_Ptr_FisherFaceRecognizer_get( System.IntPtr obj )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.face_Ptr_FisherFaceRecognizer_get_excsafe(ref ret, obj);

	if(isExc)
		handleException();
	return ret;
}


public static  void face_Ptr_FisherFaceRecognizer_delete( System.IntPtr obj )
{
	bool isExc = NativeMethodsExc.face_Ptr_FisherFaceRecognizer_delete_excsafe(obj);

	if(isExc)
		handleException();
}


public static  System.IntPtr face_LBPHFaceRecognizer_create( System.Int32 radius ,  System.Int32 neighbors ,  System.Int32 gridX ,  System.Int32 gridY ,  System.Double threshold )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.face_LBPHFaceRecognizer_create_excsafe(ref ret, radius, neighbors, gridX, gridY, threshold);

	if(isExc)
		handleException();
	return ret;
}


public static  System.Int32 face_LBPHFaceRecognizer_getGridX( System.IntPtr obj )
{
	System.Int32 ret = new System.Int32();
	bool isExc = NativeMethodsExc.face_LBPHFaceRecognizer_getGridX_excsafe(ref ret, obj);

	if(isExc)
		handleException();
	return ret;
}


public static  void face_LBPHFaceRecognizer_setGridX( System.IntPtr obj ,  System.Int32 val )
{
	bool isExc = NativeMethodsExc.face_LBPHFaceRecognizer_setGridX_excsafe(obj, val);

	if(isExc)
		handleException();
}


public static  System.Int32 face_LBPHFaceRecognizer_getGridY( System.IntPtr obj )
{
	System.Int32 ret = new System.Int32();
	bool isExc = NativeMethodsExc.face_LBPHFaceRecognizer_getGridY_excsafe(ref ret, obj);

	if(isExc)
		handleException();
	return ret;
}


public static  void face_LBPHFaceRecognizer_setGridY( System.IntPtr obj ,  System.Int32 val )
{
	bool isExc = NativeMethodsExc.face_LBPHFaceRecognizer_setGridY_excsafe(obj, val);

	if(isExc)
		handleException();
}


public static  System.Int32 face_LBPHFaceRecognizer_getRadius( System.IntPtr obj )
{
	System.Int32 ret = new System.Int32();
	bool isExc = NativeMethodsExc.face_LBPHFaceRecognizer_getRadius_excsafe(ref ret, obj);

	if(isExc)
		handleException();
	return ret;
}


public static  void face_LBPHFaceRecognizer_setRadius( System.IntPtr obj ,  System.Int32 val )
{
	bool isExc = NativeMethodsExc.face_LBPHFaceRecognizer_setRadius_excsafe(obj, val);

	if(isExc)
		handleException();
}


public static  System.Int32 face_LBPHFaceRecognizer_getNeighbors( System.IntPtr obj )
{
	System.Int32 ret = new System.Int32();
	bool isExc = NativeMethodsExc.face_LBPHFaceRecognizer_getNeighbors_excsafe(ref ret, obj);

	if(isExc)
		handleException();
	return ret;
}


public static  void face_LBPHFaceRecognizer_setNeighbors( System.IntPtr obj ,  System.Int32 val )
{
	bool isExc = NativeMethodsExc.face_LBPHFaceRecognizer_setNeighbors_excsafe(obj, val);

	if(isExc)
		handleException();
}


public static  System.Double face_LBPHFaceRecognizer_getThreshold( System.IntPtr obj )
{
	System.Double ret = new System.Double();
	bool isExc = NativeMethodsExc.face_LBPHFaceRecognizer_getThreshold_excsafe(ref ret, obj);

	if(isExc)
		handleException();
	return ret;
}


public static  System.IntPtr face_FacemarkAAM_create( System.IntPtr @params )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.face_FacemarkAAM_create_excsafe(ref ret, @params);

	if(isExc)
		handleException();
	return ret;
}


public static  System.IntPtr face_Ptr_FacemarkAAM_get( System.IntPtr obj )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.face_Ptr_FacemarkAAM_get_excsafe(ref ret, obj);

	if(isExc)
		handleException();
	return ret;
}


public static  void face_Ptr_FacemarkAAM_delete( System.IntPtr obj )
{
	bool isExc = NativeMethodsExc.face_Ptr_FacemarkAAM_delete_excsafe(obj);

	if(isExc)
		handleException();
}


public static  System.IntPtr face_FacemarkAAM_Params_new()
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.face_FacemarkAAM_Params_new_excsafe(ref ret);

	if(isExc)
		handleException();
	return ret;
}


public static  void face_FacemarkAAM_Params_delete( System.IntPtr obj )
{
	bool isExc = NativeMethodsExc.face_FacemarkAAM_Params_delete_excsafe(obj);

	if(isExc)
		handleException();
}


public static  void face_FacemarkAAM_Params_model_filename_get( System.IntPtr obj ,  System.IntPtr s )
{
	bool isExc = NativeMethodsExc.face_FacemarkAAM_Params_model_filename_get_excsafe(obj, s);

	if(isExc)
		handleException();
}


public static  void face_FacemarkAAM_Params_model_filename_set( System.IntPtr obj , [MarshalAs(UnmanagedType.LPStr)] System.String s )
{
	bool isExc = NativeMethodsExc.face_FacemarkAAM_Params_model_filename_set_excsafe(obj, s);

	if(isExc)
		handleException();
}


public static  System.Int32 face_FacemarkAAM_Params_m_get( System.IntPtr obj )
{
	System.Int32 ret = new System.Int32();
	bool isExc = NativeMethodsExc.face_FacemarkAAM_Params_m_get_excsafe(ref ret, obj);

	if(isExc)
		handleException();
	return ret;
}


public static  void face_FacemarkAAM_Params_m_set( System.IntPtr obj ,  System.Int32 val )
{
	bool isExc = NativeMethodsExc.face_FacemarkAAM_Params_m_set_excsafe(obj, val);

	if(isExc)
		handleException();
}


public static  System.Int32 face_FacemarkAAM_Params_n_get( System.IntPtr obj )
{
	System.Int32 ret = new System.Int32();
	bool isExc = NativeMethodsExc.face_FacemarkAAM_Params_n_get_excsafe(ref ret, obj);

	if(isExc)
		handleException();
	return ret;
}


public static  void face_FacemarkAAM_Params_n_set( System.IntPtr obj ,  System.Int32 val )
{
	bool isExc = NativeMethodsExc.face_FacemarkAAM_Params_n_set_excsafe(obj, val);

	if(isExc)
		handleException();
}


public static  System.Int32 face_FacemarkAAM_Params_n_iter_get( System.IntPtr obj )
{
	System.Int32 ret = new System.Int32();
	bool isExc = NativeMethodsExc.face_FacemarkAAM_Params_n_iter_get_excsafe(ref ret, obj);

	if(isExc)
		handleException();
	return ret;
}


public static  void face_FacemarkAAM_Params_n_iter_set( System.IntPtr obj ,  System.Int32 val )
{
	bool isExc = NativeMethodsExc.face_FacemarkAAM_Params_n_iter_set_excsafe(obj, val);

	if(isExc)
		handleException();
}


public static  System.Int32 face_FacemarkAAM_Params_verbose_get( System.IntPtr obj )
{
	System.Int32 ret = new System.Int32();
	bool isExc = NativeMethodsExc.face_FacemarkAAM_Params_verbose_get_excsafe(ref ret, obj);

	if(isExc)
		handleException();
	return ret;
}


public static  void face_FacemarkAAM_Params_verbose_set( System.IntPtr obj ,  System.Int32 val )
{
	bool isExc = NativeMethodsExc.face_FacemarkAAM_Params_verbose_set_excsafe(obj, val);

	if(isExc)
		handleException();
}


public static  System.Int32 face_FacemarkAAM_Params_save_model_get( System.IntPtr obj )
{
	System.Int32 ret = new System.Int32();
	bool isExc = NativeMethodsExc.face_FacemarkAAM_Params_save_model_get_excsafe(ref ret, obj);

	if(isExc)
		handleException();
	return ret;
}


public static  void face_FacemarkAAM_Params_save_model_set( System.IntPtr obj ,  System.Int32 val )
{
	bool isExc = NativeMethodsExc.face_FacemarkAAM_Params_save_model_set_excsafe(obj, val);

	if(isExc)
		handleException();
}


public static  System.Int32 face_FacemarkAAM_Params_max_m_get( System.IntPtr obj )
{
	System.Int32 ret = new System.Int32();
	bool isExc = NativeMethodsExc.face_FacemarkAAM_Params_max_m_get_excsafe(ref ret, obj);

	if(isExc)
		handleException();
	return ret;
}


public static  void face_FacemarkAAM_Params_max_m_set( System.IntPtr obj ,  System.Int32 val )
{
	bool isExc = NativeMethodsExc.face_FacemarkAAM_Params_max_m_set_excsafe(obj, val);

	if(isExc)
		handleException();
}


public static  System.Int32 face_FacemarkAAM_Params_max_n_get( System.IntPtr obj )
{
	System.Int32 ret = new System.Int32();
	bool isExc = NativeMethodsExc.face_FacemarkAAM_Params_max_n_get_excsafe(ref ret, obj);

	if(isExc)
		handleException();
	return ret;
}


public static  void face_FacemarkAAM_Params_max_n_set( System.IntPtr obj ,  System.Int32 val )
{
	bool isExc = NativeMethodsExc.face_FacemarkAAM_Params_max_n_set_excsafe(obj, val);

	if(isExc)
		handleException();
}


public static  System.Int32 face_FacemarkAAM_Params_texture_max_m_get( System.IntPtr obj )
{
	System.Int32 ret = new System.Int32();
	bool isExc = NativeMethodsExc.face_FacemarkAAM_Params_texture_max_m_get_excsafe(ref ret, obj);

	if(isExc)
		handleException();
	return ret;
}


public static  void face_FacemarkAAM_Params_texture_max_m_set( System.IntPtr obj ,  System.Int32 val )
{
	bool isExc = NativeMethodsExc.face_FacemarkAAM_Params_texture_max_m_set_excsafe(obj, val);

	if(isExc)
		handleException();
}


public static  void face_FacemarkAAM_Params_scales_get( System.IntPtr obj ,  System.IntPtr v )
{
	bool isExc = NativeMethodsExc.face_FacemarkAAM_Params_scales_get_excsafe(obj, v);

	if(isExc)
		handleException();
}


public static  void face_FacemarkAAM_Params_scales_set( System.IntPtr obj ,  System.IntPtr v )
{
	bool isExc = NativeMethodsExc.face_FacemarkAAM_Params_scales_set_excsafe(obj, v);

	if(isExc)
		handleException();
}


public static  void face_FacemarkAAM_Params_read( System.IntPtr obj ,  System.IntPtr fn )
{
	bool isExc = NativeMethodsExc.face_FacemarkAAM_Params_read_excsafe(obj, fn);

	if(isExc)
		handleException();
}


public static  void face_FacemarkAAM_Params_write( System.IntPtr obj ,  System.IntPtr fs )
{
	bool isExc = NativeMethodsExc.face_FacemarkAAM_Params_write_excsafe(obj, fs);

	if(isExc)
		handleException();
}


public static  void face_FaceRecognizer_delete( System.IntPtr obj )
{
	bool isExc = NativeMethodsExc.face_FaceRecognizer_delete_excsafe(obj);

	if(isExc)
		handleException();
}


public static  System.Int32 face_FacemarkLBF_Params_initShape_n_get( System.IntPtr obj )
{
	System.Int32 ret = new System.Int32();
	bool isExc = NativeMethodsExc.face_FacemarkLBF_Params_initShape_n_get_excsafe(ref ret, obj);

	if(isExc)
		handleException();
	return ret;
}


public static  void face_FacemarkLBF_Params_initShape_n_set( System.IntPtr obj ,  System.Int32 val )
{
	bool isExc = NativeMethodsExc.face_FacemarkLBF_Params_initShape_n_set_excsafe(obj, val);

	if(isExc)
		handleException();
}


public static  System.Int32 face_FacemarkLBF_Params_stages_n_get( System.IntPtr obj )
{
	System.Int32 ret = new System.Int32();
	bool isExc = NativeMethodsExc.face_FacemarkLBF_Params_stages_n_get_excsafe(ref ret, obj);

	if(isExc)
		handleException();
	return ret;
}


public static  void face_FacemarkLBF_Params_stages_n_set( System.IntPtr obj ,  System.Int32 val )
{
	bool isExc = NativeMethodsExc.face_FacemarkLBF_Params_stages_n_set_excsafe(obj, val);

	if(isExc)
		handleException();
}


public static  System.Int32 face_FacemarkLBF_Params_tree_n_get( System.IntPtr obj )
{
	System.Int32 ret = new System.Int32();
	bool isExc = NativeMethodsExc.face_FacemarkLBF_Params_tree_n_get_excsafe(ref ret, obj);

	if(isExc)
		handleException();
	return ret;
}


public static  void face_FacemarkLBF_Params_tree_n_set( System.IntPtr obj ,  System.Int32 val )
{
	bool isExc = NativeMethodsExc.face_FacemarkLBF_Params_tree_n_set_excsafe(obj, val);

	if(isExc)
		handleException();
}


public static  System.Int32 face_FacemarkLBF_Params_tree_depth_get( System.IntPtr obj )
{
	System.Int32 ret = new System.Int32();
	bool isExc = NativeMethodsExc.face_FacemarkLBF_Params_tree_depth_get_excsafe(ref ret, obj);

	if(isExc)
		handleException();
	return ret;
}


public static  void face_FacemarkLBF_Params_tree_depth_set( System.IntPtr obj ,  System.Int32 val )
{
	bool isExc = NativeMethodsExc.face_FacemarkLBF_Params_tree_depth_set_excsafe(obj, val);

	if(isExc)
		handleException();
}


public static  System.Double face_FacemarkLBF_Params_bagging_overlap_get( System.IntPtr obj )
{
	System.Double ret = new System.Double();
	bool isExc = NativeMethodsExc.face_FacemarkLBF_Params_bagging_overlap_get_excsafe(ref ret, obj);

	if(isExc)
		handleException();
	return ret;
}


public static  void face_FacemarkLBF_Params_bagging_overlap_set( System.IntPtr obj ,  System.Double val )
{
	bool isExc = NativeMethodsExc.face_FacemarkLBF_Params_bagging_overlap_set_excsafe(obj, val);

	if(isExc)
		handleException();
}


public static  void face_FacemarkLBF_Params_model_filename_get( System.IntPtr obj ,  System.IntPtr s )
{
	bool isExc = NativeMethodsExc.face_FacemarkLBF_Params_model_filename_get_excsafe(obj, s);

	if(isExc)
		handleException();
}


public static  void face_FacemarkLBF_Params_model_filename_set( System.IntPtr obj , [MarshalAs(UnmanagedType.LPStr)] System.String s )
{
	bool isExc = NativeMethodsExc.face_FacemarkLBF_Params_model_filename_set_excsafe(obj, s);

	if(isExc)
		handleException();
}


public static  System.Int32 face_FacemarkLBF_Params_save_model_get( System.IntPtr obj )
{
	System.Int32 ret = new System.Int32();
	bool isExc = NativeMethodsExc.face_FacemarkLBF_Params_save_model_get_excsafe(ref ret, obj);

	if(isExc)
		handleException();
	return ret;
}


public static  void face_FacemarkLBF_Params_save_model_set( System.IntPtr obj ,  System.Int32 val )
{
	bool isExc = NativeMethodsExc.face_FacemarkLBF_Params_save_model_set_excsafe(obj, val);

	if(isExc)
		handleException();
}


public static  System.UInt32 face_FacemarkLBF_Params_seed_get( System.IntPtr obj )
{
	System.UInt32 ret = new System.UInt32();
	bool isExc = NativeMethodsExc.face_FacemarkLBF_Params_seed_get_excsafe(ref ret, obj);

	if(isExc)
		handleException();
	return ret;
}


public static  void face_FacemarkLBF_Params_seed_set( System.IntPtr obj ,  System.UInt32 val )
{
	bool isExc = NativeMethodsExc.face_FacemarkLBF_Params_seed_set_excsafe(obj, val);

	if(isExc)
		handleException();
}


public static  void face_FacemarkLBF_Params_feats_m_get( System.IntPtr obj ,  System.IntPtr v )
{
	bool isExc = NativeMethodsExc.face_FacemarkLBF_Params_feats_m_get_excsafe(obj, v);

	if(isExc)
		handleException();
}


public static  void face_FacemarkLBF_Params_feats_m_set( System.IntPtr obj ,  System.IntPtr v )
{
	bool isExc = NativeMethodsExc.face_FacemarkLBF_Params_feats_m_set_excsafe(obj, v);

	if(isExc)
		handleException();
}


public static  void face_FacemarkLBF_Params_radius_m_get( System.IntPtr obj ,  System.IntPtr v )
{
	bool isExc = NativeMethodsExc.face_FacemarkLBF_Params_radius_m_get_excsafe(obj, v);

	if(isExc)
		handleException();
}


public static  void face_FacemarkLBF_Params_radius_m_set( System.IntPtr obj ,  System.IntPtr v )
{
	bool isExc = NativeMethodsExc.face_FacemarkLBF_Params_radius_m_set_excsafe(obj, v);

	if(isExc)
		handleException();
}


public static  void face_FacemarkLBF_Params_pupils0_get( System.IntPtr obj ,  System.IntPtr v )
{
	bool isExc = NativeMethodsExc.face_FacemarkLBF_Params_pupils0_get_excsafe(obj, v);

	if(isExc)
		handleException();
}


public static  void face_FacemarkLBF_Params_pupils0_set( System.IntPtr obj ,  System.IntPtr v )
{
	bool isExc = NativeMethodsExc.face_FacemarkLBF_Params_pupils0_set_excsafe(obj, v);

	if(isExc)
		handleException();
}


public static  void face_FacemarkLBF_Params_pupils1_get( System.IntPtr obj ,  System.IntPtr v )
{
	bool isExc = NativeMethodsExc.face_FacemarkLBF_Params_pupils1_get_excsafe(obj, v);

	if(isExc)
		handleException();
}


public static  void face_FacemarkLBF_Params_pupils1_set( System.IntPtr obj ,  System.IntPtr v )
{
	bool isExc = NativeMethodsExc.face_FacemarkLBF_Params_pupils1_set_excsafe(obj, v);

	if(isExc)
		handleException();
}


public static  OpenCvSharp.Rect face_FacemarkLBF_Params_detectROI_get( System.IntPtr obj )
{
	OpenCvSharp.Rect ret = new OpenCvSharp.Rect();
	bool isExc = NativeMethodsExc.face_FacemarkLBF_Params_detectROI_get_excsafe(ref ret, obj);

	if(isExc)
		handleException();
	return ret;
}


public static  void face_FacemarkLBF_Params_detectROI_set( System.IntPtr obj ,  OpenCvSharp.Rect val )
{
	bool isExc = NativeMethodsExc.face_FacemarkLBF_Params_detectROI_set_excsafe(obj, val);

	if(isExc)
		handleException();
}


public static  void face_FacemarkLBF_Params_read( System.IntPtr obj ,  System.IntPtr fn )
{
	bool isExc = NativeMethodsExc.face_FacemarkLBF_Params_read_excsafe(obj, fn);

	if(isExc)
		handleException();
}


public static  void face_FacemarkLBF_Params_write( System.IntPtr obj ,  System.IntPtr fs )
{
	bool isExc = NativeMethodsExc.face_FacemarkLBF_Params_write_excsafe(obj, fs);

	if(isExc)
		handleException();
}


public static  void face_BasicFaceRecognizer_getMean( System.IntPtr obj ,  System.IntPtr dst )
{
	bool isExc = NativeMethodsExc.face_BasicFaceRecognizer_getMean_excsafe(obj, dst);

	if(isExc)
		handleException();
}


public static  System.IntPtr face_Ptr_BasicFaceRecognizer_get( System.IntPtr obj )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.face_Ptr_BasicFaceRecognizer_get_excsafe(ref ret, obj);

	if(isExc)
		handleException();
	return ret;
}


public static  void face_Ptr_BasicFaceRecognizer_delete( System.IntPtr obj )
{
	bool isExc = NativeMethodsExc.face_Ptr_BasicFaceRecognizer_delete_excsafe(obj);

	if(isExc)
		handleException();
}


public static  System.IntPtr face_EigenFaceRecognizer_create( System.Int32 numComponents ,  System.Double threshold )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.face_EigenFaceRecognizer_create_excsafe(ref ret, numComponents, threshold);

	if(isExc)
		handleException();
	return ret;
}


public static  System.IntPtr face_Ptr_EigenFaceRecognizer_get( System.IntPtr obj )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.face_Ptr_EigenFaceRecognizer_get_excsafe(ref ret, obj);

	if(isExc)
		handleException();
	return ret;
}


public static  void face_Ptr_EigenFaceRecognizer_delete( System.IntPtr obj )
{
	bool isExc = NativeMethodsExc.face_Ptr_EigenFaceRecognizer_delete_excsafe(obj);

	if(isExc)
		handleException();
}


public static  void face_Facemark_read( System.IntPtr obj ,  System.IntPtr fn )
{
	bool isExc = NativeMethodsExc.face_Facemark_read_excsafe(obj, fn);

	if(isExc)
		handleException();
}


public static  void face_Facemark_write( System.IntPtr obj ,  System.IntPtr fs )
{
	bool isExc = NativeMethodsExc.face_Facemark_write_excsafe(obj, fs);

	if(isExc)
		handleException();
}


public static  System.Int32 face_Facemark_addTrainingSample( System.IntPtr obj ,  System.IntPtr image ,  System.IntPtr landmarks )
{
	System.Int32 ret = new System.Int32();
	bool isExc = NativeMethodsExc.face_Facemark_addTrainingSample_excsafe(ref ret, obj, image, landmarks);

	if(isExc)
		handleException();
	return ret;
}


public static  void face_Facemark_training( System.IntPtr obj ,  System.IntPtr parameters )
{
	bool isExc = NativeMethodsExc.face_Facemark_training_excsafe(obj, parameters);

	if(isExc)
		handleException();
}


public static  void face_Facemark_loadModel( System.IntPtr obj , [MarshalAs(UnmanagedType.LPStr)] System.String model )
{
	bool isExc = NativeMethodsExc.face_Facemark_loadModel_excsafe(obj, model);

	if(isExc)
		handleException();
}


public static  System.Int32 face_Facemark_fit( System.IntPtr obj ,  System.IntPtr image ,  System.IntPtr faces ,  System.IntPtr landmarks ,  System.IntPtr config )
{
	System.Int32 ret = new System.Int32();
	bool isExc = NativeMethodsExc.face_Facemark_fit_excsafe(ref ret, obj, image, faces, landmarks, config);

	if(isExc)
		handleException();
	return ret;
}


public static  System.Int32 face_Facemark_setFaceDetector( System.IntPtr obj ,  System.IntPtr detector ,  System.IntPtr userData )
{
	System.Int32 ret = new System.Int32();
	bool isExc = NativeMethodsExc.face_Facemark_setFaceDetector_excsafe(ref ret, obj, detector, userData);

	if(isExc)
		handleException();
	return ret;
}


public static  System.Int32 face_Facemark_getFaces_OutputArray( System.IntPtr obj ,  System.IntPtr image ,  System.IntPtr faces )
{
	System.Int32 ret = new System.Int32();
	bool isExc = NativeMethodsExc.face_Facemark_getFaces_OutputArray_excsafe(ref ret, obj, image, faces);

	if(isExc)
		handleException();
	return ret;
}


public static  System.Int32 face_Facemark_getFaces_vectorOfRect( System.IntPtr obj ,  System.IntPtr image ,  System.IntPtr faces )
{
	System.Int32 ret = new System.Int32();
	bool isExc = NativeMethodsExc.face_Facemark_getFaces_vectorOfRect_excsafe(ref ret, obj, image, faces);

	if(isExc)
		handleException();
	return ret;
}


public static  System.IntPtr face_FacemarkLBF_create( System.IntPtr @params )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.face_FacemarkLBF_create_excsafe(ref ret, @params);

	if(isExc)
		handleException();
	return ret;
}


public static  System.IntPtr face_Ptr_FacemarkLBF_get( System.IntPtr obj )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.face_Ptr_FacemarkLBF_get_excsafe(ref ret, obj);

	if(isExc)
		handleException();
	return ret;
}


public static  void face_Ptr_FacemarkLBF_delete( System.IntPtr obj )
{
	bool isExc = NativeMethodsExc.face_Ptr_FacemarkLBF_delete_excsafe(obj);

	if(isExc)
		handleException();
}


public static  System.IntPtr face_FacemarkLBF_Params_new()
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.face_FacemarkLBF_Params_new_excsafe(ref ret);

	if(isExc)
		handleException();
	return ret;
}


public static  void face_FacemarkLBF_Params_delete( System.IntPtr obj )
{
	bool isExc = NativeMethodsExc.face_FacemarkLBF_Params_delete_excsafe(obj);

	if(isExc)
		handleException();
}


public static  System.Double face_FacemarkLBF_Params_shape_offset_get( System.IntPtr obj )
{
	System.Double ret = new System.Double();
	bool isExc = NativeMethodsExc.face_FacemarkLBF_Params_shape_offset_get_excsafe(ref ret, obj);

	if(isExc)
		handleException();
	return ret;
}


public static  void face_FacemarkLBF_Params_shape_offset_set( System.IntPtr obj ,  System.Double val )
{
	bool isExc = NativeMethodsExc.face_FacemarkLBF_Params_shape_offset_set_excsafe(obj, val);

	if(isExc)
		handleException();
}


public static  void face_FacemarkLBF_Params_cascade_face_get( System.IntPtr obj ,  System.IntPtr s )
{
	bool isExc = NativeMethodsExc.face_FacemarkLBF_Params_cascade_face_get_excsafe(obj, s);

	if(isExc)
		handleException();
}


public static  void face_FacemarkLBF_Params_cascade_face_set( System.IntPtr obj , [MarshalAs(UnmanagedType.LPStr)] System.String s )
{
	bool isExc = NativeMethodsExc.face_FacemarkLBF_Params_cascade_face_set_excsafe(obj, s);

	if(isExc)
		handleException();
}


public static  System.Int32 face_FacemarkLBF_Params_verbose_get( System.IntPtr obj )
{
	System.Int32 ret = new System.Int32();
	bool isExc = NativeMethodsExc.face_FacemarkLBF_Params_verbose_get_excsafe(ref ret, obj);

	if(isExc)
		handleException();
	return ret;
}


public static  void face_FacemarkLBF_Params_verbose_set( System.IntPtr obj ,  System.Int32 val )
{
	bool isExc = NativeMethodsExc.face_FacemarkLBF_Params_verbose_set_excsafe(obj, val);

	if(isExc)
		handleException();
}


public static  System.Int32 face_FacemarkLBF_Params_n_landmarks_get( System.IntPtr obj )
{
	System.Int32 ret = new System.Int32();
	bool isExc = NativeMethodsExc.face_FacemarkLBF_Params_n_landmarks_get_excsafe(ref ret, obj);

	if(isExc)
		handleException();
	return ret;
}


public static  void face_FacemarkLBF_Params_n_landmarks_set( System.IntPtr obj ,  System.Int32 val )
{
	bool isExc = NativeMethodsExc.face_FacemarkLBF_Params_n_landmarks_set_excsafe(obj, val);

	if(isExc)
		handleException();
}


public static  System.IntPtr dnn_blobFromImage( System.IntPtr image ,  System.Double scalefactor ,  OpenCvSharp.Size size ,  OpenCvSharp.Scalar mean ,  System.Int32 swapRB ,  System.Int32 crop )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.dnn_blobFromImage_excsafe(ref ret, image, scalefactor, size, mean, swapRB, crop);

	if(isExc)
		handleException();
	return ret;
}


public static  System.IntPtr dnn_blobFromImages( System.IntPtr[] images ,  System.Int32 imagesLength ,  System.Double scalefactor ,  OpenCvSharp.Size size ,  OpenCvSharp.Scalar mean ,  System.Int32 swapRB ,  System.Int32 crop )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.dnn_blobFromImages_excsafe(ref ret, images, imagesLength, scalefactor, size, mean, swapRB, crop);

	if(isExc)
		handleException();
	return ret;
}


public static  void dnn_shrinkCaffeModel([MarshalAs(UnmanagedType.LPStr)] System.String src , [MarshalAs(UnmanagedType.LPStr)] System.String dst )
{
	bool isExc = NativeMethodsExc.dnn_shrinkCaffeModel_excsafe(src, dst);

	if(isExc)
		handleException();
}


public static  System.IntPtr dnn_Net_new()
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.dnn_Net_new_excsafe(ref ret);

	if(isExc)
		handleException();
	return ret;
}


public static  void dnn_Net_delete( System.IntPtr net )
{
	bool isExc = NativeMethodsExc.dnn_Net_delete_excsafe(net);

	if(isExc)
		handleException();
}


public static  System.Int32 dnn_Net_empty( System.IntPtr net )
{
	System.Int32 ret = new System.Int32();
	bool isExc = NativeMethodsExc.dnn_Net_empty_excsafe(ref ret, net);

	if(isExc)
		handleException();
	return ret;
}


public static  System.Int32 dnn_Net_getLayerId( System.IntPtr net , [MarshalAs(UnmanagedType.LPStr)] System.String layer )
{
	System.Int32 ret = new System.Int32();
	bool isExc = NativeMethodsExc.dnn_Net_getLayerId_excsafe(ref ret, net, layer);

	if(isExc)
		handleException();
	return ret;
}


public static  void dnn_Net_getLayerNames( System.IntPtr net ,  System.IntPtr outVec )
{
	bool isExc = NativeMethodsExc.dnn_Net_getLayerNames_excsafe(net, outVec);

	if(isExc)
		handleException();
}


public static  void dnn_Net_connect1( System.IntPtr net , [MarshalAs(UnmanagedType.LPStr)] System.String outPin , [MarshalAs(UnmanagedType.LPStr)] System.String inpPin )
{
	bool isExc = NativeMethodsExc.dnn_Net_connect1_excsafe(net, outPin, inpPin);

	if(isExc)
		handleException();
}


public static  void dnn_Net_connect2( System.IntPtr net ,  System.Int32 outLayerId ,  System.Int32 outNum ,  System.Int32 inpLayerId ,  System.Int32 inpNum )
{
	bool isExc = NativeMethodsExc.dnn_Net_connect2_excsafe(net, outLayerId, outNum, inpLayerId, inpNum);

	if(isExc)
		handleException();
}


public static  void dnn_Net_setInputsNames( System.IntPtr net ,  System.String[] inputBlobNames ,  System.Int32 inputBlobNamesLength )
{
	bool isExc = NativeMethodsExc.dnn_Net_setInputsNames_excsafe(net, inputBlobNames, inputBlobNamesLength);

	if(isExc)
		handleException();
}


public static  System.IntPtr dnn_Net_forward1( System.IntPtr net , [MarshalAs(UnmanagedType.LPStr)] System.String outputName )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.dnn_Net_forward1_excsafe(ref ret, net, outputName);

	if(isExc)
		handleException();
	return ret;
}


public static  void dnn_Net_forward2( System.IntPtr net ,  System.IntPtr[] outputBlobs ,  System.Int32 outputBlobsLength , [MarshalAs(UnmanagedType.LPStr)] System.String outputName )
{
	bool isExc = NativeMethodsExc.dnn_Net_forward2_excsafe(net, outputBlobs, outputBlobsLength, outputName);

	if(isExc)
		handleException();
}


public static  void dnn_Net_forward3( System.IntPtr net ,  System.IntPtr[] outputBlobs ,  System.Int32 outputBlobsLength ,  System.String[] outBlobNames ,  System.Int32 outBlobNamesLength )
{
	bool isExc = NativeMethodsExc.dnn_Net_forward3_excsafe(net, outputBlobs, outputBlobsLength, outBlobNames, outBlobNamesLength);

	if(isExc)
		handleException();
}


public static  void dnn_Net_setHalideScheduler( System.IntPtr net , [MarshalAs(UnmanagedType.LPStr)] System.String scheduler )
{
	bool isExc = NativeMethodsExc.dnn_Net_setHalideScheduler_excsafe(net, scheduler);

	if(isExc)
		handleException();
}


public static  void dnn_Net_setPreferableBackend( System.IntPtr net ,  System.Int32 backendId )
{
	bool isExc = NativeMethodsExc.dnn_Net_setPreferableBackend_excsafe(net, backendId);

	if(isExc)
		handleException();
}


public static  void dnn_Net_setPreferableTarget( System.IntPtr net ,  System.Int32 targetId )
{
	bool isExc = NativeMethodsExc.dnn_Net_setPreferableTarget_excsafe(net, targetId);

	if(isExc)
		handleException();
}


public static  void dnn_Net_setInput( System.IntPtr net ,  System.IntPtr blob , [MarshalAs(UnmanagedType.LPStr)] System.String name )
{
	bool isExc = NativeMethodsExc.dnn_Net_setInput_excsafe(net, blob, name);

	if(isExc)
		handleException();
}


public static  void dnn_Net_enableFusion( System.IntPtr net ,  System.Int32 fusion )
{
	bool isExc = NativeMethodsExc.dnn_Net_enableFusion_excsafe(net, fusion);

	if(isExc)
		handleException();
}


public static  System.Int64 dnn_Net_getPerfProfile( System.IntPtr net ,  System.IntPtr timings )
{
	System.Int64 ret = new System.Int64();
	bool isExc = NativeMethodsExc.dnn_Net_getPerfProfile_excsafe(ref ret, net, timings);

	if(isExc)
		handleException();
	return ret;
}


public static  System.Int32 face_BasicFaceRecognizer_getNumComponents( System.IntPtr obj )
{
	System.Int32 ret = new System.Int32();
	bool isExc = NativeMethodsExc.face_BasicFaceRecognizer_getNumComponents_excsafe(ref ret, obj);

	if(isExc)
		handleException();
	return ret;
}


public static  void face_BasicFaceRecognizer_setNumComponents( System.IntPtr obj ,  System.Int32 val )
{
	bool isExc = NativeMethodsExc.face_BasicFaceRecognizer_setNumComponents_excsafe(obj, val);

	if(isExc)
		handleException();
}


public static  System.Double face_BasicFaceRecognizer_getThreshold( System.IntPtr obj )
{
	System.Double ret = new System.Double();
	bool isExc = NativeMethodsExc.face_BasicFaceRecognizer_getThreshold_excsafe(ref ret, obj);

	if(isExc)
		handleException();
	return ret;
}


public static  void face_BasicFaceRecognizer_setThreshold( System.IntPtr obj ,  System.Double val )
{
	bool isExc = NativeMethodsExc.face_BasicFaceRecognizer_setThreshold_excsafe(obj, val);

	if(isExc)
		handleException();
}


public static  void face_BasicFaceRecognizer_getProjections( System.IntPtr obj ,  System.IntPtr dst )
{
	bool isExc = NativeMethodsExc.face_BasicFaceRecognizer_getProjections_excsafe(obj, dst);

	if(isExc)
		handleException();
}


public static  void face_BasicFaceRecognizer_getLabels( System.IntPtr obj ,  System.IntPtr dst )
{
	bool isExc = NativeMethodsExc.face_BasicFaceRecognizer_getLabels_excsafe(obj, dst);

	if(isExc)
		handleException();
}


public static  void face_BasicFaceRecognizer_getEigenValues( System.IntPtr obj ,  System.IntPtr dst )
{
	bool isExc = NativeMethodsExc.face_BasicFaceRecognizer_getEigenValues_excsafe(obj, dst);

	if(isExc)
		handleException();
}


public static  void face_BasicFaceRecognizer_getEigenVectors( System.IntPtr obj ,  System.IntPtr dst )
{
	bool isExc = NativeMethodsExc.face_BasicFaceRecognizer_getEigenVectors_excsafe(obj, dst);

	if(isExc)
		handleException();
}


public static  void cuda_GpuMat_convertTo( System.IntPtr obj ,  System.IntPtr m ,  System.Int32 rtype ,  System.Double alpha ,  System.Double beta )
{
	bool isExc = NativeMethodsExc.cuda_GpuMat_convertTo_excsafe(obj, m, rtype, alpha, beta);

	if(isExc)
		handleException();
}


public static  void cuda_GpuMat_assignTo( System.IntPtr obj ,  System.IntPtr m ,  System.Int32 type )
{
	bool isExc = NativeMethodsExc.cuda_GpuMat_assignTo_excsafe(obj, m, type);

	if(isExc)
		handleException();
}


public static  System.IntPtr cuda_GpuMat_setTo( System.IntPtr obj ,  OpenCvSharp.Scalar s ,  System.IntPtr mask )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.cuda_GpuMat_setTo_excsafe(ref ret, obj, s, mask);

	if(isExc)
		handleException();
	return ret;
}


public static  System.IntPtr cuda_GpuMat_reshape( System.IntPtr obj ,  System.Int32 cn ,  System.Int32 rows )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.cuda_GpuMat_reshape_excsafe(ref ret, obj, cn, rows);

	if(isExc)
		handleException();
	return ret;
}


public static  void cuda_GpuMat_create1( System.IntPtr obj ,  System.Int32 rows ,  System.Int32 cols ,  System.Int32 type )
{
	bool isExc = NativeMethodsExc.cuda_GpuMat_create1_excsafe(obj, rows, cols, type);

	if(isExc)
		handleException();
}


public static  void cuda_GpuMat_create2( System.IntPtr obj ,  OpenCvSharp.Size size ,  System.Int32 type )
{
	bool isExc = NativeMethodsExc.cuda_GpuMat_create2_excsafe(obj, size, type);

	if(isExc)
		handleException();
}


public static  void cuda_GpuMat_release( System.IntPtr obj )
{
	bool isExc = NativeMethodsExc.cuda_GpuMat_release_excsafe(obj);

	if(isExc)
		handleException();
}


public static  void cuda_GpuMat_swap( System.IntPtr obj ,  System.IntPtr mat )
{
	bool isExc = NativeMethodsExc.cuda_GpuMat_swap_excsafe(obj, mat);

	if(isExc)
		handleException();
}


public static  void cuda_GpuMat_locateROI( System.IntPtr obj ,  out OpenCvSharp.Size wholeSize ,  out OpenCvSharp.Point ofs )
{
	bool isExc = NativeMethodsExc.cuda_GpuMat_locateROI_excsafe(obj,  out wholeSize,  out ofs);

	if(isExc)
		handleException();
}


public static  System.IntPtr cuda_GpuMat_adjustROI( System.IntPtr obj ,  System.Int32 dtop ,  System.Int32 dbottom ,  System.Int32 dleft ,  System.Int32 drightt )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.cuda_GpuMat_adjustROI_excsafe(ref ret, obj, dtop, dbottom, dleft, drightt);

	if(isExc)
		handleException();
	return ret;
}


public static  System.Int32 cuda_GpuMat_isContinuous( System.IntPtr obj )
{
	System.Int32 ret = new System.Int32();
	bool isExc = NativeMethodsExc.cuda_GpuMat_isContinuous_excsafe(ref ret, obj);

	if(isExc)
		handleException();
	return ret;
}


public static  System.UInt64 cuda_GpuMat_elemSize( System.IntPtr obj )
{
	System.UInt64 ret = new System.UInt64();
	bool isExc = NativeMethodsExc.cuda_GpuMat_elemSize_excsafe(ref ret, obj);

	if(isExc)
		handleException();
	return ret;
}


public static  System.UInt64 cuda_GpuMat_elemSize1( System.IntPtr obj )
{
	System.UInt64 ret = new System.UInt64();
	bool isExc = NativeMethodsExc.cuda_GpuMat_elemSize1_excsafe(ref ret, obj);

	if(isExc)
		handleException();
	return ret;
}


public static  System.Int32 cuda_GpuMat_type( System.IntPtr obj )
{
	System.Int32 ret = new System.Int32();
	bool isExc = NativeMethodsExc.cuda_GpuMat_type_excsafe(ref ret, obj);

	if(isExc)
		handleException();
	return ret;
}


public static  System.Int32 cuda_GpuMat_depth( System.IntPtr obj )
{
	System.Int32 ret = new System.Int32();
	bool isExc = NativeMethodsExc.cuda_GpuMat_depth_excsafe(ref ret, obj);

	if(isExc)
		handleException();
	return ret;
}


public static  System.Int32 cuda_GpuMat_channels( System.IntPtr obj )
{
	System.Int32 ret = new System.Int32();
	bool isExc = NativeMethodsExc.cuda_GpuMat_channels_excsafe(ref ret, obj);

	if(isExc)
		handleException();
	return ret;
}


public static  System.UInt64 cuda_GpuMat_step1( System.IntPtr obj )
{
	System.UInt64 ret = new System.UInt64();
	bool isExc = NativeMethodsExc.cuda_GpuMat_step1_excsafe(ref ret, obj);

	if(isExc)
		handleException();
	return ret;
}


public static  OpenCvSharp.Size cuda_GpuMat_size( System.IntPtr obj )
{
	OpenCvSharp.Size ret = new OpenCvSharp.Size();
	bool isExc = NativeMethodsExc.cuda_GpuMat_size_excsafe(ref ret, obj);

	if(isExc)
		handleException();
	return ret;
}


public static  System.Int32 cuda_GpuMat_empty( System.IntPtr obj )
{
	System.Int32 ret = new System.Int32();
	bool isExc = NativeMethodsExc.cuda_GpuMat_empty_excsafe(ref ret, obj);

	if(isExc)
		handleException();
	return ret;
}


public static  unsafe System.Byte* cuda_GpuMat_ptr( System.IntPtr obj ,  System.Int32 y )
{
	IntPtr ret = new IntPtr();
	bool isExc = NativeMethodsExc.cuda_GpuMat_ptr_excsafe(ref ret, obj, y);

	if(isExc)
		handleException();
	return (System.Byte*)ret;
}


public static  void cuda_createContinuous1( System.Int32 rows ,  System.Int32 cols ,  System.Int32 type ,  System.IntPtr gm )
{
	bool isExc = NativeMethodsExc.cuda_createContinuous1_excsafe(rows, cols, type, gm);

	if(isExc)
		handleException();
}


public static  System.IntPtr cuda_createContinuous2( System.Int32 rows ,  System.Int32 cols ,  System.Int32 type )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.cuda_createContinuous2_excsafe(ref ret, rows, cols, type);

	if(isExc)
		handleException();
	return ret;
}


public static  void cuda_ensureSizeIsEnough( System.Int32 rows ,  System.Int32 cols ,  System.Int32 type ,  System.IntPtr m )
{
	bool isExc = NativeMethodsExc.cuda_ensureSizeIsEnough_excsafe(rows, cols, type, m);

	if(isExc)
		handleException();
}


public static  System.IntPtr dnn_readNetFromDarknet([MarshalAs(UnmanagedType.LPStr)] System.String cfgFile , [MarshalAs(UnmanagedType.LPStr)] System.String darknetModel )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.dnn_readNetFromDarknet_excsafe(ref ret, cfgFile, darknetModel);

	if(isExc)
		handleException();
	return ret;
}


public static  System.IntPtr dnn_readNetFromCaffe([MarshalAs(UnmanagedType.LPStr)] System.String prototxt , [MarshalAs(UnmanagedType.LPStr)] System.String caffeModel )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.dnn_readNetFromCaffe_excsafe(ref ret, prototxt, caffeModel);

	if(isExc)
		handleException();
	return ret;
}


public static  System.IntPtr dnn_readNetFromTensorflow([MarshalAs(UnmanagedType.LPStr)] System.String model , [MarshalAs(UnmanagedType.LPStr)] System.String config )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.dnn_readNetFromTensorflow_excsafe(ref ret, model, config);

	if(isExc)
		handleException();
	return ret;
}


public static  System.IntPtr dnn_readNetFromTorch([MarshalAs(UnmanagedType.LPStr)] System.String model ,  System.Int32 isBinary )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.dnn_readNetFromTorch_excsafe(ref ret, model, isBinary);

	if(isExc)
		handleException();
	return ret;
}


public static  System.IntPtr dnn_readTorchBlob([MarshalAs(UnmanagedType.LPStr)] System.String filename ,  System.Int32 isBinary )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.dnn_readTorchBlob_excsafe(ref ret, filename, isBinary);

	if(isExc)
		handleException();
	return ret;
}


public static  System.IntPtr cuda_GpuMat_new6( OpenCvSharp.Size size ,  System.Int32 type )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.cuda_GpuMat_new6_excsafe(ref ret, size, type);

	if(isExc)
		handleException();
	return ret;
}


public static  System.IntPtr cuda_GpuMat_new7( OpenCvSharp.Size size ,  System.Int32 type ,  System.IntPtr data ,  System.UInt64 step )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.cuda_GpuMat_new7_excsafe(ref ret, size, type, data, step);

	if(isExc)
		handleException();
	return ret;
}


public static  System.IntPtr cuda_GpuMat_new8( System.Int32 rows ,  System.Int32 cols ,  System.Int32 type ,  OpenCvSharp.Scalar s )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.cuda_GpuMat_new8_excsafe(ref ret, rows, cols, type, s);

	if(isExc)
		handleException();
	return ret;
}


public static  System.IntPtr cuda_GpuMat_new9( System.IntPtr m ,  OpenCvSharp.Range rowRange ,  OpenCvSharp.Range colRange )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.cuda_GpuMat_new9_excsafe(ref ret, m, rowRange, colRange);

	if(isExc)
		handleException();
	return ret;
}


public static  System.IntPtr cuda_GpuMat_new10( System.IntPtr m ,  OpenCvSharp.Rect roi )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.cuda_GpuMat_new10_excsafe(ref ret, m, roi);

	if(isExc)
		handleException();
	return ret;
}


public static  System.IntPtr cuda_GpuMat_new11( OpenCvSharp.Size size ,  System.Int32 type ,  OpenCvSharp.Scalar s )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.cuda_GpuMat_new11_excsafe(ref ret, size, type, s);

	if(isExc)
		handleException();
	return ret;
}


public static  System.IntPtr cuda_GpuMat_opToMat( System.IntPtr src )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.cuda_GpuMat_opToMat_excsafe(ref ret, src);

	if(isExc)
		handleException();
	return ret;
}


public static  System.IntPtr cuda_GpuMat_opToGpuMat( System.IntPtr src )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.cuda_GpuMat_opToGpuMat_excsafe(ref ret, src);

	if(isExc)
		handleException();
	return ret;
}


public static  void cuda_GpuMat_opAssign( System.IntPtr left ,  System.IntPtr right )
{
	bool isExc = NativeMethodsExc.cuda_GpuMat_opAssign_excsafe(left, right);

	if(isExc)
		handleException();
}


public static  System.IntPtr cuda_GpuMat_opRange1( System.IntPtr src ,  OpenCvSharp.Rect roi )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.cuda_GpuMat_opRange1_excsafe(ref ret, src, roi);

	if(isExc)
		handleException();
	return ret;
}


public static  System.IntPtr cuda_GpuMat_opRange2( System.IntPtr src ,  OpenCvSharp.Range rowRange ,  OpenCvSharp.Range colRange )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.cuda_GpuMat_opRange2_excsafe(ref ret, src, rowRange, colRange);

	if(isExc)
		handleException();
	return ret;
}


public static  System.Int32 cuda_GpuMat_flags( System.IntPtr obj )
{
	System.Int32 ret = new System.Int32();
	bool isExc = NativeMethodsExc.cuda_GpuMat_flags_excsafe(ref ret, obj);

	if(isExc)
		handleException();
	return ret;
}


public static  System.Int32 cuda_GpuMat_rows( System.IntPtr obj )
{
	System.Int32 ret = new System.Int32();
	bool isExc = NativeMethodsExc.cuda_GpuMat_rows_excsafe(ref ret, obj);

	if(isExc)
		handleException();
	return ret;
}


public static  System.Int32 cuda_GpuMat_cols( System.IntPtr obj )
{
	System.Int32 ret = new System.Int32();
	bool isExc = NativeMethodsExc.cuda_GpuMat_cols_excsafe(ref ret, obj);

	if(isExc)
		handleException();
	return ret;
}


public static  System.UInt64 cuda_GpuMat_step( System.IntPtr obj )
{
	System.UInt64 ret = new System.UInt64();
	bool isExc = NativeMethodsExc.cuda_GpuMat_step_excsafe(ref ret, obj);

	if(isExc)
		handleException();
	return ret;
}


public static  unsafe System.Byte* cuda_GpuMat_data( System.IntPtr obj )
{
	IntPtr ret = new IntPtr();
	bool isExc = NativeMethodsExc.cuda_GpuMat_data_excsafe(ref ret, obj);

	if(isExc)
		handleException();
	return (System.Byte*)ret;
}


public static  System.IntPtr cuda_GpuMat_refcount( System.IntPtr obj )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.cuda_GpuMat_refcount_excsafe(ref ret, obj);

	if(isExc)
		handleException();
	return ret;
}


public static  System.IntPtr cuda_GpuMat_datastart( System.IntPtr obj )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.cuda_GpuMat_datastart_excsafe(ref ret, obj);

	if(isExc)
		handleException();
	return ret;
}


public static  System.IntPtr cuda_GpuMat_dataend( System.IntPtr obj )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.cuda_GpuMat_dataend_excsafe(ref ret, obj);

	if(isExc)
		handleException();
	return ret;
}


public static  void cuda_GpuMat_upload( System.IntPtr obj ,  System.IntPtr mat )
{
	bool isExc = NativeMethodsExc.cuda_GpuMat_upload_excsafe(obj, mat);

	if(isExc)
		handleException();
}


public static  void cuda_GpuMat_download( System.IntPtr obj ,  System.IntPtr mat )
{
	bool isExc = NativeMethodsExc.cuda_GpuMat_download_excsafe(obj, mat);

	if(isExc)
		handleException();
}


public static  System.IntPtr cuda_GpuMat_row( System.IntPtr obj ,  System.Int32 y )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.cuda_GpuMat_row_excsafe(ref ret, obj, y);

	if(isExc)
		handleException();
	return ret;
}


public static  System.IntPtr cuda_GpuMat_col( System.IntPtr obj ,  System.Int32 x )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.cuda_GpuMat_col_excsafe(ref ret, obj, x);

	if(isExc)
		handleException();
	return ret;
}


public static  System.IntPtr cuda_GpuMat_rowRange( System.IntPtr obj ,  System.Int32 startrow ,  System.Int32 endrow )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.cuda_GpuMat_rowRange_excsafe(ref ret, obj, startrow, endrow);

	if(isExc)
		handleException();
	return ret;
}


public static  System.IntPtr cuda_GpuMat_colRange( System.IntPtr obj ,  System.Int32 startcol ,  System.Int32 endcol )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.cuda_GpuMat_colRange_excsafe(ref ret, obj, startcol, endcol);

	if(isExc)
		handleException();
	return ret;
}


public static  System.IntPtr cuda_GpuMat_clone( System.IntPtr obj )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.cuda_GpuMat_clone_excsafe(ref ret, obj);

	if(isExc)
		handleException();
	return ret;
}


public static  void cuda_GpuMat_copyTo1( System.IntPtr obj ,  System.IntPtr m )
{
	bool isExc = NativeMethodsExc.cuda_GpuMat_copyTo1_excsafe(obj, m);

	if(isExc)
		handleException();
}


public static  void cuda_GpuMat_copyTo2( System.IntPtr obj ,  System.IntPtr m ,  System.IntPtr mask )
{
	bool isExc = NativeMethodsExc.cuda_GpuMat_copyTo2_excsafe(obj, m, mask);

	if(isExc)
		handleException();
}


public static  unsafe System.Int32* cuda_MOG2_GPU_history( System.IntPtr obj )
{
	IntPtr ret = new IntPtr();
	bool isExc = NativeMethodsExc.cuda_MOG2_GPU_history_excsafe(ref ret, obj);

	if(isExc)
		handleException();
	return (System.Int32*)ret;
}


public static  unsafe System.Single* cuda_MOG2_GPU_varThreshold( System.IntPtr obj )
{
	IntPtr ret = new IntPtr();
	bool isExc = NativeMethodsExc.cuda_MOG2_GPU_varThreshold_excsafe(ref ret, obj);

	if(isExc)
		handleException();
	return (System.Single*)ret;
}


public static  unsafe System.Single* cuda_MOG2_GPU_backgroundRatio( System.IntPtr obj )
{
	IntPtr ret = new IntPtr();
	bool isExc = NativeMethodsExc.cuda_MOG2_GPU_backgroundRatio_excsafe(ref ret, obj);

	if(isExc)
		handleException();
	return (System.Single*)ret;
}


public static  unsafe System.Single* cuda_MOG2_GPU_varThresholdGen( System.IntPtr obj )
{
	IntPtr ret = new IntPtr();
	bool isExc = NativeMethodsExc.cuda_MOG2_GPU_varThresholdGen_excsafe(ref ret, obj);

	if(isExc)
		handleException();
	return (System.Single*)ret;
}


public static  unsafe System.Single* cuda_MOG2_GPU_fVarInit( System.IntPtr obj )
{
	IntPtr ret = new IntPtr();
	bool isExc = NativeMethodsExc.cuda_MOG2_GPU_fVarInit_excsafe(ref ret, obj);

	if(isExc)
		handleException();
	return (System.Single*)ret;
}


public static  unsafe System.Single* cuda_MOG2_GPU_fVarMin( System.IntPtr obj )
{
	IntPtr ret = new IntPtr();
	bool isExc = NativeMethodsExc.cuda_MOG2_GPU_fVarMin_excsafe(ref ret, obj);

	if(isExc)
		handleException();
	return (System.Single*)ret;
}


public static  unsafe System.Single* cuda_MOG2_GPU_fVarMax( System.IntPtr obj )
{
	IntPtr ret = new IntPtr();
	bool isExc = NativeMethodsExc.cuda_MOG2_GPU_fVarMax_excsafe(ref ret, obj);

	if(isExc)
		handleException();
	return (System.Single*)ret;
}


public static  unsafe System.Single* cuda_MOG2_GPU_fCT( System.IntPtr obj )
{
	IntPtr ret = new IntPtr();
	bool isExc = NativeMethodsExc.cuda_MOG2_GPU_fCT_excsafe(ref ret, obj);

	if(isExc)
		handleException();
	return (System.Single*)ret;
}


public static  System.Int32 cuda_MOG2_GPU_bShadowDetection_get( System.IntPtr obj )
{
	System.Int32 ret = new System.Int32();
	bool isExc = NativeMethodsExc.cuda_MOG2_GPU_bShadowDetection_get_excsafe(ref ret, obj);

	if(isExc)
		handleException();
	return ret;
}


public static  void cuda_MOG2_GPU_bShadowDetection_set( System.IntPtr obj ,  System.Int32 value )
{
	bool isExc = NativeMethodsExc.cuda_MOG2_GPU_bShadowDetection_set_excsafe(obj, value);

	if(isExc)
		handleException();
}


public static  unsafe System.Byte* cuda_MOG2_GPU_nShadowDetection( System.IntPtr obj )
{
	IntPtr ret = new IntPtr();
	bool isExc = NativeMethodsExc.cuda_MOG2_GPU_nShadowDetection_excsafe(ref ret, obj);

	if(isExc)
		handleException();
	return (System.Byte*)ret;
}


public static  unsafe System.Single* cuda_MOG2_GPU_fTau( System.IntPtr obj )
{
	IntPtr ret = new IntPtr();
	bool isExc = NativeMethodsExc.cuda_MOG2_GPU_fTau_excsafe(ref ret, obj);

	if(isExc)
		handleException();
	return (System.Single*)ret;
}


public static  System.IntPtr cuda_StereoBM_GPU_new1()
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.cuda_StereoBM_GPU_new1_excsafe(ref ret);

	if(isExc)
		handleException();
	return ret;
}


public static  System.IntPtr cuda_StereoBM_GPU_new2( System.Int32 preset ,  System.Int32 ndisparities ,  System.Int32 winSize )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.cuda_StereoBM_GPU_new2_excsafe(ref ret, preset, ndisparities, winSize);

	if(isExc)
		handleException();
	return ret;
}


public static  void cuda_StereoBM_GPU_delete( System.IntPtr obj )
{
	bool isExc = NativeMethodsExc.cuda_StereoBM_GPU_delete_excsafe(obj);

	if(isExc)
		handleException();
}


public static  void cuda_StereoBM_GPU_run1( System.IntPtr obj ,  System.IntPtr left ,  System.IntPtr right ,  System.IntPtr disparity )
{
	bool isExc = NativeMethodsExc.cuda_StereoBM_GPU_run1_excsafe(obj, left, right, disparity);

	if(isExc)
		handleException();
}


public static  void cuda_StereoBM_GPU_run2( System.IntPtr obj ,  System.IntPtr left ,  System.IntPtr right ,  System.IntPtr disparity ,  System.IntPtr stream )
{
	bool isExc = NativeMethodsExc.cuda_StereoBM_GPU_run2_excsafe(obj, left, right, disparity, stream);

	if(isExc)
		handleException();
}


public static  System.Int32 cuda_StereoBM_GPU_checkIfGpuCallReasonable()
{
	System.Int32 ret = new System.Int32();
	bool isExc = NativeMethodsExc.cuda_StereoBM_GPU_checkIfGpuCallReasonable_excsafe(ref ret);

	if(isExc)
		handleException();
	return ret;
}


public static  unsafe System.Int32* cuda_StereoBM_GPU_preset( System.IntPtr obj )
{
	IntPtr ret = new IntPtr();
	bool isExc = NativeMethodsExc.cuda_StereoBM_GPU_preset_excsafe(ref ret, obj);

	if(isExc)
		handleException();
	return (System.Int32*)ret;
}


public static  unsafe System.Int32* cuda_StereoBM_GPU_ndisp( System.IntPtr obj )
{
	IntPtr ret = new IntPtr();
	bool isExc = NativeMethodsExc.cuda_StereoBM_GPU_ndisp_excsafe(ref ret, obj);

	if(isExc)
		handleException();
	return (System.Int32*)ret;
}


public static  unsafe System.Int32* cuda_StereoBM_GPU_winSize( System.IntPtr obj )
{
	IntPtr ret = new IntPtr();
	bool isExc = NativeMethodsExc.cuda_StereoBM_GPU_winSize_excsafe(ref ret, obj);

	if(isExc)
		handleException();
	return (System.Int32*)ret;
}


public static  unsafe System.Single* cuda_StereoBM_GPU_avergeTexThreshold( System.IntPtr obj )
{
	IntPtr ret = new IntPtr();
	bool isExc = NativeMethodsExc.cuda_StereoBM_GPU_avergeTexThreshold_excsafe(ref ret, obj);

	if(isExc)
		handleException();
	return (System.Single*)ret;
}


public static  void cuda_GpuMat_delete( System.IntPtr obj )
{
	bool isExc = NativeMethodsExc.cuda_GpuMat_delete_excsafe(obj);

	if(isExc)
		handleException();
}


public static  System.IntPtr cuda_GpuMat_new1()
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.cuda_GpuMat_new1_excsafe(ref ret);

	if(isExc)
		handleException();
	return ret;
}


public static  System.IntPtr cuda_GpuMat_new2( System.Int32 rows ,  System.Int32 cols ,  System.Int32 type )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.cuda_GpuMat_new2_excsafe(ref ret, rows, cols, type);

	if(isExc)
		handleException();
	return ret;
}


public static  System.IntPtr cuda_GpuMat_new3( System.Int32 rows ,  System.Int32 cols ,  System.Int32 type ,  System.IntPtr data ,  System.UInt64 step )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.cuda_GpuMat_new3_excsafe(ref ret, rows, cols, type, data, step);

	if(isExc)
		handleException();
	return ret;
}


public static  System.IntPtr cuda_GpuMat_new4( System.IntPtr mat )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.cuda_GpuMat_new4_excsafe(ref ret, mat);

	if(isExc)
		handleException();
	return ret;
}


public static  System.IntPtr cuda_GpuMat_new5( System.IntPtr gpumat )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.cuda_GpuMat_new5_excsafe(ref ret, gpumat);

	if(isExc)
		handleException();
	return ret;
}


public static  System.Double HOGDescriptor_threshold_L2hys_get( System.IntPtr obj )
{
	System.Double ret = new System.Double();
	bool isExc = NativeMethodsExc.HOGDescriptor_threshold_L2hys_get_excsafe(ref ret, obj);

	if(isExc)
		handleException();
	return ret;
}


public static  System.Int32 HOGDescriptor_nlevels_get( System.IntPtr obj )
{
	System.Int32 ret = new System.Int32();
	bool isExc = NativeMethodsExc.HOGDescriptor_nlevels_get_excsafe(ref ret, obj);

	if(isExc)
		handleException();
	return ret;
}


public static  System.Int32 HOGDescriptor_gamma_correction_get( System.IntPtr obj )
{
	System.Int32 ret = new System.Int32();
	bool isExc = NativeMethodsExc.HOGDescriptor_gamma_correction_get_excsafe(ref ret, obj);

	if(isExc)
		handleException();
	return ret;
}


public static  void HOGDescriptor_win_size_set( System.IntPtr obj ,  OpenCvSharp.Size value )
{
	bool isExc = NativeMethodsExc.HOGDescriptor_win_size_set_excsafe(obj, value);

	if(isExc)
		handleException();
}


public static  void HOGDescriptor_block_size_set( System.IntPtr obj ,  OpenCvSharp.Size value )
{
	bool isExc = NativeMethodsExc.HOGDescriptor_block_size_set_excsafe(obj, value);

	if(isExc)
		handleException();
}


public static  void HOGDescriptor_block_stride_set( System.IntPtr obj ,  OpenCvSharp.Size value )
{
	bool isExc = NativeMethodsExc.HOGDescriptor_block_stride_set_excsafe(obj, value);

	if(isExc)
		handleException();
}


public static  void HOGDescriptor_cell_size_set( System.IntPtr obj ,  OpenCvSharp.Size value )
{
	bool isExc = NativeMethodsExc.HOGDescriptor_cell_size_set_excsafe(obj, value);

	if(isExc)
		handleException();
}


public static  void HOGDescriptor_nbins_set( System.IntPtr obj ,  System.Int32 value )
{
	bool isExc = NativeMethodsExc.HOGDescriptor_nbins_set_excsafe(obj, value);

	if(isExc)
		handleException();
}


public static  void HOGDescriptor_win_sigma_set( System.IntPtr obj ,  System.Double value )
{
	bool isExc = NativeMethodsExc.HOGDescriptor_win_sigma_set_excsafe(obj, value);

	if(isExc)
		handleException();
}


public static  void HOGDescriptor_threshold_L2hys_set( System.IntPtr obj ,  System.Double value )
{
	bool isExc = NativeMethodsExc.HOGDescriptor_threshold_L2hys_set_excsafe(obj, value);

	if(isExc)
		handleException();
}


public static  void HOGDescriptor_nlevels_set( System.IntPtr obj ,  System.Int32 value )
{
	bool isExc = NativeMethodsExc.HOGDescriptor_nlevels_set_excsafe(obj, value);

	if(isExc)
		handleException();
}


public static  void HOGDescriptor_gamma_correction_set( System.IntPtr obj ,  System.Int32 value )
{
	bool isExc = NativeMethodsExc.HOGDescriptor_gamma_correction_set_excsafe(obj, value);

	if(isExc)
		handleException();
}


public static  void cuda_MOG_GPU_delete( System.IntPtr obj )
{
	bool isExc = NativeMethodsExc.cuda_MOG_GPU_delete_excsafe(obj);

	if(isExc)
		handleException();
}


public static  System.IntPtr cuda_MOG_GPU_new( System.Int32 nmixtures )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.cuda_MOG_GPU_new_excsafe(ref ret, nmixtures);

	if(isExc)
		handleException();
	return ret;
}


public static  void cuda_MOG_GPU_initialize( System.IntPtr obj ,  OpenCvSharp.Size frameSize ,  System.Int32 frameType )
{
	bool isExc = NativeMethodsExc.cuda_MOG_GPU_initialize_excsafe(obj, frameSize, frameType);

	if(isExc)
		handleException();
}


public static  void cuda_MOG_GPU_operator( System.IntPtr obj ,  System.IntPtr frame ,  System.IntPtr fgmask ,  System.Single learningRate ,  System.IntPtr stream )
{
	bool isExc = NativeMethodsExc.cuda_MOG_GPU_operator_excsafe(obj, frame, fgmask, learningRate, stream);

	if(isExc)
		handleException();
}


public static  void cuda_MOG_GPU_getBackgroundImage( System.IntPtr obj ,  System.IntPtr backgroundImage ,  System.IntPtr stream )
{
	bool isExc = NativeMethodsExc.cuda_MOG_GPU_getBackgroundImage_excsafe(obj, backgroundImage, stream);

	if(isExc)
		handleException();
}


public static  void cuda_MOG_GPU_release( System.IntPtr obj )
{
	bool isExc = NativeMethodsExc.cuda_MOG_GPU_release_excsafe(obj);

	if(isExc)
		handleException();
}


public static  unsafe System.Int32* cuda_MOG_GPU_history( System.IntPtr obj )
{
	IntPtr ret = new IntPtr();
	bool isExc = NativeMethodsExc.cuda_MOG_GPU_history_excsafe(ref ret, obj);

	if(isExc)
		handleException();
	return (System.Int32*)ret;
}


public static  unsafe System.Single* cuda_MOG_GPU_varThreshold( System.IntPtr obj )
{
	IntPtr ret = new IntPtr();
	bool isExc = NativeMethodsExc.cuda_MOG_GPU_varThreshold_excsafe(ref ret, obj);

	if(isExc)
		handleException();
	return (System.Single*)ret;
}


public static  unsafe System.Single* cuda_MOG_GPU_backgroundRatio( System.IntPtr obj )
{
	IntPtr ret = new IntPtr();
	bool isExc = NativeMethodsExc.cuda_MOG_GPU_backgroundRatio_excsafe(ref ret, obj);

	if(isExc)
		handleException();
	return (System.Single*)ret;
}


public static  unsafe System.Single* cuda_MOG_GPU_noiseSigma( System.IntPtr obj )
{
	IntPtr ret = new IntPtr();
	bool isExc = NativeMethodsExc.cuda_MOG_GPU_noiseSigma_excsafe(ref ret, obj);

	if(isExc)
		handleException();
	return (System.Single*)ret;
}


public static  void cuda_MOG2_GPU_delete( System.IntPtr obj )
{
	bool isExc = NativeMethodsExc.cuda_MOG2_GPU_delete_excsafe(obj);

	if(isExc)
		handleException();
}


public static  System.IntPtr cuda_MOG2_GPU_new( System.Int32 nmixtures )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.cuda_MOG2_GPU_new_excsafe(ref ret, nmixtures);

	if(isExc)
		handleException();
	return ret;
}


public static  void cuda_MOG2_GPU_initialize( System.IntPtr obj ,  OpenCvSharp.Size frameSize ,  System.Int32 frameType )
{
	bool isExc = NativeMethodsExc.cuda_MOG2_GPU_initialize_excsafe(obj, frameSize, frameType);

	if(isExc)
		handleException();
}


public static  void cuda_MOG2_GPU_operator( System.IntPtr obj ,  System.IntPtr frame ,  System.IntPtr fgmask ,  System.Single learningRate ,  System.IntPtr stream )
{
	bool isExc = NativeMethodsExc.cuda_MOG2_GPU_operator_excsafe(obj, frame, fgmask, learningRate, stream);

	if(isExc)
		handleException();
}


public static  void cuda_MOG2_GPU_getBackgroundImage( System.IntPtr obj ,  System.IntPtr backgroundImage ,  System.IntPtr stream )
{
	bool isExc = NativeMethodsExc.cuda_MOG2_GPU_getBackgroundImage_excsafe(obj, backgroundImage, stream);

	if(isExc)
		handleException();
}


public static  void cuda_MOG2_GPU_release( System.IntPtr obj )
{
	bool isExc = NativeMethodsExc.cuda_MOG2_GPU_release_excsafe(obj);

	if(isExc)
		handleException();
}


public static  System.IntPtr cuda_CascadeClassifier_GPU_new2( System.String filename )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.cuda_CascadeClassifier_GPU_new2_excsafe(ref ret, filename);

	if(isExc)
		handleException();
	return ret;
}


public static  System.Int32 cuda_CascadeClassifier_GPU_empty( System.IntPtr obj )
{
	System.Int32 ret = new System.Int32();
	bool isExc = NativeMethodsExc.cuda_CascadeClassifier_GPU_empty_excsafe(ref ret, obj);

	if(isExc)
		handleException();
	return ret;
}


public static  System.Int32 cuda_CascadeClassifier_GPU_load( System.IntPtr obj ,  System.String filename )
{
	System.Int32 ret = new System.Int32();
	bool isExc = NativeMethodsExc.cuda_CascadeClassifier_GPU_load_excsafe(ref ret, obj, filename);

	if(isExc)
		handleException();
	return ret;
}


public static  void cuda_CascadeClassifier_GPU_release( System.IntPtr obj )
{
	bool isExc = NativeMethodsExc.cuda_CascadeClassifier_GPU_release_excsafe(obj);

	if(isExc)
		handleException();
}


public static  System.Int32 cuda_CascadeClassifier_GPU_detectMultiScale1( System.IntPtr obj ,  System.IntPtr image ,  System.IntPtr objectsBuf ,  System.Double scaleFactor ,  System.Int32 minNeighbors ,  OpenCvSharp.Size minSize )
{
	System.Int32 ret = new System.Int32();
	bool isExc = NativeMethodsExc.cuda_CascadeClassifier_GPU_detectMultiScale1_excsafe(ref ret, obj, image, objectsBuf, scaleFactor, minNeighbors, minSize);

	if(isExc)
		handleException();
	return ret;
}


public static  System.Int32 cuda_CascadeClassifier_GPU_detectMultiScale2( System.IntPtr obj ,  System.IntPtr image ,  System.IntPtr objectsBuf ,  OpenCvSharp.Size maxObjectSize ,  OpenCvSharp.Size minSize ,  System.Double scaleFactor ,  System.Int32 minNeighbors )
{
	System.Int32 ret = new System.Int32();
	bool isExc = NativeMethodsExc.cuda_CascadeClassifier_GPU_detectMultiScale2_excsafe(ref ret, obj, image, objectsBuf, maxObjectSize, minSize, scaleFactor, minNeighbors);

	if(isExc)
		handleException();
	return ret;
}


public static  System.Int32 cuda_CascadeClassifier_GPU_findLargestObject_get( System.IntPtr obj )
{
	System.Int32 ret = new System.Int32();
	bool isExc = NativeMethodsExc.cuda_CascadeClassifier_GPU_findLargestObject_get_excsafe(ref ret, obj);

	if(isExc)
		handleException();
	return ret;
}


public static  void cuda_CascadeClassifier_GPU_findLargestObject_set( System.IntPtr obj ,  System.Int32 value )
{
	bool isExc = NativeMethodsExc.cuda_CascadeClassifier_GPU_findLargestObject_set_excsafe(obj, value);

	if(isExc)
		handleException();
}


public static  System.Int32 cuda_CascadeClassifier_GPU_visualizeInPlace_get( System.IntPtr obj )
{
	System.Int32 ret = new System.Int32();
	bool isExc = NativeMethodsExc.cuda_CascadeClassifier_GPU_visualizeInPlace_get_excsafe(ref ret, obj);

	if(isExc)
		handleException();
	return ret;
}


public static  void cuda_CascadeClassifier_GPU_visualizeInPlace_set( System.IntPtr obj ,  System.Int32 value )
{
	bool isExc = NativeMethodsExc.cuda_CascadeClassifier_GPU_visualizeInPlace_set_excsafe(obj, value);

	if(isExc)
		handleException();
}


public static  OpenCvSharp.Size cuda_CascadeClassifier_GPU_getClassifierSize( System.IntPtr obj )
{
	OpenCvSharp.Size ret = new OpenCvSharp.Size();
	bool isExc = NativeMethodsExc.cuda_CascadeClassifier_GPU_getClassifierSize_excsafe(ref ret, obj);

	if(isExc)
		handleException();
	return ret;
}


public static  System.Int32 HOGDescriptor_sizeof()
{
	System.Int32 ret = new System.Int32();
	bool isExc = NativeMethodsExc.HOGDescriptor_sizeof_excsafe(ref ret);

	if(isExc)
		handleException();
	return ret;
}


public static  System.IntPtr HOGDescriptor_new( OpenCvSharp.Size win_size ,  OpenCvSharp.Size block_size ,  OpenCvSharp.Size block_stride ,  OpenCvSharp.Size cell_size ,  System.Int32 nbins ,  System.Double winSigma ,  System.Double threshold_L2Hys ,  System.Boolean gamma_correction ,  System.Int32 nlevels )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.HOGDescriptor_new_excsafe(ref ret, win_size, block_size, block_stride, cell_size, nbins, winSigma, threshold_L2Hys, gamma_correction, nlevels);

	if(isExc)
		handleException();
	return ret;
}


public static  void HOGDescriptor_delete( System.IntPtr obj )
{
	bool isExc = NativeMethodsExc.HOGDescriptor_delete_excsafe(obj);

	if(isExc)
		handleException();
}


public static  System.UInt64 HOGDescriptor_getDescriptorSize( System.IntPtr obj )
{
	System.UInt64 ret = new System.UInt64();
	bool isExc = NativeMethodsExc.HOGDescriptor_getDescriptorSize_excsafe(ref ret, obj);

	if(isExc)
		handleException();
	return ret;
}


public static  System.UInt64 HOGDescriptor_getBlockHistogramSize( System.IntPtr obj )
{
	System.UInt64 ret = new System.UInt64();
	bool isExc = NativeMethodsExc.HOGDescriptor_getBlockHistogramSize_excsafe(ref ret, obj);

	if(isExc)
		handleException();
	return ret;
}


public static  System.Int32 HOGDescriptor_checkDetectorSize( System.IntPtr obj )
{
	System.Int32 ret = new System.Int32();
	bool isExc = NativeMethodsExc.HOGDescriptor_checkDetectorSize_excsafe(ref ret, obj);

	if(isExc)
		handleException();
	return ret;
}


public static  System.Double HOGDescriptor_getWinSigma( System.IntPtr obj )
{
	System.Double ret = new System.Double();
	bool isExc = NativeMethodsExc.HOGDescriptor_getWinSigma_excsafe(ref ret, obj);

	if(isExc)
		handleException();
	return ret;
}


public static  void HOGDescriptor_setSVMDetector( System.IntPtr obj ,  System.IntPtr svmdetector )
{
	bool isExc = NativeMethodsExc.HOGDescriptor_setSVMDetector_excsafe(obj, svmdetector);

	if(isExc)
		handleException();
}


public static  void HOGDescriptor_detect( System.IntPtr obj ,  System.IntPtr img ,  System.IntPtr found_locations ,  System.Double hit_threshold ,  OpenCvSharp.Size win_stride ,  OpenCvSharp.Size padding )
{
	bool isExc = NativeMethodsExc.HOGDescriptor_detect_excsafe(obj, img, found_locations, hit_threshold, win_stride, padding);

	if(isExc)
		handleException();
}


public static  void HOGDescriptor_detectMultiScale( System.IntPtr obj ,  System.IntPtr img ,  System.IntPtr found_locations ,  System.Double hit_threshold ,  OpenCvSharp.Size win_stride ,  OpenCvSharp.Size padding ,  System.Double scale ,  System.Int32 group_threshold )
{
	bool isExc = NativeMethodsExc.HOGDescriptor_detectMultiScale_excsafe(obj, img, found_locations, hit_threshold, win_stride, padding, scale, group_threshold);

	if(isExc)
		handleException();
}


public static  void HOGDescriptor_getDescriptors( System.IntPtr obj ,  System.IntPtr img ,  OpenCvSharp.Size win_stride ,  System.IntPtr descriptors , [MarshalAs(UnmanagedType.I4)] OpenCvSharp.Cuda.DescriptorFormat descr_format )
{
	bool isExc = NativeMethodsExc.HOGDescriptor_getDescriptors_excsafe(obj, img, win_stride, descriptors, descr_format);

	if(isExc)
		handleException();
}


public static  OpenCvSharp.Size HOGDescriptor_win_size_get( System.IntPtr obj )
{
	OpenCvSharp.Size ret = new OpenCvSharp.Size();
	bool isExc = NativeMethodsExc.HOGDescriptor_win_size_get_excsafe(ref ret, obj);

	if(isExc)
		handleException();
	return ret;
}


public static  OpenCvSharp.Size HOGDescriptor_block_size_get( System.IntPtr obj )
{
	OpenCvSharp.Size ret = new OpenCvSharp.Size();
	bool isExc = NativeMethodsExc.HOGDescriptor_block_size_get_excsafe(ref ret, obj);

	if(isExc)
		handleException();
	return ret;
}


public static  OpenCvSharp.Size HOGDescriptor_block_stride_get( System.IntPtr obj )
{
	OpenCvSharp.Size ret = new OpenCvSharp.Size();
	bool isExc = NativeMethodsExc.HOGDescriptor_block_stride_get_excsafe(ref ret, obj);

	if(isExc)
		handleException();
	return ret;
}


public static  OpenCvSharp.Size HOGDescriptor_cell_size_get( System.IntPtr obj )
{
	OpenCvSharp.Size ret = new OpenCvSharp.Size();
	bool isExc = NativeMethodsExc.HOGDescriptor_cell_size_get_excsafe(ref ret, obj);

	if(isExc)
		handleException();
	return ret;
}


public static  System.Int32 HOGDescriptor_nbins_get( System.IntPtr obj )
{
	System.Int32 ret = new System.Int32();
	bool isExc = NativeMethodsExc.HOGDescriptor_nbins_get_excsafe(ref ret, obj);

	if(isExc)
		handleException();
	return ret;
}


public static  System.Double HOGDescriptor_win_sigma_get( System.IntPtr obj )
{
	System.Double ret = new System.Double();
	bool isExc = NativeMethodsExc.HOGDescriptor_win_sigma_get_excsafe(ref ret, obj);

	if(isExc)
		handleException();
	return ret;
}


public static  System.UInt64 cuda_DeviceInfo_totalMemory( System.IntPtr obj )
{
	System.UInt64 ret = new System.UInt64();
	bool isExc = NativeMethodsExc.cuda_DeviceInfo_totalMemory_excsafe(ref ret, obj);

	if(isExc)
		handleException();
	return ret;
}


public static  System.Int32 cuda_DeviceInfo_supports( System.IntPtr obj ,  System.Int32 featureSet )
{
	System.Int32 ret = new System.Int32();
	bool isExc = NativeMethodsExc.cuda_DeviceInfo_supports_excsafe(ref ret, obj, featureSet);

	if(isExc)
		handleException();
	return ret;
}


public static  System.Int32 cuda_DeviceInfo_isCompatible( System.IntPtr obj )
{
	System.Int32 ret = new System.Int32();
	bool isExc = NativeMethodsExc.cuda_DeviceInfo_isCompatible_excsafe(ref ret, obj);

	if(isExc)
		handleException();
	return ret;
}


public static  System.Int32 cuda_DeviceInfo_deviceID( System.IntPtr obj )
{
	System.Int32 ret = new System.Int32();
	bool isExc = NativeMethodsExc.cuda_DeviceInfo_deviceID_excsafe(ref ret, obj);

	if(isExc)
		handleException();
	return ret;
}


public static  System.Int32 cuda_DeviceInfo_canMapHostMemory( System.IntPtr obj )
{
	System.Int32 ret = new System.Int32();
	bool isExc = NativeMethodsExc.cuda_DeviceInfo_canMapHostMemory_excsafe(ref ret, obj);

	if(isExc)
		handleException();
	return ret;
}


public static  void cuda_printCudaDeviceInfo( System.Int32 device )
{
	bool isExc = NativeMethodsExc.cuda_printCudaDeviceInfo_excsafe(device);

	if(isExc)
		handleException();
}


public static  void cuda_printShortCudaDeviceInfo( System.Int32 device )
{
	bool isExc = NativeMethodsExc.cuda_printShortCudaDeviceInfo_excsafe(device);

	if(isExc)
		handleException();
}


public static  void cuda_registerPageLocked( System.IntPtr m )
{
	bool isExc = NativeMethodsExc.cuda_registerPageLocked_excsafe(m);

	if(isExc)
		handleException();
}


public static  void cuda_unregisterPageLocked( System.IntPtr m )
{
	bool isExc = NativeMethodsExc.cuda_unregisterPageLocked_excsafe(m);

	if(isExc)
		handleException();
}


public static  System.IntPtr cuda_Stream_new1()
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.cuda_Stream_new1_excsafe(ref ret);

	if(isExc)
		handleException();
	return ret;
}


public static  System.IntPtr cuda_Stream_new2( System.IntPtr s )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.cuda_Stream_new2_excsafe(ref ret, s);

	if(isExc)
		handleException();
	return ret;
}


public static  void cuda_Stream_delete( System.IntPtr obj )
{
	bool isExc = NativeMethodsExc.cuda_Stream_delete_excsafe(obj);

	if(isExc)
		handleException();
}


public static  void cuda_Stream_opAssign( System.IntPtr left ,  System.IntPtr right )
{
	bool isExc = NativeMethodsExc.cuda_Stream_opAssign_excsafe(left, right);

	if(isExc)
		handleException();
}


public static  System.Int32 cuda_Stream_queryIfComplete( System.IntPtr obj )
{
	System.Int32 ret = new System.Int32();
	bool isExc = NativeMethodsExc.cuda_Stream_queryIfComplete_excsafe(ref ret, obj);

	if(isExc)
		handleException();
	return ret;
}


public static  void cuda_Stream_waitForCompletion( System.IntPtr obj )
{
	bool isExc = NativeMethodsExc.cuda_Stream_waitForCompletion_excsafe(obj);

	if(isExc)
		handleException();
}


public static  void cuda_Stream_enqueueDownload_CudaMem( System.IntPtr obj ,  System.IntPtr src ,  System.IntPtr dst )
{
	bool isExc = NativeMethodsExc.cuda_Stream_enqueueDownload_CudaMem_excsafe(obj, src, dst);

	if(isExc)
		handleException();
}


public static  void cuda_Stream_enqueueDownload_Mat( System.IntPtr obj ,  System.IntPtr src ,  System.IntPtr dst )
{
	bool isExc = NativeMethodsExc.cuda_Stream_enqueueDownload_Mat_excsafe(obj, src, dst);

	if(isExc)
		handleException();
}


public static  void cuda_Stream_enqueueUpload_CudaMem( System.IntPtr obj ,  System.IntPtr src ,  System.IntPtr dst )
{
	bool isExc = NativeMethodsExc.cuda_Stream_enqueueUpload_CudaMem_excsafe(obj, src, dst);

	if(isExc)
		handleException();
}


public static  void cuda_Stream_enqueueUpload_Mat( System.IntPtr obj ,  System.IntPtr src ,  System.IntPtr dst )
{
	bool isExc = NativeMethodsExc.cuda_Stream_enqueueUpload_Mat_excsafe(obj, src, dst);

	if(isExc)
		handleException();
}


public static  void cuda_Stream_enqueueCopy( System.IntPtr obj ,  System.IntPtr src ,  System.IntPtr dst )
{
	bool isExc = NativeMethodsExc.cuda_Stream_enqueueCopy_excsafe(obj, src, dst);

	if(isExc)
		handleException();
}


public static  void cuda_Stream_enqueueMemSet( System.IntPtr obj ,  System.IntPtr src ,  OpenCvSharp.Scalar val )
{
	bool isExc = NativeMethodsExc.cuda_Stream_enqueueMemSet_excsafe(obj, src, val);

	if(isExc)
		handleException();
}


public static  void cuda_Stream_enqueueMemSet_WithMask( System.IntPtr obj ,  System.IntPtr src ,  OpenCvSharp.Scalar val ,  System.IntPtr mask )
{
	bool isExc = NativeMethodsExc.cuda_Stream_enqueueMemSet_WithMask_excsafe(obj, src, val, mask);

	if(isExc)
		handleException();
}


public static  void cuda_Stream_enqueueConvert( System.IntPtr obj ,  System.IntPtr src ,  System.IntPtr dst ,  System.Int32 dtype ,  System.Double a ,  System.Double b )
{
	bool isExc = NativeMethodsExc.cuda_Stream_enqueueConvert_excsafe(obj, src, dst, dtype, a, b);

	if(isExc)
		handleException();
}


public static  void cuda_Stream_enqueueHostCallback( System.IntPtr obj ,  System.IntPtr callback ,  System.IntPtr userData )
{
	bool isExc = NativeMethodsExc.cuda_Stream_enqueueHostCallback_excsafe(obj, callback, userData);

	if(isExc)
		handleException();
}


public static  System.IntPtr cuda_Stream_Null()
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.cuda_Stream_Null_excsafe(ref ret);

	if(isExc)
		handleException();
	return ret;
}


public static  System.Int32 cuda_Stream_bool( System.IntPtr obj )
{
	System.Int32 ret = new System.Int32();
	bool isExc = NativeMethodsExc.cuda_Stream_bool_excsafe(ref ret, obj);

	if(isExc)
		handleException();
	return ret;
}


public static  void cuda_CascadeClassifier_GPU_delete( System.IntPtr obj )
{
	bool isExc = NativeMethodsExc.cuda_CascadeClassifier_GPU_delete_excsafe(obj);

	if(isExc)
		handleException();
}


public static  System.IntPtr cuda_CascadeClassifier_GPU_new1()
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.cuda_CascadeClassifier_GPU_new1_excsafe(ref ret);

	if(isExc)
		handleException();
	return ret;
}


public static  System.IntPtr core_SparseMat_ptr_2d( System.IntPtr obj ,  System.Int32 i0 ,  System.Int32 i1 ,  System.Int32 createMissing ,  System.IntPtr hashval )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.core_SparseMat_ptr_2d_excsafe(ref ret, obj, i0, i1, createMissing, hashval);

	if(isExc)
		handleException();
	return ret;
}


public static  System.IntPtr core_SparseMat_ptr_3d( System.IntPtr obj ,  System.Int32 i0 ,  System.Int32 i1 ,  System.Int32 i2 ,  System.Int32 createMissing ,  ref System.UInt64 hashval )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.core_SparseMat_ptr_3d_excsafe(ref ret, obj, i0, i1, i2, createMissing,  ref hashval);

	if(isExc)
		handleException();
	return ret;
}


public static  System.IntPtr core_SparseMat_ptr_3d( System.IntPtr obj ,  System.Int32 i0 ,  System.Int32 i1 ,  System.Int32 i2 ,  System.Int32 createMissing ,  System.IntPtr hashval )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.core_SparseMat_ptr_3d_excsafe(ref ret, obj, i0, i1, i2, createMissing, hashval);

	if(isExc)
		handleException();
	return ret;
}


public static  System.IntPtr core_SparseMat_ptr_nd( System.IntPtr obj ,  System.Int32[] idx ,  System.Int32 createMissing ,  ref System.UInt64 hashval )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.core_SparseMat_ptr_nd_excsafe(ref ret, obj, idx, createMissing,  ref hashval);

	if(isExc)
		handleException();
	return ret;
}


public static  System.IntPtr core_SparseMat_ptr_nd( System.IntPtr obj ,  System.Int32[] idx ,  System.Int32 createMissing ,  System.IntPtr hashval )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.core_SparseMat_ptr_nd_excsafe(ref ret, obj, idx, createMissing, hashval);

	if(isExc)
		handleException();
	return ret;
}


public static  System.Int32 cuda_getCudaEnabledDeviceCount()
{
	System.Int32 ret = new System.Int32();
	bool isExc = NativeMethodsExc.cuda_getCudaEnabledDeviceCount_excsafe(ref ret);

	if(isExc)
		handleException();
	return ret;
}


public static  void cuda_setDevice( System.Int32 device )
{
	bool isExc = NativeMethodsExc.cuda_setDevice_excsafe(device);

	if(isExc)
		handleException();
}


public static  System.Int32 cuda_getDevice()
{
	System.Int32 ret = new System.Int32();
	bool isExc = NativeMethodsExc.cuda_getDevice_excsafe(ref ret);

	if(isExc)
		handleException();
	return ret;
}


public static  void cuda_resetDevice()
{
	bool isExc = NativeMethodsExc.cuda_resetDevice_excsafe();

	if(isExc)
		handleException();
}


public static  System.Int32 cuda_deviceSupports( System.Int32 feature_set )
{
	System.Int32 ret = new System.Int32();
	bool isExc = NativeMethodsExc.cuda_deviceSupports_excsafe(ref ret, feature_set);

	if(isExc)
		handleException();
	return ret;
}


public static  System.Int32 cuda_TargetArchs_builtWith( System.Int32 feature_set )
{
	System.Int32 ret = new System.Int32();
	bool isExc = NativeMethodsExc.cuda_TargetArchs_builtWith_excsafe(ref ret, feature_set);

	if(isExc)
		handleException();
	return ret;
}


public static  System.Int32 cuda_TargetArchs_has( System.Int32 major ,  System.Int32 minor )
{
	System.Int32 ret = new System.Int32();
	bool isExc = NativeMethodsExc.cuda_TargetArchs_has_excsafe(ref ret, major, minor);

	if(isExc)
		handleException();
	return ret;
}


public static  System.Int32 cuda_TargetArchs_hasPtx( System.Int32 major ,  System.Int32 minor )
{
	System.Int32 ret = new System.Int32();
	bool isExc = NativeMethodsExc.cuda_TargetArchs_hasPtx_excsafe(ref ret, major, minor);

	if(isExc)
		handleException();
	return ret;
}


public static  System.Int32 cuda_TargetArchs_hasBin( System.Int32 major ,  System.Int32 minor )
{
	System.Int32 ret = new System.Int32();
	bool isExc = NativeMethodsExc.cuda_TargetArchs_hasBin_excsafe(ref ret, major, minor);

	if(isExc)
		handleException();
	return ret;
}


public static  System.Int32 cuda_TargetArchs_hasEqualOrLessPtx( System.Int32 major ,  System.Int32 minor )
{
	System.Int32 ret = new System.Int32();
	bool isExc = NativeMethodsExc.cuda_TargetArchs_hasEqualOrLessPtx_excsafe(ref ret, major, minor);

	if(isExc)
		handleException();
	return ret;
}


public static  System.Int32 cuda_TargetArchs_hasEqualOrGreater( System.Int32 major ,  System.Int32 minor )
{
	System.Int32 ret = new System.Int32();
	bool isExc = NativeMethodsExc.cuda_TargetArchs_hasEqualOrGreater_excsafe(ref ret, major, minor);

	if(isExc)
		handleException();
	return ret;
}


public static  System.Int32 cuda_TargetArchs_hasEqualOrGreaterPtx( System.Int32 major ,  System.Int32 minor )
{
	System.Int32 ret = new System.Int32();
	bool isExc = NativeMethodsExc.cuda_TargetArchs_hasEqualOrGreaterPtx_excsafe(ref ret, major, minor);

	if(isExc)
		handleException();
	return ret;
}


public static  System.Int32 cuda_TargetArchs_hasEqualOrGreaterBin( System.Int32 major ,  System.Int32 minor )
{
	System.Int32 ret = new System.Int32();
	bool isExc = NativeMethodsExc.cuda_TargetArchs_hasEqualOrGreaterBin_excsafe(ref ret, major, minor);

	if(isExc)
		handleException();
	return ret;
}


public static  System.IntPtr cuda_DeviceInfo_new1()
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.cuda_DeviceInfo_new1_excsafe(ref ret);

	if(isExc)
		handleException();
	return ret;
}


public static  System.IntPtr cuda_DeviceInfo_new2( System.Int32 deviceId )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.cuda_DeviceInfo_new2_excsafe(ref ret, deviceId);

	if(isExc)
		handleException();
	return ret;
}


public static  void cuda_DeviceInfo_delete( System.IntPtr obj )
{
	bool isExc = NativeMethodsExc.cuda_DeviceInfo_delete_excsafe(obj);

	if(isExc)
		handleException();
}


public static  void cuda_DeviceInfo_name( System.IntPtr obj , [MarshalAs(UnmanagedType.LPStr)] System.Text.StringBuilder buf ,  System.Int32 bufLength )
{
	bool isExc = NativeMethodsExc.cuda_DeviceInfo_name_excsafe(obj, buf, bufLength);

	if(isExc)
		handleException();
}


public static  System.Int32 cuda_DeviceInfo_majorVersion( System.IntPtr obj )
{
	System.Int32 ret = new System.Int32();
	bool isExc = NativeMethodsExc.cuda_DeviceInfo_majorVersion_excsafe(ref ret, obj);

	if(isExc)
		handleException();
	return ret;
}


public static  System.Int32 cuda_DeviceInfo_minorVersion( System.IntPtr obj )
{
	System.Int32 ret = new System.Int32();
	bool isExc = NativeMethodsExc.cuda_DeviceInfo_minorVersion_excsafe(ref ret, obj);

	if(isExc)
		handleException();
	return ret;
}


public static  System.Int32 cuda_DeviceInfo_multiProcessorCount( System.IntPtr obj )
{
	System.Int32 ret = new System.Int32();
	bool isExc = NativeMethodsExc.cuda_DeviceInfo_multiProcessorCount_excsafe(ref ret, obj);

	if(isExc)
		handleException();
	return ret;
}


public static  System.UInt64 cuda_DeviceInfo_sharedMemPerBlock( System.IntPtr obj )
{
	System.UInt64 ret = new System.UInt64();
	bool isExc = NativeMethodsExc.cuda_DeviceInfo_sharedMemPerBlock_excsafe(ref ret, obj);

	if(isExc)
		handleException();
	return ret;
}


public static  void cuda_DeviceInfo_queryMemory( System.IntPtr obj ,  out System.UInt64 totalMemory ,  out System.UInt64 freeMemory )
{
	bool isExc = NativeMethodsExc.cuda_DeviceInfo_queryMemory_excsafe(obj,  out totalMemory,  out freeMemory);

	if(isExc)
		handleException();
}


public static  System.UInt64 cuda_DeviceInfo_freeMemory( System.IntPtr obj )
{
	System.UInt64 ret = new System.UInt64();
	bool isExc = NativeMethodsExc.cuda_DeviceInfo_freeMemory_excsafe(ref ret, obj);

	if(isExc)
		handleException();
	return ret;
}


public static  void core_SparseMat_operatorAssign_SparseMat( System.IntPtr obj ,  System.IntPtr m )
{
	bool isExc = NativeMethodsExc.core_SparseMat_operatorAssign_SparseMat_excsafe(obj, m);

	if(isExc)
		handleException();
}


public static  void core_SparseMat_operatorAssign_Mat( System.IntPtr obj ,  System.IntPtr m )
{
	bool isExc = NativeMethodsExc.core_SparseMat_operatorAssign_Mat_excsafe(obj, m);

	if(isExc)
		handleException();
}


public static  System.IntPtr core_SparseMat_clone( System.IntPtr obj )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.core_SparseMat_clone_excsafe(ref ret, obj);

	if(isExc)
		handleException();
	return ret;
}


public static  void core_SparseMat_copyTo_SparseMat( System.IntPtr obj ,  System.IntPtr m )
{
	bool isExc = NativeMethodsExc.core_SparseMat_copyTo_SparseMat_excsafe(obj, m);

	if(isExc)
		handleException();
}


public static  void core_SparseMat_copyTo_Mat( System.IntPtr obj ,  System.IntPtr m )
{
	bool isExc = NativeMethodsExc.core_SparseMat_copyTo_Mat_excsafe(obj, m);

	if(isExc)
		handleException();
}


public static  void core_SparseMat_convertTo_SparseMat( System.IntPtr obj ,  System.IntPtr m ,  System.Int32 rtype ,  System.Double alpha )
{
	bool isExc = NativeMethodsExc.core_SparseMat_convertTo_SparseMat_excsafe(obj, m, rtype, alpha);

	if(isExc)
		handleException();
}


public static  void core_SparseMat_convertTo_Mat( System.IntPtr obj ,  System.IntPtr m ,  System.Int32 rtype ,  System.Double alpha ,  System.Double beta )
{
	bool isExc = NativeMethodsExc.core_SparseMat_convertTo_Mat_excsafe(obj, m, rtype, alpha, beta);

	if(isExc)
		handleException();
}


public static  void core_SparseMat_assignTo( System.IntPtr obj ,  System.IntPtr m ,  System.Int32 type )
{
	bool isExc = NativeMethodsExc.core_SparseMat_assignTo_excsafe(obj, m, type);

	if(isExc)
		handleException();
}


public static  void core_SparseMat_create( System.IntPtr obj ,  System.Int32 dims ,  System.Int32[] sizes ,  System.Int32 type )
{
	bool isExc = NativeMethodsExc.core_SparseMat_create_excsafe(obj, dims, sizes, type);

	if(isExc)
		handleException();
}


public static  void core_SparseMat_clear( System.IntPtr obj )
{
	bool isExc = NativeMethodsExc.core_SparseMat_clear_excsafe(obj);

	if(isExc)
		handleException();
}


public static  void core_SparseMat_addref( System.IntPtr obj )
{
	bool isExc = NativeMethodsExc.core_SparseMat_addref_excsafe(obj);

	if(isExc)
		handleException();
}


public static  void core_SparseMat_release( System.IntPtr obj )
{
	bool isExc = NativeMethodsExc.core_SparseMat_release_excsafe(obj);

	if(isExc)
		handleException();
}


public static  System.Int32 core_SparseMat_elemSize( System.IntPtr obj )
{
	System.Int32 ret = new System.Int32();
	bool isExc = NativeMethodsExc.core_SparseMat_elemSize_excsafe(ref ret, obj);

	if(isExc)
		handleException();
	return ret;
}


public static  System.Int32 core_SparseMat_elemSize1( System.IntPtr obj )
{
	System.Int32 ret = new System.Int32();
	bool isExc = NativeMethodsExc.core_SparseMat_elemSize1_excsafe(ref ret, obj);

	if(isExc)
		handleException();
	return ret;
}


public static  System.Int32 core_SparseMat_type( System.IntPtr obj )
{
	System.Int32 ret = new System.Int32();
	bool isExc = NativeMethodsExc.core_SparseMat_type_excsafe(ref ret, obj);

	if(isExc)
		handleException();
	return ret;
}


public static  System.Int32 core_SparseMat_depth( System.IntPtr obj )
{
	System.Int32 ret = new System.Int32();
	bool isExc = NativeMethodsExc.core_SparseMat_depth_excsafe(ref ret, obj);

	if(isExc)
		handleException();
	return ret;
}


public static  System.Int32 core_SparseMat_channels( System.IntPtr obj )
{
	System.Int32 ret = new System.Int32();
	bool isExc = NativeMethodsExc.core_SparseMat_channels_excsafe(ref ret, obj);

	if(isExc)
		handleException();
	return ret;
}


public static  System.IntPtr core_SparseMat_size1( System.IntPtr obj )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.core_SparseMat_size1_excsafe(ref ret, obj);

	if(isExc)
		handleException();
	return ret;
}


public static  System.Int32 core_SparseMat_size2( System.IntPtr obj ,  System.Int32 i )
{
	System.Int32 ret = new System.Int32();
	bool isExc = NativeMethodsExc.core_SparseMat_size2_excsafe(ref ret, obj, i);

	if(isExc)
		handleException();
	return ret;
}


public static  System.Int32 core_SparseMat_dims( System.IntPtr obj )
{
	System.Int32 ret = new System.Int32();
	bool isExc = NativeMethodsExc.core_SparseMat_dims_excsafe(ref ret, obj);

	if(isExc)
		handleException();
	return ret;
}


public static  System.IntPtr core_SparseMat_nzcount( System.IntPtr obj )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.core_SparseMat_nzcount_excsafe(ref ret, obj);

	if(isExc)
		handleException();
	return ret;
}


public static  System.IntPtr core_SparseMat_hash_1d( System.IntPtr obj ,  System.Int32 i0 )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.core_SparseMat_hash_1d_excsafe(ref ret, obj, i0);

	if(isExc)
		handleException();
	return ret;
}


public static  System.IntPtr core_SparseMat_hash_2d( System.IntPtr obj ,  System.Int32 i0 ,  System.Int32 i1 )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.core_SparseMat_hash_2d_excsafe(ref ret, obj, i0, i1);

	if(isExc)
		handleException();
	return ret;
}


public static  System.IntPtr core_SparseMat_hash_3d( System.IntPtr obj ,  System.Int32 i0 ,  System.Int32 i1 ,  System.Int32 i2 )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.core_SparseMat_hash_3d_excsafe(ref ret, obj, i0, i1, i2);

	if(isExc)
		handleException();
	return ret;
}


public static  System.IntPtr core_SparseMat_hash_nd( System.IntPtr obj ,  System.Int32[] idx )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.core_SparseMat_hash_nd_excsafe(ref ret, obj, idx);

	if(isExc)
		handleException();
	return ret;
}


public static  System.IntPtr core_SparseMat_ptr_1d( System.IntPtr obj ,  System.Int32 i0 ,  System.Int32 createMissing ,  ref System.UInt64 hashval )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.core_SparseMat_ptr_1d_excsafe(ref ret, obj, i0, createMissing,  ref hashval);

	if(isExc)
		handleException();
	return ret;
}


public static  System.IntPtr core_SparseMat_ptr_1d( System.IntPtr obj ,  System.Int32 i0 ,  System.Int32 createMissing ,  System.IntPtr hashval )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.core_SparseMat_ptr_1d_excsafe(ref ret, obj, i0, createMissing, hashval);

	if(isExc)
		handleException();
	return ret;
}


public static  System.IntPtr core_SparseMat_ptr_2d( System.IntPtr obj ,  System.Int32 i0 ,  System.Int32 i1 ,  System.Int32 createMissing ,  ref System.UInt64 hashval )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.core_SparseMat_ptr_2d_excsafe(ref ret, obj, i0, i1, createMissing,  ref hashval);

	if(isExc)
		handleException();
	return ret;
}


public static  System.IntPtr core_MatExpr_row( System.IntPtr self ,  System.Int32 y )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.core_MatExpr_row_excsafe(ref ret, self, y);

	if(isExc)
		handleException();
	return ret;
}


public static  System.IntPtr core_MatExpr_col( System.IntPtr self ,  System.Int32 x )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.core_MatExpr_col_excsafe(ref ret, self, x);

	if(isExc)
		handleException();
	return ret;
}


public static  System.IntPtr core_MatExpr_diag1( System.IntPtr self )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.core_MatExpr_diag1_excsafe(ref ret, self);

	if(isExc)
		handleException();
	return ret;
}


public static  System.IntPtr core_MatExpr_diag2( System.IntPtr self ,  System.Int32 d )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.core_MatExpr_diag2_excsafe(ref ret, self, d);

	if(isExc)
		handleException();
	return ret;
}


public static  System.IntPtr core_MatExpr_submat( System.IntPtr self ,  System.Int32 rowStart ,  System.Int32 rowEnd ,  System.Int32 colStart ,  System.Int32 colEnd )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.core_MatExpr_submat_excsafe(ref ret, self, rowStart, rowEnd, colStart, colEnd);

	if(isExc)
		handleException();
	return ret;
}


public static  System.IntPtr core_MatExpr_cross( System.IntPtr self ,  System.IntPtr m )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.core_MatExpr_cross_excsafe(ref ret, self, m);

	if(isExc)
		handleException();
	return ret;
}


public static  System.Double core_MatExpr_dot( System.IntPtr self ,  System.IntPtr m )
{
	System.Double ret = new System.Double();
	bool isExc = NativeMethodsExc.core_MatExpr_dot_excsafe(ref ret, self, m);

	if(isExc)
		handleException();
	return ret;
}


public static  System.IntPtr core_MatExpr_t( System.IntPtr self )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.core_MatExpr_t_excsafe(ref ret, self);

	if(isExc)
		handleException();
	return ret;
}


public static  System.IntPtr core_MatExpr_inv1( System.IntPtr self )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.core_MatExpr_inv1_excsafe(ref ret, self);

	if(isExc)
		handleException();
	return ret;
}


public static  System.IntPtr core_MatExpr_inv2( System.IntPtr self ,  System.Int32 method )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.core_MatExpr_inv2_excsafe(ref ret, self, method);

	if(isExc)
		handleException();
	return ret;
}


public static  System.IntPtr core_MatExpr_mul_toMatExpr( System.IntPtr self ,  System.IntPtr e ,  System.Double scale )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.core_MatExpr_mul_toMatExpr_excsafe(ref ret, self, e, scale);

	if(isExc)
		handleException();
	return ret;
}


public static  System.IntPtr core_MatExpr_mul_toMat( System.IntPtr self ,  System.IntPtr m ,  System.Double scale )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.core_MatExpr_mul_toMat_excsafe(ref ret, self, m, scale);

	if(isExc)
		handleException();
	return ret;
}


public static  OpenCvSharp.Size core_MatExpr_size( System.IntPtr self )
{
	OpenCvSharp.Size ret = new OpenCvSharp.Size();
	bool isExc = NativeMethodsExc.core_MatExpr_size_excsafe(ref ret, self);

	if(isExc)
		handleException();
	return ret;
}


public static  System.Int32 core_MatExpr_type( System.IntPtr self )
{
	System.Int32 ret = new System.Int32();
	bool isExc = NativeMethodsExc.core_MatExpr_type_excsafe(ref ret, self);

	if(isExc)
		handleException();
	return ret;
}


public static  System.IntPtr core_abs_MatExpr( System.IntPtr e )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.core_abs_MatExpr_excsafe(ref ret, e);

	if(isExc)
		handleException();
	return ret;
}


public static  System.IntPtr core_OutputArray_new_byMat( System.IntPtr mat )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.core_OutputArray_new_byMat_excsafe(ref ret, mat);

	if(isExc)
		handleException();
	return ret;
}


public static  System.IntPtr core_OutputArray_new_byGpuMat( System.IntPtr mat )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.core_OutputArray_new_byGpuMat_excsafe(ref ret, mat);

	if(isExc)
		handleException();
	return ret;
}


public static  System.IntPtr core_OutputArray_new_byScalar( OpenCvSharp.Scalar val )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.core_OutputArray_new_byScalar_excsafe(ref ret, val);

	if(isExc)
		handleException();
	return ret;
}


public static  System.IntPtr core_OutputArray_new_byVectorOfMat( System.IntPtr vector )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.core_OutputArray_new_byVectorOfMat_excsafe(ref ret, vector);

	if(isExc)
		handleException();
	return ret;
}


public static  void core_OutputArray_delete( System.IntPtr oa )
{
	bool isExc = NativeMethodsExc.core_OutputArray_delete_excsafe(oa);

	if(isExc)
		handleException();
}


public static  System.IntPtr core_OutputArray_getMat( System.IntPtr oa )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.core_OutputArray_getMat_excsafe(ref ret, oa);

	if(isExc)
		handleException();
	return ret;
}


public static  OpenCvSharp.Scalar core_OutputArray_getScalar( System.IntPtr oa )
{
	OpenCvSharp.Scalar ret = new OpenCvSharp.Scalar();
	bool isExc = NativeMethodsExc.core_OutputArray_getScalar_excsafe(ref ret, oa);

	if(isExc)
		handleException();
	return ret;
}


public static  void core_OutputArray_getVectorOfMat( System.IntPtr oa ,  System.IntPtr vector )
{
	bool isExc = NativeMethodsExc.core_OutputArray_getVectorOfMat_excsafe(oa, vector);

	if(isExc)
		handleException();
}


public static  System.UInt64 core_SparseMat_sizeof()
{
	System.UInt64 ret = new System.UInt64();
	bool isExc = NativeMethodsExc.core_SparseMat_sizeof_excsafe(ref ret);

	if(isExc)
		handleException();
	return ret;
}


public static  System.IntPtr core_SparseMat_new1()
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.core_SparseMat_new1_excsafe(ref ret);

	if(isExc)
		handleException();
	return ret;
}


public static  System.IntPtr core_SparseMat_new2( System.Int32 dims ,  System.Int32[] sizes ,  System.Int32 type )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.core_SparseMat_new2_excsafe(ref ret, dims, sizes, type);

	if(isExc)
		handleException();
	return ret;
}


public static  System.IntPtr core_SparseMat_new3( System.IntPtr m )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.core_SparseMat_new3_excsafe(ref ret, m);

	if(isExc)
		handleException();
	return ret;
}


public static  void core_SparseMat_delete( System.IntPtr obj )
{
	bool isExc = NativeMethodsExc.core_SparseMat_delete_excsafe(obj);

	if(isExc)
		handleException();
}


public static  void core_Mat_forEach_Vec4d( System.IntPtr m ,  OpenCvSharp.MatForeachFunctionVec4d proc )
{
	bool isExc = NativeMethodsExc.core_Mat_forEach_Vec4d_excsafe(m, proc);

	if(isExc)
		handleException();
}


public static  void core_Mat_forEach_Vec6d( System.IntPtr m ,  OpenCvSharp.MatForeachFunctionVec6d proc )
{
	bool isExc = NativeMethodsExc.core_Mat_forEach_Vec6d_excsafe(m, proc);

	if(isExc)
		handleException();
}


public static  System.IntPtr core_MatExpr_new1()
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.core_MatExpr_new1_excsafe(ref ret);

	if(isExc)
		handleException();
	return ret;
}


public static  System.IntPtr core_MatExpr_new2( System.IntPtr mat )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.core_MatExpr_new2_excsafe(ref ret, mat);

	if(isExc)
		handleException();
	return ret;
}


public static  void core_MatExpr_delete( System.IntPtr expr )
{
	bool isExc = NativeMethodsExc.core_MatExpr_delete_excsafe(expr);

	if(isExc)
		handleException();
}


public static  System.IntPtr core_MatExpr_toMat( System.IntPtr expr )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.core_MatExpr_toMat_excsafe(ref ret, expr);

	if(isExc)
		handleException();
	return ret;
}


public static  System.IntPtr core_operatorUnaryMinus_MatExpr( System.IntPtr e )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.core_operatorUnaryMinus_MatExpr_excsafe(ref ret, e);

	if(isExc)
		handleException();
	return ret;
}


public static  System.IntPtr core_operatorUnaryNot_MatExpr( System.IntPtr e )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.core_operatorUnaryNot_MatExpr_excsafe(ref ret, e);

	if(isExc)
		handleException();
	return ret;
}


public static  System.IntPtr core_operatorAdd_MatExprMat( System.IntPtr e ,  System.IntPtr m )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.core_operatorAdd_MatExprMat_excsafe(ref ret, e, m);

	if(isExc)
		handleException();
	return ret;
}


public static  System.IntPtr core_operatorAdd_MatMatExpr( System.IntPtr m ,  System.IntPtr e )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.core_operatorAdd_MatMatExpr_excsafe(ref ret, m, e);

	if(isExc)
		handleException();
	return ret;
}


public static  System.IntPtr core_operatorAdd_MatExprScalar( System.IntPtr e ,  OpenCvSharp.Scalar s )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.core_operatorAdd_MatExprScalar_excsafe(ref ret, e, s);

	if(isExc)
		handleException();
	return ret;
}


public static  System.IntPtr core_operatorAdd_ScalarMatExpr( OpenCvSharp.Scalar s ,  System.IntPtr e )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.core_operatorAdd_ScalarMatExpr_excsafe(ref ret, s, e);

	if(isExc)
		handleException();
	return ret;
}


public static  System.IntPtr core_operatorAdd_MatExprMatExpr( System.IntPtr e1 ,  System.IntPtr e2 )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.core_operatorAdd_MatExprMatExpr_excsafe(ref ret, e1, e2);

	if(isExc)
		handleException();
	return ret;
}


public static  System.IntPtr core_operatorSubtract_MatExprMat( System.IntPtr e ,  System.IntPtr m )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.core_operatorSubtract_MatExprMat_excsafe(ref ret, e, m);

	if(isExc)
		handleException();
	return ret;
}


public static  System.IntPtr core_operatorSubtract_MatMatExpr( System.IntPtr m ,  System.IntPtr e )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.core_operatorSubtract_MatMatExpr_excsafe(ref ret, m, e);

	if(isExc)
		handleException();
	return ret;
}


public static  System.IntPtr core_operatorSubtract_MatExprScalar( System.IntPtr e ,  OpenCvSharp.Scalar s )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.core_operatorSubtract_MatExprScalar_excsafe(ref ret, e, s);

	if(isExc)
		handleException();
	return ret;
}


public static  System.IntPtr core_operatorSubtract_ScalarMatExpr( OpenCvSharp.Scalar s ,  System.IntPtr e )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.core_operatorSubtract_ScalarMatExpr_excsafe(ref ret, s, e);

	if(isExc)
		handleException();
	return ret;
}


public static  System.IntPtr core_operatorSubtract_MatExprMatExpr( System.IntPtr e1 ,  System.IntPtr e2 )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.core_operatorSubtract_MatExprMatExpr_excsafe(ref ret, e1, e2);

	if(isExc)
		handleException();
	return ret;
}


public static  System.IntPtr core_operatorMultiply_MatExprMat( System.IntPtr e ,  System.IntPtr m )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.core_operatorMultiply_MatExprMat_excsafe(ref ret, e, m);

	if(isExc)
		handleException();
	return ret;
}


public static  System.IntPtr core_operatorMultiply_MatMatExpr( System.IntPtr m ,  System.IntPtr e )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.core_operatorMultiply_MatMatExpr_excsafe(ref ret, m, e);

	if(isExc)
		handleException();
	return ret;
}


public static  System.IntPtr core_operatorMultiply_MatExprDouble( System.IntPtr e ,  System.Double s )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.core_operatorMultiply_MatExprDouble_excsafe(ref ret, e, s);

	if(isExc)
		handleException();
	return ret;
}


public static  System.IntPtr core_operatorMultiply_DoubleMatExpr( System.Double s ,  System.IntPtr e )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.core_operatorMultiply_DoubleMatExpr_excsafe(ref ret, s, e);

	if(isExc)
		handleException();
	return ret;
}


public static  System.IntPtr core_operatorMultiply_MatExprMatExpr( System.IntPtr e1 ,  System.IntPtr e2 )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.core_operatorMultiply_MatExprMatExpr_excsafe(ref ret, e1, e2);

	if(isExc)
		handleException();
	return ret;
}


public static  System.IntPtr core_operatorDivide_MatExprMat( System.IntPtr e ,  System.IntPtr m )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.core_operatorDivide_MatExprMat_excsafe(ref ret, e, m);

	if(isExc)
		handleException();
	return ret;
}


public static  System.IntPtr core_operatorDivide_MatMatExpr( System.IntPtr m ,  System.IntPtr e )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.core_operatorDivide_MatMatExpr_excsafe(ref ret, m, e);

	if(isExc)
		handleException();
	return ret;
}


public static  System.IntPtr core_operatorDivide_MatExprDouble( System.IntPtr e ,  System.Double s )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.core_operatorDivide_MatExprDouble_excsafe(ref ret, e, s);

	if(isExc)
		handleException();
	return ret;
}


public static  System.IntPtr core_operatorDivide_DoubleMatExpr( System.Double s ,  System.IntPtr e )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.core_operatorDivide_DoubleMatExpr_excsafe(ref ret, s, e);

	if(isExc)
		handleException();
	return ret;
}


public static  System.IntPtr core_operatorDivide_MatExprMatExpr( System.IntPtr e1 ,  System.IntPtr e2 )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.core_operatorDivide_MatExprMatExpr_excsafe(ref ret, e1, e2);

	if(isExc)
		handleException();
	return ret;
}


public static  void core_Mat_push_back_Rect( System.IntPtr self ,  OpenCvSharp.Rect v )
{
	bool isExc = NativeMethodsExc.core_Mat_push_back_Rect_excsafe(self, v);

	if(isExc)
		handleException();
}


public static  void core_Mat_reserve( System.IntPtr obj ,  System.IntPtr sz )
{
	bool isExc = NativeMethodsExc.core_Mat_reserve_excsafe(obj, sz);

	if(isExc)
		handleException();
}


public static  void core_Mat_resize1( System.IntPtr obj ,  System.IntPtr sz )
{
	bool isExc = NativeMethodsExc.core_Mat_resize1_excsafe(obj, sz);

	if(isExc)
		handleException();
}


public static  void core_Mat_resize2( System.IntPtr obj ,  System.IntPtr sz ,  OpenCvSharp.Scalar s )
{
	bool isExc = NativeMethodsExc.core_Mat_resize2_excsafe(obj, sz, s);

	if(isExc)
		handleException();
}


public static  void core_Mat_pop_back( System.IntPtr obj ,  System.IntPtr nelems )
{
	bool isExc = NativeMethodsExc.core_Mat_pop_back_excsafe(obj, nelems);

	if(isExc)
		handleException();
}


public static  void core_Mat_forEach_uchar( System.IntPtr m ,  OpenCvSharp.MatForeachFunctionByte proc )
{
	bool isExc = NativeMethodsExc.core_Mat_forEach_uchar_excsafe(m, proc);

	if(isExc)
		handleException();
}


public static  void core_Mat_forEach_Vec2b( System.IntPtr m ,  OpenCvSharp.MatForeachFunctionVec2b proc )
{
	bool isExc = NativeMethodsExc.core_Mat_forEach_Vec2b_excsafe(m, proc);

	if(isExc)
		handleException();
}


public static  void core_Mat_forEach_Vec3b( System.IntPtr m ,  OpenCvSharp.MatForeachFunctionVec3b proc )
{
	bool isExc = NativeMethodsExc.core_Mat_forEach_Vec3b_excsafe(m, proc);

	if(isExc)
		handleException();
}


public static  void core_Mat_forEach_Vec4b( System.IntPtr m ,  OpenCvSharp.MatForeachFunctionVec4b proc )
{
	bool isExc = NativeMethodsExc.core_Mat_forEach_Vec4b_excsafe(m, proc);

	if(isExc)
		handleException();
}


public static  void core_Mat_forEach_Vec6b( System.IntPtr m ,  OpenCvSharp.MatForeachFunctionVec6b proc )
{
	bool isExc = NativeMethodsExc.core_Mat_forEach_Vec6b_excsafe(m, proc);

	if(isExc)
		handleException();
}


public static  void core_Mat_forEach_short( System.IntPtr m ,  OpenCvSharp.MatForeachFunctionInt16 proc )
{
	bool isExc = NativeMethodsExc.core_Mat_forEach_short_excsafe(m, proc);

	if(isExc)
		handleException();
}


public static  void core_Mat_forEach_Vec2s( System.IntPtr m ,  OpenCvSharp.MatForeachFunctionVec2s proc )
{
	bool isExc = NativeMethodsExc.core_Mat_forEach_Vec2s_excsafe(m, proc);

	if(isExc)
		handleException();
}


public static  void core_Mat_forEach_Vec3s( System.IntPtr m ,  OpenCvSharp.MatForeachFunctionVec3s proc )
{
	bool isExc = NativeMethodsExc.core_Mat_forEach_Vec3s_excsafe(m, proc);

	if(isExc)
		handleException();
}


public static  void core_Mat_forEach_Vec4s( System.IntPtr m ,  OpenCvSharp.MatForeachFunctionVec4s proc )
{
	bool isExc = NativeMethodsExc.core_Mat_forEach_Vec4s_excsafe(m, proc);

	if(isExc)
		handleException();
}


public static  void core_Mat_forEach_Vec6s( System.IntPtr m ,  OpenCvSharp.MatForeachFunctionVec6s proc )
{
	bool isExc = NativeMethodsExc.core_Mat_forEach_Vec6s_excsafe(m, proc);

	if(isExc)
		handleException();
}


public static  void core_Mat_forEach_int( System.IntPtr m ,  OpenCvSharp.MatForeachFunctionInt32 proc )
{
	bool isExc = NativeMethodsExc.core_Mat_forEach_int_excsafe(m, proc);

	if(isExc)
		handleException();
}


public static  void core_Mat_forEach_Vec2i( System.IntPtr m ,  OpenCvSharp.MatForeachFunctionVec2i proc )
{
	bool isExc = NativeMethodsExc.core_Mat_forEach_Vec2i_excsafe(m, proc);

	if(isExc)
		handleException();
}


public static  void core_Mat_forEach_Vec3i( System.IntPtr m ,  OpenCvSharp.MatForeachFunctionVec3i proc )
{
	bool isExc = NativeMethodsExc.core_Mat_forEach_Vec3i_excsafe(m, proc);

	if(isExc)
		handleException();
}


public static  void core_Mat_forEach_Vec4i( System.IntPtr m ,  OpenCvSharp.MatForeachFunctionVec4i proc )
{
	bool isExc = NativeMethodsExc.core_Mat_forEach_Vec4i_excsafe(m, proc);

	if(isExc)
		handleException();
}


public static  void core_Mat_forEach_Vec6i( System.IntPtr m ,  OpenCvSharp.MatForeachFunctionVec6i proc )
{
	bool isExc = NativeMethodsExc.core_Mat_forEach_Vec6i_excsafe(m, proc);

	if(isExc)
		handleException();
}


public static  void core_Mat_forEach_float( System.IntPtr m ,  OpenCvSharp.MatForeachFunctionFloat proc )
{
	bool isExc = NativeMethodsExc.core_Mat_forEach_float_excsafe(m, proc);

	if(isExc)
		handleException();
}


public static  void core_Mat_forEach_Vec2f( System.IntPtr m ,  OpenCvSharp.MatForeachFunctionVec2f proc )
{
	bool isExc = NativeMethodsExc.core_Mat_forEach_Vec2f_excsafe(m, proc);

	if(isExc)
		handleException();
}


public static  void core_Mat_forEach_Vec3f( System.IntPtr m ,  OpenCvSharp.MatForeachFunctionVec3f proc )
{
	bool isExc = NativeMethodsExc.core_Mat_forEach_Vec3f_excsafe(m, proc);

	if(isExc)
		handleException();
}


public static  void core_Mat_forEach_Vec4f( System.IntPtr m ,  OpenCvSharp.MatForeachFunctionVec4f proc )
{
	bool isExc = NativeMethodsExc.core_Mat_forEach_Vec4f_excsafe(m, proc);

	if(isExc)
		handleException();
}


public static  void core_Mat_forEach_Vec6f( System.IntPtr m ,  OpenCvSharp.MatForeachFunctionVec6f proc )
{
	bool isExc = NativeMethodsExc.core_Mat_forEach_Vec6f_excsafe(m, proc);

	if(isExc)
		handleException();
}


public static  void core_Mat_forEach_double( System.IntPtr m ,  OpenCvSharp.MatForeachFunctionDouble proc )
{
	bool isExc = NativeMethodsExc.core_Mat_forEach_double_excsafe(m, proc);

	if(isExc)
		handleException();
}


public static  void core_Mat_forEach_Vec2d( System.IntPtr m ,  OpenCvSharp.MatForeachFunctionVec2d proc )
{
	bool isExc = NativeMethodsExc.core_Mat_forEach_Vec2d_excsafe(m, proc);

	if(isExc)
		handleException();
}


public static  void core_Mat_forEach_Vec3d( System.IntPtr m ,  OpenCvSharp.MatForeachFunctionVec3d proc )
{
	bool isExc = NativeMethodsExc.core_Mat_forEach_Vec3d_excsafe(m, proc);

	if(isExc)
		handleException();
}


public static  void core_Mat_push_back_Vec6b( System.IntPtr self ,  OpenCvSharp.Vec6b v )
{
	bool isExc = NativeMethodsExc.core_Mat_push_back_Vec6b_excsafe(self, v);

	if(isExc)
		handleException();
}


public static  void core_Mat_push_back_Vec2s( System.IntPtr self ,  OpenCvSharp.Vec2s v )
{
	bool isExc = NativeMethodsExc.core_Mat_push_back_Vec2s_excsafe(self, v);

	if(isExc)
		handleException();
}


public static  void core_Mat_push_back_Vec3s( System.IntPtr self ,  OpenCvSharp.Vec3s v )
{
	bool isExc = NativeMethodsExc.core_Mat_push_back_Vec3s_excsafe(self, v);

	if(isExc)
		handleException();
}


public static  void core_Mat_push_back_Vec4s( System.IntPtr self ,  OpenCvSharp.Vec4s v )
{
	bool isExc = NativeMethodsExc.core_Mat_push_back_Vec4s_excsafe(self, v);

	if(isExc)
		handleException();
}


public static  void core_Mat_push_back_Vec6s( System.IntPtr self ,  OpenCvSharp.Vec6s v )
{
	bool isExc = NativeMethodsExc.core_Mat_push_back_Vec6s_excsafe(self, v);

	if(isExc)
		handleException();
}


public static  void core_Mat_push_back_Vec2w( System.IntPtr self ,  OpenCvSharp.Vec2w v )
{
	bool isExc = NativeMethodsExc.core_Mat_push_back_Vec2w_excsafe(self, v);

	if(isExc)
		handleException();
}


public static  void core_Mat_push_back_Vec3w( System.IntPtr self ,  OpenCvSharp.Vec3w v )
{
	bool isExc = NativeMethodsExc.core_Mat_push_back_Vec3w_excsafe(self, v);

	if(isExc)
		handleException();
}


public static  void core_Mat_push_back_Vec4w( System.IntPtr self ,  OpenCvSharp.Vec4w v )
{
	bool isExc = NativeMethodsExc.core_Mat_push_back_Vec4w_excsafe(self, v);

	if(isExc)
		handleException();
}


public static  void core_Mat_push_back_Vec6w( System.IntPtr self ,  OpenCvSharp.Vec6w v )
{
	bool isExc = NativeMethodsExc.core_Mat_push_back_Vec6w_excsafe(self, v);

	if(isExc)
		handleException();
}


public static  void core_Mat_push_back_Vec2i( System.IntPtr self ,  OpenCvSharp.Vec2i v )
{
	bool isExc = NativeMethodsExc.core_Mat_push_back_Vec2i_excsafe(self, v);

	if(isExc)
		handleException();
}


public static  void core_Mat_push_back_Vec3i( System.IntPtr self ,  OpenCvSharp.Vec3i v )
{
	bool isExc = NativeMethodsExc.core_Mat_push_back_Vec3i_excsafe(self, v);

	if(isExc)
		handleException();
}


public static  void core_Mat_push_back_Vec4i( System.IntPtr self ,  OpenCvSharp.Vec4i v )
{
	bool isExc = NativeMethodsExc.core_Mat_push_back_Vec4i_excsafe(self, v);

	if(isExc)
		handleException();
}


public static  void core_Mat_push_back_Vec6i( System.IntPtr self ,  OpenCvSharp.Vec6i v )
{
	bool isExc = NativeMethodsExc.core_Mat_push_back_Vec6i_excsafe(self, v);

	if(isExc)
		handleException();
}


public static  void core_Mat_push_back_Vec2f( System.IntPtr self ,  OpenCvSharp.Vec2f v )
{
	bool isExc = NativeMethodsExc.core_Mat_push_back_Vec2f_excsafe(self, v);

	if(isExc)
		handleException();
}


public static  void core_Mat_push_back_Vec3f( System.IntPtr self ,  OpenCvSharp.Vec3f v )
{
	bool isExc = NativeMethodsExc.core_Mat_push_back_Vec3f_excsafe(self, v);

	if(isExc)
		handleException();
}


public static  void core_Mat_push_back_Vec4f( System.IntPtr self ,  OpenCvSharp.Vec4f v )
{
	bool isExc = NativeMethodsExc.core_Mat_push_back_Vec4f_excsafe(self, v);

	if(isExc)
		handleException();
}


public static  void core_Mat_push_back_Vec6f( System.IntPtr self ,  OpenCvSharp.Vec6f v )
{
	bool isExc = NativeMethodsExc.core_Mat_push_back_Vec6f_excsafe(self, v);

	if(isExc)
		handleException();
}


public static  void core_Mat_push_back_Vec2d( System.IntPtr self ,  OpenCvSharp.Vec2d v )
{
	bool isExc = NativeMethodsExc.core_Mat_push_back_Vec2d_excsafe(self, v);

	if(isExc)
		handleException();
}


public static  void core_Mat_push_back_Vec3d( System.IntPtr self ,  OpenCvSharp.Vec3d v )
{
	bool isExc = NativeMethodsExc.core_Mat_push_back_Vec3d_excsafe(self, v);

	if(isExc)
		handleException();
}


public static  void core_Mat_push_back_Vec6d( System.IntPtr self ,  OpenCvSharp.Vec6d v )
{
	bool isExc = NativeMethodsExc.core_Mat_push_back_Vec6d_excsafe(self, v);

	if(isExc)
		handleException();
}


public static  void core_Mat_push_back_Point( System.IntPtr self ,  OpenCvSharp.Point v )
{
	bool isExc = NativeMethodsExc.core_Mat_push_back_Point_excsafe(self, v);

	if(isExc)
		handleException();
}


public static  void core_Mat_push_back_Point2f( System.IntPtr self ,  OpenCvSharp.Point2f v )
{
	bool isExc = NativeMethodsExc.core_Mat_push_back_Point2f_excsafe(self, v);

	if(isExc)
		handleException();
}


public static  void core_Mat_push_back_Point2d( System.IntPtr self ,  OpenCvSharp.Point2d v )
{
	bool isExc = NativeMethodsExc.core_Mat_push_back_Point2d_excsafe(self, v);

	if(isExc)
		handleException();
}


public static  void core_Mat_push_back_Point3i( System.IntPtr self ,  OpenCvSharp.Point3i v )
{
	bool isExc = NativeMethodsExc.core_Mat_push_back_Point3i_excsafe(self, v);

	if(isExc)
		handleException();
}


public static  void core_Mat_push_back_Point3f( System.IntPtr self ,  OpenCvSharp.Point3f v )
{
	bool isExc = NativeMethodsExc.core_Mat_push_back_Point3f_excsafe(self, v);

	if(isExc)
		handleException();
}


public static  void core_Mat_push_back_Point3d( System.IntPtr self ,  OpenCvSharp.Point3d v )
{
	bool isExc = NativeMethodsExc.core_Mat_push_back_Point3d_excsafe(self, v);

	if(isExc)
		handleException();
}


public static  void core_Mat_push_back_Size( System.IntPtr self ,  OpenCvSharp.Size v )
{
	bool isExc = NativeMethodsExc.core_Mat_push_back_Size_excsafe(self, v);

	if(isExc)
		handleException();
}


public static  void core_Mat_push_back_Size2f( System.IntPtr self ,  OpenCvSharp.Size2f v )
{
	bool isExc = NativeMethodsExc.core_Mat_push_back_Size2f_excsafe(self, v);

	if(isExc)
		handleException();
}


public static  unsafe System.Int32 core_Mat_nGetS( System.IntPtr obj ,  System.Int32 row ,  System.Int32 col ,  System.Int16* vals ,  System.Int32 valsLength )
{
	System.Int32 ret = new System.Int32();
	bool isExc = NativeMethodsExc.core_Mat_nGetS_excsafe(ref ret, obj, row, col, vals, valsLength);

	if(isExc)
		handleException();
	return ret;
}


public static  unsafe System.Int32 core_Mat_nGetS( System.IntPtr obj ,  System.Int32 row ,  System.Int32 col ,  System.UInt16* vals ,  System.Int32 valsLength )
{
	System.Int32 ret = new System.Int32();
	bool isExc = NativeMethodsExc.core_Mat_nGetS_excsafe(ref ret, obj, row, col, vals, valsLength);

	if(isExc)
		handleException();
	return ret;
}


public static  unsafe System.Int32 core_Mat_nGetI( System.IntPtr obj ,  System.Int32 row ,  System.Int32 col ,  System.Int32* vals ,  System.Int32 valsLength )
{
	System.Int32 ret = new System.Int32();
	bool isExc = NativeMethodsExc.core_Mat_nGetI_excsafe(ref ret, obj, row, col, vals, valsLength);

	if(isExc)
		handleException();
	return ret;
}


public static  unsafe System.Int32 core_Mat_nGetF( System.IntPtr obj ,  System.Int32 row ,  System.Int32 col ,  System.Single* vals ,  System.Int32 valsLength )
{
	System.Int32 ret = new System.Int32();
	bool isExc = NativeMethodsExc.core_Mat_nGetF_excsafe(ref ret, obj, row, col, vals, valsLength);

	if(isExc)
		handleException();
	return ret;
}


public static  unsafe System.Int32 core_Mat_nGetD( System.IntPtr obj ,  System.Int32 row ,  System.Int32 col ,  System.Double* vals ,  System.Int32 valsLength )
{
	System.Int32 ret = new System.Int32();
	bool isExc = NativeMethodsExc.core_Mat_nGetD_excsafe(ref ret, obj, row, col, vals, valsLength);

	if(isExc)
		handleException();
	return ret;
}


public static  unsafe System.Int32 core_Mat_nGetVec3b( System.IntPtr obj ,  System.Int32 row ,  System.Int32 col ,  OpenCvSharp.Vec3b* vals ,  System.Int32 valsLength )
{
	System.Int32 ret = new System.Int32();
	bool isExc = NativeMethodsExc.core_Mat_nGetVec3b_excsafe(ref ret, obj, row, col, vals, valsLength);

	if(isExc)
		handleException();
	return ret;
}


public static  unsafe System.Int32 core_Mat_nGetVec3d( System.IntPtr obj ,  System.Int32 row ,  System.Int32 col ,  OpenCvSharp.Vec3d* vals ,  System.Int32 valsLength )
{
	System.Int32 ret = new System.Int32();
	bool isExc = NativeMethodsExc.core_Mat_nGetVec3d_excsafe(ref ret, obj, row, col, vals, valsLength);

	if(isExc)
		handleException();
	return ret;
}


public static  unsafe System.Int32 core_Mat_nGetVec4f( System.IntPtr obj ,  System.Int32 row ,  System.Int32 col ,  OpenCvSharp.Vec4f* vals ,  System.Int32 valsLength )
{
	System.Int32 ret = new System.Int32();
	bool isExc = NativeMethodsExc.core_Mat_nGetVec4f_excsafe(ref ret, obj, row, col, vals, valsLength);

	if(isExc)
		handleException();
	return ret;
}


public static  unsafe System.Int32 core_Mat_nGetVec6f( System.IntPtr obj ,  System.Int32 row ,  System.Int32 col ,  OpenCvSharp.Vec6f* vals ,  System.Int32 valsLength )
{
	System.Int32 ret = new System.Int32();
	bool isExc = NativeMethodsExc.core_Mat_nGetVec6f_excsafe(ref ret, obj, row, col, vals, valsLength);

	if(isExc)
		handleException();
	return ret;
}


public static  unsafe System.Int32 core_Mat_nGetVec4i( System.IntPtr obj ,  System.Int32 row ,  System.Int32 col ,  OpenCvSharp.Vec4i* vals ,  System.Int32 valsLength )
{
	System.Int32 ret = new System.Int32();
	bool isExc = NativeMethodsExc.core_Mat_nGetVec4i_excsafe(ref ret, obj, row, col, vals, valsLength);

	if(isExc)
		handleException();
	return ret;
}


public static  unsafe System.Int32 core_Mat_nGetPoint( System.IntPtr obj ,  System.Int32 row ,  System.Int32 col ,  OpenCvSharp.Point* vals ,  System.Int32 valsLength )
{
	System.Int32 ret = new System.Int32();
	bool isExc = NativeMethodsExc.core_Mat_nGetPoint_excsafe(ref ret, obj, row, col, vals, valsLength);

	if(isExc)
		handleException();
	return ret;
}


public static  unsafe System.Int32 core_Mat_nGetPoint2f( System.IntPtr obj ,  System.Int32 row ,  System.Int32 col ,  OpenCvSharp.Point2f* vals ,  System.Int32 valsLength )
{
	System.Int32 ret = new System.Int32();
	bool isExc = NativeMethodsExc.core_Mat_nGetPoint2f_excsafe(ref ret, obj, row, col, vals, valsLength);

	if(isExc)
		handleException();
	return ret;
}


public static  unsafe System.Int32 core_Mat_nGetPoint2d( System.IntPtr obj ,  System.Int32 row ,  System.Int32 col ,  OpenCvSharp.Point2d* vals ,  System.Int32 valsLength )
{
	System.Int32 ret = new System.Int32();
	bool isExc = NativeMethodsExc.core_Mat_nGetPoint2d_excsafe(ref ret, obj, row, col, vals, valsLength);

	if(isExc)
		handleException();
	return ret;
}


public static  unsafe System.Int32 core_Mat_nGetPoint3i( System.IntPtr obj ,  System.Int32 row ,  System.Int32 col ,  OpenCvSharp.Point3i* vals ,  System.Int32 valsLength )
{
	System.Int32 ret = new System.Int32();
	bool isExc = NativeMethodsExc.core_Mat_nGetPoint3i_excsafe(ref ret, obj, row, col, vals, valsLength);

	if(isExc)
		handleException();
	return ret;
}


public static  unsafe System.Int32 core_Mat_nGetPoint3f( System.IntPtr obj ,  System.Int32 row ,  System.Int32 col ,  OpenCvSharp.Point3f* vals ,  System.Int32 valsLength )
{
	System.Int32 ret = new System.Int32();
	bool isExc = NativeMethodsExc.core_Mat_nGetPoint3f_excsafe(ref ret, obj, row, col, vals, valsLength);

	if(isExc)
		handleException();
	return ret;
}


public static  unsafe System.Int32 core_Mat_nGetPoint3d( System.IntPtr obj ,  System.Int32 row ,  System.Int32 col ,  OpenCvSharp.Point3d* vals ,  System.Int32 valsLength )
{
	System.Int32 ret = new System.Int32();
	bool isExc = NativeMethodsExc.core_Mat_nGetPoint3d_excsafe(ref ret, obj, row, col, vals, valsLength);

	if(isExc)
		handleException();
	return ret;
}


public static  unsafe System.Int32 core_Mat_nGetRect( System.IntPtr obj ,  System.Int32 row ,  System.Int32 col ,  OpenCvSharp.Rect* vals ,  System.Int32 valsLength )
{
	System.Int32 ret = new System.Int32();
	bool isExc = NativeMethodsExc.core_Mat_nGetRect_excsafe(ref ret, obj, row, col, vals, valsLength);

	if(isExc)
		handleException();
	return ret;
}


public static  void core_Mat_push_back_Mat( System.IntPtr self ,  System.IntPtr m )
{
	bool isExc = NativeMethodsExc.core_Mat_push_back_Mat_excsafe(self, m);

	if(isExc)
		handleException();
}


public static  void core_Mat_push_back_char( System.IntPtr self ,  System.SByte v )
{
	bool isExc = NativeMethodsExc.core_Mat_push_back_char_excsafe(self, v);

	if(isExc)
		handleException();
}


public static  void core_Mat_push_back_uchar( System.IntPtr self ,  System.Byte v )
{
	bool isExc = NativeMethodsExc.core_Mat_push_back_uchar_excsafe(self, v);

	if(isExc)
		handleException();
}


public static  void core_Mat_push_back_short( System.IntPtr self ,  System.Int16 v )
{
	bool isExc = NativeMethodsExc.core_Mat_push_back_short_excsafe(self, v);

	if(isExc)
		handleException();
}


public static  void core_Mat_push_back_ushort( System.IntPtr self ,  System.UInt16 v )
{
	bool isExc = NativeMethodsExc.core_Mat_push_back_ushort_excsafe(self, v);

	if(isExc)
		handleException();
}


public static  void core_Mat_push_back_int( System.IntPtr self ,  System.Int32 v )
{
	bool isExc = NativeMethodsExc.core_Mat_push_back_int_excsafe(self, v);

	if(isExc)
		handleException();
}


public static  void core_Mat_push_back_float( System.IntPtr self ,  System.Single v )
{
	bool isExc = NativeMethodsExc.core_Mat_push_back_float_excsafe(self, v);

	if(isExc)
		handleException();
}


public static  void core_Mat_push_back_double( System.IntPtr self ,  System.Double v )
{
	bool isExc = NativeMethodsExc.core_Mat_push_back_double_excsafe(self, v);

	if(isExc)
		handleException();
}


public static  void core_Mat_push_back_Vec2b( System.IntPtr self ,  OpenCvSharp.Vec2b v )
{
	bool isExc = NativeMethodsExc.core_Mat_push_back_Vec2b_excsafe(self, v);

	if(isExc)
		handleException();
}


public static  void core_Mat_push_back_Vec3b( System.IntPtr self ,  OpenCvSharp.Vec3b v )
{
	bool isExc = NativeMethodsExc.core_Mat_push_back_Vec3b_excsafe(self, v);

	if(isExc)
		handleException();
}


public static  void core_Mat_push_back_Vec4b( System.IntPtr self ,  OpenCvSharp.Vec4b v )
{
	bool isExc = NativeMethodsExc.core_Mat_push_back_Vec4b_excsafe(self, v);

	if(isExc)
		handleException();
}


public static  System.IntPtr core_Mat_operatorGE_DoubleMat( System.Double a ,  System.IntPtr b )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.core_Mat_operatorGE_DoubleMat_excsafe(ref ret, a, b);

	if(isExc)
		handleException();
	return ret;
}


public static  System.IntPtr core_Mat_operatorGE_MatDouble( System.IntPtr a ,  System.Double b )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.core_Mat_operatorGE_MatDouble_excsafe(ref ret, a, b);

	if(isExc)
		handleException();
	return ret;
}


public static  System.IntPtr core_Mat_operatorEQ_MatMat( System.IntPtr a ,  System.IntPtr b )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.core_Mat_operatorEQ_MatMat_excsafe(ref ret, a, b);

	if(isExc)
		handleException();
	return ret;
}


public static  System.IntPtr core_Mat_operatorEQ_DoubleMat( System.Double a ,  System.IntPtr b )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.core_Mat_operatorEQ_DoubleMat_excsafe(ref ret, a, b);

	if(isExc)
		handleException();
	return ret;
}


public static  System.IntPtr core_Mat_operatorEQ_MatDouble( System.IntPtr a ,  System.Double b )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.core_Mat_operatorEQ_MatDouble_excsafe(ref ret, a, b);

	if(isExc)
		handleException();
	return ret;
}


public static  System.IntPtr core_Mat_operatorNE_MatMat( System.IntPtr a ,  System.IntPtr b )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.core_Mat_operatorNE_MatMat_excsafe(ref ret, a, b);

	if(isExc)
		handleException();
	return ret;
}


public static  System.IntPtr core_Mat_operatorNE_DoubleMat( System.Double a ,  System.IntPtr b )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.core_Mat_operatorNE_DoubleMat_excsafe(ref ret, a, b);

	if(isExc)
		handleException();
	return ret;
}


public static  System.IntPtr core_Mat_operatorNE_MatDouble( System.IntPtr a ,  System.Double b )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.core_Mat_operatorNE_MatDouble_excsafe(ref ret, a, b);

	if(isExc)
		handleException();
	return ret;
}


public static  System.IntPtr core_abs_Mat( System.IntPtr e )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.core_abs_Mat_excsafe(ref ret, e);

	if(isExc)
		handleException();
	return ret;
}


public static  unsafe System.Int32 core_Mat_nSetB( System.IntPtr obj ,  System.Int32 row ,  System.Int32 col ,  System.Byte* vals ,  System.Int32 valsLength )
{
	System.Int32 ret = new System.Int32();
	bool isExc = NativeMethodsExc.core_Mat_nSetB_excsafe(ref ret, obj, row, col, vals, valsLength);

	if(isExc)
		handleException();
	return ret;
}


public static  unsafe System.Int32 core_Mat_nSetS( System.IntPtr obj ,  System.Int32 row ,  System.Int32 col ,  System.Int16* vals ,  System.Int32 valsLength )
{
	System.Int32 ret = new System.Int32();
	bool isExc = NativeMethodsExc.core_Mat_nSetS_excsafe(ref ret, obj, row, col, vals, valsLength);

	if(isExc)
		handleException();
	return ret;
}


public static  unsafe System.Int32 core_Mat_nSetS( System.IntPtr obj ,  System.Int32 row ,  System.Int32 col ,  System.UInt16* vals ,  System.Int32 valsLength )
{
	System.Int32 ret = new System.Int32();
	bool isExc = NativeMethodsExc.core_Mat_nSetS_excsafe(ref ret, obj, row, col, vals, valsLength);

	if(isExc)
		handleException();
	return ret;
}


public static  unsafe System.Int32 core_Mat_nSetI( System.IntPtr obj ,  System.Int32 row ,  System.Int32 col ,  System.Int32* vals ,  System.Int32 valsLength )
{
	System.Int32 ret = new System.Int32();
	bool isExc = NativeMethodsExc.core_Mat_nSetI_excsafe(ref ret, obj, row, col, vals, valsLength);

	if(isExc)
		handleException();
	return ret;
}


public static  unsafe System.Int32 core_Mat_nSetF( System.IntPtr obj ,  System.Int32 row ,  System.Int32 col ,  System.Single* vals ,  System.Int32 valsLength )
{
	System.Int32 ret = new System.Int32();
	bool isExc = NativeMethodsExc.core_Mat_nSetF_excsafe(ref ret, obj, row, col, vals, valsLength);

	if(isExc)
		handleException();
	return ret;
}


public static  unsafe System.Int32 core_Mat_nSetD( System.IntPtr obj ,  System.Int32 row ,  System.Int32 col ,  System.Double* vals ,  System.Int32 valsLength )
{
	System.Int32 ret = new System.Int32();
	bool isExc = NativeMethodsExc.core_Mat_nSetD_excsafe(ref ret, obj, row, col, vals, valsLength);

	if(isExc)
		handleException();
	return ret;
}


public static  unsafe System.Int32 core_Mat_nSetVec3b( System.IntPtr obj ,  System.Int32 row ,  System.Int32 col ,  OpenCvSharp.Vec3b* vals ,  System.Int32 valsLength )
{
	System.Int32 ret = new System.Int32();
	bool isExc = NativeMethodsExc.core_Mat_nSetVec3b_excsafe(ref ret, obj, row, col, vals, valsLength);

	if(isExc)
		handleException();
	return ret;
}


public static  unsafe System.Int32 core_Mat_nSetVec3d( System.IntPtr obj ,  System.Int32 row ,  System.Int32 col ,  OpenCvSharp.Vec3d* vals ,  System.Int32 valsLength )
{
	System.Int32 ret = new System.Int32();
	bool isExc = NativeMethodsExc.core_Mat_nSetVec3d_excsafe(ref ret, obj, row, col, vals, valsLength);

	if(isExc)
		handleException();
	return ret;
}


public static  unsafe System.Int32 core_Mat_nSetVec4f( System.IntPtr obj ,  System.Int32 row ,  System.Int32 col ,  OpenCvSharp.Vec4f* vals ,  System.Int32 valsLength )
{
	System.Int32 ret = new System.Int32();
	bool isExc = NativeMethodsExc.core_Mat_nSetVec4f_excsafe(ref ret, obj, row, col, vals, valsLength);

	if(isExc)
		handleException();
	return ret;
}


public static  unsafe System.Int32 core_Mat_nSetVec6f( System.IntPtr obj ,  System.Int32 row ,  System.Int32 col ,  OpenCvSharp.Vec6f* vals ,  System.Int32 valsLength )
{
	System.Int32 ret = new System.Int32();
	bool isExc = NativeMethodsExc.core_Mat_nSetVec6f_excsafe(ref ret, obj, row, col, vals, valsLength);

	if(isExc)
		handleException();
	return ret;
}


public static  unsafe System.Int32 core_Mat_nSetVec4i( System.IntPtr obj ,  System.Int32 row ,  System.Int32 col ,  OpenCvSharp.Vec4i* vals ,  System.Int32 valsLength )
{
	System.Int32 ret = new System.Int32();
	bool isExc = NativeMethodsExc.core_Mat_nSetVec4i_excsafe(ref ret, obj, row, col, vals, valsLength);

	if(isExc)
		handleException();
	return ret;
}


public static  unsafe System.Int32 core_Mat_nSetPoint( System.IntPtr obj ,  System.Int32 row ,  System.Int32 col ,  OpenCvSharp.Point* vals ,  System.Int32 valsLength )
{
	System.Int32 ret = new System.Int32();
	bool isExc = NativeMethodsExc.core_Mat_nSetPoint_excsafe(ref ret, obj, row, col, vals, valsLength);

	if(isExc)
		handleException();
	return ret;
}


public static  unsafe System.Int32 core_Mat_nSetPoint2f( System.IntPtr obj ,  System.Int32 row ,  System.Int32 col ,  OpenCvSharp.Point2f* vals ,  System.Int32 valsLength )
{
	System.Int32 ret = new System.Int32();
	bool isExc = NativeMethodsExc.core_Mat_nSetPoint2f_excsafe(ref ret, obj, row, col, vals, valsLength);

	if(isExc)
		handleException();
	return ret;
}


public static  unsafe System.Int32 core_Mat_nSetPoint2d( System.IntPtr obj ,  System.Int32 row ,  System.Int32 col ,  OpenCvSharp.Point2d* vals ,  System.Int32 valsLength )
{
	System.Int32 ret = new System.Int32();
	bool isExc = NativeMethodsExc.core_Mat_nSetPoint2d_excsafe(ref ret, obj, row, col, vals, valsLength);

	if(isExc)
		handleException();
	return ret;
}


public static  unsafe System.Int32 core_Mat_nSetPoint3i( System.IntPtr obj ,  System.Int32 row ,  System.Int32 col ,  OpenCvSharp.Point3i* vals ,  System.Int32 valsLength )
{
	System.Int32 ret = new System.Int32();
	bool isExc = NativeMethodsExc.core_Mat_nSetPoint3i_excsafe(ref ret, obj, row, col, vals, valsLength);

	if(isExc)
		handleException();
	return ret;
}


public static  unsafe System.Int32 core_Mat_nSetPoint3f( System.IntPtr obj ,  System.Int32 row ,  System.Int32 col ,  OpenCvSharp.Point3f* vals ,  System.Int32 valsLength )
{
	System.Int32 ret = new System.Int32();
	bool isExc = NativeMethodsExc.core_Mat_nSetPoint3f_excsafe(ref ret, obj, row, col, vals, valsLength);

	if(isExc)
		handleException();
	return ret;
}


public static  unsafe System.Int32 core_Mat_nSetPoint3d( System.IntPtr obj ,  System.Int32 row ,  System.Int32 col ,  OpenCvSharp.Point3d* vals ,  System.Int32 valsLength )
{
	System.Int32 ret = new System.Int32();
	bool isExc = NativeMethodsExc.core_Mat_nSetPoint3d_excsafe(ref ret, obj, row, col, vals, valsLength);

	if(isExc)
		handleException();
	return ret;
}


public static  unsafe System.Int32 core_Mat_nSetRect( System.IntPtr obj ,  System.Int32 row ,  System.Int32 col ,  OpenCvSharp.Rect* vals ,  System.Int32 valsLength )
{
	System.Int32 ret = new System.Int32();
	bool isExc = NativeMethodsExc.core_Mat_nSetRect_excsafe(ref ret, obj, row, col, vals, valsLength);

	if(isExc)
		handleException();
	return ret;
}


public static  unsafe System.Int32 core_Mat_nGetB( System.IntPtr obj ,  System.Int32 row ,  System.Int32 col ,  System.Byte* vals ,  System.Int32 valsLength )
{
	System.Int32 ret = new System.Int32();
	bool isExc = NativeMethodsExc.core_Mat_nGetB_excsafe(ref ret, obj, row, col, vals, valsLength);

	if(isExc)
		handleException();
	return ret;
}


public static  System.IntPtr core_Mat_operatorSubtract_MatScalar( System.IntPtr a ,  OpenCvSharp.Scalar s )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.core_Mat_operatorSubtract_MatScalar_excsafe(ref ret, a, s);

	if(isExc)
		handleException();
	return ret;
}


public static  System.IntPtr core_Mat_operatorSubtract_ScalarMat( OpenCvSharp.Scalar s ,  System.IntPtr a )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.core_Mat_operatorSubtract_ScalarMat_excsafe(ref ret, s, a);

	if(isExc)
		handleException();
	return ret;
}


public static  System.IntPtr core_Mat_operatorMultiply_MatMat( System.IntPtr a ,  System.IntPtr b )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.core_Mat_operatorMultiply_MatMat_excsafe(ref ret, a, b);

	if(isExc)
		handleException();
	return ret;
}


public static  System.IntPtr core_Mat_operatorMultiply_MatDouble( System.IntPtr a ,  System.Double s )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.core_Mat_operatorMultiply_MatDouble_excsafe(ref ret, a, s);

	if(isExc)
		handleException();
	return ret;
}


public static  System.IntPtr core_Mat_operatorMultiply_DoubleMat( System.Double s ,  System.IntPtr a )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.core_Mat_operatorMultiply_DoubleMat_excsafe(ref ret, s, a);

	if(isExc)
		handleException();
	return ret;
}


public static  System.IntPtr core_Mat_operatorDivide_MatMat( System.IntPtr a ,  System.IntPtr b )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.core_Mat_operatorDivide_MatMat_excsafe(ref ret, a, b);

	if(isExc)
		handleException();
	return ret;
}


public static  System.IntPtr core_Mat_operatorDivide_MatDouble( System.IntPtr a ,  System.Double s )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.core_Mat_operatorDivide_MatDouble_excsafe(ref ret, a, s);

	if(isExc)
		handleException();
	return ret;
}


public static  System.IntPtr core_Mat_operatorDivide_DoubleMat( System.Double s ,  System.IntPtr a )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.core_Mat_operatorDivide_DoubleMat_excsafe(ref ret, s, a);

	if(isExc)
		handleException();
	return ret;
}


public static  System.IntPtr core_Mat_operatorAnd_MatMat( System.IntPtr a ,  System.IntPtr b )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.core_Mat_operatorAnd_MatMat_excsafe(ref ret, a, b);

	if(isExc)
		handleException();
	return ret;
}


public static  System.IntPtr core_Mat_operatorAnd_MatDouble( System.IntPtr a ,  System.Double s )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.core_Mat_operatorAnd_MatDouble_excsafe(ref ret, a, s);

	if(isExc)
		handleException();
	return ret;
}


public static  System.IntPtr core_Mat_operatorAnd_DoubleMat( System.Double s ,  System.IntPtr a )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.core_Mat_operatorAnd_DoubleMat_excsafe(ref ret, s, a);

	if(isExc)
		handleException();
	return ret;
}


public static  System.IntPtr core_Mat_operatorOr_MatMat( System.IntPtr a ,  System.IntPtr b )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.core_Mat_operatorOr_MatMat_excsafe(ref ret, a, b);

	if(isExc)
		handleException();
	return ret;
}


public static  System.IntPtr core_Mat_operatorOr_MatDouble( System.IntPtr a ,  System.Double s )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.core_Mat_operatorOr_MatDouble_excsafe(ref ret, a, s);

	if(isExc)
		handleException();
	return ret;
}


public static  System.IntPtr core_Mat_operatorOr_DoubleMat( System.Double s ,  System.IntPtr a )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.core_Mat_operatorOr_DoubleMat_excsafe(ref ret, s, a);

	if(isExc)
		handleException();
	return ret;
}


public static  System.IntPtr core_Mat_operatorXor_MatMat( System.IntPtr a ,  System.IntPtr b )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.core_Mat_operatorXor_MatMat_excsafe(ref ret, a, b);

	if(isExc)
		handleException();
	return ret;
}


public static  System.IntPtr core_Mat_operatorXor_MatDouble( System.IntPtr a ,  System.Double s )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.core_Mat_operatorXor_MatDouble_excsafe(ref ret, a, s);

	if(isExc)
		handleException();
	return ret;
}


public static  System.IntPtr core_Mat_operatorXor_DoubleMat( System.Double s ,  System.IntPtr a )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.core_Mat_operatorXor_DoubleMat_excsafe(ref ret, s, a);

	if(isExc)
		handleException();
	return ret;
}


public static  System.IntPtr core_Mat_operatorNot( System.IntPtr a )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.core_Mat_operatorNot_excsafe(ref ret, a);

	if(isExc)
		handleException();
	return ret;
}


public static  System.IntPtr core_Mat_operatorLT_MatMat( System.IntPtr a ,  System.IntPtr b )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.core_Mat_operatorLT_MatMat_excsafe(ref ret, a, b);

	if(isExc)
		handleException();
	return ret;
}


public static  System.IntPtr core_Mat_operatorLT_DoubleMat( System.Double a ,  System.IntPtr b )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.core_Mat_operatorLT_DoubleMat_excsafe(ref ret, a, b);

	if(isExc)
		handleException();
	return ret;
}


public static  System.IntPtr core_Mat_operatorLT_MatDouble( System.IntPtr a ,  System.Double b )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.core_Mat_operatorLT_MatDouble_excsafe(ref ret, a, b);

	if(isExc)
		handleException();
	return ret;
}


public static  System.IntPtr core_Mat_operatorLE_MatMat( System.IntPtr a ,  System.IntPtr b )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.core_Mat_operatorLE_MatMat_excsafe(ref ret, a, b);

	if(isExc)
		handleException();
	return ret;
}


public static  System.IntPtr core_Mat_operatorLE_DoubleMat( System.Double a ,  System.IntPtr b )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.core_Mat_operatorLE_DoubleMat_excsafe(ref ret, a, b);

	if(isExc)
		handleException();
	return ret;
}


public static  System.IntPtr core_Mat_operatorLE_MatDouble( System.IntPtr a ,  System.Double b )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.core_Mat_operatorLE_MatDouble_excsafe(ref ret, a, b);

	if(isExc)
		handleException();
	return ret;
}


public static  System.IntPtr core_Mat_operatorGT_MatMat( System.IntPtr a ,  System.IntPtr b )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.core_Mat_operatorGT_MatMat_excsafe(ref ret, a, b);

	if(isExc)
		handleException();
	return ret;
}


public static  System.IntPtr core_Mat_operatorGT_DoubleMat( System.Double a ,  System.IntPtr b )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.core_Mat_operatorGT_DoubleMat_excsafe(ref ret, a, b);

	if(isExc)
		handleException();
	return ret;
}


public static  System.IntPtr core_Mat_operatorGT_MatDouble( System.IntPtr a ,  System.Double b )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.core_Mat_operatorGT_MatDouble_excsafe(ref ret, a, b);

	if(isExc)
		handleException();
	return ret;
}


public static  System.IntPtr core_Mat_operatorGE_MatMat( System.IntPtr a ,  System.IntPtr b )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.core_Mat_operatorGE_MatMat_excsafe(ref ret, a, b);

	if(isExc)
		handleException();
	return ret;
}


public static  System.UInt64 core_Mat_step12( System.IntPtr self ,  System.Int32 i )
{
	System.UInt64 ret = new System.UInt64();
	bool isExc = NativeMethodsExc.core_Mat_step12_excsafe(ref ret, self, i);

	if(isExc)
		handleException();
	return ret;
}


public static  System.Int64 core_Mat_step( System.IntPtr self )
{
	System.Int64 ret = new System.Int64();
	bool isExc = NativeMethodsExc.core_Mat_step_excsafe(ref ret, self);

	if(isExc)
		handleException();
	return ret;
}


public static  System.UInt64 core_Mat_stepAt( System.IntPtr self ,  System.Int32 i )
{
	System.UInt64 ret = new System.UInt64();
	bool isExc = NativeMethodsExc.core_Mat_stepAt_excsafe(ref ret, self, i);

	if(isExc)
		handleException();
	return ret;
}


public static  System.IntPtr core_Mat_subMat1( System.IntPtr self ,  System.Int32 rowStart ,  System.Int32 rowEnd ,  System.Int32 colStart ,  System.Int32 colEnd )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.core_Mat_subMat1_excsafe(ref ret, self, rowStart, rowEnd, colStart, colEnd);

	if(isExc)
		handleException();
	return ret;
}


public static  System.IntPtr core_Mat_subMat2( System.IntPtr self ,  System.Int32 nRanges ,  OpenCvSharp.Range[] ranges )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.core_Mat_subMat2_excsafe(ref ret, self, nRanges, ranges);

	if(isExc)
		handleException();
	return ret;
}


public static  System.IntPtr core_Mat_t( System.IntPtr self )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.core_Mat_t_excsafe(ref ret, self);

	if(isExc)
		handleException();
	return ret;
}


public static  System.UInt64 core_Mat_total( System.IntPtr self )
{
	System.UInt64 ret = new System.UInt64();
	bool isExc = NativeMethodsExc.core_Mat_total_excsafe(ref ret, self);

	if(isExc)
		handleException();
	return ret;
}


public static  System.Int32 core_Mat_type( System.IntPtr self )
{
	System.Int32 ret = new System.Int32();
	bool isExc = NativeMethodsExc.core_Mat_type_excsafe(ref ret, self);

	if(isExc)
		handleException();
	return ret;
}


public static  System.IntPtr core_Mat_zeros1( System.Int32 rows ,  System.Int32 cols ,  System.Int32 type )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.core_Mat_zeros1_excsafe(ref ret, rows, cols, type);

	if(isExc)
		handleException();
	return ret;
}


public static  System.IntPtr core_Mat_zeros2( System.Int32 ndims , [MarshalAs(UnmanagedType.LPArray)] System.Int32[] sz ,  System.Int32 type )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.core_Mat_zeros2_excsafe(ref ret, ndims, sz, type);

	if(isExc)
		handleException();
	return ret;
}


public static  unsafe System.SByte* core_Mat_dump( System.IntPtr self , [MarshalAs(UnmanagedType.LPStr)] System.String format )
{
	IntPtr ret = new IntPtr();
	bool isExc = NativeMethodsExc.core_Mat_dump_excsafe(ref ret, self, format);

	if(isExc)
		handleException();
	return (System.SByte*)ret;
}


public static  unsafe void core_Mat_dump_delete( System.SByte* buf )
{
	bool isExc = NativeMethodsExc.core_Mat_dump_delete_excsafe(buf);

	if(isExc)
		handleException();
}


public static  System.IntPtr core_Mat_ptr1d( System.IntPtr self ,  System.Int32 i0 )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.core_Mat_ptr1d_excsafe(ref ret, self, i0);

	if(isExc)
		handleException();
	return ret;
}


public static  System.IntPtr core_Mat_ptr2d( System.IntPtr self ,  System.Int32 i0 ,  System.Int32 i1 )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.core_Mat_ptr2d_excsafe(ref ret, self, i0, i1);

	if(isExc)
		handleException();
	return ret;
}


public static  System.IntPtr core_Mat_ptr3d( System.IntPtr self ,  System.Int32 i0 ,  System.Int32 i1 ,  System.Int32 i2 )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.core_Mat_ptr3d_excsafe(ref ret, self, i0, i1, i2);

	if(isExc)
		handleException();
	return ret;
}


public static  System.IntPtr core_Mat_ptrnd( System.IntPtr self , [MarshalAs(UnmanagedType.LPArray)] System.Int32[] idx )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.core_Mat_ptrnd_excsafe(ref ret, self, idx);

	if(isExc)
		handleException();
	return ret;
}


public static  void core_Mat_assignment_FromMat( System.IntPtr self ,  System.IntPtr newMat )
{
	bool isExc = NativeMethodsExc.core_Mat_assignment_FromMat_excsafe(self, newMat);

	if(isExc)
		handleException();
}


public static  void core_Mat_assignment_FromMatExpr( System.IntPtr self ,  System.IntPtr newMatExpr )
{
	bool isExc = NativeMethodsExc.core_Mat_assignment_FromMatExpr_excsafe(self, newMatExpr);

	if(isExc)
		handleException();
}


public static  void core_Mat_assignment_FromScalar( System.IntPtr self ,  OpenCvSharp.Scalar scalar )
{
	bool isExc = NativeMethodsExc.core_Mat_assignment_FromScalar_excsafe(self, scalar);

	if(isExc)
		handleException();
}


public static  void core_Mat_IplImage( System.IntPtr self ,  System.IntPtr outImage )
{
	bool isExc = NativeMethodsExc.core_Mat_IplImage_excsafe(self, outImage);

	if(isExc)
		handleException();
}


public static  void core_Mat_IplImage_alignment( System.IntPtr self ,  out System.IntPtr outImage )
{
	bool isExc = NativeMethodsExc.core_Mat_IplImage_alignment_excsafe(self,  out outImage);

	if(isExc)
		handleException();
}


public static  void core_Mat_CvMat( System.IntPtr self ,  System.IntPtr outMat )
{
	bool isExc = NativeMethodsExc.core_Mat_CvMat_excsafe(self, outMat);

	if(isExc)
		handleException();
}


public static  System.IntPtr core_Mat_operatorUnaryMinus( System.IntPtr mat )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.core_Mat_operatorUnaryMinus_excsafe(ref ret, mat);

	if(isExc)
		handleException();
	return ret;
}


public static  System.IntPtr core_Mat_operatorAdd_MatMat( System.IntPtr a ,  System.IntPtr b )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.core_Mat_operatorAdd_MatMat_excsafe(ref ret, a, b);

	if(isExc)
		handleException();
	return ret;
}


public static  System.IntPtr core_Mat_operatorAdd_MatScalar( System.IntPtr a ,  OpenCvSharp.Scalar s )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.core_Mat_operatorAdd_MatScalar_excsafe(ref ret, a, s);

	if(isExc)
		handleException();
	return ret;
}


public static  System.IntPtr core_Mat_operatorAdd_ScalarMat( OpenCvSharp.Scalar s ,  System.IntPtr a )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.core_Mat_operatorAdd_ScalarMat_excsafe(ref ret, s, a);

	if(isExc)
		handleException();
	return ret;
}


public static  System.IntPtr core_Mat_operatorMinus_Mat( System.IntPtr a )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.core_Mat_operatorMinus_Mat_excsafe(ref ret, a);

	if(isExc)
		handleException();
	return ret;
}


public static  System.IntPtr core_Mat_operatorSubtract_MatMat( System.IntPtr a ,  System.IntPtr b )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.core_Mat_operatorSubtract_MatMat_excsafe(ref ret, a, b);

	if(isExc)
		handleException();
	return ret;
}


public static  System.IntPtr core_Mat_diag3( System.IntPtr self )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.core_Mat_diag3_excsafe(ref ret, self);

	if(isExc)
		handleException();
	return ret;
}


public static  System.Double core_Mat_dot( System.IntPtr self ,  System.IntPtr m )
{
	System.Double ret = new System.Double();
	bool isExc = NativeMethodsExc.core_Mat_dot_excsafe(ref ret, self, m);

	if(isExc)
		handleException();
	return ret;
}


public static  System.UInt64 core_Mat_elemSize( System.IntPtr self )
{
	System.UInt64 ret = new System.UInt64();
	bool isExc = NativeMethodsExc.core_Mat_elemSize_excsafe(ref ret, self);

	if(isExc)
		handleException();
	return ret;
}


public static  System.UInt64 core_Mat_elemSize1( System.IntPtr self )
{
	System.UInt64 ret = new System.UInt64();
	bool isExc = NativeMethodsExc.core_Mat_elemSize1_excsafe(ref ret, self);

	if(isExc)
		handleException();
	return ret;
}


public static  System.Int32 core_Mat_empty( System.IntPtr self )
{
	System.Int32 ret = new System.Int32();
	bool isExc = NativeMethodsExc.core_Mat_empty_excsafe(ref ret, self);

	if(isExc)
		handleException();
	return ret;
}


public static  System.IntPtr core_Mat_eye( System.Int32 rows ,  System.Int32 cols ,  System.Int32 type )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.core_Mat_eye_excsafe(ref ret, rows, cols, type);

	if(isExc)
		handleException();
	return ret;
}


public static  System.IntPtr core_Mat_inv1( System.IntPtr self )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.core_Mat_inv1_excsafe(ref ret, self);

	if(isExc)
		handleException();
	return ret;
}


public static  System.IntPtr core_Mat_inv2( System.IntPtr self ,  System.Int32 method )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.core_Mat_inv2_excsafe(ref ret, self, method);

	if(isExc)
		handleException();
	return ret;
}


public static  System.Int32 core_Mat_isContinuous( System.IntPtr self )
{
	System.Int32 ret = new System.Int32();
	bool isExc = NativeMethodsExc.core_Mat_isContinuous_excsafe(ref ret, self);

	if(isExc)
		handleException();
	return ret;
}


public static  System.Int32 core_Mat_isSubmatrix( System.IntPtr self )
{
	System.Int32 ret = new System.Int32();
	bool isExc = NativeMethodsExc.core_Mat_isSubmatrix_excsafe(ref ret, self);

	if(isExc)
		handleException();
	return ret;
}


public static  void core_Mat_locateROI( System.IntPtr self ,  out OpenCvSharp.Size wholeSize ,  out OpenCvSharp.Point ofs )
{
	bool isExc = NativeMethodsExc.core_Mat_locateROI_excsafe(self,  out wholeSize,  out ofs);

	if(isExc)
		handleException();
}


public static  System.IntPtr core_Mat_mul1( System.IntPtr self ,  System.IntPtr m )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.core_Mat_mul1_excsafe(ref ret, self, m);

	if(isExc)
		handleException();
	return ret;
}


public static  System.IntPtr core_Mat_mul2( System.IntPtr self ,  System.IntPtr m ,  System.Double scale )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.core_Mat_mul2_excsafe(ref ret, self, m, scale);

	if(isExc)
		handleException();
	return ret;
}


public static  System.IntPtr core_Mat_ones1( System.Int32 rows ,  System.Int32 cols ,  System.Int32 type )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.core_Mat_ones1_excsafe(ref ret, rows, cols, type);

	if(isExc)
		handleException();
	return ret;
}


public static  System.IntPtr core_Mat_ones2( System.Int32 ndims , [MarshalAs(UnmanagedType.LPArray)] System.Int32[] sz ,  System.Int32 type )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.core_Mat_ones2_excsafe(ref ret, ndims, sz, type);

	if(isExc)
		handleException();
	return ret;
}


public static  System.IntPtr core_Mat_reshape1( System.IntPtr self ,  System.Int32 cn )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.core_Mat_reshape1_excsafe(ref ret, self, cn);

	if(isExc)
		handleException();
	return ret;
}


public static  System.IntPtr core_Mat_reshape2( System.IntPtr self ,  System.Int32 cn ,  System.Int32 rows )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.core_Mat_reshape2_excsafe(ref ret, self, cn, rows);

	if(isExc)
		handleException();
	return ret;
}


public static  System.IntPtr core_Mat_reshape3( System.IntPtr self ,  System.Int32 cn ,  System.Int32 newndims , [MarshalAs(UnmanagedType.LPArray)] System.Int32[] newsz )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.core_Mat_reshape3_excsafe(ref ret, self, cn, newndims, newsz);

	if(isExc)
		handleException();
	return ret;
}


public static  System.Int32 core_Mat_rows( System.IntPtr self )
{
	System.Int32 ret = new System.Int32();
	bool isExc = NativeMethodsExc.core_Mat_rows_excsafe(ref ret, self);

	if(isExc)
		handleException();
	return ret;
}


public static  System.IntPtr core_Mat_row_toMat( System.IntPtr self ,  System.Int32 y )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.core_Mat_row_toMat_excsafe(ref ret, self, y);

	if(isExc)
		handleException();
	return ret;
}


public static  System.IntPtr core_Mat_row_toMatExpr( System.IntPtr self ,  System.Int32 y )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.core_Mat_row_toMatExpr_excsafe(ref ret, self, y);

	if(isExc)
		handleException();
	return ret;
}


public static  System.IntPtr core_Mat_rowRange_toMat( System.IntPtr self ,  System.Int32 startRow ,  System.Int32 endRow )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.core_Mat_rowRange_toMat_excsafe(ref ret, self, startRow, endRow);

	if(isExc)
		handleException();
	return ret;
}


public static  System.IntPtr core_Mat_rowRange_toMatExpr( System.IntPtr self ,  System.Int32 startRow ,  System.Int32 endRow )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.core_Mat_rowRange_toMatExpr_excsafe(ref ret, self, startRow, endRow);

	if(isExc)
		handleException();
	return ret;
}


public static  System.IntPtr core_Mat_setTo_Scalar( System.IntPtr self ,  OpenCvSharp.Scalar value ,  System.IntPtr mask )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.core_Mat_setTo_Scalar_excsafe(ref ret, self, value, mask);

	if(isExc)
		handleException();
	return ret;
}


public static  System.IntPtr core_Mat_setTo_InputArray( System.IntPtr self ,  System.IntPtr value ,  System.IntPtr mask )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.core_Mat_setTo_InputArray_excsafe(ref ret, self, value, mask);

	if(isExc)
		handleException();
	return ret;
}


public static  OpenCvSharp.Size core_Mat_size( System.IntPtr self )
{
	OpenCvSharp.Size ret = new OpenCvSharp.Size();
	bool isExc = NativeMethodsExc.core_Mat_size_excsafe(ref ret, self);

	if(isExc)
		handleException();
	return ret;
}


public static  System.Int32 core_Mat_sizeAt( System.IntPtr self ,  System.Int32 i )
{
	System.Int32 ret = new System.Int32();
	bool isExc = NativeMethodsExc.core_Mat_sizeAt_excsafe(ref ret, self, i);

	if(isExc)
		handleException();
	return ret;
}


public static  System.UInt64 core_Mat_step11( System.IntPtr self )
{
	System.UInt64 ret = new System.UInt64();
	bool isExc = NativeMethodsExc.core_Mat_step11_excsafe(ref ret, self);

	if(isExc)
		handleException();
	return ret;
}


public static  void core_Mat_release( System.IntPtr mat )
{
	bool isExc = NativeMethodsExc.core_Mat_release_excsafe(mat);

	if(isExc)
		handleException();
}


public static  void core_Mat_delete( System.IntPtr mat )
{
	bool isExc = NativeMethodsExc.core_Mat_delete_excsafe(mat);

	if(isExc)
		handleException();
}


public static  System.IntPtr core_Mat_adjustROI( System.IntPtr nativeObj ,  System.Int32 dtop ,  System.Int32 dbottom ,  System.Int32 dleft ,  System.Int32 dright )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.core_Mat_adjustROI_excsafe(ref ret, nativeObj, dtop, dbottom, dleft, dright);

	if(isExc)
		handleException();
	return ret;
}


public static  void core_Mat_assignTo1( System.IntPtr self ,  System.IntPtr m )
{
	bool isExc = NativeMethodsExc.core_Mat_assignTo1_excsafe(self, m);

	if(isExc)
		handleException();
}


public static  void core_Mat_assignTo2( System.IntPtr self ,  System.IntPtr m ,  System.Int32 type )
{
	bool isExc = NativeMethodsExc.core_Mat_assignTo2_excsafe(self, m, type);

	if(isExc)
		handleException();
}


public static  System.Int32 core_Mat_channels( System.IntPtr self )
{
	System.Int32 ret = new System.Int32();
	bool isExc = NativeMethodsExc.core_Mat_channels_excsafe(ref ret, self);

	if(isExc)
		handleException();
	return ret;
}


public static  System.Int32 core_Mat_checkVector1( System.IntPtr self ,  System.Int32 elemChannels )
{
	System.Int32 ret = new System.Int32();
	bool isExc = NativeMethodsExc.core_Mat_checkVector1_excsafe(ref ret, self, elemChannels);

	if(isExc)
		handleException();
	return ret;
}


public static  System.Int32 core_Mat_checkVector2( System.IntPtr self ,  System.Int32 elemChannels ,  System.Int32 depth )
{
	System.Int32 ret = new System.Int32();
	bool isExc = NativeMethodsExc.core_Mat_checkVector2_excsafe(ref ret, self, elemChannels, depth);

	if(isExc)
		handleException();
	return ret;
}


public static  System.Int32 core_Mat_checkVector3( System.IntPtr self ,  System.Int32 elemChannels ,  System.Int32 depth ,  System.Int32 requireContinuous )
{
	System.Int32 ret = new System.Int32();
	bool isExc = NativeMethodsExc.core_Mat_checkVector3_excsafe(ref ret, self, elemChannels, depth, requireContinuous);

	if(isExc)
		handleException();
	return ret;
}


public static  System.IntPtr core_Mat_clone( System.IntPtr self )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.core_Mat_clone_excsafe(ref ret, self);

	if(isExc)
		handleException();
	return ret;
}


public static  System.IntPtr core_Mat_col_toMat( System.IntPtr self ,  System.Int32 x )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.core_Mat_col_toMat_excsafe(ref ret, self, x);

	if(isExc)
		handleException();
	return ret;
}


public static  System.IntPtr core_Mat_col_toMatExpr( System.IntPtr self ,  System.Int32 x )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.core_Mat_col_toMatExpr_excsafe(ref ret, self, x);

	if(isExc)
		handleException();
	return ret;
}


public static  System.Int32 core_Mat_cols( System.IntPtr self )
{
	System.Int32 ret = new System.Int32();
	bool isExc = NativeMethodsExc.core_Mat_cols_excsafe(ref ret, self);

	if(isExc)
		handleException();
	return ret;
}


public static  System.IntPtr core_Mat_colRange_toMat( System.IntPtr self ,  System.Int32 startCol ,  System.Int32 endCol )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.core_Mat_colRange_toMat_excsafe(ref ret, self, startCol, endCol);

	if(isExc)
		handleException();
	return ret;
}


public static  System.IntPtr core_Mat_colRange_toMatExpr( System.IntPtr self ,  System.Int32 startCol ,  System.Int32 endCol )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.core_Mat_colRange_toMatExpr_excsafe(ref ret, self, startCol, endCol);

	if(isExc)
		handleException();
	return ret;
}


public static  System.Int32 core_Mat_dims( System.IntPtr self )
{
	System.Int32 ret = new System.Int32();
	bool isExc = NativeMethodsExc.core_Mat_dims_excsafe(ref ret, self);

	if(isExc)
		handleException();
	return ret;
}


public static  void core_Mat_convertTo( System.IntPtr self ,  System.IntPtr m ,  System.Int32 rtype ,  System.Double alpha ,  System.Double beta )
{
	bool isExc = NativeMethodsExc.core_Mat_convertTo_excsafe(self, m, rtype, alpha, beta);

	if(isExc)
		handleException();
}


public static  void core_Mat_copyTo( System.IntPtr self ,  System.IntPtr m ,  System.IntPtr mask )
{
	bool isExc = NativeMethodsExc.core_Mat_copyTo_excsafe(self, m, mask);

	if(isExc)
		handleException();
}


public static  void core_Mat_create1( System.IntPtr self ,  System.Int32 rows ,  System.Int32 cols ,  System.Int32 type )
{
	bool isExc = NativeMethodsExc.core_Mat_create1_excsafe(self, rows, cols, type);

	if(isExc)
		handleException();
}


public static  void core_Mat_create2( System.IntPtr self ,  System.Int32 ndims , [MarshalAs(UnmanagedType.LPArray)] System.Int32[] sizes ,  System.Int32 type )
{
	bool isExc = NativeMethodsExc.core_Mat_create2_excsafe(self, ndims, sizes, type);

	if(isExc)
		handleException();
}


public static  System.IntPtr core_Mat_cross( System.IntPtr self ,  System.IntPtr m )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.core_Mat_cross_excsafe(ref ret, self, m);

	if(isExc)
		handleException();
	return ret;
}


public static  unsafe System.Byte* core_Mat_data( System.IntPtr self )
{
	IntPtr ret = new IntPtr();
	bool isExc = NativeMethodsExc.core_Mat_data_excsafe(ref ret, self);

	if(isExc)
		handleException();
	return (System.Byte*)ret;
}


public static  System.IntPtr core_Mat_datastart( System.IntPtr self )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.core_Mat_datastart_excsafe(ref ret, self);

	if(isExc)
		handleException();
	return ret;
}


public static  System.IntPtr core_Mat_dataend( System.IntPtr self )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.core_Mat_dataend_excsafe(ref ret, self);

	if(isExc)
		handleException();
	return ret;
}


public static  System.IntPtr core_Mat_datalimit( System.IntPtr self )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.core_Mat_datalimit_excsafe(ref ret, self);

	if(isExc)
		handleException();
	return ret;
}


public static  System.Int32 core_Mat_depth( System.IntPtr self )
{
	System.Int32 ret = new System.Int32();
	bool isExc = NativeMethodsExc.core_Mat_depth_excsafe(ref ret, self);

	if(isExc)
		handleException();
	return ret;
}


public static  System.IntPtr core_Mat_diag1( System.IntPtr self )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.core_Mat_diag1_excsafe(ref ret, self);

	if(isExc)
		handleException();
	return ret;
}


public static  System.IntPtr core_Mat_diag2( System.IntPtr self ,  System.Int32 d )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.core_Mat_diag2_excsafe(ref ret, self, d);

	if(isExc)
		handleException();
	return ret;
}


public static  System.Int32 core_InputArray_isSubmatrix( System.IntPtr ia ,  System.Int32 i )
{
	System.Int32 ret = new System.Int32();
	bool isExc = NativeMethodsExc.core_InputArray_isSubmatrix_excsafe(ref ret, ia, i);

	if(isExc)
		handleException();
	return ret;
}


public static  System.Int32 core_InputArray_empty( System.IntPtr ia )
{
	System.Int32 ret = new System.Int32();
	bool isExc = NativeMethodsExc.core_InputArray_empty_excsafe(ref ret, ia);

	if(isExc)
		handleException();
	return ret;
}


public static  void core_InputArray_copyTo1( System.IntPtr ia ,  System.IntPtr arr )
{
	bool isExc = NativeMethodsExc.core_InputArray_copyTo1_excsafe(ia, arr);

	if(isExc)
		handleException();
}


public static  void core_InputArray_copyTo2( System.IntPtr ia ,  System.IntPtr arr ,  System.IntPtr mask )
{
	bool isExc = NativeMethodsExc.core_InputArray_copyTo2_excsafe(ia, arr, mask);

	if(isExc)
		handleException();
}


public static  System.IntPtr core_InputArray_offset( System.IntPtr ia ,  System.Int32 i )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.core_InputArray_offset_excsafe(ref ret, ia, i);

	if(isExc)
		handleException();
	return ret;
}


public static  System.IntPtr core_InputArray_step( System.IntPtr ia ,  System.Int32 i )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.core_InputArray_step_excsafe(ref ret, ia, i);

	if(isExc)
		handleException();
	return ret;
}


public static  System.Int32 core_InputArray_isMat( System.IntPtr ia )
{
	System.Int32 ret = new System.Int32();
	bool isExc = NativeMethodsExc.core_InputArray_isMat_excsafe(ref ret, ia);

	if(isExc)
		handleException();
	return ret;
}


public static  System.Int32 core_InputArray_isUMat( System.IntPtr ia )
{
	System.Int32 ret = new System.Int32();
	bool isExc = NativeMethodsExc.core_InputArray_isUMat_excsafe(ref ret, ia);

	if(isExc)
		handleException();
	return ret;
}


public static  System.Int32 core_InputArray_isMatVector( System.IntPtr ia )
{
	System.Int32 ret = new System.Int32();
	bool isExc = NativeMethodsExc.core_InputArray_isMatVector_excsafe(ref ret, ia);

	if(isExc)
		handleException();
	return ret;
}


public static  System.Int32 core_InputArray_isUMatVector( System.IntPtr ia )
{
	System.Int32 ret = new System.Int32();
	bool isExc = NativeMethodsExc.core_InputArray_isUMatVector_excsafe(ref ret, ia);

	if(isExc)
		handleException();
	return ret;
}


public static  System.Int32 core_InputArray_isMatx( System.IntPtr ia )
{
	System.Int32 ret = new System.Int32();
	bool isExc = NativeMethodsExc.core_InputArray_isMatx_excsafe(ref ret, ia);

	if(isExc)
		handleException();
	return ret;
}


public static  System.Int32 core_InputArray_isVector( System.IntPtr ia )
{
	System.Int32 ret = new System.Int32();
	bool isExc = NativeMethodsExc.core_InputArray_isVector_excsafe(ref ret, ia);

	if(isExc)
		handleException();
	return ret;
}


public static  System.Int32 core_InputArray_isGpuMatVector( System.IntPtr ia )
{
	System.Int32 ret = new System.Int32();
	bool isExc = NativeMethodsExc.core_InputArray_isGpuMatVector_excsafe(ref ret, ia);

	if(isExc)
		handleException();
	return ret;
}


public static  System.UInt64 core_Mat_sizeof()
{
	System.UInt64 ret = new System.UInt64();
	bool isExc = NativeMethodsExc.core_Mat_sizeof_excsafe(ref ret);

	if(isExc)
		handleException();
	return ret;
}


public static  System.IntPtr core_Mat_new1()
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.core_Mat_new1_excsafe(ref ret);

	if(isExc)
		handleException();
	return ret;
}


public static  System.IntPtr core_Mat_new2( System.Int32 rows ,  System.Int32 cols ,  System.Int32 type )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.core_Mat_new2_excsafe(ref ret, rows, cols, type);

	if(isExc)
		handleException();
	return ret;
}


public static  System.IntPtr core_Mat_new3( System.Int32 rows ,  System.Int32 cols ,  System.Int32 type ,  OpenCvSharp.Scalar scalar )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.core_Mat_new3_excsafe(ref ret, rows, cols, type, scalar);

	if(isExc)
		handleException();
	return ret;
}


public static  System.IntPtr core_Mat_new4( System.IntPtr mat ,  OpenCvSharp.Range rowRange ,  OpenCvSharp.Range colRange )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.core_Mat_new4_excsafe(ref ret, mat, rowRange, colRange);

	if(isExc)
		handleException();
	return ret;
}


public static  System.IntPtr core_Mat_new5( System.IntPtr mat ,  OpenCvSharp.Range rowRange )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.core_Mat_new5_excsafe(ref ret, mat, rowRange);

	if(isExc)
		handleException();
	return ret;
}


public static  System.IntPtr core_Mat_new6( System.IntPtr mat , [MarshalAs(UnmanagedType.LPArray)] OpenCvSharp.Range[] rowRange )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.core_Mat_new6_excsafe(ref ret, mat, rowRange);

	if(isExc)
		handleException();
	return ret;
}


public static  System.IntPtr core_Mat_new7( System.IntPtr mat ,  OpenCvSharp.Rect roi )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.core_Mat_new7_excsafe(ref ret, mat, roi);

	if(isExc)
		handleException();
	return ret;
}


public static  System.IntPtr core_Mat_new8( System.Int32 rows ,  System.Int32 cols ,  System.Int32 type ,  System.IntPtr data ,  System.IntPtr step )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.core_Mat_new8_excsafe(ref ret, rows, cols, type, data, step);

	if(isExc)
		handleException();
	return ret;
}


public static  System.IntPtr core_Mat_new9( System.Int32 ndims , [MarshalAs(UnmanagedType.LPArray)] System.Int32[] sizes ,  System.Int32 type ,  System.IntPtr data , [MarshalAs(UnmanagedType.LPArray)] System.IntPtr[] steps )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.core_Mat_new9_excsafe(ref ret, ndims, sizes, type, data, steps);

	if(isExc)
		handleException();
	return ret;
}


public static  System.IntPtr core_Mat_new9( System.Int32 ndims , [MarshalAs(UnmanagedType.LPArray)] System.Int32[] sizes ,  System.Int32 type ,  System.IntPtr data ,  System.IntPtr steps )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.core_Mat_new9_excsafe(ref ret, ndims, sizes, type, data, steps);

	if(isExc)
		handleException();
	return ret;
}


public static  System.IntPtr core_Mat_new10( System.Int32 ndims , [MarshalAs(UnmanagedType.LPArray)] System.Int32[] sizes ,  System.Int32 type )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.core_Mat_new10_excsafe(ref ret, ndims, sizes, type);

	if(isExc)
		handleException();
	return ret;
}


public static  System.IntPtr core_Mat_new11( System.Int32 ndims , [MarshalAs(UnmanagedType.LPArray)] System.Int32[] sizes ,  System.Int32 type ,  OpenCvSharp.Scalar s )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.core_Mat_new11_excsafe(ref ret, ndims, sizes, type, s);

	if(isExc)
		handleException();
	return ret;
}


public static  System.IntPtr core_Mat_new_FromIplImage( System.IntPtr img ,  System.Int32 copyData )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.core_Mat_new_FromIplImage_excsafe(ref ret, img, copyData);

	if(isExc)
		handleException();
	return ret;
}


public static  System.IntPtr core_Mat_new_FromCvMat( System.IntPtr mat ,  System.Int32 copyData )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.core_Mat_new_FromCvMat_excsafe(ref ret, mat, copyData);

	if(isExc)
		handleException();
	return ret;
}


public static  System.IntPtr core_InputArray_new_byMatExpr( System.IntPtr mat )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.core_InputArray_new_byMatExpr_excsafe(ref ret, mat);

	if(isExc)
		handleException();
	return ret;
}


public static  System.IntPtr core_InputArray_new_byScalar( OpenCvSharp.Scalar val )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.core_InputArray_new_byScalar_excsafe(ref ret, val);

	if(isExc)
		handleException();
	return ret;
}


public static  System.IntPtr core_InputArray_new_byDouble( System.Double val )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.core_InputArray_new_byDouble_excsafe(ref ret, val);

	if(isExc)
		handleException();
	return ret;
}


public static  System.IntPtr core_InputArray_new_byGpuMat( System.IntPtr mat )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.core_InputArray_new_byGpuMat_excsafe(ref ret, mat);

	if(isExc)
		handleException();
	return ret;
}


public static  System.IntPtr core_InputArray_new_byVectorOfMat( System.IntPtr vector )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.core_InputArray_new_byVectorOfMat_excsafe(ref ret, vector);

	if(isExc)
		handleException();
	return ret;
}


public static  void core_InputArray_delete( System.IntPtr ia )
{
	bool isExc = NativeMethodsExc.core_InputArray_delete_excsafe(ia);

	if(isExc)
		handleException();
}


public static  System.IntPtr core_InputArray_getMat( System.IntPtr ia ,  System.Int32 idx )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.core_InputArray_getMat_excsafe(ref ret, ia, idx);

	if(isExc)
		handleException();
	return ret;
}


public static  System.IntPtr core_InputArray_getMat_( System.IntPtr ia ,  System.Int32 idx )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.core_InputArray_getMat__excsafe(ref ret, ia, idx);

	if(isExc)
		handleException();
	return ret;
}


public static  System.IntPtr core_InputArray_getUMat( System.IntPtr ia ,  System.Int32 idx )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.core_InputArray_getUMat_excsafe(ref ret, ia, idx);

	if(isExc)
		handleException();
	return ret;
}


public static  void core_InputArray_getMatVector( System.IntPtr ia ,  System.IntPtr mv )
{
	bool isExc = NativeMethodsExc.core_InputArray_getMatVector_excsafe(ia, mv);

	if(isExc)
		handleException();
}


public static  void core_InputArray_getUMatVector( System.IntPtr ia ,  System.IntPtr umv )
{
	bool isExc = NativeMethodsExc.core_InputArray_getUMatVector_excsafe(ia, umv);

	if(isExc)
		handleException();
}


public static  void core_InputArray_getGpuMatVector( System.IntPtr ia ,  System.IntPtr gpumv )
{
	bool isExc = NativeMethodsExc.core_InputArray_getGpuMatVector_excsafe(ia, gpumv);

	if(isExc)
		handleException();
}


public static  System.IntPtr core_InputArray_getGpuMat( System.IntPtr ia )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.core_InputArray_getGpuMat_excsafe(ref ret, ia);

	if(isExc)
		handleException();
	return ret;
}


public static  System.Int32 core_InputArray_getFlags( System.IntPtr ia )
{
	System.Int32 ret = new System.Int32();
	bool isExc = NativeMethodsExc.core_InputArray_getFlags_excsafe(ref ret, ia);

	if(isExc)
		handleException();
	return ret;
}


public static  System.IntPtr core_InputArray_getObj( System.IntPtr ia )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.core_InputArray_getObj_excsafe(ref ret, ia);

	if(isExc)
		handleException();
	return ret;
}


public static  OpenCvSharp.Size core_InputArray_getSz( System.IntPtr ia )
{
	OpenCvSharp.Size ret = new OpenCvSharp.Size();
	bool isExc = NativeMethodsExc.core_InputArray_getSz_excsafe(ref ret, ia);

	if(isExc)
		handleException();
	return ret;
}


public static  System.Int32 core_InputArray_kind( System.IntPtr ia )
{
	System.Int32 ret = new System.Int32();
	bool isExc = NativeMethodsExc.core_InputArray_kind_excsafe(ref ret, ia);

	if(isExc)
		handleException();
	return ret;
}


public static  System.Int32 core_InputArray_dims( System.IntPtr ia ,  System.Int32 i )
{
	System.Int32 ret = new System.Int32();
	bool isExc = NativeMethodsExc.core_InputArray_dims_excsafe(ref ret, ia, i);

	if(isExc)
		handleException();
	return ret;
}


public static  System.Int32 core_InputArray_cols( System.IntPtr ia ,  System.Int32 i )
{
	System.Int32 ret = new System.Int32();
	bool isExc = NativeMethodsExc.core_InputArray_cols_excsafe(ref ret, ia, i);

	if(isExc)
		handleException();
	return ret;
}


public static  System.Int32 core_InputArray_rows( System.IntPtr ia ,  System.Int32 i )
{
	System.Int32 ret = new System.Int32();
	bool isExc = NativeMethodsExc.core_InputArray_rows_excsafe(ref ret, ia, i);

	if(isExc)
		handleException();
	return ret;
}


public static  OpenCvSharp.Size core_InputArray_size( System.IntPtr ia ,  System.Int32 i )
{
	OpenCvSharp.Size ret = new OpenCvSharp.Size();
	bool isExc = NativeMethodsExc.core_InputArray_size_excsafe(ref ret, ia, i);

	if(isExc)
		handleException();
	return ret;
}


public static  System.Int32 core_InputArray_sizend( System.IntPtr ia ,  System.Int32[] sz ,  System.Int32 i )
{
	System.Int32 ret = new System.Int32();
	bool isExc = NativeMethodsExc.core_InputArray_sizend_excsafe(ref ret, ia, sz, i);

	if(isExc)
		handleException();
	return ret;
}


public static  System.Int32 core_InputArray_sameSize( System.IntPtr self ,  System.IntPtr target )
{
	System.Int32 ret = new System.Int32();
	bool isExc = NativeMethodsExc.core_InputArray_sameSize_excsafe(ref ret, self, target);

	if(isExc)
		handleException();
	return ret;
}


public static  System.IntPtr core_InputArray_total( System.IntPtr ia ,  System.Int32 i )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.core_InputArray_total_excsafe(ref ret, ia, i);

	if(isExc)
		handleException();
	return ret;
}


public static  System.Int32 core_InputArray_type( System.IntPtr ia ,  System.Int32 i )
{
	System.Int32 ret = new System.Int32();
	bool isExc = NativeMethodsExc.core_InputArray_type_excsafe(ref ret, ia, i);

	if(isExc)
		handleException();
	return ret;
}


public static  System.Int32 core_InputArray_depth( System.IntPtr ia ,  System.Int32 i )
{
	System.Int32 ret = new System.Int32();
	bool isExc = NativeMethodsExc.core_InputArray_depth_excsafe(ref ret, ia, i);

	if(isExc)
		handleException();
	return ret;
}


public static  System.Int32 core_InputArray_channels( System.IntPtr ia ,  System.Int32 i )
{
	System.Int32 ret = new System.Int32();
	bool isExc = NativeMethodsExc.core_InputArray_channels_excsafe(ref ret, ia, i);

	if(isExc)
		handleException();
	return ret;
}


public static  System.Int32 core_InputArray_isContinuous( System.IntPtr ia ,  System.Int32 i )
{
	System.Int32 ret = new System.Int32();
	bool isExc = NativeMethodsExc.core_InputArray_isContinuous_excsafe(ref ret, ia, i);

	if(isExc)
		handleException();
	return ret;
}


public static  void core_FileStorage_shift_Rect2f( System.IntPtr fs ,  OpenCvSharp.Rect2f val )
{
	bool isExc = NativeMethodsExc.core_FileStorage_shift_Rect2f_excsafe(fs, val);

	if(isExc)
		handleException();
}


public static  void core_FileStorage_shift_Rect2d( System.IntPtr fs ,  OpenCvSharp.Rect2d val )
{
	bool isExc = NativeMethodsExc.core_FileStorage_shift_Rect2d_excsafe(fs, val);

	if(isExc)
		handleException();
}


public static  void core_FileStorage_shift_Scalar( System.IntPtr fs ,  OpenCvSharp.Scalar val )
{
	bool isExc = NativeMethodsExc.core_FileStorage_shift_Scalar_excsafe(fs, val);

	if(isExc)
		handleException();
}


public static  void core_FileStorage_shift_Vec2i( System.IntPtr fs ,  OpenCvSharp.Vec2i val )
{
	bool isExc = NativeMethodsExc.core_FileStorage_shift_Vec2i_excsafe(fs, val);

	if(isExc)
		handleException();
}


public static  void core_FileStorage_shift_Vec3i( System.IntPtr fs ,  OpenCvSharp.Vec3i val )
{
	bool isExc = NativeMethodsExc.core_FileStorage_shift_Vec3i_excsafe(fs, val);

	if(isExc)
		handleException();
}


public static  void core_FileStorage_shift_Vec4i( System.IntPtr fs ,  OpenCvSharp.Vec4i val )
{
	bool isExc = NativeMethodsExc.core_FileStorage_shift_Vec4i_excsafe(fs, val);

	if(isExc)
		handleException();
}


public static  void core_FileStorage_shift_Vec6i( System.IntPtr fs ,  OpenCvSharp.Vec6i val )
{
	bool isExc = NativeMethodsExc.core_FileStorage_shift_Vec6i_excsafe(fs, val);

	if(isExc)
		handleException();
}


public static  void core_FileStorage_shift_Vec2d( System.IntPtr fs ,  OpenCvSharp.Vec2d val )
{
	bool isExc = NativeMethodsExc.core_FileStorage_shift_Vec2d_excsafe(fs, val);

	if(isExc)
		handleException();
}


public static  void core_FileStorage_shift_Vec3d( System.IntPtr fs ,  OpenCvSharp.Vec3d val )
{
	bool isExc = NativeMethodsExc.core_FileStorage_shift_Vec3d_excsafe(fs, val);

	if(isExc)
		handleException();
}


public static  void core_FileStorage_shift_Vec4d( System.IntPtr fs ,  OpenCvSharp.Vec4d val )
{
	bool isExc = NativeMethodsExc.core_FileStorage_shift_Vec4d_excsafe(fs, val);

	if(isExc)
		handleException();
}


public static  void core_FileStorage_shift_Vec6d( System.IntPtr fs ,  OpenCvSharp.Vec6d val )
{
	bool isExc = NativeMethodsExc.core_FileStorage_shift_Vec6d_excsafe(fs, val);

	if(isExc)
		handleException();
}


public static  void core_FileStorage_shift_Vec2f( System.IntPtr fs ,  OpenCvSharp.Vec2f val )
{
	bool isExc = NativeMethodsExc.core_FileStorage_shift_Vec2f_excsafe(fs, val);

	if(isExc)
		handleException();
}


public static  void core_FileStorage_shift_Vec3f( System.IntPtr fs ,  OpenCvSharp.Vec3f val )
{
	bool isExc = NativeMethodsExc.core_FileStorage_shift_Vec3f_excsafe(fs, val);

	if(isExc)
		handleException();
}


public static  void core_FileStorage_shift_Vec4f( System.IntPtr fs ,  OpenCvSharp.Vec4f val )
{
	bool isExc = NativeMethodsExc.core_FileStorage_shift_Vec4f_excsafe(fs, val);

	if(isExc)
		handleException();
}


public static  void core_FileStorage_shift_Vec6f( System.IntPtr fs ,  OpenCvSharp.Vec6f val )
{
	bool isExc = NativeMethodsExc.core_FileStorage_shift_Vec6f_excsafe(fs, val);

	if(isExc)
		handleException();
}


public static  void core_FileStorage_shift_Vec2b( System.IntPtr fs ,  OpenCvSharp.Vec2b val )
{
	bool isExc = NativeMethodsExc.core_FileStorage_shift_Vec2b_excsafe(fs, val);

	if(isExc)
		handleException();
}


public static  void core_FileStorage_shift_Vec3b( System.IntPtr fs ,  OpenCvSharp.Vec3b val )
{
	bool isExc = NativeMethodsExc.core_FileStorage_shift_Vec3b_excsafe(fs, val);

	if(isExc)
		handleException();
}


public static  void core_FileStorage_shift_Vec4b( System.IntPtr fs ,  OpenCvSharp.Vec4b val )
{
	bool isExc = NativeMethodsExc.core_FileStorage_shift_Vec4b_excsafe(fs, val);

	if(isExc)
		handleException();
}


public static  void core_FileStorage_shift_Vec6b( System.IntPtr fs ,  OpenCvSharp.Vec6b val )
{
	bool isExc = NativeMethodsExc.core_FileStorage_shift_Vec6b_excsafe(fs, val);

	if(isExc)
		handleException();
}


public static  void core_FileStorage_shift_Vec2s( System.IntPtr fs ,  OpenCvSharp.Vec2s val )
{
	bool isExc = NativeMethodsExc.core_FileStorage_shift_Vec2s_excsafe(fs, val);

	if(isExc)
		handleException();
}


public static  void core_FileStorage_shift_Vec3s( System.IntPtr fs ,  OpenCvSharp.Vec3s val )
{
	bool isExc = NativeMethodsExc.core_FileStorage_shift_Vec3s_excsafe(fs, val);

	if(isExc)
		handleException();
}


public static  void core_FileStorage_shift_Vec4s( System.IntPtr fs ,  OpenCvSharp.Vec4s val )
{
	bool isExc = NativeMethodsExc.core_FileStorage_shift_Vec4s_excsafe(fs, val);

	if(isExc)
		handleException();
}


public static  void core_FileStorage_shift_Vec6s( System.IntPtr fs ,  OpenCvSharp.Vec6s val )
{
	bool isExc = NativeMethodsExc.core_FileStorage_shift_Vec6s_excsafe(fs, val);

	if(isExc)
		handleException();
}


public static  void core_FileStorage_shift_Vec2w( System.IntPtr fs ,  OpenCvSharp.Vec2w val )
{
	bool isExc = NativeMethodsExc.core_FileStorage_shift_Vec2w_excsafe(fs, val);

	if(isExc)
		handleException();
}


public static  void core_FileStorage_shift_Vec3w( System.IntPtr fs ,  OpenCvSharp.Vec3w val )
{
	bool isExc = NativeMethodsExc.core_FileStorage_shift_Vec3w_excsafe(fs, val);

	if(isExc)
		handleException();
}


public static  void core_FileStorage_shift_Vec4w( System.IntPtr fs ,  OpenCvSharp.Vec4w val )
{
	bool isExc = NativeMethodsExc.core_FileStorage_shift_Vec4w_excsafe(fs, val);

	if(isExc)
		handleException();
}


public static  void core_FileStorage_shift_Vec6w( System.IntPtr fs ,  OpenCvSharp.Vec6w val )
{
	bool isExc = NativeMethodsExc.core_FileStorage_shift_Vec6w_excsafe(fs, val);

	if(isExc)
		handleException();
}


public static  System.IntPtr core_InputArray_new_byMat( System.IntPtr mat )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.core_InputArray_new_byMat_excsafe(ref ret, mat);

	if(isExc)
		handleException();
	return ret;
}


public static  void core_FileStorage_write_SparseMat( System.IntPtr fs , [MarshalAs(UnmanagedType.LPStr)] System.String name ,  System.IntPtr value )
{
	bool isExc = NativeMethodsExc.core_FileStorage_write_SparseMat_excsafe(fs, name, value);

	if(isExc)
		handleException();
}


public static  void core_FileStorage_write_vectorOfKeyPoint( System.IntPtr fs , [MarshalAs(UnmanagedType.LPStr)] System.String name ,  System.IntPtr value )
{
	bool isExc = NativeMethodsExc.core_FileStorage_write_vectorOfKeyPoint_excsafe(fs, name, value);

	if(isExc)
		handleException();
}


public static  void core_FileStorage_write_vectorOfDMatch( System.IntPtr fs , [MarshalAs(UnmanagedType.LPStr)] System.String name ,  System.IntPtr value )
{
	bool isExc = NativeMethodsExc.core_FileStorage_write_vectorOfDMatch_excsafe(fs, name, value);

	if(isExc)
		handleException();
}


public static  void core_FileStorage_writeScalar_int( System.IntPtr fs ,  System.Int32 value )
{
	bool isExc = NativeMethodsExc.core_FileStorage_writeScalar_int_excsafe(fs, value);

	if(isExc)
		handleException();
}


public static  void core_FileStorage_writeScalar_float( System.IntPtr fs ,  System.Single value )
{
	bool isExc = NativeMethodsExc.core_FileStorage_writeScalar_float_excsafe(fs, value);

	if(isExc)
		handleException();
}


public static  void core_FileStorage_writeScalar_double( System.IntPtr fs ,  System.Double value )
{
	bool isExc = NativeMethodsExc.core_FileStorage_writeScalar_double_excsafe(fs, value);

	if(isExc)
		handleException();
}


public static  void core_FileStorage_writeScalar_String( System.IntPtr fs , [MarshalAs(UnmanagedType.LPStr)] System.String value )
{
	bool isExc = NativeMethodsExc.core_FileStorage_writeScalar_String_excsafe(fs, value);

	if(isExc)
		handleException();
}


public static  void core_FileStorage_shift_String( System.IntPtr fs , [MarshalAs(UnmanagedType.LPStr)] System.String val )
{
	bool isExc = NativeMethodsExc.core_FileStorage_shift_String_excsafe(fs, val);

	if(isExc)
		handleException();
}


public static  void core_FileStorage_shift_int( System.IntPtr fs ,  System.Int32 val )
{
	bool isExc = NativeMethodsExc.core_FileStorage_shift_int_excsafe(fs, val);

	if(isExc)
		handleException();
}


public static  void core_FileStorage_shift_float( System.IntPtr fs ,  System.Single val )
{
	bool isExc = NativeMethodsExc.core_FileStorage_shift_float_excsafe(fs, val);

	if(isExc)
		handleException();
}


public static  void core_FileStorage_shift_double( System.IntPtr fs ,  System.Double val )
{
	bool isExc = NativeMethodsExc.core_FileStorage_shift_double_excsafe(fs, val);

	if(isExc)
		handleException();
}


public static  void core_FileStorage_shift_Mat( System.IntPtr fs ,  System.IntPtr val )
{
	bool isExc = NativeMethodsExc.core_FileStorage_shift_Mat_excsafe(fs, val);

	if(isExc)
		handleException();
}


public static  void core_FileStorage_shift_SparseMat( System.IntPtr fs ,  System.IntPtr val )
{
	bool isExc = NativeMethodsExc.core_FileStorage_shift_SparseMat_excsafe(fs, val);

	if(isExc)
		handleException();
}


public static  void core_FileStorage_shift_Range( System.IntPtr fs ,  OpenCvSharp.Range val )
{
	bool isExc = NativeMethodsExc.core_FileStorage_shift_Range_excsafe(fs, val);

	if(isExc)
		handleException();
}


public static  void core_FileStorage_shift_KeyPoint( System.IntPtr fs ,  OpenCvSharp.KeyPoint val )
{
	bool isExc = NativeMethodsExc.core_FileStorage_shift_KeyPoint_excsafe(fs, val);

	if(isExc)
		handleException();
}


public static  void core_FileStorage_shift_DMatch( System.IntPtr fs ,  OpenCvSharp.DMatch val )
{
	bool isExc = NativeMethodsExc.core_FileStorage_shift_DMatch_excsafe(fs, val);

	if(isExc)
		handleException();
}


public static  void core_FileStorage_shift_vectorOfKeyPoint( System.IntPtr fs ,  System.IntPtr val )
{
	bool isExc = NativeMethodsExc.core_FileStorage_shift_vectorOfKeyPoint_excsafe(fs, val);

	if(isExc)
		handleException();
}


public static  void core_FileStorage_shift_vectorOfDMatch( System.IntPtr fs ,  System.IntPtr val )
{
	bool isExc = NativeMethodsExc.core_FileStorage_shift_vectorOfDMatch_excsafe(fs, val);

	if(isExc)
		handleException();
}


public static  void core_FileStorage_shift_Point2i( System.IntPtr fs ,  OpenCvSharp.Point val )
{
	bool isExc = NativeMethodsExc.core_FileStorage_shift_Point2i_excsafe(fs, val);

	if(isExc)
		handleException();
}


public static  void core_FileStorage_shift_Point2f( System.IntPtr fs ,  OpenCvSharp.Point2f val )
{
	bool isExc = NativeMethodsExc.core_FileStorage_shift_Point2f_excsafe(fs, val);

	if(isExc)
		handleException();
}


public static  void core_FileStorage_shift_Point2d( System.IntPtr fs ,  OpenCvSharp.Point2d val )
{
	bool isExc = NativeMethodsExc.core_FileStorage_shift_Point2d_excsafe(fs, val);

	if(isExc)
		handleException();
}


public static  void core_FileStorage_shift_Point3i( System.IntPtr fs ,  OpenCvSharp.Point3i val )
{
	bool isExc = NativeMethodsExc.core_FileStorage_shift_Point3i_excsafe(fs, val);

	if(isExc)
		handleException();
}


public static  void core_FileStorage_shift_Point3f( System.IntPtr fs ,  OpenCvSharp.Point3f val )
{
	bool isExc = NativeMethodsExc.core_FileStorage_shift_Point3f_excsafe(fs, val);

	if(isExc)
		handleException();
}


public static  void core_FileStorage_shift_Point3d( System.IntPtr fs ,  OpenCvSharp.Point3d val )
{
	bool isExc = NativeMethodsExc.core_FileStorage_shift_Point3d_excsafe(fs, val);

	if(isExc)
		handleException();
}


public static  void core_FileStorage_shift_Size2i( System.IntPtr fs ,  OpenCvSharp.Size val )
{
	bool isExc = NativeMethodsExc.core_FileStorage_shift_Size2i_excsafe(fs, val);

	if(isExc)
		handleException();
}


public static  void core_FileStorage_shift_Size2f( System.IntPtr fs ,  OpenCvSharp.Size2f val )
{
	bool isExc = NativeMethodsExc.core_FileStorage_shift_Size2f_excsafe(fs, val);

	if(isExc)
		handleException();
}


public static  void core_FileStorage_shift_Size2d( System.IntPtr fs ,  OpenCvSharp.Size2d val )
{
	bool isExc = NativeMethodsExc.core_FileStorage_shift_Size2d_excsafe(fs, val);

	if(isExc)
		handleException();
}


public static  void core_FileStorage_shift_Rect2i( System.IntPtr fs ,  OpenCvSharp.Rect val )
{
	bool isExc = NativeMethodsExc.core_FileStorage_shift_Rect2i_excsafe(fs, val);

	if(isExc)
		handleException();
}


public static  System.IntPtr core_FileNodeIterator_readRaw( System.IntPtr obj , [MarshalAs(UnmanagedType.LPStr)] System.String fmt ,  System.IntPtr vec ,  System.IntPtr maxCount )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.core_FileNodeIterator_readRaw_excsafe(ref ret, obj, fmt, vec, maxCount);

	if(isExc)
		handleException();
	return ret;
}


public static  System.IntPtr core_FileNodeIterator_readRaw( System.IntPtr obj , [MarshalAs(UnmanagedType.LPStr)] System.String fmt ,  System.Byte[] vec ,  System.IntPtr maxCount )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.core_FileNodeIterator_readRaw_excsafe(ref ret, obj, fmt, vec, maxCount);

	if(isExc)
		handleException();
	return ret;
}


public static  System.Int32 core_FileNodeIterator_operatorEqual( System.IntPtr it1 ,  System.IntPtr it2 )
{
	System.Int32 ret = new System.Int32();
	bool isExc = NativeMethodsExc.core_FileNodeIterator_operatorEqual_excsafe(ref ret, it1, it2);

	if(isExc)
		handleException();
	return ret;
}


public static  System.IntPtr core_FileNodeIterator_operatorMinus( System.IntPtr it1 ,  System.IntPtr it2 )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.core_FileNodeIterator_operatorMinus_excsafe(ref ret, it1, it2);

	if(isExc)
		handleException();
	return ret;
}


public static  System.Int32 core_FileNodeIterator_operatorLessThan( System.IntPtr it1 ,  System.IntPtr it2 )
{
	System.Int32 ret = new System.Int32();
	bool isExc = NativeMethodsExc.core_FileNodeIterator_operatorLessThan_excsafe(ref ret, it1, it2);

	if(isExc)
		handleException();
	return ret;
}


public static  System.IntPtr core_FileStorage_new1()
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.core_FileStorage_new1_excsafe(ref ret);

	if(isExc)
		handleException();
	return ret;
}


public static  System.IntPtr core_FileStorage_new2([MarshalAs(UnmanagedType.LPStr)] System.String source ,  System.Int32 flags , [MarshalAs(UnmanagedType.LPStr)] System.String encoding )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.core_FileStorage_new2_excsafe(ref ret, source, flags, encoding);

	if(isExc)
		handleException();
	return ret;
}


public static  System.IntPtr core_FileStorage_newFromLegacy( System.IntPtr fs )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.core_FileStorage_newFromLegacy_excsafe(ref ret, fs);

	if(isExc)
		handleException();
	return ret;
}


public static  void core_FileStorage_delete( System.IntPtr obj )
{
	bool isExc = NativeMethodsExc.core_FileStorage_delete_excsafe(obj);

	if(isExc)
		handleException();
}


public static  System.Int32 core_FileStorage_open( System.IntPtr obj , [MarshalAs(UnmanagedType.LPStr)] System.String filename ,  System.Int32 flags , [MarshalAs(UnmanagedType.LPStr)] System.String encoding )
{
	System.Int32 ret = new System.Int32();
	bool isExc = NativeMethodsExc.core_FileStorage_open_excsafe(ref ret, obj, filename, flags, encoding);

	if(isExc)
		handleException();
	return ret;
}


public static  System.Int32 core_FileStorage_isOpened( System.IntPtr obj )
{
	System.Int32 ret = new System.Int32();
	bool isExc = NativeMethodsExc.core_FileStorage_isOpened_excsafe(ref ret, obj);

	if(isExc)
		handleException();
	return ret;
}


public static  void core_FileStorage_release( System.IntPtr obj )
{
	bool isExc = NativeMethodsExc.core_FileStorage_release_excsafe(obj);

	if(isExc)
		handleException();
}


public static  void core_FileStorage_releaseAndGetString( System.IntPtr obj , [MarshalAs(UnmanagedType.LPStr)] System.Text.StringBuilder buf ,  System.Int32 bufLength )
{
	bool isExc = NativeMethodsExc.core_FileStorage_releaseAndGetString_excsafe(obj, buf, bufLength);

	if(isExc)
		handleException();
}


public static  System.IntPtr core_FileStorage_getFirstTopLevelNode( System.IntPtr obj )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.core_FileStorage_getFirstTopLevelNode_excsafe(ref ret, obj);

	if(isExc)
		handleException();
	return ret;
}


public static  System.IntPtr core_FileStorage_root( System.IntPtr obj ,  System.Int32 streamIdx )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.core_FileStorage_root_excsafe(ref ret, obj, streamIdx);

	if(isExc)
		handleException();
	return ret;
}


public static  System.IntPtr core_FileStorage_indexer( System.IntPtr obj , [MarshalAs(UnmanagedType.LPStr)] System.String nodeName )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.core_FileStorage_indexer_excsafe(ref ret, obj, nodeName);

	if(isExc)
		handleException();
	return ret;
}


public static  System.IntPtr core_FileStorage_toLegacy( System.IntPtr obj )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.core_FileStorage_toLegacy_excsafe(ref ret, obj);

	if(isExc)
		handleException();
	return ret;
}


public static  void core_FileStorage_writeRaw( System.IntPtr obj , [MarshalAs(UnmanagedType.LPStr)] System.String fmt ,  System.IntPtr vec ,  System.IntPtr len )
{
	bool isExc = NativeMethodsExc.core_FileStorage_writeRaw_excsafe(obj, fmt, vec, len);

	if(isExc)
		handleException();
}


public static  void core_FileStorage_writeObj( System.IntPtr obj , [MarshalAs(UnmanagedType.LPStr)] System.String name ,  System.IntPtr value )
{
	bool isExc = NativeMethodsExc.core_FileStorage_writeObj_excsafe(obj, name, value);

	if(isExc)
		handleException();
}


public static  void core_FileStorage_getDefaultObjectName([MarshalAs(UnmanagedType.LPStr)] System.String filename , [MarshalAs(UnmanagedType.LPStr)] System.Text.StringBuilder buf ,  System.Int32 bufLength )
{
	bool isExc = NativeMethodsExc.core_FileStorage_getDefaultObjectName_excsafe(filename, buf, bufLength);

	if(isExc)
		handleException();
}


public static  unsafe System.SByte* core_FileStorage_elname( System.IntPtr obj )
{
	IntPtr ret = new IntPtr();
	bool isExc = NativeMethodsExc.core_FileStorage_elname_excsafe(ref ret, obj);

	if(isExc)
		handleException();
	return (System.SByte*)ret;
}


public static  System.IntPtr core_FileStorage_structs( System.IntPtr obj ,  out System.IntPtr resultLength )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.core_FileStorage_structs_excsafe(ref ret, obj,  out resultLength);

	if(isExc)
		handleException();
	return ret;
}


public static  System.Int32 core_FileStorage_state( System.IntPtr obj )
{
	System.Int32 ret = new System.Int32();
	bool isExc = NativeMethodsExc.core_FileStorage_state_excsafe(ref ret, obj);

	if(isExc)
		handleException();
	return ret;
}


public static  void core_FileStorage_write_int( System.IntPtr fs , [MarshalAs(UnmanagedType.LPStr)] System.String name ,  System.Int32 value )
{
	bool isExc = NativeMethodsExc.core_FileStorage_write_int_excsafe(fs, name, value);

	if(isExc)
		handleException();
}


public static  void core_FileStorage_write_float( System.IntPtr fs , [MarshalAs(UnmanagedType.LPStr)] System.String name ,  System.Single value )
{
	bool isExc = NativeMethodsExc.core_FileStorage_write_float_excsafe(fs, name, value);

	if(isExc)
		handleException();
}


public static  void core_FileStorage_write_double( System.IntPtr fs , [MarshalAs(UnmanagedType.LPStr)] System.String name ,  System.Double value )
{
	bool isExc = NativeMethodsExc.core_FileStorage_write_double_excsafe(fs, name, value);

	if(isExc)
		handleException();
}


public static  void core_FileStorage_write_String( System.IntPtr fs , [MarshalAs(UnmanagedType.LPStr)] System.String name , [MarshalAs(UnmanagedType.LPStr)] System.String value )
{
	bool isExc = NativeMethodsExc.core_FileStorage_write_String_excsafe(fs, name, value);

	if(isExc)
		handleException();
}


public static  void core_FileStorage_write_Mat( System.IntPtr fs , [MarshalAs(UnmanagedType.LPStr)] System.String name ,  System.IntPtr value )
{
	bool isExc = NativeMethodsExc.core_FileStorage_write_Mat_excsafe(fs, name, value);

	if(isExc)
		handleException();
}


public static  OpenCvSharp.Vec2d core_FileNode_read_Vec2d( System.IntPtr node )
{
	OpenCvSharp.Vec2d ret = new OpenCvSharp.Vec2d();
	bool isExc = NativeMethodsExc.core_FileNode_read_Vec2d_excsafe(ref ret, node);

	if(isExc)
		handleException();
	return ret;
}


public static  OpenCvSharp.Vec3d core_FileNode_read_Vec3d( System.IntPtr node )
{
	OpenCvSharp.Vec3d ret = new OpenCvSharp.Vec3d();
	bool isExc = NativeMethodsExc.core_FileNode_read_Vec3d_excsafe(ref ret, node);

	if(isExc)
		handleException();
	return ret;
}


public static  OpenCvSharp.Vec4d core_FileNode_read_Vec4d( System.IntPtr node )
{
	OpenCvSharp.Vec4d ret = new OpenCvSharp.Vec4d();
	bool isExc = NativeMethodsExc.core_FileNode_read_Vec4d_excsafe(ref ret, node);

	if(isExc)
		handleException();
	return ret;
}


public static  OpenCvSharp.Vec6d core_FileNode_read_Vec6d( System.IntPtr node )
{
	OpenCvSharp.Vec6d ret = new OpenCvSharp.Vec6d();
	bool isExc = NativeMethodsExc.core_FileNode_read_Vec6d_excsafe(ref ret, node);

	if(isExc)
		handleException();
	return ret;
}


public static  OpenCvSharp.Vec2f core_FileNode_read_Vec2f( System.IntPtr node )
{
	OpenCvSharp.Vec2f ret = new OpenCvSharp.Vec2f();
	bool isExc = NativeMethodsExc.core_FileNode_read_Vec2f_excsafe(ref ret, node);

	if(isExc)
		handleException();
	return ret;
}


public static  OpenCvSharp.Vec3f core_FileNode_read_Vec3f( System.IntPtr node )
{
	OpenCvSharp.Vec3f ret = new OpenCvSharp.Vec3f();
	bool isExc = NativeMethodsExc.core_FileNode_read_Vec3f_excsafe(ref ret, node);

	if(isExc)
		handleException();
	return ret;
}


public static  OpenCvSharp.Vec4f core_FileNode_read_Vec4f( System.IntPtr node )
{
	OpenCvSharp.Vec4f ret = new OpenCvSharp.Vec4f();
	bool isExc = NativeMethodsExc.core_FileNode_read_Vec4f_excsafe(ref ret, node);

	if(isExc)
		handleException();
	return ret;
}


public static  OpenCvSharp.Vec6f core_FileNode_read_Vec6f( System.IntPtr node )
{
	OpenCvSharp.Vec6f ret = new OpenCvSharp.Vec6f();
	bool isExc = NativeMethodsExc.core_FileNode_read_Vec6f_excsafe(ref ret, node);

	if(isExc)
		handleException();
	return ret;
}


public static  OpenCvSharp.Vec2b core_FileNode_read_Vec2b( System.IntPtr node )
{
	OpenCvSharp.Vec2b ret = new OpenCvSharp.Vec2b();
	bool isExc = NativeMethodsExc.core_FileNode_read_Vec2b_excsafe(ref ret, node);

	if(isExc)
		handleException();
	return ret;
}


public static  OpenCvSharp.Vec3b core_FileNode_read_Vec3b( System.IntPtr node )
{
	OpenCvSharp.Vec3b ret = new OpenCvSharp.Vec3b();
	bool isExc = NativeMethodsExc.core_FileNode_read_Vec3b_excsafe(ref ret, node);

	if(isExc)
		handleException();
	return ret;
}


public static  OpenCvSharp.Vec4b core_FileNode_read_Vec4b( System.IntPtr node )
{
	OpenCvSharp.Vec4b ret = new OpenCvSharp.Vec4b();
	bool isExc = NativeMethodsExc.core_FileNode_read_Vec4b_excsafe(ref ret, node);

	if(isExc)
		handleException();
	return ret;
}


public static  OpenCvSharp.Vec6b core_FileNode_read_Vec6b( System.IntPtr node )
{
	OpenCvSharp.Vec6b ret = new OpenCvSharp.Vec6b();
	bool isExc = NativeMethodsExc.core_FileNode_read_Vec6b_excsafe(ref ret, node);

	if(isExc)
		handleException();
	return ret;
}


public static  OpenCvSharp.Vec2s core_FileNode_read_Vec2s( System.IntPtr node )
{
	OpenCvSharp.Vec2s ret = new OpenCvSharp.Vec2s();
	bool isExc = NativeMethodsExc.core_FileNode_read_Vec2s_excsafe(ref ret, node);

	if(isExc)
		handleException();
	return ret;
}


public static  OpenCvSharp.Vec3s core_FileNode_read_Vec3s( System.IntPtr node )
{
	OpenCvSharp.Vec3s ret = new OpenCvSharp.Vec3s();
	bool isExc = NativeMethodsExc.core_FileNode_read_Vec3s_excsafe(ref ret, node);

	if(isExc)
		handleException();
	return ret;
}


public static  OpenCvSharp.Vec4s core_FileNode_read_Vec4s( System.IntPtr node )
{
	OpenCvSharp.Vec4s ret = new OpenCvSharp.Vec4s();
	bool isExc = NativeMethodsExc.core_FileNode_read_Vec4s_excsafe(ref ret, node);

	if(isExc)
		handleException();
	return ret;
}


public static  OpenCvSharp.Vec6s core_FileNode_read_Vec6s( System.IntPtr node )
{
	OpenCvSharp.Vec6s ret = new OpenCvSharp.Vec6s();
	bool isExc = NativeMethodsExc.core_FileNode_read_Vec6s_excsafe(ref ret, node);

	if(isExc)
		handleException();
	return ret;
}


public static  OpenCvSharp.Vec2w core_FileNode_read_Vec2w( System.IntPtr node )
{
	OpenCvSharp.Vec2w ret = new OpenCvSharp.Vec2w();
	bool isExc = NativeMethodsExc.core_FileNode_read_Vec2w_excsafe(ref ret, node);

	if(isExc)
		handleException();
	return ret;
}


public static  OpenCvSharp.Vec3w core_FileNode_read_Vec3w( System.IntPtr node )
{
	OpenCvSharp.Vec3w ret = new OpenCvSharp.Vec3w();
	bool isExc = NativeMethodsExc.core_FileNode_read_Vec3w_excsafe(ref ret, node);

	if(isExc)
		handleException();
	return ret;
}


public static  OpenCvSharp.Vec4w core_FileNode_read_Vec4w( System.IntPtr node )
{
	OpenCvSharp.Vec4w ret = new OpenCvSharp.Vec4w();
	bool isExc = NativeMethodsExc.core_FileNode_read_Vec4w_excsafe(ref ret, node);

	if(isExc)
		handleException();
	return ret;
}


public static  OpenCvSharp.Vec6w core_FileNode_read_Vec6w( System.IntPtr node )
{
	OpenCvSharp.Vec6w ret = new OpenCvSharp.Vec6w();
	bool isExc = NativeMethodsExc.core_FileNode_read_Vec6w_excsafe(ref ret, node);

	if(isExc)
		handleException();
	return ret;
}


public static  System.IntPtr core_FileNodeIterator_new1()
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.core_FileNodeIterator_new1_excsafe(ref ret);

	if(isExc)
		handleException();
	return ret;
}


public static  System.IntPtr core_FileNodeIterator_new2( System.IntPtr obj )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.core_FileNodeIterator_new2_excsafe(ref ret, obj);

	if(isExc)
		handleException();
	return ret;
}


public static  void core_FileNodeIterator_delete( System.IntPtr obj )
{
	bool isExc = NativeMethodsExc.core_FileNodeIterator_delete_excsafe(obj);

	if(isExc)
		handleException();
}


public static  System.IntPtr core_FileNodeIterator_operatorAsterisk( System.IntPtr obj )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.core_FileNodeIterator_operatorAsterisk_excsafe(ref ret, obj);

	if(isExc)
		handleException();
	return ret;
}


public static  System.Int32 core_FileNodeIterator_operatorIncrement( System.IntPtr obj )
{
	System.Int32 ret = new System.Int32();
	bool isExc = NativeMethodsExc.core_FileNodeIterator_operatorIncrement_excsafe(ref ret, obj);

	if(isExc)
		handleException();
	return ret;
}


public static  System.Int32 core_FileNodeIterator_operatorDecrement( System.IntPtr obj )
{
	System.Int32 ret = new System.Int32();
	bool isExc = NativeMethodsExc.core_FileNodeIterator_operatorDecrement_excsafe(ref ret, obj);

	if(isExc)
		handleException();
	return ret;
}


public static  System.Int32 core_FileNodeIterator_operatorPlusEqual( System.IntPtr obj ,  System.Int32 ofs )
{
	System.Int32 ret = new System.Int32();
	bool isExc = NativeMethodsExc.core_FileNodeIterator_operatorPlusEqual_excsafe(ref ret, obj, ofs);

	if(isExc)
		handleException();
	return ret;
}


public static  System.Int32 core_FileNodeIterator_operatorMinusEqual( System.IntPtr obj ,  System.Int32 ofs )
{
	System.Int32 ret = new System.Int32();
	bool isExc = NativeMethodsExc.core_FileNodeIterator_operatorMinusEqual_excsafe(ref ret, obj, ofs);

	if(isExc)
		handleException();
	return ret;
}


public static  void core_FileNode_read_int( System.IntPtr node ,  out System.Int32 value ,  System.Int32 defaultValue )
{
	bool isExc = NativeMethodsExc.core_FileNode_read_int_excsafe(node,  out value, defaultValue);

	if(isExc)
		handleException();
}


public static  void core_FileNode_read_float( System.IntPtr node ,  out System.Single value ,  System.Single defaultValue )
{
	bool isExc = NativeMethodsExc.core_FileNode_read_float_excsafe(node,  out value, defaultValue);

	if(isExc)
		handleException();
}


public static  void core_FileNode_read_double( System.IntPtr node ,  out System.Double value ,  System.Double defaultValue )
{
	bool isExc = NativeMethodsExc.core_FileNode_read_double_excsafe(node,  out value, defaultValue);

	if(isExc)
		handleException();
}


public static  void core_FileNode_read_String( System.IntPtr node , [MarshalAs(UnmanagedType.LPStr)] System.Text.StringBuilder value ,  System.Int32 valueCapacity , [MarshalAs(UnmanagedType.LPStr)] System.String defaultValue )
{
	bool isExc = NativeMethodsExc.core_FileNode_read_String_excsafe(node, value, valueCapacity, defaultValue);

	if(isExc)
		handleException();
}


public static  void core_FileNode_read_Mat( System.IntPtr node ,  System.IntPtr mat ,  System.IntPtr defaultMat )
{
	bool isExc = NativeMethodsExc.core_FileNode_read_Mat_excsafe(node, mat, defaultMat);

	if(isExc)
		handleException();
}


public static  void core_FileNode_read_SparseMat( System.IntPtr node ,  System.IntPtr mat ,  System.IntPtr defaultMat )
{
	bool isExc = NativeMethodsExc.core_FileNode_read_SparseMat_excsafe(node, mat, defaultMat);

	if(isExc)
		handleException();
}


public static  void core_FileNode_read_vectorOfKeyPoint( System.IntPtr node ,  System.IntPtr keypoints )
{
	bool isExc = NativeMethodsExc.core_FileNode_read_vectorOfKeyPoint_excsafe(node, keypoints);

	if(isExc)
		handleException();
}


public static  void core_FileNode_read_vectorOfDMatch( System.IntPtr node ,  System.IntPtr matches )
{
	bool isExc = NativeMethodsExc.core_FileNode_read_vectorOfDMatch_excsafe(node, matches);

	if(isExc)
		handleException();
}


public static  OpenCvSharp.Range core_FileNode_read_Range( System.IntPtr node )
{
	OpenCvSharp.Range ret = new OpenCvSharp.Range();
	bool isExc = NativeMethodsExc.core_FileNode_read_Range_excsafe(ref ret, node);

	if(isExc)
		handleException();
	return ret;
}


public static  OpenCvSharp.KeyPoint core_FileNode_read_KeyPoint( System.IntPtr node )
{
	OpenCvSharp.KeyPoint ret = new OpenCvSharp.KeyPoint();
	bool isExc = NativeMethodsExc.core_FileNode_read_KeyPoint_excsafe(ref ret, node);

	if(isExc)
		handleException();
	return ret;
}


public static  OpenCvSharp.DMatch core_FileNode_read_DMatch( System.IntPtr node )
{
	OpenCvSharp.DMatch ret = new OpenCvSharp.DMatch();
	bool isExc = NativeMethodsExc.core_FileNode_read_DMatch_excsafe(ref ret, node);

	if(isExc)
		handleException();
	return ret;
}


public static  OpenCvSharp.Point core_FileNode_read_Point2i( System.IntPtr node )
{
	OpenCvSharp.Point ret = new OpenCvSharp.Point();
	bool isExc = NativeMethodsExc.core_FileNode_read_Point2i_excsafe(ref ret, node);

	if(isExc)
		handleException();
	return ret;
}


public static  OpenCvSharp.Point2f core_FileNode_read_Point2f( System.IntPtr node )
{
	OpenCvSharp.Point2f ret = new OpenCvSharp.Point2f();
	bool isExc = NativeMethodsExc.core_FileNode_read_Point2f_excsafe(ref ret, node);

	if(isExc)
		handleException();
	return ret;
}


public static  OpenCvSharp.Point2d core_FileNode_read_Point2d( System.IntPtr node )
{
	OpenCvSharp.Point2d ret = new OpenCvSharp.Point2d();
	bool isExc = NativeMethodsExc.core_FileNode_read_Point2d_excsafe(ref ret, node);

	if(isExc)
		handleException();
	return ret;
}


public static  OpenCvSharp.Point3i core_FileNode_read_Point3i( System.IntPtr node )
{
	OpenCvSharp.Point3i ret = new OpenCvSharp.Point3i();
	bool isExc = NativeMethodsExc.core_FileNode_read_Point3i_excsafe(ref ret, node);

	if(isExc)
		handleException();
	return ret;
}


public static  OpenCvSharp.Point3f core_FileNode_read_Point3f( System.IntPtr node )
{
	OpenCvSharp.Point3f ret = new OpenCvSharp.Point3f();
	bool isExc = NativeMethodsExc.core_FileNode_read_Point3f_excsafe(ref ret, node);

	if(isExc)
		handleException();
	return ret;
}


public static  OpenCvSharp.Point3d core_FileNode_read_Point3d( System.IntPtr node )
{
	OpenCvSharp.Point3d ret = new OpenCvSharp.Point3d();
	bool isExc = NativeMethodsExc.core_FileNode_read_Point3d_excsafe(ref ret, node);

	if(isExc)
		handleException();
	return ret;
}


public static  OpenCvSharp.Size core_FileNode_read_Size2i( System.IntPtr node )
{
	OpenCvSharp.Size ret = new OpenCvSharp.Size();
	bool isExc = NativeMethodsExc.core_FileNode_read_Size2i_excsafe(ref ret, node);

	if(isExc)
		handleException();
	return ret;
}


public static  OpenCvSharp.Size2f core_FileNode_read_Size2f( System.IntPtr node )
{
	OpenCvSharp.Size2f ret = new OpenCvSharp.Size2f();
	bool isExc = NativeMethodsExc.core_FileNode_read_Size2f_excsafe(ref ret, node);

	if(isExc)
		handleException();
	return ret;
}


public static  OpenCvSharp.Size2d core_FileNode_read_Size2d( System.IntPtr node )
{
	OpenCvSharp.Size2d ret = new OpenCvSharp.Size2d();
	bool isExc = NativeMethodsExc.core_FileNode_read_Size2d_excsafe(ref ret, node);

	if(isExc)
		handleException();
	return ret;
}


public static  OpenCvSharp.Rect core_FileNode_read_Rect2i( System.IntPtr node )
{
	OpenCvSharp.Rect ret = new OpenCvSharp.Rect();
	bool isExc = NativeMethodsExc.core_FileNode_read_Rect2i_excsafe(ref ret, node);

	if(isExc)
		handleException();
	return ret;
}


public static  OpenCvSharp.Rect2f core_FileNode_read_Rect2f( System.IntPtr node )
{
	OpenCvSharp.Rect2f ret = new OpenCvSharp.Rect2f();
	bool isExc = NativeMethodsExc.core_FileNode_read_Rect2f_excsafe(ref ret, node);

	if(isExc)
		handleException();
	return ret;
}


public static  OpenCvSharp.Rect2d core_FileNode_read_Rect2d( System.IntPtr node )
{
	OpenCvSharp.Rect2d ret = new OpenCvSharp.Rect2d();
	bool isExc = NativeMethodsExc.core_FileNode_read_Rect2d_excsafe(ref ret, node);

	if(isExc)
		handleException();
	return ret;
}


public static  OpenCvSharp.Scalar core_FileNode_read_Scalar( System.IntPtr node )
{
	OpenCvSharp.Scalar ret = new OpenCvSharp.Scalar();
	bool isExc = NativeMethodsExc.core_FileNode_read_Scalar_excsafe(ref ret, node);

	if(isExc)
		handleException();
	return ret;
}


public static  OpenCvSharp.Vec2i core_FileNode_read_Vec2i( System.IntPtr node )
{
	OpenCvSharp.Vec2i ret = new OpenCvSharp.Vec2i();
	bool isExc = NativeMethodsExc.core_FileNode_read_Vec2i_excsafe(ref ret, node);

	if(isExc)
		handleException();
	return ret;
}


public static  OpenCvSharp.Vec3i core_FileNode_read_Vec3i( System.IntPtr node )
{
	OpenCvSharp.Vec3i ret = new OpenCvSharp.Vec3i();
	bool isExc = NativeMethodsExc.core_FileNode_read_Vec3i_excsafe(ref ret, node);

	if(isExc)
		handleException();
	return ret;
}


public static  OpenCvSharp.Vec4i core_FileNode_read_Vec4i( System.IntPtr node )
{
	OpenCvSharp.Vec4i ret = new OpenCvSharp.Vec4i();
	bool isExc = NativeMethodsExc.core_FileNode_read_Vec4i_excsafe(ref ret, node);

	if(isExc)
		handleException();
	return ret;
}


public static  OpenCvSharp.Vec6i core_FileNode_read_Vec6i( System.IntPtr node )
{
	OpenCvSharp.Vec6i ret = new OpenCvSharp.Vec6i();
	bool isExc = NativeMethodsExc.core_FileNode_read_Vec6i_excsafe(ref ret, node);

	if(isExc)
		handleException();
	return ret;
}


public static  System.IntPtr core_LDA_subspaceProject( System.IntPtr w ,  System.IntPtr mean ,  System.IntPtr src )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.core_LDA_subspaceProject_excsafe(ref ret, w, mean, src);

	if(isExc)
		handleException();
	return ret;
}


public static  System.IntPtr core_LDA_subspaceReconstruct( System.IntPtr w ,  System.IntPtr mean ,  System.IntPtr src )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.core_LDA_subspaceReconstruct_excsafe(ref ret, w, mean, src);

	if(isExc)
		handleException();
	return ret;
}


public static  System.IntPtr core_FileNode_new1()
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.core_FileNode_new1_excsafe(ref ret);

	if(isExc)
		handleException();
	return ret;
}


public static  System.IntPtr core_FileNode_new2( System.IntPtr fs ,  System.IntPtr node )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.core_FileNode_new2_excsafe(ref ret, fs, node);

	if(isExc)
		handleException();
	return ret;
}


public static  System.IntPtr core_FileNode_new3( System.IntPtr node )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.core_FileNode_new3_excsafe(ref ret, node);

	if(isExc)
		handleException();
	return ret;
}


public static  void core_FileNode_delete( System.IntPtr node )
{
	bool isExc = NativeMethodsExc.core_FileNode_delete_excsafe(node);

	if(isExc)
		handleException();
}


public static  System.IntPtr core_FileNode_operatorThis_byString( System.IntPtr obj , [MarshalAs(UnmanagedType.LPStr)] System.String nodeName )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.core_FileNode_operatorThis_byString_excsafe(ref ret, obj, nodeName);

	if(isExc)
		handleException();
	return ret;
}


public static  System.IntPtr core_FileNode_operatorThis_byInt( System.IntPtr obj ,  System.Int32 i )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.core_FileNode_operatorThis_byInt_excsafe(ref ret, obj, i);

	if(isExc)
		handleException();
	return ret;
}


public static  System.Int32 core_FileNode_type( System.IntPtr obj )
{
	System.Int32 ret = new System.Int32();
	bool isExc = NativeMethodsExc.core_FileNode_type_excsafe(ref ret, obj);

	if(isExc)
		handleException();
	return ret;
}


public static  System.Int32 core_FileNode_empty( System.IntPtr obj )
{
	System.Int32 ret = new System.Int32();
	bool isExc = NativeMethodsExc.core_FileNode_empty_excsafe(ref ret, obj);

	if(isExc)
		handleException();
	return ret;
}


public static  System.Int32 core_FileNode_isNone( System.IntPtr obj )
{
	System.Int32 ret = new System.Int32();
	bool isExc = NativeMethodsExc.core_FileNode_isNone_excsafe(ref ret, obj);

	if(isExc)
		handleException();
	return ret;
}


public static  System.Int32 core_FileNode_isSeq( System.IntPtr obj )
{
	System.Int32 ret = new System.Int32();
	bool isExc = NativeMethodsExc.core_FileNode_isSeq_excsafe(ref ret, obj);

	if(isExc)
		handleException();
	return ret;
}


public static  System.Int32 core_FileNode_isMap( System.IntPtr obj )
{
	System.Int32 ret = new System.Int32();
	bool isExc = NativeMethodsExc.core_FileNode_isMap_excsafe(ref ret, obj);

	if(isExc)
		handleException();
	return ret;
}


public static  System.Int32 core_FileNode_isInt( System.IntPtr obj )
{
	System.Int32 ret = new System.Int32();
	bool isExc = NativeMethodsExc.core_FileNode_isInt_excsafe(ref ret, obj);

	if(isExc)
		handleException();
	return ret;
}


public static  System.Int32 core_FileNode_isReal( System.IntPtr obj )
{
	System.Int32 ret = new System.Int32();
	bool isExc = NativeMethodsExc.core_FileNode_isReal_excsafe(ref ret, obj);

	if(isExc)
		handleException();
	return ret;
}


public static  System.Int32 core_FileNode_isString( System.IntPtr obj )
{
	System.Int32 ret = new System.Int32();
	bool isExc = NativeMethodsExc.core_FileNode_isString_excsafe(ref ret, obj);

	if(isExc)
		handleException();
	return ret;
}


public static  System.Int32 core_FileNode_isNamed( System.IntPtr obj )
{
	System.Int32 ret = new System.Int32();
	bool isExc = NativeMethodsExc.core_FileNode_isNamed_excsafe(ref ret, obj);

	if(isExc)
		handleException();
	return ret;
}


public static  void core_FileNode_name( System.IntPtr obj , [MarshalAs(UnmanagedType.LPStr)] System.Text.StringBuilder buf ,  System.Int32 bufLength )
{
	bool isExc = NativeMethodsExc.core_FileNode_name_excsafe(obj, buf, bufLength);

	if(isExc)
		handleException();
}


public static  System.IntPtr core_FileNode_size( System.IntPtr obj )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.core_FileNode_size_excsafe(ref ret, obj);

	if(isExc)
		handleException();
	return ret;
}


public static  System.Int32 core_FileNode_toInt( System.IntPtr obj )
{
	System.Int32 ret = new System.Int32();
	bool isExc = NativeMethodsExc.core_FileNode_toInt_excsafe(ref ret, obj);

	if(isExc)
		handleException();
	return ret;
}


public static  System.Single core_FileNode_toFloat( System.IntPtr obj )
{
	System.Single ret = new System.Single();
	bool isExc = NativeMethodsExc.core_FileNode_toFloat_excsafe(ref ret, obj);

	if(isExc)
		handleException();
	return ret;
}


public static  System.Double core_FileNode_toDouble( System.IntPtr obj )
{
	System.Double ret = new System.Double();
	bool isExc = NativeMethodsExc.core_FileNode_toDouble_excsafe(ref ret, obj);

	if(isExc)
		handleException();
	return ret;
}


public static  void core_FileNode_toString( System.IntPtr obj ,  System.Text.StringBuilder buf ,  System.Int32 bufLength )
{
	bool isExc = NativeMethodsExc.core_FileNode_toString_excsafe(obj, buf, bufLength);

	if(isExc)
		handleException();
}


public static  void core_FileNode_toMat( System.IntPtr obj ,  System.IntPtr m )
{
	bool isExc = NativeMethodsExc.core_FileNode_toMat_excsafe(obj, m);

	if(isExc)
		handleException();
}


public static  System.IntPtr core_FileNode_begin( System.IntPtr obj )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.core_FileNode_begin_excsafe(ref ret, obj);

	if(isExc)
		handleException();
	return ret;
}


public static  System.IntPtr core_FileNode_end( System.IntPtr obj )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.core_FileNode_end_excsafe(ref ret, obj);

	if(isExc)
		handleException();
	return ret;
}


public static  void core_FileNode_readRaw( System.IntPtr obj , [MarshalAs(UnmanagedType.LPStr)] System.String fmt ,  System.IntPtr vec ,  System.IntPtr len )
{
	bool isExc = NativeMethodsExc.core_FileNode_readRaw_excsafe(obj, fmt, vec, len);

	if(isExc)
		handleException();
}


public static  System.IntPtr core_FileNode_readObj( System.IntPtr obj )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.core_FileNode_readObj_excsafe(ref ret, obj);

	if(isExc)
		handleException();
	return ret;
}


public static  System.IntPtr core_PCA_eigenvalues( System.IntPtr obj )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.core_PCA_eigenvalues_excsafe(ref ret, obj);

	if(isExc)
		handleException();
	return ret;
}


public static  System.IntPtr core_PCA_mean( System.IntPtr obj )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.core_PCA_mean_excsafe(ref ret, obj);

	if(isExc)
		handleException();
	return ret;
}


public static  void core_RNG_fill( ref System.UInt64 state ,  System.IntPtr mat ,  System.Int32 distType ,  System.IntPtr a ,  System.IntPtr b ,  System.Int32 saturateRange )
{
	bool isExc = NativeMethodsExc.core_RNG_fill_excsafe( ref state, mat, distType, a, b, saturateRange);

	if(isExc)
		handleException();
}


public static  System.Double core_RNG_gaussian( ref System.UInt64 state ,  System.Double sigma )
{
	System.Double ret = new System.Double();
	bool isExc = NativeMethodsExc.core_RNG_gaussian_excsafe(ref ret,  ref state, sigma);

	if(isExc)
		handleException();
	return ret;
}


public static  System.IntPtr core_SVD_new1()
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.core_SVD_new1_excsafe(ref ret);

	if(isExc)
		handleException();
	return ret;
}


public static  System.IntPtr core_SVD_new2( System.IntPtr src ,  System.Int32 flags )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.core_SVD_new2_excsafe(ref ret, src, flags);

	if(isExc)
		handleException();
	return ret;
}


public static  void core_SVD_delete( System.IntPtr obj )
{
	bool isExc = NativeMethodsExc.core_SVD_delete_excsafe(obj);

	if(isExc)
		handleException();
}


public static  void core_SVD_operatorThis( System.IntPtr obj ,  System.IntPtr src ,  System.Int32 flags )
{
	bool isExc = NativeMethodsExc.core_SVD_operatorThis_excsafe(obj, src, flags);

	if(isExc)
		handleException();
}


public static  void core_SVD_backSubst( System.IntPtr obj ,  System.IntPtr rhs ,  System.IntPtr dst )
{
	bool isExc = NativeMethodsExc.core_SVD_backSubst_excsafe(obj, rhs, dst);

	if(isExc)
		handleException();
}


public static  void core_SVD_static_compute1( System.IntPtr src ,  System.IntPtr w ,  System.IntPtr u ,  System.IntPtr vt ,  System.Int32 flags )
{
	bool isExc = NativeMethodsExc.core_SVD_static_compute1_excsafe(src, w, u, vt, flags);

	if(isExc)
		handleException();
}


public static  void core_SVD_static_compute2( System.IntPtr src ,  System.IntPtr w ,  System.Int32 flags )
{
	bool isExc = NativeMethodsExc.core_SVD_static_compute2_excsafe(src, w, flags);

	if(isExc)
		handleException();
}


public static  void core_SVD_static_backSubst( System.IntPtr w ,  System.IntPtr u ,  System.IntPtr vt ,  System.IntPtr rhs ,  System.IntPtr dst )
{
	bool isExc = NativeMethodsExc.core_SVD_static_backSubst_excsafe(w, u, vt, rhs, dst);

	if(isExc)
		handleException();
}


public static  void core_SVD_static_solveZ( System.IntPtr src ,  System.IntPtr dst )
{
	bool isExc = NativeMethodsExc.core_SVD_static_solveZ_excsafe(src, dst);

	if(isExc)
		handleException();
}


public static  System.IntPtr core_SVD_u( System.IntPtr obj )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.core_SVD_u_excsafe(ref ret, obj);

	if(isExc)
		handleException();
	return ret;
}


public static  System.IntPtr core_SVD_w( System.IntPtr obj )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.core_SVD_w_excsafe(ref ret, obj);

	if(isExc)
		handleException();
	return ret;
}


public static  System.IntPtr core_SVD_vt( System.IntPtr obj )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.core_SVD_vt_excsafe(ref ret, obj);

	if(isExc)
		handleException();
	return ret;
}


public static  System.IntPtr core_LDA_new1( System.Int32 numComponents )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.core_LDA_new1_excsafe(ref ret, numComponents);

	if(isExc)
		handleException();
	return ret;
}


public static  System.IntPtr core_LDA_new2( System.IntPtr src ,  System.IntPtr labels ,  System.Int32 numComponents )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.core_LDA_new2_excsafe(ref ret, src, labels, numComponents);

	if(isExc)
		handleException();
	return ret;
}


public static  void core_LDA_delete( System.IntPtr obj )
{
	bool isExc = NativeMethodsExc.core_LDA_delete_excsafe(obj);

	if(isExc)
		handleException();
}


public static  void core_LDA_save_String( System.IntPtr obj , [MarshalAs(UnmanagedType.LPStr)] System.String filename )
{
	bool isExc = NativeMethodsExc.core_LDA_save_String_excsafe(obj, filename);

	if(isExc)
		handleException();
}


public static  void core_LDA_load_String( System.IntPtr obj , [MarshalAs(UnmanagedType.LPStr)] System.String filename )
{
	bool isExc = NativeMethodsExc.core_LDA_load_String_excsafe(obj, filename);

	if(isExc)
		handleException();
}


public static  void core_LDA_save_FileStorage( System.IntPtr obj ,  System.IntPtr fs )
{
	bool isExc = NativeMethodsExc.core_LDA_save_FileStorage_excsafe(obj, fs);

	if(isExc)
		handleException();
}


public static  void core_LDA_load_FileStorage( System.IntPtr obj ,  System.IntPtr node )
{
	bool isExc = NativeMethodsExc.core_LDA_load_FileStorage_excsafe(obj, node);

	if(isExc)
		handleException();
}


public static  void core_LDA_compute( System.IntPtr obj ,  System.IntPtr src ,  System.IntPtr labels )
{
	bool isExc = NativeMethodsExc.core_LDA_compute_excsafe(obj, src, labels);

	if(isExc)
		handleException();
}


public static  System.IntPtr core_LDA_project( System.IntPtr obj ,  System.IntPtr src )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.core_LDA_project_excsafe(ref ret, obj, src);

	if(isExc)
		handleException();
	return ret;
}


public static  System.IntPtr core_LDA_reconstruct( System.IntPtr obj ,  System.IntPtr src )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.core_LDA_reconstruct_excsafe(ref ret, obj, src);

	if(isExc)
		handleException();
	return ret;
}


public static  System.IntPtr core_LDA_eigenvectors( System.IntPtr obj )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.core_LDA_eigenvectors_excsafe(ref ret, obj);

	if(isExc)
		handleException();
	return ret;
}


public static  System.IntPtr core_LDA_eigenvalues( System.IntPtr obj )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.core_LDA_eigenvalues_excsafe(ref ret, obj);

	if(isExc)
		handleException();
	return ret;
}


public static  void core_dct( System.IntPtr src ,  System.IntPtr dst ,  System.Int32 flags )
{
	bool isExc = NativeMethodsExc.core_dct_excsafe(src, dst, flags);

	if(isExc)
		handleException();
}


public static  void core_idct( System.IntPtr src ,  System.IntPtr dst ,  System.Int32 flags )
{
	bool isExc = NativeMethodsExc.core_idct_excsafe(src, dst, flags);

	if(isExc)
		handleException();
}


public static  void core_mulSpectrums( System.IntPtr a ,  System.IntPtr b ,  System.IntPtr c ,  System.Int32 flags ,  System.Int32 conjB )
{
	bool isExc = NativeMethodsExc.core_mulSpectrums_excsafe(a, b, c, flags, conjB);

	if(isExc)
		handleException();
}


public static  System.Int32 core_getOptimalDFTSize( System.Int32 vecsize )
{
	System.Int32 ret = new System.Int32();
	bool isExc = NativeMethodsExc.core_getOptimalDFTSize_excsafe(ref ret, vecsize);

	if(isExc)
		handleException();
	return ret;
}


public static  System.Double core_kmeans( System.IntPtr data ,  System.Int32 k ,  System.IntPtr bestLabels ,  OpenCvSharp.TermCriteria criteria ,  System.Int32 attempts ,  System.Int32 flags ,  System.IntPtr centers )
{
	System.Double ret = new System.Double();
	bool isExc = NativeMethodsExc.core_kmeans_excsafe(ref ret, data, k, bestLabels, criteria, attempts, flags, centers);

	if(isExc)
		handleException();
	return ret;
}


public static  System.UInt64 core_theRNG()
{
	System.UInt64 ret = new System.UInt64();
	bool isExc = NativeMethodsExc.core_theRNG_excsafe(ref ret);

	if(isExc)
		handleException();
	return ret;
}


public static  void core_randu_InputArray( System.IntPtr dst ,  System.IntPtr low ,  System.IntPtr high )
{
	bool isExc = NativeMethodsExc.core_randu_InputArray_excsafe(dst, low, high);

	if(isExc)
		handleException();
}


public static  void core_randu_Scalar( System.IntPtr dst ,  OpenCvSharp.Scalar low ,  OpenCvSharp.Scalar high )
{
	bool isExc = NativeMethodsExc.core_randu_Scalar_excsafe(dst, low, high);

	if(isExc)
		handleException();
}


public static  void core_randn_InputArray( System.IntPtr dst ,  System.IntPtr mean ,  System.IntPtr stddev )
{
	bool isExc = NativeMethodsExc.core_randn_InputArray_excsafe(dst, mean, stddev);

	if(isExc)
		handleException();
}


public static  void core_randn_Scalar( System.IntPtr dst ,  OpenCvSharp.Scalar mean ,  OpenCvSharp.Scalar stddev )
{
	bool isExc = NativeMethodsExc.core_randn_Scalar_excsafe(dst, mean, stddev);

	if(isExc)
		handleException();
}


public static  void core_randShuffle( System.IntPtr dst ,  System.Double iterFactor ,  ref System.UInt64 rng )
{
	bool isExc = NativeMethodsExc.core_randShuffle_excsafe(dst, iterFactor,  ref rng);

	if(isExc)
		handleException();
}


public static  void core_randShuffle( System.IntPtr dst ,  System.Double iterFactor ,  System.IntPtr rng )
{
	bool isExc = NativeMethodsExc.core_randShuffle_excsafe(dst, iterFactor, rng);

	if(isExc)
		handleException();
}


public static  void core_Algorithm_write( System.IntPtr obj ,  System.IntPtr fs )
{
	bool isExc = NativeMethodsExc.core_Algorithm_write_excsafe(obj, fs);

	if(isExc)
		handleException();
}


public static  void core_Algorithm_read( System.IntPtr obj ,  System.IntPtr fn )
{
	bool isExc = NativeMethodsExc.core_Algorithm_read_excsafe(obj, fn);

	if(isExc)
		handleException();
}


public static  System.Int32 core_Algorithm_empty( System.IntPtr obj )
{
	System.Int32 ret = new System.Int32();
	bool isExc = NativeMethodsExc.core_Algorithm_empty_excsafe(ref ret, obj);

	if(isExc)
		handleException();
	return ret;
}


public static  void core_Algorithm_save( System.IntPtr obj ,  System.String filename )
{
	bool isExc = NativeMethodsExc.core_Algorithm_save_excsafe(obj, filename);

	if(isExc)
		handleException();
}


public static  void core_Algorithm_getDefaultName( System.IntPtr obj , [MarshalAs(UnmanagedType.LPStr)] System.Text.StringBuilder buf ,  System.Int32 bufLength )
{
	bool isExc = NativeMethodsExc.core_Algorithm_getDefaultName_excsafe(obj, buf, bufLength);

	if(isExc)
		handleException();
}


public static  System.IntPtr core_PCA_new1()
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.core_PCA_new1_excsafe(ref ret);

	if(isExc)
		handleException();
	return ret;
}


public static  System.IntPtr core_PCA_new2( System.IntPtr data ,  System.IntPtr mean ,  System.Int32 flags ,  System.Int32 maxComponents )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.core_PCA_new2_excsafe(ref ret, data, mean, flags, maxComponents);

	if(isExc)
		handleException();
	return ret;
}


public static  System.IntPtr core_PCA_new3( System.IntPtr data ,  System.IntPtr mean ,  System.Int32 flags ,  System.Double retainedVariance )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.core_PCA_new3_excsafe(ref ret, data, mean, flags, retainedVariance);

	if(isExc)
		handleException();
	return ret;
}


public static  void core_PCA_delete( System.IntPtr obj )
{
	bool isExc = NativeMethodsExc.core_PCA_delete_excsafe(obj);

	if(isExc)
		handleException();
}


public static  void core_PCA_operatorThis( System.IntPtr obj ,  System.IntPtr data ,  System.IntPtr mean ,  System.Int32 flags ,  System.Int32 maxComponents )
{
	bool isExc = NativeMethodsExc.core_PCA_operatorThis_excsafe(obj, data, mean, flags, maxComponents);

	if(isExc)
		handleException();
}


public static  void core_PCA_computeVar( System.IntPtr obj ,  System.IntPtr data ,  System.IntPtr mean ,  System.Int32 flags ,  System.Double retainedVariance )
{
	bool isExc = NativeMethodsExc.core_PCA_computeVar_excsafe(obj, data, mean, flags, retainedVariance);

	if(isExc)
		handleException();
}


public static  System.IntPtr core_PCA_project1( System.IntPtr obj ,  System.IntPtr vec )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.core_PCA_project1_excsafe(ref ret, obj, vec);

	if(isExc)
		handleException();
	return ret;
}


public static  void core_PCA_project2( System.IntPtr obj ,  System.IntPtr vec ,  System.IntPtr result )
{
	bool isExc = NativeMethodsExc.core_PCA_project2_excsafe(obj, vec, result);

	if(isExc)
		handleException();
}


public static  System.IntPtr core_PCA_backProject1( System.IntPtr obj ,  System.IntPtr vec )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.core_PCA_backProject1_excsafe(ref ret, obj, vec);

	if(isExc)
		handleException();
	return ret;
}


public static  void core_PCA_backProject2( System.IntPtr obj ,  System.IntPtr vec ,  System.IntPtr result )
{
	bool isExc = NativeMethodsExc.core_PCA_backProject2_excsafe(obj, vec, result);

	if(isExc)
		handleException();
}


public static  System.IntPtr core_PCA_eigenvectors( System.IntPtr obj )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.core_PCA_eigenvectors_excsafe(ref ret, obj);

	if(isExc)
		handleException();
	return ret;
}


public static  void core_perspectiveTransform_Mat( System.IntPtr src ,  System.IntPtr dst ,  System.IntPtr m )
{
	bool isExc = NativeMethodsExc.core_perspectiveTransform_Mat_excsafe(src, dst, m);

	if(isExc)
		handleException();
}


public static  void core_perspectiveTransform_Point2f( System.IntPtr src ,  System.Int32 srcLength ,  System.IntPtr dst ,  System.Int32 dstLength ,  System.IntPtr m )
{
	bool isExc = NativeMethodsExc.core_perspectiveTransform_Point2f_excsafe(src, srcLength, dst, dstLength, m);

	if(isExc)
		handleException();
}


public static  void core_perspectiveTransform_Point2d( System.IntPtr src ,  System.Int32 srcLength ,  System.IntPtr dst ,  System.Int32 dstLength ,  System.IntPtr m )
{
	bool isExc = NativeMethodsExc.core_perspectiveTransform_Point2d_excsafe(src, srcLength, dst, dstLength, m);

	if(isExc)
		handleException();
}


public static  void core_perspectiveTransform_Point3f( System.IntPtr src ,  System.Int32 srcLength ,  System.IntPtr dst ,  System.Int32 dstLength ,  System.IntPtr m )
{
	bool isExc = NativeMethodsExc.core_perspectiveTransform_Point3f_excsafe(src, srcLength, dst, dstLength, m);

	if(isExc)
		handleException();
}


public static  void core_perspectiveTransform_Point3d( System.IntPtr src ,  System.Int32 srcLength ,  System.IntPtr dst ,  System.Int32 dstLength ,  System.IntPtr m )
{
	bool isExc = NativeMethodsExc.core_perspectiveTransform_Point3d_excsafe(src, srcLength, dst, dstLength, m);

	if(isExc)
		handleException();
}


public static  void core_completeSymm( System.IntPtr mtx ,  System.Int32 lowerToUpper )
{
	bool isExc = NativeMethodsExc.core_completeSymm_excsafe(mtx, lowerToUpper);

	if(isExc)
		handleException();
}


public static  void core_setIdentity( System.IntPtr mtx ,  OpenCvSharp.Scalar s )
{
	bool isExc = NativeMethodsExc.core_setIdentity_excsafe(mtx, s);

	if(isExc)
		handleException();
}


public static  System.Double core_determinant( System.IntPtr mtx )
{
	System.Double ret = new System.Double();
	bool isExc = NativeMethodsExc.core_determinant_excsafe(ref ret, mtx);

	if(isExc)
		handleException();
	return ret;
}


public static  OpenCvSharp.Scalar core_trace( System.IntPtr mtx )
{
	OpenCvSharp.Scalar ret = new OpenCvSharp.Scalar();
	bool isExc = NativeMethodsExc.core_trace_excsafe(ref ret, mtx);

	if(isExc)
		handleException();
	return ret;
}


public static  System.Double core_invert( System.IntPtr src ,  System.IntPtr dst ,  System.Int32 flags )
{
	System.Double ret = new System.Double();
	bool isExc = NativeMethodsExc.core_invert_excsafe(ref ret, src, dst, flags);

	if(isExc)
		handleException();
	return ret;
}


public static  System.Int32 core_solve( System.IntPtr src1 ,  System.IntPtr src2 ,  System.IntPtr dst ,  System.Int32 flags )
{
	System.Int32 ret = new System.Int32();
	bool isExc = NativeMethodsExc.core_solve_excsafe(ref ret, src1, src2, dst, flags);

	if(isExc)
		handleException();
	return ret;
}


public static  System.Int32 core_solveLP( System.IntPtr func ,  System.IntPtr constr ,  System.IntPtr z )
{
	System.Int32 ret = new System.Int32();
	bool isExc = NativeMethodsExc.core_solveLP_excsafe(ref ret, func, constr, z);

	if(isExc)
		handleException();
	return ret;
}


public static  void core_sort( System.IntPtr src ,  System.IntPtr dst ,  System.Int32 flags )
{
	bool isExc = NativeMethodsExc.core_sort_excsafe(src, dst, flags);

	if(isExc)
		handleException();
}


public static  void core_sortIdx( System.IntPtr src ,  System.IntPtr dst ,  System.Int32 flags )
{
	bool isExc = NativeMethodsExc.core_sortIdx_excsafe(src, dst, flags);

	if(isExc)
		handleException();
}


public static  System.Int32 core_solveCubic( System.IntPtr coeffs ,  System.IntPtr roots )
{
	System.Int32 ret = new System.Int32();
	bool isExc = NativeMethodsExc.core_solveCubic_excsafe(ref ret, coeffs, roots);

	if(isExc)
		handleException();
	return ret;
}


public static  System.Double core_solvePoly( System.IntPtr coeffs ,  System.IntPtr roots ,  System.Int32 maxIters )
{
	System.Double ret = new System.Double();
	bool isExc = NativeMethodsExc.core_solvePoly_excsafe(ref ret, coeffs, roots, maxIters);

	if(isExc)
		handleException();
	return ret;
}


public static  System.Int32 core_eigen( System.IntPtr src ,  System.IntPtr eigenvalues ,  System.IntPtr eigenvectors )
{
	System.Int32 ret = new System.Int32();
	bool isExc = NativeMethodsExc.core_eigen_excsafe(ref ret, src, eigenvalues, eigenvectors);

	if(isExc)
		handleException();
	return ret;
}


public static  void core_calcCovarMatrix_Mat([MarshalAs(UnmanagedType.LPArray)] System.IntPtr[] samples ,  System.Int32 nsamples ,  System.IntPtr covar ,  System.IntPtr mean ,  System.Int32 flags ,  System.Int32 ctype )
{
	bool isExc = NativeMethodsExc.core_calcCovarMatrix_Mat_excsafe(samples, nsamples, covar, mean, flags, ctype);

	if(isExc)
		handleException();
}


public static  void core_calcCovarMatrix_InputArray( System.IntPtr samples ,  System.IntPtr covar ,  System.IntPtr mean ,  System.Int32 flags ,  System.Int32 ctype )
{
	bool isExc = NativeMethodsExc.core_calcCovarMatrix_InputArray_excsafe(samples, covar, mean, flags, ctype);

	if(isExc)
		handleException();
}


public static  void core_PCACompute( System.IntPtr data ,  System.IntPtr mean ,  System.IntPtr eigenvectors ,  System.Int32 maxComponents )
{
	bool isExc = NativeMethodsExc.core_PCACompute_excsafe(data, mean, eigenvectors, maxComponents);

	if(isExc)
		handleException();
}


public static  void core_PCAComputeVar( System.IntPtr data ,  System.IntPtr mean ,  System.IntPtr eigenvectors ,  System.Double retainedVariance )
{
	bool isExc = NativeMethodsExc.core_PCAComputeVar_excsafe(data, mean, eigenvectors, retainedVariance);

	if(isExc)
		handleException();
}


public static  void core_PCAProject( System.IntPtr data ,  System.IntPtr mean ,  System.IntPtr eigenvectors ,  System.IntPtr result )
{
	bool isExc = NativeMethodsExc.core_PCAProject_excsafe(data, mean, eigenvectors, result);

	if(isExc)
		handleException();
}


public static  void core_PCABackProject( System.IntPtr data ,  System.IntPtr mean ,  System.IntPtr eigenvectors ,  System.IntPtr result )
{
	bool isExc = NativeMethodsExc.core_PCABackProject_excsafe(data, mean, eigenvectors, result);

	if(isExc)
		handleException();
}


public static  void core_SVDecomp( System.IntPtr src ,  System.IntPtr w ,  System.IntPtr u ,  System.IntPtr vt ,  System.Int32 flags )
{
	bool isExc = NativeMethodsExc.core_SVDecomp_excsafe(src, w, u, vt, flags);

	if(isExc)
		handleException();
}


public static  void core_SVBackSubst( System.IntPtr w ,  System.IntPtr u ,  System.IntPtr vt ,  System.IntPtr rhs ,  System.IntPtr dst )
{
	bool isExc = NativeMethodsExc.core_SVBackSubst_excsafe(w, u, vt, rhs, dst);

	if(isExc)
		handleException();
}


public static  System.Double core_Mahalanobis( System.IntPtr v1 ,  System.IntPtr v2 ,  System.IntPtr icovar )
{
	System.Double ret = new System.Double();
	bool isExc = NativeMethodsExc.core_Mahalanobis_excsafe(ref ret, v1, v2, icovar);

	if(isExc)
		handleException();
	return ret;
}


public static  void core_dft( System.IntPtr src ,  System.IntPtr dst ,  System.Int32 flags ,  System.Int32 nonzeroRows )
{
	bool isExc = NativeMethodsExc.core_dft_excsafe(src, dst, flags, nonzeroRows);

	if(isExc)
		handleException();
}


public static  void core_idft( System.IntPtr src ,  System.IntPtr dst ,  System.Int32 flags ,  System.Int32 nonzeroRows )
{
	bool isExc = NativeMethodsExc.core_idft_excsafe(src, dst, flags, nonzeroRows);

	if(isExc)
		handleException();
}


public static  void core_bitwise_not( System.IntPtr src ,  System.IntPtr dst ,  System.IntPtr mask )
{
	bool isExc = NativeMethodsExc.core_bitwise_not_excsafe(src, dst, mask);

	if(isExc)
		handleException();
}


public static  void core_absdiff( System.IntPtr src1 ,  System.IntPtr src2 ,  System.IntPtr dst )
{
	bool isExc = NativeMethodsExc.core_absdiff_excsafe(src1, src2, dst);

	if(isExc)
		handleException();
}


public static  void core_inRange_InputArray( System.IntPtr src ,  System.IntPtr lowerb ,  System.IntPtr upperb ,  System.IntPtr dst )
{
	bool isExc = NativeMethodsExc.core_inRange_InputArray_excsafe(src, lowerb, upperb, dst);

	if(isExc)
		handleException();
}


public static  void core_inRange_Scalar( System.IntPtr src ,  OpenCvSharp.Scalar lowerb ,  OpenCvSharp.Scalar upperb ,  System.IntPtr dst )
{
	bool isExc = NativeMethodsExc.core_inRange_Scalar_excsafe(src, lowerb, upperb, dst);

	if(isExc)
		handleException();
}


public static  void core_compare( System.IntPtr src1 ,  System.IntPtr src2 ,  System.IntPtr dst ,  System.Int32 cmpop )
{
	bool isExc = NativeMethodsExc.core_compare_excsafe(src1, src2, dst, cmpop);

	if(isExc)
		handleException();
}


public static  void core_min1( System.IntPtr src1 ,  System.IntPtr src2 ,  System.IntPtr dst )
{
	bool isExc = NativeMethodsExc.core_min1_excsafe(src1, src2, dst);

	if(isExc)
		handleException();
}


public static  void core_max1( System.IntPtr src1 ,  System.IntPtr src2 ,  System.IntPtr dst )
{
	bool isExc = NativeMethodsExc.core_max1_excsafe(src1, src2, dst);

	if(isExc)
		handleException();
}


public static  void core_min_MatMat( System.IntPtr src1 ,  System.IntPtr src2 ,  System.IntPtr dst )
{
	bool isExc = NativeMethodsExc.core_min_MatMat_excsafe(src1, src2, dst);

	if(isExc)
		handleException();
}


public static  void core_min_MatDouble( System.IntPtr src1 ,  System.Double src2 ,  System.IntPtr dst )
{
	bool isExc = NativeMethodsExc.core_min_MatDouble_excsafe(src1, src2, dst);

	if(isExc)
		handleException();
}


public static  void core_max_MatMat( System.IntPtr src1 ,  System.IntPtr src2 ,  System.IntPtr dst )
{
	bool isExc = NativeMethodsExc.core_max_MatMat_excsafe(src1, src2, dst);

	if(isExc)
		handleException();
}


public static  void core_max_MatDouble( System.IntPtr src1 ,  System.Double src2 ,  System.IntPtr dst )
{
	bool isExc = NativeMethodsExc.core_max_MatDouble_excsafe(src1, src2, dst);

	if(isExc)
		handleException();
}


public static  void core_sqrt( System.IntPtr src ,  System.IntPtr dst )
{
	bool isExc = NativeMethodsExc.core_sqrt_excsafe(src, dst);

	if(isExc)
		handleException();
}


public static  void core_pow_Mat( System.IntPtr src ,  System.Double power ,  System.IntPtr dst )
{
	bool isExc = NativeMethodsExc.core_pow_Mat_excsafe(src, power, dst);

	if(isExc)
		handleException();
}


public static  void core_exp_Mat( System.IntPtr src ,  System.IntPtr dst )
{
	bool isExc = NativeMethodsExc.core_exp_Mat_excsafe(src, dst);

	if(isExc)
		handleException();
}


public static  void core_log_Mat( System.IntPtr src ,  System.IntPtr dst )
{
	bool isExc = NativeMethodsExc.core_log_Mat_excsafe(src, dst);

	if(isExc)
		handleException();
}


public static  System.Single core_cubeRoot( System.Single val )
{
	System.Single ret = new System.Single();
	bool isExc = NativeMethodsExc.core_cubeRoot_excsafe(ref ret, val);

	if(isExc)
		handleException();
	return ret;
}


public static  System.Single core_fastAtan2( System.Single y ,  System.Single x )
{
	System.Single ret = new System.Single();
	bool isExc = NativeMethodsExc.core_fastAtan2_excsafe(ref ret, y, x);

	if(isExc)
		handleException();
	return ret;
}


public static  void core_polarToCart( System.IntPtr magnitude ,  System.IntPtr angle ,  System.IntPtr x ,  System.IntPtr y ,  System.Int32 angleInDegrees )
{
	bool isExc = NativeMethodsExc.core_polarToCart_excsafe(magnitude, angle, x, y, angleInDegrees);

	if(isExc)
		handleException();
}


public static  void core_cartToPolar( System.IntPtr x ,  System.IntPtr y ,  System.IntPtr magnitude ,  System.IntPtr angle ,  System.Int32 angleInDegrees )
{
	bool isExc = NativeMethodsExc.core_cartToPolar_excsafe(x, y, magnitude, angle, angleInDegrees);

	if(isExc)
		handleException();
}


public static  void core_phase( System.IntPtr x ,  System.IntPtr y ,  System.IntPtr angle ,  System.Int32 angleInDegrees )
{
	bool isExc = NativeMethodsExc.core_phase_excsafe(x, y, angle, angleInDegrees);

	if(isExc)
		handleException();
}


public static  void core_magnitude_Mat( System.IntPtr x ,  System.IntPtr y ,  System.IntPtr magnitude )
{
	bool isExc = NativeMethodsExc.core_magnitude_Mat_excsafe(x, y, magnitude);

	if(isExc)
		handleException();
}


public static  System.Int32 core_checkRange( System.IntPtr a ,  System.Int32 quiet ,  out OpenCvSharp.Point pos ,  System.Double minVal ,  System.Double maxVal )
{
	System.Int32 ret = new System.Int32();
	bool isExc = NativeMethodsExc.core_checkRange_excsafe(ref ret, a, quiet,  out pos, minVal, maxVal);

	if(isExc)
		handleException();
	return ret;
}


public static  void core_patchNaNs( System.IntPtr a ,  System.Double val )
{
	bool isExc = NativeMethodsExc.core_patchNaNs_excsafe(a, val);

	if(isExc)
		handleException();
}


public static  void core_gemm( System.IntPtr src1 ,  System.IntPtr src2 ,  System.Double alpha ,  System.IntPtr src3 ,  System.Double gamma ,  System.IntPtr dst ,  System.Int32 flags )
{
	bool isExc = NativeMethodsExc.core_gemm_excsafe(src1, src2, alpha, src3, gamma, dst, flags);

	if(isExc)
		handleException();
}


public static  void core_mulTransposed( System.IntPtr src ,  System.IntPtr dst ,  System.Int32 aTa ,  System.IntPtr delta ,  System.Double scale ,  System.Int32 dtype )
{
	bool isExc = NativeMethodsExc.core_mulTransposed_excsafe(src, dst, aTa, delta, scale, dtype);

	if(isExc)
		handleException();
}


public static  void core_transpose( System.IntPtr src ,  System.IntPtr dst )
{
	bool isExc = NativeMethodsExc.core_transpose_excsafe(src, dst);

	if(isExc)
		handleException();
}


public static  void core_transform( System.IntPtr src ,  System.IntPtr dst ,  System.IntPtr m )
{
	bool isExc = NativeMethodsExc.core_transform_excsafe(src, dst, m);

	if(isExc)
		handleException();
}


public static  void core_perspectiveTransform( System.IntPtr src ,  System.IntPtr dst ,  System.IntPtr m )
{
	bool isExc = NativeMethodsExc.core_perspectiveTransform_excsafe(src, dst, m);

	if(isExc)
		handleException();
}


public static  void core_findNonZero( System.IntPtr src ,  System.IntPtr idx )
{
	bool isExc = NativeMethodsExc.core_findNonZero_excsafe(src, idx);

	if(isExc)
		handleException();
}


public static  OpenCvSharp.Scalar core_mean( System.IntPtr src ,  System.IntPtr mask )
{
	OpenCvSharp.Scalar ret = new OpenCvSharp.Scalar();
	bool isExc = NativeMethodsExc.core_mean_excsafe(ref ret, src, mask);

	if(isExc)
		handleException();
	return ret;
}


public static  void core_meanStdDev_OutputArray( System.IntPtr src ,  System.IntPtr mean ,  System.IntPtr stddev ,  System.IntPtr mask )
{
	bool isExc = NativeMethodsExc.core_meanStdDev_OutputArray_excsafe(src, mean, stddev, mask);

	if(isExc)
		handleException();
}


public static  void core_meanStdDev_Scalar( System.IntPtr src ,  out OpenCvSharp.Scalar mean ,  out OpenCvSharp.Scalar stddev ,  System.IntPtr mask )
{
	bool isExc = NativeMethodsExc.core_meanStdDev_Scalar_excsafe(src,  out mean,  out stddev, mask);

	if(isExc)
		handleException();
}


public static  System.Double core_norm1( System.IntPtr src1 ,  System.Int32 normType ,  System.IntPtr mask )
{
	System.Double ret = new System.Double();
	bool isExc = NativeMethodsExc.core_norm1_excsafe(ref ret, src1, normType, mask);

	if(isExc)
		handleException();
	return ret;
}


public static  System.Double core_norm2( System.IntPtr src1 ,  System.IntPtr src2 ,  System.Int32 normType ,  System.IntPtr mask )
{
	System.Double ret = new System.Double();
	bool isExc = NativeMethodsExc.core_norm2_excsafe(ref ret, src1, src2, normType, mask);

	if(isExc)
		handleException();
	return ret;
}


public static  void core_batchDistance( System.IntPtr src1 ,  System.IntPtr src2 ,  System.IntPtr dist ,  System.Int32 dtype ,  System.IntPtr nidx ,  System.Int32 normType ,  System.Int32 k ,  System.IntPtr mask ,  System.Int32 update ,  System.Int32 crosscheck )
{
	bool isExc = NativeMethodsExc.core_batchDistance_excsafe(src1, src2, dist, dtype, nidx, normType, k, mask, update, crosscheck);

	if(isExc)
		handleException();
}


public static  void core_normalize( System.IntPtr src ,  System.IntPtr dst ,  System.Double alpha ,  System.Double beta ,  System.Int32 normType ,  System.Int32 dtype ,  System.IntPtr mask )
{
	bool isExc = NativeMethodsExc.core_normalize_excsafe(src, dst, alpha, beta, normType, dtype, mask);

	if(isExc)
		handleException();
}


public static  void core_minMaxLoc1( System.IntPtr src ,  out System.Double minVal ,  out System.Double maxVal )
{
	bool isExc = NativeMethodsExc.core_minMaxLoc1_excsafe(src,  out minVal,  out maxVal);

	if(isExc)
		handleException();
}


public static  void core_minMaxLoc2( System.IntPtr src ,  out System.Double minVal ,  out System.Double maxVal ,  out OpenCvSharp.Point minLoc ,  out OpenCvSharp.Point maxLoc ,  System.IntPtr mask )
{
	bool isExc = NativeMethodsExc.core_minMaxLoc2_excsafe(src,  out minVal,  out maxVal,  out minLoc,  out maxLoc, mask);

	if(isExc)
		handleException();
}


public static  void core_minMaxIdx1( System.IntPtr src ,  out System.Double minVal ,  out System.Double maxVal )
{
	bool isExc = NativeMethodsExc.core_minMaxIdx1_excsafe(src,  out minVal,  out maxVal);

	if(isExc)
		handleException();
}


public static  void core_minMaxIdx2( System.IntPtr src ,  out System.Double minVal ,  out System.Double maxVal , [MarshalAs(UnmanagedType.LPArray)] System.Int32[] minIdx , [MarshalAs(UnmanagedType.LPArray)] System.Int32[] maxIdx ,  System.IntPtr mask )
{
	bool isExc = NativeMethodsExc.core_minMaxIdx2_excsafe(src,  out minVal,  out maxVal, minIdx, maxIdx, mask);

	if(isExc)
		handleException();
}


public static  void core_reduce( System.IntPtr src ,  System.IntPtr dst ,  System.Int32 dim ,  System.Int32 rtype ,  System.Int32 dtype )
{
	bool isExc = NativeMethodsExc.core_reduce_excsafe(src, dst, dim, rtype, dtype);

	if(isExc)
		handleException();
}


public static  void core_merge([MarshalAs(UnmanagedType.LPArray)] System.IntPtr[] mv ,  System.UInt32 count ,  System.IntPtr dst )
{
	bool isExc = NativeMethodsExc.core_merge_excsafe(mv, count, dst);

	if(isExc)
		handleException();
}


public static  void core_split( System.IntPtr src ,  out System.IntPtr mv )
{
	bool isExc = NativeMethodsExc.core_split_excsafe(src,  out mv);

	if(isExc)
		handleException();
}


public static  void core_mixChannels( System.IntPtr[] src ,  System.UInt32 nsrcs ,  System.IntPtr[] dst ,  System.UInt32 ndsts ,  System.Int32[] fromTo ,  System.UInt32 npairs )
{
	bool isExc = NativeMethodsExc.core_mixChannels_excsafe(src, nsrcs, dst, ndsts, fromTo, npairs);

	if(isExc)
		handleException();
}


public static  void core_extractChannel( System.IntPtr src ,  System.IntPtr dst ,  System.Int32 coi )
{
	bool isExc = NativeMethodsExc.core_extractChannel_excsafe(src, dst, coi);

	if(isExc)
		handleException();
}


public static  void core_insertChannel( System.IntPtr src ,  System.IntPtr dst ,  System.Int32 coi )
{
	bool isExc = NativeMethodsExc.core_insertChannel_excsafe(src, dst, coi);

	if(isExc)
		handleException();
}


public static  void core_flip( System.IntPtr src ,  System.IntPtr dst ,  System.Int32 flipCode )
{
	bool isExc = NativeMethodsExc.core_flip_excsafe(src, dst, flipCode);

	if(isExc)
		handleException();
}


public static  void core_repeat1( System.IntPtr src ,  System.Int32 ny ,  System.Int32 nx ,  System.IntPtr dst )
{
	bool isExc = NativeMethodsExc.core_repeat1_excsafe(src, ny, nx, dst);

	if(isExc)
		handleException();
}


public static  System.IntPtr core_repeat2( System.IntPtr src ,  System.Int32 ny ,  System.Int32 nx )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.core_repeat2_excsafe(ref ret, src, ny, nx);

	if(isExc)
		handleException();
	return ret;
}


public static  void core_hconcat1([MarshalAs(UnmanagedType.LPArray)] System.IntPtr[] src ,  System.UInt32 nsrc ,  System.IntPtr dst )
{
	bool isExc = NativeMethodsExc.core_hconcat1_excsafe(src, nsrc, dst);

	if(isExc)
		handleException();
}


public static  void core_hconcat2( System.IntPtr src1 ,  System.IntPtr src2 ,  System.IntPtr dst )
{
	bool isExc = NativeMethodsExc.core_hconcat2_excsafe(src1, src2, dst);

	if(isExc)
		handleException();
}


public static  void core_vconcat1([MarshalAs(UnmanagedType.LPArray)] System.IntPtr[] src ,  System.UInt32 nsrc ,  System.IntPtr dst )
{
	bool isExc = NativeMethodsExc.core_vconcat1_excsafe(src, nsrc, dst);

	if(isExc)
		handleException();
}


public static  void core_vconcat2( System.IntPtr src1 ,  System.IntPtr src2 ,  System.IntPtr dst )
{
	bool isExc = NativeMethodsExc.core_vconcat2_excsafe(src1, src2, dst);

	if(isExc)
		handleException();
}


public static  void core_bitwise_and( System.IntPtr src1 ,  System.IntPtr src2 ,  System.IntPtr dst ,  System.IntPtr mask )
{
	bool isExc = NativeMethodsExc.core_bitwise_and_excsafe(src1, src2, dst, mask);

	if(isExc)
		handleException();
}


public static  void core_bitwise_or( System.IntPtr src1 ,  System.IntPtr src2 ,  System.IntPtr dst ,  System.IntPtr mask )
{
	bool isExc = NativeMethodsExc.core_bitwise_or_excsafe(src1, src2, dst, mask);

	if(isExc)
		handleException();
}


public static  void core_bitwise_xor( System.IntPtr src1 ,  System.IntPtr src2 ,  System.IntPtr dst ,  System.IntPtr mask )
{
	bool isExc = NativeMethodsExc.core_bitwise_xor_excsafe(src1, src2, dst, mask);

	if(isExc)
		handleException();
}


public static  System.Int64 core_getTickCount()
{
	System.Int64 ret = new System.Int64();
	bool isExc = NativeMethodsExc.core_getTickCount_excsafe(ref ret);

	if(isExc)
		handleException();
	return ret;
}


public static  System.Double core_getTickFrequency()
{
	System.Double ret = new System.Double();
	bool isExc = NativeMethodsExc.core_getTickFrequency_excsafe(ref ret);

	if(isExc)
		handleException();
	return ret;
}


public static  System.Int64 core_getCPUTickCount()
{
	System.Int64 ret = new System.Int64();
	bool isExc = NativeMethodsExc.core_getCPUTickCount_excsafe(ref ret);

	if(isExc)
		handleException();
	return ret;
}


public static  System.Int32 core_checkHardwareSupport( System.Int32 feature )
{
	System.Int32 ret = new System.Int32();
	bool isExc = NativeMethodsExc.core_checkHardwareSupport_excsafe(ref ret, feature);

	if(isExc)
		handleException();
	return ret;
}


public static  System.Int32 core_getNumberOfCPUs()
{
	System.Int32 ret = new System.Int32();
	bool isExc = NativeMethodsExc.core_getNumberOfCPUs_excsafe(ref ret);

	if(isExc)
		handleException();
	return ret;
}


public static  System.IntPtr core_fastMalloc( System.IntPtr bufSize )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.core_fastMalloc_excsafe(ref ret, bufSize);

	if(isExc)
		handleException();
	return ret;
}


public static  void core_fastFree( System.IntPtr ptr )
{
	bool isExc = NativeMethodsExc.core_fastFree_excsafe(ptr);

	if(isExc)
		handleException();
}


public static  void core_setUseOptimized( System.Int32 onoff )
{
	bool isExc = NativeMethodsExc.core_setUseOptimized_excsafe(onoff);

	if(isExc)
		handleException();
}


public static  System.Int32 core_useOptimized()
{
	System.Int32 ret = new System.Int32();
	bool isExc = NativeMethodsExc.core_useOptimized_excsafe(ref ret);

	if(isExc)
		handleException();
	return ret;
}


public static  System.IntPtr redirectError( OpenCvSharp.CvErrorCallback errCallback ,  System.IntPtr userdata ,  ref System.IntPtr prevUserdata )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.redirectError_excsafe(ref ret, errCallback, userdata,  ref prevUserdata);

	if(isExc)
		handleException();
	return ret;
}


public static  System.IntPtr core_cvarrToMat( System.IntPtr arr ,  System.Int32 copyData ,  System.Int32 allowND ,  System.Int32 coiMode )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.core_cvarrToMat_excsafe(ref ret, arr, copyData, allowND, coiMode);

	if(isExc)
		handleException();
	return ret;
}


public static  void core_extractImageCOI( System.IntPtr arr ,  System.IntPtr coiimg ,  System.Int32 coi )
{
	bool isExc = NativeMethodsExc.core_extractImageCOI_excsafe(arr, coiimg, coi);

	if(isExc)
		handleException();
}


public static  void core_insertImageCOI( System.IntPtr coiimg ,  System.IntPtr arr ,  System.Int32 coi )
{
	bool isExc = NativeMethodsExc.core_insertImageCOI_excsafe(coiimg, arr, coi);

	if(isExc)
		handleException();
}


public static  void core_add( System.IntPtr src1 ,  System.IntPtr src2 ,  System.IntPtr dst ,  System.IntPtr mask ,  System.Int32 dtype )
{
	bool isExc = NativeMethodsExc.core_add_excsafe(src1, src2, dst, mask, dtype);

	if(isExc)
		handleException();
}


public static  void core_subtract_InputArray2( System.IntPtr src1 ,  System.IntPtr src2 ,  System.IntPtr dst ,  System.IntPtr mask ,  System.Int32 dtype )
{
	bool isExc = NativeMethodsExc.core_subtract_InputArray2_excsafe(src1, src2, dst, mask, dtype);

	if(isExc)
		handleException();
}


public static  void core_subtract_InputArrayScalar( System.IntPtr src1 ,  OpenCvSharp.Scalar src2 ,  System.IntPtr dst ,  System.IntPtr mask ,  System.Int32 dtype )
{
	bool isExc = NativeMethodsExc.core_subtract_InputArrayScalar_excsafe(src1, src2, dst, mask, dtype);

	if(isExc)
		handleException();
}


public static  void core_subtract_ScalarInputArray( OpenCvSharp.Scalar src1 ,  System.IntPtr src2 ,  System.IntPtr dst ,  System.IntPtr mask ,  System.Int32 dtype )
{
	bool isExc = NativeMethodsExc.core_subtract_ScalarInputArray_excsafe(src1, src2, dst, mask, dtype);

	if(isExc)
		handleException();
}


public static  void core_multiply( System.IntPtr src1 ,  System.IntPtr src2 ,  System.IntPtr dst ,  System.Double scale ,  System.Int32 dtype )
{
	bool isExc = NativeMethodsExc.core_multiply_excsafe(src1, src2, dst, scale, dtype);

	if(isExc)
		handleException();
}


public static  void core_divide1( System.Double scale ,  System.IntPtr src2 ,  System.IntPtr dst ,  System.Int32 dtype )
{
	bool isExc = NativeMethodsExc.core_divide1_excsafe(scale, src2, dst, dtype);

	if(isExc)
		handleException();
}


public static  void core_divide2( System.IntPtr src1 ,  System.IntPtr src2 ,  System.IntPtr dst ,  System.Double scale ,  System.Int32 dtype )
{
	bool isExc = NativeMethodsExc.core_divide2_excsafe(src1, src2, dst, scale, dtype);

	if(isExc)
		handleException();
}


public static  void core_scaleAdd( System.IntPtr src1 ,  System.Double alpha ,  System.IntPtr src2 ,  System.IntPtr dst )
{
	bool isExc = NativeMethodsExc.core_scaleAdd_excsafe(src1, alpha, src2, dst);

	if(isExc)
		handleException();
}


public static  void core_addWeighted( System.IntPtr src1 ,  System.Double alpha ,  System.IntPtr src2 ,  System.Double beta ,  System.Double gamma ,  System.IntPtr dst ,  System.Int32 dtype )
{
	bool isExc = NativeMethodsExc.core_addWeighted_excsafe(src1, alpha, src2, beta, gamma, dst, dtype);

	if(isExc)
		handleException();
}


public static  System.Int32 core_borderInterpolate( System.Int32 p ,  System.Int32 len ,  System.Int32 borderType )
{
	System.Int32 ret = new System.Int32();
	bool isExc = NativeMethodsExc.core_borderInterpolate_excsafe(ref ret, p, len, borderType);

	if(isExc)
		handleException();
	return ret;
}


public static  void core_copyMakeBorder( System.IntPtr src ,  System.IntPtr dst ,  System.Int32 top ,  System.Int32 bottom ,  System.Int32 left ,  System.Int32 right ,  System.Int32 borderType ,  OpenCvSharp.Scalar value )
{
	bool isExc = NativeMethodsExc.core_copyMakeBorder_excsafe(src, dst, top, bottom, left, right, borderType, value);

	if(isExc)
		handleException();
}


public static  void core_convertScaleAbs( System.IntPtr src ,  System.IntPtr dst ,  System.Double alpha ,  System.Double beta )
{
	bool isExc = NativeMethodsExc.core_convertScaleAbs_excsafe(src, dst, alpha, beta);

	if(isExc)
		handleException();
}


public static  void core_LUT( System.IntPtr src ,  System.IntPtr lut ,  System.IntPtr dst )
{
	bool isExc = NativeMethodsExc.core_LUT_excsafe(src, lut, dst);

	if(isExc)
		handleException();
}


public static  OpenCvSharp.Scalar core_sum( System.IntPtr src )
{
	OpenCvSharp.Scalar ret = new OpenCvSharp.Scalar();
	bool isExc = NativeMethodsExc.core_sum_excsafe(ref ret, src);

	if(isExc)
		handleException();
	return ret;
}


public static  System.Int32 core_countNonZero( System.IntPtr src )
{
	System.Int32 ret = new System.Int32();
	bool isExc = NativeMethodsExc.core_countNonZero_excsafe(ref ret, src);

	if(isExc)
		handleException();
	return ret;
}


public static  System.Int32 calib3d_StereoMatcher_getNumDisparities( System.IntPtr obj )
{
	System.Int32 ret = new System.Int32();
	bool isExc = NativeMethodsExc.calib3d_StereoMatcher_getNumDisparities_excsafe(ref ret, obj);

	if(isExc)
		handleException();
	return ret;
}


public static  void calib3d_StereoMatcher_setNumDisparities( System.IntPtr obj ,  System.Int32 value )
{
	bool isExc = NativeMethodsExc.calib3d_StereoMatcher_setNumDisparities_excsafe(obj, value);

	if(isExc)
		handleException();
}


public static  System.Int32 calib3d_StereoMatcher_getBlockSize( System.IntPtr obj )
{
	System.Int32 ret = new System.Int32();
	bool isExc = NativeMethodsExc.calib3d_StereoMatcher_getBlockSize_excsafe(ref ret, obj);

	if(isExc)
		handleException();
	return ret;
}


public static  void calib3d_StereoMatcher_setBlockSize( System.IntPtr obj ,  System.Int32 value )
{
	bool isExc = NativeMethodsExc.calib3d_StereoMatcher_setBlockSize_excsafe(obj, value);

	if(isExc)
		handleException();
}


public static  System.Int32 calib3d_StereoMatcher_getSpeckleWindowSize( System.IntPtr obj )
{
	System.Int32 ret = new System.Int32();
	bool isExc = NativeMethodsExc.calib3d_StereoMatcher_getSpeckleWindowSize_excsafe(ref ret, obj);

	if(isExc)
		handleException();
	return ret;
}


public static  void calib3d_StereoMatcher_setSpeckleWindowSize( System.IntPtr obj ,  System.Int32 value )
{
	bool isExc = NativeMethodsExc.calib3d_StereoMatcher_setSpeckleWindowSize_excsafe(obj, value);

	if(isExc)
		handleException();
}


public static  System.Int32 calib3d_StereoMatcher_getSpeckleRange( System.IntPtr obj )
{
	System.Int32 ret = new System.Int32();
	bool isExc = NativeMethodsExc.calib3d_StereoMatcher_getSpeckleRange_excsafe(ref ret, obj);

	if(isExc)
		handleException();
	return ret;
}


public static  void calib3d_StereoMatcher_setSpeckleRange( System.IntPtr obj ,  System.Int32 value )
{
	bool isExc = NativeMethodsExc.calib3d_StereoMatcher_setSpeckleRange_excsafe(obj, value);

	if(isExc)
		handleException();
}


public static  System.Int32 calib3d_StereoMatcher_getDisp12MaxDiff( System.IntPtr obj )
{
	System.Int32 ret = new System.Int32();
	bool isExc = NativeMethodsExc.calib3d_StereoMatcher_getDisp12MaxDiff_excsafe(ref ret, obj);

	if(isExc)
		handleException();
	return ret;
}


public static  void calib3d_StereoMatcher_setDisp12MaxDiff( System.IntPtr obj ,  System.Int32 value )
{
	bool isExc = NativeMethodsExc.calib3d_StereoMatcher_setDisp12MaxDiff_excsafe(obj, value);

	if(isExc)
		handleException();
}


public static  System.IntPtr calib3d_Ptr_StereoSGBM_get( System.IntPtr obj )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.calib3d_Ptr_StereoSGBM_get_excsafe(ref ret, obj);

	if(isExc)
		handleException();
	return ret;
}


public static  void calib3d_Ptr_StereoSGBM_delete( System.IntPtr obj )
{
	bool isExc = NativeMethodsExc.calib3d_Ptr_StereoSGBM_delete_excsafe(obj);

	if(isExc)
		handleException();
}


public static  System.IntPtr calib3d_StereoSGBM_create( System.Int32 minDisparity ,  System.Int32 numDisparities ,  System.Int32 blockSize ,  System.Int32 P1 ,  System.Int32 P2 ,  System.Int32 disp12MaxDiff ,  System.Int32 preFilterCap ,  System.Int32 uniquenessRatio ,  System.Int32 speckleWindowSize ,  System.Int32 speckleRange ,  System.Int32 mode )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.calib3d_StereoSGBM_create_excsafe(ref ret, minDisparity, numDisparities, blockSize, P1, P2, disp12MaxDiff, preFilterCap, uniquenessRatio, speckleWindowSize, speckleRange, mode);

	if(isExc)
		handleException();
	return ret;
}


public static  System.Int32 calib3d_StereoSGBM_getPreFilterCap( System.IntPtr obj )
{
	System.Int32 ret = new System.Int32();
	bool isExc = NativeMethodsExc.calib3d_StereoSGBM_getPreFilterCap_excsafe(ref ret, obj);

	if(isExc)
		handleException();
	return ret;
}


public static  void calib3d_StereoSGBM_setPreFilterCap( System.IntPtr obj ,  System.Int32 value )
{
	bool isExc = NativeMethodsExc.calib3d_StereoSGBM_setPreFilterCap_excsafe(obj, value);

	if(isExc)
		handleException();
}


public static  System.Int32 calib3d_StereoSGBM_getUniquenessRatio( System.IntPtr obj )
{
	System.Int32 ret = new System.Int32();
	bool isExc = NativeMethodsExc.calib3d_StereoSGBM_getUniquenessRatio_excsafe(ref ret, obj);

	if(isExc)
		handleException();
	return ret;
}


public static  void calib3d_StereoSGBM_setUniquenessRatio( System.IntPtr obj ,  System.Int32 value )
{
	bool isExc = NativeMethodsExc.calib3d_StereoSGBM_setUniquenessRatio_excsafe(obj, value);

	if(isExc)
		handleException();
}


public static  System.Int32 calib3d_StereoSGBM_getP1( System.IntPtr obj )
{
	System.Int32 ret = new System.Int32();
	bool isExc = NativeMethodsExc.calib3d_StereoSGBM_getP1_excsafe(ref ret, obj);

	if(isExc)
		handleException();
	return ret;
}


public static  void calib3d_StereoSGBM_setP1( System.IntPtr obj ,  System.Int32 value )
{
	bool isExc = NativeMethodsExc.calib3d_StereoSGBM_setP1_excsafe(obj, value);

	if(isExc)
		handleException();
}


public static  System.Int32 calib3d_StereoSGBM_getP2( System.IntPtr obj )
{
	System.Int32 ret = new System.Int32();
	bool isExc = NativeMethodsExc.calib3d_StereoSGBM_getP2_excsafe(ref ret, obj);

	if(isExc)
		handleException();
	return ret;
}


public static  void calib3d_StereoSGBM_setP2( System.IntPtr obj ,  System.Int32 value )
{
	bool isExc = NativeMethodsExc.calib3d_StereoSGBM_setP2_excsafe(obj, value);

	if(isExc)
		handleException();
}


public static  System.Int32 calib3d_StereoSGBM_getMode( System.IntPtr obj )
{
	System.Int32 ret = new System.Int32();
	bool isExc = NativeMethodsExc.calib3d_StereoSGBM_getMode_excsafe(ref ret, obj);

	if(isExc)
		handleException();
	return ret;
}


public static  void calib3d_StereoSGBM_setMode( System.IntPtr obj ,  System.Int32 value )
{
	bool isExc = NativeMethodsExc.calib3d_StereoSGBM_setMode_excsafe(obj, value);

	if(isExc)
		handleException();
}


public static  void core_setNumThreads( System.Int32 nthreads )
{
	bool isExc = NativeMethodsExc.core_setNumThreads_excsafe(nthreads);

	if(isExc)
		handleException();
}


public static  System.Int32 core_getNumThreads()
{
	System.Int32 ret = new System.Int32();
	bool isExc = NativeMethodsExc.core_getNumThreads_excsafe(ref ret);

	if(isExc)
		handleException();
	return ret;
}


public static  System.Int32 core_getThreadNum()
{
	System.Int32 ret = new System.Int32();
	bool isExc = NativeMethodsExc.core_getThreadNum_excsafe(ref ret);

	if(isExc)
		handleException();
	return ret;
}


public static  void core_getBuildInformation([MarshalAs(UnmanagedType.LPStr)] System.Text.StringBuilder buf ,  System.Int32 maxLength )
{
	bool isExc = NativeMethodsExc.core_getBuildInformation_excsafe(buf, maxLength);

	if(isExc)
		handleException();
}


public static  System.Int32 core_getBuildInformation_length()
{
	System.Int32 ret = new System.Int32();
	bool isExc = NativeMethodsExc.core_getBuildInformation_length_excsafe(ref ret);

	if(isExc)
		handleException();
	return ret;
}


public static  void calib3d_correctMatches_array( System.Double[,] F ,  OpenCvSharp.Point2d[] points1 ,  System.Int32 points1Size ,  OpenCvSharp.Point2d[] points2 ,  System.Int32 points2Size ,  OpenCvSharp.Point2d[] newPoints1 ,  OpenCvSharp.Point2d[] newPoints2 )
{
	bool isExc = NativeMethodsExc.calib3d_correctMatches_array_excsafe(F, points1, points1Size, points2, points2Size, newPoints1, newPoints2);

	if(isExc)
		handleException();
}


public static  void calib3d_filterSpeckles( System.IntPtr img ,  System.Double newVal ,  System.Int32 maxSpeckleSize ,  System.Double maxDiff ,  System.IntPtr buf )
{
	bool isExc = NativeMethodsExc.calib3d_filterSpeckles_excsafe(img, newVal, maxSpeckleSize, maxDiff, buf);

	if(isExc)
		handleException();
}


public static  OpenCvSharp.Rect calib3d_getValidDisparityROI( OpenCvSharp.Rect roi1 ,  OpenCvSharp.Rect roi2 ,  System.Int32 minDisparity ,  System.Int32 numberOfDisparities ,  System.Int32 SADWindowSize )
{
	OpenCvSharp.Rect ret = new OpenCvSharp.Rect();
	bool isExc = NativeMethodsExc.calib3d_getValidDisparityROI_excsafe(ref ret, roi1, roi2, minDisparity, numberOfDisparities, SADWindowSize);

	if(isExc)
		handleException();
	return ret;
}


public static  void calib3d_validateDisparity( System.IntPtr disparity ,  System.IntPtr cost ,  System.Int32 minDisparity ,  System.Int32 numberOfDisparities ,  System.Int32 disp12MaxDisp )
{
	bool isExc = NativeMethodsExc.calib3d_validateDisparity_excsafe(disparity, cost, minDisparity, numberOfDisparities, disp12MaxDisp);

	if(isExc)
		handleException();
}


public static  void calib3d_reprojectImageTo3D( System.IntPtr disparity ,  System.IntPtr _3dImage ,  System.IntPtr Q ,  System.Int32 handleMissingValues ,  System.Int32 ddepth )
{
	bool isExc = NativeMethodsExc.calib3d_reprojectImageTo3D_excsafe(disparity, _3dImage, Q, handleMissingValues, ddepth);

	if(isExc)
		handleException();
}


public static  System.Int32 calib3d_estimateAffine3D( System.IntPtr src ,  System.IntPtr dst ,  System.IntPtr outVal ,  System.IntPtr inliers ,  System.Double ransacThreshold ,  System.Double confidence )
{
	System.Int32 ret = new System.Int32();
	bool isExc = NativeMethodsExc.calib3d_estimateAffine3D_excsafe(ref ret, src, dst, outVal, inliers, ransacThreshold, confidence);

	if(isExc)
		handleException();
	return ret;
}


public static  void calib3d_Ptr_StereoBM_delete( System.IntPtr obj )
{
	bool isExc = NativeMethodsExc.calib3d_Ptr_StereoBM_delete_excsafe(obj);

	if(isExc)
		handleException();
}


public static  System.IntPtr calib3d_Ptr_StereoBM_get( System.IntPtr obj )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.calib3d_Ptr_StereoBM_get_excsafe(ref ret, obj);

	if(isExc)
		handleException();
	return ret;
}


public static  System.IntPtr calib3d_StereoBM_create( System.Int32 numDisparities ,  System.Int32 blockSize )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.calib3d_StereoBM_create_excsafe(ref ret, numDisparities, blockSize);

	if(isExc)
		handleException();
	return ret;
}


public static  System.Int32 calib3d_StereoBM_getPreFilterType( System.IntPtr obj )
{
	System.Int32 ret = new System.Int32();
	bool isExc = NativeMethodsExc.calib3d_StereoBM_getPreFilterType_excsafe(ref ret, obj);

	if(isExc)
		handleException();
	return ret;
}


public static  void calib3d_StereoBM_setPreFilterType( System.IntPtr obj ,  System.Int32 value )
{
	bool isExc = NativeMethodsExc.calib3d_StereoBM_setPreFilterType_excsafe(obj, value);

	if(isExc)
		handleException();
}


public static  System.Int32 calib3d_StereoBM_getPreFilterSize( System.IntPtr obj )
{
	System.Int32 ret = new System.Int32();
	bool isExc = NativeMethodsExc.calib3d_StereoBM_getPreFilterSize_excsafe(ref ret, obj);

	if(isExc)
		handleException();
	return ret;
}


public static  void calib3d_StereoBM_setPreFilterSize( System.IntPtr obj ,  System.Int32 value )
{
	bool isExc = NativeMethodsExc.calib3d_StereoBM_setPreFilterSize_excsafe(obj, value);

	if(isExc)
		handleException();
}


public static  System.Int32 calib3d_StereoBM_getPreFilterCap( System.IntPtr obj )
{
	System.Int32 ret = new System.Int32();
	bool isExc = NativeMethodsExc.calib3d_StereoBM_getPreFilterCap_excsafe(ref ret, obj);

	if(isExc)
		handleException();
	return ret;
}


public static  void calib3d_StereoBM_setPreFilterCap( System.IntPtr obj ,  System.Int32 value )
{
	bool isExc = NativeMethodsExc.calib3d_StereoBM_setPreFilterCap_excsafe(obj, value);

	if(isExc)
		handleException();
}


public static  System.Int32 calib3d_StereoBM_getTextureThreshold( System.IntPtr obj )
{
	System.Int32 ret = new System.Int32();
	bool isExc = NativeMethodsExc.calib3d_StereoBM_getTextureThreshold_excsafe(ref ret, obj);

	if(isExc)
		handleException();
	return ret;
}


public static  void calib3d_StereoBM_setTextureThreshold( System.IntPtr obj ,  System.Int32 value )
{
	bool isExc = NativeMethodsExc.calib3d_StereoBM_setTextureThreshold_excsafe(obj, value);

	if(isExc)
		handleException();
}


public static  System.Int32 calib3d_StereoBM_getUniquenessRatio( System.IntPtr obj )
{
	System.Int32 ret = new System.Int32();
	bool isExc = NativeMethodsExc.calib3d_StereoBM_getUniquenessRatio_excsafe(ref ret, obj);

	if(isExc)
		handleException();
	return ret;
}


public static  void calib3d_StereoBM_setUniquenessRatio( System.IntPtr obj ,  System.Int32 value )
{
	bool isExc = NativeMethodsExc.calib3d_StereoBM_setUniquenessRatio_excsafe(obj, value);

	if(isExc)
		handleException();
}


public static  System.Int32 calib3d_StereoBM_getSmallerBlockSize( System.IntPtr obj )
{
	System.Int32 ret = new System.Int32();
	bool isExc = NativeMethodsExc.calib3d_StereoBM_getSmallerBlockSize_excsafe(ref ret, obj);

	if(isExc)
		handleException();
	return ret;
}


public static  void calib3d_StereoBM_setSmallerBlockSize( System.IntPtr obj ,  System.Int32 value )
{
	bool isExc = NativeMethodsExc.calib3d_StereoBM_setSmallerBlockSize_excsafe(obj, value);

	if(isExc)
		handleException();
}


public static  OpenCvSharp.Rect calib3d_StereoBM_getROI1( System.IntPtr obj )
{
	OpenCvSharp.Rect ret = new OpenCvSharp.Rect();
	bool isExc = NativeMethodsExc.calib3d_StereoBM_getROI1_excsafe(ref ret, obj);

	if(isExc)
		handleException();
	return ret;
}


public static  void calib3d_StereoBM_setROI1( System.IntPtr obj ,  OpenCvSharp.Rect value )
{
	bool isExc = NativeMethodsExc.calib3d_StereoBM_setROI1_excsafe(obj, value);

	if(isExc)
		handleException();
}


public static  OpenCvSharp.Rect calib3d_StereoBM_getROI2( System.IntPtr obj )
{
	OpenCvSharp.Rect ret = new OpenCvSharp.Rect();
	bool isExc = NativeMethodsExc.calib3d_StereoBM_getROI2_excsafe(ref ret, obj);

	if(isExc)
		handleException();
	return ret;
}


public static  void calib3d_StereoBM_setROI2( System.IntPtr obj ,  OpenCvSharp.Rect value )
{
	bool isExc = NativeMethodsExc.calib3d_StereoBM_setROI2_excsafe(obj, value);

	if(isExc)
		handleException();
}


public static  void calib3d_StereoMatcher_compute( System.IntPtr obj ,  System.IntPtr left ,  System.IntPtr right ,  System.IntPtr disparity )
{
	bool isExc = NativeMethodsExc.calib3d_StereoMatcher_compute_excsafe(obj, left, right, disparity);

	if(isExc)
		handleException();
}


public static  System.Int32 calib3d_StereoMatcher_getMinDisparity( System.IntPtr obj )
{
	System.Int32 ret = new System.Int32();
	bool isExc = NativeMethodsExc.calib3d_StereoMatcher_getMinDisparity_excsafe(ref ret, obj);

	if(isExc)
		handleException();
	return ret;
}


public static  void calib3d_StereoMatcher_setMinDisparity( System.IntPtr obj ,  System.Int32 value )
{
	bool isExc = NativeMethodsExc.calib3d_StereoMatcher_setMinDisparity_excsafe(obj, value);

	if(isExc)
		handleException();
}


public static  System.Double calib3d_calibrateCamera_InputArray( System.IntPtr[] objectPoints ,  System.Int32 objectPointsSize ,  System.IntPtr[] imagePoints ,  System.Int32 imagePointsSize ,  OpenCvSharp.Size imageSize ,  System.IntPtr cameraMatrix ,  System.IntPtr distCoeffs ,  System.IntPtr rvecs ,  System.IntPtr tvecs ,  System.Int32 flags ,  OpenCvSharp.TermCriteria criteria )
{
	System.Double ret = new System.Double();
	bool isExc = NativeMethodsExc.calib3d_calibrateCamera_InputArray_excsafe(ref ret, objectPoints, objectPointsSize, imagePoints, imagePointsSize, imageSize, cameraMatrix, distCoeffs, rvecs, tvecs, flags, criteria);

	if(isExc)
		handleException();
	return ret;
}


public static  System.Double calib3d_calibrateCamera_vector( System.IntPtr[] objectPoints ,  System.Int32 opSize1 ,  System.Int32[] opSize2 ,  System.IntPtr[] imagePoints ,  System.Int32 ipSize1 ,  System.Int32[] ipSize2 ,  OpenCvSharp.Size imageSize , [In, Out] System.Double[,] cameraMatrix , [In, Out] System.Double[] distCoeffs ,  System.Int32 distCoeffsSize ,  System.IntPtr rvecs ,  System.IntPtr tvecs ,  System.Int32 flags ,  OpenCvSharp.TermCriteria criteria )
{
	System.Double ret = new System.Double();
	bool isExc = NativeMethodsExc.calib3d_calibrateCamera_vector_excsafe(ref ret, objectPoints, opSize1, opSize2, imagePoints, ipSize1, ipSize2, imageSize, cameraMatrix, distCoeffs, distCoeffsSize, rvecs, tvecs, flags, criteria);

	if(isExc)
		handleException();
	return ret;
}


public static  void calib3d_calibrationMatrixValues_InputArray( System.IntPtr cameraMatrix ,  OpenCvSharp.Size imageSize ,  System.Double apertureWidth ,  System.Double apertureHeight ,  out System.Double fovx ,  out System.Double fovy ,  out System.Double focalLength ,  out OpenCvSharp.Point2d principalPoint ,  out System.Double aspectRatio )
{
	bool isExc = NativeMethodsExc.calib3d_calibrationMatrixValues_InputArray_excsafe(cameraMatrix, imageSize, apertureWidth, apertureHeight,  out fovx,  out fovy,  out focalLength,  out principalPoint,  out aspectRatio);

	if(isExc)
		handleException();
}


public static  void calib3d_calibrationMatrixValues_array( System.Double[,] cameraMatrix ,  OpenCvSharp.Size imageSize ,  System.Double apertureWidth ,  System.Double apertureHeight ,  out System.Double fovx ,  out System.Double fovy ,  out System.Double focalLength ,  out OpenCvSharp.Point2d principalPoint ,  out System.Double aspectRatio )
{
	bool isExc = NativeMethodsExc.calib3d_calibrationMatrixValues_array_excsafe(cameraMatrix, imageSize, apertureWidth, apertureHeight,  out fovx,  out fovy,  out focalLength,  out principalPoint,  out aspectRatio);

	if(isExc)
		handleException();
}


public static  System.Double calib3d_stereoCalibrate_InputArray( System.IntPtr[] objectPoints ,  System.Int32 opSize ,  System.IntPtr[] imagePoints1 ,  System.Int32 ip1Size ,  System.IntPtr[] imagePoints2 ,  System.Int32 ip2Size ,  System.IntPtr cameraMatrix1 ,  System.IntPtr distCoeffs1 ,  System.IntPtr cameraMatrix2 ,  System.IntPtr distCoeffs2 ,  OpenCvSharp.Size imageSize ,  System.IntPtr R ,  System.IntPtr T ,  System.IntPtr E ,  System.IntPtr F ,  System.Int32 flags ,  OpenCvSharp.TermCriteria criteria )
{
	System.Double ret = new System.Double();
	bool isExc = NativeMethodsExc.calib3d_stereoCalibrate_InputArray_excsafe(ref ret, objectPoints, opSize, imagePoints1, ip1Size, imagePoints2, ip2Size, cameraMatrix1, distCoeffs1, cameraMatrix2, distCoeffs2, imageSize, R, T, E, F, flags, criteria);

	if(isExc)
		handleException();
	return ret;
}


public static  System.Double calib3d_stereoCalibrate_array( System.IntPtr[] objectPoints ,  System.Int32 opSize1 ,  System.Int32[] opSizes2 ,  System.IntPtr[] imagePoints1 ,  System.Int32 ip1Size1 ,  System.Int32[] ip1Sizes2 ,  System.IntPtr[] imagePoints2 ,  System.Int32 ip2Size1 ,  System.Int32[] ip2Sizes2 , [In, Out] System.Double[,] cameraMatrix1 , [In, Out] System.Double[] distCoeffs1 ,  System.Int32 dc1Size , [In, Out] System.Double[,] cameraMatrix2 , [In, Out] System.Double[] distCoeffs2 ,  System.Int32 dc2Size ,  OpenCvSharp.Size imageSize ,  System.IntPtr R ,  System.IntPtr T ,  System.IntPtr E ,  System.IntPtr F ,  System.Int32 flags ,  OpenCvSharp.TermCriteria criteria )
{
	System.Double ret = new System.Double();
	bool isExc = NativeMethodsExc.calib3d_stereoCalibrate_array_excsafe(ref ret, objectPoints, opSize1, opSizes2, imagePoints1, ip1Size1, ip1Sizes2, imagePoints2, ip2Size1, ip2Sizes2, cameraMatrix1, distCoeffs1, dc1Size, cameraMatrix2, distCoeffs2, dc2Size, imageSize, R, T, E, F, flags, criteria);

	if(isExc)
		handleException();
	return ret;
}


public static  void calib3d_stereoRectify_InputArray( System.IntPtr cameraMatrix1 ,  System.IntPtr distCoeffs1 ,  System.IntPtr cameraMatrix2 ,  System.IntPtr distCoeffs2 ,  OpenCvSharp.Size imageSize ,  System.IntPtr R ,  System.IntPtr T ,  System.IntPtr R1 ,  System.IntPtr R2 ,  System.IntPtr P1 ,  System.IntPtr P2 ,  System.IntPtr Q ,  System.Int32 flags ,  System.Double alpha ,  OpenCvSharp.Size newImageSize ,  out OpenCvSharp.Rect validPixROI1 ,  out OpenCvSharp.Rect validPixROI2 )
{
	bool isExc = NativeMethodsExc.calib3d_stereoRectify_InputArray_excsafe(cameraMatrix1, distCoeffs1, cameraMatrix2, distCoeffs2, imageSize, R, T, R1, R2, P1, P2, Q, flags, alpha, newImageSize,  out validPixROI1,  out validPixROI2);

	if(isExc)
		handleException();
}


public static  void calib3d_stereoRectify_array( System.Double[,] cameraMatrix1 ,  System.Double[] distCoeffs1 ,  System.Int32 dc1Size ,  System.Double[,] cameraMatrix2 ,  System.Double[] distCoeffs2 ,  System.Int32 dc2Size ,  OpenCvSharp.Size imageSize ,  System.Double[,] R ,  System.Double[] T ,  System.Double[,] R1 ,  System.Double[,] R2 ,  System.Double[,] P1 ,  System.Double[,] P2 ,  System.Double[,] Q ,  System.Int32 flags ,  System.Double alpha ,  OpenCvSharp.Size newImageSize ,  out OpenCvSharp.Rect validPixROI1 ,  out OpenCvSharp.Rect validPixROI2 )
{
	bool isExc = NativeMethodsExc.calib3d_stereoRectify_array_excsafe(cameraMatrix1, distCoeffs1, dc1Size, cameraMatrix2, distCoeffs2, dc2Size, imageSize, R, T, R1, R2, P1, P2, Q, flags, alpha, newImageSize,  out validPixROI1,  out validPixROI2);

	if(isExc)
		handleException();
}


public static  System.Int32 calib3d_stereoRectifyUncalibrated_InputArray( System.IntPtr points1 ,  System.IntPtr points2 ,  System.IntPtr F ,  OpenCvSharp.Size imgSize ,  System.IntPtr H1 ,  System.IntPtr H2 ,  System.Double threshold )
{
	System.Int32 ret = new System.Int32();
	bool isExc = NativeMethodsExc.calib3d_stereoRectifyUncalibrated_InputArray_excsafe(ref ret, points1, points2, F, imgSize, H1, H2, threshold);

	if(isExc)
		handleException();
	return ret;
}


public static  System.Int32 calib3d_stereoRectifyUncalibrated_array( OpenCvSharp.Point2d[] points1 ,  System.Int32 points1Size ,  OpenCvSharp.Point2d[] points2 ,  System.Int32 points2Size , [In] System.Double[,] F ,  OpenCvSharp.Size imgSize , [In, Out] System.Double[,] H1 , [In, Out] System.Double[,] H2 ,  System.Double threshold )
{
	System.Int32 ret = new System.Int32();
	bool isExc = NativeMethodsExc.calib3d_stereoRectifyUncalibrated_array_excsafe(ref ret, points1, points1Size, points2, points2Size, F, imgSize, H1, H2, threshold);

	if(isExc)
		handleException();
	return ret;
}


public static  System.Single calib3d_rectify3Collinear_InputArray( System.IntPtr cameraMatrix1 ,  System.IntPtr distCoeffs1 ,  System.IntPtr cameraMatrix2 ,  System.IntPtr distCoeffs2 ,  System.IntPtr cameraMatrix3 ,  System.IntPtr distCoeffs3 ,  System.IntPtr[] imgpt1 ,  System.Int32 imgpt1Size ,  System.IntPtr[] imgpt3 ,  System.Int32 imgpt3Size ,  OpenCvSharp.Size imageSize ,  System.IntPtr R12 ,  System.IntPtr T12 ,  System.IntPtr R13 ,  System.IntPtr T13 ,  System.IntPtr R1 ,  System.IntPtr R2 ,  System.IntPtr R3 ,  System.IntPtr P1 ,  System.IntPtr P2 ,  System.IntPtr P3 ,  System.IntPtr Q ,  System.Double alpha ,  OpenCvSharp.Size newImgSize ,  out OpenCvSharp.Rect roi1 ,  out OpenCvSharp.Rect roi2 ,  System.Int32 flags )
{
	System.Single ret = new System.Single();
	bool isExc = NativeMethodsExc.calib3d_rectify3Collinear_InputArray_excsafe(ref ret, cameraMatrix1, distCoeffs1, cameraMatrix2, distCoeffs2, cameraMatrix3, distCoeffs3, imgpt1, imgpt1Size, imgpt3, imgpt3Size, imageSize, R12, T12, R13, T13, R1, R2, R3, P1, P2, P3, Q, alpha, newImgSize,  out roi1,  out roi2, flags);

	if(isExc)
		handleException();
	return ret;
}


public static  System.IntPtr calib3d_getOptimalNewCameraMatrix_InputArray( System.IntPtr cameraMatrix ,  System.IntPtr distCoeffs ,  OpenCvSharp.Size imageSize ,  System.Double alpha ,  OpenCvSharp.Size newImgSize ,  out OpenCvSharp.Rect validPixROI ,  System.Int32 centerPrincipalPoint )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.calib3d_getOptimalNewCameraMatrix_InputArray_excsafe(ref ret, cameraMatrix, distCoeffs, imageSize, alpha, newImgSize,  out validPixROI, centerPrincipalPoint);

	if(isExc)
		handleException();
	return ret;
}


public static  void calib3d_getOptimalNewCameraMatrix_array([In] System.Double[,] cameraMatrix , [In] System.Double[] distCoeffs ,  System.Int32 distCoeffsSize ,  OpenCvSharp.Size imageSize ,  System.Double alpha ,  OpenCvSharp.Size newImgSize ,  out OpenCvSharp.Rect validPixROI ,  System.Int32 centerPrincipalPoint , [In, Out] System.Double[,] outValues )
{
	bool isExc = NativeMethodsExc.calib3d_getOptimalNewCameraMatrix_array_excsafe(cameraMatrix, distCoeffs, distCoeffsSize, imageSize, alpha, newImgSize,  out validPixROI, centerPrincipalPoint, outValues);

	if(isExc)
		handleException();
}


public static  void calib3d_convertPointsToHomogeneous_InputArray( System.IntPtr src ,  System.IntPtr dst )
{
	bool isExc = NativeMethodsExc.calib3d_convertPointsToHomogeneous_InputArray_excsafe(src, dst);

	if(isExc)
		handleException();
}


public static  void calib3d_convertPointsToHomogeneous_array1([In] OpenCvSharp.Vec2f[] src , [In, Out] OpenCvSharp.Vec3f[] dst ,  System.Int32 length )
{
	bool isExc = NativeMethodsExc.calib3d_convertPointsToHomogeneous_array1_excsafe(src, dst, length);

	if(isExc)
		handleException();
}


public static  void calib3d_convertPointsToHomogeneous_array2([In] OpenCvSharp.Vec3f[] src , [In, Out] OpenCvSharp.Vec4f[] dst ,  System.Int32 length )
{
	bool isExc = NativeMethodsExc.calib3d_convertPointsToHomogeneous_array2_excsafe(src, dst, length);

	if(isExc)
		handleException();
}


public static  void calib3d_convertPointsFromHomogeneous_InputArray( System.IntPtr src ,  System.IntPtr dst )
{
	bool isExc = NativeMethodsExc.calib3d_convertPointsFromHomogeneous_InputArray_excsafe(src, dst);

	if(isExc)
		handleException();
}


public static  void calib3d_convertPointsFromHomogeneous_array1([In] OpenCvSharp.Vec3f[] src , [In, Out] OpenCvSharp.Vec2f[] dst ,  System.Int32 length )
{
	bool isExc = NativeMethodsExc.calib3d_convertPointsFromHomogeneous_array1_excsafe(src, dst, length);

	if(isExc)
		handleException();
}


public static  void calib3d_convertPointsFromHomogeneous_array2([In] OpenCvSharp.Vec4f[] src , [In, Out] OpenCvSharp.Vec3f[] dst ,  System.Int32 length )
{
	bool isExc = NativeMethodsExc.calib3d_convertPointsFromHomogeneous_array2_excsafe(src, dst, length);

	if(isExc)
		handleException();
}


public static  void calib3d_convertPointsHomogeneous( System.IntPtr src ,  System.IntPtr dst )
{
	bool isExc = NativeMethodsExc.calib3d_convertPointsHomogeneous_excsafe(src, dst);

	if(isExc)
		handleException();
}


public static  System.IntPtr calib3d_findFundamentalMat_InputArray( System.IntPtr points1 ,  System.IntPtr points2 ,  System.Int32 method ,  System.Double param1 ,  System.Double param2 ,  System.IntPtr mask )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.calib3d_findFundamentalMat_InputArray_excsafe(ref ret, points1, points2, method, param1, param2, mask);

	if(isExc)
		handleException();
	return ret;
}


public static  System.IntPtr calib3d_findFundamentalMat_array( OpenCvSharp.Point2d[] points1 ,  System.Int32 points1Size ,  OpenCvSharp.Point2d[] points2 ,  System.Int32 points2Size ,  System.Int32 method ,  System.Double param1 ,  System.Double param2 ,  System.IntPtr mask )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.calib3d_findFundamentalMat_array_excsafe(ref ret, points1, points1Size, points2, points2Size, method, param1, param2, mask);

	if(isExc)
		handleException();
	return ret;
}


public static  void calib3d_computeCorrespondEpilines_InputArray( System.IntPtr points ,  System.Int32 whichImage ,  System.IntPtr F ,  System.IntPtr lines )
{
	bool isExc = NativeMethodsExc.calib3d_computeCorrespondEpilines_InputArray_excsafe(points, whichImage, F, lines);

	if(isExc)
		handleException();
}


public static  void calib3d_computeCorrespondEpilines_array2d([In] OpenCvSharp.Point2d[] points ,  System.Int32 pointsSize ,  System.Int32 whichImage ,  System.Double[,] F , [In, Out] OpenCvSharp.Point3f[] lines )
{
	bool isExc = NativeMethodsExc.calib3d_computeCorrespondEpilines_array2d_excsafe(points, pointsSize, whichImage, F, lines);

	if(isExc)
		handleException();
}


public static  void calib3d_computeCorrespondEpilines_array3d([In] OpenCvSharp.Point3d[] points ,  System.Int32 pointsSize ,  System.Int32 whichImage ,  System.Double[,] F , [In, Out] OpenCvSharp.Point3f[] lines )
{
	bool isExc = NativeMethodsExc.calib3d_computeCorrespondEpilines_array3d_excsafe(points, pointsSize, whichImage, F, lines);

	if(isExc)
		handleException();
}


public static  void calib3d_triangulatePoints_InputArray( System.IntPtr projMatr1 ,  System.IntPtr projMatr2 ,  System.IntPtr projPoints1 ,  System.IntPtr projPoints2 ,  System.IntPtr points4D )
{
	bool isExc = NativeMethodsExc.calib3d_triangulatePoints_InputArray_excsafe(projMatr1, projMatr2, projPoints1, projPoints2, points4D);

	if(isExc)
		handleException();
}


public static  void calib3d_triangulatePoints_array([In] System.Double[,] projMatr1 , [In] System.Double[,] projMatr2 , [In] OpenCvSharp.Point2d[] projPoints1 ,  System.Int32 projPoints1Size , [In] OpenCvSharp.Point2d[] projPoints2 ,  System.Int32 projPoints2Size , [In, Out] OpenCvSharp.Vec4d[] points4D )
{
	bool isExc = NativeMethodsExc.calib3d_triangulatePoints_array_excsafe(projMatr1, projMatr2, projPoints1, projPoints1Size, projPoints2, projPoints2Size, points4D);

	if(isExc)
		handleException();
}


public static  void calib3d_correctMatches_InputArray( System.IntPtr F ,  System.IntPtr points1 ,  System.IntPtr points2 ,  System.IntPtr newPoints1 ,  System.IntPtr newPoints2 )
{
	bool isExc = NativeMethodsExc.calib3d_correctMatches_InputArray_excsafe(F, points1, points2, newPoints1, newPoints2);

	if(isExc)
		handleException();
}


public static  void calib3d_Rodrigues( System.IntPtr src ,  System.IntPtr dst ,  System.IntPtr jacobian )
{
	bool isExc = NativeMethodsExc.calib3d_Rodrigues_excsafe(src, dst, jacobian);

	if(isExc)
		handleException();
}


public static  void calib3d_Rodrigues_VecToMat( System.IntPtr vector ,  System.IntPtr matrix ,  System.IntPtr jacobian )
{
	bool isExc = NativeMethodsExc.calib3d_Rodrigues_VecToMat_excsafe(vector, matrix, jacobian);

	if(isExc)
		handleException();
}


public static  void calib3d_Rodrigues_MatToVec( System.IntPtr vector ,  System.IntPtr matrix ,  System.IntPtr jacobian )
{
	bool isExc = NativeMethodsExc.calib3d_Rodrigues_MatToVec_excsafe(vector, matrix, jacobian);

	if(isExc)
		handleException();
}


public static  System.IntPtr calib3d_findHomography_InputArray( System.IntPtr srcPoints ,  System.IntPtr dstPoints ,  System.Int32 method ,  System.Double ransacReprojThreshold ,  System.IntPtr mask )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.calib3d_findHomography_InputArray_excsafe(ref ret, srcPoints, dstPoints, method, ransacReprojThreshold, mask);

	if(isExc)
		handleException();
	return ret;
}


public static  System.IntPtr calib3d_findHomography_vector( OpenCvSharp.Point2d[] srcPoints ,  System.Int32 srcPointsLength ,  OpenCvSharp.Point2d[] dstPoints ,  System.Int32 dstPointsLength ,  System.Int32 method ,  System.Double ransacReprojThreshold ,  System.IntPtr mask )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.calib3d_findHomography_vector_excsafe(ref ret, srcPoints, srcPointsLength, dstPoints, dstPointsLength, method, ransacReprojThreshold, mask);

	if(isExc)
		handleException();
	return ret;
}


public static  void calib3d_RQDecomp3x3_InputArray( System.IntPtr src ,  System.IntPtr mtxR ,  System.IntPtr mtxQ ,  System.IntPtr qx ,  System.IntPtr qy ,  System.IntPtr qz ,  out OpenCvSharp.Vec3d outVal )
{
	bool isExc = NativeMethodsExc.calib3d_RQDecomp3x3_InputArray_excsafe(src, mtxR, mtxQ, qx, qy, qz,  out outVal);

	if(isExc)
		handleException();
}


public static  void calib3d_RQDecomp3x3_Mat( System.IntPtr src ,  System.IntPtr mtxR ,  System.IntPtr mtxQ ,  System.IntPtr qx ,  System.IntPtr qy ,  System.IntPtr qz ,  out OpenCvSharp.Vec3d outVal )
{
	bool isExc = NativeMethodsExc.calib3d_RQDecomp3x3_Mat_excsafe(src, mtxR, mtxQ, qx, qy, qz,  out outVal);

	if(isExc)
		handleException();
}


public static  void calib3d_decomposeProjectionMatrix_InputArray( System.IntPtr projMatrix ,  System.IntPtr cameraMatrix ,  System.IntPtr rotMatrix ,  System.IntPtr transVect ,  System.IntPtr rotMatrixX ,  System.IntPtr rotMatrixY ,  System.IntPtr rotMatrixZ ,  System.IntPtr eulerAngles )
{
	bool isExc = NativeMethodsExc.calib3d_decomposeProjectionMatrix_InputArray_excsafe(projMatrix, cameraMatrix, rotMatrix, transVect, rotMatrixX, rotMatrixY, rotMatrixZ, eulerAngles);

	if(isExc)
		handleException();
}


public static  void calib3d_decomposeProjectionMatrix_Mat( System.IntPtr projMatrix ,  System.IntPtr cameraMatrix ,  System.IntPtr rotMatrix ,  System.IntPtr transVect ,  System.IntPtr rotMatrixX ,  System.IntPtr rotMatrixY ,  System.IntPtr rotMatrixZ ,  System.IntPtr eulerAngles )
{
	bool isExc = NativeMethodsExc.calib3d_decomposeProjectionMatrix_Mat_excsafe(projMatrix, cameraMatrix, rotMatrix, transVect, rotMatrixX, rotMatrixY, rotMatrixZ, eulerAngles);

	if(isExc)
		handleException();
}


public static  void calib3d_matMulDeriv( System.IntPtr a ,  System.IntPtr b ,  System.IntPtr dABdA ,  System.IntPtr dABdB )
{
	bool isExc = NativeMethodsExc.calib3d_matMulDeriv_excsafe(a, b, dABdA, dABdB);

	if(isExc)
		handleException();
}


public static  void calib3d_composeRT_InputArray( System.IntPtr rvec1 ,  System.IntPtr tvec1 ,  System.IntPtr rvec2 ,  System.IntPtr tvec2 ,  System.IntPtr rvec3 ,  System.IntPtr tvec3 ,  System.IntPtr dr3dr1 ,  System.IntPtr dr3dt1 ,  System.IntPtr dr3dr2 ,  System.IntPtr dr3dt2 ,  System.IntPtr dt3dr1 ,  System.IntPtr dt3dt1 ,  System.IntPtr dt3dr2 ,  System.IntPtr dt3dt2 )
{
	bool isExc = NativeMethodsExc.calib3d_composeRT_InputArray_excsafe(rvec1, tvec1, rvec2, tvec2, rvec3, tvec3, dr3dr1, dr3dt1, dr3dr2, dr3dt2, dt3dr1, dt3dt1, dt3dr2, dt3dt2);

	if(isExc)
		handleException();
}


public static  void calib3d_composeRT_Mat( System.IntPtr rvec1 ,  System.IntPtr tvec1 ,  System.IntPtr rvec2 ,  System.IntPtr tvec2 ,  System.IntPtr rvec3 ,  System.IntPtr tvec3 ,  System.IntPtr dr3dr1 ,  System.IntPtr dr3dt1 ,  System.IntPtr dr3dr2 ,  System.IntPtr dr3dt2 ,  System.IntPtr dt3dr1 ,  System.IntPtr dt3dt1 ,  System.IntPtr dt3dr2 ,  System.IntPtr dt3dt2 )
{
	bool isExc = NativeMethodsExc.calib3d_composeRT_Mat_excsafe(rvec1, tvec1, rvec2, tvec2, rvec3, tvec3, dr3dr1, dr3dt1, dr3dr2, dr3dt2, dt3dr1, dt3dt1, dt3dr2, dt3dt2);

	if(isExc)
		handleException();
}


public static  void calib3d_projectPoints_InputArray( System.IntPtr objectPoints ,  System.IntPtr rvec ,  System.IntPtr tvec ,  System.IntPtr cameraMatrix ,  System.IntPtr distCoeffs ,  System.IntPtr imagePoints ,  System.IntPtr jacobian ,  System.Double aspectRatio )
{
	bool isExc = NativeMethodsExc.calib3d_projectPoints_InputArray_excsafe(objectPoints, rvec, tvec, cameraMatrix, distCoeffs, imagePoints, jacobian, aspectRatio);

	if(isExc)
		handleException();
}


public static  void calib3d_projectPoints_Mat( System.IntPtr objectPoints ,  System.IntPtr rvec ,  System.IntPtr tvec ,  System.IntPtr cameraMatrix ,  System.IntPtr distCoeffs ,  System.IntPtr imagePoints ,  System.IntPtr jacobian ,  System.Double aspectRatio )
{
	bool isExc = NativeMethodsExc.calib3d_projectPoints_Mat_excsafe(objectPoints, rvec, tvec, cameraMatrix, distCoeffs, imagePoints, jacobian, aspectRatio);

	if(isExc)
		handleException();
}


public static  void calib3d_solvePnP_InputArray( System.IntPtr selfectPoints ,  System.IntPtr imagePoints ,  System.IntPtr cameraMatrix ,  System.IntPtr distCoeffs ,  System.IntPtr rvec ,  System.IntPtr tvec ,  System.Int32 useExtrinsicGuess ,  System.Int32 flags )
{
	bool isExc = NativeMethodsExc.calib3d_solvePnP_InputArray_excsafe(selfectPoints, imagePoints, cameraMatrix, distCoeffs, rvec, tvec, useExtrinsicGuess, flags);

	if(isExc)
		handleException();
}


public static  void calib3d_solvePnP_vector( OpenCvSharp.Point3f[] objectPoints ,  System.Int32 objectPointsLength ,  OpenCvSharp.Point2f[] imagePoints ,  System.Int32 imagePointsLength ,  System.Double[,] cameraMatrix ,  System.Double[] distCoeffs ,  System.Int32 distCoeffsLength , [Out] System.Double[] rvec , [Out] System.Double[] tvec ,  System.Int32 useExtrinsicGuess ,  System.Int32 flags )
{
	bool isExc = NativeMethodsExc.calib3d_solvePnP_vector_excsafe(objectPoints, objectPointsLength, imagePoints, imagePointsLength, cameraMatrix, distCoeffs, distCoeffsLength, rvec, tvec, useExtrinsicGuess, flags);

	if(isExc)
		handleException();
}


public static  void calib3d_solvePnPRansac_InputArray( System.IntPtr objectPoints ,  System.IntPtr imagePoints ,  System.IntPtr cameraMatrix ,  System.IntPtr distCoeffs ,  System.IntPtr rvec ,  System.IntPtr tvec ,  System.Int32 useExtrinsicGuess ,  System.Int32 iterationsCount ,  System.Single reprojectionError ,  System.Double confidence ,  System.IntPtr inliers ,  System.Int32 flags )
{
	bool isExc = NativeMethodsExc.calib3d_solvePnPRansac_InputArray_excsafe(objectPoints, imagePoints, cameraMatrix, distCoeffs, rvec, tvec, useExtrinsicGuess, iterationsCount, reprojectionError, confidence, inliers, flags);

	if(isExc)
		handleException();
}


public static  void calib3d_solvePnPRansac_vector( OpenCvSharp.Point3f[] objectPoints ,  System.Int32 objectPointsLength ,  OpenCvSharp.Point2f[] imagePoints ,  System.Int32 imagePointsLength ,  System.Double[,] cameraMatrix ,  System.Double[] distCoeffs ,  System.Int32 distCoeffsLength , [Out] System.Double[] rvec , [Out] System.Double[] tvec ,  System.Int32 useExtrinsicGuess ,  System.Int32 iterationsCount ,  System.Single reprojectionError ,  System.Double confidence ,  System.IntPtr inliers ,  System.Int32 flags )
{
	bool isExc = NativeMethodsExc.calib3d_solvePnPRansac_vector_excsafe(objectPoints, objectPointsLength, imagePoints, imagePointsLength, cameraMatrix, distCoeffs, distCoeffsLength, rvec, tvec, useExtrinsicGuess, iterationsCount, reprojectionError, confidence, inliers, flags);

	if(isExc)
		handleException();
}


public static  System.IntPtr calib3d_initCameraMatrix2D_Mat( System.IntPtr[] objectPoints ,  System.Int32 objectPointsLength ,  System.IntPtr[] imagePoints ,  System.Int32 imagePointsLength ,  OpenCvSharp.Size imageSize ,  System.Double aspectRatio )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.calib3d_initCameraMatrix2D_Mat_excsafe(ref ret, objectPoints, objectPointsLength, imagePoints, imagePointsLength, imageSize, aspectRatio);

	if(isExc)
		handleException();
	return ret;
}


public static  System.IntPtr calib3d_initCameraMatrix2D_array( System.IntPtr[] objectPoints ,  System.Int32 opSize1 ,  System.Int32[] opSize2 ,  System.IntPtr[] imagePoints ,  System.Int32 ipSize1 ,  System.Int32[] ipSize2 ,  OpenCvSharp.Size imageSize ,  System.Double aspectRatio )
{
	System.IntPtr ret = new System.IntPtr();
	bool isExc = NativeMethodsExc.calib3d_initCameraMatrix2D_array_excsafe(ref ret, objectPoints, opSize1, opSize2, imagePoints, ipSize1, ipSize2, imageSize, aspectRatio);

	if(isExc)
		handleException();
	return ret;
}


public static  System.Int32 calib3d_findChessboardCorners_InputArray( System.IntPtr image ,  OpenCvSharp.Size patternSize ,  System.IntPtr corners ,  System.Int32 flags )
{
	System.Int32 ret = new System.Int32();
	bool isExc = NativeMethodsExc.calib3d_findChessboardCorners_InputArray_excsafe(ref ret, image, patternSize, corners, flags);

	if(isExc)
		handleException();
	return ret;
}


public static  System.Int32 calib3d_findChessboardCorners_vector( System.IntPtr image ,  OpenCvSharp.Size patternSize ,  System.IntPtr corners ,  System.Int32 flags )
{
	System.Int32 ret = new System.Int32();
	bool isExc = NativeMethodsExc.calib3d_findChessboardCorners_vector_excsafe(ref ret, image, patternSize, corners, flags);

	if(isExc)
		handleException();
	return ret;
}


public static  System.Int32 calib3d_find4QuadCornerSubpix_InputArray( System.IntPtr img ,  System.IntPtr corners ,  OpenCvSharp.Size regionSize )
{
	System.Int32 ret = new System.Int32();
	bool isExc = NativeMethodsExc.calib3d_find4QuadCornerSubpix_InputArray_excsafe(ref ret, img, corners, regionSize);

	if(isExc)
		handleException();
	return ret;
}


public static  System.Int32 calib3d_find4QuadCornerSubpix_vector( System.IntPtr img ,  System.IntPtr corners ,  OpenCvSharp.Size regionSize )
{
	System.Int32 ret = new System.Int32();
	bool isExc = NativeMethodsExc.calib3d_find4QuadCornerSubpix_vector_excsafe(ref ret, img, corners, regionSize);

	if(isExc)
		handleException();
	return ret;
}


public static  void calib3d_drawChessboardCorners_InputArray( System.IntPtr image ,  OpenCvSharp.Size patternSize ,  System.IntPtr corners ,  System.Int32 patternWasFound )
{
	bool isExc = NativeMethodsExc.calib3d_drawChessboardCorners_InputArray_excsafe(image, patternSize, corners, patternWasFound);

	if(isExc)
		handleException();
}


public static  void calib3d_drawChessboardCorners_array( System.IntPtr image ,  OpenCvSharp.Size patternSize ,  OpenCvSharp.Point2f[] corners ,  System.Int32 cornersLength ,  System.Int32 patternWasFound )
{
	bool isExc = NativeMethodsExc.calib3d_drawChessboardCorners_array_excsafe(image, patternSize, corners, cornersLength, patternWasFound);

	if(isExc)
		handleException();
}


public static  System.Int32 calib3d_findCirclesGrid_InputArray( System.IntPtr image ,  OpenCvSharp.Size patternSize ,  System.IntPtr centers ,  System.Int32 flags ,  System.IntPtr blobDetector )
{
	System.Int32 ret = new System.Int32();
	bool isExc = NativeMethodsExc.calib3d_findCirclesGrid_InputArray_excsafe(ref ret, image, patternSize, centers, flags, blobDetector);

	if(isExc)
		handleException();
	return ret;
}


public static  System.Int32 calib3d_findCirclesGrid_vector( System.IntPtr image ,  OpenCvSharp.Size patternSize ,  System.IntPtr centers ,  System.Int32 flags ,  System.IntPtr blobDetector )
{
	System.Int32 ret = new System.Int32();
	bool isExc = NativeMethodsExc.calib3d_findCirclesGrid_vector_excsafe(ref ret, image, patternSize, centers, flags, blobDetector);

	if(isExc)
		handleException();
	return ret;
}



}
}