using FluentValidation;
using MasterNet9.Application.Core;
using MasterNet9.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace MasterNet9.Application.Cursos.CursoDelete;

public class CursoDeleteCommand
{
    public record CursoDeleteCommandRequest(Guid? CursoId) : IRequest<Result<Unit>>, ICommandBase;

    internal class CursoDeleteCommandHandler : IRequestHandler<CursoDeleteCommandRequest, Result<Unit>>
    {
        private readonly MasterNet9DbContext _context;

        public CursoDeleteCommandHandler(MasterNet9DbContext context)
        {
            _context = context;
        }

        public async Task<Result<Unit>> Handle(CursoDeleteCommandRequest request, CancellationToken cancellationToken)
        {
            var curso = await _context.Cursos!
                .Include(x => x.Instructores)
                .Include(x => x.Precios)
                .Include(x => x.Calificaciones)
                .Include(x => x.Photos)
                .FirstOrDefaultAsync(c => c.Id == request.CursoId);

            if (curso is null) 
                return Result<Unit>.Failure("No se encontró el curso");

            _context.Cursos!.Remove(curso);

            var resultado = await _context.SaveChangesAsync(cancellationToken) > 0;

            return resultado 
                ? Result<Unit>.Success(Unit.Value) 
                : Result<Unit>.Failure("No se pudo eliminar el curso");
        }
    }

    public class CursoDeleteCommandValidator : AbstractValidator<CursoDeleteCommandRequest>
    {
        public CursoDeleteCommandValidator()
        {
            RuleFor(x => x.CursoId)
                .NotNull()
                .WithMessage("El Id del curso no puede estar vacío");
        }
    }
}
