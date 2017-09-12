using System;

namespace OpenCvSharp.ML
{
    /// <summary>
    /// The structure represents the logarithmic grid range of statmodel parameters.
    /// </summary>
    public struct ParamGrid
    {
        /// <summary>
        /// Minimum value of the statmodel parameter. Default value is 0.
        /// </summary>
        public double MinVal;

        /// <summary>
        /// Maximum value of the statmodel parameter. Default value is 0.
        /// </summary>
        public double MaxVal;

        /// <summary>
        /// Logarithmic step for iterating the statmodel parameter.
        /// </summary>
        /// <remarks>
        /// The grid determines the following iteration sequence of the statmodel parameter values:
        /// \f[(minVal, minVal*step, minVal*{step}^2, \dots,  minVal*{logStep}^n),\f]
        /// where \f$n\f$ is the maximal index satisfying
        /// \f[\texttt{minVal} * \texttt{logStep} ^n &lt; \texttt{maxVal}\f]
        /// The grid is logarithmic, so logStep must always be greater then 1. Default value is 1.
        /// </remarks>
        public double LogStep;

        /// <summary>
        /// Constructor with parameters
        /// </summary>
        /// <param name="minVal"></param>
        /// <param name="maxVal"></param>
        /// <param name="logStep"></param>
        public ParamGrid(double minVal, double maxVal, double logStep)
        {
            MinVal = minVal;
            MaxVal = maxVal;
            LogStep = logStep;
        }
    }
}
