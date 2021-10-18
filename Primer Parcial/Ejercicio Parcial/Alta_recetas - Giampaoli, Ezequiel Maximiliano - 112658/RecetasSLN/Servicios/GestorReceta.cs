using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RecetasSLN.Acceso_a_Datos;
using RecetasSLN.Dominio;

namespace RecetasSLN.Servicios
{
    class GestorReceta
    {
		private IRecetaDao dao;
		public GestorReceta(AbstractDaoFactory factory)
		{
			dao = factory.CrearRecetaDao();
		}
		public List<Ingrediente> ObtenerProductos()
		{
			return dao.GetIngredientes();
		}

		public int ProximaFactura()
		{
			return dao.ObtenerProximoNumero();
		}

		internal bool NuevaFactura(Receta oReceta)
		{
			return dao.InsertarReceta(oReceta);
		}
	}
}
