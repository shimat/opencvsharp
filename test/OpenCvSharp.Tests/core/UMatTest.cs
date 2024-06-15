using Xunit;

namespace OpenCvSharp.Tests.Core;

public class UMatTest
{
    [Fact]
    public void NewAndDispose()
    {
        using var umat = new UMat();
    }

    [Fact]
    public void Empty()
    {
        using var umat1 = new UMat();
        Assert.True(umat1.Empty());

        using var umat2 = new UMat(1, 2, MatType.CV_32FC1);
        Assert.False(umat2.Empty());
    }

    [Fact]
    public void Size()
    {
        using var umat = new UMat(new Size(3,4), MatType.CV_8UC1);
        Assert.Equal(new Size(3, 4), umat.Size());
        Assert.Equal(4, umat.Rows);
        Assert.Equal(3, umat.Cols);
    }

    [Fact]
    public void Total()
    {
        using var umat = new UMat(new Size(3, 4), MatType.CV_8UC1);
        Assert.Equal(3 * 4, umat.Total());
    }

    [Fact]
    public void Dims()
    {
        using var umat = new UMat(new Size(1, 1), MatType.CV_16UC1);
        Assert.Equal(2, umat.Dims);
    }

    [Fact]
    public void Step()
    {
        using var umat1 = new UMat(new Size(3, 3), MatType.CV_8UC1);
        Assert.Equal(3 * 1 * sizeof(byte), umat1.Step());
        Assert.Equal(3 * 1, umat1.Step1());

        using var umat2 = new UMat(new Size(3, 3), MatType.CV_8UC3);
        Assert.Equal(3 * 3 * sizeof(byte), umat2.Step());
        Assert.Equal(3 * 3, umat2.Step1());

        using var umat3 = new UMat(new Size(3, 3), MatType.CV_32SC1);
        Assert.Equal(3 * 1 * sizeof(int), umat3.Step());
        Assert.Equal(3 * 1, umat3.Step1());

        using var umat4 = new UMat(new Size(3, 3), MatType.CV_32SC3);
        Assert.Equal(3 * 3 * sizeof(int), umat4.Step());
        Assert.Equal(3 * 3, umat4.Step1());
    }

    [Fact]
    public void Type()
    {
        using var umat = new UMat(1, 2, MatType.CV_8UC1);
        Assert.Equal(MatType.CV_8UC1, umat.Type());
        Assert.Equal(1, umat.Channels());
        Assert.Equal(MatType.CV_8U, umat.Depth());
    }

    [Fact]
    public void ElemSize()
    {
        foreach (var (matTypeFunction, elemSize1) in GetInputs())
        {
            for (int ch = 1; ch <= 6; ch++)
            {
                using var umat = new UMat(1, 1, matTypeFunction(ch));
                Assert.Equal(elemSize1, umat.ElemSize1());
                Assert.Equal(elemSize1 * ch, umat.ElemSize());
            }
        }

        static IEnumerable<(Func<int, MatType> MatTypeFunction, int elemSize1)> GetInputs()
        {
            yield return (MatType.CV_8UC, 1);
            yield return (MatType.CV_16SC, 2);
            yield return (MatType.CV_32SC, 4);
            yield return (MatType.CV_32FC, 4);
            yield return (MatType.CV_64FC, 8);
        }
    }

    [Fact]
    public void GetMat()
    {
        using var umat = new UMat(1, 1, MatType.CV_8UC3, new Scalar(1, 2, 3));
        using var mat = umat.GetMat(AccessFlag.READ);

        Assert.Equal(umat.Size(), mat.Size());
        Assert.Equal(umat.Type(), mat.Type());
        Assert.Equal(new Vec3b(1, 2, 3), mat.Get<Vec3b>(0, 0));
    }

    [Fact]
    public void CastToInputArray()
    {
        using var src = new UMat(1, 1, MatType.CV_8UC1, new Scalar(64));
        using var dst = new UMat();

        Cv2.BitwiseNot(src, dst);

        AssertEquals(dst, MatType.CV_8UC1, new byte[,] {{255 - 64}});
    }

    [Fact]
    public void Diag()
    {
        using var main = new UMat(3, 1, MatType.CV_32FC1, new Scalar(3));
        using var diag = UMat.Diag(main);
            
        AssertEquals(diag, MatType.CV_32FC1, new float[,]
        {
            { 3, 0, 0 },
            { 0, 3, 0 },
            { 0, 0, 3 }
        });
    }
        
    [Fact]
    public void CopyToClone()
    {
        var values = new double[,] { { 1, 2 }, { 3, 4 } };
        using var srcMat = Mat.FromArray(values);

        using var srcUMat = new UMat();
        srcMat.CopyTo(srcUMat);

        var dstUMat = srcUMat.Clone();

        AssertEquals(dstUMat, MatType.CV_64FC1, values);
    }

