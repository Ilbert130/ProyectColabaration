using System.ComponentModel.DataAnnotations;

namespace ProyectPractices.DTOs
{
    public class AlumnoPostDTO
    {
        [StringLength(maximumLength: 16)]
        public string Nombre { get; set; }
        [StringLength(maximumLength: 16)]
        public string Apellido { get; set; }
        public List<int> MateriaIds { get; set; }
    }
}
