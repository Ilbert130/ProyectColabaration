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
            CreateMap<Grupo, GrupoGetDTOBasic>();
            CreateMap<GrupoPostDTO, Grupo>();
            CreateMap<GrupoPutDTO, Grupo>(); 
            CreateMap<Materia, MateriaGetDTO>();
            CreateMap<MateriaPostDTO, Materia>();
            CreateMap<MateriaPutDTO, Materia>();
            CreateMap<AlumnoPostDTO, Alumno>()
                .ForMember(a => a.MateriaAlumnos, opcion => opcion.MapFrom(AlumnoPostDTOAlumno));
            CreateMap<Alumno, AlumnoGetDTO>();

        }


        private List<MateriaAlumno> AlumnoPostDTOAlumno(AlumnoPostDTO alumnoPostDTO, Alumno alumno)
        {
            List<MateriaAlumno> materiaAlumnos = new List<MateriaAlumno>();

            foreach(var i in alumnoPostDTO.MateriaIds)
            {
                materiaAlumnos.Add(new MateriaAlumno() { MateriaId = i });
            }

            return materiaAlumnos;
        }
    }
}
