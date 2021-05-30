using System;
using System.Collections.Generic;

namespace CorEscuela.Entidades
{
    public class Curso
    {
        public string ID { get; private set; }
        public string Nombre { get; set; }
        public TiposJornada Jornada { get; set; }
        public List<Asignatura> asignaturas {get; set;}
        public List<Alumno> alumnos {set; get;}
        
        public Curso()=>ID=Guid.NewGuid().ToString();
    }
}