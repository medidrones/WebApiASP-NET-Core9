using MasterNet9.Application.Instructores.GetInstructores;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using static MasterNet9.Application.Instructores.GetInstructores.GetIntructoresQuery;

namespace MasterNet9.WebApi.Controllers;

[ApiController]
[Route("api/instructores")]
public class InstructoresController : ControllerBase
{
    private readonly ISender _sender;

    public InstructoresController(ISender sender)
    {
        _sender = sender;
    }

    [HttpGet]
    public async Task<ActionResult> PaginationInstructor([FromQuery] GetInstructoresRequest request, CancellationToken cancellationToken)
    {
        var query = new GetInstructoresQueryRequest { InstructorRequest = request };
        var resultados = await _sender.Send(query, cancellationToken);

        return resultados.IsSuccess
            ? Ok(resultados.Value)
            : NotFound();
    }
}
