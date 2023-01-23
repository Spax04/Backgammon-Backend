using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backgammon_Backend.Models
{
    public partial class Game
    {
        public Guid GameId { get; set; }
        public string Name { get; set; }    
        public bool Started { get; set; }
    }
}
