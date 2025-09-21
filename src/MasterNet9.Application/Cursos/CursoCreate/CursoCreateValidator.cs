using FluentValidation;

namespace MasterNet9.Application.Cursos.CursoCreate;

public class CursoCreateValidator : AbstractValidator<CursoCreateRequest>
{
    public CursoCreateValidator()
    {
        RuleFor(x => x.Titulo)
            .NotEmpty().WithMessage("El título no debe estar vacío")
            .MaximumLength(100).WithMessage("El título no debe exceder los 100 caracteres");       
        RuleFor(x => x.Descripcion)
            .NotEmpty().WithMessage("La descripción no debe estar vacía");
    }
}
