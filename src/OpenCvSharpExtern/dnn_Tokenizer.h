#pragma once

#ifndef NO_DNN

#ifndef _WINRT_DLL

// ReSharper disable IdentifierTypo
// ReSharper disable CppInconsistentNaming
// ReSharper disable CppNonInlineFunctionDefinitionInHeaderFile

#include "include_opencv.h"

CVAPI(ExceptionStatus) dnn_Tokenizer_load(const char *modelConfig, cv::dnn::Tokenizer **returnValue)
{
    return cvTry([&] {
        *returnValue = new cv::dnn::Tokenizer(cv::dnn::Tokenizer::load(std::string(modelConfig)));
    });
}

CVAPI(ExceptionStatus) dnn_Tokenizer_delete(cv::dnn::Tokenizer *obj)
{
    return cvTry([&] {
        delete obj;
    });
}

CVAPI(ExceptionStatus) dnn_Tokenizer_encode(cv::dnn::Tokenizer *obj, const char *text, std::vector<int> *returnValue)
{
    return cvTry([&] {
        *returnValue = obj->encode(std::string(text));
    });
}

CVAPI(ExceptionStatus) dnn_Tokenizer_decode(cv::dnn::Tokenizer *obj, int *tokens, int tokensLength, std::string *returnValue)
{
    return cvTry([&] {
        const std::vector<int> v(tokens, tokens + tokensLength);
        returnValue->assign(obj->decode(v));
    });
}

#endif // !_WINRT_DLL

#endif // NO_DNN
