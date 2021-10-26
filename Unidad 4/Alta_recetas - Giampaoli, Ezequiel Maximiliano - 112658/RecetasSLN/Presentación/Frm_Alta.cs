
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
using RecetasSLN.Acceso_a_Datos;
using RecetasSLN.Dominio;
using RecetasSLN.Servicios;

namespace RecetasSLN
{
    public partial class Frm_Alta : Form
    {
        private GestorReceta gestor;
        private Receta oReceta;
        private Accion modo;

        public Frm_Alta()
        {
            InitializeComponent();
            gestor = new GestorReceta(new DaoFactory());
            oReceta = new Receta();
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
            if (txtCheff.Text == "")
            {
                MessageBox.Show("Debe especificar un Cheff.", "Control", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtCheff.Focus();
                return;
            }
            if (txtNombre.Text == "")
            {
                MessageBox.Show("Debe especificar un Nombre.", "Control", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtNombre.Focus();
                return;
            }
            if (dgvDetalles.Rows.Count < 3)
            {
                MessageBox.Show("Debe ingresar al menos tres ingredientes.", "Control", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cboProducto.Focus();
                return;
            }

            CalcularTotales();
            GuardarPresupuesto();
        }

        private void GuardarPresupuesto()
        {
            oReceta.recetaNro = gestor.ProximaFactura();
            oReceta.tipo_receta = cboTipo.SelectedIndex;
            oReceta.nombre = txtNombre.Text;
            oReceta.cheff = txtCheff.Text;

            if (modo.Equals(Accion.Create))
            {
                if (gestor.NuevaFactura(oReceta))
                {
                    MessageBox.Show("Receta registrada con exito.", "Informe", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //Close();
                    NuevaFactura();
                }
                else
                {
                    MessageBox.Show("ERROR. No se pudo registrar la factura.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            //else
            //{
            //    if (gestor.EditarPresupuesto(oPresupuesto))
            //    {
            //        MessageBox.Show("Presupuesto editado con exito.", "Informe", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //        Close();
            //    }
            //    else
            //    {
            //        MessageBox.Show("ERROR. No se pudo editar el presupuesto.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    }
            //}


        }

        private void NuevaFactura()
        {
            lblNro.Text = "Receta N°" + gestor.ProximaFactura();
            txtCheff.Text = "Cheff";
            txtNombre.Text = "Consumidor Final";
            cboTipo.SelectedIndex = 0;
            dgvDetalles.Rows.Clear();
            oReceta = null;
            cboTipo.Enabled = true;
        }

        private void CalcularTotales()
        {
            lblTotal.Text = "Total de ingredientes: " + oReceta.ToString();
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
                txtCheff.Text = "Cheff";
                txtNombre.Text = "Consumidor Final";
                cboTipo.SelectedIndex = 0;
            }
        }

        private void CargarCombo()
        {
            List<Ingrediente> lst = gestor.ObtenerProductos();
            cboProducto.DataSource = lst;
            cboProducto.ValueMember = "ingredienteId";
            cboProducto.DisplayMember = "nombre";
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (cboProducto.Text.Equals(string.Empty))
            {
                MessageBox.Show("Debe seleccionar un producto", "Control", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            //if (string.IsNullOrEmpty(txtCantidad.Text) || !int.TryParse(txtCantidad.Text, out _))
            //{
            //    MessageBox.Show("Debe ingresar una cantidad valida", "Control", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            //    return;
            //}
            //foreach (DataGridViewRow row in dgvDetalles.Rows)
            //{
            //    if (row.Cells["ColProd"].Value.ToString().Equals(cboProducto.Text))
            //    {
            //        MessageBox.Show("Este producto ya se encuentra presupuestado", "Control", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            //        return;
            //    }
            //}
            if (ExisteProductoEnGrilla(cboProducto.SelectedItem.ToString()))
            {
                MessageBox.Show("Este producto ya se encuentra registrado", "Control", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            cboTipo.Enabled = false;

            Ingrediente oIngrediente = (Ingrediente)cboProducto.SelectedItem;
            DetalleReceta detalle = new DetalleReceta();

            detalle.ingrediente = Convert.ToInt32(oIngrediente.ingredienteId);
            detalle.cantidad = Convert.ToInt32(nudCantidad.Value);

            oReceta = new Receta();
            oReceta.AgregarDetalle(detalle);
            dgvDetalles.Rows.Add(new object[] { oIngrediente.nombre, detalle.cantidad, oIngrediente.unidad});

            CalcularTotales();
        }

        private bool ExisteProductoEnGrilla(string text)
        {
            foreach (DataGridViewRow fila in dgvDetalles.Rows)
            {
                if (fila.Cells["ingrediente"].Value.Equals(text))
                    return true;
            }
            return false;
        }       



        private void dgvDetalles_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvDetalles.CurrentCell.ColumnIndex == 5)
            {
                oReceta.QuitarDetalle(dgvDetalles.CurrentRow.Index);
                dgvDetalles.Rows.Remove(dgvDetalles.CurrentRow);
                CalcularTotales();
            }
        }
    }
}
