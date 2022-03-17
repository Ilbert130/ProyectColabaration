namespace ProyectPractices.Models
{
    public class MateriaAlumno
    {
        public int MateriaId { get; set; }
        public int AlumnoId { get; set; }
        public Materia Materia { get; set; }
        public Alumno Alumno { get; set; }
    }
}
