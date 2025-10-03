using MasterNet9.Application.Accounts;
using MasterNet9.Application.Accounts.GetCurrentUser;
using MasterNet9.Application.Accounts.Login;
using MasterNet9.Application.Accounts.Register;
using MasterNet9.Application.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using static MasterNet9.Application.Accounts.GetCurrentUser.GetCurrentUserQuery;
using static MasterNet9.Application.Accounts.Login.LoginCommand;
using static MasterNet9.Application.Accounts.Register.RegisterCommand;

namespace MasterNet9.WebApi.Controllers;

[ApiController]
[Route("api/account")]
public class AccountController : ControllerBase
{
    private readonly ISender _sender;
    private readonly IUserAccessor _userAccessor;

    public AccountController(ISender sender, IUserAccessor userAccessor)
    {
        _sender = sender;
        _userAccessor = userAccessor;
    }

    [AllowAnonymous]
    [HttpPost("login")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    public async Task<ActionResult<Profile>> Login([FromBody] LoginRequest request, CancellationToken cancellationToken)
    {
        var command = new LoginCommandRequest(request);
        var resultado = await _sender.Send(command, cancellationToken);

        return resultado.IsSuccess ? Ok(resultado.Value) : Unauthorized();
    }

    [AllowAnonymous]
    [HttpPost("register")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    public async Task<ActionResult<Profile>> Register([FromForm] RegisterRequest request, CancellationToken cancellationToken)
    {
        var command = new RegisterCommandRequest(request);
        var resultado = await _sender.Send(command, cancellationToken);

        return resultado.IsSuccess ? Ok(resultado.Value) : Unauthorized();
    }

    [Authorize]
    [HttpGet("me")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    public async Task<ActionResult<Profile>> Me(CancellationToken cancellationToken)
    {
        var email = _userAccessor.GetEmail();
        var request = new GetCurrentUserRequest { Email = email };
        var query = new GetCurrentUserQueryRequest(request);
        var resultado = await _sender.Send(query, cancellationToken);

        return resultado.IsSuccess ? Ok(resultado.Value) : Unauthorized();
    }
}
