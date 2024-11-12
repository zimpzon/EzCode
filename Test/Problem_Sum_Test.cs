using EzCodeProblems;
using EzCodeProblems.Problems;
using EzCodeProblems.Problems.Generic;

namespace Test
{
    public class Problem_Sum_Test
    {
        [Fact]
        public async Task TestProblem_Sum()
        {
            var p = new Problem_Sum();
            string withoutSolution = p.GetProblemAsStringWithoutSolution();

            string sampleSolution =
                """
                    return a + b;
                """;

            string withSolution = withoutSolution.Replace(Problem.WriteYourCodeHereComment, sampleSolution);
            var result = await RoslynExecutor.ExecuteCodeAsync(withSolution, p.MethodName, 3, 4);

            Assert.NotNull(result);
        }
    }
}