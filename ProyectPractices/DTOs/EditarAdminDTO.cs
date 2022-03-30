using System.ComponentModel.DataAnnotations;

namespace ProyectPractices.DTOs
{
    public class EditarAdminDTO
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
