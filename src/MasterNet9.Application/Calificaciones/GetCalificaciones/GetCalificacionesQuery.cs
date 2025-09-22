namespace MasterNet9.Application.Calificaciones.GetCalificacione;

public record CalificacionResponse(
    string? Alumno,
    int? Puntaje,
    string? Comentario,
    string? NombreCurso)
{
    public CalificacionResponse() : this(null, null, null, null) 
    { }
}
