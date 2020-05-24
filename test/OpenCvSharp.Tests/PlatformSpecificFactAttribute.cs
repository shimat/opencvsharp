using System;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using Xunit;

namespace OpenCvSharp.Tests
{
    // ReSharper disable once UnusedMember.Global
    public class PlatformSpecificFactAttribute : FactAttribute
    {
        public PlatformSpecificFactAttribute(params string[] targetPlatformNames)
        {
            if (targetPlatformNames == null)
                throw new ArgumentNullException(nameof(targetPlatformNames));
            if (targetPlatformNames.Length == 0)
                throw new ArgumentException($"Empty array", nameof(targetPlatformNames));

            var targetPlatforms = targetPlatformNames.Select(OSPlatformExtensions.FromString).ToArray();
            if (targetPlatforms.All(pf => !RuntimeInformation.IsOSPlatform(pf)))
            {
                Skip = $"Only running in {string.Join(" or ", targetPlatforms)}.";
            }
        }
    }

    // ReSharper disable once UnusedMember.Global
    public class PlatformSpecificStaFactAttribute : StaFactAttribute
    {
        public PlatformSpecificStaFactAttribute(params string[] targetPlatformNames)
        {
            if (targetPlatformNames == null)
                throw new ArgumentNullException(nameof(targetPlatformNames));
            if (targetPlatformNames.Length == 0)
                throw new ArgumentException($"Empty array", nameof(targetPlatformNames));

            var targetPlatforms = targetPlatformNames.Select(OSPlatformExtensions.FromString).ToArray();
            if (targetPlatforms.All(pf => !RuntimeInformation.IsOSPlatform(pf)))
            {
                Skip = $"Only running in {string.Join(" or ", targetPlatforms)}.";
            }
        }
    }

    // ReSharper disable once UnusedMember.Global
    public class PlatformSpecificTheoryAttribute : TheoryAttribute
    {
        public PlatformSpecificTheoryAttribute(params string[] targetPlatformNames)
        {
            if (targetPlatformNames == null)
                throw new ArgumentNullException(nameof(targetPlatformNames));
            if (targetPlatformNames.Length == 0)
                throw new ArgumentException($"Empty array", nameof(targetPlatformNames));

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