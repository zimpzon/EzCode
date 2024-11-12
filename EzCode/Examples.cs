namespace EzCode
{
    // ideas:
    //  count characters inside html tags: <html>abc</html> = 3
    //  are html tags paired correctly? <html></html> = ok, <html></html2> = wong
    //  are letters/numbers in sequence? (12345, abcde)
    //  count each letter: hello = h,1 + e,2 + l,2 + 0,1
    //  sum numbers as string and return sum as string - "3" + "2" = "5"
    //  return number backwards: 1234 -> 4321
    // FizzBuzz
    public class Examples
    {
        /// <summary>
        /// Return the count of character 'letter' in string 'text'.
        /// 'a' and 'A' are considered two different characters.
        /// </summary>
        public static int CountCharacter(string text, char character)
        {
            return text.Count(l => l == character);
        }
    }
}
