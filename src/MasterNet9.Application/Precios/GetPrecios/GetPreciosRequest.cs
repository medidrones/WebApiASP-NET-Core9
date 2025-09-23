using MasterNet9.Application.Core;

namespace MasterNet9.Application.Precios.GetPrecios;

public class GetPreciosRequest : PagingParams
{
    public string? Nombre { get; set; }
}
