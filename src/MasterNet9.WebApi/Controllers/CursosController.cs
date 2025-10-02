using MasterNet9.Application.Core;
using MasterNet9.Application.Cursos.CursoCreate;
using MasterNet9.Application.Cursos.CursoUpdate;
using MasterNet9.Application.Cursos.GetCursos;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using static MasterNet9.Application.Cursos.CursoCreate.CursoCreateCommand;
using static MasterNet9.Application.Cursos.CursoDelete.CursoDeleteCommand;
using static MasterNet9.Application.Cursos.CursoReportExcel.CursoReportExcelQuery;
using static MasterNet9.Application.Cursos.CursoUpdate.CursoUpdateCommand;
using static MasterNet9.Application.Cursos.GetCurso.GetCursoQuery;
using static MasterNet9.Application.Cursos.GetCursos.GetCursosQuery;

namespace MasterNet9.WebApi.Controllers;

[ApiController]
[Authorize]
[Route("api/cursos")]
public class CursosController : ControllerBase
{
    private readonly ISender _sender;

    public CursosController(ISender sender)
    {
        _sender = sender;
    }

    [HttpGet]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    public async Task<ActionResult<PagedList<CursoResponse>>> PaginationCursos([FromQuery] GetCursosRequest request, CancellationToken cancellationToken)
    {
        var query = new GetCursosQueryRequest { CursosRequest = request };
        var resultado = await _sender.Send(query, cancellationToken);

        return resultado.IsSuccess 
            ? Ok(resultado.Value) 
            : NotFound();
    }

    [HttpPost]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    public async Task<ActionResult<Result<Guid>>> CursoCreate([FromForm] CursoCreateRequest request, CancellationToken cancellationToken)
    {
        var command = new CursoCreateCommandRequest(request);
        var resultado = await _sender.Send(command, cancellationToken); 
        
        return resultado.IsSuccess 
            ? Ok(resultado.Value) 
            : BadRequest();
    }

    [HttpPut("{id}")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    public async Task<ActionResult<Result<Guid>>> CursoUpdate([FromBody] CursoUpdateRequest request, Guid id, CancellationToken cancellationToken)
    {
        var command = new CursoUpdateCommandRequest(request, id);
        var resultado = await _sender.Send(command, cancellationToken);

        return resultado.IsSuccess 
            ? Ok(resultado.Value) 
            : BadRequest();
    }

    [HttpDelete("{id}")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    public async Task<ActionResult<Unit>> CursoDelete(Guid id, CancellationToken cancellationToken)
    {
        var command = new CursoDeleteCommandRequest(id);
        var resultado = await _sender.Send(command, cancellationToken);

        return resultado.IsSuccess 
            ? Ok() 
            : BadRequest();
    }

    [HttpGet("{id}")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    public async Task<ActionResult<CursoResponse>> CursoGet(Guid id, CancellationToken cancellationToken)
    {
        var query = new GetCursoQueryRequest { Id = id };
        var resultado = await _sender.Send(query, cancellationToken);

        return resultado.IsSuccess 
            ? Ok(resultado.Value) 
            : BadRequest();
    }

    [HttpGet("reporte")]
    public async Task<IActionResult> ReporteCSV(CancellationToken cancellationToken)
    {
        var query = new CursoReporteExcelQueryRequest();
        var resultado = await _sender.Send(query, cancellationToken);

        byte[] excelBytes = resultado.ToArray();

        return File(excelBytes, "text/csv", "cursos.csv");
    }
}
