using System;
using System.Collections.Generic;

namespace CorEscuela.Entidades
{
    public class Asignatura
    {
        public string ID { get; set; }
        public string Nombre { get; set; }
        public List<Asignatura> asignaturas {set; get;}        

        public Asignatura()=>ID=Guid.NewGuid().ToString();
    }
}