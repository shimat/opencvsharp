#pragma warning disable CA1051

namespace OpenCvSharp
{
    /// <summary>
    /// The class defining termination criteria for iterative algorithms.
    /// </summary>
    public readonly struct TermCriteria
    {
        /// <summary>
        /// the type of termination criteria: COUNT, EPS or COUNT + EPS
        /// </summary>
        public readonly CriteriaType Type;

        /// <summary>
        /// the maximum number of iterations/elements
        /// </summary>
        public readonly int MaxCount;

        /// <summary>
        /// the desired accuracy
        /// </summary>
        public readonly double Epsilon;

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
            return new TermCriteria(
                type: CriteriaType.Count | CriteriaType.Eps,
                maxCount: maxCount,
                epsilon: epsilon);
        }
    }
}
