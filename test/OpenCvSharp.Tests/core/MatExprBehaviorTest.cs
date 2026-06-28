using OpenCvSharp.Tests;
using Xunit;

namespace OpenCvSharp.Tests.Core;

/// <summary>
/// Behavioral tests for the lazy <see cref="MatExpr"/> (issue #1974): laziness, the
/// <see cref="InputArray"/> materialization path, error handling, operator/method equivalence,
/// and the factory matrices. Numeric correctness of each operator lives in
/// <see cref="MatExprParityTest"/>.
/// </summary>
public class MatExprBehaviorTest : TestBase
{
    private static void AssertSame(Mat expected, Mat actual, double eps = 1e-4)
    {
        Assert.Equal(expected.Rows, actual.Rows);
        Assert.Equal(expected.Cols, actual.Cols);
        Assert.Equal(expected.Type(), actual.Type());
        var maxDiff = Cv2.Norm(expected, actual, NormTypes.INF);
        Assert.True(maxDiff <= eps, $"max abs diff = {maxDiff} (eps = {eps})");
    }

    private static Mat Float3x3(params float[] values)
    {
        var m = new Mat(3, 3, MatType.CV_32FC1);
        m.SetArray(values);
        return m;
    }

    private static Mat A() => Float3x3(1, 2, 3, 4, 5, 6, 7, 8, 9);
    private static Mat B() => Float3x3(9, 8, 7, 6, 5, 4, 3, 2, 1);
    private static Mat C() => Float3x3(2, 0, 1, 1, 3, 2, 0, 1, 4);

    // ---- laziness ----

    [Fact]
    public void OperatorsAreLazy_ReflectLaterMutationOfSource()
    {
        using var src = Float3x3(1, 2, 3, 4, 5, 6, 7, 8, 9);

        // Build the expression but do NOT materialize it yet.
        var expr = src + new Scalar(1);

        // Mutate the source AFTER building the expression. An eager implementation would have
        // already captured {1..9}; a lazy one sees the mutated values at materialization time.
        src.SetArray(10f, 20f, 30f, 40f, 50f, 60f, 70f, 80f, 90f);

        using Mat actual = expr;
        using var expected = Float3x3(11, 21, 31, 41, 51, 61, 71, 81, 91);
        AssertSame(expected, actual, 0);
    }

    [Fact]
    public void SizeMismatchThrowsOnlyWhenMaterialized()
    {
        using var a = A();                                          // 3x3
        using var b = new Mat(2, 2, MatType.CV_32FC1, new Scalar(1));

        // Building the (invalid) expression must NOT throw — nothing is evaluated yet.
        var expr = a + b;

        // The native error surfaces only at materialization.
        Assert.Throws<OpenCVException>(() => { using Mat r = expr; });
    }

    // ---- InputArray materialization path ----

    [Fact]
    public void ExpressionPassedDirectlyToCv2Method()
    {
        using var a = A();
        using var b = B();
        using var c = C();

        // (a + b) is a MatExpr; it converts to InputArray, which owns and disposes the
        // materialized temporary Mat.
        using var dst = new Mat();
        Cv2.Add(a + b, c, dst);

        using var tmp = new Mat();
        Cv2.Add(a, b, tmp);
        using var expected = new Mat();
        Cv2.Add(tmp, c, expected);

        AssertSame(expected, dst, 0);
    }

    [Fact]
    public void ExpressionAsInputArrayRepeatedlyIsStable()
    {
        using var a = A();
        using var b = B();

        // Exercise the InputArray-from-expression path many times; each call materializes and
        // disposes its own temporary without error.
        for (var i = 0; i < 200; i++)
        {
            using var dst = new Mat();
            Cv2.Add(a + b, a - b, dst);
        }
    }

    // ---- error handling ----

    [Fact]
    public void FromNullThrows()
    {
        Assert.Throws<ArgumentNullException>(() => MatExpr.From(null!));
    }

    [Fact]
    public void NullMatOperandThrows()
    {
        using var a = A();
        var expr = a + new Scalar(0);

        Assert.Throws<ArgumentNullException>(() => { _ = expr + (Mat)null!; });
    }

    // ---- operator / method equivalence ----

    [Fact]
    public void InstanceMethodsMatchOperators()
    {
        using var a = A();
        using var b = B();

        using Mat addOp = a + b;
        using Mat addM = a.Add(b);
        AssertSame(addOp, addM, 0);

        using Mat subOp = a - new Scalar(1);
        using Mat subM = a.Subtract(new Scalar(1));
        AssertSame(subOp, subM, 0);

        using Mat mulOp = a * 2.0;
        using Mat mulM = a.Multiply(2.0);
        AssertSame(mulOp, mulM, 0);

        using Mat negOp = -a;
        using Mat negM = a.Negate();
        AssertSame(negOp, negM, 0);
    }

    // ---- mixed Mat / expression operands and symmetry ----

    [Fact]
    public void MixedMatAndExpressionOperands()
    {
        using var a = A();
        using var b = B();
        using var c = C();

        // a + (b * c): Mat + (matrix-multiply expression), exercising operator +(Mat, MatExpr).
        using Mat actual = a + b * c;

        using var bc = new Mat();
        using var src3 = new Mat();
        Cv2.Gemm(b, c, 1, src3, 0, bc);
        using var expected = new Mat();
        Cv2.Add(a, bc, expected);

        AssertSame(expected, actual);
    }

    [Fact]
    public void ScalarAndDoubleOperandSymmetry()
    {
        using var a = A();

        using Mat scalarLeft = new Scalar(5) + a;
        using Mat scalarRight = a + new Scalar(5);
        AssertSame(scalarLeft, scalarRight, 0);

        using Mat doubleLeft = 2.0 * a;
        using Mat doubleRight = a * 2.0;
        AssertSame(doubleLeft, doubleRight, 0);
    }

    // ---- factory matrices ----

    [Fact]
    public void ZerosOnesEyeProduceExpectedValues()
    {
        using Mat zeros = Mat.Zeros(2, 3, MatType.CV_32FC1);
        Assert.Equal(0, Cv2.CountNonZero(zeros));

        using Mat ones = Mat.Ones(2, 3, MatType.CV_32FC1);
        Assert.Equal(6, Cv2.CountNonZero(ones));
        Assert.Equal(1, (int)ones.Get<float>(1, 2));

        using Mat eye = Mat.Eye(3, 3, MatType.CV_32FC1);
        Assert.Equal(3, Cv2.CountNonZero(eye)); // only the diagonal is non-zero
        Assert.Equal(1, (int)eye.Get<float>(0, 0));
        Assert.Equal(0, (int)eye.Get<float>(0, 1));
    }

    [Fact]
    public void FactoryMatricesAreLazyButConvertToMat()
    {
        // Mat.Eye returns a MatExpr; it can be reused and materialized independently.
        var eye = Mat.Eye(2, 2, MatType.CV_32FC1);
        using Mat first = eye;
        using Mat second = eye * 3.0;

        Assert.Equal(2, Cv2.CountNonZero(first));
        using var expected = Float2x2Diag(3f);
        AssertSame(expected, second, 0);
    }

    private static Mat Float2x2Diag(float v)
    {
        var m = new Mat(2, 2, MatType.CV_32FC1);
        m.SetArray(v, 0f, 0f, v);
        return m;
    }
}
