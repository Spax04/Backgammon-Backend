using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Chat_Models.Models
{
    public class ChatConnection
    {
        [Key]
        public string ChatId { get; set; }
        public Guid ChatterId { get; set; }
        public bool IsClosed { get; set; }
        public DateTime StartedAt { get; set; }
        public DateTime EndedAt { get; set; }

        [ForeignKey("ChatterId")]
        public virtual Chatter? Chatter { get; set; }
        public virtual ICollection<Message>? Messages { get; set; }

    }
}