using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GameFunctions.Models
{
    public class PlayerAsset
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey(nameof(Player))]
        public int PlayerId { get; set; }
        public Player? Player { get; set; }

        [ForeignKey(nameof(Asset))]
        public int AssetId { get; set; }
        public Asset? Asset { get; set; }

        // Optionally store quantity, acquired date, etc.
        public int Quantity { get; set; } = 1;
    }
}
