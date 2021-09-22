using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProductosConInterface
{
    public partial class frmProductos : Form
    {
        List<IProducto> lProductos = new List<IProducto>();
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

        private void btnCargar_Click(object sender, EventArgs e)
        {
            //VALIDAR !!!

            int cod, cant;
            string nom;
            double pre;
            cod = int.Parse(txtCodigo.Text);
            nom = txtNombre.Text;
            pre = double.Parse(txtPrecio.Text);
            cant = int.Parse(txtMedidaCantidad.Text);

            //if (rbtPack.Checked)
            if (miTipo==TipoProducto.Pack)
            { // cargar Pack
                Pack p = new Pack(cod, nom, pre, cant);
                lProductos.Add(p);
            }
            else
            { // cargar Suelto
                Suelto s = new Suelto(cod, nom, pre, cant);
                lProductos.Add(s);
            }

            lstProductos.Items.Clear();
            lstProductos.Items.AddRange(lProductos.ToArray());

        }

        private void btnTotal_Click(object sender, EventArgs e)
        {
            double total = 0;
            //for (int i = 0; i < lProductos.Count; i++)
            //{
            //    total += lProductos[i].CalcularPrecio();
            //}
            foreach (IProducto x in lProductos)
            {
                total += x.CalcularPrecio();
            }

            txtTotal.Text = total.ToString();
        }

        private void frmProductos_Load(object sender, EventArgs e)
        {

        }
    }
}
