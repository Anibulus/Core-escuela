using System.Collections.Generic;

namespace CorEscuela.Entidades
{
    public class Escuela
    {
        //Características
        string nombre;
        public string Nombre{
            get{ return nombre;}
            set { nombre=value.ToUpper();}
        }

        public int anioDeCreacion{get; set;}
        public string Pais { get; set; }
        public string Ciudad { get; set; }
        public TiposEscuela tipoEscuela {get; set;}
        public List<Curso> Cursos { get; set; }

        //Constructores
        public Escuela(string nombre, int anio)=>(Nombre,anioDeCreacion)=(nombre,anio);
        //Incluye parametros opcionales
        public Escuela(string nombre, int anio,TiposEscuela tipoEscuela, string pais="", string ciudad="")
        {
            (Nombre,anioDeCreacion)=(nombre,anio);
            this.tipoEscuela=tipoEscuela;
            Pais=pais;
            Ciudad=ciudad;
        }

        public override string ToString()
        {
            //{System.Environment.NewLine} es usado para linux, y \n para windows
            return $"Nombre: \"{Nombre}\", Tipo: \"{tipoEscuela}\", {System.Environment.NewLine} Pais: \"{Pais}\", Ciudad: \"{Ciudad}\"";
        }

    }//Fin de escuela
}//Fin de namespace