    [Fact]
    public void AssignTo()
    {
        using var srcUMat = new UMat(2, 2, MatType.CV_32SC1, Scalar.All(1234));

        using var dstUMat = new UMat();
        srcUMat.AssignTo(dstUMat);
            
        AssertEquals(dstUMat, MatType.CV_32SC1, new [,]
        {
            { 1234, 1234 }, { 1234, 1234 }
        });
    }

    [Fact]
    public void SetTo()
    {
        using var umat = new UMat(2, 2, MatType.CV_16SC1);
        umat.SetTo(Scalar.All(-5));

        AssertEquals(umat, MatType.CV_16SC1, new short[,]
        {
            { -5, -5 }, { -5, -5 }
        });
    }

    [Fact]
    public void Dot()
    {
        using var mat1 = Mat.FromPixelData(2, 1, MatType.CV_32SC1, new[] { 1, 2 });
        using var mat2 = Mat.FromPixelData(2, 1, MatType.CV_32SC1, new[] { 3, 4 });

        using var umat1 = new UMat(2, 1, MatType.CV_32SC1);
        using var umat2 = new UMat(2, 1, MatType.CV_32SC1);
        mat1.CopyTo(umat1);
        mat2.CopyTo(umat2);

        Assert.Equal(1 * 3 + 2 * 4, umat1.Dot(umat2), 6);
    }

    [Fact]
    public void Zeros()
    {
        using var umat = UMat.Zeros(2, 3, MatType.CV_16SC1);

        AssertEquals(umat, MatType.CV_16SC1, new short[,]
        {
            { 0, 0, 0 }, { 0, 0, 0 }
        });
    }

    [Fact]
    public void Ones()
    {
        using var umat = UMat.Ones(2, 3, MatType.CV_8UC1);

        AssertEquals(umat, MatType.CV_8UC1, new byte[,]
        {
            { 1, 1, 1 }, { 1, 1, 1 }
        });
    }

    [Fact]
    public void Eye()
    {
        using var umat = UMat.Eye(3, 3, MatType.CV_32FC1);

        AssertEquals(umat, MatType.CV_32FC1, new float[,]
        {
            { 1, 0, 0 },
            { 0, 1, 0 },
            { 0, 0, 1 }
        });
    }

    [Fact]
    public void SubmatByRect()
    {
        var values = new double[,]
        {
            { 1, 2, 3, 4 }, 
            { 5, 6, 7, 8 },
            { 9, 10, 11, 12 },
            { 13, 14, 15, 16 }
        };
        using var srcMat = Mat.FromArray(values);
        using var srcUMat = new UMat();
        srcMat.CopyTo(srcUMat);

        Assert.True(srcUMat.IsContinuous());
        Assert.False(srcUMat.IsSubmatrix());

        var subUMat = srcUMat[new Rect(1, 2, 2, 2)];
        AssertEquals(subUMat, MatType.CV_64FC1, new double[,]
        {
            {10, 11},
            {14, 15}
        });
        Assert.False(subUMat.IsContinuous());
        Assert.True(subUMat.IsSubmatrix());
    }

    [Fact]
    public void SubmatByRange()
    {
        var values = new double[,]
        {
            { 1, 2, 3, 4 },
            { 5, 6, 7, 8 },
            { 9, 10, 11, 12 },
            { 13, 14, 15, 16 }
        };
        using var srcMat = Mat.FromArray(values);
        using var srcUMat = new UMat();
        srcMat.CopyTo(srcUMat);

        Assert.True(srcUMat.IsContinuous());
        Assert.False(srcUMat.IsSubmatrix());

        var subUMat = srcUMat[new Range(2, 4), new Range(1, 3)];
        AssertEquals(subUMat, MatType.CV_64FC1, new double[,]
        {
            {10, 11},
            {14, 15}
        });
        Assert.False(subUMat.IsContinuous());
        Assert.True(subUMat.IsSubmatrix());
    }

    private static void AssertEquals<T>(UMat umat, MatType expectedType, T[,] expectedValues)
        where T : unmanaged
    {
        int rows = expectedValues.GetLength(0);
        int cols = expectedValues.GetLength(1);
        Assert.False(umat.Empty());
        Assert.Equal(rows, umat.Rows);
        Assert.Equal(cols, umat.Cols);
        Assert.Equal(expectedType, umat.Type());

        using var mat = umat.GetMat(AccessFlag.READ);
        Assert.True(mat.GetRectangularArray(out T[,] matValues));
        Assert.Equal(expectedValues, matValues);
    }
}
