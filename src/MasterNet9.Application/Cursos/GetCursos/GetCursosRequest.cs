using MasterNet9.Application.Core;

namespace MasterNet9.Application.Cursos.GetCursos;

public class GetCursosRequest : PagingParams
{
    public string? Titulo { get; set; }
    public string? Descripcion { get; set; }
}
