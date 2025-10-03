using MasterNet9.Application.Core;
using MasterNet9.Application.Interfaces;
using MasterNet9.Persistence.Models;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace MasterNet9.Application.Accounts.GetCurrentUser;

public class GetCurrentUserQuery
{
    public record GetCurrentUserQueryRequest(GetCurrentUserRequest request) : IRequest<Result<Profile>>;

    internal class GetCurrentUserQueryHandler : IRequestHandler<GetCurrentUserQueryRequest, Result<Profile>>
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly ITokenService _tokenService;

        public GetCurrentUserQueryHandler(UserManager<AppUser> userManager, ITokenService tokenService)
        {
            _userManager = userManager;
            _tokenService = tokenService;
        }

        public async Task<Result<Profile>> Handle(GetCurrentUserQueryRequest request, CancellationToken cancellationToken)
        {
            var user = await _userManager.Users.FirstOrDefaultAsync(x => x.Email == request.request.Email, cancellationToken);

            if (user is null) 
                return Result<Profile>.Failure("No se encontro el usuario");

            var profile = new Profile
            {
                NombreCompleto = user.NombreCompleto,
                Email = user.Email,
                Token = await _tokenService.CreateToken(user),
                Username = user.UserName
            };

            return Result<Profile>.Success(profile);
        }
    }
}
