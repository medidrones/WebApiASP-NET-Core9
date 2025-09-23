using AutoMapper;
using AutoMapper.QueryableExtensions;
using MasterNet9.Application.Calificaciones.GetCalificaciones;
using MasterNet9.Application.Core;
using MasterNet9.Domain;
using MasterNet9.Persistence;
using MediatR;
using System.Linq.Expressions;

namespace MasterNet9.Application.Calificaciones.GetCalificacione;

public class GetCalificacionesQuery
{
    public record GetCalificacionesQueryRequest : IRequest<Result<PagedList<CalificacionResponse>>>
    {
        public GetCalificacionesRequest? CalificacionesRequest { get; set; }
    }

    internal class GetCalificacionesQueryHandler : IRequestHandler<GetCalificacionesQueryRequest, Result<PagedList<CalificacionResponse>>>
    {
        private readonly MasterNet9DbContext _context;
        private readonly IMapper _mapper;

        public GetCalificacionesQueryHandler(MasterNet9DbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Result<PagedList<CalificacionResponse>>> Handle(GetCalificacionesQueryRequest request, CancellationToken cancellationToken)
        {
            IQueryable<Calificacion> queryable = _context.Calificaciones!;

            var predicate = ExpressionBuilder.New<Calificacion>();

            if (!string.IsNullOrEmpty(request.CalificacionesRequest!.Alumno))
            {
                predicate = predicate.And(y => y.Alumno!.Contains(request.CalificacionesRequest.Alumno));
            }

            if (request.CalificacionesRequest.CursoId is not null)
            {
                predicate = predicate.And(y => y.CursoId == request.CalificacionesRequest.CursoId);
            }

            if (!string.IsNullOrEmpty(request.CalificacionesRequest.OrderBy))
            {
                Expression<Func<Calificacion, object>>? orderBySelector = request.CalificacionesRequest.OrderBy.ToLower() switch
                {
                    "alumno" => x => x.Alumno!,
                    "curso" => x => x.CursoId!,
                    _ => x => x.Alumno!
                };

                bool orderBy = request.CalificacionesRequest.OrderAsc.HasValue
                    ? request.CalificacionesRequest.OrderAsc.Value
                    : true;

                queryable = orderBy
                    ? queryable.OrderBy(orderBySelector)
                    : queryable.OrderByDescending(orderBySelector);
            }

            queryable = queryable.Where(predicate);

            var calificacionQuery = queryable
                .ProjectTo<CalificacionResponse>(_mapper.ConfigurationProvider)
                .AsQueryable();

            var pagination = await PagedList<CalificacionResponse>
                .CreateAsync(calificacionQuery, request.CalificacionesRequest.PageNumber, request.CalificacionesRequest.PageSize);

            return Result<PagedList<CalificacionResponse>>.Success(pagination);
        }
    }
}

public record CalificacionResponse(
    string? Alumno,
    int? Puntaje,
    string? Comentario,
    string? NombreCurso)
{
    public CalificacionResponse() : this(null, null, null, null) 
    { }
}
