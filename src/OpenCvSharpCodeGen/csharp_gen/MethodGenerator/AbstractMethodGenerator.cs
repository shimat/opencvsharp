using System.Reflection;

namespace ExceptionSafeGenerator
{
    /// <summary>
    /// Defines a class as string given a Method Generator
    /// TODO: Currently no reason to use inheritance or non-static functions. Might selete this class and make children static 
    /// </summary>
    abstract class AbstractMethodGenerator
    {
        protected const string EXC_PREFIX = "_excsafe";
        public AbstractMethodGenerator()
        {
        }


        abstract public string generateMethod(MethodInfo methodInfo);
    }


}


