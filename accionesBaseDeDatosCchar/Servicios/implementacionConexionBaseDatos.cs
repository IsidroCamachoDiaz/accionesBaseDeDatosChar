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
            //Cierra el objeto tipo conexion
            con.Close();
        }

        NpgsqlConnection interfazConexionBaseDatos.ConectarBaseDedatos()
        {
            //Conectar a postgresql
            //Ponemos a nulo de por si
            NpgsqlConnection conn = null;
            //Cogemos los valores de app.config
            string stringConexionPostgresql = ConfigurationManager.ConnectionStrings["stringConexion"].ConnectionString;
            //Comprueba si el string es nulo o tiene espacios que no deberia
            if (!string.IsNullOrWhiteSpace(stringConexionPostgresql))
            {
                try
                {
                    //Al objeto conexion se le pasa el string que es donde estaran todos los datos
                    //para conectarse a nuestra base de datos
                    conn = new NpgsqlConnection(stringConexionPostgresql);

                    conn.Open(); // apertura de conección
                }
                //Excepciones
                catch (Exception ex)
                {
                    //Si hay erroes se pone a null
                    Console.WriteLine("Error en la implementacion de conexion a base de datos: " + ex.Message);
                    conn = null;
                }
            }
            // Si hay algun problema con el valor del string de app.config
            else
                Console.WriteLine("El appconfig esta vacio");

            return conn;
        }
    }
}
