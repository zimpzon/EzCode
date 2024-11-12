using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace EzCodeFuncApp.Functions
{
    public class SolutionVerifier
    {
        private readonly ILogger<SolutionVerifier> _logger;

        public SolutionVerifier(ILogger<SolutionVerifier> logger)
        {
            _logger = logger;
        }

        [Function("SolutionVerifier")]
        public IActionResult Run([HttpTrigger(AuthorizationLevel.Anonymous, "get", "post")] HttpRequest req)
        {
            _logger.LogInformation("C# HTTP trigger function processed a request.");
            return new OkObjectResult("Welcome to Azure Functions!");
        }
    }
}
