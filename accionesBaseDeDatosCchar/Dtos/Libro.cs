using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace accionesBaseDeDatosCchar.Dtos
{
    /// <summary>
    /// Entidad libro que usaremos para meter los valores de 
    /// nuestra base de datos
    /// </summary>
    internal class Libro
    {
        //Atributos
        long id_libro;
        string titulo;
        string autor;
        string isbn;
        int edicion;
        //Constructores
        public Libro(long id_libro, string titulo, string autor, string isbn, int edicion)
        {
            this.id_libro = id_libro;
            this.titulo = titulo;
            this.autor = autor;
            this.isbn = isbn;
            this.edicion = edicion;
        }
        //Geters y Seters
        public long Id_libro { get => id_libro; }
        public string Titulo { get => titulo; set => titulo = value; }
        public string Autor { get => autor; set => autor = value; }
        public string Isbn { get => isbn; set => isbn = value; }
        public int Edicion { get => edicion; set => edicion = value; }
        //Propiedades
        public string propiedades { get { 
                return String.Format("ID: {0} TITULO: {1} AUTOR: {2} ISBN: {3} EDICION: {4}",this.id_libro,this.titulo,this.autor,this.isbn,this.edicion);
            } 
        }


    }
}
