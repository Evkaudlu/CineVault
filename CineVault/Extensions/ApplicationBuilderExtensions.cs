
using Asp.Versioning.ApiExplorer;

namespace CineVault.Extensions
{
    public static class ApplicationBuilderExtensions
    {
        // Налаштування Swagger для версій API
        public static IApplicationBuilder UseSwaggerWithOptions(
            this IApplicationBuilder app)
        {
            app.UseSwagger();

            app.UseSwaggerUI(options =>
            {
                var provider = app.ApplicationServices
                    .GetRequiredService<IApiVersionDescriptionProvider>();

                foreach (var description in provider.ApiVersionDescriptions)
                {
                    options.SwaggerEndpoint(
                        $"/swagger/{description.GroupName}/swagger.json",
                        $"CineVault API {description.GroupName.ToUpperInvariant()}");
                }
            });

            return app;
        }
    }
}
