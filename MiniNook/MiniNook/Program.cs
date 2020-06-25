using MiniNook.clases;
using System;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniNook
{
    class Program
    {
        string usuario;
        string contraseña;

        public void Login()
        {
            Console.WriteLine("------ MiniNook -----");
            Console.WriteLine("Ingrese su usuario para ingresar al MiniNook");
            usuario=(Console.ReadLine()); //aquí lee las ordenes 
            Console.WriteLine("Ingrese su contraseña de MiniNook");
            contraseña=(Console.ReadLine());
            Console.Clear();
        }

        public void Proceso()
        {

            if (usuario == "Admin" && contraseña == "12345") //usuar    io y contraseña para ingresar al mininook
            { 
                Console.WriteLine("Bienvenido a MiniNook: " + usuario);
            }
            else
            {
                Console.WriteLine("No puedes pasar");
            }

            Console.ReadKey();
        }

        static void Main(string[] args)
        {



            Program pro = new Program(); //procesos que inicia el programa
            pro.Login();
            pro.Proceso();

            clsMenu menu = new clsMenu();
            menu.desplegar();

        }

    }
}


