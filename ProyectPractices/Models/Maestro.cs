using System.ComponentModel.DataAnnotations;

namespace ProyectPractices.Models
{
    public class Maestro
    {
        [Required]
        public int Id { get; set; }
        [StringLength(maximumLength:15)]
        public string Nombre { get; set; }
        [StringLength(maximumLength: 15)]
        public string Apellido { get; set; }
        public Grupo Grupo { get; set; }
        public List<Materia> Materias { get; set; }
    }
}
