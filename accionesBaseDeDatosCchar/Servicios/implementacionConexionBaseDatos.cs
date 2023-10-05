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
            try
            {
                //Cogemos los valores de app.config
                string stringConexionPostgresql = ConfigurationManager.ConnectionStrings["stringConexion"].ConnectionString;
                //Comprueba si el string es nulo o tiene espacios que no deberia
                if (!string.IsNullOrWhiteSpace(stringConexionPostgresql))
                {

                    //Al objeto conexion se le pasa el string que es donde estaran todos los datos
                    //para conectarse a nuestra base de datos
                    conn = new NpgsqlConnection(stringConexionPostgresql);
                    // Apertura de conección
                    conn.Open(); 
                }
                // Si hay algun problema con el valor del string de app.config
                else
                    Console.WriteLine("El appconfig esta vacio");
                //Excepciones
            } catch (ConfigurationErrorsException ce) {
                Console.WriteLine("Error en la implementacion de conexion a base de datos: No puso bien los datos de app.config" + ce.Message);
                conn = null;
            } catch (NullReferenceException nr) {
                Console.WriteLine("Error en la implementacion de conexion a base de datos: El objeto de los datos esta nulo" + nr.Message);
                conn = null;
            } 
            return conn;
        }
    }
}
