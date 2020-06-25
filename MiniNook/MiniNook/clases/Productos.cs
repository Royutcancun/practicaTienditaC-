using System;
using System.Collections.Generic;
using System.Text;

namespace MiniNook.clases
{
    class Productos
    {
        private int id;
        private string nombre;
        private string tipo;
        private int precio;

        public int Id { get => id; set => id = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Tipo { get => tipo; set => tipo = value; }
        public int Precio { get => precio; set => precio = value; }
    }
}
