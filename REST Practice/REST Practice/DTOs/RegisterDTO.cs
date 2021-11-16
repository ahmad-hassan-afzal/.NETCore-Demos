using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace REST_Practice.DTOs
{
    public class RegisterDTO : LoginDTO
    {
        [Required]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Password Mismatch")]
        public string ConfirmPassword { get; set; }
    }
}
