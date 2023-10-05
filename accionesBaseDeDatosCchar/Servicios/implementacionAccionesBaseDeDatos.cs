using accionesBaseDeDatosCchar.Dtos;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace accionesBaseDeDatosCchar.Servicios
{
    /// <summary>
    /// Clase de la implementacion donde esta las acciones de base de datos
    /// </summary>
    internal class implementacionAccionesBaseDeDatos : interfazAccionesBaseDeDatos
    {
        void interfazAccionesBaseDeDatos.ConsultasBaseDeDatos(NpgsqlConnection conexion, string query,Libro l1)
        {
            try
            {
                //Comprobamos el estado de la conexion
                string  pruebaConexion = conexion.State.ToString();
                if(pruebaConexion != "Open")
                    conexion = null;
                // creas tu query y le envías la conexión con la que va a trabajar y filtras la condición que necesitas 
                NpgsqlCommand comando = new NpgsqlCommand(query, conexion);
                //Que tipo de query es para la parametrizacion
                if (query.Contains("UPDATE")){
                    comando.Parameters.AddWithValue("@titulo", l1.Titulo);
                    comando.Parameters.AddWithValue("@autor", l1.Autor);
                    comando.Parameters.AddWithValue("@isbn", l1.Isbn);
                    comando.Parameters.AddWithValue("@edicion", l1.Edicion);
                    comando.Parameters.AddWithValue("@id", l1.Id_libro);

                }
                else if (query.Contains("DELETE"))               
                    comando.Parameters.AddWithValue("@id", l1.Id_libro);
                else
                {
                    
                    comando.Parameters.AddWithValue("@titulo", l1.Titulo);
                    comando.Parameters.AddWithValue("@autor", l1.Autor);
                    comando.Parameters.AddWithValue("@isbn", l1.Isbn);
                    comando.Parameters.AddWithValue("@edicion", l1.Edicion);
                }
                
                //Ejecuta la query
                comando.ExecuteNonQuery();
                
            }
            //Excepciones
            catch (Exception ex)
            {
                Console.WriteLine("Error en la implemnetacion de accion de base de datos: " + ex.Message);
            }
        }

        List<Libro> interfazAccionesBaseDeDatos.LeerDatos(NpgsqlConnection conexion, string query,int condicion)
        {
            //Creo la lista donde metere los resultados que creare con la entida libro
            List <Libro> libros= new List<Libro>();
            try
            {
                //Comprobamos la conexion
                string pruebaConexion = conexion.State.ToString();
                if (pruebaConexion != "Open")
                    conexion = null;
                // creas tu query y le envías la conexión con la que va a trabajar y filtras la condición que necesitas 
                NpgsqlCommand comando = new NpgsqlCommand(query, conexion);
                //Compruebo si tiene algun parametro
                if (query.Contains("@"))
                {
                    comando.Parameters.AddWithValue("@id", condicion);
                }
                //Ejecutamos la query
                NpgsqlDataReader dr = comando.ExecuteReader();
                
                // Si devulve datos los mete cada campo en un valor que sera valores de la entidad libro que meteremos en la lista
                while (dr.Read())
                    libros.Add(new Libro((long)dr[0], dr[1].ToString(), dr[2].ToString(), dr[3].ToString(),(int)dr[4]));
                //Cerramos el datareader
                dr.Close();
            }
            //Excepciones
            catch (Exception ex)
            {
                Console.WriteLine("Error en la implemnetacion de accion de base de datos: " + ex.Message);
            }
            return libros;
        }
    }
}
