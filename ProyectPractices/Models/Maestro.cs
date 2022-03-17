namespace ProyectPractices.Models
{
    public class Maestro
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public Grupo Grupo { get; set; }
        public List<Materia> Materias { get; set; }
    }
}
