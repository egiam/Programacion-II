using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carpinteria.AccesoDatos
{
    class HelperDao
    {

        private static HelperDao instancia;
        private string cadenaConexion;
        private HelperDao()
        {
            cadenaConexion = "";
        }
        private static HelperDao obtenerInstancia()
        {
            if (instancia == null)
            {
                instancia = new HelperDao();
            }
            return instancia;
        }

        public DataTable consultaSQL()
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

    }
}
