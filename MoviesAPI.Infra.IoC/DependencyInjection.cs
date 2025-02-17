﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MoviesAPI.Infra.Data.Context;

namespace MoviesAPI.Infra.IoC
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services,
           IConfiguration configuration)
        {
            // Pegando a string de conexão do appsettings.json
            var connectionString = configuration.GetConnectionString("DefaultConnection");

            // Registrando o DbContext com a string de conexão correta
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(connectionString));

            return services;

        }
    }
}


