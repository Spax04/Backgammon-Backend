using Identity_Models.Users;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace Backgammon_Backend.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
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

