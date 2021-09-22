using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using Carpinteria.Servicios;
using Carpinteria.AccesoDatos;

namespace Carpinteria.Formularios
{
    public partial class frmNuevoPresupuesto : Form
    {
        Presupuesto nuevo;
        private GestorPresupuesto gestor;

        public frmNuevoPresupuesto()
        {
            InitializeComponent();
            nuevo = new Presupuesto();
            gestor = new GestorPresupuesto(new DaoFactory);
        }

        private void frmNuevoPresupuesto_Load(object sender, EventArgs e)
        {
            lblNroPresupuesto.Text += ProximoPresupuesto();
            CargarProductos();
            txtFecha.Text = DateTime.Today.ToString("dd/MM/yyyy");
            txtCliente.Text = "Consumidor Final";
            txtDescuento.Text = "0";
            txtCantidad.Text = "1";

        }

        private void CargarProductos()
        {
            DataTable tabla = gestor.ObtenerProductos();

            cboProductos.DataSource = tabla;
            cboProductos.DisplayMember = tabla.Columns[1].ColumnName;
            cboProductos.ValueMember = tabla.Columns[0].ColumnName;
            cboProductos.DropDownStyle = ComboBoxStyle.DropDownList;

        }

        private int ProximoPresupuesto()
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

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (cboProductos.Text.Equals(string.Empty))
            {
                MessageBox.Show("Debe seleccionar un producto.", "Control", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (string.IsNullOrEmpty(txtCantidad.Text) || !int.TryParse(txtCantidad.Text,out _))//Out como el retorn del tryparse
            {
                MessageBox.Show("Debe ingresar una cantidad valida.", "Control", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            foreach (DataGridViewRow row  in dgvDetalles.Rows)
            {
                if (row.Cells["cProducto"].Value.ToString().Equals(cboProductos.Text))
                {
                    MessageBox.Show("Este producto ya esta presupuestado.", "Control", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
            }

            DataRowView item = (DataRowView)cboProductos.SelectedItem;
            int prod = Convert.ToInt32(item.Row.ItemArray[0]);
            string nom = item.Row.ItemArray[1].ToString();
            double pre = Convert.ToDouble(item.Row.ItemArray[2]);
            int cant = Convert.ToInt32(txtCantidad.Text);

            Producto p = new Producto(prod, nom, pre);
            DetallePresupuesto detalle = new DetallePresupuesto(p, cant);

            nuevo.AgregarDetalle(detalle);
            dgvDetalles.Rows.Add(new object[] { prod, nom, pre, cant });

            CalcularTotales();

        }

        private void TotalYSub()
        {
            txtSubtotal.Text = nuevo.CalcularTotal().ToString();

            double desc = nuevo.CalcularTotal() * Convert.ToDouble(txtDescuento.Text) / 100;
            txtTotal.Text = (nuevo.CalcularTotal() - desc).ToString();
        }

        private void dgvDetalles_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvDetalles.CurrentCell.ColumnIndex == 4)
            {
                nuevo.QuitarDetalle(dgvDetalles.CurrentRow.Index);
                dgvDetalles.Rows.Remove(dgvDetalles.CurrentRow);

                CalcularTotales();
            }
        }

        private void CalcularTotales()
        {
            txtSubtotal.Text = nuevo.CalcularTotal().ToString();
            double desc = nuevo.CalcularTotal() * Convert.ToDouble(txtDescuento.Text) / 100;
            txtTotal.Text = (nuevo.CalcularTotal() - desc).ToString();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            //Validar
            if (txtCliente.Text == "")
            {
                MessageBox.Show("Debe ingresar un cliente.", "Control", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (dgvDetalles.Rows.Count == 0)
            {
                MessageBox.Show("Debe ingresar un detalle al menos.", "Control", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cboProductos.Focus();
                return;
            }

            GuardarPresupuesto();

        }

        private void GuardarPresupuesto()
        {
            nuevo.Fecha = Convert.ToDateTime(txtFecha.Text);
            nuevo.Cliente = txtCliente.Text;
            nuevo.Descuento = Convert.ToDouble(txtDescuento.Text);
            nuevo.Total = Convert.ToDouble(txtTotal.Text);
            if (gestor.ConfirmarPresupuesto(nuevo))
            {
                MessageBox.Show("El presupuesto se grabo correctamente.", "Notificacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Dispose();
            }
            else
            {
                MessageBox.Show("El presupuesto NO se pudo grabar correctamente.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
