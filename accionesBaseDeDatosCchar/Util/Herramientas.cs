using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace accionesBaseDeDatosCchar.Util
{
    public static class Herramientas
    {
        /*Recibe el texto del enunciado y los valores maximos y minimos 
        * y da un numero entre los valores*/
        public static int CapturaEntero(string texto, int min, int max)
        {
            bool ok;
            int num = 0;
            do
            {
                ok = true;
                //Enseña el enunciado y pide el valor 
                Console.WriteLine("{0} del {1} al {2}", texto, min, max);
                //Comprueba con un boleano si lo que ha puesto es texto o numeros 
                ok = Int32.TryParse(Console.ReadLine(), out num);
                //Comprueba si es texto o numero
                if (!ok)
                    Console.WriteLine("Introduzca un numero");
                //Comprueba si esta entre los valores
                else if (num < min || num > max)
                    Console.WriteLine("Introdujo un numero mayor o menor de lo posible");
                //Se repite si algo esta mal
            } while (!ok || num < min || num > max);
            return num;
        }

        //Enseña la opciones de la aplicacion
        public static void Menu()
        {
            Console.WriteLine("------------------------------------------");
            Console.WriteLine("Bienvenido:");
            Console.WriteLine("1-Registrar Empleado");
            Console.WriteLine("2-Modificar Empleado");
            Console.WriteLine("3-Exportar Empleados");
            Console.WriteLine("0-Salir");
            Console.WriteLine("------------------------------------------");
        }
    }
}
