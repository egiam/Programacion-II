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
            cadenaConexion = Properties.Resources.strConexion;
        }

        private static HelperDao ObtenerInstancia()
        {
            if (instancia == null)
            {
                instancia = new HelperDao();
            }
            return instancia;
        }

        public DataTable ConsultaSQL(string nombreSP)
        {
            SqlConnection conexion = new SqlConnection();
            SqlCommand comando = new SqlCommand();
            DataTable tabla = new DataTable();
            try
            {
                conexion.ConnectionString = cadenaConexion;
                conexion.Open();            
                comando.Connection = conexion;
                comando.CommandType = CommandType.StoredProcedure;
                comando.CommandText = nombreSP;            
                tabla.Load(comando.ExecuteReader());
                conexion.Close();

                return tabla;
            }
            catch(SqlException ex)
            {
                throw (ex);
            }
            finally
            {
                if (conexion.State == ConnectionState.Open)
                    conexion.Close();
            }
            
        }

        public int ProximoID(string nombreSP, string nombreParametro)
        {
            SqlConnection conexion = new SqlConnection();
            SqlCommand comando = new SqlCommand();
            SqlParameter param = new SqlParameter(nombreParametro, SqlDbType.Int);

            try
            {
                conexion.ConnectionString = @"Data Source=localhost\SQLEXPRESS;Initial Catalog=carpinteria_db;Integrated Security=True";
                conexion.Open();            
                comando.Connection = conexion;
                comando.CommandType = CommandType.StoredProcedure;
                comando.CommandText = nombreSP;
                
                param.Direction = ParameterDirection.Output;
                comando.Parameters.Add(param);

                comando.ExecuteReader(); 
                //NonQuery cuando es un insert, update, delete

                conexion.Close();

                return (int)param.Value;
            }
            catch (SqlException ex)
            {
                throw (ex);
            }
            finally
            {
                if (conexion.State == ConnectionState.Open)
                    conexion.Close();
            }
        }

        public int EjecutarSQL(string nombreSP, Dictionary<string,object> parametros)
        {
            SqlConnection conexion = new SqlConnection();
            SqlCommand comando = new SqlCommand();
            int filasAfectadas = 0;

            try
            {
                conexion.ConnectionString = @"Data Source=localhost\SQLEXPRESS;Initial Catalog=carpinteria_db;Integrated Security=True";
                conexion.Open();
                comando.Connection = conexion;
                comando.CommandType = CommandType.StoredProcedure;
                comando.CommandText = nombreSP;

                foreach (var item in parametros)
                {
                    comando.Parameters.AddWithValue(item.Key, item);
                }

                comando.ExecuteNonQuery();
                //NonQuery cuando es un insert, update, delete

                conexion.Close();                
            }
            catch (SqlException ex)
            {
                throw (ex);
            }
            finally
            {
                if (conexion.State == ConnectionState.Open)
                    conexion.Close();
            }

            return filasAfectadas;
        }

    }
}
