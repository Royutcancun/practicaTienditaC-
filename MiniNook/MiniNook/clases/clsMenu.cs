using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MiniNook.clases
{
    public class clsMenu : conect
    {
        private int opcion;
        private List<Productos> listaProductos;

        public void desplegar(){
            listaProductos = new List<Productos>();
            string para;

            do
            {
                do
                {
                    Console.WriteLine("--------- Menú de MiniNook ---------");
                    Console.WriteLine("---------------------------------");
                    Console.WriteLine("1.- Registrar");
                    Console.WriteLine("2.- Actualizar");
                    Console.WriteLine("3.- Eliminar");
                    Console.WriteLine("4.- Buscar");
                    Console.WriteLine("5.- Listar todos los productos");
                    Console.WriteLine("6.- Salir de MiniNook");
                    Console.WriteLine("Seleccione la opción que quiera:");
                    opcion = Convert.ToInt32(Console.ReadLine());


                    // cuando la opción es valida
                    if (opcion < 1 || opcion > 6)
                    {
                        Console.WriteLine("Ingrese una opción valida");
                    }

                } while (opcion < 1 || opcion > 6);
                para = conecta();
                switch (opcion)
                {
                    case 1:
                        {
                            // registrar 

                            Productos productoNuevo = new Productos();
                          //  Console.Write("ID:");
                           // productoNuevo.Id = Convert.ToInt32(Console.ReadLine());

                                Console.Write("Nombre:");
                                productoNuevo.Nombre = Console.ReadLine();

                                Console.Write("Tipo:");
                                productoNuevo.Tipo = Console.ReadLine();

                                Console.Write("Precio:");
                                productoNuevo.Precio = Convert.ToInt32(Console.ReadLine());


                            using (SqlConnection connection = new SqlConnection(para))
                            {
                                try
                                {
                                    connection.Open();
                                    SqlCommand command = new SqlCommand("insert into rogelio (nombre,tipo,precio) values ('"+ productoNuevo.Nombre+ "','" + productoNuevo.Tipo + "'," + productoNuevo.Precio + ")", connection);
                                    SqlDataReader reader = command.ExecuteReader();

                                    reader.Close();

                                    // Console.WriteLine("Conexión válida");
                                }
                                catch (Exception exception)
                                {
                                    Console.WriteLine(exception.Message);
                                }
                            }
                            break;
                        }

                    case 2:
                        {
                            // Actualizar 

                            int idActualizar;
                            Console.WriteLine("Ingresa el ID que deseas editar: ");
                            idActualizar = Convert.ToInt32(Console.ReadLine());

                            Console.Write("Nombre:");
                            string actNombre = Console.ReadLine();

                            Console.Write("Tipo:");
                            string actTipo = Console.ReadLine();

                            Console.Write("Precio:");
                            int actPrecio = Convert.ToInt32(Console.ReadLine());

                            using (SqlConnection connection = new SqlConnection(para))
                            {
                                try
                                {
                                    connection.Open();
                                    SqlCommand command = new SqlCommand("UPDATE Rogelio SET nombre = '" + actNombre + "', tipo = '" + actTipo + "', precio = " + actPrecio + " WHERE id =" + idActualizar, connection);
                                    SqlDataReader reader = command.ExecuteReader();

                                    reader.Close();

                                    // Console.WriteLine("Conexión válida");
                                }
                                catch (Exception exception)
                                {
                                    Console.WriteLine(exception.Message);
                                }
                            }
                            foreach (Productos b in listaProductos)
                            {
                                if (b.Id == idActualizar)
                                {
                                    Console.WriteLine("----------------------------------");
                                    Console.WriteLine("ID: " + b.Id);
                                    Console.WriteLine("Nombre: " + b.Nombre);
                                    Console.WriteLine("Tipo: $" + b.Tipo);
                                    Console.WriteLine("Precio:" + b.Precio);
                                    Console.WriteLine("----------------------------------");

                                    break;
                                }

                                break;
                            }
                        }
                    case 3:
                        {
                            // Eliminar 
                            int idEliminar;
                            Console.WriteLine("Ingresa el ID que deseas eliminar: ");
                            idEliminar = Convert.ToInt32(Console.ReadLine());

                            using (SqlConnection connection = new SqlConnection(para))
                            {
                                try
                                {
                                    connection.Open();
                                    SqlCommand command = new SqlCommand("DELETE FROM Rogelio where id = " + idEliminar, connection);
                                    SqlDataReader reader = command.ExecuteReader();
                                    
                                    reader.Close();

                                    // Console.WriteLine("Conexión válida");
                                }
                                catch (Exception exception)
                                {
                                    Console.WriteLine(exception.Message);
                                }
                            }

                            break;
                        }
                    case 4:
                        {
                            // buscar 
                            Console.WriteLine("Buscar el producto: ");
                            int idBuscar = Convert.ToInt32(Console.ReadLine());

                            //valida conexion
                            
                            using (SqlConnection connection = new SqlConnection(para))
                            {
                                try
                                {
                                    connection.Open();
                                    SqlCommand command = new SqlCommand("SELECT * FROM Rogelio where id = " + idBuscar, connection);
                                    SqlDataReader reader = command.ExecuteReader();
                                    //termina la consulta data base
                                    if (reader.HasRows)
                                    {
                                        while (reader.Read())
                                        {
                                            Console.WriteLine(reader.GetString(1).ToString());
                                        }
                                    }
                                    else
                                    {
                                        Console.WriteLine("Sin resultados.");
                                    }
                                    reader.Close();

                                    // Console.WriteLine("Conexión válida");
                                }
                                catch (Exception exception)
                                {
                                    Console.WriteLine(exception.Message);
                                }
                            }
                            //termina validacion de conexion

                            foreach (Productos b in listaProductos){
                                if(b.Id == idBuscar)
                                {
                                Console.WriteLine("----------------------------------");
                                Console.WriteLine("ID: "+b.Id);
                                Console.WriteLine("Nombre: "+ b.Nombre);
                                Console.WriteLine("Tipo: $"+ b.Tipo);
                                Console.WriteLine("Precio:"+ b.Precio);
                                Console.WriteLine("----------------------------------");
                                   
                                    break;
                                }

                            }
                            break;

                        }
                    case 5:
                            //listar productos
                        {
                            
                            Console.WriteLine("Lista de productos: ");

                            using (SqlConnection connection = new SqlConnection(para))
                            {
                                try
                                {
                                    connection.Open();
                                    SqlCommand command = new SqlCommand("SELECT * FROM Rogelio", connection);
                                    SqlDataReader reader = command.ExecuteReader();
                                    //termina la consulta data base
                                    if (reader.HasRows)
                                    {
                                        while (reader.Read())
                                        {
                                            Console.WriteLine(reader.GetString(1).ToString());
                                        }
                                    }
                                    else
                                    {
                                        Console.WriteLine("Sin resultados.");
                                    }
                                    reader.Close();

                                    // Console.WriteLine("Conexión válida");
                                }
                                catch (Exception exception)
                                {
                                    Console.WriteLine(exception.Message);
                                }
                            }
                            break;
                        }
                    case 6:
                        {
                            // salir 
                            Console.WriteLine("Adiós");
                            Console.ReadLine();
                            break;
                        }
                }

            } while (opcion != 6);

        }
    }
}
