using System.ComponentModel.DataAnnotations;

namespace ProyectPractices.DTOs
{
    public class AlumnoGetDTO
    {
        [Required]
        public int Id { get; set; }
        [StringLength(maximumLength: 16)]
        public string Nombre { get; set; }
        [StringLength(maximumLength: 16)]
        public string Apellido { get; set; }
        public GrupoGetDTOBasic Grupo { get; set; }
    }
}
