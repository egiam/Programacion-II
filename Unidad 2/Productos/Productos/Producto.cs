using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Productos
{
    abstract class Producto: IProducto
    {
        public int codigo { get; set; }
        public string nombre { get; set; }
        public double precio { get; set; }

        public Producto(int cod, string nom, double prec)
        {
            this.codigo = cod;
            this.precio = prec;
            this.nombre = nom;
        }

        public abstract double CalcularPrecio();

        public override string ToString()
        {
            return codigo + " - " + nombre + " $ " + CalcularPrecio();
        }

    }
}
