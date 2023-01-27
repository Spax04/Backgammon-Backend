using Backgammon_Backend.Models;
using Identity_Models.Users;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace Backgammon_Backend.Data
{
    public class DevDataContext : DbContext
    {
        public DevDataContext(DbContextOptions<DevDataContext> options) : base(options)
        {
        }


        public DbSet<User>? Users { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<User>().Property(x => x.UserId).HasDefaultValueSql("NEWID()");




        }
    }
}
