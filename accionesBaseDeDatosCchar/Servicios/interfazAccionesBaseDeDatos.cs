using accionesBaseDeDatosCchar.Dtos;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace accionesBaseDeDatosCchar.Servicios
{
    internal interface interfazAccionesBaseDeDatos
    {
        List<Libro> LeerDatos(NpgsqlConnection conexion ,string query);
        void ConsultasBaseDeDatos(NpgsqlConnection conexion ,string query);
    }
}
