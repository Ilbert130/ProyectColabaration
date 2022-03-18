using ProyectPractices.Models;
using System.ComponentModel.DataAnnotations;

namespace ProyectPractices.DTOs
{
    public class MaestroGetDTO
    {
        [StringLength(maximumLength: 15)]
        public string Nombre { get; set; }
        [StringLength(maximumLength: 15)]
        public string Apellido { get; set; }
    }
}
