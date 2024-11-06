namespace EzCodeProblems
{
    public class Problem1 : Problem
    {
        public override string AsTextWithSolution { get; } =
            """
            // Starting small. Return the sum of a + b.
            public int Sum(int a, int b)
            {
                return a + b;
            }
            """;

        public override string VerificationsAsJson { get; } =
            """
            [
                {
                    "input": [ 2, 3 ],
                    "output": [ 5 ]
                },
                {
                    "input": [ 10, -1 ],
                    "output": [ 9 ]
                }
            ]
            """;
    }
}
