using System.Reflection;
using Xunit;

#pragma warning disable CA5394 // Do not use insecure randomness

namespace OpenCvSharp.Tests.Core;

public class VecTest
{
    [Fact]
    public void Vec2b()
    {
        Assert.Equal(
            new Vec2b(4, 6),
            new Vec2b(1, 2) + new Vec2b(3, 4));
        Assert.Equal(
            new Vec2b(255, 255), 
            new Vec2b(100, 200) + new Vec2b(200, 200));

        Assert.Equal(
            new Vec2b(9, 8),
            new Vec2b(10, 10) - new Vec2b(1, 2));
        Assert.Equal(
            new Vec2b(0, 0), 
            new Vec2b(10, 20) - new Vec2b(100, 200));

        Assert.Equal(
            new Vec2b(2, 4), 
            new Vec2b(1, 2) * 2);
        Assert.Equal(
            new Vec2b(5, 10),
            new Vec2b(2, 4) * 2.5);
        Assert.Equal(
            new Vec2b(255, 255), 
            new Vec2b(1, 2) * 10000);
        Assert.Equal(
            new Vec2b(0, 0), 
            new Vec2b(1, 2) * -10000);
    }

    [Fact]
    public void Vec3b()
    {
        Assert.Equal(
            new Vec3b(6, 9, 12), 
            new Vec3b(1, 2, 3) + new Vec3b(2, 3, 4) + new Vec3b(3, 4, 5));
        Assert.Equal(
            new Vec3b(200, 255, 255),
            new Vec3b(100, 150, 200) + new Vec3b(100, 150, 200));

        Assert.Equal(
            new Vec3b(9, 8, 7),
            new Vec3b(10, 10, 10) - new Vec3b(1, 2, 3));
        Assert.Equal(
            new Vec3b(0, 0, 0),
            new Vec3b(1, 2, 3) - new Vec3b(10, 20, 30));

        Assert.Equal(
            new Vec3b(2, 4, 6), 
            new Vec3b(1, 2, 3) * 2);
        Assert.Equal(
            new Vec3b(5, 10, 15), 
            new Vec3b(2, 4, 6) * 2.5);
        Assert.Equal(
            new Vec3b(255, 255, 255), 
            new Vec3b(1, 2, 3) * 10000);
        Assert.Equal(
            new Vec3b(0, 0, 0),
            new Vec3b(1, 2, 3) * -10000);

        Assert.Equal(
            new Vec3b(2, 1, 0),
            new Vec3b(3, 2, 1) / 2);
    }

    [Fact]
    public void ConversionVec2b()
    {
        var v = new Vec2b(1, 2);

        Assert.Equal(new Vec2s(1, 2), v.ToVec2s());
        Assert.Equal(new Vec2w(1, 2), v.ToVec2w());
        Assert.Equal(new Vec2i(1, 2), v.ToVec2i());
        Assert.Equal(new Vec2f(1, 2), v.ToVec2f());
        Assert.Equal(new Vec2d(1, 2), v.ToVec2d());
    }

    [Fact]
    public void ConversionVec3b()
    {
        var v = new Vec3b(1, 2, 3);

        Assert.Equal(new Vec3s(1, 2, 3), v.ToVec3s());
        Assert.Equal(new Vec3w(1, 2, 3), v.ToVec3w());
        Assert.Equal(new Vec3i(1, 2, 3), v.ToVec3i());
        Assert.Equal(new Vec3f(1, 2, 3), v.ToVec3f());
        Assert.Equal(new Vec3d(1, 2, 3), v.ToVec3d());
    }

    [Fact]
    public void ConversionVec4b()
    {
        var v = new Vec4b(1, 2, 3, 4);

        Assert.Equal(new Vec4s(1, 2, 3, 4), v.ToVec4s());
        Assert.Equal(new Vec4w(1, 2, 3, 4), v.ToVec4w());
        Assert.Equal(new Vec4i(1, 2, 3, 4), v.ToVec4i());
        Assert.Equal(new Vec4f(1, 2, 3, 4), v.ToVec4f());
        Assert.Equal(new Vec4d(1, 2, 3, 4), v.ToVec4d());
    }

