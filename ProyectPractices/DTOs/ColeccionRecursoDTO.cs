namespace ProyectPractices.DTOs
{
    public class ColeccionRecursoDTO<T>:RecursoDTO where T : RecursoDTO
    {
        public List<T> Valores { get; set; }
    }
}
