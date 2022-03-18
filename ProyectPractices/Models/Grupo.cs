using System.ComponentModel.DataAnnotations;

namespace ProyectPractices.Models
{
    public class Grupo
    {
        [Required]
        public int Id { get; set; }
        [StringLength(maximumLength:5)]
        public string Nombre { get; set; }
        [Required]
        public int MaestroId { get; set;}
        public Maestro Maestro { get; set; }
        public List<Alumno> Alumnos { get; set; }
    }
}
