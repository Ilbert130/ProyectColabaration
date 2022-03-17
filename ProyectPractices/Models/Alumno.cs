namespace ProyectPractices.Models
{
    public class Alumno
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int GrupoId { get; set; }
        public Grupo Grupo { get; set; }
        public List<MateriaAlumno> MateriaAlumnos { get; set; }
    }
}
