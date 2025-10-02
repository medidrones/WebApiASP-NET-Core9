using MasterNet9.Application.Interfaces;
using MasterNet9.Infrastructure.Security;
using MasterNet9.Persistence;
using MasterNet9.Persistence.Models;
using Microsoft.AspNetCore.Identity;

namespace MasterNet9.WebApi.Extensions;

public static class IdentityServiceExtension
{
    public static IServiceCollection AddIdentityServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddIdentityCore<AppUser>(opt =>
        {
            opt.Password.RequireNonAlphanumeric = false;
            opt.User.RequireUniqueEmail = true;
        }).AddRoles<IdentityRole>().AddEntityFrameworkStores<MasterNet9DbContext>();

        services.AddScoped<ITokenService, TokenService>();
        services.AddScoped<IUserAccessor, UserAccessor>();

        return services;
    }
}
