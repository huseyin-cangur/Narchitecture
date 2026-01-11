

using Application.Services.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Contexts;
using Persistence.Repositories;

namespace Persistence
{
    public static class PersistenceServiceRegistiration
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddDbContext<BaseDbContext>(options => options.UseNpgsql(configuration.GetConnectionString("RentACar")));

            

            services.AddScoped<IBrandRepository, BrandRepository>();
            services.AddScoped<ICarRepository, CarRepository>();

            services.AddScoped<IModelRepository, ModelRepository>();

            services.AddScoped<IFuelRepository, FuelRepository>();

            services.AddScoped<ITransmissionRepository, TransmissionRepository>();


            return services;

        }
    }
}