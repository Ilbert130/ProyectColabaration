using System.ComponentModel.DataAnnotations;

namespace ProyectPractices.DTOs
{
    public class GrupoPostDTO
    {
        [StringLength(maximumLength: 5)]
        public string Nombre { get; set; }
    }
}
