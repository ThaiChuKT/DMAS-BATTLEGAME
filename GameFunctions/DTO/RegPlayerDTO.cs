using System.ComponentModel.DataAnnotations;

namespace GameFunctions.DTO
{
    public class RegPlayerDto
    {
        [Required(ErrorMessage = "PlayerName is required.")]
        public string PlayerName { get; set; } = null!;

        [MaxLength(200)]
        public string? FullName { get; set; }

        [Range(1, 120, ErrorMessage = "Age must be between 1 and 120.")]
        public int Age { get; set; }

        [Range(1, 999, ErrorMessage = "CurrentLevel must be between 1 and 999.")]
        public int CurrentLevel { get; set; }
    }
}
