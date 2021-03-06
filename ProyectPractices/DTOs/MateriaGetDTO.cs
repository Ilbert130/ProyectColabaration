using ProyectPractices.Models;
using System.ComponentModel.DataAnnotations;

namespace ProyectPractices.DTOs
{
    public class MateriaGetDTO
    {
        [Required]
        public int Id { get; set; }
        [StringLength(maximumLength: 15)]
        public string Nombre { get; set; }
        [Required]
        public int MaestroId { get; set; }
        public MaestroGetDTO Maestro { get; set; }
    }
}
