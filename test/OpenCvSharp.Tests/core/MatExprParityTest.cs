using OpenCvSharp.Tests;
using Xunit;

namespace OpenCvSharp.Tests.Core;

/// <summary>
/// Numeric-parity tests for the lazy expression tree behind <see cref="Mat"/>'s operators
/// (issue #1974). Each case is written the way a user would actually write it — the operators
/// produce a lazy node that converts straight to <see cref="Mat"/>, so <c>MatExpr</c> never
/// has to appear in user code — and the result is checked against an independent oracle computed
/// with the eager <c>Cv2.*</c> functions (a different native path).
/// </summary>
public class MatExprParityTest : TestBase
{
    /// <summary>Asserts two matrices have the same shape/type and differ by at most <paramref name="eps"/>.</summary>
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
    private static Mat FloatNeg() => Float3x3(-1, 2, -3, 4, -5, 6, -7, 8, -9);

    private static Mat Byte3x3(params byte[] values)
    {
        var m = new Mat(3, 3, MatType.CV_8UC1);
        m.SetArray(values);
        return m;
    }

    private static Mat P() => Byte3x3(0x0F, 0xF0, 0xAA, 0x55, 0xFF, 0x00, 0x12, 0x34, 0x80);
    private static Mat Q() => Byte3x3(0xFF, 0x0F, 0x55, 0xAA, 0x01, 0x80, 0x21, 0x43, 0x08);

    // ---- arithmetic ----

    [Fact]
    public void AddMatMat()
    {
        using var a = A();
        using var b = B();

        using Mat actual = a + b;
        using var expected = new Mat();
        Cv2.Add(a, b, expected);

        AssertSame(expected, actual, 0);
    }

    [Fact]
    public void SubtractMatMat()
    {
        using var a = A();
        using var b = B();

        using Mat actual = a - b;
        using var expected = new Mat();
        Cv2.Subtract(a, b, expected);

        AssertSame(expected, actual, 0);
    }

    [Fact]
    public void MultiplyMatMat()
    {
        using var a = A();
        using var b = B();

        // Mat * Mat is matrix multiplication (cv::gemm), not element-wise.
        using Mat actual = a * b;
        using var src3 = new Mat();
        using var expected = new Mat();
        Cv2.Gemm(a, b, 1, src3, 0, expected);

        AssertSame(expected, actual);
    }

    [Fact]
    public void DivideMatMat()
    {
        using var a = A();
        using var b = B();

        using Mat actual = a / b;
        using var expected = new Mat();
        Cv2.Divide(a, b, expected);

        AssertSame(expected, actual);
    }

    [Fact]
    public void UnaryMinus()
    {
        using var a = A();

        using Mat actual = -a;
        using var zeros = Mat.ZerosMat(3, 3, MatType.CV_32FC1);
        using var expected = new Mat();
        Cv2.Subtract(zeros, a, expected);

        AssertSame(expected, actual, 0);
    }

    [Fact]
    public void AddScalar()
    {
        using var a = A();

        using Mat actual = a + new Scalar(10);
        using var expected = new Mat();
        Cv2.Add(a, new Scalar(10), expected);

        AssertSame(expected, actual, 0);
    }

    [Fact]
    public void ScalarSubtractMat()
    {
        using var a = A();

        using Mat actual = new Scalar(100) - a;
        using var expected = Float3x3(99, 98, 97, 96, 95, 94, 93, 92, 91);

        AssertSame(expected, actual, 0);
    }

    [Fact]
    public void MultiplyDouble()
    {
        using var a = A();

        using Mat actual = a * 0.8;
        using var expected = new Mat();
        a.ConvertTo(expected, a.Type(), 0.8);

        AssertSame(expected, actual);
    }

    [Fact]
    public void DivideDouble()
    {
        using var a = A();

        using Mat actual = a / 2.0;
        using var expected = new Mat();
        a.ConvertTo(expected, a.Type(), 0.5);

        AssertSame(expected, actual);
    }

    [Fact]
    public void ElementwiseMul()
    {
        using var a = A();
        using var b = B();

        using Mat actual = a.Mul(b, 1.5);
        using var expected = new Mat();
        Cv2.Multiply(a, b, expected, 1.5);

        AssertSame(expected, actual);
    }

    [Fact]
    public void ChainAddSubtract()
    {
        using var a = A();
        using var b = B();
        using var c = C();

        // a + b - c: with the lazy tree the intermediate (a + b) holds no native resource.
        using Mat actual = a + b - c;
        using var tmp = new Mat();
        Cv2.Add(a, b, tmp);
        using var expected = new Mat();
        Cv2.Subtract(tmp, c, expected);

        AssertSame(expected, actual, 0);
    }

