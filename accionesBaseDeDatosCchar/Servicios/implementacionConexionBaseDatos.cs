using Npgsql;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace accionesBaseDeDatosCchar.Servicios
{
    internal class implementacionConexionBaseDatos : interfazConexionBaseDatos
    {
        void interfazConexionBaseDatos.CerrarConexion(NpgsqlConnection con)
        {
            con.Close();
        }

        NpgsqlConnection interfazConexionBaseDatos.ConectarBaseDedatos()
        {
            //Conectar a postgresql
            NpgsqlConnection conn = null;
            string stringConexionPostgresql = ConfigurationManager.ConnectionStrings["stringConexion"].ConnectionString;
            if (!string.IsNullOrWhiteSpace(stringConexionPostgresql))
            {
                try
                {
                    conn = new NpgsqlConnection(stringConexionPostgresql);

                    conn.Open(); // apertura de conección
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error en la implementacion de conexion a base de datos: " + ex.Message);
                    conn = null;
                }
            }
            else
                Console.WriteLine("El appconfig esta vacio");

            return conn;
        }
    }
}
