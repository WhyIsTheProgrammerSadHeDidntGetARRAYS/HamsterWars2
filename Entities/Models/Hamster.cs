using System.ComponentModel.DataAnnotations;

namespace Entities.Models
{
    public class Hamster
    {
        [Key]
        public int Id { get; set; }
        
        [Required(ErrorMessage = "Name must be provided")]
        [MaxLength(50)]
        public string? Name { get; set; }
        [Required(ErrorMessage = "Image must be provided.")]
        public string? ImageUrl { get; set; }
        public int Likes { get; set; } // TODO: Remove Likes, this property is not needed
        [Range(1, 5,
            ErrorMessage = "Age must be between 1-5")]
        public int Age { get; set; }
        [Required(ErrorMessage = "Loves must be provided.")]
        [MaxLength(50)]
        public string? Loves { get; set; }
        
        [Required(ErrorMessage = "Favorite food must be provided")]
        [Display(Name = "Favorite Food")]
        [MaxLength(50)]
        public string? FavoriteFood { get; set; }
        public int TotalGames { get; set; }
        public int Wins { get; set; }
        public int Defeats { get; set; }
    }
}
