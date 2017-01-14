using System;

namespace OpenCvSharp
{
#if !DOTNET_FRAMEWORK
    /// <summary>
    /// Dummy System.Serializable
    /// </summary>
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct)]
    public class SerializableAttribute : Attribute
    {
    }
#endif
}
