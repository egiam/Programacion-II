using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParcialApp.Dominio
{
	class DetalleFactura
	{
	
	
			public DetalleFactura(int cantidad, Producto producto)
			{
				Cantidad = cantidad;
				Producto = producto;
			}
			public DetalleFactura()
			{
				Producto = null;
				Cantidad = 0;
			}
			public int Cantidad { get; set; }
			public Producto Producto { get; set; }

			public double CalcularSubtotal()
			{
				return Producto.Precio * Cantidad;
			}

	
	}
}
