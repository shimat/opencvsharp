using System;
using System.Reflection;

namespace ExceptionSafeGenerator
{
    class InnerNativeMethodGenerator : AbstractMethodGenerator
    {
        /// <summary>
        /// Returns a string defining the exception safe Version of the function(s , some are overloaded)
        /// </summary>
        /// <remarks>
        /// This are the functions defining the call using p/invoke
        /// This consists of: 
        ///   all names of function altered by postfix excSafe or similar
        ///     all functions return bool regardless what previous ret value
        ///     for "void" functions:
        ///         no alteration to signatures, except that they return bool
        ///     for "type*" function:
        ///         use "ref IntPtr" parameter at position 0  to store the pointer 
        ///     for "type" function:
        ///         add a "ref type" parameter at position 0 
        /// </remarks>
        /// <example>
        /// <code>
        /// [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        /// public static extern System.Boolean f(ref System.IntPtr ret,  System.IntPtr a );
        /// </code>
        /// </example>
        public override string GenerateMethod(MethodInfo methodInfo)
        {
            string methodName = methodInfo.Name;
            string newMethodName = $"{methodName}{EXC_PREFIX}";
            FunctionStringBuilder builder = new FunctionStringBuilder(newMethodName);
            // seems always the same, TODO: check for possible exceptions
            builder.attributes = "[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]\n";
            builder.modifier = "public static extern";
            builder.returnType = typeof(bool);
            Type returnValueType = methodInfo.ReturnType;
            string returnValueString = Helper.GetValidType(returnValueType.ToString());
            // Depending on return value
            if(returnValueType != typeof(void))
            {
                /// if returnValueType is a pointer, always use IntPtr 
                if(returnValueType.IsPointer)
                {
                    builder.AddParameter($"ref IntPtr ret");            
                }
                else
                {
                    builder.AddParameter($"ref {returnValueString} ret");
                }
            }
            foreach(ParameterInfo paramInfo in methodInfo.GetParameters())
            {   
                builder.AddParameter(paramInfo);
            } 
            return builder.Build();
        }
    }
}
