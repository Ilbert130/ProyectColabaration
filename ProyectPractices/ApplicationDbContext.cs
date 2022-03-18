using Microsoft.EntityFrameworkCore;
using ProyectPractices.Models;

namespace ProyectPractices
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<MateriaAlumno>().HasKey(x => new { x.MateriaId, x.AlumnoId });
        }

        public DbSet<Alumno> Alumnos { get; set; }
        public DbSet<Maestro> Maestro { get; set; }
        public DbSet<Grupo> Grupos { get; set; }
        public DbSet<Materia> Materias { get; set; }
        public DbSet<MateriaAlumno> MateriaAlumnos { get; set; }
    }
}
