using System.Reflection;

namespace ExceptionSafeGenerator
{
    /// <summary>
    /// Defines a class as string given a Method Generator
    /// </summary>
    abstract class AbstractMethodGenerator
    {
        protected const string EXC_PREFIX = "_excsafe";
        public AbstractMethodGenerator()
        {
        }
        abstract public string GenerateMethod(MethodInfo methodInfo);
    }


}


