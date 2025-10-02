using MasterNet9.Application.Calificaciones.GetCalificacione;
using MasterNet9.Application.Calificaciones.GetCalificaciones;
using MasterNet9.Application.Core;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using static MasterNet9.Application.Calificaciones.GetCalificacione.GetCalificacionesQuery;

namespace MasterNet9.WebApi.Controllers;

[ApiController]
[Route("api/calificaciones")]
public class CalificacionesController : ControllerBase
{
    private readonly ISender _sender;

    public CalificacionesController(ISender sender)
    {
        _sender = sender;
    }

    [AllowAnonymous]
    [HttpGet]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    public async Task<ActionResult<PagedList<CalificacionResponse>>> PaginationCalificacion([FromQuery] GetCalificacionesRequest request, CancellationToken cancellationToken)
    {
        var query = new GetCalificacionesQueryRequest { CalificacionesRequest = request };
        var resultados = await _sender.Send(query, cancellationToken);

        return resultados.IsSuccess 
            ? Ok(resultados.Value) 
            : NotFound();
    }
}
