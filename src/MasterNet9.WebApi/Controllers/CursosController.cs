using MasterNet9.Application.Cursos.CursoCreate;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using static MasterNet9.Application.Cursos.CursoCreate.CursoCreateCommand;
using static MasterNet9.Application.Cursos.CursoReportExcel.CursoReportExcelQuery;

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

    [HttpPost("create")]
    public async Task<ActionResult<Guid>> CursoCreate([FromForm] CursoCreateRequest request, CancellationToken cancellationToken)
    {
        var command = new CursoCreateCommandRequest(request);
        var resultado = await _sender.Send(command, cancellationToken);

        return Ok(resultado);
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
