using System.ComponentModel.DataAnnotations;

namespace Backgammon_Backend.Models
{
    public class Game
    {
        [Key]
        public Guid GameId { get; set; }
        public bool Started { get; set; }
    }
}
