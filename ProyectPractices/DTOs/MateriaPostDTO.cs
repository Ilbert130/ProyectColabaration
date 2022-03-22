using System.ComponentModel.DataAnnotations;

namespace ProyectPractices.DTOs
{
    public class MateriaPostDTO
    {
        [StringLength(maximumLength: 15)]
        public string Nombre { get; set; }
    }
}
