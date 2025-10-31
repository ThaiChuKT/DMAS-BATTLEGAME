using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GameFunctions.Models
{
    public class Asset
    {
        [Key]
        public int Id { get; set; }

        [Required, MaxLength(150)]
        public string AssetName { get; set; } = null!;

        public string? Description { get; set; }

        public ICollection<PlayerAsset>? PlayerAssets { get; set; }
    }
}
