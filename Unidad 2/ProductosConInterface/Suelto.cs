using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductosConInterface
{
    class Suelto :Producto
    {
        public int Medida { get; set; }
        public Suelto(int cod, string nom, double pre, int med): base(cod, nom, pre)
        {
            this.Medida = med;
        }
        public override double CalcularPrecio()
        {
            return this.Precio * this.Medida;
        }
        public override string ToString()
        {
            return "Suelto: " + base.ToString();
        }
    }
}