    [Fact]
    public void ConversionVec6b()
    {
        var v = new Vec6b(1, 2, 3, 4, 5, 6);

        Assert.Equal(new Vec6s(1, 2, 3, 4, 5, 6), v.ToVec6s());
        Assert.Equal(new Vec6w(1, 2, 3, 4, 5, 6), v.ToVec6w());
        Assert.Equal(new Vec6i(1, 2, 3, 4, 5, 6), v.ToVec6i());
        Assert.Equal(new Vec6f(1, 2, 3, 4, 5, 6), v.ToVec6f());
        Assert.Equal(new Vec6d(1, 2, 3, 4, 5, 6), v.ToVec6d());
    }


    [Fact]
    public void Vec4b()
    {
        Assert.Equal(new Vec4b(4, 6, 8, 10), new Vec4b(1, 2, 3, 4) + new Vec4b(3, 4, 5, 6));
        Assert.Equal(new Vec4b(255, 255, 255, 255), new Vec4b(200, 200, 200, 200) + new Vec4b(100, 100, 100, 100));
        Assert.Equal(new Vec4b(0, 0, 0, 0), new Vec4b(1, 2, 3, 4) - new Vec4b(10, 20, 30, 40));
        Assert.Equal(new Vec4b(2, 4, 6, 8), new Vec4b(1, 2, 3, 4) * 2);
        Assert.Equal(new Vec4b(0, 1, 2, 2), new Vec4b(1, 2, 3, 4) / 2);
    }

    [Fact]
    public void Vec6b()
    {
        Assert.Equal(new Vec6b(2, 4, 6, 8, 10, 12), new Vec6b(1, 2, 3, 4, 5, 6) * 2);
        Assert.Equal(new Vec6b(255, 255, 255, 255, 255, 255), new Vec6b(200, 200, 200, 200, 200, 200) + new Vec6b(100, 100, 100, 100, 100, 100));
        Assert.Equal(new Vec6b(0, 0, 0, 0, 0, 0), new Vec6b(1, 2, 3, 4, 5, 6) - new Vec6b(10, 10, 10, 10, 10, 10));
    }

    [Fact]
    public void ArithmeticSaturatingInt()
    {
        // short: saturation on overflow
        Assert.Equal(new Vec2s(4, 6), new Vec2s(1, 2) + new Vec2s(3, 4));
        Assert.Equal(new Vec2s(short.MaxValue, 0), new Vec2s(30000, 0) + new Vec2s(10000, 0));
        Assert.Equal(new Vec2s(short.MinValue, 0), new Vec2s(-30000, 0) - new Vec2s(10000, 0));
        Assert.Equal(new Vec2s(2, 4), new Vec2s(1, 2) * 2);
        Assert.Equal(new Vec2s(1, 2), new Vec2s(2, 4) / 2);

        // ushort: clamp to 0 on underflow
        Assert.Equal(new Vec2w(4, 6), new Vec2w(1, 2) + new Vec2w(3, 4));
        Assert.Equal(new Vec2w(ushort.MaxValue, ushort.MaxValue), new Vec2w(60000, 1) + new Vec2w(10000, ushort.MaxValue));
        Assert.Equal(new Vec2w(0, 0), new Vec2w(5, 3) - new Vec2w(10, 5));
        Assert.Equal(new Vec2w(2, 4), new Vec2w(1, 2) * 2);

        // int
        Assert.Equal(new Vec3i(4, 6, 8), new Vec3i(1, 2, 3) + new Vec3i(3, 4, 5));
        Assert.Equal(new Vec3i(-2, -2, -2), new Vec3i(1, 2, 3) - new Vec3i(3, 4, 5));
        Assert.Equal(new Vec3i(2, 4, 6), new Vec3i(1, 2, 3) * 2);
        Assert.Equal(new Vec3i(1, 2, 3), new Vec3i(2, 4, 6) / 2);
    }

