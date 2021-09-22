using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carpinteria.AccesoDatos
{
    class PresupuestoDao : IPresupuestoDao
    {
        public bool Crear(Presupuesto oPresupuesto)
        {
            bool estado = true;
            SqlConnection conexion = new SqlConnection();
            SqlTransaction transaccion = null;

            try
            {

                conexion.ConnectionString = @"Data Source=localhost\SQLEXPRESS;Initial Catalog=carpinteria_db;Integrated Security=True";
                conexion.Open();
                transaccion = conexion.BeginTransaction();

                SqlCommand comando = new SqlCommand();
                comando.Connection = conexion;
                comando.Transaction = transaccion;
                comando.CommandType = CommandType.StoredProcedure;
                comando.CommandText = "SP_INSERTAR_MAESTRO";

                comando.Parameters.AddWithValue("@cliente", oPresupuesto.Cliente);
                comando.Parameters.AddWithValue("@dto", oPresupuesto.Descuento);
                comando.Parameters.AddWithValue("@total", oPresupuesto.Total);

                SqlParameter param = new SqlParameter();
                param.ParameterName = "@presupuesto_nro";
                param.SqlDbType = SqlDbType.Int;
                param.Direction = ParameterDirection.Output;
                comando.Parameters.Add(param);
                comando.ExecuteNonQuery();
                oPresupuesto.PresupuestoNro = (int)param.Value;


                //for (int i = 0; i < Detalles.Count; i++)
                //{
                //    SqlCommand comandoDetalle = new SqlCommand();
                //    comandoDetalle.Connection = conexion;
                //    comandoDetalle.CommandType = CommandType.StoredProcedure;
                //    comandoDetalle.CommandText = "SP_INSERTAR_DETALLE";
                //    comandoDetalle.Parameters.AddWithValue("@presupuesto_nro", this.PresupuestoNro);
                //    comandoDetalle.Parameters.AddWithValue("@detalle", i+1);
                //    comandoDetalle.Parameters.AddWithValue("@id_producto", Detalles[i].Producto.ProductoNro);
                //    comandoDetalle.Parameters.AddWithValue("@cantidad", Detalles[i].Cantidad);
                //    comandoDetalle.ExecuteNonQuery();
                //}

                int DetalleNro = 1;
                foreach (DetallePresupuesto item in oPresupuesto.Detalles)
                {
                    SqlCommand comandoDetalle = new SqlCommand();
                    comandoDetalle.Connection = conexion;
                    comandoDetalle.Transaction = transaccion;
                    comandoDetalle.CommandType = CommandType.StoredProcedure;
                    comandoDetalle.CommandText = "SP_INSERTAR_DETALLE";

                    comandoDetalle.Parameters.AddWithValue("@presupuesto_nro", oPresupuesto.PresupuestoNro);
                    comandoDetalle.Parameters.AddWithValue("@detalle", DetalleNro);
                    comandoDetalle.Parameters.AddWithValue("@id_producto", item.Producto.ProductoNro);
                    comandoDetalle.Parameters.AddWithValue("@cantidad", item.Cantidad);

                    comandoDetalle.ExecuteNonQuery();
                    DetalleNro++;
                }

                transaccion.Commit();
            }
            catch (Exception)
            {
                transaccion.Rollback();
                estado = false;
            }
            finally
            {
                if (conexion.State == ConnectionState.Open)
                    conexion.Close();
            }

            return estado;
        }

        public DataTable ListarProductos()
        {
            SqlConnection conexion = new SqlConnection();
            conexion.ConnectionString = @"Data Source=localhost\SQLEXPRESS;Initial Catalog=carpinteria_db;Integrated Security=True";
            conexion.Open();

            SqlCommand comando = new SqlCommand();
            comando.Connection = conexion;
            comando.CommandType = CommandType.StoredProcedure;
            comando.CommandText = "SP_CONSULTAR_PRODUCTOS";

            DataTable tabla = new DataTable();
            tabla.Load(comando.ExecuteReader());

            conexion.Close();

            return tabla;
        }

        public int ObtenerProxNro()
        {
            SqlConnection conexion = new SqlConnection();
            conexion.ConnectionString = @"Data Source=localhost\SQLEXPRESS;Initial Catalog=carpinteria_db;Integrated Security=True";
            conexion.Open();

            SqlCommand comando = new SqlCommand();
            comando.Connection = conexion;
            comando.CommandType = CommandType.StoredProcedure;
            comando.CommandText = "SP_PROXIMO_ID";

            SqlParameter param = new SqlParameter("@next", SqlDbType.Int);
            param.Direction = ParameterDirection.Output;
            comando.Parameters.Add(param);

            comando.ExecuteNonQuery(); //NonQuery cuando es un insert, update, delete

            conexion.Close();

            return (int)param.Value;
        }
    }
}
