using static System.Console;

namespace CorEscuela.Util
{
    public static class Printer
    {
        public static void DibujarLinea(int tamano=10)//Parametro opcional
        {
            WriteLine("".PadLeft(tamano, '='));//Rellenar
        }

        public static void WriteTitle(string title="")//Parametro opcional
        {
            int tam=title.Length+4;
            DibujarLinea(tam);
            WriteLine($"| {title} |");
            DibujarLinea(tam);
        }

        public static void Beep(int hz, int tiempo, int cantidad=1)
        {
            while(cantidad-->0)
            {
                System.Console.Beep(hz, tiempo);                
            }
        }
    }
}