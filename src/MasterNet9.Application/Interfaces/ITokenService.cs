using MasterNet9.Persistence.Models;

namespace MasterNet9.Application.Interfaces;

public interface ITokenService
{
    Task<string> CreateToken(AppUser user);
}
