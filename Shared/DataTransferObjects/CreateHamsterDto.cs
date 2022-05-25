using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DataTransferObjects
{
    public class CreateHamsterDto
    {
        [Required(ErrorMessage = "Name must be provided")]
        public string? Name { get; set; }
        
        [Required(ErrorMessage = "Image must be provided")]
        public string? ImageUrl { get; set; }
        
        [Range(1,5, ErrorMessage = "Age must be provided, and must be between 1-5")]
        public int Age { get; set; }
        
        [Required(ErrorMessage = "Loves must be provided")]
        public string? Loves { get; set; }
        
        [Required(ErrorMessage = "Favorite Food must be provided")]
        public string? FavoriteFood { get; set; }

    }
}
