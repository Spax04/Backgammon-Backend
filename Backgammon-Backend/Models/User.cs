using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Diagnostics;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backgammon_Backend.Models
{
    public class User 
    {
        [Key]
        public Guid UserId { get; set; }
        public string? NickName { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }

        public string? PhotoFileName { get; set; }

        [NotMapped]
        public IFormFile? Image { get; set; }

    }
}
