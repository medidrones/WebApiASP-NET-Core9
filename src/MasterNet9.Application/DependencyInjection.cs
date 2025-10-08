﻿using FluentValidation;
using MasterNet9.Application.Core;
using Microsoft.Extensions.DependencyInjection;

namespace MasterNet9.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {        
        services.AddMediatR(cfg => { 
            cfg.RegisterServicesFromAssembly(typeof(DependencyInjection).Assembly);
            cfg.AddOpenBehavior(typeof(ValidationBehavior<,>));
        });
                
        services.AddValidatorsFromAssembly(typeof(DependencyInjection).Assembly);
        services.AddAutoMapper(typeof(MappingProfile).Assembly);

        return services;
    }
}
