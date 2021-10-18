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
    class HelperDao
    {
		private static HelperDao instancia;
		//private string cadenaConexion;
		SqlConnection cnn;
		SqlCommand cmd;
		private HelperDao()
		{
			//cadenaConexion = Properties.Resources.strConexion;
			cnn = new SqlConnection(@"Data Source=localhost\SQLEXPRESS;Initial Catalog=db_facturas;Integrated Security=True");
			cmd = new SqlCommand();
		}
		public static HelperDao ObtenerInstancia()
		{
			if (instancia == null)
			{
				instancia = new HelperDao();
			}
			return instancia;
		}
		public DataTable ConsultaSQL(string nombreSP)
		{
			DataTable tabla = new DataTable();
			try
			{
				cmd.Parameters.Clear();
				cnn.Open();
				cmd.Connection = cnn;
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = nombreSP;
				tabla.Load(cmd.ExecuteReader());
			}
			catch (Exception ex)
			{
				throw ex;
			}
			finally
			{
				if (cnn.State == ConnectionState.Open)
					cnn.Close();
			}
			return tabla;
		}

		public int ProximoID(string nombreSP, string nombreParam)
		{
			SqlParameter param = new SqlParameter(nombreParam, SqlDbType.Int);
			try
			{
				cmd.Parameters.Clear();
				cnn.Open();
				cmd.Connection = cnn;
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = nombreSP;
				param.Direction = ParameterDirection.Output;
				cmd.Parameters.Add(param);
				cmd.ExecuteNonQuery();
				return (int)param.Value;
			}
			catch (Exception ex)
			{
				throw ex;
			}
			finally
			{
				if (cnn.State == ConnectionState.Open)
					cnn.Close();
			}
		}

		internal int EjecutarSQLMaestroDetalle(string spMaestro, string spDetalle, Factura oFactura, Accion modo)
		{
			int filasAfectadas = 0;
			SqlTransaction trans = null;

			try
			{
				cmd.Parameters.Clear();
				cnn.Open();
				trans = cnn.BeginTransaction();
				cmd.Connection = cnn;
				cmd.Transaction = trans;
				cmd.CommandText = spMaestro;
				cmd.CommandType = CommandType.StoredProcedure;

				if (modo == Accion.Create)
				{
					cmd.Parameters.AddWithValue("@cliente", oFactura.cliente);
					cmd.Parameters.AddWithValue("@forma", oFactura.formaPago);
					cmd.Parameters.AddWithValue("@nro", oFactura.nroFactura);
					cmd.Parameters.AddWithValue("@total", oFactura.total);

					cmd.ExecuteNonQuery();
				}

				int detalleNro = 1;

				foreach (DetalleFactura item in oFactura.Detalles)
				{
					SqlCommand cmdDet = new SqlCommand();
					cmdDet.Connection = cnn;
					cmdDet.Transaction = trans;
					cmdDet.CommandText = spDetalle;
					cmdDet.CommandType = CommandType.StoredProcedure;

					cmdDet.Parameters.AddWithValue("@nro", oFactura.nroFactura);
					cmdDet.Parameters.AddWithValue("@detalle", detalleNro);
					cmdDet.Parameters.AddWithValue("@id_producto", item.producto.idProducto);
					cmdDet.Parameters.AddWithValue("@cantidad", item.cantidad);
					filasAfectadas = cmdDet.ExecuteNonQuery();
					detalleNro++;
				}

				trans.Commit();
			}
			catch (Exception e)
			{
				throw e;
				string mensaje = e.Message;
				trans.Rollback();
				filasAfectadas = 0;
			}
			finally
			{
				if (cnn != null && cnn.State == ConnectionState.Open) cnn.Close();
			}

			return filasAfectadas;
		}
	}
}

