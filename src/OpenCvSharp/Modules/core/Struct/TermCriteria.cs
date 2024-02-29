#pragma warning disable CA1051

namespace OpenCvSharp;

/// <summary>
/// The class defining termination criteria for iterative algorithms.
/// </summary>
public readonly record struct TermCriteria(CriteriaTypes Type, int MaxCount, double Epsilon)
{
    /// <summary>
    /// the type of termination criteria: COUNT, EPS or COUNT + EPS
    /// </summary>
    public readonly CriteriaTypes Type = Type;

    /// <summary>
    /// the maximum number of iterations/elements
    /// </summary>
    public readonly int MaxCount = MaxCount;

    /// <summary>
    /// the desired accuracy
    /// </summary>
    public readonly double Epsilon = Epsilon;

    /// <summary>
    /// full constructor with both type (count | epsilon)
    /// </summary>
    /// <param name="maxCount"></param>
    /// <param name="epsilon"></param>
    public static TermCriteria Both(int maxCount, double epsilon)
    {
        return new (
            Type: CriteriaTypes.Count | CriteriaTypes.Eps,
            MaxCount: maxCount,
            Epsilon: epsilon);
    }
}
