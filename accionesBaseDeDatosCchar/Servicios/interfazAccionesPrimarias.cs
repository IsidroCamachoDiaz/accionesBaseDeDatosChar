using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace accionesBaseDeDatosCchar.Servicios
{
    internal interface interfazAccionesPrimarias
    {
        void LeerDatos();
        void InsertarDatos();
        void BorrarDatos();
        void ActualizarDatos();
    }
}
