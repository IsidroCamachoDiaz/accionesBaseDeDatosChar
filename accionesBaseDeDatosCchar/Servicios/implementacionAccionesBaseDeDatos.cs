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
    internal class implementacionAccionesBaseDeDatos : interfazAccionesBaseDeDatos
    {
        void interfazAccionesBaseDeDatos.ConsultasBaseDeDatos(NpgsqlConnection conexion, string query)
        {
            try
            {
                
                string  pruebaConexion = conexion.State.ToString();
                if(pruebaConexion != "Open")
                    conexion = null;
                // creas tu query y le envías la conexión con la que va a trabajar y filtras la condición que necesitas 
                NpgsqlCommand command = new NpgsqlCommand(query, conexion);  
                command.ExecuteNonQuery();
                
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error en la implemnetacion de accion de base de datos: " + ex.Message);
            }
        }

        List<Libro> interfazAccionesBaseDeDatos.LeerDatos(NpgsqlConnection conexion, string query)
        {
            List <Libro> libros= new List<Libro>();
            try
            {
                string pruebaConexion = conexion.State.ToString();
                if (pruebaConexion != "Open")
                    conexion = null;
                // creas tu query y le envías la conexión con la que va a trabajar y filtras la condición que necesitas 
                NpgsqlCommand command = new NpgsqlCommand(query, conexion);
                NpgsqlDataReader dr = command.ExecuteReader();

                // Si devulve datos los recorre y te los muestra por la consola)
                while (dr.Read())
                    libros.Add(new Libro((long)dr[0], dr[1].ToString(), dr[2].ToString(), dr[3].ToString(),(int)dr[4]));
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error en la implemnetacion de accion de base de datos: " + ex.Message);
            }
            return libros;
        }
    }
}
