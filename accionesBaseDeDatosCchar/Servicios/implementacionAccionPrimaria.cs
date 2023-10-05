using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using accionesBaseDeDatosCchar.Dtos;
using accionesBaseDeDatosCchar.Util;
using Npgsql;

namespace accionesBaseDeDatosCchar.Servicios
{
    /// <summary>
    /// Clase donde esta la implementacion de acciones primarias
    /// </summary>
    internal class implementacionAccionPrimaria : interfazAccionesPrimarias
    {
        void interfazAccionesPrimarias.ActualizarDatos()
        {
            //Creo la interfaces con la implementacion
            interfazConexionBaseDatos inter1 = new implementacionConexionBaseDatos();
            interfazAccionesBaseDeDatos inter2 = new implementacionAccionesBaseDeDatos();
            try
            {
                //Conecto
                NpgsqlConnection conexion = inter1.ConectarBaseDedatos();
                //Compruebo conexion
                if (conexion != null)
                {
                    //Creo un lista con todos lo libros para que elija el que quiere actualizar
                    List<Libro> libros = inter2.LeerDatos(conexion, "SELECT * FROM gbp_almacen.gbp_alm_cat_libros", 0);
                    //Muestro los libros
                    MostrarDatosBucle(libros);
                    //Uso una variable para saber si encuentra el libro
                    bool encontrado = false;
                    if (libros.Count != 0)
                    {
                        //Se le pregunta cual quiere actualizar
                        int actu = Herramientas.CapturaEntero("Cual quiere actualizar", 0, 1000);
                        //Se hace un bucle para buscar
                        for (int i = 0; i < libros.Count; i++)
                        {
                            //Si es igual se pide los nuevos valores
                            if (libros[i].Id_libro == actu)
                            {
                                Console.WriteLine("Titulo del libro:");
                                libros[i].Titulo = Console.ReadLine();
                                Console.WriteLine("Autor del libro:");
                                libros[i].Autor = Console.ReadLine();
                                Console.WriteLine("ISBN del libro:");
                                libros[i].Isbn = Console.ReadLine();
                                libros[i].Edicion = Herramientas.CapturaEntero("Numero de la edicion", 1, 100);
                                // Se hace la consulta con la query
                                inter2.ConsultasBaseDeDatos(conexion, "UPDATE gbp_almacen.gbp_alm_cat_libros SET titulo=@titulo,autor=@autor,isbn=@isbn,edicion=@edicion WHERE id_libro=@id", libros[i]);
                                //Se cambia la variable
                                encontrado = true;
                                //Se sale del bucle
                                break;
                            }
                        }
                        //Si no lo encuentra por la id
                        if (!encontrado)
                            Console.WriteLine("No se encontro el id del libro indicado");
                        //Si esta true se avisa al usuario
                        else
                            Console.WriteLine("Se actualizo los datos del libro");
                        //Desconecta
                        inter1.CerrarConexion(conexion);
                    }
                    //Si esta vacia la lista
                    else
                        Console.WriteLine("No hay ningun libro registrado");

                }
                //No esta open
                else
                    Console.WriteLine("Hubo poblemas con la conexion");
                //Excepciones
            }
            catch (ArgumentOutOfRangeException aor)
            {
                Console.WriteLine("Error en la implementacion de acciones primarias " + aor.Message);
            }
            catch (IOException io)
            {
                Console.WriteLine("Error en la implementacion de acciones primarias " + io.Message);
            }
            catch (OutOfMemoryException oue)
            {
                Console.WriteLine("Error en la implementacion de acciones primarias " + oue.Message);
            }
        }

        void interfazAccionesPrimarias.BorrarDatos()
        {
            //Creamos las interfaces con la implementaciones
            interfazConexionBaseDatos inter1 = new implementacionConexionBaseDatos();
            interfazAccionesBaseDeDatos inter2 = new implementacionAccionesBaseDeDatos();
                //Conectamos
                NpgsqlConnection conexion = inter1.ConectarBaseDedatos();
                //Comprobamos
                if (conexion != null)
                {
                    //Creo la lista para mostrale al usuario
                    List<Libro> libros = inter2.LeerDatos(conexion, "SELECT * FROM gbp_almacen.gbp_alm_cat_libros",0);
                    //Muestro los libros
                    MostrarDatosBucle(libros);
                    //Se crea una variable booleana para saber si lo encuentra
                    bool encontrado = false;
                    //Comprobamos si la lista esta vacia
                    if (libros.Count != 0)
                    {
                        //Preguntamos cual quiere borrar
                        int bor = Herramientas.CapturaEntero("Cual quiere Borrar:", 0, 1000);
                        //Hacemos un bucle para buscar el libro
                        for (int i = 0; i < libros.Count; i++)
                        {
                            //Si es igual
                            if (libros[i].Id_libro == bor)
                            {
                                string seguro="";
                                //Creamos un string para hacer un bucle que sea de seguridad y
                                //quiera borrar el libro con el id elejido
                                do
                                {
                                    Console.WriteLine("Esta seguro de que quiere borrar el libro con el id: {0}, ponga SI QUIERO en mayusculas",bor);
                                    seguro = Console.ReadLine();
                                } while (seguro != "SI QUIERO");
                                //Metemos la query
                                inter2.ConsultasBaseDeDatos(conexion,"DELETE FROM gbp_almacen.gbp_alm_cat_libros WHERE id_libro=@id",libros[i]);
                                //Ponemos la varible a true
                                encontrado = true;
                                //Salimos del bucle
                                break;
                            }
                        }
                        //Si  no lo encuentra
                        if (!encontrado)
                            Console.WriteLine("No se encontro el id del libro indicado");
                        //Si lo encuntra
                        else
                            Console.WriteLine("Se borro el libro correctamente");
                        //Desconecto
                        inter1.CerrarConexion(conexion);
                    }
                    //Si la lista esta vacia
                    else
                        Console.WriteLine("No hay ningun libro registrado");

                }
                //Si la ocnexion no esta abierta
                else
                    Console.WriteLine("Hubo poblemas con la conexion");
        }

