using ProyectPractices.Models;
using System.ComponentModel.DataAnnotations;

namespace ProyectPractices.DTOs
{
    public class GrupoGetListDTO
    {
        [Required]
        public int Id { get; set; }
        [StringLength(maximumLength: 5)]
        public string Nombre { get; set; }
        [Required]
        public int MaestroId { get; set; }
        public List<Alumno> Alumnos { get; set; }
    }
}
