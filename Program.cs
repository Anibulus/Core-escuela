using System;
using System.Collections.Generic;
using System.Linq;
using CoreEscuela.Entidades;
using CoreEscuela.Util;
using static System.Console;

namespace CoreEscuela
{
    class Program
    {
        static void Main(string[] args)
        {
            var engine = new EscuelaEngine();
            engine.Inicializar();
            Printer.WriteTitle("BIENVENIDOS A LA ESCUELA");
            //Printer.Beep(10000, cantidad: 10);
            ImpimirCursosEscuela(engine.Escuela);
            var listaObjetos = engine.GetObjetosEscuela(
                out int conteoEvaluaciones,
            out int conteoCursos,
            out int conteoAsignaturas,
            out int conteoAlumnos);

            int dummy=0;//Es usado si no se requieren todos los parametros de salida
            var listaObjetos2 = engine.GetObjetosEscuela(
            out int a,
            out dummy,
            out dummy,
            out dummy,
            traerEvaluaciones:false);
            engine.Escuela.LimpiarLugar();
            /*
            var ListaILugar=(from obj in listaObjetos
                where obj is ILugar
                select (ILugar) obj);
            */
        }

        private static void ImpimirCursosEscuela(Escuela escuela)
        {

            Printer.WriteTitle("Cursos de la Escuela");


            if (escuela?.Cursos != null)
            {
                foreach (var curso in escuela.Cursos)
                {
                    WriteLine($"Nombre {curso.Nombre}, Id  {curso.UniqueId}");
                }
            }
        }
    }
}
