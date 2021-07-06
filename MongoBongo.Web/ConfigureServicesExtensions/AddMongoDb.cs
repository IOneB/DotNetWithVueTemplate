using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using MongoBongo.DAL.Services;
using MongoBongo.Db.Settings;

namespace MongoBongo.ConfigureServicesExtensions
{
    public static class AddDbExtension
    {
        public static IServiceCollection AddMongoDb(this IServiceCollection services, IConfiguration configuration)
        {
            return services
                .Configure<WorkDbSettings>(configuration.GetSection(nameof(WorkDbSettings)))
                .AddTransient<ICreateCollectionService, CreateCollectionService>()
                .AddSingleton<IWorkDbSettings>(sp => sp.GetRequiredService<IOptions<WorkDbSettings>>().Value)
                .AddSingleton<WorkService>();
        }
    }
}
