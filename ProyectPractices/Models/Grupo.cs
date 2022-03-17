namespace ProyectPractices.Models
{
    public class Grupo
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int MaestroId { get; set;}
        public Maestro Maestro { get; set; }
        public List<Alumno> Alumnos { get; set; }
    }
}
