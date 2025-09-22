using FluentValidation;
using FluentValidation.AspNetCore;
using MasterNet9.Application.Core;
using MasterNet9.Application.Cursos.CursoCreate;
using Microsoft.Extensions.DependencyInjection;

namespace MasterNet9.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {        
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(DependencyInjection).Assembly));   
        services.AddFluentValidationAutoValidation();
        services.AddValidatorsFromAssemblyContaining<CursoCreateCommand>();
        services.AddAutoMapper(typeof(MappingProfile).Assembly);

        return services;
    }
}
