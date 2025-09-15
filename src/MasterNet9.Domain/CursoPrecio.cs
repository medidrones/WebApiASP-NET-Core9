namespace MasterNet9.Domain;

public class CursoPrecio
{
    public Guid? CursoId { get; set; }
    public Guid? PrecioId { get; set; }

    public Curso? Curso { get; set; }
    public Precio? Precio { get; set; }
}