    [Fact]
    public void ArithmeticFloating()
    {
        Assert.Equal(new Vec2f(4f, 6f), new Vec2f(1f, 2f) + new Vec2f(3f, 4f));
        Assert.Equal(new Vec2f(-2f, -2f), new Vec2f(1f, 2f) - new Vec2f(3f, 4f));
        Assert.Equal(new Vec2f(2f, 4f), new Vec2f(1f, 2f) * 2);
        Assert.Equal(new Vec2f(0.5f, 1f), new Vec2f(1f, 2f) / 2);

        Assert.Equal(new Vec4f(2f, 4f, 6f, 8f), new Vec4f(1f, 2f, 3f, 4f) * 2);

        Assert.Equal(new Vec2d(4.0, 6.0), new Vec2d(1.0, 2.0) + new Vec2d(3.0, 4.0));
        Assert.Equal(new Vec2d(-2.0, -2.0), new Vec2d(1.0, 2.0) - new Vec2d(3.0, 4.0));
        Assert.Equal(new Vec2d(2.0, 4.0), new Vec2d(1.0, 2.0) * 2);
        Assert.Equal(new Vec2d(0.5, 1.0), new Vec2d(1.0, 2.0) / 2);

        Assert.Equal(new Vec6d(2.0, 4.0, 6.0, 8.0, 10.0, 12.0), new Vec6d(1.0, 2.0, 3.0, 4.0, 5.0, 6.0) * 2);
    }

    [Fact]
    public void EqualityAndHashCode()
    {
        var a = new Vec3i(1, 2, 3);
        var b = new Vec3i(1, 2, 3);
        var c = new Vec3i(1, 2, 4);
        Assert.True(a == b);
        Assert.False(a != b);
        Assert.True(a.Equals(b));
        Assert.Equal(a.GetHashCode(), b.GetHashCode());

        Assert.False(a == c);
        Assert.True(a != c);
        Assert.False(a.Equals(c));

        Assert.True(new Vec4b(1, 2, 3, 4) == new Vec4b(1, 2, 3, 4));
        Assert.True(new Vec4b(1, 2, 3, 4) != new Vec4b(1, 2, 3, 5));

        Assert.True(new Vec2f(1f, 2f) == new Vec2f(1f, 2f));
        Assert.False(new Vec2f(1f, 2f) != new Vec2f(1f, 2f));

        Assert.True(new Vec4d(1.0, 2.0, 3.0, 4.0) == new Vec4d(1.0, 2.0, 3.0, 4.0));
        Assert.True(new Vec4d(1.0, 2.0, 3.0, 4.0) != new Vec4d(1.0, 2.0, 3.0, 5.0));
    }

    [Fact]
    public void Deconstruct()
    {
        var (x, y) = new Vec2d(1.0, 2.0);
        Assert.Equal(1.0, x);
        Assert.Equal(2.0, y);

        var (xi, yi, zi) = new Vec3i(3, 4, 5);
        Assert.Equal(3, xi);
        Assert.Equal(5, zi);

        var (a, b, c, d) = new Vec4f(1f, 2f, 3f, 4f);
        Assert.Equal(4f, d);

        var (p, q, r, s, t, u) = new Vec6b(10, 20, 30, 40, 50, 60);
        Assert.Equal(10, p);
        Assert.Equal(60, u);
    }

    [Fact]
    public void IndexerOutOfRange()
    {
        var v = new Vec3d(1.0, 2.0, 3.0);
        Assert.Throws<ArgumentOutOfRangeException>(() => _ = v[-1]);
        Assert.Throws<ArgumentOutOfRangeException>(() => _ = v[3]);

        var w = new Vec4i(1, 2, 3, 4);
        Assert.Throws<ArgumentOutOfRangeException>(() => w[4] = 0);
    }

    [Fact]
    public void ToStringFormat()
    {
        Assert.Contains("Vec2b", new Vec2b(1, 2).ToString());
        Assert.Contains("1", new Vec2b(1, 2).ToString());

        Assert.Contains("Vec3f", new Vec3f(1f, 2f, 3f).ToString());
        Assert.Contains("Vec6i", new Vec6i(1, 2, 3, 4, 5, 6).ToString());
        Assert.Contains("Vec4d", new Vec4d(1.0, 2.0, 3.0, 4.0).ToString());
    }

