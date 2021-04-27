namespace MvcSampleWithTest.WebApi
{
    using System.Reflection;
    using System.Text.Json;
    using MediatR;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;
    using Microsoft.OpenApi.Models;
    using MvcSampleWithTest.Application;
    using MvcSampleWithTest.Integration;

    public class Startup
    {
        public Startup(IConfiguration configuration) =>
            this.Configuration = configuration;

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddHealthChecks();

            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddApplication();
            services.AddInfrastructure(this.Configuration);

            services.AddControllers(options =>
                {
                    options.Filters.Add<ApiExceptionFilterAttribute>();
                }).AddJsonOptions(option =>
                {
                    option.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
                    option.JsonSerializerOptions.WriteIndented = true;
                });

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "MVC Sample with Test API",
                    Version = "v1",
                });
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("v1/swagger.json", "MVC Sample with Test API v1"));
            }

            app.UseHealthChecks("/health");

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
