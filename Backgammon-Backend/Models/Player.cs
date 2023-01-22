using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backgammon_Backend.Models
{
    public partial class Player
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid PlayerId { get; set; }

        public int NumOfGames { get; set; }

        public int NumOfWins { get; set; }

        public Guid UserId { get; set; }

        [ForeignKey("UserId")]
        public virtual User? User { get; set; }

        public Guid GameId { get; set; }

        [ForeignKey("GameId")]
        public virtual Game? Game { get; set; }

        


    }
}
