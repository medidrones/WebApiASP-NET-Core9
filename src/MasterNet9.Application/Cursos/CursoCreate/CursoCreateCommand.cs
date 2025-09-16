using MasterNet9.Domain;
using MasterNet9.Persistence;
using MediatR;

namespace MasterNet9.Application.Cursos.CursoCreate;

public class CursoCreateCommand
{
    public record CursoCreateCommandRequest(CursoCreateRequest cursoCreateRequest) 
        : IRequest<Guid>;

    internal class CursoCreateCommandHandler : IRequestHandler<CursoCreateCommandRequest, Guid>
    {
        private readonly MasterNet9DbContext _context;

        public CursoCreateCommandHandler(MasterNet9DbContext context)
        {
            _context = context;
        }

        public async Task<Guid> Handle(CursoCreateCommandRequest request, CancellationToken cancellationToken)
        {
            var curso = new Curso
            {
                Id = Guid.NewGuid(),
                Titulo = request.cursoCreateRequest.Titulo,
                Descripcion = request.cursoCreateRequest.Descripcion,
                FechaPublicacion = request.cursoCreateRequest.FechaPublicacion,
            };

            _context.Add(curso);

            await _context.SaveChangesAsync(cancellationToken);

            return curso.Id;
        }
    }
}
