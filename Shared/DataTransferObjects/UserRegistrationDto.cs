using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DataTransferObjects
{
    public class UserRegistrationDto
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        [Required(ErrorMessage = "Username must be provided.")]
        public string? UserName { get; set; }
        [Required(ErrorMessage = "Password must be provided.")]
        public string? Password { get; set; }
        
        [Compare("Password", ErrorMessage = "The password and confirmation password does not match.")]
        public string? ConfirmPassword { get; set; }
        public string? Email { get; set; }
        //public ICollection<string>? Roles { get; set; }
    }
}
