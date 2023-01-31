using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Chat_Models.Models
{
    public class Chat
    {
        [Key]
        public Guid? ChatId { get; set; }
        public Guid? ChatterId { get; set; }
        public bool IsClosed { get; set; }
        public DateTime StartedAt { get; set; }
        public DateTime EndedAt { get; set; }

    }
}