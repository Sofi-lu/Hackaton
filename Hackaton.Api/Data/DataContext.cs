using Hackaton.Shared.Enties;
using Microsoft.EntityFrameworkCore;

namespace Hackaton.Api.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {


        }

        public DbSet<Equipo> Equipos { get; set; }
        public DbSet<Mentor> Mentores { get; set; }
        public DbSet <Proyecto> Proyectos { get; set; }
        public DbSet<Hackatonn> Hackatones { get; set; }
        public DbSet<Evaluacion> Evaluaciones { get; set; }
        public DbSet<Participante> Participantes { get; set; }
        public DbSet<Premio> Premios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
        //para poder conectarnos

    }
}