    [Fact]
    public void MotivatingExample_255MinusMatTimes08()
    {
        using var a = A();

        // 255 - a * 0.8 — the classic chain whose intermediates used to leak to the finalizer.
        using Mat actual = new Scalar(255) - a * 0.8;
        using var expected = Float3x3(
            255f - 1f * 0.8f, 255f - 2f * 0.8f, 255f - 3f * 0.8f,
            255f - 4f * 0.8f, 255f - 5f * 0.8f, 255f - 6f * 0.8f,
            255f - 7f * 0.8f, 255f - 8f * 0.8f, 255f - 9f * 0.8f);

        AssertSame(expected, actual, 1e-3);
    }

    [Fact]
    public void NestedMixed()
    {
        using var a = A();
        using var b = B();
        using var c = C();

        // (a + b).mul(c) * 0.5 - 1
        using Mat actual = (a + b).Mul(c) * 0.5 - new Scalar(1);

        using var ab = new Mat();
        Cv2.Add(a, b, ab);
        using var mul = new Mat();
        Cv2.Multiply(ab, c, mul);
        using var scaled = new Mat();
        mul.ConvertTo(scaled, mul.Type(), 0.5);
        using var expected = new Mat();
        Cv2.Subtract(scaled, new Scalar(1), expected);

        AssertSame(expected, actual);
    }

    [Fact]
    public void ReusedSubtreeEvaluatesIndependently()
    {
        using var a = A();
        using var b = B();

        // A node can be bound to a variable and materialized more than once; each use is
        // independent and the node itself owns no native resource.
        var sum = a + b;
        using Mat first = sum * 2.0;
        using Mat second = sum - new Scalar(1);

        using var ab = new Mat();
        Cv2.Add(a, b, ab);
        using var firstExpected = new Mat();
        ab.ConvertTo(firstExpected, ab.Type(), 2.0);
        using var secondExpected = new Mat();
        Cv2.Subtract(ab, new Scalar(1), secondExpected);

        AssertSame(firstExpected, first);
        AssertSame(secondExpected, second);
    }

    // ---- bitwise ----

    [Fact]
    public void BitwiseAnd()
    {
        using var p = P();
        using var q = Q();

        using Mat actual = p & q;
        using var expected = new Mat();
        Cv2.BitwiseAnd(p, q, expected);

        AssertSame(expected, actual, 0);
    }

    [Fact]
    public void BitwiseOr()
    {
        using var p = P();
        using var q = Q();

        using Mat actual = p | q;
        using var expected = new Mat();
        Cv2.BitwiseOr(p, q, expected);

        AssertSame(expected, actual, 0);
    }

    [Fact]
    public void BitwiseXor()
    {
        using var p = P();
        using var q = Q();

        using Mat actual = p ^ q;
        using var expected = new Mat();
        Cv2.BitwiseXor(p, q, expected);

        AssertSame(expected, actual, 0);
    }

    [Fact]
    public void BitwiseNot()
    {
        using var p = P();

        using Mat actual = ~p;
        using var expected = new Mat();
        Cv2.BitwiseNot(p, expected);

        AssertSame(expected, actual, 0);
    }

    [Fact]
    public void BitwiseChainedWithArithmetic()
    {
        using var p = P();
        using var q = Q();

        // (p & q) | ~p
        using Mat actual = (p & q) | ~p;
        using var and = new Mat();
        Cv2.BitwiseAnd(p, q, and);
        using var not = new Mat();
        Cv2.BitwiseNot(p, not);
        using var expected = new Mat();
        Cv2.BitwiseOr(and, not, expected);

        AssertSame(expected, actual, 0);
    }

    // ---- comparison ----

    [Fact]
    public void LessThan()
    {
        using var a = A();
        using var b = B();

        using Mat actual = a.LessThan(b);
        using var expected = new Mat();
        Cv2.Compare(a, b, expected, CmpTypes.LT);

        AssertSame(expected, actual, 0);
    }

    [Fact]
    public void GreaterThanOrEqualDouble()
    {
        using var a = A();

        using Mat actual = a.GreaterThanOrEqual(5.0);
        using var expected = new Mat();
        Cv2.Compare(a, new Scalar(5.0), expected, CmpTypes.GE);

        AssertSame(expected, actual, 0);
    }

