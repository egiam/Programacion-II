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
        public DetalleFactura(Producto producto, int cantidad)
        {
            this.producto = producto;
            this.cantidad = cantidad;
        }

        public double CalcularSubtotal()
        {
            return producto.precio * cantidad;
        }
    }
}
