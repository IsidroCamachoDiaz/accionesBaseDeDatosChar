using accionesBaseDeDatosCchar.Servicios;
using accionesBaseDeDatosCchar.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace accionesBaseDeDatosCchar
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int opcion = 0;
            do
            {
                Herramientas.Menu();
                interfazAccionesPrimarias inter=new implementacionAccionPrimaria();
                opcion = Herramientas.CapturaEntero("Introduzca una opcion",0,4);
                switch(opcion) 
                {
                    case 1:
                        inter.InsertarDatos();
                        break;
                    case 2:
                        inter.LeerDatos();
                        break;
                    case 3:
                        break;
                    case 4:
                        break;
                }
                

            } while (opcion != 0);
        }
    }
}
