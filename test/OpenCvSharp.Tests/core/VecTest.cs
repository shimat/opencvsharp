using System;
using System.Linq;
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
                            .SequenceEqual(new []{typeof(int)}));

                var value = GetRandomValue<T>(rand);
                pi.SetValue(obj, value, new object[]{i});
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
