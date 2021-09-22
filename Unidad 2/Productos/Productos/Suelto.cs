using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Productos
{
    class Suelto:Producto
    {

        public double medida { get; set; }

        public Suelto(int cod, string nom, double prec, double med):base(cod, nom, prec)
        {
            this.medida = med;
        }


        public override double CalcularPrecio()
        {
            return this.precio * this.medida;
        }

        public override string ToString()
        {
            return medida + ' ' + base.ToString();
        }

    }
}
