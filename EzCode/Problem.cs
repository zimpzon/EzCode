using EzCode.Exceptions;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis;

namespace EzCode
{
    public abstract class Problem
    {
        /// <summary>
        /// The easy solution is that when we present to code to the user, we remove the correct code
        /// marked by CORRECT_CODE_BEGIN and CORRECT_CODE_END. When we evaluate the user attempt we
        /// run the code as is, since it contains the correct solution.
        /// </summary>
        public abstract string ProblemText { get; }

        public void abc()
        {
            var syntaxTree = CSharpSyntaxTree.ParseText(ProblemText);
            var root = syntaxTree.GetRoot();

            var localFunctionStatements = root.DescendantNodes().OfType<LocalFunctionStatementSyntax>().ToList();
            if (localFunctionStatements.Count != 1)
            {
                throw new MalformedProblemException($"Problems must contain exactly one function for the user to fill in, actual: {localFunctionStatements.Count}");
            }

            var function = localFunctionStatements.Single();
            var functionWithEmptyBody = function.WithBody(null);

            var functionWithEmptyBodyAsString = functionWithEmptyBody.NormalizeWhitespace().ToFullString();
            // We could use Roslyn to add a body containing a comment. Or we can do it the easy way and just add it as a string. Which we will.
            functionWithEmptyBodyAsString += "\n{\n  // write your solution here\n}";

            Console.WriteLine(functionWithEmptyBodyAsString);
        }
    }
}
