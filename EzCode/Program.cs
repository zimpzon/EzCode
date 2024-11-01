using Microsoft.CodeAnalysis.CSharp.Scripting;
using Microsoft.CodeAnalysis.Scripting;

namespace EzCode
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            string s =
@"
    int Squared2(int n)
{
  return n * n;
}

return Squared(10);
";

            // Add standard references, including System.Core for Linq support
            var options = ScriptOptions.Default
                .AddReferences(
                    typeof(object).Assembly, // mscorlib (core .NET types)
                    typeof(System.Runtime.AssemblyTargetedPatchBandAttribute).Assembly, // System.Runtime (additional core types)
                    typeof(Enumerable).Assembly // System.Core for System.Linq
                )
                .AddImports(
                    "System",
                    "System.Collections.Generic",
                    "System.Linq"
                );

            object evalResult;

            try
            {
                evalResult = await CSharpScript.EvaluateAsync(s, options);
                Console.WriteLine($"evalResult: {evalResult}");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            //Script compiledScript = CSharpScript.Create(s, options);
            //var compiledResult = await compiledScript.RunAsync();

            Console.WriteLine("All done");
            //Console.WriteLine(Examples.CountLetter("Hello, World!", 'L'));
        }
    }
}
