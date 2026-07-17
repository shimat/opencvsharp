#pragma once

#ifndef NO_CONTRIB

// ReSharper disable IdentifierTypo
// ReSharper disable CppInconsistentNaming
// ReSharper disable CppNonInlineFunctionDefinitionInHeaderFile

#include "include_opencv.h"

CVAPI(ExceptionStatus) signal_resampleSignal(
    const interop::InputArrayProxy* inputSignal,
    const interop::OutputArrayProxy* outSignal,
    int inFreq, int outFreq)
{
    return cvTry([&] {
        cv::signal::resampleSignal(InProxy(*inputSignal), OutProxy(*outSignal), inFreq, outFreq);
    });
}

#endif // NO_CONTRIB
