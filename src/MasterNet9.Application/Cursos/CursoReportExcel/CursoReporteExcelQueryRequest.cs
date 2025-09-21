using MasterNet9.Application.Interfaces;
using MasterNet9.Domain;
using MasterNet9.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace MasterNet9.Application.Cursos.CursoReportExcel;

public class CursoReportExcelQuery
{
    public record CursoReporteExcelQueryRequest : IRequest<MemoryStream>;

    internal class CursoReporteExcelHandler : IRequestHandler<CursoReporteExcelQueryRequest, MemoryStream>
    {
        private readonly MasterNet9DbContext _context;
        private readonly IReportService<Curso> _reportService;

        public CursoReporteExcelHandler(MasterNet9DbContext context, IReportService<Curso> reportService)
        {
            _context = context;
            _reportService = reportService;
        }

        public async Task<MemoryStream> Handle(CursoReporteExcelQueryRequest request, CancellationToken cancellationToken)
        {
            var cursos = await _context.Cursos!.Take(10).Skip(0).ToListAsync(cancellationToken);

            return await _reportService.GetCsvReport(cursos);
        }
    }
}
