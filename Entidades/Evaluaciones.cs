using System;

namespace CorEscuela.Entidades
{
    public class Evaluaciones
    {
        public string ID { get; set; }
        public string Nombre { get; set; }
        public Alumno alumno { get; set; }
        public Asignatura asignatura {get; set;}
        public float nota {get; set;}

        public Evaluaciones()=>ID=Guid.NewGuid().ToString();
    }
}