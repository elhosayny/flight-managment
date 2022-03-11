using FlightManagement.Domain.Interfaces;
using FlightManagement.Infrastructure.UOW;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace FlightManagement.Infrastructure
{
    public static class InfrastructureDependencyInjectionExtension
    {
        public static void AddInfrastructure(this IServiceCollection services)
        {
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddDbContext<ApplicationDbContext>(options => options.UseInMemoryDatabase(databaseName: "FlightManagementDb"));
        }
    }
}
