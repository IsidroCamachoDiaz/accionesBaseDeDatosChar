using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace accionesBaseDeDatosCchar.Servicios
{
    internal interface interfazAccionesPrimarias
    {
        /// <summary>
        /// Metodo que usaremos para la lectura de datos de la base de datos
        /// </summary>
        void LeerDatos();
        /// <summary>
        /// Metodo que usaremos para meter libros en la base de datos
        /// </summary>
        void InsertarDatos();
        /// <summary>
        /// Metodo que usaremos para borrar libros de la base de datos
        /// </summary>
        void BorrarDatos();
        /// <summary>
        /// Metodo que usaremos para actualizar libros de la base de datos
        /// </summary>
        void ActualizarDatos();
    }
}
