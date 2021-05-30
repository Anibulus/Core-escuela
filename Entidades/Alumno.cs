using System;
using System.Collections.Generic;

namespace CorEscuela.Entidades
{
    public class Alumno
    {
        public string ID { get; set; }
        public string Nombre { get; set; }
        public List<Evaluaciones> evaluaciones{ get; set; }

        public Alumno()=>ID=Guid.NewGuid().ToString();
    }
}