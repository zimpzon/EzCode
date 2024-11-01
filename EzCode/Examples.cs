namespace EzCode
{
    public class Examples
    {
        /// <summary>
        /// Return the count of character 'letter' in string 'text'.
        /// Consider upper and lower case characters identical.
        /// 'text' and 'letter' will always be within a..z
        /// </summary>
        public static int CountLetter(string text, char letter)
        {
            char letterLower = letter.ToString().ToLower().First();
            return text.ToLower().Count(l => l == letterLower);
        }

        public static string FizzBuzz(int n)
        {
            const string Fizz = "Fizz";
            const string Buzz = "Buzz";

            bool isDivisibleBy_3 = n % 3 == 0;
            bool isDivisibleBy_5 = n % 5 == 0;
            bool isDivisibleBy_15 = isDivisibleBy_3 && isDivisibleBy_5;

            string result;

            if (isDivisibleBy_15)
            {
                result = $"{Fizz}{Buzz}";
            }
            else if (isDivisibleBy_3)
            {
                result = $"{Fizz}";
            }
            else if (isDivisibleBy_5)
            {
                result = $"{Buzz}";
            }
            else
            {
                result = $"{n}";
            }

            return result;
        }
    }
}
