using EzCodeProblems.Problems.Generic;

namespace EzCodeProblems.Problems
{
    public class Problem_Sum : Problem
    {
        public override ProblemCategory Category => ProblemCategory.Ez;

        public override string MethodComments => "// Return the sum of a and b.";
        public override string MethodName { get; } = nameof(Sum);

        public static int Sum(int a, int b)
        {
            return a + b;
        }
    }
}
