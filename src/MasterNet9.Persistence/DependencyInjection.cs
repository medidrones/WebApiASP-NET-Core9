﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace MasterNet9.Persistence;

public static class DependencyInjection
{
    public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<MasterNet9DbContext>(opt =>
        {
            opt.LogTo(Console.WriteLine, new[]
            {
                DbLoggerCategory.Database.Command.Name
            }, LogLevel.Information).EnableSensitiveDataLogging();

            opt.UseSqlite(configuration.GetConnectionString("SqliteDatabase"));
        });                    
        
        return services;
    }
}
