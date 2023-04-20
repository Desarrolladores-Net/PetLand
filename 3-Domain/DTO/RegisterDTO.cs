using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.DTO
{
    public class RegisterDTO
    {
        [Required(ErrorMessage = "Necesitamos tu nombre")]
        public string Fullname { get; set; }
        [Required(ErrorMessage = "Necesitamos tu email para continuar")]
        [EmailAddress(ErrorMessage = "Esto no es un email")]
        public string Email { get; set; }
        public string Phone { get; set; }
        [Required (ErrorMessage = "Necesitas una contraseña para proteger tu cuenta")]
        [MinLength (8, ErrorMessage = "Tu contraseña debe tener al menos 8 caracteres")]
        public string Password { get; set; }


    }
}