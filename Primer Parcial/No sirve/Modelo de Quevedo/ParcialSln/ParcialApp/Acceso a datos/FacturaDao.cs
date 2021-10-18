using ParcialApp.Dominio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ParcialApp.Presentacion.Frm_Alta;

namespace ParcialApp.Acceso_a_datos
{
	class FacturaDao : IFacturaDao
	{
		public List<Producto> GetProductos()
		{
			List<Producto> lst = new List<Producto>();
			DataTable tabla = HelperDao.ObtenerInstancia().ConsultaSQL("SP_CONSULTAR_PRODUCTOS");
			foreach (DataRow row in tabla.Rows)
			{
				Producto oProducto = new Producto();
				oProducto.IdProducto = Convert.ToInt32(row["id_producto"].ToString());
				oProducto.NProducto = row["n_producto"].ToString();
				oProducto.Precio = Convert.ToDouble(row["precio"].ToString());
				oProducto.Activo = row["activo"].ToString().Equals("S");

				lst.Add(oProducto);
			}
			return lst;
		}

		public int ObtenerProximoNumero()
		{
			return HelperDao.ObtenerInstancia().ProximoID("pa_PROXIMO_ID", "@next");
		}

		public bool Save(Factura oFactura)
		{
			bool resultado = true;
			int filasAfectadas = 0;

			filasAfectadas = HelperDao.ObtenerInstancia().EjecutarSQLMaestroDetalle("SP_INSERTAR_FACTURA", "SP_INSERTAR_DETALLES", oFactura, Accion.Create);

			if (filasAfectadas == 0) resultado = false;

			return resultado;
		}
	}
}
