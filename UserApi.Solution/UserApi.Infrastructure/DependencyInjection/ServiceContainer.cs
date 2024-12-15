using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using UserApi.Application.Interfaces;
using UserApi.Infrastructure.Data;
using UserApi.Infrastructure.Repositories;

namespace UserApi.Infrastructure.DependencyInjection
{
    public static class ServiceContainer
    {
        public static IServiceCollection AddInfrastructureService(this IServiceCollection services)
        {
            //add the database string 
            services.AddDbContext<UserDbContext>(options => options.UseSqlServer("usersApiconnection"));
            //add repositories
            services.AddScoped<UserInterface, UserRepository>();
            return services;
        }
    }
}
