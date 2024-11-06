namespace EzCode
{
    public class Problem1 : Problem
    {

        public Dictionary<string, int> GetDict(int a, int b, int c)
        {
            return new() { ["a"] = a, ["b"] = b, ["c"] = c };
        }

        /// <summary>
        /// Plan:
        ///     Remove correct code and present empty method to the user.
        ///     Parse both user code and correct code into Roslyn syntax trees.
        ///     Run both with sample input (defined in code), and verify they agree.
        ///     - This can all be unit tested.
        /// </summary>
        public override string ProblemText { get; } =
//"""
//public class Solution
//{
//    public Dictionary<string, int> GetDict(int a, int b, int c)
//    {
//        // CORRECT_CODE_BEGIN
//        return new() { ["a"] = a, ["b"] = b, ["c"] = c };
//        // CORRECT_CODE_END
//    }
//}
//""";
"""
public Dictionary<string, int> GetDict(int a, int b, int c)
{
    // CORRECT_CODE_BEGIN
    return new() { ["a"] = a, ["b"] = b, ["c"] = c };
    // CORRECT_CODE_END
}
""";
    }
}
