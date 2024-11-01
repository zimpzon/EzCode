namespace EzCode
{
    // list of test [input + output]
    public class Problem
    {
        public Type ReturnType { get; init; }
        public string FunctionName { get; init; }
        public string Description { get; init; }
    }

    internal static class Problems
    {
        public static readonly List<Problem> List = [
            new Problem { }
        ];
    }
}
