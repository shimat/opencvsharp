using System;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using Xunit;

namespace OpenCvSharp.Tests
{
    public sealed class PlatformSpecificFactAttribute : FactAttribute
    {
        public string[] TargetPlatformNames { get; }

        public PlatformSpecificFactAttribute(params string[] targetPlatformNames)
        {
            if (targetPlatformNames.Length == 0)
                throw new ArgumentException($"Empty array", nameof(targetPlatformNames));
            TargetPlatformNames = targetPlatformNames;

            var targetPlatforms = targetPlatformNames.Select(OSPlatformExtensions.FromString).ToArray();
            if (targetPlatforms.All(pf => !RuntimeInformation.IsOSPlatform(pf)))
            {
                Skip = $"Only running in {string.Join(" or ", targetPlatforms)}.";
            }
        }
    }

    // ReSharper disable once UnusedMember.Global
    public sealed class PlatformSpecificStaFactAttribute : StaFactAttribute
    {
        public string[] TargetPlatformNames { get; }

        public PlatformSpecificStaFactAttribute(params string[] targetPlatformNames)
        {
            if (targetPlatformNames.Length == 0)
                throw new ArgumentException($"Empty array", nameof(targetPlatformNames));
            TargetPlatformNames = targetPlatformNames;

            var targetPlatforms = targetPlatformNames.Select(OSPlatformExtensions.FromString).ToArray();
            if (targetPlatforms.All(pf => !RuntimeInformation.IsOSPlatform(pf)))
            {
                Skip = $"Only running in {string.Join(" or ", targetPlatforms)}.";
            }
        }
    }

    // ReSharper disable once UnusedMember.Global
    public sealed class PlatformSpecificTheoryAttribute : TheoryAttribute
    {
        public string[] TargetPlatformNames { get; }

        public PlatformSpecificTheoryAttribute(params string[] targetPlatformNames)
        {
            if (targetPlatformNames.Length == 0)
                throw new ArgumentException($"Empty array", nameof(targetPlatformNames));
            TargetPlatformNames = targetPlatformNames;

            var targetPlatforms = targetPlatformNames.Select(OSPlatformExtensions.FromString).ToArray();
            if (targetPlatforms.All(pf => !RuntimeInformation.IsOSPlatform(pf)))
            {
                Skip = $"Only running in {string.Join(" or ", targetPlatforms)}.";
            }
        }
    }

    internal static class OSPlatformExtensions
    {
        public static OSPlatform FromString(string platformName)
        {
            var properties = typeof(OSPlatform).GetProperties(BindingFlags.Public | BindingFlags.Static);
            var property = properties.FirstOrDefault(p => p.Name == platformName);
            var value = (OSPlatform)(property?.GetValue(null) ?? throw new InvalidOperationException());
            return value;
        }
    }
}