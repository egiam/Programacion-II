using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParcialApp.Dominio
{
    class Producto
    {
        public int idProducto { get; set; }
        public string nombre { get; set; }
        public double precio { get; set; }
        public bool activo { get; set; }


        public Producto()
        {

        }
    }
}
