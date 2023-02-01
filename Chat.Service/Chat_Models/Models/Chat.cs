using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Chat_Models.Models
{
    public class Chat
    {
        [Key]
        public Guid? ChatId { get; set; }
        public Guid? ChatterOneId { get; set; }
        public Guid? ChatterTwoId { get; set; }
        public bool IsClosed { get; set; }
        public DateTime StartedAt { get; set; }
        public DateTime EndedAt { get; set; }

        [ForeignKey("ChatterOneId")]
        public virtual Chatter? ChatterOne { get; set; }
        [ForeignKey("ChatterTwoId")]
        public virtual Chatter? ChatterTwo { get; set; }
        public virtual ICollection<Message>? Messages { get; set; }

    }
}