using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;

namespace OpenMind.WebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers();

            builder.Services.AddApiVersioning(options =>
            {
                options.DefaultApiVersion = new ApiVersion(1, 0);
                options.AssumeDefaultVersionWhenUnspecified = true;
                options.ReportApiVersions = true;
                options.ApiVersionReader = new UrlSegmentApiVersionReader();
            });

            builder.Services.AddVersionedApiExplorer(options =>
            {
                options.GroupNameFormat = "'v'VVV";
                options.SubstituteApiVersionInUrl = true;
            });

            builder.Services.AddOpenApiDocument(options =>
            {
                options.DocumentName = "v1";
                options.PostProcess = document =>
                {
                    document.Info.Title = "OpenMind API Server";
                    document.Info.Description = "ASP.NET Core Web API for OpenMind";
                    document.Info.Version = "v1";
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
                options.ApiGroupNames = new[] { "v1" };
            });

            builder.Services.AddOpenApiDocument(options =>
            {
                options.DocumentName = "v2";
                options.PostProcess = document =>
                {
                    document.Info.Title = "OpenMind API Server";
                    document.Info.Description = "ASP.NET Core Web API for OpenMind";
                    document.Info.Version = "v2";
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
                options.ApiGroupNames = new[] { "v2" };
            });

            var app = builder.Build();

            app.UseOpenApi();
            app.UseSwaggerUi3();

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}