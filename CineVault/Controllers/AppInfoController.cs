
using Microsoft.AspNetCore.Mvc;

namespace CineVault.Controllers
{
    [ApiController]
    [Route("api/appinfo")]
    public class AppInfoController : ControllerBase
    {
        private readonly IWebHostEnvironment environment;
        private readonly IConfiguration configuration;

        public AppInfoController(
            IWebHostEnvironment environment,
            IConfiguration configuration)
        {
            this.environment = environment;
            this.configuration = configuration;
        }

        [HttpGet("environment")]
        public IActionResult GetEnvironment()
        {
            string? connectionString = configuration
                .GetConnectionString("DefaultConnection");

            string? databaseName = null;

            if (!string.IsNullOrWhiteSpace(connectionString))
            {
                var parts = connectionString.Split(';');

                foreach (var part in parts)
                {
                    if (part.Trim().StartsWith(
                        "Database=",
                        StringComparison.OrdinalIgnoreCase))
                    {
                        databaseName = part.Trim()
                            .Substring("Database=".Length);

                        break;
                    }
                }
            }

            return Ok(new
            {
                Environment = environment.EnvironmentName,
                Database = databaseName,
                ConnectionConfigured =
                    !string.IsNullOrWhiteSpace(connectionString)
            });
        }
    }
}
