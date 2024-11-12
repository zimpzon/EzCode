using EzCodeProblems.Exceptions;
using EzCodeProblems.Util;

namespace EzCodeProblems.Problems.Generic
{
    public abstract class Problem
    {
        public const string WriteYourCodeHereComment = "// write your code here";

        public enum ProblemCategory { Ez, NotSoEz };

        public abstract ProblemCategory Category { get; }

        public abstract string MethodComments { get; }
        public abstract string MethodName { get; }

        public string GetProblemAsStringWithoutSolution()
        {
            var methodInfo = GetType().GetMethod(MethodName) ??
                throw new MalformedProblemException($"Method name {MethodName} does not exist");

            var parameterList = methodInfo.GetParameters().Select(param => $"{EzUtil.GetPrettyTypeName(param.ParameterType)} {param.Name}");
            string parameterString = string.Join(", ", parameterList);
            string sig = $"{EzUtil.GetPrettyTypeName(methodInfo.ReturnType)} {methodInfo.Name}({parameterString})";

            return $"{MethodComments}\n{sig}\n{{\n    {WriteYourCodeHereComment}\n}}\n";
        }
    }
}
