using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PyCarpinteria.dominio;

namespace PyCarpinteria.AccesoDatos
{
    class PresupuestoDao : IPresupuestoDao
    {
        public bool Crear(Presupuesto oPresupuesto)
        {
            return true;
        }

        public DataTable ListarProductos()
        {
            
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
