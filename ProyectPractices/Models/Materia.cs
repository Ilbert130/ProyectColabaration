namespace ProyectPractices.Models
{
    public class Materia
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int MaestroId { get; set; }
        public Maestro Maestro { get; set; }
        public List<MateriaAlumno> MateriaAlumnos { get; set; }
    }
}
