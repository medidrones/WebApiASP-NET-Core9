using FluentValidation;
using MasterNet9.Application.Core;
using MasterNet9.Application.Interfaces;
using MasterNet9.Persistence.Models;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace MasterNet9.Application.Accounts.Register;

public class RegisterCommand
{
    public record RegisterCommandRequest(RegisterRequest registerRequest) : IRequest<Result<Profile>>;

    internal class RegisterCommandHandler : IRequestHandler<RegisterCommandRequest, Result<Profile>>
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly ITokenService _tokenService;

        public RegisterCommandHandler(UserManager<AppUser> userManager, ITokenService tokenService)
        {
            _userManager = userManager;
            _tokenService = tokenService;
        }

        public async Task<Result<Profile>> Handle(RegisterCommandRequest request, CancellationToken cancellationToken)
        {
            if (await _userManager.Users.AnyAsync(x => x.Email == request.registerRequest.Email))
            {
               Result<Profile>.Failure("El email ya fue registrado por otro usuario");
            }

            if (await _userManager.Users.AnyAsync(x => x.UserName == request.registerRequest.Username))
            {
                Result<Profile>.Failure("El username ya fue registrado por otro usuario");
            }

            var user = new AppUser
            {
                NombreCompleto = request.registerRequest.NombreCompleto,
                Id = Guid.NewGuid().ToString(),
                UserName = request.registerRequest.Username,
                Email = request.registerRequest.Email,
                Carrera = request.registerRequest.Carrera
            };

            var resultado = await _userManager.CreateAsync(user, request.registerRequest.Password!);

            if (resultado.Succeeded)
            {
                await _userManager.AddToRoleAsync(user, "Client");

                var profile = new Profile
                {
                    NombreCompleto = user.NombreCompleto,
                    Email = user.Email,
                    Username = user.UserName,
                    Token = await _tokenService.CreateToken(user)
                };

                return Result<Profile>.Success(profile);
            }

            return Result<Profile>.Failure("No se pudo registrar al usuario");
        }
    }

    public class RegisterCommandRequestValidator : AbstractValidator<RegisterCommandRequest>
    {
        public RegisterCommandRequestValidator()
        {
            RuleFor(x => x.registerRequest).SetValidator(new RegisterValidator());
        }
    }
}
