using System;
using System.Collections.Generic;
using CorEscuela.Entidades;
using static System.Console; //Permite escribit soo writeLine, por ejemplo.
using CorEscuela.Util;

namespace CorEscuela
{
    class Program
    {
        static void Main(string[] args)
        {
            var engine=new EscuelaEngine();
            engine.Inicializar();
            Printer.Beep(5800,500);
            Printer.WriteTitle("Bienvenidos a la escuela");
            ImprimirCursosEscuela(engine.escuela);
           
        }

        //Susar 3 "/" en 3 renglones se usa como comentario y permite XML
        ///<SUMARY>
        ///Esto permite conocer el programa y se usa para software
        ///a nivel profesional
        private static void ImprimirCursosEscuela(Escuela e)
        {
            WriteLine("==========================");
            WriteLine("Cursos de la escuela");
            WriteLine("==========================");
            if(e?.Cursos!=null)//No se verifica salvo que e sea diferente de null
            foreach (var curso in e.Cursos)
            {
                {
                    WriteLine($"Nombre: {curso.Nombre}, ID: {curso.ID}, Jornada {curso.Jornada}");
                }
            }//Fin de for
        }//Fin de metodo


    }//Fin de la clase
}
