﻿using Microsoft.EntityFrameworkCore;
using Repositories.Contracts;
using Repositories.EFCore;
using Services;
using Services.Contracts;
using WebApi.Repositories;

namespace WebApi.Extensions
{
    public static class ServicesExtensions
    {
        public static void ConfigureSqlContext(this IServiceCollection services,IConfiguration configuration)
        {
            services.AddDbContext<RepositoryContext>(opt =>
            {
                opt.UseSqlServer(configuration.GetConnectionString("sqlConnection"));
            });
        }
        public static void ConfigureRepositoryManager(this IServiceCollection services)
            => services.AddScoped<IRepositoryManager, RepositoryManager>();

        public static void ConfigureServiceManager(this IServiceCollection services)
           => services.AddScoped<IServiceManager, ServiceManager>();

        public static void ConfigureLogService(this IServiceCollection services)
          => services.AddSingleton<ILoggerService, LoggerManager>();

    }
}
