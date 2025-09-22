using AutoMapper;
using MasterNet9.Application.Calificaciones.GetCalificacione;
using MasterNet9.Application.Instructores.GetInstructores;
using MasterNet9.Application.Photos.GetPhoto;
using MasterNet9.Application.Precios.GetPrecios;
using MasterNet9.Domain;
using static MasterNet9.Application.Cursos.GetCurso.GetCursoQuery;

namespace MasterNet9.Application.Core;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Curso, CursoResponse>();
        CreateMap<Photo, PhotoResponse>();
        CreateMap<Precio, PrecioResponse>();

        CreateMap<Instructor, InstructorResponse>()
            .ForMember(dest => dest.Apellido, src => src.MapFrom(doc => doc.Apellidos));

        CreateMap<Calificacion, CalificacionResponse>()
            .ForMember(dest => dest.NombreCurso, src => src.MapFrom(doc => doc.Curso!.Titulo));
    }
}
