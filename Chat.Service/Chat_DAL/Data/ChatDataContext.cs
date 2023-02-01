using Chat_Models.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

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

            /*  builder.Entity<Chatter>()
         .HasMany(ch => ch.Chats)
         .WithOne(c => c.ChatterOne)
         .HasForeignKey(c => c.ChatterOneId);

              builder.Entity<Chatter>()
                  .HasMany(ch => ch.Chats)
                  .WithOne(c => c.ChatterTwo)
                  .HasForeignKey(c => c.ChatterTwoId);*/

            builder.Entity<Chatter>()
        .HasMany(ch => ch.Chats)
        .WithOne();
        }
    }
}