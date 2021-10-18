using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ParcialApp.Acceso_a_datos;
using ParcialApp.Dominio;

namespace ParcialApp.Servicios
{
    class GestorFactura
    {
		private IFacturaDao dao;
		public GestorFactura(AbstractDaoFactory factory)
		{
			dao = factory.CrearFacturaDao();
		}
		public List<Producto> ObtenerProductos()
		{
			return dao.GetProductos();
		}
		public bool NuevoPresupuesto(Factura oFactura)
		{
			return dao.Save(oFactura);
		}

		public int ProximaFactura()
		{
			return dao.ObtenerProximoNumero();
		}
	}
}
