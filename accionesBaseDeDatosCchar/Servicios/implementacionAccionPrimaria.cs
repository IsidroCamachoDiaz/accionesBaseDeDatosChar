using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using accionesBaseDeDatosCchar.Dtos;
using accionesBaseDeDatosCchar.Util;
using Npgsql;

namespace accionesBaseDeDatosCchar.Servicios
{
    internal class implementacionAccionPrimaria : interfazAccionesPrimarias
    {
        void interfazAccionesPrimarias.ActualizarDatos()
        {
            interfazConexionBaseDatos inter1 = new implementacionConexionBaseDatos();

            NpgsqlConnection conexion = inter1.ConectarBaseDedatos();
            if (conexion != null)
            {

            }
            else
                Console.WriteLine("Hubo poblemas con la conexion");
        }

        void interfazAccionesPrimarias.BorrarDatos()
        {
            throw new NotImplementedException();
        }

        void interfazAccionesPrimarias.InsertarDatos()
        {
            interfazConexionBaseDatos inter1 = new implementacionConexionBaseDatos();
            interfazAccionesBaseDeDatos inter2 = new implementacionAccionesBaseDeDatos();
            List <Libro> librosCrear= new List <Libro>();
            NpgsqlConnection conexion = inter1.ConectarBaseDedatos();
            if (conexion != null)
            {
                try
                {
                    int veces = Herramientas.CapturaEntero("Cuantos usuarios quiere insertar", 1, 100);
                    for (int i = 0; i < veces; i++)
                    {
                        Console.WriteLine("Titulo del libro");
                        string titulo = Console.ReadLine();
                        Console.WriteLine("Nombre del autor del libro");
                        string autor = Console.ReadLine();
                        Console.WriteLine("ISBN del libro");
                        string sdbn = Console.ReadLine();
                        Console.WriteLine("Ediccion del libro");
                        int edicion = Herramientas.CapturaEntero("Numero de la edicion", 1, 100);
                        librosCrear.Add(new Libro(0, titulo, autor, sdbn, edicion));
                    }
                    for (int e = 0; e < librosCrear.Count; e++)
                    {
                        string sql = "INSERT INTO gbp_almacen.gbp_alm_cat_libros (titulo,autor,isbn,edicion) "
                        + "VALUES ('" + librosCrear[e].Titulo + "','" + librosCrear[e].Autor + "', '" + librosCrear[e].Isbn + "', '" + librosCrear[e].Edicion + "');";

                        inter2.ConsultasBaseDeDatos(conexion, sql);
                    }
                    Console.WriteLine("Se han creado los {0} usuarios",veces);
                    inter1.CerrarConexion(conexion);
                }catch(Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            else
                Console.WriteLine("Hubo poblemas con la conexion");
        }

        void interfazAccionesPrimarias.LeerDatos()
        {
            interfazConexionBaseDatos inter1 = new implementacionConexionBaseDatos();
            interfazAccionesBaseDeDatos inter2 = new implementacionAccionesBaseDeDatos();
            List<Libro> libros = new List<Libro>();
            try
            {
                NpgsqlConnection conexion = inter1.ConectarBaseDedatos();
                if (conexion != null)
                {
                    int opcion = Herramientas.CapturaEntero("Elija una opcion \n1-Todos lo datos\n2-Filtrar\n", 1, 2);
                    switch (opcion)
                    {
                        case 1:
                            libros = inter2.LeerDatos(conexion, "SELECT * FROM gbp_almacen.gbp_alm_cat_libros");
                            MostrarDatosBucle(libros);
                            break;
                        case 2:
                            int id = Herramientas.CapturaEntero("Introduzca el id por el que filtar", 1, 1000);
                            libros = inter2.LeerDatos(conexion, "SELECT * FROM gbp_almacen.gbp_alm_cat_libros WHERE id_libro=" + id);
                            if (libros.Count == 0)
                                Console.WriteLine("No hay ningun libro con ese id");
                            else
                                Console.WriteLine(libros[0].ToString());
                            break;
                    }
                    inter1.CerrarConexion(conexion);
                }
            }catch(Exception e)
            {
                Console.WriteLine("Error en la implementacion de acciones principales: "+e.ToString());
            }
        }
        private void MostrarDatosBucle(List<Libro> libros)
        {
            for (int i = 0; i < libros.Count; i++)
            {
                Console.WriteLine(libros[i].propiedades);
            }
        }
    }
}
