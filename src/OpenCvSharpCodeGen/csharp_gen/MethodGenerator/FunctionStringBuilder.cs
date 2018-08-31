using System;
using System.Reflection;

using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace ExceptionSafeGenerator
{
    /// <summary>
    /// Builds a function-string 
    /// </summary>
    /// <remarks>
    /// </remarks>
    class FunctionStringBuilder
    {

        public Type returnType
        { get; set; }
        private List<string> parameterList = new List<string>();
        public string attributes { get; set; } = "";
        public string methodName;
        public string body { get; set; } = ";";
        public string modifier { get; set; } = "";

        // Since reflection cannot check if the unsafe keyword has been used, check manualy
        private bool isUnsafe = false;

        public FunctionStringBuilder(string name)
        {
            returnType = typeof(void);
            methodName = name;
        }

        /// <summary>
        /// Adds a parameter directly as string
        /// </summary>
        public void AddParameter(string parameter)
        {
            parameterList.Add(parameter);
        }

        /// <summary>
        /// Adds a parameter using a ParameterInfo.
        /// </summary>
        /// <remarks>
        /// Checks which cases are indicated by attributs (e.g. opt, ref etc.)
        /// </remarks>
        public void AddParameter(ParameterInfo info)
        {
            string name = info.Name;
            name = Helper.GetValidName(name);

            string attributes = "";
            string defaultValue = "";
            string keywords = "";
            bool isOut = false, isIn = false, isRef = false;
            // ParameterAttributes attr = info.Attributes;
            System.Attribute[] attrs = (System.Attribute[])info.GetCustomAttributes();
            attrs = System.Attribute.GetCustomAttributes(info);
            List<string> attributeList = new List<string>();
            foreach(var attr in attrs)
            {
                if(attr is MarshalAsAttribute marshalAttr)
                {
                    attributeList.Add($"MarshalAs(UnmanagedType.{marshalAttr.Value})");
                }
                else if(attr is System.Runtime.InteropServices.InAttribute)
                {
                    isIn = true;
                    attributeList.Add("In");
                }
                // parameter is optional
                else if(attr is System.Runtime.InteropServices.OptionalAttribute)
                {
                    defaultValue = $" = {info.DefaultValue}";
                }
                else if(attr is System.Runtime.InteropServices.OutAttribute)
                {
                    isOut = true;
                }
                else
                    throw new Exception($"Unknown Attribute {attr} of parameter  {name}");
            }
            /// TODO violates dry, since used elsewhere
            if(info.ParameterType.IsByRef)
                isRef = true;

            if(isRef && isOut)
                keywords += " out";
            else if (isRef && !isOut)
                keywords += " ref"; 
            else if (isOut)
                attributeList.Add("Out");

            if(attributeList.Count > 0)
            {
                attributes = $"[{Helper.CommaSeparated(attributeList)}]";
            }
            string parameterType = Helper.GetValidType(info.ParameterType.ToString());
            string parameter = $"{attributes}{keywords} {parameterType} {name} {defaultValue}";
            parameterList.Add(parameter);
        }


        /// <summary>
        /// Returns the function to be build as a string
        /// </summary>
        public string Build()
        {
            var functionString = $"{attributes}{GetSignature()}{body}\n\n";
            return functionString;
        }


        private string GetSignature()
        {
            string returnType = GetReturnType(); 
            CheckUnsafe(returnType);
            foreach(string paramString in parameterList)
            {
                CheckUnsafe(paramString);
            }
            string unsafeString = "";
            if(isUnsafe)
                unsafeString = "unsafe ";
            var param = $"({Helper.CommaSeparated(parameterList)})";
            string signature = $"{modifier} {unsafeString}{returnType} {methodName}{param}";
            return signature;
        }

        /// <summary>
        /// Depending on return typ
        /// </summary>
        private string GetReturnType()
        {
            if(returnType == typeof(void))
                return "void";
            else
                return Helper.GetValidType(returnType.ToString());
        }

        /// <summary>
        /// Checks of the type indicated by the string is a pointer, whcih indicates unsafe code
        /// </summary>
        /// <remarks>
        /// Sole thing which could not be retrieved via reflection
        /// </remarks>
        private bool CheckUnsafe(string typeString)
        { 
            if(typeString.Contains("*"))
            {
                this.isUnsafe = true;
                return  true;
            }
            else
            {
                return false;
            }
        }
    }
}