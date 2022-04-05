﻿namespace ProyectPractices.DTOs
{
    public class DatoHATEOASDTO
    {
        public string Enlace { get; private set; }
        public string Descripcion { get; private  set; }
        public string Metodo { get;private set; }

        public DatoHATEOASDTO(string enlace, string descripcion, string metodo)
        {
            Enlace = enlace;
            Descripcion = descripcion;
            Metodo = metodo;
        }
    }
}
