using AutoMapper;
using ProyectPractices.DTOs;
using ProyectPractices.Models;

namespace ProyectPractices.Utilidades
{
    public class AutoMapperProfiles: Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Maestro, MaestroGetDTO>();
            CreateMap<MaestroPostDTO, Maestro>();
            CreateMap<MaestroPutDTO, Maestro>();
            CreateMap<Grupo, GrupoGetDTO>();
            CreateMap<GrupoPostDTO, Grupo>();
            CreateMap<GrupoPutDTO, Grupo>(); 
            CreateMap<Materia, MateriaGetDTO>();
            CreateMap<MateriaPostDTO, Materia>();
            CreateMap<MateriaPutDTO, Materia>();
        }
    }
}
