using FluentValidation;
using MasterNet9.Application.Core;
using MasterNet9.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace MasterNet9.Application.Cursos.CursoUpdate;

public class CursoUpdateCommand
{
    public record CursoUpdateCommandRequest(CursoUpdateRequest CursoUpdateRequest, Guid? CursoId) 
        : IRequest<Result<Guid>>;

    internal class CursoUpdateCommandHandler : IRequestHandler<CursoUpdateCommandRequest, Result<Guid>>
    {
        private readonly MasterNet9DbContext _context;

        public CursoUpdateCommandHandler(MasterNet9DbContext context)
        {
            _context = context;
        }

        public async Task<Result<Guid>> Handle(CursoUpdateCommandRequest request, CancellationToken cancellationToken)
        { 
            var cursoId = request.CursoId;
            var curso = await _context.Cursos!.FirstOrDefaultAsync(x => x.Id == cursoId);

            if (curso is null) 
                return Result<Guid>.Failure("El curso no existe");

            curso.Descripcion = request.CursoUpdateRequest.Descripcion;
            curso.Titulo = request.CursoUpdateRequest.Titulo;
            curso.FechaPublicacion = request.CursoUpdateRequest.FechaPublicacion;

            _context.Entry(curso).State = EntityState.Modified;

            var resultado = await _context.SaveChangesAsync() > 0;

            return resultado 
                ? Result<Guid>.Success(curso.Id) 
                : Result<Guid>.Failure("No se pudo actualizar el curso");
        }
    }

    public class CursoUpdateCommandValidator : AbstractValidator<CursoUpdateCommandRequest>
    {
        public CursoUpdateCommandValidator()
        {
            RuleFor(x => x.CursoUpdateRequest).SetValidator(new CursoUpdateValidator());
            RuleFor(x => x.CursoId).NotNull();
        }
    }
}
