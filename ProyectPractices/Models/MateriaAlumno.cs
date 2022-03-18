using System.ComponentModel.DataAnnotations;

namespace ProyectPractices.Models
{
    public class MateriaAlumno
    {
        [Required]
        public int MateriaId { get; set; }
        [Required]
        public int AlumnoId { get; set; }
        public Materia Materia { get; set; }
        public Alumno Alumno { get; set; }
    }
}
