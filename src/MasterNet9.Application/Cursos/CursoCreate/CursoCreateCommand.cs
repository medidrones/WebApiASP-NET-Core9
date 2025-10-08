using FluentValidation;
using MasterNet9.Application.Core;
using MasterNet9.Application.Interfaces;
using MasterNet9.Domain;
using MasterNet9.Persistence;
using MediatR;

namespace MasterNet9.Application.Cursos.CursoCreate;

public class CursoCreateCommand
{
    public record CursoCreateCommandRequest(CursoCreateRequest cursoCreateRequest) 
        : IRequest<Result<Guid>>, ICommandBase;

    internal class CursoCreateCommandHandler : IRequestHandler<CursoCreateCommandRequest, Result<Guid>>
    {
        private readonly MasterNet9DbContext _context;
        private readonly IPhotoService _photoService;

        public CursoCreateCommandHandler(MasterNet9DbContext context, IPhotoService photoService)
        {
            _context = context;
            _photoService = photoService;
        }

        public async Task<Result<Guid>> Handle(CursoCreateCommandRequest request, CancellationToken cancellationToken)
        {
            var cursoId = Guid.NewGuid();

            var curso = new Curso
            {
                Id = cursoId,
                Titulo = request.cursoCreateRequest.Titulo,
                Descripcion = request.cursoCreateRequest.Descripcion,
                FechaPublicacion = request.cursoCreateRequest.FechaPublicacion,
            };

            if (request.cursoCreateRequest.Foto is not null)
            {
                var photoUploadResult = await _photoService.AddPhoto(request.cursoCreateRequest.Foto);  
                
                var photo = new Photo
                {                   
                    Url = photoUploadResult.Url,
                    PublicId = photoUploadResult.PublicId,
                    CursoId = cursoId
                };
                
                curso.Photos = new List<Photo> { photo };
            }

            if (request.cursoCreateRequest.InstructorId is not null) 
            {
                var intructor = _context.Instructores!.FirstOrDefault(x => x.Id == request.cursoCreateRequest.InstructorId);

                if (intructor is null) 
                {
                    return Result<Guid>.Failure("No se encontró el instructor");
                }

                curso.Instructores = new List<Instructor> { intructor };
            }

            if (request.cursoCreateRequest.PrecioId is not null)
            {
                var precio = _context.Precios!.FirstOrDefault(x => x.Id == request.cursoCreateRequest.PrecioId);

                if (precio is null)
                {
                    return Result<Guid>.Failure("No se encontró el precio");
                }

                curso.Precios = new List<Precio> { precio };
            }

            _context.Add(curso);

            var resultado = await _context.SaveChangesAsync(cancellationToken) > 0;

            return resultado 
                ? Result<Guid>.Success(curso.Id)
                : Result<Guid>.Failure("No se pudo insertar el curso");
        }
    }

    public class CursoCreateCommandRequestValidator : AbstractValidator<CursoCreateCommandRequest>
    {
        public CursoCreateCommandRequestValidator()
        {
            RuleFor(x => x.cursoCreateRequest).SetValidator(new CursoCreateValidator());
        }
    }
}
