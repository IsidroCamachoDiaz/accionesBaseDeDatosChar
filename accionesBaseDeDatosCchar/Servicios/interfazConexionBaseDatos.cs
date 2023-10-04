using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace accionesBaseDeDatosCchar.Servicios
{
    internal interface interfazConexionBaseDatos
    {
        /// <summary>
        /// Metodo que suaremos para conectar a la base de datos
        /// </summary>
        /// <returns>La conexion ya abierta</returns>
        NpgsqlConnection ConectarBaseDedatos();
        /// <summary>
        /// Metodo que cierra la conexion de base de datos
        /// </summary>
        /// <param name="con"></param>
        void CerrarConexion(NpgsqlConnection con);
    }
}
