using ParcialApp.Dominio;
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

		public int EjecutarSQLMaestroDetalle(string spMaestro, string spDetalle, Factura oFactura, Accion modo)
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
					cmd.Parameters.AddWithValue("@nro", oFactura.NroFactura);
					cmd.Parameters.AddWithValue("@forma", oFactura.FormaPago);
					cmd.Parameters.AddWithValue("@cliente", oFactura.Cliente);
					cmd.Parameters.AddWithValue("@total", oFactura.Total);
					cmd.ExecuteNonQuery();
				}
				//if (modo == Accion.Update)
				//{
				//	cmd.Parameters.AddWithValue("@nro_presupuesto", oFactura.NroFactura);
				//	cmd.Parameters.AddWithValue("@fecha", oFactura.Fecha);
				//	cmd.Parameters.AddWithValue("@cliente", oFactura.Cliente);
				//	cmd.Parameters.AddWithValue("@total", oFactura.Total);
				//	cmd.ExecuteNonQuery();
				//}

				int detalleNro = 1;

				foreach (DetalleFactura item in oFactura.Detalles)
				{
					SqlCommand cmdDet = new SqlCommand();
					cmdDet.Connection = cnn;
					cmdDet.Transaction = trans;
					cmdDet.CommandText = spDetalle;
					cmdDet.CommandType = CommandType.StoredProcedure;

					cmdDet.Parameters.AddWithValue("@nro", oFactura.NroFactura);
					cmdDet.Parameters.AddWithValue("@detalle", detalleNro);
					cmdDet.Parameters.AddWithValue("@id_producto", item.Producto.IdProducto);
					cmdDet.Parameters.AddWithValue("@cantidad", item.Cantidad);
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

		public int ProximoID(string nombreSP, string nombreParam)
		{
			SqlParameter param = new SqlParameter(nombreParam, SqlDbType.Int);
			try
			{
				//Usa el siguiente codigo en SQL
				//create procedure pa_PROXIMO_ID
				//	@next int output
				//as
				//begin
				//	select @next = ISNULL(MAX(id_receta), 0) + 1 from Recetas
				//end
  

				  cmd.Parameters.Clear();
				cnn.Open();
				cmd.Connection = cnn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = nombreSP;
                param.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(param);
                cmd.ExecuteNonQuery();
                return (int)param.Value;

				//--Forma sin SP ni parametros

                //cmd.CommandType = CommandType.Text;//dice q es tipo texto 
                //cmd.CommandText = "select ISNULL(MAX(nro), 0)+1 from T_FACTURAS";
                //int nro = Convert.ToInt32(cmd.ExecuteScalar());				
                //return nro;
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
	}
}
