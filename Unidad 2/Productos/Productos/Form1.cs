using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Productos
{
    public partial class frmProductos : Form
    {
        List<Producto> lProductos = new List<Producto>();
        TipoProducto miTipo;

        enum TipoProducto
        {
            Suelto,
            Pack
        }

        public frmProductos()
        {
            InitializeComponent();
        }

        private void frmProductos_Load(object sender, EventArgs e)
        {

        }

        private void rbtSuelto_CheckedChanged(object sender, EventArgs e)
        {
            lblMedidaCantidad.Text = "Medida";
            miTipo = TipoProducto.Suelto;
        }

        private void rbtPack_CheckedChanged(object sender, EventArgs e)
        {
            lblMedidaCantidad.Text = "Cantidad";
            miTipo = TipoProducto.Pack;
        }

        private void btnCargarProd_Click(object sender, EventArgs e)
        {
            int cod = int.Parse(txtCodigo.Text);
            string nom = txtNombre.Text;
            double prec = double.Parse(txtPrecio.Text);
            int cant = int.Parse(txtMedidaCantidad.Text);

            if (rbtPack.Checked)
            {
                Pack p = new Pack(cod, nom, prec, cant);
                lProductos.Add(p);
            }
            else
            {
                Suelto s = new Suelto(cod, nom, prec, cant);
                lProductos.Add(s);
            }

            lstProductos.Items.Clear();
            lstProductos.Items.AddRange(lProductos.ToArray());
        }

        private void btnMostrarTotal_Click(object sender, EventArgs e)
        {
            double total = 0;
            for (int i = 0; i < lProductos.Count; i++)
            {
                total += lProductos[i].CalcularPrecio();
            }

            txtTotal.Text = total.ToString();

        }
    }
}
