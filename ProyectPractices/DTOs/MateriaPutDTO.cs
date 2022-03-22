﻿using System.ComponentModel.DataAnnotations;

namespace ProyectPractices.DTOs
{
    public class MateriaPutDTO
    {
        [Required]
        public int Id { get; set; }
        [StringLength(maximumLength: 15)]
        public string Nombre { get; set; }
    }
}
