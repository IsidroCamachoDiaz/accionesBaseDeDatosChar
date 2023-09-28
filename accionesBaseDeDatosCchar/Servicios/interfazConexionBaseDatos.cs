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
        NpgsqlConnection ConectarBaseDedatos();
        void CerrarConexion(NpgsqlConnection con);
    }
}
