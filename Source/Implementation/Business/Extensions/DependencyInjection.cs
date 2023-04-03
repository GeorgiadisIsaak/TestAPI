using Business.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Business.Extensions
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddBusiness(this IServiceCollection services, IConfiguration configuration)
        {
            return services.AddScoped<IDummyService, DummyService>();
        }
    }
}