    [Fact]
    public void ConversionNonByte()
    {
        // short
        var vs = new Vec3s(10, 20, 30);
        Assert.Equal(new Vec3w(10, 20, 30), vs.ToVec3w());
        Assert.Equal(new Vec3i(10, 20, 30), vs.ToVec3i());
        Assert.Equal(new Vec3f(10f, 20f, 30f), vs.ToVec3f());
        Assert.Equal(new Vec3d(10.0, 20.0, 30.0), vs.ToVec3d());

        // int
        var vi = new Vec3i(1, 2, 3);
        Assert.Equal(new Vec3f(1f, 2f, 3f), vi.ToVec3f());
        Assert.Equal(new Vec3d(1.0, 2.0, 3.0), vi.ToVec3d());

        // float
        var vf = new Vec2f(1.5f, 2.5f);
        Assert.Equal(new Vec2i(1, 2), vf.ToVec2i()); // (int) cast truncates, not rounds
        Assert.Equal(new Vec2d(1.5, 2.5), vf.ToVec2d());
    }

    [Fact]
    public void UnaryMinus()
    {
        // short (with saturation: -short.MinValue clamps to short.MaxValue)
        Assert.Equal(new Vec2s(-1, -2), -new Vec2s(1, 2));
        Assert.Equal(new Vec2s(short.MaxValue, 0), -new Vec2s(short.MinValue, 0));
        Assert.Equal(new Vec3s(-1, -2, -3), -new Vec3s(1, 2, 3));
        Assert.Equal(new Vec4s(-1, -2, -3, -4), -new Vec4s(1, 2, 3, 4));
        Assert.Equal(new Vec6s(-1, -2, -3, -4, -5, -6), -new Vec6s(1, 2, 3, 4, 5, 6));

        // int (with saturation: -int.MinValue clamps to int.MaxValue)
        Assert.Equal(new Vec2i(-1, -2), -new Vec2i(1, 2));
        Assert.Equal(new Vec2i(int.MaxValue, 0), -new Vec2i(int.MinValue, 0));
        Assert.Equal(new Vec3i(-1, -2, -3), -new Vec3i(1, 2, 3));
        Assert.Equal(new Vec4i(-1, -2, -3, -4), -new Vec4i(1, 2, 3, 4));
        Assert.Equal(new Vec6i(-1, -2, -3, -4, -5, -6), -new Vec6i(1, 2, 3, 4, 5, 6));

        // float
        Assert.Equal(new Vec2f(-1f, -2f), -new Vec2f(1f, 2f));
        Assert.Equal(new Vec3f(-1f, -2f, -3f), -new Vec3f(1f, 2f, 3f));
        Assert.Equal(new Vec4f(-1f, -2f, -3f, -4f), -new Vec4f(1f, 2f, 3f, 4f));
        Assert.Equal(new Vec6f(-1f, -2f, -3f, -4f, -5f, -6f), -new Vec6f(1f, 2f, 3f, 4f, 5f, 6f));

        // double
        Assert.Equal(new Vec2d(-1.0, -2.0), -new Vec2d(1.0, 2.0));
        Assert.Equal(new Vec3d(-1.0, -2.0, -3.0), -new Vec3d(1.0, 2.0, 3.0));
        Assert.Equal(new Vec4d(-1.0, -2.0, -3.0, -4.0), -new Vec4d(1.0, 2.0, 3.0, 4.0));
        Assert.Equal(new Vec6d(-1.0, -2.0, -3.0, -4.0, -5.0, -6.0), -new Vec6d(1.0, 2.0, 3.0, 4.0, 5.0, 6.0));
    }

