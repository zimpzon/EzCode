using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Text;
using System.Text;

namespace EzCodeSourceGenerator
{
    internal class SyntaxReceiver : ISyntaxReceiver
    {
        public List<MethodDeclarationSyntax> Methods = new List<MethodDeclarationSyntax>();

        public void OnVisitSyntaxNode(SyntaxNode syntaxNode)
        {
            if (syntaxNode is MethodDeclarationSyntax methodDeclaration &&
                methodDeclaration.Parent is ClassDeclarationSyntax classDeclaration &&
                classDeclaration.Identifier.Text == "Examples")
            {
                Methods.Add(methodDeclaration);
            }
        }
    }

    [Generator]
    internal class SourceGenerator : ISourceGenerator
    {
        public void Initialize(GeneratorInitializationContext context)
        {
            context.RegisterForSyntaxNotifications(() => new SyntaxReceiver());
        }

        public void Execute(GeneratorExecutionContext context)
        {
            Console.WriteLine("haaai");
            if (context.SyntaxReceiver is not SyntaxReceiver receiver)
                return;

            foreach(var method in receiver.Methods)
            {
                string methodName = method.Identifier.Text;
                string methodText = method.ToFullString();

                string source = $$"""
                namespace GeneratedMethods
                {
                    public static class MethodStrings
                    {
                        public static string {{methodName}} = {{methodText}}
                    }
                }
                """;

                context.AddSource($"{methodName}_Generacted.cs", SourceText.From(source, Encoding.UTF8));
            }
        }
    }
}
