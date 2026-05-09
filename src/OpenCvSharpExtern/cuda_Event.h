#pragma once

// -----------------------------------------------------------------------
// OpenCvSharpExtern – cv::cuda arithmetic wrappers
// These are the C-linkage functions that the C# P/Invoke layer calls.
// Each function catches cv::Exception, stores it, and returns an
// ExceptionStatus so managed code can rethrow it as a .NET exception.
// -----------------------------------------------------------------------

#include "include_opencv.h"

CVAPI(ExceptionStatus) cuda_Event_new1(cv::cuda::Event **returnValue)
{
    BEGIN_WRAP
    *returnValue = new cv::cuda::Event();
    END_WRAP
}

CVAPI(ExceptionStatus) cuda_Event_new2(int flags, cv::cuda::Event **returnValue)
{
    BEGIN_WRAP
    *returnValue = new cv::cuda::Event(static_cast<cv::cuda::Event::CreateFlags>(flags));
    END_WRAP
}

CVAPI(ExceptionStatus) cuda_Event_delete(cv::cuda::Event *obj)
{
    BEGIN_WRAP
    delete obj;
    END_WRAP
}

CVAPI(ExceptionStatus) cuda_Event_record(cv::cuda::Event *obj, cv::cuda::Stream *stream)
{
    BEGIN_WRAP
    cv::cuda::Stream &streamRef = stream ? *stream : cv::cuda::Stream::Null();
    obj->record(streamRef);
    END_WRAP
}

CVAPI(ExceptionStatus) cuda_Event_queryIfComplete(cv::cuda::Event *obj, int *returnValue)
{
    BEGIN_WRAP
    *returnValue = obj->queryIfComplete() ? 1 : 0;
    END_WRAP
}

CVAPI(ExceptionStatus) cuda_Event_waitForCompletion(cv::cuda::Event *obj)
{
    BEGIN_WRAP
    obj->waitForCompletion();
    END_WRAP
}
CVAPI(ExceptionStatus) cuda_Event_elapsedTime(cv::cuda::Event *start, cv::cuda::Event *end, float *returnValue)
{
    BEGIN_WRAP
    *returnValue = cv::cuda::Event::elapsedTime(*start, *end);
    END_WRAP
}
