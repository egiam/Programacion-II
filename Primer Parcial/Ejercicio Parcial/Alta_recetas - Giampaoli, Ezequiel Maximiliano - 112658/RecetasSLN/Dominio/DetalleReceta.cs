using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecetasSLN.Dominio
{
    class DetalleReceta
    {
        public DetalleReceta(int ingrediente, int cantidad)
        {
            this.ingrediente = ingrediente;
            this.cantidad = cantidad;
        }

        public DetalleReceta()
        {
            ingrediente = 0;
            cantidad = 0;
        }

        public int ingrediente { get; set; }
        public int cantidad { get; set; }

        public override string ToString()
        {
            return Convert.ToString(cantidad);
        }
    }
}
