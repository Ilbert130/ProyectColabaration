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

        DbSet<Alumno> Alumnos { get; set; }
        DbSet<Maestro> Maestro { get; set; }
        DbSet<Grupo> Grupos { get; set; }
        DbSet<Materia> Materias { get; set; }
        DbSet<MateriaAlumno> MateriaAlumnos { get; set; }
    }
}
