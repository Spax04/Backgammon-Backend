using Chat_Models.Models;
using Microsoft.EntityFrameworkCore;

namespace Chat_DAL.Data
{
    public class ChatDataContext : DbContext
    {
        public ChatDataContext(DbContextOptions<ChatDataContext> options) : base(options)
        {

        }
        
        public DbSet<Chat>? Chats { get; set; }
        public DbSet<Message>? Messages { get; set; }
        public DbSet<Chatter>? Chatters { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}