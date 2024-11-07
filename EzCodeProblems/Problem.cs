using Microsoft.CodeAnalysis;
using EzCodeProblems.Exceptions;

namespace EzCodeProblems
{
    public abstract class Problem
    {
        public enum ProblemCategory { Ez, NotSoEz };

        public abstract ProblemCategory Category { get; }

        public abstract string MethodComments { get; }

        public abstract string GetUserFormattedMethod();

        protected string GetUserFormattedMethod(string methodName)
        {
            var methodInfo = GetType().GetMethod(methodName) ??
                throw new MalformedProblemException($"Method name {methodName} does not exist");

            var parameterList = methodInfo.GetParameters().Select(param => $"{GetPrettyTypeName(param.ParameterType)} {param.Name}");
            string parameterString = string.Join(", ", parameterList);
            string sig = $"{GetPrettyTypeName(methodInfo.ReturnType)} {methodInfo.Name}({parameterString})";

            return $"{MethodComments}\n{sig}\n{{\n    // write your code here\n}}\n";
        }

        private static string GetPrettyTypeName(Type type)
        {
            if (type.IsGenericType)
            {
                string genericArguments = type.GetGenericArguments()
                                    .Select(x => TypeCommonName(x.Name))
                                    .Aggregate((x1, x2) => $"{x1}, {x2}");
                return $"{type.Name[..type.Name.IndexOf('`')]}" // backtick in generic type names
                     + $"<{genericArguments}>";
            }
            return type.Name;
        }

        /// <summary>
        /// Replace selected names like 'String' with 'string'.
        /// </summary>
        private static string TypeCommonName(string name)
        {
            return name switch
            {
                "String" => "string",
                _ => name,
            };
        }
    }
}
