using AutoMapper;
using AutoMapper.QueryableExtensions;
using MasterNet9.Application.Core;
using MasterNet9.Domain;
using MasterNet9.Persistence;
using MediatR;
using System.Linq.Expressions;

namespace MasterNet9.Application.Precios.GetPrecios;

public class GetPreciosQuery
{
   public record GetPreciosQueryRequest : IRequest<Result<PagedList<PrecioResponse>>>
    {
        public GetPreciosRequest? PreciosRequest { get; set; }
    }

    internal class GetPreciosQueryHandler : IRequestHandler<GetPreciosQueryRequest, Result<PagedList<PrecioResponse>>>
    {
        private readonly MasterNet9DbContext _context;
        private readonly IMapper _mapper;

        public GetPreciosQueryHandler(MasterNet9DbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Result<PagedList<PrecioResponse>>> Handle(GetPreciosQueryRequest request, CancellationToken cancellationToken)
        {
            IQueryable<Precio> queryable = _context.Precios!; 
            
            var predicate = ExpressionBuilder.New<Precio>();

            if (!string.IsNullOrEmpty(request.PreciosRequest?.Nombre))
            {
                predicate = predicate.And(x => x.Nombre!.Contains(request.PreciosRequest.Nombre));
            }

            if (!string.IsNullOrEmpty(request.PreciosRequest!.OrderBy))
            {
                Expression<Func<Precio, object>>? orderSelector = request.PreciosRequest.OrderBy.ToLower() switch
                {
                    "nombre" => x => x.Nombre!,
                    "precio" => x => x.PrecioActual!,                   
                    _ => x => x.Nombre!
                };

                bool orderBy = request.PreciosRequest.OrderAsc.HasValue
                    ? request.PreciosRequest.OrderAsc.Value
                    : true;

                queryable = orderBy
                    ? queryable.OrderBy(orderSelector) 
                    : queryable.OrderByDescending(orderSelector);
            }

            queryable = queryable.Where(predicate);

            var preciosQuery = queryable.ProjectTo<PrecioResponse>(_mapper.ConfigurationProvider).AsQueryable();
            var pagination = await PagedList<PrecioResponse>.CreateAsync(
                    preciosQuery, request.PreciosRequest.PageNumber, request.PreciosRequest.PageSize);

            return Result<PagedList<PrecioResponse>>.Success(pagination);
        }
    }
}

public record PrecioResponse(
    Guid? Id,
    string? Nombre,
    decimal? PrecioActual,
    decimal? PrecioPromocion)
{
    public PrecioResponse() : this(null, null, null, null) 
    { }
}
