using Business.Extensions;
using Controllers;
using Microsoft.Extensions.Configuration;
using Microsoft.OpenApi.Models;
using Persistence.Extensions;
using Persistence.Options;
using Swashbuckle.AspNetCore.SwaggerGen;
using Swashbuckle.AspNetCore.SwaggerUI;
using System.Reflection;
using TestAPI.Options;

namespace TestAPI
{
    public class Startup
    {
        private readonly IConfiguration _configuration;

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services) =>
            services.AddCors()
                    .AddSwaggerGen(ConfigureSwagger)
                    .Configure<DummyRepositoryOptions>(_configuration.GetSection(nameof(DummyRepositoryOptions)))
                    .AddPersistence(_configuration)
                    .AddBusiness(_configuration)
                    .AddControllers();

        private void ConfigureSwagger(SwaggerGenOptions options)
        {
            options.SwaggerDoc("v1", new OpenApiInfo
            {
                Version = "v1",
                Title = "My API",
                Description = "An ASP.NET Core Web API for managing my items",
                TermsOfService = new Uri("https://example.com/terms"),
                Contact = new OpenApiContact
                {
                    Name = "Example Contact",
                    Url = new Uri("https://example.com/contact")
                },
                License = new OpenApiLicense
                {
                    Name = "Example License",
                    Url = new Uri("https://example.com/license")
                }
            });

            // Set the comments path for the Swagger JSON and UI.
            var xmlFile = $"{Assembly.GetAssembly(typeof(DummyController)).GetName().Name}.xml";
            var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
            options.IncludeXmlComments(xmlPath);
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseSwagger()
                   .UseSwaggerUI(ConfigureSwaggerUi);

                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/api/exception");
            }

            app.UseHsts()
               .UseHttpsRedirection()
               .UseRouting()
               .UseCors(options => options.WithOrigins(_configuration.GetSection(nameof(CorsOptions)).Get<CorsOptions>().AllowOrigins)) // Whitelist certain URL's 
               .UseEndpoints(endpoints => endpoints.MapControllers());
        }

        private void ConfigureSwaggerUi(SwaggerUIOptions options)
        {
            options.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            options.RoutePrefix = string.Empty;
        }
    }
}
