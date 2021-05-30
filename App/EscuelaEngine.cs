using System;
using System.Collections.Generic;
using CorEscuela.Entidades;
using static System.Console;
using System.Linq;

namespace CorEscuela
{
    public class EscuelaEngine
    {
        public Escuela escuela { get; set; }
        public EscuelaEngine()
        {
            
        }

        public void Inicializar()
        {
            this.escuela=new Escuela("Platzi Academy",2021,TiposEscuela.Secundaria,
            pais:"México", ciudad:"Guadalajara");//Se puede colocar en cualquier orden caprichoso
            Console.WriteLine(escuela.ToString());
            WriteLine("Escuela.Hash "+escuela.GetHashCode()); //Es un hash y  esto lo tienen todos los objetos
            //La probabilidad de que se repita es mínima, pero si sucede y puede usarse para borrar en .Remove()
            CargarCursos();
            CargarAsignaturas();
            CargarEvaluaciones();
            
        }

        private void CargarCursos()
        {
            escuela.Cursos=new List<Curso>(){
                new Curso(){Nombre="101", Jornada=TiposJornada.Mañana},
                new Curso(){Nombre="201",Jornada=TiposJornada.Mañana},
                new Curso{Nombre="301",Jornada=TiposJornada.Mañana}
            };
            Random rnd =new Random();
            int cantidadRandom=rnd.Next(5,20);
            foreach(var c in escuela.Cursos)
            {
                c.alumnos=GenerarAlumnosAlAzar(cantidadRandom);
            }
            
            //escuela.Cursos.Add(new Curso(){Nombre="202",Jornada=TiposJornada.Tarde});
            /*
            var otraColeccion=new List<Curso>(){
                new Curso(){Nombre="401", Jornada=TiposJornada.Mañana},
                new Curso(){Nombre="501",Jornada=TiposJornada.Mañana},
                new Curso{Nombre="502",Jornada=TiposJornada.Tarde}
            };

            //Agrega una lista del mismo tipo fusinandolas
            escuela.Cursos.AddRange(otraColeccion);//Casi cualquier coleccion es un IEnnumerable, por ejemplo unalista

            //El que retorne verdadero es el que va a borrar
            escuela.Cursos.RemoveAll(delegate(Curso cur){ return cur.Nombre=="301";}); 
            escuela.Cursos.RemoveAll((Curso cur) => cur.Nombre=="101"); //Lamba al final tambien es un delegadp
            escuela.Cursos.RemoveAll((cur) => cur.Nombre=="201"||cur.Jornada==TiposJornada.Mañana); //Puede no definir el tipo ya que lo identifica por la lista
            //Un delegado como predicate, determina que parametros de entrada y salida deben haber
            private static bool Predicado(Curso curso) //Linea 41 y esto funcionan igual
            {
            return curso.Nombre=="301";
            } 
            */            
        }

        private void CargarAsignaturas()
        {
            foreach(var curso in escuela.Cursos){
                List<Asignatura> listaAsignaturas=new List<Asignatura>(){
                    new Asignatura{Nombre="Matemáticas"},
                    new Asignatura{Nombre="Educación Física"},
                    new Asignatura{Nombre="Castellano"},
                    new Asignatura{Nombre="Ciencias Naturales"}
                };
                //curso.asignaturas.AddRange(listaAsignaturas);
                curso.asignaturas=listaAsignaturas;
            }
        }
        
        private List<Alumno> GenerarAlumnosAlAzar(int cantidad=45)
        {
            string[] nombre1 = { "Alba", "Felipa", "Eusebio", "Farid", "Donald", "Alvaro", "Nicolás" };
            string[] apellido1 = { "Ruiz", "Sarmiento", "Uribe", "Maduro", "Trump", "Toledo", "Herrera" };
            string[] nombre2 = { "Freddy", "Anabel", "Rick", "Murty", "Silvana", "Diomedes", "Nicomedes", "Teodoro" };
            var listaAlumnos=(from n1 in nombre1
                            from n2 in nombre2
                            from  ap in apellido1
                            select new Alumno{Nombre=$"{n1} {n2} {ap}"});
            return listaAlumnos.OrderBy( (a1)=>a1.ID ).Take(cantidad).ToList();
            //throw new NotImplementedException();
        }

        private void CargarEvaluaciones()
        {
            List<Evaluaciones> eva = new List<Evaluaciones>();
            foreach (var curso in escuela.Cursos)
            {
                
                foreach (var asig in curso.asignaturas)
                {
                    foreach (var alumno in curso.alumnos)
                    {
                        //Requiere inicializar par guardar una lista
                        alumno.evaluaciones = new List<Evaluaciones>();

                        Random rnd =new Random(System.Environment.TickCount);
                        for (int i = 0; i < 5; i++)
                        {
                            var ev = new Evaluaciones()
                            {
                                asignatura=asig,
                                Nombre=$"{asig.Nombre} Ev#{i+1}",
                                nota=(float)(5*rnd.NextDouble()),
                                alumno=alumno 
                            };
                            alumno.evaluaciones.Add(ev);

                        }
                        
                    }
                    
                }
            }
            

        }//Fin de cargar evaluaciones

        
    }//Fin de clase
}