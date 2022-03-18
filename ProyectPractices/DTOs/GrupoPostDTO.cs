using System.ComponentModel.DataAnnotations;

namespace ProyectPractices.DTOs
{
    public class GrupoPostDTO
    {
        [Required]
        public int Id { get; set; }
        [StringLength(maximumLength: 5)]
        public string Nombre { get; set; }
        [Required]
        public int MaestroId { get; set; }
    }
}
