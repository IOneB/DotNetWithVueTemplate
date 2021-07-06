using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MongoBongo.ConfigureServicesExtensions;

namespace MongoBongo
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services
                .AddMongoDb(Configuration)
                .AddSpaStaticFiles(config => config.RootPath = "wwwroot");

            services.AddControllers();

            services.AddCors(opt =>
            {
                opt.AddPolicy("VueCorsPolicy", builder =>
                {
                    builder.AllowAnyHeader()
                    .AllowAnyMethod()
                    .AllowCredentials()
                    .WithOrigins("https://localhost:5001");
                });
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
                app.UseDeveloperExceptionPage();

            app.UseCors("VueCorsPolicy");

            app.UseAuthentication();
            app.UseRouting();

            app.UseEndpoints(endpoints => endpoints.MapControllers());
            app.UseSpaStaticFiles();

            app.UseSpa(spa =>
            {
                if (env.IsDevelopment())
                {
                    spa.UseProxyToSpaDevelopmentServer("http://localhost:8080");
                }
            });
        }
    }
}
