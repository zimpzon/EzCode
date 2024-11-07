using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.Emit;
using Microsoft.CodeAnalysis;
using System.Reflection;
using EzCodeProblems.Exceptions;

namespace EzCodeProblems
{
    public class RoslynExecutor
    {
        public async Task<object?> ExecuteCodeAsync(string code, string methodName, params object[] parameters)
        {
            // Add necessary assemblies and references
            var references = AppDomain.CurrentDomain
                .GetAssemblies()
                .Where(a => !a.IsDynamic)
                .Select(a => MetadataReference.CreateFromFile(a.Location))
                .ToList();

            // Create a syntax tree
            var syntaxTree = CSharpSyntaxTree.ParseText(@$"
        using System;
        using System.Collections.Generic;
        using System.Linq;

        public class DynamicCodeClass
        {{
            {code}
        }}");

            // Create a Roslyn compilation
            var compilation = CSharpCompilation.Create(
                "DynamicCodeAssembly",
                [syntaxTree],
                references,
                new CSharpCompilationOptions(OutputKind.DynamicallyLinkedLibrary)
            );

            // Compile code to memory
            using var ms = new System.IO.MemoryStream();
            EmitResult result = compilation.Emit(ms);

            if (!result.Success)
            {
                var failures = result.Diagnostics.Where(diagnostic =>
                    diagnostic.IsWarningAsError ||
                    diagnostic.Severity == DiagnosticSeverity.Error);

                foreach (var diagnostic in failures)
                {
                    Console.Error.WriteLine(diagnostic.ToString());
                }
                return null;
            }

            // Load the compiled assembly
            ms.Seek(0, System.IO.SeekOrigin.Begin);
            var assembly = Assembly.Load(ms.ToArray());

            // Get the dynamically created class and method
            var type = assembly.GetType("DynamicCodeClass");
            var method = type?.GetMethod(methodName);

            if (method is null)
                throw new MalformedProblemException($"Method {methodName} not found.");

            // Invoke the method with parameters
            return await Task.FromResult(method.Invoke(Activator.CreateInstance(type!), parameters));
        }
    }
}
