using MasterNet9.Application.Core;

namespace MasterNet9.Application.Calificaciones.GetCalificaciones;

public class GetCalificacionesRequest : PagingParams
{
    public string? Alumno { get; set; }
    public Guid? CursoId { get; set; }
}
