using System.Reflection.Metadata;

namespace EzCode
{
    public class InputParameter
    {
        public required Type Type { get; init; }
        public required string Name { get; init; }
    }

    public class Function
    {
        public required string Name { get; init; }
        public required List<Parameter> Parameters { get; init; }
        public required Type ReturnType { get; init; }
    }

    public class VerificationTest
    {
        public required List<object> InputParameters { get; init; }
        public required object ExpectedOutput { get; init; }
    }

    public class Problem
    {
        public required Function Function { get; init; }
        public required string Description { get; init; }
        public required List<VerificationTest> VerificationTests { get; init; }
    }

    internal static class Problems
    {
        public static readonly List<Problem> List = [];
    }
}
