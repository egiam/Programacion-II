using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Productos
{
    class Pack: Producto
    {

        public int cantidad { get; set; }

        public Pack(int cod, string nom, double prec, int cant):base(cod, nom, prec)
        {
            this.cantidad = cant;
        }

        public override double CalcularPrecio()
        {
            return this.precio * this.cantidad;
        }

        public override string ToString()
        {
            return cantidad + ' ' + base.ToString();
        }

    }
}
