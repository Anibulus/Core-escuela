using System;
using System.Collections.Generic;
using System.Linq;
using CoreEscuela.Entidades;

namespace CoreEscuela
{
    public sealed class EscuelaEngine
    {
        public Escuela Escuela { get; set; }

        public EscuelaEngine()
        {

        }

        public void Inicializar()
        {
            Escuela = new Escuela("Platzi Academay", 2012, TiposEscuela.Primaria,
            ciudad: "Bogotá", pais: "Colombia"
            );

            CargarCursos();
            CargarAsignaturas();
            CargarEvaluaciones();

        }
        #region Métodos de carga
        private void CargarEvaluaciones()
        {

            foreach (var curso in Escuela.Cursos)
            {
                foreach (var asignatura in curso.Asignaturas)
                {
                    foreach (var alumno in curso.Alumnos)
                    {
                        var rnd = new Random(System.Environment.TickCount);

                        for (int i = 0; i < 5; i++)
                        {
                            var ev = new Evaluación
                            {
                                Asignatura = asignatura,
                                Nombre = $"{asignatura.Nombre} Ev#{i + 1}",
                                Nota = (float)(5 * rnd.NextDouble()),
                                Alumno = alumno
                            };
                            alumno.Evaluaciones.Add(ev);
                        }
                    }
                }
            }

        }

        public void ImprimirDiccionario(Dictionary<LlaveDiccionario, IEnumerable<ObjetoEscuelaBase>> dic)
        {
            foreach(var obj in dic)
            {
                Console.WriteLine($"{obj.Key} {obj.Value}");
                foreach(var keyValuePair in obj.Value){
                    Console.WriteLine($"{keyValuePair.Nombre} {keyValuePair.UniqueId}");
                }
            }
        }
        //Se pide <llave, contenido>
        //IEnumerable se utiliza porque Es una interfaz generica de lista
        public Dictionary<LlaveDiccionario, IEnumerable<ObjetoEscuelaBase>> GetDiccionarioObjetos(){
            var diccionario=new Dictionary<LlaveDiccionario,IEnumerable<ObjetoEscuelaBase>>();
            
            #region Ejemplo de casteo con IEnumerable
            IEnumerable<ObjetoEscuelaBase> o=new List<ObjetoEscuelaBase>();
            List<Curso> c=new List<Curso>();

            o=c.Cast<ObjetoEscuelaBase>();
            #endregion

            diccionario.Add(LlaveDiccionario.Escuela, new[] {Escuela});
            diccionario.Add(LlaveDiccionario.Cursos,Escuela.Cursos.Cast<ObjetoEscuelaBase>());
            
            var listaTemp=new List<Evaluación>();
            var listaTempAsig=new List<Asignatura>();
            var listaTempAlu=new List<Alumno>();

            foreach(var item in Escuela.Cursos)
            {
                listaTempAsig.AddRange(item.Asignaturas);
                listaTempAlu.AddRange(item.Alumnos);
                
                foreach(var alum in item.Alumnos)
                {
                    listaTemp.AddRange(alum.Evaluaciones);                    
                }
            }
            diccionario.Add(LlaveDiccionario.Alumnos,listaTempAlu.Cast<ObjetoEscuelaBase>());
            diccionario.Add(LlaveDiccionario.Asignaturas,listaTempAsig.Cast<ObjetoEscuelaBase>());
            diccionario.Add(LlaveDiccionario.Evaluacion,
                                listaTemp.Cast<ObjetoEscuelaBase>());
            return diccionario;
        }
        public IReadOnlyList<ObjetoEscuelaBase> GetObjetosEscuela(
            bool traerEvaluaciones=true,
            bool traerAlumnos=true,
            bool traerAsignaturas=true,
            bool traerCursos=true
            )
        {
            return GetObjetosEscuela(out int dummy, out dummy, out dummy, out dummy);
        }     