        void interfazAccionesPrimarias.InsertarDatos()
        {
            //Creo las interfaces con su implementacion
            interfazConexionBaseDatos inter1 = new implementacionConexionBaseDatos();
            interfazAccionesBaseDeDatos inter2 = new implementacionAccionesBaseDeDatos();
            //Creo una lista donde guardare los libros que desee insertar
            List <Libro> librosCrear= new List <Libro>();
            //Conecto
            NpgsqlConnection conexion = inter1.ConectarBaseDedatos();
            //Compruebo
            if (conexion != null)
            {
                try
                {
                    //Le pregunto cuantos libros quiere
                    int veces = Herramientas.CapturaEntero("Cuantos usuarios quiere insertar", 1, 100);
                    //Se hace un bucle para que meta los valores
                    for (int i = 0; i < veces; i++)
                    {
                        Console.WriteLine("Titulo del libro");
                        string titulo = Console.ReadLine();
                        Console.WriteLine("Nombre del autor del libro");
                        string autor = Console.ReadLine();
                        Console.WriteLine("ISBN del libro");
                        string sdbn = Console.ReadLine();
                        Console.WriteLine("Ediccion del libro");
                        int edicion = Herramientas.CapturaEntero("Numero de la edicion", 1, 100);
                        //Se crea y se añade el libro
                        librosCrear.Add(new Libro(0, titulo, autor, sdbn, edicion));
                    }
                    //Se hace otro bucle para incertar la query con los valores de cada libro
                    for (int e = 0; e < librosCrear.Count; e++)
                    {
                        string sql = "INSERT INTO gbp_almacen.gbp_alm_cat_libros (titulo,autor,isbn,edicion) VALUES (@titulo,@autor,@isbn,@edicion)";
                        //Hace la consulta con la query
                        inter2.ConsultasBaseDeDatos(conexion, sql, librosCrear[e]);
                    }
                    Console.WriteLine("Se han creado los {0} usuarios",veces);
                    //Desconecta
                    inter1.CerrarConexion(conexion);
                    //Excepciones
                }catch(ArgumentOutOfRangeException aor)
                {
                    Console.WriteLine("Error en la implementacion de acciones primarias "+aor.Message);
                }
                catch(IOException io)
                {
                    Console.WriteLine("Error en la implementacion de acciones primarias "+io.Message);
                }
                catch(OutOfMemoryException oue)
                {
                    Console.WriteLine("Error en la implementacion de acciones primarias " + oue.Message);
                }
            }
            //Si no esta abierta la conexion
            else
                Console.WriteLine("Hubo poblemas con la conexion");
        }

        void interfazAccionesPrimarias.LeerDatos()
        {
            //Creamos las interfaces con sus implemenatciones
            interfazConexionBaseDatos inter1 = new implementacionConexionBaseDatos();
            interfazAccionesBaseDeDatos inter2 = new implementacionAccionesBaseDeDatos();
            //Creo una lista donde metere los libros que de el resultado
            List<Libro> libros = new List<Libro>();
                //Conecto
                NpgsqlConnection conexion = inter1.ConectarBaseDedatos();
                //Compruebo
                if (conexion != null)
                {
                    //Le pido que opcion desea
                    int opcion = Herramientas.CapturaEntero("Elija una opcion \n1-Todos lo datos\n2-Filtrar\n", 1, 2);
                    switch (opcion)
                    {
                        case 1:
                            //HAce la consulta con la query y me da todos los libros
                            libros = inter2.LeerDatos(conexion, "SELECT * FROM gbp_almacen.gbp_alm_cat_libros",0);
                            //Muestra los libros
                            MostrarDatosBucle(libros);
                            break;
                        case 2:
                            //Preguntamos el id
                            int id = Herramientas.CapturaEntero("Introduzca el id por el que filtar", 1, 1000);
                            //Cogemos los datos metiendo la query
                            libros = inter2.LeerDatos(conexion, "SELECT * FROM gbp_almacen.gbp_alm_cat_libros WHERE id_libro=@id",id);
                            //Si no lo encutra por la id
                            if (libros.Count == 0)
                                Console.WriteLine("No hay ningun libro con ese id");
                            //Si lo encuntra
                            else
                                Console.WriteLine(libros[0].propiedades);
                            //Sale del switch
                            break;
                    }
                    //Desconecta
                    inter1.CerrarConexion(conexion);
                }
                else
                    Console.WriteLine("Hubo poblemas con la conexion");

        }
        //Este metodo sirve para mostrar toda la lista de libros con un bucle
        private void MostrarDatosBucle(List<Libro> libros)
        {
            for (int i = 0; i < libros.Count; i++)
            {
                Console.WriteLine(libros[i].propiedades);
            }
        }
    }
}
