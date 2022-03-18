using System.ComponentModel.DataAnnotations;

namespace ProyectPractices.Models
{
    public class Materia
    {
        [Required]
        public int Id { get; set; }
        [StringLength(maximumLength: 15)]
        public string Nombre { get; set; }
        [Required]
        public int MaestroId { get; set; }
        public Maestro Maestro { get; set; }
        public List<MateriaAlumno> MateriaAlumnos { get; set; }
    }
}