        public IReadOnlyList<ObjetoEscuelaBase> GetObjetosEscuela(
            out int conteoEvaluaciones,
            bool traerEvaluaciones=true,
            bool traerAlumnos=true,
            bool traerAsignaturas=true,
            bool traerCursos=true
            )
        {
            return GetObjetosEscuela(out conteoEvaluaciones, out int dummy, out dummy, out dummy);
        }   

        public IReadOnlyList<ObjetoEscuelaBase> GetObjetosEscuela(            
            out int conteoEvaluaciones,
            out int conteoCursos,
            out int conteoAsignaturas,
            out int conteoAlumnos,
            bool traerEvaluaciones=true,
            bool traerAlumnos=true,
            bool traerAsignaturas=true,
            bool traerCursos=true
            )
        {
            //Asignacion multiple
            conteoEvaluaciones=conteoCursos=conteoAsignaturas=conteoAlumnos=0;

            var listaObj = new List<ObjetoEscuelaBase>();
            listaObj.Add(Escuela);
            if(traerCursos)
                listaObj.AddRange(Escuela.Cursos);

            conteoCursos=Escuela.Cursos.Count();
            foreach (var curso in Escuela.Cursos)
            {
                conteoAsignaturas+=curso.Asignaturas.Count();
                conteoAlumnos+=curso.Alumnos.Count();

                if(traerAsignaturas)
                    listaObj.AddRange(curso.Asignaturas);

                if(traerAlumnos)
                    listaObj.AddRange(curso.Alumnos);

                if(traerEvaluaciones)
                    foreach (var alumno in curso.Alumnos)
                    {
                        listaObj.AddRange(alumno.Evaluaciones);
                        conteoEvaluaciones+=alumno.Evaluaciones.Count();
                    }                
            }

            return listaObj.AsReadOnly();
        }

        private void CargarAsignaturas()
        {
            foreach (var curso in Escuela.Cursos)
            {
                var listaAsignaturas = new List<Asignatura>(){
                            new Asignatura{Nombre="Matemáticas"} ,
                            new Asignatura{Nombre="Educación Física"},
                            new Asignatura{Nombre="Castellano"},
                            new Asignatura{Nombre="Ciencias Naturales"}
                };
                curso.Asignaturas = listaAsignaturas;
            }
        }

        private List<Alumno> GenerarAlumnosAlAzar(int cantidad)
        {
            string[] nombre1 = { "Alba", "Felipa", "Eusebio", "Farid", "Donald", "Alvaro", "Nicolás" };
            string[] apellido1 = { "Ruiz", "Sarmiento", "Uribe", "Maduro", "Trump", "Toledo", "Herrera" };
            string[] nombre2 = { "Freddy", "Anabel", "Rick", "Murty", "Silvana", "Diomedes", "Nicomedes", "Teodoro" };

            var listaAlumnos = from n1 in nombre1
                               from n2 in nombre2
                               from a1 in apellido1
                               select new Alumno { Nombre = $"{n1} {n2} {a1}" };

            return listaAlumnos.OrderBy((al) => al.UniqueId).Take(cantidad).ToList();
        }

        private void CargarCursos()
        {
            Escuela.Cursos = new List<Curso>(){
                        new Curso(){ Nombre = "101", Jornada = TiposJornada.Mañana },
                        new Curso() {Nombre = "201", Jornada = TiposJornada.Mañana},
                        new Curso{Nombre = "301", Jornada = TiposJornada.Mañana},
                        new Curso(){ Nombre = "401", Jornada = TiposJornada.Tarde },
                        new Curso() {Nombre = "501", Jornada = TiposJornada.Tarde},
            };

            Random rnd = new Random();
            foreach (var c in Escuela.Cursos)
            {
                int cantRandom = rnd.Next(5, 20);
                c.Alumnos = GenerarAlumnosAlAzar(cantRandom);
            }
        }
        #endregion
    }
}