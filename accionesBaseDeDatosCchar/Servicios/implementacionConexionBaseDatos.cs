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
        private string[] pasaParametros(string ruta)
        {
            //en vez de hacerlo con el objeto properties he usado un archivo de texto 
            string[] parametros = new string[4];
            string[] vector2;
            int i = 0;
            try
            {
                StreamReader sr = new StreamReader(ruta);

                while (!sr.EndOfStream)
                {
                    vector2 = sr.ReadLine().Split('=');
                    parametros[i] = vector2[1];
                    i++;
                }
                sr.Close();
                //Excepciones
            }
            catch (ArgumentException au)
            {
                Console.WriteLine("No es valido los argumentos que ofrece Error: " + au.Message);
            }
            catch (FileNotFoundException fn)
            {
                Console.WriteLine("El archivo que intenta leer no existe Error: " + fn.Message);
            }
            catch (DirectoryNotFoundException dn)
            {
                Console.WriteLine("No encuentra el directorio Error: " + dn.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            return parametros;
        }
    }
}
