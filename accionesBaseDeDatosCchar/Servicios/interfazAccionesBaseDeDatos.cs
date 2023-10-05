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
        /// <summary>
        /// Metodo que usaremos para las consultas que devuelven resultados
        /// que se devoilvera en tipo lista de libros
        /// </summary>
        /// <param name="conexion"></param>
        /// <param name="query"></param>
        /// <returns></returns>
        List<Libro> LeerDatos(NpgsqlConnection conexion ,string query,int condicion);
        /// <summary>
        /// Metodo que usaremos para consultas de base de datos que no devulven nada
        /// </summary>
        /// <param name="conexion"></param>
        /// <param name="query"></param>
        void ConsultasBaseDeDatos(NpgsqlConnection conexion ,string query,Libro l1);
    }
}
