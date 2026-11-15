

using Asp.Versioning.ApiExplorer;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace CineVault.Configurations
{
    public class ConfigureSwaggerOptions :
        IConfigureOptions<SwaggerGenOptions>
    {
        private readonly IApiVersionDescriptionProvider provider;

        public ConfigureSwaggerOptions(
            IApiVersionDescriptionProvider provider)
        {
            this.provider = provider;
        }

        public void Configure(SwaggerGenOptions options)
        {
            foreach (var description in provider.ApiVersionDescriptions)
            {
                options.SwaggerDoc(
                    description.GroupName,
                    new OpenApiInfo
                    {
                        Title = "CineVault API",
                        Version = description.ApiVersion.ToString(),
                        Description = description.IsDeprecated
                            ? "DEPRECATED — This version is no longer supported. Use the latest version."
                            : "The current stable version of the API."
                    });
            }
        }
    }
}
