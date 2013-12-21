using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

#pragma warning disable 1591

namespace OpenCvSharp
{
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    internal unsafe struct WCvKalman
    {
        public int MP;
        public int DP;
        public int CP;

        /* backward compatibility fields */
#if true
        public float* PosterState;
        public float* PriorState;
        public float* DynamMatr;
        public float* MeasurementMatr;
        public float* MNCovariance;
        public float* PNCovariance;
        public float* KalmGainMatr;
        public float* PriorErrorCovariance;
        public float* PosterErrorCovariance;
        public float* Temp1;
        public float* Temp2;
#endif

        public void* state_pre;
        public void* state_post;
        public void* transition_matrix;
        public void* control_matrix;
        public void* measurement_matrix;
        public void* process_noise_cov;
        public void* measurement_noise_cov;
        public void* error_cov_pre;
        public void* gain;
        public void* error_cov_post;

        /* temporary matrices */
        public void* temp1;
        public void* temp2;
        public void* temp3;
        public void* temp4;
        public void* temp5;
    }
}
