namespace EzCodeProblems
{
    public class Problem0001 : Problem
    {
        public override ProblemCategory Category => ProblemCategory.Ez;

        public override string MethodComments { get; } =
            """
            // Return a dictionary with char as key, and the number of times this char
            // exists in the string as value. Ex, if the letter 'e' exists 3 times, the
            // dictionary will contain 'e' = 3.
            """;

        public string ProblemMethod { get; } =
            """
            // Return a dictionary with char as key, and the number of times this char
            // exists in the string as value. Ex, if the letter 'e' exists 3 times, the
            // dictionary will contain 'e' = 3.
            /* multi
            comment
            */
            public Dictionary<char, int> CountCharacters(string text)
            {
                var result = new Dictionary<char, int>();

                var distinctChars = text.Distinct();
                foreach (char distinctChar in distinctChars)
                {
                    result[distinctChar] = text.Count(c => distinctChar == c);
                }

                return result;
            }
            """;

        public override string GetUserFormattedMethod()
            => GetUserFormattedMethod(nameof(CountCharacters));

        public static Dictionary<char, int> CountCharacters(string text)
        {
            var result = new Dictionary<char, int>();

            var distinctChars = text.Distinct();
            foreach(char distinctChar in distinctChars)
            {
                result[distinctChar] = text.Count(c => distinctChar == c);
            }

            return result;
        }

        public void Run(string codeFromUser)
        {

        }

        public void Verify(string text, Dictionary<char, int> attempt)
        {

        }
    }
}
