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

		public int NroFactura { get; set; }
		public DateTime Fecha { get; set; }
		public string Cliente { get; set; }
		public int FormaPago { get; set; }
		public DateTime FechaBaja { get; set; }
		public double Total { get; set; }

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

		public string GetFechaBajaFormato()
		{
			string aux = FechaBaja.ToString("dd/MM/yyyy");
			return aux.Equals("01/01/0001") ? "" : aux;
		}
	}
}
