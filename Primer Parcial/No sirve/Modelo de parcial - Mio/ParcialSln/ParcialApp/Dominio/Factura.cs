using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParcialApp.Dominio
{
    class Factura
    {
        public List<DetalleFactura> Detalles { get; set; }

        public Factura()
        {
            Detalles = new List<DetalleFactura>();
        }

        public int nroFactura { get; set; }
        public DateTime fecha { get; set; }
        public string cliente { get; set; }
        public int formaPago { get; set; }
        public double total { get; set; }
        public DateTime fechaBaja { get; set; }

		public void AgregarDetalle(DetalleFactura detalle)
		{
			Detalles.Add(detalle);
		}
		public void QuitarDetalle(int indice)
		{
			Detalles.RemoveAt(indice);
		}
		public double CalcularTotal()
		{
			double total = 0;
			foreach (DetalleFactura item in Detalles)
			{
				total += item.CalcularSubtotal();
			}

			return total;
		}
	}
}
