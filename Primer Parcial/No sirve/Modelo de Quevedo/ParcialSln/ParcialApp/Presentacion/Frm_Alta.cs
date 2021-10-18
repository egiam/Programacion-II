
using ParcialApp.Acceso_a_datos;
using ParcialApp.Dominio;
using ParcialApp.Servicios;
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

namespace ParcialApp.Presentacion
{
    public partial class Frm_Alta : Form
    {
        private Factura oFactura;
        private GestorFactura gestor;
        private Accion modo;
        public Frm_Alta()
        {
            InitializeComponent();
            oFactura = new Factura();
            gestor = new GestorFactura(new DaoFactory());
        }

        public enum Accion
        {
            Create,
            Read,
            Update,
            Delete
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (txtCliente.Text == "")
            {
                MessageBox.Show("Debe especificar un cliente.", "Control", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtCliente.Focus();
                return;
            }
            if (dgvDetalles.Rows.Count == 0)
            {
                MessageBox.Show("Debe ingresar al menos un detalle.", "Control", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cboProducto.Focus();
                return;
            }
			if (cboForma.SelectedIndex == -1)
			{
                MessageBox.Show("Debe seleccionar al menos una forma de pago.", "Control", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cboProducto.Focus();
                return;
            }

            CalcularTotales();
            GuardarPresupuesto();
        }

		private void GuardarPresupuesto()
		{
            oFactura.NroFactura = gestor.ProximaFactura();
            oFactura.Fecha = Convert.ToDateTime(dtpFecha.Value);
            oFactura.Cliente = txtCliente.Text;
            oFactura.FormaPago = cboForma.SelectedIndex;
            oFactura.Total = Convert.ToDouble(oFactura.CalcularTotal());

            if (modo.Equals(Accion.Create))
            {
                if (gestor.NuevoPresupuesto(oFactura))
                {
                    MessageBox.Show("Factura registrada con exito.", "Informe", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LimpiarCampos();
                }
                else
                {
                    MessageBox.Show("ERROR. No se pudo registrar la factura.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
          
        }

		private void LimpiarCampos()
		{
            lblNro.Text = "Factura N° ";
            lblNro.Text += gestor.ProximaFactura();
            dtpFecha.Value = DateTime.Today;
            txtCliente.Text = "Consumidor Final";
            cboForma.SelectedIndex = -1;
            dgvDetalles.Rows.Clear();
            nudCantidad.Value = 1;
            oFactura = null;
        }

		private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("¿Está seguro que desea cancelar?", "Salir", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                this.Dispose();

            }
            else
            {
                return;
            }
        }

        private void Frm_Alta_Presupuesto_Load(object sender, EventArgs e)
        {
            CargarCombo();
            if (modo.Equals(Accion.Create))
            {
                lblNro.Text += gestor.ProximaFactura();
                dtpFecha.Value = DateTime.Today;
                txtCliente.Text = "Consumidor Final";
            }
        }

        private void CargarCombo()
        {
            List<Producto> lst = gestor.ObtenerProductos();
            cboProducto.DataSource = lst;
            cboProducto.ValueMember = "IdProducto";
            cboProducto.DisplayMember = "NProducto";
            cboProducto.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (cboProducto.Text.Equals(string.Empty))
            {
                MessageBox.Show("Debe seleccionar un producto", "Control", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            //foreach (DataGridViewRow row in dgvDetalles.Rows)
            //{
            //    if (row.Cells["producto"].Value.ToString().Equals(cboProducto.Text))
            //    {
            //        MessageBox.Show("Este producto ya se encuentra registrado", "Control", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            //        return;
            //    }
            //}
            if (ExisteProductoEnGrilla(cboProducto.SelectedItem.ToString()))
            { 
             MessageBox.Show("Este producto ya se encuentra registrado", "Control", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
             return;
            }

            Producto oProducto = (Producto)cboProducto.SelectedItem;
            DetalleFactura detalle = new DetalleFactura();

            detalle.Producto = oProducto;
            detalle.Cantidad = Convert.ToInt32(nudCantidad.Text);

            oFactura.AgregarDetalle(detalle);
            dgvDetalles.Rows.Add(new object[] { oProducto.IdProducto, oProducto.NProducto, "$ " + oProducto.Precio, detalle.Cantidad, "$ " + detalle.CalcularSubtotal() });

            CalcularTotales();
        }

		private void CalcularTotales()
		{

            lblSubtotal.Text = "Subtotal $ " + oFactura.CalcularTotal().ToString();
      
            lblTotal.Text = "Total $ "+ oFactura.CalcularTotal().ToString();
            
        }

		private bool ExisteProductoEnGrilla(string text)
        {
            foreach (DataGridViewRow fila in dgvDetalles.Rows)
            {
                if (fila.Cells["producto"].Value.Equals(text))
                    return true;
            }
            return false;
        }
        private void dgvDetalles_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvDetalles.CurrentCell.ColumnIndex == 5)
            {
                oFactura.QuitarDetalle(dgvDetalles.CurrentRow.Index);
                dgvDetalles.Rows.Remove(dgvDetalles.CurrentRow);
                CalcularTotales();
            }
        }
    }
}
