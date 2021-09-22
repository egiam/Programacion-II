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

namespace Carpinteria.Formularios
{
    public partial class frmPrincipal : Form
    {
        SqlConnection conexion = new SqlConnection(@"Data Source=localhost\SQLEXPRESS;Initial Catalog=carpinteria_db;Integrated Security=True");


        public frmPrincipal()
        {
            InitializeComponent();
        }

        private void frmCarpinteria_Load(object sender, EventArgs e)
        {

        }

        private void nuevoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmNuevoPresupuesto nuevo = new frmNuevoPresupuesto();
            nuevo.ShowDialog();
        }

        private void consultarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmConsultar nuevo = new frmConsultar();
            nuevo.ShowDialog();
        }
    }
}
