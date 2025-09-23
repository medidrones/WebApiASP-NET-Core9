using MasterNet9.Application.Core;
using MasterNet9.Application.Cursos.CursoCreate;
using MasterNet9.Application.Cursos.GetCursos;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using static MasterNet9.Application.Cursos.CursoCreate.CursoCreateCommand;
using static MasterNet9.Application.Cursos.CursoReportExcel.CursoReportExcelQuery;
using static MasterNet9.Application.Cursos.GetCurso.GetCursoQuery;
using static MasterNet9.Application.Cursos.GetCursos.GetCursosQuery;

namespace MasterNet9.WebApi.Controllers;

[ApiController]
[Route("api/cursos")]
public class CursosController : ControllerBase
{
    private readonly ISender _sender;

    public CursosController(ISender sender)
    {
        _sender = sender;
    }

    [HttpGet]
    public async Task<ActionResult> PaginationCursos([FromQuery] GetCursosRequest request, CancellationToken cancellationToken)
    {
        var query = new GetCursosQueryRequest { CursosRequest = request };
        var resultado = await _sender.Send(query, cancellationToken);

        return resultado.IsSuccess ? Ok(resultado.Value) : NotFound();
    }

    [HttpPost("create")]
    public async Task<ActionResult<Result<Guid>>> CursoCreate([FromForm] CursoCreateRequest request, CancellationToken cancellationToken)
    {
        var command = new CursoCreateCommandRequest(request);

        return await _sender.Send(command, cancellationToken);        
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> CursoGet(Guid id, CancellationToken cancellationToken)
    {
        var query = new GetCursoQueryRequest { Id = id };
        var resultado = await _sender.Send(query, cancellationToken);

        return resultado.IsSuccess ? Ok(resultado.Value) : BadRequest();
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
