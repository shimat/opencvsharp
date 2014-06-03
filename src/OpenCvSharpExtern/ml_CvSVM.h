#ifndef _CPP_ML_CVSVM_H_
#define _CPP_ML_CVSVM_H_

#include "include_opencv.h"


CVAPI(void) ml_CvSVMParams_new1(CvSVMParams *result)
{
    *result = CvSVMParams();
}
CVAPI(void) ml_CvSVMParams_new2(
    CvSVMParams *result, int svmType, int kernelType, double degree, double gamma,
    double coef0, double C, double nu, double p, CvMat *classWeights, 
    CvTermCriteria termCrit )
{
    *result = CvSVMParams(svmType, kernelType, degree, gamma, coef0, C, nu, p,
        classWeights, termCrit);
}



CVAPI(CvSVM*) ml_CvSVM_new1()
{
	return new CvSVM();
}
CVAPI(CvSVM*) ml_CvSVM_new2_CvMat(
    CvMat *trainData, CvMat *responses, CvMat *varIdx, CvMat *sampleIdx, CvSVMParams params)
{
    return new CvSVM(trainData, responses, varIdx, sampleIdx, params);
}
CVAPI(CvSVM*) ml_CvSVM_new2_Mat(
    cv::Mat *trainData, cv::Mat *responses, cv::Mat *varIdx, cv::Mat *sampleIdx, CvSVMParams params)
{
    return new CvSVM(*trainData, *responses, entity(varIdx), entity(sampleIdx), params);
}
CVAPI(void) ml_CvSVM_delete(CvSVM *model)
{
	delete model;
}


CVAPI(void) ml_CvSVM_get_default_grid(CvParamGrid *grid, int paramId)
{
    *grid = CvSVM::get_default_grid(paramId);
}
CVAPI(int) ml_CvParamGrid_check(CvParamGrid grid)
{
	return grid.check();
}


CVAPI(int) ml_CvSVM_train_CvMat(
    CvSVM *model, CvMat *trainData, CvMat *responses, CvMat *varIdx, 
    CvMat *sampleIdx, CvSVMParams params)
{
    return model->train(trainData, responses, varIdx, sampleIdx, params) ? 1 : 0;
}
CVAPI(int) ml_CvSVM_train_Mat(
    cv::SVM *model, cv::Mat *trainData, cv::Mat *responses, cv::Mat *varIdx,
    cv::Mat *sampleIdx, CvSVMParams params)
{
    return model->train(*trainData, *responses, entity(varIdx), entity(sampleIdx), params) ? 1 : 0;
}

CVAPI(int) ml_CvSVM_train_auto_CvMat(
    CvSVM *model, CvMat *trainData, CvMat *responses, CvMat *varIdx, 
    CvMat *sampleIdx, CvSVMParams params, int kFold, 
    CvParamGrid cGrid, CvParamGrid gammaGrid, CvParamGrid pGrid, CvParamGrid nuGrid, 
    CvParamGrid coefGrid, CvParamGrid degreeGrid, int balanced)
{
    return model->train_auto(trainData, responses, varIdx, sampleIdx, params, kFold, 
        cGrid, gammaGrid, pGrid, nuGrid, coefGrid, degreeGrid, balanced != 0) ? 1 : 0;
}
CVAPI(int) ml_CvSVM_train_auto_Mat(
    CvSVM *model, cv::Mat *trainData, cv::Mat *responses, cv::Mat *varIdx,
    cv::Mat *sampleIdx, CvSVMParams params, int kFold,
    CvParamGrid cGrid, CvParamGrid gammaGrid, CvParamGrid pGrid, CvParamGrid nuGrid,
    CvParamGrid coefGrid, CvParamGrid degreeGrid, int balanced)
{
    return model->train_auto(*trainData, *responses, *varIdx, *sampleIdx, params, kFold,
        cGrid, gammaGrid, pGrid, nuGrid, coefGrid, degreeGrid, balanced != 0) ? 1 : 0;
}

CVAPI(float) ml_CvSVM_predict_CvMat1(CvSVM *model, CvMat *sample, int returnDFVal)
{
    return model->predict(sample, returnDFVal != 0);
}
CVAPI(float) ml_CvSVM_predict_CvMat2(CvSVM *model, CvMat *sample, CvMat *results)
{
    return model->predict(sample, results);
}
CVAPI(float) ml_CvSVM_predict_Mat1(CvSVM *model, cv::Mat *sample, int returnDFVal)
{
    return model->predict(*sample, returnDFVal != 0);
}
CVAPI(void) ml_CvSVM_predict_Mat2(CvSVM *model, cv::_InputArray *samples, cv::_OutputArray *results)
{
    model->predict(*samples, *results);
}

CVAPI(const float*) ml_CvSVM_get_support_vector(CvSVM *model, int i)
{
	return model->get_support_vector(i);
}
CVAPI(int) ml_CvSVM_get_support_vector_count(CvSVM *model)
{
	return model->get_support_vector_count();
}
CVAPI(int) ml_CvSVM_get_var_count(CvSVM *model)
{
	return model->get_var_count();
}
CVAPI(void) ml_CvSVM_get_params(CvSVM *model, CvSVMParams* p)
{ 
	*p = model->get_params(); 
}


CVAPI(void) ml_CvSVM_clear(CvSVM *model)
{
	model->clear();
}
CVAPI(void) ml_CvSVM_write(CvSVM *model, CvFileStorage* storage, const char* name)
{
	model->write(storage, name);
}
CVAPI(void) ml_CvSVM_read(CvSVM *model, CvFileStorage* storage, CvFileNode* node)
{
	model->read(storage, node);
}

#endif
