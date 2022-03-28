using System.ComponentModel.DataAnnotations;

namespace ProyectPractices.DTOs
{
    public class GrupoGetDTOBasic
    {
        [Required]
        public int Id { get; set; }
        [StringLength(maximumLength: 5)]
        public string Nombre { get; set; }
        public MaestroGetDTO Maestro { get; set; }
    }
}
