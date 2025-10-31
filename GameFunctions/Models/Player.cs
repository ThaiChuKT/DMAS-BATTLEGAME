using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GameFunctions.Models
{
    public class Player
    {
        [Key]
        public int Id { get; set; }

        [Required, MaxLength(100)]
        public string PlayerName { get; set; } = null!;

        [MaxLength(200)]
        public string? FullName { get; set; }

        public int Age { get; set; }

        public int CurrentLevel { get; set; }

        public ICollection<PlayerAsset>? PlayerAssets { get; set; }
    }
}