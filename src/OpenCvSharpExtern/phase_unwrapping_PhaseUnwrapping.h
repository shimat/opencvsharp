#pragma once

#ifndef NO_CONTRIB

// ReSharper disable IdentifierTypo
// ReSharper disable CppInconsistentNaming
// ReSharper disable CppNonInlineFunctionDefinitionInHeaderFile

#include "include_opencv.h"

// Note: no Ptr_PhaseUnwrapping_delete/get here - PhaseUnwrapping is an abstract base with a single
// concrete subclass (HistogramPhaseUnwrapping) and no factory in this API returns a bare
// cv::Ptr<PhaseUnwrapping>, so only the virtual method shared by subclasses is bound here.

CVAPI(ExceptionStatus) phase_unwrapping_PhaseUnwrapping_unwrapPhaseMap(
    cv::phase_unwrapping::PhaseUnwrapping* obj,
    const interop::InputArrayProxy* wrappedPhaseMap,
    const interop::OutputArrayProxy* unwrappedPhaseMap,
    const interop::InputArrayProxy* shadowMask)
{
    return cvTry([&] {
        obj->unwrapPhaseMap(InProxy(*wrappedPhaseMap), OutProxy(*unwrappedPhaseMap), InProxy(*shadowMask));
    });
}

#endif // NO_CONTRIB
