using System.Text.RegularExpressions;

namespace EzCodeProblems.Util
{
    public static class Util
    {
        /// <summary>
        /// Courtesy of chadGPT. Replaces body of a method with the given string.
        /// </summary>
        public static string ReplaceMethodBody(string input, string newBody)
        {
            string temp = Regex.Replace(input, @"//.*?$|/\*.*?\*/", match =>
            {
                return new string(' ', match.Length);  // Replace comments with spaces to keep character positions
            }, RegexOptions.Singleline | RegexOptions.Multiline);

            // Step 2: Replace method body
            string output = Regex.Replace(temp, @"(?<=\{)(?:[^{}]*\{[^{}]*\}[^{}]*|[^{}]*)*(?=\})", newBody);

            // Step 3: Restore original comments
            output = Regex.Replace(output, @"[ ]{2,}", match =>
            {
                int length = match.Length;
                return input.Substring(match.Index, length);  // Restore original comment content based on match length
            });

            return output;
        }
    }
}
