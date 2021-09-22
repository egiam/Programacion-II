using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Carpinteria.Formularios
{
    public partial class frmConsultar : Form
    {
        public frmConsultar()
        {
            InitializeComponent();
        }

        private void frmConsultar_Load(object sender, EventArgs e)
        {
            CargarGrid();
            CargarDetalles();
        }

        private void CargarGrid()
        {
            grdConsultar.Rows.Clear();

            SqlConnection conexion = new SqlConnection();
            conexion.ConnectionString = @"Data Source=localhost\SQLEXPRESS;Initial Catalog=carpinteria_db;Integrated Security=True";
            conexion.Open();

            SqlCommand comando = new SqlCommand();
            comando.Connection = conexion;
            comando.CommandType = CommandType.StoredProcedure;
            comando.CommandText = "SP_CONSULTAR_PRESUPUESTOS";

            DataTable tabla = new DataTable();
            tabla.Load(comando.ExecuteReader());

            conexion.Close();

            for (int i = 0; i < tabla.Rows.Count; i++)
            {
                grdConsultar.Rows.Add(tabla.Rows[i]["NUMERO DE PRESUPUESTO"], tabla.Rows[i]["CLIENTE"], tabla.Rows[i]["FECHA"], tabla.Rows[i]["Descuento"], tabla.Rows[i]["TOTAL"]);
            }

        }

        private void CargarDetalles()

        {

            grdDetalles.Rows.Clear();

            int nroPresupuesto = Convert.ToInt32(grdConsultar.CurrentRow.Cells[0].Value);

            SqlConnection conexion = new SqlConnection();

            conexion.ConnectionString = @"Data Source=localhost\SQLEXPRESS;Initial Catalog=carpinteria_db;Integrated Security=True";

            conexion.Open();

            SqlCommand comando = new SqlCommand();

            comando.Connection = conexion;

            comando.CommandType = CommandType.StoredProcedure;

            comando.CommandText = "SP_CONSULTAR_DETALLES";

            comando.Parameters.AddWithValue(@"nro_presupuesto", nroPresupuesto);

            DataTable tabla = new DataTable();

            tabla.Load(comando.ExecuteReader());

            conexion.Close();


            for (int i = 0; i < tabla.Rows.Count; i++)

            {

                grdDetalles.Rows.Add(tabla.Rows[i]["PRODUCTO"], tabla.Rows[i]["PRECIO"], tabla.Rows[i]["CANTIDAD"]);

            }


        }


        private void BorrarPresupuesto()

        {

            int nroPresupuesto = Convert.ToInt32(grdConsultar.CurrentRow.Cells[0].Value);

            SqlConnection conexion = new SqlConnection();

            conexion.ConnectionString = @"Data Source=localhost\SQLEXPRESS;Initial Catalog=carpinteria_db;Integrated Security=True";

            conexion.Open();

            SqlCommand comando = new SqlCommand();

            comando.Connection = conexion;

            comando.CommandType = CommandType.StoredProcedure;

            comando.CommandText = "SP_BORRAR_PRESUPUESTO";

            comando.Parameters.AddWithValue(@"nro_presupuesto", nroPresupuesto);

            comando.ExecuteNonQuery();

            conexion.Close();

        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            BorrarPresupuesto();
        }
    }
}
