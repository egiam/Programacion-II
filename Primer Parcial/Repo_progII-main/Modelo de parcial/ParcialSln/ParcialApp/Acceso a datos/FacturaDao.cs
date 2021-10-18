using ParcialApp.Dominio;
using ParcialApp.Servicios;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ParcialApp.Presentacion.Frm_Alta;

namespace ParcialApp.Acceso_a_datos
{
	class FacturaDao : IFacturaDao
	{

		//Para editar
		public bool Delete(int nro)
		{

			SqlConnection cnn = new SqlConnection(@"Data Source=localhost\SQLEXPRESS;Initial Catalog=db_facturas;Integrated Security=True");
			SqlTransaction t = null;
			int affected = 0;
			try
			{
				cnn.Open();
				t = cnn.BeginTransaction();
				SqlCommand cmd = new SqlCommand("SP_REGISTRAR_BAJA_FACTURAS", cnn, t);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.AddWithValue("@factura_nro", nro);
				affected = cmd.ExecuteNonQuery();
				t.Commit();

			}
			catch (SqlException)
			{
				t.Rollback();
			}
			finally
			{
				if (cnn != null && cnn.State == ConnectionState.Open)
					cnn.Close();
			}

			return affected == 1;

		}

		public List<Factura> GetByFilters(List<Parametro> criterios)
		{
			List<Factura> lst = new List<Factura>();
			DataTable table = new DataTable();
			SqlConnection cnn = new SqlConnection(@"Data Source=localhost\SQLEXPRESS;Initial Catalog=db_facturas;Integrated Security=True");
			try
			{
				cnn.Open();

				SqlCommand cmd = new SqlCommand("SP_CONSULTAR_FACTURAS", cnn);
				cmd.CommandType = CommandType.StoredProcedure;
				foreach (Parametro p in criterios)
				{
					cmd.Parameters.AddWithValue(p.Nombre, p.Valor);
				}

				table.Load(cmd.ExecuteReader());
				//mappear los registros como objetos del dominio:

				foreach (DataRow row in table.Rows)
				{
					//Por cada registro creamos un objeto del dominio
					Factura oFactura = new Factura();
					oFactura.Cliente = row["cliente"].ToString();
					oFactura.Fecha = Convert.ToDateTime(row["fecha"].ToString());
					oFactura.FormaPago = Convert.ToInt32(row["forma_pago"].ToString());
					oFactura.NroFactura = Convert.ToInt32(row["nro"].ToString());
					oFactura.Total = Convert.ToDouble(row["total"].ToString());
					//validar que fecha_baja no es null:
					if (!row["fecha_baja"].Equals(DBNull.Value))
						oFactura.FechaBaja = Convert.ToDateTime(row["fecha_baja"].ToString());

					lst.Add(oFactura);
				}

				cnn.Close();
			}
			catch (SqlException)
			{
				lst = null;
			}
			return lst;
		}

		public Factura GetById(int id)
		{
			Factura oFactura = new Factura();
			SqlConnection cnn = new SqlConnection(@"Data Source=localhost\SQLEXPRESS;Initial Catalog=db_facturas;Integrated Security=True");
			cnn.Open();
			SqlCommand cmd = new SqlCommand();
			cmd.Connection = cnn;
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.CommandText = "SP_CONSULTAR_FACTURA_POR_ID";
			cmd.Parameters.AddWithValue("@nro", id);
			SqlDataReader reader = cmd.ExecuteReader();
			bool esPrimerRegistro = true;

			while (reader.Read())
			{
				if (esPrimerRegistro)
				{
					//solo para el primer resultado recuperamos los datos del MAESTRO:
					oFactura.NroFactura = Convert.ToInt32(reader["presupuesto_nro"].ToString());
					oFactura.Cliente = reader["cliente"].ToString();
					oFactura.Fecha = Convert.ToDateTime(reader["fecha"].ToString());
					oFactura.FormaPago = Convert.ToInt32(reader["forma_pago"].ToString());
					oFactura.Total = Convert.ToDouble(reader["total"].ToString());
					esPrimerRegistro = false;
				}

				DetalleFactura oDetalle = new DetalleFactura();
				Producto oProducto = new Producto();
				oProducto.IdProducto = Convert.ToInt32(reader["id_producto"].ToString());
				oProducto.NProducto = reader["n_producto"].ToString();
				oProducto.Precio = Convert.ToDouble(reader["precio"].ToString());
				oProducto.Activo = reader["activo"].ToString().Equals("S");
				oDetalle.Producto = oProducto;
				oDetalle.Cantidad = Convert.ToInt32(reader["cantidad"].ToString());
				esPrimerRegistro = false;
				oFactura.AgregarDetalle(oDetalle);
			}
			return oFactura;
		}

		//Comun

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

		public bool InsertarFactura(Factura oFactura)
		{
			bool resultado = true;
			int filasAfectadas = 0;

			filasAfectadas = HelperDao.ObtenerInstancia().EjecutarSQLMaestroDetalle("SP_INSERTAR_FACTURA", "SP_INSERTAR_DETALLES", oFactura, Accion.Create);

			if (filasAfectadas == 0) resultado = false;

			return resultado;
		}

		public int ObtenerProximoNumero()
		{
			return HelperDao.ObtenerInstancia().ProximoID("pa_PROXIMO_ID", "@next");
		}

		public bool Save(Factura oFactura)
		{
			throw new NotImplementedException();
		}
	}
}
