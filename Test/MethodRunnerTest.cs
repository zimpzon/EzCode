using EzCodeProblems;
using EzCodeProblems.Util;

namespace Test
{
    public class MethodRunnerTest
    {
        [Fact]
        public void Test1()
        {
            // Create problem (oh noes).
            // Call Verify() on problem
            // Returns: a list of verifications, indicating pass or fail.
            var problem = new Problem0001();
            string abc = Util.ReplaceMethodBody(problem.ProblemMethod, "\n    // write your code here\n");

            string userText = problem.GetUserFormattedMethod();
            Assert.Contains(problem.MethodComments, userText);

            RoslynExecutor re = new RoslynExecutor();
        }
    }
}