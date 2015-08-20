#ifndef _CPP_CORE_PCA_H_
#define _CPP_CORE_PCA_H_

#include "include_opencv.h"

CVAPI(cv::PCA*) core_PCA_new1()
{
	return new cv::PCA;
}
CVAPI(cv::PCA*) core_PCA_new2(cv::_InputArray *data, cv::_InputArray *mean, int flags, int maxComponents)
{
	return new cv::PCA(*data, *mean, flags, maxComponents);
}
CVAPI(cv::PCA*) core_PCA_new3(cv::_InputArray *data, cv::_InputArray *mean, int flags, double retainedVariance)
{
	return new cv::PCA(*data, *mean, flags, retainedVariance);
}
CVAPI(void) core_PCA_delete(cv::PCA *obj)
{
	delete obj;
}

//! operator that performs PCA. The previously stored data, if any, is released
CVAPI(void) core_PCA_operatorThis(cv::PCA *obj, cv::_InputArray *data, cv::_InputArray *mean, int flags, int maxComponents)
{
	(*obj)(*data, *mean, flags, maxComponents);
}
CVAPI(void) core_PCA_computeVar(cv::PCA *obj, cv::_InputArray *data, cv::_InputArray *mean, int flags, double retainedVariance)
{
	obj->computeVar(*data, *mean, flags, retainedVariance);
}
//! projects vector from the original space to the principal components subspace
CVAPI(cv::Mat*) core_PCA_project1(cv::PCA *obj, cv::_InputArray *vec)
{
	cv::Mat ret = obj->project(*vec);
	return new cv::Mat(ret);
}
//! projects vector from the original space to the principal components subspace
CVAPI(void) core_PCA_project2(cv::PCA *obj, cv::_InputArray *vec, cv::_OutputArray *result)
{
	obj->project(*vec, *result);
}
//! reconstructs the original vector from the projection
CVAPI(cv::Mat*) core_PCA_backProject1(cv::PCA *obj, cv::_InputArray *vec)
{
	cv::Mat ret = obj->backProject(*vec);
	return new cv::Mat(ret);
}
//! reconstructs the original vector from the projection
CVAPI(void) core_PCA_backProject2(cv::PCA *obj, cv::_InputArray *vec, cv::_OutputArray *result)
{
	obj->backProject(*vec, *result);
}

//!< eigenvectors of the covariation matrix
CVAPI(cv::Mat*) core_PCA_eigenvectors(cv::PCA *obj)
{
	return new cv::Mat(obj->eigenvectors);
}
//!< eigenvalues of the covariation matrix
CVAPI(cv::Mat*) core_PCA_eigenvalues(cv::PCA *obj)
{
	return new cv::Mat(obj->eigenvalues);
}
//!< mean value subtracted before the projection and added after the back projection
CVAPI(cv::Mat*) core_PCA_mean(cv::PCA *obj)
{
	return new cv::Mat(obj->mean);
}

#endif