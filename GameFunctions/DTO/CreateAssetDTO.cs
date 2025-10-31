// Dtos/CreateAssetDto.cs
using System.ComponentModel.DataAnnotations;

namespace GameFunctions.DTO
{
    public class CreateAssetDTO
    {
        [Required(ErrorMessage = "AssetName is required.")]
        public string AssetName { get; set; } = null!;

        [MaxLength(500)]
        public string? Description { get; set; }
    }
}
