using accionesBaseDeDatosCchar.Servicios;
using accionesBaseDeDatosCchar.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace accionesBaseDeDatosCchar
{
    /// <summary>
    /// Clase principal de programa
    /// </summary>
    internal class Program
    {
        static void Main(string[] args)
        {
            //Creo la opcion para que elija el usuario
            int opcion = 0;
            do
            {
                //Muestro el menu
                Herramientas.Menu();
                //Creo la interfaz de acciones
                interfazAccionesPrimarias inter=new implementacionAccionPrimaria();
                //Cojo la opcion
                opcion = Herramientas.CapturaEntero("Introduzca una opcion",0,4);
                //Coje la opcion segun lo que elijio el usuatio
                switch(opcion) 
                {
                    case 1:
                        inter.InsertarDatos();
                        break;
                    case 2:
                        inter.LeerDatos();
                        break;
                    case 3:
                        inter.ActualizarDatos();
                        break;
                    case 4:
                        inter.BorrarDatos();
                        break;
                }
                //Cuando la opcion sea 0 acaba el programa
            } while (opcion != 0);
        }
    }
}
