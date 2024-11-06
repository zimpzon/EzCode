using EzCodeProblems;

namespace Test
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            var p1 = new Problem1();
            string userText = p1.GetProblemTextWithoutSolution();
            var ver = Problem.Verification.CreateList(p1.VerificationsAsJson);

            Console.WriteLine("");
        }
    }
}