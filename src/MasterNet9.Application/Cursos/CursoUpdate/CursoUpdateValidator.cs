using FluentValidation;

namespace MasterNet9.Application.Cursos.CursoUpdate;

public class CursoUpdateValidator : AbstractValidator<CursoUpdateRequest>
{
    public CursoUpdateValidator()
    {
        RuleFor(x => x.Titulo)
            .NotEmpty()
            .WithMessage("El titulo no debe ser vacio");

        RuleFor(x => x.Descripcion)
            .NotEmpty()
            .WithMessage("La descripcion no debe ser vacia");

        RuleFor(x => x.FechaPublicacion)
            .Must(ValidateDateTime) 
            .WithMessage("La fecha de publicacion no debe ser vacia");
    }

    private bool ValidateDateTime(DateTime? date)
    {
        if (date == null) 
            return false;

        if (date == default(DateTime)) 
            return false;

        return true;

    }
}
