using MasterNet9.Application.Core;

namespace MasterNet9.Application.Instructores.GetInstructores;

public class GetInstructoresRequest : PagingParams
{
    public string? Nombre { get; set; }
    public string? Apellido { get; set; }
}
