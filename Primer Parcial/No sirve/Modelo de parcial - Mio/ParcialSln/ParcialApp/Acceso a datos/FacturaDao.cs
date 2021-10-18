using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ParcialApp.Dominio;
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
                oProducto.idProducto = Convert.ToInt32(row["id_producto"].ToString());
                oProducto.nombre = row["n_producto"].ToString();
                oProducto.precio = Convert.ToDouble(row["precio"].ToString());
                oProducto.activo = row["activo"].ToString().Equals("S");

                lst.Add(oProducto);
            }
            return lst;

   //         List<Producto> lst = new List<Producto>();
			//SqlConnection cnn = new SqlConnection(@"Data Source=localhost\SQLEXPRESS;Initial Catalog=db_facturas;Integrated Security=True");
			//cnn.Open();
			//SqlCommand cmd2 = new SqlCommand("SP_CONSULTAR_PRODUCTOS", cnn);

			//cmd2.CommandType = CommandType.StoredProcedure;

			//DataTable table = new DataTable();
			//table.Load(cmd2.ExecuteReader());

			//cnn.Close();

			//foreach (DataRow row in table.Rows)
			//{
			//	Producto oProducto = new Producto();
			//	oProducto.idProducto = Convert.ToInt32(row["id_producto"].ToString());
			//	oProducto.nombre = row["n_producto"].ToString();
			//	oProducto.precio = Convert.ToDouble(row["precio"].ToString());
			//	oProducto.activo = row["activo"].ToString().Equals("S");

			//	lst.Add(oProducto);
			//}

			//return lst;
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
