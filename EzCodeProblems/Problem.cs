using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis;
using System.Text.Json;
using EzCodeProblems.Exceptions;

namespace EzCodeProblems
{
    public abstract class Problem
    {
        public class Verification
        {
            public static readonly List<Verification> EmptyList = [];

            public IReadOnlyList<object> Input { get; init; } = [];
            public IReadOnlyList<object> Output { get; init; } = [];

            public static List<Verification> CreateList(string json)
                => string.IsNullOrWhiteSpace(json) ? EmptyList : JsonSerializer.Deserialize<List<Verification>>(json) ?? EmptyList;
        }

        public abstract string AsTextWithSolution { get; }
        public abstract string VerificationsAsJson { get; }

        /// <summary>
        /// Takes the text with the full solution and removes the code, returning just the empty method.
        /// </summary>
        public string GetProblemTextWithoutSolution()
        {
            var syntaxTree = CSharpSyntaxTree.ParseText(AsTextWithSolution);
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

            return functionWithEmptyBodyAsString;
        }
    }
}
