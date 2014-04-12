using System;
using System.Collections.Generic;
using System.Text;

namespace OpenCvSharp.CPlusPlus
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

        /// <summary>
        /// conversion from CvTermCriteria
        /// </summary>
        /// <param name="criteria"></param>
        public TermCriteria(CvTermCriteria criteria)
        {
            Type = criteria.Type;
            MaxCount = criteria.MaxIter;
            Epsilon = criteria.Epsilon;
        }

        /// <summary>
        /// conversion to CvTermCriteria
        /// </summary>
        /// <param name="self"></param>
        /// <returns></returns>
        public static implicit operator CvTermCriteria(TermCriteria self)
        {
            return new CvTermCriteria(self.Type, self.MaxCount, self.Epsilon);
        }
        /// <summary>
        /// conversion to CvTermCriteria
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        public static implicit operator TermCriteria(CvTermCriteria criteria)
        {
            return new TermCriteria(criteria);
        }

    }
}
