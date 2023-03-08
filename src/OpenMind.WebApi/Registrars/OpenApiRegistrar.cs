using Microsoft.AspNetCore.Mvc;

namespace OpenMind.WebApi.Registrars
{
    public static class OpenApiRegistrar
    {
        private static readonly ApiVersion[] versions =
        {
            new ApiVersion(1,0),
            new ApiVersion(2,0)
        };

        public static void AddOpenApi(this IServiceCollection services)
        {
            foreach (var version in versions)
            {
                services.AddOpenApiDocument(options =>
                {
                    options.DocumentName = $"v{version:VVV}";
                    options.PostProcess = document =>
                    {
                        document.Info.Title = "OpenMind API Server";
                        document.Info.Description = "ASP.NET Core Web API for OpenMind";
                        document.Info.Version = $"v{version:VVV}";
                        document.Info.TermsOfService = "None";
                        document.Info.Contact = new NSwag.OpenApiContact
                        {
                            Name = "API Server Team",
                            Email = "contact@openmind.com"
                        };
                        document.Info.License = new NSwag.OpenApiLicense
                        {
                            Name = "Use under LICX",
                            Url = "https://www.license.com"
                        };
                    };
                    options.ApiGroupNames = new[] { $"v{version:VVV}" };
                });
            }
        }
    }
}
