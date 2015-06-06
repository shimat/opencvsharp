using System;
using System.Collections.Generic;
using System.Text;

namespace OpenCvSharp
{
    /// <summary>
    /// 
    /// </summary>
    public struct TermCriteria
    {
        /// <summary>
        /// the type of termination criteria: COUNT, EPS or COUNT + EPS
        /// </summary>
        public CriteriaType Type;

        /// <summary>
        /// the maximum number of iterations/elements
        /// </summary>
        public int MaxCount;

        /// <summary>
        /// the desired accuracy
        /// </summary>
        public double Epsilon;

        /// <summary>
        /// full constructor
        /// </summary>
        /// <param name="type"></param>
        /// <param name="maxCount"></param>
        /// <param name="epsilon"></param>
        public TermCriteria(CriteriaType type, int maxCount, double epsilon)
        {
            Type = type;
            MaxCount = maxCount;
            Epsilon = epsilon;
        }

        /// <summary>
        /// full constructor with both type (count | epsilon)
        /// </summary>
        /// <param name="maxCount"></param>
        /// <param name="epsilon"></param>
        public static TermCriteria Both(int maxCount, double epsilon)
        {
            return new TermCriteria
            {
                Type = CriteriaType.Iteration | CriteriaType.Epsilon,
                MaxCount = maxCount,
                Epsilon = epsilon,
            };
        }
    }
}
