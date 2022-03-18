using System.ComponentModel.DataAnnotations;

namespace ProyectPractices.Models
{
    public class Alumno
    {
        [Required]
        public int Id { get; set; }
        [StringLength(maximumLength:16)]
        public string Nombre { get; set; }
        [StringLength(maximumLength: 16)]
        public string Apellido { get; set; }
        [Required]
        public int GrupoId { get; set; }
        public Grupo Grupo { get; set; }
        public List<MateriaAlumno> MateriaAlumnos { get; set; }
    }
}