    [Fact]
    public void EqualAndNotEqual()
    {
        using var a = A();
        using var b = B();

        using Mat eqActual = a.Equals(b);
        using var eqExpected = new Mat();
        Cv2.Compare(a, b, eqExpected, CmpTypes.EQ);
        AssertSame(eqExpected, eqActual, 0);

        using Mat neActual = a.NotEquals(b);
        using var neExpected = new Mat();
        Cv2.Compare(a, b, neExpected, CmpTypes.NE);
        AssertSame(neExpected, neActual, 0);
    }

    [Fact]
    public void ComparisonOnArithmeticResult()
    {
        using var a = A();
        using var b = B();

        // (a + b) > 8 : the comparison materializes the arithmetic subexpression to Mat.
        using Mat actual = (a + b).GreaterThan(8.0);
        using var sum = new Mat();
        Cv2.Add(a, b, sum);
        using var expected = new Mat();
        Cv2.Compare(sum, new Scalar(8.0), expected, CmpTypes.GT);

        AssertSame(expected, actual, 0);
    }

    // ---- abs / min / max ----

    [Fact]
    public void Abs()
    {
        using var a = FloatNeg();

        using Mat actual = a.Abs();
        using var zeros = Mat.ZerosMat(3, 3, MatType.CV_32FC1);
        using var expected = new Mat();
        Cv2.Absdiff(a, zeros, expected);

        AssertSame(expected, actual, 0);
    }

    [Fact]
    public void AbsOfArithmetic()
    {
        using var a = A();
        using var b = B();

        // abs(a - b)
        using Mat actual = (a - b).Abs();
        using var expected = new Mat();
        Cv2.Absdiff(a, b, expected);

        AssertSame(expected, actual, 0);
    }

    [Fact]
    public void Min()
    {
        using var a = A();
        using var b = B();
        using var c = C();

        // min of an expression with a Mat operand
        using Mat actual = (a + b).Min(c);
        using var sum = new Mat();
        Cv2.Add(a, b, sum);
        using var expected = new Mat();
        Cv2.Min(sum, c, expected);

        AssertSame(expected, actual, 0);
    }

    [Fact]
    public void MaxDouble()
    {
        using var a = A();
        using var b = B();

        using Mat actual = (a + b).Max(5.0);
        using var sum = new Mat();
        Cv2.Add(a, b, sum);
        using var expected = new Mat();
        Cv2.Max(sum, 5.0, expected);

        AssertSame(expected, actual, 0);
    }

    // ---- matrix methods ----

    [Fact]
    public void Transpose()
    {
        using var a = A();

        using Mat actual = a.T();
        using var expected = new Mat();
        Cv2.Transpose(a, expected);

        AssertSame(expected, actual, 0);
    }

    [Fact]
    public void Inverse()
    {
        using var c = C();

        using Mat actual = c.Inv();
        using var expected = new Mat();
        Cv2.Invert(c, expected, DecompTypes.LU);

        AssertSame(expected, actual);
    }

    [Fact]
    public void Row()
    {
        using var a = A();
        using var b = B();

        using Mat actual = (a + b).Row(1);
        using var sum = new Mat();
        Cv2.Add(a, b, sum);
        using Mat expected = sum.Row(1);

        AssertSame(expected, actual, 0);
    }

    [Fact]
    public void Col()
    {
        using var a = A();
        using var b = B();

        using Mat actual = (a + b).Col(2);
        using var sum = new Mat();
        Cv2.Add(a, b, sum);
        using Mat expected = sum.Col(2);

        AssertSame(expected, actual, 0);
    }

    [Fact]
    public void Diagonal()
    {
        using var a = A();
        using var b = B();

        using Mat actual = (a + b).Diag();
        using var sum = new Mat();
        Cv2.Add(a, b, sum);
        using Mat expected = sum.Diag();

        AssertSame(expected, actual, 0);
    }

    [Fact]
    public void SubMatrix()
    {
        using var a = A();
        using var b = B();
        var roi = new Rect(1, 0, 2, 2);

        using Mat actual = (a + b).SubMat(roi);
        using var sum = new Mat();
        Cv2.Add(a, b, sum);
        using Mat expected = sum.SubMat(roi);

        AssertSame(expected, actual, 0);
    }

    [Fact]
    public void SizeAndType()
    {
        using var a = A();
        using var b = B();

        var node = a + b;
        Assert.Equal(a.Size(), node.Size());
        Assert.Equal(a.Type(), node.Type());
    }
}
