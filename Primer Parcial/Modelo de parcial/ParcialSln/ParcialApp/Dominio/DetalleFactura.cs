using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParcialApp.Dominio
{
    class DetalleFactura
    {
        public Producto producto { get; set; }
        public int cantidad { get; set; }

        public DetalleFactura()
        {
            producto = new Producto();
            cantidad = 0;
        }
    }
}
