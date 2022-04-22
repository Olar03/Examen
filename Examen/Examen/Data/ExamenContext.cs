using Examen.Data.Entities;
using Microsoft.EntityFrameworkCore;



namespace Examen.Data
{
    public class ExamenContext : DbContext
    {


        public ExamenContext(DbContextOptions<ExamenContext> options) : base(options)
        {
        }

        public DbSet<Entrance> Entrances { get; set; }
        public DbSet<Ticket> Tickets { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Entrance>().HasIndex(e => e.Id).IsUnique();
            modelBuilder.Entity<Entrance>().HasIndex(t => t.Id).IsUnique();

        }

    }
}
