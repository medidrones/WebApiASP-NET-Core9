namespace MasterNet9.Application.Photos.GetPhoto;

public record PhotoResponse(
    Guid? Id,
    string? Url,
    Guid? CursoId)
{
    public PhotoResponse() : this(null, null, null)
    { }
}
