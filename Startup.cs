using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using MongoBongo.Models.Config;
using MongoBongo.Services;

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
                .Configure<WorkDbSettings>(Configuration.GetSection(nameof(WorkDbSettings)))
                .AddSingleton<IWorkDbSettings>(sp => sp.GetRequiredService<IOptions<WorkDbSettings>>().Value)
                .AddSingleton<WorkService>();

            services.AddSpaStaticFiles(configuration => configuration.RootPath = "ClientApp");

            services.AddControllers().AddNewtonsoftJson(opt => opt.UseMemberCasing());

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
            {
                app.UseDeveloperExceptionPage();
            }

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
