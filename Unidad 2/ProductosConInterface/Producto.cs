using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductosConInterface
{
    abstract class Producto : IProducto
    {
        public int Codigo { get; set; }
        public string Nombre { get; set; }
        public double Precio { get; set; }

        public Producto(int cod, string nom, double pre)
        {
            this.Codigo = cod;
            this.Nombre = nom;
            this.Precio = pre;

        }

        public abstract double CalcularPrecio();
        //public virtual double CalcularPrecio()
        //{
        //    return Precio;
        //}

        public override string ToString()
        {
            return Codigo + " - " + Nombre + " $ " + CalcularPrecio();
        }
    }
}
