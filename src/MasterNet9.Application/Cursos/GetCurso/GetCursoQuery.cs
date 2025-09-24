using AutoMapper;
using AutoMapper.QueryableExtensions;
using MasterNet9.Application.Calificaciones.GetCalificacione;
using MasterNet9.Application.Core;
using MasterNet9.Application.Instructores.GetInstructores;
using MasterNet9.Application.Photos.GetPhoto;
using MasterNet9.Application.Precios.GetPrecios;
using MasterNet9.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace MasterNet9.Application.Cursos.GetCurso;

public class GetCursoQuery
{
    public record GetCursoQueryRequest : IRequest<Result<CursoResponse>>
    {
        public Guid Id { get; set; }
    }

    internal class GetCursoQueryHandler : IRequestHandler<GetCursoQueryRequest, Result<CursoResponse>>
    {
        private readonly MasterNet9DbContext _context;
        private readonly IMapper _mapper;

        public GetCursoQueryHandler(MasterNet9DbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Result<CursoResponse>> Handle(GetCursoQueryRequest request, CancellationToken cancellationToken)
        {
            var curso = await _context.Cursos!.Where(x => x.Id == request.Id)
                .Include(x => x.Instructores)
                .Include(x => x.Precios)
                .Include(x => x.Calificaciones)
                .Include(x => x.Photos)
                .ProjectTo<CursoResponse>(_mapper.ConfigurationProvider)
                .FirstOrDefaultAsync(cancellationToken);

            return Result<CursoResponse>.Success(curso!);
        }
    }

    public record CursoResponse(
        Guid Id, 
        string Titulo, 
        string Descripcion,         
        DateTime? FechaPublicacion,
        List<InstructorResponse> Intructores,
        List<CalificacionResponse> Calificaciones,
        List<PrecioResponse> Precios,
        List<PhotoResponse> Photos)
    {
        // Construtor vazio exigido pelo framework
        public CursoResponse() : this(Guid.Empty, string.Empty, string.Empty, null,
            new List<InstructorResponse>(), new List<CalificacionResponse>(),
            new List<PrecioResponse>(), new List<PhotoResponse>())
        { }
    }
}
