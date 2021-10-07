using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParcialApp.Dominio
{
    class Factura
    {
        public int nro { get; set; }
        public DateTime fecha { get; set; }
        public string cliente { get; set; }
        public string formaPago { get; set; }
        public double total { get; set; }
        public DateTime fechaBaja { get; set; }


    }
}
