using System;
using System.Reflection;

using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace ExceptionSafeGenerator
{
    class FunctionStringBuilder
    {
        public Type returnValue
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
            returnValue = typeof(void);
            methodName = name;
        }

        public void addParameter(string parameter)
        {
            parameterList.Add(parameter);
        }

        /// TODO: Should be more elaborate, considering ref, default value, attributes ...
        public void addParameter(ParameterInfo info)
        {
            string name = info.Name;
            name = StringHelper.getValidName(name);

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
                if(attr is MarshalAsAttribute  marshalAttr)
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
            {
                keywords += " out";
            }
            else if (isRef && !isOut)
                keywords += " ref"; 
            else if (isOut)
                attributeList.Add("Out");

            // Check for case that "In" and "Out" in attributes
            //if(keywords.Contains("out") && )
            if(attributeList.Count > 0)
            {
                attributes = $"[{StringHelper.commaSeparated(attributeList)}]";
            }
            string parameterType = StringHelper.getValidType(info.ParameterType.ToString());
            string parameter = $"{attributes}{keywords} {parameterType} {name} {defaultValue}";
            parameterList.Add(parameter);
        }

        public string build()
        {
            var functionString = $"{attributes}{getSignature()}{body}\n\n";
            return functionString;
        }


        private string getSignature()
        {
            string returnType = getReturnType(); 
            checkUnsafe(returnType);
            foreach(string paramString in parameterList)
            {
                checkUnsafe(paramString);
            }
            string unsafeString = "";
            if(isUnsafe)
                unsafeString = "unsafe ";
            var param = $"({StringHelper.commaSeparated(parameterList)})";
            string signature = $"{modifier} {unsafeString}{returnType} {methodName}{param}";
            return signature;
        }


        private string getReturnType()
        {
            if(returnValue == typeof(void))
                return "void";
            else
                return StringHelper.getValidType(returnValue.ToString());
        }

        // Changes member variable as a side effect
        private bool checkUnsafe(string typeString)
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