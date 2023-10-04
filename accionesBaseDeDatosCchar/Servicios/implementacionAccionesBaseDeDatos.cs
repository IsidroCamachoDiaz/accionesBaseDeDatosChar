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
        void interfazAccionesBaseDeDatos.ConsultasBaseDeDatos(NpgsqlConnection conexion, string query)
        {
            try
            {
                //Comprobamos el estado de la conexion
                string  pruebaConexion = conexion.State.ToString();
                if(pruebaConexion != "Open")
                    conexion = null;
                // creas tu query y le envías la conexión con la que va a trabajar y filtras la condición que necesitas 
                NpgsqlCommand comando = new NpgsqlCommand(query, conexion);  
                //Ejecuta la query
                comando.ExecuteNonQuery();
                
            }
            //Excepciones
            catch (Exception ex)
            {
                Console.WriteLine("Error en la implemnetacion de accion de base de datos: " + ex.Message);
            }
        }

        List<Libro> interfazAccionesBaseDeDatos.LeerDatos(NpgsqlConnection conexion, string query)
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
                NpgsqlCommand command = new NpgsqlCommand(query, conexion);
                //Ejecutamos la query
                NpgsqlDataReader dr = command.ExecuteReader();
                
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
