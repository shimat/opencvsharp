#pragma once

#ifndef NO_DNN

#ifndef _WINRT_DLL

// ReSharper disable IdentifierTypo
// ReSharper disable CppInconsistentNaming
// ReSharper disable CppNonInlineFunctionDefinitionInHeaderFile

#include "include_opencv.h"

CVAPI(ExceptionStatus) dnn_Tokenizer_load(const char *modelConfig, cv::dnn::Tokenizer **returnValue)
{
    BEGIN_WRAP
    *returnValue = new cv::dnn::Tokenizer(cv::dnn::Tokenizer::load(std::string(modelConfig)));
    END_WRAP
}

CVAPI(ExceptionStatus) dnn_Tokenizer_delete(cv::dnn::Tokenizer *obj)
{
    BEGIN_WRAP
    delete obj;
    END_WRAP
}

CVAPI(ExceptionStatus) dnn_Tokenizer_encode(cv::dnn::Tokenizer *obj, const char *text, std::vector<int> *returnValue)
{
    BEGIN_WRAP
    *returnValue = obj->encode(std::string(text));
    END_WRAP
}

CVAPI(ExceptionStatus) dnn_Tokenizer_decode(cv::dnn::Tokenizer *obj, int *tokens, int tokensLength, std::string *returnValue)
{
    BEGIN_WRAP
    const std::vector<int> v(tokens, tokens + tokensLength);
    returnValue->assign(obj->decode(v));
    END_WRAP
}

#endif // !_WINRT_DLL

#endif // NO_DNN
