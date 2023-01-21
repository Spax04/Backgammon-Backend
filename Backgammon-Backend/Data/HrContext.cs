using Backgammon_Backend.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Backgammon_Backend.Data
{
    public class HrContext : DbContext
    {
        public HrContext(DbContextOptions<HrContext> options) : base(options)
        {
        }

        public DbSet<User>? Users { get; set; }
        public DbSet<Player>? Players { get; set; }
        public DbSet<Game>? Games { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            //// Create Users Entity with data
            builder.Entity<User>().HasData(
                new {
                    UserID = Guid.NewGuid().ToString(),
                    NickName = "Danik",
                    Email = "danielbedrack@gmail.com",
                    Password = "Daniel227",
                    PhotoFileName = @"\Assets\Users\DanielBedrackImg.jpg" },
                 new
                 {
                     UserID = Guid.NewGuid().ToString(),
                     NickName = "Shasha",
                     Email = "gotlib14@gmail.com",
                     Password = "Ww1020",
                     PhotoFileName = @"\Assets\Users\AlexGotlibImg.jpeg" },
                 new
                 {
                     UserID = Guid.NewGuid().ToString(),
                     NickName = "Aviguli",
                     Email = "margolinavigail@gmail.com",
                     Password = "Avigail227",
                     PhotoFileName = @"\Assets\Users\AvigailMargolinImg.jpeg" }                                
                ) ;
            //// Create Game Entity
            builder.Entity<Game>();

            //// Create Player Entity
            builder.Entity<Player>();
               
        }
        
    }
}
