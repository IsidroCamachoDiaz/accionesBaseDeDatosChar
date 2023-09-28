using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace accionesBaseDeDatosCchar.Dtos
{
    internal class Libro
    {
        long id_libro;
        string titulo;
        string autor;
        string isbn;
        int edicion;

        public Libro(long id_libro, string titulo, string autor, string isbn, int edicion)
        {
            this.id_libro = id_libro;
            this.titulo = titulo;
            this.autor = autor;
            this.isbn = isbn;
            this.edicion = edicion;
        }

        public long Id_libro { get => id_libro; }
        public string Titulo { get => titulo; set => titulo = value; }
        public string Autor { get => autor; set => autor = value; }
        public string Isbn { get => isbn; set => isbn = value; }
        public int Edicion { get => edicion; set => edicion = value; }

    }
}