    /// <summary>
    /// Equals() follows .NET contract (NaN.Equals(NaN) == true, required for collections).
    /// operator == follows IEEE 754 (NaN == NaN is false, same as double/float).
    /// </summary>
    [Fact]
    public void FloatingPointNaNEquality()
    {
        // float
        var vfNaN = new Vec2f(float.NaN, 1f);
        Assert.True(vfNaN.Equals(vfNaN));   // IEquatable contract: reflexive
#pragma warning disable CS1718 // Comparison made to same variable — intentional: testing IEEE 754 NaN behaviour
        Assert.False(vfNaN == vfNaN);        // IEEE 754: NaN != NaN
        Assert.True(vfNaN != vfNaN);
#pragma warning restore CS1718

        var vfNormal = new Vec2f(1f, 2f);
        Assert.True(vfNormal == vfNormal);
        Assert.False(vfNormal != vfNormal);

        // double
        var vdNaN = new Vec3d(double.NaN, 1.0, 2.0);
        Assert.True(vdNaN.Equals(vdNaN));
#pragma warning disable CS1718
        Assert.False(vdNaN == vdNaN);
        Assert.True(vdNaN != vdNaN);
#pragma warning restore CS1718

        var vdNormal = new Vec3d(1.0, 2.0, 3.0);
        Assert.True(vdNormal == vdNormal);
        Assert.False(vdNormal != vdNormal);
    }

#if !NETFRAMEWORK
    [Fact]
    public void AsSpan()
    {
        var v2b = new Vec2b(1, 2);
        var s2b = v2b.AsSpan();
        Assert.Equal(2, s2b.Length);
        Assert.Equal(1, s2b[0]);
        Assert.Equal(2, s2b[1]);
        // mutation via Span reflects back in the struct
        s2b[0] = 99;
        Assert.Equal(99, v2b.Item0);

        var v3d = new Vec3d(1.0, 2.0, 3.0);
        var s3d = v3d.AsSpan();
        Assert.Equal(3, s3d.Length);
        Assert.Equal(1.0, s3d[0]);
        Assert.Equal(3.0, s3d[2]);

        var v4f = new Vec4f(10f, 20f, 30f, 40f);
        var s4f = v4f.AsSpan();
        Assert.Equal(4, s4f.Length);
        Assert.Equal(40f, s4f[3]);

        var v6i = new Vec6i(1, 2, 3, 4, 5, 6);
        var s6i = v6i.AsSpan();
        Assert.Equal(6, s6i.Length);
        Assert.Equal(6, s6i[5]);
    }
#endif

    [Fact]
    public void ReflectionCheck()
    {
        foreach (var channels in new[] {2, 3, 4, 6})
        {
            CheckByType<byte>(channels);
            CheckByType<short>(channels);
            CheckByType<ushort>(channels);
            CheckByType<int>(channels);
            CheckByType<float>(channels);
            CheckByType<double>(channels);
        }

        static void CheckByType<T>(int channels)
            where T : unmanaged
        {
            var depth = GetTypeString<T>();
            var typeName = $"OpenCvSharp.Vec{channels}{depth},OpenCvSharp";
            var type = Type.GetType(typeName);

            var rand = new Random(123);

            // ItemX
            var obj = Activator.CreateInstance(type!);
            for (int i = 0; i < channels; i++)
            {
                var field = type!.GetField($"Item{i}");
                Assert.False(field!.IsInitOnly);

                var value = GetRandomValue<T>(rand);

                field.SetValue(obj, value);
                Assert.Equal(value, (T) field.GetValue(obj)!);
            }

            // Indexer
            obj = Activator.CreateInstance(type!);
            for (int i = 0; i < channels; i++)
            {
                var pi = type!.GetProperties(BindingFlags.Public | BindingFlags.Instance)
                    .First(pp => 
                        pp.GetIndexParameters()
                            .Select(pr => pr.ParameterType)
                            .SequenceEqual([typeof(int)]));

                var value = GetRandomValue<T>(rand);
                pi.SetValue(obj, value, [i]);
                Assert.Equal(value, (T)pi.GetValue(obj, new object[]{i})!);
            }
        }

        static string GetTypeString<T>()
            where T : unmanaged
        {
            if (typeof(T) == typeof(byte))
                return "b";
            if (typeof(T) == typeof(short))
                return "s";
            if (typeof(T) == typeof(ushort))
                return "w";
            if (typeof(T) == typeof(int))
                return "i";
            if (typeof(T) == typeof(float))
                return "f";
            if (typeof(T) == typeof(double))
                return "d";
            throw new NotSupportedException("Invalid type");
        }

        static T GetRandomValue<T>(Random random)
            where T : unmanaged
        {
            if (typeof(T) == typeof(byte))
                return (T)(object)(byte)random.Next(byte.MinValue, byte.MaxValue);
            if (typeof(T) == typeof(short))
                return (T)(object)(short)random.Next(short.MinValue, short.MaxValue);
            if (typeof(T) == typeof(ushort))
                return (T)(object)(ushort)random.Next(ushort.MinValue, ushort.MaxValue);
            if (typeof(T) == typeof(int))
                return (T)(object)random.Next();
            if (typeof(T) == typeof(float))
                return (T)(object)(float)random.NextDouble();
            if (typeof(T) == typeof(double))
                return (T)(object)random.NextDouble();
            throw new NotSupportedException("Invalid type");
        }
    }
}
