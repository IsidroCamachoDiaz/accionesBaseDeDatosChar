using Npgsql;
using System;
using System.Collections.Generic;
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
            string pruebaConexion = null;
            try
            {
                //Uso el metodo pàsaParametros que recibe la ruta del archivo
                //y devuelve un array con los datos de acceso

                string[] parametros = pasaParametros("C:\\Users\\Puesto3\\Desktop\\Ficheros\\claves.txt");

                string datos = String.Format("Server={0};User Id={1}; Password={2};Database={3};", parametros[0], parametros[1], parametros[2], parametros[3]);
                conn = new NpgsqlConnection(datos);

                conn.Open(); // apertura de conección
                pruebaConexion = conn.ConnectionString;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error en la implementacion de conexion a base de datos: " + ex.Message);
                conn = null;
            }
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
