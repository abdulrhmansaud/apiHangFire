using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hangfire;
using Application.Common.Interfaces;
using Infrastructure.Persistence;
using Infrastructure.Services;

namespace Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {

            var connection = configuration.GetConnectionString("default");
            services.AddDbContext<Dbconnect>(options => options.UseSqlServer(connection));
            services.AddHangfire(opt => opt.UseSqlServerStorage(connection));

            services.AddScoped<IBookRepo, BookRepo>();

            return services;
        }
    }
}
