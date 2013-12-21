/*
 * (C) 2008-2013 Schima
 * This code is licenced under the LGPL.
 */

#ifndef _CVNORMALBAYESCLASSIFIER_H_
#define _CVNORMALBAYESCLASSIFIER_H_

#ifdef _MSC_VER
#pragma warning(disable: 4251)
#endif
#include <opencv2/ml/ml.hpp>

CVAPI(int) CvNormalBayesClassifier_sizeof()
{
	return sizeof(CvNormalBayesClassifier);
}


CVAPI(CvNormalBayesClassifier*) CvNormalBayesClassifier_construct_default()
{
	return new CvNormalBayesClassifier();
}
CVAPI(CvNormalBayesClassifier*) CvNormalBayesClassifier_construct_training( const CvMat* _train_data, const CvMat* _responses, const CvMat* _var_idx, const CvMat* _sample_idx )
{
	return new CvNormalBayesClassifier(_train_data, _responses, _var_idx, _sample_idx);
}
CVAPI(void) CvNormalBayesClassifier_destruct(CvNormalBayesClassifier* obj)
{
	delete obj;
}


CVAPI(bool) CvNormalBayesClassifier_train(CvNormalBayesClassifier* obj, const CvMat* _train_data, const CvMat* _responses, const CvMat* _var_idx, const CvMat* _sample_idx, bool update )
{
	return obj->train(_train_data, _responses, _var_idx, _sample_idx, update);
}
CVAPI(float) CvNormalBayesClassifier_predict(CvNormalBayesClassifier* obj, const CvMat* _samples, CvMat* results )
{
	return obj->predict(_samples, results);
}


CVAPI(void) CvNormalBayesClassifier_clear( CvNormalBayesClassifier* obj )
{
	obj->clear();
}
CVAPI(void) CvNormalBayesClassifier_write( CvNormalBayesClassifier* obj, CvFileStorage* storage, const char* name )
{
	obj->write(storage, name);
}
CVAPI(void) CvNormalBayesClassifier_read( CvNormalBayesClassifier* obj, CvFileStorage* storage, CvFileNode* node )
{
	obj->read(storage, node);
}

#endif
