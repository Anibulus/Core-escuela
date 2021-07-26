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
            
            
            #region uso de diccionario
            Dictionary<int, string> diccionario=new Dictionary<int, string>();
            diccionario.Add(10,"Pepelepu");
            diccionario.Add(23,"Lorem Ipsum");
            diccionario[0]="Peter Peter";
            WriteLine(diccionario[0]);
            foreach(var keyValuePair in diccionario)
            {
                WriteLine($"Key: {keyValuePair.Key} Valor: {keyValuePair.Value}");
            }
            Printer.WriteTitle("Acceso a diccionario");
            WriteLine(diccionario[23]);

            Printer.WriteTitle("Otro diccionario");
            Dictionary<string, string> dic=new Dictionary<string, string>();
            dic["Luna"]="Cuerpo celeste que gira alrededor de la tierra";
            WriteLine(dic["Luna"]);

            var dicc=engine.GetDiccionarioObjetos();
            engine.ImprimirDiccionario(dicc);
            #endregion
            #region uso de parametros de salida con linq
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
            #endregion
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
